Public Class TipoRelacionamento
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoRelacionamento1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoRelacionamento
        CType(Me.DatasetTipoRelacionamento1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoRelacionamento1
        '
        Me.DatasetTipoRelacionamento1.DataSetName = "DatasetTipoRelacionamento"
        Me.DatasetTipoRelacionamento1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoRelacionamento1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetTipoRelacionamento1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoRelacionamento
    Protected WithEvents txtTipRlcCttFrn As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtDesTipRlcCttFrn As Infragistics.WebUI.WebDataInput.WebTextEdit
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

                'Obtem CADASTRO TIPO RELACIONAMENTO
                If Not (Request.QueryString("TipRlcCttFrn") Is Nothing) Then
                    ObterTipoRelacionamento(Decimal.Parse(Request.QueryString("TipRlcCttFrn")))
                    txtTipRlcCttFrn.Enabled = True
                Else
                    txtTipRlcCttFrn.Enabled = False
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
            AtualizarTipoRelacionamento()
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
            If txtDesTipRlcCttFrn.Text = String.Empty Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "o campo descrição deve ser preenchido"
            ElseIf IsNumeric(txtDesTipRlcCttFrn.Text) Then
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
            Response.Redirect("TipoRelacionamentoListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
    End Sub

    Public Sub ObterTipoRelacionamento(ByVal TipRlcCttFrn As Decimal)
        Try
            DatasetTipoRelacionamento1 = Controller.ObterTipoRelacionamento(TipRlcCttFrn)

            With DatasetTipoRelacionamento1.T0138474(0)
                'TIPO RELACIONAMENTO
                txtTipRlcCttFrn.Text = .TipRlcCttFrn.ToString
                'DESCRICAO TIPO RELACIONAMENTO
                txtDesTipRlcCttFrn.Text = .DesTipRlcCttFrn.Trim()
               
            End With

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Public Sub AtualizarTipoRelacionamento()
        Dim linha As wsAcoesComerciais.DatasetTipoRelacionamento.T0138474Row
        Dim tipoEdicao As Short

        Try
            If Validar() = False Then
                Exit Sub
            End If
            If IsNumeric(txtTipRlcCttFrn.Text) Then
                DatasetTipoRelacionamento1 = Controller.ObterTipoRelacionamento(Decimal.Parse(txtTipRlcCttFrn.Text))
                If CType(ViewState("flagInclusao"), Boolean) Then
                    If DatasetTipoRelacionamento1.T0138474.Rows.Count > 0 Then
                        Page.RegisterStartupScript("Alerta", "<script>alert('Inclusão não permitida, já existe esse registro no banco de dados. Os dados do banco foram carregados.');</script>")
                        ObterTipoRelacionamento(Decimal.Parse(Request.QueryString("TipRlcCttFrn")))
                        ViewState("flagInclusao") = False
                        Exit Try
                    End If
                End If
            End If

            If DatasetTipoRelacionamento1.T0138474.Rows.Count > 0 Then
                'Update
                linha = DatasetTipoRelacionamento1.T0138474(0)
                tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO
                linha.BeginEdit()
            Else
                'Insert
                DatasetTipoRelacionamento1.Clear()
                linha = DatasetTipoRelacionamento1.T0138474.NewT0138474Row
                tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO
            End If
            'Transfere os dados do formulário para o DataSet
            With linha
                'TIPO RELACIONAMENTO
                .TipRlcCttFrn = Decimal.Parse(Val(txtTipRlcCttFrn.Text).ToString)
                'DESCRICAO TIPO RELACIONAMENTO
                .DesTipRlcCttFrn = txtDesTipRlcCttFrn.Text.ToUpper()
                
            End With
            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                DatasetTipoRelacionamento1.EnforceConstraints = False
                DatasetTipoRelacionamento1.T0138474.AddT0138474Row(linha)
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                linha.EndEdit()
            End If

            Controller.AtualizarTipoRelacionamento(DatasetTipoRelacionamento1)

            Me.Response.Redirect("TipoRelacionamentoListar.aspx")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub


End Class