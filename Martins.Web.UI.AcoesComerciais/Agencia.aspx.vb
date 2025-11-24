Public Class Agencia
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetAgencia1 = New Martins.Web.UI.AcoesComerciais.wsCobrancaBancaria.DatasetAgencia
        CType(Me.DatasetAgencia1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetAgencia1
        '
        Me.DatasetAgencia1.DataSetName = "DatasetAgencia"
        Me.DatasetAgencia1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetAgencia1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetAgencia1 As Martins.Web.UI.AcoesComerciais.wsCobrancaBancaria.DatasetAgencia
    Protected WithEvents txtCODAGEBCO As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents cmbCODBCO As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNOMAGEBCO As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents txtNUMDIGVRFAGEBCO As Infragistics.WebUI.WebDataInput.WebNumericEdit
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
            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            End If
            btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")

            If (Not IsPostBack) Then

                'Obtem AGENCIA
                If Not (Request.QueryString("CODAGEBCO") Is Nothing) Then
                    ObterAgencia(Decimal.Parse(Request.QueryString("CODAGEBCO")), Decimal.Parse(Request.QueryString("CODBCO")))
                Else
                    ViewState("flagInclusao") = True
                End If

                'Carrega o combo de bancos
                With cmbCODBCO
                    .DataSource = Controller.ObterBancos(0, String.Empty, 0, String.Empty, 0)
                    .DataMember = "T0100345"
                    .DataTextField = "NOMBCO"
                    .DataValueField = "CODBCO"
                    .DataBind()
                End With
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
            Response.Redirect("AgenciaListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
    End Sub

    Public Sub ObterAgencia(ByVal CODAGEBCO As Decimal, _
                            ByVal CODBCO As Decimal)
        Try
            DatasetAgencia1 = Controller.ObterAgencia(CODAGEBCO, _
                                                      CODBCO)
            With DatasetAgencia1.T0104413(0)
                'CODIGO AGENCIA DO BANCO
                txtCODAGEBCO.Text = .CODAGEBCO.ToString
                'CODIGO BANCO
                cmbCODBCO.SelectedValue = .CODBCO.ToString
                'CODIGO DE ENDERECAMENTO POSTAL AGENCIA BANCARIA
                'txtCODCEPAGEBCO.Text = .CODCEPAGEBCO.ToString
                'CODIGO CIDADE AGENCIA BANCARIA
                'txtCODCIDAGEBCO.Text = .CODCIDAGEBCO.ToString
                'ENDERECO DA AGENCIA BANCARIA
                'txtENDAGEBCO.Text = .ENDAGEBCO.Trim()
                'INDICA SE AGENCIA E CEDENTE COBRANCA BANCARIA
                'txtFLGAGECDTCOBBCO.Text = .FLGAGECDTCOBBCO.Trim()
                'INDICA SE AGENCIA BANCARIA PARTICIPA SISTEMA COBRANCA B
                'txtFLGAGECOBBCO.Text = .FLGAGECOBBCO.Trim()
                'NOME AGENCIA DO BANCO
                txtNOMAGEBCO.Text = .NOMAGEBCO.Trim()
                ''NUMERO CGC
                'txtNUMCGCAGEBCO.Text = .NUMCGCAGEBCO.Trim()
                ''NUMERO CONTA CORRENTE CEDENTE
                'txtNUMCNTCRRCDT.Text = .NUMCNTCRRCDT.ToString
                ''NUMERO DIGITO VERIFICADOR CONTA CORRENTE CEDENTE
                'txtNUMDGTVRFCNTCRRCDT.Text = .NUMDGTVRFCNTCRRCDT.ToString
                'DIGITO VERIFICADOR PARA O CODIGO DA AGENCIA DO BANCO
                txtNUMDIGVRFAGEBCO.Text = .NUMDIGVRFAGEBCO.Trim()
                'NUMERO FAX AGENCIA BANCARIA
                'txtNUMFAXAGEBCO.Text = .NUMFAXAGEBCO.Trim()
                'NUMERO TELEFONE
                'txtNUMTLFAGEBCO.Text = .NUMTLFAGEBCO.Trim()
            End With

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

End Class