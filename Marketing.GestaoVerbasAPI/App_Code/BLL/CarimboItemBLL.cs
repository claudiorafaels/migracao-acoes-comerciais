using Marketing.GestaoVerbasAPI.Models;
using Marketing.GestaoVerbasAPI.App_Code.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class CarimboItemBLL
    {

        public static List<CarimboItem> ConsultaItensFornecedor(int CodFornecedor, string CodFiliais, int? CodComprador, int codCarimbo, string dataRef)
        {
            return CarimboItemDAL.ConsultaItensFornecedor(CodFornecedor, CodFiliais, CodComprador, codCarimbo, dataRef);
        }

        public static List<CarimboItem> ListPorCarimbo(int codigo)
        {
            return CarimboItemDAL.ListPorCarimbo(codigo);
        }

        public static CarimboItem Insert(CarimboItem item)
        {
            item.VlrRealizadoCarimbo = 0;
            item.VlrCanceladoCarimbo = 0;
            return CarimboItemDAL.Insert(item);
        }

        public static void Update(int CodCarimbo, int codMercadoria, int codFilial, CarimboItem item)
        {
            CarimboItemDAL.Update(CodCarimbo, codMercadoria, codFilial, item);
        }

        public static void UpdateList(int codCarimbo,  Carimbo pCarimbo)
        {
            Carimbo carimbo = CarimboBLL.Select(codCarimbo);
            if (carimbo.CodStatusCarimbo != 1)
                throw new Exception("O status deste carimbo não permite alteração");

            if (pCarimbo.VlrVerba != null)
            {
                NegociacaoVerba negociacaoVerba = NegociacaoVerbaBLL.Select(carimbo.CodNegociacaoVerba.Value);

                negociacaoVerba.Destinos  = NegociacaoVerbaDestinoBLL.ListPorNegociacao(carimbo.CodNegociacaoVerba.Value);

                //Atualiza o valor da Verba no Destino
                NegociacaoVerbaDestino negociacaoVerbaDestino = negociacaoVerba.Destinos.Where(p => p.CodDestinoObjetivo == carimbo.CodDestinoObjetivo).First();
                negociacaoVerbaDestino.VlrVerba = pCarimbo.VlrVerba;
                NegociacaoVerbaDestinoBLL.Update(carimbo.CodNegociacaoVerba.Value, carimbo.CodDestinoObjetivo.Value, negociacaoVerbaDestino);

                //Atualiza o total da Negociação de verba
                negociacaoVerba.VlrVerba = negociacaoVerba.Destinos.Sum(p => p.VlrVerba.GetValueOrDefault());
                NegociacaoVerbaBLL.Update(negociacaoVerba.CodNegociacaoVerba.Value, negociacaoVerba);

            }

            List<CarimboItem> listOld = CarimboItemBLL.ListPorCarimbo(codCarimbo);

            foreach (CarimboItem item in pCarimbo.Itens)
            {
                item.CodCarimbo = carimbo.CodCarimbo;
                item.CodDestinoObjetivo = carimbo.CodDestinoObjetivo;

                if (listOld.Where(p => p.CodMercadoria == item.CodMercadoria && p.CodFilialEmpresa == item.CodFilialEmpresa).FirstOrDefault() == null)
                    CarimboItemBLL.Insert(item);
                else
                    CarimboItemBLL.Update(item.CodCarimbo.Value, item.CodMercadoria.Value, item.CodFilialEmpresa.Value, item);
            }

            foreach (CarimboItem item in listOld)
            {
                if (pCarimbo.Itens.Where(p => p.CodMercadoria == item.CodMercadoria && p.CodFilialEmpresa == item.CodFilialEmpresa).FirstOrDefault() == null)
                {
                    CarimboItemBLL.Delete(item.CodCarimbo.Value, item.CodMercadoria.Value, item.CodFilialEmpresa.Value);
                }
            }
        }

        public static void Delete(int CodCarimbo, int codMercadoria, int codFilial)
        {
            CarimboItemDAL.Delete(CodCarimbo, codMercadoria, codFilial);
        }
    }
}