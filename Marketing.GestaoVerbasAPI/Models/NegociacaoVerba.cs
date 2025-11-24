using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models
{
    public class NegociacaoVerba
    {
        /// <summary>
        /// CODNGC - CODIGO NEGOCIACAO
        /// </summary>
        public int? CodNegociacaoVerba { get; set; }

        /// <summary>
        /// DESNGC - DESCRICAO NEGOCIACAO
        /// </summary>
        public string DesNegociacaoVerba { get; set; }

        /// <summary>
        /// CODSTANGCFRN - CODIGO DO STATUS DA NEGOCIACAO COM O FORNECEDOR
        /// </summary>
        public int? CodStatusNegociacaoVenda { get; set; }

        /// <summary>
        /// CODFILEMPORIVBA - CODIGO FILIAL EMPRESA ORIGEM DA VERBA
        /// </summary>
        public int? CodFilialVerba { get; set; }

        /// <summary>
        /// DESABVFILEMP - NOME DA FILIAL EMPRESA ORIGEM DA VERBA (ABREVIADO)
        /// </summary>
        public string NomFilialVerba { get; set; }

        /// <summary>
        /// CODFRN - CODIGO FORNECEDOR
        /// </summary>
        public int? CodFornecedor { get; set; }

        /// <summary>
        /// NOMFRN - CODIGO FORNECEDOR
        /// </summary>
        public string NomFornecedor { get; set; }


        /// <summary>
        /// CODCPR - CODIGO DO FUNCIONARIO COMPRADOR
        /// </summary>
        public int? CodComprador { get; set; }

        /// <summary>
        /// NOMCPR
        /// </summary>
        public string NomComprador { get; set; }
  


        /// <summary>
        /// CODFNC - CODIGO FUNCIONARIO AUTOR
        /// </summary>
        public int? CodAutor { get; set; }

        /// <summary>
        /// NOMFNC - NOME DO FUNCIONARIO AUTOR
        /// </summary>
        public string NomAutor { get; set; }
      
        /// <summary>
        /// VLRVBAFRN - VALOR DA VERBA DO FORNECEDOR
        /// </summary>
        public decimal? VlrVerba { get; set; }

        /// <summary>
        /// DATCADNGC - DATA DE CADASTRAMENTO DA NEGOCIACAO   
        /// </summary>        
        public DateTime? DtCadastroNegociacao { get; set; }

        /// <summary>
        /// DATHRAGRCHST - DATA E HORA GRAVACAO DO HISTORICO DE ALTERACAO DE CLIENTE             
        /// </summary>        
        public DateTime? DtAprovacao { get; set; }

        /// <summary>
        /// CODDIVCMP -
        /// </summary>
        public int? CodCelula { get; set; }

        /// <summary>
        /// DESOBSSLC - DESCRICAO OBSERVACAO DA SOLICITACAO
        /// </summary>
        public string DesObservacaoSolicitacao { get; set; }
        

        #region "Campos Auxiliares"
        /// <summary>
        /// DATCADNGC - FILTRO DE INICIO - DATA DE CADASTRAMENTO DA NEGOCIACAO   
        /// </summary>        
        public DateTime? DtCadastroNegociacaoInicio { get; set; }

        /// <summary>
        /// DATCADNGC - FILTRO DE FIM -  DATA DE CADASTRAMENTO DA NEGOCIACAO   
        /// </summary>        
        public DateTime? DtCadastroNegociacaoFim { get; set; }


        /// <summary>
        /// Lista de destinos da verba
        /// </summary>
        public List<NegociacaoVerbaDestino> Destinos { get; set; } 
        #endregion
    }
}