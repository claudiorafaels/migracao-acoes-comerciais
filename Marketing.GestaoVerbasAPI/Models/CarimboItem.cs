using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.GestaoVerbasAPI.Models
{
    public class CarimboItem
    {

        /// <summary>
        /// CADMCOVBAFRN -
        /// </summary>
        public int? CodCarimbo { get; set; }

        /// <summary>
        /// CODFILEMP -  CODIGO FILIAL EMPRESA
        /// </summary>
        public int? CodFilialEmpresa { get; set; }

        /// <summary>
        /// TIPDSNDSCBNF - TIPO DESTINO / DESCONTO BONIFICADO                                    
        /// </summary>
        public int? CodDestinoObjetivo { get; set; }

        /// <summary>
        /// CODMER - CODIGO MERCADORIA
        /// </summary>
        public int? CodMercadoria { get; set; }

        /// <summary>
        /// VLRPRVMCOVBAFRN
        /// </summary>
        public decimal? VlrPrevistoCarimbo { get; set; }

        /// <summary>
        /// VLRRLZMCOVBAFRN
        /// </summary>
        public decimal? VlrRealizadoCarimbo { get; set; }

        /// <summary>
        /// VLRCNCMCOVBAFRN
        /// </summary>
        public decimal? VlrCanceladoCarimbo { get; set; }

        /// <summary>
        /// VLRPIS -  
        /// </summary>
        public decimal? VlrImpostos { get; set; }



        //auxiliares

        /// <summary>
        /// DESDSNDSCBNF - DESCRICAO DESTINO DESCONTO / BONIFICACAO                         
        /// </summary>
        public string NomDestinoObjetivo { get; set; }
        
        /// <summary>
        /// DESMER
        /// </summary>
        public string NomMercadoria { get; set; }

        /// <summary>
        /// DESABVFILEMP -  NOME FILIAL EMPRESA
        /// </summary>
        public string NomFilialEmpresa { get; set; }

        /// <summary>
        /// DESCLSMER - DESCRICAO CLASSE MERCADORIA
        /// </summary>
        public string DesClasseMercadoria { get; set; }

        /// <summary>
        /// CODGRPMERSMR - CODIGO GRUPO MERCADORIA SIMILAR
        /// </summary>
        public int? CodGrupoSimilar { get; set; }

        /// <summary>
        /// VLRDIRCSTMEDEFT - VALOR DIARIO DO CUSTO MEDIO EFETIVO 
        /// </summary>
        public decimal? VlrDiarioCustoMedioEfetivo { get; set; }


        /// <summary>
        /// QDEETQMER - (campo calculado)
        /// </summary>
        public int? QtdEstoqueMercadoria { get; set; }

        /// <summary>
        /// VLRETQMER- (campo calculado)
        /// </summary>
        public decimal? VlrEstoqueMercadoria { get; set; }

        /// <summary>
        /// QDESLDPEDMER - QUANTIDADE SALDO PEDIDO MERCADORIA
        /// </summary>
        public decimal? QtdSaldoPeriodoMercadoria { get; set; }

        /// <summary>
        /// VLRSLDPEDMER - VALOR SALDO PEDIDO MERCADORIA 
        /// </summary>
        public decimal? VlrSaldoPeriodoMercadoria { get; set; }

        /// <summary>
        /// (QDEMEDVNDMNSMER * VLRDIRCSTMEDMER) * 0.833 // VLRDIRCSTMEDMER = VALOR DIARIO CUSTO MEDIO MERCADORIA,  QDEMEDVNDMNSMER = QUANTIDADE MEDIA VENDA MENSAL MERCADORIA
        /// </summary>
        public decimal? VlrMedia { get; set; }

        /// <summary>
        /// MB_VND -  (calculado)
        /// </summary>
        public decimal? VlrMbVnd { get; set; }

        /// <summary>
        /// MC_VND -  (calculado)
        /// </summary>
        public decimal? VlrMcVnd { get; set; }

        /// <summary>
        /// VLRRCTLIQVND -
        /// </summary>
        public decimal? VlrReceitaLiquidaVenda { get; set; }

        /// <summary>
        /// VLRMEDVBAMRGMER - VALOR MEDIO DA VERBA PARA MARGEM DA MERCADORIA
        /// </summary>
        public decimal? VlrMedioVerbaParaMargemMercadoria { get; set; }

        /// <summary>
        /// VLRMEDVBAPCOMER - VALOR MEDIO DA VERBA PARA PRECO DA MERCADORIA
        /// </summary>
        public decimal? VlrMedioVerbaParaPrecoMercadoria { get; set; }

        /// <summary>
        /// DESGRPMERSMR -  DESCRICAO GRUPAMENTO MERCADORIA SIMILAR
        /// </summary>
        public string DesGrupoMercadoriaSimilar { get; set; }

        /// <summary>
        /// DESGRPMERSMRAGP -  DESCRICAO GRUPAMENTO MERCADORIA SIMILAR AGRUPADO
        /// </summary>
        public string DesGrupoMercadoriaSimilarAgrupado { get; set; }

        /// <summary>
        /// FTRCNVPCO - FATOR CONVERSAO PRECO P/ CALCULO VALOR PRESENTE
        /// </summary>
        public decimal? VlrFatorConversaoPrecoValorPresente { get; set; }

        /// <summary>
        /// PERFUNVND_TOTAL - Calculado
        /// </summary>
        public decimal? VlrPercentualFundingVendaTotal { get; set; }

        /// <summary>
        /// PERFUNVND_PRECO - Calculado
        /// </summary>
        public decimal? VlrPercentualFundingVendaPreco{ get; set; }

        /// <summary>
        /// VLRTOTFNDMERVND
        /// </summary>
        public decimal? VlrTotalFundingMercadoriaVendida { get; set; }

        /// <summary>
        /// VLRTOTFNDMRGVND - VALOR TOTAL FUNDING PARA MARGEM DE VENDA
        /// </summary>
        public decimal? VlrTotalFundingMargemVendida { get; set; }
        
    }
}