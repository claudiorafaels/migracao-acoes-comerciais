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
    public class FuncionarioDAL
    {
        public static ListResult<Funcionario> List(int pagina, int tamanho, string coluna, string sentido, Funcionario filtro)
        {
            Command cmd = new Command();

            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"select CODFNC
                                  , NOMFNC
                                  , CODEMP
                             from MRT.T0100361
                            where 1=1");

            if (filtro.CodFuncionario != null)
                sql.Append(" AND CODFNC = ").AppendLine(filtro.CodFuncionario.ToString());
            if (filtro.NomFuncionario != null)
                sql.Append(" AND NOMFNC LIKE UPPER('%").Append(filtro.NomFuncionario).AppendLine("%')");
            if (filtro.CodEmpresa != null)
                sql.Append(" AND CODEMP = ").AppendLine(filtro.CodEmpresa.ToString());

            cmd.CommandText = sql.ToString();
            DataTable dt = cmd.GetData();


            List<Funcionario> funcionarios = new List<Funcionario>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Funcionario funcionario = new Funcionario();
                    if (!row.IsNull("CODFNC"))
                        funcionario.CodFuncionario = int.Parse((row["CODFNC"]).ToString());
                    if (!row.IsNull("NOMFNC"))
                        funcionario.NomFuncionario = row["NOMFNC"].ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("CODEMP"))
                        funcionario.CodEmpresa = int.Parse((row["CODEMP"]).ToString());

                    funcionarios.Add(funcionario);
                }
            }

            return ListResultadoManager.PaginarLista(funcionarios, pagina, tamanho, coluna, sentido);
        }


        public static Funcionario Select(int codFuncionario)
        {
            Command cmd = new Command();

            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"select CODFNC
                                  , NOMFNC
                                  , CODEMP
                             from MRT.T0100361
                            where CODFNC = ").AppendLine(codFuncionario.ToString());


            cmd.CommandText = sql.ToString();
            DataTable dt = cmd.GetData();

            Funcionario funcionario = null;

            if (dt != null && dt.Rows.Count == 1)
            {
                foreach (DataRow row in dt.Rows)
                {
                    funcionario = new Funcionario();
                    if (!row.IsNull("CODFNC"))
                        funcionario.CodFuncionario = int.Parse((row["CODFNC"]).ToString());
                    if (!row.IsNull("NOMFNC"))
                        funcionario.NomFuncionario = row["NOMFNC"].ToString().TrimStart().TrimEnd();
                    if (!row.IsNull("CODEMP"))
                        funcionario.CodEmpresa = int.Parse((row["CODEMP"]).ToString());

                }
            }
            return funcionario;
        }
    }
}