Public Class MktExtraAcordoListar
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "
    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetMarketinExtraAcordo1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetMarketinExtraAcordo
        CType(Me.DatasetMarketinExtraAcordo1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetMarketinExtraAcordo1
        '
        Me.DatasetMarketinExtraAcordo1.DataSetName = "DatasetMarketinExtraAcordo"
        Me.DatasetMarketinExtraAcordo1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetMarketinExtraAcordo1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents Div1 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents cmbCriterio As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TRCodigo As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents TRDescricao As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnNovo As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetMarketinExtraAcordo1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetMarketinExtraAcordo
    Protected WithEvents grdMarketingExtraAcordo As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents chkDATDSTMKTEXAARD As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtCODFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtNOMFRN As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents btnDesativar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lkbTodas As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lkbNenhuma As System.Web.UI.WebControls.LinkButton


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
            If IsPostBack Then
                Me.RecuperaEstado()
            Else
                Me.IniciarPagina()
            End If
            carregarJavaScript()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNovo.Click
        Try
            Response.Redirect("MktExtraAcordoManter.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Try
            Dim NOMFRN As String = String.Empty
            Dim CODFRN As Decimal = 0
            Dim DATDSTMKTEXAARD As Decimal = 0

            'CODIGO
            If cmbCriterio.SelectedValue = "1" Then
                CODFRN = txtCODFRN.ValueDecimal
                'DESCRICAO
            ElseIf cmbCriterio.SelectedValue = "2" Then
                NOMFRN = txtNOMFRN.Text
            End If

            If chkDATDSTMKTEXAARD.Checked Then
                DATDSTMKTEXAARD = 1
            End If

            CarregaGrid(CODFRN, NOMFRN, DATDSTMKTEXAARD)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmbCriterio_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCriterio.SelectedIndexChanged
        Try
            If CType(cmbCriterio.SelectedValue, Decimal) = 0 Then
                TRCodigo.Visible = False
                TRDescricao.Visible = False
            ElseIf CType(cmbCriterio.SelectedValue, Decimal) = 1 Then
                TRCodigo.Visible = True
                TRDescricao.Visible = False
            ElseIf CType(cmbCriterio.SelectedValue, Decimal) = 2 Then
                TRCodigo.Visible = False
                TRDescricao.Visible = True
            End If
            txtCODFRN.Text = String.Empty
            txtNOMFRN.Text = String.Empty
            grdMarketingExtraAcordo.Rows.Clear()
            grdMarketingExtraAcordo.Visible = False
            btnDesativar.Visible = False
            lkbNenhuma.Visible = False
            lkbTodas.Visible = False
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub

    Private Sub lkbTodas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkbTodas.Click
        Try
            For Each row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdMarketingExtraAcordo.Rows
                row.Cells.Item(0).Value = True
            Next
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub lkbNenhuma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkbNenhuma.Click
        Try
            For Each row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdMarketingExtraAcordo.Rows
                row.Cells.Item(0).Value = False
            Next
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnDesativar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesativar.Click
        Try
            DesativaExtraAcordo()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub grdMarketingExtraAcordo_ItemCommand(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.UltraWebGridCommandEventArgs) Handles grdMarketingExtraAcordo.ItemCommand
        Try
            'Detalhes
            If e.InnerCommandEventArgs.CommandName.Equals("btnEditar") Then

                Dim CODFRN As Decimal
                Dim DATCADMKTEXAARD As Date
                Dim DATINIAPUMKTEXAARD As Date

                CODFRN = CType(CType(e.ParentControl, Infragistics.WebUI.UltraWebGrid.CellItem).Cell.Row.Cells.FromKey("CODFRN").Value, Decimal)
                DATCADMKTEXAARD = CType(CType(e.ParentControl, Infragistics.WebUI.UltraWebGrid.CellItem).Cell.Row.Cells.FromKey("DATCADMKTEXAARD").Value, Date)
                DATINIAPUMKTEXAARD = CType(CType(e.ParentControl, Infragistics.WebUI.UltraWebGrid.CellItem).Cell.Row.Cells.FromKey("DATINIAPUMKTEXAARD").Value, Date)

                If DATINIAPUMKTEXAARD.Date > Date.Now Then
                    'Redireciona para página meio
                    Response.Redirect("MktExtraAcordoManter.aspx?CODFRN=" & CODFRN.ToString & "&DATCADMKTEXAARD=" & DATCADMKTEXAARD.ToString)
                ElseIf DATINIAPUMKTEXAARD.Date <= Date.Now.Date Then
                    If DATCADMKTEXAARD.Date = Date.Now.Date Then
                        'Redireciona para página meio
                        Response.Redirect("MktExtraAcordoManter.aspx?CODFRN=" & CODFRN.ToString & "&DATCADMKTEXAARD=" & DATCADMKTEXAARD.ToString)
                    Else
                        Util.AdicionaJsAlert(Me.Page, "Registro não pode ser alterado.Para fazer a alteração é necessário" & vbCrLf & "desabilitar este registro e criar um novo percentual.", True)
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub
#End Region

#Region "Métodos de Carga"

    Private Sub IniciarPagina()
        TRCodigo.Visible = False
        TRDescricao.Visible = False
        grdMarketingExtraAcordo.Visible = False

        If Not Request.QueryString("CODFRN") Is Nothing Then
            Dim CODFRN As Decimal = CType(Request.QueryString("CODFRN"), Decimal)
            Dim DATDSTMKTEXAARD As Decimal = CType(Request.QueryString("DATDSTMKTEXAARD"), Decimal)
            CarregaGrid(CODFRN, String.Empty, DATDSTMKTEXAARD)
        End If
    End Sub

    Private Sub carregarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        btnPesquisar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        btnDesativar.Attributes.Add("OnClick", "return confirm('Você confirma a desativação do(s) registro(s)?');")
    End Sub

    Public Sub CarregaGrid(ByVal CODFRN As Decimal, ByVal NOMFRN As String, ByVal DATDSTMKTEXAARD As Decimal)

        Me.DatasetMarketinExtraAcordo1 = Controller.ObterMarketingExtraAcordoPesquisa(CODFRN, NOMFRN, DATDSTMKTEXAARD)

        If Me.DatasetMarketinExtraAcordo1.RLCFRNPERMKTEXAARDPesquisa.Rows.Count > 0 Then
            grdMarketingExtraAcordo.DataBind()
            grdMarketingExtraAcordo.Visible = True
            btnDesativar.Visible = True
            lkbNenhuma.Visible = True
            lkbTodas.Visible = True
        Else
            Util.AdicionaJsAlert(Me.Page, "Registro(s) não encontrado(s)!", False)
            grdMarketingExtraAcordo.Rows.Clear()
            grdMarketingExtraAcordo.Visible = False
            btnDesativar.Visible = False
            lkbNenhuma.Visible = False
            lkbTodas.Visible = False
        End If
    End Sub

    Public Function ValidaSelecao() As Boolean
        For Each row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdMarketingExtraAcordo.Rows
            If CType(row.Cells.Item(0).Value, Boolean) = True Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub DesativaExtraAcordo()
        Dim CODFRN As Decimal
        Dim DATCADMKTEXAARD As Date
        Dim CODFRNDesativado As String = String.Empty
        If ValidaSelecao() Then
            For Each row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdMarketingExtraAcordo.Rows
                If CType(row.Cells.Item(0).Value, Boolean) = True Then
                    CODFRN = CType(row.GetCellValue(Me.grdMarketingExtraAcordo.Columns.FromKey("CODFRN")), Decimal)
                    DATCADMKTEXAARD = CType(row.GetCellValue(Me.grdMarketingExtraAcordo.Columns.FromKey("DATCADMKTEXAARD")), Date)
                    Me.DatasetMarketinExtraAcordo1.Merge(Controller.ObterMarketingExtraAcordoPorChave(CODFRN, DATCADMKTEXAARD))
                End If
            Next

            For Each linha As wsAcoesComerciais.DatasetMarketinExtraAcordo.RLCFRNPERMKTEXAARDRow In Me.DatasetMarketinExtraAcordo1.RLCFRNPERMKTEXAARD
                If linha.IsDATDSTMKTEXAARDNull Then
                    linha.DATDSTMKTEXAARD = Date.Now
                Else
                    If CODFRNDesativado = String.Empty Then
                        CODFRNDesativado = linha.CODFRN.ToString
                    Else
                        CODFRNDesativado &= ", " & linha.CODFRN
                    End If
                End If
            Next

            If CODFRNDesativado = String.Empty Then
                Controller.AtualizarMarketingExtraAcordo(Me.DatasetMarketinExtraAcordo1)
                Util.AdicionaJsAlert(Me.Page, "Registro(s) desativado(s) com sucesso!", True)
                btnPesquisar_Click(Nothing, Nothing)
            Else
                Util.AdicionaJsAlert(Me.Page, "Existe(m) registros selecionados que já estão desativados: " & CODFRNDesativado, True)
                Exit Sub
            End If
        Else
            Util.AdicionaJsAlert(Me.Page, "Selecione o registro que deseja desativar!", True)
        End If

    End Sub

#End Region

#Region "Métodos de Controle"
    Private Sub RecuperaEstado()
        'Me.DatasetRelacaoMercadoriaEPortariaBeneficioProdutoInformatica1 = WebSession.dsRelacaoMercadoriaEPortariaBeneficioProdutoInformatica
    End Sub

    Private Sub SalvaEstado()
        'WebSession.dsRelacaoMercadoriaEPortariaBeneficioProdutoInformatica = Me.DatasetRelacaoMercadoriaEPortariaBeneficioProdutoInformatica1
    End Sub
#End Region

#Region "Métodos de Regra"

#End Region

   
End Class