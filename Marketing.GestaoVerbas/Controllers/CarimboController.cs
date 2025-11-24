using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marketing.GestaoVerbas.ViewModel;
using Marketing.GestaoVerbas.Core;
using Marketing.GestaoVerbas.Core.Grid;
using Marketing.GestaoVerbas.Api;
using System.Text;
using System.Net;

namespace Marketing.GestaoVerbas.Controllers
{
    public class CarimboController : Controller
    {
        // GET: Carimbo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int pCodNegociacaoVerba, int pCodDestinoObjetivo)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            Usuario usuario = CookieManager.GetCookieObj(CookieEnum.USUARIO) as Usuario;

            CarimboViewModel pObjCarimbo = new CarimboViewModel();

            NegociacaoVerbaViewModel negociacaoVerba = new NegociacaoVerbaViewModel();
            RetornoApi retornoApi = NegociacaoVerbaApi.Select(pCodNegociacaoVerba);
            if (retornoApi.Sucesso)
            {
                negociacaoVerba = retornoApi.Resultado as NegociacaoVerbaViewModel;
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
            }
            ViewBag.NegociacaoVerba = negociacaoVerba;


            retornoApi = CarimboApi.SelectPorNegociacao(pCodNegociacaoVerba, pCodDestinoObjetivo);
            if (retornoApi.Sucesso)
            {
                if (retornoApi.Resultado == null && (negociacaoVerba.CodStatusNegociacaoVenda == 1 || negociacaoVerba.CodStatusNegociacaoVenda == 4)) // Se o carimbo ainda nao existe, é necessário cria-lo
                {
                    retornoApi = CarimboApi.CriarCarimbo(pCodNegociacaoVerba, pCodDestinoObjetivo, usuario.Matricula);
                    if (retornoApi.Sucesso)
                    {
                        pObjCarimbo = (CarimboViewModel)retornoApi.Resultado;
                        if (retornoApi.Sucesso)
                        {
                            retornoApi = CarimboItemApi.ConsultaItensFornecedor(pObjCarimbo.CodFornecedor.GetValueOrDefault(), null, negociacaoVerba.CodComprador, pObjCarimbo.CodCarimbo.Value, this.RetornaAnoSmnRef(negociacaoVerba.CodStatusNegociacaoVenda.Value, negociacaoVerba.DtAprovacao));
                            if (retornoApi.Sucesso)
                            {
                                pObjCarimbo.Itens = (List<CarimboItemViewModel>)retornoApi.Resultado;
                            }
                            else
                            {
                                Util.PreencheTempDataAlerta(this, retornoApi);
                            }
                        }
                        else
                        {
                            Util.PreencheTempDataAlerta(this, retornoApi);
                        }
                    }
                    else
                    {
                        Util.PreencheTempDataAlerta(this, retornoApi);
                    }
                }
                else if (retornoApi.Resultado == null)
                {
                    Util.PreencheTempDataAlerta(this, "Carimbo não encontrado!");
                }
                else // carimbo ja existe - consultar itens do carimbo
                {
                    pObjCarimbo = (CarimboViewModel)retornoApi.Resultado;


                    retornoApi = CarimboItemApi.ConsultaItensFornecedor(pObjCarimbo.CodFornecedor.GetValueOrDefault(), null, negociacaoVerba.CodComprador, pObjCarimbo.CodCarimbo.Value, this.RetornaAnoSmnRef(negociacaoVerba.CodStatusNegociacaoVenda.Value, negociacaoVerba.DtAprovacao));

                    if (retornoApi.Sucesso)
                    {
                        pObjCarimbo.Itens = (List<CarimboItemViewModel>)retornoApi.Resultado;
                    }
                    else
                    {
                        Util.PreencheTempDataAlerta(this, retornoApi);
                    }
                }
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
            //Tratativa para nao enviar a lista NULL para a view.
            if (pObjCarimbo.Itens == null)
                pObjCarimbo.Itens = new List<CarimboItemViewModel>();

            Session[string.Format("CarimboItemViewModel_", pObjCarimbo.CodCarimbo)] = pObjCarimbo.Itens;
            pObjCarimbo.Itens = CalcularCarimboMercadoria(pObjCarimbo.Itens, pObjCarimbo.VlrCarimbo.Value, pObjCarimbo.VlrImpostos.Value);

            return PartialView("~/Views/Carimbo/edit.cshtml", pObjCarimbo);
        }

        public ActionResult FiltrarGridCarimbo(int pCodFornecedor, string[] pCodFiliais, int? pCodComprador, int pCodCarimbo, decimal pVlrCarimbo, decimal pVlrImpostos, int pCodStatusNegociacaoVenda, DateTime? pDataAprovacao)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }


            string strCodFiliais = "";
            if (pCodFiliais != null)
            {
                foreach (var item in pCodFiliais)
                {
                    if (strCodFiliais != "")
                        strCodFiliais += ",";
                    strCodFiliais += item;
                }
            }

            List<CarimboItemViewModel> listaCarimbos = new List<CarimboItemViewModel>();

            RetornoApi retornoApi = CarimboItemApi.ConsultaItensFornecedor(pCodFornecedor, strCodFiliais, pCodComprador, pCodCarimbo, this.RetornaAnoSmnRef(pCodStatusNegociacaoVenda, pDataAprovacao));
            if (retornoApi.Sucesso)
            {
                listaCarimbos = (List<CarimboItemViewModel>)retornoApi.Resultado;
            }
            else
            {
                listaCarimbos = new List<CarimboItemViewModel>();
                Util.PreencheTempDataAlerta(this, retornoApi);
            }

            Session[string.Format("CarimboItemViewModel_", pCodCarimbo)] = listaCarimbos;

            listaCarimbos = CalcularCarimboMercadoria(listaCarimbos, pVlrCarimbo, pVlrImpostos);

            return PartialView("~/Views/Carimbo/gridCarimboItem.cshtml", listaCarimbos);
        }



        private List<CarimboItemViewModel> CalcularCarimboMercadoria(List<CarimboItemViewModel> list, decimal pVlrVerbaCarimbo, decimal pVlrImpostos)
        {
            List<CarimboItemViewModel> listSelecionados = list.Where(p => p.VlrPrevistoCarimbo > 0).ToList();

            foreach (var item in listSelecionados)
            {
                item.VlrPerParticipacaoVerba = ((item.VlrPrevistoCarimbo.GetValueOrDefault() * 100) / pVlrVerbaCarimbo);
                item.VlrImpostos = pVlrImpostos * (item.VlrPerParticipacaoVerba.GetValueOrDefault() / 100);
                if (item.QtdEstoqueMercadoria.GetValueOrDefault() != 0)
                    item.VlrVerbaUnitario = (item.VlrPrevistoCarimbo.GetValueOrDefault() / item.QtdEstoqueMercadoria.GetValueOrDefault());
                else
                    item.VlrVerbaUnitario = 0;

                if ((item.VlrDiarioCustoMedioEfetivo.GetValueOrDefault() - item.VlrMedioVerbaParaPrecoMercadoria.GetValueOrDefault() > 0))
                {
                    item.VlrPerQuedaPonderada = ((((item.VlrDiarioCustoMedioEfetivo.GetValueOrDefault() - item.VlrMedioVerbaParaPrecoMercadoria.GetValueOrDefault() - item.VlrVerbaUnitario.GetValueOrDefault()) / (item.VlrDiarioCustoMedioEfetivo.GetValueOrDefault() - item.VlrMedioVerbaParaPrecoMercadoria.GetValueOrDefault())) - 1) * 100);
                }
            }
            return list;
        }

        [HttpPost]
        public ActionResult OrdenarCarimboItem(CarimboViewModel edit, string coluna, string sentido)
        {
            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (edit.Itens == null)
                edit.Itens = new List<CarimboItemViewModel>();

            List<CarimboItemViewModel> listaCarimbos = Session[string.Format("CarimboItemViewModel_", edit.CodCarimbo)] as List<CarimboItemViewModel>;

            if (listaCarimbos != null)
            {
                foreach (var item in listaCarimbos)
                {
                    CarimboItemViewModel selected = edit.Itens.Where(p => p.CodMercadoria == item.CodMercadoria && p.CodFilialEmpresa == item.CodFilialEmpresa).FirstOrDefault();
                    if (selected != null)
                    {
                        item.VlrPrevistoCarimbo = selected.VlrPrevistoCarimbo;
                        item.VlrImpostos = selected.VlrImpostos;
                    }
                    else
                    {
                        item.VlrPrevistoCarimbo = null;
                        item.VlrImpostos = null;
                        item.VlrPerParticipacaoVerba = null;
                        item.VlrVerbaUnitario = null;
                        item.VlrPerQuedaPonderada = null;
                    }
                }
                listaCarimbos = CalcularCarimboMercadoria(listaCarimbos, edit.VlrCarimbo.Value, edit.VlrImpostos.Value);
                listaCarimbos = this.Ordenar(listaCarimbos, coluna, sentido);
            }
            else
            {
                Util.PreencheTempDataAlerta(this, "Erro ao obter a lista de mercadorias! Atualize a página");
                listaCarimbos = new List<CarimboItemViewModel>();
            }
            return PartialView("~/Views/Carimbo/gridCarimboItem.cshtml", listaCarimbos);
        }

        #region "Ordenação"

        private List<CarimboItemViewModel> Ordenar(List<CarimboItemViewModel> listaObjetos, string coluna, string sentido)
        {
            List<CarimboItemViewModel> similares = listaObjetos.Where(p => p.CodGrupoSimilar != 0).ToList();
            List<CarimboItemViewModel> semSimilares = listaObjetos.Where(p => p.CodGrupoSimilar == 0).ToList();

            if (sentido == "asc")
            {
                semSimilares = semSimilares.OrderBy(p => this.GetPropertyValue(p, coluna)).ToList();
            }
            else if (sentido == "desc")
            {
                semSimilares = semSimilares.OrderByDescending(p => this.GetPropertyValue(p, coluna)).ToList();
            }

            List<CarimboItemViewModel> fullList = new List<CarimboItemViewModel>();
            fullList.AddRange(similares);
            fullList.AddRange(semSimilares);
            return fullList;
        }

        private object GetPropertyValue(object obj, string propertyName)
        {
            try
            {
                System.Type t = obj.GetType();
                System.Reflection.PropertyInfo[] property = t.GetProperties();
                return t.InvokeMember(propertyName,
                     System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.Public |
                     System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetProperty, null, obj, null);
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        #endregion

        [HttpPost]
        public ActionResult ExportarCarimboCSV(int pCodFornecedor, string[] pCodFiliais, int? pCodComprador, int pCodCarimbo, decimal pVlrCarimbo, decimal pVlrImpostos, int pCodStatusNegociacaoVenda, DateTime? pDataAprovacao)
        {

            if (!Util.VerificaMenuUsuario("5"))
            {
                return RedirectToAction("HTTP403", "Error");
            }

            string strCodFiliais = "";
            if (pCodFiliais != null)
            {
                foreach (var item in pCodFiliais)
                {
                    if (strCodFiliais != "")
                        strCodFiliais += ",";
                    strCodFiliais += item;
                }
            }

            List<CarimboItemViewModel> listaCarimbos = new List<CarimboItemViewModel>();

            RetornoApi retornoApi = CarimboItemApi.ConsultaItensFornecedor(pCodFornecedor, strCodFiliais, pCodComprador, pCodCarimbo, this.RetornaAnoSmnRef(pCodStatusNegociacaoVenda, pDataAprovacao));
            if (retornoApi.Sucesso)
            {
                listaCarimbos = (List<CarimboItemViewModel>)retornoApi.Resultado;
            }
            else
            {
                listaCarimbos = new List<CarimboItemViewModel>();
                Util.PreencheTempDataAlerta(this, retornoApi);
            }

            //Session[string.Format("CarimboItemViewModel_", pCodCarimbo)] = listaCarimbos;

            //filtra somente os itens selecionados.
            listaCarimbos = listaCarimbos.Where(p => p.VlrPrevistoCarimbo != null).ToList();

            listaCarimbos = CalcularCarimboMercadoria(listaCarimbos, pVlrCarimbo, pVlrImpostos);


            if (retornoApi.Sucesso)
            {

                string handle = Guid.NewGuid().ToString();


                TempData[handle] = (new Core.CSV<CarimboItemViewModel>()).ConvertCSV(listaCarimbos
                                        , new string[] { "NomFilialEmpresa"
                                                           , "CodMercadoria"
                                                           , "NomMercadoria"
                                                           , "DesClasseMercadoria"
                                                           , "QtdEstoqueMercadoria"
                                                           , "VlrEstoqueMercadoria"
                                                           , "QtdSaldoPeriodoMercadoria"
                                                           , "VlrSaldoPeriodoMercadoria"
                                                           , "VlrCobertura"
                                                           , "VlrPerParticipacaoVerba"
                                                           , "VlrDiarioCustoMedioEfetivo"
                                                           , "VlrMedioVerbaParaPrecoMercadoria"
                                                           , "VlrMedioVerbaParaMargemMercadoria"
                                                           , "VlrVerbaUnitario"
                                                           , "VlrPrevistoCarimbo"
                                                           , "VlrPerQuedaPonderada"
                                                           , "VlrPerMcVnd"
                                                           , "VlrPerMbVnd"
                                                           , "VlrPercentualFundingVendaTotal"
                                                           , "VlrPercentualFundingVendaPreco"
                                                           , "VlrImpostos"
                                                       }
                                    );



                return new JsonResult()
                {
                    Data = new { FileGuid = handle, FileName = "Exportação Carimbo.csv" }
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



        public ActionResult SalvarCarimbo(CarimboViewModel edit)
        {

            if (!Util.ValidaSessao())
            {
                return RedirectToAction("Index", "Login");
            }

            if (edit.Itens == null)
                edit.Itens = new List<CarimboItemViewModel>();

            RetornoApi retornoApi = CarimboItemApi.UpdateList(edit.CodCarimbo.Value, edit.VlrVerba, edit.Itens);
            if (retornoApi.Sucesso)
            {
                return Edit(edit.CodNegociacaoVerba.Value, edit.CodDestinoObjetivo.Value);
            }
            else
            {
                Util.PreencheTempDataAlerta(this, retornoApi);
                ViewBag.Filiais = new List<FilialEmpresaViewModel>();
                return PartialView("~/Views/Carimbo/edit.cshtml", edit);
            }
        }

        //public ActionResult SalvarCarimboPatch(CarimboViewModel edit)
        //{

        //    if (!Util.ValidaSessao())
        //    {
        //        return RedirectToAction("Index", "Login");
        //    }

        //    if (edit.Itens == null)
        //        edit.Itens = new List<CarimboItemViewModel>();

        //    RetornoApi retornoApi = CarimboApi.Update(edit);
        //    if (retornoApi.Sucesso)
        //    {
        //        return Edit(edit.CodNegociacaoVerba.Value, edit.CodDestinoObjetivo.Value);
        //    }
        //    else
        //    {
        //        Util.PreencheTempDataAlerta(this, retornoApi);
        //        ViewBag.Filiais = new List<FilialEmpresaViewModel>();
        //        return PartialView("~/Views/Carimbo/edit.cshtml", edit);
        //    }
        //}


        private string RetornaAnoSmnRef(int pCodStatusNegociacaoVenda, DateTime? pDataAprovacao)
        {
            DateTime datafiltro = DateTime.Now;

            if (pCodStatusNegociacaoVenda == 3) //Aprovado
            {
                if (pDataAprovacao.GetValueOrDefault().DayOfWeek == DayOfWeek.Monday)
                    datafiltro = pDataAprovacao.GetValueOrDefault().AddDays(-2);
                else
                    datafiltro = pDataAprovacao.GetValueOrDefault().AddDays(-1);
            }
            else
            {
                if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
                    datafiltro = DateTime.Now.AddDays(-2);
                else
                    datafiltro = DateTime.Now.AddDays(-1);
            }
            return datafiltro.ToString("yyyy-MM-dd");
        }
    }
}