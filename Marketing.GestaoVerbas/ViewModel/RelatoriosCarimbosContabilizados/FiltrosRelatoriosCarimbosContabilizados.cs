using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.GestaoVerbas.ViewModel.RelatoriosCarimbosContabilizados
{
    public class FiltrosRelatoriosCarimbosContabilizados
    {
        #region "Gerais"

        [Display(Name = "Relatório")]
        public string IndRelVisao { get; set; }

        [Display(Name = "Tipo de Relatório")]
        public string IndAnaliticoSintetico { get; set; }

        [Display(Name = "Cód. Fornecedor")]
        public int? CodFornecedor { get; set; }

        [Display(Name = "Fornecedor")]
        public string NomFornecedor { get; set; }


        [Display(Name = "Tipo de Verba Fornecedor")]
        public int? CodTipoVerbaFornecedor { get; set; }

        [Display(Name = "Ano/Mês Referência")]
        public string IdtAnoMesReferencia { get; set; }

        #endregion

        #region "A receber"

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dt. Previsão Recebimento")]
        public DateTime? DtPrevisaoRecebimento { get; set; }

        [Display(Name = "Objetivo da Verba")]
        public int? CodObjetivo { get; set; }

        [Display(Name = "Ano/Mês Referência")]
        public string IdtAnomMesReferencia { get; set; }

        #endregion

        #region "Recebidos"

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dt. Início Recebimento")]
        public DateTime? DtInicioRecebidos { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dt. Fim Recebimento")]
        public DateTime? DtFimRecebidos { get; set; }

        [Display(Name = "Tipo Lançamento")]
        public int CodTipoLancamento { get; set; }

        [Display(Name = "Tipo Lançamento")]
        public string NomTipoLancamento { get; set; }

        #endregion

        #region "Acordos"

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dt. Início Acordo")]
        public DateTime? DtInicioAcordo { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Dt. Fim Acordo")]
        public DateTime? DtFimAcordo { get; set; }

        #endregion
    }
}