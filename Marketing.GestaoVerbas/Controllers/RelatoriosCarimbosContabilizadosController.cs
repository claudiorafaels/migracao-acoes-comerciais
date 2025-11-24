using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Marketing.GestaoVerbas.ViewModel;
using Marketing.GestaoVerbas.ViewModel.RelatoriosCarimbosContabilizados;
using Marketing.GestaoVerbas.Core.Grid;
using Marketing.GestaoVerbas.Api;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace Marketing.GestaoVerbas.Controllers
{
    public class RelatoriosCarimbosContabilizadosController : Controller
    {
        // GET: RelatoriosCarimbocContabilizados
        public ActionResult Index()
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            GridSetings<FiltrosRelatoriosCarimbosContabilizados> gridSetings = new GridSetings<FiltrosRelatoriosCarimbosContabilizados>();
            gridSetings.Filtro = new FiltrosRelatoriosCarimbosContabilizados();

            //Atriuir os valores padrão de filtro.
            gridSetings.Filtro.DtInicioAcordo = DateTime.Now.AddDays(-7);
            gridSetings.Filtro.DtFimAcordo = DateTime.Now;
            gridSetings.Filtro.DtInicioRecebidos = DateTime.Now.AddDays(-7);
            gridSetings.Filtro.DtFimRecebidos = DateTime.Now;
            gridSetings.Filtro.IndRelVisao = "Receber";

            gridSetings.Result = new List<FiltrosRelatoriosCarimbosContabilizados>();

            gridSetings.Setings = new Setings();
            gridSetings.Setings.Column = "CodFornecedor"; //define ordem Padrão de ordenação
            gridSetings.Setings.Way = "desc";
            gridSetings.Setings.CurrentPage = 1;
            gridSetings.Setings.PageSize = 10;
            gridSetings.Setings.TotalRows = 0;
            gridSetings.Setings.CurrentPageSize = 0;

            RetornoApi retornoApi = AnoMesReferenciaApi.ListAnoMesReferencia();
            if (retornoApi.Sucesso)
            {
                ViewBag.ListAnoMesReferencia = (retornoApi.Resultado as List<AnoMesReferencia>);
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
                ViewBag.ListAnoMesReferencia = new List<AnoMesReferencia>();
            }

            RetornoApi retornoApi2 = DestinoObjetivoApi.ListObjetivos();
            if (retornoApi.Sucesso)
            {
                ViewBag.ListObjetivos = (retornoApi2.Resultado as List<DestinoObjetivoViewModel>);
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
                ViewBag.ListObjetivos = new List<DestinoObjetivoViewModel>();
            }

            return View(gridSetings);
        }

        [HttpPost]
        public ActionResult Pesquisar(GridSetings<FiltrosRelatoriosCarimbosContabilizados> gridSetings)
        {

            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            RetornoApi retornoApi = null;

            switch (gridSetings.Filtro.IndRelVisao)
            {
                case "Receber":
                    if (gridSetings.Filtro.IndAnaliticoSintetico == "Analitico")
                    {
                        retornoApi = RelatoriosCarimbosContabilizadosApi.AReceberAnalitico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<ValoresReceberAnalitico> gridSetingsReceberAnalitico = (GridSetings<ValoresReceberAnalitico>)retornoApi.Resultado;

                            if (gridSetingsReceberAnalitico.Result.Count == 0)
                                Util.PreencheTempDataAlerta(this, Core.Message.Constantes.NENHUM_REGISTRO_ENCONTRADO, "Atenção", "info");

                            return PartialView("~/Views/RelatoriosCarimbosContabilizados/gridValoresAReceberAnalitico.cshtml", gridSetingsReceberAnalitico);
                        }
                    }
                    else if (gridSetings.Filtro.IndAnaliticoSintetico == "Sintetico")
                    {
                        retornoApi = RelatoriosCarimbosContabilizadosApi.AReceberSintetico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<ValoresReceberSintetico> gridSetingsReceberSintetico = (GridSetings<ValoresReceberSintetico>)retornoApi.Resultado;

                            if (gridSetingsReceberSintetico.Result.Count == 0)
                                Util.PreencheTempDataAlerta(this, Core.Message.Constantes.NENHUM_REGISTRO_ENCONTRADO, "Atenção", "info");

                            return PartialView("~/Views/RelatoriosCarimbosContabilizados/gridValoresAReceberSintetico.cshtml", gridSetingsReceberSintetico);
                        }
                    }
                    break;
                case "Recebidos":
                    if (gridSetings.Filtro.IndAnaliticoSintetico == "Analitico")
                    {
                        retornoApi = RelatoriosCarimbosContabilizadosApi.RecebidosAnalitico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<ValoresRecebidosAnalitico> gridSetingsRecebidosAnalitico = (GridSetings<ValoresRecebidosAnalitico>)retornoApi.Resultado;

                            if (gridSetingsRecebidosAnalitico.Result.Count == 0)
                                Util.PreencheTempDataAlerta(this, Core.Message.Constantes.NENHUM_REGISTRO_ENCONTRADO, "Atenção", "info");

                            return PartialView("~/Views/RelatoriosCarimbosContabilizados/gridValoresRecebidosAnalitico.cshtml", gridSetingsRecebidosAnalitico);
                        }
                    }
                    else if (gridSetings.Filtro.IndAnaliticoSintetico == "Sintetico")
                    {
                        retornoApi = RelatoriosCarimbosContabilizadosApi.RecebidosSintetico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<ValoresRecebidosSintetico> gridSetingsRecebidosSintetico = (GridSetings<ValoresRecebidosSintetico>)retornoApi.Resultado;

                            if (gridSetingsRecebidosSintetico.Result.Count == 0)
                                Util.PreencheTempDataAlerta(this, Core.Message.Constantes.NENHUM_REGISTRO_ENCONTRADO, "Atenção", "info");

                            return PartialView("~/Views/RelatoriosCarimbosContabilizados/gridValoresRecebidosSintetico.cshtml", gridSetingsRecebidosSintetico);
                        }
                    }
                    break;
                case "Novos":
                    if (gridSetings.Filtro.IndAnaliticoSintetico == "Analitico")
                    {
                        retornoApi = RelatoriosCarimbosContabilizadosApi.NovosAcordosAnalitico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<NovosAcordosAnalitico> gridSetingsNovosAnalitico = (GridSetings<NovosAcordosAnalitico>)retornoApi.Resultado;

                            if (gridSetingsNovosAnalitico.Result.Count == 0)
                                Util.PreencheTempDataAlerta(this, Core.Message.Constantes.NENHUM_REGISTRO_ENCONTRADO, "Atenção", "info");

                            return PartialView("~/Views/RelatoriosCarimbosContabilizados/gridNovosAcordosAnalitico.cshtml", gridSetingsNovosAnalitico);
                        }
                    }
                    else if (gridSetings.Filtro.IndAnaliticoSintetico == "Sintetico")
                    {
                        retornoApi = RelatoriosCarimbosContabilizadosApi.NovosAcordosSintetico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<NovosAcordosSintetico> gridSetingsNovosSintetico = (GridSetings<NovosAcordosSintetico>)retornoApi.Resultado;

                            if (gridSetingsNovosSintetico.Result.Count == 0)
                                Util.PreencheTempDataAlerta(this, Core.Message.Constantes.NENHUM_REGISTRO_ENCONTRADO, "Atenção", "info");

                            return PartialView("~/Views/RelatoriosCarimbosContabilizados/gridNovosAcordosSintetico.cshtml", gridSetingsNovosSintetico);
                        }
                    }
                    break;
                case "Cancelados":
                    if (gridSetings.Filtro.IndAnaliticoSintetico == "Analitico")
                    {
                        retornoApi = RelatoriosCarimbosContabilizadosApi.AcordosCanceladosAnalitico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<AcordosCanceladosAnalitico> gridSetingsCanceladosAnalitico = (GridSetings<AcordosCanceladosAnalitico>)retornoApi.Resultado;

                            if (gridSetingsCanceladosAnalitico.Result.Count == 0)
                                Util.PreencheTempDataAlerta(this, Core.Message.Constantes.NENHUM_REGISTRO_ENCONTRADO, "Atenção", "info");

                            return PartialView("~/Views/RelatoriosCarimbosContabilizados/gridAcordosCanceladosAnalitico.cshtml", gridSetingsCanceladosAnalitico);
                        }
                    }
                    else if (gridSetings.Filtro.IndAnaliticoSintetico == "Sintetico")
                    {
                        retornoApi = RelatoriosCarimbosContabilizadosApi.AcordosCanceladosSintetico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<AcordosCanceladosSintetico> gridSetingsAcordosCanceladosSintetico = (GridSetings<AcordosCanceladosSintetico>)retornoApi.Resultado;

                            if (gridSetingsAcordosCanceladosSintetico.Result.Count == 0)
                                Util.PreencheTempDataAlerta(this, Core.Message.Constantes.NENHUM_REGISTRO_ENCONTRADO, "Atenção", "info");

                            return PartialView("~/Views/RelatoriosCarimbosContabilizados/gridAcordosCanceladosSintetico.cshtml", gridSetingsAcordosCanceladosSintetico);
                        }
                    }
                    break;
                default:
                    return RedirectToAction("Index", "RelatoriosCarimbosContabilizados");
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
        public ActionResult ExportarRelatorioCSV(GridSetings<FiltrosRelatoriosCarimbosContabilizados> gridSetings)
        {
            //Consulta 
            string handle = Guid.NewGuid().ToString();

            RetornoApi retornoApi = new RetornoApi() { Sucesso = false };

            switch (gridSetings.Filtro.IndRelVisao)
            {
                case "Receber":
                    if (gridSetings.Filtro.IndAnaliticoSintetico == "Analitico")
                    {
                        retornoApi = RelatoriosCarimbosContabilizadosApi.AReceberAnalitico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<ValoresReceberAnalitico> gridSetingsReceberAnalitico = (GridSetings<ValoresReceberAnalitico>)retornoApi.Resultado;

                            TempData[handle] = (new Core.CSV<ValoresReceberAnalitico>()).ConvertCSV(gridSetingsReceberAnalitico.Result);
                        }
                    }
                    else if (gridSetings.Filtro.IndAnaliticoSintetico == "Sintetico")
                    {
                        retornoApi = RelatoriosCarimbosContabilizadosApi.AReceberSintetico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<ValoresReceberSintetico> gridSetingsReceberSintetico = (GridSetings<ValoresReceberSintetico>)retornoApi.Resultado;

                            TempData[handle] = (new Core.CSV<ValoresReceberSintetico>()).ConvertCSV(gridSetingsReceberSintetico.Result);
                        }
                    }
                    break;
                case "Recebidos":
                    if (gridSetings.Filtro.IndAnaliticoSintetico == "Analitico")
                    {
                        retornoApi = RelatoriosCarimbosContabilizadosApi.RecebidosAnalitico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<ValoresRecebidosAnalitico> gridSetingsRecebidosAnalitico = (GridSetings<ValoresRecebidosAnalitico>)retornoApi.Resultado;

                            TempData[handle] = (new Core.CSV<ValoresRecebidosAnalitico>()).ConvertCSV(gridSetingsRecebidosAnalitico.Result);
                        }
                    }
                    else if (gridSetings.Filtro.IndAnaliticoSintetico == "Sintetico")
                    {
                        retornoApi = RelatoriosCarimbosContabilizadosApi.RecebidosSintetico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<ValoresRecebidosSintetico> gridSetingsRecebidosSintetico = (GridSetings<ValoresRecebidosSintetico>)retornoApi.Resultado;

                            TempData[handle] = (new Core.CSV<ValoresRecebidosSintetico>()).ConvertCSV(gridSetingsRecebidosSintetico.Result);
                        }
                    }
                    break;
                case "Novos":
                    if (gridSetings.Filtro.IndAnaliticoSintetico == "Analitico")
                    {

                        retornoApi = RelatoriosCarimbosContabilizadosApi.NovosAcordosAnalitico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<NovosAcordosAnalitico> gridSetingsNovosAnalitico = (GridSetings<NovosAcordosAnalitico>)retornoApi.Resultado;

                            TempData[handle] = (new Core.CSV<NovosAcordosAnalitico>()).ConvertCSV(gridSetingsNovosAnalitico.Result);
                        }
                    }
                    else if (gridSetings.Filtro.IndAnaliticoSintetico == "Sintetico")
                    {
                        retornoApi = RelatoriosCarimbosContabilizadosApi.NovosAcordosSintetico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<NovosAcordosSintetico> gridSetingsNovosSintetico = (GridSetings<NovosAcordosSintetico>)retornoApi.Resultado;


                            TempData[handle] = (new Core.CSV<NovosAcordosSintetico>()).ConvertCSV(gridSetingsNovosSintetico.Result);
                        }
                    }
                    break;
                case "Cancelados":
                    if (gridSetings.Filtro.IndAnaliticoSintetico == "Analitico")
                    {
                        retornoApi = RelatoriosCarimbosContabilizadosApi.AcordosCanceladosAnalitico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<AcordosCanceladosAnalitico> gridSetingsCanceladosAnalitico = (GridSetings<AcordosCanceladosAnalitico>)retornoApi.Resultado;

                            TempData[handle] = (new Core.CSV<AcordosCanceladosAnalitico>()).ConvertCSV(gridSetingsCanceladosAnalitico.Result);
                        }
                    }
                    else if (gridSetings.Filtro.IndAnaliticoSintetico == "Sintetico")
                    {
                        retornoApi = RelatoriosCarimbosContabilizadosApi.AcordosCanceladosSintetico(gridSetings);
                        if (retornoApi.Sucesso)
                        {
                            GridSetings<AcordosCanceladosSintetico> gridSetingsAcordosCanceladosSintetico = (GridSetings<AcordosCanceladosSintetico>)retornoApi.Resultado;

                            TempData[handle] = (new Core.CSV<AcordosCanceladosSintetico>()).ConvertCSV(gridSetingsAcordosCanceladosSintetico.Result);
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
                    Data = new { FileGuid = handle, FileName = "Relatório de Carimbos Contabilizados.csv" }
                };
            }

            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        }


        [HttpGet]
        public virtual ActionResult Download(string fileGuid, string fileName)
        {
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