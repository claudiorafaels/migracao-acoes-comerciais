Imports Martins.Security.Helper
Imports Infragistics.WebUI

Public Class CancelarPerdaAcordo
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dsContratoFornecimentoXAbatimentoPerda = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContratoFornecimentoXAbatimentoPerda
        Me.dsPerdasDisponiveis = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetPerdasDisponiveis
        Me.dsValoresApuradosContratosValidosDoFornecedor = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetValoresApuradosContratosValidosDoFornecedor
        Me.dsAbatimentoPerdasAcoFrn = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DataSetAbatimentoPerdasAcoFrn
        Me.dsAcordosEmAbertoPorEmpenho = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetAcordosEmAbertoPorEmpenho
        CType(Me.dsContratoFornecimentoXAbatimentoPerda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsPerdasDisponiveis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsValoresApuradosContratosValidosDoFornecedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsAbatimentoPerdasAcoFrn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsAcordosEmAbertoPorEmpenho, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'dsContratoFornecimentoXAbatimentoPerda
        '
        Me.dsContratoFornecimentoXAbatimentoPerda.DataSetName = "DatasetContratoFornecimentoXAbatimentoPerda"
        Me.dsContratoFornecimentoXAbatimentoPerda.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'dsPerdasDisponiveis
        '
        Me.dsPerdasDisponiveis.DataSetName = "DatasetPerdasDisponiveis"
        Me.dsPerdasDisponiveis.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'dsValoresApuradosContratosValidosDoFornecedor
        '
        Me.dsValoresApuradosContratosValidosDoFornecedor.DataSetName = "DatasetValoresApuradosContratosValidosDoFornecedor"
        Me.dsValoresApuradosContratosValidosDoFornecedor.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'dsAbatimentoPerdasAcoFrn
        '
        Me.dsAbatimentoPerdasAcoFrn.DataSetName = "DataSetAbatimentoPerdasAcoFrn"
        Me.dsAbatimentoPerdasAcoFrn.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'dsAcordosEmAbertoPorEmpenho
        '
        Me.dsAcordosEmAbertoPorEmpenho.DataSetName = "DatasetAcordosEmAbertoPorEmpenho"
        Me.dsAcordosEmAbertoPorEmpenho.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.dsContratoFornecimentoXAbatimentoPerda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsPerdasDisponiveis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsValoresApuradosContratosValidosDoFornecedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsAbatimentoPerdasAcoFrn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsAcordosEmAbertoPorEmpenho, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtCODSITPMS As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents chkRelatorios As System.Web.UI.WebControls.CheckBox
    Protected WithEvents TbTopo As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD3 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD4 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD5 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD6 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD7 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD8 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents rblTipoFiltro As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents cmbCelula As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents btnLimpar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnSair As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnImprimir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents TxtDatIni As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents TxtDatFim As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents dsContratoFornecimentoXAbatimentoPerda As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContratoFornecimentoXAbatimentoPerda
    Protected WithEvents dsPerdasDisponiveis As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetPerdasDisponiveis
    Protected WithEvents wtabCancelarPerdaAcordoAtivoDesativado As Infragistics.WebUI.UltraWebTab.UltraWebTab
    Protected WithEvents wtabRelOp As Infragistics.WebUI.UltraWebTab.UltraWebTab
    Protected WithEvents dsValoresApuradosContratosValidosDoFornecedor As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetValoresApuradosContratosValidosDoFornecedor
    Protected WithEvents Ultrawebtab1 As Infragistics.WebUI.UltraWebTab.UltraWebTab
    Protected WithEvents dsAbatimentoPerdasAcoFrn As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DataSetAbatimentoPerdasAcoFrn
    Protected WithEvents dsAcordosEmAbertoPorEmpenho As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetAcordosEmAbertoPorEmpenho
    Protected WithEvents txtHidObs As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnVisualizar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents wtabCttPms As Infragistics.WebUI.UltraWebTab.UltraWebTab


    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
        CarregaControlesFilhosWebTab()
    End Sub

#End Region

#Region " Propriedades "

    '' WebTab de Cima
    Protected WithEvents grdCancelarPerdaAcordoDesativado As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents grdCancelarPerdaAcordoAtivo As Infragistics.WebUI.UltraWebGrid.UltraWebGrid

    ' WebTab de Baixo
    ' tab Operacoes
    Protected WithEvents txtVlrPda As WebDataInput.WebCurrencyEdit
    Protected WithEvents txtVlrRes As WebDataInput.WebCurrencyEdit
    ' subtab Contrato
    Protected WithEvents grdContratos As UltraWebGrid.UltraWebGrid
    Protected WithEvents txtVlrCtt As WebDataInput.WebCurrencyEdit
    Protected WithEvents btnImprimirContratos As LinkButton
    Protected WithEvents btnAbaterCtts As LinkButton
    ' subtab Promessas
    Protected WithEvents grdPromessas As UltraWebGrid.UltraWebGrid
    Protected WithEvents txtVlrPms As WebDataInput.WebCurrencyEdit
    Protected WithEvents btnImprimirAcordo As LinkButton
    Protected WithEvents btnAbaterAcordo As LinkButton
    ' tab Relacionamento
    ' subtab Ativo
    Protected WithEvents grdRelAtivo As UltraWebGrid.UltraWebGrid
    Protected WithEvents txtVlrPdaRel As WebDataInput.WebCurrencyEdit
    Protected WithEvents txtVlrResRel As WebDataInput.WebCurrencyEdit
    Protected WithEvents btnImprimirAtivo As LinkButton
    Protected WithEvents btnDesativar As LinkButton
    ' subtab Desativado
    Protected WithEvents grdRelDesativado As UltraWebGrid.UltraWebGrid
    Protected WithEvents btnImprimirDesativo As LinkButton

    Private Enum TipoFiltro As Integer
        CreditosDisponiveis = 1
        AbatimentosRealizados = 2
    End Enum

#End Region

#Region " Eventos "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Not IsPostBack) Then
                Me.InicializaPagina()
                With ucFornecedor
                    ucFornecedor.widthCodigo = System.Web.UI.WebControls.Unit.Parse("60px")
                    ucFornecedor.widthNome = System.Web.UI.WebControls.Unit.Parse("280px")
                End With
            Else
                'Me.RecuperaEstado()
            End If

            btnImprimir.Attributes.Add("OnClick", "javascript:mostraAndamento()")
            btnPesquisar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
            btnVisualizar.Attributes.Add("OnClick", "javascript:mostraAndamento()")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Try
            Me.LimpaControles()
            If Me.ValidarDados() Then
                Me.Pesquisar()
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub chkRelatorios_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRelatorios.CheckedChanged
        Try
            If rblTipoFiltro.SelectedValue = String.Empty Then
                rblTipoFiltro.SelectedValue = "1"
            End If
            MostraLinhasConformeFiltroSelecionado(chkRelatorios.Checked, CType(Integer.Parse(Val(rblTipoFiltro.SelectedValue).ToString), Martins.Web.UI.AcoesComerciais.CancelarPerdaAcordo.TipoFiltro))
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub rblTipoFiltro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblTipoFiltro.SelectedIndexChanged
        Try
            MostraLinhasConformeFiltroSelecionado(chkRelatorios.Checked, CType(Integer.Parse(Val(rblTipoFiltro.SelectedValue).ToString), Martins.Web.UI.AcoesComerciais.CancelarPerdaAcordo.TipoFiltro))
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Try
            Response.Redirect("Principal.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnLimpar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLimpar.Click
        Try
            Response.Redirect("CancelarPerdaAcordo.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnAbaterCtts_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAbaterCtts.Click
        Try
            Me.Abater(5)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnAbaterAcordo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAbaterAcordo.Click
        Try
            Me.Abater(6)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnDesativar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDesativar.Click
        Try
            Me.Abater(7)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ucFornecedor_FornecedorAlterado(ByVal e As System.Web.UI.WebControls.ListItem) Handles ucFornecedor.FornecedorAlterado
        Try
            Me.LimpaControles()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#Region " Metodos "

#Region " Métodos de Carga "

    Private Sub InicializaPagina()
        'Carrega celula
        Util.carregarCmbCelula(Controller.ObterCelulas(0, 0, 0, String.Empty), cmbCelula, New ListItem("TODAS", "0"))
        MostraLinhasConformeFiltroSelecionado(False, TipoFiltro.CreditosDisponiveis)

        'Os botões abaixo são relatórios que não foram implementados, conforme
        'contato com o Cleuton em 08/01/2006, elem ficarão invisiveis, caso seja
        'identificado sua necessidade, serão mostrados e implementados.
        btnImprimirAtivo.Visible = False
        btnImprimirDesativo.Visible = False
        btnImprimirContratos.Visible = False
        btnImprimirAcordo.Visible = False
    End Sub

    Private Sub CarregaControlesFilhosWebTab()
        ' WebTab de cima
        With wtabCancelarPerdaAcordoAtivoDesativado.Tabs
            ' Tab Ativo
            With .GetTab(0)
                Me.grdCancelarPerdaAcordoAtivo = CType(.FindControl("grdCancelarPerdaAcordoAtivo"), UltraWebGrid.UltraWebGrid)
            End With
            ' Tab Desativado
            With .GetTab(1)
                Me.grdCancelarPerdaAcordoDesativado = CType(.FindControl("grdCancelarPerdaAcordoDesativado"), UltraWebGrid.UltraWebGrid)
            End With
        End With
        ' WebTab de Baixo
        With wtabRelOp.Tabs
            ' tab Relacionamento
            With .GetTab(0)
                ' obj Webtab wtabAtivoDesativo
                With CType(.FindControl("wtabAtivoDesativo"), UltraWebTab.UltraWebTab)
                    ' sub tab Ativo
                    With .Tabs.GetTab(0)
                        Me.grdRelAtivo = CType(.FindControl("grdRelAtivo"), UltraWebGrid.UltraWebGrid)
                        Me.txtVlrPdaRel = CType(.FindControl("txtVlrPdaRel"), WebDataInput.WebCurrencyEdit)
                        Me.txtVlrResRel = CType(.FindControl("txtVlrResRel"), WebDataInput.WebCurrencyEdit)
                        Me.btnImprimirAtivo = CType(.FindControl("btnImprimirAtivo"), LinkButton)
                        Me.btnDesativar = CType(.FindControl("btnDesativar"), LinkButton)
                        Me.btnDesativar.Attributes.Add("onClick", "JavaScript:ValidarAbatimento(7, '" & btnDesativar.ClientID.Replace("__", "$#").Replace("_", "$").Replace("$#", "$_") & "'); return false;")
                    End With
                    ' sub tab Desativo
                    With .Tabs.GetTab(1)
                        Me.grdRelDesativado = CType(.FindControl("grdRelDesativado"), UltraWebGrid.UltraWebGrid)
                        Me.btnImprimirDesativo = CType(.FindControl("btnImprimirDesativo"), LinkButton)
                    End With
                End With
            End With
            ' tab Operacoes
            With .GetTab(1)
                Me.txtVlrPda = CType(.FindControl("txtVlrPda"), WebDataInput.WebCurrencyEdit)
                Me.txtVlrRes = CType(.FindControl("txtVlrRes"), WebDataInput.WebCurrencyEdit)
                ' obj WebTab wtabCttPms
                With CType(.FindControl("wtabCttPms"), UltraWebTab.UltraWebTab)
                    ' sub tab Contrato
                    With .Tabs.GetTab(0)
                        Me.grdContratos = CType(.FindControl("grdContratos"), UltraWebGrid.UltraWebGrid)
                        Me.txtVlrCtt = CType(.FindControl("txtVlrCtt"), WebDataInput.WebCurrencyEdit)
                        Me.btnImprimirContratos = CType(.FindControl("btnImprimirContratos"), LinkButton)
                        Me.btnAbaterCtts = CType(.FindControl("btnAbaterCtts"), LinkButton)
                        Me.btnAbaterCtts.Attributes.Add("onClick", "JavaScript:ValidarAbatimento(5, '" & btnAbaterCtts.ClientID.Replace("__", "$#").Replace("_", "$").Replace("$#", "$_") & "'); return false;")
                    End With
                    ' sub tab Promessa
                    With .Tabs.GetTab(1)
                        Me.grdPromessas = CType(.FindControl("grdPromessas"), UltraWebGrid.UltraWebGrid)
                        Me.txtVlrPms = CType(.FindControl("txtVlrPms"), WebDataInput.WebCurrencyEdit)
                        Me.btnImprimirAcordo = CType(.FindControl("btnImprimirAcordo"), LinkButton)
                        Me.btnAbaterAcordo = CType(.FindControl("btnAbaterAcordo"), LinkButton)
                        Me.btnAbaterAcordo.Attributes.Add("onClick", "JavaScript:ValidarAbatimento(6, '" & btnAbaterAcordo.ClientID.Replace("__", "$#").Replace("_", "$").Replace("$#", "$_") & "'); return false;")
                    End With
                End With
            End With
        End With
    End Sub

    Private Sub MostraLinhasConformeFiltroSelecionado(ByVal FlaRelatorios As Boolean, ByVal numTipoFiltro As TipoFiltro)
        'Esconde linha da célula
        TD3.Visible = False
        TD4.Visible = False
        'Esconde linha do fornecedor
        TD5.Visible = False
        TD6.Visible = False
        'Esconde linha da data de abatimento
        TD7.Visible = False
        TD8.Visible = False

        btnImprimir.Enabled = False
        btnPesquisar.Enabled = False

        If FlaRelatorios = False Then
            'Mostra linha do fornecedor
            TD5.Visible = True
            TD6.Visible = True
            'Esconde o tipo do filtro
            rblTipoFiltro.Visible = False

            btnPesquisar.Enabled = True
        Else
            'Habilita o botão do relatório
            btnImprimir.Enabled = True

            'Mostra o tipo do filtro
            rblTipoFiltro.Visible = True

            If numTipoFiltro = TipoFiltro.CreditosDisponiveis Then
                'Mostra linha da célula
                TD3.Visible = True
                TD4.Visible = True
                'Mostra linha do fornecedor
                TD5.Visible = True
                TD6.Visible = True
            ElseIf numTipoFiltro = TipoFiltro.AbatimentosRealizados Then
                'Mostra linha do fornecedor
                TD5.Visible = True
                TD6.Visible = True
                'Mostra linha da data de abatimento
                TD7.Visible = True
                TD8.Visible = True
            End If
        End If
    End Sub

    Private Sub CarregaGridPerdasDisponiveis()
        grdCancelarPerdaAcordoAtivo.Rows.Clear()

        Me.dsPerdasDisponiveis = Controller.ObterPerdasDisponiveis(Convert.ToInt32(ucFornecedor.CodFornecedor), 0)

        grdCancelarPerdaAcordoAtivo.DataBind()
    End Sub

    Private Sub CarregaGridPerdasDesativado()
        grdCancelarPerdaAcordoDesativado.Rows.Clear()

        ' Consulta da Perda Desativado
        Me.dsContratoFornecimentoXAbatimentoPerda = _
            Controller.ObterContratoFornecimentosXAbatimentosPerda(Convert.ToInt32(ucFornecedor.CodFornecedor), "C")

        grdCancelarPerdaAcordoDesativado.DataBind()
    End Sub

    Private Sub CarregaGridContratos()
        ' Consulta da Perda Desativado
        Me.dsValoresApuradosContratosValidosDoFornecedor = _
            Controller.ObterValoresApuradosContratosValidosDoFornecedor(Convert.ToInt32(ucFornecedor.CodFornecedor), 0, 0, 0)

        grdContratos.DataBind()
    End Sub

    Private Sub CarregaGridPromessas()
        Me.dsAcordosEmAbertoPorEmpenho = _
            Controller.ObterAcordosEmAbertoPorEmpenho(Decimal.Zero, Decimal.Zero, Decimal.Zero, Convert.ToInt32(ucFornecedor.CodFornecedor))

        grdPromessas.DataBind()
    End Sub

    Private Sub CarregaGridRelAtivoDesativo(Optional ByVal bAtivo As Boolean = True)
        If bAtivo Then
            Me.dsAbatimentoPerdasAcoFrn.Clear()
            Me.dsAbatimentoPerdasAcoFrn = _
                Controller.ObterAbatimentoPerdasAcoFrn(ucFornecedor.CodFornecedor, True)
            grdRelAtivo.DataBind()
        Else
            Me.dsAbatimentoPerdasAcoFrn.Clear()
            Me.dsAbatimentoPerdasAcoFrn = _
                Controller.ObterAbatimentoPerdasAcoFrn(ucFornecedor.CodFornecedor, False)
            grdRelDesativado.DataBind()
        End If
    End Sub

#End Region

#Region " Métodos de Controles "

    Private Sub LimpaControles()

        Util.LimpaControles(New WebControl() {txtVlrCtt, txtVlrPda, txtVlrPdaRel, txtVlrPms, txtVlrRes, txtVlrResRel, grdCancelarPerdaAcordoAtivo, grdCancelarPerdaAcordoDesativado, grdContratos, grdPromessas, grdRelAtivo, grdRelDesativado})

    End Sub

    Private Function getGrdAtivosSelectedRow() As Infragistics.WebUI.UltraWebGrid.UltraGridRow
        For Each row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In grdCancelarPerdaAcordoAtivo.Rows
            If Convert.ToBoolean(row.Cells.Item(0).Value) = True Then Return row
        Next
    End Function


#End Region

#Region " Métodos de Regras de Negocio "

    Private Function ValidarDados() As Boolean
        If ucFornecedor.CodFornecedor <= 0 Then
            Util.AdicionaJsAlert(Me.Page, "Selecione um fornecedor para realização da pesquisa.")
            Util.AdicionaJsFocus(Me.Page, CType(ucFornecedor.FindControl("txtCodigo"), WebControl))
            Return False
        End If
        Return True
    End Function

    Private Function ValidarDadosAbatimento(ByVal intOpc As Integer) As Boolean
        Dim ret As Boolean = False

        If intOpc = 5 Or intOpc = 6 Then
            Dim row As Infragistics.WebUI.UltraWebGrid.UltraGridRow

            For Each row In Me.grdContratos.Rows
                If Convert.ToBoolean(row.Cells(0).Value) Then
                    ret = True
                    Exit For
                End If
            Next

            If Not ret Then
                For Each row In Me.grdPromessas.Rows
                    If Convert.ToBoolean(row.Cells(0).Value) Then
                        ret = True
                        Exit For
                    End If
                Next
            End If

            If Not ret Then
                Util.AdicionaJsAlert(Me.Page, "Favor selecionar algum item do grid Contratos ou Promessas!")
                Return False
            End If
        Else
            ret = True
        End If

        Return ret
    End Function

    Private Sub Pesquisar()
        CarregaGridPerdasDisponiveis()
        CarregaGridPerdasDesativado()
        CarregaGridRelAtivoDesativo(True)
        CarregaGridRelAtivoDesativo(False)
        CarregaGridContratos()
        CarregaGridPromessas()
    End Sub

    Private Function Abater(ByVal intOpc As Integer) As Boolean
        Try
            If Not Me.ValidarDadosAbatimento(intOpc) Then Return False
            Dim intQde As Integer = 0
            Dim sGrid As String = String.Empty
            Dim dVlr As Decimal = Decimal.Zero
            Select Case intOpc
                Case 5 ' Contrato
                    intQde = VrfQdeDdoVlr(grdContratos, "VLRDSP", txtVlrCtt)
                    sGrid = "Contrato"
                    dVlr = txtVlrCtt.ValueDecimal
                Case 6 ' Promessa
                    intQde = VrfQdeDdoVlr(grdPromessas, "VlrDspPms", txtVlrPms)
                    sGrid = "Promessa"
                    dVlr = txtVlrPms.ValueDecimal
                Case 7 'Abater Cancelamento
                    intQde = VrfQdeDdoVlr(grdRelAtivo, "VLRCRDUTZCTTFRN", txtVlrResRel)
                    sGrid = "Relacionamento - Ativo"
                    dVlr = txtVlrResRel.ValueDecimal
                Case Else
                    Util.AdicionaJsAlert(Me.Page, "Função inválida!")
                    Return False
            End Select
            If intQde = 0 Then
                Util.AdicionaJsAlert(Me.Page, "Favor selecionar algum item do grid ( " & sGrid & " )!")
                Return False
            End If
            If txtHidObs.Value.Trim() Is String.Empty Then
                Util.AdicionaJsAlert(Me.Page, "Preencha uma observação!")
                Return False
            End If
            Me.EfetivarAbatimento(intOpc)

            'Mostra mensagem de confirmação
            Util.AdicionaJsAlert(Me.Page, "Operação realizada com sucesso!")

            'Faz uma nova pesquisa
            Me.LimpaControles()
            If Me.ValidarDados() Then
                Me.Pesquisar()
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Function EfetivarAbatimento(ByVal intOpc As Integer) As Boolean
        Dim CODFRN As Decimal
        Dim NUMCTTFRN As Decimal
        Dim NUMCSLCTTFRN As Decimal
        Dim TIPPODCTTFRN As Decimal
        Dim NUMREFPOD As Decimal
        Dim TIPEDEABGMIX As Decimal
        Dim CODEDEABGMIX As Decimal
        Dim DATREFAPU As Date
        Dim TIPFRMDSCBNF As Decimal
        Dim TIPDSNDSCBNFFRN As Decimal
        Dim VLRDSPPDA As Decimal
        Dim intOpcAux As Integer
        Dim VLRDSPPDAUX As Double
        Dim VLRDSPPMSORI As Double
        Dim VLRCRDUTZCTTFRN As Double

        'NOMACSUSRSISAPO = WSCAcoesComerciais.dsUsuarioCompra.T0113471.Item(0).NOMACSUSRSIS.tRIM
        'DATGRCOBSPMSAPO = Date.Now
        'DESOBSCTTFRNAPO = txtHidObs.Value
        'VLRDSPPDAUX = txtVlrPda.ValueDecimal

        Try
            If grdCancelarPerdaAcordoAtivo.DisplayLayout.ActiveRow Is Nothing Then
                For Each row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In grdCancelarPerdaAcordoAtivo.Rows
                    Try
                        If Convert.ToBoolean(row.Cells(0).Value) = True Then
                            row.Activate()
                            Exit For
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If

            'Obtem algumas informações do grid de contratos ativos no grid grdCancelarPerdaAcordoAtivo
            With grdCancelarPerdaAcordoAtivo.DisplayLayout.ActiveRow
                CODFRN = Convert.ToDecimal(.Cells.FromKey("CODFRN").Value)
                NUMCTTFRN = Convert.ToDecimal(.Cells.FromKey("NUMCTTFRN").Value)
                NUMCSLCTTFRN = Convert.ToDecimal(.Cells.FromKey("NUMCSLCTTFRN").Value)
                TIPPODCTTFRN = Convert.ToDecimal(.Cells.FromKey("TIPPODCTTFRN").Value)
                NUMREFPOD = Convert.ToDecimal(.Cells.FromKey("NUMREFPOD").Value)
                TIPEDEABGMIX = Convert.ToDecimal(.Cells.FromKey("TIPEDEABGMIX").Value)
                CODEDEABGMIX = Convert.ToDecimal(.Cells.FromKey("CODEDEABGMIX").Value)
                DATREFAPU = Convert.ToDateTime(.Cells.FromKey("DATREFAPU").Value)
                TIPFRMDSCBNF = Convert.ToDecimal(.Cells.FromKey("TIPFRMDSCBNF").Value)
                TIPDSNDSCBNFFRN = Convert.ToDecimal(.Cells.FromKey("TIPDSNDSCBNFFRN").Value)
                VLRDSPPDA = Convert.ToDecimal(.Cells.FromKey("VLRDSPPDA").Value)
            End With

            'Chama os métodos que fazem os abatimentos
            intOpcAux = intOpc

            If intOpcAux = -1 Or intOpcAux = 0 Or intOpcAux = 1 Or intOpcAux = 5 Then
                Me.AbaterContrato(CODFRN, _
                                  NUMCTTFRN, _
                                  NUMCSLCTTFRN, _
                                  TIPPODCTTFRN, _
                                  NUMREFPOD, _
                                  TIPEDEABGMIX, _
                                  CODEDEABGMIX, _
                                  DATREFAPU, _
                                  TIPFRMDSCBNF, _
                                  TIPDSNDSCBNFFRN, _
                                  VLRDSPPDA, _
                                  intOpcAux, _
                                  txtVlrPda.ValueDecimal, _
                                  txtHidObs.Value, _
                                  WSCAcoesComerciais.dsUsuarioCompra.T0113471.Item(0).NOMACSUSRSIS.Trim, _
                                  Date.Now)
            End If

            If intOpcAux = -1 Or intOpcAux = 0 Or intOpcAux = 2 Or intOpcAux = 6 Then
                Me.AbaterPromessa(CODFRN, _
                                  NUMCTTFRN, _
                                  NUMCSLCTTFRN, _
                                  TIPPODCTTFRN, _
                                  NUMREFPOD, _
                                  TIPEDEABGMIX, _
                                  CODEDEABGMIX, _
                                  DATREFAPU, _
                                  TIPFRMDSCBNF, _
                                  TIPDSNDSCBNFFRN, _
                                  VLRDSPPDA, _
                                  intOpcAux, _
                                  txtVlrPda.ValueDecimal, _
                                  txtHidObs.Value, _
                                  WSCAcoesComerciais.dsUsuarioCompra.T0113471.Item(0).NOMACSUSRSIS.Trim, _
                                  Date.Now)
            End If

            If intOpcAux = -1 Or intOpcAux = 3 Or intOpcAux = 7 Then
                Me.AbaterRelacionamento(CODFRN, _
                                        NUMCTTFRN, _
                                        NUMCSLCTTFRN, _
                                        TIPPODCTTFRN, _
                                        NUMREFPOD, _
                                        TIPEDEABGMIX, _
                                        CODEDEABGMIX, _
                                        DATREFAPU, _
                                        TIPFRMDSCBNF, _
                                        TIPDSNDSCBNFFRN, _
                                        VLRDSPPDA, _
                                        txtHidObs.Value, _
                                        WSCAcoesComerciais.dsUsuarioCompra.T0113471.Item(0).NOMACSUSRSIS.Trim)
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Public Function AbaterContrato(ByVal CODFRN As Decimal, _
                                   ByVal NUMCTTFRN As Decimal, _
                                   ByVal NUMCSLCTTFRN As Decimal, _
                                   ByVal TIPPODCTTFRN As Decimal, _
                                   ByVal NUMREFPOD As Decimal, _
                                   ByVal TIPEDEABGMIX As Decimal, _
                                   ByVal CODEDEABGMIX As Decimal, _
                                   ByVal DATREFAPU As Date, _
                                   ByVal TIPFRMDSCBNF As Decimal, _
                                   ByVal TIPDSNDSCBNFFRN As Decimal, _
                                   ByVal VLRDSPPDA As Decimal, _
                                   ByVal intOpcAux As Integer, _
                                   ByVal VLRDSPPDAUX As Decimal, _
                                   ByVal DESOBSAPO As String, _
                                   ByVal NOMACSUSRSISAPO As String, _
                                   ByVal DATGRCOBSPMSAPO As Date) As Boolean

        Dim VLRDSPPMSORI As Decimal
        Dim VLRCRDUTZCTTFRN As Decimal

        Dim TIPOPEAPO As Integer
        Dim NUMCTTFRNAPO As Decimal
        Dim NUMCSLCTTFRNAPO As Integer
        Dim TIPPODCTTFRNAPO As Integer
        Dim NUMREFPODAPO As Integer
        Dim TIPEDEABGMIXAPO As Integer
        Dim CODEDEABGMIXAPO As Decimal
        Dim DATREFAPUAPO As Date
        Dim NUMSEQRLCCTTPMSAPO As Integer
        Dim CODFRNAPO As Decimal
        Dim DESOBSCTTFRNAPO As String
        Dim TIPCNCPDACTTFRNAPO As String
        Dim VLRCRDDISCTTFRNAPO As Decimal
        Dim TIPFRMDSCBNFAPO As Integer
        Dim TIPDSNDSCBNFAPO As Integer

        AbaterContrato = False

        Try


            VLRCRDUTZCTTFRN = 0
            VLRDSPPMSORI = 0
            VLRDSPPDAUX = VLRDSPPDA

            'Obtem informações do grid Contrato
            For Each row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In grdContratos.Rows
                If Convert.ToBoolean(row.Cells(0).Value) = True And VLRDSPPDAUX > 0 Then

                    VLRDSPPMSORI = Convert.ToDecimal(row.Cells.FromKey("VLRDSP").Value)
                    If VLRDSPPDAUX >= VLRDSPPMSORI Then
                        '-- Abate todo VLRDSPPMS  e aplica a sobra em outra linha da última query.
                        VLRDSPPDAUX = VLRDSPPDAUX - VLRDSPPMSORI
                        VLRCRDUTZCTTFRN = VLRDSPPMSORI
                    Else
                        '-- Abate todo o VRLDSPPDA na linha em questão
                        VLRCRDUTZCTTFRN = VLRDSPPDAUX
                        VLRDSPPDAUX = 0
                    End If
                End If

                NUMCTTFRNAPO = Convert.ToDecimal(row.Cells.FromKey("NUMCTTFRN").Value)
                NUMCSLCTTFRNAPO = Convert.ToInt32(row.Cells.FromKey("NUMCSLCTTFRN").Value)
                TIPPODCTTFRNAPO = Convert.ToInt32(row.Cells.FromKey("TIPPODCTTFRN").Value)
                NUMREFPODAPO = Convert.ToInt32(row.Cells.FromKey("NUMREFPOD").Value)
                TIPEDEABGMIXAPO = Convert.ToInt32(row.Cells.FromKey("TIPEDEABGMIX").Value)
                CODEDEABGMIXAPO = Convert.ToInt32(row.Cells.FromKey("CODEDEABGMIX").Value)
                DATREFAPUAPO = Convert.ToDateTime(row.Cells.FromKey("DATREFAPU").Value)
                VLRCRDDISCTTFRNAPO = VLRCRDUTZCTTFRN
                NUMSEQRLCCTTPMSAPO = 0
                TIPFRMDSCBNFAPO = Convert.ToInt32(row.Cells.FromKey("TIPFRMDSCBNF").Value)
                TIPDSNDSCBNFAPO = Convert.ToInt32(row.Cells.FromKey("TIPDSNDSCBNFFRN").Value)

                Controller.InsereVaresApuradosContratoValido(NUMCTTFRN, _
                                                             NUMCSLCTTFRN, _
                                                             TIPPODCTTFRN, _
                                                             NUMREFPOD, _
                                                             TIPEDEABGMIX, _
                                                             CODEDEABGMIX, _
                                                             DATREFAPU, _
                                                             TIPFRMDSCBNF, _
                                                             TIPDSNDSCBNFFRN, _
                                                             CODFRN, _
                                                             NUMCTTFRNAPO, _
                                                             NUMCSLCTTFRNAPO, _
                                                             TIPPODCTTFRNAPO, _
                                                             NUMREFPODAPO, _
                                                             TIPEDEABGMIXAPO, _
                                                             CODEDEABGMIXAPO, _
                                                             DATREFAPUAPO, _
                                                             VLRCRDDISCTTFRNAPO, _
                                                             NUMSEQRLCCTTPMSAPO, _
                                                             TIPFRMDSCBNFAPO, _
                                                             TIPDSNDSCBNFAPO)

                TIPOPEAPO = 1
                TIPCNCPDACTTFRNAPO = "A"
                CODFRNAPO = CODFRN

                If Not AbtPdaObs(TIPOPEAPO, _
                                 NUMCTTFRNAPO, _
                                 NUMCSLCTTFRNAPO, _
                                 TIPPODCTTFRNAPO, _
                                 NUMREFPODAPO, _
                                 TIPEDEABGMIXAPO, _
                                 CODEDEABGMIXAPO, _
                                 DATREFAPUAPO, _
                                 NUMSEQRLCCTTPMSAPO, _
                                 CODFRNAPO, _
                                 DESOBSCTTFRNAPO, _
                                 TIPCNCPDACTTFRNAPO, _
                                 VLRCRDDISCTTFRNAPO, _
                                 TIPFRMDSCBNFAPO, _
                                 TIPDSNDSCBNFAPO, _
                                 NOMACSUSRSISAPO, _
                                 DATGRCOBSPMSAPO) Then

                    Util.AdicionaJsAlert(Me.Page, "Não foi possível de realizar a operação")
                    Exit Function
                End If
            Next
            Return True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Public Function AbaterPromessa(ByVal CODFRN As Decimal, _
                                   ByVal NUMCTTFRN As Decimal, _
                                   ByVal NUMCSLCTTFRN As Decimal, _
                                   ByVal TIPPODCTTFRN As Decimal, _
                                   ByVal NUMREFPOD As Decimal, _
                                   ByVal TIPEDEABGMIX As Decimal, _
                                   ByVal CODEDEABGMIX As Decimal, _
                                   ByVal DATREFAPU As Date, _
                                   ByVal TIPFRMDSCBNF As Decimal, _
                                   ByVal TIPDSNDSCBNFFRN As Decimal, _
                                   ByVal VLRDSPPDA As Decimal, _
                                   ByVal intOpcAux As Integer, _
                                   ByVal VLRDSPPDAUX As Decimal, _
                                   ByVal DESOBSAPO As String, _
                                   ByVal NOMACSUSRSISAPO As String, _
                                   ByVal DATGRCOBSPMSAPO As Date) As Boolean

        Dim VLRDSPPMSORI As Decimal
        Dim VLRCRDUTZCTTFRN As Decimal
        AbaterPromessa = False

        Dim CODEMPORI As Decimal
        Dim CODFILEMPORI As Decimal
        Dim CODPMSORI As Decimal
        Dim DATNGCPMSORI As Date
        Dim DATPRVRCBPMSORI As Date
        Dim TipFrmDscBnfOri As Decimal
        Dim TipDsnDscBnfOri As Decimal
        Dim NUMSEQRLCCTTPMS As Integer
        Dim TIPOBSPMS As String

        VLRCRDUTZCTTFRN = 0
        VLRDSPPMSORI = 0

        Try

            For Each row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In grdPromessas.Rows
                If Convert.ToBoolean(row.Cells(0).Value) = True And VLRDSPPDAUX > 0 Then
                    'sMsgErr = "Abatimento da Promessa" 'Promessa

                    VLRDSPPMSORI = Convert.ToDecimal(row.Cells.FromKey("VlrDspPms").Value)
                    If VLRDSPPDAUX >= VLRDSPPMSORI Then
                        '-- Abate todo VLRDSPPMS  e aplica a sobra em outra linha da última query.
                        VLRDSPPDAUX = VLRDSPPDAUX - VLRDSPPMSORI
                        VLRCRDUTZCTTFRN = VLRDSPPMSORI
                    Else
                        '-- Abate todo o VRLDSPPDA na linha em questão
                        VLRCRDUTZCTTFRN = VLRDSPPDAUX
                        VLRDSPPDAUX = 0
                    End If

                    CODEMPORI = Convert.ToInt32(row.Cells.FromKey("CodEmp").Value)
                    CODFILEMPORI = Convert.ToInt32(row.Cells.FromKey("CodFilEmp").Value)

                    If IsNumeric(row.Cells.FromKey("CodPms").Value) Then
                        Dim tempCodPms As Integer
                        tempCodPms = CType(row.Cells.FromKey("CodPms").Value, Integer)
                        CODPMSORI = CType(tempCodPms, Decimal)
                    End If

                    If IsDate(row.Cells.FromKey("DatNgcPms").Value) Then
                        DATNGCPMSORI = Convert.ToDateTime(row.Cells.FromKey("DatNgcPms").Value)
                    Else
                        DATNGCPMSORI = Nothing
                    End If

                    If IsDate(row.Cells.FromKey("DatPrvRcbPms").Value) Then
                        DATPRVRCBPMSORI = CType(row.Cells.FromKey("DatPrvRcbPms").Value, Date)
                    Else
                        DATPRVRCBPMSORI = Nothing
                    End If

                    TipFrmDscBnfOri = Convert.ToInt32(row.Cells.FromKey("TipFrmDscBnf").Value)
                    TipDsnDscBnfOri = Convert.ToInt32(row.Cells.FromKey("TipDsnDscBnf").Value)
                    NUMSEQRLCCTTPMS = 0
                    TIPOBSPMS = "N"

                    Controller.InserePromessasEmAbertoDeAcordoEmpenho(NUMCTTFRN, _
                                                                      NUMCSLCTTFRN, _
                                                                      TIPPODCTTFRN, _
                                                                      NUMREFPOD, _
                                                                      TIPEDEABGMIX, _
                                                                      CODEDEABGMIX, _
                                                                      DATREFAPU, _
                                                                      TIPFRMDSCBNF, _
                                                                      TIPDSNDSCBNFFRN, _
                                                                      CODFRN, _
                                                                      CODEMPORI, _
                                                                      CODFILEMPORI, _
                                                                      CODPMSORI, _
                                                                      DATNGCPMSORI, _
                                                                      DATPRVRCBPMSORI, _
                                                                      TipFrmDscBnfOri, _
                                                                      TipDsnDscBnfOri, _
                                                                      VLRCRDUTZCTTFRN, _
                                                                      DESOBSAPO, _
                                                                      NOMACSUSRSISAPO, _
                                                                      NUMSEQRLCCTTPMS, _
                                                                      TIPOBSPMS)
                End If
            Next
            Return True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Function

    Public Function AbaterRelacionamento(ByVal CODFRN As Decimal, _
                                         ByVal NUMCTTFRN As Decimal, _
                                         ByVal NUMCSLCTTFRN As Decimal, _
                                         ByVal TIPPODCTTFRN As Decimal, _
                                         ByVal NUMREFPOD As Decimal, _
                                         ByVal TIPEDEABGMIX As Decimal, _
                                         ByVal CODEDEABGMIX As Decimal, _
                                         ByVal DATREFAPU As Date, _
                                         ByVal TIPFRMDSCBNF As Decimal, _
                                         ByVal TIPDSNDSCBNFFRN As Decimal, _
                                         ByVal VLRDSPPDA As Decimal, _
                                         ByVal DESOBSAPO As String, _
                                         ByVal NOMACSUSRSISAPO As String) As Boolean

        AbaterRelacionamento = False

        Dim rowNUMCTTFRN As Decimal
        Dim rowNUMCSLCTTFRN As Decimal
        Dim rowTIPPODCTTFRN As Decimal
        Dim rowNUMREFPOD As Decimal
        Dim rowTIPEDEABGMIX As Decimal
        Dim rowCODEDEABGMIX As Decimal
        Dim rowDATREFAPU As Date
        Dim rowTIPFRMDSCBNF As Decimal
        Dim rowTIPDSNDSCBNF As Decimal
        Dim rowCODFRN As Decimal
        Dim rowNUMCTTFRNORIPDA As Decimal
        Dim rowNUMCSLCTTFRNORIPDA As Integer
        Dim rowTIPPODCTTFRNORIPDA As Integer
        Dim rowNUMREFPODORIPDA As Integer
        Dim rowTIPEDEABGMIXORIPDA As Integer
        Dim rowCODEDEABGMIXORIPDA As Integer
        Dim rowDATREFAPUORIPDA As Date
        Dim rowVLRCRDUTZCTTFRN As Decimal
        Dim rowNUMSEQRLCCTTPMS As Integer
        Dim rowTIPFRMDSCBNFORIPDA As Integer
        Dim rowTIPDSNDSCBNFORIPDA As Integer
        Dim rowCODEMP As Decimal
        Dim rowCODFILEMP As Decimal
        Dim rowCODPMS As Decimal
        Dim rowDATNGCPMS As Date
        Dim rowDATPRVRCBPMS As Date

        Try
            For Each relAtivoRow As Infragistics.WebUI.UltraWebGrid.UltraGridRow In grdRelAtivo.Rows
                If Convert.ToBoolean(relAtivoRow.Cells(0).Value) = True Then

                    rowNUMCTTFRN = Convert.ToDecimal(relAtivoRow.Cells.FromKey("NUMCTTFRN").Value)
                    rowNUMCSLCTTFRN = Convert.ToDecimal(relAtivoRow.Cells.FromKey("NUMCSLCTTFRN").Value)
                    rowTIPPODCTTFRN = Convert.ToDecimal(relAtivoRow.Cells.FromKey("TIPPODCTTFRN").Value)
                    rowNUMREFPOD = Convert.ToDecimal(relAtivoRow.Cells.FromKey("NUMREFPOD").Value)
                    rowTIPEDEABGMIX = Convert.ToDecimal(relAtivoRow.Cells.FromKey("TIPEDEABGMIX").Value)
                    rowCODEDEABGMIX = Convert.ToDecimal(relAtivoRow.Cells.FromKey("CODEDEABGMIX").Value)
                    rowDATREFAPU = Convert.ToDateTime(relAtivoRow.Cells.FromKey("DATREFAPU").Value).Date
                    rowTIPFRMDSCBNF = Convert.ToDecimal(relAtivoRow.Cells.FromKey("TIPFRMDSCBNF").Value)
                    rowTIPDSNDSCBNF = Convert.ToDecimal(relAtivoRow.Cells.FromKey("TIPDSNDSCBNF").Value)
                    rowCODFRN = Convert.ToDecimal(relAtivoRow.Cells.FromKey("CODFRN").Value)
                    rowNUMCTTFRNORIPDA = Convert.ToDecimal(relAtivoRow.Cells.FromKey("NUMCTTFRNORIPDA").Value)
                    rowNUMCSLCTTFRNORIPDA = Convert.ToInt32(relAtivoRow.Cells.FromKey("NUMCSLCTTFRNORIPDA").Value)
                    rowTIPPODCTTFRNORIPDA = Convert.ToInt32(relAtivoRow.Cells.FromKey("TIPPODCTTFRNORIPDA").Value)
                    rowNUMREFPODORIPDA = Convert.ToInt32(relAtivoRow.Cells.FromKey("NUMREFPODORIPDA").Value)
                    rowTIPEDEABGMIXORIPDA = Convert.ToInt32(relAtivoRow.Cells.FromKey("TIPEDEABGMIXORIPDA").Value)
                    rowCODEDEABGMIXORIPDA = Convert.ToInt32(relAtivoRow.Cells.FromKey("CODEDEABGMIXORIPDA").Value)
                    rowDATREFAPUORIPDA = Convert.ToDateTime(relAtivoRow.Cells.FromKey("DATREFAPUORIPDA").Value).Date
                    rowVLRCRDUTZCTTFRN = Convert.ToDecimal(relAtivoRow.Cells.FromKey("VLRCRDUTZCTTFRN").Value)
                    rowNUMSEQRLCCTTPMS = Convert.ToInt32(relAtivoRow.Cells.FromKey("NUMSEQRLCCTTPMS").Value)
                    rowTIPFRMDSCBNFORIPDA = Convert.ToInt32(relAtivoRow.Cells.FromKey("TIPFRMDSCBNFORIPDA").Value)
                    rowTIPDSNDSCBNFORIPDA = Convert.ToInt32(relAtivoRow.Cells.FromKey("TIPDSNDSCBNFORIPDA").Value)
                    rowNUMCSLCTTFRNORIPDA = Convert.ToInt32(relAtivoRow.Cells.FromKey("NUMCSLCTTFRNORIPDA").Value)
                    rowCODEMP = Convert.ToDecimal(relAtivoRow.Cells.FromKey("CODEMP").Value)
                    rowCODFILEMP = Convert.ToDecimal(relAtivoRow.Cells.FromKey("CODFILEMP").Value)
                    rowCODPMS = Convert.ToDecimal(relAtivoRow.Cells.FromKey("CODPMS").Value)
                    rowDATNGCPMS = Convert.ToDateTime(relAtivoRow.Cells.FromKey("DATNGCPMS").Value).Date
                    rowDATPRVRCBPMS = Convert.ToDateTime(relAtivoRow.Cells.FromKey("DATPRVRCBPMS").Value).Date

                    If Convert.ToDecimal(relAtivoRow.Cells.FromKey("CODPMS").Value).Equals(0) Or relAtivoRow.Cells.FromKey("CODPMS").Value Is String.Empty Then
                        'Procedure legado: spCLJ153
                        Controller.InsereVaresApuradosContratoValido(rowNUMCTTFRN, _
                                                                     rowNUMCSLCTTFRN, _
                                                                     rowTIPPODCTTFRN, _
                                                                     rowNUMREFPOD, _
                                                                     rowTIPEDEABGMIX, _
                                                                     rowCODEDEABGMIX, _
                                                                     rowDATREFAPU, _
                                                                     rowTIPFRMDSCBNF, _
                                                                     rowTIPDSNDSCBNF, _
                                                                     rowCODFRN, _
                                                                     rowNUMCTTFRNORIPDA, _
                                                                     rowNUMCSLCTTFRNORIPDA, _
                                                                     rowTIPPODCTTFRNORIPDA, _
                                                                     rowNUMREFPODORIPDA, _
                                                                     rowTIPEDEABGMIXORIPDA, _
                                                                     rowCODEDEABGMIXORIPDA, _
                                                                     rowDATREFAPUORIPDA, _
                                                                     rowVLRCRDUTZCTTFRN, _
                                                                     rowNUMSEQRLCCTTPMS, _
                                                                     rowTIPFRMDSCBNFORIPDA, _
                                                                     rowTIPDSNDSCBNFORIPDA)

                        '    CODFRNAPO = CODFRN
                        Me.AbtPdaObs(1 _
                                    , rowNUMCTTFRNORIPDA _
                                    , rowNUMCSLCTTFRNORIPDA _
                                    , rowTIPPODCTTFRNORIPDA _
                                    , rowNUMREFPODORIPDA _
                                    , rowTIPEDEABGMIXORIPDA _
                                    , rowCODEDEABGMIXORIPDA _
                                    , rowDATREFAPUORIPDA _
                                    , rowNUMSEQRLCCTTPMS _
                                    , CODFRN _
                                    , DESOBSAPO _
                                    , "D" _
                                    , rowVLRCRDUTZCTTFRN _
                                    , rowTIPFRMDSCBNFORIPDA _
                                    , rowTIPDSNDSCBNFORIPDA _
                                    , NOMACSUSRSISAPO _
                                    , Date.Now)
                    Else
                        '   CREATE   PROCEDURE [dbo].[spCLJ154] -- ENTRADA DE PARÂMETROS
                        Controller.InserePromessasEmAbertoDeAcordoEmpenho( _
                                rowNUMCTTFRN, _
                                rowNUMCSLCTTFRN, _
                                rowTIPPODCTTFRN, _
                                rowNUMREFPOD, _
                                rowTIPEDEABGMIX, _
                                rowCODEDEABGMIX, _
                                rowDATREFAPU, _
                                rowTIPFRMDSCBNF, _
                                rowTIPDSNDSCBNF, _
                                CODFRN, _
                                rowCODEMP, _
                                rowCODFILEMP, _
                                rowCODPMS, _
                                rowDATNGCPMS, _
                                rowDATPRVRCBPMS, _
                                rowTIPFRMDSCBNFORIPDA, _
                                rowTIPDSNDSCBNFORIPDA, _
                                rowVLRCRDUTZCTTFRN, _
                                DESOBSAPO, _
                                NOMACSUSRSISAPO, _
                                rowNUMSEQRLCCTTPMS, _
                                "C")
                    End If
                End If
            Next
            Return True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Public Function AbtPdaObs(ByVal TIPOPE As Integer _
                            , ByVal NUMCTTFRN As Decimal _
                            , ByVal NUMCSLCTTFRN As Decimal _
                            , ByVal TIPPODCTTFRN As Integer _
                            , ByVal NUMREFPOD As Integer _
                            , ByVal TIPEDEABGMIX As Integer _
                            , ByVal CODEDEABGMIX As Decimal _
                            , ByVal DATREFAPU As Date _
                            , ByVal NUMSEQRLCCTTPMS As Integer _
                            , ByVal CODFRN As Decimal _
                            , ByVal DESOBSCTTFRNAUX As String _
                            , ByVal TIPCNCPDACTTFRN As String _
                            , ByVal VLRCRDDISCTTFRN As Decimal _
                            , ByVal TIPFRMDSCBNF As Integer _
                            , ByVal TIPDSNDSCBNF As Integer _
                            , ByVal NOMACSUSRSIS As String _
                            , ByVal DATGRCOBSPMS As Date _
                            ) As Boolean
        '********************************************************************************************************
        '* Descrição : Abatimento Perda referente a Observação
        '********************************************************************************************************
        AbtPdaObs = False
        '        DESOBSCTTFRN = DESOBSCTTFRNAUX

        If TIPOPE = 0 Or TIPOPE = 1 Then

            'sMsgErr = "Abatimento da Pda. Des "
            '   CREATE   PROCEDURE [dbo].[spCLJ158]
            Controller.GravarObservacaoPerdaAcordo( _
                                                   0, _
                                                   NUMCTTFRN, _
                                                   NUMCSLCTTFRN, _
                                                   TIPPODCTTFRN, _
                                                   NUMREFPOD, _
                                                   TIPEDEABGMIX, _
                                                   CODEDEABGMIX, _
                                                   DATREFAPU, _
                                                   NUMSEQRLCCTTPMS, _
                                                   CODFRN, _
                                                   DESOBSCTTFRNAUX, _
                                                   TIPCNCPDACTTFRN, _
                                                   VLRCRDDISCTTFRN, _
                                                   TIPFRMDSCBNF, _
                                                   TIPDSNDSCBNF, _
                                                   NOMACSUSRSIS, _
                                                   DATREFAPU)
        End If

        If TIPOPE = 0 Then
            ''sMsgErr = "Abatimento da Pda. Des "
            ''   CREATE   PROCEDURE [dbo].[spCLJ157]
            Controller.CancelarPerdasDisponiveis(0, NUMCTTFRN, NUMCSLCTTFRN, TIPPODCTTFRN, NUMREFPOD, TIPEDEABGMIX, CODEDEABGMIX, DATREFAPU, VLRCRDDISCTTFRN)
        End If
        Return True
    End Function

    Private Function VrfQdeDdoVlr(ByRef grdObj As Infragistics.WebUI.UltraWebGrid.UltraWebGrid, ByVal strColGrid As String, ByRef objTxt As Infragistics.WebUI.WebDataInput.WebCurrencyEdit) As Integer
        '********************************************************************************************************
        '* Descrição : Verificar Quantidade de Dados de Valores
        '********************************************************************************************************
        Dim intQde As Integer = 0
        VrfQdeDdoVlr = 0
        objTxt.ValueDecimal = 0
        For intCont As Integer = 0 To grdObj.Rows.Count - 1
            If Convert.ToBoolean(grdObj.Rows.Item(intCont).Cells(0).Value) = True Then
                intQde += 1
                objTxt.ValueDecimal += Convert.ToDecimal(grdObj.Rows.Item(intCont).Cells.FromKey(strColGrid).Value)
            End If
        Next intCont
        VrfQdeDdoVlr = intQde
    End Function

#End Region

#Region " Métodos de Impressão"

    Private Function Validar() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = String.Empty

        Try
            Validar = True

            ''Opção1
            'If rblTipoFiltro.SelectedValue = "1" Then          
            '    'Fornecedor
            '    If ucFornecedor.CodFornecedor <= 0 Then
            '        If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '        mensagemErro &= "fornecedor não informado"
            '    End If     
            'End If

            'Opção2
            If rblTipoFiltro.SelectedValue = "2" Then
                'Fornecedor
                If ucFornecedor.CodFornecedor <= 0 Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "fornecedor não informado"
                End If

                'Data período
                If Not (IsDate(TxtDatIni.Text)) Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "período incial não informada ou inválida"
                ElseIf Not (IsDate(TxtDatFim.Text)) Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "período final não informada ou inválida"
                ElseIf Date.Parse(TxtDatIni.Text) > Date.Parse(TxtDatFim.Text) Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "data inicial do período maior que data final"
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

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            If Validar() = False Then
                Exit Sub
            End If

            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = True

            If rblTipoFiltro.SelectedValue = "1" Then
                ImprimirCreditosDisponiveis()
            ElseIf rblTipoFiltro.SelectedValue = "2" Then
                ImprimirAbatimentosRealizados()
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

            If rblTipoFiltro.SelectedValue = "1" Then
                ImprimirCreditosDisponiveis()
            ElseIf rblTipoFiltro.SelectedValue = "2" Then
                ImprimirAbatimentosRealizados()
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ImprimirCreditosDisponiveis()
        If rblTipoFiltro.SelectedValue = "1" Then
            ' Obter dados do relatório e guardar na seção
            WSCAcoesComerciais.dsRelacaoPerdasEmitidas = Controller.ObterRelacaoPerdasEmitidas_163(Integer.Parse(cmbCelula.SelectedValue), Convert.ToInt32(ucFornecedor.CodFornecedor))
            ' Guarda o nome do relatório na seção
            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "rpclj148a.rpt"
        End If
        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

    Private Sub ImprimirAbatimentosRealizados()
        If rblTipoFiltro.SelectedValue = "2" Then
            ' Obter dados do relatório e guardar na seção
            WSCAcoesComerciais.dsRelacaoPerdasEmitidas = Controller.ObterRelacaoPerdasEmitidas_164(Convert.ToInt32(ucFornecedor.CodFornecedor), Date.Parse(TxtDatIni.Text), Date.Parse(TxtDatFim.Text))
            ' Guarda o nome do relatório na seção
            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "rpclj148b.rpt"
        End If
        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

#End Region

#End Region

    Private Sub wtabCttPms_TabClick(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.UltraWebTab.WebTabEvent) Handles wtabCttPms.TabClick

    End Sub
End Class