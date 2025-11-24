Public Class RelacaoEmpenhoTipoPedidoCompraListar
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "
    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblFrame As System.Web.UI.WebControls.Label
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents txtDataInicial As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtDataFinal As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents cmbCriterio As System.Web.UI.WebControls.DropDownList
    Protected WithEvents LblA As System.Web.UI.WebControls.Label
    Protected WithEvents cmbNomeFornecedor As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnBuscarFornecedor As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LblFornecedor As System.Web.UI.WebControls.Label
    Protected WithEvents CmbEmpenho As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmbTipoPedidoCompra As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Espera As System.Web.UI.WebControls.Image
    Protected WithEvents tdEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Div1 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnInserir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable


    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnPesquisar.Attributes.Add("OnClick", "javascript:mostraAndamento()")

        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            'Carrega as Empenhos
            Util.carregarCmbEmpenho(Controller.ObterEmpenhos(String.Empty, String.Empty, String.Empty, 0, String.Empty), CmbEmpenho, Nothing)
            'Carrega combo tipo pedido compra
            With cmbTipoPedidoCompra
                .DataSource = Controller.ObterTiposPedidoCompra(String.Empty)
                .DataMember = "T0104499"
                .DataTextField = "DESTIPPEDCMP"
                .DataValueField = "TIPPEDCMP"
                .DataBind()
            End With
            'tdEspera.Visible = False
            RestaurarCriteriosDePesquisa(sender, e)
        End If
    End Sub

    Private Sub btnInserir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInserir.Click
        Controller.NavegarInserirRelacaoEmpenhoTipoPedidoCompra()
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Try
            'Verifica o critério
            If Me.cmbCriterio.SelectedValue = "0" Then  'Nenhum critério, busca todos registros
                lblFrame.Text = "<iframe src='" & "RelacaoEmpenhoTipoPedidoCompraListarGrid.aspx?criterio=" & cmbCriterio.SelectedItem.Value & "' height=100% width=100% frameborder=0 ALLOWTRANSPARENCY scrolling=yes></iframe>"
            ElseIf Me.cmbCriterio.SelectedValue = "1" Then  'Consulta por EMPENHO
                lblFrame.Text = "<iframe src='" & "RelacaoEmpenhoTipoPedidoCompraListarGrid.aspx?criterio=" & cmbCriterio.SelectedItem.Value & "&TIPDSNDSCBNF=" & CmbEmpenho.SelectedValue & "' height=100% width=100% frameborder=0 ALLOWTRANSPARENCY scrolling=yes></iframe>"
            ElseIf cmbCriterio.SelectedValue = "2" Then 'Consulta por TIPO PEDIDO COMPRA
                lblFrame.Text = "<iframe src='" & "RelacaoEmpenhoTipoPedidoCompraListarGrid.aspx?criterio=" & cmbCriterio.SelectedItem.Value & "&TIPPEDCMP=" & cmbTipoPedidoCompra.SelectedValue & "' height=100% width=100% frameborder=0 ALLOWTRANSPARENCY scrolling=yes></iframe>"
            End If
            GravarCriteriosDePesquisa(lblFrame.Text)
            'tdEspera.Visible = True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmbCriterio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCriterio.SelectedIndexChanged

        CmbEmpenho.Visible = False
        cmbTipoPedidoCompra.Visible = False

        If cmbCriterio.SelectedValue = "1" Then
            CmbEmpenho.Visible = True
        ElseIf cmbCriterio.SelectedValue = "2" Then
            cmbTipoPedidoCompra.Visible = True
        End If

    End Sub
    Private Sub GravarCriteriosDePesquisa(ByVal urlFrame As String)
        Dim criterios As New Collection
        With criterios
            .Add(urlFrame, "urlFrame")
            .Add(cmbCriterio.SelectedValue, "cmbCriterio")
            .Add(CmbEmpenho.SelectedValue, "CmbEmpenho")
            .Add(cmbTipoPedidoCompra.SelectedValue, "cmbTipoPedidoCompra")

        End With
        Session("RelacaoEmpenhoTipoPedidoCompraListar") = criterios
    End Sub

    Private Sub RestaurarCriteriosDePesquisa(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim criterios As Collection

        If Not Session("RelacaoEmpenhoTipoPedidoCompraListar") Is Nothing Then
            Try
                criterios = CType(Session("RelacaoEmpenhoTipoPedidoCompraListar"), Collection)

                lblFrame.Text = CType(criterios.Item("urlFrame"), String)

                cmbCriterio.SelectedValue = CType(criterios.Item("cmbCriterio"), String)
                cmbCriterio_SelectedIndexChanged(sender, e)

                CmbEmpenho.SelectedValue = CType(criterios.Item("CmbEmpenho"), String)
                cmbTipoPedidoCompra.SelectedValue = CType(criterios.Item(" cmbTipoPedidoCompra"), String)

                'tdEspera.Visible = True
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class