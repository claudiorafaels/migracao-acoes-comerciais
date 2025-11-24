using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.GestaoVerbas.ViewModel.RelatoriosCarimbosContabilizados
{
    public class AcordosCanceladosSintetico
    {
        [Display(Name = "Cód. Fornecedor")]
        public int? CodFornecedor { get; set; }

        [Display(Name = "Fornecedor")]
        public string NomFornecedor { get; set; }

        [Display(Name = "Dt. Cancelamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DtCancelamento { get; set; }

        [Display(Name = "Empenho")]
        public string NomDestinoObjetivo { get; set; }

        [Display(Name = "Vlr. Acordo")]
        [DataType(DataType.Currency)]
        public decimal? VlrAcordo { get; set; }

    }
}