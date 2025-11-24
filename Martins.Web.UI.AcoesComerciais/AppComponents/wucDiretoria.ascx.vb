Public Class wucDiretoria
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtDiretoria As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNomeDiretoria As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents cmbNomeDiretoria As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnBuscarDiretoria As System.Web.UI.WebControls.ImageButton

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

    Public Event DiretoriaAlterado(ByVal e As ListItem)

    Public Property CodDiretoria() As Decimal
        Get
            If cmbNomeDiretoria.Items.Count > 0 Then
                If IsNumeric(cmbNomeDiretoria.SelectedValue) Then
                    Return CType(txtDiretoria.Text, Decimal)
                Else
                    Return 0
                End If
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Decimal)
            If Not cmbNomeDiretoria.Items.FindByValue(Value.ToString()) Is Nothing Then
                cmbNomeDiretoria.SelectedValue = Value.ToString()
            End If
        End Set
    End Property

    Public ReadOnly Property NomDiretoria() As String
        Get
            If cmbNomeDiretoria.Items.Count > 0 Then
                Return cmbNomeDiretoria.SelectedItem.ToString.Trim
            Else
                Return String.Empty
            End If
        End Get
    End Property

    Public WriteOnly Property Enabled() As Boolean
        Set(ByVal Value As Boolean)
            Util.HabilitaControles(New WebControl() {txtDiretoria, txtNomeDiretoria, cmbNomeDiretoria, btnBuscarDiretoria}, Value)
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

#End Region

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IsPostBack Then
            Me.txtDiretoria.Width = widthCodigo
            Me.txtNomeDiretoria.Width = widthNome
        End If
    End Sub

    Private Sub BuscarDiretoria_Click(ByVal Ctrls As WebControl())
        Dim flagMostrarCombo As Boolean = False

        ' 0 = campo de codigo 
        ' 1 = txt Diretoria 
        ' 2 = ddl Diretoria

        If Ctrls(1).Visible Then
            If CType(Ctrls(1), Infragistics.WebUI.WebDataInput.WebTextEdit).Text.Trim.Length < 3 Then
                Page.RegisterStartupScript("Alerta", "<script>alert('É obrigatório digitar no mínimo 3 caracteres do nome antes de pesquisar.');</script>")
                Exit Sub
            End If

            Dim datasetDiretoriaCelula As wsRecuperacaoEPrevencaoPerdas.DatasetDiretoriaCelulas = _
                 Controller.ObterDiretoriaCelulas(0, 0, 0, 0, CType(Ctrls(1), Infragistics.WebUI.WebDataInput.WebTextEdit).Text)

            If datasetDiretoriaCelula.T0123183.Rows.Count > 0 Then
                Util.carregarCmbDiretoria(datasetDiretoriaCelula, cmbNomeDiretoria, Nothing)
                flagMostrarCombo = True
            Else
                Me.txtNomeDiretoria.Text = String.Empty
                Page.RegisterStartupScript("Alerta", "<script>alert('Diretoria não Encontrada.');</script>")
                Util.AdicionaJsFocus(Me.Page, txtDiretoria)
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
                RaiseEvent DiretoriaAlterado(CType(Ctrls(2), DropDownList).SelectedItem)
            Else
                CType(Ctrls(2), DropDownList).Items.Insert(0, New ListItem(Format("000") & " - " & "TODAS", "0"))
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
    End Sub

    Private Sub cmbNomeDiretoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNomeDiretoria.SelectedIndexChanged
        With cmbNomeDiretoria
            txtDiretoria.Text = .SelectedValue
            RaiseEvent DiretoriaAlterado(.SelectedItem)
        End With
    End Sub
    Private Sub txtDiretoria_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiretoria.TextChanged
        txtNomeDiretoria.Text = String.Empty
        If Not IsNumeric(txtDiretoria.Text) Then
            If txtDiretoria.Text = String.Empty Then
                Util.AdicionaJsAlert(Me.Page, "Código de Diretoria inválido", True)
                cmbNomeDiretoria.Items.Clear()
                txtDiretoria.Text = String.Empty
                Util.AdicionaJsFocus(Me.Page, txtDiretoria)
            End If
            RaiseEvent DiretoriaAlterado(Nothing)
            Exit Sub
        End If
        Me.txtDiretoria_ValueChange(New WebControl() {txtDiretoria, txtNomeDiretoria, cmbNomeDiretoria})

        If txtDiretoria.Text = String.Empty Then
            cmbNomeDiretoria.Items.Clear()
        End If
    End Sub

    Private Sub txtDiretoria_ValueChange(ByVal Ctrls As WebControl())
        Dim flagMostrarCombo As Boolean = False

        If Not (IsNumeric(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text)) Then Exit Sub

        Dim DatasetDiretoriaCelula As wsRecuperacaoEPrevencaoPerdas.DatasetDiretoriaCelulas = _
            Controller.ObterDiretoriaCelulas(0, 0, CType(Me.txtDiretoria.Text, Decimal), 0, String.Empty)

        If DatasetDiretoriaCelula.T0123183.Rows.Count > 0 Then
            flagMostrarCombo = True
            With CType(Ctrls(2), DropDownList)
                Util.carregarCmbDiretoria(DatasetDiretoriaCelula, CType(Ctrls(2), DropDownList), Nothing)
                RaiseEvent DiretoriaAlterado(cmbNomeDiretoria.SelectedItem)
            End With
            If CType(Me.txtDiretoria.Text, Decimal) = 0 Then
                cmbNomeDiretoria.Items.Insert(0, New ListItem(Format("000") & " - " & "TODAS", "0"))
            End If
            ' hipotese para toda a Diretoria
        ElseIf CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text.Equals("0") Then
            CType(Ctrls(2), DropDownList).Items.Clear()
            CType(Ctrls(2), DropDownList).Items.Add(New ListItem(Format("000") & " - " & "TODAS", "0"))
            cmbNomeDiretoria_SelectedIndexChanged(Nothing, Nothing)
        Else
            CType(Ctrls(2), DropDownList).Items.Clear()
            txtNomeDiretoria.Text = String.Empty

            If IsNumeric(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text) Then
                If Convert.ToDecimal(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text) > 0 Then
                    Util.AdicionaJsAlert(Me.Page, "Código de Diretoria inválido")
                End If
            End If

            RaiseEvent DiretoriaAlterado(New ListItem("NÃO ENCONTRADO", CLng(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text).ToString))
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

    Private Sub btnBuscarDiretoria_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscarDiretoria.Click
        Me.BuscarDiretoria_Click(New WebControl() {txtDiretoria, txtNomeDiretoria, cmbNomeDiretoria})
    End Sub

    Public Sub ReinicializaControle()
        Util.HabilitaControles(New WebControl() {txtDiretoria, txtNomeDiretoria, cmbNomeDiretoria, btnBuscarDiretoria}, True)
        Util.LimpaControles(New WebControl() {txtDiretoria, txtNomeDiretoria, cmbNomeDiretoria})
        txtNomeDiretoria.Visible = True
        cmbNomeDiretoria.Visible = False
    End Sub

    Public Sub SelecionarDiretoria(ByVal CODCPR As Decimal)
        Me.ReinicializaControle()
        txtDiretoria.Text = CODCPR.ToString
        txtDiretoria_TextChanged(Nothing, Nothing)
    End Sub

    Public Sub SelecionarVazio()
        txtDiretoria.Text = String.Empty
        cmbNomeDiretoria.Items.Clear()
    End Sub

    Public Sub PesquisarDiretoria(ByVal NOMCPR As String)
        Me.ReinicializaControle()
        txtNomeDiretoria.Text = NOMCPR.Trim()
        btnBuscarDiretoria_Click(Nothing, Nothing)
    End Sub

    Public Sub setFocus()
        Util.AdicionaJsFocus(Me.Page, txtDiretoria)
    End Sub


End Class