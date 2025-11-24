using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.GestaoVerbas.ViewModel.RelatoriosCarimbosContabilizados
{
    public class ValoresRecebidosAnalitico
    {
        [Display(Name = "Cód. Fornecedor")]
        public int? CodFornecedor { get; set; }

        [Display(Name = "Fornecedor")]
        public string NomFornecedor { get; set; }

        [Display(Name = "Tipo Lançamento")]
        public string NomTipoLancamento { get; set; }

        [Display(Name = "Cód. Acordo")]
        public int? CodPromessa { get; set; }

        [Display(Name = "Nota Fiscal")]
        public string NumNotaFiscal { get; set; }

        [Display(Name = "Vlr. Acordo")]
        [DataType(DataType.Currency)]
        public decimal? VlrAcordo { get; set; }

    }
}