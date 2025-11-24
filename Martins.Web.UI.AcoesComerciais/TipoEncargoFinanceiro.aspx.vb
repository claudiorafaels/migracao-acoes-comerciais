Public Class TipoEncargoFinanceiro
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoEncargoFinanceiro1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoEncargoFinanceiro
        CType(Me.DatasetTipoEncargoFinanceiro1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoEncargoFinanceiro1
        '
        Me.DatasetTipoEncargoFinanceiro1.DataSetName = "DatasetTipoEncargoFinanceiro"
        Me.DatasetTipoEncargoFinanceiro1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoEncargoFinanceiro1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetTipoEncargoFinanceiro1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoEncargoFinanceiro
    Protected WithEvents txtTipEncFinCttFrn As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtDesTipEncFinCttFrn As Infragistics.WebUI.WebDataInput.WebTextEdit
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

                'Obtem CADASTRO TIPO ENCARGO FINANCEIRO
                If Not (Request.QueryString("TipEncFinCttFrn") Is Nothing) Then
                    ObterTipoEncargoFinanceiro(Decimal.Parse(Request.QueryString("TipEncFinCttFrn")))
                    txtTipEncFinCttFrn.Enabled = True
                Else
                    txtTipEncFinCttFrn.Enabled = False
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
            AtualizarTipoEncargoFinanceiro()
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
            If txtDesTipEncFinCttFrn.Text = String.Empty Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "o campo descrição deve ser preenchido"
            ElseIf IsNumeric(txtDesTipEncFinCttFrn.Text) Then
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
            Response.Redirect("TipoEncargoFinanceiroListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
    End Sub

    Public Sub ObterTipoEncargoFinanceiro(ByVal TipEncFinCttFrn As Decimal)
        Try
            DatasetTipoEncargoFinanceiro1 = Controller.ObterTipoEncargoFinanceiro(TipEncFinCttFrn)

            With DatasetTipoEncargoFinanceiro1.T0138415(0)
                'TIPO ENCARGO FINANCEIRO
                txtTipEncFinCttFrn.Text = .TipEncFinCttFrn.ToString
                'DESCRICAO TIPO ENCARGO FINANCEIRO
                txtDesTipEncFinCttFrn.Text = .DesTipEncFinCttFrn.Trim()
               
            End With

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Public Sub AtualizarTipoEncargoFinanceiro()
        Dim linha As wsAcoesComerciais.DatasetTipoEncargoFinanceiro.T0138415Row
        Dim tipoEdicao As Short

        Try
            If Validar() = False Then
                Exit Sub
            End If
            If IsNumeric(txtTipEncFinCttFrn.Text) Then
                DatasetTipoEncargoFinanceiro1 = Controller.ObterTipoEncargoFinanceiro(Decimal.Parse(txtTipEncFinCttFrn.Text))
                If CType(ViewState("flagInclusao"), Boolean) Then
                    If DatasetTipoEncargoFinanceiro1.T0138415.Rows.Count > 0 Then
                        Page.RegisterStartupScript("Alerta", "<script>alert('Inclusão não permitida, já existe esse registro no banco de dados. Os dados do banco foram carregados.');</script>")
                        ObterTipoEncargoFinanceiro(Decimal.Parse(Request.QueryString("TipEncFinCttFrn")))
                        ViewState("flagInclusao") = False
                        Exit Try
                    End If
                End If
            End If

            If DatasetTipoEncargoFinanceiro1.T0138415.Rows.Count > 0 Then
                'Update
                linha = DatasetTipoEncargoFinanceiro1.T0138415(0)
                tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO
                linha.BeginEdit()
            Else
                'Insert
                DatasetTipoEncargoFinanceiro1.Clear()
                linha = DatasetTipoEncargoFinanceiro1.T0138415.NewT0138415Row
                tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO
            End If
            'Transfere os dados do formulário para o DataSet
            With linha
                'TIPO ENCARGO FINANCEIRO
                .TipEncFinCttFrn = Decimal.Parse(Val(txtTipEncFinCttFrn.Text).ToString)
                'DESCRICAO TIPO ENCARGO FINANCEIRO
                .DesTipEncFinCttFrn = txtDesTipEncFinCttFrn.Text.ToUpper()
                
            End With
            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                DatasetTipoEncargoFinanceiro1.EnforceConstraints = False
                DatasetTipoEncargoFinanceiro1.T0138415.AddT0138415Row(linha)
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                linha.EndEdit()
            End If

            Controller.AtualizarTipoEncargoFinanceiro(DatasetTipoEncargoFinanceiro1)

            Me.Response.Redirect("TipoEncargoFinanceiroListar.aspx")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub
End Class