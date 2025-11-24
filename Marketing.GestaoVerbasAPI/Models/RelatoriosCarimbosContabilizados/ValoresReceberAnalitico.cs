using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models.RelatoriosCarimbosContabilizados
{
    public class ValoresReceberAnalitico
    {
        /// <summary>
        /// CODFRN - 
        /// </summary>
        public int? CodFornecedor { get; set; }

        /// <summary>
        /// NOMFRN -
        /// </summary>
        public string NomFornecedor { get; set; }

        /// <summary>
        /// DATPRVRCBPMS - 
        /// </summary>        
        public DateTime? DtPrevisaoRecebimento { get; set; }

        // <summary>
        /// VLRSLDEXAARDCMC + VLRSLDARDCMC -
        /// </summary>
        public decimal? SaldoTotal { get; set; }

        // <summary>
        /// VLRSLDEXAARDCMC -
        /// </summary>
        public decimal? SaldoExtraAcordo { get; set; }

        /// <summary>
        /// VLRSLDARDCMC -
        /// </summary>
        public decimal? SaldoAcordo { get; set; }

        /// <summary>
        /// CODPMS
        /// </summary>
        public int? CodPromessa { get; set; }

    }
}