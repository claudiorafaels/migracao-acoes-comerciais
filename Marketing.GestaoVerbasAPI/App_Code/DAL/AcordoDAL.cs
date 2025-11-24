using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.DAL
{
    public class AcordoDAL
    {
        public static Acordo Select(int CodEmpresa, int CodFilialEmpresa, int CodPromessa, DateTime DtNegociacaoAcordo)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT PMS.CODEMP").AppendLine();
            sql.Append("     , PMS.CODFILEMP").AppendLine();
            sql.Append("     , PMS.CODPMS").AppendLine();
            sql.Append("     , PMS.DATNGCPMS").AppendLine();
            sql.Append("     , PMS.CODSITPMS").AppendLine();
            sql.Append("     , PMS.NUMPEDCMP").AppendLine();
            sql.Append("     , PMS.CODFRN").AppendLine();
            sql.Append("     , PMS.NOMACSUSRSIS").AppendLine();
            sql.Append("     , PMS.DESMSGUSR").AppendLine();
            sql.Append("     , PMS.NOMCTOFRN").AppendLine();
            sql.Append("     , PMS.NUMTLFCTOFRN").AppendLine();
            sql.Append("     , PMS.DESCGRCTOFRN").AppendLine();
            sql.Append("     , PMS.DATEFTPMS").AppendLine();
            sql.Append("     , PMS.DATCNCPED").AppendLine();
            sql.Append("     , PMS.NOMUSRCNCPED").AppendLine();
            sql.Append("     , PMS.DATCADPMS").AppendLine();
            sql.Append("     , PMS.INDASCARDFRNPMS").AppendLine();
            sql.Append("     , PMS.INDTRNVLRARDCMCRCB").AppendLine();
            sql.Append("     , PMS.DESSTAARDCMC").AppendLine();
            sql.Append("  FROM MRT.T0118058 PMS").AppendLine();
            sql.Append(" WHERE PMS.CODEMP").Append(CodEmpresa).AppendLine();
            sql.Append("   AND PMS.CODFILEMP").Append(CodFilialEmpresa).AppendLine();
            sql.Append("   AND PMS.CODPMS").Append(CodPromessa).AppendLine();
            sql.Append("   AND PMS.DATNGCPMS").Append(DtNegociacaoAcordo).AppendLine();


            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();

            Acordo obj = null;

            if (dt != null && dt.Rows.Count == 1)
            {
                obj = new Acordo();
                DataRow row = dt.Rows[0];
                if (!row.IsNull("CODEMP"))
                    obj.CodEmpresa = int.Parse((row["CODEMP"]).ToString());
                if (!row.IsNull("CODFILEMP"))
                    obj.CodFilialEmpresa = int.Parse((row["CODFILEMP"]).ToString());
                if (!row.IsNull("CODPMS"))
                    obj.CodPromessa = int.Parse((row["CODPMS"]).ToString());
                if (!row.IsNull("DATNGCPMS"))
                    obj.DtNegociacaoAcordo = DateTime.Parse((row["DATNGCPMS"]).ToString());
                if (!row.IsNull("CODSITPMS"))
                    obj.CodStatusAcordo = int.Parse((row["CODSITPMS"]).ToString());
                if (!row.IsNull("NUMPEDCMP"))
                    obj.NumPedidoCompra = int.Parse((row["NUMPEDCMP"]).ToString());
                if (!row.IsNull("CODFRN"))
                    obj.CodFornecedor = int.Parse((row["CODFRN"]).ToString());
                if (!row.IsNull("NOMACSUSRSIS"))
                    obj.NomUsuario = row["NOMACSUSRSIS"].ToString().TrimStart().TrimEnd();
                if (!row.IsNull("DESMSGUSR"))
                    obj.DesComentarioUsuario = row["DESMSGUSR"].ToString().TrimStart().TrimEnd();
                if (!row.IsNull("NOMCTOFRN"))
                    obj.NomContatoFornecedor = row["NOMCTOFRN"].ToString().TrimStart().TrimEnd();
                if (!row.IsNull("NUMTLFCTOFRN"))
                    obj.NumTelefoneContatoFornecedor = row["NUMTLFCTOFRN"].ToString().TrimStart().TrimEnd();
                if (!row.IsNull("DESCGRCTOFRN"))
                    obj.NomCargoContatoFornecedor = row["DESCGRCTOFRN"].ToString().TrimStart().TrimEnd();
                if (!row.IsNull("DATEFTPMS"))
                    obj.DtEfetivacaoAcordo = DateTime.Parse((row["DATEFTPMS"]).ToString());
                if (!row.IsNull("DATCNCPED"))
                    obj.DtCancelamentoAcordo = DateTime.Parse((row["DATCNCPED"]).ToString());
                if (!row.IsNull("NOMUSRCNCPED"))
                    obj.NomFuncionarioCancelamento = row["NOMUSRCNCPED"].ToString().TrimStart().TrimEnd();
                if (!row.IsNull("DATCADPMS"))
                    obj.DtCadastroAcordo = DateTime.Parse((row["DATCADPMS"]).ToString());
                if (!row.IsNull("INDASCARDFRNPMS"))
                    obj.INDASCARDFRNPMS = int.Parse((row["INDASCARDFRNPMS"]).ToString());
                if (!row.IsNull("INDTRNVLRARDCMCRCB"))
                    obj.INDTRNVLRARDCMCRCB = int.Parse((row["INDTRNVLRARDCMCRCB"]).ToString());
                if (!row.IsNull("DESSTAARDCMC"))
                    obj.DesStatusAcordoComercial = row["DESSTAARDCMC"].ToString().TrimStart().TrimEnd();
            }
            return obj;
        }


        public static List<Acordo> ListPorNegociacao(int codNegociacaoVerba)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT PMS.CODEMP").AppendLine();
            sql.Append("     , PMS.CODFILEMP").AppendLine();
            sql.Append("     , PMS.CODPMS").AppendLine();
            sql.Append("     , PMS.DATNGCPMS").AppendLine();
            sql.Append("     , PMS.CODSITPMS").AppendLine();
            sql.Append("     , PMS.NUMPEDCMP").AppendLine();
            sql.Append("     , PMS.CODFRN").AppendLine();
            sql.Append("     , PMS.NOMACSUSRSIS").AppendLine();
            sql.Append("     , PMS.DESMSGUSR").AppendLine();
            sql.Append("     , PMS.NOMCTOFRN").AppendLine();
            sql.Append("     , PMS.NUMTLFCTOFRN").AppendLine();
            sql.Append("     , PMS.DESCGRCTOFRN").AppendLine();
            sql.Append("     , PMS.DATEFTPMS").AppendLine();
            sql.Append("     , PMS.DATCNCPED").AppendLine();
            sql.Append("     , PMS.NOMUSRCNCPED").AppendLine();
            sql.Append("     , PMS.DATCADPMS").AppendLine();
            sql.Append("     , PMS.INDASCARDFRNPMS").AppendLine();
            sql.Append("     , PMS.INDTRNVLRARDCMCRCB").AppendLine();
            sql.Append("     , PMS.DESSTAARDCMC").AppendLine();
            sql.Append("     , NGC.VLRVBAFRN").AppendLine();
            sql.Append("     , EMP.DESDSNDSCBNF").AppendLine();
            sql.Append("  FROM MRT.T0118058 PMS").AppendLine();
            sql.Append("   INNER JOIN MRT.RLCNGCVBAFRNDSN NGC ON NGC.CODPMS = PMS.CODPMS").AppendLine();
            sql.Append("   INNER JOIN MRT.T0109059 EMP ON EMP.TIPDSNDSCBNF = NGC.TIPDSNDSCBNF").AppendLine();
            sql.Append(" WHERE NGC.CODNGC = ").Append(codNegociacaoVerba).AppendLine();


            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();

            List<Acordo> list = new List<Acordo>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Acordo obj = new Acordo();
                    if (!row.IsNull("CODPMS"))
                        obj.CodPromessa = int.Parse((row["CODPMS"]).ToString());
                    if (!row.IsNull("NUMPEDCMP"))
                        obj.NumPedidoCompra = int.Parse((row["NUMPEDCMP"]).ToString());
                    if (!row.IsNull("DATCADPMS"))
                        obj.DtCadastroAcordo = DateTime.Parse((row["DATCADPMS"]).ToString());
                    if (!row.IsNull("CODSITPMS"))
                        obj.CodStatusAcordo = int.Parse((row["CODSITPMS"]).ToString());
                    if (!row.IsNull("DESDSNDSCBNF"))
                    {
                        if (obj.Recebimentos == null)
                        {
                            obj.Recebimentos = new List<AcordoRecebimento>();
                            obj.Recebimentos.Add(new AcordoRecebimento() { NomDestinoObjetivo = row["DESDSNDSCBNF"].ToString().TrimStart().TrimEnd() });
                        }
                        else
                            obj.Recebimentos[0].NomDestinoObjetivo = row["DESDSNDSCBNF"].ToString().TrimStart().TrimEnd();

                    }
                    if (!row.IsNull("VLRVBAFRN"))
                    {
                        if (obj.Recebimentos == null)
                        {
                            obj.Recebimentos = new List<AcordoRecebimento>();
                            obj.Recebimentos.Add(new AcordoRecebimento() { VlrNegociado = decimal.Parse((row["VLRVBAFRN"]).ToString()) });
                        }
                        else
                            obj.Recebimentos[0].VlrNegociado = decimal.Parse((row["VLRVBAFRN"]).ToString());
                    }

                    list.Add(obj);
                }
            }
            return list;
        }

        public static int NextCodPromessa()
        {
            Command cmd = new Command();
            cmd.CommandText = @"UPDATE MRT.T0118074 
                                   SET CODULTUTZPMS = CODULTUTZPMS + 1
                                     , DATREFPCSPEDCMP = TO_DATE(TO_CHAR(SYSDATE,'YYYY-MM-DD'),'YYYY-MM-DD')
                                 WHERE CODEMP = 1 
                                   AND CODFILEMP = 1";
            cmd.ExecuteScalar();

            cmd.CommandText = @"SELECT CODULTUTZPMS as NextVal
                                  FROM MRT.T0118074
                                 WHERE CODEMP = 1
                                   AND CODFILEMP = 1";
            DataTable dt = cmd.GetData();

            int NextVal = 1;
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                if (!row.IsNull("NextVal"))
                    NextVal = int.Parse((row["NextVal"]).ToString());
            }
            return NextVal;
        }

        public static Acordo Insert(Acordo obj)
        {
            obj.CodPromessa = NextCodPromessa();

            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"INSERT INTO MRT.T0118058
                                  ( CODEMP
                                  , CODFILEMP
                                  , CODPMS
                                  , DATNGCPMS
                                  , CODSITPMS
                                  , NUMPEDCMP
                                  , CODFRN
                                  , NOMACSUSRSIS
                                  , DESMSGUSR
                                  , NOMCTOFRN
                                  , NUMTLFCTOFRN
                                  , DESCGRCTOFRN
                                  , DATEFTPMS
                                  , DATCNCPED
                                  , NOMUSRCNCPED
                                  , DATCADPMS
                                  , INDASCARDFRNPMS
                                  , INDTRNVLRARDCMCRCB
                                  , DESSTAARDCMC
                                  ) VALUES (");
            sql.Append(" ").Append(obj.CodEmpresa).AppendLine();
            sql.Append(", ").Append(obj.CodFilialEmpresa).AppendLine();
            sql.Append(", ").Append(obj.CodPromessa).AppendLine();
            sql.Append(", TO_DATE('").Append(obj.DtNegociacaoAcordo.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'yyyy-mm-dd')").AppendLine();
            sql.Append(", ").Append(obj.CodStatusAcordo).AppendLine();
            if (obj.NumPedidoCompra == null)
                sql.Append(", NULL").AppendLine();
            else
                sql.Append(", ").Append(obj.NumPedidoCompra).AppendLine();
            sql.Append(", ").Append(obj.CodFornecedor).AppendLine();
            sql.Append(", '").Append(obj.NomUsuario.Trim()).AppendLine("'");
            if (string.IsNullOrEmpty(obj.DesComentarioUsuario))
                sql.Append(", NULL").AppendLine();
            else
                sql.Append(", '").Append(obj.DesComentarioUsuario.Trim()).AppendLine("'");

            if (string.IsNullOrEmpty(obj.NomContatoFornecedor))
                sql.Append(", NULL").AppendLine();
            else
                sql.Append(", '").Append(obj.NomContatoFornecedor.Trim()).AppendLine("'");

            if (string.IsNullOrEmpty(obj.NumTelefoneContatoFornecedor))
                sql.Append(", NULL").AppendLine();
            else
                sql.Append(", '").Append(obj.NumTelefoneContatoFornecedor.Trim()).AppendLine("'");

            if (string.IsNullOrEmpty(obj.NomCargoContatoFornecedor))
                sql.Append(", NULL").AppendLine();
            else
                sql.Append(", '").Append(obj.NomCargoContatoFornecedor.Trim()).AppendLine("'");

            if (obj.DtEfetivacaoAcordo == null)
                sql.Append(", NULL").AppendLine();
            else
                sql.Append(", TO_DATE('").Append(obj.DtEfetivacaoAcordo.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'yyyy-mm-dd')").AppendLine();

            if (obj.DtEfetivacaoAcordo == null)
                sql.Append(", NULL").AppendLine();
            else
                sql.Append(", TO_DATE('").Append(obj.DtCancelamentoAcordo.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'yyyy-mm-dd')").AppendLine();

            if (string.IsNullOrEmpty(obj.NomFuncionarioCancelamento))
                sql.Append(",  NULL").AppendLine();
            else
                sql.Append(", '").Append(obj.NomFuncionarioCancelamento.Trim()).AppendLine("'");

            sql.Append(", TO_DATE('").Append(obj.DtCadastroAcordo.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'yyyy-mm-dd')").AppendLine();

            if (obj.INDASCARDFRNPMS == null)
                sql.Append(", NULL").AppendLine();
            else
                sql.Append(", ").Append(obj.INDASCARDFRNPMS).AppendLine();

            if (obj.INDTRNVLRARDCMCRCB == null)
                sql.Append(", NULL").AppendLine();
            else
                sql.Append(", ").Append(obj.INDTRNVLRARDCMCRCB).AppendLine();

            if (string.IsNullOrEmpty(obj.DesStatusAcordoComercial))
                sql.Append(", NULL").AppendLine();
            else
                sql.Append(", '").Append(obj.DesStatusAcordoComercial.Trim()).AppendLine("'");


            sql.AppendLine(")");

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();
            var ret = cmd.ExecuteScalar();
            if (ret != null)
                throw new Exception(ret.ToString());

            return obj;
        }

        public static void Update(int CodEmpresa, int CodFilialEmpresa, int CodPromessa, DateTime DtNegociacaoAcordo, Acordo obj)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(@"UPDATE MRT.T0118058");
            sql.Append("SET CODSITPMS = ").Append(obj.CodStatusAcordo).AppendLine();
            sql.Append(", NUMPEDCMP = ").Append(obj.NumPedidoCompra).AppendLine();
            sql.Append(", CODFRN = ").Append(obj.CodFornecedor).AppendLine();
            sql.Append(", NOMACSUSRSIS = ").Append(obj.NomUsuario.Trim()).AppendLine();
            if (string.IsNullOrEmpty(obj.DesComentarioUsuario))
                sql.Append(", DESMSGUSR = NULL").AppendLine();
            else
                sql.Append(", DESMSGUSR = ").Append(obj.DesComentarioUsuario.Trim()).AppendLine();

            if (string.IsNullOrEmpty(obj.NomContatoFornecedor))
                sql.Append(", NOMCTOFRN = NULL").AppendLine();
            else
                sql.Append(", NOMCTOFRN = '").Append(obj.NomContatoFornecedor.Trim()).AppendLine("'");

            if (string.IsNullOrEmpty(obj.NumTelefoneContatoFornecedor))
                sql.Append(", NUMTLFCTOFRN = NULL").AppendLine();
            else
                sql.Append(", NUMTLFCTOFRN = '").Append(obj.NumTelefoneContatoFornecedor.Trim()).AppendLine("'");

            if (string.IsNullOrEmpty(obj.NomCargoContatoFornecedor))
                sql.Append(", DESCGRCTOFRN = NULL").AppendLine();
            else
                sql.Append(", DESCGRCTOFRN = '").Append(obj.NomCargoContatoFornecedor.Trim()).AppendLine("'");

            if (obj.DtEfetivacaoAcordo == null)
                sql.Append(", DATEFTPMS = NULL").AppendLine();
            else
                sql.Append(", DATEFTPMS = TO_DATE('").Append(obj.DtEfetivacaoAcordo.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'yyyy-mm-dd')").AppendLine();

            if (obj.DtEfetivacaoAcordo == null)
                sql.Append(", DATCNCPED = NULL").AppendLine();
            else
                sql.Append(", DATCNCPED = TO_DATE('").Append(obj.DtCancelamentoAcordo.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'yyyy-mm-dd')").AppendLine();

            if (string.IsNullOrEmpty(obj.NomFuncionarioCancelamento))
                sql.Append(", NOMUSRCNCPED = NULL").AppendLine();
            else
                sql.Append(", NOMUSRCNCPED = '").Append(obj.NomFuncionarioCancelamento.Trim()).AppendLine("'");

            if (obj.INDASCARDFRNPMS == null)
                sql.Append(", INDASCARDFRNPMS = NULL").AppendLine();
            else
                sql.Append(", INDASCARDFRNPMS = ").Append(obj.INDASCARDFRNPMS).AppendLine();

            if (obj.INDTRNVLRARDCMCRCB == null)
                sql.Append(", INDTRNVLRARDCMCRCB = NULL").AppendLine();
            else
                sql.Append(", INDTRNVLRARDCMCRCB = ").Append(obj.INDTRNVLRARDCMCRCB).AppendLine();

            if (string.IsNullOrEmpty(obj.DesStatusAcordoComercial))
                sql.Append(", DESSTAARDCMC = NULL").AppendLine();
            else
                sql.Append(", DESSTAARDCMC = '").Append(obj.DesStatusAcordoComercial.Trim()).AppendLine("'");



            sql.Append("      WHERE CODEMP = ").Append(CodEmpresa).AppendLine();
            sql.Append("        AND CODFILEMP = ").Append(CodFilialEmpresa).AppendLine();
            sql.Append("        AND CODPMS = ").Append(CodPromessa).AppendLine();
            sql.Append("        AND DATNGCPMS = TO_DATE('").Append(DtNegociacaoAcordo.ToString("yyyy-MM-dd")).Append("', 'yyyy-mm-dd')").AppendLine();
            Command cmd = new Command();
            cmd.CommandText = sql.ToString();


            var ret = cmd.ExecuteScalar();
            if (ret != null)
                throw new Exception(ret.ToString());
        }

        public static void Delete(int CodEmpresa, int CodFilialEmpresa, int CodPromessa, DateTime DtNegociacaoAcordo)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE FROM MRT.T0118058").AppendLine();
            sql.Append("      WHERE CODEMP = ").Append(CodEmpresa).AppendLine();
            sql.Append("        AND CODFILEMP = ").Append(CodFilialEmpresa).AppendLine();
            sql.Append("        AND CODPMS = ").Append(CodPromessa).AppendLine();
            sql.Append("        AND DATNGCPMS = TO_DATE('").Append(DtNegociacaoAcordo.ToString("yyyy-MM-dd")).Append("', 'yyyy-mm-dd')").AppendLine();
            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            var ret = cmd.ExecuteScalar();

            if (ret != null)
                throw new Exception(ret.ToString());
        }

        public static List<Acordo> SelectPKPdf(int codPromessa)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(" SELECT PMS.CODPMS ");
            sql.AppendLine("      , PMS.DATNGCPMS "); 
            sql.AppendLine("      , PMS.CODFILEMP "); 
            sql.AppendLine("      , PMS.NUMPEDCMP "); 
            sql.AppendLine("      , PMS.DESMSGUSR "); 
            sql.AppendLine("      , PMS.CODEMP ");  
            sql.AppendLine("      , PMS.NOMCTOFRN "); 
            sql.AppendLine("      , PMS.CODFRN "); 
            sql.AppendLine("      , FRN.NOMFRN "); 
            sql.AppendLine("      , RCB.DATPRVRCBPMS "); 
            sql.AppendLine("      , RCB.TIPFRMDSCBNF "); 
            sql.AppendLine("      , FPG.DESFRMDSCBNF "); 
            sql.AppendLine("      , RCB.VLRPGOPMS");  
            sql.AppendLine("      , RCB.VLREFTPMS "); 
            sql.AppendLine("      , EMP.DESDSNDSCBNF "); 
            sql.AppendLine("      , NGC.TIPDSNDSCBNF "); 
            sql.AppendLine("FROM MRT.T0118058 PMS ");
            sql.AppendLine("INNER JOIN MRT.T0118066 RCB ON RCB.CODPMS = pms.CODPMS ");
            sql.AppendLine("INNER JOIN MRT.T0113552 FPG ON FPG.TIPFRMDSCBNF = RCB.TIPFRMDSCBNF ");
            sql.AppendLine("INNER JOIN MRT.T0100426 FRN ON FRN.CODFRN = pms.CODFRN ");
            sql.AppendLine("INNER JOIN MRT.RLCNGCVBAFRNDSN NGC ON NGC.CODPMS = PMS.CODPMS ");
            sql.AppendLine("INNER JOIN MRT.T0109059 EMP ON EMP.TIPDSNDSCBNF = NGC.TIPDSNDSCBNF ");
            sql.Append("WHERE PMS.CODPMS = ").Append(codPromessa).AppendLine();

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();

            List<Acordo> list = new List<Acordo>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Acordo obj = new Acordo();
                    if (!row.IsNull("CODPMS"))
                        obj.CodPromessa = int.Parse((row["CODPMS"]).ToString());
                    if (!row.IsNull("NUMPEDCMP"))
                        obj.NumPedidoCompra = int.Parse((row["NUMPEDCMP"]).ToString());
                    if (!row.IsNull("DATNGCPMS"))
                        obj.DtCadastroAcordo = DateTime.Parse((row["DATNGCPMS"]).ToString());
                    if (!row.IsNull("CODFILEMP"))
                        obj.CodFilialEmpresa = int.Parse((row["CODFILEMP"]).ToString());
                    if (!row.IsNull("DESMSGUSR"))
                        obj.DesComentarioUsuario = (row["DESMSGUSR"]).ToString();
                    if (!row.IsNull("CODEMP"))
                        obj.CodEmpresa = int.Parse((row["CODEMP"]).ToString());
                    if (!row.IsNull("NOMCTOFRN"))
                        obj.NomContatoFornecedor = (row["NOMCTOFRN"]).ToString();
                    if (!row.IsNull("CODFRN"))
                        obj.CodFornecedor = int.Parse((row["CODFRN"]).ToString());
                    if (!row.IsNull("NOMFRN"))
                        obj.NomFornecedor = (row["NOMFRN"]).ToString();
                    
                    if (obj.Recebimentos == null)
                    {
                        obj.Recebimentos = new List<AcordoRecebimento>();
                        obj.Recebimentos.Add(new AcordoRecebimento() );
                    }
                    if (!row.IsNull("DESDSNDSCBNF"))
                    {
                            obj.Recebimentos[0].NomDestinoObjetivo = string.Format("{0} - {1}", row["TIPDSNDSCBNF"].ToString(), row["DESDSNDSCBNF"].ToString()).TrimStart().TrimEnd();
                    }    
                    if (!row.IsNull("DATPRVRCBPMS"))
                        obj.Recebimentos[0].DtPrevisaoRecebimento = DateTime.Parse((row["DATPRVRCBPMS"]).ToString());
                    
                    if (!row.IsNull("TIPFRMDSCBNF"))
                        obj.Recebimentos[0].CodFormaRecebimento = int.Parse((row["TIPFRMDSCBNF"]).ToString());
                    if (!row.IsNull("DESFRMDSCBNF"))

                        obj.Recebimentos[0].NomFormaRecebimento = (row["DESFRMDSCBNF"]).ToString();
                    
                    if (!row.IsNull("VLRPGOPMS"))
                        obj.Recebimentos[0].VlrPago = decimal.Parse((row["VLRPGOPMS"]).ToString());
                    
                    if (!row.IsNull("VLREFTPMS"))
                        obj.Recebimentos[0].VlrEfetivo = decimal.Parse((row["VLREFTPMS"]).ToString());

                    list.Add(obj);
                }
            }
            return list;
        }
    }
}