Public Class TipoAbrangenciaListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoAbrangencia1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoAbrangencia
        CType(Me.DatasetTipoAbrangencia1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoAbrangencia1
        '
        Me.DatasetTipoAbrangencia1.DataSetName = "DatasetTipoAbrangencia"
        Me.DatasetTipoAbrangencia1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoAbrangencia1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetTipoAbrangencia1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoAbrangencia
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
                DatasetTipoAbrangencia1.EnforceConstraints = False
                DatasetTipoAbrangencia1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 0 'Nenhum
                        DatasetTipoAbrangencia1 = Controller.ObterTiposAbrangencia("")
                        DatasetTipoAbrangencia1.T0138423.DefaultView.Sort = "TipAbgTabPcoCttFrn" '"DesTipAbgTabPcoCtt"
                    Case 1 'Consulta por DESCRIÇÃO
                        DatasetTipoAbrangencia1 = Controller.ObterTiposAbrangencia(Request.QueryString("DesTipAbgTabPcoCtt"))
                        DatasetTipoAbrangencia1.T0138423.DefaultView.Sort = "TipAbgTabPcoCttFrn" '"DesTipAbgTabPcoCtt"
                    Case 2 'Consulta por CÓDIGO
                        DatasetTipoAbrangencia1 = Controller.ObterTipoAbrangencia(Decimal.Parse(Request.QueryString("TipAbgTabPcoCttFrn")))
                        DatasetTipoAbrangencia1.T0138423.DefaultView.Sort = "TipAbgTabPcoCttFrn"
                End Select

                dtgListar.DataSource = DatasetTipoAbrangencia1.T0138423.DefaultView
                dtgListar.DataBind()
                WSCAcoesComerciais.dsTipoAbrangencia = DatasetTipoAbrangencia1
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""TipoAbrangencia.aspx?TipAbgTabPcoCttFrn=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & """;" & vbCrLf)
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
            '        DatasetTipoAbrangencia1 = Controller.ObterTiposAbrangencia(Request.QueryString("DesTipAbgTabPcoCtt"))
            '    Case 2 'Consulta por CÓDIGO
            '        DatasetTipoAbrangencia1 = Controller.ObterTipoAbrangencia(Decimal.Parse(Request.QueryString("TipAbgTabPcoCttFrn")))
            'End Select

            DatasetTipoAbrangencia1 = WSCAcoesComerciais.dsTipoAbrangencia
            dtgListar.DataSource = DatasetTipoAbrangencia1.T0138423.DefaultView
            dtgListar.DataBind()
        Catch ex As Exception
        End Try
    End Sub

End Class