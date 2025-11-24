using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models.RelatoriosCarimbosContabilizados
{
    public class FiltrosRelatoriosCarimbosContabilizados
    {
        #region "Gerais"
        
        public string IndRelVisao { get; set; }

        public string IndAnaliticoSintetico { get; set; }

        public int? CodFornecedor { get; set; }

        public string NomFornecedor { get; set; }

        public int? CodTipoVerbaFornecedor { get; set; }

        public string IdtAnoMesReferencia { get; set; }
        #endregion

        #region "A receber"

        public DateTime? DtPrevisaoRecebimento { get; set; }

        public int? CodObjetivo { get; set; }

        public string NomObjetivo { get; set; }

        #endregion

        #region "Recebidos"

        public DateTime? DtInicioRecebidos { get; set; }

        public DateTime? DtFimRecebidos { get; set; }

        public int CodTipoLancamento { get; set; }

        public string NomTipoLancamento { get; set; }

        #endregion

        #region "Acordos"

        public DateTime? DtInicioAcordo { get; set; }

        public DateTime? DtFimAcordo { get; set; }

        #endregion
    }
}