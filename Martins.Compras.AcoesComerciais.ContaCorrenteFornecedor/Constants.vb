Public Class Constants
    Public Const CONEXAO_PRINCIPAL As Decimal = 152
    Public Const TIPO_EDICAO_INCLUSAO As Decimal = 1
    Public Const TIPO_EDICAO_ALTERACAO As Decimal = 2
    Public Const TIPO_EDICAO_EXCLUSAO As Decimal = 3

    'Tipo de Status Transferencia Verbas Fornecedor
    Public Const TIPSTAFLUAPV_NOVO As String = "0"
    Public Const TIPSTAFLUAPV_EM_APROVACAO As String = "1"
    Public Const TIPSTAFLUAPV_REJEITADO As String = "2"
    Public Const TIPSTAFLUAPV_APROVADO As String = "3"
    Public Const TIPSTAFLUAPV_ESPERA_APROVACAO As String = "4"

    Public Const CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS As Decimal = 9
    Public Const CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS_EMPENHO_MARKETING As Decimal = 13
    Public Const CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS_DESONERACAO_E_RESULTADO_AGF As Decimal = 15

    'Indicador do mes para lançamento da transferencia do fluxo em conta corrente
    Public Const INDMESTRNFLU_QUANDO_APROVACAO As Decimal = 0
    Public Const INDMESTRNFLU_MES_ATUAL As Decimal = 1
    Public Const INDMESTRNFLU_MES_ANTERIOR As Decimal = 2

    Public Const NUMSEQNIVAPV_PARA_GERAR_FLUXO_DA_CONTROLADORIA_QUANDO_MES_LANCAMENTO_FOR_DIFERENTE_DO_MES_DE_APROVACAO As Decimal = 301
    Public Const NUMSEQNIVAPV_PARA_OBTER_FUNCIONARIO_APROVADOR_DA_CONTROLADORIA_QUANDO_MES_LANCAMENTO_FOR_DIFERENTE_DO_MES_DE_APROVACAO As Decimal = 3

    'Cancelamento de Acordos Fornecedor
    Public Const CODSISINF_FLUXO_DE_CANCELAMENTO_DE_ACORDO As Decimal = 11

    Public Const CODSTAAPV_EM_APROVACAO As Decimal = 0
    Public Const CODSTAAPV_APROVADO As Decimal = 1
    Public Const CODSTAAPV_REJEITADO As Decimal = 2
    Public Const CODSTAAPV_NOVO As Decimal = 3

    Public Const TIPSTAFLUAPV_ESPERA_APROVAÇÃO_EM_FLUXO_CANCELAMENTO_ACORDO As String = "4"
    Public Const TIPSTAFLUAPV_EM_APROVAÇÃO_EM_FLUXO_CANCELAMENTO_ACORDO As String = "1"

    Public Const NUMSEQNIVAPV_PRIMEIRO_FLUXO_CONTROLADORIA As Decimal = 301

    'Recuperacao e prevencao de perdas
    Public Const CODEMP As Decimal = 1

    Public Const EMPENHO_FORNECEDOR_MARKETING As Decimal = 78

    Public Const TIPLMTHSTCFAARDFRN As Decimal = 3

End Class