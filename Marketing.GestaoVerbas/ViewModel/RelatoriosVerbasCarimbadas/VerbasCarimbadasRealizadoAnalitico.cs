using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.GestaoVerbas.ViewModel.RelatoriosVerbasCarimbadas
{
    public class VerbasCarimbadasRealizadoAnalitico
    {
        [Display(Name = "Cód. Fornecedor")]
        public int? CodFornecedor { get; set; }

        [Display(Name = "Fornecedor")]
        public string NomFornecedor { get; set; }

        [Display(Name = "Destino")]
        public string Destino { get; set; }

        [Display(Name = "Filial")]
        public int? CodFilial { get; set; }

        //[Display(Name = "Filial")]
        //public string NomFilial { get; set; }

        //[Display(Name = "Tipo Lançamento")]
        //public string NomTipoLancamento { get; set; }

        [Display(Name = "Cód. Mercadoria")]
        public int? CodMercadoria { get; set; }

        [Display(Name = "Mercadoria")]
        public string DescricaoMercadoria { get; set; }

        [Display(Name = "Valor")]
        [DataType(DataType.Currency)]
        public decimal? Valor { get; set; }

    }
}