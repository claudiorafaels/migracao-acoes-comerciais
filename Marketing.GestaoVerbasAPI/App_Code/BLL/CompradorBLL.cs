using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.App_Code.Connection;
namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class CompradorBLL
    {
        public static List<Comprador> List(Comprador filtro)
        {
            return CompradorDAL.List(filtro);
        }
    }
}