Imports System.Web.Services
Imports Martins.Security.Helper
Imports Martins.ExceptionManagement
Imports Martins.Compras.AcoesComerciais.ContaCorrenteFornecedor
Imports Martins.Compras.AcoesComerciais.ContaCorrenteFornecedor.BP
Imports Martins.Compras.AcoesComerciais.AcordoFornecimento.BP

<System.Web.Services.WebService(Namespace:="http://tempuri.org/Martins.Web.Services.AcoesComerciais/AcoesComerciais")> _
Public Class FluxoDeCancelamentoDeAcordos
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

   
    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0154038")> _
    Public Function ObterFluxoCancelamentoAcordoPorChave(ByVal CODFRN As Decimal, _
                                                         ByVal NUMPEDCNCACOCMC As Decimal) As DatasetFluxoCancelamentoAcordo
        Try
            Dim FluxoDeCancelamentoDeAcordosBP As FluxoDeCancelamentoDeAcordosBP
            Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo

            FluxoDeCancelamentoDeAcordosBP = New FluxoDeCancelamentoDeAcordosBP
            DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordosBP.ObterFluxoCancelamentoAcordoPorChave(CODFRN, NUMPEDCNCACOCMC)

            Return DatasetFluxoCancelamentoAcordo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0154038")> _
    Public Function ObterFluxoCancelamentoAcordoPorAtributos(ByVal CODFRN As Decimal, _
                                                             ByVal CODSTAAPV As Decimal, _
                                                             ByVal NUMPEDCNCACOCMC As Decimal, _
                                                             ByVal NUMREQCNCACOCMC As Decimal) As DatasetFluxoCancelamentoAcordo
        Try
            Dim FluxoDeCancelamentoDeAcordosBP As FluxoDeCancelamentoDeAcordosBP
            Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo

            FluxoDeCancelamentoDeAcordosBP = New FluxoDeCancelamentoDeAcordosBP
            DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordosBP.ObterFluxoCancelamentoAcordoPorAtributos(CODFRN, CODSTAAPV, NUMPEDCNCACOCMC, NUMREQCNCACOCMC)

            Return DatasetFluxoCancelamentoAcordo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0154038")> _
    Public Function AtualizarFluxoCancelamentoAcordo(ByVal DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo) As Boolean
        Try
            Dim FluxoDeCancelamentoDeAcordosBP As FluxoDeCancelamentoDeAcordosBP
            FluxoDeCancelamentoDeAcordosBP = New FluxoDeCancelamentoDeAcordosBP
            FluxoDeCancelamentoDeAcordosBP.AtualizarFluxoCancelamentoAcordo(DatasetFluxoCancelamentoAcordo)
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

    <WebMethod(Description:="Retorna um registro com base em sua chave primária. Entidade principal:T0154021")> _
    Public Function ObterAcordoACancelarEmFluxoCancelamentoAcordoPorChave(ByVal CODEMP As Decimal, _
                                                                          ByVal CODFILEMP As Decimal, _
                                                                          ByVal CODPMS As Decimal, _
                                                                          ByVal DATNGCPMS As Date, _
                                                                          ByVal DATPRVRCBPMS As Date, _
                                                                          ByVal NUMPEDCNCACOCMC As Decimal, _
                                                                          ByVal TIPDSNDSCBNF As Decimal, _
                                                                          ByVal TIPFRMDSCBNF As Decimal) As DatasetFluxoCancelamentoAcordo
        Try
            Dim FluxoDeCancelamentoDeAcordosBP As FluxoDeCancelamentoDeAcordosBP
            Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo

            FluxoDeCancelamentoDeAcordosBP = New FluxoDeCancelamentoDeAcordosBP
            DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordosBP.ObterAcordoACancelarEmFluxoCancelamentoAcordoPorChave(CODEMP, CODFILEMP, CODPMS, DATNGCPMS, DATPRVRCBPMS, NUMPEDCNCACOCMC, TIPDSNDSCBNF, TIPFRMDSCBNF)

            Return DatasetFluxoCancelamentoAcordo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0154021")> _
    Public Function ObterAcordoACancelarEmFluxoCancelamentoAcordoPorAtributos(ByVal CODEMP As Decimal, _
                                                                              ByVal CODFILEMP As Decimal, _
                                                                              ByVal CODPMS As Decimal, _
                                                                              ByVal DATNGCPMS As Date, _
                                                                              ByVal DATPRVRCBPMS As Date, _
                                                                              ByVal NUMPEDCNCACOCMC As Decimal, _
                                                                              ByVal TIPDSNDSCBNF As Decimal, _
                                                                              ByVal TIPFRMDSCBNF As Decimal) As DatasetFluxoCancelamentoAcordo
        Try
            Dim FluxoDeCancelamentoDeAcordosBP As FluxoDeCancelamentoDeAcordosBP
            Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo

            FluxoDeCancelamentoDeAcordosBP = New FluxoDeCancelamentoDeAcordosBP
            DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordosBP.ObterAcordoACancelarEmFluxoCancelamentoAcordoPorAtributos(CODEMP, CODFILEMP, CODPMS, DATNGCPMS, DATPRVRCBPMS, NUMPEDCNCACOCMC, TIPDSNDSCBNF, TIPFRMDSCBNF)

            Return DatasetFluxoCancelamentoAcordo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Atualização dos dados. Entidade principalT0154021")> _
    Public Function AtualizarAcordoACancelarEmFluxoCancelamentoAcordo(ByVal DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo) As Boolean
        Try
            Dim FluxoDeCancelamentoDeAcordosBP As FluxoDeCancelamentoDeAcordosBP
            FluxoDeCancelamentoDeAcordosBP = New FluxoDeCancelamentoDeAcordosBP
            FluxoDeCancelamentoDeAcordosBP.AtualizarAcordoACancelarEmFluxoCancelamentoAcordo(DatasetFluxoCancelamentoAcordo)
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

    <WebMethod(Description:="Obter as aprovações pendentes de um usuário")> _
    Public Function ObterMinhasAprovavoesEmFluxoDeCancelamentoDeAcordos(ByVal NUMPEDCNCACOCMC As Decimal, _
                                                                         ByVal CODFNC As Decimal) As DatasetFluxoCancelamentoAcordo
        Try
            Dim FluxoDeCancelamentoDeAcordosBP As FluxoDeCancelamentoDeAcordosBP
            Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo

            FluxoDeCancelamentoDeAcordosBP = New FluxoDeCancelamentoDeAcordosBP
            DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordosBP.ObterMinhasAprovavoesEmFluxoDeCancelamentoDeAcordos(NUMPEDCNCACOCMC, CODFNC)

            Return DatasetFluxoCancelamentoAcordo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Obter nova chave para a transferencia verba")> _
   Public Function ObterNovaChaveFluxoCancelamento() As Decimal
        Try
            Dim FluxoDeCancelamentoDeAcordos As New FluxoDeCancelamentoDeAcordosBP
            Dim chave As Decimal = FluxoDeCancelamentoDeAcordos.ObterNovaChaveFluxoCancelamento
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


    <WebMethod(Description:="Obter saldo disponível do fornecedor")> _
    Public Function ObterAcordosParaCancelamentoPorFornecedor(ByVal CODFRN As Decimal) As DatasetAcordoACancelarEmFluxoCancelamentoAcordo
        Try
            Dim FluxoDeCancelamentoDeAcordosBP As New FluxoDeCancelamentoDeAcordosBP
            Dim ds As DatasetAcordoACancelarEmFluxoCancelamentoAcordo

            ds = FluxoDeCancelamentoDeAcordosBP.ObterAcordosParaCancelamentoPorFornecedor(CODFRN)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Obter saldo disponível do fornecedor")> _
    Public Function ObterAcordosParaCancelamentoPorNUMPEDCNCACOCMC(ByVal NUMPEDCNCACOCMC As Decimal) As DatasetAcordoACancelarEmFluxoCancelamentoAcordo
        Try
            Dim FluxoDeCancelamentoDeAcordosBP As New FluxoDeCancelamentoDeAcordosBP
            Dim ds As DatasetAcordoACancelarEmFluxoCancelamentoAcordo

            ds = FluxoDeCancelamentoDeAcordosBP.ObterAcordosParaCancelamentoPorNUMPEDCNCACOCMC(NUMPEDCNCACOCMC)

            Return ds
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Iniciar Fluxo Cancelamento Acordo")> _
    Public Function IniciarFluxoCancelamentoAcordo(ByVal NUMPEDCNCACOCMC As Decimal, ByVal CODFRN As Decimal) As Boolean
        Try
            Dim FluxoDeCancelamentoDeAcordosBP As FluxoDeCancelamentoDeAcordosBP
            FluxoDeCancelamentoDeAcordosBP = New FluxoDeCancelamentoDeAcordosBP
            FluxoDeCancelamentoDeAcordosBP.IniciarFluxoCancelamentoAcordo(NUMPEDCNCACOCMC, CODFRN)
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

    <WebMethod(Description:="Retorna registro(s) com base em atributos (não necessariamente chave primária). Entidade principal:T0154038Pesquisa")> _
    Public Function ObterFluxoCancelamentoAcordoPesquisa(ByVal CODFRN As Decimal, _
                                                         ByVal CODSTAAPV As Decimal, _
                                                         ByVal NUMPEDCNCACOCMC As Decimal, _
                                                         ByVal NUMREQCNCACOCMC As Decimal) As DatasetFluxoCancelamentoAcordo
        Try
            Dim FluxoDeCancelamentoDeAcordosBP As FluxoDeCancelamentoDeAcordosBP
            Dim DatasetFluxoCancelamentoAcordo As DatasetFluxoCancelamentoAcordo

            FluxoDeCancelamentoDeAcordosBP = New FluxoDeCancelamentoDeAcordosBP
            DatasetFluxoCancelamentoAcordo = FluxoDeCancelamentoDeAcordosBP.ObterFluxoCancelamentoAcordoPesquisa(CODFRN, CODSTAAPV, NUMPEDCNCACOCMC, NUMREQCNCACOCMC)

            Return DatasetFluxoCancelamentoAcordo
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Reprovar Fluxo Cancelamento de Acordo")> _
    Public Function ReprovarFluxoCancelamentoAcordo(ByVal NUMPEDCNCACOCMC As Decimal, ByVal CODFRN As Decimal, ByVal CODFNC As Decimal, ByVal DESOBSAPV As String) As Boolean
        Try
            Dim FluxoDeCancelamentoDeAcordosBP As FluxoDeCancelamentoDeAcordosBP
            FluxoDeCancelamentoDeAcordosBP = New FluxoDeCancelamentoDeAcordosBP
            FluxoDeCancelamentoDeAcordosBP.ReprovarFluxoCancelamentoAcordo(NUMPEDCNCACOCMC, CODFRN, CODFNC, DESOBSAPV)
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

    <WebMethod(Description:="Aprovar  Fluxo Cancelamento de Acordo")> _
    Public Function AprovarFluxoCancelamentoAcordo(ByVal NUMPEDCNCACOCMC As Decimal, ByVal CODFNC As Decimal, ByVal CODFRN As Decimal, ByVal DESOBSAPV As String, ByVal NOMACSUSRSIS As String) As Boolean
        Try
            Dim FluxoDeCancelamentoDeAcordosBP As FluxoDeCancelamentoDeAcordosBP
            FluxoDeCancelamentoDeAcordosBP = New FluxoDeCancelamentoDeAcordosBP
            FluxoDeCancelamentoDeAcordosBP.AprovarFluxoCancelamentoAcordo(NUMPEDCNCACOCMC, CODFNC, CODFRN, DESOBSAPV, NOMACSUSRSIS)
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

    <WebMethod(Description:="Clonar Fluxo Cancelamento de Acordo")> _
    Public Function ClonarFluxoCancelamentoAcordoFornecedor(ByVal NUMPEDCNCACOCMC As Decimal, ByVal CODFRN As Decimal) As Decimal
        Try
            Dim FluxoDeCancelamentoDeAcordosBP As New FluxoDeCancelamentoDeAcordosBP
            Return FluxoDeCancelamentoDeAcordosBP.ClonarFluxoCancelamentoAcordoFornecedor(NUMPEDCNCACOCMC, CODFRN)
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException
            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
            Throw tempEx
        End Try
    End Function
End Class