using Marketing.GestaoVerbas.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbas.Api
{
    public class DestinoObjetivoApi
    {
        public static RetornoApi ListObjetivoPorDestino(int codDestino)
        {
            RetornoApi retorno = new RetornoApi();
            try
            {
                RetornoApi retornoGet = RestApi.Get(string.Format("/DestinoObjetivo/{0}/listObjetivoPorDestino", codDestino));
                if (!retornoGet.Sucesso)
                {
                    return retornoGet;
                }
                retorno.Resultado = JsonConvert.DeserializeObject<List<DestinoObjetivoViewModel>>((string)retornoGet.Resultado);
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

        public static RetornoApi ListObjetivos()
        {
            RetornoApi retorno = new RetornoApi();
            try
            {
                RetornoApi retornoGet = RestApi.Get("/DestinoObjetivo/listObjetivos");
                if (!retornoGet.Sucesso)
                {
                    return retornoGet;
                }
                retorno.Resultado = JsonConvert.DeserializeObject<List<DestinoObjetivoViewModel>>((string)retornoGet.Resultado);
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }
    }
}