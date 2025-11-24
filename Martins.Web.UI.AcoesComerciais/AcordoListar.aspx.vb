Public Class AcordoListar
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "
    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblFrame As System.Web.UI.WebControls.Label
    Protected WithEvents btnPesquisar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnInserir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents txtDataInicial As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtDataFinal As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents cmbCriterio As System.Web.UI.WebControls.DropDownList
    Protected WithEvents LblA As System.Web.UI.WebControls.Label
    Protected WithEvents btnBuscarFornecedor As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtNomeFornecedor As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents cmbNomeFornecedor As System.Web.UI.WebControls.DropDownList
    Protected WithEvents LblFornecedor As System.Web.UI.WebControls.Label
    Protected WithEvents Espera As System.Web.UI.WebControls.Image
    Protected WithEvents txtCodigo As Infragistics.WebUI.WebDataInput.WebNumericEdit
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

#Region "Busca Fornecedor"

    Private Sub btnBuscarFornecedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarFornecedor.Click
        Dim datasetFornecedor As wsAcoesComerciais.dataSetDivisaoFornecedor
        Dim flagMostrarCombo As Boolean

        If txtNomeFornecedor.Visible Then
            If txtNomeFornecedor.Text.Trim.Length < 3 Then
                Page.RegisterStartupScript("Alerta", "<script>alert('É obrigatório digitar no mínimo 3 caracteres do nome antes de pesquisar.');</script>")
                Exit Sub
            End If

            datasetFornecedor = Controller.ObterDivisoesFornecedor(1, txtNomeFornecedor.Text)
            If datasetFornecedor.T0100426.Rows.Count > 0 Then
                Util.carregarCmbDivisaoFornecedor(datasetFornecedor, cmbNomeFornecedor, Nothing)
                txtNomeFornecedor.Text = cmbNomeFornecedor.SelectedValue
                flagMostrarCombo = True
            Else
                Util.AdicionaJsAlert(Me.Page, "Registro não encontrado")
            End If

            With cmbNomeFornecedor
                .Visible = flagMostrarCombo
                .Enabled = flagMostrarCombo
                If flagMostrarCombo Then
                    .Width = System.Web.UI.WebControls.Unit.Parse("170px")
                Else
                    .Width = System.Web.UI.WebControls.Unit.Parse("0px")
                End If
            End With
            With txtNomeFornecedor
                .Visible = Not flagMostrarCombo
                .Enabled = Not flagMostrarCombo
                If Not flagMostrarCombo Then
                    .Width = System.Web.UI.WebControls.Unit.Parse("170px")
                Else
                    .Width = System.Web.UI.WebControls.Unit.Parse("0px")
                End If
            End With
        ElseIf cmbNomeFornecedor.Visible Then
            With cmbNomeFornecedor
                .Visible = False
                .Enabled = False
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
            End With
            With txtNomeFornecedor
                .Visible = True
                .Enabled = True
                .Width = System.Web.UI.WebControls.Unit.Parse("170px")
            End With
        End If
    End Sub

    Private Sub cmbNomeFornecedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNomeFornecedor.SelectedIndexChanged
        txtCodigo.Text = cmbNomeFornecedor.SelectedValue
    End Sub

    Private Sub txtCodigo_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtCodigo.ValueChange
        Dim datasetFornecedor As wsAcoesComerciais.dataSetDivisaoFornecedor
        Dim flagMostrarCombo As Boolean

        If Not (IsNumeric(txtCodigo.Text)) Then Exit Sub
        If Not (cmbCriterio.SelectedValue = "3") Then Exit Sub

        datasetFornecedor = Controller.ObterDivisaoFornecedor(1, CLng(txtCodigo.Text))
        If datasetFornecedor.T0100426.Rows.Count > 0 Then
            cmbNomeFornecedor.Items.Clear()
            For Contador As Integer = 0 To datasetFornecedor.T0100426.Count - 1
                cmbNomeFornecedor.Items.Add(datasetFornecedor.T0100426(Contador).NOMFRN.Trim)
                cmbNomeFornecedor.Items(Contador).Value = datasetFornecedor.T0100426(Contador).CODFRN.ToString
            Next
            flagMostrarCombo = True
        Else
            cmbNomeFornecedor.Items.Clear()
            txtNomeFornecedor.Text = String.Empty
            Util.AdicionaJsAlert(Me.Page, "Código de fornecedor inválido")
        End If

        With cmbNomeFornecedor
            .Visible = flagMostrarCombo
            .Enabled = flagMostrarCombo
            If flagMostrarCombo Then
                .Width = System.Web.UI.WebControls.Unit.Parse("170px")
            Else
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
            End If
        End With
        With txtNomeFornecedor
            .Visible = Not flagMostrarCombo
            .Enabled = Not flagMostrarCombo
            If Not flagMostrarCombo Then
                .Width = System.Web.UI.WebControls.Unit.Parse("170px")
            Else
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
            End If
        End With
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
            Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
        End If
        If (Not IsPostBack) Then
            RestaurarCriteriosDePesquisa(sender, e)
        End If
        btnPesquisar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
    End Sub

    Private Sub btnInserir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInserir.Click
        Controller.NavegarInserirAcordo()
    End Sub

    Private Sub btnPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Try
            'Verifica o critério
            If cmbCriterio.SelectedValue = "1" Then     '1 Período
                If Not IsDate(txtDataInicial.Text) Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Data inicial não informada ou inválida.');</script>")
                    Exit Try
                End If
                If Not IsDate(txtDataFinal.Text) Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Data final não informada ou inválida.');</script>")
                    Exit Try
                End If
                If Date.Parse(txtDataInicial.Text) > Date.Parse(txtDataFinal.Text) Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Data inicial maior que data final.');</script>")
                    Exit Try
                End If
                lblFrame.Text = "<iframe src='" & "AcordoListarGrid.aspx?criterio=" & cmbCriterio.SelectedItem.Value & "&DATNGCPMSInicial=" & txtDataInicial.Text & "&DATNGCPMSFinal=" & txtDataFinal.Text & "' height=100% width=100% frameborder=0 ALLOWTRANSPARENCY scrolling=yes></iframe>"
            ElseIf cmbCriterio.SelectedValue = "2" Then '2 Data Previsão
                If Not IsDate(txtDataInicial.Text) Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Data não informada ou inválida.');</script>")
                    Exit Try
                End If
                lblFrame.Text = "<iframe src='" & "AcordoListarGrid.aspx?criterio=" & cmbCriterio.SelectedItem.Value & "&DATNGCPMS=" & txtDataInicial.Text & "' height=100% width=100% frameborder=0 ALLOWTRANSPARENCY scrolling=yes></iframe>"
            ElseIf cmbCriterio.SelectedValue = "3" Then '3 Período/Fornecedor
                If Not IsDate(txtDataInicial.Text) Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Data inicial não informada ou inválida.');</script>")
                    Exit Try
                End If
                If Not IsDate(txtDataFinal.Text) Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Data final não informada ou inválida.');</script>")
                    Exit Try
                End If
                If Date.Parse(txtDataInicial.Text) > Date.Parse(txtDataFinal.Text) Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Data inicial maior que data final.');</script>")
                    Exit Try
                End If
                If Not IsNumeric(txtCodigo.Text) Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Fornecedor não informado.');</script>")
                    Exit Try
                End If
                lblFrame.Text = "<iframe src='" & "AcordoListarGrid.aspx?criterio=" & cmbCriterio.SelectedItem.Value & "&DATNGCPMSInicial=" & txtDataInicial.Text & "&DATNGCPMSFinal=" & txtDataFinal.Text & "&CODFRN=" & txtCodigo.Text & "' height=100% width=100% frameborder=0 ALLOWTRANSPARENCY scrolling=yes></iframe>"
            ElseIf cmbCriterio.SelectedValue = "4" Then '3 Número
                If Not IsNumeric(txtCodigo.Text) Then
                    Page.RegisterStartupScript("Alerta", "<script>alert('Informe o número do Acordo.');</script>")
                    Exit Try
                End If
                lblFrame.Text = "<iframe src='" & "AcordoListarGrid.aspx?criterio=" & cmbCriterio.SelectedItem.Value & "&CODPMS=" & txtCodigo.Text & "' height=100% width=100% frameborder=0 ALLOWTRANSPARENCY scrolling=yes></iframe>"
            End If

            GravarCriteriosDePesquisa(lblFrame.Text)

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub cmbCriterio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCriterio.SelectedIndexChanged

        txtCodigo.AutoPostBack = False

        txtDataInicial.Visible = False
        LblA.Visible = False
        txtDataFinal.Visible = False
        LblFornecedor.Visible = False
        txtCodigo.Visible = False
        cmbNomeFornecedor.Visible = False
        txtNomeFornecedor.Visible = False
        btnBuscarFornecedor.Visible = False

        'Limpa
        txtDataInicial.Text = String.Empty
        txtDataFinal.Text = String.Empty
        txtCodigo.Text = String.Empty

        If cmbCriterio.SelectedValue = "1" Then     '1 Período
            txtDataInicial.Visible = True
            LblA.Visible = True
            txtDataFinal.Visible = True
        ElseIf cmbCriterio.SelectedValue = "2" Then '2 Data Previsão
            txtDataInicial.Visible = True
        ElseIf cmbCriterio.SelectedValue = "3" Then '3 Período/Fornecedor
            txtDataInicial.Visible = True
            LblA.Visible = True
            txtDataFinal.Visible = True
            LblFornecedor.Visible = True
            txtCodigo.Visible = True
            txtNomeFornecedor.Visible = True
            txtNomeFornecedor.Width = System.Web.UI.WebControls.Unit.Parse("170px")
            btnBuscarFornecedor.Visible = True
            txtCodigo.AutoPostBack = True
        ElseIf cmbCriterio.SelectedValue = "4" Then '4 Código
            txtCodigo.Visible = True
        End If

    End Sub

    Private Sub GravarCriteriosDePesquisa(ByVal urlFrame As String)
        Dim criterios As New Collection
        With criterios
            .Add(urlFrame, "urlFrame")
            .Add(cmbCriterio.SelectedValue, "cmbCriterio")
            .Add(txtDataInicial.Text, "txtDataInicial")
            .Add(txtDataFinal.Text, "txtDataFinal")
            .Add(txtCodigo.ValueDecimal.ToString, "txtCodigo")
            .Add(txtNomeFornecedor.Text, "txtNomeFornecedor")
            .Add(cmbNomeFornecedor.SelectedValue, "cmbNomeFornecedor")
        End With
        Session("AcordoListar") = criterios
    End Sub

    Private Sub RestaurarCriteriosDePesquisa(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim criterios As Collection

        If Not Session("AcordoListar") Is Nothing Then
            Try
                criterios = CType(Session("AcordoListar"), Collection)

                lblFrame.Text = CType(criterios.Item("urlFrame"), String)
                cmbCriterio.SelectedValue = CType(criterios.Item("cmbCriterio"), String)
                cmbCriterio_SelectedIndexChanged(sender, e)

                txtDataInicial.Text = CType(criterios.Item("txtDataInicial"), String)
                txtDataFinal.Text = CType(criterios.Item("txtDataFinal"), String)
                txtNomeFornecedor.Text = CType(criterios.Item("txtNomeFornecedor"), String)
                txtCodigo.Text = CType(criterios.Item("txtCodigo"), String)
                cmbNomeFornecedor.SelectedValue = CType(criterios.Item("cmbNomeFornecedor"), String)

                If txtCodigo.ValueDecimal > 0 Then
                    txtCodigo_ValueChange(sender, Nothing)
                End If

                If cmbNomeFornecedor.Items.Count > 0 Then
                    cmbNomeFornecedor.Visible = True
                    txtNomeFornecedor.Visible = False
                End If

            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnTeste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Throw New Martins.ExceptionManagement.MartinsApplicationException("Message", "NumerDiaPriApuArdFrn")
            'Throw New Martins.ExceptionManagement.MartinsSystemException("Message", "NumerDiaPriApuArdFrn")
            Dim ds As wsAcoesComerciais.DatasetAcordo
            ds = Controller.ObterAcordo(1, 1, 1, Nothing)
        Catch ex As Martins.ExceptionManagement.MartinsApplicationException
            Util.AdicionaJsAlert(Me.Page, ex.UserMessage)
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
        'Dim dsAcordo As wsAcoesComerciais.DatasetAcordo
        'Dim dsContrato As wsAcoesComerciais.DatasetContrato

        'dsAcordo = Controller.ObterAcordos(0, 0, 0, 0, 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, txtDataInicial.Date, txtDataFinal.Date, String.Empty)
        'dsContrato = Controller.ObterContratos(0, 0, "", 5010, 0)

        'Session("DS01") = dsAcordo
        'Session("DS02") = dsAcordo
        'Session("DS03") = dsAcordo
        'Session("DS04") = dsAcordo
        'Session("DS05") = dsAcordo
        'Session("DS06") = dsAcordo
        'Session("DS07") = dsAcordo
        'Session("DS08") = dsAcordo
        'Session("DS09") = dsAcordo
        'Session("DS10") = dsAcordo
        'Session("DS11") = dsAcordo
        'Session("DS12") = dsAcordo
        'Session("DS13") = dsAcordo
        'Session("DS14") = dsAcordo
        'Session("DS15") = dsAcordo
        'Session("DS16") = dsAcordo
        'Session("DS17") = dsAcordo
        'Session("DS18") = dsAcordo
        'Session("DS19") = dsAcordo
        'Session("DS20") = dsAcordo
        'Session("DS01") = Nothing
        'Session("DS02") = Nothing
        'Session("DS03") = Nothing
        'Session("DS04") = Nothing
        'Session("DS05") = Nothing
        'Session("DS06") = Nothing
        'Session("DS07") = Nothing
        'Session("DS08") = Nothing
        'Session("DS09") = Nothing
        'Session("DS10") = Nothing
        'Session("DS11") = Nothing
        'Session("DS12") = Nothing
        'Session("DS13") = Nothing
        'Session("DS14") = Nothing
        'Session("DS15") = Nothing
        'Session("DS16") = Nothing
        'Session("DS17") = Nothing
        'Session("DS18") = Nothing
        'Session("DS19") = Nothing
        'Session("DS20") = Nothing

        'Session("DS01") = dsContrato
        'Session("DS02") = dsContrato
        'Session("DS03") = dsContrato
        'Session("DS04") = dsContrato
        'Session("DS05") = dsContrato
        'Session("DS06") = dsContrato
        'Session("DS07") = dsContrato
        'Session("DS08") = dsContrato
        'Session("DS09") = dsContrato
        'Session("DS10") = dsContrato
        'Session("DS11") = dsContrato
        'Session("DS12") = dsContrato
        'Session("DS13") = dsContrato
        'Session("DS14") = dsContrato
        'Session("DS15") = dsContrato
        'Session("DS16") = dsContrato
        'Session("DS17") = dsContrato
        'Session("DS18") = dsContrato
        'Session("DS19") = dsContrato
        'Session("DS20") = dsContrato
    End Sub

    Private Sub Linkbutton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dsAcordo As wsAcoesComerciais.DatasetAcordo
        Dim dsContrato As wsAcoesComerciais.DatasetContrato

        dsAcordo = Controller.ObterAcordos(0, 0, 0, 0, 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, txtDataInicial.Date, txtDataFinal.Date, String.Empty, 0)
        dsContrato = Controller.ObterContratos(0, 0, "", 5010, 0)

        Session("DS01") = dsAcordo
        Session("DS02") = dsAcordo
        Session("DS03") = dsAcordo
        Session("DS04") = dsAcordo
        Session("DS05") = dsAcordo
        Session("DS06") = dsAcordo
        Session("DS07") = dsAcordo
        Session("DS08") = dsAcordo
        Session("DS09") = dsAcordo
        Session("DS10") = dsAcordo
        Session("DS11") = dsAcordo
        Session("DS12") = dsAcordo
        Session("DS13") = dsAcordo
        Session("DS14") = dsAcordo
        Session("DS15") = dsAcordo
        Session("DS16") = dsAcordo
        Session("DS17") = dsAcordo
        Session("DS18") = dsAcordo
        Session("DS19") = dsAcordo
        Session("DS20") = dsAcordo

        Session.Clear()
        Session("DS01") = dsContrato
        Session("DS02") = dsContrato
        Session("DS03") = dsContrato
        Session("DS04") = dsContrato
        Session("DS05") = dsContrato
        Session("DS06") = dsContrato
        Session("DS07") = dsContrato
        Session("DS08") = dsContrato
        Session("DS09") = dsContrato
        Session("DS10") = dsContrato
        Session("DS11") = dsContrato
        Session("DS12") = dsContrato
        Session("DS13") = dsContrato
        Session("DS14") = dsContrato
        Session("DS15") = dsContrato
        Session("DS16") = dsContrato
        Session("DS17") = dsContrato
        Session("DS18") = dsContrato
        Session("DS19") = dsContrato
        Session("DS20") = dsContrato
    End Sub

    Private Sub Linkbutton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dsAcordo As wsAcoesComerciais.DatasetAcordo

        dsAcordo = Controller.ObterAcordos(0, 0, 0, 0, 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, txtDataInicial.Date, txtDataFinal.Date, String.Empty, 0)

        Session("DS01") = Nothing
        Session("DS02") = Nothing
        Session("DS03") = Nothing
        Session("DS04") = Nothing
        Session("DS05") = Nothing
        Session("DS06") = Nothing
        Session("DS07") = Nothing
        Session("DS08") = Nothing
        Session("DS09") = Nothing
        Session("DS10") = Nothing
        Session("DS11") = Nothing
        Session("DS12") = Nothing
        Session("DS13") = Nothing
        Session("DS14") = Nothing
        Session("DS15") = Nothing
        Session("DS16") = Nothing
        Session("DS17") = Nothing
        Session("DS18") = Nothing
        Session("DS19") = Nothing
        Session("DS20") = Nothing

        Session("DS01") = dsAcordo
        Session("DS02") = dsAcordo
        Session("DS03") = dsAcordo
        Session("DS04") = dsAcordo
        Session("DS05") = dsAcordo
        Session("DS06") = dsAcordo
        Session("DS07") = dsAcordo
        Session("DS08") = dsAcordo
        Session("DS09") = dsAcordo
        Session("DS10") = dsAcordo
        Session("DS11") = dsAcordo
        Session("DS12") = dsAcordo
        Session("DS13") = dsAcordo
        Session("DS14") = dsAcordo
        Session("DS15") = dsAcordo
        Session("DS16") = dsAcordo
        Session("DS17") = dsAcordo
        Session("DS18") = dsAcordo
        Session("DS19") = dsAcordo
        Session("DS20") = dsAcordo
    End Sub

    Private Sub Linkbutton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dsContrato As wsAcoesComerciais.DatasetContrato

        dsContrato = Controller.ObterContratos(0, 0, "", 5010, 0)

        Session("DS01") = Nothing
        Session("DS02") = Nothing
        Session("DS03") = Nothing
        Session("DS04") = Nothing
        Session("DS05") = Nothing
        Session("DS06") = Nothing
        Session("DS07") = Nothing
        Session("DS08") = Nothing
        Session("DS09") = Nothing
        Session("DS10") = Nothing
        Session("DS11") = Nothing
        Session("DS12") = Nothing
        Session("DS13") = Nothing
        Session("DS14") = Nothing
        Session("DS15") = Nothing
        Session("DS16") = Nothing
        Session("DS17") = Nothing
        Session("DS18") = Nothing
        Session("DS19") = Nothing
        Session("DS20") = Nothing

        Session("DS01") = dsContrato
        Session("DS02") = dsContrato
        Session("DS03") = dsContrato
        Session("DS04") = dsContrato
        Session("DS05") = dsContrato
        Session("DS06") = dsContrato
        Session("DS07") = dsContrato
        Session("DS08") = dsContrato
        Session("DS09") = dsContrato
        Session("DS10") = dsContrato
        Session("DS11") = dsContrato
        Session("DS12") = dsContrato
        Session("DS13") = dsContrato
        Session("DS14") = dsContrato
        Session("DS15") = dsContrato
        Session("DS16") = dsContrato
        Session("DS17") = dsContrato
        Session("DS18") = dsContrato
        Session("DS19") = dsContrato
        Session("DS20") = dsContrato
    End Sub
End Class