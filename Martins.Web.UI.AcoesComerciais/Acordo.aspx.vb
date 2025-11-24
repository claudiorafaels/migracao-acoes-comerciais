Imports Martins.Security.Helper

Public Class Acordo
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cmbNomeFornecedor As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNomeFornecedor As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents btnBuscarFornecedor As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cmbCODFILEMP As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDATNGCPMS As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtNOMCTOFRN As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents txtNUMPEDCMP As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents txtNUMTLFCTOFRN As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents txtDESCGRCTOFRN As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents txtDATNGCPMSItem As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtVLRNGCPMS As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtDATPRVRCBPMS As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents cmbTIPFRMDSCBNF As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmbTIPDSNDSCBNF As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDESMSGUSR As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents btnInserir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetAcordo1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetAcordo
    Protected WithEvents txtCODPMS As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtCODFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtCODSITPMS As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents btnSalvarRecebimento As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cmbCODSITPMS As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNOMACSUSRSIS As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents txtValorTotal As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents cmdCancelarAcordo As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnImprimir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtTipoFornecedor As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents dGridRecebimentos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnVisualizar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnNovo As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ddl1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddl2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents btnAlterarVerbaCarimbo As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Linkbutton2 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents GrdVerbaCarimbo As Infragistics.WebUI.UltraWebGrid.UltraWebGrid


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
    Private flagCarimbo As Boolean = False

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

    Private Property _flagCarimbo() As Boolean
        Get
            Return flagCarimbo
        End Get
        Set(ByVal Value As Boolean)
            flagCarimbo = Value
        End Set
    End Property


#End Region

#Region "Busca Fornecedor"

    Private Sub btnBuscarFornecedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarFornecedor.Click
        Dim datasetFornecedor As wsAcoesComerciais.dataSetDivisaoFornecedor
        Dim flagMostrarCombo As Boolean = False

        If txtNomeFornecedor.Visible Then
            If txtNomeFornecedor.Text.Trim.Length < 3 Then
                Page.RegisterStartupScript("Alerta", "<script>alert('É obrigatório digitar no mínimo 3 caracteres do nome antes de pesquisar.');</script>")
                Exit Sub
            End If

            datasetFornecedor = Controller.ObterDivisoesFornecedor(1, txtNomeFornecedor.Text)
            If datasetFornecedor.T0100426.Rows.Count > 0 Then
                Util.carregarCmbDivisaoFornecedor(datasetFornecedor, cmbNomeFornecedor, Nothing)
                txtCODFRN.Text = cmbNomeFornecedor.SelectedValue
                flagMostrarCombo = True
            Else
                Util.AdicionaJsAlert(Me.Page, "Registro não encontrado")
            End If

            With cmbNomeFornecedor
                .Visible = flagMostrarCombo
                .Enabled = flagMostrarCombo
                If flagMostrarCombo Then
                    .Width = System.Web.UI.WebControls.Unit.Parse("280px")
                Else
                    .Width = System.Web.UI.WebControls.Unit.Parse("0px")
                End If
            End With
            With txtNomeFornecedor
                .Visible = Not flagMostrarCombo
                .Enabled = Not flagMostrarCombo
                If Not flagMostrarCombo Then
                    .Width = System.Web.UI.WebControls.Unit.Parse("280px")
                Else
                    .Width = System.Web.UI.WebControls.Unit.Parse("0px")
                End If
            End With
        ElseIf cmbNomeFornecedor.Visible Then
            With cmbNomeFornecedor
                .Visible = False
                .Enabled = False
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
            End With
            With txtNomeFornecedor
                .Visible = True
                .Enabled = True
                .Width = System.Web.UI.WebControls.Unit.Parse("280px")
            End With
        End If
    End Sub

    Private Sub cmbNomeFornecedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNomeFornecedor.SelectedIndexChanged
        txtCODFRN.Text = cmbNomeFornecedor.SelectedValue
    End Sub

    Private Sub txtCODFRN_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtCODFRN.ValueChange
        Dim datasetFornecedor As wsAcoesComerciais.dataSetDivisaoFornecedor
        Dim flagMostrarCombo As Boolean

        If Not (IsNumeric(txtCODFRN.Text)) Then Exit Sub

        flagMostrarCombo = False
        datasetFornecedor = Controller.ObterDivisaoFornecedor(1, CLng(txtCODFRN.Text))
        If datasetFornecedor.T0100426.Rows.Count > 0 Then
            cmbNomeFornecedor.Items.Clear()
            For Contador As Integer = 0 To datasetFornecedor.T0100426.Count - 1
                cmbNomeFornecedor.Items.Add(datasetFornecedor.T0100426(Contador).NOMFRN.Trim)
                cmbNomeFornecedor.Items(Contador).Value = datasetFornecedor.T0100426(Contador).CODFRN.ToString
            Next
            flagMostrarCombo = True
            'Verifica o tipo da empresa
            txtTipoFornecedor.Text = String.Empty
            If datasetFornecedor.T0100426.Rows.Count > 0 Then
                If datasetFornecedor.T0100426(0).IsTIPIDTEMPASCACOCMCNull Then
                    txtTipoFornecedor.Text = "MARTINS"
                Else
                    If datasetFornecedor.T0100426(0).TIPIDTEMPASCACOCMC = 0 Then
                        txtTipoFornecedor.Text = "MARTINS"
                    Else
                        txtTipoFornecedor.Text = "FARMASERVICE"
                    End If
                End If
            End If
        Else
            cmbNomeFornecedor.Items.Clear()
            txtNomeFornecedor.Text = String.Empty
            Util.AdicionaJsAlert(Me.Page, "Código de fornecedor inválido")
        End If

        With cmbNomeFornecedor
            .Visible = flagMostrarCombo
            .Enabled = flagMostrarCombo
            If flagMostrarCombo Then
                .Width = System.Web.UI.WebControls.Unit.Parse("280px")
            Else
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
            End If
        End With
        With txtNomeFornecedor
            .Visible = Not flagMostrarCombo
            .Enabled = Not flagMostrarCombo
            If Not flagMostrarCombo Then
                .Width = System.Web.UI.WebControls.Unit.Parse("280px")
            Else
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
            End If
        End With
        Util.AdicionaJsFocus(Me.Page, CType(ddl1, WebControl))
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Not IsPostBack) Then
                btnAlterarVerbaCarimbo.Visible = False
                Me.ViewState.Add("CANCELAR", False)
                carregarCombos()
                WSCAcoesComerciais.isCarimbo = VerificaChamadaCarimbo()
                If WSCAcoesComerciais.isCarimbo Then
                    Me.ObterParametrosQueryString()
                Else
                    Session("DatasetAcordo1") = Nothing
                    If Not (Request.QueryString("CODFILEMP") Is Nothing _
                            Or Request.QueryString("CODPMS") Is Nothing _
                            Or Request.QueryString("DATNGCPMS") Is Nothing) Then

                        ObterAcordo(1, Decimal.Parse(Request.QueryString("CODFILEMP")), Decimal.Parse(Request.QueryString("CODPMS")), Date.Parse(Request.QueryString("DATNGCPMS")))
                        AtualizarTela()
                        Me.CarregarGridCarimbo(0, txtCODPMS.ValueDecimal, True)

                        If Me.GrdVerbaCarimbo.Rows.Count > 0 Then
                            txtCODFRN.Enabled = False
                            cmbNomeFornecedor.Enabled = False
                            txtNomeFornecedor.Enabled = False
                            cmbTIPDSNDSCBNF.Enabled = False
                            txtVLRNGCPMS.Enabled = False
                            btnBuscarFornecedor.Visible = False
                        End If

                        txtCODFRN_ValueChange(sender, Nothing)
                        cmbCODFILEMP.Enabled = False
                        ViewState("flagInclusao") = False
                    Else
                        'Novo
                        cmbCODFILEMP.Enabled = True
                        ViewState("flagInclusao") = True
                        txtDATNGCPMS.Date = Date.Today.Date

                        Try
                            txtNOMACSUSRSIS.Text = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0).NOMACSUSRSIS.Trim
                        Catch ex As Exception
                            btnSalvar.Enabled = False
                            cmdCancelarAcordo.Enabled = False
                            btnImprimir.Enabled = False
                            Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471), consequentemente o sistema não vai permitir salvar esse registro.")
                        End Try

                        cmbCODSITPMS.SelectedValue = "0"
                        txtCODPMS.ValueDecimal = -1

                        cmdCancelarAcordo.Enabled = False
                        btnImprimir.Enabled = False
                        btnVisualizar.Enabled = False

                        Util.AdicionaJsFocus(Me.Page, CType(ddl2, WebControl))
                    End If
                End If


            Else
                Me.RecuperaEstado()
            End If

            GerarJavaScript()
            'RegistrarEventos()
            VerificaSituacao()

            'Verifica se deve mostrar o botão para cancelar acordo
            cmdCancelarAcordo.Visible = permitirCancelarAcordo()



            PreencheCampo()

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        Me.SalvaEstado()
    End Sub

    Private Sub RecuperaEstado()
        If Not WSCAcoesComerciais.dsAcordo Is Nothing Then
            Me.DatasetAcordo1 = WSCAcoesComerciais.dsAcordo
        End If
    End Sub

    Private Sub SalvaEstado()
        WSCAcoesComerciais.dsAcordo = Me.DatasetAcordo1
    End Sub

    Private Sub RegistrarEventos()
        'AddHandler btnSalvar.Click, AddressOf btnSalvar_Click
        AddHandler btnCancelar.Click, AddressOf btnCancelar_Click
        AddHandler btnApagar.Click, AddressOf btnApagar_Click
        AddHandler btnSalvarRecebimento.Click, AddressOf btnSalvarRecebimento_Click
        AddHandler cmbCODFILEMP.SelectedIndexChanged, AddressOf cmbCODFILEMP_SelectedIndexChanged
        AddHandler cmdCancelarAcordo.Click, AddressOf cmdCancelarAcordo_Click
        AddHandler btnInserir.Click, AddressOf btnInserir_Click
    End Sub

    Private Sub carregarCombos()
        Dim datasetFilial As wsAcoesComerciais.dataSetFilial
        Dim datasetEmpenho As wsAcoesComerciais.DatasetEmpenho
        Dim datasetFormaPagamento As wsAcoesComerciais.DatasetFormaPagamento
        Dim datasetSituacaoAcordo As wsAcoesComerciais.DatasetSituacaoAcordo

        'Carregar o combo de filiais
        Util.carregarCmbFilial(Controller.ObterFiliaisExpedicao(1), cmbCODFILEMP, Nothing)

        'Carregar combo com os empenhos
        WSCAcoesComerciais.dsEmpenho = Controller.ObterEmpenhosValidos()
        Util.carregarCmbEmpenho(WSCAcoesComerciais.dsEmpenho, cmbTIPDSNDSCBNF, Nothing)

        'Carregar combo com as formas de pagamento
        WSCAcoesComerciais.dsformaPagamento = Controller.ObterFormasPagamento(String.Empty, -1)
        Me.carregarCmbFormaPagamento(WSCAcoesComerciais.dsformaPagamento, cmbTIPFRMDSCBNF, Nothing)

        'Carrega o combo de situação
        Util.carregarCmbSituacoesAcordo(Controller.ObterSituacoesAcordo(String.Empty), cmbCODSITPMS, Nothing)

    End Sub

    Private Sub carregarComboFilialIncluindoFilialNaoExpedicao(ByVal CODFILEMP As Integer)
        Dim datasetFilial As wsAcoesComerciais.dataSetFilial
        Dim row As wsAcoesComerciais.dataSetFilial.T0112963Row

        row = Me.ObterFilial(CODFILEMP)
        datasetFilial = Controller.ObterFiliaisExpedicao(1)

        If Not row Is Nothing Then
            datasetFilial.T0112963.ImportRow(row)
        End If

        'Carregar o combo de filiais
        Util.carregarCmbFilial(datasetFilial, cmbCODFILEMP, Nothing)

    End Sub

    Private Sub GerarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        cmbTIPDSNDSCBNF.Attributes.Add("onblur", "document.getElementById('btnSalvarRecebimento').focus();return false")

        If permitirEditarAcordo(False) Then
            'btnCancelar.Attributes.Add("OnClick", "javascript:return confirm('Deseja sair sem salvar?')")
        Else
            btnCancelar.Attributes.Remove("OnClick")
        End If

        'Dependendo da situação grava uma mensagem no evento click
        'do botão <cancelar acordo>
        If cmbCODSITPMS.SelectedValue = "0" Then
            cmdCancelarAcordo.Attributes.Add("OnClick", "javascript:return confirm('Cancelamento Total do Acordo?')")
        ElseIf cmbCODSITPMS.SelectedValue = "1" Then
            cmdCancelarAcordo.Attributes.Add("OnClick", "javascript:return confirm('Cancelamento Parcial do Acordo?')")
        End If

        btnApagar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        btnImprimir.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        'btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        btnSalvar.Attributes.Add("OnClick", "javascript:CliqueSalvar(this)")
        btnImprimir.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        btnVisualizar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            If Not permitirEditarAcordo(True) Then Exit Sub

            If flagProcessando Then
                Exit Sub
            End If
            flagProcessando = True
            'AtualizaDataPrevisaoRecebimento()
            AtualizarAcordo()
            Me.SalvarStatusCarimbo(2)
            Util.AdicionaJsFocus(Me.Page, CType(btnImprimir, WebControl))
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        Finally
            flagProcessando = False
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Response.Redirect("AcordoListar.aspx", False)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub btnAlterarVerbaCarimbo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlterarVerbaCarimbo.Click

        Dim Filial As Decimal = CType(cmbCODFILEMP.SelectedValue, Decimal)
        Dim DataNegociacao As String = txtDATNGCPMS.Text
        Dim codFornecedor As Decimal = CType(txtCODFRN.Text, Decimal)
        'Dim nomeFornecedor As String = txtNomeFornecedor.Text
        Dim empenho As Decimal = CType(cmbTIPDSNDSCBNF.SelectedValue, Decimal)
        Dim valorVerba As Decimal
        If txtVLRNGCPMS.Text <> "" Then
            valorVerba = CType(txtVLRNGCPMS.Text, Decimal)
        End If
        Dim NomeFornecedor As String = txtNomeFornecedor.Text
        Dim Acordo As Decimal = txtCODPMS.ValueDecimal
        HttpContext.Current.Response.Redirect("VerbaCarimbo.aspx?codFornecedor=" & codFornecedor & "&empenho=" & empenho & "&valorVerba=" & valorVerba & "&Acordo=" & Acordo & "&Filial=" & Filial & "&DataNegociacao=" & DataNegociacao & "&NomeFornecedor=" & NomeFornecedor & "&tipoAcao=salvar")


    End Sub

    Private Sub CancelaAcordo()
        Dim dstVerbaCarimbo As New wsAcoesComerciais.DatasetVerbaCarimbo
        Dim indexGrid As Integer = 0
        Dim codMcoVbaFrn As Decimal
        For i As Integer = 0 To Me.GrdVerbaCarimbo.Rows.Count - 1
            codMcoVbaFrn = CType(GrdVerbaCarimbo.Rows(i).Cells.FromKey("CARIMBO").Value(), Decimal)
            dstVerbaCarimbo.Merge(Controller.ObterCadCarimboVerbaFornecByPk(codMcoVbaFrn))
            dstVerbaCarimbo.CADMCOVBAFRN.FindByCODMCOVBAFRN(codMcoVbaFrn).INDSTAMCOVBAFRN = 1
            dstVerbaCarimbo.CADMCOVBAFRN.FindByCODMCOVBAFRN(codMcoVbaFrn).CODPMS = 0
            dstVerbaCarimbo.CADMCOVBAFRN.FindByCODMCOVBAFRN(codMcoVbaFrn).DATNGCPMS = New Date(1, 1, 1)
        Next
        Controller.AtualizarCadCarimboVerbaFornec(dstVerbaCarimbo)
    End Sub

    Private Sub cmdCancelarAcordo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelarAcordo.Click
        Me.ViewState("CANCELAR") = True
        If txtCODPMS.ValueDecimal <> -1 Then
            If cmbCODSITPMS.SelectedValue = "0" Then
                cmbCODSITPMS.SelectedValue = "4"
                cmdCancelarAcordo.Visible = False
                ViewState("FlagCancelandoAcordo") = True
            ElseIf cmbCODSITPMS.SelectedValue = "1" Then
                cmbCODSITPMS.SelectedValue = "3"
                cmdCancelarAcordo.Visible = False
                ViewState("FlagCancelandoAcordo") = True
            End If
        End If
        btnSalvar_Click(sender, e)
        Me.CancelaAcordo()
        If CType(Me.ViewState("CANCELAR").ToString, Boolean) = True Then
            Me.ViewState("CANCELAR") = False
            Me.Response.Redirect("AcordoListar.aspx")

        End If
    End Sub

    Private Sub btnInserir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInserir.Click
        If Not permitirEditarItens(True) Then Exit Sub
        'Limpar campos
        txtDATNGCPMSItem.Text = Date.Today.ToString
        If Not Me.GrdVerbaCarimbo.Rows.Count > 0 Then txtVLRNGCPMS.ValueDecimal = 0
        txtDATPRVRCBPMS.Text = String.Empty
        'Controle de foco
        'Page.RegisterStartupScript("eTemp1", "<script>document.getElementById('igtxttxtVLRNGCPMS').focus();</script>")
        'Page.RegisterStartupScript("eTemp2", "<script>document.getElementById('igtxttxtVLRNGCPMS').select();</script>")
        'Controle da edição
        ViewState("flagInclusaoRecebimento") = True
        If dGridRecebimentos.Items.Count = 0 Then
            If Not Session("DatasetAcordo1") Is Nothing Then
                ' CType(Session("DatasetAcordo1"), Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetAcordo).T0118066.Clear()
            End If
        End If
    End Sub

    Private Sub btnSalvarRecebimento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvarRecebimento.Click
        Dim tipoEdicao As Short
        Dim linha As wsAcoesComerciais.DatasetAcordo.T0118066Row
        Dim Vl_TotalAcordo As Decimal

        If Not permitirEditarItens(True) Then Exit Sub

        'Validar Data de Negociação
        If Not IsDate(txtDATNGCPMSItem.Text) Then
            Page.RegisterStartupScript("Alerta", "<script>alert('Data de negociação inválida.');</script>")
            Exit Sub
        End If
        If txtDATPRVRCBPMS.Date < txtDATNGCPMSItem.Date Then
            Page.RegisterStartupScript("Alerta", "<script>alert('Não é permitido previsão de vencimento menor que a data de negociação.');</script>")
            Exit Sub
        End If
        'Validacao Valor
        If txtVLRNGCPMS.ValueDecimal <= 0 Then
            Page.RegisterStartupScript("Alerta", "<script>alert('Valor da verba inválido.');</script>")
            Exit Sub
        End If
        'Validação vencimento
        If Not IsDate(txtDATPRVRCBPMS.Text) Then
            Page.RegisterStartupScript("Alerta", "<script>alert('Previsão de Vencimento inválida.');</script>")
            Exit Sub
        End If
        'If CDate(txtDATPRVRCBPMS.Text) < Date.Today Then
        '    Page.RegisterStartupScript("Alerta", "<script>alert('Previsão de Vencimento inválida, não é pertido anterior a data atual.');</script>")
        '    Exit Sub
        'End If
        'If CDate(txtDATPRVRCBPMS.Text) > Date.Today.AddDays(120) Then
        '    Page.RegisterStartupScript("Alerta", "<script>alert('Previsão de Vencimento inválida, não é pertido data futura com mais de 120 dias.');</script>")
        '    Exit Sub
        'End If

        'Atualiza o dataset
        If Not (Session("DatasetAcordo1") Is Nothing) Then
            Try
                DatasetAcordo1 = CType(Session("DatasetAcordo1"), Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetAcordo)
            Catch ex As Exception
            End Try
        End If

        If DatasetAcordo1 Is Nothing Then
            DatasetAcordo1 = New wsAcoesComerciais.DatasetAcordo
        End If


        'Acrescentar ou salva o registro no dataset de recebimentos
        If DatasetAcordo1.T0118066.Select("CODEMP=1 AND CODFILEMP=" + cmbCODFILEMP.SelectedValue + " AND CODPMS=" + txtCODPMS.Text + " AND DATNGCPMS='" + txtDATNGCPMS.Text + "' AND DATPRVRCBPMS='" + txtDATPRVRCBPMS.Text + "' AND TIPDSNDSCBNF=" + cmbTIPDSNDSCBNF.SelectedValue + " AND TIPFRMDSCBNF=" + cmbTIPFRMDSCBNF.SelectedValue).Length = 0 Then
            tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO
            linha = DatasetAcordo1.T0118066.NewT0118066Row
        Else
            tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO
            linha = CType(DatasetAcordo1.T0118066.Select("CODEMP=1 AND CODFILEMP=" + cmbCODFILEMP.SelectedValue + " AND CODPMS=" + txtCODPMS.Text + " AND DATNGCPMS='" + txtDATNGCPMS.Text + "' AND DATPRVRCBPMS='" + txtDATPRVRCBPMS.Text + "' AND TIPDSNDSCBNF=" + cmbTIPDSNDSCBNF.SelectedValue + " AND TIPFRMDSCBNF=" + cmbTIPFRMDSCBNF.SelectedValue)(0), wsAcoesComerciais.DatasetAcordo.T0118066Row)
            linha.BeginEdit()
        End If

        With linha
            .CODEMP = 1
            .CODFILEMP = CDec(cmbCODFILEMP.SelectedValue)
            .CODPMS = txtCODPMS.ValueDecimal
            .DATNGCPMS = CDate(txtDATNGCPMS.Text).Date
            .DATPRVRCBPMS = CDate(txtDATPRVRCBPMS.Text)
            .TIPDSNDSCBNF = CDec(cmbTIPDSNDSCBNF.SelectedValue)
            .TIPFRMDSCBNF = CDec(cmbTIPFRMDSCBNF.SelectedValue)
            .VLRNGCPMS = txtVLRNGCPMS.ValueDecimal
            .VLREFTPMS = txtVLRNGCPMS.ValueDecimal
        End With
        If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
            DatasetAcordo1.EnforceConstraints = False
            DatasetAcordo1.T0118066.AddT0118066Row(linha)
        ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
            linha.EndEdit()
        End If
        'Salva o Dataset na seção
        Session("DatasetAcordo1") = DatasetAcordo1
        'Atualiza o grid
        dGridRecebimentos.DataBind()
        'VALOR TOTAL DO ACORDO
        Vl_TotalAcordo = 0
        For Each linhaRecebecimento As wsAcoesComerciais.DatasetAcordo.T0118066Row In DatasetAcordo1.T0118066
            If linhaRecebecimento.RowState <> DataRowState.Deleted Then
                If Not linhaRecebecimento.IsNull("VLRNGCPMS") Then
                    Vl_TotalAcordo += linhaRecebecimento.VLRNGCPMS
                End If
            End If
        Next
        txtValorTotal.ValueDecimal = Vl_TotalAcordo
        'Controle de foco
        Util.AdicionaJsFocus(Me.Page, CType(btnSalvar, WebControl))
        If WSCAcoesComerciais.isCarimbo Then
            Me.btnAlterarVerbaCarimbo.Enabled = False
            Me.btnInserir.Enabled = False
            Me.btnSalvarRecebimento.Enabled = False
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            If ValidarRelatorio() = False Then
                Exit Sub
            End If

            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = True

            ImprimirAcordo()

            Util.AdicionaJsFocus(Me.Page, CType(btnCancelar, WebControl))
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            If ValidarRelatorio() = False Then
                Exit Sub
            End If

            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = False

            ImprimirAcordo()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Protected Function obterDESFRMDSCBNF(ByVal codigo As Decimal) As String
        Dim result As String = ""

        Try
            result = WSCAcoesComerciais.dsformaPagamento.T0113552.FindByTIPFRMDSCBNF(codigo).DESFRMDSCBNF()
        Catch ex As Exception
        End Try

        Return result
    End Function

    Protected Function obterDESDSNDSCBNF(ByVal codigo As Decimal) As String
        Dim result As String = ""

        Try
            result = WSCAcoesComerciais.dsEmpenho.T0109059.FindByTIPDSNDSCBNF(codigo).DESDSNDSCBNF
        Catch ex As Exception
        End Try

        Return result
    End Function

    Private Sub btnNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNovo.Click
        Controller.NavegarInserirAcordo()
    End Sub

    Private Function ObterFilial(ByVal CODFILEMP As Integer) As wsAcoesComerciais.dataSetFilial.T0112963Row
        Dim ds As wsAcoesComerciais.dataSetFilial
        ds = Controller.ObterFiliais(1)
        Return ds.T0112963.FindByCODEMPCODFILEMP(1, CODFILEMP)
    End Function

#Region "Relatório"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Validção para emissão do relatório
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	16/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function ValidarRelatorio() As Boolean
        Dim NumeroItem As Decimal

        Dim mensagemErro As String = String.Empty
        Dim Qt_Recebimentos As Integer

        Try
            ValidarRelatorio = True

            'Se o acordo está na tela não é necessário validar
            'If DatasetAcordo1.T0118058.Rows.Count = 0 Then
            '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '    mensagemErro &= "Nao Existe promessa com este código"
            'End If

            If CType(ViewState("flagInclusao"), Boolean) = True Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "Salve o extra acordo antes de imprimir"
            End If

            If mensagemErro.Trim() <> String.Empty Then
                Page.RegisterStartupScript("Alerta", "<script>alert('" & (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1) & "');</script>")
                Return False
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Sub ImprimirAcordo()
        ' Obter dados do relatório e guardar na seção
        WSCAcoesComerciais.dsRelatorioAcordoAcoesComerciais = Controller.ObterRelatorioAcordoAcoesComerciais_232(CInt("1"), Integer.Parse(cmbCODFILEMP.SelectedValue), txtCODPMS.ValueInt, txtDATNGCPMS.Date)
        ' Guarda o nome do relatório na seção
        WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "cby002ka.rpt"

        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")

    End Sub

#End Region

#Region "Acordo"

    Private Function Validar(ByVal tipoEdicao As Short) As Boolean
        Dim NumeroItem As Decimal
        Dim DatasetAcordoAnterior As wsAcoesComerciais.DatasetAcordo

        Dim mensagemErro As String = String.Empty
        Dim Qt_Recebimentos As Integer

        Try
            Validar = True

            'Situação do acordo
            If cmbCODSITPMS.SelectedValue = "1" Then
            End If

            'Quantidade de recebimentos
            For Each linha As wsAcoesComerciais.DatasetAcordo.T0118066Row In DatasetAcordo1.T0118066
                If linha.RowState <> DataRowState.Deleted Then
                    Qt_Recebimentos += 1
                End If
            Next
            If Qt_Recebimentos = 0 Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "é obrigatório digitar no mínimo 1 (um) recebimento"
            End If

            'Data de negociação do acordo
            If Not (IsDate(txtDATNGCPMS.Text)) Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "data negociação inválida"
            ElseIf CDate(txtDATNGCPMS.Text) = Date.Now And tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "só é permitido alterar acordo cuja data de negociação seja igual à data atual"
            End If

            'Fornecedor
            If txtCODFRN.ValueDecimal = 0 Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "fornecedor não informado"
            ElseIf Not (IsNumeric(cmbNomeFornecedor.SelectedValue)) Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "fornecedor não localizado"
            ElseIf CDec(cmbNomeFornecedor.SelectedValue) <> txtCODFRN.ValueDecimal Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "o fornecedor selecionado no combo não corresponde ao codigo digitado"
            End If

            'Caso seja alteração verifica se o acordo pode ser alterado
            If CType(ViewState("flagInclusao"), Boolean) = False Then
                'Consulta o acordo novamente no banco, isso é necessário
                'porque o sistema vai comparar alguns atributos antes da
                'alterãção com após a alteração
                DatasetAcordoAnterior = Controller.ObterAcordo(1, _
                                                               Decimal.Parse(cmbCODFILEMP.SelectedValue), _
                                                               txtCODPMS.ValueDecimal, _
                                                               Date.Parse(txtDATNGCPMS.Text))

                'Verifica se a procedure pode ser alterada
                If ((DatasetAcordoAnterior.T0118058(0).CODFILEMP <> DatasetAcordo1.T0118058(0).CODFILEMP) Or _
                   (DatasetAcordoAnterior.T0118058(0).CODPMS <> DatasetAcordo1.T0118058(0).CODPMS) Or _
                   (DatasetAcordoAnterior.T0118058(0).DATNGCPMS <> DatasetAcordo1.T0118058(0).DATNGCPMS) Or _
                   (DatasetAcordoAnterior.T0118058(0).CODFRN <> DatasetAcordo1.T0118058(0).CODFRN)) Then

                    If Date.Parse(txtDATNGCPMS.Text) <> Date.Today Then
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "Só é permitido alterar promessas cuja data de negociação seja igual à data atual"
                    End If
                End If
            End If

            ''Comentário
            'If txtDESMSGUSR.Text.Trim.Length = 0 Then
            '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '    mensagemErro &= "é obrigatório informar o comentário"
            'End If

            If mensagemErro.Trim() <> String.Empty Then
                Page.RegisterStartupScript("Alerta", "<script>alert('" & (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1) & "');</script>")
                Return False
            End If
            lblErro.Visible = False
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Public Sub ObterAcordo(ByVal CODEMP As Decimal, _
                           ByVal CODFILEMP As Decimal, _
                           ByVal CODPMS As Decimal, _
                           ByVal DATNGCPMS As Date)
        Try
            Dim Ic_BuscouSecao As Boolean
            Dim Vl_TotalAcordo As Decimal

            If Not (Session("DatasetAcordo1") Is Nothing) Then
                Try
                    DatasetAcordo1 = CType(Session("DatasetAcordo1"), Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetAcordo)
                    Ic_BuscouSecao = True
                Catch ex As Exception
                    Ic_BuscouSecao = False
                End Try
            End If

            If Not Ic_BuscouSecao Then
                DatasetAcordo1 = Controller.ObterAcordo(CODEMP, _
                                                        CODFILEMP, _
                                                        CODPMS, _
                                                        DATNGCPMS)
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Public Sub AtualizarTela()
        Try
            Dim Vl_TotalAcordo As Decimal

            If DatasetAcordo1.T0118058.Rows.Count > 0 Then
                With DatasetAcordo1.T0118058(0)
                    'CODIGO DA FILIAL DA EMPRESA
                    If Not .IsNull("CODFILEMP") Then
                        If cmbCODFILEMP.Items.FindByValue(.CODFILEMP.ToString) Is Nothing Then
                            carregarComboFilialIncluindoFilialNaoExpedicao(CType(.CODFILEMP, Integer))
                        End If
                        If cmbCODFILEMP.Items.FindByValue(.CODFILEMP.ToString) Is Nothing Then
                            cmbCODFILEMP.Items.Add(New ListItem("NÃO ENCONTRADA " & .CODFILEMP.ToString, .CODFILEMP.ToString))
                        End If
                        cmbCODFILEMP.SelectedValue = .CODFILEMP.ToString
                    End If
                    'CODIGO FORNECEDOR
                    If Not .IsNull("CODFRN") Then
                        txtCODFRN.Text = .CODFRN.ToString
                    End If

                    'CODIGO PROMESSA
                    If Not .IsNull("CODPMS") Then
                        txtCODPMS.Text = .CODPMS.ToString
                    End If
                    'CODIGO SITUACAO PROMESSA
                    If Not .IsNull("CODSITPMS") Then
                        cmbCODSITPMS.SelectedValue = .CODSITPMS.ToString
                    End If
                    'DATA DA NEGOCIACAO DA PROMESSA
                    If Not .IsNull("DATNGCPMS") Then
                        txtDATNGCPMS.Text = .DATNGCPMS.ToString
                    End If
                    'DESCRIÇÃO DO CARGO DO CONTATO DO FORNECEDOR
                    If Not .IsNull("DESCGRCTOFRN") Then
                        txtDESCGRCTOFRN.Text = .DESCGRCTOFRN.Trim()
                    End If
                    'DESCRIÇÃO DA MENSAGEM USUÁRIO
                    If Not .IsNull("DESMSGUSR") Then
                        txtDESMSGUSR.Text = .DESMSGUSR.Trim()
                    End If
                    'NOME ACESSO USUARIO SISTEMA
                    If Not .IsNull("NOMACSUSRSIS") Then
                        txtNOMACSUSRSIS.Text = .NOMACSUSRSIS.Trim()
                    End If
                    'NOME CONTATO FORNECEDOR
                    If Not .IsNull("NOMCTOFRN") Then
                        txtNOMCTOFRN.Text = .NOMCTOFRN.Trim()
                    End If
                    'IDENTIFICA O PEDIDO DE COMPRA
                    If Not .IsNull("NUMPEDCMP") Then
                        txtNUMPEDCMP.Text = .NUMPEDCMP.ToString
                    End If
                    'NUMERO DE TELEFONE DE CONTATO DO FORNECEDOR
                    If Not .IsNull("NUMTLFCTOFRN") Then
                        txtNUMTLFCTOFRN.Text = .NUMTLFCTOFRN.Trim()
                    End If
                    'VALOR TOTAL DO ACORDO
                    Vl_TotalAcordo = 0
                    For Each linha As wsAcoesComerciais.DatasetAcordo.T0118066Row In DatasetAcordo1.T0118066
                        If linha.RowState <> DataRowState.Deleted Then
                            If Not linha.IsNull("VLRNGCPMS") Then
                                Vl_TotalAcordo += linha.VLRNGCPMS
                            End If
                        End If
                    Next
                    txtValorTotal.ValueDecimal = Vl_TotalAcordo
                End With
                'Salva o dataset na seção
                Session("DatasetAcordo1") = DatasetAcordo1


                If Me.VerificaChamadaCarimbo() Then
                    txtCODFRN.Enabled = False
                    cmbNomeFornecedor.Enabled = False
                    txtNomeFornecedor.Enabled = False
                    cmbTIPDSNDSCBNF.Enabled = False
                    txtVLRNGCPMS.Enabled = False
                    btnBuscarFornecedor.Visible = False
                End If

            End If

            'Atualizar grid
            dGridRecebimentos.DataSource = Me.DatasetAcordo1
            dGridRecebimentos.DataBind()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Public Sub GeraCapaExtraAcordo()
        Dim linha As wsAcoesComerciais.DatasetAcordo.T0118058Row
        Dim tipoEdicao As Short
        Dim Filial As Decimal
        Dim DataNegociacao As Date
        Dim valorVerba As Decimal
        Dim Acordo As Decimal

        If Me.DatasetAcordo1 Is Nothing Then
            Me.DatasetAcordo1 = New wsAcoesComerciais.DatasetAcordo
        End If

        If Request.QueryString("tipoAcao").ToString = "salvar" Then
            linha = DatasetAcordo1.T0118058.NewT0118058Row
            tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO
        Else
            DatasetAcordo1.T0118058.Clear()
            Filial = CType(Request.QueryString("Filial").ToString, Decimal)
            DataNegociacao = CType(Request.QueryString("DataNegociacao").ToString, Date)
            valorVerba = CType(Request.QueryString("valorVerba").ToString, Decimal)
            Acordo = CType(Request.QueryString("Acordo").ToString, Decimal)
            DatasetAcordo1 = Controller.ObterAcordo(1, Filial, Acordo, DataNegociacao)
            If Not WSCAcoesComerciais.dsAcordo Is Nothing Then
                DatasetAcordo1.Merge(WSCAcoesComerciais.dsAcordo.T0118066)
            End If
            If DatasetAcordo1.T0118058.Count > 0 Then
                Me.AtualizarTela()
                linha = DatasetAcordo1.T0118058(0)
                tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO
            End If
        End If

        Try
            'Transfere os dados do formulário para o DataSet
            With linha
                'CODIGO EMPRESA
                .CODEMP = 1
                'CODIGO DA FILIAL DA EMPRESA
                .CODFILEMP = Decimal.Parse(cmbCODFILEMP.SelectedValue)
                'CODIGO FORNECEDOR
                .CODFRN = txtCODFRN.ValueDecimal
                'CODIGO PROMESSA
                .CODPMS = txtCODPMS.ValueDecimal
                'DATA DE CADASTRO DO ACORDO
                .DATCADPMS = Date.Today.Date
                'DATA DA NEGOCIACAO DA PROMESSA
                .DATNGCPMS = Date.Parse(txtDATNGCPMS.Text).Date
                'DESCRIÇÃO DO CARGO DO CONTATO DO FORNECEDOR
                .DESCGRCTOFRN = txtDESCGRCTOFRN.Text.ToUpper()
                'DESCRIÇÃO DA MENSAGEM USUÁRIO
                .DESMSGUSR = txtDESMSGUSR.Text.ToUpper()
                'NOME ACESSO USUARIO SISTEMA
                .NOMACSUSRSIS = txtNOMACSUSRSIS.Text
                'NOME CONTATO FORNECEDOR
                .NOMCTOFRN = txtNOMCTOFRN.Text.ToUpper()
                'NUMERO DE TELEFONE DE CONTATO DO FORNECEDOR
                .NUMTLFCTOFRN = txtNUMTLFCTOFRN.Text.ToUpper()

                'CANCELAMENTO DO ACORDO
                If tipoEdicao <> Constants.TIPO_EDICAO_INCLUSAO Then
                    If cmbCODSITPMS.SelectedValue = "3" Or cmbCODSITPMS.SelectedValue = "4" Then
                        If Not (.CODSITPMS = 3 Or .CODSITPMS = 4) Then
                            'DATA DE CANCELAMENTO DO ACORDO
                            .DATCNCPED = Date.Now
                            'USUÁRIO QUE CANCELOU O ACORDO
                            .NOMUSRCNCPED = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0).NOMACSUSRSIS.Trim
                        End If
                    End If
                End If

                'CODIGO SITUACAO PROMESSA
                If IsNumeric(cmbCODSITPMS.SelectedValue) Then
                    .CODSITPMS = CDec(cmbCODSITPMS.SelectedValue)
                End If

            End With
            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                DatasetAcordo1.EnforceConstraints = False
                DatasetAcordo1.T0118058.AddT0118058Row(linha)
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                linha.EndEdit()
            End If

            txtCODPMS.ValueDecimal = Controller.AtualizarAcordo(DatasetAcordo1)

            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                'Util.AdicionaJsAlert(Me.Page, "Capa Extra Acordo gerado com sucesso!!")
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                txtCODPMS.ValueDecimal = Acordo
                'Util.AdicionaJsAlert(Me.Page, "Capa Extra Atualizado com sucesso!!")
            End If
            Me.CarregarGridCarimbo(4, 0)
            Me.SalvarStatusCarimbo(4)
            Me.CarregarGridCarimbo(4, txtCODPMS.ValueDecimal)

            'If Not Me.dGridRecebimentos.Items.Count > 0 Then
            '    Me.dGridRecebimentos.Visible = False
            'Else
            '    Me.dGridRecebimentos.Visible = True
            'End If


        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub SalvarStatusCarimbo(ByVal INDSTAMCOVBAFRN As Integer)
        Dim dstVerbaCarimbo As New wsAcoesComerciais.DatasetVerbaCarimbo
        Dim codMcoVbaFrn As Decimal
        If GrdVerbaCarimbo.Rows.Count > 0 Then
            For Index As Integer = 0 To GrdVerbaCarimbo.Rows.Count - 1
                codMcoVbaFrn = CType(GrdVerbaCarimbo.Rows(Index).Cells.FromKey("CARIMBO").Value(), Decimal)
                dstVerbaCarimbo.Merge(Controller.ObterCadCarimboVerbaFornecByPk(codMcoVbaFrn))
                If INDSTAMCOVBAFRN = 2 OrElse dstVerbaCarimbo.CADMCOVBAFRN.FindByCODMCOVBAFRN(codMcoVbaFrn).CODPMS = 0 Then
                    dstVerbaCarimbo.CADMCOVBAFRN.FindByCODMCOVBAFRN(codMcoVbaFrn).CODPMS = txtCODPMS.ValueDecimal
                    dstVerbaCarimbo.CADMCOVBAFRN.FindByCODMCOVBAFRN(codMcoVbaFrn).DATNGCPMS = CType(txtDATNGCPMS.Text, Date)
                    dstVerbaCarimbo.CADMCOVBAFRN.FindByCODMCOVBAFRN(codMcoVbaFrn).INDSTAMCOVBAFRN = INDSTAMCOVBAFRN
                End If
            Next
            Controller.AtualizarCadCarimboVerbaFornec(dstVerbaCarimbo)
        End If

    End Sub


    Public Sub AtualizarAcordo()
        Dim linha As wsAcoesComerciais.DatasetAcordo.T0118058Row
        Dim tipoEdicao As Short

        Try
            If IsNumeric(cmbCODFILEMP.SelectedValue) And _
               IsNumeric(txtCODPMS.Text) And _
               IsDate(txtDATNGCPMS.Text) Then

                If CType(ViewState("flagInclusao"), Boolean) Then

                    DatasetAcordo1 = Controller.ObterAcordo(1, _
                                                            Decimal.Parse(cmbCODFILEMP.SelectedValue), _
                                                            txtCODPMS.ValueDecimal, _
                                                            Date.Parse(txtDATNGCPMS.Text))

                    If DatasetAcordo1.T0118058.Rows.Count > 0 Then
                        Page.RegisterStartupScript("Alerta", "<script>alert('Inclusão não permitida, já existe esse registro no banco de dados. Os dados do banco foram carregados.');</script>")
                        ObterAcordo(1, _
                                     Decimal.Parse(cmbCODFILEMP.SelectedValue), _
                                     txtCODPMS.ValueDecimal, _
                                     Date.Parse(txtDATNGCPMS.Text))

                        ViewState("flagInclusao") = False
                        Session("DatasetAcordo1") = DatasetAcordo1
                        Exit Try
                    End If
                End If

                ObterAcordo(1, _
                             Decimal.Parse(cmbCODFILEMP.SelectedValue), _
                             txtCODPMS.ValueDecimal, _
                             Date.Parse(txtDATNGCPMS.Text))

            End If

            If Not Me.Request.QueryString("tipoAcao") Is Nothing Then
                DatasetAcordo1.T0118058.Clear()
                DatasetAcordo1.Merge(Controller.ObterAcordo(1, _
                             Decimal.Parse(cmbCODFILEMP.SelectedValue), _
                             txtCODPMS.ValueDecimal, _
                             Date.Parse(txtDATNGCPMS.Text)))
            End If



            If DatasetAcordo1.T0118058.Rows.Count > 0 Then 'provavel local de erro
                'Update
                DatasetAcordo1.T0118058.AcceptChanges()
                linha = DatasetAcordo1.T0118058(0)
                DatasetAcordo1.T0118058(0).CODPMS = txtCODPMS.ValueDecimal
                tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO
                linha.BeginEdit()
            Else
                'Insert
                linha = DatasetAcordo1.T0118058.NewT0118058Row
                tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO
            End If
            'Transfere os dados do formulário para o DataSet
            With linha
                If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                    'CODIGO EMPRESA
                    .CODEMP = 1
                    'CODIGO DA FILIAL DA EMPRESA
                    .CODFILEMP = Decimal.Parse(cmbCODFILEMP.SelectedValue)
                    'CODIGO PROMESSA
                    .CODPMS = txtCODPMS.ValueDecimal
                    'DATA DE CADASTRO DO ACORDO
                    .DATCADPMS = Date.Today.Date
                    'DATA DA NEGOCIACAO DA PROMESSA
                    .DATNGCPMS = Date.Parse(txtDATNGCPMS.Text).Date
                End If
                'CODIGO FORNECEDOR
                .CODFRN = txtCODFRN.ValueDecimal
                'DESCRIÇÃO DO CARGO DO CONTATO DO FORNECEDOR
                .DESCGRCTOFRN = txtDESCGRCTOFRN.Text.ToUpper()
                'DESCRIÇÃO DA MENSAGEM USUÁRIO
                .DESMSGUSR = txtDESMSGUSR.Text.ToUpper()
                'NOME ACESSO USUARIO SISTEMA
                .NOMACSUSRSIS = txtNOMACSUSRSIS.Text
                'NOME CONTATO FORNECEDOR
                .NOMCTOFRN = txtNOMCTOFRN.Text.ToUpper()
                'NUMERO DE TELEFONE DE CONTATO DO FORNECEDOR
                .NUMTLFCTOFRN = txtNUMTLFCTOFRN.Text.ToUpper()

                'CANCELAMENTO DO ACORDO
                If tipoEdicao <> Constants.TIPO_EDICAO_INCLUSAO Then
                    If cmbCODSITPMS.SelectedValue = "3" Or cmbCODSITPMS.SelectedValue = "4" Then
                        If Not (.CODSITPMS = 3 Or .CODSITPMS = 4) Then
                            'DATA DE CANCELAMENTO DO ACORDO
                            .DATCNCPED = Date.Now
                            'USUÁRIO QUE CANCELOU O ACORDO
                            .NOMUSRCNCPED = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0).NOMACSUSRSIS.Trim
                        End If
                    End If
                End If

                'CODIGO SITUACAO PROMESSA
                If IsNumeric(cmbCODSITPMS.SelectedValue) Then
                    .CODSITPMS = CDec(cmbCODSITPMS.SelectedValue)
                End If

            End With
            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                DatasetAcordo1.EnforceConstraints = False
                DatasetAcordo1.T0118058.AddT0118058Row(linha)
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                linha.EndEdit()
            End If

            If Not Validar(tipoEdicao) Then
                Exit Sub
            End If

            Dim acordoAux As Decimal = 0
            If txtCODPMS.ValueDecimal > 0 Then
                acordoAux = Me.txtCODPMS.ValueDecimal
            End If

            txtCODPMS.ValueDecimal = Controller.AtualizarAcordo(DatasetAcordo1)
            If acordoAux > 0 And Me.txtCODPMS.ValueDecimal = 0 Then
                Me.txtCODPMS.ValueDecimal = acordoAux
            End If
            Me.SalvarStatusCarimbo(2)

            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                Util.AdicionaJsAlert(Me.Page, "Registro incluído")
                Me.btnSalvar.Enabled = False
                ViewState("flagInclusao") = False
                cmdCancelarAcordo.Enabled = True
                btnImprimir.Enabled = True
                btnVisualizar.Enabled = True
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO And CType(ViewState("CANCELAR").ToString, Boolean) = False Then
                Me.Response.Redirect("AcordoListar.aspx", False)
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function permitirEditarAcordo(ByVal flagMostrarMensagem As Boolean) As Boolean

        'Situação do acordo
        If Not acordoEstaSendoCancelado() Then
            If IsNumeric(cmbCODSITPMS.SelectedValue) Then
                If CDec(cmbCODSITPMS.SelectedValue) >= 1 Then
                    If flagMostrarMensagem Then
                        Page.RegisterStartupScript("Alerta", "<script>alert('Não é permitido salvar acordo com essa situação');</script>")
                    End If
                    Return False
                End If
            End If
        End If

        'Numero do pedido
        If IsNumeric(txtNUMPEDCMP.Text) Then
            If CDec(txtNUMPEDCMP.Text) <> 0 Then
                If flagMostrarMensagem Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Não é permitido salvar o acordo quando o pedido de compra foi definido');</script>")
                End If
                Return False
            End If
        End If

        If btnSalvar.Enabled = False And cmbNomeFornecedor.Enabled = False Then
            Return False
        End If

        Return True
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Verifica se o acordo pode ser cancelado
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	16/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function permitirCancelarAcordo() As Boolean
        Dim result As Boolean = False

        Try
            If Controller.ObterUsuariosCompraLogadoSistema.T0113471(0).TIPUSRSIS = "X" _
                And cmbCODSITPMS.SelectedValue = "0" _
                And Val(cmbCODSITPMS.SelectedValue) < 2 _
                And txtNUMPEDCMP.Text = String.Empty Then
                result = True
            End If
        Catch ex As Exception
        End Try

        Return result
    End Function

    Private Function acordoEstaSendoCancelado() As Boolean
        If ViewState("FlagCancelandoAcordo") Is Nothing Then
            Return False
        End If
        Return CType(ViewState("FlagCancelandoAcordo"), Boolean)
    End Function

    Private Sub cmbCODFILEMP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Page.RegisterStartupScript("eTemp1", "<script>document.getElementById('igtxttxtCODFRN').focus();</script>")
    End Sub

    Private Sub VerificaSituacao()
        If Val(cmbCODSITPMS.SelectedValue) > 1 Or Val(txtNUMPEDCMP.Text) <> 0 Then
            'cmbCODSITPMS.Enabled = False
            txtDESMSGUSR.Enabled = False
            txtNOMCTOFRN.Enabled = False
            txtNUMTLFCTOFRN.Enabled = False
            txtDESCGRCTOFRN.Enabled = False
            btnInserir.Enabled = False
            btnSalvarRecebimento.Enabled = False
            If Val(txtNUMPEDCMP.Text) = 0 Then
                Util.AdicionaJsAlert(Me, "Atenção! Promessa Cancelada ou foi totalmente atendida")
            End If
            Exit Sub
        Else
            If Val(cmbCODSITPMS.SelectedValue) = 0 Or Val(cmbCODSITPMS.SelectedValue) = 1 Then
                txtNOMCTOFRN.Enabled = True
                txtNUMTLFCTOFRN.Enabled = True
                txtDESCGRCTOFRN.Enabled = True
                'cmbCODSITPMS.Enabled = True
                btnInserir.Enabled = True
                btnSalvarRecebimento.Enabled = True
                txtDESMSGUSR.Enabled = True
            End If
        End If

        If WSCAcoesComerciais.isCarimbo AndAlso Me.dGridRecebimentos.Items.Count > 0 Then
            btnInserir.Enabled = False
            btnSalvarRecebimento.Enabled = False
        End If

        TrancarCamposSeDataDiferenteAtual()
    End Sub

    Private Sub TrancarCamposSeDataDiferenteAtual()
        'Pode editar somente o campo txtDESMSGUSR,os demais são desabiltiados
        If txtDATNGCPMS.Date <> Date.Today Then
            txtCODFRN.Enabled = False
            cmbNomeFornecedor.Enabled = False
            txtNomeFornecedor.Enabled = False
            btnBuscarFornecedor.Enabled = False
            txtNOMCTOFRN.Enabled = False
            txtNUMTLFCTOFRN.Enabled = False
            txtDESCGRCTOFRN.Enabled = False
            btnInserir.Enabled = False
            btnSalvarRecebimento.Enabled = False
            txtDATNGCPMSItem.Enabled = False
            txtVLRNGCPMS.Enabled = False
            cmbTIPFRMDSCBNF.Enabled = False
            txtDATPRVRCBPMS.Enabled = False
            cmbTIPDSNDSCBNF.Enabled = False
        End If
    End Sub

    Private Sub carregarCmbFormaPagamento(ByRef ds As wsAcoesComerciais.DatasetFormaPagamento, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem, Optional ByRef flagLimparComboAntesPreencher As Boolean = True)
        With cmb
            If flagLimparComboAntesPreencher Then
                .Items.Clear()
            End If
            For Each linha As wsAcoesComerciais.DatasetFormaPagamento.T0113552Row In ds.T0113552.Select("", "TIPFRMDSCBNF")
                If linha.TIPFRMDSCBNF = 3 Or _
                   linha.TIPFRMDSCBNF = 8 Or _
                   linha.TIPFRMDSCBNF = 13 Then
                    .Items.Add(New ListItem(linha.TIPFRMDSCBNF.ToString & " - " & linha.DESFRMDSCBNF, linha.TIPFRMDSCBNF.ToString))
                End If
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

#End Region

#Region "Recebimento"

    Private Sub dGridRecebimentos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dGridRecebimentos.ItemDataBound
        Select Case e.Item.ItemType
            Case ListItemType.Item, ListItemType.AlternatingItem
                CType(e.Item.Cells(0).FindControl("imbExcluir"), ImageButton).Attributes.Add("onClick", "javascript:return confirm('Deseja realmente excluir este registro?');")
        End Select
    End Sub

    Private Sub dGridRecebimentos_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dGridRecebimentos.ItemCommand
        Try
            If e.CommandName = "grdExcluir" Then

                If Val(cmbCODSITPMS.SelectedValue) > 1 Then
                    Util.AdicionaJsAlert(Me, "Acordo não está aberto, não é permitido excluir recebimento")
                    Exit Sub
                End If
                If Val(txtNUMPEDCMP.Text) <> 0 Then
                    Util.AdicionaJsAlert(Me, "Existe pedido de compra relacionado, não é permitido excluir recebimento")
                    Exit Sub
                End If
                If txtDATNGCPMS.Date <> Date.Today Then
                    Util.AdicionaJsAlert(Me.Page, "Data de negociação diferente da data atual, não é permitido exclui recebimento")
                    Exit Sub
                End If

                DatasetAcordo1.T0118066.Item(e.Item.DataSetIndex).Delete()
                dGridRecebimentos.DataBind()

                If DatasetAcordo1.T0118066.Rows.Count > 0 Then
                        Me.btnAlterarVerbaCarimbo.Enabled = False
                Else
                    Me.btnAlterarVerbaCarimbo.Enabled = True
                    Me.btnInserir.Enabled = True
                    Me.btnAlterarVerbaCarimbo.Enabled = True
                End If

                If WSCAcoesComerciais.isCarimbo AndAlso Me.dGridRecebimentos.Items.Count = 0 Then
                    Me.btnInserir.Enabled = True
                    Me.btnSalvarRecebimento.Enabled = True
                End If
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub dGridRecebimentos_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dGridRecebimentos.PageIndexChanged
        Try
            DatasetAcordo1 = WSCAcoesComerciais.dsAcordo
            Me.dGridRecebimentos.CurrentPageIndex = e.NewPageIndex
            dGridRecebimentos.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Private Function permitirEditarItens(ByVal flagMostrarMensagem As Boolean) As Boolean
        If IsNumeric(cmbCODSITPMS.SelectedValue) Then
            If CDec(cmbCODSITPMS.SelectedValue) >= 1 Then
                If flagMostrarMensagem Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Não é permitido editar os recebimentos para essa situação do acordo');</script>")
                End If
                Return False
            End If
        End If
        Return True
    End Function

    Private Function VerificaChamadaCarimbo() As Boolean
        If Not Request.QueryString("tipoAcao") Is Nothing Then
            Return True
        End If
        Return False
    End Function

    Private Sub ObterParametrosQueryString()
        Dim datasetFornecedor As wsAcoesComerciais.dataSetDivisaoFornecedor
        txtDATNGCPMS.Text = Date.Today.Date.ToString
        Dim codFornecedor As Decimal = CType(Request.QueryString("codFornecedor").ToString, Decimal)
        Dim nomeFornecedor As String = (Request.QueryString("nomeFornecedor").ToString)
        Dim empenho As Decimal = CType(Request.QueryString("empenho").ToString, Decimal)
        Dim valorVerba As Decimal = CType(Request.QueryString("valorVerba").ToString, Decimal)

        txtCODFRN.Text = codFornecedor.ToString
        txtNomeFornecedor.Text = nomeFornecedor.ToString
        cmbTIPDSNDSCBNF.SelectedValue = empenho.ToString.ToUpper
        txtVLRNGCPMS.ValueDecimal = valorVerba

        datasetFornecedor = Controller.ObterDivisaoFornecedor(1, CLng(txtCODFRN.Text))
        If datasetFornecedor.T0100426.Rows.Count > 0 Then
            cmbNomeFornecedor.Items.Clear()
            For Contador As Integer = 0 To datasetFornecedor.T0100426.Count - 1
                cmbNomeFornecedor.Items.Add(datasetFornecedor.T0100426(Contador).NOMFRN.Trim)
                cmbNomeFornecedor.Items(Contador).Value = datasetFornecedor.T0100426(Contador).CODFRN.ToString
            Next
        End If

        If Not Me.cmbNomeFornecedor.Items.FindByValue(codFornecedor.ToString) Is Nothing Then
            Me.cmbNomeFornecedor.SelectedValue = codFornecedor.ToString
        End If

        txtCODFRN.Enabled = False
        txtNomeFornecedor.Enabled = False
        cmbNomeFornecedor.Enabled = False
        cmbTIPDSNDSCBNF.Enabled = False
        txtVLRNGCPMS.Enabled = False
        btnBuscarFornecedor.Visible = False
        Dim indFilDtb As Decimal = CType(Request.QueryString("indFilDtb").ToString, Decimal)
        Me.cmbCODFILEMP.Enabled = Not (indFilDtb = 1)
        If Not Me.cmbCODFILEMP.Enabled Then
            Me.cmbCODFILEMP.SelectedValue = Request.QueryString("codFilEmp")
        End If
        Try
            txtNOMACSUSRSIS.Text = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0).NOMACSUSRSIS.Trim
            Me.GeraCapaExtraAcordo()
        Catch ex As Exception
            btnSalvar.Enabled = False
            cmdCancelarAcordo.Enabled = False
            btnImprimir.Enabled = False
            Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471), consequentemente o sistema não vai permitir salvar esse registro.")
        End Try

    End Sub

    Private Sub CarregarGridCarimbo(ByVal indStaMcoVbaFrn As Decimal, ByVal acordo As Decimal, Optional ByVal flagPesquisa As Boolean = False)
        GrdVerbaCarimbo.Rows.Clear()
        Dim Fornecedor As Decimal = 0
        Dim Empenho As Decimal = 0
        Dim controle As Boolean
        Dim controleSalvar As Boolean

        Dim dstVerbaCarimbo As New wsAcoesComerciais.DatasetVerbaCarimbo

        If txtCODFRN.Text <> String.Empty Then
            Fornecedor = CType(txtCODFRN.Text, Decimal)
        End If

        If cmbTIPDSNDSCBNF.SelectedValue <> "" Then
            Empenho = CType(cmbTIPDSNDSCBNF.SelectedValue, Decimal)
        End If

        If flagPesquisa = True Then
            dstVerbaCarimbo = Controller.ObterVerbaCarimboPesquisa(0, 0, 0, acordo)
        Else
            dstVerbaCarimbo = Controller.ObterVerbaCarimboPesquisa(indStaMcoVbaFrn, Fornecedor, Empenho, acordo)
        End If


        If dstVerbaCarimbo.CADMCOVBAFRNPesquisa.Rows.Count > 0 Then

            If cmbTIPDSNDSCBNF.Items.Count > 0 AndAlso Not cmbTIPDSNDSCBNF.Items.FindByValue(dstVerbaCarimbo.CADMCOVBAFRNPesquisa(0).EMPENHO) Is Nothing Then
                cmbTIPDSNDSCBNF.SelectedValue = dstVerbaCarimbo.CADMCOVBAFRNPesquisa(0).EMPENHO
            End If

            controle = dstVerbaCarimbo.CADMCOVBAFRNPesquisa.Select("INDSTAMCOVBAFRN=4").Length > 0
            controleSalvar = dstVerbaCarimbo.CADMCOVBAFRNPesquisa.Select("INDSTAMCOVBAFRN<>4").Length > 0
            Dim isCarimbo As Boolean = dstVerbaCarimbo.CADMCOVBAFRNPesquisa.Select("INDSTAMCOVBAFRN=2").Length > 0 AndAlso txtDATNGCPMS.Date = Date.Now.Today

            btnAlterarVerbaCarimbo.Visible = controle

            If dstVerbaCarimbo.CADMCOVBAFRNPesquisa.Select("INDSTAMCOVBAFRN=2").Length > 0 Then 'carimbo
                Me.btnSalvar.Enabled = isCarimbo
                WSCAcoesComerciais.isCarimbo = True
            Else
                WSCAcoesComerciais.isCarimbo = False
                Me.btnSalvar.Enabled = Not controleSalvar
                btnSalvar.Attributes.Remove("onclick")
            End If
            'Me.btnSalvar.Enabled = (Not controleSalvar) Or isCarimbo ''erro aqui


            Me.GrdVerbaCarimbo.DataSource = dstVerbaCarimbo.CADMCOVBAFRNPesquisa
            GrdVerbaCarimbo.DataBind()
            With Me.GrdVerbaCarimbo
                If Controller.PageSize > 0 Then
                    .DisplayLayout.Pager.AllowPaging = True
                    .DisplayLayout.Pager.Alignment = Infragistics.WebUI.UltraWebGrid.PagerAlignment.Center
                    .DisplayLayout.Pager.PageSize = Controller.PageSize
                End If
                .DataBind()
                For i As Integer = 0 To GrdVerbaCarimbo.Rows.Count - 1
                    Me.GrdVerbaCarimbo.Rows(i).Cells.FromKey("DATA").Text = Format(CDate(Me.GrdVerbaCarimbo.Rows(i).Cells.FromKey("DATA").Value), "dd/MM/yyyy")
                    Me.GrdVerbaCarimbo.Rows(i).Cells.FromKey("VALOR_PREVISTO").Text = FormatNumber(Me.GrdVerbaCarimbo.Rows(i).Cells.FromKey("VALOR_PREVISTO").Value, 2)
                    If Not VerificaChamadaCarimbo() Then txtVLRNGCPMS.ValueDecimal += Convert.ToDecimal(FormatNumber(Me.GrdVerbaCarimbo.Rows(i).Cells.FromKey("VALOR_PREVISTO").Value, 2))
                Next
            End With
            GrdVerbaCarimbo.Visible = True
        End If
    End Sub
    Private Sub PreencheCampo()

    End Sub

#End Region

End Class