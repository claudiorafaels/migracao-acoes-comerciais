using Marketing.GestaoVerbas.ViewModel.RelatoriosCarimbosContabilizados;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbas.Api
{
    public class AnoMesReferenciaApi
    {
        public static RetornoApi ListAnoMesReferencia()
        {
            RetornoApi retorno = new RetornoApi();
            try
            {
                RetornoApi retornoGet = RestApi.Get("/AnoMesReferencia/listObjetivoPorDestino");
                if (!retornoGet.Sucesso)
                {
                    return retornoGet;
                }
                retorno.Resultado = JsonConvert.DeserializeObject<List<AnoMesReferencia>>((string)retornoGet.Resultado);
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }
    }
}