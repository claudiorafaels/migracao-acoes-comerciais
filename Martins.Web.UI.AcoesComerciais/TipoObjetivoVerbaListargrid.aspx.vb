Public Class TipoObjetivoVerbaListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetVerbaCarimbo1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetVerbaCarimbo
        CType(Me.DatasetVerbaCarimbo1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetVerbaCarimbo1
        '
        Me.DatasetVerbaCarimbo1.DataSetName = "DatasetVerbaCarimbo"
        Me.DatasetVerbaCarimbo1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetVerbaCarimbo1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents dtgListar As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatasetVerbaCarimbo1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetVerbaCarimbo
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
                DatasetVerbaCarimbo1.EnforceConstraints = False
                DatasetVerbaCarimbo1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 0 'Nenhum
                        DatasetVerbaCarimbo1 = Controller.ObterTiposObjetivoVerba("", "")
                    Case 1 'Consulta por DESCRIÇÃO
                        DatasetVerbaCarimbo1 = Controller.ObterTiposObjetivoVerba(Request.QueryString("nome").ToUpper(), "")
                    Case 2 'Consulta por CÓDIGO
                        DatasetVerbaCarimbo1 = Controller.ObterTiposObjetivoVerba("",Request.QueryString("codigo"))
                End Select



                Dim dv As DataView = DatasetVerbaCarimbo1.CADOBJDSNVBA.DefaultView
                dv.Sort = "TIPOBJDSNVBA"

                dtgListar.DataSource = dv
                dtgListar.DataBind()
                WSCAcoesComerciais.dstVerbaCarimboSelecionado = DatasetVerbaCarimbo1
            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try
    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""TipoObjetivoVerba.aspx?codigo=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & """;" & vbCrLf)
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
            '        DatasetVerbaCarimbo1 = Controller.ObterTiposAbrangencia(Request.QueryString("DesTipAbgTabPcoCtt"))
            '    Case 2 'Consulta por CÓDIGO
            '        DatasetVerbaCarimbo1 = Controller.ObterTipoAbrangencia(Decimal.Parse(Request.QueryString("TipAbgTabPcoCttFrn")))
            'End Select

            DatasetVerbaCarimbo1 = WSCAcoesComerciais.dstVerbaCarimboSelecionado
            dtgListar.DataSource = DatasetVerbaCarimbo1.CADOBJDSNVBA.DefaultView
            dtgListar.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtgListar_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgListar.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then

            If (e.Item.Cells(3).Text.Trim().Length > 0) Then

            End If


        End If
    End Sub
End Class