Public Class Recebimento
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dsAcordo = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetAcordo
        CType(Me.dsAcordo, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'dsAcordo
        '
        Me.dsAcordo.DataSetName = "DatasetAcordo"
        Me.dsAcordo.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.dsAcordo, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents uwgAcordos As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents chkBaixarNegociado As System.Web.UI.WebControls.CheckBox
    Protected WithEvents cmdCalcularValores As System.Web.UI.WebControls.Button
    Protected WithEvents txtVlrPmsSel1 As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtVlrPmsSel As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtVlrPgtSel As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtVlrRst As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents uwgRecebimentos As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents BtnImprimirRecibo As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents dsAcordo As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetAcordo
    Protected WithEvents btnVisualizar As System.Web.UI.WebControls.LinkButton
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

#Region " Propriedades "

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

    Private Enum Baixa As Integer
        AcordoComercial = 1
        Pendencia = 2
        Ambos = 3
    End Enum

#End Region

#Region " Eventos "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            End If
            btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
            BtnImprimirRecibo.Attributes.Add("OnClick", "javascript:mostraAndamento()")
            btnVisualizar.Attributes.Add("OnClick", "javascript:mostraAndamento()")

            If (Not IsPostBack) Then
                Me.InicializaPagina()
            Else
                Me.RecuperaEstado()
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        SalvaEstado()
    End Sub

    Private Sub ucFornecedor_FornecedorAlterado(ByVal e As System.Web.UI.WebControls.ListItem) Handles ucFornecedor.FornecedorAlterado
        Try
            CarregaGrids(ucFornecedor.CodFornecedor)
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

            If Not EfetuarCalculosAcordos() Then
                flagProcessando = False
                Exit Sub
            End If
            Me.EfetuarCalculosRecebimentos()
            Me.Atualizar()
            Me.CarregaGrids(ucFornecedor.CodFornecedor)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        Finally
            flagProcessando = False
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("Recebimento.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmdCalcularValores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalcularValores.Click
        Try
            Me.EfetuarCalculosAcordos()
            Me.EfetuarCalculosRecebimentos()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub chkBaixarNegociado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBaixarNegociado.CheckedChanged
        Try
            Me.EfetuarCalculosAcordos()
            Me.EfetuarCalculosRecebimentos()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    'Private Sub uwgAcordos_ItemCommand(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.UltraWebGridCommandEventArgs) Handles uwgAcordos.ItemCommand
    '    Try
    '        uwgAcordos.DisplayLayout.ActiveRow().Cells(13).Value = uwgAcordos.DisplayLayout.ActiveRow().Cells(12).Value
    '    Catch ex As Exception
    '        Controller.TrataErro(Me.Page, ex)
    '    End Try
    'End Sub

    Private Sub uwgAcordos_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.RowEventArgs) Handles uwgAcordos.InitializeRow
        Try
            e.Row.Cells(13).Value = Format(e.Row.Cells(12).Value, "###,###,##0.00").ToString
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#Region " Metodos "

#Region " Metodos de Carga "

    Private Sub InicializaPagina()
        ucFornecedor.widthNome = System.Web.UI.WebControls.Unit.Parse("280px")
    End Sub

    Private Sub RecuperaEstado()
        If Not Session.Item(dsAcordo.DataSetName) Is Nothing Then
            dsAcordo = DirectCast(Session.Item(dsAcordo.DataSetName), wsAcoesComerciais.DatasetAcordo)
        End If
    End Sub

    Private Sub SalvaEstado()
        If Not dsAcordo Is Nothing Then _
            Session.Add(dsAcordo.DataSetName, dsAcordo)
    End Sub

    Private Sub CarregaGrids(ByVal codFornecedor As Decimal)
        Dim ds As wsAcoesComerciais.DatasetAcordo
        ds = Controller.ObterAcordosPendente(codFornecedor)
        dsAcordo = CalcularRestantePagar(Controller.ObterAcordosPendente(codFornecedor))
        uwgAcordos.DataBind()

        Dim dsCHRecebidoFornecedor As New wsAcoesComerciais.DatasetCHRecebidoFornecedor
        dsCHRecebidoFornecedor = Controller.ObterCHsRecebidoFornecedor(0, 0, codFornecedor, Nothing, Nothing, Nothing, 1, 0)

        Dim dsOPRecebidoFornecedor As New wsAcoesComerciais.DatasetOPRecebidaFornecedor
        dsOPRecebidoFornecedor = Controller.ObterOPsRecebidaFornecedor(0, 0, codFornecedor, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, 1, String.Empty, 0, 0, 0, 0)

        uwgRecebimentos.DataSource = Me.CriaDsRecebimentos(dsCHRecebidoFornecedor, dsOPRecebidoFornecedor)
        uwgRecebimentos.DataBind()
        'Formata colunas do grid
        With uwgRecebimentos
            .Columns(5).CellStyle.HorizontalAlign = HorizontalAlign.Center
            .Columns(5).Format = "dd/MM/yyyy"
            .Columns(6).CellStyle.HorizontalAlign = HorizontalAlign.Right
            .Columns(6).Format = "R$  ###,###,##0.00"
        End With

        Me.ucFornecedor.CodFornecedor = codFornecedor
        Me.LimpaControles()
    End Sub

    Private Function CriaDsRecebimentos(ByVal dsCHRecebidoFornecedor As wsAcoesComerciais.DatasetCHRecebidoFornecedor, ByVal dsOPRecebidoFornecedor As wsAcoesComerciais.DatasetOPRecebidaFornecedor) As DataTable
        Dim dt As New DataTable

        With dt
            .Columns.Add("TIPO", GetType(String))
            .Columns.Add("DOCUMENTO", GetType(Decimal))
            .Columns.Add("BANCO", GetType(String))
            .Columns.Add("AGENCIA", GetType(String))
            .Columns.Add("DATARECEBIMENTO", GetType(Date))
            .Columns.Add("VALOR DO CHEQUE - OP", GetType(Decimal))
        End With

        For Each drCHRecebidoFornecedor As wsAcoesComerciais.DatasetCHRecebidoFornecedor.T0118872Row _
            In dsCHRecebidoFornecedor.T0118872.Rows
            Dim dr As DataRow = dt.NewRow()

            dr.Item("TIPO") = "CH"
            dr.Item("DOCUMENTO") = drCHRecebidoFornecedor.NUMCHQ
            dr.Item("BANCO") = drCHRecebidoFornecedor.CODBCO
            dr.Item("AGENCIA") = drCHRecebidoFornecedor.CODAGE
            dr.Item("DATARECEBIMENTO") = drCHRecebidoFornecedor.DATRCBCHQ
            dr.Item("VALOR DO CHEQUE - OP") = drCHRecebidoFornecedor.VLRCHQ

            dt.Rows.Add(dr)
        Next

        For Each drOPRecebidoFornecedor As wsAcoesComerciais.DatasetOPRecebidaFornecedor.T0118880Row _
            In dsOPRecebidoFornecedor.T0118880.Rows
            Dim dr As DataRow = dt.NewRow()

            dr.Item("TIPO") = "OP"
            dr.Item("DOCUMENTO") = drOPRecebidoFornecedor.NUMORDPGTFRN
            dr.Item("BANCO") = drOPRecebidoFornecedor.CODBCO
            dr.Item("AGENCIA") = drOPRecebidoFornecedor.CODAGE
            dr.Item("DATARECEBIMENTO") = drOPRecebidoFornecedor.DATRCBORDPGT
            dr.Item("VALOR DO CHEQUE - OP") = drOPRecebidoFornecedor.VLRORDPGT

            dt.Rows.Add(dr)
        Next

        Return dt

    End Function

    Private Function CalculaValorRestantePagar(ByVal drAcordoPendente As wsAcoesComerciais.DatasetAcordo.tbAcordosPendenteRow) As Decimal
        If chkBaixarNegociado.Checked Then
            Return txtVlrPmsSel1.ValueDecimal - txtVlrPgtSel.ValueDecimal
        Else
            Return txtVlrPmsSel.ValueDecimal - txtVlrPgtSel.ValueDecimal
        End If

        'With drAcordoPendente
        '    Return .VlrNgcPms - .VlrPgoPms
        'End With
        'Else
        'With drAcordoPendente
        '    Return .VlrEftPms - .VlrPgoPms
        'End With
        'End If
    End Function

#End Region

#Region " Metodos de Controles "

    Private Sub EfetuarCalculoVlrRestante()
        If chkBaixarNegociado.Checked Then
            txtVlrRst.Value = txtVlrPmsSel1.ValueDecimal - txtVlrPgtSel.ValueDecimal
        Else
            txtVlrRst.Value = txtVlrPmsSel.ValueDecimal - txtVlrPgtSel.ValueDecimal
        End If
    End Sub

    Private Function EfetuarCalculosAcordos() As Boolean
        Dim AcumulaAC As Decimal = 0        'vlrGenerico
        Dim AcumulaAC1 As Decimal = 0       'Negociado
        Dim AcumulaAC2 As Decimal = 0       'Pago
        Dim AcumulaAC3 As Decimal = 0       'Efetivado
        txtVlrPmsSel.Value = AcumulaAC
        txtVlrPmsSel1.Value = AcumulaAC1 - AcumulaAC2
        For Each uwgLinha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In uwgAcordos.Rows
            ' COLUNA 0 É A COLUNA DO CHECKBOX
            If Convert.ToBoolean(uwgLinha.Cells(0).Value) Then
                ' negociado
                AcumulaAC1 += ConverterCurrencyToDecimal(uwgLinha.Cells(9).Value)
                ' pago
                AcumulaAC2 += ConverterCurrencyToDecimal(uwgLinha.Cells(10).Value)
                ' efetivado
                AcumulaAC3 += ConverterCurrencyToDecimal(uwgLinha.Cells(11).Value)
                ' Diferenca
                If Not IsNumeric(uwgLinha.Cells(13).Value) Then
                    Util.AdicionaJsAlert(Me.Page, "Existem números inválidos na coluna 'Valor Restante'")
                    Return False
                End If
                If ConverterCurrencyToDecimal(uwgLinha.Cells(12).Value) <> Convert.ToDecimal(uwgLinha.Cells(13).Value) Then
                    uwgLinha.Cells(12).Value = Convert.ToDecimal(uwgLinha.Cells(13).Value)
                End If
                AcumulaAC += ConverterCurrencyToDecimal(uwgLinha.Cells(12).Value)
            End If
        Next
        If chkBaixarNegociado.Checked Then
            txtVlrPmsSel.Value = AcumulaAC3 - AcumulaAC2
            txtVlrPmsSel1.Value = AcumulaAC
            Me.EfetuarCalculoVlrRestante()
        Else
            txtVlrPmsSel.Value = AcumulaAC
            txtVlrPmsSel1.Value = AcumulaAC1 - AcumulaAC2
            Me.EfetuarCalculoVlrRestante()
        End If
        Return True
    End Function

    Private Sub EfetuarCalculosRecebimentos()
        Dim AcumulaPn As Decimal = 0
        Dim AcumulaPn1 As Decimal = 0
        txtVlrPgtSel.Value = AcumulaPn

        For Each uwgLinha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In uwgRecebimentos.Rows
            ' COLUNA 0 É A COLUNA DO CHECKBOX
            If Convert.ToBoolean(uwgLinha.Cells(0).Value) Then
                AcumulaPn += ConverterCurrencyToDecimal(uwgLinha.Cells(6).Value)
            End If
        Next

        txtVlrPgtSel.Value = AcumulaPn
        Me.EfetuarCalculoVlrRestante()

    End Sub

    Private Sub LimpaControles()
        txtVlrPgtSel.Value = 0
        txtVlrPmsSel.Value = 0
        txtVlrPmsSel1.Value = 0
        txtVlrRst.Value = 0
        'chkBaixarNegociado.Checked = False
    End Sub

#End Region

#Region " Metodos de Regras "

    Private Sub Atualizar()
        Dim AcumulaAC As Decimal = 0
        Dim AcumulaPn As Decimal = 0
        Dim PagtoSel As Decimal = 0

        PagtoSel = txtVlrPgtSel.ValueDecimal
        If PagtoSel = 0 Then
            Page.RegisterStartupScript("Alerta", "<script>alert('Nenhum pagamento foi selecionado.');</script>")
            Exit Sub
        End If

        Select Case Me.VerificaEscolha(AcumulaAC, AcumulaPn)
            Case Baixa.AcordoComercial      'Ações comerciais-Promessa
                If AcumulaAC >= PagtoSel Then
                    BaixaAcaoPendencia(AcumulaAC, AcumulaPn)
                Else
                    Page.RegisterStartupScript("Alerta", "<script>alert('O valor dos pagamentos devem ser totalmente usados.');</script>")
                End If
            Case Baixa.Pendencia            'Pendencias
                If PagtoSel = AcumulaPn Then
                    BaixaAcaoPendencia(AcumulaAC, AcumulaPn)
                Else
                    If PagtoSel > AcumulaPn Then
                        Page.RegisterStartupScript("Alerta", "<script>alert('O valor dos pagamentos devem ser totalmente usados.');</script>")
                    Else
                        Page.RegisterStartupScript("Alerta", "<script>alert('A pendência só pode ter baixa total.');</script>")
                    End If
                End If
            Case Baixa.Ambos   'Ações e Pendências
                If PagtoSel > AcumulaAC + AcumulaPn Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('O valor dos pagamentos devem ser totalmente usados.');</script>")
                ElseIf PagtoSel = AcumulaAC + AcumulaPn Then
                    BaixaAcaoPendencia(AcumulaAC, AcumulaPn)
                Else
                    If PagtoSel = AcumulaPn Then
                        BaixaAcaoPendencia(AcumulaAC, AcumulaPn)
                    ElseIf PagtoSel > AcumulaPn Then
                        BaixaAcaoPendencia(AcumulaAC, AcumulaPn)
                    Else
                        Page.RegisterStartupScript("Alerta", "<script>alert('Divergência de valores.');</script>")
                    End If
                End If
        End Select
    End Sub

    Private Function ConverterCurrencyToDecimal(ByVal vlr As Object) As Decimal
        Dim tvlr As String = Convert.ToString(vlr)
        If tvlr.StartsWith("R$") Then
            tvlr = tvlr.Replace("R$", String.Empty).Trim()
            If IsNumeric(tvlr) Then
                Return Convert.ToDecimal(tvlr)
            Else : Return 0
            End If
        Else
            If IsNumeric(tvlr) Then
                Return Convert.ToDecimal(tvlr)
            Else : Return 0
            End If
        End If
    End Function

    Private Sub BaixaAcaoPendencia(ByVal AcumulaAC As Decimal, ByVal AcumulaPn As Decimal)
        ' GRID E PENDENCIAS E ACORDOS
        For Each linhaPnd As Infragistics.WebUI.UltraWebGrid.UltraGridRow In uwgAcordos.Rows
            ' linha esta marcada
            If Convert.ToBoolean(linhaPnd.Cells(0).Value) Then
                Dim drGrdAcordos As wsAcoesComerciais.DatasetAcordo.tbGrdAcordosRow = _
                    dsAcordo.tbGrdAcordos.NewtbGrdAcordosRow()
                ' LER O DADOS DO GRID E COLOCA NO DATASET
                With drGrdAcordos
                    .TIPO = linhaPnd.Cells(1).Text
                    .DOCUMENTO = Convert.ToInt32(linhaPnd.Cells(2).Value)
                    .PEDIDO = Convert.ToInt32(linhaPnd.Cells(3).Value)
                    .FILIAL = Convert.ToInt32(linhaPnd.Cells(4).Value)
                    .FORMAPAGAMENTO = Convert.ToInt32(linhaPnd.Cells(5).Text.Split(" "c)(0).Trim())
                    .DESTINODESCONTO = Convert.ToInt32(linhaPnd.Cells(6).Text.Split(" "c)(0).Trim())
                    .DATANEGOCIACAO = Date.Parse(linhaPnd.Cells(7).Text.Trim())
                    .DATAPREVISAO = Date.Parse(linhaPnd.Cells(8).Text.Trim())
                    .VALORNEGOCIADO = ConverterCurrencyToDecimal(linhaPnd.Cells(9).Value)
                    .VALORPAGO = ConverterCurrencyToDecimal(linhaPnd.Cells(10).Value)
                    .VALOREFETIVADO = ConverterCurrencyToDecimal(linhaPnd.Cells(11).Value)
                    .VALORRESTANTEPAGAR = ConverterCurrencyToDecimal(linhaPnd.Cells(12).Value)
                    .FORNECEDOR = ucFornecedor.CodFornecedor

                    Try
                        .Cod_Acesso = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0).NOMACSUSRSIS.Trim
                    Catch ex As Exception
                        Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
                        Exit Sub
                    End Try

                End With
                dsAcordo.tbGrdAcordos.AddtbGrdAcordosRow(drGrdAcordos)
            End If
        Next

        ' GRID DE RECEBIMENTOS
        For Each linhaPnd As Infragistics.WebUI.UltraWebGrid.UltraGridRow In uwgRecebimentos.Rows
            ' linha esta marcada
            If Convert.ToBoolean(linhaPnd.Cells(0).Value) Then
                Dim drGrdCheques As wsAcoesComerciais.DatasetAcordo.tbGrdChequesRow = _
                    dsAcordo.tbGrdCheques.NewtbGrdChequesRow()
                ' LER O DADOS DO GRID E COLOCA NO DATASET
                With drGrdCheques
                    .TIPO = linhaPnd.Cells(1).Text
                    .DOCUMENTO = Convert.ToInt32(linhaPnd.Cells(2).Value)
                    .BANCO = Convert.ToInt32(linhaPnd.Cells(3).Value)
                    .AGENCIA = Convert.ToInt32(linhaPnd.Cells(4).Value)
                    .DATARECEBIMENTO = Date.Parse(linhaPnd.Cells(5).Text.Trim())
                    .VALORCH = ConverterCurrencyToDecimal(linhaPnd.Cells(6).Value)
                    .FORNECEDOR = ucFornecedor.CodFornecedor

                    Try
                        .Cod_Acesso = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0).NOMACSUSRSIS.Trim
                    Catch ex As Exception
                        Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
                        Exit Sub
                    End Try

                End With
                dsAcordo.tbGrdCheques.AddtbGrdChequesRow(drGrdCheques)
            End If
        Next

        Controller.EfetivarBaixaAcaoComercialPendencias(dsAcordo, Controller.ObterUsuariosCompraLogadoSistema.T0113471(0).NOMACSUSRSIS.Trim)
    End Sub

    Private Function VerificaEscolha(ByRef AcumulaAC As Decimal, ByRef AcumulaPn As Decimal) As Baixa
        Dim OP1 As Integer = 0
        Dim OP2 As Integer = 0
        For Each linha As Infragistics.WebUI.UltraWebGrid.UltraGridRow In uwgAcordos.Rows
            If Convert.ToBoolean(linha.Cells(0).Value) Then
                Select Case linha.Cells(1).Text
                    Case "Ac"
                        OP1 = 1     'Baixa somente Ações comerciais
                        AcumulaAC += ConverterCurrencyToDecimal(linha.Cells(12).Value)
                    Case "Pn"
                        OP2 = 2     'Baixa somente Pendências
                        AcumulaPn += ConverterCurrencyToDecimal(linha.Cells(12).Value)
                End Select
            End If
        Next
        If (OP1 > 0) And (OP2 = 0) Then
            Return Baixa.AcordoComercial
        ElseIf (OP2 > 0) And (OP1 = 0) Then
            Return Baixa.Pendencia
        ElseIf (OP1 > 0) And (OP2 > 0) Then
            Return Baixa.Ambos
        End If
    End Function

    Private Function Validar() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = String.Empty

        Try
            Validar = True
            'Fornecedor
            If ucFornecedor.CodFornecedor <= 0 Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "fornecedor não informado"
            End If

            If mensagemErro.Trim() <> String.Empty Then
                Page.RegisterStartupScript("Alerta", "<script>alert('" & (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1) & "');</script>")
                Return False
            End If
            lblErro.Visible = False
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Sub btnImprimirRecibo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimirRecibo.Click
        Try
            If Validar() = False Then
                Exit Sub
            End If

            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = True

            ImprimirRecibo()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            If Validar() = False Then
                Exit Sub
            End If

            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = False

            ImprimirRecibo()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ImprimirRecibo()
        Dim dsRelatorioRecibo As wsAcoesComerciais.DataSetRelatorioRecibo
        ' Obter dados do relatório e guardar na seção
        dsRelatorioRecibo = Controller.ObterRelatorioRecibo(Convert.ToInt32(ucFornecedor.CodFornecedor))
        WSCAcoesComerciais.dsRelatorioRecibo = dsRelatorioRecibo
        ' Guarda o nome do relatório na seção
        WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "cby002la.rpt"
        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

    Private Function CalcularRestantePagar(ByVal ds As wsAcoesComerciais.DatasetAcordo) As wsAcoesComerciais.DatasetAcordo
        Dim VlrNgcPms As Decimal = 0
        Dim VlrEftPms As Decimal = 0
        Dim VlrPgoPms As Decimal = 0

        For Each linha As wsAcoesComerciais.DatasetAcordo.tbAcordosPendenteRow In ds.tbAcordosPendente
            VlrNgcPms = 0
            VlrEftPms = 0
            VlrPgoPms = 0

            If Not linha.IsNull("VlrNgcPms") Then VlrNgcPms = linha.VlrNgcPms
            If Not linha.IsNull("VlrEftPms") Then VlrEftPms = linha.VlrEftPms
            If Not linha.IsNull("VlrPgoPms") Then VlrPgoPms = linha.VlrPgoPms

            If linha.codsitpms = 3 Then
                linha.ValorRestantePagar = VlrEftPms - VlrPgoPms
            Else
                linha.ValorRestantePagar = VlrNgcPms - VlrPgoPms
            End If

        Next
        Return ds
    End Function

#End Region

#End Region

End Class