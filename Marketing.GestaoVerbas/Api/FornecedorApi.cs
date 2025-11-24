using Marketing.GestaoVerbas.Core.Grid;
using Marketing.GestaoVerbas.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Marketing.GestaoVerbas.Api
{
    public class FornecedorApi
    {
        public static RetornoApi List(GridSetings<ViewModel.FornecedorViewModel> gridSetings)
        {
            RetornoApi retorno = new RetornoApi();

            retorno.Resultado = gridSetings;
            try
            {
                RetornoApi retornoPost = RestApi.Post(string.Format("/Fornecedor/{0}/{1}/{2}/{3}/list", gridSetings.Setings.CurrentPage, gridSetings.Setings.PageSize, gridSetings.Setings.Column, gridSetings.Setings.Way), gridSetings.Filtro);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }
                ListResult<FornecedorViewModel> listResult = JsonConvert.DeserializeObject<ListResult<FornecedorViewModel>>((string)retornoPost.Resultado);

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



        public static RetornoApi ListPorCompradorFilial(int codFilialEmpresa, int codComprador)
        {
            RetornoApi retorno = new RetornoApi();

            try
            {
                RetornoApi retornoPost = RestApi.Get(string.Format("/Fornecedor/{0}/{1}/ListPorCompradorFilial", codFilialEmpresa, codComprador));
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }
                retorno.Resultado = JsonConvert.DeserializeObject<List<FornecedorViewModel>>((string)retornoPost.Resultado);

            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }
    }
}