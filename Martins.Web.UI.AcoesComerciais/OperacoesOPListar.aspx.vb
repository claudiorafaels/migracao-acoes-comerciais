Public Class OperacoesOPListar
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
    Protected WithEvents cmbNomeFornecedor As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnBuscarFornecedor As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LblFornecedor As System.Web.UI.WebControls.Label
    Protected WithEvents Espera As System.Web.UI.WebControls.Image
    Protected WithEvents Div1 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents txtCodigo As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtNomeFornecedor As Infragistics.WebUI.WebDataInput.WebTextEdit
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

#Region "Persistencia de objetos"

#End Region

#Region "Busca Fornecedor"

    Private Sub btnBuscarFornecedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarFornecedor.Click
        Dim datasetFornecedor As wsAcoesComerciais.dataSetDivisaoFornecedor
        Dim flagMostrarCombo As Boolean

        If txtNomeFornecedor.Visible Then
            If txtNomeFornecedor.Text.Trim.Length < 3 Then
                Page.RegisterStartupScript("Alerta", "<script>alert('É obrigatório digitar no mínimo 3 caracteres do nome antes de pesquisar.');</script>")
                Exit Sub
            End If

            datasetFornecedor = Controller.ObterDivisoesFornecedor(1, txtNomeFornecedor.Text)
            If datasetFornecedor.T0100426.Rows.Count > 0 Then
                Util.carregarCmbDivisaoFornecedor(datasetFornecedor, cmbNomeFornecedor, Nothing)
                txtCodigo.Text = cmbNomeFornecedor.SelectedValue
                flagMostrarCombo = True
            Else
                Util.AdicionaJsAlert(Me.Page, "Registro não encontrado")
            End If

            With cmbNomeFornecedor
                .Visible = flagMostrarCombo
                .Enabled = flagMostrarCombo
                If flagMostrarCombo Then
                    .Width = System.Web.UI.WebControls.Unit.Parse("170px")
                Else
                    .Width = System.Web.UI.WebControls.Unit.Parse("0px")
                End If
            End With
            With txtNomeFornecedor
                .Visible = Not flagMostrarCombo
                .Enabled = Not flagMostrarCombo
                If Not flagMostrarCombo Then
                    .Width = System.Web.UI.WebControls.Unit.Parse("170px")
                Else
                    .Width = System.Web.UI.WebControls.Unit.Parse("0px")
                End If
            End With
        ElseIf cmbNomeFornecedor.Visible Then
            With cmbNomeFornecedor
                .Visible = False
                .Enabled = False
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
            End With
            With txtNomeFornecedor
                .Visible = True
                .Enabled = True
                .Width = System.Web.UI.WebControls.Unit.Parse("170px")
            End With
        End If
    End Sub

    Private Sub cmbNomeFornecedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNomeFornecedor.SelectedIndexChanged
        txtCodigo.Text = cmbNomeFornecedor.SelectedValue
    End Sub

    Private Sub txtCodigo_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtCodigo.ValueChange
        Dim datasetFornecedor As wsAcoesComerciais.dataSetDivisaoFornecedor
        Dim flagMostrarCombo As Boolean

        If Not (IsNumeric(txtCodigo.Text)) Then Exit Sub
        If Not (cmbCriterio.SelectedValue = "3") Then Exit Sub

        datasetFornecedor = Controller.ObterDivisaoFornecedor(1, CLng(txtCodigo.Text))
        If datasetFornecedor.T0100426.Rows.Count > 0 Then
            cmbNomeFornecedor.Items.Clear()
            For Contador As Integer = 0 To datasetFornecedor.T0100426.Count - 1
                cmbNomeFornecedor.Items.Add(datasetFornecedor.T0100426(Contador).NOMFRN.Trim)
                cmbNomeFornecedor.Items(Contador).Value = datasetFornecedor.T0100426(Contador).CODFRN.ToString
            Next
            flagMostrarCombo = True
        Else
            cmbNomeFornecedor.Items.Clear()
            txtNomeFornecedor.Text = String.Empty
            Util.AdicionaJsAlert(Me.Page, "Código de fornecedor inválido")
        End If

        With cmbNomeFornecedor
            .Visible = flagMostrarCombo
            .Enabled = flagMostrarCombo
            If flagMostrarCombo Then
                .Width = System.Web.UI.WebControls.Unit.Parse("170px")
            Else
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
            End If
        End With
        With txtNomeFornecedor
            .Visible = Not flagMostrarCombo
            .Enabled = Not flagMostrarCombo
            If Not flagMostrarCombo Then
                .Width = System.Web.UI.WebControls.Unit.Parse("170px")
            Else
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
            End If
        End With
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim AcaoMmm As Int16
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        If (Not IsPostBack) Then
            Session("DadosGridConsulta") = Nothing
            RestaurarCriteriosDePesquisa(sender, e)
        End If
        btnPesquisar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
    End Sub

    Private Sub btnInserir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInserir.Click
        Controller.NavegarInserirOperacoesOP()
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Try
            GravarCriteriosDePesquisa(lblFrame.Text)
            'tdEspera.Visible = True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)

        End Try
    End Sub

    Private Sub cmbCriterio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCriterio.SelectedIndexChanged

        txtDataInicial.Visible = False
        LblA.Visible = False
        txtDataFinal.Visible = False
        LblFornecedor.Visible = False
        txtCodigo.Visible = False
        cmbNomeFornecedor.Visible = False
        btnBuscarFornecedor.Visible = False

        If cmbCriterio.SelectedValue = "1" Then     '1 Período
            txtDataInicial.Visible = True
            LblA.Visible = True
            txtDataFinal.Visible = True
        ElseIf cmbCriterio.SelectedValue = "2" Then '2 Data Previsão
            txtDataInicial.Visible = True
        ElseIf cmbCriterio.SelectedValue = "3" Then '3 Período/Fornecedor
            txtDataInicial.Visible = True
            LblA.Visible = True
            txtDataFinal.Visible = True
            LblFornecedor.Visible = True
            txtCodigo.Visible = True
            cmbNomeFornecedor.Visible = True
            btnBuscarFornecedor.Visible = True
        ElseIf cmbCriterio.SelectedValue = "4" Then '4 Código
            txtCodigo.Visible = True
        End If

    End Sub

    Private Sub GravarCriteriosDePesquisa(ByVal urlFrame As String)
        Dim criterios As New Collection
        With criterios
            .Add(urlFrame, "urlFrame")
            .Add(cmbCriterio.SelectedValue, "cmbCriterio")
            .Add(txtDataInicial.Text, "txtDataInicial")
            .Add(txtDataFinal.Text, "txtDataFinal")
            .Add(txtCodigo.ValueDecimal.ToString, "txtCodigo")
            .Add(txtNomeFornecedor.Text, "txtNomeFornecedor")
            .Add(cmbNomeFornecedor.SelectedValue, "cmbNomeFornecedor")
        End With
        Session("OperacoesOPListar") = criterios
    End Sub

    Private Sub RestaurarCriteriosDePesquisa(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim criterios As Collection

        If Not Session("OperacoesOPListar") Is Nothing Then
            Try
                criterios = CType(Session("OperacoesOPListar"), Collection)

                lblFrame.Text = CType(criterios.Item("urlFrame"), String)

                cmbCriterio.SelectedValue = CType(criterios.Item("cmbCriterio"), String)
                cmbCriterio_SelectedIndexChanged(sender, e)

                txtDataInicial.Text = CType(criterios.Item("txtDataInicial"), String)
                txtDataFinal.Text = CType(criterios.Item("txtDataFinal"), String)
                txtCodigo.Text = CType(criterios.Item("txtCodigo"), String)
                cmbNomeFornecedor.SelectedValue = CType(criterios.Item("cmbNomeFornecedor"), String)

                If txtCodigo.ValueDecimal > 0 Then
                End If

                If cmbNomeFornecedor.Items.Count > 0 Then
                    cmbNomeFornecedor.Visible = True
                    txtNomeFornecedor.Visible = False
                End If

            Catch ex As Exception
            End Try
        End If
    End Sub

End Class