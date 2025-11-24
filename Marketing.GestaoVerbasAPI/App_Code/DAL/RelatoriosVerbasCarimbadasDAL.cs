using Marketing.GestaoVerbasAPI.App_Code.Connection;
using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.Models.RelatoriosVerbasCarimbadas;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.DAL
{
    public class RelatoriosVerbasCarimbadasDAL
    {

        public static ListResult<VerbasCarimbadasRealizadoSintetico> ListVerbasCarimbadasSintetico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosVerbasCarimbadas filtro)
        {
            StringBuilder sql = new StringBuilder();
            List<VerbasCarimbadasRealizadoSintetico> list = new List<VerbasCarimbadasRealizadoSintetico>();

            sql.AppendLine(" SELECT A.CODFRN AS CODIGO_FORNECEDOR ");
            sql.AppendLine("      , TRIM(C.NOMFRN) AS NOME_FORNECEDOR ");
            sql.AppendLine("      , CASE WHEN A.TIPDSNDSCBNF = 91 THEN 'PRECO' ELSE 'MARGEM' END AS DESTINO ");
            sql.AppendLine("      , A.CODFILEMP AS FILIAL ");
            sql.AppendLine("      , SUM(A.VLRLMT) AS VALOR ");
            sql.AppendLine("   FROM MRT.HSTLMTVBAMCO A ");
            sql.AppendLine("  INNER JOIN MRT.T0100086 B ON (A.CODMER = B.CODMER) AND B.CODEMP = 1  ");
            sql.AppendLine("  INNER JOIN MRT.T0100426 C ON (A.CODFRN = C.CODFRN) ");
            sql.AppendLine("  WHERE A.DESHSTLMT = 'Ref. venda funding carimbo' ");

            if (filtro.DtInicio != null && filtro.DtFim != null)
            {
                sql.Append(" AND TRUNC(A.DATHRAGRCHST) BETWEEN TO_DATE('").Append(filtro.DtInicio.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD')  ").AppendLine();
                sql.Append("                               AND TO_DATE('").Append(filtro.DtFim.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD')   ").AppendLine();
            }

            if (filtro.Destino > 0)
            {
                if (filtro.Destino == 91)
                    sql.AppendLine(" AND A.TIPDSNDSCBNF = 91");
                else
                    sql.AppendLine(" AND A.TIPDSNDSCBNF <>  91");
            }

            if (filtro.CodFornecedor != null)
                sql.AppendLine(" AND A.CODFRN =  ").Append(filtro.CodFornecedor.ToString()).AppendLine();

            sql.AppendLine("GROUP BY A.CODFRN ");
            sql.AppendLine("       , C.NOMFRN ");
            sql.AppendLine("       , CASE WHEN A.TIPDSNDSCBNF = 91 THEN 'PRECO' ELSE 'MARGEM' END");
            sql.AppendLine("       , A.CODFILEMP ");

            Command cmd = new Command();

            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();


            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    VerbasCarimbadasRealizadoSintetico objResult = new VerbasCarimbadasRealizadoSintetico();

                    if (row.Table.Columns.Contains("CODIGO_FORNECEDOR") && !row.IsNull("CODIGO_FORNECEDOR"))
                        objResult.CodFornecedor = int.Parse(row["CODIGO_FORNECEDOR"].ToString());

                    if (row.Table.Columns.Contains("NOME_FORNECEDOR") && !row.IsNull("NOME_FORNECEDOR"))
                        objResult.NomFornecedor = row["NOME_FORNECEDOR"].ToString();

                    if (row.Table.Columns.Contains("DESTINO") && !row.IsNull("DESTINO"))
                        objResult.Destino = row["DESTINO"].ToString();

                    if (row.Table.Columns.Contains("FILIAL") && !row.IsNull("FILIAL"))
                        objResult.CodFilial = int.Parse(row["FILIAL"].ToString());


                    if (row.Table.Columns.Contains("VALOR") && !row.IsNull("VALOR"))
                        objResult.Valor = decimal.Parse(row["VALOR"].ToString());

                    list.Add(objResult);
                }
            }

            ListResult<VerbasCarimbadasRealizadoSintetico> result = ListResultadoManager.PaginarLista(list, pagina, tamanho, coluna, sentido);
            result.AggregateSummary = new Dictionary<string, object>();

            decimal sumValor = list.Sum(p => p.Valor.GetValueOrDefault());

            result.AggregateSummary.Add("sumValor", sumValor);

            return result;
        }

        public static ListResult<VerbasCarimbadasRealizadoAnalitico> ListVerbasCarimbadasAnalitico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosVerbasCarimbadas filtro)
        {
            StringBuilder sql = new StringBuilder();
            List<VerbasCarimbadasRealizadoAnalitico> list = new List<VerbasCarimbadasRealizadoAnalitico>();

            sql.AppendLine("SELECT A.CODFRN AS CODIGO_FORNECEDOR ");
            sql.AppendLine("     , TRIM(C.NOMFRN) AS NOME_FORNECEDOR ");
            sql.AppendLine("     , CASE WHEN A.TIPDSNDSCBNF = 91 THEN 'PRECO' ELSE 'MARGEM' END AS DESTINO ");
            sql.AppendLine("     , A.CODFILEMP AS FILIAL ");
            sql.AppendLine("     , A.CODMER AS CODIGO_MERCADORIA ");
            sql.AppendLine("     , B.DESMER AS DESCRICAO_MERCADORIA ");
            sql.AppendLine("     , SUM(A.VLRLMT) AS VALOR ");
            sql.AppendLine("  FROM MRT.HSTLMTVBAMCO A ");
            sql.AppendLine(" INNER JOIN MRT.T0100086 B ON (A.CODMER = B.CODMER) AND B.CODEMP = 1 ");
            sql.AppendLine(" INNER JOIN MRT.T0100426 C ON (A.CODFRN = C.CODFRN)");
            sql.AppendLine(" WHERE A.DESHSTLMT = 'Ref. venda funding carimbo' ");

            if (filtro.DtInicio != null && filtro.DtFim != null)
            {
                sql.Append(" AND TRUNC(A.DATHRAGRCHST) BETWEEN TO_DATE('").Append(filtro.DtInicio.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-dd')   ").AppendLine();
                sql.Append("                               AND TO_DATE('").Append(filtro.DtFim.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD')   ").AppendLine();
            }

            if (filtro.Destino > 0)
            {
                if (filtro.Destino == 91)
                    sql.AppendLine(" AND A.TIPDSNDSCBNF = 91");
                else
                    sql.AppendLine(" AND A.TIPDSNDSCBNF <>  91");
            }

            if (filtro.CodFornecedor != null)
                sql.AppendLine(" AND A.CODFRN =  ").Append(filtro.CodFornecedor.ToString()).AppendLine();

            sql.AppendLine("GROUP BY  A.CODFRN ");
            sql.AppendLine("        , C.NOMFRN ");
            sql.AppendLine("        , CASE WHEN A.TIPDSNDSCBNF = 91 THEN 'PRECO' ELSE 'MARGEM' END  ");
            sql.AppendLine("        , A.CODFILEMP ");
            sql.AppendLine("        , A.CODMER");
            sql.AppendLine("        , B.DESMER");

            Command cmd = new Command();

            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();


            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    VerbasCarimbadasRealizadoAnalitico objResult = new VerbasCarimbadasRealizadoAnalitico();

                    if (row.Table.Columns.Contains("CODIGO_FORNECEDOR") && !row.IsNull("CODIGO_FORNECEDOR"))
                        objResult.CodFornecedor = int.Parse(row["CODIGO_FORNECEDOR"].ToString());

                    if (row.Table.Columns.Contains("NOME_FORNECEDOR") && !row.IsNull("NOME_FORNECEDOR"))
                        objResult.NomFornecedor = row["NOME_FORNECEDOR"].ToString();

                    if (row.Table.Columns.Contains("DESTINO") && !row.IsNull("DESTINO"))
                        objResult.Destino = row["DESTINO"].ToString();

                    if (row.Table.Columns.Contains("FILIAL") && !row.IsNull("FILIAL"))
                        objResult.CodFilial = int.Parse(row["FILIAL"].ToString());

                    if (row.Table.Columns.Contains("CODIGO_MERCADORIA") && !row.IsNull("CODIGO_MERCADORIA"))
                        objResult.CodMercadoria = int.Parse(row["CODIGO_MERCADORIA"].ToString());

                    if (row.Table.Columns.Contains("DESCRICAO_MERCADORIA") && !row.IsNull("DESCRICAO_MERCADORIA"))
                        objResult.DescricaoMercadoria = row["DESCRICAO_MERCADORIA"].ToString();

                    if (row.Table.Columns.Contains("VALOR") && !row.IsNull("VALOR"))
                        objResult.Valor = decimal.Parse(row["VALOR"].ToString());

                    list.Add(objResult);
                }
            }

            ListResult<VerbasCarimbadasRealizadoAnalitico> result = ListResultadoManager.PaginarLista(list, pagina, tamanho, coluna, sentido);
            result.AggregateSummary = new Dictionary<string, object>();

            decimal sumValor = list.Sum(p => p.Valor.GetValueOrDefault());

            result.AggregateSummary.Add("sumValor", sumValor);

            return result;

        }

        public static ListResult<VerbasCarimbadasCanceladoSintetico> ListVerbasCarimbadasCanceladoSintetico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosVerbasCarimbadas filtro)
        {
            StringBuilder sql = new StringBuilder();
            List<VerbasCarimbadasCanceladoSintetico> list = new List<VerbasCarimbadasCanceladoSintetico>();

            sql.AppendLine(" SELECT A.CODFRN AS CODIGO_FORNECEDOR ");
            sql.AppendLine("      , TRIM(C.NOMFRN) AS NOME_FORNECEDOR ");
            sql.AppendLine("      , CASE WHEN A.TIPDSNDSCBNF = 91 THEN 'PRECO' ELSE 'MARGEM' END AS DESTINO ");
            sql.AppendLine("      , A.CODFILEMP AS FILIAL ");
            sql.AppendLine("      , SUM(A.VLRLMT) AS VALOR ");
            sql.AppendLine("   FROM MRT.HSTLMTVBAMCO A ");
            sql.AppendLine("  INNER JOIN MRT.T0100086 B ON (A.CODMER = B.CODMER) AND B.CODEMP = 1  ");
            sql.AppendLine("  INNER JOIN MRT.T0100426 C ON (A.CODFRN = C.CODFRN) ");
            sql.AppendLine("  WHERE A.DESHSTLMT = 'Ref. cancelamento venda funding carimbo' ");



            if (filtro.DtInicio != null && filtro.DtFim != null)
            {
                sql.Append(" AND TRUNC(A.DATHRAGRCHST) BETWEEN TO_DATE('").Append(filtro.DtInicio.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD')").AppendLine();
                sql.Append("                               AND TO_DATE('").Append(filtro.DtFim.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD')").AppendLine();
            }

            if (filtro.Destino > 0)
            {
                if (filtro.Destino == 91)
                    sql.AppendLine(" AND A.TIPDSNDSCBNF = 91");
                else
                    sql.AppendLine(" AND A.TIPDSNDSCBNF <>  91");
            }

            if (filtro.CodFornecedor != null)
                sql.AppendLine(" AND A.CODFRN =  ").Append(filtro.CodFornecedor.ToString()).AppendLine();

            sql.AppendLine("GROUP BY A.CODFRN ");
            sql.AppendLine("      , C.NOMFRN ");
            sql.AppendLine("      , CASE WHEN A.TIPDSNDSCBNF = 91 THEN 'PRECO' ELSE 'MARGEM' END  ");
            sql.AppendLine("      , A.CODFILEMP ");

            Command cmd = new Command();

            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();


            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    VerbasCarimbadasCanceladoSintetico objResult = new VerbasCarimbadasCanceladoSintetico();

                    if (row.Table.Columns.Contains("CODIGO_FORNECEDOR") && !row.IsNull("CODIGO_FORNECEDOR"))
                        objResult.CodFornecedor = int.Parse(row["CODIGO_FORNECEDOR"].ToString());

                    if (row.Table.Columns.Contains("NOME_FORNECEDOR") && !row.IsNull("NOME_FORNECEDOR"))
                        objResult.NomFornecedor = row["NOME_FORNECEDOR"].ToString();

                    if (row.Table.Columns.Contains("DESTINO") && !row.IsNull("DESTINO"))
                        objResult.Destino = row["DESTINO"].ToString();

                    if (row.Table.Columns.Contains("FILIAL") && !row.IsNull("FILIAL"))
                        objResult.CodFilial = int.Parse(row["FILIAL"].ToString());


                    if (row.Table.Columns.Contains("VALOR") && !row.IsNull("VALOR"))
                        objResult.Valor = decimal.Parse(row["VALOR"].ToString());

                    list.Add(objResult);
                }
            }

            ListResult<VerbasCarimbadasCanceladoSintetico> result = ListResultadoManager.PaginarLista(list, pagina, tamanho, coluna, sentido);
            result.AggregateSummary = new Dictionary<string, object>();

            decimal sumValor = list.Sum(p => p.Valor.GetValueOrDefault());

            result.AggregateSummary.Add("sumValor", sumValor);

            return result;
        }

        public static ListResult<VerbasCarimbadasCanceladoAnalitico> ListVerbasCarimbadasCanceladoAnalitico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosVerbasCarimbadas filtro)
        {
            StringBuilder sql = new StringBuilder();
            List<VerbasCarimbadasCanceladoAnalitico> list = new List<VerbasCarimbadasCanceladoAnalitico>();

            sql.Append("SELECT A.CODFRN AS CODIGO_FORNECEDOR ");
            sql.Append("     , trim(C.NOMFRN) AS NOME_FORNECEDOR ");
            sql.Append("     , CASE WHEN A.TIPDSNDSCBNF = 91 THEN 'PRECO' ELSE 'MARGEM' END AS DESTINO ");
            sql.Append("     , A.CODFILEMP AS FILIAL ");
            sql.Append("     , A.CODMER AS CODIGO_MERCADORIA ");
            sql.Append("     , B.DESMER AS DESCRICAO_MERCADORIA ");
            sql.Append("     , SUM(A.VLRLMT) AS VALOR ");
            sql.Append("  FROM MRT.HSTLMTVBAMCO A ");
            sql.Append(" INNER JOIN MRT.T0100086 B ON (A.CODMER = B.CODMER) AND B.CODEMP = 1 ");
            sql.Append(" INNER JOIN MRT.T0100426 C ON (A.CODFRN = C.CODFRN)");
            sql.Append(" WHERE A.DESHSTLMT = 'Ref. cancelamento venda funding carimbo' ");

            if (filtro.DtInicio != null && filtro.DtFim != null)
            {
                sql.Append(" AND TRUNC(A.DATHRAGRCHST) BETWEEN TO_DATE('").Append(filtro.DtInicio.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD')   ").AppendLine();
                sql.Append("                               AND TO_DATE('").Append(filtro.DtFim.GetValueOrDefault().ToString("yyyy-MM-dd")).Append("', 'YYYY-MM-DD')   ").AppendLine();
            }

            if (filtro.Destino > 0)
            {
                if (filtro.Destino == 91)
                    sql.AppendLine(" AND A.TIPDSNDSCBNF = 91");
                else
                    sql.AppendLine(" AND A.TIPDSNDSCBNF <>  91");
            }

            if (filtro.CodFornecedor != null)
                sql.AppendLine(" AND A.CODFRN =  ").Append(filtro.CodFornecedor.ToString()).AppendLine();

            sql.AppendLine("GROUP BY A.CODFRN ");
            sql.AppendLine("       , C.NOMFRN ");
            sql.AppendLine("       , CASE WHEN A.TIPDSNDSCBNF = 91 THEN 'PRECO' ELSE 'MARGEM' END  ");
            sql.AppendLine("       , A.CODFILEMP ");
            sql.AppendLine("       , A.CODMER");
            sql.AppendLine("       , B.DESMER");

            Command cmd = new Command();

            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();


            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    VerbasCarimbadasCanceladoAnalitico objResult = new VerbasCarimbadasCanceladoAnalitico();

                    if (row.Table.Columns.Contains("CODIGO_FORNECEDOR") && !row.IsNull("CODIGO_FORNECEDOR"))
                        objResult.CodFornecedor = int.Parse(row["CODIGO_FORNECEDOR"].ToString());

                    if (row.Table.Columns.Contains("NOME_FORNECEDOR") && !row.IsNull("NOME_FORNECEDOR"))
                        objResult.NomFornecedor = row["NOME_FORNECEDOR"].ToString();

                    if (row.Table.Columns.Contains("DESTINO") && !row.IsNull("DESTINO"))
                        objResult.Destino = row["DESTINO"].ToString();

                    if (row.Table.Columns.Contains("FILIAL") && !row.IsNull("FILIAL"))
                        objResult.CodFilial = int.Parse(row["FILIAL"].ToString());

                    if (row.Table.Columns.Contains("CODIGO_MERCADORIA") && !row.IsNull("CODIGO_MERCADORIA"))
                        objResult.CodMercadoria = int.Parse(row["CODIGO_MERCADORIA"].ToString());

                    if (row.Table.Columns.Contains("DESCRICAO_MERCADORIA") && !row.IsNull("DESCRICAO_MERCADORIA"))
                        objResult.DescricaoMercadoria = row["DESCRICAO_MERCADORIA"].ToString();

                    if (row.Table.Columns.Contains("VALOR") && !row.IsNull("VALOR"))
                        objResult.Valor = decimal.Parse(row["VALOR"].ToString());

                    list.Add(objResult);
                }
            }

            ListResult<VerbasCarimbadasCanceladoAnalitico> result = ListResultadoManager.PaginarLista(list, pagina, tamanho, coluna, sentido);
            result.AggregateSummary = new Dictionary<string, object>();

            decimal sumValor = list.Sum(p => p.Valor.GetValueOrDefault());

            result.AggregateSummary.Add("sumValor", sumValor);

            return result;
        }
    }
}
