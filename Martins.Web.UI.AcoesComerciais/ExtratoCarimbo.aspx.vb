Public Class ExtratoCarimbo
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents cmbEmpenho As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents TD1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD2 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Tr1 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD4 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents btnImprimir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnVisualizar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents tblOpcao As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents cmbFilial As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmbFiltro As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents ucDiretoria As wucDiretoria
    Protected WithEvents ucCelula As wucCelula
    Protected WithEvents ucComprador As wucComprador
    Protected WithEvents trDiretoria As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trCelula As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trComprador As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trFornecedor As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trHistorico1 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trHistorico2 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trHistorico3 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trHistorico4 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trEmpenho As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trFiltro As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents txtDataInicial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataFinal As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescricao As System.Web.UI.WebControls.TextBox
    Protected WithEvents tblTipo As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ucMercadoria1 As ucMercadoria

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Dim controle As Controller
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            InicializarPagina()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
        'Put user code to initialize the page here
    End Sub

    Private Sub InicializarPagina()
        Try
            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            End If
            Me.cmbFiltro.Items.Remove(Me.cmbFiltro.Items.FindByValue("2")) ''deleta comprador
            If (Not IsPostBack) Then
                CarregaComboEmpenho()
                Util.carregarCmbFilial(Controller.ObterFiliais(1), Me.cmbFilial, New ListItem("TODOS", "0"))
                'Util.carregarCmbEmpenho(Controller.ObterEmpenhos("", "", "", 0, ""), Me.cmbEmpenho, New ListItem("Selecione", "0"))
                EscondeWebControls()
            End If
            btnCancelar.Attributes.Add("OnClick", "javascript:window.close()")
            btnImprimir.Attributes.Add("OnClick", "javascript:mostraAndamento()")
            btnVisualizar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub
    Private Sub CarregaComboEmpenho()
        Dim dstEmpenho As New wsAcoesComerciais.DatasetEmpenho
        dstEmpenho = Controller.ObterComboEmpenho(1)


        'With cmb
        '    .Items.Clear()
        '    For Each linha As wsAcoesComerciais.DatasetEmpenho.T0109059Row In ds.T0109059.Select("", "TIPDSNDSCBNF")
        '        .Items.Add(New ListItem(Format(linha.TIPDSNDSCBNF, "0000") & " - " & linha.DESDSNDSCBNF, linha.TIPDSNDSCBNF.ToString))
        '    Next
        '    If Not (listItemExtra Is Nothing) Then
        '        .Items.Insert(0, listItemExtra)
        '    End If
        'End With

        With cmbEmpenho
            .DataSource = dstEmpenho
            .DataMember = "T0109059Pesquisa"
            .DataTextField = "DESDSNDSCBNF".ToUpper
            .DataValueField = "TIPDSNDSCBNF"
            .DataBind()
            .Items.Insert(0, New ListItem("(Selecione)", "0"))
        End With
    End Sub

    Private Function Validar() As Boolean
        Dim mensagemErro As String = String.Empty


        If cmbEmpenho.SelectedIndex = 0 Then
            Page.RegisterStartupScript("Alerta", "<script>alert('" & " Selecione um empenho." & "');</script>")
            Return False
        End If

        If cmbFiltro.SelectedIndex = 0 Then
            Page.RegisterStartupScript("Alerta", "<script>alert('" & " Selecione um filtro. " & "');</script>")
            Return False
        End If

        Return True
    End Function

    Private Function ValidaHistorico() As Boolean
        If txtDataInicial.Text.Trim() = String.Empty Then
            Page.RegisterStartupScript("Alerta", "<script>alert('" & "Data Inicial Obrigatório!" & "');</script>")
            Return False
        End If
        If txtDataFinal.Text.Trim() = String.Empty Then
            Page.RegisterStartupScript("Alerta", "<script>alert('" & "Data Final Obrigatório!" & "');</script>")
            Return False
        End If
        If (Not txtDataInicial.Text.Trim = String.Empty) And (txtDataFinal.Text.Trim <> String.Empty) Then
            If IsDate(txtDataInicial.Text.Trim) Then
                If IsDate(txtDataFinal.Text.Trim) Then
                    If txtDataInicial.Text <> String.Empty AndAlso Date.Compare(CDate(txtDataInicial.Text), CDate(txtDataFinal.Text)) = 1 Then
                        Page.RegisterStartupScript("Alerta", "<script>alert('" & "Data Final deve ser maior que Data Inicial!" & "');</script>")
                        Return False
                    End If
                Else
                    Page.RegisterStartupScript("Alerta", "<script>alert('" & "Data Final Inválida!" & "');</script>")
                    Return False
                End If
            Else
                Page.RegisterStartupScript("Alerta", "<script>alert('" & "Data Inicial Inválida!" & "');</script>")
                Return False
            End If
        End If
        Return True
    End Function


    Private Sub cmbFiltro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFiltro.SelectedIndexChanged
        EscondeWebControls()
        If cmbFiltro.SelectedValue = "3" Then
            tblOpcao.Items.Item(0).Selected = True
            tblOpcao.Enabled = False
            Me.trDiretoria.Visible = True
        End If
        If cmbFiltro.SelectedValue = "1" Then
            tblOpcao.Enabled = True
            Me.trCelula.Visible = True
        End If
        If cmbFiltro.SelectedValue = "2" Then
            tblOpcao.Enabled = True
            trComprador.Visible = True
        End If
        If cmbFiltro.SelectedValue = "4" Then
            tblOpcao.Enabled = True
            trFornecedor.Visible = True
        End If
    End Sub
    Private Sub EscondeWebControls()
        trDiretoria.Visible = False
        trCelula.Visible = False
        trComprador.Visible = False
        trFornecedor.Visible = False
        trHistorico1.Visible = False
        trHistorico2.Visible = False
        trHistorico3.Visible = False
        trHistorico4.Visible = False
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            If Not tblOpcao.SelectedIndex = 2 Then
                If Validar() = False Then Exit Sub
                'Limpa as Formulas do relatorio que são guardadas na seção
                WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
                WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = True
                MontaRelatorio()
            Else
                If ValidaHistorico() = False Then Exit Sub
                WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
                WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = True
                MontaRelatorio()
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub
    Private Sub MontaRelatorioHistorico()
        ''colocar metodo para popular historico
    End Sub
    Private Sub MontaRelatorio()
        Dim Empenho As Integer = 0
        Dim Filial As Integer = 0
        Dim Celula As Integer = 0
        Dim Comprador As Integer = 0
        Dim Fornecedor As Integer = 0
        Dim Diretoria As Integer = 0
        Dim DataInicio As String = String.Empty
        Dim DataFim As String = String.Empty
        Dim Tipo As String = String.Empty
        Dim descricao As String = String.Empty
        Dim Mercadoria As Integer = 0
        Empenho = Convert.ToInt32(cmbEmpenho.SelectedValue)
        Filial = Convert.ToInt32(cmbFilial.SelectedValue)

        Try
            If tblOpcao.SelectedIndex = 2 Then
                DataInicio = txtDataInicial.Text.Trim
                DataFim = txtDataFinal.Text.Trim
                WSCAcoesComerciais.StringValue(WSCVar.Periodo) = txtDataInicial.Text.Trim + " - " + txtDataFinal.Text.Trim
                Filial = Convert.ToInt32(Me.cmbFilial.SelectedValue)
                WSCAcoesComerciais.StringValue(WSCVar.Filial) = cmbFilial.SelectedItem.Text.Trim.ToUpper
                If Me.tblTipo.SelectedValue = "t" Then
                    Tipo = ""
                Else
                    Tipo = tblTipo.SelectedValue
                End If
                WSCAcoesComerciais.StringValue(WSCVar.Tipo) = tblTipo.SelectedItem.Text.Trim.ToUpper


                If Not IsNothing(Me.ucDiretoria.CodDiretoria) Then
                    Diretoria = Convert.ToInt32(Me.ucDiretoria.CodDiretoria)
                    WSCAcoesComerciais.StringValue(WSCVar.Diretoria) = Me.ucDiretoria.NomDiretoria.ToUpper
                End If
                If Not IsNothing(Me.ucCelula.CodCelula) Then
                    Celula = Convert.ToInt32(Me.ucCelula.CodCelula)
                    WSCAcoesComerciais.StringValue(WSCVar.Celula) = Me.ucCelula.NomCelula.ToUpper
                End If
                If Not IsNothing(Me.ucComprador.CodComprador) Then
                    Comprador = Convert.ToInt32(Me.ucComprador.CodComprador)
                    WSCAcoesComerciais.StringValue(WSCVar.Comprador) = Me.ucComprador.NomComprador.ToUpper
                End If
                If Not IsNothing(Me.ucFornecedor.CodFornecedor) AndAlso IsNumeric(Me.ucFornecedor.CodFornecedor) Then
                    Fornecedor = Convert.ToInt32(Me.ucFornecedor.CodFornecedor)
                    WSCAcoesComerciais.StringValue(WSCVar.Fornecedor) = Me.ucFornecedor.NomFornecedor.ToUpper
                End If
                If Not IsNothing(Me.ucMercadoria1.CodMercadoria) Then
                    Mercadoria = Convert.ToInt32(Me.ucMercadoria1.CodMercadoria)
                    WSCAcoesComerciais.StringValue(WSCVar.Mercadoria) = Me.ucMercadoria1.NomMercadoria.ToUpper
                End If

                If Me.txtDescricao.Text.Trim <> String.Empty Then
                    descricao = txtDescricao.Text.Trim.ToUpper
                    WSCAcoesComerciais.StringValue(WSCVar.Descricao) = descricao
                End If

                Try
                    WSCAcoesComerciais.dsRelatorioHistorico = controle.ObterRelatorioHistorico(DataInicio, DataFim, Filial, Empenho, Celula, Comprador, Diretoria, Fornecedor, Mercadoria, Tipo, descricao)
                    WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RelatorioCarimboHistorico.rpt"
                    Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")

                Catch ex As Exception
                    Controller.TrataErro(Me.Page, ex)
                End Try
                Exit Sub
            End If

            If Validar() Then
                If Me.cmbFiltro.SelectedValue = "3" Then
                    Diretoria = Convert.ToInt32(Me.ucDiretoria.CodDiretoria)
                    WSCAcoesComerciais.StringValue(WSCVar.Filial) = Me.cmbFilial.SelectedItem.Text.Trim.ToUpper
                    WSCAcoesComerciais.StringValue(WSCVar.Empenho) = Me.cmbEmpenho.SelectedItem.Text.Trim.ToUpper
                    WSCAcoesComerciais.StringValue(WSCVar.Filtro) = Me.ucDiretoria.NomDiretoria.ToUpper
                    WSCAcoesComerciais.StringValue(WSCVar.labelFiltro) = "Diretoria :"
                    ImprimeDiretoria(Diretoria, Empenho, Filial)
                End If

                If tblOpcao.SelectedValue = "0" Then ' Sintetico
                    If Me.cmbFiltro.SelectedValue = "1" Then
                        Celula = Convert.ToInt32(Me.ucCelula.CodCelula)
                        WSCAcoesComerciais.StringValue(WSCVar.Filial) = Me.cmbFilial.SelectedItem.Text.Trim.ToUpper
                        WSCAcoesComerciais.StringValue(WSCVar.Empenho) = Me.cmbEmpenho.SelectedItem.Text.Trim.ToUpper
                        WSCAcoesComerciais.StringValue(WSCVar.Filtro) = Me.ucCelula.NomCelula.ToUpper
                        WSCAcoesComerciais.StringValue(WSCVar.labelFiltro) = "Célula :"
                        ImprimirSintetico(Empenho, Filial, Celula, Fornecedor, Comprador)
                    End If
                    If Me.cmbFiltro.SelectedValue = "2" Then
                        Comprador = Convert.ToInt32(Me.ucComprador.CodComprador)
                        WSCAcoesComerciais.StringValue(WSCVar.Filial) = Me.cmbFilial.SelectedItem.Text.Trim.ToUpper
                        WSCAcoesComerciais.StringValue(WSCVar.Empenho) = Me.cmbEmpenho.SelectedItem.Text.Trim.ToUpper
                        WSCAcoesComerciais.StringValue(WSCVar.Filtro) = Me.ucComprador.NomComprador.ToUpper
                        WSCAcoesComerciais.StringValue(WSCVar.labelFiltro) = "Comprador :"
                        ImprimirSintetico(Empenho, Filial, Celula, Fornecedor, Comprador)
                    End If
                    If Me.cmbFiltro.SelectedValue = "4" Then
                        Fornecedor = Convert.ToInt32(Me.ucFornecedor.CodFornecedor)
                        WSCAcoesComerciais.StringValue(WSCVar.Filial) = Me.cmbFilial.SelectedItem.Text.Trim.ToUpper
                        WSCAcoesComerciais.StringValue(WSCVar.Empenho) = Me.cmbEmpenho.SelectedItem.Text.Trim.ToUpper
                        WSCAcoesComerciais.StringValue(WSCVar.Filtro) = Me.ucFornecedor.NomFornecedor.ToUpper
                        WSCAcoesComerciais.StringValue(WSCVar.labelFiltro) = "Fornecedor :"
                        ImprimirSintetico(Empenho, Filial, Celula, Fornecedor, Comprador)
                    End If
                ElseIf tblOpcao.SelectedValue = "1" Then 'Analitico
                    If Me.cmbFiltro.SelectedValue = "1" Then
                        Celula = Convert.ToInt32(Me.ucCelula.CodCelula)
                        WSCAcoesComerciais.StringValue(WSCVar.Filial) = Me.cmbFilial.SelectedItem.Text.Trim.ToUpper
                        WSCAcoesComerciais.StringValue(WSCVar.Empenho) = Me.cmbEmpenho.SelectedItem.Text.Trim.ToUpper
                        WSCAcoesComerciais.StringValue(WSCVar.Filtro) = Me.ucCelula.NomCelula.ToUpper
                        WSCAcoesComerciais.StringValue(WSCVar.labelFiltro) = "Célula :"
                        ImprimirAnalitico(Empenho, Filial, Celula, Fornecedor, Comprador)
                    End If
                    If Me.cmbFiltro.SelectedValue = "2" Then
                        Comprador = Convert.ToInt32(Me.ucComprador.CodComprador)
                        WSCAcoesComerciais.StringValue(WSCVar.Filial) = Me.cmbFilial.SelectedItem.Text.Trim.ToUpper
                        WSCAcoesComerciais.StringValue(WSCVar.Empenho) = Me.cmbEmpenho.SelectedItem.Text.Trim.ToUpper
                        WSCAcoesComerciais.StringValue(WSCVar.Filtro) = Me.ucComprador.NomComprador.ToUpper
                        WSCAcoesComerciais.StringValue(WSCVar.labelFiltro) = "Comprador :"
                        ImprimirAnalitico(Empenho, Filial, Celula, Fornecedor, Comprador)
                    End If
                    If Me.cmbFiltro.SelectedValue = "4" Then
                        Fornecedor = Convert.ToInt32(Me.ucFornecedor.CodFornecedor)
                        WSCAcoesComerciais.StringValue(WSCVar.Filial) = Me.cmbFilial.SelectedItem.Text.Trim.ToUpper
                        WSCAcoesComerciais.StringValue(WSCVar.Empenho) = Me.cmbEmpenho.SelectedItem.Text.Trim.ToUpper
                        WSCAcoesComerciais.StringValue(WSCVar.Filtro) = Me.ucFornecedor.NomFornecedor.ToUpper
                        WSCAcoesComerciais.StringValue(WSCVar.labelFiltro) = "Fornecedor :"
                        ImprimirAnalitico(Empenho, Filial, Celula, Fornecedor, Comprador)
                    End If
                ElseIf tblOpcao.SelectedValue = "2" Then
                    'historico
                End If
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = False
        MontaRelatorio()
    End Sub

    Private Sub ImprimeDiretoria(ByVal Diretoria As Integer, ByVal Empenho As Integer, ByVal Filial As Integer)
        Try
            WSCAcoesComerciais.dsRelatorioCarimbo = controle.ObterRelatorioCarimboDiretoria(Diretoria, Empenho, Filial)
            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RelatorioCarimbo.rpt"
            Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ImprimirAnalitico(ByVal Empenho As Integer, ByVal Filial As Integer, ByVal Celula As Integer, ByVal Fornecedor As Integer, ByVal Comprador As Integer)

        Try
            WSCAcoesComerciais.dsRelatorioCarimbo = controle.ObterRelatorioFiltroAnalitico(Empenho, Filial, Celula, Fornecedor, Comprador)
            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RelatorioCarimboAnalitico.rpt"
            Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ImprimirSintetico(ByVal Empenho As Integer, ByVal Filial As Integer, ByVal Celula As Integer, ByVal Fornecedor As Integer, ByVal Comprador As Integer)
        Try
            WSCAcoesComerciais.dsRelatorioCarimbo = controle.ObterRelatorioFiltroSintetico(Empenho, Filial, Celula, Fornecedor, Comprador)
            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RelatorioCarimboSintetico.rpt"
            Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnVisualizaRelatorio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WSCAcoesComerciais.dsRelatorioCarimbo = controle.ObterRelatorioFiltroSintetico(98, 1, 14, 0, 0)
        WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RelatorioCarimboSintetico.rpt"
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

    Private Sub tblOpcao_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblOpcao.SelectedIndexChanged
        EscondeWebControls()
        If tblOpcao.SelectedValue = "2" Then
            habilitaHistorico()
        Else
            trFiltro.Visible = True
            trEmpenho.Visible = True
            Me.cmbFiltro.SelectedIndex = 0
            Me.cmbFiltro.SelectedIndex = 0
            Me.cmbEmpenho.SelectedIndex = 0
        End If

    End Sub

    Private Sub habilitaHistorico()
        trHistorico1.Visible = True
        trHistorico2.Visible = True
        trHistorico3.Visible = True
        trHistorico4.Visible = True
        trDiretoria.Visible = True
        trCelula.Visible = True
        trComprador.Visible = True
        trFornecedor.Visible = True
        trFiltro.Visible = False
        trEmpenho.Visible = False
    End Sub
End Class
