Public Class Empenho
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTituloPagamentoContrato1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTituloPagamentoContrato
        Me.DatasetEmpenho1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetEmpenho
        CType(Me.DatasetTituloPagamentoContrato1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetEmpenho1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTituloPagamentoContrato1
        '
        Me.DatasetTituloPagamentoContrato1.DataSetName = "DatasetTituloPagamentoContrato"
        Me.DatasetTituloPagamentoContrato1.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DatasetEmpenho1
        '
        Me.DatasetEmpenho1.DataSetName = "DatasetEmpenho"
        Me.DatasetEmpenho1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTituloPagamentoContrato1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetEmpenho1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnApagar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatasetTituloPagamentoContrato1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTituloPagamentoContrato
    Protected WithEvents cmbTipAlcVbaFrn As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DatasetEmpenho1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetEmpenho
    Protected WithEvents txtTipDsnDscBnf As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents txtDesDsnDscBnf As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents chkFlgCalCst As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkFlgCntCrrFrn As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkFlgAcoMcd As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkFlgUtzLcrEmp As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkFlgCtbDsnDsc As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtIdtFluAcoCmc As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents chkFlgArdEmsCon As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkIndTrnDsnDscBnf As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkIndFluCncPedCmp As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkIndTipDsnDspFrn As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents chkINDTIPDSNRCTCSTMER As System.Web.UI.WebControls.CheckBox
    Protected WithEvents cmbDestVerbCarimbo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlObjetivoVerba As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Dropdownlist1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDataLimite As Infragistics.WebUI.WebDataInput.WebDateTimeEdit

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

                'Carrega o combo de título de pagamento do contrato
                Util.carregarTituloPagamentoContrato(Controller.ObterTitulosPagamentoContrato(String.Empty), cmbTipAlcVbaFrn, New ListItem("", ""))
                Me.PopulaComboDestino()
                Me.PopulaComboObjetivoVerba()
                'Obtem Empenho
                If Not (Request.QueryString("TIPDSNDSCBNF") Is Nothing) Then
                    ObterEmpenho(Decimal.Parse(Request.QueryString("TIPDSNDSCBNF")))

                    txtTipDsnDscBnf.ReadOnly = True
                Else
                    txtTipDsnDscBnf.ReadOnly = False
                End If
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

    Private Sub ObterEmpenho(ByVal TIPDSNDSCBNF As Decimal)
        Try
            DatasetEmpenho1 = Controller.ObterEmpenho(TIPDSNDSCBNF)

            With DatasetEmpenho1.T0109059(0)
                txtTipDsnDscBnf.Text = .TIPDSNDSCBNF.ToString
                txtDesDsnDscBnf.Text = .DESDSNDSCBNF.ToString.Trim
                txtIdtFluAcoCmc.Text = .IDTFLUACOCMC

                If .IsNull("INDTRNDSNDSCBNF") Then
                    chkIndTrnDsnDscBnf.Checked = False
                Else
                    If .INDTRNDSNDSCBNF = 1 Then
                        chkIndTrnDsnDscBnf.Checked = True
                    Else
                        chkIndTrnDsnDscBnf.Checked = False
                    End If
                End If

                If .IsNull("TIPALCVBAFRN") Then
                    cmbTipAlcVbaFrn.SelectedValue = ""
                ElseIf .TIPALCVBAFRN = 0 Then
                    cmbTipAlcVbaFrn.SelectedValue = ""
                Else
                    cmbTipAlcVbaFrn.SelectedValue = .TIPALCVBAFRN.ToString
                End If

                If .FLGCALCST.ToUpper = "S" Then
                    chkFlgCalCst.Checked = True
                Else
                    chkFlgCalCst.Checked = False
                End If

                If .FLGCNTCRRFRN.ToUpper = "S" Then
                    chkFlgCntCrrFrn.Checked = True
                Else
                    chkFlgCntCrrFrn.Checked = False
                End If

                If .FLGACOMCD.ToUpper = "S" Then
                    chkFlgAcoMcd.Checked = True
                Else
                    chkFlgAcoMcd.Checked = False
                End If

                If .FLGUTZLCREMP.ToUpper = "S" Then
                    chkFlgUtzLcrEmp.Checked = True
                Else
                    chkFlgUtzLcrEmp.Checked = False
                End If

                If .FLGCTBDSNDSC.ToUpper = "C" Then
                    cmbDestVerbCarimbo.Enabled = False
                ElseIf .FLGCTBDSNDSC.ToUpper = "S" Then
                    chkFlgCtbDsnDsc.Checked = True
                Else
                    chkFlgCtbDsnDsc.Checked = False
                End If

                If .INDFLUCNCPEDCMP = 1 Then
                    chkIndFluCncPedCmp.Checked = True
                Else
                    chkIndFluCncPedCmp.Checked = False
                End If

                If .IsNull("FLGARDEMSCON") Then
                    chkFlgArdEmsCon.Checked = False
                Else
                    If .FLGARDEMSCON = "S" Then
                        chkFlgArdEmsCon.Checked = True
                    Else
                        chkFlgArdEmsCon.Checked = False
                    End If
                End If

                If .IsNull("INDTIPDSNDSPFRN") Then
                    chkIndTipDsnDspFrn.Checked = False
                Else
                    If .INDTIPDSNDSPFRN = 1 Then
                        chkIndTipDsnDspFrn.Checked = True
                    Else
                        chkIndTipDsnDspFrn.Checked = False
                    End If
                End If

                If .IsNull("INDTIPDSNRCTCSTMER") Then
                    chkINDTIPDSNRCTCSTMER.Checked = False
                Else
                    If .INDTIPDSNRCTCSTMER = 1 Then
                        chkINDTIPDSNRCTCSTMER.Checked = True
                    Else
                        chkINDTIPDSNRCTCSTMER.Checked = False
                    End If
                End If

                cmbDestVerbCarimbo.SelectedValue = .INDDSNVBAMCO.ToString

                If (Not .IsTIPOBJDSNVBANull) AndAlso .TIPOBJDSNVBA > 0 Then
                    Me.ddlObjetivoVerba.SelectedValue = .TIPOBJDSNVBA.ToString()
                End If



                If Not .IsDATLIMVGRNull Then
                    Me.txtDataLimite.Date = .DATLIMVGR
                End If

                'Não econtrado controle da o campo
                '.CODCNTCTBGLM()
            End With

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            AtualizarEmpenho()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = String.Empty

        Try
            Validar = True
            ''Código Empenho
            'If Val(txtTipDsnDscBnf.Text) <= 0 Then
            '    If mensagemErro.Length > 0 Then mensagemErro &= ", "
            '    mensagemErro &= "cod empenho inválido"
            'End If
            'Descriçaõ empenho
            If txtDesDsnDscBnf.Text = String.Empty Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "descrição empenho inválida"
            End If

            If txtDataLimite.Text.Length > 0 Then
                Dim dataLimite As DateTime
                Try
                    dataLimite = Convert.ToDateTime(txtDataLimite.Text)
                Catch ex As Exception

                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "data limite inválida"
                End Try

                If dataLimite <= Now Then

                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "data limite deve ser maior que a data atual"

                End If

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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("EmpenhoListar.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub AtualizarEmpenho()
        Dim linha As wsAcoesComerciais.DatasetEmpenho.T0109059Row
        Dim tipoEdicao As Short

        Try
            If Validar() = False Then
                Exit Sub
            End If

            If IsNumeric(txtTipDsnDscBnf.Text) Then
                DatasetEmpenho1 = Controller.ObterEmpenho(Decimal.Parse(txtTipDsnDscBnf.Text))
            End If

            If DatasetEmpenho1.T0109059.Rows.Count > 0 Then
                'Update
                linha = DatasetEmpenho1.T0109059(0)
                tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO
                linha.BeginEdit()
            Else
                'Insert
                DatasetEmpenho1.Clear()
                linha = DatasetEmpenho1.T0109059.NewT0109059Row
                tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO
                'Controles que não são solicitados na tela
                linha.CODCCP = "0"
            End If

            'Transfere os dados do formulário para o DataSet
            With linha
                .TIPDSNDSCBNF = Decimal.Parse(Val(txtTipDsnDscBnf.Text).ToString)
                If cmbTipAlcVbaFrn.SelectedValue = "" Then
                    .SetTIPALCVBAFRNNull()
                Else
                    .TIPALCVBAFRN = Decimal.Parse(Val(cmbTipAlcVbaFrn.SelectedValue).ToString)
                End If
                .DESDSNDSCBNF = txtDesDsnDscBnf.Text.ToUpper.Trim
                .IDTFLUACOCMC = txtIdtFluAcoCmc.Text.ToUpper.Trim

                If chkIndTrnDsnDscBnf.Checked Then
                    .INDTRNDSNDSCBNF = 1
                Else
                    .INDTRNDSNDSCBNF = 0
                End If

                If chkFlgCalCst.Checked Then
                    .FLGCALCST = "S"
                Else
                    .FLGCALCST = "N"
                End If

                If chkFlgCntCrrFrn.Checked Then
                    .FLGCNTCRRFRN = "S"
                Else
                    .FLGCNTCRRFRN = "N"
                End If

                If chkFlgAcoMcd.Checked Then
                    .FLGACOMCD = "S"
                Else
                    .FLGACOMCD = "N"
                End If

                If chkFlgUtzLcrEmp.Checked Then
                    .FLGUTZLCREMP = "S"
                Else
                    .FLGUTZLCREMP = "N"
                End If

                If cmbDestVerbCarimbo.SelectedValue <> "0" Then
                    .FLGCTBDSNDSC = "C"
                ElseIf chkFlgCtbDsnDsc.Checked Then
                    .FLGCTBDSNDSC = "S"
                Else
                    .FLGCTBDSNDSC = "N"
                End If

                If chkIndFluCncPedCmp.Checked Then
                    .INDFLUCNCPEDCMP = 1
                Else
                    .INDFLUCNCPEDCMP = 0
                End If

                If chkFlgArdEmsCon.Checked Then
                    .FLGARDEMSCON = "S"
                Else
                    .FLGARDEMSCON = "N"
                End If

                If chkIndTipDsnDspFrn.Checked Then
                    .INDTIPDSNDSPFRN = 1
                Else
                    .INDTIPDSNDSPFRN = 0
                End If


                If chkINDTIPDSNRCTCSTMER.Checked Then
                    .INDTIPDSNRCTCSTMER = 1 'SIM
                Else
                    .INDTIPDSNRCTCSTMER = 0 'NÃO
                End If

                .INDDSNVBAMCO = CType(cmbDestVerbCarimbo.SelectedValue, Decimal)

                .TIPOBJDSNVBA = CType(ddlObjetivoVerba.SelectedValue, Decimal)

                If (Me.txtDataLimite.Text.Length = 10) Then
                    .DATLIMVGR = Me.txtDataLimite.Date
                End If


                'Não econtrado controle para o campo
                '.CODCNTCTBGLM()
            End With

            If tipoEdicao = Constants.TIPO_EDICAO_INCLUSAO Then
                DatasetEmpenho1.EnforceConstraints = False
                DatasetEmpenho1.T0109059.AddT0109059Row(linha)
            ElseIf tipoEdicao = Constants.TIPO_EDICAO_ALTERACAO Then
                linha.EndEdit()
            End If

            Controller.AtualizarEmpenho(DatasetEmpenho1)

            Try
                Me.Response.Redirect("EmpenhoListar.aspx")
            Catch ex As Exception
            End Try

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
    End Sub

    Private Sub PopulaComboDestino()
        With cmbDestVerbCarimbo
            .Items.Clear()
            .Items.Insert(0, New ListItem("", "0"))
            .Items.Insert(1, New ListItem("1-PREÇO", "1"))
            .Items.Insert(2, New ListItem("2-MARGEM", "2"))
            .SelectedValue = "0"
        End With
    End Sub
    Private Sub PopulaComboObjetivoVerba()

        Dim ds As DataSet = Controller.ObterTiposObjetivoVerbaAtivo()

        ddlObjetivoVerba.Items.Clear()

        For Each row As DataRow In ds.Tables("CADOBJDSNVBA").Rows
            ddlObjetivoVerba.Items.Insert(0, New ListItem(row("TIPOBJDSNVBA").ToString().PadLeft(2, "0"c) & " - " & row("DESOBJDSNVBA").ToString().Trim().ToUpper(), row("TIPOBJDSNVBA").ToString()))
        Next
    End Sub



    Private Sub btnSalvar_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles btnSalvar.Command

    End Sub
End Class