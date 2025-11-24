Public Class ucContratoPeriodo
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetContrato1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContrato
        CType(Me.DatasetContrato1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetContrato1
        '
        Me.DatasetContrato1.DataSetName = "DatasetContrato"
        Me.DatasetContrato1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetContrato1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents txtDATINIPOD As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents lblErroDATINIPOD As System.Web.UI.WebControls.Label
    Protected WithEvents LblErroDATFIMPOD As System.Web.UI.WebControls.Label
    Protected WithEvents grdPeriodos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetContrato1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContrato
    Protected WithEvents txtDATFIMPOD As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtNUMREFPOD As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents cmbNUMCSLCTTFRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNUMCSLCTTFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents cmbTIPPODCTTFRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtTIPPODCTTFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents lblErroNUMCSLCTTFRN As System.Web.UI.WebControls.Label
    Protected WithEvents lblErroTIPPODCTTFRN As System.Web.UI.WebControls.Label
    Protected WithEvents cmbDATINIPOD As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TD1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD2 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD3 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD4 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD5 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD6 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents btnTrimestralidade As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnExcluir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cmdAtualizar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cmdNova As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnAnualidade As System.Web.UI.WebControls.LinkButton

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

    Private Shadows Property Page() As Martins.Web.UI.AcoesComerciais.Contrato
        Get
            Return DirectCast(MyBase.Page, Martins.Web.UI.AcoesComerciais.Contrato)
        End Get
        Set(ByVal Value As Martins.Web.UI.AcoesComerciais.Contrato)
            MyBase.Page = Value
        End Set
    End Property

#End Region

#Region " Eventos "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not IsPostBack Then
                CarregaControles()
            End If
            btnExcluir.Attributes.Add("OnClick", "javascript:return confirm('Deseja excluir este registro ?')")
            TD1.Visible = False
            TD2.Visible = False
            TD3.Visible = False
            TD4.Visible = False
            TD5.Visible = False
            TD6.Visible = False
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub cmdNova_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            CarregaControles()
            Util.AdicionaJsFocus(MyBase.Page, CType(txtNUMCSLCTTFRN, WebControl), Util.tipoDeComponente.InfragisticsTxt)

            Dim ctrlLblErro As WebControl() = New WebControl() {lblErroNUMCSLCTTFRN, _
                                                                lblErroTIPPODCTTFRN, _
                                                                lblErroDATINIPOD, _
                                                                LblErroDATFIMPOD}
            Util.MostraControles(ctrlLblErro, True)
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        Try
            If Page.flagContratoAtivo = False Then
                Util.AdicionaJsAlert(MyBase.Page, "Esse contrato não está ativo")
                Exit Sub
            End If

            'Comentado em 15/06/2007 - Solicitado por Elisangela, ela justificou que mesmo
            'tendo existido apuração deverá permitir gerar período porque pode ter sido incluído
            'nova cláusulas

            'Descomentado 02/07/2007 validação porque agora passou a verificar se existe apuração 
            'para cláusula e não para o contrato como anteriormente
            If Page.existeApuracaoParaEsseContrato(txtNUMCSLCTTFRN.ValueDecimal) Then
                Util.AdicionaJsAlert(MyBase.Page, "Existe apuração para essa cláusula, não é permitido gerar período")
                Exit Sub
            End If

            If Me.SalvarDados() Then
                Page.dsContrato.Merge(Controller.ObterContratosXPeriodos(0, Page.NUMCTTFRN, 0, 0).T0124988)
                Me.BindGrdPeriodos()

                'habilita botão que permite duplicar dados bônus para anualidade
                If cmbNUMCSLCTTFRN.SelectedValue = "2" Then
                    If Not Existe_Anualidade() Then
                        btnAnualidade.Enabled = True
                    End If
                    If Not Existe_Trimestralidade() Then
                        btnTrimestralidade.Enabled = (cmbTIPPODCTTFRN.SelectedValue = "1")
                    End If
                End If
            End If
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click
        Try
            If Page.flagContratoAtivo = False Then
                Util.AdicionaJsAlert(MyBase.Page, "Esse contrato não está ativo")
                Exit Sub
            End If

            'Regra correta, confirmado com Severton em 02/07/2007
            If Page.existeApuracaoParaEsseContrato(txtNUMCSLCTTFRN.ValueDecimal) Then
                Util.AdicionaJsAlert(MyBase.Page, "Existe apuração para essa cláusula, não é permitido excluir período")
                Exit Sub
            End If

            If Me.ExcluirPeriodos() Then
                Page.dsContrato.T0124988.Rows.Clear()
                Page.dsContrato.Merge(Controller.ObterContratosXPeriodos(0, Page.NUMCTTFRN, 0, 0).T0124988)
                Me.BindGrdPeriodos()
            End If
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub cmbNUMCSLCTTFRN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNUMCSLCTTFRN.SelectedIndexChanged
        Try
            txtNUMCSLCTTFRN.Text = cmbNUMCSLCTTFRN.SelectedValue
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub cmbTIPPODCTTFRN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTIPPODCTTFRN.SelectedIndexChanged
        Try
            txtTIPPODCTTFRN.Text = cmbTIPPODCTTFRN.SelectedValue
            preenche_ComboData()
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub GrdPeriodos_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPeriodos.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Dim linha As wsAcoesComerciais.DatasetContrato.T0124988Row
                linha = Me.Page.dsContrato.T0124988.FindByNUMCTTFRNNUMCSLCTTFRNTIPPODCTTFRNNUMREFPODDATINIPOD(Convert.ToDecimal(e.Item.Cells(6).Text), _
                                                                                                              Convert.ToDecimal(e.Item.Cells(7).Text), _
                                                                                                              Convert.ToDecimal(e.Item.Cells(8).Text), _
                                                                                                              Convert.ToDecimal(e.Item.Cells(3).Text), _
                                                                                                              Convert.ToDateTime(e.Item.Cells(4).Text))
                If Not linha Is Nothing Then
                    PreencheControles(linha)
                End If

            End If

        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub grdPeriodos_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdPeriodos.PageIndexChanged
        Try
            DatasetContrato1 = Page.dsContrato
            Me.grdPeriodos.CurrentPageIndex = e.NewPageIndex
            grdPeriodos.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtTIPPODCTTFRN_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtTIPPODCTTFRN.ValueChange
        cmbTIPPODCTTFRN_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub btnTrimestralidade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrimestralidade.Click
        Try
            'Validação
            If Page.flagContratoAtivo = False Then
                Util.AdicionaJsAlert(MyBase.Page, "Esse contrato não está ativo")
                Exit Sub
            End If
            If Not IsNumeric(cmbNUMCSLCTTFRN.SelectedValue) Then
                Util.AdicionaJsAlert(MyBase.Page, "Selecione uma cláusula")
                Exit Sub
            End If
            If Not Page.existeFaixaParaClausula(CType(cmbNUMCSLCTTFRN.SelectedValue, Decimal)) Then
                Util.AdicionaJsAlert(MyBase.Page, "Digite as faixas antes de gerar a trimestralidade")
                Exit Sub
            End If

            Controller.GerarClausulaTrimestralidade(Page.NUMCTTFRN)
            btnTrimestralidade.Enabled = False
            Page.atualizarGridNaTabClausulas()

            If Me.btnAnualidade.Enabled = False Then
                Page.SalvarEContinuar()
            End If

        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub btnAnualidade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnualidade.Click
        Try
            'Validação
            If Page.flagContratoAtivo = False Then
                Util.AdicionaJsAlert(MyBase.Page, "Esse contrato não está ativo")
                Exit Sub
            End If
            If Not IsNumeric(cmbNUMCSLCTTFRN.SelectedValue) Then
                Util.AdicionaJsAlert(MyBase.Page, "Selecione uma cláusula")
                Exit Sub
            End If
            If Not Page.existeFaixaParaClausula(CType(cmbNUMCSLCTTFRN.SelectedValue, Decimal)) Then
                Util.AdicionaJsAlert(MyBase.Page, "Digite as faixas antes de gerar a anualidade")
                Exit Sub
            End If

            Controller.GerarClausulaAnualidade(Page.NUMCTTFRN)
            btnAnualidade.Enabled = False
            Page.atualizarGridNaTabClausulas()
            Page.SalvarEContinuar()
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

#End Region

#Region " Metodos "

#Region " Metodos de Carga "

    Private Sub CarregaControles()
        Me.CarregarCmbNUMCSLCTTFRN()
        Me.CarregarCmbTIPPODCTTFRN()
        Me.BindGrdPeriodos()
    End Sub

    Public Sub CarregarCmbNUMCSLCTTFRN()
        Me.Page.dsContrato.Merge(Controller.ObterContratoXClausulaContrato(Nothing, Nothing, Nothing, Decimal.Zero, Convert.ToDecimal(Me.Page.NUMCTTFRN)), False, MissingSchemaAction.Ignore)

        With cmbNUMCSLCTTFRN
            If Me.Page.dsContrato.T0124953.Rows.Count = 0 Then
                Me.Page.dsContrato.Merge(Controller.ObterClausulasContrato("", 0).T0124953, False, MissingSchemaAction.Ignore)
            End If
            .Items.Clear()
            For Each drT0124961 As wsAcoesComerciais.DatasetContrato.T0124961Row In Me.Page.dsContrato.T0124961.Rows
                'As vezes a célula foi desativada é o usuário escolhe ela para ser consultada
                'If drT0124961.IsDATDSTCSLNull Then
                .Items.Add(New ListItem(drT0124961.NUMCSLCTTFRN.ToString() & " - " & drT0124961.T0124953Row.DESCSLCTTFRN, drT0124961.NUMCSLCTTFRN.ToString()))
                'End If
            Next
            .Items.Insert(0, New ListItem(String.Empty, String.Empty))
        End With
    End Sub

    Private Sub CarregarCmbTIPPODCTTFRN()
        Dim ds As wsAcoesComerciais.DatasetTipoPeriodo = _
            Controller.ObterTiposPeriodo(String.Empty, Decimal.Zero)

        With cmbTIPPODCTTFRN
            .Items.Clear()
            .DataSource = ds.T0124970
            .DataTextField = ds.T0124970.DESPODCTTFRNColumn.ColumnName
            .DataValueField = ds.T0124970.TIPPODCTTFRNColumn.ColumnName
            .DataBind()
            .Items.Insert(0, New ListItem(String.Empty, String.Empty))
            .SelectedIndex = 0
        End With

        cmbTIPPODCTTFRN_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub BindGrdPeriodos()
        Try
            Me.DatasetContrato1 = Me.Page.dsContrato
            Me.grdPeriodos.DataBind()
        Catch ex As Exception
            If Me.grdPeriodos.CurrentPageIndex > 0 Then
                Me.grdPeriodos.CurrentPageIndex = 0
                BindGrdPeriodos()
            Else
                Controller.TrataErro(MyBase.Page, ex)
            End If
        End Try
    End Sub

#End Region

#Region " Metodos de Controles "

    Protected Function consultarDESCSLCTTFRN(ByVal vDad As String) As String
        Dim result As String = String.Empty

        If vDad Is Nothing Then
            result = ""
        ElseIf vDad = "" Then
            result = ""
        ElseIf Not IsNumeric(vDad) Then
            result = ""
        Else
            Try
                Dim linha As wsAcoesComerciais.DatasetContrato.T0124953Row = Me.Page.dsContrato.T0124953.FindByNUMCSLCTTFRN(Convert.ToDecimal(vDad))
                If Not linha Is Nothing Then
                    result = linha.NUMCSLCTTFRN.ToString("0000") & " - " & linha.DESCSLCTTFRN
                End If
            Catch ex As Exception
                result = ""
            End Try
        End If

        Return result
    End Function

    Protected Function consultarDESPODCTTFRN(ByVal vDad As String) As String
        Dim result As String = String.Empty

        If vDad Is Nothing Then
            result = ""
        ElseIf vDad = "" Then
            result = ""
        ElseIf Not IsNumeric(vDad) Then
            result = ""
        Else
            Try
                'Consulta o descrição a partir do combo
                Dim list As ListItem
                list = cmbTIPPODCTTFRN.Items.FindByValue(vDad)
                If Not list Is Nothing Then
                    result = list.Text
                End If
            Catch ex As Exception
                result = ""
            End Try
        End If

        Return result
    End Function

#End Region

#Region " Metodos de Regras de Negocio "

    Private Function ValidarDados() As Boolean
        Dim result As Boolean
        Dim mensagemErro As String = String.Empty
        Dim deuFoco As Boolean

        colocaMesmoValorDosCombosNoText()

        Try
            If Val(cmbNUMCSLCTTFRN.SelectedValue) <= 0 Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "cláusula inválida"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(cmbNUMCSLCTTFRN, WebControl))
                End If
                deuFoco = True
                lblErroNUMCSLCTTFRN.Visible = True
            Else
                lblErroNUMCSLCTTFRN.Visible = False
            End If

            If cmbTIPPODCTTFRN.SelectedValue Is String.Empty Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "período inválido"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(cmbTIPPODCTTFRN, WebControl))
                End If
                deuFoco = True
                lblErroTIPPODCTTFRN.Visible = True
            Else
                lblErroTIPPODCTTFRN.Visible = False
            End If

            'If txtNUMCSLCTTFRN.ValueInt.Equals(3) Then  ' Anualidade
            '    'Mensagem
            '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '    mensagemErro &= "não é permitido editar clásula de Anualidade, ela é gerada pelo sistema"
            'ElseIf txtNUMCSLCTTFRN.ValueInt.Equals(10) Then  ' Trimestralidade
            '    'Mensagem
            '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '    mensagemErro &= "não é permitido editar clásula de Trimestralidade, ela é gerada pelo sistema"
            'End If

            'If txtDATINIPOD.Text Is String.Empty Then
            '    'Mensagem
            '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '    mensagemErro &= "Data inicial do período inválida"

            '    If Not deuFoco Then
            '        Util.AdicionaJsFocus(MyBase.Page, CType(txtDATINIPOD, WebControl), Util.tipoDeComponente.InfragisticsTxt)
            '    End If
            '    deuFoco = True
            '    lblErroDATINIPOD.Visible = True
            'Else
            '    lblErroDATINIPOD.Visible = False
            'End If

            'If txtDATFIMPOD.Text Is String.Empty Then
            '    'Mensagem
            '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '    mensagemErro &= "Data final do período inválida"

            '    If Not deuFoco Then
            '        Util.AdicionaJsFocus(MyBase.Page, CType(txtDATFIMPOD, WebControl), Util.tipoDeComponente.InfragisticsTxt)
            '    End If
            '    deuFoco = True
            '    LblErroDATFIMPOD.Visible = True
            'Else
            '    LblErroDATFIMPOD.Visible = False
            'End If

            'Mostra mensagem de erro
            If mensagemErro.Trim() <> String.Empty Then
                Page.RegisterStartupScript("Alerta", "<script>alert('" & (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1) & "');</script>")
                Return False
            End If

            Return True
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try

    End Function

    Private Sub colocaMesmoValorDosCombosNoText()
        txtNUMCSLCTTFRN.Text = cmbNUMCSLCTTFRN.SelectedValue
        txtTIPPODCTTFRN.Text = cmbTIPPODCTTFRN.SelectedValue
    End Sub

    Private Sub PreencheLinhaT0124988(ByRef dr As wsAcoesComerciais.DatasetContrato.T0124988Row)
        With dr
            .NUMCTTFRN = Page.NUMCTTFRN
            .NUMCSLCTTFRN = Convert.ToDecimal(cmbNUMCSLCTTFRN.SelectedValue)
            .TIPPODCTTFRN = Convert.ToDecimal(cmbTIPPODCTTFRN.SelectedValue)
            .DATINIPOD = txtDATINIPOD.Date
            .DATFIMPOD = txtDATFIMPOD.Date

            If dr.RowState = DataRowState.Added Then
                .NUMREFPOD = 0
            End If
        End With
    End Sub

    Private Sub PreencheControles(ByRef dr As wsAcoesComerciais.DatasetContrato.T0124988Row)
        With dr

            If Not cmbNUMCSLCTTFRN.Items.FindByValue(dr.NUMCSLCTTFRN.ToString) Is Nothing Then
                txtNUMCSLCTTFRN.Text = dr.NUMCSLCTTFRN.ToString
                cmbNUMCSLCTTFRN.SelectedValue = dr.NUMCSLCTTFRN.ToString
            End If
            If Not cmbTIPPODCTTFRN.Items.FindByValue(dr.TIPPODCTTFRN.ToString) Is Nothing Then
                txtTIPPODCTTFRN.Text = dr.TIPPODCTTFRN.ToString
                cmbTIPPODCTTFRN.SelectedValue = dr.TIPPODCTTFRN.ToString
            End If
            txtDATINIPOD.Date = dr.DATINIPOD
            txtDATFIMPOD.Date = dr.DATFIMPOD
        End With
    End Sub

    Private Function SalvarDados() As Boolean
        Try
            SalvarDados = False
            If Me.ValidarDados() Then

                Try
                    If Page.flagInclusao Then
                        Page.SalvarEContinuar()
                    End If

                    Controller.GerarPeriodosParaClausulaDeContrato(Convert.ToInt32(Page.NUMCTTFRN), _
                                                                   Convert.ToInt32(cmbNUMCSLCTTFRN.SelectedValue), _
                                                                   Convert.ToInt32(cmbTIPPODCTTFRN.SelectedValue))
                Catch ex As Exception
                    Util.AdicionaJsAlert(MyBase.Page, "Erro na geração dos períodos")
                    Exit Function
                End Try

                SalvarDados = True
            End If
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Function

    Private Function ExcluirPeriodos() As Boolean
        Try
            ExcluirPeriodos = False
            If Me.ValidarDados() Then

                Try
                    Dim ds As New wsAcoesComerciais.DatasetContrato
                    ds.EnforceConstraints = False
                    ds.Merge(Page.dsContrato.T0124988)

                    For i As Integer = ds.T0124988.Rows.Count - 1 To 0 Step -1
                        Dim linha As wsAcoesComerciais.DatasetContrato.T0124988Row
                        linha = Page.dsContrato.T0124988(i)

                        If linha.NUMCTTFRN = Convert.ToInt32(Page.NUMCTTFRN) And _
                           linha.NUMCSLCTTFRN = Convert.ToInt32(cmbNUMCSLCTTFRN.SelectedValue) And _
                           linha.TIPPODCTTFRN = Convert.ToInt32(cmbTIPPODCTTFRN.SelectedValue) Then
                            If linha.RowState = DataRowState.Added Then
                                Page.dsContrato.T0124988.RemoveT0124988Row(linha)
                            Else
                                Page.dsContrato.T0124988(i).Delete()
                            End If
                        End If
                    Next
                    Controller.AtualizarContrato(Page.dsContrato)

                Catch ex As Exception
                    Util.AdicionaJsAlert(MyBase.Page, "Erro na exclusão dos períodos")
                    Exit Function
                End Try

                ExcluirPeriodos = True
            End If
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Function

    Private Function ExcluirLinha() As Boolean
        ExcluirLinha = False
        If Me.ValidarDados() Then
            If Not Page.dsContrato.T0124988.FindByNUMCTTFRNNUMCSLCTTFRNTIPPODCTTFRNNUMREFPODDATINIPOD(Page.NUMCTTFRN, Convert.ToDecimal(cmbNUMCSLCTTFRN.SelectedValue), Convert.ToDecimal(cmbTIPPODCTTFRN.SelectedValue), 0, txtDATINIPOD.Date) Is Nothing Then
                Dim dr As wsAcoesComerciais.DatasetContrato.T0124988Row = Page.dsContrato.T0124988.FindByNUMCTTFRNNUMCSLCTTFRNTIPPODCTTFRNNUMREFPODDATINIPOD(Page.NUMCTTFRN, Convert.ToDecimal(cmbNUMCSLCTTFRN.SelectedValue), Convert.ToDecimal(cmbTIPPODCTTFRN.SelectedValue), txtNUMREFPOD.ValueDecimal, txtDATINIPOD.Date)
                If dr.RowState = DataRowState.Added Then
                    Page.dsContrato.T0124988.RemoveT0124988Row(dr)
                Else
                    dr.Delete()
                End If
                ExcluirLinha = True
            End If
        End If

        cmbTIPPODCTTFRN.SelectedValue = String.Empty
        txtTIPPODCTTFRN.Text = ""

        BindGrdPeriodos()
    End Function

    Private Sub preenche_ComboData()
        Dim ds As wsAcoesComerciais.DatasetContratoXPeriodo

        cmbDATINIPOD.Items.Clear()

        If Not IsNumeric(cmbNUMCSLCTTFRN.SelectedValue) Then
            Exit Sub
        End If

        If Not IsNumeric(cmbTIPPODCTTFRN.SelectedValue) Then
            Exit Sub
        End If

        ds = Controller.ObterDistinctDATINIPODDePeriodo(Page.NUMCTTFRN, _
                                                        Convert.ToDecimal(cmbNUMCSLCTTFRN.SelectedValue), _
                                                        Convert.ToDecimal(cmbTIPPODCTTFRN.SelectedValue))

        cmbDATINIPOD.Items.Clear()
        For Each linha As wsAcoesComerciais.DatasetContratoXPeriodo.Query01Row In ds.Query01
            With cmbDATINIPOD
                .Items.Add(New ListItem(linha.DATINIPOD.ToString("dd/MM/yyyy"), linha.DATINIPOD.ToString("dd/MM/yyyy")))
            End With
        Next

        If txtDATINIPOD.Text = "" Then
            If IsDate(cmbDATINIPOD.SelectedValue) Then
                txtDATINIPOD.Text = cmbDATINIPOD.SelectedValue
            End If
        End If

    End Sub

    Private Function Existe_Anualidade() As Boolean
        Dim result As Boolean = False

        If Page.dsContrato.T0124961.Select("NumCslCttFrn = 3").Length > 0 Then
            result = True
        End If

        Return result
    End Function

    Private Function Existe_Trimestralidade() As Boolean
        Dim result As Boolean = False

        If Page.dsContrato.T0124961.Select("NumCslCttFrn = 10").Length > 0 Then
            result = True
        End If

        Return result
    End Function

#End Region

#End Region

End Class