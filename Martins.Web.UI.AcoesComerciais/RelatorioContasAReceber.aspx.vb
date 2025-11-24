Imports CrystalDecisions
Imports CrystalDecisions.shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine

Public Class RelatorioContasAReceber
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cmbFormaPagamento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnImprimir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents rdlOpcoes As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents TD2 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD4 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD5 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD6 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD7 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD8 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD9 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD10 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD12 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD13 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD14 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD15 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD16 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD17 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD3 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD11 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents CmbCelula As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ucFornecedor As wucFornecedor
    Protected WithEvents ucEmpenho As wucEmpenho
    Protected WithEvents txtDataInicial As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtSemana As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtPeriodoIntervalo As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents TD19 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD18 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents txtUsuario As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents chkTodasCelula As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkQuebraCelula As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents cmbFiltro As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TD1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD20 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents lblFiltro As System.Web.UI.WebControls.Label
    Protected WithEvents btnVisualizar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents txtDataFinal As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trEspera As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Td21 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td22 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents cmbTIPIDTEMPASCACOCMC As System.Web.UI.WebControls.DropDownList
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

#End Region

#Region "Eventos"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            End If

            btnImprimir.Attributes.Add("OnClick", "javascript:mostraAndamento()")
            btnVisualizar.Attributes.Add("OnClick", "javascript:mostraAndamento()")

            If (Not IsPostBack) Then
                ucFornecedor.widthNome = System.Web.UI.WebControls.Unit.Parse("280px")
                ucEmpenho.IncluirItemTodos = True
                carregarCmbFormaPagamento()
                carregarCmbCelula()
                carregarCmbFiltro(1)

                Try
                    txtUsuario.Text = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0).NOMACSUSRSIS.Trim
                Catch ex As Exception
                    Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
                    btnImprimir.Enabled = False
                    Exit Sub
                End Try

                txtSemana.Date = Date.Today
                txtDataInicial.Date = Date.Today.AddDays(-1)
                txtDataFinal.Date = Date.Today
                txtPeriodoIntervalo.Text = "50"
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Response.Redirect("Principal.aspx")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            If Validar() = False Then
                Exit Sub
            End If

            'Limpa as Formulas do relatorio que são guardadas na seção
            WSCAcoesComerciais.hashtableFormulasCrystal = Nothing
            WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = True

            If rdlOpcoes.SelectedValue = "1" Then
                ImprimirContasAReceberAnalitico()
            ElseIf rdlOpcoes.SelectedValue = "2" Then
                ImprimirContasAReceberSintetico()
            ElseIf rdlOpcoes.SelectedValue = "3" Then
                ImprimirABCSaldoemAberto()
            ElseIf rdlOpcoes.SelectedValue = "4" Then
                ImprimirValoresIncorretos()
            ElseIf rdlOpcoes.SelectedValue = "5" Then
                ImprimirGingListAnalítico()
            ElseIf rdlOpcoes.SelectedValue = "6" Then
                ImprimirGingListSintetico()
            End If
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

            If rdlOpcoes.SelectedValue = "1" Then
                ImprimirContasAReceberAnalitico()
            ElseIf rdlOpcoes.SelectedValue = "2" Then
                ImprimirContasAReceberSintetico()
            ElseIf rdlOpcoes.SelectedValue = "3" Then
                ImprimirABCSaldoemAberto()
            ElseIf rdlOpcoes.SelectedValue = "4" Then
                ImprimirValoresIncorretos()
            ElseIf rdlOpcoes.SelectedValue = "5" Then
                ImprimirGingListAnalítico()
            ElseIf rdlOpcoes.SelectedValue = "6" Then
                ImprimirGingListSintetico()
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub

    Private Sub rdlOpcoes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdlOpcoes.SelectedIndexChanged
        carregarCmbFiltro(CInt(rdlOpcoes.SelectedValue))
    End Sub

    Private Sub chkTodasCelula_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodasCelula.CheckedChanged
        If CmbCelula.Items.Count > 0 Then
            If chkTodasCelula.Checked Then
                CmbCelula.SelectedValue = "0"
            End If
        Else
            CmbCelula.SelectedValue = "0"
        End If
    End Sub

    Private Sub CmbCelulaula_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCelula.SelectedIndexChanged
        If CmbCelula.SelectedValue = "0" Then
            chkTodasCelula.Checked = True
        Else
            chkTodasCelula.Checked = False
        End If
    End Sub

#End Region

#Region "Métodos"

    Private Sub transferirDadosDoDatasetParaFormulario()
        Try
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = String.Empty

        Try
            Validar = True
            'Op ContasAReceberAnalitico
            If rdlOpcoes.SelectedValue = "1" Then
                'Período
                If Not (IsDate(txtDataInicial.Text)) Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "período incial não informada ou inválida"
                ElseIf Not (IsDate(txtDataFinal.Text)) Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "período final não informada ou inválida"
                ElseIf Date.Parse(txtDataInicial.Text) > Date.Parse(txtDataFinal.Text) Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "data inicial do período maior que data final"
                End If
                'Fornecedor
                If ucFornecedor.CodFornecedor < 0 Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "fornecedor não informado"
                End If
            End If
            'op ContasAReceberSintetico
            If rdlOpcoes.SelectedValue = "2" Then
                'semana
                If Not (IsDate(txtSemana.Text)) Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "semana não informada ou inválida"
                End If
                'Fornecedor
                If ucFornecedor.CodFornecedor < 0 Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "fornecedor não informado"
                End If
            End If

            'ABCSaldoemAberto
            If rdlOpcoes.SelectedValue = "3" Then

            End If
            'ValoresIncorretos()
            If rdlOpcoes.SelectedValue = "4" Then
                'Período
                If Not (IsDate(txtDataInicial.Text)) Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "data inicial do período não informada ou inválida"
                ElseIf Not (IsDate(txtDataFinal.Text)) Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "data final do período não informada ou inválida"
                ElseIf Date.Parse(txtDataInicial.Text) > Date.Parse(txtDataFinal.Text) Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "data inicial do período maior que data final"
                End If
            End If
            'GingListAnalítico
            If rdlOpcoes.SelectedValue = "5" Then
                'PeriodoIdade
                If txtPeriodoIntervalo.Text = String.Empty Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "período idade não informado"
                End If
                'Fornecedor
                If ucFornecedor.CodFornecedor < 0 Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "fornecedor não informado"
                End If
            End If
            'GingListSintetico
            If rdlOpcoes.SelectedValue = "6" Then
                'PeriodoIdade
                If txtPeriodoIntervalo.Text = String.Empty Then
                    If mensagemErro.Length > 0 Then mensagemErro &= ", "
                    mensagemErro &= "período idade não informado"
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

    Private Sub carregarCmbFormaPagamento()
        Util.carregarCmbFormaPagamento(Controller.ObterFormasPagamento(String.Empty, -1), cmbFormaPagamento, New ListItem("TODAS", "0"))
    End Sub

    Private Sub carregarCmbCelula()
        Util.carregarCmbCelula(Controller.ObterCelulas(0, 0, 0, String.Empty), CmbCelula, New ListItem("TODAS", "0"))
    End Sub

    Private Sub carregarCmbFiltro(ByVal Opcao As Integer)
        If Opcao = 1 Then '1 Contas a Receber Analítico
            With cmbFiltro
                .Items.Clear()
                .Items.Add(New ListItem("TODOS", "1"))
                .Items.Add(New ListItem("A RECEBER > 0", "2"))
                .Items.Add(New ListItem("RECEBER A EMITIR > 0", "3"))
                .SelectedValue = "2"
                .Enabled = True
            End With

            TD1.Visible = True      'Filtro
            TD20.Visible = True     'Filtro
            TD2.Visible = True      'celula
            TD10.Visible = True     'celula
            TD3.Visible = True      'periodo
            TD11.Visible = True     'periodo
            TD4.Visible = False     'semana
            TD12.Visible = False    'semana
            TD5.Visible = False     'peridoidade
            TD13.Visible = False    'peridoidade
            TD6.Visible = True      'fornecedor
            TD14.Visible = True     'fornecedor
            TD7.Visible = True      'usuario
            TD15.Visible = True     'usuario
            TD8.Visible = True      'forma pagmento
            TD16.Visible = True     'forma pagmento
            TD9.Visible = True      'empenho
            TD17.Visible = True     'empenho
            TD18.Visible = False    'empenho
            TD19.Visible = False    'empenho
            Td21.Visible = False 'empenho
            Td22.Visible = False 'empenho
            chkTodasCelula.Visible = False
            cmbTIPIDTEMPASCACOCMC.Visible = False
            chkQuebraCelula.Visible = False

            txtDataInicial.Date = Date.Today.AddDays(-1)
            txtDataFinal.Date = Date.Today
        ElseIf Opcao = 2 Then '2-Contas a Receber Sintético
            With cmbFiltro
                .Items.Clear()
                .Items.Add(New ListItem("TODOS", "1"))
                .Items.Add(New ListItem("RECEBER A EMITIR", "3"))
                .SelectedValue = "1"
                .Enabled = True
            End With

            TD1.Visible = True      'Filtro
            TD20.Visible = True     'Filtro
            TD2.Visible = True      'celula
            TD10.Visible = True     'celula
            TD3.Visible = False     'periodo
            TD11.Visible = False    'periodo
            TD4.Visible = True      'semana
            TD12.Visible = True     'semana
            TD5.Visible = False     'peridoidade
            TD13.Visible = False    'peridoidade
            TD6.Visible = True      'fornecedor
            TD14.Visible = True     'fornecedor
            TD7.Visible = True      'usuario
            TD15.Visible = True     'usuario
            TD8.Visible = True      'forma pagmento
            TD16.Visible = True     'forma pagmento
            TD9.Visible = True      'empenho
            TD17.Visible = True     'empenho
            TD18.Visible = False    'empenho
            TD19.Visible = False    'empenho
            Td21.Visible = False 'empenho
            Td22.Visible = False 'empenho
            chkTodasCelula.Visible = False
            cmbTIPIDTEMPASCACOCMC.Visible = False
            chkQuebraCelula.Visible = True

        ElseIf Opcao = 3 Then '3-ABC - Saldo em Aberto
            'Configura opções de filtro
            With cmbFiltro
                .Items.Clear()
                .Enabled = False
            End With

            TD1.Visible = False      'Filtro
            TD20.Visible = False     'Filtro
            TD2.Visible = True       'celula
            TD10.Visible = True 'celula
            TD3.Visible = False ' periodo
            TD11.Visible = False ' periodo
            TD4.Visible = False 'semana
            TD12.Visible = False 'semana
            TD5.Visible = False 'peridoidade
            TD13.Visible = False 'peridoidade
            TD6.Visible = False 'fornecedor
            TD14.Visible = False 'fornecedor
            TD7.Visible = False 'usuario
            TD15.Visible = False 'usuario
            TD8.Visible = False 'forma pagmento
            TD16.Visible = False 'forma pagmento
            TD9.Visible = False 'empenho
            TD17.Visible = False 'empenho
            TD18.Visible = False 'empenho
            TD19.Visible = False 'empenho
            Td21.Visible = False 'empenho
            Td22.Visible = False 'empenho
            chkTodasCelula.Visible = False
            cmbTIPIDTEMPASCACOCMC.Visible = False
            chkQuebraCelula.Visible = True

        ElseIf Opcao = 4 Then '4-Valores Incorretos
            'Configura opções de filtro
            With cmbFiltro
                .Items.Clear()
                .Enabled = False
            End With

            TD1.Visible = False      'Filtro
            TD20.Visible = False     'Filtro
            TD2.Visible = False 'celula
            TD10.Visible = False 'celula
            TD3.Visible = True ' periodo
            TD11.Visible = True ' periodo
            TD4.Visible = False 'semana
            TD12.Visible = False 'semana
            TD5.Visible = False 'peridoidade
            TD13.Visible = False 'peridoidade
            TD6.Visible = False 'fornecedor
            TD14.Visible = False 'fornecedor
            TD7.Visible = False 'usuario
            TD15.Visible = False 'usuario
            TD8.Visible = False 'forma pagmento
            TD16.Visible = False 'forma pagmento
            TD9.Visible = False 'empenho
            TD17.Visible = False 'empenho
            TD18.Visible = False 'empenho
            TD19.Visible = False 'empenho
            Td21.Visible = False 'empenho
            Td22.Visible = False 'empenho
            chkTodasCelula.Visible = False
            cmbTIPIDTEMPASCACOCMC.Visible = False
            chkQuebraCelula.Visible = False

        ElseIf Opcao = 5 Then '5-Aging List Analítico ( Valores a receber por idade )
            'Configura opções de filtro
            With cmbFiltro
                .Items.Clear()
                .Enabled = False
            End With

            TD1.Visible = False      'Filtro
            TD20.Visible = False     'Filtro
            TD2.Visible = True 'celula
            TD10.Visible = True 'celula
            TD3.Visible = False ' periodo
            TD11.Visible = False ' periodo
            TD4.Visible = False 'semana
            TD12.Visible = False 'semana
            TD5.Visible = True 'peridoidade
            TD13.Visible = True 'peridoidade
            TD6.Visible = True 'fornecedor
            TD14.Visible = True 'fornecedor
            TD7.Visible = False 'usuario
            TD15.Visible = False 'usuario
            TD8.Visible = False 'forma pagmento
            TD16.Visible = False 'forma pagmento
            TD9.Visible = False 'empenho
            TD17.Visible = False 'empenho
            TD18.Visible = True 'empenho
            TD19.Visible = True 'empenho
            Td21.Visible = True 'empenho
            Td22.Visible = True 'empenho
            chkTodasCelula.Visible = True
            chkTodasCelula.Checked = True
            cmbTIPIDTEMPASCACOCMC.Visible = True
            chkQuebraCelula.Visible = True

            cmbTIPIDTEMPASCACOCMC.SelectedValue = "0" 'Defautl Martins

        ElseIf Opcao = 6 Then '6-Aging List Sintético ( Valores a receber por idade )
            'Configura opções de filtro
            With cmbFiltro
                .Items.Clear()
                .Enabled = False
            End With

            TD1.Visible = False      'Filtro
            TD20.Visible = False     'Filtro
            TD2.Visible = True 'celula
            TD10.Visible = True 'celula
            TD3.Visible = False ' periodo
            TD11.Visible = False ' periodo
            TD4.Visible = False 'semana
            TD12.Visible = False 'semana
            TD5.Visible = True 'peridoidade
            TD13.Visible = True 'peridoidade
            TD6.Visible = False 'fornecedor
            TD14.Visible = False 'fornecedor
            TD7.Visible = False 'usuario
            TD15.Visible = False 'usuario
            TD8.Visible = False 'forma pagmento
            TD16.Visible = False 'forma pagmento
            TD9.Visible = False 'empenho
            TD17.Visible = False 'empenho
            TD18.Visible = True 'empenho
            TD19.Visible = True 'empenho
            Td21.Visible = True 'empenho
            Td22.Visible = True 'empenho
            chkTodasCelula.Visible = True
            chkTodasCelula.Checked = True
            cmbTIPIDTEMPASCACOCMC.Visible = True
            chkQuebraCelula.Visible = True

            cmbTIPIDTEMPASCACOCMC.SelectedValue = "0" 'Defautl Martins
        End If
    End Sub

#Region "Relatorios"

    Private Sub ImprimirContasAReceberAnalitico()
        Dim htFormulas As New Hashtable
        Dim Abo As Integer


        If cmbFiltro.SelectedValue <> "3" Then 'diferente de receber e emitir
            'Define o valor da váriavel de parametros
            If cmbFiltro.SelectedValue = "1" Then     'TODOS
                Abo = 0
            ElseIf cmbFiltro.SelectedValue = "2" Then 'A RECEBER > 0
                Abo = 1
            End If
            ' Obter dados do relatório e guardar na seção
            WSCAcoesComerciais.dsRelatorioContasAReceber = Controller.ObterRelatorioContasAReceber_02ZA(Date.Parse(txtDataInicial.Text), Date.Parse(txtDataFinal.Text), Integer.Parse(CmbCelula.SelectedValue), Integer.Parse(CmbCelula.SelectedValue), Convert.ToInt32(ucFornecedor.CodFornecedor), Convert.ToInt32(ucFornecedor.CodFornecedor), Integer.Parse(cmbFormaPagamento.SelectedValue), Integer.Parse(cmbFormaPagamento.SelectedValue), Integer.Parse(ucEmpenho.CodEmpenho.ToString), Integer.Parse(ucEmpenho.CodEmpenho.ToString), Abo)
            'Guarda o nome do relatório na seção
            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "CBY002ZA.RPT"
            'Guarda as Formulas na seção
            With htFormulas
                .Add("NomRel", "'CBY002ZA.RPT'")
                .Add("Usuario", "'" & txtUsuario.Text.ToUpper & "'")
                .Add("Periodo", "'Emitido em: " & Format(Date.Today, "dd/MM/yy") & " Referente ao Período de: " & txtDataInicial.Text & " a " & txtDataFinal.Text & "'")
            End With
            WSCAcoesComerciais.hashtableFormulasCrystal = htFormulas
        Else
            'Obter dados do relatório e guardar na seção
            WSCAcoesComerciais.dsRelatorioContasAReceber = Controller.ObterRelatorioContasAReceber_02ZR(Integer.Parse(CmbCelula.SelectedValue), Convert.ToInt32(ucFornecedor.CodFornecedor), CInt("0"), "N")
            ' Guarda o nome do relatório na seção
            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "CBY002ZR.RPT"
            'Guarda as Formulas na seção
            With htFormulas
                .Add("Periodo", "'Emitido em: " & Format(Date.Today, "dd/MM/yy") & " Referente ao Período de: " & txtDataInicial.Text & " a " & txtDataFinal.Text & "'")
                .Add("NomRel", "'CBY002ZR.RPT'")
                .Add("Usuario", "'" & txtUsuario.Text.ToUpper & "'")
            End With
            WSCAcoesComerciais.hashtableFormulasCrystal = htFormulas
        End If
        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

    Private Sub ImprimirContasAReceberSintetico()
        Dim numeroSemana As Integer
        Dim htFormulas As New Hashtable
        Dim sem1 As String = Convert.ToString(DatePart("ww", txtDataInicial.Date) - 1)
        Dim sem2 As String = Convert.ToString(DatePart("ww", txtDataInicial.Date))
        Dim Ano As String = Format(txtDataInicial.Date, "yyyy")
        Dim Ano1 As String = Format(txtDataFinal.Date, "yyyy")
        Dim PmtFlgTot As Integer

        numeroSemana = DatePart("ww", txtSemana.Text) + (DatePart("yyyy", txtSemana.Text) * 100)
        txtDataInicial.Date = txtSemana.Date

        If cmbFiltro.SelectedValue <> "3" Then 'Diferente de Receber e emitir
            'Define o valor de um doso parametros
            If Integer.Parse(CmbCelula.SelectedValue) <> 0 Then
                PmtFlgTot = 0
            ElseIf cmbFiltro.SelectedValue = "1" Then     'TODOS
                PmtFlgTot = 0
            Else
                PmtFlgTot = 1
            End If
            ' Obter dados do relatório e guardar na seção
            WSCAcoesComerciais.dsRelatorioContasAReceber = Controller.ObterRelatorioContasAReceber_02ZB(numeroSemana, Integer.Parse(CmbCelula.SelectedValue), Integer.Parse(CmbCelula.SelectedValue), Convert.ToInt32(ucFornecedor.CodFornecedor), Convert.ToInt32(ucFornecedor.CodFornecedor), Integer.Parse(cmbFormaPagamento.SelectedValue), Integer.Parse(cmbFormaPagamento.SelectedValue), Integer.Parse(ucEmpenho.CodEmpenho.ToString), Integer.Parse(ucEmpenho.CodEmpenho.ToString), PmtFlgTot)
            'Guarda o nome do relatório na seção
            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "CBY002ZB.RPT"
            'Guarda as Formulas na seção
            With htFormulas
                .Add("Periodo", "'Emitido em: " & Format(Date.Today, "dd/MM/yy") & " Referente ao Período de: " & txtDataInicial.Text & " a " & txtDataFinal.Text & "'")
                .Add("NomRel", "'CBY002ZB.RPT'")
                .Add("Usuario", "'" & txtUsuario.Text.ToUpper & "'")
                .Add("SemAnt", "'" & sem1 & " de " & Ano1 & "'")
                .Add("SemAtu", "'" & sem2 & " de " & Ano1 & "'")
            End With
            WSCAcoesComerciais.hashtableFormulasCrystal = htFormulas
        Else
            'Obter dados do relatório e guardar na seção
            WSCAcoesComerciais.dsRelatorioContasAReceber = Controller.ObterRelatorioContasAReceber_02ZC1(Integer.Parse(CmbCelula.SelectedValue), Convert.ToInt32(ucFornecedor.CodFornecedor), CInt("0"))
            ' Guarda o nome do relatório na seção
            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "CBY002ZC1.RPT"
            'Guarda as Formulas na seção
            With htFormulas
                .Add("Periodo", "'Emitido em: " & Format(Date.Today, "dd/MM/yy") & " Referente ao Período de: " & txtDataInicial.Text & " a " & txtDataFinal.Text & "'")
                .Add("NomRel", "'CBY002ZC1.RPT'")
                .Add("Usuario", "'" & txtUsuario.Text.ToUpper & "'")
            End With
            WSCAcoesComerciais.hashtableFormulasCrystal = htFormulas
        End If
        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

    Private Sub ImprimirABCSaldoemAberto()
        Dim htFormulas As New Hashtable
        Dim IdtFlgTod As Integer

        'Defino o valor da variavel IdtFlgTod
        If CmbCelula.SelectedValue <> "0" Then
            IdtFlgTod = 0
        ElseIf chkQuebraCelula.Checked Then
            IdtFlgTod = 0
        Else
            IdtFlgTod = 1
        End If

        'Obter dados do relatório e guardar na seção
        WSCAcoesComerciais.dsRelatorioContasAReceber = Controller.ObterRelatorioContasAReceber_02ZC(Integer.Parse(CmbCelula.SelectedValue), Integer.Parse(CmbCelula.SelectedValue), Convert.ToInt32(ucFornecedor.CodFornecedor), Convert.ToInt32(ucFornecedor.CodFornecedor), IdtFlgTod)

        'Guarda o nome do relatório na seção
        WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "CBY002ZC.RPT"
        'Guarda as Formulas na seção
        With htFormulas
            .Add("Periodo", "'Emitido em: " & Format(Date.Today, "dd/MM/yy") & " Referente ao Período de: " & txtDataInicial.Text & " a " & txtDataFinal.Text & "'")
            .Add("NomRel", "'CBY002ZC.RPT'")
            .Add("Usuario", "'" & txtUsuario.Text.ToUpper & "'")
        End With
        WSCAcoesComerciais.hashtableFormulasCrystal = htFormulas
        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

    Private Sub ImprimirValoresIncorretos()
        Dim htFormulas As New Hashtable
        ' Obter dados do relatório e guardar na seção
        WSCAcoesComerciais.dsRelatorioContasAReceber = Controller.ObterRelatorioContasAReceber_02ZE1(Date.Parse(txtDataInicial.Text), Date.Parse(txtDataFinal.Text))
        'Guarda o nome do relatório na seção
        WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "CBY002ZE1.RPT"
        'Guarda as Formulas na seção
        With htFormulas
            .Add("Periodo", "'Emitido em: " & Format(Date.Today, "dd/MM/yy") & " Referente ao Período de: " & txtDataInicial.Text & " a " & txtDataFinal.Text & "'")
            .Add("NomRel", "'CBY002ZE1.RPT'")
            .Add("Usuario", "'" & txtUsuario.Text.ToUpper & "'")
        End With
        WSCAcoesComerciais.hashtableFormulasCrystal = htFormulas
        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

    Private Sub ImprimirGingListAnalítico()
        Dim htFormulas As New Hashtable
        Dim lCmbCel As Integer = 0
        Dim QdeDiaInt As Integer
        Dim IdtFlgTod As Integer
        Dim vTipIdtEmp As Integer = CType(cmbTIPIDTEMPASCACOCMC.SelectedValue, Integer)

        'Define o valor de alguns parametros
        lCmbCel = Integer.Parse(CmbCelula.SelectedValue)
        If chkTodasCelula.Visible Then
            If CmbCelula.SelectedValue = "0" And chkTodasCelula.Checked Then
                lCmbCel = -1
            End If
        End If
        If txtPeriodoIntervalo.ValueInt = 0 Then
            txtPeriodoIntervalo.ValueInt = 50
            QdeDiaInt = 50
        Else
            QdeDiaInt = txtPeriodoIntervalo.ValueInt
        End If
        If Integer.Parse(CmbCelula.SelectedValue) <> 0 Then
            IdtFlgTod = 0
        ElseIf chkQuebraCelula.Checked Then  'chkTodasCelula.Checked Then
            IdtFlgTod = 0
        Else
            IdtFlgTod = 1
        End If

        ' Obter dados do relatório e guardar na seção
        WSCAcoesComerciais.dsRelatorioContasAReceber = Controller.ObterRelatorioContasAReceber_02ZF(lCmbCel, Integer.Parse(CmbCelula.SelectedValue), Convert.ToInt32(ucFornecedor.CodFornecedor), Convert.ToInt32(ucFornecedor.CodFornecedor), QdeDiaInt, IdtFlgTod, vTipIdtEmp)
        'Guarda o nome do relatório na seção
        WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "CBY002ZF.RPT"
        'Guarda as Formulas na seção
        With htFormulas
            .Add("Periodo", "'Emitido em: " & Format(Date.Today, "dd/MM/yy") & " Referente ao Período de: " & txtDataInicial.Text & " a " & txtDataFinal.Text & "'")
            .Add("NomRel", "'CBY002ZF.RPT'")
            .Add("Usuario", "'" & txtUsuario.Text.ToUpper & "'")
        End With
        WSCAcoesComerciais.hashtableFormulasCrystal = htFormulas
        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

    Private Sub ImprimirGingListSintetico()
        Dim htFormulas As New Hashtable
        Dim lCmbCel As Integer = 0
        Dim IdtFlgTod As Integer
        Dim vTipIdtEmp As Integer = CType(cmbTIPIDTEMPASCACOCMC.SelectedValue, Integer)

        lCmbCel = Integer.Parse(CmbCelula.SelectedValue)
        If chkTodasCelula.Visible Then
            If CmbCelula.SelectedValue = "0" And chkTodasCelula.Checked Then
                lCmbCel = -1
            End If
        End If

        'Verifica se foi informado o período
        If txtPeriodoIntervalo.ValueInt = 0 Then
            txtPeriodoIntervalo.Value = 50
        End If

        'Define o valor do parametro IdtFlgTod
        If CmbCelula.SelectedValue <> "0" Then
            IdtFlgTod = 0
        ElseIf chkQuebraCelula.Checked Then
            IdtFlgTod = 0
        Else
            IdtFlgTod = 1
        End If

        ' Obter dados do relatório e guardar na seção
        WSCAcoesComerciais.dsRelatorioContasAReceber = Controller.ObterRelatorioContasAReceber_02ZG(lCmbCel, Integer.Parse(CmbCelula.SelectedValue), Integer.Parse(txtPeriodoIntervalo.Text), IdtFlgTod, vTipIdtEmp)

        'Guarda o nome do relatório na seção
        WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = "CBY002ZG.RPT"
        'Guarda as Formulas na seção
        With htFormulas
            .Add("Periodo", "'Emitido em: " & Format(Date.Today, "dd/MM/yy") & " Referente ao Período de: " & txtDataInicial.Text & " a " & txtDataFinal.Text & "'")
            .Add("NomRel", "'CBY002ZG.RPT'")
            .Add("Usuario", "'" & txtUsuario.Text.ToUpper & "'")
            .Add("intervalo", "'" & txtPeriodoIntervalo.Text & "'")
        End With
        WSCAcoesComerciais.hashtableFormulasCrystal = htFormulas
        'Chama o visualizador de relatório
        Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
    End Sub

#End Region

#End Region

End Class