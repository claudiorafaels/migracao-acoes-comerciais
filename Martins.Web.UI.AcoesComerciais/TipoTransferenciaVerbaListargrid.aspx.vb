Public Class TipoTransferenciaVerbaListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetTipoTransferenciaValoresAcoesComerciais1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoTransferenciaValoresAcoesComerciais
        CType(Me.DatasetTipoTransferenciaValoresAcoesComerciais1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetTipoTransferenciaValoresAcoesComerciais1
        '
        Me.DatasetTipoTransferenciaValoresAcoesComerciais1.DataSetName = "DatasetTipoTransferenciaValoresAcoesComerciais"
        Me.DatasetTipoTransferenciaValoresAcoesComerciais1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetTipoTransferenciaValoresAcoesComerciais1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetTipoTransferenciaValoresAcoesComerciais1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetTipoTransferenciaValoresAcoesComerciais
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
                DatasetTipoTransferenciaValoresAcoesComerciais1.EnforceConstraints = False
                DatasetTipoTransferenciaValoresAcoesComerciais1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 0 'Nenhum
                        DatasetTipoTransferenciaValoresAcoesComerciais1 = Controller.ObterTiposTransferenciasValoresAcoesComerciais(0, String.Empty, 0)
                        DatasetTipoTransferenciaValoresAcoesComerciais1.T0135033.DefaultView.Sort = "CODTIPTRNVLRACOCMC" '("TIPDSNDSCBNF")
                    Case 1 'Consulta por DESCRIÇÃO
                        DatasetTipoTransferenciaValoresAcoesComerciais1 = Controller.ObterTiposTransferenciasValoresAcoesComerciais(0, Request.QueryString("DESTIPTRNVLRACOCMC"), 0)
                        DatasetTipoTransferenciaValoresAcoesComerciais1.T0135033.DefaultView.Sort = "CODTIPTRNVLRACOCMC" '"DESTIPTRNVLRACOCMC"
                    Case 2 'Consulta por CÓDIGO
                        DatasetTipoTransferenciaValoresAcoesComerciais1 = Controller.ObterTipoTransferenciaValoresAcoesComerciais(Decimal.Parse(Request.QueryString("CODTIPTRNVLRACOCMC")))
                        DatasetTipoTransferenciaValoresAcoesComerciais1.T0135033.DefaultView.Sort = "CODTIPTRNVLRACOCMC"
                    Case 3 'Consulta por EMPENHO
                        DatasetTipoTransferenciaValoresAcoesComerciais1 = Controller.ObterTiposTransferenciasValoresAcoesComerciais(0, String.Empty, Decimal.Parse(Request.QueryString("TIPDSNDSCBNF")))
                        DatasetTipoTransferenciaValoresAcoesComerciais1.T0135033.DefaultView.Sort = "CODTIPTRNVLRACOCMC" '"TIPDSNDSCBNF"
                End Select

                dtgListar.DataSource = DatasetTipoTransferenciaValoresAcoesComerciais1.T0135033.DefaultView
                dtgListar.DataBind()
                WSCAcoesComerciais.dsTipoTransferenciaValoresAcoesComerciais = DatasetTipoTransferenciaValoresAcoesComerciais1
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""TipoTransferenciaVerba.aspx?CODTIPTRNVLRACOCMC=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & """;" & vbCrLf)
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
            '        DatasetTipoTransferenciaValoresAcoesComerciais1 = Controller.ObterTiposTransferenciasValoresAcoesComerciais(0, Request.QueryString("DESTIPTRNVLRACOCMC"), 0)
            '    Case 2 'Consulta por CÓDIGO
            '        DatasetTipoTransferenciaValoresAcoesComerciais1 = Controller.ObterTipoTransferenciaValoresAcoesComerciais(Decimal.Parse(Request.QueryString("CODTIPTRNVLRACOCMC")))
            '    Case 3 'Consulta por EMPENHO
            '        DatasetTipoTransferenciaValoresAcoesComerciais1 = Controller.ObterTiposTransferenciasValoresAcoesComerciais(0, String.Empty, Decimal.Parse(Request.QueryString("TIPDSNDSCBNF")))
            'End Select

            DatasetTipoTransferenciaValoresAcoesComerciais1 = WSCAcoesComerciais.dsTipoTransferenciaValoresAcoesComerciais
            dtgListar.DataSource = DatasetTipoTransferenciaValoresAcoesComerciais1.T0135033.DefaultView
            dtgListar.DataBind()
        Catch ex As Exception
        End Try
    End Sub

End Class