Public Class RelacionamentoTransferenciaVerbaListar
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
    Protected WithEvents cmbCelula As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents Espera As System.Web.UI.WebControls.Image
    Protected WithEvents tdEspera As System.Web.UI.HtmlControls.HtmlTableRow
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
        If Not Me.Page.IsPostBack Then
            cmbCriterio_SelectedIndexChanged(Nothing, Nothing)
            'tdEspera.Visible = False
            RestaurarCriteriosDePesquisa(sender, e)
        End If

        btnPesquisar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
    End Sub

    Private Sub btnInserir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInserir.Click
        Controller.NavegarInserirRelacionamentoTransferenciaVerba()
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Try
            If cmbCriterio.SelectedValue.Equals("2") Then
                If ucFornecedor.CodFornecedor > 0 Then
                    lblFrame.Text = "<iframe src='" & "RelacionamentoTransferenciaVerbaListarGrid.aspx?criterio=" & cmbCriterio.SelectedItem.Value & "&cod=" & ucFornecedor.CodFornecedor.ToString() & "'height=100% width=100% frameborder=0 ALLOWTRANSPARENCY scrolling=yes></iframe>"
                Else
                    Util.AdicionaJsAlert(Me.Page, "Por favor escolha um Fornecedor!")
                    Util.AdicionaJsFocus(Me.Page, CType(ucFornecedor.FindControl("txtCodigo"), WebControl))
                End If
            ElseIf cmbCriterio.SelectedValue.Equals("1") Then
                If cmbCelula.SelectedIndex > 0 Then
                    lblFrame.Text = "<iframe src='RelacionamentoTransferenciaVerbaListarGrid.aspx?criterio=" & cmbCriterio.SelectedItem.Value & "&cod=" & cmbCelula.SelectedValue & "'height=100% width=100% frameborder=0 ALLOWTRANSPARENCY scrolling=yes></iframe>"
                Else
                    Util.AdicionaJsAlert(Me.Page, "Por favor escolha uma Célula!")
                    Util.AdicionaJsFocus(Me.Page, CType(cmbCelula, WebControl))
                End If

            End If
            GravarCriteriosDePesquisa(lblFrame.Text)
            'tdEspera.Visible = True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmbCriterio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCriterio.SelectedIndexChanged

        cmbCelula.Visible = False
        ucFornecedor.Visible = False

        If cmbCriterio.SelectedValue.Equals("2") Then
            ucFornecedor.Visible = True
        ElseIf cmbCriterio.SelectedValue.Equals("1") Then
            cmbCelula.Visible = True
            Me.CarregaCelulas()
        End If

    End Sub

    Private Sub CarregaCelulas()
        With cmbCelula
            If .Items.Count <= 1 Then
                Util.carregarCmbCelula(Controller.ObterCelulas(0, 0, 0, String.Empty), cmbCelula, New ListItem(String.Empty, String.Empty))
            End If
        End With
    End Sub

    Private Sub GravarCriteriosDePesquisa(ByVal urlFrame As String)
        Dim criterios As New Collection
        With criterios
            .Add(urlFrame, "urlFrame")
            .Add(cmbCriterio.SelectedValue, "cmbCriterio")
            .Add(cmbCelula.SelectedValue, "cmbCelula")
            .Add(ucFornecedor.CodFornecedor, "ucFornecedor")

        End With
        Session("RelacionamentoTransferenciaVerbaListar") = criterios
    End Sub

    Private Sub RestaurarCriteriosDePesquisa(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim criterios As Collection

        If Not Session("RelacionamentoTransferenciaVerbaListar") Is Nothing Then
            Try
                criterios = CType(Session("RelacionamentoTransferenciaVerbaListar"), Collection)

                lblFrame.Text = CType(criterios.Item("urlFrame"), String)

                cmbCriterio.SelectedValue = CType(criterios.Item("cmbCriterio"), String)
                cmbCriterio_SelectedIndexChanged(sender, e)

                cmbCelula.SelectedValue = CType(criterios.Item("cmbCelula"), String)
                ucFornecedor.CodFornecedor = CType(criterios.Item("ucFornecedor"), Decimal)
                'tdEspera.Visible = True
            Catch ex As Exception
            End Try
        End If
    End Sub

End Class