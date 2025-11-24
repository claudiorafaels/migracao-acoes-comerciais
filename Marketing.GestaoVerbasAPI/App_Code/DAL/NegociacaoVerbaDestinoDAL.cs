using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.DAL
{
    public class NegociacaoVerbaDestinoDAL
    {

        public static List<NegociacaoVerbaDestino> ListPorNegociacao(int CodNegociacaoVerba)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT DEST.CODNGC
                              , DEST.TIPDSNDSCBNF
                              , TPDEST.DESDSNDSCBNF
                              , DEST.VLRVBAFRN
                              , DEST.DESOBSSLC
                              , TPDEST.TIPVBAFRN
                              , TPDEST.TIPOBJDSNVBA
                              , OBJ.DESOBJDSNVBA
                              , CAR.CODMCOVBAFRN
                              , DEST.CODPMS
                         FROM MRT.RLCNGCVBAFRNDSN DEST
                           INNER JOIN MRT.T0109059 TPDEST ON TPDEST.TIPDSNDSCBNF  = DEST.TIPDSNDSCBNF
                           INNER JOIN MRT.CADOBJDSNVBA  OBJ ON TPDEST.TIPOBJDSNVBA = OBJ.TIPOBJDSNVBA
                            LEFT JOIN MRT.CADMCOVBAFRN CAR ON CAR.CODNGC = DEST.CODNGC AND DEST.TIPDSNDSCBNF = CAR.TIPDSNDSCBNF
                          WHERE DEST.CODNGC = ").AppendLine(CodNegociacaoVerba.ToString().Replace(",", "."));

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();

            List<NegociacaoVerbaDestino> list = new List<NegociacaoVerbaDestino>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    NegociacaoVerbaDestino obj = new NegociacaoVerbaDestino();
                    if (!row.IsNull("CODNGC"))
                        obj.CodNegociacaoVerba = int.Parse((row["CODNGC"]).ToString());
                    if (!row.IsNull("TIPDSNDSCBNF"))
                        obj.CodDestinoObjetivo = int.Parse((row["TIPDSNDSCBNF"]).ToString());
                    if (!row.IsNull("DESDSNDSCBNF"))
                        obj.NomDestinoObjetivo = row["DESDSNDSCBNF"].ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("VLRVBAFRN"))
                        obj.VlrVerba = decimal.Parse((row["VLRVBAFRN"]).ToString());
                    if (!row.IsNull("DESOBSSLC"))
                        obj.DesObservacao = row["DESOBSSLC"].ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("TIPVBAFRN"))
                        obj.CodDestino = int.Parse((row["TIPVBAFRN"]).ToString());
                    if (!row.IsNull("TIPOBJDSNVBA"))
                        obj.CodObjetivo = int.Parse((row["TIPOBJDSNVBA"]).ToString());
                    if (!row.IsNull("DESOBJDSNVBA"))
                        obj.NomObjetivo = row["DESOBJDSNVBA"].ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("CODMCOVBAFRN"))
                        obj.CodCarimbo = int.Parse((row["CODMCOVBAFRN"]).ToString());
                    if (!row.IsNull("CODPMS"))
                        obj.CodPromessa = int.Parse((row["CODPMS"]).ToString());

                    list.Add(obj);
                }
            }
            return list;
        }

        public static NegociacaoVerbaDestino Select(int CodNegociacaoVerba, int CodDestinoObjetivo)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT DEST.CODNGC
                              , DEST.TIPDSNDSCBNF
                              , TPDEST.DESDSNDSCBNF
                              , DEST.VLRVBAFRN
                              , DEST.DESOBSSLC
                              , TPDEST.TIPVBAFRN
                              , TPDEST.TIPOBJDSNVBA
                              , OBJ.DESOBJDSNVBA
                              , CAR.CODMCOVBAFRN
                              , DEST.CODPMS
                         FROM MRT.RLCNGCVBAFRNDSN DEST
                           INNER JOIN MRT.T0109059 TPDEST ON TPDEST.TIPDSNDSCBNF  = DEST.TIPDSNDSCBNF
                           INNER JOIN MRT.CADOBJDSNVBA  OBJ ON TPDEST.TIPOBJDSNVBA = OBJ.TIPOBJDSNVBA
                            LEFT JOIN MRT.CADMCOVBAFRN CAR ON CAR.CODNGC = DEST.CODNGC AND DEST.TIPDSNDSCBNF = CAR.TIPDSNDSCBNF
                          WHERE DEST.CODNGC = ").Append(CodNegociacaoVerba).AppendLine();
            sql.Append("    AND DEST.TIPDSNDSCBNF = ").Append(CodDestinoObjetivo).AppendLine();

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();

            NegociacaoVerbaDestino obj = new NegociacaoVerbaDestino();
            if (dt != null && dt.Rows.Count == 1)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (!row.IsNull("CODNGC"))
                        obj.CodNegociacaoVerba = int.Parse((row["CODNGC"]).ToString());
                    if (!row.IsNull("TIPDSNDSCBNF"))
                        obj.CodDestinoObjetivo = int.Parse((row["TIPDSNDSCBNF"]).ToString());
                    if (!row.IsNull("DESDSNDSCBNF"))
                        obj.NomDestinoObjetivo = row["DESDSNDSCBNF"].ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("VLRVBAFRN"))
                        obj.VlrVerba = decimal.Parse((row["VLRVBAFRN"]).ToString());
                    if (!row.IsNull("DESOBSSLC"))
                        obj.DesObservacao = row["DESOBSSLC"].ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("TIPVBAFRN"))
                        obj.CodDestino = int.Parse((row["TIPVBAFRN"]).ToString());
                    if (!row.IsNull("TIPOBJDSNVBA"))
                        obj.CodObjetivo = int.Parse((row["TIPOBJDSNVBA"]).ToString());
                    if (!row.IsNull("DESOBJDSNVBA"))
                        obj.NomObjetivo = row["DESOBJDSNVBA"].ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("CODMCOVBAFRN"))
                        obj.CodCarimbo = int.Parse((row["CODMCOVBAFRN"]).ToString());
                    if (!row.IsNull("CODPMS"))
                        obj.CodPromessa = int.Parse((row["CODPMS"]).ToString());
                }
            }
            return obj;
        }

        public static void Insert(NegociacaoVerbaDestino obj)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(@"INSERT INTO MRT.RLCNGCVBAFRNDSN
                                     ( CODNGC
                                     , TIPDSNDSCBNF
                                     , VLRVBAFRN
                                     , DESOBSSLC
                                     , CODPMS)");

            sql.Append("VALUES( ").AppendLine(obj.CodNegociacaoVerba.ToString());
            sql.Append(", ").AppendLine(obj.CodDestinoObjetivo.ToString());
            sql.Append(", ").AppendLine(obj.VlrVerba.ToString().Replace(",", "."));
            sql.Append(", '").Append(obj.DesObservacao.ToString().TrimStart().TrimEnd()).AppendLine("'");
            if (obj.CodPromessa == null)
                sql.Append(", NULL").AppendLine();
            else
                sql.Append(", ").Append(obj.CodPromessa).AppendLine();
            sql.AppendLine(")");

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            var ret = cmd.ExecuteScalar();
            if (ret != null)
                throw new Exception(ret.ToString());
        }

        public static void Update(int CodNegociacaoVerba, int CodObjetivoDestino, NegociacaoVerbaDestino obj)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(@"UPDATE MRT.RLCNGCVBAFRNDSN");
            sql.Append(@" SET VLRVBAFRN = ").AppendLine(obj.VlrVerba.ToString().Replace(",", "."));
            sql.Append(@" , DESOBSSLC = '").Append(obj.DesObservacao.ToString().TrimStart().TrimEnd()).AppendLine("'");
            if (obj.CodPromessa == null)
                sql.Append(@" , CODPMS = NULL").AppendLine();
            else
                sql.Append(@" , CODPMS = ").Append(obj.CodPromessa).AppendLine();
            sql.Append(@" WHERE CODNGC = ").AppendLine(CodNegociacaoVerba.ToString());
            sql.Append(@" AND TIPDSNDSCBNF = ").AppendLine(CodObjetivoDestino.ToString());

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            var ret = cmd.ExecuteScalar();
            if (ret != null)
                throw new Exception(ret.ToString());

        }

        public static void Delete(int CodNegociacaoVerba, int CodObjetivoDestino)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(@"DELETE MRT.RLCNGCVBAFRNDSN");
            sql.Append(@" WHERE CODNGC = ").AppendLine(CodNegociacaoVerba.ToString());
            sql.Append(@" AND TIPDSNDSCBNF = ").AppendLine(CodObjetivoDestino.ToString());

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            var ret = cmd.ExecuteScalar();
            if (ret != null)
                throw new Exception(ret.ToString());
        }


    }
}