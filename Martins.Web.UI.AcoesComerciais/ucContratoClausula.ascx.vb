Public Class ucContratoClausula
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetContrato1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContrato
        CType(Me.DatasetContrato1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetContrato1
        '
        Me.DatasetContrato1.DataSetName = "DatasetContrato"
        Me.DatasetContrato1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetContrato1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents ddlDVF As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlMoeda As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtPercCtaFrn As Infragistics.WebUI.WebDataInput.WebPercentEdit
    Protected WithEvents chkGeraAco As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkFlgDscAut As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtDiaVencAco As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtTipDsc As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtDatVigCsl As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtObs As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtQdeMesApuMedPod As Infragistics.WebUI.WebDataInput.WebPercentEdit
    Protected WithEvents ddlDatRefApuPodCslCtt As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlTipLimCalPod As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtVlrLimFatcalPod As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtPerIteVarMix As Infragistics.WebUI.WebDataInput.WebPercentEdit
    Protected WithEvents txtCodDVF As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents cmdDesativarClausula As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cmdAtualizarClausula As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cmdNovaClausula As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnTrimestralidade As System.Web.UI.WebControls.Button
    Protected WithEvents btnAnualidade As System.Web.UI.WebControls.Button
    Protected WithEvents ddlDVM As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodDVM As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents ddlFormaPagamento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodFormaPagamento As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents DatasetContrato1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContrato
    Protected WithEvents grdClausulas As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblErrotxtCodFormaPagamento As System.Web.UI.WebControls.Label
    Protected WithEvents lblErroddlMoeda As System.Web.UI.WebControls.Label
    Protected WithEvents lblErrotxtCodDVF As System.Web.UI.WebControls.Label
    Protected WithEvents lblErrotxtCodDVM As System.Web.UI.WebControls.Label
    Protected WithEvents lblErrotxtPercCtaFrn As System.Web.UI.WebControls.Label
    Protected WithEvents lblErrotxtDiaVencAco As System.Web.UI.WebControls.Label
    Protected WithEvents lblErrotxtDatVigCsl As System.Web.UI.WebControls.Label
    Protected WithEvents lblErrotxtPerIteVarMix As System.Web.UI.WebControls.Label
    Protected WithEvents lblErroddlDatRefApuPodCslCtt As System.Web.UI.WebControls.Label
    Protected WithEvents lblErrotxtQdeMesApuMedPod As System.Web.UI.WebControls.Label
    Protected WithEvents lblErrotxtVlrLimFatcalPod As System.Web.UI.WebControls.Label
    Protected WithEvents lblErrotxtQdeIteVarMix As System.Web.UI.WebControls.Label
    Protected WithEvents lblErroddlTipLimCalPod As System.Web.UI.WebControls.Label
    Protected WithEvents lblErrotxtQdePedPodApuCsl As System.Web.UI.WebControls.Label
    Protected WithEvents lblErrotxtTipDsc As System.Web.UI.WebControls.Label
    Protected WithEvents txtQdeIteVarMix As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtQdePedPodApuCsl As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents lblErrotxtCodClausula As System.Web.UI.WebControls.Label
    Protected WithEvents ddlClausula As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodClausula As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtTIPPODCTTFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents cmbTIPPODCTTFRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblTIPPODCTTFRN As System.Web.UI.WebControls.Label
    Protected WithEvents TD1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD2 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD3 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD4 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents btnExcluir As System.Web.UI.WebControls.LinkButton

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

    Public Overrides Property Visible() As Boolean
        Get
            Return MyBase.Visible
        End Get
        Set(ByVal Value As Boolean)
            MyBase.Visible = Value
            If Value Then Me.CarregaControles()
        End Set
    End Property

    Private ReadOnly Property Controles() As WebControl()
        Get
            Return New WebControl() {txtCodClausula, ddlClausula, txtCodFormaPagamento, ddlFormaPagamento, _
                            txtCodDVF, ddlDVF, txtCodDVM, ddlDVM, ddlMoeda, txtPercCtaFrn, chkGeraAco, chkFlgDscAut, _
                            txtDiaVencAco, txtTipDsc, txtDatVigCsl, txtObs, ddlDatRefApuPodCslCtt, txtQdeMesApuMedPod, _
                            ddlTipLimCalPod, txtVlrLimFatcalPod, txtQdeIteVarMix, txtPerIteVarMix, txtQdePedPodApuCsl, _
                            btnTrimestralidade, btnAnualidade}
        End Get
    End Property

    Private Property iIndCalGrpFrnAsc() As Integer
        Get
            If Me.ViewState.Item("iIndCalGrpFrnAsc") Is Nothing Then
                Return 0
            Else
                Return Convert.ToInt32(Me.ViewState.Item("iIndCalGrpFrnAsc"))
            End If
        End Get
        Set(ByVal Value As Integer)
            Me.ViewState.Add("iIndCalGrpFrnAsc", Value)
        End Set
    End Property

#End Region

#Region " Eventos "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not IsPostBack Then
                CarregaControles()
                TD1.Visible = False
                TD2.Visible = False
                TD3.Visible = False
                TD4.Visible = False
            End If
            CarregarJavaScript()
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub cmdNovaClausula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovaClausula.Click
        Try
            If ValidarPreCondicoesParaInclusãoDeClausula() Then
                txtCodClausula.Enabled = True
                ddlClausula.Enabled = True

                Dim ctrlLblErro As WebControl() = New WebControl() {lblErrotxtCodClausula, _
                                                                    lblErrotxtCodFormaPagamento, _
                                                                    lblErrotxtCodDVF, _
                                                                    lblErroddlMoeda, _
                                                                    lblErrotxtCodDVM, _
                                                                    lblErrotxtDatVigCsl, _
                                                                    lblErrotxtPercCtaFrn, _
                                                                    lblErrotxtDiaVencAco, _
                                                                    lblErrotxtTipDsc}

                Util.MostraControles(ctrlLblErro, True)

                For Each ctrl As WebControl In Me.Controles()
                    Util.LimpaControles(New WebControl() {ctrl}, False)
                Next
                Util.AdicionaJsFocus(MyBase.Page, CType(txtCodClausula, WebControl), Util.tipoDeComponente.InfragisticsTxt)
            End If
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub cmdAtualizarClausula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizarClausula.Click
        Try
            If Page.flagContratoAtivo = False Then
                Util.AdicionaJsAlert(MyBase.Page, "Esse contrato não está ativo")
                Exit Sub
            End If
            'Page.SalvarEContinuar()
            If Me.SalvarDados() Then
                Me.CarregaGrdClausulas(recarregads:=False)
                cmdNovaClausula_Click(sender, e)
                'Page.carregarClausulasNasTabs()
                Page.SalvarEContinuar()

                'Limpar controles
                For Each ctrl As WebControl In Me.Controles()
                    Util.LimpaControles(New WebControl() {ctrl}, False)
                Next
            End If
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub cmdDesativarClausula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDesativarClausula.Click
        Try
            If Page.flagContratoAtivo = False Then
                Util.AdicionaJsAlert(MyBase.Page, "Esse contrato não está ativo")
                Exit Sub
            End If
            Me.DesativarClausula()
            Me.CarregaGrdClausulas(recarregads:=False)
            Util.AdicionaJsFocus(MyBase.Page, CType(cmdNovaClausula, WebControl))
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click
        Try
            If Page.flagContratoAtivo = False Then
                Util.AdicionaJsAlert(MyBase.Page, "Esse contrato não está ativo")
                Exit Sub
            End If
            If Page.existeApuracaoParaEsseContrato(txtCodClausula.ValueDecimal) Then
                Util.AdicionaJsAlert(MyBase.Page, "Existe apuração para essa cláusula, não é permitido excluir")
                Exit Sub
            End If
            Me.ExcluirClausula()
            Page.SalvarEContinuar()
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub ddlClausula_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlClausula.SelectedIndexChanged
        Try
            Me.MudaClausula()
            Util.AdicionaJsFocus(MyBase.Page, CType(txtCodFormaPagamento, WebControl))
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub ddlFormaPagamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlFormaPagamento.SelectedIndexChanged
        Try
            txtCodFormaPagamento.Text = ddlFormaPagamento.SelectedValue
            Util.AdicionaJsFocus(MyBase.Page, CType(txtCodDVM, WebControl), Util.tipoDeComponente.InfragisticsTxt)
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub ddlDVF_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlDVF.SelectedIndexChanged
        Try
            txtCodDVF.Text = ddlDVF.SelectedValue
            Util.AdicionaJsFocus(MyBase.Page, CType(txtCodFormaPagamento, WebControl), Util.tipoDeComponente.InfragisticsTxt)
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub ddlDVM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlDVM.SelectedIndexChanged
        Try
            txtCodDVM.Text = ddlDVM.SelectedValue
            Util.AdicionaJsFocus(MyBase.Page, CType(ddlMoeda, WebControl))
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub grdClausulas_Click(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.UltraWebGrid.ClickEventArgs)
        Try
            Me.EditarClausula(Convert.ToDecimal(e.Row.Cells(1).GetText()))
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub grdClausulas_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdClausulas.PageIndexChanged
        Try
            DatasetContrato1 = Page.dsContrato
            Me.grdClausulas.CurrentPageIndex = e.NewPageIndex
            grdClausulas.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chkGeraAco_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGeraAco.CheckedChanged
        Try
            If chkGeraAco.Checked Then
                chkFlgDscAut.Checked = False
                chkFlgDscAut.Enabled = False
            Else
                chkFlgDscAut.Enabled = True
            End If
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub ddlTipPod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Util.AdicionaJsFocus(MyBase.Page, CType(txtCodDVF, WebControl), Util.tipoDeComponente.InfragisticsTxt)
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub btnTrimestralidade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrimestralidade.Click
        Try
            Me.SalvarDados()
            Page.transferirDadosParaDataset(Page.dsContrato)
            Controller.AtualizarContrato(Page.dsContrato)

            If Me.TrimestralidadeAnualidadePermitida(1) Then
                If Controller.GerarClausulaTrimestralidade(Me.Page.NUMCTTFRN) Then
                    Util.AdicionaJsAlert(MyBase.Page, "Geração da cláusula Trimestralidade executada com sucesso")
                    Me.CarregaGrdClausulas(recarregads:=True)
                End If

                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""Contrato.aspx?numcttfrn=" & Page.NUMCTTFRN.ToString & """;" & vbCrLf)
                Response.Write("</script>" & vbCrLf)

            End If
            btnTrimestralidade.Enabled = False
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub btnAnualidade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnualidade.Click
        Try
            Me.SalvarDados()
            Page.transferirDadosParaDataset(Page.dsContrato)
            Controller.AtualizarContrato(Page.dsContrato)

            If Me.TrimestralidadeAnualidadePermitida(2) Then
                Page.transferirDadosParaDataset(Page.dsContrato)
                Controller.AtualizarContrato(Page.dsContrato)

                If Controller.GerarClausulaAnualidade(Me.Page.NUMCTTFRN) Then
                    Util.AdicionaJsAlert(MyBase.Page, "Geração da cláusula Anualidade executada com sucesso")
                    Me.CarregaGrdClausulas(recarregads:=True)
                End If

                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""Contrato.aspx?numcttfrn=" & Page.NUMCTTFRN.ToString & """;" & vbCrLf)
                Response.Write("</script>" & vbCrLf)
            End If
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub txtCodDVF_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtCodDVF.ValueChange
        Try
            If txtCodDVF.Text <> ddlDVF.SelectedValue Then
                ddlDVF.SelectedValue = txtCodDVF.Text
            End If
            Util.AdicionaJsFocus(MyBase.Page, CType(txtCodFormaPagamento, WebControl), Util.tipoDeComponente.InfragisticsTxt)
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub txtCodFormaPagamento_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtCodFormaPagamento.ValueChange
        Try
            If txtCodFormaPagamento.Text <> ddlFormaPagamento.SelectedValue Then
                ddlFormaPagamento.SelectedValue = txtCodFormaPagamento.Text
            End If
            Util.AdicionaJsFocus(MyBase.Page, CType(txtCodDVM, WebControl), Util.tipoDeComponente.InfragisticsTxt)
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub txtCodDVM_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtCodDVM.ValueChange
        Try
            If txtCodDVM.Text <> ddlDVM.SelectedValue Then
                ddlDVM.SelectedValue = txtCodDVM.Text
            End If
            Util.AdicionaJsFocus(MyBase.Page, CType(ddlMoeda, WebControl))
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub grdClausulas_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdClausulas.ItemCommand
        Try
            If e.CommandName = "Link" Then
                EditarClausula(Convert.ToDecimal(e.Item.Cells(4).Text))
            End If

        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub cmbTIPPODCTTFRN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTIPPODCTTFRN.SelectedIndexChanged
        If ddlClausula.SelectedValue = "2" Then
            If cmbTIPPODCTTFRN.SelectedValue <> String.Empty Then
                btnTrimestralidade.Enabled = (cmbTIPPODCTTFRN.SelectedValue = "1")
            End If
        End If
    End Sub

    Private Sub txtCodClausula_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtCodClausula.ValueChange
        Try
            ddlClausula.SelectedValue = txtCodClausula.Text
            ddlClausula_SelectedIndexChanged(sender, e)
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region " Metodos "

#Region " Metodos de Carga "

    Private Sub CarregaControles()
        Me.CarregaDDLClausulas()
        Me.CarregaDDLDestinoVerba()
        Me.CarregaDDLFormaPgto()
        Me.CarregaDDLMoeda()
        Me.CarregaGrdClausulas(RecarregaDS:=Me.Page.dsContrato.T0124961.Rows.Count = 0)
        Me.CarregaCmbTIPPODCTTFRN()
        'Me.SetPageSate(Contrato.PageState.SemAcao)
        cmdDesativarClausula.Attributes.Add("OnClick", "javascript:return confirm('Deseja desativar a cláusula?')")
    End Sub

    Private Sub CarregaDDLClausulas()
        If Not ddlClausula.Items.Count > 0 Then
            Dim ds As wsAcoesComerciais.DatasetClausulaContrato = _
                        Controller.ObterClausulasContrato(String.Empty, Decimal.Zero)

            Util.carregarClausulaContrato(ds, ddlClausula, New ListItem(String.Empty, String.Empty))
        End If
    End Sub

    Private Sub CarregaCmbTIPPODCTTFRN()
        If Not cmbTIPPODCTTFRN.Items.Count > 0 Then
            Dim ds As wsAcoesComerciais.DatasetTipoPeriodo = _
                        Controller.ObterTiposPeriodo(String.Empty, Decimal.Zero)

            Util.carregarCmbTipoPeriodo(ds, cmbTIPPODCTTFRN, New ListItem(String.Empty, String.Empty))
        End If
    End Sub

    Private Sub CarregaDDLDestinoVerba()
        If Not ddlDVF.Items.Count > 0 Then
            Dim ds As wsAcoesComerciais.DatasetEmpenho = _
                        Controller.ObterEmpenhos(String.Empty, String.Empty, String.Empty, Decimal.Zero, String.Empty)

            Util.carregarCmbEmpenho(ds, ddlDVF, New ListItem(String.Empty, String.Empty))
            Util.carregarCmbEmpenho(ds, ddlDVM, New ListItem(String.Empty, String.Empty))
        End If
    End Sub

    Private Sub CarregaDDLFormaPgto()
        If Not ddlFormaPagamento.Items.Count > 0 Then
            Util.carregarCmbFormaPagamento(Controller.ObterFormasPagamento(String.Empty, -1), ddlFormaPagamento, New ListItem(String.Empty, String.Empty))
        End If
    End Sub

    Private Sub CarregaDDLMoeda()
        If Not ddlMoeda.Items.Count > 0 Then
            Dim ds As wsAcoesComerciais.DatasetMoeda = _
                        Controller.ObterMoedas(String.Empty)
            Util.carregarCmbMoeda(ds, ddlMoeda, New ListItem(String.Empty, String.Empty))
        End If
    End Sub

    Public Sub CarregaGrdClausulas(Optional ByVal RecarregaDS As Boolean = False)
        Try
            If RecarregaDS Then
                Me.Page.dsContrato.Merge(Controller.ObterContratoXClausulaContrato(Nothing, Nothing, Nothing, Decimal.Zero, Convert.ToDecimal(Me.Page.NUMCTTFRN)), False, MissingSchemaAction.Ignore)
            End If
            Me.DatasetContrato1 = Me.Page.dsContrato   '.T0124961
            grdClausulas.DataBind()
        Catch ex As Exception
            If grdClausulas.CurrentPageIndex > 0 Then
                grdClausulas.CurrentPageIndex = 0
                CarregaGrdClausulas(RecarregaDS)
            Else
                Controller.TrataErro(MyBase.Page, ex)
            End If
        End Try
    End Sub

    Private Sub CarregarJavaScript()
        cmbTIPPODCTTFRN.Attributes.Add("OnBlur", Util.getJsFocus(MyBase.Page, CType(txtTIPPODCTTFRN, WebControl), Util.tipoDeComponente.InfragisticsTxt))
        btnExcluir.Attributes.Add("OnClick", "javascript:return confirm('Deseja excluir a cláusula?')")
    End Sub

    Public Shared Sub carregarClausulaContrato(ByRef ds As wsAcoesComerciais.DatasetClausulaContrato, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetClausulaContrato.T0124953Row In ds.T0124953.Select("", "NUMCSLCTTFRN")
                If linha.NUMCSLCTTFRN <> 3 And linha.NUMCSLCTTFRN <> 10 Then
                    .Items.Add(New ListItem(Format(linha.NUMCSLCTTFRN, "0000") & " - " & linha.DESCSLCTTFRN, linha.NUMCSLCTTFRN.ToString))
                End If
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

#End Region

#Region " Metodos de Controles "

    Private Sub MudaClausula()
        txtCodClausula.Text = ddlClausula.SelectedValue
        ' Indicador de Cálculo Agrupado para Fornecedores Associados
        Me.iIndCalGrpFrnAsc = 0

        For Each ctrl As WebControl In Me.Controles()
            If ctrl.ID <> ddlClausula.ID And ctrl.ID <> txtCodClausula.ID Then
                Util.LimpaControles(New WebControl() {ctrl}, False)
            End If
        Next

        chkGeraAco.Checked = True
        chkGeraAco_CheckedChanged(Nothing, Nothing)

        'Campos que são setados com valores padrão
        txtDatVigCsl.Date = Page.DATINIPODVGRCTTFRN
        txtTipDsc.ValueDecimal = 0
        txtDiaVencAco.ValueDecimal = 15
        ddlMoeda.SelectedValue = "45"

        ' Variedade de Mix
        Dim ctrlVarMix As WebControl() = New WebControl() {txtQdeIteVarMix, txtPerIteVarMix}
        Dim ctrlLblErroVarMix As WebControl() = New WebControl() {lblErrotxtQdeIteVarMix, lblErrotxtPerIteVarMix}
        ' Aniversario
        Dim ctrlAni As WebControl() = New WebControl() {ddlDatRefApuPodCslCtt, ddlTipLimCalPod, txtQdeMesApuMedPod, txtVlrLimFatcalPod}
        Dim ctrlLblErroAni As WebControl() = New WebControl() {lblErroddlDatRefApuPodCslCtt, lblErroddlTipLimCalPod, lblErrotxtQdeMesApuMedPod, lblErrotxtVlrLimFatcalPod}
        ' Regularidade
        Dim ctrlReg As WebControl() = New WebControl() {txtQdePedPodApuCsl}
        Dim ctrlLblErroReg As WebControl() = New WebControl() {lblErrotxtQdePedPodApuCsl}
        ' Variedade de Mix
        Util.HabilitaControles(ctrlVarMix, False)
        Util.MostraControles(ctrlLblErroVarMix, False)
        ' Aniversario
        Util.HabilitaControles(ctrlAni, False)
        Util.MostraControles(ctrlLblErroAni, False)
        ' Regularidade
        Util.HabilitaControles(ctrlReg, False)
        Util.MostraControles(ctrlLblErroReg, False)

        ' Indicador de Cálculo Agrupado para Fornecedores Associados
        Me.iIndCalGrpFrnAsc = 0

        If ddlClausula.SelectedValue.Equals("5") Then ' Variedade de Mix
            Util.HabilitaControles(ctrlVarMix, True)
            Util.MostraControles(ctrlLblErroVarMix, True)
        ElseIf ddlClausula.SelectedValue.Equals("6") Or ddlClausula.SelectedValue.Equals("19") Then ' Aniversario
            Util.HabilitaControles(ctrlAni, True)
            Util.MostraControles(ctrlLblErroAni, True)
            ddlDatRefApuPodCslCtt.SelectedValue = "8"  ' Setembro
            txtQdeMesApuMedPod.Text = "1"
            ddlTipLimCalPod.SelectedValue = "1"
            txtVlrLimFatcalPod.Text = "0"
        ElseIf ddlClausula.SelectedValue.Equals("7") Then ' Regularidade
            Util.HabilitaControles(ctrlReg, True)
            Util.MostraControles(ctrlLblErroReg, True)
            txtQdePedPodApuCsl.Text = "2"
        End If

        If txtCodClausula.ValueInt.Equals(2) Then
            btnAnualidade.Enabled = True
            btnTrimestralidade.Enabled = False

            If ddlClausula.SelectedValue = "2" Then
                If cmbTIPPODCTTFRN.SelectedValue <> String.Empty Then
                    btnTrimestralidade.Enabled = (cmbTIPPODCTTFRN.SelectedValue = "1")
                End If
            End If

        Else
            btnAnualidade.Enabled = False
            btnTrimestralidade.Enabled = False
        End If


        If ddlClausula.SelectedValue = "1" Then 'Investimento Promocional
            txtPercCtaFrn.Text = "100,00"
            chkFlgDscAut.Enabled = True
        Else
            If ddlClausula.SelectedValue = "2" Then 'Bonus Crescimento
                txtPercCtaFrn.Text = "0"
                chkFlgDscAut.Enabled = False
            Else
                If ddlClausula.SelectedValue = "3" Then
                    txtPercCtaFrn.Text = "0"
                    chkFlgDscAut.Enabled = False
                End If
            End If
        End If

        If ddlClausula.SelectedValue = "1" Then
            ddlDVF.SelectedValue = "30"
            ddlDVM.SelectedValue = "30"
            txtCodDVF.ValueDecimal = 30
            txtCodDVM.ValueDecimal = 30
        ElseIf ddlClausula.SelectedValue = "2" Then
            ddlDVF.SelectedValue = "55"
            ddlDVM.SelectedValue = "55"
            txtCodDVF.ValueDecimal = 55
            txtCodDVM.ValueDecimal = 55
        ElseIf ddlClausula.SelectedValue = "3" Then
            ddlDVF.SelectedValue = "60"
            ddlDVM.SelectedValue = "60"
            txtCodDVF.ValueDecimal = 60
            txtCodDVM.ValueDecimal = 60
        ElseIf ddlClausula.SelectedValue = "5" Then
            ddlDVF.SelectedValue = "32"
            ddlDVM.SelectedValue = "32"
            txtCodDVF.ValueDecimal = 32
            txtCodDVM.ValueDecimal = 32
        ElseIf ddlClausula.SelectedValue = "6" Then
            ddlDVF.SelectedValue = "53"
            ddlDVM.SelectedValue = "53"
            txtCodDVF.ValueDecimal = 53
            txtCodDVM.ValueDecimal = 53
        ElseIf ddlClausula.SelectedValue = "7" Then
            ddlDVF.SelectedValue = "32"
            ddlDVM.SelectedValue = "32"
            txtCodDVF.ValueDecimal = 32
            txtCodDVM.ValueDecimal = 32
        ElseIf ddlClausula.SelectedValue = "8" Then
            ddlDVF.SelectedValue = "42"
            ddlDVM.SelectedValue = "42"
            txtCodDVF.ValueDecimal = 42
            txtCodDVM.ValueDecimal = 42
        ElseIf ddlClausula.SelectedValue = "9" Then
            ddlDVF.SelectedValue = "54"
            ddlDVM.SelectedValue = "54"
            txtCodDVF.ValueDecimal = 54
            txtCodDVM.ValueDecimal = 54
        ElseIf ddlClausula.SelectedValue = "10" Then
            ddlDVF.SelectedValue = "58"
            ddlDVM.SelectedValue = "58"
            txtCodDVF.ValueDecimal = 58
            txtCodDVM.ValueDecimal = 58
        ElseIf ddlClausula.SelectedValue = "11" Then
            ddlDVF.SelectedValue = "32"
            ddlDVM.SelectedValue = "32"
            txtCodDVF.ValueDecimal = 32
            txtCodDVM.ValueDecimal = 32
        ElseIf ddlClausula.SelectedValue = "12" Then
            ddlDVF.SelectedValue = "61"
            ddlDVM.SelectedValue = "61"
            txtCodDVF.ValueDecimal = 61
            txtCodDVM.ValueDecimal = 61
        ElseIf ddlClausula.SelectedValue = "19" Then
            ddlDVF.SelectedValue = "101"
            ddlDVM.SelectedValue = "101"
            txtCodDVF.ValueDecimal = 101
            txtCodDVM.ValueDecimal = 101
        End If


        If ddlFormaPagamento.SelectedValue = "2" Then
            If ddlClausula.SelectedValue = "1" Then
                txtTipDsc.Text = "10 - IPC"
            ElseIf ddlClausula.SelectedValue = "2" Then
                txtTipDsc.Text = "12 - BCC"
            ElseIf ddlClausula.SelectedValue = "3" Then
                txtTipDsc.Text = "13 - ANU"
            End If
        Else
            txtTipDsc.Text = "0"
        End If

        'Valores padrão
        If Not ddlFormaPagamento.Items.FindByValue("2") Is Nothing Then
            txtCodFormaPagamento.Text = "2"
            ddlFormaPagamento.SelectedValue = "2"
        End If
        If ddlClausula.SelectedValue.Equals("9") Then
            txtPercCtaFrn.ValueDecimal = 0
        Else
            txtPercCtaFrn.ValueDecimal = 100
        End If

        txtTipDsc.Enabled = False

    End Sub

#End Region

#Region " Metodos de Regras de Negocio "

    Private Function FCN_ValPdoClsAni(ByVal btTipoValidacao As Integer, _
                                        ByVal NumCttFrn As Decimal, _
                                        ByVal dtDatRefApuPodCslCtt As Date, _
                                        ByVal iQdeMesApuMedPod As Integer) As Boolean
        ' Valida Periodo para apuracao da media da clausula de aditamento aniversario
        ' btTipoValidacao:
        '   1 - Mês Ref. p/ Apuração
        '   2 - Qtd. Meses p/ Cálc. Média
        Dim StrSQL As String
        Dim dtAuxiliar As Date
        Dim bMensagem As Boolean
        Dim drT0124945 As wsAcoesComerciais.DatasetContrato.T0124945Row = _
            Me.Page.getContratoByNumCttFrn(NumCttFrn)

        FCN_ValPdoClsAni = False
        bMensagem = True

        If btTipoValidacao = 1 Then ' 1 - Mês Ref. p/ Apuração
            dtAuxiliar = CDate("01/" & Page.DATINIPODVGRCTTFRN.Month & "/" & Page.DATINIPODVGRCTTFRN.Year)
            Do While dtAuxiliar <= CDate("01/" & Page.DATVNCCTTFRN.Month & "/" & Page.DATVNCCTTFRN.Year)
                If Month(dtAuxiliar) = Month(dtDatRefApuPodCslCtt) Then
                    FCN_ValPdoClsAni = True
                    bMensagem = False
                    Exit Do
                End If
                dtAuxiliar = DateAdd("m", 1, dtAuxiliar)
            Loop
            If bMensagem Then
                Util.AdicionaJsAlert(MyBase.Page, "Mês Ref. p/ Apuração deve estar entre " & vbCrLf & _
                    Page.DATINIPODVGRCTTFRN.ToShortDateString() & " e " & _
                    Page.DATVNCCTTFRN.ToShortDateString() & ".")
            End If
        ElseIf btTipoValidacao = 2 Then ' 2 - Qtd. Meses p/ Cálc. Média
            Dim ds As wsAcoesComerciais.DatasetTipoPeriodo = _
                Controller.ObterTipoPeriodo(Page.TIPPODCTTFRN)
            If ds.T0124970.Rows.Count > 0 Then
                If (iQdeMesApuMedPod <= ds.T0124970.Item(0).QDEMESREFPOD) Then
                    FCN_ValPdoClsAni = True
                    bMensagem = False
                End If
            End If
            If bMensagem Then
                Util.AdicionaJsAlert(MyBase.Page, "Qtd. Meses p/ Cálc. Média não" & vbCrLf & "pode ultrapassar " & _
                    Trim(Str(ds.T0124970.Item(0).QDEMESREFPOD)) & Convert.ToString(IIf(ds.T0124970.Item(0).QDEMESREFPOD > 1, " meses.", " mês.")))
            End If
        End If
    End Function

    Private Function ValidarDados() As Boolean
        Dim result As Boolean
        Dim mensagemErro As String = String.Empty
        Dim deuFoco As Boolean

        colocaMesmoValorDosCombosNoText()

        Try
            If Page.CODFRN = 0 Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "informe o fornecedor"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(ddlClausula, WebControl))
                End If
                deuFoco = True
                lblErrotxtCodClausula.Visible = True
            Else
                lblErrotxtCodClausula.Visible = False
            End If

            If Page.DATINIPODVGRCTTFRN = Nothing Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "informe a data da vigoração do contrato"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(ddlFormaPagamento, WebControl))
                End If
                deuFoco = True
                lblErrotxtCodFormaPagamento.Visible = True
            Else
                lblErrotxtCodFormaPagamento.Visible = False
            End If

            If Page.DATVNCCTTFRN = Nothing Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "informe a data de vencimento do contrato"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(ddlMoeda, WebControl))
                End If
                deuFoco = True
                lblErroddlMoeda.Visible = True
            Else
                lblErroddlMoeda.Visible = False
            End If

            If txtCodClausula.ValueInt <= 0 Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "cláusula inválida"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(ddlClausula, WebControl))
                End If
                deuFoco = True
                lblErrotxtCodClausula.Visible = True
            Else
                lblErrotxtCodClausula.Visible = False
            End If

            If txtCodFormaPagamento.ValueInt <= 0 Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "desconto inválido"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(ddlFormaPagamento, WebControl))
                End If
                deuFoco = True
                lblErrotxtCodFormaPagamento.Visible = True
            Else
                lblErrotxtCodFormaPagamento.Visible = False
            End If

            If ddlMoeda.SelectedValue Is String.Empty AndAlso Not IsNumeric(ddlMoeda.SelectedValue) Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "moeda inválida"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(ddlMoeda, WebControl))
                End If
                deuFoco = True
                lblErroddlMoeda.Visible = True
            Else
                lblErroddlMoeda.Visible = False
            End If

            If txtCodDVF.ValueInt <= 0 Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "Destino Verba Fornecedor inválido"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(ddlDVF, WebControl))
                End If
                deuFoco = True
                lblErrotxtCodDVF.Visible = True
            Else
                lblErrotxtCodDVF.Visible = False
            End If

            If txtCodDVM.ValueInt <= 0 Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "Destino Verba Martins inválido"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(ddlDVM, WebControl))
                End If
                deuFoco = True
                lblErrotxtCodDVM.Visible = True
            Else
                lblErrotxtCodDVM.Visible = False
            End If

            If txtPercCtaFrn.ValueDecimal < 0 Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "percentual inválido"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(txtPercCtaFrn, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                End If
                deuFoco = True
                lblErrotxtPercCtaFrn.Visible = True
            Else
                lblErrotxtPercCtaFrn.Visible = False
            End If

            If txtDiaVencAco.ValueInt <= 0 Or txtDiaVencAco.ValueInt > 31 Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "dia inválido"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(txtDiaVencAco, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                End If
                deuFoco = True
                lblErrotxtDiaVencAco.Visible = True
            Else
                lblErrotxtDiaVencAco.Visible = False
            End If

            If txtDatVigCsl.Text Is String.Empty Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "data Inválida"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(txtDatVigCsl, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                End If
                deuFoco = True
                lblErrotxtDatVigCsl.Visible = True
            Else
                lblErrotxtDatVigCsl.Visible = False
            End If

            If txtCodFormaPagamento.ValueInt.Equals(2) Then
                If txtTipDsc.Text = "" Then
                    'Mensagem
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "tipo do desconto não informado"

                    If Not deuFoco Then
                        Util.AdicionaJsFocus(MyBase.Page, CType(txtTipDsc, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                    End If
                    deuFoco = True
                    lblErrotxtTipDsc.Visible = True
                Else
                    lblErrotxtTipDsc.Visible = False
                End If
            Else
                lblErrotxtTipDsc.Visible = False
            End If

            If txtCodClausula.ValueInt.Equals(5) Then  ' Variedade de Mix
                'Comentado essa validação por solicitação do Severton
                'If txtPerIteVarMix.Text.Trim Is String.Empty Or _
                '    txtPerIteVarMix.ValueInt = 0 Then
                '    'Mensagem
                '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                '    mensagemErro &= "perc. Mínimo Bonificação inválido"

                '    If Not deuFoco Then
                '        Util.AdicionaJsFocus(MyBase.Page, CType(txtPerIteVarMix, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                '    End If
                '    deuFoco = True
                '    lblErrotxtPerIteVarMix.Visible = True
                'Else
                '    lblErrotxtPerIteVarMix.Visible = False
                'End If
                lblErrotxtPerIteVarMix.Visible = False
            ElseIf txtCodClausula.ValueInt.Equals(6) Or txtCodClausula.ValueInt.Equals(19) Then  ' Aniversario
                cmbTIPPODCTTFRN.SelectedValue = "1"
                'If cmbTIPPODCTTFRN.SelectedValue <> "1" Then 'Período mensal
                '    'Mensagem
                '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                '    mensagemErro &= "tipo do Período dever ser Mensal para esta cláusula"

                '    If Not deuFoco Then
                '        Util.AdicionaJsFocus(MyBase.Page, CType(cmbTIPPODCTTFRN, WebControl))
                '    End If
                '    deuFoco = True
                '    lblErrotxtCodClausula.Visible = True
                'Else
                '    lblErrotxtCodClausula.Visible = False
                'End If

                If ddlDatRefApuPodCslCtt.SelectedIndex = 0 Then
                    'Mensagem
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "mês Ref. p/ Apuração não informado"

                    If Not deuFoco Then
                        Util.AdicionaJsFocus(MyBase.Page, CType(ddlDatRefApuPodCslCtt, WebControl))
                    End If
                    deuFoco = True
                    lblErrotxtCodClausula.Visible = True
                Else
                    lblErrotxtCodClausula.Visible = False
                End If
                If txtQdeMesApuMedPod.Text.Trim Is String.Empty Or _
                    txtQdeMesApuMedPod.ValueInt = 0 Then
                    'Mensagem
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "qtd. Meses p/ Cálc. Média inválido"

                    If Not deuFoco Then
                        Util.AdicionaJsFocus(MyBase.Page, CType(txtQdeMesApuMedPod, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                    End If
                    deuFoco = True
                    lblErrotxtQdeMesApuMedPod.Visible = True
                Else
                    lblErrotxtQdeMesApuMedPod.Visible = False
                End If
                If ddlDatRefApuPodCslCtt.SelectedIndex = 0 Then
                    If txtVlrLimFatcalPod.Text.Trim Is String.Empty Or txtVlrLimFatcalPod.ValueDecimal = 0 Then
                        'Mensagem
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "vlr. Limite p/ Cálculo inválido"

                        If Not deuFoco Then
                            Util.AdicionaJsFocus(MyBase.Page, CType(txtVlrLimFatcalPod, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                        End If
                        deuFoco = True
                        lblErroddlDatRefApuPodCslCtt.Visible = True
                    Else
                        lblErroddlDatRefApuPodCslCtt.Visible = False
                    End If
                ElseIf ddlDatRefApuPodCslCtt.SelectedValue.Equals("1") Then
                    If txtVlrLimFatcalPod.Text.Trim Is String.Empty Or txtVlrLimFatcalPod.ValueDecimal.Equals(0) Then
                        'Mensagem
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "vlr. Limite p/ Cálculo inválido"

                        If Not deuFoco Then
                            Util.AdicionaJsFocus(MyBase.Page, CType(txtVlrLimFatcalPod, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                        End If
                        deuFoco = True
                        lblErrotxtVlrLimFatcalPod.Visible = True
                    Else
                        lblErrotxtVlrLimFatcalPod.Visible = False
                    End If
                End If

                If Page.DATINIPODVGRCTTFRN = Nothing Then
                    'Mensagem
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "data de inicio do período de vigoração não informado, informe, escolha o opção salvar e continuar e tente incluir a cláusula novamente"
                End If
                If Page.TIPPODCTTFRN = 0 Then
                    'Mensagem
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "tipo de período não informado, informe, escolha o opção salvar e continuar e tente incluir a cláusula novamente"
                End If

                ' Valida Periodo para apuracao da media
                ' 1 - Mês Ref. p/ Apuração
                If Not (FCN_ValPdoClsAni(1, Convert.ToDecimal(Me.Page.NUMCTTFRN), _
                      CDate("01/" & ddlDatRefApuPodCslCtt.SelectedValue & _
                        Format(Date.Now, "/yyyy")), txtQdeMesApuMedPod.ValueInt)) Then
                    If ddlDatRefApuPodCslCtt.Enabled Then Util.AdicionaJsFocus(MyBase.Page, CType(ddlDatRefApuPodCslCtt, WebControl))
                    Exit Function
                End If
                '' 2 - Qtd. Meses p/ Cálc. Média
                If Not (FCN_ValPdoClsAni(2, Convert.ToDecimal(Me.Page.NUMCTTFRN), _
                  CDate("01/" & ddlDatRefApuPodCslCtt.SelectedValue & _
                  Format(Date.Now, "/yyyy")), txtQdeMesApuMedPod.ValueInt)) Then
                    If txtQdeMesApuMedPod.Enabled Then Util.AdicionaJsFocus(MyBase.Page, CType(txtQdeMesApuMedPod, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                    Exit Function
                End If

                'Comentado essa validação por solicitação do Severton
                'ElseIf txtCodClausula.ValueInt.Equals(3) Then  ' Anualidade
                '    'Mensagem
                '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                '    mensagemErro &= "não é permitido editar clásula de Anualidade, ela é gerada pelo sistema"

                '    If Not deuFoco Then
                '        Util.AdicionaJsFocus(MyBase.Page, CType(txtVlrLimFatcalPod, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                '    End If
                '    deuFoco = True
                '    lblErroddlDatRefApuPodCslCtt.Visible = True
                'ElseIf txtCodClausula.ValueInt.Equals(10) Then  ' Trimestralidade
                '    'Mensagem
                '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                '    mensagemErro &= "não é permitido editar clásula de Trimestralidade, ela é gerada pelo sistema"

                '    If Not deuFoco Then
                '        Util.AdicionaJsFocus(MyBase.Page, CType(txtVlrLimFatcalPod, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                '    End If
                '    deuFoco = True
                '    lblErroddlDatRefApuPodCslCtt.Visible = True

            End If

            'Mostra mensagem de erro
            If mensagemErro.Trim() <> String.Empty Then
                Page.RegisterStartupScript("Alerta", "<script>alert('" & (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1) & "');</script>")
                Return False
            End If

        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
        Return True
    End Function

    Private Function ValidarPreCondicoesParaInclusãoDeClausula() As Boolean
        Dim result As Boolean
        Dim mensagemErro As String = String.Empty

        Try
            If Page.CODFRN = 0 Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "informe o fornecedor"
            End If

            If Page.DATINIPODVGRCTTFRN = Nothing Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "informe a data da vigoração do contrato"
            End If

            If Page.DATVNCCTTFRN = Nothing Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "informe a data de vencimento do contrato"
            End If

            'Mostra mensagem de erro
            If mensagemErro.Trim() <> String.Empty Then
                Page.RegisterStartupScript("Alerta", "<script>alert('" & (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1) & "');</script>")
                Return False
            End If

        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
        Return True
    End Function

    Private Sub colocaMesmoValorDosCombosNoText()
        txtCodClausula.Text = ddlClausula.SelectedValue
        txtTIPPODCTTFRN.Text = cmbTIPPODCTTFRN.SelectedValue
        txtCodFormaPagamento.Text = ddlFormaPagamento.SelectedValue
        txtCodDVF.Text = ddlDVF.SelectedValue
        txtCodDVM.Text = ddlDVM.SelectedValue
    End Sub

    Private Sub PreencheLinhaT0124961(ByRef dr As wsAcoesComerciais.DatasetContrato.T0124961Row)
        With dr
            ' linha nova
            If dr.RowState = DataRowState.Detached Then
                .NUMCTTFRN = Convert.ToDecimal(Me.Page.NUMCTTFRN)
                .SetDATDSTCSLNull()
            End If

            .NUMCSLCTTFRN = txtCodClausula.ValueDecimal
            .TIPFRMDSCBNF = txtCodFormaPagamento.ValueDecimal
            .TIPMOE = Convert.ToDecimal(ddlMoeda.SelectedValue)
            .PERDISCNTCRRFRN = txtPercCtaFrn.ValueDecimal
            .FLGGRCACOCMC = Convert.ToString(IIf(chkGeraAco.Checked, "*", String.Empty))
            .NUMDIAVNCACOCMC = txtDiaVencAco.ValueInt

            .DESOBSREFCSL = txtObs.Text
            .DATINIVGRCSLCTTFRN = txtDatVigCsl.Date
            .TIPDSNDSCBNFFRN = txtCodDVF.ValueDecimal
            .TIPDSNDSCBNFMRT = txtCodDVM.ValueDecimal
            .FLGDSCAUTPED = Convert.ToString(IIf(chkFlgDscAut.Checked, "S", "N"))
            .TIPDSCPGTFVC = txtTipDsc.ValueDecimal
            .IndCalGrpFrnAsc = iIndCalGrpFrnAsc

            If txtCodClausula.ValueInt.Equals(5) Then
                .QdeIteVarMix = txtQdeIteVarMix.ValueInt
                .PerIteVarMix = txtPerIteVarMix.ValueInt
                .PerIteVarMix = txtPerIteVarMix.ValueInt
            Else
                .QdeIteVarMix = 0
                .PerIteVarMix = 0
                .PerIteVarMix = 0
            End If

            ' Aniversario
            If txtCodClausula.ValueInt.Equals(6) Or txtCodClausula.ValueInt.Equals(19) Then
                .DatRefApuPodCslCtt = CDate("01/" & ddlDatRefApuPodCslCtt.SelectedValue & "/" & Date.Now.Year.ToString())
                .QdeMesApuMedPod = txtQdeMesApuMedPod.ValueInt
                .VlrLimFatCalPod = txtVlrLimFatcalPod.ValueDecimal
                .TipLimCalPod = Convert.ToInt32(ddlTipLimCalPod.SelectedValue)
            Else
                .SetDatRefApuPodCslCttNull()
                .SetQdeMesApuMedPodNull()
                .SetVlrLimFatCalPodNull()
                .SetTipLimCalPodNull()
            End If

            ' Regularidade
            If txtCodClausula.ValueInt.Equals(7) Then
                .QdePedPodApuCsl = txtQdePedPodApuCsl.ValueInt
            Else
                .SetQdePedPodApuCslNull()
            End If

        End With
    End Sub

    Private Sub PreencheControles(ByRef dr As wsAcoesComerciais.DatasetContrato.T0124961Row)
        With dr
            ddlClausula.SelectedValue = .NUMCSLCTTFRN.ToString() : Me.ddlClausula_SelectedIndexChanged(Nothing, Nothing)
            ddlFormaPagamento.SelectedValue = .TIPFRMDSCBNF.ToString() : Me.ddlFormaPagamento_SelectedIndexChanged(Nothing, Nothing)
            ddlMoeda.SelectedValue = .TIPMOE.ToString()
            txtPercCtaFrn.ValueDecimal = .PERDISCNTCRRFRN

            chkGeraAco.Checked = False
            chkGeraAco.Checked = Convert.ToBoolean(IIf(.FLGGRCACOCMC.Equals("*"), True, False)) : chkGeraAco_CheckedChanged(Nothing, Nothing)

            txtDiaVencAco.ValueInt = .NUMDIAVNCACOCMC

            txtObs.Text = ""
            If Not .IsDESOBSREFCSLNull Then txtObs.Text = .DESOBSREFCSL

            txtDatVigCsl.Date = .DATINIVGRCSLCTTFRN
            If Not .IsTIPDSNDSCBNFFRNNull Then ddlDVF.SelectedValue = .TIPDSNDSCBNFFRN.ToString : ddlDVF_SelectedIndexChanged(Nothing, Nothing)
            If Not .IsTIPDSNDSCBNFMRTNull Then ddlDVM.SelectedValue = .TIPDSNDSCBNFMRT.ToString() : ddlDVM_SelectedIndexChanged(Nothing, Nothing)

            chkFlgDscAut.Checked = False
            chkFlgDscAut.Checked = Convert.ToBoolean(IIf(Not .IsFLGDSCAUTPEDNull AndAlso .FLGDSCAUTPED.Equals("S"), True, False))

            If Not .IsTIPDSCPGTFVCNull Then txtTipDsc.ValueDecimal = .TIPDSCPGTFVC
            ' Indicador de Cálculo Agrupado para Fornecedores Associados
            iIndCalGrpFrnAsc = 0
            If Not .IsIndCalGrpFrnAscNull Then
                iIndCalGrpFrnAsc = .IndCalGrpFrnAsc
            End If
            ' Variedade de Mix
            If txtCodClausula.ValueInt.Equals(5) Then
                txtQdeIteVarMix.Text = Convert.ToString(IIf(Not .IsQdeIteVarMixNull, .QdeIteVarMix, Nothing))
                txtPerIteVarMix.Text = Convert.ToString(IIf(Not .IsPerIteVarMixNull, .PerIteVarMix, Nothing))
                ' Aniversario
            ElseIf txtCodClausula.ValueInt.Equals(6) Or txtCodClausula.ValueInt.Equals(19) Then
                ddlDatRefApuPodCslCtt.SelectedValue = .DatRefApuPodCslCtt.Month.ToString()
                txtQdeMesApuMedPod.ValueInt = .QdeMesApuMedPod
                ddlTipLimCalPod.SelectedValue = .TipLimCalPod.ToString()
                txtVlrLimFatcalPod.ValueDecimal = .VlrLimFatCalPod
                ' Regularidade
            ElseIf txtCodClausula.ValueInt.Equals(7) Then
                txtQdePedPodApuCsl.ValueInt = .QdePedPodApuCsl
            End If
        End With
    End Sub

    Private Function SalvarDados() As Boolean
        SalvarDados = False

        'Pega o mesmo período informado na capa
        cmbTIPPODCTTFRN.SelectedValue = Page.TIPPODCTTFRN.ToString

        If Me.ValidarDados() Then
            If Not Me.Page.dsContrato.T0124961.FindByNUMCTTFRNNUMCSLCTTFRN(Convert.ToDecimal(Me.Page.NUMCTTFRN), txtCodClausula.ValueDecimal) Is Nothing Then
                Dim dr As wsAcoesComerciais.DatasetContrato.T0124961Row = _
                        Me.Page.dsContrato.T0124961.FindByNUMCTTFRNNUMCSLCTTFRN(Convert.ToDecimal(Me.Page.NUMCTTFRN), txtCodClausula.ValueDecimal)

                If dr.isDATDSTCSLnull Then
                    Util.AdicionaJsAlert(MyBase.Page, "Cláusula destivada, não é permitido alteração")
                End If

                Me.PreencheLinhaT0124961(dr)
            Else
                Dim dr As wsAcoesComerciais.DatasetContrato.T0124961Row = _
                                    Me.Page.dsContrato.T0124961.NewT0124961Row()
                Me.PreencheLinhaT0124961(dr)
                Me.Page.dsContrato.T0124961.AddT0124961Row(dr)
            End If
            SalvarDados = True
        End If
    End Function

    Public Function SalvarDadosDataSet() As Boolean
        ' Neste caso apenas por compatibilidade genérica
        Return True
    End Function

    Private Sub EditarClausula(ByVal NumCslCttFrn As Decimal)
        If Not Me.Page.dsContrato.T0124961.FindByNUMCTTFRNNUMCSLCTTFRN(Convert.ToDecimal(Me.Page.NUMCTTFRN), NumCslCttFrn) Is Nothing Then
            Dim dr As wsAcoesComerciais.DatasetContrato.T0124961Row = _
                            Me.Page.dsContrato.T0124961.FindByNUMCTTFRNNUMCSLCTTFRN(Convert.ToDecimal(Me.Page.NUMCTTFRN), NumCslCttFrn)
            'Me.SetPageSate(Contrato.PageState.EdicaoRegistro)
            Me.PreencheControles(dr)
            txtCodClausula.Enabled = False
            ddlClausula.Enabled = False
        End If
    End Sub

    Private Sub DesativarClausula()
        If Not Me.Page.dsContrato.T0124961.FindByNUMCTTFRNNUMCSLCTTFRN(Convert.ToDecimal(Me.Page.NUMCTTFRN), txtCodClausula.ValueDecimal) Is Nothing Then
            Dim dr As wsAcoesComerciais.DatasetContrato.T0124961Row = _
                                    Me.Page.dsContrato.T0124961.FindByNUMCTTFRNNUMCSLCTTFRN(Convert.ToDecimal(Me.Page.NUMCTTFRN), txtCodClausula.ValueDecimal)

            dr.DATDSTCSL = Date.Now
            Me.Page.SalvarEContinuar()
            Util.AdicionaJsAlert(MyBase.Page, "Desativação realizada com sucesso.")
        End If
    End Sub

    Private Sub ExcluirClausula()
        If Not Me.Page.dsContrato.T0124961.FindByNUMCTTFRNNUMCSLCTTFRN(Convert.ToDecimal(Me.Page.NUMCTTFRN), txtCodClausula.ValueDecimal) Is Nothing Then
            Dim dr As wsAcoesComerciais.DatasetContrato.T0124961Row = _
                                    Me.Page.dsContrato.T0124961.FindByNUMCTTFRNNUMCSLCTTFRN(Convert.ToDecimal(Me.Page.NUMCTTFRN), txtCodClausula.ValueDecimal)

            ''Validação se existe abrangencia
            'If dr.GetT0124996Rows.Length > 0 Then
            '    Util.AdicionaJsAlert(MyBase.Page, "Exclusão não permitida, existe abrangencia cadastrada essa cláusula")
            '    Exit Sub
            'End If

            'Excluir a cláusulas e as tabelas relacionadas
            dr.Delete()

            For Each ctrl As WebControl In Me.Controles()
                Util.LimpaControles(New WebControl() {ctrl}, False)
            Next

            Me.Page.SalvarEContinuar()
        End If
    End Sub

    Private Function TrimestralidadeAnualidadePermitida(ByVal tipo As Integer) As Boolean
        Dim dt As wsAcoesComerciais.DatasetTrimestralidadeAnualidade.tbTrimestralidadeAnualidadePermitidaDataTable = Controller.ObterTrimestralidadeAnualidadePermitida(Me.Page.NUMCTTFRN).tbTrimestralidadeAnualidadePermitida
        Dim Aprovou_Cadastro As Boolean

        If dt.Rows.Count > 0 Then
            With dt.Item(0)
                If .QdeMesPodCtt <= .QdeMesPodCsl Then
                    Aprovou_Cadastro = False
                    TrimestralidadeAnualidadePermitida = False
                    If tipo = 1 Then
                        Util.AdicionaJsAlert(MyBase.Page, "Cláusula Trimestralidade só é aplicável se o bônus for calculado por " & _
                                               "um período inferior ao contrato.")
                    Else
                        Util.AdicionaJsAlert(MyBase.Page, "Cláusula Anualidade só é aplicável se o bônus for calculado por " & _
                           "um período inferior ao contrato.")
                    End If

                Else
                    TrimestralidadeAnualidadePermitida = True
                End If

                If Aprovou_Cadastro Then
                    If .FlgApuPodAnt.Equals("*") Then
                        TrimestralidadeAnualidadePermitida = False
                        If tipo = 1 Then
                            Util.AdicionaJsAlert(MyBase.Page, "Cláusula Trimestralidade não é aplicável quando o bônus for calculado " & _
                            "com relação ao período anterior.")
                        Else
                            Util.AdicionaJsAlert(MyBase.Page, "Cláusula Anualidade não é aplicável quando o bônus for calculado " & _
                            "com relação ao período anterior.")
                        End If
                    Else
                        TrimestralidadeAnualidadePermitida = True
                    End If
                End If
            End With
        Else
            TrimestralidadeAnualidadePermitida = False
        End If

    End Function

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

    Private Function consultarTipoPeriodo(ByVal tipPeriodo As Integer) As String
        Select Case tipPeriodo
            Case 1
                Return "MENSAL"
            Case 2
                Return "TRIMESTRAL"
            Case 3
                Return "SEMESTRAL"
            Case 4
                Return "ANUAL"
            Case Else
                Return "OUTROS"
        End Select

    End Function

#End Region

#End Region

End Class