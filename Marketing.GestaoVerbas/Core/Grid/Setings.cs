using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.GestaoVerbas.Core.Grid
{
    public class Setings
    {
        public string Column { get; set; }
        public string Way { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int CurrentPageSize { get; set; }
        public int TotalRows { get; set; }
    }
}
