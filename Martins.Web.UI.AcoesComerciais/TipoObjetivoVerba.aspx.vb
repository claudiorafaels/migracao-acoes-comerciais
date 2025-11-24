Public Class TipoObjetivoVerba
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetVerbaCarimbo1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetVerbaCarimbo
        CType(Me.DatasetVerbaCarimbo1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetVerbaCarimbo1
        '
        Me.DatasetVerbaCarimbo1.DataSetName = "DatasetVerbaCarimbo"
        Me.DatasetVerbaCarimbo1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetVerbaCarimbo1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtTipAbgTabPcoCttFrn As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtDesTipAbgTabPcoCtt As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents DatasetVerbaCarimbo1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetVerbaCarimbo

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub


    Public isDelete As Boolean = False

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GerarJavaScript()
            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            End If

            If (Not IsPostBack) Then

                'Obtem CADASTRO ABRANGÊNCIA
                If Not (Request.QueryString("codigo") Is Nothing) Then
                    ObterTipoObjetivoVerba(Request.QueryString("codigo"))
                    txtTipAbgTabPcoCttFrn.Enabled = True

                    Me.btnApagar.Visible = DatasetVerbaCarimbo1.CADOBJDSNVBA(0).IsDATDSTTIPOBJDSNVBANull
                    Me.btnSalvar.Visible = DatasetVerbaCarimbo1.CADOBJDSNVBA(0).IsDATDSTTIPOBJDSNVBANull
                Else
                    txtTipAbgTabPcoCttFrn.Enabled = False
                    ViewState("flagInclusao") = True
                    Me.btnApagar.Visible = False
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
            AtualizarTipoObjetivoVerba()
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
            If txtDesTipAbgTabPcoCtt.Text = String.Empty Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "o campo descrição deve ser preenchido"
            ElseIf IsNumeric(txtDesTipAbgTabPcoCtt.Text) Then
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
            Response.Redirect("TipoObjetivoVerbaListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
        Try


            Dim msgValidacao As String = Controller.VerificaDesaticavaoTipoDestinoVerba(txtTipAbgTabPcoCttFrn.ValueInt)
            If msgValidacao.Length > 0 Then
                Page.RegisterStartupScript("Alerta", "<script>alert('" & msgValidacao & "');</script>")
                Exit Sub
            End If



            Dim linha As wsAcoesComerciais.DatasetVerbaCarimbo.CADOBJDSNVBARow
            DatasetVerbaCarimbo1 = Controller.ObterTiposObjetivoVerba("", txtTipAbgTabPcoCttFrn.Text)
            linha = DatasetVerbaCarimbo1.CADOBJDSNVBA(0)
            linha.BeginEdit()
            With linha
                .DATDSTTIPOBJDSNVBA = Date.Now
            End With
            linha.EndEdit()

            Controller.AtualizarTiposObjetivoVerba(DatasetVerbaCarimbo1)

            Me.Response.Redirect("TipoObjetivoVerbaListar.aspx")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub

    Public Sub ObterTipoObjetivoVerba(ByVal codigo As String)
        Try
            DatasetVerbaCarimbo1 = Controller.ObterTiposObjetivoVerba("", codigo)

            With DatasetVerbaCarimbo1.CADOBJDSNVBA(0)
                'TIPO ABRANGÊNCIA
                txtTipAbgTabPcoCttFrn.Text = .TIPOBJDSNVBA.ToString
                'DESCRICAO TIPO ABRANGÊNCIA
                txtDesTipAbgTabPcoCtt.Text = .DESOBJDSNVBA.Trim()

            End With



        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Public Sub AtualizarTipoObjetivoVerba()
        Dim linha As wsAcoesComerciais.DatasetVerbaCarimbo.CADOBJDSNVBARow
        Dim tipoEdicao As Short

        Try
            If Validar() = False Then
                Exit Sub
            End If
            If IsNumeric(txtTipAbgTabPcoCttFrn.Text) Then
                DatasetVerbaCarimbo1 = Controller.ObterTiposObjetivoVerba("", txtTipAbgTabPcoCttFrn.Text)
                If CType(ViewState("flagInclusao"), Boolean) Then
                    If DatasetVerbaCarimbo1.CADOBJDSNVBA.Rows.Count > 0 Then
                        Page.RegisterStartupScript("Alerta", "<script>alert('Inclusão não permitida, já existe esse registro no banco de dados. Os dados do banco foram carregados.');</script>")
                        ObterTipoObjetivoVerba(Request.QueryString("codigo"))
                        ViewState("flagInclusao") = False
                        Exit Try
                    End If
                End If
            End If

            If DatasetVerbaCarimbo1.CADOBJDSNVBA.Rows.Count > 0 Then
                'Update
                linha = DatasetVerbaCarimbo1.CADOBJDSNVBA(0)
                tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO
                linha.BeginEdit()
            Else
                'Insert
                DatasetVerbaCarimbo1.Clear()
                linha = DatasetVerbaCarimbo1.CADOBJDSNVBA.NewCADOBJDSNVBARow
                tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO
            End If
            'Transfere os dados do formulário para o DataSet
            With linha
                'TIPO ABRANGÊNCIA
                .TIPOBJDSNVBA = txtTipAbgTabPcoCttFrn.ValueDecimal
                'DESCRICAO TIPO ABRANGÊNCIA
                .DESOBJDSNVBA = txtDesTipAbgTabPcoCtt.Text.ToUpper()

            End With
            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                DatasetVerbaCarimbo1.EnforceConstraints = False
                DatasetVerbaCarimbo1.CADOBJDSNVBA.AddCADOBJDSNVBARow(linha)
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                linha.EndEdit()
            End If

            Controller.AtualizarTiposObjetivoVerba(DatasetVerbaCarimbo1)

            Me.Response.Redirect("TipoObjetivoVerbaListar.aspx")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub


End Class