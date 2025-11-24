Public Class RelacaoEmpenhoTipoPedidoCompra
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
    Protected WithEvents DataSetTipoPedidoCompraXEmpenho1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoPedidoCompraXEmpenho
    Protected WithEvents cmbTipoPedidoCompra As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ucEmpenho As wucEmpenho
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            End If

            GerarJavaScript()

            If (Not IsPostBack) Then
                'Carrega combo tipo pedido compra
                Util.carregarCmbTipoPedidoCompra(Controller.ObterTiposPedidoCompra(String.Empty), cmbTipoPedidoCompra, New ListItem("Selecione->", "0"))
                ''Obtem CADASTRO TIPO PEDIDO COMPRA
                'If Not (Request.QueryString("TIPPEDCMP") Is Nothing) Then
                '    ObterRelacaoEmpenhoTipoPedidoCompra(Decimal.Parse(Request.QueryString("TIPPEDCMP")))
                'End If

                If Not (Request.QueryString("TIPDSNDSCBNF") Is Nothing _
                   And Request.QueryString("TIPPEDCMP") Is Nothing) Then
                    ucEmpenho.SelecionaItemCmbNomeEmpenho()
                    Dim TIPDSNDSCBNF As Decimal = CType(Request.QueryString("CodEmpenho"), Decimal)
                    Dim TIPPEDCMP As Decimal = CType(Request.QueryString("TipPedCmp"), Decimal)
                    ObterTiposPedidoCompraXEmpenho(TIPDSNDSCBNF, TIPPEDCMP)
                End If
                ucEmpenho.MostrarReceitaCMV = wucEmpenho.enumMostrarReceitaCMV.nao
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub GerarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        'btnCancelar.Attributes.Add("OnClick", "javascript:return confirm('Deseja sair sem salvar?')")
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            AtualizarTipoPedidoCompraXEmpenho()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = String.Empty

        Try
            Validar = True

            'Código 
            'If Val(txtTIPPEDCMP.Text) = 0 Then
            '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '    mensagemErro &= "código inválido"
            'End If
            ''descrição
            'If txtDESTIPPEDCMP.Text = String.Empty Then
            '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '    mensagemErro &= "descrição inválida"
            'End If
            If cmbTipoPedidoCompra.SelectedValue = "0" Then
                Util.AdicionaJsAlert(Me.Page, "Selecione o tipo de pedido compra", True)
                Return False
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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("RelacaoEmpenhoTipoPedidoCompraListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
    End Sub

    Public Sub ObterTiposPedidoCompraXEmpenho(ByVal TIPDSNDSCBNF As Decimal, ByVal TIPPEDCMP As Decimal)
        Try
            DataSetTipoPedidoCompraXEmpenho1 = Controller.ObterTiposPedidoCompraXEmpenho(TIPDSNDSCBNF, TIPPEDCMP)

            With DataSetTipoPedidoCompraXEmpenho1.T0118104(0)

                'TIPO DESTINO / DESCONTO BONIFICADO.
                If Not .IsNull("TIPDSNDSCBNF") Then
                    ucEmpenho.SelecionarEmpenho(.TIPDSNDSCBNF)
                End If

                'TIPO PEDIDO COMPRAS 
                If Not .IsNull("TipPedCmp") Then
                    If cmbTipoPedidoCompra.Items.FindByValue(.TIPPEDCMP.ToString) Is Nothing Then
                        Util.AdicionaJsAlert(Me.Page, "Não foi possivel selecionar o tipo de pedido " & .TIPPEDCMP.ToString & " , mantenha contato com o suporte técnico.", True)
                        cmbTipoPedidoCompra.SelectedValue = "0"
                    Else
                        cmbTipoPedidoCompra.SelectedValue = .TIPPEDCMP.ToString
                    End If
                End If
            End With

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Public Sub AtualizarTipoPedidoCompraXEmpenho()
        Dim linha As wsAcoesComerciais.DatasetTipoPedidoCompraXEmpenho.T0118104Row
        Dim tipoEdicao As Short

        Try
            If Validar() = False Then
                Exit Sub
            End If
            If ucEmpenho.CodEmpenho > 0 And _
            IsNumeric(cmbTipoPedidoCompra.SelectedValue) Then
                DataSetTipoPedidoCompraXEmpenho1 = Controller.ObterTipoPedidoCompraXEmpenho(ucEmpenho.CodEmpenho, CDec(cmbTipoPedidoCompra.SelectedValue))
            End If

            If DataSetTipoPedidoCompraXEmpenho1.T0118104.Rows.Count > 0 Then
                'Update
                linha = DataSetTipoPedidoCompraXEmpenho1.T0118104(0)
                tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO
                linha.BeginEdit()
            Else
                'Insert
                DataSetTipoPedidoCompraXEmpenho1.Clear()
                linha = DataSetTipoPedidoCompraXEmpenho1.T0118104.NewT0118104Row
                tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO
            End If
            'Transfere os dados do formulário para o DataSet
            With linha
                'TIPO DESTINO / DESCONTO BONIFICADO.
                .TIPDSNDSCBNF = ucEmpenho.CodEmpenho
                'TIPO PEDIDO COMPRAS 
                .TIPPEDCMP = Decimal.Parse(cmbTipoPedidoCompra.SelectedValue)
            End With
            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                DataSetTipoPedidoCompraXEmpenho1.EnforceConstraints = False
                DataSetTipoPedidoCompraXEmpenho1.T0118104.AddT0118104Row(linha)
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                linha.EndEdit()
            End If

            Controller.AtualizarTipoPedidoCompraXEmpenho(DataSetTipoPedidoCompraXEmpenho1)

            Me.Response.Redirect("RelacaoEmpenhoTipoPedidoCompraListar.aspx")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

End Class