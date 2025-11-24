using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using Marketing.GestaoVerbasAPI.Models;

namespace Marketing.GestaoVerbasAPI.App_Code.DAL
{
    public class CarimboItemDAL
    {

        public static List<CarimboItem> ConsultaItensFornecedor(int CodFornecedor, string codFiliais, int? CodComprador, int codCarimbo, string dataRef)
        {
            StringBuilder sql = new StringBuilder();

            //DateTime datafiltro = DateTime.Now.AddDays(-2);
            //if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
            //    datafiltro = DateTime.Now.AddDays(-2);
            //else
            //    datafiltro = DateTime.Now.AddDays(-1);

//#if DEBUG
//datafiltro = new DateTime(2018, 02, 24);
//#endif


            sql.AppendLine(@" SELECT FIL.CODFILEMP
                                   , FIL.DESABVFILEMP
                                   , MER.CODMER
                                   , MER.DESMER
                                   , CLS.DESCLSMER
                                   , NVL(SML.CODGRPMERSMR, 0) AS CODGRPMERSMR
                                   , CST.VLRDIRCSTMEDEFT 
                                   , CASE WHEN (CST.QDEETQMER - QDEVNDDIRMERPND) < 0 THEN 0 ELSE (CST.QDEETQMER - QDEVNDDIRMERPND) END AS QDEETQMER
                                   , CASE WHEN ((CST.QDEETQMER - QDEVNDDIRMERPND) * VLRDIRCSTMEDMER) < 0 THEN 0 
                                           ELSE ((CST.QDEETQMER -QDEVNDDIRMERPND) *VLRDIRCSTMEDMER) END AS VLRETQMER
                                   , CST.QDESLDPEDMER
                                   , CST.VLRSLDPEDMER
                                   , (CST.QDEMEDVNDMNSMER * VLRDIRCSTMEDMER) * 0.833 AS MEDIA
                                   , (CASE WHEN IND.VLRMRGBRTVND IS NULL THEN IND.VLRMRGBRTVND + IND.VLRTOTCSTDTBVND ELSE IND.VLRMRGBRTVND END) AS MB_VND
                                   , (CASE WHEN IND.VLRMRGCRBVND IS NULL THEN IND.VLRMRGCRBVND ELSE IND.VLRMRGCRBVND END) AS MC_VND
                                   , IND.VLRRCTLIQVND
                                   , VLRMEDVBAMRGMER
                                   , VLRMEDVBAPCOMER

                                   , CASE WHEN NVL(SML.CODGRPMERSMR,   0) =  0 THEN 
                                        TRIM(GRP.DESGRPMERSMR) 
                                     ELSE 
                                        TRIM(GRP.DESGRPMERSMR) || ' - ' || TRIM(FIL.CODFILEMP) || TRIM(FIL.DESABVFILEMP) || ' - ' ||  NVL(SML.CODGRPMERSMR, 0) 
                                     END AS DESGRPMERSMRAGP
                                   , GRP.DESGRPMERSMR 

                                   , NVL(FTRCNVPCO, 1) AS FTRCNVPCO
                              
                                   , CASE WHEN (IND.VLRRCTLIQVND) <> 0 THEN 
                                         ROUND((IND.VLRTOTFNDMERVND) /(IND.VLRRCTLIQVND)*100, 2) 
                                         ELSE 0 
                                     END   AS PERFUNVND_TOTAL
                              
                                  , CASE WHEN (IND.VLRRCTLIQVND) <> 0 THEN 
                                        ROUND((IND.VLRTOTFNDMERVND-IND.VLRTOTFNDMRGVND) /(IND.VLRRCTLIQVND)*100, 2) 
                                        ELSE 0
                                    END AS PERFUNVND_PRECO
                                  , IND.VLRTOTFNDMERVND
                                  , IND.VLRTOTFNDMRGVND
                                  , ITE.TIPDSNDSCBNF
                                  , ITE.VLRPRVMCOVBAFRN
                                  , ITE.VLRRLZMCOVBAFRN
                                  , ITE.VLRCNCMCOVBAFRN  
                                FROM MRT.T0131259 RLC 
                               INNER JOIN MRT.T0100426 FRN ON FRN.CODFRN = RLC.CODFRN  AND FRN.CODEMP = 1
                               INNER JOIN MRT.T0112963 FIL ON RLC.CODFILEMP = FIL.CODFILEMP AND FIL.CODEMP = 1
                               INNER JOIN MRT.T0100086 MER ON RLC.CODMER = MER.CODMER AND MER.CODEMP = 1 
                               INNER JOIN MRT.T0100132 CLS ON CLS.CODGRPMER = MER.CODGRPMER AND CLS.CODFMLMER = MER.CODFMLMER AND CLS.CODCLSMER = MER.CODCLSMER AND CLS.DATDSTCLSMER IS NULL
                               INNER JOIN MRT.T0201350 CST ON CST.CODEMP = 1 AND CST.CODFILEMP = RLC.CODFILEMP AND CST.CODMER = RLC.CODMER AND CST.CODCNLDTB = 0 
                               INNER JOIN MRT.T0150881 IND ON IND.CODFILEMPEPD = RLC.CODFILEMP AND IND.CODMER = RLC.CODMER ");

            sql.Append(" AND IND.ANOSMNREF = TO_NUMBER(TO_CHAR(TO_DATE('").Append(dataRef).AppendLine("', 'YYYY-MM-DD'),'IYYYIW')) ");

            sql.AppendLine(" LEFT JOIN MRT.T0106050 SML ON MER.CODMER = SML.CODMER ");
            sql.AppendLine(" LEFT JOIN mrt.T0106033 GRP ON GRP.CODGRPMERSMR = SML.CODGRPMERSMR ");
            sql.Append(" LEFT JOIN MRT.CADITEMCOVBAFRN ITE  ON ITE.CODMER = MER.CODMER AND ITE.CODFILEMP = FIL.CODFILEMP AND CODMCOVBAFRN = ").Append(codCarimbo).AppendLine();
            sql.Append(" WHERE RLC.CODFRN = ").Append(CodFornecedor).AppendLine();

            if (codFiliais != "Todas")
                sql.Append(" AND RLC.CODFILEMP in( ").Append(codFiliais).Append(")").AppendLine();
            else
                sql.AppendLine(" AND CASE WHEN INDECSVLRGACDTBATC = 1 THEN INDFILDTB ELSE 0 END = 0 ");

            if (CodComprador != null)
                sql.Append(" AND RLC.CODCPR = ").Append(CodComprador).AppendLine();

            sql.AppendLine(" ORDER BY CASE WHEN NVL(sml.codgrpmersmr,   0) =  0 THEN ");
            sql.AppendLine("          trim(grp.desgrpmersmr) ");
            sql.AppendLine("          ELSE ");
            sql.AppendLine("          trim(grp.desgrpmersmr) || ' - ' || trim(fil.codfilemp) || trim(fil.desabvfilemp) ");
            sql.AppendLine("          END ASC, ");
            sql.AppendLine("          MER.DESMER ASC ");
            sql.AppendLine("          , FIL.CODFILEMP asc ");

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();


            List<CarimboItem> list = new List<CarimboItem>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    CarimboItem obj = new CarimboItem();

                    //if (!row.IsNull("CODMCOVBAFRN"))
                    //    obj.CodCarimbo = int.Parse((row["CODMCOVBAFRN"]).ToString());
                    //if (!row.IsNull("VLRPRVMCOVBAFRN"))
                    //    obj.VlrPrevistoCarimbo = Decimal.Parse((row["VLRPRVMCOVBAFRN"]).ToString());
                    //if (!row.IsNull("VLRRLZMCOVBAFRN"))
                    //    obj.VlrRealizadoCarimbo = Decimal.Parse((row["VLRRLZMCOVBAFRN"]).ToString());
                    //if (!row.IsNull("VLRCNCMCOVBAFRN"))
                    //    obj.VlrCanceladoCarimbo = Decimal.Parse((row["VLRCNCMCOVBAFRN"]).ToString());
                    //if (!row.IsNull("VLRPIS"))
                    //    obj.VlrImpostos = Decimal.Parse((row["VLRPIS"]).ToString());
                    //if (!row.IsNull("TIPDSNDSCBNF"))
                    //    obj.CodDestino = int.Parse((row["TIPDSNDSCBNF"]).ToString());
                    //if (!row.IsNull("DESDSNDSCBNF"))
                    //    obj.NomDestino = (row["DESDSNDSCBNF"]).ToString().TrimStart().TrimEnd();


                    if (!row.IsNull("CODFILEMP"))
                        obj.CodFilialEmpresa = int.Parse((row["CODFILEMP"]).ToString());
                    if (!row.IsNull("DESABVFILEMP"))
                        obj.NomFilialEmpresa = (row["DESABVFILEMP"]).ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("CODMER"))
                        obj.CodMercadoria = int.Parse((row["CODMER"]).ToString());
                    if (!row.IsNull("DESMER"))
                        obj.NomMercadoria = (row["DESMER"]).ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("DESCLSMER"))
                        obj.DesClasseMercadoria = (row["DESCLSMER"]).ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("CODGRPMERSMR"))
                        obj.CodGrupoSimilar = int.Parse((row["CODGRPMERSMR"]).ToString());
                    if (!row.IsNull("VLRDIRCSTMEDEFT"))
                        obj.VlrDiarioCustoMedioEfetivo = decimal.Parse((row["VLRDIRCSTMEDEFT"]).ToString());
                    if (!row.IsNull("QDEETQMER"))
                        obj.QtdEstoqueMercadoria = int.Parse((row["QDEETQMER"]).ToString());
                    if (!row.IsNull("VLRETQMER"))
                        obj.VlrEstoqueMercadoria = decimal.Parse((row["VLRETQMER"]).ToString());
                    if (!row.IsNull("QDESLDPEDMER"))
                        obj.QtdSaldoPeriodoMercadoria = decimal.Parse((row["QDESLDPEDMER"]).ToString());
                    if (!row.IsNull("VLRSLDPEDMER"))
                        obj.VlrSaldoPeriodoMercadoria = decimal.Parse((row["VLRSLDPEDMER"]).ToString());
                    if (!row.IsNull("MEDIA"))
                        obj.VlrMedia = decimal.Parse((row["MEDIA"]).ToString());
                    if (!row.IsNull("MB_VND"))
                        obj.VlrMbVnd = decimal.Parse((row["MB_VND"]).ToString());
                    if (!row.IsNull("MC_VND"))
                        obj.VlrMcVnd = decimal.Parse((row["MC_VND"]).ToString());
                    if (!row.IsNull("VLRRCTLIQVND"))
                        obj.VlrReceitaLiquidaVenda = decimal.Parse((row["VLRRCTLIQVND"]).ToString());
                    if (!row.IsNull("VLRMEDVBAMRGMER"))
                        obj.VlrMedioVerbaParaMargemMercadoria = decimal.Parse((row["VLRMEDVBAMRGMER"]).ToString());
                    if (!row.IsNull("VLRMEDVBAPCOMER"))
                        obj.VlrMedioVerbaParaPrecoMercadoria = decimal.Parse((row["VLRMEDVBAPCOMER"]).ToString());
                    if (!row.IsNull("DESGRPMERSMRAGP"))
                        obj.DesGrupoMercadoriaSimilarAgrupado = (row["DESGRPMERSMRAGP"]).ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("DESGRPMERSMR"))
                        obj.DesGrupoMercadoriaSimilar = (row["DESGRPMERSMR"]).ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("FTRCNVPCO"))
                        obj.VlrFatorConversaoPrecoValorPresente = decimal.Parse((row["FTRCNVPCO"]).ToString());
                    if (!row.IsNull("PERFUNVND_TOTAL"))
                        obj.VlrPercentualFundingVendaTotal = decimal.Parse((row["PERFUNVND_TOTAL"]).ToString());
                    if (!row.IsNull("PERFUNVND_PRECO"))
                        obj.VlrPercentualFundingVendaPreco = decimal.Parse((row["PERFUNVND_PRECO"]).ToString());
                    if (!row.IsNull("VLRTOTFNDMERVND"))
                        obj.VlrTotalFundingMercadoriaVendida = decimal.Parse((row["VLRTOTFNDMERVND"]).ToString());
                    if (!row.IsNull("VLRTOTFNDMRGVND"))
                        obj.VlrTotalFundingMargemVendida = decimal.Parse((row["VLRTOTFNDMRGVND"]).ToString());

                    if (!row.IsNull("TIPDSNDSCBNF"))
                        obj.CodDestinoObjetivo = int.Parse((row["TIPDSNDSCBNF"]).ToString());
                    if (!row.IsNull("VLRPRVMCOVBAFRN"))
                        obj.VlrPrevistoCarimbo = decimal.Parse((row["VLRPRVMCOVBAFRN"]).ToString());
                    if (!row.IsNull("VLRRLZMCOVBAFRN"))
                        obj.VlrRealizadoCarimbo = decimal.Parse((row["VLRRLZMCOVBAFRN"]).ToString());
                    if (!row.IsNull("VLRCNCMCOVBAFRN"))
                        obj.VlrCanceladoCarimbo = decimal.Parse((row["VLRCNCMCOVBAFRN"]).ToString());

                    list.Add(obj);
                }
            }
            return list;
        }

        public static List<CarimboItem> ListPorCarimbo(int codigo)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(@"SELECT ITE.CODMCOVBAFRN
                                  , ITE.CODFILEMP
                                  , FIL.DESABVFILEMP
                                  , ITE.CODMER
                                  , MER.DESMER
                                  , ITE.VLRPRVMCOVBAFRN
                                  , ITE.VLRRLZMCOVBAFRN
                                  , ITE.VLRCNCMCOVBAFRN
                                  , ITE.VLRPIS
                                  , ITE.TIPDSNDSCBNF
                                  , DEST.DESDSNDSCBNF 
                                  , DEST.TIPVBAFRN 
                              FROM MRT.CADITEMCOVBAFRN ITE
                             INNER JOIN MRT.T0100086 MER ON ITE.CODMER = MER.CODMER AND MER.CODEMP = 1 
                             INNER JOIN MRT.T0112963 FIL ON ITE.CODFILEMP = FIL.CODFILEMP AND FIL.CODEMP = 1 
                             INNER JOIN MRT.T0109059 DEST ON ITE.TIPDSNDSCBNF = DEST.TIPDSNDSCBNF
                             WHERE ITE.CODMCOVBAFRN = ").Append(codigo).AppendLine();


            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();

            List<CarimboItem> list = new List<CarimboItem>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    CarimboItem obj = new CarimboItem();
                    if (!row.IsNull("CODMCOVBAFRN"))
                        obj.CodCarimbo = int.Parse((row["CODMCOVBAFRN"]).ToString());
                    if (!row.IsNull("CODFILEMP"))
                        obj.CodFilialEmpresa = int.Parse((row["CODFILEMP"]).ToString());
                    if (!row.IsNull("CODMER"))
                        obj.CodMercadoria = int.Parse((row["CODMER"]).ToString());
                    if (!row.IsNull("VLRPRVMCOVBAFRN"))
                        obj.VlrPrevistoCarimbo = Decimal.Parse((row["VLRPRVMCOVBAFRN"]).ToString());
                    if (!row.IsNull("VLRRLZMCOVBAFRN"))
                        obj.VlrRealizadoCarimbo = Decimal.Parse((row["VLRRLZMCOVBAFRN"]).ToString());
                    if (!row.IsNull("VLRCNCMCOVBAFRN"))
                        obj.VlrCanceladoCarimbo = Decimal.Parse((row["VLRCNCMCOVBAFRN"]).ToString());
                    if (!row.IsNull("VLRPIS"))
                        obj.VlrImpostos = Decimal.Parse((row["VLRPIS"]).ToString());
                    if (!row.IsNull("TIPDSNDSCBNF"))
                        obj.CodDestinoObjetivo = int.Parse((row["TIPDSNDSCBNF"]).ToString());

                    if (!row.IsNull("DESABVFILEMP"))
                        obj.NomFilialEmpresa = (row["DESABVFILEMP"]).ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("DESMER"))
                        obj.NomMercadoria = (row["DESMER"]).ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("DESDSNDSCBNF"))
                        obj.NomDestinoObjetivo = (row["DESDSNDSCBNF"]).ToString().TrimStart().TrimEnd();
                    //if (!row.IsNull("TIPVBAFRN"))
                    //    obj.CodObjetivo = int.Parse((row["TIPVBAFRN"]).ToString());


                    list.Add(obj);
                }
            }
            return list;
        }

        public static CarimboItem Insert(CarimboItem obj)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"INSERT INTO MRT.CADITEMCOVBAFRN
                                  ( CODMCOVBAFRN
                                  , CODFILEMP
                                  , CODMER
                                  , VLRPRVMCOVBAFRN
                                  , VLRRLZMCOVBAFRN
                                  , VLRCNCMCOVBAFRN
                                  , VLRPIS
                                  , TIPDSNDSCBNF)
                            VALUES( ");
            sql.Append(" ").Append(obj.CodCarimbo).AppendLine();
            sql.Append(", ").Append(obj.CodFilialEmpresa).AppendLine();
            sql.Append(", ").Append(obj.CodMercadoria).AppendLine();
            sql.Append(", ").AppendLine(obj.VlrPrevistoCarimbo.ToString().Replace(",", "."));
            sql.Append(", ").AppendLine(obj.VlrRealizadoCarimbo.ToString().Replace(",", "."));
            sql.Append(", ").AppendLine(obj.VlrCanceladoCarimbo.ToString().Replace(",", "."));
            sql.Append(", ").AppendLine(obj.VlrImpostos.ToString().Replace(",", "."));
            sql.Append(", ").Append(obj.CodDestinoObjetivo).AppendLine();
            sql.AppendLine(")");

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();
            var ret = cmd.ExecuteScalar();
            if (ret != null)
                throw new Exception(ret.ToString());

            return obj;
        }

        public static void Update(int CodCarimbo, int codMercadoria, int codFilial, CarimboItem obj)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"UPDATE MRT.CADITEMCOVBAFRN");
            sql.Append(" SET VLRPRVMCOVBAFRN = ").AppendLine(obj.VlrPrevistoCarimbo.ToString().Replace(",", "."));
            //sql.Append(" , VLRRLZMCOVBAFRN = ").AppendLine(obj.VlrRealizadoCarimbo.ToString().Replace(",", "."));
            //sql.Append(" , VLRCNCMCOVBAFRN = ").AppendLine(obj.VlrCanceladoCarimbo.ToString().Replace(",", "."));
            sql.Append(" , VLRPIS = ").AppendLine(obj.VlrImpostos.ToString().Replace(",", "."));
            sql.Append(" WHERE CODMCOVBAFRN = ").Append(CodCarimbo).AppendLine();
            sql.Append(" AND CODFILEMP = ").Append(codFilial).AppendLine();
            sql.Append(" AND CODMER = ").Append(codMercadoria).AppendLine();

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();
            var ret = cmd.ExecuteScalar();
            if (ret != null)
                throw new Exception(ret.ToString());
        }

        public static void Delete(int CodCarimbo, int codMercadoria, int codFilial)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"DELETE FROM  MRT.CADITEMCOVBAFRN");
            sql.Append(" WHERE CODMCOVBAFRN = ").Append(CodCarimbo).AppendLine();
            sql.Append(" AND CODFILEMP = ").Append(codFilial).AppendLine();
            sql.Append(" AND CODMER = ").Append(codMercadoria).AppendLine();

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();
            var ret = cmd.ExecuteScalar();
            if (ret != null)
                throw new Exception(ret.ToString());
        }
    }
}