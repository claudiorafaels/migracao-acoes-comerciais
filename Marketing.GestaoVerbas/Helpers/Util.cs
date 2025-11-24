using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Marketing.GestaoVerbas.Api;
using Marketing.GestaoVerbas.ViewModel;

public class Util
{
    public static bool ValidaSessao()
    {
        var codUserCookie = CookieManager.GetCookieObj(CookieEnum.USUARIO);
        var menuAcessoCookie = CookieManager.GetCookieMenu(CookieEnum.MENUACESSO);

        // Se não tem cookie de usuário, sessão inválida
        if (codUserCookie == null) return false;

        HttpContext.Current.Session["NOMEUSUARIO"] = codUserCookie.IdRede;
        HttpContext.Current.Session["NOMECOMPLETO"] = codUserCookie.Nome;
        HttpContext.Current.Session["MATRICULA"] = codUserCookie.Matricula;
        HttpContext.Current.Session["USUARIO"] = codUserCookie;
        HttpContext.Current.Session["INICIALNOME"] = codUserCookie.Nome.Remove(1);
        HttpContext.Current.Session["MENUACESSO"] = menuAcessoCookie;


        return true;
        
    }

    //public static bool VerificaGrupoUsuario(string[] grupos)
    //{
    //    bool permitido = false;
    //    foreach (var item in grupos)
    //    {
    //        permitido = VerificaGrupoUsuario(item);
    //        if (permitido)
    //            return permitido;
    //    }
    //    return permitido;
    //}

    //public static bool VerificaGrupoUsuario(string grupo)
    //{
    //    Usuario usuario = HttpContext.Current.Session["USUARIO"] as Usuario;

    //    if (usuario == null)
    //        return false;

    //    List<string> grupos = HttpContext.Current.Session["GRUPOSUSUARIO"] as List<string>;

    //    if (grupos == null)
    //        return false;

    //    return grupos.Where(p => p == grupo).FirstOrDefault() != null;

    //}

    public static bool VerificaMenuUsuario(string pCodMenu)
    {

        var codUserCookie = CookieManager.GetCookieObj(CookieEnum.USUARIO);
        var menuAcessoCookie = CookieManager.GetCookieMenu(CookieEnum.MENUACESSO);

        if (codUserCookie == null)
        {
            return false;
        }
        var usuario = CookieManager.GetCookieObj(CookieEnum.USUARIO);

        if (usuario == null)
            return false;

        
        List<Marketing.GestaoVerbas.ViewModel.MenuViewModel> menus = menuAcessoCookie as List<Marketing.GestaoVerbas.ViewModel.MenuViewModel>;

        if (menus == null)
            return false;

        return menus.Where(p => p.CodMenu == pCodMenu).FirstOrDefault() != null;
    }

    public static string GetDispositivo(HttpRequestBase request)
    {
        try
        {
            string strUserAgent = request.UserAgent.ToString().ToLower();
            return strUserAgent;
        }
        catch (Exception ex)
        {
            return "";
        }
    }
    
    public static void PreencheTempDataAlertaSucesso(Controller controller, string msgSucesso)
    {
        PreencheTempDataAlerta(controller, new RetornoApi(msgSucesso));
    }

    public static void PreencheTempDataAlerta(Controller controller, string msgAlerta)
    {
        PreencheTempDataAlerta(controller, RetornoApi.RetornoAlerta(msgAlerta));
    }

    public static void PreencheTempDataAlerta(Controller controller, RetornoApi retorno)
    {
        if (retorno != null)
        {
            PreencheTempDataAlerta(controller, retorno.Mensagem, retorno.TituloAlerta, retorno.CssAlerta);
        }
    }

    public static void PreencheTempDataAlerta(Controller controller, string msg, string titulo, string css)
    {
        string mensagem = "";

        if (string.IsNullOrEmpty(msg))
        {
            mensagem = "sem mensagem";
        }
        else
        {
            mensagem = msg;
            mensagem = mensagem.Replace("\n\r", "");
            mensagem = mensagem.Replace("\r\n", "");
            mensagem = mensagem.Replace("\n", "");
            mensagem = mensagem.Replace("\r", "");
            mensagem = mensagem.Replace("''", "(vazio)");
            mensagem = mensagem.Replace("'", "");
        }

        controller.TempData["mensagemAlerta"] = mensagem;
        controller.TempData["tituloAlerta"] = titulo;
        controller.TempData["cssAlerta"] = css;
    }

    public static void EnviarEmailErro(string mensagem, string stacktrace, string innerException)
    {
        try
        {
            string enviaEmailErro = ConfigurationManager.AppSettings["enviaEmailErro"];

            if (enviaEmailErro == "1")
            {
                Task.Run(() => EnviaEmailErroTask(mensagem, stacktrace, innerException));
            }
        }
        catch (Exception ex)
        {
            //do nothing
        }
    }

    private static void EnviaEmailErroTask(string mensagem, string stacktrace, string innerException)
    {
        try
        {
            string smtpEmailErro = ConfigurationManager.AppSettings["smtpEmailErro"];
            string from = ConfigurationManager.AppSettings["fromEmailErro"];
            string to = ConfigurationManager.AppSettings["toEmailErro"];

            string subject = "Erro Aprovacao Credito";

            string body = "Mensagem: " + mensagem + "\n";

            if (!string.IsNullOrEmpty(stacktrace))
            {
                body += "Stacktrace: " + stacktrace + "\n";
            }

            if (!string.IsNullOrEmpty(innerException))
            {
                body += "InnerException: " + innerException + "\n";
            }

            MailMessage message = new MailMessage(from, to, subject, body);
            SmtpClient client = new SmtpClient(smtpEmailErro);

            client.Send(message);
        }
        catch (Exception ex)
        {
            //do nothing
        }
    }

}