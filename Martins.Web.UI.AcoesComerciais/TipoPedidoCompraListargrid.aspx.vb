Public Class TipoPedidoCompraListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoPedidoCompra1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoPedidoCompra
        CType(Me.DatasetTipoPedidoCompra1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoPedidoCompra1
        '
        Me.DatasetTipoPedidoCompra1.DataSetName = "DatasetTipoPedidoCompra"
        Me.DatasetTipoPedidoCompra1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoPedidoCompra1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetTipoPedidoCompra1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoPedidoCompra
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
                DatasetTipoPedidoCompra1.EnforceConstraints = False
                DatasetTipoPedidoCompra1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 0 'Nunhum andamento
                        DatasetTipoPedidoCompra1 = Controller.ObterTiposPedidoCompra(String.Empty)
                    Case 1 'Consulta por CÓDIGO
                        DatasetTipoPedidoCompra1 = Controller.ObterTipoPedidoCompra(Decimal.Parse(Request.QueryString("TipPedCmp")))
                    Case 2 'Consulta por DESCRIÇÃO
                        DatasetTipoPedidoCompra1 = Controller.ObterTiposPedidoCompra(Request.QueryString("DesTipPedCmp"))
                End Select

                DatasetTipoPedidoCompra1.T0104499.DefaultView.Sort = "TipPedCmp"
                dtgListar.DataSource = DatasetTipoPedidoCompra1.T0104499.DefaultView
                dtgListar.DataBind()
                WSCAcoesComerciais.dsTipoPedidoCompra = DatasetTipoPedidoCompra1
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""TipoPedidoCompra.aspx?TipPedCmp=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & """;" & vbCrLf)
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
            '        DatasetTipoPedidoCompra1 = Controller.ObterTiposPedidoCompra(String.Empty)
            '    Case 1 'Consulta por CÓDIGO
            '        DatasetTipoPedidoCompra1 = Controller.ObterTipoPedidoCompra(Decimal.Parse(Request.QueryString("TipPedCmp")))
            '    Case 2 'Consulta por DESCRIÇÃO
            '        DatasetTipoPedidoCompra1 = Controller.ObterTiposPedidoCompra(Request.QueryString("DesTipPedCmp"))
            'End Select

            DatasetTipoPedidoCompra1 = WSCAcoesComerciais.dsTipoPedidoCompra
            dtgListar.DataSource = DatasetTipoPedidoCompra1.T0104499.DefaultView
            dtgListar.DataBind()
        Catch ex As Exception
        End Try
    End Sub

End Class