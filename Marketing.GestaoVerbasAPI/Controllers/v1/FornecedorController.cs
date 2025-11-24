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
    /// Controlador responvavel pela entidade Fornecedor
    /// </summary>
    public class FornecedorController : ApiController
    {
        /// <summary>
        /// Consulta os Fornecedores de acordo com os critérios de filtro especificados
        /// </summary>
        /// <param name="pagina">Pagina Atual</param>
        /// <param name="tamanho">Tamanho das paginas</param>
        /// <param name="coluna">critério de ordenacao</param>
        /// <param name="sentido">Sentido de ordenação - asc/desc</param>
        /// <param name="filtro">Objeto de filtro</param>
        /// <returns>Lista de negociações que atendem ao critério do filtro</returns>
        [Route("fornecedor/{pagina}/{tamanho}/{coluna}/{sentido}/list")]
        [HttpPost]
        public ListResult<Fornecedor> List(int pagina, int tamanho, string coluna, string sentido, [FromBody]Fornecedor filtro)
        {
            return FornecedorBLL.List(pagina, tamanho, coluna, sentido, filtro);
        }

        /// <summary>
        /// Retorna os fornecedores do comprador /Filial
        /// </summary>
        /// <param name="codFilialEmpresa"></param>
        /// <param name="codComprador"></param>
        /// <returns></returns>
        [Route("fornecedor/{codFilialEmpresa}/{codComprador}/ListPorCompradorFilial")]
        [HttpGet]
        public List<Fornecedor> ListPorCompradorFilial(int codFilialEmpresa, int codComprador)
        {
            return FornecedorBLL.ListPorCompradorFilial(codFilialEmpresa, codComprador);
        }
    }
}