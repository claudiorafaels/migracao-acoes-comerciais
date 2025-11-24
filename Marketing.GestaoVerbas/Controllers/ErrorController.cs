using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marketing.GestaoVerbas.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult HTTP403()
        {
            return View();
        }
    }
}