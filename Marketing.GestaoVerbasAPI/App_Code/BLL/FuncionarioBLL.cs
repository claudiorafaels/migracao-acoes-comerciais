using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.App_Code.Connection;

namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class FuncionarioBLL
    {

        public static ListResult<Funcionario> List(int pagina, int tamanho, string coluna, string sentido, Funcionario filtro)
        {
            return  FuncionarioDAL.List(pagina, tamanho, coluna, sentido, filtro);
        }

        public static Funcionario Select(int codFuncionario)
        {
            return FuncionarioDAL.Select(codFuncionario);
        }
    }
}