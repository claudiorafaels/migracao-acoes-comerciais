Public Class TipoFornecedorListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoFornecedor1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoFornecedor
        CType(Me.DatasetTipoFornecedor1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoFornecedor1
        '
        Me.DatasetTipoFornecedor1.DataSetName = "DatasetTipoFornecedor"
        Me.DatasetTipoFornecedor1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoFornecedor1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetTipoFornecedor1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoFornecedor
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
                DatasetTipoFornecedor1.EnforceConstraints = False
                DatasetTipoFornecedor1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 0 'Nenhum
                        DatasetTipoFornecedor1 = Controller.ObterTiposFornecedor(String.Empty)
                        DatasetTipoFornecedor1.T0138440.DefaultView.Sort = "TipFrnCttFrn" '"DesTipFrnCttFrn"
                    Case 1 'Consulta por DESCRIÇÃO
                        DatasetTipoFornecedor1 = Controller.ObterTiposFornecedor(Request.QueryString("DesTipFrnCttFrn"))
                        DatasetTipoFornecedor1.T0138440.DefaultView.Sort = "TipFrnCttFrn" '"DesTipFrnCttFrn"
                    Case 2 'Consulta por CÓDIGO
                        DatasetTipoFornecedor1 = Controller.ObterTipoFornecedor(Decimal.Parse(Request.QueryString("TipFrnCttFrn")))
                        DatasetTipoFornecedor1.T0138440.DefaultView.Sort = "TipFrnCttFrn"
                End Select

                dtgListar.DataSource = DatasetTipoFornecedor1.T0138440.DefaultView
                dtgListar.DataBind()

                WSCAcoesComerciais.dsTipoFornecedor = DatasetTipoFornecedor1
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""TipoFornecedor.aspx?TipFrnCttFrn=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & """;" & vbCrLf)
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
            '        DatasetTipoFornecedor1 = Controller.ObterTiposFornecedor(Request.QueryString("DesTipFrnCttFrn"))
            '    Case 2 'Consulta por CÓDIGO
            '        DatasetTipoFornecedor1 = Controller.ObterTipoFornecedor(Decimal.Parse(Request.QueryString("TipFrnCttFrn")))
            'End Select

            DatasetTipoFornecedor1 = WSCAcoesComerciais.dsTipoFornecedor
            dtgListar.DataSource = DatasetTipoFornecedor1.T0138440.DefaultView
            dtgListar.DataBind()
        Catch ex As Exception
        End Try
    End Sub

End Class