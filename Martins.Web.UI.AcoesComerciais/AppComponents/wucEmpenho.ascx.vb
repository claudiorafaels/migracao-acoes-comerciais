Public Class wucEmpenho
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents cmbNomeEmpenho As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodigo As Infragistics.WebUI.WebDataInput.WebTextEdit

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

    Public Event EmpenhoAlterado(ByVal e As ListItem)

    Public Enum enumMostrarReceitaCMV As Integer
        todos = -1
        nao = 0
        sim = 1
    End Enum

    Public Property CodEmpenho() As Decimal
        Get
            If cmbNomeEmpenho.Items.Count > 0 Then
                If IsNumeric(cmbNomeEmpenho.SelectedValue) Then
                    Return Convert.ToDecimal(cmbNomeEmpenho.SelectedValue)
                Else
                    Return 0
                End If
            Else
                Return 0 '-1 (se precisar retornar -1 avisar para Marcos alterar relatórios)
            End If
        End Get
        Set(ByVal Value As Decimal)
            If cmbNomeEmpenho.Items.Count = 0 Then
                Me.carregarCombo()
            End If
            If Not cmbNomeEmpenho.Items.FindByValue(Value.ToString()) Is Nothing Then
                cmbNomeEmpenho.SelectedValue = Value.ToString()
                txtCodigo.Text = cmbNomeEmpenho.SelectedValue
            End If
        End Set
    End Property

    Public WriteOnly Property Enabled() As Boolean
        Set(ByVal Value As Boolean)
            Util.HabilitaControles(New WebControl() {txtCodigo, cmbNomeEmpenho}, Value)
        End Set
    End Property

    Public Property IncluirItemTodos() As Boolean
        Get
            Dim result As Boolean
            If ViewState("IncluirItemTodos") Is Nothing Then
                result = False
            End If
            Return CType(ViewState("IncluirItemTodos"), Boolean)
        End Get
        Set(ByVal Value As Boolean)
            ViewState("IncluirItemTodos") = Value
            If Value = True Then
                If cmbNomeEmpenho.Items.FindByValue(txtCodigo.Text) Is Nothing Then
                    cmbNomeEmpenho.Items.Insert(0, New ListItem("Todos", "0"))
                End If
            Else
                If Not cmbNomeEmpenho.Items.FindByValue(txtCodigo.Text) Is Nothing Then
                    cmbNomeEmpenho.Items.Remove(New ListItem("Todos", "0"))
                End If
            End If
        End Set
    End Property

    Public Property IncluirItemSelecione() As Boolean
        Get
            Dim result As Boolean
            If ViewState("IncluirItemSelecione") Is Nothing Then
                result = False
            End If
            Return CType(ViewState("IncluirItemSelecione"), Boolean)
        End Get
        Set(ByVal Value As Boolean)
            ViewState("IncluirItemSelecione") = Value
            If Value = True Then
                If cmbNomeEmpenho.Items.FindByValue("0") Is Nothing Then
                    cmbNomeEmpenho.Items.Insert(0, New ListItem("SELECIONE->", "0"))
                End If
            Else
                If Not cmbNomeEmpenho.Items.FindByValue("0") Is Nothing Then
                    cmbNomeEmpenho.Items.Remove(New ListItem("SELECIONE->", "0"))
                End If
            End If
        End Set
    End Property

    Public Property MostrarReceitaCMV() As enumMostrarReceitaCMV
        Get
            Dim result As enumMostrarReceitaCMV
            If ViewState("MostrarReceitaCMV") Is Nothing Then
                result = enumMostrarReceitaCMV.todos
            End If
            Return CType(ViewState("MostrarReceitaCMV"), enumMostrarReceitaCMV)
        End Get
        Set(ByVal Value As enumMostrarReceitaCMV)
            ViewState("MostrarReceitaCMV") = Value
        End Set
    End Property

    Public ReadOnly Property recarregarCombo() As Boolean
        Get
            Dim result As Boolean = False
            If cmbNomeEmpenho.Items.Count = 0 Then
                result = True
            ElseIf cmbNomeEmpenho.Items.Count = 1 And (cmbNomeEmpenho.Items(0).Value = "0" Or cmbNomeEmpenho.Items(0).Value = "") Then
                result = True
            End If
            Return result
        End Get
    End Property

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IsPostBack Then
            If recarregarCombo Then
                'Carregar todos empenhos
                carregarCombo()
                txtCodigo.Text = CodEmpenho.ToString  'cmbNomeEmpenho.SelectedValue
            End If
        End If
    End Sub

    Private Sub cmbNomeEmpenho_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNomeEmpenho.SelectedIndexChanged
        With cmbNomeEmpenho
            txtCodigo.Text = .SelectedValue
            RaiseEvent EmpenhoAlterado(.SelectedItem)
        End With
    End Sub

    Public Sub SelecionaItemCmbNomeEmpenho()
        If recarregarCombo Then
            carregarCombo()
        End If
        If Not cmbNomeEmpenho.Items.FindByValue(Request.QueryString("CodEmpenho").ToString) Is Nothing Then
            cmbNomeEmpenho.SelectedValue = CodEmpenho.ToString
            txtCodigo.Text = cmbNomeEmpenho.SelectedValue
        End If
    End Sub


    'Private Sub txtCodigo_ValueChange(ByVal sender As Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtCodigo.ValueChange
    '    Me.Codigo_ValueChange(New WebControl() {txtCodigo, cmbNomeEmpenho})
    'End Sub

    'Private Sub Codigo_ValueChange(ByVal Ctrls As WebControl())
    '    'If Not cmbNomeEmpenho.Items.FindByValue(txtCodigo.Text) Is Nothing Then
    '    '    cmbNomeEmpenho.SelectedValue = Me.txtCodigo.Text
    '    'Else
    '    '    'Util.AdicionaJsAlert(Me.Page, "Não encontrado Empenho " & txtCodigo.Text.Trim)
    '    '    txtCodigo.Value = cmbNomeEmpenho.SelectedValue
    '    'End If

    '    If cmbNomeEmpenho.Items.Count <= 0 Then
    '        carregarCombo()
    '    End If
    '    CodEmpenho = 

    'End Sub

    Public Sub ReinicializaControle()
        Util.HabilitaControles(New WebControl() {txtCodigo, cmbNomeEmpenho}, True)
        Util.LimpaControles(New WebControl() {txtCodigo, cmbNomeEmpenho})
        'cmbNomeEmpenho.Visible = False
    End Sub

    Public Sub SelecionarEmpenho(ByVal codEmpenho As Decimal)
        Me.ReinicializaControle()
        txtCodigo.Value = codEmpenho
        txtCodigo_ValueChange(Nothing, Nothing)
    End Sub

    Public Sub SelecionarVazio()
        txtCodigo.Value = String.Empty
        cmbNomeEmpenho.SelectedIndex = 0
    End Sub

    Private Sub carregarCombo()
        'Carregar todos empenhos
        If IncluirItemTodos Then
            Util.carregarCmbEmpenho(Controller.ObterEmpenhos("", "", "", 0, "", CType(MostrarReceitaCMV, Decimal)), cmbNomeEmpenho, New ListItem("Todos", "0"))
        ElseIf IncluirItemSelecione Then
            Util.carregarCmbEmpenho(Controller.ObterEmpenhos("", "", "", 0, "", CType(MostrarReceitaCMV, Decimal)), cmbNomeEmpenho, New ListItem("SELECIONE->", "0"))
        Else
            Util.carregarCmbEmpenho(Controller.ObterEmpenhos("", "", "", 0, "", CType(MostrarReceitaCMV, Decimal)), cmbNomeEmpenho, Nothing)
        End If
        If Not cmbNomeEmpenho.Items.FindByText(txtCodigo.Text) Is Nothing Then
            cmbNomeEmpenho.SelectedValue = txtCodigo.Text
        ElseIf Not cmbNomeEmpenho.Items.FindByText(Me.CodEmpenho.ToString) Is Nothing Then
            cmbNomeEmpenho.SelectedValue = Me.CodEmpenho.ToString
        End If
        txtCodigo.Text = cmbNomeEmpenho.SelectedValue
    End Sub

    Private Sub txtCodigo_ValueChange(ByVal sender As System.Object, ByVal e As Infragistics.WebUI.WebDataInput.ValueChangeEventArgs) Handles txtCodigo.ValueChange
        'Sincroniza codigo do empenho 

        If CodEmpenho.ToString <> txtCodigo.Text Then
            If IsNumeric(txtCodigo.Text) Then
                CodEmpenho = Convert.ToDecimal(txtCodigo.Text)
            Else
                CodEmpenho = 0
            End If
            RaiseEvent EmpenhoAlterado(cmbNomeEmpenho.SelectedItem)
        End If
        'Sincroniza o codigo com o combo
        If CodEmpenho.ToString <> cmbNomeEmpenho.SelectedValue Then
            If Not cmbNomeEmpenho.Items.FindByText(CodEmpenho.ToString) Is Nothing Then
                cmbNomeEmpenho.SelectedValue = CodEmpenho.ToString
                RaiseEvent EmpenhoAlterado(cmbNomeEmpenho.SelectedItem)
            End If
        End If

        Dim limparFornecedor As Boolean = False
        If txtCodigo.Text = "" Then
            limparFornecedor = True
        ElseIf Not IsNumeric(txtCodigo.Text) Then
            limparFornecedor = True
        ElseIf CType(txtCodigo.Text, Decimal) = 0 Then
            limparFornecedor = True
        End If

        If limparFornecedor Then
            cmbNomeEmpenho.Items.Clear()
        End If

    End Sub

    Public Sub setFocus()
        Util.AdicionaJsFocus(Me.Page, cmbNomeEmpenho)
    End Sub

End Class
