using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Marketing.GestaoVerbas.ViewModel.RelatoriosVerbasCarimbadas
{
    public class VerbasCarimbadasCanceladoAnalitico
    {
        [Display(Name = "Cód. Fornecedor")]
        public int? CodFornecedor { get; set; }

        [Display(Name = "Fornecedor")]
        public string NomFornecedor { get; set; }

        [Display(Name = "Destino")]
        public string Destino { get; set; }

        [Display(Name = "Filial")]
        public int? CodFilial { get; set; }

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