Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class VisualizaRelatorio
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents crvVisualizadorRelatorio As CrystalDecisions.Web.CrystalReportViewer
    Protected WithEvents CrystalReportViewer1 As CrystalDecisions.Web.CrystalReportViewer


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
        'Inicializa o objeto fortemente tipado do Relatorio
        Dim crReportDocument As New ReportDocument
        crReportDocument.Load(Server.MapPath(String.Concat("Relatorios/", WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio))))

        Me.VisualizaRelatorios(crReportDocument)

        'O reportsource do viewer deve ser setado antes de acessar
        ' qualquer parâmetro
        crvVisualizadorRelatorio.ReportSource = crReportDocument
    End Sub

    Private Sub VisualizaRelatorios(ByRef crRD As ReportDocument)
        Select Case WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio)
            Case "cby002za.rpt"
                crRD.SetDataSource(WSCAcoesComerciais.dsRelatorioAcordoFornecimento.tbAcordoFornecimento_022)
        End Select
    End Sub
End Class
