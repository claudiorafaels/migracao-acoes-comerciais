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
    /// Controlador responvavel pela entidade Negociação de Verba destino
    /// </summary>
    public class NegociacaoVerbaDestinoController : ApiController
    {

        /// <summary>
        /// Consulta a negociaação de verba pelo codigo
        /// </summary>
        /// <param name="codigoNegociacao">Codigo da negociação de verba</param>
        /// <returns>Informações da negociação de verba</returns>
        [Route("negociacaoverbadestino/{codigoNegociacao}/listpornegociacao")]
        [HttpGet]
        public List<NegociacaoVerbaDestino> ListPorNegociacao(int codigoNegociacao)
        {
            return NegociacaoVerbaDestinoBLL.ListPorNegociacao(codigoNegociacao);
        }
    }
}