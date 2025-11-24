using Marketing.GestaoVerbas.Core.Grid;
using Marketing.GestaoVerbas.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Marketing.GestaoVerbas.Api
{
    public class MenuApi
    {
        public static RetornoApi List(GridSetings<ViewModel.MenuViewModel> gridSetings)
        {
            RetornoApi retorno = new RetornoApi();

            retorno.Resultado = gridSetings;
            try
            {
                RetornoApi retornoPost = RestApi.Post(string.Format("/menu/{0}/{1}/{2}/{3}/list", gridSetings.Setings.CurrentPage, gridSetings.Setings.PageSize, gridSetings.Setings.Column, gridSetings.Setings.Way), gridSetings.Filtro);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }
                ListResult<MenuViewModel> listResult = JsonConvert.DeserializeObject<ListResult<MenuViewModel>>((string)retornoPost.Resultado);

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

        public static RetornoApi SelectPorGrupo(int pCodGrupoAcesso)
        {
            RetornoApi retorno = new RetornoApi();

            try
            {
                retorno = RestApi.Get(string.Format("/menu/{0}/selectporgrupo", pCodGrupoAcesso));
                if (!retorno.Sucesso)
                {
                    return retorno;
                }
                retorno.Resultado = JsonConvert.DeserializeObject<List<MenuViewModel>>((string)retorno.Resultado);
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

        public static RetornoApi ListMenuPorGrupos(string pListGrupos)
        {
            RetornoApi retorno = new RetornoApi();

            try
            {
                retorno = RestApi.Post(string.Format("/menu/listmenuporgrupos"), pListGrupos);
                if (!retorno.Sucesso)
                {
                    return retorno;
                }

                retorno.Resultado = JsonConvert.DeserializeObject<List<MenuViewModel>>((string)retorno.Resultado);
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }
    }
}