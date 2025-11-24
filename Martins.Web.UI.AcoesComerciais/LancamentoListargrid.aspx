<%@ Page Language="vb" AutoEventWireup="false" Codebehind="LancamentoListargrid.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.LancamentoListarGrid" %>
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
					CssClass=" " PageSize="20" AllowPaging="True">
					<AlternatingItemStyle CssClass="row4"></AlternatingItemStyle>
					<ItemStyle CssClass="row3"></ItemStyle>
					<HeaderStyle CssClass="header1"></HeaderStyle>
					<Columns>
						<asp:ButtonColumn Text="&lt;img src=../Imagens/office/s_b_dail.gif alt=Detalhe border=0&gt;" CommandName="Link">
							<HeaderStyle Width="20px"></HeaderStyle>
							<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
						</asp:ButtonColumn>
						<asp:BoundColumn DataField="NUMSEQLMT" SortExpression="NUMSEQLMT" HeaderText="N&#218;MERO">
							<HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="CODFRN" SortExpression="CODFRN" HeaderText="COD. FOR.">
							<HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
						</asp:BoundColumn>
						<asp:TemplateColumn HeaderText="NOME FORNECEDOR">
							<ItemStyle Wrap="False"></ItemStyle>
							<ItemTemplate>
								<asp:Label id=Label1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem.Row.T0100426Row, "NOMFRN") %>'>
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="TIPDSNDSCBNF" SortExpression="TIPDSNDSCBNF" HeaderText="EMPENHO">
							<HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="DATREFLMT" SortExpression="DATREFLMT" HeaderText="DATA" DataFormatString="{0:d}">
							<HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="VLRLMTCTB" SortExpression="VLRLMTCTB" HeaderText="VALOR" DataFormatString="{0:N2}">
							<HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="DESHSTLMT" SortExpression="DESHSTLMT" HeaderText="HIST&#211;RICO">
							<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="CODGDC" SortExpression="CODGDC" HeaderText="D/C"></asp:BoundColumn>
					</Columns>
					<PagerStyle VerticalAlign="Middle" Height="20px" HorizontalAlign="Center" PageButtonCount="9"
						CssClass=" " Mode="NumericPages"></PagerStyle>
				</asp:datagrid>&nbsp;
			</form>
		</P>
	</body>
</HTML>