Imports System.Web.Services
Imports Martins.Security.Helper
Imports Martins.ExceptionManagement
Imports Martins.Compras.AcoesComerciais.AcordoFornecimento
Imports Martins.Compras.AcoesComerciais.AcordoFornecimento.BP
Imports Martins.Compras.AcoesComerciais.ContaCorrenteFornecedor
Imports Martins.Compras.AcoesComerciais.ContaCorrenteFornecedor.BP
Imports Martins.Compras.AcoesComerciais.Gestao
Imports Martins.Compras.AcoesComerciais.Gestao.BP
Imports Martins.Administracao.Contabilidade.Filial
Imports Martins.Administracao.Contabilidade.Filial.BP
Imports Martins.Compras.Negociacao.PedidoCompra
Imports Martins.Compras.Negociacao.PedidoCompra.BP
Imports Martins.Administracao.CadastramentoFornecedores.DivisaoFornecedor
Imports Martins.Administracao.CadastramentoFornecedores.DivisaoFornecedor.BP
Imports Martins.Compras.Negociacao.UsuarioCompra
Imports Martins.Compras.Negociacao.UsuarioCompra.bp
Imports Martins.Compras.AcoesComerciais.AcoesMercadologicas
Imports Martins.Compras.AcoesComerciais.AcoesMercadologicas.BP

'Imports Martins.Compras.Negociacao.UsuarioCompra
'Imports Martins.Compras.Negociacao.UsuarioCompra.BP

<System.Web.Services.WebService(Namespace:="http://tempuri.org/Martins.Web.Services.AcoesComerciais/AcoesComerciais")> _
Public Class AcoesComerciais
    Inherits SecureWebService

#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()

        'Add your own initialization code after the InitializeComponent() call

    End Sub

    'Required by the Web Services Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Web Services Designer
    'It can be modified using the Web Services Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: This procedure is required by the Web Services Designer
        'Do not modify it using the code editor.
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose (disposing)
    End Sub

#End Region

#Region "Serviços Classes AcordoFornecimento, ContaCorrenteFornecedor e Gestao"

    <WebMethod(Description:="Retorna um registro com base em sua chave primária.")> _
         Public Function ValidaSeFornecedorDeOrigemEDeDestinoEMexEImportado(ByVal codFrnOrigem As Decimal, ByVal codFrnDestino As Decimal) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetFornecedorImportado As DatasetFornecedorImportado

            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.ValidaSeFornecedorDeOrigemEDeDestinoEMexEImportado(codFrnOrigem, codFrnDestino)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária.")> _
      Public Function VerificaFornecedorImportado(ByVal CODFRN As Decimal) As DatasetFornecedorImportado
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetFornecedorImportado As DatasetFornecedorImportado

            AcordoComercialBP = New AcordoComercialBP
            DatasetFornecedorImportado = AcordoComercialBP.VerificaFornecedorImportado(CODFRN)

            Return DatasetFornecedorImportado
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária.")> _
  Public Function VerificaFornecedorMex(ByVal CODFRN As Decimal) As DatasetFornecedorImportado
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetFornecedorImportado As DatasetFornecedorImportado

            AcordoComercialBP = New AcordoComercialBP
            DatasetFornecedorImportado = AcordoComercialBP.VerificaFornecedorMex(CODFRN)

            Return DatasetFornecedorImportado
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function



    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0119291")> _
    Public Function ObterPendenciaRecebidaAcaoComercial(ByVal CODEMP As Decimal, _
                                                        ByVal CODFILEMP As Decimal, _
                                                        ByVal NUMPNDFRN As Decimal, _
                                                        ByVal NUMSEQPGTPND As Decimal) As DatasetPendenciaRecebidaAcaoComercial
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetPendenciaRecebidaAcaoComercial As DatasetPendenciaRecebidaAcaoComercial

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetPendenciaRecebidaAcaoComercial = AcordoFornecimentoBP.ObterPendenciaRecebidaAcaoComercial(CODEMP, CODFILEMP, NUMPNDFRN, NUMSEQPGTPND)

            Return DatasetPendenciaRecebidaAcaoComercial
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0119291")> _
    Public Function ObterPendenciasRecebidaAcaoComercial(ByVal CODAGE As Decimal, _
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
                                                         ByVal VLRPGOPND As Decimal) As DatasetPendenciaRecebidaAcaoComercial
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetPendenciaRecebidaAcaoComercial As DatasetPendenciaRecebidaAcaoComercial

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetPendenciaRecebidaAcaoComercial = AcordoFornecimentoBP.ObterPendenciasRecebidaAcaoComercial(CODAGE, CODBCO, CODEMP, CODFILEMP, CODFRN, DATBXAPNDFRN, DATBXAPNDFRNInicial, DATBXAPNDFRNFinal, IncluirDATBXAPNDFRNNulo, IncluirDATTRNPNDACOCMCNulo, IncluirDATVNCNGCPNDFRNNulo, NUMCHQPND, NUMNOTFSCFRNCTB, NUMORDPGTPND, NUMPNDFRN, NUMSEQPGTPND, VLRPGOPND)

            Return DatasetPendenciaRecebidaAcaoComercial
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0119291")> _
    Public Function AtualizarPendenciaRecebidaAcaoComercial(ByVal DatasetPendenciaRecebidaAcaoComercial As DatasetPendenciaRecebidaAcaoComercial) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarPendenciaRecebidaAcaoComercial(DatasetPendenciaRecebidaAcaoComercial)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0125038")> _
    Public Function ObterFaixaAvaliacao(ByVal CODEDEABGMIX As Decimal, _
                                        ByVal CODFXAAVL As Decimal, _
                                        ByVal NUMCSLCTTFRN As Decimal, _
                                        ByVal NUMCTTFRN As Decimal, _
                                        ByVal TIPEDEABGMIX As Decimal) As DatasetFaixaAvaliacao
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetFaixaAvaliacao As DatasetFaixaAvaliacao

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetFaixaAvaliacao = AcordoFornecimentoBP.ObterFaixaAvaliacao(CODEDEABGMIX, CODFXAAVL, NUMCSLCTTFRN, NUMCTTFRN, TIPEDEABGMIX)

            Return DatasetFaixaAvaliacao
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0125038")> _
    Public Function ObterFaixasAvaliacao(ByVal CODEDEABGMIX As Decimal, _
                                         ByVal CODFXAAVL As Decimal, _
                                         ByVal NUMCSLCTTFRN As Decimal, _
                                         ByVal NUMCTTFRN As Decimal, _
                                         ByVal TIPEDEABGMIX As Decimal) As DatasetFaixaAvaliacao
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetFaixaAvaliacao As DatasetFaixaAvaliacao

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetFaixaAvaliacao = AcordoFornecimentoBP.ObterFaixasAvaliacao(CODEDEABGMIX, CODFXAAVL, NUMCSLCTTFRN, NUMCTTFRN, TIPEDEABGMIX)

            Return DatasetFaixaAvaliacao
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0125038")> _
    Public Function AtualizarFaixaAvaliacao(ByVal DatasetFaixaAvaliacao As DatasetFaixaAvaliacao) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarFaixaAvaliacao(DatasetFaixaAvaliacao)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0124953")> _
    Public Function ObterClausulaContrato(ByVal NUMCSLCTTFRN As Decimal) As DatasetClausulaContrato
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetClausulaContrato As DatasetClausulaContrato

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetClausulaContrato = AcordoFornecimentoBP.ObterClausulaContrato(NUMCSLCTTFRN)

            Return DatasetClausulaContrato
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna os registros referentes a abrangencia do aditamento")> _
   Public Function ObterAbrangenciaAditamento(ByVal NUMCTTFRN As Decimal) As DatasetContrato
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetContrato As DatasetContrato

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetContrato = AcordoFornecimentoBP.ObterAbrangenciaAditamento(NUMCTTFRN)

            Return DatasetContrato
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna os registros referentes a abrangencia do aditamento")> _
 Public Function ObterAditamentoPorNUMCTTFRN(ByVal NUMCTTFRN As Decimal) As DatasetContrato
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetContrato As DatasetContrato

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetContrato = AcordoFornecimentoBP.ObterAditamentoPorNUMCTTFRN(NUMCTTFRN)

            Return DatasetContrato
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna os registros referentes aos percentuais do aditamento")> _
   Public Function ObterAditamento(ByVal NUMCTTFRN As Decimal, _
                                        ByVal NUMCSLCTTFRN As Decimal, _
                                        ByVal TIPEDEABGMIX As Decimal, _
                                        ByVal CODEDEABGMIX As Decimal) As DatasetContrato
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetContrato As DatasetContrato

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetContrato = AcordoFornecimentoBP.ObterAditamento(NUMCTTFRN, NUMCSLCTTFRN, TIPEDEABGMIX, CODEDEABGMIX)

            Return DatasetContrato
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna os registros referentes a tabela de simulacao")> _
   Public Function ObterDadosSimulacao(ByVal NUMCTTFRN As Decimal, _
                                        ByVal NUMCSLCTTFRN As Decimal, _
                                        ByVal TIPEDEABGMIX As Decimal, _
                                        ByVal CODEDEABGMIX As Decimal) As DatasetContrato
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetContrato As DatasetContrato

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetContrato = AcordoFornecimentoBP.ObterDadosSimulacao(NUMCTTFRN, NUMCSLCTTFRN, TIPEDEABGMIX, CODEDEABGMIX)

            Return DatasetContrato
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna os registros referentes aos dados da tabela: MRT.RLCARDFRNADINOTFSC")> _
 Public Function ObterAditamentoGravado(ByVal NUMCTTFRN As Decimal, _
                                      ByVal NUMCSLCTTFRN As Decimal, _
                                      ByVal TIPEDEABGMIX As Decimal, _
                                      ByVal CODEDEABGMIX As Decimal) As DatasetContrato
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetContrato As DatasetContrato

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetContrato = AcordoFornecimentoBP.ObterAditamentoGravado(NUMCTTFRN, NUMCSLCTTFRN, TIPEDEABGMIX, CODEDEABGMIX)

            Return DatasetContrato
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna os registros referentes aos dados da tabela: MRT.RLCARDFRNADINOTFSC")> _
  Public Function ObterAditamentoPorChave(ByVal NUMCTTFRN As Decimal, _
                                       ByVal NUMCSLCTTFRN As Decimal, _
                                       ByVal TIPEDEABGMIX As Decimal, _
                                       ByVal CODEDEABGMIX As Decimal) As DatasetContrato
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetContrato As DatasetContrato

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetContrato = AcordoFornecimentoBP.ObterAditamentoPorChave(NUMCTTFRN, NUMCSLCTTFRN, TIPEDEABGMIX, CODEDEABGMIX)

            Return DatasetContrato
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function


    <WebMethod(Description:="Atualização dos dados. Entidade principal: RLCARDFRNADINOTFSC")> _
  Public Function AtualizarAditamento(ByVal DatasetContrato As DatasetContrato) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarAditamento(DatasetContrato)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0124953")> _
    Public Function ObterClausulasContrato(ByVal DESCSLCTTFRN As String, _
                                           ByVal NUMCSLCTTFRN As Decimal) As DatasetClausulaContrato
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetClausulaContrato As DatasetClausulaContrato

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetClausulaContrato = AcordoFornecimentoBP.ObterClausulasContrato(DESCSLCTTFRN, NUMCSLCTTFRN)

            Return DatasetClausulaContrato
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0124953")> _
    Public Function AtualizarClausulaContrato(ByVal DatasetClausulaContrato As DatasetClausulaContrato) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarClausulaContrato(DatasetClausulaContrato)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0124970")> _
    Public Function ObterTipoPeriodo(ByVal TIPPODCTTFRN As Decimal) As DatasetTipoPeriodo
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetTipoPeriodo As DatasetTipoPeriodo

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetTipoPeriodo = AcordoFornecimentoBP.ObterTipoPeriodo(TIPPODCTTFRN)

            Return DatasetTipoPeriodo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0124970")> _
    Public Function ObterTiposPeriodo(ByVal DESPODCTTFRN As String, _
                                      ByVal TIPPODCTTFRN As Decimal) As DatasetTipoPeriodo
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetTipoPeriodo As DatasetTipoPeriodo

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetTipoPeriodo = AcordoFornecimentoBP.ObterTiposPeriodo(DESPODCTTFRN, TIPPODCTTFRN)

            Return DatasetTipoPeriodo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0124970")> _
    Public Function AtualizarTipoPeriodo(ByVal DatasetTipoPeriodo As DatasetTipoPeriodo) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarTipoPeriodo(DatasetTipoPeriodo)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0124945")> _
    Public Function ObterContrato(ByVal NUMCTTFRN As Decimal) As DatasetContrato
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetContrato As DatasetContrato

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetContrato = AcordoFornecimentoBP.ObterContrato(NUMCTTFRN)

            Return DatasetContrato
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0124945")> _
    Public Function ObterContratos(ByVal CODAGEBCOCTTFRN As Decimal, _
                                   ByVal CODBCOCTTFRN As Decimal, _
                                   ByVal CODCNTCRRBCOCTTFRN As String, _
                                   ByVal CODFRN As Decimal, _
                                   ByVal TIPPODCTTFRN As Decimal) As DatasetContrato
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetContrato As DatasetContrato

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetContrato = AcordoFornecimentoBP.ObterContratos(CODAGEBCOCTTFRN, CODBCOCTTFRN, CODCNTCRRBCOCTTFRN, CODFRN, TIPPODCTTFRN)

            Return DatasetContrato
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0124945")> _
    Public Function ObterContratosAtivos(ByVal CODAGEBCOCTTFRN As Decimal, _
                                         ByVal CODBCOCTTFRN As Decimal, _
                                         ByVal CODCNTCRRBCOCTTFRN As String, _
                                         ByVal CODFRN As Decimal, _
                                         ByVal TIPPODCTTFRN As Decimal) As DatasetContrato
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetContrato As DatasetContrato

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetContrato = AcordoFornecimentoBP.ObterContratosAtivos(CODAGEBCOCTTFRN, CODBCOCTTFRN, CODCNTCRRBCOCTTFRN, CODFRN, TIPPODCTTFRN)

            Return DatasetContrato
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0124945")> _
    Public Function AtualizarContrato(ByVal DatasetContrato As DatasetContrato) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarContrato(DatasetContrato)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0124996")> _
    Public Function ObterContratoXAbrangenciaMix(ByVal CODEDEABGMIX As Decimal, _
                                                 ByVal NUMCSLCTTFRN As Decimal, _
                                                 ByVal NUMCTTFRN As Decimal, _
                                                 ByVal TIPEDEABGMIX As Decimal) As DatasetContratoXAbrangenciaMix
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetContratoXAbrangenciaMix As DatasetContratoXAbrangenciaMix

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetContratoXAbrangenciaMix = AcordoFornecimentoBP.ObterContratoXAbrangenciaMix(CODEDEABGMIX, NUMCSLCTTFRN, NUMCTTFRN, TIPEDEABGMIX)

            Return DatasetContratoXAbrangenciaMix
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária (incluindo informações da mercadorias). Entidade principal:T0124996")> _
    Public Function ObterContratoXAbrangenciaMix2(ByVal CODEDEABGMIX As Decimal, _
                                                  ByVal NUMCSLCTTFRN As Decimal, _
                                                  ByVal NUMCTTFRN As Decimal, _
                                                  ByVal TIPEDEABGMIX As Decimal, _
                                                  ByVal CODFRN As Decimal) As DatasetContratoXAbrangenciaMix
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetContratoXAbrangenciaMix As DatasetContratoXAbrangenciaMix

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetContratoXAbrangenciaMix = AcordoFornecimentoBP.ObterContratoXAbrangenciaMix(CODEDEABGMIX, NUMCSLCTTFRN, NUMCTTFRN, TIPEDEABGMIX, CODFRN)

            Return DatasetContratoXAbrangenciaMix
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0124996")> _
    Public Function ObterContratosXAbrangenciasMix(ByVal CODEDEABGMIX As Decimal, _
                                                   ByVal NUMCSLCTTFRN As Decimal, _
                                                   ByVal NUMCTTFRN As Decimal, _
                                                   ByVal TIPEDEABGMIX As Decimal) As DatasetContratoXAbrangenciaMix
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetContratoXAbrangenciaMix As DatasetContratoXAbrangenciaMix

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetContratoXAbrangenciaMix = AcordoFornecimentoBP.ObterContratosXAbrangenciasMix(CODEDEABGMIX, NUMCSLCTTFRN, NUMCTTFRN, TIPEDEABGMIX)

            Return DatasetContratoXAbrangenciaMix
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0124996")> _
    Public Function AtualizarContratoXAbrangenciaMix(ByVal DatasetContratoXAbrangenciaMix As DatasetContratoXAbrangenciaMix) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarContratoXAbrangenciaMix(DatasetContratoXAbrangenciaMix)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0123086")> _
    Public Function ObterContaCorrenteFornecedor(ByVal CODFRN As Decimal, _
                                                 ByVal CODGDC As String, _
                                                 ByVal DATREFLMT As Date, _
                                                 ByVal NUMSEQLMT As Decimal, _
                                                 ByVal TIPDSNDSCBNF As Decimal) As DatasetContaCorrenteFornecedor
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            Dim DatasetContaCorrenteFornecedor As DatasetContaCorrenteFornecedor

            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            DatasetContaCorrenteFornecedor = ContaCorrenteFornecedorBP.ObterContaCorrenteFornecedor(CODFRN, CODGDC, DATREFLMT, NUMSEQLMT, TIPDSNDSCBNF)

            Return DatasetContaCorrenteFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0123086")> _
    Public Function ObterContasCorrenteFornecedor(ByVal CODCENCSTCRD As String, _
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
                                                  ByVal TIPDSNDSCBNF As Decimal) As DatasetContaCorrenteFornecedor
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            Dim DatasetContaCorrenteFornecedor As DatasetContaCorrenteFornecedor

            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            DatasetContaCorrenteFornecedor = ContaCorrenteFornecedorBP.ObterContasCorrenteFornecedor(CODCENCSTCRD, CODCENCSTDEB, CODCNTCRD, CODCNTDEB, CODFILEMP, CODFRN, CODGDC, CODPMS, CODTIPLMT, DATREFLMT, DATREFLMTInicial, DATREFLMTFinal, DESHSTLMT, DESVARHSTPAD, NUMSEQLMT, TIPDSNDSCBNF)

            Return DatasetContaCorrenteFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0123086")> _
    Public Function AtualizarContaCorrenteFornecedor(ByVal DatasetContaCorrenteFornecedor As DatasetContaCorrenteFornecedor) As Boolean
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            ContaCorrenteFornecedorBP.AtualizarContaCorrenteFornecedor(DatasetContaCorrenteFornecedor)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0123094")> _
    Public Function ObterParametroContabilContaCorrenteFornecedor(ByVal CODFILEMP As Decimal, _
                                                                  ByVal CODTIPLMT As Decimal) As DatasetParametroContabilContaCorrenteFornecedor
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            Dim DatasetParametroContabilContaCorrenteFornecedor As DatasetParametroContabilContaCorrenteFornecedor

            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            DatasetParametroContabilContaCorrenteFornecedor = ContaCorrenteFornecedorBP.ObterParametroContabilContaCorrenteFornecedor(CODFILEMP, CODTIPLMT)

            Return DatasetParametroContabilContaCorrenteFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0123094")> _
    Public Function ObterParametrosContabilContaCorrenteFornecedor(ByVal CODCENCSTCRD As String, _
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
                                                                   ByVal CODTIPLMT As Decimal) As DatasetParametroContabilContaCorrenteFornecedor
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            Dim DatasetParametroContabilContaCorrenteFornecedor As DatasetParametroContabilContaCorrenteFornecedor

            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            DatasetParametroContabilContaCorrenteFornecedor = ContaCorrenteFornecedorBP.ObterParametrosContabilContaCorrenteFornecedor(CODCENCSTCRD, CODCENCSTDEB, CODCNTCRD, CODCNTDEB, CODEVTCTB, CODEVTCTBFRTDVL, CODEVTCTBNGCDVL, CODFILEMP, CODFTOCTB, CODFTOCTBFRTDVL, CODFTOCTBNGCDVL, CODHSTPAD, CODTIPLMT)

            Return DatasetParametroContabilContaCorrenteFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0123094")> _
    Public Function AtualizarParametroContabilContaCorrenteFornecedor(ByVal DatasetParametroContabilContaCorrenteFornecedor As DatasetParametroContabilContaCorrenteFornecedor) As Boolean
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            ContaCorrenteFornecedorBP.AtualizarParametroContabilContaCorrenteFornecedor(DatasetParametroContabilContaCorrenteFornecedor)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0123108")> _
    Public Function ObterTipoLancamentoContaCorrenteFornecedor(ByVal CODTIPLMT As Decimal) As DatasetTipoLancamentoContaCorrenteFornecedor
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            Dim DatasetTipoLancamentoContaCorrenteFornecedor As DatasetTipoLancamentoContaCorrenteFornecedor

            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            DatasetTipoLancamentoContaCorrenteFornecedor = ContaCorrenteFornecedorBP.ObterTipoLancamentoContaCorrenteFornecedor(CODTIPLMT)

            Return DatasetTipoLancamentoContaCorrenteFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna os registros com base nas condições dos parâmetros. Entidade principal:T0162251")> _
    Public Function ObterTipoLancamentoPrincipalXTipoLancamentoAssociado(ByVal CODTIPLMTASC As Decimal, _
                                                                         ByVal CODTIPLMTPCP As Decimal) As DatasetTipoLancamentoContaCorrenteFornecedor
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            Dim DatasetTipoLancamentoContaCorrenteFornecedor As DatasetTipoLancamentoContaCorrenteFornecedor

            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            DatasetTipoLancamentoContaCorrenteFornecedor = ContaCorrenteFornecedorBP.ObterTipoLancamentoPrincipalXTipoLancamentoAssociado(CODTIPLMTASC, CODTIPLMTPCP)

            Return DatasetTipoLancamentoContaCorrenteFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0123108")> _
    Public Function ObterTiposLancamentoContaCorrenteFornecedor(ByVal DESTIPLMT As String, _
                                                                ByVal DESTIPLMTFRN As String) As DatasetTipoLancamentoContaCorrenteFornecedor
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            Dim DatasetTipoLancamentoContaCorrenteFornecedor As DatasetTipoLancamentoContaCorrenteFornecedor

            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            DatasetTipoLancamentoContaCorrenteFornecedor = ContaCorrenteFornecedorBP.ObterTiposLancamentoContaCorrenteFornecedor(DESTIPLMT, DESTIPLMTFRN)

            Return DatasetTipoLancamentoContaCorrenteFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0123108")> _
    Public Function AtualizarTipoLancamentoContaCorrenteFornecedor(ByVal DatasetTipoLancamentoContaCorrenteFornecedor As DatasetTipoLancamentoContaCorrenteFornecedor) As Boolean
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            ContaCorrenteFornecedorBP.AtualizarTipoLancamentoContaCorrenteFornecedor(DatasetTipoLancamentoContaCorrenteFornecedor)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0113552")> _
    Public Function ObterFormaPagamento(ByVal TIPFRMDSCBNF As Decimal) As DatasetFormaPagamento
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetFormaPagamento As DatasetFormaPagamento

            AcordoComercialBP = New AcordoComercialBP
            DatasetFormaPagamento = AcordoComercialBP.ObterFormaPagamento(TIPFRMDSCBNF)

            Return DatasetFormaPagamento
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function


    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0113552")> _
    Public Function ObterFormasPagamento(ByVal DESFRMDSCBNF As String, ByVal INDDSCGRCACOCMC As Decimal) As DatasetFormaPagamento
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetFormaPagamento As DatasetFormaPagamento

            AcordoComercialBP = New AcordoComercialBP
            DatasetFormaPagamento = AcordoComercialBP.ObterFormasPagamento(DESFRMDSCBNF, INDDSCGRCACOCMC)

            Return DatasetFormaPagamento
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0113552")> _
    Public Function AtualizarFormaPagamento(ByVal DatasetFormaPagamento As DatasetFormaPagamento) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarFormaPagamento(DatasetFormaPagamento)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0118902")> _
    Public Function ObterBaixaOPFornecedor(ByVal CODAGE As Decimal, _
                                           ByVal CODBCO As Decimal, _
                                           ByVal DATRCBORDPGT As Date, _
                                           ByVal NUMORDPGTFRN As Decimal, _
                                           ByVal NUMSEQORDPGT As Decimal) As DatasetBaixaOPFornecedor
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetBaixaOPFornecedor As DatasetBaixaOPFornecedor

            AcordoComercialBP = New AcordoComercialBP
            DatasetBaixaOPFornecedor = AcordoComercialBP.ObterBaixaOPFornecedor(CODAGE, CODBCO, DATRCBORDPGT, NUMORDPGTFRN, NUMSEQORDPGT)

            Return DatasetBaixaOPFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0118902")> _
    Public Function ObterBaixasOPFornecedor(ByVal CODAGE As Decimal, _
                                            ByVal CODBCO As Decimal, _
                                            ByVal CODEMP As Decimal, _
                                            ByVal CODFILEMP As Decimal, _
                                            ByVal CODPMS As Decimal, _
                                            ByVal DATLMTCNTCRR As Date, _
                                            ByVal DATLMTCNTCRRInicial As Date, _
                                            ByVal DATLMTCNTCRRFinal As Date, _
                                            ByVal NUMORDPGTFRN As Decimal, _
                                            ByVal NUMPNDFRN As Decimal, _
                                            ByVal NUMSEQORDPGT As Decimal) As DatasetBaixaOPFornecedor
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetBaixaOPFornecedor As DatasetBaixaOPFornecedor

            AcordoComercialBP = New AcordoComercialBP
            DatasetBaixaOPFornecedor = AcordoComercialBP.ObterBaixasOPFornecedor(CODAGE, CODBCO, CODEMP, CODFILEMP, CODPMS, DATLMTCNTCRR, DATLMTCNTCRRInicial, DATLMTCNTCRRFinal, NUMORDPGTFRN, NUMPNDFRN, NUMSEQORDPGT)

            Return DatasetBaixaOPFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0118902")> _
    Public Function AtualizarBaixaOPFornecedor(ByVal DatasetBaixaOPFornecedor As DatasetBaixaOPFornecedor) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarBaixaOPFornecedor(DatasetBaixaOPFornecedor)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0118899")> _
    Public Function ObterBaixaCHFornecedor(ByVal CODAGE As Decimal, _
                                           ByVal CODBCO As Decimal, _
                                           ByVal DATRCBCHQ As Date, _
                                           ByVal NUMCHQ As Decimal, _
                                           ByVal NUMSEQPGT As Decimal) As DatasetBaixaCHFornecedor
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetBaixaCHFornecedor As DatasetBaixaCHFornecedor

            AcordoComercialBP = New AcordoComercialBP
            DatasetBaixaCHFornecedor = AcordoComercialBP.ObterBaixaCHFornecedor(CODAGE, CODBCO, DATRCBCHQ, NUMCHQ, NUMSEQPGT)

            Return DatasetBaixaCHFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0118899")> _
    Public Function ObterBaixasCHFornecedor(ByVal CODAGE As Decimal, _
                                            ByVal CODBCO As Decimal, _
                                            ByVal CODEMP As Decimal, _
                                            ByVal CODFILEMP As Decimal, _
                                            ByVal CODPMS As Decimal, _
                                            ByVal DATPRVRCBPMS As Date, _
                                            ByVal DATPRVRCBPMSInicial As Date, _
                                            ByVal DATPRVRCBPMSFinal As Date, _
                                            ByVal NUMCHQ As Decimal, _
                                            ByVal NUMSEQPGT As Decimal) As DatasetBaixaCHFornecedor
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetBaixaCHFornecedor As DatasetBaixaCHFornecedor

            AcordoComercialBP = New AcordoComercialBP
            DatasetBaixaCHFornecedor = AcordoComercialBP.ObterBaixasCHFornecedor(CODAGE, CODBCO, CODEMP, CODFILEMP, CODPMS, DATPRVRCBPMS, DATPRVRCBPMSInicial, DATPRVRCBPMSFinal, NUMCHQ, NUMSEQPGT)

            Return DatasetBaixaCHFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0118899")> _
    Public Function AtualizarBaixaCHFornecedor(ByVal DatasetBaixaCHFornecedor As DatasetBaixaCHFornecedor) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarBaixaCHFornecedor(DatasetBaixaCHFornecedor)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0118880")> _
    Public Function ObterOPRecebidaFornecedor(ByVal CODAGE As Decimal, _
                                              ByVal CODBCO As Decimal, _
                                              ByVal DATRCBORDPGT As Date, _
                                              ByVal NUMORDPGTFRN As Decimal) As DatasetOPRecebidaFornecedor
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetOPRecebidaFornecedor As DatasetOPRecebidaFornecedor

            AcordoComercialBP = New AcordoComercialBP
            DatasetOPRecebidaFornecedor = AcordoComercialBP.ObterOPRecebidaFornecedor(CODAGE, CODBCO, DATRCBORDPGT, NUMORDPGTFRN)

            Return DatasetOPRecebidaFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0118880")> _
    Public Function ObterOPsRecebidaFornecedor(ByVal CODAGE As Decimal, _
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
                                               ByVal TIPORIORDPGTFRN As Decimal) As DatasetOPRecebidaFornecedor
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetOPRecebidaFornecedor As DatasetOPRecebidaFornecedor

            AcordoComercialBP = New AcordoComercialBP
            DatasetOPRecebidaFornecedor = AcordoComercialBP.ObterOPsRecebidaFornecedor(CODAGE, CODBCO, CODFRN, DATRCBORDPGT, DATRCBORDPGTInicial, DATRCBORDPGTFinal, DATTRNORDPGTFRN, DATTRNORDPGTFRNInicial, DATTRNORDPGTFRNFinal, DATULTPMSORD, DATULTPMSORDInicial, DATULTPMSORDFinal, IncluirDATULTPMSORDNulo, DESHSTDPSIDTFRN, NUMORDPGTFRN, NUMORDPGTORIFRN, TIPOPEBXAORDPGTFRN, TIPORIORDPGTFRN)

            Return DatasetOPRecebidaFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0118880")> _
    Public Function AtualizarOPRecebidaFornecedor(ByVal DatasetOPRecebidaFornecedor As DatasetOPRecebidaFornecedor) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarOPRecebidaFornecedor(DatasetOPRecebidaFornecedor)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0118872")> _
    Public Function ObterCHRecebidoFornecedor(ByVal CODAGE As Decimal, _
                                              ByVal CODBCO As Decimal, _
                                              ByVal DATRCBCHQ As Date, _
                                              ByVal NUMCHQ As Decimal) As DatasetCHRecebidoFornecedor
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetCHRecebidoFornecedor As DatasetCHRecebidoFornecedor

            AcordoComercialBP = New AcordoComercialBP
            DatasetCHRecebidoFornecedor = AcordoComercialBP.ObterCHRecebidoFornecedor(CODAGE, CODBCO, DATRCBCHQ, NUMCHQ)

            Return DatasetCHRecebidoFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0118872")> _
    Public Function ObterCHsRecebidoFornecedor(ByVal CODAGE As Decimal, _
                                               ByVal CODBCO As Decimal, _
                                               ByVal CODFRN As Decimal, _
                                               ByVal DATRCBCHQ As Date, _
                                               ByVal DATRCBCHQInicial As Date, _
                                               ByVal DATRCBCHQFinal As Date, _
                                               ByVal IncluirDATULTPMSCHQNulo As Int16, _
                                               ByVal NUMCHQ As Decimal) As DatasetCHRecebidoFornecedor
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetCHRecebidoFornecedor As DatasetCHRecebidoFornecedor

            AcordoComercialBP = New AcordoComercialBP
            DatasetCHRecebidoFornecedor = AcordoComercialBP.ObterCHsRecebidoFornecedor(CODAGE, CODBCO, CODFRN, DATRCBCHQ, DATRCBCHQInicial, DATRCBCHQFinal, IncluirDATULTPMSCHQNulo, NUMCHQ)

            Return DatasetCHRecebidoFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0118872")> _
    Public Function AtualizarCHRecebidoFornecedor(ByVal DatasetCHRecebidoFornecedor As DatasetCHRecebidoFornecedor) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarCHRecebidoFornecedor(DatasetCHRecebidoFornecedor)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0118082")> _
    Public Function ObterSituacaoAcordo(ByVal CODSITPMS As Decimal) As DatasetSituacaoAcordo
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetSituacaoAcordo As DatasetSituacaoAcordo

            AcordoComercialBP = New AcordoComercialBP
            DatasetSituacaoAcordo = AcordoComercialBP.ObterSituacaoAcordo(CODSITPMS)

            Return DatasetSituacaoAcordo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0118082")> _
    Public Function ObterSituacoesAcordo(ByVal DESSITPMS As String) As DatasetSituacaoAcordo
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetSituacaoAcordo As DatasetSituacaoAcordo

            AcordoComercialBP = New AcordoComercialBP
            DatasetSituacaoAcordo = AcordoComercialBP.ObterSituacoesAcordo(DESSITPMS)

            Return DatasetSituacaoAcordo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0118082")> _
    Public Function AtualizarSituacaoAcordo(ByVal DatasetSituacaoAcordo As DatasetSituacaoAcordo) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarSituacaoAcordo(DatasetSituacaoAcordo)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0118074")> _
    Public Function ObterParametroGestaoAcaoComercial(ByVal CODEMP As Decimal, _
                                                      ByVal CODFILEMP As Decimal) As DatasetParametroGestaoAcaoComercial
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetParametroGestaoAcaoComercial As DatasetParametroGestaoAcaoComercial

            AcordoComercialBP = New AcordoComercialBP
            DatasetParametroGestaoAcaoComercial = AcordoComercialBP.ObterParametroGestaoAcaoComercial(CODEMP, CODFILEMP)

            Return DatasetParametroGestaoAcaoComercial
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0118074")> _
    Public Function ObterParametrosGestaoAcaoComercial(ByVal CODEMP As Decimal, _
                                                       ByVal CODFILEMP As Decimal) As DatasetParametroGestaoAcaoComercial
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetParametroGestaoAcaoComercial As DatasetParametroGestaoAcaoComercial

            AcordoComercialBP = New AcordoComercialBP
            DatasetParametroGestaoAcaoComercial = AcordoComercialBP.ObterParametrosGestaoAcaoComercial(CODEMP, CODFILEMP)

            Return DatasetParametroGestaoAcaoComercial
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0118074")> _
    Public Function AtualizarParametroGestaoAcaoComercial(ByVal DatasetParametroGestaoAcaoComercial As DatasetParametroGestaoAcaoComercial) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarParametroGestaoAcaoComercial(DatasetParametroGestaoAcaoComercial)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0118058")> _
    Public Function ObterAcordo(ByVal CODEMP As Decimal, _
                                ByVal CODFILEMP As Decimal, _
                                ByVal CODPMS As Decimal, _
                                ByVal DATNGCPMS As Date) As DatasetAcordo

        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetAcordo As DatasetAcordo

            AcordoComercialBP = New AcordoComercialBP
            DatasetAcordo = AcordoComercialBP.ObterAcordo(CODEMP, CODFILEMP, CODPMS, DATNGCPMS)

            Return DatasetAcordo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna os centro de custos.")> _
    Public Function ObterCentroCusto(ByVal codCentroCusto As String, ByVal desCentroCusto As String) As DatasetAcordo

        Try
            Dim BP As New AcordoComercialBP
            Dim dstAcordo As DatasetAcordo

            dstAcordo = BP.ObterCentroCusto(codCentroCusto, desCentroCusto)

            Return dstAcordo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0118058")> _
    Public Function ObterAcordos(ByVal CODEMP As Decimal, _
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
                                 ByVal NUMPEDCMP As Decimal) As DatasetAcordo
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetAcordo As DatasetAcordo

            AcordoComercialBP = New AcordoComercialBP
            DatasetAcordo = AcordoComercialBP.ObterAcordos(CODEMP, CODFILEMP, CODFRN, CODPMS, CODSITPMS, DATCADPMS, DATCADPMSInicial, DATCADPMSFinal, DATCNCPED, DATCNCPEDInicial, DATCNCPEDFinal, DATEFTPMS, DATEFTPMSInicial, DATEFTPMSFinal, DATNGCPMS, DATNGCPMSInicial, DATNGCPMSFinal, NOMCTOFRN, NUMPEDCMP)

            Return DatasetAcordo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Este método retorna os Acordos do TIPO AC filtrando pelo Fornecedor.")> _
    Public Function ObterAcordosPendente(ByVal CODFRN As Decimal) As DatasetAcordo
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim DatasetAcordo As DatasetAcordo

            DatasetAcordo = AcordoComercialBP.ObterAcordosPendente(CODFRN)

            Return DatasetAcordo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0118058")> _
    Public Function AtualizarAcordo(ByVal DatasetAcordo As DatasetAcordo) As Decimal
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            Return AcordoComercialBP.AtualizarAcordo(DatasetAcordo)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0151799")> _
    Public Function ObterTituloPagamentoContrato(ByVal TIPALCVBAFRN As Decimal) As DatasetTituloPagamentoContrato
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetTituloPagamentoContrato As DatasetTituloPagamentoContrato

            AcordoComercialBP = New AcordoComercialBP
            DatasetTituloPagamentoContrato = AcordoComercialBP.ObterTituloPagamentoContrato(TIPALCVBAFRN)

            Return DatasetTituloPagamentoContrato
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0151799")> _
    Public Function ObterTitulosPagamentoContrato(ByVal DESALCVBAFRN As String) As DatasetTituloPagamentoContrato
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetTituloPagamentoContrato As DatasetTituloPagamentoContrato

            AcordoComercialBP = New AcordoComercialBP
            DatasetTituloPagamentoContrato = AcordoComercialBP.ObterTitulosPagamentoContrato(DESALCVBAFRN)

            Return DatasetTituloPagamentoContrato
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0151799")> _
    Public Function AtualizarTituloPagamentoContrato(ByVal DatasetTituloPagamentoContrato As DatasetTituloPagamentoContrato) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarTituloPagamentoContrato(DatasetTituloPagamentoContrato)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0129440")> _
    Public Function ObterParametroProrrogacaoVencimento(ByVal NUMCTTFRN As Decimal) As DatasetParametroProrrogacaoVencimento
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetParametroProrrogacaoVencimento As DatasetParametroProrrogacaoVencimento

            AcordoComercialBP = New AcordoComercialBP
            DatasetParametroProrrogacaoVencimento = AcordoComercialBP.ObterParametroProrrogacaoVencimento(NUMCTTFRN)

            Return DatasetParametroProrrogacaoVencimento
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0129440")> _
    Public Function ObterParametrosProrrogacaoVencimento(ByVal DESDATREFPGC As String, _
                                                         ByVal NUMCTTFRN As Decimal) As DatasetParametroProrrogacaoVencimento
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetParametroProrrogacaoVencimento As DatasetParametroProrrogacaoVencimento

            AcordoComercialBP = New AcordoComercialBP
            DatasetParametroProrrogacaoVencimento = AcordoComercialBP.ObterParametrosProrrogacaoVencimento(DESDATREFPGC, NUMCTTFRN)

            Return DatasetParametroProrrogacaoVencimento
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0129440")> _
    Public Function AtualizarParametroProrrogacaoVencimento(ByVal DatasetParametroProrrogacaoVencimento As DatasetParametroProrrogacaoVencimento) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarParametroProrrogacaoVencimento(DatasetParametroProrrogacaoVencimento)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0144946")> _
    Public Function ObterTransferenciaVerbasEntreEmpenhos(ByVal CODFRNDSNTRNVBA As Decimal, _
                                                          ByVal CODFRNORITRNVBA As Decimal, _
                                                          ByVal CODGDCDSNTRNVBA As String, _
                                                          ByVal CODGDCORITRNVBA As String, _
                                                          ByVal DATREFLMT As Date, _
                                                          ByVal NUMSEQLMTDSNTRNVBA As Decimal, _
                                                          ByVal NUMSEQLMTORITRNVBA As Decimal, _
                                                          ByVal TIPDSNDSCBNFDSNTRN As Decimal, _
                                                          ByVal TIPDSNDSCBNFORITRN As Decimal) As DatasetTransferenciaVerbasEntreEmpenhos
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetTransferenciaVerbasEntreEmpenhos As DatasetTransferenciaVerbasEntreEmpenhos

            AcordoComercialBP = New AcordoComercialBP
            DatasetTransferenciaVerbasEntreEmpenhos = AcordoComercialBP.ObterTransferenciaVerbasEntreEmpenhos(CODFRNDSNTRNVBA, CODFRNORITRNVBA, CODGDCDSNTRNVBA, CODGDCORITRNVBA, DATREFLMT, NUMSEQLMTDSNTRNVBA, NUMSEQLMTORITRNVBA, TIPDSNDSCBNFDSNTRN, TIPDSNDSCBNFORITRN)

            Return DatasetTransferenciaVerbasEntreEmpenhos
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0144946")> _
    Public Function ObterTransferenciasVerbasEntreEmpenhos(ByVal CODFRNDSNTRNVBA As Decimal, _
                                                           ByVal CODFRNORITRNVBA As Decimal, _
                                                           ByVal CODGDCDSNTRNVBA As String, _
                                                           ByVal CODGDCORITRNVBA As String, _
                                                           ByVal DATREFLMT As Date, _
                                                           ByVal DATREFLMTInicial As Date, _
                                                           ByVal DATREFLMTFinal As Date, _
                                                           ByVal NUMSEQLMTDSNTRNVBA As Decimal, _
                                                           ByVal NUMSEQLMTORITRNVBA As Decimal, _
                                                           ByVal TIPDSNDSCBNFDSNTRN As Decimal, _
                                                           ByVal TIPDSNDSCBNFORITRN As Decimal) As DatasetTransferenciaVerbasEntreEmpenhos
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetTransferenciaVerbasEntreEmpenhos As DatasetTransferenciaVerbasEntreEmpenhos

            AcordoComercialBP = New AcordoComercialBP
            DatasetTransferenciaVerbasEntreEmpenhos = AcordoComercialBP.ObterTransferenciasVerbasEntreEmpenhos(CODFRNDSNTRNVBA, CODFRNORITRNVBA, CODGDCDSNTRNVBA, CODGDCORITRNVBA, DATREFLMT, DATREFLMTInicial, DATREFLMTFinal, NUMSEQLMTDSNTRNVBA, NUMSEQLMTORITRNVBA, TIPDSNDSCBNFDSNTRN, TIPDSNDSCBNFORITRN)

            Return DatasetTransferenciaVerbasEntreEmpenhos
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0144946")> _
    Public Function AtualizarTransferenciaVerbasEntreEmpenhos(ByVal DatasetTransferenciaVerbasEntreEmpenhos As DatasetTransferenciaVerbasEntreEmpenhos) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarTransferenciaVerbasEntreEmpenhos(DatasetTransferenciaVerbasEntreEmpenhos)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0103409")> _
    Public Function ObterEmpresa(ByVal CODEMP As Decimal) As DatasetEmpresa
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetEmpresa As DatasetEmpresa

            AcordoComercialBP = New AcordoComercialBP
            DatasetEmpresa = AcordoComercialBP.ObterEmpresa(CODEMP)

            Return DatasetEmpresa
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0103409")> _
    Public Function ObterEmpresas(ByVal NOMEMP As String) As DatasetEmpresa
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetEmpresa As DatasetEmpresa

            AcordoComercialBP = New AcordoComercialBP
            DatasetEmpresa = AcordoComercialBP.ObterEmpresas(NOMEMP)

            Return DatasetEmpresa
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0103409")> _
    Public Function AtualizarEmpresa(ByVal DatasetEmpresa As DatasetEmpresa) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarEmpresa(DatasetEmpresa)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0135041")> _
    Public Function ObterTipoTransferenciaXDivisaoCompras(ByVal CODDIVCMP As Decimal, _
                                                          ByVal CODTIPTRNVLRACOCMC As Decimal) As DatasetTipoTransferenciaXDivisaoCompras
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetTipoTransferenciaXDivisaoCompras As DatasetTipoTransferenciaXDivisaoCompras

            AcordoComercialBP = New AcordoComercialBP
            DatasetTipoTransferenciaXDivisaoCompras = AcordoComercialBP.ObterTipoTransferenciaXDivisaoCompras(CODDIVCMP, CODTIPTRNVLRACOCMC)

            Return DatasetTipoTransferenciaXDivisaoCompras
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0135041")> _
    Public Function ObterTiposTransferenciasXDivisaoCompras(ByVal CODDIVCMP As Decimal, _
                                                            ByVal CODTIPTRNVLRACOCMC As Decimal) As DatasetTipoTransferenciaXDivisaoCompras
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetTipoTransferenciaXDivisaoCompras As DatasetTipoTransferenciaXDivisaoCompras

            AcordoComercialBP = New AcordoComercialBP
            DatasetTipoTransferenciaXDivisaoCompras = AcordoComercialBP.ObterTiposTransferenciasXDivisaoCompras(CODDIVCMP, CODTIPTRNVLRACOCMC)

            Return DatasetTipoTransferenciaXDivisaoCompras
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0135041")> _
    Public Function AtualizarTipoTransferenciaXDivisaoCompras(ByVal DatasetTipoTransferenciaXDivisaoCompras As DatasetTipoTransferenciaXDivisaoCompras) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarTipoTransferenciaXDivisaoCompras(DatasetTipoTransferenciaXDivisaoCompras)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0151810")> _
    Public Function ObterRequisicaoAlocacaoVerbas(ByVal CODREQALCVBAFRN As Decimal) As DatasetRequisicaoAlocacaoVerbas
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetRequisicaoAlocacaoVerbas As DatasetRequisicaoAlocacaoVerbas

            AcordoComercialBP = New AcordoComercialBP
            DatasetRequisicaoAlocacaoVerbas = AcordoComercialBP.ObterRequisicaoAlocacaoVerbas(CODREQALCVBAFRN)

            Return DatasetRequisicaoAlocacaoVerbas
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0151810")> _
    Public Function ObterRequisicoesAlocacaoVerbas(ByVal CODFNCATUAPVALCVBA As Decimal, _
                                                   ByVal CODFNCCADALCVBAFRN As Decimal, _
                                                   ByVal CODSTAALCVBAFRN As Decimal) As DatasetRequisicaoAlocacaoVerbas
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetRequisicaoAlocacaoVerbas As DatasetRequisicaoAlocacaoVerbas

            AcordoComercialBP = New AcordoComercialBP
            DatasetRequisicaoAlocacaoVerbas = AcordoComercialBP.ObterRequisicoesAlocacaoVerbas(CODFNCATUAPVALCVBA, CODFNCCADALCVBAFRN, CODSTAALCVBAFRN)

            Return DatasetRequisicaoAlocacaoVerbas
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0151810")> _
    Public Function AtualizarRequisicaoAlocacaoVerbas(ByVal DatasetRequisicaoAlocacaoVerbas As DatasetRequisicaoAlocacaoVerbas) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarRequisicaoAlocacaoVerbas(DatasetRequisicaoAlocacaoVerbas)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0109059")> _
    Public Function ObterEmpenho(ByVal TIPDSNDSCBNF As Decimal) As DatasetEmpenho
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetEmpenho As DatasetEmpenho

            AcordoComercialBP = New AcordoComercialBP
            DatasetEmpenho = AcordoComercialBP.ObterEmpenho(TIPDSNDSCBNF)

            Return DatasetEmpenho
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0109059")> _
    Public Function ObterEmpenhos(ByVal CODCCP As String, _
                                  ByVal CODCENCST As String, _
                                  ByVal CODCNTCTBGLM As String, _
                                  ByVal CODFLUAPVACOCMC As Decimal, _
                                  ByVal DESDSNDSCBNF As String, _
                                  ByVal INDTIPDSNRCTCSTMER As Decimal) As DatasetEmpenho
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetEmpenho As DatasetEmpenho

            AcordoComercialBP = New AcordoComercialBP
            DatasetEmpenho = AcordoComercialBP.ObterEmpenhos(CODCCP, CODCENCST, CODCNTCTBGLM, CODFLUAPVACOCMC, DESDSNDSCBNF, INDTIPDSNRCTCSTMER)

            Return DatasetEmpenho
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0109059")> _
    Public Sub AtualizarEmpenho(ByVal DatasetEmpenho As DatasetEmpenho)
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarEmpenho(DatasetEmpenho)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Sub

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0136390")> _
    Public Function ObterTipoOperacaoBaixaOP(ByVal TIPOPEBXAORDPGTFRN As Decimal) As DatasetTipoOperacaoBaixaOP
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetTipoOperacaoBaixaOP As DatasetTipoOperacaoBaixaOP

            AcordoComercialBP = New AcordoComercialBP
            DatasetTipoOperacaoBaixaOP = AcordoComercialBP.ObterTipoOperacaoBaixaOP(TIPOPEBXAORDPGTFRN)

            Return DatasetTipoOperacaoBaixaOP
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0136390")> _
    Public Function ObterTiposOperacoesBaixaOP(ByVal CODTIPLMT As Decimal, _
                                               ByVal CODTIPLMTPNDCOMDVL As Decimal, _
                                               ByVal CODTIPLMTPNDSEMDVL As Decimal, _
                                               ByVal DESTIPOPEBXAORDPGT As String, _
                                               ByVal INDTIPOPEBXAORDPGT As Decimal, _
                                               ByVal INDTIPOPEQBRORDPGT As Decimal, _
                                               ByVal INDTIPOPETRNORDPGT As Decimal, _
                                               ByVal TIPOPEBXAORDPGTFRN As Decimal, _
                                               ByVal TIPORIORDPGTFRN As Decimal) As DatasetTipoOperacaoBaixaOP
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetTipoOperacaoBaixaOP As DatasetTipoOperacaoBaixaOP

            AcordoComercialBP = New AcordoComercialBP
            DatasetTipoOperacaoBaixaOP = AcordoComercialBP.ObterTiposOperacoesBaixaOP(CODTIPLMT, CODTIPLMTPNDCOMDVL, CODTIPLMTPNDSEMDVL, DESTIPOPEBXAORDPGT, INDTIPOPEBXAORDPGT, INDTIPOPEQBRORDPGT, INDTIPOPETRNORDPGT, TIPOPEBXAORDPGTFRN, TIPORIORDPGTFRN)

            Return DatasetTipoOperacaoBaixaOP
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0136390")> _
    Public Function AtualizarTipoOperacaoBaixaOP(ByVal DatasetTipoOperacaoBaixaOP As DatasetTipoOperacaoBaixaOP) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarTipoOperacaoBaixaOP(DatasetTipoOperacaoBaixaOP)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0135050")> _
    Public Function ObterTipoTransferenciaXFornecedor(ByVal CODFRN As Decimal, _
                                                      ByVal CODTIPTRNVLRACOCMC As Decimal) As DatasetTipoTransferenciaXFornecedor
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetTipoTransferenciaXFornecedor As DatasetTipoTransferenciaXFornecedor

            AcordoComercialBP = New AcordoComercialBP
            DatasetTipoTransferenciaXFornecedor = AcordoComercialBP.ObterTipoTransferenciaXFornecedor(CODFRN, CODTIPTRNVLRACOCMC)

            Return DatasetTipoTransferenciaXFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0135050")> _
    Public Function ObterTiposTransferenciasXFornecedor(ByVal CODFRN As Decimal, _
                                                        ByVal CODTIPTRNVLRACOCMC As Decimal) As DatasetTipoTransferenciaXFornecedor
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetTipoTransferenciaXFornecedor As DatasetTipoTransferenciaXFornecedor

            AcordoComercialBP = New AcordoComercialBP
            DatasetTipoTransferenciaXFornecedor = AcordoComercialBP.ObterTiposTransferenciasXFornecedor(CODFRN, CODTIPTRNVLRACOCMC)

            Return DatasetTipoTransferenciaXFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0135050")> _
    Public Function AtualizarTipoTransferenciaXFornecedor(ByVal DatasetTipoTransferenciaXFornecedor As DatasetTipoTransferenciaXFornecedor) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarTipoTransferenciaXFornecedor(DatasetTipoTransferenciaXFornecedor)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0135033")> _
    Public Function ObterTipoTransferenciaValoresAcoesComerciais(ByVal CODTIPTRNVLRACOCMC As Decimal) As DatasetTipoTransferenciaValoresAcoesComerciais
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetTipoTransferenciaValoresAcoesComerciais As DatasetTipoTransferenciaValoresAcoesComerciais

            AcordoComercialBP = New AcordoComercialBP
            DatasetTipoTransferenciaValoresAcoesComerciais = AcordoComercialBP.ObterTipoTransferenciaValoresAcoesComerciais(CODTIPTRNVLRACOCMC)

            Return DatasetTipoTransferenciaValoresAcoesComerciais
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0135033")> _
    Public Function ObterTiposTransferenciasValoresAcoesComerciais(ByVal CODTIPTRNVLRACOCMC As Decimal, _
                                                                   ByVal DESTIPTRNVLRACOCMC As String, _
                                                                   ByVal TIPDSNDSCBNF As Decimal) As DatasetTipoTransferenciaValoresAcoesComerciais
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetTipoTransferenciaValoresAcoesComerciais As DatasetTipoTransferenciaValoresAcoesComerciais

            AcordoComercialBP = New AcordoComercialBP
            DatasetTipoTransferenciaValoresAcoesComerciais = AcordoComercialBP.ObterTiposTransferenciasValoresAcoesComerciais(CODTIPTRNVLRACOCMC, DESTIPTRNVLRACOCMC, TIPDSNDSCBNF)

            Return DatasetTipoTransferenciaValoresAcoesComerciais
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Verifica se existe Empenho relacionado. Entidade principal:T0135033")> _
    Public Function ExisteEmpenhoRelacionado(ByVal TIPDSNDSCBNF As Decimal, _
                                             ByVal NOMACSUSRSIS As String) As Boolean
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Return AcordoComercialBP.ExisteEmpenhoRelacionado(TIPDSNDSCBNF, NOMACSUSRSIS)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0135033")> _
    Public Function AtualizarTipoTransferenciaValoresAcoesComerciais(ByVal DatasetTipoTransferenciaValoresAcoesComerciais As DatasetTipoTransferenciaValoresAcoesComerciais) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarTipoTransferenciaValoresAcoesComerciais(DatasetTipoTransferenciaValoresAcoesComerciais)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:HSTAVLCTTFRNCLI")> _
    Public Function ObterHistoricoAvalicaoContratoPorClienteSmart(ByVal CODCLI As Decimal, _
                                                                  ByVal CODEDEABGMIX As Decimal, _
                                                                  ByVal CODFXAAVL As Decimal, _
                                                                  ByVal DATAPUPODCTTFRN As Date, _
                                                                  ByVal DATREFAPU As Date, _
                                                                  ByVal NUMCSLCTTFRN As Decimal, _
                                                                  ByVal NUMCTTFRN As Decimal, _
                                                                  ByVal NUMCTTFRNAPUPOD As Decimal) As DatasetHistoricoAvalicaoContratoPorClienteSmart
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetHistoricoAvalicaoContratoPorClienteSmart As DatasetHistoricoAvalicaoContratoPorClienteSmart

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetHistoricoAvalicaoContratoPorClienteSmart = AcordoFornecimentoBP.ObterHistoricoAvalicaoContratoPorClienteSmart(CODCLI, CODEDEABGMIX, CODFXAAVL, DATAPUPODCTTFRN, DATREFAPU, NUMCSLCTTFRN, NUMCTTFRN, NUMCTTFRNAPUPOD)

            Return DatasetHistoricoAvalicaoContratoPorClienteSmart
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalHSTAVLCTTFRNCLI")> _
    Public Function AtualizarHistoricoAvalicaoContratoPorClienteSmart(ByVal DatasetHistoricoAvalicaoContratoPorClienteSmart As DatasetHistoricoAvalicaoContratoPorClienteSmart) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarHistoricoAvalicaoContratoPorClienteSmart(DatasetHistoricoAvalicaoContratoPorClienteSmart)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0125003")> _
    Public Function ObterTipoBaseCalculo(ByVal TIPBSECAL As Decimal) As DatasetTipoBaseCalculo
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetTipoBaseCalculo As DatasetTipoBaseCalculo

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetTipoBaseCalculo = AcordoFornecimentoBP.ObterTipoBaseCalculo(TIPBSECAL)

            Return DatasetTipoBaseCalculo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0125003")> _
    Public Function ObterTiposBaseCalculo(ByVal DESBSECAL As String) As DatasetTipoBaseCalculo
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetTipoBaseCalculo As DatasetTipoBaseCalculo

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetTipoBaseCalculo = AcordoFornecimentoBP.ObterTiposBaseCalculo(DESBSECAL)

            Return DatasetTipoBaseCalculo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0125003")> _
    Public Function AtualizarTipoBaseCalculo(ByVal DatasetTipoBaseCalculo As DatasetTipoBaseCalculo) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarTipoBaseCalculo(DatasetTipoBaseCalculo)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0125011")> _
    Public Function ObterTipoAbrangenciaMix(ByVal TIPEDEABGMIX As Decimal) As DatasetTipoAbrangenciaMix
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetTipoAbrangenciaMix As DatasetTipoAbrangenciaMix

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetTipoAbrangenciaMix = AcordoFornecimentoBP.ObterTipoAbrangenciaMix(TIPEDEABGMIX)

            Return DatasetTipoAbrangenciaMix
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0125011")> _
    Public Function ObterTiposAbrangenciaMix(ByVal DESEDEABGMIX As String) As DatasetTipoAbrangenciaMix
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetTipoAbrangenciaMix As DatasetTipoAbrangenciaMix

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetTipoAbrangenciaMix = AcordoFornecimentoBP.ObterTiposAbrangenciaMix(DESEDEABGMIX)

            Return DatasetTipoAbrangenciaMix
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0125011")> _
    Public Function AtualizarTipoAbrangenciaMix(ByVal DatasetTipoAbrangenciaMix As DatasetTipoAbrangenciaMix) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarTipoAbrangenciaMix(DatasetTipoAbrangenciaMix)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0124988")> _
    Public Function ObterContratoXPeriodo(ByVal DATINIPOD As Date, _
                                          ByVal NUMCSLCTTFRN As Decimal, _
                                          ByVal NUMCTTFRN As Decimal, _
                                          ByVal NUMREFPOD As Decimal, _
                                          ByVal TIPPODCTTFRN As Decimal) As DatasetContratoXPeriodo
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetContratoXPeriodo As DatasetContratoXPeriodo

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetContratoXPeriodo = AcordoFornecimentoBP.ObterContratoXPeriodo(DATINIPOD, NUMCSLCTTFRN, NUMCTTFRN, NUMREFPOD, TIPPODCTTFRN)

            Return DatasetContratoXPeriodo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0124988")> _
    Public Function ObterContratosXPeriodos(ByVal NUMCSLCTTFRN As Decimal, _
                                            ByVal NUMCTTFRN As Decimal, _
                                            ByVal NUMREFPOD As Decimal, _
                                            ByVal TIPPODCTTFRN As Decimal) As DatasetContratoXPeriodo
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetContratoXPeriodo As DatasetContratoXPeriodo

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetContratoXPeriodo = AcordoFornecimentoBP.ObterContratosXPeriodos(NUMCSLCTTFRN, NUMCTTFRN, NUMREFPOD, TIPPODCTTFRN)

            Return DatasetContratoXPeriodo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0124988")> _
    Public Function AtualizarContratoXPeriodo(ByVal DatasetContratoXPeriodo As DatasetContratoXPeriodo) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarContratoXPeriodo(DatasetContratoXPeriodo)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0133243")> _
    Public Function ObterBonificacaoEmitir(ByVal CODCPR As Decimal, _
                                           ByVal CODEDEABGMIX As Decimal, _
                                           ByVal CODFRN As Decimal, _
                                           ByVal DATREFAPU As Date, _
                                           ByVal NUMCSLCTTFRN As Decimal, _
                                           ByVal NUMCTTFRN As Decimal, _
                                           ByVal NUMREFPOD As Decimal, _
                                           ByVal TIPEDEABGMIX As Decimal, _
                                           ByVal TIPPODCTTFRN As Decimal) As DatasetBonificacaoEmitir
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetBonificacaoEmitir As DatasetBonificacaoEmitir

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetBonificacaoEmitir = AcordoFornecimentoBP.ObterBonificacaoEmitir(CODCPR, CODEDEABGMIX, CODFRN, DATREFAPU, NUMCSLCTTFRN, NUMCTTFRN, NUMREFPOD, TIPEDEABGMIX, TIPPODCTTFRN)

            Return DatasetBonificacaoEmitir
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0133243")> _
    Public Function ObterBonificacoesEmitir(ByVal CODCPR As Decimal, _
                                            ByVal CODEDEABGMIX As Decimal, _
                                            ByVal CODFRN As Decimal, _
                                            ByVal NUMCSLCTTFRN As Decimal, _
                                            ByVal NUMCTTFRN As Decimal, _
                                            ByVal NUMREFPOD As Decimal, _
                                            ByVal TIPEDEABGMIX As Decimal, _
                                            ByVal TIPPODCTTFRN As Decimal) As DatasetBonificacaoEmitir
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetBonificacaoEmitir As DatasetBonificacaoEmitir

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetBonificacaoEmitir = AcordoFornecimentoBP.ObterBonificacoesEmitir(CODCPR, CODEDEABGMIX, CODFRN, NUMCSLCTTFRN, NUMCTTFRN, NUMREFPOD, TIPEDEABGMIX, TIPPODCTTFRN)

            Return DatasetBonificacaoEmitir
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0133243")> _
    Public Function AtualizarBonificacaoEmitir(ByVal DatasetBonificacaoEmitir As DatasetBonificacaoEmitir) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarBonificacaoEmitir(DatasetBonificacaoEmitir)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Efetivação das baixas de Pendências e Acordos")> _
    Public Function EfetivarBaixaAcaoComercialPendencias(ByRef dsAcordo As DatasetAcordo, ByVal Cod_Acesso As String) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP = _
                New AcordoComercialBP
            AcordoComercialBP.EfetivarBaixaAcaoComercialPendencias(dsAcordo, Cod_Acesso)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0135092")> _
    Public Function ObterTipoTransferenciaXUsuario(ByVal CODTIPTRNVLRACOCMC As Decimal, _
                                                   ByVal NOMACSUSRSIS As String) As DatasetTipoTransferenciaXUsuario
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetTipoTransferenciaXUsuario As DatasetTipoTransferenciaXUsuario

            AcordoComercialBP = New AcordoComercialBP
            DatasetTipoTransferenciaXUsuario = AcordoComercialBP.ObterTipoTransferenciaXUsuario(CODTIPTRNVLRACOCMC, NOMACSUSRSIS)

            Return DatasetTipoTransferenciaXUsuario
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0135092")> _
    Public Function ObterTiposTransferenciasXUsuario(ByVal CODTIPTRNVLRACOCMC As Decimal, _
                                                     ByVal NOMACSUSRSIS As String) As DatasetTipoTransferenciaXUsuario
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetTipoTransferenciaXUsuario As DatasetTipoTransferenciaXUsuario

            AcordoComercialBP = New AcordoComercialBP
            DatasetTipoTransferenciaXUsuario = AcordoComercialBP.ObterTiposTransferenciasXUsuario(CODTIPTRNVLRACOCMC, NOMACSUSRSIS)

            Return DatasetTipoTransferenciaXUsuario
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0135092")> _
    Public Function AtualizarTipoTransferenciaXUsuario(ByVal DatasetTipoTransferenciaXUsuario As DatasetTipoTransferenciaXUsuario) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarTipoTransferenciaXUsuario(DatasetTipoTransferenciaXUsuario)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0118104")> _
    Public Function ObterTipoPedidoCompraXEmpenho(ByVal TIPDSNDSCBNF As Decimal, _
                                                  ByVal TIPPEDCMP As Decimal) As DatasetTipoPedidoCompraXEmpenho
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetTipoPedidoCompraXEmpenho As DatasetTipoPedidoCompraXEmpenho

            AcordoComercialBP = New AcordoComercialBP
            DatasetTipoPedidoCompraXEmpenho = AcordoComercialBP.ObterTipoPedidoCompraXEmpenho(TIPDSNDSCBNF, TIPPEDCMP)

            Return DatasetTipoPedidoCompraXEmpenho
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0118104")> _
    Public Function ObterTiposPedidoCompraXEmpenho(ByVal TIPDSNDSCBNF As Decimal, _
                                                   ByVal TIPPEDCMP As Decimal) As DatasetTipoPedidoCompraXEmpenho
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetTipoPedidoCompraXEmpenho As DatasetTipoPedidoCompraXEmpenho

            AcordoComercialBP = New AcordoComercialBP
            DatasetTipoPedidoCompraXEmpenho = AcordoComercialBP.ObterTiposPedidoCompraXEmpenho(TIPDSNDSCBNF, TIPPEDCMP)

            Return DatasetTipoPedidoCompraXEmpenho
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0118104")> _
    Public Function AtualizarTipoPedidoCompraXEmpenho(ByVal DatasetTipoPedidoCompraXEmpenho As DatasetTipoPedidoCompraXEmpenho) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarTipoPedidoCompraXEmpenho(DatasetTipoPedidoCompraXEmpenho)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0100094")> _
   Public Function ObterValorMoeda(ByVal MESREF As Decimal, _
                                   ByVal TIPMOE As Decimal) As DatasetValorMoeda
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetValorMoeda As DatasetValorMoeda

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetValorMoeda = AcordoFornecimentoBP.ObterValorMoeda(MESREF, TIPMOE)

            Return DatasetValorMoeda
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0100094")> _
    Public Function AtualizarValorMoeda(ByVal DatasetValorMoeda As DatasetValorMoeda) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarValorMoeda(DatasetValorMoeda)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0101724")> _
       Public Function ObterMoeda(ByVal TIPMOE As Decimal) As DatasetMoeda
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetMoeda As DatasetMoeda

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetMoeda = AcordoFornecimentoBP.ObterMoeda(TIPMOE)

            Return DatasetMoeda
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0101724")> _
    Public Function ObterMoedas(ByVal DESTIPMOE As String) As DatasetMoeda
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetMoeda As DatasetMoeda

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetMoeda = AcordoFornecimentoBP.ObterMoedas(DESTIPMOE)

            Return DatasetMoeda
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0101724")> _
    Public Function AtualizarMoeda(ByVal DatasetMoeda As DatasetMoeda) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarMoeda(DatasetMoeda)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0138407")> _
    Public Function ObterTipoFormaPagamento(ByVal TIPFRMPGTCTTFRN As Decimal) As DatasetTipoFormaPagamento
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetTipoFormaPagamento As DatasetTipoFormaPagamento

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetTipoFormaPagamento = AcordoFornecimentoBP.ObterTipoFormaPagamento(TIPFRMPGTCTTFRN)

            Return DatasetTipoFormaPagamento
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0138407")> _
    Public Function ObterTiposFormaPagamento(ByVal DESTIPFRMPGTCTTFRN As String) As DatasetTipoFormaPagamento
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetTipoFormaPagamento As DatasetTipoFormaPagamento

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetTipoFormaPagamento = AcordoFornecimentoBP.ObterTiposFormaPagamento(DESTIPFRMPGTCTTFRN)

            Return DatasetTipoFormaPagamento
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0138407")> _
    Public Function AtualizarTipoFormaPagamento(ByVal DatasetTipoFormaPagamento As DatasetTipoFormaPagamento) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarTipoFormaPagamento(DatasetTipoFormaPagamento)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0138415")> _
     Public Function ObterTipoEncargoFinanceiro(ByVal TIPENCFINCTTFRN As Decimal) As DatasetTipoEncargoFinanceiro
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetTipoEncargoFinanceiro As DatasetTipoEncargoFinanceiro

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetTipoEncargoFinanceiro = AcordoFornecimentoBP.ObterTipoEncargoFinanceiro(TIPENCFINCTTFRN)

            Return DatasetTipoEncargoFinanceiro
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0138415")> _
    Public Function ObterTiposEncargoFinanceiro(ByVal DESTIPENCFINCTTFRN As String) As DatasetTipoEncargoFinanceiro
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetTipoEncargoFinanceiro As DatasetTipoEncargoFinanceiro

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetTipoEncargoFinanceiro = AcordoFornecimentoBP.ObterTiposEncargoFinanceiro(DESTIPENCFINCTTFRN)

            Return DatasetTipoEncargoFinanceiro
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0138415")> _
    Public Function AtualizarTipoEncargoFinanceiro(ByVal DatasetTipoEncargoFinanceiro As DatasetTipoEncargoFinanceiro) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarTipoEncargoFinanceiro(DatasetTipoEncargoFinanceiro)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0138423")> _
    Public Function ObterTipoAbrangencia(ByVal TIPABGTABPCOCTTFRN As Decimal) As DatasetTipoAbrangencia
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetTipoAbrangencia As DatasetTipoAbrangencia

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetTipoAbrangencia = AcordoFornecimentoBP.ObterTipoAbrangencia(TIPABGTABPCOCTTFRN)

            Return DatasetTipoAbrangencia
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0138423")> _
    Public Function ObterTiposAbrangencia(ByVal DESTIPABGTABPCOCTT As String) As DatasetTipoAbrangencia
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetTipoAbrangencia As DatasetTipoAbrangencia

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetTipoAbrangencia = AcordoFornecimentoBP.ObterTiposAbrangencia(DESTIPABGTABPCOCTT)

            Return DatasetTipoAbrangencia
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0138423")> _
    Public Function AtualizarTipoAbrangencia(ByVal DatasetTipoAbrangencia As DatasetTipoAbrangencia) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarTipoAbrangencia(DatasetTipoAbrangencia)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0138431")> _
    Public Function ObterTipoPagamento(ByVal TIPPGTNOTFSCCTTFRN As Decimal) As DatasetTipoPagamento
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetTipoPagamento As DatasetTipoPagamento

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetTipoPagamento = AcordoFornecimentoBP.ObterTipoPagamento(TIPPGTNOTFSCCTTFRN)

            Return DatasetTipoPagamento
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0138431")> _
    Public Function ObterTiposPagamento(ByVal DESTIPPGTNOTFSCCTT As String) As DatasetTipoPagamento
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetTipoPagamento As DatasetTipoPagamento

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetTipoPagamento = AcordoFornecimentoBP.ObterTiposPagamento(DESTIPPGTNOTFSCCTT)

            Return DatasetTipoPagamento
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0138431")> _
    Public Function AtualizarTipoPagamento(ByVal DatasetTipoPagamento As DatasetTipoPagamento) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarTipoPagamento(DatasetTipoPagamento)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0138440")> _
        Public Function ObterTipoFornecedor(ByVal TIPFRNCTTFRN As Decimal) As DatasetTipoFornecedor
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetTipoFornecedor As DatasetTipoFornecedor

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetTipoFornecedor = AcordoFornecimentoBP.ObterTipoFornecedor(TIPFRNCTTFRN)

            Return DatasetTipoFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0138440")> _
    Public Function ObterTiposFornecedor(ByVal DESTIPFRNCTTFRN As String) As DatasetTipoFornecedor
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetTipoFornecedor As DatasetTipoFornecedor

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetTipoFornecedor = AcordoFornecimentoBP.ObterTiposFornecedor(DESTIPFRNCTTFRN)

            Return DatasetTipoFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0138440")> _
    Public Function AtualizarTipoFornecedor(ByVal DatasetTipoFornecedor As DatasetTipoFornecedor) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarTipoFornecedor(DatasetTipoFornecedor)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0138458")> _
    Public Function ObterTipoUnidadePagamento(ByVal TIPUNDPGTCTTFRN As Decimal) As DatasetTipoUnidadePagamento
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetTipoUnidadePagamento As DatasetTipoUnidadePagamento

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetTipoUnidadePagamento = AcordoFornecimentoBP.ObterTipoUnidadePagamento(TIPUNDPGTCTTFRN)

            Return DatasetTipoUnidadePagamento
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0138458")> _
    Public Function ObterTiposUnidadePagamento(ByVal DESTIPUNDPGTCTTFRN As String) As DatasetTipoUnidadePagamento
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetTipoUnidadePagamento As DatasetTipoUnidadePagamento

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetTipoUnidadePagamento = AcordoFornecimentoBP.ObterTiposUnidadePagamento(DESTIPUNDPGTCTTFRN)

            Return DatasetTipoUnidadePagamento
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0138458")> _
    Public Function AtualizarTipoUnidadePagamento(ByVal DatasetTipoUnidadePagamento As DatasetTipoUnidadePagamento) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarTipoUnidadePagamento(DatasetTipoUnidadePagamento)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0138466")> _
     Public Function ObterTipoServico(ByVal TIPSVCCTTFRN As Decimal) As DatasetTipoServico
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetTipoServico As DatasetTipoServico

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetTipoServico = AcordoFornecimentoBP.ObterTipoServico(TIPSVCCTTFRN)

            Return DatasetTipoServico
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0138466")> _
    Public Function ObterTiposServico(ByVal DESTIPSVCCTTFRN As String) As DatasetTipoServico
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetTipoServico As DatasetTipoServico

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetTipoServico = AcordoFornecimentoBP.ObterTiposServico(DESTIPSVCCTTFRN)

            Return DatasetTipoServico
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0138466")> _
    Public Function AtualizarTipoServico(ByVal DatasetTipoServico As DatasetTipoServico) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarTipoServico(DatasetTipoServico)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0138474")> _
      Public Function ObterTipoRelacionamento(ByVal TIPRLCCTTFRN As Decimal) As DatasetTipoRelacionamento
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetTipoRelacionamento As DatasetTipoRelacionamento

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetTipoRelacionamento = AcordoFornecimentoBP.ObterTipoRelacionamento(TIPRLCCTTFRN)

            Return DatasetTipoRelacionamento
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0138474")> _
    Public Function ObterTiposRelacionamento(ByVal DESTIPRLCCTTFRN As String) As DatasetTipoRelacionamento
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetTipoRelacionamento As DatasetTipoRelacionamento

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetTipoRelacionamento = AcordoFornecimentoBP.ObterTiposRelacionamento(DESTIPRLCCTTFRN)

            Return DatasetTipoRelacionamento
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0138474")> _
    Public Function AtualizarTipoRelacionamento(ByVal DatasetTipoRelacionamento As DatasetTipoRelacionamento) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarTipoRelacionamento(DatasetTipoRelacionamento)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

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
    <WebMethod(Description:="Este método retorna os dados para tabela T0124961 com base em atributos que não fazem parte da chave primária.")> _
    Public Function ObterContratoXClausulaContrato(ByVal DATDSTCSL As Date, _
                                                   ByVal DATDSTCSLInicial As Date, _
                                                   ByVal DATDSTCSLFinal As Date, _
                                                   ByVal NUMCSLCTTFRN As Decimal, _
                                                   ByVal NUMCTTFRN As Decimal) As DatasetContrato
        Try
            Dim AcordoFornecimentoBP As New AcordoFornecimentoBP
            ObterContratoXClausulaContrato = AcordoFornecimentoBP.ObterContratoXClausulaContrato(DATDSTCSL, DATDSTCSLInicial, DATDSTCSLFinal, NUMCSLCTTFRN, NUMCTTFRN)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

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
    '<MartinsSecurity(5, -1)> _
    <WebMethod(Description:="Atualiza os dados no banco da tabela T0124961.")> _
    Public Sub AtualizarContratoXClausulaContrato(ByVal ds As DatasetContrato)
        Try
            Dim AcordoFornecimento As New AcordoFornecimentoBP

            AcordoFornecimento.AtualizarContratoXClausulaContrato(ds)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Retorna um registro com base em sua chave primária. Entidade principal:T0153589
    ''' </summary>
    ''' <param name="CODEDEABGMIX"></param>
    ''' <param name="DATREFAPU"></param>
    ''' <param name="NUMCSLCTTFRN"></param>
    ''' <param name="NUMCTTFRN"></param>
    ''' <param name="NUMREFPOD"></param>
    ''' <param name="NUMSEQRLCCTTPMS"></param>
    ''' <param name="TIPEDEABGMIX"></param>
    ''' <param name="TIPPODCTTFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	16/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0153589")> _
    Public Function ObterContratoFornecimentoXAbatimentoPerda(ByVal CODEDEABGMIX As Decimal, _
                                                              ByVal DATREFAPU As Date, _
                                                              ByVal NUMCSLCTTFRN As Decimal, _
                                                              ByVal NUMCTTFRN As Decimal, _
                                                              ByVal NUMREFPOD As Decimal, _
                                                              ByVal NUMSEQRLCCTTPMS As Decimal, _
                                                              ByVal TIPEDEABGMIX As Decimal, _
                                                              ByVal TIPPODCTTFRN As Decimal) As DatasetContratoFornecimentoXAbatimentoPerda
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetContratoFornecimentoXAbatimentoPerda As DatasetContratoFornecimentoXAbatimentoPerda

            AcordoComercialBP = New AcordoComercialBP
            DatasetContratoFornecimentoXAbatimentoPerda = AcordoComercialBP.ObterContratoFornecimentoXAbatimentoPerda(CODEDEABGMIX, DATREFAPU, NUMCSLCTTFRN, NUMCTTFRN, NUMREFPOD, NUMSEQRLCCTTPMS, TIPEDEABGMIX, TIPPODCTTFRN)

            Return DatasetContratoFornecimentoXAbatimentoPerda
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Atualização dos dados. Entidade principalT0153589
    ''' </summary>
    ''' <param name="DatasetContratoFornecimentoXAbatimentoPerda"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	16/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Atualização dos dados. Entidade principalT0153589")> _
    Public Function AtualizarContratoFornecimentoXAbatimentoPerda(ByVal DatasetContratoFornecimentoXAbatimentoPerda As DatasetContratoFornecimentoXAbatimentoPerda) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarContratoFornecimentoXAbatimentoPerda(DatasetContratoFornecimentoXAbatimentoPerda)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
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
    <WebMethod(Description:="Este método retorna o SQL para tabela T0153589 com base nos parametros.")> _
    Public Function ObterContratoFornecimentosXAbatimentosPerda(ByVal CODFRN As Decimal, ByVal TIPCNCPDACTTFRN As String) As DatasetContratoFornecimentoXAbatimentoPerda
        Try
            Dim AcordoComercial As AcordoComercialBP
            AcordoComercial = New AcordoComercialBP

            Dim DatasetContratoFornecimentoXAbatimentoPerda As DatasetContratoFornecimentoXAbatimentoPerda

            DatasetContratoFornecimentoXAbatimentoPerda = AcordoComercial.ObterContratoFornecimentosXAbatimentosPerda(CODFRN, TIPCNCPDACTTFRN)

            Return DatasetContratoFornecimentoXAbatimentoPerda
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Retorna um registro com base em sua chave primária. Entidade principal:T0153031
    ''' </summary>
    ''' <param name="CODEMP"></param>
    ''' <param name="CODFILEMP"></param>
    ''' <param name="CODPMS"></param>
    ''' <param name="DATNGCPMS"></param>
    ''' <param name="NUMSEQOBSPMS"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	16/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0153031")> _
    Public Function ObterAcordoXMensagem(ByVal CODEMP As Decimal, _
                                         ByVal CODFILEMP As Decimal, _
                                         ByVal CODPMS As Decimal, _
                                         ByVal DATNGCPMS As Date, _
                                         ByVal NUMSEQOBSPMS As Decimal) As DatasetAcordoXMensagem
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetAcordoXMensagem As DatasetAcordoXMensagem

            AcordoComercialBP = New AcordoComercialBP
            DatasetAcordoXMensagem = AcordoComercialBP.ObterAcordoXMensagem(CODEMP, CODFILEMP, CODPMS, DATNGCPMS, NUMSEQOBSPMS)

            Return DatasetAcordoXMensagem
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Atualização dos dados. Entidade principalT0153031
    ''' </summary>
    ''' <param name="DatasetAcordoXMensagem"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	16/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Atualização dos dados. Entidade principalT0153031")> _
    Public Function AtualizarAcordoXMensagem(ByVal DatasetAcordoXMensagem As DatasetAcordoXMensagem) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarAcordoXMensagem(DatasetAcordoXMensagem)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Retorna um registro com base em sua chave primária. Entidade principal:T0152663
    ''' </summary>
    ''' <param name="CODEDEABGMIX"></param>
    ''' <param name="CODFRN"></param>
    ''' <param name="DATREFAPU"></param>
    ''' <param name="NUMCSLCTTFRN"></param>
    ''' <param name="NUMCTTFRN"></param>
    ''' <param name="NUMREFPOD"></param>
    ''' <param name="TIPEDEABGMIX"></param>
    ''' <param name="TIPPODCTTFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	16/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0152663")> _
    Public Function ObterBonificacaoDuplicataEmitir(ByVal CODEDEABGMIX As Decimal, _
                                                    ByVal CODFRN As Decimal, _
                                                    ByVal DATREFAPU As Date, _
                                                    ByVal NUMCSLCTTFRN As Decimal, _
                                                    ByVal NUMCTTFRN As Decimal, _
                                                    ByVal NUMREFPOD As Decimal, _
                                                    ByVal TIPEDEABGMIX As Decimal, _
                                                    ByVal TIPPODCTTFRN As Decimal) As DatasetBonificacaoDuplicataEmitir
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetBonificacaoDuplicataEmitir As DatasetBonificacaoDuplicataEmitir

            AcordoComercialBP = New AcordoComercialBP
            DatasetBonificacaoDuplicataEmitir = AcordoComercialBP.ObterBonificacaoDuplicataEmitir(CODEDEABGMIX, CODFRN, DATREFAPU, NUMCSLCTTFRN, NUMCTTFRN, NUMREFPOD, TIPEDEABGMIX, TIPPODCTTFRN)

            Return DatasetBonificacaoDuplicataEmitir
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Atualização dos dados. Entidade principalT0152663
    ''' </summary>
    ''' <param name="DatasetBonificacaoDuplicataEmitir"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	16/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Atualização dos dados. Entidade principalT0152663")> _
    Public Function AtualizarBonificacaoDuplicataEmitir(ByVal DatasetBonificacaoDuplicataEmitir As DatasetBonificacaoDuplicataEmitir) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarBonificacaoDuplicataEmitir(DatasetBonificacaoDuplicataEmitir)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Retorna um registro com base em sua chave primária. Entidade principal:T0152647
    ''' </summary>
    ''' <param name="CODEDEABGMIX"></param>
    ''' <param name="DATREFAPU"></param>
    ''' <param name="NUMCSLCTTFRN"></param>
    ''' <param name="NUMCTTFRN"></param>
    ''' <param name="NUMREFPOD"></param>
    ''' <param name="NUMSEQRLCCTTPMS"></param>
    ''' <param name="TIPEDEABGMIX"></param>
    ''' <param name="TIPPODCTTFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	16/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0152647")> _
    Public Function ObterPerdaEmitida(ByVal CODEDEABGMIX As Decimal, _
                                      ByVal DATREFAPU As Date, _
                                      ByVal NUMCSLCTTFRN As Decimal, _
                                      ByVal NUMCTTFRN As Decimal, _
                                      ByVal NUMREFPOD As Decimal, _
                                      ByVal NUMSEQRLCCTTPMS As Decimal, _
                                      ByVal TIPEDEABGMIX As Decimal, _
                                      ByVal TIPPODCTTFRN As Decimal) As DatasetPerdaEmitida
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetPerdaEmitida As DatasetPerdaEmitida

            AcordoComercialBP = New AcordoComercialBP
            DatasetPerdaEmitida = AcordoComercialBP.ObterPerdaEmitida(CODEDEABGMIX, DATREFAPU, NUMCSLCTTFRN, NUMCTTFRN, NUMREFPOD, NUMSEQRLCCTTPMS, TIPEDEABGMIX, TIPPODCTTFRN)

            Return DatasetPerdaEmitida
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Selecione os abatimento referente as perdas do processo Aco. Frn")> _
    Public Function ObterAbatimentoPerdasAcoFrn(ByVal CODFRN As Decimal, ByVal isDATDSTRLCPDACTTFRNNull As Boolean) As DataSetAbatimentoPerdasAcoFrn
        Try
            ObterAbatimentoPerdasAcoFrn = (New AcordoComercialBP).ObterAbatimentoPerdasAcoFrn(CODFRN, isDATDSTRLCPDACTTFRNNull)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Atualização dos dados. Entidade principalT0152647
    ''' </summary>
    ''' <param name="DatasetPerdaEmitida"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	16/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Atualização dos dados. Entidade principalT0152647")> _
    Public Function AtualizarPerdaEmitida(ByVal DatasetPerdaEmitida As DatasetPerdaEmitida) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarPerdaEmitida(DatasetPerdaEmitida)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    '' -----------------------------------------------------------------------------
    '' <summary>
    '' Obter valores para validar a Trimestralidade e a Anualidade
    '' </summary>
    '' <param name="NUMCTTFRN">Contrato</param>
    '' <remarks>
    '' </remarks>
    '' <history>
    ''     [Elifázio Bernardes]    17/11/2006  Created
    '' </history>
    '' -----------------------------------------------------------------------------
    <WebMethod(Description:="Obter valores para validar a Trimestralidade e a Anualidade.")> _
    Public Function ObterTrimestralidadeAnualidadePermitida(ByVal NUMCTTFRN As Integer) As DatasetTrimestralidadeAnualidade
        Try
            Dim AcordoFornecimentoBP As New AcordoFornecimentoBP
            Return AcordoFornecimentoBP.ObterTrimestralidadeAnualidadePermitida(NUMCTTFRN)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obter Proximo numero de OP.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	17/11/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Obter Proximo numero de OP.")> _
    Public Function ObterProximoNumeroOP() As Decimal
        Try
            Dim AcordoComercial As New AcordoComercialBP
            Return AcordoComercial.ObterProximoNumeroOP
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

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
    <WebMethod(Description:="Atualiza os dados no banco de todas as tabelas que envolve a criação do contrato.")> _
    Public Sub AtualizarContratoTabelas(ByVal ds As DatasetContrato)
        Try
            Call (New AcordoFornecimentoBP).AtualizarContratoTabelas(ds)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Sub

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
    <WebMethod(Description:="Obtem simulação sintética de crescimento.")> _
    Public Function ObterSimulacaoSinteticaDeCrescimento(ByVal pvCodDivCmpEnt As Integer, _
                                                         ByVal pvCodFrnEnt As Integer, _
                                                         ByVal pvCodCprEnt As Integer, _
                                                         ByVal pvTipPodEnt As Integer, _
                                                         ByVal pvNumPorEnt As Integer, _
                                                         ByVal pvNumPor1Ent As Integer) As DatasetSimulacaoSinteticaDeCrescimento
        Try
            Dim ds As DatasetSimulacaoSinteticaDeCrescimento
            Dim AcordoFornecimento As New AcordoFornecimentoBP

            ds = AcordoFornecimento.ObterSimulacaoSinteticaDeCrescimento(pvCodDivCmpEnt, _
                                                                         pvCodFrnEnt, _
                                                                         pvCodCprEnt, _
                                                                         pvTipPodEnt, _
                                                                         pvNumPorEnt, _
                                                                         pvNumPor1Ent)

            Return ds

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try

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
    <WebMethod(Description:="Verifica se o fornecedor pertence a celula atendida pelo usuário.")> _
    Public Function FornecedorPertenceCelulaAtendidaUsuario(ByVal CODFRN As Decimal, _
                                                            ByVal NOMACSUSRSIS As String) As Boolean
        Try
            Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorBP
            Return ContaCorrenteFornecedor.FornecedorPertenceCelulaAtendidaUsuario(CODFRN, _
                                                                                     NOMACSUSRSIS)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
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
    <WebMethod(Description:="Obter as categorias do fornecedor.")> _
    Public Function ObterCategoriasDoFornecedor(ByVal CODEMP As Decimal, _
                                                ByVal CODFRNPCPMER As Decimal) As DatasetContratoXAbrangenciaMix
        Try
            Dim AcordoFornecimento As New AcordoFornecimentoBP
            Return AcordoFornecimento.ObterCategoriasDoFornecedor(CODEMP, _
                                                                  CODFRNPCPMER)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obter as categorias do fornecedor.
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
    <WebMethod(Description:="Obter as categorias do fornecedor.")> _
    Public Function ObterMercadoriasDoFornecedor(ByVal CODEMP As Decimal, _
                                                 ByVal CODFRNPCPMER As Decimal) As DatasetContratoXAbrangenciaMix
        Try
            Dim AcordoFornecimento As New AcordoFornecimentoBP
            Return AcordoFornecimento.ObterMercadoriasDoFornecedor(CODEMP, _
                                                                   CODFRNPCPMER)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

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
    <WebMethod(Description:="Obter cláusulas em contrato vigente do fornecedor.")> _
    Public Function ObterClausulasEmContratroVigentesDoFornecedor(ByVal CODFRNPCPAPUARDFRN As Decimal) As DatasetContrato
        Try
            Dim AcordoFornecimento As New AcordoFornecimentoBP
            Return AcordoFornecimento.ObterClausulasEmContratroVigentesDoFornecedor(CODFRNPCPAPUARDFRN)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Retorna um registro com base em sua chave primária. Entidade principal:T0123884
    ''' </summary>
    ''' <param name="CODFRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	15/2/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0123884")> _
    Public Function ObterParametroFornecedorMmm(ByVal CODFRN As Decimal) As DatasetParametroFornecedorMmm
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetParametroFornecedorMmm As DatasetParametroFornecedorMmm

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetParametroFornecedorMmm = AcordoFornecimentoBP.ObterParametroFornecedorMmm(CODFRN)

            Return DatasetParametroFornecedorMmm
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0123884
    ''' </summary>
    ''' <param name="CODFRN"></param>
    ''' <param name="FLGFRNAJTCMC"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	15/2/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0123884")> _
    Public Function ObterParametrosFornecedorMmm(ByVal CODFRN As Decimal, _
                                                 ByVal FLGFRNAJTCMC As String) As DatasetParametroFornecedorMmm
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetParametroFornecedorMmm As DatasetParametroFornecedorMmm

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetParametroFornecedorMmm = AcordoFornecimentoBP.ObterParametrosFornecedorMmm(CODFRN, FLGFRNAJTCMC)

            Return DatasetParametroFornecedorMmm
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Atualização dos dados. Entidade principalT0123884
    ''' </summary>
    ''' <param name="DatasetParametroFornecedorMmm"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	15/2/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Atualização dos dados. Entidade principalT0123884")> _
    Public Function AtualizarParametroFornecedorMmm(ByVal DatasetParametroFornecedorMmm As DatasetParametroFornecedorMmm) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarParametroFornecedorMmm(DatasetParametroFornecedorMmm)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
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
    <WebMethod(Description:="Obtem os filiados do contrato")> _
    Public Function ObterFiliadosContrato(ByVal NUMCTTFRN As Decimal, _
                                          ByVal NUMCSLCTTFRN As Decimal, _
                                          ByVal TIPEDEABGMIX As Decimal, _
                                          ByVal CODEDEABGMIX As Decimal) As DatasetContrato

        Try
            Dim AcordoFornecimento As New AcordoFornecimentoBP
            Dim DatasetContrato As DatasetContrato

            DatasetContrato = AcordoFornecimento.ObterFiliadosContrato(NUMCTTFRN, NUMCSLCTTFRN, TIPEDEABGMIX, CODEDEABGMIX)
            Return DatasetContrato

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Retorna um registro com base em sua chave primária. Entidade principal:RLCABGCTTFIL
    ''' </summary>
    ''' <param name="CODCLI"></param>
    ''' <param name="CODEDEABGMIX"></param>
    ''' <param name="NUMCSLCTTFRN"></param>
    ''' <param name="NUMCTTFRN"></param>
    ''' <param name="TIPEDEABGMIX"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	23/2/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:RLCABGCTTFIL")> _
    Public Function ObterAbrangenciaXContratoXFiliado(ByVal CODCLI As Decimal, _
                                                      ByVal CODEDEABGMIX As Decimal, _
                                                      ByVal NUMCSLCTTFRN As Decimal, _
                                                      ByVal NUMCTTFRN As Decimal, _
                                                      ByVal TIPEDEABGMIX As Decimal) As DatasetContrato
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetContrato As DatasetContrato

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetContrato = AcordoFornecimentoBP.ObterAbrangenciaXContratoXFiliado(CODCLI, CODEDEABGMIX, NUMCSLCTTFRN, NUMCTTFRN, TIPEDEABGMIX)

            Return DatasetContrato
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:RLCABGCTTFIL
    ''' </summary>
    ''' <param name="CODCLI"></param>
    ''' <param name="CODEDEABGMIX"></param>
    ''' <param name="NUMCSLCTTFRN"></param>
    ''' <param name="NUMCTTFRN"></param>
    ''' <param name="TIPEDEABGMIX"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	23/2/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:RLCABGCTTFIL")> _
    Public Function ObterAbrangenciasXContratoXFiliado(ByVal CODCLI As Decimal, _
                                                       ByVal CODEDEABGMIX As Decimal, _
                                                       ByVal NUMCSLCTTFRN As Decimal, _
                                                       ByVal NUMCTTFRN As Decimal, _
                                                       ByVal TIPEDEABGMIX As Decimal) As DatasetContrato
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetContrato As DatasetContrato

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetContrato = AcordoFornecimentoBP.ObterAbrangenciasXContratoXFiliado(CODCLI, CODEDEABGMIX, NUMCSLCTTFRN, NUMCTTFRN, TIPEDEABGMIX)

            Return DatasetContrato
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Atualização dos dados. Entidade principalRLCABGCTTFIL
    ''' </summary>
    ''' <param name="DatasetContrato"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	23/2/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Atualização dos dados. Entidade principalRLCABGCTTFIL")> _
    Public Function AtualizarAbrangenciaXContratoXFiliado(ByVal DatasetContrato As DatasetContrato) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarAbrangenciaXContratoXFiliado(DatasetContrato)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

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
    <WebMethod(Description:="Atualização dos dados. Entidade RLCABGCTTFIL a partir de arquivo CSV")> _
    Public Sub AtualizarAbrangenciaXContratoXFiliadoDeArquivoCSV(ByVal NUMCTTFRN As Decimal, ByVal NUMCSLCTTFRN As Decimal, ByVal TIPEDEABGMIX As Decimal, ByVal CODEDEABGMIX As Decimal, ByVal caminhoArquivoCSV As String)
        Dim AcordoFornecimento As New AcordoFornecimentoBP
        Try
            AcordoFornecimento.AtualizarAbrangenciaXContratoXFiliadoDeArquivoCSV(NUMCTTFRN, NUMCSLCTTFRN, TIPEDEABGMIX, CODEDEABGMIX, caminhoArquivoCSV)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Retorna um registro com base em sua chave primária. Entidade principal:T0144920
    ''' </summary>
    ''' <param name="CODDIVCMP"></param>
    ''' <param name="NOMACSUSRSIS"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	26/2/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0144920")> _
    Public Function ObterUsuarioXCelula(ByVal CODDIVCMP As Decimal, _
                                        ByVal NOMACSUSRSIS As String) As DatasetUsuarioXCelula
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetUsuarioXCelula As DatasetUsuarioXCelula

            AcordoComercialBP = New AcordoComercialBP
            DatasetUsuarioXCelula = AcordoComercialBP.ObterUsuarioXCelula(CODDIVCMP, NOMACSUSRSIS)

            Return DatasetUsuarioXCelula
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0144920
    ''' </summary>
    ''' <param name="CODDIVCMP"></param>
    ''' <param name="NOMACSUSRSIS"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	26/2/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0144920")> _
    Public Function ObterUsuariosXCelula(ByVal CODDIVCMP As Decimal, _
                                         ByVal NOMACSUSRSIS As String) As DatasetUsuarioXCelula
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetUsuarioXCelula As DatasetUsuarioXCelula

            AcordoComercialBP = New AcordoComercialBP
            DatasetUsuarioXCelula = AcordoComercialBP.ObterUsuariosXCelula(CODDIVCMP, NOMACSUSRSIS)

            Return DatasetUsuarioXCelula
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Atualização dos dados. Entidade principalT0144920
    ''' </summary>
    ''' <param name="DatasetUsuarioXCelula"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	26/2/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Atualização dos dados. Entidade principalT0144920")> _
    Public Function AtualizarUsuarioXCelula(ByVal DatasetUsuarioXCelula As DatasetUsuarioXCelula) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarUsuarioXCelula(DatasetUsuarioXCelula)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Retorna um registro com base em sua chave primária. Entidade principal:CADTRNVBAFRN
    ''' </summary>
    ''' <param name="NUMFLUAPV"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	27/11/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:CADTRNVBAFRN")> _
    Public Function ObterTransferenciaVerbaFornecedor(ByVal NUMFLUAPV As Decimal) As DatasetTransferenciaVerbaFornecedor
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor

            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedorBP.ObterTransferenciaVerbaFornecedor(NUMFLUAPV)

            Return DatasetTransferenciaVerbaFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Retorna um registro com base em sua chave primária. Entidade principal:CADTRNVBAFRN
    ''' </summary>
    ''' <param name="NUMFLUAPV"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	27/11/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:CADTRNVBAFRN")> _
    Public Function ObterTransferenciasVerbaFornecedorJOIN(ByVal NUMFLUAPV As Decimal, _
                                                              ByVal CODFNC As Decimal, _
                                                              ByVal TIPSTAFLUAPV As String) As DatasetTransferenciaVerbaFornecedor
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor

            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedorBP.ObterTransferenciasVerbaFornecedorJOIN(NUMFLUAPV, CODFNC, TIPSTAFLUAPV)

            Return DatasetTransferenciaVerbaFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NUMFLUAPV"></param>
    ''' <param name="CODFNC"></param>
    ''' <param name="TIPSTAFLUAPV"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	22/12/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Obter as aprovações pendentes de um usuário")> _
    Public Function ObterMinhasAprovavoesEmTransferenciaVerbasFornecedor(ByVal NUMFLUAPV As Decimal, _
                                                                         ByVal CODFNC As Decimal) As DatasetTransferenciaVerbaFornecedor
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor

            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedorBP.ObterMinhasAprovavoesEmTransferenciaVerbasFornecedor(NUMFLUAPV, CODFNC)

            Return DatasetTransferenciaVerbaFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:CADTRNVBAFRN
    ''' </summary>
    ''' <param name="CODFNC"></param>
    ''' <param name="DESJSTTRNVBA"></param>
    ''' <param name="NUMFLUAPV"></param>
    ''' <param name="TIPALCVBAFRN"></param>
    ''' <param name="TIPDSNDSCBNFDSNTRN"></param>
    ''' <param name="TIPSTAFLUAPV"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	22/12/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:CADTRNVBAFRN")> _
    Public Function ObterTransferenciasVerbaFornecedor(ByVal CODFNC As Decimal, _
                                                       ByVal DESJSTTRNVBA As String, _
                                                       ByVal NUMFLUAPV As Decimal, _
                                                       ByVal TIPALCVBAFRN As Decimal, _
                                                       ByVal TIPDSNDSCBNFDSNTRN As Decimal, _
                                                       ByVal TIPSTAFLUAPV As String) As DatasetTransferenciaVerbaFornecedor
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor

            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedorBP.ObterTransferenciasVerbaFornecedor(CODFNC, DESJSTTRNVBA, NUMFLUAPV, TIPALCVBAFRN, TIPDSNDSCBNFDSNTRN, TIPSTAFLUAPV)

            Return DatasetTransferenciaVerbaFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Atualização dos dados. Entidade principalCADTRNVBAFRN
    ''' </summary>
    ''' <param name="DatasetTransferenciaVerbaFornecedor"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	27/11/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Atualização dos dados. Entidade principalCADTRNVBAFRN")> _
    Public Function AtualizarTransferenciaVerbaFornecedor(ByVal DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor) As Boolean
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            ContaCorrenteFornecedorBP.AtualizarTransferenciaVerbaFornecedor(DatasetTransferenciaVerbaFornecedor)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Retorna um registro com base em sua chave primária. Entidade principal:RLCTRNVBAFRN
    ''' </summary>
    ''' <param name="CODFRN"></param>
    ''' <param name="NUMFLUAPV"></param>
    ''' <param name="TIPALCVBAFRN"></param>
    ''' <param name="TIPDSNDSCBNFORITRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	27/11/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:RLCTRNVBAFRN")> _
    Public Function ObterRelacaoTransferenciaVerbaFornecedor(ByVal CODFRN As Decimal, _
                                                             ByVal NUMFLUAPV As Decimal, _
                                                             ByVal TIPALCVBAFRN As Decimal, _
                                                             ByVal TIPDSNDSCBNFORITRN As Decimal) As DatasetTransferenciaVerbaFornecedor
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor

            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedorBP.ObterRelacaoTransferenciaVerbaFornecedor(CODFRN, NUMFLUAPV, TIPALCVBAFRN, TIPDSNDSCBNFORITRN)

            Return DatasetTransferenciaVerbaFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem os registros da tabela:RLCTRNVBAFRN com seus respectivos relacionamentos
    ''' </summary>
    ''' <param name="NUMFLUAPV"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	5/12/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Obtem os registros da tabela:RLCTRNVBAFRN com seus respectivos relacionamentos")> _
    Public Function ObterRelacaoTransferenciaVerbaFornecedorJoinT0153541JoinT0100426JoinT0113625JoinT0118570JoinT0109059(ByVal NUMFLUAPV As Decimal) As DatasetTransferenciaVerbaFornecedor
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor

            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedorBP.ObterRelacaoTransferenciaVerbaFornecedorJoinT0153541JoinT0100426JoinT0113625JoinT0118570JoinT0109059(NUMFLUAPV)

            Return DatasetTransferenciaVerbaFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:RLCTRNVBAFRN
    ''' </summary>
    ''' <param name="CODFRN"></param>
    ''' <param name="NUMFLUAPV"></param>
    ''' <param name="TIPALCVBAFRN"></param>
    ''' <param name="TIPDSNDSCBNFORITRN"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	27/11/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:RLCTRNVBAFRN")> _
    Public Function ObterRelacoesTransferenciaVerbaFornecedor(ByVal CODFRN As Decimal, _
                                                              ByVal NUMFLUAPV As Decimal, _
                                                              ByVal TIPALCVBAFRN As Decimal, _
                                                              ByVal TIPDSNDSCBNFORITRN As Decimal) As DatasetTransferenciaVerbaFornecedor
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            Dim DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor

            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            DatasetTransferenciaVerbaFornecedor = ContaCorrenteFornecedorBP.ObterRelacoesTransferenciaVerbaFornecedor(CODFRN, NUMFLUAPV, TIPALCVBAFRN, TIPDSNDSCBNFORITRN)

            Return DatasetTransferenciaVerbaFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Atualização dos dados. Entidade principalRLCTRNVBAFRN
    ''' </summary>
    ''' <param name="DatasetTransferenciaVerbaFornecedor"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	27/11/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Atualização dos dados. Entidade principalRLCTRNVBAFRN")> _
    Public Function AtualizarRelacaoTransferenciaVerbaFornecedor(ByVal DatasetTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor) As Boolean
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            ContaCorrenteFornecedorBP.AtualizarRelacaoTransferenciaVerbaFornecedor(DatasetTransferenciaVerbaFornecedor)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obter nova chave para a transferencia verba
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	29/11/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Obter nova chave para a transferencia verba")> _
    Public Function ObterNovaChaveTransferenciaVerba() As Decimal
        Try
            Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorBP
            Dim chave As Decimal = ContaCorrenteFornecedor.ObterNovaChaveTransferenciaVerba
            Return chave
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Retorna um registro com base em sua chave primária. Entidade principal:T0100361
    ''' </summary>
    ''' <param name="CODFNC"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	29/11/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0100361")> _
    Public Function ObterFuncionario(ByVal CODFNC As Decimal) As DatasetFuncionario
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            Dim DatasetFuncionario As DatasetFuncionario

            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            DatasetFuncionario = ContaCorrenteFornecedorBP.ObterFuncionario(CODFNC)

            Return DatasetFuncionario
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0161591")> _
    Public Function ObterFluxoAprovacao(ByVal CODSISINF As Decimal, _
                                        ByVal NUMFLUAPV As Decimal, _
                                        ByVal NUMSEQFLUAPV As Decimal) As DatasetFluxoAprovacao
        Try
            Dim FluxoDeCancelamentoDeAcordosBP As FluxoDeCancelamentoDeAcordosBP
            Dim DatasetFluxoAprovacao As DatasetFluxoAprovacao

            FluxoDeCancelamentoDeAcordosBP = New FluxoDeCancelamentoDeAcordosBP
            DatasetFluxoAprovacao = FluxoDeCancelamentoDeAcordosBP.ObterFluxoAprovacao(CODSISINF, NUMFLUAPV, NUMSEQFLUAPV)

            Return DatasetFluxoAprovacao
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0161591")> _
    Public Function ObterFluxosAprovacao(ByVal CODEDEAPV As Decimal, _
                                         ByVal CODEDEARZ As Decimal, _
                                         ByVal CODSISINF As Decimal, _
                                         ByVal DATHRAAPVFLU As String, _
                                         ByVal DATHRAFLUAPV As String, _
                                         ByVal NUMFLUAPV As Decimal, _
                                         ByVal NUMSEQFLUAPV As Decimal, _
                                         ByVal NUMSEQFLUAPVPEDOPN As Decimal, _
                                         ByVal NUMSEQNIVAPV As Decimal, _
                                         ByVal TIPSTAFLUAPV As String) As DatasetFluxoAprovacao
        Try
            Dim FluxoDeCancelamentoDeAcordos As FluxoDeCancelamentoDeAcordosBP
            Dim DatasetFluxoAprovacao As DatasetFluxoAprovacao

            FluxoDeCancelamentoDeAcordos = New FluxoDeCancelamentoDeAcordosBP
            DatasetFluxoAprovacao = FluxoDeCancelamentoDeAcordos.ObterFluxosAprovacao(CODEDEAPV, CODEDEARZ, CODSISINF, DATHRAAPVFLU, DATHRAFLUAPV, NUMFLUAPV, NUMSEQFLUAPV, NUMSEQFLUAPVPEDOPN, NUMSEQNIVAPV, TIPSTAFLUAPV)

            Return DatasetFluxoAprovacao
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0161591")> _
    Public Function AtualizarFluxoAprovacao(ByVal DatasetFluxoAprovacao As DatasetFluxoAprovacao) As Boolean
        Try
            Dim FluxoDeCancelamentoDeAcordosBP As FluxoDeCancelamentoDeAcordosBP
            FluxoDeCancelamentoDeAcordosBP = New FluxoDeCancelamentoDeAcordosBP
            FluxoDeCancelamentoDeAcordosBP.AtualizarFluxoAprovacao(DatasetFluxoAprovacao)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Iniciar Fluxo Transferencia Verbas")> _
    Public Function IniciarFluxoTransferenciaVerbas(ByVal NUMFLUAPV As Decimal) As Boolean
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            ContaCorrenteFornecedorBP.IniciarFluxoTransferenciaVerbas(NUMFLUAPV)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Aprovar Fluxo Transferencia Verbas")> _
    Public Function AprovarFluxoTransferenciaVerbas(ByVal NUMFLUAPV As Decimal, ByVal CODFNC As Decimal, ByVal DESOBSAPV As String) As Boolean
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            ContaCorrenteFornecedorBP.AprovarFluxoTransferenciaVerbas(NUMFLUAPV, CODFNC, DESOBSAPV)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Reprovar Fluxo Transferencia Verbas")> _
    Public Function ReprovarFluxoTransferenciaVerbas(ByVal NUMFLUAPV As Decimal, ByVal CODFNC As Decimal, ByVal DESOBSAPV As String) As Boolean
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            ContaCorrenteFornecedorBP.ReprovarFluxoTransferenciaVerbas(NUMFLUAPV, CODFNC, DESOBSAPV)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Reprovar Fluxo Transferencia Verbas
    ''' </summary>
    ''' <param name="NUMFLUAPV"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	27/12/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Reprovar Fluxo Transferencia Verbas")> _
    Public Function ClonarTransferenciaEmpenhoFornecedor(ByVal NUMFLUAPV As Decimal) As Decimal
        Try
            Dim ContaCorrenteFornecedorBP As New ContaCorrenteFornecedorBP
            Return ContaCorrenteFornecedorBP.ClonarTransferenciaEmpenhoFornecedor(NUMFLUAPV)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0102321")> _
    Public Function ObterCalendarioAnual(ByVal DATREF As Date) As DatasetCalendarioAnual
        Try
            Dim ContaCorrenteFornecedorBP As ContaCorrenteFornecedorBP
            Dim DatasetCalendarioAnual As DatasetCalendarioAnual

            ContaCorrenteFornecedorBP = New ContaCorrenteFornecedorBP
            DatasetCalendarioAnual = ContaCorrenteFornecedorBP.ObterCalendarioAnual(DATREF)

            Return DatasetCalendarioAnual
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Transfere valores entre empenhos do fornecedor (processo sem fluxo de aprovação)
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
    <WebMethod(Description:="Transfere valores entre empenhos do fornecedor (processo sem fluxo de aprovação)")> _
    Public Sub AtualizarTransferencia(ByVal NOMACSUSRSIS As String, _
                                      ByVal TIPUSRSIS As String, _
                                      ByVal dsTransferenciaVerbaFornecedor As DatasetTransferenciaVerbaFornecedor)
        Try
            Dim ContaCorrenteFornecedorBP As New ContaCorrenteFornecedorBP

            ContaCorrenteFornecedorBP.AtualizarTransferencia(NOMACSUSRSIS, _
                                                             TIPUSRSIS, _
                                                             dsTransferenciaVerbaFornecedor)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' CONSULTA RELAÇÃO TIPO DE TRANSFERÊNCIA EMPRENHO E FORNECEDOR
    ''' </summary>
    ''' <param name="vTipOpe">TIPO DA CONSULTA 1,2 OU 3</param>
    ''' <param name="vNomAcsUsrSis"></param>
    ''' <param name="vTipDsnDscBnf"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[ELIFÁZIO]	21/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="CONSULTA RELAÇÃO TIPO DE TRANSFERÊNCIA EMPRENHO E FORNECEDOR")> _
    Public Function ObterRelacaoTipoTransferenciaEmpenhoFornecedor(ByVal vTipOpe As Integer, _
                                                                    ByVal vNomAcsUsrSis As String, _
                                                                    ByVal vTipDsnDscBnf As Decimal) As DatasetRelacaoTipoTransferenciaEmpenhoFornecedor
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelacaoTipoTransferenciaEmpenhoFornecedor

            ds = AcordoComercialBP.ObterRelacaoTipoTransferenciaEmpenhoFornecedor(vTipOpe, vNomAcsUsrSis, vTipDsnDscBnf)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="CONSULTA Valores Disponiveis de um Fornecedor")> _
    Public Function ObterSelecaoValorDisponivelFornecedor(ByVal vDatRef As Date, _
                                                          ByVal vCodFrn As Decimal, _
                                                          ByVal vTipDsnDscBnf As Decimal) As DatasetSelecaoValorDisponivelFornecedor
        Try
            Dim ContaCorrenteFornecedorBP As New ContaCorrenteFornecedorBP
            Dim ds As DatasetSelecaoValorDisponivelFornecedor

            ds = ContaCorrenteFornecedorBP.ObterSelecaoValorDisponivelFornecedor(vDatRef, vCodFrn, vTipDsnDscBnf)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obter saldo disponível do fornecedor
    ''' </summary>
    ''' <param name="vDatRef"></param>
    ''' <param name="vCodFrn"></param>
    ''' <param name="vTipDsnDscBnf"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	22/11/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Obter saldo disponível do fornecedor")> _
    Public Function ObterSaldoDisponivelFornecedor(ByVal vDatRef As Date, _
                                                   ByVal vCodFrn As Decimal, _
                                                   ByVal vTipDsnDscBnf As Decimal) As DatasetSelecaoValorDisponivelFornecedor
        Try
            Dim ContaCorrenteFornecedorBP As New ContaCorrenteFornecedorBP
            Dim ds As DatasetSelecaoValorDisponivelFornecedor

            ds = ContaCorrenteFornecedorBP.ObterSaldoDisponivelFornecedor(vDatRef, vCodFrn, vTipDsnDscBnf)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obter saldo disponível do fornecedor
    ''' </summary>
    ''' <param name="vDatRef"></param>
    ''' <param name="vCodFrn"></param>
    ''' <param name="In_TipDsnDscBnf"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	22/2/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Obter saldo disponível do fornecedor")> _
    Public Function ObterSaldoDisponivelFornecedor2(ByVal vDatRef As Date, _
                                                    ByVal vCodFrn As Decimal, _
                                                    ByVal In_TipDsnDscBnf As String) As DatasetSelecaoValorDisponivelFornecedor
        Try
            Dim ContaCorrenteFornecedorBP As New ContaCorrenteFornecedorBP
            Dim ds As DatasetSelecaoValorDisponivelFornecedor

            ds = ContaCorrenteFornecedorBP.ObterSaldoDisponivelFornecedor(vDatRef, vCodFrn, In_TipDsnDscBnf)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obter saldo disponível do fornecedor para todos empenhos
    ''' </summary>
    ''' <param name="vDatRef"></param>
    ''' <param name="vCodFrn"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	11/1/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Obter saldo disponível do fornecedor para todos empenhos")> _
    Public Function ObterSaldoDisponivelFornecedorParaTodosEmpenhos(ByVal vDatRef As Date, _
                                                                    ByVal vCodFrn As Decimal) As DatasetSelecaoValorDisponivelFornecedor
        Try
            Dim ContaCorrenteFornecedorBP As New ContaCorrenteFornecedorBP
            Dim ds As DatasetSelecaoValorDisponivelFornecedor

            ds = ContaCorrenteFornecedorBP.ObterSaldoDisponivelFornecedorParaTodosEmpenhos(vDatRef, vCodFrn)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obter saldo disponível do fornecedor por categoria
    ''' </summary>
    ''' <param name="vDatRef"></param>
    ''' <param name="CodDivCmp"></param>
    ''' <param name="vTipDsnDscBnf"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	22/11/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Obter saldo disponível do fornecedor por categoria")> _
    Public Function ObterSaldoDisponivelFornecedorPorCategoria(ByVal vDatRef As Date, _
                                                               ByVal CodDivCmp As Decimal, _
                                                               ByVal vTipDsnDscBnf As Decimal) As DatasetSelecaoValorDisponivelFornecedor
        Try
            Dim ContaCorrenteFornecedorBP As New ContaCorrenteFornecedorBP
            Dim ds As DatasetSelecaoValorDisponivelFornecedor

            ds = ContaCorrenteFornecedorBP.ObterSaldoDisponivelFornecedorPorCategoria(vDatRef, CodDivCmp, vTipDsnDscBnf)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obter saldo disponível do fornecedor por categoria
    ''' </summary>
    ''' <param name="vDatRef"></param>
    ''' <param name="CodDivCmp"></param>
    ''' <param name="vTipDsnDscBnf"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	22/2/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Obter saldo disponível do fornecedor por categoria")> _
    Public Function ObterSaldoDisponivelFornecedorPorCategoria2(ByVal vDatRef As Date, _
                                                                ByVal CodDivCmp As Decimal) As DatasetSelecaoValorDisponivelFornecedor
        Try
            Dim ContaCorrenteFornecedorBP As New ContaCorrenteFornecedorBP
            Dim ds As DatasetSelecaoValorDisponivelFornecedor

            ds = ContaCorrenteFornecedorBP.ObterSaldoDisponivelFornecedorPorCategoria(vDatRef, CodDivCmp)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obter saldo disponível do fornecedor por comprador
    ''' </summary>
    ''' <param name="vDatRef"></param>
    ''' <param name="codCpr"></param>
    ''' <param name="vTipDsnDscBnf"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	22/11/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Obter saldo disponível do fornecedor por comprador")> _
    Public Function ObterSaldoDisponivelFornecedorPorComprador(ByVal vDatRef As Date, _
                                                               ByVal codCpr As Decimal, _
                                                               ByVal vTipDsnDscBnf As Decimal) As DatasetSelecaoValorDisponivelFornecedor
        Try
            Dim ContaCorrenteFornecedorBP As New ContaCorrenteFornecedorBP
            Dim ds As DatasetSelecaoValorDisponivelFornecedor

            ds = ContaCorrenteFornecedorBP.ObterSaldoDisponivelFornecedorPorComprador(vDatRef, codCpr, vTipDsnDscBnf)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obter saldo disponível do fornecedor por comprador
    ''' </summary>
    ''' <param name="vDatRef"></param>
    ''' <param name="codCpr"></param>
    ''' <param name="vTipDsnDscBnf"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Marcos Queiroz]	22/2/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Obter saldo disponível do fornecedor por comprador")> _
    Public Function ObterSaldoDisponivelFornecedorPorComprador2(ByVal vDatRef As Date, _
                                                                ByVal codCpr As Decimal) As DatasetSelecaoValorDisponivelFornecedor
        Try
            Dim ContaCorrenteFornecedorBP As New ContaCorrenteFornecedorBP
            Dim ds As DatasetSelecaoValorDisponivelFornecedor

            ds = ContaCorrenteFornecedorBP.ObterSaldoDisponivelFornecedorPorComprador(vDatRef, codCpr)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    '<WebMethod(Description:="Verificar se o fornecedor pertence à célula atendida pelo usuário.")> _
    'Public Function VerificarFornecedorPertenceCeludaAtendidaUsuario(ByVal NomUsrSis As String, ByVal CodFrn As Decimal) As Boolean
    '    Try
    '        Dim AcordoComercialBP As New AcordoComercialBP

    '        Return AcordoComercialBP.VerificarFornecedorPertenceCeludaAtendidaUsuario(NomUsrSis, CodFrn)
    '    Catch ex As Martins.ExceptionManagement.BaseApplicationException
    '        ex.GenerateSoapException()
    '    Catch ex As Exception
    '        Dim tempEx As MartinsSystemException

    '        tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
    '        tempEx.GenerateSoapException()
    '    End Try
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
    <WebMethod(Description:="CONSULTA Valores Acordos Duplicata Nao Relacionada.")> _
    Public Function ObterSelecaoValorAcordoDuplicataNaoRelacionada(ByVal vOpcao As Integer, _
                                                                    ByVal vCodFrn As Integer) As DatasetSelecaoValorAcordoDuplicataNaoRelacionada
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetSelecaoValorAcordoDuplicataNaoRelacionada

            ds = AcordoComercialBP.ObterSelecaoValorAcordoDuplicataNaoRelacionada(vOpcao, vCodFrn)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="CONSULTA Valores Promessa Origem Troca Forma Pagamento Acordo.")> _
    Public Function ObterValorPromessaOrigemTrocaFormaPagamentoAcordo(ByVal vCodPmsEnt As Integer, _
                                                                     ByVal vDatPgtTit As Date) As DatasetObterValorPromessaOrigemTrocaFormaPagamentoAcordo
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetObterValorPromessaOrigemTrocaFormaPagamentoAcordo

            ds = AcordoComercialBP.ObterValorPromessaOrigemTrocaFormaPagamentoAcordo(vCodPmsEnt, vDatPgtTit)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Obtem Novo Codigo de Promessa.")> _
    Public Function ObterProximoCodigoAcordoComercial(ByVal vCodEmp As Integer, _
                                                    ByVal vCodFilEmp As Integer) As Integer
        Try
            ObterProximoCodigoAcordoComercial = -1
            Dim AcordoComercial As New AcordoComercialBP
            ObterProximoCodigoAcordoComercial = AcordoComercial.ObterProximoCodigoAcordoComercial(vCodEmp, vCodFilEmp)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="CADASTRA A PROMESSA, Manutencao Movimento Acordo Comercial.")> _
    Public Function GerarManutencaoMovimentoAcordoComercial(ByVal vTipOpe As Integer, _
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
        Try
            GerarManutencaoMovimentoAcordoComercial = False
            Dim AcordoComercial As New AcordoComercialBP
            GerarManutencaoMovimentoAcordoComercial = AcordoComercial.GerarManutencaoMovimentoAcordoComercial(vTipOpe, vCodEmp, vCodFilEmp, vCodPms, vDatNgcPms, vCodSitPms, vNumPedCmp, vCodFrn, vNomAcsUsrSis, vDesMsgUsr, vNomCtoFrn, vNumTlfCtoFrn, vDesCgrCtofrn)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="CADASTRA A Manutencao Relacao Acordo Comercial Parcela.")> _
    Public Function GerarManutencaoRelacaoAcordoComercialParcela(ByVal vTipOpe As Integer, _
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

        Try
            GerarManutencaoRelacaoAcordoComercialParcela = False
            Dim AcordoComercial As New AcordoComercialBP
            GerarManutencaoRelacaoAcordoComercialParcela = AcordoComercial.GerarManutencaoRelacaoAcordoComercialParcela(vTipOpe, vCodEmp, vCodFilEmp, vCodPms, vDatNgcPms, vDatPrvRcbPms, vTipFrmDscBnf, vTipDsnDscBnf, vVlrNgcPms, vVlrEftPms, vNomAcsUsrSis)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Acessar procedure PRCDKSelAtlOpeBxaOpeFrn.")> _
    Public Function ObterSelecaoAtualizacaoOperacaoBaixaOperacaoFornecedor(ByVal TipOpe As Integer, _
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
                                                                           ByVal TipIdtEmpAscAcoCmc As Integer) As DatasetOperacaoBaixaOperacaoFornecedor

        Try
            Dim AcordoComercial As New AcordoComercialBP

            Return AcordoComercial.ObterSelecaoAtualizacaoOperacaoBaixaOperacaoFornecedor(TipOpe, _
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

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try

    End Function

    <WebMethod(Description:="Acessar procedure PRCDKSelAtlOpeBxaOpeFrn.")> _
    Public Sub AtualizarOperacaoBaixaOperacaoFornecedor(ByVal TipOpe As Integer, _
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
            Dim AcordoComercial As New AcordoComercialBP

            AcordoComercial.AtualizarOperacaoBaixaOperacaoFornecedor(TipOpe, _
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

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try

    End Sub

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
    <WebMethod(Description:="Preenche o extratro do fornecedor")> _
    Public Function ObterPesquisaExtratoMovimentoDiarioFornecedor(ByVal Ano As Integer, _
                                                                  ByVal Mes As Integer, _
                                                                  ByVal CodFrn As Integer, _
                                                                  ByVal TipDsnDscBnf As Integer, _
                                                                  ByVal FlgDsp As String, _
                                                                  ByVal TipPmt As Integer) As DatasetExtratoMovimentoDiarioFornecedor
        Try
            Dim AcordoComercial As New AcordoComercialBP
            ObterPesquisaExtratoMovimentoDiarioFornecedor = AcordoComercial.ObterPesquisaExtratoMovimentoDiarioFornecedor(Ano, Mes, CodFrn, TipDsnDscBnf, FlgDsp, TipPmt)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Retorna dados do cartório por célula")> _
  Public Function ObterDadosDoCartorioPorCelula(ByVal CodDivCmp As Integer) As DatasetDadosDoCartorioPorCelula
        Try
            Dim AcordoComercial As New AcordoComercialBP
            ObterDadosDoCartorioPorCelula = AcordoComercial.ObterDadosDoCartorioPorCelula(CodDivCmp)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Seleciona as Perdas Disponíveis")> _
    Public Function ObterPerdasDisponiveis(ByVal CODFRN As Integer, _
                                           ByVal CODDIVCMP As Integer) As DatasetPerdasDisponiveis
        Try
            Dim AcordoComercial As New AcordoComercialBP
            ObterPerdasDisponiveis = AcordoComercial.ObterPerdasDisponiveis(CODFRN, CODDIVCMP)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Buscar todos os valores apurados para contratos válidos do fornecedor
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
    <WebMethod(Description:="Buscar todos os valores apurados para contratos válidos do fornecedor")> _
   Public Function ObterValoresApuradosContratosValidosDoFornecedor(ByVal CODFRN As Integer, _
                                                                    ByVal NUMCSLCTTFRN As Integer, _
                                                                    ByVal TIPFRMDSCBNF As Integer, _
                                                                    ByVal TIPDSNDSCBNF As Integer) As DatasetValoresApuradosContratosValidosDoFornecedor
        Try
            Dim AcordoComercial As New AcordoComercialBP
            ObterValoresApuradosContratosValidosDoFornecedor = AcordoComercial.ObterValoresApuradosContratosValidosDoFornecedor(CODFRN, NUMCSLCTTFRN, TIPFRMDSCBNF, TIPDSNDSCBNF)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Selecionar as promessas em aberto de acordo com o empenho em questão
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
    <WebMethod(Description:="Selecionar as promessas em aberto de acordo com o empenho em questão")> _
 Public Function ObterAcordosEmAbertoPorEmpenho(ByVal TipDsnDscBnf As Decimal, _
                                                ByVal TipFrmDscBnf As Decimal, _
                                                ByVal CodDivCmp As Decimal, _
                                                ByVal CodFrn As Decimal) As DatasetAcordosEmAbertoPorEmpenho
        Try
            Dim AcordoComercial As New AcordoComercialBP
            ObterAcordosEmAbertoPorEmpenho = AcordoComercial.ObterAcordosEmAbertoPorEmpenho(TipDsnDscBnf, TipFrmDscBnf, CodDivCmp, CodFrn)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

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
    <WebMethod(Description:="Chamada para procedure: MRT.PCTDLGrcCslTms.PRCDLGrcCslTms.")> _
    Public Function GerarClausulaTrimestralidade(ByVal pvNumCttFrn As Decimal) As Boolean
        Try
            Dim AcordoFornecimento As New AcordoFornecimentoBP

            'Envia os dados à DAL para salvar em banco
            GerarClausulaTrimestralidade = AcordoFornecimento.GerarClausulaTrimestralidade(pvNumCttFrn)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Chamada para procedure: MRT.PCTDLGrcCslAno.PRCDLGrcCslAno.")> _
    Public Function GerarClausulaAnualidade(ByVal pvNumCttFrn As Decimal) As Boolean
        Try
            Dim AcordoFornecimento As New AcordoFornecimentoBP

            'Envia os dados à DAL para salvar em banco
            GerarClausulaAnualidade = AcordoFornecimento.GerarClausulaAnualidade(pvNumCttFrn)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Chamada para procedure: MRT.PCTDKAtlCntCrrFrn.PRCDKAtlCntCrrFrn
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
    ''' Chamada para procedure: MRT.PCTDKAtlCntCrrFrn.PRCDKAtlCntCrrFrn
    ''' LEGADO: CCX001GA
    ''' </remarks>
    ''' <history>
    '''     [Elifázio Bernardes]    21/11/2006  Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Chamada para procedure: MRT.PCTDKAtlCntCrrFrn.PRCDKAtlCntCrrFrn.")> _
    Public Sub AtualizarContaCorrenteFornecedor2(ByVal pvDatRefLmt As Date, _
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
        Try
            Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorBP

            ContaCorrenteFornecedor.AtualizarContaCorrenteFornecedor(pvDatRefLmt, _
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

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Chamada para procedure: MRT.PCTDKAtlCntCrrFrn.PRCDKAtlCntCrrFrn.")> _
    Public Sub InsereVaresApuradosContratoValido(ByVal pvNUMCTTFRN As Decimal, _
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
        Try
            Dim AcordoComercial As New AcordoComercialBP

            AcordoComercial.InsereVaresApuradosContratoValido(pvNUMCTTFRN, _
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

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Chamada para procedure: MRT.PCTDKAtlCntCrrFrn.PRCDKAtlCntCrrFrn.")> _
    Public Sub InserePromessasEmAbertoDeAcordoEmpenho(ByVal pvNUMCTTFRN As Decimal, _
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
        Try
            Dim AcordoComercial As New AcordoComercialBP

            AcordoComercial.InserePromessasEmAbertoDeAcordoEmpenho(pvNUMCTTFRN, _
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

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Chamada para procedure: MRT.PCTDKAtlCntCrrFrn.PRCDKAtlCntCrrFrn.")> _
    Public Sub CancelarPerdasDisponiveis(ByVal pvTIPOPE As Integer, _
                                         ByVal pvNUMCTTFRN As Decimal, _
                                         ByVal pvNUMCSLCTTFRN As Decimal, _
                                         ByVal pvTIPPODCTTFRN As Decimal, _
                                         ByVal pvNUMREFPOD As Decimal, _
                                         ByVal pvTIPEDEABGMIX As Decimal, _
                                         ByVal pvCODEDEABGMIX As Decimal, _
                                         ByVal pvDATREFAPU As Date, _
                                         ByVal pvVLRPDACNC As Decimal)
        Try
            Dim AcordoComercial As New AcordoComercialBP

            AcordoComercial.CancelarPerdasDisponiveis(pvTIPOPE, _
                                                      pvNUMCTTFRN, _
                                                      pvNUMCSLCTTFRN, _
                                                      pvTIPPODCTTFRN, _
                                                      pvNUMREFPOD, _
                                                      pvTIPEDEABGMIX, _
                                                      pvCODEDEABGMIX, _
                                                      pvDATREFAPU, _
                                                      pvVLRPDACNC)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Chamada para procedure: MRT.PCTDKAtlCntCrrFrn.PRCDKAtlCntCrrFrn.")> _
    Public Function GravarObservacaoPerdaAcordo(ByVal pvTIPOPE As Integer, _
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
                                                ByVal pvDATGRCOBSPMS As Date) As DatasetAcordo
        Try
            Dim AcordoComercial As New AcordoComercialBP

            Return AcordoComercial.GravarObservacaoPerdaAcordo(pvTIPOPE, _
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

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Chamada para procedure: MRT.PCTDKSelAcoCmcBxa.PRCDKSelAcoCmcBxa")> _
    Public Function ObterAcoesComerciaisBaixa(ByVal pvCodpms As Decimal, _
                                              ByVal pvCodFilEmp As Decimal, _
                                              ByVal pvnumpedcmp As Decimal, _
                                              ByVal pvCodFrn As Decimal, _
                                              ByVal pvDatIniPod As Date, _
                                              ByVal pvDatFimPod As Date, _
                                              ByVal pvflag As Integer) As DatasetAcordo
        Try
            Dim AcordoComercial As New AcordoComercialBP

            Return AcordoComercial.ObterAcoesComerciaisBaixa(pvCodpms, _
                                                             pvCodFilEmp, _
                                                             pvnumpedcmp, _
                                                             pvCodFrn, _
                                                             pvDatIniPod, _
                                                             pvDatFimPod, _
                                                             pvflag)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try

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
    <WebMethod(Description:="Chamada para procedure: MRT.PCTDKObtMaxCodOrdPgtFrnAsc.PRCDKObtMaxCodOrdPgtFrnAsc")> _
    Public Function ObterMaximoDeCodigoOrdemPagamentoFornecedor(ByVal pvCodFrn As Integer) As DatasetOPRecebidaFornecedor
        Try
            Dim AcordoComercial As New AcordoComercialBP

            Return AcordoComercial.ObterMaximoDeCodigoOrdemPagamentoFornecedor(pvCodFrn)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Realiza transferencia")> _
    Public Sub TransferirValoresEntreEmpenhosFornecedor(ByVal pValor As Decimal, _
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


        Try
            Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorBP

            ContaCorrenteFornecedor.TransferirValoresEntreEmpenhosFornecedor(pValor, _
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

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Sub

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
    <WebMethod(Description:="Obtem diretoria e divisão de compra de fornecedor")> _
    Public Function ObterDiretoriaEDivisaoDeCompraDeFornecedor(ByVal pvCodFrn As Decimal) As DatasetDiretoriaEDivisaoDeCompraDeFornecedor
        Try
            Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorBP
            Dim ds As DatasetDiretoriaEDivisaoDeCompraDeFornecedor
            ds = ContaCorrenteFornecedor.ObterDiretoriaEDivisaoDeCompraDeFornecedor(pvCodFrn)
            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

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
    <WebMethod(Description:="Apura Acordo de Fornecimento")> _
    Public Sub ApurarAcordoGeralDeFornecimento(ByVal ppin_NumCttFrn As Decimal, _
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

        Try
            Dim AcordoComercial As New AcordoComercialBP
            AcordoComercial.ApurarAcordoGeralDeFornecimento(ppin_NumCttFrn, _
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
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Sub

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0125046")> _
    Public Function ObterEntidade(ByVal CODEDEABGMIX As Decimal, _
                                  ByVal DATREFAPU As Date, _
                                  ByVal NUMCSLCTTFRN As Decimal, _
                                  ByVal NUMCTTFRN As Decimal, _
                                  ByVal NUMREFPOD As Decimal, _
                                  ByVal TIPEDEABGMIX As Decimal, _
                                  ByVal TIPPODCTTFRN As Decimal) As DatasetEntidade
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetEntidade As DatasetEntidade

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetEntidade = AcordoFornecimentoBP.ObterEntidade(CODEDEABGMIX, DATREFAPU, NUMCSLCTTFRN, NUMCTTFRN, NUMREFPOD, TIPEDEABGMIX, TIPPODCTTFRN)

            Return DatasetEntidade
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0125046")> _
    Public Function ObterEntidades(ByVal CODEDEABGMIX As Decimal, _
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
                                   ByVal TIPPODCTTFRN As Decimal) As DatasetEntidade
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetEntidade As DatasetEntidade

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetEntidade = AcordoFornecimentoBP.ObterEntidades(CODEDEABGMIX, CODFXAAVL, CODPMS, DATNGCPMS, DATNGCPMSInicial, DATNGCPMSFinal, DATREFAPU, DATREFAPUInicial, DATREFAPUFinal, NUMCSLCTTFRN, NUMCTTFRN, NUMCTTFRNAPUPOD, NUMREFPOD, TIPEDEABGMIX, TIPPODCTTFRN)

            Return DatasetEntidade
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0125046")> _
    Public Function AtualizarEntidade(ByVal DatasetEntidade As DatasetEntidade) As Boolean
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            AcordoFornecimentoBP = New AcordoFornecimentoBP
            AcordoFornecimentoBP.AtualizarEntidade(DatasetEntidade)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="")> _
    Public Function VerificaParcial(ByVal codPms As Decimal, ByVal numNota As Decimal) As Decimal
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim promessaParcial As Decimal

            AcordoComercialBP = New AcordoComercialBP
            promessaParcial = AcordoComercialBP.VerificaParcial(codPms, numNota)

            Return promessaParcial
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

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
    <WebMethod(Description:="")> _
    Public Function ManterClausulaContrato(ByVal ppin_IndPrc As Integer, _
                                           ByVal ppin_NumCslCttFrn As Integer, _
                                           ByVal ppin_CodFrnPcpApuArdFrn As Integer, _
                                           ByVal ppin_NumCttFrn As Integer, _
                                           ByVal ppin_CodFrnAscApuArdFrn As Integer, _
                                           ByVal ppin_NumCttFrnAcs As Integer) As Integer
        Try
            Dim AcordoFornecimento As New AcordoFornecimentoBP

            Return AcordoFornecimento.ManterClausulaContrato(ppin_IndPrc, _
                                                             ppin_NumCslCttFrn, _
                                                             ppin_CodFrnPcpApuArdFrn, _
                                                             ppin_NumCttFrn, _
                                                             ppin_CodFrnAscApuArdFrn, _
                                                             ppin_NumCttFrnAcs)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="")> _
    Public Function GeraFaixasParaAbrangencia(ByVal ppin_CTT As Decimal, _
                                              ByVal ppin_CSL As Decimal, _
                                              ByVal ppin_ABG As Decimal, _
                                              ByVal ppin_EDE As Decimal, _
                                              ByVal ppin_VLRFXA As Decimal, _
                                              ByVal ppin_VLRREC As Decimal, _
                                              ByVal ppin_PER As Decimal, _
                                              ByVal ppid_DATREFINIUTZPMT As Date) As Boolean
        Try
            Dim AcordoFornecimento As New AcordoFornecimentoBP

            Return AcordoFornecimento.GeraFaixasParaAbrangencia(ppin_CTT, _
                                                                ppin_CSL, _
                                                                ppin_ABG, _
                                                                ppin_EDE, _
                                                                ppin_VLRFXA, _
                                                                ppin_VLRREC, _
                                                                ppin_PER, _
                                                                ppid_DATREFINIUTZPMT)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try

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
    <WebMethod(Description:="")> _
    Public Function ObtemFornecedorEPeriodoContrato(ByVal ppin_CodOpc As Integer, _
                                                    ByVal ppin_CodPar As Integer, _
                                                    ByVal ppis_DesPar As String, _
                                                    ByVal ppin_TipOrd As Integer, _
                                                    ByVal ppin_CodEmp As Integer) As DatasetFornecedorEPeriodoContrato
        Try
            Dim AcordoFornecimento As New AcordoFornecimentoBP

            ObtemFornecedorEPeriodoContrato = AcordoFornecimento.ObtemFornecedorEPeriodoContrato(ppin_CodOpc, _
                                                                                                 ppin_CodPar, _
                                                                                                 ppis_DesPar, _
                                                                                                 ppin_TipOrd, _
                                                                                                 ppin_CodEmp)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="")> _
    Public Function ManterFaixasDeCrescimento(ByVal ppin_CTT As Integer, _
                                              ByVal ppin_CSL As Integer, _
                                              ByVal ppin_ABG As Integer, _
                                              ByVal ppin_EDE As Integer, _
                                              ByVal ppin_VLRFXA As Decimal, _
                                              ByVal ppin_VLRREC As Decimal, _
                                              ByVal ppin_PER As Decimal, _
                                              ByVal ppin_CODFXA As Integer, _
                                              ByVal ppid_DATREFINIUTZPMT As Date) As Boolean
        Try
            Dim AcordoFornecimento As New AcordoFornecimentoBP

            Return AcordoFornecimento.ManterFaixasDeCrescimento(ppin_CTT, _
                                                                ppin_CSL, _
                                                                ppin_ABG, _
                                                                ppin_EDE, _
                                                                ppin_VLRFXA, _
                                                                ppin_VLRREC, _
                                                                ppin_PER, _
                                                                ppin_CODFXA, _
                                                                ppid_DATREFINIUTZPMT)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="")> _
    Public Sub AtualizarParametrosAlocacaoVerbas(ByVal ppin_TipOpe As Integer, _
                                                 ByVal ppin_NumCtt_Query As Integer, _
                                                 ByVal ppin_NumCttFrn As Integer, _
                                                 ByVal ppin_NumCSl_Query As Integer, _
                                                 ByVal ppin_TipEde_Query As Integer, _
                                                 ByVal ppin_CodEde_Query As Decimal, _
                                                 ByVal ppin_PerVlrRcb As Integer, _
                                                 ByVal ppin_PerVlrRcb_Query As Integer, _
                                                 ByVal ppin_ReqAlcVba_Query As Integer)
        Try
            Dim AcordoFornecimento As New AcordoFornecimentoBP

            'Envia os dados à DAL para salvar em banco
            AcordoFornecimento.AtualizarParametrosAlocacaoVerbas(ppin_TipOpe, _
                                                                 ppin_NumCtt_Query, _
                                                                 ppin_NumCttFrn, _
                                                                 ppin_NumCSl_Query, _
                                                                 ppin_TipEde_Query, _
                                                                 ppin_CodEde_Query, _
                                                                 ppin_PerVlrRcb, _
                                                                 ppin_PerVlrRcb_Query, _
                                                                 ppin_ReqAlcVba_Query)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try

    End Sub

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
    <WebMethod(Description:="")> _
    Public Function ObterDistinctDatRefIniUtzPmtDeFaixa(ByVal NUMCTTFRN As Decimal, _
                                                        ByVal NUMCSLCTTFRN As Decimal, _
                                                        ByVal TIPEDEABGMIX As Decimal, _
                                                        ByVal CODEDEABGMIX As Decimal) As DatasetFaixaAvaliacao

        Try
            Dim AcordoFornecimento As New AcordoFornecimentoBP
            ObterDistinctDatRefIniUtzPmtDeFaixa = AcordoFornecimento.ObterDistinctDatRefIniUtzPmtDeFaixa(NUMCTTFRN, _
                                                                                                         NUMCSLCTTFRN, _
                                                                                                         TIPEDEABGMIX, _
                                                                                                         CODEDEABGMIX)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="")> _
    Public Function ObterDistinctDATINIPODDePeriodo(ByVal NUMCTTFRN As Decimal, _
                                                    ByVal NUMCSLCTTFRN As Decimal, _
                                                    ByVal TIPPODCTTFRN As Decimal) As DatasetContratoXPeriodo

        Try
            Dim AcordoFornecimento As New AcordoFornecimentoBP
            ObterDistinctDATINIPODDePeriodo = AcordoFornecimento.ObterDistinctDATINIPODDePeriodo(NUMCTTFRN, _
                                                                                                 NUMCSLCTTFRN, _
                                                                                                 TIPPODCTTFRN)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Chamada para procedure: MRT.PctDLAtlPgcAutCttArdFrn.PrcDlPodCslCtt")> _
    Public Sub GerarPeriodosParaClausulaDeContrato(ByVal ppin_Ctt As Integer, _
                                                   ByVal ppin_Cla As Integer, _
                                                   ByVal ppin_Per As Integer)
        Try
            Dim AcordoFornecimento As New AcordoFornecimentoBP

            AcordoFornecimento.GerarPeriodosParaClausulaDeContrato(ppin_Ctt, _
                                                                   ppin_Cla, _
                                                                   ppin_Per)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Chamada para procedure: MRT.PCTDLCnsAscCslFrn.PRCDLCnsAscCslFrn")> _
    Public Function ObterAssociacaoClausulaFornecedor(ByVal pvCodFrn As Decimal, _
                                                      ByVal pvNumCttFrn As Decimal, _
                                                      ByVal pvNumCslCttFrn As Decimal) As DatasetContrato

        Try
            Dim AcordoFornecimento As New AcordoFornecimentoBP

            'Envia os dados à DAL para salvar em banco
            Return AcordoFornecimento.ObterAssociacaoClausulaFornecedor(pvCodFrn, _
                                                                        pvNumCttFrn, _
                                                                        pvNumCslCttFrn)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
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
    <WebMethod(Description:="Chamada para procedure: MRT.PCTDLSelAltVlrEftDsc.PRCDLSelAltVlrEftDsc")> _
    Public Function SelecionarEAlterarValorEfetivoDesconto(ByVal pvOperacao As Integer, _
                                                           ByVal pvNumCttFrn As Decimal, _
                                                           ByVal pvNumCslCttFrn As Decimal, _
                                                           ByVal pvTipPodCttFrn As Decimal, _
                                                           ByVal pvNumRefPod As Decimal, _
                                                           ByVal pvTipEdeAbgMix As Decimal, _
                                                           ByVal pvCodEdeAbgMixEnt As Decimal, _
                                                           ByVal pvDatRefApu As Date, _
                                                           ByVal pvVlrDscRcbEftFxa As Decimal, _
                                                           ByVal pvNomAcsUsrSis As String) As DatasetValorEfetivoDesconto
        Try
            Dim AcordoComercial As New AcordoComercialBP
            Return AcordoComercial.SelecionarEAlterarValorEfetivoDesconto(pvOperacao, _
                                                                          pvNumCttFrn, _
                                                                          pvNumCslCttFrn, _
                                                                          pvTipPodCttFrn, _
                                                                          pvNumRefPod, _
                                                                          pvTipEdeAbgMix, _
                                                                          pvCodEdeAbgMixEnt, _
                                                                          pvDatRefApu, _
                                                                          pvVlrDscRcbEftFxa, _
                                                                          pvNomAcsUsrSis)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function


    <WebMethod(Description:="ObterContaUsuario")> _
    Public Function ObterContaUsuario(ByVal CODFNC As Decimal) As DatasetContaUsuario
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetContaUsuario As DatasetContaUsuario

            AcordoComercialBP = New AcordoComercialBP
            DatasetContaUsuario = AcordoComercialBP.ObterContaUsuario(CODFNC)

            Return DatasetContaUsuario
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0124945")> _
    Public Function ObterContratoComparativoValores(ByVal CODFRN As Decimal) As DatasetContrato
        Try
            Dim AcordoFornecimentoBP As AcordoFornecimentoBP
            Dim DatasetContrato As DatasetContrato

            AcordoFornecimentoBP = New AcordoFornecimentoBP
            DatasetContrato = AcordoFornecimentoBP.ObterContratoComparativoValores(CODFRN)

            Return DatasetContrato
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Obter Dados para o Relatorio Previsao Apuracao")> _
    Public Function ObterPrevisaoApuracao(ByVal FILTRO As Decimal, _
                                          ByVal CODFRN As Decimal, _
                                          ByVal CODCPR As Decimal, _
                                          ByVal CODDIV As Decimal, _
                                          ByVal CODDRT As Decimal) As DatasetPrevisaoApuracao
        Try
            Dim PrevisaoApuracaoBP As PrevisaoApuracaoBP
            Dim DatasetPrevisaoApuracao As DatasetPrevisaoApuracao

            PrevisaoApuracaoBP = New PrevisaoApuracaoBP
            DatasetPrevisaoApuracao = PrevisaoApuracaoBP.ObterPrevisaoApuracao(FILTRO, CODFRN, CODCPR, CODDIV, CODDRT)

            Return DatasetPrevisaoApuracao
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

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
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="LÓGICA DA PROC spCLJ095 MIGRADA PARA FRAMEWORK MARTINS.")> _
    Public Function AtualizarValorUtilizado(ByVal NumCttFrn As Integer, _
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
        Try
            AtualizarValorUtilizado = False
            Dim AcordoComercial As New AcordoComercialBP
            AtualizarValorUtilizado = AcordoComercial.AtualizarValorUtilizado(NumCttFrn, NumCslCttFrn, TipPodCttFrn, NumRefPod, TipEdeAbgMix, CodEdeAbgMix, DatRefApu, NumSeqRlcCttPms, CodFrn, CodEmpFrn, NumNotFscFrnCtb, CodSeqPclNotFsc, NumSeqTitPgt, CodEmp, CodFilEmp, VlrUtzCtt, FlgSitNgcDup, TipDscPgtFvc, TipFrmDscBnf, TipDsnDscBnf, NomAcsUsrSis)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
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
    <WebMethod(Description:="LÓGICA DA PROC spCLJ096 MIGRADA PARA FRAMEWORK MARTINS")> _
    Public Function GerarLinhaDescontoBonificacao(ByVal NumCttFrn As Integer, _
                                                  ByVal NumCslCttFrn As Integer, _
                                                  ByVal TipPodCttFrn As Integer, _
                                                  ByVal NumRefPod As Integer, _
                                                  ByVal TipEdeAbgMix As Integer, _
                                                  ByVal CodEdeAbgMix As Decimal, _
                                                  ByVal DatRefApu As Date, _
                                                  ByVal VlrRcbEftFxa As Decimal, _
                                                  ByVal TipFrmDscBnf As Integer, _
                                                  ByVal NumSeqRlcCttPms As Decimal) As Boolean

        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            GerarLinhaDescontoBonificacao = AcordoComercialBP.GerarLinhaDescontoBonificacao(NumCttFrn, NumCslCttFrn, TipPodCttFrn, NumRefPod, TipEdeAbgMix, CodEdeAbgMix, DatRefApu, VlrRcbEftFxa, TipFrmDscBnf, NumSeqRlcCttPms)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
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
    <WebMethod(Description:="LÓGICA DA PROC spCLJ097 MIGRADA PARA FRAMEWORK MARTINS.")> _
    Public Function AtualizaSituacaoNegociacao(ByVal NumCttFrn As Integer, _
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
        Try
            AtualizaSituacaoNegociacao = False
            Dim AcordoComercial As New AcordoComercialBP
            AtualizaSituacaoNegociacao = AcordoComercial.AtualizaSituacaoNegociacao(NumCttFrn, NumCslCttFrn, TipPodCttFrn, NumRefPod, TipEdeAbgMix, CodEdeAbgMixEnt, DatRefApu, NumSeqRlcCttPms, VlrNgcPms, CodPms, DatNgcPms, VlrEftDscPcl, FlgSitNgcDup, NomAcsUsrSis, CodEmp, CodFilEmp, TipFrmDscBnf, TipDsnDscBnf, CodFrn, CodEmpFrn, NumNotFscFrnCtb, CodSeqPclNotFsc, NumSeqTitPgt, TipDscPgtFvc, DatPrvRcbPms)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
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
    <WebMethod(Description:="Obter Destino Verba Prometida")> _
    Public Function ObterDestinoVerbaPrometida(ByVal NumCttFrn As Integer, ByVal NumCslCttFrn As Integer) As DataSet
        Try
            Dim AcordoComercial As New AcordoComercialBP
            Return AcordoComercial.ObterDestinoVerbaPrometida(NumCttFrn, NumCslCttFrn)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
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
    <WebMethod(Description:="Obter Data Previsao Recebimento")> _
    Public Function ObterDataPrevisaoRecebimento(ByVal NumCttFrn As Integer, _
                                                                ByVal NumCslCttFrn As Integer, _
                                                                ByVal TipPodCttFrn As Integer, _
                                                                ByVal NumRefPod As Integer) As DataSet
        Try
            Dim AcordoComercial As New AcordoComercialBP
            Return AcordoComercial.ObterDataPrevisaoRecebimento(NumCttFrn, NumCslCttFrn, TipPodCttFrn, NumRefPod)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
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
    <WebMethod(Description:="Seleciona as duplicatas de um fornecedor CLJ072.")> _
    Public Function ObterDuplicatasDisponiveis(ByVal CodFrn As Integer) As DatasetDuplicatasDisponiveis
        Try
            Dim AcordoComercial As New AcordoComercialBP
            Return AcordoComercial.ObterDuplicatasDisponiveis(CodFrn)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
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
    <WebMethod(Description:="TROCA MANUAL DE TITULOS DE PAGAMENTO DE ACORDOS COMERCIAIS")> _
    Public Function ObterTrocaManualTituloPagamentoAcordoComercial(ByVal vpTipCsn As Integer, _
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
                                                                    ByVal vpVlrTitPgtUtzSbtPms As Decimal) As DatasetTrocaManualTituloPagamentoAcordoComercial
        Try
            Dim AcordoComercial As New AcordoComercialBP
            Return AcordoComercial.ObterTrocaManualTituloPagamentoAcordoComercial(vpTipCsn, _
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
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

#End Region

#Region " Relatórios "
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Relatorio Historico Baixa por OP
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
    <WebMethod(Description:="Relatorio Historico Baixa por OP. Dataset com a Tabela preenchida")> _
    Public Function ObterRelatorioHistoricoBaixaOP(ByVal pDatInicial As String, ByVal pDatFinal As String, ByVal pCodFrn As Integer, ByVal pNomFrn As String) As DatasetRelatorioHistoricoBaixaOP
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelatorioHistoricoBaixaOP

            ds = AcordoComercialBP.ObterRelatorioHistoricoBaixaOP(pDatInicial, pDatFinal, pCodFrn, pNomFrn)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

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
    <WebMethod(Description:="Relatorio Historico Contrato X Promessa. Dataset com a Tabela tbHistoricoAcordo preenchida")> _
    Public Function ObterRelatorioHistoricoAcordo(ByVal pCodPms As Integer) As DatasetRelatorioHistoricoAcordo
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelatorioHistoricoAcordo

            ds = AcordoComercialBP.ObterRelatorioHistoricoAcordo(pCodPms)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Relatorio Historico Acordo Fornecimento rpclj027.rpt. Dataset com a Tabela tbAcordoFornecimento_027 preenchida")> _
    Public Function ObterRelatorioAcordoFornecimento_027(ByVal CodDivCmp As Decimal, ByVal NumCslCttFrn As Decimal, ByVal TipPodCttFrn As Decimal, ByVal DatIni As Date, ByVal DatFim As Date) As DatasetRelatorioAcordoFornecimento
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelatorioAcordoFornecimento

            ds = AcordoComercialBP.ObterRelatorioAcordoFornecimento_027(CodDivCmp, NumCslCttFrn, TipPodCttFrn, DatIni, DatFim)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Relatorio Historico Acordo Fornecimento rpclj041.rpt. Dataset com a Tabela tbAcordoFornecimento_041 preenchida")> _
    Public Function ObterRelatorioAcordoFornecimento_041(ByVal CodDivCmp As Integer, ByVal NumCslCttFrn As Decimal, ByVal TipPodCttFrn As Decimal, ByVal DatIni As Date, ByVal DatFim As Date) As DatasetRelatorioAcordoFornecimento
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelatorioAcordoFornecimento

            ds = AcordoComercialBP.ObterRelatorioAcordoFornecimento_041(CodDivCmp, NumCslCttFrn, TipPodCttFrn, DatIni, DatFim)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Relatorio Historico Acordo Fornecimento rpclj022.rpt. Dataset com a Tabela tbAcordoFornecimento_022 preenchida")> _
    Public Function ObterRelatorioAcordoFornecimento_022(ByVal CodFrn As Decimal, _
                                                         ByVal TipPod As Decimal, _
                                                         ByVal NumCttFrn As Decimal, _
                                                         ByVal NumCslCttFrn As Decimal, _
                                                         ByVal TipEdeAbgMix As Decimal, _
                                                         ByVal CodEdeAbgMix As Decimal, _
                                                         ByVal NumRefPod As Decimal, _
                                                         ByVal DatIniPod As Date) As DatasetRelatorioAcordoFornecimento
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelatorioAcordoFornecimento

            ds = AcordoComercialBP.ObterRelatorioAcordoFornecimento_022(CodFrn, TipPod, NumCttFrn, NumCslCttFrn, TipEdeAbgMix, CodEdeAbgMix, NumRefPod, DatIniPod)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Relatorio Acordo Fornecimento rpclj023.rpt. Dataset com a Tabela tbAcordoFornecimento_023 preenchida")> _
    Public Function ObterRelatorioAcordoFornecimento_023(ByVal CodFrn As Decimal, _
                                                         ByVal TipPod As Decimal, _
                                                         ByVal NumCttFrn As Decimal, _
                                                         ByVal NumCslCttFrn As Decimal, _
                                                         ByVal TipEdeAbgMix As Decimal, _
                                                         ByVal CodEdeAbgMixPAR As Decimal, _
                                                         ByVal NumRefPod As Decimal, _
                                                         ByVal DatIniPodPAR As Date) As DatasetRelatorioAcordoFornecimento
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelatorioAcordoFornecimento

            ds = AcordoComercialBP.ObterRelatorioAcordoFornecimento_023(CodFrn, TipPod, NumCttFrn, NumCslCttFrn, TipEdeAbgMix, CodEdeAbgMixPAR, NumRefPod, DatIniPodPAR)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Relatorio Acordo Fornecimento (rpcClj051B.rpt – Procedure: spClj051;1 | rpcClj051A.rpt – Procedure: spClj051;1). Dataset com a Tabela tbAcordoFornecimento_051 preenchida")> _
    Public Function ObterRelatorioAcordoFornecimento_051(ByVal CodFrn As Decimal, _
                                                        ByVal TipPod As Decimal, _
                                                        ByVal NumCttFrn As Decimal, _
                                                        ByVal NumCslCttFrn As Decimal, _
                                                        ByVal TipEdeAbgMix As Decimal, _
                                                        ByVal CodEdeAbgMixPAR As Decimal, _
                                                        ByVal NumRefPod As Decimal, _
                                                        ByVal DatIniPodPAR As Date) As DatasetRelatorioAcordoFornecimento
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelatorioAcordoFornecimento

            ds = AcordoComercialBP.ObterRelatorioAcordoFornecimento_051(CodFrn, TipPod, NumCttFrn, NumCslCttFrn, TipEdeAbgMix, CodEdeAbgMixPAR, NumRefPod, DatIniPodPAR)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Relatorio Acordo Fornecimento. Dataset com a Tabela tbAcordoFornecimento_052 preenchida")> _
    Public Function ObterRelatorioAcordoFornecimento_052(ByVal CodFrn As Integer, _
                                                        ByVal TipPod As Integer, _
                                                        ByVal NumCttFrn As Decimal, _
                                                        ByVal NumCslCttFrn As Integer, _
                                                        ByVal TipEdeAbgMix As Integer, _
                                                        ByVal CodEdeAbgMixPAR As Decimal, _
                                                        ByVal NumRefPod As Integer, _
                                                        ByVal DatRefPod As Date) As DatasetRelatorioAcordoFornecimento
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelatorioAcordoFornecimento

            ds = AcordoComercialBP.ObterRelatorioAcordoFornecimento_052(CodFrn, TipPod, NumCttFrn, NumCslCttFrn, TipEdeAbgMix, CodEdeAbgMixPAR, NumRefPod, DatRefPod)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Relatorio Acordo Fornecimento rpcclj053.rpt. Dataset com a Tabela tbAcordoFornecimento_053 preenchida")> _
    Public Function ObterRelatorioAcordoFornecimento_053(ByVal CodFrn As Decimal, _
                                                        ByVal TipPod As Decimal, _
                                                        ByVal NumCttFrn As Decimal, _
                                                        ByVal NumCslCttFrn As Decimal, _
                                                        ByVal TipEdeAbgMix As Decimal, _
                                                        ByVal CodEdeAbgMixPAR As Decimal, _
                                                        ByVal NumRefPod As Decimal, _
                                                        ByVal DatRefPodPar As Date) As DatasetRelatorioAcordoFornecimento
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelatorioAcordoFornecimento

            ds = AcordoComercialBP.ObterRelatorioAcordoFornecimento_053(CodFrn, TipPod, NumCttFrn, NumCslCttFrn, TipEdeAbgMix, CodEdeAbgMixPAR, NumRefPod, DatRefPodPar)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Relatorio Acordo Fornecimento rpclj070.rpt - proc spCLJ074
    ''' </summary>
    ''' <param name="Opcao"></param>
    ''' <param name="CodFrn"></param>
    '''  <<returns>Dataset com a Tabela tbAcordoFornecimento_074 preenchida</returns>
    ''' <remarks>
    ''' O posfixo 074 é por compatibilidade do nome do legado
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	15/9/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Relatorio Acordo Fornecimento rpclj070.rpt. Dataset com a Tabela tbAcordoFornecimento_074 preenchida")> _
    Public Function ObterRelatorioAcordoFornecimento_074(ByVal Opcao As Integer, _
                                                         ByVal CodFrn As Integer) As DatasetRelatorioAcordoFornecimento
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelatorioAcordoFornecimento

            ds = AcordoComercialBP.ObterRelatorioAcordoFornecimento_074(Opcao, CodFrn)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Relatorio Acordo p/Deduction e Acordo s/NF p/Deduction. Dataset com a Tabela tbAcordoParaDeduction preenchida")> _
    Public Function ObterRelatorioAcordoParaDeduction(ByVal TipOpeEnt As Integer, _
                                                      ByVal CodFrnEnt As Integer, _
                                                      ByVal CodDivCmpEnt As Integer, _
                                                      ByVal TipFrmDscBnfEnt As Integer, _
                                                      ByVal DatIniEnt As Date, _
                                                      ByVal DatFimEnt As Date, _
                                                      ByVal ChkEfetivadoEnt As Integer, _
                                                      ByVal ChkAssociadoEnt As Integer) As DatasetRelatorioAcordoParaDeduction
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelatorioAcordoParaDeduction

            ds = AcordoComercialBP.ObterRelatorioAcordoParaDeduction(TipOpeEnt, CodFrnEnt, CodDivCmpEnt, TipFrmDscBnfEnt, DatIniEnt, DatFimEnt, ChkEfetivadoEnt, ChkAssociadoEnt)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Conferencia Ação Tática. Dataset com a Tabela tbConferenciaAcaoTatica preenchida")> _
    Public Function ObterRelatorioConferenciaAcaoTatica(ByVal CodFrn As Integer, _
                                                        ByVal MesRef As String, _
                                                        ByVal Opcao As Integer) As DatasetRelatorioConferenciaAcaoTatica
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelatorioConferenciaAcaoTatica

            ds = AcordoComercialBP.ObterRelatorioConferenciaAcaoTatica(CodFrn, MesRef, Opcao)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Conta A Receber CBY002ZA.RPT. Dataset com a Tabela tbContasAReceber_02ZA preenchida")> _
    Public Function ObterRelatorioContasAReceber_02ZA(ByVal DatInicial As Date, _
                                                      ByVal DatFinal As Date, _
                                                      ByVal CelI As Integer, _
                                                      ByVal CelF As Integer, _
                                                      ByVal FrnI As Integer, _
                                                      ByVal FrnF As Integer, _
                                                      ByVal FrmI As Integer, _
                                                      ByVal FrmF As Integer, _
                                                      ByVal DsnI As Integer, _
                                                      ByVal DsnF As Integer, _
                                                      ByVal Abo As Integer) As DatasetRelatorioContasAReceber
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelatorioContasAReceber

            ds = AcordoComercialBP.ObterRelatorioContasAReceber_02ZA(DatInicial, DatFinal, CelI, CelF, FrnI, FrnF, FrmI, FrmF, DsnI, DsnF, Abo)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Contas a Receber Sintético CBY002ZB.RPT. Dataset com a Tabela tbContasAReceber_02ZB preenchida")> _
    Public Function ObterRelatorioContasAReceber_02ZB(ByVal PmtIdtSmn As Integer, _
                                                      ByVal CodCelI As Integer, _
                                                      ByVal CodCelF As Integer, _
                                                      ByVal CodFrnI As Integer, _
                                                      ByVal CodFrnF As Integer, _
                                                      ByVal TipFrmI As Integer, _
                                                      ByVal TipFrmF As Integer, _
                                                      ByVal TipDsnI As Integer, _
                                                      ByVal TipDsnF As Integer, _
                                                      ByVal PmtFlgTot As Integer) As DatasetRelatorioContasAReceber
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelatorioContasAReceber

            ds = AcordoComercialBP.ObterRelatorioContasAReceber_02ZB(PmtIdtSmn, CodCelI, CodCelF, CodFrnI, CodFrnF, TipFrmI, TipFrmF, TipDsnI, TipDsnF, PmtFlgTot)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Conta A Receber ABC - Saldo em Aberto CBY002ZC.RPT. Dataset com a Tabela tbContasAReceber_02ZC preenchida")> _
    Public Function ObterRelatorioContasAReceber_02ZC(ByVal CodCelI As Integer, _
                                                      ByVal CodCelF As Integer, _
                                                      ByVal CodFrnI As Integer, _
                                                      ByVal CodFrnF As Integer, _
                                                      ByVal IdtFlgTod As Integer) As DatasetRelatorioContasAReceber
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelatorioContasAReceber

            ds = AcordoComercialBP.ObterRelatorioContasAReceber_02ZC(CodCelI, CodCelF, CodFrnI, CodFrnF, IdtFlgTod)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Conta A Receber ABC - Saldo em Aberto - A Emitir CBY002ZC1.RPT. Dataset com a Tabela tbContasAReceber_02ZC1 preenchida.")> _
    Public Function ObterRelatorioContasAReceber_02ZC1(ByVal CodDivCmp As Integer, _
                                                       ByVal CodFrn As Integer, _
                                                       ByVal NumCslCttFrn As Integer) As DatasetRelatorioContasAReceber
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelatorioContasAReceber

            ds = AcordoComercialBP.ObterRelatorioContasAReceber_02ZC1(CodDivCmp, CodFrn, NumCslCttFrn)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Conta A Receber - Acordos com Situação de Erro CBY002ZE1.RPT. Dataset com a Tabela tbContasAReceber_02ZE1 preenchida.")> _
    Public Function ObterRelatorioContasAReceber_02ZE1(ByVal DatIni As Date, _
                                                       ByVal DatFim As Date) As DatasetRelatorioContasAReceber
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelatorioContasAReceber

            ds = AcordoComercialBP.ObterRelatorioContasAReceber_02ZE1(DatIni, DatFim)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Conta A Receber - Aging List Analítico ( Valores a receber por idade ) CBY002ZF.RPT.")> _
    Public Function ObterRelatorioContasAReceber_02ZF(ByVal CodCelI As Integer, _
                                                      ByVal CodCelF As Integer, _
                                                      ByVal CodFrnI As Integer, _
                                                      ByVal CodFrnF As Integer, _
                                                      ByVal QdeDiaInt As Integer, _
                                                      ByVal IdtFlgTod As Integer, _
                                                      ByVal vTipIdtEmp As Integer) As DatasetRelatorioContasAReceber
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelatorioContasAReceber

            ds = AcordoComercialBP.ObterRelatorioContasAReceber_02ZF(CodCelI, CodCelF, CodFrnI, CodFrnF, QdeDiaInt, IdtFlgTod, vTipIdtEmp)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Conta A Receber - INF. DO.AGING LIST SINTETICO ( VALORES A RECEBER POR IDADE) CBY002ZG.RPT")> _
    Public Function ObterRelatorioContasAReceber_02ZG(ByVal CodCelI As Integer, _
                                                      ByVal CodCelF As Integer, _
                                                      ByVal QdeDiaInt As Integer, _
                                                      ByVal IdtFlgTod As Integer, _
                                                      ByVal vTipIdtEmp As Integer) As DatasetRelatorioContasAReceber
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelatorioContasAReceber

            ds = AcordoComercialBP.ObterRelatorioContasAReceber_02ZG(CodCelI, CodCelF, QdeDiaInt, IdtFlgTod, vTipIdtEmp)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Conta A Receber - Bonificacoes e Desconto em Duplicata a Emitir. Dataset com a Tabela tbContasAReceber_02ZR preenchida.")> _
    Public Function ObterRelatorioContasAReceber_02ZR(ByVal CodDivCmp As Integer, _
                                                      ByVal CodFrn As Integer, _
                                                      ByVal NumCslCttFrn As Integer, _
                                                      ByVal ChmAcoNot As String) As DatasetRelatorioContasAReceber
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelatorioContasAReceber

            ds = AcordoComercialBP.ObterRelatorioContasAReceber_02ZR(CodDivCmp, CodFrn, NumCslCttFrn, ChmAcoNot)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Manutenção Acordo - Registro de acordo.
    ''' cby002ka.rpt 
    ''' </summary>
    ''' <param name="CodEmp"></param>
    ''' <param name="CodFilEmp"></param>
    ''' <param name="CodPms"></param>
    ''' <param name="DatNgcPms"></param>
    ''' <returns>Dataset com a Tabela TbAcordoAcoesComerciais_232 preenchida</returns>
    ''' <remarks>
    ''' Procedure legado SQL-SERVER: spCBU232 
    ''' Procedure Migrada Oracle...: 
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	10/17/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="-Manutenção Acordo  - Registro de acordo. Dataset com a Tabela TbAcordoAcoesComerciais_232 preenchida.")> _
    Public Function ObterRelatorioAcordoAcoesComerciais_232(ByVal CodEmp As Integer, _
                                                            ByVal CodFilEmp As Integer, _
                                                            ByVal CodPms As Integer, _
                                                            ByVal DatNgcPms As Date) As DatasetRelatorioAcordoAcoesComerciais
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelatorioAcordoAcoesComerciais

            ds = AcordoComercialBP.ObterRelatorioAcordoAcoesComerciais_232(CodEmp, CodFilEmp, CodPms, DatNgcPms)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Cancelar Vlrs.Fornec - Cancelar Valores para Fornecedores em Processo de Desativação. Dataset com a Tabela TbAcordoAcoesComerciais_194 preenchida.
    ''' CBY002AE.rpt 
    ''' </summary>
    ''' <param name="CodEmp"></param>
    ''' <param name="CodFilEmp"></param>
    ''' <param name="CodPms"></param>
    ''' <param name="DatNgcPms"></param>
    ''' <returns>Dataset com a Tabela TbAcordoAcoesComerciais_194 preenchida</returns>
    ''' <remarks>
    ''' Procedure legado SQL-SERVER: spCBU194
    ''' Procedure Migrada Oracle...: 
    ''' </remarks>
    ''' <history>
    ''' 	[Joelma Oliveira]	10/17/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="-Cancelar Vlrs.Fornec - Cancelar Valores para Fornecedores em Processo de Desativação. Dataset com a Tabela TbAcordoAcoesComerciais_194 preenchida.")> _
    Public Function ObterRelatorioAcordoAcoesComerciais_194(ByVal TipOpe As Integer, _
                                                            ByVal CodFrn As Integer, _
                                                            ByVal FlgCon As Integer) As DatasetRelatorioAcordoAcoesComerciais
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelatorioAcordoAcoesComerciais

            ds = AcordoComercialBP.ObterRelatorioAcordoAcoesComerciais_194(TipOpe, CodFrn, FlgCon)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Contrato - Consulta acordos de fornecedores.
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
    ''' 	[Joelma Oliveira]	10/18/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="-Contrato - Consulta acordos de fornecedores. Dataset com a Tabela TbAnaliticoAcoesComerciais preenchida.")> _
    Public Function ObterRelatorioAnaliticoAcoesComerciais(ByVal TipOpe As Integer, _
                                                           ByVal CodFrn As Integer, _
                                                           ByVal NumCttFrn As Integer, _
                                                           ByVal FlgTipOpe As Integer, _
                                                           ByVal Codigo As Integer, _
                                                           ByVal Tipo As String) As DataSetRelatorioAnaliticoAcoesComerciais
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DataSetRelatorioAnaliticoAcoesComerciais

            ds = AcordoComercialBP.ObterRelatorioAnaliticoAcoesComerciais(TipOpe, CodFrn, NumCttFrn, FlgTipOpe, Codigo, Tipo)
            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Extrato- Extrato de Fornecedor.
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
    ''' 	[Joelma Oliveira]	10/18/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="-Extrato- Extrato de Fornecedor.Dataset com a Tabela TbExtratoContaCorrrente_012 preenchida.")> _
     Public Function ObterRelatorioExtratoContaCorrrente_012(ByVal Ano As Integer, _
                                                               ByVal Mes As Integer, _
                                                               ByVal CodFrn As Integer, _
                                                               ByVal TipDsnDscBnf As Integer, _
                                                               ByVal FlgDsp As String, _
                                                               ByVal TipPmt As Integer) As DataSetRelatorioExtratoContaCorrrente
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DataSetRelatorioExtratoContaCorrrente

            ds = AcordoComercialBP.ObterRelatorioExtratoContaCorrrente_012(Ano, Mes, CodFrn, TipDsnDscBnf, FlgDsp, TipPmt)
            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Extrato- Extrato de Fornecedor(disponível).
    ''' CCX001ia.rpt
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
    ''' 	[Joelma Oliveira]	10/18/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="-Extrato- Extrato de Fornecedor.Dataset com a Tabela TbExtratoContaCorrrente_048 preenchida.")> _
    Public Function ObterRelatorioExtratoContaCorrrente_048(ByVal DataInicial As Date, _
                                                            ByVal DataFinal As Date, _
                                                            ByVal CodFrn As Integer, _
                                                            ByVal TipDsnDscBnf As Integer, _
                                                            ByVal FlgDsp As String, _
                                                            ByVal TipPmt As Integer, _
                                                            ByVal lst_TipDsnDscBnf As String) As DataSetRelatorioExtratoContaCorrrente
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DataSetRelatorioExtratoContaCorrrente

            ds = AcordoComercialBP.ObterRelatorioExtratoContaCorrrente_048(DataInicial, DataFinal, CodFrn, TipDsnDscBnf, FlgDsp, TipPmt, lst_TipDsnDscBnf)
            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="-Recebimento.Dataset com a Tabela TbRecebo preenchida.")> _
       Public Function ObterRelatorioRecibo(ByVal CodFrn As Integer) As DataSetRelatorioRecibo

        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DataSetRelatorioRecibo

            ds = AcordoComercialBP.ObterRelatorioRecibo(CodFrn)
            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    ''' 	[Joelma Oliveira]	11/2/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="-Relação de Perdas Emitidas.Dataset com a Tabela TbRelacaoPerdasEmitidas_163 preenchida.")> _
       Public Function ObterRelacaoPerdasEmitidas_163(ByVal CodDivCmp As Integer, _
                                                      ByVal CodFrn As Integer) As DatasetRelacaoPerdasEmitidas

        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelacaoPerdasEmitidas

            ds = AcordoComercialBP.ObterRelacaoPerdasEmitidas_163(CodDivCmp, CodFrn)
            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="-Relação de Perdas Emitidas.Dataset com a Tabela TbRelacaoPerdasEmitidas_164 preenchida.")> _
      Public Function ObterRelacaoPerdasEmitidas_164(ByVal CodFrn As Integer, _
                                                     ByVal DatIni As Date, _
                                                     ByVal DatFim As Date) As DatasetRelacaoPerdasEmitidas

        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelacaoPerdasEmitidas

            ds = AcordoComercialBP.ObterRelacaoPerdasEmitidas_164(CodFrn, DatIni, DatFim)
            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="-RelatorioSaldoDisponivelFornecedorCelula.")> _
    Public Function ObterRelatorioSaldoDisponivelFornecedorCelula(ByVal pvCodDivCmp As Decimal, _
                                                                  ByVal pvCodCpr As Decimal, _
                                                                  ByVal pvTipDsnDscBnf As Decimal, _
                                                                  ByVal pvAnoMesRef As Decimal, _
                                                                  ByVal pvTipo As Integer) As DataSetRelatorioSaldoDisponivelFornecedorCelula
        Try
            Dim ContaCorrenteFornecedor As New ContaCorrenteFornecedorBP
            Dim ds As DataSetRelatorioSaldoDisponivelFornecedorCelula

            ds = ContaCorrenteFornecedor.ObterRelatorioSaldoDisponivelFornecedorCelula(pvCodDivCmp, _
                                                                                       pvCodCpr, _
                                                                                       pvTipDsnDscBnf, _
                                                                                       pvAnoMesRef, _
                                                                                       pvTipo)
            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Relatorio Baixa Acordo. Dataset com a Tabela tbBaixa Acordo preenchida
    ''' </summary>
    ''' <param name="CodPms"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Danilo Rafael]	27/5/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Relatorio Baixa Acordo. Dataset com a Tabela tbBaixa Acordo preenchida")> _
   Public Function ObterRelatorioBaixaAcordo(ByVal CODPMS As Decimal) As DatasetRelatorioBaixaAcordo
        Try
            Dim AcordoComercialBP As New AcordoComercialBP
            Dim ds As DatasetRelatorioBaixaAcordo

            ds = AcordoComercialBP.ObterRelatorioBaixaAcordo(CODPMS)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function
#End Region

#End Region

#Region "Serviços Classe Filial"

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0112963")> _
    Public Function ObterFiliaisExpedicao(ByVal CODEMP As Integer) As dataSetFilial
        Try
            Dim FilialBP As FilialBP
            Dim DatasetFilial As DatasetFilial

            FilialBP = New FilialBP
            DatasetFilial = FilialBP.ObterFiliaisExpedicao(CODEMP)

            Return DatasetFilial
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0112963")> _
    Public Function ObterFiliais(ByVal indicadorRestricaoFilial As Int16) As dataSetFilial
        Try
            Dim FilialBP As FilialBP
            Dim DatasetFilial As DatasetFilial

            FilialBP = New FilialBP
            DatasetFilial = FilialBP.ObterFiliais(indicadorRestricaoFilial)

            Return DatasetFilial
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function
#End Region

#Region "Serviços PedidoCompra"

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0104499")> _
    Public Function ObterTipoPedidoCompra(ByVal TIPPEDCMP As Decimal) As DatasetTipoPedidoCompra
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetTipoPedidoCompra As DatasetTipoPedidoCompra

            AcordoComercialBP = New AcordoComercialBP
            DatasetTipoPedidoCompra = AcordoComercialBP.ObterTipoPedidoCompra(TIPPEDCMP)

            Return DatasetTipoPedidoCompra
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0104499")> _
    Public Function ObterTiposPedidoCompra(ByVal DESTIPPEDCMP As String) As DatasetTipoPedidoCompra
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetTipoPedidoCompra As DatasetTipoPedidoCompra

            AcordoComercialBP = New AcordoComercialBP
            DatasetTipoPedidoCompra = AcordoComercialBP.ObterTiposPedidoCompra(DESTIPPEDCMP)

            Return DatasetTipoPedidoCompra
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0104499")> _
    Public Function AtualizarTipoPedidoCompra(ByVal DatasetTipoPedidoCompra As DatasetTipoPedidoCompra) As Boolean
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            AcordoComercialBP = New AcordoComercialBP
            AcordoComercialBP.AtualizarTipoPedidoCompra(DatasetTipoPedidoCompra)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0114095")> _
    Public Function ObterParametro(ByVal NUMPMTSIS As Integer) As dataSetParametro
        Try
            Dim PedidoCompraBP As PedidoCompraBP
            Dim DatasetParametro As DatasetParametro

            PedidoCompraBP = New PedidoCompraBP
            DatasetParametro = PedidoCompraBP.ObterParametroNegociacaoFornecedor(NUMPMTSIS)

            Return DatasetParametro
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0105592")> _
    Public Function ObterCapaPedidoCompra(ByVal CODEMP As Decimal, _
                                          ByVal CODFILEMP As Decimal, _
                                          ByVal NUMPEDCMP As Decimal) As DatasetCapaPedidoCompra
        Try
            Dim PedidoCompraBP As PedidoCompraBP
            Dim DatasetCapaPedidoCompra As DatasetCapaPedidoCompra

            PedidoCompraBP = New PedidoCompraBP
            DatasetCapaPedidoCompra = PedidoCompraBP.ObterCapaPedidoCompra(CODEMP, CODFILEMP, NUMPEDCMP)

            Return DatasetCapaPedidoCompra
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0105592")> _
    Public Function ObterCapaPedidosCompra(ByVal CODBCOTITPGT As Decimal, _
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
                                           ByVal NUMPNDRLCPEDCMP As Decimal) As DatasetCapaPedidoCompra
        Try
            Dim PedidoCompraBP As PedidoCompraBP
            Dim DatasetCapaPedidoCompra As DatasetCapaPedidoCompra

            PedidoCompraBP = New PedidoCompraBP
            DatasetCapaPedidoCompra = PedidoCompraBP.ObterCapaPedidosCompra(CODBCOTITPGT, CODCIDENTCIF, CODCNLDTB, CODCPR, CODEMP, CODFILEMP, CODFILEMPENT, CODFILEMPTRN, CODFRN, DATBXAPEDCMP, DATCNCPEDCMP, DATPEDCMP, NOMCIDRCBMER, NUMACOMCD, NUMIDTTIPPEDCMP, NUMPEDBNF, NUMPEDCMP, NUMPEDNOR, NUMPNDRLCPEDCMP)

            Return DatasetCapaPedidoCompra
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0114508")> _
    Public Function ObterCadastroTributosFilial(ByVal CODFILEMP As Decimal, _
                                                ByVal NUMPMTSIS As Decimal) As DatasetCadastroTributosFilial
        Try
            Dim PedidoCompraBP As PedidoCompraBP
            Dim DatasetCadastroTributosFilial As DatasetCadastroTributosFilial

            PedidoCompraBP = New PedidoCompraBP
            DatasetCadastroTributosFilial = PedidoCompraBP.ObterCadastroTributosFilial(CODFILEMP, NUMPMTSIS)

            Return DatasetCadastroTributosFilial
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0114508")> _
    Public Function ObterCadastrosTributosFilial(ByVal CODFILEMP As Decimal, _
                                                 ByVal NUMPMTSIS As Decimal) As DatasetCadastroTributosFilial
        Try
            Dim PedidoCompraBP As PedidoCompraBP
            Dim DatasetCadastroTributosFilial As DatasetCadastroTributosFilial

            PedidoCompraBP = New PedidoCompraBP
            DatasetCadastroTributosFilial = PedidoCompraBP.ObterCadastrosTributosFilial(CODFILEMP, NUMPMTSIS)

            Return DatasetCadastroTributosFilial
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna Parâmetro Negociação Fornecedor. Entidade principal:T0114508")> _
    Public Function ObterParametroNegociacaoFornecedor(ByVal numeroParametro As Integer) As dataSetParametro
        Try
            Dim PedidoCompraBP As New PedidoCompraBP
            Dim ds As dataSetParametro
            PedidoCompraBP.ObterParametroNegociacaoFornecedor(numeroParametro)
            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualiza os dados de Parâmetro Negociação Fornecedor em banco de dados. Entidade principal:T0114508")> _
    Public Sub AtualizarParametroNegociacaoFornecedor(ByRef ds As dataSetParametro)
        Try
            Dim PedidoCompraBP As New PedidoCompraBP
            PedidoCompraBP.AtualizarParametroNegociacaoFornecedor(ds)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Sub

#End Region

#Region "Serviços Estrutura Compra"

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0113625")> _
    Public Function ObterComprador(ByVal CODCPR As Integer) As dataSetEstruturaCompra
        Try
            Dim EstruturaCompraBP As EstruturaCompraBP
            Dim dataSetEstruturaCompra As dataSetEstruturaCompra

            EstruturaCompraBP = New EstruturaCompraBP
            dataSetEstruturaCompra = EstruturaCompraBP.ObterComprador(CODCPR)

            Return dataSetEstruturaCompra
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
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
    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0113625")> _
    Public Function ObterCompradores(ByVal CODGERPRD As Decimal, _
                                     ByVal DATDSTCPR As Date, _
                                     ByVal DATDSTCPRInicial As Date, _
                                     ByVal DATDSTCPRFinal As Date, _
                                     ByVal IncluirDATDSTCPRNulo As Int16, _
                                     ByVal DESSGLGERPRD As String, _
                                     ByVal NOMCPR As String) As dataSetEstruturaCompra
        Try
            Dim EstruturaCompraBP As EstruturaCompraBP
            Dim dataSetEstruturaCompra As dataSetEstruturaCompra

            EstruturaCompraBP = New EstruturaCompraBP
            dataSetEstruturaCompra = EstruturaCompraBP.ObterCompradores(CODGERPRD , _
                                                                        DATDSTCPR , _
                                                                        DATDSTCPRInicial , _
                                                                        DATDSTCPRFinal , _
                                                                        IncluirDATDSTCPRNulo , _
                                                                        DESSGLGERPRD , _
                                                                        NOMCPR )

            Return dataSetEstruturaCompra
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0118570")> _
    Public Function ObterCelula(ByVal CODDIVCMP As Decimal) As DatasetCelula
        Try
            Dim EstruturaCompraBP As EstruturaCompraBP
            Dim DatasetCelula As DatasetCelula

            EstruturaCompraBP = New EstruturaCompraBP
            DatasetCelula = EstruturaCompraBP.ObterCelula(CODDIVCMP)

            Return DatasetCelula
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0118570")> _
    Public Function ObterCelulas(ByVal CODDRTCMP As Decimal, _
                                        ByVal CODGERPRD As Decimal, _
                                        ByVal CODGRPMERFRC As Decimal, _
                                        ByVal DESDIVCMP As String) As DatasetCelula
        Try
            Dim EstruturaCompraBP As EstruturaCompraBP
            Dim DatasetCelula As DatasetCelula

            EstruturaCompraBP = New EstruturaCompraBP
            DatasetCelula = EstruturaCompraBP.ObterCelulas(CODDRTCMP, CODGERPRD, CODGRPMERFRC, DESDIVCMP)

            Return DatasetCelula
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0131275")> _
    Public Function ObterDiretoriaCompra(ByVal CODUNDESRNGC As Decimal) As DatasetDiretoriaCompra
        Try
            Dim EstruturaCompraBP As EstruturaCompraBP
            Dim DatasetDiretoriaCompra As DatasetDiretoriaCompra

            EstruturaCompraBP = New EstruturaCompraBP
            DatasetDiretoriaCompra = EstruturaCompraBP.ObterDiretoriaCompra(CODUNDESRNGC)

            Return DatasetDiretoriaCompra
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0131275")> _
    Public Function ObterDiretoriasCompra(ByVal CODFNC As Decimal, _
                                          ByVal DESABVUNDESRNGC As String, _
                                          ByVal DESUNDESRNGC As String) As DatasetDiretoriaCompra
        Try
            Dim EstruturaCompraBP As EstruturaCompraBP
            Dim DatasetDiretoriaCompra As DatasetDiretoriaCompra

            EstruturaCompraBP = New EstruturaCompraBP
            DatasetDiretoriaCompra = EstruturaCompraBP.ObterDiretoriasCompra(CODFNC, DESABVUNDESRNGC, DESUNDESRNGC)

            Return DatasetDiretoriaCompra
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

#End Region

#Region "Serviços Divisão Fornecedor"

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0100426")> _
    Public Function ObterDivisaoFornecedor(ByVal codigoEmpresa As Integer, _
                                           ByVal codigoDivisaoFornecedor As Long) As dataSetDivisaoFornecedor
        Try
            Dim DivisaoFornecedorBP As DivisaoFornecedorBP
            Dim dataSetDivisaoFornecedor As dataSetDivisaoFornecedor

            DivisaoFornecedorBP = New DivisaoFornecedorBP
            dataSetDivisaoFornecedor = DivisaoFornecedorBP.ObterDivisaoFornecedor(codigoEmpresa, _
                                                                       codigoDivisaoFornecedor)

            Return dataSetDivisaoFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registros com base no nome do fornecedor. Entidade principal:T0100426")> _
        Public Function ObterDivisoesFornecedor(ByVal CODEMP As Decimal, _
                                                ByVal NOMFRN As String) As dataSetDivisaoFornecedor
        Try
            Dim DivisaoFornecedorBP As DivisaoFornecedorBP
            Dim dataSetDivisaoFornecedor As dataSetDivisaoFornecedor

            DivisaoFornecedorBP = New DivisaoFornecedorBP
            dataSetDivisaoFornecedor = DivisaoFornecedorBP.ObterDivisaoFornecedor(CODEMP, NOMFRN)

            Return dataSetDivisaoFornecedor
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

#End Region

#Region "Serviços Usuário Compra"

    <WebMethod(Description:="Atualização dos dados. Entidade principal T0113471")> _
    Public Function ObterUsuariosNegociacaoCompra(ByVal codigoComprador As Integer, _
                                                  ByVal codigoFuncionario As Integer, _
                                                  ByVal tipoUsuarioSistema As String) As dataSetUsuarioCompra
        Try
            Dim UsuarioCompraBP As UsuarioCompraBP
            UsuarioCompraBP = New UsuarioCompraBP
            Dim ds As New dataSetUsuarioCompra
            ds = UsuarioCompraBP.ObterUsuariosNegociacaoCompra(codigoComprador, codigoFuncionario, tipoUsuarioSistema)
            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

#End Region

#Region "Componente - Martins.Compras.AcoesComerciais.AcoesMercadologicas"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta Valor unitario da meradoria
    ''' </summary>
    ''' <param name="codigoMercadoria"></param>
    ''' <param name="codigoFilial"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Lesley]	08/14/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Consulta Valor unitario da meradoria")> _
       Public Function ObterValorUnitarioMercadoria(ByVal codigoMercadoria As Decimal, ByVal codigoFilial As Decimal) As DatasetItemAcao
        Try
            Dim valorMercadoriaBP As ItemAcaoBP
            Dim DatasetValorMercadoria As DatasetItemAcao

            valorMercadoriaBP = New ItemAcaoBP
            DatasetValorMercadoria = valorMercadoriaBP.GetValorUnitarioMercadoria(codigoMercadoria, codigoFilial)

            Return DatasetValorMercadoria
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta mercadorias similares e seus respectivos preços unitários
    ''' </summary>
    ''' <param name="codigoIncentivo"></param>
    ''' <param name="numeroCriterio"></param>
    ''' <param name="codigoTipoPublicoAlvo"></param>
    ''' <param name="codigoAbrangencia"></param>
    ''' <param name="numeroPeriodo"></param>
    ''' <param name="codigoEntidade"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Lesley]	08/25/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Consulta mercadorias similares e seus respectivos preços unitários")> _
    Public Function obterMercadoriaSimilar(ByVal codigoIncentivo As Decimal, ByVal numeroCriterio As Decimal, _
      ByVal codigoTipoPublicoAlvo As Decimal, ByVal codigoAbrangencia As Decimal, ByVal numeroPeriodo As Decimal, _
      ByVal codigoEntidade As Decimal, ByVal codigoPremioIncentivo As Decimal) As DatasetItemAcao

        Dim valorMercadoriaBP As ItemAcaoBP
        Dim DatasetValorMercadoria As DatasetItemAcao

        Try

            valorMercadoriaBP = New ItemAcaoBP
            '            DatasetValorMercadoria = valorMercadoriaBP.obterMercadoriaSimilar(codigoIncentivo, numeroCriterio, _
            'codigoTipoPublicoAlvo, codigoAbrangencia, numeroPeriodo, codigoEntidade, codigoPremioIncentivo)

            Return DatasetValorMercadoria
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        Finally
            valorMercadoriaBP = Nothing
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta mercadorias e seus preços unitários
    ''' </summary>
    ''' <param name="codigoFilial"></param>
    ''' <param name="codigoMercadoria"></param>
    ''' <param name="descricaoMercadoria"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Lesley]	08/25/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Consulta mercadorias e seus preços unitários")> _
    Public Function obterMercadoriaPreco(ByVal codigoFilial As Decimal, _
      ByVal codigoMercadoria As Decimal, ByVal descricaoMercadoria As String) As DatasetItemAcao

        Try
            Dim MercadoriaPrecoBP As ItemAcaoBP
            Dim Dataset As DatasetItemAcao

            MercadoriaPrecoBP = New ItemAcaoBP
            Dataset = MercadoriaPrecoBP.obterMercadoriaPreco(codigoFilial, codigoMercadoria, descricaoMercadoria)

            Return Dataset
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0138776
    ''' </summary>
    ''' <param name="codigoIncentivo"></param>
    ''' <param name="numeroCriterio"></param>
    ''' <param name="numeroAbrangencia"></param>
    ''' <param name="numeroPeriodo"></param>
    ''' <param name="codigoPremio"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Lesley]	07/27/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0138776")> _
     Public Function ObterSomaSaldo(ByVal codigoIncentivo As Integer, _
     ByVal numeroCriterio As Integer, _
     ByVal numeroAbrangencia As Integer, _
     ByVal numeroPeriodo As Integer, _
     ByVal codigoPremio As Integer) As DatasetItemAcao

        Try
            Dim BP As ItemAcaoBP
            Dim DatasetSaldo As DatasetItemAcao

            BP = New ItemAcaoBP
            DatasetSaldo = BP.ObterSomaSaldo(codigoIncentivo, numeroCriterio, numeroAbrangencia, numeroPeriodo, codigoPremio)

            Return DatasetSaldo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcoesMercadologicas.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

#End Region

#Region "Serviços - Tipo Grupo de Marketing"

    <WebMethod(Description:="Retorna registro(s) com base na chave. Entidade principal:CADTIPGRPMKTFRN")> _
    Public Function ObterTipoGrupoMarketingPorChave(ByVal TIPGRPMKTFRN As Decimal) As DatasetTipoGrupoMarketing
        Try
            Dim TipoGrupoMarketingBP As TipoGrupoMarketingBP
            Dim DatasetTipoGrupoMarketing As DatasetTipoGrupoMarketing

            TipoGrupoMarketingBP = New TipoGrupoMarketingBP
            DatasetTipoGrupoMarketing = TipoGrupoMarketingBP.ObterTipoGrupoMarketingPorChave(TIPGRPMKTFRN)

            Return DatasetTipoGrupoMarketing
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base na chave. Entidade principal:CADTIPGRPMKTFRN")> _
   Public Function ObterTipoGrupoMarketingPorChavePesquisa(ByVal TIPGRPMKTFRN As Decimal) As DatasetTipoGrupoMarketing
        Try
            Dim TipoGrupoMarketingBP As TipoGrupoMarketingBP
            Dim DatasetTipoGrupoMarketing As DatasetTipoGrupoMarketing

            TipoGrupoMarketingBP = New TipoGrupoMarketingBP
            DatasetTipoGrupoMarketing = TipoGrupoMarketingBP.ObterTipoGrupoMarketingPorChavePesquisa(TIPGRPMKTFRN)

            Return DatasetTipoGrupoMarketing
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base nos atributos. Entidade principal:CADTIPGRPMKTFRN")> _
   Public Function ObterTipoGrupoMarketingPorAtributo(ByVal TIPGRPMKTFRN As Decimal, ByVal DESGRPMKTFRN As String) As DatasetTipoGrupoMarketing
        Try
            Dim TipoGrupoMarketingBP As TipoGrupoMarketingBP
            Dim DatasetTipoGrupoMarketing As DatasetTipoGrupoMarketing

            TipoGrupoMarketingBP = New TipoGrupoMarketingBP
            DatasetTipoGrupoMarketing = TipoGrupoMarketingBP.ObterTipoGrupoMarketingPorAtributo(TIPGRPMKTFRN, DESGRPMKTFRN)

            Return DatasetTipoGrupoMarketing
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function


    <WebMethod(Description:="Atualização dos dados. Entidade principal CADTIPGRPMKTFRN")> _
    Public Function AtualizarTipoGrupoMarketing(ByVal DatasetTipoGrupoMarketing As DatasetTipoGrupoMarketing) As Boolean
        Try
            Dim TipoGrupoMarketing As TipoGrupoMarketingBP
            TipoGrupoMarketing = New TipoGrupoMarketingBP
            TipoGrupoMarketing.AtualizarTipoGrupoMarketing(DatasetTipoGrupoMarketing)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Obtem a proxima chave. Entidade principal CADTIPGRPMKTFRN")> _
  Public Function ObterNovaChaveTipoGrupoMarketing() As Decimal
        Try
            Dim TipoGrupoMarketing As TipoGrupoMarketingBP
            TipoGrupoMarketing = New TipoGrupoMarketingBP
            Return TipoGrupoMarketing.ObterNovaChaveTipoGrupoMarketing()
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base na chave. Entidade principal:T0107579")> _
    Public Function ObterGrupoEconomicoPorChave(ByVal CODEMP As Decimal, ByVal CODFILEMP As Decimal, ByVal CODGRPFRN As Decimal) As DatasetTipoGrupoMarketing
        Try
            Dim TipoGrupoMarketingBP As TipoGrupoMarketingBP
            Dim DatasetTipoGrupoMarketing As DatasetTipoGrupoMarketing

            TipoGrupoMarketingBP = New TipoGrupoMarketingBP
            DatasetTipoGrupoMarketing = TipoGrupoMarketingBP.ObterGrupoEconomicoPorChave(CODEMP, CODFILEMP, CODGRPFRN)

            Return DatasetTipoGrupoMarketing
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base nos atributos. Entidade principal:T0107579")> _
    Public Function ObterGrupoEconomicoPorAtributo(ByVal CODEMP As Decimal, _
                                                       ByVal CODFILEMP As Decimal, _
                                                       ByVal CODGRPFRN As Decimal, _
                                                       ByVal NOMGRPFRN As String, _
                                                       ByVal TIPFRN As String, _
                                                       ByVal DATCADGRPFRN As Date, _
                                                       ByVal DATDSTGRPFRN As Date, _
                                                       ByVal CODCGMECOFRN As Decimal, _
                                                       ByVal TIPCLFFRN As Decimal) As DatasetTipoGrupoMarketing
        Try
            Dim TipoGrupoMarketingBP As TipoGrupoMarketingBP
            Dim DatasetTipoGrupoMarketing As DatasetTipoGrupoMarketing

            TipoGrupoMarketingBP = New TipoGrupoMarketingBP
            DatasetTipoGrupoMarketing = TipoGrupoMarketingBP.ObterGrupoEconomicoPorAtributo(CODEMP, CODFILEMP, CODGRPFRN, NOMGRPFRN, TIPFRN, DATCADGRPFRN, DATDSTGRPFRN, CODCGMECOFRN, TIPCLFFRN)

            Return DatasetTipoGrupoMarketing
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function


    <WebMethod(Description:="Retorna registro(s) para a pesquisa de relaçao Grupo Econômico Fornecedor  x Grupo Marketing Fornecedor")> _
   Public Function ObterRelacaoGrupoMarketingPesquisa(ByVal TIPGRPMKTFRN As Decimal, _
                                                           ByVal CODGRPFRN As Decimal, _
                                                           ByVal PERGRPMKTFRN As Decimal) As DatasetTipoGrupoMarketing
        Try
            Dim TipoGrupoMarketingBP As TipoGrupoMarketingBP
            Dim DatasetTipoGrupoMarketing As DatasetTipoGrupoMarketing

            TipoGrupoMarketingBP = New TipoGrupoMarketingBP
            DatasetTipoGrupoMarketing = TipoGrupoMarketingBP.ObterRelacaoGrupoMarketingPesquisa(TIPGRPMKTFRN, CODGRPFRN, PERGRPMKTFRN)

            Return DatasetTipoGrupoMarketing
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principal CADTIPGRPMKTFRN")> _
   Public Function AtualizarRelacaoGrupoMarketing(ByVal DatasetTipoGrupoMarketing As DatasetTipoGrupoMarketing) As Boolean
        Try
            Dim TipoGrupoMarketing As TipoGrupoMarketingBP
            TipoGrupoMarketing = New TipoGrupoMarketingBP
            TipoGrupoMarketing.AtualizarRelacaoGrupoMarketing(DatasetTipoGrupoMarketing)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function


    <WebMethod(Description:="Retorna registro(s) para a pesquisa de relaçao Grupo Econômico Fornecedor  x Grupo Marketing Fornecedor")> _
  Public Function ObterRelacaoGrupoMarketingPorChave(ByVal CODGRPFRN As Decimal, ByVal TIPGRPMKTFRN As Decimal) As DatasetTipoGrupoMarketing
        Try
            Dim TipoGrupoMarketingBP As TipoGrupoMarketingBP
            Dim DatasetTipoGrupoMarketing As DatasetTipoGrupoMarketing

            TipoGrupoMarketingBP = New TipoGrupoMarketingBP
            DatasetTipoGrupoMarketing = TipoGrupoMarketingBP.ObterRelacaoGrupoMarketingPorChave(CODGRPFRN, TIPGRPMKTFRN)

            Return DatasetTipoGrupoMarketing
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function


    <WebMethod(Description:="Retorna registro(s) para a pesquisa de relaçao Grupo Econômico Fornecedor  x Grupo Marketing Fornecedor")> _
  Public Function ObterRelacaoGrupoMarketingPorAtributo(ByVal TIPGRPMKTFRN As Decimal, _
                                                              ByVal CODGRPFRN As Decimal) As DatasetTipoGrupoMarketing
        Try
            Dim TipoGrupoMarketingBP As TipoGrupoMarketingBP
            Dim DatasetTipoGrupoMarketing As DatasetTipoGrupoMarketing

            TipoGrupoMarketingBP = New TipoGrupoMarketingBP
            DatasetTipoGrupoMarketing = TipoGrupoMarketingBP.ObterRelacaoGrupoMarketingPorAtributo(TIPGRPMKTFRN, CODGRPFRN)

            Return DatasetTipoGrupoMarketing
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function


    <WebMethod(Description:="Retorna registro(s) para montar o grid da relacao Grupo Econômico Fornecedor  x Grupo Marketing Fornecedor")> _
    Public Function ObterRelacaoGrupoMarketingPesquisaFilho(ByVal IN_CODGRPFRN As String) As DatasetTipoGrupoMarketing
        Try
            Dim TipoGrupoMarketingBP As TipoGrupoMarketingBP
            Dim DatasetTipoGrupoMarketing As DatasetTipoGrupoMarketing

            TipoGrupoMarketingBP = New TipoGrupoMarketingBP
            DatasetTipoGrupoMarketing = TipoGrupoMarketingBP.ObterRelacaoGrupoMarketingPesquisaFilho(IN_CODGRPFRN)

            Return DatasetTipoGrupoMarketing
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) para montar o grid para o usuario. Entidade principal:RLCFRNPERMKTEXAARD")> _
       Public Function ObterMarketingExtraAcordoPesquisa(ByVal CODFRN As Decimal, ByVal NOMFRN As String, ByVal DATDSTMKTEXAARD As Decimal) As DatasetMarketinExtraAcordo
        Try
            Dim TipoGrupoMarketingBP As TipoGrupoMarketingBP
            Dim DatasetMarketinExtraAcordo As DatasetMarketinExtraAcordo

            TipoGrupoMarketingBP = New TipoGrupoMarketingBP
            DatasetMarketinExtraAcordo = TipoGrupoMarketingBP.ObterMarketingExtraAcordoPesquisa(CODFRN, NOMFRN, DATDSTMKTEXAARD)

            Return DatasetMarketinExtraAcordo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function


    <WebMethod(Description:="Atualização dos dados. Entidade principal RLCFRNPERMKTEXAARD")> _
   Public Function AtualizarMarketingExtraAcordo(ByVal DatasetMarketinExtraAcordo As DatasetMarketinExtraAcordo) As Boolean
        Try
            Dim TipoGrupoMarketing As TipoGrupoMarketingBP
            TipoGrupoMarketing = New TipoGrupoMarketingBP
            TipoGrupoMarketing.AtualizarMarketingExtraAcordo(DatasetMarketinExtraAcordo)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) para montar o grid para o usuario. Entidade principal:RLCFRNPERMKTEXAARD")> _
       Public Function ObterFormaPagamentoMktExtraAcordo() As DatasetMarketinExtraAcordo
        Try
            Dim TipoGrupoMarketingBP As TipoGrupoMarketingBP
            Dim DatasetMarketinExtraAcordo As DatasetMarketinExtraAcordo

            TipoGrupoMarketingBP = New TipoGrupoMarketingBP
            DatasetMarketinExtraAcordo = TipoGrupoMarketingBP.ObterFormaPagamentoMktExtraAcordo()

            Return DatasetMarketinExtraAcordo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function



    <WebMethod(Description:="Retorna registro(s) para montar o grid para o usuario. Entidade principal:RLCFRNPERMKTEXAARD")> _
       Public Function ObterMarketingExtraAcordoPorChave(ByVal CODFRN As Decimal, ByVal DATCADMKTEXAARD As Date) As DatasetMarketinExtraAcordo
        Try
            Dim TipoGrupoMarketingBP As TipoGrupoMarketingBP
            Dim DatasetMarketinExtraAcordo As DatasetMarketinExtraAcordo

            TipoGrupoMarketingBP = New TipoGrupoMarketingBP
            DatasetMarketinExtraAcordo = TipoGrupoMarketingBP.ObterMarketingExtraAcordoPorChave(CODFRN, DATCADMKTEXAARD)

            Return DatasetMarketinExtraAcordo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function
#End Region

#Region "Serviços - Incentivo"

    <WebMethod(Description:="Retorna registro(s) com base na chave. Entidade principal:CADPRGICT")> _
   Public Function ObterIncentivoPorChave(ByVal CODPRGICT As Decimal) As DatasetIncentivo
        Try
            Dim IncentivoBP As IncentivoBP
            Dim DatasetIncentivo As DatasetIncentivo

            IncentivoBP = New IncentivoBP
            DatasetIncentivo = IncentivoBP.ObterIncentivoPorChave(CODPRGICT)

            Return DatasetIncentivo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base nos atributos. Entidade principal:CADPRGICT")> _
   Public Function ObterIncentivoPorAtributo(ByVal CODPRGICT As Decimal, ByVal NOMPRGICT As String) As DatasetIncentivo
        Try
            Dim IncentivoBP As IncentivoBP
            Dim DatasetIncentivo As DatasetIncentivo

            IncentivoBP = New IncentivoBP
            DatasetIncentivo = IncentivoBP.ObterIncentivoPorAtributo(CODPRGICT, NOMPRGICT)

            Return DatasetIncentivo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function


    <WebMethod(Description:="Atualização dos dados. Entidade principal CADPRGICT")> _
    Public Function AtualizarIncentivo(ByVal DatasetIncentivo As DatasetIncentivo) As Boolean
        Try
            Dim Incentivo As IncentivoBP
            Incentivo = New IncentivoBP
            Incentivo.AtualizarIncentivo(DatasetIncentivo)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Obtem a proxima chave. Entidade principal CADPRGICT")> _
  Public Function ObterNovaChaveIncentivo() As Decimal
        Try
            Dim Incentivo As IncentivoBP
            Incentivo = New IncentivoBP
            Return Incentivo.ObterNovaChaveIncentivo()
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base na chave. Entidade principal:T0100426")> _
   Public Function ObterFornecedorPorChave(ByVal CODFRN As Decimal) As DatasetIncentivo
        Try
            Dim IncentivoBP As IncentivoBP
            Dim DatasetIncentivo As DatasetIncentivo

            IncentivoBP = New IncentivoBP
            DatasetIncentivo = IncentivoBP.ObterFornecedorPorChave(CODFRN)

            Return DatasetIncentivo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base nos atributos. Entidade principal:T0100426")> _
   Public Function ObterFornecedorPorAtributo(ByVal CODFRN As Decimal, ByVal NOMFRN As String) As DatasetIncentivo
        Try
            Dim IncentivoBP As IncentivoBP
            Dim DatasetIncentivo As DatasetIncentivo

            IncentivoBP = New IncentivoBP
            DatasetIncentivo = IncentivoBP.ObterFornecedorPorAtributo(CODFRN, NOMFRN)

            Return DatasetIncentivo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function


    <WebMethod(Description:="Retorna registro(s) com base nos atributos. Entidade principal:RLCPRGICTFRN")> _
   Public Function ObterRelacaoIncentivoFornecedorPesquisa(ByVal CODPRGICT As Decimal, ByVal CODFRN As Decimal) As DatasetIncentivo
        Try
            Dim IncentivoBP As IncentivoBP
            Dim DatasetIncentivo As DatasetIncentivo

            IncentivoBP = New IncentivoBP
            DatasetIncentivo = IncentivoBP.ObterRelacaoIncentivoFornecedorPesquisa(CODPRGICT, CODFRN)

            Return DatasetIncentivo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function


    <WebMethod(Description:="Retorna registro(s) com base nos atributos. Entidade principal:RLCPRGICTFRN")> _
 Public Function ObterRelacaoIncentivoFornecedor(ByVal CODPRGICT As Decimal, ByVal CODFRN As Decimal) As DatasetIncentivo
        Try
            Dim IncentivoBP As IncentivoBP
            Dim DatasetIncentivo As DatasetIncentivo

            IncentivoBP = New IncentivoBP
            DatasetIncentivo = IncentivoBP.ObterRelacaoIncentivoFornecedor(CODPRGICT, CODFRN)

            Return DatasetIncentivo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function



    <WebMethod(Description:="Atualização dos dados. Entidade principal CADPRGICT")> _
    Public Function AtualizarRelacaoIncentivoFornecedor(ByVal DatasetIncentivo As DatasetIncentivo) As Boolean
        Try
            Dim Incentivo As IncentivoBP
            Incentivo = New IncentivoBP
            Incentivo.AtualizarRelacaoIncentivoFornecedor(DatasetIncentivo)
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function


#End Region

#Region "VerbaCarimbo"
    <WebMethod(Description:="Retorna Dados da tabela.Entidade principal:CADMCOVBAFRNPesquisa")> _
        Public Function ObterVerbaCarimboPesquisa(ByVal indStaMcoVbaFrn As Decimal, _
                                                  ByVal fornecedor As Decimal, _
                                                  ByVal empenho As Decimal, _
                                                  ByVal acordo As Decimal) As DatasetVerbaCarimbo
        Try
            Dim VerbaCarimboBP As VerbaCarimboBP
            Dim DatasetVerbaCarimbo As DatasetVerbaCarimbo

            VerbaCarimboBP = New VerbaCarimboBP
            DatasetVerbaCarimbo = VerbaCarimboBP.ObterVerbaCarimboPesquisa(indStaMcoVbaFrn, fornecedor, empenho, acordo)

            Return DatasetVerbaCarimbo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0100426")> _
       Public Function ObterComboEmpenho(ByVal tipoChamada As Integer) As DatasetEmpenho

        Try
            Dim VerbaCarimboBP As VerbaCarimboBP
            Dim DatasetEmpenho As DatasetEmpenho

            VerbaCarimboBP = New VerbaCarimboBP
            DatasetEmpenho = VerbaCarimboBP.ObterComboEmpenho(tipoChamada)


            Return DatasetEmpenho
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function
    <WebMethod(Description:="Metodo para Atualizar Verba Carimbo tabela:  MRT.CADMCOVBAFRN.")> _
            Public Function AtualizarCadCarimboVerbaFornec(ByVal dstVerbaCarimbo As DatasetVerbaCarimbo) As Boolean
        Try
            Dim VerbaCarimbo As VerbaCarimboBP
            VerbaCarimbo = New VerbaCarimboBP

            If Not dstVerbaCarimbo Is Nothing Then
                VerbaCarimbo.AtualizarCadCarimboVerbaFornec(dstVerbaCarimbo)
            End If
            Return True
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function

    <WebMethod(Description:="Retorna Dados da tabela.Entidade principal:CADMCOVBAFRNVerificar")> _
        Public Function ObterVerificarCarimbo(ByVal listCarimbo() As Object) As DatasetVerbaCarimbo
        Try
            Dim array As New ArrayList
            For Each item As Object In listCarimbo
                array.Add(item)
            Next
            Dim VerbaCarimboBP As VerbaCarimboBP
            Dim DatasetVerbaCarimbo As DatasetVerbaCarimbo

            VerbaCarimboBP = New VerbaCarimboBP
            DatasetVerbaCarimbo = VerbaCarimboBP.ObterVerificarCarimbo(array)


            Return DatasetVerbaCarimbo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna Dados da tabela.Entidade principal:")> _
       Public Function ObterCadCarimboVerbaFornecByPk(ByVal CODMCOVBAFRN As Decimal) As DatasetVerbaCarimbo
        Try
            Dim VerbaCarimboBP As VerbaCarimboBP
            Dim DatasetVerbaCarimbo As DatasetVerbaCarimbo

            VerbaCarimboBP = New VerbaCarimboBP
            DatasetVerbaCarimbo = VerbaCarimboBP.ObterCadCarimboVerbaFornecByPk(CODMCOVBAFRN)

            Return DatasetVerbaCarimbo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna Dados da fornecedor:")> _
   Public Function ObterDEDAutomatico(ByVal codFrn As String, ByVal nomFrn As String, ByVal codGrpFrn As String, ByVal nomGrpFrn As String, ByVal tpStatus As String) As DatasetFornecedor
        Try
            Dim bp As New AcordoComercialBP
            Dim dst As DatasetFornecedor

            dst = bp.ObterDEDAutomatico(codFrn, nomFrn, codGrpFrn, nomGrpFrn, tpStatus)

            Return dst
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualizar Dados da fornecedor:")> _
   Public Sub AtualizarDEDAutomatico(ByVal dtsFrn As DatasetFornecedor)
        Try
            Dim bp As New AcordoComercialBP
            Dim dst As DatasetFornecedor

            bp.AtualizarDEDAutomatico(dtsFrn)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Sub

#End Region

#Region "CarimboRelatorios"
    <WebMethod(Description:="Retorna dados Para relatorio de carimbo: Diretoria com Filial:")> _
       Public Function ObterRelatorioDiretoria(ByVal Diretoria As Integer, ByVal Filial As Integer, ByVal Empenho As Integer) As DatasetRelatorioCarimbo
        Try
            Dim BP As CarimboRelatorioBP
            Dim ds As DatasetRelatorioCarimbo

            BP = New CarimboRelatorioBP
            ds = BP.ObterRelatorioDiretoria(Diretoria, Filial, Empenho)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function
    <WebMethod(Description:="Retorna dados Para relatorio de carimbo: Diretoria SEM Filial")> _
       Public Function ObterRelatorioFiltroAnalitico(ByVal Empenho As Integer, _
                                                  ByVal Filial As Integer, ByVal Celula As Integer, _
                                                  ByVal Fornecedor As Integer, _
                                                  ByVal Comprador As Integer) As DatasetRelatorioCarimbo
        Try
            Dim BP As CarimboRelatorioBP
            Dim DatasetRelatorioCarimbo As DatasetRelatorioCarimbo

            BP = New CarimboRelatorioBP
            DatasetRelatorioCarimbo = BP.ObterRelatorioFiltroAnalitico(Empenho, Filial, Celula, Fornecedor, Comprador)

            Return DatasetRelatorioCarimbo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function
    <WebMethod(Description:="Retorna dados Para relatorio de carimbo: Filtros COM Filial")> _
   Public Function ObterRelatorioFiltroSintetico(ByVal Empenho As Integer, _
                                                  ByVal Filial As Integer, ByVal Celula As Integer, _
                                                  ByVal Fornecedor As Integer, _
                                                  ByVal Comprador As Integer) As DatasetRelatorioCarimbo
        Try
            Dim BP As CarimboRelatorioBP
            Dim DatasetRelatorioCarimbo As DatasetRelatorioCarimbo

            BP = New CarimboRelatorioBP
            DatasetRelatorioCarimbo = BP.ObterRelatorioFiltroSintetico(Empenho, Filial, Celula, Fornecedor, Comprador)

            Return DatasetRelatorioCarimbo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna dados Para relatorio de carimbo : HISTORICO")> _
       Public Function ObterRelatorioHistorico(ByVal DataInicio As String, ByVal DataFim As String, ByVal Filial As Integer, ByVal Empenho As Integer, ByVal Celula As Integer, _
                                            ByVal Comprador As Integer, ByVal Diretoria As Integer, ByVal Fornecedor As Integer, _
                                        ByVal Mercadoria As Integer, ByVal Tipo As String, ByVal Descricao As String) As DatasetCarimboHistorico
        Try
            Dim BP As CarimboRelatorioBP
            Dim DatasetRelatorioCarimbo As DatasetCarimboHistorico

            BP = New CarimboRelatorioBP
            DatasetRelatorioCarimbo = BP.ObterRelatorioHistorico(DataInicio, DataFim, Filial, Empenho, Celula, Comprador, Diretoria, Fornecedor, Mercadoria, Tipo, Descricao)

            Return DatasetRelatorioCarimbo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function


    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0100086")> _
     Public Function ObterMercadoriaPorChave(ByVal CODEMP As Decimal, _
                                             ByVal CODMER As Decimal) As DatasetMercadoria
        Try
            Dim MercadoriaBP As CarimboRelatorioBP
            Dim DatasetMercadoria As DatasetMercadoria

            MercadoriaBP = New CarimboRelatorioBP
            DatasetMercadoria = MercadoriaBP.ObterMercadoriaPorChave(CODEMP, CODMER)

            Return DatasetMercadoria
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0100086")> _
    Public Function ObterMercadoriaPorAtributos(ByVal CODEMP As Decimal, _
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
                                                ByVal TIPPDCMER As Decimal) As DatasetMercadoria
        Try
            Dim MercadoriaBP As CarimboRelatorioBP
            Dim DatasetMercadoria As DatasetMercadoria

            MercadoriaBP = New CarimboRelatorioBP
            DatasetMercadoria = MercadoriaBP.ObterMercadoriaPorAtributos(CODEMP, CODFMLMER, CODFRNPCPMER, CODGRPMER, CODGRPMERNCM, CODGRPMERNCMCTB, CODMER, CODORIMER, CODSITMER, IncluirDATDSTMERNulo, DESMER, FLGDSTMER, IncluirFLGDSTMERNulo, TIPPDCMER)

            Return DatasetMercadoria
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function


#End Region

#Region "ValoresContabilizadosCarimbos"

    <WebMethod(Description:="Retorna dados Para Combo Tipo Lançamento")> _
       Public Function ObterComboTipoLancamento() As DataSetValoresContabilizadosCarimbosRelatorio

        Try
            Dim BP As ValoresContabilizadosCarimbosBP
            Dim ds As DataSetValoresContabilizadosCarimbosRelatorio

            BP = New ValoresContabilizadosCarimbosBP
            ds = BP.ObterComboTipoLancamento()

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna dados Para relatorio de Valores a Receber")> _
       Public Function ObterRelatorioValoresReceber(ByVal AnoMesRef As String, _
                                                    ByVal DataPrevisaoRecebimento As String, _
                                                    ByVal Fornecedor As Integer, _
                                                    ByVal objetivoVerba As Integer, _
                                                    ByVal isSintetico As Boolean, ByVal isCarimbados As Boolean) As DataSetValoresContabilizadosCarimbosRelatorio

        Try
            Dim BP As ValoresContabilizadosCarimbosBP
            Dim ds As DataSetValoresContabilizadosCarimbosRelatorio

            BP = New ValoresContabilizadosCarimbosBP
            ds = BP.ObterRelatorioValoresReceber(AnoMesRef, DataPrevisaoRecebimento, Fornecedor, objetivoVerba, isSintetico, isCarimbados)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna dados Para relatorio de Valores a Recebidos")> _
          Public Function ObterRelatorioValoresRecebidos(ByVal DataInicio As String, _
                                                         ByVal DataFim As String, _
                                                         ByVal Fornecedor As Decimal, _
                                                         ByVal TipoLancamento As String, _
                                                         ByVal objetivoVerba As Integer, _
                                                         ByVal isSintatico As Boolean, ByVal isCarimbados As Boolean) As DataSetValoresContabilizadosCarimbosRelatorio

        Try
            Dim BP As ValoresContabilizadosCarimbosBP
            Dim ds As DataSetValoresContabilizadosCarimbosRelatorio

            BP = New ValoresContabilizadosCarimbosBP
            ds = BP.ObterRelatorioValoresRecebidos(DataInicio, DataFim, Fornecedor, TipoLancamento, objetivoVerba, isSintatico, isCarimbados)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna dados Para relatorio de Verbas Carimbadas Realizado")> _
          Public Function ObterRelatorioVerbasCarimbadasRealizado(ByVal DataInicio As String, _
                                                                  ByVal DataFim As String, _
                                                                  ByVal Destino As Decimal, _
                                                                  ByVal Fornecedor As Decimal, _
                                                                  ByVal isSintatico As Boolean) As DataSetRelatorioVerbasCarimbadas

        Try
            Dim BP As ValoresContabilizadosCarimbosBP
            Dim ds As DataSetRelatorioVerbasCarimbadas

            BP = New ValoresContabilizadosCarimbosBP
            ds = BP.ObterRelatorioVerbasCarimbadasRealizado(DataInicio, DataFim, Destino, Fornecedor, isSintatico)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna dados Para relatorio de Verbas Carimbadas Cancelado")> _
          Public Function ObterRelatorioVerbasCarimbadasCancelado(ByVal DataInicio As String, _
                                                                  ByVal DataFim As String, _
                                                                  ByVal Destino As Decimal, _
                                                                  ByVal Fornecedor As Decimal, _
                                                                  ByVal isSintatico As Boolean) As DataSetRelatorioVerbasCarimbadas

        Try
            Dim BP As ValoresContabilizadosCarimbosBP
            Dim ds As DataSetRelatorioVerbasCarimbadas

            BP = New ValoresContabilizadosCarimbosBP
            ds = BP.ObterRelatorioVerbasCarimbadasCancelado(DataInicio, DataFim, Destino, Fornecedor, isSintatico)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna dados Para Relatorio de Novos Acordos")> _
              Public Function ObterRelatorioNovosAcordos(ByVal DataInicio As String, _
                                                         ByVal DataFim As String, _
                                                         ByVal Fornecedor As Decimal, _
                                                         ByVal isSintatico As Boolean) As DataSetRelatorioAcordos

        Try
            Dim BP As ValoresContabilizadosCarimbosBP
            Dim ds As DataSetRelatorioAcordos

            BP = New ValoresContabilizadosCarimbosBP
            ds = BP.ObterRelatorioNovosAcordos(DataInicio, DataFim, Fornecedor, isSintatico)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna dados Para Relatorio de Acordos Cancelados")> _
              Public Function ObterRelatorioAcordosCancelados(ByVal DataInicio As String, _
                                                              ByVal DataFim As String, _
                                                              ByVal Fornecedor As Decimal, _
                                                              ByVal isSintatico As Boolean) As DataSetRelatorioAcordos

        Try
            Dim BP As ValoresContabilizadosCarimbosBP
            Dim ds As DataSetRelatorioAcordos

            BP = New ValoresContabilizadosCarimbosBP
            ds = BP.ObterRelatorioAcordosCancelados(DataInicio, DataFim, Fornecedor, isSintatico)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function


    <WebMethod(Description:="Retorna dados Para combo de ano mes referencia")> _
    Public Function ObterComboAnoMesRef() As DataSetValoresContabilizadosCarimbosRelatorio

        Try
            Dim BP As ValoresContabilizadosCarimbosBP
            Dim ds As New DataSetValoresContabilizadosCarimbosRelatorio

            BP = New ValoresContabilizadosCarimbosBP
            ds = BP.ObterComboAnoMesRef()

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function


    <WebMethod(Description:="Retorna dados Para Relatorio ValorVendaCarimboXPendenteFaturar")> _
    Public Function ObterRValorVendaCarimboXPendenteFaturar(ByVal DataInicio As String, _
                                        ByVal DataFim As String, _
                                        ByVal mercadoria As Integer, _
                                        ByVal Filial As Decimal, _
                                        ByVal isSintatico As Boolean) As DataSetValoresContabilizadosCarimbosRelatorio

        Try
            Dim BP As ValoresContabilizadosCarimbosBP
            Dim ds As DataSetValoresContabilizadosCarimbosRelatorio

            BP = New ValoresContabilizadosCarimbosBP
            ds = BP.ObterRValorVendaCarimboXPendenteFaturar(DataInicio, DataFim, mercadoria, Filial, isSintatico)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna dados Para Relatorio ValoresRealizadosFundingCarimbo")> _
        Public Function ObterValoresRealizadosFundingCarimbo(ByVal DataInicio As String, _
                                            ByVal DataFim As String, _
                                            ByVal Fornecedor As Integer) As DataSetValoresContabilizadosCarimbosRelatorio

        Try
            Dim BP As ValoresContabilizadosCarimbosBP
            Dim ds As DataSetValoresContabilizadosCarimbosRelatorio

            BP = New ValoresContabilizadosCarimbosBP
            ds = BP.ObterValoresRealizadosFundingCarimbo(DataInicio, DataFim, Fornecedor)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function
#End Region
    <WebMethod(Description:="Atualizar Tipo Objetivo Verba:")> _
           Public Sub AtualizarTiposObjetivoVerba(ByVal ds As DatasetVerbaCarimbo)
        Try
            Dim bp As New VerbaCarimboBP
            Dim dst As DatasetVerbaCarimbo

            bp.AtualizarTiposObjetivoVerba(ds)

        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Sub
    <WebMethod(Description:="Retorna Dados do Tipo Objetivo Verba:")> _
       Public Function ObterTiposObjetivoVerba(ByVal nomeObjetivo As String, ByVal codigo As String) As DatasetVerbaCarimbo
        Try
            Dim bp As New VerbaCarimboBP
            Dim dst As DatasetVerbaCarimbo

            dst = bp.ObterTiposObjetivoVerba(nomeObjetivo, codigo)

            Return dst
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna Dados do Tipo Objetivo Verba:")> _
           Public Function ObterTiposObjetivoVerbaAtivo() As DatasetVerbaCarimbo
        Try
            Dim bp As New VerbaCarimboBP
            Dim dst As DatasetVerbaCarimbo

            dst = bp.ObterTiposObjetivoVerbaAtivo()

            Return dst
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com data limite maior que a data do dia. Entidade principal:T0109059")> _
        Public Function ObterEmpenhosValidos() As DatasetEmpenho
        Try
            Dim AcordoComercialBP As AcordoComercialBP
            Dim DatasetEmpenho As DatasetEmpenho

            AcordoComercialBP = New AcordoComercialBP
            DatasetEmpenho = AcordoComercialBP.ObterEmpenhosValidos()

            Return DatasetEmpenho
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function


    <WebMethod(Description:="Retorna id do registro(s) da T0109059 que possui relacao . Entidade principal:T0109059")> _
        Public Function VerificaDesaticavaoTipoDestinoVerba(ByVal id As Integer) As String
        Try
            Dim bp As VerbaCarimboBP


            bp = New VerbaCarimboBP


            Return bp.VerificaDesaticavaoTipoDestinoVerba(id)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

End Class