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
    /// Controler responsavel pela entidade Comprador
    /// </summary>
    public class CompradorController : ApiController
    {
        /// <summary>
        /// Consulta os compradores de acordo com o filtro especificado
        /// </summary>
        /// <returns>Lista de compradores</returns>
        [Route("Comprador/list")]
        [HttpPost]
        public List<Comprador> List([FromBody]Comprador filtro)
        {
            return CompradorBLL.List(filtro);
        }     
    }
}