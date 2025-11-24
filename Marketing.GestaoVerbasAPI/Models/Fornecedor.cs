using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models
{
    public class Fornecedor
    {
        /// <summary>
        /// CODFRN -  CODIGO DIVISAO FORNECEDOR
        /// </summary>
        public int? CodFornecedor { get; set; }

        /// <summary>
        /// NOMFRN - NOME DIVISAO FORNECEDOR
        /// </summary>
        public string NomFornecedor { get; set; }


        /// <summary>
        /// CODEMP - CODIGO EMPRESA
        /// </summary>
        public int? CodEmpresa { get; set; }
    }
}