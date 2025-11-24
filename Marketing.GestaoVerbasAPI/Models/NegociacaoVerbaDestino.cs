using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models
{
    public class NegociacaoVerbaDestino
    {
        /// <summary>
        /// CODNGC - CODIGO NEGOCIACAO
        /// </summary>
        public int? CodNegociacaoVerba { get; set; }

        /// <summary>
        ///TIPDSNDSCBNF - TIPO DESTINO / DESCONTO BONIFICADO                                      
        /// </summary>
        public int? CodDestinoObjetivo { get; set; }

        /// <summary>
        /// VLRVBAFRN  - VALOR DA VERBA DO FORNECEDOR                                          
        /// </summary>
        public decimal? VlrVerba { get; set; }

        /// <summary>
        /// DESOBSSLC -  DESCRICAO OBSERVACAO DA SOLICITACAO                                   
        /// </summary>
        public string DesObservacao { get; set; }


        /// <summary>
        /// CODPMS	CODIGO PROMESSA
        /// </summary>
        public int? CodPromessa { get; set; }



        // Auxiliares

        /// <summary>
        /// DESDSNDSCBNF
        /// </summary>
        public string NomDestinoObjetivo { get; set; }

        /// <summary>
        /// TIPOBJDSNVBA -  TIPO DO OBJETIVO DO DESTINO DA VERBA                                                               
        /// </summary>
        public int? CodObjetivo { get; set; }

        /// <summary>
        /// DESOBJDSNVBA - DESCRICAO DO OBJETIVO DO DESTINO DA VERBA                         
        /// </summary>
        public string NomObjetivo { get; set; }


        /// <summary>
        /// TIPVBAFRN - TIPO DA VERBA DO FORNECEDOR                                
        /// </summary>
        public int? CodDestino{ get; set; }


        /// <summary>
        /// CODMCOVBAFRN - CODIGO DO CARIMBO DE VERBA DO FORNECEDOR    
        /// </summary>
        public int? CodCarimbo { get; set; }

    }
}