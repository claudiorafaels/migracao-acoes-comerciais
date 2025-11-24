Public Class RelacaoEmpenhoTipoPedidoCompraListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataSetTipoPedidoCompraXEmpenho1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoPedidoCompraXEmpenho
        CType(Me.DataSetTipoPedidoCompraXEmpenho1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DataSetTipoPedidoCompraXEmpenho1
        '
        Me.DataSetTipoPedidoCompraXEmpenho1.DataSetName = "DatasetTipoPedidoCompraXEmpenho"
        Me.DataSetTipoPedidoCompraXEmpenho1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DataSetTipoPedidoCompraXEmpenho1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataSetTipoPedidoCompraXEmpenho1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoPedidoCompraXEmpenho
    '  Protected WithEvents DatasetTipoPedidoCompra1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoPedidoCompraXEmpenho
    'Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm



    ''NOTE: The following placeholder declaration is required by the Web Form Designer.
    ''Do not delete or move it.
    'Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Not IsPostBack) Then
                DataSetTipoPedidoCompraXEmpenho1.EnforceConstraints = False
                DataSetTipoPedidoCompraXEmpenho1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 0 'Nunhum andamento
                        DataSetTipoPedidoCompraXEmpenho1 = Controller.ObterTiposPedidoCompraXEmpenho(0, 0)
                    Case 1 'Consulta por Empenho
                        DataSetTipoPedidoCompraXEmpenho1 = Controller.ObterTiposPedidoCompraXEmpenho(Decimal.Parse(Request.QueryString("TIPDSNDSCBNF")), 0)
                        'DataSetTipoPedidoCompraXEmpenho1.T0104499.DefaultView.Sort = ("TIPDSNDSCBNF")
                    Case 2 'Consulta por TIPO PEDIDO COMPRA
                        DataSetTipoPedidoCompraXEmpenho1 = Controller.ObterTiposPedidoCompraXEmpenho(0, Decimal.Parse(Request.QueryString("TIPPEDCMP")))
                        'DataSetTipoPedidoCompraXEmpenho1.T0104499.DefaultView.Sort = ("TIPPEDCMP")
                End Select

                DataSetTipoPedidoCompraXEmpenho1.T0104499.DefaultView.Sort = "TipPedCmp"
                dtgListar.DataSource = DataSetTipoPedidoCompraXEmpenho1.T0104499.DefaultView
                dtgListar.DataBind()
                WSCAcoesComerciais.dsTipoPedidoCompraxEmpenho = DataSetTipoPedidoCompraXEmpenho1
                'If DataSetTipoPedidoCompraXEmpenho1.T0104499(0). .IsNull("") Then

            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""RelacaoEmpenhoTipoPedidoCompra.aspx?TipPedCmp=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & "&CodEmpenho=" & dtgListar.Items(e.Item.ItemIndex).Cells(3).Text() & """;" & vbCrLf)
                Response.Write("</script>" & vbCrLf)
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub dtgListar_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgListar.PageIndexChanged
        Try
            Me.dtgListar.CurrentPageIndex = e.NewPageIndex

            'Select Case CInt(Request.QueryString("criterio"))
            '    Case 0 'Nunhum andamento
            '        DataSetTipoPedidoCompraXEmpenho1 = Controller.ObterTiposPedidoCompraXEmpenho(0, 0)
            '    Case 1 'Consulta por Empenho
            '        DataSetTipoPedidoCompraXEmpenho1 = Controller.ObterTiposPedidoCompraXEmpenho(Decimal.Parse(Request.QueryString("TIPDSNDSCBNF")), 0)
            '    Case 2 'Consulta por TIPO PEDIDO COMPRA
            '        DataSetTipoPedidoCompraXEmpenho1 = Controller.ObterTiposPedidoCompraXEmpenho(0, Decimal.Parse(Request.QueryString("TIPPEDCMP")))
            'End Select

            DataSetTipoPedidoCompraXEmpenho1 = WSCAcoesComerciais.dsTipoPedidoCompraxEmpenho
            dtgListar.DataSource = DataSetTipoPedidoCompraXEmpenho1.T0104499.DefaultView
            dtgListar.DataBind()
        Catch ex As Exception
        End Try
    End Sub

End Class