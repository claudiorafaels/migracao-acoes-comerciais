using Marketing.GestaoVerbasAPI.App_Code.Connection;
using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class MenuBLL
    {
        public static ListResult<Menu> List(int pagina, int tamanho, string coluna, string sentido, Menu filtro)
        {
            return MenuDAL.List(pagina, tamanho, coluna, sentido, filtro);
        }

        public static List<Menu> SelectporGrupo(int codigo)
        {
            return MenuDAL.SelectporGrupo(codigo);
        }

        public static List<Menu> SelectAssociados(int codigo)
        {
            return MenuDAL.SelectAssociados(codigo);
        }

        public static List<Menu> ListMenuPorGrupos(string pListGrupos)
        {
            return MenuDAL.ListMenuPorGrupos(pListGrupos);
        }
    }
}