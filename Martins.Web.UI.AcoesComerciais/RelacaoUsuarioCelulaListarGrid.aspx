<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RelacaoUsuarioCelulaListarGrid.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.RelacaoUsuarioCelulaListarGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sistemas</title>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Imagens/styles.css" type="text/css" rel="stylesheet">
		<style type="text/css">BODY { MARGIN: 0px; BACKGROUND-COLOR: #ffffff }
		</style>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:datagrid id="dtgListar" runat="server" Width="800px" Font-Size="X-Small" AutoGenerateColumns="False"
				CssClass=" " AllowPaging="True" DataSource="<%# dsUsuarioXCelula %>" DataMember="T0144920">
				<AlternatingItemStyle CssClass="row4"></AlternatingItemStyle>
				<ItemStyle CssClass="row3"></ItemStyle>
				<HeaderStyle CssClass="header1"></HeaderStyle>
				<Columns>
					<asp:TemplateColumn>
						<HeaderStyle Width="10px"></HeaderStyle>
						<ItemTemplate>
							<asp:ImageButton id="imbExcluir" runat="server" ImageUrl="../Imagens/office/apagar.gif" CommandName="grdExcluir"></asp:ImageButton>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="CODDIVCMP" SortExpression="CODDIVCMP" HeaderText="CODDIVCMP"></asp:BoundColumn>
					<asp:BoundColumn DataField="NOMACSUSRSIS" SortExpression="NOMACSUSRSIS" HeaderText="USU&#193;RIO"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="C&#201;LULA">
						<ItemTemplate>
							<asp:Label id=Label1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem.Row.T0118570Row, "DESDIVCMP") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle VerticalAlign="Middle" Height="20px" HorizontalAlign="Center" PageButtonCount="9"
					CssClass=" " Mode="NumericPages"></PagerStyle>
			</asp:datagrid>&nbsp;
		</form>
	</body>
</HTML>
