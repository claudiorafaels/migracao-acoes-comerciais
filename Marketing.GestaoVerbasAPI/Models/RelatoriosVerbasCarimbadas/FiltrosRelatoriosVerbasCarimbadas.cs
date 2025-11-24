using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models.RelatoriosVerbasCarimbadas
{
    public class FiltrosRelatoriosVerbasCarimbadas
    {
        #region "Gerais"

        public string IndRelVisao { get; set; }

        public string IndAnaliticoSintetico { get; set; }

        public int? CodFornecedor { get; set; }

        public string NomFornecedor { get; set; }

        public DateTime? DtInicio { get; set; }

        public DateTime? DtFim { get; set; }

        public int? Destino { get; set; }
        #endregion
    }
}