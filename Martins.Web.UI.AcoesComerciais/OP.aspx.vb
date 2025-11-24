Public Class OP
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetOPRecebidaFornecedor1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetOPRecebidaFornecedor
        CType(Me.DatasetOPRecebidaFornecedor1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetOPRecebidaFornecedor1
        '
        Me.DatasetOPRecebidaFornecedor1.DataSetName = "DatasetOPRecebidaFornecedor"
        Me.DatasetOPRecebidaFornecedor1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetOPRecebidaFornecedor1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents WebTextEdit3 As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents WebDateTimeEdit1 As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents DatasetOPRecebidaFornecedor1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetOPRecebidaFornecedor
    Protected WithEvents Linkbutton1 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents WebTextEdit1 As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDATRCBORDPGT As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtVLRORDPGT As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents cmbNomeBanco As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNomeBanco As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents btnBuscarBanco As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cmbNomeAgencia As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNomeAgencia As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents btnBuscarAgencia As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtCODBCO As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtCODAGE As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtNUMORDPGTFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtDATTRNORDPGTFRN As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtNUMORDPGTORIFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtDESHSTDPSIDTFRN As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents txtDATRCBCREORD As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtDATULTPMSORD As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtNOMACSUSRSIS As Infragistics.WebUI.WebDataInput.WebTextEdit
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
    Protected WithEvents lblTipFrn As System.Web.UI.WebControls.Label
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents ddl1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddl2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddl3 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddl4 As System.Web.UI.WebControls.DropDownList
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

    Private Property vPriNumOrdPgtFrn() As Integer
        Get
            Dim result As Integer = 0
            If Not viewState("vPriNumOrdPgtFrn") Is Nothing Then
                result = CType(viewState("vPriNumOrdPgtFrn"), Integer)
            End If
            Return result
        End Get
        Set(ByVal Value As Integer)
            viewState("vPriNumOrdPgtFrn") = Value
        End Set
    End Property

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
        'AddHandler btnApagar.Click, btnApagar_Click()
        Try
            GerarJavaScript()

            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            End If

            If (Not IsPostBack) Then

                'Obtem OP 
                If Not (Request.QueryString("CODAGE") Is Nothing _
                       Or Request.QueryString("CODBCO") Is Nothing _
                       Or Request.QueryString("DATRCBORDPGT") Is Nothing _
                       Or Request.QueryString("NUMORDPGTFRN") Is Nothing) Then

                    ObterOPRecebidaFornecedor(Decimal.Parse(Request.QueryString("CODAGE")), _
                                              Decimal.Parse(Request.QueryString("CODBCO")), _
                                              Date.Parse(Request.QueryString("DATRCBORDPGT")), _
                                              Decimal.Parse(Request.QueryString("NUMORDPGTFRN")) _
                                             )

                    ViewState("flagInclusao") = False

                    txtCODAGE.ReadOnly = True
                    txtCODBCO.ReadOnly = True
                    txtNUMORDPGTFRN.ReadOnly = True

                    txtCODBCO_ValueChange(sender, Nothing)
                    txtCODAGE_ValueChange(sender, Nothing)

                    If OpFoiRelacionada() Then
                        btnApagar.Enabled = False
                        Util.AdicionaJsAlert(Me.Page, "Atenção, Este documento ja foi relacionado")
                    End If
                    btnSalvar.Enabled = False

                Else
                    txtCODAGE.ReadOnly = False
                    txtCODBCO.ReadOnly = False
                    txtNUMORDPGTFRN.ReadOnly = False
                    ViewState("flagInclusao") = True

                    Try
                        txtNOMACSUSRSIS.Text = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0).NOMACSUSRSIS.Trim
                    Catch ex As Exception
                        Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
                        btnSalvar.Enabled = False
                        btnApagar.Enabled = False
                        Exit Sub
                    End Try

                    txtDATRCBORDPGT.Date = Date.Today
                    btnApagar.Enabled = False
                End If
                Util.AdicionaJsFocus(Me.Page, CType(ddl1, System.web.UI.WebControls.WebControl))
            End If

            'Desabita campos que não apareciam no legado, não exlcui do formulário
            'porque posteriormente alguem pode querer que eles aqui
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

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ucFornecedor_FornecedorAlterado(ByVal e As System.Web.UI.WebControls.ListItem) Handles ucFornecedor.FornecedorAlterado
        VerNumOrdPagFrnAcs()
        Util.AdicionaJsFocus(Me.Page, CType(ddl2, System.web.UI.WebControls.WebControl))
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            If flagProcessando Then
                Exit Sub
            End If
            flagProcessando = True

            AtualizarOPRecebidaFornecedor()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        Finally
            flagProcessando = False
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("OPListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
        ExcluirOPRecebidaFornecedor()
    End Sub

#End Region

#Region "Metodos"

    Private Sub GerarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        'btnCancelar.Attributes.Add("OnClick", "javascript:return confirm('Deseja sair sem salvar?')")
        btnApagar.Attributes.Add("OnClick", "javascript:return confirm('Deseja excluir esse registro?')")
        btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
    End Sub

    Private Function Validar() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = String.Empty
        Dim datasetDivisaoFornecedorAssociado As wsAcoesComerciais.dataSetDivisaoFornecedor
        Dim bln As Boolean

        Try
            Validar = True

            'Banco
            If cmbNomeBanco.SelectedValue = String.Empty Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "banco inválido"
            ElseIf Val(txtCODBCO.Text) <= 0 Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "código do banco inválido"
            End If

            'Agencia
            If cmbNomeAgencia.SelectedValue = String.Empty Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "agencia inválido"
            ElseIf Val(txtCODAGE.Text) <= 0 Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "código da agencia inválido"
            Else
                'Verifica se a agencia é do banco
                Dim datasetAgencia As wsCobrancaBancaria.DatasetAgencia = Controller.ObterAgencia(Decimal.Parse(txtCODAGE.Text), Decimal.Parse(txtCODBCO.Text))
                If datasetAgencia.T0104413.Rows.Count = 0 Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "agencia não é do mesmo banco selecionado"
                End If
            End If

            'OP
            If Val(txtNUMORDPGTFRN.Text) <= 0 Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "número de OP inválido"
            End If

            'Data recebimento
            If Not (IsDate(txtDATRCBORDPGT.Text)) Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "data do recebimento inválida"
            End If

            'Fornecedor
            If ucFornecedor.CodFornecedor = 0 Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "fornecedor não informado"
            End If

            'Valor da OP
            If txtVLRORDPGT.ValueDecimal = 0 Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "valor cheque inválido"
            End If

            'Obtem os dados do fornecedor, posteriormente essa informação será 
            'utilizada para identificar se o fornecedor é principal ou se é
            'associado
            If ucFornecedor.CodFornecedor > 0 Then
                datasetDivisaoFornecedorAssociado = Controller.ObterDivisaoFornecedor(1, Convert.ToInt32(ucFornecedor.CodFornecedor))
            End If

            If txtNUMORDPGTFRN.ValueDecimal >= 15000000 And txtNUMORDPGTFRN.ValueDecimal <= 19999999 And Len(Trim(lblTipFrn.Text)) = 0 Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "O Número da Ordem Pagto pertence ao Fornecedor que é Associado"
            End If

            If txtNUMORDPGTFRN.ValueDecimal > 11000000 And (txtNUMORDPGTFRN.ValueDecimal < 15000000 Or txtNUMORDPGTFRN.ValueDecimal > 19999999) Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "O Número da Ordem Pagto não pode ser maior que 11000000. Exceto para Fornecedor Associado !"
            End If

            If txtNUMORDPGTFRN.ValueDecimal >= 15000000 And txtNUMORDPGTFRN.ValueDecimal <= 19999999 And Len(Trim(lblTipFrn.Text)) > 0 Then
                If CType(ViewState("flagInclusao"), Boolean) Then
                    If txtNUMORDPGTFRN.ValueDecimal > CDbl(vPriNumOrdPgtFrn) Then
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "O Número da Ordem Pagto não pode ser maior " & vPriNumOrdPgtFrn.ToString & " ."
                        bln = txtNUMORDPGTFRN.Enabled
                        txtNUMORDPGTFRN.Enabled = True
                        txtNUMORDPGTFRN.Text = vPriNumOrdPgtFrn.ToString
                        Util.AdicionaJsFocus(Me.Page, CType(txtNUMORDPGTFRN, WebControl))
                        txtNUMORDPGTFRN.Enabled = bln
                    End If
                Else
                    If txtNUMORDPGTFRN.ValueDecimal > CDbl(vPriNumOrdPgtFrn) Then
                        MsgBox("O Número da Ordem Pagto não pode ser maior " & CDbl(vPriNumOrdPgtFrn) & " .")
                        bln = txtNUMORDPGTFRN.Enabled
                        txtNUMORDPGTFRN.Enabled = True
                        txtNUMORDPGTFRN.Text = vPriNumOrdPgtFrn.ToString
                        Util.AdicionaJsFocus(Me.Page, CType(txtNUMORDPGTFRN, WebControl))
                        txtNUMORDPGTFRN.Enabled = bln
                    End If
                End If
            End If

            If mensagemErro.Trim() <> String.Empty Then
                Util.AdicionaJsAlert(Me.Page, (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1))
                'Page.RegisterStartupScript("Alerta", "<script>alert('" & (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1) & "');</script>")
                Return False
            End If
            lblErro.Visible = False
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Public Sub ObterOPRecebidaFornecedor(ByVal CODAGE As Decimal, _
                                         ByVal CODBCO As Decimal, _
                                         ByVal DATRCBORDPGT As Date, _
                                         ByVal NUMORDPGTFRN As Decimal)
        Try
            DatasetOPRecebidaFornecedor1 = Controller.ObterOPRecebidaFornecedor(CODAGE, _
                                                                                CODBCO, _
                                                                                DATRCBORDPGT, _
                                                                                NUMORDPGTFRN)

            With DatasetOPRecebidaFornecedor1.T0118880(0)
                'CODIGO AGENCIA
                txtCODAGE.Text = .CODAGE.ToString
                'CODIGO BANCO
                txtCODBCO.Text = .CODBCO.ToString
                'CODIGO FORNECEDOR
                ucFornecedor.SelecionarFornecedor(.CODFRN)

                'DATA DE RECEBIMENTO DO OP
                'If Not .IsDATRCBCREORDNull Then
                txtDATRCBORDPGT.Date = .DATRCBORDPGT
                'End If

                ''DATA DE TRANSFERENCIA DA ORDEM DE PAGTO DO FORNECEDOR
                'If Not .IsDATTRNORDPGTFRNNull Then
                '    txtDATTRNORDPGTFRN.Text = .DATTRNORDPGTFRN.ToString
                'End If

                ''DESCRICAO DO HISTORICO DO DEPOSITO IDENTIFICADO DO FORNENEDOR
                'If Not .IsDESHSTDPSIDTFRNNull Then
                '    txtDESHSTDPSIDTFRN.Text = .DESHSTDPSIDTFRN.ToString
                'End If

                ''DATA DA ÚLTIMA PROMESSA DO OP
                'If Not .IsDATULTPMSORDNull Then
                '    txtDATULTPMSORD.Text = .DATULTPMSORD.ToString
                'End If

                ''NUMERO DA ORDEM DE PAGTO ORIGINAL DO FORNECEDOR
                'If Not .IsNUMORDPGTORIFRNNull Then
                '    txtNUMORDPGTORIFRN.Text = .NUMORDPGTORIFRN.ToString
                'End If

                ''DATA DE RECEBIMENTO DO CREDITO DO OP
                'If Not .IsDATRCBCREORDNull Then
                '    txtDATRCBCREORD.Text = .DATRCBCREORD.ToString
                'End If

                'NOME ACESSO USUARIO SISTEMA
                txtNOMACSUSRSIS.Text = .NOMACSUSRSIS.Trim()
                'NUMERO DO OP
                txtNUMORDPGTFRN.Text = .NUMORDPGTFRN.ToString
                'VALOR DO TITULO
                txtVLRORDPGT.Text = .VLRORDPGT.ToString

            End With

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Public Sub AtualizarOPRecebidaFornecedor()
        Dim linha As wsAcoesComerciais.DatasetOPRecebidaFornecedor.T0118880Row
        Dim tipoEdicao As Short

        Try
            If Validar() = False Then
                Exit Sub
            End If
            If IsNumeric(txtCODAGE.Text) And _
               IsNumeric(txtCODBCO.Text) And _
               IsDate(txtDATRCBORDPGT.Text) And _
               IsNumeric(txtNUMORDPGTFRN.Text) Then

                DatasetOPRecebidaFornecedor1 = Controller.ObterOPRecebidaFornecedor(txtCODAGE.ValueDecimal, _
                                                                         txtCODBCO.ValueDecimal, _
                                                                         Date.Parse(txtDATRCBORDPGT.Text), _
                                                                         txtNUMORDPGTFRN.ValueDecimal _
                                                                         )

                If CType(ViewState("flagInclusao"), Boolean) Then
                    If DatasetOPRecebidaFornecedor1.T0118880.Rows.Count > 0 Then
                        Page.RegisterStartupScript("Alerta", "<script>alert('Inclusão não permitida, já existe esse registro no banco de dados. Os dados do banco foram carregados.');</script>")
                        btnSalvar.Enabled = False

                        Me.ObterOPRecebidaFornecedor(txtCODAGE.ValueDecimal, _
                                                     txtCODBCO.ValueDecimal, _
                                                     Date.Parse(txtDATRCBORDPGT.Text), _
                                                     txtNUMORDPGTFRN.ValueDecimal)

                        ViewState("flagInclusao") = False
                        Exit Try
                    End If
                End If
            End If

            If DatasetOPRecebidaFornecedor1.T0118880.Rows.Count > 0 Then
                'Update
                linha = DatasetOPRecebidaFornecedor1.T0118880(0)
                If linha.TIPORIORDPGTFRN <> 1 Then
                    Util.AdicionaJsAlert(Me.Page, "Não é permitido alterar OP automática")
                    Exit Sub
                End If
                tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO
                linha.BeginEdit()
            Else
                'Insert
                DatasetOPRecebidaFornecedor1.Clear()
                linha = DatasetOPRecebidaFornecedor1.T0118880.NewT0118880Row
                tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO
                linha.TIPORIORDPGTFRN = 1
            End If
            'Transfere os dados do formulário para o DataSet
            With linha

                'CODIGO AGENCIA
                .CODAGE = txtCODAGE.ValueDecimal
                'CODIGO BANCO
                .CODBCO = txtCODBCO.ValueDecimal
                'CODIGO FORNECEDOR
                .CODFRN = ucFornecedor.CodFornecedor

                'DATA DE RECEBIMENTO DO OP
                If IsDate(txtDATRCBORDPGT.Date) Then
                    .DATRCBORDPGT = txtDATRCBORDPGT.Date
                End If

                ''DATA DE TRANSFERENCIA DA ORDEM DE PAGTO DO FORNECEDOR
                'If IsDate(txtDATTRNORDPGTFRN.Text) Then
                '    .DATTRNORDPGTFRN = CDate(txtDATTRNORDPGTFRN.Text)
                'End If

                ''DATA DA ÚLTIMA PROMESSA DO OP
                'If IsDate(txtDATULTPMSORD.Text) Then
                '    .DATULTPMSORD = CDate(txtDATULTPMSORD.Text)
                'End If

                ''DATA DE RECEBIMENTO DO CREDITO DO OP
                'If IsDate(txtDATRCBCREORD.Text) Then
                '    .DATRCBCREORD = CDate(txtDATRCBCREORD.Text)
                'End If

                ''DESCRICAO DO HISTORICO DO DEPOSITO IDENTIFICADO DO FORNENEDOR
                '.DESHSTDPSIDTFRN = txtDESHSTDPSIDTFRN.Text
                ''NUMERO DA ORDEM DE PAGTO ORIGINAL DO FORNECEDOR
                '.NUMORDPGTORIFRN = txtNUMORDPGTORIFRN.ValueDecimal
                'NOME ACESSO USUARIO SISTEMA
                .NOMACSUSRSIS = txtNOMACSUSRSIS.Text
                'NUMERO DO OP
                .NUMORDPGTFRN = txtNUMORDPGTFRN.ValueDecimal
                'VALOR DO TITULO
                .VLRORDPGT = txtVLRORDPGT.ValueDecimal
            End With
            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                DatasetOPRecebidaFornecedor1.EnforceConstraints = False
                DatasetOPRecebidaFornecedor1.T0118880.AddT0118880Row(linha)
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                linha.EndEdit()
            End If

            Controller.AtualizarOPRecebidaFornecedor(DatasetOPRecebidaFornecedor1)

            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                Page.RegisterStartupScript("Alerta", "<script>alert('Inserido com sucesso!');</script>")
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                Page.RegisterStartupScript("Alerta", "<script>alert('Alterado com sucesso!');</script>")

            End If

            Me.Response.Redirect("OPListar.aspx")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub VerNumOrdPagFrnAcs()
        lblTipFrn.Text = ""
        Dim ds As wsAcoesComerciais.DatasetOPRecebidaFornecedor
        Dim vCod As Integer = 0

        txtNUMORDPGTFRN.ReadOnly = False
        vCod = Convert.ToInt32(ucFornecedor.CodFornecedor)

        If vCod > 0 Then
            ds = Controller.ObterMaximoDeCodigoOrdemPagamentoFornecedor(vCod)
            If ds.TbMaximoDeCodigoOrdemPagamentoFornecedor.Rows.Count > 0 Then
                Dim linha As wsAcoesComerciais.DatasetOPRecebidaFornecedor.TbMaximoDeCodigoOrdemPagamentoFornecedorRow
                linha = ds.TbMaximoDeCodigoOrdemPagamentoFornecedor(0)
                If linha.IsNull("NumOrdPgtFrn") Then
                    vPriNumOrdPgtFrn = 0
                Else
                    vPriNumOrdPgtFrn = Convert.ToInt32(linha.NumOrdPgtFrn)
                End If
                If vPriNumOrdPgtFrn > 0 Then
                    lblTipFrn.Text = "Fornecedor Associado"
                    If CType(ViewState("flagInclusao"), Boolean) = True Then
                        txtNUMORDPGTFRN.ValueInt = vPriNumOrdPgtFrn
                        txtNUMORDPGTFRN.ReadOnly = True
                    End If
                End If
            End If
        End If
        Exit Sub
    End Sub

    Private Function OpFoiRelacionada() As Boolean
        Dim ds As wsAcoesComerciais.DatasetCHRecebidoFornecedor
        Dim result As Boolean = False

        ds = Controller.ObterCHRecebidoFornecedor(txtCODAGE.ValueDecimal, txtCODBCO.ValueDecimal, txtDATRCBORDPGT.Date, txtNUMORDPGTFRN.ValueDecimal)
        If ds.T0118872.Rows.Count > 0 Then
            result = True
        End If

        DatasetOPRecebidaFornecedor1 = Controller.ObterOPRecebidaFornecedor(txtCODAGE.ValueDecimal, _
                                                                 txtCODBCO.ValueDecimal, _
                                                                 Date.Parse(txtDATRCBORDPGT.Text), _
                                                                 txtNUMORDPGTFRN.ValueDecimal _
                                                                 )

        If Not DatasetOPRecebidaFornecedor1.T0118880(0).IsDATULTPMSORDNull Then
            result = True
        End If

        Return result
    End Function

    Public Sub ExcluirOPRecebidaFornecedor()
        Dim linha As wsAcoesComerciais.DatasetOPRecebidaFornecedor.T0118880Row
        Dim tipoEdicao As Short

        Try
            If IsNumeric(txtCODAGE.Text) And _
               IsNumeric(txtCODBCO.Text) And _
               IsDate(txtDATRCBORDPGT.Text) And _
               IsNumeric(txtNUMORDPGTFRN.Text) Then

                DatasetOPRecebidaFornecedor1 = Controller.ObterOPRecebidaFornecedor(txtCODAGE.ValueDecimal, _
                                                                         txtCODBCO.ValueDecimal, _
                                                                         Date.Parse(txtDATRCBORDPGT.Text), _
                                                                         txtNUMORDPGTFRN.ValueDecimal _
                                                                         )

                If OpFoiRelacionada() Then
                    Util.AdicionaJsAlert(Me.Page, "Atenção, Este documento ja foi relacionado")
                    Exit Sub
                End If

                linha = DatasetOPRecebidaFornecedor1.T0118880(0)

                If linha.TIPORIORDPGTFRN <> 1 Then
                    Util.AdicionaJsAlert(Me.Page, "Não é permitido excluir OP automática")
                    Exit Sub
                End If

                linha.Delete()
                Controller.AtualizarOPRecebidaFornecedor(DatasetOPRecebidaFornecedor1)
                Me.Response.Redirect("OPListar.aspx")
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#Region "Busca Banco"

    Private Sub btnBuscarBanco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarBanco.Click
        Dim datasetBanco As wsCobrancaBancaria.DatasetBanco

        If txtNomeBanco.Visible Then
            If txtNomeBanco.Text.Trim.Length < 3 Then
                Page.RegisterStartupScript("Alerta", "<script>alert('É obrigatório digitar no mínimo 3 caracteres do nome antes de pesquisar.');</script>")
                Exit Sub
            End If
            With cmbNomeBanco
                .Visible = True
                .Enabled = True
                .Width = System.Web.UI.WebControls.Unit.Parse("250px")
            End With
            With txtNomeBanco
                .Visible = False
                .Enabled = False
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
            End With
            datasetBanco = Controller.ObterBancos(0, String.Empty, 0, txtNomeBanco.Text, 0)

            If datasetBanco.T0100345.Rows.Count > 0 Then
                Util.carregarCmbBanco(datasetBanco, cmbNomeBanco, Nothing)
                txtCODBCO.Text = cmbNomeBanco.SelectedValue
            End If

            txtNomeBanco.Visible = False
            cmbNomeBanco.Visible = True
        ElseIf cmbNomeBanco.Visible Then
            With cmbNomeBanco
                .Visible = False
                .Enabled = False
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
            End With
            With txtNomeBanco
                .Visible = True
                .Enabled = True
                .Width = System.Web.UI.WebControls.Unit.Parse("250px")
            End With
        End If
    End Sub

    Private Sub cmbNomeBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNomeBanco.SelectedIndexChanged
        txtCODBCO.Text = cmbNomeBanco.SelectedValue
    End Sub

    Private Sub txtCODBCO_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtCODBCO.ValueChange
        Dim datasetBanco As wsCobrancaBancaria.DatasetBanco

        If Not (IsNumeric(txtCODBCO.Text)) Then Exit Sub

        With cmbNomeBanco
            .Visible = True
            .Enabled = True
            .Width = System.Web.UI.WebControls.Unit.Parse("250px")
        End With
        With txtNomeBanco
            .Visible = False
            .Enabled = False
            .Width = System.Web.UI.WebControls.Unit.Parse("0px")
        End With
        datasetBanco = Controller.ObterBanco(Decimal.Parse(txtCODBCO.Text))

        If datasetBanco.T0100345.Rows.Count > 0 Then
            Util.carregarCmbBanco(datasetBanco, cmbNomeBanco, Nothing)
        End If

        txtNomeBanco.Visible = False
        cmbNomeBanco.Visible = True

        Util.AdicionaJsFocus(Me.Page, CType(ddl3, System.web.UI.WebControls.WebControl))
    End Sub
#End Region

#Region "Busca Agencia"

    Private Sub btnBuscarAgencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarAgencia.Click
        Dim datasetAgencia As wsCobrancaBancaria.DatasetAgencia

        If txtNomeAgencia.Visible Then
            If txtNomeAgencia.Text.Trim.Length < 3 Then
                Page.RegisterStartupScript("Alerta", "<script>alert('É obrigatório digitar no mínimo 3 caracteres do nome antes de pesquisar.');</script>")
                Exit Sub
            End If
            With cmbNomeAgencia
                .Visible = True
                .Enabled = True
                .Width = System.Web.UI.WebControls.Unit.Parse("250px")
            End With
            With txtNomeAgencia
                .Visible = False
                .Enabled = False
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
            End With

            datasetAgencia = Controller.ObterAgencias(0, Decimal.Parse(txtCODBCO.Text), 0, 0, String.Empty, txtNomeAgencia.Text)

            If datasetAgencia.T0104413.Rows.Count > 0 Then
                Util.carregarCmbAgencia(datasetAgencia, cmbNomeAgencia, Nothing)
                txtCODAGE.Text = cmbNomeAgencia.SelectedValue
                Page.RegisterStartupScript("e1", "<script>document.getElementById('cmbNomeAgencia').focus();</script>")
            End If

            txtNomeAgencia.Visible = False
            cmbNomeAgencia.Visible = True
        ElseIf cmbNomeAgencia.Visible Then
            With cmbNomeAgencia
                .Visible = False
                .Enabled = False
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
            End With
            With txtNomeAgencia
                .Visible = True
                .Enabled = True
                .Width = System.Web.UI.WebControls.Unit.Parse("250px")
            End With
            Page.RegisterStartupScript("e1", "<script>document.getElementById('igtxttxtNomeAgencia').focus();</script>")
        End If
    End Sub

    Private Sub cmbNomeAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNomeAgencia.SelectedIndexChanged
        txtCODAGE.Text = cmbNomeAgencia.SelectedValue
        Page.RegisterStartupScript("e1", "<script>document.getElementById('igtxttxtNUMCHQ').focus();</script>")
    End Sub

    Private Sub txtCODAGE_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtCODAGE.ValueChange
        Dim datasetAgencia As wsCobrancaBancaria.DatasetAgencia
        Dim flagMostrarCombo As Boolean

        If Not (IsNumeric(txtCODAGE.Text)) Then Exit Sub

        flagMostrarCombo = False
        datasetAgencia = Controller.ObterAgencia(Decimal.Parse(txtCODAGE.Text), Decimal.Parse(txtCODBCO.Text))
        If datasetAgencia.T0104413.Rows.Count > 0 Then
            Util.carregarCmbAgencia(datasetAgencia, cmbNomeAgencia, Nothing)
            Page.RegisterStartupScript("e1", "<script>document.getElementById('igtxttxtNUMCHQ').focus();</script>")
            flagMostrarCombo = True
        Else
            cmbNomeAgencia.Items.Clear()
            txtNomeAgencia.Text = String.Empty
            Util.AdicionaJsAlert(Me.Page, "Código de agencia inválido")
        End If

        With cmbNomeAgencia
            .Visible = flagMostrarCombo
            .Enabled = flagMostrarCombo
            If flagMostrarCombo Then
                .Width = System.Web.UI.WebControls.Unit.Parse("250px")
            Else
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
            End If
        End With
        With txtNomeAgencia
            .Visible = Not flagMostrarCombo
            .Enabled = Not flagMostrarCombo
            If Not flagMostrarCombo Then
                .Width = System.Web.UI.WebControls.Unit.Parse("250px")
            Else
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
            End If
        End With

        If Not IsNumeric(txtCODAGE.Text) Then
            Page.RegisterStartupScript("Alerta", "<script>alert('Agencia não é um código válido');</script>")
            Exit Sub
        End If

        If Not IsNumeric(txtCODBCO.Text) Then
            Page.RegisterStartupScript("Alerta", "<script>alert('Banco não é um código válido');</script>")
            Exit Sub
        End If

        Util.AdicionaJsFocus(Me.Page, CType(ddl4, System.web.UI.WebControls.WebControl))
    End Sub

#End Region

End Class