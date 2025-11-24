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
    /// Controlador responsável pela entidade GrupoAD
    /// </summary>
    public class GrupoADController : ApiController
    {

        /// <summary>
        /// Consulta Grupos de Acesso de acordo com os critérios de filtro especificados
        /// </summary>
        /// <param name="pagina">Pagina Atual</param>
        /// <param name="tamanho">Tamanho das paginas</param>
        /// <param name="coluna">critério de ordenacao</param>
        /// <param name="sentido">Sentido de ordenação - asc/desc</param>
        /// <param name="filtro">Objeto de filtro</param>
        /// <returns>Grupos de acesso que atendem ao critério do filtro</returns>
        [Route("grupoad/{pagina}/{tamanho}/{coluna}/{sentido}/list")]
        [HttpPost]
        public ListResult<GrupoAD> List(int pagina, int tamanho, string coluna, string sentido, [FromBody]GrupoAD filtro)
        {
            return GrupoADBLL.List(pagina, tamanho, coluna, sentido, filtro);
        }

        /// <summary>
        /// Atualiza Grupo de Acesso
        /// </summary>
        /// <param name="pCodGrupoAcesso">Código do Grupo de Acesso</param>
        /// <param name="obj"></param>
        /// <returns></returns>
        [Route("grupoad/{pCodGrupoAcesso}/update")]
        [HttpPut]
        public object Update(int pCodGrupoAcesso, [FromBody]GrupoAD obj)
        {
            GrupoADBLL.Update(pCodGrupoAcesso, obj);
            return HttpStatusCode.OK;
        }

        /// <summary>
        /// Insere Grupo de Acesso
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [Route("grupoad/insert")]
        [HttpPost]
        public GrupoAD Post([FromBody]GrupoAD obj)
        {
            return GrupoADBLL.Insert(obj);
        }

        /// <summary>
        /// Exclui o Grupo Acesso
        /// </summary>
        /// <param name="pCodGrupoAcesso">Código do Grupo de Acesso</param>
        /// <returns></returns>
        [Route("grupoad/{pCodGrupoAcesso}/delete")]
        [HttpDelete]
        public object Delete(int pCodGrupoAcesso)
        {
            GrupoADBLL.Delete(pCodGrupoAcesso);
            return HttpStatusCode.OK;
        }

        /// <summary>
        /// Consulta o grupo de acesso pelo codigo
        /// </summary>
        /// <param name="codigo">Codigo do grupo de acesso</param>
        /// <returns>Informações o grupo de acesso</returns>
        [Route("grupoad/{codigo}/select")]
        [HttpGet]
        public GrupoAD Select(int codigo)
        {
            return GrupoADBLL.Select(codigo);
        }

    }
}