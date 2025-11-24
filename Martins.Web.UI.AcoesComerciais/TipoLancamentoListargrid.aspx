<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TipoLancamentoListargrid.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.TipoLancamentoListarGrid" %>
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
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						</asp:ButtonColumn>
						<asp:BoundColumn DataField="CODTIPLMT" SortExpression="CODTIPLMT" HeaderText="C&#211;DIGO"></asp:BoundColumn>
						<asp:BoundColumn DataField="DESTIPLMT" SortExpression="DESTIPLMT" HeaderText="DESCRI&#199;&#195;O"></asp:BoundColumn>
						<asp:BoundColumn DataField="DESTIPLMTFRN" SortExpression="DESTIPLMTFRN" HeaderText="DESCRI&#199;&#195;O TIPO LAN&#199;. FORNECEDOR"></asp:BoundColumn>
						<asp:BoundColumn DataField="FLGGRCLMTCTB" SortExpression="FLGGRCLMTCTB" HeaderText="GERAR LAN&#199;. CONTABIL">
							<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="FLGLMTMAN" SortExpression="FLGLMTMAN" HeaderText="LAN&#199;. MANUAL">
							<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
						</asp:BoundColumn>
					</Columns>
					<PagerStyle VerticalAlign="Middle" Height="20px" HorizontalAlign="Center" PageButtonCount="9"
						CssClass=" " Mode="NumericPages"></PagerStyle>
				</asp:datagrid>
			</form>
		</P>
		<script language="JavaScript" type="text/JavaScript">
	<!--
		window.parent.MM_findObj('trEspera').style.display = 'none';
	//-->
		</script>
	</body>
</HTML>