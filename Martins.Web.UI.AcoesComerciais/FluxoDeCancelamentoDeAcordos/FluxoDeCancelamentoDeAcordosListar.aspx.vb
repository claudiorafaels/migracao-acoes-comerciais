Public Class FluxoDeCancelamentoDeAcordosListar
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "
    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetFluxoCancelamentoAcordo1 = New Martins.Web.UI.AcoesComerciais.wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo
        CType(Me.DatasetFluxoCancelamentoAcordo1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetFluxoCancelamentoAcordo1
        '
        Me.DatasetFluxoCancelamentoAcordo1.DataSetName = "DatasetFluxoCancelamentoAcordo"
        Me.DatasetFluxoCancelamentoAcordo1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetFluxoCancelamentoAcordo1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Div1 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents Espera As System.Web.UI.WebControls.Image
    Protected WithEvents lkbTodas As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lkbNenhuma As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblPaginacao As System.Web.UI.WebControls.Label
    Protected WithEvents GrdFluxo As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents btnNovo As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cmbFiltro As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TRFluxo As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents TRStatus As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents txtFluxo As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents DatasetFluxoCancelamentoAcordo1 As Martins.Web.UI.AcoesComerciais.wsFluxoDeCancelamentoDeAcordos.DatasetFluxoCancelamentoAcordo
    Protected WithEvents cmbCODSTAAPV As System.Web.UI.WebControls.DropDownList

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
            If (Not IsPostBack) Then
                Me.IniciarPagina()
            Else
                Me.RecuperaEstado()
            End If
            carregarJavaScript()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        Me.SalvaEstado()
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Try
            Me.CarregarGrdFluxo()
            Me.SalvarFiltroDePesquisa()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNovo.Click
        Response.Redirect("FluxoDeCancelamentoDeAcordos.aspx")
    End Sub

    Private Sub GrdFluxo_ItemCommand(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.UltraWebGrid.UltraWebGridCommandEventArgs) Handles GrdFluxo.ItemCommand
        Try
            'Detalhes
            If e.InnerCommandEventArgs.CommandName.Equals("btnLnkSelecionar") Then

                Dim NUMPEDCNCACOCMC As Decimal
                Dim CODFRN As Decimal


                NUMPEDCNCACOCMC = CType(CType(e.ParentControl, Infragistics.WebUI.UltraWebGrid.CellItem).Cell.Row.Cells(1).Value(), Decimal)
                CODFRN = CType(CType(e.ParentControl, Infragistics.WebUI.UltraWebGrid.CellItem).Cell.Row.Cells(5).Value(), Decimal)

                'Redireciona para página meio
                Response.Redirect("FluxoDeCancelamentoDeAcordos.aspx?NUMPEDCNCACOCMC=" & NUMPEDCNCACOCMC.ToString & "&CODFRN=" & CODFRN.ToString)

            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub GrdFluxo_PageIndexChanged(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.UltraWebGrid.PageEventArgs)
        Try
            Me.RecuperaEstado()
            With Me.GrdFluxo
                If Controller.PageSize > 0 Then
                    .DisplayLayout.Pager.AllowPaging = True
                    .DisplayLayout.Pager.Alignment = Infragistics.WebUI.UltraWebGrid.PagerAlignment.Center
                    .DisplayLayout.Pager.PageSize = Controller.PageSize
                End If
                .DisplayLayout.Pager.CurrentPageIndex = e.NewPageIndex
                .DataSource = Me.DatasetFluxoCancelamentoAcordo1
                .DataBind()
                AtualizarLabelPaginacao()
            End With
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmbFiltro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFiltro.SelectedIndexChanged
        Try
            MostraOuEscondeLinhaConformeSelecaoDeFiltro()
            Util.AdicionaJsFocus(Me.Page, Me.cmbFiltro)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmbCODSTAAPV_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCODSTAAPV.SelectedIndexChanged
        Try
            GrdFluxo.Rows.Clear()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub
#End Region

#Region "Metodos de Carga"

    Private Sub IniciarPagina()
        MostraOuEscondeLinhaConformeSelecaoDeFiltro()
        If RestaurarFiltroDePesquisa() Then
            Me.CarregarGrdFluxo()
        End If
    End Sub

    Private Sub CarregarGrdFluxo()
        Try
            If Not ValidarFiltros() Then
                Exit Sub
            End If

            Dim NUMPEDCNCACOCMC As Decimal = 0
            Dim CODFRN As Decimal = 0
            Dim CODSTAAPV As Decimal = 5

            'Definindo valor para os parametros
            Select Case cmbFiltro.SelectedValue
                Case "1" 'Fluxo
                    NUMPEDCNCACOCMC = txtFluxo.ValueDecimal

                Case "2" 'Status
                    CODSTAAPV = CType(cmbCODSTAAPV.SelectedValue, Decimal)

                Case "3" 'Minha Aprovações
                    CODFRN = Controller.ObterFuncionarioLogadoSistema
            End Select

            'Pesquisa
            If cmbFiltro.SelectedValue = "3" Then
                Me.DatasetFluxoCancelamentoAcordo1 = Controller.ObterMinhasAprovavoesEmFluxoDeCancelamentoDeAcordos(NUMPEDCNCACOCMC, CODFRN)
            Else
                Me.DatasetFluxoCancelamentoAcordo1 = Controller.ObterFluxoCancelamentoAcordoPesquisa(CODFRN, CODSTAAPV, NUMPEDCNCACOCMC, 0)
            End If

            With Me.GrdFluxo
                If Controller.PageSize > 0 Then
                    .DisplayLayout.Pager.AllowPaging = True
                    .DisplayLayout.Pager.Alignment = Infragistics.WebUI.UltraWebGrid.PagerAlignment.Center
                    .DisplayLayout.Pager.PageSize = Controller.PageSize
                End If
                .DataBind()
            End With
            Me.AtualizarLabelPaginacao()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub

    Private Sub carregarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        btnPesquisar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        cmbCODSTAAPV.Attributes.Add("OnBlur", Util.getJsFocus(Me.Page, CType(Me.btnPesquisar, WebControl), Util.tipoDeComponente.Outros))
    End Sub

#End Region

#Region "Metodos de Controle"

    Private Sub RecuperaEstado()
        Me.DatasetFluxoCancelamentoAcordo1 = WSCAcoesComerciais.dsFluxoCancelamento
    End Sub

    Private Sub SalvaEstado()
        WSCAcoesComerciais.dsFluxoCancelamento = Me.DatasetFluxoCancelamentoAcordo1
    End Sub

    Private Sub AtualizarLabelPaginacao()
        Try
            lblPaginacao.Visible = False
            If Controller.PageSize > 0 Then
                With Me.GrdFluxo
                    If .Rows.Count > 1 Then
                        Dim RegistroInicial As Integer = ((.DisplayLayout.Pager.CurrentPageIndex - 1) * .DisplayLayout.Pager.PageSize) + 1
                        Dim RegistroFinal As Integer = RegistroInicial + .Rows.Count - 1
                        lblPaginacao.Visible = True
                        lblPaginacao.Text = "Pagina: " & .DisplayLayout.Pager.CurrentPageIndex.ToString & " - Registro: " & RegistroInicial.ToString & " a " & RegistroFinal.ToString & " de " & Me.DatasetFluxoCancelamentoAcordo1.T0154038Pesquisa.Rows.Count.ToString
                    End If
                End With
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub MostraOuEscondeLinhaConformeSelecaoDeFiltro()
        Select Case cmbFiltro.SelectedValue
            Case "1" 'Fluxo
                Me.TRFluxo.Visible = True
                Me.TRStatus.Visible = False
            Case "2" 'Status
                Me.TRFluxo.Visible = False
                Me.TRStatus.Visible = True
            Case "3" 'Minha Aprovações
                Me.TRFluxo.Visible = False
                Me.TRStatus.Visible = False
        End Select
        GrdFluxo.Rows.Clear()
    End Sub

    Private Function SalvarFiltroDePesquisa() As Boolean

        Dim valor As String = String.Empty
        valor &= cmbFiltro.SelectedValue & ","
        valor &= txtFluxo.Text & ","
        valor &= cmbCODSTAAPV.SelectedValue

        Dim ck As New System.Web.HttpCookie("FiltroEmpenhoFornecedorListar", valor)
        ck.Expires = Now.AddDays(1)
        Response.Cookies.Add(ck)

        Return True
    End Function

    Private Function RestaurarFiltroDePesquisa() As Boolean

        'Elisangela solicitou para trazer sempre a oção minhas aprovações
        'antes o sistema guardava um cookie a última opção do usuário
        'essa funcionalidade está comentada
        cmbFiltro.SelectedValue() = "3"
        MostraOuEscondeLinhaConformeSelecaoDeFiltro()


        'If Request.Cookies("FiltroEmpenhoFornecedorListar") Is Nothing Then
        '    Return False
        'End If

        'Dim valor() As String = Split(Request.Cookies("FiltroEmpenhoFornecedorListar").Value.ToString, ",")

        'cmbFiltro.SelectedValue = valor(0)
        'txtFluxo.Text = valor(1)
        'cmbCODSTAAPV.SelectedValue = valor(2)

        'MostraOuEscondeLinhaConformeSelecaoDeFiltro()

        Return True
        
    End Function

#End Region

#Region "Metodos de Regra"

    Private Function ValidarFiltros() As Boolean
        Select Case cmbFiltro.SelectedValue
            Case "1" 'Fluxo
                If txtFluxo.ValueDecimal = 0 Then
                    Util.AdicionaJsAlert(Me.Page, "Informe o número do fluxo", True)
                    Return False
                End If
            Case "2" 'Status
            Case "3" 'Minha Aprovações
        End Select
        Return True
    End Function

#End Region

End Class