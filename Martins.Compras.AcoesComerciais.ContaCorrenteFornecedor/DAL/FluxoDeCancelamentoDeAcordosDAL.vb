Imports Martins.Data.TransactionManagement
Imports Martins.Data
Imports Martins.Security.Helper

Namespace DAL
    ''' -----------------------------------------------------------------------------
    ''' Project   : Martins.Compras.AcoesComerciais.AcordoFornecimento
    ''' Class     : FluxoDeCancelamentoDeAcordosDAL
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Classe DAL da entidade com objetivo: persistir os dados
    ''' </summary>
    ''' <remarks>
    '''
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    23/04/2008  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class FluxoDeCancelamentoDeAcordosDAL
        Inherits DALClass

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
                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                Dim data As IData
                Dim sql As String
                
                DatasetFluxoCancelamentoAcordo = New DatasetFluxoCancelamentoAcordo
                
                'Desabilita a integridade referencial
                DatasetFluxoCancelamentoAcordo.EnforceConstraints = False
                
                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)
                
                'Prepara o comando SQL e executa o acesso ao banco
                sql = FluxoDeCancelamentoDeAcordosDALSQL.GetSelectFluxoCancelamentoAcordo(data)
                data.FillDataSet(DatasetFluxoCancelamentoAcordo, _
                 sql, _
                 DatasetFluxoCancelamentoAcordo.T0154038.TableName, _
                 New IDataParameter() { _
                            data.CreateParameter("CODFRN",  DbType.decimal, "CODFRN", CODFRN), _
                            data.CreateParameter("NUMPEDCNCACOCMC",  DbType.decimal, "NUMPEDCNCACOCMC", NUMPEDCNCACOCMC) _
                      })


                Me.SetComplete()
                Return DatasetFluxoCancelamentoAcordo
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade T0154038 com base na em atributos que geralmente não compoem a chave primária (exceto em chaves compostas).
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
                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                Dim data As IData
                Dim sql As String
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList

                DatasetFluxoCancelamentoAcordo = New DatasetFluxoCancelamentoAcordo

                DatasetFluxoCancelamentoAcordo.EnforceConstraints = False

                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)
                sql = FluxoDeCancelamentoDeAcordosDALSQL.GetSelectFluxoCancelamentoAcordo(data, CODFRN, CODSTAAPV, NUMPEDCNCACOCMC, NUMREQCNCACOCMC)

                If CODFRN <> 0 Then
                    paramNome = data.CreateParameter("CODFRN", DbType.Decimal, "CODFRN", CODFRN)
                    If (Not IsNothing(paramNome)) Then parametros.Add (paramNome)
                End If
                If CODSTAAPV <> 0 Then
                    paramNome = data.CreateParameter("CODSTAAPV", DbType.Decimal, "CODSTAAPV", CODSTAAPV)
                    If (Not IsNothing(paramNome)) Then parametros.Add (paramNome)
                End If
                If NUMPEDCNCACOCMC <> 0 Then
                    paramNome = data.CreateParameter("NUMPEDCNCACOCMC", DbType.Decimal, "NUMPEDCNCACOCMC", NUMPEDCNCACOCMC)
                    If (Not IsNothing(paramNome)) Then parametros.Add (paramNome)
                End If
                If NUMREQCNCACOCMC <> 0 Then
                    paramNome = data.CreateParameter("NUMREQCNCACOCMC", DbType.Decimal, "NUMREQCNCACOCMC", NUMREQCNCACOCMC)
                    If (Not IsNothing(paramNome)) Then parametros.Add (paramNome)
                End If

                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo (parametrosCommand)

                data.FillDataSet(DatasetFluxoCancelamentoAcordo, _
                 sql, _
                 DatasetFluxoCancelamentoAcordo.T0154038.TableName, _
                 parametrosCommand)

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
                Dim data As IData
                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)

                Dim cb1 As CustomCommandBuilder
                cb1 = New CustomCommandBuilder(DatasetFluxoCancelamentoAcordo.T0154038, data, "MRT.T0154038") 
                data.UpdateFromDataSet(DatasetFluxoCancelamentoAcordo.T0154038, _
                 cb1.FastInsertCommand, _
                 cb1.FastUpdateCommand, _
                 cb1.FastDeleteCommand)

                Dim cb2 As CustomCommandBuilder
                cb2 = New CustomCommandBuilder(DatasetFluxoCancelamentoAcordo.T0154021, data, "MRT.T0154021")
                data.UpdateFromDataSet(DatasetFluxoCancelamentoAcordo.T0154021, _
                 cb2.FastInsertCommand, _
                 cb2.FastUpdateCommand, _
                 cb2.FastDeleteCommand)

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
                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                Dim data As IData
                Dim sql As String

                DatasetFluxoCancelamentoAcordo = New DatasetFluxoCancelamentoAcordo

                'Desabilita a integridade referencial
                DatasetFluxoCancelamentoAcordo.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = FluxoDeCancelamentoDeAcordosDALSQL.GetSelectAcordoACancelarEmFluxoCancelamentoAcordo(data)
                data.FillDataSet(DatasetFluxoCancelamentoAcordo, _
                 sql, _
                 DatasetFluxoCancelamentoAcordo.T0154021.TableName, _
                 New IDataParameter() { _
                            data.CreateParameter("CODEMP", DbType.Decimal, "CODEMP", CODEMP), _
                            data.CreateParameter("CODFILEMP", DbType.Decimal, "CODFILEMP", CODFILEMP), _
                            data.CreateParameter("CODPMS", DbType.Decimal, "CODPMS", CODPMS), _
                            data.CreateParameter("DATNGCPMS", DbType.Date, "DATNGCPMS", DATNGCPMS), _
                            data.CreateParameter("DATPRVRCBPMS", DbType.Date, "DATPRVRCBPMS", DATPRVRCBPMS), _
                            data.CreateParameter("NUMPEDCNCACOCMC", DbType.Decimal, "NUMPEDCNCACOCMC", NUMPEDCNCACOCMC), _
                            data.CreateParameter("TIPDSNDSCBNF", DbType.Decimal, "TIPDSNDSCBNF", TIPDSNDSCBNF), _
                            data.CreateParameter("TIPFRMDSCBNF", DbType.Decimal, "TIPFRMDSCBNF", TIPFRMDSCBNF) _
                      })


                Me.SetComplete()
                Return DatasetFluxoCancelamentoAcordo
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade T0154021 com base na em atributos que geralmente não compoem a chave primária (exceto em chaves compostas).
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
                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                Dim data As IData
                Dim sql As String
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList

                DatasetFluxoCancelamentoAcordo = New DatasetFluxoCancelamentoAcordo

                DatasetFluxoCancelamentoAcordo.EnforceConstraints = False

                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)
                sql = FluxoDeCancelamentoDeAcordosDALSQL.GetSelectAcordoACancelarEmFluxoCancelamentoAcordo(data, CODEMP, CODFILEMP, CODPMS, DATNGCPMS, DATPRVRCBPMS, NUMPEDCNCACOCMC, TIPDSNDSCBNF, TIPFRMDSCBNF)

                If CODEMP <> 0 Then
                    paramNome = data.CreateParameter("CODEMP", DbType.Decimal, "CODEMP", CODEMP)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODFILEMP <> 0 Then
                    paramNome = data.CreateParameter("CODFILEMP", DbType.Decimal, "CODFILEMP", CODFILEMP)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODPMS <> 0 Then
                    paramNome = data.CreateParameter("CODPMS", DbType.Decimal, "CODPMS", CODPMS)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If DATNGCPMS <> Nothing Then
                    paramNome = data.CreateParameter("DATNGCPMS", DbType.Date, "DATNGCPMS", DATNGCPMS)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If DATPRVRCBPMS <> Nothing Then
                    paramNome = data.CreateParameter("DATPRVRCBPMS", DbType.Date, "DATPRVRCBPMS", DATPRVRCBPMS)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If NUMPEDCNCACOCMC <> 0 Then
                    paramNome = data.CreateParameter("NUMPEDCNCACOCMC", DbType.Decimal, "NUMPEDCNCACOCMC", NUMPEDCNCACOCMC)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If TIPDSNDSCBNF <> 0 Then
                    paramNome = data.CreateParameter("TIPDSNDSCBNF", DbType.Decimal, "TIPDSNDSCBNF", TIPDSNDSCBNF)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If TIPFRMDSCBNF <> 0 Then
                    paramNome = data.CreateParameter("TIPFRMDSCBNF", DbType.Decimal, "TIPFRMDSCBNF", TIPFRMDSCBNF)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo(parametrosCommand)

                data.FillDataSet(DatasetFluxoCancelamentoAcordo, _
                 sql, _
                 DatasetFluxoCancelamentoAcordo.T0154021.TableName, _
                 parametrosCommand)

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
                Dim data As IData
                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)

                Dim cb1 As CustomCommandBuilder
                cb1 = New CustomCommandBuilder(DatasetFluxoCancelamentoAcordo.T0154021, data, "MRT.T0154021")
                data.UpdateFromDataSet(DatasetFluxoCancelamentoAcordo.T0154021, _
                 cb1.FastInsertCommand, _
                 cb1.FastUpdateCommand, _
                 cb1.FastDeleteCommand)

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
                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                Dim data As IData
                Dim sql As String
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList

                DatasetFluxoCancelamentoAcordo = New DatasetFluxoCancelamentoAcordo

                DatasetFluxoCancelamentoAcordo.EnforceConstraints = False

                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)
                sql = FluxoDeCancelamentoDeAcordosDALSQL.GetSelectMinhasAprovavoesEmFluxoDeCancelamentoDeAcordos(data, NUMPEDCNCACOCMC, CODFNC)

                'CODEDEAPV1
                paramNome = data.CreateParameter("CODEDEAPV1", DbType.Decimal, "CODEDEAPV", CODFNC)
                If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)

                'CODEDEAPV2
                paramNome = data.CreateParameter("CODEDEAPV2", DbType.Decimal, "CODEDEAPV", CODFNC)
                If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)

                'NUMPEDCNCACOCMC
                If NUMPEDCNCACOCMC <> 0 Then
                    paramNome = data.CreateParameter("NUMPEDCNCACOCMC", DbType.Decimal, "NUMPEDCNCACOCMC", NUMPEDCNCACOCMC)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo(parametrosCommand)

                data.FillDataSet(DatasetFluxoCancelamentoAcordo, _
                                 sql, _
                                 DatasetFluxoCancelamentoAcordo.T0154038Pesquisa.TableName, _
                                 parametrosCommand)

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
                Dim result As Decimal
                result = Convert.ToDecimal(Me.transactionContext(Constants.CONEXAO_PRINCIPAL).GetNextPrimaryKey("MRT.T0154038", "NUMPEDCNCACOCMC"))
                Me.SetComplete()
                Return result
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
        ''' 	[Danilo Rafael]	13/8/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterAcordosParaCancelamentoPorFornecedor(ByVal CODFRN As Decimal) As DatasetAcordoACancelarEmFluxoCancelamentoAcordo
            Try
                Dim DatasetAcordoACancelarEmFluxoCancelamentoAcordo As DatasetAcordoACancelarEmFluxoCancelamentoAcordo
                Dim data As IData
                Dim sql As String
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList

                DatasetAcordoACancelarEmFluxoCancelamentoAcordo = New DatasetAcordoACancelarEmFluxoCancelamentoAcordo

                DatasetAcordoACancelarEmFluxoCancelamentoAcordo.EnforceConstraints = False

                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)
                sql = FluxoDeCancelamentoDeAcordosDALSQL.GetSelectAcordosParaCancelamentoPorFornecedor(data, CODFRN)

                'CODFRN1
                paramNome = data.CreateParameter("CODFRN1", DbType.Decimal, "CODFRN", CODFRN)
                If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)

                'CODFRN2
                paramNome = data.CreateParameter("CODFRN2", DbType.Decimal, "CODFRN", CODFRN)
                If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)

                'CODFRN3
                paramNome = data.CreateParameter("CODFRN3", DbType.Decimal, "CODFRN", CODFRN)
                If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)

                'CODFRN4
                paramNome = data.CreateParameter("CODFRN4", DbType.Decimal, "CODFRN", CODFRN)
                If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)

                'CODFRN5
                paramNome = data.CreateParameter("CODFRN5", DbType.Decimal, "CODFRN", CODFRN)
                If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)

                'CODFRN6
                paramNome = data.CreateParameter("CODFRN6", DbType.Decimal, "CODFRN", CODFRN)
                If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)

                'CODFRN7
                paramNome = data.CreateParameter("CODFRN7", DbType.Decimal, "CODFRN", CODFRN)
                If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)

                'CODFRN8
                paramNome = data.CreateParameter("CODFRN8", DbType.Decimal, "CODFRN", CODFRN)
                If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)

                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo(parametrosCommand)

                data.FillDataSet(DatasetAcordoACancelarEmFluxoCancelamentoAcordo, _
                                 sql, _
                                 DatasetAcordoACancelarEmFluxoCancelamentoAcordo.T0118066Pesquisa.TableName, _
                                 parametrosCommand)

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
        ''' 	[Danilo Rafael]	14/5/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterAcordosParaCancelamentoPorNUMPEDCNCACOCMC(ByVal NUMPEDCNCACOCMC As Decimal) As DatasetAcordoACancelarEmFluxoCancelamentoAcordo
            Try
                Dim DatasetAcordoACancelarEmFluxoCancelamentoAcordo As DatasetAcordoACancelarEmFluxoCancelamentoAcordo
                Dim data As IData
                Dim sql As String
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList

                DatasetAcordoACancelarEmFluxoCancelamentoAcordo = New DatasetAcordoACancelarEmFluxoCancelamentoAcordo

                DatasetAcordoACancelarEmFluxoCancelamentoAcordo.EnforceConstraints = False

                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)
                sql = FluxoDeCancelamentoDeAcordosDALSQL.GetSelectAcordosParaCancelamentoPorNUMPEDCNCACOCMC(data, NUMPEDCNCACOCMC)

                'CODFRN1
                paramNome = data.CreateParameter("NUMPEDCNCACOCMC", DbType.Decimal, "NUMPEDCNCACOCMC", NUMPEDCNCACOCMC)
                If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)

                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo(parametrosCommand)

                data.FillDataSet(DatasetAcordoACancelarEmFluxoCancelamentoAcordo, _
                                 sql, _
                                 DatasetAcordoACancelarEmFluxoCancelamentoAcordo.T0118066Pesquisa.TableName, _
                                 parametrosCommand)

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
                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                Dim data As IData
                Dim sql As String
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList

                DatasetFluxoCancelamentoAcordo = New DatasetFluxoCancelamentoAcordo

                DatasetFluxoCancelamentoAcordo.EnforceConstraints = False

                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)
                sql = FluxoDeCancelamentoDeAcordosDALSQL.GetSelectObterFluxoCancelamentoAcordoPesquisa(data, NUMPEDCNCACOCMC, CODSTAAPV)

                If NUMPEDCNCACOCMC <> 0 Then
                    paramNome = data.CreateParameter("NUMPEDCNCACOCMC", DbType.Decimal, "NUMPEDCNCACOCMC", NUMPEDCNCACOCMC)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                If CODSTAAPV <> 5 Then
                    paramNome = data.CreateParameter("CODSTAAPV", DbType.Decimal, "CODSTAAPV", CODSTAAPV)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo(parametrosCommand)

                data.FillDataSet(DatasetFluxoCancelamentoAcordo, _
                 sql, _
                 DatasetFluxoCancelamentoAcordo.T0154038Pesquisa.TableName, _
                 parametrosCommand)

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
                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                Dim data As IData
                Dim sql As String

                DatasetFluxoCancelamentoAcordo = New DatasetFluxoCancelamentoAcordo

                'Desabilita a integridade referencial
                DatasetFluxoCancelamentoAcordo.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = FluxoDeCancelamentoDeAcordosDALSQL.GetDiretorAprovadorDeFluxoFluxoDeCancelamentosDeAcordo(data)
                data.FillDataSet(DatasetFluxoCancelamentoAcordo, _
                 sql, _
                 DatasetFluxoCancelamentoAcordo.Funcionario.TableName, _
                 New IDataParameter() { _
                            data.CreateParameter("NUMPEDCNCACOCMC", DbType.Decimal, "NUMPEDCNCACOCMC", NUMPEDCNCACOCMC) _
                      })

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
                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                Dim data As IData
                Dim sql As String

                DatasetFluxoCancelamentoAcordo = New DatasetFluxoCancelamentoAcordo

                'Desabilita a integridade referencial
                DatasetFluxoCancelamentoAcordo.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = FluxoDeCancelamentoDeAcordosDALSQL.GetGerentesAprovadoresDeFluxoFluxoDeCancelamentosDeAcordo(data)
                data.FillDataSet(DatasetFluxoCancelamentoAcordo, _
                 sql, _
                 DatasetFluxoCancelamentoAcordo.Funcionario.TableName, _
                 New IDataParameter() { _
                            data.CreateParameter("NUMPEDCNCACOCMC", DbType.Decimal, "NUMPEDCNCACOCMC", NUMPEDCNCACOCMC), _
                            data.CreateParameter("CODFNC", DbType.Decimal, "CODFNC", CODFNC) _
                      })

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
                Dim DatasetFluxoAprovacao As DatasetFluxoAprovacao
                Dim data As IData
                Dim sql As String

                DatasetFluxoAprovacao = New DatasetFluxoAprovacao

                'Desabilita a integridade referencial
                DatasetFluxoAprovacao.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = FluxoDeCancelamentoDeAcordosDALSQL.GetSelectFluxoAprovacao(data)
                data.FillDataSet(DatasetFluxoAprovacao, _
                 sql, _
                 DatasetFluxoAprovacao.T0161591.TableName, _
                 New IDataParameter() { _
                            data.CreateParameter("CODSISINF", DbType.Decimal, "CODSISINF", CODSISINF), _
                            data.CreateParameter("NUMFLUAPV", DbType.Decimal, "NUMFLUAPV", NUMFLUAPV), _
                            data.CreateParameter("NUMSEQFLUAPV", DbType.Decimal, "NUMSEQFLUAPV", NUMSEQFLUAPV) _
                      })


                Me.SetComplete()
                Return DatasetFluxoAprovacao
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade T0161591 com base na em atributos que geralmente não compoem a chave primária (exceto em chaves compostas).
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
                Dim DatasetFluxoAprovacao As DatasetFluxoAprovacao
                Dim data As IData
                Dim sql As String
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList

                DatasetFluxoAprovacao = New DatasetFluxoAprovacao

                DatasetFluxoAprovacao.EnforceConstraints = False

                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)
                sql = FluxoDeCancelamentoDeAcordosDALSQL.GetSelectFluxoAprovacao(data, CODEDEAPV, CODEDEARZ, CODSISINF, DATHRAAPVFLU, DATHRAFLUAPV, NUMFLUAPV, NUMSEQFLUAPV, NUMSEQFLUAPVPEDOPN, NUMSEQNIVAPV, TIPSTAFLUAPV)

                If CODEDEAPV <> 0 Then
                    'Parametro 1
                    paramNome = data.CreateParameter("CODEDEAPV1", DbType.Decimal, "CODEDEAPV", CODEDEAPV)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                    'Parametro 2
                    paramNome = data.CreateParameter("CODEDEAPV2", DbType.Decimal, "CODEDEAPV", CODEDEAPV)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODEDEARZ <> 0 Then
                    paramNome = data.CreateParameter("CODEDEARZ", DbType.Decimal, "CODEDEARZ", CODEDEARZ)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODSISINF <> 0 Then
                    paramNome = data.CreateParameter("CODSISINF", DbType.Decimal, "CODSISINF", CODSISINF)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If DATHRAAPVFLU.Trim() <> "" Then
                    paramNome = data.CreateParameter("DATHRAAPVFLU", DbType.String, "DATHRAAPVFLU", "%" + DATHRAAPVFLU.ToUpper() + "%")
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If DATHRAFLUAPV.Trim() <> "" Then
                    paramNome = data.CreateParameter("DATHRAFLUAPV", DbType.String, "DATHRAFLUAPV", "%" + DATHRAFLUAPV.ToUpper() + "%")
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If NUMFLUAPV <> 0 Then
                    paramNome = data.CreateParameter("NUMFLUAPV", DbType.Decimal, "NUMFLUAPV", NUMFLUAPV)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If NUMSEQFLUAPV <> 0 Then
                    paramNome = data.CreateParameter("NUMSEQFLUAPV", DbType.Decimal, "NUMSEQFLUAPV", NUMSEQFLUAPV)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If NUMSEQFLUAPVPEDOPN <> 0 Then
                    paramNome = data.CreateParameter("NUMSEQFLUAPVPEDOPN", DbType.Decimal, "NUMSEQFLUAPVPEDOPN", NUMSEQFLUAPVPEDOPN)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If NUMSEQNIVAPV <> 0 Then
                    paramNome = data.CreateParameter("NUMSEQNIVAPV", DbType.Decimal, "NUMSEQNIVAPV", NUMSEQNIVAPV)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If TIPSTAFLUAPV.Trim() <> "" Then
                    paramNome = data.CreateParameter("TIPSTAFLUAPV", DbType.String, "TIPSTAFLUAPV", TIPSTAFLUAPV.ToUpper())
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo(parametrosCommand)

                data.FillDataSet(DatasetFluxoAprovacao, _
                 sql, _
                 DatasetFluxoAprovacao.T0161591.TableName, _
                 parametrosCommand)

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
                Dim data As IData
                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)

                Dim cb1 As CustomCommandBuilder
                cb1 = New CustomCommandBuilder(DatasetFluxoAprovacao.T0161591, data, "MRT.T0161591")
                data.UpdateFromDataSet(DatasetFluxoAprovacao.T0161591, _
                 cb1.FastInsertCommand, _
                 cb1.FastUpdateCommand, _
                 cb1.FastDeleteCommand)

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
                Dim DatasetFluxoAprovacao As DatasetFluxoAprovacao
                Dim data As IData
                Dim sql As String

                DatasetFluxoAprovacao = New DatasetFluxoAprovacao

                'Desabilita a integridade referencial
                DatasetFluxoAprovacao.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = FluxoDeCancelamentoDeAcordosDALSQL.GetDiretoresAprovadoresTransferenciaVerbas(data)
                data.FillDataSet(DatasetFluxoAprovacao, _
                 sql, _
                 DatasetFluxoAprovacao.Funcionario.TableName, _
                 New IDataParameter() { _
                            data.CreateParameter("NUMFLUAPV", DbType.Decimal, "NUMFLUAPV", NUMFLUAPV) _
                      })

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
                Dim DatasetFluxoAprovacao As DatasetFluxoAprovacao
                Dim data As IData
                Dim sql As String

                DatasetFluxoAprovacao = New DatasetFluxoAprovacao

                'Desabilita a integridade referencial
                DatasetFluxoAprovacao.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = FluxoDeCancelamentoDeAcordosDALSQL.GetGerentesAprovadoresTransferenciaVerbas(data)
                data.FillDataSet(DatasetFluxoAprovacao, _
                 sql, _
                 DatasetFluxoAprovacao.Funcionario.TableName, _
                 New IDataParameter() { _
                            data.CreateParameter("NUMFLUAPV", DbType.Decimal, "NUMFLUAPV", NUMFLUAPV), _
                            data.CreateParameter("CODFNC", DbType.Decimal, "CODFNC", CODDRTCMP) _
                      })

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
                Dim data As IData
                Dim sql As String
                Dim retorno As Integer
                Dim DatasetFluxoCancelamentoAcordo As New DatasetFluxoCancelamentoAcordo

                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)
                sql = FluxoDeCancelamentoDeAcordosDALSQL.GetSelectObterFuncionariosDaControladoriaAprovadoresDeFluxoDeCancelamentoDeAcordos(data)

                data.FillDataSet(DatasetFluxoCancelamentoAcordo, _
                                 sql, _
                                 DatasetFluxoCancelamentoAcordo.FuncionariosControladoria.TableName, _
                                 New IDataParameter() { _
                                            data.CreateParameter("CODSISINF", DbType.Decimal, "CODSISINF", Constants.CODSISINF_FLUXO_DE_CANCELAMENTO_DE_ACORDO) _
                                      })

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
                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                Dim data As IData
                Dim sql As String

                DatasetFluxoCancelamentoAcordo = New DatasetFluxoCancelamentoAcordo

                'Desabilita a integridade referencial
                DatasetFluxoCancelamentoAcordo.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = FluxoDeCancelamentoDeAcordosDALSQL.GetSelectFluxosDeCancelamentoDeAcordos(data)

                data.FillDataSet(DatasetFluxoCancelamentoAcordo, _
                                 sql, _
                                 DatasetFluxoCancelamentoAcordo.queryFluxos.TableName, _
                                 New IDataParameter() {data.CreateParameter("NUMPEDCNCACOCMC", DbType.Decimal, "NUMPEDCNCACOCMC", NUMPEDCNCACOCMC)})

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
                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                Dim data As IData
                Dim sql As String

                DatasetFluxoCancelamentoAcordo = New DatasetFluxoCancelamentoAcordo

                'Desabilita a integridade referencial
                DatasetFluxoCancelamentoAcordo.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = FluxoDeCancelamentoDeAcordosDALSQL.GetSelectObterAcordoComDuplicidadeEmOutroFluxo(data)

                data.FillDataSet(DatasetFluxoCancelamentoAcordo, _
                                 sql, _
                                 DatasetFluxoCancelamentoAcordo.T0154021ComDuplicidadeEmOutroFluxo.TableName, _
                                 New IDataParameter() {data.CreateParameter("NUMPEDCNCACOCMC", DbType.Decimal, "NUMPEDCNCACOCMC", NUMPEDCNCACOCMC)})

                Me.SetComplete()
                Return DatasetFluxoCancelamentoAcordo
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function
    End Class
End Namespace