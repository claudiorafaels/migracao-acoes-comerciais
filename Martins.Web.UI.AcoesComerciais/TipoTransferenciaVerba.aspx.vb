Public Class TipoTransferenciaVerba
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoTransferenciaValoresAcoesComerciais1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoTransferenciaValoresAcoesComerciais
        CType(Me.DatasetTipoTransferenciaValoresAcoesComerciais1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoTransferenciaValoresAcoesComerciais1
        '
        Me.DatasetTipoTransferenciaValoresAcoesComerciais1.DataSetName = "DatasetTipoTransferenciaValoresAcoesComerciais"
        Me.DatasetTipoTransferenciaValoresAcoesComerciais1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoTransferenciaValoresAcoesComerciais1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtCODTIPTRNVLRACOCMC As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtDESTIPTRNVLRACOCMC As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents DatasetTipoTransferenciaValoresAcoesComerciais1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoTransferenciaValoresAcoesComerciais
    Protected WithEvents ucEmpenho As wucEmpenho
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

                'Obtem CADASTRO DE TIPO DE TRANSFERENCIA DE VALORES DE ACOES COMERCIAIS
                If Not (Request.QueryString("CODTIPTRNVLRACOCMC") Is Nothing) Then
                    ObterTipoTransferenciaValoresAcoesComerciais(Decimal.Parse(Request.QueryString("CODTIPTRNVLRACOCMC")))
                    txtCODTIPTRNVLRACOCMC.Enabled = True
                Else
                    txtCODTIPTRNVLRACOCMC.Enabled = False
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
            AtualizarTipoTransferenciaValoresAcoesComerciais()
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
            If txtDESTIPTRNVLRACOCMC.Text = String.Empty Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "o campo descrição deve ser preenchido"
            ElseIf IsNumeric(txtDESTIPTRNVLRACOCMC.Text) Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "o campo descrição não pode ser numerico"
            End If

            If mensagemErro.Trim() <> String.Empty Then
                Page.RegisterStartupScript("Alerta", "<script>alert('" & (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1) & "');</script>")
                Return False
            End If
            'If mensagemErro.Trim() <> String.Empty Then
            '    lblErro.Visible = True
            '    lblErro.Text = (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1)
            '    Return False
            'End If
            lblErro.Visible = False
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("TipoTransferenciaVerbaListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
    End Sub

    Public Sub ObterTipoTransferenciaValoresAcoesComerciais(ByVal CODTIPTRNVLRACOCMC As Decimal)
        Try
            DatasetTipoTransferenciaValoresAcoesComerciais1 = Controller.ObterTipoTransferenciaValoresAcoesComerciais(CODTIPTRNVLRACOCMC)

            With DatasetTipoTransferenciaValoresAcoesComerciais1.T0135033(0)
                'CODIGO DO TIPO DE TRANSFERENCIA DE VALORES EM ACOES COM
                txtCODTIPTRNVLRACOCMC.Text = .CODTIPTRNVLRACOCMC.ToString
                'DESCRICAO DO TIPO DE TRANSFERENCIA DE VALORES EM ACOES COM
                txtDESTIPTRNVLRACOCMC.Text = .DESTIPTRNVLRACOCMC.Trim()
                'TIPO DESTINO / DESCONTO BONIFICADO
                ucEmpenho.CodEmpenho = .TIPDSNDSCBNF
            End With

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Public Sub AtualizarTipoTransferenciaValoresAcoesComerciais()
        Dim linha As wsAcoesComerciais.DatasetTipoTransferenciaValoresAcoesComerciais.T0135033Row
        Dim tipoEdicao As Short

        Try
            If Validar() = False Then
                Exit Sub
            End If
            If IsNumeric(txtCODTIPTRNVLRACOCMC.Text) Then
                DatasetTipoTransferenciaValoresAcoesComerciais1 = Controller.ObterTipoTransferenciaValoresAcoesComerciais(Decimal.Parse(txtCODTIPTRNVLRACOCMC.Text))
                If CType(ViewState("flagInclusao"), Boolean) Then
                    If DatasetTipoTransferenciaValoresAcoesComerciais1.T0135033.Rows.Count > 0 Then
                        Page.RegisterStartupScript("Alerta", "<script>alert('Inclusão não permitida, já existe esse registro no banco de dados. Os dados do banco foram carregados.');</script>")
                        ObterTipoTransferenciaValoresAcoesComerciais(Decimal.Parse(Request.QueryString("CODTIPTRNVLRACOCMC")))
                        ViewState("flagInclusao") = False
                        Exit Try
                    End If
                End If
            End If

            If DatasetTipoTransferenciaValoresAcoesComerciais1.T0135033.Rows.Count > 0 Then
                'Update
                linha = DatasetTipoTransferenciaValoresAcoesComerciais1.T0135033(0)
                tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO
                linha.BeginEdit()
            Else
                'Insert
                DatasetTipoTransferenciaValoresAcoesComerciais1.Clear()
                linha = DatasetTipoTransferenciaValoresAcoesComerciais1.T0135033.NewT0135033Row
                tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO
            End If
            'Transfere os dados do formulário para o DataSet
            With linha
                'CODIGO DO TIPO DE TRANSFERENCIA DE VALORES EM ACOES COM
                .CODTIPTRNVLRACOCMC = Decimal.Parse(Val(txtCODTIPTRNVLRACOCMC.Text).ToString)
                'DESCRICAO DO TIPO DE TRANSFERENCIA DE VALORES EM ACOES COM
                .DESTIPTRNVLRACOCMC = txtDESTIPTRNVLRACOCMC.Text.ToUpper()
                'TIPO DESTINO / DESCONTO BONIFICADO
                .TIPDSNDSCBNF = ucEmpenho.CodEmpenho
            End With
            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                DatasetTipoTransferenciaValoresAcoesComerciais1.EnforceConstraints = False
                DatasetTipoTransferenciaValoresAcoesComerciais1.T0135033.AddT0135033Row(linha)
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                linha.EndEdit()
            End If

            Controller.AtualizarTipoTransferenciaValoresAcoesComerciais(DatasetTipoTransferenciaValoresAcoesComerciais1)

            Me.Response.Redirect("TipoTransferenciaVerbaListar.aspx")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

End Class