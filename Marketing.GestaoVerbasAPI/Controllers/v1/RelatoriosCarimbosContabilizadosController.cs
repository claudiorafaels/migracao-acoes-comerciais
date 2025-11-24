using Marketing.GestaoVerbasAPI.App_Code.BLL;
using Marketing.GestaoVerbasAPI.App_Code.Connection;
using Marketing.GestaoVerbasAPI.Models.RelatoriosCarimbosContabilizados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Marketing.GestaoVerbasAPI.Controllers.v1
{
    public class RelatoriosCarimbosContabilizadosController : ApiController
    {
       
        /// <summary>
        /// Relatório de Carimbos Contabilizados
        /// </summary>
        /// <param name="pagina">Pagina Atual</param>
        /// <param name="tamanho">Tamanho das paginas</param>
        /// <param name="coluna">critério de ordenacao</param>
        /// <param name="sentido">Sentido de ordenação - asc/desc</param>
        /// <param name="filtro">Objeto de filtro</param>
        /// <returns></returns>
        [Route("RelatoriosCarimbosContabilizados/{pagina}/{tamanho}/{coluna}/{sentido}/AReceberAnalitico")]
        [HttpPost]
        public ListResult<ValoresReceberAnalitico> AReceberAnalitico(int pagina, int tamanho, string coluna, string sentido, [FromBody]FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            return RelatoriosCarimbosContabilizadosBLL.AReceberAnalitico(pagina, tamanho, coluna, sentido, filtro);
        }

        /// <summary>
        /// Relatório de Carimbos Contabilizados
        /// </summary>
        /// <param name="pagina">Pagina Atual</param>
        /// <param name="tamanho">Tamanho das paginas</param>
        /// <param name="coluna">critério de ordenacao</param>
        /// <param name="sentido">Sentido de ordenação - asc/desc</param>
        /// <param name="filtro">Objeto de filtro</param>
        /// <returns></returns>
        [Route("RelatoriosCarimbosContabilizados/{pagina}/{tamanho}/{coluna}/{sentido}/AReceberSintetico")]
        [HttpPost]
        public ListResult<ValoresReceberSintetico> AReceberSintetico(int pagina, int tamanho, string coluna, string sentido, [FromBody]FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            return RelatoriosCarimbosContabilizadosBLL.AReceberSintetico(pagina, tamanho, coluna, sentido, filtro);
        }

        /// <summary>
        /// Relatório de Carimbos Contabilizados
        /// </summary>
        /// <param name="pagina">Pagina Atual</param>
        /// <param name="tamanho">Tamanho das paginas</param>
        /// <param name="coluna">critério de ordenacao</param>
        /// <param name="sentido">Sentido de ordenação - asc/desc</param>
        /// <param name="filtro">Objeto de filtro</param>
        /// <returns></returns>
        [Route("RelatoriosCarimbosContabilizados/{pagina}/{tamanho}/{coluna}/{sentido}/RecebidosAnalitico")]
        [HttpPost]
        public ListResult<ValoresRecebidosAnalitico> RecebidosAnalitico(int pagina, int tamanho, string coluna, string sentido, [FromBody]FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            return RelatoriosCarimbosContabilizadosBLL.RecebidosAnalitico(pagina, tamanho, coluna, sentido, filtro);
        }

        /// <summary>
        /// Relatório de Carimbos Contabilizados
        /// </summary>
        /// <param name="pagina">Pagina Atual</param>
        /// <param name="tamanho">Tamanho das paginas</param>
        /// <param name="coluna">critério de ordenacao</param>
        /// <param name="sentido">Sentido de ordenação - asc/desc</param>
        /// <param name="filtro">Objeto de filtro</param>
        /// <returns></returns>
        [Route("RelatoriosCarimbosContabilizados/{pagina}/{tamanho}/{coluna}/{sentido}/RecebidosSintetico")]
        [HttpPost]
        public ListResult<ValoresRecebidosSintetico> RecebidosSintetico(int pagina, int tamanho, string coluna, string sentido, [FromBody]FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            return RelatoriosCarimbosContabilizadosBLL.RecebidosSintetico(pagina, tamanho, coluna, sentido, filtro);
        }

        /// <summary>
        /// Relatório de Carimbos Contabilizados
        /// </summary>
        /// <param name="pagina">Pagina Atual</param>
        /// <param name="tamanho">Tamanho das paginas</param>
        /// <param name="coluna">critério de ordenacao</param>
        /// <param name="sentido">Sentido de ordenação - asc/desc</param>
        /// <param name="filtro">Objeto de filtro</param>
        /// <returns></returns>
        [Route("RelatoriosCarimbosContabilizados/{pagina}/{tamanho}/{coluna}/{sentido}/NovosAcordosAnalitico")]
        [HttpPost]
        public ListResult<NovosAcordosAnalitico> NovosAcordosAnalitico(int pagina, int tamanho, string coluna, string sentido, [FromBody]FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            return RelatoriosCarimbosContabilizadosBLL.NovosAcordosAnalitico(pagina, tamanho, coluna, sentido, filtro);
        }

        /// <summary>
        /// Relatório de Carimbos Contabilizados
        /// </summary>
        /// <param name="pagina">Pagina Atual</param>
        /// <param name="tamanho">Tamanho das paginas</param>
        /// <param name="coluna">critério de ordenacao</param>
        /// <param name="sentido">Sentido de ordenação - asc/desc</param>
        /// <param name="filtro">Objeto de filtro</param>
        /// <returns></returns>
        [Route("RelatoriosCarimbosContabilizados/{pagina}/{tamanho}/{coluna}/{sentido}/NovosAcordosSintetico")]
        [HttpPost]
        public ListResult<NovosAcordosSintetico> NovosAcordosSintetico(int pagina, int tamanho, string coluna, string sentido, [FromBody]FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            return RelatoriosCarimbosContabilizadosBLL.NovosAcordosSintetico(pagina, tamanho, coluna, sentido, filtro);
        }

        /// <summary>
        /// Relatório de Carimbos Contabilizados
        /// </summary>
        /// <param name="pagina">Pagina Atual</param>
        /// <param name="tamanho">Tamanho das paginas</param>
        /// <param name="coluna">critério de ordenacao</param>
        /// <param name="sentido">Sentido de ordenação - asc/desc</param>
        /// <param name="filtro">Objeto de filtro</param>
        /// <returns></returns>
        [Route("RelatoriosCarimbosContabilizados/{pagina}/{tamanho}/{coluna}/{sentido}/AcordosCanceladosAnalitico")]
        [HttpPost]
        public ListResult<AcordosCanceladosAnalitico> AcordosCanceladosAnalitico(int pagina, int tamanho, string coluna, string sentido, [FromBody]FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            return RelatoriosCarimbosContabilizadosBLL.AcordosCanceladosAnalitico(pagina, tamanho, coluna, sentido, filtro);
        }

        /// <summary>
        /// Relatório de Carimbos Contabilizados
        /// </summary>
        /// <param name="pagina">Pagina Atual</param>
        /// <param name="tamanho">Tamanho das paginas</param>
        /// <param name="coluna">critério de ordenacao</param>
        /// <param name="sentido">Sentido de ordenação - asc/desc</param>
        /// <param name="filtro">Objeto de filtro</param>
        /// <returns></returns>
        [Route("RelatoriosCarimbosContabilizados/{pagina}/{tamanho}/{coluna}/{sentido}/AcordosCanceladosSintetico")]
        [HttpPost]
        public ListResult<AcordosCanceladosSintetico> AcordosCanceladosSintetico(int pagina, int tamanho, string coluna, string sentido, [FromBody]FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            return RelatoriosCarimbosContabilizadosBLL.AcordosCanceladosSintetico(pagina, tamanho, coluna, sentido, filtro);
        }
    }
}