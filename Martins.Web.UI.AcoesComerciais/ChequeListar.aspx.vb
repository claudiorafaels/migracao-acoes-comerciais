Public Class ChequeListar
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "
    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblFrame As System.Web.UI.WebControls.Label
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnInserir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents txtDataInicial As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtDataFinal As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents cmbCriterio As System.Web.UI.WebControls.DropDownList
    Protected WithEvents LblA As System.Web.UI.WebControls.Label
    Protected WithEvents LblFornecedor As System.Web.UI.WebControls.Label
    Protected WithEvents txtCODFRN As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents Espera As System.Web.UI.WebControls.Image
    Protected WithEvents Div1 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents txtCodigo As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable

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
        btnPesquisar.Attributes.Add("OnClick", "javascript:mostraAndamento()")

        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        If (Not IsPostBack) Then
            RestaurarCriteriosDePesquisa(sender, e)
        End If
    End Sub

    Private Sub btnInserir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInserir.Click
        Controller.NavegarInserirCheque()
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Try
            'Verifica o critério
            If cmbCriterio.SelectedValue = "1" Then     '1 Período
                If Not IsDate(txtDataInicial.Text) Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Data inicial não informada ou inválida.');</script>")
                    Exit Try
                End If
                If Not IsDate(txtDataFinal.Text) Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Data final não informada ou inválida.');</script>")
                    Exit Try
                End If
                If Date.Parse(txtDataInicial.Text) > Date.Parse(txtDataFinal.Text) Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Data inicial maior que data final.');</script>")
                    Exit Try
                End If
                lblFrame.Text = "<iframe src='" & "ChequeListarGrid.aspx?criterio=" & cmbCriterio.SelectedItem.Value & "&DATRCBCHQInicial=" & txtDataInicial.Text & "&DATRCBCHQFinal=" & txtDataFinal.Text & "' height=100% width=100% frameborder=0 ALLOWTRANSPARENCY scrolling=yes></iframe>"
            ElseIf cmbCriterio.SelectedValue = "2" Then '2 Data Previsão
                If Not IsDate(txtDataInicial.Text) Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Data não informada ou inválida.');</script>")
                    Exit Try
                End If
                lblFrame.Text = "<iframe src='" & "ChequeListarGrid.aspx?criterio=" & cmbCriterio.SelectedItem.Value & "&DATRCBCHQ=" & txtDataInicial.Text & "' height=100% width=100% frameborder=0 ALLOWTRANSPARENCY scrolling=yes></iframe>"
            ElseIf cmbCriterio.SelectedValue = "3" Then '3 Período/Fornecedor
                If Not IsDate(txtDataInicial.Text) Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Data inicial não informada ou inválida.');</script>")
                    Exit Try
                End If
                If Not IsDate(txtDataFinal.Text) Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Data final não informada ou inválida.');</script>")
                    Exit Try
                End If
                If Date.Parse(txtDataInicial.Text) > Date.Parse(txtDataFinal.Text) Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Data inicial maior que data final.');</script>")
                    Exit Try
                End If
                If Not IsNumeric(ucFornecedor.CodFornecedor) Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Fornecedor não informado.');</script>")
                    Exit Try
                End If
                lblFrame.Text = "<iframe src='" & "ChequeListarGrid.aspx?criterio=" & cmbCriterio.SelectedItem.Value & "&DATRCBCHQInicial=" & txtDataInicial.Text & "&DATRCBCHQFinal=" & txtDataFinal.Text & "&CODFRN=" & ucFornecedor.CodFornecedor & "' height=100% width=100% frameborder=0 ALLOWTRANSPARENCY scrolling=yes></iframe>"
            ElseIf cmbCriterio.SelectedValue = "4" Then '3 Número
                If Not IsNumeric(txtCodigo.Text) Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Informe o número do cheque.');</script>")
                    Exit Try
                End If
                lblFrame.Text = "<iframe src='" & "ChequeListarGrid.aspx?criterio=" & cmbCriterio.SelectedItem.Value & "&NUMCHQ=" & txtCodigo.Text & "' height=100% width=100% frameborder=0 ALLOWTRANSPARENCY scrolling=yes></iframe>"
            End If
            GravarCriteriosDePesquisa(lblFrame.Text)

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmbCriterio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCriterio.SelectedIndexChanged



        txtDataInicial.Visible = False
        LblA.Visible = False
        txtDataFinal.Visible = False
        LblFornecedor.Visible = False
        ucFornecedor.Visible = False
        'cmbNomeFornecedor.Visible = False
        txtCodigo.Visible = False
        'btnBuscarFornecedor.Visible = False

        If cmbCriterio.SelectedValue = "1" Then     '1 Período
            txtDataInicial.Visible = True
            LblA.Visible = True
            txtDataFinal.Visible = True
            'limpa campo
            txtDataInicial.Text = String.Empty
            txtDataFinal.Text = String.Empty

        ElseIf cmbCriterio.SelectedValue = "2" Then '2 Data Previsão
            txtDataInicial.Visible = True
            'limpa campo
            txtDataInicial.Text = String.Empty

        ElseIf cmbCriterio.SelectedValue = "3" Then '3 Período/Fornecedor
            txtDataInicial.Visible = True
            LblA.Visible = True
            txtDataFinal.Visible = True
            LblFornecedor.Visible = True
            ucFornecedor.Visible = True
            'txtNomeFornecedor.Visible = True
            'btnBuscarFornecedor.Visible = True
            'limpa campos

            txtDataInicial.Text = String.Empty
            txtDataFinal.Text = String.Empty
            ucFornecedor.CodFornecedor = 0
            'txtCodigo.Text = String.Empty
            ' txtNomeFornecedor.Text = String.Empty
        ElseIf cmbCriterio.SelectedValue = "4" Then '3 Número
            txtCodigo.Visible = True
            'limpa campo
            txtCodigo.Text = String.Empty
        End If
    End Sub

    Private Sub GravarCriteriosDePesquisa(ByVal urlFrame As String)
        Dim criterios As New Collection
        With criterios
            .Add(urlFrame, "urlFrame")
            .Add(cmbCriterio.SelectedValue, "cmbCriterio")
            .Add(txtDataInicial.Text, "txtDataInicial")
            .Add(txtDataFinal.Text, "txtDataFinal")
            '.Add(txtCodigo.ValueDecimal.ToString, "txtCodigo")
            .Add(ucFornecedor.CodFornecedor, "ucFornecedor")
            '.Add(cmbNomeFornecedor.SelectedValue, "cmbNomeFornecedor")
        End With
        Session("ChequeListar") = criterios
    End Sub

    Private Sub RestaurarCriteriosDePesquisa(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim criterios As Collection

        If Not Session("ChequeListar") Is Nothing Then
            Try
                criterios = CType(Session("ChequeListar"), Collection)

                lblFrame.Text = CType(criterios.Item("urlFrame"), String)

                cmbCriterio.SelectedValue = CType(criterios.Item("cmbCriterio"), String)
                cmbCriterio_SelectedIndexChanged(sender, e)

                txtDataInicial.Text = CType(criterios.Item("txtDataInicial"), String)
                txtDataFinal.Text = CType(criterios.Item("txtDataFinal"), String)
                ucFornecedor.SelecionarFornecedor(CType(criterios.Item("ucFornecedor"), Decimal))

            Catch ex As Exception
            End Try
        End If
    End Sub

End Class