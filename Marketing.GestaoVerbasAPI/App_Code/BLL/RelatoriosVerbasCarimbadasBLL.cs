using Marketing.GestaoVerbasAPI.App_Code.Connection;
using Marketing.GestaoVerbasAPI.App_Code.DAL;
using Marketing.GestaoVerbasAPI.Models.RelatoriosVerbasCarimbadas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.App_Code.BLL
{
    public class RelatoriosVerbasCarimbadasBLL
    {
        public static ListResult<VerbasCarimbadasRealizadoAnalitico> VerbaCarimbadaRealizadoAnalitico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosVerbasCarimbadas filtro)
        {
            return RelatoriosVerbasCarimbadasDAL.ListVerbasCarimbadasAnalitico(pagina, tamanho, coluna, sentido, filtro);
        }
                                                                     
        public static ListResult<VerbasCarimbadasRealizadoSintetico> VerbaCarimbadaRealizadoSintetico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosVerbasCarimbadas filtro)
        {
            return RelatoriosVerbasCarimbadasDAL.ListVerbasCarimbadasSintetico(pagina, tamanho, coluna, sentido, filtro);
        }

        public static ListResult<VerbasCarimbadasCanceladoAnalitico> VerbaCarimbadaCanceladoAnalitico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosVerbasCarimbadas filtro)
        {
            return RelatoriosVerbasCarimbadasDAL.ListVerbasCarimbadasCanceladoAnalitico(pagina, tamanho, coluna, sentido, filtro);
        }

        public static ListResult<VerbasCarimbadasCanceladoSintetico> VerbaCarimbadaCanceladoSintetico(int pagina, int tamanho, string coluna, string sentido, FiltrosRelatoriosVerbasCarimbadas filtro)
        {
            return RelatoriosVerbasCarimbadasDAL.ListVerbasCarimbadasCanceladoSintetico(pagina, tamanho, coluna, sentido, filtro);
        }
    }
}
