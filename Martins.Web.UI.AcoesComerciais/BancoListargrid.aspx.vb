Public Class BancoListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetBanco1 = New Martins.Web.UI.AcoesComerciais.wsCobrancaBancaria.DatasetBanco
        CType(Me.DatasetBanco1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetBanco1
        '
        Me.DatasetBanco1.DataSetName = "DatasetBanco"
        Me.DatasetBanco1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetBanco1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetBanco1 As Martins.Web.UI.AcoesComerciais.wsCobrancaBancaria.DatasetBanco
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
                DatasetBanco1.EnforceConstraints = False
                DatasetBanco1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 0 'Nenum criterio
                        DatasetBanco1 = Controller.ObterBancos(0, "", 0, "", 0)
                        DatasetBanco1.T0100345.DefaultView.Sort = ("NOMBCO")
                    Case 1 'Consulta por CÓDIGO
                        DatasetBanco1 = Controller.ObterBanco(Decimal.Parse(Request.QueryString("CodBco")))
                        DatasetBanco1.T0100345.DefaultView.Sort = ("CODBCO")
                    Case 2 'Consulta por DESCRIÇÃO
                        DatasetBanco1 = Controller.ObterBancos(0, String.Empty, 0, Request.QueryString("NomBco"), 0)
                        DatasetBanco1.T0100345.DefaultView.Sort = ("NOMBCO")
                End Select

                dtgListar.DataSource = DatasetBanco1.T0100345.DefaultView
                dtgListar.DataBind()
                WSCAcoesComerciais.dsBanco = DatasetBanco1
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""Banco.aspx?CodBco=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & """;" & vbCrLf)
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
            '        DatasetBanco1 = Controller.ObterBanco(Decimal.Parse(Request.QueryString("CodBco")))
            '    Case 2 'Consulta por DESCRIÇÃO
            '        DatasetBanco1 = Controller.ObterBancos(0, String.Empty, 0, Request.QueryString("NomBco"), 0)
            'End Select

            DatasetBanco1 = WSCAcoesComerciais.dsBanco
            dtgListar.DataSource = DatasetBanco1.T0100345.DefaultView
            dtgListar.DataBind()
        Catch ex As Exception
        End Try
    End Sub

End Class