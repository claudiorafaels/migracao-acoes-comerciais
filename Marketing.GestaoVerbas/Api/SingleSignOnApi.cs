using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Newtonsoft.Json;

namespace Marketing.GestaoVerbas.Api
{
    public class SingleSignOnApi
    {
        public static RetornoApi GetSessionTimeout(string IdNetwork, string TokenAcessoUsuario)
        {
            var retorno = new RetornoApi();
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                string codSistema = RestApi.AppSettings("CodSistema");
                var pr = new Dictionary<string, string>();
                pr.Add("IdNetwork", IdNetwork);
                pr.Add("Token", TokenAcessoUsuario);
                pr.Add("IdSystem", codSistema);

                retorno = RestApi.PostValidSession("/User/IsValidSession", pr);
                if (!retorno.Sucesso)
                {
                    return retorno;
                }

                string json = (string)retorno.Resultado;

                retorno.Resultado = JsonConvert.DeserializeObject<bool>(json);

                if (retorno.Resultado == null)
                {
                    retorno.SetaAlerta("Dados  do usuário não encontrados.");
                }
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

    }
}