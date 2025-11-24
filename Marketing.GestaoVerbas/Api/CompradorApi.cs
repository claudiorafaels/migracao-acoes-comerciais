using Marketing.GestaoVerbas.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbas.Api
{
    public class CompradorApi
    {
        public static RetornoApi List(CompradorViewModel filtro)
        {
            RetornoApi retorno = new RetornoApi();

            try
            {
                RetornoApi retornoPost = RestApi.Post(string.Format("/Comprador/list"), filtro);
                if (!retornoPost.Sucesso)
                {
                    return retornoPost;
                }
                List<CompradorViewModel> listResult = JsonConvert.DeserializeObject<List<CompradorViewModel>>((string)retornoPost.Resultado);

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