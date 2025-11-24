<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EmpenhoListargrid.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.EmpenhoListarGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sistemas</title>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="../Imagens/styles.css" type="text/css" rel="stylesheet">
			<style type="text/css">BODY { BACKGROUND-COLOR: #ffffff; MARGIN: 0px }
	.upper { TEXT-TRANSFORM: uppercase }
	</style>
	</HEAD>
	<body>
		<P>
			<form id="Form1" method="post" runat="server">
				<asp:datagrid id=dtgListar runat="server" DataSource="<%# DatasetEmpenho1 %>" AllowPaging="True" PageSize="18" CssClass=" " AutoGenerateColumns="False" Font-Size="X-Small" Width="800px">
					<AlternatingItemStyle CssClass="row4"></AlternatingItemStyle>
					<ItemStyle CssClass="row3"></ItemStyle>
					<HeaderStyle CssClass="header1"></HeaderStyle>
					<Columns>
						<asp:ButtonColumn Text="&lt;img src=../Imagens/office/s_b_dail.gif alt=Detalhe border=0&gt;" CommandName="Link">
							<HeaderStyle Width="20px"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						</asp:ButtonColumn>
						<asp:BoundColumn DataField="TIPDSNDSCBNF" HeaderText="EMPENHO">
							<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="DESDSNDSCBNF" HeaderText="DESCRI&#199;&#195;O">
							<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
							<ItemStyle Wrap="False" HorizontalAlign="Left" CssClass="upper"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="FLGCALCST" HeaderText="ATUA CALC. CUSTO">
							<HeaderStyle HorizontalAlign="Center" Width="50px" VerticalAlign="Top"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="FLGCNTCRRFRN" HeaderText="ARMA- ZENA EM C/C">
							<HeaderStyle HorizontalAlign="Center" Width="50px" VerticalAlign="Top"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="FLGACOMCD" HeaderText="A&#199;&#195;O COMER- CIAL">
							<HeaderStyle HorizontalAlign="Center" Width="50px" VerticalAlign="Top"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="FLGUTZLCREMP" HeaderText="APRO- PRIA P/ LUCRO">
							<HeaderStyle HorizontalAlign="Center" Width="50px" VerticalAlign="Top"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="FLGCTBDSNDSC" SortExpression="FLGCTBDSNDSC" HeaderText="SALDO DISPO- NIVEL">
							<HeaderStyle HorizontalAlign="Center" Width="50px" VerticalAlign="Top"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
						</asp:BoundColumn>
						<asp:TemplateColumn HeaderText="Receita / CMV">
							<HeaderStyle HorizontalAlign="Center" VerticalAlign="Top"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<ItemTemplate>
								<asp:Label id=Label2 runat="server" Text='<%# IIF(DataBinder.Eval(Container, "DataItem.INDTIPDSNRCTCSTMER") = 1, "S", "N") %>'>
								</asp:Label>
							</ItemTemplate>
							<FooterStyle HorizontalAlign="Center"></FooterStyle>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="TIPO DE ALOCA&#199;&#195;O">
							<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
							<ItemTemplate>
								<asp:Label id=Label1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem.Row.T0151799Row, "DESALCVBAFRN") %>'>
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="DESTINO VERBA CARIMBO">
							<HeaderStyle HorizontalAlign="Center" Width="50px" VerticalAlign="Top"></HeaderStyle>
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
							<ItemTemplate>
								<asp:Label id="lblDestinoVerba" runat="server" Text=""></asp:Label>
							</ItemTemplate>
							<FooterStyle HorizontalAlign="Left"></FooterStyle>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="DESTINO VERBA">
							<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
							<ItemTemplate>
								<asp:Label id="lblObjetivo" runat="server" Text="">
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="DT LIMITE">
							<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
							<ItemTemplate>
								<asp:Label id="lblDataLimite" runat="server" Text="">
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
						
						
						<asp:BoundColumn DataField="TIPOBJDSNVBA" SortExpression="TIPOBJDSNVBA" HeaderText="DESTINO VERBA"
							Visible="False">
							<HeaderStyle HorizontalAlign="Center" Width="50px" VerticalAlign="Top"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="DATLIMVGR" SortExpression="DATLIMVGR" HeaderText="DT LIMITE" Visible="False">
							<HeaderStyle HorizontalAlign="Center" Width="50px" VerticalAlign="Top"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
						</asp:BoundColumn>
					</Columns>
					<PagerStyle VerticalAlign="Middle" Height="20px" HorizontalAlign="Center" PageButtonCount="9"
						CssClass=" " Mode="NumericPages"></PagerStyle>
				</asp:datagrid></form>
		</P>
	</body>
</HTML>
