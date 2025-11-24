Public Class ucGrupoMarketing
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnBuscarGrupoEconomico As System.Web.UI.WebControls.ImageButton
    Protected WithEvents txtTipoGrupoMarketing As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescricaoGrupoMarketing As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents cmbDescricaoGrupoMarketing As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblGrupoMarketing As System.Web.UI.WebControls.Label

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

    Public Event GrupoMarketingAlterado(ByVal e As ListItem)

    Public Property CodGrupoMarketing() As Decimal
        Get
            If cmbDescricaoGrupoMarketing.Items.Count > 0 Then
                If IsNumeric(cmbDescricaoGrupoMarketing.SelectedValue) Then
                    Return CType(txtTipoGrupoMarketing.Text, Decimal)
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
            If Not cmbDescricaoGrupoMarketing.Items.FindByValue(Value.ToString()) Is Nothing Then
                cmbDescricaoGrupoMarketing.SelectedValue = Value.ToString()
            End If
        End Set
    End Property

    Public ReadOnly Property NomGrupoMarketing() As String
        Get
            If Me.CodGrupoMarketing > 0 Then
                Return cmbDescricaoGrupoMarketing.SelectedItem.ToString.Trim
            Else
                Return String.Empty
            End If
        End Get
    End Property

    Public WriteOnly Property Enabled() As Boolean
        Set(ByVal Value As Boolean)
            Util.HabilitaControles(New WebControl() {txtTipoGrupoMarketing, txtDescricaoGrupoMarketing, cmbDescricaoGrupoMarketing, btnBuscarGrupoEconomico}, Value)
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
            If lblGrupoMarketing.Text.ToUpper.Trim = "GrupoMarketing DESATIVADA" Then
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
            Me.txtTipoGrupoMarketing.Width = widthCodigo
            Me.txtDescricaoGrupoMarketing.Width = widthNome
        End If
    End Sub

    Private Sub cmbDescricaoGrupoMarketing_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDescricaoGrupoMarketing.SelectedIndexChanged
        lblGrupoMarketing.Text = ""
        With cmbDescricaoGrupoMarketing
            txtTipoGrupoMarketing.Text = .SelectedValue
            Dim datasetGrupoEconomico As wsAcoesComerciais.DatasetTipoGrupoMarketing = Controller.ObterTipoGrupoMarketingPorChave(CType(txtTipoGrupoMarketing.Text, Decimal))
            'If datasetGrupoEconomico.CADTIPGRPMKTFRN.Rows.Count > 0 Then
            '    lblGrupoMarketing.Text = observacaoGrupoMarketing(datasetGrupoEconomico.CADTIPGRPMKTFRN(0))
            'End If
            RaiseEvent GrupoMarketingAlterado(.SelectedItem)
        End With
        Util.AdicionaJsFocus(Me.Page, cmbDescricaoGrupoMarketing)
    End Sub

    Private Sub txtTipoGrupoMarketing_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTipoGrupoMarketing.TextChanged
        lblGrupoMarketing.Text = ""
        txtDescricaoGrupoMarketing.Text = String.Empty
        If Not IsNumeric(txtTipoGrupoMarketing.Text) Then
            Util.AdicionaJsAlert(Me.Page, "Código do Grupo Marketing inválido", True)
            cmbDescricaoGrupoMarketing.Items.Clear()
            txtTipoGrupoMarketing.Text = String.Empty
            Util.AdicionaJsFocus(Me.Page, txtTipoGrupoMarketing)
            RaiseEvent GrupoMarketingAlterado(Nothing)
            Exit Sub
        End If
        Me.Codigo_ValueChange(New WebControl() {txtTipoGrupoMarketing, txtDescricaoGrupoMarketing, cmbDescricaoGrupoMarketing})
        If txtTipoGrupoMarketing.Text = String.Empty Then
            cmbDescricaoGrupoMarketing.Items.Clear()
        End If
        Util.AdicionaJsFocus(Me.Page, cmbDescricaoGrupoMarketing)
    End Sub

    Private Sub btnBuscarGrupoEconomico_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscarGrupoEconomico.Click
        lblGrupoMarketing.Text = ""
        txtTipoGrupoMarketing.Text = String.Empty
        cmbDescricaoGrupoMarketing.Items.Clear()
        Me.BuscarGrupoMarketing_Click(New WebControl() {txtTipoGrupoMarketing, txtDescricaoGrupoMarketing, cmbDescricaoGrupoMarketing})
    End Sub
#End Region

#Region "Métodos"

    Public Sub setFocus()
        Util.AdicionaJsFocus(Me.Page, txtTipoGrupoMarketing)
    End Sub

    Private Sub BuscarGrupoMarketing_Click(ByVal Ctrls As WebControl())
        Dim flagMostrarCombo As Boolean = False

        ' 0 = campo de codigo 
        ' 1 = txt nome GrupoMarketing 
        ' 2 = ddl GrupoMarketing 

        If Ctrls(1).Visible Then
            If CType(Ctrls(1), Infragistics.WebUI.WebDataInput.WebTextEdit).Text.Trim.Length < 3 Then
                lblGrupoMarketing.Text = ""
                Page.RegisterStartupScript("Alerta", "<script>alert('É obrigatório digitar no mínimo 3 caracteres do nome antes de pesquisar.');</script>")
                Exit Sub
            End If

            Dim datasetGrupoEconomico As wsAcoesComerciais.DatasetTipoGrupoMarketing = Controller.ObterTipoGrupoMarketingPorAtributo(0, txtDescricaoGrupoMarketing.Text)

            If datasetGrupoEconomico.CADTIPGRPMKTFRN.Rows.Count > 0 Then
                'lblGrupoMarketing.Text = observacaoGrupoMarketing(datasetGrupoEconomico.CADTIPGRPMKTFRN(0))
                carregarCombo(datasetGrupoEconomico, cmbDescricaoGrupoMarketing, Nothing)
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
                RaiseEvent GrupoMarketingAlterado(CType(Ctrls(2), DropDownList).SelectedItem)
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

        If cmbDescricaoGrupoMarketing.Visible Then
            Util.AdicionaJsFocus(Me.Page, cmbDescricaoGrupoMarketing)
        ElseIf txtDescricaoGrupoMarketing.Visible Then
            Util.AdicionaJsFocus(Me.Page, txtDescricaoGrupoMarketing)
        End If

    End Sub

    Private Sub Codigo_ValueChange(ByVal Ctrls As WebControl())
        Dim flagMostrarCombo As Boolean = False

        If Not (IsNumeric(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text)) Then Exit Sub

        Dim datasetGrupoEconomico As wsAcoesComerciais.DatasetTipoGrupoMarketing = _
            Controller.ObterTipoGrupoMarketingPorChave(CType(txtTipoGrupoMarketing.Text, Decimal))


        If datasetGrupoEconomico.CADTIPGRPMKTFRN.Rows.Count > 0 Then
            'lblGrupoMarketing.Text = observacaoGrupoMarketing(datasetGrupoEconomico.CADTIPGRPMKTFRN(0))
            flagMostrarCombo = True
            With CType(Ctrls(2), DropDownList)
                carregarCombo(datasetGrupoEconomico, CType(Ctrls(2), DropDownList), Nothing)
                cmbDescricaoGrupoMarketing_SelectedIndexChanged(Nothing, Nothing)
            End With
            ' hipotese para todos os GrupoMarketings
        ElseIf CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text.Equals("0") Then
            CType(Ctrls(2), DropDownList).Items.Clear()
            CType(Ctrls(2), DropDownList).Items.Add(New ListItem(" Todos ", "0"))
            cmbDescricaoGrupoMarketing_SelectedIndexChanged(Nothing, Nothing)
        Else
            CType(Ctrls(2), DropDownList).Items.Clear()
            txtDescricaoGrupoMarketing.Text = String.Empty

            If IsNumeric(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text) Then
                If Convert.ToDecimal(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text) > 0 Then
                    txtTipoGrupoMarketing.Text = String.Empty
                    Util.AdicionaJsAlert(Me.Page, "Código do Grupo Marketing inválido", True)
                End If
            End If

            'RaiseEvent GrupoMarketingAlterado(New ListItem("NÃO ENCONTRADO", CLng(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text).ToString))
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
        Util.HabilitaControles(New WebControl() {txtTipoGrupoMarketing, txtDescricaoGrupoMarketing, cmbDescricaoGrupoMarketing, btnBuscarGrupoEconomico}, True)
        Util.LimpaControles(New WebControl() {txtTipoGrupoMarketing, txtDescricaoGrupoMarketing, cmbDescricaoGrupoMarketing})
        cmbDescricaoGrupoMarketing.Visible = False
        txtDescricaoGrupoMarketing.Visible = True
    End Sub

    Public Sub SelecionarGrupoMarketing(ByVal codGrupoMarketing As Decimal)
        Me.ReinicializaControle()
        txtTipoGrupoMarketing.Text = codGrupoMarketing.ToString
        txtTipoGrupoMarketing_TextChanged(Nothing, Nothing)
    End Sub

    Public Sub SelecionarVazio()
        txtTipoGrupoMarketing.Text = String.Empty
        cmbDescricaoGrupoMarketing.Items.Clear()
        lblGrupoMarketing.Visible = False
    End Sub

    Public Sub PesquisarGrupoMarketing(ByVal NomeGrupoMarketing As String)
        Me.ReinicializaControle()
        txtDescricaoGrupoMarketing.Text = NomeGrupoMarketing.Trim()
        btnBuscarGrupoEconomico_Click(Nothing, Nothing)
    End Sub

    Private Sub carregarCombo(ByRef ds As wsAcoesComerciais.DatasetTipoGrupoMarketing, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetTipoGrupoMarketing.CADTIPGRPMKTFRNRow In ds.CADTIPGRPMKTFRN.Select("", "DESGRPMKTFRN")
                .Items.Add(New ListItem(linha.TIPGRPMKTFRN.ToString & " - " & linha.DESGRPMKTFRN, linha.TIPGRPMKTFRN.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

#End Region

End Class