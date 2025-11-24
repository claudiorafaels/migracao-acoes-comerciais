Public Class Transferencia
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
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtData As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtUsuario As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlEmpenhoOR As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtTotalAloc As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents grdAlocacoes As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents dsSelecaoValorDisponivelFornecedor As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
    Protected WithEvents ucFornecedorOR As wucFornecedor
    Protected WithEvents ucFornecedorDS As wucFornecedor
    Protected WithEvents dsEmpenho As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetEmpenho
    Protected WithEvents txtSaldoEmp As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtSaldoDisp As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtEmpenho As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents ddl1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddl2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents cmbTipo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtHistorico As System.Web.UI.WebControls.TextBox
    Protected WithEvents TbUmDestino As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents TbUmaOrigem As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents TbMuitasOrigens As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents TbMuitosDestinos As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents grdOrigemN As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents Dropdownlist1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ucfornecedorOrigemN As wucFornecedor
    Protected WithEvents txtValor As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents cmdCalcularValores As System.Web.UI.WebControls.Button
    Protected WithEvents lblMensagemDesatualizado As System.Web.UI.WebControls.Label
    Protected WithEvents grdDestinoN As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents ValorTransferir As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents lblAlcVbaFrn As System.Web.UI.WebControls.Label
    Protected WithEvents ddlEmpenhoDS As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtEmpenhoDS As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents ValorTransferirDestino As Infragistics.WebUI.WebDataInput.WebNumericEdit
    'Protected colEmpenhosPermitidosNaOrigem As Hashtable

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

    Private Property FlagAlocacaoOrigem() As Boolean
        Get
            If Not Me.ViewState.Item("FlagAlocacaoOrigem") Is Nothing Then
                Return DirectCast(Me.ViewState.Item("FlagAlocacaoOrigem"), Boolean)
            Else
                Return False
            End If
        End Get
        Set(ByVal Value As Boolean)
            Me.ViewState("FlagAlocacaoOrigem") = Value
        End Set
    End Property

    Private ReadOnly Property FlagAlocacaoDestino() As Boolean
        Get
            Dim result As Boolean = False
            If vCmbDsnDsnTipAlcVbaFrn <> 0 Then
                result = True
            End If
            Return result
        End Get
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
                linha = dsEmpenho.T0109059.FindByTIPDSNDSCBNF(Convert.ToDecimal(getEmpenhoValue(ddlEmpenhoOR.SelectedItem)))
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
                Return dsEmpenho.T0109059.FindByTIPDSNDSCBNF(Convert.ToDecimal(getEmpenhoValue(ddlEmpenhoOR.SelectedItem)))
            Catch ex As Exception
            End Try
        End Get
    End Property

    Private ReadOnly Property linhaEmpenhoDestino() As wsAcoesComerciais.DatasetEmpenho.T0109059Row
        Get
            Try
                Return dsEmpenho.T0109059.FindByTIPDSNDSCBNF(Convert.ToDecimal(getEmpenhoValue(ddlEmpenhoDS.SelectedItem)))
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

            Try
                If grdAlocacoes.DisplayLayout.ActiveRow Is Nothing Then
                    If grdAlocacoes.DisplayLayout.Rows.Count >= 1 Then
                        grdAlocacoes.DisplayLayout.Rows(0).Activate()
                    End If
                End If
                If Not grdAlocacoes.DisplayLayout.ActiveRow Is Nothing Then
                    result = Convert.ToInt32(Val(grdAlocacoes.DisplayLayout.ActiveRow.Cells(2).Value))
                End If
            Catch ex As Exception
            End Try

            'If Not linhaEmpenhoOrigem.IsTIPALCVBAFRNNull Then
            '    result = Convert.ToInt32(linhaEmpenhoOrigem.TIPALCVBAFRN)
            'End If

            Return result
        End Get
    End Property

    Private Property InsOri() As Boolean
        Get
            If Not Me.ViewState.Item("InsOri") Is Nothing Then
                Return DirectCast(Me.ViewState.Item("InsOri"), Boolean)
            Else
                Return False
            End If
        End Get
        Set(ByVal Value As Boolean)
            Me.ViewState("InsOri") = Value
        End Set
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

    Private Property colEmpenhosPermitidosNaOrigem() As Hashtable
        Get
            Dim result As Hashtable
            If viewstate("colEmpenhosPermitidosNaOrigem") Is Nothing Then
                result = New Hashtable
            Else
                result = CType(viewstate("colEmpenhosPermitidosNaOrigem"), Hashtable)
            End If
            Return result
        End Get

        Set(ByVal Value As Hashtable)
            viewstate("colEmpenhosPermitidosNaOrigem") = Value
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
        Try
            Select Case cmbTipo.SelectedValue
                Case "1" '1 EMPENHO ORIGEM E 1 EMPENHO DESTINO (1 p/ 1)
                    AtualizarUmaOrigemParaUmDestino()
                Case "2" '1 EMPENHO ORIGEM E 'N' EMPENHOS DESTINO (1 p/ N)
                    AtualizarUmaOrigemParaNDestinos()
                Case "3" ''N' EMPENHOS DE ORIGEM E 1 EMPENHO DESTINO (N p/ 1)
                    AtualizarNOrigensParaUmDestino()
            End Select
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
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

            If Constants.EMPENHO_FORNECEDOR_MARKETING = getEmpenhoValue(ddlEmpenhoOR.SelectedItem) Then
                Util.AdicionaJsAlert(Me.Page, "Não é permitido a transferência do empenho marketing pelo processo de transferência compras!", True)
                ddlEmpenhoOR.SelectedIndex = 0
                txtEmpenho.Text = String.Empty
                Exit Sub
            End If

            If ddlEmpenhoOR.SelectedIndex > 0 And ucFornecedorOR.CodFornecedor > 0 Then
                If Me.ValidaFornecedorSelecionado(ucFornecedorOR) Then
                    Me.CarregaGridAlocacoes()
                    Me.CarregaControlesValores()
                    Util.AdicionaJsFocus(Me.Page, CType(ddlEmpenhoOR, System.web.UI.WebControls.WebControl))
                End If
            Else
                Me.CarregaGridAlocacoes()
                Me.CarregaControlesValores()
            End If

            If txtEmpenho.Text <> getEmpenhoValue(ddlEmpenhoOR.SelectedItem).ToString Then
                txtEmpenho.Text = getEmpenhoValue(ddlEmpenhoOR.SelectedItem).ToString
            End If

            'Verifica se o empenho de origem é relacionado ao estoque, se for valida o tipo da transferencia
            If txtEmpenho.ValueDecimal > 0 Then
                If Me.empenhoEstaRelacionadoAEstoque(txtEmpenho.ValueDecimal) And cmbTipo.SelectedValue <> "1" Then
                    Util.AdicionaJsAlert(Me.Page, "Para empenho relacionado a estoque é permitido somente transferencia do tipo: '1 EMPENHO ORIGEM E 1 EMPENHO DESTINO'")
                    cmbTipo.SelectedValue = "1"
                    MostrarEsconderTabelasDeAcordoComTipoEscolhido()
                End If
            End If

            'Bloqueia os campos Empenho de Destino caso o empenho de origem seja relacionado ao estoque
            If Me.empenhoEstaRelacionadoAEstoque(txtEmpenho.ValueDecimal) Then
                Me.txtEmpenhoDS.Text = txtEmpenho.Text
                Me.ddlEmpenhoDS.SelectedValue = Me.ddlEmpenhoOR.SelectedValue
                Me.ddlEmpenhoDS.SelectedItem.Text = Me.ddlEmpenhoOR.SelectedItem.Text
                Me.txtEmpenhoDS.Enabled = False
                Me.ddlEmpenhoDS.Enabled = False
            Else
                Me.txtEmpenhoDS.Text = String.Empty
                Me.ddlEmpenhoDS.SelectedItem.Text = String.Empty
                Me.txtEmpenhoDS.Enabled = True
                Me.ddlEmpenhoDS.Enabled = True
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ucFornecedorOR_FornecedorAlterado(ByVal e As System.Web.UI.WebControls.ListItem) Handles ucFornecedorOR.FornecedorAlterado
        Try
            Dim linhaUsuarioLogado As wsAcoesComerciais.dataSetUsuarioCompra.T0113471Row
            Try
                linhaUsuarioLogado = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0)
            Catch ex As Exception
                Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
                Exit Sub
            End Try

            If Not CType(ucFornecedorOR.FindControl("txtNomeFornecedor"), Infragistics.WebUI.WebDataInput.WebTextEdit).Text Is String.Empty Then
                ucFornecedorDS.PesquisarFornecedor(CType(ucFornecedorOR.FindControl("txtNomeFornecedor"), Infragistics.WebUI.WebDataInput.WebTextEdit).Text)
            ElseIf ucFornecedorOR.CodFornecedor > 0 Then
                ucFornecedorDS.SelecionarFornecedor(ucFornecedorOR.CodFornecedor)
            End If

            If ucFornecedorOR.CodFornecedor = 0 Then
                Me.Limpa_Form()
                Exit Sub
            End If

            Me.CarregaGridAlocacoes()
            Me.CarregaControlesValores()

            If ucFornecedorDS.CodFornecedor <> ucFornecedorOR.CodFornecedor Then
                ucFornecedorDS.SelecionarFornecedor(ucFornecedorOR.CodFornecedor)
            End If

            Util.AdicionaJsFocus(Me.Page, CType(ddl2, System.web.UI.WebControls.WebControl))

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub

    Private Sub ucFornecedorOrigemN_FornecedorAlterado(ByVal e As System.Web.UI.WebControls.ListItem) Handles ucfornecedorOrigemN.FornecedorAlterado
        Try
            Dim linhaUsuarioLogado As wsAcoesComerciais.dataSetUsuarioCompra.T0113471Row
            Try
                linhaUsuarioLogado = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0)
            Catch ex As Exception
                Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
                Exit Sub
            End Try

            If ucfornecedorOrigemN.CodFornecedor = 0 Then
                Me.Limpa_Form()
                Exit Sub
            End If

            Me.CarregaGridOrigemN()
            'ucFornecedorDS.SelecionarFornecedor(ucfornecedorOrigemN.CodFornecedor)

            If ucFornecedorDS.CodFornecedor <> ucfornecedorOrigemN.CodFornecedor Then
                ucFornecedorDS.SelecionarFornecedor(ucfornecedorOrigemN.CodFornecedor)
            End If

            Util.AdicionaJsFocus(Me.Page, CType(ddl2, System.web.UI.WebControls.WebControl))
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ucFornecedorDS_FornecedorAlterado(ByVal e As System.Web.UI.WebControls.ListItem)
        Try
            Dim linhaUsuarioLogado As wsAcoesComerciais.dataSetUsuarioCompra.T0113471Row

            Try
                linhaUsuarioLogado = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0)
            Catch ex As Exception
                Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
                Exit Sub
            End Try

            If ucFornecedorDS.CodFornecedor > 0 And ucFornecedorDS.CodFornecedor > 0 Then
                If linhaUsuarioLogado.TIPUSRSIS <> "X" Then
                    If Not ValidaFornecedorSelecionado(ucFornecedorDS) Then
                        Util.AdicionaJsAlert(Me.Page, "Fornecedor não pertencente à célula. Favor selecionar outro fornecedor. (1)")
                        Me.Limpa_Form()
                        'ucFornecedorDS.SelecionarVazio()
                    End If
                End If
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ddlEmpenhoDS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlEmpenhoDS.SelectedIndexChanged
        Try
            Dim dVlr As Decimal
            lblAlcVbaFrn.Text = ""

            'Busca DESALCVBAFRN
            lblAlcVbaFrn.Text = ""
            If ddlEmpenhoDS.SelectedIndex > -1 And ddlEmpenhoDS.SelectedItem.ToString.Trim.Length > 0 Then
                If getEmpenhoValue(ddlEmpenhoDS.SelectedItem) > 0 Then
                    lblAlcVbaFrn.Text = getEmpenhoDESALCVBAFRN()
                End If
            End If

            If ucFornecedorDS.CodFornecedor > 0 And Not ddlEmpenhoDS.SelectedValue Is String.Empty Then
                CarregaControlesValores()
            End If

            'O código abaixo já é executado no método acima: CarregaControlesValores()
            ''Busca o saldo disponível
            'dVlr = VlrSldDsp
            'If ddlEmpenhoDS.SelectedIndex > -1 And ddlEmpenhoDS.SelectedItem.ToString.Trim.Length > 0 Then
            '    If grdAlocacoes.Rows.Count > 0 Then
            '        If getEmpenhoValue(ddlEmpenhoDS.SelectedItem) > 0 Then
            '            If VrfAlc(Convert.ToDecimal(Val(getEmpenhoDESALCVBAFRN()))) Then
            '                dVlr = VlrSldDspAlcVbaFrn
            '            End If
            '        End If
            '    End If
            'End If
            'txtSaldoDisp.ValueDecimal = dVlr

            If txtEmpenhoDS.Text <> getEmpenhoValue(ddlEmpenhoDS.SelectedItem).ToString Then
                txtEmpenhoDS.Text = getEmpenhoValue(ddlEmpenhoDS.SelectedItem).ToString
            End If

            Util.AdicionaJsFocus(Me.Page, CType(ddlEmpenhoDS, System.web.UI.WebControls.WebControl))
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function getEmpenhoDESALCVBAFRN() As String
        Try
            Dim linha As wsAcoesComerciais.DatasetEmpenho.T0109059Row

            If ddlEmpenhoDS.SelectedValue Is String.Empty Then
                Return String.Empty
            End If

            linha = dsEmpenho.T0109059.FindByTIPDSNDSCBNF(getEmpenhoValue(ddlEmpenhoDS.SelectedItem))

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
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

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
            Dim flgEncontrou As Boolean = False
            If txtEmpenho.Text <> getEmpenhoValue(ddlEmpenhoOR.SelectedItem).ToString Then
                For Each item As ListItem In ddlEmpenhoOR.Items
                    If item.Text = "" And txtEmpenho.Text = "" Then
                        ddlEmpenhoOR.SelectedValue = item.Value
                        ddlEmpenhoOR_SelectedIndexChanged(sender, e)
                        flgEncontrou = True
                        Exit For
                    ElseIf item.Text.Length > 4 Then
                        If item.Text.Substring(0, 4) = txtEmpenho.ValueDecimal.ToString("0000") Then
                            ddlEmpenhoOR.SelectedValue = item.Value
                            ddlEmpenhoOR_SelectedIndexChanged(sender, e)
                            flgEncontrou = True
                            Exit For
                        End If
                    End If
                Next

                If Not flgEncontrou Then
                    Util.AdicionaJsAlert(Me.Page, "Empenho inexistente")
                    txtEmpenho.Text = ""
                End If

                'Verifica se o empenho de origem é relacionado ao estoque, se for valida o tipo da transferencia
                If txtEmpenho.ValueDecimal > 0 Then
                    If Me.empenhoEstaRelacionadoAEstoque(txtEmpenho.ValueDecimal) And cmbTipo.SelectedValue <> "1" Then
                        Util.AdicionaJsAlert(Me.Page, "Para empenho relacionado a estoque é permitido somente transferencia do tipo: '1 EMPENHO ORIGEM E 1 EMPENHO DESTINO'")
                        cmbTipo.SelectedValue = "1"
                        MostrarEsconderTabelasDeAcordoComTipoEscolhido()
                    End If
                End If

                'Bloqueia os campos Empenho de Destino caso o empenho de origem seja relacionado ao estoque
                If Me.empenhoEstaRelacionadoAEstoque(txtEmpenho.ValueDecimal) Then
                    Me.txtEmpenhoDS.Text = txtEmpenho.Text
                    Me.ddlEmpenhoDS.SelectedValue = Me.ddlEmpenhoOR.SelectedValue
                    Me.ddlEmpenhoDS.SelectedItem.Text = Me.ddlEmpenhoOR.SelectedItem.Text
                    Me.txtEmpenhoDS.Enabled = False
                    Me.ddlEmpenhoDS.Enabled = False
                Else
                    Me.txtEmpenhoDS.Text = String.Empty
                    Me.ddlEmpenhoDS.SelectedItem.Text = String.Empty
                    Me.txtEmpenhoDS.Enabled = True
                    Me.ddlEmpenhoDS.Enabled = True
                End If
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub txtEmpenhoDS_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtEmpenhoDS.ValueChange
        Try
            Dim flgEncontrou As Boolean = False
            Dim valorAntigo As String
            valorAntigo = ddlEmpenhoDS.SelectedValue
            If txtEmpenhoDS.Text <> getEmpenhoValue(ddlEmpenhoDS.SelectedItem).ToString Then
                For Each item As ListItem In ddlEmpenhoDS.Items
                    If item.Text.Length > 4 Then
                        If item.Text.Substring(0, 4) = txtEmpenhoDS.ValueDecimal.ToString("0000") Then
                            ddlEmpenhoDS.SelectedValue = item.Value
                            If valorAntigo <> ddlEmpenhoDS.SelectedValue Then
                                ddlEmpenhoDS_SelectedIndexChanged(sender, e)
                            End If
                            flgEncontrou = True
                            Exit For
                        End If
                    End If
                Next

                If Not flgEncontrou Then
                    Util.AdicionaJsAlert(Me.Page, "Empenho inexistente")
                    txtEmpenho.Text = ""
                End If

            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged
        MostrarEsconderTabelasDeAcordoComTipoEscolhido()
        Me.Limpa_Form()
    End Sub

    Private Sub grdOrigemN_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.UltraWebGrid.LayoutEventArgs) Handles grdOrigemN.InitializeLayout
        Try
            If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
                Exit Sub
            End If
            e.Layout.Bands(0).Columns(1).Header.Fixed = True
            e.Layout.Bands(0).Columns(2).Header.Fixed = True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub grdDestinoN_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.UltraWebGrid.LayoutEventArgs) Handles grdDestinoN.InitializeLayout
        Try
            If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
                Exit Sub
            End If
            e.Layout.Bands(0).Columns(1).Header.Fixed = True
            e.Layout.Bands(0).Columns(2).Header.Fixed = True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#Region " Metodos "

#Region " Métodos de Carga "

    Private Sub InicializaPagina()
        Try
            btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")

            If (Not Me.IsPostBack) Then
                ucFornecedorOR.widthNome = System.Web.UI.WebControls.Unit.Parse("285px")
                ucFornecedorDS.widthNome = System.Web.UI.WebControls.Unit.Parse("285px")
                Me.CargaInicialDados()
                MostrarEsconderTabelasDeAcordoComTipoEscolhido()
                FormataCabecalhogrdOrigemN()
            Else
                Me.RecuperaEstado()
            End If
            Page.RegisterStartupScript("Valor", "<script>window.MM_findObj('TbValorAtualizado').style.display = 'none';</script>")
            Controller.SetCurrentCulture()
            AtualizarValorTotalSeAOrigemForNEmpenhos()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub RecuperaEstado()
        If Not ViewState.Item(dsSelecaoValorDisponivelFornecedor.DataSetName) Is Nothing Then dsSelecaoValorDisponivelFornecedor = DirectCast(Me.ViewState.Item(dsSelecaoValorDisponivelFornecedor.DataSetName), wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor)
        If Not ViewState.Item(dsEmpenho.DataSetName) Is Nothing Then dsEmpenho = DirectCast(Me.ViewState.Item(dsEmpenho.DataSetName), wsAcoesComerciais.DatasetEmpenho)
    End Sub

    Private Sub SalvaEstado()
        If Not dsSelecaoValorDisponivelFornecedor Is Nothing Then Me.ViewState.Add(dsSelecaoValorDisponivelFornecedor.DataSetName, dsSelecaoValorDisponivelFornecedor)
        If Not dsEmpenho Is Nothing Then Me.ViewState.Add(dsEmpenho.DataSetName, dsEmpenho)
    End Sub

    Private Sub CargaInicialDados()
        ' CARREGA OS DADOS INICIAIS
        txtData.Value = Date.Now

        Try
            txtUsuario.Text = WSCAcoesComerciais.dsUsuarioCompra.T0113471.Item(0).NOMACSUSRSIS
        Catch ex As Exception
            Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471), consequentemente o sistema não vai permitir salvar esse registro.")
            btnSalvar.Enabled = False
            Exit Sub
        End Try

        Verifica_Relacao_Usuario_TipTransf()
        Me.CarregaDDLEmpenhos()

        'Obtem o tipo de lançamento
        If Not (Request.QueryString("x") Is Nothing) Then
            '
        Else
            ' NOVO REGISTRO
            'Me.InicializaNovoRegistro()
        End If

        ucFornecedorOR.SelecionarAposBusca = False
        ucFornecedorDS.SelecionarAposBusca = False
    End Sub

    Private Sub CarregaDDLEmpenhos()
        Dim drUsuarioCompra As wsAcoesComerciais.dataSetUsuarioCompra.T0113471Row = WSCAcoesComerciais.dsUsuarioCompra.T0113471.Item(0)
        Dim InsOri As Boolean = False
        Dim InsDsn As Boolean = False

        Me.InsOri = False        

        dsEmpenho = Controller.ObterEmpenhos(String.Empty, String.Empty, String.Empty, 0, String.Empty)

        For Each drEmpenho As wsAcoesComerciais.DatasetEmpenho.T0109059Row In dsEmpenho.T0109059.Select(String.Empty, "TIPDSNDSCBNF")

            InsDsn = False

            If drUsuarioCompra.TIPUSRSIS.Equals("X") Then
                AdicionarEmpenhoDestinoEmComboEmGrid(drEmpenho)
                Me.FlaDDLEmpenho(ddlEmpenhoDS.Items.FindByValue(drEmpenho.TIPDSNDSCBNF.ToString()), drEmpenho.FLGCTBDSNDSC)
            Else
                If (Not drEmpenho.IsNull("INDTRNDSNDSCBNF")) And (Not drEmpenho.IsNull("FLGCTBDSNDSC")) Then
                    If drEmpenho.INDTRNDSNDSCBNF <> 1 And drEmpenho.FLGCTBDSNDSC.ToUpper.Equals("S") Then
                        AdicionarEmpenhoDestinoEmComboEmGrid(drEmpenho)
                        Me.FlaDDLEmpenho(ddlEmpenhoDS.Items.FindByValue(drEmpenho.TIPDSNDSCBNF.ToString()), drEmpenho.FLGCTBDSNDSC)
                    End If
                End If
            End If

            'Se existe usuario na relacao tipo Transferencia
            'somente os empenhos da relacao sao inseridos no combo
            'a nao ser que o usuario seja diretor ou gerente
            'aí vale a regra normal, incluindo ainda o empenho da relacao
            If FlgExtUsr Then
                If (UCase(drUsuarioCompra.TIPUSRSIS) <> "X") And (UCase(drUsuarioCompra.TIPUSRSIS) <> "D") Then
                    If valida_Empenho(CInt(drEmpenho.TIPDSNDSCBNF)) Then
                        ddlEmpenhoOR.Items.Add(New ListItem(drEmpenho.TIPDSNDSCBNF.ToString("0000") & " - " & drEmpenho.DESDSNDSCBNF, drEmpenho.TIPDSNDSCBNF.ToString()))
                        AdicionarItemEmpenhosPermitidosNaOrigem(drEmpenho.TIPDSNDSCBNF)
                        Me.FlaDDLEmpenho(ddlEmpenhoOR.Items.FindByValue(drEmpenho.TIPDSNDSCBNF.ToString()), drEmpenho.FLGCTBDSNDSC)
                        InsOri = True
                    Else
                        InsOri = False
                    End If
                Else
                    Me.CarregaDDLEmpenhoDestino(drEmpenho, drUsuarioCompra)
                End If
            Else
                Me.CarregaDDLEmpenhoDestino(drEmpenho, drUsuarioCompra)
            End If

        Next

        Dim lstBlank As New ListItem
        lstBlank.Value = String.Empty
        lstBlank.Text = String.Empty

        ddlEmpenhoOR.Items.Insert(0, lstBlank)
        ddlEmpenhoDS.Items.Insert(0, lstBlank)
    End Sub

    Private Sub CarregaDDLEmpenhoDestino(ByRef drEmpenho As wsAcoesComerciais.DatasetEmpenho.T0109059Row, ByRef drUsuarioCompra As wsAcoesComerciais.dataSetUsuarioCompra.T0113471Row)
        'Se existe algum empenho na relacao
        'este so aparecera no combo para os usuarios
        'que estiverem relacionados ao tipo transf para este empenho
        ' existe_Empenho_Relacionado(CInt(SsLocaliza2("TipDsnDscBnf"))) And _
        '(UCase(linhaUsuarioLogado.TIPUSRSIS) <> "X")
        If Me.Existe_Empenho_Relacionado(drEmpenho.TIPDSNDSCBNF) And _
             drUsuarioCompra.TIPUSRSIS <> "X" Then
            InsOri = False
        Else
            If drEmpenho.TIPDSNDSCBNF.Equals(2) Or drEmpenho.TIPDSNDSCBNF.Equals(48) Or _
                drEmpenho.TIPDSNDSCBNF.Equals(49) Or drEmpenho.TIPDSNDSCBNF.Equals(24) Or _
                drEmpenho.TIPDSNDSCBNF.Equals(50) Or drEmpenho.TIPDSNDSCBNF.Equals(9) Or _
                drEmpenho.TIPDSNDSCBNF.Equals(51) Or drEmpenho.TIPDSNDSCBNF.Equals(8) Then
                If drUsuarioCompra.TIPUSRSIS.Equals("X") Then
                    ddlEmpenhoOR.Items.Add(New ListItem(drEmpenho.TIPDSNDSCBNF.ToString("0000") & " - " & drEmpenho.DESDSNDSCBNF, drEmpenho.TIPDSNDSCBNF.ToString()))
                    Me.FlaDDLEmpenho(ddlEmpenhoOR.Items.FindByValue(drEmpenho.TIPDSNDSCBNF.ToString()), drEmpenho.FLGCTBDSNDSC)
                    AdicionarItemEmpenhosPermitidosNaOrigem(drEmpenho.TIPDSNDSCBNF)
                    InsOri = True
                Else
                    InsOri = False
                End If
            Else
                Dim INDTRNDSNDSCBNF As Decimal
                If Not drEmpenho.IsNull("INDTRNDSNDSCBNF") Then
                    INDTRNDSNDSCBNF = drEmpenho.INDTRNDSNDSCBNF
                End If
                If INDTRNDSNDSCBNF = 1 Then
                    If drUsuarioCompra.TIPUSRSIS.Equals("X") Or drUsuarioCompra.TIPUSRSIS.Equals("D") Then
                        ddlEmpenhoOR.Items.Add(New ListItem(drEmpenho.TIPDSNDSCBNF.ToString("0000") & " - " & drEmpenho.DESDSNDSCBNF, drEmpenho.TIPDSNDSCBNF.ToString()))
                        Me.FlaDDLEmpenho(ddlEmpenhoOR.Items.FindByValue(drEmpenho.TIPDSNDSCBNF.ToString()), drEmpenho.FLGCTBDSNDSC)
                        AdicionarItemEmpenhosPermitidosNaOrigem(drEmpenho.TIPDSNDSCBNF)
                        InsOri = True
                    Else
                        InsOri = False
                    End If
                Else
                    'Os Gerentes e Diretores podem apenar visualizar (Empenho Origem) empenhos não disponível
                    If drUsuarioCompra.TIPUSRSIS.Equals("X") Then
                        ddlEmpenhoOR.Items.Add(New ListItem(drEmpenho.TIPDSNDSCBNF.ToString("0000") & " - " & drEmpenho.DESDSNDSCBNF, drEmpenho.TIPDSNDSCBNF.ToString()))
                        Me.FlaDDLEmpenho(ddlEmpenhoOR.Items.FindByValue(drEmpenho.TIPDSNDSCBNF.ToString()), drEmpenho.FLGCTBDSNDSC)
                        AdicionarItemEmpenhosPermitidosNaOrigem(drEmpenho.TIPDSNDSCBNF)
                        InsOri = True
                    Else
                        If drEmpenho.FLGCTBDSNDSC.Equals("S") Then
                            ddlEmpenhoOR.Items.Add(New ListItem(drEmpenho.TIPDSNDSCBNF.ToString("0000") & " - " & drEmpenho.DESDSNDSCBNF, drEmpenho.TIPDSNDSCBNF.ToString()))
                            Me.FlaDDLEmpenho(ddlEmpenhoOR.Items.FindByValue(drEmpenho.TIPDSNDSCBNF.ToString()), drEmpenho.FLGCTBDSNDSC)
                            AdicionarItemEmpenhosPermitidosNaOrigem(drEmpenho.TIPDSNDSCBNF)
                        Else
                            InsOri = False
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub CarregaGridOrigemN()
        Try
            Dim DatRef As Date
            Dim CodFrn As Decimal
            Dim colEmpenhosPermitidos As Hashtable

            'Atribui valor as variaveis
            DatRef = Date.Today
            CodFrn = Me.ucfornecedorOrigemN.CodFornecedor
            dsSelecaoValorDisponivelFornecedor = Controller.ObterSaldoDisponivelFornecedorParaTodosEmpenhos(DatRef, CodFrn)
            colEmpenhosPermitidos = colEmpenhosPermitidosNaOrigem

            Dim linha As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedorRow
            For i As Integer = dsSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedor.Rows.Count - 1 To 0 Step -1
                linha = dsSelecaoValorDisponivelFornecedor.tbTransfenciaEmpenhosDoFornecedor(i)
                'Verifica se o empenho existe no arrayList de origem, se NÃO existir significa que o usuário
                'NÃO pode utilizar esse empenho na origem, nesse caso exclui a linha
                If (Not colEmpenhosPermitidos.ContainsKey(linha.CodigoEmpenho)) Or linha.SaldoDisponivel <= 0 Or linha.CodigoAlocacao = 2 Then
                    linha.Delete()
                ElseIf Me.empenhoEstaRelacionadoAEstoque(linha.CodigoEmpenho) Then
                    linha.Delete()
                End If
            Next

            Me.grdOrigemN.DataBind()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub AdicionarEmpenhoDestinoEmComboEmGrid(ByVal T0109059Row As wsAcoesComerciais.DatasetEmpenho.T0109059Row)
        Try
            'Adiciona a linha no Combo
            ddlEmpenhoDS.Items.Add(New ListItem(T0109059Row.TIPDSNDSCBNF.ToString("0000") & " - " & T0109059Row.DESDSNDSCBNF, T0109059Row.TIPDSNDSCBNF.ToString()))

            'Adiciona a linha no grid
            If Not Me.empenhoEstaRelacionadoAEstoque(T0109059Row.TIPDSNDSCBNF) Then
                Dim row As New Infragistics.WebUI.UltraWebGrid.UltraGridRow(True)
                row.Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
                row.Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
                row.Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
                row.Cells(0).Value = T0109059Row.TIPDSNDSCBNF
                row.Cells(1).Value = T0109059Row.DESDSNDSCBNF
                row.Cells(2).Value = Decimal.Zero
                grdDestinoN.Rows.Add(row)
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub AdicionarItemEmpenhosPermitidosNaOrigem(ByVal TIPDSNDSCBNF As Decimal)
        'Adiciona a linha no arrayList
        Dim colEmpenhosPermitidos As Hashtable
        colEmpenhosPermitidos = colEmpenhosPermitidosNaOrigem
        colEmpenhosPermitidos.Add(TIPDSNDSCBNF, TIPDSNDSCBNF)
        colEmpenhosPermitidosNaOrigem = colEmpenhosPermitidos
    End Sub

    Private Sub CarregaGridAlocacoes(Optional ByVal PageIndex As Integer = 0, Optional ByVal recarregaDS As Boolean = True)
        Try
            grdAlocacoes.Rows.Clear()

            If ucFornecedorOR.CodFornecedor <= 0 Or getEmpenhoValue(ddlEmpenhoOR.SelectedItem) <= 0 Then
                Exit Sub
            End If

            If recarregaDS Then dsSelecaoValorDisponivelFornecedor = Controller.ObterSelecaoValorDisponivelFornecedor(Date.Parse(txtData.Text), ucFornecedorOR.CodFornecedor, Me.getEmpenhoValue(ddlEmpenhoOR.SelectedItem))
            DataBindGrdAlocacoes()

            FlagAlocacaoOrigem = False
            'Varre as linhas do dataset para setar o valor da propriedade FlagAlocacaoOrigem
            For Each linha As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedorRow In dsSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedor
                If Not linha.IsTipAlcVbaFrnNull Then
                    If linha.TipAlcVbaFrn = 2 Then
                        FlagAlocacaoOrigem = True
                    End If
                End If
            Next
            'Dim row As New Infragistics.WebUI.UltraWebGrid.UltraGridRow(True)
            'row.Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
            'row.Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
            'row.Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
            'row.Cells(2).Value = "3 - CONTA CORRENTE"
            'row.Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
            'row.Cells(3).Value = String.Empty
            'row.Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
            'row.Cells(4).Value = String.Empty
            'row.Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
            'If dsSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedor.Item(0).IsVlrSldDspNull Then
            '    row.Cells(5).Value = 0 - Me.VlrSldDspAlcVbaFrnPmt
            'Else
            '    row.Cells(5).Value = dsSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedor.Item(0).VlrSldDsp - Me.VlrSldDspAlcVbaFrnPmt
            'End If
            'grdAlocacoes.Rows.Add(row)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub CarregaControlesValores()
        Dim iLnh As Integer
        Dim VlrSldDspAlcVbaFrnPmt As Decimal
        Dim dVlr As Decimal

        FlagAlocacaoOrigem = False
        'FlagAlocacaoDestino = False
        VlrSldDspAlcVbaFrnPmt = 0

        txtSaldoDisp.Value = Decimal.Zero
        txtSaldoEmp.Value = Decimal.Zero
        txtTotalAloc.Value = Decimal.Zero

        If ucFornecedorOR.CodFornecedor <= 0 Or getEmpenhoValue(ddlEmpenhoOR.SelectedItem) <= 0 Then
            Exit Sub
        End If

        VlrSldDsp = 0
        If Not dsSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedor.Rows.Count = 0 Then
            If Not dsSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedor(0).IsVlrSldDspNull Then
                VlrSldDsp = dsSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedor(0).VlrSldDsp
            End If
        End If

        For Each linha As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedorRow In dsSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedor
            If Not linha.IsDesAlcVbaFrnNull Then
                If Not linha.DesAlcVbaFrn.Equals(String.Empty) Then
                    If linha.TipAlcVbaFrn = 2 Then
                        FlagAlocacaoOrigem = True
                    End If
                    VlrSldDspAlcVbaFrnPmt = VlrSldDspAlcVbaFrnPmt + linha.VlrSldDspAlcVbaFrn
                End If
            End If
        Next

        txtSaldoEmp.Value = VlrSldDsp
        VlrSldDsp = VlrSldDsp - VlrSldDspAlcVbaFrnPmt
        txtTotalAloc.Value = VlrSldDspAlcVbaFrnPmt
        txtSaldoDisp.Value = VlrSldDsp

        dVlr = VlrSldDsp
        If ddlEmpenhoDS.SelectedIndex > 0 And Len(Trim(ddlEmpenhoDS.SelectedItem.Text)) > 0 Then
            If grdAlocacoes.Rows.Count > 0 Then
                If vCmbDsnDsnTipAlcVbaFrn > 0 Then
                    If VrfAlc(vCmbDsnDsnTipAlcVbaFrn) Then
                        dVlr = VlrSldDspAlcVbaFrn
                        'FlagAlocacaoDestino = True
                    End If
                End If
            End If
        End If
        txtSaldoDisp.Value = dVlr
    End Sub

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

#Region " Metodos de controle"

    Private Sub MostrarEsconderTabelasDeAcordoComTipoEscolhido()
        Select Case cmbTipo.SelectedValue
            Case "1" '1 EMPENHO ORIGEM E 1 EMPENHO DESTINO
                TbUmaOrigem.Visible = True
                TbMuitasOrigens.Visible = False
                TbUmDestino.Visible = True
                TbMuitosDestinos.Visible = False
                txtValor.ReadOnly = False
            Case "2" '1 EMPENHO ORIGEM E 'N' EMPENHOS DESTINO
                TbUmaOrigem.Visible = True
                TbMuitasOrigens.Visible = False
                TbUmDestino.Visible = False
                TbMuitosDestinos.Visible = True
                txtValor.ReadOnly = True
            Case "3" ''N' EMPENHOS DE ORIGEM E 1 EMPENHO DESTINO
                TbUmaOrigem.Visible = False
                TbMuitasOrigens.Visible = True
                TbUmDestino.Visible = True
                TbMuitosDestinos.Visible = False
                txtValor.ReadOnly = True
        End Select
        Util.AdicionaJsFocus(Me.Page, cmbTipo)
    End Sub

    Private Sub FormataCabecalhogrdOrigemN()
        ''Reposiciona as colunas
        With Me.grdOrigemN

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

            'Cria a coluna de agrupamento EMPENHO
            ch = New Infragistics.WebUI.UltraWebGrid.ColumnHeader(True)
            ch.Caption = "EMPENHO"
            ch.RowLayoutColumnInfo.OriginY = 0
            ch.RowLayoutColumnInfo.OriginX = 1
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
            ch.RowLayoutColumnInfo.OriginX = 4
            ch.RowLayoutColumnInfo.SpanX = 4
            ch.Style.HorizontalAlign = HorizontalAlign.Center
            ch.Style.Height = New System.Web.UI.WebControls.Unit(21, UnitType.Pixel)
            .DisplayLayout.Bands(0).HeaderLayout.Add(ch)

        End With
    End Sub

    Private Sub AtualizarValorTotalSeAOrigemForNEmpenhos()
        If cmbTipo.SelectedValue = "1" Then
            Exit Sub
        End If

        Dim Valor As Decimal = 0
        Dim SomaDeValor As Decimal = 0

        txtValor.ReadOnly = True

        Select Case cmbTipo.SelectedValue

            Case "2"
                For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdDestinoN.Rows
                    If IsNumeric(linha.GetCellValue(Me.grdDestinoN.Columns.FromKey("ValorTransferir"))) Then
                        Valor = CType(linha.GetCellValue(Me.grdDestinoN.Columns.FromKey("ValorTransferir")), Decimal)
                        SomaDeValor += Valor
                    End If
                Next

            Case "3"
                For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdOrigemN.Rows
                    If IsNumeric(linha.GetCellValue(Me.grdOrigemN.Columns.FromKey("ValorTransferir"))) Then
                        Valor = CType(linha.GetCellValue(Me.grdOrigemN.Columns.FromKey("ValorTransferir")), Decimal)
                        If (Valor / 100) = CType(linha.GetCellValue(Me.grdOrigemN.Columns.FromKey("SaldoDisponivel")), Decimal) Then
                            Valor = CType(linha.GetCellValue(Me.grdOrigemN.Columns.FromKey("SaldoDisponivel")), Decimal)
                            linha.Cells(7).Value = Valor
                        End If
                        SomaDeValor += Valor
                    End If
                Next

        End Select

        txtValor.ValueDecimal = SomaDeValor
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
    ''' 	[Valmir]	22/10/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function obterLinhaEmpenho(ByVal TIPDSNDSCBNF As Decimal) As wsAcoesComerciais.DatasetEmpenho.T0109059Row
        Return dsEmpenho.T0109059.FindByTIPDSNDSCBNF(TIPDSNDSCBNF)
    End Function

#End Region

#Region " Metodos de Regras de Negocio "

    Private Function Existe_Relacao_Usuario_TipTransf() As Boolean
        Dim result As Boolean = False
        Dim ds As wsAcoesComerciais.DatasetRelacaoTipoTransferenciaEmpenhoFornecedor

        ds = Controller.ObterRelacaoTipoTransferenciaEmpenhoFornecedor(1, txtUsuario.Text, Decimal.Zero)

        If ds.tbOperacao01.Rows.Count > 0 Then
            result = True
        End If

        Return result
    End Function

    Private Function Existe_Relacao_Empenho_Usuario_TipoTransf(ByVal TipDsnDscBnf As Decimal) As Boolean
        Dim result As Boolean = False
        Dim ds As wsAcoesComerciais.DatasetRelacaoTipoTransferenciaEmpenhoFornecedor

        ds = Controller.ObterRelacaoTipoTransferenciaEmpenhoFornecedor(2, txtUsuario.Text, TipDsnDscBnf)

        If ds.tbOperacao02.Rows.Count > 0 Then
            result = True
        End If

        Return result
    End Function

    Private Function Existe_Empenho_Relacionado(ByVal TipDsnDscBnf As Decimal) As Boolean
        Dim result As Boolean = False
        Dim ds As wsAcoesComerciais.DatasetRelacaoTipoTransferenciaEmpenhoFornecedor

        ds = Controller.ObterRelacaoTipoTransferenciaEmpenhoFornecedor(3, txtUsuario.Text, TipDsnDscBnf)

        If ds.tbOperacao03.Rows.Count > 0 Then
            result = True
        End If

        Return result
    End Function

    Private Sub FlaDDLEmpenho(ByRef lstItem As ListItem, ByVal FlgCtbDsnDsc As String)
        If FlgCtbDsnDsc.Equals("S") Then
            lstItem.Value = String.Concat(lstItem.Value, ";", "1")
        Else
            lstItem.Value = String.Concat(lstItem.Value, ";", "0")
        End If
    End Sub

    Private Function getEmpenhoValue(ByRef lstItem As ListItem) As Decimal
        Dim result As Decimal = 0

        If lstItem.Value.IndexOf(";") <> -1 Then
            result = Convert.ToDecimal(lstItem.Value.Split(";"c).GetValue(0))
        End If

        Return result
    End Function

    Private Function getEmpenhoFlag(ByRef lstItem As ListItem) As Decimal
        If lstItem.Value.IndexOf(";") <> -1 Then
            Return Convert.ToDecimal(lstItem.Value.Split(";"c).GetValue(1))
        Else
            Return Decimal.Zero
        End If
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
        VlrSldDspAlcVbaFrn = -1
        For Each dr As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedorRow In dsSelecaoValorDisponivelFornecedor.tbSelecaoValorDisponivelFornecedor.Rows
            If dr.TipAlcVbaFrn = lTipAlcVbaFrn Then
                VlrSldDspAlcVbaFrn = dr.VlrSldDspAlcVbaFrn
                Return True
            End If
        Next
    End Function

    'Private Function VrfAlc(ByVal lTipAlcVbaFrn As Integer) As Boolean
    '    Dim iCnt As Integer
    '    VlrSldDspAlcVbaFrn = -1
    '    VrfAlc = False

    '    With grdAlocacoes
    '        If .Rows.Count > 0 Then
    '            For iCnt = 1 To .Rows.Count
    '                If lTipAlcVbaFrn = Convert.ToDecimal(.DisplayLayout.Rows(iCnt).Cells(5).Value) Then
    '                    VlrSldDspAlcVbaFrn = Convert.ToDecimal(.DisplayLayout.Rows(iCnt).Cells(5).Value)
    '                    Return True
    '                End If
    '            Next iCnt
    '        End If
    '    End With
    '    Exit Function
    'End Function

    Private Function ValidaFornecedorSelecionado(ByRef uc As wucFornecedor) As Boolean
        If Not WSCAcoesComerciais.dsUsuarioCompra.T0113471.Item(0).TIPUSRSIS.Equals("X") Then
            If Not Controller.FornecedorPertenceCelulaAtendidaUsuario(uc.CodFornecedor(), txtUsuario.Text) Then
                Util.AdicionaJsAlert(Me.Page, "Fornecedor não pertencente à célula. Favor selecionar outro fornecedor. (2)")
                Util.AdicionaJsFocus(Me.Page, CType(uc.FindControl("txtCodigo"), WebControl), Util.tipoDeComponente.InfragisticsTxt)
                Me.Limpa_Form()
                'uc.SelecionarVazio()
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function

    Private Function getValorSelecionado() As Decimal
        getValorSelecionado = Convert.ToDecimal(grdAlocacoes.DisplayLayout.ActiveRow().Cells(5).Value)
    End Function

    'Verifica se usuario tem permissao para transferir verbas do empenho tipdsn
    Private Function permissao_Para_Transferir(ByVal TipDsn As Decimal) As Boolean
        Dim ds As wsAcoesComerciais.DatasetEmpenho
        ds = Controller.ObterEmpenho(TipDsn)

        If ds.T0109059.Rows.Count = 0 Then
            Return False
        End If

        If ds.T0109059(0).IsNull("IndTrnDsnDscBnf") Then
            Return False
        End If

        If ds.T0109059(0).INDTRNDSNDSCBNF = 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    ' Verifica se existe uma relacao empenho X usuario X tipo transferencia
    Private Function valida_Empenho(ByVal TipDsnDscBnf As Integer) As Boolean
        Dim ds As wsAcoesComerciais.DatasetTipoTransferenciaXUsuario
        Dim linhaUsuarioLogado As wsAcoesComerciais.dataSetUsuarioCompra.T0113471Row
        Dim result As Boolean = False

        Try
            linhaUsuarioLogado = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0)
        Catch ex As Exception
            Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
            Exit Function
        End Try

        ds = Controller.ObterTiposTransferenciasXUsuario(0, linhaUsuarioLogado.NOMACSUSRSIS)

        For Each linha As wsAcoesComerciais.DatasetTipoTransferenciaXUsuario.T0135092Row In ds.T0135092
            If linha.T0135033Row.TIPDSNDSCBNF = TipDsnDscBnf Then
                result = True
                Exit For
            End If
        Next

        Return result
    End Function

    'Public Function valida_Usuario(ByVal UsrSis As String, ByVal CodFrn As Decimal) As Boolean
    '    Return Controller.FornecedorPertenceCelulaAtendidaUsuario(CodFrn, UsrSis)
    'End Function

    Private Sub Limpa_Form()
        ucFornecedorOR.SelecionarVazio()
        ucFornecedorDS.SelecionarVazio()
        ucfornecedorOrigemN.SelecionarVazio()
        ddlEmpenhoOR.SelectedValue = String.Empty
        ddlEmpenhoDS.SelectedValue = String.Empty
        grdAlocacoes.Rows.Clear()
        grdOrigemN.Rows.Clear()
        txtHistorico.Text = ""
        txtValor.Text = ""
        txtSaldoDisp.Text = ""
        txtSaldoEmp.Text = ""
        txtEmpenho.Text = ""
        txtEmpenhoDS.Text = ""
        txtTotalAloc.Text = ""
        lblAlcVbaFrn.Text = ""

        'Limpa propriedades
        VlrSldDspAlcVbaFrnPmt = 0
        VlrSldDspAlcVbaFrn = 0
        FlagAlocacaoOrigem = False
        FlgExtUsr = False
        bEmpTransf = False
        VlrSldDsp = 0
        InsOri = False

        'Limpar valores do grid de origem
        For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdDestinoN.Rows
            linha.Cells(2).Value = 0
        Next

        'Limpar valores do grid de destino
        For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdOrigemN.Rows
            linha.Cells(7).Value = 0
        Next

    End Sub

    Private Sub Verifica_Relacao_Usuario_TipTransf()
        Dim ds As wsAcoesComerciais.DatasetRelacaoTipoTransferenciaEmpenhoFornecedor
        Dim linhaUsuarioLogado As wsAcoesComerciais.dataSetUsuarioCompra.T0113471Row

        'Pega o usuário logado ao sistema
        Try
            linhaUsuarioLogado = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0)
        Catch ex As Exception
            Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
            Exit Sub
        End Try

        ds = Controller.ObterRelacaoTipoTransferenciaEmpenhoFornecedor(1, linhaUsuarioLogado.NOMACSUSRSIS, 0)

        If ds.tbOperacao01.Rows.Count = 0 Then
            FlgExtUsr = False
        Else
            If ds.tbOperacao01(0).IsNull(0) Then
                FlgExtUsr = False
            Else
                FlgExtUsr = True
            End If
        End If
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
    ''' 	[Valmir]	22/10/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function empenhoEstaRelacionadoAEstoque(ByVal TIPDSNDSCBNF As Decimal) As Boolean
        Dim T0109059Row As wsAcoesComerciais.DatasetEmpenho.T0109059Row
        T0109059Row = Me.obterLinhaEmpenho(txtEmpenho.ValueDecimal)
        If Not T0109059Row Is Nothing Then
            If T0109059Row.INDTIPDSNRCTCSTMER = 1 Then 'Está relacionado ao estoque = 1
                Return True
            End If
        End If
        Return False
    End Function

#Region "Transferencia"

#Region "UmaOrigemParaUmDestino"

    Private Sub AtualizarUmaOrigemParaUmDestino()

        If flagProcessando Then
            Exit Sub
        End If

        Try
            Dim dsDiretoriaEDivisaoDeCompraDeFornecedor As wsAcoesComerciais.DatasetDiretoriaEDivisaoDeCompraDeFornecedor
            Dim linhaUsuarioLogado As wsAcoesComerciais.dataSetUsuarioCompra.T0113471Row
            Dim ContDsn As Integer = ddlEmpenhoDS.SelectedIndex
            Dim ContOrg As Integer = ddlEmpenhoOR.SelectedIndex

            flagProcessando = True

            Try
                linhaUsuarioLogado = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0)
            Catch ex As Exception
                Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
                flagProcessando = False
                Exit Sub
            End Try

            If Me.ValidarTransferenciaUmaOrigemParaUmDestino() Then
                If linhaUsuarioLogado.TIPUSRSIS = "X" Then
                    Me.TransferirValoreEntreEmpenhosFornecedorUmaOrigemParaUmDestino()
                    Exit Sub
                Else
                    'Alteração solicitada por Severton em 17/01/2007
                    'Antes não exitia o If abaixo, onde está ElseIf (vCmbDsnDsnTipAlcVbaFrnOri <> 2) And (FlagAlocacaoOrigem = False) Then
                    'exitia If (vCmbDsnDsnTipAlcVbaFrnOri <> 2) And (FlagAlocacaoOrigem = False) Then
                    If FlagAlocacaoOrigem = True And (FlagAlocacaoDestino = False) Then
                        Me.TransferirValoreEntreEmpenhosFornecedorUmaOrigemParaUmDestino()
                    ElseIf (vCmbDsnDsnTipAlcVbaFrnOri <> 2) And (FlagAlocacaoOrigem = False) Then
                        TransferenciaRegraAnteriorUmaOrigemParaUmDestino(ContOrg, ContDsn)
                    Else
                        'Obtem da procedure: MRT.PCTDJObtDrtCmpFrn.PRCDJObtDrtCmpFrn
                        dsDiretoriaEDivisaoDeCompraDeFornecedor = Controller.ObterDiretoriaEDivisaoDeCompraDeFornecedor(ucFornecedorDS.CodFornecedor)

                        If vCmbDsnDsnTipAlcVbaFrnOri = 2 Then
                            If Not dsDiretoriaEDivisaoDeCompraDeFornecedor.TbDiretoriaEDivisaoDeCompraDeFornecedor.Rows.Count = 0 Then
                                Util.AdicionaJsAlert(Me.Page, "Transferência não permitida para fornecedor deste BU !! (1)")
                            Else
                                If vCmbDsnDsnTipAlcVbaFrn = 2 Then
                                    Me.TransferirValoreEntreEmpenhosFornecedorUmaOrigemParaUmDestino()
                                Else
                                    Util.AdicionaJsAlert(Me.Page, "Só é permitida transferência para empenho destino de Marketing !! ")
                                End If
                            End If
                        ElseIf (FlagAlocacaoOrigem = True) Then
                            If Not dsDiretoriaEDivisaoDeCompraDeFornecedor.TbDiretoriaEDivisaoDeCompraDeFornecedor.Rows.Count = 0 Then
                                If vCmbDsnDsnTipAlcVbaFrn <> 1 And _
                                   vCmbDsnDsnTipAlcVbaFrn <> 2 Then
                                    Me.TransferirValoreEntreEmpenhosFornecedorUmaOrigemParaUmDestino()
                                Else
                                    Util.AdicionaJsAlert(Me.Page, "Transferência não permitida para fornecedor deste BU !! (2)")
                                End If
                            Else
                                Me.TransferirValoreEntreEmpenhosFornecedorUmaOrigemParaUmDestino()
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        Finally
            flagProcessando = False
        End Try
    End Sub

    Private Sub TransferenciaRegraAnteriorUmaOrigemParaUmDestino(ByVal ContOrg As Integer, ByVal ContDsn As Integer)
        Dim linhaUsuarioLogado As wsAcoesComerciais.dataSetUsuarioCompra.T0113471Row
        Dim strMsg As String
        Dim bPermissaoTransferencia As Boolean = False

        Try
            linhaUsuarioLogado = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0)
        Catch ex As Exception
            Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
            Util.AdicionaJsFocus(Me.Page, CType(ddl1, System.web.UI.WebControls.WebControl))
            Exit Sub
        End Try

        If ucFornecedorOR.CodFornecedor <> ucFornecedorDS.CodFornecedor Then
            'If Me.getEmpenhoValue(ddlEmpenhoOR.SelectedItem) > 0 Then
            If Not FlgExtUsr Then bPermissaoTransferencia = permissao_Para_Transferir(Me.getEmpenhoValue(ddlEmpenhoOR.SelectedItem))
            bEmpTransf = valida_Empenho(CInt(Me.getEmpenhoValue(ddlEmpenhoOR.SelectedItem)))
            'If linhaUsuarioLogado.
            If (UCase(linhaUsuarioLogado.TIPUSRSIS) = "X") Or _
               ((UCase(linhaUsuarioLogado.TIPUSRSIS) = "D") And bPermissaoTransferencia) Or _
               (FlgExtUsr And bEmpTransf) Then
                'transfere
                Me.TransferirValoreEntreEmpenhosFornecedorUmaOrigemParaUmDestino()
            Else
                If (UCase(linhaUsuarioLogado.TIPUSRSIS) = "D") Then
                    Util.AdicionaJsAlert(Me.Page, "Você não tem permissão para transferir verbas do empenho: " & ddlEmpenhoOR.SelectedItem.Text & " para outro fornecedor.")
                Else
                    Util.AdicionaJsAlert(Me.Page, "Não foi possível realizar a transferência .Usuário sem acesso.")
                End If
            End If
        ElseIf Me.getEmpenhoValue(ddlEmpenhoDS.Items(ContDsn)) = 0 Or Me.getEmpenhoValue(ddlEmpenhoOR.Items(ContOrg)) = 0 Then
            If UCase(linhaUsuarioLogado.TIPUSRSIS) = "X" Then
                'transfere
                Me.TransferirValoreEntreEmpenhosFornecedorUmaOrigemParaUmDestino()
            Else
                Util.AdicionaJsAlert(Me.Page, "Não foi possível realizar a transferência.")
            End If
        ElseIf txtSaldoDisp.ValueDecimal >= txtValor.ValueDecimal Then
            'If Util.AdicionaJsAlert(Me.Page, "Confirma Transferência ?", vbYesNo + vbQuestion, "Transferência") = vbYes Then
            If Me.getEmpenhoValue(ddlEmpenhoOR.SelectedItem) <> Me.getEmpenhoValue(ddlEmpenhoDS.SelectedItem) Then
                Me.TransferirValoreEntreEmpenhosFornecedorUmaOrigemParaUmDestino()
            Else
                Util.AdicionaJsAlert(Me.Page, "Empenhos de Origem e Destino devem ser Diferentes")
            End If
            'End If
        Else
            Util.AdicionaJsAlert(Me.Page, "Não foi possível a transferência.Saldo Insuficiente.")
        End If

    End Sub

    Private Function ValidarTransferenciaUmaOrigemParaUmDestino() As Boolean
        Dim ImportadoOR As Boolean = False
        Dim MexOR As Boolean = False
        Dim ImportadoDS As Boolean = False
        Dim MexDS As Boolean = False
        Dim linhaUsuarioLogado As wsAcoesComerciais.dataSetUsuarioCompra.T0113471Row
        Try
            linhaUsuarioLogado = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0)
        Catch ex As Exception
            Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
            Exit Function
        End Try

        'Por segurança, para o caso so usuário escolher a opção voltar do 
        'navegador, o sistema recalcula os valores, porque caso contrário
        'ele poderia trabalhar com valor da tela anterior
        CarregaControlesValores()

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
            If grdAlocacoes.DisplayLayout.Rows.Count >= 1 Then
                grdAlocacoes.DisplayLayout.Rows(0).Activate()
            End If
        End If
        If Not ValidaFornecedorSelecionado(ucFornecedorOR) Then
            Return False
        End If
        If txtEmpenho.ValueDecimal <> getEmpenhoValue(ddlEmpenhoOR.SelectedItem) Then
            Util.AdicionaJsAlert(Me.Page, "Campo texto do empenho de origem é diferente do selecionado no combo")
            Util.AdicionaJsFocus(Me.Page, CType(txtEmpenho, WebControl))
            Return False
        End If

        If Not linhaEmpenhoOrigem.IsTIPALCVBAFRNNull Then
            If Convert.ToInt32(linhaEmpenhoOrigem.TIPALCVBAFRN) = 2 Then
                Util.AdicionaJsAlert(Me.Page, "Empenho de origem Marketing não permite transferência")
                Util.AdicionaJsFocus(Me.Page, CType(ddl2, WebControl))
                Return False
            End If
        End If

        If Not linhaEmpenhoOrigem.IsTIPALCVBAFRNNull Then
            If Convert.ToInt32(linhaEmpenhoOrigem.TIPALCVBAFRN) = 4 Then
                Util.AdicionaJsAlert(Me.Page, "Empenho Desoneração AGF não permite transferência")
                Util.AdicionaJsFocus(Me.Page, CType(ddl2, WebControl))
                Return False
            End If
        End If

        If Not linhaEmpenhoOrigem.IsTIPALCVBAFRNNull Then
            If Convert.ToInt32(linhaEmpenhoOrigem.TIPALCVBAFRN) = 5 Then
                Util.AdicionaJsAlert(Me.Page, "Empenho Resultado AGF não permite transferência")
                Util.AdicionaJsFocus(Me.Page, CType(ddl2, WebControl))
                Return False
            End If
        End If

        'Verifica se o empenho de origem é relacionado ao estoque, se for valida o tipo da transferencia
        If Me.empenhoEstaRelacionadoAEstoque(txtEmpenho.ValueDecimal) Then
            If cmbTipo.SelectedValue <> "1" Then
                Util.AdicionaJsAlert(Me.Page, "Para empenho relacionado a estoque é permitido somente transferencia do tipo: '1 EMPENHO ORIGEM E 1 EMPENHO DESTINO'")
                Return False
            End If
            If ucFornecedorOR.CodFornecedor = ucFornecedorDS.CodFornecedor And txtEmpenho.ValueDecimal <> txtEmpenhoDS.ValueDecimal Then
                Util.AdicionaJsAlert(Me.Page, "Para transferência com empenho de origem relacionado ao estoque e para o mesmo fornecedor, o empenho de destino não pode ser diferente do de origem.")
                Return False
            End If

            Controller.ValidaSeFornecedorDeOrigemEDeDestinoEMexEImportado(ucFornecedorOR.CodFornecedor, ucFornecedorDS.CodFornecedor)

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
        If txtValor.ValueDecimal <= 0 Then
            Util.AdicionaJsAlert(Me.Page, "O Valor a ser transferido é Inválido! ")
            Util.AdicionaJsFocus(Me.Page, CType(txtValor, WebControl), Util.tipoDeComponente.InfragisticsTxt)
            Return False
        End If
        If Not ValidaFornecedorSelecionado(ucFornecedorDS) Then
            Return False
        End If
        If txtEmpenhoDS.ValueDecimal <> getEmpenhoValue(ddlEmpenhoDS.SelectedItem) Then
            Util.AdicionaJsAlert(Me.Page, "Campo texto do empenho de destino é diferente do selecionado no combo")
            Util.AdicionaJsFocus(Me.Page, CType(txtEmpenhoDS, WebControl))
            Return False
        End If
        If txtHistorico.Text.Trim.Length = 0 Then
            Util.AdicionaJsAlert(Me.Page, "É obrigatório digitar o histórico ! ")
            Util.AdicionaJsFocus(Me.Page, CType(txtHistorico, WebControl))
            Return False
        End If

        'Adicionado em 16/05/2007, solicitação Elisangela
        If ucFornecedorOR.CodFornecedor = ucFornecedorDS.CodFornecedor And _
           ddlEmpenhoOR.SelectedValue = ddlEmpenhoDS.SelectedValue Then
            Util.AdicionaJsAlert(Me.Page, "Não é permitido fornecedor e empenho iguais para origem e destino")
            Util.AdicionaJsFocus(Me.Page, CType(ucFornecedorDS.FindControl("txtCodigo"), WebControl))
            Return False
        End If

        'Regra adiciona por solicitação do Severton em 18/01/2007
        If linhaUsuarioLogado.TIPUSRSIS <> "X" Then
            If ucFornecedorOR.CodFornecedor <> ucFornecedorDS.CodFornecedor Then
                Util.AdicionaJsAlert(Me.Page, "Não é permitido transferência entre fornecedores diferentes! ")
            End If
        End If

        Dim dVlr As Decimal = VlrSldDsp
        If grdAlocacoes.Rows.Count > 0 Then
            If vCmbDsnDsnTipAlcVbaFrn > 0 Then
                If Not VrfAlc(vCmbDsnDsnTipAlcVbaFrn) Then
                    Util.AdicionaJsAlert(Me.Page, "Não existe alocação para o Empenho [Destino]! ")
                    Util.AdicionaJsFocus(Me.Page, CType(ddlEmpenhoDS, WebControl), Util.tipoDeComponente.Outros)
                    Return False
                Else
                    dVlr = VlrSldDspAlcVbaFrn
                End If
            End If
        End If
        txtSaldoDisp.Value = dVlr

        'Verifica se o empenho de origem é relacionado ao estoque, se for valida o tipo da transferencia        
        If Me.empenhoEstaRelacionadoAEstoque(txtEmpenho.ValueDecimal) Then
            If cmbTipo.SelectedValue <> "1" Then
                Util.AdicionaJsAlert(Me.Page, "Para empenho relacionado a estoque é permitido somente transferencia do tipo: '1 EMPENHO DSIGEM E 1 EMPENHO DESTINO'")
                Return False
            End If

            If ucFornecedorOR.CodFornecedor = ucFornecedorDS.CodFornecedor And txtEmpenho.ValueDecimal <> txtEmpenhoDS.ValueDecimal Then
                Util.AdicionaJsAlert(Me.Page, "Para transferência com empenho de origem relacionado ao estoque e para o mesmo fornecedor, o empenho de destino não pode ser diferente do de origem.")
                Return False
            End If

            Controller.ValidaSeFornecedorDeOrigemEDeDestinoEMexEImportado(ucFornecedorOR.CodFornecedor, ucFornecedorDS.CodFornecedor)

        End If
        Return True
    End Function

    Private Sub TransferirValoreEntreEmpenhosFornecedorUmaOrigemParaUmDestino()

        If flagProcessandoTransferencia Then
            Exit Sub
        End If

        If txtValor.ValueDecimal <= Me.txtSaldoDisp.ValueDecimal Then

            Dim TipAlcVbaFrnDstPmtDdoOrigem As Integer
            TipAlcVbaFrnDstPmtDdoOrigem = vCmbDsnDsnTipAlcVbaFrn

            Dim pTipAlcVbaFrn As Integer = 0
            Try
                If Not grdAlocacoes.DisplayLayout.ActiveRow().Cells(3).Value Is Nothing Then
                    pTipAlcVbaFrn = Convert.ToInt32(grdAlocacoes.DisplayLayout.ActiveRow().Cells(3).Value)
                End If
            Catch ex As Exception
            End Try

            Try
                flagProcessandoTransferencia = True
                Util.gravaInformacaoEventView("Transferência compras iniciada")
                Controller.TransferirValoreEntreEmpenhosFornecedorGAC(txtValor.ValueDecimal, _
                                                     pTipAlcVbaFrn, _
                                                     txtData.Date, _
                                                     Me.getEmpenhoValue(ddlEmpenhoOR.SelectedItem), _
                                                     Me.getEmpenhoValue(ddlEmpenhoDS.SelectedItem), _
                                                     ucFornecedorOR.CodFornecedor, _
                                                     ucFornecedorDS.CodFornecedor, _
                                                     txtValor.ValueDecimal, _
                                                     txtHistorico.Text, _
                                                     "Transf. p/ " & ddlEmpenhoDS.SelectedItem.Text.Trim().Split("-"c)(1).Trim() & " - " & ucFornecedorDS.NomFornecedor.Trim().Split("-"c)(1).Trim(), _
                                                     "Transf. de " & ddlEmpenhoOR.SelectedItem.Text.Split("-"c)(1).Trim() & " - " & ucFornecedorOR.NomFornecedor.Split("-"c)(1).Trim(), _
                                                     txtUsuario.Text.Trim(), _
                                                     TipAlcVbaFrnDstPmtDdoOrigem, _
                                                     0)

            Catch ex As Exception
                Util.gravaInformacaoEventView("Transferência compras concluída com erro")
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
            Util.gravaInformacaoEventView("Transferência compras concluída com sucesso")
        Else
            Util.AdicionaJsAlert(Me.Page, "Não foi possível a transferência. Saldo Insuficiente.")
            Util.AdicionaJsFocus(Me.Page, CType(ddl2, System.web.UI.WebControls.WebControl))
        End If
    End Sub

#End Region

#Region "UmaOrigemParaNDestinos"

    Private Sub AtualizarUmaOrigemParaNDestinos()
        Try
            Dim dsDiretoriaEDivisaoDeCompraDeFornecedor As wsAcoesComerciais.DatasetDiretoriaEDivisaoDeCompraDeFornecedor
            Dim linhaUsuarioLogado As wsAcoesComerciais.dataSetUsuarioCompra.T0113471Row
            Dim ContDsn As Integer = ddlEmpenhoDS.SelectedIndex
            Dim ContOrg As Integer = ddlEmpenhoOR.SelectedIndex

            flagProcessando = True

            Try
                linhaUsuarioLogado = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0)
            Catch ex As Exception
                Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
                flagProcessando = False
                Exit Sub
            End Try

            If Me.ValidarTransferenciaUmaOrigemParaNDestinos() Then
                Me.TransferirValoreEntreEmpenhosFornecedorUmaOrigemParaNDestinos(linhaUsuarioLogado)
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        Finally
            flagProcessando = False
        End Try
    End Sub

    Private Function ValidarTransferenciaUmaOrigemParaNDestinos() As Boolean
        Dim linhaUsuarioLogado As wsAcoesComerciais.dataSetUsuarioCompra.T0113471Row
        Try
            linhaUsuarioLogado = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0)
        Catch ex As Exception
            Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
            Exit Function
        End Try

        'Por segurança, para o caso so usuário escolher a opção voltar do 
        'navegador, o sistema recalcula os valores, porque caso contrário
        'ele poderia trabalhar com valor da tela anterior
        CarregaControlesValores()

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
            If grdAlocacoes.DisplayLayout.Rows.Count >= 1 Then
                grdAlocacoes.DisplayLayout.Rows(0).Activate()
            End If
        End If
        If Not ValidaFornecedorSelecionado(ucFornecedorOR) Then
            Return False
        End If
        If txtEmpenho.ValueDecimal <> getEmpenhoValue(ddlEmpenhoOR.SelectedItem) Then
            Util.AdicionaJsAlert(Me.Page, "Campo texto do empenho de origem é diferente do selecionado no combo")
            Util.AdicionaJsFocus(Me.Page, CType(txtEmpenho, WebControl))
            Return False
        End If

        If Not linhaEmpenhoOrigem.IsTIPALCVBAFRNNull Then
            If Convert.ToInt32(linhaEmpenhoOrigem.TIPALCVBAFRN) = 2 Then
                Util.AdicionaJsAlert(Me.Page, "Empenho de origem Marketing não permite transferência")
                Util.AdicionaJsFocus(Me.Page, CType(ddl2, WebControl))
                Return False
            End If
        End If

        If Not linhaEmpenhoOrigem.IsTIPALCVBAFRNNull Then
            If Convert.ToInt32(linhaEmpenhoOrigem.TIPALCVBAFRN) = 4 Then
                Util.AdicionaJsAlert(Me.Page, "Empenho Desoneração AGF não permite transferência")
                Util.AdicionaJsFocus(Me.Page, CType(ddl2, WebControl))
                Return False
            End If
        End If

        If Not linhaEmpenhoOrigem.IsTIPALCVBAFRNNull Then
            If Convert.ToInt32(linhaEmpenhoOrigem.TIPALCVBAFRN) = 5 Then
                Util.AdicionaJsAlert(Me.Page, "Empenho Resultado AGF não permite transferência")
                Util.AdicionaJsFocus(Me.Page, CType(ddl2, WebControl))
                Return False
            End If
        End If
        If Me.empenhoEstaRelacionadoAEstoque(txtEmpenho.ValueDecimal) Then
            Util.AdicionaJsAlert(Me.Page, "Não é permitida transferência para N Destinos quando o empenho de origem está relacionado ao estoque")
            Util.AdicionaJsFocus(Me.Page, CType(txtEmpenho, WebControl))
            Return False
        End If

        '----------------------------DESTINO---------------------------
        If txtValor.ValueDecimal <= 0 Then
            Util.AdicionaJsAlert(Me.Page, "O Valor a ser transferido é Inválido! ")
            Util.AdicionaJsFocus(Me.Page, CType(txtValor, WebControl), Util.tipoDeComponente.InfragisticsTxt)
            Return False
        End If
        If txtHistorico.Text.Trim.Length = 0 Then
            Util.AdicionaJsAlert(Me.Page, "É obrigatório digitar o histórico ! ")
            Util.AdicionaJsFocus(Me.Page, CType(txtHistorico, WebControl))
            Return False
        End If

        Return True
    End Function

    Private Sub TransferirValoreEntreEmpenhosFornecedorUmaOrigemParaNDestinos(ByVal linhaUsuarioLogado As wsAcoesComerciais.dataSetUsuarioCompra.T0113471Row)

        If flagProcessandoTransferencia Then
            Exit Sub
        End If

        Dim dsTransferenciaVerbaFornecedor As New wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor

        If txtValor.ValueDecimal <= Me.txtSaldoDisp.ValueDecimal Then

            'Consulta o empenho de Origem
            Dim linhaEmpenhoOrigem As wsAcoesComerciais.DatasetEmpenho.T0109059Row
            linhaEmpenhoOrigem = dsEmpenho.T0109059.FindByTIPDSNDSCBNF(Me.getEmpenhoValue(ddlEmpenhoOR.SelectedItem))
            If linhaEmpenhoOrigem Is Nothing Then
                Util.AdicionaJsAlert(Me.Page, "Empenho não encontrado")
                Exit Sub
            End If

            Dim TipAlcVbaFrnDstPmtDdoOrigem As Integer = 0
            If Not linhaEmpenhoOrigem.IsTIPALCVBAFRNNull Then
                TipAlcVbaFrnDstPmtDdoOrigem = Convert.ToInt32(linhaEmpenhoOrigem.TIPALCVBAFRN)
            End If

            Dim pTipAlcVbaFrn As Integer = 0
            Try
                If Not grdAlocacoes.DisplayLayout.ActiveRow().Cells(3).Value Is Nothing Then
                    pTipAlcVbaFrn = Convert.ToInt32(grdAlocacoes.DisplayLayout.ActiveRow().Cells(3).Value)
                End If
            Catch ex As Exception
            End Try

            flagProcessandoTransferencia = True

            Try
                For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdDestinoN.Rows
                    If IsNumeric(linha.GetCellValue(Me.grdDestinoN.Columns.FromKey("ValorTransferir"))) Then

                        Dim ValorTransferir As Decimal
                        ValorTransferir = CType(linha.GetCellValue(Me.grdDestinoN.Columns.FromKey("ValorTransferir")), Decimal)

                        If ValorTransferir > 0 Then

                            Dim TipDsnDscBnfDestino As Decimal
                            Dim DesDsnDscBnf As String

                            TipDsnDscBnfDestino = CType(linha.GetCellValue(Me.grdDestinoN.Columns.FromKey("TIPDSNDSCBNF")), Decimal)
                            DesDsnDscBnf = CType(linha.GetCellValue(Me.grdDestinoN.Columns.FromKey("DESDSNDSCBNF")), String)

                            Dim ParametrosTransferenciaRow As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor.ParametrosTransferenciaRow
                            ParametrosTransferenciaRow = dsTransferenciaVerbaFornecedor.ParametrosTransferencia.NewParametrosTransferenciaRow

                            With ParametrosTransferenciaRow
                                .Valor = ValorTransferir
                                .TipAlcVbaFrn = pTipAlcVbaFrn
                                .DatRefLmt = txtData.Date
                                .TipDsnDscBnfOrigem = Me.getEmpenhoValue(ddlEmpenhoOR.SelectedItem)
                                .TipDsnDscBnfDestino = TipDsnDscBnfDestino
                                .CodFrnOrigem = ucFornecedorOR.CodFornecedor
                                .CodFrnDestino = ucFornecedorOR.CodFornecedor
                                .VlrLmtCtb = ValorTransferir
                                .DesHstLmt = txtHistorico.Text
                                .DesVarHstPadOrigem = "Transf. p/ " & DesDsnDscBnf.Trim() & " - " & ucFornecedorOR.NomFornecedor.Split("-"c)(1).Trim()
                                .DesVarHstPadDestino = "Transf. de " & ddlEmpenhoOR.SelectedItem.Text.Split("-"c)(1).Trim() & " - " & ucFornecedorOR.NomFornecedor.Split("-"c)(1).Trim()
                                .NomAcsUsrGrcLmt = txtUsuario.Text.Trim()
                                .TipAlcVbaFrnPmtOrigem = TipAlcVbaFrnDstPmtDdoOrigem
                                .TipAlcVbaFrnPmtDestino = 0
                                .SaldoDisponivel = Me.txtSaldoDisp.ValueDecimal
                            End With

                            dsTransferenciaVerbaFornecedor.ParametrosTransferencia.AddParametrosTransferenciaRow(ParametrosTransferenciaRow)
                        End If
                    End If
                Next
                Controller.AtualizarTransferencia(linhaUsuarioLogado.NOMACSUSRSIS, linhaUsuarioLogado.TIPUSRSIS, dsTransferenciaVerbaFornecedor)
            Catch ex As Exception
                Util.gravaInformacaoEventView("Transferência compras concluída com erro")
                Throw ex
            Finally
                flagProcessandoTransferencia = False
            End Try

            Util.AdicionaJsAlert(Me.Page, "Transferência Concluída." & vbCrLf & _
                                          "Origem : " & ucFornecedorOR.NomFornecedor & vbCrLf & _
                                          "Empenho : " & ddlEmpenhoOR.SelectedItem.Text & vbCrLf & _
                                          "Valor : " & txtValor.ValueDecimal & vbCrLf & _
                                          "Destino : " & ucFornecedorOR.NomFornecedor & vbCrLf & _
                                          "Empenho : " & ddlEmpenhoDS.SelectedItem.Text)
            Limpa_Form()
            Util.AdicionaJsFocus(Me.Page, CType(ddl1, System.web.UI.WebControls.WebControl))
            Util.gravaInformacaoEventView("Transferência compras concluída com sucesso")
        Else
            Util.AdicionaJsAlert(Me.Page, "Não foi possível a transferência. Saldo Insuficiente.")
            Util.AdicionaJsFocus(Me.Page, CType(ddl2, System.web.UI.WebControls.WebControl))
        End If
    End Sub

#End Region

#Region "NOrigensParaUmDestino"

    Private Sub AtualizarNOrigensParaUmDestino()

        If flagProcessando Then
            Exit Sub
        End If

        Try
            Dim dsDiretoriaEDivisaoDeCompraDeFornecedor As wsAcoesComerciais.DatasetDiretoriaEDivisaoDeCompraDeFornecedor
            Dim linhaUsuarioLogado As wsAcoesComerciais.dataSetUsuarioCompra.T0113471Row
            Dim ContDsn As Integer = ddlEmpenhoDS.SelectedIndex
            Dim ContOrg As Integer = ddlEmpenhoOR.SelectedIndex

            flagProcessando = True

            Try
                linhaUsuarioLogado = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0)
            Catch ex As Exception
                Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
                flagProcessando = False
                Exit Sub
            End Try

            If Me.ValidarTransferenciaNOrigensParaUmDestino() Then
                Me.TransferirValoreEntreEmpenhosFornecedorNOrigensParaUmDestino()
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        Finally
            flagProcessando = False
        End Try
    End Sub

    Private Function ValidarTransferenciaNOrigensParaUmDestino() As Boolean
        Dim linhaUsuarioLogado As wsAcoesComerciais.dataSetUsuarioCompra.T0113471Row
        Try
            linhaUsuarioLogado = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0)
        Catch ex As Exception
            Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
            Exit Function
        End Try

        'Por segurança, para o caso so usuário escolher a opção voltar do 
        'navegador, o sistema recalcula os valores, porque caso contrário
        'ele poderia trabalhar com valor da tela anterior
        CarregaControlesValores()

        '----------------------------ORIGEM---------------------------
        If ucfornecedorOrigemN.CodFornecedor <= 0 Then
            Util.AdicionaJsAlert(Me.Page, "O Fornecedor [Origem] é Obrigatório! ")
            Util.AdicionaJsFocus(Me.Page, CType(ucfornecedorOrigemN.FindControl("txtCodigo"), WebControl))
            Return False
        End If
        If Not ValidaFornecedorSelecionado(ucfornecedorOrigemN) Then
            Return False
        End If

        For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdOrigemN.Rows
            If IsNumeric(linha.GetCellValue(Me.grdOrigemN.Columns.FromKey("ValorTransferir"))) Then
                Dim CodigoEmpenhoOrigem As Decimal = CType(linha.GetCellValue(Me.grdOrigemN.Columns.FromKey("CodigoEmpenho")), Decimal)
                If Me.empenhoEstaRelacionadoAEstoque(CodigoEmpenhoOrigem) Then
                    Util.AdicionaJsAlert(Me.Page, "Não é permitida transferência para N Origens quando o empenho de origem está relacionado ao estoque (erro empenho:" & CodigoEmpenhoOrigem.ToString & ")")
                    Util.AdicionaJsFocus(Me.Page, CType(txtEmpenho, WebControl))
                    Return False
                End If
            End If
        Next

        '----------------------------DESTINO---------------------------
        If ucfornecedorOrigemN.CodFornecedor <= 0 Then
            Util.AdicionaJsAlert(Me.Page, "O Fornecedor [Destino] é Obrigatório! ")
            Util.AdicionaJsFocus(Me.Page, CType(ucFornecedorDS.FindControl("txtCodigo"), WebControl))
            Return False
        End If
        If ddlEmpenhoDS.SelectedValue Is String.Empty Then
            Util.AdicionaJsAlert(Me.Page, "O Empenho [Destino] é Obrigatório! ")
            Util.AdicionaJsFocus(Me.Page, CType(ddlEmpenhoDS, WebControl))
            Return False
        End If
        If txtValor.ValueDecimal <= 0 Then
            Util.AdicionaJsAlert(Me.Page, "O Valor a ser transferido é Inválido! ")
            Util.AdicionaJsFocus(Me.Page, CType(txtValor, WebControl), Util.tipoDeComponente.InfragisticsTxt)
            Return False
        End If
        If Not ValidaFornecedorSelecionado(ucFornecedorDS) Then
            Return False
        End If
        If txtEmpenhoDS.ValueDecimal <> getEmpenhoValue(ddlEmpenhoDS.SelectedItem) Then
            Util.AdicionaJsAlert(Me.Page, "Campo texto do empenho de destino é diferente do selecionado no combo")
            Util.AdicionaJsFocus(Me.Page, CType(txtEmpenhoDS, WebControl))
            Return False
        End If
        If txtHistorico.Text.Trim.Length = 0 Then
            Util.AdicionaJsAlert(Me.Page, "É obrigatório digitar o histórico ! ")
            Util.AdicionaJsFocus(Me.Page, CType(txtHistorico, WebControl))
            Return False
        End If

        'Regra adiciona por solicitação do Severton em 18/01/2007
        If linhaUsuarioLogado.TIPUSRSIS <> "X" Then
            If ucfornecedorOrigemN.CodFornecedor <> ucFornecedorDS.CodFornecedor Then
                Util.AdicionaJsAlert(Me.Page, "Não é permitido transferência entre fornecedores diferentes! ")
            End If
        End If

        Return True
    End Function

    Private Sub TransferirValoreEntreEmpenhosFornecedorNOrigensParaUmDestino()
        If flagProcessandoTransferencia Then
            Exit Sub
        End If

        Dim linhaUsuarioLogado As wsAcoesComerciais.dataSetUsuarioCompra.T0113471Row
        Try
            linhaUsuarioLogado = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0)
        Catch ex As Exception
            Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
            Util.AdicionaJsFocus(Me.Page, CType(ddl1, System.web.UI.WebControls.WebControl))
            Exit Sub
        End Try

        'Obtem todos os empenhos, isso é necessário mais a frente nesse método
        dsEmpenho = Controller.ObterEmpenhos(String.Empty, String.Empty, String.Empty, 0, String.Empty)

        Dim dsTransferenciaVerbaFornecedor As New wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor
        flagProcessandoTransferencia = True

        Try
            For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdOrigemN.Rows
                If IsNumeric(linha.GetCellValue(Me.grdOrigemN.Columns.FromKey("ValorTransferir"))) Then

                    Dim CodigoEmpenhoOrigem As Decimal
                    Dim NomeEmpenhoOrigem As String
                    Dim CodigoAlocacaoOrigem As Integer
                    Dim NomeAlocacaoOrigem As String
                    Dim ValorTransferir As Decimal
                    Dim SaldoDisponivel As Decimal

                    CodigoEmpenhoOrigem = CType(linha.GetCellValue(Me.grdOrigemN.Columns.FromKey("CodigoEmpenho")), Decimal)
                    NomeEmpenhoOrigem = CType(linha.GetCellValue(Me.grdOrigemN.Columns.FromKey("NomeEmpenho")), String)
                    CodigoAlocacaoOrigem = CType(linha.GetCellValue(Me.grdOrigemN.Columns.FromKey("CodigoAlocacao")), Integer)
                    NomeAlocacaoOrigem = CType(linha.GetCellValue(Me.grdOrigemN.Columns.FromKey("NomeAlocacao")), String)
                    ValorTransferir = CType(linha.GetCellValue(Me.grdOrigemN.Columns.FromKey("ValorTransferir")), Decimal)
                    SaldoDisponivel = CType(linha.GetCellValue(Me.grdOrigemN.Columns.FromKey("SaldoDisponivel")), Decimal)

                    'Consulta o empenho de Origem
                    Dim linhaEmpenhoOrigem As wsAcoesComerciais.DatasetEmpenho.T0109059Row
                    linhaEmpenhoOrigem = dsEmpenho.T0109059.FindByTIPDSNDSCBNF(CodigoEmpenhoOrigem)
                    If linhaEmpenhoOrigem Is Nothing Then
                        Util.AdicionaJsAlert(Me.Page, "Empenho não encontrado")
                        Exit Sub
                    End If

                    'Obtem o Tipo de Alocação de Origem
                    Dim TipAlcVbaFrnDstPmtDdoOrigem As Integer = 0
                    If Not linhaEmpenhoOrigem.IsTIPALCVBAFRNNull Then
                        TipAlcVbaFrnDstPmtDdoOrigem = Convert.ToInt32(linhaEmpenhoOrigem.TIPALCVBAFRN)
                    End If

                    If ValorTransferir > 0 Then
                        Dim ParametrosTransferenciaRow As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor.ParametrosTransferenciaRow
                        ParametrosTransferenciaRow = dsTransferenciaVerbaFornecedor.ParametrosTransferencia.NewParametrosTransferenciaRow

                        With ParametrosTransferenciaRow
                            .Valor = ValorTransferir
                            .TipAlcVbaFrn = CodigoAlocacaoOrigem
                            .DatRefLmt = txtData.Date
                            .TipDsnDscBnfOrigem = CodigoEmpenhoOrigem
                            .TipDsnDscBnfDestino = Me.getEmpenhoValue(ddlEmpenhoDS.SelectedItem)
                            .CodFrnOrigem = ucfornecedorOrigemN.CodFornecedor
                            .CodFrnDestino = ucfornecedorOrigemN.CodFornecedor
                            .VlrLmtCtb = ValorTransferir
                            .DesHstLmt = txtHistorico.Text
                            .DesVarHstPadOrigem = "Transf. p/ " & ddlEmpenhoDS.SelectedItem.Text.Trim().Split("-"c)(1).Trim() & " - " & ucFornecedorDS.NomFornecedor.Trim().Split("-"c)(1).Trim()
                            .DesVarHstPadDestino = "Transf. de " & NomeEmpenhoOrigem.Trim() & " - " & ucfornecedorOrigemN.NomFornecedor.Split("-"c)(1).Trim()
                            .NomAcsUsrGrcLmt = txtUsuario.Text.Trim()
                            .TipAlcVbaFrnPmtOrigem = TipAlcVbaFrnDstPmtDdoOrigem
                            .TipAlcVbaFrnPmtDestino = 0
                            .SaldoDisponivel = SaldoDisponivel
                        End With

                        dsTransferenciaVerbaFornecedor.ParametrosTransferencia.AddParametrosTransferenciaRow(ParametrosTransferenciaRow)
                    End If
                End If
            Next
            Controller.AtualizarTransferencia(linhaUsuarioLogado.NOMACSUSRSIS, linhaUsuarioLogado.TIPUSRSIS, dsTransferenciaVerbaFornecedor)
        Catch ex As Exception
            Util.gravaInformacaoEventView("Transferência compras concluída com erro")
            Throw ex
        Finally
            flagProcessandoTransferencia = False
        End Try

        Util.AdicionaJsAlert(Me.Page, "Transferência Concluída." & vbCrLf & _
                                      "Origem : " & ucfornecedorOrigemN.NomFornecedor & vbCrLf & _
                                      "Empenho : Vários" & vbCrLf & _
                                      "Valor : " & txtValor.ValueDecimal & vbCrLf & _
                                      "Destino : " & ucFornecedorDS.NomFornecedor & vbCrLf & _
                                      "Empenho : " & ddlEmpenhoDS.SelectedItem.Text)
        Limpa_Form()
        Util.AdicionaJsFocus(Me.Page, CType(ddl1, System.web.UI.WebControls.WebControl))
    End Sub

#End Region

#End Region

#End Region

#End Region

End Class