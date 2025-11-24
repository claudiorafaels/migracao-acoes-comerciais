using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.GestaoVerbas.ViewModel
{
    public class CompradorViewModel
    {
        [Display(Name = "Cod. Comprador")]
        public int? CodComprador { get; set; }

        [Display(Name = "Comprador")]
        public string NomComprador { get; set; }

        [Display(Name = "Funcionario")]
        public int? CodFuncionario { get; set; }

        public int? CodFilialEmpresa { get; set; }


        [Display(Name = "Comprador")]
        public string CodNomComprador
        {
            get
            {
                return string.Format("{0} - {1}", CodComprador, NomComprador);
            }
            set { }
        }
    }
}