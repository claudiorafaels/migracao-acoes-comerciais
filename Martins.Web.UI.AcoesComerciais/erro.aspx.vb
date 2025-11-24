Public Class Erro
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label

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
        'If Not Request.QueryString("action") Is Nothing Then
        If CType(Request.QueryString("action"), String) = "sessaoexpirada" Then
            Dim fixFrames As String
            fixFrames = "<script language=javascript >alert('Sua sessão expirou');window.parent.parent.document.location.href = 'RedirecionaPaginaInicial.aspx?pagina=Pesquisa'; window.parent.parent.document.location.reload()</script>"
            HttpContext.Current.Response.Write(fixFrames)
        End If
        'End If
        Label1.Text = CStr(Session("Erro"))
    End Sub

End Class
