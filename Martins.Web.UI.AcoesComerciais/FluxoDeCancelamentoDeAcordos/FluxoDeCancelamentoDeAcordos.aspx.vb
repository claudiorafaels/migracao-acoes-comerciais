Public Class FluxoDeCancelamentoDeAcordos
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetAcordoACancelarEmFluxoCancelamentoAcordo1 = New Martins.Web.UI.AcoesComerciais.wsFluxoDeCancelamentoDeAcordos.DatasetAcordoACancelarEmFluxoCancelamentoAcordo
        Me.DatasetFluxoCancelamentoAcordo1 = New Martins.Web.UI.AcoesComerciais.wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo
        Me.DatasetFuncionario1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetFuncionario
        Me.DatasetFluxoAprovacao1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetFluxoAprovacao
        CType(Me.DatasetAcordoACancelarEmFluxoCancelamentoAcordo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetFluxoCancelamentoAcordo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetFuncionario1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetFluxoAprovacao1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetAcordoACancelarEmFluxoCancelamentoAcordo1
        '
        Me.DatasetAcordoACancelarEmFluxoCancelamentoAcordo1.DataSetName = "DatasetAcordoACancelarEmFluxoCancelamentoAcordo"
        Me.DatasetAcordoACancelarEmFluxoCancelamentoAcordo1.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DatasetFluxoCancelamentoAcordo1
        '
        Me.DatasetFluxoCancelamentoAcordo1.DataSetName = "DatasetFluxoCancelamentoAcordo"
        Me.DatasetFluxoCancelamentoAcordo1.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DatasetFuncionario1
        '
        Me.DatasetFuncionario1.DataSetName = "DatasetFuncionario"
        Me.DatasetFuncionario1.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DatasetFluxoAprovacao1
        '
        Me.DatasetFluxoAprovacao1.DataSetName = "DatasetFluxoAprovacao"
        Me.DatasetFluxoAprovacao1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetAcordoACancelarEmFluxoCancelamentoAcordo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetFluxoCancelamentoAcordo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetFuncionario1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetFluxoAprovacao1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnAprovar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnReprovar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnSair As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnClonar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lkbProcessaCloseModalSelecionarValores As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnEnviar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagarFluxoTransferencia As System.Web.UI.WebControls.LinkButton
    Protected WithEvents TDSelecionar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TDApgar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TDApagarSelecao As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TDSalvar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TDEnviar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TDAprovar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TDReprovar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TDClonar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TDSair As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents lkbRecarregarPagina As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkFecharTela As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetAcordoACancelarEmFluxoCancelamentoAcordo1 As Martins.Web.UI.AcoesComerciais.wsFluxoDeCancelamentoDeAcordos.DatasetAcordoACancelarEmFluxoCancelamentoAcordo
    Protected WithEvents cmbCODSTAAPV As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNUMPEDCNCACOCMC As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents btnSelecionar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetFluxoCancelamentoAcordo1 As Martins.Web.UI.AcoesComerciais.wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo
    Protected WithEvents txtDATGRCCNCACOCMC As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtDATRPVCNCACOCMC As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtDATAPVCNCACOCMC As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents DatasetFuncionario1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetFuncionario
    Protected WithEvents txtDESOBSCNCACOCMC As System.Web.UI.WebControls.TextBox
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents txtNOMUSRSIS As System.Web.UI.WebControls.TextBox
    Protected WithEvents grdFluxos As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents lblErroFluxo As System.Web.UI.WebControls.Label
    Protected WithEvents DatasetFluxoAprovacao1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetFluxoAprovacao
    Protected WithEvents lkbNenhum As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lkbTodas As System.Web.UI.WebControls.LinkButton
    Protected WithEvents grdAcordo As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents WebNumericEdit1 As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents ValorCancelar As Infragistics.WebUI.WebDataInput.WebNumericEdit

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
            If (Not IsPostBack) Then
                Me.IniciarPagina()
            Else
                Me.RecuperaEstado()
            End If
            MostrarOuEsconderBotoesDeAcordoComStatusDaTransferencia()
            HabilitaOuDesabilitaBotoesAprovacaoDependendoDoUsuarioEstarNoFluxo()
            carregarJavaScript()
            Controller.SetCurrentCulture()
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

    Private Sub lkbProcessaCloseModalSelecionarValores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkbProcessaCloseModalSelecionarValores.Click
        Try
            If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
                Exit Sub
            End If
            atualizarGridAcordo()
            atualizarGridFluxos()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnSelecionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelecionar.Click
        Try
            If ucFornecedor.CodFornecedor = 0 Then
                Util.AdicionaJsAlert(Me.Page, "Escolha o fornecedor!", True)
                Exit Sub
            End If
            WSCAcoesComerciais.CODFRN = ucFornecedor.CodFornecedor
            If txtNUMPEDCNCACOCMC.Text = String.Empty Then
                txtNUMPEDCNCACOCMC.Value = Controller.ObterNovaChaveFluxoCancelamento
                WSCAcoesComerciais.NUMPEDCNCACOCMC = txtNUMPEDCNCACOCMC.ValueDecimal
                AtualizarDataset()
                AtualizarFluxoCancelamentoAcordo()
            Else
                AtualizarDataset()
            End If
            SalvaEstado()
            carregarJanelaSelecaoAcordos()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub lkbTodas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkbTodas.Click
        Try
            If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
                Exit Sub
            End If
            Me.MarcarTodas()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub lkbNenhum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkbNenhum.Click
        Try
            If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
                Exit Sub
            End If
            Me.DesmarcarTodas()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
        Try
            If Not VerificaSelecao() Then
                Util.AdicionaJsAlert(Me.Page, "Selecione uma linha!")
                Exit Sub
            End If
            ExcluirRegistrosSelecionados()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        AtualizarDatasetComDadosDoGrid()
        If ValidarPersistencia() Then

            If Not AtualizarDataset() Then
                Exit Sub
            End If

            AtualizarFluxoCancelamentoAcordo()
            Response.Redirect("FluxoDeCancelamentoDeAcordos.aspx?NUMPEDCNCACOCMC=" & Me.txtNUMPEDCNCACOCMC.Text & "&CODFRN=" & WSCAcoesComerciais.CODFRN.ToString)
        End If
    End Sub

    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        Try
            If Not AtualizarDataset() Then
                Exit Sub
            End If
            If ValidarPersistencia() Then
                Dim CodigosAcordosDuplicados As String = String.Empty

                Me.DatasetAcordoACancelarEmFluxoCancelamentoAcordo1 = WSCAcoesComerciais.dsAcordoACancelarEmFluxoCancelamentoAcordo

                If CType(cmbCODSTAAPV.SelectedValue, Decimal) = 3 Then
                    If Me.DatasetFluxoCancelamentoAcordo1.T0154021ComDuplicidadeEmOutroFluxo.Rows.Count > 0 Then
                        For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdAcordo.Rows
                            Dim CODPMS As Decimal = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("CODPMS")), Decimal)
                            Dim T0154021ComDuplicidadeEmOutroFluxoRow As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo.T0154021ComDuplicidadeEmOutroFluxoRow

                            T0154021ComDuplicidadeEmOutroFluxoRow = Me.DatasetFluxoCancelamentoAcordo1.T0154021ComDuplicidadeEmOutroFluxo.FindByCODPMS(CODPMS)

                            If Not T0154021ComDuplicidadeEmOutroFluxoRow Is Nothing Then
                                'linha.Cells(11).Value = "*"
                                'lblErroFluxo.Visible = True
                                If CodigosAcordosDuplicados = String.Empty Then
                                    CodigosAcordosDuplicados &= CType(CODPMS, String)
                                Else
                                    CodigosAcordosDuplicados &= ", " & CType(CODPMS, String)
                                End If
                            End If
                        Next
                    End If
                End If

                If Not CodigosAcordosDuplicados = String.Empty Then
                    Util.AdicionaJsAlert(Me.Page, "Acordo(s) " & CodigosAcordosDuplicados & " já existe(m) em outro(s) fluxo(s) de cancelamento!", True)
                    Exit Sub
                End If

                AtualizarFluxoCancelamentoAcordo()
                Controller.IniciarFluxoCancelamentoAcordo(txtNUMPEDCNCACOCMC.ValueDecimal, ucFornecedor.CodFornecedor)
                Response.Redirect("FluxoDeCancelamentoDeAcordosListar.aspx")
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
            'AtualizaTela()
        End Try
    End Sub

    Private Sub btnApagarFluxoTransferencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagarFluxoTransferencia.Click
        Try
            ExcluirFluxo()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Try
            Response.Redirect("FluxoDeCancelamentoDeAcordosListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnAprovar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAprovar.Click
        Try
            WSCAcoesComerciais.NUMPEDCNCACOCMC = Me.txtNUMPEDCNCACOCMC.ValueDecimal
            carregarJanelaObservacaoAprovacaoFluxo()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnReprovar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprovar.Click
        Try
            WSCAcoesComerciais.NUMPEDCNCACOCMC = Me.txtNUMPEDCNCACOCMC.ValueDecimal
            carregarJanelaObservacaoReprovacaoFluxo()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub lnkFecharTela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkFecharTela.Click
        Try
            Response.Redirect("FluxoDeCancelamentoDeAcordosListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub
    Private Sub btnClonar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClonar.Click
        Try
            Dim NUMPEDCNCACOCMC As Decimal
            NUMPEDCNCACOCMC = Controller.ClonarFluxoCancelamentoAcordoFornecedor(txtNUMPEDCNCACOCMC.ValueDecimal, ucFornecedor.CodFornecedor)
            Response.Redirect("FluxoDeCancelamentoDeAcordos.aspx?NUMPEDCNCACOCMC=" & NUMPEDCNCACOCMC & "&CODFRN=" & WSCAcoesComerciais.CODFRN.ToString)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#Region "Metodos de Carga"

    Private Sub IniciarPagina()
        Try
            AtualizaTela()
            Util.AdicionaJsFocus(Me.Page, btnSelecionar)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub carregarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        btnApagarFluxoTransferencia.Attributes.Add("OnClick", "return confirm('Você confirma a exclusão desse fluxo de transferencia?');")
        btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento();")
        btnEnviar.Attributes.Add("OnClick", "javascript:mostraAndamento();")
        btnSelecionar.Attributes.Add("OnClick", "javascript:mostraAndamento();")
        btnApagar.Attributes.Add("OnClick", "javascript:mostraAndamento();")
        If btnAprovar.Enabled Then
            btnAprovar.Attributes.Add("OnClick", "javascript:mostraAndamento();")
        End If
        If btnReprovar.Enabled Then
            btnReprovar.Attributes.Add("OnClick", "javascript:mostraAndamento();")
        End If
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR")
    End Sub

    Private Sub carregarJanelaSelecaoAcordos()
        Page.RegisterStartupScript("Selecao", "<script>CarregarJanelaSelecionarAcordos();</script>")
    End Sub

    Private Sub atualizarGridAcordo()
        Try
            lblErroFluxo.Visible = False
            Dim NUMPEDCNCACOCMC As Decimal = WSCAcoesComerciais.NUMPEDCNCACOCMC
            Me.DatasetAcordoACancelarEmFluxoCancelamentoAcordo1 = Controller.ObterAcordosParaCancelamentoPorNUMPEDCNCACOCMC(NUMPEDCNCACOCMC)


            'TODO: TESTE DEPOIS DE TESTADO RETIRAR CODIGO, INCLUI 13 NA FORMA DE PAGAMENTO E "I" EM IMPLANTAÇÃO
            'Dim T0118066PesquisaRow As wsFluxoDeCancelamentoDeAcordos.DatasetAcordoACancelarEmFluxoCancelamentoAcordo.T0118066PesquisaRow = Me.DatasetAcordoACancelarEmFluxoCancelamentoAcordo1.T0118066Pesquisa(0)
            'T0118066PesquisaRow.TIPFRMDSCBNF = 13
            'T0118066PesquisaRow.FLGSITNGCDUP = "I"
            '----------------------------------------------------------------------------------------------------

            WSCAcoesComerciais.dsAcordoACancelarEmFluxoCancelamentoAcordo = Me.DatasetAcordoACancelarEmFluxoCancelamentoAcordo1

            grdAcordo.DataBind()

            'If CType(cmbCODSTAAPV.SelectedValue, Decimal) = 3 Then
            '    If Me.DatasetFluxoCancelamentoAcordo1.T0154021ComDuplicidadeEmOutroFluxo.Rows.Count > 0 Then
            '        For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdAcordo.Rows
            '            Dim CODPMS As Decimal = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("CODPMS")), Decimal)
            '            Dim T0154021ComDuplicidadeEmOutroFluxoRow As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo.T0154021ComDuplicidadeEmOutroFluxoRow

            '            T0154021ComDuplicidadeEmOutroFluxoRow = Me.DatasetFluxoCancelamentoAcordo1.T0154021ComDuplicidadeEmOutroFluxo.FindByCODPMS(CODPMS)

            '            If Not T0154021ComDuplicidadeEmOutroFluxoRow Is Nothing Then
            '                linha.Cells(11).Value = "*"
            '                lblErroFluxo.Visible = True
            '            End If
            '        Next
            '    End If
            'End If

            If grdAcordo.Rows.Count > 0 Then
                ucFornecedor.Enabled = False
            Else
                ucFornecedor.Enabled = True
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub MarcarTodas()
        For Each row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdAcordo.Rows
            row.Cells.Item(0).Value = True
        Next
    End Sub

    Private Sub DesmarcarTodas()
        For Each row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdAcordo.Rows
            row.Cells.Item(0).Value = False
        Next
    End Sub

    Private Sub ExcluirRegistrosSelecionados()

        Me.DatasetFluxoCancelamentoAcordo1 = Controller.ObterFluxoCancelamentoAcordoPorChave(WSCAcoesComerciais.CODFRN, WSCAcoesComerciais.NUMPEDCNCACOCMC)

        For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdAcordo.Rows
            If CType(linha.Cells.Item(0).Value, Boolean) = True Then
                Dim NUMPEDCNCACOCMC As Decimal = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("NUMPEDCNCACOCMC")), Decimal)
                Dim CODPMS As Decimal = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("CODPMS")), Decimal)
                Dim CODEMP As Decimal = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("CODEMP")), Decimal)
                Dim CODFILEMP As Decimal = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("CODFILEMP")), Decimal)
                Dim DATNGCPMS As Date = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("DATNGCPMS")), Date)
                Dim DATPRVRCBPMS As Date = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("DATPRVRCBPMS")), Date)
                Dim TIPFRMDSCBNF As Decimal = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("TIPFRMDSCBNF")), Decimal)
                Dim TIPDSNDSCBNF As Decimal = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("TIPDSNDSCBNF")), Decimal)
                Dim T0154021Row As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo.T0154021Row

                T0154021Row = Me.DatasetFluxoCancelamentoAcordo1.T0154021.FindByNUMPEDCNCACOCMCCODPMSCODEMPCODFILEMPDATNGCPMSDATPRVRCBPMSTIPFRMDSCBNFTIPDSNDSCBNF(NUMPEDCNCACOCMC, _
                                                                                                                                                                  CODPMS, _
                                                                                                                                                                  CODEMP, _
                                                                                                                                                                  CODFILEMP, _
                                                                                                                                                                  DATNGCPMS, _
                                                                                                                                                                  DATPRVRCBPMS, _
                                                                                                                                                                  TIPFRMDSCBNF, _
                                                                                                                                                                  TIPDSNDSCBNF)
                If Not T0154021Row Is Nothing Then
                    T0154021Row.Delete()
                End If

            End If
        Next

        If Me.DatasetFluxoCancelamentoAcordo1.HasChanges Then
            Controller.AtualizarFluxoCancelamentoAcordo(Me.DatasetFluxoCancelamentoAcordo1)
            Me.DatasetFluxoCancelamentoAcordo1 = Controller.ObterFluxoCancelamentoAcordoPorChave(WSCAcoesComerciais.CODFRN, WSCAcoesComerciais.NUMPEDCNCACOCMC)
        End If
        atualizarGridAcordo()
    End Sub

    Private Function atualizarGridFluxos() As Boolean
        Try
            If Me.DatasetFluxoCancelamentoAcordo1.queryFluxos.Rows.Count > 0 Then
                grdFluxos.DataBind()
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Sub carregarJanelaObservacaoAprovacaoFluxo()
        VerificaUsuarioControladorESeFluxoFoiImplantadoContasAPagar()
        Page.RegisterStartupScript("Aprovar", "<script>CarregarJanelaObservacaoAprovacaoFluxo();</script>")
    End Sub

    Public Sub carregarJanelaObservacaoReprovacaoFluxo()
        WSCAcoesComerciais.FLGSITNGCDUP = False
        Page.RegisterStartupScript("Reprovar", "<script>CarregarJanelaObservacaoReprovacaoFluxo();</script>")
    End Sub

    Private Function AtualizarDatasetComDadosDoGrid() As Boolean
        'Verifica se existe registro na tabela de cadastro
        If Me.DatasetFluxoCancelamentoAcordo1.T0154038.Rows.Count = 0 Then
            Util.AdicionaJsAlert(Me.Page, "Não existe registro na tabela de fluxo de cancelamento, tente novamente se o problema persistir informe ao analista responsável")
            Return False
        End If

        'Obtema linha da tabela de cadastro
        Dim T0154038Row As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo.T0154038Row
        T0154038Row = Me.DatasetFluxoCancelamentoAcordo1.T0154038(0)

        If T0154038Row.RowState = DataRowState.Added Then
            T0154038Row.NUMPEDCNCACOCMC = WSCAcoesComerciais.NUMPEDCNCACOCMC
        End If

        'Atualiza o dataset
        For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdAcordo.Rows
            If CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("VLRSLDPMSFRN")), Decimal) <> 0 Then
                'A linha do grid foi selecionada
                If Not AtualizarDataset(T0154038Row, linha) Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Function AtualizarDataset(ByVal T0154038Row As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo.T0154038Row, _
                                      ByVal linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow) As Boolean

        'Declaração das variaveis para transferencia dos dados e Transfere os valores da linha selecionada para as variaveis locais
        Dim NUMPEDCNCACOCMC As Decimal = WSCAcoesComerciais.NUMPEDCNCACOCMC
        Dim CODPMS As Decimal = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("CODPMS")), Decimal)
        Dim CODEMP As Decimal = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("CODEMP")), Decimal)
        Dim CODFILEMP As Decimal = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("CODFILEMP")), Decimal)
        Dim DATNGCPMS As Date = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("DATNGCPMS")), Date)
        Dim DATPRVRCBPMS As Date = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("DATPRVRCBPMS")), Date)
        Dim TIPFRMDSCBNF As Decimal = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("TIPFRMDSCBNF")), Decimal)
        Dim TIPDSNDSCBNF As Decimal = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("TIPDSNDSCBNF")), Decimal)

        'Caso a linha da capa CADTRNVBAFRN ainda não tenha sido gravada no banco de dados
        'reconsulta a chave, isso é necessário para resolver problema de concorrencia na
        'qual dois usuário podem ter aberto uma transferencia ao mesmo tempo e tenha obtido
        'o mesmo número de fluxo
        If T0154038Row.RowState = DataRowState.Added Then
            T0154038Row.NUMPEDCNCACOCMC = WSCAcoesComerciais.NUMPEDCNCACOCMC
        End If

        'Obtem a linha que será atualizada, ou cria uma nova caso ela não exista
        Dim T0154021Row As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo.T0154021Row
        T0154021Row = Me.DatasetFluxoCancelamentoAcordo1.T0154021.FindByNUMPEDCNCACOCMCCODPMSCODEMPCODFILEMPDATNGCPMSDATPRVRCBPMSTIPFRMDSCBNFTIPDSNDSCBNF(NUMPEDCNCACOCMC, _
                                                                                                                                                          CODPMS, _
                                                                                                                                                          CODEMP, _
                                                                                                                                                          CODFILEMP, _
                                                                                                                                                          DATNGCPMS, _
                                                                                                                                                          DATPRVRCBPMS, _
                                                                                                                                                          TIPFRMDSCBNF, _
                                                                                                                                                          TIPDSNDSCBNF)
        If T0154021Row Is Nothing Then
            T0154021Row = Me.DatasetFluxoCancelamentoAcordo1.T0154021.NewT0154021Row
        End If

        'Transfere valores das variaveis para a linha da tabela
        With T0154021Row
            .NUMPEDCNCACOCMC = WSCAcoesComerciais.NUMPEDCNCACOCMC
            .VLRSLDPMSFRN = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("VLRSLDPMSFRN")), Decimal)
            .CODPMS = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("CODPMS")), Decimal)
            .CODEMP = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("CODEMP")), Decimal)
            .CODFILEMP = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("CODFILEMP")), Decimal)
            .DATNGCPMS = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("DATNGCPMS")), Date)
            .DATPRVRCBPMS = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("DATPRVRCBPMS")), Date)
            .TIPFRMDSCBNF = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("TIPFRMDSCBNF")), Decimal)
            .TIPDSNDSCBNF = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("TIPDSNDSCBNF")), Decimal)
            .VLRNGCPMS = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("VLRNGCPMS")), Decimal)
            .VLRPGOPMS = CType(linha.GetCellValue(Me.grdAcordo.Columns.FromKey("VLRPGOPMS")), Decimal)
        End With

        'Insere a linha caso ela seja nova
        If T0154021Row.RowState = DataRowState.Detached Then
            Me.DatasetFluxoCancelamentoAcordo1.T0154021.AddT0154021Row(T0154021Row)
        End If
        Return True
    End Function
#End Region

#Region "Metodos de controle"

    Private Sub RecuperaEstado()
        Me.DatasetFluxoCancelamentoAcordo1 = WSCAcoesComerciais.dsFluxoCancelamento
        If Me.DatasetFluxoCancelamentoAcordo1 Is Nothing Then
            Response.Redirect("FluxoDeCancelamentoDeAcordosListar.aspx")
        End If
    End Sub

    Private Sub SalvaEstado()
        WSCAcoesComerciais.dsFluxoCancelamento = Me.DatasetFluxoCancelamentoAcordo1
    End Sub

    Private Sub AtualizaTela()
        If Not Page.Request.QueryString("NUMPEDCNCACOCMC") Is Nothing Then
            txtNUMPEDCNCACOCMC.Value = CType(Page.Request.QueryString("NUMPEDCNCACOCMC"), Decimal)
            Dim CODFRN As Decimal = CType(Page.Request.QueryString("CODFRN"), Decimal)

            WSCAcoesComerciais.CODFRN = CODFRN
            WSCAcoesComerciais.NUMPEDCNCACOCMC = CType(Page.Request.QueryString("NUMPEDCNCACOCMC"), Decimal)

            AtualizarTela(txtNUMPEDCNCACOCMC.ValueDecimal)
        Else

            Dim NOMUSRSIS As String = Controller.ObterNomeUsuarioLogadoSistema()

            cmbCODSTAAPV.SelectedValue = "3"
            txtNOMUSRSIS.Text = NOMUSRSIS
            txtDATGRCCNCACOCMC.Text = Date.Now.ToString
        End If
    End Sub

    Private Sub AtualizarTela(ByVal NUMPEDCNCACOCMC As Decimal)
        'Consulta a transferencia
        Me.DatasetFluxoCancelamentoAcordo1 = Controller.ObterFluxoCancelamentoAcordoPorChave(WSCAcoesComerciais.CODFRN, NUMPEDCNCACOCMC)

        If Me.DatasetFluxoCancelamentoAcordo1.T0154038.Rows.Count = 0 Then
            Util.AdicionaJsAlert(Me.Page, "Registro não encontrado!", True)
            Exit Sub
        End If

        'Transfere a linha encontrada para variável
        Dim T0154038Row As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo.T0154038Row
        T0154038Row = Me.DatasetFluxoCancelamentoAcordo1.T0154038(0)

        'Transfere os valores da linha para tela
        With T0154038Row
            txtNOMUSRSIS.Text = .NOMUSRSIS
            cmbCODSTAAPV.SelectedValue = .CODSTAAPV.ToString
            ucFornecedor.SelecionarFornecedor(.CODFRN)

            If Not .IsDATAPVCNCACOCMCNull Then
                txtDATAPVCNCACOCMC.Value = .DATAPVCNCACOCMC
            End If

            If Not .IsDATGRCCNCACOCMCNull Then
                txtDATGRCCNCACOCMC.Text = .DATGRCCNCACOCMC.ToString
            End If

            If Not .IsDATRPVCNCACOCMCNull Then
                txtDATRPVCNCACOCMC.Value = .DATRPVCNCACOCMC
            End If

            If Not .IsDESOBSCNCACOCMCNull Then
                txtDESOBSCNCACOCMC.Text = .DESOBSCNCACOCMC
            End If

        End With
        atualizarGridAcordo()
        atualizarGridFluxos()
    End Sub

    Private Sub MostrarOuEsconderBotoesDeAcordoComStatusDaTransferencia()
        Try
            Select Case cmbCODSTAAPV.SelectedValue
                Case "0" 'Em Aprovação
                    TDSelecionar.Visible = False
                    TDApgar.Visible = False
                    TDApagarSelecao.Visible = False
                    TDSalvar.Visible = False
                    TDEnviar.Visible = False
                    TDAprovar.Visible = True
                    TDReprovar.Visible = True
                    TDClonar.Visible = False
                    TDSair.Visible = True
                Case "1" 'Aprovado
                    TDSelecionar.Visible = False
                    TDApgar.Visible = False
                    TDApagarSelecao.Visible = False
                    TDSalvar.Visible = False
                    TDEnviar.Visible = False
                    TDAprovar.Visible = False
                    TDReprovar.Visible = False
                    TDClonar.Visible = False
                    TDSair.Visible = True
                Case "2" 'Rejeitada
                    TDSelecionar.Visible = False
                    TDApgar.Visible = False
                    TDApagarSelecao.Visible = False
                    TDSalvar.Visible = False
                    TDEnviar.Visible = False
                    TDAprovar.Visible = False
                    TDReprovar.Visible = False
                    TDClonar.Visible = True
                    TDSair.Visible = True
                Case "3" 'Nova
                    TDSelecionar.Visible = True
                    TDApgar.Visible = True
                    TDApagarSelecao.Visible = True
                    TDSalvar.Visible = True
                    TDEnviar.Visible = True
                    TDAprovar.Visible = False
                    TDReprovar.Visible = False
                    TDClonar.Visible = False
                    TDSair.Visible = True

            End Select
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub HabilitaOuDesabilitaBotoesAprovacaoDependendoDoUsuarioEstarNoFluxo()
        Try
            If TDAprovar.Visible = False And TDReprovar.Visible = False Then
                Exit Sub
            End If

            Dim CODFNC As Decimal
            CODFNC = Controller.ObterFuncionarioLogadoSistema

            If FuncionarioEAprovadorDeFluxo(CODFNC) Then
                btnAprovar.Enabled = True
                btnReprovar.Enabled = True
                If CType(cmbCODSTAAPV.SelectedValue, Decimal) = 0 Then
                    grdAcordo.Enabled = False
                    txtDESOBSCNCACOCMC.Enabled = False
                    ValorCancelar.Enabled = False
                End If
            Else
                btnAprovar.Enabled = False
                btnReprovar.Enabled = False
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function FuncionarioEAprovadorDeFluxo(ByVal CODFNC As Decimal) As Boolean
        Dim dsDatasetFluxoCancelamentoAcordo As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo
        dsDatasetFluxoCancelamentoAcordo = Controller.ObterMinhasAprovavoesEmFluxoDeCancelamentoDeAcordos(txtNUMPEDCNCACOCMC.ValueDecimal, CODFNC)
        If dsDatasetFluxoCancelamentoAcordo.T0154038Pesquisa.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    Private Sub VerificaUsuarioControladorESeFluxoFoiImplantadoContasAPagar()
        WSCAcoesComerciais.FLGSITNGCDUP = False
        Dim CODFNC As Decimal = Controller.ObterFuncionarioLogadoSistema
        Me.DatasetFluxoAprovacao1 = Controller.ObterFluxosAprovacao(CODFNC, 0, Constants.CODSISINF_FLUXO_DE_CANCELAMENTO_DE_ACORDO, String.Empty, String.Empty, txtNUMPEDCNCACOCMC.ValueDecimal, 0, 0, 0, String.Empty)

        If Not Me.DatasetFluxoAprovacao1.T0161591.Rows.Count = 0 Then
            For Each T0161591Row As wsAcoesComerciais.DatasetFluxoAprovacao.T0161591Row In Me.DatasetFluxoAprovacao1.T0161591

                If T0161591Row.NUMSEQNIVAPV >= Constants.NUMSEQNIVAPV_PRIMEIRO_FLUXO_CONTROLADORIA Then
                    If T0161591Row.CODEDEAPV = CODFNC Then
                        Me.DatasetAcordoACancelarEmFluxoCancelamentoAcordo1 = WSCAcoesComerciais.dsAcordoACancelarEmFluxoCancelamentoAcordo
                        If Not Me.DatasetAcordoACancelarEmFluxoCancelamentoAcordo1.T0118066Pesquisa.Rows.Count = 0 Then
                            For Each linha As wsFluxoDeCancelamentoDeAcordos.DatasetAcordoACancelarEmFluxoCancelamentoAcordo.T0118066PesquisaRow In Me.DatasetAcordoACancelarEmFluxoCancelamentoAcordo1.T0118066Pesquisa.Rows
                                If Not linha.IsNull("FLGSITNGCDUP") Then
                                    If linha.TIPFRMDSCBNF = 13 And linha.FLGSITNGCDUP = "I" Then
                                        WSCAcoesComerciais.FLGSITNGCDUP = True
                                        linha.IsVLRDSPPMSNull()
                                    End If
                                End If
                            Next
                        End If
                    End If
                End If
            Next
            'If Me.DatasetFluxoAprovacao1.T0161591(0).CODEDEAPV = CODFNC Then
            '    'Usuario logado é aprovador da Controladoria do fluxo corrente

            '    'Dim NUMPEDCNCACOCMC As Decimal = WSCAcoesComerciais.NUMPEDCNCACOCMC
            '    'Me.DatasetAcordoACancelarEmFluxoCancelamentoAcordo1 = Controller.ObterAcordosParaCancelamentoPorNUMPEDCNCACOCMC(NUMPEDCNCACOCMC)
            '    Me.DatasetAcordoACancelarEmFluxoCancelamentoAcordo1 = WSCAcoesComerciais.dsAcordoACancelarEmFluxoCancelamentoAcordo
            '    If Not Me.DatasetAcordoACancelarEmFluxoCancelamentoAcordo1.T0118066Pesquisa.Rows.Count = 0 Then
            '        For Each linha As wsFluxoDeCancelamentoDeAcordos.DatasetAcordoACancelarEmFluxoCancelamentoAcordo.T0118066PesquisaRow In Me.DatasetAcordoACancelarEmFluxoCancelamentoAcordo1.T0118066Pesquisa.Rows
            '            If Not linha.IsFLGSITNGCDUPNull Then
            '                If linha.TIPFRMDSCBNF = 13 And linha.FLGSITNGCDUP = "I" Then
            '                    WSCAcoesComerciais.FLGSITNGCDUP = True
            '                End If
            '            End If
            '        Next
            '    End If
            'End If
        End If
    End Sub

#End Region

#Region "Metodos de Regra"

    Private Function VerificaSelecao() As Boolean
        Dim numeroLinhas As Integer = 0
        For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In grdAcordo.Rows
            If CType(linha.Cells.Item(0).Value, Boolean) = True Then
                numeroLinhas += 1
            End If
        Next
        If numeroLinhas = 0 Then
            Return False
        End If
        Return True
    End Function

    Private Function ExcluirFluxo() As Boolean
        Try
            Me.DatasetFluxoCancelamentoAcordo1 = Controller.ObterFluxoCancelamentoAcordoPorChave(WSCAcoesComerciais.CODFRN, WSCAcoesComerciais.NUMPEDCNCACOCMC)

            'Apagar as relações
            For Each linha As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo.T0154021Row In Me.DatasetFluxoCancelamentoAcordo1.T0154021
                If linha.NUMPEDCNCACOCMC = txtNUMPEDCNCACOCMC.ValueDecimal Then
                    linha.Delete()
                End If
            Next

            'Apagar o cadastro (capa)
            For Each linha As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo.T0154038Row In Me.DatasetFluxoCancelamentoAcordo1.T0154038
                If LINHA.NUMPEDCNCACOCMC = txtNUMPEDCNCACOCMC.ValueDecimal Then
                    linha.Delete()
                End If
            Next

            Controller.AtualizarFluxoCancelamentoAcordo(Me.DatasetFluxoCancelamentoAcordo1)
            Response.Redirect("FluxoDeCancelamentoDeAcordosListar.aspx")
            Return True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Function ValidarPersistencia() As Boolean

        If ucFornecedor.CodFornecedor = 0 Then
            Util.AdicionaJsAlert(Me.Page, "Escolha o fornecedor!", True)
            Return False
        End If

        If txtDESOBSCNCACOCMC.Text.Trim.Length = 0 Then
            Util.AdicionaJsAlert(Me.Page, "Informe a justificativa")
            Return False
        End If

        For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdAcordo.Rows
            If Not ValidarPersistenciaLinhaDoGrid(linha) Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Function ValidarPersistenciaLinhaDoGrid(ByVal linhaGrid As Infragistics.WebUI.UltraWebGrid.UltraGridRow) As Boolean
        If Not linhaGrid Is Nothing Then
            'Validações
            If CType(linhaGrid.GetCellValue(grdAcordo.Columns.FromKey("VLRSLDPMSFRN")), Decimal) < 0 Then
                Dim NOMFRN As String = ucFornecedor.NomFornecedor
                Dim DESDSNDSCBNF As String = CType(linhaGrid.GetCellValue(grdAcordo.Columns.FromKey("DESDSNDSCBNF")), String)
                Dim CODPMS As String = CType(linhaGrid.GetCellValue(grdAcordo.Columns.FromKey("CODPMS")), String)
                Util.AdicionaJsAlert(Me.Page, "Não é permitido valor negativo. Fornecedor:" & NOMFRN.Trim & ", Número:" & CODPMS.Trim & ", Empenho:" & DESDSNDSCBNF.Trim, True)
                linhaGrid.Activate()
                Return False
            End If
        End If
        Return True

    End Function

#End Region

#Region "Metodos de Persistencia"

    Private Function AtualizarDataset() As Boolean
        'Obtem ou cria a linha
        Dim T0154038Row As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo.T0154038Row

        If Me.DatasetFluxoCancelamentoAcordo1.T0154038.Rows.Count = 0 Then
            T0154038Row = Me.DatasetFluxoCancelamentoAcordo1.T0154038.NewT0154038Row
        Else
            T0154038Row = Me.DatasetFluxoCancelamentoAcordo1.T0154038(0)
        End If

        'Transfere valores da tela para o dataset
        With T0154038Row
            .NUMPEDCNCACOCMC = CType(txtNUMPEDCNCACOCMC.Text, Decimal)
            .CODFRN = ucFornecedor.CodFornecedor
            .CODSTAAPV = CType(cmbCODSTAAPV.SelectedValue, Decimal)
            .NOMUSRSIS = Controller.ObterNomeUsuarioLogadoSistema
            .DATGRCCNCACOCMC = CType(txtDATGRCCNCACOCMC.Text, Date)

            If Not txtDESOBSCNCACOCMC.Text = String.Empty Then
                .DESOBSCNCACOCMC = txtDESOBSCNCACOCMC.Text
            End If

        End With

        'Se for linha nova adiciona
        If T0154038Row.RowState = DataRowState.Detached Then
            Me.DatasetFluxoCancelamentoAcordo1.T0154038.AddT0154038Row(T0154038Row)
        End If

        Return True
    End Function

    Private Sub AtualizarFluxoCancelamentoAcordo()
        'Salva os registros
        If Me.DatasetFluxoCancelamentoAcordo1.HasChanges Then
            Controller.AtualizarFluxoCancelamentoAcordo(Me.DatasetFluxoCancelamentoAcordo1)
            Me.DatasetFluxoCancelamentoAcordo1 = Controller.ObterFluxoCancelamentoAcordoPorChave(ucFornecedor.CodFornecedor, CType(txtNUMPEDCNCACOCMC.Text, Decimal))
        End If
    End Sub

#End Region

End Class