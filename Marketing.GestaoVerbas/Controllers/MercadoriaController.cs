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
    public class MercadoriaController : Controller
    {


        [HttpPost]
        public ActionResult Pesquisar(GridSetings<ViewModel.MercadoriaViewModel> gridSetings)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (gridSetings.Filtro == null)
            {
                gridSetings.Filtro = new ViewModel.MercadoriaViewModel();
                gridSetings.Result = new List<ViewModel.MercadoriaViewModel>();
            }
            else if (gridSetings.Filtro.CodMercadoria != null || !string.IsNullOrEmpty(gridSetings.Filtro.NomMercadoria))
            {
                RetornoApi retornoApi = MercadoriaApi.List(gridSetings);
                if (retornoApi.Sucesso)
                {
                    gridSetings = (GridSetings<MercadoriaViewModel>)retornoApi.Resultado;
                }
                else
                {
                    gridSetings.Result = new List<MercadoriaViewModel>();
                    Util.PreencheTempDataAlerta(this, retornoApi);
                }
                if (gridSetings.Result.Count == 0)
                    Util.PreencheTempDataAlerta(this, Core.Message.Constantes.NENHUM_REGISTRO_ENCONTRADO, "Atenção", "info");
            }
            else
            {
                Util.PreencheTempDataAlerta(this, Core.Message.Constantes.INFORME_FILTRO, "Atenção", "info");

                gridSetings.Filtro = new ViewModel.MercadoriaViewModel();
                gridSetings.Result = new List<ViewModel.MercadoriaViewModel>();
            }        

            return PartialView("~/Views/Mercadoria/findMercadoria.cshtml", gridSetings);
        }

        [HttpGet]
        public string Select(int codigo)
        {
            if (!Util.ValidaSessao())
            {
                return "";
            }

            GridSetings<ViewModel.MercadoriaViewModel> gridSetings = new GridSetings<MercadoriaViewModel>();
            gridSetings.Filtro = new MercadoriaViewModel();

            gridSetings.Filtro.CodMercadoria = codigo;
            gridSetings.Setings = new Setings();

            gridSetings.Setings.Column = "NomMercadoria";
            gridSetings.Setings.Way = "asc";
            gridSetings.Setings.PageSize = 10;
            gridSetings.Setings.CurrentPage = 1;


            RetornoApi retornoApi = MercadoriaApi.List(gridSetings);
            if (retornoApi.Sucesso)
            {
                gridSetings = (GridSetings<MercadoriaViewModel>)retornoApi.Resultado;
            }
            else
            {
                gridSetings.Result = new List<MercadoriaViewModel>();
                Util.PreencheTempDataAlerta(this, retornoApi);
            }


            if (gridSetings.Result.Count == 0)
                return "Mercadoria não encontrada!";
            else
                return gridSetings.Result.First().NomMercadoria;
        }
    }
}
