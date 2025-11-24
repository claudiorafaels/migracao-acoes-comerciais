<%@ Register TagPrefix="igmisc" Namespace="Infragistics.WebUI.Misc" Assembly="Infragistics.WebUI.Misc.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="uc1" TagName="wucEmpenho" Src="AppComponents/wucEmpenho.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Lancamento.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.Lancamento" %>
<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="AppComponents/wucFornecedor.ascx" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igcmbo" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="martinscontrols" Namespace="Martins.Web.UI.Controls" Assembly="Martins.Web.UI.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=e9ed78c287a2fd3c" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
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
		<script language="javascript">
			history.forward();
		</script>
		<LINK href="styles_tabelas.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onload="MM_preloadImages('../Imagens/lastpost.gif')">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="10" border="0">
				<tr>
					<td><A href="javascript:parent.resizeFrame('5,*')"><IMG id="Image1" onmouseover="MM_swapImage('Image1','','../Imagens/lastpost.gif',1)"
								onmouseout="MM_swapImage('Image1','','../Imagens/lastpost_l.gif',1)" height="12" src="../Imagens/lastpost_l.gif" width="12"
								name="Image1"></A></td>
				</tr>
			</table>
			<table style="WIDTH: 100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tbody>
					<tr>
						<td class="submenu2" vAlign="top">
							<table cellSpacing="0" cellPadding="0" border="0" id="tbOpcoes" runat="server">
								<tr>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnSalvar" style="TEXT-DECORATION: none" runat="server"><IMG height="16" src="../Imagens/office/salvar.gif" width="16" align="absMiddle"> Salvar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnCancelar" style="TEXT-DECORATION: none" runat="server" href="LancamentoListar.aspx"
														CausesValidation="False"><IMG height="16" src="../Imagens/office/Sair.gif" width="16" align="absMiddle"> Sair</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnApagar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
														Visible="False"><IMG height="16" src="../Imagens/office/apagar.gif" width="16" align="absMiddle">
													Apagar</asp:linkbutton></td>
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
										<TD class="barra1" align="left" style="HEIGHT: 35px" width="50%">
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
										<TD class="barra3" width="10%" height="19">
											<P align="right">Fornecedor:</P>
										</TD>
										<TD class="barra1" width="90%" colSpan="3" height="19"><P align="left"><uc1:wucfornecedor id="ucFornecedor" runat="server"></uc1:wucfornecedor></P>
										</TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%" height="19">Empenho:</TD>
										<TD class="barra1" width="40%" height="19"><uc1:wucempenho id="ucEmpenho" runat="server"></uc1:wucempenho></TD>
										<TD class="barra3" width="10%" height="19">Tipo Lançamento:</TD>
										<TD class="barra1" width="40%" height="19"><asp:dropdownlist id="cmbCODTIPLMT" runat="server" AutoPostBack="True" Width="100%" CssClass=""></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%" height="26">Número:</TD>
										<TD class="barra1" width="40%" height="26"><igtxt:webnumericedit id="txtNUMSEQLMT" runat="server" Width="57px" CssClass="" ReadOnly="True"
												Enabled="False" Height="19px"></igtxt:webnumericedit></TD>
										<TD class="barra3" width="10%" height="26">Data:</TD>
										<TD class="barra1" width="40%" height="26"><igtxt:webdatetimeedit id="txtDATREFLMT" runat="server" Width="80px" CssClass="" ReadOnly="True"
												Enabled="False" Height="19px"></igtxt:webdatetimeedit></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%" height="19">Usuário:</TD>
										<TD class="barra1" width="40%" height="19"><igtxt:webtextedit id="txtNOMACSUSRGRCLMT" runat="server" CssClass="" ReadOnly="True" Enabled="False"
												Height="19px"></igtxt:webtextedit></TD>
										<TD class="barra3" width="10%" height="19">Natureza:</TD>
										<TD class="barra1" width="40%" height="19"><asp:radiobuttonlist id="optCODGDC" runat="server" Width="220px" CssClass="">
												<asp:ListItem Value="D" Selected="True">D&#233;bito</asp:ListItem>
												<asp:ListItem Value="C">Cr&#233;dito</asp:ListItem>
											</asp:radiobuttonlist></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%" height="19">Valor:</TD>
										<TD class="barra1" width="40%" height="19"><igtxt:webcurrencyedit id="txtVLRLMTCTB" runat="server" Width="112px" CssClass="" Height="19px"></igtxt:webcurrencyedit></TD>
										<TD class="barra3" width="10%" height="19">Histórico:</TD>
										<TD class="barra1" width="40%" height="19"><igtxt:webtextedit id="txtDESHSTLMT" runat="server" Width="100%" CssClass="" Height="19px"></igtxt:webtextedit></TD>
									</TR>
									<TR>
										<TD class="barra1" width="10%" height="19"></TD>
										<TD class="barra1" width="40%" height="19"></TD>
										<TD class="barra1" width="10%" height="19"></TD>
										<TD class="barra1" width="40%" height="19"></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD1" width="10%" height="19" runat="server">Filial:</TD>
										<TD class="barra1" id="TD2" width="40%" height="19" runat="server"><asp:dropdownlist id="cmbCODFILEMP" runat="server" Visible="true" AutoPostBack="True" Width="100%"
												CssClass="" Height="19px" Font-Names="Arial" Font-Size="11px"></asp:dropdownlist></TD>
										<TD class="barra1" id="TD3" width="10%" height="19" runat="server"></TD>
										<TD class="barra1" id="TD4" width="40%" height="19" runat="server"></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD5" width="10%" height="19" runat="server">Conta Crédito:</TD>
										<TD class="barra1" id="TD6" width="40%" height="19" runat="server"><igtxt:webnumericedit id="txtCODCNTCRD" runat="server" Width="100px" CssClass="" ReadOnly="True"
												Enabled="False" Height="19px"></igtxt:webnumericedit></TD>
										<TD class="barra3" id="TD18" width="10%" height="19" runat="server">
											<P id="P1" runat="server">Centro de Custo:&nbsp;</P>
										</TD>
										<TD class="barra1" id="TD17" width="40%" height="19" runat="server"><igtxt:webnumericedit id="txtCODCENCSTCRD" runat="server" Width="100px" CssClass="" ReadOnly="True"
												Enabled="False" Height="19px"></igtxt:webnumericedit></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD19" width="10%" height="19" runat="server">Conta Débito:</TD>
										<TD class="barra1" id="TD20" width="40%" height="19" runat="server"><igtxt:webnumericedit id="txtCodCntDeb" runat="server" Width="100px" CssClass="" ReadOnly="True"
												Enabled="False" Height="19px"></igtxt:webnumericedit></TD>
										<TD class="barra3" id="TD7" width="10%" height="19" runat="server">Centro de Custo:</TD>
										<TD class="barra1" id="TD8" width="40%" height="19" runat="server"><igtxt:webnumericedit id="txtCODCENCSTDEB" runat="server" Width="100px" CssClass="" ReadOnly="True"
												Enabled="False" Height="19px"></igtxt:webnumericedit></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD9" width="10%" height="19" runat="server">Cod. Histórico 
											Padrão</TD>
										<TD class="barra1" id="TD10" width="40%" height="19" runat="server"><igtxt:webnumericedit id="txtCODHSTPAD" runat="server" Width="100px" CssClass="" ReadOnly="True"
												Enabled="False" Height="19px"></igtxt:webnumericedit></TD>
										<TD class="barra1" id="TD11" width="10%" height="19" runat="server"></TD>
										<TD class="barra1" id="TD12" width="40%" height="19" runat="server"></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD13" width="10%" height="19" runat="server">Var. do 
											Histórico Padrão&nbsp;</TD>
										<TD class="barra1" id="TD14" width="40%" height="19" runat="server"><igtxt:webtextedit id="txtDESVARHSTPAD" runat="server" Width="251px" CssClass="" Height="19px"></igtxt:webtextedit><asp:label id="lblVariaveisHP" runat="server" ForeColor="Black">Informe as variaveis do HP separadas por ' ; '.</asp:label></TD>
										<TD class="barra1" id="TD15" width="10%" height="19" runat="server"></TD>
										<TD class="barra1" id="TD16" width="40%" height="19" runat="server"></TD>
									</TR>
								</TBODY>
							</TABLE>
						</td>
					</tr>
				</tbody>
			</table>
			</TD></TBODY></TABLE><asp:label id="lblErro" runat="server" Visible="False" Font-Size="10px" ForeColor="Red"></asp:label></form>
	</body>
</HTML>
