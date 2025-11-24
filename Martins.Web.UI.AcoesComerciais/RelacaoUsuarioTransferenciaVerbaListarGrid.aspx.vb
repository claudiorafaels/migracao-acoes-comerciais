Public Class RelacaoUsuarioTransferenciaVerbaListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dsTipoTransferenciaXUsuario = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoTransferenciaXUsuario
        CType(Me.dsTipoTransferenciaXUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'dsTipoTransferenciaXUsuario
        '
        Me.dsTipoTransferenciaXUsuario.DataSetName = "DatasetTipoTransferenciaXUsuario"
        Me.dsTipoTransferenciaXUsuario.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.dsTipoTransferenciaXUsuario, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents dsTipoTransferenciaXUsuario As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoTransferenciaXUsuario

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Property VSdsTipoTransferenciaXUsuario() As wsAcoesComerciais.DatasetTipoTransferenciaXUsuario
        Get
            If Not Me.ViewState.Item("dsTipoTransferenciaXUsuario") Is Nothing Then
                Return CType(Me.ViewState.Item("dsTipoTransferenciaXUsuario"), wsAcoesComerciais.DatasetTipoTransferenciaXUsuario)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetTipoTransferenciaXUsuario)
            Me.ViewState.Add("dsTipoTransferenciaXUsuario", Value)
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Me.Page.IsPostBack() Then
            Me.CarregaDS()
            dtgListar.DataBind()
            WSCAcoesComerciais.dsTipoTransferenciaxUsuario = dsTipoTransferenciaXUsuario
        End If
        'Me.dsTipoTransferenciaXUsuario.T0135092(0).T0135033Row
    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "grdExcluir" Then
                dsTipoTransferenciaXUsuario = VSdsTipoTransferenciaXUsuario
                dsTipoTransferenciaXUsuario.T0135092.Item(e.Item.DataSetIndex).Delete()
                Controller.AtualizarTipoTransferenciaXUsuario(dsTipoTransferenciaXUsuario)
                Util.AdicionaJsAlert(Me.Page, "Exclusão relação usuário X tipo transferência executada com sucesso.")
                dtgListar.DataBind()
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub dtgListar_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) handles dtgListar.PageIndexChanged 
        Try
            dsTipoTransferenciaXUsuario = VSdsTipoTransferenciaXUsuario
            Me.dtgListar.CurrentPageIndex = e.NewPageIndex
            dtgListar.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CarregaDS()
        If Request.QueryString.Item("criterio").Equals("1") Then
            VSdsTipoTransferenciaXUsuario = Controller.ObterTiposTransferenciasXUsuario(Convert.ToDecimal(Request.QueryString.Item("cod")), String.Empty)
        ElseIf Request.QueryString.Item("criterio").Equals("2") Then
            VSdsTipoTransferenciaXUsuario = Controller.ObterTiposTransferenciasXUsuario(0, Request.QueryString.Item("cod"))
        End If
        dsTipoTransferenciaXUsuario = VSdsTipoTransferenciaXUsuario
    End Sub

    Private Sub dtgListar_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgListar.ItemDataBound
        Select Case e.Item.ItemType
            Case ListItemType.Item, ListItemType.AlternatingItem
                CType(e.Item.Cells(0).FindControl("imbExcluir"), ImageButton).Attributes.Add("onClick", "javascript:return confirm('Deseja realmente excluir este registro?');")
        End Select
    End Sub

End Class
