Imports Martins.Data.TransactionManagement
Imports Martins.Data
Imports Martins.Security.Helper
Imports System.Data.OracleClient

Namespace DAL
    ''' -----------------------------------------------------------------------------
    ''' Project   : Martins.Compras.AcoesComerciais.ContaCorrenteFornecedor
    ''' Class     : ContaCorrenteFornecedorDAL
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Classe DAL da entidade com objetivo: persistir os dados
    ''' </summary>
    ''' <remarks>
    '''
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    21/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class ContaCorrenteFornecedorDAL
        Inherits DALClass

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
                Dim DatasetContaCorrenteFornecedor As DatasetContaCorrenteFornecedor
                Dim data As IData
                Dim sql As String
                
                DatasetContaCorrenteFornecedor = New DatasetContaCorrenteFornecedor
                
                'Desabilita a integridade referencial
                DatasetContaCorrenteFornecedor.EnforceConstraints = False
                
                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = ContaCorrenteFornecedorDALSQL.GetSelectContaCorrenteFornecedor(data)
                data.FillDataSet(DatasetContaCorrenteFornecedor, _
                 sql, _
                 DatasetContaCorrenteFornecedor.T0123086.TableName, _
                 New IDataParameter() { _
                            data.CreateParameter("CODFRN",  DbType.decimal, "CODFRN", CODFRN), _
                            data.CreateParameter("CODGDC",  DbType.String, "CODGDC", CODGDC), _
                            data.CreateParameter("DATREFLMT",  DbType.Date, "DATREFLMT", DATREFLMT), _
                            data.CreateParameter("NUMSEQLMT",  DbType.decimal, "NUMSEQLMT", NUMSEQLMT), _
                            data.CreateParameter("TIPDSNDSCBNF",  DbType.decimal, "TIPDSNDSCBNF", TIPDSNDSCBNF) _
                      })


                Me.SetComplete()
                Return DatasetContaCorrenteFornecedor
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade T0123086 com base na em atributos que geralmente não compoem a chave primária (exceto em chaves compostas).
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
                Dim DatasetContaCorrenteFornecedor As DatasetContaCorrenteFornecedor
                Dim data As IData
                Dim sql As String
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList

                DatasetContaCorrenteFornecedor = New DatasetContaCorrenteFornecedor

                DatasetContaCorrenteFornecedor.EnforceConstraints = False

                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)
                sql = ContaCorrenteFornecedorDALSQL.GetSelectContaCorrenteFornecedor(data, CODCENCSTCRD, CODCENCSTDEB, CODCNTCRD, CODCNTDEB, CODFILEMP, CODFRN, CODGDC, CODPMS, CODTIPLMT, DATREFLMT, DATREFLMTInicial, DATREFLMTFinal, DESHSTLMT, DESVARHSTPAD, NUMSEQLMT, TIPDSNDSCBNF)

                If CODCENCSTCRD.Trim() <> "" Then 
                    paramNome = data.CreateParameter("CODCENCSTCRD", DbType.String, "CODCENCSTCRD", "%" + CODCENCSTCRD.ToUpper() + "%" )
                    If (Not IsNothing(paramNome)) Then parametros.Add (paramNome)
                End If
                If CODCENCSTDEB.Trim() <> "" Then 
                    paramNome = data.CreateParameter("CODCENCSTDEB", DbType.String, "CODCENCSTDEB", "%" + CODCENCSTDEB.ToUpper() + "%" )
                    If (Not IsNothing(paramNome)) Then parametros.Add (paramNome)
                End If
                If CODCNTCRD.Trim() <> "" Then 
                    paramNome = data.CreateParameter("CODCNTCRD", DbType.String, "CODCNTCRD", "%" + CODCNTCRD.ToUpper() + "%" )
                    If (Not IsNothing(paramNome)) Then parametros.Add (paramNome)
                End If
                If CODCNTDEB.Trim() <> "" Then 
                    paramNome = data.CreateParameter("CODCNTDEB", DbType.String, "CODCNTDEB", "%" + CODCNTDEB.ToUpper() + "%" )
                    If (Not IsNothing(paramNome)) Then parametros.Add (paramNome)
                End If
                If CODFILEMP <> 0 Then
                    paramNome = data.CreateParameter("CODFILEMP", DbType.Decimal, "CODFILEMP", CODFILEMP)
                    If (Not IsNothing(paramNome)) Then parametros.Add (paramNome)
                End If
                If CODFRN <> 0 Then
                    paramNome = data.CreateParameter("CODFRN", DbType.Decimal, "CODFRN", CODFRN)
                    If (Not IsNothing(paramNome)) Then parametros.Add (paramNome)
                End If
                If CODGDC.Trim() <> "" Then 
                    paramNome = data.CreateParameter("CODGDC", DbType.String, "CODGDC", "%" + CODGDC.ToUpper() + "%" )
                    If (Not IsNothing(paramNome)) Then parametros.Add (paramNome)
                End If
                If CODPMS <> 0 Then
                    paramNome = data.CreateParameter("CODPMS", DbType.Decimal, "CODPMS", CODPMS)
                    If (Not IsNothing(paramNome)) Then parametros.Add (paramNome)
                End If
                If CODTIPLMT <> 0 Then
                    paramNome = data.CreateParameter("CODTIPLMT", DbType.Decimal, "CODTIPLMT", CODTIPLMT)
                    If (Not IsNothing(paramNome)) Then parametros.Add (paramNome)
                End If
                If DATREFLMT <> Nothing Then
                    paramNome = data.CreateParameter("DATREFLMT", DbType.Date, "DATREFLMT", DATREFLMT)
                    If (Not IsNothing(paramNome)) Then parametros.Add (paramNome)
                End If
                If DATREFLMTInicial <> Nothing And DATREFLMTFinal <> Nothing Then
                    paramNome = data.CreateParameter("DATREFLMTInicial", DbType.Date, "DATREFLMT", DATREFLMTInicial)
                    If (Not IsNothing(paramNome)) Then parametros.Add (paramNome)
                    paramNome = data.CreateParameter("DATREFLMTFinal", DbType.Date, "DATREFLMT", DATREFLMTFinal)
                    If (Not IsNothing(paramNome)) Then parametros.Add (paramNome)
                End If
                If DESHSTLMT.Trim() <> "" Then 
                    paramNome = data.CreateParameter("DESHSTLMT", DbType.String, "DESHSTLMT", "%" + DESHSTLMT.ToUpper() + "%" )
                    If (Not IsNothing(paramNome)) Then parametros.Add (paramNome)
                End If
                If DESVARHSTPAD.Trim() <> "" Then 
                    paramNome = data.CreateParameter("DESVARHSTPAD", DbType.String, "DESVARHSTPAD", "%" + DESVARHSTPAD.ToUpper() + "%" )
                    If (Not IsNothing(paramNome)) Then parametros.Add (paramNome)
                End If
                If NUMSEQLMT <> 0 Then
                    paramNome = data.CreateParameter("NUMSEQLMT", DbType.Decimal, "NUMSEQLMT", NUMSEQLMT)
                    If (Not IsNothing(paramNome)) Then parametros.Add (paramNome)
                End If
                If TIPDSNDSCBNF <> 0 Then
                    paramNome = data.CreateParameter("TIPDSNDSCBNF", DbType.Decimal, "TIPDSNDSCBNF", TIPDSNDSCBNF)
                    If (Not IsNothing(paramNome)) Then parametros.Add (paramNome)
                End If

                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo (parametrosCommand)

                data.FillDataSet(DatasetContaCorrenteFornecedor, _
                 sql, _
                 DatasetContaCorrenteFornecedor.T0123086.TableName, _
                 parametrosCommand)

                Me.SetComplete()
                Return DatasetContaCorrenteFornecedor
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade T0123086 com base na em atributos que geralmente não compoem a chave primária (exceto em chaves compostas).
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
        Public Function ObterFornecedoresDeContasCorrenteFornecedor(ByRef DatasetContaCorrenteFornecedor As DatasetContaCorrenteFornecedor, _
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
                                                                    ByVal TIPDSNDSCBNF As Decimal) As DatasetContaCorrenteFornecedor
            Try
                Dim data As IData
                Dim sql As String
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList

                DatasetContaCorrenteFornecedor.EnforceConstraints = False

                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)
                sql = ContaCorrenteFornecedorDALSQL.GetSelectFornecedorDeContaCorrenteFornecedor(data, CODCENCSTCRD, CODCENCSTDEB, CODCNTCRD, CODCNTDEB, CODFILEMP, CODFRN, CODGDC, CODPMS, CODTIPLMT, DATREFLMT, DATREFLMTInicial, DATREFLMTFinal, DESHSTLMT, DESVARHSTPAD, NUMSEQLMT, TIPDSNDSCBNF)

                If CODCENCSTCRD.Trim() <> "" Then
                    paramNome = data.CreateParameter("CODCENCSTCRD", DbType.String, "CODCENCSTCRD", "%" + CODCENCSTCRD.ToUpper() + "%")
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODCENCSTDEB.Trim() <> "" Then
                    paramNome = data.CreateParameter("CODCENCSTDEB", DbType.String, "CODCENCSTDEB", "%" + CODCENCSTDEB.ToUpper() + "%")
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODCNTCRD.Trim() <> "" Then
                    paramNome = data.CreateParameter("CODCNTCRD", DbType.String, "CODCNTCRD", "%" + CODCNTCRD.ToUpper() + "%")
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODCNTDEB.Trim() <> "" Then
                    paramNome = data.CreateParameter("CODCNTDEB", DbType.String, "CODCNTDEB", "%" + CODCNTDEB.ToUpper() + "%")
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODFILEMP <> 0 Then
                    paramNome = data.CreateParameter("CODFILEMP", DbType.Decimal, "CODFILEMP", CODFILEMP)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODFRN <> 0 Then
                    paramNome = data.CreateParameter("CODFRN", DbType.Decimal, "CODFRN", CODFRN)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODGDC.Trim() <> "" Then
                    paramNome = data.CreateParameter("CODGDC", DbType.String, "CODGDC", "%" + CODGDC.ToUpper() + "%")
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODPMS <> 0 Then
                    paramNome = data.CreateParameter("CODPMS", DbType.Decimal, "CODPMS", CODPMS)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODTIPLMT <> 0 Then
                    paramNome = data.CreateParameter("CODTIPLMT", DbType.Decimal, "CODTIPLMT", CODTIPLMT)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If DATREFLMT <> Nothing Then
                    paramNome = data.CreateParameter("DATREFLMT", DbType.Date, "DATREFLMT", DATREFLMT)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If DATREFLMTInicial <> Nothing And DATREFLMTFinal <> Nothing Then
                    paramNome = data.CreateParameter("DATREFLMTInicial", DbType.Date, "DATREFLMT", DATREFLMTInicial)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                    paramNome = data.CreateParameter("DATREFLMTFinal", DbType.Date, "DATREFLMT", DATREFLMTFinal)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If DESHSTLMT.Trim() <> "" Then
                    paramNome = data.CreateParameter("DESHSTLMT", DbType.String, "DESHSTLMT", "%" + DESHSTLMT.ToUpper() + "%")
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If DESVARHSTPAD.Trim() <> "" Then
                    paramNome = data.CreateParameter("DESVARHSTPAD", DbType.String, "DESVARHSTPAD", "%" + DESVARHSTPAD.ToUpper() + "%")
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If NUMSEQLMT <> 0 Then
                    paramNome = data.CreateParameter("NUMSEQLMT", DbType.Decimal, "NUMSEQLMT", NUMSEQLMT)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If TIPDSNDSCBNF <> 0 Then
                    paramNome = data.CreateParameter("TIPDSNDSCBNF", DbType.Decimal, "TIPDSNDSCBNF", TIPDSNDSCBNF)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo(parametrosCommand)

                data.FillDataSet(DatasetContaCorrenteFornecedor, _
                 sql, _
                 DatasetContaCorrenteFornecedor.T0100426.TableName, _
                 parametrosCommand)

                Me.SetComplete()
                Return DatasetContaCorrenteFornecedor
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
                Dim DatasetParametroContabilContaCorrenteFornecedor As DatasetParametroContabilContaCorrenteFornecedor
                Dim data As IData
                Dim sql As String

                DatasetParametroContabilContaCorrenteFornecedor = New DatasetParametroContabilContaCorrenteFornecedor

                'Desabilita a integridade referencial
                DatasetParametroContabilContaCorrenteFornecedor.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = ContaCorrenteFornecedorDALSQL.GetSelectParametroContabilContaCorrenteFornecedor(data)
                data.FillDataSet(DatasetParametroContabilContaCorrenteFornecedor, _
                 sql, _
                 DatasetParametroContabilContaCorrenteFornecedor.T0123094.TableName, _
                 New IDataParameter() { _
                            data.CreateParameter("CODFILEMP", DbType.Decimal, "CODFILEMP", CODFILEMP), _
                            data.CreateParameter("CODTIPLMT", DbType.Decimal, "CODTIPLMT", CODTIPLMT) _
                      })


                Me.SetComplete()
                Return DatasetParametroContabilContaCorrenteFornecedor
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade T0123094 com base na em atributos que geralmente não compoem a chave primária (exceto em chaves compostas).
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
                Dim DatasetParametroContabilContaCorrenteFornecedor As DatasetParametroContabilContaCorrenteFornecedor
                Dim data As IData
                Dim sql As String
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList

                DatasetParametroContabilContaCorrenteFornecedor = New DatasetParametroContabilContaCorrenteFornecedor

                DatasetParametroContabilContaCorrenteFornecedor.EnforceConstraints = False

                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)
                sql = ContaCorrenteFornecedorDALSQL.GetSelectParametroContabilContaCorrenteFornecedor(data, CODCENCSTCRD, CODCENCSTDEB, CODCNTCRD, CODCNTDEB, CODEVTCTB, CODEVTCTBFRTDVL, CODEVTCTBNGCDVL, CODFILEMP, CODFTOCTB, CODFTOCTBFRTDVL, CODFTOCTBNGCDVL, CODHSTPAD, CODTIPLMT)

                If CODCENCSTCRD.Trim() <> "" Then
                    paramNome = data.CreateParameter("CODCENCSTCRD", DbType.String, "CODCENCSTCRD", "%" + CODCENCSTCRD.ToUpper() + "%")
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODCENCSTDEB.Trim() <> "" Then
                    paramNome = data.CreateParameter("CODCENCSTDEB", DbType.String, "CODCENCSTDEB", "%" + CODCENCSTDEB.ToUpper() + "%")
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODCNTCRD.Trim() <> "" Then
                    paramNome = data.CreateParameter("CODCNTCRD", DbType.String, "CODCNTCRD", "%" + CODCNTCRD.ToUpper() + "%")
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODCNTDEB.Trim() <> "" Then
                    paramNome = data.CreateParameter("CODCNTDEB", DbType.String, "CODCNTDEB", "%" + CODCNTDEB.ToUpper() + "%")
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODEVTCTB <> 0 Then
                    paramNome = data.CreateParameter("CODEVTCTB", DbType.Decimal, "CODEVTCTB", CODEVTCTB)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODEVTCTBFRTDVL <> 0 Then
                    paramNome = data.CreateParameter("CODEVTCTBFRTDVL", DbType.Decimal, "CODEVTCTBFRTDVL", CODEVTCTBFRTDVL)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODEVTCTBNGCDVL <> 0 Then
                    paramNome = data.CreateParameter("CODEVTCTBNGCDVL", DbType.Decimal, "CODEVTCTBNGCDVL", CODEVTCTBNGCDVL)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODFILEMP <> 0 Then
                    paramNome = data.CreateParameter("CODFILEMP", DbType.Decimal, "CODFILEMP", CODFILEMP)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODFTOCTB <> 0 Then
                    paramNome = data.CreateParameter("CODFTOCTB", DbType.Decimal, "CODFTOCTB", CODFTOCTB)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODFTOCTBFRTDVL <> 0 Then
                    paramNome = data.CreateParameter("CODFTOCTBFRTDVL", DbType.Decimal, "CODFTOCTBFRTDVL", CODFTOCTBFRTDVL)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODFTOCTBNGCDVL <> 0 Then
                    paramNome = data.CreateParameter("CODFTOCTBNGCDVL", DbType.Decimal, "CODFTOCTBNGCDVL", CODFTOCTBNGCDVL)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODHSTPAD.Trim() <> "" Then
                    paramNome = data.CreateParameter("CODHSTPAD", DbType.String, "CODHSTPAD", "%" + CODHSTPAD.ToUpper() + "%")
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODTIPLMT <> 0 Then
                    paramNome = data.CreateParameter("CODTIPLMT", DbType.Decimal, "CODTIPLMT", CODTIPLMT)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo(parametrosCommand)

                data.FillDataSet(DatasetParametroContabilContaCorrenteFornecedor, _
                 sql, _
                 DatasetParametroContabilContaCorrenteFornecedor.T0123094.TableName, _
                 parametrosCommand)

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
                Dim data As IData
                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)

                Dim cb1 As CustomCommandBuilder
                cb1 = New CustomCommandBuilder(DatasetParametroContabilContaCorrenteFornecedor.T0123094, data, "MRT.T0123094")
                data.UpdateFromDataSet(DatasetParametroContabilContaCorrenteFornecedor.T0123094, _
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
                Dim DatasetTipoLancamentoContaCorrenteFornecedor As DatasetTipoLancamentoContaCorrenteFornecedor
                Dim data As IData
                Dim sql As String

                DatasetTipoLancamentoContaCorrenteFornecedor = New DatasetTipoLancamentoContaCorrenteFornecedor

                'Desabilita a integridade referencial
                DatasetTipoLancamentoContaCorrenteFornecedor.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = ContaCorrenteFornecedorDALSQL.GetSelectTipoLancamentoContaCorrenteFornecedor(data)
                data.FillDataSet(DatasetTipoLancamentoContaCorrenteFornecedor, _
                 sql, _
                 DatasetTipoLancamentoContaCorrenteFornecedor.T0123108.TableName, _
                 New IDataParameter() { _
                            data.CreateParameter("CODTIPLMT", DbType.Decimal, "CODTIPLMT", CODTIPLMT) _
                      })

                ''Popula tabela relacionada T0123094 (PARAMETRO CONTABIL CONTA CORRENTE FORNECEDOR)
                'sql = ContaCorrenteFornecedorDALSQL.GetSelectParametroContabilContaCorrenteFornecedor(data)
                'data.FillDataSet(DatasetTipoLancamentoContaCorrenteFornecedor, _
                ' sql, _
                ' DatasetTipoLancamentoContaCorrenteFornecedor.T0123094.TableName, _
                ' New IDataParameter() { _
                '            data.CreateParameter("CODFILEMP", DbType.Decimal, "CODFILEMP", Decimal.Parse("1")), _
                '            data.CreateParameter("CODTIPLMT", DbType.Decimal, "CODTIPLMT", CODTIPLMT) _
                '      })

                ''Popula tabela relacionada T0123108_Associada (Esse dataset tem um relacionado para a mesma tabela)
                'sql = ContaCorrenteFornecedorDALSQL.GetSelectTipoLancamentoContaCorrenteFornecedor(data)
                'data.FillDataSet(DatasetTipoLancamentoContaCorrenteFornecedor, _
                ' sql, _
                ' DatasetTipoLancamentoContaCorrenteFornecedor.T0123094.TableName, _
                ' New IDataParameter() { _
                '            data.CreateParameter("CODFILEMP", DbType.Decimal, "CODFILEMP", Decimal.Parse("1")), _
                '            data.CreateParameter("CODTIPLMT", DbType.Decimal, "CODTIPLMT", CODTIPLMT) _
                '      })

                Me.SetComplete()
                Return DatasetTipoLancamentoContaCorrenteFornecedor
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade T0123108 com base na em atributos que geralmente não compoem a chave primária (exceto em chaves compostas).
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
                Dim DatasetTipoLancamentoContaCorrenteFornecedor As DatasetTipoLancamentoContaCorrenteFornecedor
                Dim data As IData
                Dim sql As String
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList

                DatasetTipoLancamentoContaCorrenteFornecedor = New DatasetTipoLancamentoContaCorrenteFornecedor

                DatasetTipoLancamentoContaCorrenteFornecedor.EnforceConstraints = False

                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)
                sql = ContaCorrenteFornecedorDALSQL.GetSelectTipoLancamentoContaCorrenteFornecedor(data, DESTIPLMT, DESTIPLMTFRN)

                If DESTIPLMT.Trim() <> "" Then
                    paramNome = data.CreateParameter("DESTIPLMT", DbType.String, "DESTIPLMT", "%" + DESTIPLMT.ToUpper() + "%")
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If DESTIPLMTFRN.Trim() <> "" Then
                    paramNome = data.CreateParameter("DESTIPLMTFRN", DbType.String, "DESTIPLMTFRN", "%" + DESTIPLMTFRN.ToUpper() + "%")
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo(parametrosCommand)

                data.FillDataSet(DatasetTipoLancamentoContaCorrenteFornecedor, _
                 sql, _
                 DatasetTipoLancamentoContaCorrenteFornecedor.T0123108.TableName, _
                 parametrosCommand)

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
                Dim DatasetTipoLancamentoContaCorrenteFornecedor As DatasetTipoLancamentoContaCorrenteFornecedor
                Dim data As IData
                Dim sql As String
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList

                DatasetTipoLancamentoContaCorrenteFornecedor = New DatasetTipoLancamentoContaCorrenteFornecedor

                DatasetTipoLancamentoContaCorrenteFornecedor.EnforceConstraints = False

                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)
                sql = ContaCorrenteFornecedorDALSQL.GetSelectTipoLancamentoPrincipalXTipoLancamentoAssociado(data, CODTIPLMTASC, CODTIPLMTPCP)

                If CODTIPLMTASC <> 0 Then
                    paramNome = data.CreateParameter("CODTIPLMTASC", DbType.Decimal, "CODTIPLMTASC", CODTIPLMTASC)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODTIPLMTPCP <> 0 Then
                    paramNome = data.CreateParameter("CODTIPLMTPCP", DbType.Decimal, "CODTIPLMTPCP", CODTIPLMTPCP)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo(parametrosCommand)

                data.FillDataSet(DatasetTipoLancamentoContaCorrenteFornecedor, _
                 sql, _
                 DatasetTipoLancamentoContaCorrenteFornecedor.T0162251.TableName, _
                 parametrosCommand)

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
                Dim data As IData
                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)

                Dim cb1 As CustomCommandBuilder
                cb1 = New CustomCommandBuilder(DatasetTipoLancamentoContaCorrenteFornecedor.T0123108, data, "MRT.T0123108")
                data.UpdateFromDataSet(DatasetTipoLancamentoContaCorrenteFornecedor.T0123108, _
                 cb1.FastInsertCommand, _
                 cb1.FastUpdateCommand, _
                 cb1.FastDeleteCommand)

                Dim cb2 As CustomCommandBuilder
                cb2 = New CustomCommandBuilder(DatasetTipoLancamentoContaCorrenteFornecedor.T0123094, data, "MRT.T0123094")
                data.UpdateFromDataSet(DatasetTipoLancamentoContaCorrenteFornecedor.T0123094, _
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
        ''' Retorna a próxima chave disponível no banco para a tabelaT0123108
        ''' Descrição da tabela: CADASTRO TIPO LANCAMENTO CONTA CORRENTE FORNECEDOR.
        ''' </summary>
        ''' <returns>Código da próxima chave disponível</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    21/07/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterNovaChaveTipoLancamentoContaCorrenteFornecedor() As Decimal
            Try
                Dim result As Decimal
                result = Convert.ToDecimal(Me.transactionContext(Constants.CONEXAO_PRINCIPAL).GetNextPrimaryKey("MRT.T0123108", "CODTIPLMT"))
                Me.SetComplete()
                Return result
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
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
                Dim data As IData
                Dim sql As String
                Dim retorno As Integer
                Dim result As Boolean

                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)

                sql = ContaCorrenteFornecedorDALSQL.GetSelectFornecedorPertenceCelulaAtendidaUsuario(data)

                retorno = Convert.ToInt32(data.ExecuteScalar(sql, _
                                       New IDataParameter() {data.CreateParameter("CODFRN", DbType.Decimal, "CODFRN", CODFRN), _
                                                             data.CreateParameter("NOMACSUSRSIS", DbType.String, "NOMACSUSRSIS", NOMACSUSRSIS.ToUpper.Trim) _
                                                            }))

                Me.SetComplete()

                If retorno = 0 Then
                    If CODFRN = 9240 Then
                        result = FornecedorPertenceCelulaAtendidaUsuarioExcecao1(NOMACSUSRSIS)
                    Else
                        result = False
                    End If
                Else
                    result = True
                End If

                Return result
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Retorna verdadeiro se o fornecedor pertence a celula atendida pelo usuário,
        ''' exeção criada para atender um caso específico
        ''' </summary>
        ''' <param name="CODFRN"></param>
        ''' <param name="NOMACSUSRSIS"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	20/3/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Function FornecedorPertenceCelulaAtendidaUsuarioExcecao1(ByVal NOMACSUSRSIS As String) As Boolean
            Try
                Dim data As IData
                Dim sql As String
                Dim retorno As Integer
                Dim result As Boolean

                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)

                sql = ContaCorrenteFornecedorDALSQL.GetSelectFornecedorPertenceCelulaAtendidaUsuarioExcecao1(data)

                retorno = Convert.ToInt32(data.ExecuteScalar(sql, _
                                       New IDataParameter() {data.CreateParameter("NOMACSUSRSIS", DbType.String, "NOMACSUSRSIS", NOMACSUSRSIS.ToUpper.Trim) _
                                                            }))
                Me.SetComplete()

                If retorno = 0 Then
                    result = False
                Else
                    result = True
                End If

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
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	29/11/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterNovaChaveTransferenciaVerba() As Decimal
            Try
                Dim chave As Decimal = Convert.ToDecimal(Me.transactionContext(Constants.CONEXAO_PRINCIPAL).GetNextPrimaryKey("MRT.CADTRNVBAFRN", "NUMFLUAPV"))
                If chave = 0 Then chave = 1
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
                Dim DatasetFuncionario As DatasetFuncionario
                Dim data As IData
                Dim sql As String

                DatasetFuncionario = New DatasetFuncionario

                'Desabilita a integridade referencial
                DatasetFuncionario.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = ContaCorrenteFornecedorDALSQL.GetSelectFuncionario(data)
                data.FillDataSet(DatasetFuncionario, _
                 sql, _
                 DatasetFuncionario.T0100361.TableName, _
                 New IDataParameter() { _
                            data.CreateParameter("CODFNC", DbType.Decimal, "CODFNC", CODFNC) _
                      })


                Me.SetComplete()
                Return DatasetFuncionario
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
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                Dim data As IData
                Dim sql As String

                DatasetTransferenciaVerbaFornecedor = New DatasetTransferenciaVerbaFornecedor

                'Desabilita a integridade referencial
                DatasetTransferenciaVerbaFornecedor.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = ContaCorrenteFornecedorDALSQL.GetSelectTransferenciaVerbaFornecedor(data)
                data.FillDataSet(DatasetTransferenciaVerbaFornecedor, _
                 sql, _
                 DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRN.TableName, _
                 New IDataParameter() { _
                            data.CreateParameter("NUMFLUAPV", DbType.Decimal, "NUMFLUAPV", NUMFLUAPV) _
                      })


                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade CADTRNVBAFRN com base na em atributos que geralmente não compoem a chave primária (exceto em chaves compostas).
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
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                Dim data As IData
                Dim sql As String
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList

                DatasetTransferenciaVerbaFornecedor = New DatasetTransferenciaVerbaFornecedor

                DatasetTransferenciaVerbaFornecedor.EnforceConstraints = False

                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)
                sql = ContaCorrenteFornecedorDALSQL.GetSelectTransferenciaVerbaFornecedor(data, CODFNC, DESJSTTRNVBA, NUMFLUAPV, TIPALCVBAFRN, TIPDSNDSCBNFDSNTRN, TIPSTAFLUAPV)

                If CODFNC <> 0 Then
                    paramNome = data.CreateParameter("CODFNC", DbType.Decimal, "CODFNC", CODFNC)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If DESJSTTRNVBA.Trim() <> "" Then
                    paramNome = data.CreateParameter("DESJSTTRNVBA", DbType.String, "DESJSTTRNVBA", "%" + DESJSTTRNVBA.ToUpper() + "%")
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If NUMFLUAPV <> 0 Then
                    paramNome = data.CreateParameter("NUMFLUAPV", DbType.Decimal, "NUMFLUAPV", NUMFLUAPV)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If TIPALCVBAFRN <> 0 Then
                    paramNome = data.CreateParameter("TIPALCVBAFRN", DbType.Decimal, "TIPALCVBAFRN", TIPALCVBAFRN)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If TIPDSNDSCBNFDSNTRN <> 0 Then
                    paramNome = data.CreateParameter("TIPDSNDSCBNFDSNTRN", DbType.Decimal, "TIPDSNDSCBNFDSNTRN", TIPDSNDSCBNFDSNTRN)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If TIPSTAFLUAPV.Trim() <> "" Then
                    paramNome = data.CreateParameter("TIPSTAFLUAPV", DbType.String, "TIPSTAFLUAPV", "%" + TIPSTAFLUAPV.ToUpper() + "%")
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo(parametrosCommand)

                data.FillDataSet(DatasetTransferenciaVerbaFornecedor, _
                                 sql, _
                                 DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRN.TableName, _
                                 parametrosCommand)

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
                Dim data As IData
                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)

                Dim cb1 As CustomCommandBuilder
                cb1 = New CustomCommandBuilder(DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRN, data, "MRT.CADTRNVBAFRN")
                data.UpdateFromDataSet(DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRN, _
                                       cb1.FastInsertCommand, _
                                       cb1.FastUpdateCommand, _
                                       cb1.FastDeleteCommand)

                Dim cb2 As CustomCommandBuilder
                cb2 = New CustomCommandBuilder(DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRN, data, "MRT.RLCTRNVBAFRN")
                data.UpdateFromDataSet(DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRN, _
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
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                Dim data As IData
                Dim sql As String

                DatasetTransferenciaVerbaFornecedor = New DatasetTransferenciaVerbaFornecedor

                'Desabilita a integridade referencial
                DatasetTransferenciaVerbaFornecedor.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = ContaCorrenteFornecedorDALSQL.GetSelectRelacaoTransferenciaVerbaFornecedor(data)
                data.FillDataSet(DatasetTransferenciaVerbaFornecedor, _
                 sql, _
                 DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRN.TableName, _
                 New IDataParameter() { _
                            data.CreateParameter("CODFRN", DbType.Decimal, "CODFRN", CODFRN), _
                            data.CreateParameter("NUMFLUAPV", DbType.Decimal, "NUMFLUAPV", NUMFLUAPV), _
                            data.CreateParameter("TIPALCVBAFRN", DbType.Decimal, "TIPALCVBAFRN", TIPALCVBAFRN), _
                            data.CreateParameter("TIPDSNDSCBNFORITRN", DbType.Decimal, "TIPDSNDSCBNFORITRN", TIPDSNDSCBNFORITRN) _
                      })


                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade RLCTRNVBAFRN com base na em atributos que geralmente não compoem a chave primária (exceto em chaves compostas).
        ''' Descrição da entidade:RELACAO DE TRANSFERENCIA VERBAS FORNECEDOR
        ''' </summary>
        ''' <param name="NUMFLUAPV">NUMERO FLUXO DE APROVACAO.</param>
        ''' <param name="CODFNC">CODIGO FUNCIONARIO.</param>
        ''' <param name="TIPSTAFLUAPV">TIPO STATUS FLUXO APROVACAO.</param>
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
        Public Function ObterTransferenciaSVerbaFornecedorjoin(ByVal NUMFLUAPV As Decimal, _
                                                               ByVal CODFNC As Decimal, _
                                                               ByVal TIPSTAFLUAPV As String) As DatasetTransferenciaVerbaFornecedor
            Try
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                Dim data As IData
                Dim sql As String
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList

                DatasetTransferenciaVerbaFornecedor = New DatasetTransferenciaVerbaFornecedor

                DatasetTransferenciaVerbaFornecedor.EnforceConstraints = False

                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)
                sql = ContaCorrenteFornecedorDALSQL.GetSelectRelacaoTransferenciaVerbaFornecedorJoin(data, NUMFLUAPV, CODFNC, TIPSTAFLUAPV)

                If NUMFLUAPV <> 0 Then
                    paramNome = data.CreateParameter("NUMFLUAPV", DbType.Decimal, "NUMFLUAPV", NUMFLUAPV)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                If CODFNC <> 0 Then
                    'CODEDEAPV1
                    paramNome = data.CreateParameter("CODEDEAPV1", DbType.Decimal, "CODEDEAPV", CODFNC)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                    'CODEDEAPV2
                    paramNome = data.CreateParameter("CODEDEAPV2", DbType.Decimal, "CODEDEAPV", CODFNC)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                If TIPSTAFLUAPV.Trim() <> "" Then
                    paramNome = data.CreateParameter("TIPSTAFLUAPV", DbType.String, "TIPSTAFLUAPV", TIPSTAFLUAPV)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo(parametrosCommand)

                data.FillDataSet(DatasetTransferenciaVerbaFornecedor, _
                                 sql, _
                                 DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNJOIN.TableName, _
                                 parametrosCommand)

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
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                Dim data As IData
                Dim sql As String
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList

                DatasetTransferenciaVerbaFornecedor = New DatasetTransferenciaVerbaFornecedor

                DatasetTransferenciaVerbaFornecedor.EnforceConstraints = False

                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)
                sql = ContaCorrenteFornecedorDALSQL.GetSelectMinhasAprovavoesEmTransferenciaVerbasFornecedor(data, NUMFLUAPV, CODFNC)

                'CODEDEAPV1
                paramNome = data.CreateParameter("CODEDEAPV1", DbType.Decimal, "CODEDEAPV", CODFNC)
                If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)

                'CODEDEAPV2
                paramNome = data.CreateParameter("CODEDEAPV2", DbType.Decimal, "CODEDEAPV", CODFNC)
                If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)

                If NUMFLUAPV <> 0 Then
                    paramNome = data.CreateParameter("NUMFLUAPV", DbType.Decimal, "NUMFLUAPV", NUMFLUAPV)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo(parametrosCommand)

                data.FillDataSet(DatasetTransferenciaVerbaFornecedor, _
                                 sql, _
                                 DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNJOIN.TableName, _
                                 parametrosCommand)

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
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                Dim data As IData
                Dim sql As String

                DatasetTransferenciaVerbaFornecedor = New DatasetTransferenciaVerbaFornecedor

                'Desabilita a integridade referencial
                DatasetTransferenciaVerbaFornecedor.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = ContaCorrenteFornecedorDALSQL.GetSelectRelacaoTransferenciaVerbaFornecedorJoinT0153541JoinT0100426JoinT0113625JoinT0118570JoinT0109059(data)
                data.FillDataSet(DatasetTransferenciaVerbaFornecedor, _
                                 sql, _
                                 DatasetTransferenciaVerbaFornecedor.QueryRLCTRNVBAFRN.TableName, _
                                 New IDataParameter() { _
                                     data.CreateParameter("NUMFLUAPV", DbType.Decimal, "NUMFLUAPV", NUMFLUAPV) _
                                 })

                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade RLCTRNVBAFRN com base na em atributos que geralmente não compoem a chave primária (exceto em chaves compostas).
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
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                Dim data As IData
                Dim sql As String
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList

                DatasetTransferenciaVerbaFornecedor = New DatasetTransferenciaVerbaFornecedor

                DatasetTransferenciaVerbaFornecedor.EnforceConstraints = False

                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)
                sql = ContaCorrenteFornecedorDALSQL.GetSelectRelacaoTransferenciaVerbaFornecedor(data, CODFRN, NUMFLUAPV, TIPALCVBAFRN, TIPDSNDSCBNFORITRN)

                If CODFRN <> 0 Then
                    paramNome = data.CreateParameter("CODFRN", DbType.Decimal, "CODFRN", CODFRN)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If NUMFLUAPV <> 0 Then
                    paramNome = data.CreateParameter("NUMFLUAPV", DbType.Decimal, "NUMFLUAPV", NUMFLUAPV)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If TIPALCVBAFRN <> 0 Then
                    paramNome = data.CreateParameter("TIPALCVBAFRN", DbType.Decimal, "TIPALCVBAFRN", TIPALCVBAFRN)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If TIPDSNDSCBNFORITRN <> 0 Then
                    paramNome = data.CreateParameter("TIPDSNDSCBNFORITRN", DbType.Decimal, "TIPDSNDSCBNFORITRN", TIPDSNDSCBNFORITRN)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo(parametrosCommand)

                data.FillDataSet(DatasetTransferenciaVerbaFornecedor, _
                                 sql, _
                                 DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRN.TableName, _
                                 parametrosCommand)

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
                Dim data As IData
                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)

                Dim cb1 As CustomCommandBuilder
                cb1 = New CustomCommandBuilder(DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRN, data, "MRT.RLCTRNVBAFRN")
                data.UpdateFromDataSet(DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRN, _
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
        ''' 	[Marcos Queiroz]	12/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterFluxosDeTransferenciaVerbaFornecedor(ByVal NUMFLUAPV As Decimal) As DatasetTransferenciaVerbaFornecedor
            Try
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                Dim data As IData
                Dim sql As String

                DatasetTransferenciaVerbaFornecedor = New DatasetTransferenciaVerbaFornecedor

                'Desabilita a integridade referencial
                DatasetTransferenciaVerbaFornecedor.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = ContaCorrenteFornecedorDALSQL.GetSelectFluxosDeTransferenciaVerbaFornecedor(data)

                data.FillDataSet(DatasetTransferenciaVerbaFornecedor, _
                                 sql, _
                                 DatasetTransferenciaVerbaFornecedor.queryFluxos.TableName, _
                                 New IDataParameter() {data.CreateParameter("NUMFLUAPV", DbType.Decimal, "NUMFLUAPV", NUMFLUAPV)})

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
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                Dim data As IData
                Dim sql As String

                DatasetTransferenciaVerbaFornecedor = New DatasetTransferenciaVerbaFornecedor

                'Desabilita a integridade referencial
                DatasetTransferenciaVerbaFornecedor.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = ContaCorrenteFornecedorDALSQL.GetSelectFluxosDeTransferenciaVerbaFornecedorMarketing(data)

                data.FillDataSet(DatasetTransferenciaVerbaFornecedor, _
                                 sql, _
                                 DatasetTransferenciaVerbaFornecedor.queryFluxos.TableName, _
                                 New IDataParameter() {data.CreateParameter("NUMFLUAPV", DbType.Decimal, "NUMFLUAPV", NUMFLUAPV)})

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
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                Dim data As IData
                Dim sql As String

                DatasetTransferenciaVerbaFornecedor = New DatasetTransferenciaVerbaFornecedor

                'Desabilita a integridade referencial
                DatasetTransferenciaVerbaFornecedor.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = ContaCorrenteFornecedorDALSQL.GetSelectFluxosDeTransferenciaVerbaDesoneracaoEResultadoAGF(data)

                data.FillDataSet(DatasetTransferenciaVerbaFornecedor, _
                                 sql, _
                                 DatasetTransferenciaVerbaFornecedor.queryFluxos.TableName, _
                                 New IDataParameter() {data.CreateParameter("NUMFLUAPV", DbType.Decimal, "NUMFLUAPV", NUMFLUAPV)})

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
                Dim DatasetReservaSaldoFornecedor As DatasetReservaSaldoFornecedor
                Dim data As IData
                Dim sql As String

                DatasetReservaSaldoFornecedor = New DatasetReservaSaldoFornecedor

                'Desabilita a integridade referencial
                DatasetReservaSaldoFornecedor.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = ContaCorrenteFornecedorDALSQL.GetSelectReservaSaldoFornecedor(data)
                data.FillDataSet(DatasetReservaSaldoFornecedor, _
                 sql, _
                 DatasetReservaSaldoFornecedor.T0123159.TableName, _
                 New IDataParameter() { _
                            data.CreateParameter("CODACOCMC", DbType.String, "CODACOCMC", CODACOCMC), _
                            data.CreateParameter("CODFRN", DbType.Decimal, "CODFRN", CODFRN), _
                            data.CreateParameter("TIPDSNDSCBNF", DbType.Decimal, "TIPDSNDSCBNF", TIPDSNDSCBNF) _
                      })


                Me.SetComplete()
                Return DatasetReservaSaldoFornecedor
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna dados da entidade T0123159 com base na em atributos que geralmente não compoem a chave primária (exceto em chaves compostas).
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
                Dim DatasetReservaSaldoFornecedor As DatasetReservaSaldoFornecedor
                Dim data As IData
                Dim sql As String
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList

                DatasetReservaSaldoFornecedor = New DatasetReservaSaldoFornecedor

                DatasetReservaSaldoFornecedor.EnforceConstraints = False

                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)
                sql = ContaCorrenteFornecedorDALSQL.GetSelectReservaSaldoFornecedor(data, CODACOCMC, CODFRN, DATAPVACOCMC, DATAPVACOCMCInicial, DATAPVACOCMCFinal, TIPDSNDSCBNF)

                If CODACOCMC.Trim() <> "" Then
                    paramNome = data.CreateParameter("CODACOCMC", DbType.String, "CODACOCMC", "%" + CODACOCMC.ToUpper() + "%")
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If CODFRN <> 0 Then
                    paramNome = data.CreateParameter("CODFRN", DbType.Decimal, "CODFRN", CODFRN)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If DATAPVACOCMC <> Nothing Then
                    paramNome = data.CreateParameter("DATAPVACOCMC", DbType.Date, "DATAPVACOCMC", DATAPVACOCMC)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If DATAPVACOCMCInicial <> Nothing And DATAPVACOCMCFinal <> Nothing Then
                    paramNome = data.CreateParameter("DATAPVACOCMCInicial", DbType.Date, "DATAPVACOCMC", DATAPVACOCMCInicial)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                    paramNome = data.CreateParameter("DATAPVACOCMCFinal", DbType.Date, "DATAPVACOCMC", DATAPVACOCMCFinal)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If
                If TIPDSNDSCBNF <> 0 Then
                    paramNome = data.CreateParameter("TIPDSNDSCBNF", DbType.Decimal, "TIPDSNDSCBNF", TIPDSNDSCBNF)
                    If (Not IsNothing(paramNome)) Then parametros.Add(paramNome)
                End If

                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo(parametrosCommand)

                data.FillDataSet(DatasetReservaSaldoFornecedor, _
                 sql, _
                 DatasetReservaSaldoFornecedor.T0123159.TableName, _
                 parametrosCommand)

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
                Dim data As IData
                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)

                Dim cb1 As CustomCommandBuilder
                cb1 = New CustomCommandBuilder(DatasetReservaSaldoFornecedor.T0123159, data, "MRT.T0123159")
                data.UpdateFromDataSet(DatasetReservaSaldoFornecedor.T0123159, _
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
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Marcos Queiroz]	26/12/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterFuncionarioAprovadorDaControladoriaQuandoMesLancamentoForDiferenteDoMesDeAprovacao() As Decimal
            Try
                Dim data As IData
                Dim sql As String
                Dim retorno As Integer
                Dim result As Decimal

                data = Me.transactionContext(Constants.CONEXAO_PRINCIPAL)
                sql = ContaCorrenteFornecedorDALSQL.GetSelectObterFuncionarioAprovadorDaControladoriaQuandoMesLancamentoForDiferenteDoMesDeAprovacao(data)

                result = Convert.ToInt32(data.ExecuteScalar(sql, _
                                         New IDataParameter() {data.CreateParameter("CODSISINF", DbType.Decimal, "CODSISINF", Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS), _
                                                               data.CreateParameter("NUMSEQNIVAPV", DbType.Decimal, "NUMSEQNIVAPV", Constants.NUMSEQNIVAPV_PARA_OBTER_FUNCIONARIO_APROVADOR_DA_CONTROLADORIA_QUANDO_MES_LANCAMENTO_FOR_DIFERENTE_DO_MES_DE_APROVACAO) _
                                                              }))

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
                Dim DatasetCalendarioAnual As DatasetCalendarioAnual
                Dim data As IData
                Dim sql As String

                DatasetCalendarioAnual = New DatasetCalendarioAnual

                'Desabilita a integridade referencial
                DatasetCalendarioAnual.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = ContaCorrenteFornecedorDALSQL.GetSelectCalendarioAnual(data)
                data.FillDataSet(DatasetCalendarioAnual, _
                 sql, _
                 DatasetCalendarioAnual.T0102321.TableName, _
                 New IDataParameter() { _
                            data.CreateParameter("DATREF", DbType.Date, "DATREF", DATREF) _
                      })


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
                Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor
                Dim data As IData
                Dim sql As String

                DatasetTransferenciaVerbaFornecedor = New DatasetTransferenciaVerbaFornecedor

                'Desabilita a integridade referencial
                DatasetTransferenciaVerbaFornecedor.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = ContaCorrenteFornecedorDALSQL.GetSelectAprovadoresEmpenhoMarketing(data)
                data.FillDataSet(DatasetTransferenciaVerbaFornecedor, _
                 sql, _
                 DatasetTransferenciaVerbaFornecedor.T0161581.TableName, _
                 New IDataParameter() { _
                            data.CreateParameter("CODSISINF", DbType.Date, "CODSISINF", Constants.CODSISINF_PARA_FLUXO_TRANSFERENCIA_VERBAS_EMPENHO_MARKETING) _
                      })


                Me.SetComplete()
                Return DatasetTransferenciaVerbaFornecedor
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

#Region "Stored Procedure"

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Atualiza os dados no banco 
        ''' LEGADO: SPCCX004
        ''' Procedure: MRT.PCTDJAtlCntCrrFrn.PRCDJAtlCntCrrFrn
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
        Public Sub AtualizarContaCorrenteFornecedor(ByVal linha As DatasetContaCorrenteFornecedor.T0123086Row)

            Try
                Dim data As IData
                Dim sql As String

                'Declara os parametros Oracle
                Dim vDatRefLmt As New OracleParameter("vDatRefLmt", OracleType.DateTime)
                Dim vTipDsnDscBnf As New OracleParameter("vTipDsnDscBnf", OracleType.Number)
                Dim vCodFrn As New OracleParameter("vCodFrn", OracleType.Number)
                Dim vCodGdc As New OracleParameter("vCodGdc", OracleType.VarChar, 1000)
                Dim vCodTipLmtPmt As New OracleParameter("vCodTipLmtPmt", OracleType.Int32)
                Dim vCodCntCrd As New OracleParameter("vCodCntCrd", OracleType.VarChar, 1000)
                Dim vCodCenCstCrd As New OracleParameter("vCodCenCstCrd", OracleType.VarChar, 1000)
                Dim vCodCntDeb As New OracleParameter("vCodCntDeb", OracleType.VarChar, 1000)
                Dim vCodCenCstDeb As New OracleParameter("vCodCenCstDeb", OracleType.VarChar, 1000)
                Dim vVlrLmtCtb As New OracleParameter("vVlrLmtCtb", OracleType.Number)
                Dim vDesHstLmt As New OracleParameter("vDesHstLmt", OracleType.VarChar, 1000)
                Dim vDesVarHstPad As New OracleParameter("vDesVarHstPad", OracleType.VarChar, 1000)
                Dim vNomAcsUsrGrcLmt As New OracleParameter("vNomAcsUsrGrcLmt", OracleType.VarChar, 1000)
                Dim CODUNI As New OracleParameter("CODUNI", OracleType.VarChar, 1000)
                Dim vCodErr As New OracleParameter("vCodErr", OracleType.Int32)
                Dim vMsgErr As New OracleParameter("vMsgErr", OracleType.VarChar, 1000)
                Dim vCodFilEmp As New OracleParameter("vCodFilEmp", OracleType.Number)
                Dim vCodPms As New OracleParameter("vCodPms", OracleType.Number)
                Dim vFlgRetVlr As New OracleParameter("vFlgRetVlr", OracleType.VarChar, 1000)
                Dim vTipAlcVbaFrnPmt As New OracleParameter("vTipAlcVbaFrnPmt", OracleType.Int32)
                Dim vTransfIntegral As New OracleParameter("vTransfIntegral", OracleType.Int32)

                'Define a direção dos parametros
                vDatRefLmt.Direction = ParameterDirection.Input
                vTipDsnDscBnf.Direction = ParameterDirection.Input
                vCodFrn.Direction = ParameterDirection.Input
                vCodGdc.Direction = ParameterDirection.Input
                vCodTipLmtPmt.Direction = ParameterDirection.Input
                vCodCntCrd.Direction = ParameterDirection.Input
                vCodCenCstCrd.Direction = ParameterDirection.Input
                vCodCntDeb.Direction = ParameterDirection.Input
                vCodCenCstDeb.Direction = ParameterDirection.Input
                vVlrLmtCtb.Direction = ParameterDirection.Input
                vDesHstLmt.Direction = ParameterDirection.Input
                vDesVarHstPad.Direction = ParameterDirection.Input
                vNomAcsUsrGrcLmt.Direction = ParameterDirection.Input
                CODUNI.Direction = ParameterDirection.Input
                vCodErr.Direction = ParameterDirection.Output
                vMsgErr.Direction = ParameterDirection.Output
                vCodFilEmp.Direction = ParameterDirection.Input
                vCodPms.Direction = ParameterDirection.Input
                vFlgRetVlr.Direction = ParameterDirection.Input
                vTipAlcVbaFrnPmt.Direction = ParameterDirection.Input
                vTransfIntegral.Direction = ParameterDirection.Input

                'Atribui valor aos parametros
                vDatRefLmt.Value = linha.DATREFLMT
                vTipDsnDscBnf.Value = linha.TIPDSNDSCBNF
                vCodFrn.Value = linha.CODFRN
                vCodGdc.Value = linha.CODGDC
                vCodTipLmtPmt.Value = linha.CODTIPLMT
                vCodCntCrd.Value = linha.CODCNTCRD
                vCodCenCstCrd.Value = linha.CODCENCSTCRD
                vCodCntDeb.Value = linha.CODCNTDEB
                vCodCenCstDeb.Value = linha.CODCENCSTDEB
                vVlrLmtCtb.Value = linha.VLRLMTCTB
                vDesHstLmt.Value = linha.DESHSTLMT
                vDesVarHstPad.Value = linha.DESVARHSTPAD
                vNomAcsUsrGrcLmt.Value = linha.NOMACSUSRGRCLMT.Trim
                CODUNI.Value = System.Data.OracleClient.OracleString.Null
                vCodFilEmp.Value = linha.CODFILEMP
                vCodPms.Value = linha.CODPMS
                'Esses 3 últimos parametros não eram informados no legado
                'CCX001E.Insere
                vFlgRetVlr.Value = ""
                vTipAlcVbaFrnPmt.Value = 0
                vTransfIntegral.Value = 0

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Obtem o sql
                sql = ContaCorrenteFornecedorDALSQL.GetSelectAtualizarContaCorrenteFornecedor

                System.Diagnostics.Debug.WriteLine("Inicio--------------------------------------------")
                System.Diagnostics.Debug.WriteLine("Procedure.......: " & sql)
                System.Diagnostics.Debug.WriteLine("Método..........: AtualizarContaCorrenteFornecedor")
                System.Diagnostics.Debug.WriteLine("vDatRefLmt......: " & linha.DATREFLMT.ToString)
                System.Diagnostics.Debug.WriteLine("vTipDsnDscBnf...: " & linha.TIPDSNDSCBNF)
                System.Diagnostics.Debug.WriteLine("vCodFrn.........: " & linha.CODFRN.ToString)
                System.Diagnostics.Debug.WriteLine("vCodGdc.........: " & linha.CODGDC.ToString)
                System.Diagnostics.Debug.WriteLine("vCodTipLmtPmt...: " & linha.CODTIPLMT.ToString)
                System.Diagnostics.Debug.WriteLine("vCodCntCrd......: " & linha.CODCNTCRD.ToString)
                System.Diagnostics.Debug.WriteLine("vCodCenCstCrd...: " & linha.CODCENCSTCRD.ToString)
                System.Diagnostics.Debug.WriteLine("vCodCntDeb......: " & linha.CODCNTDEB.ToString)
                System.Diagnostics.Debug.WriteLine("vCodCenCstDeb...: " & linha.CODCENCSTDEB.ToString)
                System.Diagnostics.Debug.WriteLine("vVlrLmtCtb......: " & linha.VLRLMTCTB.ToString)
                System.Diagnostics.Debug.WriteLine("vDesHstLmt......: " & linha.DESHSTLMT.ToString)
                System.Diagnostics.Debug.WriteLine("vDesVarHstPad...: " & linha.DESVARHSTPAD.ToString)
                System.Diagnostics.Debug.WriteLine("vNomAcsUsrGrcLmt: " & linha.NOMACSUSRGRCLMT.Trim)
                System.Diagnostics.Debug.WriteLine("vCodFilEmp......: " & linha.CODFILEMP.ToString)
                System.Diagnostics.Debug.WriteLine("vCodPms.........: " & linha.CODPMS.ToString)
                System.Diagnostics.Debug.WriteLine("Fim----------------------------------------------")
                System.Diagnostics.Debug.WriteLine("")
                System.Diagnostics.Debug.WriteLine("")

                data.ExecuteNonQuery(CommandType.StoredProcedure, _
                                     sql, _
                                     New IDataParameter() {vDatRefLmt, _
                                                       vTipDsnDscBnf, _
                                                       vCodFrn, _
                                                       vCodGdc, _
                                                       vCodTipLmtPmt, _
                                                       vCodCntCrd, _
                                                       vCodCenCstCrd, _
                                                       vCodCntDeb, _
                                                       vCodCenCstDeb, _
                                                       vVlrLmtCtb, _
                                                       vDesHstLmt, _
                                                       vDesVarHstPad, _
                                                       vNomAcsUsrGrcLmt, _
                                                       CODUNI, _
                                                       vCodErr, _
                                                       vMsgErr, _
                                                       vCodFilEmp, _
                                                       vCodPms, _
                                                       vFlgRetVlr, _
                                                       vTipAlcVbaFrnPmt, _
                                                       vTransfIntegral} _
                                     )

                'Verifica o retorno, nos casos abaixo não ocorreu erro
                '[ 1 = Suceesso | 1422 = Too Many Rows | 1403 = No data found
                If vCodErr.Value.ToString <> "1" And _
                   vCodErr.Value.ToString <> "1422" And _
                   vCodErr.Value.ToString <> "1403" Then
                    Throw New Martins.ExceptionManagement.MartinsSystemException(vMsgErr.Value.ToString, ErrorConstants.SYSTEM_ERROR)
                End If

                Me.SetComplete()

            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Sub

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
        '''     [Marcos Queiroz]        29/12/2006  Updated
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
                Dim data As IData
                Dim sql As String

                'Declara os parametros Oracle
                Dim vDatRefLmt As New OracleParameter("vDatRefLmt", OracleType.DateTime, 1000)
                Dim vTipDsnDscBnf As New OracleParameter("vTipDsnDscBnf", OracleType.Number)
                Dim vCodFrn As New OracleParameter("vCodFrn", OracleType.Number)
                Dim vCodGdc As New OracleParameter("vCodGdc", OracleType.VarChar, 1000)
                Dim vCodTipLmtPmt As New OracleParameter("vCodTipLmtPmt", OracleType.Int32)
                Dim vCodCntCrd As New OracleParameter("vCodCntCrd", OracleType.VarChar, 1000)
                Dim vCodCenCstCrd As New OracleParameter("vCodCenCstCrd", OracleType.VarChar, 1000)
                Dim vCodCntDeb As New OracleParameter("vCodCntDeb", OracleType.VarChar, 1000)
                Dim vCodCenCstDeb As New OracleParameter("vCodCenCstDeb", OracleType.VarChar, 1000)
                Dim vVlrLmtCtb As New OracleParameter("vVlrLmtCtb", OracleType.Number)
                Dim vDesHstLmt As New OracleParameter("vDesHstLmt", OracleType.VarChar, 1000)
                Dim vDesVarHstPad As New OracleParameter("vDesVarHstPad", OracleType.VarChar, 1000)
                Dim vNomAcsUsrGrcLmt As New OracleParameter("vNomAcsUsrGrcLmt", OracleType.VarChar, 1000)
                Dim CODUNI As New OracleParameter("CODUNI", OracleType.VarChar, 1000)
                Dim vCodErr As New OracleParameter("vCodErr", OracleType.Int32)
                Dim vMsgErr As New OracleParameter("vMsgErr", OracleType.VarChar, 1000)
                Dim vCodFilEmp As New OracleParameter("vCodFilEmp", OracleType.Number)
                Dim vCodPms As New OracleParameter("vCodPms", OracleType.Number)
                Dim vFlgRetVlr As New OracleParameter("vFlgRetVlr", OracleType.VarChar, 1000)
                Dim vTipAlcVbaFrnPmt As New OracleParameter("vTipAlcVbaFrnPmt", OracleType.Int32)
                Dim vTransfIntegral As New OracleParameter("vTransfIntegral", OracleType.Int32)

                System.Diagnostics.Debug.WriteLine("Inicio--------------------------------------------")
                System.Diagnostics.Debug.WriteLine("Procedure........: " & sql)
                System.Diagnostics.Debug.WriteLine("Método..........: AtualizarContaCorrenteFornecedor")
                System.Diagnostics.Debug.WriteLine("pvDatRefLmt......: " & pvDatRefLmt.ToString)
                System.Diagnostics.Debug.WriteLine("pvTipDsnDscBnf...: " & pvTipDsnDscBnf.ToString)
                System.Diagnostics.Debug.WriteLine("pvCodFrn.........: " & pvCodFrn.ToString)
                System.Diagnostics.Debug.WriteLine("pvCodGdc.........: " & pvCodGdc.ToString)
                System.Diagnostics.Debug.WriteLine("pvCodTipLmtPmt...: " & pvCodTipLmtPmt.ToString)
                System.Diagnostics.Debug.WriteLine("pvCodCntCrd......: " & pvCodCntCrd.ToString)
                System.Diagnostics.Debug.WriteLine("pvCodCenCstCrd...: " & pvCodCenCstCrd.ToString)
                System.Diagnostics.Debug.WriteLine("pvCodCntDeb......: " & pvCodCntDeb.ToString)
                System.Diagnostics.Debug.WriteLine("pvCodCenCstDeb...: " & pvCodCenCstDeb.ToString)
                System.Diagnostics.Debug.WriteLine("pvVlrLmtCtb......: " & pvVlrLmtCtb.ToString)
                System.Diagnostics.Debug.WriteLine("pvDesHstLmt......: " & pvDesHstLmt.ToString)
                System.Diagnostics.Debug.WriteLine("pvDesVarHstPad...: " & pvDesVarHstPad.ToString)
                System.Diagnostics.Debug.WriteLine("pvNomAcsUsrGrcLmt: " & pvNomAcsUsrGrcLmt.ToString)
                System.Diagnostics.Debug.WriteLine("pvCodFilEmp......: " & pvCodFilEmp.ToString)
                System.Diagnostics.Debug.WriteLine("pvCodPms.........: " & pvCodPms.ToString)
                System.Diagnostics.Debug.WriteLine("pvFlgRetVlr......: " & pvFlgRetVlr.ToString)
                System.Diagnostics.Debug.WriteLine("pvTipAlcVbaFrnPmt: " & pvTipAlcVbaFrnPmt.ToString)
                System.Diagnostics.Debug.WriteLine("pvTransfIntegral.: " & pvTransfIntegral.ToString)
                System.Diagnostics.Debug.WriteLine("Fim----------------------------------------------")
                System.Diagnostics.Debug.WriteLine("")
                System.Diagnostics.Debug.WriteLine("")

                'Define a direção dos parametros
                vDatRefLmt.Direction = ParameterDirection.Input
                vTipDsnDscBnf.Direction = ParameterDirection.Input
                vCodFrn.Direction = ParameterDirection.Input
                vCodGdc.Direction = ParameterDirection.Input
                vCodTipLmtPmt.Direction = ParameterDirection.Input
                vCodCntCrd.Direction = ParameterDirection.Input
                vCodCenCstCrd.Direction = ParameterDirection.Input
                vCodCntDeb.Direction = ParameterDirection.Input
                vCodCenCstDeb.Direction = ParameterDirection.Input
                vVlrLmtCtb.Direction = ParameterDirection.Input
                vDesHstLmt.Direction = ParameterDirection.Input
                vDesVarHstPad.Direction = ParameterDirection.Input
                vNomAcsUsrGrcLmt.Direction = ParameterDirection.Input
                CODUNI.Direction = ParameterDirection.Input
                vCodErr.Direction = ParameterDirection.Output
                vMsgErr.Direction = ParameterDirection.Output
                vCodFilEmp.Direction = ParameterDirection.Input
                vCodPms.Direction = ParameterDirection.Input
                vFlgRetVlr.Direction = ParameterDirection.Input
                vTipAlcVbaFrnPmt.Direction = ParameterDirection.Input
                vTransfIntegral.Direction = ParameterDirection.Input

                'Atribui valor aos parametros
                vDatRefLmt.Value = pvDatRefLmt
                vTipDsnDscBnf.Value = pvTipDsnDscBnf
                vCodFrn.Value = pvCodFrn
                vCodGdc.Value = pvCodGdc
                vCodTipLmtPmt.Value = pvCodTipLmtPmt
                vCodCntCrd.Value = pvCodCntCrd
                vCodCenCstCrd.Value = pvCodCenCstCrd
                vCodCntDeb.Value = pvCodCntDeb
                vCodCenCstDeb.Value = pvCodCenCstDeb
                vVlrLmtCtb.Value = pvVlrLmtCtb
                vDesHstLmt.Value = pvDesHstLmt
                vDesVarHstPad.Value = pvDesVarHstPad
                vNomAcsUsrGrcLmt.Value = pvNomAcsUsrGrcLmt
                CODUNI.Value = System.Data.OracleClient.OracleString.Null
                vCodFilEmp.Value = pvCodFilEmp
                vCodPms.Value = pvCodPms
                vFlgRetVlr.Value = pvFlgRetVlr
                vTipAlcVbaFrnPmt.Value = pvTipAlcVbaFrnPmt
                vTransfIntegral.Value = pvTransfIntegral

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Obtem o sql
                sql = ContaCorrenteFornecedorDALSQL.GetSelectAtualizarContaCorrenteFornecedor()

                data.ExecuteNonQuery(CommandType.StoredProcedure, _
                                 sql, _
                                 New IDataParameter() {vDatRefLmt, _
                                                       vTipDsnDscBnf, _
                                                       vCodFrn, _
                                                       vCodGdc, _
                                                       vCodTipLmtPmt, _
                                                       vCodCntCrd, _
                                                       vCodCenCstCrd, _
                                                       vCodCntDeb, _
                                                       vCodCenCstDeb, _
                                                       vVlrLmtCtb, _
                                                       vDesHstLmt, _
                                                       vDesVarHstPad, _
                                                       vNomAcsUsrGrcLmt, _
                                                       CODUNI, _
                                                       vCodErr, _
                                                       vMsgErr, _
                                                       vCodFilEmp, _
                                                       vCodPms, _
                                                       vFlgRetVlr, _
                                                       vTipAlcVbaFrnPmt, _
                                                       vTransfIntegral} _
                                 )

                'Verifica o retorno, nos casos abaixo não ocorreu erro
                '[ 1 = Suceesso | 1422 = Too Many Rows | 1403 = No data found
                If vCodErr.Value.ToString <> "1" And _
                   vCodErr.Value.ToString <> "1422" And _
                   vCodErr.Value.ToString <> "1403" Then
                    Throw New Martins.ExceptionManagement.MartinsSystemException(vMsgErr.Value.ToString, ErrorConstants.SYSTEM_ERROR)
                End If

                Me.SetComplete()

            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Chamada para procedure: MRT.PCTDJAtlCntCrrFrn.PRCDJObtNumSeqLmt
        ''' </summary>
        ''' <param name="pvTipDsnDscBnf"></param>
        ''' <param name="pvCodFrn"></param>
        ''' <param name="pvDatRefLmt"></param>
        ''' <param name="pvCodTipLmt"></param>
        ''' <param name="pCodUni"></param>
        ''' <remarks>
        ''' Chamada para procedure: MRT.PCTDJAtlCntCrrFrn.PRCDJObtNumSeqLmt
        ''' LEGADO:Estava incluído na spCCX004
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    28/12/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterNumeroSequenciaLancamento(ByVal pvTipDsnDscBnf As Decimal, _
                                                       ByVal pvCodFrn As Decimal, _
                                                       ByVal pvDatRefLmt As Date, _
                                                       ByVal pvCodTipLmt As Integer, _
                                                       ByVal pCodUni As String) As Integer
            Try
                Dim data As IData
                Dim sql As String

                'Declara os parametros Oracle
                Dim vTipDsnDscBnf As New OracleParameter("vTipDsnDscBnf", OracleType.Number)
                Dim vCodFrn As New OracleParameter("vCodFrn", OracleType.Number)
                Dim vDatRefLmt As New OracleParameter("vDatRefLmt", OracleType.DateTime)
                Dim vCodTipLmt As New OracleParameter("vCodTipLmt", OracleType.Int32)
                Dim CodUni As New OracleParameter("CodUni", OracleType.VarChar, 1000)
                Dim vNumSeqLmt As New OracleParameter("vNumSeqLmt", OracleType.Int32)
                Dim vCodErr As New OracleParameter("vCodErr", OracleType.Int32)
                Dim vMsgErr As New OracleParameter("vMsgErr", OracleType.VarChar, 1000)

                'Define a direção dos parametros
                vTipDsnDscBnf.Direction = ParameterDirection.Input
                vCodFrn.Direction = ParameterDirection.Input
                vDatRefLmt.Direction = ParameterDirection.Input
                vCodTipLmt.Direction = ParameterDirection.Input
                CodUni.Direction = ParameterDirection.Input
                vNumSeqLmt.Direction = ParameterDirection.Output
                vCodErr.Direction = ParameterDirection.Output
                vMsgErr.Direction = ParameterDirection.Output

                'Atribui valor aos parametros
                vTipDsnDscBnf.Value = pvTipDsnDscBnf
                vCodFrn.Value = pvCodFrn
                vDatRefLmt.Value = pvDatRefLmt
                vCodTipLmt.Value = pvCodTipLmt
                CodUni.Value = pCodUni

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Obtem o sql
                sql = ContaCorrenteFornecedorDALSQL.GetSelectObterNumeroSequenciaLancamento

                data.ExecuteNonQuery(CommandType.StoredProcedure, _
                                 sql, _
                                 New IDataParameter() {vTipDsnDscBnf, _
                                                       vCodFrn, _
                                                       vDatRefLmt, _
                                                       vCodTipLmt, _
                                                       CodUni, _
                                                       vNumSeqLmt, _
                                                       vCodErr, _
                                                       vMsgErr} _
                                )

                'Verifica o retorno, nos casos abaixo não ocorreu erro
                '[ 1 = Suceesso | 1422 = Too Many Rows | 1403 = No data found
                If vCodErr.Value.ToString <> "1" And _
                   vCodErr.Value.ToString <> "1422" And _
                   vCodErr.Value.ToString <> "1403" Then
                    Throw New Martins.ExceptionManagement.MartinsSystemException(vMsgErr.Value.ToString, ErrorConstants.SYSTEM_ERROR)
                End If

                Me.SetComplete()
                Return Convert.ToInt32(vNumSeqLmt.Value)

            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

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
                Dim ds As New DataSetRelatorioSaldoDisponivelFornecedorCelula
                Dim data As IData
                Dim sql As String

                'Declara os parametros Oracle
                Dim CODUNI As New OracleParameter("CODUNI", OracleType.VarChar, 1000)
                Dim rsCCX025 As New OracleParameter("rsCCX025", OracleType.Cursor)
                Dim vCodErr As New OracleParameter("vCodErr", OracleType.Int32)
                Dim vMsgErr As New OracleParameter("vMsgErr", OracleType.VarChar, 1000)
                Dim vCodDivCmp As New OracleParameter("vCodDivCmp", OracleType.Number)
                Dim vCodCpr As New OracleParameter("vCodCpr", OracleType.Number)
                Dim vTipDsnDscBnf As New OracleParameter("vTipDsnDscBnf", OracleType.Number)
                Dim vAnoMesRef As New OracleParameter("vAnoMesRef", OracleType.Number)
                Dim vTipo As New OracleParameter("vTipo", OracleType.Int32)

                'Define a direção dos parametros
                CODUNI.Direction = ParameterDirection.Input
                rsCCX025.Direction = ParameterDirection.Output
                vCodErr.Direction = ParameterDirection.Output
                vMsgErr.Direction = ParameterDirection.Output
                vCodDivCmp.Direction = ParameterDirection.Input
                vCodCpr.Direction = ParameterDirection.Input
                vTipDsnDscBnf.Direction = ParameterDirection.Input
                vAnoMesRef.Direction = ParameterDirection.Input
                vTipo.Direction = ParameterDirection.Input

                'Atribui valor aos parametros
                CODUNI.Value = System.Data.OracleClient.OracleString.Null
                vCodDivCmp.Value = pvCodDivCmp
                vCodCpr.Value = pvCodCpr
                vTipDsnDscBnf.Value = pvTipDsnDscBnf
                vAnoMesRef.Value = pvAnoMesRef
                vTipo.Value = pvTipo

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Obtem o sql
                sql = ContaCorrenteFornecedorDALSQL.GetSelectObterRelatorioSaldoDisponivelFornecedorCelula

                ds.EnforceConstraints = False
                data.FillDataSet(ds, _
                                 CommandType.StoredProcedure, _
                                 sql, _
                                 ds.TbAnalitico.TableName, _
                                 New IDataParameter() {CODUNI, _
                                                       rsCCX025, _
                                                       vCodErr, _
                                                       vMsgErr, _
                                                       vCodDivCmp, _
                                                       vTipDsnDscBnf, _
                                                       vAnoMesRef, _
                                                       vTipo, _
                                                       vCodCpr} _
                                )

                'Verifica o retorno, nos casos abaixo não ocorreu erro
                '[ 1 = Suceesso | 1422 = Too Many Rows | 1403 = No data found
                If vCodErr.Value.ToString <> "1" And _
                   vCodErr.Value.ToString <> "1422" And _
                   vCodErr.Value.ToString <> "1403" Then
                    Throw New Martins.ExceptionManagement.MartinsSystemException(vMsgErr.Value.ToString, ErrorConstants.SYSTEM_ERROR)
                End If

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
                Dim ds As New DatasetDiretoriaEDivisaoDeCompraDeFornecedor
                Dim data As IData
                Dim sql As String

                'Declara os parametros Oracle
                Dim vCodFrn As New OracleParameter("vCodFrn", OracleType.Number)
                Dim CODUNI As New OracleParameter("CODUNI", OracleType.VarChar, 1000)
                Dim rsCCX043 As New OracleParameter("rsCCX043", OracleType.Cursor)
                Dim vCodErr As New OracleParameter("vCodErr", OracleType.Int32)
                Dim vMsgErr As New OracleParameter("vMsgErr", OracleType.VarChar, 1000)

                'Define a direção dos parametros
                vCodFrn.Direction = ParameterDirection.Input
                CODUNI.Direction = ParameterDirection.Input
                rsCCX043.Direction = ParameterDirection.Output
                vCodErr.Direction = ParameterDirection.Output
                vMsgErr.Direction = ParameterDirection.Output

                'Atribui valor aos parametros
                vCodFrn.Value = pvCodFrn
                CODUNI.Value = System.Data.OracleClient.OracleString.Null

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Obtem o sql
                sql = ContaCorrenteFornecedorDALSQL.GetSelectObterDiretoriaEDivisaoDeCompraDeFornecedor

                ds.EnforceConstraints = False
                data.FillDataSet(ds, _
                                 CommandType.StoredProcedure, _
                                 sql, _
                                 ds.TbDiretoriaEDivisaoDeCompraDeFornecedor.TableName, _
                                 New IDataParameter() {vCodFrn, _
                                                       CODUNI, _
                                                       rsCCX043, _
                                                       vCodErr, _
                                                       vMsgErr} _
                                )

                'Verifica o retorno, nos casos abaixo não ocorreu erro
                '[ 1 = Suceesso | 1422 = Too Many Rows | 1403 = No data found
                If vCodErr.Value.ToString <> "1" And _
                   vCodErr.Value.ToString <> "1422" And _
                   vCodErr.Value.ToString <> "1403" Then
                    Throw New Martins.ExceptionManagement.MartinsSystemException(vMsgErr.Value.ToString, ErrorConstants.SYSTEM_ERROR)
                End If

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
        ''' Procedure legado SQL-SERVER: SPCCX017
        ''' Procedure Migrada Oracle...: PCTDJSelVlrDisFrn.PRCDJSelVlrDisFrn
        ''' </remarks>
        ''' <history>
        ''' 	[ELIFÁZIO]	21/9/2006	Created
        '''     [Marcos Queiroz] 01/11/2006 Updated
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ObterSelecaoValorDisponivelFornecedor(ByVal vDatRef As Date, _
                                                              ByVal vCodFrn As Decimal, _
                                                              ByVal vTipDsnDscBnf As Decimal) As DatasetSelecaoValorDisponivelFornecedor

            Try
                Dim ds As New DatasetSelecaoValorDisponivelFornecedor
                Dim data As IData
                Dim sql As String

                'Declara os parametros Oracle
                Dim pvdatref As New OracleParameter("vdatref", OracleType.DateTime)
                Dim pvcodfrn As New OracleParameter("vcodfrn", OracleType.Number)
                Dim pvtipdsndscbnf As New OracleParameter("vtipdsndscbnf", OracleType.Number)
                Dim pcoduni As New OracleParameter("coduni", OracleType.VarChar, 100)
                Dim prsccx017 As New OracleParameter("rsCCX017", OracleType.Cursor)
                Dim pvcoderr As New OracleParameter("vcoderr", OracleType.Int32)
                Dim pvmsgerr As New OracleParameter("vmsgerr", OracleType.VarChar, 2000)

                'Define a direção dos parametros
                pvdatref.Direction = ParameterDirection.Input
                pvcodfrn.Direction = ParameterDirection.Input
                pvtipdsndscbnf.Direction = ParameterDirection.Input
                pcoduni.Direction = ParameterDirection.Input
                prsccx017.Direction = ParameterDirection.Output
                pvcoderr.Direction = ParameterDirection.Output
                pvmsgerr.Direction = ParameterDirection.Output

                'Atribui valor aos parametros
                pvdatref.Value = vDatRef
                pvcodfrn.Value = vCodFrn
                pvtipdsndscbnf.Value = vTipDsnDscBnf
                pcoduni.Value = System.Data.OracleClient.OracleString.Null

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL
                sql = ContaCorrenteFornecedorDALSQL.GetSelectObterSelecaoValorDisponivelFornecedor

                ds.EnforceConstraints = False
                data.FillDataSet(ds, _
                                 CommandType.StoredProcedure, _
                                 sql, _
                                 ds.tbSelecaoValorDisponivelFornecedor.TableName, _
                                 New IDataParameter() {pvdatref, _
                                                       pvcodfrn, _
                                                       pvtipdsndscbnf, _
                                                       pcoduni, _
                                                       prsccx017, _
                                                       pvcoderr, _
                                                       pvmsgerr} _
                                )

                'Verifica o retorno, nos casos abaixo não ocorreu erro
                '[ 1 = Suceesso | 1422 = Too Many Rows | 1403 = No data found
                If pvcoderr.Value.ToString <> "1" And _
                   pvcoderr.Value.ToString <> "1422" And _
                   pvcoderr.Value.ToString <> "1403" Then
                    Throw New Martins.ExceptionManagement.MartinsSystemException(pvmsgerr.Value.ToString, ErrorConstants.SYSTEM_ERROR)
                End If

                Me.SetComplete()
                Return ds
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
                Dim DatasetSelecaoValorDisponivelFornecedor As DatasetSelecaoValorDisponivelFornecedor
                Dim paramNome As System.data.IDataParameter
                Dim parametros As New System.Collections.ArrayList
                Dim data As IData
                Dim sql As String
                Dim IN_CODFRNArray() As String = Split(IN_CODFRN.Trim, ",")

                DatasetSelecaoValorDisponivelFornecedor = New DatasetSelecaoValorDisponivelFornecedor

                'Desabilita a integridade referencial
                DatasetSelecaoValorDisponivelFornecedor.EnforceConstraints = False

                'Obtem o acesso a banco
                data = Me.transactionContext.GetDataAccess(Constants.CONEXAO_PRINCIPAL)

                'Prepara o comando SQL e executa o acesso ao banco
                sql = ContaCorrenteFornecedorDALSQL.GetSelectFornecedorCompradorEDivisaoCompra(data, IN_CODFRN)

                'Prepara os parametros da cláusula In
                If IN_CODFRNArray.Length > 0 Then
                    For i As Integer = 0 To IN_CODFRNArray.Length - 1
                        If IsNumeric(IN_CODFRNArray(i)) Then
                            paramNome = data.CreateParameter("CODFRN" + i.ToString, DbType.Decimal, "CODFRN", CType(IN_CODFRNArray(i), Decimal))
                            parametros.Add(paramNome)
                        End If
                    Next
                End If

                'Prepara o comando SQL e executa o acesso ao banco
                DatasetSelecaoValorDisponivelFornecedor.EnforceConstraints = False
                Dim parametrosCommand(parametros.Count - 1) As IDataParameter
                parametros.CopyTo(parametrosCommand)
                data.FillDataSet(DatasetSelecaoValorDisponivelFornecedor, _
                                 sql, _
                                 DatasetSelecaoValorDisponivelFornecedor.tbFornecedorCompradorEDivisaoCompra.TableName, _
                                 parametrosCommand)

                Me.SetComplete()
                Return DatasetSelecaoValorDisponivelFornecedor
            Catch ex As Exception
                Me.SetAbort()
                Throw ex
            End Try
        End Function

#End Region

    End Class

End Namespace