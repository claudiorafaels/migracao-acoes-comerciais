Public Class RelacionamentoTransferenciaVerba
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
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents lblTip As System.Web.UI.WebControls.Label
    Protected WithEvents cmbCriterio As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlCelula As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlTipoTransferencia As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtPercentual As Infragistics.WebUI.WebDataInput.WebPercentEdit
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
            Response.Redirect("RelacionamentoTransferenciaVerbaListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
    End Sub

    Private Sub cmbCriterio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCriterio.SelectedIndexChanged
        Me.AlternaTipoRelacao()
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
            Me.CarregaCelulas()
            Me.CarregaTipoTransferencia()
            Me.InicializaEdicaoRelacionamento()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub CarregaCelulas()
        With ddlCelula
            If .Items.Count <= 1 Then
                Util.carregarCmbCelula(Controller.ObterCelulas(0, 0, 0, String.Empty), ddlCelula, New ListItem(String.Empty, String.Empty))
            End If
        End With
    End Sub

    Private Sub CarregaTipoTransferencia()
        With ddlTipoTransferencia
            If .Items.Count <= 1 Then
                Util.carregarCmbTipoTransferencia(Controller.ObterTiposTransferenciasValoresAcoesComerciais(Decimal.Zero, String.Empty, Decimal.Zero), ddlTipoTransferencia, New ListItem(String.Empty, String.Empty))
            End If
        End With
    End Sub

    Private Sub PreencheDRRelacionamento(ByRef dr As Object)
        ' CELULA
        If cmbCriterio.SelectedValue.Equals("1") Then
            With CType(dr, wsAcoesComerciais.DatasetTipoTransferenciaXDivisaoCompras.T0135041Row)
                .CODTIPTRNVLRACOCMC = Convert.ToDecimal(ddlTipoTransferencia.SelectedValue)
                .CODDIVCMP = Convert.ToDecimal(ddlCelula.SelectedValue)
                .PERTRNVLRACOCMC = txtPercentual.ValueDecimal
            End With
            ' FORNECEDOR
        ElseIf cmbCriterio.SelectedValue.Equals("2") Then
            With CType(dr, wsAcoesComerciais.DatasetTipoTransferenciaXFornecedor.T0135050Row)
                .CODTIPTRNVLRACOCMC = Convert.ToDecimal(ddlTipoTransferencia.SelectedValue)
                Me.AlternaTipoRelacao()
                .CODFRN = ucFornecedor.CodFornecedor
                .PERTRNVLRACOCMC = txtPercentual.ValueDecimal
            End With
        End If
    End Sub

    Private Sub InicializaEdicaoRelacionamento()
        If Not Me.Request.QueryString.Item("dsIndex") Is Nothing AndAlso _
            Not Me.Request.QueryString.Item("criterio") Is Nothing Then
            cmbCriterio.SelectedValue = Me.Request.QueryString.Item("criterio").Trim
            ' celula
            If Me.Request.QueryString.Item("criterio").Trim.Equals("1") Then
                Me.PreencheControles(WSCAcoesComerciais.dsTipoTransferenciaXDivisaoCompras.T0135041.Item(Convert.ToInt32(Me.Request.QueryString.Item("dsIndex"))))
            ElseIf Me.Request.QueryString.Item("criterio").Trim.Equals("2") Then
                ' fornecedor
                Me.PreencheControles(WSCAcoesComerciais.dsTipoTransferenciaXFornecedor.T0135050.Item(Convert.ToInt32(Me.Request.QueryString.Item("dsIndex"))))
            End If
        Else
            WSCAcoesComerciais.dsTipoTransferenciaXDivisaoCompras = New wsAcoesComerciais.DatasetTipoTransferenciaXDivisaoCompras
            WSCAcoesComerciais.dsTipoTransferenciaXFornecedor = New wsAcoesComerciais.DatasetTipoTransferenciaXFornecedor
        End If
    End Sub

#End Region

#Region " Metodos de Web Controles "

    Private Sub AlternaTipoRelacao()
        If cmbCriterio.SelectedValue.Equals("1") Then
            ucFornecedor.Visible = False
            ddlCelula.Visible = True
            lblTip.Text = "Célula"
        ElseIf cmbCriterio.SelectedValue.Equals("2") Then
            ucFornecedor.Visible = True
            ddlCelula.Visible = False
            lblTip.Text = "Fornecedor"
        End If
    End Sub

    Private Sub PreencheControles(ByRef dr As DataRow)
        ' CELULA
        If cmbCriterio.SelectedValue.Equals("1") Then
            With CType(dr, wsAcoesComerciais.DatasetTipoTransferenciaXDivisaoCompras.T0135041Row)
                ddlTipoTransferencia.SelectedValue = .CODTIPTRNVLRACOCMC.ToString()
                Me.AlternaTipoRelacao()
                ddlCelula.SelectedValue = .CODDIVCMP.ToString()
                txtPercentual.Value = .PERTRNVLRACOCMC
                ' VAMOS DELETAR ESSA LINHA, POIS NAO TEM EDICAO EFETIVA AE SIM DELETE E INSERT
                .Delete()
            End With
            ' FORNECEDOR
        ElseIf cmbCriterio.SelectedValue.Equals("2") Then
            With CType(dr, wsAcoesComerciais.DatasetTipoTransferenciaXFornecedor.T0135050Row)
                ddlTipoTransferencia.SelectedValue = .CODTIPTRNVLRACOCMC.ToString()
                Me.AlternaTipoRelacao()
                ucFornecedor.SelecionarFornecedor(.CODFRN)
                txtPercentual.Value = .PERTRNVLRACOCMC
                ' VAMOS DELETAR ESSA LINHA, POIS NAO TEM EDICAO EFETIVA AE SIM DELETE E INSERT
                .Delete()
            End With
        End If
    End Sub

#End Region

#Region " Metodos de Regras de Negocio "

    Private Function ValidarDados() As Boolean
        If Not ddlTipoTransferencia.SelectedIndex > 0 Then
            Util.AdicionaJsAlert(Me.Page, "Inclusão não efetuada. Favor informar o tipo de transferência.")
            Util.AdicionaJsFocus(Me.Page, CType(ddlTipoTransferencia, WebControl))
            Return False
        End If
        If cmbCriterio.SelectedValue.Equals("1") Then
            If Not ddlCelula.SelectedIndex > 0 Then
                Util.AdicionaJsAlert(Me.Page, "Inclusão não efetuada. Favor informar a célula.")
                Util.AdicionaJsFocus(Me.Page, CType(ddlCelula, WebControl))
                Return False
            End If
        ElseIf cmbCriterio.SelectedValue.Equals("2") Then
            If ucFornecedor.CodFornecedor <= 0 Then
                Util.AdicionaJsAlert(Me.Page, "Inclusão não efetuada. Favor informar o Fornecedor.")
                Util.AdicionaJsFocus(Me.Page, CType(ucFornecedor.FindControl("txtCodigo"), WebControl))
                Return False
            End If
        End If
        If txtPercentual.Value Is String.Empty Then
            Util.AdicionaJsAlert(Me.Page, "Inclusão não efetuada. Favor informar o percentual de transferência.")
            Util.AdicionaJsFocus(Me.Page, CType(txtPercentual, WebControl))
            Return False
        End If
        Return True
    End Function

    Private Sub SalvarDados()
        Try
            If ValidarDados() Then
                ' CELULA
                If cmbCriterio.SelectedValue.Equals("1") Then
                    Me.SalvarDadosCelula()
                ElseIf cmbCriterio.SelectedValue.Equals("2") Then
                    ' FORNECEDOR
                    Me.SalvarDadosFornecedor()
                End If

                Me.Response.Redirect("RelacionamentoTransferenciaVerbaListar.aspx")
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub SalvarDadosCelula()
        Dim dr As wsAcoesComerciais.DatasetTipoTransferenciaXDivisaoCompras.T0135041Row
        dr = WSCAcoesComerciais.dsTipoTransferenciaXDivisaoCompras.T0135041.NewT0135041Row()
        Me.PreencheDRRelacionamento(CType(dr, Object))
        WSCAcoesComerciais.dsTipoTransferenciaXDivisaoCompras.T0135041.AddT0135041Row(dr)

        Controller.AtualizarTipoTransferenciaXDivisaoCompras(WSCAcoesComerciais.dsTipoTransferenciaXDivisaoCompras)
    End Sub

    Private Sub SalvarDadosFornecedor()
        Dim dr As wsAcoesComerciais.DatasetTipoTransferenciaXFornecedor.T0135050Row
        dr = WSCAcoesComerciais.dsTipoTransferenciaXFornecedor.T0135050.NewT0135050Row()
        Me.PreencheDRRelacionamento(CType(dr, Object))
        WSCAcoesComerciais.dsTipoTransferenciaXFornecedor.T0135050.AddT0135050Row(dr)

        Controller.AtualizarTipoTransferenciaXFornecedor(WSCAcoesComerciais.dsTipoTransferenciaXFornecedor)
    End Sub

#End Region

#End Region

End Class