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
    public class GrupoADDAO
    {
        public static string siglaSistema = "DJ";
        public static ListResult<GrupoAD> List(int pagina, int tamanho, string coluna, string sentido, GrupoAD filtro)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"SELECT GRP.NOMSISINF
                                  , GRP.CODGRPACS
                                  , GRP.DESGRPACS
                                  , GRP.DESGRPRDE  
                               FROM MRT.CADGRPACSSIS GRP
                              WHERE GRP.NOMSISINF = '").Append(siglaSistema).AppendLine("'");    // 

            if (filtro.CodGrupoAcesso != null)
                sql.Append("AND GRP.CODGRPACS= ").Append(filtro.CodGrupoAcesso).AppendLine();
            if (!string.IsNullOrWhiteSpace(filtro.NomGrupoAcesso))
                sql.Append("AND GRP.DESGRPACS LIKE '%").Append(filtro.NomGrupoAcesso.TrimStart().TrimEnd()).AppendLine("%'");
            if (!string.IsNullOrWhiteSpace(filtro.DesGrupoAcesso))
                sql.Append("AND GRP.DESGRPRDE LIKE '%").Append(filtro.DesGrupoAcesso.TrimStart().TrimEnd()).AppendLine("%'");

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();


            List<GrupoAD> list = new List<GrupoAD>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    GrupoAD obj = new GrupoAD();
                    if (!row.IsNull("CODGRPACS"))
                        obj.CodGrupoAcesso = int.Parse((row["CODGRPACS"]).ToString());
                    if (!row.IsNull("DESGRPACS"))
                        obj.NomGrupoAcesso = row["DESGRPACS"].ToString().Trim();
                    if (!row.IsNull("DESGRPRDE"))
                        obj.DesGrupoAcesso = row["DESGRPRDE"].ToString().Trim();
                    list.Add(obj);
                }
            }


            return ListResultadoManager.PaginarLista(list, pagina, tamanho, coluna, sentido);
        }

        public static GrupoAD Select(int pCodGrupoAcesso)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"SELECT GRP.NOMSISINF
                              , GRP.CODGRPACS
                              , GRP.DESGRPACS
                              , GRP.DESGRPRDE  
                           FROM MRT.CADGRPACSSIS GRP
                          WHERE GRP.NOMSISINF = '").Append(siglaSistema).AppendLine("'");
            sql.Append("    AND GRP.CODGRPACS = ").Append(pCodGrupoAcesso).AppendLine();

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();

            GrupoAD obj = null;

            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                obj = new GrupoAD();
                if (!row.IsNull("CODGRPACS"))
                    obj.CodGrupoAcesso = int.Parse((row["CODGRPACS"]).ToString());
                if (!row.IsNull("DESGRPACS"))
                    obj.NomGrupoAcesso = row["DESGRPACS"].ToString().Trim();
                if (!row.IsNull("DESGRPRDE"))
                    obj.DesGrupoAcesso = row["DESGRPRDE"].ToString().Trim();
            }
            return obj;
        }

        public static int NextCodGrupoAcesso()
        {
            Command cmd = new Command();
            cmd.CommandText = @"SELECT NVL(MAX(CODGRPACS) + 1, 1) as NextVal
                                     FROM MRT.CADGRPACSSIS";


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

        public static GrupoAD Insert(GrupoAD obj)
        {

            obj.CodGrupoAcesso = NextCodGrupoAcesso();


            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"INSERT INTO MRT.CADGRPACSSIS
                                     ( NOMSISINF
                                     , CODGRPACS
                                     , DESGRPACS
                                     , DESGRPRDE)
                               VALUES(");
            sql.Append(" '").Append(siglaSistema).AppendLine("'");
            sql.Append(", '").Append(obj.CodGrupoAcesso).AppendLine("'");
            sql.Append(", '").Append(obj.NomGrupoAcesso.ToString().Trim()).AppendLine("'");
            sql.Append(", '").Append(obj.DesGrupoAcesso.ToString().Trim()).AppendLine("'");
            sql.AppendLine(")");

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();
            var ret = cmd.ExecuteScalar();
            if (ret != null)
                throw new Exception(ret.ToString());

            return obj;
        }

        public static void Update(int pCodGrupoAcesso, GrupoAD obj)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"UPDATE MRT.CADGRPACSSIS").AppendLine();
            sql.Append("    SET DESGRPACS = '").Append(obj.NomGrupoAcesso.Trim()).AppendLine("'");
            sql.Append("      , DESGRPRDE = '").Append(obj.DesGrupoAcesso.Trim()).AppendLine("'");
            sql.Append("  WHERE NOMSISINF = '").Append(siglaSistema).AppendLine("'");
            sql.Append("    AND CODGRPACS = '").Append(pCodGrupoAcesso).AppendLine("'");

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            var ret = cmd.ExecuteScalar();
            if (ret != null)
                throw new Exception(ret.ToString());
        }

        public static void Delete(int pCodGrupoAcesso)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"DELETE FROM MRT.CADGRPACSSIS").AppendLine();
            sql.Append("  WHERE NOMSISINF = '").Append(siglaSistema).AppendLine("'");
            sql.Append("    AND CODGRPACS = ").Append(pCodGrupoAcesso).AppendLine();

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            var ret = cmd.ExecuteScalar();

            if (ret != null)
                throw new Exception(ret.ToString());
        }

    }
}