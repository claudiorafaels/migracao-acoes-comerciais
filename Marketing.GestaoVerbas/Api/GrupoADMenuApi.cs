using Marketing.GestaoVerbas.Core.Grid;
using Marketing.GestaoVerbas.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Marketing.GestaoVerbas.Api
{
    public class GrupoADMenuApi
    {
        class MenuUpdate
        {
            public string CodMenu { get; set; }
            public string NomMenu { get; set; }
            public string DesIconeMenu { get; set; }
            public string DesLocalAplicacaoMenu { get; set; }
            public string CodMenuPai { get; set; }
            public int InAssociado { get; set; }
            public int CodGrupoAcesso { get; set; }

        }

        public static RetornoApi UpdateList(int CodGrupoAcesso, List<MenuViewModel> menuList)
        {
            RetornoApi retorno = new RetornoApi();
            try
            {
                List<MenuUpdate> list = new List<MenuUpdate>();
                foreach (var item in menuList)
                {
                    list.Add(new MenuUpdate()
                    {
                        CodGrupoAcesso = CodGrupoAcesso,
                        CodMenu = item.CodMenu
                    });
                }

                RetornoApi retornoApi = RestApi.Patch(string.Format("/grupoadmenu/{0}/updatelist", CodGrupoAcesso), list);
                if (!retornoApi.Sucesso)
                {
                    return retornoApi;
                }
                retorno.Resultado = JsonConvert.DeserializeObject<GrupoADViewModel>((string)retornoApi.Resultado);
            }
            catch (Exception ex)
            {
                retorno.SetaExcecao(ex);
            }

            return retorno;
        }

    }
}