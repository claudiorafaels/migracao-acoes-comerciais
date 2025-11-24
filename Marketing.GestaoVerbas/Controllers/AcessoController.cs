using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marketing.GestaoVerbas.ViewModel;
using Marketing.GestaoVerbas.Core;
using Marketing.GestaoVerbas.Core.Grid;
using Marketing.GestaoVerbas.Api;
using System.Net;
using Newtonsoft.Json;


namespace Marketing.GestaoVerbas.Controllers
{
    public class AcessoController : Controller
    {
        // GET: Acesso
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MontaAcesso(string pListaGrupos)
        {
            RetornoApi retornoMontaMenu = MenuApi.ListMenuPorGrupos(pListaGrupos);
            MenuAcessoViewModel acesso = new MenuAcessoViewModel() { CodMenuCorrente = "0" };
            acesso.Acessos = new List<MenuViewModel>();
            if (retornoMontaMenu.Sucesso)
            {
                acesso.Acessos = (List<MenuViewModel>)retornoMontaMenu.Resultado;
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoMontaMenu);
            }

            return PartialView("~/Views/Shared/BaseAcesso.cshtml", acesso);
        }

    }
}