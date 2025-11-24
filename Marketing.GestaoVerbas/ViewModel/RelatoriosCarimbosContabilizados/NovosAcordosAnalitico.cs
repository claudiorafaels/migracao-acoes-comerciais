using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.GestaoVerbas.ViewModel.RelatoriosCarimbosContabilizados
{
    public class NovosAcordosAnalitico
    {
        [Display(Name = "Cód. Fornecedor")]
        public int? CodFornecedor { get; set; }

        [Display(Name = "Fornecedor")]
        public string NomFornecedor { get; set; }

        [Display(Name = "Acordo")]
        public int? CodPromessa { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dt. Negociação Acordo")]
        public DateTime? DtNegociacaoAcordo { get; set; }

        [Display(Name = "Vlr. Acordo")]
        [DataType(DataType.Currency)]
        public decimal? VlrAcordo { get; set; }

    }
}