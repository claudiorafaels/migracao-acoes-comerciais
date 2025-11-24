Imports Martins.Data

Namespace DAL
    ''' -----------------------------------------------------------------------------
    ''' Project   : Martins.Compras.AcoesComerciais.AcordoFornecimento
    ''' Class     : FluxoDeCancelamentoDeAcordosDALSQL
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Classe de geração de comandos sql
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    23/04/2008  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Friend Class FluxoDeCancelamentoDeAcordosDALSQL

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela T0154038 com base na sua chave primária.
        ''' Descrição da entidade:FLUXO CANCELAMENTO ACORDO
        ''' </summary>
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    23/04/2008  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectFluxoCancelamentoAcordo(ByVal data As IData) As String
            Dim sql As New System.Text.StringBuilder

            sql.Append("SELECT " + vbCrLf)
            sql.Append("         CODFRN, " + vbCrLf )
            sql.Append("         CODSTAAPV, " + vbCrLf )
            sql.Append("         DATAPVCNCACOCMC, " + vbCrLf )
            sql.Append("         DATGRCCNCACOCMC, " + vbCrLf )
            sql.Append("         DATRPVCNCACOCMC, " + vbCrLf )
            sql.Append("         DESOBSCNCACOCMC, " + vbCrLf )
            sql.Append("         NOMUSRSIS, " + vbCrLf )
            sql.Append("         NUMPEDCNCACOCMC, " + vbCrLf )
            sql.Append("         NUMREQCNCACOCMC, " + vbCrLf )
            sql.Append("         VLRTOTCNCACOCMC " + vbCrLf )
            sql.Append("FROM     MRT.T0154038 ")
            sql.Append("WHERE    CODFRN=" + data.ConvertParameterName("CODFRN") + vbCrLf)
            sql.Append("         AND NUMPEDCNCACOCMC=" + data.ConvertParameterName("NUMPEDCNCACOCMC") + vbCrLf)
                   
            Return sql.ToString
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela T0154038 com base em atributos que não fazem parte da chave primária.
        ''' Descrição da entidade:FLUXO CANCELAMENTO ACORDO
        ''' </summary>
        ''' <param name="data">Contexto do banco de dados</param>
        ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
        ''' <param name="CODSTAAPV">CODIGO DO STATUS DO FLUXO.</param>
        ''' <param name="NUMPEDCNCACOCMC">NUMERO PEDIDO CANCELAMENTO ACORDO COMERCIAL.</param>
        ''' <param name="NUMREQCNCACOCMC">NUMERO REQUISICAO CANCELAMENTO ACORDO COMERCIAL.</param>
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    23/04/2008  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectFluxoCancelamentoAcordo(ByVal data As IData, _
                                                                ByVal CODFRN As Decimal, _
                                                                ByVal CODSTAAPV As Decimal, _
                                                                ByVal NUMPEDCNCACOCMC As Decimal, _
                                                                ByVal NUMREQCNCACOCMC As Decimal) As String
            Dim sql As New System.Text.StringBuilder
            Dim clausulaWhere As New System.Text.StringBuilder

            sql.Append("SELECT " + vbCrLf)
            sql.Append("         CODFRN, " + vbCrLf)
            sql.Append("         CODSTAAPV, " + vbCrLf)
            sql.Append("         DATAPVCNCACOCMC, " + vbCrLf)
            sql.Append("         DATGRCCNCACOCMC, " + vbCrLf)
            sql.Append("         DATRPVCNCACOCMC, " + vbCrLf)
            sql.Append("         DESOBSCNCACOCMC, " + vbCrLf)
            sql.Append("         NOMUSRSIS, " + vbCrLf)
            sql.Append("         NUMPEDCNCACOCMC, " + vbCrLf)
            sql.Append("         NUMREQCNCACOCMC, " + vbCrLf)
            sql.Append("         VLRTOTCNCACOCMC " + vbCrLf)
            sql.Append("FROM     MRT.T0154038 " + vbCrLf)

            If CODFRN <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE    ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("CODFRN=" + data.ConvertParameterName("CODFRN") + vbCrLf) 
            End If
            If CODSTAAPV <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE    ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("CODSTAAPV=" + data.ConvertParameterName("CODSTAAPV") + vbCrLf) 
            End If
            If NUMPEDCNCACOCMC <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE    ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("NUMPEDCNCACOCMC=" + data.ConvertParameterName("NUMPEDCNCACOCMC") + vbCrLf) 
            End If
            If NUMREQCNCACOCMC <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE    ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("NUMREQCNCACOCMC=" + data.ConvertParameterName("NUMREQCNCACOCMC") + vbCrLf) 
            End If

            sql.Append(clausulaWhere)

            Return sql.ToString
        End Function


        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela T0154021 com base na sua chave primária.
        ''' Descrição da entidade:ACORDO A CANCELAR EM FLUXO CANCELAMENTO ACORDO
        ''' </summary>
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    23/04/2008  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectAcordoACancelarEmFluxoCancelamentoAcordo(ByVal data As IData) As String
            Dim sql As New System.Text.StringBuilder

            sql.Append("SELECT " + vbCrLf)
            sql.Append("         CODEMP, " + vbCrLf )
            sql.Append("         CODFILEMP, " + vbCrLf )
            sql.Append("         CODPMS, " + vbCrLf )
            sql.Append("         DATNGCPMS, " + vbCrLf )
            sql.Append("         DATPRVRCBPMS, " + vbCrLf )
            sql.Append("         NUMPEDCNCACOCMC, " + vbCrLf )
            sql.Append("         TIPDSNDSCBNF, " + vbCrLf )
            sql.Append("         TIPFRMDSCBNF, " + vbCrLf )
            sql.Append("         VLRNGCPMS, " + vbCrLf )
            sql.Append("         VLRPGOPMS, " + vbCrLf )
            sql.Append("         VLRSLDPMSFRN " + vbCrLf )
            sql.Append("FROM     MRT.T0154021 ")
            sql.Append("WHERE    CODEMP=" + data.ConvertParameterName("CODEMP") + vbCrLf)
            sql.Append("         AND CODFILEMP=" + data.ConvertParameterName("CODFILEMP") + vbCrLf)
            sql.Append("         AND CODPMS=" + data.ConvertParameterName("CODPMS") + vbCrLf)
            sql.Append("         AND DATNGCPMS=" + data.ConvertParameterName("DATNGCPMS") + vbCrLf)
            sql.Append("         AND DATPRVRCBPMS=" + data.ConvertParameterName("DATPRVRCBPMS") + vbCrLf)
            sql.Append("         AND NUMPEDCNCACOCMC=" + data.ConvertParameterName("NUMPEDCNCACOCMC") + vbCrLf)
            sql.Append("         AND TIPDSNDSCBNF=" + data.ConvertParameterName("TIPDSNDSCBNF") + vbCrLf)
            sql.Append("         AND TIPFRMDSCBNF=" + data.ConvertParameterName("TIPFRMDSCBNF") + vbCrLf)
                   
            Return sql.ToString
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela T0154021 com base em atributos que não fazem parte da chave primária.
        ''' Descrição da entidade:ACORDO A CANCELAR EM FLUXO CANCELAMENTO ACORDO
        ''' </summary>
        ''' <param name="data">Contexto do banco de dados</param>
        ''' <param name="CODEMP">CODIGO EMPRESA.</param>
        ''' <param name="CODFILEMP">CODIGO DA FILIAL DA EMPRESA.</param>
        ''' <param name="CODPMS">CODIGO PROMESSA.</param>
        ''' <param name="DATNGCPMS">DATA DA NEGOCIACAO DA PROMESSA.</param>
        ''' <param name="DATPRVRCBPMS">DATA DE PREVISAO DE RECEBIMENTO DA PROMESSA.</param>
        ''' <param name="NUMPEDCNCACOCMC">NUMERO PEDIDO CANCELAMENTO ACORDO COMERCIAL.</param>
        ''' <param name="TIPDSNDSCBNF">TIPO DESTINO / DESCONTO BONIFICADO.</param>
        ''' <param name="TIPFRMDSCBNF">TIPO FORMA DESCONTO BONIFICACAO.</param>
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    23/04/2008  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectAcordoACancelarEmFluxoCancelamentoAcordo(ByVal data As IData, _
                                                                                 ByVal CODEMP As Decimal, _
                                                                                 ByVal CODFILEMP As Decimal, _
                                                                                 ByVal CODPMS As Decimal, _
                                                                                 ByVal DATNGCPMS As Date, _
                                                                                 ByVal DATPRVRCBPMS As Date, _
                                                                                 ByVal NUMPEDCNCACOCMC As Decimal, _
                                                                                 ByVal TIPDSNDSCBNF As Decimal, _
                                                                                 ByVal TIPFRMDSCBNF As Decimal) As String
            Dim sql As New System.Text.StringBuilder
            Dim clausulaWhere As New System.Text.StringBuilder

            sql.Append("SELECT " + vbCrLf)
            sql.Append("         CODEMP, " + vbCrLf)
            sql.Append("         CODFILEMP, " + vbCrLf)
            sql.Append("         CODPMS, " + vbCrLf)
            sql.Append("         DATNGCPMS, " + vbCrLf)
            sql.Append("         DATPRVRCBPMS, " + vbCrLf)
            sql.Append("         NUMPEDCNCACOCMC, " + vbCrLf)
            sql.Append("         TIPDSNDSCBNF, " + vbCrLf)
            sql.Append("         TIPFRMDSCBNF, " + vbCrLf)
            sql.Append("         VLRNGCPMS, " + vbCrLf)
            sql.Append("         VLRPGOPMS, " + vbCrLf)
            sql.Append("         VLRSLDPMSFRN " + vbCrLf)
            sql.Append("FROM     MRT.T0154021 " + vbCrLf)

            If CODEMP <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE    ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("CODEMP=" + data.ConvertParameterName("CODEMP") + vbCrLf) 
            End If
            If CODFILEMP <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE    ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("CODFILEMP=" + data.ConvertParameterName("CODFILEMP") + vbCrLf) 
            End If
            If CODPMS <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE    ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("CODPMS=" + data.ConvertParameterName("CODPMS") + vbCrLf) 
            End If
            If DATNGCPMS <> Nothing Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE    ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("DATNGCPMS=" + data.ConvertParameterName("DATNGCPMS") + vbCrLf) 
            End If
            If DATPRVRCBPMS <> Nothing Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE    ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("DATPRVRCBPMS=" + data.ConvertParameterName("DATPRVRCBPMS") + vbCrLf) 
            End If
            If NUMPEDCNCACOCMC <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE    ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("NUMPEDCNCACOCMC=" + data.ConvertParameterName("NUMPEDCNCACOCMC") + vbCrLf) 
            End If
            If TIPDSNDSCBNF <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE    ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("TIPDSNDSCBNF=" + data.ConvertParameterName("TIPDSNDSCBNF") + vbCrLf) 
            End If
            If TIPFRMDSCBNF <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE    ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("TIPFRMDSCBNF=" + data.ConvertParameterName("TIPFRMDSCBNF") + vbCrLf) 
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
        ''' 	[Danilo]	4/24/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectMinhasAprovavoesEmFluxoDeCancelamentoDeAcordos(ByVal data As IData, _
                                                                                       ByVal NUMPEDCNCACOCMC As Decimal, _
                                                                                       ByVal CODFNC As Decimal) As String
            Dim sql As New System.Text.StringBuilder

            sql.Append("Select DISTINCT " & vbCrLf)
            sql.Append("       A.NUMPEDCNCACOCMC," & vbCrLf)
            sql.Append("       A.CODSTAAPV," & vbCrLf)
            sql.Append("       Case A.CODSTAAPV" & vbCrLf)
            sql.Append("            WHEN 0 THEN 'EM APROVAÇÃO' " & vbCrLf)
            sql.Append("            WHEN 1 THEN 'APROVADO' " & vbCrLf)
            sql.Append("            WHEN 2 THEN 'REJEITADO' " & vbCrLf)
            sql.Append("            WHEN 3 THEN 'NOVO' " & vbCrLf)
            sql.Append("       End AS DESSTAAPV," & vbCrLf)
            sql.Append("       A.CODFRN," & vbCrLf)
            sql.Append("       B.NOMFRN," & vbCrLf)
            sql.Append("       A.DESOBSCNCACOCMC" & vbCrLf)
            sql.Append("FROM   MRT.T0154038 A " & vbCrLf)
            sql.Append("       INNER JOIN MRT.T0100426 B ON A.CODFRN = B.CODFRN" & vbCrLf)
            sql.Append("       LEFT  JOIN MRT.T0161591 C ON C.NUMFLUAPV  = A.NUMPEDCNCACOCMC" & vbCrLf)
            sql.Append("                                 AND C.CODSISINF = " & Constants.CODSISINF_FLUXO_DE_CANCELAMENTO_DE_ACORDO & vbCrLf)
            sql.Append("       LEFT  JOIN MRT.T0153350 D ON D.CODFNCAPVNGC = C.CODEDEAPV" & vbCrLf)
            sql.Append("                                 AND D.DATDST IS NULL " & vbCrLf)
            sql.Append("WHERE  (C.CODEDEAPV=" & data.ConvertParameterName("CODEDEAPV1") & " OR (D.CODFNCARZAPVNGC=" & data.ConvertParameterName("CODEDEAPV2") & " AND SYSTIMESTAMP BETWEEN D.DATINI AND D.DATFIM))" & vbCrLf)
            sql.Append("     AND A.CODSTAAPV=" & Constants.CODSTAAPV_EM_APROVACAO.ToString & vbCrLf)
            sql.Append("     AND C.TIPSTAFLUAPV=" & Constants.TIPSTAFLUAPV_EM_APROVAÇÃO_EM_FLUXO_CANCELAMENTO_ACORDO & vbCrLf)

            If NUMPEDCNCACOCMC <> 0 Then
                sql.Append("       And NUMPEDCNCACOCMC=" & data.ConvertParameterName("NUMPEDCNCACOCMC") & vbCrLf)
            End If

            Return sql.ToString
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="data"></param>
        ''' <param name="CODFRN"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Danilo Rafael]	4/28/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectAcordosParaCancelamentoPorFornecedor(ByVal data As IData, _
                                                                             ByVal CODFRN As Decimal) As String
            Dim sql As New System.Text.StringBuilder
            Dim clausulaWhere As New System.Text.StringBuilder

            sql.Append("WITH tempAcordos AS (                                                                                                                          " + vbCrLf)
            sql.Append("            SELECT Distinct                                                                                                                    " + vbCrLf)
            sql.Append("                   B.CODFRN,                                                                                                                   " + vbCrLf)
            sql.Append("                   (Select Z.NomFrn From MRT.T0100426 Z where Z.CodFrn  = B.CodFrn) As NomFrn,                                                 " + vbCrLf)
            sql.Append("                   A.CODEMP,                                                                                                                   " + vbCrLf)
            sql.Append("                   A.CODFILEMP,                                                                                                                " + vbCrLf)
            sql.Append("                   A.CODPMS,                                                                                                                   " + vbCrLf)
            sql.Append("                   A.DATNGCPMS,                                                                                                                " + vbCrLf)
            sql.Append("                   A.DATPRVRCBPMS,                                                                                                             " + vbCrLf)
            sql.Append("                   A.TIPFRMDSCBNF,                                                                                                             " + vbCrLf)
            sql.Append("                   D.DESFRMDSCBNF,                                                                                                             " + vbCrLf)
            sql.Append("                   NVL(E.FLGSITNGCDUP, ' ') AS FLGSITNGCDUP,                                                                                   " + vbCrLf)
            sql.Append("                   A.TIPDSNDSCBNF,                                                                                                             " + vbCrLf)
            sql.Append("                   C.DESDSNDSCBNF,                                                                                                             " + vbCrLf)
            sql.Append("                   B.CODSITPMS,                                                                                                                " + vbCrLf)
            sql.Append("                   NVL(A.VlrNgcPms, 0) as VLRNGCPMS,                                                                                           " + vbCrLf)
            sql.Append("                   NVL(A.VLRPGOPMS, 0) as VLRPGOPMS,                                                                                           " + vbCrLf)
            sql.Append("                   NVL(A.VLRNGCPMS, 0) - NVL(A.VLRPGOPMS, 0)  as VLRDSPPMS                                                                     " + vbCrLf)
            sql.Append("            FROM   MRT.T0118066 A                                                                                                              " + vbCrLf)
            sql.Append("                   INNER JOIN MRT.T0118058 B ON A.CODEMP = B.CODEMP                                                                            " + vbCrLf)
            sql.Append("                                            AND A.CODFILEMP = B.CODFILEMP                                                                      " + vbCrLf)
            sql.Append("                                            AND A.CODPMS = B.CODPMS                                                                            " + vbCrLf)
            sql.Append("                                            AND A.DATNGCPMS = B.DATNGCPMS                                                                      " + vbCrLf)
            sql.Append("                   INNER JOIN MRT.T0109059 C ON A.TIPDSNDSCBNF = C.TIPDSNDSCBNF                                                                " + vbCrLf)
            sql.Append("                   INNER JOIN MRT.T0113552 D ON A.TIPFRMDSCBNF = D.TIPFRMDSCBNF                                                                " + vbCrLf)
            sql.Append("                   LEFT JOIN MRT.T0128592 E ON A.CODPMS = E.CODPMS                                                                             " + vbCrLf)
            sql.Append("                                            AND A.CODEMP = E.CODEMP                                                                            " + vbCrLf)
            sql.Append("                                            AND A.CODFILEMP = E.CODFILEMP                                                                      " + vbCrLf)
            sql.Append("                                            AND A.DATNGCPMS = E.DATNGCPMS                                                                      " + vbCrLf)
            sql.Append("                                            AND E.FLGSITNGCDUP IN ( 'A', 'I')                                                                  " + vbCrLf)
            sql.Append("            WHERE  (B.CODFRN =" + data.ConvertParameterName("CODFRN1") + " or 0 =" + data.ConvertParameterName("CODFRN2") + ")                 " + vbCrLf)
            sql.Append("                   AND (B.CODSITPMS NOT IN (2, 4, 5, 6))                                                                                       " + vbCrLf)
            sql.Append("                   AND (A.TIPFRMDSCBNF IN (2, 3, 8, 13))                                                                                       " + vbCrLf)
            sql.Append("                   AND (B.NumPedCmp IS NULL)                                                                                                   " + vbCrLf)
            sql.Append("                   AND (B.NomAcsUsrSis = 'SISTEMA')                                                                                            " + vbCrLf)
            sql.Append("                   AND (NVL(A.IndAscArdFrnPms,0) = 0)                                                                                          " + vbCrLf)
            sql.Append("                   AND (NVL(A.VLRNGCPMS, 0)) = NVL(A.VlrEftPms, 0)                                                                             " + vbCrLf)
            sql.Append("                   AND ((NVL(A.VLRNGCPMS, 0)) - NVL(A.VLRPGOPMS, 0) > 1)                                                                       " + vbCrLf)
            sql.Append("            UNION ALL                                                                                                                          " + vbCrLf)
            sql.Append("            SELECT Distinct                                                                                                                    " + vbCrLf)
            sql.Append("                   B.CODFRN,                                                                                                                   " + vbCrLf)
            sql.Append("                   (Select Z.NomFrn From MRT.T0100426 Z where Z.CodFrn  = B.CodFrn) As NomFrn,                                                 " + vbCrLf)
            sql.Append("                   A.CODEMP,                                                                                                                   " + vbCrLf)
            sql.Append("                   A.CODFILEMP,                                                                                                                " + vbCrLf)
            sql.Append("                   A.CODPMS,                                                                                                                   " + vbCrLf)
            sql.Append("                   A.DATNGCPMS,                                                                                                                " + vbCrLf)
            sql.Append("                   A.DATPRVRCBPMS,                                                                                                             " + vbCrLf)
            sql.Append("                   A.TIPFRMDSCBNF,                                                                                                             " + vbCrLf)
            sql.Append("                   D.DESFRMDSCBNF,                                                                                                             " + vbCrLf)
            sql.Append("                   NVL(E.FLGSITNGCDUP, ' ') AS FLGSITNGCDUP,                                                                                   " + vbCrLf)
            sql.Append("                   A.TIPDSNDSCBNF,                                                                                                             " + vbCrLf)
            sql.Append("                   C.DESDSNDSCBNF,                                                                                                             " + vbCrLf)
            sql.Append("                   B.CODSITPMS,                                                                                                                " + vbCrLf)
            sql.Append("                   NVL(A.VLRNGCPMS, 0) as VLRNGCPMS,                                                                                           " + vbCrLf)
            sql.Append("                   NVL(A.VLRPGOPMS, 0) as VLRPGOPMS,                                                                                           " + vbCrLf)
            sql.Append("                   NVL(A.VLRNGCPMS, 0) - NVL(A.VLRPGOPMS, 0)  as VlrDspPms                                                                     " + vbCrLf)
            sql.Append("            FROM   MRT.T0118066 A                                                                                                              " + vbCrLf)
            sql.Append("                   INNER JOIN MRT.T0118058 B ON A.CODEMP = B.CODEMP                                                                            " + vbCrLf)
            sql.Append("                                            AND A.CODFILEMP = B.CODFILEMP                                                                      " + vbCrLf)
            sql.Append("                                            AND A.CODPMS = B.CODPMS                                                                            " + vbCrLf)
            sql.Append("                                            AND A.DATNGCPMS = B.DATNGCPMS                                                                      " + vbCrLf)
            sql.Append("                   INNER JOIN MRT.T0109059 C ON A.TIPDSNDSCBNF = C.TIPDSNDSCBNF                                                                " + vbCrLf)
            sql.Append("                   INNER JOIN MRT.T0113552 D ON A.TIPFRMDSCBNF = D.TIPFRMDSCBNF                                                                " + vbCrLf)
            sql.Append("                   LEFT JOIN MRT.T0128592 E ON A.CODPMS = E.CODPMS                                                                             " + vbCrLf)
            sql.Append("                                            AND A.CODEMP = E.CODEMP                                                                            " + vbCrLf)
            sql.Append("                                            AND A.CODFILEMP = E.CODFILEMP                                                                      " + vbCrLf)
            sql.Append("                                            AND A.DATNGCPMS = E.DATNGCPMS                                                                      " + vbCrLf)
            sql.Append("                                            AND E.FLGSITNGCDUP IN ( 'A', 'I')                                                                  " + vbCrLf)
            sql.Append("            WHERE  (B.CODFRN =" + data.ConvertParameterName("CODFRN3") + " or 0 =" + data.ConvertParameterName("CODFRN4") + ")                 " + vbCrLf)
            sql.Append("                   AND (B.CODSITPMS NOT IN (2, 4, 5, 6))                                                                                       " + vbCrLf)
            sql.Append("                   AND (A.TIPFRMDSCBNF = 9)                                                                                                    " + vbCrLf)
            sql.Append("                   AND (B.NumPedCmp IS NULL)                                                                                                   " + vbCrLf)
            sql.Append("                   AND (NVL(A.IndAscArdFrnPms,0) = 0)                                                                                          " + vbCrLf)
            sql.Append("                   AND (B.NomAcsUsrSis = 'SISTEMA')                                                                                            " + vbCrLf)
            sql.Append("                   AND (NVL(A.VLRNGCPMS, 0)) = NVL(A.VlrEftPms, 0)                                                                             " + vbCrLf)
            sql.Append("                   AND ((NVL(A.VLRNGCPMS, 0)) - NVL(A.VLRPGOPMS, 0) > 1)                                                                       " + vbCrLf)
            sql.Append("            UNION ALL                                                                                                                          " + vbCrLf)
            sql.Append("            SELECT Distinct                                                                                                                    " + vbCrLf)
            sql.Append("                   B.CODFRN,                                                                                                                   " + vbCrLf)
            sql.Append("                   (select Z.NomFrn From MRT.T0100426 Z where Z.CodFrn  = B.CodFrn) As NomFrn,                                                 " + vbCrLf)
            sql.Append("                   A.CODEMP,                                                                                                                   " + vbCrLf)
            sql.Append("                   A.CODFILEMP,                                                                                                                " + vbCrLf)
            sql.Append("                   A.CODPMS,                                                                                                                   " + vbCrLf)
            sql.Append("                   A.DATNGCPMS,                                                                                                                " + vbCrLf)
            sql.Append("                   A.DATPRVRCBPMS,                                                                                                             " + vbCrLf)
            sql.Append("                   MAX(A.TIPFRMDSCBNF) AS TIPFRMDSCBNF,                                                                                        " + vbCrLf)
            sql.Append("                   F.DESFRMDSCBNF,                                                                                                             " + vbCrLf)
            sql.Append("                   NVL(E.FLGSITNGCDUP, ' ') AS FLGSITNGCDUP,                                                                                   " + vbCrLf)
            sql.Append("                   MAX(A.TIPDSNDSCBNF) AS TIPDSNDSCBNF,                                                                                        " + vbCrLf)
            sql.Append("                   D.DESDSNDSCBNF, B.CODSITPMS,                                                                                                " + vbCrLf)
            sql.Append("                   NVL(A.VLRNGCPMS, 0) as VLRNGCPMS,                                                                                           " + vbCrLf)
            sql.Append("                   NVL(A.VLRPGOPMS, 0) as VLRPGOPMS,                                                                                           " + vbCrLf)
            sql.Append("                   (CASE WHEN ((B.CODSITPMS <> 3) AND (C.NumIdtTipPedCmp > 199)) THEN                                                          " + vbCrLf)
            sql.Append("                              NVL(SUM(A.VLRNGCPMS), 0) - NVL(SUM(A.VLRPGOPMS), 0)                                                              " + vbCrLf)
            sql.Append("                         WHEN ((B.CODSITPMS <> 3) AND (C.NumIdtTipPedCmp <= 199)) AND NVL(SUM(A.VLRNGCPMS), 0) = NVL(SUM(A.VlrEftPms), 0) THEN " + vbCrLf)
            sql.Append("                              NVL(SUM(A.VLRNGCPMS), 0) - NVL(SUM(A.VLRPGOPMS), 0)                                                              " + vbCrLf)
            sql.Append("                         WHEN ((B.CODSITPMS = 3) AND (C.NumIdtTipPedCmp <= 199)) THEN                                                          " + vbCrLf)
            sql.Append("                              NVL(SUM(A.VlrEftPms), 0) - NVL(SUM(A.VLRPGOPMS), 0)                                                              " + vbCrLf)
            sql.Append("                         WHEN ((B.CODSITPMS = 3) AND (C.NumIdtTipPedCmp > 199)) AND NVL(SUM(A.VLRNGCPMS), 0) = NVL(SUM(A.VlrEftPms), 0) THEN   " + vbCrLf)
            sql.Append("                              NVL(SUM(A.VLRNGCPMS), 0) - NVL(SUM(A.VLRPGOPMS), 0)                                                              " + vbCrLf)
            sql.Append("                    END) AS VlrDspPms                                                                                                          " + vbCrLf)
            sql.Append("            FROM   MRT.T0118066 A                                                                                                              " + vbCrLf)
            sql.Append("                   INNER JOIN MRT.T0118058 B ON A.CODEMP = B.CODEMP                                                                            " + vbCrLf)
            sql.Append("                                            AND A.CODFILEMP = B.CODFILEMP                                                                      " + vbCrLf)
            sql.Append("                                            AND A.CODPMS = B.CODPMS                                                                            " + vbCrLf)
            sql.Append("                                            AND A.DATNGCPMS = B.DATNGCPMS                                                                      " + vbCrLf)
            sql.Append("                   INNER JOIN MRT.T0105592 C ON B.NumPedCmp = C.NumPedCmp                                                                      " + vbCrLf)
            sql.Append("                   INNER JOIN MRT.T0109059 D ON A.TIPDSNDSCBNF = D.TIPDSNDSCBNF                                                                " + vbCrLf)
            sql.Append("                   LEFT JOIN MRT.T0128592 E ON A.CODPMS = E.CODPMS                                                                             " + vbCrLf)
            sql.Append("                                            AND A.CODEMP = E.CODEMP                                                                            " + vbCrLf)
            sql.Append("                                            AND A.CODFILEMP = E.CODFILEMP                                                                      " + vbCrLf)
            sql.Append("                                            AND A.DATNGCPMS = E.DATNGCPMS                                                                      " + vbCrLf)
            sql.Append("                                            AND E.FLGSITNGCDUP IN ( 'A', 'I')                                                                  " + vbCrLf)
            sql.Append("                   INNER JOIN MRT.T0113552 F ON A.TIPFRMDSCBNF = F.TIPFRMDSCBNF                                                                " + vbCrLf)
            sql.Append("            WHERE  (B.CODFRN =" + data.ConvertParameterName("CODFRN5") + " or 0 =" + data.ConvertParameterName("CODFRN6") + ")                 " + vbCrLf)
            sql.Append("                   AND (B.CODSITPMS NOT IN (2, 4, 5, 6))                                                                                       " + vbCrLf)
            sql.Append("                   AND (NVL(A.IndAscArdFrnPms,0) = 0)                                                                                          " + vbCrLf)
            sql.Append("                   AND ((A.TIPFRMDSCBNF IN ( 3 , 8 , 9, 13 )                                                                                   " + vbCrLf)
            sql.Append("                         AND B.NomAcsUsrSis <> 'SISTEMA'                                                                                       " + vbCrLf)
            sql.Append("                         AND B.NumPedCmp IS NOT NULL )  OR ( A.TIPFRMDSCBNF = 9 AND B.NomAcsUsrSis = 'SISTEMA' AND B.NumPedCmp IS NOT NULL))   " + vbCrLf)
            sql.Append("            GROUP BY B.CODFRN,                                                                                                                 " + vbCrLf)
            sql.Append("                   A.CODEMP,                                                                                                                   " + vbCrLf)
            sql.Append("                   A.CODFILEMP,                                                                                                                " + vbCrLf)
            sql.Append("                   A.CODPMS,                                                                                                                   " + vbCrLf)
            sql.Append("                   A.DATNGCPMS,                                                                                                                " + vbCrLf)
            sql.Append("                   D.DESDSNDSCBNF,                                                                                                             " + vbCrLf)
            sql.Append("                   B.CODSITPMS,                                                                                                                " + vbCrLf)
            sql.Append("                   C.NumIdtTipPedCmp,                                                                                                          " + vbCrLf)
            sql.Append("                   A.VLRNGCPMS,                                                                                                                " + vbCrLf)
            sql.Append("                   A.DATPRVRCBPMS,                                                                                                             " + vbCrLf)
            sql.Append("                   F.DESFRMDSCBNF,                                                                                                             " + vbCrLf)
            sql.Append("                   E.FLGSITNGCDUP,                                                                                                             " + vbCrLf)
            sql.Append("                   A.VLRPGOPMS                                                                                                                 " + vbCrLf)
            sql.Append("            HAVING (B.CODSITPMS <> 3) AND (C.NumIdtTipPedCmp > 199) AND                                                                        " + vbCrLf)
            sql.Append("                   (NVL(SUM(A.VLRNGCPMS), 0) - NVL(SUM(A.VLRPGOPMS), 0) > 0.01)                                                                " + vbCrLf)
            sql.Append("                   OR (B.CODSITPMS <> 3) AND (C.NumIdtTipPedCmp <= 199) AND                                                                    " + vbCrLf)
            sql.Append("                   (NVL(SUM(A.VLRNGCPMS), 0) = NVL(SUM(A.VlrEftPms), 0)) AND                                                                   " + vbCrLf)
            sql.Append("                   (NVL(SUM(A.VLRNGCPMS), 0) - NVL(SUM(A.VLRPGOPMS), 0) > 0.01) OR                                                             " + vbCrLf)
            sql.Append("                   ((B.CODSITPMS = 3) AND (C.NumIdtTipPedCmp <= 199) AND  + (NVL(SUM(A.VlrEftPms), 0)) -                                       " + vbCrLf)
            sql.Append("                   NVL(SUM(A.VLRPGOPMS), 0) > 0.01) OR                                                                                         " + vbCrLf)
            sql.Append("                   ((B.CODSITPMS = 3) AND (C.NumIdtTipPedCmp > 199) AND                                                                        " + vbCrLf)
            sql.Append("                   (NVL(SUM(A.VLRNGCPMS), 0) = NVL(SUM(A.VlrEftPms), 0)) AND                                                                   " + vbCrLf)
            sql.Append("                   (NVL(SUM(A.VLRNGCPMS), 0) - NVL(SUM(A.VLRPGOPMS), 0) > 0.01))                                                               " + vbCrLf)
            sql.Append("            UNION ALL                                                                                                                          " + vbCrLf)
            sql.Append("            SELECT Distinct                                                                                                                    " + vbCrLf)
            sql.Append("                   B.CODFRN,                                                                                                                   " + vbCrLf)
            sql.Append("                   (select Z.NomFrn From MRT.T0100426 Z where Z.CodFrn  = B.CodFrn) As NomFrn,                                                 " + vbCrLf)
            sql.Append("                   A.CODEMP,                                                                                                                   " + vbCrLf)
            sql.Append("                   A.CODFILEMP,                                                                                                                " + vbCrLf)
            sql.Append("                   A.CODPMS,                                                                                                                   " + vbCrLf)
            sql.Append("                   A.DATNGCPMS,                                                                                                                " + vbCrLf)
            sql.Append("                   MAX(A.DATPRVRCBPMS) as DATPRVRCBPMS,                                                                                        " + vbCrLf)
            sql.Append("                   MAX(A.TIPFRMDSCBNF) AS TIPFRMDSCBNF,                                                                                        " + vbCrLf)
            sql.Append("                   D.DESFRMDSCBNF,                                                                                                             " + vbCrLf)
            sql.Append("                   NVL(E.FLGSITNGCDUP, ' ') AS FLGSITNGCDUP,                                                                                   " + vbCrLf)
            sql.Append("                   MAX(A.TIPDSNDSCBNF) AS TIPDSNDSCBNF,                                                                                        " + vbCrLf)
            sql.Append("                   C.DESDSNDSCBNF, B.CODSITPMS,                                                                                                " + vbCrLf)
            sql.Append("                   NVL(A.VLRNGCPMS, 0) as VLRNGCPMS,                                                                                           " + vbCrLf)
            sql.Append("                   NVL(A.VLRPGOPMS, 0) as VLRPGOPMS,                                                                                           " + vbCrLf)
            sql.Append("                   NVL(SUM(A.VLRNGCPMS), 0)  - NVL(SUM(A.VLRPGOPMS), 0)  as VlrDspPms                                                          " + vbCrLf)
            sql.Append("            FROM   MRT.T0118066 A                                                                                                              " + vbCrLf)
            sql.Append("                   INNER JOIN MRT.T0118058 B ON A.CODEMP = B.CODEMP                                                                            " + vbCrLf)
            sql.Append("                                            AND (A.CODFILEMP = B.CODFILEMP)                                                                    " + vbCrLf)
            sql.Append("                                            AND (A.CODPMS = B.CODPMS)                                                                          " + vbCrLf)
            sql.Append("                                            AND (A.DATNGCPMS = B.DATNGCPMS)                                                                    " + vbCrLf)
            sql.Append("                   INNER JOIN MRT.T0109059 C ON A.TIPDSNDSCBNF = C.TIPDSNDSCBNF                                                                " + vbCrLf)
            sql.Append("                   INNER JOIN MRT.T0113552 D ON A.TIPFRMDSCBNF = D.TIPFRMDSCBNF                                                                " + vbCrLf)
            sql.Append("                   LEFT JOIN MRT.T0128592 E ON A.CODPMS = E.CODPMS                                                                             " + vbCrLf)
            sql.Append("                                            AND A.CODEMP = E.CODEMP                                                                            " + vbCrLf)
            sql.Append("                                            AND A.CODFILEMP = E.CODFILEMP                                                                      " + vbCrLf)
            sql.Append("                                            AND A.DATNGCPMS = E.DATNGCPMS                                                                      " + vbCrLf)
            sql.Append("                                            AND E.FLGSITNGCDUP IN ( 'A', 'I')                                                                  " + vbCrLf)
            sql.Append("            WHERE  (B.CODFRN =" + data.ConvertParameterName("CODFRN7") + " or 0 =" + data.ConvertParameterName("CODFRN8") + ")                 " + vbCrLf)
            sql.Append("                   AND (B.CODSITPMS NOT IN (2, 4, 5, 6))                                                                                       " + vbCrLf)
            sql.Append("                   AND (A.TIPFRMDSCBNF IN (3, 8, 9, 13))                                                                                       " + vbCrLf)
            sql.Append("                   AND (B.NumPedCmp IS NULL)                                                                                                   " + vbCrLf)
            sql.Append("                   AND (NVL(A.IndAscArdFrnPms,0) = 0)                                                                                          " + vbCrLf)
            sql.Append("                   AND (B.NomAcsUsrSis <> 'SISTEMA')                                                                                           " + vbCrLf)
            sql.Append("            GROUP BY B.CODFRN,                                                                                                                 " + vbCrLf)
            sql.Append("                   A.CODEMP,                                                                                                                   " + vbCrLf)
            sql.Append("                   A.CODFILEMP,                                                                                                                " + vbCrLf)
            sql.Append("                   A.CODPMS,                                                                                                                   " + vbCrLf)
            sql.Append("                   A.DATNGCPMS,                                                                                                                " + vbCrLf)
            sql.Append("                   C.DESDSNDSCBNF,                                                                                                             " + vbCrLf)
            sql.Append("                   B.CODSITPMS,                                                                                                                " + vbCrLf)
            sql.Append("                   A.VLRNGCPMS,                                                                                                                " + vbCrLf)
            sql.Append("                   A.VLRPGOPMS,                                                                                                                " + vbCrLf)
            sql.Append("                   D.DESFRMDSCBNF,                                                                                                             " + vbCrLf)
            sql.Append("                   E.FLGSITNGCDUP                                                                                                              " + vbCrLf)
            sql.Append("            HAVING ((NVL(SUM(A.VLRNGCPMS), 0) = NVL(SUM(A.VlrEftPms), 0))                                                                      " + vbCrLf)
            sql.Append("                   AND ((NVL(SUM(A.VLRNGCPMS), 0) - NVL(SUM(A.VLRPGOPMS), 0)) > 0.01))                                                         " + vbCrLf)
            sql.Append("            )                                                                                                                                  " + vbCrLf)
            sql.Append("            SELECT Distinct A.*                                                                                                                " + vbCrLf)
            sql.Append("            FROM   tempAcordos A                                                                                                               " + vbCrLf)
            sql.Append("            WHERE  NOT EXISTS(SELECT C.NUMPEDCNCACOCMC                                                                                         " + vbCrLf)
            sql.Append("                              FROM   MRT.T0154021 B                                                                                            " + vbCrLf)
            sql.Append("                                     LEFT JOIN MRT.T0154038 C ON C.NUMPEDCNCACOCMC = B.NUMPEDCNCACOCMC                                         " + vbCrLf)
            sql.Append("                              WHERE  B.CODPMS = A.CODPMS                                                                                       " + vbCrLf)
            sql.Append("                                     AND NVL(C.CODSTAAPV,3) = 0)                                                                               " + vbCrLf)

            Return sql.ToString
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="data"></param>
        ''' <param name="NUMPEDCNCACOCMC"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Danilo Rafael]	5/6/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectAcordosParaCancelamentoPorNUMPEDCNCACOCMC(ByVal data As IData, _
                                                                                  ByVal NUMPEDCNCACOCMC As Decimal) As String
            Dim sql As New System.Text.StringBuilder
            Dim clausulaWhere As New System.Text.StringBuilder


            sql.Append("SELECT DISTINCT" + vbCrLf)
            sql.Append("       D.NUMPEDCNCACOCMC, " + vbCrLf)
            sql.Append("       B.DESDSNDSCBNF," + vbCrLf)
            sql.Append("       D.CODPMS," + vbCrLf)
            sql.Append("       D.DATNGCPMS," + vbCrLf)
            sql.Append("       D.DATPRVRCBPMS," + vbCrLf)
            sql.Append("       E.DESFRMDSCBNF," + vbCrLf)
            sql.Append("       NVL(F.FLGSITNGCDUP, ' ') as FLGSITNGCDUP," + vbCrLf)
            sql.Append("       D.VLRNGCPMS," + vbCrLf)
            sql.Append("       D.VLRPGOPMS," + vbCrLf)
            sql.Append("       D.CODEMP," + vbCrLf)
            sql.Append("       D.CODFILEMP," + vbCrLf)
            sql.Append("       D.TIPDSNDSCBNF," + vbCrLf)
            sql.Append("       D.TIPFRMDSCBNF," + vbCrLf)
            sql.Append("       D.VLRSLDPMSFRN," + vbCrLf)
            sql.Append("       C.CODFRN   " + vbCrLf)
            sql.Append("FROM   MRT.T0118066 A" + vbCrLf)
            sql.Append("       INNER JOIN MRT.T0109059 B ON B.TIPDSNDSCBNF = A.TIPDSNDSCBNF" + vbCrLf)
            sql.Append("       INNER JOIN MRT.T0118058 C ON C.CODEMP = A.CODEMP" + vbCrLf)
            sql.Append("                                AND C.CODFILEMP = A.CODFILEMP" + vbCrLf)
            sql.Append("                                AND C.CODPMS = A.CODPMS" + vbCrLf)
            sql.Append("                                AND C.DATNGCPMS = A.DATNGCPMS" + vbCrLf)
            sql.Append("       INNER JOIN MRT.T0154021 D ON  D.CODEMP = C.CODEMP" + vbCrLf)
            sql.Append("                                AND D.CODFILEMP = C.CODFILEMP" + vbCrLf)
            sql.Append("                                AND D.CODPMS = C.CODPMS" + vbCrLf)
            sql.Append("                                AND D.DATNGCPMS = C.DATNGCPMS" + vbCrLf)
            sql.Append("       INNER JOIN MRT.T0113552 E ON A.TIPFRMDSCBNF = E.TIPFRMDSCBNF" + vbCrLf)
            sql.Append("       LEFT JOIN MRT.T0128592 F ON A.CODPMS = F.CODPMS" + vbCrLf)
            sql.Append("                                AND A.CODEMP = F.CODEMP" + vbCrLf)
            sql.Append("                                AND A.CODFILEMP = F.CODFILEMP" + vbCrLf)
            sql.Append("                                AND A.DATNGCPMS = F.DATNGCPMS" + vbCrLf)
            sql.Append("                                AND F.FLGSITNGCDUP IN ( 'A', 'I')" + vbCrLf)
            sql.Append("WHERE  D.NUMPEDCNCACOCMC =" + data.ConvertParameterName("NUMPEDCNCACOCMC") + vbCrLf)
            Return sql.ToString
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="data"></param>
        ''' <param name="NUMPEDCNCACOCMC"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Danilo Rafael]	14/5/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectObterFluxoCancelamentoAcordoPesquisa(ByVal data As IData, _
                                                                             ByVal NUMPEDCNCACOCMC As Decimal, _
                                                                             ByVal CODSTAAPV As Decimal) As String
            Dim sql As New System.Text.StringBuilder
            Dim clausulaWhere As New System.Text.StringBuilder

            sql.Append("Select DISTINCT " + vbCrLf)
            sql.Append("       A.NUMPEDCNCACOCMC," + vbCrLf)
            sql.Append("       A.CODSTAAPV," + vbCrLf)
            sql.Append("       Case A.CODSTAAPV" + vbCrLf)
            sql.Append("            WHEN 0 THEN 'EM APROVAÇÃO' " + vbCrLf)
            sql.Append("            WHEN 1 THEN 'APROVADO' " + vbCrLf)
            sql.Append("            WHEN 2 THEN 'REJEITADO' " + vbCrLf)
            sql.Append("            WHEN 3 THEN 'NOVO' " + vbCrLf)
            sql.Append("       End AS DESSTAAPV," + vbCrLf)
            sql.Append("       A.CODFRN," + vbCrLf)
            sql.Append("       B.NOMFRN," + vbCrLf)
            sql.Append("       A.DESOBSCNCACOCMC" + vbCrLf)
            sql.Append("FROM   MRT.T0154038 A " + vbCrLf)
            sql.Append("       INNER JOIN MRT.T0100426 B ON A.CODFRN = B.CODFRN" + vbCrLf)
            sql.Append("       LEFT  JOIN MRT.T0161591 C ON C.NUMFLUAPV  = A.NUMPEDCNCACOCMC" + vbCrLf)
            sql.Append("                                 AND C.CODSISINF = 11" + vbCrLf)
            sql.Append("       LEFT  JOIN MRT.T0153350 D ON D.CODFNCAPVNGC = C.CODEDEAPV" + vbCrLf)
            sql.Append("                                 AND D.DATDST IS NULL " + vbCrLf)

            If NUMPEDCNCACOCMC <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE    ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("NUMPEDCNCACOCMC=" + data.ConvertParameterName("NUMPEDCNCACOCMC") + vbCrLf)
            End If

            If CODSTAAPV <> 5 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE    ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("CODSTAAPV=" + data.ConvertParameterName("CODSTAAPV") + vbCrLf)
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
        ''' 	[Danilo Rafael]	14/5/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetDiretorAprovadorDeFluxoFluxoDeCancelamentosDeAcordo(ByVal data As IData) As String
            Dim sql As New System.Text.StringBuilder

            sql.Append("SELECT   DISTINCT " + vbCrLf)
            sql.Append("         F.CODFNC, " + vbCrLf)
            sql.Append("         H.NOMUSRRCF" + vbCrLf)
            sql.Append("FROM     MRT.T0154038 A " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0100426 B ON B.CODFRN = A.CODFRN " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0113625 C ON C.CODCPR = B.CODCPR " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0118570 D ON D.CODGERPRD = C.CODGERPRD " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0123183 E ON E.CODDRTCMP = D.CODDRTCMP " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0100981 F ON F.CODCPR = E.CODCPR " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0100981 G ON G.CODCPR = C.CODGERPRD " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0104596 H ON H.CODFNC = F.CODFNC " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0104596 I ON I.CODFNC = G.CODFNC " + vbCrLf)
            sql.Append("WHERE    A.NUMPEDCNCACOCMC =" + data.ConvertParameterName("NUMPEDCNCACOCMC") + vbCrLf)
            sql.Append("ORDER BY F.CODFNC" + vbCrLf)

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
        ''' 	[Danilo Rafael]	14/5/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetGerentesAprovadoresDeFluxoFluxoDeCancelamentosDeAcordo(ByVal data As IData) As String
            Dim sql As New System.Text.StringBuilder

            sql.Append("SELECT   DISTINCT " + vbCrLf)
            sql.Append("         G.CODFNC, " + vbCrLf)
            sql.Append("         I.NOMUSRRCF " + vbCrLf)
            sql.Append("FROM     MRT.T0154038 A " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0100426 B ON B.CODFRN = A.CODFRN " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0113625 C ON C.CODCPR = B.CODCPR " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0118570 D ON D.CODGERPRD = C.CODGERPRD " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0123183 E ON E.CODDRTCMP = D.CODDRTCMP " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0100981 F ON F.CODCPR = E.CODCPR " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0100981 G ON G.CODCPR = C.CODGERPRD " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0104596 H ON H.CODFNC = F.CODFNC " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0104596 I ON I.CODFNC = G.CODFNC " + vbCrLf)
            sql.Append("WHERE    A.NUMPEDCNCACOCMC =" + data.ConvertParameterName("NUMPEDCNCACOCMC") + vbCrLf)
            sql.Append("         AND F.CODFNC =" + data.ConvertParameterName("CODFNC") + vbCrLf)
            sql.Append("ORDER BY G.CODFNC" + vbCrLf)

            Return sql.ToString
        End Function


        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela T0161591 com base na sua chave primária.
        ''' Descrição da entidade:FLUXO DE APROVAÇÃO
        ''' </summary>
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    06/12/2007  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectFluxoAprovacao(ByVal data As IData) As String
            Dim sql As New System.Text.StringBuilder

            sql.Append("SELECT " + vbCrLf)
            sql.Append("         CODEDEAPV, " + vbCrLf)
            sql.Append("         CODEDEARZ, " + vbCrLf)
            sql.Append("         CODSISINF, " + vbCrLf)
            sql.Append("         DATHRAAPVFLU, " + vbCrLf)
            sql.Append("         DATHRAFLUAPV, " + vbCrLf)
            sql.Append("         DESMTVAPVFLUACOCMC, " + vbCrLf)
            sql.Append("         DESOBSAPV, " + vbCrLf)
            sql.Append("         NUMFLUAPV, " + vbCrLf)
            sql.Append("         NUMSEQFLUAPV, " + vbCrLf)
            sql.Append("         NUMSEQFLUAPVPEDOPN, " + vbCrLf)
            sql.Append("         NUMSEQNIVAPV, " + vbCrLf)
            sql.Append("         TIPSTAFLUAPV " + vbCrLf)
            sql.Append("FROM     MRT.T0161591 ")
            sql.Append("WHERE    CODSISINF=" + data.ConvertParameterName("CODSISINF") + vbCrLf)
            sql.Append("         AND NUMFLUAPV=" + data.ConvertParameterName("NUMFLUAPV") + vbCrLf)
            sql.Append("         AND NUMSEQFLUAPV=" + data.ConvertParameterName("NUMSEQFLUAPV") + vbCrLf)

            Return sql.ToString
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela T0161591 com base em atributos que não fazem parte da chave primária.
        ''' Descrição da entidade:FLUXO DE APROVAÇÃO
        ''' </summary>
        ''' <param name="data">Contexto do banco de dados</param>
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
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    06/12/2007  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectFluxoAprovacao(ByVal data As IData, _
                                                       ByVal CODEDEAPV As Decimal, _
                                                       ByVal CODEDEARZ As Decimal, _
                                                       ByVal CODSISINF As Decimal, _
                                                       ByVal DATHRAAPVFLU As String, _
                                                       ByVal DATHRAFLUAPV As String, _
                                                       ByVal NUMFLUAPV As Decimal, _
                                                       ByVal NUMSEQFLUAPV As Decimal, _
                                                       ByVal NUMSEQFLUAPVPEDOPN As Decimal, _
                                                       ByVal NUMSEQNIVAPV As Decimal, _
                                                       ByVal TIPSTAFLUAPV As String) As String
            Dim sql As New System.Text.StringBuilder
            Dim clausulaWhere As New System.Text.StringBuilder

            sql.Append("SELECT   DISTINCT " + vbCrLf)
            sql.Append("         A.CODEDEAPV, " + vbCrLf)
            sql.Append("         A.CODEDEARZ, " + vbCrLf)
            sql.Append("         A.CODSISINF, " + vbCrLf)
            sql.Append("         A.DATHRAAPVFLU, " + vbCrLf)
            sql.Append("         A.DATHRAFLUAPV, " + vbCrLf)
            sql.Append("         A.DESMTVAPVFLUACOCMC, " + vbCrLf)
            sql.Append("         A.DESOBSAPV, " + vbCrLf)
            sql.Append("         A.NUMFLUAPV, " + vbCrLf)
            sql.Append("         A.NUMSEQFLUAPV, " + vbCrLf)
            sql.Append("         A.NUMSEQFLUAPVPEDOPN, " + vbCrLf)
            sql.Append("         A.NUMSEQNIVAPV, " + vbCrLf)
            sql.Append("         A.TIPSTAFLUAPV " + vbCrLf)
            sql.Append("FROM     MRT.T0161591 A " + vbCrLf)
            sql.Append("         LEFT JOIN MRT.T0153350 B ON A.CODEDEAPV = B.CODFNCAPVNGC " + vbCrLf)

            If CODEDEAPV <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("(A.CODEDEAPV=" + data.ConvertParameterName("CODEDEAPV1") + " OR (B.CODFNCARZAPVNGC=" + data.ConvertParameterName("CODEDEAPV2") + " AND SYSTIMESTAMP BETWEEN B.DATINI AND B.DATFIM)) " + vbCrLf)
            End If
            If CODEDEARZ <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("A.CODEDEARZ=" + data.ConvertParameterName("CODEDEARZ") + vbCrLf)
            End If
            If CODSISINF <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("A.CODSISINF=" + data.ConvertParameterName("CODSISINF") + vbCrLf)
            End If
            If DATHRAAPVFLU.Trim() <> "" Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("Upper(A.DATHRAAPVFLU) Like " + data.ConvertParameterName("DATHRAAPVFLU") + vbCrLf)
            End If
            If DATHRAFLUAPV.Trim() <> "" Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("Upper(A.DATHRAFLUAPV) Like " + data.ConvertParameterName("DATHRAFLUAPV") + vbCrLf)
            End If
            If NUMFLUAPV <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("A.NUMFLUAPV=" + data.ConvertParameterName("NUMFLUAPV") + vbCrLf)
            End If
            If NUMSEQFLUAPV <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("A.NUMSEQFLUAPV=" + data.ConvertParameterName("NUMSEQFLUAPV") + vbCrLf)
            End If
            If NUMSEQFLUAPVPEDOPN <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("A.NUMSEQFLUAPVPEDOPN=" + data.ConvertParameterName("NUMSEQFLUAPVPEDOPN") + vbCrLf)
            End If
            If NUMSEQNIVAPV <> 0 Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("A.NUMSEQNIVAPV=" + data.ConvertParameterName("NUMSEQNIVAPV") + vbCrLf)
            End If
            If TIPSTAFLUAPV.Trim() <> "" Then
                If clausulaWhere.ToString = String.Empty Then
                    clausulaWhere.Append("WHERE ")
                Else
                    clausulaWhere.Append("         And ")
                End If
                clausulaWhere.Append("Upper(A.TIPSTAFLUAPV) = " + data.ConvertParameterName("TIPSTAFLUAPV") + vbCrLf)
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
        Friend Shared Function GetDiretoresAprovadoresTransferenciaVerbas(ByVal data As IData) As String
            Dim sql As New System.Text.StringBuilder

            sql.Append("SELECT   DISTINCT " + vbCrLf)
            sql.Append("         F.CODFNC, " + vbCrLf)
            sql.Append("         H.NOMUSRRCF " + vbCrLf)
            sql.Append("FROM     MRT.RLCTRNVBAFRN A " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0100426 B ON B.CODFRN = A.CODFRN " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0113625 C ON C.CODCPR = B.CODCPR " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0118570 D ON D.CODGERPRD = C.CODGERPRD " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0123183 E ON E.CODDRTCMP = D.CODDRTCMP " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0100981 F ON F.CODCPR = E.CODCPR " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0100981 G ON G.CODCPR = C.CODGERPRD " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0104596 H ON H.CODFNC = F.CODFNC " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0104596 I ON I.CODFNC = G.CODFNC " + vbCrLf)
            sql.Append("WHERE    NUMFLUAPV = " + data.ConvertParameterName("NUMFLUAPV") + vbCrLf)
            sql.Append("ORDER BY F.CODFNC " + vbCrLf)

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
        Friend Shared Function GetGerentesAprovadoresTransferenciaVerbas(ByVal data As IData) As String
            Dim sql As New System.Text.StringBuilder

            sql.Append("SELECT   DISTINCT " + vbCrLf)
            sql.Append("         G.CODFNC, " + vbCrLf)
            sql.Append("         I.NOMUSRRCF " + vbCrLf)
            sql.Append("FROM     MRT.RLCTRNVBAFRN A " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0100426 B ON B.CODFRN = A.CODFRN " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0113625 C ON C.CODCPR = B.CODCPR " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0118570 D ON D.CODGERPRD = C.CODGERPRD " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0123183 E ON E.CODDRTCMP = D.CODDRTCMP " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0100981 F ON F.CODCPR = E.CODCPR " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0100981 G ON G.CODCPR = C.CODGERPRD " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0104596 H ON H.CODFNC = F.CODFNC " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0104596 I ON I.CODFNC = G.CODFNC " + vbCrLf)
            sql.Append("WHERE    NUMFLUAPV = " + data.ConvertParameterName("NUMFLUAPV") + vbCrLf)
            sql.Append("         AND F.CODFNC = " + data.ConvertParameterName("CODFNC") + vbCrLf)
            sql.Append("ORDER BY G.CODFNC " + vbCrLf)

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
        ''' 	[Danilo Rafael]	15/5/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectObterFuncionariosDaControladoriaAprovadoresDeFluxoDeCancelamentoDeAcordos(ByVal data As IData) As String
            Dim sql As New System.Text.StringBuilder

            sql.Append("SELECT NUMSEQNIVAPV," + vbCrLf)
            sql.Append("       CODFNCAPVFIX " + vbCrLf)
            sql.Append("FROM   MRT.T0161581 " + vbCrLf)
            sql.Append("WHERE  CODSISINF =" + data.ConvertParameterName("CODSISINF") + vbCrLf)
            sql.Append("AND NUMSEQNIVAPV >= 3  " + vbCrLf)

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
        ''' 	[Danilo Rafael]	16/5/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectFluxosDeCancelamentoDeAcordos(ByVal data As IData) As String

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
            sql.Append("         B.DESOBSAPV" + vbCrLf)
            sql.Append("FROM     MRT.T0154038 A " + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0161591 B ON B.NUMFLUAPV = A.NUMPEDCNCACOCMC" + vbCrLf)
            sql.Append("         INNER JOIN MRT.T0100361 C ON C.CODFNC = B.CODEDEAPV " + vbCrLf)
            sql.Append("         LEFT JOIN MRT.T0100361 D ON D.CODFNC = B.CODEDEARZ" + vbCrLf)
            sql.Append("WHERE    B.CODSISINF =" + Constants.CODSISINF_FLUXO_DE_CANCELAMENTO_DE_ACORDO.ToString + vbCrLf)
            sql.Append("         AND B.NUMFLUAPV =" + data.ConvertParameterName("NUMPEDCNCACOCMC") + vbCrLf)
            sql.Append("ORDER BY NUMSEQNIVAPV" + vbCrLf)

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
        ''' 	[Danilo Rafael]	19/5/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectObterAcordoComDuplicidadeEmOutroFluxo(ByVal data As IData) As String

            Dim sql As New System.Text.StringBuilder

            sql.Append("SELECT B.CODEMP, " + vbCrLf)
            sql.Append("       B.CODFILEMP, " + vbCrLf)
            sql.Append("       B.CODPMS, " + vbCrLf)
            sql.Append("       B.DATNGCPMS, " + vbCrLf)
            sql.Append("       B.DATPRVRCBPMS, " + vbCrLf)
            sql.Append("       B.NUMPEDCNCACOCMC, " + vbCrLf)
            sql.Append("       B.TIPDSNDSCBNF, " + vbCrLf)
            sql.Append("       B.TIPFRMDSCBNF, " + vbCrLf)
            sql.Append("       B.VLRNGCPMS, " + vbCrLf)
            sql.Append("       B.VLRPGOPMS, " + vbCrLf)
            sql.Append("       B.VLRSLDPMSFRN " + vbCrLf)
            sql.Append("FROM   MRT.T0154038 A" + vbCrLf)
            sql.Append("       INNER JOIN MRT.T0154021 B ON B.NUMPEDCNCACOCMC = A.NUMPEDCNCACOCMC" + vbCrLf)
            sql.Append("WHERE  A.NUMPEDCNCACOCMC <> " + data.ConvertParameterName("NUMPEDCNCACOCMC") + vbCrLf)
            sql.Append("       AND B.CODPMS IN(SELECT B.CODPMS" + vbCrLf)
            sql.Append("                       FROM   MRT.T0154038 A" + vbCrLf)
            sql.Append("                              INNER JOIN MRT.T0154021 B ON B.NUMPEDCNCACOCMC = A.NUMPEDCNCACOCMC" + vbCrLf)
            sql.Append("                       WHERE  A.NUMPEDCNCACOCMC = " + data.ConvertParameterName("NUMPEDCNCACOCMC") + " )" + vbCrLf)
            sql.Append("       AND A.CODSTAAPV IN (0)" + vbCrLf)

            Return sql.ToString
        End Function
    End Class
End Namespace