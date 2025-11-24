using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using Marketing.GestaoVerbasAPI.Models;

namespace Marketing.GestaoVerbasAPI.App_Code.DAL
{
    public class EmailDestinatarioDAL
    {
        public static EmailDestinatario Insert(EmailDestinatario obj)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"INSERT INTO MRT.T0134282
                                  ( TIPMSGCREETN
                                   ,NUMSEQMSGCREETN
                                   ,TIPENDCREETN
                                   ,NUMSEQENDCREETN
                                   ,IDTENDCREETN)
                            VALUES( ");
            sql.Append(" ").Append(obj.TipoMensagem).AppendLine();
            sql.Append(", ").Append(obj.NumSeqEmail).AppendLine();
            sql.Append(", ").Append(obj.TipoEndereco).AppendLine();
            sql.Append(", ").Append(obj.NumSeqEndereco).AppendLine();
            sql.Append(", '").Append(obj.DesEmail.Trim()).AppendLine("'");
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