using Marketing.GestaoVerbasAPI.App_Code.BLL;
using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Marketing.GestaoVerbasAPI.Controllers.v1
{
    /// <summary>
    /// Controler responsavel pela entidode DestinoObjetivo
    /// </summary>
    public class DestinoObjetivoController : ApiController
    {
        /// <summary>
        /// Retorna os Destinos de acordo com o objetivo
        /// </summary>
        /// <param name="codDestino"></param>
        /// <returns></returns>
        [Route("DestinoObjetivo/{codDestino}/listObjetivoPorDestino")]
        [HttpGet]
        public List<DestinoObjetivo> ListObjetivoPorDestino(int codDestino)
        {
            return DestinoObjetivoBLL.ListObjetivoPorDestino(codDestino);
        }

        /// <summary>
        /// Retorna Objetivos
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Route("DestinoObjetivo/listObjetivos")]
        [HttpGet]
        public List<DestinoObjetivo> ListObjetivos()
        {
            return DestinoObjetivoBLL.ListObjetivos();
        }
        
    }
}