Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO

Public Class VisualizadorRelatorio
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents CrystalReportViewer1 As CrystalDecisions.Web.CrystalReportViewer

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        Try
            If Not IsPostBack Then
                saidaDiretoParaPdf = WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF)
                temFormulas = (Not WSCAcoesComerciais.hashtableFormulasCrystal Is Nothing)
                If temFormulas Then
                    HttpContext.Current.Application("htFormulas") = WSCAcoesComerciais.hashtableFormulasCrystal
                End If
            End If
            carregarRelatorio()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub

#End Region

#Region "Propriedades"

    Private ReadOnly Property nomeRelatorio() As String
        Get
            Dim result As String

            If WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio).ToUpper.Length = 0 Then
                If Not saidaDiretoParaPdf Then
                    result = HttpContext.Current.Application("nomeRelatorio").ToString
                Else
                    result = ""
                End If
            Else
                If Not saidaDiretoParaPdf Then
                    HttpContext.Current.Application("nomeRelatorio") = WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio).ToUpper
                End If
                result = WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio).ToUpper
            End If
            Return result
        End Get
    End Property

    Private Property saidaDiretoParaPdf() As Boolean
        Get
            Return CType(ViewState("saidaDiretoParaPdf"), Boolean)
        End Get
        Set(ByVal Value As Boolean)
            ViewState("saidaDiretoParaPdf") = Value
        End Set
    End Property

    Private Property temFormulas() As Boolean
        Get
            Return CType(ViewState("temFormulas"), Boolean)
        End Get
        Set(ByVal Value As Boolean)
            ViewState("temFormulas") = Value
        End Set
    End Property

    Private ReadOnly Property PerdeuSessao() As Boolean
        Get
            Dim result As Boolean

            If WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio).ToUpper.Length = 0 Then
                result = True
            Else
                result = False
            End If

            Return result
        End Get
    End Property

    Private Property tipoDataset() As String
        Get
            Return CType(ViewState("tipoDataset"), String)
        End Get
        Set(ByVal Value As String)
            ViewState("tipoDataset") = Value
        End Set
    End Property

    Private ReadOnly Property CrystalReportDocument() As ReportDocument
        Get
            Select Case nomeRelatorio.ToUpper
                Case "CBY002AE.RPT"
                    Return New cby002ae
                Case "CBY002KA.RPT"
                    Return New cby002ka
                Case "CBY002LA.RPT"
                    Return New cby002la
                Case "CBY002Z2A.RPT"
                    Return New cby002z2a
                Case "CBY002Z2B.RPT"
                    Return New cby002z2b
                Case "CBY002Z4.RPT"
                    Return New cby002z4
                Case "CBY002Z5.RPT"
                    Return New cby002z5
                Case "CBY002Z5A.RPT"
                    Return New cby002z5a
                Case "CBY002ZA.RPT"
                    Return New cby002za
                Case "CBY002ZB.RPT"
                    Return New cby002zb
                Case "CBY002ZC.RPT"
                    Return New cby002zc
                Case "CBY002ZC1.RPT"
                    Return New cby002zc1
                Case "CBY002ZE1.RPT"
                    Return New cby002ze1
                Case "CBY002ZF.RPT"
                    Return New cby002zf
                Case "CBY002ZG.RPT"
                    Return New cby002zg
                Case "CBY002ZR.RPT"
                    Return New cby002zr
                Case "CCX001I.RPT"
                    Return New ccx001i
                Case "CCX001IA.RPT"
                    Return New ccx001ia
                Case "CLJ001Y.RPT"
                    Return New clj001y
                Case "RPCCLJ051A.RPT"
                    Return New rpcclj051a
                Case "RPCCLJ051B.RPT"
                    Return New rpcclj051b
                Case "RPCCLJ052A.RPT"
                    Return New rpcclj052a
                Case "RPCCLJ052A1.RPT"
                    Return New rpcclj052a1
                Case "RPCCLJ052B.RPT"
                    Return New rpcclj052b
                Case "RPCCLJ052B1.RPT"
                    Return New rpcclj052b1
                Case "RPCCLJ052C.RPT"
                    Return New rpcclj052c
                Case "RPCCLJ052C1.RPT"
                    Return New rpcclj052c1
                Case "RPCCLJ052D.RPT"
                    Return New rpcclj052d
                Case "RPCCLJ052D1.RPT"
                    Return New rpcclj052d1
                Case "RPCCLJ053.RPT"
                    Return New rpcclj053
                Case "RPCCLJ122.RPT"
                    Return New rpcclj122
                Case "RPCLJ022.RPT"
                    Return New rpclj022
                Case "RPCLJ023.RPT"
                    Return New rpclj023
                Case "RPCLJ027.RPT"
                    Return New rpclj027
                Case "RPCLJ041.RPT"
                    Return New rpclj041
                Case "RPCLJ070.RPT"
                    Return New rpclj070
                Case "RPCLJ148A.RPT"
                    Return New rpclj148a
                Case "RPCLJ148B.RPT"
                    Return New rpclj148b
                Case "RPCCLJ121.RPT"
                    Return New rpcclj121
                Case "CBY002L1.RPT"
                    Return New cby002l1
                Case "CCX001J.RPT"
                    Return New ccx001j
                Case "CCX001JB.RPT"
                    Return New ccx001jb
                Case "CCX001JC.RPT"
                    Return New ccx001jc
                Case "RELATORIOBAIXARACORDO.RPT"
                    Return New RelatorioBaixarAcordo
                Case "RELATORIOCOMPARATIVOVALORESSINTETICO.RPT"
                    Return New RelatorioComparativoValoresSintetico
                Case "RELATORIOCOMPARATIVOVALORESANALITICO.RPT"
                    Return New RelatorioComparativoValoresAnalitico
                Case "RELATORIOACORDOSCANCELADOSPERDAS.RPT"
                    Return New RelatorioAcordosCanceladosPerdas
                Case "RELATORIOPREVISAOAPURACAO.RPT"
                    Return New RelatorioPrevisaoApuracao
                Case "RELATORIOPREVISAOAPURACAOCELULA.RPT"
                    Return New RelatorioPrevisaoApuracaoCelula
                Case "RELATORIOPREVISAOAPURACAOCOMPRADOR.RPT"
                    Return New RelatorioPrevisaoApuracaoComprador
                Case "RELATORIOPREVISAOAPURACAOFORNECEDOR.RPT"
                    Return New RelatorioPrevisaoApuracaoFornecedor
                Case "RELATORIONOTASPERIODO.RPT"
                    Return New RelatorioNotasPeriodo
                Case "RELATORIOPREVISAOAPURACAOSINTETICO.RPT"
                    Return New RelatorioPrevisaoApuracaoSintetico
                Case "RELATORIOPREVISAOAPURACAOCELULASINTETICO.RPT"
                    Return New RelatorioPrevisaoApuracaoCelulaSintetico
                Case "RELATORIOPREVISAOAPURACAOCOMPRADORSINTETICO.RPT"
                    Return New RelatorioPrevisaoApuracaoCompradorSintetico
                Case "RELATORIOPREVISAOAPURACAOFORNECEDORSINTETICO.RPT"
                    Return New RelatorioPrevisaoApuracaoFornecedorSintetico
                Case "RELATORIOCARIMBO.RPT"
                    Return New RelatorioCarimbo
                Case "RELATORIOCARIMBOSINTETICO.RPT"
                    Return New RelatorioCarimboSintetico
                Case "RELATORIOCARIMBOANALITICO.RPT"
                    Return New RelatorioCarimboAnalitico
                Case "RELATORIOCARIMBOHISTORICO.RPT"
                    Return New RelatorioCarimboHistorico
                Case "RELATORIOVALORESRECEBERSINTETICO.RPT"
                    Return New RelatorioValoresReceberSintetico
                Case "RELATORIOVALORESRECEBERANALITICO.RPT"
                    Return New RelatorioValoresReceberAnalitico
                Case "RELATORIOVALORESRECEBIDOSSINTETICO.RPT"
                    Return New RelatorioValoresRecebidosSintetico
                Case "RELATORIOVALORESRECEBIDOSANALITICO.RPT"
                    Return New RelatorioValoresRecebidosAnalitico
                Case "RELATORIOVERBASCARIMBADASREALIZADOSINTETICO.RPT"
                    Return New RelatorioVerbasCarimbadasRealizadoSintetico
                Case "RELATORIOVERBASCARIMBADASREALIZADOANALITICO.RPT"
                    Return New RelatorioVerbasCarimbadasRealizadoAnalitico
                Case "RELATORIOVERBASCARIMBADASCANCELADOSINTETICO.RPT"
                    Return New RelatorioVerbasCarimbadasCanceladoSintetico
                Case "RELATORIOVERBASCARIMBADASCANCELADOANALITICO.RPT"
                    Return New RelatorioVerbasCarimbadasCanceladoAnalitico
                Case "RELATORIONOVOSACORDOSSINTETICO.RPT"
                    Return New RelatorioNovosAcordosSintetico
                Case "RELATORIONOVOSACORDOSANALITICO.RPT"
                    Return New RelatorioNovosAcordosAnalitico
                Case "RELATORIOACORDOSCANCELADOSSINTETICO.RPT"
                    Return New RelatorioAcordosCanceladosSintetico
                Case "RELATORIOACORDOSCANCELADOSANALITICO.RPT"
                    Return New RelatorioAcordosCanceladosAnalitico
                Case "RELATORIOCARIMBOXPENDENTEFATURARANA.RPT"
                    Return New RelatorioVendaCarimbosPendenteFaturarAna
                Case "RELATORIOCARIMBOXPENDENTEFATURARSINT.RPT"
                    Return New RelatorioVendaCarimbosPendenteFaturarSint
                Case "RELATORIOCARIMBOXPENDENTEFATURARSINT.RPT"
                    Return New RelatorioVendaCarimbosPendenteFaturarSint
                Case "RELATORIOVALORESREALIZADOSFUNGINDANALITICO.RPT"
                    Return New RelatorioValoresRealizadosFungindAnalitico
                Case "RELATORIOHISTORICOBAIXAOP.RPT"
                    Return New RelatorioHstBaixaOP
            End Select
        End Get
    End Property

#End Region

#Region "Eventos"

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'conteúdo do evento Page_looad transferido para Page_Init

    End Sub

#End Region

#Region "Metodos"

    Private Sub carregarRelatorio()
        Dim crReportDocument As New ReportDocument
        Dim margins As PageMargins
        Dim count As Integer

        Try

            'Generico - Carrega o relatório a partir do WSCAcoesComercias
            crReportDocument = Me.CrystalReportDocument

            'Atribui o dataset ao relatório
            atribuirDataset(crReportDocument)

            'Atribui valores a formulas
            atribuirFormulas(crReportDocument)
           

            If saidaDiretoParaPdf = False Then
                margins = crReportDocument.PrintOptions.PageMargins
                margins.bottomMargin = 350
                margins.topMargin = 350
                crReportDocument.PrintOptions.ApplyPageMargins(margins)

                'Generico - chama o relatório
                With Me.CrystalReportViewer1
                    .ReportSource = crReportDocument
                    .DataBind()
                    .PageZoomFactor = 100
                    .HasZoomFactorList = True
                    .HasGotoPageButton = False
                    .DisplayGroupTree = False
                    '' .HasPrintButton = False
                    .HasDrillUpButton = False
                    '' .HasToggleGroupTreeButton = False
                    ''.HasExportButton = True
                    .HasSearchButton = False
                    .Visible = True
                End With
            Else
               
                margins = crReportDocument.PrintOptions.PageMargins
                margins.bottomMargin = 350
                margins.topMargin = 350
                crReportDocument.PrintOptions.ApplyPageMargins(margins)

                Dim oStream As New MemoryStream ' // using System.IO 
                oStream = CType(crReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat), MemoryStream)
                Response.ClearContent()
                Response.ClearHeaders()
                Response.ContentType = "application/pdf"
                Response.BinaryWrite(oStream.ToArray())
                Response.Flush()
                Response.Close()
            End If
            Me.atribuirDataset(Nothing)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub atribuirDataset(ByRef crReportDocument As ReportDocument)
        Try
            If PerdeuSessao Then
                If Not saidaDiretoParaPdf Then
                    atribuirDatasetDeApplication(crReportDocument)
                    Exit Sub
                End If
            End If

            If crReportDocument Is Nothing Then
                Exit Sub
            End If

            'Dependendo do relatório carrega a fonte de dados específica
            Select Case nomeRelatorio.ToUpper
                'Relatorio contas a receber
            Case "CBY002ZA.RPT", _
                 "CBY002ZR.RPT", _
                 "CBY002ZB.RPT", _
                 "CBY002ZC1.RPT", _
                 "CBY002ZC.RPT", _
                 "CBY002ZE1.RPT", _
                 "CBY002ZF.RPT", _
                 "CBY002ZG.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsRelatorioContasAReceber)
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsRelatorioContasAReceber
                        tipoDataset = "dsRelatorioContasAReceber"
                    End If

                    'RelatorioConferenciaAçãoTatica
                Case "CBY002Z2B.RPT", _
                     "CBY002Z2A.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsRelatorioConferenciaAcaoTatica)
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsRelatorioConferenciaAcaoTatica
                        tipoDataset = "dsRelatorioConferenciaAcaoTatica"
                    End If

                    'RelatorioAcordoS/NFparaDeduction
                Case "CBY002Z4.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsRelatorioAcordoParaDeduction)
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsRelatorioAcordoParaDeduction
                        tipoDataset = "dsRelatorioAcordoParaDeduction"
                    End If

                    'RelatorioAcordoS/NFparaDeduction
                Case "CBY002Z5A.RPT", _
                     "CBY002Z5.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsRelatorioAcordoParaDeduction)
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsRelatorioAcordoParaDeduction
                        tipoDataset = "dsRelatorioAcordoParaDeduction"
                    End If

                    'RelatorioAcordoFornecimento
                Case "RPCLJ022.RPT", _
                     "RPCLJ023.RPT", _
                     "RPCLJ027.RPT", _
                     "RPCLJ041.RPT", _
                     "RPCCLJ052D1.RPT", _
                     "RPCCLJ052A1.RPT", _
                     "RPCCLJ052C1.RPT", _
                     "RPCCLJ052B1.RPT", _
                     "RPCCLJ052A.RPT", _
                     "RPCCLJ052D.RPT", _
                     "RPCCLJ052C.RPT", _
                     "RPCCLJ052B.RPT", _
                     "RPCCLJ052A1.RPT", _
                     "RPCCLJ051B.RPT", _
                     "RPCCLJ051A.RPT", _
                     "RPCCLJ053.RPT", _
                     "RPCCLJ070.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsRelatorioAcordoFornecimento)
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsRelatorioAcordoFornecimento
                        tipoDataset = "dsRelatorioAcordoFornecimento"
                    End If

                    'RelatorioHistoricoAcordo
                Case "RPCCLJ122.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsRelatorioHistoricoAcordo)
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsRelatorioHistoricoAcordo
                        tipoDataset = "dsRelatorioHistoricoAcordo"
                    End If

                    'Relatorio Operacoes OP
                Case "CBY002L1.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsOperacaoBaixaOperacaoFornecedor)
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsOperacaoBaixaOperacaoFornecedor
                        tipoDataset = "dsOperacaoBaixaOperacaoFornecedor"
                    End If

                    'Relatorio Manutenção Acordo
                Case "CBY002KA.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsRelatorioAcordoAcoesComerciais)
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsRelatorioAcordoAcoesComerciais
                        tipoDataset = "dsRelatorioAcordoAcoesComerciais"
                    End If

                    'Cancelar Vlrs.Fornec 
                Case "CBY002AE.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsRelatorioAcordoAcoesComerciais)
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsRelatorioAcordoAcoesComerciais
                        tipoDataset = "dsRelatorioAcordoAcoesComerciais"
                    End If

                    'Relatorio contrato
                Case "CLJ001Y.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsRelatorioAnaliticoAcoesComerciais)
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsRelatorioAnaliticoAcoesComerciais
                        tipoDataset = "dsRelatorioAnaliticoAcoesComerciais"
                    End If

                    'Relatorio Extrato - Martins
                Case "CCX001I.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsRelatorioExtratoContaCorrrente)
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsRelatorioExtratoContaCorrrente
                        tipoDataset = "dsRelatorioExtratoContaCorrrente"
                    End If

                    'Relatorio Extrato - Fornecedor
                Case "CCX001IA.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsRelatorioExtratoContaCorrrente)
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsRelatorioExtratoContaCorrrente
                        tipoDataset = "dsRelatorioExtratoContaCorrrente"
                    End If

                    'Relatório Recebimento
                Case "CBY002LA.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsRelatorioRecibo)
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsRelatorioRecibo
                        tipoDataset = "dsRelatorioRecibo"
                    End If

                    'Relatório Relação Perdas Emitidas
                Case "RPCLJ148A.RPT", _
                     "RPCLJ148B.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsRelacaoPerdasEmitidas)
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsRelacaoPerdasEmitidas
                        tipoDataset = "dsRelacaoPerdasEmitidas"
                    End If

                    'Relatorio Acordo Fornecimento, simulção por célula
                Case "RPCCLJ121.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsSimulacaoSinteticaDeCrescimento)
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsSimulacaoSinteticaDeCrescimento
                        tipoDataset = "dsSimulacaoSinteticaDeCrescimento"
                    End If

                    'Relatório Extrato Martins por célula
                Case "CCX001JB.RPT", "CCX001JC.RPT", "CCX001J.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsRelatorioSaldoDisponivelFornecedorCelula)
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsRelatorioSaldoDisponivelFornecedorCelula
                        tipoDataset = "dsRelatorioSaldoDisponivelFornecedorCelula"
                    End If
                Case "RELATORIOBAIXARACORDO.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsRelatorioBaixaAcordo)
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsRelatorioBaixaAcordo
                        tipoDataset = "dsRelatorioBaixaAcordo"
                    End If
                Case "RELATORIOCOMPARATIVOVALORESSINTETICO.RPT", "RELATORIOCOMPARATIVOVALORESANALITICO.RPT", "RELATORIOACORDOSCANCELADOSPERDAS.RPT", "RELATORIONOTASPERIODO.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsRecuperacaoEPrevencaoPerdas)
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsRecuperacaoEPrevencaoPerdas
                        tipoDataset = "dsRecuperacaoEPrevencaoPerdas"
                    End If
                Case "RELATORIOPREVISAOAPURACAO.RPT", "RELATORIOPREVISAOAPURACAOCELULA.RPT", "RELATORIOPREVISAOAPURACAOCOMPRADOR.RPT", "RELATORIOPREVISAOAPURACAOFORNECEDOR.RPT", _
                     "RELATORIOPREVISAOAPURACAOSINTETICO.RPT", "RELATORIOPREVISAOAPURACAOCELULASINTETICO.RPT", "RELATORIOPREVISAOAPURACAOCOMPRADORSINTETICO.RPT", "RELATORIOPREVISAOAPURACAOFORNECEDORSINTETICO.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsPrevisaoApuracao)
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsPrevisaoApuracao
                        tipoDataset = "dsPrevisaoApuracao"
                    End If
                Case "RELATORIOCARIMBO.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsRelatorioCarimbo)
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsRelatorioCarimbo
                        tipoDataset = "dsRelatorioCarimbo"
                    End If
                    crReportDocument.SetParameterValue("Filtro", WSCAcoesComerciais.StringValue(WSCVar.Filtro))
                    crReportDocument.SetParameterValue("Empenho", WSCAcoesComerciais.StringValue(WSCVar.Empenho))
                    crReportDocument.SetParameterValue("Filial", WSCAcoesComerciais.StringValue(WSCVar.Filial))
                    crReportDocument.SetParameterValue("Usuario", WSCAcoesComerciais.StringValue(WSCVar.Usuario))
                    crReportDocument.SetParameterValue("LabelFiltro", WSCAcoesComerciais.StringValue(WSCVar.labelFiltro))
                Case "RELATORIOCARIMBOSINTETICO.RPT"
                    crReportDocument.Load(Server.MapPath("~/Relatorios/RELATORIOCARIMBOSINTETICO.RPT"))
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsRelatorioCarimbo)
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsRelatorioCarimbo
                        tipoDataset = "dsRelatorioCarimbo"
                    End If
                    crReportDocument.SetParameterValue("Filtro", WSCAcoesComerciais.StringValue(WSCVar.Filtro))
                    crReportDocument.SetParameterValue("Empenho", WSCAcoesComerciais.StringValue(WSCVar.Empenho))
                    crReportDocument.SetParameterValue("Filial", WSCAcoesComerciais.StringValue(WSCVar.Filial))
                    crReportDocument.SetParameterValue("Usuario", WSCAcoesComerciais.StringValue(WSCVar.Usuario))
                    crReportDocument.SetParameterValue("LabelFiltro", WSCAcoesComerciais.StringValue(WSCVar.labelFiltro))
                Case "RELATORIOCARIMBOANALITICO.RPT"
                    'crReportDocument.SetParameterValue("?Filtro")
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsRelatorioCarimbo)
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsRelatorioCarimbo
                        tipoDataset = "dsRelatorioCarimbo"
                    End If
                    crReportDocument.SetParameterValue("Filtro", WSCAcoesComerciais.StringValue(WSCVar.Filtro))
                    crReportDocument.SetParameterValue("Empenho", WSCAcoesComerciais.StringValue(WSCVar.Empenho))
                    crReportDocument.SetParameterValue("Filial", WSCAcoesComerciais.StringValue(WSCVar.Filial))
                    crReportDocument.SetParameterValue("Usuario", WSCAcoesComerciais.StringValue(WSCVar.Usuario))
                    crReportDocument.SetParameterValue("LabelFiltro", WSCAcoesComerciais.StringValue(WSCVar.labelFiltro))
                Case "RELATORIOCARIMBOHISTORICO.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsRelatorioHistorico)
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsRelatorioHistorico
                        tipoDataset = "dsRelatorioHistorico"
                    End If
                    crReportDocument.SetParameterValue("Filial", WSCAcoesComerciais.StringValue(WSCVar.Filial))
                    crReportDocument.SetParameterValue("Usuario", WSCAcoesComerciais.StringValue(WSCVar.Usuario))
                    crReportDocument.SetParameterValue("Periodo", WSCAcoesComerciais.StringValue(WSCVar.Periodo))
                    crReportDocument.SetParameterValue("Diretoria", WSCAcoesComerciais.StringValue(WSCVar.Diretoria))
                    crReportDocument.SetParameterValue("Celula", WSCAcoesComerciais.StringValue(WSCVar.Celula))
                    crReportDocument.SetParameterValue("Comprador", WSCAcoesComerciais.StringValue(WSCVar.Comprador))
                    crReportDocument.SetParameterValue("Fornecedor", WSCAcoesComerciais.StringValue(WSCVar.Fornecedor))
                    crReportDocument.SetParameterValue("Tipo", WSCAcoesComerciais.StringValue(WSCVar.Tipo))
                    crReportDocument.SetParameterValue("Descricao", WSCAcoesComerciais.StringValue(WSCVar.Descricao))
                    crReportDocument.SetParameterValue("Mercadoria", WSCAcoesComerciais.StringValue(WSCVar.Mercadoria))
                Case "RELATORIOVALORESRECEBERSINTETICO.RPT", _
                     "RELATORIOVALORESRECEBERANALITICO.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsValoresContabilizadosCarimbos)
                    crReportDocument.SetParameterValue("DataGeracaoAcordo", WSCAcoesComerciais.StringValue(WSCVar.DataGeracaoAcordo))
                    crReportDocument.SetParameterValue("DataPrevisaoRecebimento", WSCAcoesComerciais.StringValue(WSCVar.DataPrevisaoRecebimento))
                    crReportDocument.SetParameterValue("Tipo", WSCAcoesComerciais.StringValue(WSCVar.TipoDesconto))
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsValoresContabilizadosCarimbos
                        tipoDataset = "dsValoresContabilizadosCarimbos"
                    End If
                Case "RELATORIOVALORESRECEBIDOSSINTETICO.RPT", _
                     "RELATORIOVALORESRECEBIDOSANALITICO.RPT", _
                     "RELATORIOCARIMBOXPENDENTEFATURARANA.RPT", _
                     "RELATORIOCARIMBOXPENDENTEFATURARSINT.RPT"

                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsValoresContabilizadosCarimbos)
                    crReportDocument.SetParameterValue("Filtro", WSCAcoesComerciais.StringValue(WSCVar.Filtro))
                    crReportDocument.SetParameterValue("Tipo", WSCAcoesComerciais.StringValue(WSCVar.TipoDesconto))
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsValoresContabilizadosCarimbos
                        tipoDataset = "dsValoresContabilizadosCarimbos"
                    End If
                Case "RELATORIOVERBASCARIMBADASREALIZADOSINTETICO.RPT", _
                     "RELATORIOVERBASCARIMBADASREALIZADOANALITICO.RPT", _
                     "RELATORIOVERBASCARIMBADASCANCELADOSINTETICO.RPT", _
                     "RELATORIOVERBASCARIMBADASCANCELADOANALITICO.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsVerbasCarimbadas)
                    crReportDocument.SetParameterValue("Filtro", WSCAcoesComerciais.StringValue(WSCVar.Filtro))
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsVerbasCarimbadas
                        tipoDataset = "dsVerbasCarimbadas"
                    End If
                Case "RELATORIONOVOSACORDOSSINTETICO.RPT", _
                     "RELATORIONOVOSACORDOSANALITICO.RPT", _
                     "RELATORIOACORDOSCANCELADOSSINTETICO.RPT", _
                     "RELATORIOACORDOSCANCELADOSANALITICO.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsAcordos)
                    crReportDocument.SetParameterValue("Filtro", WSCAcoesComerciais.StringValue(WSCVar.Filtro))
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsAcordos
                        tipoDataset = "dsAcordos"
                    End If
                Case "RELATORIOVALORESREALIZADOSFUNGINDANALITICO.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsValoresContabilizadosCarimbos)
                    crReportDocument.SetParameterValue("Filtro", WSCAcoesComerciais.StringValue(WSCVar.Filtro))
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsValoresContabilizadosCarimbos
                        tipoDataset = "dsValoresContabilizadosCarimbos"
                    End If
                Case "RELATORIOHISTORICOBAIXAOP.RPT"
                    crReportDocument.SetDataSource(WSCAcoesComerciais.dsRelatorioHistoricoBaixaOP)
                    'crReportDocument.SetParameterValue("DataGeracaoHistorico", WSCAcoesComerciais.StringValue(WSCVar.DataGeracaoAcordo))
                    If Not saidaDiretoParaPdf Then
                        HttpContext.Current.Application("dsRelatorio") = WSCAcoesComerciais.dsRelatorioHistoricoBaixaOP
                        tipoDataset = "dsRelatorioHistoricoBaixaOP"
                    End If
            End Select
            WSCAcoesComerciais.StringValue(WSCVar.Celula) = String.Empty
            WSCAcoesComerciais.StringValue(WSCVar.Comprador) = String.Empty
            WSCAcoesComerciais.StringValue(WSCVar.Descricao) = String.Empty
            WSCAcoesComerciais.StringValue(WSCVar.Diretoria) = String.Empty
            WSCAcoesComerciais.StringValue(WSCVar.dsRelatorioCarimbo) = Nothing
            WSCAcoesComerciais.StringValue(WSCVar.dsRelatorioHistorico) = Nothing
            WSCAcoesComerciais.StringValue(WSCVar.Empenho) = String.Empty
            WSCAcoesComerciais.StringValue(WSCVar.Filial) = String.Empty
            WSCAcoesComerciais.StringValue(WSCVar.Filtro) = String.Empty
            WSCAcoesComerciais.StringValue(WSCVar.Fornecedor) = String.Empty
            WSCAcoesComerciais.StringValue(WSCVar.Mercadoria) = String.Empty
            WSCAcoesComerciais.StringValue(WSCVar.Periodo) = String.Empty
            WSCAcoesComerciais.StringValue(WSCVar.Tipo) = String.Empty
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub atribuirDatasetDeApplication(ByRef crReportDocument As ReportDocument)
        Try

            'Dependendo do relatório carrega a fonte de dados específica
            Select Case nomeRelatorio.ToUpper

                'Relatorio contas a receber
            Case "CBY002ZA.RPT", _
                 "CBY002ZR.RPT", _
                 "CBY002ZB.RPT", _
                 "CBY002ZC1.RPT", _
                 "CBY002ZC.RPT", _
                 "CBY002ZE1.RPT", _
                 "CBY002ZF.RPT", _
                 "CBY002ZG.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DatasetRelatorioContasAReceber))

                    'RelatorioConferenciaAçãoTatica
                Case "CBY002Z2B.RPT", _
                     "CBY002Z2A.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DatasetRelatorioConferenciaAcaoTatica))

                    'RelatorioAcordoS/NFparaDeduction
                Case "CBY002Z4.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DatasetRelatorioAcordoParaDeduction))

                    'RelatorioAcordoS/NFparaDeduction
                Case "CBY002Z5A.RPT", _
                     "CBY002Z5.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DatasetRelatorioAcordoParaDeduction))

                    'RelatorioAcordoFornecimento
                Case "RPCLJ022.RPT", _
                     "RPCLJ023.RPT", _
                     "RPCLJ027.RPT", _
                     "RPCLJ041.RPT", _
                     "RPCCLJ052D1.RPT", _
                     "RPCCLJ052A1.RPT", _
                     "RPCCLJ052C1.RPT", _
                     "RPCCLJ052B1.RPT", _
                     "RPCCLJ052A.RPT", _
                     "RPCCLJ052D.RPT", _
                     "RPCCLJ052C.RPT", _
                     "RPCCLJ052B.RPT", _
                     "RPCCLJ052A1.RPT", _
                     "RPCCLJ051B.RPT", _
                     "RPCCLJ051A.RPT", _
                     "RPCCLJ053.RPT", _
                     "RPCCLJ070.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DatasetRelatorioAcordoFornecimento))

                    'RelatorioHistoricoAcordo
                Case "RPCCLJ122.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DatasetRelatorioHistoricoAcordo))

                    'Relatorio Operacoes OP
                Case "CBY002L1.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DatasetOperacaoBaixaOperacaoFornecedor))

                    'Relatorio Manutenção Acordo
                Case "CBY002KA.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DatasetRelatorioAcordoAcoesComerciais))

                    'Cancelar Vlrs.Fornec 
                Case "CBY002AE.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DatasetRelatorioAcordoAcoesComerciais))

                    'Relatorio contrato
                Case "CLJ001Y.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DataSetRelatorioAnaliticoAcoesComerciais))

                    'Relatorio Extrato - Martins
                Case "CCX001I.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DataSetRelatorioExtratoContaCorrrente))

                    'Relatorio Extrato - Fornecedor
                Case "CCX001IA.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DataSetRelatorioExtratoContaCorrrente))

                    'Relatório Recebimento
                Case "CBY002LA.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DataSetRelatorioRecibo))

                    'Relatório Relação Perdas Emitidas
                Case "RPCLJ148A.RPT", _
                     "RPCLJ148B.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DatasetRelacaoPerdasEmitidas))

                    'Relatorio Acordo Fornecimento, simulção por célula
                Case "RPCCLJ121.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DatasetSimulacaoSinteticaDeCrescimento))

                    'Relatório Extrato Martins por célula
                Case "CCX001JB.RPT", "CCX001JC.RPT", "CCX001J.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DataSetRelatorioSaldoDisponivelFornecedorCelula))

                Case "RELATORIOBAIXARACORDO.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DatasetRelatorioBaixaAcordo))

                Case "RELATORIOCOMPARATIVOVALORESSINTETICO.RPT", "RELATORIOCOMPARATIVOVALORESANALITICO.RPT", "RELATORIOACORDOSCANCELADOSPERDAS.RPT", "RELATORIONOTASPERIODO.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsRecuperacaoEPrevencaoPerdas.DatasetRecuperacaoEPrevencaoPerdas))

                Case "RELATORIOPREVISAOAPURACAO.RPT", "RELATORIOPREVISAOAPURACAOCELULA.RPT", "RELATORIOPREVISAOAPURACAOCOMPRADOR.RPT", "RELATORIOPREVISAOAPURACAOFORNECEDOR.RPT", _
                    "RELATORIOPREVISAOAPURACAOSINTETICO.RPT", "RELATORIOPREVISAOAPURACAOCELULASINTETICO.RPT", "RELATORIOPREVISAOAPURACAOCOMPRADORSINTETICO.RPT", "RELATORIOPREVISAOAPURACAOFORNECEDORSINTETICO.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DatasetPrevisaoApuracao))

                Case "RELATORIOCARIMBO.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DatasetRelatorioCarimbo))

                Case "RELATORIOCARIMBOSINTETICO.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DatasetRelatorioCarimbo))
                Case "RELATORIOCARIMBOANALITICO.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DatasetRelatorioCarimbo))
                Case "RELATORIOCARIMBOHISTORICO.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DatasetCarimboHistorico))
                Case "RELATORIOVALORESRECEBERSINTETICO.RPT", _
                     "RELATORIOVALORESRECEBERANALITICO.RPT", _
                     "RELATORIOVALORESRECEBIDOSSINTETICO.RPT", _
                     "RELATORIOVALORESRECEBIDOSANALITICO.RPT", _
                     "RELATORIOCARIMBOXPENDENTEFATURARANA.RPT", _
                     "RELATORIOCARIMBOXPENDENTEFATURARSINT.RPT"

                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DataSetValoresContabilizadosCarimbosRelatorio))
                Case "RELATORIOVERBASCARIMBADASREALIZADOSINTETICO.RPT", _
                     "RELATORIOVERBASCARIMBADASREALIZADOANALITICO.RPT", _
                     "RELATORIOVERBASCARIMBADASCANCELADOSINTETICO.RPT", _
                     "RELATORIOVERBASCARIMBADASCANCELADOANALITICO.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DataSetRelatorioVerbasCarimbadas))
                Case "RELATORIONOVOSACORDOSSINTETICO.RPT", _
                     "RELATORIONOVOSACORDOSANALITICO.RPT", _
                     "RELATORIOACORDOSCANCELADOSSINTETICO.RPT", _
                     "RELATORIOACORDOSCANCELADOSANALITICO.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DataSetRelatorioAcordos))
                Case "RELATORIOHISTORICOBAIXAOP.RPT"
                    crReportDocument.SetDataSource(CType(HttpContext.Current.Application("dsRelatorio"), wsAcoesComerciais.DatasetRelatorioHistoricoBaixaOP))
            End Select

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub atribuirFormulas(ByRef crReportDocument As ReportDocument)
        Try
            Dim htFormulas As Hashtable = WSCAcoesComerciais.hashtableFormulasCrystal
            Dim chave As String

            If temFormulas And htFormulas Is Nothing Then
                htFormulas = CType(HttpContext.Current.Application("htFormulas"), Hashtable)
            End If

            If htFormulas Is Nothing Then Exit Sub
            For Each chave In htFormulas.Keys
                crReportDocument.DataDefinition.FormulaFields(chave).Text = htFormulas(chave).ToString
            Next

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

End Class