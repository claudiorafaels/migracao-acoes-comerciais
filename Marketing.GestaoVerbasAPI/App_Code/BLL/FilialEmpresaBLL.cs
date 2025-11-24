using Marketing.GestaoVerbasAPI.App_Code.Connection;
using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class FilialEmpresaBLL
    {

        public static ListResult<FilialEmpresa> List(int pagina, int tamanho, string coluna, string sentido, FilialEmpresa filtro)
        {
            return FilialEmpresaDAL.List(pagina, tamanho, coluna, sentido, filtro);
        }

        public static List<FilialEmpresa> ListLookup()
        {
            return FilialEmpresaDAL.ListLookup();
        }

    }
}