using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class EmailConteudoBLL
    {
        public static EmailConteudo Insert(EmailConteudo obj)
        {
            
            obj = EmailConteudoDAL.Insert(obj);


            return obj;
        }
    }
}