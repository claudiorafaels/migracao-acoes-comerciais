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
    public class MenuDAL
    {
        public static string siglaSistema = "DJ";
        public static ListResult<Menu> List(int pagina, int tamanho, string coluna, string sentido, Menu filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT DISTINCT
                                  MN.CODMNU
                                , MN.DESMNU
                                , CASE WHEN MN.CODMNUPAI = MN.CODMNU THEN '0' ELSE MN.CODMNUPAI END AS CODMNUPAI
                                , CASE WHEN RLC.CODGRPACS IS NULL THEN 0 ELSE 1 END INDASSOCIADO
                           FROM MRT.T0150830 MN
                             INNER JOIN MRT.RLCGRPACSSISMNU RLC ON MN.CODMNU = RLC.CODMNU
                                                               AND RLC.NOMSISINF = MN.NOMSISINF 
                           WHERE MN.CODFILEMP = 1 
                             AND MN.NOMSISINF = '").Append(siglaSistema).AppendLine("'");

            if (filtro.CodGrupoAcesso != null)
                sql.Append("AND RLC.CODGRPACS = ").Append(filtro.CodGrupoAcesso).AppendLine();
            if (filtro.CodMenu != null)
                sql.Append("AND MN.CODMNU = ").Append(filtro.CodMenu).AppendLine();
            if (filtro.CodMenuPai != null)
                sql.Append("AND MN.CODMNUPAI = ").Append(filtro.CodMenuPai).AppendLine();
            if (!string.IsNullOrWhiteSpace(filtro.NomMenu))
                sql.Append("AND MN.DESMNU LIKE '%").Append(filtro.NomMenu.TrimStart().TrimEnd()).AppendLine("%'");

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();


            List<Menu> list = new List<Menu>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Menu obj = new Menu();
                    if (!row.IsNull("INDASSOCIADO"))
                        obj.IndAssociado = int.Parse((row["INDASSOCIADO"]).ToString());
                    if (!row.IsNull("CODMNUPAI"))
                        obj.CodMenuPai = row["CODMNUPAI"].ToString().Trim();
                    if (!row.IsNull("CODMNU"))
                        obj.CodMenu = row["CODMNU"].ToString().Trim();
                    if (!row.IsNull("DESMNU"))
                        obj.NomMenu = row["DESMNU"].ToString().Trim();
                    list.Add(obj);
                }
            }


            return ListResultadoManager.PaginarLista(list, pagina, tamanho, coluna, sentido);
        }

        public static List<Menu> SelectporGrupo(int pCodGrupoAcesso)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"SELECT DISTINCT
                                  MN.CODMNU
                                , MN.DESMNU
                                , CASE WHEN MN.CODMNUPAI = MN.CODMNU THEN '0' ELSE MN.CODMNUPAI END AS CODMNUPAI
                                , CASE WHEN RLC.CODGRPACS IS NULL THEN 0 ELSE 1 END INDASSOCIADO
                           FROM MRT.T0150830 MN
                             LEFT JOIN MRT.RLCGRPACSSISMNU RLC ON MN.CODMNU = RLC.CODMNU
                                                               AND RLC.NOMSISINF = MN.NOMSISINF 
                                                               AND RLC.CODGRPACS = ").Append(pCodGrupoAcesso).AppendLine();
            sql.Append(" WHERE MN.NOMSISINF = '").Append(siglaSistema).Append("' AND MN.CODFILEMP = 1  ").AppendLine();
            sql.Append(" ORDER BY MN.DESMNU");

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();

            List<Menu> list = new List<Menu>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Menu obj = new Menu();
                    if (!row.IsNull("INDASSOCIADO"))
                        obj.IndAssociado = int.Parse((row["INDASSOCIADO"]).ToString());
                    if (!row.IsNull("CODMNUPAI"))
                        obj.CodMenuPai = row["CODMNUPAI"].ToString().Trim();
                    if (!row.IsNull("CODMNU"))
                        obj.CodMenu = row["CODMNU"].ToString().Trim();
                    if (!row.IsNull("DESMNU"))
                        obj.NomMenu = row["DESMNU"].ToString().Trim();
                    list.Add(obj);
                }
            }

            return list;
        }

        public static List<Menu> SelectAssociados(int pCodGrupoAcesso)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"SELECT DISTINCT
                                  MN.CODMNU
                                , MN.DESMNU
                                , CASE WHEN MN.CODMNUPAI = MN.CODMNU THEN '0' ELSE MN.CODMNUPAI END AS CODMNUPAI
                                , CASE WHEN RLC.CODGRPACS IS NULL THEN 0 ELSE 1 END INDASSOCIADO
                           FROM MRT.T0150830 MN
                             INNER JOIN MRT.RLCGRPACSSISMNU RLC ON MN.CODMNU = RLC.CODMNU
                                                               AND RLC.NOMSISINF = MN.NOMSISINF 
                                                               AND RLC.CODGRPACS = ").Append(pCodGrupoAcesso).AppendLine();
            sql.Append(" WHERE MN.NOMSISINF = '").Append(siglaSistema).Append("'").AppendLine();
            sql.Append("   AND MN.CODFILEMP = 1  ");

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();

            List<Menu> list = new List<Menu>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Menu obj = new Menu();
                    if (!row.IsNull("INDASSOCIADO"))
                        obj.IndAssociado = int.Parse((row["INDASSOCIADO"]).ToString());
                    if (!row.IsNull("CODMNUPAI"))
                        obj.CodMenuPai = row["CODMNUPAI"].ToString().Trim();
                    if (!row.IsNull("CODMNU"))
                        obj.CodMenu = row["CODMNU"].ToString().Trim();
                    if (!row.IsNull("DESMNU"))
                        obj.NomMenu = row["DESMNU"].ToString().Trim();

                    obj.CodGrupoAcesso = pCodGrupoAcesso;
                    list.Add(obj);
                }
            }

            return list;
        }

        public static List<Menu> ListMenuPorGrupos(string pListGrupos)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT DISTINCT
                                MN.CODMNU
                              , MN.DESMNU
                              , MN.CODMNUPAI
                              , MN.DESICNMNU
                              , MN.NOMOBEPRG
                           FROM MRT.T0150830 MN
                                    INNER JOIN MRT.RLCGRPACSSISMNU RLC ON MN.CODMNU = RLC.CODMNU AND RLC.NOMSISINF = MN.NOMSISINF 
                                    INNER JOIN MRT.CADGRPACSSIS GRP ON  GRP.CODGRPACS = RLC.CODGRPACS AND GRP.NOMSISINF = MN.NOMSISINF 
                           WHERE MN.NOMSISINF = '").Append(siglaSistema).Append("'").AppendLine();
            sql.Append("     AND MN.CODFILEMP = 1").AppendLine();
            sql.Append("     AND UPPER(GRP.DESGRPRDE) IN ( ").Append(pListGrupos.ToUpper()).AppendLine(")");
            sql.Append("ORDER BY MN.DESMNU");

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();

            List<Menu> list = new List<Menu>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Menu obj = new Menu();
                    if (!row.IsNull("CODMNUPAI"))
                        obj.CodMenuPai = row["CODMNUPAI"].ToString().Trim();
                    if (!row.IsNull("CODMNU"))
                        obj.CodMenu = row["CODMNU"].ToString().Trim();
                    if (!row.IsNull("DESMNU"))
                        obj.NomMenu = row["DESMNU"].ToString().Trim();
                    if (!row.IsNull("DESICNMNU"))
                        obj.DesIconeMenu = row["DESICNMNU"].ToString().Trim();
                    if (!row.IsNull("NOMOBEPRG"))
                        obj.DesLocalAplicacaoMenu = row["NOMOBEPRG"].ToString().Trim();

                    list.Add(obj);
                }
            }
            return list;
        }
    }
}