using Marketing.GestaoVerbasAPI.App_Code.BLL;
using Marketing.GestaoVerbasAPI.Models.RelatoriosCarimbosContabilizados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Marketing.GestaoVerbasAPI.Controllers.v1
{
    public class AnoMesReferenciaController : ApiController
    {
        /// <summary>
        /// Retorna os AnoMesReferencia
        /// </summary>
        /// <returns></returns>
        [Route("AnoMesReferencia/listObjetivoPorDestino")]
        [HttpGet]
        public List<AnoMesReferencia> ListAnoMesReferencia()
        {
            return AnoMesReferenciaBLL.ListAnoMesReferencia();
        }
    }
}