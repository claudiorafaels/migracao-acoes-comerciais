Public Class RelatorioAcordoParaDeduction
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Associado As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Efetivado As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents cmbCelula As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmbFormaPagamento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents btnImprimir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtDatFinal As Infragistics.WebUI.WebSchedule.WebDateChooser
    Protected WithEvents txtDatInicial As Infragistics.WebUI.WebSchedule.WebDateChooser
    Protected WithEvents btnVisualizar As System.Web.UI.WebControls.LinkButton
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

#Region " Eventos "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            End If
            btnImprimir.Attributes.Add("OnClick", "javascript:mostraAndamento()")
            btnVisualizar.Attributes.Add("OnClick", "javascript:mostraAndamento()")

            If (Not IsPostBack) Then
                ucFornecedor.widthNome = System.Web.UI.WebControls.Unit.Parse("280px")
                carregarCmbCelula()
                carregarCmbFormaPagamento()
                'Data inicial e final = hoje
                txtDatInicial.Value = Date.Today
                txtDatFinal.Value = Date.Today
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub Associado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Associado.CheckedChanged
        If Associado.Checked = True Then
            Efetivado.Checked = False
        End If
    End Sub

    Private Sub Efetivado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Efetivado.CheckedChanged
        If Efetivado.Checked = True Then
            Associado.Checked = False
        End If
    End Sub

#End Region

#Region " Metodos "

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Response.Redirect("Principal.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = String.Empty

        Try
            Validar = True
            'período 
            If Not (IsDate(txtDatInicial.Text)) Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "Data Inicial do Periodo não informada ou inválida"
            ElseIf Not (IsDate(txtDatFinal.Text)) Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "data final do período não informada ou inválida"
            ElseIf Date.Parse(txtDatInicial.Text) > Date.Parse(txtDatFinal.Text) Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "data inicial do período maior que data final"
            End If
            'Tipo do relatório
            If (Not Associado.Checked) And (Not Efetivado.Checked) Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "deve - se checar pelo menos um(1) entre associado e efetivado"
            End If

            If mensagemErro.Trim() <> String.Empty Then
                Page.RegisterStartupScript("Alerta", "<script>alert('" & (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1) & "');</script>")
                Return False
            End If
            lblErro.Visible = False
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            If Validar() = False Then
                Exit Sub
            End If

            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = True

            If Associado.Checked = True Then
                ImprimirAssociado()
            End If

            If Efetivado.Checked = True Then
                ImprimirEfetivado()
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            If Validar() = False Then
                Exit Sub
            End If

            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = False

            If Associado.Checked = True Then
                ImprimirAssociado()
            End If

            If Efetivado.Checked = True Then
                ImprimirEfetivado()
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ImprimirEfetivado()
        Dim htFormulas As New Hashtable
        Dim ChkEfetivadoEnt As Integer = 0
        Dim ChkAssociadoEnt As Integer = 0

        If Associado.Checked Then ChkAssociadoEnt = 1
        If Efetivado.Checked Then ChkAssociadoEnt = 1

        ' Obter dados do relatório e guardar na seção
        WSCAcoesComerciais.dsRelatorioAcordoParaDeduction = Controller.ObterRelatorioAcordoParaDeduction(CInt("3"), Convert.ToInt32(ucFornecedor.CodFornecedor), Integer.Parse(cmbCelula.SelectedValue), Integer.Parse(cmbFormaPagamento.SelectedValue), Convert.ToDateTime(txtDatInicial.Value), Convert.ToDateTime(txtDatFinal.Value), ChkEfetivadoEnt, ChkAssociadoEnt)

        'Guarda as Formulas na seção
        With htFormulas
            .Add("Periodo", "'" & "Período : " & Convert.ToDateTime(txtDatInicial.Value).ToString("dd/MM/yyyy") & "  à " & Convert.ToDateTime(txtDatFinal.Value).ToString("dd/MM/yyyy") & "'")
        End With
        WSCAcoesComerciais.hashtableFormulasCrystal = htFormulas

        ' Guarda o nome do relatório na seção
        WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "cby002z5a.rpt"

        'Chama o visualizador de relatório
        Page.RegisterStartupScript("cby002z5a", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 768,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

    Private Sub ImprimirAssociado()
        Dim htFormulas As New Hashtable
        Dim ChkEfetivadoEnt As Integer = 0
        Dim ChkAssociadoEnt As Integer = 0

        If Associado.Checked Then ChkAssociadoEnt = 1
        If Efetivado.Checked Then ChkAssociadoEnt = 1

        ' Obter dados do relatório e guardar na seção
        WSCAcoesComerciais.dsRelatorioAcordoParaDeduction = Controller.ObterRelatorioAcordoParaDeduction(CInt("2"), Convert.ToInt32(ucFornecedor.CodFornecedor), Integer.Parse(cmbCelula.SelectedValue), Integer.Parse(cmbFormaPagamento.SelectedValue), Convert.ToDateTime(txtDatInicial.Value), Convert.ToDateTime(txtDatFinal.Value), ChkEfetivadoEnt, ChkAssociadoEnt)

        'Guarda as Formulas na seção
        With htFormulas
            .Add("Periodo", "'" & "Período : " & Convert.ToDateTime(txtDatInicial.Value).ToString("dd/MM/yyyy") & "  à " & Convert.ToDateTime(txtDatFinal.Value).ToString("dd/MM/yyyy") & "'")
        End With
        WSCAcoesComerciais.hashtableFormulasCrystal = htFormulas

        ' Guarda o nome do relatório na seção
        WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "cby002z5.rpt"

        'Chama o visualizador de relatório
        Page.RegisterStartupScript("cby002z5", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 768,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

    Private Sub carregarCmbCelula()
        Util.carregarCmbCelula(Controller.ObterCelulas(0, 0, 0, String.Empty), cmbCelula, New ListItem("", "0"))
    End Sub

    Private Sub carregarCmbFormaPagamento()
        Util.carregarCmbFormaPagamento(Controller.ObterFormasPagamento(String.Empty, 1), cmbFormaPagamento, New ListItem(String.Empty, "0"))
    End Sub

#End Region

End Class