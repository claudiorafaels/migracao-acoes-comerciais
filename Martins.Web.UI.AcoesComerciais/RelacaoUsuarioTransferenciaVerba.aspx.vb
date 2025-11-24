Public Class RelacaoUsuarioTransferenciaVerba
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ddlTipoTransferencia As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlUsuario As System.Web.UI.WebControls.DropDownList
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
            Me.InicializaPagina()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            Me.SalvarDados()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("RelacaoUsuarioTransferenciaVerbaListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
    End Sub

#End Region

#Region " Metodos "

#Region " Métodos de Carga "

    Private Sub InicializaPagina()

        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If

        If (Not Me.IsPostBack) Then
            Me.CargaInicialDados()
        End If

        btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
    End Sub

    Private Sub CargaInicialDados()
        ' CARREGA OS DADOS INICIAIS
        Try
            Me.CarregaUsuarios()
            Me.CarregaTipoTransferencia()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub CarregaUsuarios()
        Util.carregarCmbUsuario(Controller.ObterUsuariosoCompra(0, 0, String.Empty), ddlUsuario, Nothing)
    End Sub

    Private Sub CarregaTipoTransferencia()
        Util.carregarCmbTipoTransferencia(Controller.ObterTiposTransferenciasValoresAcoesComerciais(Decimal.Zero, String.Empty, Decimal.Zero), ddlTipoTransferencia, New ListItem(String.Empty, String.Empty))
    End Sub

#End Region

#Region " Metodos de Regras de Negocio "

    Private Function ValidarDados() As Boolean
        If Not ddlTipoTransferencia.SelectedIndex > 0 Then
            Util.AdicionaJsAlert(Me.Page, "Inclusão não efetuada. Favor selecionar o tipo de transferência.")
            Util.AdicionaJsFocus(Me.Page, CType(ddlTipoTransferencia, WebControl))
            Return False
        End If

        If Not ddlUsuario.SelectedIndex > 0 Then
            Util.AdicionaJsAlert(Me.Page, "Inclusão não efetuada. Favor selecionar o usuário.")
            Util.AdicionaJsFocus(Me.Page, CType(ddlUsuario, WebControl))
            Return False
        End If
        Return True
    End Function

    Private Sub SalvarDados()
        Try
            If ValidarDados() Then
                Dim ds As New wsAcoesComerciais.DatasetTipoTransferenciaXUsuario
                Dim linha As wsAcoesComerciais.DatasetTipoTransferenciaXUsuario.T0135092Row

                linha = ds.T0135092.NewT0135092Row

                With linha
                    .NOMACSUSRSIS = ddlUsuario.SelectedValue
                    .CODTIPTRNVLRACOCMC = Convert.ToDecimal(ddlTipoTransferencia.SelectedValue)
                End With

                ds.EnforceConstraints = False
                ds.T0135092.AddT0135092Row(linha)

                Controller.AtualizarTipoTransferenciaXUsuario(ds)

                Me.Response.Redirect("RelacaoUsuarioTransferenciaVerbaListar.aspx")
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#End Region

End Class