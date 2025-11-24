using Marketing.GestaoVerbas.Core.Grid;
using Marketing.GestaoVerbas.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbas.Api
{
    public class FilialEmpresaApi
    {
        public static RetornoApi List(GridSetings<ViewModel.FilialEmpresaViewModel> gridSetings)
        {
            RetornoApi retorno = new RetornoApi();

            retorno.Resultado = gridSetings;
            try
            {
                RetornoApi retornoPost = RestApi.Post(string.Format("/FilialEmpresa/{0}/{1}/{2}/{3}/list", gridSetings.Setings.CurrentPage, gridSetings.Setings.PageSize, gridSetings.Setings.Column, gridSetings.Setings.Way), gridSetings.Filtro);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }
                ListResult<FilialEmpresaViewModel> listResult = JsonConvert.DeserializeObject<ListResult<FilialEmpresaViewModel>>((string)retornoPost.Resultado);

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

        public static RetornoApi ListLookup()
        {
            RetornoApi retorno = new RetornoApi();

            try
            {
                RetornoApi retornoPost = RestApi.Get(string.Format("/FilialEmpresa/ListLookup"));
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }
                List<FilialEmpresaViewModel> listResult = JsonConvert.DeserializeObject<List<FilialEmpresaViewModel>>((string)retornoPost.Resultado);

                retorno.Resultado = listResult;
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

    }
}