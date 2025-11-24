Imports Martins.Data.TransactionManagement
Imports Martins.Security.Helper
Imports Martins.Compras.AcoesComerciais.ContaCorrenteFornecedor.BLL
Imports Martins.Compras.AcoesComerciais.AcordoFornecimento

Namespace BP

    Public Class RecuperacaoEPrevencaoPerdasBP
        Inherits BPClass

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
        ''' -----------------------------------------------------------------------------
        Public Function ObterRecuperacaoEPrevencaoPerdasSintetico(ByVal NUMCTTFRN As Decimal, _
                                                                  ByVal INDDVRVLRAPUARDFRN As Decimal, _
                                                                  ByVal TIPLMTHSTCFAARDFRN As Decimal) As DatasetRecuperacaoEPrevencaoPerdas
            Try
                Dim RecuperacaoEPrevencaoPerdasSintetico As RecuperacaoEPrevencaoPerdasBLL
                RecuperacaoEPrevencaoPerdasSintetico = New RecuperacaoEPrevencaoPerdasBLL

                Dim DatasetRecuperacaoEPrevencaoPerdas As DatasetRecuperacaoEPrevencaoPerdas
                DatasetRecuperacaoEPrevencaoPerdas = RecuperacaoEPrevencaoPerdasSintetico.ObterRecuperacaoEPrevencaoPerdasSintetico(NUMCTTFRN, INDDVRVLRAPUARDFRN, TIPLMTHSTCFAARDFRN)

                Me.SetComplete()
                Return DatasetRecuperacaoEPrevencaoPerdas

            Catch ex As Martins.ExceptionManagement.BaseApplicationException

                Me.SetAbort()
                Throw ex

            Catch ex As Exception

                Me.SetAbort()
                Throw New Martins.ExceptionManagement.MartinsSystemException(ex.Message, ErrorConstants.SYSTEM_ERROR, ex)

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
    ''' -----------------------------------------------------------------------------
        Public Function ObterRecuperacaoEPrevencaoPerdasAnalitico(ByVal NUMCTTFRN As Decimal, _
                                                                  ByVal INDDVRVLRAPUARDFRN As Decimal, _
                                                                  ByVal TIPLMTHSTCFAARDFRN As Decimal, _
                                                                  ByVal DATREFAPU As Date, _
                                                                  ByVal NUMCSLCTTFRN As Decimal) As DatasetRecuperacaoEPrevencaoPerdas
            Try
                Dim RecuperacaoEPrevencaoPerdasAnalitico As RecuperacaoEPrevencaoPerdasBLL
                RecuperacaoEPrevencaoPerdasAnalitico = New RecuperacaoEPrevencaoPerdasBLL

                Dim DatasetRecuperacaoEPrevencaoPerdas As DatasetRecuperacaoEPrevencaoPerdas
                DatasetRecuperacaoEPrevencaoPerdas = RecuperacaoEPrevencaoPerdasAnalitico.ObterRecuperacaoEPrevencaoPerdasAnalitico(NUMCTTFRN, INDDVRVLRAPUARDFRN, TIPLMTHSTCFAARDFRN, DATREFAPU, NUMCSLCTTFRN)

                Me.SetComplete()
                Return DatasetRecuperacaoEPrevencaoPerdas

            Catch ex As Martins.ExceptionManagement.BaseApplicationException

                Me.SetAbort()
                Throw ex

            Catch ex As Exception

                Me.SetAbort()
                Throw New Martins.ExceptionManagement.MartinsSystemException(ex.Message, ErrorConstants.SYSTEM_ERROR, ex)

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
        Public Function ObterNotasPeriodo(ByVal NUMCTTFRN As Decimal, _
                                          ByVal CODFRN As Decimal) As DatasetRecuperacaoEPrevencaoPerdas
            Try
                Dim RecuperacaoEPrevencaoPerdasNotasPeriodo As RecuperacaoEPrevencaoPerdasBLL
                RecuperacaoEPrevencaoPerdasNotasPeriodo = New RecuperacaoEPrevencaoPerdasBLL

                Dim DatasetRecuperacaoEPrevencaoPerdas As DatasetRecuperacaoEPrevencaoPerdas
                DatasetRecuperacaoEPrevencaoPerdas = RecuperacaoEPrevencaoPerdasNotasPeriodo.ObterNotasPeriodo(NUMCTTFRN, CODFRN)

                Me.SetComplete()
                Return DatasetRecuperacaoEPrevencaoPerdas

            Catch ex As Martins.ExceptionManagement.BaseApplicationException

                Me.SetAbort()
                Throw ex

            Catch ex As Exception

                Me.SetAbort()
                Throw New Martins.ExceptionManagement.MartinsSystemException(ex.Message, ErrorConstants.SYSTEM_ERROR, ex)

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
        ''' -----------------------------------------------------------------------------
        Public Function ObterRecuperacaoEPrevencaoPerdasClausulas(ByVal NUMCTTFRN As Decimal) As DatasetRecuperacaoEPrevencaoPerdas
            Try
                Dim RecuperacaoEPrevencaoPerdasClausulas As RecuperacaoEPrevencaoPerdasBLL
                RecuperacaoEPrevencaoPerdasClausulas = New RecuperacaoEPrevencaoPerdasBLL

                Dim DatasetRecuperacaoEPrevencaoPerdas As DatasetRecuperacaoEPrevencaoPerdas
                DatasetRecuperacaoEPrevencaoPerdas = RecuperacaoEPrevencaoPerdasClausulas.ObterRecuperacaoEPrevencaoPerdasClausulas(NUMCTTFRN)

                Me.SetComplete()
                Return DatasetRecuperacaoEPrevencaoPerdas

            Catch ex As Martins.ExceptionManagement.BaseApplicationException

                Me.SetAbort()
                Throw ex

            Catch ex As Exception

                Me.SetAbort()
                Throw New Martins.ExceptionManagement.MartinsSystemException(ex.Message, ErrorConstants.SYSTEM_ERROR, ex)

            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Obtem as datas de referencia da apuracao do contrato selecionado como filtro para
        ''' o relatorio Recuperacao e Prevencao de Perdas.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Rodrigo Gama]	28/8/2008	Created
        ''' </history>
        ''' 
        Public Function ObterRecuperacaoEPrevencaoPerdasDataApuracao(ByVal NUMCTTFRN As Decimal) As DatasetRecuperacaoEPrevencaoPerdas
            Try
                Dim RecuperacaoEPrevencaoPerdasDataApuracao As RecuperacaoEPrevencaoPerdasBLL
                RecuperacaoEPrevencaoPerdasDataApuracao = New RecuperacaoEPrevencaoPerdasBLL

                Dim DatasetRecuperacaoEPrevencaoPerdas As DatasetRecuperacaoEPrevencaoPerdas
                DatasetRecuperacaoEPrevencaoPerdas = RecuperacaoEPrevencaoPerdasDataApuracao.ObterRecuperacaoEPrevencaoPerdasDataApuracao(NUMCTTFRN)

                Me.SetComplete()
                Return DatasetRecuperacaoEPrevencaoPerdas

            Catch ex As Martins.ExceptionManagement.BaseApplicationException

                Me.SetAbort()
                Throw ex

            Catch ex As Exception

                Me.SetAbort()
                Throw New Martins.ExceptionManagement.MartinsSystemException(ex.Message, ErrorConstants.SYSTEM_ERROR, ex)

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
        ''' -----------------------------------------------------------------------------
        Public Function ObterAcordosCanceladosPerdas(ByVal DATAINICIAL As Date, _
                                                     ByVal DATAFINAL As Date, _
                                                     ByVal CODFRN As Decimal, _
                                                     ByVal CODCPR As Decimal, _
                                                     ByVal CODDIVCMP As Decimal) As DatasetRecuperacaoEPrevencaoPerdas
            Try
                Dim RecuperacaoEPrevencaoPerdasAcordosCanceladosPerdas As RecuperacaoEPrevencaoPerdasBLL
                RecuperacaoEPrevencaoPerdasAcordosCanceladosPerdas = New RecuperacaoEPrevencaoPerdasBLL

                Dim DatasetRecuperacaoEPrevencaoPerdas As DatasetRecuperacaoEPrevencaoPerdas
                DatasetRecuperacaoEPrevencaoPerdas = RecuperacaoEPrevencaoPerdasAcordosCanceladosPerdas.ObterAcordosCanceladosPerdas(DATAINICIAL, DATAFINAL, CODFRN, CODCPR, CODDIVCMP)

                Me.SetComplete()
                Return DatasetRecuperacaoEPrevencaoPerdas

            Catch ex As Martins.ExceptionManagement.BaseApplicationException

                Me.SetAbort()
                Throw ex

            Catch ex As Exception

                Me.SetAbort()
                Throw New Martins.ExceptionManagement.MartinsSystemException(ex.Message, ErrorConstants.SYSTEM_ERROR, ex)

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
                Dim RecuperacaoEPrevencaoPerdasObterComprador As RecuperacaoEPrevencaoPerdasBLL
                RecuperacaoEPrevencaoPerdasObterComprador = New RecuperacaoEPrevencaoPerdasBLL

                Dim DatasetRecuperacaoEPrevencaoPerdas As DatasetRecuperacaoEPrevencaoPerdas
                DatasetRecuperacaoEPrevencaoPerdas = RecuperacaoEPrevencaoPerdasObterComprador.ObterComprador(CODCPR, NOMCPR)

                Me.SetComplete()
                Return DatasetRecuperacaoEPrevencaoPerdas

            Catch ex As Martins.ExceptionManagement.BaseApplicationException

                Me.SetAbort()
                Throw ex

            Catch ex As Exception

                Me.SetAbort()
                Throw New Martins.ExceptionManagement.MartinsSystemException(ex.Message, ErrorConstants.SYSTEM_ERROR, ex)

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
        ''' -----------------------------------------------------------------------------
        Public Function ObterCelulaPorAtributo(ByVal CODDIVCMP As Decimal, _
                                               ByVal DESDIVCMP As String) As DatasetCelula
            Try
                Dim DatasetCelulaObterCelulaPorAtributo As RecuperacaoEPrevencaoPerdasBLL
                DatasetCelulaObterCelulaPorAtributo = New RecuperacaoEPrevencaoPerdasBLL

                Dim DatasetCelula As DatasetCelula
                DatasetCelula = DatasetCelulaObterCelulaPorAtributo.ObterCelulaPorAtributo(CODDIVCMP, DESDIVCMP)

                Me.SetComplete()
                Return DatasetCelula

            Catch ex As Martins.ExceptionManagement.BaseApplicationException

                Me.SetAbort()
                Throw ex

            Catch ex As Exception

                Me.SetAbort()
                Throw New Martins.ExceptionManagement.MartinsSystemException(ex.Message, ErrorConstants.SYSTEM_ERROR, ex)

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

                Dim RecuperacaoEPrevencaoPerdas As RecuperacaoEPrevencaoPerdasBLL
                RecuperacaoEPrevencaoPerdas = New RecuperacaoEPrevencaoPerdasBLL

                Dim DatasetDiretoriaCelulas As DatasetDiretoriaCelulas
                DatasetDiretoriaCelulas = RecuperacaoEPrevencaoPerdas.ObterDiretoriaCelula(CODDRTCMP)

                Dim configuracao As Martins.ConfigurationManagement.MartinsApplicationConfiguration
                configuracao = CType(Martins.ConfigurationManagement.ConfigurationManager.Read(Martins.ConfigurationManagement.ConfigurationManager.GetDefaultSection()), Martins.ConfigurationManagement.MartinsApplicationConfiguration)

                Me.SetComplete()
                Return DatasetDiretoriaCelulas

            Catch ex As Martins.ExceptionManagement.BaseApplicationException

                Me.SetAbort()
                Throw ex

            Catch ex As Exception

                Me.SetAbort()
                Throw New Martins.ExceptionManagement.MartinsSystemException(ex.Message, ErrorConstants.SYSTEM_ERROR, ex)

            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade T0123183 com base em outros atributos.
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
                Dim RecuperacaoEPrevencaoPerdas As RecuperacaoEPrevencaoPerdasBLL
                RecuperacaoEPrevencaoPerdas = New RecuperacaoEPrevencaoPerdasBLL

                Dim DatasetDiretoriaCelulas As DatasetDiretoriaCelulas
                DatasetDiretoriaCelulas = RecuperacaoEPrevencaoPerdas.ObterDiretoriaCelulas(CODCPR, CODDRT, CODDRTCMP, CODUNDESRNGC, DESDRTCMP)

                Me.SetComplete()
                Return DatasetDiretoriaCelulas

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


