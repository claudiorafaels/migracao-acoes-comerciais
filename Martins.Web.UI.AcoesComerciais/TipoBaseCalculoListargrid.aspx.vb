Public Class TipoBaseCalculoListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoBaseCalculo1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoBaseCalculo
        CType(Me.DatasetTipoBaseCalculo1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoBaseCalculo1
        '
        Me.DatasetTipoBaseCalculo1.DataSetName = "DatasetTipoBaseCalculo"
        Me.DatasetTipoBaseCalculo1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoBaseCalculo1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetTipoBaseCalculo1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoBaseCalculo
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
                DatasetTipoBaseCalculo1.EnforceConstraints = False
                DatasetTipoBaseCalculo1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 0 'Nenhum
                        DatasetTipoBaseCalculo1 = Controller.ObterTiposBaseCalculo(String.Empty)
                        DatasetTipoBaseCalculo1.T0125003.DefaultView.Sort = "TIPBSECAL" '"DESBSECAL"
                    Case 1 'Consulta por DESCRIÇÃO
                        DatasetTipoBaseCalculo1 = Controller.ObterTiposBaseCalculo(Request.QueryString("DESBSECAL"))
                        DatasetTipoBaseCalculo1.T0125003.DefaultView.Sort = "TIPBSECAL" '"DESBSECAL"
                    Case 2 'Consulta por CÓDIGO
                        DatasetTipoBaseCalculo1 = Controller.ObterTipoBaseCalculo(Decimal.Parse(Request.QueryString("TIPBSECAL")))
                        DatasetTipoBaseCalculo1.T0125003.DefaultView.Sort = "TIPBSECAL"
                End Select

                dtgListar.DataSource = DatasetTipoBaseCalculo1.T0125003.DefaultView
                dtgListar.DataBind()
                WSCAcoesComerciais.dsTipoBaseCalculo = DatasetTipoBaseCalculo1
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""TipoBaseCalculo.aspx?TIPBSECAL=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & """;" & vbCrLf)
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
            '    Case 1 'Consulta por DESCRIÇÃO
            '        DatasetTipoBaseCalculo1 = Controller.ObterTiposBaseCalculo(Request.QueryString("DESBSECAL"))
            '    Case 2 'Consulta por CÓDIGO
            '        DatasetTipoBaseCalculo1 = Controller.ObterTipoBaseCalculo(Decimal.Parse(Request.QueryString("TIPBSECAL")))
            'End Select

            DatasetTipoBaseCalculo1 = WSCAcoesComerciais.dsTipoBaseCalculo
            dtgListar.DataSource = DatasetTipoBaseCalculo1.T0125003.DefaultView
            dtgListar.DataBind()
        Catch ex As Exception
        End Try
    End Sub

End Class