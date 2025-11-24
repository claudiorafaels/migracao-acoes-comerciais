Public Class ObservacaoBaixaAcordo
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetAcordo1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetAcordo
        CType(Me.DatasetAcordo1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetAcordo1
        '
        Me.DatasetAcordo1.DataSetName = "DatasetAcordo"
        Me.DatasetAcordo1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetAcordo1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnSair As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblObservacao As System.Web.UI.WebControls.Label
    Protected WithEvents DatasetAcordo1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetAcordo
    Protected WithEvents txtDESJSTCNCVLRARDCMC As System.Web.UI.WebControls.TextBox

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

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            Salvar()
            Util.FecharPagina(Me.Page)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Try
            If Util.FecharPaginaSeASessionExpirou(Me.Page) Then
                Exit Sub
            End If
            Util.FecharPagina(Me.Page)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#Region "Metodo Carga"

    Private Sub IniciarPagina()
        Try
            'AtualizaTela()
            Util.AdicionaJsFocus(Me.Page, txtDESJSTCNCVLRARDCMC)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub carregarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
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

    'Private Sub AtualizaTela()
    '    Try
    '        If Not Request.QueryString("action") Is Nothing Then
    '            Select Case CType(Request.QueryString("action"), String)
    '                Case "Perda"
    '                    lblObservacao.Text = "Justificativa Vr. Perda:"
    '                    btnSalvar.ToolTip = "Alterar Vr. Perda"
    '                Case "Pago"
    '                    lblObservacao.Text = "Justificativa Vr. Pago:"
    '                    btnSalvar.ToolTip = "Alterar Vr. Pago"
    '            End Select
    '        End If
    '    Catch ex As Exception
    '        Controller.TrataErro(Me.Page, ex)
    '    End Try
    'End Sub

#End Region

#Region "Metodos de controle"

    Private Sub RecuperaEstado()
    End Sub

    Private Sub SalvaEstado()
    End Sub

#End Region

#Region "Regra"

    Private Sub Salvar()
        DatasetAcordo1.EnforceConstraints = False
        Dim T0120540RowDestino As wsAcoesComerciais.DatasetAcordo.T0120540Row
        Dim T0120540RowOrigem As wsAcoesComerciais.DatasetAcordo.T0120540Row
        Dim T0118066RowDestino As wsAcoesComerciais.DatasetAcordo.T0118066Row
        Dim T0118066RowOrigem As wsAcoesComerciais.DatasetAcordo.T0118066Row

        T0120540RowOrigem = WSCAcoesComerciais.T0120540Row
        T0118066RowOrigem = WSCAcoesComerciais.T0118066Row

        If txtDESJSTCNCVLRARDCMC.Text = String.Empty Then
            Util.AdicionaJsAlert(Me.Page, "Digite a Justificativa!", True)
            Exit Sub
        End If
        DatasetAcordo1 = Controller.ObterAcordo(T0118066RowOrigem.CODEMP, T0118066RowOrigem.CODFILEMP, T0118066RowOrigem.CODPMS, T0118066RowOrigem.DATNGCPMS)

        T0118066RowDestino = DatasetAcordo1.T0118066.FindByCODEMPCODFILEMPCODPMSDATPRVRCBPMSTIPFRMDSCBNFTIPDSNDSCBNFDATNGCPMS(T0118066RowOrigem.CODEMP, _
                                                                                                                              T0118066RowOrigem.CODFILEMP, _
                                                                                                                              T0118066RowOrigem.CODPMS, _
                                                                                                                              T0118066RowOrigem.DATPRVRCBPMS, _
                                                                                                                              T0118066RowOrigem.TIPFRMDSCBNF, _
                                                                                                                              T0118066RowOrigem.TIPDSNDSCBNF, _
                                                                                                                              T0118066RowOrigem.DATNGCPMS)


        If Not T0118066RowDestino Is Nothing Then
            With T0118066RowDestino
                .VLRPGOPMS = T0118066RowOrigem.VLRPGOPMS
                .VLRPDAPMS = T0118066RowOrigem.VLRPDAPMS
            End With
        End If

        T0120540RowDestino = DatasetAcordo1.T0120540.NewT0120540Row
        With T0120540RowDestino
            .CodEmp = T0120540RowOrigem.CodEmp
            .CodFilEmp = T0120540RowOrigem.CodFilEmp
            .CodPms = T0120540RowOrigem.CodPms
            .DatAltPms = T0120540RowOrigem.DatAltPms
            .DatNgcPms = T0120540RowOrigem.DatNgcPms
            .DatPrvRcbPms = T0120540RowOrigem.DatPrvRcbPms
            .DESJSTCNCVLRARDCMC = txtDESJSTCNCVLRARDCMC.Text
            .FlgLstPlhLmt = T0120540RowOrigem.FlgLstPlhLmt
            .NomAcsUsrSis = T0120540RowOrigem.NomAcsUsrSis
            .NumUltAltPms = T0120540RowOrigem.NumUltAltPms
            .TipDsnDscBnf = T0120540RowOrigem.TipDsnDscBnf
            .TipFrmDscBnf = T0120540RowOrigem.TipFrmDscBnf
            .VlrLstPlhLmt = T0120540RowOrigem.VlrLstPlhLmt
            .VlrPdaPmsAnt = T0120540RowOrigem.VlrPdaPmsAnt
            .VlrPgoPms = T0120540RowOrigem.VlrPgoPms
            .VlrPgoPmsAnt = T0120540RowOrigem.VlrPgoPmsAnt
            If Not T0120540RowOrigem.IsCODCENCSTNull Then
                .CODCENCST = T0120540RowOrigem.CODCENCST
            Else
                .CODCENCST = 0
            End If

        End With

        DatasetAcordo1.T0120540.Rows.Add(T0120540RowDestino)
        Controller.AtualizarAcordo(DatasetAcordo1)

        Util.AdicionaJsAlert(Me.Page, "Gravação com sucesso", True)
    End Sub

#End Region

End Class