using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models.RelatoriosVerbasCarimbadas
{

    public class VerbasCarimbadasRealizadoSintetico
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
        /// Destino da verba
        /// </summary>
        public string Destino { get; set; }

        /// <summary>
        /// Código da Filial
        /// </summary>
        public int? CodFilial { get; set; }

        /// <summary>
        /// VALOR -
        /// </summary>
        public decimal? Valor { get; set; }

    }

}