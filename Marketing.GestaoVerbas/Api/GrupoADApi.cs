using Marketing.GestaoVerbas.Core.Grid;
using Marketing.GestaoVerbas.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Marketing.GestaoVerbas.Api
{
    public class GrupoADApi
    {
        public static RetornoApi List(GridSetings<ViewModel.GrupoADViewModel> gridSetings)
        {
            RetornoApi retorno = new RetornoApi();

            retorno.Resultado = gridSetings;
            try
            {
                RetornoApi retornoPost = RestApi.Post(string.Format("/grupoad/{0}/{1}/{2}/{3}/list", gridSetings.Setings.CurrentPage, gridSetings.Setings.PageSize, gridSetings.Setings.Column, gridSetings.Setings.Way), gridSetings.Filtro);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }
                ListResult<GrupoADViewModel> listResult = JsonConvert.DeserializeObject<ListResult<GrupoADViewModel>>((string)retornoPost.Resultado);

                gridSetings.Result = listResult.Result;
                gridSetings.Setings.TotalRows = listResult.TotalRows;
                gridSetings.Setings.CurrentPageSize = listResult.Result.Count;

                retorno.Resultado = gridSetings;
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

        public static RetornoApi Select(int pCodGrupoAcesso)
        {
            RetornoApi retorno = new RetornoApi();

            try
            {
                RetornoApi retornoGet = RestApi.Get(string.Format("/grupoad/{0}/select", pCodGrupoAcesso));
                if (!retornoGet.Sucesso)
                {
                    return retornoGet;
                }
                retorno.Resultado = JsonConvert.DeserializeObject<GrupoADViewModel>((string)retornoGet.Resultado);
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

        public static RetornoApi Insert(GrupoADViewModel obj)
        {
            RetornoApi retorno = new RetornoApi();

            try
            {
                RetornoApi retornoPost = RestApi.Post("/grupoad/insert", obj);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }
                retorno.Resultado = JsonConvert.DeserializeObject<GrupoADViewModel>((string)retornoPost.Resultado);
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

        public static RetornoApi Update(GrupoADViewModel obj)
        {
            RetornoApi retorno = new RetornoApi();

            try
            {
                RetornoApi retornoPost = RestApi.Put(string.Format("/grupoad/{0}/update", obj.CodGrupoAcesso), obj);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }
                retorno.Resultado = true;
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

        public static RetornoApi Delete(int pCodGrupoAcesso)
        {
            RetornoApi retorno = new RetornoApi();

            try
            {
                RetornoApi retornoGet = RestApi.Delete(string.Format("/grupoad/{0}/delete", pCodGrupoAcesso));
                if (!retornoGet.Sucesso)
                {
                    return retornoGet;
                }
                retorno.Resultado = true;
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }
    }
}