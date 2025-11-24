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
    public class CarimboItemController : ApiController
    {
        /// <summary>
        /// Consulta os itens do fornecdor
        /// </summary>
        /// <param name="codFornecedor"></param>
        /// <param name="codFiliais"></param>
        /// <param name="codComprador"></param>
        /// <param name="codCarimbo"></param>
        /// <param name="dataRef"></param>
        /// <returns></returns>
        [Route("CarimboItem/{codFornecedor}/{codFiliais}/{codComprador}/{codCarimbo}/{dataRef}/ConsultaItensFornecedor")]
        [HttpGet]
        public List<CarimboItem> ConsultaItensFornecedor(int codFornecedor, string codFiliais, int? codComprador, int codCarimbo, string dataRef)
        {
            return CarimboItemBLL.ConsultaItensFornecedor(codFornecedor, codFiliais, codComprador, codCarimbo, dataRef);
        }

        /// <summary>
        /// Retorna os itens(mercadorias) do carimbo
        /// </summary>
        /// <param name="codCarimbo"></param>
        /// <returns></returns>
        [Route("CarimboItem/{codCarimbo}/ListPorCarimbo")]
        [HttpGet]
        public List<CarimboItem> ListPorCarimbo(int codCarimbo)
        {
            return CarimboItemBLL.ListPorCarimbo(codCarimbo);
        }


        /// <summary>
        /// Atualiza as mercadorias do carimbo
        /// </summary>
        /// <param name="codCarimbo"></param>
        /// <param name="carimbo"></param>
        [Route("CarimboItem/{codCarimbo}/UpdateList")]
        [HttpPatch]
        public object UpdateList(int codCarimbo, [FromBody] Carimbo carimbo)
        {
            CarimboItemBLL.UpdateList(codCarimbo, carimbo);
            return HttpStatusCode.OK;
        }
    }
}