using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbas.ViewModel
{
    public class AcordoRecebimentoViewModel
    {
        [Display(Name = "Cod. Empresa")]
        public int? CodEmpresa { get; set; }

        [Display(Name = "Cod. Filial")]
        public int? CodFilialEmpresa { get; set; }

        [Display(Name = "Cod. Acordo")]
        public int? CodPromessa { get; set; }

        [Display(Name = "Previsão de Vencimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DtPrevisaoRecebimento { get; set; }

        [Display(Name = "Forma de Recebimento")]
        public int? CodFormaRecebimento { get; set; }

        [Display(Name = "Empenho")]
        public int? CodDestinoObjetivo { get; set; }

        [Display(Name = "Empenho")]
        public string NomDestinoObjetivo { get; set; }

        [Display(Name = "Data da Negociação")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DtNegociacaoAcordo { get; set; }
    
        [Display(Name = "Vlr. Verba")]
        public decimal? VlrNegociado { get; set; }

        [Display(Name = "Vlr. Recebido")]
        public decimal? VlrPago { get; set; }

        [Display(Name = "Vlr. Efetivo")]
        public decimal? VlrEfetivo { get; set; }

        /// <summary>
        /// VLRNGCPMSANTARR                               
        /// </summary>
        public decimal? VLRNGCPMSANTARR { get; set; }

        /// <summary>
        /// VLRPDAPMS                               
        /// </summary>
        public decimal? VLRPDAPMS { get; set; }

        /// <summary>
        /// VLRRCTPMS                               
        /// </summary>
        public decimal? VLRRCTPMS { get; set; }

        /// <summary>
        /// INDASCARDFRNPMS                               
        /// </summary>
        public int? INDASCARDFRNPMS { get; set; }



        // Auxiliares
        public string NomFormaRecebimento { get; set; }
    }
}