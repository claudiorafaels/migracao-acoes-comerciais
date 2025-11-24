using Marketing.GestaoVerbas.Core.Grid;
using Marketing.GestaoVerbas.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbas.Api
{
    public class NegociacaoVerbaApi
    {


        public static RetornoApi List(GridSetings<ViewModel.NegociacaoVerbaViewModel> gridSetings)
        {
            RetornoApi retorno = new RetornoApi();

            retorno.Resultado = gridSetings;
            try
            {
                RetornoApi retornoPost = RestApi.Post(string.Format("/negociacaoverba/{0}/{1}/{2}/{3}/list", gridSetings.Setings.CurrentPage, gridSetings.Setings.PageSize, gridSetings.Setings.Column, gridSetings.Setings.Way), gridSetings.Filtro);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }
                ListResult<NegociacaoVerbaViewModel> listResult = JsonConvert.DeserializeObject<ListResult<NegociacaoVerbaViewModel>>((string)retornoPost.Resultado);

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

        public static RetornoApi Select(int pCodNegociacaoVerba)
        {
            RetornoApi retorno = new RetornoApi();

            try
            {
                RetornoApi retornoGet = RestApi.Get(string.Format("/negociacaoverba/{0}/select", pCodNegociacaoVerba));
                if (!retornoGet.Sucesso)
                {
                    return retornoGet;
                }
                retorno.Resultado = JsonConvert.DeserializeObject<NegociacaoVerbaViewModel>((string)retornoGet.Resultado);
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

        public static RetornoApi Insert(NegociacaoVerbaViewModel obj)
        {
            RetornoApi retorno = new RetornoApi();

            try
            {
                RetornoApi retornoPost = RestApi.Post("/negociacaoverba/insert", obj);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }
                retorno.Resultado = JsonConvert.DeserializeObject<NegociacaoVerbaViewModel>((string)retornoPost.Resultado);
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

        public static RetornoApi Update(NegociacaoVerbaViewModel obj)
        {
            RetornoApi retorno = new RetornoApi();

            try
            {
                RetornoApi retornoPost = RestApi.Put(string.Format("/negociacaoverba/{0}/update", obj.CodNegociacaoVerba), obj);
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

        public static RetornoApi Delete(int pCodNegociacaoVerba)
        {
            RetornoApi retorno = new RetornoApi();

            try
            {
                RetornoApi retornoGet = RestApi.Delete(string.Format("/negociacaoverba/{0}/delete", pCodNegociacaoVerba));
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

        public static RetornoApi SolicitarAprovacao(int pCodNegociacaoVerba, int pCodUsuario)
        {
            RetornoApi retorno = new RetornoApi();

            try
            {
                RetornoApi retornoApi = RestApi.Patch(string.Format("/negociacaoverba/{0}/{1}/solicitaraprovacao", pCodNegociacaoVerba, pCodUsuario));
                if (!retornoApi.Sucesso)
                {
                    return retornoApi;
                }
                retorno.Resultado = true;
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

        public static RetornoApi Aprovar(int pCodNegociacaoVerba, int pCodUsuario, AcordoViewModel pAcordo)
        {
            RetornoApi retorno = new RetornoApi();

            try
            {
                RetornoApi retornoPost = RestApi.Patch(string.Format("/negociacaoverba/{0}/{1}/aprovar", pCodNegociacaoVerba, pCodUsuario), pAcordo);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }
                retorno.Resultado = JsonConvert.DeserializeObject<List<AcordoViewModel>>(retornoPost.Resultado as string);
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

        public static RetornoApi Reprovar(int pCodNegociacaoVerba, string pDesJustificativaReprovacao, int pCodUsuario)
        {
            RetornoApi retorno = new RetornoApi();

            try
            {

                var parametros = new Dictionary<String, String>();
                parametros.Add("DesJustificativaReprovacao", pDesJustificativaReprovacao);

                RetornoApi retornoPost = RestApi.Patch(string.Format("/negociacaoverba/{0}/{1}/reprovar", pCodNegociacaoVerba, pCodUsuario), parametros);
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

        

    }
}