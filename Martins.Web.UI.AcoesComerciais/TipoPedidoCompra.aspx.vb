Public Class TipoPedidoCompra
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoPedidoCompra1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoPedidoCompra
        CType(Me.DatasetTipoPedidoCompra1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoPedidoCompra1
        '
        Me.DatasetTipoPedidoCompra1.DataSetName = "DatasetTipoPedidoCompra"
        Me.DatasetTipoPedidoCompra1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoPedidoCompra1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetTipoPedidoCompra1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoPedidoCompra
    Protected WithEvents txtTIPPEDCMP As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtDESTIPPEDCMP As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents chkFLGCALPCOMER As System.Web.UI.WebControls.CheckBox
    Protected WithEvents cmbClausula As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            End If

            GerarJavaScript()

            If (Not IsPostBack) Then
               
                'Carrega Clausulas
                Util.carregarClausulaContrato(Controller.ObterClausulasContrato(String.Empty, 0), cmbClausula, New ListItem("", "0"))

                'Obtem CADASTRO TIPO PEDIDO COMPRA
                If Not (Request.QueryString("TIPPEDCMP") Is Nothing) Then
                    ObterTipoPedidoCompra(Decimal.Parse(Request.QueryString("TIPPEDCMP")))
                Else
                    txtTIPPEDCMP.Enabled = False
                End If

            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub GerarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")

        'btnCancelar.Attributes.Add("OnClick", "javascript:return confirm('Deseja sair sem salvar?')")
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            AtualizarTipoPedidoCompra()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = String.Empty

        Try
            Validar = True

            ''Código 
            'If Val(txtTIPPEDCMP.Text) = 0 Then
            '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '    mensagemErro &= "código inválido"
            'End If
            'descrição
            If txtDESTIPPEDCMP.Text = String.Empty Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "descrição inválida"
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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("TipoPedidoCompraListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
    End Sub

    Public Sub ObterTipoPedidoCompra(ByVal TIPPEDCMP As Decimal)
        Try
            DatasetTipoPedidoCompra1 = Controller.ObterTipoPedidoCompra(TIPPEDCMP)

            With DatasetTipoPedidoCompra1.T0104499(0)
                txtTIPPEDCMP.Text = .TIPPEDCMP.ToString
                txtDESTIPPEDCMP.Text = .DESTIPPEDCMP.Trim
                If .FLGCALPCOMER = 1 Then
                    chkFLGCALPCOMER.Checked = True
                Else
                    chkFLGCALPCOMER.Checked = False
                End If
                If Not .IsNull("NUMCSLCTTFRN") Then
                    If Not cmbClausula.Items.FindByValue(.NUMCSLCTTFRN.ToString) Is Nothing Then
                        cmbClausula.SelectedValue = .NUMCSLCTTFRN.ToString
                    Else
                        cmbClausula.SelectedValue = "0"
                    End If
                Else
                    cmbClausula.SelectedValue = "0"
                End If
            End With

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    'Public Sub ObterTiposPedidoCompra(ByVal DESTIPPEDCMP As String)
    '    Try
    '        DatasetTipoPedidoCompra1 = Controller.ObterTiposPedidoCompra(DESTIPPEDCMP)

    '        With DatasetTipoPedidoCompra1.T0104499(0)
    '            txtDESTIPPEDCMP.Text = .DESTIPPEDCMP.ToString
    '            '      txtDESTIPPEDCMP.Text = .DESTIPPEDCMP.Trim
    '            'If .FLGCALPCOMER = 1 Then
    '            '    chkFLGCALPCOMER.Checked = True
    '            'Else
    '            '    chkFLGCALPCOMER.Checked = False
    '            'End If
    '        End With

    '    Catch ex As Exception
    '        Controller.TrataErro(Me.Page, ex)
    '    End Try
    'End Sub
    Public Sub AtualizarTipoPedidoCompra()
        Dim linha As wsAcoesComerciais.DatasetTipoPedidoCompra.T0104499Row
        Dim tipoEdicao As Short

        Try
            If Validar() = False Then
                Exit Sub
            End If
            If IsNumeric(txtTIPPEDCMP.Text) Then
                DatasetTipoPedidoCompra1 = Controller.ObterTipoPedidoCompra(Decimal.Parse(txtTIPPEDCMP.Text))
            End If

            If DatasetTipoPedidoCompra1.T0104499.Rows.Count > 0 Then
                'Update
                linha = DatasetTipoPedidoCompra1.T0104499(0)
                tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO
                linha.BeginEdit()
            Else
                'Insert
                DatasetTipoPedidoCompra1.Clear()
                linha = DatasetTipoPedidoCompra1.T0104499.NewT0104499Row
                tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO
            End If
            'Transfere os dados do formulário para o DataSet
            With linha
                .DESTIPPEDCMP = txtDESTIPPEDCMP.Text.ToUpper

                If chkFLGCALPCOMER.Checked Then
                    .FLGCALPCOMER = 1
                Else
                    .FLGCALPCOMER = 0
                End If
                .TIPPEDCMP = Decimal.Parse(Val(txtTIPPEDCMP.Text).ToString)
                'If cmbClausula.SelectedValue <> "0" Then
                .NUMCSLCTTFRN = Decimal.Parse(cmbClausula.SelectedValue)
                'Else
                '    .SetNUMCSLCTTFRNNull()
                'End If
            End With
            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                DatasetTipoPedidoCompra1.EnforceConstraints = False
                DatasetTipoPedidoCompra1.T0104499.AddT0104499Row(linha)
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                linha.EndEdit()
            End If

            Controller.AtualizarTipoPedidoCompra(DatasetTipoPedidoCompra1)

            Me.Response.Redirect("TipoPedidoCompraListar.aspx")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub


End Class