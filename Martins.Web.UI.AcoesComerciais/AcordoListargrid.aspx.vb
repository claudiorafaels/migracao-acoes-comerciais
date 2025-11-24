Public Class AcordoListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetAcordo1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetAcordo
        CType(Me.DatasetAcordo1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetAcordo1
        '
        Me.DatasetAcordo1.DataSetName = "DatasetAcordo"
        Me.DatasetAcordo1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetAcordo1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents DatasetAcordo1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetAcordo
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
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
                DatasetAcordo1.EnforceConstraints = False
                DatasetAcordo1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 1 '1 Período
                        DatasetAcordo1 = Controller.ObterAcordos(0, 0, 0, 0, 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, CDate(Request.QueryString("DATNGCPMSInicial")), CDate(Request.QueryString("DATNGCPMSFinal")), String.Empty, 0)
                    Case 2 '2 Data Previsão
                        DatasetAcordo1 = Controller.ObterAcordos(0, 0, 0, 0, 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, CDate(Request.QueryString("DATNGCPMS")), Nothing, Nothing, String.Empty, 0)
                    Case 3 '3 Período/Fornecedor
                        DatasetAcordo1 = Controller.ObterAcordos(0, 0, Decimal.Parse(Request.QueryString("CODFRN")), 0, 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, CDate(Request.QueryString("DATNGCPMSInicial")), CDate(Request.QueryString("DATNGCPMSFinal")), String.Empty, 0)
                    Case 4 '4 Número
                        DatasetAcordo1 = Controller.ObterAcordos(0, 0, 0, Decimal.Parse(Request.QueryString("CODPMS")), 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, String.Empty, 0)
                End Select

                DatasetAcordo1.T0118058.DefaultView.Sort = "DATNGCPMS"
                dtgListar.DataSource = DatasetAcordo1.T0118058.DefaultView
                dtgListar.DataBind()
                WSCAcoesComerciais.dsAcordo = DatasetAcordo1

                'DatasetAcordo1.T0118058(0).T0100426Row.NOMFRN

            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""Acordo.aspx?CODFILEMP=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & "&CODPMS=" & dtgListar.Items(e.Item.ItemIndex).Cells(2).Text() & "&DATNGCPMS=" & dtgListar.Items(e.Item.ItemIndex).Cells(3).Text() & """;" & vbCrLf)
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
            '    Case 1 '1 Período
            '        DatasetAcordo1 = Controller.ObterAcordos(0, 0, 0, 0, 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, CDate(Request.QueryString("DATNGCPMSInicial")), CDate(Request.QueryString("DATNGCPMSFinal")), String.Empty)
            '    Case 2 '2 Data Previsão
            '        DatasetAcordo1 = Controller.ObterAcordos(0, 0, 0, 0, 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, CDate(Request.QueryString("DATNGCPMS")), Nothing, Nothing, String.Empty)
            '    Case 3 '3 Período/Fornecedor
            '        DatasetAcordo1 = Controller.ObterAcordos(0, 0, Decimal.Parse(Request.QueryString("CODFRN")), 0, 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, CDate(Request.QueryString("DATNGCPMSInicial")), CDate(Request.QueryString("DATNGCPMSFinal")), String.Empty)
            '    Case 4 '4 Número
            '        DatasetAcordo1 = Controller.ObterAcordos(0, 0, 0, Decimal.Parse(Request.QueryString("CODPMS")), 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, String.Empty)
            'End Select

            DatasetAcordo1 = WSCAcoesComerciais.dsAcordo
            dtgListar.DataSource = DatasetAcordo1.T0118058.DefaultView
            dtgListar.DataBind()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtgListar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtgListar.SelectedIndexChanged

    End Sub
End Class