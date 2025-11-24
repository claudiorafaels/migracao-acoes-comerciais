using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace Marketing.GestaoVerbas.Core
{
    public class CSV<T> where T : class, new()
    {
        public string ConvertCSV(List<T> source, string[] colunas = null)
        {
            List<PropertyInfo> properties = typeof(T).GetProperties().ToList();

            if (colunas == null)
            {
                colunas = new string[properties.Count];
                for (int i = 0; i < properties.Count; i++)
                {
                    colunas[i] = properties[i].Name;
                }
            }

            T defaltValues = new T();

            StringBuilder strBld = new StringBuilder();
            foreach (string coluna in colunas)
            {
                PropertyInfo property = properties.Where(p => p.Name == coluna).FirstOrDefault();

                if (property != null)
                {
                    DisplayAttribute display = AnnotationUtility.GetAnnotation<DisplayAttribute>(defaltValues, coluna);
                    strBld.Append(string.Format("\"{0}\";", display.Name));
                }
            }
            strBld.AppendLine();

            foreach (T item in source)
            {
                foreach (string coluna in colunas)
                {
                    PropertyInfo property = properties.Where(p => p.Name == coluna).FirstOrDefault();

                    if (property != null)
                    {

                        object value = property.GetValue(item, null);

                        strBld.Append(string.Format("\"{0}\";", value));
                    }
                }
                strBld.AppendLine();
            }

            return strBld.ToString();
        }
    }
}