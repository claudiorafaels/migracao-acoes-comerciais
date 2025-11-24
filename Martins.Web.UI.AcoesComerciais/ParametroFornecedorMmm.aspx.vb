Public Class ParametroFornecedorMmm
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetParametroFornecedorMmm1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetParametroFornecedorMmm
        CType(Me.DatasetParametroFornecedorMmm1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetParametroFornecedorMmm1
        '
        Me.DatasetParametroFornecedorMmm1.DataSetName = "DatasetParametroFornecedorMmm"
        Me.DatasetParametroFornecedorMmm1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetParametroFornecedorMmm1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetParametroFornecedorMmm1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetParametroFornecedorMmm
    Protected WithEvents rblFLGFRNAJTCMC As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents wucCODFRN As wucFornecedor
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

#Region " Eventos "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GerarJavaScript()
            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            End If

            If (Not IsPostBack) Then

                'Obtem dados
                If Not (Request.QueryString("CODFRN") Is Nothing) Then
                    ObterParametroFornecedorMmm(Decimal.Parse(Request.QueryString("CODFRN")))
                    wucCODFRN.Enabled = False
                Else
                    wucCODFRN.Enabled = True
                    ViewState("flagInclusao") = True
                End If
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            AtualizarParametroFornecedorMmm()
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

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
    End Sub

    Private Sub wucCODFRN_FornecedorAlterado(ByVal e As System.Web.UI.WebControls.ListItem) Handles wucCODFRN.FornecedorAlterado
        Try
            ObterParametroFornecedorMmm(wucCODFRN.CodFornecedor)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#Region " Métodos "

    Private Sub GerarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        'btnCancelar.Attributes.Add("OnClick", "javascript:return confirm('Deseja sair sem salvar?')")
    End Sub

    Private Function Validar() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = String.Empty

        Try
            Validar = True

            If mensagemErro.Trim() <> String.Empty Then
                Page.RegisterStartupScript("Alerta", "<script>alert('" & (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1) & "');</script>")
                Return False
            End If

            lblErro.Visible = False
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

#Region " Persistencia "

    Public Sub ObterParametroFornecedorMmm(ByVal CODFRN As Decimal)
        Try
            DatasetParametroFornecedorMmm1 = Controller.ObterParametroFornecedorMmm(CODFRN)

            If DatasetParametroFornecedorMmm1.T0123884.Rows.Count = 0 Then
                rblFLGFRNAJTCMC.SelectedValue = "N"
                ViewState("flagInclusao") = True
                Exit Sub
            End If

            With DatasetParametroFornecedorMmm1.T0123884(0)
                If wucCODFRN.CodFornecedor <> .CODFRN Then
                    wucCODFRN.SelecionarFornecedor(.CODFRN)
                End If
                rblFLGFRNAJTCMC.SelectedValue = .FLGFRNAJTCMC
                ViewState("flagInclusao") = False
            End With

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Public Sub AtualizarParametroFornecedorMmm()
        Dim linha As wsAcoesComerciais.DatasetParametroFornecedorMmm.T0123884Row
        Dim tipoEdicao As Short

        Try
            If Validar() = False Then
                Exit Sub
            End If

            DatasetParametroFornecedorMmm1 = Controller.ObterParametroFornecedorMmm(wucCODFRN.CodFornecedor)
            If CType(ViewState("flagInclusao"), Boolean) Then
                If DatasetParametroFornecedorMmm1.T0123884.Rows.Count > 0 Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Inclusão não permitida, já existe esse registro no banco de dados. Os dados do banco foram carregados.');</script>")
                    ObterParametroFornecedorMmm(wucCODFRN.CodFornecedor)
                    ViewState("flagInclusao") = False
                    Exit Try
                End If
            End If

            If DatasetParametroFornecedorMmm1.T0123884.Rows.Count > 0 Then
                'Update
                linha = DatasetParametroFornecedorMmm1.T0123884(0)
                tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO
                linha.BeginEdit()
            Else
                'Insert
                DatasetParametroFornecedorMmm1.Clear()
                linha = DatasetParametroFornecedorMmm1.T0123884.NewT0123884Row
                tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO
            End If
            'Transfere os dados do formulário para o DataSet
            With linha
                .CODFRN = wucCODFRN.CodFornecedor
                .FLGFRNAJTCMC = rblFLGFRNAJTCMC.SelectedValue
            End With
            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                DatasetParametroFornecedorMmm1.EnforceConstraints = False
                DatasetParametroFornecedorMmm1.T0123884.AddT0123884Row(linha)
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                linha.EndEdit()
            End If

            Controller.AtualizarParametroFornecedorMmm(DatasetParametroFornecedorMmm1)

            Me.Response.Redirect("ParametroFornecedorMmm.aspx")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#End Region

End Class