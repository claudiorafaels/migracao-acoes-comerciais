using Marketing.GestaoVerbas.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbas.Api
{
    public class CarimboItemApi
    {
        public static RetornoApi ConsultaItensFornecedor(int codFornecedor, string codFiliais, int? codComprador, int codCarimbo, string dataRef)
        {

            RetornoApi retorno = new RetornoApi();
            try
            {
                string url = string.Format("/CarimboItem/{0}/{1}/{2}/{3}/{4}/ConsultaItensFornecedor"
                                          , codFornecedor
                                          , (string.IsNullOrEmpty(codFiliais) ? "Todas" : codFiliais)
                                          , (codComprador == null ? "null" : codComprador.ToString())
                                          , codCarimbo
                                          , dataRef);
                RetornoApi retornoGet = RestApi.Get(url);
                if (!retornoGet.Sucesso)
                {
                    return retornoGet;
                }
                retorno.Resultado = JsonConvert.DeserializeObject<List<CarimboItemViewModel>>((string)retornoGet.Resultado);
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

        public static RetornoApi ListPorCarimbo(int codCarimbo)
        {
            RetornoApi retorno = new RetornoApi();
            try
            {
                RetornoApi retornoGet = RestApi.Get(string.Format("/CarimboItem/{0}/ListPorCarimbo", codCarimbo));
                if (!retornoGet.Sucesso)
                {
                    return retornoGet;
                }
                retorno.Resultado = JsonConvert.DeserializeObject<List<CarimboItemViewModel>>((string)retornoGet.Resultado);
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

        class CarimboUpdate
        {
            public decimal? VlrVerba { get; set; }
            public List<CarimboitemUpdate> Itens { get; set; }
        }

            class CarimboitemUpdate
        {
            public int? CodCarimbo { get; set; }
            public int? CodFilialEmpresa { get; set; }
            public int? CodMercadoria { get; set; }
            public decimal? VlrPrevistoCarimbo { get; set; }
            public decimal? VlrImpostos { get; set; }
            public int? CodDestinoObjetivo { get; set; }

        }

        public static RetornoApi UpdateList(int CodCarimbo, decimal? vlrVerba, List<CarimboItemViewModel> carimboItensList)
        {
            RetornoApi retorno = new RetornoApi();
            try
            {
                CarimboUpdate carimboUpdate = new CarimboUpdate();
                carimboUpdate.VlrVerba = vlrVerba;
                carimboUpdate.Itens = new List<CarimboitemUpdate>();
                foreach (var item in carimboItensList)
                {
                    carimboUpdate.Itens.Add(new CarimboitemUpdate()
                    {
                        CodCarimbo = item.CodCarimbo,
                        CodFilialEmpresa = item.CodFilialEmpresa,
                        CodMercadoria = item.CodMercadoria,
                        VlrPrevistoCarimbo = item.VlrPrevistoCarimbo,
                        VlrImpostos = item.VlrImpostos,
                        CodDestinoObjetivo = item.CodDestinoObjetivo,
                    });
                }

                RetornoApi retornoApi = RestApi.Patch(string.Format("/CarimboItem/{0}/updatelist", CodCarimbo), carimboUpdate);
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
    }
}