using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketing.GestaoVerbasAPI.Models
{
    public class NegociacaoVerbaHistorico
    {
        /// <summary>
        /// - JUSTIFICATIVA REPROVACAO
        /// </summary>
        public string DesJustificativaReprovacao { get; set; }
        /// <summary>
        /// CODNGC - CODIGO NEGOCIACAO
        /// </summary>
        public int? CodNegociacaoVerba { get; set; }

        /// <summary>
        /// DATHRAGRCHST - DATA E HORA GRAVACAO DO HISTORICO DE ALTERACAO DE CLIENTE             
        /// </summary>
        public DateTime? DtHistorico { get; set; }

        /// <summary>
        /// CODSTANGCFRN - CODIGO DO STATUS DA NEGOCIACAO COM O FORNECEDOR                       
        /// </summary>
        public int? CodStatusNegociacaoVenda { get; set; }

        /// <summary>
        /// CODFNC - CODIGO FUNCIONARIO                                                    
        /// </summary>
        public int? CodFuncionario { get; set; }


        #region "campos auxiliares"

        /// <summary>
        /// NOMFNC - NOME DO FUNCIONARIO
        /// </summary>
        public string NomFuncionario { get; set; }

        #endregion
    }
}