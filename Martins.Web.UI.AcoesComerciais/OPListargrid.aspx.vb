Public Class OPListarGrid
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
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetOPRecebidaFornecedor1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetOPRecebidaFornecedor
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
                DatasetOPRecebidaFornecedor1.EnforceConstraints = False
                DatasetOPRecebidaFornecedor1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 1 'Consulta por Período
                        DatasetOPRecebidaFornecedor1 = Controller.ObterOPsRecebidaFornecedor(0, 0, 0, Nothing, Date.Parse(Request.QueryString("DATRCBORDPGTInicial")), Date.Parse(Request.QueryString("DATRCBORDPGTFinal")), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, 2, String.Empty, 0, 0, 0, 0)
                    Case 2 'Consulta por Data Previsão
                        DatasetOPRecebidaFornecedor1 = Controller.ObterOPsRecebidaFornecedor(0, 0, 0, Date.Parse(Request.QueryString("DATRCBORDPGT")), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, 2, String.Empty, 0, 0, 0, 0)
                    Case 3 'Consulta por Período + Fornecedor
                        DatasetOPRecebidaFornecedor1 = Controller.ObterOPsRecebidaFornecedor(0, 0, Decimal.Parse(Request.QueryString("CODFRN")), Nothing, Date.Parse(Request.QueryString("DATRCBORDPGTInicial")), Date.Parse(Request.QueryString("DATRCBORDPGTFinal")), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, 2, String.Empty, 0, 0, 0, 0)
                    Case 4 'Consulta por Numero OP'
                        DatasetOPRecebidaFornecedor1 = Controller.ObterOPsRecebidaFornecedor(0, 0, 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, 2, String.Empty, Decimal.Parse(Request.QueryString("NUMORDPGTFRN")), 0, 0, 0)
                End Select

                DatasetOPRecebidaFornecedor1.T0118880.DefaultView.Sort = "DATRCBORDPGT"
                dtgListar.DataSource = DatasetOPRecebidaFornecedor1.T0118880.DefaultView
                dtgListar.DataBind()
                WSCAcoesComerciais.dsOPRecebidaFornecedor = DatasetOPRecebidaFornecedor1
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub

    Private Sub dtgListar_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgListar.PageIndexChanged
        Try
            Me.dtgListar.CurrentPageIndex = e.NewPageIndex

            'Select Case CInt(Request.QueryString("criterio"))
            '    Case 1 'Consulta por Período
            '        DatasetOPRecebidaFornecedor1 = Controller.ObterOPsRecebidaFornecedor(0, 0, 0, Nothing, Date.Parse(Request.QueryString("DATRCBORDPGTInicial")), Date.Parse(Request.QueryString("DATRCBORDPGTFinal")), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, 2, String.Empty, 0, 0, 0, 0)
            '    Case 2 'Consulta por Data Previsão
            '        DatasetOPRecebidaFornecedor1 = Controller.ObterOPsRecebidaFornecedor(0, 0, 0, Date.Parse(Request.QueryString("DATRCBORDPGT")), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, 2, String.Empty, 0, 0, 0, 0)
            '    Case 3 'Consulta por Período + Fornecedor
            '        DatasetOPRecebidaFornecedor1 = Controller.ObterOPsRecebidaFornecedor(0, 0, Decimal.Parse(Request.QueryString("CODFRN")), Nothing, Date.Parse(Request.QueryString("DATRCBORDPGTInicial")), Date.Parse(Request.QueryString("DATRCBORDPGTFinal")), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, 2, String.Empty, 0, 0, 0, 0)
            '    Case 4 'Consulta por Numero OP
            '        DatasetOPRecebidaFornecedor1 = Controller.ObterOPsRecebidaFornecedor(0, 0, 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, 2, String.Empty, Decimal.Parse(Request.QueryString("NUMORDPGTFRN")), 0, 0, 0)
            'End Select

            DatasetOPRecebidaFornecedor1 = WSCAcoesComerciais.dsOPRecebidaFornecedor
            dtgListar.DataSource = DatasetOPRecebidaFornecedor1.T0118880.DefaultView
            dtgListar.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""OP.aspx?CODAGE=" & dtgListar.Items(e.Item.ItemIndex).Cells(2).Text() & _
                                                                          "&CODBCO=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & _
                                                                          "&DATRCBORDPGT=" & dtgListar.Items(e.Item.ItemIndex).Cells(7).Text() & _
                                                                          "&NUMORDPGTFRN=" & dtgListar.Items(e.Item.ItemIndex).Cells(3).Text() & _
                                                                          """;" & vbCrLf)
                Response.Write("</script>" & vbCrLf)
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

End Class