Public Class TipoPagamento
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoPagamento1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoPagamento
        CType(Me.DatasetTipoPagamento1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoPagamento1
        '
        Me.DatasetTipoPagamento1.DataSetName = "DatasetTipoPagamento"
        Me.DatasetTipoPagamento1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoPagamento1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetTipoPagamento1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoPagamento
    Protected WithEvents txtTipPgtNotFscCttFrn As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtDesTipPgtNotFscCtt            As Infragistics.WebUI.WebDataInput.WebTextEdit
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

                'Obtem CADASTRO TIPO PAGAMENTO
                If Not (Request.QueryString("TipPgtNotFscCttFrn") Is Nothing) Then
                    ObterTipoPagamento(Decimal.Parse(Request.QueryString("TipPgtNotFscCttFrn")))
                    txtTipPgtNotFscCttFrn.Enabled = True
                Else
                    txtTipPgtNotFscCttFrn.Enabled = False
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
            AtualizarTipoPagamento()
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
            If txtDesTipPgtNotFscCtt.Text = String.Empty Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "o campo descrição deve ser preenchido"
            ElseIf IsNumeric(txtDesTipPgtNotFscCtt.Text) Then
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
            Response.Redirect("TipoPagamentoListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
    End Sub

    Public Sub ObterTipoPagamento(ByVal TipPgtNotFscCttFrn As Decimal)
        Try
            DatasetTipoPagamento1 = Controller.ObterTipoPagamento(TipPgtNotFscCttFrn)

            With DatasetTipoPagamento1.T0138431(0)
                'TIPO PAGAMENTO
                txtTipPgtNotFscCttFrn.Text = .TipPgtNotFscCttFrn.ToString
                'DESCRICAO TIPO PAGAMENTO
                txtDesTipPgtNotFscCtt.Text = .DesTipPgtNotFscCtt.Trim()
               
            End With

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Public Sub AtualizarTipoPagamento()
        Dim linha As wsAcoesComerciais.DatasetTipoPagamento.T0138431Row
        Dim tipoEdicao As Short

        Try
            If Validar() = False Then
                Exit Sub
            End If
            If IsNumeric(txtTipPgtNotFscCttFrn.Text) Then
                DatasetTipoPagamento1 = Controller.ObterTipoPagamento(Decimal.Parse(txtTipPgtNotFscCttFrn.Text))
                If CType(ViewState("flagInclusao"), Boolean) Then
                    If DatasetTipoPagamento1.T0138431.Rows.Count > 0 Then
                        Page.RegisterStartupScript("Alerta", "<script>alert('Inclusão não permitida, já existe esse registro no banco de dados. Os dados do banco foram carregados.');</script>")
                        ObterTipoPagamento(Decimal.Parse(Request.QueryString("TipPgtNotFscCttFrn")))
                        ViewState("flagInclusao") = False
                        Exit Try
                    End If
                End If
            End If

            If DatasetTipoPagamento1.T0138431.Rows.Count > 0 Then
                'Update
                linha = DatasetTipoPagamento1.T0138431(0)
                tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO
                linha.BeginEdit()
            Else
                'Insert
                DatasetTipoPagamento1.Clear()
                linha = DatasetTipoPagamento1.T0138431.NewT0138431Row
                tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO
            End If
            'Transfere os dados do formulário para o DataSet
            With linha
                'TIPO PAGAMENTO
                .TipPgtNotFscCttFrn = Decimal.Parse(Val(txtTipPgtNotFscCttFrn.Text).ToString)
                'DESCRICAO TIPO PAGAMENTO
                .DesTipPgtNotFscCtt = txtDesTipPgtNotFscCtt.Text.ToUpper()
                
            End With
            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                DatasetTipoPagamento1.EnforceConstraints = False
                DatasetTipoPagamento1.T0138431.AddT0138431Row(linha)
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                linha.EndEdit()
            End If

            Controller.AtualizarTipoPagamento(DatasetTipoPagamento1)

            Me.Response.Redirect("TipoPagamentoListar.aspx")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub


End Class