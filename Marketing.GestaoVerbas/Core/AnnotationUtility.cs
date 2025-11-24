using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Marketing.GestaoVerbas.Core
{
    public class AnnotationUtility
    {
        public static T GetAnnotation<T>(object obj, string propertyName)
        {

            if (obj == null)
            {
                return default(T);
            }

            List<PropertyInfo> propConfig = obj.GetType().GetProperties().ToList();
            PropertyInfo propertyConfig = (from a in propConfig where a.Name == propertyName select a).FirstOrDefault();

            if ((propertyConfig == null))
            {
                return default(T);
            }

            object[] attributes = propertyConfig.GetCustomAttributes(typeof(T), true);
            if ((attributes == null || attributes.Length == 0))
            {
                return default(T);
            }

            return (T)attributes.First();

        }


        public static T GetAnnotation<T>(object obj)
        {

            if (obj == null)
            {
                return default(T);
            }

            object[] attributes = obj.GetType().GetCustomAttributes(typeof(T), true);
            if ((attributes == null || attributes.Length == 0))
            {
                return default(T);
            }

            return (T)attributes.First();

        }
    }
}