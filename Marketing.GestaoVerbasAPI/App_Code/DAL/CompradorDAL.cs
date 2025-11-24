using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using Marketing.GestaoVerbasAPI.Models;
using Marketing.GestaoVerbasAPI.App_Code.Connection;
using System.Text;
namespace Marketing.GestaoVerbasAPI.App_Code.DAL
{
    public class CompradorDAL
    {
        public static List<Comprador> List(Comprador filtro)
        {
            Command cmd = new Command();

            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT DISTINCT COM.CODCPR
                                  , COM.NOMCPR
                                  , COMFNC.CODFNC
                               FROM MRT.T0113625 COM
                               LEFT JOIN MRT.T0153541 COMFIL ON COMFIL.CODCPR = COM.CODCPR
                               LEFT JOIN MRT.T0100981 COMFNC ON COMFNC.CODCPR = COM.CODCPR
                              WHERE 1 = 1");

            if (filtro.CodComprador != null)
                sql.Append(" AND COM.CODCPR = ").AppendLine(filtro.CodComprador.ToString());
            if (filtro.NomComprador != null)
                sql.Append(" AND COM.NOMCPR LIKE UPPER('%").Append(filtro.NomComprador).AppendLine("%')");
            if (filtro.CodFuncionario != null)
                sql.Append(" AND COM.CODFNC = ").AppendLine(filtro.CodFuncionario.ToString());
            if (filtro.CodFilialEmpresa != null)
                sql.Append(" AND COMFIL.CODFILEMP = ").AppendLine(filtro.CodFilialEmpresa.ToString());

            cmd.CommandText = sql.ToString();
            DataTable dt = cmd.GetData();


            List<Comprador> list = new List<Comprador>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Comprador obj = new Comprador();
                    if (!row.IsNull("CODCPR"))
                        obj.CodComprador = int.Parse((row["CODCPR"]).ToString());
                    if (!row.IsNull("NOMCPR"))
                        obj.NomComprador = row["NOMCPR"].ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("CODFNC"))
                        obj.CodFuncionario = int.Parse((row["CODFNC"]).ToString());

                    list.Add(obj);
                }
            }

            return list;
        }
    }
}