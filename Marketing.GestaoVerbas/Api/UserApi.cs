using Marketing.GestaoVerbas.AuthenticationService;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbas.Api
{
    public class UserApi
    {
        public static RetornoApi ConsultaUsuario(string pLogin)
        {
            RetornoApi retorno = new RetornoApi();
            try
            {
                RetornoApi retornoPost = RestApi.Get(string.Format("/User/{0}/User", pLogin));
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }

                string resultado = (string)retornoPost.Resultado;

                if (string.IsNullOrEmpty(resultado))
                {
                    retorno.SetaAlerta("Não foi possível localizar seus dados no banco de dados. Solicite ao administrador para verificar.");
                }
                else
                {
                    string json = resultado.Replace("\\", "");

                    retorno.Resultado = JsonConvert.DeserializeObject<Usuario>(json);

                    if (retorno.Resultado == null)
                    {
                        retorno.SetaAlerta("Não foi possível localizar seus dados no banco de dados. Solicite ao administrador para verificar.");
                    }
                }
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }



        public static RetornoApi AutenticaDMZ(string usuario, string senha)
        {
            var retorno = new RetornoApi();
            try
            {
                if (string.IsNullOrEmpty(usuario))
                {
                    retorno.SetaAlerta("Informe o usuário.");
                    return retorno;
                }

                if (string.IsNullOrEmpty(senha))
                {
                    retorno.SetaAlerta("Informa a senha.");
                    return retorno;
                }

                WSAutenticacaoTokenDMZ service = new WSAutenticacaoTokenDMZ();
                string result = service.WSAutenticacaoDMZRetornaGrupo(usuario, senha);

                if (string.IsNullOrEmpty(result))
                {
                    retorno.SetaAlerta("Não foi possível consultar dados.");
                    return retorno;
                }

                if (result == "102")
                {
                    retorno.SetaAlerta("Usuário ou Senha inválidos.");
                    return retorno;
                }

                string[] split = result.Split(':');

                if (split.Length < 2)
                {
                    retorno.SetaAlerta("Não foi possível consultar dados.");
                    return retorno;
                }

                if (split[0].Trim() == "0") //Acesso concedido
                {
                    string[] groupSplit = split[1].Split(new[] { "-groups-" }, StringSplitOptions.None);

                    if (groupSplit.Length < 2)
                    {
                        retorno.Resultado = "";
                    }
                    else
                    {
                        retorno.Resultado = groupSplit[1].Trim().ToUpper().Split(';');
                    }

                    return retorno;
                }
                else
                {
                    retorno.SetaAlerta(split[1]);
                    return retorno;
                }
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
                return retorno;
            }
        }

        public static RetornoApi AutenticaAPI(string usuario, string senha)
        {
            var retorno = new RetornoApi();
            try
            {
                if (string.IsNullOrEmpty(usuario))
                {
                    retorno.SetaAlerta("Informe o usuário.");
                    return retorno;
                }

                if (string.IsNullOrEmpty(senha))
                {
                    retorno.SetaAlerta("Informa a senha.");
                    return retorno;
                }

                var ret = AutenticaPOST(usuario, senha);

                JObject retornoJObject = (JObject)ret.Resultado;

                if (retornoJObject == null)
                {
                    retorno.SetaAlerta("Não foi possível consultar dados.");
                    return retorno;
                }

                if (retornoJObject.GetValue("Code").ToString() == "102")
                {
                    retorno.SetaAlerta("Usuário ou Senha inválidos.");
                    return retorno;
                }

                if (retornoJObject.GetValue("Code").ToString() != "104")
                {
                    retorno.SetaAlerta(retornoJObject.GetValue("Message").ToString());
                    return retorno;
                }
                else
                {
                    var teste = retornoJObject.SelectToken(@"UserAD.lstGroupAD").ToList().Select(x => x.SelectToken(@"$.Name").Value<string>().ToUpper()).ToList();
                    //testar pegar value? pra ser string[]
                    retorno.Resultado = teste;
                    return retorno;
                }


            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
                return retorno;
            }
        }

        private static RetornoApi AutenticaPOST(string pSenha, string pUsuario)
        {
            RetornoApi retorno = new RetornoApi();

            try
            {
                var pr = new Dictionary<string, string>();
                pr.Add("user", pSenha);
                pr.Add("password", pUsuario);

                retorno = RestApi.PostAutenticacao(string.Format("/Data/authMartinsAD"), pr);
                if (!retorno.Sucesso)
                {
                    retorno.Resultado = JObject.Parse((string)retorno.Resultado);
                    return retorno;
                }

                retorno.Resultado = JObject.Parse((string)retorno.Resultado);
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

    }
}