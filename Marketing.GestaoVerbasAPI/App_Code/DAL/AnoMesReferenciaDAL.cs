using Marketing.GestaoVerbasAPI.Models.RelatoriosCarimbosContabilizados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.DAL
{
    public class AnoMesReferenciaDAL
    {
        public static List<AnoMesReferencia> ListAnoMesReferencia()
        {
            Command cmd = new Command();

            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"select distinct anomesref from mrt.HSTSLDRCBFRN order by 1 desc");

            cmd.CommandText = sql.ToString();
            DataTable dt = cmd.GetData();

            List<AnoMesReferencia> list = new List<AnoMesReferencia>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    AnoMesReferencia obj = new AnoMesReferencia();
                    if (!row.IsNull("anomesref"))
                        obj.IdtAnoMesReferencia = (row["anomesref"]).ToString();

                    list.Add(obj);
                }
            }
            return list;
        }
    }
}