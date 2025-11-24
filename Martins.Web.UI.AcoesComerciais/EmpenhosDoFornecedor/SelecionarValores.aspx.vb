Public Class SelecionarValores
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetCelula1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetCelula
        Me.DataSetEstruturaCompra1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.dataSetEstruturaCompra
        Me.DatasetSelecaoValorDisponivelFornecedor1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
        Me.DatasetTransferenciaVerbaFornecedor1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor
        CType(Me.DatasetCelula1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetEstruturaCompra1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetSelecaoValorDisponivelFornecedor1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetTransferenciaVerbaFornecedor1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetCelula1
        '
        Me.DatasetCelula1.DataSetName = "DatasetCelula"
        Me.DatasetCelula1.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DataSetEstruturaCompra1
        '
        Me.DataSetEstruturaCompra1.DataSetName = "dataSetEstruturaCompra"
        Me.DataSetEstruturaCompra1.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DatasetSelecaoValorDisponivelFornecedor1
        '
        Me.DatasetSelecaoValorDisponivelFornecedor1.DataSetName = "DatasetSelecaoValorDisponivelFornecedor"
        Me.DatasetSelecaoValorDisponivelFornecedor1.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DatasetTransferenciaVerbaFornecedor1
        '
        Me.DatasetTransferenciaVerbaFornecedor1.DataSetName = "DatasetTransferenciaVerbaFornecedor"
        Me.DatasetTransferenciaVerbaFornecedor1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetCelula1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetEstruturaCompra1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetSelecaoValorDisponivelFornecedor1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetTransferenciaVerbaFornecedor1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblFiltroOrigem As System.Web.UI.WebControls.Label
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetCelula1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetCelula
    Protected WithEvents DataSetEstruturaCompra1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.dataSetEstruturaCompra
    Protected WithEvents btnLimparOrigem As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnSair As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetSelecaoValorDisponivelFornecedor1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
    Protected WithEvents DatasetTransferenciaVerbaFornecedor1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor
    Protected WithEvents txtValor As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents lblMensagemDesatualizado As System.Web.UI.WebControls.Label
    Protected WithEvents cmdCalcularValores As System.Web.UI.WebControls.Button
    Protected WithEvents lblAlcVbaFrn As System.Web.UI.WebControls.Label
    Protected WithEvents cmbTIPDSNDSCBNFORITRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtTIPDSNDSCBNFORITRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents cmbComprador As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmbCategoria As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ValorTransferir As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents cmbOpcaoFiltro As System.Web.UI.WebControls.DropDownList
    Protected WithEvents grdOrigem As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents lkbNenhum As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lkbTodas As System.Web.UI.WebControls.LinkButton
    Protected WithEvents WucFornecedor1 As wucFornecedor
    Protected WithEvents txtPERPSQSLDFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents TRBuscaSaldoFornecedor As System.Web.UI.HtmlControls.HtmlTableRow

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

#End Region

#Region "Eventos"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Not IsPostBack) Then
                Me.IniciarPagina()
            Else
                Me.RecuperaEstado()
            End If
            carregarJavaScript()
            SetNaoGravarCache()
            AtualizarValorTotal()

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
            Exit Sub
        End If
        Me.SalvaEstado()
    End Sub

    Private Sub txtPERPSQSLDFRN_ValueChange(ByVal sender As Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtPERPSQSLDFRN.ValueChange
        Try
            If txtPERPSQSLDFRN.ValueDecimal < 0 Or txtPERPSQSLDFRN.ValueDecimal > 100 Then
                Util.AdicionaJsAlert(Me.Page, "Valor não pode ser maior que 100 nem menor que 0!", True)
                Exit Sub
            End If
            Me.AtualizarValorATransferir()
            Me.AtualizarValorTotal()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Try
            If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
                Exit Sub
            End If
            If Me.Pesquisar() Then
                Me.atualizarGrid()
                Me.atualizarGridComDadosDoDataset()
                Me.AtualizarValorATransferir()
                Me.AtualizarValorTotal()
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnLimparOrigem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimparOrigem.Click
        Try
            If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
                Exit Sub
            End If
            Me.LimparOrigem()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
                Exit Sub
            End If
            SelecionarLinhasComValorATransferirInformado()
            If Validar() Then
                If AtualizarDatasetComDadosDoGrid() Then
                    Controller.AtualizarTransferenciaVerbaFornecedor(Me.DatasetTransferenciaVerbaFornecedor1)
                    Me.DatasetTransferenciaVerbaFornecedor1 = Controller.ObterTransferenciaVerbaFornecedor(WSCAcoesComerciais.numFluApv)
                    WSCAcoesComerciais.PERPSQSLDFRN = txtPERPSQSLDFRN.ValueDecimal
                    'Util.FecharPagina(Me.Page)
                End If
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmbOpcaoFiltro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOpcaoFiltro.SelectedIndexChanged
        Try
            If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
                Exit Sub
            End If
            AplicaLabelFiltro(CType(cmbOpcaoFiltro.SelectedValue, String))
            Util.AdicionaJsFocus(Me.Page, cmbOpcaoFiltro)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub lkbTodas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkbTodas.Click
        Try
            If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
                Exit Sub
            End If
            Me.MarcarTodas()
            Me.AtualizarValorTotal()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub lkbNenhum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkbNenhum.Click
        Try
            If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
                Exit Sub
            End If
            Me.DesmarcarTodas()
            Me.AtualizarValorTotal()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub WucFornecedor1_FornecedorAlterado(ByVal e As System.Web.UI.WebControls.ListItem)
        Try
            If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
                Exit Sub
            End If
            WucFornecedor1.setFocus()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub grdOrigem_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.UltraWebGrid.LayoutEventArgs)
        Try
            If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
                Exit Sub
            End If
            'e.Layout.UseFixedHeaders = True
            e.Layout.Bands(0).Columns(1).Header.Fixed = True
            e.Layout.Bands(0).Columns(2).Header.Fixed = True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Try
            If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
                'Controller.TrataSecaoExpirada()
                Exit Sub
            End If
            Util.FecharPagina(Me.Page)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ValorTransferir_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs)
        Try
            Dim linhaSelecionadaGrid As Infragistics.WebUI.UltraWebGrid.UltraGridRow
            linhaSelecionadaGrid = Me.grdOrigem.DisplayLayout.ActiveRow
            If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
                Exit Sub
            End If
            If Not linhaSelecionadaGrid Is Nothing Then
                ValidarLinhaDoGrid(linhaSelecionadaGrid)
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmbTIPDSNDSCBNFORITRN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTIPDSNDSCBNFORITRN.SelectedIndexChanged
        Try

            If Not Request.QueryString("TipoFluxo") Is Nothing Then
                Dim TipoFluxo As Decimal = CType(Request.QueryString("TipoFluxo").ToString, Decimal)
                If TipoFluxo = 0 Then
                    If Constants.EMPENHO_FORNECEDOR_MARKETING = CType(cmbTIPDSNDSCBNFORITRN.SelectedItem.Value, Decimal) Then
                        Util.AdicionaJsAlert(Me.Page, "Não é permitido a transferência do empenho marketing pelo processo de transferência compras!", True)
                        cmbTIPDSNDSCBNFORITRN.SelectedIndex = 0
                        txtTIPDSNDSCBNFORITRN.Text = ""
                        Exit Sub
                    End If
                End If
            Else
                If Constants.EMPENHO_FORNECEDOR_MARKETING = CType(cmbTIPDSNDSCBNFORITRN.SelectedItem.Value, Decimal) Then
                    Util.AdicionaJsAlert(Me.Page, "Não é permitido a transferência do empenho marketing pelo processo de transferência compras!", True)
                    cmbTIPDSNDSCBNFORITRN.SelectedIndex = 0
                    txtTIPDSNDSCBNFORITRN.Text = ""
                    Exit Sub
                End If
            End If

            If Constants.EMPENHO_FORNECEDOR_MARKETING = CType(cmbTIPDSNDSCBNFORITRN.SelectedItem.Value, Decimal) Then
                Util.AdicionaJsAlert(Me.Page, "Não é permitido a transferência do empenho marketing pelo processo de transferência compras!", True)
                cmbTIPDSNDSCBNFORITRN.SelectedIndex = 0
                txtTIPDSNDSCBNFORITRN.Text = ""
                Exit Sub
            End If

            If Not IsNumeric(cmbTIPDSNDSCBNFORITRN.SelectedValue) Then
                txtTIPDSNDSCBNFORITRN.Text = ""
                Exit Sub
            End If
            If txtTIPDSNDSCBNFORITRN.Text <> cmbTIPDSNDSCBNFORITRN.SelectedValue Then
                txtTIPDSNDSCBNFORITRN.Text = cmbTIPDSNDSCBNFORITRN.SelectedValue
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub txtTIPDSNDSCBNFORITRN_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtTIPDSNDSCBNFORITRN.ValueChange
        Try
            If cmbTIPDSNDSCBNFORITRN.SelectedValue <> txtTIPDSNDSCBNFORITRN.Text Then
                If Not cmbTIPDSNDSCBNFORITRN.Items.FindByValue(txtTIPDSNDSCBNFORITRN.Text) Is Nothing Then
                    cmbTIPDSNDSCBNFORITRN.SelectedValue = txtTIPDSNDSCBNFORITRN.Text
                Else
                    Util.AdicionaJsAlert(Me.Page, "Opção não disponível", True)
                    txtTIPDSNDSCBNFORITRN.Text = cmbTIPDSNDSCBNFORITRN.SelectedValue
                End If
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#Region "Metodos de Carga"

    Private Sub AplicaLabelFiltro(ByVal TipoFiltro As String)
        Try
            Select Case TipoFiltro
                Case "Categoria"
                    Me.lblFiltroOrigem.Text = "Categoria:"
                    Me.cmbCategoria.Visible = True
                    Me.cmbComprador.Visible = False
                    Me.WucFornecedor1.Visible = False
                Case "Comprador"
                    Me.lblFiltroOrigem.Text = "Comprador:"
                    Me.cmbCategoria.Visible = False
                    Me.cmbComprador.Visible = True
                    Me.WucFornecedor1.Visible = False
                Case "Fornecedor"
                    Me.lblFiltroOrigem.Text = "Fornecedor:"
                    Me.cmbCategoria.Visible = False
                    Me.cmbComprador.Visible = False
                    Me.WucFornecedor1.Visible = True
            End Select
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub IniciarPagina()
        Try
            CarregarCmbCategoria()
            CarregarCmbComprador()
            FormataCabecalhoGrid()
            Me.DatasetTransferenciaVerbaFornecedor1 = WSCAcoesComerciais.dsTransferenciaVerbaFornecedor
            CarregarEmpenhosDeOrigem()
            AtualizaTela()
            Util.AdicionaJsFocus(Me.Page, cmbOpcaoFiltro)
            txtPERPSQSLDFRN.ValueDecimal = 100
            If Not Request.QueryString("TipoFluxo") Is Nothing Then
                Dim TipoFluxo As Decimal = CType(Request.QueryString("TipoFluxo").ToString, Decimal)
                'Marketing
                If TipoFluxo = 1 Then
                    TRBuscaSaldoFornecedor.Visible = True

                    txtTIPDSNDSCBNFORITRN.ValueDecimal = Constants.EMPENHO_FORNECEDOR_MARKETING
                    txtTIPDSNDSCBNFORITRN_ValueChange(Nothing, Nothing)
                    txtTIPDSNDSCBNFORITRN.Enabled = False
                    cmbTIPDSNDSCBNFORITRN.Enabled = False
                    'Desoneracao AGF
                ElseIf TipoFluxo = 2 Then
                    TRBuscaSaldoFornecedor.Visible = True
                    txtTIPDSNDSCBNFORITRN.ValueDecimal = Constants.EMPENHO_DESONERACAO_AGF
                    txtTIPDSNDSCBNFORITRN_ValueChange(Nothing, Nothing)
                    txtTIPDSNDSCBNFORITRN.Enabled = False
                    cmbTIPDSNDSCBNFORITRN.Enabled = False
                    'Resultado AGF
                ElseIf TipoFluxo = 3 Then
                    TRBuscaSaldoFornecedor.Visible = True
                    txtTIPDSNDSCBNFORITRN.ValueDecimal = Constants.EMPENHO_RESULTADO_AGF
                    txtTIPDSNDSCBNFORITRN_ValueChange(Nothing, Nothing)
                    txtTIPDSNDSCBNFORITRN.Enabled = False
                    cmbTIPDSNDSCBNFORITRN.Enabled = False
                Else
                    TRBuscaSaldoFornecedor.Visible = False
                End If
            End If
            If Me.grdOrigem.Rows.Count > 0 Then
                txtPERPSQSLDFRN.ValueDecimal = WSCAcoesComerciais.PERPSQSLDFRN
            Else
                WSCAcoesComerciais.PERPSQSLDFRN = 0
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub carregarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        btnPesquisar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        Page.RegisterStartupScript("Valor", "<script>window.MM_findObj('TbValorAtualizado').style.display = 'none';</script>")
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR")
    End Sub

    Private Sub CarregarCmbCategoria()
        Try
            Me.DatasetCelula1 = Controller.ObterCelulas(0, 0, 0, "")
            Util.carregarCmbCelula(Me.DatasetCelula1, Me.cmbCategoria, Nothing)
            'Util.carregarCmbCelula(Me.DatasetCelula1, Me.cmbComprador, New ListItem("Resultado", "0"))
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub CarregarCmbComprador()
        Try
            Me.DataSetEstruturaCompra1 = Controller.ObterCompradores(0, Nothing, Nothing, Nothing, 1, "", "")
            Util.carregarCmbComprador(Me.DataSetEstruturaCompra1, Me.cmbComprador, Nothing)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
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
            ch = .DisplayLayout.Bands(0).Columns.FromKey("NomeCategoria").Header
            ch.RowLayoutColumnInfo.SpanY = 2
            ch.RowLayoutColumnInfo.OriginY = 0
            ch.Style.VerticalAlign = VerticalAlign.Top

            'Expande a coluna para 2 linhas
            ch = .DisplayLayout.Bands(0).Columns.FromKey("NomeComprador").Header
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
            ch = .DisplayLayout.Bands(0).Columns.FromKey("NomeAlocacao").Header
            ch.RowLayoutColumnInfo.SpanY = 2
            ch.RowLayoutColumnInfo.OriginY = 0
            ch.Style.VerticalAlign = VerticalAlign.Top

            'Cria a coluna de agrupamento VALOR
            ch = New Infragistics.WebUI.UltraWebGrid.ColumnHeader(True)
            ch.Caption = "VALOR"
            ch.RowLayoutColumnInfo.OriginY = 0
            ch.RowLayoutColumnInfo.OriginX = 8
            ch.RowLayoutColumnInfo.SpanX = 4
            ch.Style.HorizontalAlign = HorizontalAlign.Center
            ch.Style.Height = New System.Web.UI.WebControls.Unit(21, UnitType.Pixel)
            .DisplayLayout.Bands(0).HeaderLayout.Add(ch)

        End With
    End Sub

    Private Sub SetNaoGravarCache()
        Try
            Response.Cache.SetNoServerCaching()
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache)
            Response.Cache.SetNoStore()
            Response.Cache.SetExpires(New DateTime(1900, 1, 1, 0, 0, 0, 0))
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub CarregarEmpenhosDeOrigem()
        If Me.DatasetTransferenciaVerbaFornecedor1.CADTRNVBAFRN.Rows.Count = 0 Then
            Util.AdicionaJsAlert(Me.Page, "Não foi possivel carregar os empenhos de origem")
        End If

        Dim CADTRNVBAFRNRow As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow
        CADTRNVBAFRNRow = Me.DatasetTransferenciaVerbaFornecedor1.CADTRNVBAFRN(0)

        Dim dsEmpenho As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetEmpenho
        dsEmpenho = Controller.ObterEmpenhos(String.Empty, String.Empty, String.Empty, 0, String.Empty)

        If CADTRNVBAFRNRow.TIPDSNDSCBNFDSNTRN = 1 Or CADTRNVBAFRNRow.TIPDSNDSCBNFDSNTRN = 97 Or CADTRNVBAFRNRow.TIPDSNDSCBNFDSNTRN = 47 Then 'Apropriar para custo
            CarregarEmpenhosDeOrigemQuandoEmpenhoDestinoForApropriarParaCusto(dsEmpenho)
        Else
            CarregarEmpenhosDeOrigemQuandoEmpenhoDestinoNaoForApropriarParaCusto(dsEmpenho)
        End If
    End Sub

    Private Sub CarregarEmpenhosDeOrigemQuandoEmpenhoDestinoForApropriarParaCusto(ByVal dsEmpenho As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetEmpenho)
        For Each T0109059Row As wsAcoesComerciais.DatasetEmpenho.T0109059Row In dsEmpenho.T0109059.Select(String.Empty, "TIPDSNDSCBNF")
            If T0109059Row.FLGCTBDSNDSC.ToUpper = "S" Then
                cmbTIPDSNDSCBNFORITRN.Items.Add(New ListItem(T0109059Row.TIPDSNDSCBNF.ToString("0000") & " - " & T0109059Row.DESDSNDSCBNF, T0109059Row.TIPDSNDSCBNF.ToString()))
            End If
        Next

        'Adiciona todos empenhos no inicio
        cmbTIPDSNDSCBNFORITRN.Items.Insert(0, (New ListItem("Todos Empenhos", "0")))

        If IsNumeric(cmbTIPDSNDSCBNFORITRN.SelectedValue) Then
            txtTIPDSNDSCBNFORITRN.Text = cmbTIPDSNDSCBNFORITRN.SelectedValue
        End If
    End Sub

    Private Sub CarregarEmpenhosDeOrigemQuandoEmpenhoDestinoNaoForApropriarParaCusto(ByVal dsEmpenho As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetEmpenho)
        Dim INDTIPDSNRCTCSTMER As Decimal
        For Each T0109059Row As wsAcoesComerciais.DatasetEmpenho.T0109059Row In dsEmpenho.T0109059.Select(String.Empty, "TIPDSNDSCBNF")

            INDTIPDSNRCTCSTMER = 0
            If Not T0109059Row.IsINDTIPDSNRCTCSTMERNull Then
                INDTIPDSNRCTCSTMER = T0109059Row.INDTIPDSNRCTCSTMER
            End If

            If T0109059Row.FLGCTBDSNDSC.ToUpper = "S" And T0109059Row.IsTIPALCVBAFRNNull And INDTIPDSNRCTCSTMER <> 1 Then
                cmbTIPDSNDSCBNFORITRN.Items.Add(New ListItem(T0109059Row.TIPDSNDSCBNF.ToString("0000") & " - " & T0109059Row.DESDSNDSCBNF, T0109059Row.TIPDSNDSCBNF.ToString()))
            End If
        Next

        'Adiciona todos empenhos no inicio
        cmbTIPDSNDSCBNFORITRN.Items.Insert(0, (New ListItem("Todos Empenhos", "0")))

        If IsNumeric(cmbTIPDSNDSCBNFORITRN.SelectedValue) Then
            txtTIPDSNDSCBNFORITRN.Text = cmbTIPDSNDSCBNFORITRN.SelectedValue
        End If
    End Sub

#End Region

#Region "Metodos de controle"

    Private Sub RecuperaEstado()
        If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
            Exit Sub
        End If
        Me.DatasetSelecaoValorDisponivelFornecedor1 = WSCAcoesComerciais.dsSelecaoValorDisponivelFornecedor
        Me.DatasetTransferenciaVerbaFornecedor1 = WSCAcoesComerciais.dsTransferenciaVerbaFornecedor
    End Sub

    Private Sub SalvaEstado()
        WSCAcoesComerciais.dsSelecaoValorDisponivelFornecedor = Me.DatasetSelecaoValorDisponivelFornecedor1
        WSCAcoesComerciais.dsTransferenciaVerbaFornecedor = Me.DatasetTransferenciaVerbaFornecedor1
    End Sub

    Private Sub AtualizaTela()

    End Sub

    Private Sub MarcarTodas()
        For Each row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdOrigem.Rows
            If CType(row.Cells.Item(0).Value, Boolean) = False Then
                row.Cells.Item(11).Value = row.Cells.Item(10).Value
            End If
            row.Cells.Item(0).Value = True
        Next
    End Sub

    Private Sub DesmarcarTodas()
        For Each row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdOrigem.Rows
            row.Cells.Item(0).Value = False
            row.Cells.Item(11).Value = 0
        Next
    End Sub

    Private Sub LimparOrigem()
        Me.grdOrigem.Rows.Clear()
        Me.DatasetSelecaoValorDisponivelFornecedor1 = New wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
        Me.WucFornecedor1.SelecionarVazio()
    End Sub

    Private Sub atualizarGrid()
        Try
            If Not Request.QueryString("TipoFluxo") Is Nothing Then
                Dim TipoFluxo As Decimal = CType(Request.QueryString("TipoFluxo").ToString, Decimal)
                If TipoFluxo = 0 Then
                    Me.DatasetSelecaoValorDisponivelFornecedor1 = excluiEmpenhoMarketing(Me.DatasetSelecaoValorDisponivelFornecedor1)
                End If
            End If

            If Me.DatasetSelecaoValorDisponivelFornecedor1.tbTransfenciaEmpenhosDoFornecedor.Rows.Count > 0 Then
                Me.DatasetSelecaoValorDisponivelFornecedor1.tbTransfenciaEmpenhosDoFornecedor.DefaultView(0).DataView.Sort = "NomeFornecedor, CodigoEmpenho"
            End If
            With Me.grdOrigem
                .DataSource = Me.DatasetSelecaoValorDisponivelFornecedor1
                .DataBind()
            End With

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function excluiEmpenhoMarketing(ByVal dsDatasetSelecaoValorDisponivelFornecedor As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor) As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
        Dim arrayCodigosFornecedor As New ArrayList
        Dim arrayCodigosEmpenho As New ArrayList
        Dim arrayCodigosAlocacao As New ArrayList
        Dim indiceArrays As Integer = 0
       
        For ix As Integer = 0 To dsDatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedor.Rows.Count - 1
            If (dsDatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedor(ix).CodigoEmpenho = Constants.EMPENHO_FORNECEDOR_MARKETING) Or _
                (dsDatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedor(ix).CodigoEmpenho = Constants.EMPENHO_DESONERACAO_AGF) Or _
                (dsDatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedor(ix).CodigoEmpenho = Constants.EMPENHO_RESULTADO_AGF) Then

                arrayCodigosFornecedor.Add(dsDatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedor(ix).CodigoFornecedor)
                arrayCodigosEmpenho.Add(dsDatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedor(ix).CodigoEmpenho)
                arrayCodigosAlocacao.Add(dsDatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedor(ix).CodigoAlocacao)
                indiceArrays += 1
            End If
        Next

        For ix As Integer = 0 To arrayCodigosEmpenho.Count - 1
            dsDatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedor.FindByCodigoFornecedorCodigoEmpenhoCodigoAlocacao(CType(arrayCodigosFornecedor.Item(ix), Decimal), CType(arrayCodigosEmpenho.Item(ix), Decimal), CType(arrayCodigosAlocacao.Item(ix), Decimal)).Delete()
        Next
        Return dsDatasetSelecaoValorDisponivelFornecedor
    End Function

    Private Function SelecionarLinhasComValorATransferirInformado() As Boolean
        For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdOrigem.Rows
            If CType(linha.Cells(11).Value, Decimal) > 0 Then
                linha.Cells(0).Value = True
            Else
                linha.Cells(0).Value = False
            End If
        Next
    End Function

    Private Sub AtualizarValorTotal()
        Dim Valor As Decimal = 0
        Dim SomaDeValor As Decimal = 0

        For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdOrigem.Rows
            If IsNumeric(linha.GetCellValue(Me.grdOrigem.Columns.FromKey("ValorTransferir"))) Then
                Valor = CType(linha.GetCellValue(Me.grdOrigem.Columns.FromKey("ValorTransferir")), Decimal)
                SomaDeValor += Valor
            End If
        Next

        txtValor.ValueDecimal = SomaDeValor
    End Sub

#End Region

#Region "Metodos de Regra"

    Private Function Validar() As Boolean
        Try
            Dim result As Boolean = True
            For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdOrigem.Rows
                If Not ValidarLinhaDoGrid(linha) Then
                    result = False
                End If
            Next
            Return result
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Function ValidarLinhaDoGrid(ByVal linhaGrid As Infragistics.WebUI.UltraWebGrid.UltraGridRow) As Boolean
        Try
            If Not linhaGrid Is Nothing Then

                'Validações
                If CType(linhaGrid.GetCellValue(grdOrigem.Columns.FromKey("ValorTransferir")), Decimal) < 0 Then
                    Dim NomeFornecedor As String = CType(linhaGrid.GetCellValue(grdOrigem.Columns.FromKey("NomeFornecedor")), String)
                    Dim NomeAlocacao As String = CType(linhaGrid.GetCellValue(grdOrigem.Columns.FromKey("NomeAlocacao")), String)
                    Dim NomeEmpenho As String = CType(linhaGrid.GetCellValue(grdOrigem.Columns.FromKey("NomeEmpenho")), String)
                    Util.AdicionaJsAlert(Me.Page, "Não é permitido valor negativo. Fornecedor:" & NomeFornecedor.Trim & ", Alocação:" & NomeAlocacao.Trim & ", Empenho:" & NomeEmpenho.Trim, True)
                    linhaGrid.Activate()
                    Return False
                End If

                'Trata um erro que acontece quando você clica na primeira coluna para selecionar a linha
                'nesse caso, não sei porque, o valor vem cem vezes maior
                Dim ValorTransferir As Decimal
                ValorTransferir = CType(linhaGrid.GetCellValue(grdOrigem.Columns.FromKey("ValorTransferir")), Decimal)
                If (ValorTransferir / 100) = CType(linhaGrid.GetCellValue(grdOrigem.Columns.FromKey("SaldoDisponivel")), Decimal) Then
                    ValorTransferir = ValorTransferir / 100
                    linhaGrid.Cells(11).Value = ValorTransferir
                End If

                If ValorTransferir > 0 And ValorTransferir > CType(linhaGrid.GetCellValue(grdOrigem.Columns.FromKey("SaldoDisponivel")), Decimal) Then
                    Dim NomeFornecedor As String = CType(linhaGrid.GetCellValue(grdOrigem.Columns.FromKey("NomeFornecedor")), String)
                    Dim NomeAlocacao As String = CType(linhaGrid.GetCellValue(grdOrigem.Columns.FromKey("NomeAlocacao")), String)
                    Dim NomeEmpenho As String = CType(linhaGrid.GetCellValue(grdOrigem.Columns.FromKey("NomeEmpenho")), String)
                    Util.AdicionaJsAlert(Me.Page, "Não é permitido transferir valor maior que o disponível. Fornecedor:" & NomeFornecedor.Trim & ", Alocação:" & NomeAlocacao.Trim & ", Empenho:" & NomeEmpenho.Trim, True)
                    linhaGrid.Activate()
                    Return False
                End If

            End If
            Return True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Function ValidarFiltrosPesquisa() As Boolean
        'Validação
        If Not IsNumeric(cmbTIPDSNDSCBNFORITRN.SelectedValue) Then
            Util.AdicionaJsAlert(Me.Page, "Empenho inválido", True)
            Return False
            'ElseIf CType(cmbTIPDSNDSCBNFORITRN.SelectedValue, Decimal) = 0 Then
            '    Util.AdicionaJsAlert(Me.Page, "Empenho inválido", True)
            '    Return False
        End If

        If cmbOpcaoFiltro.SelectedValue = "Fornecedor" Then
            If WucFornecedor1.CodFornecedor = 0 Then
                Util.AdicionaJsAlert(Me.Page, "Fornecedor inválido", True)
                Return False
            End If
        End If

        Return True
    End Function

    Private Function ObterRelacaoDeEmpenhosAConsultarSaldo() As String
        Dim result As String = String.Empty
        If Me.cmbTIPDSNDSCBNFORITRN.SelectedValue = "0" Then 'Todos Empenhos da lista
            For i As Integer = 0 To cmbTIPDSNDSCBNFORITRN.Items.Count - 1
                If cmbTIPDSNDSCBNFORITRN.Items(i).Value <> "0" Then
                    If result <> String.Empty Then
                        result &= ", "
                    End If
                    result &= cmbTIPDSNDSCBNFORITRN.Items(i).Value
                End If
            Next
        Else
            result = Me.cmbTIPDSNDSCBNFORITRN.SelectedValue
        End If
        Return result
    End Function

    Public Sub AtualizarValorATransferir()
        If Not Request.QueryString("TipoFluxo") Is Nothing Then
            Dim TipoFluxo As Decimal = CType(Request.QueryString("TipoFluxo").ToString, Decimal)

            If TipoFluxo <> 0 Then
                For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdOrigem.Rows
                    If txtPERPSQSLDFRN.ValueDecimal <> 0 Then
                        linha.Cells.Item(11).Value = CType(linha.Cells.Item(10).Value, Decimal) * (txtPERPSQSLDFRN.ValueDecimal / 100)
                        'txtValor.ValueDecimal = CType(linha.Cells.Item(11).Value, Decimal)
                    End If
                Next
            End If
        End If
    End Sub
#End Region

#Region "Metodos de Persistencia"

    Private Function Pesquisar() As Boolean
        'Valida o filtro
        If Not ValidarFiltrosPesquisa() Then
            Return False
        End If
        'Obtem os dados
        Dim dsSelecaoValorDisponivelFornecedor As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
        Select Case cmbOpcaoFiltro.SelectedValue
            Case "Categoria"
                dsSelecaoValorDisponivelFornecedor = PesquisarSaldoPorCategoria()
            Case "Comprador"
                dsSelecaoValorDisponivelFornecedor = PesquisarSaldoPorComprador()
            Case "Fornecedor"
                dsSelecaoValorDisponivelFornecedor = PesquisarSaldoPorFornecedor()
        End Select
        'Inclui os dados no dataset da pagina
        Return IncluirLinhaNoDatasetDaPagina(dsSelecaoValorDisponivelFornecedor)
    End Function

    Private Function IncluirLinhaNoDatasetDaPagina(ByVal dsSelecaoValorDisponivelFornecedor As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor) As Boolean
        For Each novaLinha As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedorRow In dsSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedor
            If novaLinha.SaldoDisponivel > 0 Then
                Dim mesmaLinha As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedorRow
                mesmaLinha = Me.DatasetSelecaoValorDisponivelFornecedor1.tbTransfenciaEmpenhosDoFornecedor.FindByCodigoFornecedorCodigoEmpenhoCodigoAlocacao(novaLinha.CodigoFornecedor, novaLinha.CodigoEmpenho, novaLinha.CodigoAlocacao)
                If Not mesmaLinha Is Nothing Then
                    Me.DatasetSelecaoValorDisponivelFornecedor1.tbTransfenciaEmpenhosDoFornecedor.Rows.Remove(mesmaLinha)
                End If
                Me.DatasetSelecaoValorDisponivelFornecedor1.tbTransfenciaEmpenhosDoFornecedor.Rows.Add(novaLinha.ItemArray)
            End If
        Next
        Return True
    End Function

    Private Function PesquisarSaldoPorCategoria() As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
        Try
            Dim DatRef As Date
            Dim CodDivCmp As Decimal
            Dim TipDsnDscBnfOriTrn As Decimal

            'Atribui valor as variaveis
            DatRef = Date.Today
            CodDivCmp = CType(Me.cmbCategoria.SelectedValue, Decimal)
            TipDsnDscBnfOriTrn = CType(Me.cmbTIPDSNDSCBNFORITRN.SelectedValue, Decimal)

            'Consulta os dados
            Dim dsSelecaoValorDisponivelFornecedor As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
            dsSelecaoValorDisponivelFornecedor = Controller.ObterSaldoDisponivelFornecedorPorCategoria(DatRef, CodDivCmp)

            'Exclui as linhas dos empenhos que não estão no combo, esses saldos não poderão ser mostrados
            For i As Integer = dsSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedor.Rows.Count - 1 To 0 Step -1
                Dim linha As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedorRow
                linha = dsSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedor(i)
                If TipDsnDscBnfOriTrn = 0 Then
                    If cmbTIPDSNDSCBNFORITRN.Items.FindByValue(linha.CodigoEmpenho.ToString) Is Nothing Then
                        linha.Delete()
                    End If
                Else
                    If TipDsnDscBnfOriTrn <> linha.CodigoEmpenho Then
                        linha.Delete()
                    End If
                End If
            Next
            dsSelecaoValorDisponivelFornecedor.AcceptChanges()

            Return dsSelecaoValorDisponivelFornecedor
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Function PesquisarSaldoPorComprador() As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
        Try
            Dim DatRef As Date
            Dim CodCpr As Decimal
            Dim TipDsnDscBnfOriTrn As Decimal

            'Atribui valor as variaveis
            DatRef = Date.Today
            CodCpr = CType(Me.cmbComprador.SelectedValue, Decimal)
            TipDsnDscBnfOriTrn = CType(Me.cmbTIPDSNDSCBNFORITRN.SelectedValue, Decimal)

            Dim dsSelecaoValorDisponivelFornecedor As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
            dsSelecaoValorDisponivelFornecedor = Controller.ObterSaldoDisponivelFornecedorPorComprador(DatRef, CodCpr)

            'Exclui as linhas dos empenhos que não estão no combo, esses saldos não poderão ser mostrados
            For i As Integer = dsSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedor.Rows.Count - 1 To 0 Step -1
                Dim linha As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedorRow
                linha = dsSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedor(i)

                If TipDsnDscBnfOriTrn = 0 Then
                    If cmbTIPDSNDSCBNFORITRN.Items.FindByValue(linha.CodigoEmpenho.ToString) Is Nothing Then
                        linha.Delete()
                    End If
                Else
                    If TipDsnDscBnfOriTrn <> linha.CodigoEmpenho Then
                        linha.Delete()
                    End If
                End If
            Next
            dsSelecaoValorDisponivelFornecedor.AcceptChanges()

            Return dsSelecaoValorDisponivelFornecedor
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Function PesquisarSaldoPorFornecedor() As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
        Try
            Dim DatRef As Date
            Dim CodFrn As Decimal
            Dim TipDsnDscBnf As String

            'Atribui valor as variaveis
            DatRef = Date.Today
            CodFrn = Me.WucFornecedor1.CodFornecedor
            TipDsnDscBnf = Me.ObterRelacaoDeEmpenhosAConsultarSaldo

            'Faz merge porque a idéia e sempre adicionar linhas, isso permite ao usuário
            'ir alterando o filtro, fazendo nova pesquisa e acrescentando linhas ao grid
            Dim dsSelecaoValorDisponivelFornecedor As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
            dsSelecaoValorDisponivelFornecedor = Controller.ObterSaldoDisponivelFornecedor(DatRef, CodFrn, TipDsnDscBnf)

            Return dsSelecaoValorDisponivelFornecedor
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Function AtualizarDatasetComDadosDoGrid() As Boolean
        Try
            Dim NUMFLUAPV As Decimal
            NUMFLUAPV = CType(Request.QueryString("NUMFLUAPV"), Decimal)

            'Verifica se existe registro na tabela de cadastro
            If Me.DatasetTransferenciaVerbaFornecedor1.CADTRNVBAFRN.Rows.Count = 0 Then
                Util.AdicionaJsAlert(Me.Page, "Não existe registro na tabela de cadastro da relação, tente novamente se o problema persistir informe ao analista responsável")
                Return False
            End If

            'Obtema linha da tabela de cadastro
            Dim CADTRNVBAFRNRow As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow
            CADTRNVBAFRNRow = Me.DatasetTransferenciaVerbaFornecedor1.CADTRNVBAFRN(0)

            'Se o linha ainda não foi salva, reconsulta o número do fluxo, isso por precaução
            'de ocorrer uma situação onde 2 usuário iniciam uma tranferencia verba ao mesmo
            'tempo e pegam o mesmo número de fluxo
            If CADTRNVBAFRNRow.RowState = DataRowState.Added Then
                CADTRNVBAFRNRow.NUMFLUAPV = NUMFLUAPV     'Controller.ObterNovaChaveTransferenciaVerba
            End If

            'Atualiza o dataset
            For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdOrigem.Rows
                Select Case CType(linha.Cells(0).Value, Boolean)
                    Case True 'A linha do grid foi selecionada
                        If Not AtualizarDataset(CADTRNVBAFRNRow, linha) Then
                            Return False
                        End If
                    Case False 'A linha do grid não foi selecionada
                        If Not ExcluirLinhaDoDataset(CADTRNVBAFRNRow, linha) Then
                            Return False
                        End If
                End Select
            Next

            Return True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
            Return False
        End Try
    End Function

    Private Function atualizarGridComDadosDoDataset() As Boolean
        Try
            'Verifica se existe registro na tabela de cadastro
            If Me.DatasetTransferenciaVerbaFornecedor1.CADTRNVBAFRN.Rows.Count = 0 Then
                Return True
            End If

            Dim RLCTRNVBAFRNRow As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRNRow
            Dim NUMFLUAPV As Decimal
            Dim CODFRN As Decimal
            Dim TIPDSNDSCBNFORITRN As Decimal
            Dim TIPALCVBAFRN As Decimal

            'Atualiza as linha do Grid
            For Each linhaGrid As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdOrigem.Rows

                'Transfere os valores da linha selecionada para as variaveis locais
                NUMFLUAPV = CType(Request.QueryString("NUMFLUAPV"), Decimal)
                CODFRN = CType(linhaGrid.GetCellValue(Me.grdOrigem.Columns.FromKey("CodigoFornecedor")), Decimal)
                TIPDSNDSCBNFORITRN = CType(linhaGrid.GetCellValue(Me.grdOrigem.Columns.FromKey("CodigoEmpenho")), Decimal)
                TIPALCVBAFRN = CType(linhaGrid.GetCellValue(Me.grdOrigem.Columns.FromKey("CodigoAlocacao")), Decimal)

                'Localiza a linha no dataset
                RLCTRNVBAFRNRow = Me.DatasetTransferenciaVerbaFornecedor1.RLCTRNVBAFRN.FindByNUMFLUAPVCODFRNTIPDSNDSCBNFORITRNTIPALCVBAFRN(NUMFLUAPV, CODFRN, TIPDSNDSCBNFORITRN, TIPALCVBAFRN)

                If RLCTRNVBAFRNRow Is Nothing Then
                    linhaGrid.Cells(0).Value = False
                Else
                    linhaGrid.Cells(0).Value = True
                    linhaGrid.Cells(11).Value = RLCTRNVBAFRNRow.VLRLMTCTB

                End If
            Next

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
            Return False
        End Try
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

            'Transfere os valores da linha selecionada para as variaveis locais
            NUMFLUAPV = CADTRNVBAFRNRow.NUMFLUAPV
            CODFRN = CType(linhaGrid.GetCellValue(Me.grdOrigem.Columns.FromKey("CodigoFornecedor")), Decimal)
            TIPDSNDSCBNFORITRN = CType(linhaGrid.GetCellValue(Me.grdOrigem.Columns.FromKey("CodigoEmpenho")), Decimal)
            TIPALCVBAFRN = CType(linhaGrid.GetCellValue(Me.grdOrigem.Columns.FromKey("CodigoAlocacao")), Decimal)
            VLRLMTCTB = CType(linhaGrid.GetCellValue(Me.grdOrigem.Columns.FromKey("ValorTransferir")), Decimal)

            'Caso a linha da capa CADTRNVBAFRN ainda não tenha sido gravada no banco de dados
            'reconsulta a chave, isso é necessário para resolver problema de concorrencia na
            'qual dois usuário podem ter aberto uma transferencia ao mesmo tempo e tenha obtido
            'o mesmo número de fluxo
            If CADTRNVBAFRNRow.RowState = DataRowState.Added Then
                CADTRNVBAFRNRow.NUMFLUAPV = CType(Request.QueryString("NUMFLUAPV"), Decimal) 'Controller.ObterNovaChaveTransferenciaVerba
                'WSCAcoesComerciais.numFluApv = CADTRNVBAFRNRow.NUMFLUAPV
            End If

            'Obtem a linha que será atualizada, ou cria uma nova caso ela não exista
            Dim RLCTRNVBAFRNRow As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor.RLCTRNVBAFRNRow
            RLCTRNVBAFRNRow = Me.DatasetTransferenciaVerbaFornecedor1.RLCTRNVBAFRN.FindByNUMFLUAPVCODFRNTIPDSNDSCBNFORITRNTIPALCVBAFRN(NUMFLUAPV, CODFRN, TIPDSNDSCBNFORITRN, TIPALCVBAFRN)
            If RLCTRNVBAFRNRow Is Nothing Then
                RLCTRNVBAFRNRow = Me.DatasetTransferenciaVerbaFornecedor1.RLCTRNVBAFRN.NewRLCTRNVBAFRNRow
            End If

            'Transfere valores das variaveis para a linha da tabela
            With RLCTRNVBAFRNRow
                .NUMFLUAPV = NUMFLUAPV
                .CODFRN = CODFRN
                .TIPDSNDSCBNFORITRN = TIPDSNDSCBNFORITRN
                .TIPALCVBAFRN = TIPALCVBAFRN
                .VLRLMTCTB = VLRLMTCTB
            End With

            'Insere a linha caso ela seja nova
            If RLCTRNVBAFRNRow.RowState = DataRowState.Detached Then
                Me.DatasetTransferenciaVerbaFornecedor1.RLCTRNVBAFRN.AddRLCTRNVBAFRNRow(RLCTRNVBAFRNRow)
            End If

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
            CODFRN = CType(linhaGrid.GetCellValue(Me.grdOrigem.Columns.FromKey("CodigoFornecedor")), Decimal)
            TIPDSNDSCBNFORITRN = CType(linhaGrid.GetCellValue(Me.grdOrigem.Columns.FromKey("CodigoEmpenho")), Decimal)
            TIPALCVBAFRN = CType(linhaGrid.GetCellValue(Me.grdOrigem.Columns.FromKey("CodigoAlocacao")), Decimal)

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

#End Region

   

End Class