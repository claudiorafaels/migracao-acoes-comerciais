Imports Martins.Security.Helper
Public Class AlteraValorEfetivo
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetClausulaContrato = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetClausulaContrato
        Me.DatasetContrato = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContrato
        Me.DatasetTipoAbrangenciaMix = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoAbrangenciaMix
        Me.DatasetEntidade = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetEntidade
        Me.DatasetContratoXPeriodo = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContratoXPeriodo
        Me.DatasetTipoPeriodo = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoPeriodo
        CType(Me.DatasetClausulaContrato, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetContrato, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetTipoAbrangenciaMix, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetEntidade, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetContratoXPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetTipoPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetClausulaContrato
        '
        Me.DatasetClausulaContrato.DataSetName = "DatasetClausulaContrato"
        Me.DatasetClausulaContrato.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DatasetContrato
        '
        Me.DatasetContrato.DataSetName = "DatasetContrato"
        Me.DatasetContrato.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DatasetTipoAbrangenciaMix
        '
        Me.DatasetTipoAbrangenciaMix.DataSetName = "DatasetTipoAbrangenciaMix"
        Me.DatasetTipoAbrangenciaMix.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DatasetEntidade
        '
        Me.DatasetEntidade.DataSetName = "DatasetEntidade"
        Me.DatasetEntidade.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DatasetContratoXPeriodo
        '
        Me.DatasetContratoXPeriodo.DataSetName = "DatasetContratoXPeriodo"
        Me.DatasetContratoXPeriodo.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DatasetTipoPeriodo
        '
        Me.DatasetTipoPeriodo.DataSetName = "DatasetTipoPeriodo"
        Me.DatasetTipoPeriodo.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetClausulaContrato, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetContrato, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetTipoAbrangenciaMix, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetEntidade, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetContratoXPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetTipoPeriodo, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents WebCurrencyEdit1 As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents WebCurrencyEdit2 As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents WebCurrencyEdit3 As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents lblValorEfetivo As System.Web.UI.WebControls.Label
    Protected WithEvents DatasetClausulaContrato As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetClausulaContrato
    Protected WithEvents DatasetContrato As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContrato
    Protected WithEvents DatasetTipoAbrangenciaMix As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoAbrangenciaMix
    Protected WithEvents DatasetEntidade As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetEntidade
    Protected WithEvents DatasetContratoXPeriodo As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContratoXPeriodo
    Protected WithEvents DatasetTipoPeriodo As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoPeriodo
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DdlContrato As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlClausula As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlTipoPeriodo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents pnlAbrangencia As System.Web.UI.WebControls.Panel
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents gridValor As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents btnLimpar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtNumPeriodo As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtAbrangencia As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents txtEntidade As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtDataFinal As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtDataInicio As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents txtValorEfetivo As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
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

#Region " Propriedades"

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.txtValorEfetivo.Attributes.Add("OnKeyDown", "FormataValorPrecisao(this,15,2,event)")
            btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
            btnPesquisar.Attributes.Add("OnClick", "javascript:mostraAndamento()")

            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            End If
            If Not Me.Page.IsPostBack Then
                MontaDdlTipoPeriodo()
                With ucFornecedor
                    ucFornecedor.widthCodigo = System.Web.UI.WebControls.Unit.Parse("60px")
                    ucFornecedor.widthNome = System.Web.UI.WebControls.Unit.Parse("280px")
                End With
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub
    Private Sub DdlContrato_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DdlContrato.SelectedIndexChanged
        Me.MontaDdlClausulaContrato()
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        If Me.DdlContrato.SelectedIndex > 0 Then
            Me.MontaGrid()
        Else
            Util.AdicionaJsAlert(Me, "Os campos forncedor e contrato são obrigatórios!")
        End If
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            If flagProcessando Then
                Exit Sub
            End If
            flagProcessando = True

            AtualizarValorEfetivo()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        Finally
            flagProcessando = False
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("AlteraValorEfetivoListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ucFornecedor_FornecedorAlterado(ByVal e As System.Web.UI.WebControls.ListItem) Handles ucFornecedor.FornecedorAlterado
        Try
            If Not ucFornecedor.CodFornecedor = Decimal.Zero Then
                Me.MontaDdlContrato()
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub gridValor_ItemCommand(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.UltraWebGridCommandEventArgs) Handles gridValor.ItemCommand
        Try
            Dim arrDados As New ArrayList
            For i As Integer = 1 To 6
                arrDados.Add(gridValor.DisplayLayout.ActiveRow().Cells(i).Value)
            Next
            Me.MontaDadosTela(arrDados)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnLimpar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpar.Click
        Try
            Server.Transfer("AlteraValorEfetivo.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#Region " Metodos "

    Private Sub MontaDdlContrato()
        Try
            Me.DatasetContrato.Clear()
            Me.DdlContrato.Items.Clear()
            DatasetContrato.EnforceConstraints = False
            Me.DatasetContrato.Merge(Controller.ObterContratos(0, 0, String.Empty, ucFornecedor.CodFornecedor, 0), False, MissingSchemaAction.Ignore)
            If Me.DatasetContrato.T0124945.Rows.Count > 0 Then
                Me.DdlContrato.DataBind()
            End If
            Me.DdlContrato.Items.Insert(0, New ListItem("Selecione", "0"))
            Me.DdlContrato.SelectedIndex = 0
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub MontaDdlClausulaContrato()
        Try
            Me.DatasetClausulaContrato.Clear()
            Me.ddlClausula.Items.Clear()
            Me.DatasetClausulaContrato.EnforceConstraints = False
            Dim contrato As Decimal = CType(IIf(CType(Me.DdlContrato.SelectedValue, Decimal) > 0, CType(Me.DdlContrato.SelectedValue, Decimal), Decimal.Zero), Decimal)
            Me.DatasetClausulaContrato.Merge(Controller.ObterContratoXClausulaContrato(Nothing, Nothing, Nothing, Decimal.Zero, contrato), False, MissingSchemaAction.Ignore)
            Util.carregarClausulaContrato(Me.DatasetClausulaContrato, Me.ddlClausula, New ListItem("Selecione a cláusula", "0"))
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub MontaDdlTipoPeriodo()
        Try
            Me.DatasetTipoPeriodo.Clear()
            Me.ddlTipoPeriodo.Items.Clear()
            Me.DatasetTipoPeriodo.Merge(Controller.ObterTiposPeriodo(String.Empty, Decimal.Zero), False, MissingSchemaAction.Ignore)
            Util.carregarCmbTipoPeriodo(Me.DatasetTipoPeriodo, Me.ddlTipoPeriodo, New ListItem("Selecione Tipo Período", "0"))
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub MontaGrid()
        Try
            Dim contrato As Integer = CType(IIf(CType(Me.DdlContrato.SelectedValue, Double) > 0, Me.DdlContrato.SelectedValue, 0), Integer)
            Dim clausula As Integer = CType(IIf(CType(Me.ddlClausula.SelectedValue, Double) > 0, Me.ddlClausula.SelectedValue, 0), Integer)
            Dim numPeriodo As Integer = CType(IIf(Me.txtNumPeriodo.Text <> String.Empty, Me.txtNumPeriodo.Text, 0), Integer)
            Dim tipoPeriodo As Integer = CType(IIf(CType(Me.ddlTipoPeriodo.SelectedValue, Double) > 0, Me.ddlTipoPeriodo.SelectedValue, 0), Integer)
            Me.DatasetContratoXPeriodo.EnforceConstraints = False
            Me.DatasetContratoXPeriodo.Merge(Controller.ObterContratosXPeriodos(clausula, contrato, numPeriodo, tipoPeriodo), False, MissingSchemaAction.Ignore)
            Me.gridValor.DataBind()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub MontaDadosTela(ByVal arrDados As ArrayList)
        Try
            Me.DatasetEntidade.Clear()
            Session("DataSetEntidade") = Controller.ObterEntidades(Decimal.Zero, Decimal.Zero, _
                                                                   Decimal.Zero, Nothing, Nothing, _
                                                                   Nothing, Nothing, Nothing, Nothing, _
                                                                   CType(arrDados(1), Decimal), _
                                                                   CType(arrDados(0), Decimal), _
                                                                   Decimal.Zero, CType(arrDados(3), Decimal), _
                                                                   Decimal.Zero, CType(arrDados(2), Decimal))

            Me.DatasetEntidade.Merge(CType(Session("DataSetEntidade"), DataSet), False, MissingSchemaAction.Ignore)
            If Me.DatasetEntidade.T0125046.Rows.Count > 0 Then
                Me.btnSalvar.Visible = True
                Me.btnLimpar.Visible = True
                Me.pnlAbrangencia.Visible = True
                Me.txtValorEfetivo.Visible = True
                Me.txtDataFinal.Visible = True
                Me.txtDataInicio.Visible = True
                Me.Label1.Visible = True
                Me.Label2.Visible = True
                Me.DdlContrato.SelectedValue = arrDados(0).ToString
                Me.ddlClausula.SelectedValue = arrDados(1).ToString
                Me.ddlTipoPeriodo.SelectedValue = arrDados(2).ToString
                Me.txtNumPeriodo.Text = arrDados(3).ToString
                Me.txtDataInicio.Text = CType(arrDados(4), Date).ToString("dd/MM/yyyy")
                Me.txtDataFinal.Text = CType(arrDados(5), Date).ToString("dd/MM/yyyy")
                Me.txtEntidade.Text = Me.DatasetEntidade.T0125046(0).CODEDEABGMIX.ToString

                Me.txtAbrangencia.Text = Me.RetornaAbrangencia(Me.DatasetEntidade.T0125046(0).TIPEDEABGMIX)
                If Me.DatasetEntidade.T0125046(0).IsVLRDSCRCBEFTFXANull Then
                    Me.txtValorEfetivo.ValueDecimal = Decimal.Zero
                Else
                    Me.txtValorEfetivo.ValueDecimal = Me.DatasetEntidade.T0125046(0).VLRDSCRCBEFTFXA
                End If
            Else
                Util.AdicionaJsAlert(Me, "Não foi encontrado valor efetivo para este registro!")
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function RetornaAbrangencia(ByVal abrangencia As Decimal) As String
        Select Case abrangencia
            Case 1
                Return "0001 - TODOS"
            Case 2
                Return "0002 - CATEGORIA"
            Case 3
                Return "0003 - ITENS"
            Case 4
                Return "0004 - ITENS NOVOS"
            Case Else
                Return String.Empty
        End Select
    End Function

    Private Sub AtualizarValorEfetivo()
        'Tentar obter o usuário logado ao sistema
        Dim NOMACSUSRSIS As String
        Try
            NOMACSUSRSIS = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0).NOMACSUSRSIS.Trim
        Catch ex As Exception
            Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471), consequentemente o sistema não vai permitir salvar esse registro.")
            Exit Sub
        End Try

        Try
            Dim pvOperacao As Integer
            Dim pvNumCttFrn As Decimal
            Dim pvNumCslCttFrn As Decimal
            Dim pvTipPodCttFrn As Decimal
            Dim pvNumRefPod As Decimal
            Dim pvTipEdeAbgMix As Decimal
            Dim pvCodEdeAbgMixEnt As Decimal
            Dim pvDatRefApu As Date
            Dim pvVlrDscRcbEftFxa As Decimal
            Dim pvNomAcsUsrSis As String

            pvOperacao = 2
            pvNumCttFrn = Convert.ToDecimal(DdlContrato.SelectedValue)
            pvNumCslCttFrn = Convert.ToDecimal(ddlClausula.SelectedValue)
            pvTipPodCttFrn = Convert.ToDecimal(ddlTipoPeriodo.SelectedValue)
            pvNumRefPod = txtNumPeriodo.ValueDecimal
            pvTipEdeAbgMix = Convert.ToDecimal(txtAbrangencia.Text.Substring(0, 4))
            If pvTipEdeAbgMix = 1 Then
                pvCodEdeAbgMixEnt = ucFornecedor.CodFornecedor
            Else
                pvCodEdeAbgMixEnt = txtEntidade.ValueDecimal
            End If
            pvDatRefApu = txtDataInicio.Date
            pvVlrDscRcbEftFxa = txtValorEfetivo.ValueDecimal
            pvNomAcsUsrSis = NOMACSUSRSIS

            Controller.SelecionarEAlterarValorEfetivoDesconto(pvOperacao, _
                                                              pvNumCttFrn, _
                                                              pvNumCslCttFrn, _
                                                              pvTipPodCttFrn, _
                                                              pvNumRefPod, _
                                                              pvTipEdeAbgMix, _
                                                              pvCodEdeAbgMixEnt, _
                                                              pvDatRefApu, _
                                                              pvVlrDscRcbEftFxa, _
                                                              pvNomAcsUsrSis)

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

        'Try
        '    Dim linha As wsAcoesComerciais.DatasetEntidade.T0125046Row
        '    linha = Me.DatasetEntidade.T0125046(0)
        '    If linha.IsVLRDSCRCBEFTFXANull Then linha.VLRDSCRCBEFTFXA = 0
        '    If linha.VLRDSCRCBEFTFXA = CType(Me.txtValorEfetivo.Text.Trim, Decimal) Then
        '        Util.AdicionaJsAlert(Me, "Modifique o valor do desconto antes de atualizar!")
        '    Else
        '        If CType(Me.txtValorEfetivo.Text, Decimal) = Decimal.Zero Then
        '            linha.SetVLRDSCRCBEFTFXANull()
        '        Else
        '            linha.VLRDSCRCBEFTFXA = CType(Me.txtValorEfetivo.Text.Trim, Decimal)
        '        End If
        '        linha.DATHRAALTRGT = Now
        '        linha.NOMACSUSRSIS = NOMACSUSRSIS
        '        Controller.AtualizarEntidade(Me.DatasetEntidade)
        '        Util.AdicionaJsAlert(Me, "Valor efetivo atualizado com sucesso!")
        '    End If

        'Catch ex As Exception
        '    Controller.TrataErro(Me.Page, ex)
        'End Try
    End Sub
#End Region

End Class