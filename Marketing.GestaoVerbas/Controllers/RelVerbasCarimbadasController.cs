using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Marketing.GestaoVerbas.ViewModel;
using Marketing.GestaoVerbas.ViewModel.RelatoriosVerbasCarimbadas;
using Marketing.GestaoVerbas.Core.Grid;
using Marketing.GestaoVerbas.Api;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace Marketing.GestaoVerbas.Controllers
{
    public class RelVerbasCarimbadasController : Controller
    {
        private static string CodigoMenu = "15";

        [HttpGet]
        public ActionResult Index()
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario(CodigoMenu))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            GridSetings<FiltrosRelatoriosVerbasCarimbadas> gridSetings = new GridSetings<FiltrosRelatoriosVerbasCarimbadas>();
            gridSetings.Filtro = new FiltrosRelatoriosVerbasCarimbadas();

            //Atriuir os valores padrão de filtro.
            gridSetings.Filtro.DtInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            gridSetings.Filtro.DtFim = DateTime.Now;
            gridSetings.Filtro.IndRelVisao = "Realizados";

            gridSetings.Result = new List<FiltrosRelatoriosVerbasCarimbadas>();

            gridSetings.Setings = new Setings();
            gridSetings.Setings.Column = "CodFornecedor"; //define ordem Padrão de ordenação
            gridSetings.Setings.Way = "desc";
            gridSetings.Setings.CurrentPage = 1;
            gridSetings.Setings.PageSize = 10;
            gridSetings.Setings.TotalRows = 0;
            gridSetings.Setings.CurrentPageSize = 0;

            return View(gridSetings);
        }

        [HttpPost]
        public ActionResult Pesquisar(GridSetings<FiltrosRelatoriosVerbasCarimbadas> gridSetings)
        {

            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario(CodigoMenu))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            RetornoApi retornoApi = null;

            switch (gridSetings.Filtro.IndRelVisao)
            {
                case "Realizados":
                    if (gridSetings.Filtro.IndAnaliticoSintetico == "Analitico")
                    {
                        retornoApi = RelatoriosVerbasCarimbadasApi.VerbaCarimbadaRealizadoAnalitico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<VerbasCarimbadasRealizadoAnalitico> gridSetingsRealizadoAnalitico = (GridSetings<VerbasCarimbadasRealizadoAnalitico>)retornoApi.Resultado;

                            if (gridSetingsRealizadoAnalitico.Result.Count == 0)
                                Util.PreencheTempDataAlerta(this, Core.Message.Constantes.NENHUM_REGISTRO_ENCONTRADO, "Atenção", "info");

                            return PartialView("~/Views/RelVerbasCarimbadas/gridVerbasCarimbadasRealizadoAnalitico.cshtml", gridSetingsRealizadoAnalitico);
                        }
                    }
                    else if (gridSetings.Filtro.IndAnaliticoSintetico == "Sintetico")
                    {
                        retornoApi = RelatoriosVerbasCarimbadasApi.VerbaCarimbadaRealizadoSintetico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<VerbasCarimbadasRealizadoSintetico> gridSetingsRealizadoSintetico = (GridSetings<VerbasCarimbadasRealizadoSintetico>)retornoApi.Resultado;

                            if (gridSetingsRealizadoSintetico.Result.Count == 0)
                                Util.PreencheTempDataAlerta(this, Core.Message.Constantes.NENHUM_REGISTRO_ENCONTRADO, "Atenção", "info");

                            return PartialView("~/Views/RelVerbasCarimbadas/gridVerbasCarimbadasRealizadoSintetico.cshtml", gridSetingsRealizadoSintetico);
                        }
                    }
                    break;

                case "Cancelados":
                    if (gridSetings.Filtro.IndAnaliticoSintetico == "Analitico")
                    {
                        retornoApi = RelatoriosVerbasCarimbadasApi.VerbaCarimbadaCanceladoAnalitico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<VerbasCarimbadasCanceladoAnalitico> gridSetingsCanceladosAnalitico = (GridSetings<VerbasCarimbadasCanceladoAnalitico>)retornoApi.Resultado;

                            if (gridSetingsCanceladosAnalitico.Result.Count == 0)
                                Util.PreencheTempDataAlerta(this, Core.Message.Constantes.NENHUM_REGISTRO_ENCONTRADO, "Atenção", "info");

                            return PartialView("~/Views/RelVerbasCarimbadas/gridVerbasCarimbadasCanceladoAnalitico.cshtml", gridSetingsCanceladosAnalitico);
                        }
                    }
                    else if (gridSetings.Filtro.IndAnaliticoSintetico == "Sintetico")
                    {
                        retornoApi = RelatoriosVerbasCarimbadasApi.VerbaCarimbadaCanceladoSintetico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<VerbasCarimbadasCanceladoSintetico> gridSetingsAcordosCanceladosSintetico = (GridSetings<VerbasCarimbadasCanceladoSintetico>)retornoApi.Resultado;

                            if (gridSetingsAcordosCanceladosSintetico.Result.Count == 0)
                                Util.PreencheTempDataAlerta(this, Core.Message.Constantes.NENHUM_REGISTRO_ENCONTRADO, "Atenção", "info");

                            return PartialView("~/Views/RelVerbasCarimbadas/gridVerbasCarimbadasCanceladoSintetico.cshtml", gridSetingsAcordosCanceladosSintetico);
                        }
                    }
                    break;
                default:
                    return RedirectToAction("Index", "RelatoriosVerbasCarimbadas");
            }


            if (!retornoApi.Sucesso)
            {
                //gridSetings.Result = new List<FiltrosRelatoriosCarimbosContabilizados>();
                Util.PreencheTempDataAlerta(this, retornoApi);
            }

            //TODO: ISSO esta errado, deveria retornar uma view de erro.
            return PartialView("~/Views/Shared/_Pagination.cshtml", gridSetings.Setings);
        }

        [HttpPost]
        public ActionResult ExportarRelatorioCSV(GridSetings<FiltrosRelatoriosVerbasCarimbadas> gridSetings)
        {
            if (!Util.VerificaMenuUsuario(CodigoMenu))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            //Consulta 
            string handle = Guid.NewGuid().ToString();

            RetornoApi retornoApi = new RetornoApi() { Sucesso = false };

            if (gridSetings.Setings.Column == null)
                gridSetings.Setings.Column = "CodFornecedor";
            if (gridSetings.Setings.Way == null)
                gridSetings.Setings.Way = "desc";

            switch (gridSetings.Filtro.IndRelVisao)
            {
                case "Realizados":
                    if (gridSetings.Filtro.IndAnaliticoSintetico == "Analitico")
                    {
                        retornoApi = RelatoriosVerbasCarimbadasApi.VerbaCarimbadaRealizadoAnalitico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<VerbasCarimbadasRealizadoAnalitico> gridSetingsRealizadoAnalitico = (GridSetings<VerbasCarimbadasRealizadoAnalitico>)retornoApi.Resultado;

                            TempData[handle] = (new Core.CSV<VerbasCarimbadasRealizadoAnalitico>()).ConvertCSV(gridSetingsRealizadoAnalitico.Result);
                        }
                    }
                    else if (gridSetings.Filtro.IndAnaliticoSintetico == "Sintetico")
                    {
                        retornoApi = RelatoriosVerbasCarimbadasApi.VerbaCarimbadaRealizadoSintetico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<VerbasCarimbadasRealizadoSintetico> gridSetingsRealizadoSintetico = (GridSetings<VerbasCarimbadasRealizadoSintetico>)retornoApi.Resultado;

                            TempData[handle] = (new Core.CSV<VerbasCarimbadasRealizadoSintetico>()).ConvertCSV(gridSetingsRealizadoSintetico.Result);
                        }
                    }
                    break;

                case "Cancelados":
                    if (gridSetings.Filtro.IndAnaliticoSintetico == "Analitico")
                    {
                        retornoApi = RelatoriosVerbasCarimbadasApi.VerbaCarimbadaCanceladoAnalitico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<VerbasCarimbadasCanceladoAnalitico> gridSetingsCanceladosAnalitico = (GridSetings<VerbasCarimbadasCanceladoAnalitico>)retornoApi.Resultado;

                            TempData[handle] = (new Core.CSV<VerbasCarimbadasCanceladoAnalitico>()).ConvertCSV(gridSetingsCanceladosAnalitico.Result);
                        }
                    }
                    else if (gridSetings.Filtro.IndAnaliticoSintetico == "Sintetico")
                    {
                        retornoApi = RelatoriosVerbasCarimbadasApi.VerbaCarimbadaCanceladoSintetico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<VerbasCarimbadasCanceladoSintetico> gridSetingsAcordosCanceladosSintetico = (GridSetings<VerbasCarimbadasCanceladoSintetico>)retornoApi.Resultado;

                            TempData[handle] = (new Core.CSV<VerbasCarimbadasCanceladoSintetico>()).ConvertCSV(gridSetingsAcordosCanceladosSintetico.Result);
                        }
                    }
                    break;
                default:
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

            }

            if (retornoApi.Sucesso)
            {
                return new JsonResult()
                {
                    Data = new { FileGuid = handle, FileName = "Relatório de Verbas Carimbadas.csv" }
                };
            }

            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        }


        [HttpGet]
        public virtual ActionResult Download(string fileGuid, string fileName)
        {
            if (!Util.VerificaMenuUsuario(CodigoMenu))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            if (TempData[fileGuid] != null)
            {
                string data = TempData[fileGuid] as string;

                byte[] byteArray = Encoding.Default.GetBytes(data);
                return File(byteArray, "application/csv", fileName);
            }
            else
            {
                return new EmptyResult();
            }
        }

    }
}