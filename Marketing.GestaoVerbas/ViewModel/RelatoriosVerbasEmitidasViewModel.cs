using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.GestaoVerbas.ViewModel
{
    public class RelatoriosVerbasEmitidasViewModel
    {
       
        [Display(Name = "Cód. Negociação")]
        public int? CodNegociacaoVerba { get; set; }

        [Display(Name = "Negociação")]
        public string NomNegociacaoVerba { get; set; }

        [Display(Name = "Status Negociação")]
        public int? CodStatusNegociacao { get; set; }

        [Display(Name = "Status da Negociação")]
        public string NomStatusNegociacao
        {
            get
            {
                switch (CodStatusNegociacao)
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
                        return string.Format("Descrição não encontrada - Codigo: {0}", CodStatusNegociacao);
                }
            }
        }

        [Display(Name = "Dt. Negociação de Verba")]
        public DateTime? DtCadastroNegociacao { get; set; }

        [Display(Name = "Valor Verba")]
        [DataType(DataType.Currency)]
        public decimal? VlrVerbaNegociacao { get; set; }


        [Display(Name = "Observação")]
        public string DesObservacaoSolicitacao { get; set; }



        [Display(Name = "Valor Verba Empenho")]
        [DataType(DataType.Currency)]
        public decimal? VlrVerbaEmpenho { get; set; }

        [Display(Name = "Observação")]
        public string DesObservacaoSolicitacaoEmpenho { get; set; }


        [Display(Name = "Cód. Filial")]
        public int? CodFilialEmpresa { get; set; }

        [Display(Name = "Filial")]
        public string NomFilialEmpresa { get; set; }


        [Display(Name = "Cód. Fornecedor")]
        public int? CodFornecedor { get; set; }

        [Display(Name = "Fornecedor")]
        public string NomFornecedor { get; set; }

        

        [Display(Name = "Cód. Destino")]
        public int? CodDestino { get; set; }

        [Display(Name = "Destino")]
        [StringLength(500)]
        public string NomDestino
        {
            get
            {
                switch (CodDestino)
                {
                    case 1:
                        return "Ações Comerciais";
                    case 2:
                        return "Ações em Preço";
                    case null:
                        return "";
                    default:
                        return string.Format("Descrição não encontrada - Codigo: {0}", CodDestino);
                }
            }
        }

        [Display(Name = "Cód. Objetivo")]
        public int? CodObjetivo { get; set; }

        [Display(Name = "Objetivo")]
        public string NomObjetivo { get; set; }

        [Display(Name = "Cód. Empenho")]
        public int? CodDestinoObjetivo { get; set; }

        [Display(Name = "Empenho")]
        public string NomDestinoObjetivo { get; set; }


        [Display(Name = "Cód. Acordo")]
        public int? CodAcordo { get; set; }


        [Display(Name = "Cód. Carimbo")]
        public int? CodCarimbo { get; set; }

        [Display(Name = "Dt. Carimbo")]
        public DateTime? DtCadastroCarimbo { get; set; }

        [Display(Name = "Status do Carimbo")]
        public int? CodStatusCarimbo { get; set; }

        [Display(Name = "Status do Carimbo")]
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

        [Display(Name = "Valor do Carimbo")]
        [DataType(DataType.Currency)]
        public decimal? VlrCarimbo { get; set; }

        [Display(Name = "Valor Impostos Carimbo")]
        [DataType(DataType.Currency)]
        public decimal? VlrImpostos { get; set; }

        [Display(Name = "Observação")]
        public string DesObservacaoCarimbo { get; set; }

        [Display(Name = "Cód. Mercadoria")]
        public int? CodMercadoria { get; set; }

        [Display(Name = "Mercadoria")]
        public string NomMercadoria { get; set; }

        [Display(Name = "Valor Carimbo")]
        [DataType(DataType.Currency)]
        public decimal? VlrCarimboMercadoria { get; set; }



        [Display(Name = "Cód. Comprador")]
        public int? CodComprador { get; set; }

        [Display(Name = "Cód. Célula")]
        public int? CodCelula { get; set; }

        [Display(Name = "Célula")]
        public string NomCelula { get; set; }



        [Display(Name = "Entidade")]
        public string DesEntidade { get; set; }






        //public string DesClasseMercadoria { get; set; }

        //[Display(Name = "Categoria")]
        //public int? CodGrupoSimilar { get; set; }

        //public string DesGrupoMercadoriaSimilar { get; set; }

        //public string DesGrupoMercadoriaSimilarAgrupado { get; set; }

        //[Display(Name = "Comprador")]
        //[StringLength(200)]
        //public string NomComprador { get; set; }

        //[Display(Name = "Pedido de compra")]
        //public int? NumPedidoCompra { get; set; }


        //public List<RelatoriosVerbasEmitidasViewModel> listaResult { get; set; }

        //public int? IndExportar { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dt. Início Carimbo")]
        public DateTime? DtCadastroCarimboInicio { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dt. Fim Carimbo")]
        public DateTime? DtCadastroCarimboFim { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dt. Início Negociação")]
        public DateTime? DtCadastroNegociacaoInicio { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dt. Fim Negociação")]
        public DateTime? DtCadastroNegociacaoFim { get; set; }


        [Display(Name = "Visão")]
        public string IndRelVisao { get; set; }

    }
}