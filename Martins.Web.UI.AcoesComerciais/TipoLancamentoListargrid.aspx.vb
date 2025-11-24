Public Class TipoLancamentoListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoLancamentoContaCorrenteFornecedor1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor
        CType(Me.DatasetTipoLancamentoContaCorrenteFornecedor1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoLancamentoContaCorrenteFornecedor1
        '
        Me.DatasetTipoLancamentoContaCorrenteFornecedor1.DataSetName = "DatasetTipoLancamentoContaCorrenteFornecedor"
        Me.DatasetTipoLancamentoContaCorrenteFornecedor1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoLancamentoContaCorrenteFornecedor1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents DatasetTipoLancamento1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetTipoLancamentoContaCorrenteFornecedor1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor
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
                DatasetTipoLancamentoContaCorrenteFornecedor1.EnforceConstraints = False
                DatasetTipoLancamentoContaCorrenteFornecedor1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 0
                        DatasetTipoLancamentoContaCorrenteFornecedor1 = Controller.ObterTiposLancamentoContaCorrenteFornecedor(String.Empty, String.Empty)
                        DatasetTipoLancamentoContaCorrenteFornecedor1.T0123108.DefaultView.Sort = ("CodTipLmt")
                    Case 1 'Consulta por CÓDIGO
                        DatasetTipoLancamentoContaCorrenteFornecedor1 = Controller.ObterTipoLancamentoContaCorrenteFornecedor(Decimal.Parse(Request.QueryString("CodTipLmt")))
                        DatasetTipoLancamentoContaCorrenteFornecedor1.T0123108.DefaultView.Sort = ("CodTipLmt")
                    Case 2 'Consulta por DESCRIÇÃO
                        DatasetTipoLancamentoContaCorrenteFornecedor1 = Controller.ObterTiposLancamentoContaCorrenteFornecedor(Request.QueryString("DesTipLmt"), String.Empty)
                        DatasetTipoLancamentoContaCorrenteFornecedor1.T0123108.DefaultView.Sort = ("CodTipLmt")
                End Select

                dtgListar.DataSource = DatasetTipoLancamentoContaCorrenteFornecedor1.T0123108.DefaultView
                dtgListar.DataBind()
                WSCAcoesComerciais.dsTipoLancamentoContacorrenteFornecedor = DatasetTipoLancamentoContaCorrenteFornecedor1
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""TipoLancamento.aspx?CodTipLmt=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & """;" & vbCrLf)
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
            '    Case 1 'Consulta por CÓDIGO
            '        DatasetTipoLancamentoContaCorrenteFornecedor1 = Controller.ObterTipoLancamentoContaCorrenteFornecedor(Decimal.Parse(Request.QueryString("CodTipLmt")))
            '    Case 2 'Consulta por DESCRIÇÃO
            '        DatasetTipoLancamentoContaCorrenteFornecedor1 = Controller.ObterTiposLancamentoContaCorrenteFornecedor(Request.QueryString("DesTipLmt"), String.Empty)
            'End Select

            DatasetTipoLancamentoContaCorrenteFornecedor1 = WSCAcoesComerciais.dsTipoLancamentoContacorrenteFornecedor
            dtgListar.DataSource = DatasetTipoLancamentoContaCorrenteFornecedor1.T0123108.DefaultView
            dtgListar.DataBind()
        Catch ex As Exception
        End Try
    End Sub
End Class