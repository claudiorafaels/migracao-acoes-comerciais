using Marketing.GestaoVerbasAPI.App_Code.Connection;
using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.DAL
{
    public class GrupoADMenuDAL
    {
        public static string siglaSistema = "DJ";
        public static GrupoADMenu Insert(GrupoADMenu obj)
        {

            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"INSERT INTO MRT.RLCGRPACSSISMNU
                                     ( NOMSISINF
                                     , CODGRPACS
                                     , CODMNU)
                               VALUES( ");
            sql.Append(" '").Append(siglaSistema).AppendLine("'");
            sql.Append(", ").Append(obj.CodGrupoAcesso).AppendLine();
            sql.Append(", '").Append(obj.CodMenu).AppendLine("')");

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();
            var ret = cmd.ExecuteScalar();
            if (ret != null)
                throw new Exception(ret.ToString());

            return obj;
        }

        public static void Delete(int pCodGrupoAcesso, string pCodMenu)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"DELETE FROM MRT.RLCGRPACSSISMNU").AppendLine();
            sql.Append("  WHERE NOMSISINF = '").Append(siglaSistema).AppendLine("'");
            sql.Append("    AND CODGRPACS = ").Append(pCodGrupoAcesso).AppendLine();
            sql.Append("    AND CODMNU = '").Append(pCodMenu).AppendLine("'");

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            var ret = cmd.ExecuteScalar();

            if (ret != null)
                throw new Exception(ret.ToString());
        }

        public static GrupoADMenu Select(int? pCodGrupoAcesso, string pCodMenu)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"SELECT MNU.CODGRPACS
                              , MNU.CODMNU
                           FROM MRT.RLCGRPACSSISMNU MNU
                          WHERE MNU.NOMSISINF =  '").Append(siglaSistema).AppendLine("'");
            sql.Append("    AND MNU.CODMNU = ").Append(pCodMenu).AppendLine();
            sql.Append("    AND MNU.CODGRPACS = '").Append(pCodGrupoAcesso).AppendLine("'");

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();

            GrupoADMenu obj = null;

            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                obj = new GrupoADMenu();
                if (!row.IsNull("CODGRPACS"))
                    obj.CodGrupoAcesso = int.Parse((row["CODGRPACS"]).ToString());
                if (!row.IsNull("CODMNU"))
                    obj.CodMenu = row["CODMNU"].ToString().Trim();
            }
            return obj;
        }
    }

}