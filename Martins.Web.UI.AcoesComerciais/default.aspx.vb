Public Class _default
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

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
        WSCAcoesComerciais.checkSession = 1
        If Not Request.QueryString("pagina") Is Nothing Then
            Select Case CType(Request.QueryString("pagina"), String)
                Case "empenhoDoFornecedor"
                    Response.Write("<script language=""javascript"">window.parent.location=""EmpenhosDoFornecedor/EmpenhoFornecedor.aspx?NUMFLUAPV=" & Request.QueryString("NUMFLUAPV") & """;</script>")
            End Select
        End If

    End Sub

End Class
