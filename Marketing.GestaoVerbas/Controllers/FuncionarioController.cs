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
    public class FuncionarioController : Controller
    {
        [HttpPost]
        public ActionResult Pesquisar(GridSetings<ViewModel.FuncionarioViewModel> gridSetings)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (gridSetings.Filtro == null)
            {
                gridSetings.Filtro = new ViewModel.FuncionarioViewModel();
                gridSetings.Result = new List<ViewModel.FuncionarioViewModel>();
            }
            else if (gridSetings.Filtro.CodFuncionario != null || !string.IsNullOrEmpty(gridSetings.Filtro.NomFuncionario))
            {
                RetornoApi retornoFuncionarios = FuncionarioApi.List(gridSetings);
                if (retornoFuncionarios.Sucesso)
                {
                    gridSetings = (GridSetings<FuncionarioViewModel>)retornoFuncionarios.Resultado;
                }
                else
                {
                    gridSetings.Result = new List<FuncionarioViewModel>();
                    Util.PreencheTempDataAlerta(this, retornoFuncionarios);
                }
                if (gridSetings.Result.Count == 0)
                    Util.PreencheTempDataAlerta(this, Core.Message.Constantes.NENHUM_REGISTRO_ENCONTRADO, "Atenção", "info");
            }
            else
            {
                Util.PreencheTempDataAlerta(this, Core.Message.Constantes.INFORME_FILTRO, "Atenção", "info");

                gridSetings.Filtro = new ViewModel.FuncionarioViewModel();
                gridSetings.Result = new List<ViewModel.FuncionarioViewModel>();
            }
            
            return PartialView("~/Views/Funcionario/findFuncionario.cshtml", gridSetings);
        }


        [HttpGet]
        public string Select(int codigo)
        {
            if (!Util.ValidaSessao())
            {
                return "";
            }

            GridSetings<ViewModel.FuncionarioViewModel> gridSetings = new GridSetings<FuncionarioViewModel>();
            gridSetings.Filtro = new FuncionarioViewModel();

            gridSetings.Filtro.CodFuncionario = codigo;
            gridSetings.Setings = new Setings();

            gridSetings.Setings.Column = "NomFuncionario";
            gridSetings.Setings.Way = "asc";
            gridSetings.Setings.PageSize = 10;
            gridSetings.Setings.CurrentPage = 1;


            RetornoApi retornoApi = FuncionarioApi.List(gridSetings);
            if (retornoApi.Sucesso)
            {
                gridSetings = (GridSetings<FuncionarioViewModel>)retornoApi.Resultado;
            }
            else
            {
                gridSetings.Result = new List<FuncionarioViewModel>();
                Util.PreencheTempDataAlerta(this, retornoApi);
            }


            if (gridSetings.Result.Count == 0)
                return "Funcionario não encontrado!";
            else
                return gridSetings.Result.First().NomFuncionario;
        }
    }
}