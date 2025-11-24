Public Class FormaPagamentoListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetFormaPagamento1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetFormaPagamento
        CType(Me.DatasetFormaPagamento1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetFormaPagamento1
        '
        Me.DatasetFormaPagamento1.DataSetName = "DatasetFormaPagamento"
        Me.DatasetFormaPagamento1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetFormaPagamento1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents DatasetFormaPagamento1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetFormaPagamento
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
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
                DatasetFormaPagamento1.EnforceConstraints = False
                DatasetFormaPagamento1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 0 'Nenhum
                        DatasetFormaPagamento1 = Controller.ObterFormasPagamento(String.Empty, -1)
                        DatasetFormaPagamento1.T0113552.DefaultView.Sort = ("TipFrmDscBnf")
                    Case 1 'Consulta por CÓDIGO
                        DatasetFormaPagamento1 = Controller.ObterFormaPagamento(Decimal.Parse(Request.QueryString("TipFrmDscBnf")))
                        DatasetFormaPagamento1.T0113552.DefaultView.Sort = ("TipFrmDscBnf")
                    Case 2 'Consulta por DESCRIÇÃO
                        DatasetFormaPagamento1 = Controller.ObterFormasPagamento(Request.QueryString("DesFrmDscBnf"), -1)
                        DatasetFormaPagamento1.T0113552.DefaultView.Sort = ("TipFrmDscBnf")
                End Select

                dtgListar.DataSource = DatasetFormaPagamento1.T0113552.DefaultView
                dtgListar.DataBind()
                WSCAcoesComerciais.dsformaPagamento = DatasetFormaPagamento1
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""FormaPagamento.aspx?TipFrmDscBnf=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & """;" & vbCrLf)
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
            '    Case 1 'Consulta por CÓDIGO
            '        DatasetFormaPagamento1 = Controller.ObterFormaPagamento(Decimal.Parse(Request.QueryString("TipFrmDscBnf")))
            '    Case 2 'Consulta por DESCRIÇÃO
            '        DatasetFormaPagamento1 = Controller.ObterFormasPagamento(Request.QueryString("DesFrmDscBnf"))
            'End Select

            DatasetFormaPagamento1 = WSCAcoesComerciais.dsformaPagamento
            dtgListar.DataSource = DatasetFormaPagamento1.T0113552.DefaultView
            dtgListar.DataBind()
        Catch ex As Exception
        End Try
    End Sub
End Class