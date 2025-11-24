using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Net;
using System.Web;

public class RestApi
{
    private static void SetaAlertaApi(IRestResponse response, RetornoApi retorno, string url)
    {
        string msg = url;

        if (!string.IsNullOrEmpty(response.Content))
        {
            msg += " " + response.Content;
        }

        if (!string.IsNullOrEmpty(response.ErrorMessage))
        {
            msg += " " + response.ErrorMessage;
        }

        retorno.SetaAlerta(msg);
    }

    private static RetornoApi GetToken()
    {
        //RetornoApi retorno = new RetornoApi();
        //retorno.Resultado = "123123";
        //return retorno;
        RetornoApi retorno = new RetornoApi();
        string url = "";
        try
        {
            DateTime? dtExpiracaoToken = null;
            var cookieValor = CookieManager.GetCookie(CookieEnum.DT_EXPIRA_TOKEN);

            if (!string.IsNullOrWhiteSpace(cookieValor))
            {
                double seconds;
                if (double.TryParse(cookieValor, NumberStyles.Float, CultureInfo.InvariantCulture, out seconds))
                {
                    dtExpiracaoToken = DateTime.Now.AddSeconds(seconds);
                }
            }

            if (dtExpiracaoToken == null || dtExpiracaoToken.Value <= DateTime.Now)
            {
                string urlApi = Marketing.GestaoVerbas.Core.Config.UrlApiToken();
                string authUser = Marketing.GestaoVerbas.Core.Config.AuthUser();
                string authPassword = Marketing.GestaoVerbas.Core.Config.AuthPassword();

                url = urlApi;
                RestClient client = new RestClient(url);
                client.Authenticator = new HttpBasicAuthenticator(authUser, authPassword);

                RestRequest request = new RestRequest();
                request.Method = Method.POST;
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("grant_type", "client_credentials");

                var response = client.Execute<Token>(request);

                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
                {
                    var novaExpiracao = DateTime.Now.AddSeconds(Double.Parse(response.Data.ExpiresIn));

                    HttpContext.Current.Session["DT_EXPIRA_TOKEN"] = novaExpiracao;
                    CookieManager.SetCookie(CookieEnum.DT_EXPIRA_TOKEN, response.Data.ExpiresIn);



                    HttpContext.Current.Session["TOKEN"] = response.Data.AccessToken;
                    CookieManager.SetCookie(CookieEnum.TOKEN, response.Data.AccessToken);

                }
                else
                {
                    SetaAlertaApi(response, retorno, url);
                    return retorno;
                }
            }

            HttpContext.Current.Session["TOKEN"] = CookieManager.GetCookie(CookieEnum.TOKEN);
            retorno.Resultado = (string)HttpContext.Current.Session["TOKEN"];
        }
        catch (Exception ex)
        {
            retorno.SetaExcecao(ex, url);
        }

        return retorno;
    }
    private static RetornoApi GetTokenAutenticacao()
    {
        RetornoApi retorno = new RetornoApi();
        string url = "";
        try
        {
            DateTime? dtExpiracaoToken = (DateTime?)HttpContext.Current.Session["DT_EXPIRA_TOKEN_AUTENTICACAO"];

            if (dtExpiracaoToken == null || dtExpiracaoToken.Value <= DateTime.Now)
            {
                string urlApi = ConfigurationManager.AppSettings["UrlApiTokenAutenticacao"] ;
                string authUser = ConfigurationManager.AppSettings["authUserAutenticacao"];
                string authPassword = ConfigurationManager.AppSettings["authPasswordAutenticacao"];

                url = urlApi;
                RestClient client = new RestClient(url);
                client.Authenticator = new HttpBasicAuthenticator(authUser, authPassword);

                RestRequest request = new RestRequest();
                request.Method = Method.POST;
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("grant_type", "client_credentials");

                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;//Https
                var response = client.Execute<Token>(request);

                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
                {
                    HttpContext.Current.Session["DT_EXPIRA_TOKEN_AUTENTICACAO"] =
                        DateTime.Now.AddSeconds(Double.Parse(response.Data.ExpiresIn));
                    HttpContext.Current.Session["TOKEN_AUTENTICACAO"] = response.Data.AccessToken;
                }
                else
                {
                    SetaAlertaApi(response, retorno, url);
                    return retorno;
                }
            }

            retorno.Resultado = (string)HttpContext.Current.Session["TOKEN_AUTENTICACAO"];
        }
        catch (Exception ex)
        {
            retorno.SetaExcecao(ex, url);
        }

        return retorno;
    }


    public static string AppSettings(string key)
    {
        string value = ConfigurationManager.AppSettings[key];
        if (value == null || value.ToString().Trim() == "")
        {
            throw new Exception("Favor definir o valor no config para '" + key + "'");
        }

        return value.Trim();
    }

    public static RetornoApi PostAutenticacao(string rotaMetodo, Dictionary<string, string> param)
    {
        RetornoApi retorno = new RetornoApi();
        string url = "";
        try
        {
            RetornoApi retornoToken = GetTokenAutenticacao();
            if (!retornoToken.Sucesso)
            {
                return retornoToken;
            }

            url = ConfigurationManager.AppSettings["urlApiAutenticacao"] + rotaMetodo;
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            //request.AddHeader("Authorization", "Bearer " + (string)retornoToken.Resultado);
            request.AddHeader("client_id", ConfigurationManager.AppSettings["authUserAutenticacao"]);
            request.AddHeader("access_token", (string)retornoToken.Resultado);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", SimpleJson.SerializeObject(param), ParameterType.RequestBody);

            IRestResponse response = null;

            response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                retorno.Resultado = response.Content;
                return retorno;
            }
            else
            {
                SetaAlertaApi(response, retorno, url);
                return retorno;
            }
        }
        catch (Exception ex)
        {
            retorno.SetaExcecao(ex, url);
            return retorno;
        }
    }

    public static RetornoApi Post(string rotaMetodo, Dictionary<string, string> param)
    {
        RetornoApi retorno = new RetornoApi();
        string url = "";
        try
        {
            RetornoApi retornoToken = GetToken();
            if (!retornoToken.Sucesso)
            {
                return retornoToken;
            }

            url = Marketing.GestaoVerbas.Core.Config.UrlApi() + rotaMetodo;
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            //request.AddHeader("Authorization", "Bearer " + (string)retornoToken.Resultado);
            request.AddHeader("client_id", Marketing.GestaoVerbas.Core.Config.AuthUser());
            request.AddHeader("access_token", (string)retornoToken.Resultado);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", SimpleJson.SerializeObject(param), ParameterType.RequestBody);

            IRestResponse response = null;

            response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                retorno.Resultado = response.Content;
                return retorno;
            }
            else
            {
                SetaAlertaApi(response, retorno, url);
                return retorno;
            }
        }
        catch (Exception ex)
        {
            retorno.SetaExcecao(ex, url);
            return retorno;
        }
    }

    public static RetornoApi Post(string rotaMetodo, object param = null)
    {
        RetornoApi retorno = new RetornoApi();
        string url = "";
        try
        {
            RetornoApi retornoToken = GetToken();
            if (!retornoToken.Sucesso)
            {
                return retornoToken;
            }

            url = Marketing.GestaoVerbas.Core.Config.UrlApi() + rotaMetodo;
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            //request.AddHeader("Authorization", "Bearer " + (string)retornoToken.Resultado);
            request.AddHeader("client_id", Marketing.GestaoVerbas.Core.Config.AuthUser());
            request.AddHeader("access_token", (string)retornoToken.Resultado);
            request.AddHeader("Content-Type", "application/json");
            if (param != null)
                request.AddParameter("application/json", SimpleJson.SerializeObject(param), ParameterType.RequestBody);

            IRestResponse response = null;
            response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                retorno.Resultado = response.Content;
                return retorno;
            }
            else
            {
                SetaAlertaApi(response, retorno, url);
                return retorno;
            }
        }
        catch (Exception ex)
        {
            retorno.SetaExcecao(ex, url);
            return retorno;
        }
    }


    public static RetornoApi Get(string rotaMetodo)
    {
        RetornoApi retorno = new RetornoApi();
        string url = "";
        try
        {
            RetornoApi retornoToken = GetToken();
            if (!retornoToken.Sucesso)
            {
                return retornoToken;
            }

            url = Marketing.GestaoVerbas.Core.Config.UrlApi() + rotaMetodo;
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("client_id", Marketing.GestaoVerbas.Core.Config.AuthUser());
            request.AddHeader("access_token", (string)retornoToken.Resultado);
            //request.AddHeader("Authorization", "Bearer " + (string)retornoToken.Resultado);
            request.AddHeader("content-type", "application/json");

            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                retorno.Resultado = response.Content;
                return retorno;
            }
            else
            {
                SetaAlertaApi(response, retorno, url);
                return retorno;
            }
        }
        catch (Exception ex)
        {
            retorno.SetaExcecao(ex, url);
            return retorno;
        }
    }


    public static RetornoApi Put(string rotaMetodo, Dictionary<string, string> param)
    {
        RetornoApi retorno = new RetornoApi();
        string url = "";
        try
        {
            RetornoApi retornoToken = GetToken();
            if (!retornoToken.Sucesso)
            {
                return retornoToken;
            }

            url = Marketing.GestaoVerbas.Core.Config.UrlApi() + rotaMetodo;
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.PUT);
            request.AddHeader("cache-control", "no-cache");
            //request.AddHeader("Authorization", "Bearer " + (string)retornoToken.Resultado);
            request.AddHeader("client_id", Marketing.GestaoVerbas.Core.Config.AuthUser());
            request.AddHeader("access_token", (string)retornoToken.Resultado);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", SimpleJson.SerializeObject(param), ParameterType.RequestBody);

            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                retorno.Resultado = response.Content;
                return retorno;
            }
            else
            {
                SetaAlertaApi(response, retorno, url);
                return retorno;
            }
        }
        catch (Exception ex)
        {
            retorno.SetaExcecao(ex, url);
            return retorno;
        }
    }

    public static RetornoApi Put(string rotaMetodo, object param = null)
    {
        RetornoApi retorno = new RetornoApi();
        string url = "";
        try
        {
            RetornoApi retornoToken = GetToken();
            if (!retornoToken.Sucesso)
            {
                return retornoToken;
            }

            url = Marketing.GestaoVerbas.Core.Config.UrlApi() + rotaMetodo;
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.PUT);
            request.AddHeader("cache-control", "no-cache");
            //request.AddHeader("Authorization", "Bearer " + (string)retornoToken.Resultado);
            request.AddHeader("client_id", Marketing.GestaoVerbas.Core.Config.AuthUser());
            request.AddHeader("access_token", (string)retornoToken.Resultado);
            request.AddHeader("Content-Type", "application/json");
            if (param != null)
                request.AddParameter("application/json", SimpleJson.SerializeObject(param), ParameterType.RequestBody);

            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                retorno.Resultado = response.Content;
                return retorno;
            }
            else
            {
                SetaAlertaApi(response, retorno, url);
                return retorno;
            }
        }
        catch (Exception ex)
        {
            retorno.SetaExcecao(ex, url);
            return retorno;
        }
    }


    public static RetornoApi Patch(string rotaMetodo, object param = null)
    {
        RetornoApi retorno = new RetornoApi();
        string url = "";
        try
        {
            RetornoApi retornoToken = GetToken();
            if (!retornoToken.Sucesso)
            {
                return retornoToken;
            }

            url = Marketing.GestaoVerbas.Core.Config.UrlApi() + rotaMetodo;
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.PATCH);
            request.AddHeader("cache-control", "no-cache");
            //request.AddHeader("Authorization", "Bearer " + (string)retornoToken.Resultado);
            request.AddHeader("client_id", Marketing.GestaoVerbas.Core.Config.AuthUser());
            request.AddHeader("access_token", (string)retornoToken.Resultado);
            request.AddHeader("Content-Type", "application/json");
            if (param != null)
                request.AddParameter("application/json", SimpleJson.SerializeObject(param), ParameterType.RequestBody);

            IRestResponse response = null;

            response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                retorno.Resultado = response.Content;
                return retorno;
            }
            else
            {
                SetaAlertaApi(response, retorno, url);
                return retorno;
            }
        }
        catch (Exception ex)
        {
            retorno.SetaExcecao(ex, url);
            return retorno;
        }
    }

    public static RetornoApi Delete(string rotaMetodo)
    {
        RetornoApi retorno = new RetornoApi();
        string url = "";
        try
        {
            RetornoApi retornoToken = GetToken();
            if (!retornoToken.Sucesso)
            {
                return retornoToken;
            }

            url = Marketing.GestaoVerbas.Core.Config.UrlApi() + rotaMetodo;
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.DELETE);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("client_id", Marketing.GestaoVerbas.Core.Config.AuthUser());
            request.AddHeader("access_token", (string)retornoToken.Resultado);
            //request.AddHeader("Authorization", "Bearer " + (string)retornoToken.Resultado);
            request.AddHeader("content-type", "application/json");

            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                retorno.Resultado = response.Content;
                return retorno;
            }
            else
            {
                SetaAlertaApi(response, retorno, url);
                return retorno;
            }
        }
        catch (Exception ex)
        {
            retorno.SetaExcecao(ex, url);
            return retorno;
        }
    }

    public static RetornoApi PostValidSession(string rotaMetodo, Dictionary<string, string> param)
    {
        RetornoApi retorno = new RetornoApi();
        string url = "";
        try
        {
            RetornoApi retornoToken = GetTokenAutenticacao();
            if (!retornoToken.Sucesso)
            {
                return retornoToken;
            }

            url = AppSettings("urlAprovaSIMApi") + rotaMetodo;
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("client_id", (string)AppSettings("authUserAprovaSim"));
            request.AddHeader("access_token", (string)retornoToken.Resultado);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", SimpleJson.SerializeObject(param), ParameterType.RequestBody);

            IRestResponse response = null;
            Int16 tentativas = 0;

            do
            {
                tentativas += 1;
                response = client.Execute(request);

            } while ((response.StatusCode == HttpStatusCode.InternalServerError || response.Content == "\"Favor informar os parâmetros corretamente.\"") && tentativas <= 13);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                retorno.Resultado = response.Content;
                return retorno;
            }
            else
            {
                SetaAlertaApi(response, retorno, url);
                return retorno;
            }
        }
        catch (Exception ex)
        {
            retorno.SetaExcecao(ex, url);
            return retorno;
        }
    }
}