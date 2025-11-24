Public Class ContratoListar
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "
    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblFrame As System.Web.UI.WebControls.Label
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnInserir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents cmbCriterio As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodigo As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents Espera As System.Web.UI.WebControls.Image
    Protected WithEvents Div1 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow

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
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        If (Not IsPostBack) Then
            RestaurarCriteriosDePesquisa(sender, e)
        End If
        btnPesquisar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
    End Sub

    Private Sub btnInserir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInserir.Click
        Controller.NavegarInserirContrato()
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Try
            'Verifica o critério
            If cmbCriterio.SelectedValue.Equals("1") Then '1 Código
                If Not txtCodigo.ValueInt > 0 Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Código do contrato não informado.');</script>")
                    Exit Try
                End If
                lblFrame.Text = "<iframe src='" & "ContratoListarGrid.aspx?criterio=" & cmbCriterio.SelectedItem.Value & "&CODCTT=" & txtCodigo.Text & "' height=100% width=100% frameborder=0 ALLOWTRANSPARENCY scrolling=yes></iframe>"
            ElseIf cmbCriterio.SelectedValue.Equals("2") Then '2 Fornecedor
                If ucFornecedor.CodFornecedor <= 0 Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Fornecedor não informado.');</script>")
                    Exit Try
                End If
                lblFrame.Text = "<iframe src='" & "ContratoListarGrid.aspx?criterio=" & cmbCriterio.SelectedItem.Value & "&CODFRN=" & ucFornecedor.CodFornecedor.ToString() & "' height=100% width=100% frameborder=0 ALLOWTRANSPARENCY scrolling=yes></iframe>"
            End If
            GravarCriteriosDePesquisa(lblFrame.Text)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmbCriterio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCriterio.SelectedIndexChanged

        txtCodigo.AutoPostBack = False
        txtCodigo.Visible = False
        ucFornecedor.Visible = False

        'Limpa
        txtCodigo.Text = String.Empty

        If cmbCriterio.SelectedValue.Equals("1") Then '1 Código
            txtCodigo.Visible = True
        ElseIf cmbCriterio.SelectedValue.Equals("2") Then '2 Fornecedor
            ucFornecedor.Visible = True
        End If
        'tdEspera.Visible = False
    End Sub

    Private Sub GravarCriteriosDePesquisa(ByVal urlFrame As String)
        Dim criterios As New Collection
        With criterios
            .Add(urlFrame, "urlFrame")
            .Add(cmbCriterio.SelectedValue, cmbCriterio.ID)
            .Add(txtCodigo.Text, txtCodigo.ID)
            .Add(ucFornecedor.CodFornecedor, ucFornecedor.ID)
        End With
        Session("ContratoListar") = criterios
    End Sub

    Private Sub RestaurarCriteriosDePesquisa(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim criterios As Collection

        If Not Session("ContratoListar") Is Nothing Then
            criterios = CType(Session("ContratoListar"), Collection)

            lblFrame.Text = CType(criterios.Item("urlFrame"), String)

            cmbCriterio.SelectedValue = CType(criterios.Item(cmbCriterio.ID), String)
            cmbCriterio_SelectedIndexChanged(sender, e)

            If IsNumeric(criterios.Item(txtCodigo.ID)) Then
                txtCodigo.ValueDecimal = Convert.ToDecimal(criterios.Item(txtCodigo.ID))
            End If
            If IsNumeric(criterios.Item(ucFornecedor.ID)) Then
                ucFornecedor.SelecionarFornecedor(CType(criterios.Item(ucFornecedor.ID), Decimal))
            End If
        End If
    End Sub
End Class