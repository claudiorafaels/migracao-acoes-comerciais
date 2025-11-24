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
    public class MercadoriaDAL
    {
        public static ListResult<Mercadoria> List(int pagina, int tamanho, string coluna, string sentido, Mercadoria filtro)
        {
            Command cmd = new Command();

            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"select CODMER
                                  , DESMER
                                  
                             from MRT.T0100086
                            where 1=1");

            if (filtro.CodMercadoria != null)
                sql.Append(" AND CODMER = ").AppendLine(filtro.CodMercadoria.ToString());
            if (filtro.NomMercadoria != null)
                sql.Append(" AND DESMER LIKE UPPER('%").Append(filtro.NomMercadoria).AppendLine("%')");


            cmd.CommandText = sql.ToString();
            DataTable dt = cmd.GetData();


            List<Mercadoria> list = new List<Mercadoria>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Mercadoria obj = new Mercadoria();
                    if (!row.IsNull("CODMER"))
                        obj.CodMercadoria = int.Parse((row["CODMER"]).ToString());
                    if (!row.IsNull("DESMER"))
                        obj.NomMercadoria = row["DESMER"].ToString().TrimStart().TrimEnd();


                    list.Add(obj);
                }
            }

            return ListResultadoManager.PaginarLista(list, pagina, tamanho, coluna, sentido);
        }


        public static List<Mercadoria> ListLookup()
        {
            Command cmd = new Command();

            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT CODMER
                                  , DESMER
                                  
                             FROM MRT.T0100086
                             
                             ORDER BY CODMER");

            cmd.CommandText = sql.ToString();
            DataTable dt = cmd.GetData();


            List<Mercadoria> list = new List<Mercadoria>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Mercadoria obj = new Mercadoria();
                    if (!row.IsNull("CODMER"))
                        obj.CodMercadoria = int.Parse((row["CODMER"]).ToString());
                    if (!row.IsNull("DESMER"))
                        obj.NomMercadoria = row["DESMER"].ToString().TrimStart().TrimEnd();

                    list.Add(obj);
                }
            }

            return list;
        }
    }
}