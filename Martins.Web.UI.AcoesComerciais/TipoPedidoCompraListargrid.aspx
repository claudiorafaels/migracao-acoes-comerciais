<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TipoPedidoCompraListargrid.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.TipoPedidoCompraListarGrid" %>
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
					CssClass=" " DataKeyField="TIPPEDCMP" PageSize="19" AllowPaging="True">
					<AlternatingItemStyle CssClass="row4"></AlternatingItemStyle>
					<ItemStyle CssClass="row3"></ItemStyle>
					<HeaderStyle CssClass="header1"></HeaderStyle>
					<Columns>
						<asp:ButtonColumn Text="&lt;img src=../Imagens/office/s_b_dail.gif alt=Detalhe border=0&gt;" CommandName="Link">
							<HeaderStyle Width="20px"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						</asp:ButtonColumn>
						<asp:BoundColumn DataField="TIPPEDCMP" SortExpression="TIPPEDCMP" HeaderText="CODIGO">
							<HeaderStyle Width="80px"></HeaderStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="DESTIPPEDCMP" SortExpression="DESTIPPEDCMP" HeaderText="DESCRI&#199;&#195;O"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="CALC.PRE&#199;O MERC.">
							<HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<ItemTemplate>
								<asp:Label id=Label1 runat="server" Text='<%# IIf(DataBinder.Eval(Container, "DataItem.FLGCALPCOMER") = 1 , "S", "N") %>'>
								</asp:Label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox id=TextBox1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FLGCALPCOMER") %>'>
								</asp:TextBox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="CL&#193;USULA">
							<ItemTemplate>
								<asp:Label id=Label2 runat="server" Text='<%# DataBinder.Eval(Container.DataItem.Row.T0124953Row, "DESCSLCTTFRN") %>'>
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
					<PagerStyle VerticalAlign="Middle" Height="20px" HorizontalAlign="Center" PageButtonCount="9"
						CssClass=" " Mode="NumericPages"></PagerStyle>
				</asp:datagrid>
			</form>
		</P>
	</body>
</HTML>
