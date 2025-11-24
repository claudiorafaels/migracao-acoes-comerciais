using Marketing.GestaoVerbas.Core.Grid;
using Marketing.GestaoVerbas.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbas.Api
{
    public class FuncionarioApi
    {

        public static RetornoApi List(GridSetings<ViewModel.FuncionarioViewModel> gridSetings)
        {
            RetornoApi retorno = new RetornoApi();

            retorno.Resultado = gridSetings;
            try
            {
                var parametros = new Dictionary<String, String>();
                if (gridSetings.Filtro.CodFuncionario != null)
                    parametros.Add("CodFuncionario", gridSetings.Filtro.CodFuncionario.ToString());
                if (gridSetings.Filtro.NomFuncionario != null)
                    parametros.Add("NomFuncionario", gridSetings.Filtro.NomFuncionario.ToString());
                if (gridSetings.Filtro.CodEmpresa != null)
                    parametros.Add("CodEmpresa", gridSetings.Filtro.CodEmpresa.ToString());

                RetornoApi retornoPost = RestApi.Post(string.Format("/Funcionario/{0}/{1}/{2}/{3}/list", gridSetings.Setings.CurrentPage, gridSetings.Setings.PageSize, gridSetings.Setings.Column, gridSetings.Setings.Way), parametros);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }
                ListResult< FuncionarioViewModel > listResult = JsonConvert.DeserializeObject<ListResult<FuncionarioViewModel>>((string)retornoPost.Resultado);

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
    }
}