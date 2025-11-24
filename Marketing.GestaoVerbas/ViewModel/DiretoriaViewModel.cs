using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbas.ViewModel
{
    public class DiretoriaViewModel
    {
        [Display(Name = "Cód. Diretoria")]
        public int? CodDiretoria { get; set; }

        [Display(Name = "Diretoria")]
        public string NomDiretoria { get; set; }
    }
}