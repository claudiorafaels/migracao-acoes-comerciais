using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.DAL
{
    public class EmailCapaDAL
    {
        public static int NextSeqEmail()
        {
            Command cmd = new Command();
            cmd.CommandText = @"SELECT NVL(MAX(NUMSEQMSGCREETN) + 1, 1) AS NEXTVAL FROM MRT.T0134274 WHERE TIPMSGCREETN = 95";

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

        public static EmailCapa Insert(EmailCapa obj)
        {
            obj.NumSeqEmail = NextSeqEmail();
            obj.TipoMensagem = 95;

            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"INSERT INTO MRT.T0134274
                                     (  TIPMSGCREETN
                                      , NUMSEQMSGCREETN
                                      , DATENVMSGCREETN
                                      , DESASSCREETN)
                               VALUES(");
            sql.Append(" ").AppendLine(obj.TipoMensagem.ToString());
            sql.Append(", ").AppendLine(obj.NumSeqEmail.ToString());
            sql.Append(", TO_DATE('").Append(obj.DataEnvio.GetValueOrDefault().ToString("yyyy-MM-dd")).AppendLine("', 'yyyy-mm-dd')");
            sql.Append(", '").Append(obj.Assunto.Trim()).AppendLine("'");
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