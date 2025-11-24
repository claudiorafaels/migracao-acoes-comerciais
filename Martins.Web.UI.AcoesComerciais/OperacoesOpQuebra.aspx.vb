Public Class OperacoesOpQuebra
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetOperacaoBaixaOperacaoFornecedor1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetOperacaoBaixaOperacaoFornecedor
        CType(Me.DatasetOperacaoBaixaOperacaoFornecedor1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetOperacaoBaixaOperacaoFornecedor1
        '
        Me.DatasetOperacaoBaixaOperacaoFornecedor1.DataSetName = "DatasetOperacaoBaixaOperacaoFornecedor"
        Me.DatasetOperacaoBaixaOperacaoFornecedor1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetOperacaoBaixaOperacaoFornecedor1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtOpOriginal As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtTotVlrOP As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents btnIncluir As System.Web.UI.WebControls.Button
    Protected WithEvents btnExcluir As System.Web.UI.WebControls.Button
    Protected WithEvents btnConfirmar As System.Web.UI.WebControls.Button
    Protected WithEvents txtValorQuebra As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtCodigoFornecedor As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtNomeFornecedor As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents txtDecricaoHistorico As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents txtValorSaldo As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtValorTotal As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents uwgQuebra As Infragistics.WebUI.UltraWebGrid.UltraWebGrid
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents DatasetOperacaoBaixaOperacaoFornecedor1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetOperacaoBaixaOperacaoFornecedor
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTableCell

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

    Private Property mdContTot() As Decimal
        Get
            Dim result As Decimal = 0
            If Not viewstate("mdContTot") Is Nothing Then
                result = CType(viewState("mdContTot"), Decimal)
                Return result
            End If
        End Get
        Set(ByVal Value As Decimal)
            viewstate("mdContTot") = Value
        End Set
    End Property

    Private Property mdTotal() As Decimal
        Get
            Dim result As Decimal = 0
            If Not viewstate("mdTotal") Is Nothing Then
                result = CType(viewState("mdTotal"), Decimal)
                Return result
            End If
        End Get
        Set(ByVal Value As Decimal)
            viewstate("mdTotal") = Value
        End Set
    End Property

    Private Property mdSaldo() As Decimal
        Get
            Dim result As Decimal = 0
            If Not viewstate("mdSaldo") Is Nothing Then
                result = CType(viewState("mdSaldo"), Decimal)
                Return result
            End If
        End Get
        Set(ByVal Value As Decimal)
            viewstate("mdSaldo") = Value
        End Set
    End Property

    Private Property mlCont() As Integer
        Get
            Dim result As Integer = 0
            If Not viewstate("mlCont") Is Nothing Then
                result = CType(viewState("mlCont"), Integer)
                Return result
            End If
        End Get
        Set(ByVal Value As Integer)
            viewstate("mlCont") = Value
        End Set
    End Property

    Private Property msQbrVrl() As String
        Get
            Dim result As String = ""
            If Not viewstate("msQbrVrl") Is Nothing Then
                result = CType(viewState("msQbrVrl"), String)
                Return result
            End If
        End Get
        Set(ByVal Value As String)
            viewstate("msQbrVrl") = Value
        End Set
    End Property

    Private Property mvLinExc() As Integer
        Get
            Dim result As Integer = 0
            If Not viewstate("mvLinExc") Is Nothing Then
                result = CType(viewState("mvLinExc"), Integer)
                Return result
            End If
        End Get
        Set(ByVal Value As Integer)
            viewstate("mvLinExc") = Value
        End Set
    End Property

#End Region

#Region "Eventos"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ExpiraPagina()
            btnIncluir.Attributes.Add("OnClick", "javascript:mostraAndamento()")
            btnExcluir.Attributes.Add("OnClick", "javascript:mostraAndamento()")
            btnConfirmar.Attributes.Add("OnClick", "javascript:mostraAndamento()")

            If Not Page.IsPostBack Then
                recuperaVariaveisDeOperacoesOP()
                uwgQuebra.Rows.Clear()
                IniVar()
                VerificarHabDes()
                AdicionarEventoJavaScript()
                WSCAcoesComerciais.dsOperacaoBaixaOperacaoFornecedor = New wsAcoesComerciais.DatasetOperacaoBaixaOperacaoFornecedor
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncluir.Click
        Try
            Dim vValor As Decimal
            Dim vCodFrn As Integer
            Dim vNomFrn As String
            Dim dAux As Decimal

            vCodFrn = 0
            vNomFrn = ""
            vValor = 0

            If Not ValidarCamposInsere() Then
                Exit Sub
            End If

            dAux = txtValorQuebra.ValueDecimal
            vValor = txtValorQuebra.ValueDecimal
            vCodFrn = Convert.ToInt32(ucFornecedor.CodFornecedor)
            vNomFrn = ucFornecedor.NomFornecedor

            IncluirLinhaEspcifico(vCodFrn, vNomFrn, vValor)

            mdContTot = mdContTot + dAux
            mdSaldo = mdSaldo - dAux
            txtValorSaldo.ValueDecimal = mdSaldo
            txtValorTotal.ValueDecimal = mdContTot
            VerificarHabDes()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnConfirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmar.Click
        Try
            If Not ValidarCamposConfirmar() Then
                Exit Sub
            End If

            btnIncluir.Enabled = False
            btnExcluir.Enabled = False
            btnConfirmar.Enabled = False

            RealizarQuebra()

            Page.RegisterStartupScript("Saida", "<script>javascript:window.close();</script>")
            'Page.RegisterStartupScript("Saida", "<script> opener.__doPostBack('lkbProcessaCloseModal',''); window.close(); </script>")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        Finally
            flagProcessando = False
        End Try
    End Sub

    Private Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click
        Try
            Dim lIndice As Long
            Dim vValor As Decimal
            Dim dAux As Decimal
            Dim bAchou As Boolean
            Dim lTam As Long
            Dim lCont As Long
            Dim lLinha As Long

            If Not ValidarCamposExcluir() Then
                Exit Sub
            End If

            'Verifica se tem linha selecionada
            Dim temLinhaSelecionada As Boolean
            For i As Integer = 0 To uwgQuebra.DisplayLayout.Rows.Count - 1
                If uwgQuebra.DisplayLayout.Rows(i).Selected Then
                    temLinhaSelecionada = True
                    Exit For
                End If
            Next

            'Se não foi selecionado linha e existir mais de uma linha mostra mensagem
            'solicitando que seja selecionado uma linha
            If Not temLinhaSelecionada Then
                Util.AdicionaJsAlert(Me.Page, "Selecione a linha que deseja excluir")
                Exit Sub
            End If

            'Obtem os códigos a partir da linha
            Dim codigo As Integer = Convert.ToInt32(uwgQuebra.DisplayLayout.ActiveRow().GetCellValue(uwgQuebra.Columns.Item(0)))
            Dim Fornecedor As String = Convert.ToString(uwgQuebra.DisplayLayout.ActiveRow().GetCellValue(uwgQuebra.Columns.Item(1)))
            Dim valor As Decimal = Convert.ToDecimal(uwgQuebra.DisplayLayout.ActiveRow().GetCellValue(uwgQuebra.Columns.Item(2)))
            Dim tipo As String = Convert.ToString(uwgQuebra.DisplayLayout.ActiveRow().GetCellValue(uwgQuebra.Columns.Item(3)))

            'Busca a linha no dataset
            DatasetOperacaoBaixaOperacaoFornecedor1 = WSCAcoesComerciais.dsOperacaoBaixaOperacaoFornecedor
            For Each linha As wsAcoesComerciais.DatasetOperacaoBaixaOperacaoFornecedor.tbQuebraOPRow In DatasetOperacaoBaixaOperacaoFornecedor1.tbQuebraOP
                If linha.RowState <> DataRowState.Deleted Then
                    With linha
                        If .Codigo = codigo And _
                           .Fornecedor = Fornecedor And _
                           .Valor = valor And _
                           .Tipo = "I" Then
                            linha.Delete()
                            Exit For
                        End If
                    End With
                End If
            Next

            'Salva o dataset na seção
            WSCAcoesComerciais.dsOperacaoBaixaOperacaoFornecedor = DatasetOperacaoBaixaOperacaoFornecedor1

            dAux = valor
            vValor = valor
            mdContTot = mdContTot - dAux
            mdSaldo = mdSaldo + dAux
            txtValorSaldo.ValueDecimal = mdSaldo
            txtValorTotal.ValueDecimal = mdContTot

            VerificarHabDes()
            txtValorQuebra.Text = ""
            Util.AdicionaJsFocus(Me.Page, CType(txtValorQuebra, System.Web.UI.WebControls.WebControl))

            uwgQuebra.DataBind()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

#Region "Metodos"

    Private Sub AdicionarEventoJavaScript()
        btnExcluir.Attributes.Add("OnClick", "javascript:return confirm('Deseja excluir este item ?')")
    End Sub

    Private Sub recuperaVariaveisDeOperacoesOP()
        Dim hsOperacoesOp As Hashtable
        Dim OpOriginal As Integer
        Dim TotVlrOP As Decimal
        Dim CodigoFornecedor As Integer
        Dim NomeFornecedor As String
        Dim DecricaoHistorico As String
        Dim ValorSaldo As Decimal

        hsOperacoesOp = WSCAcoesComerciais.hashtableOperacoesOP()
        txtValorQuebra.Text = ""
        txtOpOriginal.ValueInt = Convert.ToInt32(hsOperacoesOp("txtOpOriginal"))
        txtTotVlrOP.ValueDecimal = Convert.ToDecimal(hsOperacoesOp("txtTotVlrOP"))
        txtCodigoFornecedor.ValueInt = Convert.ToInt32(hsOperacoesOp("txtCodigoFornecedor"))
        txtNomeFornecedor.Text = Convert.ToString(hsOperacoesOp("txtNomeFornecedor"))
        txtDecricaoHistorico.Text = Convert.ToString(hsOperacoesOp("txtDecricaoHistorico"))
        txtValorSaldo.ValueDecimal = Convert.ToDecimal(hsOperacoesOp("txtValorSaldo"))

    End Sub

    Private Sub VerificarHabDes()
        With uwgQuebra
            If .Rows.Count <= 0 Then
                btnExcluir.Enabled = False
                btnConfirmar.Enabled = False
                Exit Sub
            End If
            If Convert.ToString(.Rows.Item(.Rows.Count - 1).GetCellValue(.Columns.FromKey("Tipo"))) <> "I" Then
                btnExcluir.Enabled = False
                btnConfirmar.Enabled = False
            Else
                btnExcluir.Enabled = True
                btnConfirmar.Enabled = True
            End If
        End With
    End Sub

    Private Function ValidarCamposInsere() As Boolean
        Dim mensagemErro As String = String.Empty
        Dim intlencont As Integer
        Dim intcont As Integer
        Dim vVlrQbr As Decimal
        Dim vVlrTot As Decimal
        Dim vVlrTotOp As Decimal
        Dim vVlrOp As Decimal

        If ucFornecedor.CodFornecedor <= 0 Then
            If mensagemErro.Length > 0 Then mensagemErro &= ", "
            mensagemErro &= "O campo fornecedor é obrigatório"
        End If
        If txtValorQuebra.ValueDecimal = 0 Then
            If mensagemErro.Length > 0 Then mensagemErro &= ", "
            mensagemErro &= "O campo valor tem que ser maior que zero(0)"
        End If

        vVlrQbr = txtValorQuebra.ValueDecimal
        vVlrTot = txtValorTotal.ValueDecimal
        vVlrTotOp = vVlrQbr + vVlrTot
        vVlrOp = txtTotVlrOP.ValueDecimal

        If vVlrTotOp > vVlrOp Then
            If mensagemErro.Length > 0 Then mensagemErro &= ", "
            mensagemErro &= "O valor total não pode ser maior que o valor da Op."
        End If

        If mensagemErro.Trim() <> String.Empty Then
            Page.RegisterStartupScript("Alerta", "<script>alert('" & (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1) & "');</script>")
            Return False
            Exit Function
        End If

        Return True
    End Function

    Private Function ValidarCamposExcluir() As Boolean
        Dim mensagemErro As String = String.Empty

        ValidarCamposExcluir = False
        With uwgQuebra
            If .Rows.Count = 0 Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "Insere algum item na lista"
            End If
            If Convert.ToString(.Rows.Item(.Rows.Count - 1).GetCellValue(.Columns.FromKey("Tipo"))) <> "I" Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "Selecione algum item na lista"
            End If
        End With

        If mensagemErro.Trim() <> String.Empty Then
            Page.RegisterStartupScript("Alerta", "<script>alert('" & (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1) & "');</script>")
            Return False
            Exit Function
        End If

        Return True
    End Function

    Private Function ValidarCamposConfirmar() As Boolean
        Dim mensagemErro As String = String.Empty
        Dim lCont As Integer
        Dim lTam As Integer
        Dim bExiste As Boolean
        Dim sQbr As String

        ValidarCamposConfirmar = False

        If txtValorTotal.ValueDecimal <> mdTotal Then
            If mensagemErro.Length > 0 Then mensagemErro &= ", "
            mensagemErro &= "O valor total da quebra não pode ser diferente do valor da Op"
        End If

        bExiste = False
        sQbr = ""
        msQbrVrl = ""
        lCont = 0
        With uwgQuebra
            If .Rows.Count > 0 Then
                lTam = .Rows.Count
                While (lCont < lTam)
                    If Convert.ToString(.Rows.Item(lCont).GetCellValue(.Columns.Item(3))) = "I" Then
                        bExiste = True
                        'Adiciona na string sQbr o código do fornecedor
                        Dim colunaCodigoFornecedor As String = Convert.ToString(.Rows.Item(lCont).GetCellValue(.Columns.Item(0)))
                        sQbr = CStr(CDbl(Trim(colunaCodigoFornecedor)))
                        sQbr = Format$(Val(sQbr), "000000000")
                        'Adiciona na string sQbr o valor da quebra
                        Dim colunaValor As String = Convert.ToString(.Rows.Item(lCont).GetCellValue(.Columns.Item(2)))
                        sQbr = Trim(sQbr & Util.TrocarVirgulaPorPonto(Trim(colunaValor)))
                        msQbrVrl = Trim(msQbrVrl & sQbr & ";")
                    End If
                    lCont = lCont + 1
                End While
                If Not bExiste Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "Não existe nenhum valor a ser quebrado"
                End If
            Else
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "Não existe nenhum valor a ser quebrado"
            End If
        End With
        mlCont = lCont

        If mensagemErro.Trim() <> String.Empty Then
            Page.RegisterStartupScript("Alerta", "<script>alert('" & (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1) & "');</script>")
            Return False
            Exit Function
        End If

        Return True
    End Function

    Private Sub RealizarQuebra()
        Try
            Dim hsOperacoesOp As Hashtable
            Dim TipOpeBxaOrdPgtFrn As Integer
            Dim NumOrdPgtFrn As Integer
            Dim CodBco As Integer
            Dim CodAge As Integer
            Dim DatRcbOrdPgtAlt As Date
            Dim NomAcsUsrBxaOrdPgtAlt As String

            hsOperacoesOp = WSCAcoesComerciais.hashtableOperacoesOP

            TipOpeBxaOrdPgtFrn = Convert.ToInt32(hsOperacoesOp("mlTipOpeBxaOrdPgtFrnPesq"))
            NumOrdPgtFrn = Convert.ToInt32(hsOperacoesOp("gvOp"))
            CodBco = Convert.ToInt32(hsOperacoesOp("gvBanco"))
            CodAge = Convert.ToInt32(hsOperacoesOp("gvAgencia"))
            DatRcbOrdPgtAlt = Convert.ToDateTime(hsOperacoesOp("gvDtaRec"))

            Try
                NomAcsUsrBxaOrdPgtAlt = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0).NOMACSUSRSIS.Trim
            Catch ex As Exception
                Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
                Exit Sub
            End Try

            'Chama a procedure que vai gravar a transferencia 
            Controller.AtualizarOperacaoBaixaOperacaoFornecedor(4, _
                                                                0, _
                                                                0, _
                                                                Nothing, _
                                                                0, _
                                                                TipOpeBxaOrdPgtFrn, _
                                                                NumOrdPgtFrn, _
                                                                CodBco, _
                                                                CodAge, _
                                                                DatRcbOrdPgtAlt, _
                                                                NomAcsUsrBxaOrdPgtAlt, _
                                                                msQbrVrl, _
                                                                mlCont, _
                                                                Nothing, _
                                                                Nothing, _
                                                                Nothing, _
                                                                Nothing, _
                                                                Nothing)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub IniVar()
        mdContTot = 0
        mdTotal = txtTotVlrOP.ValueDecimal
        mlCont = 0
        msQbrVrl = ""
        mvLinExc = 0
        mdSaldo = txtTotVlrOP.ValueDecimal
    End Sub

    Private Sub IncluirLinhaEspcifico(ByVal vCodFr As Integer, ByVal vNomFrn As String, ByVal vVlrQbr As Decimal)
        Dim linha As wsAcoesComerciais.DatasetOperacaoBaixaOperacaoFornecedor.tbQuebraOPRow

        'Recuper o dataset da seção
        DatasetOperacaoBaixaOperacaoFornecedor1 = WSCAcoesComerciais.dsOperacaoBaixaOperacaoFornecedor

        linha = DatasetOperacaoBaixaOperacaoFornecedor1.tbQuebraOP.NewtbQuebraOPRow
        With linha
            .Codigo = vCodFr
            .Fornecedor = vNomFrn
            .Valor = vVlrQbr
            .Tipo = "I"
        End With

        'Insere a linha no dataset
        DatasetOperacaoBaixaOperacaoFornecedor1.tbQuebraOP.AddtbQuebraOPRow(linha)

        'Salva o dataset na seção
        WSCAcoesComerciais.dsOperacaoBaixaOperacaoFornecedor = DatasetOperacaoBaixaOperacaoFornecedor1

        uwgQuebra.DataBind()
    End Sub

    Public Sub ExpiraPagina()
        With HttpContext.Current.Response
            .Buffer = True
            .ExpiresAbsolute = DateTime.Now.AddMinutes(-1)
            .Expires = 0
            .CacheControl = "no-cache"
        End With
    End Sub

#End Region

End Class