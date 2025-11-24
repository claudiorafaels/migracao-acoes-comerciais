using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marketing.GestaoVerbas.Core;
using Newtonsoft.Json;

namespace Marketing.GestaoVerbas.Controllers
{
    public class AlertController : Controller
    {
        [HttpGet]
        public string GerAlerts()
        {
            if (TempData["mensagemAlerta"] == null)
                return "";
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("titulo", TempData["tituloAlerta"] as string);

            string mensagem = TempData["mensagemAlerta"] as string;
            if (mensagem.Contains("\"ExceptionMessage\":") && mensagem.Contains("\"ExceptionType\":"))
            {
                int start = mensagem.IndexOf("\"ExceptionMessage\":") + 20;
                int end = mensagem.IndexOf("\",\"ExceptionType\":");

                result.Add("mensagem", mensagem.Substring(start, (end - start)));
            }
            else
            {
                result.Add("mensagem", mensagem);
            }

            result.Add("css", TempData["cssAlerta"] as string);

            return JsonConvert.SerializeObject(result);
        }
    }
}
