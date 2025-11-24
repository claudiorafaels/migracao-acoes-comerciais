using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Marketing.GestaoVerbasAPI.App_Code.DAL;

namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class DiretoriaBLL
    {
        public static List<Diretoria> List(Diretoria filtro)
        {
            return DiretoriaDAL.List(filtro);
        }
    }
}