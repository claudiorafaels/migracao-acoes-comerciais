using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using Marketing.GestaoVerbasAPI.App_Code.Connection;
using Marketing.GestaoVerbasAPI.Models;

namespace Marketing.GestaoVerbasAPI.App_Code.DAL
{
    public class RelatoriosVerbasEmitidasDAL
    {
        public static ListResult<RelatoriosVerbasEmitidas> PorNegociacaoVerba(int pagina, int tamanho, string coluna, string sentido, RelatoriosVerbasEmitidas obj)
        {
            StringBuilder sql = new StringBuilder();
            List<RelatoriosVerbasEmitidas> list = new List<RelatoriosVerbasEmitidas>();

            sql.Append("SELECT NGC.CODNGC").AppendLine();
            sql.Append("     , NGC.DATCADNGC").AppendLine();
            sql.Append("     , NGC.VLRVBAFRN").AppendLine();
            sql.Append("     , NGC.DESOBSSLC").AppendLine();
            sql.Append("     , NGC.DESNGC").AppendLine();
            sql.Append("     , NGC.CODSTANGCFRN ").AppendLine();
            sql.Append("     , FIL.CODFILEMP").AppendLine();
            sql.Append("     , FIL.DESABVFILEMP").AppendLine();
            sql.Append("     , FRN.CODFRN").AppendLine();
            sql.Append("     , FRN.NOMFRN ").AppendLine();
            sql.Append("     , HST.DATHRAGRCHST ").AppendLine();
            sql.Append("     , DIV.CODDIVCMP ").AppendLine();
            sql.Append("     , DIV.DESDIVCMP ").AppendLine();
            sql.Append("     , DIR.CODDRTCMP").AppendLine();
            sql.Append("     , DIR.DESDRTCMP").AppendLine();
            sql.Append("     , COM.CODCPR ").AppendLine();
            sql.Append("     , COM.NOMCPR").AppendLine();
            sql.Append("  FROM MRT.CADNGCVBAFRN NGC").AppendLine();
            sql.Append("  LEFT JOIN MRT.HSTNGCVBAFRN HST ON NGC.CODNGC = HST.CODNGC AND HST.CODSTANGCFRN = 3");
            sql.Append(" INNER JOIN MRT.T0100426 FRN ON NGC.CODFRN = FRN.CODFRN ").AppendLine();
            sql.Append(" INNER JOIN MRT.T0118570 DIV ON DIV.CODGERPRD = FRN.CODGERPRD ").AppendLine();
            sql.Append(" INNER JOIN MRT.T0123183 DIR ON DIR.CODDRTCMP = DIV.CODDRTCMP ").AppendLine();
            sql.Append(" INNER JOIN MRT.T0112963 FIL ON FIL.CODFILEMP = NGC.CODFILEMPORIVBA ").AppendLine();
            sql.Append(" INNER JOIN MRT.T0113625 COM ON COM.CODCPR = NGC.CODCPR").AppendLine();
            sql.Append(" WHERE HST.DATHRAGRCHST >= TO_DATE('").Append(obj.DtAprovacaoNegociacaoInicio.GetValueOrDefault().ToString("yyy-MM-dd")).Append("', 'YYYY-MM-DD') ").AppendLine();
            sql.Append("   AND HST.DATHRAGRCHST <= TO_DATE('").Append(obj.DtAprovacaoNegociacaoFim.GetValueOrDefault().ToString("yyy-MM-dd")).Append(" 23:59:59', 'YYYY-MM-DD hh24:mi:ss') ").AppendLine();


            if (obj.CodNegociacaoVerba != null)
                sql.Append("   AND NGC.CODNGC = ").Append(obj.CodNegociacaoVerba).AppendLine();

            if (obj.CodStatusNegociacao != null)
                sql.Append("   AND NGC.CODSTANGCFRN = ").Append(obj.CodStatusNegociacao).AppendLine();

            if (obj.CodFilialEmpresa != null)
                sql.Append("   AND NGC.CODFILEMPORIVBA = ").Append(obj.CodFilialEmpresa).AppendLine();

            if (obj.CodComprador != null)
                sql.Append("   AND NGC.CODCPR = ").Append(obj.CodComprador).AppendLine();

            if (obj.CodFornecedor != null)
                sql.Append("   AND NGC.CODFRN = ").Append(obj.CodFornecedor).AppendLine();

            if (obj.CodCelula != null)
                sql.Append("   AND DIV.CODDIVCMP = ").Append(obj.CodCelula).AppendLine();

            if (obj.CodDiretoria != null)
                sql.Append("  AND DIR.CODDRTCMP = ").Append(obj.CodDiretoria).AppendLine();
            

            sql.AppendLine(" ORDER BY NGC.CODNGC  ");

            Command cmd = new Command();

            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();


            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    RelatoriosVerbasEmitidas objResult = new RelatoriosVerbasEmitidas();

                    //if (row.Table.Columns.Contains("DATCADNGC") && !row.IsNull("DATCADNGC"))
                    //    objResult.DtCadastroNegociacao = DateTime.Parse((row["DATCADNGC"]).ToString());
                    if (row.Table.Columns.Contains("DATHRAGRCHST") && !row.IsNull("DATHRAGRCHST"))
                        objResult.DtAprovacaoNegociacao = DateTime.Parse((row["DATHRAGRCHST"]).ToString());

                    if (row.Table.Columns.Contains("CODSTANGCFRN") && !row.IsNull("CODSTANGCFRN"))
                        objResult.CodStatusNegociacao = int.Parse((row["CODSTANGCFRN"]).ToString());

                    if (row.Table.Columns.Contains("CODFILEMP") && !row.IsNull("CODFILEMP"))
                        objResult.CodFilialEmpresa = int.Parse((row["CODFILEMP"]).ToString());

                    if (row.Table.Columns.Contains("DESABVFILEMP") && !row.IsNull("DESABVFILEMP"))
                        objResult.NomFilialEmpresa = (row["DESABVFILEMP"]).ToString();

                    if (row.Table.Columns.Contains("CODFRN") && !row.IsNull("CODFRN"))
                        objResult.CodFornecedor = int.Parse((row["CODFRN"]).ToString());

                    if (row.Table.Columns.Contains("NOMFRN") && !row.IsNull("NOMFRN"))
                        objResult.NomFornecedor = (row["NOMFRN"]).ToString();

                    if (row.Table.Columns.Contains("VLRVBAFRN") && !row.IsNull("VLRVBAFRN"))
                        objResult.VlrVerbaNegociacao = Decimal.Parse((row["VLRVBAFRN"]).ToString());

                    if (row.Table.Columns.Contains("DESOBSSLC") && !row.IsNull("DESOBSSLC"))
                        objResult.DesObservacaoSolicitacao = (row["DESOBSSLC"]).ToString();

                    if (row.Table.Columns.Contains("CODNGC") && !row.IsNull("CODNGC"))
                        objResult.CodNegociacaoVerba = int.Parse((row["CODNGC"]).ToString());

                    if (row.Table.Columns.Contains("DESNGC") && !row.IsNull("DESNGC"))
                        objResult.NomNegociacaoVerba = (row["DESNGC"]).ToString();


                    if (row.Table.Columns.Contains("CODDIVCMP") && !row.IsNull("CODDIVCMP"))
                        objResult.CodCelula = int.Parse((row["CODDIVCMP"]).ToString());

                    if (row.Table.Columns.Contains("DESDIVCMP") && !row.IsNull("DESDIVCMP"))
                        objResult.NomCelula = (row["DESDIVCMP"]).ToString();

                    if (row.Table.Columns.Contains("CODDRTCMP") && !row.IsNull("CODDRTCMP"))
                        objResult.CodDiretoria = int.Parse((row["CODDRTCMP"]).ToString());

                    if (row.Table.Columns.Contains("DESDRTCMP") && !row.IsNull("DESDRTCMP"))
                        objResult.NomDiretoria = (row["DESDRTCMP"]).ToString();

                    if (row.Table.Columns.Contains("CODCPR") && !row.IsNull("CODCPR"))
                        objResult.CodComprador = int.Parse((row["CODCPR"]).ToString());

                    if (row.Table.Columns.Contains("NOMCPR") && !row.IsNull("NOMCPR"))
                        objResult.NomComprador = (row["NOMCPR"]).ToString();

                    list.Add(objResult);
                }
            }
            ListResult<RelatoriosVerbasEmitidas> result = ListResultadoManager.PaginarLista(list, pagina, tamanho, coluna, sentido);
            result.AggregateSummary = new Dictionary<string, object>();

            decimal sumVlrVerbaNegociacao = list.Sum(p => p.VlrVerbaNegociacao.GetValueOrDefault());

            result.AggregateSummary.Add("SumVlrVerbaNegociacao", sumVlrVerbaNegociacao);

            return result;
        }

        public static ListResult<RelatoriosVerbasEmitidas> PorNegociacaoVerbaEmpenho(int pagina, int tamanho, string coluna, string sentido, RelatoriosVerbasEmitidas obj)
        {
            StringBuilder sql = new StringBuilder();
            List<RelatoriosVerbasEmitidas> list = new List<RelatoriosVerbasEmitidas>();

            sql.AppendLine("SELECT DEST.CODNGC");
            sql.AppendLine("     , DEST.TIPDSNDSCBNF");
            sql.AppendLine("     , TPDEST.DESDSNDSCBNF");
            sql.AppendLine("     , DEST.VLRVBAFRN");
            sql.AppendLine("     , DEST.DESOBSSLC");
            sql.AppendLine("     , TPDEST.TIPVBAFRN");
            sql.AppendLine("     , TPDEST.TIPOBJDSNVBA");
            sql.AppendLine("     , OBJ.DESOBJDSNVBA");
            sql.AppendLine("     , CAR.CODMCOVBAFRN");
            sql.AppendLine("     , NGC.DATCADNGC");
            sql.AppendLine("     , NGC.CODSTANGCFRN");
            sql.AppendLine("     , NGC.CODSTANGCFRN");
            sql.AppendLine("     , NGC.DESNGC");
            sql.AppendLine("     , FIL.CODFILEMP");
            sql.AppendLine("     , FIL.DESABVFILEMP");
            sql.AppendLine("     , FRN.CODFRN");
            sql.AppendLine("     , FRN.NOMFRN");
            sql.AppendLine("     , DEST.CODPMS");
            sql.AppendLine("     , HST.DATHRAGRCHST ");
            sql.AppendLine("     , DIV.CODDIVCMP ");
            sql.AppendLine("     , DIV.DESDIVCMP ");
            sql.AppendLine("     , COM.CODGERPRD ");
            sql.AppendLine("     , DIR.CODDRTCMP");
            sql.AppendLine("     , DIR.DESDRTCMP");
            sql.AppendLine("     , COM.CODCPR ");
            sql.AppendLine("     , COM.NOMCPR");
            sql.AppendLine("  FROM MRT.RLCNGCVBAFRNDSN DEST");
            sql.AppendLine(" INNER JOIN MRT.T0109059 TPDEST ON TPDEST.TIPDSNDSCBNF = DEST.TIPDSNDSCBNF");
            sql.AppendLine(" INNER JOIN MRT.CADOBJDSNVBA  OBJ ON TPDEST.TIPOBJDSNVBA = OBJ.TIPOBJDSNVBA");
            sql.AppendLine("  LEFT JOIN MRT.CADMCOVBAFRN CAR ON CAR.CODNGC = DEST.CODNGC AND DEST.TIPDSNDSCBNF = CAR.TIPDSNDSCBNF");
            sql.AppendLine(" INNER JOIN MRT.CADNGCVBAFRN NGC ON DESt.CODNGC = NGC.CODNGC");
            sql.AppendLine("  LEFT JOIN MRT.HSTNGCVBAFRN HST ON NGC.CODNGC = HST.CODNGC AND HST.CODSTANGCFRN = 3");
            sql.AppendLine(" INNER JOIN MRT.T0112963 FIL ON FIL.CODFILEMP = NGC.CODFILEMPORIVBA");
            sql.AppendLine(" INNER JOIN MRT.T0100426 FRN ON NGC.CODFRN = FRN.CODFRN");
            sql.AppendLine(" INNER JOIN MRT.T0118570 DIV ON DIV.CODGERPRD = FRN.CODGERPRD ");
            sql.AppendLine(" INNER JOIN MRT.T0123183 DIR ON DIR.CODDRTCMP = DIV.CODDRTCMP ");
            sql.AppendLine(" INNER JOIN MRT.T0113625 COM ON COM.CODCPR = NGC.CODCPR");
            sql.Append(" WHERE HST.DATHRAGRCHST >= TO_DATE('").Append(obj.DtAprovacaoNegociacaoInicio.GetValueOrDefault().ToString("yyy-MM-dd")).Append("', 'YYYY-MM-DD') ").AppendLine();
            sql.Append("   AND HST.DATHRAGRCHST <= TO_DATE('").Append(obj.DtAprovacaoNegociacaoFim.GetValueOrDefault().ToString("yyy-MM-dd")).Append(" 23:59:59', 'YYYY-MM-DD hh24:mi:ss') ").AppendLine();

            if (obj.CodNegociacaoVerba != null)
                sql.Append("   AND NGC.CODNGC = ").Append(obj.CodNegociacaoVerba).AppendLine();

            if (obj.CodDestino != null)
                sql.Append("   AND TPDEST.TIPVBAFRN = ").Append(obj.CodDestino).AppendLine();

            if (obj.CodObjetivo != null)
                sql.Append("   AND TPDEST.TIPOBJDSNVBA = ").Append(obj.CodObjetivo).AppendLine();

            if (obj.CodStatusNegociacao != null)
                sql.Append("   AND NGC.CODSTANGCFRN = ").Append(obj.CodStatusNegociacao).AppendLine();

            if (obj.CodFilialEmpresa != null)
                sql.Append("   AND NGC.CODFILEMPORIVBA = ").Append(obj.CodFilialEmpresa).AppendLine();

            if (obj.CodComprador != null)
                sql.Append("   AND NGC.CODCPR = ").Append(obj.CodComprador).AppendLine();

            if (obj.CodFornecedor != null)
                sql.Append("   AND NGC.CODFRN = ").Append(obj.CodFornecedor).AppendLine();

            if (obj.CodCelula != null)
                sql.Append("   AND DIV.CODDIVCMP = ").Append(obj.CodCelula).AppendLine();

            if (obj.CodDiretoria != null)
                sql.Append("  AND DIR.CODDRTCMP = ").Append(obj.CodDiretoria).AppendLine();

            sql.AppendLine(" ORDER BY NGC.CODNGC  ");

            Command cmd = new Command();

            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();


            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    RelatoriosVerbasEmitidas objResult = new RelatoriosVerbasEmitidas();

                    //if (row.Table.Columns.Contains("DATCADNGC") && !row.IsNull("DATCADNGC"))
                    //    objResult.DtCadastroNegociacao = DateTime.Parse((row["DATCADNGC"]).ToString());
                    if (row.Table.Columns.Contains("DATHRAGRCHST") && !row.IsNull("DATHRAGRCHST"))
                        objResult.DtAprovacaoNegociacao = DateTime.Parse((row["DATHRAGRCHST"]).ToString());


                    if (row.Table.Columns.Contains("TIPVBAFRN") && !row.IsNull("TIPVBAFRN"))
                        objResult.CodDestino = int.Parse((row["TIPVBAFRN"]).ToString());

                    if (row.Table.Columns.Contains("TIPOBJDSNVBA") && !row.IsNull("TIPOBJDSNVBA"))
                        objResult.CodObjetivo = int.Parse((row["TIPOBJDSNVBA"]).ToString());

                    if (row.Table.Columns.Contains("DESOBJDSNVBA") && !row.IsNull("DESOBJDSNVBA"))
                        objResult.NomObjetivo = (row["DESOBJDSNVBA"]).ToString();

                    if (row.Table.Columns.Contains("TIPDSNDSCBNF") && !row.IsNull("TIPDSNDSCBNF"))
                        objResult.CodDestinoObjetivo = int.Parse((row["TIPDSNDSCBNF"]).ToString());

                    if (row.Table.Columns.Contains("DESDSNDSCBNF") && !row.IsNull("DESDSNDSCBNF"))
                        objResult.NomDestinoObjetivo = (row["DESDSNDSCBNF"]).ToString();

                    if (row.Table.Columns.Contains("CODMCOVBAFRN") && !row.IsNull("CODMCOVBAFRN"))
                        objResult.CodCarimbo = int.Parse((row["CODMCOVBAFRN"]).ToString());

                    if (row.Table.Columns.Contains("CODSTANGCFRN") && !row.IsNull("CODSTANGCFRN"))
                        objResult.CodStatusNegociacao = int.Parse((row["CODSTANGCFRN"]).ToString());

                    if (row.Table.Columns.Contains("CODFILEMP") && !row.IsNull("CODFILEMP"))
                        objResult.CodFilialEmpresa = int.Parse((row["CODFILEMP"]).ToString());

                    if (row.Table.Columns.Contains("DESABVFILEMP") && !row.IsNull("DESABVFILEMP"))
                        objResult.NomFilialEmpresa = (row["DESABVFILEMP"]).ToString();

                    if (row.Table.Columns.Contains("CODFRN") && !row.IsNull("CODFRN"))
                        objResult.CodFornecedor = int.Parse((row["CODFRN"]).ToString());

                    if (row.Table.Columns.Contains("NOMFRN") && !row.IsNull("NOMFRN"))
                        objResult.NomFornecedor = (row["NOMFRN"]).ToString();

                    if (row.Table.Columns.Contains("VLRVBAFRN") && !row.IsNull("VLRVBAFRN"))
                        objResult.VlrVerbaEmpenho = Decimal.Parse((row["VLRVBAFRN"]).ToString());

                    if (row.Table.Columns.Contains("DESOBSSLC") && !row.IsNull("DESOBSSLC"))
                        objResult.DesObservacaoSolicitacaoEmpenho = (row["DESOBSSLC"]).ToString();

                    if (row.Table.Columns.Contains("CODNGC") && !row.IsNull("CODNGC"))
                        objResult.CodNegociacaoVerba = int.Parse((row["CODNGC"]).ToString());

                    if (row.Table.Columns.Contains("DESNGC") && !row.IsNull("DESNGC"))
                        objResult.NomNegociacaoVerba = (row["DESNGC"]).ToString();

                    if (row.Table.Columns.Contains("CODPMS") && !row.IsNull("CODPMS"))
                        objResult.CodAcordo = int.Parse((row["CODPMS"]).ToString());

                    if (row.Table.Columns.Contains("CODDIVCMP") && !row.IsNull("CODDIVCMP"))
                        objResult.CodCelula = int.Parse((row["CODDIVCMP"]).ToString());

                    if (row.Table.Columns.Contains("DESDIVCMP") && !row.IsNull("DESDIVCMP"))
                        objResult.NomCelula = (row["DESDIVCMP"]).ToString();

                    if (row.Table.Columns.Contains("CODDRTCMP") && !row.IsNull("CODDRTCMP"))
                        objResult.CodDiretoria = int.Parse((row["CODDRTCMP"]).ToString());

                    if (row.Table.Columns.Contains("DESDRTCMP") && !row.IsNull("DESDRTCMP"))
                        objResult.NomDiretoria = (row["DESDRTCMP"]).ToString();

                    if (row.Table.Columns.Contains("CODCPR") && !row.IsNull("CODCPR"))
                        objResult.CodComprador = int.Parse((row["CODCPR"]).ToString());

                    if (row.Table.Columns.Contains("NOMCPR") && !row.IsNull("NOMCPR"))
                        objResult.NomComprador = (row["NOMCPR"]).ToString();


                    list.Add(objResult);
                }
            }
            ListResult<RelatoriosVerbasEmitidas> result = ListResultadoManager.PaginarLista(list, pagina, tamanho, coluna, sentido);
            result.AggregateSummary = new Dictionary<string, object>();

            decimal sumVlrVerbaEmpenho = list.Sum(p => p.VlrVerbaEmpenho.GetValueOrDefault());

            result.AggregateSummary.Add("SumVlrVerbaEmpenho", sumVlrVerbaEmpenho);

            return result;
        }

        public static ListResult<RelatoriosVerbasEmitidas> PorCarrimboFornecedor(int pagina, int tamanho, string coluna, string sentido, RelatoriosVerbasEmitidas obj)
        {
            StringBuilder sql = new StringBuilder();
            List<RelatoriosVerbasEmitidas> list = new List<RelatoriosVerbasEmitidas>();

            sql.Append("SELECT A.DATGRCMCOVBAFRN").AppendLine();
            sql.Append("     , A.CODMCOVBAFRN").AppendLine();
            sql.Append("     , FRN.CODFRN ").AppendLine();
            sql.Append("     , FRN.NOMFRN ").AppendLine();
            sql.Append("     , A.INDSTAMCOVBAFRN ").AppendLine();
            sql.Append("     , C.DESDSNDSCBNF ").AppendLine();
            sql.Append("     , OBJ.DESOBJDSNVBA ").AppendLine();
            //sql.Append("     , (CASE WHEN D.DESOBJMCOVBAFRN IS NULL THEN ' ' ELSE D.DESOBJMCOVBAFRN END) AS OBJETIVO").AppendLine();
            sql.Append("     , (CASE WHEN A.NUMPEDCMP > 0 AND A.CODPMS = 0 THEN 'PEDIDO: '||TO_CHAR(A.NUMPEDCMP) ").AppendLine();
            sql.Append("             WHEN A.NUMPEDCMP = 0 AND A.CODPMS > 0 THEN 'EXTRA ACORDO: '||TO_CHAR(A.CODPMS)").AppendLine();
            sql.Append("             WHEN A.NUMPEDCMP = 0 AND A.CODPMS = 0 AND A.INDSTAMCOVBAFRN = 1 THEN ' ' ").AppendLine();
            sql.Append("             WHEN A.NUMPEDCMP = 0 AND A.CODPMS = 0 THEN 'ACORDO REF.: '||SUBSTR(A.DESOBSMCOVBAFRN, 47, 29) END ) AS ENTIDADE  ").AppendLine();
            //sql.Append("     , B.CODFILEMP ").AppendLine();
            //sql.Append("     , F.DESABVFILEMP ").AppendLine();
            sql.Append("     , SUM(CASE WHEN INDSTAMCOVBAFRN IN (1,2) THEN B.VLRPRVMCOVBAFRN ELSE B.VLRRLZMCOVBAFRN END) AS VALOR  ").AppendLine();
            sql.Append("     , REPLACE(CASE WHEN ( A.NUMPEDCMP > 0 AND A.CODPMS = 0 ) OR ( A.NUMPEDCMP = 0 AND A.CODPMS > 0) THEN A.DESOBSMCOVBAFRN ").AppendLine();
            sql.Append("                    WHEN   A.NUMPEDCMP = 0 AND A.CODPMS = 0 AND A.INDSTAMCOVBAFRN = 1 THEN A.DESOBSMCOVBAFRN ELSE ' ' END, '\"', '' ) AS OBSERVACAO").AppendLine();
            //sql.Append("     , CASE WHEN A.INDSTAMCOVBAFRN IN (3, 5, 6) THEN 'REALIZADO' ").AppendLine();
            //sql.Append("            WHEN A.INDSTAMCOVBAFRN = 1 THEN 'SIMULADO' ").AppendLine();
            //sql.Append("            WHEN A.INDSTAMCOVBAFRN = 2 THEN 'ASSINADO' END AS SITUACAO  ").AppendLine();

            sql.Append("   FROM MRT.CADMCOVBAFRN A ").AppendLine();
            sql.Append("  INNER JOIN MRT.CADITEMCOVBAFRN B ON B.CODMCOVBAFRN = A.CODMCOVBAFRN ").AppendLine();
            sql.Append("  INNER JOIN MRT.T0131259 RLC ON RLC.CODMER = B.CODMER  AND RLC.CODFILEMP = B.CODFILEMP").AppendLine();
            sql.Append("  INNER JOIN MRT.T0109059 C ON C.TIPDSNDSCBNF = B.TIPDSNDSCBNF").AppendLine();
            sql.Append("  INNER JOIN MRT.T0100086 E ON E.CODMER = B.CODMER  AND E.CODEMP = 1").AppendLine();
            sql.Append("  INNER JOIN MRT.T0100426 FRN ON E.CODFRNPCPMER = FRN.CODFRN").AppendLine();
            sql.Append("  INNER JOIN MRT.T0118570 DIV ON DIV.CODGERPRD = FRN.CODGERPRD").AppendLine();
            sql.Append("  INNER JOIN MRT.CADOBJDSNVBA  OBJ ON c.TIPOBJDSNVBA = OBJ.TIPOBJDSNVBA").AppendLine();
            sql.Append("   LEFT JOIN MRT.CADOBJMCOVBAFRN D  ON D.TIPOBJMCOVBAFRN = A.TIPOBJMCOVBAFRN").AppendLine();
            sql.Append("   LEFT JOIN MRT.CADNGCVBAFRN NGC  ON NGC.CODNGC =  A.CODNGC").AppendLine();
            sql.Append("  WHERE A.DATGRCMCOVBAFRN >= TO_DATE('").Append(obj.DtCadastroCarimboInicio.GetValueOrDefault().ToString("yyy-MM-dd")).AppendLine("', 'YYYY-MM-DD') ");
            sql.Append("    AND A.DATGRCMCOVBAFRN <= TO_DATE('").Append(obj.DtCadastroCarimboFim.GetValueOrDefault().ToString("yyy-MM-dd")).AppendLine(" 23:59:59', 'YYYY-MM-DD hh24:mi:ss') ");

            if (obj.CodNegociacaoVerba != null)
                sql.Append(" AND NGC.CODNGC = ").Append(obj.CodNegociacaoVerba.ToString()).AppendLine();
            if (obj.CodStatusNegociacao != null)
                sql.Append(" AND NGC.CODSTANGCFRN = ").Append(obj.CodStatusNegociacao.ToString()).AppendLine();
            if (obj.CodFilialEmpresa != null)
                sql.Append(" AND NGC.CODFILEMPORIVBA = ").Append(obj.CodFilialEmpresa.ToString()).AppendLine();
            if (obj.CodComprador != null)
                sql.Append(" AND NGC.CODCPR = ").Append(obj.CodComprador).AppendLine();
            if (obj.CodFornecedor != null)
                sql.Append(" AND FRN.CODFRN = ").Append(obj.CodFornecedor).AppendLine();
            if (obj.CodCelula != null)
                sql.Append(" AND DIV.CODDIVCMP = ").Append(obj.CodCelula).AppendLine();
            if (obj.CodDestino != null)
                sql.Append(" AND C.TIPVBAFRN = ").Append(obj.CodDestino).AppendLine();
            if (obj.CodObjetivo != null)
                sql.Append(" AND C.TIPOBJDSNVBA = ").Append(obj.CodObjetivo).AppendLine();
            if (obj.CodMercadoria != null)
                sql.Append(" AND E.CODMER = ").Append(obj.CodMercadoria).AppendLine();
            if (obj.CodCarimbo != null)
                sql.Append(" AND A.CODMCOVBAFRN= ").Append(obj.CodCarimbo).AppendLine();
            if (obj.CodStatusCarimbo != null)
                sql.Append(" AND A.INDSTAMCOVBAFRN = ").Append(obj.CodStatusCarimbo).AppendLine();

            sql.Append("  GROUP BY A.DATGRCMCOVBAFRN").AppendLine();
            sql.Append("         , A.CODMCOVBAFRN").AppendLine();
            sql.Append("         , C.DESDSNDSCBNF").AppendLine();
            sql.Append("         , OBJ.DESOBJDSNVBA").AppendLine();
            sql.Append("         , D.DESOBJMCOVBAFRN").AppendLine();
            sql.Append("         , A.INDSTAMCOVBAFRN").AppendLine();
            sql.Append("         , FRN.CODFRN ").AppendLine();
            sql.Append("         , FRN.NOMFRN ").AppendLine();
            sql.Append("         , (CASE WHEN A.NUMPEDCMP > 0 AND A.CODPMS = 0 THEN 'PEDIDO: '||TO_CHAR(A.NUMPEDCMP)").AppendLine();
            sql.Append("                 WHEN A.NUMPEDCMP = 0 AND A.CODPMS > 0 THEN 'EXTRA ACORDO: '||TO_CHAR(A.CODPMS)").AppendLine();
            sql.Append("                 WHEN A.NUMPEDCMP = 0 AND A.CODPMS = 0 AND A.INDSTAMCOVBAFRN = 1 THEN ' '").AppendLine();
            sql.Append("                 WHEN A.NUMPEDCMP = 0 AND A.CODPMS = 0 THEN 'ACORDO REF.: '||SUBSTR(A.DESOBSMCOVBAFRN, 47, 29) END )").AppendLine();
            sql.Append("         , (CASE WHEN ( A.NUMPEDCMP > 0 AND A.CODPMS = 0 ) OR ( A.NUMPEDCMP = 0 AND A.CODPMS > 0) THEN A.DESOBSMCOVBAFRN").AppendLine();
            sql.Append("                 WHEN   A.NUMPEDCMP = 0 AND A.CODPMS = 0 AND A.INDSTAMCOVBAFRN = 1 THEN A.DESOBSMCOVBAFRN ELSE ' ' END )").AppendLine();
            //sql.Append("         , CASE  WHEN A.INDSTAMCOVBAFRN IN (3, 5, 6) THEN 'REALIZADO'").AppendLine();
            //sql.Append("                 WHEN A.INDSTAMCOVBAFRN = 1 THEN 'SIMULADO'").AppendLine();
            //sql.Append("                 WHEN A.INDSTAMCOVBAFRN = 2 THEN 'ASSINADO' END").AppendLine();


            Command cmd = new Command();

            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();



            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    RelatoriosVerbasEmitidas objResult = new RelatoriosVerbasEmitidas();

                    if (row.Table.Columns.Contains("DATGRCMCOVBAFRN") && !row.IsNull("DATGRCMCOVBAFRN"))
                        objResult.DtCadastroCarimbo = DateTime.Parse((row["DATGRCMCOVBAFRN"]).ToString());

                    if (row.Table.Columns.Contains("CODMCOVBAFRN") && !row.IsNull("CODMCOVBAFRN"))
                        objResult.CodCarimbo = int.Parse((row["CODMCOVBAFRN"]).ToString());

                    //if (row.Table.Columns.Contains("CODFILEMP") && !row.IsNull("CODFILEMP"))
                    //    objResult.CodFilialEmpresa = int.Parse((row["CODFILEMP"]).ToString());
                    //
                    //if (row.Table.Columns.Contains("DESABVFILEMP") && !row.IsNull("DESABVFILEMP"))
                    //    objResult.NomFilialEmpresa = (row["DESABVFILEMP"]).ToString();




                    //if (row.Table.Columns.Contains("TIPVBAFRN") && !row.IsNull("TIPVBAFRN"))
                    //    objResult.CodDestino = int.Parse((row["TIPVBAFRN"]).ToString());

                    //if (row.Table.Columns.Contains("TIPOBJDSNVBA") && !row.IsNull("TIPOBJDSNVBA"))
                    //    objResult.CodObjetivo = int.Parse((row["TIPOBJDSNVBA"]).ToString());

                    if (row.Table.Columns.Contains("DESOBJDSNVBA") && !row.IsNull("DESOBJDSNVBA"))
                        objResult.NomObjetivo = (row["DESOBJDSNVBA"]).ToString();

                    //if (row.Table.Columns.Contains("TIPDSNDSCBNF") && !row.IsNull("TIPDSNDSCBNF"))
                    //    objResult.CodDestinoObjetivo = int.Parse((row["TIPDSNDSCBNF"]).ToString());

                    if (row.Table.Columns.Contains("DESDSNDSCBNF") && !row.IsNull("DESDSNDSCBNF"))
                        objResult.NomDestinoObjetivo = (row["DESDSNDSCBNF"]).ToString();


                    //if (row.Table.Columns.Contains("DESDSNDSCBNF") && !row.IsNull("DESDSNDSCBNF"))
                    //    objResult.NomDestinoObjetivo = (row["DESDSNDSCBNF"]).ToString();


                    if (row.Table.Columns.Contains("ENTIDADE") && !row.IsNull("ENTIDADE"))
                        objResult.DesEntidade = (row["ENTIDADE"]).ToString();

                    if (row.Table.Columns.Contains("CODFRN") && !row.IsNull("CODFRN"))
                        objResult.CodFornecedor = int.Parse((row["CODFRN"]).ToString());

                    if (row.Table.Columns.Contains("NOMFRN") && !row.IsNull("NOMFRN"))
                        objResult.NomFornecedor = (row["NOMFRN"]).ToString();

                    if (row.Table.Columns.Contains("VALOR") && !row.IsNull("VALOR"))
                        objResult.VlrCarimbo = Decimal.Parse((row["VALOR"]).ToString());

                    if (row.Table.Columns.Contains("OBSERVACAO") && !row.IsNull("OBSERVACAO"))
                        objResult.DesObservacaoCarimbo = (row["OBSERVACAO"]).ToString();

                    //if (row.Table.Columns.Contains("SITUACAO") && !row.IsNull("SITUACAO"))
                    //    objResult.DesSituacao = (row["SITUACAO"]).ToString();

                    if (row.Table.Columns.Contains("INDSTAMCOVBAFRN") && !row.IsNull("INDSTAMCOVBAFRN"))
                        objResult.CodStatusCarimbo = int.Parse((row["INDSTAMCOVBAFRN"]).ToString());


                    if (row.Table.Columns.Contains("CODMER") && !row.IsNull("CODMER"))
                        objResult.CodMercadoria = int.Parse((row["CODMER"]).ToString());

                    //if (row.Table.Columns.Contains("CODGRPMER") && !row.IsNull("CODGRPMER"))
                    //    objResult.CodGrupoSimilar = int.Parse((row["CODGRPMER"]).ToString());

                    if (row.Table.Columns.Contains("DESMER") && !row.IsNull("DESMER"))
                        objResult.NomMercadoria = (row["DESMER"]).ToString();

                    if (row.Table.Columns.Contains("CODNGC") && !row.IsNull("CODNGC"))
                        objResult.CodNegociacaoVerba = int.Parse((row["CODNGC"]).ToString());

                    if (row.Table.Columns.Contains("DESNGC") && !row.IsNull("DESNGC"))
                        objResult.NomNegociacaoVerba = (row["DESNGC"]).ToString();

                    list.Add(objResult);
                }
            }

            ListResult<RelatoriosVerbasEmitidas> result = ListResultadoManager.PaginarLista(list, pagina, tamanho, coluna, sentido);
            result.AggregateSummary = new Dictionary<string, object>();

            decimal sumVlrCarimbo = list.Sum(p => p.VlrCarimbo.GetValueOrDefault());

            result.AggregateSummary.Add("SumVlrCarimbo", sumVlrCarimbo);

            return result;
        }

        public static ListResult<RelatoriosVerbasEmitidas> PorCarrimboMercadoria(int pagina, int tamanho, string coluna, string sentido, RelatoriosVerbasEmitidas obj)
        {
            StringBuilder sql = new StringBuilder();
            List<RelatoriosVerbasEmitidas> list = new List<RelatoriosVerbasEmitidas>();

            sql.Append("SELECT A.DATGRCMCOVBAFRN").AppendLine();
            sql.Append("     , A.CODMCOVBAFRN AS CARIMBO ").AppendLine();
            sql.Append("     , E.CODGRPMER").AppendLine();
            sql.Append("     , B.CODMER ").AppendLine();
            sql.Append("     , E.DESMER ").AppendLine();
            sql.Append("     , A.INDSTAMCOVBAFRN ").AppendLine();
            sql.Append("     , C.DESDSNDSCBNF ").AppendLine();
            sql.Append("     , C.TIPOBJDSNVBA ").AppendLine();
            //sql.Append("     , (	CASE WHEN D.DESOBJMCOVBAFRN IS NULL THEN ' ' ELSE D.DESOBJMCOVBAFRN END) AS OBJETIVO  ").AppendLine();
            sql.Append("     , (CASE WHEN A.NUMPEDCMP > 0 AND A.CODPMS = 0 THEN 'PEDIDO: '||TO_CHAR(A.NUMPEDCMP) ").AppendLine();
            sql.Append("             WHEN A.NUMPEDCMP = 0 AND A.CODPMS > 0 THEN 'EXTRA ACORDO: '||TO_CHAR(A.CODPMS)").AppendLine();
            sql.Append("             WHEN A.NUMPEDCMP = 0 AND A.CODPMS = 0 AND A.INDSTAMCOVBAFRN = 1 THEN ' ' ").AppendLine();
            sql.Append("             WHEN A.NUMPEDCMP = 0 AND A.CODPMS = 0 THEN 'ACORDO REF.: '||SUBSTR(A.DESOBSMCOVBAFRN, 47, 29) END ) AS ENTIDADE  ").AppendLine();
            sql.Append("     , B.CODFILEMP ").AppendLine();
            sql.Append("     , F.DESABVFILEMP ").AppendLine();
            sql.Append("     , SUM(CASE WHEN INDSTAMCOVBAFRN IN (1,2) THEN B.VLRPRVMCOVBAFRN ELSE B.VLRRLZMCOVBAFRN END) AS VALOR  ").AppendLine();
            sql.Append("     , REPLACE(CASE WHEN ( A.NUMPEDCMP > 0 AND A.CODPMS = 0 ) OR ( A.NUMPEDCMP = 0 AND A.CODPMS > 0) THEN A.DESOBSMCOVBAFRN ").AppendLine();
            sql.Append("                    WHEN A.NUMPEDCMP = 0 AND A.CODPMS = 0 AND A.INDSTAMCOVBAFRN = 1 THEN A.DESOBSMCOVBAFRN ELSE ' ' END, '\"', '' ) AS OBSERVACAO").AppendLine();
            sql.Append("     , CASE WHEN A.INDSTAMCOVBAFRN IN (3, 5, 6) THEN 'REALIZADO' ").AppendLine();
            sql.Append("            WHEN A.INDSTAMCOVBAFRN = 1 THEN 'SIMULADO' ").AppendLine();
            sql.Append("            WHEN A.INDSTAMCOVBAFRN = 2 THEN 'ASSINADO' END AS SITUACAO  ").AppendLine();

            sql.Append("  FROM MRT.CADMCOVBAFRN A ").AppendLine();
            sql.Append(" INNER JOIN MRT.CADITEMCOVBAFRN B ON B.CODMCOVBAFRN = A.CODMCOVBAFRN ").AppendLine();
            sql.Append(" INNER JOIN MRT.T0131259 RLC ON RLC.CODMER = B.CODMER  AND RLC.CODFILEMP = B.CODFILEMP").AppendLine();
            sql.Append(" INNER JOIN MRT.T0109059 C ON C.TIPDSNDSCBNF = B.TIPDSNDSCBNF ").AppendLine();
            sql.Append(" INNER JOIN MRT.T0100086 E ON E.CODMER = B.CODMER  AND E.CODEMP = 1").AppendLine();
            sql.Append(" INNER JOIN MRT.T0112963 F ON F.CODFILEMP = B.CODFILEMP").AppendLine();
            sql.Append(" INNER JOIN MRT.T0100426 FRN ON E.CODFRNPCPMER = FRN.CODFRN").AppendLine();
            sql.Append(" INNER JOIN MRT.T0118570 DIV ON DIV.CODGERPRD = FRN.CODGERPRD").AppendLine();
            sql.Append("  LEFT JOIN MRT.CADOBJMCOVBAFRN D  ON D.TIPOBJMCOVBAFRN = A.TIPOBJMCOVBAFRN").AppendLine();
            sql.Append("  LEFT JOIN MRT.CADNGCVBAFRN NGC  ON NGC.CODNGC =  A.CODNGC").AppendLine();
            sql.Append(" WHERE A.DATGRCMCOVBAFRN >= TO_DATE('").Append(obj.DtCadastroCarimboInicio.GetValueOrDefault().ToString("yyy-MM-dd")).AppendLine("', 'YYYY-MM-DD') ");
            sql.Append("   AND A.DATGRCMCOVBAFRN <= TO_DATE('").Append(obj.DtCadastroCarimboFim.GetValueOrDefault().ToString("yyy-MM-dd")).AppendLine("', 'YYYY-MM-DD') ");
            //sql.Append("   AND A.CODNGC IS NOT NULL ").AppendLine();

            if (obj.CodNegociacaoVerba != null)
                sql.Append("   AND NGC.CODNGC = ").Append(obj.CodNegociacaoVerba).AppendLine();
            if (obj.CodStatusNegociacao != null)
                sql.Append("   AND NGC.CODSTANGCFRN = ").Append(obj.CodStatusNegociacao).AppendLine();
            if (obj.CodFilialEmpresa != null)
                sql.Append("   AND B.CODFILEMP = ").Append(obj.CodFilialEmpresa.ToString()).AppendLine();
            if (obj.CodComprador != null)
                sql.Append("   AND RLC.CODCPR = ").Append(obj.CodComprador).AppendLine();
            if (obj.CodFornecedor != null)
                sql.Append("   AND FRN.CODFRN = ").Append(obj.CodFornecedor).AppendLine();
            if (obj.CodCelula != null)
                sql.Append("   AND DIV.CODDIVCMP = ").Append(obj.CodCelula).AppendLine();
            if (obj.CodDestino != null)
                sql.Append(" AND C.TIPVBAFRN = ").Append(obj.CodDestino).AppendLine();
            if (obj.CodObjetivo != null)
                sql.Append(" AND C.TIPOBJDSNVBA = ").Append(obj.CodObjetivo).AppendLine();
            if (obj.CodMercadoria != null)
                sql.Append("   AND E.CODMER = ").Append(obj.CodMercadoria).AppendLine();
            if (obj.CodCarimbo != null)
                sql.Append("   AND A.CODMCOVBAFRN = ").Append(obj.CodCarimbo).AppendLine();
            if (obj.CodStatusCarimbo != null)
                sql.AppendLine("   AND A.INDSTAMCOVBAFRN = ").Append(obj.CodStatusCarimbo.ToString()).AppendLine();

            sql.Append("  GROUP BY A.DATGRCMCOVBAFRN").AppendLine();
            sql.Append("         , A.CODMCOVBAFRN ").AppendLine();
            sql.Append("         , B.CODFILEMP").AppendLine();
            sql.Append("         , F.DESABVFILEMP ").AppendLine();
            sql.Append("         , C.DESDSNDSCBNF").AppendLine();
            sql.Append("         , C.TIPOBJDSNVBA").AppendLine();
            sql.Append("         , D.DESOBJMCOVBAFRN").AppendLine();
            sql.Append("         , A.INDSTAMCOVBAFRN").AppendLine();
            sql.Append("         , E.CODGRPMER").AppendLine();
            sql.Append("         , B.CODMER").AppendLine();
            sql.Append("         , E.DESMER").AppendLine();
            sql.Append("         , (CASE WHEN A.NUMPEDCMP > 0 AND A.CODPMS = 0 THEN 'PEDIDO: '||TO_CHAR(A.NUMPEDCMP)").AppendLine();
            sql.Append("                 WHEN A.NUMPEDCMP = 0 AND A.CODPMS > 0 THEN 'EXTRA ACORDO: '||TO_CHAR(A.CODPMS)").AppendLine();
            sql.Append("                 WHEN A.NUMPEDCMP = 0 AND A.CODPMS = 0 AND A.INDSTAMCOVBAFRN = 1 THEN ' '").AppendLine();
            sql.Append("                 WHEN A.NUMPEDCMP = 0 AND A.CODPMS = 0 THEN 'ACORDO REF.: '||SUBSTR(A.DESOBSMCOVBAFRN, 47, 29) END)").AppendLine();
            sql.Append("         , (CASE WHEN ( A.NUMPEDCMP > 0 AND A.CODPMS = 0 ) OR ( A.NUMPEDCMP = 0 AND A.CODPMS > 0) THEN A.DESOBSMCOVBAFRN").AppendLine();
            sql.Append("                 WHEN   A.NUMPEDCMP = 0 AND A.CODPMS = 0 AND A.INDSTAMCOVBAFRN = 1 THEN A.DESOBSMCOVBAFRN ELSE ' ' END )").AppendLine();
            if (obj.CodFilialEmpresa != null)
                sql.Append("         , B.CODFILEMP , F.DESABVFILEMP ").AppendLine();
            sql.Append("         , B.CODMER").AppendLine();
            sql.Append("         , E.DESMER").AppendLine();
            sql.Append("         , FRN.CODFRN").AppendLine();
            sql.Append("         , FRN.NOMFRN").AppendLine();
            sql.Append("         , CASE WHEN A.INDSTAMCOVBAFRN IN (3, 5, 6) THEN 'REALIZADO'").AppendLine();
            sql.Append("                WHEN A.INDSTAMCOVBAFRN = 1 THEN 'SIMULADO' ").AppendLine();
            sql.Append("                WHEN A.INDSTAMCOVBAFRN = 2 THEN 'ASSINADO' END ").AppendLine();

            sql.Append("  ORDER BY B.CODFILEMP  ").AppendLine();
            sql.Append("         , A.CODMCOVBAFRN").AppendLine();
            if (obj.CodFilialEmpresa != null)
                sql.Append("         , B.CODFILEMP ").AppendLine();
            sql.Append("         , B.CODMER ").AppendLine();


            Command cmd = new Command();

            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();


            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    RelatoriosVerbasEmitidas objResult = new RelatoriosVerbasEmitidas();

                    if (row.Table.Columns.Contains("DATGRCMCOVBAFRN") && !row.IsNull("DATGRCMCOVBAFRN"))
                        objResult.DtCadastroCarimbo = DateTime.Parse((row["DATGRCMCOVBAFRN"]).ToString());

                    if (row.Table.Columns.Contains("CARIMBO") && !row.IsNull("CARIMBO"))
                        objResult.CodCarimbo = int.Parse((row["CARIMBO"]).ToString());

                    if (row.Table.Columns.Contains("CODFILEMP") && !row.IsNull("CODFILEMP"))
                        objResult.CodFilialEmpresa = int.Parse((row["CODFILEMP"]).ToString());

                    if (row.Table.Columns.Contains("DESABVFILEMP") && !row.IsNull("DESABVFILEMP"))
                        objResult.NomFilialEmpresa = (row["DESABVFILEMP"]).ToString();

                    if (row.Table.Columns.Contains("DESDSNDSCBNF") && !row.IsNull("DESDSNDSCBNF"))
                        objResult.NomDestinoObjetivo = (row["DESDSNDSCBNF"]).ToString();

                    if (row.Table.Columns.Contains("OBJETIVO") && !row.IsNull("OBJETIVO"))
                        objResult.NomObjetivo = (row["OBJETIVO"]).ToString();

                    if (row.Table.Columns.Contains("ENTIDADE") && !row.IsNull("ENTIDADE"))
                        objResult.DesEntidade = (row["ENTIDADE"]).ToString();

                    if (row.Table.Columns.Contains("CODFRN") && !row.IsNull("CODFRN"))
                        objResult.CodFornecedor = int.Parse((row["CODFRN"]).ToString());

                    if (row.Table.Columns.Contains("NOMFRN") && !row.IsNull("NOMFRN"))
                        objResult.NomFornecedor = (row["NOMFRN"]).ToString();

                    if (row.Table.Columns.Contains("VALOR") && !row.IsNull("VALOR"))
                        objResult.VlrCarimboMercadoria = Decimal.Parse((row["VALOR"]).ToString());

                    if (row.Table.Columns.Contains("OBSERVACAO") && !row.IsNull("OBSERVACAO"))
                        objResult.DesObservacaoCarimbo = (row["OBSERVACAO"]).ToString();

                    //if (row.Table.Columns.Contains("SITUACAO") && !row.IsNull("SITUACAO"))
                    //    objResult.DesSituacao = (row["SITUACAO"]).ToString();

                    if (row.Table.Columns.Contains("INDSTAMCOVBAFRN") && !row.IsNull("INDSTAMCOVBAFRN"))
                        objResult.CodStatusCarimbo = int.Parse((row["INDSTAMCOVBAFRN"]).ToString());

                    if (row.Table.Columns.Contains("CODFILEMP") && !row.IsNull("CODFILEMP"))
                        objResult.CodFilialEmpresa = int.Parse((row["CODFILEMP"]).ToString());

                    if (row.Table.Columns.Contains("DESABVFILEMP") && !row.IsNull("DESABVFILEMP"))
                        objResult.NomFilialEmpresa = (row["DESABVFILEMP"]).ToString();

                    if (row.Table.Columns.Contains("CODMER") && !row.IsNull("CODMER"))
                        objResult.CodMercadoria = int.Parse((row["CODMER"]).ToString());

                    //if (row.Table.Columns.Contains("CODGRPMER") && !row.IsNull("CODGRPMER"))
                    //    objResult.CodGrupoSimilar = int.Parse((row["CODGRPMER"]).ToString());

                    if (row.Table.Columns.Contains("DESMER") && !row.IsNull("DESMER"))
                        objResult.NomMercadoria = (row["DESMER"]).ToString();

                    if (row.Table.Columns.Contains("CODNGC") && !row.IsNull("CODNGC"))
                        objResult.CodNegociacaoVerba = int.Parse((row["CODNGC"]).ToString());

                    if (row.Table.Columns.Contains("DESNGC") && !row.IsNull("DESNGC"))
                        objResult.NomNegociacaoVerba = (row["DESNGC"]).ToString();

                    list.Add(objResult);
                }
            }

            ListResult<RelatoriosVerbasEmitidas> result = ListResultadoManager.PaginarLista(list, pagina, tamanho, coluna, sentido);
            result.AggregateSummary = new Dictionary<string, object>();

            decimal sumVlrCarimboMercadoria = list.Sum(p => p.VlrCarimboMercadoria.GetValueOrDefault());

            result.AggregateSummary.Add("SumVlrCarimboMercadoria", sumVlrCarimboMercadoria);

            return result;
        }


    }
}