Public Class RelatorioAcordoFornecimento
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetContratoXPeriodo1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContratoXPeriodo
        CType(Me.DatasetContratoXPeriodo1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetContratoXPeriodo1
        '
        Me.DatasetContratoXPeriodo1.DataSetName = "DatasetContratoXPeriodo"
        Me.DatasetContratoXPeriodo1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetContratoXPeriodo1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LblA As System.Web.UI.WebControls.Label
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents WebTextEdit4 As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents WebTextEdit5 As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents txtDataFinal As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtDataInicial As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents CmbContrato As System.Web.UI.WebControls.DropDownList
    Protected WithEvents CmbCelula As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNumRefPod As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents btnImprimir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents rdlOpcoes As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents CmbClausula As System.Web.UI.WebControls.DropDownList
    Protected WithEvents CmbAbrangencia As System.Web.UI.WebControls.DropDownList
    Protected WithEvents CmbEntidade As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodClausula As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents CmbTipoPeriodo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodTipoPeriodo As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents TD1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD2 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD3 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD4 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD5 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD6 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD7 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD8 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD9 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD10 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD11 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD12 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD13 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD14 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD15 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD16 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD17 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD18 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TxtCodAbrangencia As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents cmbComprador As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtPercentualFinal As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtPercentualInicial As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents TD19 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD20 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD21 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD22 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD23 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD24 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD25 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD26 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents txtCodTipoPeriodo2 As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents CmbTipoPeriodo2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnVisualizar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents CodEntidade As Infragistics.WebUI.WebDataInput.WebMaskEdit
    Protected WithEvents uWebGrid As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents DatasetContratoXPeriodo1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContratoXPeriodo

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "Propriedades"

    Private Property NumeroUltimoTipoDeRelatorio() As Integer
        Get
            If Not ViewState("NumeroUltimoTipoDeRelatorio") Is Nothing Then
                Return DirectCast(ViewState("NumeroUltimoTipoDeRelatorio"), Integer)
            Else
                Return Convert.ToInt32("1")
            End If
        End Get
        Set(ByVal Value As Integer)
            ViewState("NumeroUltimoTipoDeRelatorio") = Value
        End Set
    End Property

#End Region

#Region "Eventos"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim datasetCelula As wsAcoesComerciais.DatasetCelula

            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            End If

            btnImprimir.Attributes.Add("OnClick", "javascript:mostraAndamento()")
            btnVisualizar.Attributes.Add("OnClick", "javascript:mostraAndamento()")

            If (Not IsPostBack) Then
                ucFornecedor.widthNome = System.Web.UI.WebControls.Unit.Parse("280px")
                ''carrega combo abrangencia
                'Util.carregarCmbTipoAbrangenciaMix(Controller.ObterTiposAbrangenciaMix(String.Empty), CmbAbrangencia, Nothing)
                'TxtCodAbrangencia.Text = CmbAbrangencia.SelectedValue

                ''Carrega celula
                'Util.carregarCmbCelula(Controller.ObterCelulas(0, 0, 0, String.Empty), CmbCelula, New ListItem("TODAS", "0"))
                'CmbCelula.Items.Insert(0, New ListItem(String.Empty, "-1"))
                'CmbCelula_SelectedIndexChanged(sender, e)
                'carregarCmbTipoPeriodo()
                'carregarCmbComprador()

                'Opção anterior do relatório
                NumeroUltimoTipoDeRelatorio = 1

                MostrarLinhasDeSimulacaoPorCelula(False)
                'Por solicitação do Cleuton, a linha da célula foi escondida
                TD3.Visible = False
                TD4.Visible = False
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub CmbAbrangencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbAbrangencia.SelectedIndexChanged
        Try
            If TxtCodAbrangencia.Text <> CmbAbrangencia.SelectedValue Then
                TxtCodAbrangencia.Text = CmbAbrangencia.SelectedValue
                TxtCodAbrangencia_ValueChange(sender, Nothing)
            End If
        Catch ex As Exception
            TxtCodAbrangencia.Text = String.Empty
        End Try
    End Sub

    Private Sub CmbTipoPeriodo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTipoPeriodo.SelectedIndexChanged
        Try
            If txtCodTipoPeriodo.Text <> CmbTipoPeriodo.SelectedValue Then
                txtCodTipoPeriodo.Text = CmbTipoPeriodo.SelectedValue
            End If
            txtCodTipoPeriodo_ValueChange(sender, Nothing)
            atualizarGrid()
        Catch ex As Exception
            txtCodTipoPeriodo.Text = String.Empty
        End Try
    End Sub

    Private Sub CmbTipoPeriodo2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTipoPeriodo2.SelectedIndexChanged
        Try
            If txtCodTipoPeriodo2.Text <> CmbTipoPeriodo2.SelectedValue Then
                txtCodTipoPeriodo2.Text = CmbTipoPeriodo2.SelectedValue
            End If
            txtCodTipoPeriodo2_ValueChange(sender, Nothing)
        Catch ex As Exception
            txtCodTipoPeriodo2.Text = String.Empty
        End Try
    End Sub

    Private Sub txtCodTipoPeriodo_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtCodTipoPeriodo.ValueChange
        Try
            If CmbTipoPeriodo.SelectedValue <> txtCodTipoPeriodo.Text Then
                CmbTipoPeriodo.SelectedValue = txtCodTipoPeriodo.Text
            End If
            atualizarGrid()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtCodTipoPeriodo2_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtCodTipoPeriodo2.ValueChange
        Try
            If CmbTipoPeriodo2.SelectedValue <> txtCodTipoPeriodo2.Text Then
                CmbTipoPeriodo2.SelectedValue = txtCodTipoPeriodo2.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CodEntidade_ValueChange(ByVal sender As Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles CodEntidade.ValueChange
        Try
            If CmbEntidade.SelectedValue <> CodEntidade.Text Then
                CmbEntidade.SelectedValue = CodEntidade.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CmbEntidade_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEntidade.SelectedIndexChanged
        Try
            If CodEntidade.Text <> CmbEntidade.SelectedValue Then
                CodEntidade.Text = CmbEntidade.SelectedValue
                CodEntidade_ValueChange(sender, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ucFornecedor_FornecedorAlterado(ByVal e As System.Web.UI.WebControls.ListItem) Handles ucFornecedor.FornecedorAlterado
        Try
            carregarCmbContrato()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub CmbCelula_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCelula.SelectedIndexChanged
        Try
            carregarCmbComprador()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmbClausula_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbClausula.SelectedIndexChanged
        Try
            If txtCodClausula.Text <> CmbClausula.SelectedValue Then
                txtCodClausula.Text = CmbClausula.SelectedValue
            End If

            carregarCmbAbrangencia()
            carregarCmbTipoPeriodo()
            carregarCmbEntidade()

            atualizarGrid()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtCodClausula_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtCodClausula.ValueChange
        Try
            If CmbClausula.SelectedValue <> txtCodClausula.Text Then
                CmbClausula.SelectedValue = txtCodClausula.Text
            End If
            carregarCmbAbrangencia()
            carregarCmbTipoPeriodo()
            atualizarGrid()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CmbContrato_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbContrato.SelectedIndexChanged
        Try
            carregarCmbClausula()
            carregarCmbAbrangencia()
            carregarCmbTipoPeriodo()
            carregarCmbEntidade()

            atualizarGrid()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Response.Redirect("Principal.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            If Validar() = False Then
                Exit Sub
            End If

            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = True

            If rdlOpcoes.SelectedValue = "1" Then
                ImprimirFornecedorSintético()
            ElseIf rdlOpcoes.SelectedValue = "2" Then
                ImprimirFornecedorAnalítico()
            ElseIf rdlOpcoes.SelectedValue = "3" Then
                ImprimirSimulacao()
            ElseIf rdlOpcoes.SelectedValue = "4" Then
                ImprimirSimulacaoPorCelula()
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            If Validar() = False Then
                Exit Sub
            End If

            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = False

            If rdlOpcoes.SelectedValue = "1" Then
                ImprimirFornecedorSintético()
            ElseIf rdlOpcoes.SelectedValue = "2" Then
                ImprimirFornecedorAnalítico()
            ElseIf rdlOpcoes.SelectedValue = "3" Then
                ImprimirSimulacao()
            ElseIf rdlOpcoes.SelectedValue = "4" Then
                ImprimirSimulacaoPorCelula()
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub TxtCodAbrangencia_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles TxtCodAbrangencia.ValueChange
        Try
            If CmbAbrangencia.SelectedValue <> TxtCodAbrangencia.Text Then
                CmbAbrangencia.SelectedValue = TxtCodAbrangencia.Text
            End If

            carregarCmbTipoPeriodo()
            carregarCmbEntidade()

        Catch ex As Exception
            TxtCodAbrangencia.Text = String.Empty
        End Try

    End Sub

    Private Sub rdlOpcoes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdlOpcoes.SelectedIndexChanged
        Select Case rdlOpcoes.SelectedValue
            Case "1", "2"
                If rdlOpcoes.SelectedValue = "1" And NumeroUltimoTipoDeRelatorio <> 1 Then
                    atualizarGrid()
                End If
                If rdlOpcoes.SelectedValue = "2" And NumeroUltimoTipoDeRelatorio <> 2 Then
                    atualizarGrid()
                End If
                NumeroUltimoTipoDeRelatorio = Convert.ToInt32(rdlOpcoes.SelectedValue)
                MostrarLinhasDeSimulacaoPorCelula(False)
            Case "3"
                If NumeroUltimoTipoDeRelatorio <> 3 Then
                    atualizarGrid()
                End If
                NumeroUltimoTipoDeRelatorio = Convert.ToInt32(rdlOpcoes.SelectedValue)
                MostrarLinhasDeSimulacaoPorCelula(False)
            Case "4"
                If NumeroUltimoTipoDeRelatorio <> 4 Then
                    atualizarGrid()
                End If
                MostrarLinhasDeSimulacaoPorCelula(True)
                carregarCmbComprador()
                carregarCmbTipoPeriodoParaSimulacaoPorCelula()
        End Select
    End Sub

    Private Sub uWebGrid_Click(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.ClickEventArgs) Handles uWebGrid.Click
        txtNumRefPod.Text = uWebGrid.DisplayLayout.ActiveRow().GetCellValue(uWebGrid.Columns.FromKey("NUMREFPOD")).ToString
        txtDataInicial.Text = uWebGrid.DisplayLayout.ActiveRow().GetCellValue(uWebGrid.Columns.FromKey("DATINIPOD")).ToString
        txtDataFinal.Text = uWebGrid.DisplayLayout.ActiveRow().GetCellValue(uWebGrid.Columns.FromKey("DATFIMPOD")).ToString
    End Sub

    Private Sub btnImprimirSimulacaoPorCelula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Page.RegisterStartupScript("Quebra", "<script>MostrarJanelaModal()</script>")
    End Sub

#End Region

#Region "Metodos"

#Region "Relatorios"

    Private Sub ImprimirFornecedorSintético()
        Try
            'op1
            Dim codigoEntidade As Decimal
            If CType(CodEntidade.Value, Decimal) = 0 Then
                codigoEntidade = ucFornecedor.CodFornecedor
            Else
                codigoEntidade = CType(CmbEntidade.SelectedValue, Decimal)
            End If

            Dim numeroContrato As Decimal
            If IsNumeric(CmbContrato.SelectedValue) Then
                numeroContrato = CType(CmbContrato.SelectedValue, Decimal)
            End If

            If CType(CmbCelula.SelectedValue, Decimal) >= 0 Then    'Selecionou opção, todas celulas ou celula específica
                If Me.CmbClausula.SelectedValue = "1" Then
                    ' Obter dados do relatório e guardar na seção
                    WSCAcoesComerciais.dsRelatorioAcordoFornecimento = Controller.ObterRelatorioAcordoFornecimento_027(CType(CmbCelula.SelectedValue, Decimal), txtCodClausula.ValueDecimal, txtCodTipoPeriodo.ValueDecimal, txtDataInicial.Date, Date.Parse(txtDataFinal.Text))
                    ' Guarda o nome do relatório na seção
                    WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "rpclj027.rpt"
                Else
                    ' Obter dados do relatório e guardar na seção
                    WSCAcoesComerciais.dsRelatorioAcordoFornecimento = Controller.ObterRelatorioAcordoFornecimento_041(Integer.Parse(CmbCelula.SelectedValue), txtCodClausula.ValueDecimal, txtCodTipoPeriodo.ValueDecimal, txtDataInicial.Date, Date.Parse(txtDataFinal.Text))
                    ' Guarda o nome do relatório na seção
                    WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "rpclj041.rpt"
                End If
            Else
                If CmbClausula.SelectedValue = "1" Or _
                   CmbClausula.SelectedValue = "4" Or _
                   CmbClausula.SelectedValue = "5" Or _
                   CmbClausula.SelectedValue = "6" Or _
                   CmbClausula.SelectedValue = "7" Or _
                   CmbClausula.SelectedValue = "8" Or _
                   CmbClausula.SelectedValue = "9" Or _
                   CmbClausula.SelectedValue = "12" Then

                    ' Obter dados do relatório e guardar na seção
                    WSCAcoesComerciais.dsRelatorioAcordoFornecimento = Controller.ObterRelatorioAcordoFornecimento_022(CType(ucFornecedor.CodFornecedor, Decimal), txtCodTipoPeriodo.ValueDecimal, numeroContrato, txtCodClausula.ValueDecimal, TxtCodAbrangencia.ValueDecimal, codigoEntidade, txtNumRefPod.ValueDecimal, txtDataInicial.Date)
                    ' Guarda o nome do relatório na seção
                    WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "rpclj022.rpt"
                Else
                    ' Obter dados do relatório e guardar na seção
                    WSCAcoesComerciais.dsRelatorioAcordoFornecimento = Controller.ObterRelatorioAcordoFornecimento_023(CType(ucFornecedor.CodFornecedor, Decimal), txtCodTipoPeriodo.ValueInt, numeroContrato, txtCodClausula.ValueDecimal, TxtCodAbrangencia.ValueDecimal, codigoEntidade, txtNumRefPod.ValueDecimal, txtDataInicial.Date)
                    ' Guarda o nome do relatório na seção
                    WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "rpclj023.rpt"
                End If

                'Coloca o número do acordo na seção, 
                'posteriormente será adicionado as formulas do relatório
                Dim htFormulas As New Hashtable
                With htFormulas
                    .Add("Contrato", "'" & CmbContrato.SelectedValue & "'")
                End With
                WSCAcoesComerciais.hashtableFormulasCrystal = htFormulas

            End If

            'Chama o visualizador de relatório
            Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ImprimirFornecedorAnalítico()
        'op2
        Dim TipRel As Decimal
        Dim TipRelComp As Decimal
        Dim TipApu As Decimal

        Dim codigoEntidade As Decimal
        If CType(CodEntidade.Value, Decimal) = 0 Then
            codigoEntidade = CType(ucFornecedor.CodFornecedor, Decimal)
        Else
            codigoEntidade = CType(CmbEntidade.SelectedValue, Decimal)
        End If

        Dim numeroContrato As Decimal
        If IsNumeric(CmbContrato.SelectedValue) Then
            numeroContrato = CType(CmbContrato.SelectedValue, Decimal)
        End If

        If CmbClausula.SelectedValue = "2" Or _
           CmbClausula.SelectedValue = "3" Or _
           CmbClausula.SelectedValue = "10" Then 'Relatório de bonus de crescimento 2,3,10

            TipRel = ObtemBaseCalculo(CDec(CmbContrato.SelectedValue), CDec(CmbClausula.SelectedValue), CDec(CmbAbrangencia.SelectedValue), Convert.ToDecimal(codigoEntidade))
            TipApu = ObtemTipoApuracao(CDec(CmbContrato.SelectedValue), CDec(CmbClausula.SelectedValue), CDec(CmbAbrangencia.SelectedValue), Convert.ToDecimal(codigoEntidade))
            TipRelComp = ObtemBaseCalculoComp(CDec(CmbContrato.SelectedValue), CDec(CmbClausula.SelectedValue), CDec(CmbAbrangencia.SelectedValue), Convert.ToDecimal(codigoEntidade))

            If TipRel <> -1 And TipRelComp <> -1 Then
                If TipRelComp = 1 Then 'faturamento bruto
                    If TipApu = 1 Then 'meta
                        ' Obter dados do relatório e guardar na seção
                        WSCAcoesComerciais.dsRelatorioAcordoFornecimento = Controller.ObterRelatorioAcordoFornecimento_052(Convert.ToInt32(ucFornecedor.CodFornecedor), txtCodTipoPeriodo.ValueInt, numeroContrato, txtCodClausula.ValueInt, TxtCodAbrangencia.ValueInt, codigoEntidade, txtNumRefPod.ValueInt, txtDataInicial.Date)
                        ' Guarda o nome do relatório na seção
                        WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "rpcClj052D1.rpt" 'meta/faturamento
                    Else
                        If TipRel = 1 Then
                            ' Obter dados do relatório e guardar na seção
                            WSCAcoesComerciais.dsRelatorioAcordoFornecimento = Controller.ObterRelatorioAcordoFornecimento_052(Convert.ToInt32(ucFornecedor.CodFornecedor), txtCodTipoPeriodo.ValueInt, numeroContrato, txtCodClausula.ValueInt, TxtCodAbrangencia.ValueInt, codigoEntidade, txtNumRefPod.ValueInt, txtDataInicial.Date)
                            ' Guarda o nome do relatório na seção
                            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "rpcClj052A1.rpt" 'meta/faturamento
                        ElseIf TipRel = 3 Then
                            ' Obter dados do relatório e guardar na seção
                            WSCAcoesComerciais.dsRelatorioAcordoFornecimento = Controller.ObterRelatorioAcordoFornecimento_052(Convert.ToInt32(ucFornecedor.CodFornecedor), txtCodTipoPeriodo.ValueInt, numeroContrato, txtCodClausula.ValueInt, TxtCodAbrangencia.ValueInt, codigoEntidade, txtNumRefPod.ValueInt, txtDataInicial.Date)
                            ' Guarda o nome do relatório na seção
                            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "rpcClj052C1.rpt" 'unid/faturamento
                        ElseIf TipRel = 4 Then
                            ' Obter dados do relatório e guardar na seção
                            WSCAcoesComerciais.dsRelatorioAcordoFornecimento = Controller.ObterRelatorioAcordoFornecimento_052(Convert.ToInt32(ucFornecedor.CodFornecedor), txtCodTipoPeriodo.ValueInt, numeroContrato, txtCodClausula.ValueInt, TxtCodAbrangencia.ValueInt, codigoEntidade, txtNumRefPod.ValueInt, txtDataInicial.Date)
                            ' Guarda o nome do relatório na seção
                            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "rpcClj052B1.rpt" ''tonelada/faturamento
                            'tonelada/faturamento
                        Else
                            ' Obter dados do relatório e guardar na seção
                            WSCAcoesComerciais.dsRelatorioAcordoFornecimento = Controller.ObterRelatorioAcordoFornecimento_052(Convert.ToInt32(ucFornecedor.CodFornecedor), txtCodTipoPeriodo.ValueInt, numeroContrato, txtCodClausula.ValueInt, TxtCodAbrangencia.ValueInt, codigoEntidade, txtNumRefPod.ValueInt, txtDataInicial.Date)
                            ' Guarda o nome do relatório na seção
                            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "rpcClj052A.rpt" ''tonelada/faturamento
                        End If
                    End If
                Else ' /faturamento liquido
                    If TipApu = 1 Then  'meta
                        ' Obter dados do relatório e guardar na seção
                        WSCAcoesComerciais.dsRelatorioAcordoFornecimento = Controller.ObterRelatorioAcordoFornecimento_052(Convert.ToInt32(ucFornecedor.CodFornecedor), txtCodTipoPeriodo.ValueInt, numeroContrato, txtCodClausula.ValueInt, TxtCodAbrangencia.ValueInt, codigoEntidade, txtNumRefPod.ValueInt, txtDataInicial.Date)
                        ' Guarda o nome do relatório na seção
                        WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "rpcClj052D.rpt" ''tonelada/faturamento
                    Else
                        If TipRel = 2 Then
                            'Obter dados do relatório e guardar na seção
                            WSCAcoesComerciais.dsRelatorioAcordoFornecimento = Controller.ObterRelatorioAcordoFornecimento_052(Convert.ToInt32(ucFornecedor.CodFornecedor), txtCodTipoPeriodo.ValueInt, numeroContrato, txtCodClausula.ValueInt, TxtCodAbrangencia.ValueInt, codigoEntidade, txtNumRefPod.ValueInt, txtDataInicial.Date)
                            'Guarda o nome do relatório na seção
                            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "rpcClj052A.rpt" 'faturamento liq/faturamento liq
                        ElseIf TipRel = 3 Then                         'unid/faturamento liq
                            'Obter dados do relatório e guardar na seção
                            WSCAcoesComerciais.dsRelatorioAcordoFornecimento = Controller.ObterRelatorioAcordoFornecimento_052(Convert.ToInt32(ucFornecedor.CodFornecedor), txtCodTipoPeriodo.ValueInt, numeroContrato, txtCodClausula.ValueInt, TxtCodAbrangencia.ValueInt, codigoEntidade, txtNumRefPod.ValueInt, txtDataInicial.Date)
                            'Guarda o nome do relatório na seção
                            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "rpcClj052C.rpt" ' 'unid/faturamento liq
                        ElseIf TipRel = 4 Then
                            'Obter dados do relatório e guardar na seção
                            WSCAcoesComerciais.dsRelatorioAcordoFornecimento = Controller.ObterRelatorioAcordoFornecimento_052(Convert.ToInt32(ucFornecedor.CodFornecedor), txtCodTipoPeriodo.ValueInt, numeroContrato, txtCodClausula.ValueInt, TxtCodAbrangencia.ValueInt, codigoEntidade, txtNumRefPod.ValueInt, txtDataInicial.Date)
                            'Guarda o nome do relatório na seção
                            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "rpcClj052B.rpt" ' tonelada/faturamento liq
                        Else
                            'Obter dados do relatório e guardar na seção
                            WSCAcoesComerciais.dsRelatorioAcordoFornecimento = Controller.ObterRelatorioAcordoFornecimento_052(Convert.ToInt32(ucFornecedor.CodFornecedor), txtCodTipoPeriodo.ValueInt, numeroContrato, txtCodClausula.ValueInt, TxtCodAbrangencia.ValueInt, codigoEntidade, txtNumRefPod.ValueInt, txtDataInicial.Date)
                            'Guarda o nome do relatório na seção
                            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "rpcClj052A1.rpt" ' tonelada/faturamento liq
                        End If
                    End If
                End If
            Else
                Util.AdicionaJsAlert(Me, "Erro na otenção da base cálculo para impressão do relatório.")
            End If
        Else
            TipRel = ObtemBaseCalculo(CDec(CmbContrato.SelectedValue), CDec(CmbClausula.SelectedValue), CDec(CmbAbrangencia.SelectedValue), Convert.ToDecimal(codigoEntidade))

            If TipRel <> -1 Then
                If TipRel = 1 Then
                    'Obter dados do relatório e guardar na seção
                    WSCAcoesComerciais.dsRelatorioAcordoFornecimento = Controller.ObterRelatorioAcordoFornecimento_051(CType(ucFornecedor.CodFornecedor, Decimal), txtCodTipoPeriodo.ValueDecimal, numeroContrato, txtCodClausula.ValueDecimal, TxtCodAbrangencia.ValueDecimal, codigoEntidade, txtNumRefPod.ValueDecimal, txtDataInicial.Date)
                    ' Guarda o nome do relatório na seção
                    WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "rpcClj051B.rpt"
                Else
                    'Obter dados do relatório e guardar na seção
                    WSCAcoesComerciais.dsRelatorioAcordoFornecimento = Controller.ObterRelatorioAcordoFornecimento_051(CType(ucFornecedor.CodFornecedor, Decimal), txtCodTipoPeriodo.ValueDecimal, numeroContrato, txtCodClausula.ValueDecimal, TxtCodAbrangencia.ValueDecimal, codigoEntidade, txtNumRefPod.ValueDecimal, txtDataInicial.Date)
                    'Guarda o nome do relatório na seção
                    WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "rpcClj051A.rpt"
                End If
            Else
                Util.AdicionaJsAlert(Me, "Erro na otenção da base cálculo para impressão do relatório. Favor consultar analista responsável.")
            End If
        End If

        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

    Private Sub ImprimirSimulacao()
        Dim codigoEntidade As Decimal
        If CType(CodEntidade.Value, Decimal) = 0 Then
            codigoEntidade = ucFornecedor.CodFornecedor
        Else
            codigoEntidade = CType(CmbEntidade.SelectedValue, Decimal)
        End If

        Dim numeroContrato As Decimal
        If IsNumeric(CmbContrato.SelectedValue) Then
            numeroContrato = CType(CmbContrato.SelectedValue, Decimal)
        End If

        ' Obter dados do relatório e guardar na seção
        WSCAcoesComerciais.dsRelatorioAcordoFornecimento = Controller.ObterRelatorioAcordoFornecimento_053(ucFornecedor.CodFornecedor, txtCodTipoPeriodo.ValueDecimal, numeroContrato, txtCodClausula.ValueDecimal, TxtCodAbrangencia.ValueDecimal, codigoEntidade, txtNumRefPod.ValueDecimal, txtDataInicial.Date)

        ' Guarda o nome do relatório na seção
        WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "rpcclj053.rpt"

        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

    Private Sub ImprimirSimulacaoPorCelula()
        Dim mvCodCel As Integer = 0
        Dim mvCodCpr As Integer = 0
        Dim mvPor As Integer = 0
        Dim mvPor1 As Integer = 0
        Dim mvPer As Integer = 0

        If IsNumeric(CmbCelula.SelectedValue) Then
            mvCodCel = Convert.ToInt32(CmbCelula.SelectedValue)
        End If
        If IsNumeric(cmbComprador.SelectedValue) Then
            mvCodCpr = Convert.ToInt32(cmbComprador.SelectedValue)
        End If

        mvPor = txtPercentualInicial.ValueInt
        mvPor1 = txtPercentualFinal.ValueInt
        mvPer = txtCodTipoPeriodo2.ValueInt

        ' Obter dados do relatório e guardar na seção
        WSCAcoesComerciais.dsSimulacaoSinteticaDeCrescimento = Controller.ObterSimulacaoSinteticaDeCrescimento(mvCodCel, 0, mvCodCpr, mvPer, mvPor, mvPor1)

        ' Guarda o nome do relatório na seção
        WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RPCCLJ121.RPT"

        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left = 0,top = 0,left =0,height = 768,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

    Private Function ObtemBaseCalculoComp(ByVal NumCttFrn As Decimal, ByVal NumCslCttFrn As Decimal, ByVal TipEdeAbgMix As Decimal, ByVal CodEdeAbgMix As Decimal) As Integer
        Dim datasetContrato As wsAcoesComerciais.DatasetContratoXAbrangenciaMix
        Dim result As Integer
        datasetContrato = Controller.ObterContratosXAbrangenciasMix(CodEdeAbgMix, NumCslCttFrn, NumCttFrn, TipEdeAbgMix)
        If datasetContrato.T0124996.Rows.Count > 0 Then
            result = CInt(datasetContrato.T0124996(0).TIPBSECALAPUVLRRCB)
        Else
            result = -1
        End If
        Return result
    End Function

    Private Function ObtemBaseCalculo(ByVal NumCttFrn As Decimal, ByVal NumCslCttFrn As Decimal, ByVal TipEdeAbgMix As Decimal, ByVal CodEdeAbgMix As Decimal) As Integer
        Dim datasetContrato As wsAcoesComerciais.DatasetContratoXAbrangenciaMix
        Dim result As Integer
        datasetContrato = Controller.ObterContratosXAbrangenciasMix(CodEdeAbgMix, NumCslCttFrn, NumCttFrn, TipEdeAbgMix)

        If datasetContrato.T0124996.Rows.Count > 0 Then
            result = CInt(datasetContrato.T0124996(0).TIPBSECALAPUVLRRCB)
        Else
            result = -1
        End If

        Return result
    End Function

    Private Function ObtemTipoApuracao(ByVal NumCttFrn As Decimal, ByVal NumCslCttFrn As Decimal, ByVal TipEdeAbgMix As Decimal, ByVal CodEdeAbgMix As Decimal) As Integer
        Dim datasetContrato As wsAcoesComerciais.DatasetContratoXAbrangenciaMix
        Dim result As Integer
        datasetContrato = Controller.ObterContratosXAbrangenciasMix(CodEdeAbgMix, NumCslCttFrn, NumCttFrn, TipEdeAbgMix)

        If datasetContrato.T0124996.Rows.Count > 0 Then
            If datasetContrato.T0124996(0).IsFLGFXAAVLPERNull Then
                result = 1     'apuracao por valor / meta a ser cumprida
            Else
                If datasetContrato.T0124996(0).FLGFXAAVLPER = String.Empty Then
                    result = 1 'apuracao por valor / meta a ser cumprida
                Else
                    result = 2 'apuracao por faixa
                End If
            End If
        Else
            result = -1
        End If

        Return result
    End Function

#End Region

    Private Function Validar() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = String.Empty

        Try
            Validar = True

            'Opção1
            If rdlOpcoes.SelectedValue = "1" Then
                'Celula)
                If (Val(CmbCelula.SelectedValue)) >= 0 Then
                    'clausula
                    If txtCodClausula.ValueDecimal = 0 Then
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "clausula não informado"
                    ElseIf Not (IsNumeric(CmbClausula.SelectedValue)) Then
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "clausula não localizada"
                    ElseIf CDec(CmbClausula.SelectedValue) <> txtCodClausula.ValueDecimal Then
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "a clausula selecionada no combo não corresponde ao codigo digitado"
                    End If
                    'tipo de período
                    If CmbTipoPeriodo.SelectedValue = String.Empty Then
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "tipo de Período inválido"
                    End If
                    'Data período
                    If Not (IsDate(txtDataInicial.Text)) Then
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "data inicial do período não informada ou inválida"
                    ElseIf Not (IsDate(txtDataFinal.Text)) Then
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "data final do período não informada ou inválida"
                    ElseIf txtDataInicial.Date > txtDataFinal.Date Then
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "data inicial maior que data final"
                    End If
                Else
                    'Fornecedor
                    If ucFornecedor.CodFornecedor <= 0 Then
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "fornecedor não informado"
                    End If
                    'clausula
                    If txtCodClausula.ValueDecimal = 0 Then
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "clausula não informado"
                    ElseIf Not (IsNumeric(CmbClausula.SelectedValue)) Then
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "clausula não localizada"
                    ElseIf CDec(CmbClausula.SelectedValue) <> txtCodClausula.ValueDecimal Then
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "a clausula selecionada no combo não corresponde ao codigo digitado"
                    End If
                    'tipo de período
                    If CmbTipoPeriodo.SelectedValue = String.Empty Then
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "tipo de Período inválido"
                    End If
                    'Data período
                    If Not (IsDate(txtDataInicial.Text)) Then
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "data inicial do período não informada ou inválida"
                    ElseIf Not (IsDate(txtDataFinal.Text)) Then
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "data final do período não informada ou inválida"
                    ElseIf txtDataInicial.Date > txtDataFinal.Date Then
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "data inicial maior que data final"
                    End If
                    'contrato
                    If CmbContrato.SelectedValue = String.Empty Then
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "contrato inválido"
                    End If
                    'Entidade
                    If TxtCodAbrangencia.Text = "2" Or TxtCodAbrangencia.Text = "3" Then
                        If CodEntidade.Text = String.Empty Then
                            If mensagemErro.Length > 0 Then mensagemErro &= ", "
                            mensagemErro &= "entidade inválida"
                        End If
                    End If
                    'Abrangencia
                    If TxtCodAbrangencia.Text = String.Empty Then
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "abrangencia inválida"
                    ElseIf CmbAbrangencia.SelectedValue = String.Empty Then
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "abrangência mix inválida"
                    End If
                    'num.período inválido
                    If txtNumRefPod.Text = String.Empty Then
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "voce deve escolher um período"
                    End If
                End If
            End If
            'Opção2
            If rdlOpcoes.SelectedValue = "2" Then
                'Fornecedor
                If ucFornecedor.CodFornecedor <= 0 Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "fornecedor não informado"
                End If
                'clausula
                If txtCodClausula.ValueDecimal = 0 Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "clausula não informado"
                ElseIf Not (IsNumeric(CmbClausula.SelectedValue)) Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "clausula não localizada"
                ElseIf CDec(CmbClausula.SelectedValue) <> txtCodClausula.ValueDecimal Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "a clausula selecionada no combo não corresponde ao codigo digitado"
                End If
                'tipo de período
                If CmbTipoPeriodo.SelectedValue = String.Empty Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "tipo de Período inválido"
                End If
                'Data período
                If Not (IsDate(txtDataInicial.Text)) Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "data inicial do período não informada ou inválida"
                ElseIf Not (IsDate(txtDataFinal.Text)) Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "data final do período não informada ou inválida"
                ElseIf txtDataInicial.Date > txtDataFinal.Date Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "data inicial maior que data final"
                End If
                'contrato
                If CmbContrato.SelectedValue = String.Empty Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "contrato inválido"
                End If
                'Entidade
                If TxtCodAbrangencia.Text = "2" Or TxtCodAbrangencia.Text = "3" Then
                    If CodEntidade.Text = String.Empty Then
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "entidade inválida"
                    End If
                End If
                'Abrangencia
                If TxtCodAbrangencia.Text = String.Empty Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "abrangencia inválida"
                ElseIf CmbAbrangencia.SelectedValue = String.Empty Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "abrangência mix inválida"
                End If
                'num.período inválido
                If txtNumRefPod.Text = String.Empty Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "você deve escolher um período"
                End If
            End If
            'Opção3
            If rdlOpcoes.SelectedValue = "3" Then
                'periodo(Data)
                If IsDate(txtDataInicial.Text) And IsDate(txtDataFinal.Text) Then
                    'data atual
                    If (Date.Now >= txtDataInicial.Date) And (Date.Now < Date.Parse(txtDataFinal.Text)) Then
                        'clausula
                        If txtCodClausula.ValueDecimal = 0 Then
                            If mensagemErro.Length > 0 Then mensagemErro &= ", "
                            mensagemErro &= "clausula não informado"
                        ElseIf Not (IsNumeric(CmbClausula.SelectedValue)) Then
                            If mensagemErro.Length > 0 Then mensagemErro &= ", "
                            mensagemErro &= "clausula não localizada"
                        ElseIf CDec(CmbClausula.SelectedValue) <> txtCodClausula.ValueDecimal Then
                            If mensagemErro.Length > 0 Then mensagemErro &= ", "
                            mensagemErro &= "a clausula selecionada no combo não corresponde ao codigo digitado"
                        End If
                        'tipo de período
                        If CmbTipoPeriodo.SelectedValue = String.Empty Then
                            If mensagemErro.Length > 0 Then mensagemErro &= ", "
                            mensagemErro &= "tipo de Período inválido"
                        End If
                        'Data período
                        If Not (IsDate(txtDataInicial.Text)) Then
                            If mensagemErro.Length > 0 Then mensagemErro &= ", "
                            mensagemErro &= "data inicial do período não informada ou inválida"
                        ElseIf Not (IsDate(txtDataFinal.Text)) Then
                            If mensagemErro.Length > 0 Then mensagemErro &= ", "
                            mensagemErro &= "data final do período não informada ou inválida"
                        ElseIf txtDataInicial.Date > txtDataFinal.Date Then
                            If mensagemErro.Length > 0 Then mensagemErro &= ", "
                            mensagemErro &= "data inicial maior que data final"
                        End If
                        'Fornecedor
                        If ucFornecedor.CodFornecedor <= 0 Then
                            If mensagemErro.Length > 0 Then mensagemErro &= ", "
                            mensagemErro &= "fornecedor não informado"
                        End If
                        'contrato
                        If CmbContrato.SelectedValue = String.Empty Then
                            If mensagemErro.Length > 0 Then mensagemErro &= ", "
                            mensagemErro &= "contrato inválido"
                        End If
                        'abrangência 
                        If CmbAbrangencia.SelectedValue = String.Empty Then
                            If mensagemErro.Length > 0 Then mensagemErro &= ", "
                            mensagemErro &= "abrangência mix inválida"
                        End If
                        'Num.peridodo(referencia)
                        If txtNumRefPod.Text = String.Empty Then
                            If mensagemErro.Length > 0 Then mensagemErro &= ", "
                            mensagemErro &= "Você deve escolher um período"
                        End If
                    Else
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "Período de referência inválido. Simulação válida para períodos em aberto"
                    End If
                Else
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "data inicial ou data final inválida"
                End If
                If txtNumRefPod.ValueInt = 0 Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "número de perído inválido"
                End If
            End If
            'Opção4
            If rdlOpcoes.SelectedValue = "4" Then
                'Celula
                If (Val(CmbCelula.SelectedValue)) <= 0 Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "é obrigatório selecionar a célula"
                End If
                'Tipo Período
                If txtCodTipoPeriodo.ValueDecimal = 0 Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "o campo tipo de período é obrigatório"
                End If
                'Porcentagem
                If txtPercentualInicial.ValueDecimal < 0 Or txtPercentualFinal.ValueDecimal < 0 Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "o campo porcentagem é obrigatório"
                End If
                If txtPercentualInicial.ValueDecimal > txtPercentualFinal.ValueDecimal Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "o primeiro campo da porcentagem não pode ser maior que o segundo"
                End If
            End If

            If mensagemErro.Trim() <> String.Empty Then
                Page.RegisterStartupScript("Alerta", "<script>alert('" & (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1) & "');</script>")
                Return False
            End If
            lblErro.Visible = False

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Sub carregarCmbEntidadeOpcaoItens()
        Dim ds As wsAcoesComerciais.DatasetContratoXAbrangenciaMix

        CmbEntidade.Items.Clear()
        CodEntidade.Text = String.Empty

        Dim x As Decimal

        If Not IsNumeric(CmbContrato.SelectedValue) Then Exit Sub
        If Val(CmbContrato.SelectedValue) = 0 Then Exit Sub
        If TxtCodAbrangencia.ValueDecimal = 0 Then Exit Sub

        ds = Controller.ObterContratosXAbrangenciasMix(0, txtCodClausula.ValueDecimal, CDec(CmbContrato.SelectedValue), TxtCodAbrangencia.ValueDecimal)
        For Each linha As wsAcoesComerciais.DatasetContratoXAbrangenciaMix.T0100086Row In ds.T0100086
            If linha.GetT0124996Rows.Length > 0 Then
                CmbEntidade.Items.Add(New ListItem(linha.DESMER.Trim, linha.CODMER.ToString))
            End If
        Next
        CodEntidade.Text = CmbEntidade.SelectedValue
        CodEntidade_ValueChange(Nothing, Nothing)
    End Sub

    Private Sub carregarCmbEntidadeOpcaoCategoria()
        Dim ds As wsAcoesComerciais.DatasetContratoXAbrangenciaMix

        CmbEntidade.Items.Clear()
        CodEntidade.Text = String.Empty

        If Not IsNumeric(CmbContrato.SelectedValue) Then Exit Sub
        If Val(CmbContrato.SelectedValue) = 0 Then Exit Sub
        If TxtCodAbrangencia.ValueDecimal = 0 Then Exit Sub

        ds = Controller.ObterContratosXAbrangenciasMix(0, txtCodClausula.ValueDecimal, CDec(CmbContrato.SelectedValue), TxtCodAbrangencia.ValueDecimal)
        For Each linha As wsAcoesComerciais.DatasetContratoXAbrangenciaMix.QueryDeT0100132Row In ds.QueryDeT0100132
            CmbEntidade.Items.Add(New ListItem(linha.DESCLSMER.ToString, linha.CODCTGUNIMER.ToString))
        Next
        CodEntidade.Text = CmbEntidade.SelectedValue
    End Sub

    Private Sub carregarCmbAbrangencia()
        Dim ds As wsAcoesComerciais.DatasetContratoXAbrangenciaMix

        CmbAbrangencia.Items.Clear()
        TxtCodAbrangencia.Text = String.Empty

        If Not IsNumeric(CmbContrato.SelectedValue) Then Exit Sub
        If txtCodClausula.ValueDecimal = 0 Then Exit Sub
        If Val(CmbContrato.SelectedValue) = 0 Then Exit Sub

        ds = Controller.ObterContratosXAbrangenciasMix(0, txtCodClausula.ValueDecimal, CDec(CmbContrato.SelectedValue), 0)
        For Each linha As wsAcoesComerciais.DatasetContratoXAbrangenciaMix.T0124996Row In ds.T0124996
            CmbAbrangencia.Items.Add(New ListItem(linha.T0125011Row.DESEDEABGMIX, linha.T0125011Row.TIPEDEABGMIX.ToString))
        Next
        TxtCodAbrangencia.Text = CmbAbrangencia.SelectedValue

    End Sub

    Private Sub carregarCmbTipoPeriodo()
        Dim ds As wsAcoesComerciais.DatasetContratoXPeriodo
        Dim flagCarregarTodosPeriodos As Boolean = False

        CmbTipoPeriodo.Items.Clear()
        txtCodTipoPeriodo.Text = String.Empty

        If Not IsNumeric(CmbContrato.SelectedValue) Then flagCarregarTodosPeriodos = True
        If txtCodClausula.ValueDecimal = 0 Then flagCarregarTodosPeriodos = True
        If Val(CmbContrato.SelectedValue) = 0 Then flagCarregarTodosPeriodos = True

        If flagCarregarTodosPeriodos Then
            'ds = Controller.ObterContratoXPeriodo(Nothing, 0, 0, 0, 0)
            'For Each linha As wsAcoesComerciais.DatasetContratoXPeriodo.T0124970Row In ds.T0124970
            '    CmbTipoPeriodo.Items.Add(New ListItem(linha.DESPODCTTFRN.ToString, linha.TIPPODCTTFRN.ToString))
            'Next
        Else
            ds = Controller.ObterContratosXPeriodos(txtCodClausula.ValueDecimal, CDec(CmbContrato.SelectedValue), 0, 0)
            For Each linha As wsAcoesComerciais.DatasetContratoXPeriodo.T0124970Row In ds.T0124970
                If linha.GetT0124988Rows.Length > 0 Then
                    CmbTipoPeriodo.Items.Add(New ListItem(linha.DESPODCTTFRN.ToString, linha.TIPPODCTTFRN.ToString))
                End If
            Next
            'For Each linha As wsAcoesComerciais.DatasetContratoXPeriodo.T0124988Row In ds.T0124988
            '    CmbTipoPeriodo.Items.Add(New ListItem(linha.T0124970Row.DESPODCTTFRN.ToString, linha.T0124970Row.TIPPODCTTFRN.ToString))
            'Next
        End If
        txtCodTipoPeriodo.Text = CmbTipoPeriodo.SelectedValue

    End Sub

    Private Sub carregarCmbTipoPeriodoParaSimulacaoPorCelula()
        Dim ds As wsAcoesComerciais.DatasetTipoPeriodo

        ds = Controller.ObterTiposPeriodo("", 0)
        CmbTipoPeriodo2.Items.Clear()
        For Each linha As wsAcoesComerciais.DatasetTipoPeriodo.T0124970Row In ds.T0124970
            If linha.TIPPODCTTFRN = 1 Or linha.TIPPODCTTFRN = 2 Then
                CmbTipoPeriodo2.Items.Add(New ListItem(linha.DESPODCTTFRN, linha.TIPPODCTTFRN.ToString))
            End If
        Next
        txtCodTipoPeriodo2.Text = CmbTipoPeriodo2.SelectedValue

    End Sub

    Private Sub carregarCmbClausula()
        'Obtem as clausulas do contrato
        Dim DatasetContrato As wsAcoesComerciais.DatasetContrato
        Dim datasetClausulaContrato As wsAcoesComerciais.DatasetClausulaContrato

        CmbClausula.Items.Clear()
        txtCodClausula.Text = String.Empty

        If IsNumeric(CmbContrato.SelectedValue) Then
            DatasetContrato = Controller.ObterContratoXClausulaContrato(Nothing, Nothing, Nothing, 0, CDec(CmbContrato.SelectedValue))
            Util.carregarClausulaContrato(DatasetContrato, CmbClausula, Nothing)

            If DatasetContrato.T0124961.Rows.Count = 0 Then
                Util.AdicionaJsAlert(Me, "Cláusula inexistente")
                Exit Sub
            End If

        ElseIf IsNumeric(CmbCelula.SelectedValue) Then
            If CDec(CmbCelula.SelectedValue) >= 0 Then
                datasetClausulaContrato = Controller.ObterClausulasContrato(String.Empty, 0)

                If datasetClausulaContrato.T0124953.Rows.Count = 0 Then
                    Util.AdicionaJsAlert(Me, "Cláusula inexistente")
                    Exit Sub
                End If

                For Each linha As wsAcoesComerciais.DatasetClausulaContrato.T0124953Row In datasetClausulaContrato.T0124953
                    CmbClausula.Items.Add(New ListItem(Format(linha.NUMCSLCTTFRN, "0000") & " - " & linha.DESCSLCTTFRN, linha.NUMCSLCTTFRN.ToString))
                Next
            End If
        End If
        txtCodClausula.Text = CmbClausula.SelectedValue

    End Sub

    Private Sub carregarCmbContrato()
        CmbContrato.Items.Clear()
        CmbContrato.Items.Add(New ListItem(String.Empty, "-1"))
        'Carrega Contrato
        For Each linha As wsAcoesComerciais.DatasetContrato.T0124945Row In Controller.ObterContratos(0, 0, String.Empty, ucFornecedor.CodFornecedor, 0).T0124945
            CmbContrato.Items.Add(New ListItem(linha.NUMCTTFRN.ToString, linha.NUMCTTFRN.ToString))
        Next
    End Sub

    Private Sub carregarCmbComprador()
        MostrarEsconderLinhasDeAcordoComItemSelecionadoCelula()

        'Limpa o combom de compradores
        cmbComprador.Items.Clear()

        'Validações
        If Not IsNumeric(CmbCelula.SelectedValue) Then Exit Sub
        If Convert.ToDecimal(CmbCelula.SelectedValue) = 0 Then Exit Sub

        'Consulta a celula selecionada para encontrar o gerente de projeto
        Dim ds As wsAcoesComerciais.DatasetCelula
        ds = Controller.ObterCelula(Convert.ToDecimal(CmbCelula.SelectedValue))

        'Se não econtrou a celula sai da função
        If ds.T0118570.Rows.Count = 0 Then Exit Sub

        'Carregar combo de compradores, que pertencem ao gerente de produto
        'selecionado na celula
        Util.carregarCmbComprador(Controller.ObterCompradores(ds.T0118570(0).CODGERPRD, Nothing, Nothing, Nothing, 1, "", ""), cmbComprador, New ListItem("", "0"))
    End Sub

    Private Sub carregarCmbEntidade()
        'Dependendo do tipo de abrangencia popula a entidade
        If TxtCodAbrangencia.ValueDecimal = 1 Then      'Todos
            CodEntidade.Text = "0"
            CmbEntidade.Items.Clear()
            CmbEntidade.Enabled = False
        ElseIf TxtCodAbrangencia.ValueDecimal = 2 Then  'Categoria
            carregarCmbEntidadeOpcaoCategoria()
            CmbEntidade.Enabled = True
        ElseIf TxtCodAbrangencia.ValueDecimal = 3 Then  'Itens
            carregarCmbEntidadeOpcaoItens()
            CmbEntidade.Enabled = True
        ElseIf TxtCodAbrangencia.ValueDecimal = 4 Then  'Itens Novos
            CodEntidade.Text = "0"
            CmbEntidade.Items.Clear()
            CmbEntidade.Enabled = False
        End If
    End Sub

    Private Sub atualizarGrid()
        Try
            Dim NUMCTTFRN As Decimal
            Dim NUMCSLCTTFRN As Decimal
            Dim TIPPODCTTFRN As Decimal

            'Limpa campos 
            txtNumRefPod.Text = ""
            txtDataInicial.Text = ""
            txtDataFinal.Text = ""

            If IsNumeric(CmbContrato.SelectedValue) Then
                NUMCTTFRN = CDec(CmbContrato.SelectedValue)
            End If
            NUMCSLCTTFRN = txtCodClausula.ValueDecimal
            TIPPODCTTFRN = txtCodTipoPeriodo.ValueDecimal

            'Caso não tenha encontrado os 3 parametros 
            'sai do método e limpa o grid
            If NUMCTTFRN = 0 Or _
               NUMCSLCTTFRN = 0 Or _
               TIPPODCTTFRN = 0 Then
                'uWebGrid.DataSource = New wsAcoesComerciais.DatasetContratoXPeriodo
                uWebGrid.DataBind()
                Exit Sub
            End If

            'Popula o grid
            DatasetContratoXPeriodo1 = Controller.ObterContratosXPeriodos(NUMCSLCTTFRN, NUMCTTFRN, 0, TIPPODCTTFRN)
            With uWebGrid
                .DataBind()
            End With

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub MostrarLinhasDeSimulacaoPorCelula(ByVal flagMostrar As Boolean)
        'Célula
        TD3.Visible = flagMostrar
        TD4.Visible = flagMostrar
        'Fornecedor
        TD5.Visible = Not flagMostrar
        TD6.Visible = Not flagMostrar
        'Contrato
        TD7.Visible = Not flagMostrar
        TD8.Visible = Not flagMostrar
        'Clausula
        TD9.Visible = Not flagMostrar
        TD10.Visible = Not flagMostrar
        'Abrangencia
        TD11.Visible = Not flagMostrar
        TD12.Visible = Not flagMostrar
        'Entidade
        TD13.Visible = Not flagMostrar
        TD14.Visible = Not flagMostrar
        'Tipo Período
        TD15.Visible = Not flagMostrar
        TD16.Visible = Not flagMostrar
        'Numero Período
        TD17.Visible = Not flagMostrar
        TD18.Visible = Not flagMostrar
        'Itens
        TD25.Visible = Not flagMostrar
        TD26.Visible = Not flagMostrar
        'Comprador
        TD19.Visible = flagMostrar
        TD20.Visible = flagMostrar
        'Período
        TD21.Visible = flagMostrar
        TD22.Visible = flagMostrar
        'Porcentagem
        TD23.Visible = flagMostrar
        TD24.Visible = flagMostrar

        'Carrega a célula de forma diferente, dependento se vai as linha de 
        'simulação por célula
        'Carrega celula
        If Not flagMostrar Then
            Util.carregarCmbCelula(Controller.ObterCelulas(0, 0, 0, String.Empty), CmbCelula, New ListItem("TODAS", "0"))
            CmbCelula.Items.Insert(0, New ListItem(String.Empty, "-1"))
        Else
            Util.carregarCmbCelula(Controller.ObterCelulas(0, 0, 0, String.Empty), CmbCelula, Nothing)
        End If
        MostrarEsconderLinhasDeAcordoComItemSelecionadoCelula()

    End Sub

    Private Sub MostrarEsconderLinhasDeAcordoComItemSelecionadoCelula()

        'Caso seja simulação por célula não executa esse método
        If rdlOpcoes.SelectedValue = "4" Then
            Exit Sub
        End If

        If Val(CmbCelula.SelectedValue) >= 0 Then

            'linha do fornecedor
            TD5.Visible = False
            TD6.Visible = False
            ucFornecedor.SelecionarVazio()

            'linha do contrato
            TD7.Visible = False
            TD8.Visible = False
            CmbContrato.Items.Clear()

            'linha da abrangencia
            TD11.Visible = False
            TD12.Visible = False
            CmbAbrangencia.Items.Clear()
            TxtCodAbrangencia.Text = String.Empty

            'linha da entidade
            TD13.Visible = False
            TD14.Visible = False
            CmbEntidade.Items.Clear()
            CodEntidade.Text = String.Empty

            'Habilita a digitação do período
            txtDataInicial.ReadOnly = False
            txtDataFinal.ReadOnly = False

        Else

            'carrega combo tipo período
            Util.carregarCmbTipoPeriodo(Controller.ObterTiposPeriodo(String.Empty, 0), CmbTipoPeriodo, Nothing)
            txtCodTipoPeriodo.Text = CmbTipoPeriodo.SelectedValue

            'carrega combo abrangencia
            Util.carregarCmbTipoAbrangenciaMix(Controller.ObterTiposAbrangenciaMix(String.Empty), CmbAbrangencia, Nothing)
            TxtCodAbrangencia.Text = CmbAbrangencia.SelectedValue

            'linha do fornecedor
            TD5.Visible = True
            TD6.Visible = True

            'linha do contrato
            TD7.Visible = True
            TD8.Visible = True

            'linha da abrangencia
            TD11.Visible = True
            TD12.Visible = True

            'linha da entidade
            TD13.Visible = True
            TD14.Visible = True

            'Habilita a digitação do período
            txtDataInicial.ReadOnly = True
            txtDataFinal.ReadOnly = True
        End If

        atualizarGrid()
        carregarCmbClausula()
    End Sub

#End Region

End Class