Public Class wucCelula
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtNomeCelula As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents cmbNomeCelula As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnBuscarCelula As System.Web.UI.WebControls.ImageButton
    Protected WithEvents txtCelula As System.Web.UI.WebControls.TextBox

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

    Public Event CelulaAlterado(ByVal e As ListItem)

    Public Property CodCelula() As Decimal
        Get
            If cmbNomeCelula.Items.Count > 0 Then
                If IsNumeric(cmbNomeCelula.SelectedValue) Then
                    Return CType(txtCelula.Text, Decimal)
                Else
                    Return 0
                End If
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Decimal)
            If Not cmbNomeCelula.Items.FindByValue(Value.ToString()) Is Nothing Then
                cmbNomeCelula.SelectedValue = Value.ToString()
            End If
        End Set
    End Property

    Public ReadOnly Property NomCelula() As String
        Get
            If cmbNomeCelula.Items.Count > 0 Then
                Return cmbNomeCelula.SelectedItem.ToString.Trim
            Else
                Return String.Empty
            End If
        End Get
    End Property

    Public WriteOnly Property Enabled() As Boolean
        Set(ByVal Value As Boolean)
            Util.HabilitaControles(New WebControl() {txtCelula, txtNomeCelula, cmbNomeCelula, btnBuscarCelula}, Value)
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
            Me.txtCelula.Width = widthCodigo
            Me.txtNomeCelula.Width = widthNome
        End If
    End Sub

    Private Sub BuscarCelula_Click(ByVal Ctrls As WebControl())
        Dim flagMostrarCombo As Boolean = False

        ' 0 = campo de codigo 
        ' 1 = txt nome Comprador 
        ' 2 = ddl Comprador 

        If Ctrls(1).Visible Then
            If CType(Ctrls(1), Infragistics.WebUI.WebDataInput.WebTextEdit).Text.Trim.Length < 3 Then
                Page.RegisterStartupScript("Alerta", "<script>alert('É obrigatório digitar no mínimo 3 caracteres do nome antes de pesquisar.');</script>")
                Exit Sub
            End If

            Dim datasetCelula As wsRecuperacaoEPrevencaoPerdas.DatasetCelula = _
                    Controller.ObterCelulaPorAtributo(0, CType(Ctrls(1), Infragistics.WebUI.WebDataInput.WebTextEdit).Text)

            If datasetCelula.T0118570.Rows.Count > 0 Then
                Util.carregarCmbCelula(datasetCelula, cmbNomeCelula, Nothing)
                flagMostrarCombo = True
            Else
                Me.txtNomeCelula.Text = String.Empty
                Page.RegisterStartupScript("Alerta", "<script>alert('Célula não Encontrada.');</script>")
                Util.AdicionaJsFocus(Me.Page, txtCelula)
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
                RaiseEvent CelulaAlterado(CType(Ctrls(2), DropDownList).SelectedItem)
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

    Private Sub cmbNomeCelula_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNomeCelula.SelectedIndexChanged
        With cmbNomeCelula
            txtCelula.Text = .SelectedValue
            RaiseEvent CelulaAlterado(.SelectedItem)
        End With
    End Sub

    Private Sub txtCelula_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCelula.TextChanged
        txtNomeCelula.Text = String.Empty
        If Not IsNumeric(txtCelula.Text) Then
            If txtCelula.Text = String.Empty Then
                Util.AdicionaJsAlert(Me.Page, "Código de Célula inválido", True)
                cmbNomeCelula.Items.Clear()
                txtCelula.Text = String.Empty
                Util.AdicionaJsFocus(Me.Page, txtCelula)
            End If
            RaiseEvent CelulaAlterado(Nothing)
            Exit Sub
        End If
        Me.txtCelula_ValueChange(New WebControl() {txtCelula, txtNomeCelula, cmbNomeCelula})
        If txtCelula.Text = String.Empty Then
            cmbNomeCelula.Items.Clear()
        End If
    End Sub

    Private Sub txtCelula_ValueChange(ByVal Ctrls As WebControl())
        Dim flagMostrarCombo As Boolean = False

        If Not (IsNumeric(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text)) Then Exit Sub

        Dim datasetCelula As wsRecuperacaoEPrevencaoPerdas.DatasetCelula = _
            Controller.ObterCelulaPorAtributo(CType(Me.txtCelula.Text, Decimal), String.Empty)

        If datasetCelula.T0118570.Rows.Count > 0 Then
            flagMostrarCombo = True
            With CType(Ctrls(2), DropDownList)
                Util.carregarCmbCelula(datasetCelula, CType(Ctrls(2), DropDownList), Nothing)
                RaiseEvent CelulaAlterado(cmbNomeCelula.SelectedItem)
            End With
            If CType(Me.txtCelula.Text, Decimal) = 0 Then
                cmbNomeCelula.Items.Insert(0, New ListItem(Format("000") & " - " & "TODAS", "0"))
            End If
            ' hipotese para todos os Compradores
        ElseIf CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text.Equals("0") Then
            CType(Ctrls(2), DropDownList).Items.Clear()
            CType(Ctrls(2), DropDownList).Items.Add(New ListItem(Format("000") & " - " & "TODAS", "0"))
            cmbNomeCelula_SelectedIndexChanged(CType(Me.txtCelula.Text, Decimal), Nothing)
        Else
            CType(Ctrls(2), DropDownList).Items.Clear()
            txtNomeCelula.Text = String.Empty

            If IsNumeric(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text) Then
                If Convert.ToDecimal(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text) > 0 Then
                    Util.AdicionaJsAlert(Me.Page, "Código de Celula inválido")
                End If
            End If

            RaiseEvent CelulaAlterado(New ListItem("NÃO ENCONTRADO", CLng(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text).ToString))
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

    Private Sub btnBuscarCelula_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscarCelula.Click
        Me.BuscarCelula_Click(New WebControl() {txtCelula, txtNomeCelula, cmbNomeCelula})
    End Sub

    Public Sub ReinicializaControle()
        Util.HabilitaControles(New WebControl() {txtCelula, txtNomeCelula, cmbNomeCelula, btnBuscarCelula}, True)
        Util.LimpaControles(New WebControl() {txtCelula, txtNomeCelula, cmbNomeCelula})
        cmbNomeCelula.Visible = False
        txtNomeCelula.Visible = True
    End Sub

    Public Sub SelecionarComprador(ByVal CODCPR As Decimal)
        Me.ReinicializaControle()
        txtCelula.Text = CODCPR.ToString
        txtCelula_TextChanged(Nothing, Nothing)
    End Sub

    Public Sub SelecionarVazio()
        txtCelula.Text = String.Empty
        cmbNomeCelula.Items.Clear()
    End Sub

    Public Function EVazio() As Boolean
        If txtCelula.Text = String.Empty Then
            Return True
        End If
        'cmbNomeCelula.Items.Clear()
        Return False
    End Function

    Public Sub PesquisarComprador(ByVal NOMCPR As String)
        Me.ReinicializaControle()
        txtNomeCelula.Text = NOMCPR.Trim()
        btnBuscarCelula_Click(Nothing, Nothing)
    End Sub

    Public Sub setFocus()
        Util.AdicionaJsFocus(Me.Page, txtCelula)
    End Sub

End Class