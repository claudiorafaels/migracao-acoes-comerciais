Public Class ucContratoCondicaoPagamento
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtNUMDIAPRZPGTCTTFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents cmbTIPFRMPGTCTTFRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtPERDSCFINCTTFRN As Infragistics.WebUI.WebDataInput.WebPercentEdit
    Protected WithEvents txtPERENCFINCTTFRN As Infragistics.WebUI.WebDataInput.WebPercentEdit
    Protected WithEvents cmbTIPENCFINCTTFRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDESOBSCNDPGTCTTFRN As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblErroNUMDIAPRZPGTCTTFRN As System.Web.UI.WebControls.Label
    Protected WithEvents lblErroTIPFRMPGTCTTFRN As System.Web.UI.WebControls.Label
    Protected WithEvents lblErroTIPENCFINCTTFRN As System.Web.UI.WebControls.Label

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
        If (Not IsPostBack) Then
        End If
    End Sub

#End Region

#Region " Metodos "

#Region " Metodos de Carga "
    'Não tem
#End Region

#Region " Metdos Regra de Negócio "

    Public Function Validar() As Boolean
        Dim result As Boolean
        Dim mensagemErro As String = String.Empty
        Dim deuFoco As Boolean

        Try
            'Prazo Pagamento
            If txtNUMDIAPRZPGTCTTFRN.ValueDecimal <= 0 Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "deve-se informar Prazo Pagamento"
                'Foco
                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page(), CType(txtNUMDIAPRZPGTCTTFRN, WebControl), Util.tipoDeComponente.InfragisticsTxt)
                    deuFoco = True
                End If
                'Indicador erro
                lblErroNUMDIAPRZPGTCTTFRN.Visible = True
            Else
                lblErroNUMDIAPRZPGTCTTFRN.Visible = False
            End If

            'Modalidade Pagamento
            If cmbTIPFRMPGTCTTFRN.SelectedValue = "0" Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "deve-se informar Modalidade de Pagamento"
                'Foco
                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page(), CType(cmbTIPFRMPGTCTTFRN, WebControl))
                    deuFoco = True
                End If
                'Indicador erro
                lblErroTIPFRMPGTCTTFRN.Visible = True
            Else
                lblErroTIPFRMPGTCTTFRN.Visible = False
            End If

            'Periodicidade do Encargo
            If cmbTIPENCFINCTTFRN.SelectedValue = "0" Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "deve-se informar periodicidade do encargo"
                'Foco
                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page(), CType(cmbTIPENCFINCTTFRN, WebControl))
                    deuFoco = True
                End If
                'Indicador erro
                lblErroTIPENCFINCTTFRN.Visible = True
            Else
                lblErroTIPENCFINCTTFRN.Visible = False
            End If

            'Mostra mensagem de erro
            If mensagemErro.Trim() <> String.Empty Then
                Page.RegisterStartupScript("Alerta", "<script>alert('" & (mensagemErro.Substring(0, 1)).ToUpper & mensagemErro.Substring(1) & "');</script>")
                Return False
            End If

            Return True

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Function

    Public Function transferirDadosParaDataset(ByVal ds As wsAcoesComerciais.DatasetContrato) As wsAcoesComerciais.DatasetContrato
        PreencheLinhaT0124945(ds.T0124945(0))
        Return ds
    End Function

    Private Sub PreencheLinhaT0124945(ByRef dr As wsAcoesComerciais.DatasetContrato.T0124945Row)
        With dr
            .NUMDIAPRZPGTCTTFRN = txtNUMDIAPRZPGTCTTFRN.ValueDecimal
            .TIPFRMPGTCTTFRN = Convert.ToDecimal(cmbTIPFRMPGTCTTFRN.SelectedValue)
            .PERDSCFINCTTFRN = txtPERDSCFINCTTFRN.ValueDecimal
            .PERENCFINCTTFRN = txtPERENCFINCTTFRN.ValueDecimal
            .TIPENCFINCTTFRN = Convert.ToDecimal(cmbTIPENCFINCTTFRN.SelectedValue)
            .DESOBSCNDPGTCTTFRN = txtDESOBSCNDPGTCTTFRN.Text
        End With
    End Sub

    Public Sub PreencheControles(ByRef ds As wsAcoesComerciais.DatasetContrato)
        Dim dr As wsAcoesComerciais.DatasetContrato.T0124945Row

        If ds.T0124945.Rows.Count = 0 Then
            Exit Sub
        End If

        dr = ds.T0124945(0)
        With dr
            If Not .IsNUMDIAPRZPGTCTTFRNNull Then
                txtNUMDIAPRZPGTCTTFRN.ValueDecimal = .NUMDIAPRZPGTCTTFRN
            Else
                txtNUMDIAPRZPGTCTTFRN.ValueDecimal = 0
            End If
            If Not .IsTIPFRMPGTCTTFRNNull Then
                cmbTIPFRMPGTCTTFRN.SelectedValue = .TIPFRMPGTCTTFRN.ToString
            Else
                cmbTIPFRMPGTCTTFRN.SelectedValue = "0"
            End If
            If Not .IsPERDSCFINCTTFRNNull Then
                txtPERDSCFINCTTFRN.ValueDecimal = .PERDSCFINCTTFRN
            Else
                txtPERDSCFINCTTFRN.ValueDecimal = 0
            End If
            If Not .IsPERENCFINCTTFRNNull Then
                txtPERENCFINCTTFRN.ValueDecimal = .PERENCFINCTTFRN
            Else
                txtPERENCFINCTTFRN.ValueDecimal = 0
            End If
            If Not .IsTIPENCFINCTTFRNNull Then
                cmbTIPENCFINCTTFRN.SelectedValue = .TIPENCFINCTTFRN.ToString
            Else
                cmbTIPENCFINCTTFRN.SelectedValue = "0"
            End If
            If Not .IsDESOBSCNDPGTCTTFRNNull Then
                txtDESOBSCNDPGTCTTFRN.Text = .DESOBSCNDPGTCTTFRN
            Else
                txtDESOBSCNDPGTCTTFRN.Text = ""
            End If
        End With
    End Sub

#End Region

#End Region

End Class