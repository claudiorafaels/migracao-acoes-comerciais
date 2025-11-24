Public Class TipoEncargoFinanceiroListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoEncargoFinanceiro1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoEncargoFinanceiro
        CType(Me.DatasetTipoEncargoFinanceiro1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoEncargoFinanceiro1
        '
        Me.DatasetTipoEncargoFinanceiro1.DataSetName = "DatasetTipoEncargoFinanceiro"
        Me.DatasetTipoEncargoFinanceiro1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoEncargoFinanceiro1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetTipoEncargoFinanceiro1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoEncargoFinanceiro
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
                DatasetTipoEncargoFinanceiro1.EnforceConstraints = False
                DatasetTipoEncargoFinanceiro1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 0 'Nenhum
                        DatasetTipoEncargoFinanceiro1 = Controller.ObterTiposEncargoFinanceiro(String.Empty)
                        DatasetTipoEncargoFinanceiro1.T0138415.DefaultView.Sort = "TipEncFinCttFrn" '"DesTipEncFinCttFrn"
                    Case 1 'Consulta por DESCRIÇÃO
                        DatasetTipoEncargoFinanceiro1 = Controller.ObterTiposEncargoFinanceiro(Request.QueryString("DesTipEncFinCttFrn"))
                        DatasetTipoEncargoFinanceiro1.T0138415.DefaultView.Sort = "TipEncFinCttFrn" '"DesTipEncFinCttFrn"
                    Case 2 'Consulta por CÓDIGO
                        DatasetTipoEncargoFinanceiro1 = Controller.ObterTipoEncargoFinanceiro(Decimal.Parse(Request.QueryString("TipEncFinCttFrn")))
                        DatasetTipoEncargoFinanceiro1.T0138415.DefaultView.Sort = "TipEncFinCttFrn"
                End Select

                dtgListar.DataSource = DatasetTipoEncargoFinanceiro1.T0138415.DefaultView
                dtgListar.DataBind()
                WSCAcoesComerciais.dsTipoEncargoFinanceiro = DatasetTipoEncargoFinanceiro1
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""TipoEncargoFinanceiro.aspx?TipEncFinCttFrn=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & """;" & vbCrLf)
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
            '        DatasetTipoEncargoFinanceiro1 = Controller.ObterTiposEncargoFinanceiro(Request.QueryString("DesTipEncFinCttFrn"))
            '    Case 2 'Consulta por CÓDIGO
            '        DatasetTipoEncargoFinanceiro1 = Controller.ObterTipoEncargoFinanceiro(Decimal.Parse(Request.QueryString("TipEncFinCttFrn")))
            'End Select

            DatasetTipoEncargoFinanceiro1 = WSCAcoesComerciais.dsTipoEncargoFinanceiro
            dtgListar.DataSource = DatasetTipoEncargoFinanceiro1.T0138415.DefaultView
            dtgListar.DataBind()
        Catch ex As Exception
        End Try
    End Sub

End Class