Public Class TipoFornecedor
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoFornecedor1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoFornecedor
        CType(Me.DatasetTipoFornecedor1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoFornecedor1
        '
        Me.DatasetTipoFornecedor1.DataSetName = "DatasetTipoFornecedor"
        Me.DatasetTipoFornecedor1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoFornecedor1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtDesTipFrnCttFrn As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents DatasetTipoFornecedor1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoFornecedor
    Protected WithEvents txtTIPFRNCTTFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
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

                'Obtem CADASTRO TIPO FORNECEDOR
                If Not (Request.QueryString("TIPFRNCTTFRN") Is Nothing) Then
                    ObterTipoFornecedor(Decimal.Parse(Request.QueryString("TIPFRNCTTFRN")))
                    txtTipFrnCttFrn.Enabled = True
                Else
                    txtTipFrnCttFrn.Enabled = False
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
            AtualizarTipoFornecedor()
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
            If txtDesTipFrnCttFrn.Text = String.Empty Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "o campo descrição deve ser preenchido"
            ElseIf IsNumeric(txtDesTipFrnCttFrn.Text) Then
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
            Response.Redirect("TipoFornecedorListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
    End Sub

    Public Sub ObterTipoFornecedor(ByVal TIPFRNCTTFRN As Decimal)
        Try
            DatasetTipoFornecedor1 = Controller.ObterTipoFornecedor(TipFrnCttFrn)

            With DatasetTipoFornecedor1.T0138440(0)
                'TIPO FORNECEDOR
                txtTipFrnCttFrn.Text = .TipFrnCttFrn.ToString
                'DESCRICAO TIPO FORNECEDOR
                txtDesTipFrnCttFrn.Text = .DesTipFrnCttFrn.Trim()

            End With

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Public Sub AtualizarTipoFornecedor()
        Dim linha As wsAcoesComerciais.DatasetTipoFornecedor.T0138440Row
        Dim tipoEdicao As Short

        Try
            If Validar() = False Then
                Exit Sub
            End If
            If IsNumeric(txtTipFrnCttFrn.Text) Then
                DatasetTipoFornecedor1 = Controller.ObterTipoFornecedor(Decimal.Parse(txtTipFrnCttFrn.Text))
                If CType(ViewState("flagInclusao"), Boolean) Then
                    If DatasetTipoFornecedor1.T0138440.Rows.Count > 0 Then
                        Page.RegisterStartupScript("Alerta", "<script>alert('Inclusão não permitida, já existe esse registro no banco de dados. Os dados do banco foram carregados.');</script>")
                        ObterTipoFornecedor(Decimal.Parse(Request.QueryString("TIPFRNCTTFRN")))
                        ViewState("flagInclusao") = False
                        Exit Try
                    End If
                End If
            End If

            If DatasetTipoFornecedor1.T0138440.Rows.Count > 0 Then
                'Update
                linha = DatasetTipoFornecedor1.T0138440(0)
                tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO
                linha.BeginEdit()
            Else
                'Insert
                DatasetTipoFornecedor1.Clear()
                linha = DatasetTipoFornecedor1.T0138440.NewT0138440Row
                tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO
            End If
            'Transfere os dados do formulário para o DataSet
            With linha
                'TIPO BASE DE CALCULO
                .TipFrnCttFrn = Decimal.Parse(Val(txtTipFrnCttFrn.Text).ToString)
                'DESCRICAO TIPO BASE DE CALCULO
                .DesTipFrnCttFrn = txtDesTipFrnCttFrn.Text.ToUpper()

            End With
            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                DatasetTipoFornecedor1.EnforceConstraints = False
                DatasetTipoFornecedor1.T0138440.AddT0138440Row(linha)
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                linha.EndEdit()
            End If

            Controller.AtualizarTipoFornecedor(DatasetTipoFornecedor1)

            Me.Response.Redirect("TipoFornecedorListar.aspx")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

End Class