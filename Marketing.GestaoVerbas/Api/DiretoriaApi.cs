using Marketing.GestaoVerbas.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbas.Api
{
    public class DiretoriaApi
    {
        public static RetornoApi List(DiretoriaViewModel filtro)
        {
            RetornoApi retorno = new RetornoApi();

            try
            {
                RetornoApi retornoPost = RestApi.Post(string.Format("/Diretoria/list"), filtro);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }
                List<DiretoriaViewModel> listResult = JsonConvert.DeserializeObject<List<DiretoriaViewModel>>((string)retornoPost.Resultado);

                retorno.Resultado = listResult;
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }
    }
}