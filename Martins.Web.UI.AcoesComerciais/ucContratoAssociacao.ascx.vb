Public Class ucContratoAssociacao
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
    Protected WithEvents cmdCancelarContrato As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetContrato1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContrato
    Protected WithEvents txtNUMCSLCTTFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents cmbNUMCSLCTTFRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblErroNUMCSLCTTFRN As System.Web.UI.WebControls.Label
    Protected WithEvents btnAlterar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents grdContratosAssociados As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblTipoFornecedor As System.Web.UI.WebControls.Label
    Protected WithEvents MessageBox1 As ControleMessageBox.MessageBox
    Protected WithEvents TD1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD2 As System.Web.UI.HtmlControls.HtmlTableCell

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

    Private Property bFrnPrincipal() As Boolean
        Get
            If Not Me.ViewState.Item("bFrnPrincipal") Is Nothing Then
                Return DirectCast(Me.ViewState.Item("bFrnPrincipal"), Boolean)
            Else
                Return False
            End If
        End Get
        Set(ByVal Value As Boolean)
            Me.ViewState("bFrnPrincipal") = Value
        End Set
    End Property

    Private Property linhaSelecionadaGrid() As Integer
        Get
            If viewState("linhaSelecionadaGrid") Is Nothing Then
                Return -1
            End If
            Return DirectCast(viewState("linhaSelecionadaGrid"), Integer)
        End Get
        Set(ByVal Value As Integer)
            viewState("linhaSelecionadaGrid") = Value
        End Set
    End Property

    Private Property colunaSelecionadaGrid() As Integer
        Get
            If viewState("colunaSelecionadaGrid") Is Nothing Then
                Return -1
            End If
            Return DirectCast(viewState("colunaSelecionadaGrid"), Integer)
        End Get
        Set(ByVal Value As Integer)
            viewState("colunaSelecionadaGrid") = Value
        End Set
    End Property

#End Region

#Region " Eventos "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not IsPostBack Then
                bFrnPrincipal = False
                CarregaControles()
            End If
            btnAlterar.Attributes.Add("OnClick", "javascript:return confirm('Gravar o registro?')")
            TD1.Visible = False
            TD2.Visible = False
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub btnAlterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlterar.Click
        Try
            If Page.flagContratoAtivo = False Then
                Util.AdicionaJsAlert(MyBase.Page, "Esse contrato não está ativo")
                Exit Sub
            End If
            If Me.ValidarDados Then
                If Me.Atualizar() Then
                    Me.BindGrdContratosAssociados()
                End If
            End If
            Session("numeroClausula") = cmbNUMCSLCTTFRN.SelectedValue
            Page.SalvarEContinuar()
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub cmbNUMCSLCTTFRN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNUMCSLCTTFRN.SelectedIndexChanged
        Try
            txtNUMCSLCTTFRN.Text = cmbNUMCSLCTTFRN.SelectedValue
            If txtNUMCSLCTTFRN.ValueDecimal = 0 Then
                btnAlterar.Enabled = False
                Exit Sub
            End If
            'Carregar o grid
            Me.BindGrdContratosAssociados()
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub GrdContratosAssociados_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdContratosAssociados.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Dim linha As wsAcoesComerciais.DatasetContrato.T0134010Row
                linha = Me.Page.dsContrato.T0134010.FindByNUMCSLCTTFRNCODFRNPCPAPUARDFRNNUMCTTFRNCODFRNASCAPUARDFRNNUMCTTFRNACS(Convert.ToDecimal(e.Item.Cells(4).Text), _
                                                                                                                                Convert.ToDecimal(e.Item.Cells(5).Text), _
                                                                                                                                Page.NUMCTTFRN, _
                                                                                                                                Convert.ToDecimal(e.Item.Cells(6).Text), _
                                                                                                                                Convert.ToDecimal(e.Item.Cells(7).Text))
                If Not linha Is Nothing Then
                End If

            End If

        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub GrdContratosAssociados_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdContratosAssociados.PageIndexChanged
        Try
            DatasetContrato1 = Page.dsContrato
            Me.grdContratosAssociados.CurrentPageIndex = e.NewPageIndex
            grdContratosAssociados.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdContratosAssociados_ItemCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdContratosAssociados.ItemCommand
        Try
            If e.CommandName = "lnkAssociacao" Then
                ProcessaSelecaoGrid(4, e.Item.ItemIndex)
            End If

        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub MessageBox1_YesChoosed(ByVal sender As Object, ByVal Key As String) Handles MessageBox1.YesChoosed
        If linhaSelecionadaGrid < 0 Then Exit Sub
        If colunaSelecionadaGrid < 0 Then Exit Sub
        AlteracaoSelecaoAssociacao(linhaSelecionadaGrid, CStr(IIf(BuscaValorCelulaNoGrid(colunaSelecionadaGrid, linhaSelecionadaGrid) = "1", "0", "1")))
    End Sub

#End Region

#Region " Metodos "

#Region " Metodos de Carga "

    Private Sub CarregaControles()
        Me.CarregarCmbNUMCSLCTTFRN()
        Me.BindGrdContratosAssociados()
    End Sub

    Private Sub CarregarCmbNUMCSLCTTFRN()
        Me.Page.dsContrato.Merge(Controller.ObterContratoXClausulaContrato(Nothing, Nothing, Nothing, Decimal.Zero, Convert.ToDecimal(Me.Page().NUMCTTFRN)), False, MissingSchemaAction.Ignore)
        If Me.Page.dsContrato.T0124953.Rows.Count = 0 Then
            Me.Page.dsContrato.Merge(Controller.ObterClausulasContrato("", 0).T0124953, False, MissingSchemaAction.Ignore)
        End If

        If Page.dsContrato.T0100426.Rows.Count = 0 Then
            cmbNUMCSLCTTFRN.Items.Clear()
            Exit Sub
        End If

        If Page.dsContrato.T0124945(0).T0100426Row Is Nothing Then
            cmbNUMCSLCTTFRN.Items.Clear()
            Exit Sub
        End If

        If Page.CODFRN = Page.dsContrato.T0124945(0).T0100426Row.CODFRNPCPAPUARDFRN Then
            CarregarCmbNUMCSLCTTFRNFornecedorPrincipal()
        Else
            CarregarCmbNUMCSLCTTFRNFornecedorAssociado()
        End If

        'Seleciona a cláusula
        If Not (Session("numeroClausula") Is Nothing) Then
            If IsNumeric(Session("numeroClausula")) Then
                If Not (cmbNUMCSLCTTFRN.Items.FindByValue(CType(Session("numeroClausula"), String)) Is Nothing) Then
                    cmbNUMCSLCTTFRN.SelectedValue = CType(Session("numeroClausula"), String)
                    txtNUMCSLCTTFRN.Text = CType(Session("numeroClausula"), String)
                End If
            End If
        End If
    End Sub

    Private Sub CarregarCmbNUMCSLCTTFRNFornecedorPrincipal()
        With cmbNUMCSLCTTFRN
            .Items.Clear()
            For Each drT0124961 As wsAcoesComerciais.DatasetContrato.T0124961Row In Me.Page.dsContrato.T0124961.Rows
                .Items.Add(New ListItem(drT0124961.NUMCSLCTTFRN.ToString() & " - " & drT0124961.T0124953Row.DESCSLCTTFRN, drT0124961.NUMCSLCTTFRN.ToString()))
            Next
            .Items.Insert(0, New ListItem(String.Empty, String.Empty))
        End With
    End Sub

    Private Sub CarregarCmbNUMCSLCTTFRNFornecedorAssociado()
        Dim ds As wsAcoesComerciais.DatasetContrato

        If Page.dsContrato.T0124945.Rows.Count = 0 Then
            Exit Sub
        End If

        ds = Controller.ObterClausulasEmContratroVigentesDoFornecedor(Page.dsContrato.T0124945(0).T0100426Row.CODFRNPCPAPUARDFRN)
        With cmbNUMCSLCTTFRN
            .Items.Clear()
            For Each drT0124961 As wsAcoesComerciais.DatasetContrato.T0124961Row In Me.Page.dsContrato.T0124961.Rows
                .Items.Add(New ListItem(drT0124961.NUMCSLCTTFRN.ToString() & " - " & drT0124961.T0124953Row.DESCSLCTTFRN, drT0124961.NUMCSLCTTFRN.ToString()))
            Next
            .Items.Insert(0, New ListItem(String.Empty, String.Empty))
        End With
    End Sub

    Private Sub BindGrdContratosAssociados()
        Try
            Dim ds As wsAcoesComerciais.DatasetContrato

            'Se não tem linha no contrato sai
            If Page.dsContrato.T0124945.Rows.Count = 0 Then
                Exit Sub
            End If

            'Se não existe linha do fornecedor associado, sai
            If Page.dsContrato.T0124945(0).T0100426Row Is Nothing Then
                Exit Sub
            End If

            'Comparando T0100426Row.CODFRNPCPAPUARDFRN = Page.CODFRN
            'é definido o texto que será colocado na label
            If Page.dsContrato.T0124945(0).T0100426Row.CODFRNPCPAPUARDFRN = Page.CODFRN Then
                bFrnPrincipal = True
                lblTipoFornecedor.Text = "Fornecedor(es) Associado(s)"
            Else
                bFrnPrincipal = False
                lblTipoFornecedor.Text = "Fornecedor Principal"
            End If

            'Consulta antiga procedure: spCLJ117
            'para obter as associações
            If IsNumeric(cmbNUMCSLCTTFRN.SelectedValue) Then
                ds = Controller.ObterAssociacaoClausulaFornecedor(Page.CODFRN, Page.NUMCTTFRN, Convert.ToDecimal(cmbNUMCSLCTTFRN.SelectedValue))

                'Transfere os dados para o dataset de contrato
                If Not ds Is Nothing Then
                    Page.dsContrato.TbPRCDLCnsAscCslFrn.Rows.Clear()
                    Page.dsContrato.Merge(ds.TbPRCDLCnsAscCslFrn, False, MissingSchemaAction.Ignore)
                End If

            End If

            Me.DatasetContrato1 = Me.Page.dsContrato
            Me.grdContratosAssociados.DataBind()
        Catch ex As Exception
            If grdContratosAssociados.CurrentPageIndex > 0 Then
                grdContratosAssociados.CurrentPageIndex = 0
                BindGrdContratosAssociados()
            Else
                Controller.TrataErro(MyBase.Page, ex)
            End If
        End Try

    End Sub

#End Region

#Region " Metodos de Controles "

#End Region

#Region " Metodos de Regras de Negocio "

    Private Function Atualizar() As Boolean
        Dim ppin_IndPrc As Integer
        Dim ppin_NumCslCttFrn As Integer
        Dim ppin_CodFrnPcpApuArdFrn As Integer
        Dim ppin_NumCttFrn As Integer
        Dim ppin_CodFrnAscApuArdFrn As Integer
        Dim ppin_NumCttFrnAcs As Integer

        'Coloca o mesmo valor do combo no text
        txtNUMCSLCTTFRN.Text = ""
        If IsNumeric(cmbNUMCSLCTTFRN.SelectedValue) Then
            txtNUMCSLCTTFRN.Text = cmbNUMCSLCTTFRN.SelectedValue
        End If

        'Grava/Elimina a associação da Cláusula do Contrato do
        'Fornecedor Associado com a do Contrato Fornecedor Principal
        For linha As Integer = 0 To grdContratosAssociados.Items.Count - 1

            'Indicador de Processo de Consulta
            ppin_IndPrc = Convert.ToInt32(IIf(BuscaValorCelulaNoGrid(4, linha) = "0", "2", "1"))

            ' Cláusula do Contrato
            ppin_NumCslCttFrn = txtNUMCSLCTTFRN.ValueInt

            ' Fornecedor Principal
            ppin_CodFrnPcpApuArdFrn = CInt(IIf(bFrnPrincipal, Page.CODFRN.ToString, BuscaValorCelulaNoGrid(1, linha)))

            ' Contrato Fornecedor Principal
            ppin_NumCttFrn = CInt(IIf(bFrnPrincipal, Page.NUMCTTFRN.ToString, BuscaValorCelulaNoGrid(3, linha)))

            ' Fornecedor Associado
            ppin_CodFrnAscApuArdFrn = CInt(IIf(bFrnPrincipal, Trim(BuscaValorCelulaNoGrid(1, linha)), Page.CODFRN.ToString))

            ' Contrato Fornecedor Associado
            ppin_NumCttFrnAcs = CInt(IIf(bFrnPrincipal, Trim(BuscaValorCelulaNoGrid(3, linha)), Page.NUMCTTFRN.ToString))

            'Chama a procedure para persistencia dos dados
            Controller.ManterClausulaContrato(ppin_IndPrc, _
                                              ppin_NumCslCttFrn, _
                                              ppin_CodFrnPcpApuArdFrn, _
                                              ppin_NumCttFrn, _
                                              ppin_CodFrnAscApuArdFrn, _
                                              ppin_NumCttFrnAcs)

        Next

        'Util.AdicionaJsAlert(MyBase.Page, "Cadastro realizado com sucesso.")
    End Function

    Private Function Atualizar(ByVal linha As Integer) As Boolean
        Dim ppin_IndPrc As Integer
        Dim ppin_NumCslCttFrn As Integer
        Dim ppin_CodFrnPcpApuArdFrn As Integer
        Dim ppin_NumCttFrn As Integer
        Dim ppin_CodFrnAscApuArdFrn As Integer
        Dim ppin_NumCttFrnAcs As Integer

        'Coloca o mesmo valor do combo no text
        txtNUMCSLCTTFRN.Text = ""
        If IsNumeric(cmbNUMCSLCTTFRN.SelectedValue) Then
            txtNUMCSLCTTFRN.Text = cmbNUMCSLCTTFRN.SelectedValue
        End If

        'Indicador de Processo de Consulta
        ppin_IndPrc = Convert.ToInt32(IIf(BuscaValorCelulaNoGrid(4, linha) = "0", "2", "1"))

        ' Cláusula do Contrato
        ppin_NumCslCttFrn = txtNUMCSLCTTFRN.ValueInt

        ' Fornecedor Principal
        ppin_CodFrnPcpApuArdFrn = CInt(IIf(bFrnPrincipal, Page.CODFRN.ToString, BuscaValorCelulaNoGrid(1, linha)))

        ' Contrato Fornecedor Principal
        ppin_NumCttFrn = CInt(IIf(bFrnPrincipal, Page.NUMCTTFRN.ToString, BuscaValorCelulaNoGrid(3, linha)))

        ' Fornecedor Associado
        ppin_CodFrnAscApuArdFrn = CInt(IIf(bFrnPrincipal, Trim(BuscaValorCelulaNoGrid(1, linha)), Page.CODFRN.ToString))

        ' Contrato Fornecedor Associado
        ppin_NumCttFrnAcs = CInt(IIf(bFrnPrincipal, Trim(BuscaValorCelulaNoGrid(3, linha)), Page.NUMCTTFRN.ToString))

        'Chama a procedure para persistencia dos dados
        Controller.ManterClausulaContrato(ppin_IndPrc, _
                                            ppin_NumCslCttFrn, _
                                            ppin_CodFrnPcpApuArdFrn, _
                                            ppin_NumCttFrn, _
                                            ppin_CodFrnAscApuArdFrn, _
                                            ppin_NumCttFrnAcs)

        'Util.AdicionaJsAlert(MyBase.Page, "Cadastro realizado com sucesso.")
    End Function

    Private Sub ProcessaSelecaoGrid(ByVal Col As Integer, ByVal Row As Integer)
        If bFrnPrincipal Then ' Fornecedor Principal
            ' Só altera se não estiver agrupada
            If BuscaValorCelulaNoGrid(5, Row) = "0" Then
                If (IIf(BuscaValorCelulaNoGrid(Col, Row) = "1", "0", "1").ToString = "1") Then
                    If ExisteClausula(0, cmbNUMCSLCTTFRN.SelectedValue, BuscaValorCelulaNoGrid(3, Row)) Then
                        colunaSelecionadaGrid = Col
                        linhaSelecionadaGrid = Row
                        Me.MessageBox1.ShowConfirmation("Cláusula já cadastrada para Contrato do Fornecedor Associado. Confirma o agrupamento com Clásula do Contrato do Fornecedor Principal.", "None", True, False)
                        Exit Sub
                    End If
                End If
                ' Agrupa/Desagrupa
                ''AlteracaoSelecaoAssociacao(Row, CStr(IIf(BuscaValorCelulaNoGrid(Col, Row) = "1", "0", "1")))
            End If
        Else ' Fornecedor Associado
            ' Se não existir ao desagrupar avisa ao usuário
            If IIf(BuscaValorCelulaNoGrid(Col, Row) = "1", "0", "1").ToString = "1" Then
                If Not (ExisteClausula(0, cmbNUMCSLCTTFRN.SelectedValue, Page.NUMCTTFRN.ToString)) Then
                    If BuscaValorCelulaNoGrid(Col, Row) = "1" Then
                        colunaSelecionadaGrid = Col
                        linhaSelecionadaGrid = Row
                        Me.MessageBox1.ShowConfirmation("Cláusula não cadastrada para Contrato do Fornecedor Associado. Confirma o desagrupamento com Clásula do Contrato do Fornecedor Principal.", "None", True, False)
                        Exit Sub
                        'If MsgBox("Cláusula não cadastrada para Contrato do Fornecedor Associado." & vbCrLf & "Confirma o desagrupamento com Clásula do Contrato do Fornecedor Principal.", _
                        'vbYesNo, "Confirmação") = vbNo Then
                        '    Exit Sub
                        'End If
                    End If
                Else
                    colunaSelecionadaGrid = Col
                    linhaSelecionadaGrid = Row
                    Me.MessageBox1.ShowConfirmation("Cláusula já cadastrada para Contrato do Fornecedor Associado. Confirma o agrupamento com Clásula do Contrato do Fornecedor Principal.", "None", True, False)
                    Exit Sub
                    'If MsgBox("Cláusula já cadastrada para Contrato do Fornecedor Associado." & vbCrLf & _
                    '   "Confirma o agrupamento com Clásula do Contrato do Fornecedor Principal.", _
                    '   vbYesNo, "Confirmação") = vbNo Then
                    '    Exit Sub
                    'End If
                End If
            Else
                If Not (ExisteClausula(0, cmbNUMCSLCTTFRN.SelectedValue, Page.NUMCTTFRN.ToString)) Then
                    If BuscaValorCelulaNoGrid(Col, Row) = "1" Then
                        colunaSelecionadaGrid = Col
                        linhaSelecionadaGrid = Row
                        Me.MessageBox1.ShowConfirmation("Cláusula não cadastrada para Contrato do Fornecedor Associado. Confirma o desagrupamento com Clásula do Contrato do Fornecedor Principal.", "None", True, False)
                        Exit Sub
                        'If MsgBox("Cláusula não cadastrada para Contrato do Fornecedor Associado." & vbCrLf & _
                        '"Confirma o desagrupamento com Clásula do Contrato do Fornecedor Principal.", _
                        'vbYesNo, "Confirmação") = vbNo Then
                        '    Exit Sub
                        'End If
                    End If
                End If
            End If
        End If
        'Agrupa/Desagrupa
        AlteracaoSelecaoAssociacao(Row, CStr(IIf(BuscaValorCelulaNoGrid(Col, Row) = "1", "0", "1")))
    End Sub

    Private Function BuscaValorCelulaNoGrid(ByVal coluna As Integer, ByVal linha As Integer) As String
        Try
            Return grdContratosAssociados.Items(linha).Cells(coluna).Text
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Function

    Private Function AlteracaoSelecaoAssociacao(ByVal linha As Integer, ByVal valor As String) As Boolean
        Try
            If Me.grdContratosAssociados.Items.Count < linha Then
                Return False
            End If
            Me.grdContratosAssociados.Items(linha).Cells(4).Text = valor

            For i As Integer = 0 To (grdContratosAssociados.Items.Count - 1)
                Select Case Me.grdContratosAssociados.Items(i).Cells(4).Text
                    Case "1"
                        Me.grdContratosAssociados.Items(i).Cells(6).Text = "ASSOCIADO"
                    Case Else
                        Me.grdContratosAssociados.Items(i).Cells(6).Text = "NÃO ASSOCIADO"
                End Select
            Next

            'Salva associação
            If Me.ValidarDados Then
                If Me.Atualizar(linha) Then
                    Me.BindGrdContratosAssociados()
                End If
            End If
            Session("numeroClausula") = cmbNUMCSLCTTFRN.SelectedValue

        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Function

    Public Function ExisteClausula(ByVal iIndPrc As Integer, ByVal sNumCslCttFrn As String, ByVal sNumCttFrnAcs As String) As Boolean
        ' sIndPrc -> 0 - Consulta Existencia de Clausula cadastrada para o
        '                Contrato do Fornecedor Associado
        ' sIndPrc -> 3 - Consulta Existencia de Clausula do Contrato do
        '                Fornecedor Associado com a do Contrato do Fornecedor
        '                Principal

        ExisteClausula = False
        Dim IndExr As Integer

        If Not IsNumeric(cmbNUMCSLCTTFRN.SelectedValue) Then
            Return False
        End If

        ' Consulta Existência da Clásula do Contrato do
        ' Fornecedor Associado
        IndExr = Controller.ManterClausulaContrato(iIndPrc, CType(cmbNUMCSLCTTFRN.SelectedValue, Integer), 0, 0, 0, CType(sNumCttFrnAcs, Integer))
        ExisteClausula = (IndExr > 0)

    End Function

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

            'If ucfCODFRNASCAPUARDFRN.CodFornecedor = 0 Then
            '    'Mensagem
            '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '    mensagemErro &= "abrangencia inválida"

            '    If Not deuFoco Then
            '        Util.AdicionaJsFocus(MyBase.Page, CType(ucfCODFRNASCAPUARDFRN.FindControl("txtCodigo"), WebControl))
            '    End If
            '    deuFoco = True
            '    lblErroCODFRNASCAPUARDFRN.Visible = True
            'Else
            '    lblErroCODFRNASCAPUARDFRN.Visible = False
            'End If

            'If Not IsNumeric(cmbNUMCTTFRNACS.SelectedValue) Then
            '    'Mensagem
            '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '    mensagemErro &= "Entidade inválida"

            '    If Not deuFoco Then
            '        Util.AdicionaJsFocus(MyBase.Page, CType(cmbNUMCTTFRNACS, WebControl))
            '    End If
            '    deuFoco = True
            '    lblErroNUMCTTFRNACS.Visible = True
            'Else
            '    lblErroNUMCTTFRNACS.Visible = False
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
    End Sub

    Protected Function consultarDescricaoAssociacao(ByVal vDad As String) As String
        Dim result As String = String.Empty

        If vDad Is Nothing Then
            result = ""
        ElseIf vDad = "" Then
            result = ""
        ElseIf Not IsNumeric(vDad) Then
            result = ""
        Else
            Try
                If vDad = "1" Then
                    result = "ASSOCIADO"
                Else
                    result = "NÃO ASSOCIADO"
                End If
            Catch ex As Exception
                result = ""
            End Try
        End If

        Return result
    End Function

#End Region

#End Region

End Class