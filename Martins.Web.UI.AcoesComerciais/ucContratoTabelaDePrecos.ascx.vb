Public Class ucContratoTabelaDePrecos
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents cmbTIPABGTABPCOCTTFRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNUMDIAATLTABPCOFRN As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents cmbINDDIFALQICMCTTFRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmbINDDIFCNLVNDCTTFRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDESOBSTABPCOCTTFRN As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblErroTIPABGTABPCOCTTFRN As System.Web.UI.WebControls.Label

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
            'Abrangência
            If cmbTIPABGTABPCOCTTFRN.SelectedValue = "0" Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "deve-se informar abrangencia"
                'Foco
                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page(), CType(cmbTIPABGTABPCOCTTFRN, WebControl))
                    deuFoco = True
                End If
                'Indicador erro
                lblErroTIPABGTABPCOCTTFRN.Visible = True
            Else
                lblErroTIPABGTABPCOCTTFRN.Visible = False
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

    Private Sub PreencheLinhaT0124945(ByRef dr As wsAcoesComerciais.DatasetContrato.T0124945Row)
        With dr
            .TIPABGTABPCOCTTFRN = Convert.ToDecimal(cmbTIPABGTABPCOCTTFRN.SelectedValue)
            .INDDIFALQICMCTTFRN = Convert.ToDecimal(cmbINDDIFALQICMCTTFRN.SelectedValue)
            .INDDIFCNLVNDCTTFRN = Convert.ToDecimal(cmbINDDIFCNLVNDCTTFRN.SelectedValue)
            .NUMDIAATLTABPCOFRN = txtNUMDIAATLTABPCOFRN.ValueDecimal
            .DESOBSTABPCOCTTFRN = txtDESOBSTABPCOCTTFRN.Text
        End With
    End Sub

    Public Sub PreencheControles(ByRef ds As wsAcoesComerciais.DatasetContrato)
        Dim dr As wsAcoesComerciais.DatasetContrato.T0124945Row

        If ds.T0124945.Rows.Count = 0 Then
            Exit Sub
        End If

        dr = ds.T0124945(0)
        With dr
            If Not .IsTIPABGTABPCOCTTFRNNull Then
                cmbTIPABGTABPCOCTTFRN.SelectedValue = .TIPABGTABPCOCTTFRN.ToString
            Else
                cmbTIPABGTABPCOCTTFRN.SelectedValue = "0"
            End If
            If Not .IsINDDIFALQICMCTTFRNNull Then
                cmbINDDIFALQICMCTTFRN.SelectedValue = .INDDIFALQICMCTTFRN.ToString
            Else
                cmbINDDIFALQICMCTTFRN.SelectedValue = "0"
            End If
            If Not .IsINDDIFCNLVNDCTTFRNNull Then
                cmbINDDIFCNLVNDCTTFRN.SelectedValue = .INDDIFCNLVNDCTTFRN.ToString
            Else
                cmbINDDIFCNLVNDCTTFRN.SelectedValue = "0"
            End If
            If Not .IsNUMDIAATLTABPCOFRNNull Then
                txtNUMDIAATLTABPCOFRN.ValueDecimal = .NUMDIAATLTABPCOFRN
            Else
                txtNUMDIAATLTABPCOFRN.ValueDecimal = 0
            End If
            If Not .IsDESOBSTABPCOCTTFRNNull Then
                txtDESOBSTABPCOCTTFRN.Text = .DESOBSTABPCOCTTFRN
            Else
                txtDESOBSTABPCOCTTFRN.Text = ""
            End If
        End With

    End Sub

#End Region

#End Region

End Class
