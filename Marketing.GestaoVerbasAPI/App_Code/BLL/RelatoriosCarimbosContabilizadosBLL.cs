using Marketing.GestaoVerbasAPI.App_Code.Connection;
using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.Models.RelatoriosCarimbosContabilizados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class RelatoriosCarimbosContabilizadosBLL
    {
        public static ListResult<ValoresReceberAnalitico> AReceberAnalitico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            return RelatoriosCarimbosContabilizadosDAL.AReceberAnalitico(pagina, tamanho, coluna, sentido, filtro);
        }

        public static ListResult<ValoresReceberSintetico> AReceberSintetico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            return RelatoriosCarimbosContabilizadosDAL.AReceberSintetico(pagina, tamanho, coluna, sentido, filtro);
        }

        public static ListResult<ValoresRecebidosAnalitico> RecebidosAnalitico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            return RelatoriosCarimbosContabilizadosDAL.RecebidosAnalitico(pagina, tamanho, coluna, sentido, filtro);
        }

        public static ListResult<ValoresRecebidosSintetico> RecebidosSintetico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            return RelatoriosCarimbosContabilizadosDAL.RecebidosSintetico(pagina, tamanho, coluna, sentido, filtro);
        }

        public static ListResult<NovosAcordosAnalitico> NovosAcordosAnalitico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            return RelatoriosCarimbosContabilizadosDAL.NovosAcordosAnalitico(pagina, tamanho, coluna, sentido, filtro);
        }

        public static ListResult<NovosAcordosSintetico> NovosAcordosSintetico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            return RelatoriosCarimbosContabilizadosDAL.NovosAcordosSintetico(pagina, tamanho, coluna, sentido, filtro);
        }

        public static ListResult<AcordosCanceladosAnalitico> AcordosCanceladosAnalitico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            return RelatoriosCarimbosContabilizadosDAL.AcordosCanceladosAnalitico(pagina, tamanho, coluna, sentido, filtro);
        }

        public static ListResult<AcordosCanceladosSintetico> AcordosCanceladosSintetico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosCarimbosContabilizados filtro)
        {
            return RelatoriosCarimbosContabilizadosDAL.AcordosCanceladosSintetico(pagina, tamanho, coluna, sentido, filtro);
        }

    }
}