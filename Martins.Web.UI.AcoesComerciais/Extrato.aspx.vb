Public Class Extrato
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dsExtratoMovimentoDiarioFornecedor = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetExtratoMovimentoDiarioFornecedor
        CType(Me.dsExtratoMovimentoDiarioFornecedor, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'dsExtratoMovimentoDiarioFornecedor
        '
        Me.dsExtratoMovimentoDiarioFornecedor.DataSetName = "DatasetExtratoMovimentoDiarioFornecedor"
        Me.dsExtratoMovimentoDiarioFornecedor.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.dsExtratoMovimentoDiarioFornecedor, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents ucEmpenho As wucEmpenho
    Protected WithEvents txtSldAnt As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtVlrRcb As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents lblSldDisponivel As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtDebito As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtSldAtual As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtMesRef As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtSldPms As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents dsExtratoMovimentoDiarioFornecedor As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetExtratoMovimentoDiarioFornecedor
    Protected WithEvents btnImprimir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ddlDisponivel As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCredito As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents btnCelulas As System.Web.UI.WebControls.LinkButton
    Protected WithEvents grdLancamentos As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents grdAlocacoes As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents btnVisualizar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents btnCarimbo As System.Web.UI.WebControls.LinkButton

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region " Propriedades "

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
            btnImprimir.Enabled = True
            btnVisualizar.Enabled = True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnCelulas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCelulas.Click
        Try
            Util.ShowPopUp(False, False)
            Page.RegisterStartupScript("ExtratoCelula", "<script>ShowPopUp('ExtratoCelula.aspx', 'ExtratoCelula', 280, 300)</script>")
            Exit Sub
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

    Private Sub ddlDisponivel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDisponivel.SelectedIndexChanged
        Try
            If ddlDisponivel.SelectedValue.Equals(1) Or ddlDisponivel.SelectedValue.Equals(2) Then
                If Not WSCAcoesComerciais.dsUsuarioCompra.T0113471.Item(0).TIPUSRSIS.Equals("X") Then
                    Util.AdicionaJsAlert(Me.Page, "Acesso restrito à controladoria.")
                    ddlDisponivel.SelectedIndex = 0
                End If
            End If
            LimparControles()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ucEmpenho_EmpenhoAlterado(ByVal e As System.Web.UI.WebControls.ListItem) Handles ucEmpenho.EmpenhoAlterado
        Try
            Me.LimparControles()
            'Me.Pesquisar()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = True
            'Pesquisar()
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

    Private Sub ucFornecedor_FornecedorAlterado(ByVal e As System.Web.UI.WebControls.ListItem) Handles ucFornecedor.FornecedorAlterado
        LimparControles()
    End Sub

    Private Sub txtMesRef_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtMesRef.ValueChange
        LimparControles()
    End Sub

    Private Sub btnCarimbo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCarimbo.Click
        Try
            Util.ShowPopUp(False, False)
            Page.RegisterStartupScript("ExtratoCarimbo", "<script>ShowPopUp('ExtratoCarimbo.aspx', 'ExatratoCarimbo', 500, 500)</script>")
            Exit Sub
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub
#End Region

#Region " Metodos "

#Region " Métodos de Carga "

    Private Sub InicializaPagina()
        btnCelulas.Attributes.Add("OnClick", "javascript:MostrarJanelaModal();")
        btnImprimir.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        btnVisualizar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        btnPesquisar.Attributes.Add("OnClick", "javascript:mostraAndamento()")

        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If

        If (Not Me.IsPostBack) Then
            Me.CargaInicialDados()
            ddlDisponivel.SelectedValue = "0"
            With ucFornecedor
                ucFornecedor.widthNome = System.Web.UI.WebControls.Unit.Parse("270px")
            End With
        Else
            Me.RecuperaEstado()
        End If
    End Sub

    Private Sub RecuperaEstado()
        'If Not ViewState.Item(dsTrocaManualTituloPagamentoAcordoComercial.DataSetName) Is Nothing Then _
        '    dsTrocaManualTituloPagamentoAcordoComercial = DirectCast(Me.ViewState.Item(dsTrocaManualTituloPagamentoAcordoComercial.DataSetName), wsAcoesComerciais.DatasetTrocaManualTituloPagamentoAcordoComercial)
    End Sub

    Private Sub SalvaEstado()
        'If Not dsTrocaManualTituloPagamentoAcordoComercial Is Nothing Then _
        '    Me.ViewState.Add(dsTrocaManualTituloPagamentoAcordoComercial.DataSetName, dsTrocaManualTituloPagamentoAcordoComercial)
    End Sub

    Private Sub CargaInicialDados()
        ' CARREGA OS DADOS INICIAIS
        Try
            Me.ucEmpenho.IncluirItemTodos = True
            txtMesRef.Date = Date.Today
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#Region " Métodos de Controles "

    Private Sub LimparControles()
        Util.LimpaControles(New WebControl() {txtCredito, txtDebito, txtSldAnt, txtSldAtual, txtSldPms, txtVlrRcb, lblSldDisponivel, grdAlocacoes, grdLancamentos})
        btnImprimir.Enabled = False
        btnVisualizar.Enabled = False
    End Sub

#End Region

#Region " Metodos de Regras de Negocio "

    Private Function Validar() As Boolean
        If ucFornecedor.CodFornecedor <= 0 Then
            Util.AdicionaJsAlert(Me.Page, "O Campo Fornecedor é Obrigatório!")
            Util.AdicionaJsFocus(Me.Page, CType(ucFornecedor.FindControl("txtCodigo"), WebControl))
            Return False
        End If
        If txtMesRef.Value Is String.Empty Then
            Util.AdicionaJsAlert(Me.Page, "O Campo Mês Ref. é Inválido!")
            Util.AdicionaJsFocus(Me.Page, CType(txtMesRef, WebControl))
            Return False
        End If
        Return True
    End Function

    Private Sub Pesquisar()
        Try
            If Me.Validar() Then
                LimparControles()
                dsExtratoMovimentoDiarioFornecedor = Controller.ObterPesquisaExtratoMovimentoDiarioFornecedor(txtMesRef.Date.Year, txtMesRef.Date.Month, Convert.ToInt32(ucFornecedor.CodFornecedor), CInt(ucEmpenho.CodEmpenho.ToString), ddlDisponivel.SelectedValue, 2)
                Me.CarregaGridAlocacoes()
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub CarregaGridAlocacoes()
        If dsExtratoMovimentoDiarioFornecedor.tbExtratoMovimentoDiarioFornecedor.Rows.Count > 0 Then
            Dim dblCredito As Decimal = Decimal.Zero
            Dim dblDebito As Decimal = Decimal.Zero
            Dim dblSaldoAnt As Decimal = Decimal.Zero
            Dim dblSaldoPms As Decimal = Decimal.Zero
            Dim dblSldDsp As Decimal = Decimal.Zero
            Dim iTipDsnDscBnf As Integer = 0
            Dim dVlrRcb As Decimal = Decimal.Zero
            Dim dVlrSldAlc As Decimal = Decimal.Zero
            Dim dVlrRcbAlc As Decimal = Decimal.Zero
            Dim dSldDspAlc As Decimal = Decimal.Zero

            For Each drExtratoMovimentoDiarioFornecedor As wsAcoesComerciais.DatasetExtratoMovimentoDiarioFornecedor.tbExtratoMovimentoDiarioFornecedorRow _
                    In dsExtratoMovimentoDiarioFornecedor.tbExtratoMovimentoDiarioFornecedor.Select("", "TipDsnDscBnf")
                If drExtratoMovimentoDiarioFornecedor.PmtDdo.Equals("B") Then
                    With grdAlocacoes
                        Dim rowAlocacoes As New Infragistics.WebUI.UltraWebGrid.UltraGridRow(True)
                        With rowAlocacoes
                            .Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
                            .Cells(0).Value = String.Concat(" ", drExtratoMovimentoDiarioFornecedor.DesDsnDscBnf)
                            .Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
                            .Cells(1).Value = String.Concat(drExtratoMovimentoDiarioFornecedor.TipAlcVbaFrn, " - ", drExtratoMovimentoDiarioFornecedor.DesAlcVbaFrn)
                            .Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
                            .Cells(2).Value = drExtratoMovimentoDiarioFornecedor.VlrAlcVbaFrn
                            .Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
                            .Cells(3).Value = drExtratoMovimentoDiarioFornecedor.VlrRcbAlcVbaFrn
                            .Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
                            .Cells(4).Value = drExtratoMovimentoDiarioFornecedor.VlrSldDspAlcVbaFrn
                        End With
                        .Rows.Add(rowAlocacoes)
                    End With
                Else
                    If drExtratoMovimentoDiarioFornecedor.TipDsnDscBnf <> iTipDsnDscBnf Then
                        If drExtratoMovimentoDiarioFornecedor.IsSldDspNull Then
                            dblSldDsp = dblSldDsp + 0
                        Else
                            dblSldDsp = dblSldDsp + drExtratoMovimentoDiarioFornecedor.SldDsp
                            System.Diagnostics.Debug.WriteLine(drExtratoMovimentoDiarioFornecedor.TipDsnDscBnf.ToString & " - " & drExtratoMovimentoDiarioFornecedor.SldDsp.ToString)
                        End If
                        dblCredito = dblCredito + drExtratoMovimentoDiarioFornecedor.VlrCrdMesCrr
                        dblDebito = dblDebito + drExtratoMovimentoDiarioFornecedor.VlrDebMesCrr
                        dblSaldoAnt = dblSaldoAnt + drExtratoMovimentoDiarioFornecedor.VlrSldMesAnt
                        dblSaldoPms = dblSaldoPms + drExtratoMovimentoDiarioFornecedor.VlrSldPms
                        iTipDsnDscBnf = drExtratoMovimentoDiarioFornecedor.TipDsnDscBnf
                        dVlrRcb = dVlrRcb + drExtratoMovimentoDiarioFornecedor.VlrRcb
                        dVlrRcbAlc = drExtratoMovimentoDiarioFornecedor.VlrRcb
                        dSldDspAlc = dblSldDsp
                    End If
                    If drExtratoMovimentoDiarioFornecedor.DesTipLmt.Trim() <> String.Empty Then
                        With grdLancamentos
                            Dim rowLancamentos As New Infragistics.WebUI.UltraWebGrid.UltraGridRow(True)
                            With rowLancamentos
                                .Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
                                .Cells(0).Value = drExtratoMovimentoDiarioFornecedor.DatRefLmt
                                .Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
                                .Cells(1).Value = drExtratoMovimentoDiarioFornecedor.CodGdc
                                .Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
                                .Cells(2).Value = drExtratoMovimentoDiarioFornecedor.NumSeqLmt
                                .Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
                                .Cells(3).Value = drExtratoMovimentoDiarioFornecedor.DesDsnDscBnf
                                .Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
                                .Cells(4).Value = drExtratoMovimentoDiarioFornecedor.DesTipLmt
                                .Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
                                .Cells(5).Value = drExtratoMovimentoDiarioFornecedor.DesHstLmt
                                .Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
                                .Cells(6).Value = drExtratoMovimentoDiarioFornecedor.VlrLmtCtb
                                .Cells.Add(New Infragistics.WebUI.UltraWebGrid.UltraGridCell)
                                .Cells(7).Value = drExtratoMovimentoDiarioFornecedor.NomAcsUsrGrcLmt
                            End With
                            .Rows.Add(rowLancamentos)
                        End With
                    End If
                End If
            Next

            ' Atualiza resumo de saldo
            txtCredito.Value = dblCredito
            txtDebito.Value = dblDebito
            txtSldPms.Value = dblSaldoPms
            txtSldAnt.Value = dblSaldoAnt
            txtSldAtual.Value = dblSaldoAnt + dblCredito - dblDebito
            txtVlrRcb.Value = dVlrRcb
            lblSldDisponivel.Value = dblSldDsp
        End If
    End Sub

#End Region

#End Region

#Region " Relatório "

    Private Sub ImprimirExtrato()
        'Coloca os parametros na seção
        Dim htFormulas As New Hashtable
        'Guarda as Formulas na seção
        With htFormulas
            .Add("NomRel", "'CCX001i.rpt'")

            Try
                .Add("Usuario", "'" & Controller.ObterUsuariosCompraLogadoSistema.T0113471(0).NOMACSUSRSIS.ToUpper.Trim & "'")
            Catch ex As Exception
                Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
                Exit Sub
            End Try

            .Add("AnoMesRef", "'" & Format(txtMesRef.Date, "yyyy/MM") & "'")
            .Add("SldDsp", "'" & Format(lblSldDisponivel.ValueDecimal, "###,###,###,##0.00") & "'")
        End With
        WSCAcoesComerciais.hashtableFormulasCrystal = htFormulas

        'Obter dados do relatório e guardar na seção
        WSCAcoesComerciais.dsRelatorioExtratoContaCorrrente = Controller.ObterRelatorioExtratoContaCorrrente_012(txtMesRef.Date.Year, txtMesRef.Date.Month, Convert.ToInt32(ucFornecedor.CodFornecedor), CInt(ucEmpenho.CodEmpenho.ToString), ddlDisponivel.SelectedValue, 2)

        'Guarda o nome do relatório na seção
        WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "CCX001i.rpt"
        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

#End Region


End Class