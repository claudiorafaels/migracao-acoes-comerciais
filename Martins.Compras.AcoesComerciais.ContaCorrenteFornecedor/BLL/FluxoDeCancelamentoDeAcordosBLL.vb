Imports Martins.Data.TransactionManagement
Imports Martins.Security.Helper
Imports Martins.Compras.AcoesComerciais.ContaCorrenteFornecedor.DAL

Namespace BLL
    ''' -----------------------------------------------------------------------------
    ''' Project   : Martins.Compras.AcoesComerciais.ContaCorrenteFornecedor
    ''' Class     : FluxoDeCancelamentoDeAcordosBLL
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Regras de negócio da classe FluxoDeCancelamentoDeAcordos
    ''' </summary>
    ''' <remarks>
    '''
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    23/04/2008  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class FluxoDeCancelamentoDeAcordosBLL
        Inherits BLLClass

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade T0154038 com base na sua chave primária.
        ''' Descrição da entidade:FLUXO CANCELAMENTO ACORDO
        ''' </summary>
        ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
        ''' <param name="NUMPEDCNCACOCMC">NUMERO PEDIDO CANCELAMENTO ACORDO COMERCIAL.</param>
        ''' <returns>Retorna um DataSet com a tabela "T0154038" preenchida.</returns>
        ''' <remarks>
        ''' Sempre que um código inválido for informado, uma exception será retornada.
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    23/04/2008  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterFluxoCancelamentoAcordoPorChave(ByVal CODFRN As Decimal, _
                                                             ByVal NUMPEDCNCACOCMC As Decimal) As DatasetFluxoCancelamentoAcordo
            Try
                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosDAL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosDAL
                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterFluxoCancelamentoAcordoPorChave(CODFRN, NUMPEDCNCACOCMC)

                Me.SetComplete()
                Return DatasetFluxoCancelamentoAcordo

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade T0154038 com base na sua chave primária.
        ''' Descrição da entidade:FLUXO CANCELAMENTO ACORDO
        ''' </summary>
        ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
        ''' <param name="CODSTAAPV">CODIGO DO STATUS DO FLUXO.</param>
        ''' <param name="NUMPEDCNCACOCMC">NUMERO PEDIDO CANCELAMENTO ACORDO COMERCIAL.</param>
        ''' <param name="NUMREQCNCACOCMC">NUMERO REQUISICAO CANCELAMENTO ACORDO COMERCIAL.</param>
        ''' <returns>Retorna um DataSet com a tabela "T0154038" preenchida.</returns>
        ''' <remarks>
        ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
        ''' Um parametro do tipo número é omitido quando for zero,
        ''' Um parametro do tipo String é omitido quando for vazia,
        ''' Um parametro do tipo data   é omitido quando for Nothing,
        ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    23/04/2008  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterFluxoCancelamentoAcordoPorAtributos(ByVal CODFRN As Decimal, _
                                                                 ByVal CODSTAAPV As Decimal, _
                                                                 ByVal NUMPEDCNCACOCMC As Decimal, _
                                                                 ByVal NUMREQCNCACOCMC As Decimal) As DatasetFluxoCancelamentoAcordo
            Try
                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosDAL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosDAL
                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterFluxoCancelamentoAcordoPorAtributos(CODFRN, CODSTAAPV, NUMPEDCNCACOCMC, NUMREQCNCACOCMC)
                Me.SetComplete()
                Return DatasetFluxoCancelamentoAcordo

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Atualiza os dados no banco 
        ''' </summary>
        ''' <param name="DatasetFluxoCancelamentoAcordo">DataSet com os dados a serem atualizados</param>
        ''' <remarks>
        ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    23/04/2008  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Sub AtualizarFluxoCancelamentoAcordo(ByVal DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo)
            Try
                Dim chave As Double
                Dim FluxoDeCancelamentoDeAcordos As New FluxoDeCancelamentoDeAcordosDAL
                chave = -1

                'O loop abaixo trata os dados antes de enviá-los ao banco
                For Each linha As DatasetFluxoCancelamentoAcordo.T0154038Row In DatasetFluxoCancelamentoAcordo.T0154038
                    If (linha.RowState = System.Data.DataRowState.Added) Then
                        'Inserindo, buscar nova chave sequencial
                        'If (chave = -1) Then
                        '    chave = FluxoCancelamentoAcordo.ObterNovaChaveFluxoCancelamentoAcordo
                        '    If chave = 0 Then chave = 1
                        'Else
                        '    chave = chave + 1
                        'End If
                        'linha. = Convert.To(chave)
                        ValidarFluxoCancelamentoAcordo(linha)
                    ElseIf (linha.RowState = System.Data.DataRowState.Deleted) Then
                        'TODO: Remover registros que dependam desse
                    ElseIf (linha.RowState = System.Data.DataRowState.Modified) Then
                        'TODO: Tratar alguma regra para o update dos dados
                        ValidarFluxoCancelamentoAcordo(linha)
                    End If
                Next

                'Envia os dados à DAL para salvar em banco
                FluxoDeCancelamentoDeAcordos.AtualizarFluxoCancelamentoAcordo(DatasetFluxoCancelamentoAcordo)
                Me.SetComplete()

            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Sub

        Private Sub ValidarFluxoCancelamentoAcordo(ByRef linha As DatasetFluxoCancelamentoAcordo.T0154038Row)
            Try
                'Trata campos do tipo string, não permitido nulo, e com valor nulo
                If linha.RowState <> DataRowState.Deleted Then
                    'TODO: Linha comentada para implementação da tela de Cancelamento de Acordos - Danilo Rafael 07/05/2008
                    'If linha.IsNull("DESOBSCNCACOCMC") Then  Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|É obrigatório informar valor para DESCRICAO OBSERVACAO CANCELAMENTO ACORDO COMERCIAL" & "|","")
                    If linha.IsNull("NOMUSRSIS") Then Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|É obrigatório informar valor para NOME DO USUARIO DO SISTEMA" & "|", "")
                End If

                'Trata campos do tipo string e que não permite nulo com tamanho = 0
                If linha.RowState <> DataRowState.Deleted Then
                    'TODO: Linha comentada para implementação da tela de Cancelamento de Acordos - Danilo Rafael 07/05/2008
                    'If linha.DESOBSCNCACOCMC = "" Then Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|É obrigatório informar valor para DESCRICAO OBSERVACAO CANCELAMENTO ACORDO COMERCIAL" & "|", "")
                    If linha.NOMUSRSIS = "" Then Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|É obrigatório informar valor para NOME DO USUARIO DO SISTEMA" & "|", "")
                End If

                'Transforma os campos do tipo string em caixa alta
                If linha.RowState <> DataRowState.Deleted Then
                    If Not linha.IsNull("DESOBSCNCACOCMC") Then
                        linha.DESOBSCNCACOCMC = linha.DESOBSCNCACOCMC.ToUpper
                    End If
                    If Not linha.IsNull("NOMUSRSIS") Then
                        linha.NOMUSRSIS = linha.NOMUSRSIS.ToUpper
                    End If
                End If

                'Trata campos do tipo string com tamanho maior que o
                'tamanho do banco
                If linha.RowState <> DataRowState.Deleted Then
                End If

                Me.SetComplete()
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try

        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade T0154021 com base na sua chave primária.
        ''' Descrição da entidade:ACORDO A CANCELAR EM FLUXO CANCELAMENTO ACORDO
        ''' </summary>
        ''' <param name="CODEMP">CODIGO EMPRESA.</param>
        ''' <param name="CODFILEMP">CODIGO DA FILIAL DA EMPRESA.</param>
        ''' <param name="CODPMS">CODIGO PROMESSA.</param>
        ''' <param name="DATNGCPMS">DATA DA NEGOCIACAO DA PROMESSA.</param>
        ''' <param name="DATPRVRCBPMS">DATA DE PREVISAO DE RECEBIMENTO DA PROMESSA.</param>
        ''' <param name="NUMPEDCNCACOCMC">NUMERO PEDIDO CANCELAMENTO ACORDO COMERCIAL.</param>
        ''' <param name="TIPDSNDSCBNF">TIPO DESTINO / DESCONTO BONIFICADO.</param>
        ''' <param name="TIPFRMDSCBNF">TIPO FORMA DESCONTO BONIFICACAO.</param>
        ''' <returns>Retorna um DataSet com a tabela "T0154021" preenchida.</returns>
        ''' <remarks>
        ''' Sempre que um código inválido for informado, uma exception será retornada.
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    23/04/2008  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterAcordoACancelarEmFluxoCancelamentoAcordoPorChave(ByVal CODEMP As Decimal, _
                                                                              ByVal CODFILEMP As Decimal, _
                                                                              ByVal CODPMS As Decimal, _
                                                                              ByVal DATNGCPMS As Date, _
                                                                              ByVal DATPRVRCBPMS As Date, _
                                                                              ByVal NUMPEDCNCACOCMC As Decimal, _
                                                                              ByVal TIPDSNDSCBNF As Decimal, _
                                                                              ByVal TIPFRMDSCBNF As Decimal) As DatasetFluxoCancelamentoAcordo
            Try
                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosDAL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosDAL
                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterAcordoACancelarEmFluxoCancelamentoAcordoPorChave(CODEMP, CODFILEMP, CODPMS, DATNGCPMS, DATPRVRCBPMS, NUMPEDCNCACOCMC, TIPDSNDSCBNF, TIPFRMDSCBNF)

                Me.SetComplete()
                Return DatasetFluxoCancelamentoAcordo

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade T0154021 com base na sua chave primária.
        ''' Descrição da entidade:ACORDO A CANCELAR EM FLUXO CANCELAMENTO ACORDO
        ''' </summary>
        ''' <param name="CODEMP">CODIGO EMPRESA.</param>
        ''' <param name="CODFILEMP">CODIGO DA FILIAL DA EMPRESA.</param>
        ''' <param name="CODPMS">CODIGO PROMESSA.</param>
        ''' <param name="DATNGCPMS">DATA DA NEGOCIACAO DA PROMESSA.</param>
        ''' <param name="DATPRVRCBPMS">DATA DE PREVISAO DE RECEBIMENTO DA PROMESSA.</param>
        ''' <param name="NUMPEDCNCACOCMC">NUMERO PEDIDO CANCELAMENTO ACORDO COMERCIAL.</param>
        ''' <param name="TIPDSNDSCBNF">TIPO DESTINO / DESCONTO BONIFICADO.</param>
        ''' <param name="TIPFRMDSCBNF">TIPO FORMA DESCONTO BONIFICACAO.</param>
        ''' <returns>Retorna um DataSet com a tabela "T0154021" preenchida.</returns>
        ''' <remarks>
        ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
        ''' Um parametro do tipo número é omitido quando for zero,
        ''' Um parametro do tipo String é omitido quando for vazia,
        ''' Um parametro do tipo data   é omitido quando for Nothing,
        ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    23/04/2008  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterAcordoACancelarEmFluxoCancelamentoAcordoPorAtributos(ByVal CODEMP As Decimal, _
                                                                                  ByVal CODFILEMP As Decimal, _
                                                                                  ByVal CODPMS As Decimal, _
                                                                                  ByVal DATNGCPMS As Date, _
                                                                                  ByVal DATPRVRCBPMS As Date, _
                                                                                  ByVal NUMPEDCNCACOCMC As Decimal, _
                                                                                  ByVal TIPDSNDSCBNF As Decimal, _
                                                                                  ByVal TIPFRMDSCBNF As Decimal) As DatasetFluxoCancelamentoAcordo
            Try
                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosDAL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosDAL
                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterAcordoACancelarEmFluxoCancelamentoAcordoPorAtributos(CODEMP, CODFILEMP, CODPMS, DATNGCPMS, DATPRVRCBPMS, NUMPEDCNCACOCMC, TIPDSNDSCBNF, TIPFRMDSCBNF)
                Me.SetComplete()
                Return DatasetFluxoCancelamentoAcordo

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Atualiza os dados no banco 
        ''' </summary>
        ''' <param name="DatasetAcordoACancelarEmFluxoCancelamentoAcordo">DataSet com os dados a serem atualizados</param>
        ''' <remarks>
        ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    23/04/2008  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Sub AtualizarAcordoACancelarEmFluxoCancelamentoAcordo(ByVal DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo)
            Try
                Dim chave As Double
                Dim FluxoDeCancelamentoDeAcordos As New FluxoDeCancelamentoDeAcordosDAL
                chave = -1

                'O loop abaixo trata os dados antes de enviá-los ao banco
                For Each linha As DatasetFluxoCancelamentoAcordo.T0154021Row In DatasetFluxoCancelamentoAcordo.T0154021
                    If (linha.RowState = System.Data.DataRowState.Added) Then
                        'Inserindo, buscar nova chave sequencial
                        'If (chave = -1) Then
                        '    chave = AcordoACancelarEmFluxoCancelamentoAcordo.ObterNovaChaveAcordoACancelarEmFluxoCancelamentoAcordo
                        '    If chave = 0 Then chave = 1
                        'Else
                        '    chave = chave + 1
                        'End If
                        'linha. = Convert.To(chave)
                        ValidarAcordoACancelarEmFluxoCancelamentoAcordo(linha)
                    ElseIf (linha.RowState = System.Data.DataRowState.Deleted) Then
                        'TODO: Remover registros que dependam desse
                    ElseIf (linha.RowState = System.Data.DataRowState.Modified) Then
                        'TODO: Tratar alguma regra para o update dos dados
                        ValidarAcordoACancelarEmFluxoCancelamentoAcordo(linha)
                    End If
                Next

                'Envia os dados à DAL para salvar em banco
                FluxoDeCancelamentoDeAcordos.AtualizarAcordoACancelarEmFluxoCancelamentoAcordo(DatasetFluxoCancelamentoAcordo)
                Me.SetComplete()

            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Sub

        Private Sub ValidarAcordoACancelarEmFluxoCancelamentoAcordo(ByRef linha As DatasetFluxoCancelamentoAcordo.T0154021Row)
            Try
                'Trata campos do tipo string, não permitido nulo, e com valor nulo
                If linha.RowState <> DataRowState.Deleted Then
                End If

                'Trata campos do tipo string e que não permite nulo com tamanho = 0
                If linha.RowState <> DataRowState.Deleted Then
                End If

                'Transforma os campos do tipo string em caixa alta
                If linha.RowState <> DataRowState.Deleted Then
                End If

                'Trata campos do tipo string com tamanho maior que o
                'tamanho do banco
                If linha.RowState <> DataRowState.Deleted Then
                End If

                Me.SetComplete()
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try

        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="NUMFLUAPV"></param>
        ''' <param name="CODFNC"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Danilo]	4/24/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterMinhasAprovavoesEmFluxoDeCancelamentoDeAcordos(ByVal NUMPEDCNCACOCMC As Decimal, _
                                                                             ByVal CODFNC As Decimal) As DatasetFluxoCancelamentoAcordo
            Try
                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosDAL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosDAL
                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterMinhasAprovavoesEmFluxoDeCancelamentoDeAcordos(NUMPEDCNCACOCMC, CODFNC)

                Me.SetComplete()
                Return DatasetFluxoCancelamentoAcordo

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Danilo Rafael]	4/25/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterNovaChaveFluxoCancelamento() As Decimal
            Try
                Dim FluxoDeCancelamentoDeAcordos As New FluxoDeCancelamentoDeAcordosDAL
                Dim chave As Decimal = FluxoDeCancelamentoDeAcordos.ObterNovaChaveFluxoCancelamento
                Me.SetComplete()
                Return chave
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="CODFRN"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Danilo Rafael]	4/28/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterAcordosParaCancelamentoPorFornecedor(ByVal CODFRN As Decimal) As DatasetAcordoACancelarEmFluxoCancelamentoAcordo
            Try
                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosDAL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosDAL
                Dim DatasetAcordoACancelarEmFluxoCancelamentoAcordo As DatasetAcordoACancelarEmFluxoCancelamentoAcordo
                DatasetAcordoACancelarEmFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterAcordosParaCancelamentoPorFornecedor(CODFRN)

                Me.SetComplete()
                Return DatasetAcordoACancelarEmFluxoCancelamentoAcordo

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="NUMPEDCNCACOCMC"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Danilo Rafael]	5/6/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterAcordosParaCancelamentoPorNUMPEDCNCACOCMC(ByVal NUMPEDCNCACOCMC As Decimal) As DatasetAcordoACancelarEmFluxoCancelamentoAcordo
            Try
                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosDAL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosDAL
                Dim DatasetAcordoACancelarEmFluxoCancelamentoAcordo As DatasetAcordoACancelarEmFluxoCancelamentoAcordo
                DatasetAcordoACancelarEmFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterAcordosParaCancelamentoPorNUMPEDCNCACOCMC(NUMPEDCNCACOCMC)

                Me.SetComplete()
                Return DatasetAcordoACancelarEmFluxoCancelamentoAcordo

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="CODFRN"></param>
        ''' <param name="CODSTAAPV"></param>
        ''' <param name="NUMPEDCNCACOCMC"></param>
        ''' <param name="NUMREQCNCACOCMC"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Danilo Rafael]	14/5/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterFluxoCancelamentoAcordoPesquisa(ByVal CODFRN As Decimal, _
                                                             ByVal CODSTAAPV As Decimal, _
                                                             ByVal NUMPEDCNCACOCMC As Decimal, _
                                                             ByVal NUMREQCNCACOCMC As Decimal) As DatasetFluxoCancelamentoAcordo
            Try
                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosDAL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosDAL
                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterFluxoCancelamentoAcordoPesquisa(CODFRN, CODSTAAPV, NUMPEDCNCACOCMC, NUMREQCNCACOCMC)
                Me.SetComplete()
                Return DatasetFluxoCancelamentoAcordo

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="NUMPEDCNCACOCMC"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Danilo Rafael]	14/5/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterDiretorAprovadorDeFluxoFluxoDeCancelamentosDeAcordo(ByVal NUMPEDCNCACOCMC As Decimal) As DatasetFluxoCancelamentoAcordo
            Try
                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosDAL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosDAL
                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterDiretorAprovadorDeFluxoFluxoDeCancelamentosDeAcordo(NUMPEDCNCACOCMC)
                Me.SetComplete()
                Return DatasetFluxoCancelamentoAcordo
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="NUMPEDCNCACOCMC"></param>
        ''' <param name="CODFNC"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Danilo Rafael]	14/5/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterGerentesAprovadoresDeFluxoFluxoDeCancelamentosDeAcordo(ByVal NUMPEDCNCACOCMC As Decimal, ByVal CODFNC As Decimal) As DatasetFluxoCancelamentoAcordo
            Try
                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosDAL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosDAL
                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterGerentesAprovadoresDeFluxoFluxoDeCancelamentosDeAcordo(NUMPEDCNCACOCMC, CODFNC)
                Me.SetComplete()
                Return DatasetFluxoCancelamentoAcordo
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade T0161591 com base na sua chave primária.
        ''' Descrição da entidade:FLUXO DE APROVAÇÃO
        ''' </summary>
        ''' <param name="CODSISINF">CODIGO DO SISTEMA DE INFORMACAO.</param>
        ''' <param name="NUMFLUAPV">.</param>
        ''' <param name="NUMSEQFLUAPV">.</param>
        ''' <returns>Retorna um DataSet com a tabela "T0161591" preenchida.</returns>
        ''' <remarks>
        ''' Sempre que um código inválido for informado, uma exception será retornada.
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    06/12/2007  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterFluxoAprovacao(ByVal CODSISINF As Decimal, _
                                            ByVal NUMFLUAPV As Decimal, _
                                            ByVal NUMSEQFLUAPV As Decimal) As DatasetFluxoAprovacao
            Try
                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosDAL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosDAL
                Dim DatasetFluxoAprovacao As DatasetFluxoAprovacao
                DatasetFluxoAprovacao = FluxoDeCancelamentoDeAcordos.ObterFluxoAprovacao(CODSISINF, NUMFLUAPV, NUMSEQFLUAPV)

                Me.SetComplete()
                Return DatasetFluxoAprovacao

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade T0161591 com base na sua chave primária.
        ''' Descrição da entidade:FLUXO DE APROVAÇÃO
        ''' </summary>
        ''' <param name="CODEDEAPV">CODIGO ENTIDADE APROVOU.</param>
        ''' <param name="CODEDEARZ">CODIGO DA ENTIDADE AUTORIZADA.</param>
        ''' <param name="CODSISINF">CODIGO DO SISTEMA DE INFORMACAO.</param>
        ''' <param name="DATHRAAPVFLU">DATA E HORA DE APROVACAO DO FLUXO.</param>
        ''' <param name="DATHRAFLUAPV">DATA E HORA DO FLUXO DE APROVACAO.</param>
        ''' <param name="NUMFLUAPV">.</param>
        ''' <param name="NUMSEQFLUAPV">.</param>
        ''' <param name="NUMSEQFLUAPVPEDOPN">.</param>
        ''' <param name="NUMSEQNIVAPV">.</param>
        ''' <param name="TIPSTAFLUAPV">.</param>
        ''' <returns>Retorna um DataSet com a tabela "T0161591" preenchida.</returns>
        ''' <remarks>
        ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
        ''' Um parametro do tipo número é omitido quando for zero,
        ''' Um parametro do tipo String é omitido quando for vazia,
        ''' Um parametro do tipo data   é omitido quando for Nothing,
        ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    06/12/2007  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterFluxosAprovacao(ByVal CODEDEAPV As Decimal, _
                                             ByVal CODEDEARZ As Decimal, _
                                             ByVal CODSISINF As Decimal, _
                                             ByVal DATHRAAPVFLU As String, _
                                             ByVal DATHRAFLUAPV As String, _
                                             ByVal NUMFLUAPV As Decimal, _
                                             ByVal NUMSEQFLUAPV As Decimal, _
                                             ByVal NUMSEQFLUAPVPEDOPN As Decimal, _
                                             ByVal NUMSEQNIVAPV As Decimal, _
                                             ByVal TIPSTAFLUAPV As String) As DatasetFluxoAprovacao
            Try
                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosDAL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosDAL
                Dim DatasetFluxoAprovacao As DatasetFluxoAprovacao
                DatasetFluxoAprovacao = FluxoDeCancelamentoDeAcordos.ObterFluxosAprovacao(CODEDEAPV, CODEDEARZ, CODSISINF, DATHRAAPVFLU, DATHRAFLUAPV, NUMFLUAPV, NUMSEQFLUAPV, NUMSEQFLUAPVPEDOPN, NUMSEQNIVAPV, TIPSTAFLUAPV)
                Me.SetComplete()
                Return DatasetFluxoAprovacao

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Atualiza os dados no banco 
        ''' </summary>
        ''' <param name="DatasetFluxoAprovacao">DataSet com os dados a serem atualizados</param>
        ''' <remarks>
        ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    06/12/2007  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Sub AtualizarFluxoAprovacao(ByVal DatasetFluxoAprovacao As DatasetFluxoAprovacao)
            Try
                Dim chave As Double
                Dim FluxoDeCancelamentoDeAcordos As New FluxoDeCancelamentoDeAcordosDAL
                chave = -1

                'O loop abaixo trata os dados antes de enviá-los ao banco
                For Each linha As DatasetFluxoAprovacao.T0161591Row In DatasetFluxoAprovacao.T0161591
                    If (linha.RowState = System.Data.DataRowState.Added) Then
                        'Inserindo, buscar nova chave sequencial
                        'If (chave = -1) Then
                        '    chave = FluxoAprovacao.ObterNovaChaveFluxoAprovacao
                        '    If chave = 0 Then chave = 1
                        'Else
                        '    chave = chave + 1
                        'End If
                        'linha. = Convert.To(chave)
                        ValidarFluxoAprovacao(linha)
                    ElseIf (linha.RowState = System.Data.DataRowState.Deleted) Then
                        'TODO: Remover registros que dependam desse
                    ElseIf (linha.RowState = System.Data.DataRowState.Modified) Then
                        'TODO: Tratar alguma regra para o update dos dados
                        ValidarFluxoAprovacao(linha)
                    End If
                Next

                'Envia os dados à DAL para salvar em banco
                FluxoDeCancelamentoDeAcordos.AtualizarFluxoAprovacao(DatasetFluxoAprovacao)
                Me.SetComplete()

            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Sub

        Private Sub ValidarFluxoAprovacao(ByRef linha As DatasetFluxoAprovacao.T0161591Row)
            Try
                'Trata campos do tipo string, não permitido nulo, e com valor nulo
                If linha.RowState <> DataRowState.Deleted Then
                    If linha.IsNull("DESMTVAPVFLUACOCMC") Then linha.DESMTVAPVFLUACOCMC = " "
                    If linha.IsNull("DESOBSAPV") Then linha.DESOBSAPV = " "
                    If linha.IsNull("TIPSTAFLUAPV") Then linha.TIPSTAFLUAPV = " "
                End If

                'Transforma os campos do tipo string em caixa alta
                If linha.RowState <> DataRowState.Deleted Then
                    If Not linha.IsNull("DESMTVAPVFLUACOCMC") Then linha.DESMTVAPVFLUACOCMC = linha.DESMTVAPVFLUACOCMC.Trim().ToUpper()
                    If Not linha.IsNull("DESOBSAPV") Then linha.DESOBSAPV = linha.DESOBSAPV.Trim().ToUpper()
                    If Not linha.IsNull("TIPSTAFLUAPV") Then linha.TIPSTAFLUAPV = linha.TIPSTAFLUAPV.Trim().ToUpper()
                End If

                'Trata campos do tipo string e que não permite nulo
                'substituindo por espaço
                If linha.RowState <> DataRowState.Deleted Then
                    If linha.DESMTVAPVFLUACOCMC = "" Then linha.DESMTVAPVFLUACOCMC = " "
                    If linha.DESOBSAPV = "" Then linha.DESOBSAPV = " "
                    If linha.TIPSTAFLUAPV = "" Then linha.TIPSTAFLUAPV = " "
                End If

                Me.SetComplete()

            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try

        End Sub

        Public Sub GerarFluxoAprovacao(ByVal CODSISINF As Decimal, _
                                       ByVal NUMFLUAPV As Decimal, _
                                       ByVal NUMSEQFLUAPV As Decimal, _
                                       ByVal DATHRAFLUAPV As Date, _
                                       ByVal NUMSEQNIVAPV As Decimal, _
                                       ByVal CODEDEAPV As Decimal, _
                                       ByVal TIPSTAFLUAPV As String, _
                                       ByVal DATHRAAPVFLU As Date, _
                                       ByVal DESOBSAPV As String, _
                                       ByVal DESMTVAPVFLUACOCMC As String, _
                                       ByVal NUMSEQFLUAPVPEDOPN As Decimal, _
                                       ByVal CODEDEARZ As Decimal)
            Try
                Dim dsFluxoAprovacao As New DatasetFluxoAprovacao

                dsFluxoAprovacao.T0161591.AddT0161591Row(CODSISINF, _
                                                         NUMFLUAPV, _
                                                         NUMSEQFLUAPV, _
                                                         DATHRAFLUAPV, _
                                                         NUMSEQNIVAPV, _
                                                         CODEDEAPV, _
                                                         TIPSTAFLUAPV, _
                                                         DATHRAAPVFLU, _
                                                         DESOBSAPV, _
                                                         DESMTVAPVFLUACOCMC, _
                                                         NUMSEQFLUAPVPEDOPN, _
                                                         CODEDEARZ)
                Me.AtualizarFluxoAprovacao(dsFluxoAprovacao)
                Me.SetComplete()
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="NUMFLUAPV"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	6/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterDiretoresAprovadoresTransferenciaVerbas(ByVal NUMFLUAPV As Decimal) As DatasetFluxoAprovacao
            Try
                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosDAL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosDAL
                Dim DatasetFluxoAprovacao As DatasetFluxoAprovacao
                DatasetFluxoAprovacao = FluxoDeCancelamentoDeAcordos.ObterDiretoresAprovadoresTransferenciaVerbas(NUMFLUAPV)
                Me.SetComplete()
                Return DatasetFluxoAprovacao
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="NUMFLUAPV"></param>
        ''' <param name="CODDRTCMP"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	6/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterGerentesAprovadoresTransferenciaVerbas(ByVal NUMFLUAPV As Decimal, ByVal CODDRTCMP As Decimal) As DatasetFluxoAprovacao
            Try
                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosDAL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosDAL
                Dim DatasetFluxoAprovacao As DatasetFluxoAprovacao
                DatasetFluxoAprovacao = FluxoDeCancelamentoDeAcordos.ObterGerentesAprovadoresTransferenciaVerbas(NUMFLUAPV, CODDRTCMP)
                Me.SetComplete()
                Return DatasetFluxoAprovacao
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Danilo Rafael]	15/5/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterFuncionariosDaControladoriaAprovadoresDeFluxoDeCancelamentoDeAcordos() As DatasetFluxoCancelamentoAcordo
            Try
                Dim FluxoDeCancelamentoDeAcordos As New FluxoDeCancelamentoDeAcordosDAL
                Dim DatasetFluxoCancelamentoAcordo As New DatasetFluxoCancelamentoAcordo

                DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterFuncionariosDaControladoriaAprovadoresDeFluxoDeCancelamentoDeAcordos
                Me.SetComplete()
                Return DatasetFluxoCancelamentoAcordo
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="NUMPEDCNCACOCMC"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Danilo Rafael]	16/5/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterFluxosDeCancelamentoDeAcordos(ByVal NUMPEDCNCACOCMC As Decimal) As DatasetFluxoCancelamentoAcordo
            Try
                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosDAL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosDAL
                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterFluxosDeCancelamentoDeAcordos(NUMPEDCNCACOCMC)

                Me.SetComplete()
                Return DatasetFluxoCancelamentoAcordo

            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="NUMPEDCNCACOCMC"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Danilo Rafael]	19/5/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterAcordoComDuplicidadeEmOutroFluxo(ByVal NUMPEDCNCACOCMC As Decimal) As DatasetFluxoCancelamentoAcordo
            Try
                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosDAL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosDAL
                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterAcordoComDuplicidadeEmOutroFluxo(NUMPEDCNCACOCMC)

                Me.SetComplete()
                Return DatasetFluxoCancelamentoAcordo

            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function
    End Class
End Namespace