Public Class ucCancelarPerdaAcordoRelacionamentoAtivo
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dGridRecebimentos As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents WebCurrencyEdit1 As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents WebCurrencyEdit2 As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton

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
        'Put user code to initialize the page here
    End Sub


    Public Function SalvarDadosDataSet() As Boolean
        Return True
    End Function

End Class
