using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class CarimboBLL
    {
        public static Carimbo Select(int pCodCarimbo)
        {
            return CarimboDAL.Select(pCodCarimbo);
        }

        public static Carimbo Insert(Carimbo obj)
        {
            obj.DtCadastroCarimbo = DateTime.Now;

            obj = CarimboDAL.Insert(obj);

            if (obj.Itens != null)
            {
                foreach (CarimboItem item in obj.Itens)
                {
                    item.CodDestinoObjetivo = obj.CodDestinoObjetivo;
                    item.CodCarimbo = obj.CodCarimbo;
                    CarimboItemBLL.Insert(item);
                }
            }

            return obj;
        }

        public static void Update(int pCodCarimbo, Carimbo obj)
        {
            CarimboDAL.Update(pCodCarimbo, obj);

            if (obj.Itens != null)
            {
                List<CarimboItem> listOld = CarimboItemBLL.ListPorCarimbo(pCodCarimbo);

                foreach (CarimboItem item in obj.Itens)
                {
                    item.CodCarimbo = obj.CodCarimbo;
                    item.CodDestinoObjetivo = obj.CodDestinoObjetivo;

                    if (listOld.Where(p => p.CodMercadoria == item.CodMercadoria && p.CodFilialEmpresa == item.CodFilialEmpresa).FirstOrDefault() == null)
                        CarimboItemBLL.Insert(item);
                    else
                        CarimboItemBLL.Update(item.CodCarimbo.Value, item.CodMercadoria.Value, item.CodFilialEmpresa.Value, item);
                }

                foreach (CarimboItem item in listOld)
                {
                    if (obj.Itens.Where(p => p.CodMercadoria == item.CodMercadoria && p.CodFilialEmpresa == item.CodFilialEmpresa).FirstOrDefault() == null)
                    {
                        CarimboItemBLL.Delete(item.CodCarimbo.Value, item.CodMercadoria.Value, item.CodFilialEmpresa.Value);
                    }
                }
            }
        }

        public static Carimbo SelectPorNegociacao(int codigoNegociacaoVerba, int codDestinoObjetivo)
        {
            return CarimboDAL.SelectPorNegociacao(codigoNegociacaoVerba, codDestinoObjetivo);
        }

        public static List<Carimbo> ListPorNegociacao(int codigoNegociacaoVerba)
        {
            return CarimboDAL.ListPorNegociacao(codigoNegociacaoVerba);
        }

        public static Carimbo CriarCarimbo(int codigoNegociacaoVerba, int codDestinoObjetivo, int codUsuario)
        {

            Funcionario funcionarioLogado = FuncionarioBLL.Select(codUsuario);

            Carimbo carimbo = SelectPorNegociacao(codigoNegociacaoVerba, codDestinoObjetivo);
            if (carimbo != null)
            {
                throw new Exception("Já existe carimbo para esta negociação de verba");
            }
            else
            {
                NegociacaoVerba negociacaoVerba = NegociacaoVerbaBLL.Select(codigoNegociacaoVerba);

                if (negociacaoVerba == null)
                {
                    throw new Exception("Negociação de verba não encontrada");
                }

                if (!(negociacaoVerba.CodStatusNegociacaoVenda == 1 || negociacaoVerba.CodStatusNegociacaoVenda == 4)) // 1 = Novo , 4 = Reprovado
                {
                    throw new Exception("O status da negociação de verba não permite alteração");
                }
                NegociacaoVerbaDestino negociacaoVerbaDestino = NegociacaoVerbaDestinoBLL.ListPorNegociacao(codigoNegociacaoVerba).Where(p => p.CodDestinoObjetivo == codDestinoObjetivo).FirstOrDefault();
                if (negociacaoVerbaDestino == null)
                {
                    throw new Exception("Destino da negociação de verba não encontrada");
                }


                carimbo = new Carimbo();
                carimbo.NumPedidoCompra = 0;
                carimbo.DtCadastroCarimbo = DateTime.Now;
                carimbo.CodFuncionario = funcionarioLogado.CodFuncionario;
                carimbo.CodFornecedor = negociacaoVerba.CodFornecedor;
                carimbo.CodPromessa = 0;
                carimbo.DtNegociacaoPromessa = DateTime.Now;
                carimbo.CodStatusCarimbo = 1; //1 = "Simulado"
                carimbo.DesObservacao = negociacaoVerbaDestino.DesObservacao;
                carimbo.TIPOBJMCOVBAFRN = 0;
                carimbo.VlrUtilizadoAcaoComercial = 0;
                carimbo.CodNegociacaoVerba = negociacaoVerba.CodNegociacaoVerba;
                carimbo.CodDestinoObjetivo = negociacaoVerbaDestino.CodDestinoObjetivo;

                carimbo.NomDestinoObjetivo = negociacaoVerbaDestino.NomDestinoObjetivo;
                carimbo.NomFuncionario = funcionarioLogado.NomFuncionario;
                carimbo.NomFornecedor = negociacaoVerba.NomFornecedor;

                carimbo.VlrVerba = negociacaoVerbaDestino.VlrVerba;
                carimbo.VlrCarimbo = Math.Round(negociacaoVerbaDestino.VlrVerba.Value * ((decimal)0.9), 2);
                carimbo.VlrImpostos = (carimbo.VlrVerba.Value - carimbo.VlrCarimbo.Value);

                carimbo = CarimboBLL.Insert(carimbo);


                carimbo.Itens = new List<CarimboItem>();

                return carimbo;
            }
        }


        public static void Delete(int pCodCarimbo)
        {
            CarimboDAL.Delete(pCodCarimbo);
        }

    }
}