using Marketing.GestaoVerbasAPI.App_Code.Connection;
using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class NegociacaoVerbaBLL
    {

        public static ListResult<NegociacaoVerba> List(int pagina, int tamanho, string coluna, string sentido, NegociacaoVerba filtro)
        {
            return NegociacaoVerbaDAL.List(pagina, tamanho, coluna, sentido, filtro);
        }

        public static NegociacaoVerba Select(int codigo)
        {
            return NegociacaoVerbaDAL.Select(codigo);
        }

        public static NegociacaoVerba Insert(NegociacaoVerba obj)
        {
            obj.DtCadastroNegociacao = DateTime.Now;
            obj.CodStatusNegociacaoVenda = 1;

            obj = NegociacaoVerbaDAL.Insert(obj);


            if (obj.Destinos != null)
            {
                foreach (NegociacaoVerbaDestino destino in obj.Destinos)
                {
                    destino.CodNegociacaoVerba = obj.CodNegociacaoVerba;
                    NegociacaoVerbaDestinoBLL.Insert(destino);
                }
            }

            NegociacaoVerbaHistorico hst = new NegociacaoVerbaHistorico();
            hst.CodFuncionario = obj.CodAutor;
            hst.CodNegociacaoVerba = obj.CodNegociacaoVerba;
            hst.CodStatusNegociacaoVenda = obj.CodStatusNegociacaoVenda;
            hst.DtHistorico = DateTime.Now;
            NegociacaoVerbaHistoricoBLL.Insert(hst);

            return obj;
        }

        public static void Update(int codigo, NegociacaoVerba obj)
        {
            List<Carimbo> carimbos = CarimboBLL.ListPorNegociacao(codigo);

            if (carimbos.Where(p => p.CodStatusCarimbo != 1).FirstOrDefault() != null)
            {
                throw new Exception(string.Format("Um ou mais carimbos relacionado a esta negociação de verba esta em um status que não permite alteração!"));
            }


            NegociacaoVerbaDAL.Update(codigo, obj);

            if (obj.Destinos != null)
            {
                List<NegociacaoVerbaDestino> listOld = NegociacaoVerbaDestinoBLL.ListPorNegociacao(codigo);

                foreach (NegociacaoVerbaDestino destino in obj.Destinos)
                {
                    destino.CodNegociacaoVerba = obj.CodNegociacaoVerba;

                    if (listOld.Where(p => p.CodDestinoObjetivo == destino.CodDestinoObjetivo).FirstOrDefault() == null)
                        NegociacaoVerbaDestinoBLL.Insert(destino);
                    else
                    {
                        NegociacaoVerbaDestinoBLL.Update(destino.CodNegociacaoVerba.Value, destino.CodDestinoObjetivo.Value, destino);

                        Carimbo carimbo = carimbos.Where(p => p.CodDestinoObjetivo == destino.CodDestinoObjetivo).FirstOrDefault();
                        if (carimbo != null) // se ja tem carimbo
                        {
                            if (carimbo.DesObservacao != destino.DesObservacao || carimbo.CodFornecedor != obj.CodFornecedor) //verifica se algum campo foi alterado
                            {
                                carimbo.DesObservacao = destino.DesObservacao;
                                carimbo.CodFornecedor = obj.CodFornecedor;
                                CarimboBLL.Update(carimbo.CodCarimbo.Value, carimbo);
                            }
                        }
                    }
                }

                foreach (NegociacaoVerbaDestino destino in listOld)
                {
                    if (obj.Destinos.Where(p => p.CodDestinoObjetivo == destino.CodDestinoObjetivo).FirstOrDefault() == null)
                    {
                        NegociacaoVerbaDestinoBLL.Delete(destino.CodNegociacaoVerba.Value, destino.CodDestinoObjetivo.Value);

                        Carimbo carimbo = carimbos.Where(p => p.CodDestinoObjetivo == destino.CodDestinoObjetivo).FirstOrDefault();
                        if (carimbo != null) // se ja tem carimbo
                        {
                            CarimboBLL.Delete(carimbo.CodCarimbo.Value);
                        }
                    }
                }
            }
        }

        public static void Delete(int codigo)
        {
            NegociacaoVerbaDAL.Delete(codigo);
        }


        public static void SolicitarAprovacao(int codNegociacaoVerba, int codUsuario)
        {
            NegociacaoVerba obj = Select(codNegociacaoVerba);

            if (!(obj.CodStatusNegociacaoVenda == 1 || obj.CodStatusNegociacaoVenda == 4))
                throw new Exception("O status da negociação de verba não permite o envio para aprovação.");
            if (obj.CodAutor != codUsuario)
                throw new Exception("Você não é o autor desta negociação de verba");

            List<NegociacaoVerbaDestino> destinosObjetivo = NegociacaoVerbaDestinoBLL.ListPorNegociacao(codNegociacaoVerba);

            if (destinosObjetivo.Count == 0)
                throw new Exception("É necessário informar distribuição de verbas antes do envio para aprovação.");

            decimal sum = destinosObjetivo.Sum(p => p.VlrVerba.GetValueOrDefault());

            if (sum != obj.VlrVerba)
                throw new Exception("A Soma dos Destino/Objetivo dever ser igual ao valor da negociação de verba");

            

            List<Carimbo> carimbosList = CarimboBLL.ListPorNegociacao(codNegociacaoVerba);
            

            foreach (var item in destinosObjetivo)
            {
                if (item.CodObjetivo == 1)
                {
                    if (item.CodCarimbo == null)
                        throw new Exception(string.Format("Não foi gerado carimbo para o empenho {0};", item.NomDestinoObjetivo));

                    Carimbo carimbo = carimbosList.Where(p => p.CodCarimbo == item.CodCarimbo).First();

                    carimbo.Itens = CarimboItemBLL.ListPorCarimbo(carimbo.CodCarimbo.Value);


                    if (carimbo.Itens.Count == 0)
                        throw new Exception(string.Format("Não foram selecionados as mercadorias para o carimbo {0};", item.CodCarimbo));

                    decimal sumCarimboItens = carimbo.Itens.Sum(p => p.VlrPrevistoCarimbo.GetValueOrDefault());
                    decimal percentualDiferenca = (((item.VlrVerba.Value * (decimal)0.9) * 100) / sumCarimboItens);
                    if (percentualDiferenca < 99 || percentualDiferenca > 101)
                        throw new Exception(string.Format("As mercadorias selecionadas para o carimbo {0} não totalizam o valor previsto para o carimbo;", item.CodCarimbo));
                }
            }





            NegociacaoVerbaDAL.UpdateStatus(codNegociacaoVerba, 2);

            NegociacaoVerbaHistorico hst = new NegociacaoVerbaHistorico();
            hst.CodFuncionario = codUsuario;
            hst.CodNegociacaoVerba = codNegociacaoVerba;
            hst.CodStatusNegociacaoVenda = 2;
            hst.DtHistorico = DateTime.Now;
            NegociacaoVerbaHistoricoBLL.Insert(hst);

        }


        public static void Reprovar(int codNegociacaoVerba, string desJustificativaReprovacao, int codUsuario)
        {
            NegociacaoVerba obj = Select(codNegociacaoVerba);

            if (obj.CodStatusNegociacaoVenda != 2)
                throw new Exception("Esta negociação de verba não esta aguardando aprovação");

            NegociacaoVerbaDAL.UpdateStatus(codNegociacaoVerba, 4);

            DateTime dataReprovacao = DateTime.Now;

            NegociacaoVerbaHistorico hst = new NegociacaoVerbaHistorico();
            hst.CodFuncionario = codUsuario;
            hst.CodNegociacaoVerba = codNegociacaoVerba;
            hst.DesJustificativaReprovacao = desJustificativaReprovacao;
            hst.CodStatusNegociacaoVenda = 4;
            hst.DtHistorico = dataReprovacao;
            NegociacaoVerbaHistoricoBLL.Insert(hst);

            Usuario userAutor = UserBLL.GetUserByCodFunc(obj.CodAutor);
            Usuario userReprovador = UserBLL.GetUserByCodFunc(codUsuario);
  
        
            

            EmailCapa email = new EmailCapa();
            email.Assunto = String.Format("Negociação de verba {0} reprovada", codNegociacaoVerba);
            email.AddConteudo( string.Format("A negociação de verba {0} foi reprovada em {1}", codNegociacaoVerba, dataReprovacao) );
            email.AddConteudo( "Justificativa:" );
            email.AddConteudo( desJustificativaReprovacao );
            email.AddRemetente(userReprovador.Email);
            email.AddDestinatario(userAutor.Email);

            EmailCapaBLL.Insert(email);
        }


        public static List<Acordo> Aprovar(int codNegociacaoVerba, int codUsuario, Acordo pAcordo)
        {
            List<Acordo> list = new List<Acordo>();
            NegociacaoVerba negociacaoVerba = Select(codNegociacaoVerba);

            if (negociacaoVerba.CodStatusNegociacaoVenda != 2)
                throw new Exception("Esta negociação de verba não esta aguardando aprovação");

            List<Carimbo> carimbosList = CarimboBLL.ListPorNegociacao(codNegociacaoVerba);

            if (carimbosList.Where(p => p.CodStatusCarimbo != 1).FirstOrDefault() != null)
                throw new Exception("Existem carimbo(s) nesta negociação de verba que já estão em processo de cadastramento!");

            List<NegociacaoVerbaDestino> destinosList = NegociacaoVerbaDestinoBLL.ListPorNegociacao(codNegociacaoVerba);

            foreach (NegociacaoVerbaDestino destino in destinosList)
            {
                Acordo acordo = new Acordo();
                acordo.CodEmpresa = 1;
                acordo.CodFilialEmpresa = negociacaoVerba.CodFilialVerba;
                //acordo.CodPromessa; //Obtem o codigo na hora de fazer o insert
                acordo.DtNegociacaoAcordo = pAcordo.DtNegociacaoAcordo;
                acordo.CodStatusAcordo = 0; // 0 = Aberto
                acordo.NumPedidoCompra = null;
                acordo.CodFornecedor = negociacaoVerba.CodFornecedor;

                acordo.NomUsuario = pAcordo.NomUsuario;
                acordo.DesComentarioUsuario = pAcordo.DesComentarioUsuario;
                acordo.NomContatoFornecedor = pAcordo.NomContatoFornecedor;
                acordo.NumTelefoneContatoFornecedor = pAcordo.NumTelefoneContatoFornecedor;
                acordo.NomCargoContatoFornecedor = pAcordo.NomCargoContatoFornecedor;

                acordo.DtEfetivacaoAcordo = null;
                acordo.DtCancelamentoAcordo = null;
                acordo.NomFuncionarioCancelamento = null;
                acordo.DtCadastroAcordo = DateTime.Now;
                acordo.INDASCARDFRNPMS = null;
                acordo.INDTRNVLRARDCMCRCB = null;
                acordo.DesStatusAcordoComercial = null;

                acordo.Recebimentos = new List<AcordoRecebimento>();
                foreach (var item in pAcordo.Recebimentos)
                {
                    acordo.Recebimentos.Add(new AcordoRecebimento()
                    {
                        CodEmpresa = acordo.CodEmpresa,
                        CodFilialEmpresa = acordo.CodFilialEmpresa,
                        DtPrevisaoRecebimento = item.DtPrevisaoRecebimento,
                        //CodPromessa = acordo.CodPromessa,
                        CodFormaRecebimento = item.CodFormaRecebimento,
                        CodDestinoObjetivo = destino.CodDestinoObjetivo,
                        DtNegociacaoAcordo = acordo.DtNegociacaoAcordo,
                        VlrNegociado = destino.VlrVerba,
                        VlrPago = 0,
                        VlrEfetivo = destino.VlrVerba,
                        NomDestinoObjetivo = destino.NomDestinoObjetivo
                    });
                }

                AcordoBLL.Insert(acordo);

                foreach (Carimbo carimbo in carimbosList.Where(p => p.CodDestinoObjetivo == destino.CodDestinoObjetivo))
                {
                    carimbo.CodStatusCarimbo = 2; //2 = "Assinado"
                    carimbo.CodPromessa = acordo.CodPromessa;
                    carimbo.DtNegociacaoPromessa = acordo.DtNegociacaoAcordo;
                    CarimboBLL.Update(carimbo.CodCarimbo.Value, carimbo);
                }


                destino.CodPromessa = acordo.CodPromessa;

                NegociacaoVerbaDestinoBLL.Update(destino.CodNegociacaoVerba.Value, destino.CodDestinoObjetivo.Value, destino);

                list.Add(acordo);
            }

            NegociacaoVerbaDAL.UpdateStatus(codNegociacaoVerba, 3);

            NegociacaoVerbaHistorico hst = new NegociacaoVerbaHistorico();
            hst.CodFuncionario = codUsuario;
            hst.CodNegociacaoVerba = codNegociacaoVerba;
            hst.CodStatusNegociacaoVenda = 3;
            hst.DtHistorico = DateTime.Now;
            NegociacaoVerbaHistoricoBLL.Insert(hst);

            return list;
        }
    }
}