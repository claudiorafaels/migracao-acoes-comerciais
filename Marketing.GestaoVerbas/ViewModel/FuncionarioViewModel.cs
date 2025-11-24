using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Marketing.GestaoVerbas.ViewModel
{
    public class FuncionarioViewModel
    {
        [Display(Name = "Código")]
        public int? CodFuncionario { get; set; }

        [Display(Name = "Nome")]
        [StringLength(200)]
        public string NomFuncionario { get; set; }

        [Display(Name = "Código da Empresa")]
        public int? CodEmpresa { get; set; }

        [Display(Name = "Empresa")]
        public string NomEmpresa { get; set; }
    }
}