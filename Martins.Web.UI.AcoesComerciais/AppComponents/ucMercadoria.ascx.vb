Public Class ucMercadoria
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetMercadoria1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetMercadoria

        CType(Me.DatasetMercadoria1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetMercadoria1
        '
        Me.DatasetMercadoria1.DataSetName = "DatasetMercadoria"
        Me.DatasetMercadoria1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetMercadoria1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents btnBuscarMercadoria As System.Web.UI.WebControls.ImageButton
    Protected WithEvents txtCodigoMercadoria As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmbNomeMercadoria As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNomeMercadoria As Infragistics.WebUI.WebDataInput.WebTextEdit
    Protected WithEvents DatasetMercadoria1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetMercadoria
    Protected WithEvents lblMercadoria As System.Web.UI.WebControls.Label

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

    Public Event MercadoriaAlterado(ByVal e As ListItem)

    Public Property CodMercadoria() As Decimal
        Get
            If cmbNomeMercadoria.Items.Count > 0 Then
                If IsNumeric(cmbNomeMercadoria.SelectedValue) Then
                    Return CType(txtCodigoMercadoria.Text, Decimal)
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
            If Not cmbNomeMercadoria.Items.FindByValue(Value.ToString()) Is Nothing Then
                cmbNomeMercadoria.SelectedValue = Value.ToString()
            End If
        End Set
    End Property

    Public ReadOnly Property NomMercadoria() As String
        Get
            If Me.CodMercadoria > 0 Then
                Return cmbNomeMercadoria.SelectedItem.ToString.Trim
            Else
                Return String.Empty
            End If
        End Get
    End Property

    Public WriteOnly Property Enabled() As Boolean
        Set(ByVal Value As Boolean)
            Util.HabilitaControles(New WebControl() {txtCodigoMercadoria, txtNomeMercadoria, cmbNomeMercadoria, btnBuscarMercadoria}, Value)
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
            If lblMercadoria.Text.ToUpper.Trim = "MERCADORIA DESATIVADA" Then
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
            Me.txtCodigoMercadoria.Width = widthCodigo
            Me.txtNomeMercadoria.Width = widthNome
        End If
    End Sub

    Private Sub cmbNomeMercadoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNomeMercadoria.SelectedIndexChanged
        lblMercadoria.Text = ""
        With cmbNomeMercadoria
            txtCodigoMercadoria.Text = .SelectedValue
            Dim datasetMercadoria As wsAcoesComerciais.DatasetMercadoria = _
                        Controller.ObterMercadoriaPorChave(1, CType(.SelectedValue, Decimal))
            If datasetMercadoria.T0100086.Rows.Count > 0 Then
                lblMercadoria.Text = observacaoMercadoria(datasetMercadoria.T0100086(0))
            End If
            RaiseEvent MercadoriaAlterado(.SelectedItem)
        End With
        Util.AdicionaJsFocus(Me.Page, cmbNomeMercadoria)
    End Sub

    Private Sub txtCodigoMercadoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoMercadoria.TextChanged
        lblMercadoria.Text = ""
        txtNomeMercadoria.Text = String.Empty
        If Not IsNumeric(txtCodigoMercadoria.Text) Then
            If txtCodigoMercadoria.Text = String.Empty Then
                Util.AdicionaJsAlert(Me.Page, "Código de Mercadoria inválido", True)
                cmbNomeMercadoria.Items.Clear()
                txtCodigoMercadoria.Text = String.Empty
                Util.AdicionaJsFocus(Me.Page, txtCodigoMercadoria)
            End If
            RaiseEvent MercadoriaAlterado(Nothing)
            Exit Sub
        End If
        Me.Codigo_ValueChange(New WebControl() {txtCodigoMercadoria, txtNomeMercadoria, cmbNomeMercadoria})
        If txtCodigoMercadoria.Text = String.Empty Then
            cmbNomeMercadoria.Items.Clear()
        End If
        Util.AdicionaJsFocus(Me.Page, cmbNomeMercadoria)
    End Sub

    Private Sub btnBuscarMercadoria_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscarMercadoria.Click
        lblMercadoria.Text = ""
        Me.BuscarMercadoria_Click(New WebControl() {txtCodigoMercadoria, txtNomeMercadoria, cmbNomeMercadoria})
    End Sub

#End Region

#Region "Métodos"

    Public Sub setFocus()
        Util.AdicionaJsFocus(Me.Page, txtCodigoMercadoria)
    End Sub

    Private Sub BuscarMercadoria_Click(ByVal Ctrls As WebControl())
        Dim flagMostrarCombo As Boolean = False

        ' 0 = campo de codigo 
        ' 1 = txt nome Mercadoria 
        ' 2 = ddl Mercadoria 

        If Ctrls(1).Visible Then
            If CType(Ctrls(1), Infragistics.WebUI.WebDataInput.WebTextEdit).Text.Trim.Length < 3 Then
                lblMercadoria.Text = ""
                Page.RegisterStartupScript("Alerta", "<script>alert('É obrigatório digitar no mínimo 3 caracteres do nome antes de pesquisar.');</script>")
                Exit Sub
            End If

            Dim datasetMercadoria As wsAcoesComerciais.DatasetMercadoria = Controller.ObterMercadoriaPorAtributos(1, 0, 0, 0, String.Empty, String.Empty, 0, 0, 0, 3, Me.txtNomeMercadoria.Text, String.Empty, 3, 0)

            If datasetMercadoria.T0100086.Rows.Count > 0 Then
                lblMercadoria.Text = observacaoMercadoria(datasetMercadoria.T0100086(0))
                carregarCombo(datasetMercadoria, cmbNomeMercadoria, Nothing)
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
                RaiseEvent MercadoriaAlterado(CType(Ctrls(2), DropDownList).SelectedItem)
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

        If cmbNomeMercadoria.Visible Then
            Util.AdicionaJsFocus(Me.Page, cmbNomeMercadoria)
        ElseIf txtNomeMercadoria.Visible Then
            Util.AdicionaJsFocus(Me.Page, txtNomeMercadoria)
        End If

    End Sub

    Private Sub Codigo_ValueChange(ByVal Ctrls As WebControl())
        Dim flagMostrarCombo As Boolean = False

        If Not (IsNumeric(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text)) Then Exit Sub

        Dim datasetMercadoria As wsAcoesComerciais.DatasetMercadoria = _
            Controller.ObterMercadoriaPorChave(1, CType(Me.txtCodigoMercadoria.Text, Decimal))


        If datasetMercadoria.T0100086.Rows.Count > 0 Then
            lblMercadoria.Text = observacaoMercadoria(datasetMercadoria.T0100086(0))
            flagMostrarCombo = True
            With CType(Ctrls(2), DropDownList)
                carregarCombo(datasetMercadoria, CType(Ctrls(2), DropDownList), Nothing)
                cmbNomeMercadoria_SelectedIndexChanged(Nothing, Nothing)
            End With
            ' hipotese para todos os Mercadorias
        ElseIf CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text.Equals("0") Then
            CType(Ctrls(2), DropDownList).Items.Clear()
            CType(Ctrls(2), DropDownList).Items.Add(New ListItem(" Todos ", "0"))
            cmbNomeMercadoria_SelectedIndexChanged(Nothing, Nothing)
        Else
            CType(Ctrls(2), DropDownList).Items.Clear()
            txtNomeMercadoria.Text = String.Empty

            If IsNumeric(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text) Then
                If Convert.ToDecimal(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text) > 0 Then
                    txtCodigoMercadoria.Text = String.Empty
                    Util.AdicionaJsAlert(Me.Page, "Código de Mercadoria inválido", True)
                End If
            End If

            'RaiseEvent MercadoriaAlterado(New ListItem("NÃO ENCONTRADO", CLng(CType(Ctrls(0), System.Web.UI.WebControls.TextBox).Text).ToString))
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
        Util.HabilitaControles(New WebControl() {txtCodigoMercadoria, txtNomeMercadoria, cmbNomeMercadoria, btnBuscarMercadoria}, True)
        Util.LimpaControles(New WebControl() {txtCodigoMercadoria, txtNomeMercadoria, cmbNomeMercadoria})
        cmbNomeMercadoria.Visible = False
        txtNomeMercadoria.Visible = True
    End Sub

    Public Sub SelecionarMercadoria(ByVal codMercadoria As Decimal)
        Me.ReinicializaControle()
        txtCodigoMercadoria.Text = codMercadoria.ToString
        txtCodigoMercadoria_TextChanged(Nothing, Nothing)
    End Sub

    Public Sub SelecionarVazio()
        txtCodigoMercadoria.Text = String.Empty
        cmbNomeMercadoria.Items.Clear()
        lblMercadoria.Visible = False
    End Sub

    Public Sub PesquisarMercadoria(ByVal NomeMercadoria As String)
        Me.ReinicializaControle()
        txtNomeMercadoria.Text = NomeMercadoria.Trim()
        btnBuscarMercadoria_Click(Nothing, Nothing)
    End Sub

    Private Sub carregarCombo(ByRef ds As wsAcoesComerciais.DatasetMercadoria, ByRef cmb As DropDownList, ByRef listItemExtra As ListItem)
        With cmb
            .Items.Clear()
            For Each linha As wsAcoesComerciais.DatasetMercadoria.T0100086Row In ds.T0100086.Select("", "DESMER")
                .Items.Add(New ListItem(linha.DESMER, linha.CODMER.ToString))
            Next
            If Not (listItemExtra Is Nothing) Then
                .Items.Insert(0, listItemExtra)
            End If
        End With
    End Sub

    Private Function observacaoMercadoria(ByVal T0100086Row As wsAcoesComerciais.DatasetMercadoria.T0100086Row) As String

        'Verifica se a mercadoria é importada
        Dim flagMercadoriaImportada As Boolean = False
        If Not T0100086Row.IsNull("INDORIMER") Then
            flagMercadoriaImportada = (T0100086Row.INDORIMER = 1)
        End If

        'Verifica se a mercadoria esta desativada
        Dim flagMercadoriaDesativada As Boolean = False
        If Not T0100086Row.IsNull("DATDSTMER") Then
            flagMercadoriaDesativada = True
        End If

        'Prepara o retorno
        Dim result As String
        If flagMercadoriaDesativada Then
            result = "Mercadoria Desativada"
        ElseIf flagMercadoriaImportada Then
            result = "Mercadoria Importada"
        End If

        Return result
    End Function


#End Region

    
End Class