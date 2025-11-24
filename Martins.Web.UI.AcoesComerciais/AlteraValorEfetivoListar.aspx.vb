Public Class AlteraValorEfetivoListar
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
    Protected WithEvents txtCodigo As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents LblFornecedor As System.Web.UI.WebControls.Label
    Protected WithEvents Espera As System.Web.UI.WebControls.Image
    Protected WithEvents tdEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Div1 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents txtNomeFornecedor As System.Web.UI.WebControls.TextBox
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

#Region " Propriedades "

#End Region

#Region " Eventos "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim AcaoMmm As Int16
            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            End If
            If (Not IsPostBack) Then
                'tdEspera.Visible = False
                RestaurarCriteriosDePesquisa(sender, e)
                Session("DadosGridConsulta") = Nothing
            End If
            btnPesquisar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnInserir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInserir.Click
        Try
            Controller.NavegarInserirAlteraValorEfetivo()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
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
        Try
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
            'tdEspera.Visible = False
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#Region " Metodos"

    Private Sub GravarCriteriosDePesquisa(ByVal urlFrame As String)
        Dim criterios As New Collection
        With criterios
            .Add(urlFrame, "urlFrame")
            .Add(cmbCriterio.SelectedValue, "cmbCriterio")
            .Add(txtDataInicial.Text, "txtDataInicial")
            .Add(txtDataFinal.Text, "txtDataFinal")
            .Add(txtCodigo.Text, "txtCodigo")
            .Add(cmbNomeFornecedor.SelectedValue, "cmbNomeFornecedor")

        End With
        Session("AlteraValorEfetivoListar") = criterios
    End Sub

    Private Sub RestaurarCriteriosDePesquisa(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim criterios As Collection

        If Not Session("AlteraValorEfetivoListar") Is Nothing Then
            Try
                criterios = CType(Session("AlteraValorEfetivoListar"), Collection)

                lblFrame.Text = CType(criterios.Item("urlFrame"), String)
                cmbCriterio.SelectedValue = CType(criterios.Item("cmbCriterio"), String)
                cmbCriterio_SelectedIndexChanged(sender, e)

                txtDataInicial.Text = CType(criterios.Item("txtDataInicial"), String)
                txtDataFinal.Text = CType(criterios.Item("txtDataFinal"), String)
                txtCodigo.Text = CType(criterios.Item("txtCodigo"), String)
                cmbNomeFornecedor.SelectedValue = CType(criterios.Item("cmbNomeFornecedor"), String)

                If cmbNomeFornecedor.Items.Count > 0 Then
                    cmbNomeFornecedor.Visible = True
                    txtNomeFornecedor.Visible = False
                End If

                'tdEspera.Visible = True
            Catch ex As Exception
            End Try
        End If
    End Sub

#End Region

End Class