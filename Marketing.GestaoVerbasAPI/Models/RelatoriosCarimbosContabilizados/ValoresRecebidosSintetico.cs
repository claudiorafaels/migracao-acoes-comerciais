using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models.RelatoriosCarimbosContabilizados
{
    public class ValoresRecebidosSintetico
    {
        /// <summary>
        /// NOMFRN -
        /// </summary>
        public string NomFornecedor { get; set; }

        /// <summary>
        /// CODFRN - 
        /// </summary>
        public int? CodFornecedor { get; set; }
        /// <summary>
        /// TIPDSC - 
        /// </summary>
        public string NomTipoLancamento { get; set; }

        /// <summary>
        /// VLRNGCPMS -
        /// </summary>
        public decimal? VlrAcordo { get; set; }

    }
}