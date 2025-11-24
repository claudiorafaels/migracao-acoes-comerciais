using Marketing.GestaoVerbasAPI.App_Code.Connection;
using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class MercadoriaBLL
    {

        public static ListResult<Mercadoria> List(int pagina, int tamanho, string coluna, string sentido, Mercadoria filtro)
        {
            return MercadoriaDAL.List(pagina, tamanho, coluna, sentido, filtro);
        }

        public static List<Mercadoria> ListLookup()
        {
            return MercadoriaDAL.ListLookup();
        }

    }
}