Public Class ucContratoRelacionamentos
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
    Protected WithEvents GrdRelacionamento As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cmbTIPRLCCTTFRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDESOBSRLCCTTFRN As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmbINDRLCCTTFRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblErroTIPRLCCTTFRN As System.Web.UI.WebControls.Label
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
            Util.AdicionaJsFocus(MyBase.Page, CType(cmbTIPRLCCTTFRN, WebControl))

            Dim ctrlLblErro As WebControl() = New WebControl() {lblErroTIPRLCCTTFRN}
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
                Me.BindGrdRelacionamento()
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

    Private Sub GrdRelacionamento_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles GrdRelacionamento.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Dim linha As wsAcoesComerciais.DatasetContrato.T0138512Row
                linha = Me.Page.dsContrato.T0138512.FindByTIPRLCCTTFRNNUMCTTFRN(Convert.ToDecimal(e.Item.Cells(2).Text), _
                                                                                Page.NUMCTTFRN)
                If Not linha Is Nothing Then
                    PreencheControles(linha)
                End If

            End If

        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub GrdRelacionamento_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles GrdRelacionamento.PageIndexChanged
        Try
            DatasetContrato1 = Page.dsContrato
            Me.GrdRelacionamento.CurrentPageIndex = e.NewPageIndex
            GrdRelacionamento.DataBind()
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region " Metodos "

#Region " Metodos de Carga "

    Private Sub CarregaControles()
        Me.CarregarCmbTIPRLCCTTFRN()
        Me.BindGrdRelacionamento()
    End Sub

    Private Sub CarregarCmbTIPRLCCTTFRN()
        If Page.dsContrato.T0138474.Rows.Count = 0 Then
            Page.dsContrato.Merge(Controller.ObterTiposRelacionamento("").T0138474, False, MissingSchemaAction.Ignore)
        End If

        With cmbTIPRLCCTTFRN
            .Items.Clear()
            For Each drt0138474 As wsAcoesComerciais.DatasetContrato.T0138474Row In Me.Page.dsContrato.T0138474.Rows
                .Items.Add(New ListItem(drt0138474.TIPRLCCTTFRN.ToString() & " - " & drt0138474.DESTIPRLCCTTFRN, drt0138474.TIPRLCCTTFRN.ToString))
            Next
            .Items.Insert(0, New ListItem(String.Empty, String.Empty))
        End With
    End Sub

    Private Sub BindGrdRelacionamento()
        Try
            Me.DatasetContrato1 = Me.Page.dsContrato
            Me.GrdRelacionamento.DataBind()
        Catch ex As Exception
            If Me.GrdRelacionamento.CurrentPageIndex > 0 Then
                Me.GrdRelacionamento.CurrentPageIndex = 0
                BindGrdRelacionamento()
            Else
                Controller.TrataErro(MyBase.Page, ex)
            End If
        End Try
    End Sub

#End Region

#Region " Metodos de Controles "

    Protected Function consultarDESTIPRLCCTTFRN(ByVal vDad As String) As String
        Dim result As String = String.Empty

        If vDad Is Nothing Then
            result = ""
        ElseIf vDad = "" Then
            result = ""
        ElseIf Not IsNumeric(vDad) Then
            result = ""
        Else
            Try
                Dim linha As wsAcoesComerciais.DatasetContrato.T0138474Row = Me.Page.dsContrato.T0138474.FindByTIPRLCCTTFRN(Convert.ToDecimal(vDad))
                If Not linha Is Nothing Then
                    result = linha.TIPRLCCTTFRN.ToString() & " - " & linha.DESTIPRLCCTTFRN
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
            If Val(cmbTIPRLCCTTFRN.SelectedValue) <= 0 Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "relacionamento inválido"

                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page, CType(cmbTIPRLCCTTFRN, WebControl))
                End If
                deuFoco = True
                lblErroTIPRLCCTTFRN.Visible = True
            Else
                lblErroTIPRLCCTTFRN.Visible = False
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

    Private Sub PreencheLinhaT0138512(ByRef dr As wsAcoesComerciais.DatasetContrato.T0138512Row)
        With dr
            .TIPRLCCTTFRN = Convert.ToDecimal(cmbTIPRLCCTTFRN.SelectedValue)
            .NUMCTTFRN = Page.NUMCTTFRN
            .INDRLCCTTFRN = Convert.ToDecimal(cmbINDRLCCTTFRN.SelectedValue)
            .DESOBSRLCCTTFRN = txtDESOBSRLCCTTFRN.Text
        End With
    End Sub

    Private Sub PreencheControles(ByRef dr As wsAcoesComerciais.DatasetContrato.T0138512Row)
        With dr
            cmbTIPRLCCTTFRN.SelectedValue = .TIPRLCCTTFRN.ToString
            cmbINDRLCCTTFRN.SelectedValue = .INDRLCCTTFRN.ToString
            If Not .IsDESOBSRLCCTTFRNNull Then
                txtDESOBSRLCCTTFRN.Text = .DESOBSRLCCTTFRN
            Else
                txtDESOBSRLCCTTFRN.Text = ""
            End If
        End With
    End Sub

    Private Function SalvarDados() As Boolean
        SalvarDados = False
        If Me.ValidarDados() Then
            If Not Page.dsContrato.T0138512.FindByTIPRLCCTTFRNNUMCTTFRN(Convert.ToDecimal(cmbTIPRLCCTTFRN.SelectedValue), Page.NUMCTTFRN) Is Nothing Then
                Dim dr As wsAcoesComerciais.DatasetContrato.T0138512Row = Page.dsContrato.T0138512.FindByTIPRLCCTTFRNNUMCTTFRN(Convert.ToDecimal(cmbTIPRLCCTTFRN.SelectedValue), Page.NUMCTTFRN)
                Me.PreencheLinhaT0138512(dr)
            Else
                Dim dr As wsAcoesComerciais.DatasetContrato.T0138512Row = Me.Page().dsContrato.T0138512.NewT0138512Row()
                Me.PreencheLinhaT0138512(dr)
                Me.Page.dsContrato.T0138512.AddT0138512Row(dr)
            End If
            SalvarDados = True
        End If
    End Function

    Private Function ExcluirLinha() As Boolean
        ExcluirLinha = False
        If Me.ValidarDados() Then
            If Not Page.dsContrato.T0138512.FindByTIPRLCCTTFRNNUMCTTFRN(Convert.ToDecimal(cmbTIPRLCCTTFRN.SelectedValue), Page.NUMCTTFRN) Is Nothing Then
                Dim dr As wsAcoesComerciais.DatasetContrato.T0138512Row = Page.dsContrato.T0138512.FindByTIPRLCCTTFRNNUMCTTFRN(Convert.ToDecimal(cmbTIPRLCCTTFRN.SelectedValue), Page.NUMCTTFRN)
                If dr.RowState = DataRowState.Added Then
                    Page.dsContrato.T0138512.RemoveT0138512Row(dr)
                Else
                    dr.Delete()
                End If
            End If
            ExcluirLinha = True
        End If
        BindGrdRelacionamento()
    End Function
#End Region

#End Region

End Class