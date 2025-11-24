using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models
{
    public class FilialEmpresa
    {
        /// <summary>
        /// CODFILEMP -  CODIGO FILIAL EMPRESA
        /// </summary>
        public int? CodFilialEmpresa { get; set; }

        /// <summary>
        /// DESABVFILEMP -  NOME FILIAL EMPRESA ABREVIADO
        /// </summary>
        public string NomFilialEmpresa { get; set; }


        /// <summary>
        /// CODEMP -  CODIGO EMPRESA
        /// </summary>
        public int? CodEmpresa { get; set; }

        /// <summary>
        /// NOMEMP -  NOME EMPRESA
        /// </summary>
        public string NomEmpresa { get; set; }
    }
}