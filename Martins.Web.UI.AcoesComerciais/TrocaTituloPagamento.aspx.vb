Public Class TrocaTituloPagamento
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dsTrocaManualTituloPagamentoAcordoComercial = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTrocaManualTituloPagamentoAcordoComercial
        CType(Me.dsTrocaManualTituloPagamentoAcordoComercial, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'dsTrocaManualTituloPagamentoAcordoComercial
        '
        Me.dsTrocaManualTituloPagamentoAcordoComercial.DataSetName = "DatasetTrocaManualTituloPagamentoAcordoComercial"
        Me.dsTrocaManualTituloPagamentoAcordoComercial.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.dsTrocaManualTituloPagamentoAcordoComercial, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents UltraWebGrid2 As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents ddlAcordo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rbIntegral As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbParcial As System.Web.UI.WebControls.RadioButton
    Protected WithEvents dsTrocaManualTituloPagamentoAcordoComercial As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTrocaManualTituloPagamentoAcordoComercial
    Protected WithEvents txtDatNgc As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents grdNotasAssociadas As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents grdNotasDisponiveis As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents ddlTipDsnDscBnf As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlTipFrmDscBnf As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDesSitPms As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlDatPrvRcbPms As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtVlrNgcEftPms As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtVlrPgoPms As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtVlrRelPms As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtVlrPms As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtVlrUtz As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents tblVlrUtz As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents btnOk As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancVlr As System.Web.UI.WebControls.LinkButton
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

#Region "Propriedades"

    Private Property flagProcessando() As Boolean
        Get
            Dim result As Boolean = False
            If Not viewstate("flagProcessando") Is Nothing Then
                result = CType(viewstate("flagProcessando"), Boolean)
            End If
            Return result
        End Get

        Set(ByVal Value As Boolean)
            viewstate("flagProcessando") = Value
        End Set
    End Property

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
            If flagProcessando Then
                Exit Sub
            End If
            flagProcessando = True

            If validar() Then
                Atualizar()
                Util.AdicionaJsAlert(Me.Page, "Gravação realizada com sucesso.")
                btnSalvar.Enabled = False
            Else
                Util.AdicionaJsAlert(Me, "Não foi encontrado nenhuma Nota Fiscal Associada!")
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        Finally
            flagProcessando = False
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("Principal.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        Me.SalvaEstado()
    End Sub

    Private Sub grdNotas_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.RowEventArgs) Handles grdNotasAssociadas.InitializeRow, grdNotasDisponiveis.InitializeRow
        Try
            Dim nota, codSeq As String
            If Not e.Row.Cells.FromKey("NumNotFscFrnCtb").Value Is Nothing Then
                nota = e.Row.Cells.FromKey("NumNotFscFrnCtb").Value.ToString
            Else
                e.Row.Delete()
                Exit Sub
            End If
            If Not e.Row.Cells.FromKey("CodSeqPclNotFsc").Value Is Nothing Then
                codSeq = e.Row.Cells.FromKey("CodSeqPclNotFsc").Value.ToString
            Else
                e.Row.Delete()
                Exit Sub
            End If
            e.Row.Cells(1).Value = String.Concat(nota, " - ", codSeq)
            e.Row.Tag = 1
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ucFornecedor_FornecedorAlterado(ByVal e As System.Web.UI.WebControls.ListItem) Handles ucFornecedor.FornecedorAlterado
        Try
            If Not ucFornecedor.CodFornecedor = Decimal.Zero Then
                dsTrocaManualTituloPagamentoAcordoComercial = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTrocaManualTituloPagamentoAcordoComercial
                'Me.grdNotasDisponiveis.DataBind() 'Limpar
                'Me.grdNotasAssociadas.DataBind()  'Limpar
                Me.LimparControles()
                Me.CarregaPromessas(1)
                btnSalvar.Enabled = True
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub rbTipo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbIntegral.CheckedChanged, rbParcial.CheckedChanged
        Try
            Me.LimparControles()
            If ucFornecedor.CodFornecedor > 0 Then
                CarregaDDLAcordo()
                Me.CarregaPromessas(1)
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ddlDatPrvRcbPms_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlDatPrvRcbPms.SelectedIndexChanged
        Try
            Me.TrocaDataPrevisaoRecebimentoTipoDestinoDescontoBeneficio()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ddlTipDsnDscBnf_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTipDsnDscBnf.SelectedIndexChanged
        Try
            Me.TrocaDataPrevisaoRecebimentoTipoDestinoDescontoBeneficio()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ddlTipFrmDscBnf_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTipFrmDscBnf.SelectedIndexChanged
        Try
            Me.TrocaDataPrevisaoRecebimentoTipoDestinoDescontoBeneficio()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ddlAcordo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlAcordo.SelectedIndexChanged
        Try
            If IsNumeric(ddlAcordo.SelectedValue) AndAlso Convert.ToInt32(ddlAcordo.SelectedValue) > 0 Then
                Me.CarregaPromessas(8)
                btnSalvar.Enabled = True
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub grdNotasAssociadas_ItemCommand(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.UltraWebGridCommandEventArgs) Handles grdNotasAssociadas.ItemCommand
        Try
            If Me.rbParcial.Checked Then
                If Controller.VerificaParcial(Convert.ToDecimal(Me.ddlAcordo.SelectedValue), Convert.ToDecimal(grdNotasAssociadas.DisplayLayout.ActiveRow.Cells.FromKey("NumNotFscFrnCtb").Value)) = 0 Then
                    Util.AdicionaJsAlert(Me, "Esta nota não pode ser dissociada!")
                    Exit Sub
                End If
            End If
            Me.DesassociarNotas(grdNotasAssociadas.DisplayLayout.ActiveRow.Index)
            grdNotasDisponiveis.DataBind()
            grdNotasDisponiveis.Rows.Item(grdNotasDisponiveis.Rows.Count - 1).Tag = 2
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    'Private Sub btnDesassociar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesassociar.Click
    '    Dim count As Integer = 0
    '    For Each row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdNotasAssociadas.Rows
    '        If Convert.ToBoolean(row.Cells(0).Value) Then
    '            count += 1
    '        End If
    '    Next
    '    If count > 0 Then
    '        Me.DesassociarNotas()
    '        grdNotasDisponiveis.DataBind()
    '        grdNotasDisponiveis.Rows.Item(grdNotasDisponiveis.Rows.Count - 1).Tag = 1
    '    Else
    '        Util.AdicionaJsAlert(Me, "Nenhuma nota fiscal foi selecionada!")
    '    End If
    'End Sub

    Private Sub grdNotasDisponiveis_ItemCommand(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.UltraWebGridCommandEventArgs) Handles grdNotasDisponiveis.ItemCommand
        Try
            If grdNotasDisponiveis.Rows.Count > 0 Then
                If Not Session("key") Is Nothing Then Session("key") = Nothing
                tblVlrUtz.Visible = True
                txtVlrUtz.Value = grdNotasDisponiveis.DisplayLayout.ActiveRow().GetCellValue(grdNotasDisponiveis.Columns.FromKey("VlrDspNotFsc")) 'row.Cells.FromKey("VlrDspNotFsc").Value
                Util.AdicionaJsFocus(Me.Page, CType(txtVlrUtz, WebControl))
                Session("key") = grdNotasDisponiveis.DisplayLayout.ActiveRow.Index
            Else
                Util.AdicionaJsAlert(Me, "Nenhuma nota disponível!")
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    'Private Sub btnAssociar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'If grdNotasDisponiveis.Rows.Count > 0 Then
    '    ' Dim count As Integer = 0
    '    If Session("key") Is Nothing Then Session("key") = -1
    '    For Each row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In Me.grdNotasDisponiveis.Rows
    '        If row.Index > CInt(Session("key")) Then
    '            If Convert.ToBoolean(row.Cells(0).Value) Then
    '                tblVlrUtz.Visible = True
    '                Me.lblValor.Text = "Informe o valor a ser utilizado para a nota " + row.Cells(1).Value.ToString
    '                txtVlrUtz.Value = row.Cells.FromKey("VlrDspNotFsc").Value 'grdNotasDisponiveis.DisplayLayout.ActiveRow().GetCellValue(grdNotasDisponiveis.Columns.FromKey("VlrDspNotFsc"))
    '                Util.AdicionaJsFocus(Me.Page, CType(txtVlrUtz, WebControl))
    '                'count += 1
    '                Session("key") = row.Index
    '                Exit For
    '            End If
    '        End If
    '    Next
    '    'If count = 0 Then
    '    '    Util.AdicionaJsAlert(Me, "Nenhuma nota fiscal foi selecionada!")
    '    'End If
    'Else
    '    Util.AdicionaJsAlert(Me, "Nenhuma nota disponível!")
    'End If
    'End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Try
            Me.AssociarNotas()
            Me.grdNotasAssociadas.DataSource = dsTrocaManualTituloPagamentoAcordoComercial()
            Me.grdNotasAssociadas.DataBind()
            If Me.grdNotasAssociadas.Rows.Count > 0 Then
                grdNotasAssociadas.Rows.Item(grdNotasAssociadas.Rows.Count - 1).Tag = 1
                Me.tblVlrUtz.Visible = False
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnCancVlr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancVlr.Click
        tblVlrUtz.Visible = False
    End Sub

#End Region

#Region " Metodos "

#Region " Metodos de Controles "

    Private Sub LimparControles()
        Util.LimpaControles(New WebControl() {ddlAcordo, txtDatNgc, ddlDatPrvRcbPms, ddlTipDsnDscBnf, ddlTipFrmDscBnf, txtDesSitPms, txtVlrNgcEftPms, txtVlrPgoPms, txtVlrRelPms, txtVlrPms})
        grdNotasDisponiveis.Rows.Clear()
        grdNotasAssociadas.Rows.Clear()
        dsTrocaManualTituloPagamentoAcordoComercial.Clear()
    End Sub

#End Region

#Region " Métodos de Carga "

    Private Sub InicializaPagina()

        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If

        If Not Me.IsPostBack Then
            ucFornecedor.widthNome = System.Web.UI.WebControls.Unit.Parse("280px")
        Else
            Me.RecuperaEstado()
        End If

        btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
    End Sub

    Private Sub RecuperaEstado()
        If Not Session("EstadoTrocaTitulo") Is Nothing Then _
            dsTrocaManualTituloPagamentoAcordoComercial = DirectCast(Session("EstadoTrocaTitulo"), wsAcoesComerciais.DatasetTrocaManualTituloPagamentoAcordoComercial)
    End Sub

    Private Sub SalvaEstado()
        If Not dsTrocaManualTituloPagamentoAcordoComercial Is Nothing Then _
            Session("EstadoTrocaTitulo") = dsTrocaManualTituloPagamentoAcordoComercial()
    End Sub

    Private Sub CarregaDDLAcordo()
        With ddlAcordo
            .Items.Clear()
            Dim linha As wsAcoesComerciais.DatasetTrocaManualTituloPagamentoAcordoComercial.tbPromessasFornecedorRow
            For Each linha In dsTrocaManualTituloPagamentoAcordoComercial.tbPromessasFornecedor.Rows
                If Not linha.IsCodPmsNull And Not linha.IsDesSitPmsNull Then
                    .Items.Add(New ListItem(linha.CodPms.ToString & " - " & linha.DesSitPms, linha.CodPms.ToString))
                End If
            Next
            .Items.Insert(0, New ListItem("SELECIONE", "0"))
            .DataBind()
        End With
    End Sub

    Private Sub CarregaControles()
        ddlDatPrvRcbPms.Items.Clear()
        ddlTipDsnDscBnf.Items.Clear()
        ddlTipFrmDscBnf.Items.Clear()

        Dim drPromessasFornecedor As wsAcoesComerciais.DatasetTrocaManualTituloPagamentoAcordoComercial.tbPromessasFornecedorRow = _
            Me.getPromessasFornecedorByCodPromessa()

        txtDatNgc.Value = drPromessasFornecedor.DatNgcPms.ToString("dd/MM/yyyy")
        txtDesSitPms.Text = drPromessasFornecedor.DesSitPms
        If drPromessasFornecedor.CodSitPms <> 3 Then
            txtVlrNgcEftPms.Value = drPromessasFornecedor.VlrNgcPms
        Else
            txtVlrNgcEftPms.Value = drPromessasFornecedor.VlrEftPms
        End If
        txtVlrPgoPms.Value = drPromessasFornecedor.VlrPgoPms
        txtVlrRelPms.Value = drPromessasFornecedor.VlrRelPms
        txtVlrPms.Value = drPromessasFornecedor.VlrPms

        If rbParcial.Checked And drPromessasFornecedor.QtdDsnDscBnf > 1 Then
            ' PARCIAL
            Session("Parciais") = dsTrocaManualTituloPagamentoAcordoComercial.tbInformacoesPromessaParciaisEspecificaFornecedor

            For Each drInformacoesPromessaParciaisEspecificaFornecedor As wsAcoesComerciais.DatasetTrocaManualTituloPagamentoAcordoComercial.tbInformacoesPromessaEspecificaFornecedorRow _
                    In dsTrocaManualTituloPagamentoAcordoComercial.tbInformacoesPromessaParciaisEspecificaFornecedor.Rows
                ddlDatPrvRcbPms.Items.Add(New ListItem(drInformacoesPromessaParciaisEspecificaFornecedor.DatPrvRcbPms.ToShortDateString()))
                ddlTipDsnDscBnf.Items.Add(New ListItem(drInformacoesPromessaParciaisEspecificaFornecedor.TipDsnDscBnf.ToString("0000") & " - " & drInformacoesPromessaParciaisEspecificaFornecedor.DesDsnDscBnf, drInformacoesPromessaParciaisEspecificaFornecedor.TipDsnDscBnf.ToString()))
                ddlTipFrmDscBnf.Items.Add(New ListItem(drInformacoesPromessaParciaisEspecificaFornecedor.TipFrmDscBnf.ToString("0000") & " - " & drInformacoesPromessaParciaisEspecificaFornecedor.DesFrmDscBnf, drInformacoesPromessaParciaisEspecificaFornecedor.TipFrmDscBnf.ToString()))
            Next
            Me.ddlDatPrvRcbPms_SelectedIndexChanged(Nothing, Nothing)
        Else
            ' INTEGRAL
            ddlDatPrvRcbPms.Items.Add(New ListItem(drPromessasFornecedor.DatPrvRcbPms.ToShortDateString()))
            ddlTipDsnDscBnf.Items.Add(New ListItem(drPromessasFornecedor.TipDsnDscBnf.ToString("0000") & " - " & drPromessasFornecedor.DesDsnDscBnf, drPromessasFornecedor.TipDsnDscBnf.ToString()))
            ddlTipFrmDscBnf.Items.Add(New ListItem(drPromessasFornecedor.TipFrmDscBnf.ToString("0000") & " - " & drPromessasFornecedor.DesFrmDscBnf, drPromessasFornecedor.TipFrmDscBnf.ToString()))
        End If
    End Sub

    Private Sub CarregaGridNotasFiscaisAssociadas(ByVal tipCsn As Integer)
        Try
            Me.grdNotasAssociadas.DataSource = Nothing
            Dim row As DataRow
            Dim column As DataColumn
            If dsTrocaManualTituloPagamentoAcordoComercial.tbInformacoesPromessaParciaisEspecificaFornecedor.Select("DatPrvRcbPms = #" & CType(ddlDatPrvRcbPms.SelectedItem.Text, Date).ToString("yyyy-MM-dd") & "#").Length > 0 Then
                row = dsTrocaManualTituloPagamentoAcordoComercial.tbInformacoesPromessaParciaisEspecificaFornecedor.Select("DatPrvRcbPms = #" & CType(ddlDatPrvRcbPms.SelectedItem.Text, Date).ToString("yyyy-MM-dd") & "#")(0)
            End If
            dsTrocaManualTituloPagamentoAcordoComercial.tbNotasRelacionadasPromessaFornecedor.Clear()

            If Not (row Is Nothing) Then
                dsTrocaManualTituloPagamentoAcordoComercial.Merge(Controller.ObterTrocaManualTituloPagamentoAcordoComercial(tipCsn, Convert.ToInt32(ucFornecedor.CodFornecedor), Convert.ToInt32(ddlAcordo.SelectedValue), CInt(row("CodEmp")), CInt(row("CodFilEmp")), 0, CDate(row("DatPrvRcbPms")), CInt(row("TipFrmDscBnf")), CInt(row("TipDsnDscBnf")), Nothing, 0, String.Empty, 0, Decimal.Zero), False, MissingSchemaAction.Ignore)
            End If

            If dsTrocaManualTituloPagamentoAcordoComercial.tbNotasRelacionadasPromessaFornecedor.Rows.Count > 0 Then
                grdNotasAssociadas.DataBind()
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub CarregaPromessas(ByVal tipCsn As Integer)
        Try

            Select Case tipCsn
                Case 1
                    dsTrocaManualTituloPagamentoAcordoComercial.Merge(Controller.ObterTrocaManualTituloPagamentoAcordoComercial(1, Convert.ToInt32(ucFornecedor.CodFornecedor), 0, 0, 0, 0, Nothing, 0, 0, Nothing, 0, String.Empty, 0, Decimal.Zero), False, MissingSchemaAction.Ignore)
                    'dsTrocaManualTituloPagamentoAcordoComercial = Controller.ObterTrocaManualTituloPagamentoAcordoComercial(1, Convert.ToInt32(ucFornecedor.CodFornecedor), 0, 0, 0, 0, Nothing, 0, 0, Nothing, 0, String.Empty, 0, Decimal.Zero)
                    Me.CarregaDDLAcordo()
                Case 3
                    Me.CarregaGridNotasFiscaisAssociadas(tipCsn)
                    CarregaPromessas(4)
                Case 4S
                    dsTrocaManualTituloPagamentoAcordoComercial.Merge(Controller.ObterTrocaManualTituloPagamentoAcordoComercial(4, Convert.ToInt32(ucFornecedor.CodFornecedor), Convert.ToInt32(ddlAcordo.SelectedValue), 0, 0, 0, Nothing, 0, 0, Nothing, 0, String.Empty, 0, Decimal.Zero), False, MissingSchemaAction.Ignore)
                    'dsTrocaManualTituloPagamentoAcordoComercial = Controller.ObterTrocaManualTituloPagamentoAcordoComercial(4, Convert.ToInt32(ucFornecedor.CodFornecedor), Convert.ToInt32(ddlAcordo.SelectedValue), 0, 0, 0, Nothing, 0, 0, Nothing, 0, String.Empty, 0, Decimal.Zero)
                    grdNotasDisponiveis.DataBind()
                    Session("key") = Nothing
                    'Me.CarregaGridNotasFiscaisDisponiveis()
                Case 8
                    dsTrocaManualTituloPagamentoAcordoComercial.Merge(Controller.ObterTrocaManualTituloPagamentoAcordoComercial(8, Convert.ToInt32(ucFornecedor.CodFornecedor), Convert.ToInt32(ddlAcordo.SelectedValue), 0, 0, 0, Nothing, 0, 0, Nothing, 0, String.Empty, 0, Decimal.Zero))
                    'dsTrocaManualTituloPagamentoAcordoComercial = Controller.ObterTrocaManualTituloPagamentoAcordoComercial(8, Convert.ToInt32(ucFornecedor.CodFornecedor), Convert.ToInt32(ddlAcordo.SelectedValue), 0, 0, 0, Nothing, 0, 0, Nothing, 0, String.Empty, 0, Decimal.Zero)
                    Me.CarregaControles()
                    Me.CarregaPromessas(3)
            End Select
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub


#End Region

#Region " Metodos de Regras de Negocio "

    Private Function validar() As Boolean

        If grdNotasAssociadas.Rows.Count > 0 Then
            For Each row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In grdNotasAssociadas.Rows
                If Not row.Cells(1).Value Is String.Empty Then
                    Return True
                End If
            Next
        End If

        ' Duplicatas disponiveis
        If grdNotasDisponiveis.Rows.Count > 0 Then
            For Each row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In grdNotasDisponiveis.Rows
                'Verifica se a linha foi desassociada
                If (Not row.Cells(1).Value Is String.Empty) And CType(row.Cells(10).Value, Boolean) Then
                    Return True
                End If
            Next
        End If
    End Function

    Private Function getPromessasFornecedorByCodPromessa() As wsAcoesComerciais.DatasetTrocaManualTituloPagamentoAcordoComercial.tbPromessasFornecedorRow
        If dsTrocaManualTituloPagamentoAcordoComercial.tbPromessasFornecedor.Select("CodPms = " & ddlAcordo.SelectedValue).Length > 0 Then
            getPromessasFornecedorByCodPromessa = CType(dsTrocaManualTituloPagamentoAcordoComercial.tbPromessasFornecedor.Select("CodPms = " & ddlAcordo.SelectedValue).GetValue(0), wsAcoesComerciais.DatasetTrocaManualTituloPagamentoAcordoComercial.tbPromessasFornecedorRow)
        End If
    End Function

    Private Function getPromessaParcialEspecificaFornecedorByDatPrvRcbPms() As wsAcoesComerciais.DatasetTrocaManualTituloPagamentoAcordoComercial.tbInformacoesPromessaParciaisEspecificaFornecedorRow
        If dsTrocaManualTituloPagamentoAcordoComercial.tbInformacoesPromessaParciaisEspecificaFornecedor.Select("DatPrvRcbPms = #" & CType(ddlDatPrvRcbPms.SelectedItem.Text, Date).ToString("yyyy-MM-dd") & "#").Length > 0 Then
            getPromessaParcialEspecificaFornecedorByDatPrvRcbPms = CType(dsTrocaManualTituloPagamentoAcordoComercial.tbInformacoesPromessaParciaisEspecificaFornecedor.Select("DatPrvRcbPms = #" & CType(ddlDatPrvRcbPms.SelectedItem.Text, Date).ToString("yyyy-MM-dd") & "#").GetValue(0), wsAcoesComerciais.DatasetTrocaManualTituloPagamentoAcordoComercial.tbInformacoesPromessaParciaisEspecificaFornecedorRow)
        End If
    End Function

    Private Function getPromessaValue(ByVal indice As Integer, ByVal field As String) As Object
        Dim dt As DataTable = dsTrocaManualTituloPagamentoAcordoComercial.tbPromessasFornecedor

        If rbParcial.Checked And getPromessasFornecedorByCodPromessa().QtdDsnDscBnf > 1 Then
            If dsTrocaManualTituloPagamentoAcordoComercial.tbInformacoesPromessaParciaisEspecificaFornecedor.Rows.Count > 0 Then
                'Trabalha com com promessas parciais 8
                dt = dsTrocaManualTituloPagamentoAcordoComercial.tbInformacoesPromessaParciaisEspecificaFornecedor
            End If
        End If
        Return dt.Rows.Item(indice).Item(field)
    End Function

    Private Sub TrocaDataPrevisaoRecebimentoTipoDestinoDescontoBeneficio()
        Dim drPromessasFornecedor As wsAcoesComerciais.DatasetTrocaManualTituloPagamentoAcordoComercial.tbPromessasFornecedorRow = _
            Me.getPromessasFornecedorByCodPromessa()

        If (rbParcial.Checked And drPromessasFornecedor.QtdDsnDscBnf > 1) Then
            If ddlDatPrvRcbPms.SelectedIndex > -1 And dsTrocaManualTituloPagamentoAcordoComercial.tbInformacoesPromessaParciaisEspecificaFornecedor.Rows.Count > 0 Then

                If grdNotasAssociadas.Rows.Count > 0 Then grdNotasAssociadas.Rows.Clear()

                Dim drPromessaParcialEspecificaFornecedor As wsAcoesComerciais.DatasetTrocaManualTituloPagamentoAcordoComercial.tbInformacoesPromessaParciaisEspecificaFornecedorRow = _
                    Me.getPromessaParcialEspecificaFornecedorByDatPrvRcbPms()

                txtDatNgc.Value = drPromessaParcialEspecificaFornecedor.DatNgcPms
                txtDesSitPms.Text = drPromessaParcialEspecificaFornecedor.DesSitPms

                If drPromessaParcialEspecificaFornecedor.CodSitPms <> 3 Then
                    txtVlrNgcEftPms.Value = drPromessaParcialEspecificaFornecedor.VlrNgcPms
                Else
                    txtVlrNgcEftPms.Value = drPromessaParcialEspecificaFornecedor.VlrEftPms
                End If

                txtVlrPgoPms.Value = drPromessaParcialEspecificaFornecedor.VlrPgoPms
                txtVlrRelPms.Value = drPromessaParcialEspecificaFornecedor.VlrRelPms
                txtVlrPms.Value = drPromessaParcialEspecificaFornecedor.VlrPms

                ddlTipDsnDscBnf.SelectedIndex = ddlDatPrvRcbPms.SelectedIndex
                ddlTipFrmDscBnf.SelectedIndex = ddlDatPrvRcbPms.SelectedIndex

                'Preenche o grid Notas fiscais associadas parciais
                Me.CarregaGridNotasFiscaisAssociadas(11)
            End If
        End If

    End Sub

    Private Sub DesassociarNotas(ByVal row As Integer)
        Try
            If grdNotasAssociadas.Rows.Count > 0 Then
                Dim dblVlrRelPms, dblVlrPms, dblVlrTitPgtUtzSbtPms, dblVlrDspNotFsc, dblVlrRelNotFsc As Decimal

                'Altera valor da promessa
                dblVlrTitPgtUtzSbtPms = Convert.ToDecimal(Me.grdNotasAssociadas.Rows(row).Cells(6).Value) 'Convert.ToDecimal(grdNotasAssociadas.DisplayLayout.ActiveRow.Cells(6).Value)
                dblVlrRelPms = txtVlrRelPms.ValueDecimal - dblVlrTitPgtUtzSbtPms
                dblVlrPms = txtVlrPms.ValueDecimal + dblVlrTitPgtUtzSbtPms
                txtVlrRelPms.Value = dblVlrRelPms
                Me.getPromessasFornecedorByCodPromessa().VlrRelPms = dblVlrRelPms
                txtVlrPms.Value = dblVlrPms
                Me.getPromessasFornecedorByCodPromessa().VlrPms = dblVlrPms

                'Altera valor da nota
                dblVlrDspNotFsc = Convert.ToDecimal(Me.grdNotasAssociadas.Rows(row).Cells.FromKey("VlrDspNotFsc").Value) 'Convert.ToDecimal(grdNotasAssociadas.DisplayLayout.ActiveRow().GetCellValue(grdNotasAssociadas.Columns.FromKey("VlrDspNotFsc").value).value)
                dblVlrRelNotFsc = Convert.ToDecimal(Me.grdNotasAssociadas.Rows(row).Cells.FromKey("VlrRelNotFsc").Value) 'Convert.ToDecimal(grdNotasAssociadas.DisplayLayout.ActiveRow().GetCellValue(grdNotasAssociadas.Columns.FromKey("VlrRelNotFsc").value).value)
                dblVlrDspNotFsc = dblVlrDspNotFsc + dblVlrTitPgtUtzSbtPms
                dblVlrRelNotFsc = dblVlrRelNotFsc - dblVlrTitPgtUtzSbtPms

                Dim drNotasDisponiveisRelacionamento As wsAcoesComerciais.DatasetTrocaManualTituloPagamentoAcordoComercial.tbNotasDisponiveisRelacionamentoRow = _
                    dsTrocaManualTituloPagamentoAcordoComercial.tbNotasDisponiveisRelacionamento.NewtbNotasDisponiveisRelacionamentoRow
                Dim drNotasRelacionadasPromessaFornecedor As wsAcoesComerciais.DatasetTrocaManualTituloPagamentoAcordoComercial.tbNotasRelacionadasPromessaFornecedorRow
                With drNotasDisponiveisRelacionamento
                    .NumNotFscFrnCtb = Convert.ToInt32(Me.grdNotasAssociadas.Rows(row).Cells.FromKey("NumNotFscFrnCtb").Value) 'Convert.ToInt32(grdNotasAssociadas.DisplayLayout.ActiveRow().GetCellValue(grdNotasAssociadas.Columns.FromKey("NumNotFscFrnCtb").value))
                    .DatPgtPclNotFsc = Convert.ToDateTime(Me.grdNotasAssociadas.Rows(row).Cells.FromKey("DatPgtPclNotFsc").Value).Date() 'Convert.ToDateTime(grdNotasAssociadas.DisplayLayout.ActiveRow().GetCellValue(grdNotasAssociadas.Columns.FromKey("DatPgtPclNotFsc").value)).Date()
                    .VlrDspNotFsc = Convert.ToDecimal(Me.grdNotasAssociadas.Rows(row).Cells.FromKey("VlrDspNotFsc").Value) 'Convert.ToDecimal(grdNotasAssociadas.DisplayLayout.ActiveRow().GetCellValue(grdNotasAssociadas.Columns.FromKey("VlrDspNotFsc").value))
                    .VlrRelNotFsc = Convert.ToDecimal(Me.grdNotasAssociadas.Rows(row).Cells.FromKey("VlrRelNotFsc").Value) 'Convert.ToDecimal(grdNotasAssociadas.DisplayLayout.ActiveRow().GetCellValue(grdNotasAssociadas.Columns.FromKey("VlrRelNotFsc").value))
                    .NumNotFscFrnCtb = Convert.ToInt32(Me.grdNotasAssociadas.Rows(row).Cells.FromKey("NumNotFscFrnCtb").Value) 'Convert.ToInt32(grdNotasAssociadas.DisplayLayout.ActiveRow().GetCellValue(grdNotasAssociadas.Columns.FromKey("NumNotFscFrnCtb").value))
                    .CodSeqPclNotFsc = Convert.ToString(Me.grdNotasAssociadas.Rows(row).Cells.FromKey("CodSeqPclNotFsc").Value) 'Convert.ToString(grdNotasAssociadas.DisplayLayout.ActiveRow().GetCellValue(grdNotasAssociadas.Columns.FromKey("CodSeqPclNotFsc").value))
                    .NumSeqTitPgt = Convert.ToInt32(Me.grdNotasAssociadas.Rows(row).Cells.FromKey("NumSeqTitPgt").Value) 'Convert.ToInt32(grdNotasAssociadas.DisplayLayout.ActiveRow().GetCellValue(grdNotasAssociadas.Columns.FromKey("NumSeqTitPgt").value))
                    .CodEmpFrn = Convert.ToInt32(Me.grdNotasAssociadas.Rows(row).Cells.FromKey("CodEmpFrn").Value) 'Convert.ToInt32(grdNotasAssociadas.DisplayLayout.ActiveRow().GetCellValue(grdNotasAssociadas.Columns.FromKey("CodEmpFrn").value))
                    .DatPgtPclNotFsc = Convert.ToDateTime(Me.grdNotasAssociadas.Rows(row).Cells.FromKey("DatPgtPclNotFsc").Value).Date() 'Convert.ToDateTime(grdNotasAssociadas.DisplayLayout.ActiveRow().GetCellValue(grdNotasAssociadas.Columns.FromKey("DatPgtPclNotFsc").value)).Date()
                    .VlrTitPgtUtzSbtPms = Convert.ToDecimal(Me.grdNotasAssociadas.Rows(row).Cells.FromKey("VlrTitPgtUtzSbtPms").Value) 'Convert.ToDecimal(grdNotasAssociadas.DisplayLayout.ActiveRow().GetCellValue(grdNotasAssociadas.Columns.FromKey("VlrTitPgtUtzSbtPms").value))
                    .FlagFoiDesassociada = True
                    For Each drNotasRelacionadasPromessaFornecedor In Me.dsTrocaManualTituloPagamentoAcordoComercial.tbNotasRelacionadasPromessaFornecedor.Rows
                        If .NumNotFscFrnCtb = drNotasRelacionadasPromessaFornecedor.NumNotFscFrnCtb Then
                            dsTrocaManualTituloPagamentoAcordoComercial.tbNotasRelacionadasPromessaFornecedor.RemovetbNotasRelacionadasPromessaFornecedorRow(drNotasRelacionadasPromessaFornecedor)
                            Exit For
                        End If
                    Next
                End With
                dsTrocaManualTituloPagamentoAcordoComercial.tbNotasDisponiveisRelacionamento.AddtbNotasDisponiveisRelacionamentoRow(drNotasDisponiveisRelacionamento)

                Me.grdNotasAssociadas.Rows(row).Delete()
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub AssociarNotas()
        Dim dblVlrRelPms, dblVlrPms, dblVlrTitPgtUtzSbtPms, dblVlrDspNotFsc, dblVlrRelNotFsc As Decimal

        If txtVlrUtz.Text.Trim() Is String.Empty Then txtVlrUtz.Value = 0

        If txtVlrUtz.ValueDecimal = 0 Then
            Util.AdicionaJsAlert(Me.Page, "O valor deve ser maior que zero.")
            Exit Sub
        End If
        If txtVlrUtz.ValueDecimal > Convert.ToDecimal(grdNotasDisponiveis.Rows(CInt(Session("key"))).Cells.FromKey("VlrDspNotFsc").Value) Then
            'If txtVlrUtz.ValueDecimal > 'Convert.ToDecimal(grdNotasDisponiveis.DisplayLayout.ActiveRow().GetCellValue(grdNotasDisponiveis.Columns.FromKey("VlrDspNotFsc"))) Then
            Util.AdicionaJsAlert(Me.Page, "O valor informado não poder ser superior ao Vlr. Disponível na Nota Fiscal.")
            Exit Sub
        End If
        If txtVlrUtz.ValueDecimal > txtVlrPms.ValueDecimal Then
            Util.AdicionaJsAlert(Me.Page, "O valor informado não poder ser superior ao Vlr. do Saldo da Promessa.")
            Exit Sub
        End If
        If rbIntegral.Checked Then
            If txtVlrUtz.ValueDecimal < txtVlrPms.ValueDecimal Then
                Util.AdicionaJsAlert(Me.Page, "O valor informado não poder ser inferior ao Vlr. do Saldo da Promessa.")
                Exit Sub
            End If
        End If

        ' Altera valor da promessa
        dblVlrTitPgtUtzSbtPms = txtVlrUtz.ValueDecimal
        dblVlrRelPms = txtVlrRelPms.ValueDecimal + dblVlrTitPgtUtzSbtPms
        dblVlrPms = txtVlrPms.ValueDecimal - dblVlrTitPgtUtzSbtPms
        txtVlrRelPms.Value = dblVlrRelPms
        Me.getPromessasFornecedorByCodPromessa().VlrRelPms = dblVlrRelPms
        txtVlrPms.Value = dblVlrPms
        Me.getPromessasFornecedorByCodPromessa().VlrPms = dblVlrPms

        ' Altera valor da nota
        dblVlrDspNotFsc = Convert.ToDecimal(grdNotasDisponiveis.Rows(CInt(Session("key"))).Cells.FromKey("VlrDspNotFsc").Value) 'Convert.ToDecimal(grdNotasDisponiveis.DisplayLayout.ActiveRow().GetCellValue(grdNotasDisponiveis.Columns.FromKey("VlrDspNotFsc")))
        dblVlrRelNotFsc = Convert.ToDecimal(grdNotasDisponiveis.Rows(CInt(Session("key"))).Cells.FromKey("VlrRelNotFsc").Value) 'Convert.ToDecimal(grdNotasDisponiveis.DisplayLayout.ActiveRow().GetCellValue(grdNotasDisponiveis.Columns.FromKey("VlrRelNotFsc")))
        dblVlrDspNotFsc = dblVlrDspNotFsc - dblVlrTitPgtUtzSbtPms
        dblVlrRelNotFsc = dblVlrRelNotFsc + dblVlrTitPgtUtzSbtPms

        Dim drNotasRelacionadasPromessaFornecedor As wsAcoesComerciais.DatasetTrocaManualTituloPagamentoAcordoComercial.tbNotasRelacionadasPromessaFornecedorRow = _
            dsTrocaManualTituloPagamentoAcordoComercial.tbNotasRelacionadasPromessaFornecedor.NewtbNotasRelacionadasPromessaFornecedorRow()
        Dim drNotasDisponiveisRelacionamento As wsAcoesComerciais.DatasetTrocaManualTituloPagamentoAcordoComercial.tbNotasDisponiveisRelacionamentoRow

        With drNotasRelacionadasPromessaFornecedor
            .NumNotFscFrnCtb = Convert.ToInt32(grdNotasDisponiveis.Rows(CInt(Session("key"))).Cells.FromKey("NumNotFscFrnCtb").Value) 'Convert.ToInt32(grdNotasDisponiveis.DisplayLayout.ActiveRow().GetCellValue(grdNotasDisponiveis.Columns.FromKey("NumNotFscFrnCtb")))
            .DatPgtPclNotFsc = Convert.ToDateTime(grdNotasDisponiveis.Rows(CInt(Session("key"))).Cells.FromKey("DatPgtPclNotFsc").Value).Date() 'Convert.ToDateTime(grdNotasDisponiveis.DisplayLayout.ActiveRow().GetCellValue(grdNotasDisponiveis.Columns.FromKey("DatPgtPclNotFsc"))).Date()
            .VlrDspNotFsc = Convert.ToDecimal(grdNotasDisponiveis.Rows(CInt(Session("key"))).Cells.FromKey("VlrDspNotFsc").Value) 'Convert.ToDecimal(grdNotasDisponiveis.DisplayLayout.ActiveRow().GetCellValue(grdNotasDisponiveis.Columns.FromKey("VlrDspNotFsc")))
            .VlrRelNotFsc = dblVlrRelNotFsc 'Convert.ToDecimal(grdNotasDisponiveis.Rows(CInt(Session("key"))).Cells.FromKey("VlrRelNotFsc").Value) 'Convert.ToDecimal(grdNotasDisponiveis.DisplayLayout.ActiveRow().GetCellValue(grdNotasDisponiveis.Columns.FromKey("VlrRelNotFsc")))
            .NumNotFscFrnCtb = Convert.ToInt32(grdNotasDisponiveis.Rows(CInt(Session("key"))).Cells.FromKey("NumNotFscFrnCtb").Value) 'Convert.ToInt32(grdNotasDisponiveis.DisplayLayout.ActiveRow().GetCellValue(grdNotasDisponiveis.Columns.FromKey("NumNotFscFrnCtb")))
            .CodSeqPclNotFsc = Convert.ToString(grdNotasDisponiveis.Rows(CInt(Session("key"))).Cells.FromKey("CodSeqPclNotFsc").Value) 'Convert.ToString(grdNotasDisponiveis.DisplayLayout.ActiveRow().GetCellValue(grdNotasDisponiveis.Columns.FromKey("CodSeqPclNotFsc")))
            .NumSeqTitPgt = Convert.ToInt32(grdNotasDisponiveis.Rows(CInt(Session("key"))).Cells.FromKey("NumSeqTitPgt").Value) 'Convert.ToInt32(grdNotasDisponiveis.DisplayLayout.ActiveRow().GetCellValue(grdNotasDisponiveis.Columns.FromKey("NumSeqTitPgt")))
            .CodEmpFrn = Convert.ToInt32(grdNotasDisponiveis.Rows(CInt(Session("key"))).Cells.FromKey("CodEmpFrn").Value) 'Convert.ToInt32(grdNotasDisponiveis.DisplayLayout.ActiveRow().GetCellValue(grdNotasDisponiveis.Columns.FromKey("CodEmpFrn")))
            .DatPgtPclNotFsc = Convert.ToDateTime(grdNotasDisponiveis.Rows(CInt(Session("key"))).Cells.FromKey("DatPgtPclNotFsc").Value).Date 'Convert.ToDateTime(grdNotasDisponiveis.DisplayLayout.ActiveRow().GetCellValue(grdNotasDisponiveis.Columns.FromKey("DatPgtPclNotFsc"))).Date()
            .VlrTitPgtUtzSbtPms = dblVlrTitPgtUtzSbtPms 'Convert.ToDecimal(grdNotasDisponiveis.Rows(CInt(Session("key"))).Cells.FromKey("VlrTitPgtUtzSbtPms").Value) 'Convert.ToDecimal(grdNotasDisponiveis.DisplayLayout.ActiveRow().GetCellValue(grdNotasDisponiveis.Columns.FromKey("VlrTitPgtUtzSbtPms")))
            For Each drNotasDisponiveisRelacionamento In Me.dsTrocaManualTituloPagamentoAcordoComercial.tbNotasDisponiveisRelacionamento.Rows
                If .NumNotFscFrnCtb = drNotasDisponiveisRelacionamento.NumNotFscFrnCtb Then
                    Me.dsTrocaManualTituloPagamentoAcordoComercial.tbNotasDisponiveisRelacionamento.RemovetbNotasDisponiveisRelacionamentoRow(drNotasDisponiveisRelacionamento)
                    Exit For
                End If
            Next
        End With
        dsTrocaManualTituloPagamentoAcordoComercial.tbNotasRelacionadasPromessaFornecedor.AddtbNotasRelacionadasPromessaFornecedorRow(drNotasRelacionadasPromessaFornecedor)
        grdNotasDisponiveis.Rows(CInt(Session("key"))).Delete()
    End Sub

    Private Sub Atualizar()
        Dim iTipCsn As Integer
        'Trabalha com grid com promessas integrais

        If rbIntegral.Checked Then
            'Notas Fiscais Associadas integrais
            iTipCsn = 5
        Else
            'Notas Fiscais Associadas parciais
            iTipCsn = 9
        End If

        ' Duplicatas relacionadas
        If grdNotasAssociadas.Rows.Count > 0 Then
            For Each row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In grdNotasAssociadas.Rows
                If Not row.Cells(1).Value Is String.Empty Then
                    'Controller.ObterTrocaManualTituloPagamentoAcordoComercial(iTipCsn, _
                    '                                                        Convert.ToInt32(ucFornecedor.CodFornecedor), _
                    '                                                        Convert.ToInt32(ddlAcordo.SelectedValue), _
                    '                                                        getPromessaParcialEspecificaFornecedorByDatPrvRcbPms().CodEmp, _
                    '                                                        getPromessaParcialEspecificaFornecedorByDatPrvRcbPms().CodFilEmp, _
                    '                                                        Convert.ToInt32(row.GetCellValue(grdNotasAssociadas.Columns.FromKey("CodEmpFrn"))), _
                    '                                                        Convert.ToDateTime(Me.getPromessaValue(ddlDatPrvRcbPms.SelectedIndex, "DatPrvRcbPms")).Date(), _
                    '                                                        Convert.ToInt32(Me.getPromessaValue(ddlDatPrvRcbPms.SelectedIndex, "TipFrmDscBnf")), _
                    '                                                        Convert.ToInt32(Me.getPromessaValue(ddlDatPrvRcbPms.SelectedIndex, "TipDsnDscBnf")), _
                    '                                                        Convert.ToDateTime(Me.getPromessaValue(ddlDatPrvRcbPms.SelectedIndex, "DatNgcPms")).Date(), _
                    '                                                        Convert.ToInt32(row.GetCellValue(grdNotasAssociadas.Columns.FromKey("NumNotFscFrnCtb"))), _
                    '                                                        Convert.ToString(row.GetCellValue(grdNotasAssociadas.Columns.FromKey("CodSeqPclNotFsc"))), _
                    '                                                        Convert.ToInt32(row.GetCellValue(grdNotasAssociadas.Columns.FromKey("NumSeqTitPgt"))), _
                    '                                                        Convert.ToDecimal(row.GetCellValue(grdNotasAssociadas.Columns.FromKey("VlrTitPgtUtzSbtPms"))))

                    Controller.ObterTrocaManualTituloPagamentoAcordoComercial(iTipCsn, _
                                                                            Convert.ToInt32(ucFornecedor.CodFornecedor), _
                                                                            Convert.ToInt32(ddlAcordo.SelectedValue), _
                                                                            getPromessaParcialEspecificaFornecedorByDatPrvRcbPms().CodEmp, _
                                                                            getPromessaParcialEspecificaFornecedorByDatPrvRcbPms().CodFilEmp, _
                                                                            Convert.ToInt32(row.GetCellValue(grdNotasAssociadas.Columns.FromKey("CodEmpFrn"))), _
                                                                            Convert.ToDateTime(Me.getPromessaValue(ddlAcordo.SelectedIndex - 1, "DatPrvRcbPms")).Date(), _
                                                                            Convert.ToInt32(Me.getPromessaValue(ddlAcordo.SelectedIndex - 1, "TipFrmDscBnf")), _
                                                                            Convert.ToInt32(Me.getPromessaValue(ddlAcordo.SelectedIndex - 1, "TipDsnDscBnf")), _
                                                                            Convert.ToDateTime(Me.getPromessaValue(ddlAcordo.SelectedIndex - 1, "DatNgcPms")).Date(), _
                                                                            Convert.ToInt32(row.GetCellValue(grdNotasAssociadas.Columns.FromKey("NumNotFscFrnCtb"))), _
                                                                            Convert.ToString(row.GetCellValue(grdNotasAssociadas.Columns.FromKey("CodSeqPclNotFsc"))), _
                                                                            Convert.ToInt32(row.GetCellValue(grdNotasAssociadas.Columns.FromKey("NumSeqTitPgt"))), _
                                                                            Convert.ToDecimal(row.GetCellValue(grdNotasAssociadas.Columns.FromKey("VlrTitPgtUtzSbtPms"))))
                End If
            Next
        End If


        If rbIntegral.Checked Then
            'Notas Fiscais Associadas integrais
            iTipCsn = 6
        Else
            'Notas Fiscais Associadas parciais
            iTipCsn = 10
        End If

        ' Duplicatas disponiveis
        If grdNotasDisponiveis.Rows.Count > 0 Then
            For Each row As Infragistics.WebUI.UltraWebGrid.UltraGridRow In grdNotasDisponiveis.Rows

                If (Not row.Cells(1).Value Is String.Empty) And _
                   CType(row.Cells(10).Value, Boolean) Then
                    'Controller.ObterTrocaManualTituloPagamentoAcordoComercial(iTipCsn, _
                    '                                                          Convert.ToInt32(ucFornecedor.CodFornecedor), _
                    '                                                          Convert.ToInt32(ddlAcordo.SelectedValue), _
                    '                                                          Convert.ToInt32(Me.getPromessaValue(ddlDatPrvRcbPms.SelectedIndex, "CodEmp")), _
                    '                                                          Convert.ToInt32(Me.getPromessaValue(ddlDatPrvRcbPms.SelectedIndex, "CodFilEmp")), _
                    '                                                          Convert.ToInt32(row.GetCellValue(grdNotasDisponiveis.Columns.FromKey("CodEmpFrn"))), _
                    '                                                          Convert.ToDateTime(Me.getPromessaValue(ddlDatPrvRcbPms.SelectedIndex, "DatPrvRcbPms")).Date(), _
                    '                                                          Convert.ToInt32(Me.getPromessaValue(ddlDatPrvRcbPms.SelectedIndex, "TipFrmDscBnf")), _
                    '                                                          Convert.ToInt32(Me.getPromessaValue(ddlDatPrvRcbPms.SelectedIndex, "TipDsnDscBnf")), _
                    '                                                          Convert.ToDateTime(Me.getPromessaValue(ddlDatPrvRcbPms.SelectedIndex, "DatNgcPms")).Date(), _
                    '                                                          Convert.ToInt32(row.GetCellValue(grdNotasDisponiveis.Columns.FromKey("NumNotFscFrnCtb"))), _
                    '                                                          Convert.ToString(row.GetCellValue(grdNotasDisponiveis.Columns.FromKey("CodSeqPclNotFsc"))), _
                    '                                                          Convert.ToInt32(row.GetCellValue(grdNotasDisponiveis.Columns.FromKey("NumSeqTitPgt"))), _
                    '                                                          Convert.ToDecimal(row.GetCellValue(grdNotasDisponiveis.Columns.FromKey("VlrTitPgtUtzSbtPms"))))

                    Controller.ObterTrocaManualTituloPagamentoAcordoComercial(iTipCsn, _
                                                                              Convert.ToInt32(ucFornecedor.CodFornecedor), _
                                                                              Convert.ToInt32(ddlAcordo.SelectedValue), _
                                                                              Convert.ToInt32(Me.getPromessaValue(ddlAcordo.SelectedIndex - 1, "CodEmp")), _
                                                                              Convert.ToInt32(Me.getPromessaValue(ddlAcordo.SelectedIndex - 1, "CodFilEmp")), _
                                                                              Convert.ToInt32(row.GetCellValue(grdNotasDisponiveis.Columns.FromKey("CodEmpFrn"))), _
                                                                              Convert.ToDateTime(Me.getPromessaValue(ddlAcordo.SelectedIndex - 1, "DatPrvRcbPms")).Date(), _
                                                                              Convert.ToInt32(Me.getPromessaValue(ddlAcordo.SelectedIndex - 1, "TipFrmDscBnf")), _
                                                                              Convert.ToInt32(Me.getPromessaValue(ddlAcordo.SelectedIndex - 1, "TipDsnDscBnf")), _
                                                                              Convert.ToDateTime(Me.getPromessaValue(ddlAcordo.SelectedIndex - 1, "DatNgcPms")).Date(), _
                                                                              Convert.ToInt32(row.GetCellValue(grdNotasDisponiveis.Columns.FromKey("NumNotFscFrnCtb"))), _
                                                                              Convert.ToString(row.GetCellValue(grdNotasDisponiveis.Columns.FromKey("CodSeqPclNotFsc"))), _
                                                                              Convert.ToInt32(row.GetCellValue(grdNotasDisponiveis.Columns.FromKey("NumSeqTitPgt"))), _
                                                                              Convert.ToDecimal(row.GetCellValue(grdNotasDisponiveis.Columns.FromKey("VlrTitPgtUtzSbtPms"))))

                End If
            Next
        End If
    End Sub

#End Region

#End Region

End Class