Public Class ucAditamento
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetContrato1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContrato
        Me.DatasetTipoAbrangenciaMix1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoAbrangenciaMix
        CType(Me.DatasetContrato1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetTipoAbrangenciaMix1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetContrato1
        '
        Me.DatasetContrato1.DataSetName = "DatasetContrato"
        Me.DatasetContrato1.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DatasetTipoAbrangenciaMix1
        '
        Me.DatasetTipoAbrangenciaMix1.DataSetName = "DatasetTipoAbrangenciaMix"
        Me.DatasetTipoAbrangenciaMix1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetContrato1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetTipoAbrangenciaMix1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents DatasetContrato1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContrato
    Protected WithEvents DatasetTipoAbrangenciaMix1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoAbrangenciaMix
    Protected WithEvents TRFaixas As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents grdAditamento As System.Web.UI.WebControls.DataGrid
    Protected WithEvents grdFaixas As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents txtPERFIXAPUVLRRCB As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents TRPercentualFixo As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents txtDataInicio As Infragistics.WebUI.WebSchedule.WebDateChooser
    Protected WithEvents txtDataFim As Infragistics.WebUI.WebSchedule.WebDateChooser
    Protected WithEvents txtPERUTZVLRAPUARDFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtPERRCTTBTADIARDFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtPERDSCNOTFSCFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents btnBuscarAditamento As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnSalvarAditamento As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelarAditamento As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblAditamento As System.Web.UI.WebControls.Label
    Protected WithEvents TROrigem As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents TRDadosAditamento As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents txtPERORIFIXAPUVLRRCB As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents lblSituacao As System.Web.UI.WebControls.Label

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

    Private Shadows Property Page() As Martins.Web.UI.AcoesComerciais.Contrato
        Get
            Return DirectCast(MyBase.Page, Martins.Web.UI.AcoesComerciais.Contrato)
        End Get
        Set(ByVal Value As Martins.Web.UI.AcoesComerciais.Contrato)
            MyBase.Page = Value
        End Set
    End Property

    Private ReadOnly Property Controles() As WebControl()
        Get
            'Return New WebControl() {txtCodClausula, ddlClausula, txtCodAbrangencia, ddlAbrangencia, _
            '    txtCodEntidade, ddlEntidade, txtCodBseClcVlrRec, ddlBseClcVlrRec, txtCodBseClcIndice, ddlBseClcIndice, _
            '    ddlTipCalculoFatMin, txtValorFatMin, chkMerExc, chkFaixa, chkFxaPer, chkDescMerNova, _
            '    chkPerVlr, txtVlrFixoApu, txtPerFixoVlr, chkBaseAnterior, chkIndIncIPIApuCtt, _
            '    chkIndIncICMApuCtt, chkIndIncPISApuCtt, chkIndIncSbtTbtApuCtt}
        End Get
    End Property

#End Region

#Region " Eventos "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not IsPostBack Then
                CarregaControles()
            End If
            CarregarJavaScript()
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub btnBuscarAditamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarAditamento.Click
        Try
            Me.BuscarAditamento()
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub grdAditamento_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdAditamento.PageIndexChanged
        Try
            DatasetContrato1 = Page.dsContrato
            Me.grdAditamento.CurrentPageIndex = e.NewPageIndex
            grdAditamento.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdAditamento_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdAditamento.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Dim AditamentoRow As wsAcoesComerciais.DatasetContrato.AditamentoRow
                Dim NUMCSLCTTFRN As Decimal = CType(e.Item.Cells(10).Text, Decimal)
                Dim CODEDEABGMIX As Decimal = CType(e.Item.Cells(13).Text, Decimal)
                Dim NUMCTTFRN As Decimal = CType(e.Item.Cells(4).Text, Decimal)
                Dim TIPEDEABGMIX As Decimal = CType(e.Item.Cells(11).Text, Decimal)
                Dim CODFXAAVL As Decimal = CType(e.Item.Cells(7).Text, Decimal)
                Dim DESCSLCTTFRN As String = consultarDESCSLCTTFRN(e.Item.Cells(10).Text)
                Dim DESEDEABGMIX As String = consultarDESEDEABGMIX(e.Item.Cells(11).Text)

                lblAditamento.Text = "Cláusula: " & DESCSLCTTFRN.Trim & ", Abrangência: " & DESEDEABGMIX.Trim & ", Entidade: " & e.Item.Cells(13).Text & ", Situação: "

                TRDadosAditamento.Visible = True
                If NUMCSLCTTFRN = 2 Then
                    TRFaixas.Visible = True
                    TRPercentualFixo.Visible = False
                    TROrigem.Visible = False
                Else
                    TRFaixas.Visible = False
                    TRPercentualFixo.Visible = True
                    txtPERFIXAPUVLRRCB.ValueDecimal = CType(e.Item.Cells(6).Text, Decimal)
                End If

                Me.DatasetContrato1 = Me.Page.dsContrato

                AditamentoRow = Me.DatasetContrato1.Aditamento.FindByNUMCTTFRNCODFXAAVLNUMCSLCTTFRNTIPEDEABGMIXCODEDEABGMIX(NUMCTTFRN, CODFXAAVL, NUMCSLCTTFRN, TIPEDEABGMIX, CODEDEABGMIX)

                If Not AditamentoRow Is Nothing Then
                    WSCAcoesComerciais.AditamentoRow = AditamentoRow
                End If

                txtPERDSCNOTFSCFRN.Text = String.Empty
                txtPERRCTTBTADIARDFRN.Text = String.Empty
                txtPERUTZVLRAPUARDFRN.Text = String.Empty

                Me.CarregaDatas()
                Me.BuscaAditamentoGravado(NUMCSLCTTFRN, NUMCTTFRN, CODEDEABGMIX, TIPEDEABGMIX)

            End If

        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub txtDataInicio_ValueChanged(ByVal sender As Object, ByVal e As Infragistics.WebUI.WebSchedule.WebDateChooser.WebDateChooserEventArgs) Handles txtDataInicio.ValueChanged
        Try
            If Not Me.ValidaDatas() Then
                CarregaDatas()
            End If
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub txtDataFim_ValueChanged(ByVal sender As Object, ByVal e As Infragistics.WebUI.WebSchedule.WebDateChooser.WebDateChooserEventArgs) Handles txtDataFim.ValueChanged
        Try
            If Not Me.ValidaDatas() Then
                CarregaDatas()
            End If
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub btnSalvarAditamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvarAditamento.Click
        Try
            Me.SalvarAditamento()
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub btnCancelarAditamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarAditamento.Click
        Try
            Me.CancelarAditamento()
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub
#End Region

#Region " Metodos "

#Region " Metodos de Carga "

    Private Sub CarregarJavaScript()
        'btnExcluir.Attributes.Add("OnClick", "javascript:return confirm('Deseja excluir a abrangencia?')")
    End Sub

    Private Sub CarregaControles()
        Me.CarregaGrdAditamento()
        Me.CarregaDatas()
        TRFaixas.Visible = False
        TRPercentualFixo.Visible = False
        TROrigem.Visible = False
        TRDadosAditamento.Visible = False
        WSCAcoesComerciais.AditamentoRow = Nothing
        btnBuscarAditamento.Enabled = False
        btnSalvarAditamento.Enabled = False
        btnCancelarAditamento.Enabled = False
    End Sub

    Public Sub CarregaDatas()
        If Me.DatasetContrato1.Aditamento.Rows.Count > 0 Then
            txtDataFim.Value = Me.DatasetContrato1.Aditamento(0).DATVNCCTTFRN.ToString
        End If
        txtDataInicio.Value = "01/" & Date.Now.Month & "/" & Date.Now.Year.ToString

    End Sub

    Private Sub BuscarAditamento()
        If grdAditamento.Items.Count <= 0 Then
            Util.AdicionaJsAlert(MyBase.Page, "Não é possível buscar aditamento! Nenhuma abrangência foi cadastrada para o contrato.", True)
            Exit Sub
        End If

        If (TRFaixas.Visible = True) Or (TRPercentualFixo.Visible = True) Then
            If Not WSCAcoesComerciais.AditamentoRow Is Nothing Then
                Dim dsPercentuaisAditamento As wsAcoesComerciais.DatasetContrato

                With WSCAcoesComerciais.AditamentoRow
                    dsPercentuaisAditamento = Controller.ObterAditamento(.NUMCTTFRN, .NUMCSLCTTFRN, .TIPEDEABGMIX, .CODEDEABGMIX)
                End With

                If dsPercentuaisAditamento.AditamentoPercentuais.Rows.Count <= 0 Then
                    Util.AdicionaJsAlert(MyBase.Page, "Não há simulação efetuada para gerar aditamento desta abrangência no acordo de fornecimento!", True)
                    Exit Sub
                Else
                    With dsPercentuaisAditamento.AditamentoPercentuais(0)
                        txtPERDSCNOTFSCFRN.ValueDecimal = .PERDSCNOTFSCFRN
                        txtPERRCTTBTADIARDFRN.ValueDecimal = .PERRCTTBTADIARDFRN
                        txtPERUTZVLRAPUARDFRN.ValueDecimal = .PERUTZVLRAPUARDFRN
                    End With

                End If

            End If
        Else
            Util.AdicionaJsAlert(MyBase.Page, "Antes de buscar o aditamento é necessário escolher uma abrangência!", True)
        End If
    End Sub

    Private Sub CarregaGrdAditamento()
        Try
            Me.DatasetContrato1 = Me.Page.dsContrato
            Me.ConfiguraDatasetAditamento()
            Me.CarregaGridFaixas()
            'Me.grdAditamento.DataBind()

        Catch ex As Exception
            If Me.grdAditamento.CurrentPageIndex > 0 Then
                Me.grdAditamento.CurrentPageIndex = 0
                Me.CarregaGrdAditamento()
            Else
                Controller.TrataErro(MyBase.Page, ex)
            End If

        End Try
    End Sub

    Private Sub BuscaAditamentoGravado(ByVal NUMCSLCTTFRN As Decimal, ByVal NUMCTTFRN As Decimal, ByVal CODEDEABGMIX As Decimal, ByVal TIPEDEABGMIX As Decimal)
        Dim dsAditamentoGravado As wsAcoesComerciais.DatasetContrato
        Dim AditamentoRow As wsAcoesComerciais.DatasetContrato.AditamentoRow
        dsAditamentoGravado = Controller.ObterAditamentoGravado(NUMCTTFRN, NUMCSLCTTFRN, TIPEDEABGMIX, CODEDEABGMIX)

        Me.CarregaGridFaixas()

        If NUMCSLCTTFRN = 2 Then
            AditamentoRow = Me.DatasetContrato1.Aditamento.FindByNUMCTTFRNCODFXAAVLNUMCSLCTTFRNTIPEDEABGMIXCODEDEABGMIX(NUMCTTFRN, 1, NUMCSLCTTFRN, TIPEDEABGMIX, CODEDEABGMIX)
        Else
            AditamentoRow = Me.DatasetContrato1.Aditamento.FindByNUMCTTFRNCODFXAAVLNUMCSLCTTFRNTIPEDEABGMIXCODEDEABGMIX(NUMCTTFRN, 0, NUMCSLCTTFRN, TIPEDEABGMIX, CODEDEABGMIX)
        End If

        WSCAcoesComerciais.AditamentoRow = AditamentoRow

        If dsAditamentoGravado.AditamentoGravado.Rows.Count = 0 Then
            btnBuscarAditamento.Enabled = True
            btnSalvarAditamento.Enabled = True
            btnCancelarAditamento.Enabled = False
            TROrigem.Visible = False
            lblSituacao.Text = "Inativo"
            If NUMCSLCTTFRN <> 2 Then
                txtPERFIXAPUVLRRCB.ValueDecimal = AditamentoRow.PERFIXAPUVLRRCB
            End If
            Me.grdFaixas.Bands(0).Columns(13).Hidden = True
            Me.grdFaixas.Width = Unit.Pixel(224)
        Else
            btnBuscarAditamento.Enabled = False
            btnSalvarAditamento.Enabled = False
            btnCancelarAditamento.Enabled = True

            If NUMCSLCTTFRN <> 2 Then
                TROrigem.Visible = True
                txtPERORIFIXAPUVLRRCB.ValueDecimal = AditamentoRow.PERORIFIXAPUVLRRCB
                txtPERFIXAPUVLRRCB.ValueDecimal = AditamentoRow.PERFIXAPUVLRRCB
            End If

            lblSituacao.Text = "Ativo"

            With dsAditamentoGravado.AditamentoGravado(0)
                txtDataInicio.Value = .DATINIVGRADIARDFRN
                txtDataFim.Value = .DATFIMVGRADIARDFRN
                txtPERDSCNOTFSCFRN.ValueDecimal = .PERDSCNOTFSCFRN
                txtPERRCTTBTADIARDFRN.ValueDecimal = .PERRCTTBTADIARDFRN
                txtPERUTZVLRAPUARDFRN.ValueDecimal = .PERUTZVLRAPUARDFRN
            End With

            Me.grdFaixas.Bands(0).Columns(13).Hidden = False
            Me.grdFaixas.Width = Unit.Pixel(284)
        End If

    End Sub

    Private Sub SalvarAditamento()
        Try
            If txtPERDSCNOTFSCFRN.Text = String.Empty Or txtPERRCTTBTADIARDFRN.Text = String.Empty Or txtPERUTZVLRAPUARDFRN.Text = String.Empty Then
                Util.AdicionaJsAlert(MyBase.Page, "Antes de salvar aditamento é necessário buscar simulação!", True)
                Exit Sub
            End If

            Dim INDSUSAPUARDFRN As Decimal = 0
            Dim T0124996Row As wsAcoesComerciais.DatasetContrato.T0124996Row
            Dim AditamentoRow As wsAcoesComerciais.DatasetContrato.AditamentoRow = WSCAcoesComerciais.AditamentoRow

            Me.DatasetContrato1 = Me.Page.dsContrato

            Me.DatasetContrato1.RLCARDFRNADINOTFSC.Rows.Clear()

            'Inserir aditamento tabela:MRT.RLCARDFRNADINOTFSC
            Dim RLCARDFRNADINOTFSCRow As wsAcoesComerciais.DatasetContrato.RLCARDFRNADINOTFSCRow
            RLCARDFRNADINOTFSCRow = Me.DatasetContrato1.RLCARDFRNADINOTFSC.NewRLCARDFRNADINOTFSCRow

            With RLCARDFRNADINOTFSCRow
                .CODEDEABGMIX = AditamentoRow.CODEDEABGMIX
                .SetDATCNCADIARDFRNNull()
                .DATFIMVGRADIARDFRN = CType(txtDataFim.Value, Date)
                .DATINIVGRADIARDFRN = CType(txtDataInicio.Value, Date)
                .NUMCSLCTTFRN = AditamentoRow.NUMCSLCTTFRN
                .NUMCTTFRN = AditamentoRow.NUMCTTFRN
                .PERDSCNOTFSCFRN = txtPERDSCNOTFSCFRN.ValueDecimal
                .PERRCTTBTADIARDFRN = txtPERRCTTBTADIARDFRN.ValueDecimal
                .PERUTZVLRAPUARDFRN = txtPERUTZVLRAPUARDFRN.ValueDecimal
                .TIPEDEABGMIX = AditamentoRow.TIPEDEABGMIX
            End With

            Me.DatasetContrato1.RLCARDFRNADINOTFSC.AddRLCARDFRNADINOTFSCRow(RLCARDFRNADINOTFSCRow)

            'Atualiza abrangencia
            If (AditamentoRow.PERFIXAPUVLRRCB - txtPERUTZVLRAPUARDFRN.ValueDecimal) = 0 Then
                INDSUSAPUARDFRN = 1
            End If

            With AditamentoRow
                T0124996Row = Me.DatasetContrato1.T0124996.FindByNUMCTTFRNNUMCSLCTTFRNTIPEDEABGMIXCODEDEABGMIX(.NUMCTTFRN, .NUMCSLCTTFRN, .TIPEDEABGMIX, .CODEDEABGMIX)
            End With

            T0124996Row.PERFIXAPUVLRRCB = AditamentoRow.PERFIXAPUVLRRCB - txtPERUTZVLRAPUARDFRN.ValueDecimal
            T0124996Row.PERORIFIXAPUVLRRCB = AditamentoRow.PERFIXAPUVLRRCB
            T0124996Row.INDSUSAPUARDFRN = INDSUSAPUARDFRN

            'Atualizar Faixas
            'Somente atualiza as faixas se a abrangencia escolhida for a de bonus de crescimento
            If (AditamentoRow.NUMCSLCTTFRN = 2) Then
                Dim CODFXAAVLAUX As Integer = 1

                For Each T0125038Row As wsAcoesComerciais.DatasetContrato.T0125038Row In Me.DatasetContrato1.T0125038.Select("NUMCSLCTTFRN IN (2,3,10)")
                    If (T0125038Row.PERAPUVLRRCBREFFXA - txtPERUTZVLRAPUARDFRN.ValueDecimal) <= 0 Then
                        T0125038Row.PERORIAPUVLRRCBFXA = T0125038Row.PERAPUVLRRCBREFFXA
                        T0125038Row.PERAPUVLRRCBREFFXA = 0
                    Else
                        T0125038Row.PERORIAPUVLRRCBFXA = T0125038Row.PERAPUVLRRCBREFFXA
                        T0125038Row.PERAPUVLRRCBREFFXA = T0125038Row.PERAPUVLRRCBREFFXA - txtPERUTZVLRAPUARDFRN.ValueDecimal
                    End If
                Next
            End If

            'Atualizar Simulação
            Me.DatasetContrato1.Merge(Controller.ObterDadosSimulacao(AditamentoRow.NUMCTTFRN, AditamentoRow.NUMCSLCTTFRN, AditamentoRow.TIPEDEABGMIX, AditamentoRow.CODEDEABGMIX))

            If Me.DatasetContrato1.RLCARDFRNSMLADI.Rows.Count > 0 Then
                If Me.DatasetContrato1.RLCARDFRNSMLADI(0).IsDATEFTSMLADIARDFRNNull Then
                    Me.DatasetContrato1.RLCARDFRNSMLADI(0).DATEFTSMLADIARDFRN = Date.Now
                End If
            End If

            Controller.AtualizarAditamento(Me.DatasetContrato1)

            Me.DatasetContrato1 = Controller.ObterContrato(Me.Page.NUMCTTFRN)

            Me.Page.dsContrato = Me.DatasetContrato1

            With AditamentoRow
                BuscaAditamentoGravado(.NUMCSLCTTFRN, .NUMCTTFRN, .CODEDEABGMIX, .TIPEDEABGMIX)
            End With

            Util.AdicionaJsAlert(MyBase.Page, "Aditamento salvo com sucesso!", True)
        Catch ex As Exception
            Me.DatasetContrato1.RejectChanges()
            Controller.TrataErro(MyBase.Page, ex)
        End Try
       

    End Sub

    Private Sub CancelarAditamento()

        Dim T0124996Row As wsAcoesComerciais.DatasetContrato.T0124996Row
        Dim AditamentoRow As wsAcoesComerciais.DatasetContrato.AditamentoRow = WSCAcoesComerciais.AditamentoRow
        Dim dsAditamento As wsAcoesComerciais.DatasetContrato
        Dim RLCARDFRNADINOTFSCRow As wsAcoesComerciais.DatasetContrato.RLCARDFRNADINOTFSCRow

        Me.DatasetContrato1 = Me.Page.dsContrato

        'Atualiza tabela de aditamento
        With AditamentoRow
            RLCARDFRNADINOTFSCRow = Me.DatasetContrato1.RLCARDFRNADINOTFSC.FindByNUMCTTFRNNUMCSLCTTFRNTIPEDEABGMIXCODEDEABGMIXDATINIVGRADIARDFRN(.NUMCTTFRN, .NUMCSLCTTFRN, .TIPEDEABGMIX, .CODEDEABGMIX, CType(txtDataInicio.Value, Date))
        End With

        If Not RLCARDFRNADINOTFSCRow Is Nothing Then
            RLCARDFRNADINOTFSCRow.DATCNCADIARDFRN = Date.Now
        End If

        'Atualiza abrangencia
        With AditamentoRow
            T0124996Row = Me.DatasetContrato1.T0124996.FindByNUMCTTFRNNUMCSLCTTFRNTIPEDEABGMIXCODEDEABGMIX(.NUMCTTFRN, .NUMCSLCTTFRN, .TIPEDEABGMIX, .CODEDEABGMIX)
        End With

        T0124996Row.PERFIXAPUVLRRCB = T0124996Row.PERORIFIXAPUVLRRCB
        T0124996Row.PERORIFIXAPUVLRRCB = 0
        T0124996Row.INDSUSAPUARDFRN = 0

        'Atualizar faixas
        If (AditamentoRow.NUMCSLCTTFRN = 2) Then
            For Each T0125038Row As wsAcoesComerciais.DatasetContrato.T0125038Row In Me.DatasetContrato1.T0125038.Select("NUMCSLCTTFRN IN (2,3,10)")
                T0125038Row.PERAPUVLRRCBREFFXA = T0125038Row.PERORIAPUVLRRCBFXA
                T0125038Row.PERORIAPUVLRRCBFXA = 0
            Next
        End If
        Controller.AtualizarAditamento(Me.DatasetContrato1)

        Me.DatasetContrato1 = Controller.ObterContrato(Me.Page.NUMCTTFRN)

        Me.Page.dsContrato = Me.DatasetContrato1

        txtPERDSCNOTFSCFRN.Text = String.Empty
        txtPERRCTTBTADIARDFRN.Text = String.Empty
        txtPERUTZVLRAPUARDFRN.Text = String.Empty

        With AditamentoRow
            BuscaAditamentoGravado(.NUMCSLCTTFRN, .NUMCTTFRN, .CODEDEABGMIX, .TIPEDEABGMIX)
        End With

        Me.CarregaDatas()
        Util.AdicionaJsAlert(MyBase.Page, "Aditamento cancelado com sucesso!", True)
    End Sub
#End Region

#Region " Metodos de Controles "

    Private Sub ConfiguraDatasetAditamento()
        'Esconde as linhas repeditas referentes ao Bonus Crescimento do dataset Aditamento
        Dim dsAditamento As New wsAcoesComerciais.DatasetContrato
        Dim DatasetContratoCopy As New wsAcoesComerciais.DatasetContrato
        Dim NUMCSLCTTFRN As Decimal = 0
        Dim AditamentoRow As wsAcoesComerciais.DatasetContrato.AditamentoRow

        For Each linha As wsAcoesComerciais.DatasetContrato.AditamentoRow In Me.Page.dsContrato.Aditamento

            If NUMCSLCTTFRN = 0 Then
                NUMCSLCTTFRN = linha.NUMCSLCTTFRN
                AditamentoRow = dsAditamento.Aditamento.NewAditamentoRow
                With AditamentoRow
                    .CODFRN = linha.CODFRN
                    .CODFXAAVL = linha.CODFXAAVL
                    .DESCSLCTTFRN = linha.DESCSLCTTFRN
                    .NOMFRN = linha.NOMFRN
                    .NUMCSLCTTFRN = linha.NUMCSLCTTFRN
                    .NUMCTTFRN = linha.NUMCTTFRN
                    .PERAPUVLRRCBREFFXA = linha.PERAPUVLRRCBREFFXA
                    .PERFIXAPUVLRRCB = linha.PERFIXAPUVLRRCB
                    .TIPEDEABGMIX = linha.TIPEDEABGMIX
                    .VLRFXAAVL = linha.VLRFXAAVL
                    .CODEDEABGMIX = linha.CODEDEABGMIX
                    .DATVNCCTTFRN = linha.DATVNCCTTFRN
                    .PERORIFIXAPUVLRRCB = linha.PERORIFIXAPUVLRRCB
                    .PERORIAPUVLRRCBFXA = linha.PERORIAPUVLRRCBFXA
                End With
                dsAditamento.Aditamento.AddAditamentoRow(AditamentoRow)
            Else
                If (NUMCSLCTTFRN <> linha.NUMCSLCTTFRN) Or ((NUMCSLCTTFRN = linha.NUMCSLCTTFRN) And (linha.NUMCSLCTTFRN <> 2)) Then

                    NUMCSLCTTFRN = linha.NUMCSLCTTFRN
                    AditamentoRow = dsAditamento.Aditamento.NewAditamentoRow
                    With AditamentoRow
                        .CODFRN = linha.CODFRN
                        .CODFXAAVL = linha.CODFXAAVL
                        .DESCSLCTTFRN = linha.DESCSLCTTFRN
                        .NOMFRN = linha.NOMFRN
                        .NUMCSLCTTFRN = linha.NUMCSLCTTFRN
                        .NUMCTTFRN = linha.NUMCTTFRN
                        .PERAPUVLRRCBREFFXA = linha.PERAPUVLRRCBREFFXA
                        .PERFIXAPUVLRRCB = linha.PERFIXAPUVLRRCB
                        .TIPEDEABGMIX = linha.TIPEDEABGMIX
                        .VLRFXAAVL = linha.VLRFXAAVL
                        .CODEDEABGMIX = linha.CODEDEABGMIX
                        .DATVNCCTTFRN = linha.DATVNCCTTFRN
                        .PERORIFIXAPUVLRRCB = linha.PERORIFIXAPUVLRRCB
                        .PERORIAPUVLRRCBFXA = linha.PERORIAPUVLRRCBFXA
                    End With

                    dsAditamento.Aditamento.AddAditamentoRow(AditamentoRow)

                End If
            End If
        Next

        Me.DatasetContrato1.Aditamento.Clear()
        Me.DatasetContrato1.Merge(dsAditamento.Aditamento)
        Me.grdAditamento.DataBind()

    End Sub

    Private Sub CarregaGridFaixas()
        Dim dsFaixas As New wsAcoesComerciais.DatasetContrato

        Me.DatasetContrato1.Aditamento.Clear()
        Me.DatasetContrato1.Merge(Controller.ObterAbrangenciaAditamento(Me.Page.NUMCTTFRN))

        For Each AditamentoRow As wsAcoesComerciais.DatasetContrato.AditamentoRow In Me.Page.dsContrato.Aditamento
            If AditamentoRow.NUMCSLCTTFRN = 2 Then
                Dim linha As wsAcoesComerciais.DatasetContrato.AditamentoRow
                linha = dsFaixas.Aditamento.NewAditamentoRow

                With linha
                    .CODFRN = AditamentoRow.CODFRN
                    .CODFXAAVL = AditamentoRow.CODFXAAVL
                    .DESCSLCTTFRN = AditamentoRow.DESCSLCTTFRN
                    .NOMFRN = AditamentoRow.NOMFRN
                    .NUMCSLCTTFRN = AditamentoRow.NUMCSLCTTFRN
                    .NUMCTTFRN = AditamentoRow.NUMCTTFRN
                    .PERAPUVLRRCBREFFXA = AditamentoRow.PERAPUVLRRCBREFFXA
                    .PERFIXAPUVLRRCB = AditamentoRow.PERFIXAPUVLRRCB
                    .TIPEDEABGMIX = AditamentoRow.TIPEDEABGMIX
                    .VLRFXAAVL = AditamentoRow.VLRFXAAVL
                    .CODEDEABGMIX = AditamentoRow.CODEDEABGMIX
                    .DATVNCCTTFRN = AditamentoRow.DATVNCCTTFRN
                    .PERORIFIXAPUVLRRCB = AditamentoRow.PERORIFIXAPUVLRRCB
                    .PERORIAPUVLRRCBFXA = AditamentoRow.PERORIAPUVLRRCBFXA
                End With
                dsFaixas.Aditamento.AddAditamentoRow(linha)
            End If
        Next

        Me.grdFaixas.DataSource = dsFaixas
        Me.grdFaixas.DataMember = "Aditamento"
        Me.grdFaixas.DataBind()
        Me.ConfiguraLayoutGridFaixas()
        Me.DatasetContrato1 = Controller.ObterContrato(Me.Page.NUMCTTFRN)

        Me.Page.dsContrato.Merge(Me.DatasetContrato1)
    End Sub

    Private Sub ConfiguraLayoutGridFaixas()
        With Me.grdFaixas

            'Esconde colunas desnecessarias
            .Bands(0).Columns(0).Hidden = True
            .Bands(0).Columns(1).Hidden = True
            .Bands(0).Columns(2).Hidden = True
            .Bands(0).Columns(3).Hidden = True
            .Bands(0).Columns(4).Hidden = True
            .Bands(0).Columns(5).Hidden = True
            .Bands(0).Columns(8).Hidden = True
            .Bands(0).Columns(9).Hidden = True
            .Bands(0).Columns(10).Hidden = True
            .Bands(0).Columns(11).Hidden = True
            .Bands(0).Columns(12).Hidden = True

            'Muda cabeçalho
            .Bands(0).Columns(6).Header.Caption = "Níveis de Crescimento"
            .Bands(0).Columns(6).Header.Style.HorizontalAlign = HorizontalAlign.Center
            .Bands(0).Columns(6).CellStyle.HorizontalAlign = HorizontalAlign.Center
            .Bands(0).Columns(6).Width = Unit.Pixel(150)
            .Bands(0).Columns(7).Header.Caption = "% Atual"
            .Bands(0).Columns(7).CellStyle.HorizontalAlign = HorizontalAlign.Center
            .Bands(0).Columns(7).Header.Style.HorizontalAlign = HorizontalAlign.Center
            .Bands(0).Columns(7).Width = Unit.Pixel(50)
            .Bands(0).Columns(13).Header.Caption = "% Original"
            .Bands(0).Columns(13).CellStyle.HorizontalAlign = HorizontalAlign.Center
            .Bands(0).Columns(13).Header.Style.HorizontalAlign = HorizontalAlign.Center
            .Bands(0).Columns(13).Width = Unit.Pixel(60)


            'Gera os niveis de crescimento
            For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdFaixas.Rows
                If linha.Index = Me.grdFaixas.Rows.Count - 1 Then
                    linha.Cells(6).Value = "Acima de  " & Format(CType(linha.Cells(6).Text, Decimal), "###,##0.#0") & "%"
                Else
                    linha.Cells(6).Value = "De " & Format(CType(linha.Cells(6).Text, Decimal), "###,##0.#0") & "% a " & Format(CType(linha.NextRow.Cells(6).Text, Decimal) - 0.1, "###,##0.#0") & "%"

                End If
            Next

            .Bands(0).Columns(7).Format = "###,##0.#0"
            .Bands(0).Columns(13).Format = "###,##0.#0"
        End With

    End Sub

    Protected Function consultarDESCSLCTTFRN(ByVal vDad As String) As String
        Dim result As String = String.Empty

        If vDad Is Nothing Then
            result = ""
        ElseIf vDad = "" Then
            result = ""
        ElseIf Not IsNumeric(vDad) Then
            result = ""
        Else
            Try
                Dim linha As wsAcoesComerciais.DatasetContrato.T0124953Row = Me.Page.dsContrato.T0124953.FindByNUMCSLCTTFRN(Convert.ToDecimal(vDad))
                If Not linha Is Nothing Then
                    result = linha.NUMCSLCTTFRN.ToString("0000") & " - " & linha.DESCSLCTTFRN
                End If
            Catch ex As Exception
                result = ""
            End Try
        End If

        Return result
    End Function

    Protected Function consultarDESEDEABGMIX(ByVal vDad As String) As String
        Dim result As String = String.Empty

        If WSCAcoesComerciais.dsTipoAbrangenciaMix Is Nothing Then
            WSCAcoesComerciais.dsTipoAbrangenciaMix = Controller.ObterTiposAbrangenciaMix("")
        End If

        If vDad Is Nothing Then
            result = ""
        ElseIf vDad = "" Then
            result = ""
        ElseIf Not IsNumeric(vDad) Then
            result = ""
        Else
            Try
                Dim linha As wsAcoesComerciais.DatasetTipoAbrangenciaMix.T0125011Row = WSCAcoesComerciais.dsTipoAbrangenciaMix.T0125011.FindByTIPEDEABGMIX(Convert.ToDecimal(vDad))
                If Not linha Is Nothing Then
                    result = linha.TIPEDEABGMIX.ToString("0000") & " - " & linha.DESEDEABGMIX
                End If
            Catch ex As Exception
                result = ""
            End Try
        End If

        Return result
    End Function

    Private Function ValidaDatas() As Boolean
        Dim dataInicialLimite As Date
        Dim dataFinalLimite As Date

        Me.DatasetContrato1 = Me.Page.dsContrato

        If Me.DatasetContrato1.Aditamento.Rows.Count > 0 Then
            dataFinalLimite = CType(Me.DatasetContrato1.Aditamento(0).DATVNCCTTFRN.ToString, Date)
        Else
            Return False
        End If

        dataInicialLimite = CType("01/" & Date.Now.Month & "/" & Date.Now.Year.ToString, Date)

        If CType(txtDataInicio.Value, Date) < dataInicialLimite Then
            Util.AdicionaJsAlert(MyBase.Page, "Data inicial não pode ser menor que " & dataInicialLimite.Date & "!", True)
            Return False
        End If

        If CType(txtDataFim.Value, Date) > dataFinalLimite Then
            Util.AdicionaJsAlert(MyBase.Page, "Data final não pode ser maior que " & dataFinalLimite.Date & "!", True)
            Return False
        End If

        If CType(txtDataInicio.Value, Date) > CType(txtDataFim.Value, Date) Then
            Util.AdicionaJsAlert(MyBase.Page, "Data inicial não pode ser maior que data final!", True)
            Return False
        End If

        If CType(txtDataInicio.Value, Date) = CType(txtDataFim.Value, Date) Then
            Util.AdicionaJsAlert(MyBase.Page, "As datas não podem ser iguais!", True)
            Return False
        End If
        Return True
    End Function
#End Region

#Region " Metodos de Regras de Negocio "


#End Region

#End Region

End Class