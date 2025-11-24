using Marketing.GestaoVerbasAPI.App_Code.Connection;
using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class FornecedorBLL
    {
        public static ListResult<Fornecedor> List(int pagina, int tamanho, string coluna, string sentido, Fornecedor filtro)
        {
            return FornecedorDAL.List(pagina, tamanho, coluna, sentido, filtro);
        }


        public static List<Fornecedor> ListPorCompradorFilial(int pCodFilialEmpresa, int pCodComprador)
        {
            return FornecedorDAL.ListPorCompradorFilial(pCodFilialEmpresa, pCodComprador);
        }
    }
}