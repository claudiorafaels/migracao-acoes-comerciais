Imports Martins.Data.TransactionManagement
Imports Martins.Security.Helper
Imports Martins.Compras.AcoesComerciais.ContaCorrenteFornecedor
Imports Martins.Compras.AcoesComerciais.ContaCorrenteFornecedor.BLL
Imports Martins.Compras.AcoesComerciais.AcordoFornecimento
Imports Martins.Compras.AcoesComerciais.AcordoFornecimento.BP
Imports Martins.Compras.AcoesComerciais.AcordoFornecimento.BLL
Imports Martins.Compras.AcoesComerciais.MensagemEletronica
Imports Martins.Compras.AcoesComerciais.MensagemEletronica.BLL
Imports Martins.Compras.AcoesComerciais.Gestao
Imports Martins.Compras.AcoesComerciais.Gestao.BLL
Imports Martins.Administracao.CadastramentoFornecedores.DivisaoFornecedor
Imports Martins.Administracao.CadastramentoFornecedores.DivisaoFornecedor.BLL

Namespace BP
    ''' -----------------------------------------------------------------------------
    ''' Project   : Martins.Compras.AcoesComerciais.ContaCorrenteFornecedor
    ''' Class     : ContaCorrenteFornecedorBP
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Classe BP da entidade com objetivo: chegar segurança e repassar a chamada para a classe BLL
    ''' </summary>
    ''' <remarks>
    '''
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class ContaCorrenteFornecedorBP
        Inherits BPClass

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade T0123086 com base na sua chave primária.
        ''' Descrição da entidade:MOVIMENTO DIARIO CONTA CORRENTE FORNECEDOR
        ''' </summary>
        ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
        ''' <param name="CODGDC">CODIGO CONTROLE TRANSACAO CABECALHO DE UM LANCAMENTO.</param>
        ''' <param name="DATREFLMT">DATA REFERENCIA (AAAA-MM-DD).</param>
        ''' <param name="NUMSEQLMT">NUMERO SEQUENCIA.</param>
        ''' <param name="TIPDSNDSCBNF">TIPO DESTINO / DESCONTO BONIFICADO.</param>
        ''' <returns>Retorna um DataSet com a tabela "T0123086" preenchida.</returns>
        ''' <remarks>
        ''' Sempre que um código inválido for informado, uma exception será retornada.
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    12/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterContaCorrenteFornecedor(ByVal CODFRN As Decimal, _
                                                     ByVal CODGDC As String, _
                                                     ByVal DATREFLMT As Date, _
                                                     ByVal NUMSEQLMT As Decimal, _
                                                     ByVal TIPDSNDSCBNF As Decimal) As DatasetContaCorrenteFornecedor
            Try

                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL

                Dim DatasetContaCorrenteFornecedor As DatasetContaCorrenteFornecedor
                DatasetContaCorrenteFornecedor = ContaCorrenteFornecedor.ObterContaCorrenteFornecedor(CODFRN, CODGDC, DATREFLMT, NUMSEQLMT, TIPDSNDSCBNF)

                Dim configuracao As Martins.ConfigurationManagement.MartinsApplicationConfiguration
                configuracao = CType(Martins.ConfigurationManagement.ConfigurationManager.Read(Martins.ConfigurationManagement.ConfigurationManager.GetDefaultSection()), Martins.ConfigurationManagement.MartinsApplicationConfiguration)

                Me.SetComplete()
                Return DatasetContaCorrenteFornecedor

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
        ''' Este método retorna dados da entidade T0123086 com base em outros atributos.
        ''' Descrição da entidade:MOVIMENTO DIARIO CONTA CORRENTE FORNECEDOR
        ''' </summary>
        ''' <param name="CODCENCSTCRD">CODIGO CENTRO DE CUSTRO DE CREDITO.</param>
        ''' <param name="CODCENCSTDEB">CODIGO CENTRO DE CUSTRO DE DEBITO.</param>
        ''' <param name="CODCNTCRD">CODIGO CONTA CONTABIL.</param>
        ''' <param name="CODCNTDEB">CODIGO CONTA CONTABIL.</param>
        ''' <param name="CODFILEMP">CODIGO DA FILIAL DA EMPRESA.</param>
        ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
        ''' <param name="CODGDC">CODIGO CONTROLE TRANSACAO CABECALHO DE UM LANCAMENTO.</param>
        ''' <param name="CODPMS">CODIGO PROMESSA.</param>
        ''' <param name="CODTIPLMT">CODIGO TIPO LANCAMENTO.</param>
        ''' <param name="DATREFLMT">DATA REFERENCIA (AAAA-MM-DD).</param>
        ''' <param name="DATREFLMTInicial">DATA REFERENCIA (AAAA-MM-DD) INICIAL.</param>
        ''' <param name="DATREFLMTFinal">DATA REFERENCIA (AAAA-MM-DD) FINAL.</param>
        ''' <param name="DESHSTLMT">DESCRICAO DO HISTORICO CONTA CORRENTE.</param>
        ''' <param name="DESVARHSTPAD">DESCRICAO DA VARIAVEL DO HISTORICO PADRAO.</param>
        ''' <param name="NUMSEQLMT">NUMERO SEQUENCIA.</param>
        ''' <param name="TIPDSNDSCBNF">TIPO DESTINO / DESCONTO BONIFICADO.</param>
        ''' <returns>Retorna um DataSet com a tabela "T0123086" preenchida.</returns>
        ''' <remarks>
        ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
        ''' Um parametro do tipo número é omitido quando for zero,
        ''' Um parametro do tipo String é omitido quando for vazia,
        ''' Um parametro do tipo data   é omitido quando for Nothing,
        ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    12/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterContasCorrenteFornecedor(ByVal CODCENCSTCRD As String, _
                                                      ByVal CODCENCSTDEB As String, _
                                                      ByVal CODCNTCRD As String, _
                                                      ByVal CODCNTDEB As String, _
                                                      ByVal CODFILEMP As Decimal, _
                                                      ByVal CODFRN As Decimal, _
                                                      ByVal CODGDC As String, _
                                                      ByVal CODPMS As Decimal, _
                                                      ByVal CODTIPLMT As Decimal, _
                                                      ByVal DATREFLMT As Date, _
                                                      ByVal DATREFLMTInicial As Date, _
                                                      ByVal DATREFLMTFinal As Date, _
                                                      ByVal DESHSTLMT As String, _
                                                      ByVal DESVARHSTPAD As String, _
                                                      ByVal NUMSEQLMT As Decimal, _
                                                      ByVal TIPDSNDSCBNF As Decimal) As DatasetContaCorrenteFornecedor
            Try
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL
                
                Dim DatasetContaCorrenteFornecedor As DatasetContaCorrenteFornecedor
                DatasetContaCorrenteFornecedor = ContaCorrenteFornecedor.ObterContasCorrenteFornecedor(CODCENCSTCRD, CODCENCSTDEB, CODCNTCRD, CODCNTDEB, CODFILEMP, CODFRN, CODGDC, CODPMS, CODTIPLMT, DATREFLMT, DATREFLMTInicial, DATREFLMTFinal, DESHSTLMT, DESVARHSTPAD, NUMSEQLMT, TIPDSNDSCBNF)

                Me.SetComplete()
                Return DatasetContaCorrenteFornecedor

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
        ''' <param name="DatasetContaCorrenteFornecedor">DataSet com os dados a serem atualizados</param>
        ''' <remarks>
        ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    12/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Sub AtualizarContaCorrenteFornecedor(ByVal DatasetContaCorrenteFornecedor As DatasetContaCorrenteFornecedor)
            Try

                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL
                
                ContaCorrenteFornecedor.AtualizarContaCorrenteFornecedor(DatasetContaCorrenteFornecedor)
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
        ''' Este método retorna dados da entidade T0123094 com base na sua chave primária.
        ''' Descrição da entidade:PARAMETRO CONTABIL CONTA CORRENTE FORNECEDOR
        ''' </summary>
        ''' <param name="CODFILEMP">CODIGO DA FILIAL DA EMPRESA.</param>
        ''' <param name="CODTIPLMT">CODIGO TIPO LANCAMENTO.</param>
        ''' <returns>Retorna um DataSet com a tabela "T0123094" preenchida.</returns>
        ''' <remarks>
        ''' Sempre que um código inválido for informado, uma exception será retornada.
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    12/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterParametroContabilContaCorrenteFornecedor(ByVal CODFILEMP As Decimal, _
                                                                      ByVal CODTIPLMT As Decimal) As DatasetParametroContabilContaCorrenteFornecedor
            Try

                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL

                Dim DatasetParametroContabilContaCorrenteFornecedor As DatasetParametroContabilContaCorrenteFornecedor
                DatasetParametroContabilContaCorrenteFornecedor = ContaCorrenteFornecedor.ObterParametroContabilContaCorrenteFornecedor(CODFILEMP, CODTIPLMT)

                Dim configuracao As Martins.ConfigurationManagement.MartinsApplicationConfiguration
                configuracao = CType(Martins.ConfigurationManagement.ConfigurationManager.Read(Martins.ConfigurationManagement.ConfigurationManager.GetDefaultSection()), Martins.ConfigurationManagement.MartinsApplicationConfiguration)

                Me.SetComplete()
                Return DatasetParametroContabilContaCorrenteFornecedor

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
        ''' Este método retorna dados da entidade T0123094 com base em outros atributos.
        ''' Descrição da entidade:PARAMETRO CONTABIL CONTA CORRENTE FORNECEDOR
        ''' </summary>
        ''' <param name="CODCENCSTCRD">.</param>
        ''' <param name="CODCENCSTDEB">.</param>
        ''' <param name="CODCNTCRD">CODIGO CONTA CONTABIL.</param>
        ''' <param name="CODCNTDEB">CODIGO CONTA CONTABIL.</param>
        ''' <param name="CODEVTCTB">CODIGO EVENTO CONTABIL - COFINS.</param>
        ''' <param name="CODEVTCTBFRTDVL">CODIGO EVENTO CONTABIL DO FRETE DE DEVOLUCAO.</param>
        ''' <param name="CODEVTCTBNGCDVL">CODIGO EVENTO CONTABIL DE NEGOCIACAO DE DEVOLUCAO.</param>
        ''' <param name="CODFILEMP">CODIGO DA FILIAL DA EMPRESA.</param>
        ''' <param name="CODFTOCTB">CODIGO FATO CONTABIL.</param>
        ''' <param name="CODFTOCTBFRTDVL">CODIGO FATO CONTABIL DO FRETE DE DEVOLUCAO.</param>
        ''' <param name="CODFTOCTBNGCDVL">CODIGO FATO CONTABIL DE NEGOCIACAO DE DEVOLUCAO.</param>
        ''' <param name="CODHSTPAD">CODIGO HISTORICO PADRAO.</param>
        ''' <param name="CODTIPLMT">CODIGO TIPO LANCAMENTO.</param>
        ''' <returns>Retorna um DataSet com a tabela "T0123094" preenchida.</returns>
        ''' <remarks>
        ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
        ''' Um parametro do tipo número é omitido quando for zero,
        ''' Um parametro do tipo String é omitido quando for vazia,
        ''' Um parametro do tipo data   é omitido quando for Nothing,
        ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    12/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterParametrosContabilContaCorrenteFornecedor(ByVal CODCENCSTCRD As String, _
                                                                       ByVal CODCENCSTDEB As String, _
                                                                       ByVal CODCNTCRD As String, _
                                                                       ByVal CODCNTDEB As String, _
                                                                       ByVal CODEVTCTB As Decimal, _
                                                                       ByVal CODEVTCTBFRTDVL As Decimal, _
                                                                       ByVal CODEVTCTBNGCDVL As Decimal, _
                                                                       ByVal CODFILEMP As Decimal, _
                                                                       ByVal CODFTOCTB As Decimal, _
                                                                       ByVal CODFTOCTBFRTDVL As Decimal, _
                                                                       ByVal CODFTOCTBNGCDVL As Decimal, _
                                                                       ByVal CODHSTPAD As String, _
                                                                       ByVal CODTIPLMT As Decimal) As DatasetParametroContabilContaCorrenteFornecedor
            Try
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL
                
                Dim DatasetParametroContabilContaCorrenteFornecedor As DatasetParametroContabilContaCorrenteFornecedor
                DatasetParametroContabilContaCorrenteFornecedor = ContaCorrenteFornecedor.ObterParametrosContabilContaCorrenteFornecedor(CODCENCSTCRD, CODCENCSTDEB, CODCNTCRD, CODCNTDEB, CODEVTCTB, CODEVTCTBFRTDVL, CODEVTCTBNGCDVL, CODFILEMP, CODFTOCTB, CODFTOCTBFRTDVL, CODFTOCTBNGCDVL, CODHSTPAD, CODTIPLMT)

                Me.SetComplete()
                Return DatasetParametroContabilContaCorrenteFornecedor

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
        ''' <param name="DatasetParametroContabilContaCorrenteFornecedor">DataSet com os dados a serem atualizados</param>
        ''' <remarks>
        ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    12/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Sub AtualizarParametroContabilContaCorrenteFornecedor(ByVal DatasetParametroContabilContaCorrenteFornecedor As DatasetParametroContabilContaCorrenteFornecedor)
            Try

                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL
                
                ContaCorrenteFornecedor.AtualizarParametroContabilContaCorrenteFornecedor(DatasetParametroContabilContaCorrenteFornecedor)
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
        ''' Este método retorna dados da entidade T0123108 com base na sua chave primária.
        ''' Descrição da entidade:CADASTRO TIPO LANCAMENTO CONTA CORRENTE FORNECEDOR
        ''' </summary>
        ''' <param name="CODTIPLMT">CODIGO TIPO LANCAMENTO.</param>
        ''' <returns>Retorna um DataSet com a tabela "T0123108" preenchida.</returns>
        ''' <remarks>
        ''' Sempre que um código inválido for informado, uma exception será retornada.
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    12/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterTipoLancamentoContaCorrenteFornecedor(ByVal CODTIPLMT As Decimal) As DatasetTipoLancamentoContaCorrenteFornecedor
            Try

                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL

                Dim DatasetTipoLancamentoContaCorrenteFornecedor As DatasetTipoLancamentoContaCorrenteFornecedor
                DatasetTipoLancamentoContaCorrenteFornecedor = ContaCorrenteFornecedor.ObterTipoLancamentoContaCorrenteFornecedor(CODTIPLMT)

                Dim configuracao As Martins.ConfigurationManagement.MartinsApplicationConfiguration
                configuracao = CType(Martins.ConfigurationManagement.ConfigurationManager.Read(Martins.ConfigurationManagement.ConfigurationManager.GetDefaultSection()), Martins.ConfigurationManagement.MartinsApplicationConfiguration)

                Me.SetComplete()
                Return DatasetTipoLancamentoContaCorrenteFornecedor

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
        ''' Este método retorna dados da entidade T0123108 com base em outros atributos.
        ''' Descrição da entidade:CADASTRO TIPO LANCAMENTO CONTA CORRENTE FORNECEDOR
        ''' </summary>
        ''' <param name="DESTIPLMT">DESCRICAO DO TIPO DE LANCAMENTO.</param>
        ''' <param name="DESTIPLMTFRN">DESCRICAO DO TIPO DE LANCAMENTO FORNECEDOR.</param>
        ''' <returns>Retorna um DataSet com a tabela "T0123108" preenchida.</returns>
        ''' <remarks>
        ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
        ''' Um parametro do tipo número é omitido quando for zero,
        ''' Um parametro do tipo String é omitido quando for vazia,
        ''' Um parametro do tipo data   é omitido quando for Nothing,
        ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    12/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterTiposLancamentoContaCorrenteFornecedor(ByVal DESTIPLMT As String, _
                                                                    ByVal DESTIPLMTFRN As String) As DatasetTipoLancamentoContaCorrenteFornecedor
            Try
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL
                
                Dim DatasetTipoLancamentoContaCorrenteFornecedor As DatasetTipoLancamentoContaCorrenteFornecedor
                DatasetTipoLancamentoContaCorrenteFornecedor = ContaCorrenteFornecedor.ObterTiposLancamentoContaCorrenteFornecedor(DESTIPLMT, DESTIPLMTFRN)

                Me.SetComplete()
                Return DatasetTipoLancamentoContaCorrenteFornecedor

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
        ''' Este método retorna os registros para tabela T062251 com base na sua chave primária.
        ''' Descrição da entidade:RELACAO TIPO DE LANÇAMENTO PRINCIPAL X TIPO LANÇAMENTO ASSOCIADO
        ''' </summary>
        ''' <param name="CODTIPLMTASC">CODIGO TIPO LANCAMENTO ASSOCIADO.</param>
        ''' <param name="CODTIPLMTPCP">CODIGO TIPO LANCAMENTO PRINCIPAL.</param>
        ''' <returns>Retorna um DataSet com a tabela "T062251" preenchida.</returns>
        ''' <remarks>
        ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
        ''' Um parametro do tipo número é omitido quando for zero,
        ''' Um parametro do tipo String é omitido quando for vazia,
        ''' Um parametro do tipo data   é omitido quando for Nothing,
        ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
        ''' </remarks>
        ''' <history>
        '''     [Elifázio Bernardes]    23/08/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterTipoLancamentoPrincipalXTipoLancamentoAssociado(ByVal CODTIPLMTASC As Decimal, _
                                                                             ByVal CODTIPLMTPCP As Decimal) As DatasetTipoLancamentoContaCorrenteFornecedor
            Try
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL

                Dim DatasetTipoLancamentoContaCorrenteFornecedor As DatasetTipoLancamentoContaCorrenteFornecedor
                DatasetTipoLancamentoContaCorrenteFornecedor = ContaCorrenteFornecedor.ObterTipoLancamentoPrincipalXTipoLancamentoAssociado(CODTIPLMTASC, CODTIPLMTPCP)

                Me.SetComplete()
                Return DatasetTipoLancamentoContaCorrenteFornecedor

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
        ''' <param name="DatasetTipoLancamentoContaCorrenteFornecedor">DataSet com os dados a serem atualizados</param>
        ''' <remarks>
        ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    12/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Sub AtualizarTipoLancamentoContaCorrenteFornecedor(ByVal DatasetTipoLancamentoContaCorrenteFornecedor As DatasetTipoLancamentoContaCorrenteFornecedor)
            Try

                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL

                ContaCorrenteFornecedor.AtualizarTipoLancamentoContaCorrenteFornecedor(DatasetTipoLancamentoContaCorrenteFornecedor)
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
        ''' Este método retorna dados da entidade CADTRNVBAFRN com base na sua chave primária.
        ''' Descrição da entidade:CADASTRO DE TRANSFERENCIA VERBAS FORNECEDOR
        ''' </summary>
        ''' <param name="NUMFLUAPV">NUMERO FLUXO DE APROVACAO.</param>
        ''' <returns>Retorna um DataSet com a tabela "CADTRNVBAFRN" preenchida.</returns>
        ''' <remarks>
        ''' Sempre que um código inválido for informado, uma exception será retornada.
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    27/11/2007  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterTransferenciaVerbaFornecedor(ByVal NUMFLUAPV As Decimal) As DatasetTransferenciaVerbaFornecedor
            Try

                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor

                'Obtem a tabela principal
                DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedor.ObterTransferenciaVerbaFornecedor(NUMFLUAPV)

                'Obtem a relação
                If Not DatasetTransferenciaVerbaFornecedor Is Nothing Then
                    DatasetTransferenciaVerbaFornecedor.Merge(ContaCorrenteFornecedor.ObterRelacoesTransferenciaVerbaFornecedor(0, NUMFLUAPV, 0, 0))
                Else
                    DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedor.ObterRelacoesTransferenciaVerbaFornecedor(0, NUMFLUAPV, 0, 0)
                End If

                'Obtem a relação fazendo join com outras tabelas, visão ideal para mostrar em um grid
                If Not DatasetTransferenciaVerbaFornecedor Is Nothing Then
                    DatasetTransferenciaVerbaFornecedor.Merge(ContaCorrenteFornecedor.ObterRelacaoTransferenciaVerbaFornecedorJoinT0153541JoinT0100426JoinT0113625JoinT0118570JoinT0109059(NUMFLUAPV))
                Else
                    DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedor.ObterRelacaoTransferenciaVerbaFornecedorJoinT0153541JoinT0100426JoinT0113625JoinT0118570JoinT0109059(NUMFLUAPV)
                End If

                'Dependendo do status da transferencia, decide se vai consultar os saldos disponíveis
                If DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRN.Rows.Count > 0 Then
                    If DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRN(0).TIPSTAFLUAPV = Constants.TIPSTAFLUAPV_NOVO Then
                        For Each QueryRLCTRNVBAFRNRow As DatasetTransferenciaVerbaFornecedor.QueryRLCTRNVBAFRNRow In DatasetTransferenciaVerbaFornecedor.QueryRLCTRNVBAFRN
                            Dim dsSelecaoValorDisponivelFornecedorLaco As DatasetSelecaoValorDisponivelFornecedor
                            dsSelecaoValorDisponivelFornecedorLaco = Me.ObterSaldoDisponivelFornecedor(Date.Today, QueryRLCTRNVBAFRNRow.CODFRN, QueryRLCTRNVBAFRNRow.TIPDSNDSCBNFORITRN)
                            If dsSelecaoValorDisponivelFornecedorLaco.tbTransfenciaEmpenhosDoFornecedor.Rows.Count > 0 Then
                                Dim tbTransfenciaEmpenhosDoFornecedorRow As DatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedorRow
                                tbTransfenciaEmpenhosDoFornecedorRow = dsSelecaoValorDisponivelFornecedorLaco.tbTransfenciaEmpenhosDoFornecedor.FindByCodigoFornecedorCodigoEmpenhoCodigoAlocacao(QueryRLCTRNVBAFRNRow.CODFRN, QueryRLCTRNVBAFRNRow.TIPDSNDSCBNFORITRN, QueryRLCTRNVBAFRNRow.TIPALCVBAFRN)
                                If Not tbTransfenciaEmpenhosDoFornecedorRow Is Nothing Then
                                    QueryRLCTRNVBAFRNRow.VlrSldDsp = tbTransfenciaEmpenhosDoFornecedorRow.SaldoDisponivel
                                    QueryRLCTRNVBAFRNRow.VlrSldDspAlcVbaFrn = tbTransfenciaEmpenhosDoFornecedorRow.SaldoDisponivel
                                End If
                            End If
                        Next
                    End If
                End If

                'Obtem relação dos fluxos
                If Not DatasetTransferenciaVerbaFornecedor Is Nothing Then
                    'Empenho marketing
                    If DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRN(0).INDFLUTRNVBAMKT = 0 Then
                        DatasetTransferenciaVerbaFornecedor.Merge(ContaCorrenteFornecedor.ObterFluxosDeTransferenciaVerbaFornecedor(NUMFLUAPV))
                    ElseIf DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRN(0).INDFLUTRNVBAMKT = 1 Then
                        DatasetTransferenciaVerbaFornecedor.Merge(ContaCorrenteFornecedor.ObterFluxosDeTransferenciaVerbaFornecedorMarketing(NUMFLUAPV))
                    ElseIf (DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRN(0).INDFLUTRNVBAMKT = 2 Or DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRN(0).INDFLUTRNVBAMKT = 3) Then
                        DatasetTransferenciaVerbaFornecedor.Merge(ContaCorrenteFornecedor.ObterFluxosDeTransferenciaVerbaDesoneracaoEResultadoAGF(NUMFLUAPV))
                    End If

                Else
                    DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedor.ObterFluxosDeTransferenciaVerbaFornecedor(NUMFLUAPV)
                End If

                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor

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
        ''' Este método retorna dados da entidade CADTRNVBAFRN com base em outros atributos.
        ''' Descrição da entidade:CADASTRO DE TRANSFERENCIA VERBAS FORNECEDOR
        ''' </summary>
        ''' <param name="CODFNC">CODIGO FUNCIONARIO.</param>
        ''' <param name="DESJSTTRNVBA">DESCRICAO JUSTIFICATIVA DA TRANSFERENCIA DE VERBA.</param>
        ''' <param name="NUMFLUAPV">NUMERO FLUXO DE APROVACAO.</param>
        ''' <param name="TIPALCVBAFRN">TIPO DE ALOCACAO DA VERBA DO FORNECEDOR.</param>
        ''' <param name="TIPDSNDSCBNFDSNTRN">TIPO EMPENHO DESTINO TRANSFERENCIA VERBA.</param>
        ''' <param name="TIPSTAFLUAPV">TIPO STATUS FLUXO APROVACAO.</param>
        ''' <returns>Retorna um DataSet com a tabela "CADTRNVBAFRN" preenchida.</returns>
        ''' <remarks>
        ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
        ''' Um parametro do tipo número é omitido quando for zero,
        ''' Um parametro do tipo String é omitido quando for vazia,
        ''' Um parametro do tipo data   é omitido quando for Nothing,
        ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    27/11/2007  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterTransferenciasVerbaFornecedor(ByVal CODFNC As Decimal, _
                                                           ByVal DESJSTTRNVBA As String, _
                                                           ByVal NUMFLUAPV As Decimal, _
                                                           ByVal TIPALCVBAFRN As Decimal, _
                                                           ByVal TIPDSNDSCBNFDSNTRN As Decimal, _
                                                           ByVal TIPSTAFLUAPV As String) As DatasetTransferenciaVerbaFornecedor
            Try
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL

                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedor.ObterTransferenciasVerbaFornecedor(CODFNC, DESJSTTRNVBA, NUMFLUAPV, TIPALCVBAFRN, TIPDSNDSCBNFDSNTRN, TIPSTAFLUAPV)

                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor

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
        ''' Este método retorna dados da entidade CADTRNVBAFRN com base em outros atributos.
        ''' Descrição da entidade:CADASTRO DE TRANSFERENCIA VERBAS FORNECEDOR
        ''' </summary>
        ''' <param name="CODFNC">CODIGO FUNCIONARIO.</param>
        ''' <param name="DESJSTTRNVBA">DESCRICAO JUSTIFICATIVA DA TRANSFERENCIA DE VERBA.</param>
        ''' <param name="NUMFLUAPV">NUMERO FLUXO DE APROVACAO.</param>
        ''' <param name="TIPALCVBAFRN">TIPO DE ALOCACAO DA VERBA DO FORNECEDOR.</param>
        ''' <param name="TIPDSNDSCBNFDSNTRN">TIPO EMPENHO DESTINO TRANSFERENCIA VERBA.</param>
        ''' <param name="TIPSTAFLUAPV">TIPO STATUS FLUXO APROVACAO.</param>
        ''' <returns>Retorna um DataSet com a tabela "CADTRNVBAFRN" preenchida.</returns>
        ''' <remarks>
        ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
        ''' Um parametro do tipo número é omitido quando for zero,
        ''' Um parametro do tipo String é omitido quando for vazia,
        ''' Um parametro do tipo data   é omitido quando for Nothing,
        ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    27/11/2007  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterTransferenciasVerbaFornecedorJOIN(ByVal NUMFLUAPV As Decimal, _
                                                              ByVal CODFNC As Decimal, _
                                                              ByVal TIPSTAFLUAPV As String) As DatasetTransferenciaVerbaFornecedor
            Try
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL

                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedor.ObterTransferenciasVerbaFornecedorJOIN(NUMFLUAPV, CODFNC, TIPSTAFLUAPV)

                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor

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
        ''' <param name="NUMFLUAPV"></param>
        ''' <param name="CODFNC"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	22/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterMinhasAprovavoesEmTransferenciaVerbasFornecedor(ByVal NUMFLUAPV As Decimal, _
                                                                             ByVal CODFNC As Decimal) As DatasetTransferenciaVerbaFornecedor
            Try
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL

                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedor.ObterMinhasAprovavoesEmTransferenciaVerbasFornecedor(NUMFLUAPV, CODFNC)

                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor

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
        ''' <param name="DatasetTransferenciaVerbaFornecedor">DataSet com os dados a serem atualizados</param>
        ''' <remarks>
        ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    27/11/2007  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Sub AtualizarTransferenciaVerbaFornecedor(ByVal DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor)
            Try

                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL

                ContaCorrenteFornecedor.AtualizarTransferenciaVerbaFornecedor(DatasetTransferenciaVerbaFornecedor)
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
        ''' Este método retorna dados da entidade RLCTRNVBAFRN com base na sua chave primária.
        ''' Descrição da entidade:RELACAO DE TRANSFERENCIA VERBAS FORNECEDOR
        ''' </summary>
        ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
        ''' <param name="NUMFLUAPV">NUMERO FLUXO DE APROVACAO.</param>
        ''' <param name="TIPALCVBAFRN">TIPO DE ALOCACAO DA VERBA DO FORNECEDOR.</param>
        ''' <param name="TIPDSNDSCBNFORITRN">TIPO EMPENHO ORIGEM TRANSFERENCIA VERBA.</param>
        ''' <returns>Retorna um DataSet com a tabela "RLCTRNVBAFRN" preenchida.</returns>
        ''' <remarks>
        ''' Sempre que um código inválido for informado, uma exception será retornada.
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    27/11/2007  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterRelacaoTransferenciaVerbaFornecedor(ByVal CODFRN As Decimal, _
                                                                 ByVal NUMFLUAPV As Decimal, _
                                                                 ByVal TIPALCVBAFRN As Decimal, _
                                                                 ByVal TIPDSNDSCBNFORITRN As Decimal) As DatasetTransferenciaVerbaFornecedor
            Try

                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL

                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedor.ObterRelacaoTransferenciaVerbaFornecedor(CODFRN, NUMFLUAPV, TIPALCVBAFRN, TIPDSNDSCBNFORITRN)

                Dim configuracao As Martins.ConfigurationManagement.MartinsApplicationConfiguration
                configuracao = CType(Martins.ConfigurationManagement.ConfigurationManager.Read(Martins.ConfigurationManagement.ConfigurationManager.GetDefaultSection()), Martins.ConfigurationManagement.MartinsApplicationConfiguration)

                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor

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
        ''' Este método retorna dados da entidade RLCTRNVBAFRN com base na sua chave primária.
        ''' Descrição da entidade:RELACAO DE TRANSFERENCIA VERBAS FORNECEDOR
        ''' </summary>
        ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
        ''' <param name="NUMFLUAPV">NUMERO FLUXO DE APROVACAO.</param>
        ''' <param name="TIPALCVBAFRN">TIPO DE ALOCACAO DA VERBA DO FORNECEDOR.</param>
        ''' <param name="TIPDSNDSCBNFORITRN">TIPO EMPENHO ORIGEM TRANSFERENCIA VERBA.</param>
        ''' <returns>Retorna um DataSet com a tabela "RLCTRNVBAFRN" preenchida.</returns>
        ''' <remarks>
        ''' Sempre que um código inválido for informado, uma exception será retornada.
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    27/11/2007  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterRelacaoTransferenciaVerbaFornecedorJoin(ByVal NUMFLUAPV As Decimal, _
                                                                     ByVal CODFNC As Decimal, _
                                                                     ByVal TIPSTAFLUAPV As String) As DatasetTransferenciaVerbaFornecedor
            Try

                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL

                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedor.ObterTransferenciaSVerbaFornecedorJoin(NUMFLUAPV, CODFNC, TIPSTAFLUAPV)

                Dim configuracao As Martins.ConfigurationManagement.MartinsApplicationConfiguration
                configuracao = CType(Martins.ConfigurationManagement.ConfigurationManager.Read(Martins.ConfigurationManagement.ConfigurationManager.GetDefaultSection()), Martins.ConfigurationManagement.MartinsApplicationConfiguration)

                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor

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
        ''' <param name="NUMFLUAPV"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	5/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterRelacaoTransferenciaVerbaFornecedorJoinT0153541JoinT0100426JoinT0113625JoinT0118570JoinT0109059(ByVal NUMFLUAPV As Decimal) As DatasetTransferenciaVerbaFornecedor
            Try
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL

                'Obtem os dados principais
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedor.ObterRelacaoTransferenciaVerbaFornecedorJoinT0153541JoinT0100426JoinT0113625JoinT0118570JoinT0109059(NUMFLUAPV)

                'Obtem a transferencia (capa) através dessa consulta é decidido se 
                'deverá consultar os saldos disponíveis
                DatasetTransferenciaVerbaFornecedor.Merge(Me.ObterTransferenciaVerbaFornecedor(NUMFLUAPV))

                'Dependendo do status da transferencia, decide se vai consultar os saldos disponíveis
                If DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRN.Rows.Count > 0 Then
                    If DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRN(0).TIPSTAFLUAPV = Constants.TIPSTAFLUAPV_NOVO Then
                        For Each QueryRLCTRNVBAFRNRow As DatasetTransferenciaVerbaFornecedor.QueryRLCTRNVBAFRNRow In DatasetTransferenciaVerbaFornecedor.QueryRLCTRNVBAFRN
                            Dim dsSelecaoValorDisponivelFornecedorLaco As DatasetSelecaoValorDisponivelFornecedor
                            dsSelecaoValorDisponivelFornecedorLaco = Me.ObterSaldoDisponivelFornecedor(Date.Today, QueryRLCTRNVBAFRNRow.CODFRN, QueryRLCTRNVBAFRNRow.TIPDSNDSCBNFORITRN)
                            If dsSelecaoValorDisponivelFornecedorLaco.tbSelecaoValorDisponivelFornecedor.Rows.Count > 0 Then
                                Dim tbTransfenciaEmpenhosDoFornecedorRow As DatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedorRow
                                tbTransfenciaEmpenhosDoFornecedorRow = dsSelecaoValorDisponivelFornecedorLaco.tbTransfenciaEmpenhosDoFornecedor.FindByCodigoFornecedorCodigoEmpenhoCodigoAlocacao(QueryRLCTRNVBAFRNRow.CODFRN, QueryRLCTRNVBAFRNRow.TIPDSNDSCBNFORITRN, QueryRLCTRNVBAFRNRow.TIPALCVBAFRN)
                                If Not tbTransfenciaEmpenhosDoFornecedorRow Is Nothing Then
                                    QueryRLCTRNVBAFRNRow.VlrSldDsp = tbTransfenciaEmpenhosDoFornecedorRow.SaldoDisponivel
                                    QueryRLCTRNVBAFRNRow.VlrSldDspAlcVbaFrn = tbTransfenciaEmpenhosDoFornecedorRow.SaldoDisponivel
                                End If
                            End If
                        Next
                    End If
                End If

                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor

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
        ''' Este método retorna dados da entidade RLCTRNVBAFRN com base em outros atributos.
        ''' Descrição da entidade:RELACAO DE TRANSFERENCIA VERBAS FORNECEDOR
        ''' </summary>
        ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
        ''' <param name="NUMFLUAPV">NUMERO FLUXO DE APROVACAO.</param>
        ''' <param name="TIPALCVBAFRN">TIPO DE ALOCACAO DA VERBA DO FORNECEDOR.</param>
        ''' <param name="TIPDSNDSCBNFORITRN">TIPO EMPENHO ORIGEM TRANSFERENCIA VERBA.</param>
        ''' <returns>Retorna um DataSet com a tabela "RLCTRNVBAFRN" preenchida.</returns>
        ''' <remarks>
        ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
        ''' Um parametro do tipo número é omitido quando for zero,
        ''' Um parametro do tipo String é omitido quando for vazia,
        ''' Um parametro do tipo data   é omitido quando for Nothing,
        ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    27/11/2007  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterRelacoesTransferenciaVerbaFornecedor(ByVal CODFRN As Decimal, _
                                                                  ByVal NUMFLUAPV As Decimal, _
                                                                  ByVal TIPALCVBAFRN As Decimal, _
                                                                  ByVal TIPDSNDSCBNFORITRN As Decimal) As DatasetTransferenciaVerbaFornecedor
            Try
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL

                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedor.ObterRelacoesTransferenciaVerbaFornecedor(CODFRN, NUMFLUAPV, TIPALCVBAFRN, TIPDSNDSCBNFORITRN)

                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor

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
        ''' <param name="DatasetTransferenciaVerbaFornecedor">DataSet com os dados a serem atualizados</param>
        ''' <remarks>
        ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    27/11/2007  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Sub AtualizarRelacaoTransferenciaVerbaFornecedor(ByVal DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor)
            Try

                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL

                ContaCorrenteFornecedor.AtualizarRelacaoTransferenciaVerbaFornecedor(DatasetTransferenciaVerbaFornecedor)
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
        ''' 	[Marcos Queiroz]	29/11/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterNovaChaveTransferenciaVerba() As Decimal
            Try
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorBLL
                Dim chave As Decimal = ContaCorrenteFornecedor.ObterNovaChaveTransferenciaVerba
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
        ''' <param name="CODFNC"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	29/11/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterFuncionario(ByVal CODFNC As Decimal) As DatasetFuncionario
            Try

                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL

                Dim DatasetFuncionario As DatasetFuncionario
                DatasetFuncionario = ContaCorrenteFornecedor.ObterFuncionario(CODFNC)

                Dim configuracao As Martins.ConfigurationManagement.MartinsApplicationConfiguration
                configuracao = CType(Martins.ConfigurationManagement.ConfigurationManager.Read(Martins.ConfigurationManagement.ConfigurationManager.GetDefaultSection()), Martins.ConfigurationManagement.MartinsApplicationConfiguration)

                Me.SetComplete()
                Return DatasetFuncionario

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
        ''' Retorna verdadeiro se o fornecedor pertence a celula atendida pelo usuário
        ''' </summary>
        ''' <param name="CODFRN"></param>
        ''' <param name="NOMACSUSRSIS"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	29/12/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function FornecedorPertenceCelulaAtendidaUsuario(ByVal CODFRN As Decimal, _
                                                                ByVal NOMACSUSRSIS As String) As Boolean
            Try
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorBLL
                Dim result As Boolean

                result = ContaCorrenteFornecedor.FornecedorPertenceCelulaAtendidaUsuario(CODFRN, _
                                                                                         NOMACSUSRSIS.ToUpper.Trim)

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
        ''' <param name="NUMFLUAPV"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	6/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function IniciarFluxoTransferenciaVerbas(ByVal NUMFLUAPV As Decimal) As Boolean
            Try
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorBLL
                Dim FluxoDeCancelamentoDeAcordosBLL As New FluxoDeCancelamentoDeAcordosBLL
                Dim dsDiretores As DatasetFluxoAprovacao
                Dim email As New ArrayList

                Dim dsEmpenhoMarketing As DatasetTransferenciaVerbaFornecedor
                Dim CADTRNVBAFRNMarketingRow As DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow
                Dim empenhoMarketing As Decimal = 0

                dsEmpenhoMarketing = ContaCorrenteFornecedor.ObterTransferenciaVerbaFornecedor(NUMFLUAPV)

                If Not dsEmpenhoMarketing Is Nothing Then
                    If dsEmpenhoMarketing.CADTRNVBAFRN.Rows.Count > 0 Then
                        CADTRNVBAFRNMarketingRow = dsEmpenhoMarketing.CADTRNVBAFRN(0)
                        empenhoMarketing = CADTRNVBAFRNMarketingRow.INDFLUTRNVBAMKT
                    End If
                End If

                If empenhoMarketing = 0 Then
                    'Obter Diretores Aprovadores da Transferencia Verbas
                    Dim FluxoDeCancelamentoDeAcordos As New FluxoDeCancelamentoDeAcordosBLL
                    dsDiretores = FluxoDeCancelamentoDeAcordos.ObterDiretoresAprovadoresTransferenciaVerbas(NUMFLUAPV)

                    'Percorre todos diretores aprovadores
                    Dim NUMSEQFLUAPVDiretor As Decimal = 201
                    Dim NUMSEQFLUAPV As Decimal = 1
                    Dim DATHRAAPVFLU As Date = Date.Now

                    'Gerar fluxo de aprovação para diretores e gerentes
                    For Each LinhaDiretor As DatasetFluxoAprovacao.FuncionarioRow In dsDiretores.Funcionario
                        'Gera Fluxo Diretor
                        FluxoDeCancelamentoDeAcordosBLL.GerarFluxoAprovacao(Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS, NUMFLUAPV, NUMSEQFLUAPV, DATHRAAPVFLU, NUMSEQFLUAPVDiretor, LinhaDiretor.CODFNC, Constants.TIPSTAFLUAPV_ESPERA_APROVACAO, Nothing, String.Empty, String.Empty, 0, 0)

                        'Busca todos gerentes aprovadores da transferencia verbas e subordinados ao diretores do laço
                        Dim dsGerentes As DatasetFluxoAprovacao
                        dsGerentes = FluxoDeCancelamentoDeAcordos.ObterGerentesAprovadoresTransferenciaVerbas(NUMFLUAPV, LinhaDiretor.CODFNC)
                        'Percorre todos gerentes aprovadores e gera fluxo para cada um deles
                        For Each LinhaGerente As DatasetFluxoAprovacao.FuncionarioRow In dsGerentes.Funcionario
                            NUMSEQFLUAPV += 1
                            'Gera Fluxo Gerente
                            FluxoDeCancelamentoDeAcordosBLL.GerarFluxoAprovacao(Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS, NUMFLUAPV, NUMSEQFLUAPV, DATHRAAPVFLU, NUMSEQFLUAPVDiretor - 100, LinhaGerente.CODFNC, Constants.TIPSTAFLUAPV_EM_APROVACAO, Nothing, String.Empty, String.Empty, 0, 0)
                            'Guarda endereço para enviar e-mail
                            email.Add(LinhaGerente.NOMUSRRCF.ToLower.Trim & "@martins.com.br")
                        Next
                        NUMSEQFLUAPV += 1
                        NUMSEQFLUAPVDiretor += 1
                    Next

                    'Consulta Transferencia
                    Dim dsTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                    dsTransferenciaVerbaFornecedor = Me.ObterTransferenciaVerbaFornecedor(NUMFLUAPV)
                    If dsTransferenciaVerbaFornecedor.CADTRNVBAFRN.Rows.Count = 0 Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Transferencia Verbas não econtrada|", "")
                    End If
                    Dim CADTRNVBAFRNRow As DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow
                    CADTRNVBAFRNRow = dsTransferenciaVerbaFornecedor.CADTRNVBAFRN(0)

                    'Validar Transferencia
                    If CADTRNVBAFRNRow.TIPSTAFLUAPV <> Constants.TIPSTAFLUAPV_NOVO Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Não é possível iniciar fluxo porque o status da transferencia não é novo|", "")
                    End If
                    If CADTRNVBAFRNRow.DESJSTTRNVBA.Trim.Length = 0 Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Informe a justificativa|", "")
                    End If
                    If CADTRNVBAFRNRow.TIPALCVBAFRN = 0 Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Informa alocação|", "")
                    End If
                    If CADTRNVBAFRNRow.TIPDSNDSCBNFDSNTRN = 0 Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Informe empenho destino|", "")
                    End If
                    If dsTransferenciaVerbaFornecedor.RLCTRNVBAFRN.Rows.Count = 0 Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Selecione os valores a transferir antes de iniciar o fluxo|", "")
                    End If

                    'Gerar fluxo para responsável por aprovar transferencia com lançamento em período
                    'diferente do mes de aprovação (no momento da implementação a Elisangela era essa pessoa)
                    If CADTRNVBAFRNRow.INDMESTRNFLU <> Constants.INDMESTRNFLU_QUANDO_APROVACAO Then
                        Dim CODFNC As Decimal
                        CODFNC = Me.ObterFuncionarioAprovadorDaControladoriaQuandoMesLancamentoForDiferenteDoMesDeAprovacao
                        'Obtem a conta do usuário
                        Dim AcordoComercial As New AcordoComercialBLL
                        Dim dsContaUsuario As DatasetContaUsuario
                        dsContaUsuario = AcordoComercial.ObterContaUsuario(CODFNC)
                        If dsContaUsuario.T0104596.Rows.Count = 0 Then
                            Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Não encontrado funcionario da controladoria (" & CODFNC.ToString & ") na geração do fluxo|", "")
                        End If
                        'Gera Fluxo
                        FluxoDeCancelamentoDeAcordosBLL.GerarFluxoAprovacao(Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS, NUMFLUAPV, NUMSEQFLUAPV, DATHRAAPVFLU, Constants.NUMSEQNIVAPV_PARA_GERAR_FLUXO_DA_CONTROLADORIA_QUANDO_MES_LANCAMENTO_FOR_DIFERENTE_DO_MES_DE_APROVACAO, CODFNC, Constants.TIPSTAFLUAPV_ESPERA_APROVACAO, Nothing, String.Empty, String.Empty, 0, 0)
                    End If

                    'Verifica se o valor a transferir é maior que o saldo disponível
                    dsTransferenciaVerbaFornecedor.Merge(ObterRelacaoTransferenciaVerbaFornecedorJoinT0153541JoinT0100426JoinT0113625JoinT0118570JoinT0109059(NUMFLUAPV).QueryRLCTRNVBAFRN)
                    If dsTransferenciaVerbaFornecedor.QueryRLCTRNVBAFRN.Rows.Count = 0 Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Não é permitido liberar transferencia sem itens|", "")
                    End If
                    For Each QueryRLCTRNVBAFRNRow As DatasetTransferenciaVerbaFornecedor.QueryRLCTRNVBAFRNRow In dsTransferenciaVerbaFornecedor.QueryRLCTRNVBAFRN
                        If QueryRLCTRNVBAFRNRow.VLRLMTCTB > QueryRLCTRNVBAFRNRow.VlrSldDsp Then
                            Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Não é permitido transferir valor superior ao saldo disponível, fornecedor:" & QueryRLCTRNVBAFRNRow.NOMFRN.Trim & ", empenho:" & QueryRLCTRNVBAFRNRow.DESDSNDSCBNF.Trim & ", alocação:" & QueryRLCTRNVBAFRNRow.DESALCVBAFRN.Trim & "|", "")
                        End If
                    Next

                    'Reservar Saldo
                    Me.ReservarSaldo(NUMFLUAPV, DATHRAAPVFLU)

                    'Alterar status da transferencia
                    CADTRNVBAFRNRow.TIPSTAFLUAPV = Constants.TIPSTAFLUAPV_EM_APROVACAO
                    Me.AtualizarTransferenciaVerbaFornecedor(dsTransferenciaVerbaFornecedor)

                ElseIf empenhoMarketing = 1 Then

                    Dim DATHRAAPVFLU As Date = Date.Now
                    Dim dsTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                    Dim NUMSEQNIVAPV As Decimal = 201


                    dsTransferenciaVerbaFornecedor = Me.ObterTransferenciaVerbaFornecedor(NUMFLUAPV)

                    If dsTransferenciaVerbaFornecedor.CADTRNVBAFRN.Rows.Count = 0 Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Transferencia Verbas não econtrada|", "")
                    End If

                    Dim CADTRNVBAFRNRow As DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow
                    CADTRNVBAFRNRow = dsTransferenciaVerbaFornecedor.CADTRNVBAFRN(0)

                    'Validar Transferencia
                    If CADTRNVBAFRNRow.TIPSTAFLUAPV <> Constants.TIPSTAFLUAPV_NOVO Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Não é possível iniciar fluxo porque o status da transferencia não é novo|", "")
                    End If

                    If CADTRNVBAFRNRow.DESJSTTRNVBA.Trim.Length = 0 Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Informe a justificativa|", "")
                    End If

                    If CADTRNVBAFRNRow.TIPALCVBAFRN = 0 Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Informa alocação|", "")
                    End If

                    If CADTRNVBAFRNRow.TIPDSNDSCBNFDSNTRN = 0 Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Informe empenho destino|", "")
                    End If

                    If dsTransferenciaVerbaFornecedor.RLCTRNVBAFRN.Rows.Count = 0 Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Selecione os valores a transferir antes de iniciar o fluxo|", "")
                    End If

                    Dim dsAprovadoresEmpenhoMarketing As DatasetTransferenciaVerbaFornecedor
                    Dim T0161581Row As DatasetTransferenciaVerbaFornecedor.T0161581Row

                    dsAprovadoresEmpenhoMarketing = Me.ObterAprovadoresEmpenhoMarketing()

                    If Not dsAprovadoresEmpenhoMarketing Is Nothing Then
                        If dsAprovadoresEmpenhoMarketing.T0161581.Rows.Count > 0 Then
                            For Each linha As DatasetTransferenciaVerbaFornecedor.T0161581Row In dsAprovadoresEmpenhoMarketing.T0161581.Rows
                               
                                'Envia e-mail para o primeiro aprovador
                                If NUMSEQNIVAPV = 201 Then
                                    Dim dsContaUsuario As DatasetContaUsuario
                                    Dim AcordoComercial As New AcordoComercialBLL
                                    dsContaUsuario = AcordoComercial.ObterContaUsuario(linha.CODFNCAPVFIX)
                                    If dsContaUsuario.T0104596.Rows.Count > 0 Then
                                        Dim T0104596row As DatasetContaUsuario.T0104596Row
                                        T0104596row = dsContaUsuario.T0104596(0)
                                        email.Add(T0104596row.NOMUSRRCF.ToLower.Trim & "@martins.com.br")
                                        'Gera Fluxo
                                        FluxoDeCancelamentoDeAcordosBLL.GerarFluxoAprovacao(Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS_EMPENHO_MARKETING, NUMFLUAPV, linha.NUMSEQNIVAPV, DATHRAAPVFLU, NUMSEQNIVAPV, linha.CODFNCAPVFIX, Constants.TIPSTAFLUAPV_EM_APROVACAO, Nothing, String.Empty, String.Empty, 0, 0)

                                        'EnviarEmailNaIniciacaoDoFluxoDeTransferenciaVerbas(NUMFLUAPV, T0104596row.NOMUSRRCF.ToLower.Trim & "@martins.com.br"
                                    End If


                                    'dsFluxoAprovacaoControladoria = FluxoDeCancelamentoDeAcordosBP.ObterFluxosAprovacaoPendentes(0, 0, Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS_EMPENHO_MARKETING, String.Empty, String.Empty, NUMFLUAPV, 0, 0, NUMSEQNIVAPV)
                                    'If dsFluxoAprovacaoControladoria.T0161591.Rows.Count > 0 Then
                                    '    Dim T0161591row As DatasetFluxoAprovacao.T0161591Row
                                    '    T0161591row = dsFluxoAprovacaoControladoria.T0161591(0)
                                    '    'Altera o status do fluxo para em aprovação
                                    '    T0161591row.TIPSTAFLUAPV = Constants.TIPSTAFLUAPV_EM_APROVACAO
                                    '    FluxoDeCancelamentoDeAcordos.AtualizarFluxoAprovacao(dsFluxoAprovacaoControladoria)
                                    '    'Envia e-mail
                                    '    Dim AcordoComercial As New AcordoComercialBLL
                                    '    Dim dsContaUsuario As DatasetContaUsuario
                                    '    dsContaUsuario = AcordoComercial.ObterContaUsuario(T0161591row.CODEDEAPV)
                                    '    If dsContaUsuario.T0104596.Rows.Count > 0 Then
                                    '        Dim T0104596row As DatasetContaUsuario.T0104596Row
                                    '        T0104596row = dsContaUsuario.T0104596(0)
                                    '        EnviarEmailNaIniciacaoDoFluxoDeTransferenciaVerbas(NUMFLUAPV, T0104596row.NOMUSRRCF.ToLower.Trim & "@martins.com.br")
                                    '    End If
                                    'End If
                                Else
                                    'Gera Fluxo
                                    FluxoDeCancelamentoDeAcordosBLL.GerarFluxoAprovacao(Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS_EMPENHO_MARKETING, NUMFLUAPV, linha.NUMSEQNIVAPV, DATHRAAPVFLU, NUMSEQNIVAPV, linha.CODFNCAPVFIX, Constants.TIPSTAFLUAPV_ESPERA_APROVACAO, Nothing, String.Empty, String.Empty, 0, 0)
                                End If

                                NUMSEQNIVAPV += 100
                            Next
                        End If
                    End If


                    'Reservar Saldo
                    Me.ReservarSaldo(NUMFLUAPV, DATHRAAPVFLU)

                    'Alterar status da transferencia
                    CADTRNVBAFRNRow.TIPSTAFLUAPV = Constants.TIPSTAFLUAPV_EM_APROVACAO
                    Me.AtualizarTransferenciaVerbaFornecedor(dsTransferenciaVerbaFornecedor)

                ElseIf (empenhoMarketing = 2 Or empenhoMarketing = 3) Then

                    Dim DATHRAAPVFLU As Date = Date.Now
                    Dim dsTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                    Dim NUMSEQNIVAPV As Decimal = 201


                    dsTransferenciaVerbaFornecedor = Me.ObterTransferenciaVerbaFornecedor(NUMFLUAPV)

                    If dsTransferenciaVerbaFornecedor.CADTRNVBAFRN.Rows.Count = 0 Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Transferencia Verbas não econtrada|", "")
                    End If

                    Dim CADTRNVBAFRNRow As DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow
                    CADTRNVBAFRNRow = dsTransferenciaVerbaFornecedor.CADTRNVBAFRN(0)

                    'Validar Transferencia
                    If CADTRNVBAFRNRow.TIPSTAFLUAPV <> Constants.TIPSTAFLUAPV_NOVO Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Não é possível iniciar fluxo porque o status da transferencia não é novo|", "")
                    End If

                    If CADTRNVBAFRNRow.DESJSTTRNVBA.Trim.Length = 0 Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Informe a justificativa|", "")
                    End If

                    If CADTRNVBAFRNRow.TIPALCVBAFRN = 0 Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Informa alocação|", "")
                    End If

                    If CADTRNVBAFRNRow.TIPDSNDSCBNFDSNTRN = 0 Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Informe empenho destino|", "")
                    End If

                    If dsTransferenciaVerbaFornecedor.RLCTRNVBAFRN.Rows.Count = 0 Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Selecione os valores a transferir antes de iniciar o fluxo|", "")
                    End If

                    Dim dsAprovadoresEmpenhoMarketing As DatasetTransferenciaVerbaFornecedor
                    Dim T0161581Row As DatasetTransferenciaVerbaFornecedor.T0161581Row

                    dsAprovadoresEmpenhoMarketing = Me.ObterAprovadoresEmpenhoMarketing()

                    If Not dsAprovadoresEmpenhoMarketing Is Nothing Then
                        If dsAprovadoresEmpenhoMarketing.T0161581.Rows.Count > 0 Then
                            For Each linha As DatasetTransferenciaVerbaFornecedor.T0161581Row In dsAprovadoresEmpenhoMarketing.T0161581.Rows

                                'Envia e-mail para o primeiro aprovador
                                If NUMSEQNIVAPV = 201 Then
                                    Dim dsContaUsuario As DatasetContaUsuario
                                    Dim AcordoComercial As New AcordoComercialBLL
                                    dsContaUsuario = AcordoComercial.ObterContaUsuario(linha.CODFNCAPVFIX)
                                    If dsContaUsuario.T0104596.Rows.Count > 0 Then
                                        Dim T0104596row As DatasetContaUsuario.T0104596Row
                                        T0104596row = dsContaUsuario.T0104596(0)
                                        email.Add(T0104596row.NOMUSRRCF.ToLower.Trim & "@martins.com.br")
                                        'Gera Fluxo
                                        FluxoDeCancelamentoDeAcordosBLL.GerarFluxoAprovacao(Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS_DESONERACAO_E_RESULTADO_AGF, NUMFLUAPV, linha.NUMSEQNIVAPV, DATHRAAPVFLU, NUMSEQNIVAPV, linha.CODFNCAPVFIX, Constants.TIPSTAFLUAPV_EM_APROVACAO, Nothing, String.Empty, String.Empty, 0, 0)

                                        'EnviarEmailNaIniciacaoDoFluxoDeTransferenciaVerbas(NUMFLUAPV, T0104596row.NOMUSRRCF.ToLower.Trim & "@martins.com.br"
                                    End If

                                Else
                                    'Gera Fluxo
                                    FluxoDeCancelamentoDeAcordosBLL.GerarFluxoAprovacao(Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS_DESONERACAO_E_RESULTADO_AGF, NUMFLUAPV, linha.NUMSEQNIVAPV, DATHRAAPVFLU, NUMSEQNIVAPV, linha.CODFNCAPVFIX, Constants.TIPSTAFLUAPV_ESPERA_APROVACAO, Nothing, String.Empty, String.Empty, 0, 0)
                                End If

                                NUMSEQNIVAPV += 100
                            Next
                        End If
                    End If


                    'Reservar Saldo
                    Me.ReservarSaldo(NUMFLUAPV, DATHRAAPVFLU)

                    'Alterar status da transferencia
                    CADTRNVBAFRNRow.TIPSTAFLUAPV = Constants.TIPSTAFLUAPV_EM_APROVACAO
                    Me.AtualizarTransferenciaVerbaFornecedor(dsTransferenciaVerbaFornecedor)

                End If

                'Enviar e-mail para os aprovadores
                Me.EnviarEmailNaIniciacaoDoFluxoDeTransferenciaVerbas(NUMFLUAPV, email)

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
        ''' <param name="NUMFLUAPV"></param>
        ''' <param name="CODFNC"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	12/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function AprovarFluxoTransferenciaVerbas(ByVal NUMFLUAPV As Decimal, ByVal CODFNC As Decimal, ByVal DESOBSAPV As String) As Boolean
            Try
                Dim CODSISINF As Decimal = 0
                'Consulta Transferencia
                Dim dsTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                dsTransferenciaVerbaFornecedor = Me.ObterTransferenciaVerbaFornecedor(NUMFLUAPV)
                If dsTransferenciaVerbaFornecedor.CADTRNVBAFRN.Rows.Count = 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Transferencia Verbas não econtrada|", "")
                End If

                'Obtem os fluxos de aprovação do funcionário
                Dim FluxoDeCancelamentoDeAcordos As New FluxoDeCancelamentoDeAcordosBP
                Dim dsFluxoAprovacao As DatasetFluxoAprovacao

                dsFluxoAprovacao = FluxoDeCancelamentoDeAcordos.ObterFluxosAprovacao(CODFNC, 0, Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS, String.Empty, String.Empty, NUMFLUAPV, 0, 0, 0, Constants.TIPSTAFLUAPV_EM_APROVACAO)
                CODSISINF = Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS
                If dsFluxoAprovacao.T0161591.Rows.Count = 0 Then
                    dsFluxoAprovacao = FluxoDeCancelamentoDeAcordos.ObterFluxosAprovacao(CODFNC, 0, Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS_EMPENHO_MARKETING, String.Empty, String.Empty, NUMFLUAPV, 0, 0, 0, Constants.TIPSTAFLUAPV_EM_APROVACAO)
                    CODSISINF = Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS_EMPENHO_MARKETING
                    If dsFluxoAprovacao.T0161591.Rows.Count = 0 Then
                        dsFluxoAprovacao = FluxoDeCancelamentoDeAcordos.ObterFluxosAprovacao(CODFNC, 0, Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS_DESONERACAO_E_RESULTADO_AGF, String.Empty, String.Empty, NUMFLUAPV, 0, 0, 0, Constants.TIPSTAFLUAPV_EM_APROVACAO)
                        CODSISINF = Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS_DESONERACAO_E_RESULTADO_AGF
                        If dsFluxoAprovacao.T0161591.Rows.Count = 0 Then
                            Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Não encontrado fluxo pendente para funcionário|", "")
                        End If
                    End If
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

                dsFluxoAprovacao = FluxoDeCancelamentoDeAcordos.ObterFluxosAprovacaoPendentes(0, 0, CODSISINF, String.Empty, String.Empty, NUMFLUAPV, 0, 0, 0)
                Dim existeFluxoPendente As Boolean = (dsFluxoAprovacao.T0161591.Rows.Count > 0)

                'Se todos fluxo foram provados aprova a tabela principal (capa)
                If Not existeFluxoPendente Then
                    'Consulta Transferencia
                    dsTransferenciaVerbaFornecedor = Me.ObterTransferenciaVerbaFornecedor(NUMFLUAPV)
                    If dsTransferenciaVerbaFornecedor.CADTRNVBAFRN.Rows.Count = 0 Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Transferencia Verbas não econtrada|", "")
                    End If

                    Dim CADTRNVBAFRNRow As DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow
                    Dim DATAPVACOCMC As Date = Date.Now
                    CADTRNVBAFRNRow = dsTransferenciaVerbaFornecedor.CADTRNVBAFRN(0)
                    CADTRNVBAFRNRow.TIPSTAFLUAPV = Constants.TIPSTAFLUAPV_APROVADO

                    Dim DataLancamento As Date
                    DataLancamento = ObterDataLancamentoTransferenciaVerbas(CADTRNVBAFRNRow.INDMESTRNFLU, DATHRAFLUAPV, DATAPVACOCMC)

                    TransferirValoresDeFluxoTransferenciaVerbas(NUMFLUAPV, DATHRAFLUAPV, DATAPVACOCMC, CADTRNVBAFRNRow.INDMESTRNFLU, DataLancamento)
                    AtualizarTransferenciaVerbaFornecedor(dsTransferenciaVerbaFornecedor)
                End If

                'Consulta todos os fluxo pendentes com o mesmo NUMSEQNIVAPV
                'esse campo indica todos gerentes subordinandos a um diretor específico
                If NUMSEQNIVAPV > 100 And NUMSEQNIVAPV < 200 Then 'Nesses casos é um gerente que está aprovando
                    dsFluxoAprovacao = FluxoDeCancelamentoDeAcordos.ObterFluxosAprovacaoPendentes(0, 0, CODSISINF, String.Empty, String.Empty, NUMFLUAPV, 0, 0, NUMSEQNIVAPV)
                    If dsFluxoAprovacao.T0161591.Rows.Count = 0 Then
                        'Nesse caso não existe nenhum fluxo de gerente pendente
                        'consulta o diretor desse gerente para enviar e-mail
                        Dim dsFluxoDiretor As DatasetFluxoAprovacao
                        dsFluxoDiretor = FluxoDeCancelamentoDeAcordos.ObterFluxosAprovacaoPendentes(0, 0, CODSISINF, String.Empty, String.Empty, NUMFLUAPV, 0, 0, NUMSEQNIVAPV + 100)
                        For Each T0161591rowFluxoDiretor As DatasetFluxoAprovacao.T0161591Row In dsFluxoDiretor.T0161591
                            'Consulta o diretor do fluxo
                            Dim FluxoDeCancelamentoDeAcordosBLL As New FluxoDeCancelamentoDeAcordosBLL
                            Dim dsFluxoAprovacaoDiretor As DatasetFluxoAprovacao
                            dsFluxoAprovacaoDiretor = FluxoDeCancelamentoDeAcordosBLL.ObterDiretoresAprovadoresTransferenciaVerbas(NUMFLUAPV)
                            If dsFluxoAprovacaoDiretor.Funcionario.Rows.Count > 0 Then
                                'Altera o fluxo do diretor para "Em Aprovação"
                                T0161591rowFluxoDiretor.TIPSTAFLUAPV = Constants.TIPSTAFLUAPV_EM_APROVACAO
                                'Envia notificação para o diretor
                                EnviarEmailNaIniciacaoDoFluxoDeTransferenciaVerbas(NUMFLUAPV, dsFluxoAprovacaoDiretor.Funcionario(0).NOMUSRRCF.ToLower.Trim & "@martins.com.br")
                            End If
                        Next
                        If Not dsFluxoDiretor.GetChanges Is Nothing Then
                            FluxoDeCancelamentoDeAcordos.AtualizarFluxoAprovacao(dsFluxoDiretor)
                        End If
                    End If
                End If

                'Verifica se todos fluxos foram aprovados, exceto o da controladoria
                Dim PendenteSomenteFluxoControladoria As Boolean = True
                dsFluxoAprovacao = FluxoDeCancelamentoDeAcordos.ObterFluxosAprovacaoPendentes(0, 0, CODSISINF, String.Empty, String.Empty, NUMFLUAPV, 0, 0, 0)
                For Each T0161591rowFluxoDiretor As DatasetFluxoAprovacao.T0161591Row In dsFluxoAprovacao.T0161591
                    If T0161591rowFluxoDiretor.NUMSEQNIVAPV <> Constants.NUMSEQNIVAPV_PARA_GERAR_FLUXO_DA_CONTROLADORIA_QUANDO_MES_LANCAMENTO_FOR_DIFERENTE_DO_MES_DE_APROVACAO Then
                        PendenteSomenteFluxoControladoria = False
                        Exit For
                    End If
                Next

                'Muda o status do fluxo e envia e-mail para controladoria
                If PendenteSomenteFluxoControladoria Then
                    Dim dsFluxoAprovacaoControladoria As DatasetFluxoAprovacao
                    dsFluxoAprovacaoControladoria = FluxoDeCancelamentoDeAcordos.ObterFluxosAprovacaoPendentes(0, 0, CODSISINF, String.Empty, String.Empty, NUMFLUAPV, 0, 0, Constants.NUMSEQNIVAPV_PARA_GERAR_FLUXO_DA_CONTROLADORIA_QUANDO_MES_LANCAMENTO_FOR_DIFERENTE_DO_MES_DE_APROVACAO)
                    If dsFluxoAprovacaoControladoria.T0161591.Rows.Count > 0 Then
                        Dim T0161591row As DatasetFluxoAprovacao.T0161591Row
                        T0161591row = dsFluxoAprovacaoControladoria.T0161591(0)
                        'Altera o status do fluxo para em aprovação
                        T0161591row.TIPSTAFLUAPV = Constants.TIPSTAFLUAPV_EM_APROVACAO
                        FluxoDeCancelamentoDeAcordos.AtualizarFluxoAprovacao(dsFluxoAprovacaoControladoria)
                        'Envia e-mail
                        Dim AcordoComercial As New AcordoComercialBLL
                        Dim dsContaUsuario As DatasetContaUsuario
                        dsContaUsuario = AcordoComercial.ObterContaUsuario(T0161591row.CODEDEAPV)
                        If dsContaUsuario.T0104596.Rows.Count > 0 Then
                            Dim T0104596row As DatasetContaUsuario.T0104596Row
                            T0104596row = dsContaUsuario.T0104596(0)
                            EnviarEmailNaIniciacaoDoFluxoDeTransferenciaVerbas(NUMFLUAPV, T0104596row.NOMUSRRCF.ToLower.Trim & "@martins.com.br")
                        End If
                    End If
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
        ''' <param name="INDMESTRNFLU"></param>
        ''' <param name="DATHRAFLUAPV"></param>
        ''' <param name="DATAPVACOCMC"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	9/1/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Function ObterDataLancamentoTransferenciaVerbas(ByVal INDMESTRNFLU As Decimal, _
                                                                ByVal DATHRAFLUAPV As Date, _
                                                                ByVal DATAPVACOCMC As Date) As Date
            Try
                'Define a data de lançamento no conta corrente tomado por base a data da geração
                'do fluxo, a data de aprovação do fluxo e o campo INDMESTRNFLU da transferencia.
                'Esse campo define quando será lançado no conta corrente
                Dim result As Date
                Select Case INDMESTRNFLU
                    Case Constants.INDMESTRNFLU_QUANDO_APROVACAO
                        result = DATAPVACOCMC 'Hora de aprovação do fluxo
                        If result.DayOfWeek = DayOfWeek.Sunday Then
                            result = result.AddDays(-1)
                        End If
                    Case Constants.INDMESTRNFLU_MES_ATUAL
                        'DATHRAFLUAPV:Hora de geração do fluxo
                        'DATAPVACOCMC:Hora de aprovação do fluxo
                        Dim MesDesejado As Integer
                        Dim AnoDesejado As Integer
                        MesDesejado = DATHRAFLUAPV.Month
                        AnoDesejado = DATHRAFLUAPV.Year

                        result = DATAPVACOCMC.Date
                        Do While True
                            If result.Month = MesDesejado And _
                               result.Year = AnoDesejado And _
                               result.DayOfWeek <> DayOfWeek.Sunday Then
                                Exit Do
                            End If
                            result = result.AddDays(-1)
                        Loop
                    Case Constants.INDMESTRNFLU_MES_ANTERIOR
                        Dim MesDesejado As Integer
                        Dim AnoDesejado As Integer
                        MesDesejado = DATAPVACOCMC.AddMonths(-1).Month
                        AnoDesejado = DATAPVACOCMC.AddMonths(-1).Year

                        result = DATAPVACOCMC.Date
                        Do While True
                            result = result.AddDays(-1) 'Um mês antes da geração do fluxo
                            If result.Month = MesDesejado And _
                               result.Year = AnoDesejado And _
                               result.DayOfWeek <> DayOfWeek.Sunday Then
                                Exit Do
                            End If
                        Loop
                End Select

                'Verifica se a data encontrada é feriado no Martins, se for vai reduzindo 1 dia
                'até encontrar uma data que não é
                Do While True
                    Dim dsCalendarioAnual As DatasetCalendarioAnual
                    dsCalendarioAnual = ObterCalendarioAnual(result)
                    If dsCalendarioAnual.T0102321.Rows.Count = 0 Then
                        Exit Do
                    End If
                    If dsCalendarioAnual.T0102321(0).FLGFRDNAC <> "*" Then
                        Exit Do
                    End If
                    result = result.AddDays(-1)
                Loop

                Me.SetComplete()
                Return result
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
        ''' <param name="NUMFLUAPV"></param>
        ''' <param name="CODFNC"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	12/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ReprovarFluxoTransferenciaVerbas(ByVal NUMFLUAPV As Decimal, ByVal CODFNC As Decimal, ByVal DESOBSAPV As String) As Boolean
            Try
                Dim CODSISINF As Decimal = 0
                'Consulta Transferencia
                Dim dsTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                dsTransferenciaVerbaFornecedor = Me.ObterTransferenciaVerbaFornecedor(NUMFLUAPV)
                If dsTransferenciaVerbaFornecedor.CADTRNVBAFRN.Rows.Count = 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Transferencia Verbas não econtrada|", "")
                End If

                'Obtem os fluxos de aprovação do funcionário
                Dim FluxoDeCancelamentoDeAcordos As New FluxoDeCancelamentoDeAcordosBLL
                Dim dsFluxoAprovacao As DatasetFluxoAprovacao

                dsFluxoAprovacao = FluxoDeCancelamentoDeAcordos.ObterFluxosAprovacao(CODFNC, 0, Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS, String.Empty, String.Empty, NUMFLUAPV, 0, 0, 0, Constants.TIPSTAFLUAPV_EM_APROVACAO)
                CODSISINF = Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS

                If dsFluxoAprovacao.T0161591.Rows.Count = 0 Then
                    dsFluxoAprovacao = FluxoDeCancelamentoDeAcordos.ObterFluxosAprovacao(CODFNC, 0, Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS_EMPENHO_MARKETING, String.Empty, String.Empty, NUMFLUAPV, 0, 0, 0, Constants.TIPSTAFLUAPV_EM_APROVACAO)
                    CODSISINF = Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS_EMPENHO_MARKETING
                    If dsFluxoAprovacao.T0161591.Rows.Count = 0 Then
                        dsFluxoAprovacao = FluxoDeCancelamentoDeAcordos.ObterFluxosAprovacao(CODFNC, 0, Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS_DESONERACAO_E_RESULTADO_AGF, String.Empty, String.Empty, NUMFLUAPV, 0, 0, 0, Constants.TIPSTAFLUAPV_EM_APROVACAO)
                        CODSISINF = Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS_DESONERACAO_E_RESULTADO_AGF

                        If dsFluxoAprovacao.T0161591.Rows.Count = 0 Then
                            Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Não encontrado fluxo pendente para funcionário|", "")
                        End If

                    End If
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

                Dim CADTRNVBAFRNRow As DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow
                CADTRNVBAFRNRow = dsTransferenciaVerbaFornecedor.CADTRNVBAFRN(0)
                CADTRNVBAFRNRow.TIPSTAFLUAPV = Constants.TIPSTAFLUAPV_REJEITADO
                AtualizarTransferenciaVerbaFornecedor(dsTransferenciaVerbaFornecedor)

                'Excluir o saldo reservado
                ExcluirReservaSaldo(NUMFLUAPV)

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
        ''' <param name="NUMFLUAPV"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	12/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function TransferirValoresDeFluxoTransferenciaVerbas(ByVal NUMFLUAPV As Decimal, _
                                                                    ByVal DATHRAFLUAPV As Date, _
                                                                    ByVal DATAPVACOCMC As Date, _
                                                                    ByVal INDMESTRNFLU As Decimal, _
                                                                    ByVal DataParaLancamento As Date) As Boolean

            Try
                TransferirValoresDeFluxoTransferenciaVerbas = False

                'Consulta os empenhos, essa informação será utilizada para compor um campo de descrição
                Dim dsEmpenho As DatasetEmpenho
                Dim AcordoComercial As New AcordoComercialBLL
                dsEmpenho = AcordoComercial.ObterEmpenhos("", "", "", 0, "", -1)

                'Consulta Transferencia
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                DatasetTransferenciaVerbaFornecedor = Me.ObterTransferenciaVerbaFornecedor(NUMFLUAPV)
                If DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRN.Rows.Count = 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Transferencia Verbas não econtrada|", "")
                End If

                'Transfere as informações da transferencia para linha
                Dim CADTRNVBAFRNrow As DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow
                CADTRNVBAFRNrow = DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRN(0)

                'Consulta o usuário
                Dim dsContaUsuario As DatasetContaUsuario
                dsContaUsuario = AcordoComercial.ObterContaUsuario(CADTRNVBAFRNrow.CODFNC)
                Dim NomeUsuario As String
                If dsContaUsuario.T0104596.Rows.Count > 0 Then
                    NomeUsuario = dsContaUsuario.T0104596(0).NOMUSRRCF
                End If

                'Percorre todas linhas de relação
                For Each RLCTRNVBAFRNRow As DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRNRow In DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRN

                    'Regra para definir tipo de alocação verba origem
                    Dim TipAlcVbaFrnDstPmtDdoOrigem As Integer
                    If RLCTRNVBAFRNRow.TIPALCVBAFRN = 3 Then
                        TipAlcVbaFrnDstPmtDdoOrigem = 0
                    Else
                        TipAlcVbaFrnDstPmtDdoOrigem = CType(RLCTRNVBAFRNRow.TIPALCVBAFRN, Integer)
                    End If

                    'Regra para definir tipo de alocação verba destino (definida por severton em 03/01/2008
                    Dim indicadorTransferenciaParaMarketing As Boolean = False
                    If CADTRNVBAFRNrow.TIPDSNDSCBNFDSNTRN = 42 Then
                        If CADTRNVBAFRNrow.TIPALCVBAFRN = 2 Then 'Alocação para Marketing
                            If ForncedorTemAlocacao(DataParaLancamento, RLCTRNVBAFRNRow.CODFRN, CADTRNVBAFRNrow.TIPDSNDSCBNFDSNTRN) Then
                                indicadorTransferenciaParaMarketing = True
                            End If
                        End If
                    End If
                    If indicadorTransferenciaParaMarketing Then
                        CADTRNVBAFRNrow.TIPALCVBAFRN = 2 'Transferencia para Marketing
                    Else
                        CADTRNVBAFRNrow.TIPALCVBAFRN = 3 'Transferencia para Conta Corrente
                    End If

                    'Regra para definir tipo de alocação verba destino,
                    'antiga, copiada da transferencia verbas antiga (fornecedor e GAC)
                    Dim TipAlcVbaFrnDstPmtDdoDestino As Integer
                    If CADTRNVBAFRNrow.TIPALCVBAFRN = 3 Then
                        TipAlcVbaFrnDstPmtDdoDestino = 9999
                    Else
                        TipAlcVbaFrnDstPmtDdoDestino = CType(CADTRNVBAFRNrow.TIPALCVBAFRN, Integer)
                    End If

                    Dim pTipAlcVbaFrn As Integer = 0

                    'Consulta o Fornecedor
                    Dim dsDivisaoFornecedor As dataSetDivisaoFornecedor
                    Dim DivisaoFornecedor As New DivisaoFornecedorBLL
                    dsDivisaoFornecedor = DivisaoFornecedor.ObterDivisaoFornecedor(1, CType(RLCTRNVBAFRNRow.CODFRN, Long))
                    Dim NomeFornecedor As String
                    If dsDivisaoFornecedor.T0100426.Rows.Count > 0 Then
                        NomeFornecedor = dsDivisaoFornecedor.T0100426(0).NOMFRN
                    End If

                    'Empenho Origem
                    Dim T0109059RowOrigem As DatasetEmpenho.T0109059Row
                    T0109059RowOrigem = dsEmpenho.T0109059.FindByTIPDSNDSCBNF(RLCTRNVBAFRNRow.TIPDSNDSCBNFORITRN)
                    Dim NomeEmpenhoOrigem As String
                    If Not T0109059RowOrigem Is Nothing Then
                        NomeEmpenhoOrigem = T0109059RowOrigem.DESDSNDSCBNF
                    End If

                    'Empenho Destino
                    Dim T0109059RowDestino As DatasetEmpenho.T0109059Row
                    T0109059RowDestino = dsEmpenho.T0109059.FindByTIPDSNDSCBNF(CADTRNVBAFRNrow.TIPDSNDSCBNFDSNTRN)
                    Dim NomeEmpenhoDestino As String
                    If Not T0109059RowDestino Is Nothing Then
                        NomeEmpenhoDestino = T0109059RowDestino.DESDSNDSCBNF
                    End If

                    'Historico
                    Dim Historico As String
                    Historico = "TRANSFERENCIA VIA FLUXO:" & NUMFLUAPV.ToString

                    Me.TransferirValoresEntreEmpenhosFornecedor(RLCTRNVBAFRNRow.VLRLMTCTB, _
                                                 pTipAlcVbaFrn, _
                                                 DataParaLancamento, _
                                                 RLCTRNVBAFRNRow.TIPDSNDSCBNFORITRN, _
                                                 CADTRNVBAFRNrow.TIPDSNDSCBNFDSNTRN, _
                                                 RLCTRNVBAFRNRow.CODFRN, _
                                                 RLCTRNVBAFRNRow.CODFRN, _
                                                 RLCTRNVBAFRNRow.VLRLMTCTB, _
                                                 Historico.Trim, _
                                                 "Transf. p/ " & NomeEmpenhoDestino.Trim & " - " & NomeFornecedor.Trim, _
                                                 "Transf. de " & NomeEmpenhoOrigem.Trim & " - " & NomeFornecedor.Trim, _
                                                 NomeUsuario, _
                                                 TipAlcVbaFrnDstPmtDdoOrigem, _
                                                 TipAlcVbaFrnDstPmtDdoDestino)
                Next

                'Liberar saldo reservado
                LiberarReservaSaldo(NUMFLUAPV, _
                                    DATAPVACOCMC)

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

        Private Function ForncedorTemAlocacao(ByVal vDatRef As Date, _
                                              ByVal vCodFrn As Decimal, _
                                              ByVal vTipDsnDscBnf As Decimal) As Boolean
            Try
                Dim result As Boolean = False
                Dim dsSelecaoValorDisponivelFornecedor As DatasetSelecaoValorDisponivelFornecedor
                dsSelecaoValorDisponivelFornecedor = Me.ObterSelecaoValorDisponivelFornecedor(vDatRef, vCodFrn, vTipDsnDscBnf)

                If dsSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedor.Rows.Count > 0 Then
                    Dim row As DatasetSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedorRow
                    row = dsSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedor(0)

                    If (Not row.IsDesAlcVbaFrnNull) And (Not row.IsTipAlcVbaFrnNull) Then
                        If Not row.IsVlrAlcVbaFrnNull Then
                            If Not row.IsVlrRcbAlcVbaFrnNull Then
                                result = True
                            End If
                        End If
                    End If

                End If

                Me.SetComplete()
                Return result
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
        ''' <param name="NUMFLUAPV"></param>
        ''' <param name="emailRemetente"></param>
        ''' <param name="emailDestinatario"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	7/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Function EnviarEmailNaIniciacaoDoFluxoDeTransferenciaVerbas(ByVal NUMFLUAPV As Decimal, _
                                                                            ByVal emailDestinatario As String) As Boolean
            Try
                Dim MensagemEletronica As New MensagemEletronicaBLL
                Dim dsMensagemEltronica As New MensagemEletronica.dataSetMensagemEletronica

                'Obter a transferencia verba
                Dim dsTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                dsTransferenciaVerbaFornecedor = Me.ObterTransferenciaVerbaFornecedor(NUMFLUAPV)
                If dsTransferenciaVerbaFornecedor.CADTRNVBAFRN.Rows.Count = 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Transferencia Verbas não econtrada|", "")
                End If
                Dim CADTRNVBAFRNRow As DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow
                CADTRNVBAFRNRow = dsTransferenciaVerbaFornecedor.CADTRNVBAFRN(0)

                'Obter e-mail do remetente
                Dim AcordoComercial As New AcordoComercialBLL
                Dim dsContaUsuario As DatasetContaUsuario
                dsContaUsuario = AcordoComercial.ObterContaUsuario(CADTRNVBAFRNRow.CODFNC)
                If dsContaUsuario.T0104596.Rows.Count = 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Não encontrado e-mail para o funcionário " & CADTRNVBAFRNRow.CODFNC.ToString & "|", "")
                End If
                Dim T0104596row As DatasetContaUsuario.T0104596Row
                T0104596row = dsContaUsuario.T0104596(0)
                Dim emailRemetente As String = T0104596row.NOMUSRRCF.ToLower.Trim & "@martins.com.br"

                ''''''''''''''''''''''''''''''''''
                'Inserindo a Capa da Mensagem
                ''''''''''''''''''''''''''''''''''
                Dim newRowCpa As MensagemEletronica.dataSetMensagemEletronica.T0134274Row
                newRowCpa = CType(dsMensagemEltronica.T0134274.NewRow, MensagemEletronica.dataSetMensagemEletronica.T0134274Row)
                newRowCpa.TIPMSGCREETN = 46
                newRowCpa.NUMSEQMSGCREETN = 0
                newRowCpa.SetDATENVMSGCREETNNull()
                newRowCpa.DESASSCREETN = "Fluxo Transferencia Verbas Fornecedor"
                dsMensagemEltronica.T0134274.Rows.Add(newRowCpa)

                ''''''''''''''''''''''''''''''''''
                'Inserindo o Remetente da Mensagem
                ''''''''''''''''''''''''''''''''''
                Dim newRowRem As MensagemEletronica.dataSetMensagemEletronica.T0134282Row
                newRowRem = CType(dsMensagemEltronica.T0134282.NewRow, MensagemEletronica.dataSetMensagemEletronica.T0134282Row)
                newRowRem.TIPMSGCREETN = 46
                newRowRem.NUMSEQMSGCREETN = 0
                newRowRem.TIPENDCREETN = 1 'Remetente
                newRowRem.NUMSEQENDCREETN = 1
                newRowRem.IDTENDCREETN = emailRemetente
                dsMensagemEltronica.T0134282.Rows.Add(newRowRem)

                '''''''''''''''''''''''''''''''''''''
                'Inserindo o Destinatário da Mensagem
                '''''''''''''''''''''''''''''''''''''
                Dim newRowDst As MensagemEletronica.dataSetMensagemEletronica.T0134282Row
                newRowDst = CType(dsMensagemEltronica.T0134282.NewRow, MensagemEletronica.dataSetMensagemEletronica.T0134282Row)
                newRowDst.TIPMSGCREETN = 46
                newRowDst.NUMSEQMSGCREETN = 0
                newRowDst.TIPENDCREETN = 2 'Destinatário
                newRowDst.NUMSEQENDCREETN = 1
                newRowDst.IDTENDCREETN = emailDestinatario
                dsMensagemEltronica.T0134282.Rows.Add(newRowDst)

                ''''''''''''''''''''''''''''''
                'Inserindo o Texto da Mensagem
                ''''''''''''''''''''''''''''''
                Dim lstTextoMensagem As New ArrayList
                lstTextoMensagem.Add("")
                lstTextoMensagem.Add("Sr(a),")
                lstTextoMensagem.Add("")
                lstTextoMensagem.Add("   A transferencia de verbas - Nro " & NUMFLUAPV.ToString & " Está aguardando sua avaliação/aprovação. Clique no link abaixo para dar sequência ao processo.")
                lstTextoMensagem.Add("   http://SIM/AcoesComerciais/default.aspx?pagina=empenhoDoFornecedor&NUMFLUAPV=" & NUMFLUAPV.ToString)
                lstTextoMensagem.Add("")
                lstTextoMensagem.Add("* MENSAGEM AUTOMATICA *")

                For i As Integer = 0 To lstTextoMensagem.Count - 1
                    Dim newRowTxt As MensagemEletronica.dataSetMensagemEletronica.T0134290Row
                    newRowTxt = CType(dsMensagemEltronica.T0134290.NewRow, MensagemEletronica.dataSetMensagemEletronica.T0134290Row)
                    newRowTxt.TIPMSGCREETN = 46
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
        ''' <param name="NUMFLUAPV"></param>
        ''' <param name="emailDestinatario"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	31/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Function EnviarEmailNaIniciacaoDoFluxoDeTransferenciaVerbas(ByVal NUMFLUAPV As Decimal, _
                                                                            ByVal emailDestinatario As ArrayList) As Boolean
            Try
                Dim MensagemEletronica As New MensagemEletronicaBLL
                Dim dsMensagemEltronica As New MensagemEletronica.dataSetMensagemEletronica

                'Obter a transferencia verba
                Dim dsTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                dsTransferenciaVerbaFornecedor = Me.ObterTransferenciaVerbaFornecedor(NUMFLUAPV)
                If dsTransferenciaVerbaFornecedor.CADTRNVBAFRN.Rows.Count = 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Transferencia Verbas não econtrada|", "")
                End If
                Dim CADTRNVBAFRNRow As DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow
                CADTRNVBAFRNRow = dsTransferenciaVerbaFornecedor.CADTRNVBAFRN(0)

                'Obter e-mail do remetente
                Dim AcordoComercial As New AcordoComercialBLL
                Dim dsContaUsuario As DatasetContaUsuario
                dsContaUsuario = AcordoComercial.ObterContaUsuario(CADTRNVBAFRNRow.CODFNC)
                If dsContaUsuario.T0104596.Rows.Count = 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Não encontrado e-mail para o funcionário " & CADTRNVBAFRNRow.CODFNC.ToString & "|", "")
                End If
                Dim T0104596row As DatasetContaUsuario.T0104596Row
                T0104596row = dsContaUsuario.T0104596(0)
                Dim emailRemetente As String = T0104596row.NOMUSRRCF.ToLower.Trim & "@martins.com.br"

                ''''''''''''''''''''''''''''''''''
                'Inserindo a Capa da Mensagem
                ''''''''''''''''''''''''''''''''''
                Dim newRowCpa As MensagemEletronica.dataSetMensagemEletronica.T0134274Row
                newRowCpa = CType(dsMensagemEltronica.T0134274.NewRow, MensagemEletronica.dataSetMensagemEletronica.T0134274Row)
                newRowCpa.TIPMSGCREETN = 46
                newRowCpa.NUMSEQMSGCREETN = 0
                newRowCpa.SetDATENVMSGCREETNNull()
                newRowCpa.DESASSCREETN = "Fluxo Transferencia Verbas Fornecedor"
                dsMensagemEltronica.T0134274.Rows.Add(newRowCpa)

                ''''''''''''''''''''''''''''''''''
                'Inserindo o Remetente da Mensagem
                ''''''''''''''''''''''''''''''''''
                Dim newRowRem As MensagemEletronica.dataSetMensagemEletronica.T0134282Row
                newRowRem = CType(dsMensagemEltronica.T0134282.NewRow, MensagemEletronica.dataSetMensagemEletronica.T0134282Row)
                newRowRem.TIPMSGCREETN = 46
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
                    newRowDst.TIPMSGCREETN = 46
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
                lstTextoMensagem.Add("   A transferencia de verbas - Nro " & NUMFLUAPV.ToString & " Está aguardando sua avaliação/aprovação. Clique no link abaixo para dar sequência ao processo.")
                'lstTextoMensagem.Add("   http://SIM/AcoesComerciais/default.aspx?pagina=empenhoDoFornecedor&NUMFLUAPV=" & NUMFLUAPV.ToString)
                lstTextoMensagem.Add("   http://SIM/AcoesComerciais/default.aspx")
                lstTextoMensagem.Add("")
                lstTextoMensagem.Add("* MENSAGEM AUTOMATICA *")

                For i As Integer = 0 To lstTextoMensagem.Count - 1
                    Dim newRowTxt As MensagemEletronica.dataSetMensagemEletronica.T0134290Row
                    newRowTxt = CType(dsMensagemEltronica.T0134290.NewRow, MensagemEletronica.dataSetMensagemEletronica.T0134290Row)
                    newRowTxt.TIPMSGCREETN = 46
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
        ''' <param name="NUMFLUAPV"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	17/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ReservarSaldo(ByVal NUMFLUAPV As Decimal, _
                                      ByVal DATHRAAPVFLU As Date) As Boolean
            Try
                'Consulta A relação de transferencias do fluxo
                Dim dsTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                dsTransferenciaVerbaFornecedor = Me.ObterRelacoesTransferenciaVerbaFornecedor(0, NUMFLUAPV, 0, 0)
                If dsTransferenciaVerbaFornecedor.RLCTRNVBAFRN.Rows.Count = 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Não encontrado Relacao para Transferencia Verbas|", "")
                End If

                Dim dsReservaSaldoFornecedor As New DatasetReservaSaldoFornecedor
                For Each RLCTRNVBAFRNRow As DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRNRow In dsTransferenciaVerbaFornecedor.RLCTRNVBAFRN
                    Dim T0123159Row As DatasetReservaSaldoFornecedor.T0123159Row
                    T0123159Row = dsReservaSaldoFornecedor.T0123159.FindByCODFRNCODACOCMCTIPDSNDSCBNF(RLCTRNVBAFRNRow.CODFRN, RLCTRNVBAFRNRow.NUMFLUAPV.ToString & "/01", RLCTRNVBAFRNRow.TIPDSNDSCBNFORITRN)

                    If T0123159Row Is Nothing Then 'A linha ainda não existe
                        T0123159Row = dsReservaSaldoFornecedor.T0123159.NewT0123159Row
                        With T0123159Row
                            .CODFRN = RLCTRNVBAFRNRow.CODFRN
                            .CODACOCMC = RLCTRNVBAFRNRow.NUMFLUAPV.ToString & "/01"
                            .TIPDSNDSCBNF = RLCTRNVBAFRNRow.TIPDSNDSCBNFORITRN
                            .VLRSLDRSVFRN = RLCTRNVBAFRNRow.VLRLMTCTB
                            .FLGAPVACOCMC = "N"
                            .FLGLMTCNTCRR = String.Empty
                            .TIPACOCMC = "V"
                            .DATAPVACOCMC = DATHRAAPVFLU
                        End With
                    Else 'A linha ja existe, neste caso aumenta o saldo
                        With T0123159Row
                            .VLRSLDRSVFRN = .VLRSLDRSVFRN + RLCTRNVBAFRNRow.VLRLMTCTB
                        End With
                    End If

                    If T0123159Row.RowState = DataRowState.Detached Then
                        dsReservaSaldoFornecedor.T0123159.AddT0123159Row(T0123159Row)
                    End If
                Next
                Me.AtualizarReservaSaldoFornecedor(dsReservaSaldoFornecedor)

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
        ''' <param name="NUMFLUAPV"></param>
        ''' <param name="DATHRAAPVFLU"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	17/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function LiberarReservaSaldo(ByVal NUMFLUAPV As Decimal, _
                                            ByVal DATAPVACOCMC As Date) As Boolean
            Try
                Dim CODACOCMC As String = NUMFLUAPV.ToString & "/01"
                Dim dsReservaSaldoFornecedor As DatasetReservaSaldoFornecedor

                dsReservaSaldoFornecedor = Me.ObterReservasSaldoFornecedor(CODACOCMC, 0, Nothing, Nothing, Nothing, 0)
                For Each T0123159Row As DatasetReservaSaldoFornecedor.T0123159Row In dsReservaSaldoFornecedor.T0123159
                    With T0123159Row
                        .FLGAPVACOCMC = "S"
                        .DATAPVACOCMC = DATAPVACOCMC
                    End With
                Next

                Me.AtualizarReservaSaldoFornecedor(dsReservaSaldoFornecedor)
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
        ''' <param name="NUMFLUAPV"></param>
        ''' <param name="DATAPVACOCMC"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	18/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ExcluirReservaSaldo(ByVal NUMFLUAPV As Decimal) As Boolean
            Try
                Dim CODACOCMC As String = NUMFLUAPV.ToString & "/01"
                Dim dsReservaSaldoFornecedor As DatasetReservaSaldoFornecedor

                dsReservaSaldoFornecedor = Me.ObterReservasSaldoFornecedor(CODACOCMC, 0, Nothing, Nothing, Nothing, 0)
                For Each T0123159Row As DatasetReservaSaldoFornecedor.T0123159Row In dsReservaSaldoFornecedor.T0123159
                    T0123159Row.Delete()
                Next

                Me.AtualizarReservaSaldoFornecedor(dsReservaSaldoFornecedor)
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
        ''' Este método retorna dados da entidade T0123159 com base na sua chave primária.
        ''' Descrição da entidade:MOVIMENTO DIARIO RESERVA DE SALDO FORNECEDOR
        ''' </summary>
        ''' <param name="CODACOCMC">CODIGO DA ACAO COMERCIAL.</param>
        ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
        ''' <param name="TIPDSNDSCBNF">TIPO DESTINO / DESCONTO BONIFICADO.</param>
        ''' <returns>Retorna um DataSet com a tabela "T0123159" preenchida.</returns>
        ''' <remarks>
        ''' Sempre que um código inválido for informado, uma exception será retornada.
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    17/12/2007  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterReservaSaldoFornecedor(ByVal CODACOCMC As String, _
                                                    ByVal CODFRN As Decimal, _
                                                    ByVal TIPDSNDSCBNF As Decimal) As DatasetReservaSaldoFornecedor
            Try

                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL

                Dim DatasetReservaSaldoFornecedor As DatasetReservaSaldoFornecedor
                DatasetReservaSaldoFornecedor = ContaCorrenteFornecedor.ObterReservaSaldoFornecedor(CODACOCMC, CODFRN, TIPDSNDSCBNF)

                Dim configuracao As Martins.ConfigurationManagement.MartinsApplicationConfiguration
                configuracao = CType(Martins.ConfigurationManagement.ConfigurationManager.Read(Martins.ConfigurationManagement.ConfigurationManager.GetDefaultSection()), Martins.ConfigurationManagement.MartinsApplicationConfiguration)

                Me.SetComplete()
                Return DatasetReservaSaldoFornecedor

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
        ''' Este método retorna dados da entidade T0123159 com base em outros atributos.
        ''' Descrição da entidade:MOVIMENTO DIARIO RESERVA DE SALDO FORNECEDOR
        ''' </summary>
        ''' <param name="CODACOCMC">CODIGO DA ACAO COMERCIAL.</param>
        ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
        ''' <param name="DATAPVACOCMC">DATA DE APROVACAO DA ACAO COMERCIAL.</param>
        ''' <param name="DATAPVACOCMCInicial">DATA DE APROVACAO DA ACAO COMERCIAL INICIAL.</param>
        ''' <param name="DATAPVACOCMCFinal">DATA DE APROVACAO DA ACAO COMERCIAL FINAL.</param>
        ''' <param name="TIPDSNDSCBNF">TIPO DESTINO / DESCONTO BONIFICADO.</param>
        ''' <returns>Retorna um DataSet com a tabela "T0123159" preenchida.</returns>
        ''' <remarks>
        ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
        ''' Um parametro do tipo número é omitido quando for zero,
        ''' Um parametro do tipo String é omitido quando for vazia,
        ''' Um parametro do tipo data   é omitido quando for Nothing,
        ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    17/12/2007  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterReservasSaldoFornecedor(ByVal CODACOCMC As String, _
                                                     ByVal CODFRN As Decimal, _
                                                     ByVal DATAPVACOCMC As Date, _
                                                     ByVal DATAPVACOCMCInicial As Date, _
                                                     ByVal DATAPVACOCMCFinal As Date, _
                                                     ByVal TIPDSNDSCBNF As Decimal) As DatasetReservaSaldoFornecedor
            Try
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL

                Dim DatasetReservaSaldoFornecedor As DatasetReservaSaldoFornecedor
                DatasetReservaSaldoFornecedor = ContaCorrenteFornecedor.ObterReservasSaldoFornecedor(CODACOCMC, CODFRN, DATAPVACOCMC, DATAPVACOCMCInicial, DATAPVACOCMCFinal, TIPDSNDSCBNF)

                Me.SetComplete()
                Return DatasetReservaSaldoFornecedor

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
        ''' <param name="DatasetReservaSaldoFornecedor">DataSet com os dados a serem atualizados</param>
        ''' <remarks>
        ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    17/12/2007  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Sub AtualizarReservaSaldoFornecedor(ByVal DatasetReservaSaldoFornecedor As DatasetReservaSaldoFornecedor)
            Try

                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL

                ContaCorrenteFornecedor.AtualizarReservaSaldoFornecedor(DatasetReservaSaldoFornecedor)
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
        ''' <param name="vDatRef"></param>
        ''' <param name="vCodFrn"></param>
        ''' <param name="vTipDsnDscBnf"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	21/11/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterSaldoDisponivelFornecedor(ByVal vDatRef As Date, _
                                                       ByVal vCodFrn As Decimal, _
                                                       ByVal vTipDsnDscBnf As Decimal) As DatasetSelecaoValorDisponivelFornecedor
            Try

                Dim ds As DatasetSelecaoValorDisponivelFornecedor
                ds = Me.ObterSaldoDisponivelFornecedor(vDatRef, vCodFrn.ToString, vTipDsnDscBnf)
                Me.SetComplete()
                Return ds
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
        ''' <param name="vDatRef"></param>
        ''' <param name="vCodFrn"></param>
        ''' <param name="In_TipDsnDscBnf"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	22/2/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterSaldoDisponivelFornecedor(ByVal vDatRef As Date, _
                                                       ByVal vCodFrn As Decimal, _
                                                       ByVal In_TipDsnDscBnf As String) As DatasetSelecaoValorDisponivelFornecedor
            Try

                Dim ds As DatasetSelecaoValorDisponivelFornecedor
                ds = Me.ObterSaldoDisponivelFornecedor(vDatRef, vCodFrn.ToString, In_TipDsnDscBnf)
                Me.SetComplete()
                Return ds
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
        ''' <param name="vDatRef"></param>
        ''' <param name="vCodFrn"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	11/1/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterSaldoDisponivelFornecedorParaTodosEmpenhos(ByVal vDatRef As Date, _
                                                                         ByVal vCodFrn As Decimal) As DatasetSelecaoValorDisponivelFornecedor
            Try
                Dim ds As New DatasetSelecaoValorDisponivelFornecedor
                Dim dsEmpenho As DatasetEmpenho
                Dim AcordoComercial As New AcordoComercialBLL

                'Obtem todos empenhos
                dsEmpenho = AcordoComercial.ObterEmpenhos("", "", "", 0, "", -1)

                'Varre consultando para todos empenhos
                For Each T0109059Row As DatasetEmpenho.T0109059Row In dsEmpenho.T0109059
                    'Verifica se o empenho nao é o de marketing (78), se for nao inclui
                    If Not T0109059Row.TIPDSNDSCBNF = Constants.EMPENHO_FORNECEDOR_MARKETING Then
                        ds.Merge(Me.ObterSaldoDisponivelFornecedor(vDatRef, vCodFrn.ToString, T0109059Row.TIPDSNDSCBNF))
                    End If
                Next

                Me.SetComplete()
                Return ds
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
        ''' <param name="vDatRef"></param>
        ''' <param name="CodDivCmp"></param>
        ''' <param name="vTipDsnDscBnf"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	22/11/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterSaldoDisponivelFornecedorPorCategoria(ByVal DatRef As Date, _
                                                                   ByVal CodDivCmp As Decimal, _
                                                                   ByVal TipDsnDscBnf As Decimal) As DatasetSelecaoValorDisponivelFornecedor
            Try
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL = New ContaCorrenteFornecedorBLL

                Dim In_CodDivCmp As String
                In_CodDivCmp = ContaCorrenteFornecedor.ObterCodigoFornecedorPorCategoriaSeparadoPorVirgula(CodDivCmp)

                Dim ds As DatasetSelecaoValorDisponivelFornecedor
                ds = Me.ObterSaldoDisponivelFornecedor(DatRef, In_CodDivCmp, TipDsnDscBnf)

                Me.SetComplete()
                Return ds
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
        ''' <param name="DatRef"></param>
        ''' <param name="CodDivCmp"></param>
        ''' <param name="In_TipDsnDscBnf"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	22/2/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterSaldoDisponivelFornecedorPorCategoria(ByVal DatRef As Date, _
                                                                   ByVal CodDivCmp As Decimal) As DatasetSelecaoValorDisponivelFornecedor
            Try
                Dim dsSelecaoValorDisponivelFornecedor As DatasetSelecaoValorDisponivelFornecedor
                dsSelecaoValorDisponivelFornecedor = Me.ObterSaldoDisponivelFornecedorPorCategoriaEOuComprador(DatRef, 0, CodDivCmp)

                Me.SetComplete()
                Return dsSelecaoValorDisponivelFornecedor
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
        ''' <param name="vDatRef"></param>
        ''' <param name="codCpr"></param>
        ''' <param name="vTipDsnDscBnf"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	22/11/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterSaldoDisponivelFornecedorPorComprador(ByVal DatRef As Date, _
                                                                   ByVal CodCpr As Decimal, _
                                                                   ByVal TipDsnDscBnf As Decimal) As DatasetSelecaoValorDisponivelFornecedor
            Try
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL = New ContaCorrenteFornecedorBLL

                Dim In_CodFrn As String
                In_CodFrn = ContaCorrenteFornecedor.ObterCodigoFornecedorPorCompradorSeparadoPorVirgula(CodCpr)

                Dim ds As DatasetSelecaoValorDisponivelFornecedor
                ds = Me.ObterSaldoDisponivelFornecedor(DatRef, In_CodFrn, TipDsnDscBnf)

                Me.SetComplete()
                Return ds
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
        ''' <param name="DatRef"></param>
        ''' <param name="CodCpr"></param>
        ''' <param name="In_TipDsnDscBnf"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	22/2/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterSaldoDisponivelFornecedorPorComprador(ByVal DatRef As Date, _
                                                                   ByVal CodCpr As Decimal) As DatasetSelecaoValorDisponivelFornecedor
            Try
                Dim dsSelecaoValorDisponivelFornecedor As DatasetSelecaoValorDisponivelFornecedor
                dsSelecaoValorDisponivelFornecedor = Me.ObterSaldoDisponivelFornecedorPorCategoriaEOuComprador(DatRef, CodCpr, 0)

                Me.SetComplete()
                Return dsSelecaoValorDisponivelFornecedor
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
        ''' <param name="DatRef"></param>
        ''' <param name="CodCpr"></param>
        ''' <param name="CodDivCmp"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	18/3/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Function ObterSaldoDisponivelFornecedorPorCategoriaEOuComprador(ByVal DatRef As Date, _
                                                                                ByVal CodCpr As Decimal, _
                                                                                ByVal CodDivCmp As Decimal) As DatasetSelecaoValorDisponivelFornecedor
            Try
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL = New ContaCorrenteFornecedorBLL

                'Utiliza a mesma procedure do relatório por célula
                Dim dsRelatorioSaldoDisponivelFornecedorCelula As DataSetRelatorioSaldoDisponivelFornecedorCelula
                dsRelatorioSaldoDisponivelFornecedorCelula = ContaCorrenteFornecedor.ObterRelatorioSaldoDisponivelFornecedorCelula(CodDivCmp, CodCpr, 0, CType(Format(DatRef, "yyyyMM"), Decimal), 1)

                'Transfere os dados para outro dataset (para manter compatibilitadade com retorno do método que consulta por fornecedor)
                Dim dsSelecaoValorDisponivelFornecedor As New DatasetSelecaoValorDisponivelFornecedor
                dsSelecaoValorDisponivelFornecedor.EnforceConstraints = False

                'Guarda os códigos dos fornecedores pesquisados em string separando com vírgula
                Dim IN_CodFrn As String = String.Empty

                'Varre as linhas retornadas (origem) criando novas linha no destino
                For Each linhaOrigem As DataSetRelatorioSaldoDisponivelFornecedorCelula.TbAnaliticoRow In dsRelatorioSaldoDisponivelFornecedorCelula.TbAnalitico

                    'Declara variaveis que receberão os valores retornados no dataset,
                    'as variavies são necessárias para evitar problemas de campo com valor nulo
                    Dim CODFRN As Long = 0
                    Dim TIPEMPENHO As Decimal = 0
                    Dim DESEMPENHO As String = String.Empty
                    Dim SALDO As Decimal = 0
                    Dim NOMFRN As String = String.Empty
                    Dim VlrSldRsv As Decimal = 0
                    Dim TIPDSNDSCBNF As Decimal = 0
                    Dim DESDSNDSCBNF As String = String.Empty
                    Dim VlrRcb As Decimal = 0
                    Dim TipAlcVbaFrn As Decimal = 0
                    Dim DesAlcVbaFrn As String = String.Empty
                    Dim PerAlcVbaFrn As Decimal = 0
                    Dim VlrAlcVbaFrn As Decimal = 0
                    Dim VlrRcbAlcVbaFrn As Decimal = 0
                    Dim VlrSldDspAlcVbaFrn As Decimal = 0
                    Dim PmtDdo As String = String.Empty

                    'Transfere os valores da linha para as variáveis
                    If Not linhaOrigem.IsNull("CODFRN") Then CODFRN = linhaOrigem.CODFRN
                    If Not linhaOrigem.IsNull("TIPEMPENHO") Then TIPEMPENHO = linhaOrigem.TIPEMPENHO
                    If Not linhaOrigem.IsNull("DESEMPENHO") Then DESEMPENHO = linhaOrigem.DESEMPENHO
                    If Not linhaOrigem.IsNull("SALDO") Then SALDO = linhaOrigem.SALDO
                    If Not linhaOrigem.IsNull("NOMFRN") Then NOMFRN = linhaOrigem.NOMFRN
                    If Not linhaOrigem.IsNull("VlrSldRsv") Then VlrSldRsv = linhaOrigem.VlrSldRsv
                    If Not linhaOrigem.IsNull("TIPDSNDSCBNF") Then TIPDSNDSCBNF = linhaOrigem.TIPDSNDSCBNF
                    If Not linhaOrigem.IsNull("DESDSNDSCBNF") Then DESDSNDSCBNF = linhaOrigem.DESDSNDSCBNF
                    If Not linhaOrigem.IsNull("VlrRcb") Then VlrRcb = linhaOrigem.VlrRcb
                    If Not linhaOrigem.IsNull("TipAlcVbaFrn") Then TipAlcVbaFrn = linhaOrigem.TipAlcVbaFrn
                    If Not linhaOrigem.IsNull("DesAlcVbaFrn") Then DesAlcVbaFrn = linhaOrigem.DesAlcVbaFrn
                    If Not linhaOrigem.IsNull("PerAlcVbaFrn") Then PerAlcVbaFrn = linhaOrigem.PerAlcVbaFrn
                    If Not linhaOrigem.IsNull("VlrAlcVbaFrn") Then VlrAlcVbaFrn = linhaOrigem.VlrAlcVbaFrn
                    If Not linhaOrigem.IsNull("VlrRcbAlcVbaFrn") Then VlrRcbAlcVbaFrn = linhaOrigem.VlrRcbAlcVbaFrn
                    If Not linhaOrigem.IsNull("VlrSldDspAlcVbaFrn") Then VlrSldDspAlcVbaFrn = linhaOrigem.VlrSldDspAlcVbaFrn
                    If Not linhaOrigem.IsNull("PmtDdo") Then PmtDdo = linhaOrigem.PmtDdo

                    If DesAlcVbaFrn.Trim <> String.Empty Then 'Alocação
                        'Obtem o saldo Alocado
                        If VlrSldDspAlcVbaFrn <> 0 Then
                            Dim linhaDestino As DatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedorRow
                            linhaDestino = dsSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedor.NewtbTransfenciaEmpenhosDoFornecedorRow
                            With linhaDestino
                                .NomeCategoria = ""
                                .NomeComprador = ""
                                .CodigoFornecedor = CODFRN
                                .NomeFornecedor = NOMFRN
                                .CodigoEmpenho = TIPDSNDSCBNF
                                .NomeEmpenho = DESDSNDSCBNF
                                .CodigoAlocacao = TipAlcVbaFrn
                                .NomeAlocacao = DesAlcVbaFrn
                                .ValorAlocado = VlrAlcVbaFrn
                                .ValorReceber = VlrRcbAlcVbaFrn
                                .SaldoDisponivel = VlrSldDspAlcVbaFrn
                                .ValorTransferir = 0
                            End With
                            dsSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedor.AddtbTransfenciaEmpenhosDoFornecedorRow(linhaDestino)
                        End If
                    Else 'Conta Corrente
                        'Obter o saldo de conta corrente
                        If (SALDO - VlrSldRsv - (VlrRcbAlcVbaFrn + VlrAlcVbaFrn)) <> 0 Then
                            Dim linhaDestino As DatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedorRow
                            linhaDestino = dsSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedor.NewtbTransfenciaEmpenhosDoFornecedorRow
                            With linhaDestino
                                .NomeCategoria = ""
                                .NomeComprador = ""
                                .CodigoFornecedor = CODFRN
                                .NomeFornecedor = NOMFRN
                                .CodigoEmpenho = TIPEMPENHO
                                .NomeEmpenho = DESEMPENHO
                                .CodigoAlocacao = 3
                                .NomeAlocacao = "CONTA CORRENTE"
                                .ValorAlocado = 0
                                .ValorReceber = 0
                                .SaldoDisponivel = SALDO - VlrSldRsv
                                .ValorTransferir = 0
                            End With
                            dsSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedor.AddtbTransfenciaEmpenhosDoFornecedorRow(linhaDestino)
                        End If
                    End If

                    'Guarda o códigos dos fornecedores separando por vírgula
                    If IN_CodFrn.IndexOf(" " & CODFRN.ToString) < 0 Then
                        If IN_CodFrn <> String.Empty Then
                            IN_CodFrn &= ", "
                        End If
                        IN_CodFrn &= (" " & CODFRN.ToString)
                    End If
                Next

                'Varre o dataset (que será retornado) para deduzir os valores 
                'alocados da conta corrente
                For Each linhaDestino As DatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedorRow In dsSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedor
                    If linhaDestino.NomeAlocacao = "CONTA CORRENTE" Then
                        For Each linhaAlocacao As DatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedorRow In dsSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedor.Select("CodigoFornecedor=" & linhaDestino.CodigoFornecedor.ToString & " And CodigoEmpenho = " & linhaDestino.CodigoEmpenho.ToString)
                            If linhaAlocacao.NomeAlocacao <> "CONTA CORRENTE" Then
                                linhaDestino.SaldoDisponivel = linhaDestino.SaldoDisponivel - linhaAlocacao.SaldoDisponivel
                            End If
                        Next
                    End If
                Next

                'Obtem dados do fornecedor, comprador e divisão de compra e preenche a tabela de retorno
                If IN_CodFrn <> String.Empty Then
                    dsSelecaoValorDisponivelFornecedor.Merge(ContaCorrenteFornecedor.ObterFornecedorCompradorEDivisaoCompra(IN_CodFrn))
                    For Each linhaDestino As DatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedorRow In dsSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedor
                        Dim linhaOrigem As DatasetSelecaoValorDisponivelFornecedor.tbFornecedorCompradorEDivisaoCompraRow
                        linhaOrigem = dsSelecaoValorDisponivelFornecedor.tbFornecedorCompradorEDivisaoCompra.FindByCODFRN(linhaDestino.CodigoFornecedor)
                        If Not linhaOrigem Is Nothing Then
                            linhaDestino.NomeCategoria = linhaOrigem.DESDIVCMP
                            linhadestino.NomeComprador = linhaOrigem.NOMCPR
                            linhadestino.CodigoComprador = linhaOrigem.CODCPR
                            linhaDestino.NomeFornecedor = linhaOrigem.NOMFRN
                        End If
                    Next
                End If

                Me.SetComplete()
                Return dsSelecaoValorDisponivelFornecedor
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
        ''' Consulta saldo para varios fornecedores e vários empenhos
        ''' </summary>
        ''' <param name="vDatRef"></param>
        ''' <param name="IN_CodFrn"></param>
        ''' <param name="IN_TipDsnDscBnf"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	22/2/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterSaldoDisponivelFornecedor(ByVal vDatRef As Date, _
                                                       ByVal IN_CodFrn As String, _
                                                       ByVal IN_TipDsnDscBnf As String) As DatasetSelecaoValorDisponivelFornecedor
            Try

                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorBLL
                Dim dsSelecaoValorDisponivelFornecedorFinal As New DatasetSelecaoValorDisponivelFornecedor
                Dim IN_TipDsnDscBnfArray() As String = Split(IN_TipDsnDscBnf.Trim, ",")

                dsSelecaoValorDisponivelFornecedorFinal.EnforceConstraints = False

                'Prepara os parametros da cláusula In
                If IN_TipDsnDscBnfArray.Length > 0 Then
                    For i As Integer = 0 To IN_TipDsnDscBnfArray.Length - 1
                        If IsNumeric(IN_TipDsnDscBnfArray(i)) Then
                            Dim TipDsnDscBnf As Decimal = CType(IN_TipDsnDscBnfArray(i), Decimal)
                            Dim dsSelecaoValorDisponivelFornecedorLaco As DatasetSelecaoValorDisponivelFornecedor
                            dsSelecaoValorDisponivelFornecedorLaco = Me.ObterSaldoDisponivelFornecedor(vDatRef, IN_CodFrn, TipDsnDscBnf)
                            dsSelecaoValorDisponivelFornecedorFinal.Merge(dsSelecaoValorDisponivelFornecedorLaco)
                        End If
                    Next
                End If

                Me.SetComplete()
                Return dsSelecaoValorDisponivelFornecedorFinal
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
        ''' <param name="vDatRef"></param>
        ''' <param name="vCodFrn"></param>
        ''' <param name="vTipDsnDscBnf"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	21/11/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterSaldoDisponivelFornecedor(ByVal vDatRef As Date, _
                                                       ByVal IN_CodFrn As String, _
                                                       ByVal vTipDsnDscBnf As Decimal) As DatasetSelecaoValorDisponivelFornecedor
            Try

                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorBLL
                Dim dsSelecaoValorDisponivelFornecedorFinal As New DatasetSelecaoValorDisponivelFornecedor
                Dim IN_CODFRNArray() As String = Split(IN_CodFrn.Trim, ",")

                dsSelecaoValorDisponivelFornecedorFinal.EnforceConstraints = False

                'Prepara os parametros da cláusula In
                If IN_CODFRNArray.Length > 0 Then
                    For i As Integer = 0 To IN_CODFRNArray.Length - 1

                        If IsNumeric(IN_CODFRNArray(i)) Then
                            Dim vCodFrn As Decimal = CType(IN_CODFRNArray(i), Decimal)
                            Dim dsSelecaoValorDisponivelFornecedorLaco As DatasetSelecaoValorDisponivelFornecedor

                            dsSelecaoValorDisponivelFornecedorLaco = ContaCorrenteFornecedor.ObterSelecaoValorDisponivelFornecedor(vDatRef, vCodFrn, vTipDsnDscBnf)

                            'Soma o total de VlrSldDspAlcVbaFrn (Regra)
                            Dim SomaDeVlrSldDspAlcVbaFrn As Decimal = 0
                            For Each linhaOrigem As DatasetSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedorRow In dsSelecaoValorDisponivelFornecedorLaco.tbSelecaoValorDisponivelFornecedor
                                If Not linhaOrigem.IsVlrSldDspAlcVbaFrnNull Then
                                    SomaDeVlrSldDspAlcVbaFrn += linhaOrigem.VlrSldDspAlcVbaFrn
                                End If
                            Next

                            'Obtem o primeiro valor encontrado para VlrSldDsp (Regra)
                            Dim PrimeiroVlrSldDsp As Decimal = 0
                            If Not dsSelecaoValorDisponivelFornecedorLaco.tbSelecaoValorDisponivelFornecedor.Item(0).IsVlrSldDspNull Then
                                PrimeiroVlrSldDsp = dsSelecaoValorDisponivelFornecedorLaco.tbSelecaoValorDisponivelFornecedor.Item(0).VlrSldDsp
                            End If

                            'Calcular saldo para conta corrente
                            Dim ValorSaldoDisponivelContaCorrente As Decimal = 0
                            ValorSaldoDisponivelContaCorrente = PrimeiroVlrSldDsp - SomaDeVlrSldDspAlcVbaFrn

                            'Transfere os valores de uma tabela para outra dentro do mesmo dataset
                            'Nesse laço está sendo transferido todos valores retornando pela
                            'procedure PL-SQL, retorno do método: ObterSelecaoValorDisponivelFornecedor.
                            'No final será inserida uma nova linha referente ao valor do saldo 
                            'disponível para conta corrente
                            dsSelecaoValorDisponivelFornecedorLaco.EnforceConstraints = False
                            For Each linhaOrigem As DatasetSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedorRow In dsSelecaoValorDisponivelFornecedorLaco.tbSelecaoValorDisponivelFornecedor
                                If Not linhaOrigem.IsNull("DesAlcVbaFrn") Then
                                    Dim linhaDestino As DatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedorRow
                                    linhaDestino = dsSelecaoValorDisponivelFornecedorLaco.tbTransfenciaEmpenhosDoFornecedor.NewtbTransfenciaEmpenhosDoFornecedorRow
                                    With linhaDestino
                                        .NomeCategoria = ""
                                        .NomeComprador = ""
                                        If Not linhaOrigem.IsNull("CodFrn") Then .CodigoFornecedor = linhaOrigem.CodFrn
                                        .NomeFornecedor = ""
                                        .CodigoEmpenho = linhaOrigem.TipDsnDscBnf
                                        .NomeEmpenho = ""
                                        If Not linhaOrigem.Isnull("TipAlcVbaFrn") Then .CodigoAlocacao = linhaOrigem.TipAlcVbaFrn
                                        If Not linhaOrigem.Isnull("DesAlcVbaFrn") Then .NomeAlocacao = linhaOrigem.DesAlcVbaFrn
                                        If Not linhaOrigem.IsNull("VlrAlcVbaFrn") Then .ValorAlocado = linhaOrigem.VlrAlcVbaFrn
                                        If Not linhaOrigem.IsNull("VlrRcbAlcVbaFrn") Then .ValorReceber = linhaOrigem.VlrRcbAlcVbaFrn
                                        If Not linhaOrigem.IsNull("VlrRcbAlcVbaFrn") Then .SaldoDisponivel = linhaOrigem.VlrRcbAlcVbaFrn + linhaOrigem.VlrAlcVbaFrn
                                        .ValorTransferir = 0
                                    End With
                                    dsSelecaoValorDisponivelFornecedorLaco.tbTransfenciaEmpenhosDoFornecedor.AddtbTransfenciaEmpenhosDoFornecedorRow(linhaDestino)
                                End If
                            Next

                            'Adiciona a linha do conta corrente
                            If ValorSaldoDisponivelContaCorrente <> 0 Or ValorSaldoDisponivelContaCorrente = 0 Then
                                Dim linhaDestino As DatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedorRow
                                linhaDestino = dsSelecaoValorDisponivelFornecedorLaco.tbTransfenciaEmpenhosDoFornecedor.NewtbTransfenciaEmpenhosDoFornecedorRow
                                With linhaDestino
                                    .NomeCategoria = ""
                                    .NomeComprador = ""
                                    .CodigoFornecedor = vCodFrn
                                    .NomeFornecedor = ""
                                    .CodigoEmpenho = vTipDsnDscBnf
                                    .NomeEmpenho = ""
                                    .CodigoAlocacao = 3
                                    .NomeAlocacao = "CONTA CORRENTE"
                                    .ValorAlocado = 0
                                    .ValorReceber = 0
                                    .SaldoDisponivel = ValorSaldoDisponivelContaCorrente
                                    .ValorTransferir = 0
                                End With
                                dsSelecaoValorDisponivelFornecedorLaco.tbTransfenciaEmpenhosDoFornecedor.AddtbTransfenciaEmpenhosDoFornecedorRow(linhaDestino)
                            End If

                            dsSelecaoValorDisponivelFornecedorFinal.Merge(dsSelecaoValorDisponivelFornecedorLaco)
                        End If

                    Next
                End If

                'Obtem os empenhos e preenche na tabela de retorno
                Dim AcordoComercialBP As New AcordoComercialBLL
                Dim dsEmpenho As DatasetEmpenho
                dsEmpenho = AcordoComercialBP.ObterEmpenho(vTipDsnDscBnf)
                If dsEmpenho.T0109059.Rows.Count > 0 Then
                    Dim linhaT0109059 As DatasetEmpenho.T0109059Row
                    linhaT0109059 = dsEmpenho.T0109059(0)
                    For Each linhaDestino As DatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedorRow In dsSelecaoValorDisponivelFornecedorFinal.tbTransfenciaEmpenhosDoFornecedor
                        linhaDestino.NomeEmpenho = linhaT0109059.DESDSNDSCBNF
                    Next
                End If

                'Obtem dados do fornecedor, comprador e divisão de compra e preenche a tabela de retorno
                dsSelecaoValorDisponivelFornecedorFinal.Merge(ContaCorrenteFornecedor.ObterFornecedorCompradorEDivisaoCompra(IN_CodFrn))
                For Each linhaDestino As DatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedorRow In dsSelecaoValorDisponivelFornecedorFinal.tbTransfenciaEmpenhosDoFornecedor
                    Dim linhaOrigem As DatasetSelecaoValorDisponivelFornecedor.tbFornecedorCompradorEDivisaoCompraRow
                    linhaOrigem = dsSelecaoValorDisponivelFornecedorFinal.tbFornecedorCompradorEDivisaoCompra.FindByCODFRN(linhaDestino.CodigoFornecedor)
                    If Not linhaOrigem Is Nothing Then
                        linhaDestino.NomeCategoria = linhaOrigem.DESDIVCMP
                        linhadestino.NomeComprador = linhaOrigem.NOMCPR
                        linhaDestino.NomeFornecedor = linhaOrigem.NOMFRN
                    End If
                Next

                Me.SetComplete()
                Return dsSelecaoValorDisponivelFornecedorFinal
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
        ''' 	[Marcos Queiroz]	26/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Function ObterFuncionarioAprovadorDaControladoriaQuandoMesLancamentoForDiferenteDoMesDeAprovacao() As Decimal
            Try
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorBLL
                Dim result As Decimal

                result = ContaCorrenteFornecedor.ObterFuncionarioAprovadorDaControladoriaQuandoMesLancamentoForDiferenteDoMesDeAprovacao
                Me.SetComplete()
                Return result

            Catch ex As Martins.ExceptionManagement.BaseApplicationException
                Me.SetAbort()
                Throw ex
            Catch ex As Exception
                Me.SetAbort()
                Throw New Martins.ExceptionManagement.MartinsSystemException(ex.Message, ErrorConstants.SYSTEM_ERROR, ex)
            End Try
        End Function

        Public Function ClonarTransferenciaEmpenhoFornecedor(ByVal NUMFLUAPV As Decimal) As Decimal

            Try
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorBLL
                Dim ProximoNUMFLUAPV As Decimal

                'Obtem o código da proxima transferencia
                ProximoNUMFLUAPV = ObterNovaChaveTransferenciaVerba()

                'Consulta a transferencia de origem
                Dim dsTransferenciaVerbaFornecedorOrigem As DatasetTransferenciaVerbaFornecedor
                dsTransferenciaVerbaFornecedorOrigem = Me.ObterTransferenciaVerbaFornecedor(NUMFLUAPV)

                'Prepara o dataset de destino
                Dim dsTransferenciaVerbaFornecedorDestino As New DatasetTransferenciaVerbaFornecedor

                'Copia os dados da origem para o destino (Tabela cadastro)
                For Each CADTRNVBAFRNRow As DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow In dsTransferenciaVerbaFornecedorOrigem.CADTRNVBAFRN
                    dsTransferenciaVerbaFornecedorDestino.CADTRNVBAFRN.AddCADTRNVBAFRNRow(ProximoNUMFLUAPV, _
                                                                 Constants.TIPSTAFLUAPV_NOVO, _
                                                                 CADTRNVBAFRNRow.TIPDSNDSCBNFDSNTRN, _
                                                                 CADTRNVBAFRNRow.TIPALCVBAFRN, _
                                                                 CADTRNVBAFRNRow.DESJSTTRNVBA, _
                                                                 CADTRNVBAFRNRow.CODFNC, _
                                                                 CADTRNVBAFRNRow.INDMESTRNFLU, _
                                                                 CADTRNVBAFRNRow.INDFLUTRNVBAMKT, _
                                                                 CADTRNVBAFRNRow.PERPSQSLDFRN)
                Next

                'Copia os dados da origem para o destino (Relacao)
                For Each RLCTRNVBAFRNRow As DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRNRow In dsTransferenciaVerbaFornecedorOrigem.RLCTRNVBAFRN
                    dsTransferenciaVerbaFornecedorDestino.RLCTRNVBAFRN.AddRLCTRNVBAFRNRow(ProximoNUMFLUAPV, _
                                                                  RLCTRNVBAFRNRow.CODFRN, _
                                                                  RLCTRNVBAFRNRow.TIPDSNDSCBNFORITRN, _
                                                                  RLCTRNVBAFRNRow.TIPALCVBAFRN, _
                                                                  RLCTRNVBAFRNRow.VLRLMTCTB)
                Next

                Me.AtualizarTransferenciaVerbaFornecedor(dsTransferenciaVerbaFornecedorDestino)
                Me.SetComplete()
                Return ProximoNUMFLUAPV
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
        ''' <param name="DATREF"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	9/1/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterCalendarioAnual(ByVal DATREF As Date) As DatasetCalendarioAnual
            Try

                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorBLL

                Dim DatasetCalendarioAnual As DatasetCalendarioAnual
                DatasetCalendarioAnual = ContaCorrenteFornecedor.ObterCalendarioAnual(DATREF)

                Me.SetComplete()
                Return DatasetCalendarioAnual

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
        ''' 	[Danilo Rafael]	29/5/2009	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Function ObterAprovadoresEmpenhoMarketing() As DatasetTransferenciaVerbaFornecedor
            Try
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorBLL
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor

                DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedor.ObterAprovadoresEmpenhoMarketing
                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor

            Catch ex As Martins.ExceptionManagement.BaseApplicationException
                Me.SetAbort()
                Throw ex
            Catch ex As Exception
                Me.SetAbort()
                Throw New Martins.ExceptionManagement.MartinsSystemException(ex.Message, ErrorConstants.SYSTEM_ERROR, ex)
            End Try
        End Function

#Region "Transferencia"

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="TIPUSRSIS"></param>
        ''' <param name="dsTransferenciaVerbaFornecedor"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	15/1/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub AtualizarTransferencia(ByVal NOMACSUSRSIS As String, _
                                          ByVal TIPUSRSIS As String, _
                                          ByVal dsTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor)

            Try
                Dim AcordoComercial As New AcordoComercialBLL

                For Each linha As DatasetTransferenciaVerbaFornecedor.ParametrosTransferenciaRow In dsTransferenciaVerbaFornecedor.ParametrosTransferencia
                    Dim dsDiretoriaEDivisaoDeCompraDeFornecedor As DatasetDiretoriaEDivisaoDeCompraDeFornecedor

                    'Consulta o empenho de origem
                    Dim dsEmpenhoOrigem As DatasetEmpenho
                    dsEmpenhoOrigem = AcordoComercial.ObterEmpenho(linha.TipDsnDscBnfOrigem)
                    If dsEmpenhoOrigem.T0109059.Rows.Count = 0 Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Não encontrado empenho de origem|", "")
                    End If

                    'Consulta o empenho de destino
                    Dim dsEmpenhoDestino As DatasetEmpenho
                    dsEmpenhoDestino = AcordoComercial.ObterEmpenho(linha.TipDsnDscBnfDestino)
                    If dsEmpenhoDestino.T0109059.Rows.Count = 0 Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|" & "Não encontrado empenho de destino|", "")
                    End If

                    If Me.ValidarTransferencia(TIPUSRSIS, linha, dsEmpenhoOrigem.T0109059(0), dsEmpenhoDestino.T0109059(0)) Then
                        If TIPUSRSIS = "X" Then
                            Me.TransferirValoreEntreEmpenhosFornecedor(linha)
                            'Exit Sub 'não pode existir isso, nem sei porque coloquei 31/01/2008
                        Else
                            'Verifica se o empenho de origem é de alocação
                            Dim OrigemTemAlocacao As Boolean = False
                            Dim dsSelecaoValorDisponivelFornecedor As DatasetSelecaoValorDisponivelFornecedor
                            dsSelecaoValorDisponivelFornecedor = ObterSelecaoValorDisponivelFornecedor(linha.DatRefLmt, linha.CodFrnOrigem, linha.TipDsnDscBnfOrigem)
                            For Each linhaValor As DatasetSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedorRow In dsSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedor
                                If Not linhaValor.IsTipAlcVbaFrnNull Then
                                    If linhaValor.TipAlcVbaFrn = 2 Then
                                        OrigemTemAlocacao = True
                                    End If
                                End If
                            Next

                            'Verifica se o empenho de Destino é de alocação
                            Dim DestinoTemAlocacao As Boolean = False
                            dsSelecaoValorDisponivelFornecedor = ObterSelecaoValorDisponivelFornecedor(linha.DatRefLmt, linha.CodFrnDestino, linha.TipDsnDscBnfDestino)
                            For Each linhaValor As DatasetSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedorRow In dsSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedor
                                If Not linhaValor.IsTipAlcVbaFrnNull Then
                                    If linhaValor.TipAlcVbaFrn = 2 Then
                                        DestinoTemAlocacao = True
                                    End If
                                End If
                            Next

                            If OrigemTemAlocacao = True And (DestinoTemAlocacao = False) Then
                                Me.TransferirValoreEntreEmpenhosFornecedor(linha)
                            ElseIf (linha.TipAlcVbaFrnPmtOrigem <> 2) And (OrigemTemAlocacao = False) Then
                                TransferenciaRegraAnterior(NOMACSUSRSIS, TIPUSRSIS, linha, dsEmpenhoOrigem.T0109059(0), dsEmpenhoDestino.T0109059(0))
                            Else
                                dsDiretoriaEDivisaoDeCompraDeFornecedor = ObterDiretoriaEDivisaoDeCompraDeFornecedor(linha.CodFrnDestino)

                                If linha.TipAlcVbaFrnPmtOrigem = 2 Then
                                    If Not dsDiretoriaEDivisaoDeCompraDeFornecedor.TbDiretoriaEDivisaoDeCompraDeFornecedor.Rows.Count = 0 Then
                                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|Transferência não permitida para fornecedor deste BU|", "")
                                    Else
                                        If linha.TipDsnDscBnfDestino = 2 Then
                                            Me.TransferirValoreEntreEmpenhosFornecedor(linha)
                                        Else
                                            Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|Só é permitida transferência para empenho destino de Marketing !!|", "")
                                        End If
                                    End If
                                ElseIf (OrigemTemAlocacao = True) Then
                                    If Not dsDiretoriaEDivisaoDeCompraDeFornecedor.TbDiretoriaEDivisaoDeCompraDeFornecedor.Rows.Count = 0 Then
                                        If linha.TipDsnDscBnfDestino <> 1 And _
                                           linha.TipDsnDscBnfDestino <> 2 Then
                                            Me.TransferirValoreEntreEmpenhosFornecedor(linha)
                                        Else
                                            Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|Transferência não permitida para fornecedor deste BU !! (2)|", "")
                                        End If
                                    Else
                                        Me.TransferirValoreEntreEmpenhosFornecedor(linha)
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next

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
        ''' <param name="ParametrosTransferenciaRow"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	15/1/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub TransferirValoreEntreEmpenhosFornecedor(ByVal ParametrosTransferenciaRow As DatasetTransferenciaVerbaFornecedor.ParametrosTransferenciaRow)
            Try
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorBLL

                ContaCorrenteFornecedor.TransferirValoresEntreEmpenhosFornecedor(ParametrosTransferenciaRow.Valor, _
                                                                                 ParametrosTransferenciaRow.TipAlcVbaFrn, _
                                                                                 ParametrosTransferenciaRow.DatRefLmt, _
                                                                                 ParametrosTransferenciaRow.TipDsnDscBnfOrigem, _
                                                                                 ParametrosTransferenciaRow.TipDsnDscBnfDestino, _
                                                                                 ParametrosTransferenciaRow.CodFrnOrigem, _
                                                                                 ParametrosTransferenciaRow.CodFrnDestino, _
                                                                                 ParametrosTransferenciaRow.VlrLmtCtb, _
                                                                                 ParametrosTransferenciaRow.DesHstLmt, _
                                                                                 ParametrosTransferenciaRow.DesVarHstPadOrigem, _
                                                                                 ParametrosTransferenciaRow.DesVarHstPadDestino, _
                                                                                 ParametrosTransferenciaRow.NomAcsUsrGrcLmt, _
                                                                                 ParametrosTransferenciaRow.TipAlcVbaFrnPmtOrigem, _
                                                                                 ParametrosTransferenciaRow.TipAlcVbaFrnPmtDestino)

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
        ''' <param name="NOMACSUSRSIS"></param>
        ''' <param name="TIPUSRSIS"></param>
        ''' <param name="ParametrosTransferenciaRow"></param>
        ''' <param name="T0109059rowOrigem"></param>
        ''' <param name="T0109059rowDestino"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	15/1/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub TransferenciaRegraAnterior(ByVal NOMACSUSRSIS As String, _
                                               ByVal TIPUSRSIS As String, _
                                               ByVal ParametrosTransferenciaRow As DatasetTransferenciaVerbaFornecedor.ParametrosTransferenciaRow, _
                                               ByVal T0109059rowOrigem As DatasetEmpenho.T0109059Row, _
                                               ByVal T0109059rowDestino As DatasetEmpenho.T0109059Row)
            Try
                Dim strMsg As String
                Dim UsuarioPodeTransferir As Boolean = False
                Dim EmpenhoPermiteTransferencia As Boolean = False
                Dim UsuarioPodeTansferirParaEmpenho As Boolean = False

                Dim FLGCTBDSNDSCOrigem As String
                FLGCTBDSNDSCOrigem = T0109059rowOrigem.FLGCTBDSNDSC

                Dim FLGCTBDSNDSCDestino As String
                FLGCTBDSNDSCDestino = T0109059rowDestino.FLGCTBDSNDSC

                If ParametrosTransferenciaRow.CodFrnOrigem <> ParametrosTransferenciaRow.CodFrnDestino Then

                    'Verifica se o usuário pode fazer a transferencia
                    Dim AcordoComercial As New AcordoComercialBLL
                    Dim dsRelacaoTipoTransferenciaEmpenhoFornecedor As DatasetRelacaoTipoTransferenciaEmpenhoFornecedor
                    dsRelacaoTipoTransferenciaEmpenhoFornecedor = AcordoComercial.ObterRelacaoTipoTransferenciaEmpenhoFornecedor(1, NOMACSUSRSIS, 0)
                    If dsRelacaoTipoTransferenciaEmpenhoFornecedor.tbOperacao01.Rows.Count > 0 Then
                        If Not dsRelacaoTipoTransferenciaEmpenhoFornecedor.tbOperacao01(0).IsNull(0) Then
                            UsuarioPodeTransferir = True
                        End If
                    End If

                    'Verifica se é permitido transferir
                    If Not UsuarioPodeTransferir Then
                        If Not T0109059rowOrigem Is Nothing Then
                            If Not T0109059rowOrigem.IsNull("IndTrnDsnDscBnf") Then
                                If T0109059rowOrigem.INDTRNDSNDSCBNF <> 0 Then
                                    EmpenhoPermiteTransferencia = True
                                End If
                            End If
                        End If
                    End If

                    'Valida se é o usuário pode transferir para o empenho
                    Dim dsTipoTransferenciaXUsuario As DatasetTipoTransferenciaXUsuario
                    dsTipoTransferenciaXUsuario = AcordoComercial.ObterTiposTransferenciasXUsuario(0, NOMACSUSRSIS)
                    For Each linha As DatasetTipoTransferenciaXUsuario.T0135092Row In dsTipoTransferenciaXUsuario.T0135092
                        If linha.T0135033Row.TIPDSNDSCBNF = ParametrosTransferenciaRow.TipDsnDscBnfOrigem Then
                            UsuarioPodeTansferirParaEmpenho = True
                            Exit For
                        End If
                    Next

                    If (UCase(TIPUSRSIS) = "X") Or _
                       ((UCase(TIPUSRSIS) = "D") And UsuarioPodeTransferir) Or _
                       (UsuarioPodeTransferir And UsuarioPodeTansferirParaEmpenho) Then
                        TransferirValoreEntreEmpenhosFornecedor(ParametrosTransferenciaRow)
                    Else
                        If (UCase(TIPUSRSIS) = "D") Then
                            Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|Você não tem permissão para transferir verbas do empenho: " & ParametrosTransferenciaRow.TipDsnDscBnfOrigem & " para outro fornecedor.|", "")
                        Else
                            Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|Não foi possível realizar a transferência .Usuário sem acesso.|", "")
                        End If
                    End If
                ElseIf FLGCTBDSNDSCDestino = "N" Or FLGCTBDSNDSCOrigem = "N" Then
                    If UCase(TIPUSRSIS) = "X" Then
                        'transfere
                        Me.TransferirValoreEntreEmpenhosFornecedor(ParametrosTransferenciaRow)
                    Else
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|Não foi possível realizar a transferência.|", "")
                    End If
                ElseIf ParametrosTransferenciaRow.SaldoDisponivel > ParametrosTransferenciaRow.Valor Then
                    If ParametrosTransferenciaRow.TipDsnDscBnfOrigem <> ParametrosTransferenciaRow.TipDsnDscBnfDestino Then
                        Me.TransferirValoreEntreEmpenhosFornecedor(ParametrosTransferenciaRow)
                    Else
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|Empenhos de Origem e Destino devem ser Diferentes.|", "")
                    End If
                Else
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|Saldo insuficiente para empenho:" & ParametrosTransferenciaRow.TipDsnDscBnfOrigem.ToString & " - Fornecedor:" & ParametrosTransferenciaRow.CodFrnOrigem.ToString & "!|", "")
                End If

                'Verifica o tipo de alocação do empenho de destino
                Dim TIPALCVBAFRNDestino As Decimal = 0
                If Not T0109059rowDestino.IsTIPALCVBAFRNNull Then
                    TIPALCVBAFRNDestino = T0109059rowDestino.TIPALCVBAFRN
                End If

                'Verificar o saldo disponível em alocação de verbas do fornecedor
                Dim SaldoDisponivelAlocacao As Decimal = 0
                Dim TemAlocacaoDestino As Boolean = False
                If TIPALCVBAFRNDestino > 0 Then
                    Dim dsSelecaoValorDisponivelFornecedor As DatasetSelecaoValorDisponivelFornecedor
                    dsSelecaoValorDisponivelFornecedor = ObterSaldoDisponivelFornecedorParaTodosEmpenhos(ParametrosTransferenciaRow.DatRefLmt, ParametrosTransferenciaRow.CodFrnOrigem)
                    For Each dr As DatasetSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedorRow In dsSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedor.Rows
                        If dr.TipAlcVbaFrn = TIPALCVBAFRNDestino Then
                            SaldoDisponivelAlocacao += dr.VlrSldDspAlcVbaFrn
                            TemAlocacaoDestino = True
                        End If
                    Next
                End If

                If TemAlocacaoDestino Then
                    If ParametrosTransferenciaRow.VlrLmtCtb > SaldoDisponivelAlocacao Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|Saldo insuficiente para empenho:" & ParametrosTransferenciaRow.TipDsnDscBnfOrigem.ToString & " - Fornecedor:" & ParametrosTransferenciaRow.CodFrnOrigem.ToString & "!|", "")
                    End If
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
        ''' <param name="linha"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	15/1/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Function ValidarTransferencia(ByVal TIPUSRSIS As String, _
                                              ByVal linha As DatasetTransferenciaVerbaFornecedor.ParametrosTransferenciaRow, _
                                              ByVal T0109059rowOrigem As DatasetEmpenho.T0109059Row, _
                                              ByVal T0109059rowDestino As DatasetEmpenho.T0109059Row) As Boolean
            Try
                '----------------------------ORIGEM---------------------------
                If linha.CodFrnOrigem <= 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|O Fornecedor [Origem] é Obrigatório!|", "")
                    Me.SetComplete()
                    Return False
                End If
                If linha.TipDsnDscBnfOrigem = 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|O Empenho [Origem] é Obrigatório!|", "")
                    Me.SetComplete()
                    Return False
                End If

                If linha.TipAlcVbaFrnPmtOrigem = 2 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|Empenho de origem Marketing não permite transferência|", "")
                    Me.SetComplete()
                    Return False
                End If

                '----------------------------DESTINO---------------------------
                If linha.CodFrnOrigem <= 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|O Fornecedor [Destino] é Obrigatório!|", "")
                    Me.SetComplete()
                    Return False
                End If
                If linha.TipDsnDscBnfDestino = 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|O Empenho [Destino] é Obrigatório!|", "")
                    Me.SetComplete()
                    Return False
                End If
                If linha.Valor <= 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|O Valor a ser transferido é Inválido!|", "")
                    Me.SetComplete()
                    Return False
                End If
                If linha.DesHstLmt.Trim.Length = 0 Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|É obrigatório digitar o histórico !|", "")
                    Me.SetComplete()
                    Return False
                End If

                If linha.CodFrnOrigem = linha.CodFrnDestino And _
                   linha.TipDsnDscBnfOrigem = linha.TipDsnDscBnfDestino Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|Não é permitido fornecedor e empenho iguais para origem e destino|", "")
                    Me.SetComplete()
                    Return False
                End If

                If TIPUSRSIS <> "X" Then
                    If linha.CodFrnOrigem <> linha.CodFrnDestino Then
                        Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|Não é permitido transferência entre fornecedores diferentes!|", "")
                    End If
                End If

                If linha.SaldoDisponivel < linha.Valor Then
                    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|Saldo insuficiente para empenho:" & linha.TipDsnDscBnfOrigem.ToString & " - Fornecedor:" & linha.CodFrnOrigem.ToString & "!|", "")
                End If

                ''Verifica o tipo de alocação do empenho de destino
                'Dim TIPALCVBAFRNDestino As Decimal = 0
                'If Not T0109059rowDestino.IsTIPALCVBAFRNNull Then
                '    TIPALCVBAFRNDestino = T0109059rowDestino.TIPALCVBAFRN
                'End If

                ''Verificar o saldo disponível em alocação de verbas do fornecedor
                'Dim SaldoDisponivelAlocacao As Decimal = 0
                'Dim TemAlocacaoDestino As Boolean = False
                'If TIPALCVBAFRNDestino > 0 Then
                '    Dim dsSelecaoValorDisponivelFornecedor As DatasetSelecaoValorDisponivelFornecedor
                '    dsSelecaoValorDisponivelFornecedor = ObterSaldoDisponivelFornecedorParaTodosEmpenhos(linha.DatRefLmt, linha.CodFrnOrigem)
                '    For Each dr As DatasetSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedorRow In dsSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedor.Rows
                '        If dr.TipAlcVbaFrn = TIPALCVBAFRNDestino Then
                '            SaldoDisponivelAlocacao += dr.VlrSldDspAlcVbaFrn
                '        End If
                '    Next
                'End If

                'If linha.VlrLmtCtb > SaldoDisponivelAlocacao Then
                '    Throw New Martins.ExceptionManagement.MartinsApplicationException("|Regra|Saldo insuficiente para empenho:" & linha.TipDsnDscBnfOrigem.ToString & " - Fornecedor:" & linha.CodFrnOrigem.ToString & "!|", "")
                'End If

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

#End Region

#Region "Stored Procedure"

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Chamada para procedure: MRT.PCTDJRetSldDisFrnCel.PRCDJRetSldDisFrnCel
        ''' </summary>
        ''' <param name="pvCodDivCmp"></param>
        ''' <param name="pvTipDsnDscBnf"></param>
        ''' <param name="pvAnoMesRef"></param>
        ''' <param name="pvTipo"></param>
        ''' <remarks>
        ''' Chamada para procedure: MRT.PCTDJRetSldDisFrnCel.PRCDJRetSldDisFrnCel
        ''' LEGADO:spccx025
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    27/12/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterRelatorioSaldoDisponivelFornecedorCelula(ByVal pvCodDivCmp As Decimal, _
                                                                      ByVal pvCodCpr As Decimal, _
                                                                      ByVal pvTipDsnDscBnf As Decimal, _
                                                                      ByVal pvAnoMesRef As Decimal, _
                                                                      ByVal pvTipo As Integer) As DataSetRelatorioSaldoDisponivelFornecedorCelula
            Try
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorBLL
                Dim ds As DataSetRelatorioSaldoDisponivelFornecedorCelula

                ds = ContaCorrenteFornecedor.ObterRelatorioSaldoDisponivelFornecedorCelula(pvCodDivCmp, _
                                                                                           pvCodCpr, _
                                                                                           pvTipDsnDscBnf, _
                                                                                           pvAnoMesRef, _
                                                                                           pvTipo)
                Me.SetComplete()
                Return ds

            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Chamada para procedure: MRT.PCTDJAtlCntCrrFrn.PRCDJAtlCntCrrFrn
        ''' </summary>
        ''' <param name="pvDatRefLmt"></param>
        ''' <param name="pvTipDsnDscBnf"></param>
        ''' <param name="pvCodFrn"></param>
        ''' <param name="pvCodGdc"></param>
        ''' <param name="pvCodTipLmtPmt"></param>
        ''' <param name="pvCodCntCrd"></param>
        ''' <param name="pvCodCenCstCrd"></param>
        ''' <param name="pvCodCntDeb"></param>
        ''' <param name="pvCodCenCstDeb"></param>
        ''' <param name="pvVlrLmtCtb"></param>
        ''' <param name="pvDesHstLmt"></param>
        ''' <param name="pvDesVarHstPad"></param>
        ''' <param name="pvNomAcsUsrGrcLmt"></param>
        ''' <param name="pvCodFilEmp"></param>
        ''' <param name="pvCodPms"></param>
        ''' <param name="pvFlgRetVlr"></param>
        ''' <param name="pvTipAlcVbaFrnPmt"></param>
        ''' <param name="pvTransfIntegral"></param>
        ''' <remarks>
        ''' Chamada para procedure: MRT.PCTDJAtlCntCrrFrn.PRCDJAtlCntCrrFrn
        ''' LEGADO: CCX001GA
        ''' </remarks>
        ''' <history>
        '''     [Elifázio Bernardes]    21/11/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub AtualizarContaCorrenteFornecedor(ByVal pvDatRefLmt As Date, _
                                                    ByVal pvTipDsnDscBnf As Decimal, _
                                                    ByVal pvCodFrn As Decimal, _
                                                    ByVal pvCodGdc As String, _
                                                    ByVal pvCodTipLmtPmt As Integer, _
                                                    ByVal pvCodCntCrd As String, _
                                                    ByVal pvCodCenCstCrd As String, _
                                                    ByVal pvCodCntDeb As String, _
                                                    ByVal pvCodCenCstDeb As String, _
                                                    ByVal pvVlrLmtCtb As Decimal, _
                                                    ByVal pvDesHstLmt As String, _
                                                    ByVal pvDesVarHstPad As String, _
                                                    ByVal pvNomAcsUsrGrcLmt As String, _
                                                    ByVal pvCodFilEmp As Decimal, _
                                                    ByVal pvCodPms As Decimal, _
                                                    ByVal pvFlgRetVlr As String, _
                                                    ByVal pvTipAlcVbaFrnPmt As Integer, _
                                                    ByVal pvTransfIntegral As Integer)
            Try
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorBLL

                ContaCorrenteFornecedor.AtualizarContaCorrenteFornecedor( _
                                    pvDatRefLmt, _
                                    pvTipDsnDscBnf, _
                                    pvCodFrn, _
                                    pvCodGdc, _
                                    pvCodTipLmtPmt, _
                                    pvCodCntCrd, _
                                    pvCodCenCstCrd, _
                                    pvCodCntDeb, _
                                    pvCodCenCstDeb, _
                                    pvVlrLmtCtb, _
                                    pvDesHstLmt, _
                                    pvDesVarHstPad, _
                                    pvNomAcsUsrGrcLmt, _
                                    pvCodFilEmp, _
                                    pvCodPms, _
                                    pvFlgRetVlr, _
                                    pvTipAlcVbaFrnPmt, _
                                    pvTransfIntegral)


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
        ''' Realiza transferencia entre dos fornecedores e/ou empenho
        ''' </summary>
        ''' <param name="pValor"></param>
        ''' <param name="pTipAlcVbaFrn"></param>
        ''' <param name="pvDatRefLmt"></param>
        ''' <param name="pvTipDsnDscBnfOrigem"></param>
        ''' <param name="pvTipDsnDscBnfDestino"></param>
        ''' <param name="pvCodFrnOrigem"></param>
        ''' <param name="pvCodFrnDestino"></param>
        ''' <param name="pvVlrLmtCtb"></param>
        ''' <param name="pvDesHstLmt"></param>
        ''' <param name="pvDesVarHstPadOrigem"></param>
        ''' <param name="pvDesVarHstPadDestino"></param>
        ''' <param name="pvNomAcsUsrGrcLmt"></param>
        ''' <param name="pvTipAlcVbaFrnPmtOrigem"></param>
        ''' <param name="pvTipAlcVbaFrnPmtDestino"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	29/12/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub TransferirValoresEntreEmpenhosFornecedor(ByVal pValor As Decimal, _
                                             ByVal pTipAlcVbaFrn As Integer, _
                                             ByVal pvDatRefLmt As Date, _
                                             ByVal pvTipDsnDscBnfOrigem As Decimal, _
                                             ByVal pvTipDsnDscBnfDestino As Decimal, _
                                             ByVal pvCodFrnOrigem As Decimal, _
                                             ByVal pvCodFrnDestino As Decimal, _
                                             ByVal pvVlrLmtCtb As Decimal, _
                                             ByVal pvDesHstLmt As String, _
                                             ByVal pvDesVarHstPadOrigem As String, _
                                             ByVal pvDesVarHstPadDestino As String, _
                                             ByVal pvNomAcsUsrGrcLmt As String, _
                                             ByVal pvTipAlcVbaFrnPmtOrigem As Integer, _
                                             ByVal pvTipAlcVbaFrnPmtDestino As Integer)


            Try
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorBLL

                ContaCorrenteFornecedor.TransferirValoresEntreEmpenhosFornecedor(pValor, _
                                                                  pTipAlcVbaFrn, _
                                                                  pvDatRefLmt, _
                                                                  pvTipDsnDscBnfOrigem, _
                                                                  pvTipDsnDscBnfDestino, _
                                                                  pvCodFrnOrigem, _
                                                                  pvCodFrnDestino, _
                                                                  pvVlrLmtCtb, _
                                                                  pvDesHstLmt, _
                                                                  pvDesVarHstPadOrigem, _
                                                                  pvDesVarHstPadDestino, _
                                                                  pvNomAcsUsrGrcLmt, _
                                                                  pvTipAlcVbaFrnPmtOrigem, _
                                                                  pvTipAlcVbaFrnPmtDestino)

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
        ''' Chamada para procedure: MRT.PCTDJObtDrtCmpFrn.PRCDJObtDrtCmpFrn
        ''' </summary>
        ''' <param name="pvCodFrn"></param>
        ''' <remarks>
        ''' Chamada para procedure: MRT.PCTDJObtDrtCmpFrn.PRCDJObtDrtCmpFrn
        ''' LEGADO:spCCX043
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    30/12/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterDiretoriaEDivisaoDeCompraDeFornecedor(ByVal pvCodFrn As Decimal) As DatasetDiretoriaEDivisaoDeCompraDeFornecedor
            Try
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorBLL
                Dim ds As DatasetDiretoriaEDivisaoDeCompraDeFornecedor
                ds = ContaCorrenteFornecedor.ObterDiretoriaEDivisaoDeCompraDeFornecedor(pvCodFrn)
                Me.SetComplete()
                Return ds

            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' CONSULTA Valores Disponiveis de um Fornecedor
        ''' </summary>
        ''' <param name="vDatRef"></param>
        ''' <param name="vCodFrn"></param>
        ''' <param name="vTipDsnDscBnf"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[ELIFÁZIO]	21/9/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterSelecaoValorDisponivelFornecedor(ByVal vDatRef As Date, _
                                                              ByVal vCodFrn As Decimal, _
                                                              ByVal vTipDsnDscBnf As Decimal) As DatasetSelecaoValorDisponivelFornecedor
            Try

                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorBLL = New ContaCorrenteFornecedorBLL

                Dim ds As DatasetSelecaoValorDisponivelFornecedor
                ds = ContaCorrenteFornecedor.ObterSelecaoValorDisponivelFornecedor(vDatRef, vCodFrn, vTipDsnDscBnf)
                ds = ContaCorrenteFornecedor.ObterSelecaoValorDisponivelFornecedor(vDatRef, vCodFrn, vTipDsnDscBnf)

                Me.SetComplete()
                Return ds
            Catch ex As Martins.ExceptionManagement.BaseApplicationException
                Me.SetAbort()
                Throw ex
            Catch ex As Exception
                Me.SetAbort()
                Throw New Martins.ExceptionManagement.MartinsSystemException(ex.Message, ErrorConstants.SYSTEM_ERROR, ex)
            End Try
        End Function

#End Region

    End Class
End Namespace