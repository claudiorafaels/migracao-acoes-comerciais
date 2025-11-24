using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbas.ViewModel
{
    public class MenuAcessoViewModel
    {
        public string CodMenuCorrente { get; set; }

        public List<MenuViewModel> Acessos { get; set; }
    }
}