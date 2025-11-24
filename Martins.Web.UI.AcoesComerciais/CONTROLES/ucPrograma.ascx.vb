Public Class ucPrograma
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtCODPRGICT As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNOMPRGICT As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents cmbNOMPRGICT As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblPrograma As System.Web.UI.WebControls.Label
    Protected WithEvents btnBuscarPrograma As System.Web.UI.WebControls.ImageButton

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

    Public Event ProgramaAlterado(ByVal e As ListItem)

    Public Property CodPrograma() As Decimal
        Get
            If cmbNOMPRGICT.Items.Count > 0 Then
                If IsNumeric(cmbNOMPRGICT.SelectedValue) Then
                    Return CType(txtCODPRGICT.Text, Decimal)
                Else
                    Return 0
                End If
            Else
                Return 0 '-1 (se precisar retornar -1 avisar para Marcos alterar relatórios)
            End If
        End Get
        Set(ByVal Value As Decimal)
            'If ComboFoiCarregado() = False Then
            'carregarCombo()
            'End If
            If Not cmbNOMPRGICT.Items.FindByValue(Value.ToString()) Is Nothing Then
                cmbNOMPRGICT.SelectedValue = Value.ToString()
            End If
        End Set
    End Property

    Public ReadOnly Property NomPrograma() As String
        Get
            If Me.CodPrograma > 0 Then
                Return cmbNOMPRGICT.SelectedItem.ToString.Trim
            Else
                Return String.Empty
            End If
        End Get
    End Property

    Public WriteOnly Property Enabled() As Boolean
        Set(ByVal Value As Boolean)
            Util.HabilitaControles(New WebControl() {txtCODPRGICT, txtNOMPRGICT, cmbNOMPRGICT, btnBuscarPrograma}, Value)
        End Set
    End Property

    Public Property SelecionarAposBusca() As Boolean
        Get
            If Not Me.ViewState.Item("SelecionarAposBusca") Is Nothing Then
                Return DirectCast(Me.ViewState.Item("SelecionarAposBusca"), Boolean)
            Else
                Return True
            End If
        End Get
        Set(ByVal Value As Boolean)
            Me.ViewState("SelecionarAposBusca") = Value
        End Set
    End Property

    Public Property widthCodigo() As System.Web.UI.WebControls.Unit
        Get
            If Not Me.ViewState.Item("widthCodigo") Is Nothing Then
                Return DirectCast(Me.ViewState.Item("widthCodigo"), System.Web.UI.WebControls.Unit)
            Else
                Return System.Web.UI.WebControls.Unit.Parse("60")
            End If
        End Get
        Set(ByVal Value As System.Web.UI.WebControls.Unit)
            Me.ViewState("widthCodigo") = Value
        End Set
    End Property

    Public Property widthNome() As System.Web.UI.WebControls.Unit
        Get
            If Not Me.ViewState.Item("widthNome") Is Nothing Then
                Return DirectCast(Me.ViewState.Item("widthNome"), System.Web.UI.WebControls.Unit)
            Else
                Return System.Web.UI.WebControls.Unit.Parse("280")
            End If
        End Get
        Set(ByVal Value As System.Web.UI.WebControls.Unit)
            Me.ViewState("widthNome") = Value
        End Set
    End Property

    Public ReadOnly Property Desativada() As Boolean
        Get
            If lblPrograma.Text.ToUpper.Trim = "Programa DESATIVADA" Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
#End Region

#Region "Eventos"

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IsPostBack Then
            Me.txtCODPRGICT.Width = widthCodigo
            Me.txtNOMPRGICT.Width = widthNome
        End If
    End Sub

    Private Sub cmbNOMPRGICT_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNOMPRGICT.SelectedIndexChanged
        lblPrograma.Text = ""
        With cmbNOMPRGICT
            txtCODPRGICT.Text = .SelectedValue
            Dim DatasetIncentivo As wsAcoesComerciais.DatasetIncentivo = Controller.ObterIncentivoPorChave(CType(txtCODPRGICT.Text, Decimal))
            'If DatasetIncentivo.T0100426.Rows.Count > 0 Then
            '    lblPrograma.Text = observacaoPrograma(DatasetIncentivo.T0100426(0))
            'End If
            RaiseEvent ProgramaAlterado(.SelectedItem)
        End With
        Util.AdicionaJsFocus(Me.Page, cmbNOMPRGICT)
    End Sub

    Private Sub txtCODPRGICT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCODPRGICT.TextChanged
        lblPrograma.Text = ""
        txtNOMPRGICT.Text = String.Empty
        If Not IsNumeric(txtCODPRGICT.Text) Then
            Util.AdicionaJsAlert(Me.Page, "Código do Programa inválido", True)
            cmbNOMPRGICT.Items.Clear()
            txtCODPRGICT.Text = String.Empty
            Util.AdicionaJsFocus(Me.Page, txtCODPRGICT)
            RaiseEvent ProgramaAlterado(Nothing)
            Exit Sub
        End If
        Me.Codigo_ValueChange(New WebControl() {txtCODPRGICT, txtNOMPRGICT, cmbNOMPRGICT})
        If txtCODPRGICT.Text = String.Empty Then
            cmbNOMPRGICT.Items.Clear()
        End If
        Util.AdicionaJsFocus(Me.Page, cmbNOMPRGICT)
    End Sub

    Private Sub btnBuscarPrograma_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscarPrograma.Click
        lblPrograma.Text = ""
        txtCODPRGICT.Text = String.Empty
        Me.BuscarPrograma_Click(New WebControl() {txtCODPRGICT, txtNOMPRGICT, cmbNOMPRGICT})
    End Sub
#End Region

#Region "Métodos"

    Public Sub setFocus()
        Util.AdicionaJsFocus(Me.Page, txtCODPRGICT)
    End Sub

    Private Sub BuscarPrograma_Click(ByVal Ctrls As WebControl())
        Dim flagMostrarCombo As Boolean = False

        ' 0 = campo de codigo 
        ' 1 = txt nome Programa 
        ' 2 = ddl Programa 

        If Ctrls(1).Visible Then
            If CType(Ctrls(1), Infragistics.WebUI.WebDataInput.WebTextEdit).Text.Trim.Length < 3 Then
                lblPrograma.Text = ""
                Page.RegisterStartupScript("Alerta", "<script>alert('É obrigatório digitar no mínimo 3 caracteres do nome antes de pesquisar.');</script>")
                Exit Sub
            End If

            Dim DatasetIncentivo As wsAcoesComerciais.DatasetIncentivo = Controller.ObterIncentivoPorAtributo(0, txtNOMPRGICT.Text)

            If DatasetIncentivo.CADPRGICT.Rows.Count > 0 Then
                'lblPrograma.Text = observacaoPrograma(DatasetIncentivo.T0100426(0))
                carregarCombo(DatasetIncentivo, cmbNOMPRGICT, Nothing)
                flagMostrarCombo = True
            End If

            With CType(Ctrls(2), DropDownList)
                .Visible = flagMostrarCombo
                .Enabled = flagMostrarCombo
                If flagMostrarCombo Then
                    .Width = widthNome
                Else
                    .Width = System.Web.UI.WebControls.Unit.Parse("0px")
                End If
            End With
            With Ctrls(1)
                .Visible = Not flagMostrarCombo
                .Enabled = Not flagMostrarCombo
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
                If Not flagMostrarCombo Then
                    .Width = widthNome
                Else
                    .Width = System.Web.UI.WebControls.Unit.Parse("0px")
                End If
            End With
            If SelecionarAposBusca Then
                CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text = CType(Ctrls(2), DropDownList).SelectedValue
                RaiseEvent ProgramaAlterado(CType(Ctrls(2), DropDownList).SelectedItem)
            Else
                CType(Ctrls(2), DropDownList).Items.Insert(0, New ListItem("SELECIONE->", ""))
                CType(Ctrls(2), DropDownList).SelectedValue = ""
                CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text = ""
            End If

        ElseIf Ctrls(2).Visible Then
            With Ctrls(2)
                .Visible = False
                .Enabled = False
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
            End With
            With Ctrls(1)
                .Visible = True
                .Enabled = True
                .Width = widthNome
            End With
        End If

        If cmbNOMPRGICT.Visible Then
            Util.AdicionaJsFocus(Me.Page, cmbNOMPRGICT)
        ElseIf txtNOMPRGICT.Visible Then
            Util.AdicionaJsFocus(Me.Page, txtNOMPRGICT)
        End If

    End Sub

    Private Sub Codigo_ValueChange(ByVal Ctrls As WebControl())
        Dim flagMostrarCombo As Boolean = False

        If Not (IsNumeric(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text)) Then Exit Sub

        Dim DatasetIncentivo As wsAcoesComerciais.DatasetIncentivo = _
            Controller.ObterIncentivoPorChave(CType(txtCODPRGICT.Text, Decimal))


        If DatasetIncentivo.CADPRGICT.Rows.Count > 0 Then
            'lblPrograma.Text = observacaoPrograma(DatasetIncentivo.T0100426(0))
            flagMostrarCombo = True
            With CType(Ctrls(2), DropDownList)
                carregarCombo(DatasetIncentivo, CType(Ctrls(2), DropDownList), Nothing)
                cmbNOMPRGICT_SelectedIndexChanged(Nothing, Nothing)
            End With
            ' hipotese para todos os Programas
        ElseIf CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text.Equals("0") Then
            CType(Ctrls(2), DropDownList).Items.Clear()
            CType(Ctrls(2), DropDownList).Items.Add(New ListItem(" Todos ", "0"))
            cmbNOMPRGICT_SelectedIndexChanged(Nothing, Nothing)
        Else
            CType(Ctrls(2), DropDownList).Items.Clear()
            txtNOMPRGICT.Text = String.Empty

            If IsNumeric(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text) Then
                If Convert.ToDecimal(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text) > 0 Then
                    txtCODPRGICT.Text = String.Empty
                    Util.AdicionaJsAlert(Me.Page, "Código do Programa inválido", True)
                End If
            End If

            'RaiseEvent ProgramaAlterado(New ListItem("NÃO ENCONTRADO", CLng(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text).ToString))
        End If

        With Ctrls(2)
            .Visible = flagMostrarCombo
            .Enabled = flagMostrarCombo
            If flagMostrarCombo Then
                .Width = widthNome
            Else
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
            End If
        End With
        With Ctrls(1)
            .Visible = Not flagMostrarCombo
            .Enabled = Not flagMostrarCombo
            If Not flagMostrarCombo Then
                .Width = widthNome
            Else
                .Width = System.Web.UI.WebControls.Unit.Parse("0px")
            End If
        End With
    End Sub

    Public Sub ReinicializaControle()
        Util.HabilitaControles(New WebControl() {txtCODPRGICT, txtNOMPRGICT, cmbNOMPRGICT, btnBuscarPrograma}, True)
        Util.LimpaControles(New WebControl() {txtCODPRGICT, txtNOMPRGICT, cmbNOMPRGICT})
        cmbNOMPRGICT.Visible = False
        txtNOMPRGICT.Visible = True
    End Sub

    Public Sub SelecionarPrograma(ByVal codPrograma As Decimal)
        Me.ReinicializaControle()
        txtCODPRGICT.Text = codPrograma.ToString
        txtCODPRGICT_TextChanged(Nothing, Nothing)
    End Sub

    Public Sub SelecionarVazio()
        txtCODPRGICT.Text = String.Empty
        cmbNOMPRGICT.Items.Clear()
        lblPrograma.Visible = False
    End Sub

    Public Sub PesquisarPrograma(ByVal NomePrograma As String)
        Me.ReinicializaControle()
        txtNOMPRGICT.Text = NomePrograma.Trim()
        btnBuscarPrograma_Click(Nothing, Nothing)
    End Sub

    Private Sub carregarCombo(ByRef ds As wsAcoesComerciais.DatasetIncentivo, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetIncentivo.CADPRGICTRow In ds.CADPRGICT.Select("", "NOMPRGICT")
                .Items.Add(New ListItem(linha.CODPRGICT.ToString & " - " & linha.NOMPRGICT, linha.CODPRGICT.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

#End Region


End Class