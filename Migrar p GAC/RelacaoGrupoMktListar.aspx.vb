Imports System.IO.File
Imports System.IO.StreamReader
Imports System.Data
Imports System.Data.OleDb
Imports Martins.Security.Helper

Public Class RelacaoGrupoMktListar
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "
    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Div1 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnImportar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Plan As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents TRTipoGrupoMkt As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents TRCodigoGrupoEconomico As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents TRChkGrupoEconomico As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents UcGrupoMarketing As ucGrupoMarketing
    Protected WithEvents ucGrupoEconomico As ucGrupoEconomico
    Protected WithEvents chkGrupoEconomicoSemGrupoMkt As System.Web.UI.WebControls.CheckBox


    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "Eventos"
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If IsPostBack Then
                Me.RecuperaEstado()
            Else
                Me.IniciarPagina()
            End If
            carregarJavaScript()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Try
            CarregaDadosPesquisa()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub


    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        Try
            CarregaDadosPlanilha()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#Region "Métodos de Carga"

    Private Sub IniciarPagina()
        If Not Request.QueryString("erro") Is Nothing Then
            Dim erroArray() As String = Request.QueryString("erro").ToString.Split(CType("|", Char))
            Dim mensagem As String = String.Empty
            For ix As Integer = 0 To erroArray.Length - 1
                If mensagem = String.Empty Then
                    mensagem = erroArray(ix) & vbCrLf
                Else
                    mensagem &= erroArray(ix) & vbCrLf
                End If
            Next
            Util.AdicionaJsAlert(Me.Page, mensagem, True)
        End If
    End Sub

    Private Sub carregarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        btnPesquisar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        btnImportar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
    End Sub

    Public Sub CarregaDadosPlanilha()
        If ValidaPlanilha() Then
            Dim dsPlanilha As New DataSet
            Dim nomePlanilha As String
            nomePlanilha = SalvaPlanilhaServidor()

            Dim strConn As String = "Provider=Microsoft.Jet.OleDb.4.0;" _
                          & "data source=" & Server.MapPath("~/Upload/") & nomePlanilha _
                          & "; Extended Properties=Excel 8.0;"

            Dim objConn As New OleDbConnection(strConn)

            Dim strSql As String = "Select * from " & "[Plan1$]"

            Dim objCmd As New OleDbCommand(strSql, objConn)

            Try
                objConn.Open()
                Dim tableAdapter As New OleDbDataAdapter(objCmd.CommandText, objConn)
                tableAdapter.Fill(dsPlanilha)
                WSCAcoesComerciais.dsPlanilha = dsPlanilha
                Response.Redirect("RelacaoGrupoMktManter.aspx")
            Catch ex As Exception
                Controller.TrataErro(Me.Page, ex)
            Finally
                objConn.Dispose()
                If System.IO.File.Exists(Server.MapPath("~/Upload/") & nomePlanilha) Then
                    System.IO.File.Delete(Server.MapPath("~/Upload/") & nomePlanilha)
                End If
            End Try

        End If
    End Sub

    Private Sub CarregaDadosPesquisa()
        Dim dsPesquisa As wsAcoesComerciais.DatasetTipoGrupoMarketing
        Dim TIPGRPMKTFRN As Decimal
        Dim CODGRPFRN As Decimal
        Dim PERGRPMKTFRN As Decimal

        TIPGRPMKTFRN = UcGrupoMarketing.CodGrupoMarketing
        CODGRPFRN = ucGrupoEconomico.CodGrupoEconomico

        If chkGrupoEconomicoSemGrupoMkt.Checked Then
            PERGRPMKTFRN = 1
        Else
            PERGRPMKTFRN = 0
        End If
        dsPesquisa = Controller.ObterRelacaoGrupoMarketingPesquisa(TIPGRPMKTFRN, CODGRPFRN, PERGRPMKTFRN)

        If dsPesquisa.RLCGRPECOGRPMKTFRNPesquisaPai.Rows.Count > 0 Then
            WSCAcoesComerciais.dsTipoGrupoMarketing = dsPesquisa
            Response.Redirect("RelacaoGrupoMktManter.aspx")
        Else
            Util.AdicionaJsAlert(Me.Page, "Registro(s) não encontrado(s)!", True)
        End If

    End Sub

    Public Function SalvaPlanilhaServidor() As String
        Dim ArquivoInfo As System.io.FileInfo
        Dim NomeArquivo As String    ' Nome do Arquivo
        Dim CaminhoArquivo As String ' Caminho do arquivo no servidor
        Dim Extensao As String = ".xls"

        Dim ticketData As SecurityCache.TicketData
        ticketData = SecurityCache.ObterTicketDoSite()

        ArquivoInfo = New System.IO.FileInfo(Plan.PostedFile.FileName)

        NomeArquivo = ticketData.NomeUsuario.Replace(" ", "").Trim()

        NomeArquivo = Util.TiraAcentuacao(NomeArquivo).ToUpper

        Plan.PostedFile.SaveAs(Server.MapPath("~/Upload/") & NomeArquivo & Extensao)

        Return NomeArquivo & Extensao
    End Function
#End Region

#Region "Métodos de Controle"
    Private Sub RecuperaEstado()
        'Me.DatasetRelacaoMercadoriaEPortariaBeneficioProdutoInformatica1 = WebSession.dsRelacaoMercadoriaEPortariaBeneficioProdutoInformatica
    End Sub

    Private Sub SalvaEstado()
        'WebSession.dsRelacaoMercadoriaEPortariaBeneficioProdutoInformatica = Me.DatasetRelacaoMercadoriaEPortariaBeneficioProdutoInformatica1
    End Sub
#End Region

#Region "Métodos de Regra"

    Public Function ValidaPlanilha() As Boolean
        Dim ArquivoInfo As System.io.FileInfo
        Dim NomeArquivo As String
        Dim Extensao As String

        ArquivoInfo = New System.IO.FileInfo(Plan.PostedFile.FileName)
        NomeArquivo = ArquivoInfo.Name
        Extensao = ArquivoInfo.Extension

        If Plan.Value = String.Empty Then
            Util.AdicionaJsAlert(Me.Page, "Selecione uma planilha!")
            Return False
        End If

        If Extensao.ToLower = ".exe" Or Extensao.ToLower = ".bat" Or Extensao.ToLower = ".com" Then
            Util.AdicionaJsAlert(Me.Page, "Ins5erção de Arquivo não Permitida!")
            Return False
        End If

        If Extensao.ToLower = ".xlsx" Then
            Util.AdicionaJsAlert(Me.Page, "A versão da planilha carregada não é compativel!")
            Return False
        End If

        If Extensao.ToLower <> ".xls" Then
            Util.AdicionaJsAlert(Me.Page, "O arquivo selecionado não é uma planilha!")
            Return False
        End If
        Return True
    End Function

#End Region

End Class