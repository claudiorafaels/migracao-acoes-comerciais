using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.DAL
{
    public class NegociacaoVerbaHistoricoDAL
    {
        public static List<NegociacaoVerbaHistorico> ListPorNegociacao(int codigoNegociacao)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT HST.CODNGC
                              , HST.DATHRAGRCHST
                              , HST.CODSTANGCFRN
                              , HST.CODFNC
                              , HST.DESOBSSLC
                              , FUN.NOMFNC
                           FROM MRT.HSTNGCVBAFRN HST
                           INNER JOIN MRT.T0100361 FUN ON FUN.CODFNC = HST.CODFNC
                          WHERE HST.CODNGC = ").AppendLine(codigoNegociacao.ToString().Replace(",","."));
            sql.AppendLine(" ORDER BY HST.DATHRAGRCHST ");

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();

            List<NegociacaoVerbaHistorico> list = new List<NegociacaoVerbaHistorico>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    NegociacaoVerbaHistorico obj = new NegociacaoVerbaHistorico();
                    if (!row.IsNull("CODNGC"))
                        obj.CodNegociacaoVerba = int.Parse((row["CODNGC"]).ToString());
                    if (!row.IsNull("DATHRAGRCHST"))
                        obj.DtHistorico = DateTime.Parse((row["DATHRAGRCHST"]).ToString());
                    if (!row.IsNull("CODSTANGCFRN"))
                        obj.CodStatusNegociacaoVenda = int.Parse((row["CODSTANGCFRN"]).ToString());
                    if (!row.IsNull("CODFNC"))
                        obj.CodFuncionario = int.Parse((row["CODFNC"]).ToString());
                    if (!row.IsNull("NOMFNC"))
                        obj.NomFuncionario = row["NOMFNC"].ToString();
                    if (!row.IsNull("DESOBSSLC"))
                        obj.DesJustificativaReprovacao = row["DESOBSSLC"].ToString().TrimStart().TrimEnd();
                    list.Add(obj);
                }
            }
            return list;
        }

        public static NegociacaoVerbaHistorico Insert(NegociacaoVerbaHistorico obj)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"INSERT INTO MRT.HSTNGCVBAFRN 
                                   ( CODNGC
                                   , DATHRAGRCHST
                                   , CODSTANGCFRN
                                   , CODFNC
                                   , DESOBSSLC
                                   )");
            sql.Append("  VALUES( ").AppendLine(obj.CodNegociacaoVerba.ToString());
            sql.Append(", TO_DATE('").Append(obj.DtHistorico.GetValueOrDefault().ToString("yyyy-MM-dd HH:mm:ss")).AppendLine("', 'yyyy-mm-dd hh24:mi:ss')");
            sql.Append(", ").AppendLine(obj.CodStatusNegociacaoVenda.ToString());
            sql.Append(", ").AppendLine(obj.CodFuncionario.ToString());
            if (obj.DesJustificativaReprovacao == null)
                sql.Append(", null").AppendLine();
            else
                sql.Append(", '").Append(obj.DesJustificativaReprovacao.Trim()).AppendLine("'");
            sql.Append(")");

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();
        
            var ret = cmd.ExecuteScalar();

            if (ret != null)
                throw new Exception(ret.ToString());

            return obj;
        }
    }
}