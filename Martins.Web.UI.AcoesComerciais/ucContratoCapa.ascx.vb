Public Class ucContratoCapa
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtDatIniPodVgrCttFrn As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtDatDstCttFrn As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents txtQtdIteCtlFrn As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents txtDesLnhPrdCttFrn As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlIndDscCmcPet As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDesObsDescCmcPet As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkPrgVen As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkPerApu As System.Web.UI.WebControls.CheckBox
    Protected WithEvents ddlProPer As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtPrzProVec As Infragistics.WebUI.WebDataInput.WebNumericEdit
    Protected WithEvents ddlAceTrc As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlTipRess As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlTipFreDev As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDesObsDvlMer As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkIndApuPisCttFrn As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkIndApuPisNcmCttFrn As System.Web.UI.WebControls.CheckBox
    Protected WithEvents ddlTipCttFrn As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDatVen As Infragistics.WebUI.WebDataInput.WebDateTimeEdit
    Protected WithEvents lblErrotxtDatIniPodVgrCttFrn As System.Web.UI.WebControls.Label
    Protected WithEvents lblErroddlProPer As System.Web.UI.WebControls.Label
    Protected WithEvents chkAvisoRenovacao As System.Web.UI.WebControls.CheckBox
    Protected WithEvents TRDataAviso As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents txtDataAviso As Infragistics.WebUI.WebDataInput.WebDateTimeEdit

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

    Public ReadOnly Property DATINIPODVGRCTTFRN() As Date
        Get
            Return txtDatIniPodVgrCttFrn.Date
        End Get
    End Property

    Public ReadOnly Property DATVNCCTTFRN() As Date
        Get
            If Page.dsContrato.T0124945.Rows.Count > 0 Then
                If Not Page.dsContrato.T0124945(0).IsNull("DATVNCCTTFRN") Then
                    Return Page.dsContrato.T0124945(0).DATVNCCTTFRN
                End If
            End If

            If IsDate(txtDatIniPodVgrCttFrn.Text) Then
                Return txtDatIniPodVgrCttFrn.Date.AddMonths(Convert.ToInt32(ddlProPer.SelectedValue.Split(";"c).GetValue(1)))
            End If

            Return Nothing
        End Get
    End Property

    Public ReadOnly Property TIPPODCTTFRN() As Decimal
        Get
            Return Convert.ToDecimal(ddlProPer.SelectedValue.Split(";"c).GetValue(0))
        End Get
    End Property

#End Region

#Region " Eventos "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Not IsPostBack) Then
                Me.CarregaControles()
            End If
        Catch ex As Exception
            Controller.TrataErro(MyBase.Page, ex)
        End Try
    End Sub

    Private Sub chkAvisoRenovacao_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAvisoRenovacao.CheckedChanged
        
        If chkAvisoRenovacao.Checked Then
            If txtDatVen.Text = String.Empty Then

                Util.AdicionaJsAlert(MyBase.Page, "Para utilizar este recurso é necessário gravar o contrato," & vbCrLf & "para que a data de vencimento seja gerada.", True)
                chkAvisoRenovacao.Checked = False
            Else
                TRDataAviso.Visible = True
                Me.GeraDataAviso()
            End If

        Else
            TRDataAviso.Visible = False
        End If


    End Sub

    Private Sub txtDatVen_ValueChange(ByVal sender As Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtDatVen.ValueChange
        GeraDataAviso()
    End Sub

    Private Sub txtDataAviso_ValueChange(ByVal sender As Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtDataAviso.ValueChange
        If txtDataAviso.Date.Day <> txtDatVen.Date.Day Then
            Util.AdicionaJsAlert(MyBase.Page, "Dia Inválido! O dia deve ser o mesmo da data de vencimento.", True)
            GeraDataAviso()
            Exit Sub
        End If

        If txtDataAviso.Date.Month > txtDatVen.Date.AddMonths(-3).Month Or txtDataAviso.Date.Month < txtDatVen.Date.AddMonths(-6).Month Then
            Util.AdicionaJsAlert(MyBase.Page, "Mês Inválido!!" & vbCrLf & "O intervalo de mês válido é do mês " & txtDatVen.Date.AddMonths(-6).Month & " ao mês " & txtDatVen.Date.AddMonths(-3).Month & ".", True)
            GeraDataAviso()
            Exit Sub
        End If
    End Sub
#End Region

#Region " Metodos "

    Private Sub CarregaDDLRessarcimento()
        If Not ddlTipRess.Items.Count > 0 Then
            Util.carregarCmbFormaPagamento(Controller.ObterFormasPagamento(String.Empty, -1), ddlTipRess, New ListItem(String.Empty, String.Empty))
        End If
    End Sub

    Public Sub CarregarDdlTipCttFrn(ByVal CODFRN As Decimal)
        If CODFRN > 0 Then
            Dim ds As wsAcoesComerciais.dataSetDivisaoFornecedor = Controller.ObterDivisaoFornecedor(1, Convert.ToInt32(CODFRN))
            If ds.T0100426.Rows.Count > 0 Then
                ddlTipCttFrn.Items.Clear()
                If ds.T0100426.Item(0).IsTIPIDTEMPASCACOCMCNull OrElse _
                    ds.T0100426.Item(0).TIPIDTEMPASCACOCMC = 0 Then
                    ddlTipCttFrn.Items.Add(New ListItem("Martins", "1"))
                    ddlTipCttFrn.Items.Add(New ListItem("Sourcing", "2"))
                Else
                    ddlTipCttFrn.Items.Add(New ListItem("Farma", "3"))
                End If
            End If
        Else
            ddlTipCttFrn.Items.Clear()
        End If
    End Sub

    Private Sub CarregaControles()

        If Not ddlProPer.Items.Count > 0 Then
            ddlProPer.Items.Clear()
            For Each dr As wsAcoesComerciais.DatasetTipoPeriodo.T0124970Row _
                            In Controller.ObterTiposPeriodo(String.Empty, Decimal.Zero).T0124970.Rows
                ddlProPer.Items.Add(New ListItem(dr.DESPODCTTFRN.Trim(), String.Concat(dr.TIPPODCTTFRN.ToString(), ";", dr.QDEMESREFPOD.ToString())))
            Next
        End If

        Dim item As ListItem
        item = ddlProPer.Items.FindByText("ANUAL")
        If Not ddlProPer.Items.FindByValue(item.Value) Is Nothing Then
            ddlProPer.SelectedValue = item.Value
        End If
        Me.CarregaDDLRessarcimento()
    End Sub

    Public Function Validar() As Boolean
        Dim result As Boolean
        Dim mensagemErro As String = String.Empty
        Dim deuFoco As Boolean

        Try
            'Data de vigoração
            If txtDatIniPodVgrCttFrn.Text Is String.Empty Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "data de vigoração inválida."
                'Foco
                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page(), CType(txtDatIniPodVgrCttFrn, WebControl))
                    deuFoco = True
                End If
                'Indicador erro
                lblErrotxtDatIniPodVgrCttFrn.Visible = True
            Else
                lblErrotxtDatIniPodVgrCttFrn.Visible = False
            End If

            'Periodicidade
            If ddlProPer.SelectedValue.Equals(String.Empty) Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "é obrigatório definir a periodicidade"
                'Foco
                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page(), CType(txtDatIniPodVgrCttFrn, WebControl))
                    deuFoco = True
                End If
                'Indicador erro
                lblErroddlProPer.Visible = True
            ElseIf Convert.ToInt32(ddlProPer.SelectedValue.Split(";"c).GetValue(1)) = 0 Then
                'Mensagem
                If mensagemErro.Length > 0 Then mensagemErro &= ", "
                mensagemErro &= "é obrigatório definir a periodicidade"
                'Foco
                If Not deuFoco Then
                    Util.AdicionaJsFocus(MyBase.Page(), CType(txtDatIniPodVgrCttFrn, WebControl))
                    deuFoco = True
                End If
                'Indicador erro
                lblErroddlProPer.Visible = True
            Else
                lblErroddlProPer.Visible = False
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
            If dr.RowState = DataRowState.Added Then
                .DATCADCTTFRN = Date.Now
                ' NA PROC DO LEGADO: spCLJ035, INSERE 0 
                .QDEMESAPUPODVGRCTT = Decimal.Zero
                ' NA PROC DO LEGADO: spCLJ035, INSERE 0 
                .QDEPGCEFTCTTFRN = 0
                ' NA PROC DO LEGADO: spCLJ035, INSERE nulo 
                .SetDATDSTCTTFRNNull()
                ' NA PROC DO LEGADO: spCLJ035, INSERE vazio
                .FLGFIMCTTFRN = String.Empty
                ' NA PROC DO LEGADO: spCLJ035, INSERE nulo 
                .SetNUMNVOCTTFRNNull()
                ' NA PROC DO LEGADO: spCLJ035, INSERE 0 
                .TIPUTZALCVBAFRN = Decimal.Zero

                .DATVNCCTTFRN = Me.DATVNCCTTFRN
                .TIPPODCTTFRN = Convert.ToDecimal(ddlProPer.SelectedValue.Split(";"c).GetValue(0))
                txtDatVen.Date = .DATVNCCTTFRN

               
            End If

            .DATINIPODVGRCTTFRN = txtDatIniPodVgrCttFrn.Date
            .FLGPGCAUTCTTFRN = Convert.ToString(IIf(chkPrgVen.Checked, "*", String.Empty))
            .FLGAPUCRSREFPODANT = Convert.ToString(IIf(chkPerApu.Checked, "*", String.Empty))
            .TIPCTTFRN = Convert.ToDecimal(ddlTipCttFrn.SelectedValue)
            .QDEITECTLFRN = txtQtdIteCtlFrn.ValueDecimal
            .INDAPUPISCTTFRN = Convert.ToDecimal(chkIndApuPisCttFrn.Checked)
            .INDAPUPISNCMCTTFRN = Convert.ToDecimal(chkIndApuPisNcmCttFrn.Checked)
            .INDDSCCMCPETCTTFRN = Convert.ToDecimal(ddlIndDscCmcPet.SelectedValue)
            .DESOBSDSCCMCPET = txtDesObsDescCmcPet.Text.Trim()
            .DESLNHPRDCTTFRN = txtDesLnhPrdCttFrn.Text.Trim()
            .NUMDIAVNCPRDCTTFRN = txtPrzProVec.ValueDecimal
            .INDTRCMERCTTFRN = Convert.ToDecimal(ddlAceTrc.SelectedValue)
            If Not ddlTipRess.SelectedValue Is String.Empty Then .TIPFRMDSCDVLMER = Convert.ToDecimal(ddlTipRess.SelectedValue)
            .TIPFRTDVLMER = ddlTipFreDev.SelectedValue
            .DESOBSDVLMER = txtDesObsDvlMer.Text

            'TODO: DENIS COMENTADO PORQUE TAVA DANDO ERRO
            'Data Aviso Renovacao Acordo de Fornecimento
            'If chkAvisoRenovacao.Checked Then
            '    .DATALAPGCCTTFRN = txtDataAviso.Date
            'Else
            '    .SetDATALAPGCCTTFRNNull()
            'End If

        End With
    End Sub

    Public Sub PreencheControles(ByRef ds As wsAcoesComerciais.DatasetContrato)
        Dim dr As wsAcoesComerciais.DatasetContrato.T0124945Row

        CarregaDDLRessarcimento()

        If ds.T0124945.Rows.Count > 0 Then
            dr = ds.T0124945(0)
        End If

        With dr
            'txtNroCnt.Text = dr.NUMCTTFRN.ToString()
            txtDatIniPodVgrCttFrn.Date = .DATINIPODVGRCTTFRN
            If Not .IsNull("DATVNCCTTFRN") Then txtDatVen.Date = .DATVNCCTTFRN
            If Not .IsDATDSTCTTFRNNull Then txtDatDstCttFrn.Date = .DATDSTCTTFRN

            For Each lst As ListItem In ddlProPer.Items
                If Not dr.IsNull("TIPPODCTTFRN") Then
                    If Convert.ToString(lst.Value.Split(";"c).GetValue(0)) = .TIPPODCTTFRN.ToString() Then
                        'ddlProPer.Items.Item(ddlProPer.Items.IndexOf(lst)).Selected = True
                        lst.Selected = True
                        Exit For
                    End If
                End If
            Next
            chkPrgVen.Checked = Convert.ToBoolean(IIf(.FLGPGCAUTCTTFRN.Equals("*"), True, False))

            'ucFornecedor.SelecionarFornecedor(.CODFRN)
            chkPerApu.Checked = Convert.ToBoolean(IIf(Not .IsFLGAPUCRSREFPODANTNull AndAlso .FLGAPUCRSREFPODANT.Equals("*"), True, False))
            If Not .IsTIPCTTFRNNull Then
                If Not ddlTipCttFrn.Items.FindByValue(.TIPCTTFRN.ToString()) Is Nothing Then
                    ddlTipCttFrn.SelectedValue = .TIPCTTFRN.ToString()
                End If
            End If

            If Not .IsQDEITECTLFRNNull Then txtQtdIteCtlFrn.ValueDecimal = .QDEITECTLFRN
            If Not .IsINDAPUPISCTTFRNNull Then chkIndApuPisCttFrn.Checked = Convert.ToBoolean(.INDAPUPISCTTFRN)
            If Not .IsINDAPUPISNCMCTTFRNNull Then chkIndApuPisNcmCttFrn.Checked = Convert.ToBoolean(.INDAPUPISNCMCTTFRN)

            ' clj001Y tab Geral
            If Not .IsINDDSCCMCPETCTTFRNNull Then ddlIndDscCmcPet.SelectedValue = .INDDSCCMCPETCTTFRN.ToString()
            If Not .IsDESOBSDSCCMCPETNull Then txtDesObsDescCmcPet.Text = .DESOBSDSCCMCPET
            If Not .IsDESLNHPRDCTTFRNNull Then txtDesLnhPrdCttFrn.Text = .DESLNHPRDCTTFRN
            If Not .IsNUMDIAVNCPRDCTTFRNNull Then txtPrzProVec.ValueDecimal = .NUMDIAVNCPRDCTTFRN
            If Not .IsINDTRCMERCTTFRNNull Then ddlAceTrc.SelectedValue = .INDTRCMERCTTFRN.ToString()
            If Not .IsTIPFRMDSCDVLMERNull Then ddlTipRess.SelectedValue = .TIPFRMDSCDVLMER.ToString()

            Try
                If Not .IsTIPFRTDVLMERNull Then ddlTipFreDev.SelectedValue = .TIPFRTDVLMER.ToString()
            Catch ex As Exception
                ddlTipFreDev.SelectedValue = String.Empty
            End Try

            If Not .IsDESOBSDVLMERNull Then txtDesObsDvlMer.Text = .DESOBSDVLMER

            'Verifica se existe apuração, se existir não permite editar a data de inicio
            If Page.existeApuracaoParaEsseContrato Then
                txtDatIniPodVgrCttFrn.Enabled = False
                txtDataAviso.Enabled = False
            Else
                txtDatIniPodVgrCttFrn.Enabled = True
                txtDataAviso.Enabled = True
            End If

            'Data Aviso Renovacao Acordo de Fornecimento
            'If Not .IsDATALAPGCCTTFRNNull Then
            '    chkAvisoRenovacao.Checked = True
            '    TRDataAviso.Visible = True
            '    txtDataAviso.Date = .DATALAPGCCTTFRN
            'Else
            '    chkAvisoRenovacao.Checked = False
            '    TRDataAviso.Visible = False
            'End If
        End With
    End Sub

    Private Sub GeraDataAviso()
        Dim diaAviso As Integer
        Dim mesAviso As Integer
        Dim anoAviso As Integer

        If txtDatVen.Text <> String.Empty Then
            diaAviso = txtDatVen.Date.Day
            mesAviso = txtDatVen.Date.AddMonths(-3).Month
            anoAviso = txtDatVen.Date.AddMonths(-3).Year

            txtDataAviso.Date = CDate(diaAviso.ToString & "/" & mesAviso.ToString & "/" & anoAviso.ToString)

        End If
    End Sub

#End Region

End Class