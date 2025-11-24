Public Class Apuracao
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetClausulaContrato = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetClausulaContrato
        Me.DatasetEntidade = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetEntidade
        Me.DatasetContrato = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContrato
        CType(Me.DatasetClausulaContrato, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetEntidade, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetContrato, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetClausulaContrato
        '
        Me.DatasetClausulaContrato.DataSetName = "DatasetClausulaContrato"
        Me.DatasetClausulaContrato.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DatasetEntidade
        '
        Me.DatasetEntidade.DataSetName = "DatasetEntidade"
        Me.DatasetEntidade.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DatasetContrato
        '
        Me.DatasetContrato.DataSetName = "DatasetContrato"
        Me.DatasetContrato.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetClausulaContrato, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetEntidade, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetContrato, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApurarTudo As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApurarFornecedores As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApurarCategoria As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnItem As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnItensNovos As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnSair As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ddlClausula As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DatasetClausulaContrato As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetClausulaContrato
    Protected WithEvents txtDataApuracao As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtNumContrato As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtHoraInicio As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtHoraFim As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents chkTodos As System.Web.UI.WebControls.CheckBox
    Protected WithEvents DatasetEntidade As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetEntidade
    Protected WithEvents DatasetContrato As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContrato
    Protected WithEvents btnNova As System.Web.UI.WebControls.LinkButton
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

#Region " Eventos "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            End If

            btnApurarTudo.Attributes.Add("OnClick", "javascript:mostraAndamento()")
            btnApurarFornecedores.Attributes.Add("OnClick", "javascript:mostraAndamento()")
            btnApurarCategoria.Attributes.Add("OnClick", "javascript:mostraAndamento()")
            btnItem.Attributes.Add("OnClick", "javascript:mostraAndamento()")
            btnItensNovos.Attributes.Add("OnClick", "javascript:mostraAndamento()")

            If (Not IsPostBack) Then
                Me.txtDataApuracao.Text = Now.ToString("dd/MM/yyyy")
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Response.Redirect("Principal.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApurarTudo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApurarTudo.Click
        Try
            Me.ApuraTudo()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApurarFornecedores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApurarFornecedores.Click
        Try
            Me.ExecutaApuracao(0, 1, 0, 0, 0)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApurarCategoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApurarCategoria.Click
        Try
            Me.ExecutaApuracao(0, 0, 1, 0, 0)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnItem.Click
        Try
            Me.ExecutaApuracao(0, 0, 0, 1, 0)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnItensNovos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnItensNovos.Click
        Try
            Me.ExecutaApuracao(0, 0, 0, 0, 1)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub chkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodos.CheckedChanged
        Try
            If Me.chkTodos.Checked Then
                Me.btnApurarCategoria.Enabled = False
                Me.btnApurarFornecedores.Enabled = False
                Me.btnItem.Enabled = False
                Me.btnItensNovos.Enabled = False
            Else
                Me.btnApurarCategoria.Enabled = True
                Me.btnApurarFornecedores.Enabled = True
                Me.btnItem.Enabled = True
                Me.btnItensNovos.Enabled = True
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub txtNumContrato_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtNumContrato.ValueChange
        Try
            Dim dsContrato As wsAcoesComerciais.DatasetContrato
            dsContrato = Controller.ObterContratoXClausulaContrato(Nothing, Nothing, Nothing, Decimal.Zero, CType(Me.txtNumContrato.Text, Decimal))

            If dsContrato.T0124961.Rows.Count = 0 Then
                Util.AdicionaJsAlert(Me, "Não foram encontradas ´cláusulas para este contrato!")
                Exit Sub
            End If

            With ddlClausula
                .Items.Clear()
                For Each linha As wsAcoesComerciais.DatasetContrato.T0124961Row In dsContrato.T0124961
                    .Items.Add(New ListItem(Format(linha.NUMCSLCTTFRN, "0000") & " - " & linha.T0124953Row.DESCSLCTTFRN, linha.NUMCSLCTTFRN.ToString))
                Next
                .Items.Insert(0, New ListItem("TODAS", "0"))
            End With

            'Dim ds As New DataSet
            'Dim clausulas As New System.Text.StringBuilder
            'Dim linha As wsAcoesComerciais.DatasetContrato.T0124961Row

            'DatasetContrato.EnforceConstraints = False
            'Me.DatasetContrato.Merge(Controller.ObterContratoXClausulaContrato(Nothing, Nothing, Nothing, Decimal.Zero, CType(Me.txtNumContrato.Text, Decimal)), False, MissingSchemaAction.Ignore)

            'For Each linha In Me.DatasetContrato.T0124961.Rows
            '    If clausulas.Length > 0 Then clausulas.Append(",")
            '    clausulas.Append(linha.NUMCSLCTTFRN)
            'Next

            'If clausulas.Length > 0 Then
            '    ds.EnforceConstraints = False
            '    ds.Merge(Controller.ObterClausulasContrato(String.Empty, Decimal.Zero), False, MissingSchemaAction.Ignore)
            '    Me.DatasetClausulaContrato.EnforceConstraints = False
            '    Me.DatasetClausulaContrato.Merge(ds.Tables("T0124953").Select("NUMCSLCTTFRN in (" + clausulas.ToString + ")", "NUMCSLCTTFRN"), False, MissingSchemaAction.Ignore)
            '    Util.carregarClausulaContrato(Me.DatasetClausulaContrato, Me.ddlClausula, New ListItem("TODAS", "0"))
            'Else
            '    Util.AdicionaJsAlert(Me, "Não foram encontradas ´cláusulas para este contrato!")
            'End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnNova_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNova.Click
        Response.Redirect("Apuracao.aspx")
    End Sub

#End Region

#Region " Metodos "

    Private Sub ApuraTudo()
        Try
            If txtNumContrato.Text = "0" Then
                Util.AdicionaJsAlert(Me, "Número do contrato inválido.")
                Exit Sub
            End If
            If chkTodos.Checked Then
                Me.DatasetEntidade = Controller.ObterEntidades(0, 0, 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, 0, CDec(Me.txtNumContrato.Text), 0, 0, 0, 0)
                Dim quant As Integer
                quant = Me.DatasetEntidade.T0125046.Rows.Count
                If quant > 0 Then
                    Util.AdicionaJsAlert(Me, "Impossível apurar todos os períodos para este contrato. Já ocorreram apurações.")
                    Exit Sub
                End If
            End If
            Me.ExecutaApuracao(1, 0, 0, 0, 0)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub ExecutaApuracao(ByVal apuraTudo As Integer, ByVal fornecedor As Integer, ByVal categoria As Integer, ByVal itens As Integer, ByVal itensNovos As Integer)
        Try
            Dim ppin_CodEmp As Integer
            ppin_CodEmp = CType(ObterTIPIDTEMPASCACOCMC(CType(Me.txtNumContrato.Text.Trim, Decimal)), Integer)

            If ppin_CodEmp = -1 Then
                Util.AdicionaJsAlert(Me, "Contrato ou fornecedor não encontrado!")
                Exit Sub
            End If

            If Me.VerficaVazio Then
                Util.AdicionaJsAlert(Me, "Os campos Data Apuração,Contrato e Clausula são obrigatórios!")
            Else
                Me.txtHoraInicio.Text = Now.ToString("hh:mm:ss")
                Controller.ApurarAcordoGeralDeFornecimento(CType(Me.txtNumContrato.Text.Trim, Decimal) _
                                                            , CType(Me.ddlClausula.SelectedValue, Decimal) _
                                                            , CType(Me.txtDataApuracao.Text, Date) _
                                                            , CType(IIf(Me.chkTodos.Checked, 1, Decimal.Zero), Decimal) _
                                                            , apuraTudo _
                                                            , fornecedor _
                                                            , categoria _
                                                            , itens _
                                                            , itensNovos _
                                                            , ppin_CodEmp _
                                                            , 0 _
                                                            , String.Empty _
                                                            , String.Empty _
                                                            , String.Empty)

            End If
            Me.txtHoraFim.Text = Now.ToString("hh:mm:ss")
            Util.AdicionaJsAlert(Me, "Apuração executa com sucesso!")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function VerficaVazio() As Boolean
        Select Case String.Empty
            Case Me.txtDataApuracao.Text
                Return True
            Case Me.txtNumContrato.Text
                Return True
        End Select
        'Select Case 0
        '    Case Me.ddlClausula.SelectedIndex
        '        Return True
        '    Case CInt(Me.txtNumContrato.Text)
        '        Return True
        'End Select
        Return False
    End Function

    Private Function ObterTIPIDTEMPASCACOCMC(ByVal NUMCTTFRN As Decimal) As Decimal
        Dim ds As wsAcoesComerciais.DatasetContrato
        Dim result As Decimal = 0

        ds = Controller.ObterContrato(NUMCTTFRN)
        If ds.T0100426.Rows.Count = 0 Then
            Return -1 'Fornecedor ou contrato não encontrado
        End If

        If Not ds.T0100426(0).IsTIPIDTEMPASCACOCMCNull Then
            result = ds.T0100426(0).TIPIDTEMPASCACOCMC
        End If

        Return result
    End Function

#End Region

End Class