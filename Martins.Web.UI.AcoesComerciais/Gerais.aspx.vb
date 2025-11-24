Public Class Gerais
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetParametroGestaoAcaoComercial1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetParametroGestaoAcaoComercial
        CType(Me.DatasetParametroGestaoAcaoComercial1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetParametroGestaoAcaoComercial1
        '
        Me.DatasetParametroGestaoAcaoComercial1.DataSetName = "DatasetParametroGestaoAcaoComercial"
        Me.DatasetParametroGestaoAcaoComercial1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetParametroGestaoAcaoComercial1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents DatasetParametroGestaoAcaoComercial1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetParametroGestaoAcaoComercial
    Protected WithEvents cmbCODFILEMP As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCODULTUTZPMS As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents txtPERMAXARR As Infragistics.WebUI.WebDataInput.WebPercentEdit
    Protected WithEvents txtPERPIS As Infragistics.WebUI.WebDataInput.WebPercentEdit
    Protected WithEvents txtVLRMAXARR As Infragistics.WebUI.WebDataInput.WebCurrencyEdit
    Protected WithEvents txtDATREFPCSPEDCMP As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtFTRCNVVBACTTMRGCRB As Infragistics.WebUI.WebDataInput.WebPercentEdit
    Protected WithEvents txtPERJURSLDNEG As Infragistics.WebUI.WebDataInput.WebPercentEdit
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GerarJavaScript()

            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            End If

            If (Not IsPostBack) Then

                'Obtem PARAMETRO SISTEMA DE GESTAO DE ACAOCOMERCIAL
                If Not (Request.QueryString("CodFilEmp") Is Nothing) Then
                    ObterParametroGestaoAcaoComercial(1, Decimal.Parse(Request.QueryString("CodFilEmp")))
                    cmbCODFILEMP.Enabled = False
                Else
                    cmbCODFILEMP.Enabled = True
                    ViewState("flagInclusao") = True
                End If

                'Carrega as filiais
                Util.carregarCmbFilial(Controller.ObterFiliaisExpedicao(1), cmbCODFILEMP, Nothing)
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub
    Private Sub GerarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        btnSalvar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        'btnCancelar.Attributes.Add("OnClick", "javascript:return confirm('Deseja sair sem salvar?')")
    End Sub


    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            AtualizarParametroGestaoAcaoComercial()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = String.Empty

        Try
            Validar = True
            'Percentual max de arredondamento
            If txtPERMAXARR.ValueDecimal < 0 Or txtPERMAXARR.ValueDecimal > 100 Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "percentual max. arredondamento inválido"
            End If

            'Percentual de Juros para Saldo Neg
            If txtPERJURSLDNEG.ValueDecimal < 0 Or txtPERJURSLDNEG.ValueDecimal > 100 Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "percentual de Juros para Saldo Neg. inválido"
            End If

            'Percentual dedução PIS/COFINS
            If txtPERPIS.ValueDecimal < 0 Or txtPERPIS.ValueDecimal > 100 Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "percentual dedução PIS/COFINS inválido"
            End If

            'Fator Conv. Verba Ctt. Margem Crg
            If Not ((txtFTRCNVVBACTTMRGCRB.ValueDecimal) >= 0.0001 And (txtFTRCNVVBACTTMRGCRB.ValueDecimal) <= 1) Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "fator Conv. Verba Ctt. Margem Crg inválido"
            End If

            If mensagemErro.Trim() <> String.Empty Then
                Page.RegisterStartupScript("Alerta", "<script>alert('" & (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1) & "');</script>")
                Return False
            End If
            'If mensagemErro.Trim() <> String.Empty Then
            '    lblErro.Visible = True
            '    lblErro.Text = (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1)
            '    Return False
            'End If
            lblErro.Visible = False
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("GeraisListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
    End Sub

    Public Sub ObterParametroGestaoAcaoComercial(ByVal CODEMP As Decimal, _
                                                 ByVal CODFILEMP As Decimal)
        Try
            DatasetParametroGestaoAcaoComercial1 = Controller.ObterParametroGestaoAcaoComercial(CODEMP, _
                                                                                                CODFILEMP)

            With DatasetParametroGestaoAcaoComercial1.T0118074(0)
                'CODIGO DA FILIAL DA EMPRESA
                cmbCODFILEMP.SelectedValue = .CODFILEMP.ToString
                'ULTIMO CODIGO UTILIZADO PARA PROMESSA
                txtCODULTUTZPMS.Text = .CODULTUTZPMS.ToString
                'DATA REFERENCIA (AAAA-MM-DD)
                txtDATREFPCSPEDCMP.Text = .DATREFPCSPEDCMP.ToString
                'FATOR CONVERSAO VERBA DE CONTRATO PARA MARGEM DE CONTRI
                txtFTRCNVVBACTTMRGCRB.ValueDecimal = .FTRCNVVBACTTMRGCRB
                'PERCENTUAL DE JUROS COBRADO SOBRE SALDO NEGATIVO DO FOR
                txtPERJURSLDNEG.ValueDecimal = .PERJURSLDNEG
                'PERCENTUAL DE ARREDONDAMENTO
                txtPERMAXARR.ValueDecimal = .PERMAXARR
                'PERCENTUAL DE PIS/COFINS QUE INCIDE SOBRE RECEITAS DE F
                txtPERPIS.ValueDecimal = .PERPIS
                'VALOR MAXIMO ARREDONDAMENTO
                txtVLRMAXARR.ValueDecimal = .VLRMAXARR
            End With

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Public Sub AtualizarParametroGestaoAcaoComercial()
        Dim linha As wsAcoesComerciais.DatasetParametroGestaoAcaoComercial.T0118074Row
        Dim tipoEdicao As Short

        Try
            If Validar() = False Then
                Exit Sub
            End If
            If IsNumeric(cmbCODFILEMP.SelectedValue) Then
                DatasetParametroGestaoAcaoComercial1 = Controller.ObterParametroGestaoAcaoComercial(1, Decimal.Parse(cmbCODFILEMP.SelectedValue))
                If CType(ViewState("flagInclusao"), Boolean) Then
                    If DatasetParametroGestaoAcaoComercial1.T0118074.Rows.Count > 0 Then
                        Page.RegisterStartupScript("Alerta", "<script>alert('Inclusão não permitida, já existe esse registro no banco de dados. Os dados do banco foram carregados.');</script>")
                        Controller.ObterParametrosGestaoAcaoComercial(1, Decimal.Parse(cmbCODFILEMP.SelectedValue))
                        ViewState("flagInclusao") = False
                        Exit Try
                    End If
                End If
            End If

            If DatasetParametroGestaoAcaoComercial1.T0118074.Rows.Count > 0 Then
                'Update
                linha = DatasetParametroGestaoAcaoComercial1.T0118074(0)
                tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO
                linha.BeginEdit()
            Else
                'Insert
                DatasetParametroGestaoAcaoComercial1.Clear()
                linha = DatasetParametroGestaoAcaoComercial1.T0118074.NewT0118074Row
                tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO
            End If
            'Transfere os dados do formulário para o DataSet
            With linha
                'CODIGO EMPRESA
                .CODEMP = 1
                'CODIGO DA FILIAL DA EMPRESA
                .CODFILEMP = Decimal.Parse(Val(cmbCODFILEMP.SelectedValue).ToString)
                'ULTIMO CODIGO UTILIZADO PARA PROMESSA
                .CODULTUTZPMS = Decimal.Parse(Val(txtCODULTUTZPMS.Value).ToString)
                'DATA REFERENCIA (AAAA-MM-DD)
                If IsDate(txtDATREFPCSPEDCMP.Text) Then
                    .DATREFPCSPEDCMP = Date.Parse(txtDATREFPCSPEDCMP.Text)
                Else
                    .DATREFPCSPEDCMP = Date.Today
                End If
                'FATOR CONVERSAO VERBA DE CONTRATO PARA MARGEM DE CONTRI
                .FTRCNVVBACTTMRGCRB = txtFTRCNVVBACTTMRGCRB.ValueDecimal
                'PERCENTUAL DE JUROS COBRADO SOBRE SALDO NEGATIVO DO FOR
                .PERJURSLDNEG = txtPERJURSLDNEG.ValueDecimal
                'PERCENTUAL DE ARREDONDAMENTO
                .PERMAXARR = txtPERMAXARR.ValueDecimal
                'PERCENTUAL DE PIS/COFINS QUE INCIDE SOBRE RECEITAS DE F
                .PERPIS = txtPERPIS.ValueDecimal
                'VALOR MAXIMO ARREDONDAMENTO
                .VLRMAXARR = txtVLRMAXARR.ValueDecimal
            End With
            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                DatasetParametroGestaoAcaoComercial1.EnforceConstraints = False
                DatasetParametroGestaoAcaoComercial1.T0118074.AddT0118074Row(linha)
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                linha.EndEdit()
            End If

            Controller.AtualizarParametroGestaoAcaoComercial(DatasetParametroGestaoAcaoComercial1)

            Me.Response.Redirect("GeraisListar.aspx")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

End Class