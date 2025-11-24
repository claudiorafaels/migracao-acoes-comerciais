Public Class AlteraFormaPagamento
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dsSelecaoValorAcordoDuplicataNaoRelacionada = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetSelecaoValorAcordoDuplicataNaoRelacionada
        Me.dsDuplicatasDisponiveis = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetDuplicatasDisponiveis
        Me.DatasetAcordo = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetAcordo
        CType(Me.dsSelecaoValorAcordoDuplicataNaoRelacionada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsDuplicatasDisponiveis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetAcordo, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'dsSelecaoValorAcordoDuplicataNaoRelacionada
        '
        Me.dsSelecaoValorAcordoDuplicataNaoRelacionada.DataSetName = "DatasetSelecaoValorAcordoDuplicataNaoRelacionada"
        Me.dsSelecaoValorAcordoDuplicataNaoRelacionada.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'dsDuplicatasDisponiveis
        '
        Me.dsDuplicatasDisponiveis.DataSetName = "DatasetDuplicatasDisponiveis"
        Me.dsDuplicatasDisponiveis.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DatasetAcordo
        '
        Me.DatasetAcordo.DataSetName = "DatasetAcordo"
        Me.DatasetAcordo.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.dsSelecaoValorAcordoDuplicataNaoRelacionada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsDuplicatasDisponiveis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetAcordo, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ddlDesconto As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rbDuplicata As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbBonificacao As System.Web.UI.WebControls.RadioButton
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents btnImprimir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents dsSelecaoValorAcordoDuplicataNaoRelacionada As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetSelecaoValorAcordoDuplicataNaoRelacionada
    Protected WithEvents ddlFormaPagamento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents trDuplicatas01 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents dsDuplicatasDisponiveis As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetDuplicatasDisponiveis
    Protected WithEvents grdContratos As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents txtFornecedor As System.Web.UI.WebControls.Label
    Protected WithEvents grdDuplicatas As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents trDuplicatas02 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trDuplicatas03 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents DatasetAcordo As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetAcordo
    Protected WithEvents btnVisualizar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td1 As System.Web.UI.HtmlControls.HtmlTableCell
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

    Private Property flagProcessando() As Boolean

        Get
            Dim result As Boolean = False
            If Not viewstate("flagProcessando") Is Nothing Then
                result = CType(viewstate("flagProcessando"), Boolean)
            End If
            Return result
        End Get

        Set(ByVal Value As Boolean)
            viewstate("flagProcessando") = Value
        End Set

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

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            If flagProcessando Then
                Exit Sub
            End If
            flagProcessando = True

            If Me.ddlFormaPagamento.SelectedIndex > 0 Then
                Me.Gerar_Nova_Promessa()
                Util.AdicionaJsAlert(Me, "Forma de pagamento atualizada com sucesso para os registros selecionados!")
            Else
                Util.AdicionaJsAlert(Me, "Informe a nova forma de pagamento!")
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        Finally
            flagProcessando = False
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("Branca.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ddlDesconto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDesconto.SelectedIndexChanged
        Try

            TrocaDesconto()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub rbDuplicata_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDuplicata.CheckedChanged
        Try
            If ucFornecedor.CodFornecedor > -1 Then
                Me.CarregaContratos(vOpcao:=2, vCodFrn:=Convert.ToInt32(ucFornecedor.CodFornecedor))
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub rbBonificacao_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBonificacao.CheckedChanged
        Try
            If ucFornecedor.CodFornecedor > -1 Then
                Me.CarregaContratos(vOpcao:=3, vCodFrn:=Convert.ToInt32(ucFornecedor.CodFornecedor))
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub grdContratos_InitializeRow(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.UltraWebGrid.RowEventArgs) Handles grdContratos.InitializeRow
        Try
            'Dim A As Decimal = Me.CalculaValorResidual(CType(e.Data, wsAcoesComerciais.DatasetSelecaoValorAcordoDuplicataNaoRelacionada.tbSelecaoValorAcordoDuplicataNaoRelacionadaRow))
            '    FOR I AS Integer 
            '    e.Row.Cells(3).Value = A
            'e.Row.DataKey = CType(e.Data, wsAcoesComerciais.DatasetSelecaoValorAcordoDuplicataNaoRelacionada.tbSelecaoValorAcordoDuplicataNaoRelacionadaRow).DSINDEX

            Dim valorResidual As Decimal = Decimal.Zero
            If CType(e.Row.Cells(7).Value, Decimal) > CType(e.Row.Cells(4).Value, Decimal) Then
                valorResidual = CType(e.Row.Cells(7).Value, Decimal) - CType(e.Row.Cells(4).Value, Decimal)
            End If
            If valorResidual < 0.01 Then
                valorResidual = 0
            End If
            e.Row.Cells(3).Value = valorResidual
            e.Row.DataKey = e.Row.Cells(20).Value
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub grdContratos_Click(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.UltraWebGrid.ClickEventArgs) Handles grdContratos.Click
        Try
            If Not e.Row Is Nothing Then
                Me.MostraDuplicatasDisponiveis(Convert.ToInt32(e.Row.DataKey))
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ddlFormaPagamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlFormaPagamento.SelectedIndexChanged
        Dim row As Infragistics.WebUI.UltraWebGrid.UltraGridRow = obterLinhaSelecionadaGrid()

        If ddlFormaPagamento.SelectedValue = "2" Then
            If Not row Is Nothing Then
                If dsSelecaoValorAcordoDuplicataNaoRelacionada.tbSelecaoValorAcordoDuplicataNaoRelacionada.Rows.Count = 0 Then
                    dsSelecaoValorAcordoDuplicataNaoRelacionada.Merge(CType(Session("dataSetGrid"), DataSet), False, MissingSchemaAction.Ignore)
                End If
                MostraDuplicatasDisponiveis(Convert.ToInt32(row.DataKey), False)
                Session("NumeroSeq") = dsSelecaoValorAcordoDuplicataNaoRelacionada.tbSelecaoValorAcordoDuplicataNaoRelacionada.FindByDSINDEX(Convert.ToInt32(row.DataKey)).NUMSEQRLCCTTPMS
            Else
                ddlFormaPagamento.SelectedIndex = 0
                Util.AdicionaJsAlert(Me.Page, "Selecione uma linha do grid")
            End If
        Else
            Me.MostrarControlesDuplicatas(False)
        End If
    End Sub

    Private Function obterLinhaSelecionadaGrid() As Infragistics.WebUI.UltraWebGrid.UltraGridRow
        If grdContratos.Rows.Count > 0 Then
            For Each row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In grdContratos.Rows
                If Convert.ToBoolean(row.Cells(0).Value) Then
                    Return row
                End If
            Next
        End If
    End Function

#End Region

#Region " Metodos "

#Region " Metodos de Carga "

    Private Sub InicializaPagina()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If

        btnImprimir.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        btnVisualizar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")

        If (Not IsPostBack) Then
            Me.MostrarControlesDuplicatas(False)
            Me.CarregaGridContratos()
            With ucFornecedor
                ucFornecedor.widthCodigo = System.Web.UI.WebControls.Unit.Parse("60px")
                ucFornecedor.widthNome = System.Web.UI.WebControls.Unit.Parse("280px")
            End With
        End If

    End Sub

    Private Sub RecuperaEstado()
        If Not ViewState.Item(dsSelecaoValorAcordoDuplicataNaoRelacionada.DataSetName) Is Nothing Then _
            dsSelecaoValorAcordoDuplicataNaoRelacionada = DirectCast(Me.ViewState.Item(dsSelecaoValorAcordoDuplicataNaoRelacionada.DataSetName), wsAcoesComerciais.DatasetSelecaoValorAcordoDuplicataNaoRelacionada)
    End Sub

    Private Sub SalvaEstado()
        If Not dsSelecaoValorAcordoDuplicataNaoRelacionada Is Nothing Then _
            Me.ViewState.Add(dsSelecaoValorAcordoDuplicataNaoRelacionada.DataSetName, dsSelecaoValorAcordoDuplicataNaoRelacionada)
    End Sub

    Private Sub CarregaGridContratos()
        If ddlDesconto.SelectedValue.Equals("IPP") Then
            ucFornecedor.Enabled = False
            Me.CarregaContratos(vOpcao:=1, RecarregaDS:=True)
        ElseIf ddlDesconto.SelectedValue.Equals("IPC/BCC") Then
            ucFornecedor.Enabled = True
            If rbBonificacao.Checked Then
                Me.CarregaContratos(vOpcao:=3, RecarregaDS:=True, vCodFrn:=Convert.ToInt32(ucFornecedor.CodFornecedor))
            Else
                Me.CarregaContratos(vOpcao:=2, RecarregaDS:=True, vCodFrn:=Convert.ToInt32(ucFornecedor.CodFornecedor))
            End If
        End If
    End Sub

    Private Sub CarregaContratos(Optional ByVal PageIndex As Integer = 0, Optional ByVal RecarregaDS As Boolean = True, Optional ByVal vOpcao As Integer = 0, Optional ByVal vCodFrn As Integer = 0)
        Try
            If RecarregaDS = True Then
                Session("dataSetGrid") = Nothing
                dsSelecaoValorAcordoDuplicataNaoRelacionada.Clear()
                Session("dataSetGrid") = Controller.ObterSelecaoValorAcordoDuplicataNaoRelacionada(vOpcao, vCodFrn)
                dsSelecaoValorAcordoDuplicataNaoRelacionada.Merge(CType(Session("dataSetGrid"), DataSet), False, MissingSchemaAction.Ignore)
            End If
            Me.grdContratos.DataBind()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub CarregaDuplicatas(ByVal vCodFrn As Integer, Optional ByVal PageIndex As Integer = 0, Optional ByVal RecarregaDS As Boolean = True)
        If RecarregaDS = True Then dsDuplicatasDisponiveis = Controller.ObterDuplicatasDisponiveis(vCodFrn)
        grdDuplicatas.DataBind()
    End Sub

#End Region

#Region " Metodos de Controles "

    Private Sub MostrarControlesDuplicatas(ByVal bView As Boolean)
        trDuplicatas01.Visible = bView
        trDuplicatas02.Visible = bView
        trDuplicatas03.Visible = bView
    End Sub

#End Region

#Region " Métodos de Regras de Negócio "

    Private Function CalculaValorResidual(ByVal dr As wsAcoesComerciais.DatasetSelecaoValorAcordoDuplicataNaoRelacionada.tbSelecaoValorAcordoDuplicataNaoRelacionadaRow) As Decimal
        CalculaValorResidual = 0
        If dr.VLRRCBEFTFXA > dr.VLRRCBPCL Then
            CalculaValorResidual = dr.VLRRCBEFTFXA - dr.VLRRCBPCL
        End If
        If CalculaValorResidual < 0.01 Then
            CalculaValorResidual = 0
        End If
    End Function

    Private Sub TrocaDesconto()
        Me.grdContratos.DataSource = Nothing
        Me.grdContratos.DataBind()
        If ddlDesconto.SelectedValue.Equals("IPP") Then
            Util.HabilitaControles(New WebControl() {rbBonificacao, rbDuplicata}, False)
            ucFornecedor.Enabled = False
            Util.LimpaControles(New WebControl() {rbBonificacao, rbDuplicata})
            ucFornecedor.ReinicializaControle()
            Me.CarregaContratos(vOpcao:=1, RecarregaDS:=True)
        ElseIf ddlDesconto.SelectedValue.Equals("IPC/BCC") Then
            Util.HabilitaControles(New WebControl() {rbBonificacao, rbDuplicata}, True) : ucFornecedor.Enabled = True
        End If
    End Sub

    Private Sub Gerar_Nova_Promessa()
        If dsSelecaoValorAcordoDuplicataNaoRelacionada.tbSelecaoValorAcordoDuplicataNaoRelacionada.Rows.Count = 0 Then
            dsSelecaoValorAcordoDuplicataNaoRelacionada.Merge(CType(Session("dataSetGrid"), DataSet), False, MissingSchemaAction.Ignore)
        End If
        If grdContratos.Rows.Count > 0 Then
            For Each row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In grdContratos.Rows
                If Convert.ToBoolean(row.Cells(0).Value) Then
                    If ddlFormaPagamento.SelectedValue.Equals("2") Then
                        'Se duplicata mostra as duplicatas disponíveis
                        MostraDuplicatasDisponiveis(Convert.ToInt32(row.DataKey))
                        Session("NumeroSeq") = dsSelecaoValorAcordoDuplicataNaoRelacionada.tbSelecaoValorAcordoDuplicataNaoRelacionada.FindByDSINDEX(Convert.ToInt32(row.DataKey)).NUMSEQRLCCTTPMS
                    ElseIf ddlFormaPagamento.SelectedValue.Equals("9") Then
                        'Gera desconto em bonificacao
                        Me.GeraDescontoBonificacao(dsSelecaoValorAcordoDuplicataNaoRelacionada.tbSelecaoValorAcordoDuplicataNaoRelacionada.FindByDSINDEX(Convert.ToInt32(row.DataKey)))
                        row.Delete()
                    ElseIf ddlFormaPagamento.SelectedValue.Equals("3") Or ddlFormaPagamento.SelectedValue.Equals("8") Then
                        'Gera desconto em cheque / op
                        Me.GeraDescontoChequeOP(dsSelecaoValorAcordoDuplicataNaoRelacionada.tbSelecaoValorAcordoDuplicataNaoRelacionada.FindByDSINDEX(Convert.ToInt32(row.DataKey)), 0)
                        row.Delete()
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub GeraDescontoBonificacao(ByVal dr As wsAcoesComerciais.DatasetSelecaoValorAcordoDuplicataNaoRelacionada.tbSelecaoValorAcordoDuplicataNaoRelacionadaRow)
        If Not rbBonificacao.Checked Then
            Controller.GerarLinhaDescontoBonificacao(dr.NUMCTTFRN, dr.NUMCSLCTTFRN, dr.TIPPODCTTFRN, dr.NUMREFPOD, dr.TIPEDEABGMIX, dr.CODEDEABGMIX, dr.DATREFAPU, dr.VLRRCBEFTFXA, Convert.ToInt32(ddlFormaPagamento.SelectedValue), dr.NUMSEQRLCCTTPMS)
        End If
    End Sub

    Private Sub GeraDescontoChequeOP(ByVal dr As wsAcoesComerciais.DatasetSelecaoValorAcordoDuplicataNaoRelacionada.tbSelecaoValorAcordoDuplicataNaoRelacionadaRow, ByVal CodPms As Integer)
        Try
            If dr.NUMCSLCTTFRN.Equals(9999) Then
                If dr.TIPDSNDSCBNF.Equals(56) And dr.TIPDSCPGTFVC.Equals(14) Then
                    For Each drVPORFA As wsAcoesComerciais.DatasetObterValorPromessaOrigemTrocaFormaPagamentoAcordo.tbObterValorPromessaOrigemTrocaFormaPagamentoAcordoRow In _
                                Controller.ObterValorPromessaOrigemTrocaFormaPagamentoAcordo(CodPms, dr.DATREFAPU).tbObterValorPromessaOrigemTrocaFormaPagamentoAcordo.Rows
                        Me.Gera_Lancamentos(dr, drVPORFA.VlrNgcPms, drVPORFA.TipDsnDscBnf, Date.Now.Date, Date.Now.Date, 0)
                    Next
                Else
                    Me.Gera_Lancamentos(dr, Me.CalculaValorResidual(dr), dr.TIPDSNDSCBNF, Date.Now, Date.Now, 0)
                End If
            Else
                Dim dtDVP As DataTable = Controller.ObterDestinoVerbaPrometida(dr.NUMCTTFRN, dr.NUMCSLCTTFRN)
                Dim dtDPR As DataTable = Controller.ObterDataPrevisaoRecebimento(dr.NUMCTTFRN, dr.NUMCSLCTTFRN, dr.TIPPODCTTFRN, dr.NUMREFPOD)
                Dim DatPrvRcbPms As Date
                If dtDVP.Rows.Count = 0 Then Exit Sub
                If dtDPR.Rows.Count = 0 Then
                    DatPrvRcbPms = dr.DATREFAPU.AddDays(14)
                Else
                    DatPrvRcbPms = Convert.ToDateTime(dtDPR.Rows(0).Item("DatFimPod")).Date().AddDays(Convert.ToInt32(dtDPR.Rows(0).Item("NumDiaVncAcoCmc")) - 1)
                End If

                Me.Gera_Lancamentos(dr, Me.CalculaValorResidual(dr), Convert.ToInt32(dtDVP.Rows(0).Item("TipDsnDscBnfFrn")), DatPrvRcbPms, Date.Today, 0)
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function Gera_Lancamentos(ByVal dr As wsAcoesComerciais.DatasetSelecaoValorAcordoDuplicataNaoRelacionada.tbSelecaoValorAcordoDuplicataNaoRelacionadaRow, ByVal Valor As Decimal, ByVal TipDsn As Integer, ByVal DatPrv As Date, ByVal DataNgc As Date, ByVal CodPms As Integer) As Boolean
        Try

            Dim Operacao As Integer
            If CodPms.Equals(0) Then
                CodPms = Controller.ObterProximoCodigoAcordoComercial(1, 1)
                Operacao = 1

            Else
                Operacao = 2
            End If

            'Retira a hora das datas
            DatPrv = DatPrv.Date
            DataNgc = DataNgc.Date


            ' gera_Cadastro_Promessa
            Me.GerarManutencaoMovimentoAcordoComercial(Operacao, 1, 1, CodPms, DataNgc, 0, _
                        Nothing, dr.CODFRN, Convert.ToString(IIf(WSCAcoesComerciais.dsUsuarioCompra.T0113471.Item(0).NOMACSUSRSIS Is String.Empty, "SISTEMA", WSCAcoesComerciais.dsUsuarioCompra.T0113471.Item(0).NOMACSUSRSIS)), _
                        String.Empty, String.Empty, Nothing, String.Empty)

            ' gera_Parcela_Promessa

            Controller.GerarManutencaoRelacaoAcordoComercialParcela(Operacao, 1, 1, CodPms, DataNgc, DatPrv, Convert.ToInt32(ddlFormaPagamento.SelectedValue), TipDsn, Valor.ToString(), Valor.ToString(), String.Empty)

            With dr
                Dim NUMCTTFRN As Integer
                Dim NUMCSLCTTFRN As Integer
                Dim TIPPODCTTFRN As Integer
                Dim NUMREFPOD As Integer
                Dim TIPEDEABGMIX As Integer
                Dim CODEDEABGMIX As Decimal
                Dim DATREFAPU As Date
                Dim NUMSEQRLCCTTPMS As Integer
                Dim CODFRN As Integer
                Dim NUMNOTFSCFRNCTB As Integer
                Dim TIPDSCPGTFVC As Integer

                NUMCTTFRN = .NUMCTTFRN
                NUMCSLCTTFRN = .NUMCSLCTTFRN
                TIPPODCTTFRN = .TIPPODCTTFRN
                NUMREFPOD = .NUMREFPOD
                TIPEDEABGMIX = .TIPEDEABGMIX
                CODEDEABGMIX = .CODEDEABGMIX
                DATREFAPU = .DATREFAPU
                NUMSEQRLCCTTPMS = .NUMSEQRLCCTTPMS
                CODFRN = .CODFRN
                If Not .IsNUMNOTFSCFRNCTBNull Then
                    NUMNOTFSCFRNCTB = .NUMNOTFSCFRNCTB
                End If
                If Not .IsTIPDSCPGTFVCNull Then
                    TIPDSCPGTFVC = .TIPDSCPGTFVC
                End If

                Controller.AtualizaSituacaoNegociacao(NUMCTTFRN, NUMCSLCTTFRN, TIPPODCTTFRN, NUMREFPOD, TIPEDEABGMIX, _
                        CODEDEABGMIX, DATREFAPU, NUMSEQRLCCTTPMS, Valor, CodPms, DataNgc, Valor, _
                        "I", Convert.ToString(IIf(WSCAcoesComerciais.dsUsuarioCompra.T0113471.Item(0).NOMACSUSRSIS Is String.Empty, "SISTEMA", WSCAcoesComerciais.dsUsuarioCompra.T0113471.Item(0).NOMACSUSRSIS)), _
                        1, 1, Convert.ToInt32(ddlFormaPagamento.SelectedValue), TipDsn, CODFRN, 0, _
                        NUMNOTFSCFRNCTB, String.Empty, 0, TIPDSCPGTFVC, DatPrv)
            End With
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Public Sub GerarManutencaoMovimentoAcordoComercial(ByVal vTipOpe As Integer, _
                                            ByVal vCodEmp As Integer, _
                                            ByVal vCodFilEmp As Integer, _
                                            ByVal vCodPms As Integer, _
                                            ByVal vDatNgcPms As Date, _
                                            ByVal vCodSitPms As Integer, _
                                            ByVal vNumPedCmp As Integer, _
                                            ByVal vCodFrn As Integer, _
                                            ByVal vNomAcsUsrSis As String, _
                                            ByVal vDesMsgUsr As String, _
                                            ByVal vNomCtoFrn As String, _
                                            ByVal vNumTlfCtoFrn As Integer, _
                                            ByVal vDesCgrCtofrn As String)


        Try
            Me.DatasetAcordo.Clear()
            Me.DatasetAcordo.EnforceConstraints = False
            Dim linha As wsAcoesComerciais.DatasetAcordo.T0118058Row
            If vTipOpe = 1 Then
                'insert
                linha = Me.DatasetAcordo.T0118058.NewT0118058Row
                linha.CODEMP = vCodEmp
                linha.CODFILEMP = vCodFilEmp
                linha.CODPMS = vCodPms
                linha.DATNGCPMS = vDatNgcPms.Date
                linha.CODSITPMS = vCodSitPms

                If vNumPedCmp = 0 Then
                    linha.SetNUMPEDCMPNull()
                Else
                    linha.NUMPEDCMP = vNumPedCmp
                End If

                linha.CODFRN = vCodFrn
                linha.NOMACSUSRSIS = vNomAcsUsrSis
                linha.DESMSGUSR = vDesMsgUsr
                linha.NOMCTOFRN = vNomCtoFrn
                linha.NUMTLFCTOFRN = vNumTlfCtoFrn.ToString
                linha.DESCGRCTOFRN = vDesCgrCtofrn
                Me.DatasetAcordo.T0118058.AddT0118058Row(linha)
            Else
                'update
                Me.DatasetAcordo.Merge(Controller.ObterAcordo(vCodEmp, vCodFilEmp, vCodPms, vDatNgcPms), False, MissingSchemaAction.Ignore)
                If DatasetAcordo.T0118058.Rows.Count > 0 Then
                    linha.CODSITPMS = vCodSitPms

                    If vNumPedCmp = 0 Then
                        linha.SetNUMPEDCMPNull()
                    Else
                        linha.NUMPEDCMP = vNumPedCmp
                    End If

                    linha.CODFRN = vCodFrn
                    linha.NOMACSUSRSIS = vNomAcsUsrSis
                    linha.DESMSGUSR = vDesMsgUsr
                    linha.NOMCTOFRN = vNomCtoFrn
                    linha.NUMTLFCTOFRN = vNumTlfCtoFrn.ToString
                    linha.DESCGRCTOFRN = vDesCgrCtofrn
                Else
                    Util.AdicionaJsAlert(Me, "Não foi possível atualizar este acordo!")
                End If

            End If
            Controller.AtualizarAcordo(Me.DatasetAcordo)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub
    Private Function VerificarDuplicatasSelecionas(Optional ByRef vSel As Decimal = 0) As Boolean
        VerificarDuplicatasSelecionas = False
        For Each row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In grdDuplicatas.Rows
            If Convert.ToBoolean(row.Cells(0).Value) Then
                VerificarDuplicatasSelecionas = True
                vSel += Convert.ToDecimal(row.Cells(8).Value)
            End If
        Next
    End Function

    Private Sub MostraDuplicatasDisponiveis(ByVal dsIContratos As Integer, Optional ByVal flagMostarMensagem As Boolean = True)
        If Not Me.VerificarDuplicatasSelecionas() Then
            'Se duplicata mostra as duplicatas disponíveis
            Me.MostrarControlesDuplicatas(True)
            txtFornecedor.Text = dsSelecaoValorAcordoDuplicataNaoRelacionada.tbSelecaoValorAcordoDuplicataNaoRelacionada.FindByDSINDEX(dsIContratos).NOMFRN
            Me.CarregaDuplicatas(dsSelecaoValorAcordoDuplicataNaoRelacionada.tbSelecaoValorAcordoDuplicataNaoRelacionada.FindByDSINDEX(dsIContratos).CODFRN)
            If flagMostarMensagem Then
                Util.AdicionaJsAlert(Me.Page, "Atenção para o tipo Duplicata, você deverá selecionar as duplicatas na Lista " + vbNewLine + " e clicar novamente em Salvar!")
            End If
        Else
            Me.RelacionarDuplicatasSelecionadas(dsIContratos)
            grdDuplicatas.Rows.Clear()
            Me.MostrarControlesDuplicatas(False)
            Me.CarregaGridContratos()
        End If
    End Sub

    Private Sub RelacionarDuplicatasSelecionadas(ByVal dsIContratos As Integer)
        Dim vlrDupsSelecionadas As Decimal = 0
        Dim ValorUtz As Decimal = Me.CalculaValorResidual(dsSelecaoValorAcordoDuplicataNaoRelacionada.tbSelecaoValorAcordoDuplicataNaoRelacionada.FindByDSINDEX(dsIContratos))

        Me.VerificarDuplicatasSelecionas(vlrDupsSelecionadas)

        If dsSelecaoValorAcordoDuplicataNaoRelacionada.tbSelecaoValorAcordoDuplicataNaoRelacionada.FindByDSINDEX(dsIContratos).TIPDSCPGTFVC.Equals(11) _
                    And vlrDupsSelecionadas < ValorUtz Then
            Util.AdicionaJsAlert(Me.Page, "Não existem duplicatas suficientes para implantação do desconto. " & vbCrLf & _
                                   "Valor duplicata: " & vlrDupsSelecionadas & vbCrLf & _
                                   "Valor desconto: " & ValorUtz)
        Else
            Me.EfetivarRelacionarDuplicatasSelecionadas(dsIContratos)
        End If
    End Sub

    Private Sub EfetivarRelacionarDuplicatasSelecionadas(ByVal dsIContratos As Integer)
        For i As Integer = 0 To grdDuplicatas.Rows.Count - 1
            Dim row As Infragistics.WebUI.UltraWebGrid.UltraGridRow = grdDuplicatas.Rows.Item(i)
            If Convert.ToBoolean(row.Cells(0).Value) Then
                With dsSelecaoValorAcordoDuplicataNaoRelacionada.tbSelecaoValorAcordoDuplicataNaoRelacionada.FindByDSINDEX(dsIContratos)
                    Controller.AtualizarValorUtilizado(.NUMCTTFRN, .NUMCSLCTTFRN, .TIPPODCTTFRN, .NUMREFPOD, _
                                            .TIPEDEABGMIX, .CODEDEABGMIX, .DATREFAPU, CInt(Session("NumeroSeq")), _
                                            .CODFRN, Convert.ToInt32(row.GetCellValue(grdDuplicatas.Columns.FromKey("CODEMPFRN"))), _
                                             Convert.ToInt32(row.GetCellValue(grdDuplicatas.Columns.FromKey("NUMNOTFSCFRNCTB"))), _
                                             Convert.ToString(row.GetCellValue(grdDuplicatas.Columns.FromKey("CODSEQPCLNOTFSC"))), _
                                             Convert.ToInt32(row.GetCellValue(grdDuplicatas.Columns.FromKey("NUMSEQTITPGT"))), _
                                             Convert.ToInt32(row.GetCellValue(grdDuplicatas.Columns.FromKey("CODEMP"))), _
                                             Convert.ToInt32(row.GetCellValue(grdDuplicatas.Columns.FromKey("CODFILEMP"))), _
                                             Convert.ToDecimal(IIf(Me.CalculaValorResidual(dsSelecaoValorAcordoDuplicataNaoRelacionada.tbSelecaoValorAcordoDuplicataNaoRelacionada.FindByDSINDEX(dsIContratos)) > Convert.ToDecimal(row.GetCellValue(grdDuplicatas.Columns.FromKey("VLRDSP"))), Convert.ToDecimal(row.GetCellValue(grdDuplicatas.Columns.FromKey("VLRDSP"))), Me.CalculaValorResidual(dsSelecaoValorAcordoDuplicataNaoRelacionada.tbSelecaoValorAcordoDuplicataNaoRelacionada.FindByDSINDEX(dsIContratos)))), _
                                             "D", .TIPDSCPGTFVC, 0, 0, WSCAcoesComerciais.dsUsuarioCompra.T0113471.Item(0).NOMACSUSRSIS)
                End With
            End If
        Next
    End Sub

#End Region

#End Region

#Region " Relatório "

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

            ImprimirAlteraFormaPagamento()
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

            ImprimirAlteraFormaPagamento()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ImprimirAlteraFormaPagamento()
        'Declara os parametros
        Dim opcao As Integer
        Dim codFrn As Integer

        'Definir os parametros
        opcao = 0
        codFrn = 0

        If ddlDesconto.SelectedIndex = 0 Then
            opcao = 1
            codFrn = 0
        Else
            If rbBonificacao.Checked Then
                opcao = 3
                codFrn = Integer.Parse(ucFornecedor.CodFornecedor.ToString)
            Else
                opcao = 2
                codFrn = Integer.Parse(ucFornecedor.CodFornecedor.ToString)
            End If
        End If

        ' Obter dados do relatório e guardar na seção
        WSCAcoesComerciais.dsRelatorioAcordoFornecimento = Controller.ObterRelatorioAcordoFornecimento_074(opcao, codFrn)
        ' Guarda o nome do relatório na seção

        WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "rpclj070.rpt"
        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub
#End Region

End Class