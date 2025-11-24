Public Class RelacaoGrupoMktManter
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "
    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoGrupoMarketing1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoGrupoMarketing
        CType(Me.DatasetTipoGrupoMarketing1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoGrupoMarketing1
        '
        Me.DatasetTipoGrupoMarketing1.DataSetName = "DatasetTipoGrupoMarketing"
        Me.DatasetTipoGrupoMarketing1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoGrupoMarketing1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents Div1 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents cmbGrupoMarketingPercentuais As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnSair As System.Web.UI.WebControls.LinkButton
    Protected WithEvents grdRelacaoGrupoEconomico As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents lkbNenhuma As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lkbTodas As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetTipoGrupoMarketing1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoGrupoMarketing


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
    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Try
            RedirecionaPagina()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub lkbTodas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkbTodas.Click
        Try
            MarcarTodas()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub lkbNenhuma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkbNenhuma.Click
        Try
            DesmarcarTodas()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            ConsistirDadosGrid()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#Region "Métodos de Carga"

    Private Sub IniciarPagina()
        CarregaCombo()
        CarregarDadosGrid()
    End Sub

    Private Sub carregarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
    End Sub

    Private Sub RedirecionaPagina()
        Response.Redirect("RelacaoGrupoMktListar.aspx")
    End Sub

    Private Sub RedirecionaPagina(ByVal erro As String)
        Response.Redirect("RelacaoGrupoMktListar.aspx?erro=" & erro)
    End Sub

    Private Sub CarregaCombo()
        Dim dsGrupoMarketing As wsAcoesComerciais.DatasetTipoGrupoMarketing
        dsGrupoMarketing = Controller.ObterTipoGrupoMarketingPorAtributo(0, String.Empty)

        If Not dsGrupoMarketing Is Nothing Then
            If dsGrupoMarketing.CADTIPGRPMKTFRNPesquisa.Rows.Count > 0 Then
                cmbGrupoMarketingPercentuais.Items.Add("SELECIONE")
                For Each linha As wsAcoesComerciais.DatasetTipoGrupoMarketing.CADTIPGRPMKTFRNPesquisaRow In dsGrupoMarketing.CADTIPGRPMKTFRNPesquisa
                    With cmbGrupoMarketingPercentuais
                        .DataValueField = linha.TIPGRPMKTFRN.ToString
                        .Items.Add(linha.TIPGRPMKTFRN & " - " & linha.DESGRPMKTFRN & " - " & Format(linha.PERGRPMKTFRN, "###,###,##0.00").ToString & "%")
                    End With
                Next
            End If
        End If
    End Sub

    Private Sub CarregarDadosGrid()
        Dim dsPlanilha As New DataSet

        If Not WSCAcoesComerciais.dsPlanilha Is Nothing Then
            dsPlanilha = WSCAcoesComerciais.dsPlanilha
        End If

        If Not WSCAcoesComerciais.dsTipoGrupoMarketing Is Nothing Then
            Me.DatasetTipoGrupoMarketing1 = WSCAcoesComerciais.dsTipoGrupoMarketing

        End If

        If Me.DatasetTipoGrupoMarketing1.RLCGRPECOGRPMKTFRNPesquisaPai.Rows.Count > 0 Then
            'CriaRelacionamentosDataset()
            grdRelacaoGrupoEconomico.DataBind()
            ConfiguraLayoutGridBand1()
            WSCAcoesComerciais.dsTipoGrupoMarketing = Nothing
        Else
            If dsPlanilha.Tables.Count > 0 Then
                If dsPlanilha.Tables(0).Rows.Count > 0 Then
                    cmbGrupoMarketingPercentuais.Enabled = False
                    MontarDadosGridPlanilha()
                    WSCAcoesComerciais.dsPlanilha = Nothing
                End If
            End If
        End If
    End Sub

    Private Sub CriaRelacionamentosDataset()
        'Cria relacionamento da table TbPai com TbFilho

        Dim RelacionamentoTbPaiTbFilho As New System.Data.DataRelation("RelacaoPaiFilho", New System.Data.DataColumn() {Me.DatasetTipoGrupoMarketing1.RLCGRPECOGRPMKTFRNPesquisaPai.Columns("CODGRPFRN")}, _
                                                                                   New System.Data.DataColumn() {Me.DatasetTipoGrupoMarketing1.RLCGRPECOGRPMKTFRNPesquisaFilho.Columns("CODGRPFRN")})

        Me.DatasetTipoGrupoMarketing1.Relations.Add(RelacionamentoTbPaiTbFilho)
    End Sub

    Private Sub ConfiguraLayoutGridBand1()
        With Me.grdRelacaoGrupoEconomico.Bands(1)
            .Indentation = 15
            'For i As Integer = 0 To 4
            .Columns(0).Hidden = True
            .Columns(0).Width = Unit.Pixel(25)
            'Next
            .Columns(1).Header.Caption = "Cód. Fornecedor"
            .Columns(1).Width = Unit.Pixel(100)
            .Columns(1).Header.Style.HorizontalAlign = HorizontalAlign.Center
            .Columns(1).CellStyle.HorizontalAlign = HorizontalAlign.Center
            .Columns(2).Header.Caption = "Nome Fornecedor"
            .Columns(2).Width = Unit.Pixel(250)
        End With
    End Sub

    Private Sub DesmarcarTodas()
        For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdRelacaoGrupoEconomico.Rows
            linha.Cells.Item(0).Value = False
        Next
    End Sub

    Private Sub MarcarTodas()
        For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdRelacaoGrupoEconomico.Rows
            linha.Cells.Item(0).Value = True
        Next
    End Sub

    Private Sub MontarDadosGridPlanilha()
        Dim dsPlanilha As New DataSet
        Dim CODGRPFRN As Decimal
        Dim TIPGRPMKTFRN As Decimal
        Dim erroCODGRPFRN As String = String.Empty
        Dim erroTIPGRPMKTFRN As String = String.Empty
        Dim erro As String = String.Empty
        Dim IN_CODGRPFRN As String = String.Empty
        Dim dsT0107579 As New wsAcoesComerciais.DatasetTipoGrupoMarketing
        Dim dsCADTIPGRPMKTFRN As New wsAcoesComerciais.DatasetTipoGrupoMarketing
        Dim RLCGRPECOGRPMKTFRNPesquisaPaiRow As wsAcoesComerciais.DatasetTipoGrupoMarketing.RLCGRPECOGRPMKTFRNPesquisaPaiRow
        Dim RLCGRPECOGRPMKTFRNPesquisaPaiRowValida As wsAcoesComerciais.DatasetTipoGrupoMarketing.RLCGRPECOGRPMKTFRNPesquisaPaiRow

        dsPlanilha = WSCAcoesComerciais.dsPlanilha
        If dsPlanilha.Tables.Count > 0 Then
            If dsPlanilha.Tables(0).Rows.Count > 0 Then
                For aux As Integer = 0 To dsPlanilha.Tables(0).Rows.Count - 1
                    RLCGRPECOGRPMKTFRNPesquisaPaiRow = Me.DatasetTipoGrupoMarketing1.RLCGRPECOGRPMKTFRNPesquisaPai.NewRLCGRPECOGRPMKTFRNPesquisaPaiRow

                    If Not IsDBNull(dsPlanilha.Tables(0).Rows(aux)(0)) Then
                        CODGRPFRN = CType(dsPlanilha.Tables(0).Rows(aux)(0), Decimal)
                    Else
                        erro = "Existe(m) código(s) do Grupo Econômico não informado(s) na planilha."
                        RedirecionaPagina(erro)
                    End If

                    If Not IsDBNull(dsPlanilha.Tables(0).Rows(aux)(1)) Then
                        TIPGRPMKTFRN = CType(dsPlanilha.Tables(0).Rows(aux)(1), Decimal)
                    Else
                        erro = "Existe(m) código(s) do Grupo de Marketing não informado(s) na planilha."
                        RedirecionaPagina(erro)
                    End If

                    dsT0107579 = Controller.ObterGrupoEconomicoPorAtributo(1, 1, CODGRPFRN, String.Empty, String.Empty, Nothing, Nothing, 0, 0)

                    RLCGRPECOGRPMKTFRNPesquisaPaiRowValida = Me.DatasetTipoGrupoMarketing1.RLCGRPECOGRPMKTFRNPesquisaPai.FindByCODGRPFRN(CODGRPFRN)

                    If Not RLCGRPECOGRPMKTFRNPesquisaPaiRowValida Is Nothing Then
                        erro = "Código do Grupo Econômico duplicado! Código:" & CODGRPFRN
                        RedirecionaPagina(erro)
                    End If

                    If IN_CODGRPFRN = String.Empty Then
                        IN_CODGRPFRN = CODGRPFRN.ToString
                    Else
                        IN_CODGRPFRN &= ", " & CODGRPFRN.ToString
                    End If

                    If dsT0107579.T0107579.Rows.Count > 0 Then
                        dsCADTIPGRPMKTFRN = Controller.ObterTipoGrupoMarketingPorChave(TIPGRPMKTFRN)

                        If dsCADTIPGRPMKTFRN.CADTIPGRPMKTFRN.Rows.Count > 0 Then
                            With RLCGRPECOGRPMKTFRNPesquisaPaiRow
                                .CODGRPFRN = CODGRPFRN
                                .NOMGRPFRN = dsT0107579.T0107579(0).NOMGRPFRN
                                .TIPGRPMKTFRN = TIPGRPMKTFRN
                                .DESGRPMKTFRN = dsCADTIPGRPMKTFRN.CADTIPGRPMKTFRN(0).DESGRPMKTFRN

                                If dsCADTIPGRPMKTFRN.CADTIPGRPMKTFRN(0).INDORIVBAMKT = 0 Then
                                    .INDORIVBAMKT = "NENHUM"
                                ElseIf dsCADTIPGRPMKTFRN.CADTIPGRPMKTFRN(0).INDORIVBAMKT = 1 Then
                                    .INDORIVBAMKT = "CONTRATO"
                                ElseIf dsCADTIPGRPMKTFRN.CADTIPGRPMKTFRN(0).INDORIVBAMKT = 2 Then
                                    .INDORIVBAMKT = "CMV"
                                End If

                                .PERGRPMKTFRN = dsCADTIPGRPMKTFRN.CADTIPGRPMKTFRN(0).PERGRPMKTFRN
                            End With
                            Me.DatasetTipoGrupoMarketing1.RLCGRPECOGRPMKTFRNPesquisaPai.AddRLCGRPECOGRPMKTFRNPesquisaPaiRow(RLCGRPECOGRPMKTFRNPesquisaPaiRow)
                        Else
                            If erroTIPGRPMKTFRN = String.Empty Then
                                erroTIPGRPMKTFRN = TIPGRPMKTFRN.ToString
                            Else
                                erroTIPGRPMKTFRN &= ", " & TIPGRPMKTFRN.ToString
                            End If
                        End If
                    Else
                        If erroCODGRPFRN = String.Empty Then
                            erroCODGRPFRN = CODGRPFRN.ToString
                        Else
                            erroCODGRPFRN &= ", " & CODGRPFRN.ToString
                        End If
                    End If
                Next

                If erroTIPGRPMKTFRN = String.Empty And erroCODGRPFRN = String.Empty Then
                    Me.DatasetTipoGrupoMarketing1.Merge(Controller.ObterRelacaoGrupoMarketingPesquisaFilho(IN_CODGRPFRN))
                    'CriaRelacionamentosDataset()
                    grdRelacaoGrupoEconomico.DataBind()
                    ConfiguraLayoutGridBand1()
                Else
                    erro = "Código(s) do Grupo Econômico do Fornecedor inválido(s):" & erroCODGRPFRN & _
                                          "|Código(s) do Grupo Marketing do Fornecedor inválido(s):" & erroTIPGRPMKTFRN & _
                                          "|Faça a correção da planilha e faça a importação novamente."
                    RedirecionaPagina(erro)
                End If
            End If
        End If
    End Sub
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

    Private Sub ConsistirDadosGrid()
        If VerificaSelecaoGrid() Then
            SalvarDados()
        Else
            Util.AdicionaJsAlert(Me.Page, "Selecione um ou mais registros!", True)
        End If
    End Sub

    Private Function VerificaSelecaoGrid() As Boolean
        For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In grdRelacaoGrupoEconomico.Rows
            If CType(linha.Cells.Item(0).Value, Boolean) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub SalvarDados()
        
        If cmbGrupoMarketingPercentuais.Enabled Then
            'SalvoDadosPesquisa
            SalvaDadosPesquisa()
        Else
            'SalvoDadosPlanilha
            SalvaDadosPlanilha()
        End If

    End Sub

    Private Sub SalvaDadosPesquisa()
        Dim dsRLCGRPECOGRPMKTFRN As New wsAcoesComerciais.DatasetTipoGrupoMarketing
        Dim CODGRPFRN As Decimal
        Dim TIPGRPMKTFRN As Decimal
        Dim RLCGRPECOGRPMKTFRNRow As wsAcoesComerciais.DatasetTipoGrupoMarketing.RLCGRPECOGRPMKTFRNRow


        For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In grdRelacaoGrupoEconomico.Rows
            If CType(linha.Cells.FromKey("Sel").Value, Boolean) Then
                CODGRPFRN = CType(linha.Cells.FromKey("CODGRPFRN").Value, Decimal)

                Me.DatasetTipoGrupoMarketing1 = Controller.ObterRelacaoGrupoMarketingPorAtributo(0, CODGRPFRN)

                If Me.DatasetTipoGrupoMarketing1.RLCGRPECOGRPMKTFRN.Rows.Count > 0 Then
                    RLCGRPECOGRPMKTFRNRow = Me.DatasetTipoGrupoMarketing1.RLCGRPECOGRPMKTFRN(0)
                Else
                    RLCGRPECOGRPMKTFRNRow = dsRLCGRPECOGRPMKTFRN.RLCGRPECOGRPMKTFRN.NewRLCGRPECOGRPMKTFRNRow
                End If

                If cmbGrupoMarketingPercentuais.SelectedItem.Text.ToUpper.Trim = "SELECIONE" Then
                    Util.AdicionaJsAlert(Me.Page, "Selecione o Grupo de Marketing antes de salvar os registros!", True)
                    Exit Sub
                End If

                TIPGRPMKTFRN = CType(Trim(Split(cmbGrupoMarketingPercentuais.SelectedItem.Text, "-")(0)), Decimal)

                With RLCGRPECOGRPMKTFRNRow
                    .CODGRPFRN = CODGRPFRN
                    .TIPGRPMKTFRN = TIPGRPMKTFRN
                End With

                If Me.DatasetTipoGrupoMarketing1.RLCGRPECOGRPMKTFRN.Rows.Count = 0 Then
                    dsRLCGRPECOGRPMKTFRN.RLCGRPECOGRPMKTFRN.AddRLCGRPECOGRPMKTFRNRow(RLCGRPECOGRPMKTFRNRow)
                Else
                    dsRLCGRPECOGRPMKTFRN = Me.DatasetTipoGrupoMarketing1
                End If
                Controller.AtualizarRelacaoGrupoMarketing(dsRLCGRPECOGRPMKTFRN)
                dsRLCGRPECOGRPMKTFRN.RLCGRPECOGRPMKTFRN.Rows.Clear()
            End If
        Next
        RedirecionaPagina()
    End Sub

    Private Sub SalvaDadosPlanilha()
        Dim CODGRPFRN As Decimal
        Dim TIPGRPMKTFRN As Decimal
        Dim RLCGRPECOGRPMKTFRNRow As wsAcoesComerciais.DatasetTipoGrupoMarketing.RLCGRPECOGRPMKTFRNRow

        For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In grdRelacaoGrupoEconomico.Rows
            If CType(linha.Cells.FromKey("Sel").Value, Boolean) Then
                CODGRPFRN = CType(linha.Cells.FromKey("CODGRPFRN").Value, Decimal)

                Me.DatasetTipoGrupoMarketing1 = Controller.ObterRelacaoGrupoMarketingPorAtributo(0, CODGRPFRN)

                If Me.DatasetTipoGrupoMarketing1.RLCGRPECOGRPMKTFRN.Rows.Count > 0 Then
                    RLCGRPECOGRPMKTFRNRow = Me.DatasetTipoGrupoMarketing1.RLCGRPECOGRPMKTFRN(0)
                Else
                    RLCGRPECOGRPMKTFRNRow = Me.DatasetTipoGrupoMarketing1.RLCGRPECOGRPMKTFRN.NewRLCGRPECOGRPMKTFRNRow
                End If

                TIPGRPMKTFRN = CType(linha.Cells.FromKey("TIPGRPMKTFRN").Value, Decimal)

                With RLCGRPECOGRPMKTFRNRow
                    .CODGRPFRN = CODGRPFRN
                    .TIPGRPMKTFRN = TIPGRPMKTFRN
                End With

                If Me.DatasetTipoGrupoMarketing1.RLCGRPECOGRPMKTFRN.Rows.Count = 0 Then
                    Me.DatasetTipoGrupoMarketing1.RLCGRPECOGRPMKTFRN.AddRLCGRPECOGRPMKTFRNRow(RLCGRPECOGRPMKTFRNRow)
                End If

                Controller.AtualizarRelacaoGrupoMarketing(Me.DatasetTipoGrupoMarketing1)
                Me.DatasetTipoGrupoMarketing1.RLCGRPECOGRPMKTFRN.Rows.Clear()
            End If
        Next
        RedirecionaPagina()
    End Sub
#End Region

End Class