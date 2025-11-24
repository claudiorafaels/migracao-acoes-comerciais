Public Class RelacaoProgramaIncentivoListar
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "
    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetIncentivo1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetIncentivo
        CType(Me.DatasetIncentivo1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetIncentivo1
        '
        Me.DatasetIncentivo1.DataSetName = "DatasetIncentivo"
        Me.DatasetIncentivo1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetIncentivo1, System.ComponentModel.ISupportInitialize).EndInit()

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
    Protected WithEvents DatasetIncentivo1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetIncentivo
    Protected WithEvents grdIncentivo As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents ucFornecedor As ucFornecedor
    Protected WithEvents ucPrograma As ucPrograma


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
            Response.Redirect("RelacaoProgramaIncentivoManter.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Try
            Dim CODPRGICT As Decimal = 0
            Dim CODFRN As Decimal = 0

            'PROGRAMA
            If cmbCriterio.SelectedValue = "1" Then
                CODPRGICT = ucPrograma.CodPrograma
                'FORNECEDOR
            ElseIf cmbCriterio.SelectedValue = "2" Then
                CODFRN = ucFornecedor.CodFornecedor
            End If

            CarregaGrid(CODPRGICT, CODFRN)
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
            ucPrograma.SelecionarVazio()
            ucFornecedor.SelecionarVazio()
            grdIncentivo.Rows.Clear()
            grdIncentivo.Visible = False
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub

    Private Sub grdIncentivo_ItemCommand1(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.UltraWebGridCommandEventArgs) Handles grdIncentivo.ItemCommand
        Try
            'Detalhes
            If e.InnerCommandEventArgs.CommandName.Equals("btnEditar") Then

                Dim CODPRGICT As Decimal
                Dim CODFRN As Decimal

                CODPRGICT = CType(CType(e.ParentControl, Infragistics.WebUI.UltraWebGrid.CellItem).Cell.Row.Cells.FromKey("PROGRAMA").Value, Decimal)
                CODFRN = CType(CType(e.ParentControl, Infragistics.WebUI.UltraWebGrid.CellItem).Cell.Row.Cells.FromKey("CODIGO").Value, Decimal)

                'Redireciona para página meio
                Response.Redirect("RelacaoProgramaIncentivoManter.aspx?CODPRGICT=" & CODPRGICT.ToString & "&CODFRN=" & CODFRN.ToString)

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
        grdIncentivo.Visible = False
        Dim CODPRGICT As Decimal = 0
        Dim CODFRN As Decimal = 0
        If (Not Request.QueryString("CODPRGICT") Is Nothing) And (Not Request.QueryString("CODFRN") Is Nothing) Then
            CODPRGICT = CType(Request.QueryString("CODPRGICT"), Decimal)
            CODFRN = CType(Request.QueryString("CODFRN"), Decimal)
            CarregaGrid(CODPRGICT, CODFRN)
        End If
    End Sub

    Private Sub carregarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        btnPesquisar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
    End Sub

    Public Sub CarregaGrid(ByVal CODPRGICT As Decimal, ByVal CODFRN As Decimal)

        Me.DatasetIncentivo1 = Controller.ObterRelacaoIncentivoFornecedorPesquisa(CODPRGICT, CODFRN)

        If Me.DatasetIncentivo1.RLCPRGICTFRNPesquisa.Rows.Count > 0 Then
            grdIncentivo.DataBind()
            grdIncentivo.Visible = True
        Else
            grdIncentivo.Rows.Clear()
            grdIncentivo.Visible = False
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