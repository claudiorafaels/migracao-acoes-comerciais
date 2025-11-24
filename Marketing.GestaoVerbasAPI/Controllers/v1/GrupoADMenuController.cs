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
    public class GrupoADMenuController : ApiController
    {
        /// <summary>
        /// Atualiza os menus associados ao grupo acesso
        /// </summary>
        /// <param name="codGrupoAcesso"></param>
        /// <param name="list"></param>
        [Route("grupoadmenu/{codGrupoAcesso}/UpdateList")]
        [HttpPatch]
        public object UpdateList(int codGrupoAcesso, [FromBody]List<Menu> list)
        {
            return GrupoADMenuBLL.UpdateList(codGrupoAcesso, list);
            
        }

    }
}