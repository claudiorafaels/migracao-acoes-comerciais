Public Class ucFornecedor
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected WithEvents txtCODFRN As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNOMFRN As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents cmbNOMFRN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblFornecedor As System.Web.UI.WebControls.Label
    Protected WithEvents btnFornecedor As System.Web.UI.WebControls.ImageButton

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

    Public Event FornecedorAlterado(ByVal e As ListItem)

    Public Property CodFornecedor() As Decimal
        Get
            If cmbNOMFRN.Items.Count > 0 Then
                If IsNumeric(cmbNOMFRN.SelectedValue) Then
                    Return CType(txtCODFRN.Text, Decimal)
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
            If Not cmbNOMFRN.Items.FindByValue(Value.ToString()) Is Nothing Then
                cmbNOMFRN.SelectedValue = Value.ToString()
            End If
        End Set
    End Property

    Public ReadOnly Property NomFornecedor() As String
        Get
            If Me.CodFornecedor > 0 Then
                Return cmbNOMFRN.SelectedItem.ToString.Trim
            Else
                Return String.Empty
            End If
        End Get
    End Property

    Public Property Enabled() As Boolean
        Set(ByVal Value As Boolean)
            Util.HabilitaControles(New WebControl() {txtCODFRN, txtNOMFRN, cmbNOMFRN, btnFornecedor}, Value)
        End Set
        Get
            If txtCODFRN.Enabled = False And txtNOMFRN.Enabled = False And cmbNOMFRN.Enabled = False And btnFornecedor.Enabled = False Then
                Return False
            ElseIf txtCODFRN.Enabled = True And txtNOMFRN.Enabled = True And cmbNOMFRN.Enabled = True And btnFornecedor.Enabled = True Then
                Return True
            End If
        End Get
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
            If lblFornecedor.Text.ToUpper.Trim = "Fornecedor DESATIVADA" Then
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
            Me.txtCODFRN.Width = widthCodigo
            Me.txtNOMFRN.Width = widthNome
        End If
    End Sub


    Private Sub cmbNOMFRN_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNOMFRN.SelectedIndexChanged
        lblFornecedor.Text = ""
        With cmbNOMFRN
            txtCODFRN.Text = .SelectedValue
            Dim DatasetIncentivo As wsAcoesComerciais.DatasetIncentivo = Controller.ObterFornecedorPorChave(CType(txtCODFRN.Text, Decimal))
            'If DatasetIncentivo.T0100426.Rows.Count > 0 Then
            '    lblFornecedor.Text = observacaoFornecedor(DatasetIncentivo.T0100426(0))
            'End If
            RaiseEvent FornecedorAlterado(.SelectedItem)
        End With
        Util.AdicionaJsFocus(Me.Page, cmbNOMFRN)
    End Sub

    Private Sub txtCODFRN_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCODFRN.TextChanged
        lblFornecedor.Text = ""
        txtNOMFRN.Text = String.Empty
        If Not IsNumeric(txtCODFRN.Text) Then
            Util.AdicionaJsAlert(Me.Page, "Código do Fornecedor inválido", True)
            cmbNOMFRN.Items.Clear()
            txtCODFRN.Text = String.Empty
            Util.AdicionaJsFocus(Me.Page, txtCODFRN)
            RaiseEvent FornecedorAlterado(Nothing)
            Exit Sub
        End If
        Me.Codigo_ValueChange(New WebControl() {txtCODFRN, txtNOMFRN, cmbNOMFRN})
        If txtCODFRN.Text = String.Empty Then
            cmbNOMFRN.Items.Clear()
        End If
        Util.AdicionaJsFocus(Me.Page, cmbNOMFRN)
    End Sub

    Private Sub btnFornecedor_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnFornecedor.Click
        lblFornecedor.Text = ""
        txtCODFRN.Text = String.Empty
        Me.BuscarFornecedor_Click(New WebControl() {txtCODFRN, txtNOMFRN, cmbNOMFRN})
    End Sub
#End Region

#Region "Métodos"

    Public Sub setFocus()
        Util.AdicionaJsFocus(Me.Page, txtCODFRN)
    End Sub

    Private Sub BuscarFornecedor_Click(ByVal Ctrls As WebControl())
        Dim flagMostrarCombo As Boolean = False

        ' 0 = campo de codigo 
        ' 1 = txt nome Fornecedor 
        ' 2 = ddl Fornecedor 

        If Ctrls(1).Visible Then
            If CType(Ctrls(1), Infragistics.WebUI.WebDataInput.WebTextEdit).Text.Trim.Length < 3 Then
                lblFornecedor.Text = ""
                Page.RegisterStartupScript("Alerta", "<script>alert('É obrigatório digitar no mínimo 3 caracteres do nome antes de pesquisar.');</script>")
                Exit Sub
            End If

            Dim DatasetIncentivo As wsAcoesComerciais.DatasetIncentivo = Controller.ObterFornecedorPorAtributo(0, txtNOMFRN.Text)

            If DatasetIncentivo.T0100426.Rows.Count > 0 Then
                'lblFornecedor.Text = observacaoFornecedor(DatasetIncentivo.T0100426(0))
                carregarCombo(DatasetIncentivo, cmbNOMFRN, Nothing)
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
                RaiseEvent FornecedorAlterado(CType(Ctrls(2), DropDownList).SelectedItem)
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

        If cmbNOMFRN.Visible Then
            Util.AdicionaJsFocus(Me.Page, cmbNOMFRN)
        ElseIf txtNOMFRN.Visible Then
            Util.AdicionaJsFocus(Me.Page, txtNOMFRN)
        End If

    End Sub

    Private Sub Codigo_ValueChange(ByVal Ctrls As WebControl())
        Dim flagMostrarCombo As Boolean = False

        If Not (IsNumeric(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text)) Then Exit Sub

        Dim DatasetIncentivo As wsAcoesComerciais.DatasetIncentivo = _
            Controller.ObterFornecedorPorChave(CType(txtCODFRN.Text, Decimal))


        If DatasetIncentivo.T0100426.Rows.Count > 0 Then
            'lblFornecedor.Text = observacaoFornecedor(DatasetIncentivo.T0100426(0))
            flagMostrarCombo = True
            With CType(Ctrls(2), DropDownList)
                carregarCombo(DatasetIncentivo, CType(Ctrls(2), DropDownList), Nothing)
                cmbNOMFRN_SelectedIndexChanged(Nothing, Nothing)
            End With
            ' hipotese para todos os Fornecedors
        ElseIf CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text.Equals("0") Then
            CType(Ctrls(2), DropDownList).Items.Clear()
            CType(Ctrls(2), DropDownList).Items.Add(New ListItem(" Todos ", "0"))
            cmbNOMFRN_SelectedIndexChanged(Nothing, Nothing)
        Else
            CType(Ctrls(2), DropDownList).Items.Clear()
            txtNOMFRN.Text = String.Empty

            If IsNumeric(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text) Then
                If Convert.ToDecimal(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text) > 0 Then
                    txtCODFRN.Text = String.Empty
                    Util.AdicionaJsAlert(Me.Page, "Código do Fornecedor inválido", True)
                End If
            End If

            'RaiseEvent FornecedorAlterado(New ListItem("NÃO ENCONTRADO", CLng(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text).ToString))
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
        Util.HabilitaControles(New WebControl() {txtCODFRN, txtNOMFRN, cmbNOMFRN, btnFornecedor}, True)
        Util.LimpaControles(New WebControl() {txtCODFRN, txtNOMFRN, cmbNOMFRN})
        cmbNOMFRN.Visible = False
        txtNOMFRN.Visible = True
    End Sub

    Public Sub SelecionarFornecedor(ByVal codFornecedor As Decimal)
        Me.ReinicializaControle()
        txtCODFRN.Text = codFornecedor.ToString
        txtCODFRN_TextChanged(Nothing, Nothing)
    End Sub

    Public Sub SelecionarVazio()
        txtCODFRN.Text = String.Empty
        cmbNOMFRN.Items.Clear()
        lblFornecedor.Visible = False
    End Sub

    Public Sub PesquisarFornecedor(ByVal NomeFornecedor As String)
        Me.ReinicializaControle()
        txtNOMFRN.Text = NomeFornecedor.Trim()
        btnFornecedor_Click(Nothing, Nothing)
    End Sub

    Private Sub carregarCombo(ByRef ds As wsAcoesComerciais.DatasetIncentivo, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetIncentivo.T0100426Row In ds.T0100426.Select("", "NOMFRN")
                .Items.Add(New ListItem(linha.CODFRN.ToString & " - " & linha.NOMFRN, linha.CODFRN.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

#End Region

End Class