Public Class AcordosCanceladosPerdas
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetRecuperacaoEPrevencaoPerdas1 = New Martins.Web.UI.AcoesComerciais.wsRecuperacaoEPrevencaoPerdas.DatasetRecuperacaoEPrevencaoPerdas
        CType(Me.DatasetRecuperacaoEPrevencaoPerdas1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetRecuperacaoEPrevencaoPerdas1
        '
        Me.DatasetRecuperacaoEPrevencaoPerdas1.DataSetName = "DatasetRecuperacaoEPrevencaoPerdas"
        Me.DatasetRecuperacaoEPrevencaoPerdas1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetRecuperacaoEPrevencaoPerdas1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btImprimir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnVisualizar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents DatasetRecuperacaoEPrevencaoPerdas1 As Martins.Web.UI.AcoesComerciais.wsRecuperacaoEPrevencaoPerdas.DatasetRecuperacaoEPrevencaoPerdas
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents txtDataInicial As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtDataFinal As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD3 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD11 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents WucComprador As wucComprador
    Protected WithEvents WucCelula As wucCelula
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
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
                WucComprador.widthNome = System.Web.UI.WebControls.Unit.Parse("280px")
                WucCelula.widthNome = System.Web.UI.WebControls.Unit.Parse("280px")
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
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = String.Empty

        Try
            Validar = True

            'Período
            If Not (IsDate(txtDataInicial.Text)) Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "período incial não informada ou inválida"
            ElseIf Not (IsDate(txtDataFinal.Text)) Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "período final não informada ou inválida"
            ElseIf Date.Parse(txtDataInicial.Text) > Date.Parse(txtDataFinal.Text) Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "data inicial do período maior que data final"
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

        Dim DATAINICIAL As Date = Nothing
        Dim DATAFINAL As Date = Nothing
        Dim CODFRN As Decimal
        Dim CODCPR As Decimal
        Dim CODDIVCMP As Decimal

        If IsDate(txtDataInicial.Text) Then
            DATAINICIAL = CType(txtDataInicial.Text, Date)
        End If

        If IsDate(txtDataFinal.Text) Then
            DATAFINAL = CType(txtDataFinal.Text, Date)
        End If

        If ucFornecedor.CodFornecedor > 0 Then
            CODFRN = ucFornecedor.CodFornecedor
        Else
            CODFRN = 0
        End If

        If WucComprador.CodComprador > 0 Then
            CODCPR = WucComprador.CodComprador
        Else
            CODCPR = 0
        End If

        If WucCelula.CodCelula > 0 Then
            CODDIVCMP = WucCelula.CodCelula
        Else
            CODDIVCMP = 0
        End If

        ' Obter dados do relatório e guardar na seção
        WSCAcoesComerciais.dsRecuperacaoEPrevencaoPerdas = Controller.ObterAcordosCanceladosPerdas(DATAINICIAL, DATAFINAL, CODFRN, CODCPR, CODDIVCMP)
        ' Guarda o nome do relatório na seção
        WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RelatorioAcordosCanceladosPerdas.rpt"

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

    Private Sub btnLimpar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLimpar.Click
        Try
            Response.Redirect("RelatorioAcordosCanceladosPerdas.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub
End Class