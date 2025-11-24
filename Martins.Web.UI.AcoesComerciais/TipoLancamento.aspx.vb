Public Class TipoLancamento
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dsTipoLancamentoContaCorrenteFornecedor = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor
        CType(Me.dsTipoLancamentoContaCorrenteFornecedor, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'dsTipoLancamentoContaCorrenteFornecedor
        '
        Me.dsTipoLancamentoContaCorrenteFornecedor.DataSetName = "DatasetTipoLancamentoContaCorrenteFornecedor"
        Me.dsTipoLancamentoContaCorrenteFornecedor.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.dsTipoLancamentoContaCorrenteFornecedor, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtCodTipLmt As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtDesTipLmt As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents chkFlgLmtMan As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkFlgGrcLmtCtb As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkIndTipLmtDspFrn As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtDesTipLmtFrn As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents chkIndTipLmtStn As System.Web.UI.WebControls.CheckBox
    Protected WithEvents dsTipoLancamentoContaCorrenteFornecedor As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor
    Protected WithEvents cmbFillial As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtContaDebito As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents txtCCDebito As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents txtContaCredito As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents txtCCCredito As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents cmbTipoLancamentoAssoc As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lkbAssociar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents grdAssociacao As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents tblAssociacao As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents txtCodHistPadrao As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtCodFato As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtCodEvento As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents lkbAtualizarParamContab As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label

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

    Private ControlesTiposLanc As WebControl()
    Private ControlesParamContabil As WebControl()
    Private ControlesAssociacao As WebControl()

#End Region

#Region " Eventos "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.InicializaPagina()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        Me.SalvaEstado()
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            AtualizarTipoLancamento()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("TipoLancamentoListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
    End Sub

    Private Sub lkbAssociar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkbAssociar.Click
        If chkIndTipLmtStn.Checked Then
            If cmbTipoLancamentoAssoc.Items.Count > 0 AndAlso cmbTipoLancamentoAssoc.SelectedIndex > 0 Then
                Me.EfetivaAssociacaoTipoLancamento(txtCodTipLmt.ValueDecimal, Convert.ToDecimal(cmbTipoLancamentoAssoc.SelectedValue))
                Me.CarregaGridAssociacao(txtCodTipLmt.ValueDecimal)
            End If
        Else
            Page.RegisterStartupScript("Alerta", "<script>alert('Você deve selecionar este lançamento como Sintético primeiro!');</script>")
        End If
    End Sub

    Private Sub chkIndTipLmtDspFrn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIndTipLmtDspFrn.CheckedChanged
        txtDesTipLmtFrn.Enabled = chkIndTipLmtDspFrn.Checked
        If Not chkIndTipLmtDspFrn.Checked Then
            txtDesTipLmtFrn.Text = String.Empty
        End If
    End Sub

    Private Sub chkFlgGrcLmtCtb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFlgGrcLmtCtb.CheckedChanged
        ' LANCAMENTO CONTABIL
        Me.HabilitaControles(Me.ControlesParamContabil, chkFlgGrcLmtCtb.Checked)
        If chkFlgGrcLmtCtb.Checked Then Me.CarregaComboFilial()
        Me.CarregaParametrosContabeis()
    End Sub

    Private Sub chkIndTipLmtStn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIndTipLmtStn.CheckedChanged
        ' LANCAMENTO SINTETICO
        tblAssociacao.Visible = chkIndTipLmtStn.Checked
        Me.HabilitaControles(Me.ControlesAssociacao, chkIndTipLmtStn.Checked)
        If chkIndTipLmtStn.Checked Then Me.CarregaComboTipoLancamento()
    End Sub

    Private Sub grdAssociacao_ItemCommand(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.UltraWebGridCommandEventArgs) Handles grdAssociacao.ItemCommand
        If e.InnerCommandEventArgs.CommandName.Equals("cnExcluir") _
                AndAlso IsNumeric(e.InnerCommandEventArgs.CommandArgument) _
                AndAlso Convert.ToDecimal(e.InnerCommandEventArgs.CommandArgument) > 0 Then
            Me.EfetivaExclusaoTipoLancamento(txtCodTipLmt.ValueDecimal, Convert.ToDecimal(e.InnerCommandEventArgs.CommandArgument))
            Me.CarregaGridAssociacao(txtCodTipLmt.ValueDecimal)
        End If
    End Sub

    Private Sub cmbFillial_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFillial.SelectedIndexChanged
        If cmbFillial.Items.Count > 0 AndAlso cmbFillial.SelectedIndex > 0 Then
            '            Me.CarregaParametrosContabeis()
            Me.PopulaControlesParamContabil(dsTipoLancamentoContaCorrenteFornecedor.T0123094.FindByCODTIPLMTCODFILEMP(txtCodTipLmt.ValueDecimal, Convert.ToDecimal(cmbFillial.SelectedValue)))
        End If
    End Sub

    Private Sub lkbAtualizarParamContab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkbAtualizarParamContab.Click
        Me.SalvarParametrosContabeis()
    End Sub

#End Region

#Region " Metodos "

#Region " Métodos de Carga "

    Private Sub InicializaPagina()

        ' agrupa controles tipos lanc
        Me.ControlesTiposLanc = New WebControl() {txtCodTipLmt, txtDesTipLmt, chkFlgGrcLmtCtb, chkFlgLmtMan, _
                                chkIndTipLmtDspFrn, chkIndTipLmtStn, txtDesTipLmtFrn}
        ' agrupa controles de parametros contabeis
        Me.ControlesParamContabil = New WebControl() {cmbFillial, txtContaDebito, txtContaCredito, _
                                    txtCodHistPadrao, txtCodFato, txtCCCredito, txtCCDebito, txtCodEvento}
        ' agrupa controles da associacao
        Me.ControlesAssociacao = New WebControl() {cmbTipoLancamentoAssoc, lkbAssociar, grdAssociacao}

        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If

        If (Not Me.IsPostBack) Then

            Me.HabilitaControles(Me.ControlesTiposLanc, True) : txtDesTipLmt.Enabled = False
            Me.HabilitaControles(Me.ControlesAssociacao, False)
            Me.HabilitaControles(Me.ControlesParamContabil, False)

            Me.CargaInicialDados()
        Else
            Me.RecuperaEstado()
        End If
    End Sub

    Private Sub RecuperaEstado()
        If Not Session.Item(dsTipoLancamentoContaCorrenteFornecedor.DataSetName) Is Nothing Then _
            dsTipoLancamentoContaCorrenteFornecedor = DirectCast(Session.Item(dsTipoLancamentoContaCorrenteFornecedor.DataSetName), wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor)
    End Sub

    Private Sub SalvaEstado()
        If Not dsTipoLancamentoContaCorrenteFornecedor Is Nothing Then _
            Session.Add(dsTipoLancamentoContaCorrenteFornecedor.DataSetName, dsTipoLancamentoContaCorrenteFornecedor)
    End Sub

    Private Sub CargaInicialDados()
        ' CARREGA OS DADOS PARA TRABALHAR COM OS TIPOS E SEUS RELACIONAMENTOS
        Try
            dsTipoLancamentoContaCorrenteFornecedor = Controller.ObterTiposLancamentoContaCorrenteFornecedor(String.Empty, String.Empty)
            dsTipoLancamentoContaCorrenteFornecedor.Merge(Controller.ObterTipoLancamentoPrincipalXTipoLancamentoAssociado(0, 0), False, MissingSchemaAction.Ignore)
            dsTipoLancamentoContaCorrenteFornecedor.EnforceConstraints = True

            Me.CarregaComboFilial()


        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

        'Obtem o tipo de lançamento
        If Not (Request.QueryString("CodTipLmt") Is Nothing) Then
            ObterTipoLancamentoContaCorrenteFornecedor(Decimal.Parse(Request.QueryString("CodTipLmt")))
        Else
            ' NOVO REGISTRO
            Me.InicializaNovoRegistro()
        End If

        Me.HabilitaControles(Me.ControlesParamContabil, chkFlgGrcLmtCtb.Checked)
        Me.CarregaParametrosContabeis()
    End Sub

    Private Sub InicializaNovoRegistro()
        Dim dr As wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor.T0123108Row = _
                dsTipoLancamentoContaCorrenteFornecedor.T0123108.NewT0123108Row()
        Me.PreencheLinhaDSTipoLancamento(dr)
        dsTipoLancamentoContaCorrenteFornecedor.T0123108.AddT0123108Row(dr)
        Me.PopulaControlesTipoLancamento(dr)
    End Sub

    Private Sub ObterTipoLancamentoContaCorrenteFornecedor(ByVal CodTipLmt As Decimal)
        If Not dsTipoLancamentoContaCorrenteFornecedor.T0123108.FindByCODTIPLMT(CodTipLmt) Is Nothing Then
            Me.PopulaControlesTipoLancamento(dsTipoLancamentoContaCorrenteFornecedor.T0123108.FindByCODTIPLMT(CodTipLmt))
            Me.CarregaGridAssociacao(CodTipLmt)
        End If
    End Sub

    Private Sub CarregaComboTipoLancamento()
        Util.carregarCmbTipoLancamento(dsTipoLancamentoContaCorrenteFornecedor, cmbTipoLancamentoAssoc, New ListItem(String.Empty, "0"))
    End Sub

    Private Sub CarregaComboFilial()
        Try
            Util.carregarCmbFilial(Controller.ObterFiliaisExpedicao(1), cmbFillial, New ListItem(String.Empty, "0"))
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub CarregaGridAssociacao(ByVal CodTipLmt As Decimal)
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("CÓDIGO", GetType(System.Decimal)))
        dt.Columns.Add(New DataColumn("DESCRIÇÃO", GetType(System.String)))
        For Each drAssoc As wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor.T0162251Row In _
            dsTipoLancamentoContaCorrenteFornecedor.T0162251.Select("CODTIPLMTPCP = " & CodTipLmt & _
                                                                    " AND CODTIPLMTASC <> " & CodTipLmt)
            If Not dsTipoLancamentoContaCorrenteFornecedor.T0123108.FindByCODTIPLMT(drAssoc.CODTIPLMTASC) Is Nothing Then
                With dsTipoLancamentoContaCorrenteFornecedor.T0123108.FindByCODTIPLMT(drAssoc.CODTIPLMTASC)
                    Dim r As DataRow = dt.NewRow()
                    r.Item(0) = .CODTIPLMT
                    r.Item(1) = .DESTIPLMT
                    dt.Rows.Add(r)
                End With
            End If
        Next
        grdAssociacao.DataSource = dt
        grdAssociacao.DataBind()
    End Sub

    Private Sub CarregaParametrosContabeis()
        If txtCodTipLmt.Text.Trim() <> String.Empty Then
            For Each lstItem As ListItem In cmbFillial.Items
                If IsNumeric(lstItem.Value) AndAlso _
                    dsTipoLancamentoContaCorrenteFornecedor.T0123094.FindByCODTIPLMTCODFILEMP(txtCodTipLmt.ValueDecimal, Convert.ToDecimal(lstItem.Value)) Is Nothing _
                    And txtCodTipLmt.ValueDecimal > 0 Then
                    dsTipoLancamentoContaCorrenteFornecedor.Merge(Controller.ObterParametroContabilContaCorrenteFornecedor(Convert.ToDecimal(lstItem.Value), txtCodTipLmt.ValueDecimal), False, MissingSchemaAction.Ignore)
                End If
            Next
        End If
    End Sub

#End Region

#Region " Metodos de Controles "

    Private Sub PopulaControlesTipoLancamento(ByRef dr As wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor.T0123108Row)
        With dr
            Me.LimpaControles(Me.ControlesTiposLanc)
            Me.HabilitaControles(Me.ControlesTiposLanc, True)

            txtCodTipLmt.Text = .CODTIPLMT.ToString()
            txtDesTipLmt.Text = .DESTIPLMT

            If Not .IsDESTIPLMTFRNNull Then txtDesTipLmtFrn.Text = .DESTIPLMTFRN
            If .FLGGRCLMTCTB = "S" Then chkFlgGrcLmtCtb.Checked = True
            If .FLGLMTMAN = "S" Then
                chkFlgLmtMan.Checked = True
                Me.chkFlgGrcLmtCtb_CheckedChanged(Nothing, Nothing)
            End If
            If Not .IsINDTIPLMTDSPFRNNull AndAlso .INDTIPLMTDSPFRN = 1 Then chkIndTipLmtDspFrn.Checked = True
            If Not .IsINDTIPLMTSTNNull AndAlso .INDTIPLMTSTN = 1 Then
                chkIndTipLmtStn.Checked = True
                tblAssociacao.Visible = True
                Me.HabilitaControles(Me.ControlesAssociacao, True)
                Me.CarregaComboTipoLancamento()
            End If
        End With
    End Sub

    Private Sub PopulaControlesParamContabil(ByRef dr As wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor.T0123094Row)
        If Not dr Is Nothing Then
            With dr
                txtContaDebito.Text = .CODCNTDEB.ToString()
                txtContaCredito.Text = .CODCNTCRD.ToString()
                txtCodHistPadrao.Text = .CODHSTPAD
                txtCodFato.Text = .CODFTOCTB.ToString()
                txtCCDebito.Text = .CODCENCSTDEB.ToString()
                txtCCCredito.Text = .CODCENCSTCRD.ToString()
                txtCodEvento.Text = .CODEVTCTB.ToString()
            End With
        Else
            Dim TempArray As WebControl() = Me.ControlesParamContabil
            ' cmbFilial, não pode limpar
            TempArray.SetValue(Nothing, 0)
            Me.LimpaControles(TempArray)
        End If
    End Sub

    Private Sub LimpaControles(ByVal ctrls As WebControl())
        For Each ctrl As WebControl In ctrls
            If TypeOf ctrl Is DropDownList Then
                DirectCast(ctrl, DropDownList).Items.Clear()
            ElseIf TypeOf ctrl Is TextBox Then
                DirectCast(ctrl, TextBox).Text = String.Empty
            ElseIf TypeOf ctrl Is CheckBox Then
                DirectCast(ctrl, CheckBox).Checked = False
            ElseIf TypeOf ctrl Is Infragistics.WebUI.WebDataInput.WebTextEdit Then
                DirectCast(ctrl, Infragistics.WebUI.WebDataInput.WebTextEdit).Text = String.Empty
            ElseIf TypeOf ctrl Is Infragistics.WebUI.WebDataInput.WebNumericEdit Then
                DirectCast(ctrl, Infragistics.WebUI.WebDataInput.WebNumericEdit).Text = String.Empty
            ElseIf TypeOf ctrl Is Infragistics.WebUI.UltraWebGrid.UltraWebGrid Then
                DirectCast(ctrl, Infragistics.WebUI.UltraWebGrid.UltraWebGrid).Rows.Clear()
            End If
        Next
    End Sub

    Private Sub HabilitaControles(ByVal ctrls As WebControl(), ByVal flag As Boolean)
        For Each ctrl As WebControl In ctrls
            If TypeOf ctrl Is DropDownList Then
                ctrl.Enabled = flag
            ElseIf TypeOf ctrl Is TextBox Then
                ctrl.Enabled = flag
            ElseIf TypeOf ctrl Is CheckBox Then
                ctrl.Enabled = flag
            ElseIf TypeOf ctrl Is LinkButton Then
                ctrl.Enabled = flag
            ElseIf TypeOf ctrl Is Infragistics.WebUI.WebDataInput.WebTextEdit Then
                ctrl.Enabled = flag
            ElseIf TypeOf ctrl Is Infragistics.WebUI.WebDataInput.WebNumericEdit Then
                ctrl.Enabled = flag
            ElseIf TypeOf ctrl Is Infragistics.WebUI.UltraWebGrid.UltraWebGrid Then
                ctrl.Enabled = flag
            End If
        Next
    End Sub

#End Region

#Region " Metodos de Regras de Negocio "

    Private Function ValidarAssociacaoTipoLancamento(ByVal CodTipLancPrinc As Decimal, ByVal CodTipLancAssoc As Decimal) As Boolean
        ' VERIFICA SE O LANCAMENTO PRINCIPAL JÁ TEM UMA OUTRA ASSOCIACAO QUALQUER
        ' SOH É VÁLIDA SE FOR A PRIMEIRA ASSOCIAÇÃO
        If dsTipoLancamentoContaCorrenteFornecedor.T0162251.Select("CODTIPLMTASC = " & CodTipLancPrinc.ToString()).Length() > 0 _
                And grdAssociacao.Rows.Count = 0 Then
            Page.RegisterStartupScript("Alerta", "<script>alert('Associação não permitida! Lançamento principal está associado a outro lançamento!!');</script>")
            Return False
        End If
        ' VERIFICA SE O TIPO ASSOCIADO JÁ ESTEJA ASSOCIADO COM ELE MESMO
        If dsTipoLancamentoContaCorrenteFornecedor.T0162251.Select("CODTIPLMTPCP = " & CodTipLancAssoc.ToString() & _
                                                                   " AND CODTIPLMTASC = " & CodTipLancAssoc.ToString()).Length() > 0 Then
            Page.RegisterStartupScript("Alerta", "<script>alert('Associação não permitida! Tipo de Lançamento já possui associação com ele mesmo!!');</script>")
            Return False
        End If
        ' VERIFICA SE O TIPO ASSOCIADO JÁ ESTEJA ASSOCIADO COM O TIPO PRINCIPAL
        If dsTipoLancamentoContaCorrenteFornecedor.T0162251.Select("CODTIPLMTPCP = " & CodTipLancPrinc.ToString() & _
                                                                   " AND CODTIPLMTASC = " & CodTipLancAssoc.ToString()).Length() > 0 Then
            Page.RegisterStartupScript("Alerta", "<script>alert('Associação já cadastrada!!');</script>")
            Return False
        End If
        Return True
    End Function

    Private Sub EfetivaAssociacaoTipoLancamento(ByVal CodTipLancPrinc As Decimal, ByVal CodTipLancAssoc As Decimal)
        If Me.ValidarAssociacaoTipoLancamento(CodTipLancPrinc, CodTipLancAssoc) Then
            If Not dsTipoLancamentoContaCorrenteFornecedor.T0162251.AddT0162251Row(dsTipoLancamentoContaCorrenteFornecedor.T0123108.FindByCODTIPLMT(CodTipLancPrinc), CodTipLancAssoc) Is Nothing Then
                Page.RegisterStartupScript("Alerta", "<script>alert('Registro incluído com sucesso!!');</script>")
            Else
                Page.RegisterStartupScript("Alerta", "<script>alert('Erro ao incluir registro!!');</script>")
            End If
        End If
    End Sub

    Private Sub EfetivaExclusaoTipoLancamento(ByVal CodTipLancPrinc As Decimal, ByVal CodTipLancAssoc As Decimal)
        dsTipoLancamentoContaCorrenteFornecedor.T0162251.RemoveT0162251Row(dsTipoLancamentoContaCorrenteFornecedor.T0162251.FindByCODTIPLMTPCPCODTIPLMTASC(CodTipLancPrinc, CodTipLancAssoc))
        Page.RegisterStartupScript("Alerta", "<script>alert('Registro excluído com sucesso!!');</script>")
    End Sub

    Private Sub SalvarParametrosContabeis()
        If cmbFillial.Items.Count > 0 AndAlso cmbFillial.SelectedIndex > 0 AndAlso IsNumeric(cmbFillial.SelectedValue) Then
            'If Not txtContaCredito.Text.Trim() Is String.Empty Or _
            '    Not txtContaDebito.Text.Trim() Is String.Empty Or _
            '    Not txtCodHistPadrao.Text.Trim() Is String.Empty Or _
            '    Not txtCodFato.Text.Trim() Is String.Empty Or _
            '    Not txtCCDebito.Text.Trim() Is String.Empty Or _
            '    Not txtCCCredito.Text.Trim() Is String.Empty Or _
            '    Not txtCodEvento.Text.Trim() Is String.Empty Then

            ' novo
            If dsTipoLancamentoContaCorrenteFornecedor.T0123094.FindByCODTIPLMTCODFILEMP(txtCodTipLmt.ValueDecimal, Convert.ToDecimal(cmbFillial.SelectedValue)) Is Nothing Then
                Dim dr As wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor.T0123094Row = _
                                                    dsTipoLancamentoContaCorrenteFornecedor.T0123094.NewT0123094Row()
                Me.PreencheLinhaDSParamContabeis(dr)
                dsTipoLancamentoContaCorrenteFornecedor.T0123094.AddT0123094Row(dr)
            Else
                ' edição
                Me.PreencheLinhaDSParamContabeis(dsTipoLancamentoContaCorrenteFornecedor.T0123094.FindByCODTIPLMTCODFILEMP(txtCodTipLmt.ValueDecimal, Convert.ToDecimal(cmbFillial.SelectedValue)))
            End If

            'Else
            '    Page.RegisterStartupScript("Alerta", "<script>alert('Por favor, preencher todos os campos!');</script>")
            'End If
            SalvaEstado()
        Else
            Page.RegisterStartupScript("Alerta", "<script>alert('Selecione uma filial!');</script>")
        End If
    End Sub

    Private Sub PreencheLinhaDSTipoLancamento(ByRef dr As wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor.T0123108Row)
        With dr
            .DESTIPLMT = txtDesTipLmt.Text
            If txtDesTipLmtFrn.Text.Trim() Is String.Empty Then : .SetDESTIPLMTFRNNull()
            Else : .DESTIPLMTFRN = txtDesTipLmtFrn.Text.Trim() : End If
            If chkFlgGrcLmtCtb.Checked Then : .FLGGRCLMTCTB = "S"
            Else : .FLGGRCLMTCTB = "N" : End If
            If chkFlgLmtMan.Checked Then : .FLGLMTMAN = "S"
            Else : .FLGLMTMAN = "N" : End If
            If chkIndTipLmtDspFrn.Checked Then : .INDTIPLMTDSPFRN = 1
            Else : .INDTIPLMTDSPFRN = 0 : .DESTIPLMTFRN = String.Empty : End If
            If chkIndTipLmtStn.Checked Then : .INDTIPLMTSTN = 1
            Else : .INDTIPLMTSTN = 0 : End If
        End With
    End Sub

    Private Sub PreencheLinhaDSParamContabeis(ByRef dr As wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor.T0123094Row)
        With dr
            .CODTIPLMT = txtCodTipLmt.ValueDecimal
            .CODFILEMP = Convert.ToDecimal(cmbFillial.SelectedValue)
            .CODCNTDEB = txtContaDebito.Text
            .CODCNTCRD = txtContaCredito.Text
            .CODHSTPAD = txtCodHistPadrao.Text
            .CODFTOCTB = Convert.ToDecimal(txtCodFato.Text)
            .CODCENCSTDEB = txtCCDebito.Text
            .CODCENCSTCRD = txtCCCredito.Text
            .CODEVTCTB = Convert.ToDecimal(txtCodEvento.Text)
        End With
    End Sub

#End Region

    Private Function Validar() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = String.Empty

        Try
            Validar = True

            If mensagemErro <> String.Empty Then
                lblErro.Visible = True
                lblErro.Text = (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1)
                Return False
            End If
            lblErro.Visible = False
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Function EfetuarValidacaoLancamento() As Boolean
        If txtDesTipLmt.Text.Trim() Is String.Empty Then
            Page.RegisterStartupScript("Alerta", "<script>alert('Informe a descrição para o tipo de lançamento.');</script>")
            Return False
        End If
        'If chkFlgGrcLmtCtb.Checked AndAlso cmbFillial.Items.Count - 1 <> dsTipoLancamentoContaCorrenteFornecedor.T0123094.Rows.Count Then
        '    Page.RegisterStartupScript("Alerta", "<script>alert('Informe parâmetros contábeis para todas as Filiais!.');</script>")
        '    Return False
        'End If
        Return True
    End Function

    Private Sub AtualizarTipoLancamento()
        Try
            RecuperaEstado()
            If Not EfetuarValidacaoLancamento() Then Exit Sub

            If Not dsTipoLancamentoContaCorrenteFornecedor.T0123108.FindByCODTIPLMT(txtCodTipLmt.ValueDecimal) Is Nothing Then
                'Update
                Dim dr As wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor.T0123108Row = _
                    dsTipoLancamentoContaCorrenteFornecedor.T0123108.FindByCODTIPLMT(txtCodTipLmt.ValueDecimal)
                Me.PreencheLinhaDSTipoLancamento(dr)
            End If

            Controller.AtualizarTipoLancamentoContaCorrenteFornecedor(dsTipoLancamentoContaCorrenteFornecedor)

            Me.Response.Redirect("TipoLancamentoListar.aspx")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

    Private Sub grdAssociacao_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.UltraWebGrid.LayoutEventArgs) Handles grdAssociacao.InitializeLayout

    End Sub
End Class