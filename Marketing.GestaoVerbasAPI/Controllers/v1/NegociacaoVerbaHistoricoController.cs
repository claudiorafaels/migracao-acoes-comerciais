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
    /// Controlador responvavel pela entidade Histórico da Negociação de Verba
    /// </summary>
    public class NegociacaoVerbaHistoricoController : ApiController
    {
        /// <summary>
        /// Consulta a negociaação de verba pelo codigo
        /// </summary>
        /// <param name="codigoNegociacao">Codigo da negociação de verba</param>
        /// <returns>Informações da negociação de verba</returns>
        [Route("negociacaoverbahistorico/{codigoNegociacao}/listpornegociacao")]
        [HttpGet]
        public List<NegociacaoVerbaHistorico> ListPorNegociacao(int codigoNegociacao)
        {
            return NegociacaoVerbaHistoricoBLL.ListPorNegociacao(codigoNegociacao);
        }
    }
}