using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbas.ViewModel
{
    public class GrupoADViewModel
    {

        [Key]
        [Display(Name = "Cod. Grupo de Acesso")]
        public int? CodGrupoAcesso { get; set; }

        [Display(Name = "Grupo de Acesso")]
        public string NomGrupoAcesso { get; set; }

        [Display(Name = "Grupo de Rede AD")]
        public string DesGrupoAcesso { get; set; }

        public string CodMenuCorrente { get; set; }

        public List<MenuViewModel> ControleAcessos { get; set; }
    }
}