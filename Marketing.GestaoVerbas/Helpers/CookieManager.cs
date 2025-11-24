using Marketing.GestaoVerbas.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;


public class CookieManager
{
    public static void SetCookie(CookieEnum key, string value)
    {
        //NOTE: ENCRYPT
        value = Convert.ToBase64String(MachineKey.Protect(Encoding.UTF8.GetBytes(value)));

        string cookieKey = GetKey(key);

        HttpContext.Current.Response.Cookies[cookieKey].Value = value;
        HttpContext.Current.Response.Cookies[cookieKey].Expires = DateTime.Now.AddDays(1);
    }
    public static void SetCookieObj(CookieEnum key, Usuario value)
    {
        //NOTE: ENCRYPT
        var cript = CryptoHelper.EncryptObject(value);

        string cookieKey = GetKey(key);

        HttpContext.Current.Response.Cookies[cookieKey].Value = cript;
        HttpContext.Current.Response.Cookies[cookieKey].Expires = DateTime.Now.AddDays(1);
    }
    public static void SetCookieMenu(CookieEnum key, List<MenuViewModel> value )
    {
        //NOTE: ENCRYPT
        var cript = CryptoHelper.EncryptObject(value);

        string cookieKey = GetKey(key);

        HttpContext.Current.Response.Cookies[cookieKey].Value = cript;
        HttpContext.Current.Response.Cookies[cookieKey].Expires = DateTime.Now.AddDays(1);
    }

    public static Usuario GetCookieObj(CookieEnum key)
    {
        string cookieKey = GetKey(key);
        HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieKey];

        if (cookie == null)
        {
            return null;
        }

        //NOTE: DECRYPT
        try
        {
           return CryptoHelper.DecryptObject<Usuario>(cookie.Value);
        }
        catch (Exception)
        {
            return null;
        }
    }
    public static List<MenuViewModel> GetCookieMenu(CookieEnum key)
    {
        string cookieKey = GetKey(key);
        HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieKey];

        if (cookie == null)
        {
            return null;
        }

        //NOTE: DECRYPT
        try
        {
           return CryptoHelper.DecryptObject<List<MenuViewModel>>(cookie.Value);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public static string GetCookie(CookieEnum key)
    {
        string cookieKey = GetKey(key);
        HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieKey];

        if (cookie == null)
        {
            return null;
        }

        //NOTE: DECRYPT
        try
        {
            return Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(cookie.Value)));
        }
        catch (Exception)
        {
            return null;
        }
    }

    public static string PopCookie(CookieEnum key)
    {
        string value = GetCookie(key);
        ClearCookie(key);

        return value;
    }

    public static void ClearCookies()
    {
        foreach (CookieEnum key in Enum.GetValues(typeof(CookieEnum)))
        {
            ClearCookie(key);
        }
    }

    private static void ClearCookie(CookieEnum key)
    {
        string cookieKey = GetKey(key);
        HttpContext.Current.Response.Cookies[cookieKey].Expires = DateTime.Now.AddDays(-1);
    }

    private static string GetKey(CookieEnum key)
    {
        return "Marketing.GestaoVerbas_" + key.ToString();
    }
}


public enum CookieEnum
{
    NOMEUSUARIO,
    NOMECOMPLETO,
    MATRICULA,
    USUARIO,
    INICIALNOME,
    MENUACESSO,
    GRUPOSUSUARIO,
    TOKEN,
    DT_EXPIRA_TOKEN
}