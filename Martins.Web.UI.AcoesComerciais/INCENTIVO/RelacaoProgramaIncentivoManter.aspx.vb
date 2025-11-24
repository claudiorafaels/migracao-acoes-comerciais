Public Class RelacaoProgramaIncentivoManter
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "
    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetIncentivo1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetIncentivo
        CType(Me.DatasetIncentivo1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetIncentivo1
        '
        Me.DatasetIncentivo1.DataSetName = "DatasetIncentivo"
        Me.DatasetIncentivo1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetIncentivo1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents Div1 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TRCodigo As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents TRDescricao As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents DatasetIncentivo1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetIncentivo
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnSair As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ucFornecedor As ucFornecedor
    Protected WithEvents ucPrograma As ucPrograma
    Protected WithEvents btnExcluir As System.Web.UI.WebControls.LinkButton


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
            Response.Redirect("RelacaoProgramaIncentivoListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click
        Try
            ExcluiRegistro()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub
#End Region

#Region "Métodos de Carga"

    Private Sub IniciarPagina()
        Dim CODPRGICT As Decimal = 0
        Dim CODFRN As Decimal = 0
        If (Not Request.QueryString("CODPRGICT") Is Nothing) And (Not Request.QueryString("CODFRN") Is Nothing) Then
            CODPRGICT = CType(Request.QueryString("CODPRGICT"), Decimal)
            CODFRN = CType(Request.QueryString("CODFRN"), Decimal)
            CarregaPagina(CODPRGICT, CODFRN)
        End If
        WSCAcoesComerciais.CODPRGICT = CODPRGICT
        WSCAcoesComerciais.CODFRN = CODFRN
    End Sub

    Private Sub carregarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        btnExcluir.Attributes.Add("OnClick", "javascript:mostraAndamento()")
    End Sub

    Public Sub CarregaPagina(ByVal CODPRGICT As Decimal, ByVal CODFRN As Decimal)
        Dim RLCPRGICTFRNPesquisaRow As wsAcoesComerciais.DatasetIncentivo.RLCPRGICTFRNPesquisaRow

        Me.DatasetIncentivo1 = Controller.ObterRelacaoIncentivoFornecedorPesquisa(CODPRGICT, CODFRN)

        If Not Me.DatasetIncentivo1 Is Nothing Then
            If Me.DatasetIncentivo1.RLCPRGICTFRNPesquisa.Rows.Count > 0 Then
                RLCPRGICTFRNPesquisaRow = Me.DatasetIncentivo1.RLCPRGICTFRNPesquisa(0)

                ucPrograma.SelecionarPrograma(RLCPRGICTFRNPesquisaRow.PROGRAMA)
                ucPrograma.Enabled = False
                ucFornecedor.SelecionarFornecedor(RLCPRGICTFRNPesquisaRow.CODIGO)
            End If
        End If
    End Sub

    Public Sub SalvarDados()
        Dim RLCPRGICTFRNRow As wsAcoesComerciais.DatasetIncentivo.RLCPRGICTFRNRow
        Dim CODPRGICT As Decimal
        Dim CODFRN As Decimal

        If WSCAcoesComerciais.CODPRGICT <> 0 And WSCAcoesComerciais.CODFRN <> 0 Then
            CODPRGICT = WSCAcoesComerciais.CODPRGICT
            CODFRN = WSCAcoesComerciais.CODFRN
        Else
            If ucPrograma.CodPrograma <> 0 Then
                CODPRGICT = ucPrograma.CodPrograma
            Else
                Util.AdicionaJsAlert(Me.Page, "É necessário informar o código do programa", True)
            End If

            If ucFornecedor.CodFornecedor <> 0 Then
                CODFRN = ucFornecedor.CodFornecedor
            Else
                Util.AdicionaJsAlert(Me.Page, "É necessário informar o fornecedor", True)
            End If
        End If

        Me.DatasetIncentivo1 = Controller.ObterRelacaoIncentivoFornecedor(CODPRGICT, CODFRN)

        If Me.DatasetIncentivo1.RLCPRGICTFRN.Rows.Count > 0 Then
            RLCPRGICTFRNRow = Me.DatasetIncentivo1.RLCPRGICTFRN(0)
            CODFRN = ucFornecedor.CodFornecedor
            CODPRGICT = ucPrograma.CodPrograma
            'Util.AdicionaJsAlert(Me.Page, "Esta relação já foi cadastrada! Entre com uma relação diferente.", True)
            'Exit Sub
        Else
            RLCPRGICTFRNRow = Me.DatasetIncentivo1.RLCPRGICTFRN.NewRLCPRGICTFRNRow
        End If

        With RLCPRGICTFRNRow
            .CODPRGICT = CODPRGICT
            .CODFRN = CODFRN
        End With

        If Me.DatasetIncentivo1.RLCPRGICTFRN.Rows.Count = 0 Then
            Me.DatasetIncentivo1.RLCPRGICTFRN.AddRLCPRGICTFRNRow(RLCPRGICTFRNRow)
        End If

        Controller.AtualizarRelacaoIncentivoFornecedor(Me.DatasetIncentivo1)

        WSCAcoesComerciais.CODPRGICT = 0
        WSCAcoesComerciais.CODFRN = 0

        Response.Redirect("RelacaoProgramaIncentivoListar.aspx?CODPRGICT=" & CODPRGICT.ToString & "&CODFRN=" & CODFRN.ToString)
    End Sub

    Private Sub ExcluiRegistro()
        Dim CODPRGICT As Decimal
        Dim CODFRN As Decimal

        Dim RLCPRGICTFRNRow As wsAcoesComerciais.DatasetIncentivo.RLCPRGICTFRNRow
        If ucPrograma.CodPrograma <> 0 Then
            CODPRGICT = ucPrograma.CodPrograma
        Else
            Util.AdicionaJsAlert(Me.Page, "É necessário informar o código do programa", True)
        End If

        If ucFornecedor.CodFornecedor <> 0 Then
            CODFRN = ucFornecedor.CodFornecedor
        Else
            Util.AdicionaJsAlert(Me.Page, "É necessário informar o fornecedor", True)
        End If

        Me.DatasetIncentivo1 = Controller.ObterRelacaoIncentivoFornecedor(CODPRGICT, CODFRN)

        If Me.DatasetIncentivo1.RLCPRGICTFRN.Rows.Count > 0 Then
            RLCPRGICTFRNRow = Me.DatasetIncentivo1.RLCPRGICTFRN(0)
        End If
        RLCPRGICTFRNRow.Delete()

        Controller.AtualizarRelacaoIncentivoFornecedor(Me.DatasetIncentivo1)

        WSCAcoesComerciais.CODPRGICT = 0
        WSCAcoesComerciais.CODFRN = 0

        Response.Redirect("RelacaoProgramaIncentivoListar.aspx")
    End Sub
#End Region

#Region "Métodos de Controle"
    Private Sub RecuperaEstado()
        '    Me.DatasetIncentivo1 = WebSession.dsIncentivo
    End Sub

    Private Sub SalvaEstado()
        '    WebSession.dsIncentivo = Me.DatasetIncentivo1
    End Sub
#End Region

#Region "Métodos de Regra"

#End Region

End Class