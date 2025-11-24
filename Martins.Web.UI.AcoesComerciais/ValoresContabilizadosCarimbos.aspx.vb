Imports System.Globalization
Public Class ValoresContabilizadosCarimbos
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnImprimir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnVisualizar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Tr1 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trHistorico1 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trHistorico3 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trDataGeracaoAcordo As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents txtDataPrevisaoRecebimentos As System.Web.UI.WebControls.TextBox
    Protected WithEvents trDataPrevisaoRecebimentos As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents UcFornecedor1 As ucFornecedor
    Protected WithEvents tblValoresReceber As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblFornecedor As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblValoresRecebidos As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblTipoRelatorio As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents ddlTipoLancamento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rdbRelatorio As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rdbTipoRelatorio As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddlDestino As System.Web.UI.WebControls.DropDownList
    Protected WithEvents tblDestino As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents ddlAnoMesReferencia As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlDataInicio As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlDataFim As System.Web.UI.WebControls.DropDownList
    Protected WithEvents tblPeriodo As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblPeriodoAnoMes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents txtFilial As System.Web.UI.WebControls.TextBox
    Protected WithEvents tblFilial As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblMercadoria As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents txtDataInicial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataFinal As System.Web.UI.WebControls.TextBox
    Protected WithEvents UcMercadoria1 As ucMercadoria
    Protected WithEvents rblTipDsnDscBnf As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents tblRadioTipoDestinoDesconto As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents ddlObjetivoVerba As System.Web.UI.WebControls.DropDownList
    Protected WithEvents tblObjetivoVerba As System.Web.UI.HtmlControls.HtmlTable


    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "Eventos"
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            InicializarPagina()
            'Dim culture As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("pt-BR")
            'System.Threading.Thread.CurrentThread.CurrentCulture = culture

            'System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
            'System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
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

            If (Not IsPostBack) Then
                PopulaComboObjetivoVerba()
                EscondeWebControls()
                carregaComboAnoMesRef()
            End If
            btnCancelar.Attributes.Add("OnClick", "javascript:window.close()")
            btnImprimir.Attributes.Add("OnClick", "javascript:mostraAndamento()")
            btnVisualizar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub


    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If Not validar() Then
            Exit Sub
        End If
        WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = True
        MontaRelatorio()
    End Sub

#End Region

#Region "Métodos"

    Private Sub MontaRelatorio()
        Select Case rdbRelatorio.SelectedIndex
            Case 0
                If validaValoresReceber() Then
                    ImprimeValoresReceber()
                End If
            Case 1
                If validaPerido() Then
                    ImprimeValoresRecebidos()
                End If
            Case 2
                If validaPerido() Then
                    ImprimeVerbasCarimbadasRealizado()
                End If
            Case 3
                If validaPerido() Then
                    ImprimeVerbasCarimbadasCancelado()
                End If
            Case 4
                If validaPerido() Then
                    ImprimeNovosAcordos()
                End If
            Case 5
                If validaPerido() Then
                    ImprimeAcordosCancelados()
                End If
            Case 6
                If validaVendaCarimboXPendenteFaturar() Then
                    ImprimeRValorVendaCarimboXPendenteFaturar()
                End If
            Case 7
                If validaPerido() Then
                    ValoresRealizadosFundingCarimbo()
                End If
        End Select

    End Sub

    Private Sub ImprimeValoresReceber()
        Dim isSintatico As Boolean = False
        Dim fornecedor As Integer


        Dim anoMesRef As String = Me.ddlAnoMesReferencia.SelectedValue
        Dim dataPrevisaoRecebimento As String = Me.txtDataPrevisaoRecebimentos.Text
        Dim isCarimbados As Boolean = rblTipDsnDscBnf.SelectedIndex = 0

        WSCAcoesComerciais.StringValue(WSCVar.TipoDesconto) = Me.ddlObjetivoVerba.SelectedItem.Text

        WSCAcoesComerciais.StringValue(WSCVar.DataGeracaoAcordo) = anoMesRef
        WSCAcoesComerciais.StringValue(WSCVar.DataPrevisaoRecebimento) = Me.txtDataPrevisaoRecebimentos.Text.Trim

        If Me.rdbTipoRelatorio.SelectedIndex = 0 Then isSintatico = True

        If Not IsNothing(Me.UcFornecedor1.CodFornecedor) AndAlso IsNumeric(Me.UcFornecedor1.CodFornecedor) Then
            fornecedor = Convert.ToInt32(Me.UcFornecedor1.CodFornecedor)
            WSCAcoesComerciais.StringValue(WSCVar.Fornecedor) = Me.UcFornecedor1.NomFornecedor.ToUpper
        End If

        Dim tipoObjetivoVerba As Integer = 0

        tipoObjetivoVerba = Convert.ToInt32(ddlObjetivoVerba.SelectedValue)


        Try
            WSCAcoesComerciais.dsValoresContabilizadosCarimbos = Controller.ObterRelatorioValoresReceber(anoMesRef, dataPrevisaoRecebimento, fornecedor, tipoObjetivoVerba, isSintatico, isCarimbados)

            If isSintatico Then
                WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RELATORIOVALORESRECEBERSINTETICO.RPT"
            Else
                WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RELATORIOVALORESRECEBERANALITICO.RPT"
            End If
            Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ImprimeValoresRecebidos()
        Dim isSintatico As Boolean = False
        Dim fornecedor As Integer
        Dim tipoLancamento As String

        Dim dataInicio As String = Me.txtDataInicial.Text
        Dim dataFim As String = Me.txtDataFinal.Text
        Dim flCarimbados As Boolean = rblTipDsnDscBnf.SelectedIndex = 0
        WSCAcoesComerciais.StringValue(WSCVar.Filtro) = txtDataInicial.Text.Trim + " a " + txtDataFinal.Text.Trim
        tipoLancamento = Me.ddlTipoLancamento.SelectedValue
        WSCAcoesComerciais.StringValue(WSCVar.TipoDesconto) = Me.ddlObjetivoVerba.SelectedItem.Text
        If Me.rdbTipoRelatorio.SelectedIndex = 0 Then isSintatico = True

        If Not IsNothing(Me.UcFornecedor1.CodFornecedor) AndAlso IsNumeric(Me.UcFornecedor1.CodFornecedor) Then
            fornecedor = Convert.ToInt32(Me.UcFornecedor1.CodFornecedor)
            WSCAcoesComerciais.StringValue(WSCVar.Fornecedor) = Me.UcFornecedor1.NomFornecedor.ToUpper
        End If


        Dim tipoObjetivoVerba As Integer = 0

        tipoObjetivoVerba = Convert.ToInt32(ddlObjetivoVerba.SelectedValue)


        Try
            WSCAcoesComerciais.dsValoresContabilizadosCarimbos = Controller.ObterRelatorioValoresRecebidos(dataInicio, dataFim, fornecedor, tipoLancamento, tipoObjetivoVerba, isSintatico, flCarimbados)

            If isSintatico Then
                WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RELATORIOVALORESRECEBIDOSSINTETICO.RPT"
            Else
                WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RELATORIOVALORESRECEBIDOSANALITICO.RPT"
            End If
            Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ImprimeRValorVendaCarimboXPendenteFaturar()
        Dim isSintatico As Boolean = False
        Dim mercadoria As Integer = 0
        Dim filial As Integer = 0
        Dim dataInicio As String = Me.ddlDataInicio.SelectedValue
        Dim datafim As String = Me.ddlDataFim.SelectedValue


        WSCAcoesComerciais.StringValue(WSCVar.DataInicio) = dataInicio
        WSCAcoesComerciais.StringValue(WSCVar.DataFim) = datafim


        WSCAcoesComerciais.StringValue(WSCVar.Filtro) = dataInicio.Insert(4, "/") + " a " + datafim.Insert(4, "/")
        If Me.rdbTipoRelatorio.SelectedIndex = 0 Then isSintatico = True

        If Not IsNothing(Me.UcMercadoria1.CodMercadoria) AndAlso IsNumeric(Me.UcMercadoria1.CodMercadoria) Then
            mercadoria = Convert.ToInt32(Me.UcMercadoria1.CodMercadoria)
            WSCAcoesComerciais.DecimalValue(WSCVar.Mercadoria) = mercadoria
        End If
        If Me.txtFilial.Text <> String.Empty Then
            filial = Convert.ToInt32(Me.txtFilial.Text)
        End If

        Try
            'dataInicio = "201006"
            'datafim = "201006"
            WSCAcoesComerciais.dsValoresContabilizadosCarimbos = Controller.ObterRValorVendaCarimboXPendenteFaturar(dataInicio, datafim, mercadoria, filial, isSintatico)

            If isSintatico Then
                WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RELATORIOCARIMBOXPENDENTEFATURARSINT.RPT"
            Else
                WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RELATORIOCARIMBOXPENDENTEFATURARANA.RPT"
            End If
            Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ImprimeVerbasCarimbadasRealizado()
        Dim isSintatico As Boolean = False
        Dim fornecedor As Integer
        Dim destino As Integer

        Dim dataInicio As String = Me.txtDataInicial.Text
        Dim dataFim As String = Me.txtDataFinal.Text

        WSCAcoesComerciais.StringValue(WSCVar.Filtro) = txtDataInicial.Text.Trim + " a " + txtDataFinal.Text.Trim
        destino = Convert.ToInt32(Me.ddlDestino.SelectedValue)

        If Me.rdbTipoRelatorio.SelectedIndex = 0 Then isSintatico = True

        If Not IsNothing(Me.UcFornecedor1.CodFornecedor) AndAlso IsNumeric(Me.UcFornecedor1.CodFornecedor) Then
            fornecedor = Convert.ToInt32(Me.UcFornecedor1.CodFornecedor)
            WSCAcoesComerciais.StringValue(WSCVar.Fornecedor) = Me.UcFornecedor1.NomFornecedor.ToUpper
        End If

        Try
            WSCAcoesComerciais.dsVerbasCarimbadas = Controller.ObterRelatorioVerbasCarimbadasRealizado(dataInicio, dataFim, destino, fornecedor, isSintatico)

            If isSintatico Then
                WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RELATORIOVERBASCARIMBADASREALIZADOSINTETICO.RPT"
            Else
                WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RELATORIOVERBASCARIMBADASREALIZADOANALITICO.RPT"
            End If
            Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ImprimeVerbasCarimbadasCancelado()
        Dim isSintatico As Boolean = False
        Dim fornecedor As Integer
        Dim destino As Integer

        Dim dataInicio As String = Me.txtDataInicial.Text
        Dim dataFim As String = Me.txtDataFinal.Text

        WSCAcoesComerciais.StringValue(WSCVar.Filtro) = txtDataInicial.Text.Trim + " a " + txtDataFinal.Text.Trim
        destino = Convert.ToInt32(Me.ddlDestino.SelectedValue)

        If Me.rdbTipoRelatorio.SelectedIndex = 0 Then isSintatico = True

        If Not IsNothing(Me.UcFornecedor1.CodFornecedor) AndAlso IsNumeric(Me.UcFornecedor1.CodFornecedor) Then
            fornecedor = Convert.ToInt32(Me.UcFornecedor1.CodFornecedor)
            WSCAcoesComerciais.StringValue(WSCVar.Fornecedor) = Me.UcFornecedor1.NomFornecedor.ToUpper
        End If

        Try
            WSCAcoesComerciais.dsVerbasCarimbadas = Controller.ObterRelatorioVerbasCarimbadasCancelado(dataInicio, dataFim, destino, fornecedor, isSintatico)

            If isSintatico Then
                WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RELATORIOVERBASCARIMBADASCANCELADOSINTETICO.RPT"
            Else
                WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RELATORIOVERBASCARIMBADASCANCELADOANALITICO.RPT"
            End If
            Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ImprimeNovosAcordos()
        Dim isSintatico As Boolean = False
        Dim fornecedor As Integer
        Dim Sum1 As Decimal = 0
        Dim sum2 As Decimal = 0
        Dim dst As wsAcoesComerciais.DataSetRelatorioAcordos
        Dim dataInicio As String = Me.txtDataInicial.Text
        Dim dataFim As String = Me.txtDataFinal.Text

        WSCAcoesComerciais.StringValue(WSCVar.Filtro) = txtDataInicial.Text.Trim + " a " + txtDataFinal.Text.Trim

        If Me.rdbTipoRelatorio.SelectedIndex = 0 Then isSintatico = True

        If Not IsNothing(Me.UcFornecedor1.CodFornecedor) AndAlso IsNumeric(Me.UcFornecedor1.CodFornecedor) Then
            fornecedor = Convert.ToInt32(Me.UcFornecedor1.CodFornecedor)
            WSCAcoesComerciais.StringValue(WSCVar.Fornecedor) = Me.UcFornecedor1.NomFornecedor.ToUpper
        End If

        Try
            WSCAcoesComerciais.dsAcordos = Controller.ObterRelatorioNovosAcordos(dataInicio, dataFim, fornecedor, isSintatico)
            dst = WSCAcoesComerciais.dsAcordos
            If isSintatico Then
                WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RELATORIONOVOSACORDOSSINTETICO.RPT"
            Else
                WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RELATORIONOVOSACORDOSANALITICO.RPT"
            End If
            Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ImprimeAcordosCancelados()
        Dim isSintatico As Boolean = False
        Dim fornecedor As Integer

        Dim dataInicio As String = Me.txtDataInicial.Text
        Dim dataFim As String = Me.txtDataFinal.Text

        WSCAcoesComerciais.StringValue(WSCVar.Filtro) = txtDataInicial.Text.Trim + " a " + txtDataFinal.Text.Trim

        If Me.rdbTipoRelatorio.SelectedIndex = 0 Then isSintatico = True

        If Not IsNothing(Me.UcFornecedor1.CodFornecedor) AndAlso IsNumeric(Me.UcFornecedor1.CodFornecedor) Then
            fornecedor = Convert.ToInt32(Me.UcFornecedor1.CodFornecedor)
            WSCAcoesComerciais.StringValue(WSCVar.Fornecedor) = Me.UcFornecedor1.NomFornecedor.ToUpper
        End If


        Try
            WSCAcoesComerciais.dsAcordos = Controller.ObterRelatorioAcordosCancelados(dataInicio, dataFim, fornecedor, isSintatico)

            If isSintatico Then
                WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RELATORIOACORDOSCANCELADOSSINTETICO.RPT"
            Else
                WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RELATORIOACORDOSCANCELADOSANALITICO.RPT"
            End If
            Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub
    Private Sub ValoresRealizadosFundingCarimbo()
        Dim fornecedor As Integer


        Dim dataInicio As String = Me.txtDataInicial.Text
        Dim dataFim As String = Me.txtDataFinal.Text

        WSCAcoesComerciais.StringValue(WSCVar.Filtro) = txtDataInicial.Text.Trim + " a " + txtDataFinal.Text.Trim

        If Not IsNothing(Me.UcFornecedor1.CodFornecedor) AndAlso IsNumeric(Me.UcFornecedor1.CodFornecedor) Then
            fornecedor = Convert.ToInt32(Me.UcFornecedor1.CodFornecedor)
            WSCAcoesComerciais.StringValue(WSCVar.Fornecedor) = Me.UcFornecedor1.NomFornecedor.ToUpper
        End If

        Try
            WSCAcoesComerciais.dsValoresContabilizadosCarimbos = Controller.ObterValoresRealizadosFundingCarimbo(dataInicio, dataFim, fornecedor)
            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "RELATORIOVALORESREALIZADOSFUNGINDANALITICO.RPT"
            Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function validar() As Boolean
        'If Me.txtDataGeracaoAcordo.Text = String.Empty And Me.txtDataPrevisaoRecebimentos.Text = String.Empty Then
        '    Util.AdicionaJsAlert(Me.Page, "")
        '    Return False
        'End If     

        If Not Me.rdbRelatorio.SelectedIndex >= 0 Then
            Util.AdicionaJsAlert(Me.Page, "Selecionar Relatório")
            Return False
        End If

        Return True
    End Function

    Private Function validaValoresReceber() As Boolean
        Dim DataPrevisao As Date = Nothing
        Dim DataGeracaoAcordo As Date = Nothing
        Try
            If Me.txtDataPrevisaoRecebimentos.Text.Length = 10 Then DataPrevisao = CDate(Me.txtDataPrevisaoRecebimentos.Text.Trim)
            If Me.ddlAnoMesReferencia.SelectedIndex <> 0 Then DataGeracaoAcordo = New Date(Convert.ToInt32(ddlAnoMesReferencia.SelectedValue.Substring(0, 4)), Convert.ToInt32(ddlAnoMesReferencia.SelectedValue.Substring(4, 2)), Now.Day)

            'If DataGeracaoAcordo <> Nothing Then
            '    If Not DataGeracaoAcordo <= Date.Now Then
            '        Util.AdicionaJsAlert(Me.Page, "Data da geração do acordo deve ser menor ou igual a data atual")
            '        Return False
            '    End If
            If DataPrevisao = Nothing And Me.ddlAnoMesReferencia.SelectedIndex = 0 Then
                Util.AdicionaJsAlert(Me.Page, "É obrigatório escolher pelo menos uma data.")
                Return False
            End If
            Return True
        Catch ex As Exception
            Util.AdicionaJsAlert(Me.Page, "Data Inválida")
        End Try
    End Function

    Public Function validaPerido() As Boolean
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

    Private Sub EscondeWebControls()
        Me.tblValoresReceber.Visible = False
        Me.tblRadioTipoDestinoDesconto.Visible = False
        Me.tblValoresRecebidos.Visible = False
        Me.tblTipoRelatorio.Visible = False
        Me.tblPeriodo.Visible = False
        Me.tblFornecedor.Visible = False
        Me.tblDestino.Visible = False
        Me.tblPeriodoAnoMes.Visible = False
        Me.tblMercadoria.Visible = False
        Me.tblFilial.Visible = False
        Me.tblObjetivoVerba.Visible = False
    End Sub

    Private Sub carregaComboAnoMesRef()
        Dim ds As New wsAcoesComerciais.DataSetValoresContabilizadosCarimbosRelatorio
        ds = Controller.ObterComboAnoMesRef()
        With Me.ddlAnoMesReferencia
            .DataSource = ds
            .DataMember = ds.TBComboAnoMesRef.TableName
            .DataTextField = "AnoMesRef"
            .DataValueField = "AnoMesRef"
            .DataBind()
            .Items.Insert(0, New ListItem("(Selecione)", "0"))
        End With

        With Me.ddlDataInicio
            .DataSource = ds
            .DataMember = ds.TBComboAnoMesRef.TableName
            .DataTextField = "AnoMesRef"
            .DataValueField = "AnoMesRef"
            .DataBind()
            .Items.Insert(0, New ListItem("(Selecione)", "0"))
        End With

        With Me.ddlDataFim
            .DataSource = ds
            .DataMember = ds.TBComboAnoMesRef.TableName
            .DataTextField = "AnoMesRef"
            .DataValueField = "AnoMesRef"
            .DataBind()
            .Items.Insert(0, New ListItem("(Selecione)", "0"))
        End With



    End Sub

    Private Sub PopulaComboObjetivoVerba()

        Dim ds As DataSet = Controller.ObterTiposObjetivoVerbaAtivo()

        ddlObjetivoVerba.Items.Clear()
        Dim i As Integer = 0
        For Each row As DataRow In ds.Tables("CADOBJDSNVBA").Rows
            ddlObjetivoVerba.Items.Insert(i, New ListItem(row("TIPOBJDSNVBA").ToString().PadLeft(2, "0"c) & " - " & row("DESOBJDSNVBA").ToString().Trim().ToUpper(), row("TIPOBJDSNVBA").ToString()))
            i = i + 1
        Next

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        If Not validar() Then
            Exit Sub
        End If
        WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = False
        MontaRelatorio()
    End Sub

    Private Sub rdbRelatorio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbRelatorio.SelectedIndexChanged
        Me.tblRadioTipoDestinoDesconto.Visible = False
        If Me.rdbRelatorio.SelectedIndex = 0 Then
            EscondeWebControls()
            Me.tblTipoRelatorio.Visible = True
            Me.tblValoresReceber.Visible = True
            Me.tblFornecedor.Visible = True
            Me.ddlAnoMesReferencia.SelectedIndex = 0
            Me.tblObjetivoVerba.Visible = True
            Me.tblRadioTipoDestinoDesconto.Visible = False
        End If
        If Me.rdbRelatorio.SelectedIndex = 1 Then
            EscondeWebControls()
            Me.tblValoresRecebidos.Visible = True
            Me.tblPeriodo.Visible = True
            Me.tblFornecedor.Visible = True
            Me.tblTipoRelatorio.Visible = True
            Me.tblRadioTipoDestinoDesconto.Visible = False
            Me.tblObjetivoVerba.Visible = True
            preenchePeriodo()
        End If
        If Me.rdbRelatorio.SelectedIndex = 2 Then
            EscondeWebControls()
            Me.tblTipoRelatorio.Visible = True
            Me.tblPeriodo.Visible = True
            Me.tblDestino.Visible = True
            Me.tblFornecedor.Visible = True
            Me.tblObjetivoVerba.Visible = False
            preenchePeriodo()
        End If
        If Me.rdbRelatorio.SelectedIndex = 3 Then
            EscondeWebControls()
            Me.tblTipoRelatorio.Visible = True
            Me.tblPeriodo.Visible = True
            Me.tblDestino.Visible = True
            Me.tblFornecedor.Visible = True
            Me.tblObjetivoVerba.Visible = False
            preenchePeriodo()
        End If
        If Me.rdbRelatorio.SelectedIndex = 4 Then
            EscondeWebControls()
            Me.tblTipoRelatorio.Visible = True
            Me.tblPeriodo.Visible = True
            Me.tblFornecedor.Visible = True
            Me.tblObjetivoVerba.Visible = False
            preenchePeriodo()
        End If
        If Me.rdbRelatorio.SelectedIndex = 5 Then
            EscondeWebControls()
            Me.tblTipoRelatorio.Visible = True
            Me.tblPeriodo.Visible = True
            Me.tblFornecedor.Visible = True
            Me.tblObjetivoVerba.Visible = False
            preenchePeriodo()
        End If
        If Me.rdbRelatorio.SelectedIndex = 6 Then
            EscondeWebControls()
            Me.tblTipoRelatorio.Visible = True
            Me.tblPeriodoAnoMes.Visible = True
            Me.tblMercadoria.Visible = True
            Me.tblObjetivoVerba.Visible = False
            Me.tblFilial.Visible = True
        End If
        If Me.rdbRelatorio.SelectedIndex = 7 Then
            EscondeWebControls()
            Me.tblTipoRelatorio.Visible = True
            Me.rdbTipoRelatorio.SelectedIndex = 1
            Me.rdbTipoRelatorio.Enabled = False
            Me.tblPeriodo.Visible = True
            Me.tblFornecedor.Visible = True
            Me.tblObjetivoVerba.Visible = False
        End If
    End Sub

    Private Sub preenchePeriodo()
        Dim dataInicio As String
        Dim dataFim As String
        Dim dia As Integer
        Dim mes As Integer
        Dim ano As Integer

        If Date.Now.Month = 1 Then
            dia = Date.Now.Day
            mes = 12
            ano = Date.Now.Year - 1
        Else
            dia = Date.Now.Day
            ano = Date.Now.Year
            mes = Date.Now.Month - 1
            Select Case mes
                Case 2
                    If Date.Now.IsLeapYear(Date.Now.Year) And Date.Now.Day > 29 Then
                        dia = 29
                        ano = Date.Now.Year
                    ElseIf Not Date.Now.IsLeapYear(Date.Now.Year) And Date.Now.Day > 28 Then

                        dia = 28
                        ano = Date.Now.Year
                    End If
                Case 4, 6, 9, 11
                    dia = 30
                    ano = Date.Now.Year
                Case 1, 3, 5, 7, 8, 10, 12
                    dia = 31
            End Select
        End If

        Dim mesString As String = mes.ToString
        If mes < 10 Then
            mesString = String.Concat("0", mes)
        End If

        dataInicio = String.Concat("01", "/", mesString, "/", ano)
        dataFim = String.Concat(dia, "/", mesString, "/", ano)

        Me.txtDataInicial.Text = dataInicio
        Me.txtDataFinal.Text = dataFim
    End Sub

    Private Function validaVendaCarimboXPendenteFaturar() As Boolean
        If ddlDataInicio.SelectedIndex = 0 OrElse ddlDataFim.SelectedIndex = 0 Then
            Util.AdicionaJsAlert(Me.Page, "Periodo Obrigatório!")
            Return False
        End If
        If Convert.ToInt32(ddlDataInicio.SelectedValue) > Convert.ToInt32(ddlDataFim.SelectedValue) Then
            Util.AdicionaJsAlert(Me.Page, "Periodo inválido!")
            Return False
        End If
        Return True
    End Function

#End Region


End Class
