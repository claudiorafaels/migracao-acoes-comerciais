using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.GestaoVerbas.ViewModel.RelatoriosVerbasCarimbadas
{
    public class FiltrosRelatoriosVerbasCarimbadas
    {
        #region "Gerais"
        [Display(Name = "Visão")]
        public string IndRelVisao { get; set; }

        [Display(Name = "Tipo")]
        public string IndAnaliticoSintetico { get; set; }

        [Display(Name = "Cód. Fornecedor")]
        public int? CodFornecedor { get; set; }

        [Display(Name = "Fornecedor")]
        public string NomFornecedor { get; set; }

        [Display(Name = "Ano/Mês Referência")]
        public string IdtAnoMesReferencia { get; set; }

        public decimal Destino { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dt. Início")]
        public DateTime? DtInicio { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dt. Fim")]
        public DateTime? DtFim { get; set; }

        [Display(Name = "Cód. Mercadoria")]
        public int? CodMercadoria { get; set; }

        [Display(Name = "Mercadoria")]
        public string NomMercadoria { get; set; }


        #endregion
    }
}