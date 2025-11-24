Public Class TipoFormaPagamentoListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoFormaPagamento1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoFormaPagamento
        CType(Me.DatasetTipoFormaPagamento1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoFormaPagamento1
        '
        Me.DatasetTipoFormaPagamento1.DataSetName = "DatasetTipoFormaPagamento"
        Me.DatasetTipoFormaPagamento1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoFormaPagamento1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetTipoFormaPagamento1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoFormaPagamento
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
                DatasetTipoFormaPagamento1.EnforceConstraints = False
                DatasetTipoFormaPagamento1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 0 'Nenhum
                        DatasetTipoFormaPagamento1 = Controller.ObterTiposFormaPagamento(String.Empty)
                        DatasetTipoFormaPagamento1.T0138407.DefaultView.Sort = "TipFrmPgtCttFrn" '"DesTipFrmPgtCttFrn"
                    Case 1 'Consulta por DESCRIÇÃO
                        DatasetTipoFormaPagamento1 = Controller.ObterTiposFormaPagamento(Request.QueryString("DesTipFrmPgtCttFrn"))
                        DatasetTipoFormaPagamento1.T0138407.DefaultView.Sort = "TipFrmPgtCttFrn" '"DesTipFrmPgtCttFrn"
                    Case 2 'Consulta por CÓDIGO
                        DatasetTipoFormaPagamento1 = Controller.ObterTipoFormaPagamento(Decimal.Parse(Request.QueryString("TipFrmPgtCttFrn")))
                        DatasetTipoFormaPagamento1.T0138407.DefaultView.Sort = "TipFrmPgtCttFrn"
                End Select

                dtgListar.DataSource = DatasetTipoFormaPagamento1.T0138407.DefaultView
                dtgListar.DataBind()
                WSCAcoesComerciais.dsTipoFormaPagamento = DatasetTipoFormaPagamento1
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""TipoFormaPagamento.aspx?TipFrmPgtCttFrn=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & """;" & vbCrLf)
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
            '        DatasetTipoFormaPagamento1 = Controller.ObterTiposFormaPagamento(Request.QueryString("DesTipFrmPgtCttFrn"))
            '    Case 2 'Consulta por CÓDIGO
            '        DatasetTipoFormaPagamento1 = Controller.ObterTipoFormaPagamento(Decimal.Parse(Request.QueryString("TipFrmPgtCttFrn")))
            'End Select

            DatasetTipoFormaPagamento1 = WSCAcoesComerciais.dsTipoFormaPagamento
            dtgListar.DataSource = DatasetTipoFormaPagamento1.T0138407.DefaultView
            dtgListar.DataBind()
        Catch ex As Exception
        End Try
    End Sub

End Class