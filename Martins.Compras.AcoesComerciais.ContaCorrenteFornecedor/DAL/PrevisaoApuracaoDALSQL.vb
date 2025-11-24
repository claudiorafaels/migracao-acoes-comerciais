Imports Martins.Data

Namespace DAL

    Friend Class PrevisaoApuracaoDALSQL

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Obtem os dados para o relatorio Previsao Apuração
        ''' Se o filtro diretoria for selecionado
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Rodrigo Gama]	09/09/2008	Created
        ''' </history>
        Friend Shared Function GetSelectPrevisaoApuracaoPorDiretoria(ByVal data As IData) As String

            Dim sql As New System.Text.StringBuilder
            Dim clausulaOpicional As String

            sql.Append("SELECT DISTINCT                                                                                                                                                 ").Append(vbNewLine)
            sql.Append("       G.CODDRTCMP,                                                                                                                                             ").Append(vbNewLine)
            sql.Append("       G.DESDRTCMP,                                                                                                                                             ").Append(vbNewLine)
            sql.Append("       F.CODDIVCMP,                                                                                                                                             ").Append(vbNewLine)
            sql.Append("       F.DESDIVCMP,                                                                                                                                             ").Append(vbNewLine)
            sql.Append("       E.CODCPR,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       E.NOMCPR,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       C.CODFRN,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       C.NOMFRN,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("	   a.numcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.numcslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   x.descslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.tippodcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("       a.numrefpod,												                                                                                                ").Append(vbNewLine)
            sql.Append("	   a.tipedeabgmix, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.codedeabgmix,  											                                                                                            ").Append(vbNewLine)
            sql.Append("	   sum(a.vlrrcbeftfxa)as vlrrcbeftfxa 												                                                                        ").Append(vbNewLine)
            sql.Append("FROM   mrt.HSTPRVAPUARDFRN a 										                                                                                            ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0124945 b on b.numcttfrn = a.numcttfrn 							                                                                        ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0124953 x on x.numcslcttfrn = a.numcslcttfrn                                                                                             ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0100426 c on c.codfrn = b.codfrn 								                                                                        ").Append(vbNewLine)
            sql.Append("   	                                and c.codemp = 1									                                                                        ").Append(vbNewLine)
            sql.Append("   	                                and (C.CODFRN = " & data.ConvertParameterName("CODFRN1") & " OR 0 = " & data.ConvertParameterName("CODFRN2") & ")           ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0113625 e on e.codcpr = c.codcpr 								                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (E.CODCPR  = " & data.ConvertParameterName("CODCPR1") & " OR 0 = " & data.ConvertParameterName("CODCPR2") & ")          ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0118570 f on f.codgerprd = e.codgerprd 							                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (F.CODDIVCMP  = " & data.ConvertParameterName("CODDIV1") & " OR 0 = " & data.ConvertParameterName("CODDIV2") & ")       ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0123183 g on g.coddrtcmp = f.coddrtcmp 							                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (G.CODDRTCMP  = " & data.ConvertParameterName("CODDRT1") & " OR 0 = " & data.ConvertParameterName("CODDRT2") & ")       ").Append(vbNewLine)
            sql.Append("GROUP BY                                                                                                                                                        ").Append(vbNewLine)
            sql.Append("       G.CODDRTCMP,                                                                                                                                             ").Append(vbNewLine)
            sql.Append("       G.DESDRTCMP,                                                                                                                                             ").Append(vbNewLine)
            sql.Append("       F.CODDIVCMP,                                                                                                                                             ").Append(vbNewLine)
            sql.Append("       F.DESDIVCMP,                                                                                                                                             ").Append(vbNewLine)
            sql.Append("       E.CODCPR,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       E.NOMCPR,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       C.CODFRN,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       C.NOMFRN,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("	   a.numcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.numcslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   x.descslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.tippodcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("       a.numrefpod,												                                                                                                ").Append(vbNewLine)
            sql.Append("	   a.tipedeabgmix, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.codedeabgmix   											                                                                                            ").Append(vbNewLine)
            sql.Append("ORDER BY 3,4,5,6,7, 8, 9                                                                                                                                        ").Append(vbNewLine)

            Return sql.ToString()

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Obtem os dados para o relatorio Previsao Apuração
        ''' Se o filtro Célula for selecionado
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Rodrigo Gama]	09/09/2008	Created
        ''' </history>
        Friend Shared Function GetSelectPrevisaoApuracaoPorCelula(ByVal data As IData) As String

            Dim sql As New System.Text.StringBuilder
            Dim clausulaOpicional As String

            sql.Append("SELECT DISTINCT                                                                                                                                                 ").Append(vbNewLine)
            sql.Append("       F.CODDIVCMP,                                                                                                                                             ").Append(vbNewLine)
            sql.Append("       F.DESDIVCMP,                                                                                                                                             ").Append(vbNewLine)
            sql.Append("       E.CODCPR,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       E.NOMCPR,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       C.CODFRN,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       C.NOMFRN,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("	   a.numcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.numcslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   x.descslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.tippodcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("       a.numrefpod,												                                                                                                ").Append(vbNewLine)
            sql.Append("	   a.tipedeabgmix, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.codedeabgmix,  											                                                                                            ").Append(vbNewLine)
            sql.Append("	   sum(a.vlrrcbeftfxa)as vlrrcbeftfxa 												                                                                        ").Append(vbNewLine)
            sql.Append("FROM   mrt.HSTPRVAPUARDFRN a 										                                                                                            ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0124945 b on b.numcttfrn = a.numcttfrn 							                                                                        ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0124953 x on x.numcslcttfrn = a.numcslcttfrn                                                                                             ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0100426 c on c.codfrn = b.codfrn 								                                                                        ").Append(vbNewLine)
            sql.Append("   	                                and c.codemp = 1									                                                                        ").Append(vbNewLine)
            sql.Append("   	                                and (C.CODFRN = " & data.ConvertParameterName("CODFRN1") & " OR 0 = " & data.ConvertParameterName("CODFRN2") & ")           ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0113625 e on e.codcpr = c.codcpr 								                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (E.CODCPR  = " & data.ConvertParameterName("CODCPR1") & " OR 0 = " & data.ConvertParameterName("CODCPR2") & ")          ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0118570 f on f.codgerprd = e.codgerprd 							                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (F.CODDIVCMP  = " & data.ConvertParameterName("CODDIV1") & " OR 0 = " & data.ConvertParameterName("CODDIV2") & ")       ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0123183 g on g.coddrtcmp = f.coddrtcmp 							                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (G.CODDRTCMP  = " & data.ConvertParameterName("CODDRT1") & " OR 0 = " & data.ConvertParameterName("CODDRT2") & ")       ").Append(vbNewLine)
            sql.Append("GROUP BY                                                                                                                                                        ").Append(vbNewLine)
            sql.Append("       F.CODDIVCMP,                                                                                                                                             ").Append(vbNewLine)
            sql.Append("       F.DESDIVCMP,                                                                                                                                             ").Append(vbNewLine)
            sql.Append("       E.CODCPR,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       E.NOMCPR,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       C.CODFRN,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       C.NOMFRN,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("	   a.numcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.numcslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   x.descslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.tippodcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("       a.numrefpod,												                                                                                                ").Append(vbNewLine)
            sql.Append("	   a.tipedeabgmix, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.codedeabgmix   											                                                                                            ").Append(vbNewLine)
            sql.Append("ORDER BY 3,4,5,6,7, 8, 9                                                                                                                                        ").Append(vbNewLine)

            Return sql.ToString()

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Obtem os dados para o relatorio Previsao Apuração
        ''' Se o filtro Comprador for selecionado
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Rodrigo Gama]	09/09/2008	Created
        ''' </history>
        Friend Shared Function GetSelectPrevisaoApuracaoPorComprador(ByVal data As IData) As String

            Dim sql As New System.Text.StringBuilder
            Dim clausulaOpicional As String

            sql.Append("SELECT DISTINCT                                                                                                                                                 ").Append(vbNewLine)
            sql.Append("       E.CODCPR,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       E.NOMCPR,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       C.CODFRN,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       C.NOMFRN,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("	   a.numcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.numcslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   x.descslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.tippodcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("       a.numrefpod,												                                                                                                ").Append(vbNewLine)
            sql.Append("	   a.tipedeabgmix, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.codedeabgmix,  											                                                                                            ").Append(vbNewLine)
            sql.Append("	   sum(a.vlrrcbeftfxa)as vlrrcbeftfxa 												                                                                        ").Append(vbNewLine)
            sql.Append("FROM   mrt.HSTPRVAPUARDFRN a 										                                                                                            ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0124945 b on b.numcttfrn = a.numcttfrn 							                                                                        ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0124953 x on x.numcslcttfrn = a.numcslcttfrn                                                                                             ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0100426 c on c.codfrn = b.codfrn 								                                                                        ").Append(vbNewLine)
            sql.Append("   	                                and c.codemp = 1									                                                                        ").Append(vbNewLine)
            sql.Append("   	                                and (C.CODFRN = " & data.ConvertParameterName("CODFRN1") & " OR 0 = " & data.ConvertParameterName("CODFRN2") & ")           ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0113625 e on e.codcpr = c.codcpr 								                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (E.CODCPR  = " & data.ConvertParameterName("CODCPR1") & " OR 0 = " & data.ConvertParameterName("CODCPR2") & ")          ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0118570 f on f.codgerprd = e.codgerprd 							                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (F.CODDIVCMP  = " & data.ConvertParameterName("CODDIV1") & " OR 0 = " & data.ConvertParameterName("CODDIV2") & ")       ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0123183 g on g.coddrtcmp = f.coddrtcmp 							                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (G.CODDRTCMP  = " & data.ConvertParameterName("CODDRT1") & " OR 0 = " & data.ConvertParameterName("CODDRT2") & ")       ").Append(vbNewLine)
            sql.Append("GROUP BY                                                                                                                                                        ").Append(vbNewLine)
            sql.Append("       E.CODCPR,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       E.NOMCPR,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       C.CODFRN,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       C.NOMFRN,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("	   a.numcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.numcslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   x.descslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.tippodcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("       a.numrefpod,												                                                                                                ").Append(vbNewLine)
            sql.Append("	   a.tipedeabgmix, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.codedeabgmix   											                                                                                            ").Append(vbNewLine)
            sql.Append("ORDER BY 3,4,5,6,7, 8, 9                                                                                                                                        ").Append(vbNewLine)

            Return sql.ToString()

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Obtem os dados para o relatorio Previsao Apuração
        ''' Se o filtro Fornecedor for selecionado
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Rodrigo Gama]	09/09/2008	Created
        ''' </history>
        Friend Shared Function GetSelectPrevisaoApuracaoPorFornecedor(ByVal data As IData) As String

            Dim sql As New System.Text.StringBuilder
            Dim clausulaOpicional As String

            sql.Append("SELECT DISTINCT                                                                                                                                                 ").Append(vbNewLine)
            sql.Append("       C.CODFRN,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       C.NOMFRN,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("	   a.numcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.numcslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   x.descslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.tippodcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("       a.numrefpod,												                                                                                                ").Append(vbNewLine)
            sql.Append("	   a.tipedeabgmix, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.codedeabgmix,  											                                                                                            ").Append(vbNewLine)
            sql.Append("	   sum(a.vlrrcbeftfxa)as vlrrcbeftfxa 												                                                                        ").Append(vbNewLine)
            sql.Append("FROM   mrt.HSTPRVAPUARDFRN a 										                                                                                            ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0124945 b on b.numcttfrn = a.numcttfrn 							                                                                        ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0124953 x on x.numcslcttfrn = a.numcslcttfrn                                                                                             ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0100426 c on c.codfrn = b.codfrn 								                                                                        ").Append(vbNewLine)
            sql.Append("   	                                and c.codemp = 1									                                                                        ").Append(vbNewLine)
            sql.Append("   	                                and (C.CODFRN = " & data.ConvertParameterName("CODFRN1") & " OR 0 = " & data.ConvertParameterName("CODFRN2") & ")           ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0113625 e on e.codcpr = c.codcpr 								                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (E.CODCPR  = " & data.ConvertParameterName("CODCPR1") & " OR 0 = " & data.ConvertParameterName("CODCPR2") & ")          ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0118570 f on f.codgerprd = e.codgerprd 							                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (F.CODDIVCMP  = " & data.ConvertParameterName("CODDIV1") & " OR 0 = " & data.ConvertParameterName("CODDIV2") & ")       ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0123183 g on g.coddrtcmp = f.coddrtcmp 							                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (G.CODDRTCMP  = " & data.ConvertParameterName("CODDRT1") & " OR 0 = " & data.ConvertParameterName("CODDRT2") & ")       ").Append(vbNewLine)
            sql.Append("GROUP BY                                                                                                                                                        ").Append(vbNewLine)
            sql.Append("       C.CODFRN,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       C.NOMFRN,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("	   a.numcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.numcslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   x.descslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.tippodcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("       a.numrefpod,												                                                                                                ").Append(vbNewLine)
            sql.Append("	   a.tipedeabgmix, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   a.codedeabgmix   											                                                                                            ").Append(vbNewLine)
            sql.Append("ORDER BY 3,4,5,6,7, 8, 9                                                                                                                                        ").Append(vbNewLine)

            Return sql.ToString()

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Obtem os dados para o relatorio Previsao Apuração Sintético
        ''' Se o filtro diretoria for selecionado
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Rodrigo Gama]	22/09/2008	Created
        ''' </history>
        Friend Shared Function GetSelectPrevisaoApuracaoPorDiretoriaSintetico(ByVal data As IData) As String

            Dim sql As New System.Text.StringBuilder
            Dim clausulaOpicional As String

            sql.Append("SELECT DISTINCT                                                                                                                                                 ").Append(vbNewLine)
            sql.Append("       G.CODDRTCMP,                                                                                                                                             ").Append(vbNewLine)
            sql.Append("       G.DESDRTCMP,                                                                                                                                             ").Append(vbNewLine)
            sql.Append("	   a.numcslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   x.descslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   sum(a.vlrrcbeftfxa)as vlrrcbeftfxa 												                                                                        ").Append(vbNewLine)
            sql.Append("FROM   mrt.HSTPRVAPUARDFRN a 										                                                                                            ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0124945 b on b.numcttfrn = a.numcttfrn 							                                                                        ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0124953 x on x.numcslcttfrn = a.numcslcttfrn                                                                                             ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0100426 c on c.codfrn = b.codfrn 								                                                                        ").Append(vbNewLine)
            sql.Append("   	                                and c.codemp = 1									                                                                        ").Append(vbNewLine)
            sql.Append("   	                                and (C.CODFRN = " & data.ConvertParameterName("CODFRN1") & " OR 0 = " & data.ConvertParameterName("CODFRN2") & ")           ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0113625 e on e.codcpr = c.codcpr 								                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (E.CODCPR  = " & data.ConvertParameterName("CODCPR1") & " OR 0 = " & data.ConvertParameterName("CODCPR2") & ")          ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0118570 f on f.codgerprd = e.codgerprd 							                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (F.CODDIVCMP  = " & data.ConvertParameterName("CODDIV1") & " OR 0 = " & data.ConvertParameterName("CODDIV2") & ")       ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0123183 g on g.coddrtcmp = f.coddrtcmp 							                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (G.CODDRTCMP  = " & data.ConvertParameterName("CODDRT1") & " OR 0 = " & data.ConvertParameterName("CODDRT2") & ")       ").Append(vbNewLine)
            sql.Append("GROUP BY                                                                                                                                                        ").Append(vbNewLine)
            sql.Append("       G.CODDRTCMP,                                                                                                                                             ").Append(vbNewLine)
            sql.Append("       G.DESDRTCMP,                                                                                                                                             ").Append(vbNewLine)
            sql.Append("	   a.numcslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   x.descslcttfrn  												                                                                                            ").Append(vbNewLine)
            
            Return sql.ToString()

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Obtem os dados para o relatorio Previsao Apuração Sintético
        ''' Se o filtro Celula for selecionado
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Rodrigo Gama]	22/09/2008	Created
        ''' </history>
        Friend Shared Function GetSelectPrevisaoApuracaoPorCelulaSintetico(ByVal data As IData) As String

            Dim sql As New System.Text.StringBuilder
            Dim clausulaOpicional As String

            sql.Append("SELECT DISTINCT                                                                                                                                                 ").Append(vbNewLine)
            sql.Append("       F.CODDIVCMP,                                                                                                                                             ").Append(vbNewLine)
            sql.Append("       F.DESDIVCMP,                                                                                                                                             ").Append(vbNewLine)
            sql.Append("	   a.numcslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   x.descslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   sum(a.vlrrcbeftfxa)as vlrrcbeftfxa 												                                                                        ").Append(vbNewLine)
            sql.Append("FROM   mrt.HSTPRVAPUARDFRN a 										                                                                                            ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0124945 b on b.numcttfrn = a.numcttfrn 							                                                                        ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0124953 x on x.numcslcttfrn = a.numcslcttfrn                                                                                             ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0100426 c on c.codfrn = b.codfrn 								                                                                        ").Append(vbNewLine)
            sql.Append("   	                                and c.codemp = 1									                                                                        ").Append(vbNewLine)
            sql.Append("   	                                and (C.CODFRN = " & data.ConvertParameterName("CODFRN1") & " OR 0 = " & data.ConvertParameterName("CODFRN2") & ")           ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0113625 e on e.codcpr = c.codcpr 								                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (E.CODCPR  = " & data.ConvertParameterName("CODCPR1") & " OR 0 = " & data.ConvertParameterName("CODCPR2") & ")          ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0118570 f on f.codgerprd = e.codgerprd 							                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (F.CODDIVCMP  = " & data.ConvertParameterName("CODDIV1") & " OR 0 = " & data.ConvertParameterName("CODDIV2") & ")       ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0123183 g on g.coddrtcmp = f.coddrtcmp 							                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (G.CODDRTCMP  = " & data.ConvertParameterName("CODDRT1") & " OR 0 = " & data.ConvertParameterName("CODDRT2") & ")       ").Append(vbNewLine)
            sql.Append("GROUP BY                                                                                                                                                        ").Append(vbNewLine)
            sql.Append("       F.CODDIVCMP,                                                                                                                                             ").Append(vbNewLine)
            sql.Append("       F.DESDIVCMP,                                                                                                                                             ").Append(vbNewLine)
            sql.Append("	   a.numcslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   x.descslcttfrn  												                                                                                            ").Append(vbNewLine)

            Return sql.ToString()

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Obtem os dados para o relatorio Previsao Apuração Sintético
        ''' Se o filtro Comprador for selecionado
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Rodrigo Gama]	22/09/2008	Created
        ''' </history>
        Friend Shared Function GetSelectPrevisaoApuracaoPorCompradorSintetico(ByVal data As IData) As String

            Dim sql As New System.Text.StringBuilder
            Dim clausulaOpicional As String

            sql.Append("SELECT DISTINCT                                                                                                                                                 ").Append(vbNewLine)
            sql.Append("       E.CODCPR,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       E.NOMCPR,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("	   a.numcslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   x.descslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   sum(a.vlrrcbeftfxa)as vlrrcbeftfxa 												                                                                        ").Append(vbNewLine)
            sql.Append("FROM   mrt.HSTPRVAPUARDFRN a 										                                                                                            ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0124945 b on b.numcttfrn = a.numcttfrn 							                                                                        ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0124953 x on x.numcslcttfrn = a.numcslcttfrn                                                                                             ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0100426 c on c.codfrn = b.codfrn 								                                                                        ").Append(vbNewLine)
            sql.Append("   	                                and c.codemp = 1									                                                                        ").Append(vbNewLine)
            sql.Append("   	                                and (C.CODFRN = " & data.ConvertParameterName("CODFRN1") & " OR 0 = " & data.ConvertParameterName("CODFRN2") & ")           ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0113625 e on e.codcpr = c.codcpr 								                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (E.CODCPR  = " & data.ConvertParameterName("CODCPR1") & " OR 0 = " & data.ConvertParameterName("CODCPR2") & ")          ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0118570 f on f.codgerprd = e.codgerprd 							                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (F.CODDIVCMP  = " & data.ConvertParameterName("CODDIV1") & " OR 0 = " & data.ConvertParameterName("CODDIV2") & ")       ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0123183 g on g.coddrtcmp = f.coddrtcmp 							                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (G.CODDRTCMP  = " & data.ConvertParameterName("CODDRT1") & " OR 0 = " & data.ConvertParameterName("CODDRT2") & ")       ").Append(vbNewLine)
            sql.Append("GROUP BY                                                                                                                                                        ").Append(vbNewLine)
            sql.Append("       E.CODCPR,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       E.NOMCPR,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("	   a.numcslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   x.descslcttfrn  												                                                                                            ").Append(vbNewLine)

            Return sql.ToString()

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Obtem os dados para o relatorio Previsao Apuração Sintético
        ''' Se o filtro Fornecedor for selecionado
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Rodrigo Gama]	22/09/2008	Created
        ''' </history>
        Friend Shared Function GetSelectPrevisaoApuracaoPorFornecedorSintetico(ByVal data As IData) As String

            Dim sql As New System.Text.StringBuilder
            Dim clausulaOpicional As String

            sql.Append("SELECT DISTINCT                                                                                                                                                 ").Append(vbNewLine)
            sql.Append("       C.CODFRN,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       C.NOMFRN,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("	   a.numcslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   x.descslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   sum(a.vlrrcbeftfxa)as vlrrcbeftfxa 												                                                                        ").Append(vbNewLine)
            sql.Append("FROM   mrt.HSTPRVAPUARDFRN a 										                                                                                            ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0124945 b on b.numcttfrn = a.numcttfrn 							                                                                        ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0124953 x on x.numcslcttfrn = a.numcslcttfrn                                                                                             ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0100426 c on c.codfrn = b.codfrn 								                                                                        ").Append(vbNewLine)
            sql.Append("   	                                and c.codemp = 1									                                                                        ").Append(vbNewLine)
            sql.Append("   	                                and (C.CODFRN = " & data.ConvertParameterName("CODFRN1") & " OR 0 = " & data.ConvertParameterName("CODFRN2") & ")           ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0113625 e on e.codcpr = c.codcpr 								                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (E.CODCPR  = " & data.ConvertParameterName("CODCPR1") & " OR 0 = " & data.ConvertParameterName("CODCPR2") & ")          ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0118570 f on f.codgerprd = e.codgerprd 							                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (F.CODDIVCMP  = " & data.ConvertParameterName("CODDIV1") & " OR 0 = " & data.ConvertParameterName("CODDIV2") & ")       ").Append(vbNewLine)
            sql.Append("	   inner join mrt.t0123183 g on g.coddrtcmp = f.coddrtcmp 							                                                                        ").Append(vbNewLine)
            sql.Append("  	                                and (G.CODDRTCMP  = " & data.ConvertParameterName("CODDRT1") & " OR 0 = " & data.ConvertParameterName("CODDRT2") & ")       ").Append(vbNewLine)
            sql.Append("GROUP BY                                                                                                                                                        ").Append(vbNewLine)
            sql.Append("       C.CODFRN,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("       C.NOMFRN,                                                                                                                                                ").Append(vbNewLine)
            sql.Append("	   a.numcslcttfrn, 												                                                                                            ").Append(vbNewLine)
            sql.Append("	   x.descslcttfrn  												                                                                                            ").Append(vbNewLine)

            Return sql.ToString()

        End Function

    End Class

End Namespace
