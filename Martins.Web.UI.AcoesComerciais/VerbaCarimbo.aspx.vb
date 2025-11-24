Public Class VerbaCarimbo
    Inherits System.Web.UI.Page
#Region " Web Form Designer Generated Code "
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnGerarExtraAcordo As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnAtualizarExtraAcordo As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents ddl2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCODFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents cmbNomeFornecedor As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmbEmpenho As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtVLRNGCPMS As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents Linkbutton2 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents GrdVerbaCarimbo As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents lblPaginacao As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblFrame As System.Web.UI.WebControls.Label
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents DatasetVerbaCarimbo1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetVerbaCarimbo
    Protected WithEvents txtNomeFornecedor As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents btnBuscarFornecedor As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    'Protected WithEvents ddl1 As System.Web.UI.WebControls.DropDownList

    Private Sub InitializeComponent()
        Me.DatasetVerbaCarimbo1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetVerbaCarimbo
        CType(Me.DatasetVerbaCarimbo1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetVerbaCarimbo1
        '
        Me.DatasetVerbaCarimbo1.DataSetName = "DatasetVerbaCarimbo"
        Me.DatasetVerbaCarimbo1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetVerbaCarimbo1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

#Region "Eventos"
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not IsPostBack Then
                Me.IniciaPagina()
            End If


        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        If Me.ValidaCampo Then
            Me.CarregaGridVerbaCarimbo(False)
        End If

    End Sub

    Private Sub btnGerarExtraAcordo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGerarExtraAcordo.Click
        If Me.VerificaSelecaoNoGrd Then
            Dim codFornecedor As Decimal = CType(txtCODFRN.Text, Decimal)
            Dim nomeFornecedor As String = cmbNomeFornecedor.SelectedItem.Text
            Dim empenho As Decimal = CType(cmbEmpenho.SelectedValue, Decimal)
            Dim valorVerba As Decimal = CType(txtVLRNGCPMS.Text, Decimal)
            Dim indFilDtb As Decimal = -1
            Dim codfilEmp As Decimal = -1
            If Me.VerificaCarimboNoBanco(Me.BuscarCarimboSelecionadoGrd, indFilDtb, codfilEmp) Then
                Me.SalvarStatusCarimbo()
                HttpContext.Current.Response.Redirect("Acordo.aspx?codFornecedor=" & codFornecedor & "&nomeFornecedor=" & nomeFornecedor & "&empenho=" & empenho & "&valorVerba=" & valorVerba & "&tipoAcao=salvar&indFilDtb=" & indFilDtb.ToString() & "&codFilEmp=" & codfilEmp.ToString())
            End If
        Else
            Util.AdicionaJsAlert(Me.Page, "Por Favor selecione o(s) carimbos")
        End If
    End Sub

    Private Sub btnAtualizarExtraAcordo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAtualizarExtraAcordo.Click
        If Not Me.VerificaSelecaoNoGrd Then
            Util.AdicionaJsAlert(Me.Page, "Por Favor selecione o(s) carimbos")
        Else
            Dim codFornecedor As Decimal = CType(txtCODFRN.Text, Decimal)
            Dim nomeFornecedor As String = ""
            If (cmbNomeFornecedor.Items.Count = 0) Then
                nomeFornecedor = txtNomeFornecedor.Text
            Else
                nomeFornecedor = cmbNomeFornecedor.SelectedItem.Text
            End If

            Dim empenho As Decimal = CType(cmbEmpenho.SelectedValue, Decimal)
            Dim valorVerba As Decimal = CType(txtVLRNGCPMS.Text, Decimal)
            Dim Acordo As Decimal = 0

            If Not Request.QueryString("Acordo") Is Nothing Then
                Acordo = CType(Request.QueryString("Acordo").ToString, Decimal)
            End If
            Dim Filial As Decimal = 0
            If Not Request.QueryString("Filial") Is Nothing Then
                Filial = CType(Request.QueryString("Filial").ToString, Decimal)
            End If
            Dim DataNegociacao As String = String.Empty
            If Not Request.QueryString("DataNegociacao") Is Nothing Then
                DataNegociacao = Request.QueryString("DataNegociacao").ToString
            End If
            Dim indFilDtb As Decimal = -1
            Dim codFilEmp As Decimal = -1
            If Me.VerificaCarimboNoBanco(Me.BuscarCarimboSelecionadoGrd, indFilDtb, codFilEmp) Then
                Me.SalvarStatusCarimbo()
                HttpContext.Current.Response.Redirect("Acordo.aspx?codFornecedor=" & codFornecedor & "&nomeFornecedor=" & nomeFornecedor & "&empenho=" & empenho & "&valorVerba=" & valorVerba & "&Acordo=" & Acordo & "&Filial=" & Filial & "&DataNegociacao=" & DataNegociacao & "&tipoAcao=manter&indFilDtb=" & indFilDtb.ToString() & "&codFilEmp=" & codFilEmp.ToString())
            End If
        End If

     
    End Sub


#End Region


#Region "Metodos"

    Private Sub IniciaPagina()
        btnAtualizarExtraAcordo.Visible = False
        Me.cmbNomeFornecedor.Visible = False
        'Me.CarregaComboFornecedor()
        Me.CarregaComboEmpenho()
        If Not (Request.QueryString("tipoAcao") Is Nothing) Then
            Me.ObterParametrosQueryString()
        End If
    End Sub
    Private Function VerificaSelecaoNoGrd() As Boolean
        Dim flagChek As Boolean = False
        Dim templColumn As Infragistics.WebUI.UltraWebGrid.TemplatedColumn
        Dim cellItem As Infragistics.WebUI.UltraWebGrid.CellItem
        Dim cellItems As ArrayList
        Dim checkbox As CheckBox
        templColumn = CType(Me.GrdVerbaCarimbo.Columns.FromKey("Sel"), Infragistics.WebUI.UltraWebGrid.TemplatedColumn)
        cellItems = templColumn.CellItems
        For Each item As Object In cellItems
            cellItem = CType(item, Infragistics.WebUI.UltraWebGrid.CellItem)
            checkbox = CType(cellItem.FindControl("chkSel"), CheckBox)
            If checkbox.Checked Then
                flagChek = True
                Exit For
            End If
        Next
        Return flagChek
    End Function

    Private Sub CarregaGridVerbaCarimbo(ByVal voltaPaginaAcordo As Boolean)
        GrdVerbaCarimbo.Rows.Clear()
        Dim Fornecedor As Decimal = 0
        Dim Empenho As Decimal = 0
        Dim indStaMcoVbaFrn As Decimal = 1
        Dim acordo As Decimal = 0
        If Not Request.QueryString("Acordo") Is Nothing Then
            acordo = CType(Request.QueryString("Acordo").ToString, Decimal)
        End If

        If txtCODFRN.Text <> String.Empty Then
            Fornecedor = CType(txtCODFRN.Text, Decimal)
        End If

        If cmbEmpenho.SelectedValue <> "" Then
            Empenho = CType(cmbEmpenho.SelectedValue, Decimal)
        End If


        Me.DatasetVerbaCarimbo1 = Controller.ObterVerbaCarimboPesquisa(indStaMcoVbaFrn, Fornecedor, Empenho, 0)
        If voltaPaginaAcordo Then
            Me.DatasetVerbaCarimbo1.Merge(Controller.ObterVerbaCarimboPesquisa(4, Fornecedor, Empenho, acordo))
        End If
        If Me.DatasetVerbaCarimbo1.CADMCOVBAFRNPesquisa.Rows.Count > 0 Then
            Me.GrdVerbaCarimbo.DataSource = Me.DatasetVerbaCarimbo1.CADMCOVBAFRNPesquisa
            GrdVerbaCarimbo.DataBind()
            With Me.GrdVerbaCarimbo
                If Controller.PageSize > 0 Then
                    .DisplayLayout.Pager.AllowPaging = True
                    .DisplayLayout.Pager.Alignment = Infragistics.WebUI.UltraWebGrid.PagerAlignment.Center
                    .DisplayLayout.Pager.PageSize = Controller.PageSize
                End If
                .DataBind()
            End With
            Me.MantemValoresControlesGrid()
        Else
            Util.AdicionaJsAlert(Me.Page, "Não foi encontrado nenhum registro!", True)
        End If
    End Sub

    Private Function ValidaCampo() As Boolean

        If txtCODFRN.Text = String.Empty Then
            Util.AdicionaJsAlert(Me.Page, "Informe codigo Fornecedor")
            Return False

        End If

        If cmbNomeFornecedor.SelectedValue = "0" Then
            Util.AdicionaJsAlert(Me.Page, "Selecione  Fornecedor")
            Return False
        End If

        If cmbEmpenho.SelectedValue = "0" Then
            Util.AdicionaJsAlert(Me.Page, "selecione Destino Verba")
            Return False

        End If
        Return True

    End Function

    Private Sub CarregaComboEmpenho()
        Dim dstEmpenho As New wsAcoesComerciais.DatasetEmpenho
        dstEmpenho = Controller.ObterComboEmpenho(1)

        With cmbEmpenho
            .DataSource = dstEmpenho
            .DataMember = "T0109059Pesquisa"
            .DataTextField = "DESDSNDSCBNF".ToUpper
            .DataValueField = "TIPDSNDSCBNF"
            .DataBind()
            .Items.Insert(0, New ListItem("(Selecione)", "0"))
        End With
    End Sub

    Private Sub MantemValoresControlesGrid()
        Dim templColumn As Infragistics.WebUI.UltraWebGrid.TemplatedColumn
        Dim cellItem As Infragistics.WebUI.UltraWebGrid.CellItem
        Dim cellItems As ArrayList
        Dim checkbox As checkbox
        Dim index As Integer = 0
        Dim valorPrevisto As Decimal
        templColumn = CType(Me.GrdVerbaCarimbo.Columns.FromKey("Sel"), Infragistics.WebUI.UltraWebGrid.TemplatedColumn)
        cellItems = templColumn.CellItems
        index = 0
        txtVLRNGCPMS.Text = ""
        For Each item As Object In cellItems
            valorPrevisto = CType(Me.GrdVerbaCarimbo.Rows(index).Cells.FromKey("VALOR_PREVISTO").Value, Decimal)
            cellItem = CType(item, Infragistics.WebUI.UltraWebGrid.CellItem)
            checkbox = CType(cellItem.FindControl("chkSel"), checkbox)
            checkbox.Attributes.Add("Onclick", "javascript:somaValorVerba('" & checkbox.ClientID & "'," & valorPrevisto.ToString & ")")
            Me.GrdVerbaCarimbo.Rows(index).Cells.FromKey("DATA").Text = Format(CDate(Me.GrdVerbaCarimbo.Rows(index).Cells.FromKey("DATA").Value), "dd/MM/yyyy")
            Me.GrdVerbaCarimbo.Rows(index).Cells.FromKey("VALOR_PREVISTO").Text = FormatNumber(Me.GrdVerbaCarimbo.Rows(index).Cells.FromKey("VALOR_PREVISTO").Value, 2)
            checkbox.Checked = Me.GrdVerbaCarimbo.Rows(index).Cells.FromKey("INDSTAMCOVBAFRN").Value.ToString.Equals("4")
            If checkbox.Checked Then
                Me.txtVLRNGCPMS.ValueDecimal += CDec(Me.GrdVerbaCarimbo.Rows(index).Cells.FromKey("VALOR_PREVISTO").Text)
            End If
            index += 1
        Next
    End Sub

    Private Sub ObterParametrosQueryString()

        If Not Request.QueryString("tipoAcao") Is Nothing Then
            btnAtualizarExtraAcordo.Visible = True
            Dim codFornecedor As Decimal = CType(Request.QueryString("codFornecedor").ToString, Decimal)
            'Dim nomeFornecedor As String = (Request.QueryString("nomeFornecedor").ToString)
            Dim empenho As Decimal = CType(Request.QueryString("empenho").ToString, Decimal)
            Dim valorVerba As Decimal = CType(Request.QueryString("valorVerba").ToString, Decimal)
            Dim NomeFornecedor As String = Request.QueryString("NomeFornecedor").ToString

            txtCODFRN.Text = codFornecedor.ToString
            Me.BuscaFornecedorPeloCodigo()
            cmbNomeFornecedor.SelectedValue = codFornecedor.ToString
            cmbEmpenho.SelectedValue = empenho.ToString
            txtVLRNGCPMS.ValueDecimal = valorVerba
            txtNomeFornecedor.Text = NomeFornecedor

            txtCODFRN.Enabled = False
            cmbNomeFornecedor.Enabled = False
            cmbEmpenho.Enabled = False
            txtVLRNGCPMS.Enabled = False
            txtNomeFornecedor.Enabled = False
            btnGerarExtraAcordo.Visible = False
            Me.CarregaGridVerbaCarimbo(True)
        End If
    End Sub

    Private Function BuscarCarimboSelecionadoGrd() As Object()
        Dim templColumn As Infragistics.WebUI.UltraWebGrid.TemplatedColumn
        Dim cellItem As Infragistics.WebUI.UltraWebGrid.CellItem
        Dim cellItems As ArrayList
        Dim checkbox As checkbox
        Dim indexGrid As Integer = 0
        Dim indexList As Integer = 0
        Dim listCarimbo() As Object
        templColumn = CType(Me.GrdVerbaCarimbo.Columns.FromKey("Sel"), Infragistics.WebUI.UltraWebGrid.TemplatedColumn)
        cellItems = templColumn.CellItems
        ReDim listCarimbo(cellItems.Count)
        For Each item As Object In cellItems
            cellItem = CType(item, Infragistics.WebUI.UltraWebGrid.CellItem)
            checkbox = CType(cellItem.FindControl("chkSel"), checkbox)
            If checkbox.Checked Then
                listCarimbo(indexList) = Me.GrdVerbaCarimbo.Rows(indexGrid).Cells.FromKey("CARIMBO").Value
                indexList += 1
            End If
            indexGrid += 1
        Next
        Return listCarimbo
    End Function

    Private Function VerificaCarimboNoBanco(ByVal listCarimbo() As Object, ByRef indFilDtb As Decimal, ByRef codFilEmp As Decimal) As Boolean
        Dim Acordo As Decimal = 0
        If Not Request.QueryString("Acordo") Is Nothing Then
            Acordo = CType(Request.QueryString("Acordo").ToString, Decimal)
        End If

        Dim mensagem As String = String.Empty
        Dim dstVerbaCarimbo As New wsAcoesComerciais.DatasetVerbaCarimbo

        dstVerbaCarimbo = Controller.ObterVerificarCarimbo(listCarimbo)
        For i As Integer = 0 To dstVerbaCarimbo.CADMCOVBAFRNVerificarCarimbo.Count - 1
            If dstVerbaCarimbo.CADMCOVBAFRNVerificarCarimbo(i).INDSTAMCOVBAFRN <> 1 And (dstVerbaCarimbo.CADMCOVBAFRNVerificarCarimbo(i).CODPMS = 0 OrElse dstVerbaCarimbo.CADMCOVBAFRNVerificarCarimbo(i).CODPMS <> Acordo) Then
                mensagem += dstVerbaCarimbo.CADMCOVBAFRNVerificarCarimbo(i).CODMCOVBAFRN.ToString & " ,"
            End If

            If indFilDtb <> 1 Then
                indFilDtb = dstVerbaCarimbo.CADMCOVBAFRNVerificarCarimbo(i).INDFILDTB
                codFilEmp = dstVerbaCarimbo.CADMCOVBAFRNVerificarCarimbo(i).CODFILEMP
            End If
            If indFilDtb >= 0 Then
                If indFilDtb <> dstVerbaCarimbo.CADMCOVBAFRNVerificarCarimbo(i).INDFILDTB Then
                    Util.AdicionaJsAlert(Me.Page, "Os carimbos selecionados devem ser da mesma filial de distribuição para geração dos extra acordos.")
                    Return False
                End If
            End If
        Next
        If mensagem <> String.Empty Then
            mensagem.Remove(mensagem.LastIndexOf(","), 1)
            Util.AdicionaJsAlert(Me.Page, "Os Carimbos " & mensagem & "ja estão em processo de cadastramento")
            Return False
        End If
        Return True
    End Function

    Private Sub SalvarStatusCarimbo()
        Dim acordo As Decimal = 0
        If Not Request.QueryString("Acordo") Is Nothing Then
            acordo = CType(Request.QueryString("Acordo").ToString, Decimal)
        End If
        Dim dstVerbaCarimbo As New wsAcoesComerciais.DatasetVerbaCarimbo
        Dim templColumn As Infragistics.WebUI.UltraWebGrid.TemplatedColumn
        Dim cellItem As Infragistics.WebUI.UltraWebGrid.CellItem
        Dim cellItems As ArrayList
        Dim checkbox As checkbox
        Dim indexGrid As Integer = 0
        Dim codMcoVbaFrn As Decimal
        templColumn = CType(Me.GrdVerbaCarimbo.Columns.FromKey("Sel"), Infragistics.WebUI.UltraWebGrid.TemplatedColumn)
        cellItems = templColumn.CellItems
        For Each item As Object In cellItems
            cellItem = CType(item, Infragistics.WebUI.UltraWebGrid.CellItem)
            checkbox = CType(cellItem.FindControl("chkSel"), checkbox)
            codMcoVbaFrn = CType(GrdVerbaCarimbo.Rows(indexGrid).Cells.FromKey("CARIMBO").Value(), Decimal)
            dstVerbaCarimbo.Merge(Controller.ObterCadCarimboVerbaFornecByPk(codMcoVbaFrn))
            If checkbox.Checked Then
                dstVerbaCarimbo.CADMCOVBAFRN.FindByCODMCOVBAFRN(codMcoVbaFrn).INDSTAMCOVBAFRN = 4
            ElseIf dstVerbaCarimbo.CADMCOVBAFRN.FindByCODMCOVBAFRN(codMcoVbaFrn).CODPMS = acordo Then
                dstVerbaCarimbo.CADMCOVBAFRN.FindByCODMCOVBAFRN(codMcoVbaFrn).INDSTAMCOVBAFRN = 1
                dstVerbaCarimbo.CADMCOVBAFRN.FindByCODMCOVBAFRN(codMcoVbaFrn).CODPMS = 0
                dstVerbaCarimbo.CADMCOVBAFRN.FindByCODMCOVBAFRN(codMcoVbaFrn).DATNGCPMS = New Date(1, 1, 1)
            End If
            indexGrid += 1
        Next
        Controller.AtualizarCadCarimboVerbaFornec(dstVerbaCarimbo)
    End Sub

    Private Sub BuscaFornecedorPeloCodigo()
        Dim datasetFornecedor As wsAcoesComerciais.dataSetDivisaoFornecedor
        Dim flagMostrarCombo As Boolean

        If Not (IsNumeric(txtCODFRN.Text)) Then Exit Sub

        flagMostrarCombo = False
        datasetFornecedor = Controller.ObterDivisaoFornecedor(1, CLng(txtCODFRN.Text))
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
                .Width = System.Web.UI.WebControls.Unit.Parse("280px")
            Else
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
            End If
        End With
        With txtNomeFornecedor
            .Visible = Not flagMostrarCombo
            .Enabled = Not flagMostrarCombo
            If Not flagMostrarCombo Then
                .Width = System.Web.UI.WebControls.Unit.Parse("280px")
            Else
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
            End If
        End With
        Util.AdicionaJsFocus(Me.Page, CType(Me.cmbNomeFornecedor, WebControl))
    End Sub



#End Region


#Region "Busca Fornecedor"

    Private Sub btnBuscarFornecedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarFornecedor.Click
        Dim datasetFornecedor As wsAcoesComerciais.dataSetDivisaoFornecedor
        Dim flagMostrarCombo As Boolean = False

        If txtNomeFornecedor.Visible Then
            If txtNomeFornecedor.Text.Trim.Length < 3 Then
                Page.RegisterStartupScript("Alerta", "<script>alert('É obrigatório digitar no mínimo 3 caracteres do nome antes de pesquisar.');</script>")
                Exit Sub
            End If

            datasetFornecedor = Controller.ObterDivisoesFornecedor(1, txtNomeFornecedor.Text)
            If datasetFornecedor.T0100426.Rows.Count > 0 Then
                Util.carregarCmbDivisaoFornecedor(datasetFornecedor, cmbNomeFornecedor, Nothing)
                txtCODFRN.Text = cmbNomeFornecedor.SelectedValue
                flagMostrarCombo = True
            Else
                Util.AdicionaJsAlert(Me.Page, "Registro não encontrado")
            End If

            With cmbNomeFornecedor
                .Visible = flagMostrarCombo
                .Enabled = flagMostrarCombo
                If flagMostrarCombo Then
                    .Width = System.Web.UI.WebControls.Unit.Parse("280px")
                Else
                    .Width = System.Web.UI.WebControls.Unit.Parse("0px")
                End If
            End With
            With txtNomeFornecedor
                .Visible = Not flagMostrarCombo
                .Enabled = Not flagMostrarCombo
                If Not flagMostrarCombo Then
                    .Width = System.Web.UI.WebControls.Unit.Parse("280px")
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
                .Width = System.Web.UI.WebControls.Unit.Parse("280px")
            End With
        End If

    End Sub

    Private Sub cmbNomeFornecedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNomeFornecedor.SelectedIndexChanged
        txtCODFRN.Text = cmbNomeFornecedor.SelectedValue
    End Sub

    Private Sub txtCODFRN_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtCODFRN.ValueChange
        Me.BuscaFornecedorPeloCodigo()
    End Sub

#End Region


   



    
End Class
