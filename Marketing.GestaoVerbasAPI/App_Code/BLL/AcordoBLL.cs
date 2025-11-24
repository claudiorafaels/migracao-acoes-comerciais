using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class AcordoBLL
    {
        public static Acordo Select(int CodEmpresa, int CodFilialEmpresa, int CodPromessa, DateTime DtNegociacaoAcordo)
        {
            return AcordoDAL.Select(CodEmpresa, CodFilialEmpresa, CodPromessa, DtNegociacaoAcordo);
        }

        public static Acordo Insert(Acordo obj)
        {
            obj.DtCadastroAcordo = DateTime.Now;

            obj = AcordoDAL.Insert(obj);

            if (obj.Recebimentos != null)
            {
                foreach (AcordoRecebimento item in obj.Recebimentos)
                {
                    item.CodPromessa = obj.CodPromessa;

                    AcordoRecebimentoBLL.Insert(item);
                }
            }

            return obj;
        }

        public static void Update(int CodEmpresa, int CodFilialEmpresa, int CodPromessa, DateTime DtNegociacaoAcordo, Acordo obj)
        {
            AcordoDAL.Update(CodEmpresa, CodFilialEmpresa, CodPromessa, DtNegociacaoAcordo, obj);

            //if (obj.Itens != null)
            //{
            //    List<AcordoItem> listOld = AcordoItemBLL.ListPorAcordo(codigo);

            //    foreach (AcordoItem item in obj.Itens)
            //    {
            //        item.CodAcordo = obj.CodAcordo;
            //        item.CodDestinoObjetivo = obj.CodDestinoObjetivo;

            //        if (listOld.Where(p => p.CodMercadoria == item.CodMercadoria && p.CodFilialEmpresa == item.CodFilialEmpresa).FirstOrDefault() == null)
            //            AcordoItemBLL.Insert(item);
            //        else
            //            AcordoItemBLL.Update(item.CodAcordo.Value, item.CodMercadoria.Value, item.CodFilialEmpresa.Value, item);
            //    }

            //    foreach (AcordoItem item in listOld)
            //    {
            //        if (obj.Itens.Where(p => p.CodMercadoria == item.CodMercadoria && p.CodFilialEmpresa == item.CodFilialEmpresa).FirstOrDefault() == null)
            //        {
            //            AcordoItemBLL.Delete(item.CodAcordo.Value, item.CodMercadoria.Value, item.CodFilialEmpresa.Value);
            //        }
            //    }
            //}
        }

        public static List<Acordo> ListPorNegociacao(int codigoNegociacaoVerba)
        {
            return AcordoDAL.ListPorNegociacao(codigoNegociacaoVerba);
        }

        public static List<Acordo> SelectPKPdf(int codPromessa)
        {
            return AcordoDAL.SelectPKPdf(codPromessa);
        }

    }
}