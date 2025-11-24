using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class NegociacaoVerbaDestinoBLL
    {
        public static List<NegociacaoVerbaDestino> ListPorNegociacao(int CodNegociacaoVerba)
        {
            return NegociacaoVerbaDestinoDAL.ListPorNegociacao(CodNegociacaoVerba);
        }

        public static NegociacaoVerbaDestino Select(int CodNegociacaoVerba, int CodDestinoObjetivo)
        {
            return NegociacaoVerbaDestinoDAL.Select(CodNegociacaoVerba, CodDestinoObjetivo);
        }

        public static void Insert(NegociacaoVerbaDestino obj)
        {
            NegociacaoVerbaDestinoDAL.Insert(obj);
        }

        public static void Update(int CodNegociacaoVerba, int CodObjetivoDestino, NegociacaoVerbaDestino obj)
        {
            //Carimbo carimbo = CarimboBLL.SelectPorNegociacao(CodNegociacaoVerba, CodObjetivoDestino);

            //if (carimbo != null && carimbo.CodStatusCarimbo != 1)
            //{
            //    throw new Exception(string.Format("O status do carimbo {0} não permite alteração", carimbo.CodCarimbo));
            //}

            NegociacaoVerbaDestinoDAL.Update(CodNegociacaoVerba, CodObjetivoDestino, obj);

            //if (carimbo != null) // se ja tem carimbo
            //{
            //    if (carimbo.DesObservacao != obj.DesObservacao) //verifica se algum campo foi alterado
            //    {
            //        carimbo.DesObservacao = obj.DesObservacao;
            //        //carimbo.CodFornecedor = 
            //        CarimboBLL.Update(carimbo.CodCarimbo.Value, carimbo);
            //    }
            //}
        }

        public static void Delete(int CodNegociacaoVerba, int CodObjetivoDestino)
        {
            //Carimbo carimbo = CarimboBLL.SelectPorNegociacao(CodNegociacaoVerba, CodObjetivoDestino);

            //if (carimbo != null)
            //{
            //    if (carimbo.CodStatusCarimbo != 1)
            //    {
            //        throw new Exception(string.Format("O status do carimbo {0} não permite alteração", carimbo.CodCarimbo));
            //    }
            //    CarimboBLL.Delete(carimbo.CodCarimbo.Value);
            //}

            NegociacaoVerbaDestinoDAL.Delete(CodNegociacaoVerba, CodObjetivoDestino);
        }
    }
}