using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.GestaoVerbas.ViewModel
{
    public class CarimboViewModel
    {
        [Display(Name = "Carimbo")]
        public int? CodCarimbo { get; set; }

        [Display(Name = "Pedido de compra")]
        public int? NumPedidoCompra { get; set; }

        [Display(Name = "Dt. Cadastro")]
        public DateTime DtCadastroCarimbo { get; set; }

        [Display(Name = "Funcionário")]
        public int? CodFuncionario { get; set; }

        [Display(Name = "Comprador")]
        public int? CodFornecedor { get; set; }

        [Display(Name = "Fornecedor")]
        public string NomFornecedor { get; set; }

        [Display(Name = "Cod. Acordo")]
        public int? CodPromessa { get; set; }

        [Display(Name = "Dt. Acordo")]
        public DateTime DtNegociacaoPromessa { get; set; }

        [Display(Name = "Status")]
        public int? CodStatusCarimbo { get; set; }

        [Display(Name = "Observação")]
        public string DesObservacao { get; set; }


        [Display(Name = "Empenho")]
        public int? CodDestinoObjetivo { get; set; }

       
        [Display(Name = "Negociação")]
        public int? CodNegociacaoVerba { get; set; }


        //campos auxiliares 
      

        [Display(Name = "Valor da Verba")]
        [DataType(DataType.Currency)]
        public decimal? VlrVerba { get; set; }

        [Display(Name = "Valor do Carimbo")]
        [DataType(DataType.Currency)]
        public decimal? VlrCarimbo { get; set; }

        [Display(Name = "Valor dos Impostos")]
        [DataType(DataType.Currency)]
        public decimal? VlrImpostos { get; set; }

        [Display(Name = "Funcionário")]
        [StringLength(200)]
        public string NomFuncionario { get; set; }

        [Display(Name = "Empenho")]
        public string NomDestinoObjetivo { get; set; }


        //[Display(Name = "Objetivo")]
        //public int? CodObjetivo { get; set; }

        //[Display(Name = "Objetivo")]
        //[StringLength(500)]
        //public string NomObjetivo { get; set; }

        //[Display(Name = "Destino")]
        //public int? CodDestino { get; set; }

        //[Display(Name = "Destino")]
        //public string NomDestino { get; set; }


        [Display(Name = "Código")]
        public int? CodFilial { get; set; }

        [Display(Name = "Filial")]
        public string NomFilial { get; set; }




        [Display(Name = "Status")]
        public string NomStatusCarimbo
        {
            get
            {
                switch (CodStatusCarimbo)
                {
                    case 1:
                        return "Simulado";
                    case 2:
                        return "Assinado";
                    case 3:
                        return "Realizado";
                    case 4:
                        return "Em Andamento";
                    case 5:
                        return "Cancelado";
                    case 6:
                        return "Recebimento Parcial";
                    case 7:
                        return "Cancelamento Parcial";
                    case null:
                        return "";
                    default:
                        return string.Format("Descrição não encontrada - Codigo: {0}", CodStatusCarimbo);
                }
            }
        }

        public List<CarimboItemViewModel> Itens { get; set; }
    }
}