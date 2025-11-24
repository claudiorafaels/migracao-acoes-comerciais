Public Class LancamentoListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetContaCorrenteFornecedor1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContaCorrenteFornecedor
        CType(Me.DatasetContaCorrenteFornecedor1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetContaCorrenteFornecedor1
        '
        Me.DatasetContaCorrenteFornecedor1.DataSetName = "DatasetContaCorrenteFornecedor"
        Me.DatasetContaCorrenteFornecedor1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetContaCorrenteFornecedor1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetContaCorrenteFornecedor1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContaCorrenteFornecedor
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
                DatasetContaCorrenteFornecedor1.EnforceConstraints = False
                DatasetContaCorrenteFornecedor1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 1 'Consulta por Período
                        DatasetContaCorrenteFornecedor1 = Controller.ObterContasCorrenteFornecedor(String.Empty, String.Empty, String.Empty, String.Empty, 0, 0, String.Empty, 0, 0, Nothing, Date.Parse(Request.QueryString("DATREFLMTInicial") + " 00:00:00"), Date.Parse(Request.QueryString("DATREFLMTFinal") + " 23:59:59"), String.Empty, String.Empty, 0, 0)
                    Case 2 'Consulta por Data Previsão
                        DatasetContaCorrenteFornecedor1 = Controller.ObterContasCorrenteFornecedor(String.Empty, String.Empty, String.Empty, String.Empty, 0, 0, String.Empty, 0, 0, Nothing, CDate(Request.QueryString("DATREFLMT") + " 00:00:00"), CDate(Request.QueryString("DATREFLMT") + " 23:59:59"), String.Empty, String.Empty, 0, 0)
                    Case 3 'Consulta por Período + Fornecedor
                        DatasetContaCorrenteFornecedor1 = Controller.ObterContasCorrenteFornecedor(String.Empty, String.Empty, String.Empty, String.Empty, 0, Decimal.Parse(Request.QueryString("CODFRN")), String.Empty, 0, 0, Nothing, Date.Parse(Request.QueryString("DATREFLMTInicial") + " 00:00:00"), Date.Parse(Request.QueryString("DATREFLMTFinal") + " 23:59:59"), String.Empty, String.Empty, 0, 0)
                    Case 4 'Consulta por Numero Lancamento
                        DatasetContaCorrenteFornecedor1 = Controller.ObterContasCorrenteFornecedor(String.Empty, String.Empty, String.Empty, String.Empty, 0, 0, String.Empty, 0, 0, Nothing, Nothing, Nothing, String.Empty, String.Empty, Decimal.Parse(Request.QueryString("NUMSEQLMT")), 0)
                End Select

                DatasetContaCorrenteFornecedor1.T0123086.DefaultView.Sort = "DATREFLMT"
                dtgListar.DataSource = DatasetContaCorrenteFornecedor1.T0123086.DefaultView
                dtgListar.DataBind()
                WSCAcoesComerciais.dsContaCorrenteFornecedor = DatasetContaCorrenteFornecedor1
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
            '        DatasetContaCorrenteFornecedor1 = Controller.ObterContasCorrenteFornecedor(String.Empty, String.Empty, String.Empty, String.Empty, 0, 0, String.Empty, 0, 0, Nothing, Date.Parse(Request.QueryString("DATREFLMTInicial")), Date.Parse(Request.QueryString("DATREFLMTFinal")), String.Empty, String.Empty, 0, 0)
            '    Case 2 'Consulta por Data Previsão
            '        DatasetContaCorrenteFornecedor1 = Controller.ObterContasCorrenteFornecedor(String.Empty, String.Empty, String.Empty, String.Empty, 0, 0, String.Empty, 0, 0, CDate(Request.QueryString("DATREFLMT")), Nothing, Nothing, String.Empty, String.Empty, 0, 0)
            '    Case 3 'Consulta por Período + Fornecedor
            '        DatasetContaCorrenteFornecedor1 = Controller.ObterContasCorrenteFornecedor(String.Empty, String.Empty, String.Empty, String.Empty, 0, Decimal.Parse(Request.QueryString("CODFRN")), String.Empty, 0, 0, Nothing, Date.Parse(Request.QueryString("DATREFLMTInicial")), Date.Parse(Request.QueryString("DATREFLMTFinal")), String.Empty, String.Empty, 0, 0)
            '    Case 4 'Consulta por Numero Lancamento
            '        DatasetContaCorrenteFornecedor1 = Controller.ObterContasCorrenteFornecedor(String.Empty, String.Empty, String.Empty, String.Empty, 0, 0, String.Empty, 0, 0, Nothing, Nothing, Nothing, String.Empty, String.Empty, Decimal.Parse(Request.QueryString("NUMSEQLMT")), 0)
            'End Select

            DatasetContaCorrenteFornecedor1 = WSCAcoesComerciais.dsContaCorrenteFornecedor
            dtgListar.DataSource = DatasetContaCorrenteFornecedor1.T0123086.DefaultView
            dtgListar.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""Lancamento.aspx?CODFRN=" & dtgListar.Items(e.Item.ItemIndex).Cells(2).Text() & _
                                                                          "&CODGDC=" & dtgListar.Items(e.Item.ItemIndex).Cells(8).Text() & _
                                                                          "&DATREFLMT=" & dtgListar.Items(e.Item.ItemIndex).Cells(5).Text() & _
                                                                          "&NUMSEQLMT=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & _
                                                                          "&TIPDSNDSCBNF=" & dtgListar.Items(e.Item.ItemIndex).Cells(4).Text() & _
                                                                          """;" & vbCrLf)
                    Response.Write("</script>" & vbCrLf)
                End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub
End Class