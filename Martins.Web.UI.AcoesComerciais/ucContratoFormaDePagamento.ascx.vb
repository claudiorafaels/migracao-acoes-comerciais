Public Class ucContratoFormaDePagamento
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
    Protected WithEvents lboTIPUNDPGTCTTFRN As System.Web.UI.WebControls.ListBox
    Protected WithEvents cmbCODBCOCTTFRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmbCODAGEBCOCTTFRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDESOBSFRMPGTCTTFRN As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmbTIPFRNCTTFRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmbTIPPGTNOTFSCCTTFRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lboTIPUNDPGTCTTFRN_existente As System.Web.UI.WebControls.ListBox
    Protected WithEvents lblErroCODBCOCTTFRN As System.Web.UI.WebControls.Label
    Protected WithEvents lblErroCODAGEBCOCTTFRN As System.Web.UI.WebControls.Label
    Protected WithEvents lblErroCODCNTCRRBCOCTTFRN As System.Web.UI.WebControls.Label
    Protected WithEvents txtCODCNTCRRBCOCTTFRN As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnExcluirUnidadePagadora As System.Web.UI.WebControls.Button
    Protected WithEvents btnIncluirUnidadePagadora As System.Web.UI.WebControls.Button
    Protected WithEvents DatasetContrato1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetContrato

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
            If (Not IsPostBack) Then
                bindLboTIPUNDPGTCTTFRN()
                bindLboTIPUNDPGTCTTFRN_existente()
                If cmbCODBCOCTTFRN.Items.Count = 0 Then
                    carregarCmbCODBCOCTTFRN()
                End If
            End If
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub btnIncluirUnidadePagadora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncluirUnidadePagadora.Click
        Try
            If Me.SalvarDados() Then
                Me.bindLboTIPUNDPGTCTTFRN()
            End If
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub btnExcluirUnidadePagadora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluirUnidadePagadora.Click
        Try
            If Me.ExcluirDados() Then
                Me.bindLboTIPUNDPGTCTTFRN()
            End If
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub cmbCODBCOCTTFRN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCODBCOCTTFRN.SelectedIndexChanged
        Try
            carregarCmbCODAGEBCOCTTFRN(Convert.ToDecimal(cmbCODBCOCTTFRN.SelectedValue))
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

#End Region

#Region " Metodos "

#Region " Metodos de Carga "

    Private Sub bindLboTIPUNDPGTCTTFRN()
        lboTIPUNDPGTCTTFRN.Items.Clear()
        For Each linha As wsAcoesComerciais.DatasetContrato.T0138482Row In Page.dsContrato.T0138482
            lboTIPUNDPGTCTTFRN.Items.Add(New ListItem(linha.TIPUNDPGTCTTFRN.ToString & " - " & linha.T0138458Row.DESTIPUNDPGTCTTFRN, linha.TIPUNDPGTCTTFRN.ToString))
        Next
    End Sub

    Private Sub bindLboTIPUNDPGTCTTFRN_existente()
        lboTIPUNDPGTCTTFRN_existente.Items.Clear()

        If Page.dsContrato.T0138458.Rows.Count = 0 Then
            Page.dsContrato.Merge(Controller.ObterTiposUnidadePagamento("").T0138458, False, MissingSchemaAction.Ignore)
        End If

        For Each linha As wsAcoesComerciais.DatasetContrato.T0138458Row In Page.dsContrato.T0138458
            If lboTIPUNDPGTCTTFRN.Items.FindByValue(linha.TIPUNDPGTCTTFRN.ToString) Is Nothing Then
                lboTIPUNDPGTCTTFRN_existente.Items.Add(New ListItem(linha.TIPUNDPGTCTTFRN.ToString & " - " & linha.DESTIPUNDPGTCTTFRN, linha.TIPUNDPGTCTTFRN.ToString))
            End If
        Next
    End Sub

    Private Sub carregarCmbCODBCOCTTFRN()
        Dim ds As wsCobrancaBancaria.DatasetBanco
        ds = Controller.ObterBancos(0, "", 0, "", 0)
        Util.carregarCmbBanco(ds, cmbCODBCOCTTFRN, New ListItem("", "0"))
    End Sub

    Private Sub carregarCmbCODAGEBCOCTTFRN(ByVal CODBCO As Decimal)
        Dim ds As wsCobrancaBancaria.DatasetAgencia

        If CODBCO = 0 Then
            cmbCODAGEBCOCTTFRN.Items.Clear()
            Exit Sub
        End If

        ds = Controller.ObterAgencias(0, CODBCO, 0, 0, "", "")
        Util.carregarCmbAgencia(ds, cmbCODAGEBCOCTTFRN, New ListItem("", "0"))
    End Sub

#End Region

#Region " Metdos Regra de Negócio "

    Public Function Validar() As Boolean
        Dim result As Boolean
        Dim mensagemErro As String = String.Empty
        Dim deuFoco As Boolean

        Try
            'Banco
            If cmbCODBCOCTTFRN.SelectedValue = "0" Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "deve-se informar Banco"
                'Foco
                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page(), CType(cmbCODBCOCTTFRN, WebControl))
                    deuFoco = True
                End If
                'Indicador erro
                lblErroCODBCOCTTFRN.Visible = True
            Else
                lblErroCODBCOCTTFRN.Visible = False
            End If

            'Agencia
            If cmbCODAGEBCOCTTFRN.SelectedValue = "0" Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "deve-se informar Agência"
                'Foco
                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page(), CType(cmbCODAGEBCOCTTFRN, WebControl))
                    deuFoco = True
                End If
                'Indicador erro
                lblErroCODAGEBCOCTTFRN.Visible = True
            Else
                lblErroCODAGEBCOCTTFRN.Visible = False
            End If

            'Conta Corrente
            If txtCODCNTCRRBCOCTTFRN.Text = "" Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "deve-se informar Conta Corrente(C.C)"
                'Foco
                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page(), CType(txtCODCNTCRRBCOCTTFRN, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                    deuFoco = True
                End If
                'Indicador erro
                lblErroCODAGEBCOCTTFRN.Visible = True
            Else
                lblErroCODAGEBCOCTTFRN.Visible = False
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

    Public Function transferirDadosParaDataset(ByVal ds As wsAcoesComerciais.DatasetContrato) As wsAcoesComerciais.DatasetContrato
        PreencheLinhaT0124945(ds.T0124945(0))
        Return ds
    End Function

    Public Function transferirDadosParaDatasetUnidadePagadora(ByVal ds As wsAcoesComerciais.DatasetContrato) As wsAcoesComerciais.DatasetContrato
        PreencheLinhaT0138482(ds.T0138482(0))
        Return ds
    End Function

    Private Sub PreencheLinhaT0124945(ByRef dr As wsAcoesComerciais.DatasetContrato.T0124945Row)
        With dr
            If IsNumeric(cmbTIPPGTNOTFSCCTTFRN.SelectedValue) Then
                .TIPPGTNOTFSCCTTFRN = Convert.ToDecimal(cmbTIPPGTNOTFSCCTTFRN.SelectedValue)
            Else
                .SetTIPPGTNOTFSCCTTFRNNull()
            End If
            If IsNumeric(cmbTIPFRNCTTFRN.SelectedValue) Then
                .TIPFRNCTTFRN = Convert.ToDecimal(cmbTIPFRNCTTFRN.SelectedValue)
            Else
                .SetTIPFRNCTTFRNNull()
            End If
            If IsNumeric(cmbCODBCOCTTFRN.SelectedValue) Then
                .CODBCOCTTFRN = Convert.ToDecimal(cmbCODBCOCTTFRN.SelectedValue)
            Else
                .SetCODBCOCTTFRNNull()
            End If
            If IsNumeric(cmbCODAGEBCOCTTFRN.SelectedValue) Then
                .CODAGEBCOCTTFRN = Convert.ToDecimal(cmbCODAGEBCOCTTFRN.SelectedValue)
            Else
                .CODAGEBCOCTTFRN = 0
            End If
            .CODCNTCRRBCOCTTFRN = txtCODCNTCRRBCOCTTFRN.Text
            .DESOBSFRMPGTCTTFRN = txtDESOBSFRMPGTCTTFRN.Text
        End With
    End Sub

    Private Sub PreencheLinhaT0138482(ByRef dr As wsAcoesComerciais.DatasetContrato.T0138482Row)
        With dr
            .TIPUNDPGTCTTFRN = Convert.ToDecimal(lboTIPUNDPGTCTTFRN_existente.SelectedValue)
            .NUMCTTFRN = Page.NUMCTTFRN
        End With
    End Sub

    Public Sub PreencheControles(ByRef ds As wsAcoesComerciais.DatasetContrato)
        Dim dr As wsAcoesComerciais.DatasetContrato.T0124945Row

        If ds.T0124945.Rows.Count = 0 Then
            Exit Sub
        End If

        dr = ds.T0124945(0)
        With dr
            If Not .IsTIPPGTNOTFSCCTTFRNNull Then
                cmbTIPPGTNOTFSCCTTFRN.SelectedValue = .TIPPGTNOTFSCCTTFRN.ToString
            Else
                cmbTIPPGTNOTFSCCTTFRN.SelectedValue = "0"
            End If

            If Not .IsTIPFRNCTTFRNNull Then
                cmbTIPFRNCTTFRN.SelectedValue = .TIPFRNCTTFRN.ToString
            Else
                cmbTIPFRNCTTFRN.SelectedValue = "0"
            End If

            If cmbCODBCOCTTFRN.Items.Count = 0 Then
                carregarCmbCODBCOCTTFRN()
            End If
            If Not .IsCODBCOCTTFRNNull Then
                cmbCODBCOCTTFRN.SelectedValue = .CODBCOCTTFRN.ToString
            Else
                cmbCODBCOCTTFRN.SelectedValue = "0"
            End If

            carregarCmbCODAGEBCOCTTFRN(Convert.ToDecimal(cmbCODBCOCTTFRN.SelectedValue))
            If Not .IsCODAGEBCOCTTFRNNull Then
                cmbCODAGEBCOCTTFRN.SelectedValue = .CODAGEBCOCTTFRN.ToString
            Else
                cmbCODAGEBCOCTTFRN.SelectedValue = "0"
            End If

            If Not .IsCODCNTCRRBCOCTTFRNNull Then
                txtCODCNTCRRBCOCTTFRN.Text = .CODCNTCRRBCOCTTFRN
            Else
                txtCODCNTCRRBCOCTTFRN.Text = ""
            End If

            If Not .IsDESOBSFRMPGTCTTFRNNull Then
                txtDESOBSFRMPGTCTTFRN.Text = .DESOBSFRMPGTCTTFRN
            Else
                txtDESOBSFRMPGTCTTFRN.Text = ""
            End If

        End With
    End Sub

    Private Function SalvarDados() As Boolean
        SalvarDados = False
        If Not Page.dsContrato.T0138482.FindByTIPUNDPGTCTTFRNNUMCTTFRN(Convert.ToDecimal(lboTIPUNDPGTCTTFRN_existente.SelectedValue), Page.NUMCTTFRN) Is Nothing Then
            Dim dr As wsAcoesComerciais.DatasetContrato.T0138482Row = Page.dsContrato.T0138482.FindByTIPUNDPGTCTTFRNNUMCTTFRN(Convert.ToDecimal(lboTIPUNDPGTCTTFRN_existente.SelectedValue), Page.NUMCTTFRN)
            Me.PreencheLinhaT0138482(dr)
        Else
            Dim dr As wsAcoesComerciais.DatasetContrato.T0138482Row = Me.Page.dsContrato.T0138482.NewT0138482Row()
            Me.PreencheLinhaT0138482(dr)
            Me.Page.dsContrato.T0138482.AddT0138482Row(dr)
        End If
        SalvarDados = True
    End Function

    Private Function ExcluirDados() As Boolean
        ExcluirDados = False
        If Not Page.dsContrato.T0138482.FindByTIPUNDPGTCTTFRNNUMCTTFRN(Convert.ToDecimal(lboTIPUNDPGTCTTFRN_existente.SelectedValue), Page.NUMCTTFRN) Is Nothing Then
            Dim dr As wsAcoesComerciais.DatasetContrato.T0138482Row = Page.dsContrato.T0138482.FindByTIPUNDPGTCTTFRNNUMCTTFRN(Convert.ToDecimal(lboTIPUNDPGTCTTFRN_existente.SelectedValue), Page.NUMCTTFRN)
            dr.Delete()
        End If
        ExcluirDados = True
    End Function

#End Region

#End Region

End Class