using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models
{
    public class GrupoAD
    {
        /// <summary>
        /// CODGRPACS NUMBER(10,0)    CODIGO GRUPO DE ACESSO
        /// </summary>
        public int? CodGrupoAcesso { get; set; }

        /// <summary>
        ///DESGRPACS CHAR(40 BYTE)   DESCRICAO DO GRUPO DE ACESSO
        /// </summary>
        public string NomGrupoAcesso { get; set; }

        /// <summary>
        /// DESGRPRDE   CHAR(200 BYTE)  DESCRICAO DO GRUPO DE REDE AD
        /// </summary>
        public string DesGrupoAcesso { get; set; }
    }
}