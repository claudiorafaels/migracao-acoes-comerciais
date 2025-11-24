using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.GestaoVerbas.ViewModel.RelatoriosCarimbosContabilizados
{
    public class ValoresReceberSintetico
    {
        [Display(Name = "Cód. Fornecedor")]
        public int? CodFornecedor { get; set; }

        [Display(Name = "Fornecedor")]
        public string NomFornecedor { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dt. Previsão Recebimento")]
        public DateTime? DtPrevisaoRecebimento { get; set; }

        [Display(Name = "Saldo Extra Acordo")]
        [DataType(DataType.Currency)]
        public decimal? SaldoExtraAcordo { get; set; }

        [Display(Name = "Saldo Acordo")]
        [DataType(DataType.Currency)]
        public decimal? SaldoAcordo { get; set; }

        [Display(Name = "Saldo Total")]
        [DataType(DataType.Currency)]
        public decimal? SaldoTotal { get; set; }
    }
}