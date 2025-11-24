<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ContratoListargrid.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.ContratoListarGrid" %>
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
				<asp:datagrid id="dtgListar" runat="server" AllowPaging="True" DataKeyField="NUMCTTFRN" CssClass=" "
					AutoGenerateColumns="False" Font-Size="X-Small" Width="800px" PageSize="20">
					<AlternatingItemStyle CssClass="row4"></AlternatingItemStyle>
					<ItemStyle CssClass="row3"></ItemStyle>
					<HeaderStyle CssClass="header1"></HeaderStyle>
					<Columns>
						<asp:ButtonColumn Text="&lt;img src=../Imagens/office/s_b_dail.gif alt=Detalhe border=0&gt;" CommandName="Link">
							<HeaderStyle Width="20px"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						</asp:ButtonColumn>
						<asp:BoundColumn DataField="NUMCTTFRN" SortExpression="NUMCTTFRN" HeaderText="CONTRATO"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="CODFRN" SortExpression="CODFRN" HeaderText="CODIGO FORNECEDOR"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="FORNECEDOR">
							<ItemTemplate>
								<asp:Label id=Label1 runat="server" Text='<%# obterNOMFRN(DataBinder.Eval(Container, "DataItem.CODFRN")) %>'>
								</asp:Label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox id=TextBox1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CODFRN") %>'>
								</asp:TextBox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="DATCADCTTFRN" SortExpression="DATCADCTTFRN" HeaderText="DATA CADASTRO"
							DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
						<asp:BoundColumn DataField="DATINIPODVGRCTTFRN" SortExpression="DATINIPODVGRCTTFRN" HeaderText="PER&#205;ODO VIG."
							DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
						<asp:BoundColumn DataField="DATVNCCTTFRN" SortExpression="DATVNCCTTFRN" HeaderText="VENCIMENTO" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
					</Columns>
					<PagerStyle VerticalAlign="Middle" Height="20px" HorizontalAlign="Center" PageButtonCount="9"
						CssClass=" " Mode="NumericPages"></PagerStyle>
				</asp:datagrid></form>
		</P>
	</body>
</HTML>
