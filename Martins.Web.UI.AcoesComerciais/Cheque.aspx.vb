Public Class Cheque
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetCHRecebidoFornecedor1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetCHRecebidoFornecedor
        CType(Me.DatasetCHRecebidoFornecedor1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetCHRecebidoFornecedor1
        '
        Me.DatasetCHRecebidoFornecedor1.DataSetName = "DatasetCHRecebidoFornecedor"
        Me.DatasetCHRecebidoFornecedor1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetCHRecebidoFornecedor1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents WebTextEdit3 As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents WebDateTimeEdit1 As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents DatasetCHRecebidoFornecedor1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetCHRecebidoFornecedor
    Protected WithEvents Linkbutton1 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents WebTextEdit1 As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDATRCBCHQ As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtVLRCHQ As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents btnBuscarFornecedor As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtNomeFornecedor As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents cmbNomeFornecedor As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmbNomeBanco As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNomeBanco As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents btnBuscarBanco As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cmbNomeAgencia As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNomeAgencia As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents btnBuscarAgencia As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtCODBCO As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtCODAGE As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtCODFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtNUMCHQ As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtDATRCBCRECHQ As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtDATULTPMSCHQ As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtNOMACSUSRSIS As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents TD1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD2 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD3 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD4 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents ddl1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddl2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddl4 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddl3 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddl5 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'AddHandler btnApagar.Click, btnApagar_Click()
        Try
            GerarJavaScript()

            If (Not IsPostBack) Then

                'Obtem MOVIMENTO DIARIO CHEQUE RECEBIDO DO FORNECEDOR - COMPRAS
                If Not (Request.QueryString("CODAGE") Is Nothing _
                       Or Request.QueryString("CODBCO") Is Nothing _
                       Or Request.QueryString("DATRCBCHQ") Is Nothing _
                       Or Request.QueryString("NUMCHQ") Is Nothing) Then

                    ObterCHRecebidoFornecedor(Decimal.Parse(Request.QueryString("CODAGE")), _
                                              Decimal.Parse(Request.QueryString("CODBCO")), _
                                              Date.Parse(Request.QueryString("DATRCBCHQ")), _
                                              Decimal.Parse(Request.QueryString("NUMCHQ")) _
                                             )

                    txtCODAGE.ReadOnly = True
                    txtCODBCO.ReadOnly = True
                    txtDATRCBCHQ.ReadOnly = True
                    txtNUMCHQ.ReadOnly = True

                    txtCODFRN_ValueChange(sender, Nothing)
                    txtCODBCO_ValueChange(sender, Nothing)
                    txtCODAGE_ValueChange(sender, Nothing)
                Else
                    txtCODAGE.ReadOnly = False
                    txtCODBCO.ReadOnly = False
                    txtDATRCBCHQ.ReadOnly = False
                    txtNUMCHQ.ReadOnly = False
                    ViewState("flagInclusao") = True

                    Try
                        txtNOMACSUSRSIS.Text = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0).NOMACSUSRSIS.Trim
                    Catch ex As Exception
                        Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
                        btnSalvar.Enabled = False
                        btnApagar.Enabled = False
                        Exit Sub
                    End Try

                End If
                Util.AdicionaJsFocus(Me.Page, CType(ddl1, System.web.UI.WebControls.WebControl))
            End If

            'Desabita campos que não apareciam no legado, não exlcui do formulário
            'porque posteriormente alguem pode querer que eles aqui
            TD1.Visible = False
            TD2.Visible = False
            TD3.Visible = False
            TD4.Visible = False

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub GerarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        btnCancelar.Attributes.Add("OnClick", "javascript:return confirm('Deseja sair sem salvar?')")
        btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If flagProcessando Then
                Exit Sub
            End If
            flagProcessando = True
            AtualizarCHRecebidoFornecedor()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        Finally
            flagProcessando = False
        End Try
    End Sub

    Private Function Validar() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = String.Empty

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
            End If

            'Numero cheque
            If Val(txtNUMCHQ.Text) <= 0 Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "número de cheque inválido"
            End If

            'Data recebimento
            If Not (IsDate(txtDATRCBCHQ.Text)) Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "data do recebimento inválida"
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

            ''Data Recebimento do credito
            'If Not (IsDate(txtDATRCBCRECHQ.Text)) Then
            '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '    mensagemErro &= "data do recebimento credito inválida"
            'End If

            ''Data do último acordo
            'If Not (IsDate(txtDATULTPMSCHQ.Text)) Then
            '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '    mensagemErro &= "data do último acordo inválida"
            'End If

            ''usuário
            'If txtNOMACSUSRSIS.Text = String.Empty Then
            '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '    mensagemErro &= "usuário inválido"
            'End If

            'Valor do cheque
            If txtVLRCHQ.ValueDecimal = 0 Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "valor cheque inválido"
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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Response.Redirect("ChequeListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Public Sub ObterCHRecebidoFornecedor(ByVal CODAGE As Decimal, _
                                         ByVal CODBCO As Decimal, _
                                         ByVal DATRCBCHQ As Date, _
                                         ByVal NUMCHQ As Decimal)
        Try
            DatasetCHRecebidoFornecedor1 = Controller.ObterCHRecebidoFornecedor(CODAGE, _
                                                                                CODBCO, _
                                                                                DATRCBCHQ, _
                                                                                NUMCHQ)

            With DatasetCHRecebidoFornecedor1.T0118872(0)
                'CODIGO AGENCIA
                txtCODAGE.Text = .CODAGE.ToString
                'CODIGO BANCO
                txtCODBCO.Text = .CODBCO.ToString
                'CODIGO FORNECEDOR
                txtCODFRN.Text = .CODFRN.ToString
                'DATA DE RECEBIMENTO DO CHEQUE
                If Not .IsDATRCBCRECHQNull Then
                    txtDATRCBCHQ.Text = .DATRCBCHQ.ToString
                End If
                ''DATA DE RECEBIMENTO DO CREDITO DO CHEQUE
                'txtDATRCBCRECHQ.Text = .DATRCBCRECHQ.ToString
                ''DATA DA ÚLTIMA PROMESSA DO CHEQUE
                'If Not .IsDATULTPMSCHQNull Then
                '    txtDATULTPMSCHQ.Text = .DATULTPMSCHQ.ToString
                'End If
                'NOME ACESSO USUARIO SISTEMA
                txtNOMACSUSRSIS.Text = .NOMACSUSRSIS.Trim()
                'NUMERO DO CHEQUE
                txtNUMCHQ.Text = .NUMCHQ.ToString
                'VALOR DO TITULO
                txtVLRCHQ.Text = .VLRCHQ.ToString
            End With

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Public Sub AtualizarCHRecebidoFornecedor()
        Dim linha As wsAcoesComerciais.DatasetCHRecebidoFornecedor.T0118872Row
        Dim tipoEdicao As Short

        Try
            If Validar() = False Then
                Exit Sub
            End If
            If IsNumeric(txtCODAGE.Text) And _
               IsNumeric(txtCODBCO.Text) And _
               IsDate(txtDATRCBCHQ.Text) And _
               IsNumeric(txtNUMCHQ.Text) Then

                DatasetCHRecebidoFornecedor1 = Controller.ObterCHRecebidoFornecedor(txtCODAGE.ValueDecimal, _
                                                                         txtCODBCO.ValueDecimal, _
                                                                         Date.Parse(txtDATRCBCHQ.Text), _
                                                                         txtNUMCHQ.ValueDecimal _
                                                                         )

                If CType(ViewState("flagInclusao"), Boolean) Then
                    If DatasetCHRecebidoFornecedor1.T0118872.Rows.Count > 0 Then
                        Page.RegisterStartupScript("Alerta", "<script>alert('Inclusão não permitida, já existe esse registro no banco de dados. Os dados do banco foram carregados.');</script>")

                        Me.ObterCHRecebidoFornecedor(txtCODAGE.ValueDecimal, _
                                                     txtCODBCO.ValueDecimal, _
                                                     Date.Parse(txtDATRCBCHQ.Text), _
                                                     txtNUMCHQ.ValueDecimal)

                        ViewState("flagInclusao") = False
                        Exit Try
                    End If
                End If
            End If

            If DatasetCHRecebidoFornecedor1.T0118872.Rows.Count > 0 Then
                'Update
                linha = DatasetCHRecebidoFornecedor1.T0118872(0)
                tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO
                linha.BeginEdit()
            Else
                'Insert
                DatasetCHRecebidoFornecedor1.Clear()
                linha = DatasetCHRecebidoFornecedor1.T0118872.NewT0118872Row
                tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO
            End If
            'Transfere os dados do formulário para o DataSet
            With linha
                'CODIGO AGENCIA
                .CODAGE = txtCODAGE.ValueDecimal
                'CODIGO BANCO
                .CODBCO = txtCODBCO.ValueDecimal
                'CODIGO FORNECEDOR
                .CODFRN = txtCODFRN.ValueDecimal
                'DATA DE RECEBIMENTO DO CHEQUE
                .DATRCBCHQ = Date.Parse(txtDATRCBCHQ.Text)
                'DATA DE RECEBIMENTO DO CREDITO DO CHEQUE
                '.DATRCBCRECHQ = Date.Parse(txtDATRCBCRECHQ.Text)
                ''DATA DA ULTIMA PROMESSA DE CHEQUE
                'If IsDate(txtDATULTPMSCHQ) Then
                '    .DATULTPMSCHQ = Date.Parse(txtDATULTPMSCHQ.Text)
                'End If
                'NOME ACESSO USUARIO SISTEMA
                .NOMACSUSRSIS = txtNOMACSUSRSIS.Text
                'NUMERO DO CHEQUE
                .NUMCHQ = txtNUMCHQ.ValueDecimal
                'VALOR DO TITULO
                .VLRCHQ = txtVLRCHQ.ValueDecimal
            End With
            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                DatasetCHRecebidoFornecedor1.EnforceConstraints = False
                DatasetCHRecebidoFornecedor1.T0118872.AddT0118872Row(linha)
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                linha.EndEdit()
            End If

            Controller.AtualizarCHRecebidoFornecedor(DatasetCHRecebidoFornecedor1)

            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                Page.RegisterStartupScript("Alerta", "<script>alert('Inserido com sucesso!');</script>")
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                Page.RegisterStartupScript("Alerta", "<script>alert('Alterado com sucesso!');</script>")
            End If

            Me.Response.Redirect("ChequeListar.aspx")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#Region "Busca Fornecedor"

    Private Sub btnBuscarFornecedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarFornecedor.Click
        Dim datasetFornecedor As wsAcoesComerciais.dataSetDivisaoFornecedor

        If txtNomeFornecedor.Visible Then
            If txtNomeFornecedor.Text.Trim.Length < 3 Then
                Page.RegisterStartupScript("Alerta", "<script>alert('É obrigatório digitar no mínimo 3 caracteres do nome antes de pesquisar.');</script>")
                Exit Sub
            End If
            With cmbNomeFornecedor
                .Visible = True
                .Enabled = True
                .Width = System.Web.UI.WebControls.Unit.Parse("280px")
            End With
            With txtNomeFornecedor
                .Visible = False
                .Enabled = False
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
            End With
            datasetFornecedor = Controller.ObterDivisoesFornecedor(1, txtNomeFornecedor.Text)

            If datasetFornecedor.T0100426.Rows.Count > 0 Then
                cmbNomeFornecedor.Items.Clear()
                Util.carregarCmbDivisaoFornecedor(datasetFornecedor, cmbNomeFornecedor, Nothing)
                txtCODFRN.Text = cmbNomeFornecedor.SelectedValue
                Page.RegisterStartupScript("e1", "<script>document.getElementById('cmbNomeFornecedor').focus();</script>")
            End If

            txtNomeFornecedor.Visible = False
            cmbNomeFornecedor.Visible = True
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
            Page.RegisterStartupScript("e1", "<script>document.getElementById('igtxttxtCODFRN').focus();</script>")
        End If
    End Sub

    Private Sub cmbNomeFornecedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNomeFornecedor.SelectedIndexChanged
        txtCODFRN.Text = cmbNomeFornecedor.SelectedValue
        Page.RegisterStartupScript("e1", "<script>document.getElementById('igtxttxtDATRCBCRECHQ').focus();</script>")
    End Sub

    Private Sub txtCODFRN_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtCODFRN.ValueChange
        Dim datasetFornecedor As wsAcoesComerciais.dataSetDivisaoFornecedor
        Dim flagMostrarCombo As Boolean

        If Not (IsNumeric(txtCODFRN.Text)) Then Exit Sub

        datasetFornecedor = Controller.ObterDivisaoFornecedor(1, CLng(txtCODFRN.Text))

        If datasetFornecedor.T0100426.Rows.Count > 0 Then
            Util.carregarCmbDivisaoFornecedor(datasetFornecedor, cmbNomeFornecedor, Nothing)
            Page.RegisterStartupScript("e1", "<script>document.getElementById('igtxttxtDATRCBCRECHQ').focus();</script>")
            flagMostrarCombo = True
        Else
            cmbNomeFornecedor.Items.Clear()
            Util.AdicionaJsAlert(Me.Page, "Código de fornecedor inválido")
            Exit Sub
        End If

        With cmbNomeFornecedor
            .Visible = flagMostrarCombo
            .Enabled = flagMostrarCombo
            If flagMostrarCombo Then .Width = System.Web.UI.WebControls.Unit.Parse("280px")
        End With
        With txtNomeFornecedor
            .Visible = Not flagMostrarCombo
            .Enabled = Not flagMostrarCombo
            If flagMostrarCombo Then .Width = System.Web.UI.WebControls.Unit.Parse("0px")
        End With

        txtNomeFornecedor.Visible = False
        cmbNomeFornecedor.Visible = True

        Util.AdicionaJsFocus(Me.Page, CType(ddl5, System.web.UI.WebControls.WebControl))
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
                .Width = System.Web.UI.WebControls.Unit.Parse("350px")
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
            Page.RegisterStartupScript("e1", "<script>document.getElementById('cmbNomeBanco').focus();</script>")
        ElseIf cmbNomeBanco.Visible Then
            With cmbNomeBanco
                .Visible = False
                .Enabled = False
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
            End With
            With txtNomeBanco
                .Visible = True
                .Enabled = True
                .Width = System.Web.UI.WebControls.Unit.Parse("350px")
            End With
            Page.RegisterStartupScript("e1", "<script>document.getElementById('igtxttxtNomeBanco').focus();</script>")
        End If
    End Sub

    Private Sub cmbNomeBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNomeBanco.SelectedIndexChanged
        txtCODBCO.Text = cmbNomeBanco.SelectedValue
        Page.RegisterStartupScript("e1", "<script>document.getElementById('igtxttxtCODAGE').focus();</script>")
    End Sub

    Private Sub txtCODBCO_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtCODBCO.ValueChange
        Dim datasetBanco As wsCobrancaBancaria.DatasetBanco

        If Not (IsNumeric(txtCODBCO.Text)) Then Exit Sub

        With cmbNomeBanco
            .Visible = True
            .Enabled = True
            .Width = System.Web.UI.WebControls.Unit.Parse("350px")
        End With
        With txtNomeBanco
            .Visible = False
            .Enabled = False
            .Width = System.Web.UI.WebControls.Unit.Parse("0px")
        End With
        datasetBanco = Controller.ObterBanco(Decimal.Parse(txtCODBCO.Text))

        If datasetBanco.T0100345.Rows.Count > 0 Then
            Util.carregarCmbBanco(datasetBanco, cmbNomeBanco, Nothing)
            Page.RegisterStartupScript("e1", "<script>document.getElementById('igtxttxtCODAGE').focus();</script>")
        End If

        txtNomeBanco.Visible = False
        cmbNomeBanco.Visible = True
        Util.AdicionaJsFocus(Me.Page, CType(ddl2, System.web.UI.WebControls.WebControl))
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
                .Width = System.Web.UI.WebControls.Unit.Parse("350px")
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
                .Width = System.Web.UI.WebControls.Unit.Parse("350px")
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
                .Width = System.Web.UI.WebControls.Unit.Parse("350px")
            Else
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
            End If
        End With
        With txtNomeAgencia
            .Visible = Not flagMostrarCombo
            .Enabled = Not flagMostrarCombo
            If Not flagMostrarCombo Then
                .Width = System.Web.UI.WebControls.Unit.Parse("350px")
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
        Util.AdicionaJsFocus(Me.Page, CType(ddl3, System.web.UI.WebControls.WebControl))
    End Sub

#End Region

    Private Sub txtNomeBanco_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtNomeBanco.ValueChange

    End Sub
End Class