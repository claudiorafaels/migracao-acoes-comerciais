<%@ Page Language="vb" AutoEventWireup="false" Codebehind="FormaPagamentoListargrid.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.FormaPagamentoListarGrid" %>
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
					CssClass=" " DataKeyField="TIPFRMDSCBNF" PageSize="20" AllowPaging="True">
					<AlternatingItemStyle CssClass="row4"></AlternatingItemStyle>
					<ItemStyle CssClass="row3"></ItemStyle>
					<HeaderStyle CssClass="header1"></HeaderStyle>
					<Columns>
						<asp:ButtonColumn Text="&lt;img src=../Imagens/office/s_b_dail.gif alt=Detalhe border=0&gt;" CommandName="Link">
							<HeaderStyle Width="10px"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						</asp:ButtonColumn>
						<asp:BoundColumn DataField="TIPFRMDSCBNF" SortExpression="TIPFRMDSCBNF" HeaderText="CODIGO"></asp:BoundColumn>
						<asp:BoundColumn DataField="DESFRMDSCBNF" SortExpression="DESFRMDSCBNF" HeaderText="DESC. FORMA"></asp:BoundColumn>
						<asp:BoundColumn DataField="FLGCFANOTFSC" SortExpression="FLGCFANOTFSC" HeaderText="CONF. C/ NF">
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="FLGPTCVLRTIT" SortExpression="FLGPTCVLRTIT" HeaderText="COMPOE VALOR TIT.">
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
						</asp:BoundColumn>
						<asp:TemplateColumn HeaderText="Receita/CMV">
							<HeaderStyle HorizontalAlign="Center" VerticalAlign="Top"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
							<ItemTemplate>
								<asp:Label id=Label1 runat="server" Text='<%# IIF(DataBinder.Eval(Container, "DataItem.INDTIPDSNRCTCSTMER") = 1, "S", "N") %>'>
								</asp:Label>
							</ItemTemplate>
							<FooterStyle HorizontalAlign="Center" VerticalAlign="Top"></FooterStyle>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="PERDSCIMD" SortExpression="PERDSCIMD" HeaderText="% IMEDIATO" DataFormatString="{0:0.00}">
							<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="PERDSCMNS" SortExpression="PERDSCMNS" HeaderText="% MENSAL" DataFormatString="{0:0.00}">
							<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="QDEMNMDIABLQFRN" SortExpression="QDEMNMDIABLQFRN" HeaderText="TOLER&#194;NCIA"
							DataFormatString="{0:0}">
							<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
					</Columns>
					<PagerStyle VerticalAlign="Middle" Height="20px" HorizontalAlign="Center" PageButtonCount="9"
						CssClass=" " Mode="NumericPages"></PagerStyle>
				</asp:datagrid>
			</form>
		</P>
	</body>
</HTML>
