using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.GestaoVerbas.ViewModel
{
    public class CarimboItemViewModel
    {
        [Display(Name = "Carimbo")]
        public int? CodCarimbo { get; set; }

        [Display(Name = "Código da Filial")]
        public int? CodFilialEmpresa { get; set; }


        [Display(Name = "Empenho")]
        public int? CodDestinoObjetivo { get; set; }

        [Display(Name = "Mercadoria")]
        public int? CodMercadoria { get; set; }


        [Display(Name = "Verba Total")]
        [DataType(DataType.Currency)]
        public decimal? VlrPrevistoCarimbo { get; set; }

        [Display(Name = "Vlr. Realizado")]
        [DataType(DataType.Currency)]
        public decimal? VlrRealizadoCarimbo { get; set; }

        [Display(Name = "Vlr. Cancelado")]
        [DataType(DataType.Currency)]
        public decimal? VlrCanceladoCarimbo { get; set; }

        [Display(Name = "Impostos")]
        [DataType(DataType.Currency)]
        public decimal? VlrImpostos { get; set; }



        //auxiliares

        [Display(Name = "Verba Unitário")]
        [DataType(DataType.Currency)]
        public decimal? VlrVerbaUnitario { get; set; }

        [Display(Name = "%Part. Verba")]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal? VlrPerParticipacaoVerba { get; set; }

        [Display(Name = "%Queda Ponderada")]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal? VlrPerQuedaPonderada { get; set; }


        [Display(Name = "Empenho")]
        public string NomDestinoObjetivo { get; set; }

        [Display(Name = "Descrição")]
        public string NomMercadoria { get; set; }


        [Display(Name = "Filial")]
        public string NomFilialEmpresa { get; set; }

        [Display(Name = "Categoria")]
        public string DesClasseMercadoria { get; set; }

        [Display(Name = "Categoria")]
        public int? CodGrupoSimilar { get; set; }


        [Display(Name = "Custo Preço")]
        [DisplayFormat(DataFormatString = "{0:0.0000}")]
        public decimal? VlrDiarioCustoMedioEfetivo { get; set; }

        [Display(Name = "Qtd. Estoque")]
        [DisplayFormat(DataFormatString = "{0:#,#}")]
        public int? QtdEstoqueMercadoria { get; set; }

        [Display(Name = "Vlr. Estoque")]
        [DisplayFormat(DataFormatString = "{0:#,#}")]
        //[DisplayFormat(DataFormatString = "{0:#,#.##}")]
        public decimal? VlrEstoqueMercadoria { get; set; }

        //qtd saldo pedido
        [Display(Name = "Qtd. Saldo Pedido")]
        [DisplayFormat(DataFormatString = "{0:#,#}")]
        public decimal? QtdSaldoPeriodoMercadoria { get; set; }

        //vlr pedido
        [Display(Name = "Vlr. Pedido")]
        [DisplayFormat(DataFormatString = "{0:#,#}")]
        public decimal? VlrSaldoPeriodoMercadoria { get; set; }

        /// <summary>
        /// (QDEMEDVNDMNSMER * VLRDIRCSTMEDMER) * 0.833 // VLRDIRCSTMEDMER = VALOR DIARIO CUSTO MEDIO MERCADORIA,  QDEMEDVNDMNSMER = QUANTIDADE MEDIA VENDA MENSAL MERCADORIA
        /// </summary>
        public decimal? VlrMedia { get; set; }

        [Display(Name = "Vlr. MB")]
        public decimal? VlrMbVnd { get; set; }

        [Display(Name = "Vlr. MC")]
        public decimal? VlrMcVnd { get; set; }

        /// <summary>
        /// VLRRCTLIQVND -
        /// </summary>
        public decimal? VlrReceitaLiquidaVenda { get; set; }

        [Display(Name = "Verba Margem")]
        public decimal? VlrMedioVerbaParaMargemMercadoria { get; set; }

        [Display(Name = "Verba Preço")]
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

        [Display(Name = "%Funding Total")]
        public decimal? VlrPercentualFundingVendaTotal { get; set; }

        [Display(Name = "%Funding Preço")]
        public decimal? VlrPercentualFundingVendaPreco { get; set; }

        [Display(Name = "Vlr Funding Mercadoria")]
        public decimal? VlrTotalFundingMercadoriaVendida { get; set; }

        [Display(Name = "Vlr Funding Margem")]
        public decimal? VlrTotalFundingMargemVendida { get; set; }






        [Display(Name = "Cobertura")]
        [DisplayFormat(DataFormatString = "{0:0}")]
        public decimal? VlrCobertura
        {
            get
            {
                decimal cobertura = 0;
                if (this.VlrMedia.GetValueOrDefault() > 0)
                    cobertura = (this.VlrEstoqueMercadoria.GetValueOrDefault() * 30) / this.VlrMedia.GetValueOrDefault();

                return Math.Round(cobertura, 0);
            }
        }

        [Display(Name = "%MB")]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal? VlrPerMbVnd
        {
            get
            {
                decimal perMb = 0;
                if (this.VlrReceitaLiquidaVenda.GetValueOrDefault() > 0)
                    perMb = (this.VlrMbVnd.GetValueOrDefault() * 100) / this.VlrReceitaLiquidaVenda.GetValueOrDefault();

                return Math.Round(perMb, 2);
            }
        }

        [Display(Name = "%MC")]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal? VlrPerMcVnd
        {
            get
            {
                decimal perMC = 0;
                if (this.VlrReceitaLiquidaVenda.GetValueOrDefault() > 0)
                    perMC = (this.VlrMcVnd.GetValueOrDefault() * 100) / this.VlrReceitaLiquidaVenda.GetValueOrDefault();

                return Math.Round(perMC, 2);
            }
        }











        //[Display(Name = "Filial")]
        //[StringLength(200)]
        //public string NomFilialFiltro { get; set; }

        //[Display(Name = "Filial")]
        //public int? CodFilialFiltro { get; set; }











        //auxiliares


    }
}