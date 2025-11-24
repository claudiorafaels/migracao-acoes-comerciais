using Marketing.GestaoVerbas.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbas.Api
{
    public class CarimboApi
    {
        public static RetornoApi SelectPorNegociacao(int codigoNegociacaoVerba, int CodDestinoObjetivo)
        {
            RetornoApi retorno = new RetornoApi();
            try
            {
                RetornoApi retornoGet = RestApi.Get(string.Format("/carimbo/{0}/{1}/selectPorNegociacao", codigoNegociacaoVerba, CodDestinoObjetivo));
                if (!retornoGet.Sucesso)
                {
                    return retornoGet;
                }
                retorno.Resultado = JsonConvert.DeserializeObject<CarimboViewModel>((string)retornoGet.Resultado);
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

        public static RetornoApi CriarCarimbo(int codigoNegociacaoVerba, int codDestino, int codUsuario)
        {
            RetornoApi retorno = new RetornoApi();
            try
            {
                RetornoApi retornoApi = RestApi.Patch(string.Format("/carimbo/{0}/{1}/{2}/CriarCarimbo", codigoNegociacaoVerba, codDestino, codUsuario));
                if (!retornoApi.Sucesso)
                {
                    return retornoApi;
                }
                retorno.Resultado = JsonConvert.DeserializeObject<CarimboViewModel>((string)retornoApi.Resultado);
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

        public static RetornoApi Update(CarimboViewModel carimbo)
        {
            RetornoApi retorno = new RetornoApi();
            try
            {
                RetornoApi retornoApi = RestApi.Put(string.Format("/carimbo/{0}/update", carimbo.CodCarimbo), carimbo);
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