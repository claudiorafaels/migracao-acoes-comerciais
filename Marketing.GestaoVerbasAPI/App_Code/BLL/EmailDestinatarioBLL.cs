using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;                   
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class EmailDestinatarioBLL
    {
        public static EmailDestinatario Insert(EmailDestinatario obj)
        {

            obj = EmailDestinatarioDAL.Insert(obj);

            return obj;
        }
    }
}