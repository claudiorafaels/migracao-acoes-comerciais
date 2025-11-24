using Marketing.GestaoVerbas.Core.Grid;
using Marketing.GestaoVerbas.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbas.Api
{
    public class NegociacaoVerbaHistoricoApi
    {
        public static RetornoApi Historico(int pCodNegociacaoVerba)
        {
            RetornoApi retorno = new RetornoApi();

            try
            {
                RetornoApi retornoPost = RestApi.Get(string.Format("/negociacaoverbahistorico/{0}/listpornegociacao", pCodNegociacaoVerba));
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }
                retorno.Resultado = JsonConvert.DeserializeObject<List<NegociacaoVerbaHistoricoViewModel>>((string)retornoPost.Resultado);
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

    }
}