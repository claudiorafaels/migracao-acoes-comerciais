Public Class TipoGrupoMktListar
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "
    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoGrupoMarketing1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoGrupoMarketing
        CType(Me.DatasetTipoGrupoMarketing1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoGrupoMarketing1
        '
        Me.DatasetTipoGrupoMarketing1.DataSetName = "DatasetTipoGrupoMarketing"
        Me.DatasetTipoGrupoMarketing1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoGrupoMarketing1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents Div1 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents cmbCriterio As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TRCodigo As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents TRDescricao As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnNovo As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtTIPGRPMKTFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtDESGRPMKTFRN As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents DatasetTipoGrupoMarketing1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoGrupoMarketing
    Protected WithEvents grdVerbasMarketing As Infragistics.WebUI.UltraWebGrid.UltraWebGrid


    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "Eventos"
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If IsPostBack Then
                Me.RecuperaEstado()
            Else
                Me.IniciarPagina()
            End If
            carregarJavaScript()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNovo.Click
        Try
            Response.Redirect("TipoGrupoMktManter.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Try
            Dim DESGRPMKTFRN As String = String.Empty
            Dim TIPGRPMKTFRN As Decimal = 0

            'CODIGO
            If cmbCriterio.SelectedValue = "1" Then
                TIPGRPMKTFRN = txtTIPGRPMKTFRN.ValueDecimal
                'DESCRICAO
            ElseIf cmbCriterio.SelectedValue = "2" Then
                DESGRPMKTFRN = txtDESGRPMKTFRN.Text
            End If

            CarregaGrid(TIPGRPMKTFRN, DESGRPMKTFRN)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmbCriterio_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCriterio.SelectedIndexChanged
        Try
            If CType(cmbCriterio.SelectedValue, Decimal) = 0 Then
                TRCodigo.Visible = False
                TRDescricao.Visible = False
            ElseIf CType(cmbCriterio.SelectedValue, Decimal) = 1 Then
                TRCodigo.Visible = True
                TRDescricao.Visible = False
            ElseIf CType(cmbCriterio.SelectedValue, Decimal) = 2 Then
                TRCodigo.Visible = False
                TRDescricao.Visible = True
            End If
            txtTIPGRPMKTFRN.Text = String.Empty
            txtDESGRPMKTFRN.Text = String.Empty
            grdVerbasMarketing.Rows.Clear()
            grdVerbasMarketing.Visible = False
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub

    Private Sub grdVerbasMarketing_ItemCommand(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.UltraWebGridCommandEventArgs) Handles grdVerbasMarketing.ItemCommand
        Try
            'Detalhes
            If e.InnerCommandEventArgs.CommandName.Equals("btnEditar") Then

                Dim TIPGRPMKTFRN As Decimal

                TIPGRPMKTFRN = CType(CType(e.ParentControl, Infragistics.WebUI.UltraWebGrid.CellItem).Cell.Row.Cells.FromKey("TIPGRPMKTFRN").Value, Decimal)

                'Redireciona para página meio
                Response.Redirect("TipoGrupoMktManter.aspx?TIPGRPMKTFRN=" & TIPGRPMKTFRN.ToString)

            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub
#End Region

#Region "Métodos de Carga"

    Private Sub IniciarPagina()
        TRCodigo.Visible = False
        TRDescricao.Visible = False
        grdVerbasMarketing.Visible = False
        Dim TIPGRPMKTFRN As Decimal = 0
        If Not Request.QueryString("TIPGRPMKTFRN") Is Nothing Then
            TIPGRPMKTFRN = CType(Request.QueryString("TIPGRPMKTFRN"), Decimal)
            CarregaGrid(TIPGRPMKTFRN)
        End If
    End Sub

    Private Sub carregarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        btnPesquisar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
    End Sub

    Public Sub CarregaGrid(ByVal TIPGRPMKTFRN As Decimal, ByVal DESGRPMKTFRN As String)

        Me.DatasetTipoGrupoMarketing1 = Controller.ObterTipoGrupoMarketingPorAtributo(TIPGRPMKTFRN, DESGRPMKTFRN)

        If Me.DatasetTipoGrupoMarketing1.CADTIPGRPMKTFRNPesquisa.Rows.Count > 0 Then
            grdVerbasMarketing.DataBind()
            grdVerbasMarketing.Visible = True
        Else
            Util.AdicionaJsAlert(Me.Page, "Registro(s) não encontrado(s)!", False)
            grdVerbasMarketing.Rows.Clear()
            grdVerbasMarketing.Visible = False
        End If
    End Sub

    Public Sub CarregaGrid(ByVal TIPGRPMKTFRN As Decimal)

        Me.DatasetTipoGrupoMarketing1 = Controller.ObterTipoGrupoMarketingPorChavePesquisa(TIPGRPMKTFRN)

        If Not Me.DatasetTipoGrupoMarketing1 Is Nothing Then
            grdVerbasMarketing.DataBind()
            grdVerbasMarketing.Visible = True
        Else
            Util.AdicionaJsAlert(Me.Page, "Registro(s) não encontrado(s)!", False)
        End If
    End Sub
#End Region

#Region "Métodos de Controle"
    Private Sub RecuperaEstado()
        'Me.DatasetRelacaoMercadoriaEPortariaBeneficioProdutoInformatica1 = WebSession.dsRelacaoMercadoriaEPortariaBeneficioProdutoInformatica
    End Sub

    Private Sub SalvaEstado()
        'WebSession.dsRelacaoMercadoriaEPortariaBeneficioProdutoInformatica = Me.DatasetRelacaoMercadoriaEPortariaBeneficioProdutoInformatica1
    End Sub
#End Region

#Region "Métodos de Regra"

#End Region

   
End Class