using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class DestinoObjetivoBLL
    {

        public static List<DestinoObjetivo> ListObjetivoPorDestino(int codDestino)
        {
            return DestinoObjetivoDAL.ListObjetivoPorDestino(codDestino);
        }

        public static List<DestinoObjetivo> ListObjetivos()
        {
            return DestinoObjetivoDAL.ListObjetivos();
        }
    }
}