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
    /// <summary>
    /// Controlador responvavel pela entidade Empresa
    /// </summary>
    public class EmpresaController : ApiController
    {
        /// <summary>
        /// Consulta Negociação de verba de acordo com os critérios de filtro especificados
        /// </summary>
        /// <param name="pagina">Pagina Atual</param>
        /// <param name="tamanho">Tamanho das paginas</param>
        /// <param name="coluna">critério de ordenacao</param>
        /// <param name="sentido">Sentido de ordenação - asc/desc</param>
        /// <param name="filtro">Objeto de filtro</param>
        /// <returns>Lista de negociações que atendem ao critério do filtro</returns>
        [Route("empresa/{pagina}/{tamanho}/{coluna}/{sentido}/list")]
        [HttpPost]
        public ListResult<Empresa> List(int pagina, int tamanho, string coluna, string sentido, [FromBody]Empresa filtro)
        {
            return new ListResult<Empresa>() { Result = new List<Empresa>(), TotalRows = 0 };
            //return EmpresaBLL.List(filtro);
        }
    }
}