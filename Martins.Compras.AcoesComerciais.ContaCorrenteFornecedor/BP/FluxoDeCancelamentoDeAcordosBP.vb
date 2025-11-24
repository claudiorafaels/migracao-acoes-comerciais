Imports Martins.Data.TransactionManagement
Imports Martins.Security.Helper
Imports Martins.Compras.AcoesComerciais.ContaCorrenteFornecedor.BLL
Imports Martins.Compras.AcoesComerciais.MensagemEletronica.BLL
Imports Martins.Compras.AcoesComerciais.MensagemEletronica
Imports Martins.Compras.AcoesComerciais.Gestao
Imports Martins.Compras.AcoesComerciais.Gestao.BLL
Imports Martins.Compras.AcoesComerciais.Gestao.DAL

Namespace BP
    ''' -----------------------------------------------------------------------------
    ''' Project   : Martins.Compras.AcoesComerciais.AcordoFornecimento
    ''' Class     : FluxoDeCancelamentoDeAcordosBP
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Classe BP da entidade com objetivo: chegar segurança e repassar a chamada para a classe BLL
    ''' </summary>
    ''' <remarks>
    '''
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    23/04/2008  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class FluxoDeCancelamentoDeAcordosBP
        Inherits BPClass

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
        '''         '''     [Marcos Queiroz]    23/04/2008  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterFluxoCancelamentoAcordoPorChave(ByVal CODFRN As Decimal, _
                                                             ByVal NUMPEDCNCACOCMC As Decimal) As DatasetFluxoCancelamentoAcordo
            Try

                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosBLL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosBLL

                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterFluxoCancelamentoAcordoPorChave(CODFRN, NUMPEDCNCACOCMC)

                Dim T0154038Row As DatasetFluxoCancelamentoAcordo.T0154038Row
                T0154038Row = DatasetFluxoCancelamentoAcordo.T0154038(0)

                If T0154038Row.CODSTAAPV = 3 Then
                    DatasetFluxoCancelamentoAcordo.Merge(FluxoDeCancelamentoDeAcordos.ObterAcordoComDuplicidadeEmOutroFluxo(NUMPEDCNCACOCMC))
                End If

                'Obtem a relação
                If Not DatasetFluxoCancelamentoAcordo Is Nothing Then
                    DatasetFluxoCancelamentoAcordo.Merge(FluxoDeCancelamentoDeAcordos.ObterAcordoACancelarEmFluxoCancelamentoAcordoPorAtributos(0, 0, 0, Nothing, Nothing, NUMPEDCNCACOCMC, 0, 0))
                Else
                    DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterAcordoACancelarEmFluxoCancelamentoAcordoPorAtributos(0, 0, 0, Nothing, Nothing, NUMPEDCNCACOCMC, 0, 0)
                End If

                'Obtem relação dos fluxos
                If Not DatasetFluxoCancelamentoAcordo Is Nothing Then
                    DatasetFluxoCancelamentoAcordo.Merge(FluxoDeCancelamentoDeAcordos.ObterFluxosDeCancelamentoDeAcordos(NUMPEDCNCACOCMC))
                Else
                    DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterFluxosDeCancelamentoDeAcordos(NUMPEDCNCACOCMC)
                End If

                Me.SetComplete()
                Return DatasetFluxoCancelamentoAcordo

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
        ''' Este método retorna dados da entidade T0154038 com base em outros atributos.
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
                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosBLL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosBLL

                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterFluxoCancelamentoAcordoPorAtributos(CODFRN, CODSTAAPV, NUMPEDCNCACOCMC, NUMREQCNCACOCMC)

                Me.SetComplete()
                Return DatasetFluxoCancelamentoAcordo

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

                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosBLL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosBLL

                FluxoDeCancelamentoDeAcordos.AtualizarFluxoCancelamentoAcordo(DatasetFluxoCancelamentoAcordo)
                Me.SetComplete()

            Catch ex As Martins.ExceptionManagement.BaseApplicationException

                Me.SetAbort()
                Throw ex

            Catch ex As Exception

                Me.SetAbort()
                Throw New Martins.ExceptionManagement.MartinsSystemException(ex.Message, ErrorConstants.SYSTEM_ERROR, ex)

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

                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosBLL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosBLL

                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterAcordoACancelarEmFluxoCancelamentoAcordoPorChave(CODEMP, CODFILEMP, CODPMS, DATNGCPMS, DATPRVRCBPMS, NUMPEDCNCACOCMC, TIPDSNDSCBNF, TIPFRMDSCBNF)

                Me.SetComplete()
                Return DatasetFluxoCancelamentoAcordo

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
        ''' Este método retorna dados da entidade T0154021 com base em outros atributos.
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
                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosBLL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosBLL

                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterAcordoACancelarEmFluxoCancelamentoAcordoPorAtributos(CODEMP, CODFILEMP, CODPMS, DATNGCPMS, DATPRVRCBPMS, NUMPEDCNCACOCMC, TIPDSNDSCBNF, TIPFRMDSCBNF)

                Me.SetComplete()
                Return DatasetFluxoCancelamentoAcordo

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

                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosBLL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosBLL

                FluxoDeCancelamentoDeAcordos.AtualizarAcordoACancelarEmFluxoCancelamentoAcordo(DatasetFluxoCancelamentoAcordo)
                Me.SetComplete()

            Catch ex As Martins.ExceptionManagement.BaseApplicationException

                Me.SetAbort()
                Throw ex

            Catch ex As Exception

                Me.SetAbort()
                Throw New Martins.ExceptionManagement.MartinsSystemException(ex.Message, ErrorConstants.SYSTEM_ERROR, ex)

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
                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosBLL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosBLL

                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterMinhasAprovavoesEmFluxoDeCancelamentoDeAcordos(NUMPEDCNCACOCMC, CODFNC)

                Me.SetComplete()
                Return DatasetFluxoCancelamentoAcordo

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
                Dim FluxoDeCancelamentoDeAcordos As New FluxoDeCancelamentoDeAcordosBLL
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

                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosBLL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosBLL

                Dim DatasetAcordoACancelarEmFluxoCancelamentoAcordo As DatasetAcordoACancelarEmFluxoCancelamentoAcordo

                DatasetAcordoACancelarEmFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterAcordosParaCancelamentoPorFornecedor(CODFRN)

                Me.SetComplete()
                Return DatasetAcordoACancelarEmFluxoCancelamentoAcordo
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

                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosBLL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosBLL

                Dim DatasetAcordoACancelarEmFluxoCancelamentoAcordo As DatasetAcordoACancelarEmFluxoCancelamentoAcordo
                DatasetAcordoACancelarEmFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterAcordosParaCancelamentoPorNUMPEDCNCACOCMC(NUMPEDCNCACOCMC)

                Me.SetComplete()
                Return DatasetAcordoACancelarEmFluxoCancelamentoAcordo
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
        ''' 
        ''' </summary>
        ''' <param name="NUMPEDCNCACOCMC"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Danilo Rafael]	13/5/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function IniciarFluxoCancelamentoAcordo(ByVal NUMPEDCNCACOCMC As Decimal, ByVal CODFRN As Decimal) As Boolean
            Try
                Dim FluxoDeCancelamentoDeAcordos As New FluxoDeCancelamentoDeAcordosBLL
                Dim dsDiretores As DatasetFluxoCancelamentoAcordo
                Dim email As New ArrayList

                'Obter Diretores Aprovadores do Cancelamento de Acordo
                dsDiretores = FluxoDeCancelamentoDeAcordos.ObterDiretorAprovadorDeFluxoFluxoDeCancelamentosDeAcordo(NUMPEDCNCACOCMC)

                'Percorre todos diretores aprovadores
                Dim NUMSEQFLUAPVDiretor As Decimal = 201
                Dim NUMSEQFLUAPV As Decimal = 1
                Dim DATHRAAPVFLU As Date = Date.Now

                'Gerar fluxo de aprovação para diretores e gerentes
                For Each LinhaDiretor As DatasetFluxoCancelamentoAcordo.FuncionarioRow In dsDiretores.Funcionario
                    'Gera Fluxo Diretor
                    FluxoDeCancelamentoDeAcordos.GerarFluxoAprovacao(Constants.CODSISINF_FLUXO_DE_CANCELAMENTO_DE_ACORDO, NUMPEDCNCACOCMC, NUMSEQFLUAPV, DATHRAAPVFLU, NUMSEQFLUAPVDiretor, LinhaDiretor.CODFNC, Constants.TIPSTAFLUAPV_ESPERA_APROVACAO, Nothing, String.Empty, String.Empty, 0, 0)

                    'Busca todos gerentes aprovadores do cancelamento de acordo e subordinados ao diretores do laço
                    Dim dsGerentes As DatasetFluxoCancelamentoAcordo
                    dsGerentes = FluxoDeCancelamentoDeAcordos.ObterGerentesAprovadoresDeFluxoFluxoDeCancelamentosDeAcordo(NUMPEDCNCACOCMC, LinhaDiretor.CODFNC)

                    'Percorre todos gerentes aprovadores e gera fluxo para cada um deles
                    For Each LinhaGerente As DatasetFluxoCancelamentoAcordo.FuncionarioRow In dsGerentes.Funcionario
                        NUMSEQFLUAPV += 1
                        'Gera Fluxo Gerente
                        FluxoDeCancelamentoDeAcordos.GerarFluxoAprovacao(Constants.CODSISINF_FLUXO_DE_CANCELAMENTO_DE_ACORDO, NUMPEDCNCACOCMC, NUMSEQFLUAPV, DATHRAAPVFLU, NUMSEQFLUAPVDiretor - 100, LinhaGerente.CODFNC, Constants.TIPSTAFLUAPV_EM_APROVACAO, Nothing, String.Empty, String.Empty, 0, 0)
                        'Guarda endereço para enviar e-mail
                        email.Add(LinhaGerente.NOMUSRRCF.ToLower.Trim & "@martins.com.br")
                    Next
                    NUMSEQFLUAPV += 1
                    NUMSEQFLUAPVDiretor += 1
                Next

                'Consulta Fluxo
                Dim dsDatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                dsDatasetFluxoCancelamentoAcordo = Me.ObterFluxoCancelamentoAcordoPorChave(CODFRN, NUMPEDCNCACOCMC)

                If dsDatasetFluxoCancelamentoAcordo.T0154038.Rows.Count = 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Cancelamento de Acordos não econtrado|", "")
                End If

                If dsDatasetFluxoCancelamentoAcordo.T0154021ComDuplicidadeEmOutroFluxo.Rows.Count > 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Existe acordo que pertence a outro fluxo aprovado ou em aprovação|", "")
                End If

                Dim T0154038Row As DatasetFluxoCancelamentoAcordo.T0154038Row
                T0154038Row = dsDatasetFluxoCancelamentoAcordo.T0154038(0)

                'Validar(Fluxo)
                If T0154038Row.CODSTAAPV <> Constants.CODSTAAPV_NOVO Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Não é possível iniciar fluxo porque o status da transferencia não é novo|", "")
                End If
                If T0154038Row.DESOBSCNCACOCMC.Trim.Length = 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Informe a observação|", "")
                End If
                If dsDatasetFluxoCancelamentoAcordo.T0154021.Rows.Count = 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Selecione os valores a cancelar antes de iniciar o fluxo|", "")
                End If

                'Gerar fluxo para funcionários da controladoria
                Dim dsFuncionariosControladoria As DatasetFluxoCancelamentoAcordo
                Dim NUMSEQNIVAPV As Decimal = Constants.NUMSEQNIVAPV_PRIMEIRO_FLUXO_CONTROLADORIA

                dsFuncionariosControladoria = Me.ObterFuncionariosDaControladoriaAprovadoresDeFluxoDeCancelamentoDeAcordos

                For Each LinhaFuncionariosControladoria As DatasetFluxoCancelamentoAcordo.FuncionariosControladoriaRow In dsFuncionariosControladoria.FuncionariosControladoria
                    FluxoDeCancelamentoDeAcordos.GerarFluxoAprovacao(Constants.CODSISINF_FLUXO_DE_CANCELAMENTO_DE_ACORDO, NUMPEDCNCACOCMC, NUMSEQFLUAPV, DATHRAAPVFLU, NUMSEQNIVAPV, LinhaFuncionariosControladoria.CODFNCAPVFIX, Constants.TIPSTAFLUAPV_ESPERA_APROVACAO, Nothing, String.Empty, String.Empty, 0, 0)
                    NUMSEQFLUAPV += 1
                    NUMSEQNIVAPV += 100
                Next

                'Alterar status da transferencia
                T0154038Row.CODSTAAPV = Constants.CODSTAAPV_EM_APROVACAO
                Me.AtualizarFluxoCancelamentoAcordo(dsDatasetFluxoCancelamentoAcordo)

                'Enviar e-mail para os aprovadores
                Me.EnviarEmailNaIniciacaoDoFluxoDeCancelamentoDeAcordo(NUMPEDCNCACOCMC, CODFRN, email)

                Me.SetComplete()
                Return True
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
                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosBLL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosBLL

                Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterFluxoCancelamentoAcordoPesquisa(CODFRN, CODSTAAPV, NUMPEDCNCACOCMC, NUMREQCNCACOCMC)

                Me.SetComplete()
                Return DatasetFluxoCancelamentoAcordo

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

                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosBLL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosBLL

                Dim DatasetFluxoAprovacao As DatasetFluxoAprovacao
                DatasetFluxoAprovacao = FluxoDeCancelamentoDeAcordos.ObterFluxoAprovacao(CODSISINF, NUMFLUAPV, NUMSEQFLUAPV)

                Me.SetComplete()
                Return DatasetFluxoAprovacao

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
        ''' Este método retorna dados da entidade T0161591 com base em outros atributos.
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
                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosBLL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosBLL

                Dim DatasetFluxoAprovacao As DatasetFluxoAprovacao
                DatasetFluxoAprovacao = FluxoDeCancelamentoDeAcordos.ObterFluxosAprovacao(CODEDEAPV, CODEDEARZ, CODSISINF, DATHRAAPVFLU, DATHRAFLUAPV, NUMFLUAPV, NUMSEQFLUAPV, NUMSEQFLUAPVPEDOPN, NUMSEQNIVAPV, TIPSTAFLUAPV)

                Me.SetComplete()
                Return DatasetFluxoAprovacao

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
        ''' 
        ''' </summary>
        ''' <param name="CODEDEAPV"></param>
        ''' <param name="CODEDEARZ"></param>
        ''' <param name="CODSISINF"></param>
        ''' <param name="DATHRAAPVFLU"></param>
        ''' <param name="DATHRAFLUAPV"></param>
        ''' <param name="NUMFLUAPV"></param>
        ''' <param name="NUMSEQFLUAPV"></param>
        ''' <param name="NUMSEQFLUAPVPEDOPN"></param>
        ''' <param name="NUMSEQNIVAPV"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	28/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterFluxosAprovacaoPendentes(ByVal CODEDEAPV As Decimal, _
                                                      ByVal CODEDEARZ As Decimal, _
                                                      ByVal CODSISINF As Decimal, _
                                                      ByVal DATHRAAPVFLU As String, _
                                                      ByVal DATHRAFLUAPV As String, _
                                                      ByVal NUMFLUAPV As Decimal, _
                                                      ByVal NUMSEQFLUAPV As Decimal, _
                                                      ByVal NUMSEQFLUAPVPEDOPN As Decimal, _
                                                      ByVal NUMSEQNIVAPV As Decimal) As DatasetFluxoAprovacao
            Try
                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosBLL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosBLL

                Dim DatasetFluxoAprovacao As New DatasetFluxoAprovacao

                DatasetFluxoAprovacao.Merge(FluxoDeCancelamentoDeAcordos.ObterFluxosAprovacao(CODEDEAPV, CODEDEARZ, CODSISINF, DATHRAAPVFLU, DATHRAFLUAPV, NUMFLUAPV, NUMSEQFLUAPV, NUMSEQFLUAPVPEDOPN, NUMSEQNIVAPV, Constants.TIPSTAFLUAPV_NOVO))
                DatasetFluxoAprovacao.Merge(FluxoDeCancelamentoDeAcordos.ObterFluxosAprovacao(CODEDEAPV, CODEDEARZ, CODSISINF, DATHRAAPVFLU, DATHRAFLUAPV, NUMFLUAPV, NUMSEQFLUAPV, NUMSEQFLUAPVPEDOPN, NUMSEQNIVAPV, Constants.TIPSTAFLUAPV_EM_APROVACAO))
                DatasetFluxoAprovacao.Merge(FluxoDeCancelamentoDeAcordos.ObterFluxosAprovacao(CODEDEAPV, CODEDEARZ, CODSISINF, DATHRAAPVFLU, DATHRAFLUAPV, NUMFLUAPV, NUMSEQFLUAPV, NUMSEQFLUAPVPEDOPN, NUMSEQNIVAPV, Constants.TIPSTAFLUAPV_ESPERA_APROVACAO))

                Me.SetComplete()
                Return DatasetFluxoAprovacao

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

                Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosBLL
                FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosBLL

                FluxoDeCancelamentoDeAcordos.AtualizarFluxoAprovacao(DatasetFluxoAprovacao)
                Me.SetComplete()

            Catch ex As Martins.ExceptionManagement.BaseApplicationException
                Me.SetAbort()
                Throw ex
            Catch ex As Exception
                Me.SetAbort()
                Throw New Martins.ExceptionManagement.MartinsSystemException(ex.Message, ErrorConstants.SYSTEM_ERROR, ex)
            End Try
        End Sub

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
        Private Function ObterFuncionariosDaControladoriaAprovadoresDeFluxoDeCancelamentoDeAcordos() As DatasetFluxoCancelamentoAcordo
            Try
                Dim FluxoDeCancelamentoDeAcordos As New FluxoDeCancelamentoDeAcordosBLL
                Dim DatasetFluxoCancelamentoAcordo As New DatasetFluxoCancelamentoAcordo

                DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordos.ObterFuncionariosDaControladoriaAprovadoresDeFluxoDeCancelamentoDeAcordos
                Me.SetComplete()
                Return DatasetFluxoCancelamentoAcordo

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
        ''' 
        ''' </summary>
        ''' <param name="NUMPEDCNCACOCMC"></param>
        ''' <param name="emailDestinatario"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Danilo Rafael]	15/5/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Function EnviarEmailNaIniciacaoDoFluxoDeCancelamentoDeAcordo(ByVal NUMPEDCNCACOCMC As Decimal, _
                                                                             ByVal CODFRN As Decimal, _
                                                                             ByVal emailDestinatario As ArrayList) As Boolean
            Try
                Dim MensagemEletronica As New MensagemEletronicaBLL
                Dim dsMensagemEltronica As New MensagemEletronica.dataSetMensagemEletronica

                'Obter a transferencia verba
                Dim dsDatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                dsDatasetFluxoCancelamentoAcordo = Me.ObterFluxoCancelamentoAcordoPorChave(CODFRN, NUMPEDCNCACOCMC)
                If dsDatasetFluxoCancelamentoAcordo.T0154038.Rows.Count = 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Fluxo de Cancelamento não econtrado|", "")
                End If
                Dim T0154038Row As DatasetFluxoCancelamentoAcordo.T0154038Row
                T0154038Row = dsDatasetFluxoCancelamentoAcordo.T0154038(0)

                Dim emailRemetente As String = T0154038Row.NOMUSRSIS.ToLower.Trim & "@martins.com.br"

                ''''''''''''''''''''''''''''''''''
                'Inserindo a Capa da Mensagem
                ''''''''''''''''''''''''''''''''''
                Dim newRowCpa As MensagemEletronica.dataSetMensagemEletronica.T0134274Row
                newRowCpa = CType(dsMensagemEltronica.T0134274.NewRow, MensagemEletronica.dataSetMensagemEletronica.T0134274Row)
                newRowCpa.TIPMSGCREETN = 50
                newRowCpa.NUMSEQMSGCREETN = 0
                newRowCpa.SetDATENVMSGCREETNNull()
                newRowCpa.DESASSCREETN = "Fluxo de Cancelamento de Acordo"
                dsMensagemEltronica.T0134274.Rows.Add(newRowCpa)

                ''''''''''''''''''''''''''''''''''
                'Inserindo o Remetente da Mensagem
                ''''''''''''''''''''''''''''''''''
                Dim newRowRem As MensagemEletronica.dataSetMensagemEletronica.T0134282Row
                newRowRem = CType(dsMensagemEltronica.T0134282.NewRow, MensagemEletronica.dataSetMensagemEletronica.T0134282Row)
                newRowRem.TIPMSGCREETN = 50
                newRowRem.NUMSEQMSGCREETN = 0
                newRowRem.TIPENDCREETN = 1 'Remetente
                newRowRem.NUMSEQENDCREETN = 1
                newRowRem.IDTENDCREETN = emailRemetente
                dsMensagemEltronica.T0134282.Rows.Add(newRowRem)

                '''''''''''''''''''''''''''''''''''''
                'Inserindo o Destinatário da Mensagem
                '''''''''''''''''''''''''''''''''''''
                Dim NUMSEQENDCREETN As Long = 1
                For Each email As String In emailDestinatario
                    Dim newRowDst As MensagemEletronica.dataSetMensagemEletronica.T0134282Row
                    newRowDst = CType(dsMensagemEltronica.T0134282.NewRow, MensagemEletronica.dataSetMensagemEletronica.T0134282Row)
                    newRowDst.TIPMSGCREETN = 50
                    newRowDst.NUMSEQMSGCREETN = 0
                    newRowDst.TIPENDCREETN = 2 'Destinatário
                    newRowDst.NUMSEQENDCREETN = NUMSEQENDCREETN
                    newRowDst.IDTENDCREETN = email
                    dsMensagemEltronica.T0134282.Rows.Add(newRowDst)
                    NUMSEQENDCREETN += 1
                Next

                ''''''''''''''''''''''''''''''
                'Inserindo o Texto da Mensagem
                ''''''''''''''''''''''''''''''
                Dim lstTextoMensagem As New ArrayList
                lstTextoMensagem.Add("")
                lstTextoMensagem.Add("Sr(a),")
                lstTextoMensagem.Add("")
                lstTextoMensagem.Add("   O Fluxo de Cancelamento de Acordo - Nro " & NUMPEDCNCACOCMC.ToString & " Está aguardando sua avaliação/aprovação. Clique no link abaixo para dar sequência ao processo.")
                'lstTextoMensagem.Add("   http://SIM/AcoesComerciais/default.aspx?pagina=empenhoDoFornecedor&NUMPEDCNCACOCMC=" & NUMPEDCNCACOCMC.ToString)
                lstTextoMensagem.Add("   http://SIM/AcoesComerciais/default.aspx")
                lstTextoMensagem.Add("")
                lstTextoMensagem.Add("* MENSAGEM AUTOMATICA *")

                For i As Integer = 0 To lstTextoMensagem.Count - 1
                    Dim newRowTxt As MensagemEletronica.dataSetMensagemEletronica.T0134290Row
                    newRowTxt = CType(dsMensagemEltronica.T0134290.NewRow, MensagemEletronica.dataSetMensagemEletronica.T0134290Row)
                    newRowTxt.TIPMSGCREETN = 50
                    newRowTxt.NUMSEQMSGCREETN = 0
                    newRowTxt.NUMSEQLNHFISCREETN = i + 1
                    newRowTxt.DESTXTLNHFISCREETN = CStr(lstTextoMensagem.Item(i))
                    dsMensagemEltronica.T0134290.Rows.Add(newRowTxt)
                Next

                MensagemEletronica.AtualizarMensagemEletronica(dsMensagemEltronica)
                Me.SetComplete()

                Return True
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
        ''' 
        ''' </summary>
        ''' <param name="NUMPEDCNCACOCMC"></param>
        ''' <param name="CODFRN"></param>
        ''' <param name="CODFNC"></param>
        ''' <param name="DESOBSAPV"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Danilo Rafael]	16/5/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ReprovarFluxoCancelamentoAcordo(ByVal NUMPEDCNCACOCMC As Decimal, ByVal CODFRN As Decimal, ByVal CODFNC As Decimal, ByVal DESOBSAPV As String) As Boolean
            Try
                'Consulta Transferencia
                Dim dsDatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                dsDatasetFluxoCancelamentoAcordo = Me.ObterFluxoCancelamentoAcordoPorChave(CODFRN, NUMPEDCNCACOCMC)
                If dsDatasetFluxoCancelamentoAcordo.T0154038.Rows.Count = 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Acordo a Cancelar não econtrada|", "")
                End If

                'Obtem os fluxos de aprovação do funcionário
                Dim FluxoDeCancelamentoDeAcordos As New FluxoDeCancelamentoDeAcordosBLL
                Dim dsFluxoAprovacao As DatasetFluxoAprovacao
                dsFluxoAprovacao = FluxoDeCancelamentoDeAcordos.ObterFluxosAprovacao(CODFNC, 0, Constants.CODSISINF_FLUXO_DE_CANCELAMENTO_DE_ACORDO, String.Empty, String.Empty, NUMPEDCNCACOCMC, 0, 0, 0, Constants.TIPSTAFLUAPV_EM_APROVAÇÃO_EM_FLUXO_CANCELAMENTO_ACORDO)
                If dsFluxoAprovacao.T0161591.Rows.Count = 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Não encontrado fluxo pendente para funcionário|", "")
                End If

                'Reprova o fluxo
                For Each T0161591row As DatasetFluxoAprovacao.T0161591Row In dsFluxoAprovacao.T0161591
                    T0161591row.TIPSTAFLUAPV = Constants.TIPSTAFLUAPV_REJEITADO
                    T0161591row.DESOBSAPV = DESOBSAPV
                    T0161591row.DATHRAAPVFLU = Date.Now
                    If T0161591row.CODEDEAPV <> CODFNC Then
                        T0161591row.CODEDEARZ = CODFNC
                    End If
                Next

                'Persiste os dados do fluxo
                FluxoDeCancelamentoDeAcordos.AtualizarFluxoAprovacao(dsFluxoAprovacao)

                Dim T0154038Row As DatasetFluxoCancelamentoAcordo.T0154038Row
                T0154038Row = dsDatasetFluxoCancelamentoAcordo.T0154038(0)
                With T0154038Row
                    .CODSTAAPV = CType(Constants.CODSTAAPV_REJEITADO, Decimal)
                    .DATRPVCNCACOCMC = Date.Today
                End With

                AtualizarFluxoCancelamentoAcordo(dsDatasetFluxoCancelamentoAcordo)

                Me.SetComplete()
                Return True
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
        ''' 
        ''' </summary>
        ''' <param name="NUMPEDCNCACOCMC"></param>
        ''' <param name="CODFNC"></param>
        ''' <param name="CODFRN"></param>
        ''' <param name="DESOBSAPV"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Danilo Rafael]	19/5/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function AprovarFluxoCancelamentoAcordo(ByVal NUMPEDCNCACOCMC As Decimal, _
                                                       ByVal CODFNC As Decimal, _
                                                       ByVal CODFRN As Decimal, _
                                                       ByVal DESOBSAPV As String, _
                                                       ByVal NOMACSUSRSIS As String) As Boolean
            Try
                'Consulta Transferencia
                Dim email As New ArrayList
                Dim dsDatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo
                Dim AcordoComercial As New AcordoComercialBLL
                dsDatasetFluxoCancelamentoAcordo = Me.ObterFluxoCancelamentoAcordoPorChave(CODFRN, NUMPEDCNCACOCMC)
                If dsDatasetFluxoCancelamentoAcordo.T0154038.Rows.Count = 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Cancelamento de Acordo não econtrado|", "")
                End If

                'Obtem os fluxos de aprovação do funcionário
                Dim FluxoDeCancelamentoDeAcordos As New FluxoDeCancelamentoDeAcordosBLL
                Dim dsFluxoAprovacao As DatasetFluxoAprovacao
                dsFluxoAprovacao = FluxoDeCancelamentoDeAcordos.ObterFluxosAprovacao(CODFNC, 0, Constants.CODSISINF_FLUXO_DE_CANCELAMENTO_DE_ACORDO, String.Empty, String.Empty, NUMPEDCNCACOCMC, 0, 0, 0, Constants.TIPSTAFLUAPV_EM_APROVAÇÃO_EM_FLUXO_CANCELAMENTO_ACORDO)
                If dsFluxoAprovacao.T0161591.Rows.Count = 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Não encontrado fluxo pendente para funcionário|", "")
                End If

                'Declara variável que vai guardar o número da sequencia, 
                'essa informação é importante (e será utilizada mais a frente)
                'para identificar os gerentes que estão subordinados a um diretor,
                'por exemplo, gerente tem essse campo com valor 101,
                'o diretor desses gerente tem esse campo com valor = 201
                Dim NUMSEQNIVAPV As Decimal = 0

                'Guarda a data de liberação do fluxo, essa informação pode ser obtida em qualquer
                'linha da tabela T0161591
                Dim DATHRAFLUAPV As Date

                'Aprova o fluxo
                For Each T0161591row As DatasetFluxoAprovacao.T0161591Row In dsFluxoAprovacao.T0161591
                    T0161591row.TIPSTAFLUAPV = Constants.TIPSTAFLUAPV_APROVADO
                    T0161591row.DESOBSAPV = DESOBSAPV
                    T0161591row.DATHRAAPVFLU = Date.Now
                    If T0161591row.CODEDEAPV <> CODFNC Then
                        T0161591row.CODEDEARZ = CODFNC
                    End If
                    NUMSEQNIVAPV = T0161591row.NUMSEQNIVAPV
                    'Pega a data de liberação do fluxo, essa informação pode ser obtida em qualquer
                    'linha da tabela T0161591, logo ele busca aqui (linha do fluxo que está sendo aprovada)
                    DATHRAFLUAPV = T0161591row.DATHRAFLUAPV
                Next

                'Persiste os dados do fluxo
                FluxoDeCancelamentoDeAcordos.AtualizarFluxoAprovacao(dsFluxoAprovacao)

                'Verificar se todos fluxo foram aprovados, 
                'se for muda o status da tabela principal

                dsFluxoAprovacao = Me.ObterFluxosAprovacaoPendentes(0, 0, Constants.CODSISINF_FLUXO_DE_CANCELAMENTO_DE_ACORDO, String.Empty, String.Empty, NUMPEDCNCACOCMC, 0, 0, 0)
                Dim existeFluxoPendente As Boolean = (dsFluxoAprovacao.T0161591.Rows.Count > 0)

                'Se todos os fluxos foram aprovados aprova a tabela principal (capa)
                If Not existeFluxoPendente Then
                    'Consulta Transferencia
                    dsDatasetFluxoCancelamentoAcordo = Me.ObterFluxoCancelamentoAcordoPorChave(CODFRN, NUMPEDCNCACOCMC)
                    If dsDatasetFluxoCancelamentoAcordo.T0154038.Rows.Count = 0 Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Cancelamento de Acordo não econtrado|", "")
                    End If

                    Dim T0154038Row As DatasetFluxoCancelamentoAcordo.T0154038Row
                    T0154038Row = dsDatasetFluxoCancelamentoAcordo.T0154038(0)

                    With T0154038Row
                        .CODSTAAPV = CType(Constants.CODSTAAPV_APROVADO, Decimal)
                        .DATAPVCNCACOCMC = Date.Today
                    End With
                    AtualizarFluxoCancelamentoAcordo(dsDatasetFluxoCancelamentoAcordo)

                    'Efetivar o cancelmento do acordo
                    For Each T0154021Row As DatasetFluxoCancelamentoAcordo.T0154021Row In dsDatasetFluxoCancelamentoAcordo.T0154021
                        Dim ValorQuePodeSerCancelado As Decimal = T0154021Row.VLRNGCPMS - T0154021Row.VLRPGOPMS
                        'Verifica se o acordo já possui alguma quantia cancelada
                        'ObterAcordo
                        Dim dsAcordo As DatasetAcordo
                        dsAcordo = AcordoComercial.ObterAcordo(T0154021Row.CODEMP, T0154021Row.CODFILEMP, T0154021Row.CODPMS, T0154021Row.DATNGCPMS)

                        If (dsAcordo.T0120540.Rows.Count > 0) Or (T0154021Row.VLRSLDPMSFRN <> ValorQuePodeSerCancelado) Then
                            If T0154021Row.VLRSLDPMSFRN = ValorQuePodeSerCancelado Then
                                CancelarAcordoParcial(T0154021Row.CODEMP, T0154021Row.CODFILEMP, T0154021Row.CODPMS, T0154021Row.DATNGCPMS, T0154021Row.NUMPEDCNCACOCMC, T0154021Row.VLRSLDPMSFRN, NOMACSUSRSIS, T0154038Row.DESOBSCNCACOCMC, True)
                            Else
                                CancelarAcordoParcial(T0154021Row.CODEMP, T0154021Row.CODFILEMP, T0154021Row.CODPMS, T0154021Row.DATNGCPMS, T0154021Row.NUMPEDCNCACOCMC, T0154021Row.VLRSLDPMSFRN, NOMACSUSRSIS, T0154038Row.DESOBSCNCACOCMC, False)
                            End If
                        ElseIf T0154021Row.VLRSLDPMSFRN = ValorQuePodeSerCancelado Then
                            CancelarAcordoTotal(T0154021Row.CODEMP, T0154021Row.CODFILEMP, T0154021Row.CODPMS, T0154021Row.DATNGCPMS, T0154021Row.NUMPEDCNCACOCMC)
                        Else
                            Throw New Martins.ExceptionManagement.MartinsApplicationException("Erro na efetivação do cancelamento do acordo, verificar método: AprovarFluxoCancelamentoAcordo, comentário:Efetivar o cancelmento do acordo, a condição IF ou ELSE deveria ser verdadeira. Valores: dsAcordo.T0120540.Rows.Count =" & dsAcordo.T0120540.Rows.Count.ToString & " T0154021Row.VLRSLDPMSFRN=" & T0154021Row.VLRSLDPMSFRN.ToString & " ValorQuePodeSerCancelado=" & ValorQuePodeSerCancelado.ToString, "")
                        End If
                    Next

                    'Verifica se existe forma de pagamento igual a 13 e se o fluxo de acordo tem desconto em contas a pagar, atualiza MRT.T0128592
                    Dim dsAcordoACancelarEmFluxoCancelamentoAcordo As DatasetAcordoACancelarEmFluxoCancelamentoAcordo
                    dsAcordoACancelarEmFluxoCancelamentoAcordo = ObterAcordosParaCancelamentoPorNUMPEDCNCACOCMC(NUMPEDCNCACOCMC)
                    Dim dsTitulopagamentocontrato As DatasetTituloPagamentoContrato

                    For Each linha As DatasetAcordoACancelarEmFluxoCancelamentoAcordo.T0118066PesquisaRow In dsAcordoACancelarEmFluxoCancelamentoAcordo.T0118066Pesquisa
                        If Not linha.IsFLGSITNGCDUPNull Then
                            If linha.TIPFRMDSCBNF = 13 And linha.FLGSITNGCDUP = "I" Then
                                Dim T0128592Row As DatasetTituloPagamentoContrato.T0128592Row
                                dsTitulopagamentocontrato = AcordoComercial.ObterRelacaoTituloPagamentoContratoFornecedor(linha.CODPMS, linha.DATNGCPMS)
                                T0128592Row = dsTitulopagamentocontrato.T0128592(0)

                                With T0128592Row
                                    .FLGSITNGCDUP = "R"
                                    .NOMACSUSRSIS = NOMACSUSRSIS
                                End With
                            End If
                        End If
                    Next
                    If Not dsTitulopagamentocontrato Is Nothing Then
                        AcordoComercial.AtualizarTituloPagamentoContratoXContrato(dsTitulopagamentocontrato)
                    End If
                    'Me.SetComplete()
                    'Return True
                End If

                'Consulta todos os fluxo pendentes com o mesmo NUMSEQNIVAPV
                'esse campo indica todos gerentes subordinandos a um diretor específico
                If NUMSEQNIVAPV > 100 And NUMSEQNIVAPV < 200 Then 'Nesses casos é um gerente que está aprovando
                    dsFluxoAprovacao = Me.ObterFluxosAprovacaoPendentes(0, 0, Constants.CODSISINF_FLUXO_DE_CANCELAMENTO_DE_ACORDO, String.Empty, String.Empty, NUMPEDCNCACOCMC, 0, 0, NUMSEQNIVAPV)
                    If dsFluxoAprovacao.T0161591.Rows.Count = 0 Then
                        'Nesse caso não existe nenhum fluxo de gerente pendente
                        'consulta o diretor desse gerente para enviar e-mail
                        Dim dsFluxoDiretor As DatasetFluxoAprovacao
                        dsFluxoDiretor = Me.ObterFluxosAprovacaoPendentes(0, 0, Constants.CODSISINF_FLUXO_DE_CANCELAMENTO_DE_ACORDO, String.Empty, String.Empty, NUMPEDCNCACOCMC, 0, 0, NUMSEQNIVAPV + 100)
                        For Each T0161591rowFluxoDiretor As DatasetFluxoAprovacao.T0161591Row In dsFluxoDiretor.T0161591
                            'Consulta o diretor do fluxo

                            Dim dsFluxoAprovacaoDiretor As DatasetFluxoCancelamentoAcordo
                            dsFluxoAprovacaoDiretor = FluxoDeCancelamentoDeAcordos.ObterDiretorAprovadorDeFluxoFluxoDeCancelamentosDeAcordo(NUMPEDCNCACOCMC)
                            If dsFluxoAprovacaoDiretor.Funcionario.Rows.Count > 0 Then
                                'Altera o fluxo do diretor para "Em Aprovação"
                                T0161591rowFluxoDiretor.TIPSTAFLUAPV = Constants.TIPSTAFLUAPV_EM_APROVACAO
                                'Envia notificação para o diretor
                                email.Add(dsFluxoAprovacaoDiretor.Funcionario(0).NOMUSRRCF.ToLower.Trim & "@martins.com.br")
                                Me.EnviarEmailNaIniciacaoDoFluxoDeCancelamentoDeAcordo(NUMPEDCNCACOCMC, CODFRN, email)

                            End If
                        Next
                        If Not dsFluxoDiretor.GetChanges Is Nothing Then
                            FluxoDeCancelamentoDeAcordos.AtualizarFluxoAprovacao(dsFluxoDiretor)
                        End If
                    End If
                End If

                'Verifica se todos fluxos foram aprovados, exceto o da controladoria
                Dim PendenteSomenteFluxoControladoria As Boolean = True
                dsFluxoAprovacao = Me.ObterFluxosAprovacaoPendentes(0, 0, Constants.CODSISINF_FLUXO_DE_CANCELAMENTO_DE_ACORDO, String.Empty, String.Empty, NUMPEDCNCACOCMC, 0, 0, 0)
                For Each T0161591row As DatasetFluxoAprovacao.T0161591Row In dsFluxoAprovacao.T0161591
                    If T0161591row.NUMSEQNIVAPV < Constants.NUMSEQNIVAPV_PRIMEIRO_FLUXO_CONTROLADORIA Then
                        PendenteSomenteFluxoControladoria = False
                        Exit For
                    End If
                Next

                If PendenteSomenteFluxoControladoria And dsFluxoAprovacao.T0161591.Rows.Count > 0 Then
                    'Encontrar o fluxo da vez, começa a procurar com o valor da constant NUMSEQNIVAPV_PRIMEIRO_FLUXO_CONTROLADORIA
                    'se não encontrar continua procurando, sempre incrementando 100
                    Dim NumSeqNivApvAProcurar As Decimal = Constants.NUMSEQNIVAPV_PRIMEIRO_FLUXO_CONTROLADORIA
                    Dim dsFluxoControladoria As DatasetFluxoAprovacao
                    'Laço que vai pesquisar um determinado número de fluxo, se 
                    Do While True
                        dsFluxoControladoria = Me.ObterFluxosAprovacaoPendentes(0, 0, Constants.CODSISINF_FLUXO_DE_CANCELAMENTO_DE_ACORDO, String.Empty, String.Empty, NUMPEDCNCACOCMC, 0, 0, NumSeqNivApvAProcurar)
                        If dsFluxoControladoria.T0161591.Rows.Count > 0 Then
                            'Altera o status do fluxo para em aprovação
                            Dim T0161591rowFluxoControladoria As DatasetFluxoAprovacao.T0161591Row
                            T0161591rowFluxoControladoria = dsFluxoControladoria.T0161591(0)

                            T0161591rowFluxoControladoria.TIPSTAFLUAPV = Constants.TIPSTAFLUAPV_EM_APROVACAO
                            FluxoDeCancelamentoDeAcordos.AtualizarFluxoAprovacao(dsFluxoControladoria)
                            'Envia e-mail

                            Dim dsContaUsuario As DatasetContaUsuario
                            dsContaUsuario = AcordoComercial.ObterContaUsuario(T0161591rowFluxoControladoria.CODEDEAPV)
                            If dsContaUsuario.T0104596.Rows.Count > 0 Then
                                Dim T0104596Row As DatasetContaUsuario.T0104596Row
                                T0104596Row = dsContaUsuario.T0104596(0)
                                email.Add(T0104596Row.NOMUSRRCF.ToLower.Trim & "@martins.com.br")
                                Me.EnviarEmailNaIniciacaoDoFluxoDeCancelamentoDeAcordo(NUMPEDCNCACOCMC, CODFRN, email)
                            End If
                            Exit Do
                        End If
                        NumSeqNivApvAProcurar += 100
                    Loop
                End If

                Me.SetComplete()
                Return True
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
        ''' 
        ''' </summary>
        ''' <param name="CODEMP"></param>
        ''' <param name="CODFILEMP"></param>
        ''' <param name="CODPMS"></param>
        ''' <param name="DATNGCPMS"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Danilo Rafael]	19/5/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub CancelarAcordoTotal(ByVal CODEMP As Decimal, _
                                        ByVal CODFILEMP As Decimal, _
                                        ByVal CODPMS As Decimal, _
                                        ByVal DATNGCPMS As Date, _
                                        ByVal NUMPEDCNCACOCMC As Decimal)
            Try
                Dim dsAcordoComercial As DatasetAcordo
                Dim AcordoComercial As New AcordoComercialBLL

                dsAcordoComercial = AcordoComercial.ObterAcordo(CODEMP, _
                                                                CODFILEMP, _
                                                                CODPMS, _
                                                                DATNGCPMS)

                If dsAcordoComercial.T0118058.Rows.Count = 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Não foi encontrado acordo " & CODPMS.ToString & " para efetivação do cancelamento|", "")
                End If

                Dim T0118058Row As DatasetAcordo.T0118058Row
                T0118058Row = dsAcordoComercial.T0118058(0)

                T0118058Row.CODSITPMS = 4
                AcordoComercial.AtualizarAcordo(dsAcordoComercial, False)

                Me.SetComplete()
            Catch ex As Martins.ExceptionManagement.BaseApplicationException
                Me.SetAbort()
                Throw ex
            Catch ex As Exception
                Me.SetAbort()
                Throw New Martins.ExceptionManagement.MartinsSystemException(ex.Message, ErrorConstants.SYSTEM_ERROR, ex)
            End Try
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Cancelamento Acordo (quando o cancelamento é parcial)
        ''' </summary>
        ''' <param name="CODEMP"></param>
        ''' <param name="CODFILEMP"></param>
        ''' <param name="CODPMS"></param>
        ''' <param name="DATNGCPMS"></param>
        ''' <param name="NUMPEDCNCACOCMC"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	20/6/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub CancelarAcordoParcial(ByVal CODEMP As Decimal, _
                                          ByVal CODFILEMP As Decimal, _
                                          ByVal CODPMS As Decimal, _
                                          ByVal DATNGCPMS As Date, _
                                          ByVal NUMPEDCNCACOCMC As Decimal, _
                                          ByVal VLRSLDPMSFRN As Decimal, _
                                          ByVal NOMACSUSRSIS As String, _
                                          ByVal DESOBSCNCACOCMC As String, _
                                          ByVal FinalizarAcordo As Boolean)
            Try
                Dim dsAcordoComercial As DatasetAcordo
                Dim AcordoComercial As New AcordoComercialBLL

                dsAcordoComercial = AcordoComercial.ObterAcoesComerciaisBaixa(CODPMS, _
                                                                              CODFILEMP, _
                                                                              1, _
                                                                              1, _
                                                                              Nothing, _
                                                                              Nothing, _
                                                                              1)

                If dsAcordoComercial.TbAcoesComerciaisBaixa.Rows.Count = 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Não foi encontrado acordo " & CODPMS.ToString & " para efetivação do cancelamento (Baixa Parcial)|", "")
                End If

                Dim AcoesComerciaisBaixaRow As DatasetAcordo.TbAcoesComerciaisBaixaRow
                AcoesComerciaisBaixaRow = dsAcordoComercial.TbAcoesComerciaisBaixa(0)

                Dim valorLimite As Decimal = AcoesComerciaisBaixaRow.vlreftpms - AcoesComerciaisBaixaRow.vlrpgopms
                If valorLimite = 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Não é possível informar valor de perda para acordo: " & CODPMS.ToString & "|", "")
                End If

                Dim valorPerdaAtual As Decimal = 0
                valorPerdaAtual = VLRSLDPMSFRN

                Dim VlrPgoAlt As Decimal
                VlrPgoAlt = AcoesComerciaisBaixaRow.vlrpgopms + valorPerdaAtual

                If valorLimite < valorPerdaAtual Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Valor da perda deve ser menor que a diferença entre valor efetivado e o valor pago informado, acordo: " & CODPMS.ToString & "|", "")
                End If

                'Consulta a acordo comercial que será alterado
                dsAcordoComercial.Merge(AcordoComercial.ObterAcordo(CODEMP, _
                                                                    CODFILEMP, _
                                                                    CODPMS, _
                                                                    DATNGCPMS))
                Dim linhaT0118066 As DatasetAcordo.T0118066Row
                linhaT0118066 = dsAcordoComercial.T0118066.FindByCODEMPCODFILEMPCODPMSDATPRVRCBPMSTIPFRMDSCBNFTIPDSNDSCBNFDATNGCPMS(CODEMP, CODFILEMP, CODPMS, AcoesComerciaisBaixaRow.datprvrcbpms, AcoesComerciaisBaixaRow.tipfrmdscbnf, AcoesComerciaisBaixaRow.tipdsndscbnf, DATNGCPMS)
                If linhaT0118066 Is Nothing Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Não econtrado acordo: " & CODPMS.ToString & "|", "")
                End If

                'Atualiza os valores
                With linhaT0118066
                    .BeginEdit()
                    .VLRPGOPMS = VlrPgoAlt
                    If .IsNull("VLRPDAPMS") Then .VLRPDAPMS = 0
                    .VLRPDAPMS = .VLRPDAPMS + valorPerdaAtual
                    .EndEdit()
                End With

                Dim linhaT0120540 As DatasetAcordo.T0120540Row
                linhaT0120540 = dsAcordoComercial.T0120540.NewT0120540Row
                With linhaT0120540
                    .CodEmp = CODEMP
                    .CodFilEmp = CODFILEMP
                    .CodPms = CODPMS
                    .DatNgcPms = DATNGCPMS
                    .DatPrvRcbPms = AcoesComerciaisBaixaRow.datprvrcbpms
                    .TipFrmDscBnf = AcoesComerciaisBaixaRow.tipfrmdscbnf
                    .TipDsnDscBnf = AcoesComerciaisBaixaRow.tipdsndscbnf
                    .NumUltAltPms = 0
                    .DatAltPms = Date.Today
                    .VlrPgoPmsAnt = AcoesComerciaisBaixaRow.vlrpgopms
                    .VlrPgoPms = VlrPgoAlt
                    .NomAcsUsrSis = NOMACSUSRSIS
                    .FlgLstPlhLmt = "P"
                    .VlrLstPlhLmt = 0
                    If AcoesComerciaisBaixaRow.IsvlrpdapmsNull Then
                        .VlrPdaPmsAnt = 0
                    Else
                        .VlrPdaPmsAnt = AcoesComerciaisBaixaRow.vlrpdapms
                    End If

                    .DESJSTCNCVLRARDCMC = DESOBSCNCACOCMC
                End With
                dsAcordoComercial.T0120540.AddT0120540Row(linhaT0120540)

                If dsAcordoComercial.T0118058.Rows.Count = 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Não foi encontrado acordo " & CODPMS.ToString & " para efetivação do cancelamento|", "")
                End If

                Dim T0118058Row As DatasetAcordo.T0118058Row
                T0118058Row = dsAcordoComercial.T0118058(0)

                If FinalizarAcordo Then
                    T0118058Row.CODSITPMS = 4
                    AcordoComercial.AtualizarAcordo(dsAcordoComercial, False)
                Else
                    T0118058Row.CODSITPMS = 1
                    AcordoComercial.AtualizarAcordo(dsAcordoComercial)
                End If

                Me.SetComplete()
            Catch ex As Martins.ExceptionManagement.BaseApplicationException
                Me.SetAbort()
                Throw ex
            Catch ex As Exception
                Me.SetAbort()
                Throw New Martins.ExceptionManagement.MartinsSystemException(ex.Message, ErrorConstants.SYSTEM_ERROR, ex)
            End Try
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="NUMPEDCNCACOCMC"></param>
        ''' <param name="CODFRN"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Danilo Rafael]	20/5/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ClonarFluxoCancelamentoAcordoFornecedor(ByVal NUMPEDCNCACOCMC As Decimal, ByVal CODFRN As Decimal) As Decimal
            Try
                Dim FluxoDeCancelamentoDeAcordos As New FluxoDeCancelamentoDeAcordosBLL
                Dim ProximoNUMPEDCNCACOCMC As Decimal

                'Obtem o código da proxima transferencia
                ProximoNUMPEDCNCACOCMC = Me.ObterNovaChaveFluxoCancelamento

                'Consulta a transferencia de origem
                Dim dsDatasetFluxoCancelamentoAcordoOrigem As DatasetFluxoCancelamentoAcordo
                dsDatasetFluxoCancelamentoAcordoOrigem = Me.ObterFluxoCancelamentoAcordoPorChave(CODFRN, NUMPEDCNCACOCMC)

                'Prepara o dataset de destino
                Dim dsDatasetFluxoCancelamentoAcordoDestino As New DatasetFluxoCancelamentoAcordo

                'Copia os dados da origem para o destino (Tabela cadastro)
                For Each T0154038Row As DatasetFluxoCancelamentoAcordo.T0154038Row In dsDatasetFluxoCancelamentoAcordoOrigem.T0154038

                    dsDatasetFluxoCancelamentoAcordoDestino.T0154038.AddT0154038Row(ProximoNUMPEDCNCACOCMC, _
                                                                                    CODFRN, _
                                                                                    Nothing, _
                                                                                    Constants.CODSTAAPV_NOVO, _
                                                                                    Nothing, _
                                                                                    T0154038Row.DESOBSCNCACOCMC, _
                                                                                    T0154038Row.NOMUSRSIS, _
                                                                                    T0154038Row.DATGRCCNCACOCMC, _
                                                                                    Nothing, _
                                                                                    Nothing)
                Next

                'Copia os dados da origem para o destino (Relacao)
                For Each T0154021Row As DatasetFluxoCancelamentoAcordo.T0154021Row In dsDatasetFluxoCancelamentoAcordoOrigem.T0154021
                    dsDatasetFluxoCancelamentoAcordoDestino.T0154021.AddT0154021Row(ProximoNUMPEDCNCACOCMC, _
                                                                                    T0154021Row.CODPMS, _
                                                                                    T0154021Row.CODEMP, _
                                                                                    T0154021Row.CODFILEMP, _
                                                                                    T0154021Row.DATNGCPMS, _
                                                                                    T0154021Row.DATPRVRCBPMS, _
                                                                                    T0154021Row.TIPFRMDSCBNF, _
                                                                                    T0154021Row.TIPDSNDSCBNF, _
                                                                                    T0154021Row.VLRNGCPMS, _
                                                                                    T0154021Row.VLRPGOPMS, _
                                                                                    T0154021Row.VLRSLDPMSFRN)
                Next

                Me.AtualizarFluxoCancelamentoAcordo(dsDatasetFluxoCancelamentoAcordoDestino)
                Me.SetComplete()
                Return ProximoNUMPEDCNCACOCMC
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