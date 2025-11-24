using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models
{
    public class Usuario
    {
        public String Matricula { get; set; }
        public string Nome { get; set; }
        public string IdRede { get; set; }
        public string Email { get; set; }
        public string CentroCusto { get; set; }
        public int CodEmpresa { get; set; }
        public int CodFilial { get; set; }
    }
}