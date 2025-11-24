<%@ Page Language="vb" AutoEventWireup="false" Codebehind="VisualizadorRelatorio.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.VisualizadorRelatorio" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.2.3300.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Relatório Acões Comerciais</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<cr:CrystalReportViewer style="Z-INDEX: 101; POSITION: absolute; TOP: 16px; LEFT: 8px" id="CrystalReportViewer1"
				runat="server"></cr:CrystalReportViewer></form>
		</FORM>
	</body>
</HTML>
