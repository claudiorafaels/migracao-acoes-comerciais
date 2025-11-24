Public Class TipoServico
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoServico1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoServico
        CType(Me.DatasetTipoServico1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoServico1
        '
        Me.DatasetTipoServico1.DataSetName = "DatasetTipoServico"
        Me.DatasetTipoServico1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoServico1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtDesTipSvcCttFrn As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents txtTipSvcCttFrn As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents DatasetTipoServico1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoServico
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

                'Obtem CADASTRO TIPO SERVIÇO
                If Not (Request.QueryString("TipSvcCttFrn") Is Nothing) Then
                    ObterTipoServico(Decimal.Parse(Request.QueryString("TipSvcCttFrn")))
                    txtTipSvcCttFrn.Enabled = True
                Else
                    txtTipSvcCttFrn.Enabled = False
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
            AtualizarTipoServico()
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
            If txtDesTipSvcCttFrn.Text = String.Empty Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "o campo descrição deve ser preenchido"
            ElseIf IsNumeric(txtDesTipSvcCttFrn.Text) Then
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
            Response.Redirect("TipoServicoListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
    End Sub

    Public Sub ObterTipoServico(ByVal TipSvcCttFrn  As Decimal)
        Try
            DatasetTipoServico1 = Controller.ObterTipoServico(TipSvcCttFrn )

            With DatasetTipoServico1.T0138466(0)
                'TIPO SERVIÇO
                txtTipSvcCttFrn.Text = .TipSvcCttFrn.ToString
                'DESCRICAO TIPO SERVIÇO
                txtDesTipSvcCttFrn.Text = .DesTipSvcCttFrn.Trim()

            End With

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Public Sub AtualizarTipoServico()
        Dim linha As wsAcoesComerciais.DatasetTipoServico.T0138466Row
        Dim tipoEdicao As Short

        Try
            If Validar() = False Then
                Exit Sub
            End If
            If IsNumeric(txtTipSvcCttFrn.Text) Then
                DatasetTipoServico1 = Controller.ObterTipoServico(Decimal.Parse(txtTipSvcCttFrn.Text))
                If CType(ViewState("flagInclusao"), Boolean) Then
                    If DatasetTipoServico1.T0138466.Rows.Count > 0 Then
                        Page.RegisterStartupScript("Alerta", "<script>alert('Inclusão não permitida, já existe esse registro no banco de dados. Os dados do banco foram carregados.');</script>")
                        ObterTipoServico(Decimal.Parse(Request.QueryString("TipSvcCttFrn ")))
                        ViewState("flagInclusao") = False
                        Exit Try
                    End If
                End If
            End If

            If DatasetTipoServico1.T0138466.Rows.Count > 0 Then
                'Update
                linha = DatasetTipoServico1.T0138466(0)
                tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO
                linha.BeginEdit()
            Else
                'Insert
                DatasetTipoServico1.Clear()
                linha = DatasetTipoServico1.T0138466.NewT0138466Row
                tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO
            End If
            'Transfere os dados do formulário para o DataSet
            With linha
                'TIPO SERVIÇO
                .TipSvcCttFrn = Decimal.Parse(Val(txtTipSvcCttFrn.Text).ToString)
                'DESCRICAO TIPO SERVIÇO
                .DesTipSvcCttFrn = txtDesTipSvcCttFrn.Text.ToUpper()

            End With
            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                DatasetTipoServico1.EnforceConstraints = False
                DatasetTipoServico1.T0138466.AddT0138466Row(linha)
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                linha.EndEdit()
            End If

            Controller.AtualizarTipoServico(DatasetTipoServico1)

            Me.Response.Redirect("TipoServicoListar.aspx")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub


End Class