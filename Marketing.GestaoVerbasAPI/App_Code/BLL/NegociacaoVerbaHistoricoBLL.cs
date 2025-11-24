using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class NegociacaoVerbaHistoricoBLL
    {


        public static List<NegociacaoVerbaHistorico> ListPorNegociacao(int codigoNegociacao)
        {
            return NegociacaoVerbaHistoricoDAL.ListPorNegociacao(codigoNegociacao);
        }


        public static void Insert(NegociacaoVerbaHistorico obj)
        {
            NegociacaoVerbaHistoricoDAL.Insert(obj);
        }
    }
}