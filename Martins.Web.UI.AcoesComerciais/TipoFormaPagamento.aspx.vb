Public Class TipoFormaPagamento
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoFormaPagamento1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoFormaPagamento
        CType(Me.DatasetTipoFormaPagamento1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoFormaPagamento1
        '
        Me.DatasetTipoFormaPagamento1.DataSetName = "DatasetTipoFormaPagamento"
        Me.DatasetTipoFormaPagamento1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoFormaPagamento1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtTipFrmPgtCttFrn As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtDesTipFrmPgtCttFrn As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents DatasetTipoFormaPagamento1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoFormaPagamento
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

                'Obtem CADASTRO TIPO FORMA PAGAMENTO
                If Not (Request.QueryString("TipFrmPgtCttFrn") Is Nothing) Then
                    ObterTipoFormaPagamento(Decimal.Parse(Request.QueryString("TipFrmPgtCttFrn")))
                    txtTipFrmPgtCttFrn.Enabled = True
                Else
                    txtTipFrmPgtCttFrn.Enabled = False
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
            AtualizarTipoFormaPagamento()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = String.Empty

        Try
            Validar = True

            'Descrição
            If txtDesTipFrmPgtCttFrn.Text = String.Empty Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "o campo descrição deve ser preenchido"
            ElseIf IsNumeric(txtDesTipFrmPgtCttFrn.Text) Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "o campo descrição não pode ser numerico"
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
            Response.Redirect("TipoFormaPagamentoListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
    End Sub

    Public Sub ObterTipoFormaPagamento(ByVal TipFrmPgtCttFrn As Decimal)
        Try
            DatasetTipoFormaPagamento1 = Controller.ObterTipoFormaPagamento(TipFrmPgtCttFrn)

            With DatasetTipoFormaPagamento1.T0138407(0)
                'TIPO FORMA PAGAMENTO
                txtTipFrmPgtCttFrn.Text = .TipFrmPgtCttFrn.ToString
                'DESCRICAO TIPO FORMA PAGAMENTO
                txtDesTipFrmPgtCttFrn.Text = .DesTipFrmPgtCttFrn.Trim()

            End With

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Public Sub AtualizarTipoFormaPagamento()
        Dim linha As wsAcoesComerciais.DatasetTipoFormaPagamento.T0138407Row
        Dim tipoEdicao As Short

        Try
            If Validar() = False Then
                Exit Sub
            End If
            If IsNumeric(txtTipFrmPgtCttFrn.Text) Then
                DatasetTipoFormaPagamento1 = Controller.ObterTipoFormaPagamento(Decimal.Parse(txtTipFrmPgtCttFrn.Text))
                If CType(ViewState("flagInclusao"), Boolean) Then
                    If DatasetTipoFormaPagamento1.T0138407.Rows.Count > 0 Then
                        Page.RegisterStartupScript("Alerta", "<script>alert('Inclusão não permitida, já existe esse registro no banco de dados. Os dados do banco foram carregados.');</script>")
                        ObterTipoFormaPagamento(Decimal.Parse(Request.QueryString("TipFrmPgtCttFrn")))
                        ViewState("flagInclusao") = False
                        Exit Try
                    End If
                End If
            End If

            If DatasetTipoFormaPagamento1.T0138407.Rows.Count > 0 Then
                'Update
                linha = DatasetTipoFormaPagamento1.T0138407(0)
                tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO
                linha.BeginEdit()
            Else
                'Insert
                DatasetTipoFormaPagamento1.Clear()
                linha = DatasetTipoFormaPagamento1.T0138407.NewT0138407Row
                tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO
            End If
            'Transfere os dados do formulário para o DataSet
            With linha
                'TIPO BASE DE PAGAMENTO
                .TipFrmPgtCttFrn = Decimal.Parse(Val(txtTipFrmPgtCttFrn.Text).ToString)
                'DESCRICAO FORMA DE PAGAMENTO
                .DesTipFrmPgtCttFrn = txtDesTipFrmPgtCttFrn.Text.ToUpper()

            End With
            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                DatasetTipoFormaPagamento1.EnforceConstraints = False
                DatasetTipoFormaPagamento1.T0138407.AddT0138407Row(linha)
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                linha.EndEdit()
            End If

            Controller.AtualizarTipoFormaPagamento(DatasetTipoFormaPagamento1)

            Me.Response.Redirect("TipoFormaPagamentoListar.aspx")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub


End Class