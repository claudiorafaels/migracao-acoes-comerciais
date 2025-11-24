using Marketing.GestaoVerbasAPI.App_Code.Connection;
using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class GrupoADMenuBLL
    {
        public static GrupoAD UpdateList(int codGrupoAcesso, List<Menu> list)
        {
            List<Menu> listOld = MenuBLL.SelectAssociados(codGrupoAcesso);

            foreach (Menu item in list)
            {
                if (listOld.Where(p => p.CodGrupoAcesso == codGrupoAcesso && p.CodMenu == item.CodMenu).Count() == 0)
                {
                    GrupoADMenu menu = new GrupoADMenu() { CodGrupoAcesso = codGrupoAcesso, CodMenu = item.CodMenu };

                    Insert(menu);
                }
            }

            foreach (Menu item in listOld)
            {
                if (list.Where(p => p.CodGrupoAcesso == codGrupoAcesso && p.CodMenu == item.CodMenu).FirstOrDefault() == null)
                {
                    Delete(codGrupoAcesso, item.CodMenu);
                }
            }

            GrupoAD retGrupo = GrupoADBLL.Select(codGrupoAcesso);

            return retGrupo;
        }


        public static GrupoADMenu Insert(GrupoADMenu obj)
        {
            obj = GrupoADMenuDAL.Insert(obj);

            return obj;
        }

        public static void Delete(int pCodGrupoAcesso, string pCodMenu)
        {
            GrupoADMenuDAL.Delete(pCodGrupoAcesso, pCodMenu);
        }
    }
}