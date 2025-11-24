Public Class EmpenhoListarGrid
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DatasetEmpenho1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetEmpenho
        Me.DatasetVerbaCarimbo1 = New Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetVerbaCarimbo
        CType(Me.DatasetEmpenho1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetVerbaCarimbo1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DatasetEmpenho1
        '
        Me.DatasetEmpenho1.DataSetName = "DatasetEmpenho"
        Me.DatasetEmpenho1.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'DatasetVerbaCarimbo1
        '
        Me.DatasetVerbaCarimbo1.DataSetName = "DatasetVerbaCarimbo"
        Me.DatasetVerbaCarimbo1.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.DatasetEmpenho1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetVerbaCarimbo1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents DatasetEmpenho1 As Martins.Web.UI.AcoesComerciais.wsAcoesComerciais.DatasetEmpenho
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
                DatasetEmpenho1.EnforceConstraints = False
                DatasetEmpenho1.Clear()

                Select Case CInt(Request.QueryString("criterio"))
                    Case 0 'Nenhum
                        DatasetEmpenho1 = Controller.ObterEmpenhos("", "", "", 0, "")
                        DatasetEmpenho1.T0109059.DefaultView.Sort = ("TIPDSNDSCBNF")
                    Case 1 'Consulta por CÓDIGO
                        DatasetEmpenho1 = Controller.ObterEmpenho(Decimal.Parse(Request.QueryString("TipDsnDscBnf")))
                        DatasetEmpenho1.T0109059.DefaultView.Sort = ("TIPDSNDSCBNF")
                    Case 2 'Consulta por DESCRIÇÃO
                        DatasetEmpenho1 = Controller.ObterEmpenhos(String.Empty, String.Empty, String.Empty, 0, Request.QueryString("DesDsnDscBnf"))
                        DatasetEmpenho1.T0109059.DefaultView.Sort = ("TIPDSNDSCBNF")
                End Select




                'DatasetEmpenho1.T0109059.DefaultView.Sort = ("TIPDSNDSCBNF")
                'dtgListar.DataSource = DatasetEmpenho1.T0109059.Select("", "TIPDSNDSCBNF")
                dtgListar.DataSource = DatasetEmpenho1.T0109059.DefaultView
                dtgListar.DataMember = "T0109059"

                dtgListar.DataBind()
                WSCAcoesComerciais.dsEmpenho = DatasetEmpenho1
                Me.configuraGrd()

            End If
        Catch ex As Exception
            Controller.TrataErro(Me.Page, ex)
        End Try

    End Sub
    Private Sub configuraGrd()
        Dim TIPDSNDSCBNF As Decimal

        For i As Integer = 0 To dtgListar.Items.Count - 1
            Dim lblDestinoVerba As Label = CType(Me.dtgListar.Items(i).FindControl("lblDestinoVerba"), Label)
            TIPDSNDSCBNF = CType(Me.dtgListar.Items(i).Cells(1).Text, Decimal)
            If Not WSCAcoesComerciais.dsEmpenho.T0109059.FindByTIPDSNDSCBNF(TIPDSNDSCBNF) Is Nothing Then
                Select Case WSCAcoesComerciais.dsEmpenho.T0109059.FindByTIPDSNDSCBNF(TIPDSNDSCBNF).INDDSNVBAMCO
                    Case 1
                        lblDestinoVerba.Text = "PREÇO"
                    Case 2
                        lblDestinoVerba.Text = "MARGEM"
                    Case 0
                        lblDestinoVerba.Text = ""
                End Select
            End If
        Next
    End Sub

    Private Sub dtgListar_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListar.ItemCommand
        Try
            If e.CommandName = "Link" Then
                Response.Write("<script language=javascript>" & vbCrLf)
                Response.Write("window.parent.location.href = ""Empenho.aspx?TIPDSNDSCBNF=" & dtgListar.Items(e.Item.ItemIndex).Cells(1).Text() & """;" & vbCrLf)
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
            '        DatasetEmpenho1 = Controller.ObterEmpenho(Decimal.Parse(Request.QueryString("TipDsnDscBnf")))
            '    Case 2 'Consulta por DESCRIÇÃO
            '        DatasetEmpenho1 = Controller.ObterEmpenhos(String.Empty, String.Empty, String.Empty, 0, Request.QueryString("DesDsnDscBnf"))
            'End Select

            DatasetEmpenho1 = WSCAcoesComerciais.dsEmpenho
            dtgListar.DataSource = DatasetEmpenho1.T0109059.DefaultView
            dtgListar.DataBind()
            Me.configuraGrd()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtgListar_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgListar.ItemDataBound

        Select Case e.Item.ItemType
            Case ListItemType.Item, ListItemType.AlternatingItem
                Dim dsObjetivo As String
                If (e.Item.Cells(13).Text.Trim() <> "0") Then


                    DatasetVerbaCarimbo1 = Controller.ObterTiposObjetivoVerba("", e.Item.Cells(13).Text)



                    If DatasetVerbaCarimbo1.CADOBJDSNVBA.Rows.Count > 0 Then
                        dsObjetivo = DatasetVerbaCarimbo1.CADOBJDSNVBA.Rows(0)("DESOBJDSNVBA").ToString()
                        '11
                        CType(e.Item.Cells(11).FindControl("lblObjetivo"), Label).Text = dsObjetivo.Trim()
                    Else
                        CType(e.Item.Cells(11).FindControl("lblObjetivo"), Label).Text = ""
                    End If

                End If

                '12
                Try
                    CType(e.Item.Cells(12).FindControl("lblDataLimite"), Label).Text = Convert.ToDateTime(e.Item.Cells(14).Text).ToString("dd/MM/yyyy")
                Catch ex As Exception
                    CType(e.Item.Cells(12).FindControl("lblDataLimite"), Label).Text = ""
                End Try


        End Select

    End Sub
End Class