Public Class SelecionarAcordos
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetAcordoACancelarEmFluxoCancelamentoAcordo1 = New Martins.Web.UI.AcoesComerciais.wsFluxoDeCancelamentoDeAcordos.DatasetAcordoACancelarEmFluxoCancelamentoAcordo
        Me.DatasetFluxoCancelamentoAcordo1 = New Martins.Web.UI.AcoesComerciais.wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo
        CType(Me.DatasetAcordoACancelarEmFluxoCancelamentoAcordo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetFluxoCancelamentoAcordo1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetAcordoACancelarEmFluxoCancelamentoAcordo1
        '
        Me.DatasetAcordoACancelarEmFluxoCancelamentoAcordo1.DataSetName = "DatasetAcordoACancelarEmFluxoCancelamentoAcordo"
        Me.DatasetAcordoACancelarEmFluxoCancelamentoAcordo1.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DatasetFluxoCancelamentoAcordo1
        '
        Me.DatasetFluxoCancelamentoAcordo1.DataSetName = "DatasetFluxoCancelamentoAcordo"
        Me.DatasetFluxoCancelamentoAcordo1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetAcordoACancelarEmFluxoCancelamentoAcordo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetFluxoCancelamentoAcordo1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnLimparOrigem As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lkbNenhum As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lkbTodas As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetAcordoACancelarEmFluxoCancelamentoAcordo1 As Martins.Web.UI.AcoesComerciais.wsFluxoDeCancelamentoDeAcordos.DatasetAcordoACancelarEmFluxoCancelamentoAcordo
    Protected WithEvents grdAcordoCancelamento As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents btnVoltar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cmdCalcularValores As System.Web.UI.WebControls.Button
    Protected WithEvents lblMensagemDesatualizado As System.Web.UI.WebControls.Label
    Protected WithEvents DatasetFluxoCancelamentoAcordo1 As Martins.Web.UI.AcoesComerciais.wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo
    Protected WithEvents txtValor1 As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents ValorTransferir As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtValorCancelar As Infragistics.WebUI.WebDataInput.WebNumericEdit


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
            If (Not IsPostBack) Then
                Me.IniciarPagina()
            Else
                Me.RecuperaEstado()
            End If
            carregarJavaScript()
            SetNaoGravarCache()
            AtualizarValorTotal()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
            Exit Sub
        End If
        Me.SalvaEstado()
    End Sub

    Private Sub btnVoltar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Try
            Util.FecharPagina(Me.Page)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnLimparOrigem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimparOrigem.Click
        Try
            LimparTela()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ucFornecedor_FornecedorAlterado(ByVal e As System.Web.UI.WebControls.ListItem)
        Try
            grdAcordoCancelamento.Rows.Clear()
            txtValor1.Value = 0
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
                Exit Sub
            End If
            If AtualizarDatasetComDadosDoGrid() Then
                Controller.AtualizarFluxoCancelamentoAcordo(Me.DatasetFluxoCancelamentoAcordo1)
                Me.DatasetFluxoCancelamentoAcordo1 = Controller.ObterFluxoCancelamentoAcordoPorChave(WSCAcoesComerciais.CODFRN, WSCAcoesComerciais.NUMPEDCNCACOCMC)
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub lkbTodas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkbTodas.Click
        Try
            If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
                Exit Sub
            End If
            Me.MarcarTodas()
            Me.AtualizarValorTotal()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub lkbNenhum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkbNenhum.Click
        Try
            If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
                Exit Sub
            End If
            Me.DesmarcarTodas()
            Me.AtualizarValorTotal()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub grdOrigem_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.UltraWebGrid.LayoutEventArgs)
        Try
            If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
                Exit Sub
            End If
            e.Layout.Bands(0).Columns(1).Header.Fixed = True
            e.Layout.Bands(0).Columns(2).Header.Fixed = True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#Region "Metodos de Carga"

    Private Sub IniciarPagina()
        Try
            Me.DatasetFluxoCancelamentoAcordo1 = WSCAcoesComerciais.dsFluxoCancelamento
            PesquisarAcordos()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub carregarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        Page.RegisterStartupScript("Valor", "<script>window.MM_findObj('TbValorAtualizado').style.display = 'none';</script>")
        'System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR")
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("pt-BR")
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalDigits = 2
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalDigits = 2
        'System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat = System.Globalization.DateTimeFormatInfo.CreateSpecificCulture("pt-BR") 'System.Globalization.DateTimeFormatInfo
    End Sub

    Private Sub PesquisarAcordos()
        Dim CODFRN As Decimal
        CODFRN = WSCAcoesComerciais.CODFRN

        Me.DatasetAcordoACancelarEmFluxoCancelamentoAcordo1 = Controller.ObterAcordosParaCancelamentoPorFornecedor(CODFRN)

        If Not Me.DatasetAcordoACancelarEmFluxoCancelamentoAcordo1 Is Nothing Then
            grdAcordoCancelamento.DataBind()
            VerificaAcordoACancelar()
        Else
            Util.AdicionaJsAlert(Me.Page, "Não foi encontrado nenhum registro!")
        End If
    End Sub

    Private Sub VerificaAcordoACancelar()
        Dim TotalValorACancelar As Decimal
        Me.DatasetFluxoCancelamentoAcordo1.Merge(Controller.ObterAcordoACancelarEmFluxoCancelamentoAcordoPorAtributos(0, 0, 0, Nothing, Nothing, 0, 0, 0))

        If Me.DatasetFluxoCancelamentoAcordo1.T0154021.Rows.Count <> 0 Then
            For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In grdAcordoCancelamento.Rows
                Dim T0154021Row As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo.T0154021Row

                Dim NUMPEDCNCACOCMC As Decimal = WSCAcoesComerciais.NUMPEDCNCACOCMC
                Dim CODPMS As Decimal = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("CODPMS")), Decimal)
                Dim CODEMP As Decimal = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("CODEMP")), Decimal)
                Dim CODFILEMP As Decimal = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("CODFILEMP")), Decimal)
                Dim DATNGCPMS As Date = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("DATNGCPMS")), Date)
                Dim DATPRVRCBPMS As Date = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("DATPRVRCBPMS")), Date)
                Dim TIPFRMDSCBNF As Decimal = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("TIPFRMDSCBNF")), Decimal)
                Dim TIPDSNDSCBNF As Decimal = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("TIPDSNDSCBNF")), Decimal)

                T0154021Row = Me.DatasetFluxoCancelamentoAcordo1.T0154021.FindByNUMPEDCNCACOCMCCODPMSCODEMPCODFILEMPDATNGCPMSDATPRVRCBPMSTIPFRMDSCBNFTIPDSNDSCBNF(NUMPEDCNCACOCMC, _
                                                                           CODPMS, _
                                                                           CODEMP, _
                                                                           CODFILEMP, _
                                                                           DATNGCPMS, _
                                                                           DATPRVRCBPMS, _
                                                                           TIPFRMDSCBNF, _
                                                                           TIPDSNDSCBNF)
                If Not T0154021Row Is Nothing Then
                    If T0154021Row.VLRSLDPMSFRN = (T0154021Row.VLRNGCPMS - T0154021Row.VLRPGOPMS) Then
                        linha.Cells.Item(0).Value = True
                    End If
                    'linha.Cells(CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("ValorACancelar")), Integer)).Value = T0154021Row.VLRSLDPMSFRN
                    linha.Cells(9).Value = T0154021Row.VLRSLDPMSFRN
                    TotalValorACancelar += T0154021Row.VLRSLDPMSFRN
                End If
                txtValor1.ValueDecimal = TotalValorACancelar
            Next
        End If
    End Sub

    Private Sub SetNaoGravarCache()
        Try
            Response.Cache.SetNoServerCaching()
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache)
            Response.Cache.SetNoStore()
            Response.Cache.SetExpires(New DateTime(1900, 1, 1, 0, 0, 0, 0))
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#Region "Metodos de controle"

    Private Sub RecuperaEstado()
        If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
            Exit Sub
        End If
        Me.DatasetFluxoCancelamentoAcordo1 = WSCAcoesComerciais.dsFluxoCancelamento
    End Sub

    Private Sub SalvaEstado()
        WSCAcoesComerciais.dsFluxoCancelamento = Me.DatasetFluxoCancelamentoAcordo1
    End Sub

    Private Sub MarcarTodas()
        For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdAcordoCancelamento.Rows
            If CType(linha.Cells.Item(0).Value, Boolean) = False Then
                linha.Cells(CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("ValorACancelar")), Integer)).Value = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("VLRNGCPMS")), Decimal) - CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("VLRPGOPMS")), Decimal)
            End If
            linha.Cells.Item(0).Value = True
        Next
    End Sub

    Private Sub DesmarcarTodas()
        For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdAcordoCancelamento.Rows
            linha.Cells.Item(0).Value = False
            linha.Cells(CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("ValorACancelar")), Integer)).Value = 0
        Next
    End Sub

    Private Sub LimparTela()
        grdAcordoCancelamento.Rows.Clear()
        txtValor1.Text = String.Empty
    End Sub

    Private Sub AtualizarValorTotal()
        Dim Valor As Decimal = 0
        Dim SomaDeValor As Decimal = 0

        For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdAcordoCancelamento.Rows
           
            If (CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("ValorACancelar")), Decimal) <> 0) Or (CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("Sel")), Boolean)) Or (CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("Sel")), Boolean)) Then
                If (CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("Sel")), Boolean)) Or (CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("Sel")), Boolean)) Then
                    linha.Cells(9).Value = linha.Cells(10).Value
                Else
                    If CType(linha.Cells(9).Value, Decimal) > CType(linha.Cells(10).Value, Decimal) Then
                        Util.AdicionaJsAlert(Me.Page, "Valor a cancelar é maior que o permitido!", True)
                        Exit Sub
                    End If
                End If

                Valor = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("ValorACancelar")), Decimal)
                SomaDeValor += Valor
            End If
        Next
        txtValor1.ValueDecimal = SomaDeValor
    End Sub

#End Region

#Region "Metodos de Regra"

#End Region

#Region "Metodos de Persistencia"

    Private Function AtualizarDatasetComDadosDoGrid() As Boolean
        'Verifica se existe registro na tabela de cadastro
        If Me.DatasetFluxoCancelamentoAcordo1.T0154038.Rows.Count = 0 Then
            Util.AdicionaJsAlert(Me.Page, "Não existe registro na tabela de fluxo de cancelamento, tente novamente se o problema persistir informe ao analista responsável")
            Return False
        End If

        'Obtema linha da tabela de cadastro
        Dim T0154038Row As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo.T0154038Row
        T0154038Row = Me.DatasetFluxoCancelamentoAcordo1.T0154038(0)

        If T0154038Row.RowState = DataRowState.Added Then
            T0154038Row.NUMPEDCNCACOCMC = WSCAcoesComerciais.NUMPEDCNCACOCMC
        End If

        'Atualiza o dataset
        For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdAcordoCancelamento.Rows
            Select Case CType(linha.Cells(0).Value, Boolean) Or CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("ValorACancelar")), Decimal) <> 0
                Case True 'A linha do grid foi selecionada
                    If Not AtualizarDataset(T0154038Row, linha) Then
                        Return False
                    End If
                Case False 'A linha do grid não foi selecionada
                    If Not ExcluirLinhaDoDataset(T0154038Row, linha) Then
                        Return False
                    End If
            End Select
        Next
        Return True
    End Function

    Private Function AtualizarDataset(ByVal T0154038Row As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo.T0154038Row, _
                                      ByVal linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow) As Boolean

        'Declaração das variaveis para transferencia dos dados e Transfere os valores da linha selecionada para as variaveis locais
        Dim NUMPEDCNCACOCMC As Decimal = WSCAcoesComerciais.NUMPEDCNCACOCMC
        Dim CODPMS As Decimal = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("CODPMS")), Decimal)
        Dim CODEMP As Decimal = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("CODEMP")), Decimal)
        Dim CODFILEMP As Decimal = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("CODFILEMP")), Decimal)
        Dim DATNGCPMS As Date = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("DATNGCPMS")), Date)
        Dim DATPRVRCBPMS As Date = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("DATPRVRCBPMS")), Date)
        Dim TIPFRMDSCBNF As Decimal = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("TIPFRMDSCBNF")), Decimal)
        Dim TIPDSNDSCBNF As Decimal = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("TIPDSNDSCBNF")), Decimal)

        'Caso a linha da capa CADTRNVBAFRN ainda não tenha sido gravada no banco de dados
        'reconsulta a chave, isso é necessário para resolver problema de concorrencia na
        'qual dois usuário podem ter aberto uma transferencia ao mesmo tempo e tenha obtido
        'o mesmo número de fluxo
        If T0154038Row.RowState = DataRowState.Added Then
            T0154038Row.NUMPEDCNCACOCMC = WSCAcoesComerciais.NUMPEDCNCACOCMC
        End If

        'Obtem a linha que será atualizada, ou cria uma nova caso ela não exista
        Dim T0154021Row As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo.T0154021Row
        T0154021Row = Me.DatasetFluxoCancelamentoAcordo1.T0154021.FindByNUMPEDCNCACOCMCCODPMSCODEMPCODFILEMPDATNGCPMSDATPRVRCBPMSTIPFRMDSCBNFTIPDSNDSCBNF(NUMPEDCNCACOCMC, _
                                                                                                                                                          CODPMS, _
                                                                                                                                                          CODEMP, _
                                                                                                                                                          CODFILEMP, _
                                                                                                                                                          DATNGCPMS, _
                                                                                                                                                          DATPRVRCBPMS, _
                                                                                                                                                          TIPFRMDSCBNF, _
                                                                                                                                                          TIPDSNDSCBNF)
        If T0154021Row Is Nothing Then
            T0154021Row = Me.DatasetFluxoCancelamentoAcordo1.T0154021.NewT0154021Row
        End If

        'Transfere valores das variaveis para a linha da tabela
        With T0154021Row
            .NUMPEDCNCACOCMC = WSCAcoesComerciais.NUMPEDCNCACOCMC
            .VLRSLDPMSFRN = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("ValorACancelar")), Decimal)
            .CODPMS = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("CODPMS")), Decimal)
            .CODEMP = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("CODEMP")), Decimal)
            .CODFILEMP = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("CODFILEMP")), Decimal)
            .DATNGCPMS = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("DATNGCPMS")), Date)
            .DATPRVRCBPMS = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("DATPRVRCBPMS")), Date)
            .TIPFRMDSCBNF = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("TIPFRMDSCBNF")), Decimal)
            .TIPDSNDSCBNF = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("TIPDSNDSCBNF")), Decimal)
            .VLRNGCPMS = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("VLRNGCPMS")), Decimal)
            .VLRPGOPMS = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("VLRPGOPMS")), Decimal)
        End With

        'Insere a linha caso ela seja nova
        If T0154021Row.RowState = DataRowState.Detached Then
            Me.DatasetFluxoCancelamentoAcordo1.T0154021.AddT0154021Row(T0154021Row)
        End If
        Return True
    End Function

    Private Function ExcluirLinhaDoDataset(ByVal T0154038Row As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo.T0154038Row, _
                                           ByVal linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow) As Boolean

        'Declaração das variaveis para transferencia dos dados e Transfere os valores da linha selecionada para as variaveis locais
        Dim NUMPEDCNCACOCMC As Decimal = WSCAcoesComerciais.NUMPEDCNCACOCMC
        Dim CODPMS As Decimal = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("CODPMS")), Decimal)
        Dim CODEMP As Decimal = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("CODEMP")), Decimal)
        Dim CODFILEMP As Decimal = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("CODFILEMP")), Decimal)
        Dim DATNGCPMS As Date = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("DATNGCPMS")), Date)
        Dim DATPRVRCBPMS As Date = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("DATPRVRCBPMS")), Date)
        Dim TIPFRMDSCBNF As Decimal = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("TIPFRMDSCBNF")), Decimal)
        Dim TIPDSNDSCBNF As Decimal = CType(linha.GetCellValue(Me.grdAcordoCancelamento.Columns.FromKey("TIPDSNDSCBNF")), Decimal)

        'Obtem a linha que será excluída
        Dim T0154021Row As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo.T0154021Row
        T0154021Row = Me.DatasetFluxoCancelamentoAcordo1.T0154021.FindByNUMPEDCNCACOCMCCODPMSCODEMPCODFILEMPDATNGCPMSDATPRVRCBPMSTIPFRMDSCBNFTIPDSNDSCBNF(NUMPEDCNCACOCMC, _
                                                                                                                                                          CODPMS, _
                                                                                                                                                          CODEMP, _
                                                                                                                                                          CODFILEMP, _
                                                                                                                                                          DATNGCPMS, _
                                                                                                                                                          DATPRVRCBPMS, _
                                                                                                                                                          TIPFRMDSCBNF, _
                                                                                                                                                          TIPDSNDSCBNF)

        'Exclui a linha
        If Not T0154021Row Is Nothing Then
            T0154021Row.Delete()
        End If
        Return True
    End Function
#End Region

End Class