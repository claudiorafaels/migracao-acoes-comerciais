Public Class InibirDedAutomatico
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents ddlStatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Div1 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TRCodigoGrupoEconomico As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents ucGrupoEconomico As ucGrupoEconomico
    Protected WithEvents btnLimpar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnExportar As System.Web.UI.WebControls.LinkButton
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
        'Put user code to initialize the page here
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Try
            CarregaDadosPesquisa()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Public Sub CarregaDadosPesquisa()
        Dim codFrn, nomFrn, codGrpFrn, nomGrpFrn, status As String
        codFrn = ""
        codGrpFrn = ""
        If ucGrupoEconomico.CodGrupoEconomico > 0 Then codGrpFrn = ucGrupoEconomico.CodGrupoEconomico.ToString()
        If ucFornecedor.CodFornecedor > 0 Then codFrn = ucFornecedor.CodFornecedor.ToString()
        nomFrn = "" 'ucFornecedor.NomFornecedor
        nomGrpFrn = "" 'ucGrupoEconomico.NomGrupoEconomico
        status = Me.ddlStatus.SelectedValue.ToString()

        Dim dtsFornecedor As wsAcoesComerciais.DatasetFornecedor
        dtsFornecedor = Controller.ObterDEDAutomatico(codFrn, nomFrn, codGrpFrn, nomGrpFrn, status)
        If dtsFornecedor.DEDAutomatico.Rows.Count > 0 Then
            Session("DED") = dtsFornecedor.DEDAutomatico
            Me.dtgListar.DataSource = dtsFornecedor.DEDAutomatico
            dtgListar.DataBind()
            Me.btnExportar.Visible = True
        Else
            Me.dtgListar.DataSource = Nothing
            dtgListar.DataBind()
            Me.btnExportar.Visible = False
            Util.AdicionaJsAlert(Me.Page, "Não foi encontrado nenhum registro!", True)
        End If
    End Sub

    Private Sub dtgListar_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgListar.PageIndexChanged
        Try
            dtgListar.DataSource = Session("DED")
            dtgListar.CurrentPageIndex = e.NewPageIndex()
            dtgListar.DataBind()
        Catch vex As Exception
        End Try
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Dim dtsFrn As New wsAcoesComerciais.DatasetFornecedor
        dtsFrn.Merge(DirectCast(Session("DED"), wsAcoesComerciais.DatasetFornecedor.DEDAutomaticoDataTable))
        Dim dtsAtualizacao As New wsAcoesComerciais.DatasetFornecedor
        For i As Integer = 0 To dtgListar.Items.Count - 1
            Dim chk As CheckBox = DirectCast(dtgListar.Items(i).FindControl("chkInibido"), CheckBox)
            Dim indicador As Decimal = 0
            If chk.Checked Then indicador = 1
            If dtsFrn.DEDAutomatico.Select("CODFRN = " & dtgListar.Items(i).Cells(0).Text & " AND CODGRPFRN = " & dtgListar.Items(i).Cells(2).Text & " AND INDSUSDSCNOTFSCAUT = " & indicador).Length = 0 Then
                Dim row As wsAcoesComerciais.DatasetFornecedor.DEDAutomaticoRow = dtsAtualizacao.DEDAutomatico.NewDEDAutomaticoRow
                With row
                    .CODFRN = Decimal.Parse(dtgListar.Items(i).Cells(0).Text)
                    .CODGRPFRN = Decimal.Parse(dtgListar.Items(i).Cells(2).Text)
                    .INDSUSDSCNOTFSCAUT = indicador
                End With
                dtsAtualizacao.DEDAutomatico.AddDEDAutomaticoRow(row)
            End If
        Next
        Controller.AtualizarDEDAutomatico(dtsAtualizacao)
        Util.AdicionaJsAlert(Me.Page, "Dados atualizados com sucesso!", True)
        CarregaDadosPesquisa()
    End Sub

    Private Sub btnLimpar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpar.Click
        Server.Transfer("InibirDedAutomatico.aspx")
    End Sub

   
    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Try
            If dtgListar.Items.Count = 0 Then
                Util.AdicionaJsAlert(MyBase.Page, "Não existem dados para serem exportados")
                Exit Sub
            End If

            Response.Clear()
            dtgListar.EnableViewState = False
            dtgListar.DataSource = Session("DED")
            dtgListar.AllowSorting = False
            dtgListar.AllowPaging = False
            Response.ContentType = "Application/x-msexcel"
            Dim oStringWriter As New System.IO.StringWriter
            Dim oHtmlTextWriter As New System.Web.UI.HtmlTextWriter(oStringWriter)

            oHtmlTextWriter.Write("<html><head>")
            oHtmlTextWriter.Write("</head><body>")
            oHtmlTextWriter.WriteBeginTag("form runat=server ")
            oHtmlTextWriter.WriteAttribute("target", "_top")
            oHtmlTextWriter.Write(">")
            dtgListar.HeaderStyle.BackColor = Color.DarkBlue
            dtgListar.HeaderStyle.ForeColor = Color.White
            dtgListar.ItemStyle.BackColor = Color.WhiteSmoke
            dtgListar.ItemStyle.Wrap = False
            dtgListar.AlternatingItemStyle.BackColor = Color.LightSkyBlue
            dtgListar.AlternatingItemStyle.Wrap = False
            dtgListar.Columns(4).Visible = False
            dtgListar.Columns(5).Visible = True
            dtgListar.DataBind()
            dtgListar.RenderControl(oHtmlTextWriter)
            oHtmlTextWriter.Write("</form></body></html>")
            Response.AddHeader("Content-Disposition", "attachment;filename=DEDAutomatico.xls")
            Response.Write(oStringWriter.ToString())
            dtgListar.Columns(4).Visible = True
            dtgListar.Columns(5).Visible = False
            Response.End()
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub dtgListar_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgListar.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim lblInibido As Label = DirectCast(e.Item.FindControl("lblInibido"), Label)
            Dim dtsDED As wsAcoesComerciais.DatasetFornecedor.DEDAutomaticoDataTable = DirectCast(Session("DED"), wsAcoesComerciais.DatasetFornecedor.DEDAutomaticoDataTable)
            If dtsDED(e.Item.ItemIndex).INDSUSDSCNOTFSCAUT = 1 Then
                lblInibido.Text = "SIM"
            Else
                lblInibido.Text = "NÃO"
            End If
        End If
    End Sub
End Class
