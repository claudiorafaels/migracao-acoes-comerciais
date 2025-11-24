Public Class RelacaoUsuarioCelulaListar
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
    Protected WithEvents cmbUsuario As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Espera As System.Web.UI.WebControls.Image
    Protected WithEvents tdEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Div1 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents cmbCelula As System.Web.UI.WebControls.DropDownList
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
        Controller.NavegarInserirRelacaoUsuarioCelula()
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Try
            If cmbCriterio.SelectedValue.Equals("1") Then
                If cmbCelula.SelectedIndex > 0 Then
                    lblFrame.Text = "<iframe src='RelacaoUsuarioCelulaListarGrid.aspx?criterio=" & cmbCriterio.SelectedItem.Value & "&cod=" & cmbCelula.SelectedValue & "'height=100% width=100% frameborder=0 ALLOWTRANSPARENCY scrolling=yes></iframe>"
                Else
                    Util.AdicionaJsAlert(Me.Page, "Por favor escolha um Tipo de Transferência!")
                    Util.AdicionaJsFocus(Me.Page, CType(cmbCelula, WebControl))

                End If
            ElseIf cmbCriterio.SelectedValue.Equals("2") Then
                If cmbUsuario.SelectedIndex > 0 Then
                    lblFrame.Text = "<iframe src='" & "RelacaoUsuarioCelulaListarGrid.aspx?criterio=" & cmbCriterio.SelectedItem.Value & "&cod=" & cmbUsuario.SelectedValue & "'height=100% width=100% frameborder=0 ALLOWTRANSPARENCY scrolling=yes></iframe>"
                Else
                    Util.AdicionaJsAlert(Me.Page, "Por favor escolha um Usuário!")
                    Util.AdicionaJsFocus(Me.Page, CType(cmbUsuario, WebControl))
                End If

            End If
            GravarCriteriosDePesquisa(lblFrame.Text)
            'tdEspera.Visible = True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmbCriterio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCriterio.SelectedIndexChanged

        cmbUsuario.Visible = False
        cmbCelula.Visible = False

        If cmbCriterio.SelectedValue.Equals("1") Then
            cmbCelula.Visible = True
            Me.CarregaCelula()
        ElseIf cmbCriterio.SelectedValue.Equals("2") Then
            cmbUsuario.Visible = True
            Me.CarregaUsuarios()
        End If

    End Sub

    Private Sub CarregaUsuarios()
        With cmbUsuario
            If .Items.Count <= 1 Then
                .Items.Clear()
                .DataSource = Controller.ObterUsuariosoCompra(0, 0, String.Empty).T0113471.Select(String.Empty, "NOMACSUSRSIS ASC")
                .DataTextField = "NOMACSUSRSIS"
                .DataValueField = "NOMACSUSRSIS"
                .DataBind()
                .Items.Insert(0, New ListItem(String.Empty, String.Empty))
            End If
        End With
    End Sub

    Private Sub CarregaCelula()
        Dim ds As wsAcoesComerciais.DatasetCelula = _
        Controller.ObterCelulas(Decimal.Zero, Decimal.Zero, Decimal.Zero, String.Empty)
        Util.carregarCmbCelula(ds, cmbCelula, New ListItem(String.Empty, String.Empty))
    End Sub
    Private Sub GravarCriteriosDePesquisa(ByVal urlFrame As String)
        Dim criterios As New Collection
        With criterios
            .Add(urlFrame, "urlFrame")
            .Add(cmbCriterio.SelectedValue, "cmbCriterio")
            .Add(cmbUsuario.SelectedValue, "cmbUsuario")
            .Add(cmbCelula.SelectedValue, "cmbCelula")

        End With
        Session("RelacaoUsuarioCelulaListar") = criterios
    End Sub

    Private Sub RestaurarCriteriosDePesquisa(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim criterios As Collection

        If Not Session("RelacaoUsuarioCelulaListar") Is Nothing Then
            Try
                criterios = CType(Session("RelacaoUsuarioCelulaListar"), Collection)

                lblFrame.Text = CType(criterios.Item("urlFrame"), String)

                cmbCriterio.SelectedValue = CType(criterios.Item("cmbCriterio"), String)
                cmbCriterio_SelectedIndexChanged(sender, e)

                cmbUsuario.SelectedValue = CType(criterios.Item("cmbUsuario"), String)
                cmbCelula.SelectedValue = CType(criterios.Item("cmbCelula"), String)

                'tdEspera.Visible = True
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class