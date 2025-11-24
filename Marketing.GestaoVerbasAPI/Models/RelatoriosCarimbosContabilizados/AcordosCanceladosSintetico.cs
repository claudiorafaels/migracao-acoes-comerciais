using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models.RelatoriosCarimbosContabilizados
{
    public class AcordosCanceladosSintetico
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
        /// DATCNCPED
        /// </summary>
        public DateTime? DtCancelamento { get; set; }

        /// <summary>
        /// <summary>
        /// DESDSNDSCBNF
        /// </summary>
        public string NomDestinoObjetivo { get; set; }

        /// VLRNGCPMS -
        /// </summary>
        public decimal? VlrAcordo { get; set; }

        ///// <summary>
        ///// CODPMS
        ///// </summary>
        //public int? CodPromessa { get; set; }

        ///// <summary>
        ///// TIPDSNDSCBNF
        ///// </summary>
        //public int CodDestinoObjetivo { get; set; }



    }
}