using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.GestaoVerbasAPI.Models
{
    public class RelatoriosVerbasEmitidas
    {
        /// <summary>
        /// CODNGC -
        /// </summary>
        public int? CodNegociacaoVerba { get; set; }

        /// <summary>
        /// DESNGC -
        /// </summary>
        public string NomNegociacaoVerba { get; set; }

        /// <summary>
        /// CODSTANGCFRN
        /// </summary>
        public int? CodStatusNegociacao { get; set; }

        ///// <summary>
        ///// DATCADNGC - DATA DE CADASTRAMENTO DA NEGOCIACAO   
        ///// </summary>        
        //public DateTime? DtCadastroNegociacao { get; set; }


        /// <summary>
        /// DATHRAGRCHST - DATA DE APROVACAO DA NEGOCIACAO   
        /// </summary>        
        public DateTime? DtAprovacaoNegociacao { get; set; }


        /// <summary>
        /// VLRRLZMCOVBAFRN -
        /// </summary>
        public decimal? VlrVerbaNegociacao { get; set; }

        /// <summary>
        /// DESOBSSLC - DESCRICAO OBSERVACAO DA SOLICITACAO
        /// </summary>
        public string DesObservacaoSolicitacao { get; set; }


        /// <summary>
        /// VLRVBAFRN  - VALOR DA VERBA DO FORNECEDOR                                          
        /// </summary>
        public decimal? VlrVerbaEmpenho { get; set; }

        /// <summary>
        /// DESOBSSLC -  DESCRICAO OBSERVACAO DA SOLICITACAO                                 
        /// </summary>
        public string DesObservacaoSolicitacaoEmpenho { get; set; }



        /// <summary>
        /// CODFILEMP -
        /// </summary>
        public int? CodFilialEmpresa { get; set; }

        /// <summary>
        /// DESABVFILEMP -
        /// </summary>
        public string NomFilialEmpresa { get; set; }


        /// <summary>
        /// CODFRN -
        /// </summary>
        public int? CodFornecedor { get; set; }

        /// <summary>
        /// NOMFRN -
        /// </summary>
        public string NomFornecedor { get; set; }



        /// <summary>
        /// TIPDSNDSCBNF -
        /// </summary>
        public int? CodDestino { get; set; }

        /// <summary>
        /// DESDSNDSCBNF -
        /// </summary>
        public string NomDestino { get; set; }

        /// <summary>
        /// TIPOBJMCOVBAFRN -
        /// </summary>
        public int? CodObjetivo { get; set; }

        /// <summary>
        /// DESOBJMCOVBAFRN -
        /// </summary>
        public string NomObjetivo { get; set; }

        /// <summary>
        ///TIPDSNDSCBNF - TIPO DESTINO / DESCONTO BONIFICADO                                      
        /// </summary>
        public int? CodDestinoObjetivo { get; set; }

        /// <summary>
        /// DESDSNDSCBNF
        /// </summary>
        public string NomDestinoObjetivo { get; set; }



        /// <summary>
        /// CODPMS -
        /// </summary>
        public int? CodAcordo { get; set; }




        /// <summary>
        /// CODMCOVBAFRN -
        /// </summary>
        public int? CodCarimbo { get; set; }

        /// <summary>
        /// DATGRCMCOVBAFRN	DATA GERACAO DO CARIMBO DA VERBA DO FORNECEDOR
        /// </summary>
        public DateTime? DtCadastroCarimbo { get; set; }

        /// <summary>
        /// INDSTAMCOVBAFRN	INDICADOR DE STATUS DO CARIMBO DA VERBA DO FORNECEDOR
        /// </summary>
        public int? CodStatusCarimbo { get; set; }

        /// <summary>
        /// 90% do valor da verba
        /// </summary>
        public decimal? VlrCarimbo { get; set; }

        /// <summary>
        /// 10 % do valorda verba
        /// </summary>
        public decimal? VlrImpostos { get; set; }

        /// <summary>
        /// DESOBSMCOVBAFRN	DESCRICAO OBSERVACAO DO CARIMBO DA VERBA DO FORNECEDOR
        /// </summary>
        public string DesObservacaoCarimbo { get; set; }

        /// <summary>
        /// CODMER -
        /// </summary>
        public int? CodMercadoria { get; set; }

        /// <summary>
        /// DESMER -
        /// </summary>
        public string NomMercadoria { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? VlrCarimboMercadoria { get; set; }

        
        /// <summary>
        /// CODCPR -
        /// </summary>
        public int? CodComprador { get; set; }

        /// <summary>
        /// DESDSNDSCBNF -
        /// </summary>
        public string NomComprador { get; set; }

        /// <summary>
        /// CODDIVCMP -
        /// </summary>
        public int? CodCelula { get; set; }

        /// <summary>
        /// DESDIVCMP -
        /// </summary>
        public string NomCelula { get; set; }

        /// <summary>
        /// DESOBSMCOVBAFRN -
        /// </summary>
        public string DesEntidade { get; set; }

        /// <summary>
        /// CODDRTCMP
        /// </summary>
        public int? CodDiretoria { get; set; }
        /// <summary>
        /// DESDRTCMP
        /// </summary>
        public string NomDiretoria { get; set; }

        #region "Auxiliares"

        ///// <summary>
        ///// Indicador de Visão -
        ///// </summary>
        //public string IndRelVisao { get; set; }

        //public string DesClasseMercadoria { get; set; }

        //public int? CodGrupoSimilar { get; set; }

        //public string DesGrupoMercadoriaSimilar { get; set; }

        ///// <summary>
        ///// DESGRPMERSMRAGP -  DESCRICAO GRUPAMENTO MERCADORIA SIMILAR AGRUPADO
        ///// </summary>
        //public string DesGrupoMercadoriaSimilarAgrupado { get; set; }

        ///// <summary>
        ///// DESDSNDSCBNF -
        ///// </summary>
        //public decimal? VlrImpostos { get; set; }

        ///// <summary>
        ///// DESDSNDSCBNF -
        ///// </summary>
        //public string NomComprador { get; set; }

        ///// <summary>
        ///// DESDSNDSCBNF -
        ///// </summary>]
        //public int? NumPedidoCompra { get; set; }










        // Campos de Filtro

        ///// <summary>
        ///// DATCADNGC - DATA DE CADASTRAMENTO DA NEGOCIACAO   
        ///// </summary>        
        //public DateTime? DtCadastroNegociacaoInicio { get; set; }
        ///// <summary>
        ///// DATCADNGC - DATA DE CADASTRAMENTO DA NEGOCIACAO   
        ///// </summary>        
        //public DateTime? DtCadastroNegociacaoFim { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public DateTime? DtAprovacaoNegociacaoInicio { get; set; }
        /// <summary>
        /// 
        /// </summary>        
        public DateTime? DtAprovacaoNegociacaoFim { get; set; }



        /// <summary>
        /// DATGRCMCOVBAFRN	DATA GERACAO DO CARIMBO DA VERBA DO FORNECEDOR
        /// </summary>
        public DateTime? DtCadastroCarimboInicio { get; set; }
        /// <summary>
        /// DATGRCMCOVBAFRN	DATA GERACAO DO CARIMBO DA VERBA DO FORNECEDOR
        /// </summary>
        public DateTime? DtCadastroCarimboFim { get; set; }
        #endregion
    }
}