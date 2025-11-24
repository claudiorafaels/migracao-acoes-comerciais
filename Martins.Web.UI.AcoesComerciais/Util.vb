Public Class Util

#Region " Enumerador "
    Public Enum tipoDeComponente As Integer
        Outros
        InfragisticsTxt
        InfragisticsWebNumericEdit
        InfragisticsWebDateTimeEdit
        ucFornecedor
        WucComprador
        WucCelula
    End Enum

#End Region

#Region " Web Utilities "

    Friend Shared Function ShowPopUp(ByVal scroll As Boolean) As String
        Try
            Dim sBuilder As System.Text.StringBuilder

            sBuilder = New System.Text.StringBuilder
            sBuilder.Append("<script language=""JavaScript"">" & vbCrLf)
            sBuilder.Append("function ShowPopUp(sURL, sName, altura, largura) " & vbCrLf)
            sBuilder.Append("{ " & vbCrLf)
            sBuilder.Append("	// Posiciona a nova janela no da tela " & vbCrLf)
            sBuilder.Append("	var top = (window.screen.height/3) - (altura/3); " & vbCrLf)
            sBuilder.Append("	var left = (window.screen.width/2) - (largura/2); " & vbCrLf)
            sBuilder.Append("	var sFeatures = ""Height="" + altura + "", Width="" + largura + "", top="" + top + "", left="" + left + "", fullscreen=no, toolbar=no, status=no, directories=no, location=no, menubar=no, resizable=yes, scrollbars=")
            If (scroll) Then
                sBuilder.Append("yes")
            Else
                sBuilder.Append("no")
            End If
            sBuilder.Append(""" " & vbCrLf)
            sBuilder.Append("	// Mostra a janela e coloca o foco nela " & vbCrLf)
            sBuilder.Append("	window.open(sURL, sName, sFeatures, true).focus(); " & vbCrLf)
            sBuilder.Append("} " & vbCrLf)
            sBuilder.Append("</script>")

            Return sBuilder.ToString()
        Catch ex As Exception
            'Controller.TrataErro(Me.Page, ex)
            Throw ex
        End Try
    End Function

    Friend Shared Function ShowPopUp(ByVal scroll As Boolean, ByVal fullScreen As Boolean) As String
        Try
            Dim sBuilder As System.Text.StringBuilder

            sBuilder = New System.Text.StringBuilder

            If fullScreen = False Then
                sBuilder.Append(ShowPopUp(scroll))
                Return sBuilder.ToString()
            End If

            sBuilder.Append("<script language=""JavaScript"">" & vbCrLf)
            sBuilder.Append("function ShowPopUp(sURL, sName) " & vbCrLf)
            sBuilder.Append("{ " & vbCrLf)
            sBuilder.Append("	// Posiciona a nova janela no da tela " & vbCrLf)
            sBuilder.Append("	var sFeatures = ""fullscreen=yes, movable=yes , toolbar=no, status=yes, directories=no, location=no, menubar=no, resizable=yes, scrollbars=")
            If (scroll) Then
                sBuilder.Append("yes")
            Else
                sBuilder.Append("no")
            End If
            sBuilder.Append(""" " & vbCrLf)
            sBuilder.Append("	// Mostra a janela e coloca o foco nela " & vbCrLf)
            sBuilder.Append("	window.open(sURL, sName, sFeatures, true).focus(); " & vbCrLf)
            sBuilder.Append("} " & vbCrLf)
            sBuilder.Append("</script>")

            Return sBuilder.ToString()
        Catch ex As Exception
            'Controller.TrataErro(Me.Page, ex)
            Throw ex
        End Try
    End Function

    Public Shared Sub AdicionaJsAlert(ByRef pagina As System.Web.UI.Page, ByVal msg As String, Optional ByVal esconderAndamento As Boolean = False)
        If esconderAndamento Then
            pagina.RegisterStartupScript("Andamento", "<script>escondeAndamento();</script>")
        End If
        msg = ReplaceCaracteresHtmlEmString(msg)
        pagina.RegisterStartupScript("Alerta", "<script>alert('" & msg.Replace(vbCrLf, "\n").Replace("'", "\'") & "');</script>")
    End Sub

    Public Shared Function ReplaceCaracteresHtmlEmString(ByVal str As String) As String
        str = str.Replace("&#225;", "á")
        str = str.Replace("&#227;", "ã")
        str = str.Replace("&#226;", "â")
        str = str.Replace("&#224;", "à")
        str = str.Replace("&#226;", "â")
        str = str.Replace("&#228;", "ä")
        str = str.Replace("&#229;", "å")
        str = str.Replace("&#170;", "ª")
        str = str.Replace("&#193;", "Á")
        str = str.Replace("&#195;", "Ã")
        str = str.Replace("&#194;", "Â")
        str = str.Replace("&#192;", "À")
        str = str.Replace("&#194;", "Â")
        str = str.Replace("&#196;", "Ä")
        str = str.Replace("&#197;", "Å")
        str = str.Replace("&#170;", "ª")
        str = str.Replace("&#243;", "ó")
        str = str.Replace("&#245;", "õ")
        str = str.Replace("&#244;", "ô")
        str = str.Replace("&#211;", "Ó")
        str = str.Replace("&#213;", "Õ")
        str = str.Replace("&#212;", "Ô")
        str = str.Replace("&#233;", "é")
        str = str.Replace("&#232;", "è")
        str = str.Replace("&#234;", "ê")
        str = str.Replace("&#235;", "ë")
        str = str.Replace("&#237;", "í")
        str = str.Replace("&#236;", "ì")
        str = str.Replace("&#238;", "î")
        str = str.Replace("&#239;", "ï")
        str = str.Replace("&#250;", "ú")
        str = str.Replace("&#249;", "ù")
        str = str.Replace("&#251;", "û")
        str = str.Replace("&#252;", "ü")
        str = str.Replace("&#231;", "ç")
        str = str.Replace("&#241;", "ñ")
        Return str
    End Function

    Public Shared Sub AdicionaJsFocus(ByRef pagina As System.Web.UI.Page, ByRef ctrl As WebControl, Optional ByVal tipoControle As tipoDeComponente = tipoDeComponente.Outros)
        pagina.RegisterStartupScript("SetFocus" & ctrl.ClientID, getJsFocus(pagina, ctrl, tipoControle))
    End Sub

    Public Shared Sub AdicionaJsFocus(ByRef pagina As System.Web.UI.Page, ByRef ctrl As Infragistics.WebUI.WebDataInput.WebNumericEdit)
        AdicionaJsFocus(pagina, CType(ctrl, WebControl), tipoDeComponente.InfragisticsTxt)
    End Sub

    Public Shared Sub AdicionaJsFocus(ByRef pagina As System.Web.UI.Page, ByRef ctrl As Infragistics.WebUI.WebDataInput.WebDateTimeEdit)
        AdicionaJsFocus(pagina, CType(ctrl, WebControl), tipoDeComponente.InfragisticsTxt)
    End Sub

    Public Shared Sub AdicionaJsFocus(ByRef pagina As System.Web.UI.Page, ByRef ctrl As Infragistics.WebUI.WebDataInput.WebTextEdit)
        AdicionaJsFocus(pagina, CType(ctrl, WebControl), tipoDeComponente.InfragisticsTxt)
    End Sub

    Public Shared Sub AdicionaJsFocus(ByRef pagina As System.Web.UI.Page, ByRef ctrl As System.Web.UI.WebControls.DropDownList)
        AdicionaJsFocus(pagina, CType(ctrl, WebControl), tipoDeComponente.Outros)
    End Sub

    Public Shared Sub AdicionaJsFocus(ByRef pagina As System.Web.UI.Page, ByRef ctrl As System.Web.UI.WebControls.LinkButton)
        AdicionaJsFocus(pagina, CType(ctrl, WebControl), tipoDeComponente.Outros)
    End Sub

    Public Shared Sub AdicionaJsFocus(ByRef pagina As System.Web.UI.Page, ByRef ctrl As System.Web.UI.WebControls.CheckBox)
        AdicionaJsFocus(pagina, CType(ctrl, WebControl), tipoDeComponente.Outros)
    End Sub

    Public Shared Sub AdicionaJsFocus(ByRef pagina As System.Web.UI.Page, ByRef ctrl As System.Web.UI.WebControls.TextBox)
        AdicionaJsFocus(pagina, CType(ctrl, WebControl), tipoDeComponente.Outros)
    End Sub

    Public Shared Function getJsFocus(ByRef pagina As System.Web.UI.Page, ByRef ctrl As WebControl, Optional ByVal tipoControle As tipoDeComponente = tipoDeComponente.Outros) As String
        Dim result As String

        Select Case tipoControle
            Case tipoDeComponente.InfragisticsTxt, tipoDeComponente.InfragisticsWebDateTimeEdit, tipoDeComponente.InfragisticsWebNumericEdit
                Dim NomeControle As String = ctrl.ClientID
                Dim NomeControle2 As String = "igtxt" & ctrl.ClientID
                Dim NomeControle3 As String = ctrl.ClientID & "_p"
                result = String.Empty
                result &= Util.ObterJavaScriptSetFocusByName(NomeControle, NomeControle2, NomeControle3)
                'result &= "<script> try { document.getElementById('igtxt" & ctrl.ClientID & "').focus(); }catch(Err){}</script>"
            Case Else
                Dim NomeControle2 As String = ctrl.ClientID.Replace("_", ":")
                result = Util.ObterJavaScriptSetFocusByName(ctrl.ClientID, NomeControle2, NomeControle2)
        End Select

        Return result
    End Function

    Friend Shared Function ObterJavaScriptSetFocusByName(ByVal NomeControle As String, _
                                                         ByVal NomeControle2 As String, _
                                                         ByVal NomeControle3 As String) As String
        Dim sBuilder As System.Text.StringBuilder
        sBuilder = New System.Text.StringBuilder

        sBuilder.Append("<SCRIPT LANGUAGE=javascript>" & vbCrLf)
        sBuilder.Append("try {" & vbCrLf)
        sBuilder.Append("   var oElements      = document.forms[0].elements;" & vbCrLf)
        sBuilder.Append("   var elementsLength = oElements.length;" & vbCrLf)
        sBuilder.Append("   var i              = 0;" & vbCrLf)
        sBuilder.Append("   " & vbCrLf)
        sBuilder.Append("   for(i = 0; i < elementsLength; i++) { " & vbCrLf)
        sBuilder.Append("      if(oElements[i].name == '" & NomeControle & "' || oElements[i].name == '" & NomeControle2 & "' || oElements[i].name == '" & NomeControle3 & "') { " & vbCrLf)
        'sBuilder.Append("         alert('Achou - Buscando:" & NomeControle & " Esse é:' + oElements[i].name ); " & vbCrLf)
        sBuilder.Append("         oElements[i].focus(); " & vbCrLf)
        'sBuilder.Append("         break; " & vbCrLf)
        sBuilder.Append("      } else { " & vbCrLf)
        'sBuilder.Append("         alert('NÃO Achou - Buscando:" & NomeControle & " Esse é:' + oElements[i].name ); " & vbCrLf)
        sBuilder.Append("      }; " & vbCrLf)
        sBuilder.Append("   }; " & vbCrLf)
        sBuilder.Append("}catch(Err){}" & vbCrLf)
        sBuilder.Append("</SCRIPT>")

        Return sBuilder.ToString()
    End Function

    Public Shared Function confirmar(ByRef perguntaDeConfirmacao As String) As String
        Dim sBuilder As New System.Text.StringBuilder

        sBuilder.Append("function ShowDialog() {" & vbCrLf)
        sBuilder.Append("   var retorno=''; " & vbCrLf)
        sBuilder.Append("" & vbCrLf)
        sBuilder.Append("   retorno = window.showModalDialog('../confirmarWindow.aspx?question=" & perguntaDeConfirmacao & "," & vbCrLf)
        sBuilder.Append("    'window','help:no;status:no;scroll:no;edge:raised;dialogWidth:400px;edge:raised;dialogHeight:120px')" & vbCrLf)
        sBuilder.Append("" & vbCrLf)
        sBuilder.Append("   if(retorno!="" && retorno!='0' && retorno!=null) {" & vbCrLf)
        sBuilder.Append("         __doPostBack('LinkButton1', '');" & vbCrLf)
        sBuilder.Append("   }" & vbCrLf)
        sBuilder.Append("}" & vbCrLf)

        Return sBuilder.ToString()
    End Function

    Public Shared Sub gravaInformacaoEventView(ByVal mensagem As String)
    End Sub

#End Region

#Region " Controles "

    Public Shared Sub LimpaControles(ByVal ctrls As WebControl(), Optional ByVal LimparDropDownLists As Boolean = True)
        For Each ctrl As WebControl In ctrls
            If TypeOf ctrl Is DropDownList Then
                If LimparDropDownLists Then DirectCast(ctrl, DropDownList).Items.Clear()
                DirectCast(ctrl, DropDownList).SelectedIndex = 0
            ElseIf TypeOf ctrl Is TextBox Then
                DirectCast(ctrl, TextBox).Text = String.Empty
            ElseIf TypeOf ctrl Is CheckBox Then
                DirectCast(ctrl, CheckBox).Checked = False
            ElseIf TypeOf ctrl Is Infragistics.WebUI.WebDataInput.WebTextEdit Then
                DirectCast(ctrl, Infragistics.WebUI.WebDataInput.WebTextEdit).Text = String.Empty
            ElseIf TypeOf ctrl Is Infragistics.WebUI.WebDataInput.WebNumericEdit Then
                DirectCast(ctrl, Infragistics.WebUI.WebDataInput.WebNumericEdit).Text = String.Empty
            ElseIf TypeOf ctrl Is Infragistics.WebUI.WebDataInput.WebCurrencyEdit Then
                DirectCast(ctrl, Infragistics.WebUI.WebDataInput.WebCurrencyEdit).Text = String.Empty
            ElseIf TypeOf ctrl Is Infragistics.WebUI.WebDataInput.WebPercentEdit Then
                DirectCast(ctrl, Infragistics.WebUI.WebDataInput.WebPercentEdit).Text = String.Empty
            ElseIf TypeOf ctrl Is Infragistics.WebUI.UltraWebGrid.UltraWebGrid Then
                DirectCast(ctrl, Infragistics.WebUI.UltraWebGrid.UltraWebGrid).Rows.Clear()
            End If
        Next
    End Sub

    Public Shared Sub HabilitaControles(ByVal ctrls As WebControl(), ByVal flag As Boolean)
        For Each ctrl As WebControl In ctrls
            If TypeOf ctrl Is DropDownList Then
                ctrl.Enabled = flag
            ElseIf TypeOf ctrl Is TextBox Then
                ctrl.Enabled = flag
            ElseIf TypeOf ctrl Is CheckBox Then
                ctrl.Enabled = flag
            ElseIf TypeOf ctrl Is LinkButton Then
                ctrl.Enabled = flag
            ElseIf TypeOf ctrl Is ImageButton Then
                ctrl.Enabled = flag
            ElseIf TypeOf ctrl Is Button Then
                ctrl.Enabled = flag
            ElseIf TypeOf ctrl Is Infragistics.WebUI.WebDataInput.WebTextEdit Then
                ctrl.Enabled = flag
            ElseIf TypeOf ctrl Is Infragistics.WebUI.WebDataInput.WebNumericEdit Then
                ctrl.Enabled = flag
            ElseIf TypeOf ctrl Is Infragistics.WebUI.WebDataInput.WebPercentEdit Then
                ctrl.Enabled = flag
            ElseIf TypeOf ctrl Is Infragistics.WebUI.UltraWebGrid.UltraWebGrid Then
                ctrl.Enabled = flag
            End If
        Next
    End Sub

    Public Shared Sub MostraControles(ByVal ctrls As WebControl(), ByVal flag As Boolean)
        For Each ctrl As WebControl In ctrls
            ctrl.Visible = flag
        Next
    End Sub

#End Region

#Region " Carga de Combo "

    Public Shared Sub carregarCmbCelula(ByRef ds As wsAcoesComerciais.DatasetCelula, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        'ds.T0118570.DefaultView.Sort = ds.T0118570.CODDIVCMPColumn.ColumnName
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetCelula.T0118570Row In ds.T0118570.Select("", "CODDIVCMP")
                .Items.Add(New ListItem(linha.CODDIVCMP.ToString & " - " & linha.DESDIVCMP, linha.CODDIVCMP.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    Public Shared Sub carregarCmbCelula(ByRef ds As wsRecuperacaoEPrevencaoPerdas.DatasetCelula, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        'ds.T0118570.DefaultView.Sort = ds.T0118570.CODDIVCMPColumn.ColumnName
        With cmb
            .Items.Clear()
            For Each linha As wsRecuperacaoEPrevencaoPerdas.DatasetCelula.T0118570Row In ds.T0118570.Select("", "CODDIVCMP")
                .Items.Add(New ListItem(linha.CODDIVCMP.ToString & " - " & linha.DESDIVCMP, linha.CODDIVCMP.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    Public Shared Sub carregarCmbFormaPagamento(ByRef ds As wsAcoesComerciais.DatasetFormaPagamento, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem, Optional ByRef flagLimparComboAntesPreencher As Boolean = True)
        With cmb
            If flagLimparComboAntesPreencher Then
                .Items.Clear()
            End If
            For Each linha As wsAcoesComerciais.DatasetFormaPagamento.T0113552Row In ds.T0113552.Select("", "TIPFRMDSCBNF")
                .Items.Add(New ListItem(linha.TIPFRMDSCBNF.ToString & " - " & linha.DESFRMDSCBNF, linha.TIPFRMDSCBNF.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    Public Shared Sub carregarCmbFormaPagamento(ByRef ds As wsAcoesComerciais.DatasetFormaPagamento, ByRef cmb As Infragistics.WebUI.WebCombo.WebCombo)
        ds.T0113552.DefaultView.Sort = ds.T0113552.TIPFRMDSCBNFColumn.ColumnName
        With cmb
            .DataSource = ds.T0113552 '.DefaultView
            .DataTextField = ds.T0113552.DESFRMDSCBNFColumn.ColumnName
            .DataValueField = ds.T0113552.TIPFRMDSCBNFColumn.ColumnName
            .DataBind()
        End With
    End Sub

    Public Shared Sub carregarCmbSituacoesAcordo(ByRef ds As wsAcoesComerciais.DatasetSituacaoAcordo, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        'ds.T0118082.DefaultView.Sort = ds.T0118082.CODSITPMSColumn.ColumnName
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetSituacaoAcordo.T0118082Row In ds.T0118082.Select("", "CODSITPMS")
                .Items.Add(New ListItem(linha.CODSITPMS.ToString & " - " & linha.DESSITPMS, linha.CODSITPMS.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    Public Shared Sub carregarCmbEmpenho(ByRef ds As wsAcoesComerciais.DatasetEmpenho, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        'ds.T0109059.DefaultView.Sort = ds.T0109059.TIPDSNDSCBNFColumn.ColumnName
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetEmpenho.T0109059Row In ds.T0109059.Select("", "TIPDSNDSCBNF")
                .Items.Add(New ListItem(Format(linha.TIPDSNDSCBNF, "0000") & " - " & linha.DESDSNDSCBNF, linha.TIPDSNDSCBNF.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    Public Shared Sub carregarCmbEmpenho(ByRef ds As wsAcoesComerciais.DatasetEmpenho, ByRef cmb As Infragistics.WebUI.WebCombo.WebCombo)
        With cmb
            .DataSource = ds.T0109059
            .DataTextField = ds.T0109059.DESDSNDSCBNFColumn.ColumnName
            .DataValueField = ds.T0109059.TIPDSNDSCBNFColumn.ColumnName
            .DataBind()
        End With
    End Sub

    Public Shared Sub carregarDdlCentroCusto(ByRef ds As wsAcoesComerciais.DatasetAcordo, ByRef cmb As DropDownList)
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetAcordo.CentroCustoRow In ds.CentroCusto.Select("", "CODCENCST")
                .Items.Add(New ListItem(linha.CODCENCST.ToString & " - " & linha.DESCENCST, linha.CODCENCST.ToString))
            Next
            .Items.Insert(0, "Selecione")
        End With
    End Sub

    Public Shared Sub carregarCmbFilial(ByRef ds As wsAcoesComerciais.dataSetFilial, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        'ds.T0112963.DefaultView.Sort = ds.T0112963.CODFILEMPColumn.ColumnName
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.dataSetFilial.T0112963Row In ds.T0112963.Select("", "CODFILEMP")
                .Items.Add(New ListItem(linha.CODFILEMP.ToString & " - " & linha.NOMFILEMP, linha.CODFILEMP.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    Public Shared Sub carregarCmbDivisaoFornecedor(ByRef ds As wsAcoesComerciais.dataSetDivisaoFornecedor, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        'ds.T0100426.DefaultView.Sort = ds.T0100426.NOMFRNColumn.ColumnName
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.dataSetDivisaoFornecedor.T0100426Row In ds.T0100426.Select("", "NOMFRN")
                .Items.Add(New ListItem(linha.CODFRN & " - " & linha.NOMFRN, linha.CODFRN.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    Public Shared Sub carregarCmbCentroCusto(ByRef ds As wsAcoesComerciais.DatasetAcordo, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetAcordo.CentroCustoRow In ds.CentroCusto.Select("", "DESCENCST")
                .Items.Add(New ListItem(linha.CODCENCST & " - " & linha.DESCENCST, linha.CODCENCST.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    Public Shared Sub carregarCmbTipoLancamento(ByRef ds As wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        'ds.T0123108.DefaultView.Sort = ds.T0123108.CODTIPLMTColumn.ColumnName
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor.T0123108Row In ds.T0123108.Select("", "CODTIPLMT")
                .Items.Add(New ListItem(Format(linha.CODTIPLMT, "0000") & " - " & linha.DESTIPLMT, linha.CODTIPLMT.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    Public Shared Sub carregarCmbTipoTransferencia(ByRef ds As wsAcoesComerciais.DatasetTipoTransferenciaValoresAcoesComerciais, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        'ds.T0135033.DefaultView.Sort = ds.T0135033.CODTIPTRNVLRACOCMCColumn.ColumnName
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetTipoTransferenciaValoresAcoesComerciais.T0135033Row In ds.T0135033.Select("", "CODTIPTRNVLRACOCMC")
                .Items.Add(New ListItem(Format(linha.CODTIPTRNVLRACOCMC, "0000") & " - " & linha.DESTIPTRNVLRACOCMC, linha.CODTIPTRNVLRACOCMC.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    Public Shared Sub carregarCmbUsuario(ByRef ds As wsAcoesComerciais.dataSetUsuarioCompra, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        'ds.T0113471.DefaultView.Sort = ds.T0113471.NOMACSUSRSISColumn.ColumnName
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.dataSetUsuarioCompra.T0113471Row In ds.T0113471.Select("", "NOMACSUSRSIS")
                .Items.Add(New ListItem(linha.NOMACSUSRSIS, linha.NOMACSUSRSIS))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    Public Shared Sub carregarCmbTipoPedidoCompra(ByRef ds As wsAcoesComerciais.DatasetTipoPedidoCompra, _
                                                  ByRef cmb As DropDownList, _
                                                  ByRef listItemExtra As ListItem)

        'ds.T0104499.DefaultView.Sort = ds.T0104499.TIPPEDCMPColumn.ColumnName
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetTipoPedidoCompra.T0104499Row In ds.T0104499.Select("", "TIPPEDCMP")
                .Items.Add(New ListItem(Format(linha.TIPPEDCMP, "0000") & " - " & linha.DESTIPPEDCMP, linha.TIPPEDCMP.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    Public Shared Sub carregarClausulaContrato(ByRef ds As wsAcoesComerciais.DatasetClausulaContrato, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetClausulaContrato.T0124953Row In ds.T0124953.Select("", "NUMCSLCTTFRN")
                .Items.Add(New ListItem(Format(linha.NUMCSLCTTFRN, "0000") & " - " & linha.DESCSLCTTFRN, linha.NUMCSLCTTFRN.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    Public Shared Sub carregarClausulaContrato(ByRef ds As wsAcoesComerciais.DatasetContrato, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetContrato.T0124961Row In ds.T0124961.Select("", "NUMCSLCTTFRN")
                .Items.Add(New ListItem(Format(linha.NUMCSLCTTFRN, "0000") & " - " & linha.T0124953Row.DESCSLCTTFRN, linha.NUMCSLCTTFRN.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    Public Shared Sub carregarTituloPagamentoContrato(ByRef ds As wsAcoesComerciais.DatasetTituloPagamentoContrato, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetTituloPagamentoContrato.T0151799Row In ds.T0151799.Select("", "TIPALCVBAFRN")
                .Items.Add(New ListItem(Format(linha.TIPALCVBAFRN, "0000") & " - " & linha.DESALCVBAFRN, linha.TIPALCVBAFRN.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    Public Shared Sub carregarCmbBanco(ByRef ds As wsCobrancaBancaria.DatasetBanco, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        With cmb
            .Items.Clear()
            For Each linha As wsCobrancaBancaria.DatasetBanco.T0100345Row In ds.T0100345.Select("", "NOMBCO")
                .Items.Add(New ListItem(Format(linha.CODBCO, "000") & " - " & linha.NOMBCO, linha.CODBCO.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    Public Shared Sub carregarCmbAgencia(ByRef ds As wsCobrancaBancaria.DatasetAgencia, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        With cmb
            .Items.Clear()
            For Each linha As wsCobrancaBancaria.DatasetAgencia.T0104413Row In ds.T0104413.Select("", "NOMAGEBCO")
                .Items.Add(New ListItem(Format(linha.CODAGEBCO, "0000") & " - " & linha.NOMAGEBCO, linha.CODAGEBCO.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    Public Shared Sub carregarCmbTipoPeriodo(ByRef ds As wsAcoesComerciais.DatasetTipoPeriodo, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetTipoPeriodo.T0124970Row In ds.T0124970.Select("", "TIPPODCTTFRN")
                .Items.Add(New ListItem(Format(linha.TIPPODCTTFRN, "00") & " - " & linha.DESPODCTTFRN, linha.TIPPODCTTFRN.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    Public Shared Sub carregarCmbTipoAbrangenciaMix(ByRef ds As wsAcoesComerciais.DatasetTipoAbrangenciaMix, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetTipoAbrangenciaMix.T0125011Row In ds.T0125011.Select("", "TIPEDEABGMIX")
                .Items.Add(New ListItem(Format(linha.TIPEDEABGMIX, "0000") & " - " & linha.DESEDEABGMIX, linha.TIPEDEABGMIX.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    Public Shared Sub carregarCmbComprador(ByRef ds As wsAcoesComerciais.dataSetEstruturaCompra, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.dataSetEstruturaCompra.T0113625Row In ds.T0113625.Select("", "NOMCPR")
                .Items.Add(New ListItem(Format(linha.CODCPR, "0000") & " - " & linha.NOMCPR, linha.CODCPR.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    Public Shared Sub carregarCmbMoeda(ByRef ds As wsAcoesComerciais.DatasetMoeda, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetMoeda.T0101724Row In ds.T0101724.Select("", "DESTIPMOE")
                .Items.Add(New ListItem(Format(linha.TIPMOE, "000") & " - " & linha.DESTIPMOE, linha.TIPMOE.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    Public Shared Sub carregarTipoBaseCalculo(ByRef ds As wsAcoesComerciais.DatasetTipoBaseCalculo, ByVal cmb As DropDownList, ByRef listItemExtra As ListItem)
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetTipoBaseCalculo.T0125003Row In ds.T0125003.Select("", "DESBSECAL")
                .Items.Add(New ListItem(Format(linha.TIPBSECAL, "000") & " - " & linha.DESBSECAL, linha.TIPBSECAL.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    'Carregar Combo Comprador
    Public Shared Sub carregarCmbNomeComprador(ByRef ds As wsRecuperacaoEPrevencaoPerdas.DatasetRecuperacaoEPrevencaoPerdas, ByVal cmb As DropDownList, ByRef listItemExtra As ListItem)
        With cmb
            .Items.Clear()
            For Each linha As wsRecuperacaoEPrevencaoPerdas.DatasetRecuperacaoEPrevencaoPerdas.CompradorRow In ds.Comprador.Select("", "NOMCPR")
                .Items.Add(New ListItem(Format(linha.CODCPR, "000") & " - " & linha.NOMCPR, linha.CODCPR.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    'Carregar Combo Diretoria
    Public Shared Sub carregarCmbDiretoria(ByRef ds As wsRecuperacaoEPrevencaoPerdas.DatasetDiretoriaCelulas, ByVal cmb As DropDownList, ByRef listItemExtra As ListItem)
        With cmb
            .Items.Clear()
            For Each linha As wsRecuperacaoEPrevencaoPerdas.DatasetDiretoriaCelulas.T0123183Row In ds.T0123183.Select("", "DESDRTCMP")
                .Items.Add(New ListItem(Format(linha.CODDRTCMP, "000") & " - " & linha.DESDRTCMP, linha.CODDRTCMP.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

#End Region

#Region " Misselanea "

    Public Shared Function TrocarVirgulaPorPonto(ByVal vVrl As String) As String
        Dim iPosVir As Integer
        iPosVir = InStr(vVrl, ",")
        If iPosVir <> 0 Then
            TrocarVirgulaPorPonto = Mid(vVrl, 1, iPosVir - 1) & "." & Mid(vVrl, iPosVir + 1)
        Else
            TrocarVirgulaPorPonto = vVrl
        End If
    End Function

    Public Shared Function RetiraCaracteresNaoNumericos(ByVal vVrl As String) As String
        Dim result As String
        For i As Integer = 0 To vVrl.Length
            If IsNumeric(vVrl.Substring(i, 1)) Then
                result += vVrl.Substring(i, 1)
            End If
        Next
        Return result
    End Function

    Public Shared Function FecharPagina(ByRef pagina As System.Web.UI.Page) As String
        Try
            pagina.RegisterStartupScript("Fechar", "<script>window.close();</script>")
        Catch ex As Exception
            Controller.TrataErro(pagina, ex)
            Throw ex
        End Try
    End Function

    Public Shared Function FecharPaginaSeASessionExpirou(ByRef pagina As System.Web.UI.Page) As Boolean
        Try
            If WSCAcoesComerciais.IsNewSession Then
                Util.AdicionaJsAlert(pagina, "Sua sessão expirou", False)
                pagina.RegisterStartupScript("Fechar", "<script>window.close()</script>")
                Controller.RedirecionarPaginaPrincipal(pagina)
                Return True
            End If
            Return False
        Catch ex As Exception
            Controller.TrataErro(pagina, ex)
            Throw ex
        End Try
    End Function

    Public Shared Function NomeDoMes(ByVal No_Mes As Integer) As String
        Select Case No_Mes
            Case 1
                Return "JANEIRO"
            Case 2
                Return "FEVEREIRO"
            Case 3
                Return "MARÇO"
            Case 4
                Return "ABRIL"
            Case 5
                Return "MAIO"
            Case 6
                Return "JUNHO"
            Case 7
                Return "JULHO"
            Case 8
                Return "AGOSTO"
            Case 9
                Return "SETEMBRO"
            Case 10
                Return "OUTUBRO"
            Case 11
                Return "NOVEMBRO"
            Case 12
                Return "DEZEMBRO"
            Case Else
                Return "---"
        End Select
    End Function

    Public Shared Function TiraAcentuacao(ByVal Quest As String) As String
        Dim Troca As String
        Dim caracter As String
        Dim I As Integer

        For I = 1 To Len(Quest)
            caracter = Mid(Quest, I, 1)
            Select Case caracter
                Case "'"
                    Troca = Troca + "-"
                Case "Á", "á", "ã", "Ã", "Â", "â"
                    Troca = Troca + "A"
                Case "ó", "Ó", "Õ", "õ", "ô", "Ô"
                    Troca = Troca + "O"
                Case "é", "É", "ê", "Ê"
                    Troca = Troca + "E"
                Case "í", "Í"
                    Troca = Troca + "I"
                Case "ú", "Ú"
                    Troca = Troca + "U"
                Case "ç", "Ç"
                    Troca = Troca + "C"
                Case Else : Troca = Troca + caracter
            End Select
        Next

        If Troca Is Nothing Then Troca = ""
        TiraAcentuacao = Troca
    End Function

#End Region

End Class