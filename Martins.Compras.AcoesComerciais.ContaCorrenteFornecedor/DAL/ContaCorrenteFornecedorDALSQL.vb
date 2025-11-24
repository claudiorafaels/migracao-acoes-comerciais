Imports Martins.Data

Namespace DAL
    ''' -----------------------------------------------------------------------------
    ''' Project   : Martins.Compras.AcoesComerciais.ContaCorrenteFornecedor
    ''' Class     : ContaCorrenteFornecedorDALSQL
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Classe de geração de comandos sql
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    21/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Friend Class ContaCorrenteFornecedorDALSQL

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela T0162251 com base na sua chave primária.
        ''' Descrição da entidade:RELACAO TIPO DE LANÇAMENTO PRINCIPAL X TIPO LANÇAMENTO ASSOCIADO
        ''' </summary>
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    21/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectTipoLancamentoPrincipalXTipoLancamentoAssociado(ByVal data As IData) As String
            Dim sql As String

            sql &= "SELECT " + vbCrLf + _ 
                   "         CODTIPLMTASC, " + vbCrLf + _
                   "         CODTIPLMTPCP " + vbCrLf + _
                   "FROM     MRT.T0162251 " + vbCrLf + _
                   "WHERE    CODTIPLMTASC=" + data.ConvertParameterName("CODTIPLMTASC") + vbCrLf + _
                   "         AND CODTIPLMTPCP=" + data.ConvertParameterName("CODTIPLMTPCP") + vbCrLf + _
                   ""
            Return sql
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela T0162251 com base em atributos que não fazem parte da chave primária.
        ''' Descrição da entidade:RELACAO TIPO DE LANÇAMENTO PRINCIPAL X TIPO LANÇAMENTO ASSOCIADO
        ''' </summary>
        ''' <param name="data">Contexto do banco de dados</param>
        ''' <param name="CODTIPLMTASC">CODIGO TIPO LANCAMENTO ASSOCIADO.</param>
        ''' <param name="CODTIPLMTPCP">CODIGO TIPO LANCAMENTO PRINCIPAL.</param>
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    21/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectTipoLancamentoPrincipalXTipoLancamentoAssociado(ByVal data As IData, _
                                                                                        ByVal CODTIPLMTASC As Decimal, _
                                                                                        ByVal CODTIPLMTPCP As Decimal) As String
            Dim sql As String
            Dim clausulaWhere As String

            sql &= "SELECT " + _ 
                   "         CODTIPLMTASC, " + vbCrLf + _
                   "         CODTIPLMTPCP " + vbCrLf + _
                   "FROM     MRT.T0162251 " + vbCrLf 

            If CODTIPLMTASC <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "CODTIPLMTASC=" + data.ConvertParameterName("CODTIPLMTASC") + vbCrLf
            End If
            If CODTIPLMTPCP <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "CODTIPLMTPCP=" + data.ConvertParameterName("CODTIPLMTPCP") + vbCrLf
            End If

            sql &= clausulaWhere

            Return sql
        End Function


        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela T0123086 com base na sua chave primária.
        ''' Descrição da entidade:MOVIMENTO DIARIO CONTA CORRENTE FORNECEDOR
        ''' </summary>
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    21/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectContaCorrenteFornecedor(ByVal data As IData) As String
            Dim sql As String

            sql &= "SELECT " + vbCrLf + _
                   "         CODCENCSTCRD, " + vbCrLf + _
                   "         CODCENCSTDEB, " + vbCrLf + _
                   "         CODCNTCRD, " + vbCrLf + _
                   "         CODCNTDEB, " + vbCrLf + _
                   "         CODFILEMP, " + vbCrLf + _
                   "         CODFRN, " + vbCrLf + _
                   "         CODGDC, " + vbCrLf + _
                   "         CODPMS, " + vbCrLf + _
                   "         CODTIPLMT, " + vbCrLf + _
                   "         DATCTBLMT, " + vbCrLf + _
                   "         DATREFLMT, " + vbCrLf + _
                   "         DESHSTLMT, " + vbCrLf + _
                   "         DESVARHSTPAD, " + vbCrLf + _
                   "         NOMACSUSRGRCLMT, " + vbCrLf + _
                   "         NUMSEQLMT, " + vbCrLf + _
                   "         TIPDSNDSCBNF, " + vbCrLf + _
                   "         TIPDSNDSCEVTACOCMC, " + vbCrLf + _
                   "         VLRLMTCTB " + vbCrLf + _
                   "FROM     MRT.T0123086 " + vbCrLf + _
                   "WHERE    CODFRN=" + data.ConvertParameterName("CODFRN") + vbCrLf + _
                   "         AND CODGDC=" + data.ConvertParameterName("CODGDC") + vbCrLf + _
                   "         AND Trunc(DATREFLMT)=" + data.ConvertParameterName("DATREFLMT") + vbCrLf + _
                   "         AND NUMSEQLMT=" + data.ConvertParameterName("NUMSEQLMT") + vbCrLf + _
                   "         AND TIPDSNDSCBNF=" + data.ConvertParameterName("TIPDSNDSCBNF") + vbCrLf + _
                   ""
            Return sql
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela T0123086 com base em atributos que não fazem parte da chave primária.
        ''' Descrição da entidade:MOVIMENTO DIARIO CONTA CORRENTE FORNECEDOR
        ''' </summary>
        ''' <param name="data">Contexto do banco de dados</param>
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
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    21/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectContaCorrenteFornecedor(ByVal data As IData, _
                                                                ByVal CODCENCSTCRD As String, _
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
                                                                ByVal TIPDSNDSCBNF As Decimal) As String
            Dim sql As String
            Dim clausulaWhere As String

            sql &= "SELECT " + _
                   "         CODCENCSTCRD, " + vbCrLf + _
                   "         CODCENCSTDEB, " + vbCrLf + _
                   "         CODCNTCRD, " + vbCrLf + _
                   "         CODCNTDEB, " + vbCrLf + _
                   "         CODFILEMP, " + vbCrLf + _
                   "         CODFRN, " + vbCrLf + _
                   "         CODGDC, " + vbCrLf + _
                   "         CODPMS, " + vbCrLf + _
                   "         CODTIPLMT, " + vbCrLf + _
                   "         DATCTBLMT, " + vbCrLf + _
                   "         DATREFLMT, " + vbCrLf + _
                   "         DESHSTLMT, " + vbCrLf + _
                   "         DESVARHSTPAD, " + vbCrLf + _
                   "         NOMACSUSRGRCLMT, " + vbCrLf + _
                   "         NUMSEQLMT, " + vbCrLf + _
                   "         TIPDSNDSCBNF, " + vbCrLf + _
                   "         TIPDSNDSCEVTACOCMC, " + vbCrLf + _
                   "         VLRLMTCTB " + vbCrLf + _
                   "FROM     MRT.T0123086 " + vbCrLf

            If CODCENCSTCRD.Trim() <> "" Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "Upper(CODCENCSTCRD) Like " + data.ConvertParameterName("CODCENCSTCRD") + vbCrLf
            End If
            If CODCENCSTDEB.Trim() <> "" Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "Upper(CODCENCSTDEB) Like " + data.ConvertParameterName("CODCENCSTDEB") + vbCrLf
            End If
            If CODCNTCRD.Trim() <> "" Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "Upper(CODCNTCRD) Like " + data.ConvertParameterName("CODCNTCRD") + vbCrLf
            End If
            If CODCNTDEB.Trim() <> "" Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "Upper(CODCNTDEB) Like " + data.ConvertParameterName("CODCNTDEB") + vbCrLf
            End If
            If CODFILEMP <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "CODFILEMP=" + data.ConvertParameterName("CODFILEMP") + vbCrLf
            End If
            If CODFRN <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "CODFRN=" + data.ConvertParameterName("CODFRN") + vbCrLf
            End If
            If CODGDC.Trim() <> "" Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "Upper(CODGDC) Like " + data.ConvertParameterName("CODGDC") + vbCrLf
            End If
            If CODPMS <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "CODPMS=" + data.ConvertParameterName("CODPMS") + vbCrLf
            End If
            If CODTIPLMT <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "CODTIPLMT=" + data.ConvertParameterName("CODTIPLMT") + vbCrLf
            End If
            If DATREFLMT <> Nothing Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "DATREFLMT=" + data.ConvertParameterName("DATREFLMT") + vbCrLf
            End If
            If DATREFLMTInicial <> Nothing And DATREFLMTFinal <> Nothing Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "DATREFLMT Between " + data.ConvertParameterName("DATREFLMTInicial") + " AND " + data.ConvertParameterName("DATREFLMTFinal") + vbCrLf
            End If
            If DESHSTLMT.Trim() <> "" Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "Upper(DESHSTLMT) Like " + data.ConvertParameterName("DESHSTLMT") + vbCrLf
            End If
            If DESVARHSTPAD.Trim() <> "" Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "Upper(DESVARHSTPAD) Like " + data.ConvertParameterName("DESVARHSTPAD") + vbCrLf
            End If
            If NUMSEQLMT <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "NUMSEQLMT=" + data.ConvertParameterName("NUMSEQLMT") + vbCrLf
            End If
            If TIPDSNDSCBNF <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "TIPDSNDSCBNF=" + data.ConvertParameterName("TIPDSNDSCBNF") + vbCrLf
            End If

            sql &= clausulaWhere

            Return sql
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela com os fornecedores da tabela T0123086
        ''' Descrição da entidade:DIVISÃO FORNECEDOR
        ''' </summary>
        ''' <param name="data">Contexto do banco de dados</param>
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
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    21/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectFornecedorDeContaCorrenteFornecedor(ByVal data As IData, _
                                                                            ByVal CODCENCSTCRD As String, _
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
                                                                            ByVal TIPDSNDSCBNF As Decimal) As String
            Dim sql As String
            Dim clausulaWhere As String

            sql &= "SELECT   B.CODFRN, " + _
                   "         B.NOMFRN " + vbCrLf + _
                   "FROM     MRT.T0123086 A " + vbCrLf + _
                   "         INNER JOIN MRT.T0100426 B ON A.CODFRN = B.CODFRN " + vbCrLf

            If CODCENCSTCRD.Trim() <> "" Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "Upper(A.CODCENCSTCRD) Like " + data.ConvertParameterName("CODCENCSTCRD") + vbCrLf
            End If
            If CODCENCSTDEB.Trim() <> "" Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "Upper(A.CODCENCSTDEB) Like " + data.ConvertParameterName("CODCENCSTDEB") + vbCrLf
            End If
            If CODCNTCRD.Trim() <> "" Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "Upper(A.CODCNTCRD) Like " + data.ConvertParameterName("CODCNTCRD") + vbCrLf
            End If
            If CODCNTDEB.Trim() <> "" Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "Upper(A.CODCNTDEB) Like " + data.ConvertParameterName("CODCNTDEB") + vbCrLf
            End If
            If CODFILEMP <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "A.CODFILEMP=" + data.ConvertParameterName("CODFILEMP") + vbCrLf
            End If
            If CODFRN <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "A.CODFRN=" + data.ConvertParameterName("CODFRN") + vbCrLf
            End If
            If CODGDC.Trim() <> "" Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "Upper(A.CODGDC) Like " + data.ConvertParameterName("CODGDC") + vbCrLf
            End If
            If CODPMS <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "A.CODPMS=" + data.ConvertParameterName("CODPMS") + vbCrLf
            End If
            If CODTIPLMT <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "A.CODTIPLMT=" + data.ConvertParameterName("CODTIPLMT") + vbCrLf
            End If
            If DATREFLMT <> Nothing Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "A.DATREFLMT=" + data.ConvertParameterName("DATREFLMT") + vbCrLf
            End If
            If DATREFLMTInicial <> Nothing And DATREFLMTFinal <> Nothing Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "A.DATREFLMT Between " + data.ConvertParameterName("DATREFLMTInicial") + " AND " + data.ConvertParameterName("DATREFLMTFinal") + vbCrLf
            End If
            If DESHSTLMT.Trim() <> "" Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "Upper(A.DESHSTLMT) Like " + data.ConvertParameterName("DESHSTLMT") + vbCrLf
            End If
            If DESVARHSTPAD.Trim() <> "" Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "Upper(A.DESVARHSTPAD) Like " + data.ConvertParameterName("DESVARHSTPAD") + vbCrLf
            End If
            If NUMSEQLMT <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "A.NUMSEQLMT=" + data.ConvertParameterName("NUMSEQLMT") + vbCrLf
            End If
            If TIPDSNDSCBNF <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "A.TIPDSNDSCBNF=" + data.ConvertParameterName("TIPDSNDSCBNF") + vbCrLf
            End If

            sql &= clausulaWhere
            sql &= "GROUP BY B.CODFRN, " + _
                   "         B.NOMFRN "

            Return sql
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela T0123094 com base na sua chave primária.
        ''' Descrição da entidade:PARAMETRO CONTABIL CONTA CORRENTE FORNECEDOR
        ''' </summary>
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    21/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectParametroContabilContaCorrenteFornecedor(ByVal data As IData) As String
            Dim sql As String

            sql &= "SELECT " + vbCrLf + _
                   "         CODCENCSTCRD, " + vbCrLf + _
                   "         CODCENCSTDEB, " + vbCrLf + _
                   "         CODCNTCRD, " + vbCrLf + _
                   "         CODCNTDEB, " + vbCrLf + _
                   "         CODEVTCTB, " + vbCrLf + _
                   "         CODEVTCTBFRTDVL, " + vbCrLf + _
                   "         CODEVTCTBNGCDVL, " + vbCrLf + _
                   "         CODFILEMP, " + vbCrLf + _
                   "         CODFTOCTB, " + vbCrLf + _
                   "         CODFTOCTBFRTDVL, " + vbCrLf + _
                   "         CODFTOCTBNGCDVL, " + vbCrLf + _
                   "         CODHSTPAD, " + vbCrLf + _
                   "         CODTIPLMT " + vbCrLf + _
                   "FROM     MRT.T0123094 " + vbCrLf + _
                   "WHERE    CODFILEMP=" + data.ConvertParameterName("CODFILEMP") + vbCrLf + _
                   "         AND CODTIPLMT=" + data.ConvertParameterName("CODTIPLMT") + vbCrLf + _
                   ""
            Return sql
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela T0123094 com base em atributos que não fazem parte da chave primária.
        ''' Descrição da entidade:PARAMETRO CONTABIL CONTA CORRENTE FORNECEDOR
        ''' </summary>
        ''' <param name="data">Contexto do banco de dados</param>
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
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    21/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectParametroContabilContaCorrenteFornecedor(ByVal data As IData, _
                                                                                 ByVal CODCENCSTCRD As String, _
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
                                                                                 ByVal CODTIPLMT As Decimal) As String
            Dim sql As String
            Dim clausulaWhere As String

            sql &= "SELECT " + _
                   "         CODCENCSTCRD, " + vbCrLf + _
                   "         CODCENCSTDEB, " + vbCrLf + _
                   "         CODCNTCRD, " + vbCrLf + _
                   "         CODCNTDEB, " + vbCrLf + _
                   "         CODEVTCTB, " + vbCrLf + _
                   "         CODEVTCTBFRTDVL, " + vbCrLf + _
                   "         CODEVTCTBNGCDVL, " + vbCrLf + _
                   "         CODFILEMP, " + vbCrLf + _
                   "         CODFTOCTB, " + vbCrLf + _
                   "         CODFTOCTBFRTDVL, " + vbCrLf + _
                   "         CODFTOCTBNGCDVL, " + vbCrLf + _
                   "         CODHSTPAD, " + vbCrLf + _
                   "         CODTIPLMT " + vbCrLf + _
                   "FROM     MRT.T0123094 " + vbCrLf

            If CODCENCSTCRD.Trim() <> "" Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "Upper(CODCENCSTCRD) Like " + data.ConvertParameterName("CODCENCSTCRD") + vbCrLf
            End If
            If CODCENCSTDEB.Trim() <> "" Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "Upper(CODCENCSTDEB) Like " + data.ConvertParameterName("CODCENCSTDEB") + vbCrLf
            End If
            If CODCNTCRD.Trim() <> "" Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "Upper(CODCNTCRD) Like " + data.ConvertParameterName("CODCNTCRD") + vbCrLf
            End If
            If CODCNTDEB.Trim() <> "" Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "Upper(CODCNTDEB) Like " + data.ConvertParameterName("CODCNTDEB") + vbCrLf
            End If
            If CODEVTCTB <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "CODEVTCTB=" + data.ConvertParameterName("CODEVTCTB") + vbCrLf
            End If
            If CODEVTCTBFRTDVL <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "CODEVTCTBFRTDVL=" + data.ConvertParameterName("CODEVTCTBFRTDVL") + vbCrLf
            End If
            If CODEVTCTBNGCDVL <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "CODEVTCTBNGCDVL=" + data.ConvertParameterName("CODEVTCTBNGCDVL") + vbCrLf
            End If
            If CODFILEMP <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "CODFILEMP=" + data.ConvertParameterName("CODFILEMP") + vbCrLf
            End If
            If CODFTOCTB <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "CODFTOCTB=" + data.ConvertParameterName("CODFTOCTB") + vbCrLf
            End If
            If CODFTOCTBFRTDVL <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "CODFTOCTBFRTDVL=" + data.ConvertParameterName("CODFTOCTBFRTDVL") + vbCrLf
            End If
            If CODFTOCTBNGCDVL <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "CODFTOCTBNGCDVL=" + data.ConvertParameterName("CODFTOCTBNGCDVL") + vbCrLf
            End If
            If CODHSTPAD.Trim() <> "" Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "Upper(CODHSTPAD) Like " + data.ConvertParameterName("CODHSTPAD") + vbCrLf
            End If
            If CODTIPLMT <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "CODTIPLMT=" + data.ConvertParameterName("CODTIPLMT") + vbCrLf
            End If

            sql &= clausulaWhere

            Return sql
        End Function


        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela T0123078 com base na sua chave primária.
        ''' Descrição da entidade:RESUMO MENSAL SALDO FORNECEDOR
        ''' </summary>
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    21/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectResumoMensalSaldoFornecedor(ByVal data As IData) As String
            Dim sql As String

            sql &= "SELECT " + vbCrLf + _
                   "         ANOMESREF, " + vbCrLf + _
                   "         CODFRN, " + vbCrLf + _
                   "         TIPDSNDSCBNF, " + vbCrLf + _
                   "         VLRCRDMESCRR, " + vbCrLf + _
                   "         VLRDEBMESCRR, " + vbCrLf + _
                   "         VLRJURMRA, " + vbCrLf + _
                   "         VLRSLDMESANT, " + vbCrLf + _
                   "         VLRSLDPMS " + vbCrLf + _
                   "FROM     MRT.T0123078 " + vbCrLf + _
                   "WHERE    ANOMESREF=" + data.ConvertParameterName("ANOMESREF") + vbCrLf + _
                   "         AND CODFRN=" + data.ConvertParameterName("CODFRN") + vbCrLf + _
                   "         AND TIPDSNDSCBNF=" + data.ConvertParameterName("TIPDSNDSCBNF") + vbCrLf + _
                   ""
            Return sql
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela T0123078 com base em atributos que não fazem parte da chave primária.
        ''' Descrição da entidade:RESUMO MENSAL SALDO FORNECEDOR
        ''' </summary>
        ''' <param name="data">Contexto do banco de dados</param>
        ''' <param name="ANOMESREF">ANO E MES DE REFERENCIA NO FORMATO AAAAMM.</param>
        ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
        ''' <param name="TIPDSNDSCBNF">TIPO DESTINO / DESCONTO BONIFICADO.</param>
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    21/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectResumoMensalSaldoFornecedor(ByVal data As IData, _
                                                                    ByVal ANOMESREF As Decimal, _
                                                                    ByVal CODFRN As Decimal, _
                                                                    ByVal TIPDSNDSCBNF As Decimal) As String
            Dim sql As String
            Dim clausulaWhere As String

            sql &= "SELECT " + _
                   "         ANOMESREF, " + vbCrLf + _
                   "         CODFRN, " + vbCrLf + _
                   "         TIPDSNDSCBNF, " + vbCrLf + _
                   "         VLRCRDMESCRR, " + vbCrLf + _
                   "         VLRDEBMESCRR, " + vbCrLf + _
                   "         VLRJURMRA, " + vbCrLf + _
                   "         VLRSLDMESANT, " + vbCrLf + _
                   "         VLRSLDPMS " + vbCrLf + _
                   "FROM     MRT.T0123078 " + vbCrLf

            If ANOMESREF <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "ANOMESREF=" + data.ConvertParameterName("ANOMESREF") + vbCrLf
            End If
            If CODFRN <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "CODFRN=" + data.ConvertParameterName("CODFRN") + vbCrLf
            End If
            If TIPDSNDSCBNF <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "TIPDSNDSCBNF=" + data.ConvertParameterName("TIPDSNDSCBNF") + vbCrLf
            End If

            sql &= clausulaWhere

            Return sql
        End Function


        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela T0123108 com base na sua chave primária.
        ''' Descrição da entidade:CADASTRO TIPO LANCAMENTO CONTA CORRENTE FORNECEDOR
        ''' </summary>
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    21/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectTipoLancamentoContaCorrenteFornecedor(ByVal data As IData) As String
            Dim sql As String

            sql &= "SELECT " + vbCrLf + _
                   "         CODTIPLMT, " + vbCrLf + _
                   "         DESTIPLMT, " + vbCrLf + _
                   "         DESTIPLMTFRN, " + vbCrLf + _
                   "         FLGGRCLMTCTB, " + vbCrLf + _
                   "         FLGLMTMAN, " + vbCrLf + _
                   "         INDTIPLMTDSPFRN, " + vbCrLf + _
                   "         INDTIPLMTSTN " + vbCrLf + _
                   "FROM     MRT.T0123108 " + vbCrLf + _
                   "WHERE    CODTIPLMT=" + data.ConvertParameterName("CODTIPLMT") + vbCrLf + _
                   ""
            Return sql
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela T0123108 com base em atributos que não fazem parte da chave primária.
        ''' Descrição da entidade:CADASTRO TIPO LANCAMENTO CONTA CORRENTE FORNECEDOR
        ''' </summary>
        ''' <param name="data">Contexto do banco de dados</param>
        ''' <param name="DESTIPLMT">DESCRICAO DO TIPO DE LANCAMENTO.</param>
        ''' <param name="DESTIPLMTFRN">DESCRICAO DO TIPO DE LANCAMENTO FORNECEDOR.</param>
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    21/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectTipoLancamentoContaCorrenteFornecedor(ByVal data As IData, _
                                                                              ByVal DESTIPLMT As String, _
                                                                              ByVal DESTIPLMTFRN As String) As String
            Dim sql As String
            Dim clausulaWhere As String

            sql &= "SELECT " + _
                   "         CODTIPLMT, " + vbCrLf + _
                   "         DESTIPLMT, " + vbCrLf + _
                   "         DESTIPLMTFRN, " + vbCrLf + _
                   "         FLGGRCLMTCTB, " + vbCrLf + _
                   "         FLGLMTMAN, " + vbCrLf + _
                   "         INDTIPLMTDSPFRN, " + vbCrLf + _
                   "         INDTIPLMTSTN " + vbCrLf + _
                   "FROM     MRT.T0123108 " + vbCrLf

            If DESTIPLMT.Trim() <> "" Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "Upper(DESTIPLMT) Like " + data.ConvertParameterName("DESTIPLMT") + vbCrLf
            End If
            If DESTIPLMTFRN.Trim() <> "" Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "Upper(DESTIPLMTFRN) Like " + data.ConvertParameterName("DESTIPLMTFRN") + vbCrLf
            End If

            sql &= clausulaWhere

            Return sql
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Obtem o sql que retorna o atributo quant, através desse atributo é possível
        ''' identificar se o fornecedor pertence a celula atendida pelo usuário compra
        ''' </summary>
        ''' <param name="data"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	29/12/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectFornecedorPertenceCelulaAtendidaUsuario(ByVal data As IData) As String
            Dim sql As String

            sql = "SELECT COUNT(DISTINCT A.CODCPRPCPMER) AS QUANT " + vbCrLf + _
                  "FROM   MRT.T0100086 A ,MRT.T0113625 B , MRT.T0118570 C, MRT.T0144920 D " + vbCrLf + _
                  "WHERE  A.CODFRNPCPMER = " + data.ConvertParameterName("CODFRN") + vbCrLf + _
                  "       AND A.CODEMP  = 1 " + vbCrLf + _
                  "       AND A.CODCPRPCPMER = B.CODCPR " + vbCrLf + _
                  "       AND B.CODGERPRD = C.CODGERPRD " + vbCrLf + _
                  "       AND C.CODDIVCMP = D.CODDIVCMP " + vbCrLf + _
                  "       AND TRIM(UPPER(D.NOMACSUSRSIS)) = " + data.ConvertParameterName("NOMACSUSRSIS") + vbCrLf

            Return sql
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Obtem o sql que retorna o atributo quant, através desse atributo é possível
        ''' identificar se o fornecedor pertence a celula atendida pelo usuário compra
        ''' esse caso é uma exeção criada para atender a uma situação específica, utilizado hard code
        ''' </summary>
        ''' <param name="data"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	20/3/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectFornecedorPertenceCelulaAtendidaUsuarioExcecao1(ByVal data As IData) As String
            Dim sql As String

            sql = "SELECT COUNT(*) AS QUANT " + vbCrLf + _
                  "FROM   MRT.T0144920 D " + vbCrLf + _
                  "WHERE  D.CODDIVCMP = 19 " + vbCrLf + _
                  "       AND TRIM(UPPER(D.NOMACSUSRSIS)) = " + data.ConvertParameterName("NOMACSUSRSIS") + vbCrLf

            Return sql
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela CADTRNVBAFRN com base na sua chave primária.
        ''' Descrição da entidade:CADASTRO DE TRANSFERENCIA VERBAS FORNECEDOR
        ''' </summary>
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    27/11/2007  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectTransferenciaVerbaFornecedor(ByVal data As IData) As String
            Dim sql As New System.Text.StringBuilder

            sql.Append("SELECT " + vbCrLf)
            sql.Append("         CODFNC, " + vbCrLf)
            sql.Append("         DESJSTTRNVBA, " + vbCrLf)
            sql.Append("         NUMFLUAPV, " + vbCrLf)
            sql.Append("         TIPALCVBAFRN, " + vbCrLf)
            sql.Append("         TIPDSNDSCBNFDSNTRN, " + vbCrLf)
            sql.Append("         TIPSTAFLUAPV, " + vbCrLf)
            sql.Append("         INDFLUTRNVBAMKT, " + vbCrLf)
            sql.Append("         PERPSQSLDFRN, " + vbCrLf)
            sql.Append("         INDMESTRNFLU " + vbCrLf)
            sql.Append("FROM     MRT.CADTRNVBAFRN " + vbCrLf)
            sql.Append("WHERE    NUMFLUAPV=" + data.ConvertParameterName("NUMFLUAPV") + vbCrLf)

            Return sql.ToString
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela CADTRNVBAFRN com base em atributos que não fazem parte da chave primária.
        ''' Descrição da entidade:CADASTRO DE TRANSFERENCIA VERBAS FORNECEDOR
        ''' </summary>
        ''' <param name="data">Contexto do banco de dados</param>
        ''' <param name="CODFNC">CODIGO FUNCIONARIO.</param>
        ''' <param name="DESJSTTRNVBA">DESCRICAO JUSTIFICATIVA DA TRANSFERENCIA DE VERBA.</param>
        ''' <param name="NUMFLUAPV">NUMERO FLUXO DE APROVACAO.</param>
        ''' <param name="TIPALCVBAFRN">TIPO DE ALOCACAO DA VERBA DO FORNECEDOR.</param>
        ''' <param name="TIPDSNDSCBNFDSNTRN">TIPO EMPENHO DESTINO TRANSFERENCIA VERBA.</param>
        ''' <param name="TIPSTAFLUAPV">TIPO STATUS FLUXO APROVACAO.</param>
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    27/11/2007  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectTransferenciaVerbaFornecedor(ByVal data As IData, _
                                                                     ByVal CODFNC As Decimal, _
                                                                     ByVal DESJSTTRNVBA As String, _
                                                                     ByVal NUMFLUAPV As Decimal, _
                                                                     ByVal TIPALCVBAFRN As Decimal, _
                                                                     ByVal TIPDSNDSCBNFDSNTRN As Decimal, _
                                                                     ByVal TIPSTAFLUAPV As String) As String
            Dim sql As New System.Text.StringBuilder
            Dim clausulaWhere As New System.Text.StringBuilder

            sql.Append("SELECT " + vbCrLf)
            sql.Append("         CODFNC, " + vbCrLf)
            sql.Append("         DESJSTTRNVBA, " + vbCrLf)
            sql.Append("         NUMFLUAPV, " + vbCrLf)
            sql.Append("         TIPALCVBAFRN, " + vbCrLf)
            sql.Append("         TIPDSNDSCBNFDSNTRN, " + vbCrLf)
            sql.Append("         TIPSTAFLUAPV, " + vbCrLf)
            sql.Append("         INDFLUTRNVBAMKT, " + vbCrLf)
            sql.Append("         PERPSQSLDFRN, " + vbCrLf)
            sql.Append("         INDMESTRNFLU " + vbCrLf)
            sql.Append("FROM     MRT.CADTRNVBAFRN " + vbCrLf)

            If CODFNC <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("CODFNC=" + data.ConvertParameterName("CODFNC") + vbCrLf)
            End If
            If DESJSTTRNVBA.Trim() <> "" Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("Upper(DESJSTTRNVBA) Like " + data.ConvertParameterName("DESJSTTRNVBA") + vbCrLf)
            End If
            If NUMFLUAPV <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("NUMFLUAPV=" + data.ConvertParameterName("NUMFLUAPV") + vbCrLf)
            End If
            If TIPALCVBAFRN <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("TIPALCVBAFRN=" + data.ConvertParameterName("TIPALCVBAFRN") + vbCrLf)
            End If
            If TIPDSNDSCBNFDSNTRN <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("TIPDSNDSCBNFDSNTRN=" + data.ConvertParameterName("TIPDSNDSCBNFDSNTRN") + vbCrLf)
            End If
            If TIPSTAFLUAPV.Trim() <> "" Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("Upper(TIPSTAFLUAPV) Like " + data.ConvertParameterName("TIPSTAFLUAPV") + vbCrLf)
            End If

            sql.Append(clausulaWhere)

            Return sql.ToString
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela RLCTRNVBAFRN com base na sua chave primária.
        ''' Descrição da entidade:RELACAO DE TRANSFERENCIA VERBAS FORNECEDOR
        ''' </summary>
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    27/11/2007  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectRelacaoTransferenciaVerbaFornecedor(ByVal data As IData) As String
            Dim sql As New System.Text.StringBuilder

            sql.Append("SELECT " + vbCrLf)
            sql.Append("         CODFRN, " + vbCrLf)
            sql.Append("         NUMFLUAPV, " + vbCrLf)
            sql.Append("         TIPALCVBAFRN, " + vbCrLf)
            sql.Append("         TIPDSNDSCBNFORITRN, " + vbCrLf)
            sql.Append("         VLRLMTCTB, " + vbCrLf)
            sql.Append("         INDMESTRNFLU " + vbCrLf)
            sql.Append("FROM     MRT.RLCTRNVBAFRN ")
            sql.Append("WHERE    CODFRN=" + data.ConvertParameterName("CODFRN") + vbCrLf)
            sql.Append("         AND NUMFLUAPV=" + data.ConvertParameterName("NUMFLUAPV") + vbCrLf)
            sql.Append("         AND TIPALCVBAFRN=" + data.ConvertParameterName("TIPALCVBAFRN") + vbCrLf)
            sql.Append("         AND TIPDSNDSCBNFORITRN=" + data.ConvertParameterName("TIPDSNDSCBNFORITRN") + vbCrLf)

            Return sql.ToString
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela RLCTRNVBAFRN com base na sua chave primária.
        ''' Descrição da entidade:RELACAO DE TRANSFERENCIA VERBAS FORNECEDOR
        ''' </summary>
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    27/11/2007  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectRelacaoTransferenciaVerbaFornecedorJoin(ByVal data As IData, _
                                                                                ByVal NUMFLUAPV As Decimal, _
                                                                                ByVal CODFNC As Decimal, _
                                                                                ByVal TIPSTAFLUAPV As String) As String
            Dim sql As New System.Text.StringBuilder
            Dim clausulaWhere As New System.Text.StringBuilder

            sql.Append("Select DISTINCT " + vbCrLf)
            sql.Append("       A.NUMFLUAPV, " + vbCrLf)
            sql.Append("       A.TIPSTAFLUAPV, " + vbCrLf)
            sql.Append("       Case A.TIPSTAFLUAPV " + vbCrLf)
            sql.Append("            WHEN '0' THEN 'NOVO' " + vbCrLf)
            sql.Append("            WHEN '1' THEN 'EM APROVAÇÃO' " + vbCrLf)
            sql.Append("            WHEN '2' THEN 'REJEITADO' " + vbCrLf)
            sql.Append("            WHEN '3' THEN 'APROVADO' " + vbCrLf)
            sql.Append("            WHEN '4' THEN 'ESPERA APROVAÇÃO' " + vbCrLf)
            sql.Append("       End AS DESSTAFLUAPV, " + vbCrLf)
            sql.Append("       D.DESALCVBAFRN, " + vbCrLf)
            sql.Append("       E.DESDSNDSCBNF, " + vbCrLf)
            sql.Append("       A.DESJSTTRNVBA, " + vbCrLf)
            sql.Append("       F.NOMFNC, " + vbCrLf)
            sql.Append("       A.INDMESTRNFLU " + vbCrLf)
            sql.Append("FROM   MRT.CADTRNVBAFRN A " + vbCrLf)
            sql.Append("       LEFT  JOIN MRT.T0161591 B ON A.NUMFLUAPV = B.NUMFLUAPV " + vbCrLf)
            sql.Append("                                 AND B.CODSISINF = " + Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS.ToString + vbCrLf)
            sql.Append("       LEFT  JOIN MRT.T0153350 C ON B.CODEDEAPV = C.CODFNCAPVNGC " + vbCrLf)
            sql.Append("                                 AND C.DATDST IS NULL " + vbCrLf)
            sql.Append("       INNER JOIN MRT.T0151799 D ON A.TIPALCVBAFRN = D.TIPALCVBAFRN " + vbCrLf)
            sql.Append("       INNER JOIN MRT.T0109059 E ON A.TIPDSNDSCBNFDSNTRN = E.TIPDSNDSCBNF " + vbCrLf)
            sql.Append("       INNER JOIN MRT.T0100361 F ON A.CODFNC = F.CODFNC " + vbCrLf)

            If NUMFLUAPV <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE ")
                Else
                    clausulaWhere.Append("       And ")
                End If
                clausulaWhere.Append("A.NUMFLUAPV=" + data.ConvertParameterName("NUMFLUAPV") + vbCrLf)
            End If

            If CODFNC <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE ")
                Else
                    clausulaWhere.Append("       And ")
                End If
                clausulaWhere.Append("B.CODEDEAPV=" + data.ConvertParameterName("CODEDEAPV1") + " OR (C.CODFNCARZAPVNGC=" + data.ConvertParameterName("CODEDEAPV2") & " AND SYSTIMESTAMP BETWEEN C.DATINI AND C.DATFIM)" + vbCrLf)
            End If

            If TIPSTAFLUAPV <> "" Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE ")
                Else
                    clausulaWhere.Append("       And ")
                End If
                clausulaWhere.Append("A.TIPSTAFLUAPV=" + data.ConvertParameterName("TIPSTAFLUAPV") + vbCrLf)
            End If

            sql.Append(clausulaWhere)

            Return sql.ToString
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="data"></param>
        ''' <param name="NUMFLUAPV"></param>
        ''' <param name="CODFNC"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	22/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectMinhasAprovavoesEmTransferenciaVerbasFornecedor(ByVal data As IData, _
                                                                                        ByVal NUMFLUAPV As Decimal, _
                                                                                        ByVal CODFNC As Decimal) As String
            Dim sql As New System.Text.StringBuilder
            Dim clausulaWhere As New System.Text.StringBuilder

            sql.Append("Select DISTINCT " + vbCrLf)
            sql.Append("       A.NUMFLUAPV, " + vbCrLf)
            sql.Append("       A.TIPSTAFLUAPV, " + vbCrLf)
            sql.Append("       Case A.TIPSTAFLUAPV " + vbCrLf)
            sql.Append("            WHEN '0' THEN 'NOVO' " + vbCrLf)
            sql.Append("            WHEN '1' THEN 'EM APROVAÇÃO' " + vbCrLf)
            sql.Append("            WHEN '2' THEN 'REJEITADO' " + vbCrLf)
            sql.Append("            WHEN '3' THEN 'APROVADO' " + vbCrLf)
            sql.Append("            WHEN '4' THEN 'ESPERA APROVAÇÃO' " + vbCrLf)
            sql.Append("       End AS DESSTAFLUAPV, " + vbCrLf)
            sql.Append("       D.DESALCVBAFRN, " + vbCrLf)
            sql.Append("       E.DESDSNDSCBNF, " + vbCrLf)
            sql.Append("       A.DESJSTTRNVBA, " + vbCrLf)
            sql.Append("       F.NOMFNC, " + vbCrLf)
            sql.Append("       A.INDMESTRNFLU " + vbCrLf)
            sql.Append("FROM   MRT.CADTRNVBAFRN A " + vbCrLf)
            sql.Append("       LEFT  JOIN MRT.T0161591 B ON A.NUMFLUAPV = B.NUMFLUAPV " + vbCrLf)
            sql.Append("                                 AND B.CODSISINF IN ( " + Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS.ToString & ", " & Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS_EMPENHO_MARKETING.ToString & ", " & Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS_DESONERACAO_E_RESULTADO_AGF & ")" + vbCrLf)
            sql.Append("       LEFT  JOIN MRT.T0153350 C ON B.CODEDEAPV = C.CODFNCAPVNGC " + vbCrLf)
            sql.Append("                                 AND C.DATDST IS NULL " + vbCrLf)
            sql.Append("       INNER JOIN MRT.T0151799 D ON A.TIPALCVBAFRN = D.TIPALCVBAFRN " + vbCrLf)
            sql.Append("       INNER JOIN MRT.T0109059 E ON A.TIPDSNDSCBNFDSNTRN = E.TIPDSNDSCBNF " + vbCrLf)
            sql.Append("       INNER JOIN MRT.T0100361 F ON A.CODFNC = F.CODFNC " + vbCrLf)
            sql.Append("WHERE  (B.CODEDEAPV=" + data.ConvertParameterName("CODEDEAPV1") + " OR (C.CODFNCARZAPVNGC=" + data.ConvertParameterName("CODEDEAPV2") & " AND SYSTIMESTAMP BETWEEN C.DATINI AND C.DATFIM))" + vbCrLf)
            sql.Append("       AND B.TIPSTAFLUAPV='" + Constants.TIPSTAFLUAPV_EM_APROVACAO.ToString + "'" & vbCrLf)

            If NUMFLUAPV <> 0 Then
                sql.Append("       And A.NUMFLUAPV=" + data.ConvertParameterName("NUMFLUAPV") + vbCrLf)
            End If

            Return sql.ToString
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="data"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	5/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectRelacaoTransferenciaVerbaFornecedorJoinT0153541JoinT0100426JoinT0113625JoinT0118570JoinT0109059(ByVal data As IData) As String
            Dim sql As New System.Text.StringBuilder

            sql.Append("SELECT DISTINCT " + vbCrLf)
            sql.Append("       E.CODDIVCMP, " + vbCrLf)
            sql.Append("       UPPER(E.DESDIVCMP) As DESDIVCMP,  " + vbCrLf)
            sql.Append("       D.CODCPR,  " + vbCrLf)
            sql.Append("       D.NOMCPR,  " + vbCrLf)
            sql.Append("       C.CODFRN,  " + vbCrLf)
            sql.Append("       C.NOMFRN,  " + vbCrLf)
            sql.Append("       A.TIPDSNDSCBNFORITRN,  " + vbCrLf)
            sql.Append("       F.DESDSNDSCBNF,  " + vbCrLf)
            sql.Append("       A.TIPALCVBAFRN,  " + vbCrLf)
            sql.Append("       G.DESALCVBAFRN,  " + vbCrLf)
            sql.Append("       A.VLRLMTCTB  " + vbCrLf)
            sql.Append("FROM   MRT.RLCTRNVBAFRN A  " + vbCrLf)
            sql.Append("       INNER JOIN MRT.T0153541 B ON A.CODFRN = B.CODFRN  " + vbCrLf)
            sql.Append("                                AND B.INDCPRPCPFRN = 1  " + vbCrLf)
            sql.Append("       INNER JOIN MRT.T0100426 C ON C.CODFRN = B.CODFRN  " + vbCrLf)
            sql.Append("                                AND C.CODCPR = B.CODCPR  " + vbCrLf)
            sql.Append("                                AND C.DATDSTDIVFRN IS NULL  " + vbCrLf)
            sql.Append("       INNER JOIN MRT.T0113625 D ON B.CODCPR = D.CODCPR  " + vbCrLf)
            sql.Append("       INNER JOIN MRT.T0118570 E ON D.CODGERPRD = E.CODGERPRD  " + vbCrLf)
            sql.Append("       INNER JOIN MRT.T0109059 F ON A.TIPDSNDSCBNFORITRN = F.TIPDSNDSCBNF  " + vbCrLf)
            sql.Append("       INNER JOIN MRT.T0151799 G ON A.TIPALCVBAFRN = G.TIPALCVBAFRN  " + vbCrLf)
            sql.Append("WHERE  A.NUMFLUAPV = " + data.ConvertParameterName("NUMFLUAPV") + vbCrLf)

            Return sql.ToString
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela RLCTRNVBAFRN com base em atributos que não fazem parte da chave primária.
        ''' Descrição da entidade:RELACAO DE TRANSFERENCIA VERBAS FORNECEDOR
        ''' </summary>
        ''' <param name="data">Contexto do banco de dados</param>
        ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
        ''' <param name="NUMFLUAPV">NUMERO FLUXO DE APROVACAO.</param>
        ''' <param name="TIPALCVBAFRN">TIPO DE ALOCACAO DA VERBA DO FORNECEDOR.</param>
        ''' <param name="TIPDSNDSCBNFORITRN">TIPO EMPENHO ORIGEM TRANSFERENCIA VERBA.</param>
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    27/11/2007  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectRelacaoTransferenciaVerbaFornecedor(ByVal data As IData, _
                                                                            ByVal CODFRN As Decimal, _
                                                                            ByVal NUMFLUAPV As Decimal, _
                                                                            ByVal TIPALCVBAFRN As Decimal, _
                                                                            ByVal TIPDSNDSCBNFORITRN As Decimal) As String
            Dim sql As New System.Text.StringBuilder
            Dim clausulaWhere As New System.Text.StringBuilder

            sql.Append("SELECT " + vbCrLf)
            sql.Append("         CODFRN, " + vbCrLf)
            sql.Append("         NUMFLUAPV, " + vbCrLf)
            sql.Append("         TIPALCVBAFRN, " + vbCrLf)
            sql.Append("         TIPDSNDSCBNFORITRN, " + vbCrLf)
            sql.Append("         VLRLMTCTB " + vbCrLf)
            sql.Append("FROM     MRT.RLCTRNVBAFRN " + vbCrLf)

            If CODFRN <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("CODFRN=" + data.ConvertParameterName("CODFRN") + vbCrLf)
            End If
            If NUMFLUAPV <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("NUMFLUAPV=" + data.ConvertParameterName("NUMFLUAPV") + vbCrLf)
            End If
            If TIPALCVBAFRN <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("TIPALCVBAFRN=" + data.ConvertParameterName("TIPALCVBAFRN") + vbCrLf)
            End If
            If TIPDSNDSCBNFORITRN <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("TIPDSNDSCBNFORITRN=" + data.ConvertParameterName("TIPDSNDSCBNFORITRN") + vbCrLf)
            End If

            sql.Append(clausulaWhere)

            Return sql.ToString
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="data"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	12/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectFluxosDeTransferenciaVerbaFornecedor(ByVal data As IData) As String

            Dim sql As New System.Text.StringBuilder

            sql.Append("SELECT   C.CODFNC, " + vbCrLf)
            sql.Append("         C.NOMFNC, " + vbCrLf)
            sql.Append("         Case B.TIPSTAFLUAPV " + vbCrLf)
            sql.Append("              WHEN '1' THEN 'EM APROVAÇÃO' " + vbCrLf)
            sql.Append("              WHEN '2' THEN 'REJEITADO' " + vbCrLf)
            sql.Append("              WHEN '3' THEN 'APROVADO' " + vbCrLf)
            sql.Append("              WHEN '4' THEN 'ESPERA APROVAÇÃO' " + vbCrLf)
            sql.Append("         End AS DESSTAFLUAPV, " + vbCrLf)
            sql.Append("         B.TIPSTAFLUAPV, " + vbCrLf)
            sql.Append("         Case Trunc(B.Dathraapvflu) " + vbCrLf)
            sql.Append("              WHEN To_Date('01/01/0001','DD/MM/YYYY') THEN NULL " + vbCrLf)
            sql.Append("              ELSE B.Dathraapvflu " + vbCrLf)
            sql.Append("         End AS DATHRAAPVFLU, " + vbCrLf)
            sql.Append("         DATHRAFLUAPV, " + vbCrLf)
            sql.Append("         D.NOMFNC AS NOMFNCDELEGADO," + vbCrLf)
            sql.Append("         B.DESOBSAPV, " + vbCrLf)
            sql.Append("         A.INDMESTRNFLU " + vbCrLf)
            sql.Append("FROM     MRT.CADTRNVBAFRN A " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0161591 B ON B.NUMFLUAPV = A.NUMFLUAPV " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0100361 C ON C.CODFNC = B.CODEDEAPV " + vbCrLf)
            sql.Append("         LEFT JOIN MRT.T0100361 D ON D.CODFNC = B.CODEDEARZ" + vbCrLf)
            sql.Append("WHERE    B.CODSISINF = " + Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS.ToString + vbCrLf)
            sql.Append("         AND B.NUMFLUAPV = " + data.ConvertParameterName("NUMFLUAPV") + vbCrLf)
            sql.Append("ORDER BY NUMSEQNIVAPV " + vbCrLf)

            Return sql.ToString
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="data"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Danilo Rafael]	2/6/2009	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectFluxosDeTransferenciaVerbaFornecedorMarketing(ByVal data As IData) As String

            Dim sql As New System.Text.StringBuilder

            sql.Append("SELECT   C.CODFNC, " + vbCrLf)
            sql.Append("         C.NOMFNC, " + vbCrLf)
            sql.Append("         Case B.TIPSTAFLUAPV " + vbCrLf)
            sql.Append("              WHEN '1' THEN 'EM APROVAÇÃO' " + vbCrLf)
            sql.Append("              WHEN '2' THEN 'REJEITADO' " + vbCrLf)
            sql.Append("              WHEN '3' THEN 'APROVADO' " + vbCrLf)
            sql.Append("              WHEN '4' THEN 'ESPERA APROVAÇÃO' " + vbCrLf)
            sql.Append("         End AS DESSTAFLUAPV, " + vbCrLf)
            sql.Append("         B.TIPSTAFLUAPV, " + vbCrLf)
            sql.Append("         Case Trunc(B.Dathraapvflu) " + vbCrLf)
            sql.Append("              WHEN To_Date('01/01/0001','DD/MM/YYYY') THEN NULL " + vbCrLf)
            sql.Append("              ELSE B.Dathraapvflu " + vbCrLf)
            sql.Append("         End AS DATHRAAPVFLU, " + vbCrLf)
            sql.Append("         DATHRAFLUAPV, " + vbCrLf)
            sql.Append("         D.NOMFNC AS NOMFNCDELEGADO," + vbCrLf)
            sql.Append("         B.DESOBSAPV, " + vbCrLf)
            sql.Append("         A.INDMESTRNFLU " + vbCrLf)
            sql.Append("FROM     MRT.CADTRNVBAFRN A " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0161591 B ON B.NUMFLUAPV = A.NUMFLUAPV " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0100361 C ON C.CODFNC = B.CODEDEAPV " + vbCrLf)
            sql.Append("         LEFT JOIN MRT.T0100361 D ON D.CODFNC = B.CODEDEARZ" + vbCrLf)
            sql.Append("WHERE    B.CODSISINF = " + Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS_EMPENHO_MARKETING.ToString + vbCrLf)
            sql.Append("         AND B.NUMFLUAPV = " + data.ConvertParameterName("NUMFLUAPV") + vbCrLf)
            sql.Append("ORDER BY NUMSEQNIVAPV " + vbCrLf)

            Return sql.ToString
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="data"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Danilo Rafael]	20/8/2009	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectFluxosDeTransferenciaVerbaDesoneracaoEResultadoAGF(ByVal data As IData) As String

            Dim sql As New System.Text.StringBuilder

            sql.Append("SELECT   C.CODFNC, " + vbCrLf)
            sql.Append("         C.NOMFNC, " + vbCrLf)
            sql.Append("         Case B.TIPSTAFLUAPV " + vbCrLf)
            sql.Append("              WHEN '1' THEN 'EM APROVAÇÃO' " + vbCrLf)
            sql.Append("              WHEN '2' THEN 'REJEITADO' " + vbCrLf)
            sql.Append("              WHEN '3' THEN 'APROVADO' " + vbCrLf)
            sql.Append("              WHEN '4' THEN 'ESPERA APROVAÇÃO' " + vbCrLf)
            sql.Append("         End AS DESSTAFLUAPV, " + vbCrLf)
            sql.Append("         B.TIPSTAFLUAPV, " + vbCrLf)
            sql.Append("         Case Trunc(B.Dathraapvflu) " + vbCrLf)
            sql.Append("              WHEN To_Date('01/01/0001','DD/MM/YYYY') THEN NULL " + vbCrLf)
            sql.Append("              ELSE B.Dathraapvflu " + vbCrLf)
            sql.Append("         End AS DATHRAAPVFLU, " + vbCrLf)
            sql.Append("         DATHRAFLUAPV, " + vbCrLf)
            sql.Append("         D.NOMFNC AS NOMFNCDELEGADO," + vbCrLf)
            sql.Append("         B.DESOBSAPV, " + vbCrLf)
            sql.Append("         A.INDMESTRNFLU " + vbCrLf)
            sql.Append("FROM     MRT.CADTRNVBAFRN A " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0161591 B ON B.NUMFLUAPV = A.NUMFLUAPV " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0100361 C ON C.CODFNC = B.CODEDEAPV " + vbCrLf)
            sql.Append("         LEFT JOIN MRT.T0100361 D ON D.CODFNC = B.CODEDEARZ" + vbCrLf)
            sql.Append("WHERE    B.CODSISINF = " + Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS_DESONERACAO_E_RESULTADO_AGF.ToString + vbCrLf)
            sql.Append("         AND B.NUMFLUAPV = " + data.ConvertParameterName("NUMFLUAPV") + vbCrLf)
            sql.Append("ORDER BY NUMSEQNIVAPV " + vbCrLf)

            Return sql.ToString
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela T0123159 com base na sua chave primária.
        ''' Descrição da entidade:MOVIMENTO DIARIO RESERVA DE SALDO FORNECEDOR
        ''' </summary>
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    17/12/2007  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectReservaSaldoFornecedor(ByVal data As IData) As String
            Dim sql As String

            sql &= "SELECT " + vbCrLf + _
                   "         CODACOCMC, " + vbCrLf + _
                   "         CODFRN, " + vbCrLf + _
                   "         DATACEACOCMC, " + vbCrLf + _
                   "         DATAPVACOCMC, " + vbCrLf + _
                   "         FLGAPVACOCMC, " + vbCrLf + _
                   "         FLGLMTCNTCRR, " + vbCrLf + _
                   "         TIPACOCMC, " + vbCrLf + _
                   "         TIPDSNDSCBNF, " + vbCrLf + _
                   "         VLRACEACOCMC, " + vbCrLf + _
                   "         VLRACRCAPACOCMC, " + vbCrLf + _
                   "         VLRRLZACOCMC, " + vbCrLf + _
                   "         VLRSLDRSVFRN " + vbCrLf + _
                   "FROM     MRT.T0123159 " + vbCrLf + _
                   "WHERE    CODACOCMC=" + data.ConvertParameterName("CODACOCMC") + vbCrLf + _
                   "         AND CODFRN=" + data.ConvertParameterName("CODFRN") + vbCrLf + _
                   "         AND TIPDSNDSCBNF=" + data.ConvertParameterName("TIPDSNDSCBNF") + vbCrLf + _
                   ""
            Return sql
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela T0123159 com base em atributos que não fazem parte da chave primária.
        ''' Descrição da entidade:MOVIMENTO DIARIO RESERVA DE SALDO FORNECEDOR
        ''' </summary>
        ''' <param name="data">Contexto do banco de dados</param>
        ''' <param name="CODACOCMC">CODIGO DA ACAO COMERCIAL.</param>
        ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
        ''' <param name="DATAPVACOCMC">DATA DE APROVACAO DA ACAO COMERCIAL.</param>
        ''' <param name="DATAPVACOCMCInicial">DATA DE APROVACAO DA ACAO COMERCIAL INICIAL.</param>
        ''' <param name="DATAPVACOCMCFinal">DATA DE APROVACAO DA ACAO COMERCIAL FINAL.</param>
        ''' <param name="TIPDSNDSCBNF">TIPO DESTINO / DESCONTO BONIFICADO.</param>
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    17/12/2007  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectReservaSaldoFornecedor(ByVal data As IData, _
                                                               ByVal CODACOCMC As String, _
                                                               ByVal CODFRN As Decimal, _
                                                               ByVal DATAPVACOCMC As Date, _
                                                               ByVal DATAPVACOCMCInicial As Date, _
                                                               ByVal DATAPVACOCMCFinal As Date, _
                                                               ByVal TIPDSNDSCBNF As Decimal) As String
            Dim sql As String
            Dim clausulaWhere As String

            sql &= "SELECT " + _
                   "         CODACOCMC, " + vbCrLf + _
                   "         CODFRN, " + vbCrLf + _
                   "         DATACEACOCMC, " + vbCrLf + _
                   "         DATAPVACOCMC, " + vbCrLf + _
                   "         FLGAPVACOCMC, " + vbCrLf + _
                   "         FLGLMTCNTCRR, " + vbCrLf + _
                   "         TIPACOCMC, " + vbCrLf + _
                   "         TIPDSNDSCBNF, " + vbCrLf + _
                   "         VLRACEACOCMC, " + vbCrLf + _
                   "         VLRACRCAPACOCMC, " + vbCrLf + _
                   "         VLRRLZACOCMC, " + vbCrLf + _
                   "         VLRSLDRSVFRN " + vbCrLf + _
                   "FROM     MRT.T0123159 " + vbCrLf

            If CODACOCMC.Trim() <> "" Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "Upper(CODACOCMC) Like " + data.ConvertParameterName("CODACOCMC") + vbCrLf
            End If
            If CODFRN <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "CODFRN=" + data.ConvertParameterName("CODFRN") + vbCrLf
            End If
            If DATAPVACOCMC <> Nothing Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "DATAPVACOCMC=" + data.ConvertParameterName("DATAPVACOCMC") + vbCrLf
            End If
            If DATAPVACOCMCInicial <> Nothing And DATAPVACOCMCFinal <> Nothing Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "DATAPVACOCMC Between " + data.ConvertParameterName("DATAPVACOCMCInicial") + " AND " + data.ConvertParameterName("DATAPVACOCMCFinal") + vbCrLf
            End If
            If TIPDSNDSCBNF <> 0 Then
                If clausulaWhere = "" Then
                    clausulaWhere &= "WHERE "
                Else
                    clausulaWhere &= "         And "
                End If
                clausulaWhere &= "TIPDSNDSCBNF=" + data.ConvertParameterName("TIPDSNDSCBNF") + vbCrLf
            End If

            sql &= clausulaWhere

            Return sql
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="data"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	29/11/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectFuncionario(ByVal data As IData) As String
            Dim sql As New System.Text.StringBuilder

            sql.Append("SELECT " + vbCrLf)
            sql.Append("         CODAGEBCOFNC, " + vbCrLf)
            sql.Append("         CODBAIFNC, " + vbCrLf)
            sql.Append("         CODBCOFNC, " + vbCrLf)
            sql.Append("         CODCENCST, " + vbCrLf)
            sql.Append("         CODCEPFNC, " + vbCrLf)
            sql.Append("         CODCGRFNC, " + vbCrLf)
            sql.Append("         CODCID, " + vbCrLf)
            sql.Append("         CODDIV, " + vbCrLf)
            sql.Append("         CODDPT, " + vbCrLf)
            sql.Append("         CODDRT, " + vbCrLf)
            sql.Append("         CODEMP, " + vbCrLf)
            sql.Append("         CODFILEMP, " + vbCrLf)
            sql.Append("         CODFILFNC, " + vbCrLf)
            sql.Append("         CODFNC, " + vbCrLf)
            sql.Append("         CODGRPPGTFNC, " + vbCrLf)
            sql.Append("         CODNIVFNC, " + vbCrLf)
            sql.Append("         CODSEC, " + vbCrLf)
            sql.Append("         CODSETFNC, " + vbCrLf)
            sql.Append("         CODSEXFNC, " + vbCrLf)
            sql.Append("         CODSGMMCDCTB, " + vbCrLf)
            sql.Append("         CODSNDFNC, " + vbCrLf)
            sql.Append("         CODUNDNGC, " + vbCrLf)
            sql.Append("         CODUNDREG, " + vbCrLf)
            sql.Append("         DATADSFNC, " + vbCrLf)
            sql.Append("         DATALTCADFNC, " + vbCrLf)
            sql.Append("         DATDEMFNC, " + vbCrLf)
            sql.Append("         DATNSC, " + vbCrLf)
            sql.Append("         DATPRVDEMFNC, " + vbCrLf)
            sql.Append("         DATVLDCARCCP, " + vbCrLf)
            sql.Append("         DATVLDCARRLP, " + vbCrLf)
            sql.Append("         DESENDCREETNFNC, " + vbCrLf)
            sql.Append("         DESPSWCDF, " + vbCrLf)
            sql.Append("         DESPSWFNCPAD, " + vbCrLf)
            sql.Append("         ENDFNC, " + vbCrLf)
            sql.Append("         INDTRBFNC, " + vbCrLf)
            sql.Append("         NOMFNC, " + vbCrLf)
            sql.Append("         NUMCARCCP, " + vbCrLf)
            sql.Append("         NUMCARRLP, " + vbCrLf)
            sql.Append("         NUMCNTCRRFNC, " + vbCrLf)
            sql.Append("         NUMCPF, " + vbCrLf)
            sql.Append("         NUMCPFFNC, " + vbCrLf)
            sql.Append("         NUMRMLTLF, " + vbCrLf)
            sql.Append("         NUMTLFFNC, " + vbCrLf)
            sql.Append("         TIPFNC " + vbCrLf)
            sql.Append("FROM     MRT.T0100361 ")
            sql.Append("WHERE    CODFNC=" + data.ConvertParameterName("CODFNC") + vbCrLf)

            Return sql.ToString
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="data"></param>
        ''' <param name="parametrosClausulaIn"></param>
        ''' <param name="nomeCampoBanco"></param>
        ''' <param name="nomeParametro"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	21/11/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Shared Function GetClausulaIn(ByVal data As IData, ByVal parametrosClausulaIn() As String, ByVal nomeCampoBanco As String, ByVal nomeParametro As String) As String
            Dim result As New System.Text.StringBuilder
            Dim ParametrosIn As System.Text.StringBuilder

            'Insere os parametros da cláusula In
            If parametrosClausulaIn.Length > 0 Then
                result.Append("             (" & vbCrLf)
                For i As Integer = 0 To parametrosClausulaIn.Length - 1 Step 1000

                    'Se for os primeiros 1000, nesse caso i = 0, não colocao Or, 
                    'caso contrário coloca Or
                    If i = 0 Then
                        result.Append("              " & nomeCampoBanco & " IN (")
                    Else
                        result.Append("              Or " & nomeCampoBanco & " IN (")
                    End If

                    'Limpa o StringBuilder que guarda a cláusula In
                    ParametrosIn = New System.Text.StringBuilder

                    'Vai montando a cláusula In
                    For j As Integer = i To Math.Min(parametrosClausulaIn.Length - 1, i + 999)
                        ParametrosIn.Append(data.ConvertParameterName(nomeParametro + j.ToString()) + ",")
                    Next

                    'Tira a última vírgula da cláusula In
                    ParametrosIn = New System.Text.StringBuilder(ParametrosIn.ToString.Substring(0, ParametrosIn.ToString.LastIndexOf(",")))

                    'Adiciona a cláusula In nos parametros (variável result)
                    result.Append(ParametrosIn.ToString & ")" & vbCrLf)

                Next
                result.Append("          )" & vbCrLf)
            End If

            Return result.ToString
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="data"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	26/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectObterFuncionarioAprovadorDaControladoriaQuandoMesLancamentoForDiferenteDoMesDeAprovacao(ByVal data As IData) As String
            Dim sql As New System.Text.StringBuilder

            sql.Append("SELECT CODFNCAPVFIX " + vbCrLf)
            sql.Append("FROM   MRT.T0161581 " + vbCrLf)
            sql.Append("WHERE  CODSISINF = " + data.ConvertParameterName("CODSISINF") + vbCrLf)
            sql.Append("       AND NUMSEQNIVAPV = " + data.ConvertParameterName("NUMSEQNIVAPV") + vbCrLf)

            Return sql.ToString
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="data"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	9/1/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectCalendarioAnual(ByVal data As IData) As String
            Dim sql As New System.Text.StringBuilder

            sql.Append("SELECT " + vbCrLf)
            sql.Append("         ANOMESREF, " + vbCrLf)
            sql.Append("         DATREF, " + vbCrLf)
            sql.Append("         DATREFSGNDIASMN, " + vbCrLf)
            sql.Append("         DATTRNLMTCTBACEVGM, " + vbCrLf)
            sql.Append("         FLGDIAACEVGMMOT, " + vbCrLf)
            sql.Append("         FLGFATDIA, " + vbCrLf)
            sql.Append("         FLGFRDBCO, " + vbCrLf)
            sql.Append("         FLGFRDEPD, " + vbCrLf)
            sql.Append("         FLGFRDFRMPCO, " + vbCrLf)
            sql.Append("         FLGFRDLEGTRB, " + vbCrLf)
            sql.Append("         FLGFRDNAC, " + vbCrLf)
            sql.Append("         FLGORDPGTREP, " + vbCrLf)
            sql.Append("         INDFRDFOLPGT, " + vbCrLf)
            sql.Append("         MESREF, " + vbCrLf)
            sql.Append("         NUMDIASMN, " + vbCrLf)
            sql.Append("         NUMSMNMES, " + vbCrLf)
            sql.Append("         PERPRVVNDDIA " + vbCrLf)
            sql.Append("FROM     MRT.T0102321 ")
            sql.Append("WHERE    DATREF=" + data.ConvertParameterName("DATREF") + vbCrLf)

            Return sql.ToString
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="data"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Danilo Rafael]	29/5/2009	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectAprovadoresEmpenhoMarketing(ByVal data As IData) As String
            Dim sql As New System.Text.StringBuilder

            sql.Append("SELECT NUMSEQNIVAPV," & vbCrLf)
            sql.Append("       CODFNCAPVFIX" & vbCrLf)
            sql.Append("FROM MRT.T0161581 " & vbCrLf)
            sql.Append("WHERE  CODSISINF = " & data.ConvertParameterName("CODSISINF") & vbCrLf)

            Return sql.ToString
        End Function

#Region "Metados com Stored Procedure"

        Friend Shared Function GetSelectAtualizarContaCorrenteFornecedor() As String
            Dim sql As String
            sql = "MRT.PCTDJAtlCntCrrFrn.PRCDJAtlCntCrrFrn"
            Return sql
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Retorna o select para procedure:MRT.PCTDJRetSldDisFrnCel.PRCDJRetSldDisFrnCel
        ''' LEGADO:spccx025
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[PRETRE21]	27/12/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectObterRelatorioSaldoDisponivelFornecedorCelula() As String
            Return "MRT.PCTDJRetSldDisFrnCel.PRCDJRetSldDisFrnCel"
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Retorna o sql para procedure MRT.PCTDJAtlCntCrrFrn.PRCDJObtNumSeqLmt
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	28/12/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectObterNumeroSequenciaLancamento() As String
            Return "MRT.PCTDJAtlCntCrrFrn.PRCDJObtNumSeqLmt"
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Retorna o sql para procedure MRT.PCTDJObtDrtCmpFrn.PRCDJObtDrtCmpFrn
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	30/12/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectObterDiretoriaEDivisaoDeCompraDeFornecedor() As String
            Return "MRT.PCTDJObtDrtCmpFrn.PRCDJObtDrtCmpFrn"
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Retorna Sql para procedure
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' Procedure legado SQL-SERVER: SPCCX017
        ''' Procedure Migrada Oracle...: PCTDJSelVlrDisFrn.PRCDJSelVlrDisFrn
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	1/11/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectObterSelecaoValorDisponivelFornecedor() As String
            Return "MRT.PCTDJSelVlrDisFrn.PRCDJSelVlrDisFrn"
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Select para obter dados do fornecedor, comprador e divisão de compra
        ''' </summary>
        ''' <param name="data"></param>
        ''' <param name="CODFRN"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	21/11/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectFornecedorCompradorEDivisaoCompra(ByVal data As IData, _
                                                                          ByVal IN_CODFRN As String) As String
            Dim sql As New System.Text.StringBuilder
            Dim IN_CODFRNArray() As String = Split(IN_CODFRN.Trim, ",")

            sql.Append("SELECT DISTINCT " + vbCrLf)
            sql.Append("       B.CODFRN, " + vbCrLf)
            sql.Append("       B.NOMFRN, " + vbCrLf)
            sql.Append("       D.CODDIVCMP, " + vbCrLf)
            sql.Append("       UPPER(D.DESDIVCMP) As DESDIVCMP, " + vbCrLf)
            sql.Append("       C.CODCPR, " + vbCrLf)
            sql.Append("       C.NOMCPR " + vbCrLf)
            sql.Append("FROM   MRT.T0153541 A, " + vbCrLf)
            sql.Append("       MRT.T0100426 B, " + vbCrLf)
            sql.Append("       MRT.T0113625 C, " + vbCrLf)
            sql.Append("       MRT.T0118570 D " + vbCrLf)
            sql.Append("WHERE  A.CODCPR = C.CODCPR " + vbCrLf)
            sql.Append("       AND A.CODFRN = B.CODFRN " + vbCrLf)
            sql.Append("       AND B.DATDSTDIVFRN IS NULL " + vbCrLf)
            sql.Append("       AND C.CODGERPRD = D.CODGERPRD " + vbCrLf)
            sql.Append("       AND " & GetClausulaIn(data, IN_CODFRNArray, "B.CODFRN", "CODFRN") & vbCrLf)

            Return sql.ToString
        End Function

#End Region

    End Class
End Namespace