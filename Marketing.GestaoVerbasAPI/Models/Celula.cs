using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models
{
    public class Celula
    {
        /// <summary>
        /// CODFILEMP -  CODIGO FILIAL EMPRESA
        /// </summary>
        public int? CodCelula { get; set; }

        /// <summary>
        /// DESABVFILEMP -  NOME FILIAL EMPRESA ABREVIADO
        /// </summary>
        public string NomCelula { get; set; }
    }
}