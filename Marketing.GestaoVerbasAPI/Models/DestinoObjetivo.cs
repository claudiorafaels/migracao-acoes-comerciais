using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models
{
    public class DestinoObjetivo
    {
        /// <summary>
        /// TIPDSNDSCBNF
        /// </summary>
        public int? CodDestinoObjetivo { get; set; }

        /// <summary>
        /// DESDSNDSCBNF
        /// </summary>
        public string NomDestinoObjetivo { get; set; }



        /// <summary>
        /// DESOBJDSNVBA - DESCRICAO DO OBJETIVO DO DESTINO DA VERBA                
        /// </summary>
        public string NomObjetivo { get; set; }

        /// <summary>
        /// TIPOBJDSNVBA - TIPO DO OBJETIVO DO DESTINO DA VERBA
        /// </summary>
        public int? CodObjetivo { get; set; }

        /// <summary>
        /// TIPVBAFRN - TIPO DA VERBA DO FORNECEDOR                                
        /// </summary>
        public int? CodDestino { get; set; }

    }
}