using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Marketing.GestaoVerbas.ViewModel;
using Marketing.GestaoVerbas.Core.Grid;
using Marketing.GestaoVerbas.Api;
using System.Text.RegularExpressions;
using System.IO;
using System.Web.Hosting;
using System.Text;
using System.Net;

namespace Marketing.GestaoVerbas.Controllers
{
    public class RelVerbasEmitidasController : Controller
    {
        // GET: Relatorios
        public ActionResult Index()
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("6"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            GridSetings<ViewModel.RelatoriosVerbasEmitidasViewModel> gridSetings = new GridSetings<RelatoriosVerbasEmitidasViewModel>();
            gridSetings.Filtro = new RelatoriosVerbasEmitidasViewModel();

            //Atriuir os valores padrão de filtro.
            gridSetings.Filtro.DtCadastroCarimboInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            gridSetings.Filtro.DtCadastroCarimboFim = DateTime.Now;
            gridSetings.Filtro.DtAprovacaoNegociacaoInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            gridSetings.Filtro.DtAprovacaoNegociacaoFim = DateTime.Now;
            gridSetings.Filtro.CodStatusNegociacao = 3;

            gridSetings.Result = new List<RelatoriosVerbasEmitidasViewModel>();

            gridSetings.Setings = new Setings();
            gridSetings.Setings.Column = "DtCadastroCarimbo"; //define ordem Padrão de ordenação
            gridSetings.Setings.Way = "desc";
            gridSetings.Setings.CurrentPage = 1;
            gridSetings.Setings.PageSize = 10;
            gridSetings.Setings.TotalRows = 0;
            gridSetings.Setings.CurrentPageSize = 0;

            RetornoApi retornoApi = CompradorApi.List(new CompradorViewModel());
            if (retornoApi.Sucesso)
            {
                List<CompradorViewModel> compradores = retornoApi.Resultado as List<CompradorViewModel>;
                ViewBag.Compradores = compradores.OrderBy(p => p.NomComprador);
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
                ViewBag.Compradores = new List<CompradorViewModel>();
            }

            RetornoApi retornoApi0 = DiretoriaApi.List(new DiretoriaViewModel());
            if (retornoApi0.Sucesso)
            {
                List<DiretoriaViewModel> diretoria = retornoApi0.Resultado as List<DiretoriaViewModel>;
                ViewBag.Diretoria = diretoria.OrderBy(p => p.NomDiretoria);
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi0);
                ViewBag.Diretoria = new List<DiretoriaViewModel>();
            }

            

            RetornoApi retornoApi2 = CelulaApi.ListLookup();
            if (retornoApi2.Sucesso)
            {
                List<CelulaViewModel> celulas = retornoApi2.Resultado as List<CelulaViewModel>;
                ViewBag.Celulas = celulas.OrderBy(p => p.NomCelula);
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
                ViewBag.Celulas = new List<CelulaViewModel>();
            }

            RetornoApi retornoApi3 = FilialEmpresaApi.ListLookup();
            if (retornoApi3.Sucesso)
            {
                List<FilialEmpresaViewModel> filiais = retornoApi3.Resultado as List<FilialEmpresaViewModel>;
                ViewBag.Filiais = filiais.OrderBy(p => p.CodFilialEmpresa);
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
                ViewBag.Filiais = new List<FilialEmpresaViewModel>();
            }


            return View(gridSetings);
        }

        [HttpPost]
        public ActionResult Pesquisar(GridSetings<RelatoriosVerbasEmitidasViewModel> gridSetings)
        {

            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("6"))
            {
                return RedirectToAction("HTTP403", "Error");
            }


            RetornoApi retornoApi = null;
            if (gridSetings == null)
            {
                gridSetings.Filtro = new ViewModel.RelatoriosVerbasEmitidasViewModel();
                gridSetings.Result = new List<ViewModel.RelatoriosVerbasEmitidasViewModel>();
            }
            else
            {
                switch (gridSetings.Filtro.IndRelVisao)
                {
                    case "N":
                        retornoApi = RelatoriosVerbasEmitidasApi.PorNegociacaoVerba(gridSetings);
                        break;
                    case "E":
                        retornoApi = RelatoriosVerbasEmitidasApi.PorNegociacaoVerbaEmpenho(gridSetings);
                        break;
                    case "M":
                        retornoApi = RelatoriosVerbasEmitidasApi.PorCarrimboMercadoria(gridSetings);
                        break;
                    case "F":
                        retornoApi = RelatoriosVerbasEmitidasApi.PorCarrimboFornecedor(gridSetings);
                        break;
                }

                if (retornoApi.Sucesso)
                {
                    gridSetings = (GridSetings<RelatoriosVerbasEmitidasViewModel>)retornoApi.Resultado;
                }
                else
                {
                    gridSetings.Result = new List<RelatoriosVerbasEmitidasViewModel>();
                    Util.PreencheTempDataAlerta(this, retornoApi);
                }
                if (gridSetings.Result.Count == 0)
                    Util.PreencheTempDataAlerta(this, Core.Message.Constantes.NENHUM_REGISTRO_ENCONTRADO, "Atenção", "info");
            }



            retornoApi = CompradorApi.List(new CompradorViewModel());
            if (retornoApi.Sucesso)
            {
                List<CompradorViewModel> compradores = retornoApi.Resultado as List<CompradorViewModel>;
                ViewBag.Compradores = compradores.OrderBy(p => p.NomComprador);
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
                ViewBag.Compradores = new List<CompradorViewModel>();
            }

            RetornoApi retornoApi0 = DiretoriaApi.List(new DiretoriaViewModel());
            if (retornoApi0.Sucesso)
            {
                List<DiretoriaViewModel> diretoria = retornoApi0.Resultado as List<DiretoriaViewModel>;
                ViewBag.Diretoria = diretoria.OrderBy(p => p.NomDiretoria);
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi0);
                ViewBag.Diretoria = new List<CompradorViewModel>();
            }

            RetornoApi retornoApi2 = FilialEmpresaApi.ListLookup();
            if (retornoApi.Sucesso)
            {
                List<FilialEmpresaViewModel> filiais = retornoApi2.Resultado as List<FilialEmpresaViewModel>;
                ViewBag.Filiais = filiais.OrderBy(p => p.CodFilialEmpresa);
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
                ViewBag.Filiais = new List<FilialEmpresaViewModel>();
            }

            RetornoApi retornoApi3 = CelulaApi.ListLookup();
            if (retornoApi3.Sucesso)
            {
                List<CelulaViewModel> celulas = retornoApi3.Resultado as List<CelulaViewModel>;
                ViewBag.Celulas = celulas.OrderBy(p => p.NomCelula);
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
                ViewBag.Celulas = new List<CelulaViewModel>();
            }

            return PartialView("~/Views/RelVerbasEmitidas/index.cshtml", gridSetings);
        }

        [HttpPost]
        public ActionResult ExportarRelatorioCSV(GridSetings<RelatoriosVerbasEmitidasViewModel> gridSetings)
        {

            if (!Util.VerificaMenuUsuario("6"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            //Consulta 
            RetornoApi retornoApi = null;
            switch (gridSetings.Filtro.IndRelVisao)
            {
                case "N":
                    retornoApi = RelatoriosVerbasEmitidasApi.PorNegociacaoVerba(gridSetings);
                    break;
                case "E":
                    retornoApi = RelatoriosVerbasEmitidasApi.PorNegociacaoVerbaEmpenho(gridSetings);
                    break;
                case "M":
                    retornoApi = RelatoriosVerbasEmitidasApi.PorCarrimboMercadoria(gridSetings);
                    break;
                case "F":
                    retornoApi = RelatoriosVerbasEmitidasApi.PorCarrimboFornecedor(gridSetings);
                    break;

            }

            if (retornoApi.Sucesso)
            {
                gridSetings = (GridSetings<RelatoriosVerbasEmitidasViewModel>)retornoApi.Resultado;

                string handle = Guid.NewGuid().ToString();

                if (gridSetings.Filtro.IndRelVisao == "N")
                {

                    TempData[handle] = (new Core.CSV<RelatoriosVerbasEmitidasViewModel>()).ConvertCSV(gridSetings.Result
                                            , new string[] { "NomDiretoria"
                                                           , "NomCelula"
                                                           , "NomComprador"
                                                           , "CodNegociacaoVerba"
                                                           , "NomNegociacaoVerba"
                                                           , "NomStatusNegociacao"
                                                           , "DtAprovacaoNegociacao"
                                                           , "CodFornecedor"
                                                           , "NomFornecedor"
                                                           , "CodFilialEmpresa"
                                                           , "NomFilialEmpresa"
                                                           , "VlrVerbaNegociacao"
                                                           , "DesObservacaoSolicitacao"
                                                           }
                                        );


                }
                if (gridSetings.Filtro.IndRelVisao == "E")
                {
                    TempData[handle] = (new Core.CSV<RelatoriosVerbasEmitidasViewModel>()).ConvertCSV(gridSetings.Result
                                           , new string[] { "NomDiretoria"
                                                          , "NomCelula"
                                                          , "NomComprador"
                                                          , "CodNegociacaoVerba"
                                                          , "NomNegociacaoVerba"
                                                          , "NomStatusNegociacao"
                                                          , "DtAprovacaoNegociacao"
                                                          , "NomDestino"
                                                          , "NomObjetivo"
                                                          , "NomDestinoObjetivo"
                                                          , "CodFornecedor"
                                                          , "NomFornecedor"
                                                          , "CodCarimbo"
                                                          , "CodAcordo"
                                                          , "CodFilialEmpresa"
                                                          , "NomFilialEmpresa"
                                                          , "VlrVerbaEmpenho"
                                                          , "DesObservacaoSolicitacaoEmpenho"
                                                            }
                                         );

                }
                if (gridSetings.Filtro.IndRelVisao == "M")
                {
                    TempData[handle] = (new Core.CSV<RelatoriosVerbasEmitidasViewModel>()).ConvertCSV(gridSetings.Result
                                           , new string[] { "CodMercadoria"
                                                          , "NomMercadoria"
                                                          , "NomDestinoObjetivo"
                                                          , "DesEntidade"
                                                          , "CodCarimbo"
                                                          , "NomStatusCarimbo"
                                                          , "DtCadastroCarimbo"
                                                          , "CodFilialEmpresa"
                                                          , "NomFilialEmpresa"
                                                          , "VlrCarimboMercadoria"
                                                          , "DesObservacaoCarimbo"
                                                           }
                                       );

                }
                if (gridSetings.Filtro.IndRelVisao == "F")
                {
                    TempData[handle] = (new Core.CSV<RelatoriosVerbasEmitidasViewModel>()).ConvertCSV(gridSetings.Result
                                            , new string[] { "CodFornecedor"
                                                           , "NomFornecedor"
                                                           , "NomDestinoObjetivo"
                                                           , "DesEntidade"
                                                           , "CodCarimbo"
                                                           , "NomStatusCarimbo"
                                                           , "DtCadastroCarimbo"
                                                           , "VlrCarimbo"
                                                           , "DesObservacaoCarimbo"
                                                           }
                                        );
                }

                return new JsonResult()
                {
                    Data = new { FileGuid = handle, FileName = "Relatório de Verbas Emitidas.csv" }
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

                byte[] byteArray = Encoding.Default.GetBytes(data); //Convert.FromBase64String(data);
                return File(byteArray, "application/csv", fileName);
            }
            else
            {
                // Problem - Log the error, generate a blank file,
                //           redirect to another controller action - whatever fits with your application
                return new EmptyResult();
            }
        }
    }
}