using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.Connection
{
   
    public class ListResult<T>
    {
        public List<T> Result { get; set; }
        public int TotalRows { get; set; }
        public Dictionary<string, object> AggregateSummary { get; set; }
}

    public class ListResultadoManager
    {
        public static ListResult<T> PaginarLista<T>(List<T> listaObjetos, int pagina, int tamanho, string coluna, string sentido)
        {
            if (sentido == "asc")
            {
                listaObjetos = listaObjetos.OrderBy(p => GetPropertyValue(p, coluna)).ToList();
            }
            else if (sentido == "desc")
            {
                listaObjetos = listaObjetos.OrderByDescending(p => GetPropertyValue(p, coluna)).ToList();
            }

            ListResult<T> retorno = new ListResult<T>();

            int startRange = (tamanho * (pagina - 1));
            if (startRange > listaObjetos.Count)
                startRange = listaObjetos.Count;

            int endRange = tamanho;
            if ((startRange + endRange) > listaObjetos.Count)
                endRange = listaObjetos.Count - startRange;

            retorno.Result = listaObjetos.GetRange(startRange, endRange);
            retorno.TotalRows = listaObjetos.Count;
            return retorno;
        }

        private static object GetPropertyValue(object obj, string propertyName)
        {
            try
            {
                System.Type t = obj.GetType();
                System.Reflection.PropertyInfo[] property = t.GetProperties();
                return t.InvokeMember(propertyName,
                     System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.Public |
                     System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetProperty, null, obj, null);
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }
    }
}