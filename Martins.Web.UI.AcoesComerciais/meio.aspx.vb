Public Class meio
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
        If WSCAcoesComerciais.queryString = String.Empty Then
            'Me.Response.Redirect("Acordo.aspx")

            'Me.Page.Parent.Page.Response.Redirect("Acordo.aspx")
            'Response.Write("<script language=javascript>" & vbCrLf)
            'Response.Write("window.parent.location.href = ""Acordo.aspx?TipUndPgtCttFrn=0" & """;" & vbCrLf)
            'Response.Write("</script>" & vbCrLf)

            'Response.Write("<script language=""javascript"">window.parent.location=""EmpenhosDoFornecedor/EmpenhoFornecedor.aspx" & WSCAcoesComerciais.queryString & """;</script>")

            'Response.Write("<script language=""javascript"">window.open(""EmpenhosDoFornecedor/EmpenhoFornecedor.aspx"");</script>")
        End If
    End Sub

End Class
