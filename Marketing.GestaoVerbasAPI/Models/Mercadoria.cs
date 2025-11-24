using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models
{
    public class Mercadoria
    {
        /// <summary>
        /// CODFILEMP -  CODIGO FILIAL EMPRESA
        /// </summary>
        public int? CodMercadoria { get; set; }

        /// <summary>
        /// DESABVFILEMP -  NOME FILIAL EMPRESA ABREVIADO
        /// </summary>
        public string NomMercadoria { get; set; }

    }
}