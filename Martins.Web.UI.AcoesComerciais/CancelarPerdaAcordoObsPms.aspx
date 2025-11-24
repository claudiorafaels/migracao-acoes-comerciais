<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CancelarPerdaAcordoObsPms.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.CancelarPerdaAcordoObsPms"%>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>CancelarPerdaAcordoObsPms</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Imagens/Styles.css" type="text/css" rel="stylesheet">
		<LINK href="styles_tabelas.css" type="text/css" rel="stylesheet">
		<style type="text/css">BODY { MARGIN: 0px; BACKGROUND-COLOR: #ffffff; scrolling: no }
		</style>
		<script language="JavaScript" type="text/JavaScript">
<!--
function Done() 
{
/*	var ParmA = tbParamA.value;
	var ParmB = tbParamB.value;
	var ParmC = tbParamC.value;
	var MyArgs = new Array(ParmA, ParmB, ParmC);*/
	window.returnValue = document.getElementById('txtObs').value;
	window.close();
}

//-->
		</script>
		<script language="javascript">
			history.forward();
		</script>		
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="5" border="0">
				<TR>
					<TD class="barra3">Usuário</TD>
					<TD width="300">
						<asp:Label id="lblUsr" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD colSpan="2"><TEXTAREA id="txtObs" rows="10" cols="60"></TEXTAREA></TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<P align="center"><INPUT type="button" onClick="Done()" size="20" value=" Ok "></P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
