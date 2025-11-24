Public Class GeraisListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetParametroGestaoAcaoComercial1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetParametroGestaoAcaoComercial
        CType(Me.DatasetParametroGestaoAcaoComercial1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetParametroGestaoAcaoComercial1
        '
        Me.DatasetParametroGestaoAcaoComercial1.DataSetName = "DatasetParametroGestaoAcaoComercial"
        Me.DatasetParametroGestaoAcaoComercial1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetParametroGestaoAcaoComercial1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetParametroGestaoAcaoComercial1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetParametroGestaoAcaoComercial
    'Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm



    ''NOTE: The following placeholder declaration is required by the Web Form Designer.
    ''Do not delete or move it.
    'Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Not IsPostBack) Then
                DatasetParametroGestaoAcaoComercial1.EnforceConstraints = False
                DatasetParametroGestaoAcaoComercial1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 1 'Consulta por CÓDIGO
                        DatasetParametroGestaoAcaoComercial1 = Controller.ObterParametrosGestaoAcaoComercial(1, Decimal.Parse(Request.QueryString("CodFilEmp")))
                    Case 2 'Consulta sem filtro (todos registros)
                        DatasetParametroGestaoAcaoComercial1 = Controller.ObterParametrosGestaoAcaoComercial(0, 0)
                End Select

                DatasetParametroGestaoAcaoComercial1.T0118074.DefaultView.Sort = "CodFilEmp"
                dtgListar.DataSource = DatasetParametroGestaoAcaoComercial1.T0118074.DefaultView
                dtgListar.DataBind()
                WSCAcoesComerciais.dsParametroGestãoAcaoComercial = DatasetParametroGestaoAcaoComercial1
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""Gerais.aspx?CodFilEmp=" & dtgListar.Items(e.Item.ItemIndex).Cells(2).Text() & """;" & vbCrLf)
                Response.Write("</script>" & vbCrLf)
            End If

        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub dtgListar_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgListar.PageIndexChanged
        Try
            Me.dtgListar.CurrentPageIndex = e.NewPageIndex

            'Select Case CInt(Request.QueryString("criterio"))
            '    Case 1 'Consulta por CÓDIGO
            '        DatasetParametroGestaoAcaoComercial1 = Controller.ObterParametrosGestaoAcaoComercial(1, Decimal.Parse(Request.QueryString("CodFilEmp")))
            '    Case 2 'Consulta sem filtro (todos registros)
            '        DatasetParametroGestaoAcaoComercial1 = Controller.ObterParametrosGestaoAcaoComercial(0, 0)
            'End Select

            DatasetParametroGestaoAcaoComercial1 = WSCAcoesComerciais.dsParametroGestãoAcaoComercial
            dtgListar.DataSource = DatasetParametroGestaoAcaoComercial1.T0118074.DefaultView
            dtgListar.DataBind()
        Catch ex As Exception
        End Try
    End Sub

End Class