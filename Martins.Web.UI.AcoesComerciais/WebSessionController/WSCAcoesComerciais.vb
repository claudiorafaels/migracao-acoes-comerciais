''' -----------------------------------------------------------------------------
''' Project	 : Martins.Web.UI.AcoesComerciais
''' Class	 : Web.UI.AcoesComerciais.WSCAcoesComerciais
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Classe abstrata para manipular sessão
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Elifazio Bernardes]	11/9/2006	Created
''' </history>
''' -----------------------------------------------------------------------------

Public Enum WSCVar As Integer
    dsUsuarioCompra
    dsAcordo
    dsAcordoACancelarEmFluxoCancelamentoAcordo
    dsFluxoCancelamento
    dsTipoTransferenciaXDivisaoCompras
    dsTipoTransferenciaXFornecedor
    crNomeRelatorio
    dsRelatorioAcordoFornecimento
    dsRelatorioAcordoParaDeduction
    dsRelatorioConferenciaAcaoTatica
    dsRelatorioContasAReceber
    dsRelatorioHistoricoAcordo
    dsRelatorioAcordoAcoesComerciais
    dsRelatorioAnaliticoAcoesComerciais
    dsRelatorioExtratoContaCorrrente
    dsRelatorioRecibo
    dsRelacaoPerdasEmitidas
    dsAgencia
    dsBanco
    dsChREcebidoFornecedor
    dsContrato
    dsEmpenho
    dsformaPagamento
    dsTipoFormaPagamento
    dsParametroGestaoAcaoComercial
    dsContaCorrenteFornecedor
    dsOPRecebidaFornecedor
    dsTipoPedidoCompraxEmpenho
    DsTipoTransferenciaxUsuario
    dsTipoAbrangencia
    dsTipoBaseCalculo
    dsTipoEncargoFinanceiro
    dsTipoFornecedor
    dsTipoLancamentoContacorrenteFornecedor
    dsTipoPagamento
    dsTipoPedidoCompra
    dsTipoRelacionamento
    dsTipoServico
    dsTipoTransferenciaValoresAcoesComerciais
    dsTransferenciaVerbasEntreEmpenhos
    dsTipoUnidadePagamento
    dsSimulacaoSinteticaDeCrescimento
    dsOperacaoBaixaOperacaoFornecedor
    dsRelatorioSaldoDisponivelFornecedorCelula
    dsTipoAbrangenciaMix
    dsUsuarioXCelula
    dsParametroFornecedorMmm
    dsSelecaoValorDisponivelFornecedor
    dsTransferenciaVerbaFornecedor
    dsRelatorioBaixaAcordo
    dsRelatorioHistoricoBaixaOP
    dsRecuperacaoEPrevencaoPerdas
    dsPrevisaoApuracao
    dsPlanilha
    dsTipoGrupoMarketing
    dstVerbaCarimboSelecionado
    dsRelatorioCarimbo
    dsRelatorioHistorico
    dsValoresContabilizadosCarimbos
    dsVerbasCarimbadas
    dsAcordos

    hashtableFormulasCrystal
    hashtableOperacoesOP
    queryString
    crSaidaDiretoPDF
    numFluApv
    NUMPEDCNCACOCMC
    CODFRN
    T0120540Row
    T0118066Row
    FLGSITNGCDUP
    CODPRGICT
    AditamentoRow
    PERPSQSLDFRN
    Empenho
    Filial
    Filtro
    labelFiltro
    Usuario
    Celula
    Comprador
    Diretoria
    Fornecedor
    Periodo
    Tipo
    Descricao
    Mercadoria
    isCarimbo
    DataGeracaoAcordo
    DataPrevisaoRecebimento
    DataInicio
    DataFim
    TipoDesconto

End Enum

Public Class WSCAcoesComerciais

#Region " Declarações "

    Private Shared NomeSession As String = GetType(WSCAcoesComerciais).Name()

#End Region

#Region " Métodos "

#Region " Genericos "

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	28/11/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function IsNewSession() As Boolean
        Return HttpContext.Current.Session.IsNewSession
    End Function

    Private Shared Sub TratarSessionExpirada()
        If HttpContext.Current.Session.IsNewSession Then
            Controller.TrataSecaoExpirada()
        End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' VERIFICA SE A VARIÁVEL ATUAL EXISTE NA SESSÃO.
    ''' </summary>
    ''' <param name="SV">NOME DA VARIAVEL A SER VERIFICADA DO TIPO DO ENUMERADOR DA CLASSE</param>
    ''' <returns>VERDADEIRO SE EXISTE E FALSO CASO CONTRARIO</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Elifazio Bernardes]	11/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Shared Function ValidaSession(ByVal SV As WSCVar) As Boolean
        TratarSessionExpirada()
        Return Not (HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(SV))) Is Nothing)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' RETORNA A STRING CONSTANTE CORRESPONDENTE AO ENUMERADOR PASSADO PARA A FUNÇÃO
    ''' </summary>
    ''' <param name="SV">ENUMERADOR PARA OBTER SEU NOME COMO STRING</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Elifazio Bernardes]	11/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Shared Function GetEnumConstName(ByVal SV As WSCVar) As String
        Return [Enum].GetName(GetType(WSCVar), SV)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' APAGA TODAS AS VARIÁVEIS DE SESSÃO QUE PERTENÇA AO CONTEXTO DESTA CLASSE 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Elifazio Bernardes]	11/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub ClearAllSessionVars()
        Dim SVars As String() = [Enum].GetNames(GetType(WSCVar))
        For Each Var As String In SVars
            HttpContext.Current.Session.Remove(String.Concat(NomeSession, Var))
        Next
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' APAGA A VARIAVEIS DA SESSÃO
    ''' </summary>
    ''' <param name="SV">ENUMERADOR PARA OBTER SEU NOME COMO STRING</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Elifazio Bernardes]	11/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub ClearSessionVar(ByVal SV As WSCVar)
        HttpContext.Current.Session.Remove(String.Concat(NomeSession, GetEnumConstName(SV)))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Metodo para trabalhar com valores inteiros na sessão
    ''' </summary>
    ''' <param name="SV">ENUMERADOR PARA OBTER SEU NOME COMO STRING</param>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Elifazio Bernardes]	11/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property IntegerValue(ByVal SV As WSCVar) As Integer
        Get
            If ValidaSession(SV) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(SV))), Integer)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Integer)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(SV)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Metodo para trabalhar com valores STRING na sessão
    ''' </summary>
    ''' <param name="SV">ENUMERADOR PARA OBTER SEU NOME COMO STRING</param>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Elifazio Bernardes]	11/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property StringValue(ByVal SV As WSCVar) As String
        Get
            If ValidaSession(SV) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(SV))), String)
            Else
                Return String.Empty
            End If
        End Get
        Set(ByVal Value As String)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(SV)), Value)
        End Set
    End Property

    Public Shared Property DecimalValue(ByVal SV As WSCVar) As Decimal
        Get
            If ValidaSession(SV) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(SV))), Decimal)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Decimal)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(SV)), Value)
        End Set
    End Property

    Public Shared Property BooleanValue(ByVal SV As WSCVar) As Boolean
        Get
            If ValidaSession(SV) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(SV))), Boolean)
            Else
                Return False
            End If
        End Get
        Set(ByVal Value As Boolean)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(SV)), Value)
        End Set
    End Property

    Public Shared WriteOnly Property checkSession() As Integer
        Set(ByVal Value As Integer)
            'TratarSessionExpirada() Não vai existir porque sempre que atribuir valor a session vai ser nova
            HttpContext.Current.Session.Add(String.Concat(NomeSession, "Integer"), Value)
        End Set
    End Property

#End Region

#Region " Tipos Complexos "

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' DATASET COM DADOS DO USUARIO LOGADO, A APLICACAO INTEIRA USA
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[ebernardes]	13/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsUsuarioCompra() As wsAcoesComerciais.dataSetUsuarioCompra
        Get
            If ValidaSession(WSCVar.dsUsuarioCompra) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsUsuarioCompra))), wsAcoesComerciais.dataSetUsuarioCompra)
            Else
                WSCAcoesComerciais.dsUsuarioCompra = Controller.ObterUsuariosCompraLogadoSistema()
                Return WSCAcoesComerciais.dsUsuarioCompra
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.dataSetUsuarioCompra)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsUsuarioCompra)), Value)
        End Set
    End Property

    Public Shared Property dstVerbaCarimboSelecionado() As wsAcoesComerciais.DatasetVerbaCarimbo
        Get
            If ValidaSession(WSCVar.dstVerbaCarimboSelecionado) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dstVerbaCarimboSelecionado))), wsAcoesComerciais.DatasetVerbaCarimbo)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetVerbaCarimbo)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dstVerbaCarimboSelecionado)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' DS USADO NA TELA RelacionamentoTransferenciaVerba.aspx, PARA PESQUISA, INSERÇÃO, 
    ''' EDIÇÃO E EXCLUSÃO
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[ebernardes]	13/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsTipoTransferenciaXDivisaoCompras() As wsAcoesComerciais.DatasetTipoTransferenciaXDivisaoCompras
        Get
            If ValidaSession(WSCVar.dsTipoTransferenciaXDivisaoCompras) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoTransferenciaXDivisaoCompras))), wsAcoesComerciais.DatasetTipoTransferenciaXDivisaoCompras)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetTipoTransferenciaXDivisaoCompras)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoTransferenciaXDivisaoCompras)), Value)
        End Set

    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' DS USADO NA TELA RelacionamentoTransferenciaVerba.aspx, PARA PESQUISA, INSERÇÃO, 
    ''' EDIÇÃO E EXCLUSÃO
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[ebernardes]	13/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsTipoTransferenciaXFornecedor() As wsAcoesComerciais.DatasetTipoTransferenciaXFornecedor
        Get
            If ValidaSession(WSCVar.dsTipoTransferenciaXFornecedor) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoTransferenciaXFornecedor))), wsAcoesComerciais.DatasetTipoTransferenciaXFornecedor)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetTipoTransferenciaXFornecedor)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoTransferenciaXFornecedor)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsAcordo() As wsAcoesComerciais.DatasetAcordo
        Get
            If ValidaSession(WSCVar.dsAcordo) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsAcordo))), wsAcoesComerciais.DatasetAcordo)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetAcordo)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsAcordo)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	5/7/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsFluxoCancelamento() As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo
        Get
            If ValidaSession(WSCVar.dsFluxoCancelamento) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsFluxoCancelamento))), wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsFluxoCancelamento)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsAgencia() As wsCobrancaBancaria.DatasetAgencia
        Get
            If ValidaSession(WSCVar.dsAgencia) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsAgencia))), wsCobrancaBancaria.DatasetAgencia)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsCobrancaBancaria.DatasetAgencia)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsAgencia)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsBanco() As wsCobrancaBancaria.DatasetBanco
        Get
            If ValidaSession(WSCVar.dsBanco) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsBanco))), wsCobrancaBancaria.DatasetBanco)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsCobrancaBancaria.DatasetBanco)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsBanco)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsChREcebidoFornecedor() As wsAcoesComerciais.DatasetCHRecebidoFornecedor
        Get
            If ValidaSession(WSCVar.dsChREcebidoFornecedor) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsChREcebidoFornecedor))), wsAcoesComerciais.DatasetCHRecebidoFornecedor)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetCHRecebidoFornecedor)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsChREcebidoFornecedor)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsContrato() As wsAcoesComerciais.DatasetContrato
        Get
            If ValidaSession(WSCVar.dsContrato) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsContrato))), wsAcoesComerciais.DatasetContrato)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetContrato)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsContrato)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliviera]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsEmpenho() As wsAcoesComerciais.DatasetEmpenho
        Get
            If ValidaSession(WSCVar.dsEmpenho) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsEmpenho))), wsAcoesComerciais.DatasetEmpenho)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetEmpenho)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsEmpenho)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsformaPagamento() As wsAcoesComerciais.DatasetFormaPagamento
        Get
            If ValidaSession(WSCVar.dsformaPagamento) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsformaPagamento))), wsAcoesComerciais.DatasetFormaPagamento)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetFormaPagamento)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsformaPagamento)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/13/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsTipoFormaPagamento() As wsAcoesComerciais.DatasetTipoFormaPagamento
        Get
            If ValidaSession(WSCVar.dsTipoFormaPagamento) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoFormaPagamento))), wsAcoesComerciais.DatasetTipoFormaPagamento)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetTipoFormaPagamento)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoFormaPagamento)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsParametroGestãoAcaoComercial() As wsAcoesComerciais.DatasetParametroGestaoAcaoComercial
        Get
            If ValidaSession(WSCVar.dsParametroGestaoAcaoComercial) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsParametroGestaoAcaoComercial))), wsAcoesComerciais.DatasetParametroGestaoAcaoComercial)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetParametroGestaoAcaoComercial)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsParametroGestaoAcaoComercial)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsContaCorrenteFornecedor() As wsAcoesComerciais.DatasetContaCorrenteFornecedor
        Get
            If ValidaSession(WSCVar.dsContaCorrenteFornecedor) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsContaCorrenteFornecedor))), wsAcoesComerciais.DatasetContaCorrenteFornecedor)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetContaCorrenteFornecedor)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsContaCorrenteFornecedor)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsOPRecebidaFornecedor() As wsAcoesComerciais.DatasetOPRecebidaFornecedor
        Get
            If ValidaSession(WSCVar.dsOPRecebidaFornecedor) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsOPRecebidaFornecedor))), wsAcoesComerciais.DatasetOPRecebidaFornecedor)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetOPRecebidaFornecedor)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsOPRecebidaFornecedor)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsTipoPedidoCompraxEmpenho() As wsAcoesComerciais.DatasetTipoPedidoCompraXEmpenho
        Get
            If ValidaSession(WSCVar.dsTipoPedidoCompraxEmpenho) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoPedidoCompraxEmpenho))), wsAcoesComerciais.DatasetTipoPedidoCompraXEmpenho)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetTipoPedidoCompraXEmpenho)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoPedidoCompraxEmpenho)), Value)
        End Set
    End Property
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsTipoTransferenciaxUsuario() As wsAcoesComerciais.DatasetTipoTransferenciaXUsuario
        Get
            If ValidaSession(WSCVar.DsTipoTransferenciaxUsuario) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.DsTipoTransferenciaxUsuario))), wsAcoesComerciais.DatasetTipoTransferenciaXUsuario)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetTipoTransferenciaXUsuario)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.DsTipoTransferenciaxUsuario)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsUsuarioXCelula() As wsAcoesComerciais.DatasetUsuarioXCelula
        Get
            If ValidaSession(WSCVar.dsUsuarioXCelula) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsUsuarioXCelula))), wsAcoesComerciais.DatasetUsuarioXCelula)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetUsuarioXCelula)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsUsuarioXCelula)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsTipoAbrangencia() As wsAcoesComerciais.DatasetTipoAbrangencia
        Get
            If ValidaSession(WSCVar.dsTipoAbrangencia) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoAbrangencia))), wsAcoesComerciais.DatasetTipoAbrangencia)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetTipoAbrangencia)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoAbrangencia)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsTipoBaseCalculo() As wsAcoesComerciais.DatasetTipoBaseCalculo
        Get
            If ValidaSession(WSCVar.dsTipoBaseCalculo) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoBaseCalculo))), wsAcoesComerciais.DatasetTipoBaseCalculo)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetTipoBaseCalculo)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoBaseCalculo)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsTipoEncargoFinanceiro() As wsAcoesComerciais.DatasetTipoEncargoFinanceiro
        Get
            If ValidaSession(WSCVar.dsTipoEncargoFinanceiro) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoEncargoFinanceiro))), wsAcoesComerciais.DatasetTipoEncargoFinanceiro)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetTipoEncargoFinanceiro)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoEncargoFinanceiro)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsTipoFornecedor() As wsAcoesComerciais.DatasetTipoFornecedor
        Get
            If ValidaSession(WSCVar.dsTipoFornecedor) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoFornecedor))), wsAcoesComerciais.DatasetTipoFornecedor)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetTipoFornecedor)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoFornecedor)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsTipoLancamentoContacorrenteFornecedor() As wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor
        Get
            If ValidaSession(WSCVar.dsTipoLancamentoContacorrenteFornecedor) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoLancamentoContacorrenteFornecedor))), wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoLancamentoContacorrenteFornecedor)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsTipoPagamento() As wsAcoesComerciais.DatasetTipoPagamento
        Get
            If ValidaSession(WSCVar.dsTipoPagamento) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoPagamento))), wsAcoesComerciais.DatasetTipoPagamento)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetTipoPagamento)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoPagamento)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsTipoPedidoCompra() As wsAcoesComerciais.DatasetTipoPedidoCompra
        Get
            If ValidaSession(WSCVar.dsTipoPedidoCompra) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoPedidoCompra))), wsAcoesComerciais.DatasetTipoPedidoCompra)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetTipoPedidoCompra)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoPedidoCompra)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsTipoRelacionamento() As wsAcoesComerciais.DatasetTipoRelacionamento
        Get
            If ValidaSession(WSCVar.dsTipoRelacionamento) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoRelacionamento))), wsAcoesComerciais.DatasetTipoRelacionamento)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetTipoRelacionamento)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoRelacionamento)), Value)
        End Set
    End Property


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsTipoServico() As wsAcoesComerciais.DatasetTipoServico
        Get
            If ValidaSession(WSCVar.dsTipoServico) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoServico))), wsAcoesComerciais.DatasetTipoServico)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetTipoServico)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoServico)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsTipoTransferenciaValoresAcoesComerciais() As wsAcoesComerciais.DatasetTipoTransferenciaValoresAcoesComerciais
        Get
            If ValidaSession(WSCVar.dsTipoTransferenciaValoresAcoesComerciais) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoTransferenciaValoresAcoesComerciais))), wsAcoesComerciais.DatasetTipoTransferenciaValoresAcoesComerciais)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetTipoTransferenciaValoresAcoesComerciais)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoTransferenciaValoresAcoesComerciais)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsTransferenciaVerbasEntreEmpenhos() As wsAcoesComerciais.DatasetTransferenciaVerbasEntreEmpenhos
        Get
            If ValidaSession(WSCVar.dsTransferenciaVerbasEntreEmpenhos) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTransferenciaVerbasEntreEmpenhos))), wsAcoesComerciais.DatasetTransferenciaVerbasEntreEmpenhos)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetTransferenciaVerbasEntreEmpenhos)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTransferenciaVerbasEntreEmpenhos)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsTipoUnidadePagamento() As wsAcoesComerciais.DatasetTipoUnidadePagamento
        Get
            If ValidaSession(WSCVar.dsTipoUnidadePagamento) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoUnidadePagamento))), wsAcoesComerciais.DatasetTipoUnidadePagamento)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetTipoUnidadePagamento)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoUnidadePagamento)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Guarda o datasetOperacaoBaixaOperacaoFornecedor na seção
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	15/12/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsOperacaoBaixaOperacaoFornecedor() As wsAcoesComerciais.DatasetOperacaoBaixaOperacaoFornecedor
        Get
            If ValidaSession(WSCVar.dsOperacaoBaixaOperacaoFornecedor) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsOperacaoBaixaOperacaoFornecedor))), wsAcoesComerciais.DatasetOperacaoBaixaOperacaoFornecedor)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetOperacaoBaixaOperacaoFornecedor)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsOperacaoBaixaOperacaoFornecedor)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	25/1/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsTipoAbrangenciaMix() As wsAcoesComerciais.DatasetTipoAbrangenciaMix
        Get
            If ValidaSession(WSCVar.dsTipoAbrangenciaMix) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoAbrangenciaMix))), wsAcoesComerciais.DatasetTipoAbrangenciaMix)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetTipoAbrangenciaMix)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoAbrangenciaMix)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	15/02/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsParametroFornecedorMmm() As wsAcoesComerciais.DatasetParametroFornecedorMmm
        Get
            If ValidaSession(WSCVar.dsParametroFornecedorMmm) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsParametroFornecedorMmm))), wsAcoesComerciais.DatasetParametroFornecedorMmm)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetParametroFornecedorMmm)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsParametroFornecedorMmm)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Grava o datasetSelecaoValorDisponivelFornecedor na session
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	20/11/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsSelecaoValorDisponivelFornecedor() As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
        Get
            If ValidaSession(WSCVar.dsSelecaoValorDisponivelFornecedor) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsSelecaoValorDisponivelFornecedor))), wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsSelecaoValorDisponivelFornecedor)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Guarda as formulas dos formulários do crystal na seção
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	15/12/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property hashtableFormulasCrystal() As Hashtable
        Get
            If ValidaSession(WSCVar.hashtableFormulasCrystal) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.hashtableFormulasCrystal))), Hashtable)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As Hashtable)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.hashtableFormulasCrystal)), Value)
        End Set
    End Property

    Public Shared Property hashtableOperacoesOP() As Hashtable
        Get
            If ValidaSession(WSCVar.hashtableOperacoesOP) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.hashtableOperacoesOP))), Hashtable)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As Hashtable)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.hashtableOperacoesOP)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	28/11/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property numFluApv() As Decimal
        Get
            If ValidaSession(WSCVar.numFluApv) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.numFluApv))), Decimal)
            Else
                Controller.TrataSecaoExpirada()
                Return Nothing
            End If
        End Get
        Set(ByVal Value As Decimal)
            TratarSessionExpirada()

            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.numFluApv)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	23/5/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property NUMPEDCNCACOCMC() As Decimal
        Get
            If ValidaSession(WSCVar.NUMPEDCNCACOCMC) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.NUMPEDCNCACOCMC))), Decimal)
            Else
                Controller.TrataSecaoExpirada()
                Return Nothing
            End If
        End Get
        Set(ByVal Value As Decimal)
            TratarSessionExpirada()

            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.NUMPEDCNCACOCMC)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Lucas Alves]	25/05/2010 Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsRelatorioCarimbo() As wsAcoesComerciais.DatasetRelatorioCarimbo
        Get
            If ValidaSession(WSCVar.dsRelatorioCarimbo) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioCarimbo))), wsAcoesComerciais.DatasetRelatorioCarimbo)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetRelatorioCarimbo)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioCarimbo)), Value)
        End Set
    End Property


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Lucas Alves]	01/06/2010 Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsRelatorioHistorico() As wsAcoesComerciais.DatasetCarimboHistorico
        Get
            If ValidaSession(WSCVar.dsRelatorioHistorico) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioHistorico))), wsAcoesComerciais.DatasetCarimboHistorico)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetCarimboHistorico)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioHistorico)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	23/5/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property CODFRN() As Decimal
        Get
            If ValidaSession(WSCVar.CODFRN) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.CODFRN))), Decimal)
            Else
                Controller.TrataSecaoExpirada()
                Return Nothing
            End If
        End Get
        Set(ByVal Value As Decimal)
            TratarSessionExpirada()

            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.CODFRN)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	29/11/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsTransferenciaVerbaFornecedor() As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor
        Get
            If ValidaSession(WSCVar.dsTransferenciaVerbaFornecedor) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTransferenciaVerbaFornecedor))), wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTransferenciaVerbaFornecedor)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	7/12/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property queryString() As String
        Get
            If ValidaSession(WSCVar.queryString) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.queryString))), String)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As String)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.queryString)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	23/5/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property T0120540Row() As wsAcoesComerciais.DatasetAcordo.T0120540Row
        Get
            If ValidaSession(WSCVar.T0120540Row) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.T0120540Row))), wsAcoesComerciais.DatasetAcordo.T0120540Row)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetAcordo.T0120540Row)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.T0120540Row)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	23/5/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property T0118066Row() As wsAcoesComerciais.DatasetAcordo.T0118066Row
        Get
            If ValidaSession(WSCVar.T0118066Row) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.T0118066Row))), wsAcoesComerciais.DatasetAcordo.T0118066Row)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetAcordo.T0118066Row)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.T0118066Row)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	27/5/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsRelatorioBaixaAcordo() As wsAcoesComerciais.DatasetRelatorioBaixaAcordo
        Get
            If ValidaSession(WSCVar.dsRelatorioBaixaAcordo) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioBaixaAcordo))), wsAcoesComerciais.DatasetRelatorioBaixaAcordo)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetRelatorioBaixaAcordo)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioBaixaAcordo)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Bruno Viso]	06/06/2013	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsRelatorioHistoricoBaixaOP() As wsAcoesComerciais.DatasetRelatorioHistoricoBaixaOP
        Get
            If ValidaSession(WSCVar.dsRelatorioHistoricoBaixaOP) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioHistoricoBaixaOP))), wsAcoesComerciais.DatasetRelatorioHistoricoBaixaOP)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetRelatorioHistoricoBaixaOP)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioHistoricoBaixaOP)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	5/6/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property FLGSITNGCDUP() As Boolean
        Get
            If ValidaSession(WSCVar.FLGSITNGCDUP) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.FLGSITNGCDUP))), Boolean)
            Else
                Controller.TrataSecaoExpirada()
                Return Nothing
            End If
        End Get
        Set(ByVal Value As Boolean)
            TratarSessionExpirada()

            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.FLGSITNGCDUP)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	5/6/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsAcordoACancelarEmFluxoCancelamentoAcordo() As wsFluxoDeCancelamentoDeAcordos.DatasetAcordoACancelarEmFluxoCancelamentoAcordo
        Get
            If ValidaSession(WSCVar.dsFluxoCancelamento) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsAcordoACancelarEmFluxoCancelamentoAcordo))), wsFluxoDeCancelamentoDeAcordos.DatasetAcordoACancelarEmFluxoCancelamentoAcordo)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsFluxoDeCancelamentoDeAcordos.DatasetAcordoACancelarEmFluxoCancelamentoAcordo)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsAcordoACancelarEmFluxoCancelamentoAcordo)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	8/4/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsPlanilha() As DataSet
        Get
            If ValidaSession(WSCVar.dsPlanilha) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsPlanilha))), DataSet)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As DataSet)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsPlanilha)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	8/4/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsTipoGrupoMarketing() As wsAcoesComerciais.DatasetTipoGrupoMarketing
        Get
            If ValidaSession(WSCVar.dsTipoGrupoMarketing) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoGrupoMarketing))), wsAcoesComerciais.DatasetTipoGrupoMarketing)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetTipoGrupoMarketing)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsTipoGrupoMarketing)), Value)
        End Set
    End Property

    Public Shared Property CODPRGICT() As Decimal
        Get
            If ValidaSession(WSCVar.CODPRGICT) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.CODPRGICT))), Decimal)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As Decimal)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.CODPRGICT)), Value)
        End Set
    End Property

    Public Shared Property AditamentoRow() As wsAcoesComerciais.DatasetContrato.AditamentoRow
        Get
            If ValidaSession(WSCVar.AditamentoRow) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.AditamentoRow))), wsAcoesComerciais.DatasetContrato.AditamentoRow)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetContrato.AditamentoRow)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.AditamentoRow)), Value)
        End Set
    End Property

    Public Shared Property PERPSQSLDFRN() As Decimal
        Get
            If ValidaSession(WSCVar.PERPSQSLDFRN) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.PERPSQSLDFRN))), Decimal)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As Decimal)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.PERPSQSLDFRN)), Value)
        End Set
    End Property

    Public Shared Property isCarimbo() As Boolean
        Get
            If ValidaSession(WSCVar.isCarimbo) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.isCarimbo))), Boolean)
            Else
                Controller.TrataSecaoExpirada()
                Return Nothing
            End If
        End Get
        Set(ByVal Value As Boolean)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.isCarimbo)), Value)
        End Set
    End Property



#Region " DataSet Relatórios "

    Public Shared Property dsRelatorioAcordoFornecimento() As wsAcoesComerciais.DatasetRelatorioAcordoFornecimento
        Get
            If ValidaSession(WSCVar.dsRelatorioAcordoFornecimento) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioAcordoFornecimento))), wsAcoesComerciais.DatasetRelatorioAcordoFornecimento)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetRelatorioAcordoFornecimento)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioAcordoFornecimento)), Value)
        End Set
    End Property

    Public Shared Property dsRelatorioAcordoParaDeduction() As wsAcoesComerciais.DatasetRelatorioAcordoParaDeduction
        Get
            If ValidaSession(WSCVar.dsRelatorioAcordoParaDeduction) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioAcordoParaDeduction))), wsAcoesComerciais.DatasetRelatorioAcordoParaDeduction)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetRelatorioAcordoParaDeduction)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioAcordoParaDeduction)), Value)
        End Set
    End Property

    Public Shared Property dsRelatorioConferenciaAcaoTatica() As wsAcoesComerciais.DatasetRelatorioConferenciaAcaoTatica
        Get
            If ValidaSession(WSCVar.dsRelatorioConferenciaAcaoTatica) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioConferenciaAcaoTatica))), wsAcoesComerciais.DatasetRelatorioConferenciaAcaoTatica)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetRelatorioConferenciaAcaoTatica)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioConferenciaAcaoTatica)), Value)
        End Set
    End Property

    Public Shared Property dsRelatorioContasAReceber() As wsAcoesComerciais.DatasetRelatorioContasAReceber
        Get
            If ValidaSession(WSCVar.dsRelatorioContasAReceber) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioContasAReceber))), wsAcoesComerciais.DatasetRelatorioContasAReceber)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetRelatorioContasAReceber)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioContasAReceber)), Value)
        End Set
    End Property

    Public Shared Property dsRelatorioOperacoesOP() As wsAcoesComerciais.DatasetOperacaoBaixaOperacaoFornecedor
        Get
            If ValidaSession(WSCVar.dsRelatorioContasAReceber) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioContasAReceber))), wsAcoesComerciais.DatasetOperacaoBaixaOperacaoFornecedor)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetOperacaoBaixaOperacaoFornecedor)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioContasAReceber)), Value)
        End Set
    End Property

    Public Shared Property dsRelatorioHistoricoAcordo() As wsAcoesComerciais.DatasetRelatorioHistoricoAcordo
        Get
            If ValidaSession(WSCVar.dsRelatorioHistoricoAcordo) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioHistoricoAcordo))), wsAcoesComerciais.DatasetRelatorioHistoricoAcordo)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetRelatorioHistoricoAcordo)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioHistoricoAcordo)), Value)
        End Set
    End Property

    Public Shared Property dsRelatorioAcordoAcoesComerciais() As wsAcoesComerciais.DatasetRelatorioAcordoAcoesComerciais
        Get
            If ValidaSession(WSCVar.dsRelatorioAcordoAcoesComerciais) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioAcordoAcoesComerciais))), wsAcoesComerciais.DatasetRelatorioAcordoAcoesComerciais)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetRelatorioAcordoAcoesComerciais)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioAcordoAcoesComerciais)), Value)
        End Set
    End Property

    Public Shared Property dsRelatorioExtratoContaCorrrente() As wsAcoesComerciais.DataSetRelatorioExtratoContaCorrrente
        Get
            If ValidaSession(WSCVar.dsRelatorioExtratoContaCorrrente) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioExtratoContaCorrrente))), wsAcoesComerciais.DataSetRelatorioExtratoContaCorrrente)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DataSetRelatorioExtratoContaCorrrente)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioExtratoContaCorrrente)), Value)
        End Set
    End Property

    Public Shared Property dsRelatorioAnaliticoAcoesComerciais() As wsAcoesComerciais.DataSetRelatorioAnaliticoAcoesComerciais
        Get
            If ValidaSession(WSCVar.dsRelatorioAnaliticoAcoesComerciais) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioAnaliticoAcoesComerciais))), wsAcoesComerciais.DataSetRelatorioAnaliticoAcoesComerciais)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DataSetRelatorioAnaliticoAcoesComerciais)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioAnaliticoAcoesComerciais)), Value)
        End Set
    End Property

    Public Shared Property dsRelatorioRecibo() As wsAcoesComerciais.DataSetRelatorioRecibo
        Get
            If ValidaSession(WSCVar.dsRelatorioRecibo) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioRecibo))), wsAcoesComerciais.DataSetRelatorioRecibo)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DataSetRelatorioRecibo)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioRecibo)), Value)
        End Set
    End Property

    Public Shared Property dsRelacaoPerdasEmitidas() As wsAcoesComerciais.DatasetRelacaoPerdasEmitidas
        Get
            If ValidaSession(WSCVar.dsRelacaoPerdasEmitidas) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelacaoPerdasEmitidas))), wsAcoesComerciais.DatasetRelacaoPerdasEmitidas)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetRelacaoPerdasEmitidas)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelacaoPerdasEmitidas)), Value)
        End Set
    End Property

    Public Shared Property dsSimulacaoSinteticaDeCrescimento() As wsAcoesComerciais.DatasetSimulacaoSinteticaDeCrescimento
        Get
            If ValidaSession(WSCVar.dsSimulacaoSinteticaDeCrescimento) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsSimulacaoSinteticaDeCrescimento))), wsAcoesComerciais.DatasetSimulacaoSinteticaDeCrescimento)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetSimulacaoSinteticaDeCrescimento)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsSimulacaoSinteticaDeCrescimento)), Value)
        End Set
    End Property

    Public Shared Property dsRelatorioSaldoDisponivelFornecedorCelula() As wsAcoesComerciais.DataSetRelatorioSaldoDisponivelFornecedorCelula
        Get
            If ValidaSession(WSCVar.dsRelatorioSaldoDisponivelFornecedorCelula) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioSaldoDisponivelFornecedorCelula))), wsAcoesComerciais.DataSetRelatorioSaldoDisponivelFornecedorCelula)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DataSetRelatorioSaldoDisponivelFornecedorCelula)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRelatorioSaldoDisponivelFornecedorCelula)), Value)
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Rodrigo Gama]	27/8/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsRecuperacaoEPrevencaoPerdas() As wsRecuperacaoEPrevencaoPerdas.DatasetRecuperacaoEPrevencaoPerdas
        Get
            If ValidaSession(WSCVar.dsRecuperacaoEPrevencaoPerdas) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRecuperacaoEPrevencaoPerdas))), wsRecuperacaoEPrevencaoPerdas.DatasetRecuperacaoEPrevencaoPerdas)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsRecuperacaoEPrevencaoPerdas.DatasetRecuperacaoEPrevencaoPerdas)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsRecuperacaoEPrevencaoPerdas)), Value)
        End Set

    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Rodrigo Gama]	10/9/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property dsPrevisaoApuracao() As wsAcoesComerciais.DatasetPrevisaoApuracao
        Get
            If ValidaSession(WSCVar.dsPrevisaoApuracao) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsPrevisaoApuracao))), wsAcoesComerciais.DatasetPrevisaoApuracao)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DatasetPrevisaoApuracao)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsPrevisaoApuracao)), Value)
        End Set

    End Property


#End Region

#Region "DataSet RelatoriosValoresContabilizadosCarimbos"
    Public Shared Property dsValoresContabilizadosCarimbos() As wsAcoesComerciais.DataSetValoresContabilizadosCarimbosRelatorio
        Get
            If ValidaSession(WSCVar.dsValoresContabilizadosCarimbos) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsValoresContabilizadosCarimbos))), wsAcoesComerciais.DataSetValoresContabilizadosCarimbosRelatorio)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DataSetValoresContabilizadosCarimbosRelatorio)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsValoresContabilizadosCarimbos)), Value)
        End Set
    End Property

    Public Shared Property dsVerbasCarimbadas() As wsAcoesComerciais.DataSetRelatorioVerbasCarimbadas
        Get
            If ValidaSession(WSCVar.dsVerbasCarimbadas) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsVerbasCarimbadas))), wsAcoesComerciais.DataSetRelatorioVerbasCarimbadas)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DataSetRelatorioVerbasCarimbadas)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsVerbasCarimbadas)), Value)
        End Set
    End Property

    Public Shared Property dsAcordos() As wsAcoesComerciais.DataSetRelatorioAcordos
        Get
            If ValidaSession(WSCVar.dsAcordos) Then
                Return DirectCast(HttpContext.Current.Session.Item(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsAcordos))), wsAcoesComerciais.DataSetRelatorioAcordos)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As wsAcoesComerciais.DataSetRelatorioAcordos)
            TratarSessionExpirada()
            HttpContext.Current.Session.Add(String.Concat(NomeSession, GetEnumConstName(WSCVar.dsAcordos)), Value)
        End Set
    End Property
#End Region

#End Region

#End Region

End Class