Public Class GeraisListar
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
    Protected WithEvents cmbFilial As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Espera As System.Web.UI.WebControls.Image
    Protected WithEvents Div1 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents s As System.Web.UI.HtmlControls.HtmlTable
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
        End If
        If Not IsPostBack Then
            'Carrega as filiais
            With cmbFilial
                .DataSource = Controller.ObterFiliaisExpedicao(1)
                .DataMember = "T0112963"
                .DataTextField = "NomFilEmp"
                .DataValueField = "CodFilEmp"
                .DataBind()
            End With
            If (Not IsPostBack) Then
                RestaurarCriteriosDePesquisa(sender, e)
            End If
        End If
    End Sub

    Private Sub btnInserir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInserir.Click
        Controller.NavegarInserirGerais()
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Try
            'Verifica o critério
            If Me.cmbCriterio.SelectedValue = "1" Then  'Consulta por CÓDIGO DA FILIAL
                lblFrame.Text = "<iframe src='" & "GeraisListarGrid.aspx?criterio=" & cmbCriterio.SelectedItem.Value & "&CodFilEmp=" & cmbFilial.SelectedValue & "' height=100% width=100% frameborder=0 ALLOWTRANSPARENCY scrolling=yes></iframe>"
            ElseIf cmbCriterio.SelectedValue = "2" Then 'Consulta Todos registros (sem filtro)
                lblFrame.Text = "<iframe src='" & "GeraisListarGrid.aspx?criterio=" & cmbCriterio.SelectedItem.Value & "' height=100% width=100% frameborder=0 ALLOWTRANSPARENCY scrolling=yes></iframe>"
            End If

            GravarCriteriosDePesquisa(lblFrame.Text)

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmbCriterio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCriterio.SelectedIndexChanged

        cmbFilial.Visible = False

        If cmbCriterio.SelectedValue = "1" Then
            cmbFilial.Visible = True
        ElseIf cmbCriterio.SelectedValue = "2" Then
        End If

    End Sub
    Private Sub GravarCriteriosDePesquisa(ByVal urlFrame As String)
        Dim criterios As New Collection
        With criterios
            .Add(urlFrame, "urlFrame")
            .Add(cmbCriterio.SelectedValue, "cmbCriterio")
            .Add(cmbFilial.SelectedValue, "cmbFilial")

        End With
        Session("GeraisListar") = criterios
    End Sub

    Private Sub RestaurarCriteriosDePesquisa(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim criterios As Collection

        If Not Session("GeraisListar") Is Nothing Then
            Try
                criterios = CType(Session("GeraisListar"), Collection)

                lblFrame.Text = CType(criterios.Item("urlFrame"), String)
                cmbCriterio.SelectedValue = CType(criterios.Item("cmbCriterio"), String)
                cmbCriterio_SelectedIndexChanged(sender, e)
                cmbFilial.SelectedValue = CType(criterios.Item("cmbFilial"), String)

            Catch ex As Exception
            End Try
        End If
    End Sub

End Class