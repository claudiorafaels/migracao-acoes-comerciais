using Marketing.GestaoVerbas.Core.Grid;
using Marketing.GestaoVerbas.ViewModel;
using Marketing.GestaoVerbas.ViewModel.RelatoriosVerbasCarimbadas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbas.Api
{
    public class RelatoriosVerbasCarimbadasApi
    {
        #region "Analitico"
        public static RetornoApi VerbaCarimbadaRealizadoAnalitico(GridSetings<FiltrosRelatoriosVerbasCarimbadas> gridSetings)
        {
            RetornoApi retorno = new RetornoApi();

            retorno.Resultado = gridSetings;
            try
            {

                RetornoApi retornoPost = RestApi.Post(string.Format("/RelatoriosVerbasCarimbadas/{0}/{1}/{2}/{3}/VerbaCarimbadaRealizadoAnalitico", gridSetings.Setings.CurrentPage, gridSetings.Setings.PageSize, gridSetings.Setings.Column, gridSetings.Setings.Way), gridSetings.Filtro);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }

                ListResult<VerbasCarimbadasRealizadoAnalitico> listResult = JsonConvert.DeserializeObject<ListResult<VerbasCarimbadasRealizadoAnalitico>>((string)retornoPost.Resultado);
                GridSetings<VerbasCarimbadasRealizadoAnalitico> gridSetingsResult = new GridSetings<VerbasCarimbadasRealizadoAnalitico>();
                gridSetingsResult.Setings = gridSetings.Setings;
                gridSetingsResult.Result = listResult.Result;
                gridSetingsResult.Setings.TotalRows = listResult.TotalRows;
                gridSetingsResult.Setings.CurrentPageSize = listResult.Result.Count;
                gridSetingsResult.AggregateSummary = listResult.AggregateSummary;
                retorno.Resultado = gridSetingsResult;
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

        public static RetornoApi VerbaCarimbadaCanceladoAnalitico(GridSetings<FiltrosRelatoriosVerbasCarimbadas> gridSetings)
        {
            RetornoApi retorno = new RetornoApi();

            retorno.Resultado = gridSetings;
            try
            {
                RetornoApi retornoPost = RestApi.Post(string.Format("/RelatoriosVerbasCarimbadas/{0}/{1}/{2}/{3}/VerbaCarimbadaCanceladoAnalitico", gridSetings.Setings.CurrentPage, gridSetings.Setings.PageSize, gridSetings.Setings.Column, gridSetings.Setings.Way), gridSetings.Filtro);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }

                ListResult<VerbasCarimbadasCanceladoAnalitico> listResult = JsonConvert.DeserializeObject<ListResult<VerbasCarimbadasCanceladoAnalitico>>((string)retornoPost.Resultado);
                GridSetings<VerbasCarimbadasCanceladoAnalitico> gridSetingsResult = new GridSetings<VerbasCarimbadasCanceladoAnalitico>();
                gridSetingsResult.Setings = gridSetings.Setings;
                gridSetingsResult.Result = listResult.Result;
                gridSetingsResult.Setings.TotalRows = listResult.TotalRows;
                gridSetingsResult.Setings.CurrentPageSize = listResult.Result.Count;
                gridSetingsResult.AggregateSummary = listResult.AggregateSummary;
                retorno.Resultado = gridSetingsResult;
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

        #endregion

        #region "Sintetico"
        public static RetornoApi VerbaCarimbadaRealizadoSintetico(GridSetings<FiltrosRelatoriosVerbasCarimbadas> gridSetings)
        {
            RetornoApi retorno = new RetornoApi();

            retorno.Resultado = gridSetings;
            try
            {

                RetornoApi retornoPost = RestApi.Post(string.Format("/RelatoriosVerbasCarimbadas/{0}/{1}/{2}/{3}/VerbaCarimbadaRealizadoSintetico", gridSetings.Setings.CurrentPage, gridSetings.Setings.PageSize, gridSetings.Setings.Column, gridSetings.Setings.Way), gridSetings.Filtro);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }

                ListResult<VerbasCarimbadasRealizadoSintetico> listResult = JsonConvert.DeserializeObject<ListResult<VerbasCarimbadasRealizadoSintetico>>((string)retornoPost.Resultado);
                GridSetings<VerbasCarimbadasRealizadoSintetico> gridSetingsResult = new GridSetings<VerbasCarimbadasRealizadoSintetico>();
                gridSetingsResult.Setings = gridSetings.Setings;
                gridSetingsResult.Result = listResult.Result;
                gridSetingsResult.Setings.TotalRows = listResult.TotalRows;
                gridSetingsResult.Setings.CurrentPageSize = listResult.Result.Count;
                gridSetingsResult.AggregateSummary = listResult.AggregateSummary;
                retorno.Resultado = gridSetingsResult;
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

        public static RetornoApi VerbaCarimbadaCanceladoSintetico(GridSetings<FiltrosRelatoriosVerbasCarimbadas> gridSetings)
        {
            RetornoApi retorno = new RetornoApi();

            retorno.Resultado = gridSetings;
            try
            {

                RetornoApi retornoPost = RestApi.Post(string.Format("/RelatoriosVerbasCarimbadas/{0}/{1}/{2}/{3}/VerbaCarimbadaCanceladoSintetico", gridSetings.Setings.CurrentPage, gridSetings.Setings.PageSize, gridSetings.Setings.Column, gridSetings.Setings.Way), gridSetings.Filtro);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }

                ListResult<VerbasCarimbadasCanceladoSintetico> listResult = JsonConvert.DeserializeObject<ListResult<VerbasCarimbadasCanceladoSintetico>>((string)retornoPost.Resultado);
                GridSetings<VerbasCarimbadasCanceladoSintetico> gridSetingsResult = new GridSetings<VerbasCarimbadasCanceladoSintetico>();
                gridSetingsResult.Setings = gridSetings.Setings;
                gridSetingsResult.Result = listResult.Result;
                gridSetingsResult.Setings.TotalRows = listResult.TotalRows;
                gridSetingsResult.Setings.CurrentPageSize = listResult.Result.Count;
                gridSetingsResult.AggregateSummary = listResult.AggregateSummary;
                retorno.Resultado = gridSetingsResult;
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }
        #endregion
    }
}

