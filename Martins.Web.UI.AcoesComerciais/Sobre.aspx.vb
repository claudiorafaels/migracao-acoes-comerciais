Imports System.Reflection

Public Class Sobre
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents grdRegioes As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents grdInformacoes As Infragistics.WebUI.UltraWebGrid.UltraWebGrid

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
        Dim dtInformacoes As DataTable

        dtInformacoes = ObterInformacoes()
        AtualizarInformacoes(dtInformacoes)
    End Sub

    Private Function ObterInformacoes() As DataTable
        Dim assemblyInfo As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim titulo As System.Reflection.AssemblyTitleAttribute
        Dim descricao As System.Reflection.AssemblyDescriptionAttribute
        Dim empresa As System.Reflection.AssemblyCompanyAttribute
        Dim produto As System.Reflection.AssemblyProductAttribute
        Dim copyright As System.Reflection.AssemblyCopyrightAttribute
        Dim dtInformacoes As New DataTable
        Dim drInfo As DataRow

        dtInformacoes.Columns.Add("Informacao", System.Type.GetType("System.String"))
        dtInformacoes.Columns.Add("Valor", System.Type.GetType("System.String"))

        'AssemblyTitle
        titulo = CType(AssemblyTitleAttribute.GetCustomAttribute(assemblyInfo, GetType(System.Reflection.AssemblyTitleAttribute)), System.Reflection.AssemblyTitleAttribute)
        drInfo = dtInformacoes.NewRow()
        drInfo("Informacao") = "Título"
        drInfo("Valor") = titulo.Title
        dtInformacoes.Rows.Add(drInfo)

        'AssemblyDescription
        descricao = CType(AssemblyDescriptionAttribute.GetCustomAttribute(assemblyInfo, GetType(System.Reflection.AssemblyDescriptionAttribute)), System.Reflection.AssemblyDescriptionAttribute)
        drInfo = dtInformacoes.NewRow()
        drInfo("Informacao") = "Descrição"
        drInfo("Valor") = descricao.Description
        dtInformacoes.Rows.Add(drInfo)

        'AssemblyCompany
        empresa = CType(AssemblyCompanyAttribute.GetCustomAttribute(assemblyInfo, GetType(System.Reflection.AssemblyCompanyAttribute)), System.Reflection.AssemblyCompanyAttribute)
        drInfo = dtInformacoes.NewRow()
        drInfo("Informacao") = "Departamento"
        drInfo("Valor") = empresa.Company
        dtInformacoes.Rows.Add(drInfo)

        'AssemblyProduct
        produto = CType(AssemblyProductAttribute.GetCustomAttribute(assemblyInfo, GetType(System.Reflection.AssemblyProductAttribute)), System.Reflection.AssemblyProductAttribute)
        drInfo = dtInformacoes.NewRow()
        drInfo("Informacao") = "Produto"
        drInfo("Valor") = produto.Product
        dtInformacoes.Rows.Add(drInfo)

        'AssemblyCopyright
        copyright = CType(AssemblyCopyrightAttribute.GetCustomAttribute(assemblyInfo, GetType(System.Reflection.AssemblyCopyrightAttribute)), System.Reflection.AssemblyCopyrightAttribute)
        drInfo = dtInformacoes.NewRow()
        drInfo("Informacao") = "Copyright"
        drInfo("Valor") = copyright.Copyright
        dtInformacoes.Rows.Add(drInfo)

        'AssemblyVersion 
        drInfo = dtInformacoes.NewRow()
        drInfo("Informacao") = "Versão"
        drInfo("Valor") = assemblyInfo.GetName.Version.ToString
        dtInformacoes.Rows.Add(drInfo)

        'Sessões ativas
        drInfo = dtInformacoes.NewRow()
        drInfo("Informacao") = "Sessões ativas"
        drInfo("Valor") = Application("ActiveUsers")
        dtInformacoes.Rows.Add(drInfo)

        'Servidor
        drInfo = dtInformacoes.NewRow()
        drInfo("Informacao") = "Servidor"
        drInfo("Valor") = HttpContext.Current.Server.MachineName
        dtInformacoes.Rows.Add(drInfo)

        Return dtInformacoes

    End Function

    Private Sub AtualizarInformacoes(ByVal dtInformacoes As DataTable)
        ' Atualiza o grid
        grdInformacoes.DataSource = dtInformacoes
        grdInformacoes.DataBind()

        ' Formata o grid
        With grdInformacoes.DisplayLayout
            'Coluna Informações
            .Bands(0).Columns(0).Header.Caption = "Informações"
            .Bands(0).Columns(0).Width = New System.Web.UI.WebControls.Unit(250, UnitType.Pixel)

            'Coluna Valor
            .Bands(0).Columns(1).Header.Caption = "Valor"
            .Bands(0).Columns(1).Width = New System.Web.UI.WebControls.Unit(348, UnitType.Pixel)
        End With
    End Sub

End Class
