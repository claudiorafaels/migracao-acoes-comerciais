Public Class ucContratoFaixa
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
    Protected WithEvents ddlClausula As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtClausula As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents ddlEntidade As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtEntidade As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtAbrangencia As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents ddlAbrangencia As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtPer As Infragistics.WebUI.WebDataInput.WebPercentEdit
    Protected WithEvents lblErroddlClausula As System.Web.UI.WebControls.Label
    Protected WithEvents lblErrotxtPer As System.Web.UI.WebControls.Label
    Protected WithEvents lblErroddlAbrangencia As System.Web.UI.WebControls.Label
    Protected WithEvents LblErroddlEntidade As System.Web.UI.WebControls.Label
    Protected WithEvents cmdNova As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErrotxtDatIniUtzPmt As System.Web.UI.WebControls.Label
    Protected WithEvents cmdAtualizar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents grdFaixa As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetContrato1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContrato
    Protected WithEvents txtVlrRec As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtVlrFxa As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents lblErrotxtVlrFxa As System.Web.UI.WebControls.Label
    Private mbSeleciona As Integer = -1
    Protected WithEvents cmdExcluir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents TD1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD2 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD3 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD4 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents txtCODFXAAVL As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmbDatIniUtzPmt As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDatIniUtzPmt As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents ddl1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblErrotxtVlrRec As System.Web.UI.WebControls.Label
    Protected WithEvents cmbTipoFaixa As System.Web.UI.WebControls.DropDownList

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region " Enumerador "

    Private Enum TipoValorFaixaEnum
        TipoValorFaixaPorPercentual = 1
        TipoValorFaixaPorValor = 2
    End Enum

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
            Return New WebControl() {txtClausula, _
                                     ddlClausula, _
                                     txtAbrangencia, _
                                     ddlAbrangencia, _
                                     txtEntidade, _
                                     ddlEntidade, _
                                     txtDatIniUtzPmt, _
                                     txtVlrFxa, _
                                     txtVlrRec, _
                                     txtPer}
        End Get
    End Property

    Private Property bSeleciona() As Boolean
        Get
            Dim result As Boolean
            If Not ViewState("bSeleciona") Is Nothing Then
                result = CType(ViewState("bSeleciona"), Boolean)
            Else
                result = False
            End If
            Return result
        End Get
        Set(ByVal Value As Boolean)
            If Value = True Then
                mbSeleciona = 1
            Else
                mbSeleciona = 0
            End If
            ViewState("bSeleciona") = Value
        End Set
    End Property

    'Property valor() As Decimal
    '    Get
    '        Dim result As Decimal = Decimal.Zero
    '        If Not ViewState("valor") Is Nothing Then
    '            result = CType(ViewState("valor"), Decimal)
    '        End If
    '        Return result
    '    End Get
    '    Set(ByVal Value As Decimal)
    '        ViewState("valor") = Value
    '    End Set
    'End Property

    Private ReadOnly Property CODEDEABGMIX() As Decimal
        Get
            Dim result As Decimal

            If IsNumeric(ddlEntidade.SelectedValue) Then
                result = Convert.ToDecimal(ddlEntidade.SelectedValue)
            Else
                result = Page.CODFRN
            End If
            Return result
        End Get
    End Property

    Private ReadOnly Property TipoValorFaixa() As TipoValorFaixaEnum
        Get
            Dim result As TipoValorFaixaEnum = TipoValorFaixaEnum.TipoValorFaixaPorPercentual
            Select Case cmbTipoFaixa.SelectedValue
                Case "1"
                    result = TipoValorFaixaEnum.TipoValorFaixaPorPercentual
                Case "2"
                    result = TipoValorFaixaEnum.TipoValorFaixaPorValor
                Case Else
                    result = TipoValorFaixaEnum.TipoValorFaixaPorPercentual
            End Select
            Return result
        End Get
    End Property

#End Region

#Region " Eventos "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not IsPostBack Then
                CarregaControles()
                txtVlrFxa.Text.Format("###,###,##0.00")
                txtVlrRec.Text.Format("###,###,##0.00")
            End If
            'cmdAtualizar.Attributes.Add("OnClick", "javascript:return confirm('Incluir parâmetros no histórico?')")
            cmdExcluir.Attributes.Add("OnClick", "javascript:return confirm('Deseja excluir esse registro ?')")
            TD1.Visible = False
            TD2.Visible = False
            TD3.Visible = False
            TD4.Visible = False
            'Desabilitado a edição data data de inicio por solicitação da Elisangela e Severto em 07/02/2007
            txtDatIniUtzPmt.Value = Page.DATINIPODVGRCTTFRN
            txtDatIniUtzPmt.ReadOnly = True
            cmbDatIniUtzPmt.Enabled = False
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub cmdNova_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNova.Click
        Try
            CarregaControles()
            preenche_ComboData()
            Util.AdicionaJsFocus(MyBase.Page, CType(txtClausula, WebControl), Util.tipoDeComponente.InfragisticsTxt)

            Dim ctrlLblErro As WebControl() = New WebControl() {LblErroddlEntidade, _
                                                                lblErroddlAbrangencia, _
                                                                LblErroddlEntidade, _
                                                                lblErrotxtDatIniUtzPmt, _
                                                                lblErrotxtVlrFxa, _
                                                                lblErrotxtVlrRec, _
                                                                lblErrotxtPer}
            'Limpar controles
            For Each ctrl As WebControl In Me.Controles()
                Util.LimpaControles(New WebControl() {ctrl}, False)
            Next

            Util.MostraControles(ctrlLblErro, True)
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        Try
            If Page.flagContratoAtivo = False Then
                Util.AdicionaJsAlert(MyBase.Page, "Esse contrato não está ativo")
                Exit Sub
            End If
            If Me.SalvarDados() Then
                'Limpar controles
                For Each ctrl As WebControl In Me.Controles()
                    Util.LimpaControles(New WebControl() {ctrl}, False)
                Next
                txtVlrRec.Text = ""
                txtPer.Text = ""

                cmdNova_Click(sender, e)
            End If
            preenche_ComboData()
            Me.CarregaGrdFaixa(grdFaixa.CurrentPageIndex)
            Util.AdicionaJsFocus(MyBase.Page, CType(ddl1, System.web.UI.WebControls.WebControl))
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        Dim linha As wsAcoesComerciais.DatasetContrato.T0125038Row

        If Page.flagContratoAtivo = False Then
            Util.AdicionaJsAlert(MyBase.Page, "Esse contrato não está ativo")
            Exit Sub
        End If

        Try
            linha = Page.dsContrato.T0125038.FindByNUMCTTFRNNUMCSLCTTFRNTIPEDEABGMIXCODEDEABGMIXCODFXAAVLDATREFINIUTZPMT(Page.NUMCTTFRN, _
                                            Convert.ToDecimal(ddlClausula.SelectedValue), _
                                            Convert.ToDecimal(ddlAbrangencia.SelectedValue), _
                                            CODEDEABGMIX, _
                                            Convert.ToDecimal(txtCODFXAAVL.Text), _
                                            Convert.ToDateTime(cmbDatIniUtzPmt.SelectedValue))
        Catch ex As Exception
            Util.AdicionaJsAlert(MyBase.Page, "Selecione uma linha no grid antes de excluir")
        End Try

        If linha Is Nothing Then
            Util.AdicionaJsAlert(MyBase.Page, "Linha não encontrada")
            Exit Sub
        End If

        If linha.RowState = DataRowState.Added Then
            Page.dsContrato.T0125038.RemoveT0125038Row(linha)
        Else
            linha.Delete()
            Util.AdicionaJsAlert(MyBase.Page, "Linha excluída")
            Page.SalvarEContinuar()
            Me.CarregaGrdFaixa(grdFaixa.CurrentPageIndex)
        End If

        preenche_ComboData()
    End Sub

    Private Sub ddlClausula_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlClausula.SelectedIndexChanged
        Try
            If txtClausula.Text <> ddlClausula.SelectedValue Then
                txtClausula.Text = ddlClausula.SelectedValue
            End If

            If Not IsNumeric(ddlClausula.SelectedValue) Then
                CarregaGrdFaixa(grdFaixa.CurrentPageIndex)
                Exit Sub
            End If

            Dim NUMCLSCTTFRN As Decimal = Convert.ToDecimal(ddlClausula.SelectedValue)
            For Each linha As wsAcoesComerciais.DatasetContrato.T0124996Row In Page.dsContrato.T0124996
                If linha.NUMCSLCTTFRN = NUMCLSCTTFRN Then
                    txtAbrangencia.Text = linha.TIPEDEABGMIX.ToString
                    If Not ddlAbrangencia.Items.FindByValue(linha.TIPEDEABGMIX.ToString) Is Nothing Then
                        ddlAbrangencia.SelectedValue = linha.TIPEDEABGMIX.ToString
                        ddlAbrangencia_SelectedIndexChanged(sender, e)
                        Util.AdicionaJsFocus(MyBase.Page, CType(txtDatIniUtzPmt, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                    End If
                End If
            Next

            CarregaGrdFaixa(grdFaixa.CurrentPageIndex)
            TrocaAbrangencia()
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub ddlAbrangencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlAbrangencia.SelectedIndexChanged
        Try
            Me.TrocaAbrangencia()
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub txtAbrangencia_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtAbrangencia.ValueChange
        Try
            If ddlAbrangencia.SelectedValue <> txtAbrangencia.Text Then
                ddlAbrangencia.SelectedValue = txtAbrangencia.Text
                Me.TrocaAbrangencia()
            End If
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub ddlEntidade_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlEntidade.SelectedIndexChanged
        Try
            txtEntidade.Text = ddlEntidade.SelectedValue
            preenche_ComboData()
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub cmbTipoFaixa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoFaixa.SelectedIndexChanged
        Try
            MostraValorOuPercentualNaTela()
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub grdFaixa_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdFaixa.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Dim linha As wsAcoesComerciais.DatasetContrato.T0125038Row
                linha = Me.Page.dsContrato.T0125038.FindByNUMCTTFRNNUMCSLCTTFRNTIPEDEABGMIXCODEDEABGMIXCODFXAAVLDATREFINIUTZPMT(Convert.ToDecimal(e.Item.Cells(2).Text), _
                                                                                                                                Convert.ToDecimal(e.Item.Cells(3).Text), _
                                                                                                                                Convert.ToDecimal(e.Item.Cells(4).Text), _
                                                                                                                                Convert.ToDecimal(e.Item.Cells(5).Text), _
                                                                                                                                Convert.ToDecimal(e.Item.Cells(6).Text), _
                                                                                                                                Convert.ToDateTime(e.Item.Cells(7).Text))
                If Not linha Is Nothing Then
                    PreencheControles(linha)
                End If

                bSeleciona = True
            End If

        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub grdFaixa_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdFaixa.PageIndexChanged
        CarregaGrdFaixa(e.NewPageIndex)
    End Sub

    Private Sub txtClausula_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtClausula.ValueChange
        If ddlClausula.SelectedValue <> txtClausula.Text Then
            ddlClausula.SelectedValue = txtClausula.Text
            TrocaAbrangencia()
        End If
    End Sub

    Private Sub txtDatIniUtzPmt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDatIniUtzPmt.SelectedIndexChanged
        txtVlrFxa.Text = ""
        txtVlrRec.Text = ""
        bSeleciona = False
        CarregaGrdFaixa(grdFaixa.CurrentPageIndex)
    End Sub

    Private Sub txtDatIniUtzPmt_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtDatIniUtzPmt.ValueChange
        If cmbDatIniUtzPmt.Items.FindByValue(txtDatIniUtzPmt.Date.ToString("dd/MM/yyyy")) Is Nothing Then
            cmbDatIniUtzPmt.Items.Add(New ListItem(txtDatIniUtzPmt.Date.ToString("dd/MM/yyyy"), txtDatIniUtzPmt.Date.ToString("dd/MM/yyyy")))
        End If
        cmbDatIniUtzPmt.SelectedValue = txtDatIniUtzPmt.Date.ToString("dd/MM/yyyy")
        Util.AdicionaJsFocus(MyBase.Page, CType(ddl1, System.web.UI.WebControls.WebControl))
    End Sub

    Private Sub txtEntidade_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtEntidade.ValueChange
        preenche_ComboData()
    End Sub

#End Region

#Region " Metodos "

#Region " Metodos de Carga "

    Private Sub CarregaControles()
        Me.CarregaDDLClausulas()
        Me.CarregaGrdFaixa(grdFaixa.CurrentPageIndex)
    End Sub

    Public Sub CarregaDDLClausulas()
        Me.Page.dsContrato.Merge(Controller.ObterContratoXClausulaContrato(Nothing, Nothing, Nothing, Decimal.Zero, Convert.ToDecimal(Me.Page.NUMCTTFRN)), False, MissingSchemaAction.Ignore)

        With ddlClausula
            If Me.Page.dsContrato.T0124953.Rows.Count = 0 Then
                Me.Page.dsContrato.Merge(Controller.ObterClausulasContrato("", 0).T0124953, False, MissingSchemaAction.Ignore)
            End If
            .Items.Clear()
            For Each drT0124961 As wsAcoesComerciais.DatasetContrato.T0124961Row In Me.Page.dsContrato.T0124961.Rows
                'As vezes a célula foi desativada é o usuário escolhe ela para ser consultada
                'If drT0124961.IsDATDSTCSLNull Then
                If drT0124961.GetT0124996Rows.GetLength(0) > 0 AndAlso drT0124961.GetT0124996Rows(0).FLGCALVLRRCBFXACRS.Equals("*") Then
                    .Items.Add(New ListItem(drT0124961.NUMCSLCTTFRN.ToString() & " - " & drT0124961.T0124953Row.DESCSLCTTFRN, drT0124961.NUMCSLCTTFRN.ToString()))
                End If
                'End If
            Next
            .Items.Insert(0, New ListItem(String.Empty, String.Empty))
        End With
    End Sub

    Private Sub CarregarDDLAbrangencia()
        Dim ds As wsAcoesComerciais.DatasetTipoBaseCalculo = _
            Controller.ObterTiposBaseCalculo(String.Empty)

        With ddlAbrangencia
            .Items.Clear()
            .DataSource = ds.T0125003
            .DataTextField = ds.T0125003.DESBSECALColumn.ColumnName
            .DataValueField = ds.T0125003.TIPBSECALColumn.ColumnName
            .DataBind()
            .Items.Insert(0, New ListItem(String.Empty, String.Empty))
            .SelectedIndex = 0
        End With

        ddlEntidade_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub CarregaGrdFaixaOpcaoItens()
        Dim ds As wsAcoesComerciais.DatasetContratoXAbrangenciaMix = _
            Controller.ObterContratosXAbrangenciasMix(Decimal.Zero, txtClausula.ValueDecimal, Convert.ToDecimal(Me.Page.NUMCTTFRN), Convert.ToDecimal(ddlAbrangencia.SelectedValue), Page.CODFRN)

        ddlEntidade.Items.Clear()
        For Each linha As wsAcoesComerciais.DatasetContratoXAbrangenciaMix.T0124996Row In ds.T0124996
            With ddlEntidade
                If Not linha.T0100086Row Is Nothing Then
                    .Items.Add(New ListItem(linha.T0100086Row.CODMER.ToString & "-" & linha.T0100086Row.DESMER, linha.T0100086Row.CODMER.ToString))
                End If
            End With
        Next
        ddlEntidade.Items.Insert(0, New ListItem(String.Empty, String.Empty))

        ddlEntidade_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub CarregaGrdFaixaOpcaoCategoria()
        Dim ds As wsAcoesComerciais.DatasetContratoXAbrangenciaMix = _
            Controller.ObterContratosXAbrangenciasMix(Decimal.Zero, txtClausula.ValueDecimal, Convert.ToDecimal(Me.Page.NUMCTTFRN), txtAbrangencia.ValueDecimal)

        ddlEntidade.Items.Clear()
        For Each linha As wsAcoesComerciais.DatasetContratoXAbrangenciaMix.QueryDeT0100132Row In ds.QueryDeT0100132
            With ddlEntidade
                .Items.Add(New ListItem(linha.CODCTGUNIMER.ToString & "-" & linha.DESCLSMER, linha.CODCTGUNIMER.ToString))
            End With
        Next
        ddlEntidade.Items.Insert(0, New ListItem(String.Empty, String.Empty))

        ddlEntidade_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub CarregaGrdFaixa(ByVal CurrentPageIndex As Integer)
        Dim ds As New wsAcoesComerciais.DatasetContrato

        Page.dsContrato.Merge(Controller.ObterFaixasAvaliacao(0, 0, 0, Page.NUMCTTFRN, 0))

        ds.EnforceConstraints = False
        ds.Merge(Page.dsContrato)

        With Me.grdFaixa
            Try
                .DataSource = ds.T0125038.Select("", "NUMCSLCTTFRN, CODFXAAVL")
                .DataMember = "T0125038"
                .CurrentPageIndex = CurrentPageIndex
                .DataBind()
            Catch ex As Exception
                Controller.TrataErro(MyBase.Page, ex)
            End Try

        End With
    End Sub

    Private Sub preenche_ComboData()
        Dim ds As wsAcoesComerciais.DatasetFaixaAvaliacao

        cmbDatIniUtzPmt.Items.Clear()

        If Not IsNumeric(ddlClausula.SelectedValue) Then
            Exit Sub
        End If

        If Not IsNumeric(ddlAbrangencia.SelectedValue) Then
            Exit Sub
        End If

        ds = Controller.ObterDistinctDatRefIniUtzPmtDeFaixa(Page.NUMCTTFRN, _
                                                            Convert.ToDecimal(ddlClausula.SelectedValue), _
                                                            Convert.ToDecimal(ddlAbrangencia.SelectedValue), _
                                                            CODEDEABGMIX)


        cmbDatIniUtzPmt.Items.Clear()
        For Each linha As wsAcoesComerciais.DatasetFaixaAvaliacao.Query01Row In ds.Query01
            With cmbDatIniUtzPmt
                .Items.Add(New ListItem(linha.DatRefIniUtzPmtEur.ToString("dd/MM/yyyy"), linha.DatRefIniUtzPmtEur.ToString("dd/MM/yyyy")))
            End With
        Next

        If txtDatIniUtzPmt.Text = "" Then
            If IsDate(cmbDatIniUtzPmt.SelectedValue) Then
                txtDatIniUtzPmt.Text = cmbDatIniUtzPmt.SelectedValue
            End If
        End If

    End Sub

#End Region

#Region " Metodos de Controles "

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

    Private Sub MostraValorOuPercentualNaTela()
        Try
            If TipoValorFaixa = TipoValorFaixaEnum.TipoValorFaixaPorPercentual Then
                txtPer.Visible = True
                txtVlrRec.Visible = False
            Else
                txtPer.Visible = False
                txtVlrRec.Visible = True
            End If
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

#End Region

#Region " Metodos de Regras de Negocio "

    Private Sub TrocaAbrangencia()
        txtAbrangencia.Text = ddlAbrangencia.SelectedValue

        If txtAbrangencia.ValueInt.Equals(3) Then
            'Itens
            ddlEntidade.Enabled = True
            Me.CarregaGrdFaixaOpcaoItens()
        ElseIf txtAbrangencia.ValueInt.Equals(2) Then
            'Categoria
            ddlEntidade.Enabled = True
            Me.CarregaGrdFaixaOpcaoCategoria()
        ElseIf txtAbrangencia.ValueInt.Equals(1) Then
            'Todos
            ddlEntidade.Items.Clear()
            ddlEntidade.Enabled = False
            ddlEntidade_SelectedIndexChanged(Nothing, Nothing)
            preenche_ComboData()
        ElseIf txtAbrangencia.ValueInt.Equals(4) Then
            'ItensNovos
            ddlEntidade.Items.Clear()
            ddlEntidade.Enabled = False
            ddlEntidade_SelectedIndexChanged(Nothing, Nothing)
            preenche_ComboData()
        End If

        MostraValorOuPercentualNaTela()
    End Sub

    Private Function ValidarDados() As Boolean
        Dim result As Boolean
        Dim mensagemErro As String = String.Empty
        Dim deuFoco As Boolean

        colocaMesmoValorDosCombosNoText()

        Try
            If Val(ddlClausula.SelectedValue) <= 0 Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "cláusula inválida"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(ddlClausula, WebControl))
                End If
                deuFoco = True
                lblErroddlClausula.Visible = True
            Else
                lblErroddlClausula.Visible = False
            End If

            If ddlAbrangencia.SelectedValue Is String.Empty Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "abrangência inválida"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(ddlAbrangencia, WebControl))
                End If
                deuFoco = True
                lblErroddlAbrangencia.Visible = True
            Else
                lblErroddlAbrangencia.Visible = False
            End If

            If Not txtAbrangencia.ValueInt.Equals(1) Or txtAbrangencia.ValueInt.Equals(4) Then
                If Val(ddlEntidade.SelectedValue) <= 0 Then
                    'Mensagem
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "entidade inválida"

                    If Not deuFoco Then
                        Util.AdicionaJsFocus(MyBase.Page, CType(ddlEntidade, WebControl))
                    End If
                    deuFoco = True
                    LblErroddlEntidade.Visible = True
                Else
                    LblErroddlEntidade.Visible = False
                End If
            Else
                LblErroddlEntidade.Visible = False
            End If

            If txtVlrFxa.Text Is String.Empty Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "Valor da faixa está incorreto"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(txtVlrFxa, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                End If
                deuFoco = True
                lblErrotxtVlrFxa.Visible = True
            Else
                lblErrotxtVlrFxa.Visible = False
            End If

            If TipoValorFaixa = TipoValorFaixaEnum.TipoValorFaixaPorValor Then
                If txtVlrRec.Text Is String.Empty Then
                    'Mensagem
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "valor a Receber está incorreto"

                    If Not deuFoco Then
                        Util.AdicionaJsFocus(MyBase.Page, CType(txtVlrRec, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                    End If
                    deuFoco = True
                    lblErrotxtVlrRec.Visible = True
                Else
                    lblErrotxtVlrRec.Visible = False
                End If
            ElseIf TipoValorFaixa = TipoValorFaixaEnum.TipoValorFaixaPorPercentual Then
                If txtPer.Text Is String.Empty Then
                    'Mensagem
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "percentual a receber está incorreto"

                    If Not deuFoco Then
                        Util.AdicionaJsFocus(MyBase.Page, CType(txtPer, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                    End If
                    deuFoco = True
                    lblErrotxtPer.Visible = True
                Else
                    lblErrotxtPer.Visible = False
                End If
            End If

            If txtDatIniUtzPmt.Text = "" Then txtDatIniUtzPmt.Date = Page.DATINIPODVGRCTTFRN
            If cmbDatIniUtzPmt.Items.FindByValue(txtDatIniUtzPmt.Date.ToString("dd/MM/yyyy")) Is Nothing Then
                cmbDatIniUtzPmt.Items.Add(New ListItem(txtDatIniUtzPmt.Date.ToString("dd/MM/yyyy"), txtDatIniUtzPmt.Date.ToString("dd/MM/yyyy")))
            End If
            If Not IsDate(cmbDatIniUtzPmt.SelectedValue) Then
                cmbDatIniUtzPmt.SelectedValue = txtDatIniUtzPmt.Date.ToString("dd/MM/yyyy")
            End If


            'If txtClausula.ValueInt.Equals(3) Then  ' Anualidade
            '    'Mensagem
            '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '    mensagemErro &= "não é permitido editar clásula de Anualidade, ela é gerada pelo sistema"
            'ElseIf txtClausula.ValueInt.Equals(10) Then  ' Trimestralidade
            '    'Mensagem
            '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '    mensagemErro &= "não é permitido editar clásula de Trimestralidade, ela é gerada pelo sistema"
            'End If

            'If cmbDatIniUtzPmt.SelectedValue = "" Then
            '    'Mensagem
            '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '    mensagemErro &= "data início utilização parâmetro inválida"

            '    If Not deuFoco Then
            '        Util.AdicionaJsFocus(MyBase.Page, CType(txtDatIniUtzPmt, WebControl), Util.tipoDeComponente.InfragisticsTxt)
            '    End If
            '    deuFoco = True
            '    lblErrotxtDatIniUtzPmt.Visible = True
            'Else
            '    lblErrotxtDatIniUtzPmt.Visible = False
            'End If

            'Mostra mensagem de erro
            If mensagemErro.Trim() <> String.Empty Then
                Page.RegisterStartupScript("Alerta", "<script>alert('" & (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1) & "');</script>")
                Return False
            End If

            Return True
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try

    End Function

    Private Sub colocaMesmoValorDosCombosNoText()
        txtClausula.Text = ddlClausula.SelectedValue
        txtAbrangencia.Text = ddlAbrangencia.SelectedValue
        txtEntidade.Text = ddlEntidade.SelectedValue
    End Sub

    Private Sub PreencheLinhat0125038(ByRef dr As wsAcoesComerciais.DatasetContrato.T0125038Row)
        With dr
            .NUMCTTFRN = Page.NUMCTTFRN
            .NUMCSLCTTFRN = Convert.ToDecimal(ddlClausula.SelectedValue)
            .TIPEDEABGMIX = Convert.ToDecimal(ddlAbrangencia.SelectedValue)
            .CODEDEABGMIX = CODEDEABGMIX
            .VLRFXAAVL = txtVlrFxa.ValueDecimal
            .DATREFINIUTZPMT = Convert.ToDateTime(cmbDatIniUtzPmt.SelectedValue)

            If TipoValorFaixa = TipoValorFaixaEnum.TipoValorFaixaPorValor Then
                .VLRRCBREFFXA = txtVlrRec.ValueDecimal
                .PERAPUVLRRCBREFFXA = 0
            Else
                .VLRRCBREFFXA = 0
                .PERAPUVLRRCBREFFXA = txtPer.ValueDecimal
            End If

            If dr.RowState = DataRowState.Added Then
                .DATCADPMT = Now.Date
            End If
            .CODFXAAVL = Convert.ToDecimal(txtCODFXAAVL.Text)
        End With
    End Sub

    Private Sub PreencheControles(ByRef dr As wsAcoesComerciais.DatasetContrato.T0125038Row)
        With dr

            If Not ddlClausula.Items.FindByValue(dr.NUMCSLCTTFRN.ToString) Is Nothing Then
                ddlClausula.SelectedValue = dr.NUMCSLCTTFRN.ToString
                txtClausula.Text = dr.NUMCSLCTTFRN.ToString
            End If

            If Not ddlAbrangencia.Items.FindByValue(dr.TIPEDEABGMIX.ToString) Is Nothing Then
                If Not ddlAbrangencia.Items.FindByValue(dr.TIPEDEABGMIX.ToString) Is Nothing Then
                    ddlAbrangencia.SelectedValue = dr.TIPEDEABGMIX.ToString
                    txtAbrangencia.Text = dr.TIPEDEABGMIX.ToString
                    TrocaAbrangencia()
                End If
            End If

            If ddlAbrangencia.SelectedValue = "3" Then 'Abrangencia por item 
                txtEntidade.ValueDecimal = .CODEDEABGMIX
                If Not ddlEntidade.Items.FindByValue(.CODEDEABGMIX.ToString) Is Nothing Then
                    ddlEntidade.SelectedValue = .CODEDEABGMIX.ToString
                Else
                    ddlEntidade.ClearSelection()
                End If
            ElseIf ddlAbrangencia.SelectedValue = "2" Then 'Abrangencia por categoria
                txtEntidade.ValueDecimal = .CODEDEABGMIX
                If Not ddlEntidade.Items.FindByValue(.CODEDEABGMIX.ToString("000000000000")) Is Nothing Then
                    ddlEntidade.SelectedValue = .CODEDEABGMIX.ToString("000000000000")
                Else
                    ddlEntidade.ClearSelection()
                End If
            Else
                txtEntidade.Text = ""
                ddlEntidade.ClearSelection()
            End If

            If Not cmbDatIniUtzPmt.Items.FindByValue(dr.DATREFINIUTZPMT.ToString("dd/MM/yyyy")) Is Nothing Then
                cmbDatIniUtzPmt.SelectedValue = dr.DATREFINIUTZPMT.ToString("dd/MM/yyyy")
                txtDatIniUtzPmt.Date = dr.DATREFINIUTZPMT
            Else
                cmbDatIniUtzPmt.Items.Add(New ListItem(dr.DATREFINIUTZPMT.ToString("dd/MM/yyyy"), dr.DATREFINIUTZPMT.ToString("dd/MM/yyyy")))
                txtDatIniUtzPmt.Date = dr.DATREFINIUTZPMT
            End If
            txtVlrFxa.ValueDecimal = dr.VLRFXAAVL
            txtPer.ValueDecimal = dr.PERAPUVLRRCBREFFXA
            txtVlrRec.ValueDecimal = dr.VLRRCBREFFXA
            txtCODFXAAVL.Text = dr.CODFXAAVL.ToString
        End With
    End Sub

    Private Function SalvarDados() As Boolean
        SalvarDados = False
        If Me.ValidarDados() Then

            Dim ppin_VLRREC As Decimal
            Dim ppin_PER As Decimal

            If ddlAbrangencia.SelectedValue = "2" Or ddlAbrangencia.SelectedValue = "3" Then
                If Trim(ddlEntidade.SelectedValue) = "" Then
                    Exit Function
                End If
            End If

            If TipoValorFaixa = TipoValorFaixaEnum.TipoValorFaixaPorValor Then
                ppin_VLRREC = txtVlrRec.ValueDecimal
                ppin_PER = 0
            Else
                ppin_VLRREC = 0
                ppin_PER = txtPer.ValueDecimal
            End If

            'If (Not ExisteFaixa() And Not bSeleciona) Or _
            '   (ExisteFaixa() And Not bSeleciona) Then
            If Not (ExisteFaixa() And bSeleciona) Then
                'Inserir Linha
                If Controller.GeraFaixasParaAbrangencia(Page.NUMCTTFRN, _
                                                        Convert.ToDecimal(ddlClausula.SelectedValue), _
                                                        Convert.ToDecimal(ddlAbrangencia.SelectedValue), _
                                                        Convert.ToDecimal(CODEDEABGMIX), _
                                                        txtVlrFxa.ValueDecimal, _
                                                        ppin_VLRREC, _
                                                        ppin_PER, _
                                                        Convert.ToDateTime(cmbDatIniUtzPmt.SelectedValue)) Then

                    'Util.AdicionaJsAlert(MyBase.Page, "Cadastro realizado com sucesso.")
                    CarregaGrdFaixa(grdFaixa.CurrentPageIndex)

                    txtVlrFxa.Text = ""
                    txtVlrRec.Text = ""

                    cmdAtualizar.Enabled = True
                    cmdExcluir.Enabled = True
                Else
                    Util.AdicionaJsAlert(MyBase.Page, "Erro na inclusão, os valores devem estar em ordem crescente na grid.")
                End If
            Else
                'Altera valores da faixa ja existente
                'Update da Linha
                If Controller.ManterFaixasDeCrescimento(Page.NUMCTTFRN, _
                                                        Convert.ToInt32(ddlClausula.SelectedValue), _
                                                        Convert.ToInt32(ddlAbrangencia.SelectedValue), _
                                                        Convert.ToInt32(CODEDEABGMIX), _
                                                        txtVlrFxa.ValueDecimal, _
                                                        ppin_VLRREC, _
                                                        ppin_PER, _
                                                        Convert.ToInt32(txtCODFXAAVL.Text), _
                                                        Convert.ToDateTime(cmbDatIniUtzPmt.SelectedValue)) Then

                    Util.AdicionaJsAlert(MyBase.Page, "Cadastro realizado com sucesso.")
                    CarregaGrdFaixa(grdFaixa.CurrentPageIndex)

                    txtVlrFxa.Text = ""
                    txtVlrRec.Text = ""
                Else
                    Util.AdicionaJsAlert(MyBase.Page, "Erro na inclusão, os valores devem estar em ordem crescente na grid.")
                End If
                Return True
            End If
        End If
    End Function

    Private Function ExisteFaixa() As Boolean
        Dim result As Boolean = False

        If Not IsNumeric(txtCODFXAAVL.Text) Then
            Return False
        End If

        'If Not Page.dsContrato.T0125038.FindByNUMCTTFRNNUMCSLCTTFRNTIPEDEABGMIXCODEDEABGMIXCODFXAAVLDATREFINIUTZPMT(Page.NUMCTTFRN, Convert.ToDecimal(ddlClausula.SelectedValue), txtAbrangencia.ValueDecimal, CODEDEABGMIX, 0, Convert.ToDateTime(cmbDatIniUtzPmt.SelectedValue).Date) Is Nothing Then
        If Page.dsContrato.T0125038.Select("CODFXAAVL = " & CType(txtCODFXAAVL.Text, Integer).ToString("########")).Length > 0 Then
            result = True
        End If
        Return result
    End Function

#End Region

#End Region

End Class