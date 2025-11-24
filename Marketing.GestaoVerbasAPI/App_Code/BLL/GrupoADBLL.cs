using Marketing.GestaoVerbasAPI.App_Code.Connection;
using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class GrupoADBLL
    {
        public static ListResult<GrupoAD> List(int pagina, int tamanho, string coluna, string sentido, GrupoAD filtro)
        {
            return GrupoADDAO.List(pagina, tamanho, coluna, sentido, filtro);
        }

        public static GrupoAD Select(int codigo)
        {
            return GrupoADDAO.Select(codigo);
        }

        public static GrupoAD Insert(GrupoAD obj)
        {
            obj = GrupoADDAO.Insert(obj);

            return obj;
        }

        public static void Update(int pCodGrupoAcesso, GrupoAD obj)
        {
            GrupoADDAO.Update(pCodGrupoAcesso, obj);
        }

        public static void Delete(int pCodGrupoAcesso)
        {
            GrupoADDAO.Delete(pCodGrupoAcesso);
        }
    }
}