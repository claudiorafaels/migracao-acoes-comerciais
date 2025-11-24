Imports Martins.Security.Helper

Public Class Contrato
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dsContrato = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContrato
        CType(Me.dsContrato, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'dsContrato
        '
        Me.dsContrato.DataSetName = "DatasetContrato"
        Me.dsContrato.EnforceConstraints = False
        Me.dsContrato.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.dsContrato, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtCODSITPMS As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents cmdCancelarContrato As System.Web.UI.WebControls.LinkButton
    Protected WithEvents webTab As Infragistics.WebUI.UltraWebTab.UltraWebTab
    Friend WithEvents dsContrato As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContrato
    Protected WithEvents txtNroCnt As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents lblErroFornecedor As System.Web.UI.WebControls.Label
    Protected WithEvents lblErrotxtNroCnt As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object
    Protected WithEvents btnSalvarEContinuar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow

    Private mflagInclusao As Int16 = -1

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region " Propriedades "

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

    Private ReadOnly Property ucCapa() As ucContratoCapa
        Get
            Dim result As ucContratoCapa
            result = CType(webTab.Tabs.GetTab(0).FindControl("ucContratoCapa"), ucContratoCapa)
            Return result
        End Get
    End Property

    Private ReadOnly Property ucClausula() As ucContratoClausula
        Get
            Dim result As ucContratoClausula
            result = CType(webTab.Tabs.GetTab(1).FindControl("ucContratoClausula"), ucContratoClausula)
            Return result
        End Get
    End Property

    Private ReadOnly Property ucAbrangencia() As ucContratoAbrangencia
        Get
            Dim result As ucContratoAbrangencia
            result = CType(webTab.Tabs.GetTab(2).FindControl("ucContratoAbrangencia"), ucContratoAbrangencia)
            Return result
        End Get
    End Property

    Private ReadOnly Property ucAditamento() As ucAditamento
        Get
            Dim result As ucAditamento
            result = CType(webTab.Tabs.GetTab(3).FindControl("ucAditamento"), ucAditamento)
            Return result
        End Get
    End Property

    Private ReadOnly Property ucFaixa() As ucContratoFaixa
        Get
            Dim result As ucContratoFaixa
            result = CType(webTab.Tabs.GetTab(4).FindControl("ucContratoFaixa"), ucContratoFaixa)
            Return result
        End Get
    End Property

    Private ReadOnly Property ucPeriodo() As ucContratoPeriodo
        Get
            Dim result As ucContratoPeriodo
            result = CType(webTab.Tabs.GetTab(5).FindControl("ucContratoPeriodo"), ucContratoPeriodo)
            Return result
        End Get
    End Property

    Private ReadOnly Property ucMercadoriaExcludente() As ucContratoMercadoriaExcludente
        Get
            Dim result As ucContratoMercadoriaExcludente
            result = CType(webTab.Tabs.GetTab(6).FindControl("ucContratoMercadoriaExcludente"), ucContratoMercadoriaExcludente)
            Return result
        End Get
    End Property

    Private ReadOnly Property ucContratoAssociacao() As ucContratoAssociacao
        Get
            Dim result As ucContratoAssociacao
            result = CType(webTab.Tabs.GetTab(7).FindControl("ucContratoAssociacao"), ucContratoAssociacao)
            Return result
        End Get
    End Property

    Private ReadOnly Property ucContratoAbrangenciaXFiliado() As ucContratoAbrangenciaXFiliado
        Get
            Dim result As ucContratoAbrangenciaXFiliado
            result = CType(webTab.Tabs.GetTab(8).FindControl("ucContratoAbrangenciaXFiliado"), ucContratoAbrangenciaXFiliado)
            Return result
        End Get
    End Property

    Private ReadOnly Property ucCondicaoPagamento() As ucContratoCondicaoPagamento
        Get
            Dim result As ucContratoCondicaoPagamento
            result = CType(webTab.Tabs.GetTab(9).FindControl("ucContratoCondicaoPagamento"), ucContratoCondicaoPagamento)
            Return result
        End Get
    End Property

    Private ReadOnly Property ucTabelaDePrecos() As ucContratoTabelaDePrecos
        Get
            Dim result As ucContratoTabelaDePrecos
            result = CType(webTab.Tabs.GetTab(10).FindControl("ucContratoTabelaDePrecos"), ucContratoTabelaDePrecos)
            Return result
        End Get
    End Property

    Private ReadOnly Property ucFormaDePagamento() As ucContratoFormaDePagamento
        Get
            Dim result As ucContratoFormaDePagamento
            result = CType(webTab.Tabs.GetTab(11).FindControl("ucContratoFormaDePagamento"), ucContratoFormaDePagamento)
            Return result
        End Get
    End Property

    Private ReadOnly Property ucCondicoesDeFrete() As ucContratoCondicoesDeFrete
        Get
            Dim result As ucContratoCondicoesDeFrete
            result = CType(webTab.Tabs.GetTab(12).FindControl("ucContratoCondicoesDeFrete"), ucContratoCondicoesDeFrete)
            Return result
        End Get
    End Property

    Private ReadOnly Property ucServicos() As ucContratoServicos
        Get
            Dim result As ucContratoServicos
            result = CType(webTab.Tabs.GetTab(13).FindControl("ucContratoServicos"), ucContratoServicos)
            Return result
        End Get
    End Property

    Private ReadOnly Property ucRelacionamentos() As ucContratoRelacionamentos
        Get
            Dim result As ucContratoRelacionamentos
            result = CType(webTab.Tabs.GetTab(14).FindControl("ucContratoRelacionamentos"), ucContratoRelacionamentos)
            Return result
        End Get
    End Property

    Public Property flagInclusao() As Boolean
        Get
            If mflagInclusao = 0 Then
                Return False
            ElseIf mflagInclusao = 1 Then
                Return True
            ElseIf Not ViewState("flagInclusao") Is Nothing Then
                Return CType(ViewState("flagInclusao"), Boolean)
            Else
                Return False
            End If
        End Get
        Set(ByVal Value As Boolean)
            ViewState("flagInclusao") = Value
            If Value = True Then
                mflagInclusao = 1
            Else
                mflagInclusao = 0
            End If
        End Set
    End Property

    'Public Enum PageState As Integer
    '    SemAcao = 0
    '    NovoRegistro = 1
    '    EdicaoRegistro = 2
    'End Enum

    Public Property NUMCTTFRN() As Integer
        Get
            Return Me.txtNroCnt.ValueInt
        End Get
        Set(ByVal Value As Integer)
            Me.txtNroCnt.ValueInt = Value
        End Set
    End Property

    Public ReadOnly Property CODFRN() As Decimal
        Get
            Return Me.ucFornecedor.CodFornecedor
        End Get
    End Property

    Public ReadOnly Property TIPPODCTTFRN() As Decimal
        Get
            Return ucCapa.TIPPODCTTFRN
        End Get
    End Property

    Public ReadOnly Property DATINIPODVGRCTTFRN() As Date
        Get
            Return ucCapa.DATINIPODVGRCTTFRN
        End Get
    End Property

    Public ReadOnly Property DATVNCCTTFRN() As Date
        Get
            Return ucCapa.DATVNCCTTFRN
        End Get
    End Property

    Public ReadOnly Property SelectedTab() As Integer
        Get
            Return Me.webTab.SelectedTab()
        End Get
    End Property

    Public ReadOnly Property flagContratoAtivo() As Boolean
        Get
            If Me.dsContrato.T0124945.Rows.Count > 0 Then
                If Me.dsContrato.T0124945(0).IsDATDSTCTTFRNNull() Then
                    Return True
                End If
            End If
            Return False
        End Get
    End Property

    Private ReadOnly Property quantidadeLinhasValidasEmT0124996() As Integer
        Get
            Dim result As Integer = 0
            For Each linha As wsAcoesComerciais.DatasetContrato.T0124996Row In Me.dsContrato.T0124996
                If linha.RowState <> DataRowState.Deleted Then
                    result += 1
                End If
            Next
            Return result
        End Get
    End Property

    Private ReadOnly Property quantidadeLinhasValidasEmT0124961() As Integer
        Get
            Dim result As Integer = 0
            For Each linha As wsAcoesComerciais.DatasetContrato.T0124961Row In Me.dsContrato.T0124961
                If linha.RowState <> DataRowState.Deleted Then
                    result += 1
                End If
            Next
            Return result
        End Get
    End Property

#End Region

#Region " Eventos "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not IsPostBack Then
                Me.InicializaPagina()
            Else
                Me.RecuperaEstado()
            End If
            btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
            btnSalvarEContinuar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
            btnCancelar.Attributes.Add("OnClick", "javascript:mostraAndamento()")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        Try
            Me.SalvaEstado()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            If flagProcessando Then
                Exit Sub
            End If
            flagProcessando = True
            Atualizar()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        Finally
            flagProcessando = False
        End Try
    End Sub

    Private Sub btnSalvarEContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvarEContinuar.Click
        Try
            If flagProcessando Then
                Exit Sub
            End If
            flagProcessando = True
            SalvarEContinuar()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        Finally
            flagProcessando = False
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("ContratoListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmdCancelarContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelarContrato.Click
        Me.dsContrato.T0124945(0).DATDSTCTTFRN = Date.Today.Date
        Util.AdicionaJsAlert(Me.Page, "Contrato desativado, click em salvar para concluir ou sair para desistir da desativação")
    End Sub

    Private Sub ucFornecedor_FornecedorAlterado(ByVal e As System.Web.UI.WebControls.ListItem) Handles ucFornecedor.FornecedorAlterado
        Try
            ucCapa.CarregarDdlTipCttFrn(ucFornecedor.CodFornecedor)
            MostrarOuEsconderTabAbrangenciaXFiliado()

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
        Try
            ExcluirContrato()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#Region " Metodos "

#Region " Metodos Carga "

    Private Sub InicializaPagina()
        If Not (Request.QueryString("numcttfrn") Is Nothing) Then
            'Alteração
            flagInclusao = False
            TransferirDadosDoDatasetParaFormulario(Convert.ToDecimal(Request.QueryString("numcttfrn")))
            If Not (Request.QueryString("tab") Is Nothing) Then
                webTab.SelectedTab = Convert.ToInt32(Request.QueryString("tab"))
            End If
            If flagContratoAtivo = False Then
                btnSalvar.Enabled = False
                cmdCancelarContrato.Enabled = False
            End If
            MostrarOuEsconderTabAbrangenciaXFiliado()
        Else
            'Novo
            flagInclusao = True
            txtNroCnt.ValueInt = -1
            InserirContrato()
            CarregarClausulas()
        End If
        cmdCancelarContrato.Attributes.Add("OnClick", "javascript:return confirm('Deseja desativar esse contrato?')")
        btnApagar.Attributes.Add("OnClick", "javascript:return confirm('Deseja excluir o contrato?')")
    End Sub

    Private Sub CarregarClausulas()
        dsContrato.Merge(Controller.ObterClausulasContrato("", 0).T0124953, False, MissingSchemaAction.Ignore)
    End Sub

    Private Sub RecuperaEstado()
        If Not WSCAcoesComerciais.dsContrato Is Nothing Then
            dsContrato = WSCAcoesComerciais.dsContrato()
        End If
    End Sub

    Private Sub SalvaEstado()
        WSCAcoesComerciais.dsContrato = dsContrato
    End Sub

    Private Sub TransferirDadosDoDatasetParaFormulario(ByVal NUMCTTFRN As Decimal)
        Try
            getContratoByNumCttFrn(NUMCTTFRN)
            PreencheControles(NUMCTTFRN)
            Me.ucCapa.PreencheControles(dsContrato)
            Me.ucCondicaoPagamento.PreencheControles(dsContrato)
            Me.ucTabelaDePrecos.PreencheControles(dsContrato)
            Me.ucFormaDePagamento.PreencheControles(dsContrato)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub PreencheControles(ByVal NUMCTTFRN As Decimal)
        Dim linha As wsAcoesComerciais.DatasetContrato.T0124945Row = getContratoByNumCttFrn(NUMCTTFRN)

        ucFornecedor.SelecionarFornecedor(linha.CODFRN)
        Me.txtNroCnt.ValueDecimal = linha.NUMCTTFRN
    End Sub

    Public Function getContratoByNumCttFrn(ByVal NumCttFrn As Decimal) As wsAcoesComerciais.DatasetContrato.T0124945Row
        If Me.dsContrato.T0124945.FindByNUMCTTFRN(NumCttFrn) Is Nothing Then
            Me.dsContrato.Merge(Controller.ObterContrato(NumCttFrn), False, MissingSchemaAction.Ignore)
            Return getContratoByNumCttFrn(NumCttFrn)
        Else
            Return Me.dsContrato.T0124945.FindByNUMCTTFRN(NumCttFrn)
        End If
    End Function

    Private Sub MostrarOuEsconderTabAbrangenciaXFiliado()
        Dim ds As wsAcoesComerciais.dataSetDivisaoFornecedor

        webTab.Tabs.GetTab(8).Visible = False
        If ucFornecedor.CodFornecedor = 0 Then
            Exit Sub
        End If

        If dsContrato.T0100426.Rows.Count > 0 Then
            If dsContrato.T0100426(0).IsNull("TIPIDTEMPASCACOCMC") Then
                Exit Sub
            End If
            If dsContrato.T0100426(0).TIPIDTEMPASCACOCMC = 2 Then
                webTab.Tabs.GetTab(8).Visible = True
            End If
            Exit Sub
        End If

        ds = Controller.ObterDivisaoFornecedor(1, Convert.ToInt32(ucFornecedor.CodFornecedor))
        If ds.T0100426.Rows.Count > 0 Then
            If ds.T0100426(0).IsNull("TIPIDTEMPASCACOCMC") Then
                Exit Sub
            End If
            If ds.T0100426(0).TIPIDTEMPASCACOCMC = 2 Then
                webTab.Tabs.GetTab(8).Visible = True
            End If
            Exit Sub
        End If
    End Sub

#End Region

#Region " Metodos Controles "

    Public Sub carregarClausulasNasTabs()
        ucAbrangencia.CarregaDDLClausulas()
        ucFaixa.CarregaDDLClausulas()
        ucPeriodo.CarregarCmbNUMCSLCTTFRN()
        ucMercadoriaExcludente.CarregarCmbNUMCSLCTTFRN()
    End Sub

    Public Sub atualizarGridNaTabClausulas()
        ucClausula.CarregaGrdClausulas(True)
    End Sub

#End Region

#Region " Regras de Negocio "

    Private Sub Atualizar()
        Try
            If validar() Then
                transferirDadosParaDataset(dsContrato)
                Controller.AtualizarContrato(dsContrato)
                Response.Redirect("ContratoListar.aspx")
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Public Sub SalvarEContinuar()
        Try
            'Me.RecuperaEstado()
            transferirDadosParaDataset(dsContrato)
            Controller.AtualizarContrato(dsContrato)
            Response.Redirect("Contrato.aspx?numcttfrn=" & Me.NUMCTTFRN.ToString & "&tab=" & SelectedTab.ToString)

            'Response.Write("<script language=javascript>" & vbCrLf)
            'Response.Write("window.parent.location.href = ""Contrato.aspx?numcttfrn=" & Me.NUMCTTFRN.ToString & "&tab=" & SelectedTab.ToString & """;" & vbCrLf)
            'Response.Write("</script>" & vbCrLf)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function validar() As Boolean
        'Valida o contrato
        If Not ValidarContrato() Then
            Return False
        End If
        'Validar capa
        If Not ucCapa.Validar Then
            webTab.SelectedTab = 0
            Return False
        End If

        'Não validar as informações abaixo por solicitação da Elisangela em 07/02/2007
        ''Validar condição de pagamento
        'If Not ucCondicaoPagamento.Validar Then
        '    webTab.SelectedTab = 8
        '    Return False
        'End If
        ''Validar Tabela de preços
        'If Not ucTabelaDePrecos.Validar Then
        '    webTab.SelectedTab = 9
        '    Return False
        'End If
        ''Validar Forma de pagamento
        'If Not ucFormaDePagamento.Validar Then
        '    webTab.SelectedTab = 10
        '    Return False
        'End If

        Return True
    End Function

    Private Function ValidarContrato() As Boolean
        Dim result As Boolean
        Dim mensagemErro As String = String.Empty
        Dim deuFoco As Boolean

        Try
            'Contrato
            If txtNroCnt.ValueDecimal <= 0 Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "número de contrato inválido"
                'Foco
                If Not deuFoco Then
                    Util.AdicionaJsFocus(Me.Page, CType(txtNroCnt, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                    deuFoco = True
                End If
                'Indicador erro
                lblErroFornecedor.Visible = True
            Else
                lblErrotxtNroCnt.Visible = False
            End If

            'Fornecedor
            If ucFornecedor.CodFornecedor = 0 Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "é obrigatório informar o fornecedor"
                'Foco
                If Not deuFoco Then
                    Util.AdicionaJsFocus(Me.Page, CType(ucFornecedor.FindControl("txtCodigo"), WebControl), Util.tipoDeComponente.InfragisticsTxt)
                    deuFoco = True
                End If
                'Indicador erro
                lblErroFornecedor.Visible = True
            Else
                lblErroFornecedor.Visible = False
            End If

            'Verifica se existe abrangencia para todas cláusulas
            For Each linha As wsAcoesComerciais.DatasetContrato.T0124961Row In Me.dsContrato.T0124961
                If linha.GetT0124996Rows.Length = 0 Then
                    'Mensagem
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "é obrigatório digitar abrangencia para todas clausulas cadastradas"
                    webTab.SelectedTab = 2
                    Exit For
                End If
            Next

            'Verifica se existe período para todas clausulas 
            For Each linha As wsAcoesComerciais.DatasetContrato.T0124961Row In Me.dsContrato.T0124961
                If linha.GetT0124988Rows.Length = 0 Then
                    'Mensagem
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "é obrigatório digitar período para todas clausulas cadastradas, não encontrado período para cláusula:" & linha.NUMCSLCTTFRN.ToString
                    webTab.SelectedTab = 3
                    Exit For
                End If
            Next

            'Verifica sem todas abrangencia se existe faixa
            For Each linha As wsAcoesComerciais.DatasetContrato.T0124996Row In Me.dsContrato.T0124996
                If linha.FLGCALVLRRCBFXACRS = "*" Then
                    If linha.GetT0125038Rows.Length = 0 Then
                        'Mensagem
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "

                        mensagemErro &= "é obrigatório digitar faixa para" & _
                                        " cláusula:" & linha.NUMCSLCTTFRN.ToString & _
                                        " tipo de abrangencia:" & linha.TIPEDEABGMIX.toString & ", " & _
                                        " código de abrangencia:" & Linha.CODEDEABGMIX.ToString

                        webTab.SelectedTab = 3
                        Exit For
                    End If
                End If
            Next

            'Verifica sem todas abrangencia se existe mercadoria excludente
            For Each linha As wsAcoesComerciais.DatasetContrato.T0124996Row In Me.dsContrato.T0124996
                If linha.FLGMERECS = "*" Or linha.FLGTRTMERNVO = "*" Then
                    If linha.T0124961RowParent.GetT0125020Rows.Length = 0 Then
                        'Mensagem
                        If mensagemErro.Length > 0 Then mensagemErro &= ", "
                        mensagemErro &= "é obrigatório digitar mercadoria excludente para cláusula:" & linha.NUMCSLCTTFRN.ToString & " abrangencia:" & linha.TIPEDEABGMIX.toString
                        webTab.SelectedTab = 3
                        Exit For
                    End If
                End If
            Next

            'Mostra mensagem de erro
            If mensagemErro.Trim() <> String.Empty Then
                Page.RegisterStartupScript("Alerta", "<script>alert('" & (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1) & "');</script>")
                Return False
            End If

            Return True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Function

    Public Function transferirDadosParaDataset(ByVal ds As wsAcoesComerciais.DatasetContrato) As wsAcoesComerciais.DatasetContrato
        'Transfere Contrato (esse formulário)
        ds = Me.transferirDadosParaDatasetContrato(ds)
        'Transfere capa
        ds = ucCapa.transferirDadosParaDataset(ds)
        'Transfere Condição pagamento
        ds = ucCondicaoPagamento.transferirDadosParaDataset(ds)
        'Transfere Tabela Preços
        ds = ucTabelaDePrecos.transferirDadosParaDataset(ds)
        'Transfere Forma de pagamento
        ds = ucFormaDePagamento.transferirDadosParaDataset(ds)

        'Coloca data de inicio de utilização das faixa = data de vigoração 
        'da tab geral, solicitação da Elisangela em 07/02/07
        For Each linha As wsAcoesComerciais.DatasetContrato.T0125038Row In Me.dsContrato.T0125038
            If linha.RowState <> DataRowState.Deleted Then
                If linha.DATREFINIUTZPMT <> Me.DATINIPODVGRCTTFRN.Date Then
                    linha.BeginEdit()
                    linha.DATREFINIUTZPMT = Me.DATINIPODVGRCTTFRN.Date
                    linha.EndEdit()
                End If
            End If
        Next

        Return ds
    End Function

    Private Function transferirDadosParaDatasetContrato(ByVal ds As wsAcoesComerciais.DatasetContrato) As wsAcoesComerciais.DatasetContrato
        Dim dr As wsAcoesComerciais.DatasetContrato.T0124945Row = ds.T0124945(0)

        dr.NUMCTTFRN = txtNroCnt.ValueDecimal
        dr.CODFRN = ucFornecedor.CodFornecedor

        Return ds
    End Function

    Private Function InserirContrato() As Boolean
        'Obtem uma nova linha do contrato
        If Me.NUMCTTFRN <= 0 Then
            Dim dr As wsAcoesComerciais.DatasetContrato.T0124945Row = Me.dsContrato.T0124945.NewT0124945Row()

            'Consulta o próximo número do contrato na tabela de parametros
            Dim dsParametro As wsAcoesComerciais.dataSetParametro
            dsParametro = Controller.ObterParametroSistemaNegociacaoFornecedor(1)

            'Transfere a linha o número do contrato do parametro para tabela de contrato
            dr.NUMCTTFRN = dsParametro.T0114095.Item(0).NUMULTCTTFRN + 1
            txtNroCnt.ValueDecimal = dr.NUMCTTFRN

            'Incrementa o último número do contrato
            dsParametro.T0114095.Item(0).NUMULTCTTFRN += 1
            Controller.AtualizarParametroNegociacaoFornecedor(dsParametro)

            'Inser a linha na tabela de contrato
            Me.dsContrato.T0124945.AddT0124945Row(dr)

            Me.SalvaEstado()
        End If

        Return True
    End Function

    Private Sub ExcluirContrato()
        Try
            'Valida
            If Me.existeApuracaoParaEsseContrato Then
                Util.AdicionaJsAlert(MyBase.Page, "Existe apuração para esse contrato, exclusão não permitida")
                Exit Sub
            End If
            'Localiza a linha
            Dim row As wsAcoesComerciais.DatasetContrato.T0124945Row
            row = Me.dsContrato.T0124945.FindByNUMCTTFRN(Me.NUMCTTFRN)
            If row Is Nothing Then
                Util.AdicionaJsAlert(MyBase.Page, "Não foi localizado a linha do contrato")
                Exit Sub
            End If
            'Exclui
            row.Delete()
            'Salva e redireciona
            Controller.AtualizarContrato(dsContrato)
            Response.Redirect("ContratoListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Public Function existeApuracaoParaEsseContrato() As Boolean
        Try
            Dim ds As wsAcoesComerciais.DatasetEntidade
            Dim result As Boolean = False

            ds = Controller.ObterEntidades(0, 0, 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, 0, Me.NUMCTTFRN, 0, 0, 0, 0)
            If ds.T0125046.Rows.Count > 0 Then
                result = True
            End If

            Return result
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Public Function existeApuracaoParaEsseContrato(ByVal NUMCSLCTTFRN As Decimal) As Boolean
        Try
            Dim ds As wsAcoesComerciais.DatasetEntidade
            Dim result As Boolean = False

            ds = Controller.ObterEntidades(0, 0, 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, NUMCSLCTTFRN, Me.NUMCTTFRN, 0, 0, 0, 0)
            If ds.T0125046.Rows.Count > 0 Then
                result = True
            End If

            Return result
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Public Function existeFaixaParaClausula(ByVal NUMCSLCTTFRN As Decimal) As Boolean
        Try
            'Verifica se existe registro da cláusula 
            Dim linha As wsAcoesComerciais.DatasetContrato.T0124953Row
            linha = dsContrato.T0124953.FindByNUMCSLCTTFRN(NUMCSLCTTFRN)
            If linha Is Nothing Then
                Return False
            End If

            'Verifica se existe no mínimo 1 faixa cadastrada
            If dsContrato.T0124996.Select("NUMCSLCTTFRN = " & NUMCSLCTTFRN.ToString).Length < 1 Then
                Return False
            End If

            Return True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

#End Region

#End Region

End Class