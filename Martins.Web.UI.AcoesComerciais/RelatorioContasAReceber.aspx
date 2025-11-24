<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="martinscontrols" Namespace="Martins.Web.UI.Controls" Assembly="Martins.Web.UI.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=e9ed78c287a2fd3c" %>
<%@ Register TagPrefix="igcmbo" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igcmbo1" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.2.3300.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RelatorioContasAReceber.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.RelatorioContasAReceber" %>
<%@ Register TagPrefix="uc1" TagName="wucEmpenho" Src="AppComponents/wucEmpenho.ascx" %>
<%@ Register TagPrefix="igsch" Namespace="Infragistics.WebUI.WebSchedule" Assembly="Infragistics.WebUI.WebDateChooser.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="AppComponents/wucFornecedor.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Martins</TITLE>
		<meta content="False" name="vs_snapToGrid">
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Imagens/Styles.css" type="text/css" rel="stylesheet">
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<SCRIPT language="JavaScript" src="../Imagens/controle.js" type="text/javascript"></SCRIPT>
		<script for="document" event="onreadystatechange">
			if (readyState == 'complete'){
				escondeAndamento();
			} else {
				mostraAndamento();			
			}
		</script>
		<style type="text/css">BODY { MARGIN: 0px; BACKGROUND-COLOR: #ffffff; scrolling: no }
		</style>
		<script language="JavaScript" type="text/JavaScript">
<!--
function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}

function escondeAndamento() {
	window.MM_findObj('tdEspera').style.display = 'none';
	window.MM_findObj('tbOpcoes').style.display = 'inline';
	return true;
}

function mostraAndamento() {
	window.MM_findObj('tdEspera').style.display = 'inline';
	window.MM_findObj('tbOpcoes').style.display = 'none';
	return true;   
}
//-->
		</script>
		<script language="javascript">
			history.forward();
		</script>
		<LINK href="styles_tabelas.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body text="#50" onload="MM_preloadImages('../Imagens/lastpost.gif')">
		<form id="Form1" method="post" runat="server" onsubmit="javascript:mostraAndamento()">
			<table cellSpacing="0" cellPadding="0" width="10" border="0">
				<tr>
					<td><A href="javascript:parent.resizeFrame('5,*')"><IMG id="Image1" onmouseover="MM_swapImage('Image1','','../Imagens/lastpost.gif',1)"
								onmouseout="MM_swapImage('Image1','','../Imagens/lastpost_l.gif',1)" height="12" src="../Imagens/lastpost_l.gif" width="12"
								name="Image1"></A></td>
				</tr>
			</table>
			<table style="WIDTH: 100%; HEIGHT: 67px" height="67" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<tbody>
					<tr>
						<td class="submenu2" vAlign="top">
							<table cellSpacing="0" cellPadding="0" border="0" id="tbOpcoes" runat="server">
								<tr>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnImprimir" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/imprimir.gif" width="16" align="absMiddle">  Imprimir</asp:linkbutton></td>
												<TD><asp:linkbutton id="btnVisualizar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/S_F_NXTO.gif" width="16" align="absMiddle">  Exportar</asp:linkbutton></TD>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnCancelar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
														href="Principal.aspx"><IMG height="16" src="../Imagens/office/Sair.gif" width="16" align="absMiddle"> Sair</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td class="darkbox" vAlign="top">
							<TABLE class="tabela1" id="Table0" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
									<TR id="trEspera" runat="server" height="40">
										<TD class="barra1" align="left" id="TDEspera" width="50%" runat="server">
											<DIV align="left" runat="server" ID="Div2">
												<asp:image id="Image2" runat="server" ImageUrl="../Imagens/espera.gif"></asp:image>
												&nbsp;Carregando...
											</DIV>
										</TD>
										<TD class="barra1" align="left" id="TDReserva" width="50%" runat="server">
										</TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
									<TR>
										<TD class="barra3" style="WIDTH: 97px">Opções</TD>
										<TD class="barra1" colSpan="3"><asp:radiobuttonlist id="rdlOpcoes" runat="server" ForeColor="Black" Width="100%" AutoPostBack="True">
												<asp:ListItem Value="1" Selected="True">Contas a Receber Anal&#237;tico </asp:ListItem>
												<asp:ListItem Value="2">Contas a Receber Sint&#233;tico</asp:ListItem>
												<asp:ListItem Value="3">ABC - Saldo em Aberto</asp:ListItem>
												<asp:ListItem Value="4">Valores Incorretos</asp:ListItem>
												<asp:ListItem Value="5">Aging List Anal&#237;tico ( Valores a receber por idade )</asp:ListItem>
												<asp:ListItem Value="6">Aging List Sint&#233;tico ( Valores a receber por idade )</asp:ListItem>
											</asp:radiobuttonlist></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD20" style="WIDTH: 97px; HEIGHT: 16px" runat="server"><asp:label id="lblFiltro" runat="server" CssClass="barra3">Filtro:</asp:label></TD>
										<TD class="barra1" id="TD1" style="HEIGHT: 16px" colSpan="3" runat="server"><asp:dropdownlist id="cmbFiltro" runat="server" Width="250px" CssClass="" Font-Size="11px" Font-Names="arial"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="barra3" id="Td21" style="WIDTH: 97px; HEIGHT: 19px" runat="server">Empresa</TD>
										<TD class="barra1" id="Td22" style="HEIGHT: 19px" colSpan="3" runat="server">
											<asp:dropdownlist id="cmbTIPIDTEMPASCACOCMC" runat="server" Width="134px" CssClass="" Font-Names="arial"
												Font-Size="11px">
												<asp:ListItem Value="0" Selected="True">Martins</asp:ListItem>
												<asp:ListItem Value="1">Farmaservice</asp:ListItem>
												<asp:ListItem Value="2">Smart</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD18" style="WIDTH: 97px; HEIGHT: 19px" runat="server"></TD>
										<TD class="barra1" id="TD19" style="HEIGHT: 19px" colSpan="3" runat="server"><asp:checkbox id="chkTodasCelula" runat="server" Text="Todas as Células" ForeColor="Black" Visible="False"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD10" style="WIDTH: 97px; HEIGHT: 19px" runat="server">Celula:</TD>
										<TD class="barra1" id="TD2" style="HEIGHT: 19px" colSpan="3" runat="server"><asp:dropdownlist id="CmbCelula" runat="server" Width="250px" CssClass="" Font-Size="11px" Font-Names="arial"></asp:dropdownlist><asp:checkbox id="chkQuebraCelula" runat="server" Text="Quebra por Célula" ForeColor="Black"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD3" style="WIDTH: 97px; HEIGHT: 27px" runat="server">Período:</TD>
										<TD class="barra1" id="TD11" style="HEIGHT: 27px" colSpan="3" runat="server"><igtxt:webdatetimeedit id="txtDataInicial" runat="server" Width="70px" CssClass="" Font-Size="11px" Font-Names="Arial"
												Height="19px" MaxValue="2025-12-31" MinValue="1950-12-31"></igtxt:webdatetimeedit>&nbsp; 
											A&nbsp;
											<igtxt:webdatetimeedit id="txtDataFinal" runat="server" Width="70px" CssClass="" Font-Size="11px" Font-Names="Arial"
												Height="19px" MaxValue="2025-12-31" MinValue="1950-12-31"></igtxt:webdatetimeedit></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD12" style="WIDTH: 97px; HEIGHT: 26px" runat="server">Semana:</TD>
										<TD class="barra1" id="TD4" style="HEIGHT: 26px" colSpan="3" runat="server"><igtxt:webdatetimeedit id="txtSemana" runat="server" Width="70px" CssClass="" Font-Size="11px" Font-Names="Arial"
												Height="19px" MaxValue="2025-12-31" MinValue="1950-12-31" DataMode="EditModeText" EditModeFormat=" "></igtxt:webdatetimeedit></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD13" style="WIDTH: 97px" runat="server">Periodo:</TD>
										<TD class="barra1" id="TD5" colSpan="3" runat="server"><igtxt:webnumericedit id="txtPeriodoIntervalo" runat="server" Width="60px" CssClass="" Height="19px" ValueText="50"></igtxt:webnumericedit></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD14" style="WIDTH: 97px; HEIGHT: 37px" runat="server">Fornecedor:</TD>
										<TD class="barra1" id="TD6" style="HEIGHT: 37px" colSpan="3" runat="server">
											<P><uc1:wucfornecedor id="ucFornecedor" runat="server"></uc1:wucfornecedor>&nbsp;<BR>
												&nbsp;
												<asp:label id="Label1" runat="server" ForeColor="Black">Para selecionar todos fornecedores informe 0 (zero) no código</asp:label></P>
										</TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD15" style="WIDTH: 97px" runat="server">Usuário:</TD>
										<TD class="barra1" id="TD7" colSpan="3" runat="server"><igtxt:webtextedit id="txtUsuario" runat="server" CssClass="" Height="19px" MaxLength="30" ReadOnly="True"
												Width="150px"></igtxt:webtextedit></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD16" style="WIDTH: 97px; HEIGHT: 20px" runat="server">Frm.de 
											Pagto:</TD>
										<TD class="barra1" id="TD8" style="HEIGHT: 35px" colSpan="3" runat="server"><asp:dropdownlist id="cmbFormaPagamento" runat="server" Width="250px" CssClass="" Font-Size="11px"
												Font-Names="arial"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD17" style="WIDTH: 97px" runat="server">Empenho:</TD>
										<TD class="barra1" id="TD9" vAlign="top" colSpan="5" runat="server"><uc1:wucempenho id="ucEmpenho" runat="server"></uc1:wucempenho></TD>
									</TR>
									<TR>
									</TR>
								</TBODY>
							</TABLE>
						</td>
					</tr>
				</tbody>
			</table>
			<asp:label id="lblErro" runat="server" ForeColor="Red" Font-Size="10px"></asp:label></form>
	</body>
</HTML>
