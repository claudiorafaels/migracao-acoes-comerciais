Public Class PrevisaoApuracao
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btImprimir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnVisualizar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents ucDiretoria As wucDiretoria
    Protected WithEvents ucCelula As wucCelula
    Protected WithEvents ucComprador As wucComprador
    Protected WithEvents rdlRelatorio As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Linkbutton1 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnLimpar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents trComprador As System.Web.UI.HtmlControls.HtmlTableRow

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
            Me.trComprador.Visible = False
            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            End If

            If (Not IsPostBack) Then
                ucFornecedor.widthNome = System.Web.UI.WebControls.Unit.Parse("280px")
                ucCelula.widthNome = System.Web.UI.WebControls.Unit.Parse("280px")
                ucDiretoria.widthNome = System.Web.UI.WebControls.Unit.Parse("280px")
                ucComprador.widthNome = System.Web.UI.WebControls.Unit.Parse("280px")
                ucDiretoria.setFocus()
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

    Private Function Validar() As Boolean
        Try
            If rdlRelatorio.SelectedValue = "1" Then
                If (ucDiretoria.CodDiretoria <= 0) And (ucCelula.CodCelula <= 0) And (ucFornecedor.CodFornecedor <= 0) And (ucComprador.CodComprador <= 0) Then
                    Util.AdicionaJsAlert(Me.Page, "Selecione um ou mais Campo(s)", True)
                    Return False
                End If
            ElseIf rdlRelatorio.SelectedValue = "2" Then
                If (ucDiretoria.NomDiretoria = String.Empty) And (ucCelula.NomCelula = String.Empty) And (ucFornecedor.NomFornecedor = String.Empty) And (ucComprador.NomComprador = String.Empty) Then
                    Util.AdicionaJsAlert(Me.Page, "Selecione um ou mais Campo(s)", True)
                    Return False
                End If
            End If

            Return True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("Principal.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImprimir.Click
        Try
            If Validar() = False Then
                Exit Sub
            End If

            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = True

            ImprimirRelatorio()

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ImprimirRelatorio()

        Dim CODFRN As Decimal = 0
        Dim CODCPR As Decimal = 0
        Dim CODDIV As Decimal = 0
        Dim CODDRT As Decimal = 0
        Dim FILTRO As Decimal = 0

        If Not ucFornecedor.NomFornecedor = String.Empty Then
            CODFRN = ucFornecedor.CodFornecedor
        End If

        If Not ucComprador.NomComprador = String.Empty Then
            CODCPR = ucComprador.CodComprador
        End If

        If Not ucCelula.NomCelula = String.Empty Then
            CODDIV = ucCelula.CodCelula
        End If

        If Not ucDiretoria.NomDiretoria = String.Empty Then
            CODDRT = ucDiretoria.CodDiretoria
        End If

        If rdlRelatorio.SelectedValue = "2" Then
            FILTRO = FiltroSelecionado()
        End If

        WSCAcoesComerciais.dsPrevisaoApuracao = Controller.ObterPrevisaoApuracao(FILTRO, CODFRN, CODCPR, CODDIV, CODDRT)

        If rdlRelatorio.SelectedValue = "1" Then 'Analítico
            If ucDiretoria.CodDiretoria > 0 Then
                WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RelatorioPrevisaoApuracao.rpt"
            ElseIf ucCelula.CodCelula > 0 Then
                WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RelatorioPrevisaoApuracaoCelula.rpt"
            ElseIf ucComprador.CodComprador > 0 Then
                WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RelatorioPrevisaoApuracaoComprador.rpt"
            ElseIf ucFornecedor.CodFornecedor > 0 Then
                WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RelatorioPrevisaoApuracaoFornecedor.rpt"
            End If
        ElseIf rdlRelatorio.SelectedValue = "2" Then 'Sintético
            If Not ucDiretoria.NomDiretoria = String.Empty Then
                WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RelatorioPrevisaoApuracaoSintetico.rpt"
            ElseIf Not ucCelula.NomCelula = String.Empty Then
                WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RelatorioPrevisaoApuracaoCelulaSintetico.rpt"
            ElseIf Not ucComprador.NomComprador = String.Empty Then
                WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RelatorioPrevisaoApuracaoCompradorSintetico.rpt"
            ElseIf Not ucFornecedor.NomFornecedor = String.Empty Then
                WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RelatorioPrevisaoApuracaoFornecedorSintetico.rpt"
            End If
        End If

        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            If Validar() = False Then
                Exit Sub
            End If

            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = False

            ImprimirRelatorio()

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function FiltroSelecionado() As Decimal
        Try
            If Not (ucDiretoria.NomDiretoria = String.Empty) Then
                Return 1
            ElseIf Not (ucCelula.NomCelula = String.Empty) Then
                Return 2
            ElseIf Not (ucComprador.NomComprador = String.Empty) Then
                Return 3
            ElseIf Not (ucFornecedor.NomFornecedor = String.Empty) Then
                Return 4
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function


    Private Sub btnLimpar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpar.Click
        Try
            Response.Redirect("RelatorioPrevisaoApuracao.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ucDiretoria_DiretoriaAlterado(ByVal e As System.Web.UI.WebControls.ListItem) Handles ucDiretoria.DiretoriaAlterado
        ucCelula.setFocus()
    End Sub

    Private Sub ucCelula_CelulaAlterado(ByVal e As System.Web.UI.WebControls.ListItem) Handles ucCelula.CelulaAlterado
        ucComprador.setFocus()
    End Sub

    Private Sub ucComprador_CompradorAlterado(ByVal e As System.Web.UI.WebControls.ListItem) Handles ucComprador.CompradorAlterado
        ucFornecedor.setFocus()
    End Sub

    Private Sub ucFornecedor_FornecedorAlterado(ByVal e As System.Web.UI.WebControls.ListItem) Handles ucFornecedor.FornecedorAlterado
        Util.AdicionaJsFocus(Me.Page, Me.btImprimir)
    End Sub
End Class