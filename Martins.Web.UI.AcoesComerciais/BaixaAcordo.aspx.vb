Imports Martins.Security.Helper

Public Class BaixaAcordo
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetAcordo1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetAcordo
        CType(Me.DatasetAcordo1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetAcordo1
        '
        Me.DatasetAcordo1.DataSetName = "DatasetAcordo"
        Me.DatasetAcordo1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetAcordo1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetAcordo1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetAcordo
    Protected WithEvents txtCODSITPMS As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents cmbCODFILEMP As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCODPMS As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtNUMPEDCMP As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents cmdImprimir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents rblObjetivo As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtDataInicial As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtDataFinal As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents uwgPesquisa As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents txtValorNegociado As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtValorEfetivado As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtValorPago As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtValorPerdaAnterior As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtFormaPagto As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDestinoVerba As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataPrevisaoRecebimento As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtValorPerda As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnGravar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnAlterarPerda As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ddl1 As System.Web.UI.WebControls.DropDownList
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

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(False, False))
        End If
        If Not (IsPostBack) Then
            btnGravar.Enabled = False
            btnAlterarPerda.Enabled = False
            PreencherComboFiliais()
            cmdImprimir.Enabled = False
            With ucFornecedor
                ucFornecedor.widthCodigo = System.Web.UI.WebControls.Unit.Parse("60px")
                ucFornecedor.widthNome = System.Web.UI.WebControls.Unit.Parse("280px")
            End With
            Util.AdicionaJsFocus(Me.Page, CType(rblObjetivo, System.web.UI.WebControls.WebControl))
        End If
        btnPesquisar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        btnGravar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        btnAlterarPerda.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        cmdImprimir.Attributes.Add("OnClick", "javascript:mostraAndamento()")
    End Sub

    Private Sub uwgPesquisa_Click(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.ClickEventArgs) Handles uwgPesquisa.Click
        If (e.Row.Index >= 0) Then
            txtValorPerda.Text = ""
            txtFormaPagto.Text = Convert.ToInt32(uwgPesquisa.DisplayLayout.ActiveRow.Cells(4).Value).ToString("00") & " - " & Convert.ToString(uwgPesquisa.DisplayLayout.ActiveRow.Cells(5).Value)
            txtDestinoVerba.Text = Convert.ToInt32(uwgPesquisa.DisplayLayout.ActiveRow.Cells(6).Value).ToString("00") & " - " & Convert.ToString(uwgPesquisa.DisplayLayout.ActiveRow.Cells(7).Value)
            txtValorNegociado.Value = uwgPesquisa.DisplayLayout.ActiveRow.Cells(8).Value
            txtValorEfetivado.Value = uwgPesquisa.DisplayLayout.ActiveRow.Cells(9).Value
            txtValorPago.Value = uwgPesquisa.DisplayLayout.ActiveRow.Cells(10).Value
            txtDataPrevisaoRecebimento.Value = uwgPesquisa.DisplayLayout.ActiveRow.Cells(11).Value
            txtValorPerdaAnterior.Value = uwgPesquisa.DisplayLayout.ActiveRow.Cells(14).Value

            If (rblObjetivo.SelectedValue = "2") Then 'Alterar Vr. Perda
                Dim valorLimite As Decimal = txtValorEfetivado.ValueDecimal - txtValorPago.ValueDecimal

                If (valorLimite = 0) Then
                    btnGravar.Enabled = False
                    btnAlterarPerda.Enabled = False
                    Util.AdicionaJsAlert(Me, "Não é possível informar valor da perda para essa promessa")
                    Exit Sub
                Else
                    txtValorPerda.Enabled = True
                    txtValorPerda.ValueDecimal = Math.Round(valorLimite, 2)
                End If
            End If

            If Convert.ToInt32(uwgPesquisa.DisplayLayout.ActiveRow.Cells(15).Value) = 2 Then
                txtValorPago.Enabled = False
                txtValorPerda.Enabled = False
                btnGravar.Enabled = False
                btnAlterarPerda.Enabled = False
                Util.AdicionaJsAlert(Me, "Não é possível informar o valor pago nem a perda da promessa")
            Else
                If (rblObjetivo.SelectedValue = "1") Then 'Alterar Vr. Pago
                    txtValorPago.Enabled = True
                    txtValorPerda.Enabled = False
                    cmdImprimir.Enabled = True
                    btnGravar.Enabled = True
                    btnAlterarPerda.Enabled = False
                Else
                    txtValorPago.Enabled = False
                    txtValorPerda.Enabled = True
                    cmdImprimir.Enabled = False
                    btnGravar.Enabled = False
                    btnAlterarPerda.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click

        Dim strMsg As String
        Dim lngCodPms As Long
        Dim lngNumPedCmp As Long
        Dim lngCodFrn As Long
        Dim DatIniPod As Date
        Dim DatFimPod As Date

        If rblObjetivo.SelectedValue = "" Then
            Util.AdicionaJsAlert(Me, "Favor selecionar uma das opções: Alterar Vr. Pago ou Alterar Vr. Perda ")
            Exit Sub
        End If

        uwgPesquisa.DisplayLayout.Rows.Clear()

        txtFormaPagto.Text = ""
        txtDestinoVerba.Text = ""
        txtValorNegociado.Text = ""
        txtValorEfetivado.Text = ""
        txtDataPrevisaoRecebimento.Text = ""
        txtValorPago.Text = ""
        txtValorPerda.Text = ""
        txtValorPerdaAnterior.Text = ""

        If ucFornecedor.CodFornecedor > 0 Then
            If txtDataInicial.Date = Nothing Or txtDataFinal.Date = Nothing Then
                Util.AdicionaJsAlert(Me, "Favor informar o período desejado")
                Exit Sub
            End If
            If txtDataInicial.Date > txtDataFinal.Date Then
                Util.AdicionaJsAlert(Me, "Data inicial deve ser anterior a data final")
                Exit Sub
            End If
        End If

        If txtCODPMS.ValueDecimal <> 0 Then
            DatasetAcordo1 = Controller.ObterAcoesComerciaisBaixa( _
                txtCODPMS.ValueDecimal, _
                Convert.ToDecimal(cmbCODFILEMP.SelectedValue), _
                1, _
                1, _
                Nothing, _
                Nothing, _
                1)
        Else
            If Not (txtNUMPEDCMP.Text.Trim = String.Empty) Then
                DatasetAcordo1 = Controller.ObterAcoesComerciaisBaixa( _
                    1, _
                    Convert.ToDecimal(cmbCODFILEMP.SelectedValue), _
                    Convert.ToDecimal(txtNUMPEDCMP.Text), _
                    1, _
                    Nothing, _
                    Nothing, _
                    2)
            Else
                If (ucFornecedor.CodFornecedor > 0) Then
                    DatasetAcordo1 = Controller.ObterAcoesComerciaisBaixa( _
                        1, _
                        Convert.ToDecimal(cmbCODFILEMP.SelectedValue), _
                        1, _
                        ucFornecedor.CodFornecedor, _
                        txtDataInicial.Date, _
                        txtDataFinal.Date, _
                        3)
                Else
                    Exit Sub
                End If
            End If
        End If

        Dim encontradoRegistros As Boolean = True
        If DatasetAcordo1.TbAcoesComerciaisBaixa.Rows.Count = 0 Then
            encontradoRegistros = False
        ElseIf (Me.DatasetAcordo1.TbAcoesComerciaisBaixa.Rows.Count = 1 And Me.DatasetAcordo1.TbAcoesComerciaisBaixa(0).IsNull("CODPMS")) Then
            encontradoRegistros = False
        End If
        If Not encontradoRegistros Then
            Util.AdicionaJsAlert(Me, "Nenhuma informação encontrada com os dados informados")
            Exit Sub
        End If

        uwgPesquisa.DataSource = DatasetAcordo1
        uwgPesquisa.DataBind()
    End Sub

    Private Sub btnAlterarPerda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlterarPerda.Click
        Try
            If flagProcessando Then
                Exit Sub
            End If
            flagProcessando = True
            alterarPerda()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        Finally
            flagProcessando = False
        End Try
    End Sub

    Private Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        Try
            If flagProcessando Then
                Exit Sub
            End If
            flagProcessando = True
            gravar()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        Finally
            flagProcessando = False
        End Try
    End Sub

    Private Sub rblObjetivo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblObjetivo.SelectedIndexChanged
        If (rblObjetivo.SelectedValue = "1") Then 'Alterar Vr. Pago
            LimpaCampos()
            txtValorPago.Enabled = True
            txtValorPerda.Enabled = False
            cmdImprimir.Enabled = True
            btnGravar.Enabled = True
            btnAlterarPerda.Enabled = False
        ElseIf (rblObjetivo.SelectedValue = "2") Then 'Alterar Vr. Perda
            LimpaCampos()
            txtValorPago.Enabled = False
            txtValorPerda.Enabled = True
            cmdImprimir.Enabled = False
            btnGravar.Enabled = False
            btnAlterarPerda.Enabled = True
        End If
        Util.AdicionaJsFocus(Me.Page, CType(cmbCODFILEMP, System.web.UI.WebControls.WebControl))
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Page.RegisterStartupScript("RelatorioBaixaAcordo", "<script>ShowPopUp('RelatorioBaixaAcordo.aspx', 'RelatorioBaixaAcordo', 200, 300)</script>")
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("Principal.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ucFornecedor_FornecedorAlterado(ByVal e As System.Web.UI.WebControls.ListItem) Handles ucFornecedor.FornecedorAlterado
        Util.AdicionaJsFocus(Me.Page, CType(ddl1, System.web.UI.WebControls.WebControl))
    End Sub

#End Region

#Region " Métodos "

#Region " Método Carga "

    Public Sub LimpaCampos()
        txtFormaPagto.Text = ""
        txtDestinoVerba.Text = ""
        txtDataPrevisaoRecebimento.Text = ""
        txtValorNegociado.Text = ""
        txtValorEfetivado.Text = ""
        txtValorPerdaAnterior.Text = ""
        txtValorPago.Text = ""
        txtValorPerda.Text = ""
    End Sub

    Private Sub PreencherComboFiliais()
        Dim dataSetFilial As wsAcoesComerciais.dataSetFilial
        dataSetFilial = Controller.ObterFiliaisExpedicao(1)
        Util.carregarCmbFilial(dataSetFilial, cmbCODFILEMP, Nothing)
    End Sub

#End Region

#Region " Métodos de Regras de Negócio "

    Private Sub alterarPerda()
        Try
            Dim VlrLim As Decimal
            Dim VlrPdaEnt As Decimal
            Dim VlrPgoAlt As Decimal

            If txtValorPerda.ValueDecimal = 0 Then
                Util.AdicionaJsAlert(Me, "Favor preencher o campo Valor da Perda.")
                Exit Sub
            End If

            If (txtValorPerda.ValueDecimal + txtValorPerdaAnterior.ValueDecimal) < 0 Then
                Util.AdicionaJsAlert(Me, "Valor da perda deve ser maior que zero.")
                Exit Sub
            End If

            VlrLim = txtValorEfetivado.ValueDecimal - txtValorPago.ValueDecimal
            VlrPgoAlt = txtValorPago.ValueDecimal + txtValorPerda.ValueDecimal

            If VlrLim >= txtValorPerda.ValueDecimal Then
                DatasetAcordo1 = Controller.ObterAcordo(1, Convert.ToDecimal(cmbCODFILEMP.SelectedValue), Convert.ToDecimal(uwgPesquisa.DisplayLayout.ActiveRow.Cells(0).Value), Convert.ToDateTime(uwgPesquisa.DisplayLayout.ActiveRow.Cells(12).Value))
                Dim linhaT0118066 As wsAcoesComerciais.DatasetAcordo.T0118066Row

                For Each linha As wsAcoesComerciais.DatasetAcordo.T0118066Row In DatasetAcordo1.T0118066
                    'Localiza a linha que deverá ser atualizada
                    If linha.TIPFRMDSCBNF = Convert.ToDecimal(Mid$(txtFormaPagto.Text, 1, 2)) And _
                       linha.TIPDSNDSCBNF = Convert.ToDecimal(Mid$(txtDestinoVerba.Text, 1, 2)) And _
                       linha.DATPRVRCBPMS = txtDataPrevisaoRecebimento.Date Then

                        If linha.IsINDASCARDFRNPMSNull Then
                            linhaT0118066 = linha
                            Exit For
                        ElseIf linha.INDASCARDFRNPMS = 0 Then
                            linhaT0118066 = linha
                            Exit For
                        End If

                    End If
                Next

                'Atualiza os valores
                If Not linhaT0118066 Is Nothing Then
                    With linhaT0118066
                        .BeginEdit()
                        .VLRPGOPMS = VlrPgoAlt 'txtValorPago.ValueDecimal
                        .VLRPDAPMS = txtValorPerda.ValueDecimal
                        .EndEdit()
                    End With
                End If

                Dim linhaT0120540 As wsAcoesComerciais.DatasetAcordo.T0120540Row
                linhaT0120540 = CType(DatasetAcordo1.T0120540.NewRow(), wsAcoesComerciais.DatasetAcordo.T0120540Row)

                linhaT0120540.CodEmp = 1
                linhaT0120540.CodFilEmp = Convert.ToDecimal(cmbCODFILEMP.SelectedValue)
                linhaT0120540.CodPms = Convert.ToDecimal(uwgPesquisa.DisplayLayout.ActiveRow.Cells(0).Value)
                linhaT0120540.DatNgcPms = Convert.ToDateTime(uwgPesquisa.DisplayLayout.ActiveRow.Cells(12).Value).Date
                linhaT0120540.DatPrvRcbPms = txtDataPrevisaoRecebimento.Date
                linhaT0120540.TipFrmDscBnf = Convert.ToDecimal(Mid$(txtFormaPagto.Text, 1, 2))
                linhaT0120540.TipDsnDscBnf = Convert.ToDecimal(Mid$(txtDestinoVerba.Text, 1, 2))
                linhaT0120540.NumUltAltPms = 0
                linhaT0120540.DatAltPms = Date.Today
                linhaT0120540.VlrPgoPmsAnt = Convert.ToDouble(uwgPesquisa.DisplayLayout.ActiveRow.Cells(10).Value)
                linhaT0120540.VlrPgoPms = VlrPgoAlt

                Try
                    linhaT0120540.NomAcsUsrSis = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0).NOMACSUSRSIS.Trim
                Catch ex As Exception
                    Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471).")
                    Exit Sub
                End Try

                linhaT0120540.FlgLstPlhLmt = "P"
                linhaT0120540.VlrLstPlhLmt = 0
                linhaT0120540.VlrPdaPmsAnt = txtValorPerdaAnterior.ValueDecimal

                DatasetAcordo1.T0120540.Rows.Add(linhaT0120540)

                Controller.AtualizarAcordo(DatasetAcordo1)
                Util.AdicionaJsAlert(Me, "Gravação com Sucesso")
            Else
                Util.AdicionaJsAlert(Me, "Valor da perda deve ser menor que a diferença entre valor efetivado e o valor pago informado.")
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub gravar()
        Try
            If txtDestinoVerba.Text = "" Or txtFormaPagto.Text = "" Then
                Util.AdicionaJsAlert(Me, "Selecine os dados que deseja alterar")
                Exit Sub
            End If

            DatasetAcordo1 = Controller.ObterAcordo(1, Convert.ToDecimal(cmbCODFILEMP.SelectedValue), Convert.ToDecimal(uwgPesquisa.DisplayLayout.ActiveRow.Cells(0).Value), Convert.ToDateTime(uwgPesquisa.DisplayLayout.ActiveRow.Cells(12).Value))
            Dim linhaT0118066 As wsAcoesComerciais.DatasetAcordo.T0118066Row

            For Each linha As wsAcoesComerciais.DatasetAcordo.T0118066Row In DatasetAcordo1.T0118066
                'Localiza a linha que deverá ser atualizada
                If linha.TIPFRMDSCBNF = Convert.ToDecimal(Mid$(txtFormaPagto.Text, 1, 2)) And _
                    linha.TIPDSNDSCBNF = Convert.ToDecimal(Mid$(txtDestinoVerba.Text, 1, 2)) And _
                    linha.DATPRVRCBPMS = txtDataPrevisaoRecebimento.Date Then
                    If linha.IsINDASCARDFRNPMSNull Then
                        linhaT0118066 = linha
                        Exit For
                    ElseIf linha.INDASCARDFRNPMS = 0 Then
                        linhaT0118066 = linha
                        Exit For
                    End If
                End If
            Next

            'Atualiza os valores
            If Not linhaT0118066 Is Nothing Then
                With linhaT0118066
                    .BeginEdit()
                    .VLRPGOPMS = txtValorPago.ValueDecimal
                    .VLRPDAPMS = txtValorPerda.ValueDecimal
                    .EndEdit()
                End With
            End If

            Dim linhaT0120540 As wsAcoesComerciais.DatasetAcordo.T0120540Row
            linhaT0120540 = CType(DatasetAcordo1.T0120540.NewRow(), wsAcoesComerciais.DatasetAcordo.T0120540Row)

            With linhaT0120540
                .CodEmp = 1
                .CodFilEmp = Convert.ToDecimal(cmbCODFILEMP.SelectedValue)
                .CodPms = Convert.ToDecimal(uwgPesquisa.DisplayLayout.ActiveRow.Cells(0).Value)
                .DatNgcPms = Convert.ToDateTime(uwgPesquisa.DisplayLayout.ActiveRow.Cells(12).Value).Date
                .DatPrvRcbPms = txtDataPrevisaoRecebimento.Date
                .TipFrmDscBnf = Convert.ToDecimal(Mid$(txtFormaPagto.Text, 1, 2))
                .TipDsnDscBnf = Convert.ToDecimal(Mid$(txtDestinoVerba.Text, 1, 2))
                .NumUltAltPms = 0
                .DatAltPms = Date.Today
                .VlrPgoPmsAnt = Convert.ToDouble(uwgPesquisa.DisplayLayout.ActiveRow.Cells(10).Value)
                .VlrPgoPms = txtValorPago.ValueDouble

                Try
                    .NomAcsUsrSis = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0).NOMACSUSRSIS.Trim
                Catch ex As Exception
                    Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
                    Exit Sub
                End Try

                .FlgLstPlhLmt = " "
                .VlrLstPlhLmt = 0
                .VlrPdaPmsAnt = txtValorPerdaAnterior.ValueDecimal
                .FlgLstPlhLmt = " "
            End With

            DatasetAcordo1.T0120540.Rows.Add(linhaT0120540)

            Controller.AtualizarAcordo(DatasetAcordo1)
            Util.AdicionaJsAlert(Me, "Gravação com Sucesso")
            cmdImprimir.Enabled = True
            btnGravar.Enabled = False
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#End Region

End Class