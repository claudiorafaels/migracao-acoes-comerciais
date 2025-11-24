using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.GestaoVerbas.ViewModel
{
    public class FilialEmpresaViewModel
    {
        [Display(Name = "Cód. Filial")]
        public int? CodFilialEmpresa { get; set; }

        [Display(Name = "Filial")]
        [StringLength(200)]
        public string NomFilialEmpresa { get; set; }

        [Display(Name = "Cód. Empresa")]
        public int? CodEmpresa { get; set; }

        [Display(Name = "Empresa")]
        public string NomEmpresa { get; set; }

        [Display(Name = "Filial")]
        public string CodNomFilialEmpresa
        {
            get
            {
                return string.Format("{0} - {1}", CodFilialEmpresa, NomFilialEmpresa);
            }
            set { }
        }
    }
}
