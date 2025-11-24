Imports Martins.Data.TransactionManagement
Imports Martins.Data
Imports Martins.Security.Helper
Imports System.Data.OracleClient
Imports Martins.Compras.AcoesComerciais.AcordoFornecimento

Namespace DAL

    Public Class PrevisaoApuracaoDAL
        Inherits DALClass

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
                Dim DatasetPrevisaoApuracao As DatasetPrevisaoApuracao
                Dim data As IData
                Dim sql As String
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList

                DatasetPrevisaoApuracao = New DatasetPrevisaoApuracao

                'Desabilita a integridade referencial
                DatasetPrevisaoApuracao.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                If FILTRO = 0 Then
                    If CODDRT > 0 Then
                        sql = PrevisaoApuracaoDALSQL.GetSelectPrevisaoApuracaoPorDiretoria(data)
                    ElseIf CODDIV > 0 Then
                        sql = PrevisaoApuracaoDALSQL.GetSelectPrevisaoApuracaoPorCelula(data)
                    ElseIf CODCPR > 0 Then
                        sql = PrevisaoApuracaoDALSQL.GetSelectPrevisaoApuracaoPorComprador(data)
                    ElseIf CODFRN > 0 Then
                        sql = PrevisaoApuracaoDALSQL.GetSelectPrevisaoApuracaoPorFornecedor(data)
                    End If
                Else
                    If FILTRO = 1 Then
                        sql = PrevisaoApuracaoDALSQL.GetSelectPrevisaoApuracaoPorDiretoriaSintetico(data)
                    ElseIf FILTRO = 2 Then
                        sql = PrevisaoApuracaoDALSQL.GetSelectPrevisaoApuracaoPorCelulaSintetico(data)
                    ElseIf FILTRO = 3 Then
                        sql = PrevisaoApuracaoDALSQL.GetSelectPrevisaoApuracaoPorCompradorSintetico(data)
                    ElseIf FILTRO = 4 Then
                        sql = PrevisaoApuracaoDALSQL.GetSelectPrevisaoApuracaoPorFornecedorSintetico(data)
                    End If
                End If


                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo(parametrosCommand)

                data.FillDataSet(DatasetPrevisaoApuracao, _
                 sql, _
                 DatasetPrevisaoApuracao.PrevisaoApuracao.TableName, _
                  New IDataParameter() { _
                      data.CreateParameter("CODFRN1", DbType.Decimal, "CODFRN", CODFRN), _
                      data.CreateParameter("CODFRN2", DbType.Decimal, "CODFRN", CODFRN), _
                      data.CreateParameter("CODCPR1", DbType.Decimal, "CODCPR", CODCPR), _
                      data.CreateParameter("CODCPR2", DbType.Decimal, "CODCPR", CODCPR), _
                      data.CreateParameter("CODDIV1", DbType.Decimal, "CODDIV", CODDIV), _
                      data.CreateParameter("CODDIV2", DbType.Decimal, "CODDIV", CODDIV), _
                      data.CreateParameter("CODDRT1", DbType.Decimal, "CODDRT", CODDRT), _
                      data.CreateParameter("CODDRT2", DbType.Decimal, "CODDRT", CODDRT) _
                })

                Me.SetComplete()
                Return DatasetPrevisaoApuracao
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

    End Class

End Namespace

