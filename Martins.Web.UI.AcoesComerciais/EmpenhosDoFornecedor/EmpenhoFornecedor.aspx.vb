Public Class EmpenhoFornecedor
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTransferenciaVerbaFornecedor1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor
        Me.DatasetTituloPagamentoContrato1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTituloPagamentoContrato
        Me.dsEmpenho = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetEmpenho
        CType(Me.DatasetTransferenciaVerbaFornecedor1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetTituloPagamentoContrato1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsEmpenho, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTransferenciaVerbaFornecedor1
        '
        Me.DatasetTransferenciaVerbaFornecedor1.DataSetName = "DatasetTransferenciaVerbaFornecedor"
        Me.DatasetTransferenciaVerbaFornecedor1.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DatasetTituloPagamentoContrato1
        '
        Me.DatasetTituloPagamentoContrato1.DataSetName = "DatasetTituloPagamentoContrato"
        Me.DatasetTituloPagamentoContrato1.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'dsEmpenho
        '
        Me.dsEmpenho.DataSetName = "DatasetEmpenho"
        Me.dsEmpenho.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTransferenciaVerbaFornecedor1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetTituloPagamentoContrato1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsEmpenho, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnAprovar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnReprovar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents grdOrigem As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents grdFluxos As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents DatasetCelula1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetCelula
    Protected WithEvents DataSetEstruturaCompra1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.dataSetEstruturaCompra
    Protected WithEvents lkbTodas As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lkbNenhum As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnSair As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnClonar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtDatRefLmt As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents lkbProcessaCloseModalSelecionarValores As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtNUMFLUAPV As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents cmbTIPSTAFLUAPV As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmbTIPALCVBAFRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnEnviar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagarFluxoTransferencia As System.Web.UI.WebControls.LinkButton
    Protected WithEvents TDSelecionar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TDApgar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TDApagarSelecao As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TDSalvar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TDEnviar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TDAprovar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TDReprovar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TDClonar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TDSair As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents lkbRecarregarPagina As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetTransferenciaVerbaFornecedor1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor
    Protected WithEvents DatasetTituloPagamentoContrato1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTituloPagamentoContrato
    Protected WithEvents txtValorAnteriorDeWucTIPDSNDSCBNFDSNTRN As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSomaDeVLRLMTCTB As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtDESJSTTRNVBA As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTIPDSNDSCBNFDSNTRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents cmbTIPDSNDSCBNFDSNTRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ValorTransferir As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents lnkFecharTela As System.Web.UI.WebControls.LinkButton
    Protected WithEvents dsEmpenho As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetEmpenho
    Protected WithEvents TRTipoFluxo As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents cmbTipoFluxo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmbINDMESTRNFLU As System.Web.UI.WebControls.DropDownList

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "Eventos"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Not IsPostBack) Then
                Me.IniciarPagina()
            Else
                Me.RecuperaEstado()
            End If
            MostrarOuEsconderBotoesDeAcordoComStatusDaTransferencia()
            HabilitaOuDesabilitaBotoesAprovacaoDependendoDoUsuarioEstarNoFluxo()
            carregarJavaScript()
            Controller.SetCurrentCulture()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        Me.SalvaEstado()
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        If ValidarPersistencia() Then
            If Not AtualizarDataset() Then
                Exit Sub
            End If
            If Not AtualizarDatasetComDadosDoGrid() Then
                Exit Sub
            End If
            AtualizarTransferenciaVerbasFornecedor()
            'Response.Redirect("EmpenhoFornecedorListar.aspx")
            Response.Redirect("EmpenhoFornecedor.aspx?NUMFLUAPV=" & Me.txtNUMFLUAPV.Text)
        End If
    End Sub

    Private Sub lkbTodas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkbTodas.Click
        Me.MarcarTodas()
    End Sub

    Private Sub lkbNenhum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkbNenhum.Click
        Me.DesmarcarTodas()
    End Sub

    Private Sub grdOrigem_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.LayoutEventArgs) Handles grdOrigem.InitializeLayout
        e.Layout.Bands(0).Columns(1).Header.Fixed = True
        e.Layout.Bands(0).Columns(2).Header.Fixed = True
    End Sub

    Private Sub lkbProcessaCloseModalSelecionarValores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkbProcessaCloseModalSelecionarValores.Click
        If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
            Exit Sub
        End If
        atualizarGridOrigem()
        atualizarGridFluxos()
        atualizartxtSomaDeVLRLMTCTB()
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Try
            If ValidarSelecaoDeValores() Then
                AtualizarDataset()
                carregarJanelaSelecaoDeValores()
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        Try
            If ValidarPersistencia() Then
                If Not AtualizarDataset() Then
                    Exit Sub
                End If
                If Not AtualizarDatasetComDadosDoGrid() Then
                    Exit Sub
                End If
                AtualizarTransferenciaVerbasFornecedor()
                Controller.IniciarFluxoTransferenciaVerbas(txtNUMFLUAPV.ValueDecimal)
                Response.Redirect("EmpenhoFornecedorListar.aspx")
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagarFluxoTransferencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagarFluxoTransferencia.Click
        Try
            ExcluirFluxo()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
        Try
            ExcluirRegistrosMarcados()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Response.Redirect("EmpenhoFornecedorListar.aspx")
    End Sub

    Private Sub btnAprovar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAprovar.Click
        Try
            WSCAcoesComerciais.numFluApv = Me.txtNUMFLUAPV.ValueDecimal
            carregarJanelaObservacaoAprovacaoFluxo()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnReprovar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprovar.Click
        Try
            WSCAcoesComerciais.numFluApv = Me.txtNUMFLUAPV.ValueDecimal
            carregarJanelaObservacaoReprovacaoFluxo()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnClonar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClonar.Click
        Try
            Dim NUMFLUAPV As Decimal
            NUMFLUAPV = Controller.ClonarTransferenciaEmpenhoFornecedor(txtNUMFLUAPV.ValueDecimal)
            Response.Redirect("EmpenhoFornecedor.aspx?NUMFLUAPV=" & NUMFLUAPV.ToString)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub lkbRecarregarPagina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkbRecarregarPagina.Click
        Try
            Me.AtualizarTela(txtNUMFLUAPV.ValueDecimal)
            MostrarOuEsconderBotoesDeAcordoComStatusDaTransferencia()
            'Response.Redirect("EmpenhoFornecedorListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub wucTIPDSNDSCBNFDSNTRN_EmpenhoAlterado(ByVal e As System.Web.UI.WebControls.ListItem)
        Try

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmbTIPDSNDSCBNFDSNTRN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTIPDSNDSCBNFDSNTRN.SelectedIndexChanged
        Try
            If Me.txtValorAnteriorDeWucTIPDSNDSCBNFDSNTRN.Text <> String.Empty And grdOrigem.Rows.Count > 0 Then
                If CType(Me.txtValorAnteriorDeWucTIPDSNDSCBNFDSNTRN.Text, Decimal) <> CType(cmbTIPDSNDSCBNFDSNTRN.SelectedValue, Decimal) Then
                    Util.AdicionaJsAlert(Me.Page, "Não é permitido alterar o empenho de destino quando existem valores na origem.")
                    cmbTIPDSNDSCBNFDSNTRN.SelectedValue = Me.txtValorAnteriorDeWucTIPDSNDSCBNFDSNTRN.Text
                    HabilitarOuDesabilitarMesLancamentoDependendoDoEmpenhoSelecionado()
                    Exit Sub
                End If
            End If

            Util.AdicionaJsFocus(Me.Page, cmbTIPDSNDSCBNFDSNTRN)
            CarregarCmbTIPALCVBAFRNComBaseNoEmpenhoDeDestino(CType(cmbTIPDSNDSCBNFDSNTRN.SelectedValue, Decimal))
            Me.txtValorAnteriorDeWucTIPDSNDSCBNFDSNTRN.Text = cmbTIPDSNDSCBNFDSNTRN.SelectedValue

            If Not IsNumeric(cmbTIPDSNDSCBNFDSNTRN.SelectedValue) Then
                txtTIPDSNDSCBNFDSNTRN.Text = ""
                HabilitarOuDesabilitarMesLancamentoDependendoDoEmpenhoSelecionado()
                Exit Sub
            End If

            If txtTIPDSNDSCBNFDSNTRN.Text <> cmbTIPDSNDSCBNFDSNTRN.SelectedValue Then
                txtTIPDSNDSCBNFDSNTRN.Text = cmbTIPDSNDSCBNFDSNTRN.SelectedValue
            End If

            HabilitarOuDesabilitarMesLancamentoDependendoDoEmpenhoSelecionado()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub txtTIPDSNDSCBNFDSNTRN_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtTIPDSNDSCBNFDSNTRN.ValueChange
        Try
            If cmbTIPDSNDSCBNFDSNTRN.SelectedValue <> txtTIPDSNDSCBNFDSNTRN.Text Then
                If Not cmbTIPDSNDSCBNFDSNTRN.Items.FindByValue(txtTIPDSNDSCBNFDSNTRN.Text) Is Nothing Then
                    cmbTIPDSNDSCBNFDSNTRN.SelectedValue = txtTIPDSNDSCBNFDSNTRN.Text
                Else
                    Util.AdicionaJsAlert(Me.Page, "Opção não disponível", True)
                    txtTIPDSNDSCBNFDSNTRN.Text = cmbTIPDSNDSCBNFDSNTRN.SelectedValue
                End If
            End If
            HabilitarOuDesabilitarMesLancamentoDependendoDoEmpenhoSelecionado()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub lnkFecharTela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkFecharTela.Click
        Try
            Response.Redirect("EmpenhoFornecedorListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#Region "Metodos de Carga"

    Private Sub IniciarPagina()
        CarregarcmbINDMESTRNFLUComOpcoesDeMesesParaTransferencia(Date.Today)
        CarregarEmpenhosDeDestino()
        CarregaDsEmpenho()
        FormataCabecalhoGrid()

        Me.txtNUMFLUAPV.ValueDecimal = CType(Page.Request.QueryString("NUMFLUAPV"), Decimal)

        If WSCAcoesComerciais.dsUsuarioCompra.T0113471.Item(0).TIPUSRSIS.ToUpper.Trim = "X" Then
            TRTipoFluxo.Visible = True
        Else
            TRTipoFluxo.Visible = False
        End If

        Me.AtualizarTela(Me.txtNUMFLUAPV.ValueDecimal)

        Util.AdicionaJsFocus(Me.Page, btnPesquisar)
    End Sub

    Private Sub carregarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        txtDESJSTTRNVBA.Attributes.Add("onKeyDown", "textContar(txtDESJSTTRNVBA,200)")
        txtDESJSTTRNVBA.Attributes.Add("onKeyUp", "textContar(txtDESJSTTRNVBA,200)")
        btnApagarFluxoTransferencia.Attributes.Add("OnClick", "return confirm('Você confirma a exclusão desse fluxo de transferencia?');")
        btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento();")
        btnEnviar.Attributes.Add("OnClick", "javascript:mostraAndamento();")
        btnPesquisar.Attributes.Add("OnClick", "javascript:mostraAndamento();")
        If btnAprovar.Enabled Then
            btnAprovar.Attributes.Add("OnClick", "javascript:mostraAndamento();")
        End If
        If btnReprovar.Enabled Then
            btnReprovar.Attributes.Add("OnClick", "javascript:mostraAndamento();")
        End If
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR")
    End Sub

    Private Sub carregarJanelaSelecaoDeValores()

        If WSCAcoesComerciais.dsUsuarioCompra.T0113471.Item(0).TIPUSRSIS.ToUpper.Trim = "X" Then
            Page.RegisterStartupScript("Selecao", "<script>CarregarJanelaSelecionarValoresTipoFluxo(" & Page.Request.QueryString("NUMFLUAPV") & ", """ & cmbTipoFluxo.SelectedValue & """);</script>")
        Else
            Page.RegisterStartupScript("Selecao", "<script>CarregarJanelaSelecionarValores(" & Page.Request.QueryString("NUMFLUAPV") & ");</script>")
        End If
    End Sub

    Private Sub carregarJanelaObservacaoAprovacaoFluxo()
        Page.RegisterStartupScript("Observacao", "<script>CarregarJanelaObservacaoAprovacaoFluxo();</script>")
    End Sub

    Public Sub carregarJanelaObservacaoReprovacaoFluxo()
        Page.RegisterStartupScript("Observacao", "<script>CarregarJanelaObservacaoReprovacaoFluxo();</script>")
    End Sub

    Private Sub FormataCabecalhoGrid()
        ''Reposiciona as colunas
        With Me.grdOrigem

            'Move as colunas que que não são título para a segunda linha
            Dim c As Infragistics.WebUI.UltraWebGrid.UltraGridColumn
            For Each c In .DisplayLayout.Bands(0).Columns
                c.Header.RowLayoutColumnInfo.OriginY = 1
            Next

            Dim ch As New Infragistics.WebUI.UltraWebGrid.ColumnHeader(True)

            'Expande a coluna para 2 linhas
            ch = .DisplayLayout.Bands(0).Columns.FromKey("Sel").Header
            ch.RowLayoutColumnInfo.SpanY = 2
            ch.RowLayoutColumnInfo.OriginY = 0
            ch.Style.VerticalAlign = VerticalAlign.Top

            'Expande a coluna para 2 linhas
            ch = .DisplayLayout.Bands(0).Columns.FromKey("DESDIVCMP").Header
            ch.RowLayoutColumnInfo.SpanY = 2
            ch.RowLayoutColumnInfo.OriginY = 0
            ch.Style.VerticalAlign = VerticalAlign.Top

            'Expande a coluna para 2 linhas
            ch = .DisplayLayout.Bands(0).Columns.FromKey("NOMCPR").Header
            ch.RowLayoutColumnInfo.SpanY = 2
            ch.RowLayoutColumnInfo.OriginY = 0
            ch.Style.VerticalAlign = VerticalAlign.Top

            'Cria a coluna de agrupamento FORNECEDOR
            ch = New Infragistics.WebUI.UltraWebGrid.ColumnHeader(True)
            ch.Caption = "FORNECEDOR"
            ch.RowLayoutColumnInfo.OriginY = 0
            ch.RowLayoutColumnInfo.OriginX = 3
            ch.RowLayoutColumnInfo.SpanX = 2
            ch.Style.HorizontalAlign = HorizontalAlign.Center
            ch.Style.Height = New System.Web.UI.WebControls.Unit(21, UnitType.Pixel)
            .DisplayLayout.Bands(0).HeaderLayout.Add(ch)

            'Cria a coluna de agrupamento EMPENHO
            ch = New Infragistics.WebUI.UltraWebGrid.ColumnHeader(True)
            ch.Caption = "EMPENHO"
            ch.RowLayoutColumnInfo.OriginY = 0
            ch.RowLayoutColumnInfo.OriginX = 5
            ch.RowLayoutColumnInfo.SpanX = 2
            ch.Style.HorizontalAlign = HorizontalAlign.Center
            ch.Style.Height = New System.Web.UI.WebControls.Unit(21, UnitType.Pixel)
            .DisplayLayout.Bands(0).HeaderLayout.Add(ch)

            'Expande a coluna para 2 linhas
            ch = .DisplayLayout.Bands(0).Columns.FromKey("DESALCVBAFRN").Header
            ch.RowLayoutColumnInfo.SpanY = 2
            ch.RowLayoutColumnInfo.OriginY = 0
            ch.Style.VerticalAlign = VerticalAlign.Top

            'Expande a coluna para 2 linhas
            ch = .DisplayLayout.Bands(0).Columns.FromKey("VLRLMTCTB").Header
            ch.RowLayoutColumnInfo.SpanY = 2
            ch.RowLayoutColumnInfo.OriginY = 0
            ch.Style.VerticalAlign = VerticalAlign.Top

            'Expande a coluna para 2 linhas
            ch = .DisplayLayout.Bands(0).Columns.FromKey("VlrSldDsp").Header
            ch.RowLayoutColumnInfo.SpanY = 2
            ch.RowLayoutColumnInfo.OriginY = 0
            ch.Style.VerticalAlign = VerticalAlign.Top
        End With
    End Sub

    Private Function atualizarGridOrigem() As Boolean
        Try
            'Me.DatasetTransferenciaVerbaFornecedor1.QueryRLCTRNVBAFRN.Rows.Clear()
            'Me.DatasetTransferenciaVerbaFornecedor1.Merge(Controller.ObterRelacaoTransferenciaVerbaFornecedorJoinT0153541JoinT0100426JoinT0113625JoinT0118570JoinT0109059(WSCAcoesComerciais.numFluApv))

            If Me.DatasetTransferenciaVerbaFornecedor1.QueryRLCTRNVBAFRN.Rows.Count > 0 Then
                Me.DatasetTransferenciaVerbaFornecedor1.QueryRLCTRNVBAFRN.DefaultView(0).DataView.Sort = "NOMFRN, TIPDSNDSCBNFORITRN"
            End If

            With Me.grdOrigem
                .DataSource = Me.DatasetTransferenciaVerbaFornecedor1
                .DataMember = "QueryRLCTRNVBAFRN"
                .DataBind()
            End With

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Function atualizarGridFluxos() As Boolean
        Try
            'Me.DatasetTransferenciaVerbaFornecedor1.QueryRLCTRNVBAFRN.Rows.Clear()
            'Me.DatasetTransferenciaVerbaFornecedor1.Merge(Controller.ObterRelacaoTransferenciaVerbaFornecedorJoinT0153541JoinT0100426JoinT0113625JoinT0118570JoinT0109059(WSCAcoesComerciais.numFluApv))

            With Me.grdFluxos
                .DataSource = Me.DatasetTransferenciaVerbaFornecedor1
                .DataBind()
            End With

            'Pega a data no primeiro fluxo
            If Me.DatasetTransferenciaVerbaFornecedor1.queryFluxos.Rows.Count > 0 Then
                Me.txtDatRefLmt.Value = Me.DatasetTransferenciaVerbaFornecedor1.queryFluxos(0).DATHRAFLUAPV
            End If

            'Atualiza opções de mês para transferencia (Lancar em)
            If IsDate(txtDatRefLmt.Value) Then
                CarregarcmbINDMESTRNFLUComOpcoesDeMesesParaTransferencia(CType(txtDatRefLmt.Value, Date))
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Function atualizartxtSomaDeVLRLMTCTB() As Boolean
        Try
            Dim SomaDeVLRLMTCTB As Decimal = 0
            For Each QueryRLCTRNVBAFRN As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor.QueryRLCTRNVBAFRNRow In Me.DatasetTransferenciaVerbaFornecedor1.QueryRLCTRNVBAFRN
                SomaDeVLRLMTCTB += QueryRLCTRNVBAFRN.VLRLMTCTB
            Next
            txtSomaDeVLRLMTCTB.ValueDecimal = SomaDeVLRLMTCTB
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Function CarregarCmbTIPALCVBAFRNComBaseNoEmpenhoDeDestino(ByVal TIPALCVBAFRN As Decimal) As Boolean
        If TIPALCVBAFRN = 42 Then
            'Se não existir a opção 'Marketing' Insere
            If cmbTIPALCVBAFRN.Items.FindByValue("2") Is Nothing Then
                cmbTIPALCVBAFRN.Items.Add(New ListItem("MARKETING", "2"))
            End If
        Else 'If TIPALCVBAFRN > 0 Then
            'Se existir a opção 'Marketing' Exclui
            If Not cmbTIPALCVBAFRN.Items.FindByValue("2") Is Nothing Then
                cmbTIPALCVBAFRN.Items.Remove(cmbTIPALCVBAFRN.Items.FindByValue("2"))
            End If
        End If
    End Function

    Private Sub CarregarEmpenhosDeDestino()
        Dim dsEmpenho As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetEmpenho
        dsEmpenho = Controller.ObterEmpenhos(String.Empty, String.Empty, String.Empty, 0, String.Empty)

        For Each T0109059Row As wsAcoesComerciais.DatasetEmpenho.T0109059Row In dsEmpenho.T0109059.Select(String.Empty, "TIPDSNDSCBNF")
            If T0109059Row.FLGCTBDSNDSC.ToUpper = "S" Or T0109059Row.TIPDSNDSCBNF = 1 Or T0109059Row.TIPDSNDSCBNF = 97 Then
                cmbTIPDSNDSCBNFDSNTRN.Items.Add(New ListItem(T0109059Row.TIPDSNDSCBNF.ToString("0000") & " - " & T0109059Row.DESDSNDSCBNF, T0109059Row.TIPDSNDSCBNF.ToString()))
            End If
        Next

        'Adicionar a opção selecione
        cmbTIPDSNDSCBNFDSNTRN.Items.Insert(0, New ListItem("SELECIONE->", "0"))
        cmbTIPDSNDSCBNFDSNTRN.SelectedValue = "1"
        txtTIPDSNDSCBNFDSNTRN.Text = "1"
    End Sub

    Private Sub CarregaDsEmpenho()
        dsEmpenho = Controller.ObterEmpenhos(String.Empty, String.Empty, String.Empty, 0, String.Empty)
    End Sub

#End Region

#Region "Metodos de controle"

    Private Sub RecuperaEstado()
        Me.DatasetTransferenciaVerbaFornecedor1 = WSCAcoesComerciais.dsTransferenciaVerbaFornecedor
        If Not ViewState.Item(dsEmpenho.DataSetName) Is Nothing Then
            dsEmpenho = DirectCast(Me.ViewState.Item(dsEmpenho.DataSetName), wsAcoesComerciais.DatasetEmpenho)
        End If
        If Me.DatasetTransferenciaVerbaFornecedor1 Is Nothing Then
            Response.Redirect("EmpenhoFornecedorListar.aspx")
        End If
    End Sub

    Private Sub SalvaEstado()
        WSCAcoesComerciais.dsTransferenciaVerbaFornecedor = Me.DatasetTransferenciaVerbaFornecedor1
        If Not dsEmpenho Is Nothing Then Me.ViewState.Add(dsEmpenho.DataSetName, dsEmpenho)
    End Sub

    Private Sub AtualizarTela(ByVal NUMFLUAPV As Decimal)
        'Consulta a transferencia
        Me.DatasetTransferenciaVerbaFornecedor1 = Controller.ObterTransferenciaVerbaFornecedor(NUMFLUAPV)

        'Verifica se encontrou
        If Me.DatasetTransferenciaVerbaFornecedor1.CADTRNVBAFRN.Rows.Count = 0 Then
            Util.AdicionaJsAlert(Me.Page, "Registro não encontrado", True)
            Exit Sub
        End If

        'Transfere a linha encontrada para variável
        Dim CADTRNVBAFRNRow As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow
        CADTRNVBAFRNRow = Me.DatasetTransferenciaVerbaFornecedor1.CADTRNVBAFRN(0)

        'Transfere os valores da linha para tela
        With CADTRNVBAFRNRow
            txtNUMFLUAPV.Value = .NUMFLUAPV
            If .TIPSTAFLUAPV.Trim.ToString <> "0" Then
                cmbTIPSTAFLUAPV.SelectedValue = .TIPSTAFLUAPV.Trim.ToString
            End If

            If .TIPDSNDSCBNFDSNTRN.ToString <> "0" Then
                cmbTIPDSNDSCBNFDSNTRN.SelectedValue = .TIPDSNDSCBNFDSNTRN.ToString
            End If

            txtTIPDSNDSCBNFDSNTRN.Text = cmbTIPDSNDSCBNFDSNTRN.SelectedValue

            If .TIPALCVBAFRN.ToString = "2" Then
                If cmbTIPALCVBAFRN.Items.FindByValue("2") Is Nothing Then
                    cmbTIPALCVBAFRN.Items.Add(New ListItem("MARKETING", "2"))
                End If
            End If

            cmbTIPALCVBAFRN.SelectedValue = .TIPALCVBAFRN.ToString
            txtDESJSTTRNVBA.Text = .DESJSTTRNVBA.Trim
            'If .INDMESTRNFLU.ToString <> "0" Then
            cmbINDMESTRNFLU.SelectedValue = .INDMESTRNFLU.ToString
            'End If

            cmbTipoFluxo.SelectedValue = .INDFLUTRNVBAMKT.ToString


            WSCAcoesComerciais.PERPSQSLDFRN = .PERPSQSLDFRN

            'If .INDFLUTRNVBAMKT = 1 Then
            '    cmbTipoFluxo.SelectedIndex = 1
            'Else
            '    cmbTipoFluxo.SelectedIndex = 0
            'End If
        End With

        WSCAcoesComerciais.numFluApv = txtNUMFLUAPV.ValueDecimal
        atualizarGridOrigem()
        atualizarGridFluxos()
        atualizartxtSomaDeVLRLMTCTB()

        'If CADTRNVBAFRNRow.TIPSTAFLUAPV <> Constants.TIPSTAFLUAPV_NOVO Then
        '    'grdOrigem.DisplayLayout.Bands(0).Columns(8).Width = New System.Web.UI.WebControls.Unit(80, UnitType.Pixel)
        '    'grdOrigem.DisplayLayout.Bands(0).Columns(8).Header.Style.Width = New System.Web.UI.WebControls.Unit(80, UnitType.Pixel)
        '    grdOrigem.DisplayLayout.Bands(0).Columns(8).Hidden = False
        'Else
        '    'grdOrigem.DisplayLayout.Bands(0).Columns(8).Width = New System.Web.UI.WebControls.Unit(1, UnitType.Pixel)
        '    'grdOrigem.DisplayLayout.Bands(0).HeaderLayout.Item(8).Style.Width = New System.Web.UI.WebControls.Unit(1, UnitType.Pixel)
        '    grdOrigem.DisplayLayout.Bands(0).Columns(8).Hidden = True
        'End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="TIPDSNDSCBNF"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Valmir]	27/10/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function EmpenhoEstaRelacionadoAEstoque(ByVal TIPDSNDSCBNF As Decimal) As Boolean
        Dim T0109059Row As wsAcoesComerciais.DatasetEmpenho.T0109059Row
        T0109059Row = Me.obterLinhaEmpenho(TIPDSNDSCBNF)
        If Not T0109059Row Is Nothing Then
            If T0109059Row.INDTIPDSNRCTCSTMER = 1 Then 'Está relacionado ao estoque = 1
                Return True
            End If
        End If
        Return False
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="TIPDSNDSCBNF"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Valmir]	27/10/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function obterLinhaEmpenho(ByVal TIPDSNDSCBNF As Decimal) As wsAcoesComerciais.DatasetEmpenho.T0109059Row
        Return dsEmpenho.T0109059.FindByTIPDSNDSCBNF(TIPDSNDSCBNF)
    End Function

    Private Sub MarcarTodas()
        For Each row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdOrigem.Rows
            row.Cells.Item(0).Value = True
        Next
    End Sub

    Private Sub DesmarcarTodas()
        For Each row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdOrigem.Rows
            row.Cells.Item(0).Value = False
        Next
    End Sub

    Private Sub MostrarOuEsconderBotoesDeAcordoComStatusDaTransferencia()
        Try
            Select Case cmbTIPSTAFLUAPV.SelectedValue
                Case "0" 'Nova
                    TDSelecionar.Visible = True
                    TDApgar.Visible = True
                    TDApagarSelecao.Visible = True
                    TDSalvar.Visible = True
                    TDEnviar.Visible = True
                    TDAprovar.Visible = False
                    TDReprovar.Visible = False
                    TDClonar.Visible = False
                    TDSair.Visible = True
                Case "1" 'Liberada
                    TDSelecionar.Visible = False
                    TDApgar.Visible = False
                    TDApagarSelecao.Visible = False
                    TDSalvar.Visible = False
                    TDEnviar.Visible = False
                    TDAprovar.Visible = True
                    TDReprovar.Visible = True
                    TDClonar.Visible = False
                    TDSair.Visible = True
                Case "2" 'Rejeitada
                    TDSelecionar.Visible = False
                    TDApgar.Visible = False
                    TDApagarSelecao.Visible = False
                    TDSalvar.Visible = False
                    TDEnviar.Visible = False
                    TDAprovar.Visible = False
                    TDReprovar.Visible = False
                    TDClonar.Visible = True
                    TDSair.Visible = True
                Case "3" 'Aprovado
                    TDSelecionar.Visible = False
                    TDApgar.Visible = False
                    TDApagarSelecao.Visible = False
                    TDSalvar.Visible = False
                    TDEnviar.Visible = False
                    TDAprovar.Visible = False
                    TDReprovar.Visible = False
                    TDClonar.Visible = False
                    TDSair.Visible = True
            End Select
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub HabilitaOuDesabilitaBotoesAprovacaoDependendoDoUsuarioEstarNoFluxo()
        Try
            If TDAprovar.Visible = False And TDReprovar.Visible = False Then
                Exit Sub
            End If

            Dim CODFNC As Decimal
            CODFNC = Controller.ObterFuncionarioLogadoSistema

            If FuncionarioEAprovadorDeFluxo(CODFNC) Then
                btnAprovar.Enabled = True
                btnReprovar.Enabled = True
            Else
                btnAprovar.Enabled = False
                btnReprovar.Enabled = False
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function FuncionarioEAprovadorDeFluxo(ByVal CODFNC As Decimal) As Boolean
        Try
            Dim dsTransferenciaVerbaFornecedor As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor
            dsTransferenciaVerbaFornecedor = Controller.ObterMinhasAprovavoesEmTransferenciaVerbasFornecedor(txtNUMFLUAPV.ValueDecimal, CODFNC)
            Return (dsTransferenciaVerbaFornecedor.CADTRNVBAFRNJOIN.Rows.Count > 0)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
            Return False
        End Try
    End Function

    Private Function CarregarcmbINDMESTRNFLUComOpcoesDeMesesParaTransferencia(ByVal DatRefLmt As Date) As Boolean
        Try
            If cmbINDMESTRNFLU.Items.Count = 0 Then
                cmbINDMESTRNFLU.Items.Add(New ListItem("MES APROVAÇÃO", "0"))
                cmbINDMESTRNFLU.Items.Add(New ListItem(Util.NomeDoMes(DatRefLmt.Month), "1"))
                cmbINDMESTRNFLU.Items.Add(New ListItem(Util.NomeDoMes(DatRefLmt.AddMonths(-1).Month), "2"))
                If Not cmbINDMESTRNFLU.Items.FindByValue("2") Is Nothing Then
                    cmbINDMESTRNFLU.SelectedValue = "2"
                End If
                Return True
            End If

            If DatRefLmt = Nothing Then
                Return True
            End If

            cmbINDMESTRNFLU.Items.FindByValue("1").Text = Util.NomeDoMes(DatRefLmt.Month)
            cmbINDMESTRNFLU.Items.FindByValue("2").Text = Util.NomeDoMes(DatRefLmt.AddMonths(-1).Month)
            Return True

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
            Return False
        End Try
    End Function

    Private Sub HabilitarOuDesabilitarMesLancamentoDependendoDoEmpenhoSelecionado()
        If txtTIPDSNDSCBNFDSNTRN.ValueDecimal <> 1 Then
            cmbINDMESTRNFLU.SelectedValue = "0"
            cmbINDMESTRNFLU.Enabled = False
        Else
            cmbINDMESTRNFLU.Enabled = True
        End If
    End Sub

#End Region

#Region "Metodos de Regra"
  
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	7/12/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function ExcluirRegistrosMarcados() As Boolean
        Try
            Dim NUMFLUAPV As Decimal
            Dim CODFRN As Decimal
            Dim TIPDSNDSCBNFORITRN As Decimal
            Dim TIPALCVBAFRN As Decimal

            Me.DatasetTransferenciaVerbaFornecedor1 = Controller.ObterTransferenciaVerbaFornecedor(txtNUMFLUAPV.ValueDecimal)

            For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdOrigem.Rows

                NUMFLUAPV = Me.txtNUMFLUAPV.ValueDecimal
                CODFRN = CType(linha.GetCellValue(Me.grdOrigem.Columns.FromKey("CODFRN")), Decimal)
                TIPDSNDSCBNFORITRN = CType(linha.GetCellValue(Me.grdOrigem.Columns.FromKey("TIPDSNDSCBNFORITRN")), Decimal)
                TIPALCVBAFRN = CType(linha.GetCellValue(Me.grdOrigem.Columns.FromKey("TIPALCVBAFRN")), Decimal)

                Dim rowRLCTRNVBAFRN As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRNRow = Me.DatasetTransferenciaVerbaFornecedor1.RLCTRNVBAFRN.FindByNUMFLUAPVCODFRNTIPDSNDSCBNFORITRNTIPALCVBAFRN(NUMFLUAPV, CODFRN, TIPDSNDSCBNFORITRN, TIPALCVBAFRN)
                rowRLCTRNVBAFRN = Me.DatasetTransferenciaVerbaFornecedor1.RLCTRNVBAFRN.FindByNUMFLUAPVCODFRNTIPDSNDSCBNFORITRNTIPALCVBAFRN(NUMFLUAPV, CODFRN, TIPDSNDSCBNFORITRN, TIPALCVBAFRN)

                Select Case CType(linha.Cells(0).Value, Boolean)
                    Case True 'A linha do grid foi selecionada
                        If rowRLCTRNVBAFRN Is Nothing Then
                            Util.AdicionaJsAlert(Me.Page, "Linha selecionada não encontrada. Fornecedor:" & CODFRN.ToString.Trim & ", Empenho:" & TIPDSNDSCBNFORITRN.ToString.Trim & ", Alocação:" & TIPALCVBAFRN.ToString.Trim)
                        End If
                        rowRLCTRNVBAFRN.Delete()

                    Case False 'A linha do grid não foi selecionada
                        'Não faz nada

                End Select

            Next
            If Me.DatasetTransferenciaVerbaFornecedor1.HasChanges Then
                Controller.AtualizarTransferenciaVerbaFornecedor(Me.DatasetTransferenciaVerbaFornecedor1)
                Me.DatasetTransferenciaVerbaFornecedor1 = Controller.ObterTransferenciaVerbaFornecedor(txtNUMFLUAPV.ValueDecimal)
            End If
            atualizarGridOrigem()
            atualizarGridFluxos()
            atualizartxtSomaDeVLRLMTCTB()

            Return True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
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
    ''' 	[Marcos Queiroz]	7/12/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function ExcluirFluxo() As Boolean
        Try
            Me.DatasetTransferenciaVerbaFornecedor1 = Controller.ObterTransferenciaVerbaFornecedor(txtNUMFLUAPV.ValueDecimal)

            'Apagar as relações
            For Each linha As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRNRow In Me.DatasetTransferenciaVerbaFornecedor1.RLCTRNVBAFRN
                If linha.NUMFLUAPV = Me.txtNUMFLUAPV.ValueDecimal Then
                    linha.Delete()
                End If
            Next

            'Apagar o cadastro (capa)
            For Each linha As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow In Me.DatasetTransferenciaVerbaFornecedor1.CADTRNVBAFRN
                If LINHA.NUMFLUAPV = Me.txtNUMFLUAPV.ValueDecimal Then
                    linha.Delete()
                End If
            Next

            Controller.AtualizarTransferenciaVerbaFornecedor(Me.DatasetTransferenciaVerbaFornecedor1)
            Response.Redirect("EmpenhoFornecedorListar.aspx")

            Return True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Function ValidarPersistencia() As Boolean

        If Not IsNumeric(cmbTIPDSNDSCBNFDSNTRN.SelectedValue) Then
            Util.AdicionaJsAlert(Me.Page, "Informe o empenho de destino")
            Return False
        ElseIf CType(cmbTIPDSNDSCBNFDSNTRN.SelectedValue, Decimal) = 0 Then
            Util.AdicionaJsAlert(Me.Page, "Informe o empenho de destino")
            Return False
        End If
        If Not IsNumeric(cmbTIPALCVBAFRN.SelectedValue) Then
            Util.AdicionaJsAlert(Me.Page, "Informe o tipo de alocação de destino")
            Return False
        End If
        If txtDESJSTTRNVBA.Text.Trim.Length = 0 Then
            Util.AdicionaJsAlert(Me.Page, "Informe a justificativa")
            Return False
        End If
        If txtTIPDSNDSCBNFDSNTRN.ValueDecimal <> 1 And cmbINDMESTRNFLU.SelectedValue <> "0" Then
            Util.AdicionaJsAlert(Me.Page, "Para o empenho '" & cmbTIPDSNDSCBNFDSNTRN.SelectedItem.Text.Trim & "' é obrigatório que o mês de lançamento seja:'" & cmbINDMESTRNFLU.Items.FindByValue("0").Text.Trim & "'")
            Return False
        End If
        For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdOrigem.Rows
            If Not ValidarPersistenciaLinhaDoGrid(linha) Then
                Return False
            End If
        Next
        Dim StrEmpenhos As String = String.Empty
        If txtTIPDSNDSCBNFDSNTRN.ValueDecimal <> 1 Then
            For Each Row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdOrigem.Rows
                If EmpenhoEstaRelacionadoAEstoque(CType(Row.GetCellValue(grdOrigem.Columns.FromKey("TIPDSNDSCBNFORITRN")), Decimal)) Then                    
                    StrEmpenhos &= CType(Row.GetCellValue(grdOrigem.Columns.FromKey("TIPDSNDSCBNFORITRN")), Decimal) & ", "
                End If
            Next
            If StrEmpenhos <> String.Empty Then
                Util.AdicionaJsAlert(Me.Page, "Transfêrencia não permitida!!" & vbCrLf & "Transfêrencia do(s) empenho(s) abaixo, permitida apenas [para resultado = 1]" & vbCrLf & StrEmpenhos)
                Return False
            End If
        End If
        Return True
    End Function

    Private Function ValidarSelecaoDeValores() As Boolean
        If Not IsNumeric(cmbTIPDSNDSCBNFDSNTRN.SelectedValue) Then
            Util.AdicionaJsAlert(Me.Page, "Informe o empenho de destino")
            Return False
        ElseIf CType(cmbTIPDSNDSCBNFDSNTRN.SelectedValue, Decimal) = 0 Then
            Util.AdicionaJsAlert(Me.Page, "Informe o empenho de destino")
            Return False
        End If
        Return True
    End Function

    Private Function ValidarPersistenciaLinhaDoGrid(ByVal linhaGrid As Infragistics.WebUI.UltraWebGrid.UltraGridRow) As Boolean
        Try
            If Not linhaGrid Is Nothing Then
                'Validações
                If CType(linhaGrid.GetCellValue(grdOrigem.Columns.FromKey("VLRLMTCTB")), Decimal) < 0 Then
                    Dim NOMFRN As String = CType(linhaGrid.GetCellValue(grdOrigem.Columns.FromKey("NOMFRN")), String)
                    Dim DESALCVBAFRN As String = CType(linhaGrid.GetCellValue(grdOrigem.Columns.FromKey("DESALCVBAFRN")), String)
                    Dim DESDSNDSCBNF As String = CType(linhaGrid.GetCellValue(grdOrigem.Columns.FromKey("DESDSNDSCBNF")), String)
                    Util.AdicionaJsAlert(Me.Page, "Não é permitido valor negativo. Fornecedor:" & NOMFRN.Trim & ", Alocação:" & DESALCVBAFRN.Trim & ", Empenho:" & DESDSNDSCBNF.Trim, True)
                    linhaGrid.Activate()
                    Return False
                End If

                'Trata um erro que acontece quando você clica na primeira coluna para selecionar a linha
                'nesse caso, não sei porque, o valor vem cem vezes maior
                Dim valorTransferir As Decimal
                valorTransferir = CType(linhaGrid.GetCellValue(grdOrigem.Columns.FromKey("VLRLMTCTB")), Decimal)
                If (valorTransferir / 100) = CType(linhaGrid.GetCellValue(grdOrigem.Columns.FromKey("VlrSldDsp")), Decimal) Then
                    valorTransferir = valorTransferir / 100
                    linhaGrid.Cells(9).Value = valorTransferir
                End If

                If valorTransferir > CType(linhaGrid.GetCellValue(grdOrigem.Columns.FromKey("VlrSldDsp")), Decimal) Then

                    Dim NOMFRN As String = CType(linhaGrid.GetCellValue(grdOrigem.Columns.FromKey("NOMFRN")), String)
                    Dim DESALCVBAFRN As String = CType(linhaGrid.GetCellValue(grdOrigem.Columns.FromKey("DESALCVBAFRN")), String)
                    Dim DESDSNDSCBNF As String = CType(linhaGrid.GetCellValue(grdOrigem.Columns.FromKey("DESDSNDSCBNF")), String)

                    Util.AdicionaJsAlert(Me.Page, "Não é permitido transferir valor maior que o disponível. Fornecedor:" & NOMFRN.Trim & ", Alocação:" & DESALCVBAFRN.Trim & ", Empenho:" & DESDSNDSCBNF.Trim, True)
                    linhaGrid.Cells(0).Value = False
                    linhaGrid.Activate()
                    Return False
                End If

            End If
            Return True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

#End Region

#Region "Metodos de Persistencia"

    Private Function AtualizarDataset() As Boolean
        'Obtem ou cria a linha
        Dim CADTRNVBAFRNRow As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow
        If Me.DatasetTransferenciaVerbaFornecedor1.CADTRNVBAFRN.Rows.Count = 0 Then
            CADTRNVBAFRNRow = Me.DatasetTransferenciaVerbaFornecedor1.CADTRNVBAFRN.NewCADTRNVBAFRNRow
        Else
            CADTRNVBAFRNRow = Me.DatasetTransferenciaVerbaFornecedor1.CADTRNVBAFRN(0)
        End If

        'Transfere valores da tela para o dataset
        With CADTRNVBAFRNRow
            .NUMFLUAPV = txtNUMFLUAPV.ValueDecimal
            .TIPSTAFLUAPV = cmbTIPSTAFLUAPV.SelectedValue
            .TIPDSNDSCBNFDSNTRN = CType(cmbTIPDSNDSCBNFDSNTRN.SelectedValue, Decimal)
            .TIPALCVBAFRN = CType(cmbTIPALCVBAFRN.SelectedValue, Decimal)
            .CODFNC = Controller.ObterFuncionarioLogadoSistema
            .DESJSTTRNVBA = txtDESJSTTRNVBA.Text
            .INDMESTRNFLU = CType(cmbINDMESTRNFLU.SelectedValue, Decimal)

            If WSCAcoesComerciais.dsUsuarioCompra.T0113471.Item(0).TIPUSRSIS.ToUpper.Trim = "X" Then
                .INDFLUTRNVBAMKT = CType(cmbTipoFluxo.SelectedValue, Decimal)
            Else
                .INDFLUTRNVBAMKT = 0
            End If
            .PERPSQSLDFRN = WSCAcoesComerciais.PERPSQSLDFRN
        End With

        'Se for linha nova adiciona
        If CADTRNVBAFRNRow.RowState = DataRowState.Detached Then
            Me.DatasetTransferenciaVerbaFornecedor1.CADTRNVBAFRN.AddCADTRNVBAFRNRow(CADTRNVBAFRNRow)
        End If

        Return True
    End Function

    Private Function AtualizarDataset(ByVal CADTRNVBAFRNRow As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow, _
                                      ByVal linhaGrid As Infragistics.WebUI.UltraWebGrid.UltraGridRow) As Boolean
        Try
            'Declaração das variaveis para transferencia dos dados
            Dim NUMFLUAPV As Decimal
            Dim CODFRN As Decimal
            Dim TIPDSNDSCBNFORITRN As Decimal
            Dim TIPALCVBAFRN As Decimal
            Dim VLRLMTCTB As Decimal
            Dim NOMFRN As String
            Dim DESALCVBAFRN As String
            Dim DESDSNDSCBNF As String

            'Transfere os valores da linha selecionada para as variaveis locais
            NUMFLUAPV = CADTRNVBAFRNRow.NUMFLUAPV
            CODFRN = CType(linhaGrid.GetCellValue(Me.grdOrigem.Columns.FromKey("CODFRN")), Decimal)
            TIPDSNDSCBNFORITRN = CType(linhaGrid.GetCellValue(Me.grdOrigem.Columns.FromKey("TIPDSNDSCBNFORITRN")), Decimal)
            TIPALCVBAFRN = CType(linhaGrid.GetCellValue(Me.grdOrigem.Columns.FromKey("TIPALCVBAFRN")), Decimal)
            VLRLMTCTB = CType(linhaGrid.GetCellValue(Me.grdOrigem.Columns.FromKey("VLRLMTCTB")), Decimal)
            NOMFRN = CType(linhaGrid.GetCellValue(grdOrigem.Columns.FromKey("NOMFRN")), String)
            DESALCVBAFRN = CType(linhaGrid.GetCellValue(grdOrigem.Columns.FromKey("DESALCVBAFRN")), String)
            DESDSNDSCBNF = CType(linhaGrid.GetCellValue(grdOrigem.Columns.FromKey("DESDSNDSCBNF")), String)

            'Obtem a linha que será atualizada, ou cria uma nova caso ela não exista
            Dim RLCTRNVBAFRNRow As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRNRow
            RLCTRNVBAFRNRow = Me.DatasetTransferenciaVerbaFornecedor1.RLCTRNVBAFRN.FindByNUMFLUAPVCODFRNTIPDSNDSCBNFORITRNTIPALCVBAFRN(NUMFLUAPV, CODFRN, TIPDSNDSCBNFORITRN, TIPALCVBAFRN)
            If RLCTRNVBAFRNRow Is Nothing Then
                Util.AdicionaJsAlert(Me.Page, "Linha do grid não foi localizada. Fornecedor:" & NOMFRN.Trim & ", Alocação:" & DESALCVBAFRN.Trim & ", Empenho:" & DESDSNDSCBNF.Trim, True)
                Return False
            End If

            'Transfere valores das variaveis para a linha da tabela
            With RLCTRNVBAFRNRow
                .VLRLMTCTB = VLRLMTCTB
                If VLRLMTCTB = 0 Then
                    .Delete()
                End If
            End With

            Return True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
            Return False
        End Try
    End Function

    Private Function AtualizarDatasetComDadosDoGrid() As Boolean
        Try
            'Verifica se existe registro na tabela de cadastro
            If Me.DatasetTransferenciaVerbaFornecedor1.CADTRNVBAFRN.Rows.Count = 0 Then
                Util.AdicionaJsAlert(Me.Page, "Não existe registro na tabela de cadastro da relação, tente novamente se o problema persistir informe ao analista responsável")
                Return False
            End If

            'Obtema linha da tabela de cadastro
            Dim CADTRNVBAFRNRow As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow
            CADTRNVBAFRNRow = Me.DatasetTransferenciaVerbaFornecedor1.CADTRNVBAFRN(0)

            'Atualiza o dataset
            For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdOrigem.Rows
                If Not AtualizarDataset(CADTRNVBAFRNRow, linha) Then
                    Return False
                End If
            Next

            Return True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
            Return False
        End Try
    End Function

    Private Function ExcluirLinhaDoDataset(ByVal CADTRNVBAFRNRow As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow, _
                                           ByVal linhaGrid As Infragistics.WebUI.UltraWebGrid.UltraGridRow) As Boolean
        Try
            'Declaração das variaveis para transferencia dos dados
            Dim NUMFLUAPV As Decimal
            Dim CODFRN As Decimal
            Dim TIPDSNDSCBNFORITRN As Decimal
            Dim TIPALCVBAFRN As Decimal

            'Transfere os valores da linha selecionada para as variaveis locais
            NUMFLUAPV = CADTRNVBAFRNRow.NUMFLUAPV
            CODFRN = CType(linhaGrid.GetCellValue(Me.grdOrigem.Columns.FromKey("CODFRN")), Decimal)
            TIPDSNDSCBNFORITRN = CType(linhaGrid.GetCellValue(Me.grdOrigem.Columns.FromKey("TIPDSNDSCBNFORITRN")), Decimal)
            TIPALCVBAFRN = CType(linhaGrid.GetCellValue(Me.grdOrigem.Columns.FromKey("TIPALCVBAFRN")), Decimal)

            'Obtem a linha que será excluída
            Dim RLCTRNVBAFRNRow As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRNRow
            RLCTRNVBAFRNRow = Me.DatasetTransferenciaVerbaFornecedor1.RLCTRNVBAFRN.FindByNUMFLUAPVCODFRNTIPDSNDSCBNFORITRNTIPALCVBAFRN(NUMFLUAPV, CODFRN, TIPDSNDSCBNFORITRN, TIPALCVBAFRN)

            'Exclui a linha
            If Not RLCTRNVBAFRNRow Is Nothing Then
                RLCTRNVBAFRNRow.Delete()
            End If

            Return True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
            Return False
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	7/12/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub AtualizarTransferenciaVerbasFornecedor()
        'Salva os registros
        If Me.DatasetTransferenciaVerbaFornecedor1.HasChanges Then
            Controller.AtualizarTransferenciaVerbaFornecedor(Me.DatasetTransferenciaVerbaFornecedor1)
            Me.DatasetTransferenciaVerbaFornecedor1 = Controller.ObterTransferenciaVerbaFornecedor(txtNUMFLUAPV.ValueDecimal)
        End If
    End Sub

#End Region

End Class