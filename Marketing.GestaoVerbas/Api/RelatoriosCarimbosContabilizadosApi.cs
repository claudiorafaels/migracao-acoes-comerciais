using Marketing.GestaoVerbas.Core.Grid;
using Marketing.GestaoVerbas.ViewModel;
using Marketing.GestaoVerbas.ViewModel.RelatoriosCarimbosContabilizados;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbas.Api
{
    public class RelatoriosCarimbosContabilizadosApi
    {
        #region "Analitico"
        public static RetornoApi AReceberAnalitico(GridSetings<FiltrosRelatoriosCarimbosContabilizados> gridSetings)
        {
            RetornoApi retorno = new RetornoApi();

            retorno.Resultado = gridSetings;
            try
            {

                RetornoApi retornoPost = RestApi.Post(string.Format("/RelatoriosCarimbosContabilizados/{0}/{1}/{2}/{3}/AReceberAnalitico", gridSetings.Setings.CurrentPage, gridSetings.Setings.PageSize, gridSetings.Setings.Column, gridSetings.Setings.Way), gridSetings.Filtro);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }

                ListResult<ValoresReceberAnalitico> listResult = JsonConvert.DeserializeObject<ListResult<ValoresReceberAnalitico>>((string)retornoPost.Resultado);
                GridSetings<ValoresReceberAnalitico> gridSetingsResult = new GridSetings<ValoresReceberAnalitico>();
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

        public static RetornoApi RecebidosAnalitico(GridSetings<FiltrosRelatoriosCarimbosContabilizados> gridSetings)
        {
            RetornoApi retorno = new RetornoApi();

            retorno.Resultado = gridSetings;
            try
            {

                RetornoApi retornoPost = RestApi.Post(string.Format("/RelatoriosCarimbosContabilizados/{0}/{1}/{2}/{3}/RecebidosAnalitico", gridSetings.Setings.CurrentPage, gridSetings.Setings.PageSize, gridSetings.Setings.Column, gridSetings.Setings.Way), gridSetings.Filtro);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }

                ListResult<ValoresRecebidosAnalitico> listResult = JsonConvert.DeserializeObject<ListResult<ValoresRecebidosAnalitico>>((string)retornoPost.Resultado);
                GridSetings<ValoresRecebidosAnalitico> gridSetingsResult = new GridSetings<ValoresRecebidosAnalitico>();
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

        public static RetornoApi NovosAcordosAnalitico(GridSetings<FiltrosRelatoriosCarimbosContabilizados> gridSetings)
        {
            RetornoApi retorno = new RetornoApi();

            retorno.Resultado = gridSetings;
            try
            {
                RetornoApi retornoPost = RestApi.Post(string.Format("/RelatoriosCarimbosContabilizados/{0}/{1}/{2}/{3}/NovosAcordosAnalitico", gridSetings.Setings.CurrentPage, gridSetings.Setings.PageSize, gridSetings.Setings.Column, gridSetings.Setings.Way), gridSetings.Filtro);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }

                ListResult<NovosAcordosAnalitico> listResult = JsonConvert.DeserializeObject<ListResult<NovosAcordosAnalitico>>((string)retornoPost.Resultado);
                GridSetings<NovosAcordosAnalitico> gridSetingsResult = new GridSetings<NovosAcordosAnalitico>();
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

        public static RetornoApi AcordosCanceladosAnalitico(GridSetings<FiltrosRelatoriosCarimbosContabilizados> gridSetings)
        {
            RetornoApi retorno = new RetornoApi();

            retorno.Resultado = gridSetings;
            try
            {

                RetornoApi retornoPost = RestApi.Post(string.Format("/RelatoriosCarimbosContabilizados/{0}/{1}/{2}/{3}/AcordosCanceladosAnalitico", gridSetings.Setings.CurrentPage, gridSetings.Setings.PageSize, gridSetings.Setings.Column, gridSetings.Setings.Way), gridSetings.Filtro);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }

                ListResult<AcordosCanceladosAnalitico> listResult = JsonConvert.DeserializeObject<ListResult<AcordosCanceladosAnalitico>>((string)retornoPost.Resultado);
                GridSetings<AcordosCanceladosAnalitico> gridSetingsResult = new GridSetings<AcordosCanceladosAnalitico>();
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
        public static RetornoApi AReceberSintetico(GridSetings<FiltrosRelatoriosCarimbosContabilizados> gridSetings)
        {
            RetornoApi retorno = new RetornoApi();

            retorno.Resultado = gridSetings;
            try
            {

                RetornoApi retornoPost = RestApi.Post(string.Format("/RelatoriosCarimbosContabilizados/{0}/{1}/{2}/{3}/AReceberSintetico", gridSetings.Setings.CurrentPage, gridSetings.Setings.PageSize, gridSetings.Setings.Column, gridSetings.Setings.Way), gridSetings.Filtro);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }

                ListResult<ValoresReceberSintetico> listResult = JsonConvert.DeserializeObject<ListResult<ValoresReceberSintetico>>((string)retornoPost.Resultado);
                GridSetings<ValoresReceberSintetico> gridSetingsResult = new GridSetings<ValoresReceberSintetico>();
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

        public static RetornoApi RecebidosSintetico(GridSetings<FiltrosRelatoriosCarimbosContabilizados> gridSetings)
        {
            RetornoApi retorno = new RetornoApi();

            retorno.Resultado = gridSetings;
            try
            {

                RetornoApi retornoPost = RestApi.Post(string.Format("/RelatoriosCarimbosContabilizados/{0}/{1}/{2}/{3}/RecebidosSintetico", gridSetings.Setings.CurrentPage, gridSetings.Setings.PageSize, gridSetings.Setings.Column, gridSetings.Setings.Way), gridSetings.Filtro);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }

                ListResult<ValoresRecebidosSintetico> listResult = JsonConvert.DeserializeObject<ListResult<ValoresRecebidosSintetico>>((string)retornoPost.Resultado);
                GridSetings<ValoresRecebidosSintetico> gridSetingsResult = new GridSetings<ValoresRecebidosSintetico>();
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

        public static RetornoApi NovosAcordosSintetico(GridSetings<FiltrosRelatoriosCarimbosContabilizados> gridSetings)
        {
            RetornoApi retorno = new RetornoApi();

            retorno.Resultado = gridSetings;
            try
            {

                RetornoApi retornoPost = RestApi.Post(string.Format("/RelatoriosCarimbosContabilizados/{0}/{1}/{2}/{3}/NovosAcordosSintetico", gridSetings.Setings.CurrentPage, gridSetings.Setings.PageSize, gridSetings.Setings.Column, gridSetings.Setings.Way), gridSetings.Filtro);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }

                ListResult<NovosAcordosSintetico> listResult = JsonConvert.DeserializeObject<ListResult<NovosAcordosSintetico>>((string)retornoPost.Resultado);
                GridSetings<NovosAcordosSintetico> gridSetingsResult = new GridSetings<NovosAcordosSintetico>();
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

        public static RetornoApi AcordosCanceladosSintetico(GridSetings<FiltrosRelatoriosCarimbosContabilizados> gridSetings)
        {
            RetornoApi retorno = new RetornoApi();

            retorno.Resultado = gridSetings;
            try
            {

                RetornoApi retornoPost = RestApi.Post(string.Format("/RelatoriosCarimbosContabilizados/{0}/{1}/{2}/{3}/AcordosCanceladosSintetico", gridSetings.Setings.CurrentPage, gridSetings.Setings.PageSize, gridSetings.Setings.Column, gridSetings.Setings.Way), gridSetings.Filtro);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }

                ListResult<AcordosCanceladosSintetico> listResult = JsonConvert.DeserializeObject<ListResult<AcordosCanceladosSintetico>>((string)retornoPost.Resultado);
                GridSetings<AcordosCanceladosSintetico> gridSetingsResult = new GridSetings<AcordosCanceladosSintetico>();
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