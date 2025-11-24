using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marketing.GestaoVerbas.ViewModel;
using Marketing.GestaoVerbas.Core;
using Marketing.GestaoVerbas.Core.Grid;
using Marketing.GestaoVerbas.Api;
using System.Net;
using Newtonsoft.Json;

namespace Marketing.GestaoVerbas.Controllers
{
    public class GrupoADController : Controller
    {
        // GET: GrupoAD
        [HttpGet]
        public ActionResult Index()
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("9"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            GridSetings<ViewModel.GrupoADViewModel> gridSetings = new GridSetings<GrupoADViewModel>();
            gridSetings.Filtro = new GrupoADViewModel();
            //Atriuir os valores padrão de filtro.

            gridSetings.Result = new List<GrupoADViewModel>();

            gridSetings.Setings = new Setings();
            gridSetings.Setings.Column = "NomGrupoAcesso"; //define ordem Padrão de ordenação
            gridSetings.Setings.Way = "asc";
            gridSetings.Setings.CurrentPage = 1;
            gridSetings.Setings.PageSize = 10;
            gridSetings.Setings.TotalRows = 0;
            gridSetings.Setings.CurrentPageSize = 0;



            return View(gridSetings);
        }

        [HttpPost]
        public ActionResult Pesquisar(GridSetings<ViewModel.GrupoADViewModel> gridSetings)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("9"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            if (gridSetings.Filtro == null)
            {
                gridSetings.Filtro = new ViewModel.GrupoADViewModel();
                gridSetings.Result = new List<ViewModel.GrupoADViewModel>();
            }
            else
            {
                RetornoApi retornoApiPs = GrupoADApi.List(gridSetings);
                if (retornoApiPs.Sucesso)
                {
                    gridSetings = (GridSetings<GrupoADViewModel>)retornoApiPs.Resultado;
                }
                else
                {
                    gridSetings.Result = new List<GrupoADViewModel>();
                    Util.PreencheTempDataAlerta(this, retornoApiPs);
                }
            }

            if (gridSetings.Result.Count == 0)
                Util.PreencheTempDataAlerta(this, Core.Message.Constantes.NENHUM_REGISTRO_ENCONTRADO, "Atenção", "info");


            return PartialView("~/Views/GrupoAD/index.cshtml", gridSetings);
        }

        [HttpPost]
        public ActionResult NovoGrupoAD()
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("9"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            GrupoADViewModel grupoViewModel = new GrupoADViewModel();

            return PartialView("~/Views/GrupoAD/edit.cshtml", grupoViewModel);
        }

        [HttpPost]
        public ActionResult EditarGrupoAD(int pCodGrupoAD)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("9"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            GrupoADViewModel obj = new GrupoADViewModel();
            RetornoApi retornoApi = GrupoADApi.Select(pCodGrupoAD);
            if (retornoApi.Sucesso)
            {
                obj = (GrupoADViewModel)retornoApi.Resultado;
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
            }

            //obj.Destinos = new List<NegociacaoVerbaDestinoViewModel>();
            //retornoApi = NegociacaoVerbaDestinoApi.ListPorNegociacao(pCodNegociacaoVerba);
            //if (retornoApi.Sucesso)
            //{
            //    obj.Destinos = (List<NegociacaoVerbaDestinoViewModel>)retornoApi.Resultado;
            //}
            //else
            //{
            //    Util.PreencheTempDataAlerta(this, retornoApi);
            //}



            return PartialView("~/Views/GrupoAD/edit.cshtml", obj);
        }


        [HttpPost]
        public ActionResult SalvarGrupoAD(GrupoADViewModel obj)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("9"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            if (obj.CodGrupoAcesso == null)
            {
                RetornoApi retornoApi = GrupoADApi.Insert(obj);
                if (retornoApi.Sucesso)
                {
                    obj = retornoApi.Resultado as GrupoADViewModel;

                    return EditarGrupoAD(obj.CodGrupoAcesso.Value);
                }
                else
                {
                    Util.PreencheTempDataAlerta(this, retornoApi);
                }
            }
            else
            {
                RetornoApi retornoApi = GrupoADApi.Update(obj);
                if (retornoApi.Sucesso)
                {
                    bool? status = retornoApi.Resultado as bool?;
                    if (status != true)
                    {
                        Util.PreencheTempDataAlerta(this, "Erro ao Salvar as alterações!");
                    }
                    //else
                    //{
                    //    return EditarGrupoAD(obj.CodGrupoAcesso.Value);
                    //}
                }
                else
                {
                    Util.PreencheTempDataAlerta(this, retornoApi);
                }
            }

            return PartialView("~/Views/GrupoAD/edit.cshtml", obj);
        }

        [HttpPost]
        public ActionResult EditarMenu(int pCodGrupoAD)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("9"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            GrupoADViewModel obj = new GrupoADViewModel();
            RetornoApi retornoApi = GrupoADApi.Select(pCodGrupoAD);
            if (retornoApi.Sucesso)
            {
                obj = (GrupoADViewModel)retornoApi.Resultado;

            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
            }

            obj.CodMenuCorrente = "0";
            obj.ControleAcessos = new List<MenuViewModel>();
            RetornoApi retMenuApi = MenuApi.SelectPorGrupo(pCodGrupoAD);
            if (retMenuApi.Sucesso)
            {
                obj.ControleAcessos = (List<MenuViewModel>)retMenuApi.Resultado;
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retMenuApi);
            }

            return PartialView("~/Views/GrupoAD/editMenu.cshtml", obj);


        }

        [HttpPost]
        public ActionResult SalvarListaMenu(GrupoADViewModel edit)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("9"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            RetornoApi retornoApi = GrupoADMenuApi.UpdateList(edit.CodGrupoAcesso.Value, edit.ControleAcessos);
            if (retornoApi.Sucesso)
            {
                return EditarMenu(edit.CodGrupoAcesso.Value);
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
                return EditarMenu(edit.CodGrupoAcesso.Value);
            }
        }
    }
}