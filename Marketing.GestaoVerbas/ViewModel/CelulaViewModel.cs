using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.GestaoVerbas.ViewModel
{
    public class CelulaViewModel
    {
        [Display(Name = "Código")]
        public int? CodCelula { get; set; }

        [Display(Name = "Célula")]
        [StringLength(200)]
        public string NomCelula { get; set; }
    }
}