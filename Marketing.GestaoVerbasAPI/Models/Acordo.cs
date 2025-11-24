using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models
{
    public class Acordo
    {
        /// <summary>
        /// CODEMP -  CODIGO EMPRESA
        /// </summary>
        public int? CodEmpresa { get; set; }

        /// <summary>
        /// CODFILEMP -  CODIGO FILIAL EMPRESA
        /// </summary>
        public int? CodFilialEmpresa { get; set; }

        /// <summary>
        /// CODPMS
        /// </summary>
        public int? CodPromessa { get; set; }

        /// <summary>
        /// DATNGCPMS
        /// </summary>
        public DateTime? DtNegociacaoAcordo { get; set; }

        /// <summary>
        /// CODSITPMS
        /// </summary>
        public int? CodStatusAcordo { get; set; }

        /// <summary>
        /// NUMPEDCMP	IDENTIFICA O PEDIDO DE COMPRA
        /// </summary>
        public int? NumPedidoCompra { get; set; }

        /// <summary>
        /// CODFRN - CODIGO FORNECEDOR
        /// </summary>
        public int? CodFornecedor { get; set; }
        
        /// <summary>
        /// NOMACSUSRSIS CHAR(25 BYTE)
        /// </summary>
        public string NomUsuario { get; set; }

        /// <summary>
        /// DESMSGUSR 
        /// </summary>
        public string DesComentarioUsuario { get; set; }

        /// <summary>
        /// NOMCTOFRN
        /// </summary>
        public string NomContatoFornecedor { get; set; }

        /// <summary>
        /// NUMTLFCTOFRN
        /// </summary>
        public string NumTelefoneContatoFornecedor { get; set; }

        /// <summary>
        /// DESCGRCTOFRN
        /// </summary>
        public string NomCargoContatoFornecedor { get; set; }

        /// <summary>
        /// DATEFTPMS
        /// </summary>
        public DateTime? DtEfetivacaoAcordo { get; set; }

        /// <summary>
        ///DATCNCPED
        /// </summary>
        public DateTime? DtCancelamentoAcordo { get; set; }

        /// <summary>
        ///NOMUSRCNCPED 
        /// </summary>
        public string NomFuncionarioCancelamento { get; set; }

        /// <summary>
        /// DATCADPMS - DATA DE CADASTRO DO ACORDO
        /// </summary>
        public DateTime? DtCadastroAcordo { get; set; }

        /// <summary>
        /// INDASCARDFRNPMS NUMBER(5,0)
        /// </summary>
        public int? INDASCARDFRNPMS { get; set; }

        /// <summary>
        /// INDTRNVLRARDCMCRCB NUMBER(5,0)
        /// </summary>
        public int? INDTRNVLRARDCMCRCB { get; set; }

        /// <summary>
        ///DESSTAARDCMC	- DESCRICAO STATUS ACORDO COMERCIAL
        /// </summary>
        public string DesStatusAcordoComercial { get; set; }



        //Auxiliares

        /// <summary>
        /// DESABVFILEMP -  NOME FILIAL EMPRESA ABREVIADO
        /// </summary>
        public string NomFilialEmpresa { get; set; }

        /// <summary>
        /// NOMEMP -  NOME EMPRESA
        /// </summary>
        public string NomEmpresa { get; set; }

        /// <summary>
        /// NOMFRN - CODIGO FORNECEDOR
        /// </summary>
        public string NomFornecedor { get; set; }

        /// <summary>
        /// Lista de formas de recebimentos
        /// </summary>
        public List<AcordoRecebimento> Recebimentos { get; set; }

    }
}