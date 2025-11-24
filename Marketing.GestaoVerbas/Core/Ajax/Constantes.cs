using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Ajax;

namespace Marketing.GestaoVerbas.Core.Ajax
{ 


    public class Constantes
    {

        public static AjaxOptions AJAX_PESQUISA_POST_DEFAULT()
        {
            return new AjaxOptions()
            {
                UpdateTargetId = "pageContent",
                InsertionMode = InsertionMode.Replace,
                OnBegin = "DefaultAjaxBegin",
                OnComplete = "DefaultAjaxComplete",
                OnSuccess = "DefaultAjaxSuccess",
                OnFailure = "DefaultAjaxFailure",
                HttpMethod = "POST"
            };
        }
        public static AjaxOptions AJAX_EDIT_POST_DEFAULT()
        {
            return new AjaxOptions()
            {
                UpdateTargetId = "formEdit",
                InsertionMode = InsertionMode.Replace,
                OnBegin = "DefaultAjaxBegin",
                OnComplete = "DefaultAjaxComplete",
                OnSuccess = "DefaultAjaxSuccess",
                OnFailure = "DefaultAjaxFailure",
                HttpMethod = "POST"
            };
        }
    }
}

