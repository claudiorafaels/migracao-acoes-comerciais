using Marketing.GestaoVerbas.Api;
using Marketing.GestaoVerbas.Core;
using Marketing.GestaoVerbas.Core.Grid;
using Marketing.GestaoVerbas.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marketing.GestaoVerbas.Controllers
{
    public class FilialEmpresaController : Controller
    {


        [HttpPost]
        public ActionResult Pesquisar(GridSetings<ViewModel.FilialEmpresaViewModel> gridSetings)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (gridSetings.Filtro == null)
            {
                gridSetings.Filtro = new ViewModel.FilialEmpresaViewModel();
                gridSetings.Result = new List<ViewModel.FilialEmpresaViewModel>();
            }
            else if (gridSetings.Filtro.CodFilialEmpresa != null || !string.IsNullOrEmpty(gridSetings.Filtro.NomFilialEmpresa))
            {
                RetornoApi retornoApi = FilialEmpresaApi.List(gridSetings);
                if (retornoApi.Sucesso)
                {
                    gridSetings = (GridSetings<FilialEmpresaViewModel>)retornoApi.Resultado;
                }
                else
                {
                    gridSetings.Result = new List<FilialEmpresaViewModel>();
                    Util.PreencheTempDataAlerta(this, retornoApi);
                }
                if (gridSetings.Result.Count == 0)
                    Util.PreencheTempDataAlerta(this, Core.Message.Constantes.NENHUM_REGISTRO_ENCONTRADO, "Atenção", "info");
            }
            else
            {
                Util.PreencheTempDataAlerta(this, Core.Message.Constantes.INFORME_FILTRO, "Atenção", "info");

                gridSetings.Filtro = new ViewModel.FilialEmpresaViewModel();
                gridSetings.Result = new List<ViewModel.FilialEmpresaViewModel>();
            }
            
            return PartialView("~/Views/FilialEmpresa/findFilialEmpresa.cshtml", gridSetings);
        }
    }
}