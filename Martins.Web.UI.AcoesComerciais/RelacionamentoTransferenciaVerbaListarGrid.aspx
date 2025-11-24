<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RelacionamentoTransferenciaVerbaListarGrid.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.RelacionamentoTransferenciaVerbaListarGrid"%>
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
			<asp:datagrid id="dtgListar" runat="server" AllowPaging="True" CssClass=" " Font-Size="X-Small"
				Width="800px" PageSize="20" AutoGenerateColumns="False">
				<AlternatingItemStyle CssClass="row4"></AlternatingItemStyle>
				<ItemStyle CssClass="row3"></ItemStyle>
				<HeaderStyle CssClass="header1"></HeaderStyle>
				<Columns>
					<asp:ButtonColumn Text="&lt;img src=../Imagens/office/s_b_dail.gif alt=Detalhe border=0&gt;" CommandName="Link">
						<HeaderStyle Width="20px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
					</asp:ButtonColumn>
					<asp:BoundColumn DataField="CODTIPTRNVLRACOCMC" HeaderText="COD. TIPO TRANSFER&#202;NCIA"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="TIPO TRANSFERENCIA">
						<ItemTemplate>
							<asp:Label id=Label1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem.Row.T0135033Row, "DESTIPTRNVLRACOCMC") %>'>
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="PERTRNVLRACOCMC" HeaderText="PERCENTUAL" DataFormatString="{0:0.00}"></asp:BoundColumn>
				</Columns>
				<PagerStyle VerticalAlign="Middle" Height="20px" HorizontalAlign="Center" PageButtonCount="9"
					CssClass=" " Mode="NumericPages"></PagerStyle>
			</asp:datagrid>&nbsp;
		</form>
	</body>
</HTML>