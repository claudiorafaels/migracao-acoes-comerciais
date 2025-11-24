Public Class ObservacaoFluxoCancelamentoAcordo
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetCelula1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetCelula
        Me.DataSetEstruturaCompra1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.dataSetEstruturaCompra
        Me.DatasetSelecaoValorDisponivelFornecedor1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
        Me.DatasetTransferenciaVerbaFornecedor1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor
        CType(Me.DatasetCelula1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetEstruturaCompra1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetSelecaoValorDisponivelFornecedor1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetTransferenciaVerbaFornecedor1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetCelula1
        '
        Me.DatasetCelula1.DataSetName = "DatasetCelula"
        Me.DatasetCelula1.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DataSetEstruturaCompra1
        '
        Me.DataSetEstruturaCompra1.DataSetName = "dataSetEstruturaCompra"
        Me.DataSetEstruturaCompra1.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DatasetSelecaoValorDisponivelFornecedor1
        '
        Me.DatasetSelecaoValorDisponivelFornecedor1.DataSetName = "DatasetSelecaoValorDisponivelFornecedor"
        Me.DatasetSelecaoValorDisponivelFornecedor1.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DatasetTransferenciaVerbaFornecedor1
        '
        Me.DatasetTransferenciaVerbaFornecedor1.DataSetName = "DatasetTransferenciaVerbaFornecedor"
        Me.DatasetTransferenciaVerbaFornecedor1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetCelula1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetEstruturaCompra1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetSelecaoValorDisponivelFornecedor1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetTransferenciaVerbaFornecedor1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetCelula1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetCelula
    Protected WithEvents DataSetEstruturaCompra1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.dataSetEstruturaCompra
    Protected WithEvents btnSair As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetSelecaoValorDisponivelFornecedor1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
    Protected WithEvents DatasetTransferenciaVerbaFornecedor1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor
    Protected WithEvents lblObservacao As System.Web.UI.WebControls.Label
    Protected WithEvents txtDESOBSAPV As System.Web.UI.WebControls.TextBox

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
            If (Not IsPostBack) Then
                Me.IniciarPagina()
            Else
                Me.RecuperaEstado()
            End If
            carregarJavaScript()
            SetNaoGravarCache()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
            Exit Sub
        End If
        Me.SalvaEstado()
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            Select Case CType(Request.QueryString("action"), String)
                Case "aprovacao"
                    AprovarFluxo()
                Case "reprovacao"
                    ReprovarFluxo()
            End Select
            Util.FecharPagina(Me.Page)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Try
            If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
                Exit Sub
            End If
            Util.FecharPagina(Me.Page)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#Region "Metodo Carga"

    Private Sub IniciarPagina()
        Try
            AtualizaTela()
            Util.AdicionaJsFocus(Me.Page, txtDESOBSAPV)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub carregarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        If WSCAcoesComerciais.FLGSITNGCDUP Then
            btnSalvar.Attributes.Add("OnClick", "return confirm('Existe neste fluxo acordos com descontos implantados no contas a pagar, deseja salvar assim mesmo?');")
        Else
            btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        End If
    End Sub

    Private Sub SetNaoGravarCache()
        Try
            Response.Cache.SetNoServerCaching()
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache)
            Response.Cache.SetNoStore()
            Response.Cache.SetExpires(New DateTime(1900, 1, 1, 0, 0, 0, 0))
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub AtualizaTela()
        Try
            If Not Request.QueryString("action") Is Nothing Then
                Select Case CType(Request.QueryString("action"), String)
                    Case "aprovacao"
                        lblObservacao.Text = "Observação para Aprovação"
                        btnSalvar.ToolTip = "Aprova o fluxo e grava observação"
                    Case "reprovacao"
                        lblObservacao.Text = "Observação para Rejeição"
                        btnSalvar.ToolTip = "Rejeita o fluxo e grava observação"
                End Select
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#Region "Metodos de controle"

    Private Sub RecuperaEstado()
    End Sub

    Private Sub SalvaEstado()
    End Sub

#End Region

#Region "Regra"

    Private Sub AprovarFluxo()
        Dim CODFNC As Decimal
        CODFNC = Controller.ObterFuncionarioLogadoSistema

        Dim NOMACSUSRSIS As String = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0).NOMACSUSRSIS.Trim
        'If WSCAcoesComerciais.FLGSITNGCDUP Then
        '    Util.AdicionaJsAlert(Me.Page, "Existe neste fluxo acordos com descontos implantados no contas a pagar", True)
        'End If
        Controller.AprovarFluxoCancelamentoAcordo(WSCAcoesComerciais.NUMPEDCNCACOCMC, CODFNC, WSCAcoesComerciais.CODFRN, txtDESOBSAPV.Text, NOMACSUSRSIS)
    End Sub

    Private Sub ReprovarFluxo()
        Dim CODFNC As Decimal
        CODFNC = Controller.ObterFuncionarioLogadoSistema
        Controller.ReprovarFluxoCancelamentoAcordo(WSCAcoesComerciais.NUMPEDCNCACOCMC, WSCAcoesComerciais.CODFRN, CODFNC, txtDESOBSAPV.Text)
    End Sub
#End Region

End Class