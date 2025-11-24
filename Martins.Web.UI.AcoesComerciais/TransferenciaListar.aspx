<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TransferenciaListar.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.TransferenciaListar" %>
<%@ Register TagPrefix="igtxt1" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igcmbo" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="martinscontrols" Namespace="Martins.Web.UI.Controls" Assembly="Martins.Web.UI.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=e9ed78c287a2fd3c" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Martins</TITLE>
		<meta content="True" name="vs_snapToGrid">
		<meta content="False" name="vs_showGrid">
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../Imagens/styles.css" type="text/css" rel="stylesheet">
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
	window.MM_findObj('trEspera').style.display = 'none';
	window.MM_findObj('tbOpcoes').style.display = 'inline';
	return true;
}

function mostraAndamento() {
	window.MM_findObj('trEspera').style.display = 'inline';
	window.MM_findObj('tbOpcoes').style.display = 'none';
	return true;   
}
//-->
			</script>
	</HEAD>
	<BODY onload="MM_preloadImages('../Imagens/lastpost.gif')">
		<form id="Form1" runat="server">
			<table cellSpacing="0" cellPadding="0" width="10" border="0">
				<tr>
					<td><A href="javascript:parent.resizeFrame('5,*')"><IMG id="Image1" onmouseover="MM_swapImage('Image1','','../Imagens/lastpost.gif',1)"
								onmouseout="MM_swapImage('Image1','','../imagens/lastpost_l.gif',1)" height="12" src="../Imagens/lastpost_l.gif" width="12"
								name="Image1"></A></td>
				</tr>
			</table>
			<table height="424" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tbody>
					<tr>
					</tr>
				</tbody></table>
			<table height="40" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tbody>
					<tr>
						<td class="submenu2" vAlign="top" height="28">
							<table cellSpacing="0" cellPadding="0" border="0" id="tbOpcoes" height="0" runat="server">
								<tr>
									<td height="10">
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnPesquisar" style="TEXT-DECORATION: none" runat="server"><img src="../Imagens/office/procurar.gif" width="16" height="16" align="absMiddle">Pesquisar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td height="10">
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnInserir" style="TEXT-DECORATION: none" runat="server"><img src="../Imagens/office/novo.gif" width="16" height="16" align="absMiddle">Novo</asp:linkbutton></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
					</tr>
				</tbody></table>
			<TABLE class="tabela1" id="Table1" height="8" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<TR>
					<TD class="barra3" height="19" widTD="10%">Critério:
					</TD>
					<TD class="barra1" width="126" height="19">
						<asp:DropDownList id="cmbCriterio" runat="server" Width="180px" Height="19px" Font-Size="10px" Font-Names="Arial"
							AutoPostBack="True">
							<asp:ListItem Value="1">PER&#205;ODO</asp:ListItem>
							<asp:ListItem Value="2">DATA</asp:ListItem>
							<asp:ListItem Value="3">PER&#205;ODO/FORN.CTA ORIGEM</asp:ListItem>
							<asp:ListItem Value="4">PER&#205;ODO/FORN.CTA DESTINO</asp:ListItem>
							<asp:ListItem Value="5">EMPENHO/FORN.CTA ORIGEM</asp:ListItem>
							<asp:ListItem Value="6">EMPENHO/FORN.CTA DESTINO</asp:ListItem>
						</asp:DropDownList></TD>
					<TD class="barra1" height="19" vAlign="top" align="left">
						<igtxt:WebDateTimeEdit id="txtDataInicial" runat="server" Width="70px" Height="19px" Font-Size="10px" Font-Names="Arial"></igtxt:WebDateTimeEdit>
						<asp:Label id="LblA" runat="server">A</asp:Label>
						<igtxt:WebDateTimeEdit id="txtDataFinal" runat="server" Width="70px" Height="19px" Font-Size="10px" Font-Names="Arial"></igtxt:WebDateTimeEdit>
						<asp:Label id="LblFornecedor" runat="server" Visible="False">Forn.</asp:Label>
						<igtxt1:WebTextEdit id="txtCodigo" runat="server" Height="19px" Width="60px" Font-Size="10px" Font-Names="Arial"
							Visible="False"></igtxt1:WebTextEdit>
						<asp:DropDownList id="cmbNomeFornecedor" runat="server" Width="170px" Height="19px" Font-Size="10px"
							Font-Names="Arial" Visible="False"></asp:DropDownList>
						<asp:TextBox id="txtNomeFornecedor" runat="server"></asp:TextBox>
						<asp:linkbutton id="btnBuscarFornecedor" style="TEXT-DECORATION: none" runat="server" Visible="False">
							<img src="../Imagens/office/procurar.gif" width="16" height="16" align="absMiddle"></asp:linkbutton>
						<asp:Label id="lblEmpenho" runat="server" Visible="False">Emp.</asp:Label>
						<asp:DropDownList id="cmbEmpenho" runat="server" Font-Names="Arial" Font-Size="10px" Height="19px"
							Width="120px" Visible="False"></asp:DropDownList></TD>
				</TR>
				<TR id="trEspera" runat="server">
					<TD class="barra1" height="19">
					</TD>
					<TD class="barra1" width="126" height="19" align="left">
						<DIV align="left" runat="server" ID="Div1">
							<asp:image id="Espera" runat="server" ImageUrl="../Imagens/espera.gif"></asp:image>&nbsp;Carregando...
						</DIV>
					</TD>
					<TD class="barra1" vAlign="top" align="left" height="19">
					</TD>
				</TR>
			</TABLE>
			<TABLE>
				<TR>
					<TD colSpan="3" height="14">
						<asp:validationsummary id="ValidationSummary1" runat="server" Width="672px" DisplayMode="SingleParagraph"></asp:validationsummary>
					</TD>
				</TR>
				<TR>
					<TD align="left" colSpan="3" height="19">
						<table height="400" cellSpacing="0" cellPadding="0" width="887" align="center" border="0">
							<TR>
								<TD vAlign="top" width="98%" height="400">
									<asp:label id="lblFrame" runat="server"></asp:label></TD>
							</TR>
						</table>
					</TD>
				</TR>
			</TABLE>
			</TR></TBODY></TABLE></TD></TR><tr>
				<td height="100%" width="915" vAlign="top">
				</td>
			</tr>
			<tr>
				<td class="darkbox" height="10" width="915" vAlign="top">&nbsp;</td>
			</tr>
			</TBODY></TABLE>
			<DIV></DIV>
		</form>
	</BODY>
</HTML>
