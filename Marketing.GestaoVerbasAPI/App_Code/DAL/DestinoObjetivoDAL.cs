using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.DAL
{
    public class DestinoObjetivoDAL
    {
        public static List<DestinoObjetivo> ListObjetivoPorDestino(int codDestino)
        {
            Command cmd = new Command();

            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT DISTINCT OBJDES.TIPVBAFRN -- COD DESTINO
                                  , OBJ.TIPOBJDSNVBA -- COD OBJETIVO
                                  , OBJ.DESOBJDSNVBA -- NOM OBJETIVO
                                  , OBJDES.TIPDSNDSCBNF    -- COD OBJETIVO/DESTINO
                                  , OBJDES.DESDSNDSCBNF -- NOM OBJETIVO/DESTINO
                             FROM MRT.CADOBJDSNVBA  OBJ
                             INNER JOIN MRT.T0109059 OBJDES ON OBJDES.TIPOBJDSNVBA = OBJ.TIPOBJDSNVBA
                            WHERE OBJDES.TIPVBAFRN = ").Append(codDestino);

            cmd.CommandText = sql.ToString();
            DataTable dt = cmd.GetData();

            List<DestinoObjetivo> list = new List<DestinoObjetivo>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DestinoObjetivo obj = new DestinoObjetivo();
                    if (!row.IsNull("TIPVBAFRN"))
                        obj.CodDestino = int.Parse((row["TIPVBAFRN"]).ToString());
                    if (!row.IsNull("TIPOBJDSNVBA"))
                        obj.CodObjetivo = int.Parse((row["TIPOBJDSNVBA"]).ToString());
                    if (!row.IsNull("DESOBJDSNVBA"))
                        obj.NomObjetivo= row["DESOBJDSNVBA"].ToString().TrimStart().TrimEnd();


                    if (!row.IsNull("TIPDSNDSCBNF"))
                        obj.CodDestinoObjetivo = int.Parse((row["TIPDSNDSCBNF"]).ToString());

                    if (!row.IsNull("DESDSNDSCBNF"))
                        obj.NomDestinoObjetivo = row["DESDSNDSCBNF"].ToString().TrimStart().TrimEnd();

                    list.Add(obj);
                }
            }
            return list;
        }

        public static List<DestinoObjetivo> ListObjetivos()
        {
            Command cmd = new Command();

            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT       TIPOBJDSNVBA,
                        DESOBJDSNVBA,
                       DATDSTTIPOBJDSNVBA 
                FROM    MRT.CADOBJDSNVBA 
                 WHERE DATDSTTIPOBJDSNVBA is null ");

            cmd.CommandText = sql.ToString();
            DataTable dt = cmd.GetData();

            List<DestinoObjetivo> list = new List<DestinoObjetivo>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DestinoObjetivo obj = new DestinoObjetivo();
                    
                        obj.CodObjetivo = int.Parse((row["TIPOBJDSNVBA"]).ToString());
                    if (!row.IsNull("DESOBJDSNVBA"))
                        obj.NomObjetivo = row["DESOBJDSNVBA"].ToString().TrimStart().TrimEnd();

                    list.Add(obj);
                }
            }
            return list;
        }
    }
}