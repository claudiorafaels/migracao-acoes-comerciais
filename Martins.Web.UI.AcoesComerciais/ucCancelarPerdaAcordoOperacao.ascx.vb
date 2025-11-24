Public Class ucCancelarPerdaAcordoOperacao
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents webTab As Infragistics.WebUI.UltraWebTab.UltraWebTab
    Protected WithEvents ucCancelarPerdaAcordoOperacaoContrato As System.Web.UI.UserControl
    Protected WithEvents ucCancelarPerdaAcordoOperacaoAcordo As System.Web.UI.UserControl
    Protected WithEvents WebCurrencyEdit2 As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents WebCurrencyEdit1 As Infragistics.WebUI.WebDataInput.WebCurrencyEdit

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region " Propriedades "

    Private UsrCtrls As UserControl()

#End Region

#Region " Eventos "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.UsrCtrls = New UserControl() {ucCancelarPerdaAcordoOperacaoContrato, ucCancelarPerdaAcordoOperacaoAcordo}

            If (Not IsPostBack) Then
                Me.InicializaPagina()
            Else
                'Me.RecuperaEstado()
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
    End Sub

    Private Sub webTab_TabClick(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.UltraWebTab.WebTabEvent) Handles webTab.TabClick

        For Each ctrl As UserControl In Me.UsrCtrls
            ctrl.Visible = False
        Next

        If webTab.SelectedTab = 0 Then
            ucCancelarPerdaAcordoOperacaoContrato.Visible = True
        ElseIf webTab.SelectedTab = 1 Then
            ucCancelarPerdaAcordoOperacaoAcordo.Visible = True
        End If

    End Sub

#End Region

#Region " Metodos "

    Private Sub InicializaPagina()
    End Sub

    Private Sub ConfiguraTabKeys()
    End Sub

#End Region

End Class