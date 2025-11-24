Imports Martins.Data.TransactionManagement
Imports Martins.Data
Imports Martins.Security.Helper
Imports System.Data.OracleClient
Imports Martins.Compras.AcoesComerciais.AcordoFornecimento

Namespace DAL

    Public Class RecuperacaoEPrevencaoPerdasDAL
        Inherits DALClass

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Obtem os dados para o relatorio Recuperacao e Prevencao de Perdas.
        ''' </summary>
        ''' <param name="NUMCTTFRN">Numero do Contrato do Fornecedor</param>
        ''' <param name="INDDVRVLRAPUARDFRN">Define se apresenta todas as linhas ou apenas divergencias </param>
        ''' 1 - apresenta somente divergencias
        ''' 0 - apresenta todas as linhas
        ''' <param name="TIPLMTHSTCFAARDFRN">Define se apresenta informacoes da Devolucao 99</param>
        ''' 1 - Apresenta apuracao sem devolucao 99
        ''' 2 - Apresenta apuracao com devolucao 99
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Rodrigo Gama]	27/8/2008	Created
        ''' </history>
        Public Function ObterRecuperacaoEPrevencaoPerdasSintetico(ByVal NUMCTTFRN As Decimal, _
                                                                  ByVal INDDVRVLRAPUARDFRN As Decimal, _
                                                                  ByVal TIPLMTHSTCFAARDFRN As Decimal) As DatasetRecuperacaoEPrevencaoPerdas
            Try
                Dim DatasetRecuperacaoEPrevencaoPerdas As DatasetRecuperacaoEPrevencaoPerdas
                Dim data As IData
                Dim sql As String
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList

                DatasetRecuperacaoEPrevencaoPerdas = New DatasetRecuperacaoEPrevencaoPerdas

                'Desabilita a integridade referencial
                DatasetRecuperacaoEPrevencaoPerdas.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = RecuperacaoEPrevencaoPerdasDALSQL.GetSelectRecuperacaoEPrevencaoPerdasSintetico(data, INDDVRVLRAPUARDFRN)

                If NUMCTTFRN <> 0 Then
                    paramNome = data.CreateParameter("NUMCTTFRN1", DbType.Decimal, "NUMCTTFRN", NUMCTTFRN)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                    paramNome = data.CreateParameter("NUMCTTFRN2", DbType.Decimal, "NUMCTTFRN", NUMCTTFRN)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                If INDDVRVLRAPUARDFRN > 0 Then
                    paramNome = data.CreateParameter("INDDVRVLRAPUARDFRN1", DbType.Decimal, "INDDVRVLRAPUARDFRN", INDDVRVLRAPUARDFRN)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                    paramNome = data.CreateParameter("INDDVRVLRAPUARDFRN2", DbType.Decimal, "INDDVRVLRAPUARDFRN", INDDVRVLRAPUARDFRN)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                paramNome = data.CreateParameter("TIPLMTHSTCFAARDFRN", DbType.Decimal, "TIPLMTHSTCFAARDFRN", TIPLMTHSTCFAARDFRN)
                If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)

                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo(parametrosCommand)

                data.FillDataSet(DatasetRecuperacaoEPrevencaoPerdas, _
                 sql, _
                 DatasetRecuperacaoEPrevencaoPerdas.Sintetico.TableName, _
                 parametrosCommand)

                Me.SetComplete()
                Return DatasetRecuperacaoEPrevencaoPerdas
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function


        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Obtem os dados para o relatorio Recuperacao e Prevencao de Perdas.
        ''' </summary>
        ''' <param name="NUMCTTFRN">Numero do Contrato do Fornecedor</param>
        ''' <param name="INDDVRVLRAPUARDFRN">Define se apresenta todas as linhas ou apenas divergencias </param>
        ''' 1 - apresenta somente divergencias
        ''' 0 - apresenta todas as linhas
        ''' <param name="TIPLMTHSTCFAARDFRN">Define se apresenta informacoes da Devolucao 99</param>
        ''' 1 - Apresenta apuracao sem devolucao 99
        ''' 2 - Apresenta apuracao com devolucao 99
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Rodrigo Gama]	27/8/2008	Created
        ''' </history>
        Public Function ObterRecuperacaoEPrevencaoPerdasAnalitico(ByVal NUMCTTFRN As Decimal, _
                                                                  ByVal INDDVRVLRAPUARDFRN As Decimal, _
                                                                  ByVal TIPLMTHSTCFAARDFRN As Decimal, _
                                                                  ByVal DATREFAPU As Date, _
                                                                  ByVal NUMCSLCTTFRN As Decimal) As DatasetRecuperacaoEPrevencaoPerdas
            Try
                Dim DatasetRecuperacaoEPrevencaoPerdas As DatasetRecuperacaoEPrevencaoPerdas
                Dim data As IData
                Dim sql As String
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList

                DatasetRecuperacaoEPrevencaoPerdas = New DatasetRecuperacaoEPrevencaoPerdas

                'Desabilita a integridade referencial
                DatasetRecuperacaoEPrevencaoPerdas.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = RecuperacaoEPrevencaoPerdasDALSQL.GetSelectRecuperacaoEPrevencaoPerdasAnalitico(data, INDDVRVLRAPUARDFRN, DATREFAPU, NUMCSLCTTFRN)

                If NUMCTTFRN <> 0 Then
                    paramNome = data.CreateParameter("NUMCTTFRN1", DbType.Decimal, "NUMCTTFRN", NUMCTTFRN)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                    paramNome = data.CreateParameter("NUMCTTFRN2", DbType.Decimal, "NUMCTTFRN", NUMCTTFRN)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                If INDDVRVLRAPUARDFRN > 0 Then
                    paramNome = data.CreateParameter("INDDVRVLRAPUARDFRN1", DbType.Decimal, "INDDVRVLRAPUARDFRN", INDDVRVLRAPUARDFRN)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                    paramNome = data.CreateParameter("INDDVRVLRAPUARDFRN2", DbType.Decimal, "INDDVRVLRAPUARDFRN", INDDVRVLRAPUARDFRN)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                paramNome = data.CreateParameter("TIPLMTHSTCFAARDFRN", DbType.Decimal, "TIPLMTHSTCFAARDFRN", TIPLMTHSTCFAARDFRN)
                If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)

                If Not DATREFAPU = Nothing Then
                    paramNome = data.CreateParameter("DATREFAPU1", DbType.Decimal, "DATREFAPU", DATREFAPU)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                    paramNome = data.CreateParameter("DATREFAPU2", DbType.Decimal, "DATREFAPU", DATREFAPU)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If NUMCSLCTTFRN <> 0 Then
                    paramNome = data.CreateParameter("NUMCSLCTTFRN1", DbType.Decimal, "NUMCSLCTTFRN", NUMCSLCTTFRN)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                    paramNome = data.CreateParameter("NUMCSLCTTFRN2", DbType.Decimal, "NUMCSLCTTFRN", NUMCSLCTTFRN)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo(parametrosCommand)

                data.FillDataSet(DatasetRecuperacaoEPrevencaoPerdas, _
                 sql, _
                 DatasetRecuperacaoEPrevencaoPerdas.Analitico.TableName, _
                 parametrosCommand)

                Me.SetComplete()
                Return DatasetRecuperacaoEPrevencaoPerdas
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Obtem os dados para o relatorio Notas Periodo, caso a opção apresentar Devolução99
        ''' seja selecionada no menu Relatório "Recuperação e Prevenção de Perdas"
        ''' </summary>
        ''' <param name="NUMCTTFRN">Numero do Contrato do Fornecedor</param>
        ''' <param name="CODFRN">Código do Fornecedor </param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Rodrigo Gama]	16/9/2008	Created
        ''' </history>
        '''---------------------------------------------------------------------------------------
        Public Function ObterNotasPeriodo(ByVal NUMCTTFRN As Decimal, ByVal CODFRN As Decimal) As DatasetRecuperacaoEPrevencaoPerdas
            Try
                Dim DatasetRecuperacaoEPrevencaoPerdas As DatasetRecuperacaoEPrevencaoPerdas
                Dim data As IData
                Dim sql As String

                DatasetRecuperacaoEPrevencaoPerdas = New DatasetRecuperacaoEPrevencaoPerdas

                'Desabilita a integridade referencial
                DatasetRecuperacaoEPrevencaoPerdas.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = RecuperacaoEPrevencaoPerdasDALSQL.GetSelectNotasPeriodo(data)

                data.FillDataSet(DatasetRecuperacaoEPrevencaoPerdas, _
                 sql, _
                 DatasetRecuperacaoEPrevencaoPerdas.NotasPeriodo.TableName, _
                 New IDataParameter() { _
                            data.CreateParameter("NUMCTTFRN", DbType.Decimal, "NUMCTTFRN", NUMCTTFRN), _
                            data.CreateParameter("CODFRN", DbType.Decimal, "CODFRN", CODFRN) _
                      })
                Me.SetComplete()

                Me.SetComplete()
                Return DatasetRecuperacaoEPrevencaoPerdas
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Obtem as clausulas do contrato selecionado como filtro para
        ''' o relatorio Recuperacao e Prevencao de Perdas.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Rodrigo Gama]	28/8/2008	Created
        ''' </history>
        Public Function ObterRecuperacaoEPrevencaoPerdasClausulas(ByVal NUMCTTFRN As Decimal) As DatasetRecuperacaoEPrevencaoPerdas
            Try
                Dim DatasetRecuperacaoEPrevencaoPerdas As DatasetRecuperacaoEPrevencaoPerdas
                Dim data As IData
                Dim sql As String

                DatasetRecuperacaoEPrevencaoPerdas = New DatasetRecuperacaoEPrevencaoPerdas

                'Desabilita a integridade referencial
                DatasetRecuperacaoEPrevencaoPerdas.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = RecuperacaoEPrevencaoPerdasDALSQL.GetSelectRecuperacaoEPrevencaoPerdasClausulas(data)

                data.FillDataSet(DatasetRecuperacaoEPrevencaoPerdas, _
                 sql, _
                 DatasetRecuperacaoEPrevencaoPerdas.Clausulas.TableName, _
                 New IDataParameter() { _
                            data.CreateParameter("NUMCTTFRN", DbType.Decimal, "NUMCTTFRN", NUMCTTFRN) _
                      })
                Me.SetComplete()

                Me.SetComplete()
                Return DatasetRecuperacaoEPrevencaoPerdas
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function


        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Obtem as Datas de referencia de apuracao do contrato selecionado como filtro para
        ''' o relatorio Recuperacao e Prevencao de Perdas.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Rodrigo Gama]	28/8/2008	Created
        ''' </history>
        Public Function ObterRecuperacaoEPrevencaoPerdasDataApuracao(ByVal NUMCTTFRN As Decimal) As DatasetRecuperacaoEPrevencaoPerdas
            Try
                Dim DatasetRecuperacaoEPrevencaoPerdas As DatasetRecuperacaoEPrevencaoPerdas
                Dim data As IData
                Dim sql As String

                DatasetRecuperacaoEPrevencaoPerdas = New DatasetRecuperacaoEPrevencaoPerdas

                'Desabilita a integridade referencial
                DatasetRecuperacaoEPrevencaoPerdas.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = RecuperacaoEPrevencaoPerdasDALSQL.GetSelectRecuperacaoEPrevencaoPerdasDataApuracao(data)

                data.FillDataSet(DatasetRecuperacaoEPrevencaoPerdas, _
                 sql, _
                 DatasetRecuperacaoEPrevencaoPerdas.DataApuracao.TableName, _
                 New IDataParameter() { _
                            data.CreateParameter("NUMCTTFRN", DbType.Decimal, "NUMCTTFRN", NUMCTTFRN) _
                      })
                Me.SetComplete()
                Return DatasetRecuperacaoEPrevencaoPerdas
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Obtem os dados para o relatorio Acordos Cancelados / Perdas
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Rodrigo Gama]	27/8/2008	Created
        ''' </history>
        Public Function ObterAcordosCanceladosPerdas(ByVal DATAINICIAL As Date, _
                                                     ByVal DATAFINAL As Date, _
                                                     ByVal CODFRN As Decimal, _
                                                     ByVal CODCPR As Decimal, _
                                                     ByVal CODDIVCMP As Decimal) As DatasetRecuperacaoEPrevencaoPerdas
            Try
                Dim DatasetRecuperacaoEPrevencaoPerdas As DatasetRecuperacaoEPrevencaoPerdas
                Dim data As IData
                Dim sql As String

                DatasetRecuperacaoEPrevencaoPerdas = New DatasetRecuperacaoEPrevencaoPerdas

                'Desabilita a integridade referencial
                DatasetRecuperacaoEPrevencaoPerdas.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = RecuperacaoEPrevencaoPerdasDALSQL.GetSelectAcordosCanceladosPerdas(data)

                data.FillDataSet(DatasetRecuperacaoEPrevencaoPerdas, _
           sql, _
           DatasetRecuperacaoEPrevencaoPerdas.AcordosCanceladosPerdas.TableName, _
           New IDataParameter() { _
                      data.CreateParameter("DTINICIAL1", DbType.Date, "DATAINICIAL", DATAINICIAL), _
                      data.CreateParameter("DTINICIAL2", DbType.Date, "DATAINICIAL", DATAINICIAL), _
                      data.CreateParameter("DTFINAL1", DbType.Date, "DATAFINAL", DATAFINAL), _
                      data.CreateParameter("DTFINAL2", DbType.Date, "DATAFINAL", DATAFINAL), _
                      data.CreateParameter("CODFRN1", DbType.Decimal, "CODFRN", CODFRN), _
                      data.CreateParameter("CODFRN2", DbType.Decimal, "CODFRN", CODFRN), _
                      data.CreateParameter("CODFRN3", DbType.Decimal, "CODFRN", CODFRN), _
                      data.CreateParameter("CODFRN4", DbType.Decimal, "CODFRN", CODFRN), _
                      data.CreateParameter("CODCPR1", DbType.Decimal, "CODCPR", CODCPR), _
                      data.CreateParameter("CODCPR2", DbType.Decimal, "CODCPR", CODCPR), _
                      data.CreateParameter("CODCPR3", DbType.Decimal, "CODCPR", CODCPR), _
                      data.CreateParameter("CODCPR4", DbType.Decimal, "CODCPR", CODCPR), _
                      data.CreateParameter("CODDIVCMP1", DbType.Decimal, "CODDIVCMP", CODDIVCMP), _
                      data.CreateParameter("CODDIVCMP2", DbType.Decimal, "CODDIVCMP", CODDIVCMP), _
                      data.CreateParameter("CODDIVCMP3", DbType.Decimal, "CODDIVCMP", CODDIVCMP), _
                      data.CreateParameter("CODDIVCMP4", DbType.Decimal, "CODDIVCMP", CODDIVCMP) _
                })
                Me.SetComplete()

                Return DatasetRecuperacaoEPrevencaoPerdas
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function


        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Obtem Compradores
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Rodrigo Gama]	04/09/2008	Created
        ''' </history>
        Public Function ObterComprador(ByVal CODCPR As Decimal, _
                                       ByVal NOMCPR As String) As DatasetRecuperacaoEPrevencaoPerdas
            Try
                Dim DatasetRecuperacaoEPrevencaoPerdas As DatasetRecuperacaoEPrevencaoPerdas
                Dim data As IData
                Dim sql As String
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList

                DatasetRecuperacaoEPrevencaoPerdas = New DatasetRecuperacaoEPrevencaoPerdas

                'Desabilita a integridade referencial
                DatasetRecuperacaoEPrevencaoPerdas.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = RecuperacaoEPrevencaoPerdasDALSQL.GetSelectObterComprador(data, CODCPR, NOMCPR)

                If CODCPR <> 0 Then
                    paramNome = data.CreateParameter("CODCPR", DbType.Decimal, "CODCPR", CODCPR)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                If NOMCPR <> "" Then
                    paramNome = data.CreateParameter("NOMCPR", DbType.String, "NOMCPR", "%" + NOMCPR.ToUpper() + "%")
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo(parametrosCommand)

                data.FillDataSet(DatasetRecuperacaoEPrevencaoPerdas, _
                 sql, _
                 DatasetRecuperacaoEPrevencaoPerdas.Comprador.TableName, _
                 parametrosCommand)

                Me.SetComplete()
                Return DatasetRecuperacaoEPrevencaoPerdas
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Obtem Celulas por atributo
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Rodrigo Gama]	09/09/2008	Created
        ''' </history>
        ''' ''' -----------------------------------------------------------------------------
        Public Function ObterCelulaPorAtributo(ByVal CODDIVCMP As Decimal, _
                                               ByVal DESDIVCMP As String) As DatasetCelula
            Try
                Dim DatasetCelula As DatasetCelula
                Dim data As IData
                Dim sql As String
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList

                DatasetCelula = New DatasetCelula

                'Desabilita a integridade referencial
                DatasetCelula.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = RecuperacaoEPrevencaoPerdasDALSQL.GetSelectObterCelulaPorAtributo(data, CODDIVCMP, DESDIVCMP)

                If CODDIVCMP <> 0 Then
                    paramNome = data.CreateParameter("CODDIVCMP", DbType.Decimal, "CODDIVCMP", CODDIVCMP)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                If DESDIVCMP <> "" Then
                    paramNome = data.CreateParameter("DESDIVCMP", DbType.String, "DESDIVCMP", "%" + DESDIVCMP.ToUpper() + "%")
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo(parametrosCommand)

                data.FillDataSet(DatasetCelula, _
                 sql, _
                 DatasetCelula.T0118570.TableName, _
                 parametrosCommand)

                Me.SetComplete()
                Return DatasetCelula
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade T0123183 com base na sua chave primária.
        ''' Descrição da entidade:CADASTRO DIRETORIA CELULA
        ''' </summary>
        ''' <param name="CODDRTCMP">CODIGO DA DIRETORIAS DE COMPRAS.</param>
        ''' <returns>Retorna um DataSet com a tabela "T0123183" preenchida.</returns>
        ''' <remarks>
        ''' Sempre que um código inválido for informado, uma exception será retornada.
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    05/09/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterDiretoriaCelula(ByVal CODDRTCMP As Decimal) As DatasetDiretoriaCelulas
            Try
                Dim DatasetDiretoriaCelulas As DatasetDiretoriaCelulas
                Dim data As IData
                Dim sql As String

                DatasetDiretoriaCelulas = New DatasetDiretoriaCelulas

                'Desabilita a integridade referencial
                DatasetDiretoriaCelulas.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = RecuperacaoEPrevencaoPerdasDALSQL.GetSelectDiretoriaCelula(data)
                data.FillDataSet(DatasetDiretoriaCelulas, _
                    sql, _
                    DatasetDiretoriaCelulas.T0123183.TableName, _
                    New IDataParameter() { _
                            data.CreateParameter("CODDRTCMP", DbType.Decimal, "CODDRTCMP", CODDRTCMP) _
                        })


                Me.SetComplete()
                Return DatasetDiretoriaCelulas
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade T0123183 com base na em atributos que geralmente não compoem a chave primária (exceto em chaves compostas).
        ''' Descrição da entidade:CADASTRO DIRETORIA CELULA
        ''' </summary>
        ''' <param name="CODCPR">CODIGO COMPRADOR.</param>
        ''' <param name="CODDRT">CODIGO DIRETORIA.</param>
        ''' <param name="CODDRTCMP">CODIGO DA DIRETORIAS DE COMPRAS.</param>
        ''' <param name="CODUNDESRNGC">CODIGO UNIDADE ESTRATEGICA DE NEGOCIOS.</param>
        ''' <param name="DESDRTCMP">DESCRICAO DA DIRETORIA DE COMPRAS.</param>
        ''' <returns>Retorna um DataSet com a tabela "T0123183" preenchida.</returns>
        ''' <remarks>
        ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
        ''' Um parametro do tipo número é omitido quando for zero,
        ''' Um parametro do tipo String é omitido quando for vazia,
        ''' Um parametro do tipo data   é omitido quando for Nothing,
        ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    05/09/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterDiretoriaCelulas(ByVal CODCPR As Decimal, _
                                                ByVal CODDRT As Decimal, _
                                                ByVal CODDRTCMP As Decimal, _
                                                ByVal CODUNDESRNGC As Decimal, _
                                                ByVal DESDRTCMP As String) As DatasetDiretoriaCelulas
            Try
                Dim DatasetDiretoriaCelulas As DatasetDiretoriaCelulas
                Dim data As IData
                Dim sql As String
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList

                DatasetDiretoriaCelulas = New DatasetDiretoriaCelulas

                DatasetDiretoriaCelulas.EnforceConstraints = False

                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)
                sql = RecuperacaoEPrevencaoPerdasDALSQL.GetSelectDiretoriaCelula(data, CODCPR, CODDRT, CODDRTCMP, CODUNDESRNGC, DESDRTCMP)

                If CODCPR <> 0 Then
                    paramNome = data.CreateParameter("CODCPR", DbType.Decimal, "CODCPR", CODCPR)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODDRT <> 0 Then
                    paramNome = data.CreateParameter("CODDRT", DbType.Decimal, "CODDRT", CODDRT)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODDRTCMP <> 0 Then
                    paramNome = data.CreateParameter("CODDRTCMP", DbType.Decimal, "CODDRTCMP", CODDRTCMP)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODUNDESRNGC <> 0 Then
                    paramNome = data.CreateParameter("CODUNDESRNGC", DbType.Decimal, "CODUNDESRNGC", CODUNDESRNGC)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If DESDRTCMP.Trim() <> "" Then
                    paramNome = data.CreateParameter("DESDRTCMP", DbType.String, "DESDRTCMP", "%" + DESDRTCMP.ToUpper() + "%")
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo(parametrosCommand)

                data.FillDataSet(DatasetDiretoriaCelulas, _
                    sql, _
                    DatasetDiretoriaCelulas.T0123183.TableName, _
                    parametrosCommand)

                Me.SetComplete()
                Return DatasetDiretoriaCelulas
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

    End Class

End Namespace
