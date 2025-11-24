Imports Martins.Security.Helper
Imports Martins.Util.Compression

''' -----------------------------------------------------------------------------
''' Project	 : Martins.Web.UI.AcoesComerciais
''' Class	 : Controller
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Controller de navegação do sistema
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Marcos Queiroz]    01/06/2006 Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class Controller

#Region "Tratamento de erro"


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Efetua tratamento de erro para redirecionar o browser à uma página com a mensagem
    ''' </summary>
    ''' <param name="ex">Exception ocorrida</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/06/2006 Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub TrataErro(ByRef pagina As System.Web.UI.Page, ByVal ex As Exception)

        Dim NivelSubPasta As Integer = ObterNivelCaminhoEmExecucao()
        Dim flagErroDeRegra As Boolean = False

        If (TypeOf (ex) Is System.Threading.ThreadAbortException) Then
            Return
        End If

        If ex.Message.IndexOf("|".ToCharArray, 0) >= 0 Then
            If ex.Message.Substring(ex.Message.IndexOf("|".ToCharArray, 0), 7).ToUpper = "|REGRA|" Then
                flagErroDeRegra = True
            End If
        End If

        If flagErroDeRegra Then
            TrataErroRegra(pagina, ex)
        Else
            TrataErroGeral(ex)
        End If

    End Sub

    Private Shared Sub TrataErroGeral(ByVal ex As Exception)
        Dim NivelSubPasta As Integer = ObterNivelCaminhoEmExecucao()

        If (TypeOf (ex) Is System.Threading.ThreadAbortException) Then
            Return
        End If

        'Guarda o erro no event viewer
        Martins.ExceptionManagement.ExceptionManager.Publish(ex)

        If (TypeOf (ex) Is System.Web.Services.Protocols.SoapException) Then
            Dim exSoap As System.Web.Services.Protocols.SoapException
            exSoap = CType(ex, System.Web.Services.Protocols.SoapException)
            If (exSoap.Detail.InnerText <> String.Empty) Then
                HttpContext.Current.Session("Erro") = exSoap.Detail.InnerText
            Else
                HttpContext.Current.Session("Erro") = ex.Message
            End If
        ElseIf (TypeOf (ex) Is Martins.ExceptionManagement.BaseApplicationException) Then
            HttpContext.Current.Session("Erro") = CType(ex, Martins.ExceptionManagement.BaseApplicationException).UserMessage
        Else
            HttpContext.Current.Session("Erro") = ex.Message
        End If

        If NivelSubPasta = 0 Then
            HttpContext.Current.Response.Redirect("~/Erro.aspx?action=Erro")
        ElseIf NivelSubPasta = 1 Then
            HttpContext.Current.Response.Redirect("~/Erro.aspx?action=Erro")
        End If

    End Sub

    Private Shared Sub TrataErroRegra(ByRef pagina As System.Web.UI.Page, ByVal ex As Exception)

        If (TypeOf (ex) Is System.Threading.ThreadAbortException) Then
            Return
        End If

        Dim mensagem() As String = Split(ex.Message, "|")

        For i As Integer = 0 To mensagem.Length
            If mensagem(i).ToUpper = "REGRA" Then
                Util.AdicionaJsAlert(pagina, mensagem(i + 1).Trim & ".")
                Exit For
            End If
        Next
    End Sub

    Public Shared Sub TrataSecaoExpirada()
        HttpContext.Current.Response.Redirect("~/Erro.aspx?action=sessaoexpirada")
    End Sub

    Public Shared Function ObterNivelCaminhoEmExecucao() As Integer
        Dim CurrentExecutionFilePath As String
        CurrentExecutionFilePath = HttpContext.Current.Request.CurrentExecutionFilePath

        Dim QuantNiveisCaminhoRaiz As Integer = QuantidadeNiveisCaminhoRaiz()

        Dim IN_PathArray() As String = Split(CurrentExecutionFilePath.Trim, "/")
        If IN_PathArray.Length <= QuantNiveisCaminhoRaiz Then
            Return 0
        End If

        Return (IN_PathArray.Length - QuantNiveisCaminhoRaiz)
    End Function

    Public Shared Function QuantidadeNiveisCaminhoRaiz() As Integer
        Dim result As Integer
        If Not (System.Configuration.ConfigurationSettings.AppSettings("Martins.Web.UI.AcoesComerciais.QuantidadeNiveisCaminhoRaiz") Is Nothing) Then
            result = CType(System.Configuration.ConfigurationSettings.AppSettings("Martins.Web.UI.AcoesComerciais.QuantidadeNiveisCaminhoRaiz"), Integer)
        End If
        Return result
    End Function

#End Region

#Region "Navegação"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Redirecionar página principal
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	29/11/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub RedirecionarPaginaPrincipal(ByRef pagina As System.Web.UI.Page)
        Dim NivelSubPasta As Integer = ObterNivelCaminhoEmExecucao()
        Dim comandoJavaScript As String

        If NivelSubPasta = 0 Then
            comandoJavaScript = "<script language=javascript >window.parent.parent.document.location.reload();</script>"
        ElseIf NivelSubPasta = 1 Then
            comandoJavaScript = "<script language=javascript >window.parent.parent.parent.document.location.reload();</script>"
        End If

        pagina.RegisterStartupScript("RedirectPrincipal", comandoJavaScript)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter Acordo, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirAcordo()
        HttpContext.Current.Response.Redirect("Acordo.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navegar para página de contrato em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	5/10/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirContrato()
        HttpContext.Current.Response.Redirect("Contrato.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter Acordo, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirBaixaAcordo()
        HttpContext.Current.Response.Redirect("BaixaAcordo.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter AlteraFormaPagamento, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirAlteraFormaPagamento()
        HttpContext.Current.Response.Redirect("AlteraFormaPagamento.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter AlteraValorEfetivo, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirAlteraValorEfetivo()
        HttpContext.Current.Response.Redirect("AlteraValorEfetivo.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter Apuracao, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirApuracao()
        HttpContext.Current.Response.Redirect("Apuracao.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter Banco, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirBanco()
        HttpContext.Current.Response.Redirect("Banco.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter Agencia, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirAgencia()
        HttpContext.Current.Response.Redirect("Agencia.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter Cheque, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirCheque()
        HttpContext.Current.Response.Redirect("Cheque.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter Empenho, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirEmpenho()
        HttpContext.Current.Response.Redirect("Empenho.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter FormaPagamento, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirFormaPagamento()
        HttpContext.Current.Response.Redirect("FormaPagamento.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter Gerais, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirGerais()
        HttpContext.Current.Response.Redirect("Gerais.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter Lancamento, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirLancamento()
        HttpContext.Current.Response.Redirect("Lancamento.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter OP, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirOP()
        HttpContext.Current.Response.Redirect("OP.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter OperacoesOP, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirOperacoesOP()
        HttpContext.Current.Response.Redirect("OperacoesOP.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter TipoBaseCalculo, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirTipoBaseCalculo()
        HttpContext.Current.Response.Redirect("TipoBaseCalculo.aspx")
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter PedidoCompra, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirTipoPedidoCompra()
        HttpContext.Current.Response.Redirect("TipoPedidoCompra.aspx")
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter RelaçaoEmpenhoTipoPedidoCompra, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirRelacaoEmpenhoTipoPedidoCompra()
        HttpContext.Current.Response.Redirect("RelacaoEmpenhoTipoPedidoCompra.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter Recebimento, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirRecebimento()
        HttpContext.Current.Response.Redirect("Recebimento.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter TipoLancamento, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirTipoLancamento()
        HttpContext.Current.Response.Redirect("TipoLancamento.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter Transferencia, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirTransferencia()
        HttpContext.Current.Response.Redirect("Transferencia.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter TransferenciaVerbas, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirTipoTransferenciaVerba()
        HttpContext.Current.Response.Redirect("TipoTransferenciaVerba.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter TransferenciaVerbas, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirTransferenciaVerba()
        HttpContext.Current.Response.Redirect("TransferenciaVerba.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter TransferenciaGac, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirTransferenciaGac()
        HttpContext.Current.Response.Redirect("TransferenciaGac.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter TransferenciaVerbas, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirRelacaoUsuarioTransferenciaVerba()
        HttpContext.Current.Response.Redirect("RelacaoUsuarioTransferenciaVerba.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter TransferenciaVerbas, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirRelacionamentoTransferenciaVerba()
        HttpContext.Current.Response.Redirect("RelacionamentoTransferenciaVerba.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Navega para a página de manter TrocaTituloPagamento, em modo de inserção
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]    01/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirTrocaTituloPagamento()
        HttpContext.Current.Response.Redirect("TrocaTituloPagamento.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	10/19/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirTipoAbrangencia()
        HttpContext.Current.Response.Redirect("TipoAbrangencia.aspx")
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	10/20/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirTipoFormaPagamento()
        HttpContext.Current.Response.Redirect("TipoFormaPagamento.aspx")
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	10/20/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirTipoFornecedor()
        HttpContext.Current.Response.Redirect("TipoFornecedor.aspx")
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	10/20/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirUnidadePagamento()
        HttpContext.Current.Response.Redirect("UnidadePagamento.aspx")
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	10/23/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirTipoServico()
        HttpContext.Current.Response.Redirect("TipoServico.aspx")
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	10/23/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirTipoPagamento()
        HttpContext.Current.Response.Redirect("TipoPagamento.aspx")
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	10/23/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirTipoEncargoFinanceiro()
        HttpContext.Current.Response.Redirect("TipoEncargoFinanceiro.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	10/23/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirTipoRelacionamento()
        HttpContext.Current.Response.Redirect("TipoRelacionamento.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[PRETRE21]	15/2/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirParametroFornecedorMmm()
        HttpContext.Current.Response.Redirect("ParametroFornecedorMmm.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chama a página de inclusão de relação de usuário X Célula
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[PRETRE21]	26/2/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub NavegarInserirRelacaoUsuarioCelula()
        HttpContext.Current.Response.Redirect("RelacaoUsuarioCelula.aspx")
    End Sub

#End Region

#Region "WebService AcoesComerciais"

#Region "Obter Dados"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0104499
    ''' Descrição da entidade:CADASTRO TIPO PEDIDO COMPRA
    ''' </summary>
    ''' <param name="TIPPEDCMP">TIPO PEDIDO DE COMPRAS.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTipoPedidoCompra(ByVal TIPPEDCMP As Decimal) As wsAcoesComerciais.DatasetTipoPedidoCompra
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTipoPedidoCompra(TIPPEDCMP)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0104499
    ''' Descrição da entidade:CADASTRO TIPO PEDIDO COMPRA
    ''' </summary>
    ''' <param name="TIPPEDCMP">TIPO PEDIDO DE COMPRAS.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTiposPedidoCompra(ByVal DESTIPPEDCMP As String) As wsAcoesComerciais.DatasetTipoPedidoCompra
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTiposPedidoCompra(DESTIPPEDCMP)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0114508
    ''' Descrição da entidade:PARAMETRO CUSTO SISTEMA NEGOCIACAO COMPRA MERCADORIA
    ''' </summary>
    ''' <param name="CODFILEMP">CODIGO DA FILIAL DA EMPRESA.</param>
    ''' <param name="NUMPMTSIS">NUMERO DO PARAMETRO DO SISTEMA.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    08/09/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterCadastroTributosFilial(ByVal CODFILEMP As Decimal, _
                                                       ByVal NUMPMTSIS As Decimal) As wsAcoesComerciais.DatasetCadastroTributosFilial
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterCadastroTributosFilial(CODFILEMP, NUMPMTSIS)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0114508
    ''' Descrição da entidade:PARAMETRO CUSTO SISTEMA NEGOCIACAO COMPRA MERCADORIA
    ''' </summary>
    ''' <param name="CODFILEMP">CODIGO DA FILIAL DA EMPRESA.</param>
    ''' <param name="NUMPMTSIS">NUMERO DO PARAMETRO DO SISTEMA.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0114508" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    08/09/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterCadastrosTributosFilial(ByVal CODFILEMP As Decimal, _
                                                        ByVal NUMPMTSIS As Decimal) As wsAcoesComerciais.DatasetCadastroTributosFilial
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterCadastrosTributosFilial(CODFILEMP, NUMPMTSIS)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0113625
    ''' Descrição da entidade:CADASTRO COMPRADOR
    ''' </summary>
    ''' <param name="CODCPR">CODIGO COMPRADOR.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterComprador(ByVal CODCPR As Integer) As wsAcoesComerciais.dataSetEstruturaCompra
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterComprador(CODCPR)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Este método retorna dados da entidade T0113625 com base em outros atributos.
    ''' Descrição da entidade:CADASTRO COMPRADOR
    ''' </summary>
    ''' <param name="CODGERPRD">CODIGO GERENTE DE PRODUTO.</param>
    ''' <param name="DATDSTCPR">DATA DE DESATIVACAO DO COMPRADOR.</param>
    ''' <param name="DATDSTCPRInicial">DATA DE DESATIVACAO DO COMPRADOR INICIAL.</param>
    ''' <param name="DATDSTCPRFinal">DATA DE DESATIVACAO DO COMPRADOR FINAL.</param>
    ''' <param name="IncluirDATDSTCPRNulo"> Valores: [0: Todos | 1:Somenta Ativos | 2:Somentes Inativos] - DATA DE DESATIVACAO DO COMPRADOR.</param>
    ''' <param name="DESSGLGERPRD">DESCRICAO SIGLA DO GERENTE DE PRODUTO.</param>
    ''' <param name="NOMCPR">NOME FUNCIONARIO.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0113625" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    11/12/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterCompradores(ByVal CODGERPRD As Decimal, _
                                            ByVal DATDSTCPR As Date, _
                                            ByVal DATDSTCPRInicial As Date, _
                                            ByVal DATDSTCPRFinal As Date, _
                                            ByVal IncluirDATDSTCPRNulo As Int16, _
                                            ByVal DESSGLGERPRD As String, _
                                            ByVal NOMCPR As String) As wsAcoesComerciais.dataSetEstruturaCompra

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials

        Return webService.ObterCompradores(CODGERPRD, _
                                           DATDSTCPR, _
                                           DATDSTCPRInicial, _
                                           DATDSTCPRFinal, _
                                           IncluirDATDSTCPRNulo, _
                                           DESSGLGERPRD, _
                                           NOMCPR)

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0114095
    ''' Descrição da entidade:PARAMETROS SISTEMA NEGOCIACAO FORNECEDOR
    ''' </summary>
    ''' <param name="NUMPMTSIS">NUMERO DO PARAMETRO DO SISTEMA.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterParametroSistemaNegociacaoFornecedor(ByVal NUMPMTSIS As Integer) As wsAcoesComerciais.dataSetParametro
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterParametro(NUMPMTSIS)
    End Function

    '''' -----------------------------------------------------------------------------
    '''' <summary>
    '''' Obtem dados no Web Service com base em atributos não chave primária
    '''' Entidade T0114095
    '''' Descrição da entidade:PARAMETROS SISTEMA NEGOCIACAO FORNECEDOR
    '''' </summary>
    '''' <param name="NUMPMTSIS">NUMERO DO PARAMETRO DO SISTEMA.</param>
    '''' <remarks>
    '''' </remarks>
    '''' <history>
    ''''     [Marcos Queiroz]    12/07/2006  Created
    '''' </history>
    '''' -----------------------------------------------------------------------------
    'Public Shared Function ObterParametrosSistemaNegociacaoFornecedor(ByVal CODEMPREF As Decimal) As wsAcoesComerciais.DatasetParametroSistemaNegociacaoFornecedor
    '    Dim webService As New wsAcoesComerciais.AcoesComerciais
    '    AssinadorWebServices.AssinarWebService(webService)
    '    Return webService.ObterParametrosSistemaNegociacaoFornecedor(CODEMPREF)
    'End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0118570
    ''' Descrição da entidade:RELACAO EQUIPE DE COMPRAS X GERENTENEGOCIO - SERV. COMPRAS
    ''' </summary>
    ''' <param name="CODDIVCMP">CODIGO DA DIVISAO DE COMPRAS.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterCelula(ByVal CODDIVCMP As Decimal) As wsAcoesComerciais.DatasetCelula
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterCelula(CODDIVCMP)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0118570
    ''' Descrição da entidade:RELACAO EQUIPE DE COMPRAS X GERENTENEGOCIO - SERV. COMPRAS
    ''' </summary>
    ''' <param name="CODDIVCMP">CODIGO DA DIVISAO DE COMPRAS.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterCelulas(ByVal CODDRTCMP As Decimal, _
                                        ByVal CODGERPRD As Decimal, _
                                        ByVal CODGRPMERFRC As Decimal, _
                                        ByVal DESDIVCMP As String) As wsAcoesComerciais.DatasetCelula
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterCelulas(CODDRTCMP, CODGERPRD, CODGRPMERFRC, DESDIVCMP)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0123183
    ''' Descrição da entidade:CADASTRO DIRETORIA COMPRA
    ''' </summary>
    ''' <param name="CODDRTCMP">CODIGO DA DIRETORIAS DE COMPRAS.</param>
    ''' <param name="CODUNDESRNGC">CODIGO UNIDADE ESTRATEGICA DE NEGOCIOS.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterDiretoriaCompra(ByVal CODUNDESRNGC As Decimal) As wsAcoesComerciais.DatasetDiretoriaCompra
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterDiretoriaCompra(CODUNDESRNGC)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0131275
    ''' Descrição da entidade:CADASTRO DIRETORIA COMPRA
    ''' </summary>
    ''' <param name="CODDRTCMP">CODIGO DA DIRETORIAS DE COMPRAS.</param>
    ''' <param name="CODUNDESRNGC">CODIGO UNIDADE ESTRATEGICA DE NEGOCIOS.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterDiretoriasCompra(ByVal CODFNC As Decimal, _
                                                 ByVal DESABVUNDESRNGC As String, _
                                                 ByVal DESUNDESRNGC As String) As wsAcoesComerciais.DatasetDiretoriaCompra
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterDiretoriasCompra(CODFNC, DESABVUNDESRNGC, DESUNDESRNGC)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0105592
    ''' Descrição da entidade:CADASTRO DE PEDIDOS DE COMPRAS
    ''' </summary>
    ''' <param name="CODEMP">CODIGO EMPRESA.</param>
    ''' <param name="CODFILEMP">CODIGO DA FILIAL DA EMPRESA.</param>
    ''' <param name="NUMPEDCMP">IDENTIFICA O PEDIDO DE COMPRA.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterPedidoCompra(ByVal CODEMP As Decimal, _
                                             ByVal CODFILEMP As Decimal, _
                                             ByVal NUMPEDCMP As Decimal) As wsAcoesComerciais.DatasetCapaPedidoCompra
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterCapaPedidoCompra(CODEMP, CODFILEMP, NUMPEDCMP)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0105592
    ''' Descrição da entidade:CADASTRO DE PEDIDOS DE COMPRAS
    ''' </summary>
    ''' <param name="CODEMP">CODIGO EMPRESA.</param>
    ''' <param name="CODFILEMP">CODIGO DA FILIAL DA EMPRESA.</param>
    ''' <param name="NUMPEDCMP">IDENTIFICA O PEDIDO DE COMPRA.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterCapaPedidosCompra(ByVal CODBCOTITPGT As Decimal, _
                                              ByVal CODCIDENTCIF As Decimal, _
                                              ByVal CODCNLDTB As Decimal, _
                                              ByVal CODCPR As Decimal, _
                                              ByVal CODEMP As Decimal, _
                                              ByVal CODFILEMP As Decimal, _
                                              ByVal CODFILEMPENT As Decimal, _
                                              ByVal CODFILEMPTRN As Decimal, _
                                              ByVal CODFRN As Decimal, _
                                              ByVal DATBXAPEDCMP As Date, _
                                              ByVal DATCNCPEDCMP As Date, _
                                              ByVal DATPEDCMP As Date, _
                                              ByVal NOMCIDRCBMER As String, _
                                              ByVal NUMACOMCD As Decimal, _
                                              ByVal NUMIDTTIPPEDCMP As Decimal, _
                                              ByVal NUMPEDBNF As Decimal, _
                                              ByVal NUMPEDCMP As Decimal, _
                                              ByVal NUMPEDNOR As Decimal, _
                                              ByVal NUMPNDRLCPEDCMP As Decimal) As wsAcoesComerciais.DatasetCapaPedidoCompra
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterCapaPedidosCompra(CODBCOTITPGT, CODCIDENTCIF, CODCNLDTB, CODCPR, CODEMP, CODFILEMP, CODFILEMPENT, CODFILEMPTRN, CODFRN, DATBXAPEDCMP, DATCNCPEDCMP, DATPEDCMP, NOMCIDRCBMER, NUMACOMCD, NUMIDTTIPPEDCMP, NUMPEDBNF, NUMPEDCMP, NUMPEDNOR, NUMPNDRLCPEDCMP)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados de FiliaisEmpresa do Web Service
    ''' </summary>
    ''' <param name="indicadorRestricaoFilial">[1=Martins | 2=Linha Direta]</param>
    ''' <returns>DataSet com os dados retornados</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	04/07/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterFiliais(ByVal indicadorRestricaoFilial As Int16) As wsAcoesComerciais.dataSetFilial
        Dim webService As wsAcoesComerciais.AcoesComerciais
        webService = New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterFiliais(indicadorRestricaoFilial)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados de Fornecedor do Web Service
    ''' </summary>
    ''' <param name="codigoFornecedor">Código do Fornecedor a pesquisar</param>
    ''' <returns>DataSet com os dados retornados</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Autor]	07/07/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterDivisaoFornecedor(ByVal codigoEmpresa As Integer, ByVal codigoFornecedor As Long) As wsAcoesComerciais.dataSetDivisaoFornecedor
        Dim webService As wsAcoesComerciais.AcoesComerciais

        'If codigoFornecedor = 0 Then
        '    Return New wsAcoesComerciais.dataSetDivisaoFornecedor
        'End If

        webService = New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterDivisaoFornecedor(codigoEmpresa, codigoFornecedor)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados de Fornecedor do Web Service
    ''' </summary>
    ''' <param name="codigoFornecedor">Código do Fornecedor a pesquisar</param>
    ''' <returns>DataSet com os dados retornados</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Autor]	07/07/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterDivisoesFornecedor(ByVal CODEMP As Decimal, _
                                                   ByVal NOMFRN As String) As wsAcoesComerciais.dataSetDivisaoFornecedor
        Dim wsAcoesComerciais As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(wsAcoesComerciais)
        wsAcoesComerciais.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return wsAcoesComerciais.ObterDivisoesFornecedor(CODEMP, NOMFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0119291
    ''' Descrição da entidade:HISTORICO DIARIO PENDENCIA RECEBIDANA ACAO COMERCIAL
    ''' </summary>
    ''' <param name="CODEMP">CODIGO EMPRESA.</param>
    ''' <param name="CODFILEMP">CODIGO DA FILIAL DA EMPRESA.</param>
    ''' <param name="NUMPNDFRN">NUMERO PENDENCIA DO FORNECEDOR.</param>
    ''' <param name="NUMSEQPGTPND">.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    03/08/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterPendenciaRecebidaAcaoComercial(ByVal CODEMP As Decimal, _
                                                               ByVal CODFILEMP As Decimal, _
                                                               ByVal NUMPNDFRN As Decimal, _
                                                               ByVal NUMSEQPGTPND As Decimal) As wsAcoesComerciais.DatasetPendenciaRecebidaAcaoComercial
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterPendenciaRecebidaAcaoComercial(CODEMP, CODFILEMP, NUMPNDFRN, NUMSEQPGTPND)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0119291
    ''' Descrição da entidade:HISTORICO DIARIO PENDENCIA RECEBIDANA ACAO COMERCIAL
    ''' </summary>
    ''' <param name="CODAGE">CODIGO DA AGENCIA.</param>
    ''' <param name="CODBCO">CODIGO BANCO.</param>
    ''' <param name="CODEMP">CODIGO EMPRESA.</param>
    ''' <param name="CODFILEMP">CODIGO DA FILIAL DA EMPRESA.</param>
    ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
    ''' <param name="DATBXAPNDFRN">DATA DA BAIXA PENDENCIA FORNECEDOR.</param>
    ''' <param name="DATBXAPNDFRNInicial">DATA DA BAIXA PENDENCIA FORNECEDOR INICIAL.</param>
    ''' <param name="DATBXAPNDFRNFinal">DATA DA BAIXA PENDENCIA FORNECEDOR FINAL.</param>
    ''' <param name="IncluirDATBXAPNDFRNNulo"> Valores: [0:Não incluir no resultado se o campo for nulo | 1:Incluir no resultado se campo for nulo | 3:Independente do valor do campo incluir no resultado] - DATA DA BAIXA PENDENCIA FORNECEDOR.</param>
    ''' <param name="IncluirDATTRNPNDACOCMCNulo"> Valores: [0:Não incluir no resultado se o campo for nulo | 1:Incluir no resultado se campo for nulo | 3:Independente do valor do campo incluir no resultado] - DATA TRANSFERENCIA PENDENCIA PARA O SISTEMA DE ACOES CO.</param>
    ''' <param name="IncluirDATVNCNGCPNDFRNNulo"> Valores: [0:Não incluir no resultado se o campo for nulo | 1:Incluir no resultado se campo for nulo | 3:Independente do valor do campo incluir no resultado] - DATA DE VENCIMENTO NEGOCIACAO PENDENCIA FORNECEDOR.</param>
    ''' <param name="NUMCHQPND">NUMERO DO CHEQUE DA PENDENCIA.</param>
    ''' <param name="NUMNOTFSCFRNCTB">NUMERO NOTA FISCAL FORNECEDOR PARA CONTABILIZACAO.</param>
    ''' <param name="NUMORDPGTPND">NUMERO DE ORDEM DE PAGAMENTO DA PENDENCIA.</param>
    ''' <param name="NUMPNDFRN">NUMERO PENDENCIA DO FORNECEDOR.</param>
    ''' <param name="NUMSEQPGTPND">NUMERO DE SEQUENCIA DE PAGAMENTO DA PENDENCIA.</param>
    ''' <param name="VLRPGOPND">VALOR PAGO NA PENDENCIA.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0119291" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    03/08/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterPendenciasRecebidaAcaoComercial(ByVal CODAGE As Decimal, _
                                                                ByVal CODBCO As Decimal, _
                                                                ByVal CODEMP As Decimal, _
                                                                ByVal CODFILEMP As Decimal, _
                                                                ByVal CODFRN As Decimal, _
                                                                ByVal DATBXAPNDFRN As Date, _
                                                                ByVal DATBXAPNDFRNInicial As Date, _
                                                                ByVal DATBXAPNDFRNFinal As Date, _
                                                                ByVal IncluirDATBXAPNDFRNNulo As Int16, _
                                                                ByVal IncluirDATTRNPNDACOCMCNulo As Int16, _
                                                                ByVal IncluirDATVNCNGCPNDFRNNulo As Int16, _
                                                                ByVal NUMCHQPND As Decimal, _
                                                                ByVal NUMNOTFSCFRNCTB As Decimal, _
                                                                ByVal NUMORDPGTPND As Decimal, _
                                                                ByVal NUMPNDFRN As Decimal, _
                                                                ByVal NUMSEQPGTPND As Decimal, _
                                                                ByVal VLRPGOPND As Decimal) As wsAcoesComerciais.DatasetPendenciaRecebidaAcaoComercial
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterPendenciasRecebidaAcaoComercial(CODAGE, CODBCO, CODEMP, CODFILEMP, CODFRN, DATBXAPNDFRN, DATBXAPNDFRNInicial, DATBXAPNDFRNFinal, IncluirDATBXAPNDFRNNulo, IncluirDATTRNPNDACOCMCNulo, IncluirDATVNCNGCPNDFRNNulo, NUMCHQPND, NUMNOTFSCFRNCTB, NUMORDPGTPND, NUMPNDFRN, NUMSEQPGTPND, VLRPGOPND)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0125038
    ''' Descrição da entidade:CADASTRO FAIXA DE AVALIACAO
    ''' </summary>
    ''' <param name="CODEDEABGMIX">CODIGO DA ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <param name="CODFXAAVL">CODIGO DA FAIXA DE AVALIACAO.</param>
    ''' <param name="NUMCSLCTTFRN">NUMERO DA CLAUSULA DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMCTTFRN">NUMERO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="TIPEDEABGMIX">TIPO DE ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterFaixaAvaliacao(ByVal CODEDEABGMIX As Decimal, _
                                               ByVal CODFXAAVL As Decimal, _
                                               ByVal NUMCSLCTTFRN As Decimal, _
                                               ByVal NUMCTTFRN As Decimal, _
                                               ByVal TIPEDEABGMIX As Decimal) As wsAcoesComerciais.DatasetFaixaAvaliacao
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterFaixaAvaliacao(CODEDEABGMIX, CODFXAAVL, NUMCSLCTTFRN, NUMCTTFRN, TIPEDEABGMIX)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0125038
    ''' Descrição da entidade:CADASTRO FAIXA DE AVALIACAO
    ''' </summary>
    ''' <param name="CODEDEABGMIX">CODIGO DA ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <param name="CODFXAAVL">CODIGO DA FAIXA DE AVALIACAO.</param>
    ''' <param name="NUMCSLCTTFRN">NUMERO DA CLAUSULA DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMCTTFRN">NUMERO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="TIPEDEABGMIX">TIPO DE ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterFaixasAvaliacao(ByVal CODEDEABGMIX As Decimal, _
                                                ByVal CODFXAAVL As Decimal, _
                                                ByVal NUMCSLCTTFRN As Decimal, _
                                                ByVal NUMCTTFRN As Decimal, _
                                                ByVal TIPEDEABGMIX As Decimal) As wsAcoesComerciais.DatasetFaixaAvaliacao
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterFaixasAvaliacao(CODEDEABGMIX, CODFXAAVL, NUMCSLCTTFRN, NUMCTTFRN, TIPEDEABGMIX)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0124953
    ''' Descrição da entidade:CADASTRO CLAUSULA CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="NUMCSLCTTFRN">NUMERO DA CLAUSULA DO CONTRATO DE FORNECIMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterClausulaContrato(ByVal NUMCSLCTTFRN As Decimal) As wsAcoesComerciais.DatasetClausulaContrato
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterClausulaContrato(NUMCSLCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NUMCTTFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	30/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterAbrangenciaAditamento(ByVal NUMCTTFRN As Decimal) As wsAcoesComerciais.DatasetContrato
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterAbrangenciaAditamento(NUMCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NUMCTTFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	10/8/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterAditamentoPorNUMCTTFRN(ByVal NUMCTTFRN As Decimal) As wsAcoesComerciais.DatasetContrato
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterAditamentoPorNUMCTTFRN(NUMCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NUMCTTFRN"></param>
    ''' <param name="NUMCSLCTTFRN"></param>
    ''' <param name="TIPEDEABGMIX"></param>
    ''' <param name="CODEDEABGMIX"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	5/8/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterAditamento(ByVal NUMCTTFRN As Decimal, _
                                        ByVal NUMCSLCTTFRN As Decimal, _
                                        ByVal TIPEDEABGMIX As Decimal, _
                                        ByVal CODEDEABGMIX As Decimal) As wsAcoesComerciais.DatasetContrato
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterAditamento(NUMCTTFRN, NUMCSLCTTFRN, TIPEDEABGMIX, CODEDEABGMIX)
    End Function


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NUMCTTFRN"></param>
    ''' <param name="NUMCSLCTTFRN"></param>
    ''' <param name="TIPEDEABGMIX"></param>
    ''' <param name="CODEDEABGMIX"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	3/9/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterDadosSimulacao(ByVal NUMCTTFRN As Decimal, _
                                       ByVal NUMCSLCTTFRN As Decimal, _
                                       ByVal TIPEDEABGMIX As Decimal, _
                                       ByVal CODEDEABGMIX As Decimal) As wsAcoesComerciais.DatasetContrato
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterDadosSimulacao(NUMCTTFRN, NUMCSLCTTFRN, TIPEDEABGMIX, CODEDEABGMIX)
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NUMCTTFRN"></param>
    ''' <param name="NUMCSLCTTFRN"></param>
    ''' <param name="TIPEDEABGMIX"></param>
    ''' <param name="CODEDEABGMIX"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	10/8/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterAditamentoPorChave(ByVal NUMCTTFRN As Decimal, _
                                       ByVal NUMCSLCTTFRN As Decimal, _
                                       ByVal TIPEDEABGMIX As Decimal, _
                                       ByVal CODEDEABGMIX As Decimal) As wsAcoesComerciais.DatasetContrato
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterAditamentoPorChave(NUMCTTFRN, NUMCSLCTTFRN, TIPEDEABGMIX, CODEDEABGMIX)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NUMCTTFRN"></param>
    ''' <param name="NUMCSLCTTFRN"></param>
    ''' <param name="TIPEDEABGMIX"></param>
    ''' <param name="CODEDEABGMIX"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	7/8/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterAditamentoGravado(ByVal NUMCTTFRN As Decimal, _
                                       ByVal NUMCSLCTTFRN As Decimal, _
                                       ByVal TIPEDEABGMIX As Decimal, _
                                       ByVal CODEDEABGMIX As Decimal) As wsAcoesComerciais.DatasetContrato
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterAditamentoGravado(NUMCTTFRN, NUMCSLCTTFRN, TIPEDEABGMIX, CODEDEABGMIX)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0124953
    ''' Descrição da entidade:CADASTRO CLAUSULA CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="NUMCSLCTTFRN">NUMERO DA CLAUSULA DO CONTRATO DE FORNECIMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterClausulasContrato(ByVal DESCSLCTTFRN As String, _
                                                  ByVal NUMCSLCTTFRN As Decimal) As wsAcoesComerciais.DatasetClausulaContrato
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterClausulasContrato(DESCSLCTTFRN, NUMCSLCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0124970
    ''' Descrição da entidade:CADASTRO TIPO DE PERIODO
    ''' </summary>
    ''' <param name="TIPPODCTTFRN">TIPO DE PERIODO CONTRATO DE FORNECIMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTipoPeriodo(ByVal TIPPODCTTFRN As Decimal) As wsAcoesComerciais.DatasetTipoPeriodo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTipoPeriodo(TIPPODCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0124970
    ''' Descrição da entidade:CADASTRO TIPO DE PERIODO
    ''' </summary>
    ''' <param name="TIPPODCTTFRN">TIPO DE PERIODO CONTRATO DE FORNECIMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTiposPeriodo(ByVal DESPODCTTFRN As String, _
                                             ByVal TIPPODCTTFRN As Decimal) As wsAcoesComerciais.DatasetTipoPeriodo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTiposPeriodo(DESPODCTTFRN, TIPPODCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0124945
    ''' Descrição da entidade:CADASTRO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="NUMCTTFRN">NUMERO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterContrato(ByVal NUMCTTFRN As Decimal) As wsAcoesComerciais.DatasetContrato
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterContrato(NUMCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0124945
    ''' Descrição da entidade:CADASTRO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="NUMCTTFRN">NUMERO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterContratos(ByVal CODAGEBCOCTTFRN As Decimal, _
                                          ByVal CODBCOCTTFRN As Decimal, _
                                          ByVal CODCNTCRRBCOCTTFRN As String, _
                                          ByVal CODFRN As Decimal, _
                                          ByVal TIPPODCTTFRN As Decimal) As wsAcoesComerciais.DatasetContrato
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterContratos(CODAGEBCOCTTFRN, CODBCOCTTFRN, CODCNTCRRBCOCTTFRN, CODFRN, TIPPODCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0124945
    ''' Descrição da entidade:CADASTRO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="NUMCTTFRN">NUMERO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    16/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterContratosAtivos(ByVal CODAGEBCOCTTFRN As Decimal, _
                                                ByVal CODBCOCTTFRN As Decimal, _
                                                ByVal CODCNTCRRBCOCTTFRN As String, _
                                                ByVal CODFRN As Decimal, _
                                                ByVal TIPPODCTTFRN As Decimal) As wsAcoesComerciais.DatasetContrato
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterContratosAtivos(CODAGEBCOCTTFRN, CODBCOCTTFRN, CODCNTCRRBCOCTTFRN, CODFRN, TIPPODCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0124996
    ''' Descrição da entidade:RELACAO COM CONTRATO DE FORNECIMENTO E ABRANGENCIA DO MIX
    ''' </summary>
    ''' <param name="CODEDEABGMIX">CODIGO DA ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <param name="NUMCSLCTTFRN">NUMERO DA CLAUSULA DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMCTTFRN">NUMERO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="TIPEDEABGMIX">TIPO DE ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterContratoXAbrangenciaMix(ByVal CODEDEABGMIX As Decimal, _
                                                        ByVal NUMCSLCTTFRN As Decimal, _
                                                        ByVal NUMCTTFRN As Decimal, _
                                                        ByVal TIPEDEABGMIX As Decimal) As wsAcoesComerciais.DatasetContratoXAbrangenciaMix
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterContratoXAbrangenciaMix(CODEDEABGMIX, NUMCSLCTTFRN, NUMCTTFRN, TIPEDEABGMIX)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0124996
    ''' Descrição da entidade:RELACAO COM CONTRATO DE FORNECIMENTO E ABRANGENCIA DO MIX
    ''' </summary>
    ''' <param name="CODEDEABGMIX">CODIGO DA ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <param name="NUMCSLCTTFRN">NUMERO DA CLAUSULA DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMCTTFRN">NUMERO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="TIPEDEABGMIX">TIPO DE ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterContratosXAbrangenciasMix(ByVal CODEDEABGMIX As Decimal, _
                                                          ByVal NUMCSLCTTFRN As Decimal, _
                                                          ByVal NUMCTTFRN As Decimal, _
                                                          ByVal TIPEDEABGMIX As Decimal) As wsAcoesComerciais.DatasetContratoXAbrangenciaMix
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterContratosXAbrangenciasMix(CODEDEABGMIX, NUMCSLCTTFRN, NUMCTTFRN, TIPEDEABGMIX)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem contrato X Abrangencia do Mix com dados das mercadorias
    ''' </summary>
    ''' <param name="CODEDEABGMIX"></param>
    ''' <param name="NUMCSLCTTFRN"></param>
    ''' <param name="NUMCTTFRN"></param>
    ''' <param name="TIPEDEABGMIX"></param>
    ''' <param name="CODFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	16/3/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterContratosXAbrangenciasMix(ByVal CODEDEABGMIX As Decimal, _
                                                          ByVal NUMCSLCTTFRN As Decimal, _
                                                          ByVal NUMCTTFRN As Decimal, _
                                                          ByVal TIPEDEABGMIX As Decimal, _
                                                          ByVal CODFRN As Decimal) As wsAcoesComerciais.DatasetContratoXAbrangenciaMix
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterContratoXAbrangenciaMix2(CODEDEABGMIX, NUMCSLCTTFRN, NUMCTTFRN, TIPEDEABGMIX, CODFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0123086
    ''' Descrição da entidade:MOVIMENTO DIARIO CONTA CORRENTE FORNECEDOR
    ''' </summary>
    ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
    ''' <param name="CODGDC">CODIGO CONTROLE TRANSACAO CABECALHO DE UM LANCAMENTO.</param>
    ''' <param name="DATREFLMT">DATA REFERENCIA (AAAA-MM-DD).</param>
    ''' <param name="NUMSEQLMT">NUMERO SEQUENCIA.</param>
    ''' <param name="TIPDSNDSCBNF">TIPO DESTINO / DESCONTO BONIFICADO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterContaCorrenteFornecedor(ByVal CODFRN As Decimal, _
                                                        ByVal CODGDC As String, _
                                                        ByVal DATREFLMT As Date, _
                                                        ByVal NUMSEQLMT As Decimal, _
                                                        ByVal TIPDSNDSCBNF As Decimal) As wsAcoesComerciais.DatasetContaCorrenteFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterContaCorrenteFornecedor(CODFRN, CODGDC, DATREFLMT, NUMSEQLMT, TIPDSNDSCBNF)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0123086
    ''' Descrição da entidade:MOVIMENTO DIARIO CONTA CORRENTE FORNECEDOR
    ''' </summary>
    ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
    ''' <param name="CODGDC">CODIGO CONTROLE TRANSACAO CABECALHO DE UM LANCAMENTO.</param>
    ''' <param name="DATREFLMT">DATA REFERENCIA (AAAA-MM-DD).</param>
    ''' <param name="NUMSEQLMT">NUMERO SEQUENCIA.</param>
    ''' <param name="TIPDSNDSCBNF">TIPO DESTINO / DESCONTO BONIFICADO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterContasCorrenteFornecedor(ByVal CODCENCSTCRD As String, _
                                                         ByVal CODCENCSTDEB As String, _
                                                         ByVal CODCNTCRD As String, _
                                                         ByVal CODCNTDEB As String, _
                                                         ByVal CODFILEMP As Decimal, _
                                                         ByVal CODFRN As Decimal, _
                                                         ByVal CODGDC As String, _
                                                         ByVal CODPMS As Decimal, _
                                                         ByVal CODTIPLMT As Decimal, _
                                                         ByVal DATREFLMT As Date, _
                                                         ByVal DATREFLMTInicial As Date, _
                                                         ByVal DATREFLMTFinal As Date, _
                                                         ByVal DESHSTLMT As String, _
                                                         ByVal DESVARHSTPAD As String, _
                                                         ByVal NUMSEQLMT As Decimal, _
                                                         ByVal TIPDSNDSCBNF As Decimal) As wsAcoesComerciais.DatasetContaCorrenteFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterContasCorrenteFornecedor(CODCENCSTCRD, CODCENCSTDEB, CODCNTCRD, CODCNTDEB, CODFILEMP, CODFRN, CODGDC, CODPMS, CODTIPLMT, DATREFLMT, DATREFLMTInicial, DATREFLMTFinal, DESHSTLMT, DESVARHSTPAD, NUMSEQLMT, TIPDSNDSCBNF)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0123094
    ''' Descrição da entidade:PARAMETRO CONTABIL CONTA CORRENTE FORNECEDOR
    ''' </summary>
    ''' <param name="CODFILEMP">CODIGO DA FILIAL DA EMPRESA.</param>
    ''' <param name="CODTIPLMT">CODIGO TIPO LANCAMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterParametroContabilContaCorrenteFornecedor(ByVal CODFILEMP As Decimal, _
                                                                         ByVal CODTIPLMT As Decimal) As wsAcoesComerciais.DatasetParametroContabilContaCorrenteFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterParametroContabilContaCorrenteFornecedor(CODFILEMP, CODTIPLMT)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0123094
    ''' Descrição da entidade:PARAMETRO CONTABIL CONTA CORRENTE FORNECEDOR
    ''' </summary>
    ''' <param name="CODFILEMP">CODIGO DA FILIAL DA EMPRESA.</param>
    ''' <param name="CODTIPLMT">CODIGO TIPO LANCAMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterParametrosContabilContaCorrenteFornecedor(ByVal CODCENCSTCRD As String, _
                                                                          ByVal CODCENCSTDEB As String, _
                                                                          ByVal CODCNTCRD As String, _
                                                                          ByVal CODCNTDEB As String, _
                                                                          ByVal CODEVTCTB As Decimal, _
                                                                          ByVal CODEVTCTBFRTDVL As Decimal, _
                                                                          ByVal CODEVTCTBNGCDVL As Decimal, _
                                                                          ByVal CODFILEMP As Decimal, _
                                                                          ByVal CODFTOCTB As Decimal, _
                                                                          ByVal CODFTOCTBFRTDVL As Decimal, _
                                                                          ByVal CODFTOCTBNGCDVL As Decimal, _
                                                                          ByVal CODHSTPAD As String, _
                                                                          ByVal CODTIPLMT As Decimal) As wsAcoesComerciais.DatasetParametroContabilContaCorrenteFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterParametrosContabilContaCorrenteFornecedor(CODCENCSTCRD, CODCENCSTDEB, CODCNTCRD, CODCNTDEB, CODEVTCTB, CODEVTCTBFRTDVL, CODEVTCTBNGCDVL, CODFILEMP, CODFTOCTB, CODFTOCTBFRTDVL, CODFTOCTBNGCDVL, CODHSTPAD, CODTIPLMT)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0123108
    ''' Descrição da entidade:CADASTRO TIPO LANCAMENTO CONTA CORRENTE FORNECEDOR
    ''' </summary>
    ''' <param name="CODTIPLMT">CODIGO TIPO LANCAMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTipoLancamentoContaCorrenteFornecedor(ByVal CODTIPLMT As Decimal) As wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTipoLancamentoContaCorrenteFornecedor(CODTIPLMT)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0123108
    ''' Descrição da entidade:CADASTRO TIPO LANCAMENTO CONTA CORRENTE FORNECEDOR
    ''' </summary>
    ''' <param name="CODTIPLMT">CODIGO TIPO LANCAMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTiposLancamentoContaCorrenteFornecedor(ByVal DESTIPLMT As String, _
                                                                       ByVal DESTIPLMTFRN As String) As wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTiposLancamentoContaCorrenteFornecedor(DESTIPLMT, DESTIPLMTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos chave primária
    ''' Entidade T062251
    ''' Descrição da entidade:CADASTRO TIPO LANCAMENTO CONTA CORRENTE FORNECEDOR
    ''' </summary>
    ''' <param name="CODTIPLMTASC">CODIGO TIPO LANCAMENTO ASSOCIADO.</param>
    ''' <param name="CODTIPLMTPCP">CODIGO TIPO LANCAMENTO PRINCIPAL.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Elifázio Bernardes]    23/08/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTipoLancamentoPrincipalXTipoLancamentoAssociado(ByVal CODTIPLMTASC As Decimal, _
                                                                                ByVal CODTIPLMTPCP As Decimal) As wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTipoLancamentoPrincipalXTipoLancamentoAssociado(CODTIPLMTASC, CODTIPLMTPCP)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0113552
    ''' Descrição da entidade:CADASTRO FORMA / DESCONTO BONIFICACAO PEDIDO COMPRA
    ''' </summary>
    ''' <param name="TIPFRMDSCBNF">TIPO FORMA DESCONTO BONIFICACAO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterFormaPagamento(ByVal TIPFRMDSCBNF As Decimal) As wsAcoesComerciais.DatasetFormaPagamento
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterFormaPagamento(TIPFRMDSCBNF)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0113552
    ''' Descrição da entidade:CADASTRO FORMA / DESCONTO BONIFICACAO PEDIDO COMPRA
    ''' </summary>
    ''' <param name="TIPFRMDSCBNF">TIPO FORMA DESCONTO BONIFICACAO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterFormasPagamento(ByVal DESFRMDSCBNF As String, ByVal INDDSCGRCACOCMC As Decimal) As wsAcoesComerciais.DatasetFormaPagamento
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterFormasPagamento(DESFRMDSCBNF, INDDSCGRCACOCMC)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0118902
    ''' Descrição da entidade:MOVIMENTO DIARIO BAIXA ORDEM PAGAMENTO DO FORNECEDOR - COMPRAS
    ''' </summary>
    ''' <param name="CODAGE">.</param>
    ''' <param name="CODBCO">CODIGO BANCO.</param>
    ''' <param name="DATRCBORDPGT">.</param>
    ''' <param name="NUMORDPGTFRN">.</param>
    ''' <param name="NUMSEQORDPGT">.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterBaixaOPFornecedor(ByVal CODAGE As Decimal, _
                                                  ByVal CODBCO As Decimal, _
                                                  ByVal DATRCBORDPGT As Date, _
                                                  ByVal NUMORDPGTFRN As Decimal, _
                                                  ByVal NUMSEQORDPGT As Decimal) As wsAcoesComerciais.DatasetBaixaOPFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterBaixaOPFornecedor(CODAGE, CODBCO, DATRCBORDPGT, NUMORDPGTFRN, NUMSEQORDPGT)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0118902
    ''' Descrição da entidade:MOVIMENTO DIARIO BAIXA ORDEM PAGAMENTO DO FORNECEDOR - COMPRAS
    ''' </summary>
    ''' <param name="CODAGE">.</param>
    ''' <param name="CODBCO">CODIGO BANCO.</param>
    ''' <param name="DATRCBORDPGT">.</param>
    ''' <param name="NUMORDPGTFRN">.</param>
    ''' <param name="NUMSEQORDPGT">.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterBaixasOPFornecedor(ByVal CODAGE As Decimal, _
                                                   ByVal CODBCO As Decimal, _
                                                   ByVal CODEMP As Decimal, _
                                                   ByVal CODFILEMP As Decimal, _
                                                   ByVal CODPMS As Decimal, _
                                                   ByVal DATLMTCNTCRR As Date, _
                                                   ByVal DATLMTCNTCRRInicial As Date, _
                                                   ByVal DATLMTCNTCRRFinal As Date, _
                                                   ByVal NUMORDPGTFRN As Decimal, _
                                                   ByVal NUMPNDFRN As Decimal, _
                                                   ByVal NUMSEQORDPGT As Decimal) As wsAcoesComerciais.DatasetBaixaOPFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterBaixasOPFornecedor(CODAGE, CODBCO, CODEMP, CODFILEMP, CODPMS, DATLMTCNTCRR, DATLMTCNTCRRInicial, DATLMTCNTCRRFinal, NUMORDPGTFRN, NUMPNDFRN, NUMSEQORDPGT)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0118899
    ''' Descrição da entidade:MOVIMENTO DIARIO BAIXA DE CHEQUE RECEBIDO DO FORNECEDOR - COMPRAS
    ''' </summary>
    ''' <param name="CODAGE">CODIGO AGENCIA.</param>
    ''' <param name="CODBCO">CODIGO BANCO.</param>
    ''' <param name="DATRCBCHQ">.</param>
    ''' <param name="NUMCHQ">NUMERO DO CHEQUE.</param>
    ''' <param name="NUMSEQPGT">NUMERO DE SEQUENCIA PAGAMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterBaixaCHFornecedor(ByVal CODAGE As Decimal, _
                                                  ByVal CODBCO As Decimal, _
                                                  ByVal DATRCBCHQ As Date, _
                                                  ByVal NUMCHQ As Decimal, _
                                                  ByVal NUMSEQPGT As Decimal) As wsAcoesComerciais.DatasetBaixaCHFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterBaixaCHFornecedor(CODAGE, CODBCO, DATRCBCHQ, NUMCHQ, NUMSEQPGT)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0118899
    ''' Descrição da entidade:MOVIMENTO DIARIO BAIXA DE CHEQUE RECEBIDO DO FORNECEDOR - COMPRAS
    ''' </summary>
    ''' <param name="CODAGE">CODIGO AGENCIA.</param>
    ''' <param name="CODBCO">CODIGO BANCO.</param>
    ''' <param name="DATRCBCHQ">.</param>
    ''' <param name="NUMCHQ">NUMERO DO CHEQUE.</param>
    ''' <param name="NUMSEQPGT">NUMERO DE SEQUENCIA PAGAMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterBaixasCHFornecedor(ByVal CODAGE As Decimal, _
                                                   ByVal CODBCO As Decimal, _
                                                   ByVal CODEMP As Decimal, _
                                                   ByVal CODFILEMP As Decimal, _
                                                   ByVal CODPMS As Decimal, _
                                                   ByVal DATPRVRCBPMS As Date, _
                                                   ByVal DATPRVRCBPMSInicial As Date, _
                                                   ByVal DATPRVRCBPMSFinal As Date, _
                                                   ByVal NUMCHQ As Decimal, _
                                                   ByVal NUMSEQPGT As Decimal) As wsAcoesComerciais.DatasetBaixaCHFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterBaixasCHFornecedor(CODAGE, CODBCO, CODEMP, CODFILEMP, CODPMS, DATPRVRCBPMS, DATPRVRCBPMSInicial, DATPRVRCBPMSFinal, NUMCHQ, NUMSEQPGT)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0118880
    ''' Descrição da entidade:MOVIMENTO DIARIO ORDEM PAGAMENTO RECEBIDO DO FORNECEDOR - COMPRAS
    ''' </summary>
    ''' <param name="CODAGE">CODIGO AGENCIA.</param>
    ''' <param name="CODBCO">CODIGO BANCO.</param>
    ''' <param name="DATRCBORDPGT">DATA DE RECEBIMENTO ORDEM DE PAGAMENTO.</param>
    ''' <param name="NUMORDPGTFRN">NUMERO DA ORDEM DE PAGAMENTO FORNECEDOR.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterOPRecebidaFornecedor(ByVal CODAGE As Decimal, _
                                                     ByVal CODBCO As Decimal, _
                                                     ByVal DATRCBORDPGT As Date, _
                                                     ByVal NUMORDPGTFRN As Decimal) As wsAcoesComerciais.DatasetOPRecebidaFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterOPRecebidaFornecedor(CODAGE, CODBCO, DATRCBORDPGT, NUMORDPGTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0118880
    ''' Descrição da entidade:MOVIMENTO DIARIO ORDEM PAGAMENTO RECEBIDO DO FORNECEDOR - COMPRAS
    ''' </summary>
    ''' <param name="CODAGE">CODIGO AGENCIA.</param>
    ''' <param name="CODBCO">CODIGO BANCO.</param>
    ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
    ''' <param name="DATRCBORDPGT">DATA DE RECEBIMENTO ORDEM DE PAGAMENTO.</param>
    ''' <param name="DATRCBORDPGTInicial">DATA DE RECEBIMENTO ORDEM DE PAGAMENTO INICIAL.</param>
    ''' <param name="DATRCBORDPGTFinal">DATA DE RECEBIMENTO ORDEM DE PAGAMENTO FINAL.</param>
    ''' <param name="DATTRNORDPGTFRN">DATA DE TRANSFERENCIA DA ORDEM DE PAGTO DO FORNECEDOR.</param>
    ''' <param name="DATTRNORDPGTFRNInicial">DATA DE TRANSFERENCIA DA ORDEM DE PAGTO DO FORNECEDOR INICIAL.</param>
    ''' <param name="DATTRNORDPGTFRNFinal">DATA DE TRANSFERENCIA DA ORDEM DE PAGTO DO FORNECEDOR FINAL.</param>
    ''' <param name="DATULTPMSORD">DATA DA ÚLTIMA PROMESSA ORDEM.</param>
    ''' <param name="DATULTPMSORDInicial">DATA DA ÚLTIMA PROMESSA ORDEM INICIAL.</param>
    ''' <param name="DATULTPMSORDFinal">DATA DA ÚLTIMA PROMESSA ORDEM FINAL.</param>
    ''' <param name="IncluirDATULTPMSORDNulo"> Valores: [0:Não incluir no resultado se o campo for nulo | 1:Incluir no resultado se campo for nulo | 3:Independente do valor do campo incluir no resultado] - DATA DA ÚLTIMA PROMESSA ORDEM.</param>
    ''' <param name="DESHSTDPSIDTFRN">DESCRICAO DO HISTORICO DO DEPOSITO IDENTIFICADO DO FORN.</param>
    ''' <param name="NUMORDPGTFRN">NUMERO DA ORDEM DE PAGAMENTO FORNECEDOR.</param>
    ''' <param name="NUMORDPGTORIFRN">NUMERO DA ORDEM DE PAGTO ORIGINAL DO FORNECEDOR.</param>
    ''' <param name="TIPOPEBXAORDPGTFRN">TIPO DE OPERACAO DE BAIXA DA ORDEM DE PAGTO DE FORNECED.</param>
    ''' <param name="TIPORIORDPGTFRN">TIPO DE ORIGEM DA ORDEM DE PAGTO FORNECEDOR.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0118880" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    31/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterOPsRecebidaFornecedor(ByVal CODAGE As Decimal, _
                                                      ByVal CODBCO As Decimal, _
                                                      ByVal CODFRN As Decimal, _
                                                      ByVal DATRCBORDPGT As Date, _
                                                      ByVal DATRCBORDPGTInicial As Date, _
                                                      ByVal DATRCBORDPGTFinal As Date, _
                                                      ByVal DATTRNORDPGTFRN As Date, _
                                                      ByVal DATTRNORDPGTFRNInicial As Date, _
                                                      ByVal DATTRNORDPGTFRNFinal As Date, _
                                                      ByVal DATULTPMSORD As Date, _
                                                      ByVal DATULTPMSORDInicial As Date, _
                                                      ByVal DATULTPMSORDFinal As Date, _
                                                      ByVal IncluirDATULTPMSORDNulo As Int16, _
                                                      ByVal DESHSTDPSIDTFRN As String, _
                                                      ByVal NUMORDPGTFRN As Decimal, _
                                                      ByVal NUMORDPGTORIFRN As Decimal, _
                                                      ByVal TIPOPEBXAORDPGTFRN As Decimal, _
                                                      ByVal TIPORIORDPGTFRN As Decimal) As wsAcoesComerciais.DatasetOPRecebidaFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterOPsRecebidaFornecedor(CODAGE, CODBCO, CODFRN, DATRCBORDPGT, DATRCBORDPGTInicial, DATRCBORDPGTFinal, DATTRNORDPGTFRN, DATTRNORDPGTFRNInicial, DATTRNORDPGTFRNFinal, DATULTPMSORD, DATULTPMSORDInicial, DATULTPMSORDFinal, IncluirDATULTPMSORDNulo, DESHSTDPSIDTFRN, NUMORDPGTFRN, NUMORDPGTORIFRN, TIPOPEBXAORDPGTFRN, TIPORIORDPGTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0118872
    ''' Descrição da entidade:MOVIMENTO DIARIO CHEQUE RECEBIDO DO FORNECEDOR - COMPRAS
    ''' </summary>
    ''' <param name="CODAGE">CODIGO AGENCIA.</param>
    ''' <param name="CODBCO">CODIGO BANCO.</param>
    ''' <param name="DATRCBCHQ">DATA DE RECEBIMENTO DO CHEQUE.</param>
    ''' <param name="NUMCHQ">NUMERO DO CHEQUE.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterCHRecebidoFornecedor(ByVal CODAGE As Decimal, _
                                                     ByVal CODBCO As Decimal, _
                                                     ByVal DATRCBCHQ As Date, _
                                                     ByVal NUMCHQ As Decimal) As wsAcoesComerciais.DatasetCHRecebidoFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterCHRecebidoFornecedor(CODAGE, CODBCO, DATRCBCHQ, NUMCHQ)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0118872
    ''' Descrição da entidade:MOVIMENTO DIARIO CHEQUE RECEBIDO DO FORNECEDOR - COMPRAS
    ''' </summary>
    ''' <param name="CODAGE">CODIGO AGENCIA.</param>
    ''' <param name="CODBCO">CODIGO BANCO.</param>
    ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
    ''' <param name="DATRCBCHQ">DATA DE RECEBIMENTO DO CHEQUE.</param>
    ''' <param name="DATRCBCHQInicial">DATA DE RECEBIMENTO DO CHEQUE INICIAL.</param>
    ''' <param name="DATRCBCHQFinal">DATA DE RECEBIMENTO DO CHEQUE FINAL.</param>
    ''' <param name="IncluirDATULTPMSCHQNulo"> Valores: [0:Não incluir no resultado se o campo for nulo | 1:Incluir no resultado se campo for nulo | 3:Independente do valor do campo incluir no resultado] - DATA DA ULTIMA PROMESSA DE CHEQUE.</param>
    ''' <param name="NUMCHQ">NUMERO DO CHEQUE.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0118872" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    31/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterCHsRecebidoFornecedor(ByVal CODAGE As Decimal, _
                                                      ByVal CODBCO As Decimal, _
                                                      ByVal CODFRN As Decimal, _
                                                      ByVal DATRCBCHQ As Date, _
                                                      ByVal DATRCBCHQInicial As Date, _
                                                      ByVal DATRCBCHQFinal As Date, _
                                                      ByVal IncluirDATULTPMSCHQNulo As Int16, _
                                                      ByVal NUMCHQ As Decimal) As wsAcoesComerciais.DatasetCHRecebidoFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterCHsRecebidoFornecedor(CODAGE, CODBCO, CODFRN, DATRCBCHQ, DATRCBCHQInicial, DATRCBCHQFinal, IncluirDATULTPMSCHQNulo, NUMCHQ)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0118082
    ''' Descrição da entidade:CADASTRO SITUACAO DE ACORDO
    ''' </summary>
    ''' <param name="CODSITPMS">CODIGO SITUACAO PROMESSA.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterSituacaoAcordo(ByVal CODSITPMS As Decimal) As wsAcoesComerciais.DatasetSituacaoAcordo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterSituacaoAcordo(CODSITPMS)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0118082
    ''' Descrição da entidade:CADASTRO SITUACAO DE ACORDO
    ''' </summary>
    ''' <param name="CODSITPMS">CODIGO SITUACAO PROMESSA.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterSituacoesAcordo(ByVal DESSITPMS As String) As wsAcoesComerciais.DatasetSituacaoAcordo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterSituacoesAcordo(DESSITPMS)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0118074
    ''' Descrição da entidade:PARAMETRO SISTEMA DE GESTAO DE ACAOCOMERCIAL
    ''' </summary>
    ''' <param name="CODEMP">CODIGO EMPRESA.</param>
    ''' <param name="CODFILEMP">CODIGO DA FILIAL DA EMPRESA.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterParametroGestaoAcaoComercial(ByVal CODEMP As Decimal, _
                                                             ByVal CODFILEMP As Decimal) As wsAcoesComerciais.DatasetParametroGestaoAcaoComercial
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterParametroGestaoAcaoComercial(CODEMP, CODFILEMP)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0118074
    ''' Descrição da entidade:PARAMETRO SISTEMA DE GESTAO DE ACAOCOMERCIAL
    ''' </summary>
    ''' <param name="CODEMP">CODIGO EMPRESA.</param>
    ''' <param name="CODFILEMP">CODIGO DA FILIAL DA EMPRESA.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterParametrosGestaoAcaoComercial(ByVal CODEMP As Decimal, _
                                                              ByVal CODFILEMP As Decimal) As wsAcoesComerciais.DatasetParametroGestaoAcaoComercial
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterParametrosGestaoAcaoComercial(CODEMP, CODFILEMP)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0118058
    ''' Descrição da entidade:MOVIMENTO DIARIO DE PROMESSA  SISTEMA
    ''' </summary>
    ''' <param name="CODEMP">CODIGO EMPRESA.</param>
    ''' <param name="CODFILEMP">CODIGO DA FILIAL DA EMPRESA.</param>
    ''' <param name="CODPMS">CODIGO PROMESSA.</param>
    ''' <param name="DATNGCPMS">DATA DA NEGOCIACAO DA PROMESSA.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterAcordo(ByVal CODEMP As Decimal, _
                                       ByVal CODFILEMP As Decimal, _
                                       ByVal CODPMS As Decimal, _
                                       ByVal DATNGCPMS As Date) As wsAcoesComerciais.DatasetAcordo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterAcordo(CODEMP, CODFILEMP, CODPMS, DATNGCPMS)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0118058
    ''' Descrição da entidade:MOVIMENTO DIARIO DE PROMESSA  SISTEMA
    ''' </summary>
    ''' <param name="CODEMP">CODIGO EMPRESA.</param>
    ''' <param name="CODFILEMP">CODIGO DA FILIAL DA EMPRESA.</param>
    ''' <param name="CODPMS">CODIGO PROMESSA.</param>
    ''' <param name="DATNGCPMS">DATA DA NEGOCIACAO DA PROMESSA.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterAcordos(ByVal CODEMP As Decimal, _
                                        ByVal CODFILEMP As Decimal, _
                                        ByVal CODFRN As Decimal, _
                                        ByVal CODPMS As Decimal, _
                                        ByVal CODSITPMS As Decimal, _
                                        ByVal DATCADPMS As Date, _
                                        ByVal DATCADPMSInicial As Date, _
                                        ByVal DATCADPMSFinal As Date, _
                                        ByVal DATCNCPED As Date, _
                                        ByVal DATCNCPEDInicial As Date, _
                                        ByVal DATCNCPEDFinal As Date, _
                                        ByVal DATEFTPMS As Date, _
                                        ByVal DATEFTPMSInicial As Date, _
                                        ByVal DATEFTPMSFinal As Date, _
                                        ByVal DATNGCPMS As Date, _
                                        ByVal DATNGCPMSInicial As Date, _
                                        ByVal DATNGCPMSFinal As Date, _
                                        ByVal NOMCTOFRN As String, _
                                        ByVal NUMPEDCMP As Decimal) As wsAcoesComerciais.DatasetAcordo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterAcordos(CODEMP, CODFILEMP, CODFRN, CODPMS, CODSITPMS, DATCADPMS, DATCADPMSInicial, DATCADPMSFinal, DATCNCPED, DATCNCPEDInicial, DATCNCPEDFinal, DATEFTPMS, DATEFTPMSInicial, DATEFTPMSFinal, DATNGCPMS, DATNGCPMSInicial, DATNGCPMSFinal, NOMCTOFRN, NUMPEDCMP)
    End Function

    Public Shared Function ObterAcordosPendente(ByVal CODFRN As Decimal) As wsAcoesComerciais.DatasetAcordo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterAcordosPendente(CODFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0151799
    ''' Descrição da entidade:CADASTRO DE TIPO DE ALOCACAO DE VERBAS DO FORNECEDOR
    ''' </summary>
    ''' <param name="TIPALCVBAFRN">TIPO DE ALOCACAO DA VERBA DO FORNECEDOR.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTituloPagamentoContrato(ByVal TIPALCVBAFRN As Decimal) As wsAcoesComerciais.DatasetTituloPagamentoContrato
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTituloPagamentoContrato(TIPALCVBAFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0151799
    ''' Descrição da entidade:CADASTRO DE TIPO DE ALOCACAO DE VERBAS DO FORNECEDOR
    ''' </summary>
    ''' <param name="TIPALCVBAFRN">TIPO DE ALOCACAO DA VERBA DO FORNECEDOR.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTitulosPagamentoContrato(ByVal DESALCVBAFRN As String) As wsAcoesComerciais.DatasetTituloPagamentoContrato
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTitulosPagamentoContrato(DESALCVBAFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0129440
    ''' Descrição da entidade:PARAMETRO PRORROGACAO VENCIMENTO TITULO DE PAGAMENTO FORNECEDOR
    ''' </summary>
    ''' <param name="NUMCTTFRN">NUMERO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterParametroProrrogacaoVencimento(ByVal NUMCTTFRN As Decimal) As wsAcoesComerciais.DatasetParametroProrrogacaoVencimento
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterParametroProrrogacaoVencimento(NUMCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0129440
    ''' Descrição da entidade:PARAMETRO PRORROGACAO VENCIMENTO TITULO DE PAGAMENTO FORNECEDOR
    ''' </summary>
    ''' <param name="NUMCTTFRN">NUMERO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterParametrosProrrogacaoVencimento(ByVal DESDATREFPGC As String, _
                                                                ByVal NUMCTTFRN As Decimal) As wsAcoesComerciais.DatasetParametroProrrogacaoVencimento
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterParametrosProrrogacaoVencimento(DESDATREFPGC, NUMCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0144946
    ''' Descrição da entidade:MOVIMENTO TRANSF. VERBAS ENTRE EMPENHOS ACAO COMERCIAL
    ''' </summary>
    ''' <param name="CODFRNDSNTRNVBA">CODIGO FORNECEDOR DESTINO TRANSFERENCIA VERBA.</param>
    ''' <param name="CODFRNORITRNVBA">CODIGO FORNECEDOR ORIGEM TRANSFERENCIA VERBA.</param>
    ''' <param name="CODGDCDSNTRNVBA">CODIGO CONTROLE TRANSACAO DESTINO TRANSFERENCIA VERBA.</param>
    ''' <param name="CODGDCORITRNVBA">CODIGO CONTROLE TRANSACAO ORIGEM TRANSFERENCIA VERBA.</param>
    ''' <param name="DATREFLMT">DATA REFERENCIA (AAAA-MM-DD).</param>
    ''' <param name="NUMSEQLMTDSNTRNVBA">NUMERO SEQUENCIA LANCAMENTO DESTINO TRANSFERENCIA VERBA.</param>
    ''' <param name="NUMSEQLMTORITRNVBA">NUMERO SEQUENCIA LANCAMENTO ORIGEM TRANSFERENCIA VERBA.</param>
    ''' <param name="TIPDSNDSCBNFDSNTRN">TIPO EMPENHO DESTINO TRANSFERENCIA VERBA.</param>
    ''' <param name="TIPDSNDSCBNFORITRN">TIPO EMPENHO ORIGEM TRANSFERENCIA VERBA.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTransferenciaVerbasEntreEmpenhos(ByVal CODFRNDSNTRNVBA As Decimal, _
                                                                 ByVal CODFRNORITRNVBA As Decimal, _
                                                                 ByVal CODGDCDSNTRNVBA As String, _
                                                                 ByVal CODGDCORITRNVBA As String, _
                                                                 ByVal DATREFLMT As Date, _
                                                                 ByVal NUMSEQLMTDSNTRNVBA As Decimal, _
                                                                 ByVal NUMSEQLMTORITRNVBA As Decimal, _
                                                                 ByVal TIPDSNDSCBNFDSNTRN As Decimal, _
                                                                 ByVal TIPDSNDSCBNFORITRN As Decimal) As wsAcoesComerciais.DatasetTransferenciaVerbasEntreEmpenhos
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTransferenciaVerbasEntreEmpenhos(CODFRNDSNTRNVBA, CODFRNORITRNVBA, CODGDCDSNTRNVBA, CODGDCORITRNVBA, DATREFLMT, NUMSEQLMTDSNTRNVBA, NUMSEQLMTORITRNVBA, TIPDSNDSCBNFDSNTRN, TIPDSNDSCBNFORITRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0144946
    ''' Descrição da entidade:MOVIMENTO TRANSF. VERBAS ENTRE EMPENHOS ACAO COMERCIAL
    ''' </summary>
    ''' <param name="CODFRNDSNTRNVBA">CODIGO FORNECEDOR DESTINO TRANSFERENCIA VERBA.</param>
    ''' <param name="CODFRNORITRNVBA">CODIGO FORNECEDOR ORIGEM TRANSFERENCIA VERBA.</param>
    ''' <param name="CODGDCDSNTRNVBA">CODIGO CONTROLE TRANSACAO DESTINO TRANSFERENCIA VERBA.</param>
    ''' <param name="CODGDCORITRNVBA">CODIGO CONTROLE TRANSACAO ORIGEM TRANSFERENCIA VERBA.</param>
    ''' <param name="DATREFLMT">DATA REFERENCIA (AAAA-MM-DD).</param>
    ''' <param name="NUMSEQLMTDSNTRNVBA">NUMERO SEQUENCIA LANCAMENTO DESTINO TRANSFERENCIA VERBA.</param>
    ''' <param name="NUMSEQLMTORITRNVBA">NUMERO SEQUENCIA LANCAMENTO ORIGEM TRANSFERENCIA VERBA.</param>
    ''' <param name="TIPDSNDSCBNFDSNTRN">TIPO EMPENHO DESTINO TRANSFERENCIA VERBA.</param>
    ''' <param name="TIPDSNDSCBNFORITRN">TIPO EMPENHO ORIGEM TRANSFERENCIA VERBA.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTransferenciasVerbasEntreEmpenhos(ByVal CODFRNDSNTRNVBA As Decimal, _
                                                                  ByVal CODFRNORITRNVBA As Decimal, _
                                                                  ByVal CODGDCDSNTRNVBA As String, _
                                                                  ByVal CODGDCORITRNVBA As String, _
                                                                  ByVal DATREFLMT As Date, _
                                                                  ByVal DATREFLMTInicial As Date, _
                                                                  ByVal DATREFLMTFinal As Date, _
                                                                  ByVal NUMSEQLMTDSNTRNVBA As Decimal, _
                                                                  ByVal NUMSEQLMTORITRNVBA As Decimal, _
                                                                  ByVal TIPDSNDSCBNFDSNTRN As Decimal, _
                                                                  ByVal TIPDSNDSCBNFORITRN As Decimal) As wsAcoesComerciais.DatasetTransferenciaVerbasEntreEmpenhos
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTransferenciasVerbasEntreEmpenhos(CODFRNDSNTRNVBA, CODFRNORITRNVBA, CODGDCDSNTRNVBA, CODGDCORITRNVBA, DATREFLMT, DATREFLMTInicial, DATREFLMTFinal, NUMSEQLMTDSNTRNVBA, NUMSEQLMTORITRNVBA, TIPDSNDSCBNFDSNTRN, TIPDSNDSCBNFORITRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0103409
    ''' Descrição da entidade:CADASTRO EMPRESA <COPORATIVO>
    ''' </summary>
    ''' <param name="CODEMP">CODIGO EMPRESA.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterEmpresa(ByVal CODEMP As Decimal) As wsAcoesComerciais.DatasetEmpresa
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterEmpresa(CODEMP)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0103409
    ''' Descrição da entidade:CADASTRO EMPRESA <COPORATIVO>
    ''' </summary>
    ''' <param name="CODEMP">CODIGO EMPRESA.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterEmpresas(ByVal NOMEMP As String) As wsAcoesComerciais.DatasetEmpresa
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterEmpresas(NOMEMP)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0135041
    ''' Descrição da entidade:RELACAO TIPO TRANSF. DE VLRS. DE ACOES COMERCIAIS X DIVISAO DE COMPRAS
    ''' </summary>
    ''' <param name="CODDIVCMP">CODIGO DA DIVISAO DE COMPRAS.</param>
    ''' <param name="CODTIPTRNVLRACOCMC">CODIGO DO TIPO DE TRANSFERENCIA DE VALORES EM ACOES COM.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTipoTransferenciaXDivisaoCompras(ByVal CODDIVCMP As Decimal, _
                                                                 ByVal CODTIPTRNVLRACOCMC As Decimal) As wsAcoesComerciais.DatasetTipoTransferenciaXDivisaoCompras
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTipoTransferenciaXDivisaoCompras(CODDIVCMP, CODTIPTRNVLRACOCMC)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0135041
    ''' Descrição da entidade:RELACAO TIPO TRANSF. DE VLRS. DE ACOES COMERCIAIS X DIVISAO DE COMPRAS
    ''' </summary>
    ''' <param name="CODDIVCMP">CODIGO DA DIVISAO DE COMPRAS.</param>
    ''' <param name="CODTIPTRNVLRACOCMC">CODIGO DO TIPO DE TRANSFERENCIA DE VALORES EM ACOES COM.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTiposTransferenciasXDivisaoCompras(ByVal CODDIVCMP As Decimal, _
                                                                   ByVal CODTIPTRNVLRACOCMC As Decimal) As wsAcoesComerciais.DatasetTipoTransferenciaXDivisaoCompras
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTiposTransferenciasXDivisaoCompras(CODDIVCMP, CODTIPTRNVLRACOCMC)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0151810
    ''' Descrição da entidade:CADASTRO DA REQUISICAO DE ALOCACAO DE VERBAS DO FORNECEDOR
    ''' </summary>
    ''' <param name="CODREQALCVBAFRN">CODIGO REQUISICAO ALOCACAO VERBA DO FORNECEDOR.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRequisicaoAlocacaoVerbas(ByVal CODREQALCVBAFRN As Decimal) As wsAcoesComerciais.DatasetRequisicaoAlocacaoVerbas
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterRequisicaoAlocacaoVerbas(CODREQALCVBAFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0151810
    ''' Descrição da entidade:CADASTRO DA REQUISICAO DE ALOCACAO DE VERBAS DO FORNECEDOR
    ''' </summary>
    ''' <param name="CODREQALCVBAFRN">CODIGO REQUISICAO ALOCACAO VERBA DO FORNECEDOR.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRequisicoesAlocacaoVerbas(ByVal CODFNCATUAPVALCVBA As Decimal, _
                                                          ByVal CODFNCCADALCVBAFRN As Decimal, _
                                                          ByVal CODSTAALCVBAFRN As Decimal) As wsAcoesComerciais.DatasetRequisicaoAlocacaoVerbas
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterRequisicoesAlocacaoVerbas(CODFNCATUAPVALCVBA, CODFNCCADALCVBAFRN, CODSTAALCVBAFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Verifica Fornecedor Importado
    ''' </summary>
    ''' <param name="codFrnOrigem", "codFrnDestino"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Valmir]	27/10/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ValidaSeFornecedorDeOrigemEDeDestinoEMexEImportado(ByVal codFrnOrigem As Decimal, ByVal codFrnDestino As Decimal) As Boolean
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ValidaSeFornecedorDeOrigemEDeDestinoEMexEImportado(codFrnOrigem, codFrnDestino)
    End Function


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Verifica Fornecedor Importado
    ''' </summary>
    ''' <param name="CODFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Valmir]	23/10/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function VerificaFornecedorImportado(ByVal CODFRN As Decimal) As wsAcoesComerciais.DatasetFornecedorImportado
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.VerificaFornecedorImportado(CODFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Verifica Fornecedor Mex
    ''' </summary>
    ''' <param name="CODFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Valmir]	23/10/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function VerificaFornecedorMex(ByVal CODFRN As Decimal) As wsAcoesComerciais.DatasetFornecedorImportado
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.VerificaFornecedorMex(CODFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0109059
    ''' Descrição da entidade:CADASTRO DESTINO DESCONTO POR BONIFICACAO PEDIDO COMPRA
    ''' </summary>
    ''' <param name="TIPDSNDSCBNF">TIPO DESTINO / DESCONTO BONIFICADO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterEmpenho(ByVal TIPDSNDSCBNF As Decimal) As wsAcoesComerciais.DatasetEmpenho
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterEmpenho(TIPDSNDSCBNF)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0109059
    ''' Descrição da entidade:CADASTRO DESTINO DESCONTO POR BONIFICACAO PEDIDO COMPRA
    ''' </summary>
    ''' <param name="TIPDSNDSCBNF">TIPO DESTINO / DESCONTO BONIFICADO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterEmpenhos(ByVal CODCCP As String, _
                                         ByVal CODCENCST As String, _
                                         ByVal CODCNTCTBGLM As String, _
                                         ByVal CODFLUAPVACOCMC As Decimal, _
                                         ByVal DESDSNDSCBNF As String) As wsAcoesComerciais.DatasetEmpenho

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterEmpenhos(CODCCP, CODCENCST, CODCNTCTBGLM, CODFLUAPVACOCMC, DESDSNDSCBNF, -1)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CODCCP"></param>
    ''' <param name="CODCENCST"></param>
    ''' <param name="CODCNTCTBGLM"></param>
    ''' <param name="CODFLUAPVACOCMC"></param>
    ''' <param name="DESDSNDSCBNF"></param>
    ''' <param name="INDTIPDSNRCTCSTMER"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Valmir]	21/10/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterEmpenhos(ByVal CODCCP As String, _
                                         ByVal CODCENCST As String, _
                                         ByVal CODCNTCTBGLM As String, _
                                         ByVal CODFLUAPVACOCMC As Decimal, _
                                         ByVal DESDSNDSCBNF As String, _
                                         ByVal INDTIPDSNRCTCSTMER As Decimal) As wsAcoesComerciais.DatasetEmpenho

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterEmpenhos(CODCCP, CODCENCST, CODCNTCTBGLM, CODFLUAPVACOCMC, DESDSNDSCBNF, INDTIPDSNRCTCSTMER)
    End Function


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0136390
    ''' Descrição da entidade:CADASTRO TIPO OPERACAO DE BAIXA DAS ORDENS DE PAGTO DE FORNECEDORES
    ''' </summary>
    ''' <param name="TIPOPEBXAORDPGTFRN">TIPO DE OPERACAO DE BAIXA DA ORDEM DE PAGTO DE FORNECED.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTipoOperacaoBaixaOP(ByVal TIPOPEBXAORDPGTFRN As Decimal) As wsAcoesComerciais.DatasetTipoOperacaoBaixaOP
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTipoOperacaoBaixaOP(TIPOPEBXAORDPGTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0136390
    ''' Descrição da entidade:CADASTRO TIPO OPERACAO DE BAIXA DAS ORDENS DE PAGTO DE FORNECEDORES
    ''' </summary>
    ''' <param name="CODTIPLMT">CODIGO TIPO LANCAMENTO.</param>
    ''' <param name="CODTIPLMTPNDCOMDVL">CODIGO TIPO LANCAMENTO PARA PENDENCIA COM DEVOLUCAO.</param>
    ''' <param name="CODTIPLMTPNDSEMDVL">CODIGO TIPO LANCAMENTO PARA PENDENCIA SEM DEVOLUCAO.</param>
    ''' <param name="DESTIPOPEBXAORDPGT">DESCRICAO DO TIPO OPERACAO DE BAIXA DA ORDEM DE PAGTO D.</param>
    ''' <param name="INDTIPOPEBXAORDPGT">INDICA TIPO DE OPERACAO DE BAIXA DA ORDEM DE PAGTO.</param>
    ''' <param name="INDTIPOPEQBRORDPGT">INDICADOR DO TIPO DE OPERACAO DE QUEBRA DA ORDEM DE PAG.</param>
    ''' <param name="INDTIPOPETRNORDPGT">INDICA TIPO DE OPERACAO DE TRANSFERENCIA DA ORDEM DE PA.</param>
    ''' <param name="TIPOPEBXAORDPGTFRN">TIPO DE OPERACAO DE BAIXA DA ORDEM DE PAGTO DE FORNECED.</param>
    ''' <param name="TIPORIORDPGTFRN">TIPO DE ORIGEM DA ORDEM DE PAGTO FORNECEDOR.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0136390" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' O parametro INDTIPOPEBXAORDPGT é omitido quando for -1
    ''' Um parametro do tipo número é omitido quando for zero exceto INDTIPOPEBXAORDPGT,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    24/08/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTiposOperacoesBaixaOP(ByVal CODTIPLMT As Decimal, _
                                                      ByVal CODTIPLMTPNDCOMDVL As Decimal, _
                                                      ByVal CODTIPLMTPNDSEMDVL As Decimal, _
                                                      ByVal DESTIPOPEBXAORDPGT As String, _
                                                      ByVal INDTIPOPEBXAORDPGT As Decimal, _
                                                      ByVal INDTIPOPEQBRORDPGT As Decimal, _
                                                      ByVal INDTIPOPETRNORDPGT As Decimal, _
                                                      ByVal TIPOPEBXAORDPGTFRN As Decimal, _
                                                      ByVal TIPORIORDPGTFRN As Decimal) As wsAcoesComerciais.DatasetTipoOperacaoBaixaOP
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTiposOperacoesBaixaOP(CODTIPLMT, CODTIPLMTPNDCOMDVL, CODTIPLMTPNDSEMDVL, DESTIPOPEBXAORDPGT, INDTIPOPEBXAORDPGT, INDTIPOPEQBRORDPGT, INDTIPOPETRNORDPGT, TIPOPEBXAORDPGTFRN, TIPORIORDPGTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0135050
    ''' Descrição da entidade:RELACAO TIPO TRANSF. DE VLRS. DE ACOES COMERCIAIS X FORNECEDOR
    ''' </summary>
    ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
    ''' <param name="CODTIPTRNVLRACOCMC">CODIGO DO TIPO DE TRANSFERENCIA DE VALORES EM ACOES COM.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTipoTransferenciaXFornecedor(ByVal CODFRN As Decimal, _
                                                             ByVal CODTIPTRNVLRACOCMC As Decimal) As wsAcoesComerciais.DatasetTipoTransferenciaXFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTipoTransferenciaXFornecedor(CODFRN, CODTIPTRNVLRACOCMC)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0135050
    ''' Descrição da entidade:RELACAO TIPO TRANSF. DE VLRS. DE ACOES COMERCIAIS X FORNECEDOR
    ''' </summary>
    ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
    ''' <param name="CODTIPTRNVLRACOCMC">CODIGO DO TIPO DE TRANSFERENCIA DE VALORES EM ACOES COM.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTiposTransferenciasXFornecedor(ByVal CODFRN As Decimal, _
                                                               ByVal CODTIPTRNVLRACOCMC As Decimal) As wsAcoesComerciais.DatasetTipoTransferenciaXFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTiposTransferenciasXFornecedor(CODFRN, CODTIPTRNVLRACOCMC)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0135033
    ''' Descrição da entidade:CADASTRO DE TIPO DE TRANSFERENCIA DE VALORES DE ACOES COMERCIAIS
    ''' </summary>
    ''' <param name="CODTIPTRNVLRACOCMC">CODIGO DO TIPO DE TRANSFERENCIA DE VALORES EM ACOES COM.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTipoTransferenciaValoresAcoesComerciais(ByVal CODTIPTRNVLRACOCMC As Decimal) As wsAcoesComerciais.DatasetTipoTransferenciaValoresAcoesComerciais
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTipoTransferenciaValoresAcoesComerciais(CODTIPTRNVLRACOCMC)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0135033
    ''' Descrição da entidade:CADASTRO DE TIPO DE TRANSFERENCIA DE VALORES DE ACOES COMERCIAIS
    ''' </summary>
    ''' <param name="CODTIPTRNVLRACOCMC">CODIGO DO TIPO DE TRANSFERENCIA DE VALORES EM ACOES COM.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTiposTransferenciasValoresAcoesComerciais(ByVal CODTIPTRNVLRACOCMC As Decimal, _
                                                                          ByVal DESTIPTRNVLRACOCMC As String, _
                                                                          ByVal TIPDSNDSCBNF As Decimal) As wsAcoesComerciais.DatasetTipoTransferenciaValoresAcoesComerciais
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTiposTransferenciasValoresAcoesComerciais(CODTIPTRNVLRACOCMC, DESTIPTRNVLRACOCMC, TIPDSNDSCBNF)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade HSTAVLCTTFRNCLI
    ''' Descrição da entidade:HISTORICO AVALIAÇÃO CONTRATO FORNECIMENTO POR CLIENTE SMART
    ''' </summary>
    ''' <param name="CODCLI">CODIGO CLIENTE.</param>
    ''' <param name="CODEDEABGMIX">CODIGO DA ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <param name="CODFXAAVL">CODIGO DA FAIXA DE AVALIACAO.</param>
    ''' <param name="DATAPUPODCTTFRN">DATA APURACAO PERIODO CONTRATO FORNECIMENTO.</param>
    ''' <param name="DATREFAPU">DATA DE REFERENCIA DA APURACAO.</param>
    ''' <param name="NUMCSLCTTFRN">NUMERO DA CLAUSULA DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMCTTFRN">NUMERO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMCTTFRNAPUPOD">NUMERO DO CONTRATO DE FORNECIMENTO APURADO NO PERIODO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterHistoricoAvalicaoContratoPorClienteSmart(ByVal CODCLI As Decimal, _
                                                                         ByVal CODEDEABGMIX As Decimal, _
                                                                         ByVal CODFXAAVL As Decimal, _
                                                                         ByVal DATAPUPODCTTFRN As Date, _
                                                                         ByVal DATREFAPU As Date, _
                                                                         ByVal NUMCSLCTTFRN As Decimal, _
                                                                         ByVal NUMCTTFRN As Decimal, _
                                                                         ByVal NUMCTTFRNAPUPOD As Decimal) As wsAcoesComerciais.DatasetHistoricoAvalicaoContratoPorClienteSmart
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterHistoricoAvalicaoContratoPorClienteSmart(CODCLI, CODEDEABGMIX, CODFXAAVL, DATAPUPODCTTFRN, DATREFAPU, NUMCSLCTTFRN, NUMCTTFRN, NUMCTTFRNAPUPOD)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0125003
    ''' Descrição da entidade:TIPO BASE CALCULO
    ''' </summary>
    ''' <param name="TIPBSECAL">TIPO DE BASE DE CALCULO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTipoBaseCalculo(ByVal TIPBSECAL As Decimal) As wsAcoesComerciais.DatasetTipoBaseCalculo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTipoBaseCalculo(TIPBSECAL)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0125003
    ''' Descrição da entidade:TIPO BASE CALCULO
    ''' </summary>
    ''' <param name="TIPBSECAL">TIPO DE BASE DE CALCULO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTiposBaseCalculo(ByVal DESBSECAL As String) As wsAcoesComerciais.DatasetTipoBaseCalculo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTiposBaseCalculo(DESBSECAL)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0125011
    ''' Descrição da entidade:CADASTRO TIPO ABRANGENCIA DO MIX
    ''' </summary>
    ''' <param name="TIPEDEABGMIX">TIPO DE ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTipoAbrangenciaMix(ByVal TIPEDEABGMIX As Decimal) As wsAcoesComerciais.DatasetTipoAbrangenciaMix
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTipoAbrangenciaMix(TIPEDEABGMIX)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0125011
    ''' Descrição da entidade:CADASTRO TIPO ABRANGENCIA DO MIX
    ''' </summary>
    ''' <param name="TIPEDEABGMIX">TIPO DE ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTiposAbrangenciaMix(ByVal DESEDEABGMIX As String) As wsAcoesComerciais.DatasetTipoAbrangenciaMix
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTiposAbrangenciaMix(DESEDEABGMIX)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0124988
    ''' Descrição da entidade:RELACAO CONTRADO DE FORNECIMENTO COM PERIODO
    ''' </summary>
    ''' <param name="DATINIPOD">DATA DE INICIO DO PERIODO.</param>
    ''' <param name="NUMCSLCTTFRN">NUMERO DA CLAUSULA DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMCTTFRN">NUMERO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMREFPOD">NUMERO DE REFERENCIA DO PERIODO.</param>
    ''' <param name="TIPPODCTTFRN">TIPO DE PERIODO CONTRATO DE FORNECIMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterContratoXPeriodo(ByVal DATINIPOD As Date, _
                                                 ByVal NUMCSLCTTFRN As Decimal, _
                                                 ByVal NUMCTTFRN As Decimal, _
                                                 ByVal NUMREFPOD As Decimal, _
                                                 ByVal TIPPODCTTFRN As Decimal) As wsAcoesComerciais.DatasetContratoXPeriodo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterContratoXPeriodo(DATINIPOD, NUMCSLCTTFRN, NUMCTTFRN, NUMREFPOD, TIPPODCTTFRN)
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0124988
    ''' Descrição da entidade:RELACAO CONTRADO DE FORNECIMENTO COM PERIODO
    ''' </summary>
    ''' <param name="DATINIPOD">DATA DE INICIO DO PERIODO.</param>
    ''' <param name="NUMCSLCTTFRN">NUMERO DA CLAUSULA DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMCTTFRN">NUMERO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMREFPOD">NUMERO DE REFERENCIA DO PERIODO.</param>
    ''' <param name="TIPPODCTTFRN">TIPO DE PERIODO CONTRATO DE FORNECIMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterContratosXPeriodos(ByVal NUMCSLCTTFRN As Decimal, _
                                                   ByVal NUMCTTFRN As Decimal, _
                                                   ByVal NUMREFPOD As Decimal, _
                                                   ByVal TIPPODCTTFRN As Decimal) As wsAcoesComerciais.DatasetContratoXPeriodo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterContratosXPeriodos(NUMCSLCTTFRN, NUMCTTFRN, NUMREFPOD, TIPPODCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0133243
    ''' Descrição da entidade:MOVIMENTO DIARIO BONIFICACOES EMITIR
    ''' </summary>
    ''' <param name="CODCPR">CODIGO COMPRADOR.</param>
    ''' <param name="CODEDEABGMIX">CODIGO DA ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
    ''' <param name="DATREFAPU">DATA DE REFERENCIA DA APURACAO.</param>
    ''' <param name="NUMCSLCTTFRN">NUMERO DA CLAUSULA DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMCTTFRN">NUMERO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMREFPOD">NUMERO DE REFERENCIA DO PERIODO.</param>
    ''' <param name="TIPEDEABGMIX">TIPO DE ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <param name="TIPPODCTTFRN">TIPO DE PERIODO CONTRATO DE FORNECIMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterBonificacaoEmitir(ByVal CODCPR As Decimal, _
                                                  ByVal CODEDEABGMIX As Decimal, _
                                                  ByVal CODFRN As Decimal, _
                                                  ByVal DATREFAPU As Date, _
                                                  ByVal NUMCSLCTTFRN As Decimal, _
                                                  ByVal NUMCTTFRN As Decimal, _
                                                  ByVal NUMREFPOD As Decimal, _
                                                  ByVal TIPEDEABGMIX As Decimal, _
                                                  ByVal TIPPODCTTFRN As Decimal) As wsAcoesComerciais.DatasetBonificacaoEmitir
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterBonificacaoEmitir(CODCPR, CODEDEABGMIX, CODFRN, DATREFAPU, NUMCSLCTTFRN, NUMCTTFRN, NUMREFPOD, TIPEDEABGMIX, TIPPODCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0133243
    ''' Descrição da entidade:MOVIMENTO DIARIO BONIFICACOES EMITIR
    ''' </summary>
    ''' <param name="CODCPR">CODIGO COMPRADOR.</param>
    ''' <param name="CODEDEABGMIX">CODIGO DA ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
    ''' <param name="DATREFAPU">DATA DE REFERENCIA DA APURACAO.</param>
    ''' <param name="NUMCSLCTTFRN">NUMERO DA CLAUSULA DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMCTTFRN">NUMERO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMREFPOD">NUMERO DE REFERENCIA DO PERIODO.</param>
    ''' <param name="TIPEDEABGMIX">TIPO DE ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <param name="TIPPODCTTFRN">TIPO DE PERIODO CONTRATO DE FORNECIMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterBonificacoesEmitir(ByVal CODCPR As Decimal, _
                                                   ByVal CODEDEABGMIX As Decimal, _
                                                   ByVal CODFRN As Decimal, _
                                                   ByVal NUMCSLCTTFRN As Decimal, _
                                                   ByVal NUMCTTFRN As Decimal, _
                                                   ByVal NUMREFPOD As Decimal, _
                                                   ByVal TIPEDEABGMIX As Decimal, _
                                                   ByVal TIPPODCTTFRN As Decimal) As wsAcoesComerciais.DatasetBonificacaoEmitir
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterBonificacoesEmitir(CODCPR, CODEDEABGMIX, CODFRN, NUMCSLCTTFRN, NUMCTTFRN, NUMREFPOD, TIPEDEABGMIX, TIPPODCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0135092
    ''' Descrição da entidade:RELACAO TIPO TRANSF. DE VLRS. DE ACOES COMERCIAIS X USUARIO
    ''' </summary>
    ''' <param name="CODTIPTRNVLRACOCMC">CODIGO DO TIPO DE TRANSFERENCIA DE VALORES EM ACOES COM.</param>
    ''' <param name="NOMACSUSRSIS">NOME ACESSO USUARIO SISTEMA.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    24/08/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTipoTransferenciaXUsuario(ByVal CODTIPTRNVLRACOCMC As Decimal, _
                                                          ByVal NOMACSUSRSIS As String) As wsAcoesComerciais.DatasetTipoTransferenciaXUsuario
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTipoTransferenciaXUsuario(CODTIPTRNVLRACOCMC, NOMACSUSRSIS)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0135092
    ''' Descrição da entidade:RELACAO TIPO TRANSF. DE VLRS. DE ACOES COMERCIAIS X USUARIO
    ''' </summary>
    ''' <param name="CODTIPTRNVLRACOCMC">CODIGO DO TIPO DE TRANSFERENCIA DE VALORES EM ACOES COM.</param>
    ''' <param name="NOMACSUSRSIS">NOME ACESSO USUARIO SISTEMA.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0135092" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    24/08/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTiposTransferenciasXUsuario(ByVal CODTIPTRNVLRACOCMC As Decimal, _
                                                            ByVal NOMACSUSRSIS As String) As wsAcoesComerciais.DatasetTipoTransferenciaXUsuario
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTiposTransferenciasXUsuario(CODTIPTRNVLRACOCMC, NOMACSUSRSIS)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''  Retorna uma lista de Filiais de expedição filtrando pelo codigo da empresa
    ''' </summary>
    ''' <param name="CODEMP">Codigo da Empresa</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	4/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterFiliaisExpedicao(ByVal CODEMP As Integer) As wsAcoesComerciais.dataSetFilial
        Dim webService As wsAcoesComerciais.AcoesComerciais
        webService = New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterFiliaisExpedicao(CODEMP)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''  Retorna uma lista de Centro de Custos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Bruno Viso]	07/06/2013	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterCentroCusto(ByVal codCentroCusto As String, ByVal desCentroCusto As String) As wsAcoesComerciais.DatasetAcordo
        Dim webService As wsAcoesComerciais.AcoesComerciais
        webService = New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterCentroCusto(codCentroCusto, desCentroCusto)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem Usuários Sistema Negociação Compras do Web Service
    ''' </summary>
    ''' <param name="codigoComprador">Código do Comprador.</param>
    ''' <param name="codigoFuncionario">Código do Funcionário.</param>
    ''' <param name="tipoUsuarioSistema">Tipo do Usuário do Sistema.</param>
    ''' <returns>DataSet com os dados retornados</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Darley Caetano Melo]	12/07/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterUsuariosoCompra(ByVal codigoComprador As Integer, _
                                                ByVal codigoFuncionario As Integer, _
                                                ByVal tipoUsuarioSistema As String) As wsAcoesComerciais.dataSetUsuarioCompra

        Dim webServiceNegociacaoCompra As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webServiceNegociacaoCompra)
        webServiceNegociacaoCompra.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webServiceNegociacaoCompra.ObterUsuariosNegociacaoCompra(codigoComprador, _
                                                                        codigoFuncionario, _
                                                                        tipoUsuarioSistema)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem o usuário logado no sistema
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	8/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterUsuarioLogadoSistema() As wsUsuario.DataSetUsuario
        Dim webServiceUsuario As wsUsuario.Usuario
        Dim dataSetDescompactado As DataSet
        Dim codigoUsuarioLogado As Decimal
        Dim ticketData As SecurityCache.TicketData
        ticketData = SecurityCache.ObterTicketDoSite()

        webServiceUsuario = New wsUsuario.Usuario
        AssinadorWebServices.AssinarWebService(webServiceUsuario)
        webServiceUsuario.Credentials = System.Net.CredentialCache.DefaultCredentials

        dataSetDescompactado = webServiceUsuario.ObterUsuario(ticketData.CodigoUsuario)

        Return CType(dataSetDescompactado, wsUsuario.DataSetUsuario)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	29/11/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterFuncionarioLogadoSistema() As Decimal

        If Controller.ModoTeste Then
            Return Controller.UsuarioCompraTeste
        Else
            Dim dsUsuario As wsUsuario.DataSetUsuario
            dsUsuario = ObterUsuarioLogadoSistema()
            If dsUsuario.Usuario.Rows.Count = 0 Then
                Return 0
            End If
            If dsUsuario.Usuario(0).IsCODFNCNull Then
                Return 0
            End If
            Return dsUsuario.Usuario(0).CODFNC
        End If
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	21/12/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Shared Function UsuarioCompraTeste() As Integer
        Dim result As Integer
        If Not (System.Configuration.ConfigurationSettings.AppSettings("Martins.Web.UI.AcoesComerciais.UsuarioCompraTeste") Is Nothing) Then
            result = CType(System.Configuration.ConfigurationSettings.AppSettings("Martins.Web.UI.AcoesComerciais.UsuarioCompraTeste"), Integer)
        End If
        Return result
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	21/12/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Shared Function UsuarioTeste() As Integer
        Dim result As Integer
        If Not (System.Configuration.ConfigurationSettings.AppSettings("Martins.Web.UI.AcoesComerciais.UsuarioTeste") Is Nothing) Then
            result = CType(System.Configuration.ConfigurationSettings.AppSettings("Martins.Web.UI.AcoesComerciais.UsuarioTeste"), Integer)
        End If
        Return result
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem usuário do sistema comprar a partir do usuário que logou no sistema
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	8/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterUsuariosCompraLogadoSistema() As wsAcoesComerciais.dataSetUsuarioCompra
        Dim webServiceNegociacaoCompra As New wsAcoesComerciais.AcoesComerciais
        Dim result As wsAcoesComerciais.dataSetUsuarioCompra

        AssinadorWebServices.AssinarWebService(webServiceNegociacaoCompra)
        webServiceNegociacaoCompra.Credentials = System.Net.CredentialCache.DefaultCredentials


        If Controller.ModoTeste Then
            result = webServiceNegociacaoCompra.ObterUsuariosNegociacaoCompra(0, UsuarioCompraTeste(), String.Empty)
        Else
            result = webServiceNegociacaoCompra.ObterUsuariosNegociacaoCompra(0, Integer.Parse(ObterUsuarioLogadoSistema().Usuario(0).CODFNC.ToString), String.Empty)
        End If

        Return result
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0118104
    ''' Descrição da entidade:RELACAO TIPO PEDIDO  COMPRA POR TIPO DESTINO DESCONTO BONIFICADO
    ''' </summary>
    ''' <param name="TIPDSNDSCBNF">TIPO DESTINO / DESCONTO BONIFICADO.</param>
    ''' <param name="TIPPEDCMP">TIPO PEDIDO DE COMPRAS.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    11/09/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTipoPedidoCompraXEmpenho(ByVal TIPDSNDSCBNF As Decimal, _
                                                         ByVal TIPPEDCMP As Decimal) As wsAcoesComerciais.DatasetTipoPedidoCompraXEmpenho
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTipoPedidoCompraXEmpenho(TIPDSNDSCBNF, TIPPEDCMP)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0118104
    ''' Descrição da entidade:RELACAO TIPO PEDIDO  COMPRA POR TIPO DESTINO DESCONTO BONIFICADO
    ''' </summary>
    ''' <param name="TIPDSNDSCBNF">TIPO DESTINO / DESCONTO BONIFICADO.</param>
    ''' <param name="TIPPEDCMP">TIPO PEDIDO DE COMPRAS.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0118104" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    11/09/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTiposPedidoCompraXEmpenho(ByVal TIPDSNDSCBNF As Decimal, _
                                                          ByVal TIPPEDCMP As Decimal) As wsAcoesComerciais.DatasetTipoPedidoCompraXEmpenho
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTiposPedidoCompraXEmpenho(TIPDSNDSCBNF, TIPPEDCMP)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NumCttFrn"></param>
    ''' <param name="NumCslCttFrn"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	02/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterDestinoVerbaPrometida(ByVal NumCttFrn As Integer, ByVal NumCslCttFrn As Integer) As DataTable
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterDestinoVerbaPrometida(NumCttFrn, NumCslCttFrn).Tables(0)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NumCttFrn"></param>
    ''' <param name="NumCslCttFrn"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	02/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterDataPrevisaoRecebimento(ByVal NumCttFrn As Integer, _
                                                                ByVal NumCslCttFrn As Integer, _
                                                                ByVal TipPodCttFrn As Integer, _
                                                                ByVal NumRefPod As Integer) As DataTable
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterDataPrevisaoRecebimento(NumCttFrn, NumCslCttFrn, TipPodCttFrn, NumRefPod).Tables(0)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Seleciona as duplicatas de um fornecedor CLJ072
    ''' </summary>
    ''' <param name="CodFrn"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio]	4/10/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterDuplicatasDisponiveis(ByVal CodFrn As Integer) As wsAcoesComerciais.DatasetDuplicatasDisponiveis
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterDuplicatasDisponiveis(CodFrn)
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0100094
    ''' Descrição da entidade:VALOR MOEDA
    ''' </summary>
    ''' <param name="MESREF">ANO E MES DE REFERENCIA NO FORMATO AAAAMM.</param>
    ''' <param name="TIPMOE">TIPO INDICE ECONOMICO/FINANCEIRO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterValorMoeda(ByVal MESREF As Decimal, _
                                           ByVal TIPMOE As Decimal) As wsAcoesComerciais.DatasetValorMoeda
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterValorMoeda(MESREF, TIPMOE)
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0101724
    ''' Descrição da entidade:CADASTRO MOEDA
    ''' </summary>
    ''' <param name="TIPMOE">TIPO INDICE ECONOMICO/FINANCEIRO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterMoeda(ByVal TIPMOE As Decimal) As wsAcoesComerciais.DatasetMoeda
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterMoeda(TIPMOE)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0101724
    ''' Descrição da entidade:CADASTRO MOEDA
    ''' </summary>
    ''' <param name="DESTIPMOE">DESCRICAO DO TIPO DE INDICE ECONOMICO/FINANCEIRO.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0101724" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterMoedas(ByVal DESTIPMOE As String) As wsAcoesComerciais.DatasetMoeda
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterMoedas(DESTIPMOE)
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0138407
    ''' Descrição da entidade:CADASTRO TIPO FORMA DE PAGAMENTO DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="TIPFRMPGTCTTFRN">TIPO FORMA DE PAGTO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTipoFormaPagamento(ByVal TIPFRMPGTCTTFRN As Decimal) As wsAcoesComerciais.DatasetTipoFormaPagamento
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTipoFormaPagamento(TIPFRMPGTCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0138407
    ''' Descrição da entidade:CADASTRO TIPO FORMA DE PAGAMENTO DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="DESTIPFRMPGTCTTFRN">DESCRICAO DO TIPO DA FORMA DE PAGAMENTO DO CONTRATO DE.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0138407" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTiposFormaPagamento(ByVal DESTIPFRMPGTCTTFRN As String) As wsAcoesComerciais.DatasetTipoFormaPagamento
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTiposFormaPagamento(DESTIPFRMPGTCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0138415
    ''' Descrição da entidade:CADASTRO TIPO ENCARGO FINANCEIRO DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="TIPENCFINCTTFRN">TIPO DO ENCARGO FINANCEIRO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTipoEncargoFinanceiro(ByVal TIPENCFINCTTFRN As Decimal) As wsAcoesComerciais.DatasetTipoEncargoFinanceiro
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTipoEncargoFinanceiro(TIPENCFINCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0138415
    ''' Descrição da entidade:CADASTRO TIPO ENCARGO FINANCEIRO DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="DESTIPENCFINCTTFRN">DESCRICAO DO TIPO DE ENCARGO FINANCEIRO DO CONTRATO DE.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0138415" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTiposEncargoFinanceiro(ByVal DESTIPENCFINCTTFRN As String) As wsAcoesComerciais.DatasetTipoEncargoFinanceiro
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTiposEncargoFinanceiro(DESTIPENCFINCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0138423
    ''' Descrição da entidade:CADASTRO TIPO ABRANGENCIA TABELA DE PRECO DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="TIPABGTABPCOCTTFRN">TIPO DA ABRANGENCIA DA TABELA DE PRECO DO CONTRATO DE F.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTipoAbrangencia(ByVal TIPABGTABPCOCTTFRN As Decimal) As wsAcoesComerciais.DatasetTipoAbrangencia
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTipoAbrangencia(TIPABGTABPCOCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0138423
    ''' Descrição da entidade:CADASTRO TIPO ABRANGENCIA TABELA DE PRECO DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="DESTIPABGTABPCOCTT">DESCRICAO TIPO DE ABRANGENCIA DA TABELA DE PRECO CTT DE.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0138423" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTiposAbrangencia(ByVal DESTIPABGTABPCOCTT As String) As wsAcoesComerciais.DatasetTipoAbrangencia
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTiposAbrangencia(DESTIPABGTABPCOCTT)
    End Function


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0138431
    ''' Descrição da entidade:CADASTRO TIPO PAGAMENTO NOTA FISCAL DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="TIPPGTNOTFSCCTTFRN">TIPO DE PAGAMENTO DA NOTA FISCAL DO CONTRATO DE FORNECI.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTipoPagamento(ByVal TIPPGTNOTFSCCTTFRN As Decimal) As wsAcoesComerciais.DatasetTipoPagamento
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTipoPagamento(TIPPGTNOTFSCCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0138431
    ''' Descrição da entidade:CADASTRO TIPO PAGAMENTO NOTA FISCAL DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="DESTIPPGTNOTFSCCTT">DESCRICAO DO TIPO DE PAGAMENTO DA NOTA FISCAL DO CTT DE.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0138431" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTiposPagamento(ByVal DESTIPPGTNOTFSCCTT As String) As wsAcoesComerciais.DatasetTipoPagamento
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTiposPagamento(DESTIPPGTNOTFSCCTT)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0138440
    ''' Descrição da entidade:CADASTRO TIPO DE FORNECEDOR DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="TIPFRNCTTFRN">TIPO DO FORNECEDOR DO CONTRATO DE FORNECIMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTipoFornecedor(ByVal TIPFRNCTTFRN As Decimal) As wsAcoesComerciais.DatasetTipoFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTipoFornecedor(TIPFRNCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0138440
    ''' Descrição da entidade:CADASTRO TIPO DE FORNECEDOR DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="DESTIPFRNCTTFRN">DESCRICAO DO TIPO DE FORNECEDOR DO CONTRATO DE FORNECIM.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0138440" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTiposFornecedor(ByVal DESTIPFRNCTTFRN As String) As wsAcoesComerciais.DatasetTipoFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTiposFornecedor(DESTIPFRNCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0138458
    ''' Descrição da entidade:CADASTRO TIPO UNIDADE DE PAGAMENTO DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="TIPUNDPGTCTTFRN">TIPO DA UNIDADE PAGAMENTO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTipoUnidadePagamento(ByVal TIPUNDPGTCTTFRN As Decimal) As wsAcoesComerciais.DatasetTipoUnidadePagamento
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTipoUnidadePagamento(TIPUNDPGTCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0138458
    ''' Descrição da entidade:CADASTRO TIPO UNIDADE DE PAGAMENTO DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="DESTIPUNDPGTCTTFRN">DESCRICAO DO TIPO DE UNIDADE DE PAGTO DO CONTRATO DE FO.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0138458" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTiposUnidadePagamento(ByVal DESTIPUNDPGTCTTFRN As String) As wsAcoesComerciais.DatasetTipoUnidadePagamento
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTiposUnidadePagamento(DESTIPUNDPGTCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0138466
    ''' Descrição da entidade:CADASTRO TIPO DE SERVICO DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="TIPSVCCTTFRN">TIPO DE SERVICO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTipoServico(ByVal TIPSVCCTTFRN As Decimal) As wsAcoesComerciais.DatasetTipoServico
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTipoServico(TIPSVCCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0138466
    ''' Descrição da entidade:CADASTRO TIPO DE SERVICO DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="DESTIPSVCCTTFRN">DESCRICAO DO TIPO DE SERVICO DO CONTRATO DE FORNECIMENT.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0138466" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTiposServico(ByVal DESTIPSVCCTTFRN As String) As wsAcoesComerciais.DatasetTipoServico
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTiposServico(DESTIPSVCCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0138474
    ''' Descrição da entidade:CADASTRO TIPO DE RELACIONAMENTO DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="TIPRLCCTTFRN">TIPO DE RELACIONAMENTO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTipoRelacionamento(ByVal TIPRLCCTTFRN As Decimal) As wsAcoesComerciais.DatasetTipoRelacionamento
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTipoRelacionamento(TIPRLCCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0138474
    ''' Descrição da entidade:CADASTRO TIPO DE RELACIONAMENTO DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="DESTIPRLCCTTFRN">DESCRICAO DO TIPO DE RELACIONAMENTO DO CONTRATO DE FORN.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0138474" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTiposRelacionamento(ByVal DESTIPRLCCTTFRN As String) As wsAcoesComerciais.DatasetTipoRelacionamento
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTiposRelacionamento(DESTIPRLCCTTFRN)
    End Function

    Public Shared Function ObterParametroNegociacaoFornecedor(ByVal numeroParametro As Integer) As wsAcoesComerciais.dataSetParametro
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterParametroNegociacaoFornecedor(numeroParametro)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem Selecao Atualizacao Operacao BaixaOperacao Fornecedor
    ''' Procedure: PRCDKSelAtlOpeBxaOpeFrn
    ''' </summary>
    ''' <param name="TipOpe"></param>
    ''' <param name="CodFrn"></param>
    ''' <param name="StaOpe"></param>
    ''' <param name="DatRcbOrdPgt"></param>
    ''' <param name="TipOriOrdPgtFrn"></param>
    ''' <param name="TipOpeBxaOrdPgtFrn"></param>
    ''' <param name="NumOrdPgtFrn"></param>
    ''' <param name="CodBco"></param>
    ''' <param name="CodAge"></param>
    ''' <param name="DatRcbOrdPgtAlt"></param>
    ''' <param name="NomAcsUsrBxaOrdPgtAlt"></param>
    ''' <param name="QbrVlrOrdPgt"></param>
    ''' <param name="QtdQbrAlt"></param>
    ''' <param name="DatRcbOrdPgtIni"></param>
    ''' <param name="DatRcbOrdPgtFim"></param>
    ''' <param name="DatUltPmsOrdIni"></param>
    ''' <param name="DatUltPmsOrdFim"></param>
    ''' <param name="TipIdtEmpAscAcoCmc"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	24/10/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterSelecaoAtualizacaoOperacaoBaixaOperacaoFornecedor(ByVal TipOpe As Integer, _
                                                                                  ByVal CodFrn As Integer, _
                                                                                  ByVal StaOpe As Integer, _
                                                                                  ByVal DatRcbOrdPgt As Date, _
                                                                                  ByVal TipOriOrdPgtFrn As Integer, _
                                                                                  ByVal TipOpeBxaOrdPgtFrn As Integer, _
                                                                                  ByVal NumOrdPgtFrn As Integer, _
                                                                                  ByVal CodBco As Integer, _
                                                                                  ByVal CodAge As Integer, _
                                                                                  ByVal DatRcbOrdPgtAlt As Date, _
                                                                                  ByVal NomAcsUsrBxaOrdPgtAlt As String, _
                                                                                  ByVal QbrVlrOrdPgt As String, _
                                                                                  ByVal QtdQbrAlt As Integer, _
                                                                                  ByVal DatRcbOrdPgtIni As Date, _
                                                                                  ByVal DatRcbOrdPgtFim As Date, _
                                                                                  ByVal DatUltPmsOrdIni As Date, _
                                                                                  ByVal DatUltPmsOrdFim As Date, _
                                                                                  ByVal TipIdtEmpAscAcoCmc As Integer) As wsAcoesComerciais.DatasetOperacaoBaixaOperacaoFornecedor


        Try
            Dim webService As New wsAcoesComerciais.AcoesComerciais
            AssinadorWebServices.AssinarWebService(webService)
            webService.Credentials = System.Net.CredentialCache.DefaultCredentials

            Return webService.ObterSelecaoAtualizacaoOperacaoBaixaOperacaoFornecedor(TipOpe, _
                                                                                     CodFrn, _
                                                                                     StaOpe, _
                                                                                     DatRcbOrdPgt, _
                                                                                     TipOriOrdPgtFrn, _
                                                                                     TipOpeBxaOrdPgtFrn, _
                                                                                     NumOrdPgtFrn, _
                                                                                     CodBco, _
                                                                                     CodAge, _
                                                                                     DatRcbOrdPgtAlt, _
                                                                                     NomAcsUsrBxaOrdPgtAlt, _
                                                                                     QbrVlrOrdPgt, _
                                                                                     QtdQbrAlt, _
                                                                                     DatRcbOrdPgtIni, _
                                                                                     DatRcbOrdPgtFim, _
                                                                                     DatUltPmsOrdIni, _
                                                                                     DatUltPmsOrdFim, _
                                                                                     TipIdtEmpAscAcoCmc)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Atualizacao Operacao BaixaOperacao Fornecedor
    ''' Procedure: PRCDKSelAtlOpeBxaOpeFrn
    ''' </summary>
    ''' <param name="TipOpe"></param>
    ''' <param name="CodFrn"></param>
    ''' <param name="StaOpe"></param>
    ''' <param name="DatRcbOrdPgt"></param>
    ''' <param name="TipOriOrdPgtFrn"></param>
    ''' <param name="TipOpeBxaOrdPgtFrn"></param>
    ''' <param name="NumOrdPgtFrn"></param>
    ''' <param name="CodBco"></param>
    ''' <param name="CodAge"></param>
    ''' <param name="DatRcbOrdPgtAlt"></param>
    ''' <param name="NomAcsUsrBxaOrdPgtAlt"></param>
    ''' <param name="QbrVlrOrdPgt"></param>
    ''' <param name="QtdQbrAlt"></param>
    ''' <param name="DatRcbOrdPgtIni"></param>
    ''' <param name="DatRcbOrdPgtFim"></param>
    ''' <param name="DatUltPmsOrdIni"></param>
    ''' <param name="DatUltPmsOrdFim"></param>
    ''' <param name="TipIdtEmpAscAcoCmc"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	24/10/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarOperacaoBaixaOperacaoFornecedor(ByVal TipOpe As Integer, _
                                                               ByVal CodFrn As Integer, _
                                                               ByVal StaOpe As Integer, _
                                                               ByVal DatRcbOrdPgt As Date, _
                                                               ByVal TipOriOrdPgtFrn As Integer, _
                                                               ByVal TipOpeBxaOrdPgtFrn As Integer, _
                                                               ByVal NumOrdPgtFrn As Integer, _
                                                               ByVal CodBco As Integer, _
                                                               ByVal CodAge As Integer, _
                                                               ByVal DatRcbOrdPgtAlt As Date, _
                                                               ByVal NomAcsUsrBxaOrdPgtAlt As String, _
                                                               ByVal QbrVlrOrdPgt As String, _
                                                               ByVal QtdQbrAlt As Integer, _
                                                               ByVal DatRcbOrdPgtIni As Date, _
                                                               ByVal DatRcbOrdPgtFim As Date, _
                                                               ByVal DatUltPmsOrdIni As Date, _
                                                               ByVal DatUltPmsOrdFim As Date, _
                                                               ByVal TipIdtEmpAscAcoCmc As Integer)


        Try
            Dim webService As New wsAcoesComerciais.AcoesComerciais
            AssinadorWebServices.AssinarWebService(webService)
            webService.Credentials = System.Net.CredentialCache.DefaultCredentials

            webService.AtualizarOperacaoBaixaOperacaoFornecedor(TipOpe, _
                                                                CodFrn, _
                                                                StaOpe, _
                                                                DatRcbOrdPgt, _
                                                                TipOriOrdPgtFrn, _
                                                                TipOpeBxaOrdPgtFrn, _
                                                                NumOrdPgtFrn, _
                                                                CodBco, _
                                                                CodAge, _
                                                                DatRcbOrdPgtAlt, _
                                                                NomAcsUsrBxaOrdPgtAlt, _
                                                                QbrVlrOrdPgt, _
                                                                QtdQbrAlt, _
                                                                DatRcbOrdPgtIni, _
                                                                DatRcbOrdPgtFim, _
                                                                DatUltPmsOrdIni, _
                                                                DatUltPmsOrdFim, _
                                                                TipIdtEmpAscAcoCmc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Este método retorna os dados para tabela T0124961 com base em atributos que não fazem parte da chave primária.
    ''' Descrição da entidade:RELACAO CLAUSULA COM CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="data">Contexto do banco de dados</param>
    ''' <param name="DATDSTCSL">DATA DESATIVACAO CLAUSULA.</param>
    ''' <param name="DATDSTCSLInicial">DATA DESATIVACAO CLAUSULA INICIAL.</param>
    ''' <param name="DATDSTCSLFinal">DATA DESATIVACAO CLAUSULA FINAL.</param>
    ''' <param name="NUMCSLCTTFRN">NUMERO DA CLAUSULA DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMCTTFRN">NUMERO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <returns>String com o comando sql.</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Elifázio Bernardes]    31/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    '<MartinsSecurity(5, -1)> _
    Public Shared Function ObterContratoXClausulaContrato(ByVal DATDSTCSL As Date, _
                                                          ByVal DATDSTCSLInicial As Date, _
                                                          ByVal DATDSTCSLFinal As Date, _
                                                          ByVal NUMCSLCTTFRN As Decimal, _
                                                          ByVal NUMCTTFRN As Decimal) As wsAcoesComerciais.DatasetContrato
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials

        Return webService.ObterContratoXClausulaContrato(DATDSTCSL, DATDSTCSLInicial, DATDSTCSLFinal, NUMCSLCTTFRN, NUMCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0153589
    ''' Descrição da entidade:RELACAO CONTRATO FORNECIMENTO X RELACAO ABATIMENTO PERDA
    ''' </summary>
    ''' <param name="CODEDEABGMIX">CODIGO DA ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <param name="DATREFAPU">DATA DE REFERENCIA DA APURACAO.</param>
    ''' <param name="NUMCSLCTTFRN">NUMERO DA CLAUSULA DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMCTTFRN">NUMERO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMREFPOD">NUMERO DE REFERENCIA DO PERIODO.</param>
    ''' <param name="NUMSEQRLCCTTPMS">NUMERO DE SEQUENCIA DE RELACIONAMENTO ENTRE CONTRATO E.</param>
    ''' <param name="TIPEDEABGMIX">TIPO DE ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <param name="TIPPODCTTFRN">TIPO DE PERIODO CONTRATO DE FORNECIMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    15/11/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterContratoFornecimentoXAbatimentoPerda(ByVal CODEDEABGMIX As Decimal, _
                                                                     ByVal DATREFAPU As Date, _
                                                                     ByVal NUMCSLCTTFRN As Decimal, _
                                                                     ByVal NUMCTTFRN As Decimal, _
                                                                     ByVal NUMREFPOD As Decimal, _
                                                                     ByVal NUMSEQRLCCTTPMS As Decimal, _
                                                                     ByVal TIPEDEABGMIX As Decimal, _
                                                                     ByVal TIPPODCTTFRN As Decimal) As wsAcoesComerciais.DatasetContratoFornecimentoXAbatimentoPerda
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterContratoFornecimentoXAbatimentoPerda(CODEDEABGMIX, DATREFAPU, NUMCSLCTTFRN, NUMCTTFRN, NUMREFPOD, NUMSEQRLCCTTPMS, TIPEDEABGMIX, TIPPODCTTFRN)
    End Function


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Este método retorna o SQL para tabela T0153589 com base nos parametros.
    ''' Descrição da entidade:RELACAO CONTRATO FORNECIMENTO X RELACAO ABATIMENTO PERDA
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Elifázio]    30/11/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterContratoFornecimentosXAbatimentosPerda(ByVal CODFRN As Decimal, ByVal TIPCNCPDACTTFRN As String) As wsAcoesComerciais.DatasetContratoFornecimentoXAbatimentoPerda
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterContratoFornecimentosXAbatimentosPerda(CODFRN, TIPCNCPDACTTFRN)
    End Function


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0153031
    ''' Descrição da entidade:RELACAO PROMESSA X MENSAGEM
    ''' </summary>
    ''' <param name="CODEMP">CODIGO EMPRESA.</param>
    ''' <param name="CODFILEMP">CODIGO DA FILIAL DA EMPRESA.</param>
    ''' <param name="CODPMS">CODIGO PROMESSA.</param>
    ''' <param name="DATNGCPMS">DATA DA NEGOCIACAO DA PROMESSA.</param>
    ''' <param name="NUMSEQOBSPMS">NUMERO SEQUENCIA OBSERVACAO PROMESSA.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    15/11/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterAcordoXMensagem(ByVal CODEMP As Decimal, _
                                                ByVal CODFILEMP As Decimal, _
                                                ByVal CODPMS As Decimal, _
                                                ByVal DATNGCPMS As Date, _
                                                ByVal NUMSEQOBSPMS As Decimal) As wsAcoesComerciais.DatasetAcordoXMensagem
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterAcordoXMensagem(CODEMP, CODFILEMP, CODPMS, DATNGCPMS, NUMSEQOBSPMS)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0152663
    ''' Descrição da entidade:RELACAO DE BONIFICACAO E DUPLICATA A EMITIR
    ''' </summary>
    ''' <param name="CODEDEABGMIX">CODIGO DA ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
    ''' <param name="DATREFAPU">DATA DE REFERENCIA DA APURACAO.</param>
    ''' <param name="NUMCSLCTTFRN">NUMERO DA CLAUSULA DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMCTTFRN">NUMERO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMREFPOD">NUMERO DE REFERENCIA DO PERIODO.</param>
    ''' <param name="TIPEDEABGMIX">TIPO DE ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <param name="TIPPODCTTFRN">TIPO DE PERIODO CONTRATO DE FORNECIMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    15/11/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterBonificacaoDuplicataEmitir(ByVal CODEDEABGMIX As Decimal, _
                                                           ByVal CODFRN As Decimal, _
                                                           ByVal DATREFAPU As Date, _
                                                           ByVal NUMCSLCTTFRN As Decimal, _
                                                           ByVal NUMCTTFRN As Decimal, _
                                                           ByVal NUMREFPOD As Decimal, _
                                                           ByVal TIPEDEABGMIX As Decimal, _
                                                           ByVal TIPPODCTTFRN As Decimal) As wsAcoesComerciais.DatasetBonificacaoDuplicataEmitir
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterBonificacaoDuplicataEmitir(CODEDEABGMIX, CODFRN, DATREFAPU, NUMCSLCTTFRN, NUMCTTFRN, NUMREFPOD, TIPEDEABGMIX, TIPPODCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0152647
    ''' Descrição da entidade:RELACAO PERDAS EMITIDAS
    ''' </summary>
    ''' <param name="CODEDEABGMIX">CODIGO DA ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <param name="DATREFAPU">DATA DE REFERENCIA DA APURACAO.</param>
    ''' <param name="NUMCSLCTTFRN">NUMERO DA CLAUSULA DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMCTTFRN">NUMERO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMREFPOD">NUMERO DE REFERENCIA DO PERIODO.</param>
    ''' <param name="NUMSEQRLCCTTPMS">NUMERO DE SEQUENCIA DE RELACIONAMENTO ENTRE CONTRATO E.</param>
    ''' <param name="TIPEDEABGMIX">TIPO DE ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <param name="TIPPODCTTFRN">TIPO DE PERIODO CONTRATO DE FORNECIMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    15/11/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterPerdaEmitida(ByVal CODEDEABGMIX As Decimal, _
                                             ByVal DATREFAPU As Date, _
                                             ByVal NUMCSLCTTFRN As Decimal, _
                                             ByVal NUMCTTFRN As Decimal, _
                                             ByVal NUMREFPOD As Decimal, _
                                             ByVal NUMSEQRLCCTTPMS As Decimal, _
                                             ByVal TIPEDEABGMIX As Decimal, _
                                             ByVal TIPPODCTTFRN As Decimal) As wsAcoesComerciais.DatasetPerdaEmitida
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterPerdaEmitida(CODEDEABGMIX, DATREFAPU, NUMCSLCTTFRN, NUMCTTFRN, NUMREFPOD, NUMSEQRLCCTTPMS, TIPEDEABGMIX, TIPPODCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Este método retorna o SQL para tabela T0152647.
    ''' Selecione os abatimento referente as perdas do processo Aco. Frn
    ''' Descrição da entidade:RELACAO PERDAS EMITIDAS
    ''' </summary>
    ''' <returns>String com o comando sql.</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Elifázio Bernardes]    04/11/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    '<MartinsSecurity(5, -1)> _
    Public Shared Function ObterAbatimentoPerdasAcoFrn(ByVal CODFRN As Decimal, ByVal isDATDSTRLCPDACTTFRNNull As Boolean) As wsAcoesComerciais.DataSetAbatimentoPerdasAcoFrn
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        ObterAbatimentoPerdasAcoFrn = webService.ObterAbatimentoPerdasAcoFrn(CODFRN, isDATDSTRLCPDACTTFRNNull)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obter valores para validar a Trimestralidade e a Anualidade
    ''' </summary>
    ''' <param name="NUMCTTFRN">Contrato</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Elifázio Bernardes]    17/11/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTrimestralidadeAnualidadePermitida(ByVal NUMCTTFRN As Integer) As wsAcoesComerciais.DatasetTrimestralidadeAnualidade
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        ObterTrimestralidadeAnualidadePermitida = webService.ObterTrimestralidadeAnualidadePermitida(NUMCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obter próximo numero de OP
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	17/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterProximoNumeroOP() As Decimal
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.ObterProximoNumeroOP()
    End Function


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Retorna verdadeiro se o fornecedor pertence a celula atendida pelo usuário
    ''' </summary>
    ''' <param name="CODFRN"></param>
    ''' <param name="NOMACSUSRSIS"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	29/12/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function FornecedorPertenceCelulaAtendidaUsuario(ByVal CODFRN As Decimal, _
                                                                   ByVal NOMACSUSRSIS As String) As Boolean
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.FornecedorPertenceCelulaAtendidaUsuario(CODFRN, _
                                                           NOMACSUSRSIS)
    End Function

    Public Shared Function VerificaParcial(ByVal CODPMS As Decimal, ByVal numNota As Decimal) As Decimal
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.VerificaParcial(CODPMS, numNota)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obter as categorias existentes para o fornecedor
    ''' </summary>
    ''' <param name="CODEMP"></param>
    ''' <param name="CODFRNPCPMER"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	5/2/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterCategoriasDoFornecedor(ByVal CODEMP As Decimal, _
                                                       ByVal CODFRNPCPMER As Decimal) As wsAcoesComerciais.DatasetContratoXAbrangenciaMix
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterCategoriasDoFornecedor(CODEMP, CODFRNPCPMER)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CODEMP"></param>
    ''' <param name="CODFRNPCPMER"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	5/2/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterMercadoriasDoFornecedor(ByVal CODEMP As Decimal, _
                                                        ByVal CODFRNPCPMER As Decimal) As wsAcoesComerciais.DatasetContratoXAbrangenciaMix
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterMercadoriasDoFornecedor(CODEMP, CODFRNPCPMER)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Este método retorna dados da entidade T0123884 com base na sua chave primária.
    ''' Descrição da entidade:PARAMETROS FORNECEDOR PARA MMM
    ''' </summary>
    ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0123884" preenchida.</returns>
    ''' <remarks>
    ''' Sempre que um código inválido for informado, uma exception será retornada.
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    15/02/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    '<MartinsSecurity(5, -1)> _
    Public Shared Function ObterParametroFornecedorMmm(ByVal CODFRN As Decimal) As wsAcoesComerciais.DatasetParametroFornecedorMmm
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterParametroFornecedorMmm(CODFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Este método retorna dados da entidade T0123884 com base em outros atributos.
    ''' Descrição da entidade:PARAMETROS FORNECEDOR PARA MMM
    ''' </summary>
    ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
    ''' <param name="FLGFRNAJTCMC">FLAG QUE INIDICA SE O FORNECEDOR TEM CONTRATO.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0123884" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    15/02/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    '<MartinsSecurity(5, -1)> _
    Public Shared Function ObterParametrosFornecedorMmm(ByVal CODFRN As Decimal, _
                                                        ByVal FLGFRNAJTCMC As String) As wsAcoesComerciais.DatasetParametroFornecedorMmm

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterParametrosFornecedorMmm(CODFRN, FLGFRNAJTCMC)

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem os filiados do contrato
    ''' </summary>
    ''' <param name="NUMCTTFRN"></param>
    ''' <param name="NUMCSLCTTFRN"></param>
    ''' <param name="TIPEDEABGMIX"></param>
    ''' <param name="CODEDEABGMIX"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	21/2/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    '<MartinsSecurity(5, -1)> _
    Public Shared Function ObterFiliadosContrato(ByVal NUMCTTFRN As Decimal, _
                                                 ByVal NUMCSLCTTFRN As Decimal, _
                                                 ByVal TIPEDEABGMIX As Decimal, _
                                                 ByVal CODEDEABGMIX As Decimal) As wsAcoesComerciais.DatasetContrato

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterFiliadosContrato(NUMCTTFRN, NUMCSLCTTFRN, TIPEDEABGMIX, CODEDEABGMIX)

    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade RLCABGCTTFIL
    ''' Descrição da entidade:RELACAO ABRANGENCIA X CONTRATO  X FILIADO
    ''' </summary>
    ''' <param name="CODCLI">CODIGO CLIENTE.</param>
    ''' <param name="CODEDEABGMIX">CODIGO DA ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <param name="NUMCSLCTTFRN">NUMERO DA CLAUSULA DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMCTTFRN">NUMERO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="TIPEDEABGMIX">TIPO DE ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    23/02/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterAbrangenciaXContratoXFiliado(ByVal CODCLI As Decimal, _
                                                             ByVal CODEDEABGMIX As Decimal, _
                                                             ByVal NUMCSLCTTFRN As Decimal, _
                                                             ByVal NUMCTTFRN As Decimal, _
                                                             ByVal TIPEDEABGMIX As Decimal) As wsAcoesComerciais.DatasetContrato
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterAbrangenciaXContratoXFiliado(CODCLI, CODEDEABGMIX, NUMCSLCTTFRN, NUMCTTFRN, TIPEDEABGMIX)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade RLCABGCTTFIL
    ''' Descrição da entidade:RELACAO ABRANGENCIA X CONTRATO  X FILIADO
    ''' </summary>
    ''' <param name="CODCLI">CODIGO CLIENTE.</param>
    ''' <param name="CODEDEABGMIX">CODIGO DA ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <param name="NUMCSLCTTFRN">NUMERO DA CLAUSULA DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMCTTFRN">NUMERO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="TIPEDEABGMIX">TIPO DE ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <returns>Retorna um DataSet com a tabela "RLCABGCTTFIL" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    23/02/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterAbrangenciasXContratoXFiliado(ByVal CODCLI As Decimal, _
                                                              ByVal CODEDEABGMIX As Decimal, _
                                                              ByVal NUMCSLCTTFRN As Decimal, _
                                                              ByVal NUMCTTFRN As Decimal, _
                                                              ByVal TIPEDEABGMIX As Decimal) As wsAcoesComerciais.DatasetContrato
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterAbrangenciasXContratoXFiliado(CODCLI, CODEDEABGMIX, NUMCSLCTTFRN, NUMCTTFRN, TIPEDEABGMIX)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0144920
    ''' Descrição da entidade:RELACAO USUARIO X CELULA
    ''' </summary>
    ''' <param name="CODDIVCMP">CODIGO DA DIVISAO DE COMPRAS.</param>
    ''' <param name="NOMACSUSRSIS">NOME ACESSO USUARIO SISTEMA.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    26/02/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterUsuarioXCelula(ByVal CODDIVCMP As Decimal, _
                                               ByVal NOMACSUSRSIS As String) As wsAcoesComerciais.DatasetUsuarioXCelula
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterUsuarioXCelula(CODDIVCMP, NOMACSUSRSIS)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0144920
    ''' Descrição da entidade:RELACAO USUARIO X CELULA
    ''' </summary>
    ''' <param name="CODDIVCMP">CODIGO DA DIVISAO DE COMPRAS.</param>
    ''' <param name="NOMACSUSRSIS">NOME ACESSO USUARIO SISTEMA.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0144920" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    26/02/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterUsuariosXCelula(ByVal CODDIVCMP As Decimal, _
                                                ByVal NOMACSUSRSIS As String) As wsAcoesComerciais.DatasetUsuarioXCelula
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterUsuariosXCelula(CODDIVCMP, NOMACSUSRSIS)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade CADTRNVBAFRN
    ''' Descrição da entidade:CADASTRO DE TRANSFERENCIA VERBAS FORNECEDOR
    ''' </summary>
    ''' <param name="NUMFLUAPV">NUMERO FLUXO DE APROVACAO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    27/11/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTransferenciaVerbaFornecedor(ByVal NUMFLUAPV As Decimal) As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterTransferenciaVerbaFornecedor(NUMFLUAPV)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade CADTRNVBAFRN
    ''' Descrição da entidade:CADASTRO DE TRANSFERENCIA VERBAS FORNECEDOR
    ''' </summary>
    ''' <param name="CODFNC">CODIGO FUNCIONARIO.</param>
    ''' <param name="DESJSTTRNVBA">DESCRICAO JUSTIFICATIVA DA TRANSFERENCIA DE VERBA.</param>
    ''' <param name="NUMFLUAPV">NUMERO FLUXO DE APROVACAO.</param>
    ''' <param name="TIPALCVBAFRN">TIPO DE ALOCACAO DA VERBA DO FORNECEDOR.</param>
    ''' <param name="TIPDSNDSCBNFDSNTRN">TIPO EMPENHO DESTINO TRANSFERENCIA VERBA.</param>
    ''' <param name="TIPSTAFLUAPV">TIPO STATUS FLUXO APROVACAO.</param>
    ''' <returns>Retorna um DataSet com a tabela "CADTRNVBAFRN" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    27/11/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTransferenciasVerbaFornecedor(ByVal CODFNC As Decimal, _
                                                              ByVal DESJSTTRNVBA As String, _
                                                              ByVal NUMFLUAPV As Decimal, _
                                                              ByVal TIPALCVBAFRN As Decimal, _
                                                              ByVal TIPDSNDSCBNFDSNTRN As Decimal, _
                                                              ByVal TIPSTAFLUAPV As String) As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterTransferenciasVerbaFornecedor(CODFNC, DESJSTTRNVBA, NUMFLUAPV, TIPALCVBAFRN, TIPDSNDSCBNFDSNTRN, TIPSTAFLUAPV)
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade CADTRNVBAFRN
    ''' Descrição da entidade:CADASTRO DE TRANSFERENCIA VERBAS FORNECEDOR
    ''' </summary>
    ''' <param name="CODFNC">CODIGO FUNCIONARIO.</param>
    ''' <param name="TIPSTAFLUAPV">TIPO STATUS FLUXO APROVACAO.</param>
    ''' <returns>Retorna um DataSet com a tabela "CADTRNVBAFRN" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    27/11/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTransferenciasVerbaFornecedorJOIN(ByVal NUMFLUAPV As Decimal, _
                                                                  ByVal CODFNC As Decimal, _
                                                                  ByVal TIPSTAFLUAPV As String) As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterTransferenciasVerbaFornecedorJOIN(NUMFLUAPV, CODFNC, TIPSTAFLUAPV)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NUMFLUAPV"></param>
    ''' <param name="CODFNC"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	22/12/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterMinhasAprovavoesEmTransferenciaVerbasFornecedor(ByVal NUMFLUAPV As Decimal, _
                                                                                ByVal CODFNC As Decimal) As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterMinhasAprovavoesEmTransferenciaVerbasFornecedor(NUMFLUAPV, CODFNC)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade RLCTRNVBAFRN
    ''' Descrição da entidade:RELACAO DE TRANSFERENCIA VERBAS FORNECEDOR
    ''' </summary>
    ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
    ''' <param name="NUMFLUAPV">NUMERO FLUXO DE APROVACAO.</param>
    ''' <param name="TIPALCVBAFRN">TIPO DE ALOCACAO DA VERBA DO FORNECEDOR.</param>
    ''' <param name="TIPDSNDSCBNFORITRN">TIPO EMPENHO ORIGEM TRANSFERENCIA VERBA.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    27/11/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelacaoTransferenciaVerbaFornecedor(ByVal CODFRN As Decimal, _
                                                                    ByVal NUMFLUAPV As Decimal, _
                                                                    ByVal TIPALCVBAFRN As Decimal, _
                                                                    ByVal TIPDSNDSCBNFORITRN As Decimal) As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterRelacaoTransferenciaVerbaFornecedor(CODFRN, NUMFLUAPV, TIPALCVBAFRN, TIPDSNDSCBNFORITRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NUMFLUAPV"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	5/12/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelacaoTransferenciaVerbaFornecedorJoinT0153541JoinT0100426JoinT0113625JoinT0118570JoinT0109059(ByVal NUMFLUAPV As Decimal) As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterRelacaoTransferenciaVerbaFornecedorJoinT0153541JoinT0100426JoinT0113625JoinT0118570JoinT0109059(NUMFLUAPV)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade RLCTRNVBAFRN
    ''' Descrição da entidade:RELACAO DE TRANSFERENCIA VERBAS FORNECEDOR
    ''' </summary>
    ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
    ''' <param name="NUMFLUAPV">NUMERO FLUXO DE APROVACAO.</param>
    ''' <param name="TIPALCVBAFRN">TIPO DE ALOCACAO DA VERBA DO FORNECEDOR.</param>
    ''' <param name="TIPDSNDSCBNFORITRN">TIPO EMPENHO ORIGEM TRANSFERENCIA VERBA.</param>
    ''' <returns>Retorna um DataSet com a tabela "RLCTRNVBAFRN" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    27/11/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelacoesTransferenciaVerbaFornecedor(ByVal CODFRN As Decimal, _
                                                                     ByVal NUMFLUAPV As Decimal, _
                                                                     ByVal TIPALCVBAFRN As Decimal, _
                                                                     ByVal TIPDSNDSCBNFORITRN As Decimal) As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterRelacoesTransferenciaVerbaFornecedor(CODFRN, NUMFLUAPV, TIPALCVBAFRN, TIPDSNDSCBNFORITRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CODFNC"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	29/11/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterFuncionario(ByVal CODFNC As Decimal) As wsAcoesComerciais.DatasetFuncionario
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterFuncionario(CODFNC)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0161591
    ''' Descrição da entidade:FLUXO DE APROVAÇÃO
    ''' </summary>
    ''' <param name="CODSISINF">CODIGO DO SISTEMA DE INFORMACAO.</param>
    ''' <param name="NUMFLUAPV">.</param>
    ''' <param name="NUMSEQFLUAPV">.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    06/12/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterFluxoAprovacao(ByVal CODSISINF As Decimal, _
                                               ByVal NUMFLUAPV As Decimal, _
                                               ByVal NUMSEQFLUAPV As Decimal) As wsAcoesComerciais.DatasetFluxoAprovacao
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterFluxoAprovacao(CODSISINF, NUMFLUAPV, NUMSEQFLUAPV)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0161591
    ''' Descrição da entidade:FLUXO DE APROVAÇÃO
    ''' </summary>
    ''' <param name="CODEDEAPV">CODIGO ENTIDADE APROVOU.</param>
    ''' <param name="CODEDEARZ">CODIGO DA ENTIDADE AUTORIZADA.</param>
    ''' <param name="CODSISINF">CODIGO DO SISTEMA DE INFORMACAO.</param>
    ''' <param name="DATHRAAPVFLU">DATA E HORA DE APROVACAO DO FLUXO.</param>
    ''' <param name="DATHRAFLUAPV">DATA E HORA DO FLUXO DE APROVACAO.</param>
    ''' <param name="NUMFLUAPV">.</param>
    ''' <param name="NUMSEQFLUAPV">.</param>
    ''' <param name="NUMSEQFLUAPVPEDOPN">.</param>
    ''' <param name="NUMSEQNIVAPV">.</param>
    ''' <param name="TIPSTAFLUAPV">.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0161591" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    06/12/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterFluxosAprovacao(ByVal CODEDEAPV As Decimal, _
                                                ByVal CODEDEARZ As Decimal, _
                                                ByVal CODSISINF As Decimal, _
                                                ByVal DATHRAAPVFLU As String, _
                                                ByVal DATHRAFLUAPV As String, _
                                                ByVal NUMFLUAPV As Decimal, _
                                                ByVal NUMSEQFLUAPV As Decimal, _
                                                ByVal NUMSEQFLUAPVPEDOPN As Decimal, _
                                                ByVal NUMSEQNIVAPV As Decimal, _
                                                ByVal TIPSTAFLUAPV As String) As wsAcoesComerciais.DatasetFluxoAprovacao
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterFluxosAprovacao(CODEDEAPV, CODEDEARZ, CODSISINF, DATHRAAPVFLU, DATHRAFLUAPV, NUMFLUAPV, NUMSEQFLUAPV, NUMSEQFLUAPVPEDOPN, NUMSEQNIVAPV, TIPSTAFLUAPV)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0154038
    ''' Descrição da entidade:FLUXO CANCELAMENTO ACORDO
    ''' </summary>
    ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
    ''' <param name="NUMPEDCNCACOCMC">NUMERO PEDIDO CANCELAMENTO ACORDO COMERCIAL.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    23/04/2008  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterFluxoCancelamentoAcordoPorChave(ByVal CODFRN As Decimal, _
                                                                ByVal NUMPEDCNCACOCMC As Decimal) As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo
        Dim webService As New wsFluxoDeCancelamentoDeAcordos.FluxoDeCancelamentoDeAcordos
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterFluxoCancelamentoAcordoPorChave(CODFRN, NUMPEDCNCACOCMC)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0154038
    ''' Descrição da entidade:FLUXO CANCELAMENTO ACORDO
    ''' </summary>
    ''' <param name="CODFRN">CODIGO FORNECEDOR.</param>
    ''' <param name="CODSTAAPV">CODIGO DO STATUS DO FLUXO.</param>
    ''' <param name="NUMPEDCNCACOCMC">NUMERO PEDIDO CANCELAMENTO ACORDO COMERCIAL.</param>
    ''' <param name="NUMREQCNCACOCMC">NUMERO REQUISICAO CANCELAMENTO ACORDO COMERCIAL.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0154038" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    23/04/2008  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterFluxoCancelamentoAcordoPorAtributos(ByVal CODFRN As Decimal, _
                                                                    ByVal CODSTAAPV As Decimal, _
                                                                    ByVal NUMPEDCNCACOCMC As Decimal, _
                                                                    ByVal NUMREQCNCACOCMC As Decimal) As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo
        Dim webService As New wsFluxoDeCancelamentoDeAcordos.FluxoDeCancelamentoDeAcordos
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterFluxoCancelamentoAcordoPorAtributos(CODFRN, CODSTAAPV, NUMPEDCNCACOCMC, NUMREQCNCACOCMC)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0154021
    ''' Descrição da entidade:ACORDO A CANCELAR EM FLUXO CANCELAMENTO ACORDO
    ''' </summary>
    ''' <param name="CODEMP">CODIGO EMPRESA.</param>
    ''' <param name="CODFILEMP">CODIGO DA FILIAL DA EMPRESA.</param>
    ''' <param name="CODPMS">CODIGO PROMESSA.</param>
    ''' <param name="DATNGCPMS">DATA DA NEGOCIACAO DA PROMESSA.</param>
    ''' <param name="DATPRVRCBPMS">DATA DE PREVISAO DE RECEBIMENTO DA PROMESSA.</param>
    ''' <param name="NUMPEDCNCACOCMC">NUMERO PEDIDO CANCELAMENTO ACORDO COMERCIAL.</param>
    ''' <param name="TIPDSNDSCBNF">TIPO DESTINO / DESCONTO BONIFICADO.</param>
    ''' <param name="TIPFRMDSCBNF">TIPO FORMA DESCONTO BONIFICACAO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    23/04/2008  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterAcordoACancelarEmFluxoCancelamentoAcordoPorChave(ByVal CODEMP As Decimal, _
                                                                                 ByVal CODFILEMP As Decimal, _
                                                                                 ByVal CODPMS As Decimal, _
                                                                                 ByVal DATNGCPMS As Date, _
                                                                                 ByVal DATPRVRCBPMS As Date, _
                                                                                 ByVal NUMPEDCNCACOCMC As Decimal, _
                                                                                 ByVal TIPDSNDSCBNF As Decimal, _
                                                                                 ByVal TIPFRMDSCBNF As Decimal) As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo
        Dim webService As New wsFluxoDeCancelamentoDeAcordos.FluxoDeCancelamentoDeAcordos
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterAcordoACancelarEmFluxoCancelamentoAcordoPorChave(CODEMP, CODFILEMP, CODPMS, DATNGCPMS, DATPRVRCBPMS, NUMPEDCNCACOCMC, TIPDSNDSCBNF, TIPFRMDSCBNF)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0154021
    ''' Descrição da entidade:ACORDO A CANCELAR EM FLUXO CANCELAMENTO ACORDO
    ''' </summary>
    ''' <param name="CODEMP">CODIGO EMPRESA.</param>
    ''' <param name="CODFILEMP">CODIGO DA FILIAL DA EMPRESA.</param>
    ''' <param name="CODPMS">CODIGO PROMESSA.</param>
    ''' <param name="DATNGCPMS">DATA DA NEGOCIACAO DA PROMESSA.</param>
    ''' <param name="DATPRVRCBPMS">DATA DE PREVISAO DE RECEBIMENTO DA PROMESSA.</param>
    ''' <param name="NUMPEDCNCACOCMC">NUMERO PEDIDO CANCELAMENTO ACORDO COMERCIAL.</param>
    ''' <param name="TIPDSNDSCBNF">TIPO DESTINO / DESCONTO BONIFICADO.</param>
    ''' <param name="TIPFRMDSCBNF">TIPO FORMA DESCONTO BONIFICACAO.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0154021" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    23/04/2008  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterAcordoACancelarEmFluxoCancelamentoAcordoPorAtributos(ByVal CODEMP As Decimal, _
                                                                                     ByVal CODFILEMP As Decimal, _
                                                                                     ByVal CODPMS As Decimal, _
                                                                                     ByVal DATNGCPMS As Date, _
                                                                                     ByVal DATPRVRCBPMS As Date, _
                                                                                     ByVal NUMPEDCNCACOCMC As Decimal, _
                                                                                     ByVal TIPDSNDSCBNF As Decimal, _
                                                                                     ByVal TIPFRMDSCBNF As Decimal) As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo
        Dim webService As New wsFluxoDeCancelamentoDeAcordos.FluxoDeCancelamentoDeAcordos
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterAcordoACancelarEmFluxoCancelamentoAcordoPorAtributos(CODEMP, CODFILEMP, CODPMS, DATNGCPMS, DATPRVRCBPMS, NUMPEDCNCACOCMC, TIPDSNDSCBNF, TIPFRMDSCBNF)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NUMFLUAPV"></param>
    ''' <param name="CODFNC"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	4/24/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterMinhasAprovavoesEmFluxoDeCancelamentoDeAcordos(ByVal NUMPEDCNCACOCMC As Decimal, _
                                                                                ByVal CODFNC As Decimal) As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo
        Dim webService As New wsFluxoDeCancelamentoDeAcordos.FluxoDeCancelamentoDeAcordos
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterMinhasAprovavoesEmFluxoDeCancelamentoDeAcordos(NUMPEDCNCACOCMC, CODFNC)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	5/7/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterNomeUsuarioLogadoSistema() As String
        Dim T0104596Row As wsAcoesComerciais.DatasetContaUsuario.T0104596Row
        Dim result As String = String.Empty

        T0104596Row = Controller.ObterContaUsuario

        If Not T0104596Row Is Nothing Then
            result = T0104596Row.NOMUSRRCF.Trim
        End If

        Return result
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	5/7/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterContaUsuario() As wsAcoesComerciais.DatasetContaUsuario.T0104596Row
        Dim dsUsuario As wsUsuario.DataSetUsuario
        Dim dsContaUsuario As wsAcoesComerciais.DatasetContaUsuario
        Dim result As wsAcoesComerciais.DatasetContaUsuario.T0104596Row
        Dim CodFnc As Decimal

        dsUsuario = ObterUsuarioLogadoSistema()

        If dsUsuario Is Nothing Then
            Return Nothing
        End If

        If dsUsuario.Usuario.Rows.Count = 0 Then
            Return Nothing
        End If

        If dsUsuario.Usuario(0).IsNull("CODFNC") Then
            Return Nothing
        End If

        dsContaUsuario = ObterContaUsuario(dsUsuario.Usuario(0).CODFNC)
        If dsContaUsuario Is Nothing Then
            Return Nothing
        End If
        If dsContaUsuario.T0104596.Rows.Count = 0 Then
            Return Nothing
        End If

        Return dsContaUsuario.T0104596(0)

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CODFNC"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	5/7/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterContaUsuario(ByVal CODFNC As Decimal) As wsAcoesComerciais.DatasetContaUsuario
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterContaUsuario(CODFNC)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CODFRN"></param>
    ''' <param name="CODSTAAPV"></param>
    ''' <param name="NUMPEDCNCACOCMC"></param>
    ''' <param name="NUMREQCNCACOCMC"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	14/5/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterFluxoCancelamentoAcordoPesquisa(ByVal CODFRN As Decimal, _
                                                                ByVal CODSTAAPV As Decimal, _
                                                                ByVal NUMPEDCNCACOCMC As Decimal, _
                                                                ByVal NUMREQCNCACOCMC As Decimal) As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo
        Dim webService As New wsFluxoDeCancelamentoDeAcordos.FluxoDeCancelamentoDeAcordos
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterFluxoCancelamentoAcordoPesquisa(CODFRN, CODSTAAPV, NUMPEDCNCACOCMC, NUMREQCNCACOCMC)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem Celulas por atributo
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Rodrigo Gama]	09/09/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterCelulaPorAtributo(ByVal CODDIVCMP As Decimal, _
                                                  ByVal DESDIVCMP As String) As wsRecuperacaoEPrevencaoPerdas.DatasetCelula
        Dim webService As New wsRecuperacaoEPrevencaoPerdas.RecuperacaoEPrevencaoPerdas
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterCelulaPorAtributo(CODDIVCMP, DESDIVCMP)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="TIPGRPMKTFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	2/4/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTipoGrupoMarketingPorChave(ByVal TIPGRPMKTFRN As Decimal) As wsAcoesComerciais.DatasetTipoGrupoMarketing
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterTipoGrupoMarketingPorChave(TIPGRPMKTFRN)
    End Function

    Public Shared Function ObterTipoGrupoMarketingPorChavePesquisa(ByVal TIPGRPMKTFRN As Decimal) As wsAcoesComerciais.DatasetTipoGrupoMarketing
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterTipoGrupoMarketingPorChavePesquisa(TIPGRPMKTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="TIPGRPMKTFRN"></param>
    ''' <param name="DESGRPMKTFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	2/4/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTipoGrupoMarketingPorAtributo(ByVal TIPGRPMKTFRN As Decimal, ByVal DESGRPMKTFRN As String) As wsAcoesComerciais.DatasetTipoGrupoMarketing
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterTipoGrupoMarketingPorAtributo(TIPGRPMKTFRN, DESGRPMKTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CODEMP"></param>
    ''' <param name="CODFILEMP"></param>
    ''' <param name="CODGRPFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	6/4/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterGrupoEconomicoPorChave(ByVal CODEMP As Decimal, ByVal CODFILEMP As Decimal, ByVal CODGRPFRN As Decimal) As wsAcoesComerciais.DatasetTipoGrupoMarketing
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterGrupoEconomicoPorChave(CODEMP, CODFILEMP, CODGRPFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CODEMP"></param>
    ''' <param name="CODFILEMP"></param>
    ''' <param name="CODGRPFRN"></param>
    ''' <param name="NOMGRPFRN"></param>
    ''' <param name="TIPFRN"></param>
    ''' <param name="DATCADGRPFRN"></param>
    ''' <param name="DATDSTGRPFRN"></param>
    ''' <param name="CODCGMECOFRN"></param>
    ''' <param name="TIPCLFFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	6/4/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterGrupoEconomicoPorAtributo(ByVal CODEMP As Decimal, _
                                                       ByVal CODFILEMP As Decimal, _
                                                       ByVal CODGRPFRN As Decimal, _
                                                       ByVal NOMGRPFRN As String, _
                                                       ByVal TIPFRN As String, _
                                                       ByVal DATCADGRPFRN As Date, _
                                                       ByVal DATDSTGRPFRN As Date, _
                                                       ByVal CODCGMECOFRN As Decimal, _
                                                       ByVal TIPCLFFRN As Decimal) As wsAcoesComerciais.DatasetTipoGrupoMarketing
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterGrupoEconomicoPorAtributo(CODEMP, CODFILEMP, CODGRPFRN, NOMGRPFRN, TIPFRN, DATCADGRPFRN, DATDSTGRPFRN, CODCGMECOFRN, TIPCLFFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="TIPGRPMKTFRN"></param>
    ''' <param name="CODGRPFRN"></param>
    ''' <param name="PERGRPMKTFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	8/4/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelacaoGrupoMarketingPesquisa(ByVal TIPGRPMKTFRN As Decimal, _
                                                           ByVal CODGRPFRN As Decimal, _
                                                           ByVal PERGRPMKTFRN As Decimal) As wsAcoesComerciais.DatasetTipoGrupoMarketing
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterRelacaoGrupoMarketingPesquisa(TIPGRPMKTFRN, CODGRPFRN, PERGRPMKTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CODFRN"></param>
    ''' <param name="NOMFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	9/4/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterFornecedorPorAtributo(ByVal CODFRN As Decimal, ByVal NOMFRN As String) As wsAcoesComerciais.DatasetIncentivo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterFornecedorPorAtributo(CODFRN, NOMFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CODFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	9/4/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterFornecedorPorChave(ByVal CODFRN As Decimal) As wsAcoesComerciais.DatasetIncentivo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterFornecedorPorChave(CODFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CODPRGICT"></param>
    ''' <param name="CODFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	9/4/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelacaoIncentivoFornecedorPesquisa(ByVal CODPRGICT As Decimal, ByVal CODFRN As Decimal) As wsAcoesComerciais.DatasetIncentivo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterRelacaoIncentivoFornecedorPesquisa(CODPRGICT, CODFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CODPRGICT"></param>
    ''' <param name="CODFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	9/4/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelacaoIncentivoFornecedor(ByVal CODPRGICT As Decimal, ByVal CODFRN As Decimal) As wsAcoesComerciais.DatasetIncentivo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterRelacaoIncentivoFornecedor(CODPRGICT, CODFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CODGRPFRN"></param>
    ''' <param name="TIPGRPMKTFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	13/4/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelacaoGrupoMarketingPorChave(ByVal CODGRPFRN As Decimal, ByVal TIPGRPMKTFRN As Decimal) As wsAcoesComerciais.DatasetTipoGrupoMarketing
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterRelacaoGrupoMarketingPorChave(CODGRPFRN, TIPGRPMKTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="TIPGRPMKTFRN"></param>
    ''' <param name="CODGRPFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	13/4/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelacaoGrupoMarketingPorAtributo(ByVal TIPGRPMKTFRN As Decimal, _
                                                                 ByVal CODGRPFRN As Decimal) As wsAcoesComerciais.DatasetTipoGrupoMarketing
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterRelacaoGrupoMarketingPorAtributo(TIPGRPMKTFRN, CODGRPFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IN_CODGRPFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	14/4/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelacaoGrupoMarketingPesquisaFilho(ByVal IN_CODGRPFRN As String) As wsAcoesComerciais.DatasetTipoGrupoMarketing
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterRelacaoGrupoMarketingPesquisaFilho(IN_CODGRPFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CODFRN"></param>
    ''' <param name="NOMFRN"></param>
    ''' <param name="DATDSTMKTEXAARD"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	15/5/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterMarketingExtraAcordoPesquisa(ByVal CODFRN As Decimal, ByVal NOMFRN As String, ByVal DATDSTMKTEXAARD As Decimal) As wsAcoesComerciais.DatasetMarketinExtraAcordo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterMarketingExtraAcordoPesquisa(CODFRN, NOMFRN, DATDSTMKTEXAARD)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	15/5/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterFormaPagamentoMktExtraAcordo() As wsAcoesComerciais.DatasetMarketinExtraAcordo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterFormaPagamentoMktExtraAcordo()
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CODFRN"></param>
    ''' <param name="DATCADMKTEXAARD"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	18/5/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterMarketingExtraAcordoPorChave(ByVal CODFRN As Decimal, ByVal DATCADMKTEXAARD As Date) As wsAcoesComerciais.DatasetMarketinExtraAcordo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterMarketingExtraAcordoPorChave(CODFRN, DATCADMKTEXAARD)
    End Function
    Public Shared Function ObterVerbaCarimboPesquisa(ByVal indStaMcoVbaFrn As Decimal, _
                                                     ByVal fornecedor As Decimal, _
                                                     ByVal empenho As Decimal, _
                                                     ByVal acordo As Decimal) As wsAcoesComerciais.DatasetVerbaCarimbo

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterVerbaCarimboPesquisa(indStaMcoVbaFrn, fornecedor, empenho, acordo)
    End Function
    Public Shared Function ObterComboEmpenho(ByVal tipoChamada As Integer) As wsAcoesComerciais.DatasetEmpenho
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterComboEmpenho(tipoChamada)
    End Function
    Public Shared Function AtualizarCadCarimboVerbaFornec(ByVal dstVerbaCarimbo As wsAcoesComerciais.DatasetVerbaCarimbo) As Boolean
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.AtualizarCadCarimboVerbaFornec(dstVerbaCarimbo)

    End Function
    Public Shared Function ObterVerificarCarimbo(ByVal listCarimbo() As Object) As wsAcoesComerciais.DatasetVerbaCarimbo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterVerificarCarimbo(listCarimbo)
    End Function
    Public Shared Function ObterCadCarimboVerbaFornecByPk(ByVal CODMCOVBAFRN As Decimal) As wsAcoesComerciais.DatasetVerbaCarimbo

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterCadCarimboVerbaFornecByPk(CODMCOVBAFRN)
    End Function


#Region " Metodos com Stored Procedures "

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' CONSULTA RELAÇÃO TIPO DE TRANSFERÊNCIA EMPRENHO E FORNECEDOR
    ''' </summary>
    ''' <param name="vTipOpe">TIPO DA CONSULTA 1,2 OU 3</param>
    ''' <param name="vNomAcsUsrSis"></param>
    ''' <param name="vTipDsnDscBnf"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' 1 -
    ''' 2 - Verifica se existe uma relacao empenho X usuario X tipo transferencia
    ''' </remarks>
    ''' <history>
    ''' 	[ELIFÁZIO]	21/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelacaoTipoTransferenciaEmpenhoFornecedor(ByVal vTipOpe As Integer, _
                                                                          ByVal vNomAcsUsrSis As String, _
                                                                          ByVal vTipDsnDscBnf As Decimal) As wsAcoesComerciais.DatasetRelacaoTipoTransferenciaEmpenhoFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelacaoTipoTransferenciaEmpenhoFornecedor(vTipOpe, vNomAcsUsrSis, vTipDsnDscBnf)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' CONSULTA Valores Disponiveis de um Fornecedor
    ''' </summary>
    ''' <param name="vDatRef"></param>
    ''' <param name="vCodFrn"></param>
    ''' <param name="vTipDsnDscBnf"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[ELIFÁZIO]	21/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterSelecaoValorDisponivelFornecedor(ByVal vDatRef As Date, _
                                                                 ByVal vCodFrn As Decimal, _
                                                                 ByVal vTipDsnDscBnf As Decimal) As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterSelecaoValorDisponivelFornecedor(vDatRef, vCodFrn, vTipDsnDscBnf)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="vDatRef"></param>
    ''' <param name="vCodFrn"></param>
    ''' <param name="vTipDsnDscBnf"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	20/11/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterSaldoDisponivelFornecedor(ByVal DatRef As Date, _
                                                          ByVal CodFrn As Decimal, _
                                                          ByVal TipDsnDscBnf As Decimal) As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterSaldoDisponivelFornecedor(DatRef, CodFrn, TipDsnDscBnf)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="DatRef"></param>
    ''' <param name="CodFrn"></param>
    ''' <param name="TipDsnDscBnf"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	22/2/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterSaldoDisponivelFornecedor(ByVal DatRef As Date, _
                                                          ByVal CodFrn As Decimal, _
                                                          ByVal In_TipDsnDscBnf As String) As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterSaldoDisponivelFornecedor2(DatRef, CodFrn, In_TipDsnDscBnf)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="DatRef"></param>
    ''' <param name="CodFrn"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	11/1/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterSaldoDisponivelFornecedorParaTodosEmpenhos(ByVal DatRef As Date, _
                                                                           ByVal CodFrn As Decimal) As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterSaldoDisponivelFornecedorParaTodosEmpenhos(DatRef, CodFrn)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="DatRef"></param>
    ''' <param name="CodDivCmp"></param>
    ''' <param name="TipDsnDscBnf"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	22/11/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterSaldoDisponivelFornecedorPorCategoria(ByVal DatRef As Date, _
                                                                      ByVal CodDivCmp As Decimal, _
                                                                      ByVal TipDsnDscBnf As Decimal) As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterSaldoDisponivelFornecedorPorCategoria(DatRef, CodDivCmp, TipDsnDscBnf)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="DatRef"></param>
    ''' <param name="CodDivCmp"></param>
    ''' <param name="TipDsnDscBnf"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	22/2/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterSaldoDisponivelFornecedorPorCategoria(ByVal DatRef As Date, _
                                                                      ByVal CodDivCmp As Decimal) As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterSaldoDisponivelFornecedorPorCategoria2(DatRef, CodDivCmp)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="DatRef"></param>
    ''' <param name="codCpr"></param>
    ''' <param name="TipDsnDscBnf"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	22/11/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterSaldoDisponivelFornecedorPorComprador(ByVal DatRef As Date, _
                                                                      ByVal CodCpr As Decimal, _
                                                                      ByVal TipDsnDscBnf As Decimal) As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterSaldoDisponivelFornecedorPorComprador(DatRef, CodCpr, TipDsnDscBnf)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="DatRef"></param>
    ''' <param name="CodCpr"></param>
    ''' <param name="TipDsnDscBnf"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	22/2/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterSaldoDisponivelFornecedorPorComprador(ByVal DatRef As Date, _
                                                                      ByVal CodCpr As Decimal) As wsAcoesComerciais.DatasetSelecaoValorDisponivelFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterSaldoDisponivelFornecedorPorComprador2(DatRef, CodCpr)
    End Function

    '''' -----------------------------------------------------------------------------
    '''' <summary>
    '''' Verificar se o fornecedor pertence à céluda atendida pelo usuário
    '''' </summary>
    '''' <param name="NomUsrSis"></param>
    '''' <param name="CodFrn"></param>
    '''' <returns></returns>
    '''' <remarks>
    '''' </remarks>
    '''' <history>
    '''' 	[ELIFÁZIO]	22/9/2006	Created
    '''' </history>
    '''' -----------------------------------------------------------------------------
    'Public Shared Function VerificarFornecedorPertenceCeludaAtendidaUsuario(ByVal NomUsrSis As String, ByVal CodFrn As Decimal) As Boolean
    '    Dim webService As New wsAcoesComerciais.AcoesComerciais
    '    AssinadorWebServices.AssinarWebService(webService)
    '    webService.Credentials = System.Net.CredentialCache.DefaultCredentials
    '    Return webService.VerificarFornecedorPertenceCeludaAtendidaUsuario(NomUsrSis, CodFrn)
    'End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' CONSULTA Valores Acordos Duplicata Nao Relacionada
    ''' </summary>
    ''' <param name="vOpcao"></param>
    ''' <param name="vCodFrn"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio]	27/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterSelecaoValorAcordoDuplicataNaoRelacionada(ByVal vOpcao As Integer, _
                                                                    ByVal vCodFrn As Integer) As wsAcoesComerciais.DatasetSelecaoValorAcordoDuplicataNaoRelacionada
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterSelecaoValorAcordoDuplicataNaoRelacionada(vOpcao, vCodFrn)
    End Function


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' CONSULTA Valores Promessa Origem Troca Forma Pagamento Acordo
    ''' </summary>
    ''' <param name="vOpcao"></param>
    ''' <param name="vCodFrn"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio]	27/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterValorPromessaOrigemTrocaFormaPagamentoAcordo(ByVal vCodPmsEnt As Integer, _
                                                                     ByVal vDatPgtTit As Date) As wsAcoesComerciais.DatasetObterValorPromessaOrigemTrocaFormaPagamentoAcordo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterValorPromessaOrigemTrocaFormaPagamentoAcordo(vCodPmsEnt, vDatPgtTit)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem Novo Codigo de Promessa
    ''' </summary>
    ''' <param name="vCodEmp"></param>
    ''' <param name="vCodFilEmp"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio]	27/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterProximoCodigoAcordoComercial(ByVal vCodEmp As Integer, _
                                                    ByVal vCodFilEmp As Integer) As Integer
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterProximoCodigoAcordoComercial(vCodEmp, vCodFilEmp)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' CADASTRA A PROMESSA, Manutencao Movimento Acordo Comercial
    ''' </summary>
    ''' <param name="vTipOpe"></param>
    ''' <param name="vCodEmp"></param>
    ''' <param name="vCodFilEmp"></param>
    ''' <param name="vCodPms"></param>
    ''' <param name="vDatNgcPms"></param>
    ''' <param name="vCodSitPms"></param>
    ''' <param name="vNumPedCmp"></param>
    ''' <param name="vCodFrn"></param>
    ''' <param name="vNomAcsUsrSis"></param>
    ''' <param name="vDesMsgUsr"></param>
    ''' <param name="vNomCtoFrn"></param>
    ''' <param name="vNumTlfCtoFrn"></param>
    ''' <param name="vDesCgrCtofrn"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	28/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function GerarManutencaoMovimentoAcordoComercial(ByVal vTipOpe As Integer, _
                                            ByVal vCodEmp As Integer, _
                                            ByVal vCodFilEmp As Integer, _
                                            ByVal vCodPms As Integer, _
                                            ByVal vDatNgcPms As Date, _
                                            ByVal vCodSitPms As Integer, _
                                            ByVal vNumPedCmp As Integer, _
                                            ByVal vCodFrn As Integer, _
                                            ByVal vNomAcsUsrSis As String, _
                                            ByVal vDesMsgUsr As String, _
                                            ByVal vNomCtoFrn As String, _
                                            ByVal vNumTlfCtoFrn As Integer, _
                                            ByVal vDesCgrCtofrn As String) As Boolean
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.GerarManutencaoMovimentoAcordoComercial(vTipOpe, vCodEmp, vCodFilEmp, vCodPms, vDatNgcPms, vCodSitPms, vNumPedCmp, vCodFrn, vNomAcsUsrSis, vDesMsgUsr, vNomCtoFrn, vNumTlfCtoFrn, vDesCgrCtofrn)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' CADASTRA A Manutencao Relacao Acordo Comercial Parcela
    ''' </summary>
    ''' <param name="vTipOpe"></param>
    ''' <param name="vCodEmp"></param>
    ''' <param name="vCodFilEmp"></param>
    ''' <param name="vCodPms"></param>
    ''' <param name="vDatNgcPms"></param>
    ''' <param name="vDatPrvRcbPms"></param>
    ''' <param name="vTipFrmDscBnf"></param>
    ''' <param name="vTipDsnDscBnf"></param>
    ''' <param name="vVlrNgcPms"></param>
    ''' <param name="vVlrEftPms"></param>
    ''' <param name="vNomAcsUsrSis"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	29/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function GerarManutencaoRelacaoAcordoComercialParcela(ByVal vTipOpe As Integer, _
                                                                ByVal vCodEmp As Integer, _
                                                                ByVal vCodFilEmp As Integer, _
                                                                ByVal vCodPms As Integer, _
                                                                ByVal vDatNgcPms As Date, _
                                                                ByVal vDatPrvRcbPms As Date, _
                                                                ByVal vTipFrmDscBnf As Integer, _
                                                                ByVal vTipDsnDscBnf As Integer, _
                                                                ByVal vVlrNgcPms As String, _
                                                                ByVal vVlrEftPms As String, _
                                                                ByVal vNomAcsUsrSis As String) As Boolean

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.GerarManutencaoRelacaoAcordoComercialParcela(vTipOpe, vCodEmp, vCodFilEmp, vCodPms, vDatNgcPms, vDatPrvRcbPms, vTipFrmDscBnf, vTipDsnDscBnf, vVlrNgcPms, vVlrEftPms, vNomAcsUsrSis)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' TROCA MANUAL DE TITULOS DE PAGAMENTO DE ACORDOS COMERCIAIS
    ''' </summary>
    ''' <param name="vpTipCsn">
    ''' 1) Lista as Promessas do Fornecedor
    ''' 2) Lista informacoes de Promessa Especifica do Fornecedor
    ''' 3) Notas relacionadas a Promessa do Fornecedor
    ''' 4) Notas disponiveis para relacionamento
    ''' 5) Insere/atualiza notas na relacao de acordos comerciais X duplicatas
    '''    Para esta opcao todos os prnincipais campos da tabela T0134045 devem ser informados
    ''' 6) Desativa notas na relacao de acordos comerciais X duplicatas
    '''    Para esta opcao todos os prnincipais campos da tabela T0134045 devem ser informados
    ''' 7) Lista as Promessas Parciais do Fornecedor
    ''' 8) Lista informacoes de Promessa  Parciais Especifica do Fornecedor
    ''' 9) Insere/atualiza notas na relacao de acordos comerciais X duplicatas
    '''    Para esta opcao todos os prnincipais campos da tabela T0138058 devem ser informados (IndAscArdFrnPms = 1)
    '''    Para esta opcao todos os prnincipais campos da tabela T0138066 devem ser informados (IndAscArdFrnPms = 1)
    '''    Para esta opcao todos os prnincipais campos da tabela T0134045 devem ser informados
    ''' 10)Desativa notas na relacao de acordos comerciais X duplicatas
    '''    Para esta opcao todos os prnincipais campos da tabela T0138058 devem ser informados (IndAscArdFrnPms = 1)
    '''    Para esta opcao todos os prnincipais campos da tabela T0138066 devem ser informados (IndAscArdFrnPms = 1)
    '''    Para esta opcao todos os prnincipais campos da tabela T0134045 devem ser informados
    ''' </param>
    ''' <param name="vpCodFrn"></param>
    ''' <param name="vpCodPms"></param>
    ''' <param name="vpCodEmp"></param>
    ''' <param name="vpCodFilEmp"></param>
    ''' <param name="vpCodEmpFrn"></param>
    ''' <param name="vpDatPrvRcbPms"></param>
    ''' <param name="vpTipFrmDscBnf"></param>
    ''' <param name="vpTipDsnDscBnf"></param>
    ''' <param name="vpDatNgcPms"></param>
    ''' <param name="vpNumNotFscFrnCtb"></param>
    ''' <param name="vpCodSeqPclNotFsc"></param>
    ''' <param name="vpNumSeqTitPgt"></param>
    ''' <param name="vpVlrTitPgtUtzSbtPms"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio]	6/10/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterTrocaManualTituloPagamentoAcordoComercial(ByVal vpTipCsn As Integer, _
                                                                    ByVal vpCodFrn As Integer, _
                                                                    ByVal vpCodPms As Integer, _
                                                                    ByVal vpCodEmp As Integer, _
                                                                    ByVal vpCodFilEmp As Integer, _
                                                                    ByVal vpCodEmpFrn As Integer, _
                                                                    ByVal vpDatPrvRcbPms As Date, _
                                                                    ByVal vpTipFrmDscBnf As Integer, _
                                                                    ByVal vpTipDsnDscBnf As Integer, _
                                                                    ByVal vpDatNgcPms As Date, _
                                                                    ByVal vpNumNotFscFrnCtb As Integer, _
                                                                    ByVal vpCodSeqPclNotFsc As String, _
                                                                    ByVal vpNumSeqTitPgt As Integer, _
                                                                    ByVal vpVlrTitPgtUtzSbtPms As Decimal) As wsAcoesComerciais.DatasetTrocaManualTituloPagamentoAcordoComercial
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterTrocaManualTituloPagamentoAcordoComercial(vpTipCsn, _
                                                                vpCodFrn, _
                                                                vpCodPms, _
                                                                vpCodEmp, _
                                                                vpCodFilEmp, _
                                                                vpCodEmpFrn, _
                                                                vpDatPrvRcbPms, _
                                                                vpTipFrmDscBnf, _
                                                                vpTipDsnDscBnf, _
                                                                vpDatNgcPms, _
                                                                vpNumNotFscFrnCtb, _
                                                                vpCodSeqPclNotFsc, _
                                                                vpNumSeqTitPgt, _
                                                                vpVlrTitPgtUtzSbtPms)
    End Function


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Preenche o extratro do fornecedor
    ''' </summary>
    ''' <param name="Ano"></param>
    ''' <param name="Mes"></param>
    ''' <param name="CodFrn"></param>
    ''' <param name="TipDsnDscBnf"></param>
    ''' <param name="FlgDsp"></param>
    ''' <param name="TipPmt"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio]	16/10/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterPesquisaExtratoMovimentoDiarioFornecedor(ByVal Ano As Integer, _
                                                                         ByVal Mes As Integer, _
                                                                         ByVal CodFrn As Integer, _
                                                                         ByVal TipDsnDscBnf As Integer, _
                                                                         ByVal FlgDsp As String, _
                                                                         ByVal TipPmt As Integer) As wsAcoesComerciais.DatasetExtratoMovimentoDiarioFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterPesquisaExtratoMovimentoDiarioFornecedor(Ano, Mes, CodFrn, TipDsnDscBnf, FlgDsp, TipPmt)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Retorna dados do cartório por célula
    ''' </summary>
    ''' <param name="CodDivCmp"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterDadosDoCartorioPorCelula(ByVal CodDivCmp As Integer) As wsAcoesComerciais.DatasetDadosDoCartorioPorCelula

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000

        Return webService.ObterDadosDoCartorioPorCelula(CodDivCmp)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Seleciona as Perdas Disponíveis
    ''' </summary>
    ''' <param name="CODFRN"></param>
    ''' <param name="CODDIVCMP"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterPerdasDisponiveis(ByVal CODFRN As Integer, _
                                                  ByVal CODDIVCMP As Integer) As wsAcoesComerciais.DatasetPerdasDisponiveis

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000

        Return webService.ObterPerdasDisponiveis(CODFRN, CODDIVCMP)
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Busca todos os valores apurados para contratos válidos do fornecedor
    ''' </summary>
    ''' <param name="CODFRN"></param>
    ''' <param name="NUMCSLCTTFRN"></param>
    ''' <param name="TIPFRMDSCBNF"></param>
    ''' <param name="TIPDSNDSCBNF"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/10/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterValoresApuradosContratosValidosDoFornecedor(ByVal CODFRN As Integer, _
                                                                            ByVal NUMCSLCTTFRN As Integer, _
                                                                            ByVal TIPFRMDSCBNF As Integer, _
                                                                            ByVal TIPDSNDSCBNF As Integer) As wsAcoesComerciais.DatasetValoresApuradosContratosValidosDoFornecedor

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000

        Return webService.ObterValoresApuradosContratosValidosDoFornecedor(CODFRN, NUMCSLCTTFRN, TIPFRMDSCBNF, TIPDSNDSCBNF)
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Selecionar as promessas em aberto de acordo com o empenho em questão.
    ''' </summary>
    ''' <param name="TipDsnDscBnf"></param>
    ''' <param name="TipFrmDscBnf"></param>
    ''' <param name="CodDivCmp"></param>
    ''' <param name="CodFrn"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/10/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterAcordosEmAbertoPorEmpenho(ByVal TipDsnDscBnf As Decimal, _
                                                          ByVal TipFrmDscBnf As Decimal, _
                                                          ByVal CodDivCmp As Decimal, _
                                                          ByVal CodFrn As Decimal) As wsAcoesComerciais.DatasetAcordosEmAbertoPorEmpenho

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000

        Return webService.ObterAcordosEmAbertoPorEmpenho(TipDsnDscBnf, TipFrmDscBnf, CodDivCmp, CodFrn)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chamada para procedure: MRT.PCTDKSelAcoCmcBxa.PRCDKSelAcoCmcBxa
    ''' </summary>
    ''' <param name="pvCodpms"></param>
    ''' <param name="pvCodFilEmp"></param>
    ''' <param name="pvnumpedcmp"></param>
    ''' <param name="pvCodFrn"></param>
    ''' <param name="pvDatIniPod"></param>
    ''' <param name="pvDatFimPod"></param>
    ''' <param name="pvflag"></param>
    ''' <remarks>
    ''' Chamada para procedure: MRT.PCTDKSelAcoCmcBxa.PRCDKSelAcoCmcBxa
    ''' LEGADO:SPCBY300
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    20/12/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterAcoesComerciaisBaixa(ByVal pvCodpms As Decimal, _
                                                     ByVal pvCodFilEmp As Decimal, _
                                                     ByVal pvnumpedcmp As Decimal, _
                                                     ByVal pvCodFrn As Decimal, _
                                                     ByVal pvDatIniPod As Date, _
                                                     ByVal pvDatFimPod As Date, _
                                                     ByVal pvflag As Integer) As wsAcoesComerciais.DatasetAcordo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000

        Return webService.ObterAcoesComerciaisBaixa(pvCodpms, _
                                                    pvCodFilEmp, _
                                                    pvnumpedcmp, _
                                                    pvCodFrn, _
                                                    pvDatIniPod, _
                                                    pvDatFimPod, _
                                                    pvflag)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chamada para procedure: MRT.PCTDKObtMaxCodOrdPgtFrnAsc.PRCDKObtMaxCodOrdPgtFrnAsc
    ''' </summary>
    ''' <param name="pvCodFrn"></param>
    ''' <remarks>
    ''' Chamada para procedure: MRT.PCTDKObtMaxCodOrdPgtFrnAsc.PRCDKObtMaxCodOrdPgtFrnAsc
    ''' LEGADO:SPCBU223
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    21/12/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterMaximoDeCodigoOrdemPagamentoFornecedor(ByVal pvCodFrn As Integer) As wsAcoesComerciais.DatasetOPRecebidaFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterMaximoDeCodigoOrdemPagamentoFornecedor(pvCodFrn)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chamada para procedure: MRT.PCTDJObtDrtCmpFrn.PRCDJObtDrtCmpFrn
    ''' </summary>
    ''' <param name="pvCodFrn"></param>
    ''' <remarks>
    ''' Chamada para procedure: MRT.PCTDJObtDrtCmpFrn.PRCDJObtDrtCmpFrn
    ''' LEGADO:spCCX043
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    30/12/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterDiretoriaEDivisaoDeCompraDeFornecedor(ByVal pvCodFrn As Decimal) As wsAcoesComerciais.DatasetDiretoriaEDivisaoDeCompraDeFornecedor
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterDiretoriaEDivisaoDeCompraDeFornecedor(pvCodFrn)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0125046
    ''' Descrição da entidade:HISTORICO MENSAL AVALIACAO DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="CODEDEABGMIX">CODIGO DA ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <param name="DATREFAPU">DATA DE REFERENCIA DA APURACAO.</param>
    ''' <param name="NUMCSLCTTFRN">NUMERO DA CLAUSULA DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMCTTFRN">NUMERO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMREFPOD">NUMERO DE REFERENCIA DO PERIODO.</param>
    ''' <param name="TIPEDEABGMIX">TIPO DE ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <param name="TIPPODCTTFRN">TIPO DE PERIODO CONTRATO DE FORNECIMENTO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    02/01/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterEntidade(ByVal CODEDEABGMIX As Decimal, _
                                         ByVal DATREFAPU As Date, _
                                         ByVal NUMCSLCTTFRN As Decimal, _
                                         ByVal NUMCTTFRN As Decimal, _
                                         ByVal NUMREFPOD As Decimal, _
                                         ByVal TIPEDEABGMIX As Decimal, _
                                         ByVal TIPPODCTTFRN As Decimal) As wsAcoesComerciais.DatasetEntidade
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterEntidade(CODEDEABGMIX, DATREFAPU, NUMCSLCTTFRN, NUMCTTFRN, NUMREFPOD, TIPEDEABGMIX, TIPPODCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0125046
    ''' Descrição da entidade:HISTORICO MENSAL AVALIACAO DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="CODEDEABGMIX">CODIGO DA ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <param name="CODFXAAVL">CODIGO DA FAIXA DE AVALIACAO.</param>
    ''' <param name="CODPMS">CODIGO PROMESSA.</param>
    ''' <param name="DATNGCPMS">DATA DA NEGOCIACAO DA PROMESSA.</param>
    ''' <param name="DATNGCPMSInicial">DATA DA NEGOCIACAO DA PROMESSA INICIAL.</param>
    ''' <param name="DATNGCPMSFinal">DATA DA NEGOCIACAO DA PROMESSA FINAL.</param>
    ''' <param name="DATREFAPU">DATA DE REFERENCIA DA APURACAO.</param>
    ''' <param name="DATREFAPUInicial">DATA DE REFERENCIA DA APURACAO INICIAL.</param>
    ''' <param name="DATREFAPUFinal">DATA DE REFERENCIA DA APURACAO FINAL.</param>
    ''' <param name="NUMCSLCTTFRN">NUMERO DA CLAUSULA DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMCTTFRN">NUMERO DO CONTRATO DE FORNECIMENTO.</param>
    ''' <param name="NUMCTTFRNAPUPOD">NUMERO DO CONTRATO DE FORNECIMENTO APURADO NO PERIODO.</param>
    ''' <param name="NUMREFPOD">NUMERO DE REFERENCIA DO PERIODO.</param>
    ''' <param name="TIPEDEABGMIX">TIPO DE ENTIDADE DE ABRANGENCIA DO MIX.</param>
    ''' <param name="TIPPODCTTFRN">TIPO DE PERIODO CONTRATO DE FORNECIMENTO.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0125046" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    02/01/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterEntidades(ByVal CODEDEABGMIX As Decimal, _
                                          ByVal CODFXAAVL As Decimal, _
                                          ByVal CODPMS As Decimal, _
                                          ByVal DATNGCPMS As Date, _
                                          ByVal DATNGCPMSInicial As Date, _
                                          ByVal DATNGCPMSFinal As Date, _
                                          ByVal DATREFAPU As Date, _
                                          ByVal DATREFAPUInicial As Date, _
                                          ByVal DATREFAPUFinal As Date, _
                                          ByVal NUMCSLCTTFRN As Decimal, _
                                          ByVal NUMCTTFRN As Decimal, _
                                          ByVal NUMCTTFRNAPUPOD As Decimal, _
                                          ByVal NUMREFPOD As Decimal, _
                                          ByVal TIPEDEABGMIX As Decimal, _
                                          ByVal TIPPODCTTFRN As Decimal) As wsAcoesComerciais.DatasetEntidade
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterEntidades(CODEDEABGMIX, CODFXAAVL, CODPMS, DATNGCPMS, DATNGCPMSInicial, DATNGCPMSFinal, DATREFAPU, DATREFAPUInicial, DATREFAPUFinal, NUMCSLCTTFRN, NUMCTTFRN, NUMCTTFRNAPUPOD, NUMREFPOD, TIPEDEABGMIX, TIPPODCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem 
    ''' </summary>
    ''' <param name="NUMCTTFRN"></param>
    ''' <param name="NUMCSLCTTFRN"></param>
    ''' <param name="TIPEDEABGMIX"></param>
    ''' <param name="CODEDEABGMIX"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	1/2/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterDistinctDatRefIniUtzPmtDeFaixa(ByVal NUMCTTFRN As Decimal, _
                                                               ByVal NUMCSLCTTFRN As Decimal, _
                                                               ByVal TIPEDEABGMIX As Decimal, _
                                                               ByVal CODEDEABGMIX As Decimal) As wsAcoesComerciais.DatasetFaixaAvaliacao

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterDistinctDatRefIniUtzPmtDeFaixa(NUMCTTFRN, _
                                                              NUMCSLCTTFRN, _
                                                              TIPEDEABGMIX, _
                                                              CODEDEABGMIX)

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NUMCTTFRN"></param>
    ''' <param name="NUMCSLCTTFRN"></param>
    ''' <param name="TIPPODCTTFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	2/2/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterDistinctDATINIPODDePeriodo(ByVal NUMCTTFRN As Decimal, _
                                                           ByVal NUMCSLCTTFRN As Decimal, _
                                                           ByVal TIPPODCTTFRN As Decimal) As wsAcoesComerciais.DatasetContratoXPeriodo

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterDistinctDATINIPODDePeriodo(NUMCTTFRN, _
                                                          NUMCSLCTTFRN, _
                                                          TIPPODCTTFRN)

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chamada para procedure: MRT.PctDLAtlPgcAutCttArdFrn.PrcDlPodCslCtt
    ''' </summary>
    ''' <param name="ppin_Ctt"></param>
    ''' <param name="ppin_Cla"></param>
    ''' <param name="ppin_Per"></param>
    ''' <param name="ppis_CodUni"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	2/2/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub GerarPeriodosParaClausulaDeContrato(ByVal ppin_Ctt As Integer, _
                                                          ByVal ppin_Cla As Integer, _
                                                          ByVal ppin_Per As Integer)

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials

        webService.GerarPeriodosParaClausulaDeContrato(ppin_Ctt, _
                                                       ppin_Cla, _
                                                       ppin_Per)

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chamada para procedure: MRT.PCTDLCnsAscCslFrn.PRCDLCnsAscCslFrn
    ''' </summary>
    ''' <param name="pvCodFrn"></param>
    ''' <param name="pvNumCttFrn"></param>
    ''' <param name="pvNumCslCttFrn"></param>
    ''' <remarks>
    ''' Chamada para procedure: MRT.PCTDLCnsAscCslFrn.PRCDLCnsAscCslFrn
    ''' LEGADO: spCLJ117
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/02/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterAssociacaoClausulaFornecedor(ByVal pvCodFrn As Decimal, _
                                                             ByVal pvNumCttFrn As Decimal, _
                                                             ByVal pvNumCslCttFrn As Decimal) As wsAcoesComerciais.DatasetContrato

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials

        Return webService.ObterAssociacaoClausulaFornecedor(pvCodFrn, _
                                                            pvNumCttFrn, _
                                                            pvNumCslCttFrn)
    End Function

#End Region

#Region " Relatórios "

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Relatorio Historico Contrato X Promessa
    ''' </summary>
    ''' <param name="pCodPms">Promessa</param>
    ''' <returns>Dataset com a Tabela tbHistoricoAcordo preenchida</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	15/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioHistoricoAcordo(ByVal pCodPms As Integer) As wsAcoesComerciais.DatasetRelatorioHistoricoAcordo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioHistoricoAcordo(pCodPms)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Relatorio Historico Contrato X Promessa
    ''' </summary>
    ''' <param name="pDatInicial">Data Inicial do Período</param>
    ''' <param name="pDatFinal">Data Final do Período</param>
    ''' <param name="pCodFrn">Código Fornecedor</param>
    ''' <param name="pNomFrn">Nome Fornecedor</param>
    ''' <returns>Dataset com a Tabela  preenchida</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Bruno Viso]	06/06/2013	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioHistoricoBaixaOP(ByVal pDatInicial As String, ByVal pDatFinal As String, ByVal pCodFrn As Integer, ByVal pNomFrn As String) As wsAcoesComerciais.DatasetRelatorioHistoricoBaixaOP
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioHistoricoBaixaOP(pDatInicial, pDatFinal, pCodFrn, pNomFrn)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Relatorio Historico Acordo Fornecimento rpclj027.rpt
    ''' </summary>
    ''' <param name="CodDivCmp"></param>
    ''' <param name="NumCslCttFrn"></param>
    ''' <param name="TipPodCttFrn"></param>
    ''' <param name="DatIni"></param>
    ''' <param name="DatFim"></param>
    ''' <returns>Dataset com a Tabela tbAcordoFornecimento_027 preenchida</returns>
    ''' <remarks>
    ''' O posfixo 027 é por compatibilidade do nome do legado
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	15/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioAcordoFornecimento_027(ByVal CodDivCmp As Decimal, _
                                                                ByVal NumCslCttFrn As Decimal, _
                                                                ByVal TipPodCttFrn As Decimal, _
                                                                ByVal DatIni As Date, _
                                                                ByVal DatFim As Date) As wsAcoesComerciais.DatasetRelatorioAcordoFornecimento
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioAcordoFornecimento_027(CodDivCmp, NumCslCttFrn, TipPodCttFrn, DatIni, DatFim)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Relatorio Historico Acordo Fornecimento rpclj041.rpt
    ''' </summary>
    ''' <param name="CodDivCmp"></param>
    ''' <param name="NumCslCttFrn"></param>
    ''' <param name="TipPodCttFrn"></param>
    ''' <param name="DatIni"></param>
    ''' <param name="DatFim"></param>
    ''' <returns>Dataset com a Tabela tbAcordoFornecimento_041 preenchida</returns>
    ''' <remarks>
    ''' O posfixo 027 é por compatibilidade do nome do legado
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	15/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioAcordoFornecimento_041(ByVal CodDivCmp As Integer, ByVal NumCslCttFrn As Decimal, ByVal TipPodCttFrn As Decimal, ByVal DatIni As Date, ByVal DatFim As Date) As wsAcoesComerciais.DatasetRelatorioAcordoFornecimento
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioAcordoFornecimento_041(CodDivCmp, NumCslCttFrn, TipPodCttFrn, DatIni, DatFim)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Relatorio Historico Acordo Fornecimento rpclj022.rpt
    ''' </summary>
    ''' <param name="CodFrn"></param>
    ''' <param name="TipPod"></param>
    ''' <param name="NumCttFrn"></param>
    ''' <param name="NumCslCttFrn"></param>
    ''' <param name="TipEdeAbgMix"></param>
    ''' <param name="CodEdeAbgMix"></param>
    ''' <param name="NumRefPod"></param>
    ''' <param name="DatIniPod"></param>
    ''' <returns>Dataset com a Tabela tbAcordoFornecimento_022 preenchida</returns>
    ''' <remarks>
    ''' O posfixo 022 é por compatibilidade do nome do legado
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	15/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioAcordoFornecimento_022(ByVal CodFrn As Decimal, _
                                                                ByVal TipPod As Decimal, _
                                                                ByVal NumCttFrn As Decimal, _
                                                                ByVal NumCslCttFrn As Decimal, _
                                                                ByVal TipEdeAbgMix As Decimal, _
                                                                ByVal CodEdeAbgMix As Decimal, _
                                                                ByVal NumRefPod As Decimal, _
                                                                ByVal DatIniPod As Date) As wsAcoesComerciais.DatasetRelatorioAcordoFornecimento
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioAcordoFornecimento_022(CodFrn, TipPod, NumCttFrn, NumCslCttFrn, TipEdeAbgMix, CodEdeAbgMix, NumRefPod, DatIniPod)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Relatorio Acordo Fornecimento rpclj023.rpt
    ''' </summary>
    ''' <param name="CodFrn"></param>
    ''' <param name="TipPod"></param>
    ''' <param name="NumCttFrn"></param>
    ''' <param name="NumCslCttFrn"></param>
    ''' <param name="TipEdeAbgMix"></param>
    ''' <param name="CodEdeAbgMixPAR"></param>
    ''' <param name="NumRefPod"></param>
    ''' <param name="DatIniPodPAR"></param>
    ''' <returns>Dataset com a Tabela tbAcordoFornecimento_023 preenchida</returns>
    ''' <remarks>
    ''' O posfixo 023 é por compatibilidade do nome do legado
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	15/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioAcordoFornecimento_023(ByVal CodFrn As Decimal, _
                                                                ByVal TipPod As Decimal, _
                                                                ByVal NumCttFrn As Decimal, _
                                                                ByVal NumCslCttFrn As Decimal, _
                                                                ByVal TipEdeAbgMix As Decimal, _
                                                                ByVal CodEdeAbgMixPAR As Decimal, _
                                                                ByVal NumRefPod As Decimal, _
                                                                ByVal DatIniPodPAR As Date) As wsAcoesComerciais.DatasetRelatorioAcordoFornecimento
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioAcordoFornecimento_023(CodFrn, TipPod, NumCttFrn, NumCslCttFrn, TipEdeAbgMix, CodEdeAbgMixPAR, NumRefPod, DatIniPodPAR)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Relatorio Acordo Fornecimento 
    ''' rpcClj051B.rpt – Procedure: spClj051;1 
    ''' rpcClj051A.rpt – Procedure: spClj051;1 
    ''' </summary>
    ''' <param name="CodFrn"></param>
    ''' <param name="TipPod"></param>
    ''' <param name="NumCttFrn"></param>
    ''' <param name="NumCslCttFrn"></param>
    ''' <param name="TipEdeAbgMix"></param>
    ''' <param name="CodEdeAbgMixPAR"></param>
    ''' <param name="NumRefPod"></param>
    ''' <param name="DatIniPodPAR"></param>
    ''' <returns>Dataset com a Tabela tbAcordoFornecimento_051 preenchida</returns>
    ''' <remarks>
    ''' O posfixo 051 é por compatibilidade do nome do legado
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	15/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioAcordoFornecimento_051(ByVal CodFrn As Decimal, _
                                                                ByVal TipPod As Decimal, _
                                                                ByVal NumCttFrn As Decimal, _
                                                                ByVal NumCslCttFrn As Decimal, _
                                                                ByVal TipEdeAbgMix As Decimal, _
                                                                ByVal CodEdeAbgMixPAR As Decimal, _
                                                                ByVal NumRefPod As Decimal, _
                                                                ByVal DatIniPodPAR As Date) As wsAcoesComerciais.DatasetRelatorioAcordoFornecimento
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioAcordoFornecimento_051(CodFrn, TipPod, NumCttFrn, NumCslCttFrn, TipEdeAbgMix, CodEdeAbgMixPAR, NumRefPod, DatIniPodPAR)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Relatorio Acordo Fornecimento 
    ''' rpcClj052D1.rpt – Procedure: spClj052;1 
    ''' rpcClj052A1.rpt – Procedure: spClj052;1 
    ''' rpcClj052C1.rpt – Procedure: spClj052;1 
    ''' rpcClj052B1.rpt – Procedure: spClj052;1 
    ''' rpcClj052A.rpt – Procedure: spClj052;1 
    ''' rpcClj052D.rpt – Procedure: spClj052;1 
    ''' rpcClj052A.rpt – Procedure: spClj052;1 
    ''' rpcClj052C.rpt – Procedure: spClj052;1 
    ''' rpcClj052B.rpt – Procedure: spClj052;1 
    ''' rpcClj052A1.rpt – Procedure: spClj052;1
    ''' </summary>
    ''' <param name="CodFrn"></param>
    ''' <param name="TipPod"></param>
    ''' <param name="NumCttFrn"></param>
    ''' <param name="NumCslCttFrn"></param>
    ''' <param name="TipEdeAbgMix"></param>
    ''' <param name="CodEdeAbgMixPAR"></param>
    ''' <param name="NumRefPod"></param>
    ''' <param name="DatRefPod"></param>
    ''' <returns>Dataset com a Tabela tbAcordoFornecimento_052 preenchida</returns>
    ''' <remarks>
    ''' O posfixo 052 é por compatibilidade do nome do legado
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	15/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioAcordoFornecimento_052(ByVal CodFrn As Integer, _
                                                                ByVal TipPod As Integer, _
                                                                ByVal NumCttFrn As Decimal, _
                                                                ByVal NumCslCttFrn As Integer, _
                                                                ByVal TipEdeAbgMix As Integer, _
                                                                ByVal CodEdeAbgMixPAR As Decimal, _
                                                                ByVal NumRefPod As Integer, _
                                                                ByVal DatRefPod As Date) As wsAcoesComerciais.DatasetRelatorioAcordoFornecimento
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioAcordoFornecimento_052(CodFrn, TipPod, NumCttFrn, NumCslCttFrn, TipEdeAbgMix, CodEdeAbgMixPAR, NumRefPod, DatRefPod)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Relatorio Acordo Fornecimento rpcclj053.rpt
    ''' </summary>
    ''' <param name="CodFrn"></param>
    ''' <param name="TipPod"></param>
    ''' <param name="NumCttFrn"></param>
    ''' <param name="NumCslCttFrn"></param>
    ''' <param name="TipEdeAbgMix"></param>
    ''' <param name="CodEdeAbgMixPAR"></param>
    ''' <param name="NumRefPod"></param>
    ''' <param name="DatRefPodPar"></param>
    ''' <returns>Dataset com a Tabela tbAcordoFornecimento_053 preenchida</returns>
    ''' <remarks>
    ''' O posfixo 053 é por compatibilidade do nome do legado
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	15/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioAcordoFornecimento_053(ByVal CodFrn As Decimal, _
                                                                ByVal TipPod As Decimal, _
                                                                ByVal NumCttFrn As Decimal, _
                                                                ByVal NumCslCttFrn As Decimal, _
                                                                ByVal TipEdeAbgMix As Decimal, _
                                                                ByVal CodEdeAbgMixPAR As Decimal, _
                                                                ByVal NumRefPod As Decimal, _
                                                                ByVal DatRefPodPar As Date) As wsAcoesComerciais.DatasetRelatorioAcordoFornecimento
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioAcordoFornecimento_053(CodFrn, TipPod, NumCttFrn, NumCslCttFrn, TipEdeAbgMix, CodEdeAbgMixPAR, NumRefPod, DatRefPodPar)
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' AcordoFornecimento-AlteraFormaPagto rpclj070.rpt
    ''' </summary>
    ''' <param name="Opcao"></param>
    ''' <param name="CodFrn"></param>
    ''' <returns>Dataset com a Tabela tbAcordoFornecimento_074 preenchida</returns>
    ''' <remarks>
    ''' O posfixo 074 é por compatibilidade do nome do legado
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	10/28/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioAcordoFornecimento_074(ByVal Opcao As Integer, _
                                                                 ByVal CodFrn As Integer) As wsAcoesComerciais.DatasetRelatorioAcordoFornecimento
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioAcordoFornecimento_074(Opcao, CodFrn)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Relatorio Acordo p/Deduction 
    ''' cby002z5.rpt – Procedure: spCBU184;1
    ''' cby002z5a.rpt – Procedure: spCBU184;1
    ''' 
    ''' Acordo s/NF p/Deduction 
    ''' cby002Z4.rpt – Procedure: spCBU184:1
    ''' </summary>
    ''' <param name="CodFrn"></param>
    ''' <param name="TipPod"></param>
    ''' <param name="NumCttFrn"></param>
    ''' <param name="NumCslCttFrn"></param>
    ''' <param name="TipEdeAbgMix"></param>
    ''' <param name="CodEdeAbgMixPAR"></param>
    ''' <param name="NumRefPod"></param>
    ''' <param name="DatRefPodPar"></param>
    ''' <returns>Dataset com a Tabela tbAcordoParaDeduction preenchida</returns>
    ''' <remarks>
    ''' Como a proc é a mesma para o relatório de Deduction s/ NF, esse método será 
    ''' reaproveitado para o mesmo
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	15/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioAcordoParaDeduction(ByVal TipOpeEnt As Integer, _
                                                             ByVal CodFrnEnt As Integer, _
                                                             ByVal CodDivCmpEnt As Integer, _
                                                             ByVal TipFrmDscBnfEnt As Integer, _
                                                             ByVal DatIniEnt As Date, _
                                                             ByVal DatFimEnt As Date, _
                                                             ByVal ChkEfetivadoEnt As Integer, _
                                                             ByVal ChkAssociadoEnt As Integer) As wsAcoesComerciais.DatasetRelatorioAcordoParaDeduction
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioAcordoParaDeduction(TipOpeEnt, CodFrnEnt, CodDivCmpEnt, TipFrmDscBnfEnt, DatIniEnt, DatFimEnt, ChkEfetivadoEnt, ChkAssociadoEnt)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Conferencia Ação Tática 
    ''' cby002z2a.rpt – Procedure: spCLJ113;1
    ''' cby002z2b.rpt – Procedure: spCLJ113;1
    ''' </summary>
    ''' <param name="CodFrn"></param>
    ''' <param name="MesRef"></param>
    ''' <param name="Opcao"></param>
    ''' <returns>Dataset com a Tabela tbConferenciaAcaoTatica preenchida</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	15/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioConferenciaAcaoTatica(ByVal CodFrn As Integer, _
                                                               ByVal MesRef As String, _
                                                               ByVal Opcao As Integer) As wsAcoesComerciais.DatasetRelatorioConferenciaAcaoTatica
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioConferenciaAcaoTatica(CodFrn, MesRef, Opcao)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Conta A Receber CBY002ZA.RPT 
    ''' </summary>
    ''' <param name="DatInicial"></param>
    ''' <param name="DatFinal"></param>
    ''' <param name="CelI"></param>
    ''' <param name="CelF"></param>
    ''' <param name="FrnI"></param>
    ''' <param name="FrnF"></param>
    ''' <param name="FrmI"></param>
    ''' <param name="FrmF"></param>
    ''' <param name="DsnI"></param>
    ''' <param name="DsnF"></param>
    ''' <param name="Abo"></param>
    ''' <returns>Dataset com a Tabela tbContasAReceber_02ZA preenchida</returns>
    ''' <remarks>
    ''' CBY002ZA.RPT – Procedure: spCBU099;1
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	18/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioContasAReceber_02ZA(ByVal DatInicial As Date, _
                                                             ByVal DatFinal As Date, _
                                                             ByVal CelI As Integer, _
                                                             ByVal CelF As Integer, _
                                                             ByVal FrnI As Integer, _
                                                             ByVal FrnF As Integer, _
                                                             ByVal FrmI As Integer, _
                                                             ByVal FrmF As Integer, _
                                                             ByVal DsnI As Integer, _
                                                             ByVal DsnF As Integer, _
                                                             ByVal Abo As Integer) As wsAcoesComerciais.DatasetRelatorioContasAReceber
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioContasAReceber_02ZA(DatInicial, DatFinal, CelI, CelF, FrnI, FrnF, FrmI, FrmF, DsnI, DsnF, Abo)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Contas a Receber Sintético CBY002ZB.RPT
    ''' </summary>
    ''' <param name="PmtIdtSmn"></param>
    ''' <param name="CodCelI"></param>
    ''' <param name="CodCelF"></param>
    ''' <param name="CodFrnI"></param>
    ''' <param name="CodFrnF"></param>
    ''' <param name="TipFrmI"></param>
    ''' <param name="TipFrmF"></param>
    ''' <param name="TipDsnI"></param>
    ''' <param name="TipDsnF"></param>
    ''' <param name="PmtFlgTot"></param>
    ''' <returns>Dataset com a Tabela tbContasAReceber_02ZB preenchida</returns>
    ''' <remarks>
    ''' CBY002ZB.RPT – Procedure: spCBU243;1
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	18/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioContasAReceber_02ZB(ByVal PmtIdtSmn As Integer, _
                                                             ByVal CodCelI As Integer, _
                                                             ByVal CodCelF As Integer, _
                                                             ByVal CodFrnI As Integer, _
                                                             ByVal CodFrnF As Integer, _
                                                             ByVal TipFrmI As Integer, _
                                                             ByVal TipFrmF As Integer, _
                                                             ByVal TipDsnI As Integer, _
                                                             ByVal TipDsnF As Integer, _
                                                             ByVal PmtFlgTot As Integer) As wsAcoesComerciais.DatasetRelatorioContasAReceber
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioContasAReceber_02ZB(PmtIdtSmn, CodCelI, CodCelF, CodFrnI, CodFrnF, TipFrmI, TipFrmF, TipDsnI, TipDsnF, PmtFlgTot)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Conta A Receber ABC - Saldo em Aberto CBY002ZC.RPT
    ''' </summary>
    ''' <param name="CodCelI"></param>
    ''' <param name="CodCelF"></param>
    ''' <param name="CodFrnI"></param>
    ''' <param name="CodFrnF"></param>
    ''' <param name="IdtFlgTodt"></param>
    ''' <returns>Dataset com a Tabela tbContasAReceber_02ZC preenchida</returns>
    ''' <remarks>
    ''' CBY002ZC.RPT – Procedure: spCBU248;1
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	18/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioContasAReceber_02ZC(ByVal CodCelI As Integer, _
                                                             ByVal CodCelF As Integer, _
                                                             ByVal CodFrnI As Integer, _
                                                             ByVal CodFrnF As Integer, _
                                                             ByVal IdtFlgTod As Integer) As wsAcoesComerciais.DatasetRelatorioContasAReceber
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioContasAReceber_02ZC(CodCelI, CodCelF, CodFrnI, CodFrnF, IdtFlgTod)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Conta A Receber ABC - Saldo em Aberto - A Emitir CBY002ZC1.RPT
    ''' </summary>
    ''' <param name="CodDivCmp"></param>
    ''' <param name="CodFrn"></param>
    ''' <param name="NumCslCttFrn"></param>
    ''' <returns>Dataset com a Tabela tbContasAReceber_02ZC1 preenchida</returns>
    ''' <remarks>
    ''' CBY002ZC1.RPT – Procedure: spCBU248;1
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	18/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioContasAReceber_02ZC1(ByVal CodDivCmp As Integer, _
                                                              ByVal CodFrn As Integer, _
                                                              ByVal NumCslCttFrn As Integer) As wsAcoesComerciais.DatasetRelatorioContasAReceber
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioContasAReceber_02ZC1(CodDivCmp, CodFrn, NumCslCttFrn)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Conta A Receber - Acordos com Situação de Erro CBY002ZE1.RPT
    ''' </summary>
    ''' <param name="DatIni"></param>
    ''' <param name="DatFim"></param>
    ''' <returns>Dataset com a Tabela tbContasAReceber_02ZE1 preenchida</returns>
    ''' <remarks>
    ''' CBY002ZE1.RPT – Procedure: spCBU246;1
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	18/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioContasAReceber_02ZE1(ByVal DatIni As Date, _
                                                              ByVal DatFim As Date) As wsAcoesComerciais.DatasetRelatorioContasAReceber
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioContasAReceber_02ZE1(DatIni, DatFim)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Conta A Receber - Aging List Analítico ( Valores a receber por idade ) CBY002ZF.RPT
    ''' </summary>
    ''' <param name="CodCelI"></param>
    ''' <param name="CodCelF"></param>
    ''' <param name="CodFrnI"></param>
    ''' <param name="CodFrnF"></param>
    ''' <param name="QdeDiaInt"></param>
    ''' <param name="IdtFlgTod"></param>
    ''' <returns>Dataset com a Tabela tbContasAReceber_02ZF preenchida</returns>
    ''' <remarks>
    ''' CBY002ZF.RPT – Procedure: spCBU245;1
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	18/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioContasAReceber_02ZF(ByVal CodCelI As Integer, _
                                                             ByVal CodCelF As Integer, _
                                                             ByVal CodFrnI As Integer, _
                                                             ByVal CodFrnF As Integer, _
                                                             ByVal QdeDiaInt As Integer, _
                                                             ByVal IdtFlgTod As Integer, _
                                                             ByVal vTipIdtEmp As Integer) As wsAcoesComerciais.DatasetRelatorioContasAReceber
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioContasAReceber_02ZF(CodCelI, CodCelF, CodFrnI, CodFrnF, QdeDiaInt, IdtFlgTod, vTipIdtEmp)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Conta A Receber - INF. DO.AGING LIST SINTETICO ( VALORES A RECEBER POR IDADE)
    ''' CBY002ZG.RPT
    ''' </summary>
    ''' <param name="CodCelI"></param>
    ''' <param name="CodCelF"></param>
    ''' <param name="QdeDiaInt"></param>
    ''' <param name="IdtFlgTod"></param>
    ''' <returns>Dataset com a Tabela tbContasAReceber_02ZG preenchida</returns>
    ''' <remarks>
    ''' CBY002ZG.RPT– Procedure: spCBU244;1
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	18/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioContasAReceber_02ZG(ByVal CodCelI As Integer, _
                                                             ByVal CodCelF As Integer, _
                                                             ByVal QdeDiaInt As Integer, _
                                                             ByVal IdtFlgTod As Integer, _
                                                             ByVal vTipIdtEmp As Integer) As wsAcoesComerciais.DatasetRelatorioContasAReceber
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioContasAReceber_02ZG(CodCelI, CodCelF, QdeDiaInt, IdtFlgTod, vTipIdtEmp)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Conta A Receber - Bonificacoes e Desconto em Duplicata a Emitir
    ''' CBY002ZR.RPT
    ''' </summary>
    ''' <param name="CodDivCmp"></param>
    ''' <param name="CodFrn"></param>
    ''' <param name="NumCslCttFrn"></param>
    ''' <param name="ChmAcoNot"></param>
    ''' <returns>Dataset com a Tabela tbContasAReceber_02ZR preenchida</returns>
    ''' <remarks>
    ''' CBY002ZR.RPT– Procedure: spCBU241;1
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	18/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioContasAReceber_02ZR(ByVal CodDivCmp As Integer, _
                                                             ByVal CodFrn As Integer, _
                                                             ByVal NumCslCttFrn As Integer, _
                                                             ByVal ChmAcoNot As String) As wsAcoesComerciais.DatasetRelatorioContasAReceber
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioContasAReceber_02ZR(CodDivCmp, CodFrn, NumCslCttFrn, ChmAcoNot)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Gac-Manutenção Acordo.
    ''' cby002ka.rpt
    ''' </summary>
    ''' <param name="CodEmp"></param>
    ''' <param name="CodFilEmp"></param>
    ''' <param name="CodPms"></param>
    ''' <param name="DatNgcPms"></param>
    ''' <returns>Dataset com a Tabela TbAcordoAcoesComerciais_232 preenchida</returns>
    ''' <remarks>
    ''' Procedure legado SQL-SERVER:  spCBU232 
    ''' Procedure Migrada Oracle...: 
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	10/25/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioAcordoAcoesComerciais_232(ByVal CodEmp As Integer, _
                                                                   ByVal CodFilEmp As Integer, _
                                                                   ByVal CodPms As Integer, _
                                                                   ByVal DatNgcPms As Date) As wsAcoesComerciais.DatasetRelatorioAcordoAcoesComerciais
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioAcordoAcoesComerciais_232(CodEmp, CodFilEmp, CodPms, DatNgcPms)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Cancelar Vlrs.Fornec - Cancelar Valores para Fornecedores em Processo de Desativação. Dataset com a Tabela TbAcordoAcoesComerciais_194 preenchida.
    ''' CBY002AE.rpt 
    ''' </summary>
    ''' <param name="TipOpe"></param>
    ''' <param name="CodFrn"></param>
    ''' <param name="FlgCon"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Procedure legado SQL-SERVER: spCBU194
    ''' Procedure Migrada Oracle...: 
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	10/26/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioAcordoAcoesComerciais_194(ByVal TipOpe As Integer, _
                                                                   ByVal CodFrn As Integer, _
                                                                   ByVal FlgCon As Integer) As wsAcoesComerciais.DatasetRelatorioAcordoAcoesComerciais
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioAcordoAcoesComerciais_194(TipOpe, CodFrn, FlgCon)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''Contrato - Consulta acordos de fornecedores.
    ''' CLJ001Y.rpt 
    ''' </summary>
    ''' <param name="TipOpe"></param>
    ''' <param name="CodFrn"></param>
    ''' <param name="NumCttFrn"></param>
    ''' <param name="FlgTipOpe"></param>
    ''' <param name="Codigo"></param>
    ''' <param name="Tipo"></param>
    ''' <returns>Dataset com a Tabela TbAnaliticoAcoesComerciais preenchida</returns>
    ''' <remarks>
    ''' Procedure legado SQL-SERVER: SPCLJ127 
    ''' Procedure Migrada Oracle...: 
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	10/27/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioAnaliticoAcoesComerciais(ByVal TipOpe As Integer, _
                                                                  ByVal CodFrn As Integer, _
                                                                  ByVal NumCttFrn As Integer, _
                                                                  ByVal FlgTipOpe As Integer, _
                                                                  ByVal Codigo As Integer, _
                                                                  ByVal Tipo As String) As wsAcoesComerciais.DataSetRelatorioAnaliticoAcoesComerciais
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioAnaliticoAcoesComerciais(TipOpe, CodFrn, NumCttFrn, FlgTipOpe, Codigo, Tipo)
    End Function


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''Extrato- Extrato de Fornecedor.
    ''' CCX001i.rpt 
    ''' </summary>
    ''' <param name="Ano"></param>
    ''' <param name="Mes"></param>
    ''' <param name="CodFrn"></param>
    ''' <param name="TipDsnDscBnf"></param>
    ''' <param name="FlgDsp"></param>
    ''' <param name="TipPmt"></param>
    ''' <returns>Dataset com a Tabela TbExtratoContaCorrrente_012 preenchida</returns>
    ''' <remarks>
    ''' Procedure legado SQL-SERVER: spCCX012 
    ''' Procedure Migrada Oracle...: 
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	10/26/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioExtratoContaCorrrente_012(ByVal Ano As Integer, _
                                                                   ByVal Mes As Integer, _
                                                                   ByVal CodFrn As Integer, _
                                                                   ByVal TipDsnDscBnf As Integer, _
                                                                   ByVal FlgDsp As String, _
                                                                   ByVal TipPmt As Integer) As wsAcoesComerciais.DataSetRelatorioExtratoContaCorrrente
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioExtratoContaCorrrente_012(Ano, Mes, CodFrn, TipDsnDscBnf, FlgDsp, TipPmt)
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''  Extrato- Extrato de Fornecedor(disponível).
    '''  CCX001ia.rpt
    ''' </summary>
    ''' <param name="DataInicial"></param>
    ''' <param name="DataFinal"></param>
    ''' <param name="CodFrn"></param>
    ''' <param name="TipDsnDscBnf"></param>
    ''' <param name="FlgDsp"></param>
    ''' <param name="TipPmt"></param>
    ''' <param name="lst_TipDsnDscBnf"></param>
    ''' <returns>Dataset com a Tabela TbExtratoContaCorrrente_48 preenchida</returns>
    ''' <remarks>
    ''' Procedure legado SQL-SERVER: spCCX048 
    ''' Procedure Migrada Oracle...: 
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	10/26/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioExtratoContaCorrrente_048(ByVal DataInicial As Date, _
                                                                   ByVal DataFinal As Date, _
                                                                   ByVal CodFrn As Integer, _
                                                                   ByVal TipDsnDscBnf As Integer, _
                                                                   ByVal FlgDsp As String, _
                                                                   ByVal TipPmt As Integer, _
                                                                   ByVal lst_TipDsnDscBnf As String) As wsAcoesComerciais.DataSetRelatorioExtratoContaCorrrente
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioExtratoContaCorrrente_048(DataInicial, DataFinal, CodFrn, TipDsnDscBnf, FlgDsp, TipPmt, lst_TipDsnDscBnf)
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Recebimento.Dataset com a Tabela TbRecebo preenchida.
    ''' cby002la.rpt
    ''' </summary>
    ''' <param name="CodFrn"></param>
    ''' <returns>Dataset com a Tabela TbRecibo</returns>
    ''' <remarks>
    ''' Procedure legado SQL-SERVER: spCBU233 
    ''' Procedure Migrada Oracle...: 
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	10/30/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioRecibo(ByVal CodFrn As Integer) As wsAcoesComerciais.DataSetRelatorioRecibo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioRecibo(CodFrn)
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Relação de Perdas Emitidas.Dataset com a Tabela TbRelacaoPerdasEmitidas_163 preenchida.
    ''' rpclj148a.rpt
    ''' </summary>
    ''' <param name="CodDivCmp"></param>
    ''' <param name="CodFrn"></param>
    ''' <returns>Dataset com a Tabela TbRelacaoPerdasEmitidas_163 preenchida</returns>
    ''' <remarks>
    ''' Procedure legado SQL-SERVER: spCLJ163
    ''' Procedure Migrada Oracle...: 
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/3/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelacaoPerdasEmitidas_163(ByVal CodDivCmp As Integer, ByVal CodFrn As Integer) As wsAcoesComerciais.DatasetRelacaoPerdasEmitidas
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelacaoPerdasEmitidas_163(CodDivCmp, CodFrn)
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Relação de Perdas Emitidas.Dataset com a Tabela TbRelacaoPerdasEmitidas_164 preenchida.
    ''' rpclj148b.rpt
    ''' </summary>
    ''' <param name="CodFrn"></param>
    ''' <param name="DatIni"></param>
    ''' <param name="DatFim"></param>
    ''' <returns>Dataset com a Tabela TbRelacaoPerdasEmitidas_164 preenchida</returns>
    ''' <remarks>
    ''' Procedure legado SQL-SERVER: spCLJ164
    ''' Procedure Migrada Oracle...: 
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	11/3/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelacaoPerdasEmitidas_164(ByVal CodFrn As Integer, _
                                                          ByVal DatIni As Date, _
                                                          ByVal DatFim As Date) As wsAcoesComerciais.DatasetRelacaoPerdasEmitidas
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelacaoPerdasEmitidas_164(CodFrn, DatIni, DatFim)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chamada para procedure: MRT.PCTDLSmlStnCrs.PRCDLSmlStnCrs
    ''' </summary>
    ''' <param name="pvCodDivCmpEnt"></param>
    ''' <param name="pvCodFrnEnt"></param>
    ''' <param name="pvCodCprEnt"></param>
    ''' <param name="pvTipPodEnt"></param>
    ''' <param name="pvNumPorEnt"></param>
    ''' <param name="pvNumPor1Ent"></param>
    ''' <remarks>
    ''' Chamada para procedure: MRT.PCTDLSmlStnCrs.PRCDLSmlStnCrs
    ''' LEGADO:spCLJ121
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    14/12/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterSimulacaoSinteticaDeCrescimento(ByVal pvCodDivCmpEnt As Integer, _
                                                         ByVal pvCodFrnEnt As Integer, _
                                                         ByVal pvCodCprEnt As Integer, _
                                                         ByVal pvTipPodEnt As Integer, _
                                                         ByVal pvNumPorEnt As Integer, _
                                                         ByVal pvNumPor1Ent As Integer) As wsAcoesComerciais.DatasetSimulacaoSinteticaDeCrescimento

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000

        Return webService.ObterSimulacaoSinteticaDeCrescimento(pvCodDivCmpEnt, _
                                                               pvCodFrnEnt, _
                                                               pvCodCprEnt, _
                                                               pvTipPodEnt, _
                                                               pvNumPorEnt, _
                                                               pvNumPor1Ent)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chamada para procedure: MRT.PCTDJRetSldDisFrnCel.PRCDJRetSldDisFrnCel
    ''' </summary>
    ''' <param name="pvCodDivCmp"></param>
    ''' <param name="pvTipDsnDscBnf"></param>
    ''' <param name="pvAnoMesRef"></param>
    ''' <param name="pvTipo"></param>
    ''' <remarks>
    ''' Chamada para procedure: MRT.PCTDJRetSldDisFrnCel.PRCDJRetSldDisFrnCel
    ''' LEGADO:spccx025
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    27/12/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioSaldoDisponivelFornecedorCelula(ByVal pvCodDivCmp As Decimal, _
                                                                         ByVal pvCodCpr As Decimal, _
                                                                         ByVal pvTipDsnDscBnf As Decimal, _
                                                                         ByVal pvAnoMesRef As Decimal, _
                                                                         ByVal pvTipo As Integer) As wsAcoesComerciais.DataSetRelatorioSaldoDisponivelFornecedorCelula

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 600000

        Return webService.ObterRelatorioSaldoDisponivelFornecedorCelula(pvCodDivCmp, _
                                                                        pvCodCpr, _
                                                                        pvTipDsnDscBnf, _
                                                                        pvAnoMesRef, _
                                                                        pvTipo)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CodPms"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	27/5/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRelatorioBaixaAcordo(ByVal CODPMS As Decimal) As wsAcoesComerciais.DatasetRelatorioBaixaAcordo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterRelatorioBaixaAcordo(CODPMS)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem os dados para o relatorio Previsao Apuração
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Rodrigo Gama]	10/09/2008	Created
    ''' </history>
    ''' ------------------------------------------------------------------------------
    Public Shared Function ObterPrevisaoApuracao(ByVal FILTRO As Decimal, _
                                                 ByVal CODFRN As Decimal, _
                                                 ByVal CODCPR As Decimal, _
                                                 ByVal CODDIV As Decimal, _
                                                 ByVal CODDRT As Decimal) As wsAcoesComerciais.DatasetPrevisaoApuracao
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.ObterPrevisaoApuracao(FILTRO, CODFRN, CODCPR, CODDIV, CODDRT)
    End Function

#End Region

#End Region

#Region "Atualizar Dados"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0104499
    ''' Descrição da entidade:CADASTRO TIPO PEDIDO COMPRA
    ''' </summary>
    ''' <param name="DatasetTipoPedidoCompra">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    11/09/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTipoPedidoCompra(ByVal DatasetTipoPedidoCompra As wsAcoesComerciais.DatasetTipoPedidoCompra)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarTipoPedidoCompra(CType(DatasetTipoPedidoCompra.GetChanges(), wsAcoesComerciais.DatasetTipoPedidoCompra))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0119291
    ''' Descrição da entidade:HISTORICO DIARIO PENDENCIA RECEBIDANA ACAO COMERCIAL
    ''' </summary>
    ''' <param name="DatasetPendenciaRecebidaAcaoComercial">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    03/08/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarPendenciaRecebidaAcaoComercial(ByVal DatasetPendenciaRecebidaAcaoComercial As wsAcoesComerciais.DatasetPendenciaRecebidaAcaoComercial)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarPendenciaRecebidaAcaoComercial(CType(DatasetPendenciaRecebidaAcaoComercial.GetChanges(), wsAcoesComerciais.DatasetPendenciaRecebidaAcaoComercial))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0125038
    ''' Descrição da entidade:CADASTRO FAIXA DE AVALIACAO
    ''' </summary>
    ''' <param name="DatasetFaixaAvaliacao">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarFaixaAvaliacao(ByVal DatasetFaixaAvaliacao As wsAcoesComerciais.DatasetFaixaAvaliacao)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarFaixaAvaliacao(CType(DatasetFaixaAvaliacao.GetChanges(), wsAcoesComerciais.DatasetFaixaAvaliacao))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0124953
    ''' Descrição da entidade:CADASTRO CLAUSULA CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="DatasetClausulaContrato">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarClausulaContrato(ByVal DatasetClausulaContrato As wsAcoesComerciais.DatasetClausulaContrato)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarClausulaContrato(CType(DatasetClausulaContrato.GetChanges(), wsAcoesComerciais.DatasetClausulaContrato))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0124970
    ''' Descrição da entidade:CADASTRO TIPO DE PERIODO
    ''' </summary>
    ''' <param name="DatasetTipoPeriodo">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTipoPeriodo(ByVal DatasetTipoPeriodo As wsAcoesComerciais.DatasetTipoPeriodo)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarTipoPeriodo(CType(DatasetTipoPeriodo.GetChanges(), wsAcoesComerciais.DatasetTipoPeriodo))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0124945
    ''' Descrição da entidade:CADASTRO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="DatasetContrato">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarContrato(ByVal DatasetContrato As wsAcoesComerciais.DatasetContrato)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarContrato(DatasetContrato)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0124996
    ''' Descrição da entidade:RELACAO COM CONTRATO DE FORNECIMENTO E ABRANGENCIA DO MIX
    ''' </summary>
    ''' <param name="DatasetContratoXAbrangenciaMix">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarContratoXAbrangenciaMix(ByVal DatasetContratoXAbrangenciaMix As wsAcoesComerciais.DatasetContratoXAbrangenciaMix)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarContratoXAbrangenciaMix(CType(DatasetContratoXAbrangenciaMix.GetChanges(), wsAcoesComerciais.DatasetContratoXAbrangenciaMix))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0123086
    ''' Descrição da entidade:MOVIMENTO DIARIO CONTA CORRENTE FORNECEDOR
    ''' </summary>
    ''' <param name="DatasetContaCorrenteFornecedor">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarContaCorrenteFornecedor(ByVal DatasetContaCorrenteFornecedor As wsAcoesComerciais.DatasetContaCorrenteFornecedor)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarContaCorrenteFornecedor(CType(DatasetContaCorrenteFornecedor.GetChanges(), wsAcoesComerciais.DatasetContaCorrenteFornecedor))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0123094
    ''' Descrição da entidade:PARAMETRO CONTABIL CONTA CORRENTE FORNECEDOR
    ''' </summary>
    ''' <param name="DatasetParametroContabilContaCorrenteFornecedor">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarParametroContabilContaCorrenteFornecedor(ByVal DatasetParametroContabilContaCorrenteFornecedor As wsAcoesComerciais.DatasetParametroContabilContaCorrenteFornecedor)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarParametroContabilContaCorrenteFornecedor(CType(DatasetParametroContabilContaCorrenteFornecedor.GetChanges(), wsAcoesComerciais.DatasetParametroContabilContaCorrenteFornecedor))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0123108
    ''' Descrição da entidade:CADASTRO TIPO LANCAMENTO CONTA CORRENTE FORNECEDOR
    ''' </summary>
    ''' <param name="DatasetTipoLancamentoContaCorrenteFornecedor">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTipoLancamentoContaCorrenteFornecedor(ByVal DatasetTipoLancamentoContaCorrenteFornecedor As wsAcoesComerciais.DatasetTipoLancamentoContaCorrenteFornecedor)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarTipoLancamentoContaCorrenteFornecedor(DatasetTipoLancamentoContaCorrenteFornecedor)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0113552
    ''' Descrição da entidade:CADASTRO FORMA / DESCONTO BONIFICACAO PEDIDO COMPRA
    ''' </summary>
    ''' <param name="DatasetFormaPagamento">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarFormaPagamento(ByVal DatasetFormaPagamento As wsAcoesComerciais.DatasetFormaPagamento)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarFormaPagamento(CType(DatasetFormaPagamento.GetChanges(), wsAcoesComerciais.DatasetFormaPagamento))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0118902
    ''' Descrição da entidade:MOVIMENTO DIARIO BAIXA ORDEM PAGAMENTO DO FORNECEDOR - COMPRAS
    ''' </summary>
    ''' <param name="DatasetBaixaOPFornecedor">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarBaixaOPFornecedor(ByVal DatasetBaixaOPFornecedor As wsAcoesComerciais.DatasetBaixaOPFornecedor)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarBaixaOPFornecedor(CType(DatasetBaixaOPFornecedor.GetChanges(), wsAcoesComerciais.DatasetBaixaOPFornecedor))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0118899
    ''' Descrição da entidade:MOVIMENTO DIARIO BAIXA DE CHEQUE RECEBIDO DO FORNECEDOR - COMPRAS
    ''' </summary>
    ''' <param name="DatasetBaixaCHFornecedor">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarBaixaCHFornecedor(ByVal DatasetBaixaCHFornecedor As wsAcoesComerciais.DatasetBaixaCHFornecedor)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarBaixaCHFornecedor(CType(DatasetBaixaCHFornecedor.GetChanges(), wsAcoesComerciais.DatasetBaixaCHFornecedor))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0118880
    ''' Descrição da entidade:MOVIMENTO DIARIO ORDEM PAGAMENTO RECEBIDO DO FORNECEDOR - COMPRAS
    ''' </summary>
    ''' <param name="DatasetOPRecebidaFornecedor">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarOPRecebidaFornecedor(ByVal DatasetOPRecebidaFornecedor As wsAcoesComerciais.DatasetOPRecebidaFornecedor)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarOPRecebidaFornecedor(CType(DatasetOPRecebidaFornecedor.GetChanges(), wsAcoesComerciais.DatasetOPRecebidaFornecedor))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0118872
    ''' Descrição da entidade:MOVIMENTO DIARIO CHEQUE RECEBIDO DO FORNECEDOR - COMPRAS
    ''' </summary>
    ''' <param name="DatasetCHRecebidoFornecedor">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarCHRecebidoFornecedor(ByVal DatasetCHRecebidoFornecedor As wsAcoesComerciais.DatasetCHRecebidoFornecedor)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarCHRecebidoFornecedor(CType(DatasetCHRecebidoFornecedor.GetChanges(), wsAcoesComerciais.DatasetCHRecebidoFornecedor))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0118082
    ''' Descrição da entidade:CADASTRO SITUACAO DE ACORDO
    ''' </summary>
    ''' <param name="DatasetSituacaoAcordo">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarSituacaoAcordo(ByVal DatasetSituacaoAcordo As wsAcoesComerciais.DatasetSituacaoAcordo)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarSituacaoAcordo(CType(DatasetSituacaoAcordo.GetChanges(), wsAcoesComerciais.DatasetSituacaoAcordo))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0118074
    ''' Descrição da entidade:PARAMETRO SISTEMA DE GESTAO DE ACAOCOMERCIAL
    ''' </summary>
    ''' <param name="DatasetParametroGestaoAcaoComercial">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarParametroGestaoAcaoComercial(ByVal DatasetParametroGestaoAcaoComercial As wsAcoesComerciais.DatasetParametroGestaoAcaoComercial)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarParametroGestaoAcaoComercial(CType(DatasetParametroGestaoAcaoComercial.GetChanges(), wsAcoesComerciais.DatasetParametroGestaoAcaoComercial))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0118058
    ''' Descrição da entidade:MOVIMENTO DIARIO DE PROMESSA  SISTEMA
    ''' </summary>
    ''' <param name="DatasetAcordo">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function AtualizarAcordo(ByVal DatasetAcordo As wsAcoesComerciais.DatasetAcordo) As Decimal
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.AtualizarAcordo(CType(DatasetAcordo.GetChanges(), wsAcoesComerciais.DatasetAcordo))
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0151799
    ''' Descrição da entidade:CADASTRO DE TIPO DE ALOCACAO DE VERBAS DO FORNECEDOR
    ''' </summary>
    ''' <param name="DatasetTituloPagamentoContrato">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTituloPagamentoContrato(ByVal DatasetTituloPagamentoContrato As wsAcoesComerciais.DatasetTituloPagamentoContrato)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarTituloPagamentoContrato(CType(DatasetTituloPagamentoContrato.GetChanges(), wsAcoesComerciais.DatasetTituloPagamentoContrato))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0129440
    ''' Descrição da entidade:PARAMETRO PRORROGACAO VENCIMENTO TITULO DE PAGAMENTO FORNECEDOR
    ''' </summary>
    ''' <param name="DatasetParametroProrrogacaoVencimento">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarParametroProrrogacaoVencimento(ByVal DatasetParametroProrrogacaoVencimento As wsAcoesComerciais.DatasetParametroProrrogacaoVencimento)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarParametroProrrogacaoVencimento(CType(DatasetParametroProrrogacaoVencimento.GetChanges(), wsAcoesComerciais.DatasetParametroProrrogacaoVencimento))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0144946
    ''' Descrição da entidade:MOVIMENTO TRANSF. VERBAS ENTRE EMPENHOS ACAO COMERCIAL
    ''' </summary>
    ''' <param name="DatasetTransferenciaVerbasEntreEmpenhos">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTransferenciaVerbasEntreEmpenhos(ByVal DatasetTransferenciaVerbasEntreEmpenhos As wsAcoesComerciais.DatasetTransferenciaVerbasEntreEmpenhos)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarTransferenciaVerbasEntreEmpenhos(CType(DatasetTransferenciaVerbasEntreEmpenhos.GetChanges(), wsAcoesComerciais.DatasetTransferenciaVerbasEntreEmpenhos))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0103409
    ''' Descrição da entidade:CADASTRO EMPRESA <COPORATIVO>
    ''' </summary>
    ''' <param name="DatasetEmpresa">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarEmpresa(ByVal DatasetEmpresa As wsAcoesComerciais.DatasetEmpresa)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarEmpresa(CType(DatasetEmpresa.GetChanges(), wsAcoesComerciais.DatasetEmpresa))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0135041
    ''' Descrição da entidade:RELACAO TIPO TRANSF. DE VLRS. DE ACOES COMERCIAIS X DIVISAO DE COMPRAS
    ''' </summary>
    ''' <param name="DatasetTipoTransferenciaXDivisaoCompras">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTipoTransferenciaXDivisaoCompras(ByVal DatasetTipoTransferenciaXDivisaoCompras As wsAcoesComerciais.DatasetTipoTransferenciaXDivisaoCompras)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarTipoTransferenciaXDivisaoCompras(CType(DatasetTipoTransferenciaXDivisaoCompras.GetChanges(), wsAcoesComerciais.DatasetTipoTransferenciaXDivisaoCompras))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0151810
    ''' Descrição da entidade:CADASTRO DA REQUISICAO DE ALOCACAO DE VERBAS DO FORNECEDOR
    ''' </summary>
    ''' <param name="DatasetRequisicaoAlocacaoVerbas">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarRequisicaoAlocacaoVerbas(ByVal DatasetRequisicaoAlocacaoVerbas As wsAcoesComerciais.DatasetRequisicaoAlocacaoVerbas)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarRequisicaoAlocacaoVerbas(CType(DatasetRequisicaoAlocacaoVerbas.GetChanges(), wsAcoesComerciais.DatasetRequisicaoAlocacaoVerbas))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0109059
    ''' Descrição da entidade:CADASTRO DESTINO DESCONTO POR BONIFICACAO PEDIDO COMPRA
    ''' </summary>
    ''' <param name="DatasetEmpenho">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarEmpenho(ByVal DatasetEmpenho As wsAcoesComerciais.DatasetEmpenho)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarEmpenho(CType(DatasetEmpenho.GetChanges(), wsAcoesComerciais.DatasetEmpenho))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0136390
    ''' Descrição da entidade:CADASTRO TIPO OPERACAO DE BAIXA DAS ORDENS DE PAGTO DE FORNECEDORES
    ''' </summary>
    ''' <param name="DatasetTipoOperacaoBaixaOP">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTipoOperacaoBaixaOP(ByVal DatasetTipoOperacaoBaixaOP As wsAcoesComerciais.DatasetTipoOperacaoBaixaOP)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarTipoOperacaoBaixaOP(CType(DatasetTipoOperacaoBaixaOP.GetChanges(), wsAcoesComerciais.DatasetTipoOperacaoBaixaOP))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0135050
    ''' Descrição da entidade:RELACAO TIPO TRANSF. DE VLRS. DE ACOES COMERCIAIS X FORNECEDOR
    ''' </summary>
    ''' <param name="DatasetTipoTransferenciaXFornecedor">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTipoTransferenciaXFornecedor(ByVal DatasetTipoTransferenciaXFornecedor As wsAcoesComerciais.DatasetTipoTransferenciaXFornecedor)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarTipoTransferenciaXFornecedor(CType(DatasetTipoTransferenciaXFornecedor.GetChanges(), wsAcoesComerciais.DatasetTipoTransferenciaXFornecedor))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0135033
    ''' Descrição da entidade:CADASTRO DE TIPO DE TRANSFERENCIA DE VALORES DE ACOES COMERCIAIS
    ''' </summary>
    ''' <param name="DatasetTipoTransferenciaValoresAcoesComerciais">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTipoTransferenciaValoresAcoesComerciais(ByVal DatasetTipoTransferenciaValoresAcoesComerciais As wsAcoesComerciais.DatasetTipoTransferenciaValoresAcoesComerciais)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarTipoTransferenciaValoresAcoesComerciais(CType(DatasetTipoTransferenciaValoresAcoesComerciais.GetChanges(), wsAcoesComerciais.DatasetTipoTransferenciaValoresAcoesComerciais))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0125003
    ''' Descrição da entidade:TIPO BASE CALCULO
    ''' </summary>
    ''' <param name="DatasetTipoBaseCalculo">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTipoBaseCalculo(ByVal DatasetTipoBaseCalculo As wsAcoesComerciais.DatasetTipoBaseCalculo)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarTipoBaseCalculo(CType(DatasetTipoBaseCalculo.GetChanges(), wsAcoesComerciais.DatasetTipoBaseCalculo))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0125011
    ''' Descrição da entidade:CADASTRO TIPO ABRANGENCIA DO MIX
    ''' </summary>
    ''' <param name="DatasetTipoAbrangenciaMix">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTipoAbrangenciaMix(ByVal DatasetTipoAbrangenciaMix As wsAcoesComerciais.DatasetTipoAbrangenciaMix)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarTipoAbrangenciaMix(CType(DatasetTipoAbrangenciaMix.GetChanges(), wsAcoesComerciais.DatasetTipoAbrangenciaMix))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0124988
    ''' Descrição da entidade:RELACAO CONTRADO DE FORNECIMENTO COM PERIODO
    ''' </summary>
    ''' <param name="DatasetContratoXPeriodo">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarContratoXPeriodo(ByVal DatasetContratoXPeriodo As wsAcoesComerciais.DatasetContratoXPeriodo)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarContratoXPeriodo(CType(DatasetContratoXPeriodo.GetChanges(), wsAcoesComerciais.DatasetContratoXPeriodo))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0133243
    ''' Descrição da entidade:MOVIMENTO DIARIO BONIFICACOES EMITIR
    ''' </summary>
    ''' <param name="DatasetBonificacaoEmitir">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarBonificacaoEmitir(ByVal DatasetBonificacaoEmitir As wsAcoesComerciais.DatasetBonificacaoEmitir)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarBonificacaoEmitir(CType(DatasetBonificacaoEmitir.GetChanges(), wsAcoesComerciais.DatasetBonificacaoEmitir))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Recebe os dados processados da tela de recebimentos e envia para ser efetivado as devidas baixas das pendeências
    ''' e Acordos com os recebimentos escolhidos
    ''' </summary>
    ''' <param name="dsAcordo">Dataset com as tabelas preenchidas (tbGrdAcordos e tbGrdCheques)</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''  	[Elifázio Bernardes]	21/8/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub EfetivarBaixaAcaoComercialPendencias(ByRef dsAcordo As wsAcoesComerciais.DatasetAcordo, ByVal Cod_Acesso As String)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.EfetivarBaixaAcaoComercialPendencias(CType(dsAcordo.GetChanges(), wsAcoesComerciais.DatasetAcordo), Cod_Acesso)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0135092
    ''' Descrição da entidade:RELACAO TIPO TRANSF. DE VLRS. DE ACOES COMERCIAIS X USUARIO
    ''' </summary>
    ''' <param name="DatasetTipoTransferenciaXUsuario">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    24/08/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTipoTransferenciaXUsuario(ByVal DatasetTipoTransferenciaXUsuario As wsAcoesComerciais.DatasetTipoTransferenciaXUsuario)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarTipoTransferenciaXUsuario(CType(DatasetTipoTransferenciaXUsuario.GetChanges(), wsAcoesComerciais.DatasetTipoTransferenciaXUsuario))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0118104
    ''' Descrição da entidade:RELACAO TIPO PEDIDO  COMPRA POR TIPO DESTINO DESCONTO BONIFICADO
    ''' </summary>
    ''' <param name="DatasetTipoPedidoCompraXEmpenho">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    11/09/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTipoPedidoCompraXEmpenho(ByVal DatasetTipoPedidoCompraXEmpenho As wsAcoesComerciais.DatasetTipoPedidoCompraXEmpenho)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarTipoPedidoCompraXEmpenho(CType(DatasetTipoPedidoCompraXEmpenho.GetChanges(), wsAcoesComerciais.DatasetTipoPedidoCompraXEmpenho))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0100094
    ''' Descrição da entidade:VALOR MOEDA
    ''' </summary>
    ''' <param name="DatasetValorMoeda">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarValorMoeda(ByVal DatasetValorMoeda As wsAcoesComerciais.DatasetValorMoeda)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarValorMoeda(CType(DatasetValorMoeda.GetChanges(), wsAcoesComerciais.DatasetValorMoeda))
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0101724
    ''' Descrição da entidade:CADASTRO MOEDA
    ''' </summary>
    ''' <param name="DatasetMoeda">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarMoeda(ByVal DatasetMoeda As wsAcoesComerciais.DatasetMoeda)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarMoeda(CType(DatasetMoeda.GetChanges(), wsAcoesComerciais.DatasetMoeda))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0138407
    ''' Descrição da entidade:CADASTRO TIPO FORMA DE PAGAMENTO DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="DatasetTipoFormaPagamento">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTipoFormaPagamento(ByVal DatasetTipoFormaPagamento As wsAcoesComerciais.DatasetTipoFormaPagamento)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarTipoFormaPagamento(CType(DatasetTipoFormaPagamento.GetChanges(), wsAcoesComerciais.DatasetTipoFormaPagamento))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0138415
    ''' Descrição da entidade:CADASTRO TIPO ENCARGO FINANCEIRO DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="DatasetTipoEncargoFinanceiro">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTipoEncargoFinanceiro(ByVal DatasetTipoEncargoFinanceiro As wsAcoesComerciais.DatasetTipoEncargoFinanceiro)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarTipoEncargoFinanceiro(CType(DatasetTipoEncargoFinanceiro.GetChanges(), wsAcoesComerciais.DatasetTipoEncargoFinanceiro))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0138423
    ''' Descrição da entidade:CADASTRO TIPO ABRANGENCIA TABELA DE PRECO DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="DatasetTipoAbrangencia">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTipoAbrangencia(ByVal DatasetTipoAbrangencia As wsAcoesComerciais.DatasetTipoAbrangencia)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarTipoAbrangencia(CType(DatasetTipoAbrangencia.GetChanges(), wsAcoesComerciais.DatasetTipoAbrangencia))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0138431
    ''' Descrição da entidade:CADASTRO TIPO PAGAMENTO NOTA FISCAL DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="DatasetTipoPagamento">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTipoPagamento(ByVal DatasetTipoPagamento As wsAcoesComerciais.DatasetTipoPagamento)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarTipoPagamento(CType(DatasetTipoPagamento.GetChanges(), wsAcoesComerciais.DatasetTipoPagamento))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0138440
    ''' Descrição da entidade:CADASTRO TIPO DE FORNECEDOR DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="DatasetTipoFornecedor">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTipoFornecedor(ByVal DatasetTipoFornecedor As wsAcoesComerciais.DatasetTipoFornecedor)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarTipoFornecedor(CType(DatasetTipoFornecedor.GetChanges(), wsAcoesComerciais.DatasetTipoFornecedor))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0138458
    ''' Descrição da entidade:CADASTRO TIPO UNIDADE DE PAGAMENTO DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="DatasetTipoUnidadePagamento">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTipoUnidadePagamento(ByVal DatasetTipoUnidadePagamento As wsAcoesComerciais.DatasetTipoUnidadePagamento)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarTipoUnidadePagamento(CType(DatasetTipoUnidadePagamento.GetChanges(), wsAcoesComerciais.DatasetTipoUnidadePagamento))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0138466
    ''' Descrição da entidade:CADASTRO TIPO DE SERVICO DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="DatasetTipoServico">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTipoServico(ByVal DatasetTipoServico As wsAcoesComerciais.DatasetTipoServico)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarTipoServico(CType(DatasetTipoServico.GetChanges(), wsAcoesComerciais.DatasetTipoServico))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0138474
    ''' Descrição da entidade:CADASTRO TIPO DE RELACIONAMENTO DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="DatasetTipoRelacionamento">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTipoRelacionamento(ByVal DatasetTipoRelacionamento As wsAcoesComerciais.DatasetTipoRelacionamento)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarTipoRelacionamento(CType(DatasetTipoRelacionamento.GetChanges(), wsAcoesComerciais.DatasetTipoRelacionamento))
    End Sub

    Public Shared Sub AtualizarParametroNegociacaoFornecedor(ByRef ds As wsAcoesComerciais.dataSetParametro)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarParametroNegociacaoFornecedor(ds)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Atualiza os dados no banco 
    ''' </summary>
    ''' <param name="ds">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Elifázio Bernardes]    31/10/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarContratoXClausulaContrato(ByVal ds As wsAcoesComerciais.DatasetContrato)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarContratoXClausulaContrato(ds)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0153589
    ''' Descrição da entidade:RELACAO CONTRATO FORNECIMENTO X RELACAO ABATIMENTO PERDA
    ''' </summary>
    ''' <param name="DatasetContratoFornecimentoXAbatimentoPerda">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    15/11/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarContratoFornecimentoXAbatimentoPerda(ByVal DatasetContratoFornecimentoXAbatimentoPerda As wsAcoesComerciais.DatasetContratoFornecimentoXAbatimentoPerda)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarContratoFornecimentoXAbatimentoPerda(CType(DatasetContratoFornecimentoXAbatimentoPerda.GetChanges(), wsAcoesComerciais.DatasetContratoFornecimentoXAbatimentoPerda))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0153031
    ''' Descrição da entidade:RELACAO PROMESSA X MENSAGEM
    ''' </summary>
    ''' <param name="DatasetAcordoXMensagem">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    15/11/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarAcordoXMensagem(ByVal DatasetAcordoXMensagem As wsAcoesComerciais.DatasetAcordoXMensagem)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarAcordoXMensagem(CType(DatasetAcordoXMensagem.GetChanges(), wsAcoesComerciais.DatasetAcordoXMensagem))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0152663
    ''' Descrição da entidade:RELACAO DE BONIFICACAO E DUPLICATA A EMITIR
    ''' </summary>
    ''' <param name="DatasetBonificacaoDuplicataEmitir">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    15/11/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarBonificacaoDuplicataEmitir(ByVal DatasetBonificacaoDuplicataEmitir As wsAcoesComerciais.DatasetBonificacaoDuplicataEmitir)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarBonificacaoDuplicataEmitir(CType(DatasetBonificacaoDuplicataEmitir.GetChanges(), wsAcoesComerciais.DatasetBonificacaoDuplicataEmitir))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0152647
    ''' Descrição da entidade:RELACAO PERDAS EMITIDAS
    ''' </summary>
    ''' <param name="DatasetPerdaEmitida">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    15/11/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarPerdaEmitida(ByVal DatasetPerdaEmitida As wsAcoesComerciais.DatasetPerdaEmitida)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarPerdaEmitida(CType(DatasetPerdaEmitida.GetChanges(), wsAcoesComerciais.DatasetPerdaEmitida))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Atualiza os dados no banco de todas as tabelas que envolve a criação do contrato
    ''' </summary>
    ''' <param name="ds">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Elifázio Bernardes]    28/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarContratoTabelas(ByVal ds As wsAcoesComerciais.DatasetContrato)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarContratoTabelas(CType(ds.GetChanges(), wsAcoesComerciais.DatasetContrato))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0125046
    ''' Descrição da entidade:HISTORICO MENSAL AVALIACAO DO CONTRATO DE FORNECIMENTO
    ''' </summary>
    ''' <param name="DatasetEntidade">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    02/01/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarEntidade(ByVal DatasetEntidade As wsAcoesComerciais.DatasetEntidade)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarEntidade(CType(DatasetEntidade.GetChanges(), wsAcoesComerciais.DatasetEntidade))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Atualiza os dados no banco 
    ''' </summary>
    ''' <param name="DatasetParametroFornecedorMmm">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    15/02/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    '<MartinsSecurity(5, -1)> _
    Public Shared Sub AtualizarParametroFornecedorMmm(ByVal DatasetParametroFornecedorMmm As wsAcoesComerciais.DatasetParametroFornecedorMmm)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarParametroFornecedorMmm(CType(DatasetParametroFornecedorMmm.GetChanges(), wsAcoesComerciais.DatasetParametroFornecedorMmm))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Atualiza os relacionamento de abrangencia e Filiado a partir de um
    ''' arquivo CSV
    ''' </summary>
    ''' <param name="NUMCTTFRN"></param>
    ''' <param name="NUMCSLCTTFRN"></param>
    ''' <param name="TIPEDEABGMIX"></param>
    ''' <param name="CODEDEABGMIX"></param>
    ''' <param name="caminhoArquivoCSV"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	23/2/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarAbrangenciaXContratoXFiliadoDeArquivoCSV(ByVal NUMCTTFRN As Decimal, ByVal NUMCSLCTTFRN As Decimal, ByVal TIPEDEABGMIX As Decimal, ByVal CODEDEABGMIX As Decimal, ByVal caminhoArquivoCSV As String)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarAbrangenciaXContratoXFiliadoDeArquivoCSV(NUMCTTFRN, NUMCSLCTTFRN, TIPEDEABGMIX, CODEDEABGMIX, caminhoArquivoCSV)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade RLCABGCTTFIL
    ''' Descrição da entidade:RELACAO ABRANGENCIA X CONTRATO  X FILIADO
    ''' </summary>
    ''' <param name="DatasetAbrangenciaXContratoXFiliado">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    23/02/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarAbrangenciaXContratoXFiliado(ByVal DatasetContrato As wsAcoesComerciais.DatasetContrato)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.AtualizarAbrangenciaXContratoXFiliado(CType(DatasetContrato.GetChanges(), wsAcoesComerciais.DatasetContrato))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0144920
    ''' Descrição da entidade:RELACAO USUARIO X CELULA
    ''' </summary>
    ''' <param name="DatasetUsuarioXCelula">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    26/02/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarUsuarioXCelula(ByVal DatasetUsuarioXCelula As wsAcoesComerciais.DatasetUsuarioXCelula)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.AtualizarUsuarioXCelula(CType(DatasetUsuarioXCelula.GetChanges(), wsAcoesComerciais.DatasetUsuarioXCelula))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade CADTRNVBAFRN
    ''' Descrição da entidade:CADASTRO DE TRANSFERENCIA VERBAS FORNECEDOR
    ''' </summary>
    ''' <param name="DatasetTransferenciaVerbaFornecedor">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    27/11/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTransferenciaVerbaFornecedor(ByVal DatasetTransferenciaVerbaFornecedor As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.AtualizarTransferenciaVerbaFornecedor(CType(DatasetTransferenciaVerbaFornecedor.GetChanges(), wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade RLCTRNVBAFRN
    ''' Descrição da entidade:RELACAO DE TRANSFERENCIA VERBAS FORNECEDOR
    ''' </summary>
    ''' <param name="DatasetTransferenciaVerbaFornecedor">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    27/11/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarRelacaoTransferenciaVerbaFornecedor(ByVal DatasetTransferenciaVerbaFornecedor As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.AtualizarRelacaoTransferenciaVerbaFornecedor(CType(DatasetTransferenciaVerbaFornecedor.GetChanges(), wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade HSTAVLCTTFRNCLI
    ''' Descrição da entidade:HISTORICO AVALIAÇÃO CONTRATO FORNECIMENTO POR CLIENTE SMART
    ''' </summary>
    ''' <param name="DatasetHistoricoAvalicaoContratoPorClienteSmart">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' Caso ocorra algum problema, a transação é abortada e uma Exception é disparada
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    12/07/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarHistoricoAvalicaoContratoPorClienteSmart(ByVal DatasetHistoricoAvalicaoContratoPorClienteSmart As wsAcoesComerciais.DatasetHistoricoAvalicaoContratoPorClienteSmart)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarHistoricoAvalicaoContratoPorClienteSmart(CType(DatasetHistoricoAvalicaoContratoPorClienteSmart.GetChanges(), wsAcoesComerciais.DatasetHistoricoAvalicaoContratoPorClienteSmart))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0161591
    ''' Descrição da entidade:FLUXO DE APROVAÇÃO
    ''' </summary>
    ''' <param name="DatasetFluxoAprovacao">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    06/12/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarFluxoAprovacao(ByVal DatasetFluxoAprovacao As wsAcoesComerciais.DatasetFluxoAprovacao)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.AtualizarFluxoAprovacao(CType(DatasetFluxoAprovacao.GetChanges(), wsAcoesComerciais.DatasetFluxoAprovacao))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NOMACSUSRSIS"></param>
    ''' <param name="TIPUSRSIS"></param>
    ''' <param name="dsTransferenciaVerbaFornecedor"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	16/1/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTransferencia(ByVal NOMACSUSRSIS As String, _
                                             ByVal TIPUSRSIS As String, _
                                             ByVal dsTransferenciaVerbaFornecedor As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.AtualizarTransferencia(NOMACSUSRSIS, TIPUSRSIS, dsTransferenciaVerbaFornecedor)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0154038
    ''' Descrição da entidade:FLUXO CANCELAMENTO ACORDO
    ''' </summary>
    ''' <param name="DatasetFluxoCancelamentoAcordo">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    23/04/2008  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarFluxoCancelamentoAcordo(ByVal DatasetFluxoCancelamentoAcordo As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo)
        Dim webService As New wsFluxoDeCancelamentoDeAcordos.FluxoDeCancelamentoDeAcordos
        AssinadorWebServices.AssinarWebService(webService)
        webService.AtualizarFluxoCancelamentoAcordo(CType(DatasetFluxoCancelamentoAcordo.GetChanges(), wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia os dados atualizados para o Web Service
    ''' Entidade T0154021
    ''' Descrição da entidade:ACORDO A CANCELAR EM FLUXO CANCELAMENTO ACORDO
    ''' </summary>
    ''' <param name="DatasetAcordoACancelarEmFluxoCancelamentoAcordo">DataSet com os dados a serem atualizados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    23/04/2008  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarAcordoACancelarEmFluxoCancelamentoAcordo(ByVal DatasetFluxoCancelamentoAcordo As wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo)
        Dim webService As New wsFluxoDeCancelamentoDeAcordos.FluxoDeCancelamentoDeAcordos
        AssinadorWebServices.AssinarWebService(webService)
        webService.AtualizarAcordoACancelarEmFluxoCancelamentoAcordo(CType(DatasetFluxoCancelamentoAcordo.GetChanges(), wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="DatasetTipoGrupoMarketing"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	31/3/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarTipoGrupoMarketing(ByVal DatasetTipoGrupoMarketing As wsAcoesComerciais.DatasetTipoGrupoMarketing)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarTipoGrupoMarketing(CType(DatasetTipoGrupoMarketing.GetChanges(), wsAcoesComerciais.DatasetTipoGrupoMarketing))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	31/3/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterNovaChaveTipoGrupoMarketing() As Decimal
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterNovaChaveTipoGrupoMarketing()
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="DatasetTipoGrupoMarketing"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	9/4/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarRelacaoIncentivoFornecedor(ByVal DatasetIncentivo As wsAcoesComerciais.DatasetIncentivo)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarRelacaoIncentivoFornecedor(CType(DatasetIncentivo.GetChanges(), wsAcoesComerciais.DatasetIncentivo))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="DatasetTipoGrupoMarketing"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	13/4/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarRelacaoGrupoMarketing(ByVal DatasetTipoGrupoMarketing As wsAcoesComerciais.DatasetTipoGrupoMarketing)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarRelacaoGrupoMarketing(CType(DatasetTipoGrupoMarketing.GetChanges(), wsAcoesComerciais.DatasetTipoGrupoMarketing))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="DatasetMarketinExtraAcordo"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	15/5/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarMarketingExtraAcordo(ByVal DatasetMarketinExtraAcordo As wsAcoesComerciais.DatasetMarketinExtraAcordo)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarMarketingExtraAcordo(CType(DatasetMarketinExtraAcordo.GetChanges(), wsAcoesComerciais.DatasetMarketinExtraAcordo))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="DatasetContrato"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	7/8/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarAditamento(ByVal DatasetContrato As wsAcoesComerciais.DatasetContrato)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarAditamento(CType(DatasetContrato.GetChanges(), wsAcoesComerciais.DatasetContrato))
    End Sub


#Region " Metodos com Stored Procedures "

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chamada para procedure: MRT.PCTDLGrcCslTms.PRCDLGrcCslTms
    ''' </summary>
    ''' <param name="pvNumCttFrn"></param>
    ''' <remarks>
    ''' Chamada para procedure: MRT.PCTDLGrcCslTms.PRCDLGrcCslTms
    ''' LEGADO: CLJ001
    ''' </remarks>
    ''' <history>
    '''     [Elifázio Bernardes]    20/11/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function GerarClausulaTrimestralidade(ByVal pvNumCttFrn As Decimal) As Boolean
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.GerarClausulaTrimestralidade(pvNumCttFrn)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chamada para procedure: MRT.PCTDLGrcCslAno.PRCDLGrcCslAno
    ''' </summary>
    ''' <param name="pvNumCttFrn"></param>
    ''' <remarks>
    ''' Chamada para procedure: MRT.PCTDLGrcCslAno.PRCDLGrcCslAno
    ''' LEGADO: CLJ001
    ''' </remarks>
    ''' <history>
    '''     [Elifázio Bernardes]    20/11/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function GerarClausulaAnualidade(ByVal pvNumCttFrn As Decimal) As Boolean
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.GerarClausulaAnualidade(pvNumCttFrn)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chamada para procedure: MRT.PCTDJAtlCntCrrFrn.PRCDJAtlCntCrrFrn
    ''' </summary>
    ''' <param name="pvDatRefLmt"></param>
    ''' <param name="pvTipDsnDscBnf"></param>
    ''' <param name="pvCodFrn"></param>
    ''' <param name="pvCodGdc"></param>
    ''' <param name="pvCodTipLmtPmt"></param>
    ''' <param name="pvCodCntCrd"></param>
    ''' <param name="pvCodCenCstCrd"></param>
    ''' <param name="pvCodCntDeb"></param>
    ''' <param name="pvCodCenCstDeb"></param>
    ''' <param name="pvVlrLmtCtb"></param>
    ''' <param name="pvDesHstLmt"></param>
    ''' <param name="pvDesVarHstPad"></param>
    ''' <param name="pvNomAcsUsrGrcLmt"></param>
    ''' <param name="pvCodFilEmp"></param>
    ''' <param name="pvCodPms"></param>
    ''' <param name="pvFlgRetVlr"></param>
    ''' <param name="pvTipAlcVbaFrnPmt"></param>
    ''' <param name="pvTransfIntegral"></param>
    ''' <remarks>
    ''' Chamada para procedure: MRT.PCTDJAtlCntCrrFrn.PRCDJAtlCntCrrFrn
    ''' LEGADO: CCX001GA
    ''' </remarks>
    ''' <history>
    '''     [Elifázio Bernardes]    21/11/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarContaCorrenteFornecedor(ByVal pvDatRefLmt As Date, _
                                                       ByVal pvTipDsnDscBnf As Decimal, _
                                                       ByVal pvCodFrn As Decimal, _
                                                       ByVal pvCodGdc As String, _
                                                       ByVal pvCodTipLmtPmt As Integer, _
                                                       ByVal pvCodCntCrd As String, _
                                                       ByVal pvCodCenCstCrd As String, _
                                                       ByVal pvCodCntDeb As String, _
                                                       ByVal pvCodCenCstDeb As String, _
                                                       ByVal pvVlrLmtCtb As Decimal, _
                                                       ByVal pvDesHstLmt As String, _
                                                       ByVal pvDesVarHstPad As String, _
                                                       ByVal pvNomAcsUsrGrcLmt As String, _
                                                       ByVal pvCodFilEmp As Decimal, _
                                                       ByVal pvCodPms As Decimal, _
                                                       ByVal pvFlgRetVlr As String, _
                                                       ByVal pvTipAlcVbaFrnPmt As Integer, _
                                                       ByVal pvTransfIntegral As Integer)

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        webService.AtualizarContaCorrenteFornecedor2( _
                                pvDatRefLmt, _
                                pvTipDsnDscBnf, _
                                pvCodFrn, _
                                pvCodGdc, _
                                pvCodTipLmtPmt, _
                                pvCodCntCrd, _
                                pvCodCenCstCrd, _
                                pvCodCntDeb, _
                                pvCodCenCstDeb, _
                                pvVlrLmtCtb, _
                                pvDesHstLmt, _
                                pvDesVarHstPad, _
                                pvNomAcsUsrGrcLmt, _
                                pvCodFilEmp, _
                                pvCodPms, _
                                pvFlgRetVlr, _
                                pvTipAlcVbaFrnPmt, _
                                pvTransfIntegral)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chamada para procedure: MRT.PCTDLIsrVlrApuCttVldFrn.PRCDLIsrVlrApuCttVldFrn
    ''' </summary>
    ''' <param name="pvNUMCTTFRN"></param>
    ''' <param name="pvNUMCSLCTTFRN"></param>
    ''' <param name="pvTIPPODCTTFRN"></param>
    ''' <param name="pvNUMREFPOD"></param>
    ''' <param name="pvTIPEDEABGMIX"></param>
    ''' <param name="pvCODEDEABGMIX"></param>
    ''' <param name="pvDATREFAPU"></param>
    ''' <param name="pvTIPFRMDSCBNF"></param>
    ''' <param name="pvTIPDSNDSCBNF"></param>
    ''' <param name="pvCODFRN"></param>
    ''' <param name="pvNUMCTTFRNORI"></param>
    ''' <param name="pvNUMCSLCTTFRNORI"></param>
    ''' <param name="pvTIPPODCTTFRNORI"></param>
    ''' <param name="pvNUMREFPODORI"></param>
    ''' <param name="pvTIPEDEABGMIXORI"></param>
    ''' <param name="pvCODEDEABGMIXORI"></param>
    ''' <param name="pvDATREFAPUORI"></param>
    ''' <param name="pvVLRCRDUTZCTTFRN"></param>
    ''' <param name="pvNUMSEQRLCCTTPMS"></param>
    ''' <param name="pvTIPFRMDSCBNFORIPDA"></param>
    ''' <param name="pvTIPDSNDSCBNFORIPDA"></param>
    ''' <remarks>
    ''' Chamada para procedure: MRT.PCTDLIsrVlrApuCttVldFrn.PRCDLIsrVlrApuCttVldFrn
    ''' LEGADO:SPCLJ153
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/12/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub InsereVaresApuradosContratoValido(ByVal pvNUMCTTFRN As Decimal, _
                                                        ByVal pvNUMCSLCTTFRN As Decimal, _
                                                        ByVal pvTIPPODCTTFRN As Decimal, _
                                                        ByVal pvNUMREFPOD As Decimal, _
                                                        ByVal pvTIPEDEABGMIX As Decimal, _
                                                        ByVal pvCODEDEABGMIX As Decimal, _
                                                        ByVal pvDATREFAPU As Date, _
                                                        ByVal pvTIPFRMDSCBNF As Decimal, _
                                                        ByVal pvTIPDSNDSCBNF As Decimal, _
                                                        ByVal pvCODFRN As Decimal, _
                                                        ByVal pvNUMCTTFRNORI As Decimal, _
                                                        ByVal pvNUMCSLCTTFRNORI As Integer, _
                                                        ByVal pvTIPPODCTTFRNORI As Integer, _
                                                        ByVal pvNUMREFPODORI As Integer, _
                                                        ByVal pvTIPEDEABGMIXORI As Integer, _
                                                        ByVal pvCODEDEABGMIXORI As Decimal, _
                                                        ByVal pvDATREFAPUORI As Date, _
                                                        ByVal pvVLRCRDUTZCTTFRN As Decimal, _
                                                        ByVal pvNUMSEQRLCCTTPMS As Integer, _
                                                        ByVal pvTIPFRMDSCBNFORIPDA As Integer, _
                                                        ByVal pvTIPDSNDSCBNFORIPDA As Integer)

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        webService.InsereVaresApuradosContratoValido(pvNUMCTTFRN, _
                                                     pvNUMCSLCTTFRN, _
                                                     pvTIPPODCTTFRN, _
                                                     pvNUMREFPOD, _
                                                     pvTIPEDEABGMIX, _
                                                     pvCODEDEABGMIX, _
                                                     pvDATREFAPU, _
                                                     pvTIPFRMDSCBNF, _
                                                     pvTIPDSNDSCBNF, _
                                                     pvCODFRN, _
                                                     pvNUMCTTFRNORI, _
                                                     pvNUMCSLCTTFRNORI, _
                                                     pvTIPPODCTTFRNORI, _
                                                     pvNUMREFPODORI, _
                                                     pvTIPEDEABGMIXORI, _
                                                     pvCODEDEABGMIXORI, _
                                                     pvDATREFAPUORI, _
                                                     pvVLRCRDUTZCTTFRN, _
                                                     pvNUMSEQRLCCTTPMS, _
                                                     pvTIPFRMDSCBNFORIPDA, _
                                                     pvTIPDSNDSCBNFORIPDA)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chamada para procedure: MRT.PCTDLIsrArdAbtRelPdaCtt.PRCDLIsrArdAbtRelPdaCtt
    ''' </summary>
    ''' <param name="pvNUMCTTFRN"></param>
    ''' <param name="pvNUMCSLCTTFRN"></param>
    ''' <param name="pvTIPPODCTTFRN"></param>
    ''' <param name="pvNUMREFPOD"></param>
    ''' <param name="pvTIPEDEABGMIX"></param>
    ''' <param name="pvCODEDEABGMIXPAR"></param>
    ''' <param name="pvDATREFAPU"></param>
    ''' <param name="pvTIPFRMDSCBNF"></param>
    ''' <param name="pvTIPDSNDSCBNF"></param>
    ''' <param name="pvCODFRN"></param>
    ''' <param name="pvCODEMPORI"></param>
    ''' <param name="pvCODFILEMPORI"></param>
    ''' <param name="pvCODPMSORI"></param>
    ''' <param name="pvDATNGCPMSORI"></param>
    ''' <param name="pvDATPRVRCBPMSORI"></param>
    ''' <param name="pvTipFrmDscBnfOri"></param>
    ''' <param name="pvTipDsnDscBnfOri"></param>
    ''' <param name="pvVLRCRDUTZCTTFRN"></param>
    ''' <param name="pvDESOBSPMSPAR"></param>
    ''' <param name="pvNOMUSRSIS"></param>
    ''' <param name="pvNUMSEQRLCCTTPMS"></param>
    ''' <param name="pvTIPOBSPMS"></param>
    ''' <remarks>
    ''' Chamada para procedure: MRT.PCTDLIsrArdAbtRelPdaCtt.PRCDLIsrArdAbtRelPdaCtt
    ''' LEGADO:SPCLJ154
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/12/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub InserePromessasEmAbertoDeAcordoEmpenho(ByVal pvNUMCTTFRN As Decimal, _
                                                             ByVal pvNUMCSLCTTFRN As Decimal, _
                                                             ByVal pvTIPPODCTTFRN As Decimal, _
                                                             ByVal pvNUMREFPOD As Decimal, _
                                                             ByVal pvTIPEDEABGMIX As Decimal, _
                                                             ByVal pvCODEDEABGMIXPAR As Decimal, _
                                                             ByVal pvDATREFAPU As Date, _
                                                             ByVal pvTIPFRMDSCBNF As Decimal, _
                                                             ByVal pvTIPDSNDSCBNF As Decimal, _
                                                             ByVal pvCODFRN As Decimal, _
                                                             ByVal pvCODEMPORI As Decimal, _
                                                             ByVal pvCODFILEMPORI As Decimal, _
                                                             ByVal pvCODPMSORI As Decimal, _
                                                             ByVal pvDATNGCPMSORI As Date, _
                                                             ByVal pvDATPRVRCBPMSORI As Date, _
                                                             ByVal pvTipFrmDscBnfOri As Decimal, _
                                                             ByVal pvTipDsnDscBnfOri As Decimal, _
                                                             ByVal pvVLRCRDUTZCTTFRN As Decimal, _
                                                             ByVal pvDESOBSPMSPAR As String, _
                                                             ByVal pvNOMUSRSIS As String, _
                                                             ByVal pvNUMSEQRLCCTTPMS As Integer, _
                                                             ByVal pvTIPOBSPMS As String)

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        webService.InserePromessasEmAbertoDeAcordoEmpenho(pvNUMCTTFRN, _
                                                          pvNUMCSLCTTFRN, _
                                                          pvTIPPODCTTFRN, _
                                                          pvNUMREFPOD, _
                                                          pvTIPEDEABGMIX, _
                                                          pvCODEDEABGMIXPAR, _
                                                          pvDATREFAPU, _
                                                          pvTIPFRMDSCBNF, _
                                                          pvTIPDSNDSCBNF, _
                                                          pvCODFRN, _
                                                          pvCODEMPORI, _
                                                          pvCODFILEMPORI, _
                                                          pvCODPMSORI, _
                                                          pvDATNGCPMSORI, _
                                                          pvDATPRVRCBPMSORI, _
                                                          pvTipFrmDscBnfOri, _
                                                          pvTipDsnDscBnfOri, _
                                                          pvVLRCRDUTZCTTFRN, _
                                                          pvDESOBSPMSPAR, _
                                                          pvNOMUSRSIS, _
                                                          pvNUMSEQRLCCTTPMS, _
                                                          pvTIPOBSPMS)

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chamada para procedure: MRT.PCTDLCncPdaDis.PRCDLCncPdaDis
    ''' </summary>
    ''' <param name="pvTIPOPE"></param>
    ''' <param name="pvNUMCTTFRN"></param>
    ''' <param name="pvNUMCSLCTTFRN"></param>
    ''' <param name="pvTIPPODCTTFRN"></param>
    ''' <param name="pvNUMREFPOD"></param>
    ''' <param name="pvTIPEDEABGMIX"></param>
    ''' <param name="pvCODEDEABGMIX"></param>
    ''' <param name="pvDATREFAPU"></param>
    ''' <param name="pvVLRPDACNC"></param>
    ''' <remarks>
    ''' Chamada para procedure: MRT.PCTDLCncPdaDis.PRCDLCncPdaDis
    ''' LEGADO:SPCLJ157
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/12/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub CancelarPerdasDisponiveis(ByVal pvTIPOPE As Integer, _
                                                ByVal pvNUMCTTFRN As Decimal, _
                                                ByVal pvNUMCSLCTTFRN As Decimal, _
                                                ByVal pvTIPPODCTTFRN As Decimal, _
                                                ByVal pvNUMREFPOD As Decimal, _
                                                ByVal pvTIPEDEABGMIX As Decimal, _
                                                ByVal pvCODEDEABGMIX As Decimal, _
                                                ByVal pvDATREFAPU As Date, _
                                                ByVal pvVLRPDACNC As Decimal)

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Timeout = 300000
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials

        webService.CancelarPerdasDisponiveis(pvTIPOPE, _
                                             pvNUMCTTFRN, _
                                             pvNUMCSLCTTFRN, _
                                             pvTIPPODCTTFRN, _
                                             pvNUMREFPOD, _
                                             pvTIPEDEABGMIX, _
                                             pvCODEDEABGMIX, _
                                             pvDATREFAPU, _
                                             pvVLRPDACNC)

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chamada para procedure: MRT.PCTDLGrvObsRlcPdaArdFrn.PRCDLGrvObsRlcPdaArdFrn
    ''' </summary>
    ''' <param name="pvTIPOPE"></param>
    ''' <param name="pvNUMCTTFRN"></param>
    ''' <param name="pvNUMCSLCTTFRN"></param>
    ''' <param name="pvTIPPODCTTFRN"></param>
    ''' <param name="pvNUMREFPOD"></param>
    ''' <param name="pvTIPEDEABGMIX"></param>
    ''' <param name="pvCODEDEABGMIXPAR"></param>
    ''' <param name="pvDATREFAPU"></param>
    ''' <param name="pvNUMSEQRLCCTTPMS"></param>
    ''' <param name="pvCODFRN"></param>
    ''' <param name="pvDESOBSCTTFRNAUX"></param>
    ''' <param name="pvTIPCNCPDACTTFRN"></param>
    ''' <param name="pvVLRCRDDISCTTFRN"></param>
    ''' <param name="pvTIPFRMDSCBNF"></param>
    ''' <param name="pvTIPDSNDSCBNF"></param>
    ''' <param name="pvNOMUSRSIS"></param>
    ''' <param name="pvDATGRCOBSPMS"></param>
    ''' <remarks>
    ''' Chamada para procedure: MRT.PCTDLGrvObsRlcPdaArdFrn.PRCDLGrvObsRlcPdaArdFrn
    ''' LEGADO:SPCLJ158
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    13/12/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function GravarObservacaoPerdaAcordo(ByVal pvTIPOPE As Integer, _
                                                       ByVal pvNUMCTTFRN As Decimal, _
                                                       ByVal pvNUMCSLCTTFRN As Decimal, _
                                                       ByVal pvTIPPODCTTFRN As Decimal, _
                                                       ByVal pvNUMREFPOD As Decimal, _
                                                       ByVal pvTIPEDEABGMIX As Decimal, _
                                                       ByVal pvCODEDEABGMIXPAR As Decimal, _
                                                       ByVal pvDATREFAPU As Date, _
                                                       ByVal pvNUMSEQRLCCTTPMS As Decimal, _
                                                       ByVal pvCODFRN As Decimal, _
                                                       ByVal pvDESOBSCTTFRNAUX As String, _
                                                       ByVal pvTIPCNCPDACTTFRN As String, _
                                                       ByVal pvVLRCRDDISCTTFRN As Decimal, _
                                                       ByVal pvTIPFRMDSCBNF As Decimal, _
                                                       ByVal pvTIPDSNDSCBNF As Decimal, _
                                                       ByVal pvNOMUSRSIS As String, _
                                                       ByVal pvDATGRCOBSPMS As Date) As wsAcoesComerciais.DatasetAcordo

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.GravarObservacaoPerdaAcordo(pvTIPOPE, _
                                                      pvNUMCTTFRN, _
                                                      pvNUMCSLCTTFRN, _
                                                      pvTIPPODCTTFRN, _
                                                      pvNUMREFPOD, _
                                                      pvTIPEDEABGMIX, _
                                                      pvCODEDEABGMIXPAR, _
                                                      pvDATREFAPU, _
                                                      pvNUMSEQRLCCTTPMS, _
                                                      pvCODFRN, _
                                                      pvDESOBSCTTFRNAUX, _
                                                      pvTIPCNCPDACTTFRN, _
                                                      pvVLRCRDDISCTTFRN, _
                                                      pvTIPFRMDSCBNF, _
                                                      pvTIPDSNDSCBNF, _
                                                      pvNOMUSRSIS, _
                                                      pvDATGRCOBSPMS)

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Realiza transferencia entre dos fornecedores e/ou empenho
    ''' </summary>
    ''' <param name="pValor"></param>
    ''' <param name="pTipAlcVbaFrn"></param>
    ''' <param name="pvDatRefLmt"></param>
    ''' <param name="pvTipDsnDscBnfOrigem"></param>
    ''' <param name="pvTipDsnDscBnfDestino"></param>
    ''' <param name="pvCodFrnOrigem"></param>
    ''' <param name="pvCodFrnDestino"></param>
    ''' <param name="pvVlrLmtCtb"></param>
    ''' <param name="pvDesHstLmt"></param>
    ''' <param name="pvDesVarHstPadOrigem"></param>
    ''' <param name="pvDesVarHstPadDestino"></param>
    ''' <param name="pvNomAcsUsrGrcLmt"></param>
    ''' <param name="pvTipAlcVbaFrnPmtOrigem"></param>
    ''' <param name="pvTipAlcVbaFrnPmtDestino"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	29/12/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub TransferirValoreEntreEmpenhosFornecedorGAC(ByVal pValor As Decimal, _
                                                ByVal pTipAlcVbaFrn As Integer, _
                                                ByVal pvDatRefLmt As Date, _
                                                ByVal pvTipDsnDscBnfOrigem As Decimal, _
                                                ByVal pvTipDsnDscBnfDestino As Decimal, _
                                                ByVal pvCodFrnOrigem As Decimal, _
                                                ByVal pvCodFrnDestino As Decimal, _
                                                ByVal pvVlrLmtCtb As Decimal, _
                                                ByVal pvDesHstLmt As String, _
                                                ByVal pvDesVarHstPadOrigem As String, _
                                                ByVal pvDesVarHstPadDestino As String, _
                                                ByVal pvNomAcsUsrGrcLmt As String, _
                                                ByVal pvTipAlcVbaFrnPmtOrigem As Integer, _
                                                ByVal pvTipAlcVbaFrnPmtDestino As Integer)

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Timeout = 300000
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials

        Util.gravaInformacaoEventView("Controller iniciou processo de transferência (chamada Web.Service). Parametros:" & _
                                      "pValor:" & pValor & vbCrLf & _
                                      "pTipAlcVbaFrn:" & pTipAlcVbaFrn & vbCrLf & _
                                      "pvDatRefLmt:" & pvDatRefLmt & vbCrLf & _
                                      "pvTipDsnDscBnfOrigem:" & pvTipDsnDscBnfOrigem & vbCrLf & _
                                      "pvTipDsnDscBnfDestino:" & pvTipDsnDscBnfDestino & vbCrLf & _
                                      "pvCodFrnOrigem:" & pvCodFrnOrigem & vbCrLf & _
                                      "pvCodFrnDestino:" & pvCodFrnDestino & vbCrLf & _
                                      "pvVlrLmtCtb:" & pvVlrLmtCtb & vbCrLf & _
                                      "pvDesHstLmt:" & pvDesHstLmt & vbCrLf & _
                                      "pvDesVarHstPadOrigem:" & pvDesVarHstPadOrigem & vbCrLf & _
                                      "pvDesVarHstPadDestino:" & pvDesVarHstPadDestino & vbCrLf & _
                                      "pvNomAcsUsrGrcLmt:" & pvNomAcsUsrGrcLmt & vbCrLf & _
                                      "pvTipAlcVbaFrnPmtOrigem:" & pvTipAlcVbaFrnPmtOrigem & vbCrLf & _
                                      "pvTipAlcVbaFrnPmtDestino:" & pvTipAlcVbaFrnPmtDestino)

        webService.TransferirValoresEntreEmpenhosFornecedor(pValor, _
                                             pTipAlcVbaFrn, _
                                             pvDatRefLmt, _
                                             pvTipDsnDscBnfOrigem, _
                                             pvTipDsnDscBnfDestino, _
                                             pvCodFrnOrigem, _
                                             pvCodFrnDestino, _
                                             pvVlrLmtCtb, _
                                             pvDesHstLmt, _
                                             pvDesVarHstPadOrigem, _
                                             pvDesVarHstPadDestino, _
                                             pvNomAcsUsrGrcLmt, _
                                             pvTipAlcVbaFrnPmtOrigem, _
                                             pvTipAlcVbaFrnPmtDestino)

        Util.gravaInformacaoEventView("Controller concluiu processo de transferência (chamada Web.Service)")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chamada para procedure: MRT.PctDLApuArdGrlFrn.PrcDLApuArdGrlFrn
    ''' </summary>
    ''' <param name="ppin_NumCttFrn"></param>
    ''' <param name="ppin_Clausula"></param>
    ''' <param name="ppid_DatApuracao"></param>
    ''' <param name="ppin_Periodo"></param>
    ''' <param name="ppin_ApuraTudo"></param>
    ''' <param name="ppin_Fornecedores"></param>
    ''' <param name="ppin_Categoria"></param>
    ''' <param name="ppin_Item"></param>
    ''' <param name="ppin_ItensNovos"></param>
    ''' <param name="ppid_DatEmsNotFsc"></param>
    ''' <param name="ppid_DatLibIni"></param>
    ''' <param name="ppid_DatLibFim"></param>
    ''' <remarks>
    ''' Chamada para procedure: MRT.PctDLApuArdGrlFrn.PrcDLApuArdGrlFrn
    ''' LEGADO:SPCLJ002
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    09/01/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub ApurarAcordoGeralDeFornecimento(ByVal ppin_NumCttFrn As Decimal, _
                                                      ByVal ppin_Clausula As Decimal, _
                                                      ByVal ppid_DatApuracao As Date, _
                                                      ByVal ppin_Periodo As Decimal, _
                                                      ByVal ppin_ApuraTudo As Integer, _
                                                      ByVal ppin_Fornecedores As Integer, _
                                                      ByVal ppin_Categoria As Integer, _
                                                      ByVal ppin_Item As Integer, _
                                                      ByVal ppin_ItensNovos As Integer, _
                                                      ByVal ppin_CodEmp As Integer, _
                                                      ByVal ppin_LeadSmn As Integer, _
                                                      ByVal ppid_DatEmsNotFsc As String, _
                                                      ByVal ppid_DatLibIni As String, _
                                                      ByVal ppid_DatLibFim As String)

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Timeout = 300000
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials

        webService.ApurarAcordoGeralDeFornecimento(ppin_NumCttFrn, _
                                                   ppin_Clausula, _
                                                   ppid_DatApuracao, _
                                                   ppin_Periodo, _
                                                   ppin_ApuraTudo, _
                                                   ppin_Fornecedores, _
                                                   ppin_Categoria, _
                                                   ppin_Item, _
                                                   ppin_ItensNovos, _
                                                   ppin_CodEmp, _
                                                   ppin_LeadSmn, _
                                                   ppid_DatEmsNotFsc, _
                                                   ppid_DatLibIni, _
                                                   ppid_DatLibFim)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chamada para procedure: MRT.PctDLVrfAscCslCttFrnAscFrnPcp.PrcDLVrfAscCslCttFrnAscFrnPcp
    ''' </summary>
    ''' <param name="ppin_IndPrc"></param>
    ''' <param name="ppin_NumCslCttFrn"></param>
    ''' <param name="ppin_CodFrnPcpApuArdFrn"></param>
    ''' <param name="ppin_NumCttFrn"></param>
    ''' <param name="ppin_CodFrnAscApuArdFrn"></param>
    ''' <param name="ppin_NumCttFrnAcs"></param>
    ''' <remarks>
    ''' Chamada para procedure: MRT.PctDLVrfAscCslCttFrnAscFrnPcp.PrcDLVrfAscCslCttFrnAscFrnPcp
    ''' LEGADO:spClj118
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    01/02/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ManterClausulaContrato(ByVal ppin_IndPrc As Integer, _
                                                  ByVal ppin_NumCslCttFrn As Integer, _
                                                  ByVal ppin_CodFrnPcpApuArdFrn As Integer, _
                                                  ByVal ppin_NumCttFrn As Integer, _
                                                  ByVal ppin_CodFrnAscApuArdFrn As Integer, _
                                                  ByVal ppin_NumCttFrnAcs As Integer) As Integer

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Timeout = 300000
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials

        Return webService.ManterClausulaContrato(ppin_IndPrc, _
                                                 ppin_NumCslCttFrn, _
                                                 ppin_CodFrnPcpApuArdFrn, _
                                                 ppin_NumCttFrn, _
                                                 ppin_CodFrnAscApuArdFrn, _
                                                 ppin_NumCttFrnAcs)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chamada para procedure: MRT.PctGrcFxaAbg.PrcGrcFxaAbg
    ''' </summary>
    ''' <param name="ppin_CTT"></param>
    ''' <param name="ppin_CSL"></param>
    ''' <param name="ppin_ABG"></param>
    ''' <param name="ppin_EDE"></param>
    ''' <param name="ppin_VLRFXA"></param>
    ''' <param name="ppin_VLRREC"></param>
    ''' <param name="ppin_PER"></param>
    ''' <param name="ppid_DATREFINIUTZPMT"></param>
    ''' <remarks>
    ''' Chamada para procedure: MRT.PctGrcFxaAbg.PrcGrcFxaAbg
    ''' LEGADO:spClj017
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    01/02/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function GeraFaixasParaAbrangencia(ByVal ppin_CTT As Decimal, _
                                                     ByVal ppin_CSL As Decimal, _
                                                     ByVal ppin_ABG As Decimal, _
                                                     ByVal ppin_EDE As Decimal, _
                                                     ByVal ppin_VLRFXA As Decimal, _
                                                     ByVal ppin_VLRREC As Decimal, _
                                                     ByVal ppin_PER As Decimal, _
                                                     ByVal ppid_DATREFINIUTZPMT As Date) As Boolean

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000

        Return webService.GeraFaixasParaAbrangencia(ppin_CTT, _
                                                    ppin_CSL, _
                                                    ppin_ABG, _
                                                    ppin_EDE, _
                                                    ppin_VLRFXA, _
                                                    ppin_VLRREC, _
                                                    ppin_PER, _
                                                    ppid_DATREFINIUTZPMT)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chamada para procedure: MRT.PctFmrAgdPed.PrcFmrAgdPed
    ''' </summary>
    ''' <param name="ppin_CodOpc"></param>
    ''' <param name="ppin_CodPar"></param>
    ''' <param name="ppis_DesPar"></param>
    ''' <param name="ppin_TipOrd"></param>
    ''' <param name="ppin_CodEmp"></param>
    ''' <remarks>
    ''' Chamada para procedure: MRT.PctFmrAgdPed.PrcFmrAgdPed
    ''' LEGADO:spCby116
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    01/02/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObtemFornecedorEPeriodoContrato(ByVal ppin_CodOpc As Integer, _
                                                    ByVal ppin_CodPar As Integer, _
                                                    ByVal ppis_DesPar As String, _
                                                    ByVal ppin_TipOrd As Integer, _
                                                    ByVal ppin_CodEmp As Integer) As wsAcoesComerciais.DatasetFornecedorEPeriodoContrato

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000

        ObtemFornecedorEPeriodoContrato = webService.ObtemFornecedorEPeriodoContrato(ppin_CodOpc, _
                                                                                     ppin_CodPar, _
                                                                                     ppis_DesPar, _
                                                                                     ppin_TipOrd, _
                                                                                     ppin_CodEmp)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chamada para procedure: MRT.PctMntFxaCrs.PrcMntFxaCrs
    ''' </summary>
    ''' <param name="ppin_CTT"></param>
    ''' <param name="ppin_CSL"></param>
    ''' <param name="ppin_ABG"></param>
    ''' <param name="ppin_EDE"></param>
    ''' <param name="ppin_VLRFXA"></param>
    ''' <param name="ppin_VLRREC"></param>
    ''' <param name="ppin_PER"></param>
    ''' <param name="ppin_CODFXA"></param>
    ''' <param name="ppid_DATREFINIUTZPMT"></param>
    ''' <remarks>
    ''' Chamada para procedure: MRT.PctMntFxaCrs.PrcMntFxaCrs
    ''' LEGADO:spClj028
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    01/02/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ManterFaixasDeCrescimento(ByVal ppin_CTT As Integer, _
                                                     ByVal ppin_CSL As Integer, _
                                                     ByVal ppin_ABG As Integer, _
                                                     ByVal ppin_EDE As Integer, _
                                                     ByVal ppin_VLRFXA As Decimal, _
                                                     ByVal ppin_VLRREC As Decimal, _
                                                     ByVal ppin_PER As Decimal, _
                                                     ByVal ppin_CODFXA As Integer, _
                                                     ByVal ppid_DATREFINIUTZPMT As Date) As Boolean

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000

        Return webService.ManterFaixasDeCrescimento(ppin_CTT, _
                                                    ppin_CSL, _
                                                    ppin_ABG, _
                                                    ppin_EDE, _
                                                    ppin_VLRFXA, _
                                                    ppin_VLRREC, _
                                                    ppin_PER, _
                                                    ppin_CODFXA, _
                                                    ppid_DATREFINIUTZPMT)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chamada para procedure: MRT.PctAtlPmtAlcVba.PrcAtlPmtAlcVba
    ''' </summary>
    ''' <param name="ppin_TipOpe"></param>
    ''' <param name="ppin_NumCtt_Query"></param>
    ''' <param name="ppin_NumCttFrn"></param>
    ''' <param name="ppin_NumCSl_Query"></param>
    ''' <param name="ppin_TipEde_Query"></param>
    ''' <param name="ppin_CodEde_Query"></param>
    ''' <param name="ppin_PerVlrRcb"></param>
    ''' <param name="ppin_PerVlrRcb_Query"></param>
    ''' <param name="ppin_ReqAlcVba_Query"></param>
    ''' <remarks>
    ''' Chamada para procedure: MRT.PctAtlPmtAlcVba.PrcAtlPmtAlcVba
    ''' LEGADO:spClj198
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    01/02/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarParametrosAlocacaoVerbas(ByVal ppin_TipOpe As Integer, _
                                                 ByVal ppin_NumCtt_Query As Integer, _
                                                 ByVal ppin_NumCttFrn As Integer, _
                                                 ByVal ppin_NumCSl_Query As Integer, _
                                                 ByVal ppin_TipEde_Query As Integer, _
                                                 ByVal ppin_CodEde_Query As Decimal, _
                                                 ByVal ppin_PerVlrRcb As Integer, _
                                                 ByVal ppin_PerVlrRcb_Query As Integer, _
                                                 ByVal ppin_ReqAlcVba_Query As Integer)

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000

        webService.AtualizarParametrosAlocacaoVerbas(ppin_TipOpe, _
                                                     ppin_NumCtt_Query, _
                                                     ppin_NumCttFrn, _
                                                     ppin_NumCSl_Query, _
                                                     ppin_TipEde_Query, _
                                                     ppin_CodEde_Query, _
                                                     ppin_PerVlrRcb, _
                                                     ppin_PerVlrRcb_Query, _
                                                     ppin_ReqAlcVba_Query)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem as clásulas em um ou mais contratos, desde que esteja vigente, 
    ''' de um fornecedor específico
    ''' </summary>
    ''' <param name="CODFRNPCPAPUARDFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	12/2/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterClausulasEmContratroVigentesDoFornecedor(ByVal CODFRNPCPAPUARDFRN As Decimal) As wsAcoesComerciais.DatasetContrato
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials

        webService.ObterClausulasEmContratroVigentesDoFornecedor(CODFRNPCPAPUARDFRN)
    End Function

#End Region

#Region " Regras da Tela de Alteração de Forma de Pagamentos "


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' LÓGICA DA PROC spCLJ095 MIGRADA PARA FRAMEWORK MARTINS
    ''' </summary>
    ''' <param name="NumCttFrn"></param>
    ''' <param name="NumCslCttFrn"></param>
    ''' <param name="TipPodCttFrn"></param>
    ''' <param name="NumRefPod"></param>
    ''' <param name="TipEdeAbgMix"></param>
    ''' <param name="CodEdeAbgMix"></param>
    ''' <param name="DatRefApu"></param>
    ''' <param name="NumSeqRlcCttPms"></param>
    ''' <param name="CodFrn"></param>
    ''' <param name="CodEmpFrn"></param>
    ''' <param name="NumNotFscFrnCtb"></param>
    ''' <param name="CodSeqPclNotFsc"></param>
    ''' <param name="NumSeqTitPgt"></param>
    ''' <param name="CodEmp"></param>
    ''' <param name="CodFilEmp"></param>
    ''' <param name="VlrUtzCtt"></param>
    ''' <param name="FlgSitNgcDup"></param>
    ''' <param name="TipDscPgtFvc"></param>
    ''' <param name="TipFrmDscBnf"></param>
    ''' <param name="TipDsnDscBnf"></param>
    ''' <param name="NomAcsUsrSis"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio]	5/10/2006	Created
    ''' </history>
    '''     ''' -----------------------------------------------------------------------------
    Public Shared Function AtualizarValorUtilizado(ByVal NumCttFrn As Integer, _
                                            ByVal NumCslCttFrn As Integer, _
                                            ByVal TipPodCttFrn As Integer, _
                                            ByVal NumRefPod As Integer, _
                                            ByVal TipEdeAbgMix As Integer, _
                                            ByVal CodEdeAbgMix As Decimal, _
                                            ByVal DatRefApu As Date, _
                                            ByVal NumSeqRlcCttPms As Integer, _
                                            ByVal CodFrn As Integer, _
                                            ByVal CodEmpFrn As Integer, _
                                            ByVal NumNotFscFrnCtb As Integer, _
                                            ByVal CodSeqPclNotFsc As String, _
                                            ByVal NumSeqTitPgt As Integer, _
                                            ByVal CodEmp As Integer, _
                                            ByVal CodFilEmp As Integer, _
                                            ByVal VlrUtzCtt As Decimal, _
                                            ByVal FlgSitNgcDup As String, _
                                            ByVal TipDscPgtFvc As Integer, _
                                            ByVal TipFrmDscBnf As Integer, _
                                            ByVal TipDsnDscBnf As Integer, _
                                            ByVal NomAcsUsrSis As String) As Boolean
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        Return webService.AtualizarValorUtilizado(NumCttFrn, NumCslCttFrn, TipPodCttFrn, NumRefPod, TipEdeAbgMix, CodEdeAbgMix, DatRefApu, NumSeqRlcCttPms, CodFrn, CodEmpFrn, NumNotFscFrnCtb, CodSeqPclNotFsc, NumSeqTitPgt, CodEmp, CodFilEmp, VlrUtzCtt, FlgSitNgcDup, TipDscPgtFvc, TipFrmDscBnf, TipDsnDscBnf, NomAcsUsrSis)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' LÓGICA DA PROC spCLJ096 MIGRADA PARA FRAMEWORK MARTINS
    ''' </summary>
    ''' <param name="NumCttFrn"></param>
    ''' <param name="NumCslCttFrn"></param>
    ''' <param name="TipPodCttFrn"></param>
    ''' <param name="NumRefPod"></param>
    ''' <param name="TipEdeAbgMix"></param>
    ''' <param name="CodEdeAbgMix"></param>
    ''' <param name="DatRefApu"></param>
    ''' <param name="VlrRcbEftFxa"></param>
    ''' <param name="TipFrmDscBnf"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	28/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function GerarLinhaDescontoBonificacao(ByVal NumCttFrn As Integer, _
                                                    ByVal NumCslCttFrn As Integer, _
                                                    ByVal TipPodCttFrn As Integer, _
                                                    ByVal NumRefPod As Integer, _
                                                    ByVal TipEdeAbgMix As Integer, _
                                                    ByVal CodEdeAbgMix As Decimal, _
                                                    ByVal DatRefApu As Date, _
                                                    ByVal VlrRcbEftFxa As Decimal, _
                                                    ByVal TipFrmDscBnf As Integer, _
                                                    ByVal NumSeqRlcCttPms As Decimal) As Boolean
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        webService.GerarLinhaDescontoBonificacao(NumCttFrn, NumCslCttFrn, TipPodCttFrn, NumRefPod, TipEdeAbgMix, CodEdeAbgMix, DatRefApu, VlrRcbEftFxa, TipFrmDscBnf, NumSeqRlcCttPms)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' LÓGICA DA PROC spCLJ097 MIGRADA PARA FRAMEWORK MARTINS
    ''' </summary>
    ''' <param name="NumCttFrn"></param>
    ''' <param name="NumCslCttFrn"></param>
    ''' <param name="TipPodCttFrn"></param>
    ''' <param name="NumRefPod"></param>
    ''' <param name="TipEdeAbgMix"></param>
    ''' <param name="CodEdeAbgMixEnt"></param>
    ''' <param name="DatRefApu"></param>
    ''' <param name="NumSeqRlcCttPms"></param>
    ''' <param name="VlrNgcPms"></param>
    ''' <param name="CodPms"></param>
    ''' <param name="DatNgcPms"></param>
    ''' <param name="VlrEftDscPcl"></param>
    ''' <param name="FlgSitNgcDup"></param>
    ''' <param name="NomAcsUsrSis"></param>
    ''' <param name="CodEmp"></param>
    ''' <param name="CodFilEmp"></param>
    ''' <param name="TipFrmDscBnf"></param>
    ''' <param name="TipDsnDscBnf"></param>
    ''' <param name="CodFrn"></param>
    ''' <param name="CodEmpFrn"></param>
    ''' <param name="NumNotFscFrnCtb"></param>
    ''' <param name="CodSeqPclNotFsc"></param>
    ''' <param name="NumSeqTitPgt"></param>
    ''' <param name="TipDscPgtFvc"></param>
    ''' <param name="DatPrvRcbPms"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Elifázio Bernardes]	29/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function AtualizaSituacaoNegociacao(ByVal NumCttFrn As Integer, _
                                                ByVal NumCslCttFrn As Integer, _
                                                ByVal TipPodCttFrn As Integer, _
                                                ByVal NumRefPod As Integer, _
                                                ByVal TipEdeAbgMix As Integer, _
                                                ByVal CodEdeAbgMixEnt As Decimal, _
                                                ByVal DatRefApu As Date, _
                                                ByVal NumSeqRlcCttPms As Integer, _
                                                ByVal VlrNgcPms As Decimal, _
                                                ByVal CodPms As Integer, _
                                                ByVal DatNgcPms As Date, _
                                                ByVal VlrEftDscPcl As Decimal, _
                                                ByVal FlgSitNgcDup As String, _
                                                ByVal NomAcsUsrSis As String, _
                                                ByVal CodEmp As Integer, _
                                                ByVal CodFilEmp As Integer, _
                                                ByVal TipFrmDscBnf As Integer, _
                                                ByVal TipDsnDscBnf As Integer, _
                                                ByVal CodFrn As Integer, _
                                                ByVal CodEmpFrn As Integer, _
                                                ByVal NumNotFscFrnCtb As Integer, _
                                                ByVal CodSeqPclNotFsc As String, _
                                                ByVal NumSeqTitPgt As Integer, _
                                                ByVal TipDscPgtFvc As Integer, _
                                                ByVal DatPrvRcbPms As Date) As Boolean
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.Timeout = 300000
        webService.AtualizaSituacaoNegociacao(NumCttFrn, NumCslCttFrn, TipPodCttFrn, NumRefPod, TipEdeAbgMix, CodEdeAbgMixEnt, DatRefApu, NumSeqRlcCttPms, VlrNgcPms, CodPms, DatNgcPms, VlrEftDscPcl, FlgSitNgcDup, NomAcsUsrSis, CodEmp, CodFilEmp, TipFrmDscBnf, TipDsnDscBnf, CodFrn, CodEmpFrn, NumNotFscFrnCtb, CodSeqPclNotFsc, NumSeqTitPgt, TipDscPgtFvc, DatPrvRcbPms)
    End Function

#End Region

#End Region

#Region "Incentivo"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CODPRGICT"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo]	7/4/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterIncentivoPorChave(ByVal CODPRGICT As Decimal) As wsAcoesComerciais.DatasetIncentivo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterIncentivoPorChave(CODPRGICT)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CODPRGICT"></param>
    ''' <param name="NOMPRGICT"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	7/4/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterIncentivoPorAtributo(ByVal CODPRGICT As Decimal, ByVal NOMPRGICT As String) As wsAcoesComerciais.DatasetIncentivo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterIncentivoPorAtributo(CODPRGICT, NOMPRGICT)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	7/4/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterNovaChaveIncentivo() As Decimal
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterNovaChaveIncentivo()
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="DatasetIncentivo"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	7/4/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub AtualizarIncentivo(ByVal DatasetIncentivo As wsAcoesComerciais.DatasetIncentivo)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarIncentivo(CType(DatasetIncentivo.GetChanges(), wsAcoesComerciais.DatasetIncentivo))
    End Sub
#End Region

#Region "Outros"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Verifica de existe empenho relacionado para um determinado tipo
    ''' de empenho e para um determinado usuário
    ''' </summary>
    ''' <param name="TIPDSNDSCBNF">TIPO DESTINO / DESCONTO BONIFICADO.</param>
    ''' <param name="NOMACSUSRSIS">NOME DE ACESSO DO USUÁRIO AO SISTEMA</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	29/8/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ExisteEmpenhoRelacionado(ByVal TIPDSNDSCBNF As Decimal, _
                                                    ByVal NOMACSUSRSIS As String) As Boolean
        Try
            Dim webService As New wsAcoesComerciais.AcoesComerciais
            AssinadorWebServices.AssinarWebService(webService)
            webService.Credentials = System.Net.CredentialCache.DefaultCredentials
            Return webService.ExisteEmpenhoRelacionado(TIPDSNDSCBNF, NOMACSUSRSIS)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chamada para procedure: MRT.PCTDLSelAltVlrEftDsc.PRCDLSelAltVlrEftDsc
    ''' </summary>
    ''' <param name="pvOperacao"></param>
    ''' <param name="pvNumCttFrn"></param>
    ''' <param name="pvNumCslCttFrn"></param>
    ''' <param name="pvTipPodCttFrn"></param>
    ''' <param name="pvNumRefPod"></param>
    ''' <param name="pvTipEdeAbgMix"></param>
    ''' <param name="pvCodEdeAbgMixEnt"></param>
    ''' <param name="pvDatRefApu"></param>
    ''' <param name="pvVlrDscRcbEftFxa"></param>
    ''' <param name="pvNomAcsUsrSis"></param>
    ''' <remarks>
    ''' Chamada para procedure: MRT.PCTDLSelAltVlrEftDsc.PRCDLSelAltVlrEftDsc
    ''' LEGADO:SPCLJ105
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    26/02/2007  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function SelecionarEAlterarValorEfetivoDesconto(ByVal pvOperacao As Integer, _
                                                                  ByVal pvNumCttFrn As Decimal, _
                                                                  ByVal pvNumCslCttFrn As Decimal, _
                                                                  ByVal pvTipPodCttFrn As Decimal, _
                                                                  ByVal pvNumRefPod As Decimal, _
                                                                  ByVal pvTipEdeAbgMix As Decimal, _
                                                                  ByVal pvCodEdeAbgMixEnt As Decimal, _
                                                                  ByVal pvDatRefApu As Date, _
                                                                  ByVal pvVlrDscRcbEftFxa As Decimal, _
                                                                  ByVal pvNomAcsUsrSis As String) As wsAcoesComerciais.DatasetValorEfetivoDesconto
        Try
            Dim webService As New wsAcoesComerciais.AcoesComerciais
            AssinadorWebServices.AssinarWebService(webService)
            webService.Credentials = System.Net.CredentialCache.DefaultCredentials
            Return webService.SelecionarEAlterarValorEfetivoDesconto(pvOperacao, _
                                                                     pvNumCttFrn, _
                                                                     pvNumCslCttFrn, _
                                                                     pvTipPodCttFrn, _
                                                                     pvNumRefPod, _
                                                                     pvTipEdeAbgMix, _
                                                                     pvCodEdeAbgMixEnt, _
                                                                     pvDatRefApu, _
                                                                     pvVlrDscRcbEftFxa, _
                                                                     pvNomAcsUsrSis)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	29/11/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterNovaChaveTransferenciaVerba() As Decimal
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterNovaChaveTransferenciaVerba()
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NUMFLUAPV"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	6/12/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function IniciarFluxoTransferenciaVerbas(ByVal NUMFLUAPV As Decimal) As Boolean
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.IniciarFluxoTransferenciaVerbas(NUMFLUAPV)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NUMFLUAPV"></param>
    ''' <param name="CODFNC"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	12/12/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function AprovarFluxoTransferenciaVerbas(ByVal NUMFLUAPV As Decimal, ByVal CODFNC As Decimal, ByVal DESOBSAPV As String) As Boolean
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.AprovarFluxoTransferenciaVerbas(NUMFLUAPV, CODFNC, DESOBSAPV)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NUMFLUAPV"></param>
    ''' <param name="CODFNC"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	12/12/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ReprovarFluxoTransferenciaVerbas(ByVal NUMFLUAPV As Decimal, ByVal CODFNC As Decimal, ByVal DESOBSAPV As String) As Boolean
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ReprovarFluxoTransferenciaVerbas(NUMFLUAPV, CODFNC, DESOBSAPV)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NUMFLUAPV"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	27/12/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ClonarTransferenciaEmpenhoFornecedor(ByVal NUMFLUAPV As Decimal) As Decimal
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ClonarTransferenciaEmpenhoFornecedor(NUMFLUAPV)
    End Function

    '' -----------------------------------------------------------------------------
    '' <summary>
    '' 
    '' </summary>
    '' <param name="DATREF"></param>
    '' <returns></returns>
    '' <remarks>
    '' </remarks>
    '' <history>
    '' 	[Marcos Queiroz]	9/1/2008	Created
    '' </history>
    '' -----------------------------------------------------------------------------
    Public Shared Function ObterCalendarioAnual(ByVal DATREF As Date) As wsAcoesComerciais.DatasetCalendarioAnual
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterCalendarioAnual(DATREF)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	4/25/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterNovaChaveFluxoCancelamento() As Decimal
        Dim webService As New wsFluxoDeCancelamentoDeAcordos.FluxoDeCancelamentoDeAcordos
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterNovaChaveFluxoCancelamento()
    End Function


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NUMPEDCNCACOCMC"></param>
    ''' <param name="CODFNC"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	4/28/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterAcordosParaCancelamentoPorFornecedor(ByVal CODFRN As Decimal) As wsFluxoDeCancelamentoDeAcordos.DatasetAcordoACancelarEmFluxoCancelamentoAcordo
        Dim webService As New wsFluxoDeCancelamentoDeAcordos.FluxoDeCancelamentoDeAcordos
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterAcordosParaCancelamentoPorFornecedor(CODFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NUMPEDCNCACOCMC"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	5/6/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterAcordosParaCancelamentoPorNUMPEDCNCACOCMC(ByVal NUMPEDCNCACOCMC As Decimal) As wsFluxoDeCancelamentoDeAcordos.DatasetAcordoACancelarEmFluxoCancelamentoAcordo
        Dim webService As New wsFluxoDeCancelamentoDeAcordos.FluxoDeCancelamentoDeAcordos
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterAcordosParaCancelamentoPorNUMPEDCNCACOCMC(NUMPEDCNCACOCMC)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NUMPEDCNCACOCMC"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	13/5/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function IniciarFluxoCancelamentoAcordo(ByVal NUMPEDCNCACOCMC As Decimal, ByVal CODFRN As Decimal) As Boolean
        Dim webService As New wsFluxoDeCancelamentoDeAcordos.FluxoDeCancelamentoDeAcordos
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.IniciarFluxoCancelamentoAcordo(NUMPEDCNCACOCMC, CODFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NUMPEDCNCACOCMC"></param>
    ''' <param name="CODFNC"></param>
    ''' <param name="DESOBSAPV"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	16/5/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ReprovarFluxoCancelamentoAcordo(ByVal NUMPEDCNCACOCMC As Decimal, ByVal CODFRN As Decimal, ByVal CODFNC As Decimal, ByVal DESOBSAPV As String) As Boolean
        Dim webService As New wsFluxoDeCancelamentoDeAcordos.FluxoDeCancelamentoDeAcordos
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ReprovarFluxoCancelamentoAcordo(NUMPEDCNCACOCMC, CODFRN, CODFNC, DESOBSAPV)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NUMPEDCNCACOCMC"></param>
    ''' <param name="CODFNC"></param>
    ''' <param name="CODFRN"></param>
    ''' <param name="DESOBSAPV"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	19/5/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function AprovarFluxoCancelamentoAcordo(ByVal NUMPEDCNCACOCMC As Decimal, ByVal CODFNC As Decimal, ByVal CODFRN As Decimal, ByVal DESOBSAPV As String, ByVal NOMACSUSRSIS As String) As Boolean
        Dim webService As New wsFluxoDeCancelamentoDeAcordos.FluxoDeCancelamentoDeAcordos
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.AprovarFluxoCancelamentoAcordo(NUMPEDCNCACOCMC, CODFNC, CODFRN, DESOBSAPV, NOMACSUSRSIS)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NUMPEDCNCACOCMC"></param>
    ''' <param name="CODFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	20/5/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ClonarFluxoCancelamentoAcordoFornecedor(ByVal NUMPEDCNCACOCMC As Decimal, ByVal CODFRN As Decimal) As Decimal
        Dim webService As New wsFluxoDeCancelamentoDeAcordos.FluxoDeCancelamentoDeAcordos
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ClonarFluxoCancelamentoAcordoFornecedor(NUMPEDCNCACOCMC, CODFRN)
    End Function
#End Region

#End Region

#Region "Web Services Recuperacao E Prevencao Perdas"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CODFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Rodrigo Gama]	26/8/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterContratoComparativoValores(ByVal CODFRN As Decimal) As wsAcoesComerciais.DatasetContrato
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterContratoComparativoValores(CODFRN)
    End Function


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem os dados para o relatorio Recuperacao e Prevencao de Perdas.
    ''' </summary>
    ''' <param name="NUMCTTFRN">Numero do Contrato do Fornecedor</param>
    ''' <param name="INDDVRVLRAPUARDFRN">Define se apresenta todas as linhas ou apenas divergencias </param>
    ''' 1 - apresenta somente divergencias
    ''' 0 - apresenta todas as linhas
    ''' <param name="TIPLMTHSTCFAARDFRN">Define se apresenta informacoes da Devolucao 99</param>
    ''' 1 - Apresenta apuracao sem devolucao 99
    ''' 2 - Apresenta apuracao com devolucao 99
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Rodrigo Gama]	27/8/2008	Created
    ''' </history>
    Public Shared Function ObterRecuperacaoEPrevencaoPerdasSintetico(ByVal NUMCTTFRN As Decimal, _
                                                                     ByVal INDDVRVLRAPUARDFRN As Decimal, _
                                                                     ByVal TIPLMTHSTCFAARDFRN As Decimal) As wsRecuperacaoEPrevencaoPerdas.DatasetRecuperacaoEPrevencaoPerdas
        Dim webService As New wsRecuperacaoEPrevencaoPerdas.RecuperacaoEPrevencaoPerdas
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterRecuperacaoEPrevencaoPerdasSintetico(NUMCTTFRN, INDDVRVLRAPUARDFRN, TIPLMTHSTCFAARDFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem os dados para o relatorio Recuperacao e Prevencao de Perdas.
    ''' </summary>
    ''' <param name="NUMCTTFRN">Numero do Contrato do Fornecedor</param>
    ''' <param name="INDDVRVLRAPUARDFRN">Define se apresenta todas as linhas ou apenas divergencias </param>
    ''' 1 - apresenta somente divergencias
    ''' 0 - apresenta todas as linhas
    ''' <param name="TIPLMTHSTCFAARDFRN">Define se apresenta informacoes da Devolucao 99</param>
    ''' 1 - Apresenta apuracao sem devolucao 99
    ''' 2 - Apresenta apuracao com devolucao 99
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Rodrigo Gama]	27/8/2008	Created
    ''' </history>
    Public Shared Function ObterRecuperacaoEPrevencaoPerdasAnalitico(ByVal NUMCTTFRN As Decimal, _
                                                                     ByVal INDDVRVLRAPUARDFRN As Decimal, _
                                                                     ByVal TIPLMTHSTCFAARDFRN As Decimal, _
                                                                     ByVal DATREFAPU As Date, _
                                                                     ByVal NUMCSLCTTFRN As Decimal) As wsRecuperacaoEPrevencaoPerdas.DatasetRecuperacaoEPrevencaoPerdas
        Dim webService As New wsRecuperacaoEPrevencaoPerdas.RecuperacaoEPrevencaoPerdas
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterRecuperacaoEPrevencaoPerdasAnalitico(NUMCTTFRN, INDDVRVLRAPUARDFRN, TIPLMTHSTCFAARDFRN, DATREFAPU, NUMCSLCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem os dados para o relatorio Notas Periodo, caso a opção apresentar Devolução99
    ''' seja selecionada no menu Relatório "Recuperação e Prevenção de Perdas"
    ''' </summary>
    ''' <param name="NUMCTTFRN">Numero do Contrato do Fornecedor</param>
    ''' <param name="CODFRN">Código do Fornecedor </param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Rodrigo Gama]	16/9/2008	Created
    ''' </history>
    '''---------------------------------------------------------------------------------------
    Public Shared Function ObterNotasPeriodo(ByVal NUMCTTFRN As Decimal, _
                                             ByVal CODFRN As Decimal) As wsRecuperacaoEPrevencaoPerdas.DatasetRecuperacaoEPrevencaoPerdas
        Dim webService As New wsRecuperacaoEPrevencaoPerdas.RecuperacaoEPrevencaoPerdas
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterNotasPeriodo(NUMCTTFRN, CODFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem as clausulas do contrato selecionado como filtro para
    ''' o relatorio Recuperacao e Prevencao de Perdas.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Rodrigo Gama]	28/8/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterRecuperacaoEPrevencaoPerdasClausulas(ByVal NUMCTTFRN As Decimal) As wsRecuperacaoEPrevencaoPerdas.DatasetRecuperacaoEPrevencaoPerdas
        Dim webService As New wsRecuperacaoEPrevencaoPerdas.RecuperacaoEPrevencaoPerdas
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterRecuperacaoEPrevencaoPerdasClausulas(NUMCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem as datas de referencia da apuracao do contrato selecionado como filtro para
    ''' o relatorio Recuperacao e Prevencao de Perdas.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Rodrigo Gama]	28/8/2008	Created
    ''' </history>
    ''' 
    Public Shared Function ObterRecuperacaoEPrevencaoPerdasDataApuracao(ByVal NUMCTTFRN As Decimal) As wsRecuperacaoEPrevencaoPerdas.DatasetRecuperacaoEPrevencaoPerdas
        Dim webService As New wsRecuperacaoEPrevencaoPerdas.RecuperacaoEPrevencaoPerdas
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterRecuperacaoEPrevencaoPerdasDataApuracao(NUMCTTFRN)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem os dados para o relatorio Acordos Cancelados Perdas
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Rodrigo Gama]	27/8/2008	Created
    ''' </history>
    Public Shared Function ObterAcordosCanceladosPerdas(ByVal DATAINICIAL As Date, _
                                                        ByVal DATAFINAL As Date, _
                                                        ByVal CODFRN As Decimal, _
                                                        ByVal CODCPR As Decimal, _
                                                        ByVal CODDIVCMP As Decimal) As wsRecuperacaoEPrevencaoPerdas.DatasetRecuperacaoEPrevencaoPerdas
        Dim webService As New wsRecuperacaoEPrevencaoPerdas.RecuperacaoEPrevencaoPerdas
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterAcordosCanceladosPerdas(DATAINICIAL, DATAFINAL, CODFRN, CODCPR, CODDIVCMP)
    End Function


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem Compradores
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Rodrigo Gama]	04/09/2008	Created
    ''' </history>
    Public Shared Function ObterComprador(ByVal CODCPR As Decimal, _
                                          ByVal NOMCPR As String) As wsRecuperacaoEPrevencaoPerdas.DatasetRecuperacaoEPrevencaoPerdas
        Dim webService As New wsRecuperacaoEPrevencaoPerdas.RecuperacaoEPrevencaoPerdas
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterComprador(CODCPR, NOMCPR)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem Diretoria
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Rodrigo Gama]	04/09/2008	Created
    ''' </history>
    Public Shared Function ObterDiretoriaCelulas(ByVal CODCPR As Decimal, _
                                                ByVal CODDRT As Decimal, _
                                                ByVal CODDRTCMP As Decimal, _
                                                ByVal CODUNDESRNGC As Decimal, _
                                                ByVal DESDRTCMP As String) As wsRecuperacaoEPrevencaoPerdas.DatasetDiretoriaCelulas
        Dim webService As New wsRecuperacaoEPrevencaoPerdas.RecuperacaoEPrevencaoPerdas
        AssinadorWebServices.AssinarWebService(webService)
        Return webService.ObterDiretoriaCelulas(CODCPR, CODDRT, CODDRTCMP, CODUNDESRNGC, DESDRTCMP)
    End Function

#End Region

#Region "WebService CobrancaBancaria"

#Region "Obter Dados"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0100345
    ''' Descrição da entidade:BANCO
    ''' </summary>
    ''' <param name="CODBCO">CODIGO BANCO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    14/09/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterBanco(ByVal CODBCO As Decimal) As wsCobrancaBancaria.DatasetBanco
        Dim webService As New wsCobrancaBancaria.CobrancaBancaria
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterBanco(CODBCO)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0100345
    ''' Descrição da entidade:BANCO
    ''' </summary>
    ''' <param name="CODCID">CODIGO CIDADE.</param>
    ''' <param name="ENDBCO">ENDERECO BANCO.</param>
    ''' <param name="INDBCOCVNFNDIVT">INDICADOR DE BANCO CONVENIADO AO FUNDO DE INVESTIMENTO [ 0=NÃO TEM CONVENIO | 1=TEM CONVENIO].</param>
    ''' <param name="NOMBCO">NOME BANCO.</param>
    ''' <param name="TIPSITBCO">TIPO SITUACAO DO BANCO.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0100345" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    14/09/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterBancos(ByVal CODCID As Decimal, _
                                       ByVal ENDBCO As String, _
                                       ByVal INDBCOCVNFNDIVT As Decimal, _
                                       ByVal NOMBCO As String, _
                                       ByVal TIPSITBCO As Decimal) As wsCobrancaBancaria.DatasetBanco
        Dim webService As New wsCobrancaBancaria.CobrancaBancaria
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterBancos(CODCID, ENDBCO, INDBCOCVNFNDIVT, NOMBCO, TIPSITBCO)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0104413
    ''' Descrição da entidade:AGENCIA
    ''' </summary>
    ''' <param name="CODAGEBCO">CODIGO AGENCIA DO BANCO.</param>
    ''' <param name="CODBCO">CODIGO BANCO.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    14/09/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterAgencia(ByVal CODAGEBCO As Decimal, _
                                        ByVal CODBCO As Decimal) As wsCobrancaBancaria.DatasetAgencia
        Dim webService As New wsCobrancaBancaria.CobrancaBancaria
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterAgencia(CODAGEBCO, CODBCO)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0104413
    ''' Descrição da entidade:AGENCIA
    ''' </summary>
    ''' <param name="CODAGEBCO">CODIGO AGENCIA DO BANCO.</param>
    ''' <param name="CODBCO">CODIGO BANCO.</param>
    ''' <param name="CODCEPAGEBCO">CODIGO DE ENDERECAMENTO POSTAL AGENCIA BANCARIA.</param>
    ''' <param name="CODCIDAGEBCO">CODIGO CIDADE AGENCIA BANCARIA.</param>
    ''' <param name="FLGAGECDTCOBBCO">INDICA SE AGENCIA E CEDENTE COBRANCA BANCARIA  [S=SIM | N=NÃO].</param>
    ''' <param name="NOMAGEBCO">NOME AGENCIA DO BANCO.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0104413" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    14/09/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterAgencias(ByVal CODAGEBCO As Decimal, _
                                         ByVal CODBCO As Decimal, _
                                         ByVal CODCEPAGEBCO As Decimal, _
                                         ByVal CODCIDAGEBCO As Decimal, _
                                         ByVal FLGAGECDTCOBBCO As String, _
                                         ByVal NOMAGEBCO As String) As wsCobrancaBancaria.DatasetAgencia
        Dim webService As New wsCobrancaBancaria.CobrancaBancaria
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterAgencias(CODAGEBCO, CODBCO, CODCEPAGEBCO, CODCIDAGEBCO, FLGAGECDTCOBBCO, NOMAGEBCO)
    End Function

#End Region

#End Region

#Region "Outros"

    Public Shared Sub SetCurrentCulture()
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR")
    End Sub

    Public Shared Function PageSize() As Integer
        Dim result As Integer = 50
        If Not (System.Configuration.ConfigurationSettings.AppSettings("Martins.Web.UI.AcoesComerciais.PageSize") Is Nothing) Then
            result = CType(System.Configuration.ConfigurationSettings.AppSettings("Martins.Web.UI.AcoesComerciais.PageSize"), Integer)
        End If
        Return result
    End Function

    Public Shared Function ModoTeste() As Boolean
        Dim result As Boolean = False
        If Not (System.Configuration.ConfigurationSettings.AppSettings("ModoTeste") Is Nothing) Then
            If CType(System.Configuration.ConfigurationSettings.AppSettings("ModoTeste"), Integer) = 1 Then
                result = True
            Else
                result = False
            End If
        End If
        Return result
    End Function

#End Region

#Region "CarimboRelatorios"
    Public Shared Function ObterRelatorioCarimboDiretoria(ByVal Diretoria As Integer, ByVal Filial As Integer, ByVal Empenho As Integer) As wsAcoesComerciais.DatasetRelatorioCarimbo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterRelatorioDiretoria(Diretoria, Empenho, Filial)
    End Function
    Public Shared Function ObterRelatorioFiltroAnalitico(ByVal Empenho As Integer, ByVal Filial As Integer, ByVal Celula As Integer, ByVal Fornecedor As Integer, ByVal Comprador As Integer) As wsAcoesComerciais.DatasetRelatorioCarimbo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterRelatorioFiltroAnalitico(Empenho, Filial, Celula, Fornecedor, Comprador)
    End Function

    Public Shared Function ObterRelatorioFiltroSintetico(ByVal Empenho As Integer, ByVal Filial As Integer, ByVal Celula As Integer, ByVal Fornecedor As Integer, ByVal Comprador As Integer) As wsAcoesComerciais.DatasetRelatorioCarimbo
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterRelatorioFiltroSintetico(Empenho, Filial, Celula, Fornecedor, Comprador)
    End Function

    Public Shared Function ObterRelatorioHistorico(ByVal DataInicio As String, ByVal DataFim As String, ByVal Filial As Integer, ByVal Empenho As Integer, ByVal Celula As Integer, _
                                            ByVal Comprador As Integer, ByVal Diretoria As Integer, ByVal Fornecedor As Integer, _
                                        ByVal Mercadoria As Integer, ByVal Tipo As String, ByVal Descricao As String) As wsAcoesComerciais.DatasetCarimboHistorico
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterRelatorioHistorico(DataInicio, DataFim, Filial, Empenho, Celula, Comprador, Diretoria, Fornecedor, Mercadoria, Tipo, Descricao)
    End Function


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base na chave primária
    ''' Entidade T0100086
    ''' Descrição da entidade:CADASTRO MERCADORIA
    ''' </summary>
    ''' <param name="CODEMP">CODIGO EMPRESA.</param>
    ''' <param name="CODMER">CODIGO MERCADORIA.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    22/01/2008  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterMercadoriaPorChave(ByVal CODEMP As Decimal, _
                                                   ByVal CODMER As Decimal) As wsAcoesComerciais.DatasetMercadoria
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Timeout = 300000
        Return webService.ObterMercadoriaPorChave(CODEMP, CODMER)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem dados no Web Service com base em atributos não chave primária
    ''' Entidade T0100086
    ''' Descrição da entidade:CADASTRO MERCADORIA
    ''' </summary>
    ''' <param name="CODEMP">CODIGO EMPRESA.</param>
    ''' <param name="CODFMLMER">CODIGO FAMILIA DA MERCADORIA.</param>
    ''' <param name="CODFRNPCPMER">CODIGO FORNECEDOR.</param>
    ''' <param name="CODGRPMER">CODIGO GRUPO DA MERCADORIA.</param>
    ''' <param name="CODGRPMERNCM">CODIGO GRUPO DE MERCADORIAS NCM.</param>
    ''' <param name="CODGRPMERNCMCTB">CODIGO GRUPO MERCADORIA NCM CONTABIL.</param>
    ''' <param name="CODMER">CODIGO MERCADORIA.</param>
    ''' <param name="CODORIMER">CODIGO ORIGEM DA MERCADORIA.</param>
    ''' <param name="CODSITMER">CODIGO SITUACAO DA MERCADORIA.</param>
    ''' <param name="IncluirDATDSTMERNulo"> Valores: [0:Não incluir no resultado se o campo for nulo | 1:Incluir no resultado se campo for nulo | 3:Independente do valor do campo incluir no resultado] - DATA EM QUE O MARTINS DEIXOU DE COMERCIALIZAR A MERCADO.</param>
    ''' <param name="DESMER">DESCRICAO MERCADORIA.</param>
    ''' <param name="FLGDSTMER">INDICA SE A MERCADORIA ESTA DESATIVADA OU NAO.</param>
    ''' <param name="IncluirFLGDSTMERNulo"> Valores: [0:Não incluir no resultado se o campo for nulo | 1:Incluir no resultado se campo for nulo | 3:Independente do valor do campo incluir no resultado] - INDICA SE A MERCADORIA ESTA DESATIVADA OU NAO.</param>
    ''' <param name="TIPPDCMER">DEFINE TIPO MERCADORIA.</param>
    ''' <returns>Retorna um DataSet com a tabela "T0100086" preenchida.</returns>
    ''' <remarks>
    ''' Caso o parametro seja omitido o atributo não será incluído na clausula Where.
    ''' Um parametro do tipo número é omitido quando for zero,
    ''' Um parametro do tipo String é omitido quando for vazia,
    ''' Um parametro do tipo data   é omitido quando for Nothing,
    ''' Um parametro com valor inicial e final será incluído somente se ambos parametros forem informados,
    ''' </remarks>
    ''' <history>
    '''     [Marcos Queiroz]    22/01/2008  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ObterMercadoriaPorAtributos(ByVal CODEMP As Decimal, _
                                                       ByVal CODFMLMER As Decimal, _
                                                       ByVal CODFRNPCPMER As Decimal, _
                                                       ByVal CODGRPMER As Decimal, _
                                                       ByVal CODGRPMERNCM As String, _
                                                       ByVal CODGRPMERNCMCTB As String, _
                                                       ByVal CODMER As Decimal, _
                                                       ByVal CODORIMER As Decimal, _
                                                       ByVal CODSITMER As Decimal, _
                                                       ByVal IncluirDATDSTMERNulo As Int16, _
                                                       ByVal DESMER As String, _
                                                       ByVal FLGDSTMER As String, _
                                                       ByVal IncluirFLGDSTMERNulo As Int16, _
                                                       ByVal TIPPDCMER As Decimal) As wsAcoesComerciais.DatasetMercadoria
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Timeout = 300000
        Return webService.ObterMercadoriaPorAtributos(CODEMP, CODFMLMER, CODFRNPCPMER, CODGRPMER, CODGRPMERNCM, CODGRPMERNCMCTB, CODMER, CODORIMER, CODSITMER, IncluirDATDSTMERNulo, DESMER, FLGDSTMER, IncluirFLGDSTMERNulo, TIPPDCMER)
    End Function
#End Region

#Region "ValoresContabilizadosCarimbos"

    Public Shared Function ObterComboTipoLancamento() As wsAcoesComerciais.DataSetValoresContabilizadosCarimbosRelatorio
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterComboTipoLancamento()
    End Function

    Public Shared Function ObterRelatorioValoresReceber(ByVal AnoMesRef As String, _
                                                        ByVal DataPrevisaoRecebimento As String, _
                                                        ByVal Fornecedor As Integer, _
                                                        ByVal tpObjetivoVerba As Integer, _
                                                        ByVal isSintetico As Boolean, ByVal isCarimbados As Boolean) As wsAcoesComerciais.DataSetValoresContabilizadosCarimbosRelatorio
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterRelatorioValoresReceber(AnoMesRef, DataPrevisaoRecebimento, Fornecedor, tpObjetivoVerba, isSintetico, isCarimbados)
    End Function

    Public Shared Function ObterRelatorioValoresRecebidos(ByVal DataInicio As String, _
                                                             ByVal DataFim As String, _
                                                             ByVal Fornecedor As Decimal, _
                                                             ByVal TipoLancamento As String, _
                                                             ByVal tpObjetivoVerba As Integer, _
                                                             ByVal isSintatico As Boolean, ByVal isCarimbados As Boolean) As wsAcoesComerciais.DataSetValoresContabilizadosCarimbosRelatorio

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterRelatorioValoresRecebidos(DataInicio, DataFim, Fornecedor, TipoLancamento, tpObjetivoVerba, isSintatico, isCarimbados)
    End Function


    Public Shared Function ObterRelatorioVerbasCarimbadasRealizado(ByVal DataInicio As String, _
                                                                   ByVal DataFim As String, _
                                                                   ByVal Destino As Decimal, _
                                                                   ByVal Fornecedor As Decimal, _
                                                                   ByVal isSintatico As Boolean) As wsAcoesComerciais.DataSetRelatorioVerbasCarimbadas

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterRelatorioVerbasCarimbadasRealizado(DataInicio, DataFim, Destino, Fornecedor, isSintatico)
    End Function

    Public Shared Function ObterRelatorioVerbasCarimbadasCancelado(ByVal DataInicio As String, _
                                                                   ByVal DataFim As String, _
                                                                   ByVal Destino As Decimal, _
                                                                   ByVal Fornecedor As Decimal, _
                                                                   ByVal isSintatico As Boolean) As wsAcoesComerciais.DataSetRelatorioVerbasCarimbadas

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterRelatorioVerbasCarimbadasCancelado(DataInicio, DataFim, Destino, Fornecedor, isSintatico)
    End Function

    Public Shared Function ObterRelatorioNovosAcordos(ByVal DataInicio As String, _
                                                      ByVal DataFim As String, _
                                                      ByVal Fornecedor As Decimal, _
                                                      ByVal isSintatico As Boolean) As wsAcoesComerciais.DataSetRelatorioAcordos

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterRelatorioNovosAcordos(DataInicio, DataFim, Fornecedor, isSintatico)
    End Function

    Public Shared Function ObterRelatorioAcordosCancelados(ByVal DataInicio As String, _
                                                           ByVal DataFim As String, _
                                                           ByVal Fornecedor As Decimal, _
                                                           ByVal isSintatico As Boolean) As wsAcoesComerciais.DataSetRelatorioAcordos

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterRelatorioAcordosCancelados(DataInicio, DataFim, Fornecedor, isSintatico)
    End Function

    Public Shared Function ObterComboAnoMesRef() As wsAcoesComerciais.DataSetValoresContabilizadosCarimbosRelatorio

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterComboAnoMesRef()
    End Function

    Public Shared Function ObterRValorVendaCarimboXPendenteFaturar(ByVal DataInicio As String, _
                                        ByVal DataFim As String, _
                                        ByVal mercadoria As Integer, _
                                        ByVal Filial As Decimal, _
                                        ByVal isSintatico As Boolean) As wsAcoesComerciais.DataSetValoresContabilizadosCarimbosRelatorio

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterRValorVendaCarimboXPendenteFaturar(DataInicio, DataFim, mercadoria, Filial, isSintatico)
    End Function

    Public Shared Function ObterValoresRealizadosFundingCarimbo(ByVal DataInicio As String, _
                                            ByVal DataFim As String, _
                                            ByVal Fornecedor As Integer) As wsAcoesComerciais.DataSetValoresContabilizadosCarimbosRelatorio

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterValoresRealizadosFundingCarimbo(DataInicio, DataFim, Fornecedor)
    End Function

#End Region

    Public Shared Function ObterDEDAutomatico(ByVal codFrn As String, _
                                                    ByVal nomFrn As String, _
                                                    ByVal codGrpFrn As String, _
                                                    ByVal nomGrpFrn As String, ByVal stStatus As String) As wsAcoesComerciais.DatasetFornecedor

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterDEDAutomatico(codFrn, nomFrn, codGrpFrn, nomGrpFrn, stStatus)
    End Function

    Public Shared Sub AtualizarDEDAutomatico(ByVal dstFrn As wsAcoesComerciais.DatasetFornecedor)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarDEDAutomatico(dstFrn)
    End Sub




    Public Shared Function ObterTiposObjetivoVerba(ByVal nomeObjetivo As String, ByVal codigo As String) As wsAcoesComerciais.DatasetVerbaCarimbo

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTiposObjetivoVerba(nomeObjetivo, codigo)
    End Function

    Public Shared Sub AtualizarTiposObjetivoVerba(ByVal ds As wsAcoesComerciais.DatasetVerbaCarimbo)
        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        webService.AtualizarTiposObjetivoVerba(ds)
    End Sub

    Public Shared Sub NavegarInserirTipoObjetivoVerba()
        HttpContext.Current.Response.Redirect("TipoObjetivoVerba.aspx")
    End Sub

    Public Shared Function ObterTiposObjetivoVerbaAtivo() As wsAcoesComerciais.DatasetVerbaCarimbo

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterTiposObjetivoVerbaAtivo()
    End Function

    Public Shared Function ObterEmpenhosValidos() As wsAcoesComerciais.DatasetEmpenho

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.ObterEmpenhosValidos()
    End Function

    Public Shared Function VerificaDesaticavaoTipoDestinoVerba(ByVal id As Integer) As String

        Dim webService As New wsAcoesComerciais.AcoesComerciais
        AssinadorWebServices.AssinarWebService(webService)
        webService.Credentials = System.Net.CredentialCache.DefaultCredentials
        Return webService.VerificaDesaticavaoTipoDestinoVerba(id)
    End Function

End Class