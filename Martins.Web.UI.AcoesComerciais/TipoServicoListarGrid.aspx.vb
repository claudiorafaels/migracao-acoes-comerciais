Public Class TipoServicoListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoServico1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoServico
        CType(Me.DatasetTipoServico1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoServico1
        '
        Me.DatasetTipoServico1.DataSetName = "DatasetTipoServico"
        Me.DatasetTipoServico1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoServico1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetTipoServico1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoServico
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
                DatasetTipoServico1.EnforceConstraints = False
                DatasetTipoServico1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 0 'Nenhum
                        DatasetTipoServico1 = Controller.ObterTiposServico(String.Empty)
                        DatasetTipoServico1.T0138466.DefaultView.Sort = "TipSvcCttFrn" ' "DesTipSvcCttFrn"
                    Case 1 'Consulta por DESCRIÇÃO
                        DatasetTipoServico1 = Controller.ObterTiposServico(Request.QueryString("DesTipSvcCttFrn"))
                        DatasetTipoServico1.T0138466.DefaultView.Sort = "TipSvcCttFrn" '"DesTipSvcCttFrn"
                    Case 2 'Consulta por CÓDIGO
                        DatasetTipoServico1 = Controller.ObterTipoServico(Decimal.Parse(Request.QueryString("TipSvcCttFrn")))
                        DatasetTipoServico1.T0138466.DefaultView.Sort = "TipSvcCttFrn"
                End Select

                dtgListar.DataSource = DatasetTipoServico1.T0138466.DefaultView
                dtgListar.DataBind()
                WSCAcoesComerciais.dsTipoServico = DatasetTipoServico1
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""TipoBaseCalculo.aspx?TipSvcCttFrn =" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & """;" & vbCrLf)
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
            '        DatasetTipoServico1 = Controller.ObterTiposServico(Request.QueryString("DesTipSvcCttFrn"))
            '    Case 2 'Consulta por CÓDIGO
            '        DatasetTipoServico1 = Controller.ObterTipoServico(Decimal.Parse(Request.QueryString("TipSvcCttFrn")))
            'End Select
            DatasetTipoServico1 = WSCAcoesComerciais.dsTipoServico
            dtgListar.DataSource = DatasetTipoServico1.T0138466.DefaultView
            dtgListar.DataBind()
        Catch ex As Exception
        End Try
    End Sub

End Class