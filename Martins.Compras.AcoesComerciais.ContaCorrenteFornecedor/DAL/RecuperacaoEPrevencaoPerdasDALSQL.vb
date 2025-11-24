Imports Martins.Data

Namespace DAL

    Friend Class RecuperacaoEPrevencaoPerdasDALSQL

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
        Friend Shared Function GetSelectRecuperacaoEPrevencaoPerdasSintetico(ByVal data As IData, _
                                                                             ByVal INDDVRVLRAPUARDFRN As Decimal) As String
            Dim sql As New System.Text.StringBuilder
            Dim clausulaWhere As String

            sql.Append("SELECT   C.CODFRN,                                                                                  ").Append(vbNewLine)
            sql.Append("         C.NOMFRN,                                                                                  ").Append(vbNewLine)
            sql.Append("         X.NUMCTTFRN,                                                                               ").Append(vbNewLine)
            sql.Append("         X.NUMCSLCTTFRN,                                                                            ").Append(vbNewLine)
            sql.Append("         X.TIPEDEABGMIX,                                                                            ").Append(vbNewLine)
            sql.Append("         X.CODEDEABGMIX,                                                                            ").Append(vbNewLine)
            sql.Append("         X.DATREFAPU,                                                                               ").Append(vbNewLine)
            sql.Append("         SUM(X.RECEBERCFA) AS RECEBERCFA,                                                           ").Append(vbNewLine)
            sql.Append("         SUM(X.RECEBERORI) AS RECEBERORI,                                                           ").Append(vbNewLine)
            sql.Append("         SUM(X.RECEBIDOACORDO) AS RECEBIDOACORDO,                                                   ").Append(vbNewLine)
            sql.Append("         SUM(X.RECEBERACORDO) AS RECEBERACORDO,                                                     ").Append(vbNewLine)
            sql.Append("         SUM(X.ACORDOTOTAL) AS ACORDOTOTAL,                                                         ").Append(vbNewLine)
            sql.Append("         SUM(X.NEGOCIADOACORDO) AS NEGOCIADOACORDO,                                                 ").Append(vbNewLine)
            sql.Append("         SUM(X.PAGOACORDO) AS PAGOACORDO                                                            ").Append(vbNewLine)
            sql.Append("FROM     (select  a.NUMCTTFRN,                                                                      ").Append(vbNewLine)
            sql.Append("                  a.NUMCSLCTTFRN,                                                                   ").Append(vbNewLine)
            sql.Append("                  a.TIPEDEABGMIX,                                                                   ").Append(vbNewLine)
            sql.Append("                  a.CODEDEABGMIX ,                                                                  ").Append(vbNewLine)
            sql.Append("                  a.DATREFAPU,                                                                      ").Append(vbNewLine)
            sql.Append("                  sum(a.VLRRCBEFTFXA) as RECEBERCFA,                                                ").Append(vbNewLine)
            sql.Append("                  0 AS RECEBERORI,                                                                  ").Append(vbNewLine)
            sql.Append("                  sum(a.VLRPGOPMS) AS RECEBIDOACORDO,                                               ").Append(vbNewLine)
            sql.Append("                  sum(a.VLRNGCPMS) NEGOCIADOACORDO,                                                 ").Append(vbNewLine)
            sql.Append("                  SUM(A.VLRNGCPMS - A.VLRPGOPMS) AS RECEBERACORDO,                                  ").Append(vbNewLine)
            sql.Append("                  SUM(a.VLRPGOPMS + (A.VLRNGCPMS - A.VLRPGOPMS)) AS ACORDOTOTAL ,                   ").Append(vbNewLine)
            sql.Append("                  sum(a.VLRPGOPMS) PAGOACORDO                                                       ").Append(vbNewLine)
            sql.Append("         from     MRT.HSTCFAAPUARDFRN a                                                             ").Append(vbNewLine)
            sql.Append("         where    A.NUMCTTFRN = " & data.ConvertParameterName("NUMCTTFRN1") & "                     ").Append(vbNewLine)
            sql.Append("                  And A.TIPLMTHSTCFAARDFRN =" & data.ConvertParameterName("TIPLMTHSTCFAARDFRN") & " ").Append(vbNewLine)

            If INDDVRVLRAPUARDFRN > 0 Then
                clausulaWhere &= "And A.INDDVRVLRAPUARDFRN =" & data.ConvertParameterName("INDDVRVLRAPUARDFRN1") & vbCrLf
            End If

            sql.Append(clausulaWhere)
            clausulaWhere = String.Empty

            sql.Append("         group by a.NUMCTTFRN,                                                                      ").Append(vbNewLine)
            sql.Append("                  a.NUMCSLCTTFRN,                                                                   ").Append(vbNewLine)
            sql.Append("                  a.TIPEDEABGMIX,                                                                   ").Append(vbNewLine)
            sql.Append("                  a.CODEDEABGMIX,                                                                   ").Append(vbNewLine)
            sql.Append("                  a.DATREFAPU                                                                       ").Append(vbNewLine)
            sql.Append("         UNION ALL                                                                                  ").Append(vbNewLine)
            sql.Append("         select   a.NUMCTTFRN ,                                                                     ").Append(vbNewLine)
            sql.Append("                  a.NUMCSLCTTFRN ,                                                                  ").Append(vbNewLine)
            sql.Append("                  a.TIPEDEABGMIX ,                                                                  ").Append(vbNewLine)
            sql.Append("                  a.CODEDEABGMIX ,                                                                  ").Append(vbNewLine)
            sql.Append("                  a.DATREFAPU,                                                                      ").Append(vbNewLine)
            sql.Append("                  0 AS RECEBERCFA,                                                                  ").Append(vbNewLine)
            sql.Append("                  sum(a.VLRRCBEFTFXA) as RECEBERORI,                                                ").Append(vbNewLine)
            sql.Append("                  0 AS RECEBIDO,                                                                    ").Append(vbNewLine)
            sql.Append("                  0 NEGOCIADOACORDO,                                                                ").Append(vbNewLine)
            sql.Append("                  0 AS RECEBERACORDO,                                                               ").Append(vbNewLine)
            sql.Append("                  0 AS ACORDOTOTAL,                                                                 ").Append(vbNewLine)
            sql.Append("                  0 AS PAGOACORDO                                                                   ").Append(vbNewLine)
            sql.Append("         from     MRT.HSTCFAAPUARDFRN a                                                             ").Append(vbNewLine)
            sql.Append("         where    A.NUMCTTFRN = " & data.ConvertParameterName("NUMCTTFRN2") & "                     ").Append(vbNewLine)
            sql.Append("                  And A.TIPLMTHSTCFAARDFRN =  " & Constants.TIPLMTHSTCFAARDFRN & "                  ").Append(vbNewLine)

            If INDDVRVLRAPUARDFRN > 0 Then
                clausulaWhere &= "And A.INDDVRVLRAPUARDFRN =" & data.ConvertParameterName("INDDVRVLRAPUARDFRN2") & vbCrLf
            End If

            sql.Append(clausulaWhere)

            sql.Append("         group by a.NUMCTTFRN,                                                                      ").Append(vbNewLine)
            sql.Append("                  a.NUMCSLCTTFRN,                                                                   ").Append(vbNewLine)
            sql.Append("                  a.TIPEDEABGMIX,                                                                   ").Append(vbNewLine)
            sql.Append("                  a.CODEDEABGMIX,                                                                   ").Append(vbNewLine)
            sql.Append("                  a.DATREFAPU) X,                                                                   ").Append(vbNewLine)
            sql.Append("         mrt.t0124945 b,                                                                            ").Append(vbNewLine)
            sql.Append("         mrt.t0100426 c                                                                             ").Append(vbNewLine)
            sql.Append("where    b.numcttfrn = X.numcttfrn                                                                  ").Append(vbNewLine)
            sql.Append("         and c.codfrn = b.codfrn                                                                    ").Append(vbNewLine)
            sql.Append("         and c.codemp = " & Constants.CODEMP & "                                                    ").Append(vbNewLine)
            sql.Append("GROUP BY C.CODFRN,                                                                                  ").Append(vbNewLine)
            sql.Append("         C.NOMFRN,                                                                                  ").Append(vbNewLine)
            sql.Append("         X.NUMCTTFRN,                                                                               ").Append(vbNewLine)
            sql.Append("         X.NUMCSLCTTFRN,                                                                            ").Append(vbNewLine)
            sql.Append("         X.TIPEDEABGMIX,                                                                            ").Append(vbNewLine)
            sql.Append("         X.CODEDEABGMIX,                                                                            ").Append(vbNewLine)
            sql.Append("         X.DATREFAPU                                                                                ").Append(vbNewLine)
            sql.Append("HAVING ( ( ABS(SUM(X.RECEBERCFA) - SUM(X.RECEBERORI)) > 1 )  OR                                     ").Append(vbNewLine)
            sql.Append("         ( ABS(SUM(X.RECEBERCFA) - SUM(X.NEGOCIADOACORDO) ) > 1 ) OR                                ").Append(vbNewLine)
            sql.Append("         ( ABS(SUM( X.RECEBERCFA - X.PAGOACORDO ) - SUM(X.RECEBERACORDO)) > 1 ) OR                  ").Append(vbNewLine)
            sql.Append("         ( ABS(SUM(X.NEGOCIADOACORDO) - SUM(X.ACORDOTOTAL)) > 1 )                                   ").Append(vbNewLine)
            sql.Append("       )                                                                                            ").Append(vbNewLine)

            Return sql.ToString()
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
        Friend Shared Function GetSelectRecuperacaoEPrevencaoPerdasAnalitico(ByVal data As IData, _
                                                                             ByVal INDDVRVLRAPUARDFRN As Decimal, _
                                                                             ByVal DATREFAPU As Date, _
                                                                             ByVal NUMCSLCTTFRN As Decimal) As String
            Dim sql As New System.Text.StringBuilder
            Dim clausulaWhere As String

            sql.Append("SELECT   C.CODFRN,                                                                                  ").Append(vbNewLine)
            sql.Append("         C.NOMFRN,                                                                                  ").Append(vbNewLine)
            sql.Append("         X.NUMCTTFRN,                                                                               ").Append(vbNewLine)
            sql.Append("         X.NUMCSLCTTFRN,                                                                            ").Append(vbNewLine)
            sql.Append("         X.TIPEDEABGMIX,                                                                            ").Append(vbNewLine)
            sql.Append("         X.CODEDEABGMIX,                                                                            ").Append(vbNewLine)
            sql.Append("         X.DATREFAPU,                                                                               ").Append(vbNewLine)
            sql.Append("         SUM(X.BASECALCFA) AS BASECALCFA,                                                           ").Append(vbNewLine)
            sql.Append("         SUM(X.BASECALORI) AS BASECALORI,                                                           ").Append(vbNewLine)
            sql.Append("         SUM(X.BASEANTCFA) AS BASEANTCFA,                                                           ").Append(vbNewLine)
            sql.Append("         SUM(X.BASEANTORI) AS BASEANTORI,                                                           ").Append(vbNewLine)
            sql.Append("         SUM(X.PERCRSCFA) AS PERCRSCFA,                                                             ").Append(vbNewLine)
            sql.Append("         SUM(X.PERCRSORI) AS PERCRSORI,                                                             ").Append(vbNewLine)
            sql.Append("         SUM(X.FXACFA) AS FXACFA,                                                                   ").Append(vbNewLine)
            sql.Append("         SUM(X.FXAORI) AS FXAORI,                                                                   ").Append(vbNewLine)
            sql.Append("         SUM(X.PERAPUCFA) AS PERAPUCFA,                                                             ").Append(vbNewLine)
            sql.Append("         SUM(X.PERAPUORI) AS PERAPUORI,                                                             ").Append(vbNewLine)
            sql.Append("         SUM(X.RECEBERCFA) AS RECEBERCFA,                                                           ").Append(vbNewLine)
            sql.Append("         SUM(X.RECEBERORI) AS RECEBERORI,                                                           ").Append(vbNewLine)
            sql.Append("         SUM(X.NEGOCIADOACORDO) AS NEGOCIADOACORDO,                                                 ").Append(vbNewLine)
            sql.Append("         SUM(X.PAGOACORDO) AS PAGOACORDO,                                                           ").Append(vbNewLine)
            sql.Append("         SUM(X.RECEBERACORDO) AS RECEBERACORDO,                                                     ").Append(vbNewLine)
            sql.Append("         SUM(X.ACORDOTOTAL) AS ACORDOTOTAL                                                          ").Append(vbNewLine)
            sql.Append("FROM    (select   a.NUMCTTFRN,                                                                      ").Append(vbNewLine)
            sql.Append("                  a.NUMCSLCTTFRN ,                                                                  ").Append(vbNewLine)
            sql.Append("                  a.TIPEDEABGMIX ,                                                                  ").Append(vbNewLine)
            sql.Append("                  a.CODEDEABGMIX,                                                                   ").Append(vbNewLine)
            sql.Append("                  a.DATREFAPU,                                                                      ").Append(vbNewLine)
            sql.Append("                  sum(a.VLRBSECALAPUVLRRCB) BASECALCFA,                                             ").Append(vbNewLine)
            sql.Append("                  sum(a.VLRBSECALIDCPODANT) BASEANTCFA,                                             ").Append(vbNewLine)
            sql.Append("                  sum(a.PERCRS) PERCRSCFA,                                                          ").Append(vbNewLine)
            sql.Append("                  sum(a.CODFXAAVL) FXACFA,                                                          ").Append(vbNewLine)
            sql.Append("                  sum(a.PERAPUVLRRCBREFFXA) PERAPUCFA,                                              ").Append(vbNewLine)
            sql.Append("                  sum(a.VLRRCBEFTFXA) RECEBERCFA,                                                   ").Append(vbNewLine)
            sql.Append("                  sum(a.VLRNGCPMS) NEGOCIADOACORDO,                                                 ").Append(vbNewLine)
            sql.Append("                  sum(a.VLRPGOPMS) PAGOACORDO,                                                      ").Append(vbNewLine)
            'sql.Append("                  sum(A.VLRNGCPMS - a.VLRPGOPMS) RECEBERACORDO,                                     ").Append(vbNewLine)
            'sql.Append("                  SUM(a.VLRPGOPMS + (A.VLRNGCPMS - A.VLRPGOPMS)) AS ACORDOTOTAL,                    ").Append(vbNewLine)
            sql.Append("                  sum(A.VLRRCBEFTFXA - a.VLRPGOPMS) RECEBERACORDO,                                     ").Append(vbNewLine)
            sql.Append("                  SUM(a.VLRPGOPMS + (A.VLRRCBEFTFXA - A.VLRPGOPMS)) AS ACORDOTOTAL,                    ").Append(vbNewLine)
            sql.Append("                  0 AS BASECALORI,                                                                  ").Append(vbNewLine)
            sql.Append("                  0 AS BASEANTORI,                                                                  ").Append(vbNewLine)
            sql.Append("                  0 AS PERCRSORI,                                                                   ").Append(vbNewLine)
            sql.Append("                  0 AS FXAORI,                                                                      ").Append(vbNewLine)
            sql.Append("                  0 AS PERAPUORI,                                                                   ").Append(vbNewLine)
            sql.Append("                  0 AS RECEBERORI                                                                   ").Append(vbNewLine)
            sql.Append("         from     MRT.HSTCFAAPUARDFRN a                                                             ").Append(vbNewLine)
            sql.Append("         where    A.NUMCTTFRN = " & data.ConvertParameterName("NUMCTTFRN1") & "                     ").Append(vbNewLine)
            sql.Append("                  And A.TIPLMTHSTCFAARDFRN =" & data.ConvertParameterName("TIPLMTHSTCFAARDFRN") & " ").Append(vbNewLine)

            If INDDVRVLRAPUARDFRN > 0 Then
                clausulaWhere &= "And A.INDDVRVLRAPUARDFRN =" & data.ConvertParameterName("INDDVRVLRAPUARDFRN1") & vbCrLf
            End If

            If Not DATREFAPU = Nothing Then
                clausulaWhere &= "And A.DATREFAPU =" & data.ConvertParameterName("DATREFAPU1") & vbCrLf
            End If
            If NUMCSLCTTFRN > 0 Then
                clausulaWhere &= "And A.NUMCSLCTTFRN =" & data.ConvertParameterName("NUMCSLCTTFRN1") & vbCrLf
            End If

            sql.Append(clausulaWhere)
            clausulaWhere = String.Empty

            sql.Append("         group by a.NUMCTTFRN,                                                                      ").Append(vbNewLine)
            sql.Append("                  a.NUMCSLCTTFRN,                                                                   ").Append(vbNewLine)
            sql.Append("                  a.TIPEDEABGMIX,                                                                   ").Append(vbNewLine)
            sql.Append("                  a.CODEDEABGMIX,                                                                   ").Append(vbNewLine)
            sql.Append("                  a.DATREFAPU                                                                       ").Append(vbNewLine)
            sql.Append("         UNION ALL                                                                                  ").Append(vbNewLine)
            sql.Append("         select   a.NUMCTTFRN ,                                                                     ").Append(vbNewLine)
            sql.Append("                  a.NUMCSLCTTFRN,                                                                   ").Append(vbNewLine)
            sql.Append("                  a.TIPEDEABGMIX,                                                                   ").Append(vbNewLine)
            sql.Append("                  a.CODEDEABGMIX,                                                                   ").Append(vbNewLine)
            sql.Append("                  a.DATREFAPU,                                                                      ").Append(vbNewLine)
            sql.Append("                  0 AS BASECALCFA,                                                                  ").Append(vbNewLine)
            sql.Append("                  0 AS BASEANTCFA,                                                                  ").Append(vbNewLine)
            sql.Append("                  0 AS PERCRSCFA,                                                                   ").Append(vbNewLine)
            sql.Append("                  0 AS FXACFA,                                                                      ").Append(vbNewLine)
            sql.Append("                  0 AS PERAPUCFA,                                                                   ").Append(vbNewLine)
            sql.Append("                  0 AS RECEBERCFA,                                                                  ").Append(vbNewLine)
            sql.Append("                  0 AS NEGOCIADOACORDO,                                                             ").Append(vbNewLine)
            sql.Append("                  0 AS PAGOACORDO,                                                                  ").Append(vbNewLine)
            sql.Append("                  0 AS RECEBERACORDO,                                                               ").Append(vbNewLine)
            sql.Append("                  0 AS ACORDOTOTAL,                                                                 ").Append(vbNewLine)
            sql.Append("                  sum(a.VLRBSECALAPUVLRRCB) BASECALORI,                                             ").Append(vbNewLine)
            sql.Append("                  sum(a.VLRBSECALIDCPODANT) BASEANTORI,                                             ").Append(vbNewLine)
            sql.Append("                  sum(a.PERCRS) PERCRSORI,                                                          ").Append(vbNewLine)
            sql.Append("                  sum(a.CODFXAAVL) FXAORI,                                                          ").Append(vbNewLine)
            sql.Append("                  sum(a.PERAPUVLRRCBREFFXA) PERAPUORI,                                              ").Append(vbNewLine)
            sql.Append("                  sum(a.VLRRCBEFTFXA) RECEBERORI                                                    ").Append(vbNewLine)
            sql.Append("         from     MRT.HSTCFAAPUARDFRN a                                                             ").Append(vbNewLine)
            sql.Append("         where    A.NUMCTTFRN = " & data.ConvertParameterName("NUMCTTFRN2") & "                     ").Append(vbNewLine)
            sql.Append("                  And A.TIPLMTHSTCFAARDFRN =  " & Constants.TIPLMTHSTCFAARDFRN & "                  ").Append(vbNewLine)

            If INDDVRVLRAPUARDFRN > 0 Then
                clausulaWhere &= "And A.INDDVRVLRAPUARDFRN =" & data.ConvertParameterName("INDDVRVLRAPUARDFRN2") & vbCrLf
            End If

            If Not DATREFAPU = Nothing Then
                clausulaWhere &= "And A.DATREFAPU =" & data.ConvertParameterName("DATREFAPU2") & vbCrLf
            End If
            If NUMCSLCTTFRN > 0 Then
                clausulaWhere &= "And A.NUMCSLCTTFRN =" & data.ConvertParameterName("NUMCSLCTTFRN2") & vbCrLf
            End If

            sql.Append(clausulaWhere)

            sql.Append("         group by a.NUMCTTFRN,                                                                      ").Append(vbNewLine)
            sql.Append("                  a.NUMCSLCTTFRN,                                                                   ").Append(vbNewLine)
            sql.Append("                  a.TIPEDEABGMIX,                                                                   ").Append(vbNewLine)
            sql.Append("                  a.CODEDEABGMIX,                                                                   ").Append(vbNewLine)
            sql.Append("                  a.DATREFAPU) X,                                                                   ").Append(vbNewLine)
            sql.Append("         mrt.t0124945 b,                                                                            ").Append(vbNewLine)
            sql.Append("         mrt.t0100426 c                                                                             ").Append(vbNewLine)
            sql.Append("where    b.numcttfrn = X.numcttfrn                                                                  ").Append(vbNewLine)
            sql.Append("         and c.codfrn = b.codfrn                                                                    ").Append(vbNewLine)
            sql.Append("         and c.codemp = " & Constants.CODEMP & "                                                    ").Append(vbNewLine)
            sql.Append("GROUP BY C.CODFRN,                                                                                  ").Append(vbNewLine)
            sql.Append("         C.NOMFRN,                                                                                  ").Append(vbNewLine)
            sql.Append("         X.NUMCTTFRN,                                                                               ").Append(vbNewLine)
            sql.Append("         X.NUMCSLCTTFRN,                                                                            ").Append(vbNewLine)
            sql.Append("         X.TIPEDEABGMIX,                                                                            ").Append(vbNewLine)
            sql.Append("         X.CODEDEABGMIX,                                                                            ").Append(vbNewLine)
            sql.Append("         X.DATREFAPU                                                                                ").Append(vbNewLine)
            sql.Append("HAVING   (                                                                                          ").Append(vbNewLine)
            sql.Append("            ( ABS(SUM(X.RECEBERCFA) - SUM(X.RECEBERORI)) > 1 )  OR                                  ").Append(vbNewLine)
            sql.Append("              (( ABS(SUM(X.BASECALCFA) - SUM(X.BASECALORI)) > 1 )  AND                              ").Append(vbNewLine)
            sql.Append("                  (                                                                                 ").Append(vbNewLine)
            sql.Append("                      ( ABS(SUM(X.RECEBERCFA) - SUM(X.RECEBERORI)) > 1 ) OR                         ").Append(vbNewLine)
            sql.Append("                      ( ABS(SUM(X.RECEBERCFA) - SUM(X.NEGOCIADOACORDO) ) > 1 ) OR                   ").Append(vbNewLine)
            sql.Append("                      ( ABS(SUM( X.RECEBERCFA - X.PAGOACORDO ) - SUM(X.RECEBERACORDO)) > 1 ) OR     ").Append(vbNewLine)
            sql.Append("                      ( ABS(SUM(X.NEGOCIADOACORDO) - SUM(X.ACORDOTOTAL)) > 1 )                      ").Append(vbNewLine)
            sql.Append("                  )                                                                                 ").Append(vbNewLine)
            sql.Append("              ) OR                                                                                  ").Append(vbNewLine)
            sql.Append("            ( ABS(SUM(X.RECEBERCFA) - SUM(X.NEGOCIADOACORDO) ) > 1 ) OR                             ").Append(vbNewLine)
            sql.Append("            ( ABS(SUM( X.RECEBERCFA - X.PAGOACORDO ) - SUM(X.RECEBERACORDO)) > 1 ) OR               ").Append(vbNewLine)
            sql.Append("            ( ABS(SUM(X.NEGOCIADOACORDO) - SUM(X.ACORDOTOTAL)) > 1 )                                ").Append(vbNewLine)
            sql.Append("         )                                                                                          ").Append(vbNewLine)

            Return sql.ToString()
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
        Friend Shared Function GetSelectNotasPeriodo(ByVal data As IData) As String

            Dim sql As New System.Text.StringBuilder

            sql.Append("WITH CONTRATO AS                                                                            ").Append(vbNewLine)
            sql.Append("              (SELECT DISTINCT CODFRN,                                                      ").Append(vbNewLine)
            sql.Append("                               DATINIPODVGRCTTFRN AS DATINI,                                ").Append(vbNewLine)
            sql.Append("                               DATVNCCTTFRN AS DATFIM                                       ").Append(vbNewLine)
            sql.Append("               FROM            MRT.T0124945                                                 ").Append(vbNewLine)
            sql.Append("               WHERE           CODFRN = " & data.ConvertParameterName("CODFRN") & "         ").Append(vbNewLine)
            sql.Append("               AND             NUMCTTFRN = " & data.ConvertParameterName("NUMCTTFRN") & ")  ").Append(vbNewLine)
            sql.Append("SELECT         A.DATEMSNOTFSC,                                                              ").Append(vbNewLine)
            sql.Append("               A.NUMNOTFSCFRN,                                                              ").Append(vbNewLine)
            sql.Append("               A.CODMER,                                                                    ").Append(vbNewLine)
            sql.Append("               C.DESMER,                                                                    ").Append(vbNewLine)
            sql.Append("               SUM((A.VLRCFAITENOTFSC * A.QDEDVLITENOTFSC) -                                ").Append(vbNewLine)
            sql.Append("                  A.VLRICMITENOTFSC ) AS VLRLIQITENOT,                                      ").Append(vbNewLine)
            sql.Append("               SUM((A.VLRCFAITENOTFSC * A.QDEDVLITENOTFSC) +                                ").Append(vbNewLine)
            sql.Append("                  (A.VLRSBTTBTITENOTFSC * A.QDEDVLITENOTFSC ) +                             ").Append(vbNewLine)
            sql.Append("                  (A.VLRIPIITENOTFSC * A.QDEDVLITENOTFSC) ) AS VLRBRTITENOT,                ").Append(vbNewLine)
            sql.Append("               SUM(A.QDEDVLITENOTFSC) AS QDEITENOT,                                         ").Append(vbNewLine)
            sql.Append("               SUM(A.VLRSBTTBTITENOTFSC * A.QDEDVLITENOTFSC ) AS VLRSTBITENOT,              ").Append(vbNewLine)
            sql.Append("               SUM(A.VLRIPIITENOTFSC *  A.QDEDVLITENOTFSC) AS VLRIPIITENOT,                 ").Append(vbNewLine)
            sql.Append("               SUM(A.VLRICMITENOTFSC) AS VLRICMITENOT                                       ").Append(vbNewLine)
            sql.Append("FROM           MRT.T0125054 A,                                                              ").Append(vbNewLine)
            sql.Append("               CONTRATO B,                                                                  ").Append(vbNewLine)
            sql.Append("               MRT.T0100086 C                                                               ").Append(vbNewLine)
            sql.Append("WHERE          A.TIPOPEGRCHST = 'P'                                                         ").Append(vbNewLine)
            sql.Append("               AND B.CODFRN = A.CODFRN                                                      ").Append(vbNewLine)
            sql.Append("               AND A.DATEMSNOTFSC BETWEEN  B.DATINI AND B.DATFIM                            ").Append(vbNewLine)
            sql.Append("               AND C.CODMER = A.CODMER                                                      ").Append(vbNewLine)
            sql.Append("               AND C.CODEMP = 1                                                             ").Append(vbNewLine)
            sql.Append("GROUP BY       A.DATEMSNOTFSC,                                                              ").Append(vbNewLine)
            sql.Append("               A.NUMNOTFSCFRN,                                                              ").Append(vbNewLine)
            sql.Append("               A.CODMER,                                                                    ").Append(vbNewLine)
            sql.Append("               C.DESMER                                                                     ").Append(vbNewLine)
            sql.Append("ORDER BY       A.DATEMSNOTFSC,                                                              ").Append(vbNewLine)
            sql.Append("               A.NUMNOTFSCFRN,                                                              ").Append(vbNewLine)
            sql.Append("               A.CODMER                                                                     ").Append(vbNewLine)

            Return sql.ToString()
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
        Friend Shared Function GetSelectRecuperacaoEPrevencaoPerdasClausulas(ByVal data As IData) As String

            Dim sql As New System.Text.StringBuilder
            Dim clausulaWhere As String


            sql.Append("SELECT DISTINCT A.NUMCSLCTTFRN, 				                                ").Append(vbNewLine)
            sql.Append("	            C.DESCSLCTTFRN 					                                ").Append(vbNewLine)
            sql.Append("FROM 		    MRT.HSTCFAAPUARDFRN A,			                                ").Append(vbNewLine)
            sql.Append("		        MRT.T0124945 B, 				                                ").Append(vbNewLine)
            sql.Append("                MRT.T0124953 C  				                                ").Append(vbNewLine)
            sql.Append("WHERE 		    B.NUMCTTFRN = A.NUMCTTFRN		                                ").Append(vbNewLine)
            sql.Append("                AND C.NUMCSLCTTFRN = A.NUMCSLCTTFRN 	                        ").Append(vbNewLine)
            sql.Append("                AND A.NUMCTTFRN =" & data.ConvertParameterName("NUMCTTFRN") & " ").Append(vbNewLine)

            Return sql.ToString()
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
        Friend Shared Function GetSelectRecuperacaoEPrevencaoPerdasDataApuracao(ByVal data As IData) As String

            Dim sql As New System.Text.StringBuilder
            Dim clausulaWhere As String

            sql.Append("SELECT DISTINCT A.DATREFAPU 				                                    ").Append(vbNewLine)
            sql.Append("FROM 		    MRT.HSTCFAAPUARDFRN A,		                                    ").Append(vbNewLine)
            sql.Append("		        MRT.T0124945 B 				                                    ").Append(vbNewLine)
            sql.Append("WHERE 		    B.NUMCTTFRN = A.NUMCTTFRN		                                ").Append(vbNewLine)
            sql.Append("                AND B.NUMCTTFRN = A.NUMCSLCTTFRN 	                            ").Append(vbNewLine)
            sql.Append("                AND A.NUMCTTFRN = " & data.ConvertParameterName("NUMCTTFRN") & "").Append(vbNewLine)

            Return sql.ToString()
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
        Friend Shared Function GetSelectAcordosCanceladosPerdas(ByVal data As IData) As String

            Dim sql As New System.Text.StringBuilder

            sql.Append("SELECT DISTINCT B.CODFRN, 									                                                                                                    ").Append(vbNewLine)
            sql.Append("	            B.NOMFRN, 									                                                                                                    ").Append(vbNewLine)
            sql.Append("		        A.CODPMS, 									                                                                                                    ").Append(vbNewLine)
            sql.Append("		        A.CODSITPMS, 								                                                                                                    ").Append(vbNewLine)
            sql.Append("	            F.DATNGCPMS, 								                                                                                                    ").Append(vbNewLine)
            sql.Append("	            F.DATPRVRCBPMS, 							                    	                                                                            ").Append(vbNewLine)
            sql.Append("		        H.TIPDSNDSCBNF, 								                                                                                                ").Append(vbNewLine)
            sql.Append("		        lower(H.TIPDSNDSCBNF || '-' || H.DESDSNDSCBNF) DESDSNDSCBNF,                                                                                    ").Append(vbNewLine)
            sql.Append("       	        F.VLRNGCPMS, 								                                                                                                    ").Append(vbNewLine)
            sql.Append("		        F.VLRPGOPMS, 								                                                                                                    ").Append(vbNewLine)
            sql.Append("		        F.VLREFTPMS, 								                                                                                                    ").Append(vbNewLine)
            sql.Append("		        A.DATCNCPED AS DATCNCPED, 						                       	                                                                        ").Append(vbNewLine)
            sql.Append("       	        A.NOMACSUSRSIS, 								                                                                                                ").Append(vbNewLine)
            sql.Append("		        NVL( F.VLRPDAPMS,0) AS VLRPDAPMS, 				                		                                                                        ").Append(vbNewLine)
            sql.Append("       	        lower(A.DESMSGUSR) AS DESJSTCNCVLRARDCMC      			                		                                                                ").Append(vbNewLine)
            sql.Append("FROM 	        MRT.T0118058 A 								                                                                                                    ").Append(vbNewLine)
            sql.Append("		        INNER JOIN MRT.T0100426 B ON B.CODFRN = A.CODFRN 					                        	                                                ").Append(vbNewLine)
            sql.Append("  			               AND B.CODEMP = 1 					                        	                                                                    ").Append(vbNewLine)
            sql.Append("                           AND (B.CODFRN = " & data.ConvertParameterName("CODFRN1") & " OR 0 = " & data.ConvertParameterName("CODFRN2") & ")                    ").Append(vbNewLine)
            sql.Append("		        INNER JOIN MRT.T0113625 D ON D.CODCPR = B.CODCPR 						                                                                        ").Append(vbNewLine)
            sql.Append("                           AND (D.CODCPR = " & data.ConvertParameterName("CODCPR1") & " OR 0 = " & data.ConvertParameterName("CODCPR2") & ")                    ").Append(vbNewLine)
            sql.Append("		        INNER JOIN MRT.T0118570 E ON E.CODGERPRD = D.CODGERPRD 					                                                                        ").Append(vbNewLine)
            sql.Append("                           AND (E.CODDIVCMP = " & data.ConvertParameterName("CODDIVCMP1") & " OR 0 = " & data.ConvertParameterName("CODDIVCMP2") & ")           ").Append(vbNewLine)
            sql.Append("		        INNER JOIN MRT.T0118066 F ON F.CODPMS = A.CODPMS 						                                                                        ").Append(vbNewLine)
            sql.Append("  			               AND F.DATNGCPMS = A.DATNGCPMS 					                                                                                    ").Append(vbNewLine)
            sql.Append("  			               AND F.CODEMP = A.CODEMP 						                                                                                        ").Append(vbNewLine)
            sql.Append("  			               AND F.CODFILEMP = A.CODFILEMP 					                                                                                    ").Append(vbNewLine)
            sql.Append("		        INNER JOIN MRT.T0109059 H ON H.TIPDSNDSCBNF = F.TIPDSNDSCBNF 					                                                                ").Append(vbNewLine)
            sql.Append("WHERE           A.DATCNCPED BETWEEN " & data.ConvertParameterName("DTINICIAL1") & "                                                                             ").Append(vbNewLine)
            sql.Append("		        AND " & data.ConvertParameterName("DTFINAL1") & "                                                                                               ").Append(vbNewLine)
            sql.Append("		        AND A.CODSITPMS NOT IN (0,1,5,6) 						                                                                                        ").Append(vbNewLine)
            sql.Append("UNION ALL 											                                                                                                            ").Append(vbNewLine)
            sql.Append("SELECT DISTINCT B.CODFRN,  							                        		                                                                            ").Append(vbNewLine)
            sql.Append("		        B.NOMFRN,								                            	                                                                        ").Append(vbNewLine)
            sql.Append("		        A.CODPMS,								                              	                                                                        ").Append(vbNewLine)
            sql.Append("		        A.CODSITPMS, 								                                                                                                    ").Append(vbNewLine)
            sql.Append("		        F.DATNGCPMS, 								                                                                                                    ").Append(vbNewLine)
            sql.Append("		        F.DATPRVRCBPMS, 							                        	                                                                        ").Append(vbNewLine)
            sql.Append("		        H.TIPDSNDSCBNF, 							                        	                                                                        ").Append(vbNewLine)
            sql.Append("		        H.DESDSNDSCBNF, 							                           	                                                                        ").Append(vbNewLine)
            sql.Append("       	        F.VLRNGCPMS, 								                                                                                                    ").Append(vbNewLine)
            sql.Append("		        F.VLRPGOPMS, 								                                                                                                    ").Append(vbNewLine)
            sql.Append("		        F.VLREFTPMS, 								                                                                                                    ").Append(vbNewLine)
            sql.Append("		        G.DATALTPMS AS DATCNCPMS, 							                                                                                            ").Append(vbNewLine)
            sql.Append("       	        G.NOMACSUSRSIS, 								                                                                                                ").Append(vbNewLine)
            sql.Append("		        G.VLRPGOPMS AS VLRPDAPMS, 							                                                                                            ").Append(vbNewLine)
            sql.Append("       	        CASE WHEN NVL  (G.DESJSTCNCVLRARDCMC, ' ') = ' ' 				                                                                                ").Append(vbNewLine)
            sql.Append("              	     THEN A.DESMSGUSR 							                                                                                                ").Append(vbNewLine)
            sql.Append("              	     ELSE G.DESJSTCNCVLRARDCMC 					                                                                                                ").Append(vbNewLine)
            sql.Append("       	        END AS DESJSTCNCVLRARDCMC       					                                                                                            ").Append(vbNewLine)
            sql.Append("FROM 	        MRT.T0118058 A 								                                                                                                    ").Append(vbNewLine)
            sql.Append("		        INNER JOIN 	    MRT.T0100426 B ON B.CODFRN = A.CODFRN 					                                                                        ").Append(vbNewLine)
            sql.Append("  				                AND B.CODEMP = 1 						                                                                                        ").Append(vbNewLine)
            sql.Append("                                AND (B.CODFRN = " & data.ConvertParameterName("CODFRN3") & " OR 0 = " & data.ConvertParameterName("CODFRN4") & ")               ").Append(vbNewLine)
            sql.Append("		        INNER JOIN 	    MRT.T0113625 D ON D.CODCPR = B.CODCPR  					                                                                        ").Append(vbNewLine)
            sql.Append("                                AND (D.CODCPR = " & data.ConvertParameterName("CODCPR3") & " OR 0 = " & data.ConvertParameterName("CODCPR4") & ")               ").Append(vbNewLine)
            sql.Append("		        INNER JOIN 	    MRT.T0118570 E ON E.CODGERPRD = D.CODGERPRD 					                                                                ").Append(vbNewLine)
            sql.Append("                                AND (E.CODDIVCMP = " & data.ConvertParameterName("CODDIVCMP3") & " OR 0 = " & data.ConvertParameterName("CODDIVCMP4") & ")      ").Append(vbNewLine)
            sql.Append("		        INNER JOIN 	    MRT.T0118066 F ON  F.CODPMS = A.CODPMS 					                                                                        ").Append(vbNewLine)
            sql.Append("  				                AND F.DATNGCPMS = A.DATNGCPMS 				                                                                                    ").Append(vbNewLine)
            sql.Append("  				                AND F.CODEMP = A.CODEMP 					                                                                                    ").Append(vbNewLine)
            sql.Append("  				                AND F.CODFILEMP = A.CODFILEMP 				                                                                                    ").Append(vbNewLine)
            sql.Append("		        INNER JOIN 	    MRT.T0109059 H ON H.TIPDSNDSCBNF = F.TIPDSNDSCBNF 			                               	                                    ").Append(vbNewLine)
            sql.Append("		        LEFT OUTER JOIN MRT.T0120540 G ON G.CODPMS = F.CODPMS 				                        	                                                ").Append(vbNewLine)
            sql.Append("  				                AND G.CODEMP = F.CODEMP 					                                                                                    ").Append(vbNewLine)
            sql.Append("  				                AND G.CODFILEMP = F.CODFILEMP 				                                                                                    ").Append(vbNewLine)
            sql.Append("  				                AND G.DATNGCPMS = F.DATNGCPMS 				                                                                                    ").Append(vbNewLine)
            sql.Append("  				                AND G.TIPFRMDSCBNF = F.TIPFRMDSCBNF 			                                                                                ").Append(vbNewLine)
            sql.Append("  				                AND G.TIPDSNDSCBNF = F.TIPDSNDSCBNF 			                                                                                ").Append(vbNewLine)
            sql.Append("WHERE 	        G.DATALTPMS BETWEEN " & data.ConvertParameterName("DTINICIAL2") & "                                                                             ").Append(vbNewLine)
            sql.Append("		        AND " & data.ConvertParameterName("DTFINAL2") & "                                                                                               ").Append(vbNewLine)
            sql.Append("		        AND A.CODSITPMS NOT IN (0,1,5,6) 						                                                                                        ").Append(vbNewLine)
            sql.Append("		        AND F.VLRPDAPMS >= 0 							                                                                                                ").Append(vbNewLine)
            sql.Append("		        AND G.FLGLSTPLHLMT = 'P' 							                                                                                            ").Append(vbNewLine)

            Return sql.ToString()
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
        Friend Shared Function GetSelectObterComprador(ByVal data As IData, _
                                                         ByVal CODCPR As Decimal, _
                                                         ByVal NOMCPR As String) As String

            Dim sql As New System.Text.StringBuilder

            sql.Append("SELECT CODCPR,                                                  ").Append(vbNewLine)
            sql.Append("       NOMCPR                                                   ").Append(vbNewLine)
            sql.Append("FROM   MRT.T0113625                                             ").Append(vbNewLine)

            If CODCPR > 0 Then
                sql.Append(" WHERE CODCPR =" & data.ConvertParameterName("CODCPR") & "  ").Append(vbNewLine)
            End If

            If Not NOMCPR = "" Then
                sql.Append(" WHERE UPPER(NOMCPR) LIKE" & data.ConvertParameterName("NOMCPR") & "  ").Append(vbNewLine)
            End If

            Return sql.ToString()
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Obtem Células por atributo
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Rodrigo Gama]	09/09/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Friend Shared Function GetSelectObterCelulaPorAtributo(ByVal data As IData, _
                                                               ByVal CODDIVCMP As Decimal, _
                                                               ByVal DESDIVCMP As String) As String

            Dim sql As New System.Text.StringBuilder

            sql.Append("SELECT CODDIVCMP,                                                       ").Append(vbNewLine)
            sql.Append("       DESDIVCMP                                                        ").Append(vbNewLine)
            sql.Append("FROM   MRT.T0118570                                                     ").Append(vbNewLine)

            If CODDIVCMP > 0 Then
                sql.Append(" WHERE CODDIVCMP =" & data.ConvertParameterName("CODDIVCMP") & "    ").Append(vbNewLine)
            End If

            If Not DESDIVCMP = "" Then
                sql.Append(" WHERE UPPER(DESDIVCMP) LIKE" & data.ConvertParameterName("DESDIVCMP") & "    ").Append(vbNewLine)
            End If

            Return sql.ToString()
        End Function

        Private Shared Function GetWhere(ByVal where As String, ByVal condicao As String) As String
            If where Is Nothing Then where = String.Empty
            If (where.Trim = "") Then
                GetWhere = "WHERE " & condicao.Trim
            Else
                GetWhere = where & " AND " & condicao.Trim
            End If
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela T0123183 com base na sua chave primária.
        ''' Descrição da entidade:CADASTRO DIRETORIA CELULA
        ''' </summary>
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    05/09/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectDiretoriaCelula(ByVal data As IData) As String
            Dim sql As String

            sql &= "SELECT " + vbCrLf + _
                    "         CODCPR, " + vbCrLf + _
                    "         CODDRT, " + vbCrLf + _
                    "         CODDRTCMP, " + vbCrLf + _
                    "         CODUNDESRNGC, " + vbCrLf + _
                    "         DESDRTCMP " + vbCrLf + _
                    "FROM     MRT.T0123183 " + vbCrLf + _
                    "WHERE    CODDRTCMP=" + data.ConvertParameterName("CODDRTCMP") + vbCrLf + _
                    ""
            Return sql
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Este método retorna o SQL para tabela T0123183 com base em atributos que não fazem parte da chave primária.
        ''' Descrição da entidade:CADASTRO DIRETORIA CELULA
        ''' </summary>
        ''' <param name="data">Contexto do banco de dados</param>
        ''' <param name="CODCPR">CODIGO COMPRADOR.</param>
        ''' <param name="CODDRT">CODIGO DIRETORIA.</param>
        ''' <param name="CODDRTCMP">CODIGO DA DIRETORIAS DE COMPRAS.</param>
        ''' <param name="CODUNDESRNGC">CODIGO UNIDADE ESTRATEGICA DE NEGOCIOS.</param>
        ''' <param name="DESDRTCMP">DESCRICAO DA DIRETORIA DE COMPRAS.</param>
        ''' <returns>String com o comando sql.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Marcos Queiroz]    05/09/2006  Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '<MartinsSecurity(5, -1)> _
        Friend Shared Function GetSelectDiretoriaCelula(ByVal data As IData, _
                                                        ByVal CODCPR As Decimal, _
                                                        ByVal CODDRT As Decimal, _
                                                        ByVal CODDRTCMP As Decimal, _
                                                        ByVal CODUNDESRNGC As Decimal, _
                                                        ByVal DESDRTCMP As String) As String
            Dim sql As String
            Dim clausulaWhere As String = String.Empty

            sql &= "SELECT " + _
                    "         CODCPR, " + vbCrLf + _
                    "         CODDRT, " + vbCrLf + _
                    "         CODDRTCMP, " + vbCrLf + _
                    "         CODUNDESRNGC, " + vbCrLf + _
                    "         DESDRTCMP " + vbCrLf + _
                    "FROM     MRT.T0123183 " + vbCrLf

            If CODCPR <> 0 Then
                clausulaWhere = GetWhere(clausulaWhere, "CODCPR=" + data.ConvertParameterName("CODCPR") + vbCrLf)
            End If
            If CODDRT <> 0 Then
                clausulaWhere = GetWhere(clausulaWhere, "CODDRT=" + data.ConvertParameterName("CODDRT") + vbCrLf)
            End If
            If CODDRTCMP <> 0 Then
                clausulaWhere = GetWhere(clausulaWhere, "CODDRTCMP=" + data.ConvertParameterName("CODDRTCMP") + vbCrLf)
            End If
            If CODUNDESRNGC <> 0 Then
                clausulaWhere = GetWhere(clausulaWhere, "CODUNDESRNGC=" + data.ConvertParameterName("CODUNDESRNGC") + vbCrLf)
            End If
            If DESDRTCMP.Trim() <> "" Then
                clausulaWhere = GetWhere(clausulaWhere, "Upper(DESDRTCMP) Like " + data.ConvertParameterName("DESDRTCMP") + vbCrLf)
            End If

            sql &= clausulaWhere

            Return sql
        End Function

    End Class

End Namespace

