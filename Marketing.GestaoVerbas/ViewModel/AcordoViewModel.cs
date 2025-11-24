using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbas.ViewModel
{
    public class AcordoViewModel
    {


        [Display(Name = "Cod. Empresa")]
        public int? CodEmpresa { get; set; }


        [Display(Name = "Cod. Filial")]
        public int? CodFilialEmpresa { get; set; }


        [Display(Name = "Cod. Acordo")]
        public int? CodPromessa { get; set; }

        [Display(Name = "Data da Negociação")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DtNegociacaoAcordo { get; set; }

        [Display(Name = "Status do Acordo")]
        public int? CodStatusAcordo { get; set; }


        [Display(Name = "Nº Pedido Compra")]
        public int? NumPedidoCompra { get; set; }


        [Display(Name = "Cod. Fornecedor")]
        public int? CodFornecedor { get; set; }


        [Display(Name = "Usuário")]
        [StringLength(25)]
        public string NomUsuario { get; set; }


        [Display(Name = "Comentário")]
        [StringLength(255)]
        public string DesComentarioUsuario { get; set; }

        [Display(Name = "Nome do contato")]
        [StringLength(25)]
        public string NomContatoFornecedor { get; set; }

        [Display(Name = "Telefone do contato")]
        [StringLength(40)]
        public string NumTelefoneContatoFornecedor { get; set; }

        [Display(Name = "Cargo do contato")]
        [StringLength(25)]
        public string NomCargoContatoFornecedor { get; set; }

        [Display(Name = "Dt. Efetivação do acordo")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        public DateTime? DtEfetivacaoAcordo { get; set; }

        [Display(Name = "Dt. Cancelamento do acordo")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        public DateTime? DtCancelamentoAcordo { get; set; }

        [Display(Name = "Nome do funcionario Cancelamento")]
        [StringLength(18)]
        public string NomFuncionarioCancelamento { get; set; }


        [Display(Name = "Dt. Cadastro do acordo")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DtCadastroAcordo { get; set; }

        /// <summary>
        /// INDASCARDFRNPMS NUMBER(5,0)
        /// </summary>
        public int? INDASCARDFRNPMS { get; set; }

        /// <summary>
        /// INDTRNVLRARDCMCRCB NUMBER(5,0)
        /// </summary>
        public int? INDTRNVLRARDCMCRCB { get; set; }


        [Display(Name = "Status do Acordo Comercial")]
        [StringLength(3)]
        public string DesStatusAcordoComercial { get; set; }


        //Auxiliares

        [Display(Name = "Filial")]
        [StringLength(200)]
        public string NomFilialEmpresa { get; set; }

        [Display(Name = "Empresa")]
        [StringLength(200)]
        public string NomEmpresa { get; set; }

        [Display(Name = "Fornecedor")]
        [StringLength(200)]
        public string NomFornecedor { get; set; }


        [Display(Name = "Condição de Recebimento")]
        public List<AcordoRecebimentoViewModel> Recebimentos { get; set; }
    }
}