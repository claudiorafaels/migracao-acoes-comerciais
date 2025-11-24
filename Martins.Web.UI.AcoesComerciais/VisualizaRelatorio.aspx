<%@ Page Language="vb" AutoEventWireup="false" Codebehind="VisualizaRelatorio.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.VisualizaRelatorio" %>
<%@ Register TagPrefix="cr1" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.2.3300.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>VisualizaRelatorio</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			&nbsp;
			<cr:crystalreportviewer id="crvVisualizadorRelatorio" runat="server" Width="350px" Height="50px"></cr:crystalreportviewer></form>
	</body>
</HTML>
