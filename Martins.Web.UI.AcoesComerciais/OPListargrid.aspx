<%@ Page Language="vb" AutoEventWireup="false" Codebehind="OPListargrid.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.OPListarGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sistemas</title>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Imagens/styles.css" type="text/css" rel="stylesheet">
		<style type="text/css">BODY { MARGIN: 0px; BACKGROUND-COLOR: #ffffff }
		</style>
	</HEAD>
	<body>
		<P>
			<form id="Form1" method="post" runat="server">
				<asp:datagrid id="dtgListar" runat="server" Width="800px" Font-Size="X-Small" AutoGenerateColumns="False"
					CssClass=" " DataKeyField="NUMORDPGTFRN" PageSize="20" AllowPaging="True">
					<AlternatingItemStyle CssClass="row4"></AlternatingItemStyle>
					<ItemStyle CssClass="row3"></ItemStyle>
					<HeaderStyle CssClass="header1"></HeaderStyle>
					<Columns>
						<asp:ButtonColumn Text="&lt;img src=../Imagens/office/s_b_dail.gif alt=Detalhe border=0&gt;" CommandName="Link">
							<HeaderStyle Width="20px"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						</asp:ButtonColumn>
						<asp:BoundColumn DataField="CODBCO" SortExpression="CODBCO" HeaderText="BANCO"></asp:BoundColumn>
						<asp:BoundColumn DataField="CODAGE" SortExpression="CODAGE" HeaderText="AGENCIA"></asp:BoundColumn>
						<asp:BoundColumn DataField="NUMORDPGTFRN" SortExpression="NUMORDPGTFRN" HeaderText="N&#218;MERO"></asp:BoundColumn>
						<asp:BoundColumn DataField="CODFRN" SortExpression="CODFRN" HeaderText="COD. FOR.">
							<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:TemplateColumn HeaderText="NOME FORNECEDOR">
							<ItemStyle Wrap="False"></ItemStyle>
							<ItemTemplate>
								<asp:Label id=Label1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem.Row.T0100426Row, "NOMFRN") %>'>
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="VLRORDPGT" SortExpression="VLRORDPGT" HeaderText="VALOR" DataFormatString="{0:###,###,##0.00}">
							<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="DATRCBORDPGT" SortExpression="DATRCBORDPGT" HeaderText="DATA RECEBIMENTO"
							DataFormatString="{0:dd/MM/yyyy}">
							<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
						</asp:BoundColumn>
					</Columns>
					<PagerStyle VerticalAlign="Middle" Height="20px" HorizontalAlign="Center" PageButtonCount="9"
						CssClass=" " Mode="NumericPages"></PagerStyle>
				</asp:datagrid>
			</form>
		</P>
	</body>
</HTML>
