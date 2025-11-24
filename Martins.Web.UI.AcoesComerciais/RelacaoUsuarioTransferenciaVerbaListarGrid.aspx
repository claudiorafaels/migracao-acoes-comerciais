<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RelacaoUsuarioTransferenciaVerbaListarGrid.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.RelacaoUsuarioTransferenciaVerbaListarGrid"%>
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
				CssClass=" " AllowPaging="True" DataSource="<%# dsTipoTransferenciaXUsuario %>" DataMember="T0135092">
				<AlternatingItemStyle CssClass="row4"></AlternatingItemStyle>
				<ItemStyle CssClass="row3"></ItemStyle>
				<HeaderStyle CssClass="header1"></HeaderStyle>
				<Columns>
					<asp:TemplateColumn>
						<HeaderStyle Width="10px"></HeaderStyle>
						<ItemTemplate>
							<asp:ImageButton id="imbExcluir" runat="server" CommandName="grdExcluir" ImageUrl="../Imagens/office/apagar.gif"></asp:ImageButton>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="CODTIPTRNVLRACOCMC" SortExpression="CODTIPTRNVLRACOCMC" HeaderText="C&#211;DIGO"></asp:BoundColumn>
					<asp:BoundColumn DataField="NOMACSUSRSIS" SortExpression="NOMACSUSRSIS" HeaderText="USU&#193;RIO"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="TIPO TRANSFERENCIA">
						<ItemTemplate>
							<asp:Label id=Label1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem.Row.T0135033Row, "DESTIPTRNVLRACOCMC") %>'>
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
