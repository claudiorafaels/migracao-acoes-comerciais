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
    /// Controlador responvavel pela entidade Filial Empresa
    /// </summary>
    public class FilialEmpresaController : ApiController
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
        [Route("filialEmpresa/{pagina}/{tamanho}/{coluna}/{sentido}/list")]
        [HttpPost]
        public ListResult<FilialEmpresa> List(int pagina, int tamanho, string coluna, string sentido, [FromBody]FilialEmpresa filtro)
        {
            return FilialEmpresaBLL.List(pagina, tamanho, coluna, sentido, filtro);
        }


        /// <summary>
        /// Retorna a lista de Filiais
        /// </summary>
        /// <returns>Lista de filiais</returns>
        [Route("filialEmpresa/ListLookup")]
        [HttpGet]
        public List<FilialEmpresa> ListLookup()
        {
            return FilialEmpresaBLL.ListLookup();
        }
    }
}