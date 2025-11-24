Public Class AgenciaListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetAgencia1 = New Martins.Web.UI.AcoesComerciais.wsCobrancaBancaria.DatasetAgencia
        CType(Me.DatasetAgencia1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetAgencia1
        '
        Me.DatasetAgencia1.DataSetName = "DatasetAgencia"
        Me.DatasetAgencia1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetAgencia1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetAgencia1 As Martins.Web.UI.AcoesComerciais.wsCobrancaBancaria.DatasetAgencia
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
                DatasetAgencia1.EnforceConstraints = False
                DatasetAgencia1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 1 'Consulta por CÓDIGO AGENCIA
                        DatasetAgencia1 = Controller.ObterAgencias(Decimal.Parse(Request.QueryString("CodAgeBco")), 0, 0, 0, String.Empty, String.Empty)
                        DatasetAgencia1.T0104413.DefaultView.Sort = ("CodBco")
                    Case 2 'Consulta por CÓDIGO BANCO
                        DatasetAgencia1 = Controller.ObterAgencias(0, Decimal.Parse(Request.QueryString("CodBco")), 0, 0, String.Empty, String.Empty)
                        DatasetAgencia1.T0104413.DefaultView.Sort = ("CodAgeBco")
                    Case 3 'Consulta por NOME AGENCIA
                        DatasetAgencia1 = Controller.ObterAgencias(0, 0, 0, 0, String.Empty, Request.QueryString("NomAgeBco"))
                        DatasetAgencia1.T0104413.DefaultView.Sort = ("NomAgeBco")
                End Select


                dtgListar.DataSource = DatasetAgencia1.T0104413.DefaultView
                dtgListar.DataBind()
                WSCAcoesComerciais.dsAgencia = DatasetAgencia1

            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""Agencia.aspx?CodBco=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & "&CodAgeBco=" & dtgListar.Items(e.Item.ItemIndex).Cells(2).Text() & """;" & vbCrLf)
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
            '    Case 1 'Consulta por CÓDIGO AGENCIA
            '        DatasetAgencia1 = Controller.ObterAgencias(Decimal.Parse(Request.QueryString("CodAgeBco")), 0, 0, 0, String.Empty, String.Empty)
            '    Case 2 'Consulta por CÓDIGO BANCO
            '        DatasetAgencia1 = Controller.ObterAgencias(0, Decimal.Parse(Request.QueryString("CodBco")), 0, 0, String.Empty, String.Empty)
            '    Case 3 'Consulta por NOME AGENCIA
            '        DatasetAgencia1 = Controller.ObterAgencias(0, 0, 0, 0, String.Empty, Request.QueryString("NomAgeBco"))
            'End Select

            DatasetAgencia1 = WSCAcoesComerciais.dsAgencia
            dtgListar.DataSource = DatasetAgencia1.T0104413.DefaultView
            dtgListar.DataBind()
        Catch ex As Exception
        End Try
    End Sub

End Class