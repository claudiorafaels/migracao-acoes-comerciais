Public Class RelatorioComparativoValores
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btImprimir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnVisualizar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents cmbContrato As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rdlRelatorio As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents cblOpcoes As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents cmbClausula As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmbMesReferencia As System.Web.UI.WebControls.DropDownList
    Protected WithEvents trClausula As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trMesReferencia As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents txtClausula As System.Web.UI.WebControls.TextBox
    Protected WithEvents Linkbutton1 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnImpNotasPeriodo As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnExpNotasPeriodo As System.Web.UI.WebControls.LinkButton
    Protected WithEvents TRImprimir As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents TRExportar As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents btnLimpar As System.Web.UI.WebControls.LinkButton

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
                TRImprimir.Visible = False
                TRExportar.Visible = False
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
        Dim mensagemErro As String = String.Empty

        Try
            Validar = True

            'Fornecedor
            If ucFornecedor.CodFornecedor <= 0 Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "fornecedor não informado"
            End If

            'Contrato
            If Not IsNumeric(cmbContrato.SelectedValue) Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "Não existe contrato para o fornecedor selecionado"
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

    Private Sub btImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImprimir.Click
        Try
            If Validar() = False Then
                Exit Sub
            End If

            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = True

            If rdlRelatorio.SelectedValue = "1" Then
                ImprimirAnalitico()
            ElseIf rdlRelatorio.SelectedValue = "2" Then
                ImprimirSintetico()
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ImprimirAnalitico()

        Dim NUMCTTFRN As Decimal = 0
        Dim INDDVRVLRAPUARDFRN As Decimal
        Dim TIPLMTHSTCFAARDFRN As Decimal
        Dim DATREFAPU As Date = Nothing
        Dim NUMCSLCTTFRN As Decimal = 0

        If IsNumeric(cmbContrato.SelectedValue) Then
            NUMCTTFRN = CType(cmbContrato.SelectedValue, Decimal)
        End If

        If cblOpcoes.SelectedValue = "2" Then
            TIPLMTHSTCFAARDFRN = 2
        Else
            TIPLMTHSTCFAARDFRN = 1
        End If

        If cblOpcoes.SelectedValue = "1" Then
            INDDVRVLRAPUARDFRN = 1
        Else
            INDDVRVLRAPUARDFRN = 0
        End If

        If IsDate(cmbMesReferencia.SelectedValue) Then
            DATREFAPU = CType(cmbMesReferencia.SelectedValue, Date)
        End If

        If IsNumeric(cmbClausula.SelectedValue) Then
            NUMCSLCTTFRN = CType(cmbClausula.SelectedValue, Decimal)
        End If

        If rdlRelatorio.SelectedValue = "1" Then 'Analítico
            ' Obter dados do relatório e guardar na seção
            WSCAcoesComerciais.dsRecuperacaoEPrevencaoPerdas = Controller.ObterRecuperacaoEPrevencaoPerdasAnalitico(NUMCTTFRN, INDDVRVLRAPUARDFRN, TIPLMTHSTCFAARDFRN, DATREFAPU, NUMCSLCTTFRN)
            ' Guarda o nome do relatório na seção
            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RelatorioComparativoValoresAnalitico.rpt"

        End If
        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

    Private Sub ImprimirSintetico()

        Dim NUMCTTFRN As Decimal
        Dim INDDVRVLRAPUARDFRN As Decimal
        Dim TIPLMTHSTCFAARDFRN As Decimal

        If IsNumeric(cmbContrato.SelectedValue) Then
            NUMCTTFRN = CType(cmbContrato.SelectedValue, Decimal)
        End If

        If cblOpcoes.SelectedValue = "2" Then
            TIPLMTHSTCFAARDFRN = 2
        Else
            TIPLMTHSTCFAARDFRN = 1
        End If

        If cblOpcoes.SelectedValue = "1" Then
            INDDVRVLRAPUARDFRN = 1
        Else
            INDDVRVLRAPUARDFRN = 0
        End If

        If rdlRelatorio.SelectedValue = "2" Then 'Sintético
            'Obter dados do relatório e guardar na seção
            WSCAcoesComerciais.dsRecuperacaoEPrevencaoPerdas = Controller.ObterRecuperacaoEPrevencaoPerdasSintetico(NUMCTTFRN, INDDVRVLRAPUARDFRN, TIPLMTHSTCFAARDFRN)
            'Guarda o nome do relatório na seção
            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RelatorioComparativoValoresSintetico.RPT"
        End If
        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

    Private Sub ImprimirNotasPeriodo()

        Dim NUMCTTFRN As Decimal
        Dim CODFRN As Decimal
        Dim htFormulas As New Hashtable

        If IsNumeric(cmbContrato.SelectedValue) Then
            NUMCTTFRN = CType(cmbContrato.SelectedValue, Decimal)
        End If

        If IsNumeric(ucFornecedor.CodFornecedor) Then
            CODFRN = ucFornecedor.CodFornecedor
        End If

        With htFormulas
            .Add("fornecedor", "'" & ucFornecedor.NomFornecedor & "'")
            .Add("contrato", "'" & cmbContrato.SelectedValue & "'")
        End With
        WSCAcoesComerciais.hashtableFormulasCrystal = htFormulas

        'Obter dados do relatório e guardar na seção
        WSCAcoesComerciais.dsRecuperacaoEPrevencaoPerdas = Controller.ObterNotasPeriodo(NUMCTTFRN, CODFRN)
        'Guarda o nome do relatório na seção
        WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RelatorioNotasPeriodo.RPT"
        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")

    End Sub

    Private Sub ucFornecedor_FornecedorAlterado(ByVal e As System.Web.UI.WebControls.ListItem) Handles ucFornecedor.FornecedorAlterado

        If ucFornecedor.CodFornecedor = 0 Then
            cmbContrato.Items.Clear()
            Exit Sub
        End If

        carregarContrato()
        carregarCombosAnalitico()

    End Sub

    Private Sub rdlRelatorio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdlRelatorio.SelectedIndexChanged

        carregarCombosAnalitico()

        If rdlRelatorio.SelectedValue = "2" Then
            trClausula.Visible = False
            trMesReferencia.Visible = False
        End If

    End Sub

    Private Sub carregarContrato()
        Dim datasetContrato As wsAcoesComerciais.DatasetContrato

        datasetContrato = Controller.ObterContratoComparativoValores(ucFornecedor.CodFornecedor)
        'Carrega Contrato
        With cmbContrato
            .DataSource = datasetContrato
            .DataMember = "ComparativoValores"
            .DataTextField = "NUMCTTFRN"
            .DataValueField = "NUMCTTFRN"
            .DataBind()
        End With

    End Sub

    Private Sub carregarMesReferencia()
        Dim datasetRecuperacaoEPrevencaoPerdas As wsRecuperacaoEPrevencaoPerdas.DatasetRecuperacaoEPrevencaoPerdas
        Dim NUMCTTFRN As Decimal = CType(cmbContrato.SelectedValue, Decimal)

        datasetRecuperacaoEPrevencaoPerdas = Controller.ObterRecuperacaoEPrevencaoPerdasDataApuracao(NUMCTTFRN)
        'Carrega Mes Referencia
        With cmbMesReferencia
            .DataSource = datasetRecuperacaoEPrevencaoPerdas
            .DataMember = "DataApuracao"
            .DataTextField = "DATREFAPU"
            .DataValueField = "DATREFAPU"
            .DataBind()
        End With

        cmbMesReferencia.Items.Insert(0, New ListItem("TODAS", "0"))

    End Sub

    Private Sub carregarClausulas()
        Dim datasetRecuperacaoEPrevencaoPerdas As wsRecuperacaoEPrevencaoPerdas.DatasetRecuperacaoEPrevencaoPerdas
        Dim NUMCTTFRN As Decimal = CType(cmbContrato.SelectedValue, Decimal)

        datasetRecuperacaoEPrevencaoPerdas = Controller.ObterRecuperacaoEPrevencaoPerdasClausulas(NUMCTTFRN)
        'Carrega Clausulas
        With cmbClausula
            .DataSource = datasetRecuperacaoEPrevencaoPerdas
            .DataMember = "Clausulas"
            .DataTextField = "DESCSLCTTFRN"
            .DataValueField = "NUMCSLCTTFRN"
            .DataBind()
        End With

        cmbClausula.Items.Insert(0, New ListItem("TODAS", "0"))
        txtClausula.Text = "TODAS"

    End Sub


    Private Sub cmbClausula_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbClausula.SelectedIndexChanged

        If cmbClausula.SelectedIndex = 0 Then
            txtClausula.Text = "TODAS"
        Else
            txtClausula.Text = cmbClausula.SelectedValue
        End If

    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            If Validar() = False Then
                Exit Sub
            End If

            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = False

            If rdlRelatorio.SelectedValue = "1" Then
                ImprimirAnalitico()
            ElseIf rdlRelatorio.SelectedValue = "2" Then
                ImprimirSintetico()
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub carregarCombosAnalitico()
        If rdlRelatorio.SelectedValue = "1" Then
            trClausula.Visible = True
            trMesReferencia.Visible = True
            If IsNumeric(cmbContrato.SelectedValue) Then
                carregarMesReferencia()
                carregarClausulas()
            End If
        End If
    End Sub

    Private Sub cblOpcoes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cblOpcoes.SelectedIndexChanged
        If cblOpcoes.Items(1).Selected Then
            TRImprimir.Visible = True
            TRExportar.Visible = True
        Else
            TRImprimir.Visible = False
            TRExportar.Visible = False
        End If
    End Sub

    Private Sub btnImpNotasPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImpNotasPeriodo.Click
        Try
            If Validar() = False Then
                Exit Sub
            End If

            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = True

            ImprimirNotasPeriodo()

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnExpNotasPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpNotasPeriodo.Click
        Try
            If Validar() = False Then
                Exit Sub
            End If

            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = False

            ImprimirNotasPeriodo()

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnLimpar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLimpar.Click
        Try
            Response.Redirect("RelatorioComparativoValores.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub


End Class