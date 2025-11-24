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
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

    }
}