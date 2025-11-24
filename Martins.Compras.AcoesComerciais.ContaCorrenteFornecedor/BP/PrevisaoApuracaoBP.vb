Imports Martins.Data.TransactionManagement
Imports Martins.Security.Helper
Imports Martins.Compras.AcoesComerciais.ContaCorrenteFornecedor.BLL
Imports Martins.Compras.AcoesComerciais.AcordoFornecimento

Namespace BP

    Public Class PrevisaoApuracaoBP
        Inherits BPClass

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Obtem os dados para o relatorio Previsao Apuração
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Rodrigo Gama]	10/09/2008	Created
        ''' </history>
        ''' ------------------------------------------------------------------------------
        Public Function ObterPrevisaoApuracao(ByVal FILTRO As Decimal, _
                                              ByVal CODFRN As Decimal, _
                                              ByVal CODCPR As Decimal, _
                                              ByVal CODDIV As Decimal, _
                                              ByVal CODDRT As Decimal) As DatasetPrevisaoApuracao
            Try
                Dim PrevisaoApuracao As PrevisaoApuracaoBLL
                PrevisaoApuracao = New PrevisaoApuracaoBLL

                Dim DatasetPrevisaoApuracao As DatasetPrevisaoApuracao
                DatasetPrevisaoApuracao = PrevisaoApuracao.ObterPrevisaoApuracao(FILTRO, CODFRN, CODCPR, CODDIV, CODDRT)

                Me.SetComplete()
                Return DatasetPrevisaoApuracao

            Catch ex As Martins.ExceptionManagement.BaseApplicationException

                Me.SetAbort()
                Throw ex

            Catch ex As Exception

                Me.SetAbort()
                Throw New Martins.ExceptionManagement.MartinsSystemException(ex.Message, ErrorConstants.SYSTEM_ERROR, ex)

            End Try
        End Function

    End Class

End Namespace
