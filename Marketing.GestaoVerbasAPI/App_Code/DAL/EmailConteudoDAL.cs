using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using Marketing.GestaoVerbasAPI.Models;


namespace Marketing.GestaoVerbasAPI.App_Code.DAL
{
    public class EmailConteudoDAL
    {
        public static EmailConteudo Insert(EmailConteudo obj)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"INSERT INTO MRT.T0134290
                                  (  TIPMSGCREETN
                                   , NUMSEQMSGCREETN
                                   , NUMSEQLNHFISCREETN
                                   , DESTXTLNHFISCREETN)
                            VALUES( ");
            sql.Append(" ").Append(obj.TipoMensagem).AppendLine();
            sql.Append(", ").Append(obj.NumSeqEmail).AppendLine();
            sql.Append(", ").Append(obj.NumSeqLinha).AppendLine();
            sql.Append(", '").Append(obj.TextoLinha.Trim()).AppendLine("'");
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