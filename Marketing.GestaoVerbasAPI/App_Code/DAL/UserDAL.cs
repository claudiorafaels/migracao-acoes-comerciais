using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.DAL
{
    public class UserDAL
    {

        public static Usuario GetUserByLogin(String login)
        {
            Command cmd = new Command();
            cmd.CommandText = "SELECT TO_CHAR(FNC.CODFNC) MATRICULA, FNC.NOMFNC NOME " +
                                    ", RDE.NOMUSRRCF ID_REDE " +
                                    ", LOWER(TRIM(RDE.NOMUSRRCF)) || '@martins.com.br' AS EMAIL " +
                                    "FROM MRT.T0104596 RDE " +
                                    "INNER JOIN MRT.T0100361 FNC ON RDE.CODFNC = FNC.CODFNC " +
                                    "WHERE RDE.NOMUSRRCF = UPPER('" + login + "')";
            DataTable dt = cmd.GetData();

            Usuario usuario = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                usuario = new Usuario()
                {
                    Matricula = (row.IsNull("MATRICULA") ? "" : row["MATRICULA"].ToString()),
                    Nome = (row.IsNull("NOME") ? "" : row["NOME"].ToString()),
                    IdRede = (row.IsNull("ID_REDE") ? "" : row["ID_REDE"].ToString()),
                    Email = (row.IsNull("EMAIL") ? "" : row["EMAIL"].ToString())
                };
            }
            return usuario;
        }

        public static Usuario GetUserByCodFunc(int? codFunc)
        {
            Command cmd = new Command();
            //nome, centro de custo, empresa, filial
            cmd.CommandText = " SELECT FNC.NOMFNC NOME, FNC.CODEMP, FNC.CODFILEMP, FNC.CODCENCST " +
                              " , TO_CHAR(FNC.CODFNC) MATRICULA" +
                              " , RDE.NOMUSRRCF ID_REDE " +
                              " , LOWER(TRIM(RDE.NOMUSRRCF)) || '@martins.com.br' AS EMAIL " +
                              " FROM MRT.T0100361 FNC" +
                              " INNER JOIN  MRT.T0104596 RDE ON RDE.CODFNC = FNC.CODFNC " +
                              " WHERE FNC.CODFNC = " + codFunc;
            DataTable dt = cmd.GetData();

            try
            {
                Usuario usuario = null;

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    usuario = new Usuario();
                    usuario.Matricula = (row.IsNull("MATRICULA") ? "" : row["MATRICULA"].ToString());
                    usuario.Nome = (row.IsNull("NOME") ? "" : row["NOME"].ToString());
                    usuario.IdRede = (row.IsNull("ID_REDE") ? "" : row["ID_REDE"].ToString());
                    usuario.Email = (row.IsNull("EMAIL") ? "" : row["EMAIL"].ToString());
                    usuario.CentroCusto = (row.IsNull("CODCENCST") ? "" : row["CODCENCST"].ToString());
                    usuario.CodEmpresa = (row.IsNull("CODEMP") ? 0 : int.Parse(row["CODEMP"].ToString()));
                    usuario.CodFilial = (row.IsNull("CODFILEMP") ? 0 : int.Parse(row["CODFILEMP"].ToString()));
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro método: GetUserByCodFunc. Erro: " + ex.Message);
            }
        }
    }
}