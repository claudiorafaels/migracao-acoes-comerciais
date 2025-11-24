Public Class TipoTransferenciaVerbaListar
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "
    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblFrame As System.Web.UI.WebControls.Label
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnInserir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents cmbCriterio As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDescricao As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents cmbEmpenho As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodigo As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents Espera As System.Web.UI.WebControls.Image
    Protected WithEvents Div1 As System.Web.UI.HtmlControls.HtmlGenericControl
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
        'Carrega as Empenhos
        Util.carregarCmbEmpenho(Controller.ObterEmpenhos(String.Empty, String.Empty, String.Empty, 0, String.Empty), cmbEmpenho, Nothing)
        If (Not IsPostBack) Then
            RestaurarCriteriosDePesquisa(sender, e)
        End If
    End Sub

    Private Sub btnInserir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInserir.Click
        Controller.NavegarInserirTipoTransferenciaVerba()
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Try
            'Verifica o critério
            If Me.cmbCriterio.SelectedValue = "0" Then      'Nenhum
                lblFrame.Text = "<iframe src='" & "TipoTransferenciaVerbaListarGrid.aspx?criterio=" & cmbCriterio.SelectedItem.Value & "' height=100% width=100% frameborder=0 ALLOWTRANSPARENCY scrolling=yes></iframe>"
            ElseIf Me.cmbCriterio.SelectedValue = "1" Then  'Consulta por Descrição
                If txtDescricao.Text.Trim.Length < 3 Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Digite no mínimo 3 digitos para pesquisar.');</script>")
                    Exit Try
                End If
                lblFrame.Text = "<iframe src='" & "TipoTransferenciaVerbaListarGrid.aspx?criterio=" & cmbCriterio.SelectedItem.Value & "&DESTIPTRNVLRACOCMC=" & txtDescricao.Text & "' height=100% width=100% frameborder=0 ALLOWTRANSPARENCY scrolling=yes></iframe>"
            ElseIf cmbCriterio.SelectedValue = "2" Then 'Consulta por Código
                If Not IsNumeric(txtCodigo.Text) Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Informe o código.');</script>")
                    Exit Try
                End If
                lblFrame.Text = "<iframe src='" & "TipoTransferenciaVerbaListarGrid.aspx?criterio=" & cmbCriterio.SelectedItem.Value & "&CODTIPTRNVLRACOCMC=" & txtCodigo.Text & "' height=100% width=100% frameborder=0 ALLOWTRANSPARENCY scrolling=yes></iframe>"
            ElseIf cmbCriterio.SelectedValue = "3" Then 'Consulta por Empenho
                If cmbEmpenho.SelectedValue.Trim.Length = -1 Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('selecione o empenho para pesquisar.');</script>")
                    Exit Try
                End If
                lblFrame.Text = "<iframe src='" & "TipoTransferenciaVerbaListarGrid.aspx?criterio=" & cmbCriterio.SelectedItem.Value & "&TIPDSNDSCBNF=" & cmbEmpenho.SelectedValue & "' height=100% width=100% frameborder=0 ALLOWTRANSPARENCY scrolling=yes></iframe>"
            End If
            GravarCriteriosDePesquisa(lblFrame.Text)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub

    Private Sub cmbCriterio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCriterio.SelectedIndexChanged

        txtDescricao.Visible = False
        txtCodigo.Visible = False
        cmbEmpenho.Visible = False

        If cmbCriterio.SelectedValue = "1" Then     '1 Período
            txtDescricao.Visible = True
        ElseIf cmbCriterio.SelectedValue = "2" Then '2 Data Previsão
            txtCodigo.Visible = True
        ElseIf cmbCriterio.SelectedValue = "3" Then '3 Empenho
            cmbEmpenho.Visible = True
        End If

    End Sub
    Private Sub GravarCriteriosDePesquisa(ByVal urlFrame As String)
        Dim criterios As New Collection
        With criterios
            .Add(urlFrame, "urlFrame")
            .Add(cmbCriterio.SelectedValue, "cmbCriterio")
            .Add(txtDescricao.Text, "txtDescricao")
            .Add(txtCodigo.Text, "txtCodigo")
            .Add(cmbEmpenho.SelectedValue, "cmbEmpenho")

        End With
        Session("TipoTransferenciaVerbaListar") = criterios
    End Sub

    Private Sub RestaurarCriteriosDePesquisa(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim criterios As Collection

        If Not Session("TipoTransferenciaVerbaListar") Is Nothing Then
            Try
                criterios = CType(Session("TipoTransferenciaVerbaListar"), Collection)

                lblFrame.Text = CType(criterios.Item("urlFrame"), String)

                cmbCriterio.SelectedValue = CType(criterios.Item("cmbCriterio"), String)
                cmbCriterio_SelectedIndexChanged(sender, e)

                txtDescricao.Text = CType(criterios.Item("txtDescricao"), String)
                txtCodigo.Text = CType(criterios.Item(" txtCodigo"), String)
                cmbEmpenho.SelectedValue = CType(criterios.Item("cmbEmpenho"), String)

            Catch ex As Exception
            End Try
        End If
    End Sub
End Class