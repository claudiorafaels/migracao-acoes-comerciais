using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.DAL
{
    public class AcordoRecebimentoDAL
    {


        public static AcordoRecebimento Insert(AcordoRecebimento obj)
        {

            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"INSERT INTO MRT.T0118066
                                  ( CODEMP
                                  , CODFILEMP
                                  , CODPMS
                                  , DATPRVRCBPMS
                                  , TIPFRMDSCBNF
                                  , TIPDSNDSCBNF
                                  , DATNGCPMS
                                  , VLRNGCPMS
                                  , VLRPGOPMS
                                  , VLREFTPMS
                                  , VLRNGCPMSANTARR
                                  , VLRPDAPMS
                                  , VLRRCTPMS
                                  , INDASCARDFRNPMS
                                  ) VALUES (");
            sql.Append(" ").Append(obj.CodEmpresa).AppendLine();
            sql.Append(", ").Append(obj.CodFilialEmpresa).AppendLine();
            sql.Append(", ").Append(obj.CodPromessa).AppendLine();
            sql.Append(", TO_DATE('").Append(obj.DtPrevisaoRecebimento.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'yyyy-mm-dd')").AppendLine();
            sql.Append(", ").Append(obj.CodFormaRecebimento).AppendLine();
            sql.Append(", ").Append(obj.CodDestinoObjetivo).AppendLine();
            sql.Append(", TO_DATE('").Append(obj.DtNegociacaoAcordo.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'yyyy-mm-dd')").AppendLine();
            sql.Append(", ").Append(obj.VlrNegociado.ToString().Replace(",", ".")).AppendLine();
            if (obj.VlrPago == null)
                sql.Append(", NULL").AppendLine();
            else
                sql.Append(", ").Append(obj.VlrPago.ToString().Replace(",", ".")).AppendLine();

            if (obj.VlrEfetivo == null)
                sql.Append(", NULL").AppendLine();
            else
                sql.Append(", ").Append(obj.VlrEfetivo.ToString().Replace(",", ".")).AppendLine();
            
            if (obj.VLRNGCPMSANTARR == null)
                sql.Append(", NULL").AppendLine();
            else
                sql.Append(", ").Append(obj.VLRNGCPMSANTARR.ToString().Replace(",", ".")).AppendLine();

            if (obj.VLRPDAPMS == null)
                sql.Append(", NULL").AppendLine();
            else
                sql.Append(", ").Append(obj.VLRPDAPMS.ToString().Replace(",", ".")).AppendLine();

            if (obj.VLRRCTPMS == null)
                sql.Append(", NULL").AppendLine();
            else
                sql.Append(", ").Append(obj.VLRRCTPMS.ToString().Replace(",", ".")).AppendLine();

            if (obj.INDASCARDFRNPMS == null)
                sql.Append(", NULL").AppendLine();
            else
                sql.Append(", ").Append(obj.INDASCARDFRNPMS).AppendLine();

            sql.AppendLine(")");

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();
            var ret = cmd.ExecuteScalar();
            if (ret != null)
                throw new Exception(ret.ToString());

            return obj;
        }
    }
}