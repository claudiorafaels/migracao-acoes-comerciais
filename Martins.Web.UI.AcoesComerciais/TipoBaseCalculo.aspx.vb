Public Class TipoBaseCalculo
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoBaseCalculo1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoBaseCalculo
        CType(Me.DatasetTipoBaseCalculo1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoBaseCalculo1
        '
        Me.DatasetTipoBaseCalculo1.DataSetName = "DatasetTipoBaseCalculo"
        Me.DatasetTipoBaseCalculo1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoBaseCalculo1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetTipoBaseCalculo1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoBaseCalculo
    Protected WithEvents txtTIPBSECAL As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtDESBSECAL As Infragistics.WebUI.WebDataInput.WebTextEdit
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

                'Obtem CADASTRO TIPO BASE DE CALCULO
                If Not (Request.QueryString("TIPBSECAL") Is Nothing) Then
                    ObterTipoBaseCalculo(Decimal.Parse(Request.QueryString("TIPBSECAL")))
                    txtTIPBSECAL.Enabled = True
                Else
                    txtTIPBSECAL.Enabled = False
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
            AtualizarTipoBaseCalculo()
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
            If txtDESBSECAL.Text = String.Empty Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "o campo descrição deve ser preenchido"
            ElseIf IsNumeric(txtDESBSECAL.Text) Then
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
            Response.Redirect("TipoBaseCalculoListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
    End Sub

    Public Sub ObterTipoBaseCalculo(ByVal TIPBSECAL As Decimal)
        Try
            DatasetTipoBaseCalculo1 = Controller.ObterTipoBaseCalculo(TIPBSECAL)

            With DatasetTipoBaseCalculo1.T0125003(0)
                'TIPO BASE DE CALCULO
                txtTIPBSECAL.Text = .TIPBSECAL.ToString
                'DESCRICAO TIPO BASE DE CALCULO
                txtDESBSECAL.Text = .DESBSECAL.Trim()
               
            End With

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Public Sub AtualizarTipoBaseCalculo()
        Dim linha As wsAcoesComerciais.DatasetTipoBaseCalculo.T0125003Row
        Dim tipoEdicao As Short

        Try
            If Validar() = False Then
                Exit Sub
            End If
            If IsNumeric(txtTIPBSECAL.Text) Then
                DatasetTipoBaseCalculo1 = Controller.ObterTipoBaseCalculo(Decimal.Parse(txtTIPBSECAL.Text))
                If CType(ViewState("flagInclusao"), Boolean) Then
                    If DatasetTipoBaseCalculo1.T0125003.Rows.Count > 0 Then
                        Page.RegisterStartupScript("Alerta", "<script>alert('Inclusão não permitida, já existe esse registro no banco de dados. Os dados do banco foram carregados.');</script>")
                        ObterTipoBaseCalculo(Decimal.Parse(Request.QueryString("TIPBSECAL")))
                        ViewState("flagInclusao") = False
                        Exit Try
                    End If
                End If
            End If

            If DatasetTipoBaseCalculo1.T0125003.Rows.Count > 0 Then
                'Update
                linha = DatasetTipoBaseCalculo1.T0125003(0)
                tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO
                linha.BeginEdit()
            Else
                'Insert
                DatasetTipoBaseCalculo1.Clear()
                linha = DatasetTipoBaseCalculo1.T0125003.NewT0125003Row
                tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO
            End If
            'Transfere os dados do formulário para o DataSet
            With linha
                'TIPO BASE DE CALCULO
                .TIPBSECAL = Decimal.Parse(Val(txtTIPBSECAL.Text).ToString)
                'DESCRICAO TIPO BASE DE CALCULO
                .DESBSECAL = txtDESBSECAL.Text.ToUpper()
                
            End With
            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                DatasetTipoBaseCalculo1.EnforceConstraints = False
                DatasetTipoBaseCalculo1.T0125003.AddT0125003Row(linha)
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                linha.EndEdit()
            End If

            Controller.AtualizarTipoBaseCalculo(DatasetTipoBaseCalculo1)

            Me.Response.Redirect("TipoBaseCalculoListar.aspx")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub
End Class