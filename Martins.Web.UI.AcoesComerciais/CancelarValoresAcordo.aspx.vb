Public Class CancelarValoresAcordo
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents UltraWebGrid1 As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents UltraWebGrid2 As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents btnImprimir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnVisualizar As System.Web.UI.WebControls.LinkButton

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "Propriedades"

    Private Property flagProcessando() As Boolean

        Get
            Dim result As Boolean = False
            If Not viewstate("flagProcessando") Is Nothing Then
                result = CType(viewstate("flagProcessando"), Boolean)
            End If
            Return result
        End Get

        Set(ByVal Value As Boolean)
            viewstate("flagProcessando") = Value
        End Set

    End Property

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("Principal.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub
    Private Function Validar() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = String.Empty

        Try
            Validar = True


            If mensagemErro.Trim() <> String.Empty Then
                Page.RegisterStartupScript("Alerta", "<script>alert('" & (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1) & "');</script>")
                Return False
            End If

            lblErro.Visible = False
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            If Validar() = False Then
                Exit Sub
            End If

            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = True

            ImprimirCancelarValores()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            If Validar() = False Then
                Exit Sub
            End If

            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = False

            ImprimirCancelarValores()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#Region "relatório"
    Private Sub ImprimirCancelarValores()
        ' Obter dados do relatório e guardar na seção
        WSCAcoesComerciais.dsRelatorioAcordoAcoesComerciais = Controller.ObterRelatorioAcordoAcoesComerciais_194(0, CInt("0"), CInt("0"))
        ' Guarda o nome do relatório na seção
        WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "CBY002AE.rpt"

        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub
#End Region

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click

    End Sub
End Class
