Public Class TipoPagamentoListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoPagamento1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoPagamento
        CType(Me.DatasetTipoPagamento1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoPagamento1
        '
        Me.DatasetTipoPagamento1.DataSetName = "DatasetTipoPagamento"
        Me.DatasetTipoPagamento1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoPagamento1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetTipoPagamento1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoPagamento
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
                DatasetTipoPagamento1.EnforceConstraints = False
                DatasetTipoPagamento1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 0 'Nenhum
                        DatasetTipoPagamento1 = Controller.ObterTiposPagamento(String.Empty)
                        DatasetTipoPagamento1.T0138431.DefaultView.Sort = "TipPgtNotFscCttFrn" '"DesTipPgtNotFscCtt"
                    Case 1 'Consulta por DESCRIÇÃO
                        DatasetTipoPagamento1 = Controller.ObterTiposPagamento(Request.QueryString("DesTipPgtNotFscCtt"))
                        DatasetTipoPagamento1.T0138431.DefaultView.Sort = "TipPgtNotFscCttFrn" '"DesTipPgtNotFscCtt"
                    Case 2 'Consulta por CÓDIGO
                        DatasetTipoPagamento1 = Controller.ObterTipoPagamento(Decimal.Parse(Request.QueryString("TipPgtNotFscCttFrn")))
                        DatasetTipoPagamento1.T0138431.DefaultView.Sort = "TipPgtNotFscCttFrn"
                End Select

                dtgListar.DataSource = DatasetTipoPagamento1.T0138431.DefaultView
                dtgListar.DataBind()
                WSCAcoesComerciais.dsTipoPagamento = DatasetTipoPagamento1
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""TipoPagamento.aspx?TipPgtNotFscCttFrn=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & """;" & vbCrLf)
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
            '        DatasetTipoPagamento1 = Controller.ObterTiposPagamento(Request.QueryString("DesTipPgtNotFscCtt"))
            '    Case 2 'Consulta por CÓDIGO
            '        DatasetTipoPagamento1 = Controller.ObterTipoPagamento(Decimal.Parse(Request.QueryString("TipPgtNotFscCttFrn")))
            'End Select

            DatasetTipoPagamento1 = WSCAcoesComerciais.dsTipoPagamento
            dtgListar.DataSource = DatasetTipoPagamento1.T0138431.DefaultView
            dtgListar.DataBind()
        Catch ex As Exception
        End Try
    End Sub

End Class