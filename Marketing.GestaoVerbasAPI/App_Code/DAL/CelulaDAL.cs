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
    public class CelulaDAL
    {
        public static List<Celula> ListLookup()
        {
            Command cmd = new Command();

            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT * FROM MRT.T0118570 ");

            cmd.CommandText = sql.ToString();
            DataTable dt = cmd.GetData();


            List<Celula> list = new List<Celula>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Celula obj = new Celula();
                    if (!row.IsNull("CODDIVCMP"))
                        obj.CodCelula = int.Parse((row["CODDIVCMP"]).ToString());
                    if (!row.IsNull("DESDIVCMP"))
                        obj.NomCelula = row["DESDIVCMP"].ToString().TrimStart().TrimEnd();

                    list.Add(obj);
                }
            }

            return list;
        }
    }
}