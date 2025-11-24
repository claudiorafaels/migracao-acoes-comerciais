Public Class ucGrupoEconomico
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtCodigoGrupoEconomico As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescricaoGrupoEconomico As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents cmbDescricaoGrupoEconomico As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblGrupoEconomico As System.Web.UI.WebControls.Label
    Protected WithEvents btnBuscarGrupoEconomico As System.Web.UI.WebControls.ImageButton

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

    Public Event GrupoEconomicoAlterado(ByVal e As ListItem)

    Public Property CodGrupoEconomico() As Decimal
        Get
            If cmbDescricaoGrupoEconomico.Items.Count > 0 Then
                If IsNumeric(cmbDescricaoGrupoEconomico.SelectedValue) Then
                    Return CType(txtCodigoGrupoEconomico.Text, Decimal)
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
            If Not cmbDescricaoGrupoEconomico.Items.FindByValue(Value.ToString()) Is Nothing Then
                cmbDescricaoGrupoEconomico.SelectedValue = Value.ToString()
            End If
        End Set
    End Property

    Public ReadOnly Property NomGrupoEconomico() As String
        Get
            If Me.CodGrupoEconomico > 0 Then
                Return cmbDescricaoGrupoEconomico.SelectedItem.ToString.Trim
            Else
                Return String.Empty
            End If
        End Get
    End Property

    Public WriteOnly Property Enabled() As Boolean
        Set(ByVal Value As Boolean)
            Util.HabilitaControles(New WebControl() {txtCodigoGrupoEconomico, txtDescricaoGrupoEconomico, cmbDescricaoGrupoEconomico, btnBuscarGrupoEconomico}, Value)
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
            If lblGrupoEconomico.Text.ToUpper.Trim = "GrupoEconomico DESATIVADA" Then
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
            Me.txtCodigoGrupoEconomico.Width = widthCodigo
            Me.txtDescricaoGrupoEconomico.Width = widthNome
        End If
    End Sub

    Private Sub cmbDescricaoGrupoEconomico_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDescricaoGrupoEconomico.SelectedIndexChanged
        lblGrupoEconomico.Text = ""
        With cmbDescricaoGrupoEconomico
            txtCodigoGrupoEconomico.Text = .SelectedValue
            Dim datasetGrupoEconomico As wsAcoesComerciais.DatasetTipoGrupoMarketing = Controller.ObterGrupoEconomicoPorChave(1, 1, CType(.SelectedValue, Decimal))
            'If datasetGrupoEconomico.T0107579.Rows.Count > 0 Then
            '    lblGrupoEconomico.Text = observacaoGrupoEconomico(datasetGrupoEconomico.T0107579(0))
            'End If
            RaiseEvent GrupoEconomicoAlterado(.SelectedItem)
        End With
        Util.AdicionaJsFocus(Me.Page, cmbDescricaoGrupoEconomico)
    End Sub

    Private Sub txtCodigoGrupoEconomico_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoGrupoEconomico.TextChanged
        lblGrupoEconomico.Text = ""
        txtDescricaoGrupoEconomico.Text = String.Empty
        If Not IsNumeric(txtCodigoGrupoEconomico.Text) Then
            Util.AdicionaJsAlert(Me.Page, "Código do Grupo Econômico inválido", True)
            cmbDescricaoGrupoEconomico.Items.Clear()
            txtCodigoGrupoEconomico.Text = String.Empty
            Util.AdicionaJsFocus(Me.Page, txtCodigoGrupoEconomico)
            RaiseEvent GrupoEconomicoAlterado(Nothing)
            Exit Sub
        End If
        Me.Codigo_ValueChange(New WebControl() {txtCodigoGrupoEconomico, txtDescricaoGrupoEconomico, cmbDescricaoGrupoEconomico})
        If txtCodigoGrupoEconomico.Text = String.Empty Then
            cmbDescricaoGrupoEconomico.Items.Clear()
        End If
        Util.AdicionaJsFocus(Me.Page, cmbDescricaoGrupoEconomico)
    End Sub

    Private Sub btnBuscarGrupoEconomico_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscarGrupoEconomico.Click
        lblGrupoEconomico.Text = ""
        txtCodigoGrupoEconomico.Text = String.Empty
        cmbDescricaoGrupoEconomico.Items.Clear()
        Me.BuscarGrupoEconomico_Click(New WebControl() {txtCodigoGrupoEconomico, txtDescricaoGrupoEconomico, cmbDescricaoGrupoEconomico})
    End Sub
#End Region

#Region "Métodos"

    Public Sub setFocus()
        Util.AdicionaJsFocus(Me.Page, txtCodigoGrupoEconomico)
    End Sub

    Private Sub BuscarGrupoEconomico_Click(ByVal Ctrls As WebControl())
        Dim flagMostrarCombo As Boolean = False

        ' 0 = campo de codigo 
        ' 1 = txt nome GrupoEconomico 
        ' 2 = ddl GrupoEconomico 

        If Ctrls(1).Visible Then
            If CType(Ctrls(1), Infragistics.WebUI.WebDataInput.WebTextEdit).Text.Trim.Length < 3 Then
                lblGrupoEconomico.Text = ""
                Page.RegisterStartupScript("Alerta", "<script>alert('É obrigatório digitar no mínimo 3 caracteres do nome antes de pesquisar.');</script>")
                Exit Sub
            End If

            Dim datasetGrupoEconomico As wsAcoesComerciais.DatasetTipoGrupoMarketing = Controller.ObterGrupoEconomicoPorAtributo(1, 1, 0, txtDescricaoGrupoEconomico.Text, String.Empty, Nothing, Nothing, 0, 0)

            If datasetGrupoEconomico.T0107579.Rows.Count > 0 Then
                'lblGrupoEconomico.Text = observacaoGrupoEconomico(datasetGrupoEconomico.T0107579(0))
                carregarCombo(datasetGrupoEconomico, cmbDescricaoGrupoEconomico, Nothing)
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
                RaiseEvent GrupoEconomicoAlterado(CType(Ctrls(2), DropDownList).SelectedItem)
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

        If cmbDescricaoGrupoEconomico.Visible Then
            Util.AdicionaJsFocus(Me.Page, cmbDescricaoGrupoEconomico)
        ElseIf txtDescricaoGrupoEconomico.Visible Then
            Util.AdicionaJsFocus(Me.Page, txtDescricaoGrupoEconomico)
        End If

    End Sub

    Private Sub Codigo_ValueChange(ByVal Ctrls As WebControl())
        Dim flagMostrarCombo As Boolean = False

        If Not (IsNumeric(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text)) Then Exit Sub

        Dim datasetGrupoEconomico As wsAcoesComerciais.DatasetTipoGrupoMarketing = _
            Controller.ObterGrupoEconomicoPorChave(1, 1, CType(Me.txtCodigoGrupoEconomico.Text, Decimal))


        If datasetGrupoEconomico.T0107579.Rows.Count > 0 Then
            'lblGrupoEconomico.Text = observacaoGrupoEconomico(datasetGrupoEconomico.T0107579(0))
            flagMostrarCombo = True
            With CType(Ctrls(2), DropDownList)
                carregarCombo(datasetGrupoEconomico, CType(Ctrls(2), DropDownList), Nothing)
                cmbDescricaoGrupoEconomico_SelectedIndexChanged(Nothing, Nothing)
            End With
            ' hipotese para todos os GrupoEconomicos
        ElseIf CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text.Equals("0") Then
            CType(Ctrls(2), DropDownList).Items.Clear()
            CType(Ctrls(2), DropDownList).Items.Add(New ListItem(" Todos ", "0"))
            cmbDescricaoGrupoEconomico_SelectedIndexChanged(Nothing, Nothing)
        Else
            CType(Ctrls(2), DropDownList).Items.Clear()
            txtDescricaoGrupoEconomico.Text = String.Empty

            If IsNumeric(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text) Then
                If Convert.ToDecimal(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text) > 0 Then
                    txtCodigoGrupoEconomico.Text = String.Empty
                    Util.AdicionaJsAlert(Me.Page, "Código de GrupoEconomico inválido", True)
                End If
            End If

            'RaiseEvent GrupoEconomicoAlterado(New ListItem("NÃO ENCONTRADO", CLng(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text).ToString))
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
        Util.HabilitaControles(New WebControl() {txtCodigoGrupoEconomico, txtDescricaoGrupoEconomico, cmbDescricaoGrupoEconomico, btnBuscarGrupoEconomico}, True)
        Util.LimpaControles(New WebControl() {txtCodigoGrupoEconomico, txtDescricaoGrupoEconomico, cmbDescricaoGrupoEconomico})
        cmbDescricaoGrupoEconomico.Visible = False
        txtDescricaoGrupoEconomico.Visible = True
    End Sub

    Public Sub SelecionarGrupoEconomico(ByVal codGrupoEconomico As Decimal)
        Me.ReinicializaControle()
        txtCodigoGrupoEconomico.Text = codGrupoEconomico.ToString
        txtCodigoGrupoEconomico_TextChanged(Nothing, Nothing)
    End Sub

    Public Sub SelecionarVazio()
        txtCodigoGrupoEconomico.Text = String.Empty
        cmbDescricaoGrupoEconomico.Items.Clear()
        lblGrupoEconomico.Visible = False
    End Sub

    Public Sub PesquisarGrupoEconomico(ByVal NomeGrupoEconomico As String)
        Me.ReinicializaControle()
        txtDescricaoGrupoEconomico.Text = NomeGrupoEconomico.Trim()
        btnBuscarGrupoEconomico_Click(Nothing, Nothing)
    End Sub

    Private Sub carregarCombo(ByRef ds As wsAcoesComerciais.DatasetTipoGrupoMarketing, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetTipoGrupoMarketing.T0107579Row In ds.T0107579.Select("", "NOMGRPFRN")
                .Items.Add(New ListItem(linha.CODGRPFRN.ToString & " - " & linha.NOMGRPFRN, linha.CODGRPFRN.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

#End Region


End Class