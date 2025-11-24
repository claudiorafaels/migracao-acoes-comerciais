Public Class EmpenhoFornecedorListar
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "
    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTransferenciaVerbaFornecedor1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor
        CType(Me.DatasetTransferenciaVerbaFornecedor1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTransferenciaVerbaFornecedor1
        '
        Me.DatasetTransferenciaVerbaFornecedor1.DataSetName = "DatasetTransferenciaVerbaFornecedor"
        Me.DatasetTransferenciaVerbaFornecedor1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTransferenciaVerbaFornecedor1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Div1 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents Espera As System.Web.UI.WebControls.Image
    Protected WithEvents lkbTodas As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lkbNenhuma As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblPaginacao As System.Web.UI.WebControls.Label
    Protected WithEvents DatasetTransferenciaVerbaFornecedor1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor
    Protected WithEvents GrdFluxo As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents cmbStatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnNovo As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cmbFiltro As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TRFluxo As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents TRStatus As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents txtFluxo As Infragistics.WebUI.WebDataInput.WebNumericEdit

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
        Try
            Dim NUMFLUAPV As Decimal
            NUMFLUAPV = Me.ReserverNovaChaveTransferenciaVerba
            HttpContext.Current.Response.Redirect("EmpenhoFornecedor.aspx?NUMFLUAPV=" & NUMFLUAPV.ToString)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub GrdFluxo_ItemCommand(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.UltraWebGrid.UltraWebGridCommandEventArgs) Handles GrdFluxo.ItemCommand
        Try
            'Detalhes
            If e.InnerCommandEventArgs.CommandName.Equals("btnLnkSelecionar") Then

                Dim NUMFLUAPV As Decimal

                NUMFLUAPV = CType(CType(e.ParentControl, Infragistics.WebUI.UltraWebGrid.CellItem).Cell.Row.Cells(1).Value(), Decimal)

                'Redireciona para página meio
                HttpContext.Current.Response.Redirect("EmpenhoFornecedor.aspx?NUMFLUAPV=" & NUMFLUAPV.ToString)

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
                .DataSource = Me.DatasetTransferenciaVerbaFornecedor1
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

            Dim NUMFLUAPV As Decimal = 0
            Dim CODFNC As Decimal = 0
            Dim TIPSTAFLUAPV As String = String.Empty

            'Definindo valor para os parametros
            Select Case cmbFiltro.SelectedValue
                Case "1" 'Fluxo
                    NUMFLUAPV = txtFluxo.ValueDecimal
                Case "2" 'Status
                    TIPSTAFLUAPV = cmbStatus.SelectedValue
                Case "3" 'Minha Aprovações
                    CODFNC = Controller.ObterFuncionarioLogadoSistema
            End Select

            'Pesquisa
            If cmbFiltro.SelectedValue = "3" Then
                Me.DatasetTransferenciaVerbaFornecedor1 = Controller.ObterMinhasAprovavoesEmTransferenciaVerbasFornecedor(0, CODFNC)
            Else
                Me.DatasetTransferenciaVerbaFornecedor1 = Controller.ObterTransferenciasVerbaFornecedorJOIN(NUMFLUAPV, CODFNC, TIPSTAFLUAPV)
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
        cmbStatus.Attributes.Add("OnBlur", Util.getJsFocus(Me.Page, CType(Me.btnPesquisar, WebControl), Util.tipoDeComponente.Outros))
    End Sub

#End Region

#Region "Metodos de Controle"

    Private Sub RecuperaEstado()
        Me.DatasetTransferenciaVerbaFornecedor1 = WSCAcoesComerciais.dsTransferenciaVerbaFornecedor
    End Sub

    Private Sub SalvaEstado()
        WSCAcoesComerciais.dsTransferenciaVerbaFornecedor = Me.DatasetTransferenciaVerbaFornecedor1
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
                        lblPaginacao.Text = "Pagina: " & .DisplayLayout.Pager.CurrentPageIndex.ToString & " - Registro: " & RegistroInicial.ToString & " a " & RegistroFinal.ToString & " de " & Me.DatasetTransferenciaVerbaFornecedor1.CADTRNVBAFRNJOIN.Rows.Count.ToString
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
    End Sub

    Private Function SalvarFiltroDePesquisa() As Boolean
        Try
            Dim valor As String = String.Empty
            valor &= cmbFiltro.SelectedValue & ","
            valor &= txtFluxo.Text & ","
            valor &= cmbStatus.SelectedValue

            Dim ck As New System.Web.HttpCookie("FiltroEmpenhoFornecedorListar", valor)
            ck.Expires = Now.AddDays(1)
            Response.Cookies.Add(ck)

            Return True
        Catch ex As Exception
            'Não tratar erro, se não conseguir gravar fica por isso mesmo
        End Try
    End Function

    Private Function RestaurarFiltroDePesquisa() As Boolean
        Try
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
            'cmbStatus.SelectedValue = valor(2)

            'MostraOuEscondeLinhaConformeSelecaoDeFiltro()

            Return True
        Catch ex As Exception
            'Não tratar erro, se não conseguir gravar fica por isso mesmo
        End Try
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

    Private Function ReserverNovaChaveTransferenciaVerba() As Decimal
        Dim result As Decimal
        result = Controller.ObterNovaChaveTransferenciaVerba

        'Dim dsTransferenciaVerbaFornecedor As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor
        Me.DatasetTransferenciaVerbaFornecedor1 = Controller.ObterTransferenciasVerbaFornecedor(0, String.Empty, 0, 0, 0, String.Empty)

        'Cria a linha
        Dim CADTRNVBAFRNRow As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow
        CADTRNVBAFRNRow = Me.DatasetTransferenciaVerbaFornecedor1.CADTRNVBAFRN.NewCADTRNVBAFRNRow
        'Dim CADTRNVBAFRNRow As wsAcoesComerciais.DatasetTransferenciaVerbaFornecedor.CADTRNVBAFRNRow
        'CADTRNVBAFRNRow = Me.DatasetTransferenciaVerbaFornecedor1.CADTRNVBAFRN.NewCADTRNVBAFRNRow

        'Transfere valores da tela para o row
        With CADTRNVBAFRNRow
            .NUMFLUAPV = result
            .TIPSTAFLUAPV = "0"
            .TIPDSNDSCBNFDSNTRN = 0
            .TIPALCVBAFRN = 3
            .CODFNC = Controller.ObterFuncionarioLogadoSistema
            .DESJSTTRNVBA = String.Empty
            .INDMESTRNFLU = 0
            .INDFLUTRNVBAMKT = 0
            .PERPSQSLDFRN = 0
        End With

        'Adiciona linha
        Me.DatasetTransferenciaVerbaFornecedor1.CADTRNVBAFRN.AddCADTRNVBAFRNRow(CADTRNVBAFRNRow)
        Controller.AtualizarTransferenciaVerbaFornecedor(Me.DatasetTransferenciaVerbaFornecedor1)

        Return result
    End Function

#End Region

End Class