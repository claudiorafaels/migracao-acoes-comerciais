Public Class MktExtraAcordoManter
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "
    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetMarketinExtraAcordo1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetMarketinExtraAcordo
        CType(Me.DatasetMarketinExtraAcordo1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetMarketinExtraAcordo1
        '
        Me.DatasetMarketinExtraAcordo1.DataSetName = "DatasetMarketinExtraAcordo"
        Me.DatasetMarketinExtraAcordo1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetMarketinExtraAcordo1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents Div1 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TRCodigo As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents TRDescricao As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents txtPERGRPMKTFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnSair As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cmbTIPFRMPGTBNF As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DatasetMarketinExtraAcordo1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetMarketinExtraAcordo
    Protected WithEvents cmbDataApuracao As Infragistics.WebUI.WebSchedule.WebDateChooser
    Protected WithEvents ucFornecedor As ucFornecedor
    Protected WithEvents cmbDataCadastro As Infragistics.WebUI.WebSchedule.WebDateChooser


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

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            SalvarDados()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Try
            Response.Redirect("MktExtraAcordoListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmbDataApuracao_ValueChanged(ByVal sender As Object, ByVal e As Infragistics.WebUI.WebSchedule.WebDateChooser.WebDateChooserEventArgs) Handles cmbDataApuracao.ValueChanged
        Try
            ValidaData()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub
#End Region

#Region "Métodos de Carga"

    Private Sub IniciarPagina()
        Dim CODFRN As Decimal = 0
        Dim DATCADMKTEXAARD As Date = Nothing
        
        If (Not (Request.QueryString("CODFRN") Is Nothing)) Or (Not (Request.QueryString("DATCADMKTEXAARD") Is Nothing)) Then
            CODFRN = CType(Request.QueryString("CODFRN"), Decimal)
            DATCADMKTEXAARD = CType(Request.QueryString("DATCADMKTEXAARD"), Date)
            CarregaPagina(CODFRN, DATCADMKTEXAARD)
        Else
            CarregaCombo()
            cmbDataApuracao.Value = GeraDataInicioApuracao()
            cmbDataCadastro.Value = Date.Now
        End If
    End Sub

    Private Sub carregarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
    End Sub

    Public Sub CarregaPagina(ByVal CODFRN As Decimal, ByVal DATCADMKTEXAARD As Date)
        Dim RLCFRNPERMKTEXAARDRow As wsAcoesComerciais.DatasetMarketinExtraAcordo.RLCFRNPERMKTEXAARDRow
        Dim dsFormaPagamento As wsAcoesComerciais.DatasetMarketinExtraAcordo = Controller.ObterFormaPagamentoMktExtraAcordo()
        Dim FormaPagamentoRow As wsAcoesComerciais.DatasetMarketinExtraAcordo.FormaPagamentoRow

        Me.DatasetMarketinExtraAcordo1 = Controller.ObterMarketingExtraAcordoPorChave(CODFRN, DATCADMKTEXAARD)

        If Not Me.DatasetMarketinExtraAcordo1 Is Nothing Then
            If Me.DatasetMarketinExtraAcordo1.RLCFRNPERMKTEXAARD.Rows.Count > 0 Then
                RLCFRNPERMKTEXAARDRow = Me.DatasetMarketinExtraAcordo1.RLCFRNPERMKTEXAARD(0)
                ucFornecedor.SelecionarFornecedor(RLCFRNPERMKTEXAARDRow.CODFRN)
                txtPERGRPMKTFRN.ValueDecimal = RLCFRNPERMKTEXAARDRow.PERMKTEXAARD
                cmbDataApuracao.Value = RLCFRNPERMKTEXAARDRow.DATINIAPUMKTEXAARD
                FormaPagamentoRow = dsFormaPagamento.FormaPagamento.FindByTIPFRMDSCBNF(RLCFRNPERMKTEXAARDRow.TIPFRMDSCBNF)
                If Not FormaPagamentoRow Is Nothing Then
                    cmbTIPFRMPGTBNF.Items.Add(FormaPagamentoRow.TIPFRMDSCBNF & " - " & FormaPagamentoRow.DESFRMDSCBNF.Trim)
                End If
                ucFornecedor.Enabled = False
                cmbDataApuracao.Enabled = False
                cmbTIPFRMPGTBNF.Enabled = False
                cmbDataCadastro.Value = DATCADMKTEXAARD
            End If
        End If
    End Sub

    Public Sub SalvarDados()
        If ValidaDados() Then
            If (ucFornecedor.Enabled = False) And (cmbDataApuracao.Enabled = False) And (cmbTIPFRMPGTBNF.Enabled = False) Then
                Dim CODFRN As Decimal = CType(Request.QueryString("CODFRN"), Decimal)
                Dim DATCADMKTEXAARD As Date = CType(Request.QueryString("DATCADMKTEXAARD"), Date)

                Me.DatasetMarketinExtraAcordo1 = Controller.ObterMarketingExtraAcordoPorChave(CODFRN, DATCADMKTEXAARD)

                If Me.DatasetMarketinExtraAcordo1.RLCFRNPERMKTEXAARD.Rows.Count > 0 Then
                    Me.DatasetMarketinExtraAcordo1.RLCFRNPERMKTEXAARD(0).PERMKTEXAARD = txtPERGRPMKTFRN.ValueDecimal
                End If

            Else
                Dim RLCFRNPERMKTEXAARDRow As wsAcoesComerciais.DatasetMarketinExtraAcordo.RLCFRNPERMKTEXAARDRow

                RLCFRNPERMKTEXAARDRow = Me.DatasetMarketinExtraAcordo1.RLCFRNPERMKTEXAARD.NewRLCFRNPERMKTEXAARDRow

                With RLCFRNPERMKTEXAARDRow
                    .CODFRN = ucFornecedor.CodFornecedor
                    .DATCADMKTEXAARD = Date.Now
                    .IsDATDSTMKTEXAARDNull()
                    .DATINIAPUMKTEXAARD = CType(cmbDataApuracao.Value, Date)
                    .PERMKTEXAARD = txtPERGRPMKTFRN.ValueDecimal
                    .TIPFRMDSCBNF = CType(Split(cmbTIPFRMPGTBNF.SelectedValue, "-")(0), Decimal)
                End With

                Me.DatasetMarketinExtraAcordo1.RLCFRNPERMKTEXAARD.AddRLCFRNPERMKTEXAARDRow(RLCFRNPERMKTEXAARDRow)

            End If

            Controller.AtualizarMarketingExtraAcordo(Me.DatasetMarketinExtraAcordo1)
            Response.Redirect("MktExtraAcordoListar.aspx")
        End If
    End Sub

    Private Sub CarregaCombo()

        Me.DatasetMarketinExtraAcordo1 = Controller.ObterFormaPagamentoMktExtraAcordo()

        If Not DatasetMarketinExtraAcordo1 Is Nothing Then
            If DatasetMarketinExtraAcordo1.FormaPagamento.Rows.Count > 0 Then
                cmbTIPFRMPGTBNF.Items.Add("SELECIONE")
                For Each linha As wsAcoesComerciais.DatasetMarketinExtraAcordo.FormaPagamentoRow In Me.DatasetMarketinExtraAcordo1.FormaPagamento
                    With cmbTIPFRMPGTBNF
                        .DataValueField = linha.TIPFRMDSCBNF.ToString
                        .Items.Add(linha.TIPFRMDSCBNF & " - " & linha.DESFRMDSCBNF)
                    End With
                Next
            End If
        End If
    End Sub

    Private Sub ValidaData()
        Dim dataSelecionada, dataAtual As Date
        Dim diaSelecionado, mesSelecionado, anoSelecionado As Integer
        Dim diaAtual, mesAtual, anoAtual As Integer

        dataSelecionada = CType(cmbDataApuracao.Value, Date)
        diaSelecionado = CType(Split(CType(dataSelecionada, String), "/")(0), Integer)
        mesSelecionado = CType(Split(CType(dataSelecionada, String), "/")(1), Integer)
        anoSelecionado = CType(Split(CType(dataSelecionada, String), "/")(2), Integer)


        dataAtual = Date.Now
        diaAtual = CType(Split(CType(dataAtual.Date, String), "/")(0), Integer)
        mesAtual = CType(Split(CType(dataAtual.Date, String), "/")(1), Integer)
        anoAtual = CType(Split(CType(dataAtual.Date, String), "/")(2), Integer)

        If (mesSelecionado < mesAtual) And (anoSelecionado >= anoAtual) Then
            Util.AdicionaJsAlert(Me.Page, "Data inválida! Data não pode ser menor que o primeiro dia do mês atual!", True)
            cmbDataApuracao.Value = GeraDataInicioApuracao()
            Exit Sub
        End If

        cmbDataApuracao.Value = 1 & "/" & mesSelecionado & "/" & anoSelecionado

    End Sub

    Private Function GeraDataInicioApuracao() As String
        Dim dataAtual As Date
        Dim mesAtual, anoAtual As Integer

        dataAtual = Date.Now
        mesAtual = CType(Split(CType(dataAtual.Date, String), "/")(1), Integer)
        anoAtual = CType(Split(CType(dataAtual.Date, String), "/")(2), Integer)
        Return 1 & "/" & mesAtual & "/" & anoAtual
    End Function

    Private Function ValidaDados() As Boolean
        If (txtPERGRPMKTFRN.ValueDecimal > 100) Or (txtPERGRPMKTFRN.ValueDecimal < 0) Then
            Util.AdicionaJsAlert(Me.Page, "Percentual deve ser maior que 0 (zero) e menor que 100 (cem)! ", True)
            Return False
        End If
        Return True
    End Function
#End Region

#Region "Métodos de Controle"
    Private Sub RecuperaEstado()
        '    Me.DatasetMarketinExtraAcordo1 = WebSession.dsTipoGrupoMarketing
    End Sub

    Private Sub SalvaEstado()
        '    WebSession.dsTipoGrupoMarketing = Me.DatasetMarketinExtraAcordo1
    End Sub
#End Region

#Region "Métodos de Regra"

#End Region

End Class