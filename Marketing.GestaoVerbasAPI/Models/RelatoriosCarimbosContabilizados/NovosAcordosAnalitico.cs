using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models.RelatoriosCarimbosContabilizados
{
    public class NovosAcordosAnalitico
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
        /// DATNGCPMS - 
        /// </summary>        
        public DateTime? DtNegociacaoAcordo { get; set; }

        /// <summary>
        /// VLRNGCPMS -
        /// </summary>
        public decimal? VlrAcordo { get; set; }

        /// <summary>
        /// CODPMS
        /// </summary>
        public int? CodPromessa { get; set; }
    }
}