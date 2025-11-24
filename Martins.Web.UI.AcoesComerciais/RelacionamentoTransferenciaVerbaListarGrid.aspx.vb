Public Class RelacionamentoTransferenciaVerbaListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid

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
        'Put user code to initialize the page here
        If Not Me.Page.IsPostBack() Then
            Me.CarregaDS()
        End If
    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName.Equals("Link") Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""RelacionamentoTransferenciaVerba.aspx?criterio= " & Request.QueryString.Item("criterio") & "&dsIndex=" & e.Item.DataSetIndex & """;" & vbCrLf)
                Response.Write("</script>" & vbCrLf)
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub dtgListar_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgListar.PageIndexChanged
        Try
            If Request.QueryString.Item("criterio").Equals("2") Then
                Me.CarregaGrid(WSCAcoesComerciais.dsTipoTransferenciaXFornecedor, e.NewPageIndex)
            ElseIf Request.QueryString.Item("criterio").Equals("1") Then
                Me.CarregaGrid(WSCAcoesComerciais.dsTipoTransferenciaXDivisaoCompras, e.NewPageIndex)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CarregaDS()
        If Request.QueryString.Item("criterio").Equals("2") Then
            WSCAcoesComerciais.dsTipoTransferenciaXFornecedor = Controller.ObterTiposTransferenciasXFornecedor(Convert.ToDecimal(Request.QueryString.Item("cod")), 0)
            Me.CarregaGrid(WSCAcoesComerciais.dsTipoTransferenciaXFornecedor)
        ElseIf Request.QueryString.Item("criterio").Equals("1") Then
            WSCAcoesComerciais.dsTipoTransferenciaXDivisaoCompras = Controller.ObterTiposTransferenciasXDivisaoCompras(Convert.ToDecimal(Request.QueryString.Item("cod")), 0)
            Me.CarregaGrid(WSCAcoesComerciais.dsTipoTransferenciaXDivisaoCompras)
        End If
    End Sub

    Private Sub CarregaGrid(ByVal ds As Object, Optional ByVal PageIndex As Integer = 0)
        If Request.QueryString.Item("criterio").Equals("2") Then
            dtgListar.DataMember = CType(ds, wsAcoesComerciais.DatasetTipoTransferenciaXFornecedor).T0135050.TableName
            'CType(dtgListar.Columns.Item(2), System.Web.UI.WebControls.BoundColumn).HeaderText = "Fornecedor"
            'CType(dtgListar.Columns.Item(2), System.Web.UI.WebControls.BoundColumn).DataField = "CODFRN"
        ElseIf Request.QueryString.Item("criterio").Equals("1") Then
            dtgListar.DataMember = CType(ds, wsAcoesComerciais.DatasetTipoTransferenciaXDivisaoCompras).T0135041.TableName
            'CType(dtgListar.Columns.Item(2), System.Web.UI.WebControls.BoundColumn).HeaderText = "Divisão Compra"
            'CType(dtgListar.Columns.Item(2), System.Web.UI.WebControls.BoundColumn).DataField = "CODDIVCMP"
        End If

        dtgListar.DataSource = ds

        dtgListar.CurrentPageIndex = PageIndex
        dtgListar.DataBind()
    End Sub

End Class