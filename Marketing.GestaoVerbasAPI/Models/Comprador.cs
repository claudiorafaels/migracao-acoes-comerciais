using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models
{
    public class Comprador
    {
        public int? CodComprador { get; set; }

        public string NomComprador { get; set; }

        public int? CodFuncionario { get; set; }

        public int? CodFilialEmpresa { get; set; }
    }
}