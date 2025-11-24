using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.GestaoVerbas.ViewModel
{
    public class NegociacaoVerbaViewModel
    {

        [Key]
        [Display(Name = "Cod. Negociação")]
        public int? CodNegociacaoVerba { get; set; }

        [Display(Name = "Negociação")]
        [StringLength(40)]
        [Required()]
        public string DesNegociacaoVerba { get; set; }

        [Display(Name = "Comprador")]
        [StringLength(200)]
        public string NomComprador { get; set; }

        [Display(Name = "Comprador")]
        [Required()]
        public int? CodComprador { get; set; }

        [Display(Name = "Status")]
        public int? CodStatusNegociacaoVenda { get; set; }

        [Display(Name = "Fornecedor")]
        [StringLength(35)]
        public string NomFornecedor { get; set; }

        [Display(Name = "Cód. Fornecedor")]
        [Required()]
        public int? CodFornecedor { get; set; }

        [Display(Name = "Cód. Célula")]
        public int? CodCelula { get; set; }

        [Display(Name = "Célula")]
        public string NomCelula { get; set; }

        [Display(Name = "Autor")]
        [StringLength(200)]
        public string NomAutor { get; set; }

        [Display(Name = "Autor")]
        public int? CodAutor { get; set; }

        [Display(Name = "Filial de Origem")]
        [Required()]
        public int? CodFilialVerba { get; set; }

        [Display(Name = "Filial de Origem")]
        [StringLength(200)]
        public string NomFilialVerba { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        [Display(Name = "Dt. Cadastro")]
        [DataType(DataType.Text)]
        public DateTime? DtCadastroNegociacao { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        [Display(Name = "Dt. Aprovacao")]
        [DataType(DataType.Text)]
        public DateTime? DtAprovacao { get; set; }

        [Display(Name = "Valor")]
        [DataType(DataType.Currency)]
        [Required()]
        public Decimal? VlrVerba { get; set; }

        [Display(Name = "Justificativa")]
        [StringLength(2400)]
        [Required()]
        public string DesJustificativaReprovacao { get; set; }

        [StringLength(2400)]
        [Display(Name = "Observação para o fornecedor")]
        [Required()]
        public string DesObservacaoSolicitacao { get; set; }

        [Display(Name = "Empenhos")]
        public List<NegociacaoVerbaDestinoViewModel> Destinos { get; set; }



        [Display(Name = "Status")]
        public string NomStatusNegociacaoVenda
        {
            get
            {
                switch (CodStatusNegociacaoVenda)
                {
                    case 1:
                        return "Nova";
                    case 2:
                        return "Aguardando Aprovação";
                    case 3:
                        return "Aprovado";
                    case 4:
                        return "Reprovado";
                    case null:
                        return "";
                    default:
                        return string.Format("Descrição não encontrada - Codigo: {0}", CodStatusNegociacaoVenda);
                }
            }
        }


        //[Display(Name = "Destino")]
        //[StringLength(500)]
        //public string NomDestino { get; set; }

        //[Display(Name = "Destino")]
        //public int? CodDestino { get; set; }

        //[Display(Name = "Objetivo")]
        //[StringLength(500)]
        //public string NomObjetivo { get; set; }

        //[Display(Name = "Objetivo")]
        //public int? CodObjetivo { get; set; }

        //[Display(Name = "Valor")]
        //[DataType(DataType.DateTime)]
        //public decimal? VlrDestino { get; set; }

        //[Display(Name = "Valor")]
        //[DataType(DataType.DateTime)]
        //public decimal? VlrImposto { get; set; }

        //[Display(Name = "Valor")]
        //[DataType(DataType.DateTime)]
        //public decimal? VlrCarimbo { get; set; }





        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        [Display(Name = "Dt. Início")]
        [DataType(DataType.Text)]
        public DateTime? DtCadastroNegociacaoInicio { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        [Display(Name = "Dt. Fim")]
        [DataType(DataType.Text)]
        public DateTime? DtCadastroNegociacaoFim { get; set; }

        //--------------------------------------------------------------------------------------------

        //[Display(Name = "Filial")]
        //[StringLength(200)]
        //public string NomFilialFiltro { get; set; }

        //[Display(Name = "Filial")]
        //public int? CodFilialFiltro { get; set; }

        //[Display(Name = "Cód. Negociação")]
        //public string strCodNegociacao { get; set; }

       //[Display(Name = "Contato do Fornecedor")]
       //[StringLength(500)]
       //public string DesContatoFornecedor { get; set; }
       //
       //[Display(Name = "Prazo")]
       //[StringLength(500)]
       //public string DesPrazoPagamento { get; set; }
       //
       //[Display(Name = "Forma de Pagamento")]
       //[StringLength(500)]
       //public string NomFormaPagamento { get; set; }
       //
       //[Display(Name = "Forma de Pagamento")]
       //public int? CodFormaPagamento { get; set; }
    }
}