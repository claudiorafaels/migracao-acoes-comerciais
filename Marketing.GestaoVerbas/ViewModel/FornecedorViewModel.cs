using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.GestaoVerbas.ViewModel
{
    public class FornecedorViewModel
    {
        [Display(Name = "Cód. Fornecedor")]
        public int? CodFornecedor { get; set; }

        [Display(Name = "Fornecedor")]
        [StringLength(200)]
        public string NomFornecedor { get; set; }

        [Display(Name = "Código da Empresa")]
        public int? CodEmpresa { get; set; }

        [Display(Name = "Empresa")]
        public string NomEmpresa { get; set; }


        [Display(Name = "Fornecedor")]
        public string CodNomFornecedor
        {
            get
            {
                return string.Format("{0} - {1}", CodFornecedor, NomFornecedor);
            }
            set { }
        }
    }
}