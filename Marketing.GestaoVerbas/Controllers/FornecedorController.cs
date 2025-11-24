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
    public class FornecedorController : Controller
    {

        [HttpPost]
        public ActionResult Pesquisar(GridSetings<ViewModel.FornecedorViewModel> gridSetings)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (gridSetings.Filtro == null)
            {
                gridSetings.Filtro = new ViewModel.FornecedorViewModel();
                gridSetings.Result = new List<ViewModel.FornecedorViewModel>();
            }
            else if (gridSetings.Filtro.CodFornecedor != null || !string.IsNullOrEmpty(gridSetings.Filtro.NomFornecedor))
            {
                RetornoApi retornoApi = FornecedorApi.List(gridSetings);
                if (retornoApi.Sucesso)
                {
                    gridSetings = (GridSetings<FornecedorViewModel>)retornoApi.Resultado;
                }
                else
                {
                    gridSetings.Result = new List<FornecedorViewModel>();
                    Util.PreencheTempDataAlerta(this, retornoApi);
                }
                if (gridSetings.Result.Count == 0)
                    Util.PreencheTempDataAlerta(this, Core.Message.Constantes.NENHUM_REGISTRO_ENCONTRADO, "Atenção", "info");
            }
            else
            {
                Util.PreencheTempDataAlerta(this, Core.Message.Constantes.INFORME_FILTRO, "Atenção", "info");

                gridSetings.Filtro = new ViewModel.FornecedorViewModel();
                gridSetings.Result = new List<ViewModel.FornecedorViewModel>();
            }         

            return PartialView("~/Views/Fornecedor/findFornecedor.cshtml", gridSetings);
        }

        [HttpGet]
        public string Select(int codigo)
        {
            if (!Util.ValidaSessao())
            {
                return "";
            }

            GridSetings<ViewModel.FornecedorViewModel> gridSetings = new GridSetings<FornecedorViewModel>();
            gridSetings.Filtro = new FornecedorViewModel();

            gridSetings.Filtro.CodFornecedor = codigo;
            gridSetings.Setings = new Setings();

            gridSetings.Setings.Column = "NomFornecedor";
            gridSetings.Setings.Way = "asc";
            gridSetings.Setings.PageSize =  10;
            gridSetings.Setings.CurrentPage = 1;
            

            RetornoApi retornoApi = FornecedorApi.List(gridSetings);
            if (retornoApi.Sucesso)
            {
                gridSetings = (GridSetings<FornecedorViewModel>)retornoApi.Resultado;
            }
            else
            {
                gridSetings.Result = new List<FornecedorViewModel>();
                Util.PreencheTempDataAlerta(this, retornoApi);
            }


            if (gridSetings.Result.Count == 0)
                return "Fornecedor não encontrado!";
            else
                return gridSetings.Result.First().NomFornecedor;
        }
    }
}