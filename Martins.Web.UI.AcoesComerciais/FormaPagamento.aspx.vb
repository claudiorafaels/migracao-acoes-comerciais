Public Class FormaPagamento
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetFormaPagamento1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetFormaPagamento
        CType(Me.DatasetFormaPagamento1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetFormaPagamento1
        '
        Me.DatasetFormaPagamento1.DataSetName = "DatasetFormaPagamento"
        Me.DatasetFormaPagamento1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetFormaPagamento1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents TipFrmDscBnf As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents DesFrmDscBnf As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents FlgCfaNotFsc As System.Web.UI.WebControls.CheckBox
    Protected WithEvents FlgPtcVlrTit As System.Web.UI.WebControls.CheckBox
    Protected WithEvents QdeMnmDiaBlqFrn As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents PerDscImd As Infragistics.WebUI.WebDataInput.WebPercentEdit
    Protected WithEvents PerDscMns As Infragistics.WebUI.WebDataInput.WebPercentEdit
    Protected WithEvents DatasetFormaPagamento1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetFormaPagamento
    Protected WithEvents rdlINDTIPDSNRCTCSTMER As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblINDDSCICMICT As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblINDDSCGRCACOCMC As System.Web.UI.WebControls.RadioButtonList

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "Eventos"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GerarJavaScript()
            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            End If

            If (Not IsPostBack) Then
                'Obtem a Forma de pagamento
                If Not (Request.QueryString("TIPFRMDSCBNF") Is Nothing) Then
                    ObterFormaPagamento(Decimal.Parse(Request.QueryString("TIPFRMDSCBNF")))

                    TipFrmDscBnf.ReadOnly = True
                Else
                    TipFrmDscBnf.ReadOnly = False
                End If
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            AtualizarFormaPagamento()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("FormaPagamentoListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
    End Sub

#End Region

#Region "Método de Carga"

    Private Sub GerarJavaScript()
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        'btnCancelar.Attributes.Add("OnClick", "javascript:return confirm('Deseja sair sem salvar?')")
    End Sub

#End Region

#Region "Métodos de Controle"

#End Region

#Region "Métodos de Regras"

    Private Sub ObterFormaPagamento(ByVal pTIPFRMDSCBNF As Decimal)
        Try
            DatasetFormaPagamento1 = Controller.ObterFormaPagamento(pTIPFRMDSCBNF)

            With DatasetFormaPagamento1.T0113552(0)
                TipFrmDscBnf.Text = pTIPFRMDSCBNF.ToString
                DesFrmDscBnf.Text = .DESFRMDSCBNF()
                If .FLGCFANOTFSC = "S" Then
                    FlgCfaNotFsc.Checked = True
                Else
                    FlgCfaNotFsc.Checked = False
                End If
                If .FLGPTCVLRTIT = "S" Then
                    FlgPtcVlrTit.Checked = True
                Else
                    FlgPtcVlrTit.Checked = False
                End If
                If Not .IsPERDSCIMDNull Then
                    PerDscImd.Text = .PERDSCIMD.ToString
                Else
                    PerDscImd.Text = "0"
                End If
                If Not .IsPERDSCMNSNull Then
                    PerDscMns.Text = .PERDSCMNS.ToString
                Else
                    PerDscMns.Text = "0"
                End If
                If Not .IsQDEMNMDIABLQFRNNull Then
                    QdeMnmDiaBlqFrn.Text = .QDEMNMDIABLQFRN.ToString
                Else
                    QdeMnmDiaBlqFrn.Text = "0"
                End If
                If Not .IsNull("INDTIPDSNRCTCSTMER") Then
                    rdlINDTIPDSNRCTCSTMER.SelectedValue = .INDTIPDSNRCTCSTMER.ToString
                Else
                    rdlINDTIPDSNRCTCSTMER.SelectedValue = "0"
                End If
                If Not .IsNull("INDDSCICMICT") Then
                    rblINDDSCICMICT.SelectedValue = .INDDSCICMICT.ToString
                Else
                    rblINDDSCICMICT.SelectedValue = "0"
                End If
                If Not .IsNull("INDDSCGRCACOCMC") Then
                    rblINDDSCGRCACOCMC.SelectedValue = .INDDSCGRCACOCMC.ToString
                Else
                    rblINDDSCGRCACOCMC.SelectedValue = "0"
                End If
            End With

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = String.Empty

        Try
            Validar = True

            ''Código Forma de Pagamento
            'If Val(TipFrmDscBnf.Text) <= 0 Then
            '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '    mensagemErro &= "código inválido"
            'End If
            'Descrição Forma de Pagamento
            If DesFrmDscBnf.Text = String.Empty Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "descrição inválida"
            End If
            'Desconto percentual imediato 
            If Val(PerDscImd.Text) < 0 Or Val(PerDscImd.Text) > 100 Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "desconto percentual imediato inválido"
            End If
            'Desconto percentual mensal
            If Val(PerDscMns.Text) < 0 Or Val(PerDscMns.Text) > 100 Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "desconto percentual mensal inválido"
            End If

            If mensagemErro.Trim() <> String.Empty Then
                Page.RegisterStartupScript("Alerta", "<script>alert('" & (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1) & "');</script>")
                Return False
            End If

            'If mensagemErro <> String.Empty Then
            '    lblErro.Visible = True
            '    lblErro.Text = (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1)
            '    Return False
            'End If
            lblErro.Visible = False
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Sub AtualizarFormaPagamento()
        Dim linha As wsAcoesComerciais.DatasetFormaPagamento.T0113552Row
        Dim tipoEdicao As Short

        Try
            If Validar() = False Then
                Exit Sub
            End If

            If IsNumeric(TipFrmDscBnf.Text) Then
                DatasetFormaPagamento1 = Controller.ObterFormaPagamento(Decimal.Parse(TipFrmDscBnf.Text))
            End If

            If DatasetFormaPagamento1.T0113552.Rows.Count > 0 Then
                'Update
                linha = DatasetFormaPagamento1.T0113552(0)
                tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO
                linha.BeginEdit()
            Else
                'Insert
                DatasetFormaPagamento1.Clear()
                linha = DatasetFormaPagamento1.T0113552.NewT0113552Row
                tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO
            End If

            'Transfere os dados do formulário para o DataSet
            With linha
                .DESFRMDSCBNF = DesFrmDscBnf.Text
                If FlgCfaNotFsc.Checked Then
                    .FLGCFANOTFSC = "S"
                Else
                    .FLGCFANOTFSC = "N"
                End If
                If FlgPtcVlrTit.Checked Then
                    .FLGPTCVLRTIT = "S"
                Else
                    .FLGPTCVLRTIT = "N"
                End If
                .PERDSCIMD = PerDscImd.ValueDecimal
                .PERDSCMNS = PerDscMns.ValueDecimal
                .INDTIPDSNRCTCSTMER = CType(rdlINDTIPDSNRCTCSTMER.SelectedValue, Decimal)
                .QDEMNMDIABLQFRN = QdeMnmDiaBlqFrn.ValueDecimal
                .NUMORDAPLDSC = 0
                .INDDSCICMICT = CType(rblINDDSCICMICT.SelectedValue, Decimal)
                .INDDSCGRCACOCMC = CType(rblINDDSCGRCACOCMC.SelectedValue, Decimal)
            End With

            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                DatasetFormaPagamento1.EnforceConstraints = False
                DatasetFormaPagamento1.T0113552.AddT0113552Row(linha)
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                linha.EndEdit()
            End If

            Controller.AtualizarFormaPagamento(DatasetFormaPagamento1)

            Me.Response.Redirect("FormaPagamentoListar.aspx")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

End Class