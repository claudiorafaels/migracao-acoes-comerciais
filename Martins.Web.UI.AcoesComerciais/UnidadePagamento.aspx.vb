Public Class UnidadePagamento
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoUnidadePagamento1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoUnidadePagamento
        CType(Me.DatasetTipoUnidadePagamento1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoUnidadePagamento1
        '
        Me.DatasetTipoUnidadePagamento1.DataSetName = "DatasetTipoUnidadePagamento"
        Me.DatasetTipoUnidadePagamento1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoUnidadePagamento1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetTipoUnidadePagamento1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoUnidadePagamento
    Protected WithEvents txtDesTipUndPgtCttFrn As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents txtTipUndPgtCttFrn As Infragistics.WebUI.WebDataInput.WebNumericEdit
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
            GerarJavaScript()
            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            End If

            If (Not IsPostBack) Then

                'Obtem CADASTRO UNIDADE PAGAMENTO
                If Not (Request.QueryString("TipUndPgtCttFrn") Is Nothing) Then
                    ObterUnidadePagamento(Decimal.Parse(Request.QueryString("TipUndPgtCttFrn")))
                    txtTipUndPgtCttFrn.Enabled = True
                Else
                    txtTipUndPgtCttFrn.Enabled = False
                    ViewState("flagInclusao") = True
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
            AtualizarUnidadePagamento()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = ""

        Try
            Validar = True

            'Descrição
            If txtDesTipUndPgtCttFrn.Text = "" Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "o campo descrição deve ser preenchido"
            ElseIf IsNumeric(txtDesTipUndPgtCttFrn.Text) Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "o campo descrição não pode ser numerico"
            End If

            If mensagemErro.Trim() <> "" Then
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
            Response.Redirect("UnidadePagamentoListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
    End Sub

    Public Sub ObterUnidadePagamento(ByVal TipUndPgtCttFrn As Decimal)
        Try
            DatasetTipoUnidadePagamento1 = Controller.ObterTipoUnidadePagamento(TipUndPgtCttFrn)

            With DatasetTipoUnidadePagamento1.T0138458(0)
                'CODIGO UNIDADE PAGAMENTO
                txtTipUndPgtCttFrn.Text = .TipUndPgtCttFrn.ToString
                'DESCRICAO UNIDADE PAGAMENTO
                txtDesTipUndPgtCttFrn.Text = .DesTipUndPgtCttFrn.Trim()

            End With

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Public Sub AtualizarUnidadePagamento()
        Dim linha As wsAcoesComerciais.DatasetTipoUnidadePagamento.T0138458Row
        Dim tipoEdicao As Short

        Try
            If Validar() = False Then
                Exit Sub
            End If
            If IsNumeric(txtTipUndPgtCttFrn.Text) Then
                DatasetTipoUnidadePagamento1 = Controller.ObterTipoUnidadePagamento(Decimal.Parse(txtTipUndPgtCttFrn.Text))
                If CType(ViewState("flagInclusao"), Boolean) Then
                    If DatasetTipoUnidadePagamento1.T0138458.Rows.Count > 0 Then
                        Page.RegisterStartupScript("Alerta", "<script>alert('Inclusão não permitida, já existe esse registro no banco de dados. Os dados do banco foram carregados.');</script>")
                        ObterUnidadePagamento(Decimal.Parse(Request.QueryString("TipUndPgtCttFrn")))
                        ViewState("flagInclusao") = False
                        Exit Try
                    End If
                End If
            End If

            If DatasetTipoUnidadePagamento1.T0138458.Rows.Count > 0 Then
                'Update
                linha = DatasetTipoUnidadePagamento1.T0138458(0)
                tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO
                linha.BeginEdit()
            Else
                'Insert
                DatasetTipoUnidadePagamento1.Clear()
                linha = DatasetTipoUnidadePagamento1.T0138458.NewT0138458Row
                tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO
            End If
            'Transfere os dados do formulário para o DataSet
            With linha
                'TIPO BASE DE CALCULO
                .TipUndPgtCttFrn = Decimal.Parse(Val(txtTipUndPgtCttFrn.Text).ToString)
                'DESCRICAO TIPO BASE DE CALCULO
                .DesTipUndPgtCttFrn = txtDesTipUndPgtCttFrn.Text.ToUpper()

            End With
            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                DatasetTipoUnidadePagamento1.EnforceConstraints = False
                DatasetTipoUnidadePagamento1.T0138458.AddT0138458Row(linha)
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                linha.EndEdit()
            End If

            Controller.AtualizarTipoUnidadePagamento(DatasetTipoUnidadePagamento1)

            Me.Response.Redirect("UnidadePagamentoListar.aspx")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub


End Class