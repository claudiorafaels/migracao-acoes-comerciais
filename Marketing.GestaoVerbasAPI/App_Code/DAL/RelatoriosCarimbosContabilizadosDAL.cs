using Marketing.GestaoVerbasAPI.App_Code.Connection;
using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.Models.RelatoriosCarimbosContabilizados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.DAL
{
    public class RelatoriosCarimbosContabilizadosDAL
    {
        public static ListResult<ValoresReceberSintetico> AReceberSintetico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            StringBuilder sql = new StringBuilder();
            List<ValoresReceberSintetico> list = new List<ValoresReceberSintetico>();

            sql.AppendLine(" SELECT A.CODFRN AS  CODIGO_FORNECEDOR ");
            sql.AppendLine("      , B.NOMFRN ");
            sql.AppendLine("      , TO_CHAR(A.CODFRN, '999999') || ' - ' || TRIM(B.NOMFRN) AS NOME_FORNECEDOR ");
            sql.AppendLine("      , TO_CHAR(A.DATPRVRCBPMS, 'DD/MM/YYYY') AS DATA_PREVISAO_RECEBIMENTO ");
            sql.AppendLine("      , NVL(SUM(A.VLRSLDEXAARDCMC), 0) AS  SALDO_EXTRA_ACORDO ");
            sql.AppendLine("      , NVL(SUM(A.VLRSLDARDCMC), 0) AS SALDO_ACORDO ");
            sql.AppendLine("      , NVL(SUM(A.VLRSLDEXAARDCMC + A.VLRSLDARDCMC), 0) AS SALDO_TOTAL ");
            sql.AppendLine("   FROM MRT.HSTSLDRCBFRN A ");
            sql.AppendLine("  INNER JOIN MRT.T0100426 B ON A.CODFRN = B.CODFRN ");
            sql.AppendLine("  INNER JOIN  MRT.T0109059 E ON E.TIPDSNDSCBNF = A.TIPDSNDSCBNF ");
            sql.AppendLine("  WHERE 1=1");

            if (filtro.IdtAnoMesReferencia != null)
                sql.Append("    AND A.ANOMESREF = ").Append(filtro.IdtAnoMesReferencia).AppendLine();

            if (filtro.CodObjetivo != null)
                sql.Append("    AND E.TIPOBJDSNVBA = ").Append(filtro.CodObjetivo.ToString()).AppendLine();

            if (filtro.DtPrevisaoRecebimento != null)
                sql.Append("   AND TRUNC(A.DATPRVRCBPMS) = TO_DATE('").Append(filtro.DtPrevisaoRecebimento.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD')   ").AppendLine();

            if (filtro.CodFornecedor != null)
                sql.Append("   AND A.CODFRN = ").Append(filtro.CodFornecedor.ToString()).AppendLine();

            if (filtro.CodTipoVerbaFornecedor != null)
            {
                if (filtro.CodTipoVerbaFornecedor == 0)
                    sql.Append("   AND E.TIPVBAFRN = 0").AppendLine();

                if (filtro.CodTipoVerbaFornecedor != 0)
                    sql.Append("   AND E.TIPVBAFRN <> 0").AppendLine();
            }

            //NECESSARIO INFORMAR PELO MENOS UMA DATA PARA RODAR O RELATORIO NO.NET
            sql.AppendLine("  GROUP BY A.CODFRN ");
            sql.AppendLine("         , B.NOMFRN ");
            sql.AppendLine("         , TO_CHAR(A.CODFRN, '999999') || ' - ' || TRIM(B.NOMFRN), A.DATPRVRCBPMS ");
            sql.AppendLine("  HAVING NVL(SUM(A.VLRSLDEXAARDCMC + A.VLRSLDARDCMC), 0) > 0.01 ");
            // sql.AppendLine("  ORDER BY 2 ");

            Command cmd = new Command();

            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ValoresReceberSintetico objResult = new ValoresReceberSintetico();

                    if (row.Table.Columns.Contains("SALDO_ACORDO") && !row.IsNull("SALDO_ACORDO"))
                        objResult.SaldoAcordo = decimal.Parse(row["SALDO_ACORDO"].ToString());

                    if (row.Table.Columns.Contains("SALDO_EXTRA_ACORDO") && !row.IsNull("SALDO_EXTRA_ACORDO"))
                        objResult.SaldoExtraAcordo = decimal.Parse(row["SALDO_EXTRA_ACORDO"].ToString());

                    if (row.Table.Columns.Contains("DATA_PREVISAO_RECEBIMENTO") && !row.IsNull("DATA_PREVISAO_RECEBIMENTO"))
                        objResult.DtPrevisaoRecebimento = DateTime.Parse(row["DATA_PREVISAO_RECEBIMENTO"].ToString());

                    if (row.Table.Columns.Contains("CODIGO_FORNECEDOR") && !row.IsNull("CODIGO_FORNECEDOR"))
                        objResult.CodFornecedor = int.Parse(row["CODIGO_FORNECEDOR"].ToString());

                    if (row.Table.Columns.Contains("NOMFRN") && !row.IsNull("NOMFRN"))
                        objResult.NomFornecedor = row["NOMFRN"].ToString();

                    if (row.Table.Columns.Contains("SALDO_TOTAL") && !row.IsNull("SALDO_TOTAL"))
                        objResult.SaldoTotal = decimal.Parse((row["SALDO_TOTAL"]).ToString());

                    list.Add(objResult);
                }
            }

            ListResult<ValoresReceberSintetico> result = ListResultadoManager.PaginarLista(list, pagina, tamanho, coluna, sentido);
            result.AggregateSummary = new Dictionary<string, object>();

            decimal sumSaldoExtraAcordo = list.Sum(p => p.SaldoExtraAcordo.GetValueOrDefault());
            decimal sumSaldoAcordo = list.Sum(p => p.SaldoAcordo.GetValueOrDefault());
            decimal sumSaldoTotal = list.Sum(p => p.SaldoTotal.GetValueOrDefault());

            result.AggregateSummary.Add("sumSaldoExtraAcordo", sumSaldoExtraAcordo);
            result.AggregateSummary.Add("sumSaldoAcordo", sumSaldoAcordo);
            result.AggregateSummary.Add("sumSaldoTotal", sumSaldoTotal);

            return result;
        }

        public static ListResult<ValoresReceberAnalitico> AReceberAnalitico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            StringBuilder sql = new StringBuilder();
            List<ValoresReceberAnalitico> list = new List<ValoresReceberAnalitico>();

            sql.AppendLine(" SELECT A.CODFRN AS CODIGO_FORNECEDOR ");
            sql.AppendLine("      , B.NOMFRN  ");
            sql.AppendLine("      , TO_CHAR(A.CODFRN, '999999') || ' - ' || TRIM(B.NOMFRN) AS NOME_FORNECEDOR ");
            sql.AppendLine("      , A.CODPMS AS ACORDO ");
            sql.AppendLine("      , TO_CHAR(A.DATPRVRCBPMS, 'DD/MM/YYYY') AS DATA_PREVISAO_RECEBIMENTO ");
            sql.AppendLine("      , A.VLRSLDEXAARDCMC AS  SALDO_EXTRA_ACORDO ");
            sql.AppendLine("      , A.VLRSLDARDCMC AS SALDO_ACORDO ");
            sql.AppendLine("      , A.VLRSLDEXAARDCMC + A.VLRSLDARDCMC AS SALDO_TOTAL ");
            sql.AppendLine("   FROM MRT.HSTSLDRCBFRN A ");
            sql.AppendLine("  INNER JOIN MRT.T0100426 B ON A.CODFRN = B.CODFRN ");
            sql.AppendLine("  INNER JOIN MRT.T0109059 E ON E.TIPDSNDSCBNF = A.TIPDSNDSCBNF");
            sql.AppendLine("  WHERE 1=1 ");

            if (filtro.IdtAnoMesReferencia != null)
                sql.Append(" AND A.ANOMESREF = ").Append(filtro.IdtAnoMesReferencia).AppendLine();

            if (filtro.CodObjetivo != null)
                sql.Append(" AND E.TIPOBJDSNVBA = ").Append(filtro.CodObjetivo.ToString()).AppendLine();

            if (filtro.DtPrevisaoRecebimento != null)
                sql.Append("AND TRUNC(A.DATPRVRCBPMS) = TO_DATE('").Append(filtro.DtPrevisaoRecebimento.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD')");

            if (filtro.CodFornecedor != null)
                sql.Append(" AND A.CODFRN = ").Append(filtro.CodFornecedor.ToString()).AppendLine();

            if (filtro.CodTipoVerbaFornecedor != null)
            {
                if (filtro.CodTipoVerbaFornecedor == 0)
                    sql.Append(" AND E.TIPVBAFRN = 0").AppendLine();

                if (filtro.CodTipoVerbaFornecedor != 0)
                    sql.Append(" AND E.TIPVBAFRN <> 0").AppendLine();
            }

            //sql.Append(" GROUP BY " +
            //            " A.CODFRN " +
            //            " , B.NOMFRN " +
            //            " , TO_CHAR(A.CODFRN, '999999') || ' - ' || TRIM(B.NOMFRN) " +
            //            " , A.CODPMS " +
            //            " , A.DATPRVRCBPMS " +
            //            " HAVING NVL(SUM(A.VLRSLDEXAARDCMC + A.VLRSLDARDCMC),0) > 0.01 ");
            //sql.AppendLine(" ORDER BY 2 ");

            Command cmd = new Command();

            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();


            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ValoresReceberAnalitico objResult = new ValoresReceberAnalitico();

                    if (row.Table.Columns.Contains("SALDO_ACORDO") && !row.IsNull("SALDO_ACORDO"))
                        objResult.SaldoAcordo = decimal.Parse(row["SALDO_ACORDO"].ToString());

                    if (row.Table.Columns.Contains("SALDO_EXTRA_ACORDO") && !row.IsNull("SALDO_EXTRA_ACORDO"))
                        objResult.SaldoExtraAcordo = decimal.Parse(row["SALDO_EXTRA_ACORDO"].ToString());

                    if (row.Table.Columns.Contains("DATA_PREVISAO_RECEBIMENTO") && !row.IsNull("DATA_PREVISAO_RECEBIMENTO"))
                        objResult.DtPrevisaoRecebimento = DateTime.Parse(row["DATA_PREVISAO_RECEBIMENTO"].ToString());

                    if (row.Table.Columns.Contains("CODIGO_FORNECEDOR") && !row.IsNull("CODIGO_FORNECEDOR"))
                        objResult.CodFornecedor = int.Parse(row["CODIGO_FORNECEDOR"].ToString());

                    if (row.Table.Columns.Contains("ACORDO") && !row.IsNull("ACORDO"))
                        objResult.CodPromessa = int.Parse(row["ACORDO"].ToString());

                    if (row.Table.Columns.Contains("NOMFRN") && !row.IsNull("NOMFRN"))
                        objResult.NomFornecedor = row["NOMFRN"].ToString();

                    if (row.Table.Columns.Contains("SALDO_TOTAL") && !row.IsNull("SALDO_TOTAL"))
                        objResult.SaldoTotal = decimal.Parse((row["SALDO_TOTAL"]).ToString());

                    list.Add(objResult);
                }
            }

            ListResult<ValoresReceberAnalitico> result = ListResultadoManager.PaginarLista(list, pagina, tamanho, coluna, sentido);
            result.AggregateSummary = new Dictionary<string, object>();

            decimal sumSaldoExtraAcordo = list.Sum(p => p.SaldoExtraAcordo.GetValueOrDefault());
            decimal sumSaldoAcordo = list.Sum(p => p.SaldoAcordo.GetValueOrDefault());
            decimal sumSaldoTotal = list.Sum(p => p.SaldoTotal.GetValueOrDefault());

            result.AggregateSummary.Add("sumSaldoExtraAcordo", sumSaldoExtraAcordo);
            result.AggregateSummary.Add("sumSaldoAcordo", sumSaldoAcordo);
            result.AggregateSummary.Add("sumSaldoTotal", sumSaldoTotal);

            return result;
        }

        public static ListResult<ValoresRecebidosAnalitico> RecebidosAnalitico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            StringBuilder sql = new StringBuilder();
            List<ValoresRecebidosAnalitico> list = new List<ValoresRecebidosAnalitico>();

            if (filtro.CodTipoLancamento == 1 || filtro.CodTipoLancamento == 0) //DEDUCTION
            {
                sql.AppendLine("SELECT 'DEDUCTION' AS TIPDSC ");
                sql.AppendLine("     , A.CODFRN AS CODFRN ");
                sql.AppendLine("     , FRN.NOMFRN");
                sql.AppendLine("     , (CASE WHEN B.CODPMS IS NOT NULL THEN B.CODPMS ELSE A.CODPMS END ) AS ACORDO ");
                sql.AppendLine("     , 'NF: ' || TO_CHAR(A.NUMNOTFSCFRNCTB) AS NUMNOTFSC ");
                sql.AppendLine("     , CAST(NVL(TO_CHAR(SUM(A.VLREFTDSCPCL), '0000000000D00'),'0') AS NUMBER(15,2))AS VLRLMT ");
                sql.AppendLine("  FROM MRT.T0128592 A ");
                sql.AppendLine("  LEFT JOIN MRT.T0134045 B ON A.CODPMS = B.CODPMSSBTFRMPGT ");
                sql.AppendLine("                          AND A.CODFRN = B.CODFRN ");
                sql.AppendLine(" INNER JOIN MRT.T0100426 FRN ON FRN.CODFRN = A.CODFRN ");
                sql.AppendLine("  LEFT JOIN MRT.T0118066 C ON C.CODPMS = B.CODPMS ");
                sql.AppendLine("                          AND C.CODFILEMP = B.CODFILEMP ");
                sql.AppendLine("                          AND C.CODEMP = B.CODEMP ");
                sql.AppendLine("                          AND C.DATNGCPMS = B.DATNGCPMS ");
                sql.AppendLine("                          AND B.CODPMS IS NOT NULL ");
                sql.AppendLine(" INNER JOIN  MRT.T0109059 D ON A.TIPDSNDSCBNF = D.TIPDSNDSCBNF").AppendLine();
                sql.AppendLine(" WHERE A.CODEMP = 1 ");
                sql.AppendLine("   AND NVL(FRN.TIPIDTEMPASCACOCMC, 0) = 0 ");
                sql.AppendLine("   AND A.FLGSITNGCDUP = 'I' ");
                //sql.AppendLine("   AND (( B.CODPMS IS NOT NULL AND D.TIPOBJDSNVBA = 1) ");
                //sql.AppendLine("         OR (B.CODPMS IS NULL AND D.TIPOBJDSNVBA = 1) ");
                //sql.AppendLine("       ) ");
                sql.Append("   AND TRUNC(A.DATPGTTIT) BETWEEN TO_DATE('").Append(filtro.DtInicioRecebidos.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD')  ").AppendLine();
                sql.Append("                              AND TO_DATE('").Append(filtro.DtFimRecebidos.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD') ").AppendLine();

                if (filtro.CodFornecedor != null)
                    sql.Append("   AND A.CODFRN = ").Append(filtro.CodFornecedor.ToString()).AppendLine();

                if (filtro.CodObjetivo != null)
                    sql.Append("   AND D.TIPOBJDSNVBA = ").Append(filtro.CodObjetivo.ToString()).AppendLine();

                if (filtro.CodTipoVerbaFornecedor != null)
                {
                    if (filtro.CodTipoVerbaFornecedor == 0)
                        sql.Append("   AND D.TIPVBAFRN = 0").AppendLine();

                    if (filtro.CodTipoVerbaFornecedor != 0)
                        sql.Append("   AND D.TIPVBAFRN <> 0").AppendLine();
                }

                sql.AppendLine("GROUP BY A.CODFRN");
                sql.AppendLine("       , FRN.NOMFRN");
                sql.AppendLine("       , 'NF: ' || TO_CHAR(A.NUMNOTFSCFRNCTB)");
                sql.AppendLine("       , (Case WHEN B.CODPMS IS NOT NULL THEN B.CODPMS ELSE A.CODPMS END )  ");
            }

            if (filtro.CodTipoLancamento == 2 || filtro.CodTipoLancamento == 0) //DUPLICATA
            {
                if (filtro.CodTipoLancamento == 0)
                    sql.AppendLine(" UNION ALL");

                sql.AppendLine("SELECT 'DUPLICATA' AS TIPDSC ");
                sql.AppendLine("      , B.CODFRN AS CODFRN ");
                sql.AppendLine("      , FRN.NOMFRN");
                sql.AppendLine("      , A.CODPMS AS ACORDO ");
                sql.AppendLine("      , 'NF: ' || TO_CHAR(A.NUMSEQTITPGT) AS NUMNOTFSC ");
                sql.AppendLine("      , CAST(NVL(TO_CHAR(SUM(A.VLRDSCAPPPMS + A.VLRDPRDSC), '0000000000D00'),'0') AS NUMBER(15,2)) AS VLRLMT ");
                sql.AppendLine(" FROM MRT.T0118910 A ");
                sql.AppendLine("      , MRT.T0118058 B ");
                sql.AppendLine("      , MRT.T0118066 C ");
                sql.AppendLine("      , MRT.T0109059 D ");
                sql.AppendLine("      , MRT.T0100426 FRN ");
                sql.AppendLine("  WHERE B.CODPMS = A.CODPMS ");
                sql.AppendLine("    AND B.CODFILEMP = A.CODFILEMP AND FRN.CODFRN = B.CODFRN ");
                sql.AppendLine("    AND B.CODEMP = A.CODEMP ");
                sql.AppendLine("    AND B.DATNGCPMS = A.DATNGCPMS ");
                sql.AppendLine("    AND C.CODPMS = B.CODPMS ");
                sql.AppendLine("    AND C.CODFILEMP = B.CODFILEMP ");
                sql.AppendLine("    AND C.CODEMP = B.CODEMP ");
                sql.AppendLine("    AND C.DATNGCPMS = B.DATNGCPMS ");
                sql.AppendLine("    AND C.TIPDSNDSCBNF = A.TIPDSNDSCBNF ");
                sql.AppendLine("    AND C.TIPFRMDSCBNF = A.TIPFRMDSCBNF ");
                sql.AppendLine("    AND C.TIPDSNDSCBNF = D.TIPDSNDSCBNF ");
                //sql.AppendLine("    AND D.TIPOBJDSNVBA = 1 ");
                sql.AppendLine("    AND C.TIPFRMDSCBNF <> 9 ");

                sql.Append("    AND TRUNC(A.DATRCBDSC) BETWEEN TO_DATE('").Append(filtro.DtInicioRecebidos.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD')   ").AppendLine();
                sql.Append("                               AND TO_DATE('").Append(filtro.DtFimRecebidos.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD') ").AppendLine();

                if (filtro.CodFornecedor != null)
                    sql.Append(" AND B.CODFRN = ").Append(filtro.CodFornecedor.ToString()).AppendLine();

                if (filtro.CodObjetivo != null)
                    sql.Append(" AND D.TIPOBJDSNVBA = ").Append(filtro.CodObjetivo.ToString()).AppendLine();

                if (filtro.CodTipoVerbaFornecedor != null)
                {
                    if (filtro.CodTipoVerbaFornecedor == 0)
                        sql.Append(" AND D.TIPVBAFRN = 0").AppendLine();

                    if (filtro.CodTipoVerbaFornecedor != 0)
                        sql.Append(" AND D.TIPVBAFRN <> 0").AppendLine();
                }



                sql.AppendLine("   GROUP BY B.CODFRN");
                sql.AppendLine("    , FRN.NOMFRN");
                sql.AppendLine("    , 'NF: ' || TO_CHAR(A.NUMSEQTITPGT)");
                sql.AppendLine("    , A.CODPMS");
            }

            if (filtro.CodTipoLancamento == 3 || filtro.CodTipoLancamento == 0) //ACERTO
            {
                if (filtro.CodTipoLancamento == 0)
                    sql.AppendLine(" UNION ALL");

                sql.AppendLine("SELECT 'ACERTO' AS TIPDSC ");
                sql.AppendLine("      , B.CODFRN AS CODFRN ");
                sql.AppendLine("      , FRN.NOMFRN ");
                sql.AppendLine("      , A.CODPMS AS ACORDO ");
                sql.AppendLine("      , SUBSTR(A.DESJSTCNCVLRARDCMC,1,50) AS NUMNOTFSC ");
                sql.AppendLine("      , CAST(NVL(TO_CHAR(SUM(A.VLRPGOPMS - A.VLRPGOPMSANT), '0000000000D00'),'0') AS NUMBER(15,2)) AS VLRLMT ");
                sql.AppendLine("   FROM MRT.T0120540 A ");
                sql.AppendLine("      , MRT.T0118058 B ");
                sql.AppendLine("      , MRT.T0118066 C ");
                sql.AppendLine("      , MRT.T0123086 D ");
                sql.AppendLine("      , MRT.T0109059 E ");
                sql.AppendLine("      , MRT.T0100426 FRN ");
                sql.AppendLine("  WHERE B.CODPMS = A.CODPMS AND FRN.CODFRN = B.CODFRN ");
                sql.AppendLine("    AND B.CODFILEMP = A.CODFILEMP ");
                sql.AppendLine("    AND B.CODEMP = A.CODEMP ");
                sql.AppendLine("    AND B.DATNGCPMS = A.DATNGCPMS ");
                sql.AppendLine("    AND C.CODPMS = B.CODPMS ");
                sql.AppendLine("    AND C.CODFILEMP = B.CODFILEMP ");
                sql.AppendLine("    AND C.CODEMP = B.CODEMP ");
                sql.AppendLine("    AND C.DATNGCPMS = B.DATNGCPMS ");
                sql.AppendLine("    AND C.TIPDSNDSCBNF = E.TIPDSNDSCBNF ");
                //sql.AppendLine("    AND E.TIPOBJDSNVBA = 1 ");
                sql.AppendLine("    AND C.TIPFRMDSCBNF <> 9 ");
                sql.AppendLine("    AND B.CODFRN = D.CODFRN ");
                sql.AppendLine("    AND A.TIPDSNDSCBNF = D.TIPDSNDSCBNF ");
                sql.AppendLine("    AND TRUNC(A.DATALTPMS) = TRUNC(D.DATREFLMT) ");
                sql.AppendLine("    AND D.CODTIPLMT = 16 ");
                sql.AppendLine("    AND D.CODPMS = A.CODPMS ");
                sql.AppendLine("    AND D.VLRLMTCTB = (A.VLRPGOPMS - A.VLRPGOPMSANT) ");

                sql.Append("    AND TRUNC(A.DATALTPMS) BETWEEN TO_DATE('").Append(filtro.DtInicioRecebidos.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD')   ").AppendLine();
                sql.Append("                               AND TO_DATE('").Append(filtro.DtFimRecebidos.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD') ").AppendLine();

                if (filtro.CodFornecedor != null)
                    sql.Append(" AND B.CODFRN = ").Append(filtro.CodFornecedor.ToString()).AppendLine();

                if (filtro.CodObjetivo != null)
                    sql.Append(" AND E.TIPOBJDSNVBA = ").Append(filtro.CodObjetivo.ToString()).AppendLine();

                if (filtro.CodTipoVerbaFornecedor != null)
                {
                    if (filtro.CodTipoVerbaFornecedor == 0)
                        sql.Append(" AND E.TIPVBAFRN = 0").AppendLine();

                    if (filtro.CodTipoVerbaFornecedor != 0)
                        sql.Append(" AND E.TIPVBAFRN <> 0").AppendLine();
                }
                    
                sql.AppendLine(" GROUP BY B.CODFRN");
                sql.AppendLine("     , FRN.NOMFRN");
                sql.AppendLine("     , SUBSTR(A.DESJSTCNCVLRARDCMC, 1, 50)");
                sql.AppendLine("     , A.CODPMS");

            }

            if (filtro.CodTipoLancamento == 4 || filtro.CodTipoLancamento == 0) //OP
            {
                if (filtro.CodTipoLancamento == 0)
                    sql.AppendLine(" UNION ALL");

                sql.AppendLine(" SELECT 'OP' AS TIPDSC ");
                sql.AppendLine("      , B.CODFRN AS CODFRN ");
                sql.AppendLine("      , D.NOMFRN");
                sql.AppendLine("      , A.CODPMS AS ACORDO ");
                sql.AppendLine("      , 'OP: ' || TO_CHAR(A.NUMORDPGTFRN) AS NUMNOTFSC ");
                sql.AppendLine("      , CAST(NVL(TO_CHAR(SUM(A.VLRAPPORDPGT), '0000000000D00'),'0') AS NUMBER(15,2)) AS VLRLMT");
                sql.AppendLine("   FROM MRT.T0118902 A ");
                sql.AppendLine("      , MRT.T0118058 B ");
                sql.AppendLine("      , MRT.T0118880 C ");
                sql.AppendLine("      , MRT.T0100426 D ");
                sql.AppendLine("      , MRT.T0109059 E ");
                sql.AppendLine("  WHERE B.CODPMS = A.CODPMS ");
                sql.AppendLine("    AND B.CODFILEMP = A.CODFILEMP");
                sql.AppendLine("    AND B.CODEMP = A.CODEMP ");
                sql.AppendLine("    AND B.DATNGCPMS = A.DATNGCPMS ");
                sql.AppendLine("    AND C.NUMORDPGTFRN = A.NUMORDPGTFRN ");
                sql.AppendLine("    AND C.CODBCO = A.CODBCO ");
                sql.AppendLine("    AND C.CODAGE = A.CODAGE ");
                sql.AppendLine("    AND NVL(B.INDASCARDFRNPMS,0) = 0 ");
                sql.AppendLine("    AND D.CODFRN = B.CODFRN ");
                sql.AppendLine("    AND NVL(D.TIPIDTEMPASCACOCMC,0) = 0 ");
                sql.AppendLine("    AND A.TIPDSNDSCBNF = E.TIPDSNDSCBNF ");
                //sql.AppendLine("    AND E.TIPOBJDSNVBA = 1 ");
                sql.AppendLine("    AND A.TIPFRMDSCBNF <> 9 ");
                sql.Append("    AND TRUNC(A.DATLMTCNTCRR) BETWEEN TO_DATE('").Append(filtro.DtInicioRecebidos.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD') ").AppendLine();
                sql.Append("                                  AND TO_DATE('").Append(filtro.DtFimRecebidos.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD') ").AppendLine();

                if (filtro.CodFornecedor != null)
                    sql.Append(" AND B.CODFRN = ").Append(filtro.CodFornecedor.ToString()).AppendLine();

                if (filtro.CodObjetivo != null)
                    sql.Append(" AND E.TIPOBJDSNVBA = ").Append(filtro.CodObjetivo.ToString()).AppendLine();

                if (filtro.CodTipoVerbaFornecedor != null)
                {
                    if (filtro.CodTipoVerbaFornecedor == 0)
                        sql.Append(" AND E.TIPVBAFRN = 0").AppendLine();

                    if (filtro.CodTipoVerbaFornecedor != 0)
                        sql.Append(" AND E.TIPVBAFRN <> 0").AppendLine();
                }

                sql.AppendLine(" GROUP BY B.CODFRN");
                sql.AppendLine("        , D.NOMFRN");
                sql.AppendLine("        , TO_CHAR(B.CODFRN, '999999') || ' - ' || TRIM(D.NOMFRN)");
                sql.AppendLine("        , 'OP: ' || TO_CHAR(A.NUMORDPGTFRN)");
                sql.AppendLine("        , A.CODPMS ");
            }

            Command cmd = new Command();

            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();


            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ValoresRecebidosAnalitico objResult = new ValoresRecebidosAnalitico();

                    if (row.Table.Columns.Contains("NUMNOTFSC") && !row.IsNull("NUMNOTFSC"))
                        objResult.NumNotaFiscal = row["NUMNOTFSC"].ToString();

                    if (row.Table.Columns.Contains("TIPDSC") && !row.IsNull("TIPDSC"))
                        objResult.NomTipoLancamento = row["TIPDSC"].ToString();

                    if (row.Table.Columns.Contains("CODFRN") && !row.IsNull("CODFRN"))
                        objResult.CodFornecedor = int.Parse(row["CODFRN"].ToString());

                    if (row.Table.Columns.Contains("NOMFRN") && !row.IsNull("NOMFRN"))
                        objResult.NomFornecedor = row["NOMFRN"].ToString();

                    if (row.Table.Columns.Contains("ACORDO") && !row.IsNull("ACORDO"))
                        objResult.CodPromessa = int.Parse((row["ACORDO"]).ToString());

                    if (row.Table.Columns.Contains("VLRLMT") && !row.IsNull("VLRLMT"))
                        objResult.VlrAcordo = decimal.Parse((row["VLRLMT"]).ToString());

                    list.Add(objResult);
                }
            }

            ListResult<ValoresRecebidosAnalitico> result = ListResultadoManager.PaginarLista(list, pagina, tamanho, coluna, sentido);
            result.AggregateSummary = new Dictionary<string, object>();

            decimal sumVlrAcordo = list.Sum(p => p.VlrAcordo.GetValueOrDefault());

            result.AggregateSummary.Add("sumVlrAcordo", sumVlrAcordo);

            return result;
        }

        public static ListResult<ValoresRecebidosSintetico> RecebidosSintetico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            StringBuilder sql = new StringBuilder();
            List<ValoresRecebidosSintetico> list = new List<ValoresRecebidosSintetico>();

            if (filtro.CodTipoLancamento == null) //todos
            {
                filtro.CodTipoLancamento = 0;
            }

            if (filtro.CodTipoLancamento == 1 || filtro.CodTipoLancamento == 0) //DEDUCTION
            {
                sql.AppendLine("SELECT 'DEDUCTION' AS TIPDSC ");
                sql.AppendLine("     , A.CODFRN AS CODFRN ");
                sql.AppendLine("     , FRN.NOMFRN");
                //sql.AppendLine("      , A.NUMNOTFSCFRNCTB AS NUMNOTFSC ");
                sql.AppendLine("     , NVL(SUM(A.VLREFTDSCPCL), 0) AS VLRLMT ");
                sql.AppendLine("  FROM MRT.T0128592 A ");
                sql.AppendLine("  LEFT JOIN MRT.T0134045 B ON A.CODPMS = B.CODPMSSBTFRMPGT ");
                sql.AppendLine("                          AND A.CODFRN = B.CODFRN ");
                sql.AppendLine("  LEFT JOIN MRT.T0100426 FRN ON FRN.CODFRN = A.CODFRN ");
                sql.AppendLine("  LEFT JOIN MRT.T0118066 C ON C.CODPMS = B.CODPMS ");
                sql.AppendLine("                     AND C.CODFILEMP = B.CODFILEMP ");
                sql.AppendLine("                     AND C.CODEMP = B.CODEMP ");
                sql.AppendLine("                     AND C.DATNGCPMS = B.DATNGCPMS ");
                sql.AppendLine("                     AND B.CODPMS IS NOT NULL ");
                sql.AppendLine("  INNER JOIN MRT.T0109059 D ON A.TIPDSNDSCBNF = D.TIPDSNDSCBNF").AppendLine();
                sql.AppendLine("  WHERE A.CODEMP = 1 ");
                sql.AppendLine("    AND A.FLGSITNGCDUP = 'I' ");
                //sql.AppendLine("    AND (( B.CODPMS IS NOT NULL AND D.TIPOBJDSNVBA = 1) ");
                //sql.AppendLine("     OR  ( B.CODPMS IS NULL AND D.TIPOBJDSNVBA = 1) ");
                //sql.AppendLine("        ) ");

                sql.Append("  AND TRUNC(A.DATPGTTIT) BETWEEN TO_DATE('").Append(filtro.DtInicioRecebidos.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD') ").AppendLine();
                sql.Append("                             AND TO_DATE('").Append(filtro.DtFimRecebidos.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD') ").AppendLine();

                if (filtro.CodFornecedor != null)
                    sql.Append(" AND A.CODFRN = ").Append(filtro.CodFornecedor.ToString()).AppendLine();

                if (filtro.CodObjetivo != null)
                    sql.Append(" AND D.TIPOBJDSNVBA = ").Append(filtro.CodObjetivo.ToString()).AppendLine();

                if (filtro.CodTipoVerbaFornecedor != null)
                {
                    if (filtro.CodTipoVerbaFornecedor == 0)
                        sql.Append(" AND D.TIPVBAFRN = 0").AppendLine();

                    if (filtro.CodTipoVerbaFornecedor != 0)
                        sql.Append(" AND D.TIPVBAFRN <> 0").AppendLine();
                }

                sql.AppendLine("  GROUP BY A.CODFRN");
                sql.AppendLine("         , FRN.NOMFRN ");
            }

            if (filtro.CodTipoLancamento == 2 || filtro.CodTipoLancamento == 0) //DUPLICATA
            {
                if (filtro.CodTipoLancamento == 0)
                    sql.AppendLine(" UNION ALL");

                sql.AppendLine("SELECT 'DUPLICATA' AS TIPDSC ");
                sql.AppendLine("      , B.CODFRN AS CODFRN ");
                sql.AppendLine("      , FRN.NOMFRN");
                // sql.AppendLine("      , A.NUMSEQTITPGT AS NUMNOTFSC ");
                sql.AppendLine("      ,  NVL(SUM((A.VLRDSCAPPPMS + A.VLRDPRDSC)), 0)  AS VLRLMT ");
                sql.AppendLine("   FROM MRT.T0118910 A ");
                sql.AppendLine("      , MRT.T0118058 B ");
                sql.AppendLine("      , MRT.T0118066 C ");
                sql.AppendLine("      , MRT.T0109059 D ");
                sql.AppendLine("      , MRT.T0100426 FRN ");
                sql.AppendLine("  WHERE B.CODPMS = A.CODPMS ");
                sql.AppendLine("    AND B.CODFILEMP = A.CODFILEMP AND FRN.CODFRN = B.CODFRN ");
                sql.AppendLine("    AND B.CODEMP = A.CODEMP ");
                sql.AppendLine("    AND B.DATNGCPMS = A.DATNGCPMS ");
                sql.AppendLine("    AND C.CODPMS = B.CODPMS ");
                sql.AppendLine("    AND C.CODFILEMP = B.CODFILEMP ");
                sql.AppendLine("    AND C.CODEMP = B.CODEMP ");
                sql.AppendLine("    AND C.DATNGCPMS = B.DATNGCPMS ");
                sql.AppendLine("    AND C.TIPDSNDSCBNF = A.TIPDSNDSCBNF ");
                sql.AppendLine("    AND C.TIPFRMDSCBNF = A.TIPFRMDSCBNF ");
                sql.AppendLine("    AND C.TIPDSNDSCBNF = D.TIPDSNDSCBNF ");
                //sql.AppendLine("    AND D.TIPOBJDSNVBA = 1 ");
                sql.AppendLine("    AND C.TIPFRMDSCBNF <> 9 ");

                sql.Append("    AND TRUNC(A.DATRCBDSC) BETWEEN TO_DATE('").Append(filtro.DtInicioRecebidos.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD')   ");
                sql.Append("                               AND TO_DATE('").Append(filtro.DtFimRecebidos.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD') ");

                if (filtro.CodFornecedor != null)
                    sql.Append(" AND B.CODFRN = ").Append(filtro.CodFornecedor.ToString()).AppendLine();

                if (filtro.CodObjetivo != null)
                    sql.Append(" AND D.TIPOBJDSNVBA = ").Append(filtro.CodObjetivo.ToString()).AppendLine();

                if (filtro.CodTipoVerbaFornecedor != null)
                {
                    if (filtro.CodTipoVerbaFornecedor == 0)
                        sql.Append(" AND D.TIPVBAFRN = 0").AppendLine();

                    if (filtro.CodTipoVerbaFornecedor != 0)
                        sql.Append(" AND D.TIPVBAFRN <> 0").AppendLine();
                }

                sql.AppendLine("    GROUP BY B.CODFRN");
                sql.AppendLine("           , FRN.NOMFRN");

            }

            if (filtro.CodTipoLancamento == 3 || filtro.CodTipoLancamento == 0) //ACERTO
            {
                if (filtro.CodTipoLancamento == 0)
                    sql.AppendLine(" UNION ALL");

                sql.AppendLine(" SELECT 'ACERTO' AS TIPDSC ");
                sql.AppendLine("      , B.CODFRN AS CODFRN ");
                sql.AppendLine("      , FRN.NOMFRN");
                //sql.AppendLine("      , 0 AS NUMNOTFSC ");
                sql.AppendLine("      ,  NVL(SUM((A.VLRPGOPMS - A.VLRPGOPMSANT)), 0)  AS VLRLMT ");
                sql.AppendLine("   FROM MRT.T0120540 A ");
                sql.AppendLine("      , MRT.T0118058 B ");
                sql.AppendLine("      , MRT.T0118066 C ");
                sql.AppendLine("      , MRT.T0123086 D ");
                sql.AppendLine("      , MRT.T0109059 E ");
                sql.AppendLine("      , MRT.T0100426 FRN ");
                sql.AppendLine("  WHERE B.CODPMS = A.CODPMS AND FRN.CODFRN = B.CODFRN");
                sql.AppendLine("    AND B.CODFILEMP = A.CODFILEMP ");
                sql.AppendLine("    AND B.CODEMP = A.CODEMP ");
                sql.AppendLine("    AND B.DATNGCPMS = A.DATNGCPMS ");
                sql.AppendLine("    AND C.CODPMS = B.CODPMS ");
                sql.AppendLine("    AND C.CODFILEMP = B.CODFILEMP ");
                sql.AppendLine("    AND C.CODEMP = B.CODEMP ");
                sql.AppendLine("    AND C.DATNGCPMS = B.DATNGCPMS ");
                sql.AppendLine("    AND C.TIPDSNDSCBNF = E.TIPDSNDSCBNF ");
                //sql.AppendLine("    AND E.TIPOBJDSNVBA = 1 ");
                sql.AppendLine("    AND C.TIPFRMDSCBNF <> 9 ");
                sql.AppendLine("    AND B.CODFRN = D.CODFRN ");
                sql.AppendLine("    AND A.TIPDSNDSCBNF = D.TIPDSNDSCBNF ");
                sql.AppendLine("    AND TRUNC(A.DATALTPMS) = TRUNC(D.DATREFLMT) ");
                sql.AppendLine("    AND D.CODTIPLMT = 16 ");
                sql.AppendLine("    AND D.CODPMS = A.CODPMS ");
                sql.AppendLine("    AND D.VLRLMTCTB = (A.VLRPGOPMS - A.VLRPGOPMSANT) ");

                sql.Append("    AND TRUNC(A.DATALTPMS) BETWEEN TO_DATE('").Append(filtro.DtInicioRecebidos.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD')   ").AppendLine();
                sql.Append("                               AND TO_DATE('").Append(filtro.DtFimRecebidos.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD') ").AppendLine();


                if (filtro.CodFornecedor != null)
                    sql.Append(" AND B.CODFRN = ").Append(filtro.CodFornecedor.ToString()).AppendLine();

                if (filtro.CodObjetivo != null)
                    sql.Append(" AND E.TIPOBJDSNVBA = ").Append(filtro.CodObjetivo.ToString()).AppendLine();

                if (filtro.CodTipoVerbaFornecedor != null)
                {
                    if (filtro.CodTipoVerbaFornecedor == 0)
                        sql.Append(" AND E.TIPVBAFRN = 0").AppendLine();

                    if (filtro.CodTipoVerbaFornecedor != 0)
                        sql.Append(" AND E.TIPVBAFRN <> 0").AppendLine();
                }

                sql.AppendLine("    GROUP BY B.CODFRN, FRN.NOMFRN ");
            }

            if (filtro.CodTipoLancamento == 4 || filtro.CodTipoLancamento == 0) //OP
            {
                if (filtro.CodTipoLancamento == 0)
                    sql.AppendLine(" UNION ALL");

                sql.AppendLine(" SELECT 'OP' AS TIPDSC ");
                sql.AppendLine("      , B.CODFRN AS CODFRN ");
                sql.AppendLine("      , FRN.NOMFRN");
                //sql.AppendLine("      , 0 AS NUMNOTFSC ");
                sql.AppendLine("      , NVL(SUM(A.VLRAPPORDPGT), 0) AS VLRLMT ");
                sql.AppendLine("   FROM MRT.T0118902 A ");
                sql.AppendLine("      , MRT.T0118058 B ");
                sql.AppendLine("      , MRT.T0118880 C ");
                sql.AppendLine("      , MRT.T0100426 D ");
                sql.AppendLine("      , MRT.T0109059 E ");
                sql.AppendLine("      , MRT.T0100426 FRN ");
                sql.AppendLine("  WHERE B.CODPMS = A.CODPMS ");
                sql.AppendLine("    AND B.CODFILEMP = A.CODFILEMP AND FRN.CODFRN = B.CODFRN ");
                sql.AppendLine("    AND B.CODEMP = A.CODEMP ");
                sql.AppendLine("    AND B.DATNGCPMS = A.DATNGCPMS ");
                sql.AppendLine("    AND C.NUMORDPGTFRN = A.NUMORDPGTFRN ");
                sql.AppendLine("    AND C.CODBCO = A.CODBCO ");
                sql.AppendLine("    AND C.CODAGE = A.CODAGE ");
                sql.AppendLine("    AND NVL(B.INDASCARDFRNPMS,0) = 0 ");
                sql.AppendLine("    AND D.CODFRN = B.CODFRN ");
                sql.AppendLine("    AND NVL(D.TIPIDTEMPASCACOCMC,0) = 0 ");
                sql.AppendLine("    AND A.TIPDSNDSCBNF = E.TIPDSNDSCBNF ");
                //sql.AppendLine("    AND E.TIPOBJDSNVBA = 1 ");
                sql.AppendLine("    AND A.TIPFRMDSCBNF <> 9 ");
                sql.AppendLine("    AND TRUNC(A.DATLMTCNTCRR) BETWEEN TO_DATE('").Append(filtro.DtInicioRecebidos.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD')   ");
                sql.AppendLine("                                  AND TO_DATE('").Append(filtro.DtFimRecebidos.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD') ");

                if (filtro.CodFornecedor != null)
                    sql.Append(" AND B.CODFRN = ").Append(filtro.CodFornecedor.ToString()).AppendLine();

                if (filtro.CodObjetivo != null)
                    sql.Append(" AND E.TIPOBJDSNVBA = ").Append(filtro.CodObjetivo.ToString()).AppendLine();

                if (filtro.CodTipoVerbaFornecedor != null)
                {
                    if (filtro.CodTipoVerbaFornecedor == 0)
                        sql.Append(" AND E.TIPVBAFRN = 0").AppendLine();

                    if (filtro.CodTipoVerbaFornecedor != 0)
                        sql.Append(" AND E.TIPVBAFRN <> 0").AppendLine();
                }
                sql.AppendLine(" GROUP BY B.CODFRN, FRN.NOMFRN       ");

            }

            Command cmd = new Command();

            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();


            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ValoresRecebidosSintetico objResult = new ValoresRecebidosSintetico();

                    if (row.Table.Columns.Contains("TIPDSC") && !row.IsNull("TIPDSC"))
                        objResult.NomTipoLancamento = row["TIPDSC"].ToString();

                    if (row.Table.Columns.Contains("CODFRN") && !row.IsNull("CODFRN"))
                        objResult.CodFornecedor = int.Parse(row["CODFRN"].ToString());

                    if (row.Table.Columns.Contains("NOMFRN") && !row.IsNull("NOMFRN"))
                        objResult.NomFornecedor = row["NOMFRN"].ToString();

                    if (row.Table.Columns.Contains("VLRLMT") && !row.IsNull("VLRLMT"))
                        objResult.VlrAcordo = decimal.Parse((row["VLRLMT"]).ToString());

                    list.Add(objResult);
                }
            }

            ListResult<ValoresRecebidosSintetico> result = ListResultadoManager.PaginarLista(list, pagina, tamanho, coluna, sentido);
            result.AggregateSummary = new Dictionary<string, object>();

            decimal sumVlrAcordo = list.Sum(p => p.VlrAcordo.GetValueOrDefault());

            result.AggregateSummary.Add("sumVlrAcordo", sumVlrAcordo);

            return result;
        }

        public static ListResult<NovosAcordosAnalitico> NovosAcordosAnalitico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            StringBuilder sql = new StringBuilder();
            List<NovosAcordosAnalitico> list = new List<NovosAcordosAnalitico>();

            sql.AppendLine("SELECT A.CODFRN  AS CODIGO_FORNECEDOR ");
            sql.AppendLine("     , TO_CHAR(A.CODFRN, '999999') || ' - ' || trim(C.NOMFRN) AS NOME_FORNECEDOR ");
            sql.AppendLine("     , A.CODPMS AS ACORDO ");
            sql.AppendLine("     , TO_CHAR(A.DATNGCPMS, 'DD/MM/YYYY') AS DATA_NEGOCIACAO_ACORDO ");
            sql.AppendLine("     , CAST(NVL(B.VLRNGCPMS, '0') AS NUMBER(15, 2)) AS VALOR_ACORDO ");
            sql.AppendLine("  FROM MRT.t0118058 a ");
            sql.AppendLine("  LEFT JOIN MRT.t0134045 e ON a.codpms = e.CODPMSSBTFRMPGT ");
            sql.AppendLine("  LEFT JOIN MRT.t0134126 f ON a.codpms = f.codpms ");
            sql.AppendLine("                          AND f.codpmsori IS NOT NULL ");
            sql.AppendLine("     , MRT.T0118066 B ");
            sql.AppendLine("     , MRT.T0100426 C ");
            sql.AppendLine("     , MRT.T0109059 D ");
            sql.AppendLine(" WHERE A.CODPMS = B.CODPMS ");
            sql.AppendLine("   AND B.TIPDSNDSCBNF = D.TIPDSNDSCBNF ");
            sql.AppendLine("   AND A.DATNGCPMS = B.DATNGCPMS ");
            sql.AppendLine("   AND A.CODEMP = B.CODEMP ");
            sql.AppendLine("   AND A.CODFILEMP = B.CODFILEMP");

            sql.Append("   AND TRUNC(A.DATCADPMS) BETWEEN TO_DATE('").Append(filtro.DtInicioAcordo.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD')   ").AppendLine();
            sql.Append("                              AND TO_DATE('").Append(filtro.DtFimAcordo.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD') ").AppendLine();

            sql.Append("   AND(").AppendLine();
            sql.Append("         (A.CODSITPMS <> 4) ").AppendLine();
            sql.Append("       OR(").AppendLine();
            sql.Append("               A.CODSITPMS = 4 ").AppendLine();
            sql.Append("           AND A.DATCNCPED > A.DATCADPMS ").AppendLine();
            sql.Append("           AND A.DATCNCPED <= TO_DATE('").Append(filtro.DtFimAcordo.GetValueOrDefault().ToString("yyyy - MM - dd")).Append("', 'YYYY-MM-DD')").AppendLine();
            sql.Append("         )").AppendLine();
            sql.Append("      )").AppendLine();
            sql.Append("   AND B.TIPFRMDSCBNF <> 9 ").AppendLine();
            //sql.Append("   AND B.TIPDSNDSCBNF NOT IN(67, 68) ").AppendLine();
            sql.Append("   AND NVL(A.INDASCARDFRNPMS, 0) = 0 ").AppendLine();
            sql.Append("   AND A.CODFRN = C.CODFRN ").AppendLine();
            sql.Append("   AND NVL(C.TIPIDTEMPASCACOCMC, 0) = 0 ").AppendLine();
            sql.Append("   AND (E.CODPMSSBTFRMPGT IS NULL OR E.CODPMSSBTFRMPGT IS NOT NULL AND E.TIPFRMDSCBNF = 9) ").AppendLine();
            sql.Append("   AND F.CODPMS IS NULL ").AppendLine();


            if (filtro.CodFornecedor != null)
                sql.AppendLine(" AND A.CODFRN = ").Append(filtro.CodFornecedor.ToString()).AppendLine();

            if (filtro.CodTipoVerbaFornecedor != null)
            {
                if (filtro.CodTipoVerbaFornecedor == 0)
                    sql.Append(" AND D.TIPVBAFRN = 0").AppendLine();

                if (filtro.CodTipoVerbaFornecedor != 0)
                    sql.Append(" AND D.TIPVBAFRN <> 0").AppendLine();
            }

            if (filtro.CodObjetivo != null)
                sql.Append(" AND D.TIPOBJDSNVBA = ").Append(filtro.CodObjetivo.ToString()).AppendLine();


            Command cmd = new Command();

            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();


            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    NovosAcordosAnalitico objResult = new NovosAcordosAnalitico();

                    if (row.Table.Columns.Contains("DATA_NEGOCIACAO_ACORDO") && !row.IsNull("DATA_NEGOCIACAO_ACORDO"))
                        objResult.DtNegociacaoAcordo = DateTime.Parse((row["DATA_NEGOCIACAO_ACORDO"]).ToString());

                    if (row.Table.Columns.Contains("CODIGO_FORNECEDOR") && !row.IsNull("CODIGO_FORNECEDOR"))
                        objResult.CodFornecedor = int.Parse(row["CODIGO_FORNECEDOR"].ToString());

                    if (row.Table.Columns.Contains("NOME_FORNECEDOR") && !row.IsNull("NOME_FORNECEDOR"))
                        objResult.NomFornecedor = row["NOME_FORNECEDOR"].ToString();

                    if (row.Table.Columns.Contains("ACORDO") && !row.IsNull("ACORDO"))
                        objResult.CodPromessa = int.Parse((row["ACORDO"]).ToString());

                    if (row.Table.Columns.Contains("VALOR_ACORDO") && !row.IsNull("VALOR_ACORDO"))
                        objResult.VlrAcordo = decimal.Parse((row["VALOR_ACORDO"]).ToString());

                    list.Add(objResult);
                }
            }
            ListResult<NovosAcordosAnalitico> result = ListResultadoManager.PaginarLista(list, pagina, tamanho, coluna, sentido);
            result.AggregateSummary = new Dictionary<string, object>();

            decimal sumVlrAcordo = list.Sum(p => p.VlrAcordo.GetValueOrDefault());
            result.AggregateSummary.Add("sumVlrAcordo", sumVlrAcordo);

            return result;
        }

        public static ListResult<NovosAcordosSintetico> NovosAcordosSintetico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            StringBuilder sql = new StringBuilder();
            List<NovosAcordosSintetico> list = new List<NovosAcordosSintetico>();

            sql.AppendLine(" SELECT A.CODFRN  AS CODIGO_FORNECEDOR ");
            sql.AppendLine("      , TRIM(C.NOMFRN) AS NOME_FORNECEDOR ");
            sql.AppendLine("      , TO_CHAR(B.DATPRVRCBPMS, 'DD/MM/YYYY') AS DATA_PREVISAO_RECEBTO ");
            sql.AppendLine("      , CAST(NVL(TO_CHAR(SUM(CASE WHEN D.TIPDSNDSCBNF NOT IN(93, 30, 55, 60, 39, 32, 53, 42, 54, 58, 61, 63, 19, 53) ");
            sql.AppendLine("                                  THEN B.VLRNGCPMS    END), '999999990D00'), '0') as NUMBER(15, 2)");
            sql.AppendLine("        ) AS SALDO_EXTRA_ACORDO ");
            sql.AppendLine("      , CAST(NVL(TO_CHAR(SUM(CASE WHEN D.TIPDSNDSCBNF IN(93, 30, 55, 60, 39, 32, 53, 42, 54, 58, 61, 63, 19, 53) ");
            sql.AppendLine("                                  THEN B.VLRNGCPMS    END), '999999990D00'), '0') as number(15, 2)");
            sql.AppendLine("        ) AS SALDO_ACORDO ");
            sql.AppendLine("   FROM MRT.t0118058 a ");
            sql.AppendLine("   LEFT JOIN MRT.t0134045 e ON a.codpms = e.CODPMSSBTFRMPGT ");
            sql.AppendLine("   LEFT JOIN MRT.t0134126 f ON a.codpms = f.codpms ");
            sql.AppendLine("                           AND f.codpmsori is not null ");
            sql.AppendLine("      , MRT.T0118066 B ");
            sql.AppendLine("      , MRT.T0100426 C ");
            sql.AppendLine("      , MRT.T0109059 D ");
            sql.AppendLine("  WHERE A.CODPMS = B.CODPMS ");
            sql.AppendLine("    AND B.TIPDSNDSCBNF = D.TIPDSNDSCBNF ");
            //sql.AppendLine("    AND D.TIPOBJDSNVBA = 1 ");
            sql.AppendLine("    AND A.DATNGCPMS = B.DATNGCPMS ");
            sql.AppendLine("    AND A.CODEMP = B.CODEMP ");
            sql.AppendLine("    AND A.CODFILEMP = B.CODFILEMP");

            sql.Append("    AND TRUNC(A.DATCADPMS) BETWEEN TO_DATE('").Append(filtro.DtInicioAcordo.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD')   ").AppendLine();
            sql.Append("                               AND TO_DATE('").Append(filtro.DtFimAcordo.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD') ").AppendLine();
            sql.Append("    AND((A.CODSITPMS <> 4) OR(A.CODSITPMS = 4 AND A.DATCNCPED > A.DATCADPMS AND A.DATCNCPED <= TO_DATE('").Append(filtro.DtFimAcordo.GetValueOrDefault().ToString("yyyy - MM - dd")).Append("', 'YYYY-MM-DD')))").AppendLine();
            sql.Append("    AND B.TIPFRMDSCBNF <> 9 ").AppendLine();
            //sql.Append("    AND B.TIPDSNDSCBNF NOT IN(67, 68) ").AppendLine();
            sql.Append("    AND NVL(A.INDASCARDFRNPMS, 0) = 0 ").AppendLine();
            sql.Append("    AND A.CODFRN = C.CODFRN ").AppendLine();
            sql.Append("    AND NVL(C.TIPIDTEMPASCACOCMC, 0) = 0 ").AppendLine();
            sql.Append("    AND(E.CODPMSSBTFRMPGT IS NULL OR E.CODPMSSBTFRMPGT IS NOT NULL AND E.TIPFRMDSCBNF = 9) ").AppendLine();
            sql.Append("    AND F.CODPMS IS NULL ").AppendLine();

            if (filtro.CodFornecedor != null)
                sql.AppendLine(" AND A.CODFRN = ").Append(filtro.CodFornecedor.ToString()).AppendLine();

            if (filtro.CodTipoVerbaFornecedor != null)
            {
                if (filtro.CodTipoVerbaFornecedor == 0)
                    sql.Append(" AND D.TIPVBAFRN = 0").AppendLine();

                if (filtro.CodTipoVerbaFornecedor != 0)
                    sql.Append(" AND D.TIPVBAFRN <> 0").AppendLine();
            }

            if (filtro.CodObjetivo != null)
                sql.Append(" AND D.TIPOBJDSNVBA = ").Append(filtro.CodObjetivo.ToString()).AppendLine();


            sql.AppendLine("GROUP BY A.CODFRN, C.NOMFRN, B.DATPRVRCBPMS ");


            Command cmd = new Command();

            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();


            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    NovosAcordosSintetico objResult = new NovosAcordosSintetico();

                    if (row.Table.Columns.Contains("DATA_PREVISAO_RECEBTO") && !row.IsNull("DATA_PREVISAO_RECEBTO"))
                        objResult.DtPrevisaoRecebimento = DateTime.Parse((row["DATA_PREVISAO_RECEBTO"]).ToString());

                    if (row.Table.Columns.Contains("CODIGO_FORNECEDOR") && !row.IsNull("CODIGO_FORNECEDOR"))
                        objResult.CodFornecedor = int.Parse(row["CODIGO_FORNECEDOR"].ToString());

                    if (row.Table.Columns.Contains("NOME_FORNECEDOR") && !row.IsNull("NOME_FORNECEDOR"))
                        objResult.NomFornecedor = row["NOME_FORNECEDOR"].ToString();


                    if (row.Table.Columns.Contains("SALDO_EXTRA_ACORDO") && !row.IsNull("SALDO_EXTRA_ACORDO"))
                        objResult.SaldoExtraAcordo = decimal.Parse((row["SALDO_EXTRA_ACORDO"]).ToString());

                    if (row.Table.Columns.Contains("SALDO_ACORDO") && !row.IsNull("SALDO_ACORDO"))
                        objResult.SaldoAcordo = decimal.Parse((row["SALDO_ACORDO"]).ToString());

                    list.Add(objResult);
                }
            }
            ListResult<NovosAcordosSintetico> result = ListResultadoManager.PaginarLista(list, pagina, tamanho, coluna, sentido);
            result.AggregateSummary = new Dictionary<string, object>();

            decimal sumSaldoExtraAcordo = list.Sum(p => p.SaldoExtraAcordo.GetValueOrDefault());
            decimal sumSaldoAcordo = list.Sum(p => p.SaldoAcordo.GetValueOrDefault());
            result.AggregateSummary.Add("sumSaldoExtraAcordo", sumSaldoExtraAcordo);
            result.AggregateSummary.Add("sumSaldoAcordo", sumSaldoAcordo);

            return result;
        }

        public static ListResult<AcordosCanceladosAnalitico> AcordosCanceladosAnalitico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            StringBuilder sql = new StringBuilder();
            List<AcordosCanceladosAnalitico> list = new List<AcordosCanceladosAnalitico>();

            sql.AppendLine("SELECT DISTINCT A.CODFRN AS CODIGO_FORNECEDOR ");
            sql.AppendLine("     , C.NOMFRN AS NOME_FORNECEDOR ");
            sql.AppendLine("     , A.CODPMS AS ACORDO ");
            sql.AppendLine("     , TRUNC(A.DATCNCPED) AS DATCNC ");
            sql.AppendLine("     , B.TIPDSNDSCBNF || ' - ' || D.DESDSNDSCBNF AS EMPENHO ");
            sql.AppendLine("     , B.VLRNGCPMS AS VLRCNC ");
            sql.AppendLine("  FROM MRT.T0118058 A ");
            sql.AppendLine("     , MRT.T0118066 B ");
            sql.AppendLine("     , MRT.T0100426 C ");
            sql.AppendLine("     , MRT.T0109059 D ");
            sql.AppendLine("     , MRT.t0109059 T ");
            sql.AppendLine(" WHERE A.CODSITPMS = 4 ");
            sql.AppendLine(" AND TRUNC(A.DATCNCPED) > TRUNC(A.DATCADPMS) ");
            sql.AppendLine(" AND (A.CODFRN = 0 OR 0 = 0) ");
            sql.AppendLine(" AND A.CODPMS = B.CODPMS ");
            sql.AppendLine(" AND A.DATNGCPMS = B.DATNGCPMS ");
            sql.AppendLine(" AND A.CODEMP = B.CODEMP ");
            sql.AppendLine(" AND A.CODFILEMP = B.CODFILEMP ");
            sql.AppendLine(" AND NVL(A.INDASCARDFRNPMS, 0) = 0 ");
            sql.AppendLine(" AND B.TIPFRMDSCBNF <> 9 ");
            sql.AppendLine(" AND B.TIPDSNDSCBNF = D.TIPDSNDSCBNF ");
            //sql.AppendLine(" AND D.TIPOBJDSNVBA = 1 ");
            sql.AppendLine(" AND A.CODFRN = C.CODFRN ");
            sql.AppendLine(" AND NVL(C.TIPIDTEMPASCACOCMC, 0) = 0  ");
            sql.AppendLine(" AND B.TIPDSNDSCBNF = D.TIPDSNDSCBNF ");

            sql.Append(" AND TRUNC(A.DATCADPMS) BETWEEN  TO_DATE('").Append(filtro.DtInicioAcordo.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD')  ").AppendLine();
            sql.Append("                             AND TO_DATE('").Append(filtro.DtFimAcordo.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD') ").AppendLine();


            if (filtro.CodFornecedor != null)
                sql.Append(" AND A.CODFRN = ").Append(filtro.CodFornecedor.ToString()).AppendLine();

            if (filtro.CodTipoVerbaFornecedor != null)
            {
                if (filtro.CodTipoVerbaFornecedor == 0)
                    sql.Append(" AND D.TIPVBAFRN = 0").AppendLine();

                if (filtro.CodTipoVerbaFornecedor != 0)
                    sql.Append(" AND D.TIPVBAFRN <> 0").AppendLine();
            }

            if (filtro.CodObjetivo != null)
                sql.Append(" AND D.TIPOBJDSNVBA = ").Append(filtro.CodObjetivo.ToString()).AppendLine();

            if (filtro.CodFornecedor != null)
                sql.Append(" AND A.CODFRN = ").Append(filtro.CodFornecedor);


            sql.AppendLine(" UNION ALL");

            sql.AppendLine(" SELECT DISTINCT A.CODFRN ");
            sql.AppendLine("      , TO_CHAR(A.CODFRN, '999999') || ' - ' || trim(C.NOMFRN) AS NOME_FORNECEDOR ");
            sql.AppendLine("      , A.CODPMS ");
            sql.AppendLine("      , TRUNC(E.DATALTPMS) ");
            sql.AppendLine("      , B.TIPDSNDSCBNF || ' - ' || D.DESDSNDSCBNF AS EMPENHO ");
            sql.AppendLine("      , E.VLRPGOPMS - E.VLRPGOPMSANT AS VLRCNC ");
            sql.AppendLine("   FROM MRT.T0118058 A");
            sql.AppendLine("      , MRT.T0118066 B");
            sql.AppendLine("      , MRT.T0100426 C");
            sql.AppendLine("      , MRT.T0109059 D");
            sql.AppendLine("      , MRT.T0120540 E");
            sql.AppendLine("      , MRT.t0109059 T ");
            sql.AppendLine("  WHERE B.VLRPDAPMS > 0 ");
            sql.AppendLine(" AND(A.CODFRN = 0 OR 0 = 0) ");
            sql.AppendLine(" AND A.CODPMS = B.CODPMS ");
            sql.AppendLine(" AND A.DATNGCPMS = B.DATNGCPMS ");
            sql.AppendLine(" AND A.CODEMP = B.CODEMP ");
            sql.AppendLine(" AND A.CODFILEMP = B.CODFILEMP ");
            sql.AppendLine(" AND NVL(A.INDASCARDFRNPMS, 0) = 0 ");
            sql.AppendLine(" AND B.TIPFRMDSCBNF <> 9 ");
            sql.AppendLine(" AND B.TIPDSNDSCBNF = D.TIPDSNDSCBNF ");
            //sql.AppendLine(" AND D.TIPOBJDSNVBA = 1 ");
            sql.AppendLine(" AND A.CODFRN = C.CODFRN ");
            sql.AppendLine(" AND NVL(C.TIPIDTEMPASCACOCMC, 0) = 0 ");
            sql.AppendLine(" AND B.TIPDSNDSCBNF = D.TIPDSNDSCBNF ");
            sql.AppendLine(" AND A.CODPMS = E.CODPMS ");
            sql.AppendLine(" AND A.DATNGCPMS = E.DATNGCPMS ");
            sql.AppendLine(" AND A.CODEMP = E.CODEMP ");
            sql.AppendLine(" AND A.CODFILEMP = E.CODFILEMP ");
            sql.AppendLine(" AND E.FLGLSTPLHLMT = 'P' ");
            sql.AppendLine(" AND DESJSTCNCVLRARDCMC <> ' '");

            sql.Append("   AND TRUNC(A.DATCADPMS) BETWEEN  TO_DATE('").Append(filtro.DtInicioAcordo.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD')   ").AppendLine();
            sql.Append("                               AND TO_DATE('").Append(filtro.DtFimAcordo.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD') ").AppendLine();

            if (filtro.CodFornecedor != null)
                sql.AppendLine(" AND A.CODFRN = ").Append(filtro.CodFornecedor.ToString()).AppendLine();

            if (filtro.CodTipoVerbaFornecedor != null)
                sql.Append(" AND D.TIPVBAFRN = ").Append(filtro.CodTipoVerbaFornecedor.ToString()).AppendLine();


            if (filtro.CodObjetivo != null)
                sql.Append(" AND D.TIPOBJDSNVBA = ").Append(filtro.CodObjetivo.ToString()).AppendLine();

            if (filtro.CodFornecedor != null)
                sql.Append(" AND A.CODFRN = ").Append(filtro.CodFornecedor);



            Command cmd = new Command();

            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();


            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    AcordosCanceladosAnalitico objResult = new AcordosCanceladosAnalitico();

                    if (row.Table.Columns.Contains("EMPENHO") && !row.IsNull("EMPENHO"))
                        objResult.NomDestinoObjetivo = row["EMPENHO"].ToString();

                    //if (row.Table.Columns.Contains("TIPDSNDSCBNF") && !row.IsNull("TIPDSNDSCBNF"))
                    //    objResult.CodDestinoObjetivo = int.Parse(row["TIPDSNDSCBNF"].ToString());

                    if (row.Table.Columns.Contains("CODIGO_FORNECEDOR") && !row.IsNull("CODIGO_FORNECEDOR"))
                        objResult.CodFornecedor = int.Parse(row["CODIGO_FORNECEDOR"].ToString());

                    if (row.Table.Columns.Contains("NOME_FORNECEDOR") && !row.IsNull("NOME_FORNECEDOR"))
                        objResult.NomFornecedor = row["NOME_FORNECEDOR"].ToString();

                    if (row.Table.Columns.Contains("ACORDO") && !row.IsNull("ACORDO"))
                        objResult.CodPromessa = int.Parse((row["ACORDO"]).ToString());

                    if (row.Table.Columns.Contains("VLRCNC") && !row.IsNull("VLRCNC"))
                        objResult.VlrAcordo = decimal.Parse((row["VLRCNC"]).ToString());

                    //if (row.Table.Columns.Contains("DATCNC") && !row.IsNull("DATCNC"))
                    //    objResult.DtCancelamento = DateTime.Parse((row["DATCNC"]).ToString());

                    list.Add(objResult);
                }
            }
            ListResult<AcordosCanceladosAnalitico> result = ListResultadoManager.PaginarLista(list, pagina, tamanho, coluna, sentido);
            result.AggregateSummary = new Dictionary<string, object>();

            decimal sumVlrAcordo = list.Sum(p => p.VlrAcordo.GetValueOrDefault());

            result.AggregateSummary.Add("sumVlrAcordo", sumVlrAcordo);

            return result;

        }

        public static ListResult<AcordosCanceladosSintetico> AcordosCanceladosSintetico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            StringBuilder sql = new StringBuilder();
            List<AcordosCanceladosSintetico> list = new List<AcordosCanceladosSintetico>();

            sql.AppendLine("SELECT A.CODFRN  AS CODIGO_FORNECEDOR ");
            sql.AppendLine("     , C.NOMFRN AS NOME_FORNECEDOR ");
            sql.AppendLine("     , TRUNC(A.DATCNCPED) AS DATCNC ");
            sql.AppendLine("     , B.TIPDSNDSCBNF || ' - ' || D.DESDSNDSCBNF AS EMPENHO ");
            sql.AppendLine("     , SUM(B.VLRNGCPMS) AS VLRCNC ");
            sql.AppendLine("  FROM MRT.T0118058 A ");
            sql.AppendLine("     , MRT.T0118066 B ");
            sql.AppendLine("     , MRT.T0100426 C ");
            sql.AppendLine("     , MRT.T0109059 D ");
            sql.AppendLine(" WHERE A.CODSITPMS = 4 ");
            sql.AppendLine("   AND TRUNC(A.DATCNCPED) > TRUNC(A.DATCADPMS) ");
            sql.AppendLine("   AND (A.CODFRN = 0 OR 0 = 0) ");
            sql.AppendLine("   AND A.CODPMS = B.CODPMS ");
            sql.AppendLine("   AND A.DATNGCPMS = B.DATNGCPMS ");
            sql.AppendLine("   AND A.CODEMP = B.CODEMP ");
            sql.AppendLine("   AND A.CODFILEMP = B.CODFILEMP ");
            sql.AppendLine("   AND NVL(A.INDASCARDFRNPMS, 0) = 0 ");
            sql.AppendLine("   AND B.TIPFRMDSCBNF <> 9 ");
            sql.AppendLine("   AND B.TIPDSNDSCBNF = D.TIPDSNDSCBNF ");
            //sql.AppendLine("   AND D.TIPOBJDSNVBA = 1 ");
            sql.AppendLine("   AND A.CODFRN = C.CODFRN ");
            sql.AppendLine("   AND NVL(C.TIPIDTEMPASCACOCMC, 0) = 0  ");
            sql.AppendLine("   AND B.TIPDSNDSCBNF = D.TIPDSNDSCBNF ");

            sql.Append("   AND TRUNC(A.DATCADPMS) BETWEEN TO_DATE('").Append(filtro.DtInicioAcordo.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD') ").AppendLine();
            sql.Append("                              AND TO_DATE('").Append(filtro.DtFimAcordo.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD') ").AppendLine();

            if (filtro.CodFornecedor != null)
                sql.Append(" AND A.CODFRN = ").Append(filtro.CodFornecedor.ToString()).AppendLine();

            if (filtro.CodTipoVerbaFornecedor != null)
                sql.Append(" AND D.TIPVBAFRN = ").Append(filtro.CodTipoVerbaFornecedor.ToString()).AppendLine();

            if (filtro.CodObjetivo != null)
                sql.Append(" AND D.TIPOBJDSNVBA = ").Append(filtro.CodObjetivo.ToString()).AppendLine();

            if (filtro.CodFornecedor != null)
                sql.Append(" AND A.CODFRN = ").Append(filtro.CodFornecedor).AppendLine();

            sql.AppendLine("  GROUP BY  A.CODFRN , C.NOMFRN, TRUNC(A.DATCNCPED), B.TIPDSNDSCBNF, D.DESDSNDSCBNF ");

            sql.AppendLine(" UNION ALL ");

            sql.AppendLine("SELECT A.CODFRN  ");
            sql.AppendLine("     , TO_CHAR(A.CODFRN, '999999') || ' - ' || trim(C.NOMFRN) AS NOME_FORNECEDOR ");
            sql.AppendLine("     , TRUNC(E.DATALTPMS) AS DATCNC ");
            sql.AppendLine("     , B.TIPDSNDSCBNF || ' - ' || D.DESDSNDSCBNF AS EMPENHO ");
            sql.AppendLine("     , SUM(E.VLRPGOPMS) - SUM(E.VLRPGOPMSANT) AS VLRCNC ");
            sql.AppendLine("  FROM MRT.T0118058 A ");
            sql.AppendLine("     , MRT.T0118066 B ");
            sql.AppendLine("     , MRT.T0100426 C ");
            sql.AppendLine("     , MRT.T0109059 D ");
            sql.AppendLine("     , MRT.T0120540 E ");
            sql.AppendLine(" WHERE B.VLRPDAPMS > 0 ");
            sql.AppendLine("   AND (A.CODFRN = 0 OR 0 = 0) ");
            sql.AppendLine("   AND A.CODPMS = B.CODPMS ");
            sql.AppendLine("   AND A.DATNGCPMS = B.DATNGCPMS ");
            sql.AppendLine("   AND A.CODEMP = B.CODEMP ");
            sql.AppendLine("   AND A.CODFILEMP = B.CODFILEMP ");
            sql.AppendLine("   AND NVL(A.INDASCARDFRNPMS, 0) = 0 ");
            sql.AppendLine("   AND B.TIPFRMDSCBNF <> 9 ");
            sql.AppendLine("   AND B.TIPDSNDSCBNF = D.TIPDSNDSCBNF ");
            //sql.AppendLine("   AND D.TIPOBJDSNVBA = 1 ");
            sql.AppendLine("   AND A.CODFRN = C.CODFRN ");
            sql.AppendLine("   AND NVL(C.TIPIDTEMPASCACOCMC, 0) = 0 ");
            sql.AppendLine("   AND B.TIPDSNDSCBNF = D.TIPDSNDSCBNF ");
            sql.AppendLine("   AND A.CODPMS = E.CODPMS ");
            sql.AppendLine("   AND A.DATNGCPMS = E.DATNGCPMS ");
            sql.AppendLine("   AND A.CODEMP = E.CODEMP ");
            sql.AppendLine("   AND A.CODFILEMP = E.CODFILEMP ");
            sql.AppendLine("   AND E.FLGLSTPLHLMT = 'P' ");
            sql.AppendLine("   AND DESJSTCNCVLRARDCMC <> ' '");

            sql.Append(" AND TRUNC(A.DATCADPMS) BETWEEN TO_DATE('").Append(filtro.DtInicioAcordo.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD') ").AppendLine();
            sql.Append("                            AND TO_DATE('").Append(filtro.DtFimAcordo.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD') ").AppendLine();

            if (filtro.CodFornecedor != null)
                sql.AppendLine(" AND A.CODFRN = ").Append(filtro.CodFornecedor.ToString()).AppendLine();

            if (filtro.CodTipoVerbaFornecedor != null)
                sql.Append(" AND D.TIPVBAFRN = ").Append(filtro.CodTipoVerbaFornecedor.ToString()).AppendLine();

            if (filtro.CodObjetivo != null)
                sql.Append(" AND D.TIPOBJDSNVBA = ").Append(filtro.CodObjetivo.ToString()).AppendLine();

            if (filtro.CodFornecedor != null)
                sql.Append(" AND A.CODFRN = ").Append(filtro.CodFornecedor);

            sql.AppendLine("GROUP BY A.CODFRN , C.NOMFRN , TRUNC(E.DATALTPMS) , B.TIPDSNDSCBNF , D.DESDSNDSCBNF  ");
            //sql.AppendLine(" ORDER BY 1,2,3,4 ");

            Command cmd = new Command();

            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();


            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    AcordosCanceladosSintetico objResult = new AcordosCanceladosSintetico();

                    if (row.Table.Columns.Contains("EMPENHO") && !row.IsNull("EMPENHO"))
                        objResult.NomDestinoObjetivo = row["EMPENHO"].ToString();

                    if (row.Table.Columns.Contains("CODIGO_FORNECEDOR") && !row.IsNull("CODIGO_FORNECEDOR"))
                        objResult.CodFornecedor = int.Parse(row["CODIGO_FORNECEDOR"].ToString());

                    if (row.Table.Columns.Contains("NOME_FORNECEDOR") && !row.IsNull("NOME_FORNECEDOR"))
                        objResult.NomFornecedor = row["NOME_FORNECEDOR"].ToString();

                    //if (row.Table.Columns.Contains("ACORDO") && !row.IsNull("ACORDO"))
                    //    objResult.CodPromessa = int.Parse((row["ACORDO"]).ToString());

                    if (row.Table.Columns.Contains("VLRCNC") && !row.IsNull("VLRCNC"))
                        objResult.VlrAcordo = decimal.Parse((row["VLRCNC"]).ToString());

                    if (row.Table.Columns.Contains("DATCNC") && !row.IsNull("DATCNC"))
                        objResult.DtCancelamento = DateTime.Parse((row["DATCNC"]).ToString());

                    list.Add(objResult);
                }
            }
            ListResult<AcordosCanceladosSintetico> result = ListResultadoManager.PaginarLista(list, pagina, tamanho, coluna, sentido);
            result.AggregateSummary = new Dictionary<string, object>();

            decimal sumVlrAcordo = list.Sum(p => p.VlrAcordo.GetValueOrDefault());

            result.AggregateSummary.Add("sumVlrAcordo", sumVlrAcordo);

            return result;
        }
    }
}