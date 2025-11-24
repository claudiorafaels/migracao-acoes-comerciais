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
    public class CelulaController : ApiController
    {

        /// <summary>
        /// Retorna a lista de Filiais
        /// </summary>
        /// <returns>Lista de filiais</returns>
        [Route("celula/ListLookup")]
        [HttpGet]
        public List<Celula> ListLookup()
        {
            return CelulaBLL.ListLookup();
        }
    }
}