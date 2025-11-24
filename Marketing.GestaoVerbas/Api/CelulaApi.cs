using Marketing.GestaoVerbas.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbas.Api
{
    public class CelulaApi
    {
        public static RetornoApi ListLookup()
        {
            RetornoApi retorno = new RetornoApi();

            try
            {
                RetornoApi retornoPost = RestApi.Get(string.Format("/celula/ListLookup"));
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }
                List<CelulaViewModel> listResult = JsonConvert.DeserializeObject<List<CelulaViewModel>>((string)retornoPost.Resultado);

                retorno.Resultado = listResult;
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }
    }
}