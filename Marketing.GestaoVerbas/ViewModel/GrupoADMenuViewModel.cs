using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Marketing.GestaoVerbas.ViewModel
{
    public class GrupoADMenuViewModel
    {
        [Display(Name = "Cod. Grupo de Acesso")]
        public int? CodGrupoAcesso { get; set; }

        [Display(Name = "Cod. Menu")]
        public string CodMenu { get; set; }

        public List<MenuViewModel> ControleAcessos { get; set; }
    }
}