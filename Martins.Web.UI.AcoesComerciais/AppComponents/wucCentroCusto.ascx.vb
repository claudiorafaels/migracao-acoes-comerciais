Public Class wucCentroCusto
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNomeCentroCusto As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents cmbNomeCentroCusto As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnBuscarCentroCusto As System.Web.UI.WebControls.ImageButton

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

    Public Event CentroCustoAlterado(ByVal e As ListItem)

    Public Property CodCentroCusto() As Decimal
        Get
            If cmbNomeCentroCusto.Items.Count > 0 Then
                If IsNumeric(cmbNomeCentroCusto.SelectedValue) Then
                    Return CType(txtCodigo.Text, Decimal)
                Else
                    Return 0
                End If
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Decimal)
            If Not cmbNomeCentroCusto.Items.FindByValue(Value.ToString()) Is Nothing Then
                cmbNomeCentroCusto.SelectedValue = Value.ToString()
            End If
        End Set
    End Property

    Public ReadOnly Property NomCentroCusto() As String
        Get
            If cmbNomeCentroCusto.Items.Count > 0 Then
                Return cmbNomeCentroCusto.SelectedItem.ToString.Trim
            Else
                Return String.Empty
            End If
        End Get
    End Property

    Public WriteOnly Property Enabled() As Boolean
        Set(ByVal Value As Boolean)
            Util.HabilitaControles(New WebControl() {txtCodigo, txtNomeCentroCusto, cmbNomeCentroCusto, btnBuscarCentroCusto}, Value)
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
                Return System.Web.UI.WebControls.Unit.Parse("50")
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
                Return System.Web.UI.WebControls.Unit.Parse("200")
            End If
        End Get
        Set(ByVal Value As System.Web.UI.WebControls.Unit)
            Me.ViewState("widthNome") = Value
        End Set
    End Property

#End Region

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IsPostBack Then
            Me.txtCodigo.Width = widthCodigo
            Me.txtNomeCentroCusto.Width = widthNome
        End If
    End Sub

    Private Sub BuscarCentroCusto_Click(ByVal Ctrls As WebControl())
        Dim flagMostrarCombo As Boolean = False

        ' 0 = campo de codigo 
        ' 1 = txt nome centro custo 
        ' 2 = ddl centro custo 

        If Ctrls(1).Visible Then
            If CType(Ctrls(1), Infragistics.WebUI.WebDataInput.WebTextEdit).Text.Trim.Length < 3 Then
                Page.RegisterStartupScript("Alerta", "<script>alert('É obrigatório digitar no mínimo 3 caracteres do nome antes de pesquisar.');</script>")
                Exit Sub
            End If

            Dim datasetCentroCusto As wsAcoesComerciais.DatasetAcordo = _
                    Controller.ObterCentroCusto(txtCodigo.Text, txtNomeCentroCusto.Text)

            If datasetCentroCusto.CentroCusto.Rows.Count > 0 Then
                Util.carregarCmbCentroCusto(datasetCentroCusto, cmbNomeCentroCusto, Nothing)
                flagMostrarCombo = True
            Else
                Me.txtNomeCentroCusto.Text = String.Empty
                Page.RegisterStartupScript("Alerta", "<script>alert('Centro de Custo não encontrado.');</script>")
                Util.AdicionaJsFocus(Me.Page, txtCodigo)
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
                RaiseEvent CentroCustoAlterado(CType(Ctrls(2), DropDownList).SelectedItem)
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
    End Sub

    Private Sub cmbNomeCentroCusto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNomeCentroCusto.SelectedIndexChanged
        With cmbNomeCentroCusto
            txtCodigo.Text = .SelectedValue
            RaiseEvent CentroCustoAlterado(.SelectedItem)
        End With
    End Sub

    Private Sub txtCodigo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
        txtNomeCentroCusto.Text = String.Empty
        If Not IsNumeric(txtCodigo.Text) Then
            If txtCodigo.Text = String.Empty Then
                Util.AdicionaJsAlert(Me.Page, "Código de centro de custo inválido", True)
                cmbNomeCentroCusto.Items.Clear()
                txtCodigo.Text = String.Empty
                Util.AdicionaJsFocus(Me.Page, txtCodigo)
            End If
            RaiseEvent CentroCustoAlterado(Nothing)
            Exit Sub
        End If
        Me.Codigo_ValueChange(New WebControl() {txtCodigo, txtNomeCentroCusto, cmbNomeCentroCusto})
        If txtCodigo.Text = String.Empty Then
            cmbNomeCentroCusto.Items.Clear()
        End If
    End Sub

    Private Sub Codigo_ValueChange(ByVal Ctrls As WebControl())
        Dim flagMostrarCombo As Boolean = False

        If Not (IsNumeric(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text)) Then Exit Sub

        Dim datasetCentroCusto As wsAcoesComerciais.DatasetAcordo = _
            Controller.ObterCentroCusto(Me.txtCodigo.Text.Trim, Me.txtNomeCentroCusto.Text.Trim)

        If datasetCentroCusto.CentroCusto.Rows.Count > 0 Then
            flagMostrarCombo = True
            With CType(Ctrls(2), DropDownList)
                Util.carregarCmbCentroCusto(datasetCentroCusto, CType(Ctrls(2), DropDownList), Nothing)
                RaiseEvent CentroCustoAlterado(cmbNomeCentroCusto.SelectedItem)
            End With

            If CType(Me.txtCodigo.Text, Decimal) = 0 Then
                cmbNomeCentroCusto.Items.Insert(0, New ListItem(Format("000") & " - " & "TODOS", "0"))
            End If
        ElseIf CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text.Equals("0") Then
            CType(Ctrls(2), DropDownList).Items.Clear()
            CType(Ctrls(2), DropDownList).Items.Add(New ListItem("TODOS", "0"))
            cmbNomeCentroCusto_SelectedIndexChanged(Nothing, Nothing)
        Else
            CType(Ctrls(2), DropDownList).Items.Clear()
            txtNomeCentroCusto.Text = String.Empty

            If IsNumeric(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text) Then
                If Convert.ToDecimal(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text) > 0 Then
                    Util.AdicionaJsAlert(Me.Page, "Código de centro de custo inválido")
                End If
            End If

            RaiseEvent CentroCustoAlterado(New ListItem("NÃO ENCONTRADO", CLng(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text).ToString))
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

    Private Sub btnBuscarCentroCusto_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscarCentroCusto.Click
        Me.BuscarCentroCusto_Click(New WebControl() {txtCodigo, txtNomeCentroCusto, cmbNomeCentroCusto})
    End Sub

    Public Sub ReinicializaControle()
        Util.HabilitaControles(New WebControl() {txtCodigo, txtNomeCentroCusto, cmbNomeCentroCusto, btnBuscarCentroCusto}, True)
        Util.LimpaControles(New WebControl() {txtCodigo, txtNomeCentroCusto, cmbNomeCentroCusto})
        cmbNomeCentroCusto.Visible = False
        txtNomeCentroCusto.Visible = True
    End Sub

    Public Sub SelecionarCentroCusto(ByVal codCentroCusto As Decimal)
        Me.ReinicializaControle()
        txtCodigo.Text = codCentroCusto.ToString
        txtCodigo_TextChanged(Nothing, Nothing)
    End Sub

    Public Sub SelecionarVazio()
        txtCodigo.Text = String.Empty
        'cmbNomeFornecedor.SelectedIndex = 0
        cmbNomeCentroCusto.Items.Clear()
    End Sub

    Public Sub PesquisarCentroCusto(ByVal NomeCentroCusto As String)
        Me.ReinicializaControle()
        txtNomeCentroCusto.Text = NomeCentroCusto.Trim()
        btnBuscarCentroCusto_Click(Nothing, Nothing)
    End Sub

    Public Sub setFocus()
        Util.AdicionaJsFocus(Me.Page, txtCodigo)
    End Sub

End Class
