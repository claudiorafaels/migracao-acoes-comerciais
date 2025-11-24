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
    public class DiretoriaController : ApiController
    {
        /// <summary>
        /// Consulta as diretorias
        /// </summary>
        /// <returns>Lista de diretorias</returns>
        [Route("Diretoria/list")]
        [HttpPost]
        public List<Diretoria> List([FromBody]Diretoria filtro)
        {
            return DiretoriaBLL.List(filtro);
        }

    }
}
