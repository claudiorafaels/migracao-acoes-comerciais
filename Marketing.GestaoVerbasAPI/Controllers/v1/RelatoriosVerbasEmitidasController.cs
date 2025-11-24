using Marketing.GestaoVerbasAPI.App_Code.BLL;
using Marketing.GestaoVerbasAPI.App_Code.Connection;
using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Marketing.GestaoVerbasAPI.Controllers.v1
{
    public class RelatoriosVerbasEmitidasController : ApiController
    {
        /// <summary>
        /// Relatório de verbas Emitidas agrupado por Negociação de verbas
        /// </summary>
        /// <param name="pagina">Pagina Atual</param>
        /// <param name="tamanho">Tamanho das paginas</param>
        /// <param name="coluna">critério de ordenacao</param>
        /// <param name="sentido">Sentido de ordenação - asc/desc</param>
        /// <param name="filtro">Objeto de filtro</param>
        /// <returns>Lista de negociações de verba que atenda ao filtro especificado</returns>
        [Route("RelatoriosVerbasEmitidas/{pagina}/{tamanho}/{coluna}/{sentido}/PorCarrimboMercadoria")]
        [HttpPost]
        public ListResult<RelatoriosVerbasEmitidas> PorCarrimboMercadoria(int pagina, int tamanho, string coluna, string sentido, [FromBody]RelatoriosVerbasEmitidas filtro)
        {
            return RelatoriosVerbasEmitidasBLL.PorCarrimboMercadoria(pagina, tamanho, coluna, sentido, filtro);
        }

        /// <summary>
        /// Relatório de verbas Emitidas agrupado por Negociação de verbas
        /// </summary>
        /// <param name="pagina">Pagina Atual</param>
        /// <param name="tamanho">Tamanho das paginas</param>
        /// <param name="coluna">critério de ordenacao</param>
        /// <param name="sentido">Sentido de ordenação - asc/desc</param>
        /// <param name="filtro">Objeto de filtro</param>
        /// <returns>Lista de negociações de verba que atenda ao filtro especificado</returns>
        [Route("RelatoriosVerbasEmitidas/{pagina}/{tamanho}/{coluna}/{sentido}/PorCarrimboFornecedor")]
        [HttpPost]
        public ListResult<RelatoriosVerbasEmitidas> PorCarrimboFornecedor(int pagina, int tamanho, string coluna, string sentido, [FromBody]RelatoriosVerbasEmitidas filtro)
        {
            return RelatoriosVerbasEmitidasBLL.PorCarrimboFornecedor(pagina, tamanho, coluna, sentido, filtro);
        }

        /// <summary>
        /// Relatório de verbas Emitidas agrupado por Negociação de verbas
        /// </summary>
        /// <param name="pagina">Pagina Atual</param>
        /// <param name="tamanho">Tamanho das paginas</param>
        /// <param name="coluna">critério de ordenacao</param>
        /// <param name="sentido">Sentido de ordenação - asc/desc</param>
        /// <param name="filtro">Objeto de filtro</param>
        /// <returns>Lista de negociações de verba que atenda ao filtro especificado</returns>
        [Route("RelatoriosVerbasEmitidas/{pagina}/{tamanho}/{coluna}/{sentido}/PorNegociacaoVerba")]
        [HttpPost]
        public ListResult<RelatoriosVerbasEmitidas> PorNegociacaoVerba(int pagina, int tamanho, string coluna, string sentido, [FromBody]RelatoriosVerbasEmitidas filtro)
        {
            return RelatoriosVerbasEmitidasBLL.PorNegociacaoVerba(pagina, tamanho, coluna, sentido, filtro);
        }

        /// <summary>
        /// Relatório de verbas Emitidas agrupado por Negociação de verbas
        /// </summary>
        /// <param name="pagina">Pagina Atual</param>
        /// <param name="tamanho">Tamanho das paginas</param>
        /// <param name="coluna">critério de ordenacao</param>
        /// <param name="sentido">Sentido de ordenação - asc/desc</param>
        /// <param name="filtro">Objeto de filtro</param>
        /// <returns>Lista de negociações de verba que atenda ao filtro especificado</returns>
        [Route("RelatoriosVerbasEmitidas/{pagina}/{tamanho}/{coluna}/{sentido}/PorNegociacaoVerbaEmpenho")]
        [HttpPost]
        public ListResult<RelatoriosVerbasEmitidas> PorNegociacaoVerbaEmpenho(int pagina, int tamanho, string coluna, string sentido, [FromBody]RelatoriosVerbasEmitidas filtro)
        {
            return RelatoriosVerbasEmitidasBLL.PorNegociacaoVerbaEmpenho(pagina, tamanho, coluna, sentido, filtro);
        }
    }
}