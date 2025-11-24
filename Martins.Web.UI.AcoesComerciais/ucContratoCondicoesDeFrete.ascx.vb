Public Class ucContratoCondicoesDeFrete
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
    Protected WithEvents cmdAtualizar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cmbTIPFRTCTTFRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblErroTIPFRTCTTFRN As System.Web.UI.WebControls.Label
    Protected WithEvents GrdCondicoesFrete As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetContrato1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContrato
    Protected WithEvents txtDESOBSTIPFRTCTTFRN As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdExcluir As System.Web.UI.WebControls.LinkButton

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
            cmdExcluir.Attributes.Add("OnClick", "javascript:return confirm('Deseja excluir esse registro?')")
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub cmdNova_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            CarregaControles()
            Util.AdicionaJsFocus(MyBase.Page, CType(cmbTIPFRTCTTFRN, WebControl))

            Dim ctrlLblErro As WebControl() = New WebControl() {lblErroTIPFRTCTTFRN}
            Util.MostraControles(ctrlLblErro, True)
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
                Me.BindGrdCondicoesFrete()
            End If
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub GrdCondicoesFrete_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles GrdCondicoesFrete.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Dim linha As wsAcoesComerciais.DatasetContrato.T0138490Row
                linha = Me.Page.dsContrato.T0138490.FindByTIPFRTCTTFRNNUMCTTFRN(e.Item.Cells(2).Text, _
                                                                                Page.NUMCTTFRN)
                If Not linha Is Nothing Then
                    PreencheControles(linha)
                End If

            End If

        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub GrdCondicoesFrete_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles GrdCondicoesFrete.PageIndexChanged
        Try
            DatasetContrato1 = Page.dsContrato
            Me.GrdCondicoesFrete.CurrentPageIndex = e.NewPageIndex
            GrdCondicoesFrete.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        Dim linha As wsAcoesComerciais.DatasetContrato.T0138490Row
        linha = Me.Page.dsContrato.T0138490.FindByTIPFRTCTTFRNNUMCTTFRN(cmbTIPFRTCTTFRN.SelectedValue, _
                                                                Page.NUMCTTFRN)

        If Page.flagContratoAtivo = False Then
            Util.AdicionaJsAlert(MyBase.Page, "Esse contrato não está ativo")
            Exit Sub
        End If

        If Not linha Is Nothing Then
            linha.Delete()
        End If

        BindGrdCondicoesFrete()
    End Sub

#End Region

#Region " Metodos "

#Region " Metodos de Carga "

    Private Sub CarregaControles()
        Me.BindGrdCondicoesFrete()
    End Sub

    Private Sub BindGrdCondicoesFrete()
        Try
            Me.DatasetContrato1 = Me.Page.dsContrato
            Me.GrdCondicoesFrete.DataBind()
        Catch ex As Exception
            If Me.GrdCondicoesFrete.CurrentPageIndex > 0 Then
                Me.GrdCondicoesFrete.CurrentPageIndex = 0
                BindGrdCondicoesFrete()
            Else
                Controller.TrataErro(MyBase.Page, ex)
            End If
        End Try
    End Sub

#End Region

#Region " Metodos de Controles "

    Protected Function consultarTIPFRTCTTFRN(ByVal vDad As String) As String
        Dim result As String = String.Empty

        If vDad Is Nothing Then
            result = ""
        ElseIf vDad = "" Then
            result = ""
        ElseIf Not IsNumeric(vDad) Then
            result = ""
        Else
            If vDad = "1" Then
                result = "C.I.F"
            ElseIf vDad = "2" Then
                result = "F.O.B"
            End If
        End If

        Return result
    End Function

#End Region

#Region " Metodos de Regras de Negocio "

    Private Function ValidarDados() As Boolean
        Dim result As Boolean
        Dim mensagemErro As String = String.Empty
        Dim deuFoco As Boolean

        Try

            If Not IsNumeric(cmbTIPFRTCTTFRN.SelectedValue) Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "Tipo inválido"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(cmbTIPFRTCTTFRN, WebControl))
                End If
                deuFoco = True
                lblErroTIPFRTCTTFRN.Visible = True
            Else
                lblErroTIPFRTCTTFRN.Visible = False
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

    End Function

    Private Sub PreencheLinhaT0138490(ByRef dr As wsAcoesComerciais.DatasetContrato.T0138490Row)
        With dr
            .TIPFRTCTTFRN = cmbTIPFRTCTTFRN.SelectedValue
            .NUMCTTFRN = Page.NUMCTTFRN
            .DESOBSTIPFRTCTTFRN = txtDESOBSTIPFRTCTTFRN.Text
        End With
    End Sub

    Private Sub PreencheControles(ByRef dr As wsAcoesComerciais.DatasetContrato.T0138490Row)
        With dr
            cmbTIPFRTCTTFRN.SelectedValue = .TIPFRTCTTFRN
            txtDESOBSTIPFRTCTTFRN.Text = .DESOBSTIPFRTCTTFRN
        End With
    End Sub

    Private Function SalvarDados() As Boolean
        SalvarDados = False
        If Me.ValidarDados() Then
            If Not Page.dsContrato.T0138490.FindByTIPFRTCTTFRNNUMCTTFRN(cmbTIPFRTCTTFRN.SelectedValue, Page.NUMCTTFRN) Is Nothing Then
                Dim dr As wsAcoesComerciais.DatasetContrato.T0138490Row = Page.dsContrato.T0138490.FindByTIPFRTCTTFRNNUMCTTFRN(cmbTIPFRTCTTFRN.SelectedValue, Page.NUMCTTFRN)
                Me.PreencheLinhaT0138490(dr)
            Else
                Dim dr As wsAcoesComerciais.DatasetContrato.T0138490Row = Me.Page.dsContrato.T0138490.NewT0138490Row()
                Me.PreencheLinhaT0138490(dr)
                Me.Page.dsContrato.T0138490.AddT0138490Row(dr)
            End If
            SalvarDados = True
        End If
    End Function

#End Region

#End Region

End Class