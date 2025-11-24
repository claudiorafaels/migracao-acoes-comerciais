Public Class ChequeListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetCHRecebidoFornecedor1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetCHRecebidoFornecedor
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
                DatasetCHRecebidoFornecedor1.EnforceConstraints = False
                DatasetCHRecebidoFornecedor1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 1 'Consulta por Período
                        DatasetCHRecebidoFornecedor1 = Controller.ObterCHsRecebidoFornecedor(0, 0, 0, Nothing, Date.Parse(Request.QueryString("DATRCBCHQInicial")), Date.Parse(Request.QueryString("DATRCBCHQFinal")), 2, 0)
                    Case 2 'Consulta por Data Previsão
                        DatasetCHRecebidoFornecedor1 = Controller.ObterCHsRecebidoFornecedor(0, 0, 0, Date.Parse(Request.QueryString("DATRCBCHQ")), Nothing, Nothing, 2, 0)
                    Case 3 'Consulta por Período + Fornecedor
                        DatasetCHRecebidoFornecedor1 = Controller.ObterCHsRecebidoFornecedor(0, 0, Decimal.Parse(Request.QueryString("CODFRN")), Nothing, Date.Parse(Request.QueryString("DATRCBCHQInicial")), Date.Parse(Request.QueryString("DATRCBCHQFinal")), 2, 0)
                    Case 4 'Consulta por Numero cheque
                        DatasetCHRecebidoFornecedor1 = Controller.ObterCHsRecebidoFornecedor(0, 0, 0, Nothing, Nothing, Nothing, 2, Decimal.Parse(Request.QueryString("NUMCHQ")))
                End Select

                DatasetCHRecebidoFornecedor1.T0118872.DefaultView.Sort = "DATRCBCHQ"
                dtgListar.DataSource = DatasetCHRecebidoFornecedor1.T0118872.DefaultView
                dtgListar.DataBind()
                WSCAcoesComerciais.dsChREcebidoFornecedor = DatasetCHRecebidoFornecedor1
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub

    Private Sub dtgListar_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgListar.PageIndexChanged
        Try
            Me.dtgListar.CurrentPageIndex = e.NewPageIndex
            DatasetCHRecebidoFornecedor1 = WSCAcoesComerciais.dsChREcebidoFornecedor
            dtgListar.DataSource = DatasetCHRecebidoFornecedor1.T0118872.DefaultView
            dtgListar.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""Cheque.aspx?CODAGE=" & dtgListar.Items(e.Item.ItemIndex).Cells(2).Text() & _
                                                                          "&CODBCO=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & _
                                                                          "&DATRCBCHQ=" & dtgListar.Items(e.Item.ItemIndex).Cells(7).Text() & _
                                                                          "&NUMCHQ=" & dtgListar.Items(e.Item.ItemIndex).Cells(3).Text() & _
                                                                          """;" & vbCrLf)
                Response.Write("</script>" & vbCrLf)
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

End Class