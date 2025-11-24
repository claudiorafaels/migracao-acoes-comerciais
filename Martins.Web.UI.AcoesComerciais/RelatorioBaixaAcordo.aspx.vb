Public Class RelatorioBaixaAcordo
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblErro As System.Web.UI.WebControls.Label
    Protected WithEvents btnRemoverSKU As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btnImprimir As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txtDataUltimaAlteracao As Infragistics.WebUI.WebDataInput.WebDateTimeEdit

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

#End Region

#Region " Eventos "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Not Page.IsClientScriptBlockRegistered("WindowOpen")) Then
                Page.RegisterClientScriptBlock("WindowOpen", Util.ShowPopUp(False, False))
            End If

            If (Not IsPostBack) Then

            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            Page.RegisterStartupScript("Fechar", "<script>window.close();</script>")
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If Validar() Then
            Imprimir()
        End If
    End Sub

#End Region

#Region " Métodos "

    Private Function Validar() As Boolean
        Dim NumeroItem As Decimal
        Dim mensagemErro As String = ""

        Try
            Validar = True

            If txtDataUltimaAlteracao.Text = String.Empty Then
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "Favor preencher a data da última alteração"
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

    Private Sub Imprimir()
        Try
            Dim NomRel As String = "CBY300G.rpt"

            '    'Coloca os parametros na seção
            '    Dim htFormulas As New Hashtable
            '    'Guarda as Formulas na seção
            '    With htFormulas
            '        .Add("celula", "'" & cmbCelula.SelectedItem.ToString & "'")
            '        .Add("usuario", "'" & Controller.ObterUsuariosCompraLogadoSistema.T0113471(0).NOMACSUSRSIS.ToUpper.tRIM & "'")
            '        .Add("AnoMesRef", "'" & Format(txtMesRef.Date, "yyyy/MM") & "'")
            '    End With
            '    WSCAcoesComerciais.hashtableFormulasCrystal = htFormulas

            '    'Guarda o dataset na seção
            '    WSCAcoesComerciais.dsRelatorioSaldoDisponivelFornecedorCelula = Controller.ObterRelatorioSaldoDisponivelFornecedorCelula(Convert.ToDecimal(cmbCelula.SelectedValue), Convert.ToDecimal(cmbEmpenho.SelectedValue), Convert.ToDecimal(Format(txtMesRef.Date, "yyyyMM")), Convert.ToInt32(tblOpcao.SelectedValue))

            '    'Guarda o nome do relatório na seção
            '    WSCAcoesComerciais.StringValue(WSCVar.crNomeRelatorio) = NomRel

            'Chama o visualizador de relatório
            Page.RegisterStartupScript("ChamadaVisualizador", "<SCRIPT language='JavaScript'>javascript:window.open('VisualizadorRelatorio.aspx','_blank','top = 0,left =0,height = 650,width = 1024,toolbar=yes,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,fullscreen=no,movable=yes, title=no')</SCRIPT>")

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

#End Region

End Class