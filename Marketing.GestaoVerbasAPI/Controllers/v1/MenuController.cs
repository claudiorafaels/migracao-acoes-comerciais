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
    /// Controlador responsável pela entidade Menu
    /// </summary>
    public class MenuController : ApiController
    {
        /// <summary>
        /// Consulta Menus de acordo com os critérios de filtro especificados
        /// </summary>
        /// <param name="pagina">Pagina Atual</param>
        /// <param name="tamanho">Tamanho das paginas</param>
        /// <param name="coluna">critério de ordenacao</param>
        /// <param name="sentido">Sentido de ordenação - asc/desc</param>
        /// <param name="filtro">Objeto de filtro</param>
        /// <returns>Menus que atendem ao critério do filtro</returns>
        [Route("menu/{pagina}/{tamanho}/{coluna}/{sentido}/list")]
        [HttpPost]
        public ListResult<Menu> List(int pagina, int tamanho, string coluna, string sentido, [FromBody]Menu filtro)
        {
            return MenuBLL.List(pagina, tamanho, coluna, sentido, filtro);
        }

        /// <summary>
        /// Consulta menus pelo codigo do grupo de acesso
        /// </summary>
        /// <param name="codigo">Codigo do grupo de acesso</param>
        /// <returns>Informações dos menus</returns>
        [Route("menu/{codigo}/selectporgrupo")]
        [HttpGet]
        public List<Menu> SelectporGrupo(int codigo)
        {
            return MenuBLL.SelectporGrupo(codigo);
        }

        /// <summary>
        /// Retorna lista de menus que o usuário logado possui acesso
        /// </summary>
        /// <param name="ListGrupos">Lista grupos que usuário possui permissão</param>
        /// <returns>Informações dos menus</returns>
        [Route("menu/listmenuporgrupos")]
        [HttpPost]
        public List<Menu> ListMenuPorGrupos([FromBody]string ListGrupos)
        {
            return MenuBLL.ListMenuPorGrupos(ListGrupos);
        }

    }
}