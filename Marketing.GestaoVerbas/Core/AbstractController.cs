//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Mvc;

//namespace Marketing.GestaoVerbas.Core
//{
//    public class AbstractController : Controller
//    {
//        protected void ShowMessage(Message.Alert alert)
//        {
//            List<Message.Alert> alerts = new List<Message.Alert>();
//            if (TempData.ContainsKey(Message.Constantes.TEMP_DATA_KEY) && TempData[Message.Constantes.TEMP_DATA_KEY] is List<Message.Alert>)
//            {
//                alerts = TempData[Message.Constantes.TEMP_DATA_KEY] as List<Message.Alert>;
//            }
//            alerts.Add(alert);
//            TempData[Message.Constantes.TEMP_DATA_KEY] = alerts;
//        }
//    }
//}