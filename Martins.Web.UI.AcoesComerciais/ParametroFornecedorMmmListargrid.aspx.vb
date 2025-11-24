Public Class ParametroFornecedorMmmListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetParametroFornecedorMmm1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetParametroFornecedorMmm
        CType(Me.DatasetParametroFornecedorMmm1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetParametroFornecedorMmm1
        '
        Me.DatasetParametroFornecedorMmm1.DataSetName = "DatasetParametroFornecedorMmm"
        Me.DatasetParametroFornecedorMmm1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetParametroFornecedorMmm1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetParametroFornecedorMmm1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetParametroFornecedorMmm
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
                DatasetParametroFornecedorMmm1.EnforceConstraints = False
                DatasetParametroFornecedorMmm1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 0 'Nenhum
                        DatasetParametroFornecedorMmm1 = Controller.ObterParametrosFornecedorMmm(0, String.Empty)
                        DatasetParametroFornecedorMmm1.T0123884.DefaultView.Sort = "CODFRN"
                    Case 1 'Fornecedor
                        DatasetParametroFornecedorMmm1 = Controller.ObterParametroFornecedorMmm(Convert.ToDecimal(Request.QueryString("CODFRN")))
                        DatasetParametroFornecedorMmm1.T0123884.DefaultView.Sort = "CODFRN"
                End Select

                dtgListar.DataSource = DatasetParametroFornecedorMmm1.T0123884.DefaultView
                dtgListar.DataBind()

                WSCAcoesComerciais.dsParametroFornecedorMmm = Me.DatasetParametroFornecedorMmm1
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""ParametroFornecedorMmm.aspx?CODFRN=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & """;" & vbCrLf)
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
            '    Case 1 'Consulta por DESCRIÇÃO
            '        DatasetParametroFornecedorMmm1 = Controller.ObterParametroFornecedorMmm(Request.QueryString("FLGFRNAJTCMC"))
            '    Case 2 'Consulta por CÓDIGO
            '        DatasetParametroFornecedorMmm1 = Controller.ObterParametroFornecedorMmm(Decimal.Parse(Request.QueryString("CODFRN")))
            'End Select

            DatasetParametroFornecedorMmm1 = WSCAcoesComerciais.dsParametroFornecedorMmm
            dtgListar.DataSource = DatasetParametroFornecedorMmm1.T0123884.DefaultView
            dtgListar.DataBind()
        Catch ex As Exception
        End Try
    End Sub

End Class