Imports Martins.Security.Helper
Public Class topo
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblUsuario As System.Web.UI.WebControls.Label
    Protected WithEvents LblVersao As System.Web.UI.WebControls.Label

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
        Try
            Dim ticketData As SecurityCache.TicketData
            ticketData = SecurityCache.ObterTicketDoSite()
            lblUsuario.Text = ticketData.NomeUsuario
            WSCAcoesComerciais.StringValue(WSCVar.Usuario) = ticketData.NomeUsuario

            If WSCAcoesComerciais.dsUsuarioCompra Is Nothing Then
                WSCAcoesComerciais.dsUsuarioCompra = Controller.ObterUsuariosCompraLogadoSistema()
            End If

        Catch ex As Exception
            'Controller.TrataErro(Me.Page, ex)
        End Try
        Try
            Me.LblVersao.Text = "V." & System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString
        Catch ex As Exception
        End Try
    End Sub
End Class
