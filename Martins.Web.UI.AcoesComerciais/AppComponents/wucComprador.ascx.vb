Public Class wucComprador
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtNomeComprador As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents cmbNomeComprador As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnBuscarComprador As System.Web.UI.WebControls.ImageButton
    Protected WithEvents txtComprador As System.Web.UI.WebControls.TextBox

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

    Public Event CompradorAlterado(ByVal e As ListItem)

    Public Property CodComprador() As Decimal
        Get
            If cmbNomeComprador.Items.Count > 0 Then
                If IsNumeric(cmbNomeComprador.SelectedValue) Then
                    Return CType(txtComprador.Text, Decimal)
                Else
                    Return 0
                End If
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Decimal)
            If Not cmbNomeComprador.Items.FindByValue(Value.ToString()) Is Nothing Then
                cmbNomeComprador.SelectedValue = Value.ToString()
            End If
        End Set
    End Property

    Public ReadOnly Property NomComprador() As String
        Get
            If cmbNomeComprador.Items.Count > 0 Then
                Return cmbNomeComprador.SelectedItem.ToString.Trim
            Else
                Return String.Empty
            End If
        End Get
    End Property

    Public WriteOnly Property Enabled() As Boolean
        Set(ByVal Value As Boolean)
            Util.HabilitaControles(New WebControl() {txtComprador, txtNomeComprador, cmbNomeComprador, btnBuscarComprador}, Value)
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
            Me.txtComprador.Width = widthCodigo
            Me.txtNomeComprador.Width = widthNome
        End If
    End Sub

    Private Sub BuscarComprador_Click(ByVal Ctrls As WebControl())
        Dim flagMostrarCombo As Boolean = False

        ' 0 = campo de codigo 
        ' 1 = txt nome Comprador 
        ' 2 = ddl Comprador 

        If Ctrls(1).Visible Then
            If CType(Ctrls(1), Infragistics.WebUI.WebDataInput.WebTextEdit).Text.Trim.Length < 3 Then
                Page.RegisterStartupScript("Alerta", "<script>alert('É obrigatório digitar no mínimo 3 caracteres do nome antes de pesquisar.');</script>")
                Exit Sub
            End If

            Dim datasetRecuperacaoEPrevencaoPerdas As wsRecuperacaoEPrevencaoPerdas.DatasetRecuperacaoEPrevencaoPerdas = _
                    Controller.ObterComprador(0, CType(Ctrls(1), Infragistics.WebUI.WebDataInput.WebTextEdit).Text)

            If datasetRecuperacaoEPrevencaoPerdas.Comprador.Rows.Count > 0 Then
                Util.carregarCmbNomeComprador(datasetRecuperacaoEPrevencaoPerdas, cmbNomeComprador, Nothing)
                flagMostrarCombo = True
            Else
                Me.txtNomeComprador.Text = String.Empty
                Page.RegisterStartupScript("Alerta", "<script>alert('Comprador não Encontrado.');</script>")
                Util.AdicionaJsFocus(Me.Page, txtComprador)
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
                RaiseEvent CompradorAlterado(CType(Ctrls(2), DropDownList).SelectedItem)
            Else
                CType(Ctrls(2), DropDownList).Items.Insert(0, New ListItem(Format("000") & " - " & "TODOS", "0"))
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

    Private Sub cmbNomeComprador_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNomeComprador.SelectedIndexChanged
        With cmbNomeComprador
            txtComprador.Text = .SelectedValue
            RaiseEvent CompradorAlterado(.SelectedItem)
        End With
    End Sub


    Private Sub txtComprador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComprador.TextChanged
        txtNomeComprador.Text = String.Empty
        If Not IsNumeric(txtComprador.Text) Then
            If txtComprador.Text = String.Empty Then
                Util.AdicionaJsAlert(Me.Page, "Código de Comprador inválido", True)
                cmbNomeComprador.Items.Clear()
                txtComprador.Text = String.Empty
                Util.AdicionaJsFocus(Me.Page, txtComprador)
            End If
            RaiseEvent CompradorAlterado(Nothing)
            Exit Sub
        End If
        Me.txtComprador_ValueChange(New WebControl() {txtComprador, txtNomeComprador, cmbNomeComprador})
        If txtComprador.Text = String.Empty Then
            cmbNomeComprador.Items.Clear()
        End If
    End Sub

    Private Sub txtComprador_ValueChange(ByVal Ctrls As WebControl())
        Dim flagMostrarCombo As Boolean = False

        If Not (IsNumeric(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text)) Then Exit Sub

        Dim datasetRecuperacaoEPrevencaoPerdas As wsRecuperacaoEPrevencaoPerdas.DatasetRecuperacaoEPrevencaoPerdas = _
            Controller.ObterComprador(CType(Me.txtComprador.Text, Decimal), String.Empty)

        If datasetRecuperacaoEPrevencaoPerdas.Comprador.Rows.Count > 0 Then
            flagMostrarCombo = True
            With CType(Ctrls(2), DropDownList)
                Util.carregarCmbNomeComprador(datasetRecuperacaoEPrevencaoPerdas, CType(Ctrls(2), DropDownList), Nothing)
                RaiseEvent CompradorAlterado(cmbNomeComprador.SelectedItem)
            End With
            If CType(Me.txtComprador.Text, Decimal) = 0 Then
                cmbNomeComprador.Items.Insert(0, New ListItem(Format("000") & " - " & "TODOS", "0"))
            End If
            ' hipotese para todos os Compradores
        ElseIf CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text.Equals("0") Then
            CType(Ctrls(2), DropDownList).Items.Clear()
            CType(Ctrls(2), DropDownList).Items.Add(New ListItem(Format("000") & " - " & "TODOS", "0"))
            cmbNomeComprador_SelectedIndexChanged(Nothing, Nothing)
        Else
            CType(Ctrls(2), DropDownList).Items.Clear()
            txtNomeComprador.Text = String.Empty

            If IsNumeric(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text) Then
                If Convert.ToDecimal(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text) > 0 Then
                    Util.AdicionaJsAlert(Me.Page, "Código de Comprador inválido")
                End If
            End If

            RaiseEvent CompradorAlterado(New ListItem("NÃO ENCONTRADO", CLng(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text).ToString))
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

    Private Sub btnBuscarComprador_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscarComprador.Click
        Me.BuscarComprador_Click(New WebControl() {txtComprador, txtNomeComprador, cmbNomeComprador})
    End Sub

    Public Sub ReinicializaControle()
        Util.HabilitaControles(New WebControl() {txtComprador, txtNomeComprador, cmbNomeComprador, btnBuscarComprador}, True)
        Util.LimpaControles(New WebControl() {txtComprador, txtNomeComprador, cmbNomeComprador})
        cmbNomeComprador.Visible = False
        txtNomeComprador.Visible = True
    End Sub

    Public Sub SelecionarComprador(ByVal CODCPR As Decimal)
        Me.ReinicializaControle()
        txtComprador.Text = CODCPR.ToString
        txtComprador_TextChanged(Nothing, Nothing)
    End Sub

    Public Sub SelecionarVazio()
        txtComprador.Text = String.Empty
        cmbNomeComprador.Items.Clear()
    End Sub

    Public Sub PesquisarComprador(ByVal NOMCPR As String)
        Me.ReinicializaControle()
        txtNomeComprador.Text = NOMCPR.Trim()
        btnBuscarComprador_Click(Nothing, Nothing)
    End Sub

    Public Sub setFocus()
        Util.AdicionaJsFocus(Me.Page, txtComprador)
    End Sub

End Class