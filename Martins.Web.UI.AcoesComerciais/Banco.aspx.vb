Public Class Banco
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetBanco1 = New Martins.Web.UI.AcoesComerciais.wsCobrancaBancaria.DatasetBanco
        CType(Me.DatasetBanco1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetBanco1
        '
        Me.DatasetBanco1.DataSetName = "DatasetBanco"
        Me.DatasetBanco1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetBanco1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetBanco1 As Martins.Web.UI.AcoesComerciais.wsCobrancaBancaria.DatasetBanco
    Protected WithEvents txtCODBCO As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtNOMBCO As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents txtNUMCGCBCO As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")

            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            End If

            If (Not IsPostBack) Then

                'Obtem BANCO
                If Not (Request.QueryString("CODBCO") Is Nothing) Then
                    ObterBanco(Decimal.Parse(Request.QueryString("CODBCO")))

                    'Dim x As wsAcoesComerciais.DatasetRelatorioHistoricoAcordo
                    'x = Controller.ObterRelatorioHistoricoAcordo(1)

                End If

            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = String.Empty

        Try
            Validar = True
            If mensagemErro.Trim() <> String.Empty Then
                lblErro.Visible = True
                lblErro.Text = (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1)
                Return False
            End If
            lblErro.Visible = False
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("BancoListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
    End Sub

    Public Sub ObterBanco(ByVal CODBCO As Decimal)
        Try
            DatasetBanco1 = Controller.ObterBanco(CODBCO)

            With DatasetBanco1.T0100345(0)
                txtCODBCO.Text = .CODBCO.ToString
                txtNOMBCO.Text = .NOMBCO.Trim()
                txtNUMCGCBCO.Text = .NUMCGCBCO.Trim()
            End With

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

End Class