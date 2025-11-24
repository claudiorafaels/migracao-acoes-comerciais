using Marketing.GestaoVerbasAPI.App_Code.Connection;
using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.DAL
{
    public class NegociacaoVerbaDAL
    {
        public static ListResult<NegociacaoVerba> List(int pagina, int tamanho, string coluna, string sentido, NegociacaoVerba filtro)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(@"SELECT VER.CODNGC
                                  , VER.DESNGC
                                  , VER.CODSTANGCFRN
                                  , VER.CODFILEMPORIVBA
                                  , VER.CODFRN
                                  , FRN.NOMFRN
                                  , VER.CODCPR
                                  , COM.NOMCPR
                                  , VER.VLRVBAFRN
                                  , VER.CODFNC
                                  , AUT.NOMFNC
                                  , VER.DATCADNGC
                                  , VER.DESOBSSLC
                                  , FIL.DESABVFILEMP
                                  , HST.DATHRAGRCHST AS DtAprovacao
                               FROM MRT.CADNGCVBAFRN VER
                               INNER JOIN MRT.T0100361 AUT ON AUT.CODFNC = VER.CODFNC
                               INNER JOIN MRT.T0113625 COM ON COM.CODCPR = VER.CODCPR
                               INNER JOIN MRT.T0100426 FRN ON FRN.CODFRN = VER.CODFRN 
                               INNER JOIN MRT.T0118570 DIV ON DIV.CODGERPRD = FRN.CODGERPRD
                               INNER JOIN MRT.T0112963 FIL ON FIL.CODFILEMP = VER.CODFILEMPORIVBA 
                                LEFT JOIN MRT.HSTNGCVBAFRN HST ON  VER.CODNGC = HST.CODNGC AND HST.CODSTANGCFRN = 3
                               WHERE 1=1");
            if (filtro.CodNegociacaoVerba != null)
                sql.Append("AND VER.CODNGC = ").AppendLine(filtro.CodNegociacaoVerba.ToString());
            if (!string.IsNullOrWhiteSpace(filtro.DesNegociacaoVerba))
                sql.Append("AND VER.DESNGC LIKE '%").Append(filtro.DesNegociacaoVerba.TrimStart().TrimEnd()).AppendLine("%'");
            if (filtro.CodFilialVerba != null)
                sql.Append("AND VER.CODFILEMPORIVBA = ").AppendLine(filtro.CodFilialVerba.ToString());
            if (filtro.CodFornecedor != null)
                sql.Append("AND VER.CODFRN = ").AppendLine(filtro.CodFornecedor.ToString());
            if (filtro.CodComprador != null)
                sql.Append("AND VER.CODCPR = ").AppendLine(filtro.CodComprador.ToString());
            if (filtro.CodAutor != null)
                sql.Append("AND VER.CODFNC = ").AppendLine(filtro.CodAutor.ToString());
            if (filtro.CodStatusNegociacaoVenda != null)
                sql.Append("AND VER.CODSTANGCFRN = ").AppendLine(filtro.CodStatusNegociacaoVenda.ToString());
            if (filtro.CodCelula != null)
                sql.Append("AND DIV.CODDIVCMP = ").Append(filtro.CodCelula).AppendLine();
            if (filtro.DtCadastroNegociacaoInicio != null && filtro.DtCadastroNegociacaoFim != null)
            {
                sql.Append("AND DATCADNGC BETWEEN TO_DATE('");
                sql.Append(filtro.DtCadastroNegociacaoInicio.GetValueOrDefault().ToString("yyyy-MM-dd"));
                sql.Append("', 'yyyy-mm-dd') AND TO_DATE('");
                sql.Append(filtro.DtCadastroNegociacaoFim.GetValueOrDefault().ToString("yyyy-MM-dd"));
                sql.AppendLine("', 'yyyy-mm-dd')");
            }

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();


            List<NegociacaoVerba> list = new List<NegociacaoVerba>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    NegociacaoVerba obj = new NegociacaoVerba();
                    if (!row.IsNull("CODNGC"))
                        obj.CodNegociacaoVerba = int.Parse((row["CODNGC"]).ToString());
                    if (!row.IsNull("DESNGC"))
                        obj.DesNegociacaoVerba = row["DESNGC"].ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("CODSTANGCFRN"))
                        obj.CodStatusNegociacaoVenda = int.Parse((row["CODSTANGCFRN"]).ToString());
                    if (!row.IsNull("CODFILEMPORIVBA"))
                        obj.CodFilialVerba = int.Parse((row["CODFILEMPORIVBA"]).ToString());
                    if (!row.IsNull("CODFRN"))
                        obj.CodFornecedor = int.Parse((row["CODFRN"]).ToString());
                    if (!row.IsNull("NOMFRN"))
                        obj.NomFornecedor = row["NOMFRN"].ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("CODCPR"))
                        obj.CodComprador = int.Parse((row["CODCPR"]).ToString());
                    if (!row.IsNull("NOMCPR"))
                        obj.NomComprador = row["NOMCPR"].ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("CODFNC"))
                        obj.CodAutor = int.Parse((row["CODFNC"]).ToString());
                    if (!row.IsNull("NOMFNC"))
                        obj.NomAutor = row["NOMFNC"].ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("VLRVBAFRN"))
                        obj.VlrVerba = decimal.Parse((row["VLRVBAFRN"]).ToString());
                    if (!row.IsNull("DATCADNGC"))
                        obj.DtCadastroNegociacao = DateTime.Parse((row["DATCADNGC"]).ToString());
                    if (!row.IsNull("DtAprovacao"))
                        obj.DtAprovacao = DateTime.Parse((row["DtAprovacao"]).ToString());
                    if (!row.IsNull("DESOBSSLC"))
                        obj.DesObservacaoSolicitacao = row["DESOBSSLC"].ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("DESABVFILEMP"))
                        obj.NomFilialVerba = row["DESABVFILEMP"].ToString().TrimStart().TrimEnd();
                    list.Add(obj);
                }
            }


            return ListResultadoManager.PaginarLista(list, pagina, tamanho, coluna, sentido);
        }

        public static NegociacaoVerba Select(int codigo)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"  SELECT VER.CODNGC
                                     , VER.DESNGC
                                     , VER.CODSTANGCFRN
                                     , VER.CODFILEMPORIVBA
                                     , VER.CODFRN
                                     , FRN.NOMFRN
                                     , VER.CODCPR
                                     , COM.NOMCPR
                                     , VER.VLRVBAFRN
                                     , VER.CODFNC
                                     , AUT.NOMFNC
                                     , VER.DATCADNGC
                                     , VER.DESOBSSLC
                                     , FIL.DESABVFILEMP
                                     , HST.DATHRAGRCHST AS DtAprovacao
                                  FROM MRT.CADNGCVBAFRN VER
                                  INNER JOIN MRT.T0100361 AUT ON AUT.CODFNC = VER.CODFNC
                                  INNER JOIN MRT.T0113625 COM ON COM.CODCPR = VER.CODCPR
                                  INNER JOIN MRT.T0100426 FRN ON FRN.CODFRN = VER.CODFRN 
                                  INNER JOIN MRT.T0112963 FIL ON FIL.CODFILEMP = VER.CODFILEMPORIVBA 
                                   LEFT JOIN MRT.HSTNGCVBAFRN HST ON  VER.CODNGC = HST.CODNGC AND HST.CODSTANGCFRN = 3
                                 WHERE VER.CODNGC = ").Append(codigo);

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            DataTable dt = cmd.GetData();

            NegociacaoVerba obj = null;

            if (dt != null && dt.Rows.Count == 1)
            {
                obj = new NegociacaoVerba();
                DataRow row = dt.Rows[0];
                if (!row.IsNull("CODNGC"))
                    obj.CodNegociacaoVerba = int.Parse((row["CODNGC"]).ToString());
                if (!row.IsNull("DESNGC"))
                    obj.DesNegociacaoVerba = row["DESNGC"].ToString().TrimStart().TrimEnd();
                if (!row.IsNull("CODSTANGCFRN"))
                    obj.CodStatusNegociacaoVenda = int.Parse((row["CODSTANGCFRN"]).ToString());
                if (!row.IsNull("CODFILEMPORIVBA"))
                    obj.CodFilialVerba = int.Parse((row["CODFILEMPORIVBA"]).ToString());
                if (!row.IsNull("DESABVFILEMP"))
                    obj.NomFilialVerba = row["DESABVFILEMP"].ToString().TrimStart().TrimEnd();
                if (!row.IsNull("CODFRN"))
                    obj.CodFornecedor = int.Parse((row["CODFRN"]).ToString());
                if (!row.IsNull("NOMFRN"))
                    obj.NomFornecedor = row["NOMFRN"].ToString().TrimStart().TrimEnd();
                if (!row.IsNull("CODCPR"))
                    obj.CodComprador = int.Parse((row["CODCPR"]).ToString());
                if (!row.IsNull("NOMCPR"))
                    obj.NomComprador = row["NOMCPR"].ToString().TrimStart().TrimEnd();
                if (!row.IsNull("CODFNC"))
                    obj.CodAutor = int.Parse((row["CODFNC"]).ToString());
                if (!row.IsNull("NOMFNC"))
                    obj.NomAutor = row["NOMFNC"].ToString().TrimStart().TrimEnd();
                if (!row.IsNull("VLRVBAFRN"))
                    obj.VlrVerba = decimal.Parse((row["VLRVBAFRN"]).ToString());
                if (!row.IsNull("DATCADNGC"))
                    obj.DtCadastroNegociacao = DateTime.Parse((row["DATCADNGC"]).ToString());        
                if (!row.IsNull("DESOBSSLC"))
                    obj.DesObservacaoSolicitacao = row["DESOBSSLC"].ToString();
                if (!row.IsNull("DtAprovacao"))
                    obj.DtAprovacao = DateTime.Parse((row["DtAprovacao"]).ToString());
            }
            return obj;
        }

        public static int NextCodNegociacaoVerba()
        {
            Command cmd = new Command();
            cmd.CommandText = @"SELECT NVL(MAX(CODNGC) + 1, 1) as NextVal
                                     FROM MRT.CADNGCVBAFRN";


            DataTable dt = cmd.GetData();

            int NextVal = 1;
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                if (!row.IsNull("NextVal"))
                    NextVal = int.Parse((row["NextVal"]).ToString());
            }
            return NextVal;
        }

        public static NegociacaoVerba Insert(NegociacaoVerba obj)
        {

            obj.CodNegociacaoVerba = NextCodNegociacaoVerba();


            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"INSERT INTO MRT.CADNGCVBAFRN
                                     ( CODNGC
                                     , DESNGC
                                     , CODSTANGCFRN
                                     , CODFILEMPORIVBA
                                     , CODFRN
                                     , CODCPR
                                     , VLRVBAFRN
                                     , CODFNC
                                     , DATCADNGC
                                     , DESOBSSLC)
                               VALUES(");
            sql.Append(" ").AppendLine(obj.CodNegociacaoVerba.ToString());
            sql.Append(", '").Append(obj.DesNegociacaoVerba.ToString().TrimStart().TrimEnd()).AppendLine("'");
            sql.Append(", ").AppendLine(obj.CodStatusNegociacaoVenda.ToString());
            sql.Append(", ").AppendLine(obj.CodFilialVerba.ToString());
            sql.Append(", ").AppendLine(obj.CodFornecedor.ToString());
            sql.Append(", ").AppendLine(obj.CodComprador.ToString());
            sql.Append(", ").AppendLine(obj.VlrVerba.ToString().Replace(",", "."));
            sql.Append(", ").AppendLine(obj.CodAutor.ToString());
            sql.Append(", TO_DATE('").Append(obj.DtCadastroNegociacao.GetValueOrDefault().ToString("yyyy-MM-dd HH:mm:ss")).AppendLine("', 'yyyy-mm-dd hh24:mi:ss')");
            sql.Append(", '").Append(obj.DesObservacaoSolicitacao.ToString().TrimStart().TrimEnd()).AppendLine("'");
            sql.AppendLine(")");

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();
            var ret = cmd.ExecuteScalar();
            if (ret != null)
                throw new Exception(ret.ToString());

            return obj;
        }

        public static void Update(int codigo, NegociacaoVerba obj)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(@"UPDATE MRT.CADNGCVBAFRN");

            sql.Append("SET DESNGC = '").Append(obj.DesNegociacaoVerba.ToString().TrimStart().TrimEnd()).AppendLine("'");
            sql.Append(", CODFILEMPORIVBA = ").AppendLine(obj.CodFilialVerba.ToString());
            sql.Append(", CODFRN = ").AppendLine(obj.CodFornecedor.ToString());
            sql.Append(", CODCPR = ").AppendLine(obj.CodComprador.ToString());
            sql.Append(", VLRVBAFRN = ").AppendLine(obj.VlrVerba.ToString().Replace(",", "."));
            sql.Append(", DESOBSSLC = '").Append(obj.DesObservacaoSolicitacao.ToString().TrimStart().TrimEnd()).AppendLine("'");

            sql.Append("WHERE CODNGC = ").AppendLine(codigo.ToString());

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();


            var ret = cmd.ExecuteScalar();
            if (ret != null)
                throw new Exception(ret.ToString());
        }

        public static void Delete(int codigo)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"DELETE FROM MRT.CADNGCVBAFRN
                                 WHERE CODNGC = ").AppendLine(codigo.ToString());

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();

            var ret = cmd.ExecuteScalar();

            if (ret != null)
                throw new Exception(ret.ToString());
        }



        public static void UpdateStatus(int CodNegociacaoVerba, int CodStatusNegociacaoVenda)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(@"UPDATE MRT.CADNGCVBAFRN");

            sql.Append("SET CODSTANGCFRN = ").AppendLine(CodStatusNegociacaoVenda.ToString());

            sql.Append("WHERE CODNGC = ").AppendLine(CodNegociacaoVerba.ToString());

            Command cmd = new Command();
            cmd.CommandText = sql.ToString();


            var ret = cmd.ExecuteScalar();
            if (ret != null)
                throw new Exception(ret.ToString());
        }
    }
}