using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models.RelatoriosVerbasCarimbadas
{
    public class VerbasCarimbadasCanceladoAnalitico
    {
        #region "Gerais"

        /// <summary>
        /// Nome do Fornecedor
        /// </summary>
        public string NomFornecedor { get; set; }

        /// <summary>
        /// Código do Fornecedor
        /// </summary>
        public int? CodFornecedor { get; set; }

        /// <summary>
        /// Código da Mercadoria
        /// </summary>
        public int? CodMercadoria { get; set; }

        /// <summary>
        /// Descrição da Mercadoria
        /// </summary>
        public string DescricaoMercadoria { get; set; }

        /// <summary>
        /// Destino da verba
        /// </summary>
        public string Destino { get; set; }

        /// <summary>
        /// Código da Filial
        /// </summary>
        public int? CodFilial { get; set; }

        /// <summary>
        /// VALOR 
        /// </summary>
        public decimal? Valor { get; set; }
        #endregion    
    }
}