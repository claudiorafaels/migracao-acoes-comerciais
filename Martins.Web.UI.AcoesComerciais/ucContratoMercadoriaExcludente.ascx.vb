Public Class ucContratoMercadoriaExcludente
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
    Protected WithEvents cmdAtualizar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cmdNova As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErroNUMCSLCTTFRN As System.Web.UI.WebControls.Label
    Protected WithEvents txtNUMCSLCTTFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents cmbNUMCSLCTTFRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtTIPEDEABGMIX As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents cmbTIPEDEABGMIX As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmbCODEDEABGMIX As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCODMER As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents cmbCODMER As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblErroTIPEDEABGMIX As System.Web.UI.WebControls.Label
    Protected WithEvents lblErroCODEDEABGMIX As System.Web.UI.WebControls.Label
    Protected WithEvents lblErroCODMER As System.Web.UI.WebControls.Label
    Protected WithEvents GrdMercadoriasExcludentes As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetContrato1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContrato
    Protected WithEvents btnExcluir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cmbTipo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnTrimestralidade As System.Web.UI.WebControls.LinkButton
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
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub cmdNova_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            CarregaControles()
            Util.AdicionaJsFocus(MyBase.Page, CType(txtNUMCSLCTTFRN, WebControl), Util.tipoDeComponente.InfragisticsTxt)

            Dim ctrlLblErro As WebControl() = New WebControl() {lblErroNUMCSLCTTFRN, _
                                                                lblErroTIPEDEABGMIX, _
                                                                lblErroCODEDEABGMIX, _
                                                                lblErroCODMER}
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
            If Me.SalvarDados() Then
                Me.BindGrdMercadoriasExcludentes()

                If cmbNUMCSLCTTFRN.SelectedValue = "2" Then
                    If Not Existe_Anualidade() Then
                        btnAnualidade.Enabled = True
                    End If
                    If Not Existe_Trimestralidade() Then
                        btnTrimestralidade.Enabled = True '(cmbTIPPODCTTFRN.SelectedValue = "1")
                    End If
                End If

            End If
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click
        If Page.flagContratoAtivo = False Then
            Util.AdicionaJsAlert(MyBase.Page, "Esse contrato não está ativo")
            Exit Sub
        End If
        Excluir()
    End Sub

    Private Sub cmbNUMCSLCTTFRN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNUMCSLCTTFRN.SelectedIndexChanged
        Try
            txtNUMCSLCTTFRN.Text = cmbNUMCSLCTTFRN.SelectedValue
            CarregarCmbTIPEDEABGMIX()
            mudarTIPEDEABGMIX()
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub txtTIPEDEABGMIX_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtTIPEDEABGMIX.ValueChange
        If cmbTIPEDEABGMIX.SelectedValue <> txtTIPEDEABGMIX.Text Then
            cmbTIPEDEABGMIX.SelectedValue = txtTIPEDEABGMIX.Text
        End If
    End Sub

    Private Sub cmbTIPEDEABGMIX_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTIPEDEABGMIX.SelectedIndexChanged
        Try
            txtTIPEDEABGMIX.Text = cmbTIPEDEABGMIX.SelectedValue
            mudarTIPEDEABGMIX()
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub GrdMercadoriasExcludentes_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles GrdMercadoriasExcludentes.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Dim linha As wsAcoesComerciais.DatasetContrato.T0125020Row
                linha = Me.Page.dsContrato.T0125020.FindByNUMCTTFRNNUMCSLCTTFRNCODMER(Page.NUMCTTFRN, _
                                                                                      Convert.ToDecimal(e.Item.Cells(6).Text), _
                                                                                      Convert.ToDecimal(e.Item.Cells(4).Text))
                If Not linha Is Nothing Then
                    PreencheControles(linha)
                End If

            End If

        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub GrdMercadoriasExcludentes_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles GrdMercadoriasExcludentes.PageIndexChanged
        Try
            DatasetContrato1 = Page.dsContrato
            Me.GrdMercadoriasExcludentes.CurrentPageIndex = e.NewPageIndex
            GrdMercadoriasExcludentes.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtNUMCSLCTTFRN_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtNUMCSLCTTFRN.ValueChange
        If cmbNUMCSLCTTFRN.SelectedValue <> txtNUMCSLCTTFRN.Text Then
            cmbNUMCSLCTTFRN.SelectedValue = txtNUMCSLCTTFRN.Text
            cmbNUMCSLCTTFRN_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged
        If cmbTipo.SelectedValue = "1" Then
            CarregarcmbCODMEROpcaoItens()
            txtCODMER.Width = New WebControls.Unit("0px")
        ElseIf cmbTipo.SelectedValue = "2" Then
            CarregarcmbCODMEROpcaoCategoria()
            txtCODMER.Width = New WebControls.Unit("50px")
        End If
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

            'DatasetContrato1 = Page.dsContrato
            Dim T0125020Row As wsAcoesComerciais.DatasetContrato.T0125020Row

            T0125020Row = Page.dsContrato.T0125020.NewT0125020Row
            With T0125020Row
                .NUMCTTFRN = Page.NUMCTTFRN
                .CODMER = txtCODMER.ValueDecimal
                .CODEDEABGMIX = Page.CODFRN
                .NUMCSLCTTFRN = 10
                .TIPEDEABGMIX = txtTIPEDEABGMIX.ValueDecimal
            End With
            Page.dsContrato.T0125020.AddT0125020Row(T0125020Row)

            DatasetContrato1 = Page.dsContrato
            'TODO:  Verificar a necessidade
            'If Not Page.existeFaixaParaClausula(CType(cmbNUMCSLCTTFRN.SelectedValue, Decimal)) Then
            '    Util.AdicionaJsAlert(MyBase.Page, "Digite as faixas antes de gerar a trimestralidade")
            '    Exit Sub
            'End If
            'Controller.GerarClausulaTrimestralidade(Page.NUMCTTFRN)
            btnTrimestralidade.Enabled = False
            GrdMercadoriasExcludentes.DataBind()

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
            'TODO:  Verificar a necessidade
            'If Not Page.existeFaixaParaClausula(CType(cmbNUMCSLCTTFRN.SelectedValue, Decimal)) Then
            '    Util.AdicionaJsAlert(MyBase.Page, "Digite as faixas antes de gerar a anualidade")
            '    Exit Sub
            'End If

            'Controller.GerarClausulaAnualidade(Page.NUMCTTFRN)
            'DatasetContrato1 = Controller.ObterContrato(Page.NUMCTTFRN)
            Dim T0125020Row As wsAcoesComerciais.DatasetContrato.T0125020Row

            T0125020Row = Page.dsContrato.T0125020.NewT0125020Row
            With T0125020Row
                .NUMCTTFRN = Page.NUMCTTFRN
                .CODMER = txtCODMER.ValueDecimal
                .CODEDEABGMIX = Page.CODFRN
                .NUMCSLCTTFRN = 3
                .TIPEDEABGMIX = txtTIPEDEABGMIX.ValueDecimal
            End With
            Page.dsContrato.T0125020.AddT0125020Row(T0125020Row)
            DatasetContrato1 = Page.dsContrato

            btnAnualidade.Enabled = False
            GrdMercadoriasExcludentes.DataBind()
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
        Me.CarregarCmbTIPEDEABGMIX()
        Me.CarregarCmbCODEDEABGMIX()
        Me.BindGrdMercadoriasExcludentes()
    End Sub

    Public Sub CarregarCmbNUMCSLCTTFRN()
        Me.Page.dsContrato.Merge(Controller.ObterContratoXClausulaContrato(Nothing, Nothing, Nothing, Decimal.Zero, Convert.ToDecimal(Me.Page.NUMCTTFRN)), False, MissingSchemaAction.Ignore)

        With cmbNUMCSLCTTFRN
            If Me.Page.dsContrato.T0124953.Rows.Count = 0 Then
                Me.Page.dsContrato.Merge(Controller.ObterClausulasContrato("", 0).T0124953, False, MissingSchemaAction.Ignore)
            End If
            .Items.Clear()

            For Each drT0124953 As wsAcoesComerciais.DatasetContrato.T0124953Row In Page.dsContrato.T0124953
                'Verifica se a clausula está sendo utilizada na abrangencia do contrato e se o tipo de abrangencia = 2 (Categoria)
                If Page.dsContrato.T0124996.Select("NUMCSLCTTFRN = " & drT0124953.NUMCSLCTTFRN.ToString & " AND FLGMERECS = '*'").Length > 0 Then
                    If Page.dsContrato.T0124996.Select("NUMCSLCTTFRN = " & drT0124953.NUMCSLCTTFRN.ToString).Length > 0 Then
                        .Items.Add(New ListItem(drT0124953.NUMCSLCTTFRN.ToString() & " - " & drT0124953.DESCSLCTTFRN, drT0124953.NUMCSLCTTFRN.ToString()))
                    End If
                End If
            Next

            .Items.Insert(0, New ListItem(String.Empty, String.Empty))
        End With

    End Sub

    Private Sub CarregarCmbTIPEDEABGMIX()
        If Not IsNumeric(cmbNUMCSLCTTFRN.SelectedValue) Then
            Exit Sub
        End If

        Dim linhaT0124996 As wsAcoesComerciais.DatasetContrato.T0124996Row
        With cmbTIPEDEABGMIX
            .Items.Clear()
            For Each linhaT0125011 As wsAcoesComerciais.DatasetContrato.T0125011Row In Page.dsContrato.T0125011
                If Page.dsContrato.T0124996.Select("NUMCSLCTTFRN = " & cmbNUMCSLCTTFRN.SelectedValue & " AND TIPEDEABGMIX = " & linhaT0125011.TIPEDEABGMIX.ToString).Length > 0 Then
                    linhaT0124996 = CType(Page.dsContrato.T0124996.Select("NUMCSLCTTFRN = " & cmbNUMCSLCTTFRN.SelectedValue & " AND TIPEDEABGMIX = " & linhaT0125011.TIPEDEABGMIX.ToString)(0), wsAcoesComerciais.DatasetContrato.T0124996Row)
                    If linhaT0124996.FLGMERECS = "*" Then
                        .Items.Add(New ListItem(linhaT0125011.DESEDEABGMIX.ToString(), linhaT0125011.TIPEDEABGMIX.ToString()))
                    End If
                End If
            Next
            If cmbTIPEDEABGMIX.Items.Count = 0 Then
                Util.AdicionaJsAlert(MyBase.Page, "Não existe abrangencia com mercadoria excludente para essa cláusula")
            End If
            cmbTIPEDEABGMIX.Items.Insert(0, New ListItem(String.Empty, String.Empty))
        End With

        cmbTIPEDEABGMIX_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub CarregarCmbCODEDEABGMIX()
        If Not IsNumeric(cmbNUMCSLCTTFRN.SelectedValue) Then
            cmbTIPEDEABGMIX.Items.Clear()
            Exit Sub
        End If

        If Not IsNumeric(cmbTIPEDEABGMIX.SelectedValue) Then
            cmbTIPEDEABGMIX.Items.Clear()
            Exit Sub
        End If

        With cmbCODEDEABGMIX
            .Items.Clear()
            For Each drT0124996 As wsAcoesComerciais.DatasetContrato.T0124996Row In Me.Page.dsContrato.T0124996.Rows
                If drT0124996.NUMCSLCTTFRN = Convert.ToDecimal(cmbNUMCSLCTTFRN.SelectedValue) And _
                   drT0124996.TIPEDEABGMIX = Convert.ToDecimal(cmbTIPEDEABGMIX.SelectedValue) Then
                    .Items.Add(New ListItem(drT0124996.CODEDEABGMIX.ToString(), drT0124996.CODEDEABGMIX.ToString()))
                End If
            Next
        End With

    End Sub

    Private Sub mudarTIPEDEABGMIX()
        cmbCODEDEABGMIX.Items.Clear()

        If Not IsNumeric(cmbNUMCSLCTTFRN.SelectedValue) Then
            Exit Sub
        End If

        If Not IsNumeric(cmbTIPEDEABGMIX.SelectedValue) Then
            Exit Sub
        End If

        If cmbTIPEDEABGMIX.SelectedValue = "3" Then
            Util.AdicionaJsAlert(MyBase.Page, "Esta abrangência não pode ter mercadoria excludente")
            cmbTIPEDEABGMIX.SelectedValue = String.Empty
            txtTIPEDEABGMIX.Text = String.Empty
            Exit Sub
        End If

        For Each linha As wsAcoesComerciais.DatasetContrato.T0124996Row In Page.dsContrato.T0124996
            If linha.NUMCSLCTTFRN = Convert.ToDecimal(cmbNUMCSLCTTFRN.SelectedValue) And linha.TIPEDEABGMIX = Convert.ToDecimal(cmbTIPEDEABGMIX.SelectedValue) Then
                If linha.FLGMERECS.Equals("*") Then
                    With cmbCODEDEABGMIX
                        .Items.Add(New ListItem(linha.CODEDEABGMIX.ToString, linha.CODEDEABGMIX.ToString))
                    End With
                End If
            End If
        Next

        cmbCODEDEABGMIX.Items.Insert(0, New ListItem("", ""))
    End Sub

    Private Sub BindGrdMercadoriasExcludentes()
        Try
            Me.DatasetContrato1 = Me.Page.dsContrato
            Me.GrdMercadoriasExcludentes.DataBind()
        Catch ex As Exception
            If Me.GrdMercadoriasExcludentes.CurrentPageIndex > 0 Then
                Me.GrdMercadoriasExcludentes.CurrentPageIndex = 0
                Me.GrdMercadoriasExcludentes.DataBind()
            Else
                Controller.TrataErro(MyBase.Page, ex)
            End If
        End Try
    End Sub

    Private Sub CarregarcmbCODMEROpcaoItens()
        Dim ds As wsAcoesComerciais.DatasetContratoXAbrangenciaMix = _
            Controller.ObterMercadoriasDoFornecedor(1, Page.CODFRN)

        cmbCODMER.Items.Clear()
        For Each linha As wsAcoesComerciais.DatasetContratoXAbrangenciaMix.T0100086Row In ds.T0100086
            cmbCODMER.Items.Add(New ListItem(linha.CODMER.ToString() & " - " & linha.DESMER, linha.CODMER.ToString))
        Next
        cmbCODMER.Items.Insert(0, New ListItem(String.Empty, String.Empty))

        'cmbCODMER_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub CarregarcmbCODMEROpcaoCategoria()
        Dim ds As wsAcoesComerciais.DatasetContratoXAbrangenciaMix
        ds = Controller.ObterCategoriasDoFornecedor(1, Page.CODFRN)

        cmbCODMER.Items.Clear()
        For Each linha As wsAcoesComerciais.DatasetContratoXAbrangenciaMix.QueryDeT0100132Row In ds.QueryDeT0100132
            cmbCODMER.Items.Add(New ListItem(linha.CODCTGUNIMER.ToString & " - " & linha.DESCLSMER, linha.CODCTGUNIMER.ToString))
        Next
        cmbCODMER.Items.Insert(0, New ListItem(String.Empty, String.Empty))

        'cmbCODMER_SelectedIndexChanged(Nothing, Nothing)
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

    Protected Function consultarDESEDEABGMIX(ByVal vDad As String) As String
        Dim result As String = String.Empty

        If WSCAcoesComerciais.dsTipoAbrangenciaMix Is Nothing Then
            WSCAcoesComerciais.dsTipoAbrangenciaMix = Controller.ObterTiposAbrangenciaMix("")
        End If

        If vDad Is Nothing Then
            result = ""
        ElseIf vDad = "" Then
            result = ""
        ElseIf Not IsNumeric(vDad) Then
            result = ""
        Else
            Try
                Dim linha As wsAcoesComerciais.DatasetTipoAbrangenciaMix.T0125011Row = WSCAcoesComerciais.dsTipoAbrangenciaMix.T0125011.FindByTIPEDEABGMIX(Convert.ToDecimal(vDad))
                If Not linha Is Nothing Then
                    result = linha.TIPEDEABGMIX.ToString("0000") & " - " & linha.DESEDEABGMIX
                End If
            Catch ex As Exception
                result = ""
            End Try
        End If

        Return result
    End Function

    Protected Function consultarDESMER(ByVal vDad As String) As String
        Dim result As String = String.Empty

        If vDad Is Nothing Then
            result = ""
        ElseIf vDad = "" Then
            result = ""
        ElseIf Not IsNumeric(vDad) Then
            result = ""
        Else
            Try
                Dim linha As wsAcoesComerciais.DatasetContrato.T0100086Row
                linha = Page.dsContrato.T0100086.FindByCODMER(Convert.ToDecimal(vDad))
                If Not linha Is Nothing Then
                    result = linha.CODMER.ToString("0000") & " - " & linha.DESMER
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
                list = cmbTIPEDEABGMIX.Items.FindByValue(vDad)
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

            If cmbTIPEDEABGMIX.SelectedValue Is String.Empty Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "abrangencia inválida"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(cmbTIPEDEABGMIX, WebControl))
                End If
                deuFoco = True
                lblErroTIPEDEABGMIX.Visible = True
            Else
                lblErroTIPEDEABGMIX.Visible = False
            End If

            If cmbCODEDEABGMIX.SelectedValue Is String.Empty Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "Entidade inválida"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(cmbCODEDEABGMIX, WebControl))
                End If
                deuFoco = True
                lblErroCODEDEABGMIX.Visible = True
            Else
                lblErroCODEDEABGMIX.Visible = False
            End If

            If txtCODMER.Text Is String.Empty Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "item não mencionado. Favor preencher o campo"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(txtCODMER, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                End If
                deuFoco = True
                lblErroCODMER.Visible = True
            Else
                lblErroCODMER.Visible = False
            End If

            If txtNUMCSLCTTFRN.ValueInt.Equals(3) Then  ' Anualidade
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "não é permitido editar clásula de Anualidade, ela é gerada pelo sistema"
            ElseIf txtNUMCSLCTTFRN.ValueInt.Equals(10) Then  ' Trimestralidade
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "não é permitido editar clásula de Trimestralidade, ela é gerada pelo sistema"
            End If

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
        txtTIPEDEABGMIX.Text = cmbTIPEDEABGMIX.SelectedValue
        txtCODMER.Text = cmbCODMER.SelectedValue
    End Sub

    Private Sub PreencheLinhaT0125020(ByRef dr As wsAcoesComerciais.DatasetContrato.T0125020Row)
        With dr
            .NUMCTTFRN = Page.NUMCTTFRN
            .NUMCSLCTTFRN = Convert.ToDecimal(cmbNUMCSLCTTFRN.SelectedValue)
            .TIPEDEABGMIX = Convert.ToDecimal(cmbTIPEDEABGMIX.SelectedValue)
            .CODEDEABGMIX = Convert.ToDecimal(cmbCODEDEABGMIX.SelectedValue)
            .CODMER = txtCODMER.ValueDecimal
        End With
    End Sub

    Private Sub PreencheLinhaT0125020(ByRef dr As wsAcoesComerciais.DatasetContrato.T0125020Row, ByVal CODMER As Decimal)
        With dr
            .NUMCTTFRN = Page.NUMCTTFRN
            .NUMCSLCTTFRN = Convert.ToDecimal(cmbNUMCSLCTTFRN.SelectedValue)
            .TIPEDEABGMIX = Convert.ToDecimal(cmbTIPEDEABGMIX.SelectedValue)
            .CODEDEABGMIX = Convert.ToDecimal(cmbCODEDEABGMIX.SelectedValue)
            .CODMER = CODMER
        End With
    End Sub

    Private Sub PreencheControles(ByRef dr As wsAcoesComerciais.DatasetContrato.T0125020Row)
        With dr
            If Not cmbNUMCSLCTTFRN.Items.FindByValue(.NUMCSLCTTFRN.ToString) Is Nothing Then
                cmbNUMCSLCTTFRN.SelectedValue = .NUMCSLCTTFRN.ToString
                txtNUMCSLCTTFRN.ValueDecimal = .NUMCSLCTTFRN
            End If

            If Not cmbTIPEDEABGMIX.Items.FindByValue(.TIPEDEABGMIX.ToString) Is Nothing Then
                cmbTIPEDEABGMIX.SelectedValue = .TIPEDEABGMIX.ToString
                txtTIPEDEABGMIX.ValueDecimal = .TIPEDEABGMIX
                mudarTIPEDEABGMIX()
            End If

            If cmbTIPEDEABGMIX.SelectedValue = "3" Then 'Abrangencia por item 
                If Not cmbCODEDEABGMIX.Items.FindByValue(.CODEDEABGMIX.ToString) Is Nothing Then
                    cmbCODEDEABGMIX.SelectedValue = .CODEDEABGMIX.ToString
                Else
                    cmbCODEDEABGMIX.ClearSelection()
                End If
            ElseIf cmbTIPEDEABGMIX.SelectedValue = "2" Then 'Abrangencia por categoria
                If Not cmbCODEDEABGMIX.Items.FindByValue(.CODEDEABGMIX.ToString("000000000000")) Is Nothing Then
                    cmbCODEDEABGMIX.SelectedValue = .CODEDEABGMIX.ToString("000000000000")
                Else
                    cmbCODEDEABGMIX.ClearSelection()
                End If
            Else
                cmbCODEDEABGMIX.ClearSelection()
            End If

            If Not cmbCODEDEABGMIX.Items.FindByValue(.CODEDEABGMIX.ToString) Is Nothing Then
                cmbCODEDEABGMIX.SelectedValue = .CODEDEABGMIX.ToString
            End If

            If Not cmbCODMER.Items.FindByValue(.CODMER.ToString) Is Nothing Then
                cmbCODMER.SelectedValue = .CODMER.ToString
                txtCODMER.ValueDecimal = .CODMER
            End If
        End With
    End Sub

    Private Function SalvarDados() As Boolean
        SalvarDados = False

        If cmbTipo.SelectedValue = "1" Then 'Seleção por item
            SalvarDados = SalvarDadosSelecaoPorItem()
        ElseIf cmbTipo.SelectedValue = "2" Then 'Seleção por grupo
            SalvarDados = SalvarDadosSelecaoPorGrupo()
        End If

    End Function

    Private Function SalvarDadosSelecaoPorItem() As Boolean
        SalvarDadosSelecaoPorItem = False
        If Me.ValidarDados() Then
            If Not Page.dsContrato.T0125020.FindByNUMCTTFRNNUMCSLCTTFRNCODMER(Page.NUMCTTFRN, Convert.ToDecimal(cmbNUMCSLCTTFRN.SelectedValue), Convert.ToDecimal(cmbCODMER.SelectedValue)) Is Nothing Then
                Dim dr As wsAcoesComerciais.DatasetContrato.T0125020Row = Page.dsContrato.T0125020.FindByNUMCTTFRNNUMCSLCTTFRNCODMER(Page.NUMCTTFRN, Convert.ToDecimal(cmbNUMCSLCTTFRN.SelectedValue), Convert.ToDecimal(cmbCODMER.SelectedValue))
                Me.PreencheLinhaT0125020(dr)
            Else
                Dim dr As wsAcoesComerciais.DatasetContrato.T0125020Row = Me.Page.dsContrato.T0125020.NewT0125020Row()
                Me.PreencheLinhaT0125020(dr)
                Me.Page.dsContrato.T0125020.AddT0125020Row(dr)
            End If
            SalvarDadosSelecaoPorItem = True
        End If
    End Function

    Private Function SalvarDadosSelecaoPorGrupo() As Boolean
        SalvarDadosSelecaoPorGrupo = False

        If Me.ValidarDados() Then
            For Each linha As wsAcoesComerciais.DatasetContrato.T0100086Row In Page.dsContrato.T0100086
                If linha.CODCTGUNIMER = cmbCODMER.SelectedValue Then
                    If Not Page.dsContrato.T0125020.FindByNUMCTTFRNNUMCSLCTTFRNCODMER(Page.NUMCTTFRN, Convert.ToDecimal(cmbNUMCSLCTTFRN.SelectedValue), linha.CODMER) Is Nothing Then
                        Dim dr As wsAcoesComerciais.DatasetContrato.T0125020Row = Page.dsContrato.T0125020.FindByNUMCTTFRNNUMCSLCTTFRNCODMER(Page.NUMCTTFRN, Convert.ToDecimal(cmbNUMCSLCTTFRN.SelectedValue), linha.CODMER)
                        Me.PreencheLinhaT0125020(dr, linha.CODMER)
                    Else
                        Dim dr As wsAcoesComerciais.DatasetContrato.T0125020Row = Me.Page.dsContrato.T0125020.NewT0125020Row()
                        Me.PreencheLinhaT0125020(dr, linha.CODMER)
                        Me.Page.dsContrato.T0125020.AddT0125020Row(dr)
                    End If
                End If
            Next
        End If

        SalvarDadosSelecaoPorGrupo = True
    End Function

    Private Function Excluir() As Boolean
        Excluir = False

        If cmbTipo.SelectedValue = "1" Then 'Seleção por item
            Excluir = ExcluirPorItem()
        ElseIf cmbTipo.SelectedValue = "2" Then 'Seleção por grupo
            Excluir = ExcluirPorCategoria()
        End If

        BindGrdMercadoriasExcludentes()
    End Function

    Private Function ExcluirPorItem() As Boolean
        ExcluirPorItem = False
        If Me.ValidarDados() Then
            If Not Page.dsContrato.T0125020.FindByNUMCTTFRNNUMCSLCTTFRNCODMER(Page.NUMCTTFRN, Convert.ToDecimal(cmbNUMCSLCTTFRN.SelectedValue), Convert.ToDecimal(cmbCODMER.SelectedValue)) Is Nothing Then
                Dim dr As wsAcoesComerciais.DatasetContrato.T0125020Row = Page.dsContrato.T0125020.FindByNUMCTTFRNNUMCSLCTTFRNCODMER(Page.NUMCTTFRN, Convert.ToDecimal(cmbNUMCSLCTTFRN.SelectedValue), Convert.ToDecimal(cmbCODMER.SelectedValue))
                If dr.RowState = DataRowState.Added Then
                    Page.dsContrato.T0125020.RemoveT0125020Row(dr)
                Else
                    dr.Delete()
                End If
            End If
            ExcluirPorItem = True
        End If
        BindGrdMercadoriasExcludentes()
    End Function

    Private Function ExcluirPorCategoria() As Boolean
        ExcluirPorCategoria = False
        If Me.ValidarDados() Then

            For Each linha As wsAcoesComerciais.DatasetContrato.T0100086Row In Page.dsContrato.T0100086
                If linha.CODCTGUNIMER = cmbCODMER.SelectedValue Then
                    If Not Page.dsContrato.T0125020.FindByNUMCTTFRNNUMCSLCTTFRNCODMER(Page.NUMCTTFRN, Convert.ToDecimal(cmbNUMCSLCTTFRN.SelectedValue), linha.CODMER) Is Nothing Then
                        Dim dr As wsAcoesComerciais.DatasetContrato.T0125020Row = Page.dsContrato.T0125020.FindByNUMCTTFRNNUMCSLCTTFRNCODMER(Page.NUMCTTFRN, Convert.ToDecimal(cmbNUMCSLCTTFRN.SelectedValue), linha.CODMER)
                        If dr.RowState = DataRowState.Added Then
                            Page.dsContrato.T0125020.RemoveT0125020Row(dr)
                        Else
                            dr.Delete()
                        End If
                    End If
                End If
            Next

            ExcluirPorCategoria = True
        End If

        BindGrdMercadoriasExcludentes()
    End Function

    Private Function Existe_Anualidade() As Boolean
        Dim result As Boolean = False

        If Page.dsContrato.T0125020.Select("NumCslCttFrn = 3").Length > 0 Then
            result = True
        End If

        Return result
    End Function

    Private Function Existe_Trimestralidade() As Boolean
        Dim result As Boolean = False

        If Page.dsContrato.T0125020.Select("NumCslCttFrn = 10").Length > 0 Then
            result = True
        End If

        Return result
    End Function
#End Region

#End Region

End Class