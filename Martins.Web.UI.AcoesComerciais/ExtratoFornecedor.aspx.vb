Public Class ExtratoFornecedor
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dsRelatorioExtratoContaCorrrente = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DataSetRelatorioExtratoContaCorrrente
        CType(Me.dsRelatorioExtratoContaCorrrente, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'dsRelatorioExtratoContaCorrrente
        '
        Me.dsRelatorioExtratoContaCorrrente.DataSetName = "DataSetRelatorioExtratoContaCorrrente"
        Me.dsRelatorioExtratoContaCorrrente.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.dsRelatorioExtratoContaCorrrente, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Linkbutton2 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtDataInicial As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtDataFinal As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents WebDateTimeEdit1 As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents WebDateTimeEdit2 As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents ucEmpenho As wucEmpenho
    Protected WithEvents btnImprimir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtSaldoAnterior As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtCreditos As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtValorAReceber As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtAcordosAReceber As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtDebitos As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtSaldoDisponivel As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtMovimentacao As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents grdLancamentos As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents cmbEmpenho As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dsRelatorioExtratoContaCorrrente As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DataSetRelatorioExtratoContaCorrrente
    Protected WithEvents txtEmpenho As Infragistics.WebUI.WebDataInput.WebNumericEdit
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

#Region "Propriedades"

    Private ReadOnly Property StrTipDsnDscBnf() As String
        Get
            Dim result As String = String.Empty
            Dim count As Integer

            If cmbEmpenho.SelectedValue = "0" Then 'Todos Empenhos
                For count = 1 To cmbEmpenho.Items.Count - 1
                    result &= Format(Convert.ToInt32(cmbEmpenho.Items(count).Value), "00") & ","
                Next count
                result = Mid(result, 1, Len(result) - 1)
            Else
                result = Format(Convert.ToInt32(cmbEmpenho.SelectedValue), "00")
            End If

            Return result
        End Get
    End Property

#End Region

#Region " Eventos "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.InicializaPagina()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Try
            Me.Pesquisar()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("TransferenciaGacListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        Try
            Me.SalvaEstado()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ucEmpenho_EmpenhoAlterado(ByVal e As System.Web.UI.WebControls.ListItem) Handles ucEmpenho.EmpenhoAlterado
        Try
            LimparControles()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = True
            Pesquisar()
            ImprimirExtrato()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = False
            Pesquisar()
            ImprimirExtrato()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmbEmpenho_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpenho.SelectedIndexChanged
        Try
            If txtEmpenho.Text <> cmbEmpenho.SelectedValue.ToString Then
                txtEmpenho.Text = cmbEmpenho.SelectedValue.ToString
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub txtEmpenho_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtEmpenho.ValueChange
        Try
            If txtEmpenho.Text <> cmbEmpenho.SelectedValue.ToString Then
                If cmbEmpenho.Items.FindByValue(txtEmpenho.Text) Is Nothing Then
                    Util.AdicionaJsAlert(Me.Page, "Empenho não encontrado")
                    txtEmpenho.Text = ""
                    Exit Sub
                End If
                cmbEmpenho.SelectedValue = txtEmpenho.Text
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ucFornecedor_FornecedorAlterado(ByVal e As System.Web.UI.WebControls.ListItem) Handles ucFornecedor.FornecedorAlterado
        LimparControles()
    End Sub

#End Region

#Region " Metodos "

#Region " Métodos de Carga "

    Private Sub InicializaPagina()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        btnImprimir.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        btnPesquisar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        btnVisualizar.Attributes.Add("OnClick", "javascript:mostraAndamento()")

        If (Not Me.IsPostBack) Then
            Me.CargaInicialDados()
            ucFornecedor.widthNome = System.Web.UI.WebControls.Unit.Parse("270px")
        Else
            Me.RecuperaEstado()
        End If
    End Sub

    Private Sub RecuperaEstado()
    End Sub

    Private Sub SalvaEstado()
    End Sub

    Private Sub CargaInicialDados()
        ' CARREGA OS DADOS INICIAIS
        Try
            Me.carregarCmbEmpenho(Controller.ObterEmpenhos("", "", "", 0, ""), cmbEmpenho, New ListItem("Todos", "0"))
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Public Shared Sub carregarCmbEmpenho(ByRef ds As wsAcoesComerciais.DatasetEmpenho, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetEmpenho.T0109059Row In ds.T0109059.Select("", "TIPDSNDSCBNF")
                .Items.Add(New ListItem(Format(linha.TIPDSNDSCBNF, "0000") & " - " & linha.DESDSNDSCBNF, linha.TIPDSNDSCBNF.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

#End Region

#Region " Métodos de Controles "

    Private Sub LimparControles()
        Util.LimpaControles(New WebControl() {txtSaldoAnterior, txtValorAReceber, txtDebitos, txtMovimentacao, txtCreditos, txtAcordosAReceber, txtSaldoDisponivel, grdLancamentos})
    End Sub

#End Region

#Region " Metodos de Regras de Negocio "

    Private Function Validar() As Boolean
        If ucFornecedor.CodFornecedor <= 0 Then
            Util.AdicionaJsAlert(Me.Page, "O Campo Fornecedor é Obrigatório!")
            Util.AdicionaJsFocus(Me.Page, CType(ucFornecedor.FindControl("txtCodigo"), WebControl))
            Return False
        End If
        If Not (IsNumeric(cmbEmpenho.SelectedValue)) Then
            Util.AdicionaJsAlert(Me.Page, "O Campo Empenho é Obrigatório!")
            Util.AdicionaJsFocus(Me.Page, CType(cmbEmpenho, WebControl))
            Return False
        End If
        If txtDataInicial.Date = Nothing Then
            Util.AdicionaJsAlert(Me.Page, "Data Inicial não informada!")
            Util.AdicionaJsFocus(Me.Page, CType(txtDataInicial, WebControl))
            Return False
        End If
        If txtDataFinal.Date = Nothing Then
            Util.AdicionaJsAlert(Me.Page, "Data final não informada!")
            Util.AdicionaJsFocus(Me.Page, CType(txtDataFinal, WebControl))
            Return False
        Else
            If txtDataInicial.Date > txtDataFinal.Date Then
                Util.AdicionaJsAlert(Me.Page, "A Data de Ínicio não pode ser maior(>) que Data de Fim.")
                Util.AdicionaJsFocus(Me.Page, CType(txtDataInicial, WebControl))
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub Pesquisar()
        Try
            If Me.Validar() Then
                LimparControles()
                dsRelatorioExtratoContaCorrrente = Controller.ObterRelatorioExtratoContaCorrrente_048(txtDataInicial.Date, txtDataFinal.Date, Convert.ToInt32(ucFornecedor.CodFornecedor), Convert.ToInt32(cmbEmpenho.SelectedValue), "0", 0, StrTipDsnDscBnf)
                Me.CarregaGridLancamentos()
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function CarregaGridLancamentos() As Boolean
        'Preenche o grid
        grdLancamentos.DataBind()

        Dim bFlg As Boolean = False
        Dim lin As Integer
        Dim iTipDsnDscBnf As Integer
        Dim dblCredito As Decimal
        Dim dblDebito As Decimal
        Dim dblSaldoAnt As Decimal
        Dim dblSaldoPms As Decimal
        Dim dblSldDsp As Decimal

        Dim dVlrRcb As Decimal
        Dim sDesSldAlc As String = String.Empty
        Dim CodGdc As String = String.Empty

        Dim dVlrSldAlc As Decimal
        Dim dVlrRcbAlc As Decimal
        Dim dSldDspAlc As Decimal
        Dim nCount As Integer
        Dim iLnh As Integer

        Dim sFlgMsg As String = String.Empty

        dVlrRcb = 0
        sDesSldAlc = ""
        dVlrSldAlc = 0
        dVlrRcbAlc = 0
        dSldDspAlc = 0
        dblCredito = 0
        dblDebito = 0
        dblSaldoAnt = 0
        dblSaldoPms = 0
        dblSldDsp = 0


        If dsRelatorioExtratoContaCorrrente.TbExtratoContaCorrrente_048.Rows.Count > 0 Then

            dblSldDsp = 0
            iTipDsnDscBnf = 0
            dblCredito = 0
            dblDebito = 0
            dblSaldoAnt = 0
            dblSaldoPms = 0

            For Each linha As wsAcoesComerciais.DataSetRelatorioExtratoContaCorrrente.TbExtratoContaCorrrente_048Row In dsRelatorioExtratoContaCorrrente.TbExtratoContaCorrrente_048 '.Select("", "TipDsnDscBnf")
                If linha.VlrLmtCtb > 0 Then
                    dblCredito = dblCredito + linha.VlrLmtCtb
                Else
                    dblDebito = dblDebito + linha.VlrLmtCtb
                End If


                If linha.TipDsnDscBnf <> iTipDsnDscBnf Then
                    If linha.IsNull("SldDsp") Then
                        dblSldDsp = dblSldDsp + 0
                    Else
                        dblSldDsp = dblSldDsp + linha.SldDsp
                    End If
                    dblSaldoAnt = dblSaldoAnt + linha.VlrSldMesAnt
                    dblSaldoPms = dblSaldoPms + linha.VlrSldPms
                    iTipDsnDscBnf = linha.TipDsnDscBnf
                    dVlrRcb = dVlrRcb + linha.VlrRcb
                    dVlrRcbAlc = linha.VlrRcb
                    dSldDspAlc = dblSldDsp
                End If
            Next

            If cmbEmpenho.SelectedValue <> "0" Then
                grdLancamentos.Columns(0).Hidden = True
                grdLancamentos.Columns(3).Hidden = True
            End If

            If grdLancamentos.Rows.Count = 0 Then
                If sFlgMsg.Trim.Length = 0 Then Util.AdicionaJsAlert(Me.Page, "Não existe nenhuma movimentação.")
            Else
                bFlg = True
            End If
        Else
            If sFlgMsg.Trim.Length = 0 Then Util.AdicionaJsAlert(Me.Page, "Não existe nenhuma movimentação.")
            Util.AdicionaJsFocus(Me.Page, CType(cmbEmpenho, System.Web.UI.WebControls.WebControl))
        End If
        ' Atualiza resumo de saldo
        txtCreditos.ValueDecimal = dblCredito
        txtDebitos.ValueDecimal = dblDebito
        txtAcordosAReceber.ValueDecimal = dblSaldoPms
        txtSaldoAnterior.ValueDecimal = dblSaldoAnt
        txtMovimentacao.ValueDecimal = dblSaldoAnt + dblCredito + dblDebito
        If dVlrRcb = -1 Then
            dVlrRcb = 0
        End If
        txtValorAReceber.ValueDecimal = dVlrRcb
        txtSaldoDisponivel.ValueDecimal = dblSldDsp

        Return bFlg
    End Function

    Private Sub ImprimirExtrato()
        'Coloca os parametros na seção
        Dim htFormulas As New Hashtable
        'Guarda as Formulas na seção
        With htFormulas
            .Add("NomRel", "'CCX001ia.rpt'")
            .Add("DataInicial", "date(" & txtDataInicial.Date.Year.ToString & "," & txtDataInicial.Date.Month.ToString & "," & txtDataInicial.Date.Day.ToString & ")")
            .Add("DataFinal", "date(" & txtDataFinal.Date.Year.ToString & "," & txtDataFinal.Date.Month.ToString & "," & txtDataFinal.Date.Day.ToString & ")")

            Try
                .Add("Usuario", "'" & Controller.ObterUsuariosCompraLogadoSistema.T0113471(0).NOMACSUSRSIS.ToUpper.Trim & "'")
            Catch ex As Exception
                Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
                Exit Sub
            End Try

            .Add("SldDsp", "'" & txtSaldoDisponivel.Text & "'")
            .Add("Hora", "'" & Format(Date.Now, "hh:ss") & "'")
        End With
        WSCAcoesComerciais.hashtableFormulasCrystal = htFormulas
        'Obter dados do relatório e guardar na seção
        WSCAcoesComerciais.dsRelatorioExtratoContaCorrrente = Controller.ObterRelatorioExtratoContaCorrrente_048(txtDataInicial.Date, txtDataFinal.Date, Convert.ToInt32(ucFornecedor.CodFornecedor), Convert.ToInt32(cmbEmpenho.SelectedValue), "0", 0, StrTipDsnDscBnf)
        'Guarda o nome do relatório na seção
        WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "CCX001ia.rpt"
        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

#End Region

#End Region

End Class