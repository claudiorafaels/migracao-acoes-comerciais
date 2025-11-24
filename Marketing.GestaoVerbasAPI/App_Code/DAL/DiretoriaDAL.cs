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
    public class DiretoriaDAL
    {
        public static List<Diretoria> List(Diretoria filtro)
        {
            Command cmd = new Command();

            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT DIR.CODDRTCMP
                                  , DIR.DESDRTCMP
                               FROM MRT.T0123183 DIR 
                              WHERE 1 = 1");

            if (filtro.CodDiretoria != null)
                sql.Append(" AND DIR.CODDRTCMP = ").AppendLine(filtro.CodDiretoria.ToString());
            if (filtro.NomDiretoria != null)
                sql.Append(" AND DIR.CODDRTCMP LIKE UPPER('%").Append(filtro.NomDiretoria).AppendLine("%')");


            cmd.CommandText = sql.ToString();
            DataTable dt = cmd.GetData();


            List<Diretoria> list = new List<Diretoria>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Diretoria obj = new Diretoria();
                    if (!row.IsNull("CODDRTCMP"))
                        obj.CodDiretoria= int.Parse((row["CODDRTCMP"]).ToString());
                    if (!row.IsNull("DESDRTCMP"))
                        obj.NomDiretoria = row["DESDRTCMP"].ToString().TrimStart().TrimEnd();

                    list.Add(obj);
                }
            }

            return list;
        }

    }
}