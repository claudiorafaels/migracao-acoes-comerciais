using Marketing.GestaoVerbas.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbas.Api
{
    public class AcordoApi
    {
        public static RetornoApi ListPorNegociacao(decimal pCodNegociacaoVerba)
        {
            RetornoApi retorno = new RetornoApi();

            try
            {
                RetornoApi retornoGet = RestApi.Get(string.Format("/negociacaoverba/{0}/listpornegociacao", pCodNegociacaoVerba));
                if (!retornoGet.Sucesso)
                {
                    return retornoGet;
                }
                retorno.Resultado = JsonConvert.DeserializeObject<List<AcordoViewModel>>((string)retornoGet.Resultado);
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

        public static RetornoApi SelectAcordoPdf(decimal pCodPromessa)
        {
            RetornoApi retorno = new RetornoApi();

            try
            {
                RetornoApi retornoGet = RestApi.Get(string.Format("/negociacaoverba/{0}/selectacordopdf", pCodPromessa));
                if (!retornoGet.Sucesso)
                {
                    return retornoGet;
                }
                retorno.Resultado = JsonConvert.DeserializeObject<List<AcordoViewModel>>((string)retornoGet.Resultado);
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }
    }
}
