Public Class ExtratoCelula
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents tblOpcao As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents cmbCelula As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmbEmpenho As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnImprimir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtMesRef As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents btnVisualizar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents TD1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD2 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents Tr1 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents TDEspera As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Div2 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents TDReserva As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents cmbFiltro As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TDlblFiltro As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TDcmbFiltro As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD3 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD4 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TD5 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tbOpcoes As System.Web.UI.HtmlControls.HtmlTable

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
            InicializarPagina()
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            If Validar() Then
                WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = True
                Imprimir()
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            If Validar() Then
                WSCAcoesComerciais.BooleanValue(WSCVar.crSaidaDiretoPDF) = False
                Imprimir()
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Dim mensagemErro As String = String.Empty

        Try
            If txtMesRef.Date = Nothing Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "Informe o mês de referência"
            End If

            If mensagemErro.Trim() <> String.Empty Then
                Page.RegisterStartupScript("Alerta", "<script>alert('" & (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1) & "');</script>")
                Return False
            End If

            Return True
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Page.RegisterStartupScript("Fechar", "<script>window.close();</script>")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub tblOpcao_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblOpcao.SelectedIndexChanged
        If tblOpcao.SelectedValue = "0" Then     'Sintético
            TD4.Visible = False
            TD5.Visible = False
        ElseIf tblOpcao.SelectedValue = "1" Then 'Analítico
            TD4.Visible = True
            TD5.Visible = True
        End If
    End Sub

#End Region

#Region "Metodos"

    Private Sub InicializarPagina()
        Try
            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(True))
            End If

            If (Not IsPostBack) Then
                Util.carregarCmbCelula(Controller.ObterCelulas(0, 0, 0, ""), cmbCelula, New ListItem("TODAS", "0"))
                Me.carregarCmbEmpenho(Controller.ObterEmpenhos("", "", "", 0, ""), cmbEmpenho, New ListItem("TODOS", "0"))
                txtMesRef.Date = Date.Today
                TD4.Visible = False
                TD5.Visible = False
            End If
            btnCancelar.Attributes.Add("OnClick", "javascript:window.close()")
            btnImprimir.Attributes.Add("OnClick", "javascript:mostraAndamento()")
            btnVisualizar.Attributes.Add("OnClick", "javascript:mostraAndamento()")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub carregarCmbEmpenho(ByRef ds As wsAcoesComerciais.DatasetEmpenho, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        Dim TIPUSRSIS As String

        Try
            TIPUSRSIS = Controller.ObterUsuariosCompraLogadoSistema.T0113471(0).TIPUSRSIS
        Catch ex As Exception
            Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
            Exit Sub
        End Try

        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetEmpenho.T0109059Row In ds.T0109059.Select("", "TIPDSNDSCBNF")
                If linha.INDTRNDSNDSCBNF = 1 Then
                    If TIPUSRSIS = "X" Or TIPUSRSIS = "D" Then
                        .Items.Add(New ListItem(Format(linha.TIPDSNDSCBNF, "0000") & " - " & linha.DESDSNDSCBNF, linha.TIPDSNDSCBNF.ToString))
                    End If
                Else
                    .Items.Add(New ListItem(Format(linha.TIPDSNDSCBNF, "0000") & " - " & linha.DESDSNDSCBNF, linha.TIPDSNDSCBNF.ToString))
                End If
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    Private Sub Imprimir()
        Try
            Dim NomRel As String

            If tblOpcao.SelectedValue = "0" Then 'Sintético
                NomRel = "CCX001J.rpt"
            Else 'Analítico
                If cmbFiltro.SelectedValue = "1" Then
                    NomRel = "CCX001JB.rpt"
                Else
                    NomRel = "CCX001JC.rpt"
                End If
            End If

            'Coloca os parametros na seção
            Dim htFormulas As New Hashtable
            'Guarda as Formulas na seção
            With htFormulas
                .Add("celula", "'" & cmbCelula.SelectedItem.ToString & "'")

                Try
                    .Add("usuario", "'" & Controller.ObterUsuariosCompraLogadoSistema.T0113471(0).NOMACSUSRSIS.ToUpper.Trim & "'")
                Catch ex As Exception
                    Util.AdicionaJsAlert(Me.Page, "Não foi possivel obter o usuário de compra logado ao sistema (tabela T0113471)")
                    Exit Sub
                End Try

                .Add("AnoMesRef", "'" & Format(txtMesRef.Date, "yyyy/MM") & "'")
            End With
            WSCAcoesComerciais.hashtableFormulasCrystal = htFormulas

            'Guarda o dataset na seção
            WSCAcoesComerciais.dsRelatorioSaldoDisponivelFornecedorCelula = Controller.ObterRelatorioSaldoDisponivelFornecedorCelula(Convert.ToDecimal(cmbCelula.SelectedValue), 0, Convert.ToDecimal(cmbEmpenho.SelectedValue), Convert.ToDecimal(Format(txtMesRef.Date, "yyyyMM")), Convert.ToInt32(tblOpcao.SelectedValue))

            'Guarda o nome do relatório na seção
            WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = NomRel

            'Chama o visualizador de relatório
            Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

End Class