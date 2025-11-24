using Marketing.GestaoVerbasAPI.App_Code.BLL;
using Marketing.GestaoVerbasAPI.App_Code.Connection;
using Marketing.GestaoVerbasAPI.Models;
using Marketing.GestaoVerbasAPI.Models.RelatoriosVerbasCarimbadas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Marketing.GestaoVerbasAPI.Controllers.v1
{
    public class RelatoriosVerbasCarimbadasController : ApiController
    {
        /// <summary>
        /// Relatório de verbas Carimbadas realizadas sintético
        /// </summary>
        /// <param name="pagina">Pagina Atual</param>
        /// <param name="tamanho">Tamanho das paginas</param>
        /// <param name="coluna">critério de ordenacao</param>
        /// <param name="sentido">Sentido de ordenação - asc/desc</param>
        /// <param name="filtro">Objeto de filtro</param>
        /// <returns>Lista de verbas carimbadas realizadas que atenda ao filtro especificado</returns>
        [Route("RelatoriosVerbasCarimbadas/{pagina}/{tamanho}/{coluna}/{sentido}/VerbaCarimbadaRealizadoSintetico")]
        [HttpPost]
        public ListResult<VerbasCarimbadasRealizadoSintetico> VerbaCarimbadaRealizadoSintetico(int pagina, int tamanho, string coluna, string sentido, [FromBody]FiltrosRelatoriosVerbasCarimbadas filtro)
        {
            return RelatoriosVerbasCarimbadasBLL.VerbaCarimbadaRealizadoSintetico(pagina, tamanho, coluna, sentido, filtro);
        }

        /// <summary>
        /// Relatório de verbas Carimbadas realizadas analítico
        /// </summary>
        /// <param name="pagina">Pagina Atual</param>
        /// <param name="tamanho">Tamanho das paginas</param>
        /// <param name="coluna">critério de ordenacao</param>
        /// <param name="sentido">Sentido de ordenação - asc/desc</param>
        /// <param name="filtro">Objeto de filtro</param>
        /// <returns>Lista de verbas carimbadas realizadas que atenda ao filtro especificado</returns>
        [Route("RelatoriosVerbasCarimbadas/{pagina}/{tamanho}/{coluna}/{sentido}/VerbaCarimbadaRealizadoAnalitico")]
        [HttpPost]
        public ListResult<VerbasCarimbadasRealizadoAnalitico> VerbaCarimbadaRealizadoAnalitico(int pagina, int tamanho, string coluna, string sentido, [FromBody]FiltrosRelatoriosVerbasCarimbadas filtro)
        {
            return RelatoriosVerbasCarimbadasBLL.VerbaCarimbadaRealizadoAnalitico(pagina, tamanho, coluna, sentido, filtro);
        }

        /// <summary>
        /// Relatório de verbas Carimbadas canceladas sintético
        /// </summary>
        /// <param name="pagina">Pagina Atual</param>
        /// <param name="tamanho">Tamanho das paginas</param>
        /// <param name="coluna">critério de ordenacao</param>
        /// <param name="sentido">Sentido de ordenação - asc/desc</param>
        /// <param name="filtro">Objeto de filtro</param>
        /// <returns>Lista de verbas carimbadas realizadas que atenda ao filtro especificado</returns>
        [Route("RelatoriosVerbasCarimbadas/{pagina}/{tamanho}/{coluna}/{sentido}/VerbaCarimbadaCanceladoSintetico")]
        [HttpPost]
        public ListResult<VerbasCarimbadasCanceladoSintetico> VerbaCarimbadaCanceladoSintetico(int pagina, int tamanho, string coluna, string sentido, [FromBody]FiltrosRelatoriosVerbasCarimbadas filtro)
        {
            return RelatoriosVerbasCarimbadasBLL.VerbaCarimbadaCanceladoSintetico(pagina, tamanho, coluna, sentido, filtro);
        }

        /// <summary>
        /// Relatório de verbas Carimbadas canceladas analítico
        /// </summary>
        /// <param name="pagina">Pagina Atual</param>
        /// <param name="tamanho">Tamanho das paginas</param>
        /// <param name="coluna">critério de ordenacao</param>
        /// <param name="sentido">Sentido de ordenação - asc/desc</param>
        /// <param name="filtro">Objeto de filtro</param>
        /// <returns>Lista de verbas carimbadas realizadas que atenda ao filtro especificado</returns>
        [Route("RelatoriosVerbasCarimbadas/{pagina}/{tamanho}/{coluna}/{sentido}/VerbaCarimbadaCanceladoAnalitico")]
        [HttpPost]
        public ListResult<VerbasCarimbadasCanceladoAnalitico> VerbaCarimbadaCanceladoAnalitico(int pagina, int tamanho, string coluna, string sentido, [FromBody]FiltrosRelatoriosVerbasCarimbadas filtro)
        {
            return RelatoriosVerbasCarimbadasBLL.VerbaCarimbadaCanceladoAnalitico(pagina, tamanho, coluna, sentido, filtro);
        }
    }
}
