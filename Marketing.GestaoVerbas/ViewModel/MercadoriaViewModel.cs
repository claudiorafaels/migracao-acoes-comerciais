using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.GestaoVerbas.ViewModel
{
    public class MercadoriaViewModel
    {
        [Display(Name = "Código")]
        public int? CodMercadoria { get; set; }

        [Display(Name = "Mercadoria")]
        [StringLength(200)]
        public string NomMercadoria { get; set; }

    }
}