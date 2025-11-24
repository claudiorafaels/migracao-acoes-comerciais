using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.DAL
{
    public class CarimboDAL
    {
        public static Carimbo Select(int codigo)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"SELECT CAR.CODMCOVBAFRN
                              , CAR.NUMPEDCMP
                              , CAR.DATGRCMCOVBAFRN
                              , CAR.CODFNCMCOVBAFRN
                              , FNC.NOMFNC AS NOMFNCMCOVBAFRN
                              , CAR.CODFRN
                              , FRN.NOMFRN
                              , CAR.CODPMS
                              , CAR.DATNGCPMS
                              , CAR.INDSTAMCOVBAFRN
                              , CAR.DESOBSMCOVBAFRN
                              , CAR.TIPOBJMCOVBAFRN
                              , CAR.VLRUTZACOCMC
                              , CAR.CODNGC
                              , CAR.TIPDSNDSCBNF
                              , NEGVITN.VLRVBAFRN
                           FROM MRT.CADMCOVBAFRN CAR
                          INNER JOIN MRT.T0100361 FNC ON FNC.CODFNC = CAR.CODFNCMCOVBAFRN
                          INNER JOIN MRT.T0100426 FRN ON FRN.CODFRN = CAR.CODFRN 
                           LEFT JOIN MRT.RLCNGCVBAFRNDSN  NEGVITN ON NEGVITN.CODNGC = CAR.CODNGC AND  NEGVITN.TIPDSNDSCBNF  = CAR.TIPDSNDSCBNF 
                          WHERE CAR.CODMCOVBAFRN = ").Append(codigo);

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();

            Carimbo obj = null;

            if (dt != null && dt.Rows.Count == 1)
            {
                obj = new Carimbo();
                DataRow row = dt.Rows[0];
                if (!row.IsNull("CODMCOVBAFRN"))
                    obj.CodCarimbo = int.Parse((row["CODMCOVBAFRN"]).ToString());
                if (!row.IsNull("NUMPEDCMP"))
                    obj.NumPedidoCompra = int.Parse((row["NUMPEDCMP"]).ToString());
                if (!row.IsNull("DATGRCMCOVBAFRN"))
                    obj.DtCadastroCarimbo = DateTime.Parse((row["DATGRCMCOVBAFRN"]).ToString());
                if (!row.IsNull("CODFNCMCOVBAFRN"))
                    obj.CodFuncionario = int.Parse((row["CODFNCMCOVBAFRN"]).ToString());
                if (!row.IsNull("NOMFNCMCOVBAFRN"))
                    obj.NomFuncionario = row["NOMFNCMCOVBAFRN"].ToString().TrimStart().TrimEnd();
                if (!row.IsNull("CODFRN"))
                    obj.CodFornecedor = int.Parse((row["CODFRN"]).ToString());
                if (!row.IsNull("NOMFRN"))
                    obj.NomFornecedor = row["NOMFRN"].ToString().TrimStart().TrimEnd();
                if (!row.IsNull("CODPMS"))
                    obj.CodPromessa = int.Parse((row["CODPMS"]).ToString());
                if (!row.IsNull("DATNGCPMS"))
                    obj.DtNegociacaoPromessa = DateTime.Parse((row["DATNGCPMS"]).ToString());
                if (!row.IsNull("INDSTAMCOVBAFRN"))
                    obj.CodStatusCarimbo = int.Parse((row["INDSTAMCOVBAFRN"]).ToString());
                if (!row.IsNull("DESOBSMCOVBAFRN"))
                    obj.DesObservacao = row["DESOBSMCOVBAFRN"].ToString().TrimStart().TrimEnd();
                if (!row.IsNull("TIPOBJMCOVBAFRN"))
                    obj.TIPOBJMCOVBAFRN = int.Parse((row["TIPOBJMCOVBAFRN"]).ToString());
                if (!row.IsNull("VLRUTZACOCMC"))
                    obj.VlrUtilizadoAcaoComercial = decimal.Parse((row["VLRUTZACOCMC"]).ToString());
                if (!row.IsNull("CODNGC"))
                    obj.CodNegociacaoVerba = int.Parse((row["CODNGC"]).ToString());
                if (!row.IsNull("TIPDSNDSCBNF"))
                    obj.CodDestinoObjetivo = int.Parse((row["TIPDSNDSCBNF"]).ToString());
                if (!row.IsNull("VLRVBAFRN"))
                    obj.VlrVerba = decimal.Parse((row["VLRVBAFRN"]).ToString());
            }
            return obj;
        }

        public static Carimbo SelectPorNegociacao(int codigoNegociacaoVerba, int codDestinoObjetivo)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"SELECT CAR.CODMCOVBAFRN
                              , CAR.NUMPEDCMP
                              , CAR.DATGRCMCOVBAFRN
                              , CAR.CODFNCMCOVBAFRN
                              , FNC.NOMFNC AS NOMFNCMCOVBAFRN
                              , CAR.CODFRN
                              , FRN.NOMFRN
                              , CAR.CODPMS
                              , CAR.DATNGCPMS
                              , CAR.INDSTAMCOVBAFRN
                              , CAR.DESOBSMCOVBAFRN
                              , CAR.TIPOBJMCOVBAFRN
                              , DESOBJ.DESDSNDSCBNF
                              , CAR.VLRUTZACOCMC
                              , CAR.CODNGC
                              , CAR.TIPDSNDSCBNF
                              , NEGVITN.VLRVBAFRN
                              , NEGVITN.VLRVBAFRN * 0.1 as VLRIMPOSTO
                              , NEGVITN.VLRVBAFRN * 0.9 as VLRCARIMBO
                           FROM MRT.CADMCOVBAFRN CAR
                          INNER JOIN MRT.T0100361 FNC ON FNC.CODFNC = CAR.CODFNCMCOVBAFRN
                          INNER JOIN MRT.T0100426 FRN ON FRN.CODFRN = CAR.CODFRN 
                          INNER JOIN MRT.T0109059 DESOBJ  on CAR.TIPDSNDSCBNF =  DESOBJ.TIPDSNDSCBNF
                           LEFT JOIN MRT.RLCNGCVBAFRNDSN  NEGVITN ON NEGVITN.CODNGC = CAR.CODNGC AND  NEGVITN.TIPDSNDSCBNF  = CAR.TIPDSNDSCBNF 
                          WHERE CAR.CODNGC = ").Append(codigoNegociacaoVerba).AppendLine();
            sql.Append("    AND CAR.TIPDSNDSCBNF = ").Append(codDestinoObjetivo).AppendLine();

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();

            Carimbo obj = null;

            if (dt != null && dt.Rows.Count == 1)
            {
                obj = new Carimbo();
                DataRow row = dt.Rows[0];
                if (!row.IsNull("CODMCOVBAFRN"))
                    obj.CodCarimbo = int.Parse((row["CODMCOVBAFRN"]).ToString());
                if (!row.IsNull("NUMPEDCMP"))
                    obj.NumPedidoCompra = int.Parse((row["NUMPEDCMP"]).ToString());
                if (!row.IsNull("DATGRCMCOVBAFRN"))
                    obj.DtCadastroCarimbo = DateTime.Parse((row["DATGRCMCOVBAFRN"]).ToString());
                if (!row.IsNull("CODFNCMCOVBAFRN"))
                    obj.CodFuncionario = int.Parse((row["CODFNCMCOVBAFRN"]).ToString());
                if (!row.IsNull("NOMFNCMCOVBAFRN"))
                    obj.NomFuncionario = row["NOMFNCMCOVBAFRN"].ToString().TrimStart().TrimEnd();
                if (!row.IsNull("CODFRN"))
                    obj.CodFornecedor = int.Parse((row["CODFRN"]).ToString());
                if (!row.IsNull("NOMFRN"))
                    obj.NomFornecedor = row["NOMFRN"].ToString().TrimStart().TrimEnd();
                if (!row.IsNull("CODPMS"))
                    obj.CodPromessa = int.Parse((row["CODPMS"]).ToString());
                if (!row.IsNull("DATNGCPMS"))
                    obj.DtNegociacaoPromessa = DateTime.Parse((row["DATNGCPMS"]).ToString());
                if (!row.IsNull("INDSTAMCOVBAFRN"))
                    obj.CodStatusCarimbo = int.Parse((row["INDSTAMCOVBAFRN"]).ToString());
                if (!row.IsNull("DESOBSMCOVBAFRN"))
                    obj.DesObservacao = row["DESOBSMCOVBAFRN"].ToString().TrimStart().TrimEnd();
                if (!row.IsNull("TIPOBJMCOVBAFRN"))
                    obj.TIPOBJMCOVBAFRN = int.Parse((row["TIPOBJMCOVBAFRN"]).ToString());         
                if (!row.IsNull("VLRUTZACOCMC"))
                    obj.VlrUtilizadoAcaoComercial = decimal.Parse((row["VLRUTZACOCMC"]).ToString());
                if (!row.IsNull("CODNGC"))
                    obj.CodNegociacaoVerba = int.Parse((row["CODNGC"]).ToString());

                if (!row.IsNull("VLRVBAFRN"))
                    obj.VlrVerba = decimal.Parse((row["VLRVBAFRN"]).ToString());
                if (!row.IsNull("VLRIMPOSTO"))
                    obj.VlrImpostos = decimal.Parse((row["VLRIMPOSTO"]).ToString());
                if (!row.IsNull("VLRCARIMBO"))
                    obj.VlrCarimbo = decimal.Parse((row["VLRCARIMBO"]).ToString());

                if (!row.IsNull("TIPDSNDSCBNF"))
                    obj.CodDestinoObjetivo = int.Parse((row["TIPDSNDSCBNF"]).ToString());
                if (!row.IsNull("DESDSNDSCBNF"))
                    obj.NomDestinoObjetivo = row["DESDSNDSCBNF"].ToString().TrimStart().TrimEnd();

            }
            return obj;
        }

        public static List<Carimbo> ListPorNegociacao(int codigoNegociacaoVerba)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"SELECT CAR.CODMCOVBAFRN
                              , CAR.NUMPEDCMP
                              , CAR.DATGRCMCOVBAFRN
                              , CAR.CODFNCMCOVBAFRN
                              , FNC.NOMFNC AS NOMFNCMCOVBAFRN
                              , CAR.CODFRN
                              , FRN.NOMFRN
                              , CAR.CODPMS
                              , CAR.DATNGCPMS
                              , CAR.INDSTAMCOVBAFRN
                              , CAR.DESOBSMCOVBAFRN
                              , CAR.TIPOBJMCOVBAFRN
                              , DESOBJ.DESDSNDSCBNF
                              , CAR.VLRUTZACOCMC
                              , CAR.CODNGC
                              , CAR.TIPDSNDSCBNF
                              , NEGVITN.VLRVBAFRN
                              , NEGVITN.VLRVBAFRN * 0.1 as VLRIMPOSTO
                              , NEGVITN.VLRVBAFRN * 0.9 as VLRCARIMBO
                           FROM MRT.CADMCOVBAFRN CAR
                          INNER JOIN MRT.T0100361 FNC ON FNC.CODFNC = CAR.CODFNCMCOVBAFRN
                          INNER JOIN MRT.T0100426 FRN ON FRN.CODFRN = CAR.CODFRN 
                          INNER JOIN MRT.T0109059 DESOBJ  on CAR.TIPDSNDSCBNF =  DESOBJ.TIPDSNDSCBNF
                           LEFT JOIN MRT.RLCNGCVBAFRNDSN  NEGVITN ON NEGVITN.CODNGC = CAR.CODNGC AND  NEGVITN.TIPDSNDSCBNF  = CAR.TIPDSNDSCBNF 
                          WHERE CAR.CODNGC = ").Append(codigoNegociacaoVerba).AppendLine();

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();

            List<Carimbo> list = new List<Carimbo>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Carimbo obj = new Carimbo();
                    if (!row.IsNull("CODMCOVBAFRN"))
                        obj.CodCarimbo = int.Parse((row["CODMCOVBAFRN"]).ToString());
                    if (!row.IsNull("NUMPEDCMP"))
                        obj.NumPedidoCompra = int.Parse((row["NUMPEDCMP"]).ToString());
                    if (!row.IsNull("DATGRCMCOVBAFRN"))
                        obj.DtCadastroCarimbo = DateTime.Parse((row["DATGRCMCOVBAFRN"]).ToString());
                    if (!row.IsNull("CODFNCMCOVBAFRN"))
                        obj.CodFuncionario = int.Parse((row["CODFNCMCOVBAFRN"]).ToString());
                    if (!row.IsNull("NOMFNCMCOVBAFRN"))
                        obj.NomFuncionario = row["NOMFNCMCOVBAFRN"].ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("CODFRN"))
                        obj.CodFornecedor = int.Parse((row["CODFRN"]).ToString());
                    if (!row.IsNull("NOMFRN"))
                        obj.NomFornecedor = row["NOMFRN"].ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("CODPMS"))
                        obj.CodPromessa = int.Parse((row["CODPMS"]).ToString());
                    if (!row.IsNull("DATNGCPMS"))
                        obj.DtNegociacaoPromessa = DateTime.Parse((row["DATNGCPMS"]).ToString());
                    if (!row.IsNull("INDSTAMCOVBAFRN"))
                        obj.CodStatusCarimbo = int.Parse((row["INDSTAMCOVBAFRN"]).ToString());
                    if (!row.IsNull("DESOBSMCOVBAFRN"))
                        obj.DesObservacao = row["DESOBSMCOVBAFRN"].ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("TIPOBJMCOVBAFRN"))
                        obj.TIPOBJMCOVBAFRN = int.Parse((row["TIPOBJMCOVBAFRN"]).ToString());                 
                    if (!row.IsNull("VLRUTZACOCMC"))
                        obj.VlrUtilizadoAcaoComercial = decimal.Parse((row["VLRUTZACOCMC"]).ToString());
                    if (!row.IsNull("CODNGC"))
                        obj.CodNegociacaoVerba = int.Parse((row["CODNGC"]).ToString());

                    if (!row.IsNull("VLRVBAFRN"))
                        obj.VlrVerba = decimal.Parse((row["VLRVBAFRN"]).ToString());
                    if (!row.IsNull("VLRIMPOSTO"))
                        obj.VlrImpostos = decimal.Parse((row["VLRIMPOSTO"]).ToString());
                    if (!row.IsNull("VLRCARIMBO"))
                        obj.VlrCarimbo = decimal.Parse((row["VLRCARIMBO"]).ToString());

                    if (!row.IsNull("TIPDSNDSCBNF"))
                        obj.CodDestinoObjetivo = int.Parse((row["TIPDSNDSCBNF"]).ToString());
                    if (!row.IsNull("DESDSNDSCBNF"))
                        obj.NomDestinoObjetivo = row["DESDSNDSCBNF"].ToString().TrimStart().TrimEnd();

                    list.Add(obj);
                }
            }
            return list;
        }

        public static int NextCodCarimbo()
        {
            Command cmd = new Command();
            cmd.CommandText = @"SELECT NVL(MAX(CODMCOVBAFRN) + 1, 1) as NextVal
                                     FROM MRT.CADMCOVBAFRN";


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

        public static Carimbo Insert(Carimbo obj)
        {
            obj.CodCarimbo = NextCodCarimbo();
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"INSERT INTO MRT.CADMCOVBAFRN
                                     ( CODMCOVBAFRN
                                     , NUMPEDCMP
                                     , DATGRCMCOVBAFRN
                                     , CODFNCMCOVBAFRN
                                     , CODFRN
                                     , CODPMS
                                     , DATNGCPMS
                                     , INDSTAMCOVBAFRN
                                     , DESOBSMCOVBAFRN
                                     , TIPOBJMCOVBAFRN
                                     , VLRUTZACOCMC
                                     , CODNGC
                                     , TIPDSNDSCBNF)
                               VALUES(");
            sql.Append(" ").AppendLine(obj.CodCarimbo.ToString());
            sql.Append(", ").AppendLine(obj.NumPedidoCompra.ToString());
            sql.Append(", TO_DATE('").Append(obj.DtCadastroCarimbo.GetValueOrDefault().ToString("yyyy-MM-dd")).AppendLine("', 'yyyy-mm-dd')");
            sql.Append(", ").AppendLine(obj.CodFuncionario.ToString());
            sql.Append(", ").AppendLine(obj.CodFornecedor.ToString());
            sql.Append(", ").AppendLine(obj.CodPromessa.ToString());
            sql.Append(", TO_DATE('").Append(obj.DtNegociacaoPromessa.GetValueOrDefault().ToString("yyyy-MM-dd")).AppendLine("', 'yyyy-mm-dd')");
            sql.Append(", ").AppendLine(obj.CodStatusCarimbo.ToString());
            sql.Append(", '").Append(obj.DesObservacao.ToString().TrimStart().TrimEnd()).AppendLine("'");
            sql.Append(", ").AppendLine(obj.TIPOBJMCOVBAFRN.ToString());
            sql.Append(", ").AppendLine(obj.VlrUtilizadoAcaoComercial.ToString().Replace(",", "."));
            sql.Append(", ").AppendLine(obj.CodNegociacaoVerba.ToString());
            sql.Append(", ").AppendLine(obj.CodDestinoObjetivo.ToString());
            
            sql.AppendLine(")");

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();
            var ret = cmd.ExecuteScalar();
            if (ret != null)
                throw new Exception(ret.ToString());

            return obj;
        }

        public static void Update(int codigo, Carimbo obj)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(@"UPDATE MRT.CADMCOVBAFRN");

            sql.Append("SET NUMPEDCMP = ").Append(obj.NumPedidoCompra).AppendLine();
            //sql.Append(", DATGRCMCOVBAFRN = ").Append("TO_DATE('").Append(obj.DtCadastroCarimbo.GetValueOrDefault().ToString("yyyy-MM-dd HH:mm:ss")).AppendLine("', 'yyyy-mm-dd hh24:mi:ss')");
            //sql.Append(", CODFNCMCOVBAFRN = ").Append(obj.CodFuncionario).AppendLine();
            sql.Append(", CODFRN = ").Append(obj.CodFornecedor).AppendLine();
            sql.Append(", CODPMS = ").Append(obj.CodPromessa).AppendLine();
            sql.Append(", DATNGCPMS = ").Append("TO_DATE('").Append(obj.DtNegociacaoPromessa.GetValueOrDefault().ToString("yyyy-MM-dd")).AppendLine("', 'yyyy-mm-dd')");
            sql.Append(", INDSTAMCOVBAFRN = ").Append(obj.CodStatusCarimbo).AppendLine();
            sql.Append(", DESOBSMCOVBAFRN = '").Append(obj.DesObservacao.ToString().TrimStart().TrimEnd()).AppendLine("'");
            //sql.Append(", TIPOBJMCOVBAFRN = ").Append(obj.TIPOBJMCOVBAFRN).AppendLine();
            //sql.Append(", VLRUTZACOCMC = ").Append(obj.VlrCarimbo.ToString().Replace(",", ".")).AppendLine();
            sql.Append(", CODNGC = ").Append(obj.CodNegociacaoVerba).AppendLine();
            sql.Append(", TIPDSNDSCBNF = ").Append(obj.CodDestinoObjetivo).AppendLine();

            sql.Append("WHERE CODMCOVBAFRN = ").AppendLine(codigo.ToString());

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();


            var ret = cmd.ExecuteScalar();
            if (ret != null)
                throw new Exception(ret.ToString());
        }

        public static void Delete(int CodCarimbo)
        {
            Command cmd = new Command();
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(@"DELETE FROM  MRT.CADITEMCOVBAFRN");
            sql.Append(" WHERE CODMCOVBAFRN = ").Append(CodCarimbo).AppendLine();
            cmd.CommandText = sql.ToString();
            var ret = cmd.ExecuteScalar();

            if (ret != null)
                throw new Exception(ret.ToString());

            sql = new StringBuilder();
            sql.Append("DELETE FROM MRT.CADMCOVBAFRN").AppendLine();
            sql.Append("        WHERE CODMCOVBAFRN = ").AppendLine(CodCarimbo.ToString());

            cmd.CommandText = sql.ToString();

            ret = cmd.ExecuteScalar();

            if (ret != null)
                throw new Exception(ret.ToString());
        }
    }
}