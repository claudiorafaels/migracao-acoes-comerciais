using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class ListResult<T>
{
    public List<T> Result { get; set; }
    public int TotalRows { get; set; }
    public Dictionary<string, object> AggregateSummary { get; set; }
}
