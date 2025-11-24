Imports Martins.Security.Helper

Public Class Lancamento
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetContaCorrenteFornecedor1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContaCorrenteFornecedor
        CType(Me.DatasetContaCorrenteFornecedor1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetContaCorrenteFornecedor1
        '
        Me.DatasetContaCorrenteFornecedor1.DataSetName = "DatasetContaCorrenteFornecedor"
        Me.DatasetContaCorrenteFornecedor1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetContaCorrenteFornecedor1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetContaCorrenteFornecedor1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContaCorrenteFornecedor
    Protected WithEvents cmbCODTIPLMT As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNUMSEQLMT As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtDATREFLMT As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtNOMACSUSRGRCLMT As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents optCODGDC As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtVLRLMTCTB As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents cmbCODFILEMP As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCODCNTCRD As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtCodCntDeb As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtCODCENCSTCRD As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtCODCENCSTDEB As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtDESHSTLMT As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents txtDESVARHSTPAD As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents ucEmpenho As wucEmpenho
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents TD1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD2 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD3 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD4 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD5 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD6 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD7 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD8 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD9 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD10 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD11 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD12 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD13 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD14 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD15 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD16 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents txtCODHSTPAD As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents lblVariaveisHP As System.Web.UI.WebControls.Label
    Protected WithEvents TD17 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD18 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents P1 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TD19 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD20 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
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

#Region "Eventos"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            End If

            If (Not IsPostBack) Then
                ucFornecedor.widthNome = System.Web.UI.WebControls.Unit.Parse("280px")
                Me.carregarCmbTipoLancamento(Controller.ObterTiposLancamentoContaCorrenteFornecedor(String.Empty, String.Empty), cmbCODTIPLMT, Nothing)
                Util.carregarCmbFilial(Controller.ObterFiliaisExpedicao(1), cmbCODFILEMP, Nothing)

                If Not (Request.QueryString("CODFRN") Is Nothing _
                        Or Request.QueryString("CODGDC") Is Nothing _
                        Or Request.QueryString("DATREFLMT") Is Nothing _
                        Or Request.QueryString("NUMSEQLMT") Is Nothing _
                        Or Request.QueryString("TIPDSNDSCBNF") Is Nothing) Then

                    ObterContaCorrenteFornecedor(Decimal.Parse(Request.QueryString("CODFRN")), Request.QueryString("CODGDC").ToString(), Date.Parse(Request.QueryString("DATREFLMT")), Decimal.Parse(Request.QueryString("NUMSEQLMT")), Decimal.Parse(Request.QueryString("TIPDSNDSCBNF")))

                    txtDATREFLMT.ReadOnly = True
                    txtNUMSEQLMT.ReadOnly = True
                    'cmbTIPDSNDSCBNF.SelectedValue = "0"
                    btnSalvar.Enabled = False
                Else
                    'novo
                    txtDATREFLMT.Date = Date.Now

                    Try
                        txtNOMACSUSRGRCLMT.Text = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0).NOMACSUSRSIS.Trim
                    Catch ex As Exception
                        Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
                        btnSalvar.Enabled = False
                        btnApagar.Enabled = False
                        Exit Sub
                    End Try

                    txtNUMSEQLMT.ValueDecimal = 0
                    'optCODGDC.SelectedValue = "D"
                    txtDATREFLMT.ReadOnly = False
                    txtNUMSEQLMT.ReadOnly = False
                    ' cmbTIPDSNDSCBNF.SelectedValue = "0"
                    ViewState("flagInclusao") = True
                    btnSalvar.Enabled = True
                End If
                cmbCODTIPLMT_SelectedIndexChanged(sender, e)
                esconderLinhasReferenteAParametrosFilial()
            End If
            GerarJavaScript() 'No final do método porque depende da variavel ViewState("flagInclusao") = True
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
            AtualizarContaCorrenteFornecedor()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        Finally
            flagProcessando = False
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("ContaCorrenteFornecedorListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmbCODTIPLMT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCODTIPLMT.SelectedIndexChanged
        Try
            'Verificar na tabela T0133108 (Tipo de lançamento) o atributo FlgGrcLmtCtb
            'Caso seja = 'S' Mostra os campos referente aos parametros (tela maior)
            'Caso seja = 'N' NÃO Mostra os campos referente aos parametros (tela maior)

            If Not IsNumeric(cmbCODTIPLMT.SelectedValue) Then
                Me.esconderLinhasReferenteAParametrosFilial()
                Exit Sub
            End If

            If tipoLancamentoUtilizaParametrosFilial() Then
                Me.mostrarLinhasReferenteAParametrosFilial()
                Exit Sub
            Else
                Me.esconderLinhasReferenteAParametrosFilial()
                Exit Sub
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmbCODFILEMP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCODFILEMP.SelectedIndexChanged
        Try
            ObterParametroContabilContaCorrenteFornecedor()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#Region "Métodos"

    Private Sub GerarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        If CType(ViewState("flagInclusao"), Boolean) Then
            btnCancelar.Attributes.Add("OnClick", "javascript:return confirm('Deseja sair sem salvar?')")
        Else
            btnCancelar.Attributes.Remove("OnClick")
        End If
        btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
    End Sub

    Private Function Validar() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = String.Empty

        Try
            Validar = True

            'Fornecedor
            If ucFornecedor.CodFornecedor = 0 Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "fornecedor não informado"
            End If
            'data
            If Not (IsDate(txtDATREFLMT.Text)) Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "data inválida"
            End If
            'usuário
            If txtNOMACSUSRGRCLMT.Text = String.Empty Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "usuário inválido"
            End If
            'valor
            If txtVLRLMTCTB.ValueDecimal <= 0 Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "valor inválido"
            End If
            'histórico
            If txtDESHSTLMT.Text = String.Empty Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "histórico inválido"
            End If
            'Empenho
            If ucEmpenho.CodEmpenho = 0 Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "empenho inválido"
            End If
            'Tipo do lançamento
            If Not IsNumeric(cmbCODTIPLMT.SelectedValue) Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "tipo de lançamento inválido"
            Else
                If CDec(cmbCODTIPLMT.SelectedValue) = 0 Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "tipo de lançamento inválido"
                End If
            End If
            'Filial
            If tipoLancamentoUtilizaParametrosFilial() Then
                If Not IsNumeric(cmbCODFILEMP.SelectedValue) Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "informe a filial"
                Else
                    If CDec(cmbCODFILEMP.SelectedValue) = 0 Then
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "informe a filial"
                    End If
                End If
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

    Public Sub ObterContaCorrenteFornecedor(ByVal CODFRN As Decimal, _
                                            ByVal CODGDC As String, _
                                            ByVal DATREFLMT As Date, _
                                            ByVal NUMSEQLMT As Decimal, _
                                            ByVal TIPDSNDSCBNF As Decimal)
        Try
            DatasetContaCorrenteFornecedor1 = Controller.ObterContaCorrenteFornecedor(CODFRN, _
                                                                                      CODGDC, _
                                                                                      DATREFLMT, _
                                                                                      NUMSEQLMT, _
                                                                                      TIPDSNDSCBNF)

            With DatasetContaCorrenteFornecedor1.T0123086(0)
                'CODIGO CENTRO DE CUSTRO DE CREDITO
                If Not .IsNull("CODCENCSTCRD") Then
                    txtCODCENCSTCRD.Text = .CODCENCSTCRD.Trim()
                End If
                'CODIGO CENTRO DE CUSTRO DE DEBITO
                If Not .IsNull("CODCENCSTDEB") Then
                    txtCODCENCSTDEB.Text = .CODCENCSTDEB.Trim()
                End If
                'CODIGO CONTA CONTABIL
                If Not .IsNull("CODCNTCRD") Then
                    txtCODCNTCRD.Text = .CODCNTCRD.Trim()
                End If
                'CODIGO CONTA CONTABIL
                If Not .IsNull("CODCNTDEB") Then
                    txtCodCntDeb.Text = .CODCNTDEB.Trim()
                End If
                'CODIGO DA FILIAL DA EMPRESA
                If Not .IsNull("CODFILEMP") Then
                    If Not cmbCODFILEMP.Items.FindByValue(.CODFILEMP.ToString) Is Nothing Then
                        cmbCODFILEMP.SelectedValue = .CODFILEMP.ToString
                    End If
                End If
                'CODIGO FORNECEDOR
                If Not .IsNull("CODFRN") Then
                    ucFornecedor.SelecionarFornecedor(.CODFRN)
                End If
                'CODIGO CONTROLE TRANSACAO CABECALHO DE UM LANCAMENTO
                If Not .IsNull("CODGDC") Then
                    optCODGDC.SelectedValue = .CODGDC.Trim()
                End If
                ''CODIGO PROMESSA
                'If Not .IsNull("CODPMS") Then
                '    txtCODPMS.Text = .CODPMS.ToString
                'End If
                'CODIGO TIPO LANCAMENTO
                If Not .IsNull("CODTIPLMT") Then
                    cmbCODTIPLMT.SelectedValue = .CODTIPLMT.ToString
                End If
                'DATA REFERENCIA (AAAA-MM-DD)
                'If Not .IsNull("DATCTBLMT") Then
                '    txtDATCTBLMT.Text = .DATCTBLMT.ToString
                'End If
                'DATA REFERENCIA (AAAA-MM-DD)
                If Not .IsNull("DATREFLMT") Then
                    txtDATREFLMT.Text = .DATREFLMT.ToString
                End If
                'DESCRICAO DO HISTORICO CONTA CORRENTE
                If Not .IsNull("DESHSTLMT") Then
                    txtDESHSTLMT.Text = .DESHSTLMT.Trim()
                End If
                'DESCRICAO DA VARIAVEL DO HISTORICO PADRAO
                If Not .IsNull("DESVARHSTPAD") Then
                    txtDESVARHSTPAD.Text = .DESVARHSTPAD.Trim()
                End If
                'NOME USUARIO PARA EXECUCAO DO JOB
                If Not .IsNull("NOMACSUSRGRCLMT") Then
                    txtNOMACSUSRGRCLMT.Text = .NOMACSUSRGRCLMT.Trim()
                End If
                'NUMERO SEQUENCIA
                If Not .IsNull("NUMSEQLMT") Then
                    txtNUMSEQLMT.Text = .NUMSEQLMT.ToString
                End If
                'TIPO DESTINO / DESCONTO BONIFICADO
                If Not .IsNull("TIPDSNDSCBNF") Then
                    ucEmpenho.SelecionarEmpenho(.TIPDSNDSCBNF)
                End If
                ''
                'If Not .IsNull("TIPDSNDSCEVTACOCMC") Then
                '    txtTIPDSNDSCEVTACOCMC.Text = .TIPDSNDSCEVTACOCMC.ToString
                'End If
                'VALOR LANCAMENTO CONTABIL
                If Not .IsNull("VLRLMTCTB") Then
                    txtVLRLMTCTB.Text = .VLRLMTCTB.ToString
                End If
            End With

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Public Sub AtualizarContaCorrenteFornecedor()
        Dim linha As wsAcoesComerciais.DatasetContaCorrenteFornecedor.T0123086Row
        Dim tipoEdicao As Short

        Try
            If Validar() = False Then
                Exit Sub
            End If

            If ucFornecedor.CodFornecedor > 0 And _
                optCODGDC.SelectedValue <> String.Empty And _
                IsDate(txtDATREFLMT.Text) And _
                IsNumeric(txtNUMSEQLMT.Text) And _
                ucEmpenho.CodEmpenho > 0 Then

                DatasetContaCorrenteFornecedor1 = Controller.ObterContaCorrenteFornecedor(ucFornecedor.CodFornecedor, _
                                                                                          optCODGDC.SelectedValue, _
                                                                                          Date.Parse(txtDATREFLMT.Text), _
                                                                                          txtNUMSEQLMT.ValueDecimal, _
                                                                                          ucEmpenho.CodEmpenho)

                If CType(ViewState("flagInclusao"), Boolean) Then
                    If DatasetContaCorrenteFornecedor1.T0123086.Rows.Count > 0 Then
                        Page.RegisterStartupScript("Alerta", "<script>alert('Inclusão não permitida, já existe esse registro no banco de dados. Os dados do banco foram carregados.');</script>")
                        ObterContaCorrenteFornecedor(ucFornecedor.CodFornecedor, _
                                                      optCODGDC.SelectedValue, _
                                                      txtDATREFLMT.Date, _
                                                      txtNUMSEQLMT.ValueDecimal, _
                                                      ucEmpenho.CodEmpenho)

                        ViewState("flagInclusao") = False
                        Exit Try
                    End If
                End If
            End If

            If DatasetContaCorrenteFornecedor1.T0123086.Rows.Count > 0 Then
                'Update
                linha = DatasetContaCorrenteFornecedor1.T0123086(0)
                tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO
                linha.BeginEdit()
            Else
                'Insert
                DatasetContaCorrenteFornecedor1.Clear()
                linha = DatasetContaCorrenteFornecedor1.T0123086.NewT0123086Row
                tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO
            End If
            'Transfere os dados do formulário para o DataSet
            With linha
                'CODIGO FORNECEDOR
                .CODFRN = ucFornecedor.CodFornecedor
                'TIPO DESTINO / DESCONTO BONIFICADO
                .TIPDSNDSCBNF = ucEmpenho.CodEmpenho
                'CODIGO TIPO LANCAMENTO
                .CODTIPLMT = Decimal.Parse(cmbCODTIPLMT.SelectedValue)
                'NUMERO SEQUENCIA
                .NUMSEQLMT = txtNUMSEQLMT.ValueDecimal
                'DATA REFERENCIA (AAAA-MM-DD)
                .DATREFLMT = txtDATREFLMT.Date
                'NOME USUARIO PARA EXECUCAO DO JOB
                .NOMACSUSRGRCLMT = txtNOMACSUSRGRCLMT.Text.ToUpper()
                'CODIGO CONTROLE TRANSACAO CABECALHO DE UM LANCAMENTO
                .CODGDC = optCODGDC.SelectedValue
                'VALOR LANCAMENTO CONTABIL
                .VLRLMTCTB = txtVLRLMTCTB.ValueDecimal
                'DESCRICAO DO HISTORICO CONTA CORRENTE
                .DESHSTLMT = txtDESHSTLMT.Text.ToUpper()
                If tipoLancamentoUtilizaParametrosFilial() Then
                    'CODIGO CENTRO DE CUSTRO DE CREDITO
                    .CODCENCSTCRD = txtCODCENCSTCRD.Text.ToUpper()
                    'CODIGO CENTRO DE CUSTRO DE DEBITO
                    .CODCENCSTDEB = txtCODCENCSTDEB.Text.ToUpper()
                    'CODIGO CONTA CONTABIL
                    .CODCNTCRD = txtCODCNTCRD.Text.ToUpper()
                    'CODIGO CONTA CONTABIL
                    .CODCNTDEB = txtCodCntDeb.Text.ToUpper()
                    'CODIGO DA FILIAL DA EMPRESA
                    .CODFILEMP = Decimal.Parse(cmbCODFILEMP.SelectedValue)
                    'DESCRICAO DA VARIAVEL DO HISTORICO PADRAO
                    .DESVARHSTPAD = txtDESVARHSTPAD.Text.ToUpper()
                Else
                    'CODIGO CENTRO DE CUSTRO DE CREDITO
                    .CODCENCSTCRD = ""
                    'CODIGO CENTRO DE CUSTRO DE DEBITO
                    .CODCENCSTDEB = ""
                    'CODIGO CONTA CONTABIL
                    .CODCNTCRD = ""
                    'CODIGO CONTA CONTABIL
                    .CODCNTDEB = ""
                    'CODIGO DA FILIAL DA EMPRESA
                    .CODFILEMP = 0
                    'DESCRICAO DA VARIAVEL DO HISTORICO PADRAO
                    .DESVARHSTPAD = ""
                End If

                'CODIGO PROMESSA
                If .IsCODPMSNull Then
                    .CODPMS = 0
                End If

                'DATA REFERENCIA (AAAA-MM-DD)
                '.DATCTBLMT = Date.Parse(txtDATCTBLMT.Text)
                '
                '.TIPDSNDSCEVTACOCMC = txtTIPDSNDSCEVTACOCMC.ValueDecimal
            End With
            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                DatasetContaCorrenteFornecedor1.EnforceConstraints = False
                DatasetContaCorrenteFornecedor1.T0123086.AddT0123086Row(linha)
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                linha.EndEdit()
            End If

            Controller.AtualizarContaCorrenteFornecedor(DatasetContaCorrenteFornecedor1)

            Me.Response.Redirect("LancamentoListar.aspx")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ObterParametroContabilContaCorrenteFornecedor()
        Dim ds As wsAcoesComerciais.DatasetParametroContabilContaCorrenteFornecedor
        Dim linha As wsAcoesComerciais.DatasetParametroContabilContaCorrenteFornecedor.T0123094Row

        If Not (IsNumeric(cmbCODTIPLMT.SelectedValue)) Then
            limparParametrosContabilContaCorrenteFornecedor()
            Util.AdicionaJsAlert(Me, "Tipo de lançamento inválido")
            Exit Sub
        End If
        If Not (IsNumeric(cmbCODFILEMP.SelectedValue)) Then
            limparParametrosContabilContaCorrenteFornecedor()
            Util.AdicionaJsAlert(Me, "Filial inválida")
            Exit Sub
        End If

        ds = Controller.ObterParametroContabilContaCorrenteFornecedor(Convert.ToDecimal(cmbCODFILEMP.SelectedValue), Convert.ToDecimal(cmbCODTIPLMT.SelectedValue))
        If ds.T0123094.Rows.Count > 0 Then
            linha = ds.T0123094(0)
            txtCODCNTCRD.Text = linha.CODCNTCRD
            txtCODCENCSTCRD.Text = linha.CODCENCSTCRD
            txtCodCntDeb.Text = linha.CODCNTDEB
            txtCODCENCSTDEB.Text = linha.CODCENCSTDEB
            txtCODHSTPAD.Text = linha.CODHSTPAD
        End If
    End Sub

    Private Sub limparParametrosContabilContaCorrenteFornecedor()
        txtCODCNTCRD.Text = ""
        txtCODCENCSTCRD.Text = ""
        txtCodCntDeb.Text = ""
        txtCODCENCSTDEB.Text = ""
        txtCODHSTPAD.Text = ""
    End Sub

    Private Function tipoLancamentoUtilizaParametrosFilial() As Boolean
        'Verificar na tabela T0133108 (Tipo de lançamento) o atributo FlgGrcLmtCtb
        'Caso seja = 'S' Mostra os campos referente aos parametros (tela maior)
        'Caso seja = 'N' NÃO Mostra os campos referente aos parametros (tela maior)
        Dim datasetTipoLancamentoContaCorrenteFornecedor As wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor
        Dim result As Boolean

        datasetTipoLancamentoContaCorrenteFornecedor = Controller.ObterTipoLancamentoContaCorrenteFornecedor(CDec(cmbCODTIPLMT.SelectedValue))
        If datasetTipoLancamentoContaCorrenteFornecedor.T0123108.Rows.Count = 0 Then
            result = False
            Return result
        End If

        If datasetTipoLancamentoContaCorrenteFornecedor.T0123108(0).FLGGRCLMTCTB = "S" Then
            result = True
        Else
            result = False
        End If
        Return result
    End Function

    Private Sub esconderLinhasReferenteAParametrosFilial()
        TD1.Visible = False
        TD2.Visible = False
        TD3.Visible = False
        TD4.Visible = False
        TD5.Visible = False
        TD6.Visible = False
        TD7.Visible = False
        TD8.Visible = False
        TD9.Visible = False
        TD10.Visible = False
        TD11.Visible = False
        TD12.Visible = False
        TD13.Visible = False
        TD14.Visible = False
        TD15.Visible = False
        TD16.Visible = False
        TD17.Visible = False
        TD18.Visible = False
        TD19.Visible = False
        TD20.Visible = False
    End Sub

    Private Sub mostrarLinhasReferenteAParametrosFilial()
        TD1.Visible = True
        TD2.Visible = True
        TD3.Visible = True
        TD4.Visible = True
        TD5.Visible = True
        TD6.Visible = True
        TD7.Visible = True
        TD8.Visible = True
        TD9.Visible = True
        TD10.Visible = True
        TD11.Visible = True
        TD12.Visible = True
        TD13.Visible = True
        TD14.Visible = True
        TD15.Visible = True
        TD16.Visible = True
        TD17.Visible = True
        TD18.Visible = True
        TD19.Visible = True
        TD20.Visible = True
    End Sub

    Private Sub carregarCmbTipoLancamento(ByRef ds As wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor.T0123108Row In ds.T0123108.Select("", "CODTIPLMT")
                If linha.FLGLMTMAN = "S" Then
                    .Items.Add(New ListItem(Format(linha.CODTIPLMT, "0000") & " - " & linha.DESTIPLMT, linha.CODTIPLMT.ToString))
                End If
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

#End Region

End Class