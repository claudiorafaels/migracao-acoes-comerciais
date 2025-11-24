Public Class TipoGrupoMktManter
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
    Protected WithEvents TRCodigo As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents TRDescricao As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents txtTIPGRPMKTFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtDESGRPMKTFRN As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents DatasetTipoGrupoMarketing1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoGrupoMarketing
    Protected WithEvents txtPERGRPMKTFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents rblINDORIVBAMKT As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnSair As System.Web.UI.WebControls.LinkButton


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

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            SalvarDados()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Try
            Response.Redirect("TipoGrupoMktListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub
#End Region

#Region "Métodos de Carga"

    Private Sub IniciarPagina()
        Dim TIPGRPMKTFRN As Decimal = 0
        If Not Request.QueryString("TIPGRPMKTFRN") Is Nothing Then
            TIPGRPMKTFRN = CType(Request.QueryString("TIPGRPMKTFRN"), Decimal)
        End If
        CarregaPagina(TIPGRPMKTFRN)
    End Sub

    Private Sub carregarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
    End Sub

    Public Sub CarregaPagina(ByVal TIPGRPMKTFRN As Decimal)
        Dim CADTIPGRPMKTFRNRow As wsAcoesComerciais.DatasetTipoGrupoMarketing.CADTIPGRPMKTFRNRow

        Me.DatasetTipoGrupoMarketing1 = Controller.ObterTipoGrupoMarketingPorChave(TIPGRPMKTFRN)

        If Not Me.DatasetTipoGrupoMarketing1 Is Nothing Then
            If Me.DatasetTipoGrupoMarketing1.CADTIPGRPMKTFRN.Rows.Count > 0 Then
                CADTIPGRPMKTFRNRow = Me.DatasetTipoGrupoMarketing1.CADTIPGRPMKTFRN(0)

                txtTIPGRPMKTFRN.ValueDecimal = CADTIPGRPMKTFRNRow.TIPGRPMKTFRN
                txtDESGRPMKTFRN.Text = CADTIPGRPMKTFRNRow.DESGRPMKTFRN.Trim
                txtPERGRPMKTFRN.ValueDecimal = CADTIPGRPMKTFRNRow.PERGRPMKTFRN
                rblINDORIVBAMKT.SelectedValue = CADTIPGRPMKTFRNRow.INDORIVBAMKT.ToString
            End If
        End If
    End Sub

    Public Sub SalvarDados()
        Dim TIPGRPMKTFRN As Decimal = Controller.ObterNovaChaveTipoGrupoMarketing()
        Dim CADTIPGRPMKTFRNRow As wsAcoesComerciais.DatasetTipoGrupoMarketing.CADTIPGRPMKTFRNRow

        If txtTIPGRPMKTFRN.Text = String.Empty Then
            CADTIPGRPMKTFRNRow = Me.DatasetTipoGrupoMarketing1.CADTIPGRPMKTFRN.NewCADTIPGRPMKTFRNRow
        Else
            TIPGRPMKTFRN = txtTIPGRPMKTFRN.ValueDecimal
            Me.DatasetTipoGrupoMarketing1 = Controller.ObterTipoGrupoMarketingPorChave(TIPGRPMKTFRN)
            CADTIPGRPMKTFRNRow = Me.DatasetTipoGrupoMarketing1.CADTIPGRPMKTFRN(0)
        End If

        With CADTIPGRPMKTFRNRow
            .TIPGRPMKTFRN = CType(txtTIPGRPMKTFRN.ValueDecimal, Integer)
            .DESGRPMKTFRN = txtDESGRPMKTFRN.Text.ToUpper.Trim
            .PERGRPMKTFRN = txtPERGRPMKTFRN.ValueDecimal
            .INDORIVBAMKT = CType(rblINDORIVBAMKT.SelectedValue, Integer)
        End With

        If txtTIPGRPMKTFRN.Text = String.Empty Then
            Me.DatasetTipoGrupoMarketing1.CADTIPGRPMKTFRN.AddCADTIPGRPMKTFRNRow(CADTIPGRPMKTFRNRow)
        End If

        Controller.AtualizarTipoGrupoMarketing(Me.DatasetTipoGrupoMarketing1)

        Response.Redirect("TipoGrupoMktListar.aspx?TIPGRPMKTFRN=" & TIPGRPMKTFRN.ToString)
    End Sub
#End Region

#Region "Métodos de Controle"
    Private Sub RecuperaEstado()
        '    Me.DatasetTipoGrupoMarketing1 = WebSession.dsTipoGrupoMarketing
    End Sub

    Private Sub SalvaEstado()
        '    WebSession.dsTipoGrupoMarketing = Me.DatasetTipoGrupoMarketing1
    End Sub
#End Region

#Region "Métodos de Regra"

#End Region


End Class