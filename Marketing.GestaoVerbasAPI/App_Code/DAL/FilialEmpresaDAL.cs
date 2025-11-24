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
    public class FilialEmpresaDAL
    {
        public static ListResult<FilialEmpresa> List(int pagina, int tamanho, string coluna, string sentido, FilialEmpresa filtro)
        {
            Command cmd = new Command();

            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"select CODFILEMP
                                  , DESABVFILEMP
                                  , CODEMP
                             from MRT.T0112963
                            where 1=1");

            if (filtro.CodFilialEmpresa != null)
                sql.Append(" AND CODFILEMP = ").AppendLine(filtro.CodFilialEmpresa.ToString());
            if (filtro.NomFilialEmpresa != null)
                sql.Append(" AND DESABVFILEMP LIKE UPPER('%").Append(filtro.NomFilialEmpresa).AppendLine("%')");
            if (filtro.CodEmpresa != null)
                sql.Append(" AND CODEMP = ").AppendLine(filtro.CodEmpresa.ToString());

            cmd.CommandText = sql.ToString();
            DataTable dt = cmd.GetData();


            List<FilialEmpresa> list = new List<FilialEmpresa>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    FilialEmpresa obj = new FilialEmpresa();
                    if (!row.IsNull("CODFILEMP"))
                        obj.CodFilialEmpresa = int.Parse((row["CODFILEMP"]).ToString());
                    if (!row.IsNull("DESABVFILEMP"))
                        obj.NomFilialEmpresa = row["DESABVFILEMP"].ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("CODEMP"))
                        obj.CodEmpresa = int.Parse((row["CODEMP"]).ToString());

                    list.Add(obj);
                }
            }

            return ListResultadoManager.PaginarLista(list, pagina, tamanho, coluna, sentido);
        }


        public static List<FilialEmpresa> ListLookup()
        {
            Command cmd = new Command();

            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT CODFILEMP
                                  , DESABVFILEMP
                                  , CODEMP
                             FROM MRT.T0112963
                             WHERE CODCIDPCOACOCMC > 0
                             ORDER BY CODFILEMP");

            cmd.CommandText = sql.ToString();
            DataTable dt = cmd.GetData();


            List<FilialEmpresa> list = new List<FilialEmpresa>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    FilialEmpresa obj = new FilialEmpresa();
                    if (!row.IsNull("CODFILEMP"))
                        obj.CodFilialEmpresa = int.Parse((row["CODFILEMP"]).ToString());
                    if (!row.IsNull("DESABVFILEMP"))
                        obj.NomFilialEmpresa = row["DESABVFILEMP"].ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("CODEMP"))
                        obj.CodEmpresa = int.Parse((row["CODEMP"]).ToString());

                    list.Add(obj);
                }
            }

            return list;
        }
    }
} 