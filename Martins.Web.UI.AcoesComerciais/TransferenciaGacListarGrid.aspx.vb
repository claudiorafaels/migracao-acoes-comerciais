Public Class TransferenciaGacListarGrid_aspx
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dsTransferenciaVerbasEntreEmpenhos = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTransferenciaVerbasEntreEmpenhos
        CType(Me.dsTransferenciaVerbasEntreEmpenhos, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'dsTransferenciaVerbasEntreEmpenhos
        '
        Me.dsTransferenciaVerbasEntreEmpenhos.DataSetName = "DatasetTransferenciaVerbasEntreEmpenhos"
        Me.dsTransferenciaVerbasEntreEmpenhos.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.dsTransferenciaVerbasEntreEmpenhos, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents dsTransferenciaVerbasEntreEmpenhos As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTransferenciaVerbasEntreEmpenhos

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
        Try
            If (Not IsPostBack) Then
                Me.CarregaGrid()
                WSCAcoesComerciais.dsTransferenciaVerbasEntreEmpenhos = dsTransferenciaVerbasEntreEmpenhos
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub

    Private Sub dtgListar_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgListar.PageIndexChanged
        Me.CarregaGrid(e.NewPageIndex)
    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""TransferenciaGac.aspx?CODTRANSFERENCIA=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & "&CODPMS=" & dtgListar.Items(e.Item.ItemIndex).Cells(2).Text() & "&DATNGCPMS=" & dtgListar.Items(e.Item.ItemIndex).Cells(3).Text() & """;" & vbCrLf)
                Response.Write("</script>" & vbCrLf)
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub CarregaGrid(Optional ByVal PageIndex As Integer = 0)
        dtgListar.CurrentPageIndex = PageIndex
        dsTransferenciaVerbasEntreEmpenhos.EnforceConstraints = False
        dsTransferenciaVerbasEntreEmpenhos.Clear()

        Select Case Convert.ToInt32(Request.QueryString("criterio"))
            Case 1 '1 Período
                dsTransferenciaVerbasEntreEmpenhos = Controller.ObterTransferenciasVerbasEntreEmpenhos(0, 0, "", String.Empty, Nothing, Date.Parse(Request.QueryString("DataInicial")), Date.Parse(Request.QueryString("DataFinal")), 0, 0, 0, 0)
            Case 2 '2 Data
                dsTransferenciaVerbasEntreEmpenhos = Controller.ObterTransferenciasVerbasEntreEmpenhos(0, 0, String.Empty, String.Empty, Date.Parse(Request.QueryString("Data")), Nothing, Nothing, 0, 0, 0, 0)
            Case 3 '3 Período/Fornecedor conta de origem
                dsTransferenciaVerbasEntreEmpenhos = Controller.ObterTransferenciasVerbasEntreEmpenhos(0, Decimal.Parse(Request.QueryString("codFornecedor")), String.Empty, String.Empty, Nothing, Date.Parse(Request.QueryString("DataInicial")), Date.Parse(Request.QueryString("DataFinal")), 0, 0, 0, 0)
            Case 4 '4 Período/Fornecedor conta de destino
                dsTransferenciaVerbasEntreEmpenhos = Controller.ObterTransferenciasVerbasEntreEmpenhos(Decimal.Parse(Request.QueryString("codFornecedor")), 0, String.Empty, String.Empty, Nothing, Date.Parse(Request.QueryString("DataInicial")), Date.Parse(Request.QueryString("DataFinal")), 0, 0, 0, 0)
            Case 5 '5 Empenho/Fornecedor conta de origem
                dsTransferenciaVerbasEntreEmpenhos = Controller.ObterTransferenciasVerbasEntreEmpenhos(0, Decimal.Parse(Request.QueryString("codFornecedor")), String.Empty, String.Empty, Nothing, Nothing, Nothing, 0, 0, 0, Decimal.Parse(Request.QueryString("codEmpenho")))
            Case 6 '6 Empenho/Fornecedor conta de destino
                dsTransferenciaVerbasEntreEmpenhos = Controller.ObterTransferenciasVerbasEntreEmpenhos(0, Decimal.Parse(Request.QueryString("codFornecedor")), String.Empty, String.Empty, Nothing, Nothing, Nothing, 0, 0, Decimal.Parse(Request.QueryString("codEmpenho")), 0)
        End Select
        dtgListar.DataBind()
    End Sub

End Class
