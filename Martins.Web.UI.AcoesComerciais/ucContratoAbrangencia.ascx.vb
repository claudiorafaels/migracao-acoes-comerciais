Public Class ucContratoAbrangencia
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
    Protected WithEvents ddlClausula As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmdNova As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cmdAtualizar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtCodClausula As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtCodAbrangencia As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents ddlAbrangencia As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodEntidade As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents ddlEntidade As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodBseClcVlrRec As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents ddlBseClcVlrRec As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodBseClcIndice As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents ddlBseClcIndice As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlTipCalculoFatMin As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtValorFatMin As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents chkMerExc As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkFaixa As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkFxaPer As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDescMerNova As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkBaseAnterior As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkIndIncIPIApuCtt As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkIndIncICMApuCtt As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkIndIncPISApuCtt As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkIndIncSbtTbtApuCtt As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkPerVlr As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lblPerVlrFixoApuracao As System.Web.UI.WebControls.Label
    Protected WithEvents DatasetContrato1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContrato
    Protected WithEvents grdAbrangencia As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetTipoAbrangenciaMix1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoAbrangenciaMix
    Protected WithEvents lblErroddlClausula As System.Web.UI.WebControls.Label
    Protected WithEvents lblErroddlAbrangencia As System.Web.UI.WebControls.Label
    Protected WithEvents lblErroddlEntidade As System.Web.UI.WebControls.Label
    Protected WithEvents lblErroddlBseClcVlrRec As System.Web.UI.WebControls.Label
    Protected WithEvents lblErrotxtValorFatMin As System.Web.UI.WebControls.Label
    Protected WithEvents lblErrotxtPerVlrFixoApuracao As System.Web.UI.WebControls.Label
    Protected WithEvents TD1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD2 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD3 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents txtPerFixoVlr As Infragistics.WebUI.WebDataInput.WebPercentEdit
    Protected WithEvents txtVlrFixoApu As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
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

    Private ReadOnly Property Controles() As WebControl()
        Get
            Return New WebControl() {txtCodClausula, ddlClausula, txtCodAbrangencia, ddlAbrangencia, _
                txtCodEntidade, ddlEntidade, txtCodBseClcVlrRec, ddlBseClcVlrRec, txtCodBseClcIndice, ddlBseClcIndice, _
                ddlTipCalculoFatMin, txtValorFatMin, chkMerExc, chkFaixa, chkFxaPer, chkDescMerNova, _
                chkPerVlr, txtVlrFixoApu, txtPerFixoVlr, chkBaseAnterior, chkIndIncIPIApuCtt, _
                chkIndIncICMApuCtt, chkIndIncPISApuCtt, chkIndIncSbtTbtApuCtt}
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

    Private Sub cmdNova_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNova.Click
        Try
            CarregaControles()
            Util.AdicionaJsFocus(MyBase.Page, CType(txtCodClausula, WebControl), Util.tipoDeComponente.InfragisticsTxt)

            Dim ctrlLblErro As WebControl() = New WebControl() {lblErroddlAbrangencia, _
                                                                lblErroddlBseClcVlrRec, _
                                                                lblErroddlClausula, _
                                                                lblErroddlEntidade, _
                                                                lblErrotxtPerVlrFixoApuracao, _
                                                                lblErrotxtValorFatMin, _
                                                                lblPerVlrFixoApuracao}
            Util.MostraControles(ctrlLblErro, True)

            'Limpar controles
            For Each ctrl As WebControl In Me.Controles()
                Util.LimpaControles(New WebControl() {ctrl}, False)
            Next

            'Campo com valor padrão
            If Not ddlAbrangencia.Items.FindByValue("1") Is Nothing Then
                txtCodAbrangencia.Text = "1"
                ddlAbrangencia.SelectedValue = "1"
                Me.ddlAbrangencia_SelectedIndexChanged(sender, e)
            End If
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
                Me.CarregaGrdAbrangencias()
                Page.carregarClausulasNasTabs()

                'Limpar controles
                If ddlAbrangencia.SelectedValue = "1" Or ddlAbrangencia.SelectedValue = "4" Then
                    For Each ctrl As WebControl In Me.Controles()
                        Util.LimpaControles(New WebControl() {ctrl}, False)
                    Next
                End If
                Page.SalvarEContinuar()
            End If

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

            'Confirmado regra com Severton em 02/07
            If Page.existeApuracaoParaEsseContrato(txtCodClausula.ValueDecimal) Then
                Util.AdicionaJsAlert(MyBase.Page, "Exclusão não permitida porque existe apuração para essa cláusula")
                Exit Sub
            End If

            If Me.ExcluirDados Then
                Me.CarregaGrdAbrangencias()
                Page.carregarClausulasNasTabs()

                'Limpar controles
                If ddlAbrangencia.SelectedValue = "1" Or ddlAbrangencia.SelectedValue = "4" Then
                    For Each ctrl As WebControl In Me.Controles()
                        Util.LimpaControles(New WebControl() {ctrl}, False)
                    Next
                End If
                Page.SalvarEContinuar()
            End If

        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub ddlClausula_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlClausula.SelectedIndexChanged
        Try
            txtCodClausula.Text = ddlClausula.SelectedValue
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

    Private Sub txtCodAbrangencia_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtCodAbrangencia.ValueChange
        Try
            If ddlAbrangencia.SelectedValue <> txtCodAbrangencia.Text Then
                ddlAbrangencia.SelectedValue = txtCodAbrangencia.Text
                Me.TrocaAbrangencia()
            End If
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub ddlEntidade_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlEntidade.SelectedIndexChanged
        Try
            txtCodEntidade.Text = ddlEntidade.SelectedValue
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub ddlBseClcVlrRec_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlBseClcVlrRec.SelectedIndexChanged
        Try
            'Iguala os valores de outros campos com o valores desse
            txtCodBseClcVlrRec.Text = ddlBseClcVlrRec.SelectedValue
            txtCodBseClcIndice.Text = ddlBseClcVlrRec.SelectedValue
            ddlBseClcIndice.SelectedValue = ddlBseClcVlrRec.SelectedValue
            ddlTipCalculoFatMin.SelectedValue = ddlBseClcVlrRec.SelectedValue
            txtValorFatMin.Text = "0"

            chkIndIncIPIApuCtt.Checked = False
            chkIndIncICMApuCtt.Checked = False
            chkIndIncPISApuCtt.Checked = False
            chkIndIncSbtTbtApuCtt.Checked = False
            If ddlBseClcVlrRec.SelectedValue.Equals("1") Then  ' Faturamento Bruto
                chkIndIncIPIApuCtt.Checked = True
                chkIndIncICMApuCtt.Checked = True
                chkIndIncPISApuCtt.Checked = True
                chkIndIncSbtTbtApuCtt.Checked = True
            ElseIf ddlBseClcVlrRec.SelectedValue.Equals("2") Then  ' Faturamento Liquido
                'chkIndIncSbtTbtApuCtt.Checked = True 
            End If
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub txtCodBseClcVlrRec_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtCodBseClcVlrRec.ValueChange
        Try
            If ddlBseClcVlrRec.SelectedValue <> txtCodBseClcVlrRec.Text Then
                ddlBseClcVlrRec.SelectedValue = txtCodBseClcVlrRec.Text
                ddlBseClcVlrRec_SelectedIndexChanged(sender, e)
            End If
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub grdAbrangencias_Click(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.UltraWebGrid.ClickEventArgs)
        Try
            Me.EditarAbrangencia(Convert.ToDecimal(e.Row.Cells(1).GetText()), Convert.ToDecimal(e.Row.Cells(2).GetText()), Convert.ToDecimal(e.Row.Cells(3).GetText()))
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub grdAbrangencia_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdAbrangencia.PageIndexChanged
        Try
            DatasetContrato1 = Page.dsContrato
            Me.grdAbrangencia.CurrentPageIndex = e.NewPageIndex
            grdAbrangencia.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chkPerVlr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPerVlr.CheckedChanged
        Try
            Me.CliquePercentualFixo()
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub chkFaixa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFaixa.CheckedChanged
        Try
            Me.CliqueFaixa()
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub grdAbrangencia_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdAbrangencia.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Dim linha As wsAcoesComerciais.DatasetContrato.T0124996Row
                linha = Me.Page.dsContrato.T0124996.FindByNUMCTTFRNNUMCSLCTTFRNTIPEDEABGMIXCODEDEABGMIX(Convert.ToDecimal(e.Item.Cells(5).Text), _
                                                                                                        Convert.ToDecimal(e.Item.Cells(2).Text), _
                                                                                                        Convert.ToDecimal(e.Item.Cells(4).Text), _
                                                                                                        Convert.ToDecimal(e.Item.Cells(6).Text))
                If Not linha Is Nothing Then
                    PreencheControles(linha)
                End If

            End If

        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

#End Region

#Region " Metodos "

#Region " Metodos de Carga "

    Private Sub CarregarJavaScript()
        btnExcluir.Attributes.Add("OnClick", "javascript:return confirm('Deseja excluir a abrangencia?')")
    End Sub

    Private Sub CarregaControles()
        Me.CarregaDDLClausulas()
        Me.CarregarDDLBseClcVlrRec()
        Me.CarregaGrdAbrangencias()
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
                .Items.Add(New ListItem(drT0124961.NUMCSLCTTFRN.ToString() & " - " & drT0124961.T0124953Row.DESCSLCTTFRN, drT0124961.NUMCSLCTTFRN.ToString()))
                'End If
            Next
            .Items.Insert(0, New ListItem(String.Empty, String.Empty))
        End With
    End Sub

    Private Sub CarregarDDLEntidadeOpcaoItens()
        Dim ds As wsAcoesComerciais.DatasetContratoXAbrangenciaMix = _
            Controller.ObterMercadoriasDoFornecedor(1, Page.CODFRN)

        ddlEntidade.Items.Clear()
        For Each linha As wsAcoesComerciais.DatasetContratoXAbrangenciaMix.T0100086Row In ds.T0100086
            ddlEntidade.Items.Add(New ListItem(linha.CODMER.ToString() & " - " & linha.DESMER, linha.CODMER.ToString))
        Next
        ddlEntidade.Items.Insert(0, New ListItem(String.Empty, String.Empty))

        ddlEntidade_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub CarregarDDLEntidadeOpcaoCategoria()
        Dim ds As wsAcoesComerciais.DatasetContratoXAbrangenciaMix
        ds = Controller.ObterCategoriasDoFornecedor(1, Page.CODFRN)

        ddlEntidade.Items.Clear()
        For Each linha As wsAcoesComerciais.DatasetContratoXAbrangenciaMix.QueryDeT0100132Row In ds.QueryDeT0100132
            ddlEntidade.Items.Add(New ListItem(linha.CODCTGUNIMER.ToString & " - " & linha.DESCLSMER, linha.CODCTGUNIMER.ToString))
        Next
        ddlEntidade.Items.Insert(0, New ListItem(String.Empty, String.Empty))

        ddlEntidade_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub CarregarDDLBseClcVlrRec()
        Dim ds As wsAcoesComerciais.DatasetTipoBaseCalculo = Controller.ObterTiposBaseCalculo(String.Empty)

        Util.carregarTipoBaseCalculo(ds, ddlBseClcVlrRec, New ListItem(String.Empty, String.Empty))
        Util.carregarTipoBaseCalculo(ds, ddlBseClcIndice, New ListItem(String.Empty, String.Empty))
        Util.carregarTipoBaseCalculo(ds, ddlTipCalculoFatMin, New ListItem(String.Empty, String.Empty))

        ddlEntidade_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub CarregaGrdAbrangencias()
        Try
            Dim dsContratoXAbrangenciaMix As wsAcoesComerciais.DatasetContratoXAbrangenciaMix

            Me.DatasetContrato1 = Me.Page.dsContrato
            Me.grdAbrangencia.DataBind()
        Catch ex As Exception
            If Me.grdAbrangencia.CurrentPageIndex > 0 Then
                Me.grdAbrangencia.CurrentPageIndex = 0
                Me.CarregaGrdAbrangencias()
            Else
                Controller.TrataErro(MyBase.Page, ex)
            End If

        End Try
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

#End Region

#Region " Metodos de Regras de Negocio "

    Private Sub TrocaAbrangencia()
        txtCodAbrangencia.Text = ddlAbrangencia.SelectedValue

        If txtCodAbrangencia.ValueInt.Equals(3) Then
            'Itens
            ddlEntidade.Enabled = True
            txtCodEntidade.Enabled = True
            Me.CarregarDDLEntidadeOpcaoItens()
        ElseIf txtCodAbrangencia.ValueInt.Equals(2) Then
            'Categoria
            ddlEntidade.Enabled = True
            txtCodEntidade.Enabled = True
            Me.CarregarDDLEntidadeOpcaoCategoria()
        ElseIf txtCodAbrangencia.ValueInt.Equals(1) Then
            'Todos
            ddlEntidade.Items.Clear()
            ddlEntidade.Enabled = False
            txtCodEntidade.Enabled = False
            ddlEntidade_SelectedIndexChanged(Nothing, Nothing)
            'CarregaDados()
        ElseIf txtCodAbrangencia.ValueInt.Equals(4) Then
            'ItensNovos
            ddlEntidade.Items.Clear()
            ddlEntidade.Enabled = False
            txtCodEntidade.Enabled = False
            ddlEntidade_SelectedIndexChanged(Nothing, Nothing)
            'CarregaDados()
        End If
        chkPerVlr.Checked = True
    End Sub

    Private Sub CliquePercentualFixo()
        If chkPerVlr.Checked Then
            txtPerFixoVlr.Visible = True
            txtVlrFixoApu.Visible = False
            txtVlrFixoApu.Text = String.Empty
            lblPerVlrFixoApuracao.Text = "Percentual Fixo de Apuração do Valor:"
        Else
            txtPerFixoVlr.Visible = False
            txtPerFixoVlr.Text = ""
            txtVlrFixoApu.Visible = True
            lblPerVlrFixoApuracao.Text = "Valor Fixo de Apuração:"

            'Verifica se foi informado um valor para a Cláusula
            If txtCodClausula.Text <> String.Empty Then
                'Verifica se a clausula é de crescimento
                If txtCodClausula.ValueInt.Equals(2) Or txtCodClausula.ValueInt.Equals(3) Or txtCodClausula.ValueInt.Equals(10) Then
                    'Verifica Através da função se o Fornecedor é do Filiado
                    If Me.VerificaSmart Then
                        'Habilita Tab Filiados
                        'TabMix.TabEnabled(1) = True
                        'Desaparece a opção de Valor Fixo
                        lblPerVlrFixoApuracao.Text = "Percentual Fixo de Apuração do Valor:"
                        txtVlrFixoApu.Visible = False
                        txtVlrFixoApu.Text = String.Empty
                    Else
                        'Desabilita Tab Filiados
                        'TabMix.TabEnabled(1) = False
                        lblPerVlrFixoApuracao.Text = "Valor Fixo de Apuração:"
                        txtVlrFixoApu.Visible = True
                        txtVlrFixoApu.Text = ""
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub CliqueFaixa()
        If chkFaixa.Checked Then
            txtPerFixoVlr.Text = String.Empty
            txtVlrFixoApu.Text = String.Empty
            txtPerFixoVlr.Enabled = False
            txtVlrFixoApu.Enabled = False
            chkPerVlr.Enabled = False
            chkFxaPer.Enabled = True

            'Se a Faixa de Crescimento estiver marcada
            'então irá aparecer o check Base Anterior
            If txtCodClausula.ValueInt.Equals(2) And Me.VerificaSmart() Then
                'Habilita Tab Filiados
                'TabMix.TabEnabled(1) = True
                'Habilta Check Base Anterior
                chkBaseAnterior.Visible = True
                chkBaseAnterior.Checked = False
            Else
                'Habilita Tab Filiados
                'TabMix.TabEnabled(1) = False
                'Desabilta Check Base Anterior
                chkBaseAnterior.Visible = False
                chkBaseAnterior.Checked = False
            End If

            TD1.Visible = False
            TD2.Visible = False
            TD3.Visible = False

            'Limpa as opções
            chkPerVlr.Checked = False
            txtPerFixoVlr.Text = ""
            txtVlrFixoApu.Text = ""
        Else
            chkPerVlr.Enabled = True
            txtPerFixoVlr.Enabled = True
            txtVlrFixoApu.Enabled = True
            chkFxaPer.Checked = False
            chkFxaPer.Enabled = False
            lblPerVlrFixoApuracao.Text = "Percentual Fixo de Apuração do Valor:"

            chkBaseAnterior.Checked = False
            chkBaseAnterior.Visible = False

            TD1.Visible = True
            TD2.Visible = True
            TD3.Visible = True
        End If
    End Sub

    Public Function VerificaSmart() As Boolean
        VerificaSmart = False
        Dim ds As wsAcoesComerciais.dataSetDivisaoFornecedor = Controller.ObterDivisaoFornecedor(1, CLng(Me.Page.CODFRN))
        If ds.T0100426.Rows.Count = 1 Then
            If Not ds.T0100426.Item(0).IsTIPIDTEMPASCACOCMCNull Then
                If ds.T0100426.Item(0).TIPIDTEMPASCACOCMC.Equals(2) Then
                    Return True
                End If
            End If
        End If
    End Function

    Private Sub colocaMesmoValorDosCombosNoText()
        txtCodClausula.Text = ddlClausula.SelectedValue
        txtCodAbrangencia.Text = ddlAbrangencia.SelectedValue
        txtCodEntidade.Text = ddlEntidade.SelectedValue
        txtCodBseClcVlrRec.Text = ddlBseClcVlrRec.SelectedValue
        txtCodBseClcIndice.Text = ddlBseClcIndice.SelectedValue
    End Sub

    Private Function ValidarDados() As Boolean
        Dim result As Boolean
        Dim mensagemErro As String = String.Empty
        Dim deuFoco As Boolean

        colocaMesmoValorDosCombosNoText()

        Try
            If txtCodClausula.ValueInt <= 0 Then
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

            If txtCodAbrangencia.Text Is String.Empty Then
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

            If (Not txtCodAbrangencia.ValueInt.Equals(1)) And (Not txtCodAbrangencia.ValueInt.Equals(4)) Then
                If txtCodEntidade.Text = String.Empty Then
                    'Mensagem
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "entidade inválida"

                    If Not deuFoco Then
                        Util.AdicionaJsFocus(MyBase.Page, CType(ddlEntidade, WebControl))
                    End If
                    deuFoco = True
                    lblErroddlEntidade.Visible = True
                Else
                    lblErroddlEntidade.Visible = False
                End If
            Else
                lblErroddlEntidade.Visible = False
            End If

            If txtCodBseClcVlrRec.Text Is String.Empty Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "base de cálculo inválida"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(ddlBseClcVlrRec, WebControl))
                End If
                deuFoco = True
                lblErroddlBseClcVlrRec.Visible = True
            Else
                lblErroddlBseClcVlrRec.Visible = False
            End If

            If Trim(ddlTipCalculoFatMin.SelectedValue) = "" Then
                'iTipoBase = Null
                'dValorMin = Null
                lblErrotxtValorFatMin.Visible = False
            Else
                If Trim(ddlTipCalculoFatMin.SelectedValue) <> "" And (Trim(txtValorFatMin.Text) = "0" Or Trim(txtValorFatMin.Text) = "") Then
                    'Mensagem
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "informe o valor mínimo faturamento cobrança."

                    If Not deuFoco Then
                        Util.AdicionaJsFocus(MyBase.Page, CType(txtValorFatMin, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                    End If
                    deuFoco = True
                    lblErrotxtValorFatMin.Visible = True
                Else
                    'iTipoBase = CVar(ddlTipCalculoFatMin.SelectedValue)
                    'dValorMin = CVar(txtValorFatMin.Text)
                    lblErrotxtValorFatMin.Visible = False
                End If
            End If

            If Not ddlTipCalculoFatMin.SelectedValue Is String.Empty Then
                If txtValorFatMin.Text.Trim() Is String.Empty Then
                    'Mensagem
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "informe o valor mínimo faturamento cobrança."

                    If Not deuFoco Then
                        Util.AdicionaJsFocus(MyBase.Page, CType(txtValorFatMin, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                    End If
                    deuFoco = True
                    lblErrotxtValorFatMin.Visible = True
                Else
                    lblErrotxtValorFatMin.Visible = False
                End If
            Else
                lblErrotxtValorFatMin.Visible = False
            End If

            ''O Tratamento de erro para o valor de percentual será apenas
            ''para fornecedores smart
            'If chkFaixa.Checked = False And txtPerFixoVlr.Text.Trim() Is String.Empty Then
            '    'Mensagem
            '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '    mensagemErro &= "você é obrigado a entrar com um valor para o Percentual"

            '    If Not deuFoco Then
            '        Util.AdicionaJsFocus(MyBase.Page, CType(txtPerFixoVlr, WebControl))
            '    End If
            '    deuFoco = True
            '    lblErrotxtPerVlrFixoApuracao.Visible = True
            'Else
            '    lblErrotxtPerVlrFixoApuracao.Visible = False
            'End If

            ' Valida Bse.Clc.Vlr.Rec para clausulas de aditamento
            If (InStr(1, ";5;6;7;", txtCodClausula.Text.Trim()) > 0) And (InStr(1, ";3;4;", txtCodBseClcVlrRec.Text.Trim()) > 0) Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "base de cálculo inválida para Cláusula de Aditamento"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(ddlBseClcVlrRec, WebControl))
                End If
                deuFoco = True
                lblErroddlBseClcVlrRec.Visible = True
            Else
                lblErroddlBseClcVlrRec.Visible = False
            End If
            'Só irá tratar o valor por meta quando o fornecedor for Martins
            If chkFaixa.Checked = False Then
                If chkPerVlr.Checked = True Then
                    If txtPerFixoVlr.Text Is String.Empty Then
                        'Mensagem
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "você é obrigado a entrar com um valor para o Percentual."

                        If Not deuFoco Then
                            Util.AdicionaJsFocus(MyBase.Page, CType(txtPerFixoVlr, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                        End If
                        deuFoco = True
                        lblErrotxtPerVlrFixoApuracao.Visible = True
                    Else
                        lblErrotxtPerVlrFixoApuracao.Visible = False
                    End If
                Else
                    If txtVlrFixoApu.Text Is String.Empty Then
                        'Mensagem
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "você é obrigado a entrar com um valor para o campo valor fixo"

                        If Not deuFoco Then
                            Util.AdicionaJsFocus(MyBase.Page, CType(txtVlrFixoApu, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                        End If
                        deuFoco = True
                        lblErrotxtPerVlrFixoApuracao.Visible = True
                    Else
                        lblErrotxtPerVlrFixoApuracao.Visible = False
                    End If
                End If
            End If

            If chkPerVlr.Checked = True And (chkFaixa.Checked = True Or chkFxaPer.Checked = True) Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "não é permitido selecionar faixa de crescimento e percentual fixo ao mesmo tempo"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(chkFaixa, WebControl))
                End If
                deuFoco = True
            End If

            If ddlTipCalculoFatMin.SelectedValue Is String.Empty And (Not txtValorFatMin.Text.Trim() Is String.Empty) Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "informe o tipo Cálculo Fat. mínimo"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(ddlTipCalculoFatMin, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                End If
                deuFoco = True
            ElseIf (Not ddlTipCalculoFatMin.SelectedValue Is String.Empty) And txtValorFatMin.Text.Trim() Is String.Empty Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "informe o valor do faturamento mínimo"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(txtValorFatMin, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                End If
                deuFoco = True
            End If

            'If txtCodClausula.ValueInt.Equals(3) Then  ' Anualidade
            '    'Mensagem
            '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '    mensagemErro &= "não é permitido editar clásula de Anualidade, ela é gerada pelo sistema"
            'ElseIf txtCodClausula.ValueInt.Equals(10) Then  ' Trimestralidade
            '    'Mensagem
            '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '    mensagemErro &= "não é permitido editar clásula de Trimestralidade, ela é gerada pelo sistema"
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

    Private Sub PreencheLinhaT0124996(ByRef dr As wsAcoesComerciais.DatasetContrato.T0124996Row)
        With dr
            ' linha nova
            If dr.RowState = DataRowState.Detached Then
                .NUMCTTFRN = Convert.ToDecimal(Me.Page.NUMCTTFRN)
                .NUMCSLCTTFRN = txtCodClausula.ValueDecimal
                .TIPEDEABGMIX = txtCodAbrangencia.ValueDecimal
                .CODEDEABGMIX = Convert.ToDecimal(IIf(txtCodAbrangencia.ValueInt.Equals(1) Or txtCodAbrangencia.ValueInt.Equals(4), Me.Page.CODFRN(), txtCodEntidade.ValueDecimal))
            End If
            .PERORIFIXAPUVLRRCB = 0
            .INDSUSAPUARDFRN = 0
            .FLGMERECS = Convert.ToString(IIf(chkMerExc.Checked, "*", String.Empty))
            .FLGTRTMERNVO = Convert.ToString(IIf(chkDescMerNova.Checked, "*", String.Empty))
            .TIPBSECALAPUVLRRCB = txtCodBseClcVlrRec.ValueDecimal
            .TIPBSECALAPUIDCCRS = txtCodBseClcIndice.ValueDecimal
            .VLRFIXAPUVLRRCB = txtVlrFixoApu.ValueDecimal
            .PERFIXAPUVLRRCB = txtPerFixoVlr.ValueDecimal
            .FLGCALVLRRCBFXACRS = Convert.ToString(IIf(chkFaixa.Checked, "*", String.Empty))
            .FLGFXAAVLPER = Convert.ToString(IIf(chkFxaPer.Checked, "*", String.Empty))
            If ddlTipCalculoFatMin.SelectedValue Is String.Empty Then
                .SetTIPBSECALVLRFATMNMNull()
                .SetVLRFATMNMCOBFRNNull()
                'dValorMin = Null
            ElseIf Not txtValorFatMin.Text.Trim() Is String.Empty Then
                .TIPBSECALVLRFATMNM = Convert.ToDecimal(ddlTipCalculoFatMin.SelectedValue)
                .VLRFATMNMCOBFRN = txtValorFatMin.ValueDecimal
                'dValorMin = CVar(txtVlrMin.Text)
            End If

            ' IndIncIpiApuCtt - IPI
            .INDINCIPIAPUCTT = Convert.ToDecimal(chkIndIncIPIApuCtt.Checked)
            ' IndIncIcmApuCtt - ICMS
            .INDINCICMAPUCTT = Convert.ToDecimal(chkIndIncICMApuCtt.Checked)
            ' IndIncPisApuCtt - PIS / COFINS
            .INDINCPISAPUCTT = Convert.ToDecimal(chkIndIncPISApuCtt.Checked)
            ' IndIncSbtTbtApuCtt - Substituição Tributária
            .INDINCSBTTBTAPUCTT = Convert.ToDecimal(chkIndIncSbtTbtApuCtt.Checked)
        End With
    End Sub

    Private Sub PreencheControles(ByRef dr As wsAcoesComerciais.DatasetContrato.T0124996Row)
        With dr

            ddlClausula.SelectedValue = .NUMCSLCTTFRN.ToString() : Me.ddlClausula_SelectedIndexChanged(Nothing, Nothing)
            ddlAbrangencia.SelectedValue = .TIPEDEABGMIX.ToString() : Me.ddlAbrangencia_SelectedIndexChanged(Nothing, Nothing)

            chkMerExc.Checked = False 'Valor padrão para o caso de ser nulo
            If Not .IsFLGMERECSNull Then
                chkMerExc.Checked = Convert.ToBoolean(IIf(.FLGMERECS.Equals("*"), True, False))
            End If

            chkDescMerNova.Checked = False 'Valor padrão para o caso de ser nulo
            If Not .IsFLGTRTMERNVONull Then
                chkDescMerNova.Checked = Convert.ToBoolean(IIf(.FLGTRTMERNVO.Equals("*"), True, False))
            End If

            If Not .IsTIPBSECALAPUVLRRCBNull Then
                txtCodBseClcVlrRec.ValueDecimal = .TIPBSECALAPUVLRRCB
                If Not ddlBseClcVlrRec.Items.FindByValue(txtCodBseClcVlrRec.Text) Is Nothing Then
                    ddlBseClcVlrRec.SelectedValue = txtCodBseClcVlrRec.Text
                End If
            End If

            If Not .IsTIPBSECALAPUIDCCRSNull Then
                txtCodBseClcIndice.ValueDecimal = .TIPBSECALAPUIDCCRS
                If Not ddlBseClcIndice.Items.FindByValue(txtCodBseClcIndice.Text) Is Nothing Then
                    ddlBseClcIndice.SelectedValue = txtCodBseClcIndice.Text
                End If
            End If

            chkFaixa.Checked = False 'Valor padrão para o caso de ser nulo
            If Not .IsFLGCALVLRRCBFXACRSNull Then
                chkFaixa.Checked = Convert.ToBoolean(IIf(.FLGCALVLRRCBFXACRS.Equals("*"), True, False))
            End If

            chkFxaPer.Checked = False 'Valor padrão para o caso de ser nulo
            If Not .IsFLGFXAAVLPERNull Then
                chkFxaPer.Checked = Convert.ToBoolean(IIf(.FLGFXAAVLPER.Equals("*"), True, False))
            End If

            txtVlrFixoApu.ValueDecimal = 0  'Valor padrão para o caso de ser nulo
            If Not .IsVLRFIXAPUVLRRCBNull Then
                If Not .VLRFIXAPUVLRRCB.ToString() Is String.Empty Then
                    txtVlrFixoApu.ValueDecimal = .VLRFIXAPUVLRRCB
                End If
            End If

            If Not .IsTIPBSECALVLRFATMNMNull Then
                If Not .TIPBSECALVLRFATMNM.ToString() Is String.Empty Then
                    ddlTipCalculoFatMin.SelectedValue = .TIPBSECALVLRFATMNM.ToString()
                End If
            End If

            If Not .IsVLRFATMNMCOBFRNNull Then
                If Not .VLRFATMNMCOBFRN.ToString() Is String.Empty Then
                    txtValorFatMin.ValueDecimal = .VLRFATMNMCOBFRN
                End If
            End If

            chkPerVlr.Checked = False  'Valor padrão para o caso de ser nulo
            If Not .IsPERFIXAPUVLRRCBNull Then
                If Not .PERFIXAPUVLRRCB.ToString() Is String.Empty Then
                    If .PERFIXAPUVLRRCB > 0 Then
                        chkPerVlr.Checked = True
                    End If
                    txtPerFixoVlr.ValueDecimal = .PERFIXAPUVLRRCB
                End If
            End If

            If ddlAbrangencia.SelectedValue = "3" Then 'Abrangencia por item 
                txtCodEntidade.ValueDecimal = .CODEDEABGMIX
                If Not ddlEntidade.Items.FindByValue(.CODEDEABGMIX.ToString) Is Nothing Then
                    ddlEntidade.SelectedValue = .CODEDEABGMIX.ToString
                Else
                    ddlEntidade.ClearSelection()
                End If
            ElseIf ddlAbrangencia.SelectedValue = "2" Then 'Abrangencia por categoria
                txtCodEntidade.ValueDecimal = .CODEDEABGMIX
                If Not ddlEntidade.Items.FindByValue(.CODEDEABGMIX.ToString("000000000000")) Is Nothing Then
                    ddlEntidade.SelectedValue = .CODEDEABGMIX.ToString("000000000000")
                Else
                    ddlEntidade.ClearSelection()
                End If
            Else
                txtCodEntidade.Text = ""
                ddlEntidade.ClearSelection()
            End If

            ' IndIncIpiApuCtt - IPI
            chkIndIncIPIApuCtt.Checked = Convert.ToBoolean(.INDINCIPIAPUCTT)
            ' IndIncIcmApuCtt - ICMS
            chkIndIncICMApuCtt.Checked = Convert.ToBoolean(.INDINCICMAPUCTT)
            ' IndIncPisApuCtt - PIS / COFINS
            chkIndIncPISApuCtt.Checked = Convert.ToBoolean(.INDINCPISAPUCTT)
            ' IndIncSbtTbtApuCtt - Substituição Tributária
            chkIndIncSbtTbtApuCtt.Checked = Convert.ToBoolean(.INDINCSBTTBTAPUCTT)

            If txtPerFixoVlr.ValueDecimal > 0 Then
                chkPerVlr.Checked = True
                txtPerFixoVlr.Visible = True
                txtVlrFixoApu.Visible = False
            Else
                chkPerVlr.Checked = False
                txtPerFixoVlr.Visible = False
                txtVlrFixoApu.Visible = True
            End If

            CliqueFaixa()

        End With
    End Sub

    Private Function SalvarDados() As Boolean
        SalvarDados = False
        If Me.ValidarDados() Then
            If Not Me.Page.dsContrato.T0124996.FindByNUMCTTFRNNUMCSLCTTFRNTIPEDEABGMIXCODEDEABGMIX(Convert.ToDecimal(Me.Page.NUMCTTFRN), txtCodClausula.ValueDecimal, txtCodAbrangencia.ValueDecimal, Convert.ToDecimal(IIf(txtCodAbrangencia.ValueInt.Equals(1) Or txtCodAbrangencia.ValueInt.Equals(4), Me.Page.CODFRN(), txtCodEntidade.ValueDecimal))) Is Nothing Then
                Dim dr As wsAcoesComerciais.DatasetContrato.T0124996Row = _
                        Me.Page.dsContrato.T0124996.FindByNUMCTTFRNNUMCSLCTTFRNTIPEDEABGMIXCODEDEABGMIX(Convert.ToDecimal(Me.Page.NUMCTTFRN), txtCodClausula.ValueDecimal, txtCodAbrangencia.ValueDecimal, Convert.ToDecimal(IIf(txtCodAbrangencia.ValueInt.Equals(1) Or txtCodAbrangencia.ValueInt.Equals(4), Me.Page.CODFRN(), txtCodEntidade.ValueDecimal)))

                'Retirado essa validação por solicitação do Severton em 02/07/2007
                'Nessa data o Severton precisou alterar uma abrangencia e manteve contato
                'com Severton que solicitou que fosse retirado essa validação
                'If Page.existeApuracaoParaEsseContrato(txtCodClausula.ValueDecimal) Then
                '    Util.AdicionaJsAlert(MyBase.Page, "Não é permitido alterar abrangência porque já foi realizada apuração para essa cláusula.")
                '    Return False
                'End If

                Me.PreencheLinhaT0124996(dr)
            Else
                Dim dr As wsAcoesComerciais.DatasetContrato.T0124996Row = _
                                    Me.Page.dsContrato.T0124996.NewT0124996Row()

                Me.PreencheLinhaT0124996(dr)
                Me.Page.dsContrato.T0124996.AddT0124996Row(dr)
            End If
            SalvarDados = True
        End If
    End Function

    Private Function ExcluirDados() As Boolean
        ExcluirDados = False
        If Me.ValidarDados() Then
            If Not Me.Page.dsContrato.T0124996.FindByNUMCTTFRNNUMCSLCTTFRNTIPEDEABGMIXCODEDEABGMIX(Convert.ToDecimal(Me.Page.NUMCTTFRN), txtCodClausula.ValueDecimal, txtCodAbrangencia.ValueDecimal, Convert.ToDecimal(IIf(txtCodAbrangencia.ValueInt.Equals(1) Or txtCodAbrangencia.ValueInt.Equals(4), Me.Page.CODFRN(), txtCodEntidade.ValueDecimal))) Is Nothing Then
                Dim dr As wsAcoesComerciais.DatasetContrato.T0124996Row = _
                        Me.Page.dsContrato.T0124996.FindByNUMCTTFRNNUMCSLCTTFRNTIPEDEABGMIXCODEDEABGMIX(Convert.ToDecimal(Me.Page.NUMCTTFRN), txtCodClausula.ValueDecimal, txtCodAbrangencia.ValueDecimal, Convert.ToDecimal(IIf(txtCodAbrangencia.ValueInt.Equals(1) Or txtCodAbrangencia.ValueInt.Equals(4), Me.Page.CODFRN(), txtCodEntidade.ValueDecimal)))
                dr.Delete()
            End If
            ExcluirDados = True
        End If
    End Function

    Private Sub EditarAbrangencia(ByVal NumCslCttFrn As Decimal, ByVal TipEdeAgbMix As Decimal, ByVal CodEdeAbgMix As Decimal)
        If Not Me.Page.dsContrato.T0124996.FindByNUMCTTFRNNUMCSLCTTFRNTIPEDEABGMIXCODEDEABGMIX(Convert.ToDecimal(Me.Page.NUMCTTFRN), NumCslCttFrn, TipEdeAgbMix, CodEdeAbgMix) Is Nothing Then
            Dim dr As wsAcoesComerciais.DatasetContrato.T0124996Row = _
                            Me.Page.dsContrato.T0124996.FindByNUMCTTFRNNUMCSLCTTFRNTIPEDEABGMIXCODEDEABGMIX(Convert.ToDecimal(Me.Page.NUMCTTFRN), NumCslCttFrn, TipEdeAgbMix, CodEdeAbgMix)
            'Me.SetPageSate(Contrato.PageState.EdicaoRegistro)
            Me.PreencheControles(dr)
            txtCodClausula.Enabled = False : ddlClausula.Enabled = False
            txtCodAbrangencia.Enabled = False : ddlAbrangencia.Enabled = False
        End If
    End Sub

#End Region

#End Region

End Class