Public Class ProgramaIncentivoManter
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
    Protected WithEvents txtCODPRGICT As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtNOMPRGICT As Infragistics.WebUI.WebDataInput.WebTextEdit


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
            Response.Redirect("ProgramaIncentivoListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub
#End Region

#Region "Métodos de Carga"

    Private Sub IniciarPagina()
        Dim CODPRGICT As Decimal = 0
        If Not Request.QueryString() Is Nothing Then
            CODPRGICT = CType(Request.QueryString("CODPRGICT"), Decimal)
        End If
        CarregaPagina(CODPRGICT)
    End Sub

    Private Sub carregarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
    End Sub

    Public Sub CarregaPagina(ByVal CODPRGICT As Decimal)
        Dim CADCODPRGICTRow As wsAcoesComerciais.DatasetIncentivo.CADPRGICTRow

        Me.DatasetIncentivo1 = Controller.ObterIncentivoPorChave(CODPRGICT)

        If Not Me.DatasetIncentivo1 Is Nothing Then
            If Me.DatasetIncentivo1.CADPRGICT.Rows.Count > 0 Then
                CADCODPRGICTRow = Me.DatasetIncentivo1.CADPRGICT(0)

                txtCODPRGICT.ValueDecimal = CADCODPRGICTRow.CODPRGICT
                txtNOMPRGICT.Text = CADCODPRGICTRow.NOMPRGICT
            End If
        End If
    End Sub

    Public Sub SalvarDados()
        Dim CODPRGICT As Decimal = Controller.ObterNovaChaveIncentivo()
        Dim CADCODPRGICTRow As wsAcoesComerciais.DatasetIncentivo.CADPRGICTRow

        If txtCODPRGICT.Text = String.Empty Then
            CADCODPRGICTRow = Me.DatasetIncentivo1.CADPRGICT.NewCADPRGICTRow
        Else
            CODPRGICT = txtCODPRGICT.ValueDecimal
            Me.DatasetIncentivo1 = Controller.ObterIncentivoPorChave(CODPRGICT)
            CADCODPRGICTRow = Me.DatasetIncentivo1.CADPRGICT(0)
        End If

        With CADCODPRGICTRow
            .CODPRGICT = CType(txtCODPRGICT.ValueDecimal, Integer)
            .NOMPRGICT = txtNOMPRGICT.Text.ToUpper.Trim
        End With

        If txtCODPRGICT.Text = String.Empty Then
            Me.DatasetIncentivo1.CADPRGICT.AddCADPRGICTRow(CADCODPRGICTRow)
        End If

        Controller.AtualizarIncentivo(Me.DatasetIncentivo1)

        Response.Redirect("ProgramaIncentivoListar.aspx?CODPRGICT=" & CODPRGICT.ToString)
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