using Marketing.GestaoVerbas.Core.Grid;
using Marketing.GestaoVerbas.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbas.Api
{
    public class RelatoriosVerbasEmitidasApi
    {
        public static RetornoApi PorCarrimboMercadoria(GridSetings<RelatoriosVerbasEmitidasViewModel> gridSetings)
        {
            RetornoApi retorno = new RetornoApi();

            retorno.Resultado = gridSetings;
            try
            {

                RetornoApi retornoPost = RestApi.Post(string.Format("/RelatoriosVerbasEmitidas/{0}/{1}/{2}/{3}/PorCarrimboMercadoria", gridSetings.Setings.CurrentPage, gridSetings.Setings.PageSize, gridSetings.Setings.Column, gridSetings.Setings.Way), gridSetings.Filtro);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }

                ListResult<RelatoriosVerbasEmitidasViewModel> listResult = JsonConvert.DeserializeObject<ListResult<RelatoriosVerbasEmitidasViewModel>>((string)retornoPost.Resultado);

                gridSetings.Result = listResult.Result;
                gridSetings.Setings.TotalRows = listResult.TotalRows;
                gridSetings.Setings.CurrentPageSize = listResult.Result.Count;
                gridSetings.AggregateSummary = listResult.AggregateSummary;

                retorno.Resultado = gridSetings;
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

        public static RetornoApi PorCarrimboFornecedor(GridSetings<RelatoriosVerbasEmitidasViewModel> gridSetings)
        {
            RetornoApi retorno = new RetornoApi();

            retorno.Resultado = gridSetings;
            try
            {

                RetornoApi retornoPost = RestApi.Post(string.Format("/RelatoriosVerbasEmitidas/{0}/{1}/{2}/{3}/PorCarrimboFornecedor", gridSetings.Setings.CurrentPage, gridSetings.Setings.PageSize, gridSetings.Setings.Column, gridSetings.Setings.Way), gridSetings.Filtro);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }

                ListResult<RelatoriosVerbasEmitidasViewModel> listResult = JsonConvert.DeserializeObject<ListResult<RelatoriosVerbasEmitidasViewModel>>((string)retornoPost.Resultado);

                gridSetings.Result = listResult.Result;
                gridSetings.Setings.TotalRows = listResult.TotalRows;
                gridSetings.Setings.CurrentPageSize = listResult.Result.Count;
                gridSetings.AggregateSummary = listResult.AggregateSummary;

                retorno.Resultado = gridSetings;
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

        public static RetornoApi PorNegociacaoVerba(GridSetings<RelatoriosVerbasEmitidasViewModel> gridSetings)
        {
            RetornoApi retorno = new RetornoApi();

            retorno.Resultado = gridSetings;
            try
            {

                RetornoApi retornoPost = RestApi.Post(string.Format("/RelatoriosVerbasEmitidas/{0}/{1}/{2}/{3}/PorNegociacaoVerba", gridSetings.Setings.CurrentPage, gridSetings.Setings.PageSize, gridSetings.Setings.Column, gridSetings.Setings.Way), gridSetings.Filtro);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }

                ListResult<RelatoriosVerbasEmitidasViewModel> listResult = JsonConvert.DeserializeObject<ListResult<RelatoriosVerbasEmitidasViewModel>>((string)retornoPost.Resultado);

                gridSetings.Result = listResult.Result;
                gridSetings.Setings.TotalRows = listResult.TotalRows;
                gridSetings.Setings.CurrentPageSize = listResult.Result.Count;
                gridSetings.AggregateSummary = listResult.AggregateSummary;

                retorno.Resultado = gridSetings;
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

        public static RetornoApi PorNegociacaoVerbaEmpenho(GridSetings<RelatoriosVerbasEmitidasViewModel> gridSetings)
        {
            RetornoApi retorno = new RetornoApi();

            retorno.Resultado = gridSetings;
            try
            {

                RetornoApi retornoPost = RestApi.Post(string.Format("/RelatoriosVerbasEmitidas/{0}/{1}/{2}/{3}/PorNegociacaoVerbaEmpenho", gridSetings.Setings.CurrentPage, gridSetings.Setings.PageSize, gridSetings.Setings.Column, gridSetings.Setings.Way), gridSetings.Filtro);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }

                ListResult<RelatoriosVerbasEmitidasViewModel> listResult = JsonConvert.DeserializeObject<ListResult<RelatoriosVerbasEmitidasViewModel>>((string)retornoPost.Resultado);

                gridSetings.Result = listResult.Result;
                gridSetings.Setings.TotalRows = listResult.TotalRows;
                gridSetings.Setings.CurrentPageSize = listResult.Result.Count;
                gridSetings.AggregateSummary = listResult.AggregateSummary;

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