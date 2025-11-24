Imports System.Web.Services
Imports Martins.Security.Helper
Imports Martins.ExceptionManagement
Imports Martins.Compras.AcoesComerciais.ContaCorrenteFornecedor
Imports Martins.Compras.AcoesComerciais.ContaCorrenteFornecedor.BP
Imports Martins.Compras.AcoesComerciais.AcordoFornecimento
Imports Martins.Compras.AcoesComerciais.AcordoFornecimento.BP

<System.Web.Services.WebService(Namespace:="http://tempuri.org/Martins.Web.Services.AcoesComerciais/RecuperacaoEPrevencaoPerdas")> _
Public Class RecuperacaoEPrevencaoPerdas
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
        MyBase.Dispose(disposing)
    End Sub

#End Region

    ' WEB SERVICE EXAMPLE
    ' The HelloWorld() example service returns the string Hello World.
    ' To build, uncomment the following lines then save and build the project.
    ' To test this web service, ensure that the .asmx file is the start page
    ' and press F5.
    '
    '<WebMethod()> _
    'Public Function HelloWorld() As String
    '   Return "Hello World"
    'End Function

    <WebMethod(Description:="Obtem dados para o relatorio Recuperacao e Prevencao de Perdas")> _
   Public Function ObterRecuperacaoEPrevencaoPerdasSintetico(ByVal NUMCTTFRN As Decimal, _
                                                              ByVal INDDVRVLRAPUARDFRN As Decimal, _
                                                              ByVal TIPLMTHSTCFAARDFRN As Decimal) As DatasetRecuperacaoEPrevencaoPerdas
        Try
            Dim RecuperacaoEPrevencaoPerdaBP As RecuperacaoEPrevencaoPerdasBP
            Dim DatasetRecuperacaoEPrevencaoPerdas As DatasetRecuperacaoEPrevencaoPerdas

            RecuperacaoEPrevencaoPerdaBP = New RecuperacaoEPrevencaoPerdasBP
            DatasetRecuperacaoEPrevencaoPerdas = RecuperacaoEPrevencaoPerdaBP.ObterRecuperacaoEPrevencaoPerdasSintetico(NUMCTTFRN, INDDVRVLRAPUARDFRN, TIPLMTHSTCFAARDFRN)

            Return DatasetRecuperacaoEPrevencaoPerdas
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Obtem dados para o relatorio Recuperacao e Prevencao de Perdas")> _
   Public Function ObterRecuperacaoEPrevencaoPerdasAnalitico(ByVal NUMCTTFRN As Decimal, _
                                                             ByVal INDDVRVLRAPUARDFRN As Decimal, _
                                                             ByVal TIPLMTHSTCFAARDFRN As Decimal, _
                                                             ByVal DATREFAPU As Date, _
                                                             ByVal NUMCSLCTTFRN As Decimal) As DatasetRecuperacaoEPrevencaoPerdas
        Try
            Dim RecuperacaoEPrevencaoPerdaBP As RecuperacaoEPrevencaoPerdasBP
            Dim DatasetRecuperacaoEPrevencaoPerdas As DatasetRecuperacaoEPrevencaoPerdas

            RecuperacaoEPrevencaoPerdaBP = New RecuperacaoEPrevencaoPerdasBP
            DatasetRecuperacaoEPrevencaoPerdas = RecuperacaoEPrevencaoPerdaBP.ObterRecuperacaoEPrevencaoPerdasAnalitico(NUMCTTFRN, INDDVRVLRAPUARDFRN, TIPLMTHSTCFAARDFRN, DATREFAPU, NUMCSLCTTFRN)

            Return DatasetRecuperacaoEPrevencaoPerdas
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Obtem dados para o relatorio Notas Periodo")> _
   Public Function ObterNotasPeriodo(ByVal NUMCTTFRN As Decimal, _
                                     ByVal CODFRN As Decimal) As DatasetRecuperacaoEPrevencaoPerdas
        Try
            Dim RecuperacaoEPrevencaoPerdaBP As RecuperacaoEPrevencaoPerdasBP
            Dim DatasetRecuperacaoEPrevencaoPerdas As DatasetRecuperacaoEPrevencaoPerdas

            RecuperacaoEPrevencaoPerdaBP = New RecuperacaoEPrevencaoPerdasBP
            DatasetRecuperacaoEPrevencaoPerdas = RecuperacaoEPrevencaoPerdaBP.ObterNotasPeriodo(NUMCTTFRN, CODFRN)

            Return DatasetRecuperacaoEPrevencaoPerdas
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Obtem dados para o relatorio Recuperacao e Prevencao de Perdas")> _
   Public Function ObterRecuperacaoEPrevencaoPerdasClausulas(ByVal NUMCTTFRN As Decimal) As DatasetRecuperacaoEPrevencaoPerdas
        Try
            Dim RecuperacaoEPrevencaoPerdaBP As RecuperacaoEPrevencaoPerdasBP
            Dim DatasetRecuperacaoEPrevencaoPerdas As DatasetRecuperacaoEPrevencaoPerdas

            RecuperacaoEPrevencaoPerdaBP = New RecuperacaoEPrevencaoPerdasBP
            DatasetRecuperacaoEPrevencaoPerdas = RecuperacaoEPrevencaoPerdaBP.ObterRecuperacaoEPrevencaoPerdasClausulas(NUMCTTFRN)

            Return DatasetRecuperacaoEPrevencaoPerdas
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Obtem dados para o relatorio Recuperacao e Prevencao de Perdas")> _
       Public Function ObterRecuperacaoEPrevencaoPerdasDataApuracao(ByVal NUMCTTFRN As Decimal) As DatasetRecuperacaoEPrevencaoPerdas
        Try
            Dim RecuperacaoEPrevencaoPerdaBP As RecuperacaoEPrevencaoPerdasBP
            Dim DatasetRecuperacaoEPrevencaoPerdas As DatasetRecuperacaoEPrevencaoPerdas

            RecuperacaoEPrevencaoPerdaBP = New RecuperacaoEPrevencaoPerdasBP
            DatasetRecuperacaoEPrevencaoPerdas = RecuperacaoEPrevencaoPerdaBP.ObterRecuperacaoEPrevencaoPerdasDataApuracao(NUMCTTFRN)

            Return DatasetRecuperacaoEPrevencaoPerdas
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Obtem dados para o relatorio Acordos Cancelados Perdas")> _
   Public Function ObterAcordosCanceladosPerdas(ByVal DATAINICIAL As Date, _
                                                ByVal DATAFINAL As Date, _
                                                ByVal CODFRN As Decimal, _
                                                ByVal CODCPR As Decimal, _
                                                ByVal CODDIVCMP As Decimal) As DatasetRecuperacaoEPrevencaoPerdas
        Try
            Dim RecuperacaoEPrevencaoPerdaBP As RecuperacaoEPrevencaoPerdasBP
            Dim DatasetRecuperacaoEPrevencaoPerdas As DatasetRecuperacaoEPrevencaoPerdas

            RecuperacaoEPrevencaoPerdaBP = New RecuperacaoEPrevencaoPerdasBP
            DatasetRecuperacaoEPrevencaoPerdas = RecuperacaoEPrevencaoPerdaBP.ObterAcordosCanceladosPerdas(DATAINICIAL, DATAFINAL, CODFRN, CODCPR, CODDIVCMP)

            Return DatasetRecuperacaoEPrevencaoPerdas
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Obtem dados para o relatorio Acordos Cancelados Perdas")> _
  Public Function ObterComprador(ByVal CODCPR As Decimal, _
                                 ByVal NOMCPR As String) As DatasetRecuperacaoEPrevencaoPerdas
        Try
            Dim RecuperacaoEPrevencaoPerdaBP As RecuperacaoEPrevencaoPerdasBP
            Dim DatasetRecuperacaoEPrevencaoPerdas As DatasetRecuperacaoEPrevencaoPerdas

            RecuperacaoEPrevencaoPerdaBP = New RecuperacaoEPrevencaoPerdasBP
            DatasetRecuperacaoEPrevencaoPerdas = RecuperacaoEPrevencaoPerdaBP.ObterComprador(CODCPR, NOMCPR)

            Return DatasetRecuperacaoEPrevencaoPerdas
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Obtem dados para o relatorio Acordos Cancelados Perdas")> _
  Public Function ObterCelulaPorAtributo(ByVal CODDIVCMP As Decimal, _
                                         ByVal DESDIVCMP As String) As DatasetCelula
        Try
            Dim bp As RecuperacaoEPrevencaoPerdasBP
            Dim DatasetCelula As DatasetCelula

            bp = New RecuperacaoEPrevencaoPerdasBP
            DatasetCelula = bp.ObterCelulaPorAtributo(CODDIVCMP, DESDIVCMP)

            Return DatasetCelula
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

    <WebMethod(Description:="Obtem dados para o relatorio Previsao Apuracao")> _
  Public Function ObterDiretoriaCelulas(ByVal CODCPR As Decimal, _
                                              ByVal CODDRT As Decimal, _
                                              ByVal CODDRTCMP As Decimal, _
                                              ByVal CODUNDESRNGC As Decimal, _
                                              ByVal DESDRTCMP As String) As DatasetDiretoriaCelulas
        Try
            Dim RecuperacaoEPrevencaoPerdasBP As RecuperacaoEPrevencaoPerdasBP
            Dim DatasetDiretoriaCelulas As DatasetDiretoriaCelulas

            RecuperacaoEPrevencaoPerdasBP = New RecuperacaoEPrevencaoPerdasBP
            DatasetDiretoriaCelulas = RecuperacaoEPrevencaoPerdasBP.ObterDiretoriaCelulas(CODCPR, CODDRT, CODDRTCMP, CODUNDESRNGC, DESDRTCMP)

            Return DatasetDiretoriaCelulas
        Catch ex As Martins.ExceptionManagement.BaseApplicationException
            ex.GenerateSoapException()
        Catch ex As Exception
            Dim tempEx As MartinsSystemException

            tempEx = New MartinsSystemException(ex.Message, Martins.Compras.AcoesComerciais.AcordoFornecimento.ErrorConstants.SYSTEM_ERROR, ex)
            tempEx.GenerateSoapException()
        End Try
    End Function

End Class

