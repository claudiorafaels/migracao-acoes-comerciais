Public Class ucContratoServicos
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
    Protected WithEvents cmbTIPSVCCTTFRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDESOBSSVCCTTFRN As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmbINDSVCCTTFRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblErroTIPSVCCTTFRN As System.Web.UI.WebControls.Label
    Protected WithEvents cmdAtualizar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents GrdServicos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetContrato1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContrato
    Protected WithEvents btnExcluir As System.Web.UI.WebControls.LinkButton

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
            btnExcluir.Attributes.Add("OnClick", "javascript:return confirm('Deseja excluir este registro ?')")
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub cmdNova_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            CarregaControles()
            Util.AdicionaJsFocus(MyBase.Page, CType(cmbTIPSVCCTTFRN, WebControl))

            Dim ctrlLblErro As WebControl() = New WebControl() {lblErroTIPSVCCTTFRN}
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
                Me.BindGrdServicos()
            End If
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click
        If Page.flagContratoAtivo = False Then
            Util.AdicionaJsAlert(MyBase.Page, "Esse contrato não está ativo")
            Exit Sub
        End If
        ExcluirLinha()
    End Sub

    Private Sub GrdServicos_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles GrdServicos.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Dim linha As wsAcoesComerciais.DatasetContrato.T0138504Row
                linha = Me.Page.dsContrato.T0138504.FindByTIPSVCCTTFRNNUMCTTFRN(Convert.ToDecimal(e.Item.Cells(2).Text), _
                                                                                Page.NUMCTTFRN)
                If Not linha Is Nothing Then
                    PreencheControles(linha)
                End If

            End If

        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub GrdServicos_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles GrdServicos.PageIndexChanged
        Try
            DatasetContrato1 = Page.dsContrato
            Me.GrdServicos.CurrentPageIndex = e.NewPageIndex
            GrdServicos.DataBind()
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region " Metodos "

#Region " Metodos de Carga "

    Private Sub CarregaControles()
        Me.CarregarcmbTIPSVCCTTFRN()
        Me.BindGrdServicos()
    End Sub

    Private Sub CarregarCmbTIPSVCCTTFRN()
        If Page.dsContrato.T0138466.Rows.Count = 0 Then
            Page.dsContrato.Merge(Controller.ObterTiposServico("").T0138466, False, MissingSchemaAction.Ignore)
        End If

        With cmbTIPSVCCTTFRN
            .Items.Clear()
            For Each drT0138466 As wsAcoesComerciais.DatasetContrato.T0138466Row In Me.Page.dsContrato.T0138466.Rows
                .Items.Add(New ListItem(drT0138466.TIPSVCCTTFRN.ToString() & " - " & drT0138466.DESTIPSVCCTTFRN, drT0138466.TIPSVCCTTFRN.ToString))
            Next
            .Items.Insert(0, New ListItem(String.Empty, String.Empty))
        End With
    End Sub

    Private Sub BindGrdServicos()
        Try
            Me.DatasetContrato1 = Me.Page.dsContrato
            Me.GrdServicos.DataBind()
        Catch ex As Exception
            If Me.GrdServicos.CurrentPageIndex > 0 Then
                Me.GrdServicos.CurrentPageIndex = 0
                BindGrdServicos()
            Else
                Controller.TrataErro(MyBase.Page, ex)
            End If
        End Try

    End Sub

#End Region

#Region " Metodos de Controles "

    Protected Function consultarDESTIPSVCCTTFRN(ByVal vDad As String) As String
        Dim result As String = String.Empty

        If vDad Is Nothing Then
            result = ""
        ElseIf vDad = "" Then
            result = ""
        ElseIf Not IsNumeric(vDad) Then
            result = ""
        Else
            Try
                Dim linha As wsAcoesComerciais.DatasetContrato.T0138466Row = Me.Page.dsContrato.T0138466.FindByTIPSVCCTTFRN(Convert.ToDecimal(vDad))
                If Not linha Is Nothing Then
                    result = linha.TIPSVCCTTFRN.ToString() & " - " & linha.DESTIPSVCCTTFRN
                End If
            Catch ex As Exception
                result = ""
            End Try
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
            If Val(cmbTIPSVCCTTFRN.SelectedValue) <= 0 Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "serviço inválido"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(cmbTIPSVCCTTFRN, WebControl))
                End If
                deuFoco = True
                lblErroTIPSVCCTTFRN.Visible = True
            Else
                lblErroTIPSVCCTTFRN.Visible = False
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

    Private Sub PreencheLinhaT0138504(ByRef dr As wsAcoesComerciais.DatasetContrato.T0138504Row)
        With dr
            .TIPSVCCTTFRN = Convert.ToDecimal(cmbTIPSVCCTTFRN.SelectedValue)
            .NUMCTTFRN = Page.NUMCTTFRN
            .INDSVCCTTFRN = Convert.ToDecimal(cmbINDSVCCTTFRN.SelectedValue)
            .DESOBSSVCCTTFRN = txtDESOBSSVCCTTFRN.Text
        End With
    End Sub

    Private Sub PreencheControles(ByRef dr As wsAcoesComerciais.DatasetContrato.T0138504Row)
        With dr
            cmbTIPSVCCTTFRN.SelectedValue = .TIPSVCCTTFRN.ToString
            cmbINDSVCCTTFRN.SelectedValue = .INDSVCCTTFRN.ToString
            If Not .IsDESOBSSVCCTTFRNNull Then
                txtDESOBSSVCCTTFRN.Text = .DESOBSSVCCTTFRN
            Else
                txtDESOBSSVCCTTFRN.Text = ""
            End If
        End With
    End Sub

    Private Function SalvarDados() As Boolean
        SalvarDados = False
        If Me.ValidarDados() Then
            If Not Page.dsContrato.T0138504.FindByTIPSVCCTTFRNNUMCTTFRN(Convert.ToDecimal(cmbTIPSVCCTTFRN.SelectedValue), Page.NUMCTTFRN) Is Nothing Then
                Dim dr As wsAcoesComerciais.DatasetContrato.T0138504Row = Page.dsContrato.T0138504.FindByTIPSVCCTTFRNNUMCTTFRN(Convert.ToDecimal(cmbTIPSVCCTTFRN.SelectedValue), Page.NUMCTTFRN)
                Me.PreencheLinhaT0138504(dr)
            Else
                Dim dr As wsAcoesComerciais.DatasetContrato.T0138504Row = Me.Page().dsContrato.T0138504.NewT0138504Row()
                Me.PreencheLinhaT0138504(dr)
                Me.Page.dsContrato.T0138504.AddT0138504Row(dr)
            End If
            SalvarDados = True
        End If
    End Function

    Private Function ExcluirLinha() As Boolean
        ExcluirLinha = False
        If Me.ValidarDados() Then
            If Not Page.dsContrato.T0138504.FindByTIPSVCCTTFRNNUMCTTFRN(Convert.ToDecimal(cmbTIPSVCCTTFRN.SelectedValue), Page.NUMCTTFRN) Is Nothing Then
                Dim dr As wsAcoesComerciais.DatasetContrato.T0138504Row = Page.dsContrato.T0138504.FindByTIPSVCCTTFRNNUMCTTFRN(Convert.ToDecimal(cmbTIPSVCCTTFRN.SelectedValue), Page.NUMCTTFRN)
                If dr.RowState = DataRowState.Added Then
                    Page.dsContrato.T0138504.RemoveT0138504Row(dr)
                Else
                    dr.Delete()
                End If
            End If
            ExcluirLinha = True
        End If
        BindGrdServicos()
    End Function

#End Region

#End Region

End Class