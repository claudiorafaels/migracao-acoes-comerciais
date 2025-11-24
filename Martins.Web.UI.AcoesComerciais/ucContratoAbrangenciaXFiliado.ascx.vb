Public Class ucContratoAbrangenciaXFiliado
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
    Protected WithEvents grdContratosAssociados As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetContrato1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContrato
    Protected WithEvents txtTIPEDEABGMIX As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents cmbTIPEDEABGMIX As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblErroTIPEDEABGMIX As System.Web.UI.WebControls.Label
    Protected WithEvents cmdAtualizar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents TD02 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD01 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents cmdExportar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents grdContratosAssociados2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblErroCODEDEABGMIX As System.Web.UI.WebControls.Label
    Protected WithEvents cmbCODEDEABGMIX As System.Web.UI.WebControls.DropDownList
    Protected WithEvents InpArquivoOrigem As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents lblErroNUMCSLCTTFRN As System.Web.UI.WebControls.Label
    Protected WithEvents cmbNUMCSLCTTFRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNUMCSLCTTFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit

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
            TD01.Visible = False
            TD02.Visible = False
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
                Me.BindgrdContratosAssociados()
            End If
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
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

    Private Sub grdContratosAssociados2_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdContratosAssociados2.PageIndexChanged
        Try
            DatasetContrato1 = Page.dsContrato
            Me.grdContratosAssociados2.CurrentPageIndex = e.NewPageIndex
            grdContratosAssociados2.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtNUMCSLCTTFRN_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtNUMCSLCTTFRN.ValueChange
        If cmbNUMCSLCTTFRN.SelectedValue <> txtNUMCSLCTTFRN.Text Then
            cmbNUMCSLCTTFRN.SelectedValue = txtNUMCSLCTTFRN.Text
            cmbNUMCSLCTTFRN_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub cmbCODEDEABGMIX_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCODEDEABGMIX.SelectedIndexChanged
        Try
            Me.BindgrdContratosAssociados()
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub cmdExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportar.Click
        Try
            If grdContratosAssociados.Items.Count = 0 Then
                Util.AdicionaJsAlert(MyBase.Page, "Não existem dados para serem exportados")
                Exit Sub
            End If

            Response.Clear()
            grdContratosAssociados.EnableViewState = False
            grdContratosAssociados.AllowSorting = False
            grdContratosAssociados.AllowPaging = False
            Response.ContentType = "Application/x-msexcel"
            Dim oStringWriter As New System.IO.StringWriter
            Dim oHtmlTextWriter As New System.Web.UI.HtmlTextWriter(oStringWriter)

            oHtmlTextWriter.Write("<html><head>")
            oHtmlTextWriter.Write("</head><body>")
            oHtmlTextWriter.WriteBeginTag("form runat=server ")
            oHtmlTextWriter.WriteAttribute("target", "_top")
            oHtmlTextWriter.Write(">")
            grdContratosAssociados.HeaderStyle.BackColor = Color.DarkBlue
            grdContratosAssociados.HeaderStyle.ForeColor = Color.White
            grdContratosAssociados.ItemStyle.BackColor = Color.WhiteSmoke
            grdContratosAssociados.ItemStyle.Wrap = False
            grdContratosAssociados.AlternatingItemStyle.BackColor = Color.LightSkyBlue
            grdContratosAssociados.AlternatingItemStyle.Wrap = False
            grdContratosAssociados.RenderControl(oHtmlTextWriter)
            oHtmlTextWriter.Write("</form></body></html>")
            Response.AddHeader("Content-Disposition", "attachment;filename=Filiados.xls")
            Response.Write(oStringWriter.ToString())
            Response.End()
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
        Me.BindgrdContratosAssociados()
    End Sub

    Public Sub CarregarCmbNUMCSLCTTFRN()
        Me.Page.dsContrato.Merge(Controller.ObterContratoXClausulaContrato(Nothing, Nothing, Nothing, Decimal.Zero, Convert.ToDecimal(Me.Page().NUMCTTFRN)), False, MissingSchemaAction.Ignore)
        With cmbNUMCSLCTTFRN
            If Me.Page.dsContrato.T0124953.Rows.Count = 0 Then
                Me.Page.dsContrato.Merge(Controller.ObterClausulasContrato("", 0).T0124953, False, MissingSchemaAction.Ignore)
            End If
            .Items.Clear()
            For Each drT0124961 As wsAcoesComerciais.DatasetContrato.T0124961Row In Me.Page.dsContrato.T0124961.Rows
                If drT0124961.IsDATDSTCSLNull Then
                    .Items.Add(New ListItem(drT0124961.NUMCSLCTTFRN.ToString() & " - " & drT0124961.T0124953Row.DESCSLCTTFRN, drT0124961.NUMCSLCTTFRN.ToString()))
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
                    .Items.Add(New ListItem(linhaT0125011.DESEDEABGMIX.ToString(), linhaT0125011.TIPEDEABGMIX.ToString()))
                End If
            Next
            cmbTIPEDEABGMIX.Items.Insert(0, New ListItem(String.Empty, String.Empty))
        End With

        If cmbTIPEDEABGMIX.Items.Count = 2 Then
            cmbTIPEDEABGMIX.SelectedValue = cmbTIPEDEABGMIX.Items(1).Value
        End If

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

        If cmbTIPEDEABGMIX.SelectedValue = "1" Or cmbTIPEDEABGMIX.SelectedValue = "4" Then
            cmbCODEDEABGMIX.Enabled = False
            Me.BindgrdContratosAssociados()
        Else
            cmbCODEDEABGMIX.Enabled = True
        End If

        For Each linha As wsAcoesComerciais.DatasetContrato.T0124996Row In Page.dsContrato.T0124996
            If linha.NUMCSLCTTFRN = Convert.ToDecimal(cmbNUMCSLCTTFRN.SelectedValue) And linha.TIPEDEABGMIX = Convert.ToDecimal(cmbTIPEDEABGMIX.SelectedValue) Then
                With cmbCODEDEABGMIX
                    .Items.Add(New ListItem(linha.CODEDEABGMIX.ToString, linha.CODEDEABGMIX.ToString))
                End With
            End If
        Next
        cmbCODEDEABGMIX.Items.Insert(0, New ListItem("", ""))

        If cmbCODEDEABGMIX.Items.Count = 2 Then
            cmbCODEDEABGMIX.SelectedValue = String.Empty
            cmbCODEDEABGMIX.SelectedValue = cmbCODEDEABGMIX.Items(1).Value
        End If
    End Sub

    Private Sub BindgrdContratosAssociados()
        Try
            '1) Limpa a table "queryFiliados"
            Me.Page.dsContrato.queryFiliados.Rows.Clear()

            '2) Declara os parametros
            Dim NUMCSLCTTFRN As Decimal
            Dim TIPEDEABGMIX As Decimal
            Dim CODEDEABGMIX As Decimal

            '3) Atribui valor aos parametros, buscando dos combos
            If IsNumeric(cmbNUMCSLCTTFRN.SelectedValue) Then
                NUMCSLCTTFRN = Convert.ToDecimal(cmbNUMCSLCTTFRN.SelectedValue)
            End If
            If IsNumeric(cmbTIPEDEABGMIX.SelectedValue) Then
                TIPEDEABGMIX = Convert.ToDecimal(cmbTIPEDEABGMIX.SelectedValue)
            End If
            If cmbTIPEDEABGMIX.SelectedValue = "1" Or cmbTIPEDEABGMIX.SelectedValue = "4" Then
                CODEDEABGMIX = Page.CODFRN
            ElseIf IsNumeric(cmbCODEDEABGMIX.SelectedValue) Then
                CODEDEABGMIX = Convert.ToDecimal(cmbCODEDEABGMIX.SelectedValue)
            End If

            '4) Consulta os filiados 
            Dim ds As wsAcoesComerciais.DatasetContrato
            If NUMCSLCTTFRN > 0 _
                And TIPEDEABGMIX > 0 _
                And CODEDEABGMIX > 0 Then
                ds = Controller.ObterFiliadosContrato(Page.NUMCTTFRN, NUMCSLCTTFRN, TIPEDEABGMIX, CODEDEABGMIX)
                Page.dsContrato.Merge(ds.queryFiliados, False, MissingSchemaAction.Ignore)
            End If

            '5) Popula o grid
            Me.DatasetContrato1 = Me.Page.dsContrato
            Me.grdContratosAssociados.DataBind()
            Me.grdContratosAssociados2.DataBind()

        Catch ex As Exception
            If Me.grdContratosAssociados2.CurrentPageIndex > 0 Then
                Me.grdContratosAssociados2.CurrentPageIndex = 0
                Me.grdContratosAssociados2.DataBind()
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

    Private Sub colocaMesmoValorDosCombosNoText()
        txtNUMCSLCTTFRN.Text = cmbNUMCSLCTTFRN.SelectedValue
        txtTIPEDEABGMIX.Text = cmbTIPEDEABGMIX.SelectedValue
    End Sub

    Private Sub PreencheLinhaT0125020(ByRef dr As wsAcoesComerciais.DatasetContrato.T0125020Row)
        With dr
            .NUMCTTFRN = Page.NUMCTTFRN
            .NUMCSLCTTFRN = Convert.ToDecimal(cmbNUMCSLCTTFRN.SelectedValue)
            .TIPEDEABGMIX = Convert.ToDecimal(cmbTIPEDEABGMIX.SelectedValue)
            .CODEDEABGMIX = Convert.ToDecimal(cmbCODEDEABGMIX.SelectedValue)
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
            End If

            If Not cmbCODEDEABGMIX.Items.FindByValue(.CODEDEABGMIX.ToString) Is Nothing Then
                cmbCODEDEABGMIX.SelectedValue = .CODEDEABGMIX.ToString
            End If
        End With
    End Sub

    Private Function SalvarDados() As Boolean
        Dim ArqInf As System.io.FileInfo
        Dim CaminhoArquivo As String

        Try
            '1) Valida os dados
            If Not ValidarDados() Then
                Exit Function
            End If

            '2) Transfere o arquivo para o servidor
            upLoadArquivo()

            '3) Pega o nome do arquivo
            ArqInf = New System.IO.FileInfo(InpArquivoOrigem.PostedFile.FileName)
            CaminhoArquivo = "C:\Framework\Interfaces\Martins.Web.UI.AcoesComerciais\Upload\" & ArqInf.Name

            '4) Envia o nome do arquivo para ser persisitido
            Controller.AtualizarAbrangenciaXContratoXFiliadoDeArquivoCSV(Page.NUMCTTFRN, Convert.ToDecimal(cmbNUMCSLCTTFRN.SelectedValue), Convert.ToDecimal(cmbTIPEDEABGMIX.SelectedValue), Convert.ToDecimal(cmbCODEDEABGMIX.SelectedValue), CaminhoArquivo)

            '5) Atualiza o grid
            BindgrdContratosAssociados()

        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        Finally
            If Not ArqInf Is Nothing Then ArqInf = Nothing
        End Try
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

            If txtNUMCSLCTTFRN.ValueInt.Equals(3) Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "não é permitido editar clásula de Anualidade, ela é gerada pelo sistema"
            ElseIf txtNUMCSLCTTFRN.ValueInt.Equals(10) Then  ' Trimestralidade
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "não é permitido editar clásula de Trimestralidade, ela é gerada pelo sistema"
            End If

            If InpArquivoOrigem.Value = "" Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "selecione o arquivo de origem"
                'If Not deuFoco Then
                '    Util.AdicionaJsFocus(MyBase.Page, CType(InpArquivoOrigem, WebControl))
                'End If
                'deuFoco = True
            Else
                Dim ArqInf As New System.io.FileInfo(InpArquivoOrigem.PostedFile.FileName)
                If Not ArqInf.Extension.ToLower.Equals(".csv") Then
                    'Mensagem
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "tipo de arquivo inválido, permitido somente arquivo CSV"
                    'If Not deuFoco Then
                    '    Util.AdicionaJsFocus(MyBase.Page, CType(InpArquivoOrigem, WebControl))
                    'End If
                    'deuFoco = True
                End If
                If Not ArqInf Is Nothing Then ArqInf = Nothing
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

        Return True

    End Function

    Private Sub upLoadArquivo()
        Dim ArqInf As System.io.FileInfo
        Dim CaminhoArquivo As String

        Try
            If Not ValidarDados() Then
                Exit Sub
            End If

            ArqInf = New System.IO.FileInfo(InpArquivoOrigem.PostedFile.FileName)
            CaminhoArquivo = MyBase.Page.Request.Url.Segments(0) & MyBase.Page.Request.Url.Segments(1) & "Upload/" & ArqInf.Name
            InpArquivoOrigem.PostedFile.SaveAs(Server.MapPath(CaminhoArquivo))

        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        Finally
            If Not ArqInf Is Nothing Then ArqInf = Nothing
        End Try

    End Sub

#End Region

#End Region

End Class