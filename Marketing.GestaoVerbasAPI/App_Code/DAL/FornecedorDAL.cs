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
    public class FornecedorDAL
    {
        public static ListResult<Fornecedor> List(int pagina, int tamanho, string coluna, string sentido, Fornecedor filtro)
        {
            Command cmd = new Command();

            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"select CODFRN
                                  , NOMFRN
                                  , CODEMP
                             from MRT.T0100426
                            where 1=1");

            if (filtro.CodFornecedor != null)
                sql.Append(" AND CODFRN = ").AppendLine(filtro.CodFornecedor.ToString());
            if (filtro.NomFornecedor != null)
                sql.Append(" AND NOMFRN LIKE UPPER('%").Append(filtro.NomFornecedor).AppendLine("%')");
            if (filtro.CodEmpresa != null)
                sql.Append(" AND CODEMP = ").AppendLine(filtro.CodEmpresa.ToString());

            cmd.CommandText = sql.ToString();
            DataTable dt = cmd.GetData();


            List<Fornecedor> list = new List<Fornecedor>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Fornecedor obj = new Fornecedor();
                    if (!row.IsNull("CODFRN"))
                        obj.CodFornecedor = int.Parse((row["CODFRN"]).ToString());
                    if (!row.IsNull("NOMFRN"))
                        obj.NomFornecedor = row["NOMFRN"].ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("CODEMP"))
                        obj.CodEmpresa = int.Parse((row["CODEMP"]).ToString());

                    list.Add(obj);
                }
            }

            return ListResultadoManager.PaginarLista(list, pagina, tamanho, coluna, sentido);
        }



        public static List<Fornecedor> ListPorCompradorFilial(int pCodFilialEmpresa, int pCodComprador)
        {
            Command cmd = new Command();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT DISTINCT FRN.CODFRN").AppendLine();
            sql.Append("          , FRN.NOMFRN").AppendLine();
            sql.Append("          , FRN.CODEMP").AppendLine();
            sql.Append("       FROM MRT.T0100426 FRN ").AppendLine();
            sql.Append("      INNER JOIN MRT.T0153541 COMFIL ON COMFIL.CODFRN = FRN.CODFRN").AppendLine();
            sql.Append("      WHERE COMFIL.CODFILEMP = ").Append(pCodFilialEmpresa).AppendLine();
            sql.Append("        AND COMFIL.CODCPR = ").Append(pCodComprador).AppendLine();

            cmd.CommandText = sql.ToString();
            DataTable dt = cmd.GetData();


            List<Fornecedor> list = new List<Fornecedor>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Fornecedor obj = new Fornecedor();
                    if (!row.IsNull("CODFRN"))
                        obj.CodFornecedor = int.Parse((row["CODFRN"]).ToString());
                    if (!row.IsNull("NOMFRN"))
                        obj.NomFornecedor = row["NOMFRN"].ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("CODEMP"))
                        obj.CodEmpresa = int.Parse((row["CODEMP"]).ToString());

                    list.Add(obj);
                }
            }

            return list;
        }
    }
}