using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.Models.RelatoriosCarimbosContabilizados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class AnoMesReferenciaBLL
    {
        public static List<AnoMesReferencia> ListAnoMesReferencia()
        {
            return AnoMesReferenciaDAL.ListAnoMesReferencia();
        }
    }
}