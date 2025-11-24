Public Class TipoRelacionamentoListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoRelacionamento1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoRelacionamento
        CType(Me.DatasetTipoRelacionamento1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoRelacionamento1
        '
        Me.DatasetTipoRelacionamento1.DataSetName = "DatasetTipoRelacionamento"
        Me.DatasetTipoRelacionamento1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoRelacionamento1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetTipoRelacionamento1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoRelacionamento
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
                DatasetTipoRelacionamento1.EnforceConstraints = False
                DatasetTipoRelacionamento1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 0 'Nenhuma
                        DatasetTipoRelacionamento1 = Controller.ObterTiposRelacionamento(String.Empty)
                        DatasetTipoRelacionamento1.T0138474.DefaultView.Sort = "TipRlcCttFrn" '"DesTipRlcCttFrn"
                    Case 1 'Consulta por DESCRIÇÃO
                        DatasetTipoRelacionamento1 = Controller.ObterTiposRelacionamento(Request.QueryString("DesTipRlcCttFrn"))
                        DatasetTipoRelacionamento1.T0138474.DefaultView.Sort = "TipRlcCttFrn" '"DesTipRlcCttFrn"
                    Case 2 'Consulta por CÓDIGO
                        DatasetTipoRelacionamento1 = Controller.ObterTipoRelacionamento(Decimal.Parse(Request.QueryString("TipRlcCttFrn")))
                        DatasetTipoRelacionamento1.T0138474.DefaultView.Sort = "TipRlcCttFrn"
                End Select

                dtgListar.DataSource = DatasetTipoRelacionamento1.T0138474.DefaultView
                dtgListar.DataBind()
                WSCAcoesComerciais.dsTipoRelacionamento = DatasetTipoRelacionamento1
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""TipoRelacionamento.aspx?TipRlcCttFrn=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & """;" & vbCrLf)
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
            '        DatasetTipoRelacionamento1 = Controller.ObterTiposRelacionamento(Request.QueryString("DesTipRlcCttFrn"))
            '    Case 2 'Consulta por CÓDIGO
            '        DatasetTipoRelacionamento1 = Controller.ObterTipoRelacionamento(Decimal.Parse(Request.QueryString("TipRlcCttFrn")))
            'End Select

            DatasetTipoRelacionamento1 = WSCAcoesComerciais.dsTipoRelacionamento
            dtgListar.DataSource = DatasetTipoRelacionamento1.T0138474.DefaultView
            dtgListar.DataBind()
        Catch ex As Exception
        End Try
    End Sub

End Class