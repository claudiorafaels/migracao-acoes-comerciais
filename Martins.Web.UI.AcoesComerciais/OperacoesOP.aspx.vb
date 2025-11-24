Public Class OperacoesOP
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoOperacaoBaixaOP1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoOperacaoBaixaOP
        Me.DatasetOperacaoBaixaOperacaoFornecedor_1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetOperacaoBaixaOperacaoFornecedor
        CType(Me.DatasetTipoOperacaoBaixaOP1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetOperacaoBaixaOperacaoFornecedor_1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoOperacaoBaixaOP1
        '
        Me.DatasetTipoOperacaoBaixaOP1.DataSetName = "DatasetTipoOperacaoBaixaOP"
        Me.DatasetTipoOperacaoBaixaOP1.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DatasetOperacaoBaixaOperacaoFornecedor_1
        '
        Me.DatasetOperacaoBaixaOperacaoFornecedor_1.DataSetName = "DatasetOperacaoBaixaOperacaoFornecedor"
        Me.DatasetOperacaoBaixaOperacaoFornecedor_1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoOperacaoBaixaOP1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetOperacaoBaixaOperacaoFornecedor_1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnBuscarFornecedor As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtNomeFornecedor As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents cmbNomeFornecedor As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCODFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents btnLimpar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnImprimir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtDatRcbOrdPgtInicial As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtDatRcbOrdPgtFinal As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtDatUltPmsOrdInicial As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtDatUltPmsOrdFinal As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents CmbTipIdtEmpAscAcoCmc As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmbStaOpe As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmbTipOriOrdPgtFrn As System.Web.UI.WebControls.DropDownList

    Protected WithEvents txtTotVlrOP As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtOpOriginal As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents cmbTipoOperacaoBaixa As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DatasetTipoOperacaoBaixaOP1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoOperacaoBaixaOP
    Protected WithEvents ValorComboTipoOperacaoBaixa As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DatasetOperacaoBaixaOperacaoFornecedor_1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetOperacaoBaixaOperacaoFornecedor
    Protected WithEvents dGridItens As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents lkbProcessaCloseModal As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtTotOP As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents btnVisualizar As System.Web.UI.WebControls.LinkButton
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

#Region "Busca Fornecedor"

    Private Sub btnBuscarFornecedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarFornecedor.Click
        Dim datasetFornecedor As wsAcoesComerciais.dataSetDivisaoFornecedor
        Dim flagMostrarCombo As Boolean = False

        If txtNomeFornecedor.Visible Then

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
            txtNomeFornecedor.Visible = True
            txtNomeFornecedor.Width = System.Web.UI.WebControls.Unit.Parse("170px")
            cmbNomeFornecedor.Visible = False
            Page.RegisterStartupScript("e1", "<script>document.getElementById('igtxttxtCODFRN').focus();</script>")
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
        dGridItens.DisplayLayout.Rows.Clear()
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

    Private Property TipOpeBxaOrdPgtFrnPesq() As Integer
        Get
            Dim result As Integer = 0
            If cmbTipoOperacaoBaixa.Items.Count > 0 Then
                If IsNumeric(cmbTipoOperacaoBaixa.SelectedValue) Then
                    result = Convert.ToInt32(cmbTipoOperacaoBaixa.SelectedValue)
                End If
            End If
            Return result
        End Get
        Set(ByVal Value As Integer)
        End Set
    End Property

#End Region

#Region "Eventos"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GerarJavaScript()
            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            End If
            If (Not IsPostBack) Then
                popularCmbTipIdtEmpAscAcoCmc()
                Limpar()
                txtTotOP.Text = "0"
                txtTotVlrOP.Text = "0"
                txtDatRcbOrdPgtInicial.Value = Date.Today.AddDays(-1)
                txtDatRcbOrdPgtFinal.Value = Date.Today
            End If
            btnImprimir.Attributes.Add("OnClick", "javascript:mostraAndamento()")
            btnPesquisar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
            btnVisualizar.Attributes.Add("OnClick", "javascript:mostraAndamento()")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            If Validar() Then
                AtualizarOPRecebidaFornecedor()
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Response.Redirect("Principal.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Try
            btnImprimir.Enabled = False
            btnVisualizar.Enabled = False
            btnSalvar.Enabled = False

            If ValidarPesquisa() = False Then
                Exit Sub
            End If

            CarregarOperacao()
            dGridItens.DataBind()

            If dGridItens.Rows.Count > 0 Then
                If DatasetOperacaoBaixaOperacaoFornecedor_1.TbRetorno1.Rows.Count > 1 Or (Not DatasetOperacaoBaixaOperacaoFornecedor_1.TbRetorno1(0).IsCodFrnNull) Then
                    btnImprimir.Enabled = True
                    btnVisualizar.Enabled = True
                    btnSalvar.Enabled = True
                End If
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmbStaOpe_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStaOpe.SelectedIndexChanged
        Try
            VerificarStatus()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try

            If dGridItens.Rows.Count <= 0 Then
                Util.AdicionaJsAlert(Me.Page, "Não existe nenhum item a ser impresso")
                Util.AdicionaJsFocus(Me.Page, CType(cmbTipoOperacaoBaixa, WebControl))
                Exit Sub
            End If

            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = True

            'Não é necessário guardar o dataset na seção porque isso já foi feito
            'na pesquisa

            ' Obter dados do relatório e guardar na seção
            'WSCAcoesComerciais.dsRelatorioOperacoesOP = Me.DatasetOperacaoBaixaOperacaoFornecedor_1

            'Guarda o nome do relatório na seção
            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "CBY002L1.RPT"

            'Chama o visualizador de relatório
            Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try

            If dGridItens.Rows.Count <= 0 Then
                Util.AdicionaJsAlert(Me.Page, "Não existe nenhum item a ser impresso")
                Util.AdicionaJsFocus(Me.Page, CType(cmbTipoOperacaoBaixa, WebControl))
                Exit Sub
            End If

            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = False

            'Não é necessário guardar o dataset na seção porque isso já foi feito
            'na pesquisa

            ' Obter dados do relatório e guardar na seção
            'WSCAcoesComerciais.dsRelatorioOperacoesOP = Me.DatasetOperacaoBaixaOperacaoFornecedor_1

            'Guarda o nome do relatório na seção
            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "CBY002L1.RPT"

            'Chama o visualizador de relatório
            Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnLimpar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpar.Click
        Try
            Limpar()
            Util.AdicionaJsFocus(Me.Page, CType(txtCODFRN, WebControl))
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub dGridItens_Click(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.ClickEventArgs) Handles dGridItens.Click
        Dim TipOpeBxaOrdPgtFrn As Decimal
        Try
            btnSalvar.Enabled = False
            cmbTipoOperacaoBaixa.Items.Clear()

            totalizarOperacoesOP()

            If dGridItens.DisplayLayout.ActiveRow Is Nothing Then
                Exit Sub
            End If

            If Not ValidarSelecao() Then
                Exit Sub
            End If

            TipOpeBxaOrdPgtFrn = Convert.ToDecimal(dGridItens.DisplayLayout.ActiveRow().GetCellValue(dGridItens.Columns.FromKey("TipOpeBxaOrdPgtFrn")))
            If TipOpeBxaOrdPgtFrn = 0 Then
                popularCmbTipoOperacaoBaixa()
            End If

            If cmbTipoOperacaoBaixa.Items.Count > 0 Then
                btnSalvar.Enabled = True
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmbTipoOperacaoBaixa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoOperacaoBaixa.SelectedIndexChanged
        Try
            registrarEventoBtnConfirmar()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub lkbProcessaCloseModal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkbProcessaCloseModal.Click
        Try
            cmbTipoOperacaoBaixa.Items.Clear()
            CarregarOperacao()
            'txtCODFRN.Value = 0
            btnSalvar.Enabled = False
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#Region "Metodos"

#Region "PopularCombos"

    Private Sub popularCmbTipoOperacaoBaixa()
        Try
            Dim ds As wsAcoesComerciais.DatasetOperacaoBaixaOperacaoFornecedor
            Dim origem As Integer = 0

            'origem = Convert.ToInt32(dGridItens.DisplayLayout.ActiveRow().GetCellValue(dGridItens.Columns.FromKey("TipOriOrdPgtFrn")))
            origem = Convert.ToInt32(dGridItens.DisplayLayout.ActiveRow().Cells(24).Value)

            'If IsNumeric(cmbTipOriOrdPgtFrn.SelectedValue) Then
            '    origem = CInt(cmbTipOriOrdPgtFrn.SelectedValue)
            'End If

            ds = Controller.ObterSelecaoAtualizacaoOperacaoBaixaOperacaoFornecedor(2, _
                                                                                   0, _
                                                                                   0, _
                                                                                   Nothing, _
                                                                                   origem, _
                                                                                   Nothing, _
                                                                                   0, _
                                                                                   Nothing, _
                                                                                   Nothing, _
                                                                                   Nothing, _
                                                                                   Nothing, _
                                                                                   Nothing, _
                                                                                   Nothing, _
                                                                                   Nothing, _
                                                                                   Nothing, _
                                                                                   Nothing, _
                                                                                   Nothing, _
                                                                                   0)
            cmbTipoOperacaoBaixa.Items.Clear()

            For Each linha As wsAcoesComerciais.DatasetOperacaoBaixaOperacaoFornecedor.TbRetorno2Row In ds.TbRetorno2
                cmbTipoOperacaoBaixa.Items.Add(New ListItem(Format(linha.TipOpeBxaOrdPgtFrn, "000") & "-" & linha.DesTipOpeBxaOrdPgt, linha.TipOpeBxaOrdPgtFrn.ToString))
            Next

            If cmbTipoOperacaoBaixa.Items.Count > 0 Then
                cmbTipoOperacaoBaixa.Items.Insert(0, New ListItem("SELECIONE->", "0"))
                cmbTipoOperacaoBaixa.SelectedValue = "0"
            End If

            Exit Sub
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub popularCmbTipIdtEmpAscAcoCmc()
    End Sub

#End Region

    Private Sub GerarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        btnPesquisar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        btnImprimir.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        btnVisualizar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        'btnCancelar.Attributes.Add("OnClick", "javascript:return confirm('Deseja sair sem salvar?')")
    End Sub

    Private Sub transferirDadosDoDatasetParaFormulario()
        Try
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Public Sub AtualizarOPRecebidaFornecedor()
        Dim linha As wsAcoesComerciais.DatasetOPRecebidaFornecedor.T0118880Row
        Dim tipoEdicao As Short
        Try

            If Not ValidarCamposConfirmar() Then
                Exit Sub
            End If

            'Consulta o tipo de operação de baixa
            DatasetTipoOperacaoBaixaOP1 = Controller.ObterTipoOperacaoBaixaOP(Decimal.Parse(cmbTipoOperacaoBaixa.SelectedValue))
            If DatasetTipoOperacaoBaixaOP1.T0136390.Rows.Count = 0 Then
                Exit Sub
            End If

            'Dependendo do atributo INDTIPOPETRNORDPGT chama outro form
            If DatasetTipoOperacaoBaixaOP1.T0136390(0).INDTIPOPETRNORDPGT = 0 Then
                GuardaVariaveisJanelaModal()
                'Util.ShowPopUp(False, False)
                'Page.RegisterStartupScript("Quebra", "<script>ShowPopUp('OperacoesOpQuebra.aspx', 'OperacoesOpQuebra', 420, 620)</script>")

                'Util.ShowPopUpModal()
                'Page.RegisterStartupScript("Quebra", "<script>ShowPopUpModal('OperacoesOpQuebra.aspx', 'OperacoesOpQuebra', 420, 620)</script>")

                Page.RegisterStartupScript("Quebra", "<script>chamaQuebraOp();</script>")
                CarregarOperacao()
                dGridItens.DataBind()

                Exit Sub
            Else
                RealizarTransferencia()
            End If

            cmbTipoOperacaoBaixa.Items.Clear()
            CarregarOperacao()
            txtCODFRN.Value = 0
            btnSalvar.Enabled = False
            Util.AdicionaJsAlert(Me.Page, "Operação bem sucedida.")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = String.Empty
        Try
            If cmbTipoOperacaoBaixa.SelectedValue = "0" Then
                Util.AdicionaJsAlert(Me, "Selecione a operação de baixa")
                Util.AdicionaJsFocus(Me, CType(cmbTipoOperacaoBaixa, System.Web.UI.WebControls.WebControl))
                Return False
            End If
            Return True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Function ValidarPesquisa() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = String.Empty
        Try
            ValidarPesquisa = True

            'período de emissão
            If IsDate(txtDatRcbOrdPgtInicial.Text) Or IsDate(txtDatRcbOrdPgtFinal.Text) Then
                If Not (IsDate(txtDatRcbOrdPgtInicial.Text)) Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "data inicial do período emissão não informada ou inválida"
                ElseIf Not (IsDate(txtDatRcbOrdPgtFinal.Text)) Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "data final do período emissão não informada ou inválida"
                ElseIf Date.Parse(txtDatRcbOrdPgtInicial.Text) > Date.Parse(txtDatRcbOrdPgtFinal.Text) Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "data inicial do período emissão maior que data final"
                End If
            End If

            'período baixa
            If IsDate(txtDatUltPmsOrdInicial.Text) Or IsDate(txtDatUltPmsOrdFinal.Text) Then
                If Not (IsDate(txtDatUltPmsOrdInicial.Text)) Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "data inicial do período baixa não informada ou inválida"
                ElseIf Not (IsDate(txtDatUltPmsOrdFinal.Text)) Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "data final do período baixa não informada ou inválida"
                ElseIf Date.Parse(txtDatUltPmsOrdInicial.Text) > Date.Parse(txtDatUltPmsOrdFinal.Text) Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "data inicial do período baixa maior que data final"
                End If
            End If

            'op original
            'If Val(txtOpOriginal.ValueDecimal) = 0 Then
            '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '    mensagemErro &= "Op original inválida"
            'End If

            If mensagemErro.Trim() <> String.Empty Then
                Page.RegisterStartupScript("Alerta", "<script>alert('" & (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1) & "');</script>")
                Return False
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Sub atualizar()
        Try

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub VerificarStatus()
        Try
            txtDatUltPmsOrdInicial.Enabled = True
            txtDatUltPmsOrdFinal.Enabled = True
            If cmbStaOpe.SelectedValue = "1" Or cmbStaOpe.SelectedValue = "3" Then
                txtDatUltPmsOrdInicial.Text = String.Empty
                txtDatUltPmsOrdFinal.Text = String.Empty
                txtDatUltPmsOrdInicial.Enabled = False
                txtDatUltPmsOrdFinal.Enabled = False
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub LimparSelecaoGrid()
        Dim i As Integer
        For i = 0 To dGridItens.Rows.Count - 1
            With dGridItens.Rows(i)
                If (CBool(.Cells.FromKey("Check").Value)) Then
                    .Cells.FromKey("Check").Value = False
                End If
            End With
        Next
    End Sub

    Private Function ValidarSelecao() As Boolean
        'Essa função deixou de ser necessária porque ao invés de check
        'estou utilizando a seleção da linha

        Return True

        'Dim i As Integer
        'Dim result As Boolean
        'Dim quantidadeLinhaSelecionadas As Integer

        'result = False

        'For i = 0 To dGridItens.Rows.Count - 1
        '    With dGridItens.Rows(i)
        '        If (CBool(.Cells.FromKey("Check").Value)) Then
        '            quantidadeLinhaSelecionadas += 1
        '        End If
        '    End With
        'Next

        'If quantidadeLinhaSelecionadas = 1 Then
        '    result = True
        'End If

        'Return result
    End Function

    Private Function ValidarCamposConfirmar() As Boolean
        ValidarCamposConfirmar = False

        If Not ValidarSelecao() Then
            Util.AdicionaJsAlert(Me.Page, "Deve-se selecionar apenas um item do grid.")
            LimparSelecaoGrid()
            Util.AdicionaJsFocus(Me.Page, CType(dGridItens, WebControl))
            Exit Function
        End If

        If Not (IsNumeric(cmbTipoOperacaoBaixa.SelectedValue)) Then
            Util.AdicionaJsAlert(Me.Page, "Selecione alguma operação a ser realizada.")
        End If

        ValidarCamposConfirmar = True
    End Function

    Public Sub LimparGrid()
        dGridItens.Rows.Clear()
    End Sub

    Private Sub Limpar()
        CmbTipIdtEmpAscAcoCmc.SelectedValue = "0"
        txtCODFRN.Text = String.Empty
        cmbNomeFornecedor.Items.Clear()
        txtDatRcbOrdPgtInicial.Text = String.Empty
        txtDatRcbOrdPgtFinal.Text = String.Empty
        txtDatUltPmsOrdInicial.Text = String.Empty
        txtDatUltPmsOrdFinal.Text = String.Empty
        txtOpOriginal.Text = String.Empty
        DatasetOperacaoBaixaOperacaoFornecedor_1 = New wsAcoesComerciais.DatasetOperacaoBaixaOperacaoFornecedor
        DatasetTipoOperacaoBaixaOP1 = New wsAcoesComerciais.DatasetTipoOperacaoBaixaOP
        dGridItens.DataBind()
        txtTotOP.Text = "0"
        txtTotVlrOP.Text = "0"
    End Sub

    Private Sub CarregarOperacao()
        Try
            Dim codigoFornecedor As Integer
            Dim status As Integer
            Dim origem As Integer
            Dim opOriginal As Integer
            Dim DatRcbOrdPgtInicial As Date
            Dim DatRcbOrdPgtFinal As Date
            Dim DatUltPmsOrdInicial As Date
            Dim DatUltPmsOrdFinal As Date
            Dim TipIdtEmpAscAcoCmc As Integer

            txtTotOP.Text = "0"
            txtTotVlrOP.Text = "0"
            btnSalvar.Enabled = False
            cmbTipoOperacaoBaixa.Items.Clear()

            'PREPARA OS PARAMETROS

            'Codigo do fornecedor
            If cmbNomeFornecedor.Items.Count > 0 Then
                codigoFornecedor = CInt(cmbNomeFornecedor.SelectedValue)
            Else
                codigoFornecedor = 0
            End If

            'Status
            If IsNumeric(cmbStaOpe.SelectedValue) Then
                status = CInt(cmbStaOpe.SelectedValue)
            End If

            'Origem
            If IsNumeric(cmbTipOriOrdPgtFrn.SelectedValue) Then
                origem = CInt(cmbTipOriOrdPgtFrn.SelectedValue)
            End If

            'OP Original
            If IsNumeric(txtOpOriginal.Text) Then
                opOriginal = CInt(txtOpOriginal.Text)
            End If

            'Período de baixa
            If IsDate(txtDatRcbOrdPgtInicial.Text) And IsDate(txtDatRcbOrdPgtFinal.Text) Then
                DatRcbOrdPgtInicial = CDate(txtDatRcbOrdPgtInicial.Text)
                DatRcbOrdPgtFinal = CDate(txtDatRcbOrdPgtFinal.Text)
            Else
                DatRcbOrdPgtInicial = Nothing
                DatRcbOrdPgtFinal = Nothing
            End If

            'Período de emissão
            If IsDate(txtDatUltPmsOrdInicial.Text) And IsDate(txtDatUltPmsOrdFinal.Text) Then
                DatUltPmsOrdInicial = CDate(txtDatUltPmsOrdInicial.Text)
                DatUltPmsOrdFinal = CDate(txtDatUltPmsOrdFinal.Text)
            Else
                DatUltPmsOrdInicial = Nothing
                DatUltPmsOrdFinal = Nothing
            End If

            'Empresa
            If CmbTipIdtEmpAscAcoCmc.SelectedValue = "-1" Then
                TipIdtEmpAscAcoCmc = Nothing
            Else
                If IsNumeric(CmbTipIdtEmpAscAcoCmc.SelectedValue) Then
                    TipIdtEmpAscAcoCmc = CInt(CmbTipIdtEmpAscAcoCmc.SelectedValue)
                End If
            End If

            DatasetOperacaoBaixaOperacaoFornecedor_1 = Controller.ObterSelecaoAtualizacaoOperacaoBaixaOperacaoFornecedor(1, _
                                                                                                                         codigoFornecedor, _
                                                                                                                         status, _
                                                                                                                         Nothing, _
                                                                                                                         origem, _
                                                                                                                         Nothing, _
                                                                                                                         opOriginal, _
                                                                                                                         Nothing, _
                                                                                                                         Nothing, _
                                                                                                                         Nothing, _
                                                                                                                         Nothing, _
                                                                                                                         Nothing, _
                                                                                                                         Nothing, _
                                                                                                                         DatRcbOrdPgtInicial, _
                                                                                                                         DatRcbOrdPgtFinal, _
                                                                                                                         DatUltPmsOrdInicial, _
                                                                                                                         DatUltPmsOrdFinal, _
                                                                                                                         TipIdtEmpAscAcoCmc)
            'Guarda o dataset na seção
            WSCAcoesComerciais.dsOperacaoBaixaOperacaoFornecedor = DatasetOperacaoBaixaOperacaoFornecedor_1

            Dim flagRetornouRegistros As Boolean = False
            dGridItens.Rows.Clear()
            If DatasetOperacaoBaixaOperacaoFornecedor_1.TbRetorno1.Rows.Count > 0 Then
                If Not DatasetOperacaoBaixaOperacaoFornecedor_1.TbRetorno1(0).IsCodFrnNull Then
                    flagRetornouRegistros = True
                End If
            End If

            If Not flagRetornouRegistros Then
                Util.AdicionaJsAlert(Me, "Não foi encontrada nenhuma ordem de pagamento.")
                Exit Sub
            End If

            dGridItens.DataBind()
            totalizarOperacoesOP()

            Exit Sub
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub totalizarOperacoesOP()
        Try
            Dim TotVlrOP As Decimal = 0
            For Each linha As wsAcoesComerciais.DatasetOperacaoBaixaOperacaoFornecedor.TbRetorno1Row In DatasetOperacaoBaixaOperacaoFornecedor_1.TbRetorno1
                TotVlrOP += linha.VlrOrdPgt
            Next

            Dim activeRow As Infragistics.WebUI.UltraWebGrid.UltraGridRow = dGridItens.DisplayLayout.ActiveRow


            If activeRow Is Nothing Then
                txtTotOP.ValueInt = DatasetOperacaoBaixaOperacaoFornecedor_1.TbRetorno1.Rows.Count
                txtTotVlrOP.ValueDecimal = TotVlrOP
            Else
                txtTotOP.ValueInt = 1
                txtTotVlrOP.ValueDecimal = CType(activeRow.GetCellValue(dGridItens.Columns.FromKey("VlrOrdPgt")), Decimal)
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub RealizarTransferencia()
        'Variaveis de controle
        Dim count As Integer

        'Declaração dos parametros que serão passados para procedure
        Dim TipOpe As Integer
        Dim CodFrn As Integer
        Dim StaOpe As Integer
        Dim DatRcbOrdPgt As Date
        Dim TipOriOrdPgtFrn As Integer
        Dim TipOpeBxaOrdPgtFrn As Integer
        Dim NumOrdPgtFrn As Integer
        Dim CodBco As Integer
        Dim CodAge As Integer
        Dim DatRcbOrdPgtAlt As Date
        Dim NomAcsUsrBxaOrdPgtAlt As String
        Dim QbrVlrOrdPgt As String
        Dim QtdQbrAlt As Integer
        Dim DatRcbOrdPgtIni As Date
        Dim DatRcbOrdPgtFim As Date
        Dim DatUltPmsOrdIni As Date
        Dim DatUltPmsOrdFim As Date
        Dim TipIdtEmpAscAcoCmc As Integer

        'Atribui valores aos parametros
        TipOpe = 3
        CodFrn = 0
        StaOpe = 0
        DatRcbOrdPgt = Nothing
        TipOriOrdPgtFrn = 0
        TipOpeBxaOrdPgtFrn = CInt(cmbTipoOperacaoBaixa.SelectedValue)

        Try
            NomAcsUsrBxaOrdPgtAlt = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0).NOMACSUSRSIS.Trim
        Catch ex As Exception
            Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
            Exit Sub
        End Try

        QbrVlrOrdPgt = String.Empty
        QtdQbrAlt = 0
        DatRcbOrdPgtIni = Nothing
        DatRcbOrdPgtFim = Nothing
        DatUltPmsOrdIni = Nothing
        DatUltPmsOrdFim = Nothing
        TipIdtEmpAscAcoCmc = 0

        With dGridItens
            NumOrdPgtFrn = Convert.ToInt32(.DisplayLayout.ActiveRow().GetCellValue(.Columns.FromKey("NumOrdPgtFrn")))
            CodBco = Convert.ToInt32(.DisplayLayout.ActiveRow().GetCellValue(.Columns.FromKey("CodBco")))
            CodAge = Convert.ToInt32(.DisplayLayout.ActiveRow().GetCellValue(.Columns.FromKey("CodAge")))
            DatRcbOrdPgtAlt = Convert.ToDateTime(.DisplayLayout.ActiveRow().GetCellValue(.Columns.FromKey("DatRcbOrdPgt")))
        End With

        'Chama a procedure que vai gravar a transferencia 
        Controller.ObterSelecaoAtualizacaoOperacaoBaixaOperacaoFornecedor(TipOpe, _
                                                            CodFrn, _
                                                            StaOpe, _
                                                            DatRcbOrdPgt, _
                                                            TipOriOrdPgtFrn, _
                                                            TipOpeBxaOrdPgtFrn, _
                                                            NumOrdPgtFrn, _
                                                            CodBco, _
                                                            CodAge, _
                                                            DatRcbOrdPgtAlt, _
                                                            NomAcsUsrBxaOrdPgtAlt, _
                                                            QbrVlrOrdPgt, _
                                                            QtdQbrAlt, _
                                                            DatRcbOrdPgtIni, _
                                                            DatRcbOrdPgtFim, _
                                                            DatUltPmsOrdIni, _
                                                            DatUltPmsOrdFim, _
                                                            TipIdtEmpAscAcoCmc)

    End Sub

    Private Function chamarOperacaoDeQuebra() As Boolean
        Dim result As Boolean = False

        If Not IsNumeric(cmbTipoOperacaoBaixa.SelectedValue) Then
            Util.AdicionaJsAlert(Me, "Tipo de operação de baixa inválida")
        End If

        If Not IsNumeric(cmbTipoOperacaoBaixa.SelectedValue) Then
            Exit Function
        End If

        DatasetTipoOperacaoBaixaOP1 = Controller.ObterTipoOperacaoBaixaOP(Decimal.Parse(cmbTipoOperacaoBaixa.SelectedValue))
        If DatasetTipoOperacaoBaixaOP1.T0136390.Rows.Count = 0 Then
            Exit Function
        End If

        If DatasetTipoOperacaoBaixaOP1.T0136390(0).INDTIPOPETRNORDPGT = 0 Then
            result = True
        End If

        Return result
    End Function

    Private Sub registrarEventoBtnConfirmar()
        If chamarOperacaoDeQuebra() Then
            btnSalvar.Attributes.Remove("OnClick")
        Else
            btnSalvar.Attributes.Remove("OnClick")
            btnSalvar.Attributes.Add("OnClick", "javascript:return confirm('Tem certeza que deseja transferir esse item ?')")
        End If
    End Sub

    Private Sub GuardaVariaveisJanelaModal()
        Dim hsOperacoesOP As New Hashtable

        With hsOperacoesOP
            .Add("txtValorQuebra", dGridItens.DisplayLayout.ActiveRow().GetCellValue(dGridItens.Columns.FromKey("VlrOrdPgt")))
            .Add("txtOpOriginal", dGridItens.DisplayLayout.ActiveRow().GetCellValue(dGridItens.Columns.FromKey("NumOrdPgtFrn")))
            .Add("txtTotVlrOP", dGridItens.DisplayLayout.ActiveRow().GetCellValue(dGridItens.Columns.FromKey("VlrOrdPgt")))
            .Add("txtCodigoFornecedor", dGridItens.DisplayLayout.ActiveRow().GetCellValue(dGridItens.Columns.FromKey("CodFrn")))
            .Add("txtNomeFornecedor", dGridItens.DisplayLayout.ActiveRow().GetCellValue(dGridItens.Columns.FromKey("NomFrn")))
            .Add("txtDecricaoHistorico", dGridItens.DisplayLayout.ActiveRow().GetCellValue(dGridItens.Columns.FromKey("DesHstDpsIdtFrn")))
            .Add("txtValorSaldo", dGridItens.DisplayLayout.ActiveRow().GetCellValue(dGridItens.Columns.FromKey("VlrOrdPgt")))
            .Add("mlTipOpeBxaOrdPgtFrnPesq", TipOpeBxaOrdPgtFrnPesq)
            .Add("gvOp", dGridItens.DisplayLayout.ActiveRow().GetCellValue(dGridItens.Columns.FromKey("NumOrdPgtFrn")))
            .Add("gvBanco", dGridItens.DisplayLayout.ActiveRow().GetCellValue(dGridItens.Columns.FromKey("CodBco")))
            .Add("gvAgencia", dGridItens.DisplayLayout.ActiveRow().GetCellValue(dGridItens.Columns.FromKey("CodAge")))
            .Add("gvDtaRec", dGridItens.DisplayLayout.ActiveRow().GetCellValue(dGridItens.Columns.FromKey("DatRcbOrdPgt")))
        End With
        WSCAcoesComerciais.hashtableOperacoesOP = hsOperacoesOP

    End Sub

    Protected Function verificaSituacao(ByVal vDad As String) As String
        Dim result As String

        If vDad Is Nothing Then
            result = "ABERTA"
        Else
            If vDad = "" Then
                result = "ABERTA"
            Else
                result = "FECHADA"
            End If
        End If

        Return result
    End Function

#End Region

    Private Sub dGridItens_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.UltraWebGrid.LayoutEventArgs) Handles dGridItens.InitializeLayout

    End Sub
End Class