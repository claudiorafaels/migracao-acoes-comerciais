Public Class RelatorioHistoricoAcordo
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnImprimir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents btnVisualizar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents txtAcordo As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents cmbAcordo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents rdbTipoRelatorio As System.Web.UI.WebControls.RadioButtonList
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
            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            End If

            btnImprimir.Attributes.Add("OnClick", "javascript:mostraAndamento()")
            btnVisualizar.Attributes.Add("OnClick", "javascript:mostraAndamento()")

            If Not IsPostBack Then
                ucFornecedor.widthNome = System.Web.UI.WebControls.Unit.Parse("280px")
            End If
            GerarJavaScript()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub GerarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
    End Sub

    Private Function Validar() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = String.Empty

        Try
            Validar = True
            'Fornecedor
            If ucFornecedor.CodFornecedor <= 0 Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "fornecedor não informado"
            End If
            'Acordo
            If cmbAcordo.SelectedValue = String.Empty Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "Não existe acordo cormercial para este fornecedor."
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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Response.Redirect("Principal.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            If Validar() = False Then
                Exit Sub
            End If

            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = True

            If rdbTipoRelatorio.SelectedValue = "0" Then
                ImprimirHistoricoAcordo()
            Else
                ImprimirBaixaAcordo()
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            If Validar() = False Then
                Exit Sub
            End If

            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = False

            If rdbTipoRelatorio.SelectedValue = "0" Then
                ImprimirHistoricoAcordo()
            Else
                ImprimirBaixaAcordo()
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ImprimirHistoricoAcordo()
        ' Obter dados do relatório e guardar na seção
        WSCAcoesComerciais.dsRelatorioHistoricoAcordo = Controller.ObterRelatorioHistoricoAcordo(CType(cmbAcordo.SelectedValue, Integer))
        ' Guarda o nome do relatório na seção
        WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "rpcCLJ122.rpt"
        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

    Private Sub ImprimirBaixaAcordo()
        ' Obter dados do relatório e guardar na seção
        WSCAcoesComerciais.dsRelatorioBaixaAcordo = Controller.ObterRelatorioBaixaAcordo(CType(cmbAcordo.SelectedValue, Decimal))
        ' Guarda o nome do relatório na seção
        WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RelatorioBaixarAcordo.rpt"
        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

    Private Sub ucFornecedor_FornecedorAlterado(ByVal e As System.Web.UI.WebControls.ListItem) Handles ucFornecedor.FornecedorAlterado
        Dim datasetAcordo As wsAcoesComerciais.DatasetAcordo

        cmbAcordo.Items.Clear()
        If ucFornecedor.CodFornecedor = 0 Then Exit Sub

        datasetAcordo = Controller.ObterAcordos(0, 0, ucFornecedor.CodFornecedor, 0, 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, String.Empty, 0)
        'Carrega Acordo
        With cmbAcordo
            .DataSource = datasetAcordo
            .DataMember = "T0118058"
            .DataTextField = "CODPMS"
            .DataValueField = "CODPMS"
            .DataBind()
        End With
        txtAcordo.Text = cmbAcordo.SelectedValue

    End Sub

    Private Sub txtAcordo_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtAcordo.ValueChange
        If Not IsNumeric(txtAcordo.Text) Then
            txtAcordo.Text = "0"
        End If

        If txtAcordo.ValueDecimal.ToString("#########") <> cmbAcordo.SelectedValue Then
            If cmbAcordo.Items.FindByValue(txtAcordo.ValueDecimal.ToString("#########")) Is Nothing Then

                'tdEspera.Visible = False
                Util.AdicionaJsAlert(Me.Page, "Acordo inválido")
                txtAcordo.Text = ""
                Exit Sub
            End If
            cmbAcordo.SelectedValue = txtAcordo.ValueDecimal.ToString("#########")
        End If
    End Sub

    Private Sub cmbAcordo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtAcordo.Text <> cmbAcordo.SelectedValue Then
            txtAcordo.Text = cmbAcordo.SelectedValue
        End If
    End Sub
End Class