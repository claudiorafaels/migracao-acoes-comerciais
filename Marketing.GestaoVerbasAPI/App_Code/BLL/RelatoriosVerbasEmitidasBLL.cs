using Marketing.GestaoVerbasAPI.App_Code.Connection;
using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class RelatoriosVerbasEmitidasBLL
    {

        public static ListResult<RelatoriosVerbasEmitidas> PorCarrimboFornecedor(int pagina, int tamanho, string coluna, string sentido, RelatoriosVerbasEmitidas filtro)
        {
            return RelatoriosVerbasEmitidasDAL.PorCarrimboFornecedor(pagina, tamanho, coluna, sentido, filtro);
        }

        public static ListResult<RelatoriosVerbasEmitidas> PorCarrimboMercadoria(int pagina, int tamanho, string coluna, string sentido, RelatoriosVerbasEmitidas filtro)
        {
            return RelatoriosVerbasEmitidasDAL.PorCarrimboMercadoria(pagina, tamanho, coluna, sentido, filtro);
        }

        public static ListResult<RelatoriosVerbasEmitidas> PorNegociacaoVerba(int pagina, int tamanho, string coluna, string sentido, RelatoriosVerbasEmitidas filtro)
        {
            return RelatoriosVerbasEmitidasDAL.PorNegociacaoVerba(pagina, tamanho, coluna, sentido, filtro);
        }
        public static ListResult<RelatoriosVerbasEmitidas> PorNegociacaoVerbaEmpenho(int pagina, int tamanho, string coluna, string sentido, RelatoriosVerbasEmitidas filtro)
        {
            return RelatoriosVerbasEmitidasDAL.PorNegociacaoVerbaEmpenho(pagina, tamanho, coluna, sentido, filtro);
        }

        
    }
}