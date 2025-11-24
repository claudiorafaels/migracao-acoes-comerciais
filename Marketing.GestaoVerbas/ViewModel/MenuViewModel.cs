using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Marketing.GestaoVerbas.ViewModel
{
    public class MenuViewModel
    {
        [Display(Name = "Cod. Menu")]
        public string CodMenu { get; set; }

        [Display(Name = "Nome Menu")]
        public string NomMenu { get; set; }

        [Display(Name = "Descrição Icone Menu")]
        public string DesIconeMenu { get; set; }

        [Display(Name = "Local Aplicação Menu")]
        public string DesLocalAplicacaoMenu { get; set; }

        [Display(Name = "Cod. Menu Pai")]
        public string CodMenuPai { get; set; }

        public int IndAssociado { get; set; }

        public int? CodGrupoAcesso { get; set; }
    }


    
}