Public Class ContratoListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetContrato1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContrato
        CType(Me.DatasetContrato1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetContrato1
        '
        Me.DatasetContrato1.DataSetName = "DatasetContrato"
        Me.DatasetContrato1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetContrato1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents DatasetContrato1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContrato
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
                DatasetContrato1.EnforceConstraints = False
                DatasetContrato1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 1 '1 Codigo
                        dtgListar.Columns(3).Visible = True
                        DatasetContrato1 = Controller.ObterContrato(Convert.ToDecimal(Request.QueryString("CODCTT")))
                        DatasetContrato1.T0124945.DefaultView.Sort = "NUMCTTFRN"
                    Case 2 '2 Fornecedor
                        dtgListar.Columns(3).Visible = False
                        DatasetContrato1 = Controller.ObterContratos(0, 0, String.Empty, Convert.ToDecimal(Request.QueryString("CODFRN")), Decimal.Zero)
                        DatasetContrato1.T0124945.DefaultView.Sort = "NUMCTTFRN"
                End Select

                dtgListar.DataSource = DatasetContrato1.T0124945.DefaultView
                dtgListar.DataBind()
                WSCAcoesComerciais.dsContrato = DatasetContrato1
            Else
                If Not Me.ViewState.Item(DatasetContrato1.DataSetName) Is Nothing Then _
                    DatasetContrato1 = DirectCast(Me.ViewState.Item(DatasetContrato1.DataSetName), wsAcoesComerciais.DatasetContrato)
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""Contrato.aspx?numcttfrn=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & """;" & vbCrLf)
                Response.Write("</script>" & vbCrLf)
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub dtgListar_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgListar.PageIndexChanged
        Me.dtgListar.CurrentPageIndex = e.NewPageIndex
        DatasetContrato1 = WSCAcoesComerciais.dsContrato
        dtgListar.DataSource = DatasetContrato1.T0124945.DefaultView
        dtgListar.DataBind()
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        If Not DatasetContrato1 Is Nothing Then _
               Me.ViewState.Add(DatasetContrato1.DataSetName, DatasetContrato1)
    End Sub

    Protected Function obterNOMFRN(ByVal codigo As Decimal) As String
        Try
            Dim ds As wsAcoesComerciais.dataSetDivisaoFornecedor

            If dtgListar.Columns(3).Visible = False Then
                Return ""
            End If

            ds = Controller.ObterDivisaoFornecedor(1, Convert.ToInt32(codigo))
            If ds.T0100426.Rows.Count = 0 Then
                Return ""
            End If
            Return ds.T0100426(0).NOMFRN
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

End Class