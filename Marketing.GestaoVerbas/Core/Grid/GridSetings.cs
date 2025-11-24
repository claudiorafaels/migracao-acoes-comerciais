using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.GestaoVerbas.Core.Grid
{
   public class GridSetings<T>
    {
        public T Filtro { get; set; }
        public List<T> Result { get; set; }
        public Setings Setings { get; set; }
        public Dictionary<string, object> AggregateSummary { get; set; }
    }
}
