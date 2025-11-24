Imports Martins.Data.TransactionManagement
Imports Martins.Security.Helper
Imports Martins.Compras.AcoesComerciais.ContaCorrenteFornecedor.DAL
Imports Martins.Compras.AcoesComerciais.Gestao
Imports Martins.Compras.AcoesComerciais.Gestao.DAL

Namespace BLL
    ''' -----------------------------------------------------------------------------
    ''' Project   : Martins.Compras.AcoesComerciais.ContaCorrenteFornecedor
    ''' Class     : ContaCorrenteFornecedorBLL
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Regras de negócio da classe ContaCorrenteFornecedor
    ''' </summary>
    ''' <remarks>
    '''
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    21/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class ContaCorrenteFornecedorBLL
        Inherits BLLClass

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
        '''     [Marcos Queiroz]    21/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterContaCorrenteFornecedor(ByVal CODFRN As Decimal, _
                                                     ByVal CODGDC As String, _
                                                     ByVal DATREFLMT As Date, _
                                                     ByVal NUMSEQLMT As Decimal, _
                                                     ByVal TIPDSNDSCBNF As Decimal) As DatasetContaCorrenteFornecedor
            Try
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorDAL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorDAL
                Dim DatasetContaCorrenteFornecedor As DatasetContaCorrenteFornecedor
                DatasetContaCorrenteFornecedor = ContaCorrenteFornecedor.ObterContaCorrenteFornecedor(CODFRN, CODGDC, DATREFLMT, NUMSEQLMT, TIPDSNDSCBNF) 

                Me.SetComplete()
                Return DatasetContaCorrenteFornecedor

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade T0123086 com base na sua chave primária.
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
        '''     [Marcos Queiroz]    21/07/2006  Created
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
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorDAL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorDAL

                Dim DatasetContaCorrenteFornecedor As DatasetContaCorrenteFornecedor
                DatasetContaCorrenteFornecedor = ContaCorrenteFornecedor.ObterContasCorrenteFornecedor(CODCENCSTCRD, CODCENCSTDEB, CODCNTCRD, CODCNTDEB, CODFILEMP, CODFRN, CODGDC, CODPMS, CODTIPLMT, DATREFLMT, DATREFLMTInicial, DATREFLMTFinal, DESHSTLMT, DESVARHSTPAD, NUMSEQLMT, TIPDSNDSCBNF)

                'Obtem os fornecedores dos lançamentos
                ContaCorrenteFornecedor.ObterFornecedoresDeContasCorrenteFornecedor(DatasetContaCorrenteFornecedor, CODCENCSTCRD, CODCENCSTDEB, CODCNTCRD, CODCNTDEB, CODFILEMP, CODFRN, CODGDC, CODPMS, CODTIPLMT, DATREFLMT, DATREFLMTInicial, DATREFLMTFinal, DESHSTLMT, DESVARHSTPAD, NUMSEQLMT, TIPDSNDSCBNF)

                Me.SetComplete()
                Return DatasetContaCorrenteFornecedor

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
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
        '''     [Marcos Queiroz]    21/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Sub AtualizarContaCorrenteFornecedor(ByVal DatasetContaCorrenteFornecedor As DatasetContaCorrenteFornecedor)
            Try
                Dim chave As Double
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorDAL
                chave = -1

                'O loop abaixo trata os dados antes de enviá-los ao banco
                For Each linha As DatasetContaCorrenteFornecedor.T0123086Row In DatasetContaCorrenteFornecedor.T0123086
                    If (linha.RowState = System.Data.DataRowState.Added) Then
                        ValidarContaCorrenteFornecedor(DatasetContaCorrenteFornecedor)
                    ElseIf (linha.RowState = System.Data.DataRowState.Deleted) Then
                    ElseIf (linha.RowState = System.Data.DataRowState.Modified) Then
                        ValidarContaCorrenteFornecedor(DatasetContaCorrenteFornecedor)
                    End If

                    'Envia os dados à DAL para salvar em banco
                    ContaCorrenteFornecedor.AtualizarContaCorrenteFornecedor(linha)
                Next

                Me.SetComplete()

            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Sub


        Private Sub ValidarContaCorrenteFornecedor(ByRef DatasetContaCorrenteFornecedor As DatasetContaCorrenteFornecedor)
            Try

                '***ContaCorrenteFornecedor***
                'Trata campos do tipo numerico, não permitido nulo, e com valor nulo
                For Each linha As DatasetContaCorrenteFornecedor.T0123086Row In DatasetContaCorrenteFornecedor.T0123086
                    If linha.RowState <> DataRowState.Deleted Then
                        If linha.IsNull("CODFRN") Then linha.CODFRN = 0
                        If linha.IsNull("CODTIPLMT") Then linha.CODTIPLMT = 0
                        If linha.IsNull("NUMSEQLMT") Then linha.NUMSEQLMT = 0
                        If linha.IsNull("TIPDSNDSCBNF") Then linha.TIPDSNDSCBNF = 0
                        If linha.IsNull("VLRLMTCTB") Then linha.VLRLMTCTB = 0
                    End If
                Next

                'Trata campos do tipo string, não permitido nulo, e com valor nulo
                For Each linha As DatasetContaCorrenteFornecedor.T0123086Row In DatasetContaCorrenteFornecedor.T0123086
                    If linha.RowState <> DataRowState.Deleted Then
                        If linha.IsNull("CODCENCSTCRD") Then linha.CODCENCSTCRD = " "
                        If linha.IsNull("CODCENCSTDEB") Then linha.CODCENCSTDEB = " "
                        If linha.IsNull("CODCNTCRD") Then linha.CODCNTCRD = " "
                        If linha.IsNull("CODCNTDEB") Then linha.CODCNTDEB = " "
                        If linha.IsNull("CODGDC") Then linha.CODGDC = " "
                        If linha.IsNull("DESHSTLMT") Then linha.DESHSTLMT = " "
                        If linha.IsNull("DESVARHSTPAD") Then linha.DESVARHSTPAD = " "
                        If linha.IsNull("NOMACSUSRGRCLMT") Then linha.NOMACSUSRGRCLMT = " "
                    End If
                Next

                'Transforma os campos do tipo string em caixa alta
                '                For Each linha As DatasetContaCorrenteFornecedor.T0123086Row In DatasetContaCorrenteFornecedor.T0123086
                '                    If linha.RowState <> DataRowState.Deleted Then
                '                        If Not linha.IsNull("CODCENCSTCRD") Then linha.CODCENCSTCRD = linha.CODCENCSTCRD.Trim().ToUpper()
                '                        If Not linha.IsNull("CODCENCSTDEB") Then linha.CODCENCSTDEB = linha.CODCENCSTDEB.Trim().ToUpper()
                '                        If Not linha.IsNull("CODCNTCRD") Then linha.CODCNTCRD = linha.CODCNTCRD.Trim().ToUpper()
                '                        If Not linha.IsNull("CODCNTDEB") Then linha.CODCNTDEB = linha.CODCNTDEB.Trim().ToUpper()
                '                        If Not linha.IsNull("CODGDC") Then linha.CODGDC = linha.CODGDC.Trim().ToUpper()
                '                        If Not linha.IsNull("DESHSTLMT") Then linha.DESHSTLMT = linha.DESHSTLMT.Trim().ToUpper()
                '                        If Not linha.IsNull("DESVARHSTPAD") Then linha.DESVARHSTPAD = linha.DESVARHSTPAD.Trim().ToUpper()
                '                        If Not linha.IsNull("NOMACSUSRGRCLMT") Then linha.NOMACSUSRGRCLMT = linha.NOMACSUSRGRCLMT.Trim().ToUpper()
                '                    End If
                '                Next

                'Trata campos do tipo string e que não permite nulo
                'substituindo por espaço
                For Each linha As DatasetContaCorrenteFornecedor.T0123086Row In DatasetContaCorrenteFornecedor.T0123086
                    If linha.RowState <> DataRowState.Deleted Then
                        If linha.CODCENCSTCRD = "" Then linha.CODCENCSTCRD = " "
                        If linha.CODCENCSTDEB = "" Then linha.CODCENCSTDEB = " "
                        If linha.CODCNTCRD = "" Then linha.CODCNTCRD = " "
                        If linha.CODCNTDEB = "" Then linha.CODCNTDEB = " "
                        If linha.CODGDC = "" Then linha.CODGDC = " "
                        If linha.DESHSTLMT = "" Then linha.DESHSTLMT = " "
                        If linha.DESVARHSTPAD = "" Then linha.DESVARHSTPAD = " "
                        If linha.NOMACSUSRGRCLMT = "" Then linha.NOMACSUSRGRCLMT = " "
                    End If
                Next

                'Trata campos do tipo string com tamanho maior que o
                'tamanho do banco
                For Each linha As DatasetContaCorrenteFornecedor.T0123086Row In DatasetContaCorrenteFornecedor.T0123086
                    If linha.RowState <> DataRowState.Deleted Then
                        If linha.CODCENCSTCRD.Length > 10 Then linha.CODCENCSTCRD = linha.CODCENCSTCRD.Substring(1, 10)
                        If linha.CODCENCSTDEB.Length > 10 Then linha.CODCENCSTDEB = linha.CODCENCSTDEB.Substring(1, 10)
                        If linha.CODCNTCRD.Length > 10 Then linha.CODCNTCRD = linha.CODCNTCRD.Substring(1, 10)
                        If linha.CODCNTDEB.Length > 10 Then linha.CODCNTDEB = linha.CODCNTDEB.Substring(1, 10)
                        If linha.CODGDC.Length > 1 Then linha.CODGDC = linha.CODGDC.Substring(1, 1)
                        If linha.DESHSTLMT.Length > 50 Then linha.DESHSTLMT = linha.DESHSTLMT.Substring(1, 50)
                        If linha.DESVARHSTPAD.Length > 50 Then linha.DESVARHSTPAD = linha.DESVARHSTPAD.Substring(1, 50)
                        If linha.NOMACSUSRGRCLMT.Length > 25 Then linha.NOMACSUSRGRCLMT = linha.NOMACSUSRGRCLMT.Substring(1, 25)
                    End If
                Next
                Me.SetComplete()
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
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
        '''     [Marcos Queiroz]    21/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterParametroContabilContaCorrenteFornecedor(ByVal CODFILEMP As Decimal, _
                                                                      ByVal CODTIPLMT As Decimal) As DatasetParametroContabilContaCorrenteFornecedor
            Try
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorDAL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorDAL
                Dim DatasetParametroContabilContaCorrenteFornecedor As DatasetParametroContabilContaCorrenteFornecedor
                DatasetParametroContabilContaCorrenteFornecedor = ContaCorrenteFornecedor.ObterParametroContabilContaCorrenteFornecedor(CODFILEMP, CODTIPLMT)

                Me.SetComplete()
                Return DatasetParametroContabilContaCorrenteFornecedor

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade T0123094 com base na sua chave primária.
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
        '''     [Marcos Queiroz]    21/07/2006  Created
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
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorDAL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorDAL
                Dim DatasetParametroContabilContaCorrenteFornecedor As DatasetParametroContabilContaCorrenteFornecedor
                DatasetParametroContabilContaCorrenteFornecedor = ContaCorrenteFornecedor.ObterParametrosContabilContaCorrenteFornecedor(CODCENCSTCRD, CODCENCSTDEB, CODCNTCRD, CODCNTDEB, CODEVTCTB, CODEVTCTBFRTDVL, CODEVTCTBNGCDVL, CODFILEMP, CODFTOCTB, CODFTOCTBFRTDVL, CODFTOCTBNGCDVL, CODHSTPAD, CODTIPLMT)
                Me.SetComplete()
                Return DatasetParametroContabilContaCorrenteFornecedor

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
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
        '''     [Marcos Queiroz]    21/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Sub AtualizarParametroContabilContaCorrenteFornecedor(ByVal DatasetParametroContabilContaCorrenteFornecedor As DatasetParametroContabilContaCorrenteFornecedor)
            Try
                Dim chave As Double
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorDAL
                chave = -1

                'O loop abaixo trata os dados antes de enviá-los ao banco
                For Each linha As DatasetParametroContabilContaCorrenteFornecedor.T0123094Row In DatasetParametroContabilContaCorrenteFornecedor.T0123094
                    If (linha.RowState = System.Data.DataRowState.Added) Then
                        'Inserindo, buscar nova chave sequencial
                        'If (chave = -1) Then
                        '    chave = ParametroContabilContaCorrenteFornecedor.ObterNovaChaveParametroContabilContaCorrenteFornecedor
                        '    If chave = 0 Then chave = 1
                        'Else
                        '    chave = chave + 1
                        'End If
                        'linha. = Convert.To(chave)
                        ValidarParametroContabilContaCorrenteFornecedor(DatasetParametroContabilContaCorrenteFornecedor)
                    ElseIf (linha.RowState = System.Data.DataRowState.Deleted) Then
                    ElseIf (linha.RowState = System.Data.DataRowState.Modified) Then
                        ValidarParametroContabilContaCorrenteFornecedor(DatasetParametroContabilContaCorrenteFornecedor)
                    End If
                Next

                'Envia os dados à DAL para salvar em banco
                ContaCorrenteFornecedor.AtualizarParametroContabilContaCorrenteFornecedor(DatasetParametroContabilContaCorrenteFornecedor)
                Me.SetComplete()

            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Sub

        Private Sub ValidarParametroContabilContaCorrenteFornecedor(ByRef DatasetParametroContabilContaCorrenteFornecedor As DatasetParametroContabilContaCorrenteFornecedor)
            Try

                '***ParametroContabilContaCorrenteFornecedor***
                'Trata campos do tipo numerico, não permitido nulo, e com valor nulo
                For Each linha As DatasetParametroContabilContaCorrenteFornecedor.T0123094Row In DatasetParametroContabilContaCorrenteFornecedor.T0123094
                    If linha.RowState <> DataRowState.Deleted Then
                        If linha.IsNull("CODFILEMP") Then linha.CODFILEMP = 0
                        If linha.IsNull("CODTIPLMT") Then linha.CODTIPLMT = 0
                    End If
                Next

                'Trata campos do tipo string, não permitido nulo, e com valor nulo
                For Each linha As DatasetParametroContabilContaCorrenteFornecedor.T0123094Row In DatasetParametroContabilContaCorrenteFornecedor.T0123094
                    If linha.RowState <> DataRowState.Deleted Then
                        If linha.IsNull("CODCENCSTCRD") Then linha.CODCENCSTCRD = " "
                        If linha.IsNull("CODCENCSTDEB") Then linha.CODCENCSTDEB = " "
                        If linha.IsNull("CODCNTCRD") Then linha.CODCNTCRD = " "
                        If linha.IsNull("CODCNTDEB") Then linha.CODCNTDEB = " "
                        If linha.IsNull("CODHSTPAD") Then linha.CODHSTPAD = " "
                    End If
                Next

                'Transforma os campos do tipo string em caixa alta
                '                For Each linha As DatasetParametroContabilContaCorrenteFornecedor.T0123094Row In DatasetParametroContabilContaCorrenteFornecedor.T0123094
                '                    If linha.RowState <> DataRowState.Deleted Then
                '                        If Not linha.IsNull("CODCENCSTCRD") Then linha.CODCENCSTCRD = linha.CODCENCSTCRD.Trim().ToUpper()
                '                        If Not linha.IsNull("CODCENCSTDEB") Then linha.CODCENCSTDEB = linha.CODCENCSTDEB.Trim().ToUpper()
                '                        If Not linha.IsNull("CODCNTCRD") Then linha.CODCNTCRD = linha.CODCNTCRD.Trim().ToUpper()
                '                        If Not linha.IsNull("CODCNTDEB") Then linha.CODCNTDEB = linha.CODCNTDEB.Trim().ToUpper()
                '                        If Not linha.IsNull("CODHSTPAD") Then linha.CODHSTPAD = linha.CODHSTPAD.Trim().ToUpper()
                '                    End If
                '                Next

                'Trata campos do tipo string e que não permite nulo
                'substituindo por espaço
                For Each linha As DatasetParametroContabilContaCorrenteFornecedor.T0123094Row In DatasetParametroContabilContaCorrenteFornecedor.T0123094
                    If linha.RowState <> DataRowState.Deleted Then
                        If linha.CODCENCSTCRD = "" Then linha.CODCENCSTCRD = " "
                        If linha.CODCENCSTDEB = "" Then linha.CODCENCSTDEB = " "
                        If linha.CODCNTCRD = "" Then linha.CODCNTCRD = " "
                        If linha.CODCNTDEB = "" Then linha.CODCNTDEB = " "
                        If linha.CODHSTPAD = "" Then linha.CODHSTPAD = " "
                    End If
                Next

                'Trata campos do tipo string com tamanho maior que o
                'tamanho do banco
                For Each linha As DatasetParametroContabilContaCorrenteFornecedor.T0123094Row In DatasetParametroContabilContaCorrenteFornecedor.T0123094
                    If linha.RowState <> DataRowState.Deleted Then
                        If linha.CODCENCSTCRD.Length > 10 Then linha.CODCENCSTCRD = linha.CODCENCSTCRD.Substring(1, 10)
                        If linha.CODCENCSTDEB.Length > 10 Then linha.CODCENCSTDEB = linha.CODCENCSTDEB.Substring(1, 10)
                        If linha.CODCNTCRD.Length > 10 Then linha.CODCNTCRD = linha.CODCNTCRD.Substring(1, 10)
                        If linha.CODCNTDEB.Length > 10 Then linha.CODCNTDEB = linha.CODCNTDEB.Substring(1, 10)
                        If linha.CODHSTPAD.Length > 4 Then linha.CODHSTPAD = linha.CODHSTPAD.Substring(1, 4)
                    End If
                Next

                Me.SetComplete()
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
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
        '''     [Marcos Queiroz]    21/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterTipoLancamentoContaCorrenteFornecedor(ByVal CODTIPLMT As Decimal) As DatasetTipoLancamentoContaCorrenteFornecedor
            Try
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorDAL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorDAL
                Dim DatasetTipoLancamentoContaCorrenteFornecedor As DatasetTipoLancamentoContaCorrenteFornecedor
                DatasetTipoLancamentoContaCorrenteFornecedor = ContaCorrenteFornecedor.ObterTipoLancamentoContaCorrenteFornecedor(CODTIPLMT)

                Me.SetComplete()
                Return DatasetTipoLancamentoContaCorrenteFornecedor

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade T0123108 com base na sua chave primária.
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
        '''     [Marcos Queiroz]    21/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Function ObterTiposLancamentoContaCorrenteFornecedor(ByVal DESTIPLMT As String, _
                                                                    ByVal DESTIPLMTFRN As String) As DatasetTipoLancamentoContaCorrenteFornecedor
            Try
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorDAL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorDAL
                Dim DatasetTipoLancamentoContaCorrenteFornecedor As DatasetTipoLancamentoContaCorrenteFornecedor
                DatasetTipoLancamentoContaCorrenteFornecedor = ContaCorrenteFornecedor.ObterTiposLancamentoContaCorrenteFornecedor(DESTIPLMT, DESTIPLMTFRN)
                Me.SetComplete()
                Return DatasetTipoLancamentoContaCorrenteFornecedor

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
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
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorDAL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorDAL
                Dim DatasetTipoLancamentoContaCorrenteFornecedor As DatasetTipoLancamentoContaCorrenteFornecedor
                DatasetTipoLancamentoContaCorrenteFornecedor = ContaCorrenteFornecedor.ObterTipoLancamentoPrincipalXTipoLancamentoAssociado(CODTIPLMTASC, CODTIPLMTPCP)
                Me.SetComplete()
                Return DatasetTipoLancamentoContaCorrenteFornecedor

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
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
        '''     [Marcos Queiroz]    21/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Public Sub AtualizarTipoLancamentoContaCorrenteFornecedor(ByVal DatasetTipoLancamentoContaCorrenteFornecedor As DatasetTipoLancamentoContaCorrenteFornecedor)
            Try
                Dim chave As Double
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorDAL
                chave = -1

                'O loop abaixo trata os dados antes de enviá-los ao banco
                For Each linha As DatasetTipoLancamentoContaCorrenteFornecedor.T0123108Row In DatasetTipoLancamentoContaCorrenteFornecedor.T0123108
                    If (linha.RowState = System.Data.DataRowState.Added) Then
                        'Inserindo, buscar nova chave sequencial
                        If (chave = -1) Then
                            chave = ContaCorrenteFornecedor.ObterNovaChaveTipoLancamentoContaCorrenteFornecedor
                            If chave = 0 Then chave = 1
                        Else
                            chave = chave + 1
                        End If
                        linha.CODTIPLMT = Convert.ToDecimal(chave)
                        ValidarTipoLancamentoContaCorrenteFornecedor(DatasetTipoLancamentoContaCorrenteFornecedor)
                    ElseIf (linha.RowState = System.Data.DataRowState.Deleted) Then
                    ElseIf (linha.RowState = System.Data.DataRowState.Modified) Then
                        ValidarTipoLancamentoContaCorrenteFornecedor(DatasetTipoLancamentoContaCorrenteFornecedor)
                    End If
                Next

                'Envia os dados à DAL para salvar em banco
                ContaCorrenteFornecedor.AtualizarTipoLancamentoContaCorrenteFornecedor(DatasetTipoLancamentoContaCorrenteFornecedor)
                Me.SetComplete()

            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Sub

        Private Sub ValidarTipoLancamentoContaCorrenteFornecedor(ByRef DatasetTipoLancamentoContaCorrenteFornecedor As DatasetTipoLancamentoContaCorrenteFornecedor)
            Try

                '***TipoLancamentoContaCorrenteFornecedor***
                'Trata campos do tipo numerico, não permitido nulo, e com valor nulo
                For Each linha As DatasetTipoLancamentoContaCorrenteFornecedor.T0123108Row In DatasetTipoLancamentoContaCorrenteFornecedor.T0123108
                    If linha.RowState <> DataRowState.Deleted Then
                        If linha.IsNull("CODTIPLMT") Then linha.CODTIPLMT = 0
                    End If
                Next

                'Trata campos do tipo string, não permitido nulo, e com valor nulo
                For Each linha As DatasetTipoLancamentoContaCorrenteFornecedor.T0123108Row In DatasetTipoLancamentoContaCorrenteFornecedor.T0123108
                    If linha.RowState <> DataRowState.Deleted Then
                        If linha.IsNull("DESTIPLMT") Then linha.DESTIPLMT = " "
                        If linha.IsNull("DESTIPLMTFRN") Then linha.DESTIPLMTFRN = " "
                        If linha.IsNull("FLGGRCLMTCTB") Then linha.FLGGRCLMTCTB = " "
                        If linha.IsNull("FLGLMTMAN") Then linha.FLGLMTMAN = " "
                    End If
                Next

                'Transforma os campos do tipo string em caixa alta
                '                For Each linha As DatasetTipoLancamentoContaCorrenteFornecedor.T0123108Row In DatasetTipoLancamentoContaCorrenteFornecedor.T0123108
                '                    If linha.RowState <> DataRowState.Deleted Then
                '                        If Not linha.IsNull("DESTIPLMT") Then linha.DESTIPLMT = linha.DESTIPLMT.Trim().ToUpper()
                '                        If Not linha.IsNull("DESTIPLMTFRN") Then linha.DESTIPLMTFRN = linha.DESTIPLMTFRN.Trim().ToUpper()
                '                        If Not linha.IsNull("FLGGRCLMTCTB") Then linha.FLGGRCLMTCTB = linha.FLGGRCLMTCTB.Trim().ToUpper()
                '                        If Not linha.IsNull("FLGLMTMAN") Then linha.FLGLMTMAN = linha.FLGLMTMAN.Trim().ToUpper()
                '                    End If
                '                Next

                'Trata campos do tipo string e que não permite nulo
                'substituindo por espaço
                For Each linha As DatasetTipoLancamentoContaCorrenteFornecedor.T0123108Row In DatasetTipoLancamentoContaCorrenteFornecedor.T0123108
                    If linha.RowState <> DataRowState.Deleted Then
                        If linha.DESTIPLMT = "" Then linha.DESTIPLMT = " "
                        If linha.DESTIPLMTFRN = "" Then linha.DESTIPLMTFRN = " "
                        If linha.FLGGRCLMTCTB = "" Then linha.FLGGRCLMTCTB = " "
                        If linha.FLGLMTMAN = "" Then linha.FLGLMTMAN = " "
                    End If
                Next

                'Trata campos do tipo string com tamanho maior que o
                'tamanho do banco
                For Each linha As DatasetTipoLancamentoContaCorrenteFornecedor.T0123108Row In DatasetTipoLancamentoContaCorrenteFornecedor.T0123108
                    If linha.RowState <> DataRowState.Deleted Then
                        If linha.DESTIPLMT.Length > 30 Then linha.DESTIPLMT = linha.DESTIPLMT.Substring(1, 30)
                        If linha.DESTIPLMTFRN.Length > 30 Then linha.DESTIPLMTFRN = linha.DESTIPLMTFRN.Substring(1, 30)
                        If linha.FLGGRCLMTCTB.Length > 1 Then linha.FLGGRCLMTCTB = linha.FLGGRCLMTCTB.Substring(1, 1)
                        If linha.FLGLMTMAN.Length > 1 Then linha.FLGLMTMAN = linha.FLGLMTMAN.Substring(1, 1)
                    End If
                Next

                Me.SetComplete()
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try

        End Sub

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
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorDAL
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
        ''' <param name="IN_CODFRN"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	21/11/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterFornecedorCompradorEDivisaoCompra(ByVal IN_CODFRN As String) As DatasetSelecaoValorDisponivelFornecedor
            Try
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorDAL
                Dim DatasetSelecaoValorDisponivelFornecedor As DatasetSelecaoValorDisponivelFornecedor

                DatasetSelecaoValorDisponivelFornecedor = ContaCorrenteFornecedor.ObterFornecedorCompradorEDivisaoCompra(IN_CODFRN)

                Me.SetComplete()
                Return DatasetSelecaoValorDisponivelFornecedor

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="CODCPR"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	22/11/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterFornecedorPorComprador(ByVal CODCPR As Decimal) As DatasetFornecedor
            Try
                Dim PedidoCompra As AcordoComercialDAL
                PedidoCompra = New AcordoComercialDAL

                Dim DatasetFornecedor As DatasetFornecedor
                DatasetFornecedor = PedidoCompra.ObterFornecedorPorComprador(CODCPR)

                Me.SetComplete()
                Return DatasetFornecedor

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="CODDIVCMP"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	22/11/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterFornecedorPorCategoria(ByVal CODDIVCMP As Decimal) As DatasetFornecedor
            Try
                Dim PedidoCompra As AcordoComercialDAL
                PedidoCompra = New AcordoComercialDAL

                Dim DatasetFornecedor As DatasetFornecedor
                DatasetFornecedor = PedidoCompra.ObterFornecedorPorCategoria(CODDIVCMP)

                Me.SetComplete()
                Return DatasetFornecedor

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="CODCPR"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	22/11/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterCodigoFornecedorPorCompradorSeparadoPorVirgula(ByVal CODCPR As Decimal) As String
            Try
                Dim PedidoCompra As AcordoComercialDAL
                PedidoCompra = New AcordoComercialDAL

                Dim DatasetFornecedor As DatasetFornecedor
                DatasetFornecedor = PedidoCompra.ObterFornecedorPorComprador(CODCPR)

                Dim result As String
                For Each linha As DatasetFornecedor.TbFornecedorRow In DatasetFornecedor.TbFornecedor
                    If result <> String.Empty Then result &= ","
                    result &= linha.CODFRN.ToString
                Next

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
        ''' <param name="CODDIVCMP"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	22/11/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterCodigoFornecedorPorCategoriaSeparadoPorVirgula(ByVal CODDIVCMP As Decimal) As String
            Try
                Dim PedidoCompra As AcordoComercialDAL
                PedidoCompra = New AcordoComercialDAL

                Dim DatasetFornecedor As DatasetFornecedor
                DatasetFornecedor = PedidoCompra.ObterFornecedorPorCategoria(CODDIVCMP)

                Dim result As String
                For Each linha As DatasetFornecedor.TbFornecedorRow In DatasetFornecedor.TbFornecedor
                    If result <> String.Empty Then result &= ","
                    result &= linha.CODFRN.ToString
                Next

                Me.SetComplete()
                Return result

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
            End Try
        End Function

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
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorDAL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorDAL
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedor.ObterTransferenciaVerbaFornecedor(NUMFLUAPV)

                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade CADTRNVBAFRN com base na sua chave primária.
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
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorDAL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorDAL
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedor.ObterTransferenciasVerbaFornecedor(CODFNC, DESJSTTRNVBA, NUMFLUAPV, TIPALCVBAFRN, TIPDSNDSCBNFDSNTRN, TIPSTAFLUAPV)
                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
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
                Dim chave As Double
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorDAL
                chave = -1

                'O loop abaixo trata os dados antes de enviá-los ao banco
                For Each linha As DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow In DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRN
                    If (linha.RowState = System.Data.DataRowState.Added) Then
                        
                        ValidarTransferenciaVerbaFornecedor(DatasetTransferenciaVerbaFornecedor)
                    ElseIf (linha.RowState = System.Data.DataRowState.Deleted) Then
                        'TODO: Remover registros que dependam desse
                    ElseIf (linha.RowState = System.Data.DataRowState.Modified) Then
                        'TODO: Tratar alguma regra para o update dos dados
                        ValidarTransferenciaVerbaFornecedor(DatasetTransferenciaVerbaFornecedor)
                    End If
                Next

                'Envia os dados à DAL para salvar em banco
                ContaCorrenteFornecedor.AtualizarTransferenciaVerbaFornecedor(DatasetTransferenciaVerbaFornecedor)
                Me.SetComplete()

            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Sub

        Private Sub ValidarTransferenciaVerbaFornecedor(ByRef DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor)
            Try
                'Trata campos do tipo string, não permitido nulo, e com valor nulo
                For Each linha As DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow In DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRN
                    If linha.RowState <> DataRowState.Deleted Then
                        If linha.IsNull("DESJSTTRNVBA") Then linha.DESJSTTRNVBA = " "
                        If linha.IsNull("TIPSTAFLUAPV") Then linha.TIPSTAFLUAPV = " "
                    End If
                Next

                'Transforma os campos do tipo string em caixa alta
                For Each linha As DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow In DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRN
                    If linha.RowState <> DataRowState.Deleted Then
                        If Not linha.IsNull("DESJSTTRNVBA") Then linha.DESJSTTRNVBA = linha.DESJSTTRNVBA.Trim().ToUpper()
                        If Not linha.IsNull("TIPSTAFLUAPV") Then linha.TIPSTAFLUAPV = linha.TIPSTAFLUAPV.Trim().ToUpper()
                    End If
                Next

                'Trata campos do tipo string e que não permite nulo
                'substituindo por espaço
                For Each linha As DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow In DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRN
                    If linha.RowState <> DataRowState.Deleted Then
                        If linha.DESJSTTRNVBA = "" Then linha.DESJSTTRNVBA = " "
                        If linha.TIPSTAFLUAPV = "" Then linha.TIPSTAFLUAPV = " "
                    End If
                Next

                Me.SetComplete()
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
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
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorDAL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorDAL
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedor.ObterRelacaoTransferenciaVerbaFornecedor(CODFRN, NUMFLUAPV, TIPALCVBAFRN, TIPDSNDSCBNFORITRN)

                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
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
        Public Function ObterTransferenciaSVerbaFornecedorJoin(ByVal NUMFLUAPV As Decimal, _
                                                               ByVal CODFNC As Decimal, _
                                                               ByVal TIPSTAFLUAPV As String) As DatasetTransferenciaVerbaFornecedor
            Try
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorDAL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorDAL
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedor.ObterTransferenciaSVerbaFornecedorjoin(NUMFLUAPV, CODFNC, TIPSTAFLUAPV)

                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor

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
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorDAL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorDAL
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedor.ObterMinhasAprovavoesEmTransferenciaVerbasFornecedor(NUMFLUAPV, CODFNC)

                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor

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
        ''' 	[Marcos Queiroz]	5/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterRelacaoTransferenciaVerbaFornecedorJoinT0153541JoinT0100426JoinT0113625JoinT0118570JoinT0109059(ByVal NUMFLUAPV As Decimal) As DatasetTransferenciaVerbaFornecedor
            Try
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorDAL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorDAL
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedor.ObterRelacaoTransferenciaVerbaFornecedorJoinT0153541JoinT0100426JoinT0113625JoinT0118570JoinT0109059(NUMFLUAPV)

                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
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
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorDAL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorDAL
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedor.ObterRelacoesTransferenciaVerbaFornecedor(CODFRN, NUMFLUAPV, TIPALCVBAFRN, TIPDSNDSCBNFORITRN)
                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
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
                Dim chave As Double
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorDAL
                chave = -1

                'O loop abaixo trata os dados antes de enviá-los ao banco
                For Each linha As DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRNRow In DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRN
                    If (linha.RowState = System.Data.DataRowState.Added) Then
                        'Inserindo, buscar nova chave sequencial
                        'If (chave = -1) Then
                        '    chave = RelacaoTransferenciaVerbaFornecedor.ObterNovaChaveRelacaoTransferenciaVerbaFornecedor
                        '    If chave = 0 Then chave = 1
                        'Else
                        '    chave = chave + 1
                        'End If
                        'linha. = Convert.To(chave)
                        ValidarRelacaoTransferenciaVerbaFornecedor(DatasetTransferenciaVerbaFornecedor)
                    ElseIf (linha.RowState = System.Data.DataRowState.Deleted) Then
                        'TODO: Remover registros que dependam desse
                    ElseIf (linha.RowState = System.Data.DataRowState.Modified) Then
                        'TODO: Tratar alguma regra para o update dos dados
                        ValidarRelacaoTransferenciaVerbaFornecedor(DatasetTransferenciaVerbaFornecedor)
                    End If
                Next

                'Envia os dados à DAL para salvar em banco
                ContaCorrenteFornecedor.AtualizarRelacaoTransferenciaVerbaFornecedor(DatasetTransferenciaVerbaFornecedor)
                Me.SetComplete()

            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Sub

        Private Sub ValidarRelacaoTransferenciaVerbaFornecedor(ByRef DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor)
            Try
                'Trata campos do tipo string, não permitido nulo, e com valor nulo
                For Each linha As DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRNRow In DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRN
                    If linha.RowState <> DataRowState.Deleted Then
                    End If
                Next

                'Transforma os campos do tipo string em caixa alta
                For Each linha As DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRNRow In DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRN
                    If linha.RowState <> DataRowState.Deleted Then
                    End If
                Next

                'Trata campos do tipo string e que não permite nulo
                'substituindo por espaço
                For Each linha As DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRNRow In DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRN
                    If linha.RowState <> DataRowState.Deleted Then
                    End If
                Next
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
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	29/11/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterNovaChaveTransferenciaVerba() As Decimal
            Try
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorDAL
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
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorDAL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorDAL
                Dim DatasetFuncionario As DatasetFuncionario
                DatasetFuncionario = ContaCorrenteFornecedor.ObterFuncionario(CODFNC)

                Me.SetComplete()
                Return DatasetFuncionario

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="CODSISINF"></param>
        ''' <param name="NUMFLUAPV"></param>
        ''' <param name="NUMSEQFLUAPV"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	12/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterFluxosDeTransferenciaVerbaFornecedor(ByVal NUMFLUAPV As Decimal) As DatasetTransferenciaVerbaFornecedor
            Try
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorDAL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorDAL
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedor.ObterFluxosDeTransferenciaVerbaFornecedor(NUMFLUAPV)

                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor

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
        ''' 	[Danilo Rafael]	2/6/2009	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterFluxosDeTransferenciaVerbaFornecedorMarketing(ByVal NUMFLUAPV As Decimal) As DatasetTransferenciaVerbaFornecedor
            Try
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorDAL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorDAL
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedor.ObterFluxosDeTransferenciaVerbaFornecedorMarketing(NUMFLUAPV)

                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor

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
        ''' 	[Danilo Rafael]	20/8/2009	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterFluxosDeTransferenciaVerbaDesoneracaoEResultadoAGF(ByVal NUMFLUAPV As Decimal) As DatasetTransferenciaVerbaFornecedor
            Try
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorDAL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorDAL
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedor.ObterFluxosDeTransferenciaVerbaDesoneracaoEResultadoAGF(NUMFLUAPV)

                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor

            Catch ex As Exception
                Me.SetAbort()
                Throw ex
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
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorDAL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorDAL
                Dim DatasetReservaSaldoFornecedor As DatasetReservaSaldoFornecedor
                DatasetReservaSaldoFornecedor = ContaCorrenteFornecedor.ObterReservaSaldoFornecedor(CODACOCMC, CODFRN, TIPDSNDSCBNF)

                Me.SetComplete()
                Return DatasetReservaSaldoFornecedor

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade T0123159 com base na sua chave primária.
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
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorDAL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorDAL
                Dim DatasetReservaSaldoFornecedor As DatasetReservaSaldoFornecedor
                DatasetReservaSaldoFornecedor = ContaCorrenteFornecedor.ObterReservasSaldoFornecedor(CODACOCMC, CODFRN, DATAPVACOCMC, DATAPVACOCMCInicial, DATAPVACOCMCFinal, TIPDSNDSCBNF)
                Me.SetComplete()
                Return DatasetReservaSaldoFornecedor

            Catch ex As Exception

                Me.SetAbort()
                Throw ex
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
                Dim chave As Double
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorDAL
                chave = -1

                'O loop abaixo trata os dados antes de enviá-los ao banco
                For Each linha As DatasetReservaSaldoFornecedor.T0123159Row In DatasetReservaSaldoFornecedor.T0123159
                    If (linha.RowState = System.Data.DataRowState.Added) Then
                        'Inserindo, buscar nova chave sequencial
                        'If (chave = -1) Then
                        '    chave = ReservaSaldoFornecedor.ObterNovaChaveReservaSaldoFornecedor
                        '    If chave = 0 Then chave = 1
                        'Else
                        '    chave = chave + 1
                        'End If
                        'linha. = Convert.To(chave)
                        ValidarReservaSaldoFornecedor(linha)
                    ElseIf (linha.RowState = System.Data.DataRowState.Deleted) Then
                        'TODO: Remover registros que dependam desse
                    ElseIf (linha.RowState = System.Data.DataRowState.Modified) Then
                        'TODO: Tratar alguma regra para o update dos dados
                        ValidarReservaSaldoFornecedor(linha)
                    End If
                Next

                'Envia os dados à DAL para salvar em banco
                ContaCorrenteFornecedor.AtualizarReservaSaldoFornecedor(DatasetReservaSaldoFornecedor)
                Me.SetComplete()

            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Sub

        Private Sub ValidarReservaSaldoFornecedor(ByRef linha As DatasetReservaSaldoFornecedor.T0123159Row)
            Try
                'Trata campos do tipo string, não permitido nulo, e com valor nulo
                If linha.RowState <> DataRowState.Deleted Then
                    If linha.IsNull("CODACOCMC") Then linha.CODACOCMC = " "
                    If linha.IsNull("FLGAPVACOCMC") Then linha.FLGAPVACOCMC = " "
                    If linha.IsNull("FLGLMTCNTCRR") Then linha.FLGLMTCNTCRR = " "
                    If linha.IsNull("TIPACOCMC") Then linha.TIPACOCMC = " "
                End If

                'Transforma os campos do tipo string em caixa alta
                If linha.RowState <> DataRowState.Deleted Then
                    If Not linha.IsNull("CODACOCMC") Then linha.CODACOCMC = linha.CODACOCMC.Trim().ToUpper()
                    If Not linha.IsNull("FLGAPVACOCMC") Then linha.FLGAPVACOCMC = linha.FLGAPVACOCMC.Trim().ToUpper()
                    If Not linha.IsNull("FLGLMTCNTCRR") Then linha.FLGLMTCNTCRR = linha.FLGLMTCNTCRR.Trim().ToUpper()
                    If Not linha.IsNull("TIPACOCMC") Then linha.TIPACOCMC = linha.TIPACOCMC.Trim().ToUpper()
                End If

                'Trata campos do tipo string e que não permite nulo
                'substituindo por espaço
                If linha.RowState <> DataRowState.Deleted Then
                    If linha.CODACOCMC = "" Then linha.CODACOCMC = " "
                    If linha.FLGAPVACOCMC = "" Then linha.FLGAPVACOCMC = " "
                    If linha.FLGLMTCNTCRR = "" Then linha.FLGLMTCNTCRR = " "
                    If linha.TIPACOCMC = "" Then linha.TIPACOCMC = " "
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
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	26/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterFuncionarioAprovadorDaControladoriaQuandoMesLancamentoForDiferenteDoMesDeAprovacao() As Decimal
            Try
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorDAL
                Dim result As Decimal

                result = ContaCorrenteFornecedor.ObterFuncionarioAprovadorDaControladoriaQuandoMesLancamentoForDiferenteDoMesDeAprovacao
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
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorDAL
                ContaCorrenteFornecedor = New ContaCorrenteFornecedorDAL
                Dim DatasetCalendarioAnual As DatasetCalendarioAnual
                DatasetCalendarioAnual = ContaCorrenteFornecedor.ObterCalendarioAnual(DATREF)

                Me.SetComplete()
                Return DatasetCalendarioAnual

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
        ''' 	[Danilo Rafael]	29/5/2009	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterAprovadoresEmpenhoMarketing() As DatasetTransferenciaVerbaFornecedor
            Try
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorDAL
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor

                DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedor.ObterAprovadoresEmpenhoMarketing
                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

#Region "Stored Procedure"

#Region "AtualizarTransferenciaGAC"

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
                AtualizarContaCorrenteFornecedor(pvDatRefLmt, _
                                                 pvTipDsnDscBnfOrigem, _
                                                 pvCodFrnOrigem, _
                                                 "D", _
                                                 1, _
                                                 " ", _
                                                 " ", _
                                                 " ", _
                                                 " ", _
                                                 pvVlrLmtCtb, _
                                                 pvDesHstLmt, _
                                                 pvDesVarHstPadOrigem, _
                                                 pvNomAcsUsrGrcLmt, _
                                                 Nothing, _
                                                 Nothing, _
                                                 String.Empty, _
                                                 pvTipAlcVbaFrnPmtOrigem, _
                                                 0)

                AtualizarContaCorrenteFornecedor(pvDatRefLmt, _
                                                 pvTipDsnDscBnfDestino, _
                                                 pvCodFrnDestino, _
                                                 "C", _
                                                 1, _
                                                 " ", _
                                                 " ", _
                                                 " ", _
                                                 " ", _
                                                 pvVlrLmtCtb, _
                                                 pvDesHstLmt, _
                                                 pvDesVarHstPadDestino, _
                                                 pvNomAcsUsrGrcLmt, _
                                                 Nothing, _
                                                 Nothing, _
                                                 String.Empty, _
                                                 pvTipAlcVbaFrnPmtDestino, _
                                                 0)

                GravaDadosTrasnf(pvDatRefLmt, pvTipDsnDscBnfOrigem, pvTipDsnDscBnfDestino, pvCodFrnOrigem, pvCodFrnDestino)

                Me.SetComplete()
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Grava dados da transferencia na tabela T0144946
        ''' </summary>
        ''' <param name="pvDatRefLmt"></param>
        ''' <param name="pvTipDsnDscBnfOrigem"></param>
        ''' <param name="pvTipDsnDscBnfDestino"></param>
        ''' <param name="pvCodFrnOrigem"></param>
        ''' <param name="pvCodFrnDestino"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	29/12/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Function GravaDadosTrasnf(ByVal pvDatRefLmt As Date, _
                                          ByVal pvTipDsnDscBnfOrigem As Decimal, _
                                          ByVal pvTipDsnDscBnfDestino As Decimal, _
                                          ByVal pvCodFrnOrigem As Decimal, _
                                          ByVal pvCodFrnDestino As Decimal) As Boolean
            Try
                Dim AcordoComercial As New AcordoComercialDAL
                Dim ds As New DatasetTransferenciaVerbasEntreEmpenhos
                Dim linha As DatasetTransferenciaVerbasEntreEmpenhos.T0144946Row

                linha = ds.T0144946.NewT0144946Row

                With linha
                    .CODFRNORITRNVBA = pvCodFrnOrigem
                    .CODFRNDSNTRNVBA = pvCodFrnDestino
                    .TIPDSNDSCBNFORITRN = pvTipDsnDscBnfOrigem
                    .TIPDSNDSCBNFDSNTRN = pvTipDsnDscBnfDestino
                    .NUMSEQLMTORITRNVBA = Convert.ToDecimal(ObterNumeroSequenciaLancamento(pvTipDsnDscBnfOrigem, pvCodFrnOrigem, pvDatRefLmt, 1, "D"))
                    .NUMSEQLMTDSNTRNVBA = Convert.ToDecimal(ObterNumeroSequenciaLancamento(pvTipDsnDscBnfDestino, pvCodFrnDestino, pvDatRefLmt, 1, "C"))
                    .CODGDCORITRNVBA = "D"
                    .CODGDCDSNTRNVBA = "C"
                    .DATREFLMT = pvDatRefLmt
                End With

                ds.T0144946.AddT0144946Row(linha)
                AcordoComercial.AtualizarTransferenciaVerbasEntreEmpenhos(ds)

                Me.SetComplete()
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Obtem o numero da última sequencia de lançamento
        ''' </summary>
        ''' <param name="pvTipDsnDscBnf"></param>
        ''' <param name="pvCodFrn"></param>
        ''' <param name="pvDatRefLmt"></param>
        ''' <param name="pvCodTipLmt"></param>
        ''' <param name="pCodUni"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[PRETRE21]	12/29/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Function ObterNumeroSequenciaLancamento(ByVal pvTipDsnDscBnf As Decimal, _
                                                        ByVal pvCodFrn As Decimal, _
                                                        ByVal pvDatRefLmt As Date, _
                                                        ByVal pvCodTipLmt As Integer, _
                                                        ByVal pCodUni As String) As Integer
            Try
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorDAL

                ContaCorrenteFornecedor.ObterNumeroSequenciaLancamento(pvTipDsnDscBnf, _
                                                                       pvCodFrn, _
                                                                       pvDatRefLmt, _
                                                                       pvCodTipLmt, _
                                                                       pCodUni)
                Me.SetComplete()
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

#End Region

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
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorDAL
                Dim result As Boolean

                If pvDesVarHstPad.Length > 50 Then pvDesVarHstPad = pvDesVarHstPad.Substring(0, 50)

                ContaCorrenteFornecedor.AtualizarContaCorrenteFornecedor(pvDatRefLmt, _
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
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Sub

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
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorDAL
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
                Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorDAL
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
                Dim ContaCorrenteFornecedor As ContaCorrenteFornecedorDAL = New ContaCorrenteFornecedorDAL
                Dim ds As DatasetSelecaoValorDisponivelFornecedor
                ds = ContaCorrenteFornecedor.ObterSelecaoValorDisponivelFornecedor(vDatRef, vCodFrn, vTipDsnDscBnf)

                Me.SetComplete()
                Return ds
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

#End Region

    End Class
End Namespace