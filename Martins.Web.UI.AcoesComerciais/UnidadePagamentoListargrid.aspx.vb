Public Class UnidadePagamentoListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoUnidadePagamento1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoUnidadePagamento
        CType(Me.DatasetTipoUnidadePagamento1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoUnidadePagamento1
        '
        Me.DatasetTipoUnidadePagamento1.DataSetName = "DatasetTipoUnidadePagamento"
        Me.DatasetTipoUnidadePagamento1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoUnidadePagamento1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetUnidadePagamento1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoUnidadePagamento
    Protected WithEvents DatasetTipoUnidadePagamento1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoUnidadePagamento
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
                DatasetTipoUnidadePagamento1.EnforceConstraints = False
                DatasetTipoUnidadePagamento1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 0
                        DatasetTipoUnidadePagamento1 = Controller.ObterTiposUnidadePagamento(String.Empty)
                        DatasetTipoUnidadePagamento1.T0138458.DefaultView.Sort = "TipUndPgtCttFrn" '"DesTipUndPgtCttFrn"
                    Case 1 'Consulta por DESCRIÇÃO
                        DatasetTipoUnidadePagamento1 = Controller.ObterTiposUnidadePagamento(Request.QueryString("DesTipUndPgtCttFrn"))
                        DatasetTipoUnidadePagamento1.T0138458.DefaultView.Sort = "TipUndPgtCttFrn" '"DesTipUndPgtCttFrn"
                    Case 2 'Consulta por CÓDIGO
                        DatasetTipoUnidadePagamento1 = Controller.ObterTipoUnidadePagamento(Decimal.Parse(Request.QueryString("TipUndPgtCttFrn")))
                        DatasetTipoUnidadePagamento1.T0138458.DefaultView.Sort = "TipUndPgtCttFrn"
                End Select

                dtgListar.DataSource = DatasetTipoUnidadePagamento1.T0138458.DefaultView
                dtgListar.DataBind()
                WSCAcoesComerciais.dsTipoUnidadePagamento = DatasetTipoUnidadePagamento1
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""UnidadePagamento.aspx?TipUndPgtCttFrn=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & """;" & vbCrLf)
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
            '        DatasetTipoUnidadePagamento1 = Controller.ObterTiposUnidadePagamento(Request.QueryString("DesTipUndPgtCttFrn"))
            '    Case 2 'Consulta por CÓDIGO
            '        DatasetTipoUnidadePagamento1 = Controller.ObterTipoUnidadePagamento(Decimal.Parse(Request.QueryString("TipUndPgtCttFrn")))
            'End Select

            DatasetTipoUnidadePagamento1 = WSCAcoesComerciais.dsTipoUnidadePagamento
            dtgListar.DataSource = DatasetTipoUnidadePagamento1.T0138458.DefaultView
            dtgListar.DataBind()
        Catch ex As Exception
        End Try
    End Sub

End Class