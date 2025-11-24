using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models
{
    public class GrupoADMenu
    {

        /// <summary>
        /// //NOMSISINF CHAR(20 BYTE)   NOME SISTEMA DE INFORMACAO
        /// </summary>
        public string NomSistema { get; set; }

        /// <summary>
        /// CODGRPACS NUMBER(10,0)    CODIGO GRUPO DE ACESSO
        /// </summary>
        public int? CodGrupoAcesso { get; set; }

        /// <summary>
        /// CODMNU  CHAR(15 BYTE)   CODIGO MENU
        /// </summary>
        public string CodMenu { get; set; }

    }
}