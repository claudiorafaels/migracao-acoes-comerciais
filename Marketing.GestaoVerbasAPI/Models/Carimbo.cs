using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models
{
    public class Carimbo
    {
        /// <summary>
        /// CODMCOVBAFRN - CODIGO DO CARIMBO DE VERBA DO FORNECEDOR    
        /// </summary>
        public int? CodCarimbo { get; set; }

        /// <summary>
        /// NUMPEDCMP	IDENTIFICA O PEDIDO DE COMPRA
        /// </summary>
        public int? NumPedidoCompra { get; set; }

        /// <summary>
        /// DATGRCMCOVBAFRN	DATA GERACAO DO CARIMBO DA VERBA DO FORNECEDOR
        /// </summary>
        public DateTime? DtCadastroCarimbo { get; set; }

        /// <summary>
        /// CODFNCMCOVBAFRN	CODIGO FUNCIONARIO DO CARIMBO DE VERBA DO FORNECEDOR
        /// </summary>
        public int? CodFuncionario { get; set; }

        /// <summary>
        /// CODFRN	CODIGO FORNECEDOR
        /// </summary>
        public int? CodFornecedor { get; set; }

        /// <summary>
        /// CODPMS	CODIGO PROMESSA
        /// </summary>
        public int? CodPromessa { get; set; }

        /// <summary>
        /// DATNGCPMS	DATA DA NEGOCIACAO DA PROMESSA
        /// </summary>
        public DateTime? DtNegociacaoPromessa { get; set; }

        /// <summary>
        /// INDSTAMCOVBAFRN	INDICADOR DE STATUS DO CARIMBO DA VERBA DO FORNECEDOR
        /// </summary>
        public int? CodStatusCarimbo { get; set; }

        /// <summary>
        /// DESOBSMCOVBAFRN	DESCRICAO OBSERVACAO DO CARIMBO DA VERBA DO FORNECEDOR
        /// </summary>
        public string DesObservacao { get; set; }

        /// <summary>
        /// TIPOBJMCOVBAFRN	TIPO DO OBJETIVO DO CARIMBO DE VERBA DO FORNECEDOR
        /// </summary>
        public int? TIPOBJMCOVBAFRN { get; set; }


        /// <summary>
        /// VLRUTZACOCMC	VALOR UTILIZADO ACAO COMERCIAL
        /// </summary>
        public decimal? VlrUtilizadoAcaoComercial { get; set; }

        /// <summary>
        /// CODNGC	CODIGO NEGOCIACAO                                                     
        /// </summary>
        public int? CodNegociacaoVerba { get; set; }


        //campos auxiliares 

        /// <summary>
        /// 90% do valor da verba
        /// </summary>
        public decimal? VlrCarimbo { get; set; }

        /// <summary>
        /// 10 % do valorda verba
        /// </summary>
        public decimal? VlrImpostos { get; set; }

        /// <summary>
        /// VLRVBAFRN  - VALOR DA VERBA DO FORNECEDOR                                          
        /// </summary>
        public decimal? VlrVerba { get; set; }



        /// <summary>
        ///TIPDSNDSCBNF - TIPO DESTINO / DESCONTO BONIFICADO                                      
        /// </summary>
        public int? CodDestinoObjetivo { get; set; }

        /// <summary>
        /// DESDSNDSCBNF - DESCRICAO DESTINO DESCONTO / BONIFICACAO
        /// </summary>
        public string NomDestinoObjetivo { get; set; }



        public string NomFuncionario { get; set; }
        public string NomFornecedor { get; set; }


        public int? CodFilial { get; set; }

        public string NomFilial { get; set; }


        public List<CarimboItem> Itens { get; set; }

    }
}