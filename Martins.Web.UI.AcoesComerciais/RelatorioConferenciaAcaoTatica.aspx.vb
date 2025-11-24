Public Class RelatorioConferenciaAcaoTatica
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btImprimir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents rdlOpcoes As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtMesAnoReferencia As Infragistics.WebUI.WebDataInput.WebMaskEdit
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents btnVisualizar As System.Web.UI.WebControls.LinkButton
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
                ucFornecedor.widthNome = System.Web.UI.WebControls.Unit.Parse("280px")
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub GerarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        btImprimir.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        btnVisualizar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
    End Sub

    Private Sub transferirDadosDoDatasetParaFormulario()
        Try
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            atualizar()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = String.Empty

        Try
            Validar = True


            'Fornecedor
            If ucFornecedor.CodFornecedor < 0 Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "fornecedor não informado"
            End If
            'Mes(referencia)
            If Not IsNumeric(txtMesAnoReferencia.Text.Substring(0, 2)) Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "é obrigatório informar um valor entre 1 e 12 para o mês"
            Else
                If Val(txtMesAnoReferencia.Text.Substring(0, 2)) > 12 Or Val(txtMesAnoReferencia.Text.Substring(0, 2)) < 1 Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "mês inválido"
                End If
            End If
            'Ano(referencia)
            If Not IsNumeric(txtMesAnoReferencia.Text.Substring(3, 4)) Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "é obrigatório o ano"
            Else
                If Val(txtMesAnoReferencia.Text.Substring(3, 4)) > 2100 Or Val(txtMesAnoReferencia.Text.Substring(3, 4)) < 1900 Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "Ano inválido"
                End If
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

    Private Sub atualizar()
        Try

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub btImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImprimir.Click
        Try
            If Validar() = False Then
                Exit Sub
            End If

            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = True

            If rdlOpcoes.SelectedValue = "1" Then
                ImprimirAnalitico()
            ElseIf rdlOpcoes.SelectedValue = "2" Then
                ImprimirSintetico()
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

            If rdlOpcoes.SelectedValue = "1" Then
                ImprimirAnalitico()
            ElseIf rdlOpcoes.SelectedValue = "2" Then
                ImprimirSintetico()
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ImprimirAnalitico()
        If rdlOpcoes.SelectedValue = "1" Then 'Analítico
            ' Obter dados do relatório e guardar na seção
            WSCAcoesComerciais.dsRelatorioConferenciaAcaoTatica = Controller.ObterRelatorioConferenciaAcaoTatica(Convert.ToInt32(ucFornecedor.CodFornecedor), txtMesAnoReferencia.Text, Integer.Parse("1"))
            ' Guarda o nome do relatório na seção
            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "cby002z2b.rpt"

        End If
        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

    Private Sub ImprimirSintetico()
        If rdlOpcoes.SelectedValue = "2" Then 'Sintético
            'Obter dados do relatório e guardar na seção
            WSCAcoesComerciais.dsRelatorioConferenciaAcaoTatica = Controller.ObterRelatorioConferenciaAcaoTatica(Convert.ToInt32(ucFornecedor.CodFornecedor), txtMesAnoReferencia.Text, Integer.Parse("2"))
            'Guarda o nome do relatório na seção
            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "cby002z2a.RPT"
        End If
        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

  
End Class