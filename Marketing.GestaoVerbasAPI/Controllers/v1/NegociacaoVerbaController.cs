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
    /// Controlador responvavel pela entidade Negociação de Verba
    /// </summary>
    public class NegociacaoVerbaController : ApiController
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
        [Route("negociacaoverba/{pagina}/{tamanho}/{coluna}/{sentido}/list")]
        [HttpPost]
        public ListResult<NegociacaoVerba> List(int pagina, int tamanho, string coluna, string sentido, [FromBody]NegociacaoVerba filtro)
        {
            return NegociacaoVerbaBLL.List(pagina, tamanho, coluna, sentido, filtro);
        }

        /// <summary>
        /// Consulta a negociaação de verba pelo codigo
        /// </summary>
        /// <param name="codigo">Codigo da negociação de verba</param>
        /// <returns>Informações da negociação de verba</returns>
        [Route("negociacaoverba/{codigo}/select")]
        [HttpGet]
        public NegociacaoVerba Get(int codigo)
        {
            return NegociacaoVerbaBLL.Select(codigo);
        }

        /// <summary>
        /// Insere a negociação de verba
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [Route("negociacaoverba/insert")]
        [HttpPost]
        public NegociacaoVerba Post([FromBody]NegociacaoVerba obj)
        {
            return NegociacaoVerbaBLL.Insert(obj);
        }

        /// <summary>
        /// Atualiza a negociação de verba
        /// </summary>
        /// <param name="codigo">Código da negociação de verba a ser atualizada</param>
        /// <param name="obj"></param>
        /// <returns></returns>
        [Route("negociacaoverba/{codigo}/update")]
        [HttpPut]
        public object Update(int codigo, [FromBody]NegociacaoVerba obj)
        {
            NegociacaoVerbaBLL.Update(codigo, obj);
            return HttpStatusCode.OK;
        }

        /// <summary>
        /// Exclui a negociação de verba
        /// </summary>
        /// <param name="codigo">Código da negociação de verba</param>
        /// <returns></returns>
        [Route("negociacaoverba/{codigo}/delete")]
        [HttpDelete]
        public object Delete(int codigo)
        {
            NegociacaoVerbaBLL.Delete(codigo);
            return HttpStatusCode.OK;
        }

        /// <summary>
        /// Atualiza a negociação de verba
        /// </summary>
        /// <param name="codNegociacao">Código da negociação de verba a ser atualizada</param>
        /// <param name="codUsuario"></param>
        /// <returns></returns>
        [Route("negociacaoverba/{codNegociacao}/{codUsuario}/solicitaraprovacao")]
        [HttpPatch]
        public object SolicitarAprovacao(int codNegociacao, int codUsuario)
        {
            NegociacaoVerbaBLL.SolicitarAprovacao(codNegociacao, codUsuario);
            return HttpStatusCode.OK;
        }

        /// <summary>
        /// Atualiza a negociação de verba
        /// </summary>
        /// <param name="codNegociacao">Código da negociação de verba a ser atualizada</param>
        /// <param name="codUsuario"></param>
        /// <param name="acordo"></param>
        /// <returns></returns>
        [Route("negociacaoverba/{codNegociacao}/{codUsuario}/aprovar")]
        [HttpPatch]
        public object Aprovar(int codNegociacao, int codUsuario, [FromBody] Acordo acordo)
        {
            return NegociacaoVerbaBLL.Aprovar(codNegociacao, codUsuario, acordo);
        }

        /// <summary>
        /// Atualiza a negociação de verba
        /// </summary>
        /// <param name="codNegociacao">Código da negociação de verba a ser atualizada</param>
        /// <param name="codUsuario"></param>
        /// <returns></returns>
        [Route("negociacaoverba/{codNegociacao}/{codUsuario}/reprovar")]
        [HttpPatch]
        public object Reprovar(int codNegociacao, int codUsuario, [FromBody]NegociacaoVerbaHistorico desJustificativaReprovacao)
        {
            NegociacaoVerbaBLL.Reprovar(codNegociacao, desJustificativaReprovacao.DesJustificativaReprovacao, codUsuario);
            return HttpStatusCode.OK;
        }

        /// <summary>
        /// Lista acordos da negociação 
        /// </summary>
        /// <param name="codNegociacao">Código da negociação de verba a ser atualizada</param>
        /// <returns></returns>
        [Route("negociacaoverba/{codNegociacao}/listpornegociacao")]
        [HttpGet]
        public object ListPorNegociacao(int codNegociacao)
        {
            return AcordoBLL.ListPorNegociacao(codNegociacao);

        }

        /// <summary>
        /// Seleciona Promessa para gerar PDF
        /// </summary>
        /// <param name="codPromessa">Código da Promessa</param>
        /// <returns></returns>
        [Route("negociacaoverba/{codPromessa}/selectacordopdf")]
        [HttpGet]
        public object SelectAcordoPdf(int codPromessa)
        {
            return AcordoBLL.SelectPKPdf(codPromessa);
        }

    }
}