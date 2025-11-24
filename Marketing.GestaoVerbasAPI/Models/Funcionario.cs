using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models
{
    public class Funcionario
    {
        public int? CodFuncionario { get; set; }
        public string NomFuncionario { get; set; }
        public int? CodEmpresa { get; set; }
    }
}