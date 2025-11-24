Public Class TransferenciaGAC
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dsSelecaoValorDisponivelFornecedor = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
        Me.dsEmpenho = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetEmpenho
        CType(Me.dsSelecaoValorDisponivelFornecedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsEmpenho, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'dsSelecaoValorDisponivelFornecedor
        '
        Me.dsSelecaoValorDisponivelFornecedor.DataSetName = "DatasetSelecaoValorDisponivelFornecedor"
        Me.dsSelecaoValorDisponivelFornecedor.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'dsEmpenho
        '
        Me.dsEmpenho.DataSetName = "DatasetEmpenho"
        Me.dsEmpenho.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.dsSelecaoValorDisponivelFornecedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsEmpenho, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtData As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtValor As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtSaldoEmp As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtSaldoDisp As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtUsuario As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHistorico As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlEmpenhoOR As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtTotalAloc As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents ddlEmpenhoDS As System.Web.UI.WebControls.DropDownList
    Protected WithEvents grdAlocacoes As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents dsSelecaoValorDisponivelFornecedor As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
    Protected WithEvents ucFornecedorDS As wucFornecedor
    Protected WithEvents ucFornecedorOR As wucFornecedor
    Protected WithEvents dsEmpenho As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetEmpenho
    Protected WithEvents ddlDestino As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TD1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD2 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD3 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD4 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD5 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD6 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD7 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD8 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents txtEmpenho As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtEmpenhoDS As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents ddl1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddl2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddl3 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddl4 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TDTransferir As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region " Propriedades "

    Private Property VlrSldDspAlcVbaFrnPmt() As Decimal
        Get
            If Not Me.ViewState.Item("VlrSldDspAlcVbaFrnPmt") Is Nothing Then
                Return DirectCast(Me.ViewState.Item("VlrSldDspAlcVbaFrnPmt"), Decimal)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Decimal)
            Me.ViewState.Add("VlrSldDspAlcVbaFrnPmt", Value)
        End Set
    End Property

    Private Property VlrSldDspAlcVbaFrn() As Decimal
        Get
            If Not Me.ViewState.Item("VlrSldDspAlcVbaFrn") Is Nothing Then
                Return DirectCast(Me.ViewState.Item("VlrSldDspAlcVbaFrn"), Decimal)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Decimal)
            Me.ViewState("VlrSldDspAlcVbaFrn") = Value
        End Set
    End Property

    Private Property FlagAlocacao() As Boolean
        Get
            If Not Me.ViewState.Item("FlagAlocacao") Is Nothing Then
                Return DirectCast(Me.ViewState.Item("FlagAlocacao"), Boolean)
            Else
                Return False
            End If
        End Get
        Set(ByVal Value As Boolean)
            Me.ViewState("FlagAlocacao") = Value
        End Set
    End Property

    Private Property FlgExtUsr() As Boolean
        Get
            If Not Me.ViewState.Item("FlgExtUsr") Is Nothing Then
                Return DirectCast(Me.ViewState.Item("FlgExtUsr"), Boolean)
            Else
                Return False
            End If
        End Get
        Set(ByVal Value As Boolean)
            Me.ViewState("FlgExtUsr") = Value
        End Set
    End Property

    Private Property bEmpTransf() As Boolean
        Get
            If Not Me.ViewState.Item("bEmpTransf") Is Nothing Then
                Return DirectCast(Me.ViewState.Item("bEmpTransf"), Boolean)
            Else
                Return False
            End If
        End Get
        Set(ByVal Value As Boolean)
            Me.ViewState("bEmpTransf") = Value
        End Set
    End Property

    Private Property VlrSldDsp() As Decimal
        Get
            If Not Me.ViewState.Item("VlrSldDsp") Is Nothing Then
                Return DirectCast(Me.ViewState.Item("VlrSldDsp"), Decimal)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Decimal)
            Me.ViewState("VlrSldDsp") = Value
        End Set
    End Property

    Private ReadOnly Property TipAlcVbaFrnOrigem() As Decimal
        Get
            Dim result As Decimal = 0
            Dim linha As wsAcoesComerciais.DatasetEmpenho.T0109059Row

            Try
                linha = dsEmpenho.T0109059.FindByTIPDSNDSCBNF(Convert.ToDecimal(ddlEmpenhoOR.SelectedValue))
            Catch ex As Exception
            End Try

            If Not linha Is Nothing Then
                result = linha.TIPALCVBAFRN
            End If
            Return result
        End Get
    End Property

    Private ReadOnly Property linhaEmpenhoOrigem() As wsAcoesComerciais.DatasetEmpenho.T0109059Row
        Get
            Try
                Return dsEmpenho.T0109059.FindByTIPDSNDSCBNF(Convert.ToDecimal(ddlEmpenhoOR.SelectedValue))
            Catch ex As Exception
            End Try
        End Get
    End Property

    Private ReadOnly Property linhaEmpenhoDestino() As wsAcoesComerciais.DatasetEmpenho.T0109059Row
        Get
            Try
                Return dsEmpenho.T0109059.FindByTIPDSNDSCBNF(Convert.ToDecimal(ddlEmpenhoDS.SelectedValue))
            Catch ex As Exception
            End Try
        End Get
    End Property

    Private ReadOnly Property vCmbDsnDsnTipAlcVbaFrn() As Integer
        Get
            Dim result As Integer = 0
            If Not linhaEmpenhoDestino.IsTIPALCVBAFRNNull Then
                result = Convert.ToInt32(linhaEmpenhoDestino.TIPALCVBAFRN)
            End If
            Return result
        End Get
    End Property

    Private ReadOnly Property vCmbDsnDsnTipAlcVbaFrnOri() As Integer
        Get
            Dim result As Integer = 0
            If Not linhaEmpenhoOrigem.IsTIPALCVBAFRNNull Then
                result = Convert.ToInt32(linhaEmpenhoOrigem.TIPALCVBAFRN)
            End If
            Return result
        End Get
    End Property

    Private Property flagProcessando() As Boolean

        Get
            Dim result As Boolean = False
            If Not viewstate("flagProcessando") Is Nothing Then
                result = CType(viewstate("flagProcessando"), Boolean)
            End If
            Return result
        End Get

        Set(ByVal Value As Boolean)
            viewstate("flagProcessando") = Value
        End Set

    End Property

    Private Property flagProcessandoTransferencia() As Boolean

        Get
            Dim result As Boolean = False
            If Not viewstate("flagProcessandoTransferencia") Is Nothing Then
                result = CType(viewstate("flagProcessandoTransferencia"), Boolean)
            End If
            Return result
        End Get

        Set(ByVal Value As Boolean)
            viewstate("flagProcessandoTransferencia") = Value
        End Set

    End Property

#End Region

#Region " Eventos "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.InicializaPagina()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        'Pre condição
        If flagProcessando Then
            Exit Sub
        End If
        Try
            flagProcessando = True
            If Me.ValidarTransferenciaGAC() Then
                Me.TransferirValoreEntreEmpenhosFornecedorGAC()
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        Finally
            flagProcessando = False
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("Principal.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ddlEmpenhoOR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmpenhoOR.SelectedIndexChanged
        Try

            If ddlEmpenhoOR.SelectedIndex > 0 And ucFornecedorOR.CodFornecedor > 0 Then
                If Me.ValidaFornecedorSelecionado(ucFornecedorOR) Then
                    Me.CarregaGridAlocacoes()
                    Me.CarregaControlesValores()
                    Util.AdicionaJsFocus(Me.Page, CType(ddl4, System.web.UI.WebControls.WebControl))
                End If
            End If

            If txtEmpenho.Text <> ddlEmpenhoOR.SelectedValue.ToString Then
                txtEmpenho.Text = ddlEmpenhoOR.SelectedValue.ToString
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ucFornecedorOR_FornecedorAlterado(ByVal e As System.Web.UI.WebControls.ListItem)
        Try
            If ddlEmpenhoOR.SelectedIndex > 0 And ucFornecedorOR.CodFornecedor > 0 Then
                If Me.ValidaFornecedorSelecionado(ucFornecedorOR) Then
                    Me.CarregaGridAlocacoes()
                    Me.CarregaControlesValores()
                End If
            End If
            If Not CType(ucFornecedorOR.FindControl("txtNomeFornecedor"), Infragistics.WebUI.WebDataInput.WebTextEdit).Text Is String.Empty Then
                ucFornecedorDS.PesquisarFornecedor(CType(ucFornecedorOR.FindControl("txtNomeFornecedor"), Infragistics.WebUI.WebDataInput.WebTextEdit).Text)
            ElseIf ucFornecedorOR.CodFornecedor > 0 Then
                ucFornecedorDS.SelecionarFornecedor(ucFornecedorOR.CodFornecedor)
            End If
            'Util.AdicionaJsFocus(Me.Page, CType(ddlEmpenhoOR, System.Web.UI.WebControls.WebControl), Util.tipoDeComponente.Outros)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ucFornecedorDS_FornecedorAlterado(ByVal e As System.Web.UI.WebControls.ListItem) Handles ucFornecedorDS.FornecedorAlterado
        Try
            If ucFornecedorDS.CodFornecedor > 0 And Not ddlEmpenhoDS.SelectedValue Is String.Empty Then
                If Me.ValidaFornecedorSelecionado(ucFornecedorDS) Then
                    'Me.CarregaDDLDestino()
                End If
            End If
            Util.AdicionaJsFocus(Me.Page, CType(ddl4, System.web.UI.WebControls.WebControl))
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub grdAlocacoes_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.RowEventArgs) Handles grdAlocacoes.InitializeRow
        Try
            With CType(CType(e.Data, DataRowView).Row, wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedorRow)
                If .IsDesAlcVbaFrnNull OrElse .DesAlcVbaFrn Is String.Empty Then
                    e.Row.Delete()
                Else
                    Me.VlrSldDspAlcVbaFrnPmt += .VlrSldDspAlcVbaFrn
                End If
            End With
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        Me.SalvaEstado()
    End Sub

    Private Sub txtEmpenho_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtEmpenho.ValueChange
        Try
            If txtEmpenho.Text <> ddlEmpenhoOR.SelectedValue.ToString Then
                For Each item As ListItem In ddlEmpenhoOR.Items
                    If item.Text.Length > 4 Then
                        If item.Text.Substring(0, 4) = txtEmpenho.ValueDecimal.ToString("0000") Then
                            ddlEmpenhoOR.SelectedValue = item.Value
                            ddlEmpenhoOR_SelectedIndexChanged(sender, e)
                            Exit For
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ucFornecedorOR_FornecedorAlterado1(ByVal e As System.Web.UI.WebControls.ListItem) Handles ucFornecedorOR.FornecedorAlterado
        Util.AdicionaJsFocus(Me.Page, CType(ddl2, System.web.UI.WebControls.WebControl))
        ucFornecedorDS.SelecionarFornecedor(ucFornecedorOR.CodFornecedor)
        ucFornecedorDS_FornecedorAlterado(e)

        If ucFornecedorOR.CodFornecedor = 0 Then
            Me.Limpa_Form()
            Exit Sub
        End If
        Me.CarregaGridAlocacoes()
        Me.CarregaControlesValores()

    End Sub

#End Region

#Region " Metodos "

#Region " Métodos de Carga "

    Private Sub InicializaPagina()
        If (Not Me.IsPostBack) Then
            ucFornecedorOR.widthNome = System.Web.UI.WebControls.Unit.Parse("285px")
            ucFornecedorDS.widthNome = System.Web.UI.WebControls.Unit.Parse("285px")
            Me.CargaInicialDados()
            Util.AdicionaJsFocus(Me.Page, CType(ddl1, System.web.UI.WebControls.WebControl))
        Else
            Me.RecuperaEstado()
        End If
        btnSalvar.Attributes.Add("OnClick", "javascript:return confirm('Confirma Transferencia')")
        btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
    End Sub

    Private Sub RecuperaEstado()
        If Not ViewState.Item(dsSelecaoValorDisponivelFornecedor.DataSetName) Is Nothing Then _
            dsSelecaoValorDisponivelFornecedor = DirectCast(Me.ViewState.Item(dsSelecaoValorDisponivelFornecedor.DataSetName), wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor)
        If Not ViewState.Item(dsEmpenho.DataSetName) Is Nothing Then _
            dsEmpenho = DirectCast(Me.ViewState.Item(dsEmpenho.DataSetName), wsAcoesComerciais.DatasetEmpenho)
    End Sub

    Private Sub SalvaEstado()
        If Not dsSelecaoValorDisponivelFornecedor Is Nothing Then _
            Me.ViewState.Add(dsSelecaoValorDisponivelFornecedor.DataSetName, dsSelecaoValorDisponivelFornecedor)
        If Not dsEmpenho Is Nothing Then _
            Me.ViewState.Add(dsEmpenho.DataSetName, dsEmpenho)
    End Sub

    Private Sub CargaInicialDados()
        TD1.Visible = False
        TD2.Visible = False
        TD3.Visible = False
        TD4.Visible = False
        TD5.Visible = False
        TD6.Visible = False
        TD7.Visible = False
        TD8.Visible = False

        ' CARREGA OS DADOS INICIAIS
        txtData.Value = Date.Now
        txtUsuario.Text = WSCAcoesComerciais.dsUsuarioCompra.T0113471.Item(0).NOMACSUSRSIS.Trim()
        Me.CarregaDDLEmpenhos()

        'Util.AdicionaJsFocus(Me.Page, CType(ucFornecedorOR.FindControl("txtCodigo"), WebControl))
    End Sub

    Private Sub CarregaDDLEmpenhos()
        dsEmpenho = Controller.ObterEmpenhos(String.Empty, String.Empty, String.Empty, 0, String.Empty)
        Util.carregarCmbEmpenho(dsEmpenho, ddlEmpenhoDS, New ListItem(String.Empty, String.Empty))
        Util.carregarCmbEmpenho(dsEmpenho, ddlEmpenhoOR, New ListItem(String.Empty, String.Empty))
    End Sub

    Private Sub CarregaGridAlocacoes(Optional ByVal PageIndex As Integer = 0, Optional ByVal recarregaDS As Boolean = True)
        grdAlocacoes.Rows.Clear()
        If ucFornecedorOR.CodFornecedor <= 0 Or getEmpenhoValue(ddlEmpenhoOR.SelectedItem) <= 0 Then
            Exit Sub
        End If

        If recarregaDS Then
            dsSelecaoValorDisponivelFornecedor = Controller.ObterSelecaoValorDisponivelFornecedor(Date.Parse(txtData.Text), ucFornecedorOR.CodFornecedor, Convert.ToDecimal(ddlEmpenhoOR.SelectedValue))
        End If
        grdAlocacoes.Rows.Clear()
        DataBindGrdAlocacoes()
        Dim row As New Infragistics.WebUI.UltraWebGrid.UltraGridRow(True)

        row.Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
        row.Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
        row.Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
        row.Cells(2).Value = "3 - CONTA CORRENTE"
        row.Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
        row.Cells(3).Value = String.Empty
        row.Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
        row.Cells(4).Value = String.Empty
        row.Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)

        Calcula_VlrSldDspAlcVbaFrnPmt()
        If dsSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedor.Item(0).IsVlrSldDspNull Then
            row.Cells(5).Value = 0 - Me.VlrSldDspAlcVbaFrnPmt
        Else
            row.Cells(5).Value = dsSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedor.Item(0).VlrSldDsp - Me.VlrSldDspAlcVbaFrnPmt
        End If

        grdAlocacoes.Rows.Add(row)
    End Sub

    Private Sub CarregaControlesValores()
        txtSaldoDisp.Value = 0
        txtSaldoEmp.Value = 0
        txtTotalAloc.ValueDecimal = 0

        If ucFornecedorOR.CodFornecedor <= 0 Or getEmpenhoValue(ddlEmpenhoOR.SelectedItem) <= 0 Then
            Exit Sub
        End If

        If Not dsSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedor.Item(0).IsVlrSldDspNull Then
            txtSaldoDisp.Value = dsSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedor.Item(0).VlrSldDsp - Me.Calcula_VlrSldDspAlcVbaFrnPmt()
        End If
        If Not dsSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedor.Item(0).IsVlrSldDspNull Then
            txtSaldoEmp.Value = dsSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedor.Item(0).VlrSldDsp
        End If

        txtTotalAloc.ValueDecimal = Me.Calcula_VlrSldDspAlcVbaFrnPmt()

        If ddlEmpenhoDS.SelectedIndex > 0 Then
            If grdAlocacoes.Rows.Count > 0 Then
                If Convert.ToDecimal(Me.ddlEmpenhoDS.SelectedValue) > 0 Then
                    Me.VrfAlc(Convert.ToDecimal(Val(getEmpenhoDESALCVBAFRN())))
                End If
            End If
        End If
    End Sub

    'Private Sub CarregaDDLDestino()
    '    ddlDestino.Items.Clear()
    '    'For Each drDestino As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedorRow In _
    '    '    Controller.ObterSelecaoValorDisponivelFornecedor(txtData.Date, ucFornecedorDS.CodFornecedor, Convert.ToDecimal(ddlEmpenhoDS.SelectedValue)).tbSelecaoValorDisponivelFornecedor.Rows
    '    '    With ddlDestino
    '    '        If Not drDestino.IsDesAlcVbaFrnNull AndAlso Not drDestino.DesAlcVbaFrn.Trim() Is String.Empty Then
    '    '            .Items.Add(New ListItem(drDestino.DesAlcVbaFrn, drDestino.TipAlcVbaFrn.ToString()))
    '    '        End If
    '    '    End With
    '    'Next

    '    ddlDestino.Items.Add(New ListItem("2 - MARKETING", "2"))
    '    ddlDestino.Items.Add(New ListItem("3 - CONTA CORRENTE", "3"))
    '    ddlDestino.SelectedValue = "3"

    '    'If ddlDestino.Items.Count = 2 Then
    '    '    ddlDestino.SelectedValue = ddlDestino.Items(1).Value
    '    'End If
    'End Sub

    Private Sub DataBindGrdAlocacoes()
        Dim flagEncontrouValor As Boolean
        For Each linha As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedorRow In dsSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedor
            Dim row As New Infragistics.WebUI.UltraWebGrid.UltraGridRow(True)
            flagEncontrouValor = False

            row.Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
            row.Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
            row.Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)

            If (Not linha.IsDesAlcVbaFrnNull) And (Not linha.IsTipAlcVbaFrnNull) Then
                row.Cells(2).Value = linha.TipAlcVbaFrn.ToString & " - " & linha.DesAlcVbaFrn
                flagEncontrouValor = True
            Else
                row.Cells(2).Value = String.Empty
            End If

            row.Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
            If Not linha.IsVlrAlcVbaFrnNull Then
                row.Cells(3).Value = linha.VlrAlcVbaFrn
                If linha.VlrAlcVbaFrn > 0 Then flagEncontrouValor = True
            Else
                row.Cells(3).Value = Decimal.Zero
            End If

            row.Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
            If Not linha.IsVlrRcbAlcVbaFrnNull Then
                row.Cells(4).Value = linha.VlrRcbAlcVbaFrn
                If linha.VlrRcbAlcVbaFrn > 0 Then flagEncontrouValor = True
            Else
                row.Cells(4).Value = Decimal.Zero
            End If

            row.Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
            If Not linha.IsVlrSldDspAlcVbaFrnNull Then
                row.Cells(5).Value = linha.VlrSldDspAlcVbaFrn
                If linha.VlrSldDspAlcVbaFrn > 0 Then flagEncontrouValor = True
            Else
                row.Cells(5).Value = Decimal.Zero
            End If

            If flagEncontrouValor Then
                grdAlocacoes.Rows.Add(row)
            End If

        Next
    End Sub

#End Region

#Region " Metodos de Regras de Negocio "

    Private Function Existe_Relacao_Usuario_TipTransf() As Boolean
        Return Controller.ObterRelacaoTipoTransferenciaEmpenhoFornecedor(1, txtUsuario.Text.Trim(), Decimal.Zero).tbOperacao01.Rows.Count > 0
    End Function

    Private Function Existe_Relacao_Empenho_Usuario_TipoTransf(ByVal TipDsnDscBnf As Decimal) As Boolean
        ' Verifica se existe uma relacao empenho X usuario X tipo TransferenciaGAC
        Return Controller.ObterRelacaoTipoTransferenciaEmpenhoFornecedor(2, txtUsuario.Text.Trim(), TipDsnDscBnf).tbOperacao02.Rows.Count > 0
    End Function

    Private Function Existe_Empenho_Relacionado(ByVal TipDsnDscBnf As Decimal) As Boolean
        ' Verifica se o empenho existe na relacao de TransferenciaGAC
        ' para um usuario que nao seja o que esta executando o programa
        ' se o usuario esta na relacao este empenho e carregado no combo
        Return Controller.ObterRelacaoTipoTransferenciaEmpenhoFornecedor(3, txtUsuario.Text.Trim(), TipDsnDscBnf).tbOperacao03.Rows.Count > 0
    End Function

    'Private Sub FlaDDLEmpenho(ByRef lstItem As ListItem, ByVal FlgCtbDsnDsc As String)
    '    If FlgCtbDsnDsc.Equals("S") Then
    '        lstItem.Value = String.Concat(lstItem.Value, ";", "1")
    '    Else
    '        lstItem.Value = String.Concat(lstItem.Value, ";", "0")
    '    End If
    'End Sub

    Private Function getEmpenhoValue(ByRef lstItem As ListItem) As Decimal
        Dim result As Decimal
        If IsNumeric(lstItem.Value) Then
            result = Convert.ToDecimal(lstItem.Value)
        Else
            result = 0
        End If
        Return result
    End Function

    Private Function getEmpenhoDESALCVBAFRN() As String
        Dim linha As wsAcoesComerciais.DatasetEmpenho.T0109059Row

        If ddlEmpenhoDS.SelectedValue Is String.Empty Then
            Return String.Empty
        End If

        linha = dsEmpenho.T0109059.FindByTIPDSNDSCBNF(Convert.ToDecimal(ddlEmpenhoDS.SelectedValue))

        If linha Is Nothing Then
            Return String.Empty
        End If

        If linha.T0151799Row Is Nothing Then
            Return String.Empty
        End If

        Try
            Return linha.T0151799Row.TIPALCVBAFRN.ToString & " - " & linha.T0151799Row.DESALCVBAFRN
        Catch ex As Exception
        End Try
    End Function

    Private Function Calcula_VlrSldDspAlcVbaFrnPmt() As Decimal
        Dim result As Decimal = Decimal.Zero
        For Each dr As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedorRow In dsSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedor.Rows
            If Not dr.IsVlrSldDspAlcVbaFrnNull Then
                result += dr.VlrSldDspAlcVbaFrn
            End If
        Next
        Me.VlrSldDspAlcVbaFrnPmt = result
        Return result
    End Function

    Private Function VrfAlc(ByVal lTipAlcVbaFrn As Decimal) As Boolean
        For Each dr As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedorRow In dsSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedor.Rows
            If lTipAlcVbaFrn = dr.TipAlcVbaFrn Then
                txtSaldoDisp.Value = dr.TipAlcVbaFrn
                Return True
            End If
        Next
    End Function

    Private Function ValidaFornecedorSelecionado(ByRef uc As wucFornecedor) As Boolean
        If Not WSCAcoesComerciais.dsUsuarioCompra.T0113471.Item(0).TIPUSRSIS.Equals("X") Then
            If Not Controller.FornecedorPertenceCelulaAtendidaUsuario(uc.CodFornecedor(), txtUsuario.Text.Trim()) Then
                Util.AdicionaJsAlert(Me.Page, "Fornecedor não pertencente à célula. Favor selecionar outro fornecedor.")
                'Util.AdicionaJsFocus(Me.Page, CType(uc.FindControl("txtCodigo"), WebControl))
                uc.SelecionarVazio()
                Return False
            End If
        Else
            Return True
        End If
    End Function

    Private Function ValidarTransferenciaGAC() As Boolean
        '----------------------------ORIGEM---------------------------
        If ucFornecedorOR.CodFornecedor <= 0 Then
            Util.AdicionaJsAlert(Me.Page, "O Fornecedor [Origem] é Obrigatório! ")
            Util.AdicionaJsFocus(Me.Page, CType(ucFornecedorOR.FindControl("txtCodigo"), WebControl))
            Return False
        End If
        If ddlEmpenhoOR.SelectedValue Is String.Empty Then
            Util.AdicionaJsAlert(Me.Page, "O Empenho [Origem] é Obrigatório! ")
            Util.AdicionaJsFocus(Me.Page, CType(ddlEmpenhoOR, WebControl))
            Return False
        End If
        If grdAlocacoes.DisplayLayout.ActiveRow Is Nothing Then
            If grdAlocacoes.DisplayLayout.Rows.Count = 1 Then
                grdAlocacoes.DisplayLayout.Rows(0).Activate()
            Else
                Util.AdicionaJsAlert(Me.Page, "Você deve escolher uma opção da grade (MARGEM, MARKETING OU CONTA CORRENTE) ! ")
                Return False
            End If
        End If
        '----------------------------DESTINO---------------------------
        If ucFornecedorOR.CodFornecedor <= 0 Then
            Util.AdicionaJsAlert(Me.Page, "O Fornecedor [Destino] é Obrigatório! ")
            Util.AdicionaJsFocus(Me.Page, CType(ucFornecedorDS.FindControl("txtCodigo"), WebControl))
            Return False
        End If
        If ddlEmpenhoOR.SelectedValue Is String.Empty Then
            Util.AdicionaJsAlert(Me.Page, "O Empenho [Destino] é Obrigatório! ")
            Util.AdicionaJsFocus(Me.Page, CType(ddlEmpenhoDS, WebControl))
            Return False
        End If
        If ddlDestino.SelectedValue Is String.Empty Then
            Util.AdicionaJsAlert(Me.Page, "O Campo [Destino] é Obrigatório! ")
            Util.AdicionaJsFocus(Me.Page, CType(ddlDestino, WebControl))
            Return False
        End If
        If txtValor.ValueDecimal <= 0 Then
            Util.AdicionaJsAlert(Me.Page, "O Valor a ser transferido é Inválido! ")
            Util.AdicionaJsFocus(Me.Page, CType(txtValor, WebControl))
            Return False
        End If
        If txtHistorico.Text.Trim.Length = 0 Then
            Util.AdicionaJsAlert(Me.Page, "É obrigatório digitar o histórico ! ")
            Util.AdicionaJsFocus(Me.Page, CType(txtHistorico, WebControl))
            Return False
        End If

        'Adicionado em 16/05/2007, solicitação Elisangela
        'Alterado em 04/07/2007, criado regra diferente para empenho 42
        If Convert.ToDecimal(ddlEmpenhoOR.SelectedValue) = 42 And Convert.ToDecimal(ddlEmpenhoDS.SelectedValue) = 42 Then
            If ucFornecedorOR.CodFornecedor = ucFornecedorDS.CodFornecedor And _
               ddlEmpenhoOR.SelectedValue = ddlEmpenhoDS.SelectedValue And _
               Convert.ToInt32(Val(grdAlocacoes.DisplayLayout.ActiveRow().Cells(2).Value)) = CType(ddlDestino.SelectedValue, Integer) Then
                Util.AdicionaJsAlert(Me.Page, "Não é permitido fornecedor, empenho e alocação iguais para origem e destino")
                Util.AdicionaJsFocus(Me.Page, CType(ucFornecedorDS.FindControl("txtCodigo"), WebControl))
                Return False
            End If
        Else
            If ucFornecedorOR.CodFornecedor = ucFornecedorDS.CodFornecedor And _
               ddlEmpenhoOR.SelectedValue = ddlEmpenhoDS.SelectedValue  Then
                Util.AdicionaJsAlert(Me.Page, "Não é permitido fornecedor e empenho iguais para origem e destino")
                Util.AdicionaJsFocus(Me.Page, CType(ucFornecedorDS.FindControl("txtCodigo"), WebControl))
                Return False
            End If
        End If

        If ucFornecedorOR.CodFornecedor = ucFornecedorDS.CodFornecedor And _
           ddlEmpenhoOR.SelectedValue = ddlEmpenhoDS.SelectedValue And _
           getValorSelecionado() = CType(ddlDestino.SelectedValue, Decimal) Then
            Util.AdicionaJsAlert(Me.Page, "Não é permitido fornecedor e empenho iguais para origem e destino")
            Util.AdicionaJsFocus(Me.Page, CType(ucFornecedorDS.FindControl("txtCodigo"), WebControl))
            Return False
        End If

        'If Convert.ToDecimal(ddlDestino.SelectedValue) <> 42 And Convert.ToDecimal(ddlEmpenhoDS.SelectedValue) = 2 Then
        '    Util.AdicionaJsAlert(Me.Page, "O destino Marketing não pode utilizando com empenho " & ddlDestino.SelectedValue.ToString)
        '    Util.AdicionaJsFocus(Me.Page, CType(ddlDestino, WebControl))
        '    Return False
        'End If

        Return True
    End Function

    Private Function getValorSelecionado() As Decimal
        getValorSelecionado = Convert.ToDecimal(grdAlocacoes.DisplayLayout.ActiveRow().Cells(5).Value)
    End Function

    Private Sub TransferirValoreEntreEmpenhosFornecedorGAC()
        If flagProcessandoTransferencia Then
            Exit Sub
        End If

        If txtValor.ValueDecimal <= Me.getValorSelecionado() Then

            Dim TipAlcVbaFrnDstPmtDdoOrigem As Integer
            If Convert.ToInt32(Val(grdAlocacoes.DisplayLayout.ActiveRow().Cells(2).Value)) = 3 Then
                TipAlcVbaFrnDstPmtDdoOrigem = 0
            Else
                TipAlcVbaFrnDstPmtDdoOrigem = Convert.ToInt32(Val(grdAlocacoes.DisplayLayout.ActiveRow().Cells(2).Value))
            End If

            Dim TipAlcVbaFrnDstPmtDdoDestino As Integer
            If ddlDestino.SelectedValue.Equals(3) Then
                TipAlcVbaFrnDstPmtDdoDestino = 9999
            Else
                TipAlcVbaFrnDstPmtDdoDestino = Convert.ToInt32(ddlDestino.SelectedValue)
            End If

            Dim pTipAlcVbaFrn As Integer = 0
            Try
                If Not grdAlocacoes.DisplayLayout.ActiveRow().Cells(1).Value Is Nothing Then
                    pTipAlcVbaFrn = Convert.ToInt32(grdAlocacoes.DisplayLayout.ActiveRow().Cells(1).Value)
                End If
            Catch ex As Exception
            End Try

            Try
                flagProcessandoTransferencia = True
                Util.gravaInformacaoEventView("Transferência Gac iniciada")
                Controller.TransferirValoreEntreEmpenhosFornecedorGAC(txtValor.ValueDecimal, _
                                                     pTipAlcVbaFrn, _
                                                     txtData.Date, _
                                                     Convert.ToDecimal(ddlEmpenhoOR.SelectedValue), _
                                                     Convert.ToDecimal(ddlEmpenhoDS.SelectedValue), _
                                                     ucFornecedorOR.CodFornecedor, _
                                                     ucFornecedorDS.CodFornecedor, _
                                                     txtValor.ValueDecimal, _
                                                     txtHistorico.Text, _
                                                     "Transf. p/ " & ddlEmpenhoDS.SelectedItem.Text.Trim().Split("-"c)(1).Trim() & " - " & ucFornecedorDS.NomFornecedor.Trim().Split("-"c)(1).Trim(), _
                                                     "Transf. de " & ddlEmpenhoOR.SelectedItem.Text.Split("-"c)(1).Trim() & " - " & ucFornecedorOR.NomFornecedor.Split("-"c)(1).Trim(), _
                                                     txtUsuario.Text.Trim(), _
                                                     TipAlcVbaFrnDstPmtDdoOrigem, _
                                                     TipAlcVbaFrnDstPmtDdoDestino)

            Catch ex As Exception
                Util.gravaInformacaoEventView("Transferência Gac concluída com erro")
                Throw ex
            Finally
                flagProcessandoTransferencia = False
            End Try

            Util.AdicionaJsAlert(Me.Page, "Transferência Concluída." & vbCrLf & _
                                          "Origem : " & ucFornecedorOR.NomFornecedor & vbCrLf & _
                                          "Empenho : " & ddlEmpenhoOR.SelectedItem.Text & vbCrLf & _
                                          "Valor : " & txtValor.ValueDecimal & vbCrLf & _
                                          "Destino : " & ucFornecedorDS.NomFornecedor & vbCrLf & _
                                          "Empenho : " & ddlEmpenhoDS.SelectedItem.Text)
            Limpa_Form()
            Util.AdicionaJsFocus(Me.Page, CType(ddl1, System.web.UI.WebControls.WebControl))
            Util.gravaInformacaoEventView("Transferência Gac concluída com sucesso")
        Else
            Util.AdicionaJsAlert(Me.Page, "Não foi possível a transferência. Saldo Insuficiente.")
        End If
    End Sub

    Private Sub Limpa_Form()
        ucFornecedorOR.SelecionarVazio()
        ucFornecedorDS.SelecionarVazio()
        ddlEmpenhoOR.SelectedValue = String.Empty
        ddlEmpenhoDS.SelectedValue = String.Empty
        grdAlocacoes.Rows.Clear()
        'ddlDestino.Items.Clear()
        txtHistorico.Text = ""
        txtValor.Text = ""
        txtSaldoDisp.Text = ""
        txtSaldoEmp.Text = ""
        txtEmpenho.Text = ""
        txtEmpenhoDS.Text = ""

        'Limpa propriedades
        VlrSldDspAlcVbaFrnPmt = 0
        VlrSldDspAlcVbaFrn = 0
        FlagAlocacao = False
        FlgExtUsr = False
        bEmpTransf = False
        VlrSldDsp = 0
    End Sub

#End Region

#End Region

End Class