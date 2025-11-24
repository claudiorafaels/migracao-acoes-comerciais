
using Marketing.GestaoVerbas.Api;
using Marketing.GestaoVerbas.Core.Grid;
using Marketing.GestaoVerbas.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Marketing.GestaoVerbas.Controllers
{
    public class NegociacaoController : Controller
    {
        // GET: Negociacao
        [HttpGet]
        public ActionResult Index()
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("5"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            GridSetings<ViewModel.NegociacaoVerbaViewModel> gridSetings = new GridSetings<NegociacaoVerbaViewModel>();
            gridSetings.Filtro = new NegociacaoVerbaViewModel();
            //Atriuir os valores padrão de filtro.

            gridSetings.Result = new List<NegociacaoVerbaViewModel>();

            gridSetings.Setings = new Setings();
            gridSetings.Setings.Column = "DtCadastroNegociacao"; //define ordem Padrão de ordenação
            gridSetings.Setings.Way = "desc";
            gridSetings.Setings.CurrentPage = 1;
            gridSetings.Setings.PageSize = 10;
            gridSetings.Setings.TotalRows = 0;
            gridSetings.Setings.CurrentPageSize = 0;

            RetornoApi retornoApiIndex = CompradorApi.List(new CompradorViewModel());
            if (retornoApiIndex.Sucesso)
            {
                List<CompradorViewModel> compradores = retornoApiIndex.Resultado as List<CompradorViewModel>;
                ViewBag.Compradores = compradores.OrderBy(p => p.NomComprador);
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApiIndex);
                ViewBag.Compradores = new List<CompradorViewModel>();
            }

            RetornoApi retornoApiFilial = FilialEmpresaApi.ListLookup();
            if (retornoApiFilial.Sucesso)
            {
                List<FilialEmpresaViewModel> filiais = retornoApiFilial.Resultado as List<FilialEmpresaViewModel>;
                ViewBag.Filiais = filiais;
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApiFilial);
                ViewBag.Filiais = new List<FilialEmpresaViewModel>();
            }

            RetornoApi retornoApi2 = CelulaApi.ListLookup();
            if (retornoApi2.Sucesso)
            {
                List<CelulaViewModel> celulas = retornoApi2.Resultado as List<CelulaViewModel>;
                ViewBag.Celulas = celulas.OrderBy(p => p.NomCelula);
            }


            return View(gridSetings);
        }

        [HttpPost]
        public ActionResult Pesquisar(GridSetings<ViewModel.NegociacaoVerbaViewModel> gridSetings)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("5"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            RetornoApi retornoApiIndex = CompradorApi.List(new CompradorViewModel());
            if (retornoApiIndex.Sucesso)
            {
                List<CompradorViewModel> compradores = retornoApiIndex.Resultado as List<CompradorViewModel>;
                ViewBag.Compradores = compradores.OrderBy(p => p.NomComprador);
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApiIndex);
                ViewBag.Compradores = new List<CompradorViewModel>();
            }


            if (gridSetings.Filtro == null)
            {
                gridSetings.Filtro = new ViewModel.NegociacaoVerbaViewModel();
                gridSetings.Result = new List<ViewModel.NegociacaoVerbaViewModel>();
            }
            else
            {
                RetornoApi retornoApiPs = NegociacaoVerbaApi.List(gridSetings);
                if (retornoApiPs.Sucesso)
                {
                    gridSetings = (GridSetings<NegociacaoVerbaViewModel>)retornoApiPs.Resultado;
                }
                else
                {
                    gridSetings.Result = new List<NegociacaoVerbaViewModel>();
                    Util.PreencheTempDataAlerta(this, retornoApiPs);
                }
            }

            if (gridSetings.Result.Count == 0)
                Util.PreencheTempDataAlerta(this, Core.Message.Constantes.NENHUM_REGISTRO_ENCONTRADO, "Atenção", "info");

            RetornoApi retornoApi3 = CelulaApi.ListLookup();
            if (retornoApi3.Sucesso)
            {
                List<CelulaViewModel> celulas = retornoApi3.Resultado as List<CelulaViewModel>;
                ViewBag.Celulas = celulas.OrderBy(p => p.NomCelula);
            }

            RetornoApi retornoApiFilial = FilialEmpresaApi.ListLookup();
            if (retornoApiFilial.Sucesso)
            {
                List<FilialEmpresaViewModel> filiais = retornoApiFilial.Resultado as List<FilialEmpresaViewModel>;
                ViewBag.Filiais = filiais;
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApiFilial);
                ViewBag.Filiais = new List<FilialEmpresaViewModel>();
            }

            return PartialView("~/Views/Negociacao/index.cshtml", gridSetings);
        }

        [HttpPost]
        public ActionResult NovaNegociacao()
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("10"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            NegociacaoVerbaViewModel negociacaoVerbaViewModel = new NegociacaoVerbaViewModel();
            negociacaoVerbaViewModel.CodStatusNegociacaoVenda = 1;


            //Usuario usuario = Session["USUARIO"] as Usuario;
            Usuario usuario = CookieManager.GetCookieObj(CookieEnum.USUARIO);
            negociacaoVerbaViewModel.CodAutor = usuario.Matricula;
            negociacaoVerbaViewModel.NomAutor = usuario.Nome;
            negociacaoVerbaViewModel.VlrVerba = 0;

            RetornoApi retornoApiFilial = FilialEmpresaApi.ListLookup();
            if (retornoApiFilial.Sucesso)
            {
                List<FilialEmpresaViewModel> filiais = retornoApiFilial.Resultado as List<FilialEmpresaViewModel>;
                ViewBag.Filiais = filiais;
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApiFilial);
                ViewBag.Filiais = new List<FilialEmpresaViewModel>();
            }


            ViewBag.Compradores = new List<CompradorViewModel>();
            ViewBag.Fornecedores = new List<FornecedorViewModel>();

            negociacaoVerbaViewModel.Destinos = new List<NegociacaoVerbaDestinoViewModel>();

            return PartialView("~/Views/Negociacao/edit.cshtml", negociacaoVerbaViewModel);
        }

        [HttpPost]
        public ActionResult AddObjetivoDestino(List<NegociacaoVerbaDestinoViewModel> list, NegociacaoVerbaDestinoViewModel obj)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("5"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            if (list == null)
                list = new List<NegociacaoVerbaDestinoViewModel>();

            if (obj.CodDestino != 0 && obj.CodObjetivo != 0 && obj != null)
            {
                if (!(list.Where(x => x.CodObjetivo == obj.CodObjetivo && x.CodDestino == obj.CodDestino).ToList().Count > 0))
                {
                    list.Add(obj);
                }
                else
                {
                    Util.PreencheTempDataAlerta(this, "Esta combinação de Destino\\Objetivo já existe!");
                }
            }
            NegociacaoVerbaViewModel item = new NegociacaoVerbaViewModel();
            item.Destinos = list;
            return PartialView("~/Views/Negociacao/destinoObjetivo.cshtml", list);
        }

        [HttpPost]
        public ActionResult RemoverObjetivoDestino(List<NegociacaoVerbaDestinoViewModel> list, int codigo)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("5"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            list.Remove(list.Where(p => p.CodDestinoObjetivo == codigo).FirstOrDefault());

            return PartialView("~/Views/Negociacao/destinoObjetivo.cshtml", list);
        }

        [HttpPost]
        public ActionResult SalvarNegociacao(NegociacaoVerbaViewModel obj)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("5"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            if (obj.Destinos == null)
                obj.Destinos = new List<NegociacaoVerbaDestinoViewModel>();

          
                if (obj.CodNegociacaoVerba == null)
                {
                    Usuario usuario = CookieManager.GetCookieObj(CookieEnum.USUARIO) as Usuario;
                    obj.CodAutor = usuario.Matricula;
                    obj.NomAutor = usuario.Nome;

                    RetornoApi retornoApi = NegociacaoVerbaApi.Insert(obj);
                    if (retornoApi.Sucesso)
                    {
                        obj = retornoApi.Resultado as NegociacaoVerbaViewModel;

                        return EditarNegociacao(obj.CodNegociacaoVerba.Value);
                    }
                    else
                    {
                        Util.PreencheTempDataAlerta(this, retornoApi);
                    }
                }
                else
                {
                    RetornoApi retornoApi = NegociacaoVerbaApi.Update(obj);
                    if (retornoApi.Sucesso)
                    {
                        bool? status = retornoApi.Resultado as bool?;
                        if (status != true)
                        {
                            Util.PreencheTempDataAlerta(this, "Erro ao Salvar as alterações!");
                        }
                        else
                        {
                            return EditarNegociacao(obj.CodNegociacaoVerba.Value);
                        }
                    }
                    else
                    {
                        Util.PreencheTempDataAlerta(this, retornoApi);
                    }
                }

            if (ViewBag.Compradores == null)
                ViewBag.Compradores = new List<CompradorViewModel>();
            if (ViewBag.Filiais == null)
                ViewBag.Filiais = new List<FilialEmpresaViewModel>();
            if (ViewBag.Fornecedores == null)
                ViewBag.Fornecedores = new List<FornecedorViewModel>();
            return PartialView("~/Views/Negociacao/edit.cshtml", obj);
        }

        [HttpPost]
        public ActionResult EditarNegociacao(int pCodNegociacaoVerba)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("5"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            NegociacaoVerbaViewModel obj = new NegociacaoVerbaViewModel();
            RetornoApi retornoApi = NegociacaoVerbaApi.Select(pCodNegociacaoVerba);
            if (retornoApi.Sucesso)
            {
                obj = (NegociacaoVerbaViewModel)retornoApi.Resultado;
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
            }

            obj.Destinos = new List<NegociacaoVerbaDestinoViewModel>();
            retornoApi = NegociacaoVerbaDestinoApi.ListPorNegociacao(pCodNegociacaoVerba);
            if (retornoApi.Sucesso)
            {
                obj.Destinos = (List<NegociacaoVerbaDestinoViewModel>)retornoApi.Resultado;
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
            }

            retornoApi = FilialEmpresaApi.ListLookup();
            if (retornoApi.Sucesso)
            {
                List<FilialEmpresaViewModel> filiais = retornoApi.Resultado as List<FilialEmpresaViewModel>;
                ViewBag.Filiais = filiais;
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
                ViewBag.Filiais = new List<FilialEmpresaViewModel>();
            }

            retornoApi = CompradorApi.List(new CompradorViewModel() { CodFilialEmpresa = obj.CodFilialVerba });
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

            retornoApi = FornecedorApi.ListPorCompradorFilial(obj.CodFilialVerba.Value, obj.CodComprador.Value);
            if (retornoApi.Sucesso)
            {
                List<FornecedorViewModel> fornecedores = retornoApi.Resultado as List<FornecedorViewModel>;
                ViewBag.Fornecedores = fornecedores.OrderBy(p => p.NomFornecedor);
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
                ViewBag.Fornecedores = new List<FornecedorViewModel>();
            }

            return PartialView("~/Views/Negociacao/edit.cshtml", obj);
        }

        [HttpPost]
        public ActionResult EnviarParaAprovacao(int pCodNegociacaoVerba)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("14"))
            {
                return RedirectToAction("HTTP403", "Error");
            }
                
            Usuario usuario = CookieManager.GetCookieObj(CookieEnum.USUARIO) as Usuario;

            RetornoApi retornoApi = NegociacaoVerbaApi.SolicitarAprovacao(pCodNegociacaoVerba, usuario.Matricula);
            if (retornoApi.Sucesso)
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);  // OK = 200
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);  // OK = 200
        }

        [HttpGet]
        public ActionResult Pendencias()
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("4"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            GridSetings<ViewModel.NegociacaoVerbaViewModel> gridSetings = new GridSetings<NegociacaoVerbaViewModel>();
            gridSetings.Filtro = new NegociacaoVerbaViewModel();
            //Atriuir os valores padrão de filtro.

            gridSetings.Result = new List<NegociacaoVerbaViewModel>();

            gridSetings.Setings = new Setings();
            gridSetings.Setings.Column = "DtCadastroNegociacao"; //define ordem Padrão de ordenação
            gridSetings.Setings.Way = "asc";
            gridSetings.Setings.CurrentPage = 1;
            gridSetings.Setings.PageSize = 10;
            gridSetings.Setings.TotalRows = 0;
            gridSetings.Setings.CurrentPageSize = 0;


            gridSetings.Filtro.CodStatusNegociacaoVenda = 2;

            RetornoApi retornoApi = NegociacaoVerbaApi.List(gridSetings);
            if (retornoApi.Sucesso)
            {
                gridSetings = (GridSetings<NegociacaoVerbaViewModel>)retornoApi.Resultado;
            }
            else
            {
                gridSetings.Result = new List<NegociacaoVerbaViewModel>();
                Util.PreencheTempDataAlerta(this, retornoApi);
            }

            if (gridSetings.Result.Count == 0)
                Util.PreencheTempDataAlerta(this, Core.Message.Constantes.NENHUM_REGISTRO_ENCONTRADO, "Atenção", "info");

            return View(gridSetings);
        }

        [HttpPost]
        public ActionResult PesquisarPendencias(GridSetings<NegociacaoVerbaViewModel> gridSetings)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("4"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            gridSetings.Filtro.CodStatusNegociacaoVenda = 2;

            RetornoApi retornoApi = NegociacaoVerbaApi.List(gridSetings);
            if (retornoApi.Sucesso)
            {
                gridSetings = (GridSetings<NegociacaoVerbaViewModel>)retornoApi.Resultado;
            }
            else
            {
                gridSetings.Result = new List<NegociacaoVerbaViewModel>();
                Util.PreencheTempDataAlerta(this, retornoApi);
            }


            if (gridSetings.Result.Count == 0)
                Util.PreencheTempDataAlerta(this, Core.Message.Constantes.NENHUM_REGISTRO_ENCONTRADO, "Atenção", "info");

            RetornoApi retornoApiPesq = CompradorApi.List(new CompradorViewModel());
            if (retornoApiPesq.Sucesso)
            {
                List<CompradorViewModel> compradores = retornoApiPesq.Resultado as List<CompradorViewModel>;
                ViewBag.Compradores = compradores.OrderBy(p => p.NomComprador);
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApiPesq);
                ViewBag.Compradores = new List<CompradorViewModel>();
            }

            RetornoApi retornoApiFilial = FilialEmpresaApi.ListLookup();
            if (retornoApiFilial.Sucesso)
            {
                List<FilialEmpresaViewModel> filiais = retornoApiFilial.Resultado as List<FilialEmpresaViewModel>;
                ViewBag.Filiais = filiais;
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApiFilial);
                ViewBag.Filiais = new List<FilialEmpresaViewModel>();
            }


            return PartialView("~/Views/Negociacao/pendencias.cshtml", gridSetings);
        }

        [HttpPost]
        public ActionResult Reprovar(int pCodNegociacaoVerba, string pDesJustificativaReprovacao)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("12"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            Usuario usuario = CookieManager.GetCookieObj(CookieEnum.USUARIO) as Usuario;

            RetornoApi retornoApi = NegociacaoVerbaApi.Reprovar(pCodNegociacaoVerba, pDesJustificativaReprovacao, usuario.Matricula);
            if (retornoApi.Sucesso)
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);  // OK = 200
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);  // OK = 200
        }

        [HttpGet]
        public ActionResult Aprovar(int codNegociacaoVerba)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("11"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            RetornoApi retornoApi = NegociacaoVerbaApi.Select(codNegociacaoVerba);
            if (retornoApi.Sucesso)
            {
                Usuario usuario = CookieManager.GetCookieObj(CookieEnum.USUARIO) as Usuario;

                NegociacaoVerbaViewModel negociacaoVerba = retornoApi.Resultado as NegociacaoVerbaViewModel;
                ViewBag.NegociacaoVerba = negociacaoVerba;


                AcordoViewModel acordo = new AcordoViewModel();
                acordo.NomUsuario = usuario.IdRede;
                acordo.DtNegociacaoAcordo = DateTime.Now.Date;
                acordo.DesComentarioUsuario = negociacaoVerba.DesObservacaoSolicitacao;

                acordo.Recebimentos = new List<AcordoRecebimentoViewModel>();
                acordo.Recebimentos.Add(new AcordoRecebimentoViewModel());

                return PartialView("~/Views/Negociacao/aprovar.cshtml", acordo);
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
            }
            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        public ActionResult Aprovar(int pCodNegociacaoVerba, AcordoViewModel pAcordo)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("11"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            Usuario usuario = CookieManager.GetCookieObj(CookieEnum.USUARIO) as Usuario;

            RetornoApi retornoApi = NegociacaoVerbaApi.Aprovar(pCodNegociacaoVerba, usuario.Matricula, pAcordo);
            if (retornoApi.Sucesso)
            {

                List<AcordoViewModel> listAcordo = retornoApi.Resultado as List<AcordoViewModel>;
                retornoApi = NegociacaoVerbaApi.Select(pCodNegociacaoVerba);
                if (retornoApi.Sucesso)
                {
                    NegociacaoVerbaViewModel negociacaoVerba = retornoApi.Resultado as NegociacaoVerbaViewModel;
                    ViewBag.NegociacaoVerba = negociacaoVerba;
                }
                else
                {
                    Util.PreencheTempDataAlerta(this, retornoApi);
                }

                return PartialView("~/Views/Negociacao/acordosNegociacao.cshtml", listAcordo);
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);  // OK = 200
        }

        [HttpGet]
        public string ListObjetivos(int codDestino)
        {
            if (!Util.ValidaSessao())
            {
                return "";
            }

            RetornoApi retornoApi = DestinoObjetivoApi.ListObjetivoPorDestino(codDestino);
            if (retornoApi.Sucesso)
            {
                List<DestinoObjetivoViewModel> objetivos = retornoApi.Resultado as List<DestinoObjetivoViewModel>;

                if (objetivos != null)
                {
                    objetivos = objetivos.OrderBy(o => o.NomObjetivo).ToList();
                }
                return JsonConvert.SerializeObject((objetivos as List<DestinoObjetivoViewModel>));
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
            }

            return "";
        }

        [HttpPost]
        public ActionResult FindNegociacao(GridSetings<ViewModel.NegociacaoVerbaViewModel> gridSetings)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (gridSetings.Filtro == null)
            {
                gridSetings.Filtro = new ViewModel.NegociacaoVerbaViewModel();
                gridSetings.Result = new List<ViewModel.NegociacaoVerbaViewModel>();
            }
            else if (gridSetings.Filtro.CodNegociacaoVerba != null || !string.IsNullOrEmpty(gridSetings.Filtro.DesNegociacaoVerba))
            {
                RetornoApi retornoApi = NegociacaoVerbaApi.List(gridSetings);
                if (retornoApi.Sucesso)
                {
                    gridSetings = (GridSetings<NegociacaoVerbaViewModel>)retornoApi.Resultado;
                }
                else
                {
                    gridSetings.Result = new List<NegociacaoVerbaViewModel>();
                    Util.PreencheTempDataAlerta(this, retornoApi);
                }
            }
            else
            {
                Util.PreencheTempDataAlerta(this, Core.Message.Constantes.INFORME_FILTRO, "Atenção", "info");

                gridSetings.Filtro = new ViewModel.NegociacaoVerbaViewModel();
                gridSetings.Result = new List<ViewModel.NegociacaoVerbaViewModel>();
            }

            if (gridSetings.Result.Count == 0)
                Util.PreencheTempDataAlerta(this, Core.Message.Constantes.NENHUM_REGISTRO_ENCONTRADO, "Atenção", "info");

            return PartialView("~/Views/Negociacao/findNegociacao.cshtml", gridSetings);
        }


        [HttpGet]
        public string FiltrarComprador(int codFilialEmpresa)
        {
            if (!Util.ValidaSessao())
            {
                return "";
            }

            RetornoApi retornoApi = CompradorApi.List(new CompradorViewModel() { CodFilialEmpresa = codFilialEmpresa });
            if (retornoApi.Sucesso)
            {
                return JsonConvert.SerializeObject((retornoApi.Resultado as List<CompradorViewModel>).OrderBy(p => p.NomComprador));
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
            }
            return "";
        }

        [HttpGet]
        public string FiltrarFornecedor(int codFilialEmpresa, int codComprador)
        {
            if (!Util.ValidaSessao())
            {
                return "";
            }

            RetornoApi retornoApi = FornecedorApi.ListPorCompradorFilial(codFilialEmpresa, codComprador);
            if (retornoApi.Sucesso)
            {
                return JsonConvert.SerializeObject((retornoApi.Resultado as List<FornecedorViewModel>).OrderBy(p => p.NomFornecedor));
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
            }
            return "";
        }

        [HttpPost]
        public ActionResult Imprimir(int pCodNegociacaoVerba)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("13"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            RetornoApi retornoApi = NegociacaoVerbaApi.Select(pCodNegociacaoVerba);
            NegociacaoVerbaViewModel negociacaoVerba = retornoApi.Resultado as NegociacaoVerbaViewModel;
            ViewBag.NegociacaoVerba = negociacaoVerba;

            retornoApi = new RetornoApi();
            retornoApi = AcordoApi.ListPorNegociacao(pCodNegociacaoVerba);

            if (retornoApi.Sucesso)
            {

                List<AcordoViewModel> listAcordo = retornoApi.Resultado as List<AcordoViewModel>;
                

                return PartialView("~/Views/Negociacao/imprimirAcordo.cshtml", listAcordo);
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);  // OK = 200
        }

        [HttpGet]
        public ActionResult ImprimirAcordo(int pCodPromessa)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("13"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            RetornoApi retornoApi = AcordoApi.SelectAcordoPdf(pCodPromessa);
            List<AcordoViewModel> acordo = retornoApi.Resultado as List<AcordoViewModel>;

            if (retornoApi.Sucesso)
            {
                return PartialView("~/Views/Negociacao/acordoPdfGenerate.cshtml", acordo.FirstOrDefault());
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);  // OK = 200

            
        }

        [HttpGet]
        public ActionResult JustificativaReprovacao(int pCodNegociacaoVerba)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("12"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            NegociacaoVerbaViewModel obj = new NegociacaoVerbaViewModel();
            obj.CodNegociacaoVerba = pCodNegociacaoVerba;

            return PartialView("~/Views/Negociacao/justificativaReprovacao.cshtml", obj);
        }

        [HttpPost]
        public ActionResult HistoricoNegociacao(int pCodNegociacaoVerba)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (!Util.VerificaMenuUsuario("5"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            RetornoApi retornoApi = NegociacaoVerbaHistoricoApi.Historico(pCodNegociacaoVerba);

            List<NegociacaoVerbaHistoricoViewModel> listHistorico = retornoApi.Resultado as List<NegociacaoVerbaHistoricoViewModel>;

            if (retornoApi.Sucesso)
            {
                return PartialView("~/Views/Negociacao/historicoNegociacao.cshtml", listHistorico);
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);  // OK = 200
            
        }
    }
}
