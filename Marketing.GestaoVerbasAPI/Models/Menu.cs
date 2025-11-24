using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models
{
    public class Menu
    {
        /// <summary>
        /// CODMNU  CHAR(15 BYTE)   CODIGO MENU
        /// </summary>
        public string CodMenu { get; set; }

        /// <summary>
        /// DESMNU  CHAR(40 BYTE)   DESCRICAO MENU
        /// </summary>
        public string NomMenu { get; set; }

        /// <summary>
        /// DESICNMNU CHAR(70 BYTE)   DESCRICAO ICONE MENU
        /// </summary>
        public string DesIconeMenu { get; set; }

        /// <summary>
        /// DESLCLAPLMNU    CHAR(70 BYTE)   DESCRICAO LOCAL APLICAR MENU
        /// </summary>
        public string DesLocalAplicacaoMenu { get; set; }

        /// <summary>
        /// CODMNUPAI CHAR(15 BYTE)   CODIGO MENU PAI
        /// </summary>
        public string CodMenuPai { get; set; }
        
        public int IndAssociado { get; set; }

        public int? CodGrupoAcesso { get; set; }

    }
}