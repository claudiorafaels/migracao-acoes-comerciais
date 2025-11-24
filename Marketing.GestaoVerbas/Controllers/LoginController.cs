using Marketing.GestaoVerbas.Api;
using Marketing.GestaoVerbas.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;


namespace Marketing.GestaoVerbas.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            string mapPath = ConfigurationManager.AppSettings["path"];
            Session["MAPPATH"] = mapPath;

            string IdNetwork = Request.QueryString["IdNetwork"];
            string TokenAcessoUsuario = Request.QueryString["Token"];
            if (!string.IsNullOrEmpty(IdNetwork) && !string.IsNullOrEmpty(TokenAcessoUsuario))
            {
                RetornoApi retorno = null;

                retorno = SingleSignOnApi.GetSessionTimeout(IdNetwork, TokenAcessoUsuario);
                if (retorno.Sucesso)
                {
                    RetornoApi retornoUsuario = null;
                    bool result = (bool)retorno.Resultado;
                    if (result)
                    {
                        retornoUsuario = UserApi.ConsultaUsuario(IdNetwork);
                        if (retornoUsuario.Resultado != null)
                        {
                            Usuario usuario = (Usuario)retornoUsuario.Resultado;

                            usuario.Admin = false;

                            Session["NOMEUSUARIO"] = usuario.IdRede;
                            Session["NOMECOMPLETO"] = usuario.Nome;
                            Session["MATRICULA"] = usuario.Matricula;
                            Session["USUARIO"] = usuario;
                            Session["INICIALNOME"] = usuario.Nome.Remove(1);

                            CookieManager.SetCookie(CookieEnum.NOMEUSUARIO, usuario.IdRede);
                            CookieManager.SetCookie(CookieEnum.NOMECOMPLETO, usuario.Nome);
                            CookieManager.SetCookie(CookieEnum.MATRICULA, usuario.Matricula.ToString());
                            CookieManager.SetCookieObj(CookieEnum.USUARIO, usuario);
                            CookieManager.SetCookie(CookieEnum.INICIALNOME, usuario.Nome.Remove(1));

                            string infoDevice = Util.GetDispositivo(Request);
                        }
                    }
                }
            }

            if (Util.ValidaSessao())
            {
                return RedirectToAction("index", "index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            CookieManager.ClearCookies();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Login(string txtUsuario, string txtSenha)
        {
            //if ((txtUsuario == "FakeComprador" || txtUsuario == "FakeAprovador" || txtUsuario == "FakeTradeMarketing" || txtUsuario == "FakeDiretores" || txtUsuario == "FakeUser") && txtSenha == "FakeUser")
            //{
            //    Usuario fakeUser = new Usuario();
            //    fakeUser.Admin = false;
            //    fakeUser.IdRede = txtUsuario;
            //    fakeUser.Nome = txtUsuario;
            //    fakeUser.Matricula = 1299;

            //    Session["NOMEUSUARIO"] = fakeUser.IdRede;
            //    Session["NOMECOMPLETO"] = fakeUser.Nome;
            //    Session["MATRICULA"] = fakeUser.Matricula;
            //    Session["USUARIO"] = fakeUser;
            //    Session["INICIALNOME"] = fakeUser.Nome.Remove(1);

            //    List<string> grupos = new List<string>();
            //    if (txtUsuario == "FakeComprador")
            //        grupos.Add("SNC_COMPRADORES");

            //    if (txtUsuario == "FakeAprovador")
            //        grupos.Add("SMART.GAC.CONTROLADORIA");

            //    if (txtUsuario == "FakeUser")
            //        grupos.Add("TI.ADMINISTRADOR.TRADEMKT");

            //    if (txtUsuario == "FakeTradeMarketing")
            //        grupos.Add("SNC_TRADEMAKETING");

            //    if (txtUsuario == "FakeDiretores")
            //        grupos.Add("SNC_DIRETORES");

            //    Session["GRUPOSUSUARIO"] = grupos;

            //    string strgruposFake = "";
            //    if (txtUsuario == "FakeComprador")
            //        strgruposFake = "'SNC_COMPRADORES'";

            //    if (txtUsuario == "FakeAprovador")
            //        strgruposFake = "'SMART.GAC.CONTROLADORIA'";

            //    if (txtUsuario == "FakeUser")
            //        strgruposFake = "'TI.ADMINISTRADOR.TRADEMKT'";

            //    if (txtUsuario == "FakeTradeMarketing")
            //        strgruposFake = "'SNC_TRADEMAKETING'";

            //    if (txtUsuario == "FakeDiretores")
            //        strgruposFake = "'SNC_DIRETORES'";

            //    RetornoApi retornoMontaMenuFake = MenuApi.ListMenuPorGrupos(strgruposFake);
            //    if (retornoMontaMenuFake.Sucesso)
            //    {
            //        Session["MENUACESSO"] = (List<ViewModel.MenuViewModel>)retornoMontaMenuFake.Resultado;
            //        return RedirectToAction("index", "index");
            //    }
            //    else
            //    {
            //        Util.PreencheTempDataAlerta(this, retornoMontaMenuFake);
            //        return RedirectToAction("Index");
            //    }
            //}
            CookieManager.ClearCookies();
            RetornoApi retornoAutentica = null;
            string usuarioRede = txtUsuario;
            string usuarioAdmin = "";
            bool loginComoAdmin = txtUsuario.Contains("@");

            if (loginComoAdmin)
            {
                usuarioRede = txtUsuario.Split('@')[1];
                usuarioAdmin = txtUsuario.Split('@')[0];

                retornoAutentica = UserApi.AutenticaAPI(usuarioAdmin, txtSenha);
            }
            else
            {
                usuarioRede = txtUsuario;
                retornoAutentica = UserApi.AutenticaAPI(usuarioRede, txtSenha);
            }

            if (!retornoAutentica.Sucesso)
            {
                Util.PreencheTempDataAlerta(this, retornoAutentica);
                return RedirectToAction("Index");
            }

            if (loginComoAdmin)
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["gruposTI"]))
                {
                    Util.PreencheTempDataAlerta(this, "Não há grupos configurados para login como admin.");
                    return RedirectToAction("Index");
                }
                string[] gruposTI = ConfigurationManager.AppSettings["gruposTI"].Split(';');
                string[] gruposusuario = (retornoAutentica.Resultado as List<string>).ToArray();

                if (!gruposusuario.Any(p => gruposTI.Contains(p)))
                {
                    Util.PreencheTempDataAlerta(this, "Você não tem permissão para logar como administrador.");
                    return RedirectToAction("Index");
                }
            }

            RetornoApi retornoUsuario = null;

            retornoUsuario = UserApi.ConsultaUsuario(usuarioRede);

            if (!retornoUsuario.Sucesso)
            {
                Util.PreencheTempDataAlerta(this, retornoUsuario);
                return RedirectToAction("Index");
            }

            Usuario usuario = (Usuario)retornoUsuario.Resultado;
            usuario.Admin = loginComoAdmin;
            Session["NOMEUSUARIO"] = usuario.IdRede;
            Session["NOMECOMPLETO"] = usuario.Nome;
            Session["MATRICULA"] = usuario.Matricula;
            Session["USUARIO"] = usuario;
            Session["INICIALNOME"] = usuario.Nome.Remove(1);
            Session["GRUPOSUSUARIO"] = (retornoAutentica.Resultado as List<string>);

            CookieManager.SetCookie(CookieEnum.NOMEUSUARIO, usuario.IdRede);
            CookieManager.SetCookie(CookieEnum.NOMECOMPLETO, usuario.Nome);
            CookieManager.SetCookie(CookieEnum.MATRICULA, usuario.Matricula.ToString());
            CookieManager.SetCookieObj(CookieEnum.USUARIO, usuario);
            CookieManager.SetCookie(CookieEnum.INICIALNOME, usuario.Nome.Remove(1));              
           

            // string infoDevice = Util.GetDispositivo(Request);

            string strgrupos = "";
            foreach (string grupo in (retornoAutentica.Resultado as List<string>))
            {
                if (strgrupos != "")
                    strgrupos += ",";

                strgrupos += "'" + grupo + "'";
            }

            RetornoApi retornoMontaMenu = MenuApi.ListMenuPorGrupos(strgrupos);
            if (retornoMontaMenu.Sucesso)
            {
                Session["MENUACESSO"] = (List<ViewModel.MenuViewModel>)retornoMontaMenu.Resultado;
                var menuCookie = (List<ViewModel.MenuViewModel>)retornoMontaMenu.Resultado;
                CookieManager.SetCookieMenu(CookieEnum.MENUACESSO, menuCookie);

            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoMontaMenu);
                return RedirectToAction("Index");
            }

            return RedirectToAction("index", "index");
        }
    }
}