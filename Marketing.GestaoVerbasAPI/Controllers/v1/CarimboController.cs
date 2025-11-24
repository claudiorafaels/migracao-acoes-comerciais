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
    /// Controlador responsavel pela entidade Carimbo
    /// </summary>
    public class CarimboController : ApiController
    {
        /// <summary>
        /// Consulta o carimbo pelo codigo
        /// </summary>
        /// <param name="codigoNegociacaoVerba">Codigo da negociação de verba</param>
        /// <param name="codDestinoObjetivo">Codigo do destino</param>
        /// <returns>Informações da negociação de verba</returns>
        [Route("carimbo/{codigoNegociacaoVerba}/{codDestinoObjetivo}/selectPorNegociacao")]
        [HttpGet]
        public Carimbo SelectPorNegociacao(int codigoNegociacaoVerba, int codDestinoObjetivo)
        {
            return CarimboBLL.SelectPorNegociacao(codigoNegociacaoVerba, codDestinoObjetivo);
        }

        /// <summary>
        /// Cria o Carimbo para a negociação de verba
        /// </summary>
        /// <param name="codigoNegociacaoVerba"></param>
        /// <param name="codDestinoObjetivo"></param>
        /// <param name="codUsuario"></param>
        /// <returns></returns>
        [Route("carimbo/{codigoNegociacaoVerba}/{codDestinoObjetivo}/{codUsuario}/CriarCarimbo")]
        [HttpPatch]
        public Carimbo CriarCarimbo(int codigoNegociacaoVerba, int codDestinoObjetivo, int codUsuario)
        {
            return CarimboBLL.CriarCarimbo(codigoNegociacaoVerba, codDestinoObjetivo, codUsuario);
        }

        /// <summary>
        /// Atualiza o carimbo
        /// </summary>
        /// <param name="codCarimbo"></param>
        /// <param name="obj"></param>
        [Route("carimbo/{codCarimbo}/update")]
        [HttpPut]
        public object Update(int codCarimbo, [FromBody]Carimbo obj)
        {
            CarimboBLL.Update(codCarimbo, obj);
            return HttpStatusCode.OK;
        }
    }
}

