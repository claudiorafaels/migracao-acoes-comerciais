using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class AcordoRecebimentoBLL
    {
        public static AcordoRecebimento Insert(AcordoRecebimento obj)
        {
            return AcordoRecebimentoDAL.Insert(obj);
        }
    }
}