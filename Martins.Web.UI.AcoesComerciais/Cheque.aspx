<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="martinscontrols" Namespace="Martins.Web.UI.Controls" Assembly="Martins.Web.UI.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=e9ed78c287a2fd3c" %>
<%@ Register TagPrefix="igcmbo" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Cheque.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.Cheque" %>
<%@ Register TagPrefix="igtxt1" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Martins</TITLE>
		<meta content="True" name="vs_snapToGrid">
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

function txtVLRCHQ_Blur(oEdit, text, oEvent){
	btnSalvar.focus();
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
	<body onload="MM_preloadImages('../Imagens/lastpost.gif')" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="10" border="0">
				<tr>
					<td><A href="javascript:parent.resizeFrame('5,*')"><IMG id="Image1" onmouseover="MM_swapImage('Image1','','../Imagens/lastpost.gif',1)"
								onmouseout="MM_swapImage('Image1','','../Imagens/lastpost_l.gif',1)" height="12" src="../Imagens/lastpost_l.gif" width="12"
								name="Image1"></A></td>
				</tr>
			</table>
			<table height="67" cellSpacing="0" cellPadding="0" width="100%" border="0" style="WIDTH: 100%; HEIGHT: 67px">
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
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnCancelar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
														href="ChequeListar.aspx"><IMG height="16" src="../Imagens/office/Sair.gif" width="16" align="absMiddle"> Sair</asp:linkbutton></td>
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
						</td>
					</tr>
					<TR>
						<TD class="barra3">
							<asp:dropdownlist id="ddl1" runat="server" AutoPostBack="True" Height="19px" Font-Names="Arial" Font-Size="11px"
								Width="0px" CssClass=" "></asp:dropdownlist>
							Código do Banco:
						</TD>
						<TD class="barra1" colSpan="3">
							<igtxt1:WebNumericEdit id="txtCODBCO" runat="server" CssClass="" Width="60px" Font-Size="11px"
								Font-Names="Arial" Height="20" DataMode="Decimal" AutoPostBack="True"></igtxt1:WebNumericEdit>
							<asp:DropDownList id="cmbNomeBanco" runat="server" Visible="False" AutoPostBack="True" Font-Names="Arial"
								Font-Size="11px" Width="250px" CssClass="" Height="19px"></asp:DropDownList>
							<igtxt:WebTextEdit id="txtNomeBanco" runat="server" Font-Names="Arial" Font-Size="11px" Width="250px"
								CssClass=""></igtxt:WebTextEdit>
							<asp:linkbutton id="btnBuscarBanco" style="TEXT-DECORATION: none" runat="server">
								<img src="../Imagens/office/procurar.gif" width="16" height="16" align="absMiddle"></asp:linkbutton>
						</TD>
					</TR>
					<TR>
						<TD class="barra3">
							<asp:dropdownlist id="ddl2" runat="server" AutoPostBack="True" Height="19px" Font-Names="Arial" Font-Size="11px"
								Width="0px" CssClass=" "></asp:dropdownlist>
							Código da Agencia:
						</TD>
						<TD class="barra1" colSpan="3">
							<igtxt1:WebNumericEdit id="txtCODAGE" runat="server" CssClass="" Width="60px" Font-Size="11px"
								Font-Names="Arial" Height="20" DataMode="Decimal" AutoPostBack="True"></igtxt1:WebNumericEdit>
							<asp:DropDownList id="cmbNomeAgencia" runat="server" Visible="False" AutoPostBack="True" Font-Names="Arial"
								Font-Size="11px" Width="250px" CssClass="" Height="19px"></asp:DropDownList>
							<igtxt:WebTextEdit id="txtNomeAgencia" runat="server" Font-Names="Arial" Font-Size="11px" Width="250px"
								CssClass=""></igtxt:WebTextEdit>
							<asp:linkbutton id="btnBuscarAgencia" style="TEXT-DECORATION: none" runat="server">
								<img src="../Imagens/office/procurar.gif" width="16" height="16" align="absMiddle"></asp:linkbutton>
						</TD>
					</TR>
					<TR>
						<TD class="barra3">
							<asp:dropdownlist id="ddl3" runat="server" AutoPostBack="True" Height="19px" Font-Names="Arial" Font-Size="11px"
								Width="0px" CssClass=" "></asp:dropdownlist>Número do Cheque:
						</TD>
						<TD class="barra1" colSpan="3">
							<igtxt1:WebNumericEdit id="txtNUMCHQ" runat="server" CssClass="" Width="80px" Font-Size="11px"
								Font-Names="Arial" Height="20" DataMode="Decimal"></igtxt1:WebNumericEdit></TD>
					</TR>
					<TR>
						<TD class="barra3">
							Data do Recebimento:
						</TD>
						<TD class="barra1" colSpan="3">
							<igtxt1:WebDateTimeEdit id="txtDATRCBCHQ" runat="server" Width="80px" Height="20" CssClass="" Font-Names="Arial"
								Font-Size="11px" PromptChar=" " HorizontalAlign="Right"></igtxt1:WebDateTimeEdit>
						</TD>
					</TR>
					<TR>
						<TD class="barra3">Fornecedor:
						</TD>
						<TD class="barra1" colSpan="3">
							<igtxt1:WebNumericEdit id="txtCODFRN" runat="server" CssClass="" Width="60px" Font-Size="11px"
								Font-Names="Arial" Height="20" DataMode="Decimal" AutoPostBack="True"></igtxt1:WebNumericEdit>
							<asp:DropDownList id="cmbNomeFornecedor" runat="server" Visible="False" AutoPostBack="True" Font-Names="Arial"
								Font-Size="11px" Width="280px" CssClass="" Height="19px"></asp:DropDownList>
							<igtxt:WebTextEdit id="txtNomeFornecedor" runat="server" Font-Names="Arial" Font-Size="11px" Width="280px"
								CssClass=""></igtxt:WebTextEdit>
							<asp:linkbutton id="btnBuscarFornecedor" style="TEXT-DECORATION: none" runat="server">
								<img src="../Imagens/office/procurar.gif" width="16" height="16" align="absMiddle"></asp:linkbutton></TD>
					</TR>
					<TR>
						<TD class="barra3" id="TD1" runat="server">
							<asp:dropdownlist id="ddl4" runat="server" AutoPostBack="True" Height="19px" Font-Names="Arial" Font-Size="11px"
								Width="0px" CssClass=" "></asp:dropdownlist>Data do 
							Recebimento&nbsp;do Crédito:</TD>
						<TD class="barra1" colSpan="3" id="TD2" runat="server">
							<igtxt1:WebDateTimeEdit id="txtDATRCBCRECHQ" runat="server" Font-Names="Arial" Font-Size="11px" Width="80px"
								CssClass="" Height="20" PromptChar=" " HorizontalAlign="Right" ReadOnly="True"></igtxt1:WebDateTimeEdit></TD>
					</TR>
					<TR>
						<TD class="barra3" id="TD4" runat="server">Data de Último Acordo</TD>
						<TD class="barra1" colSpan="3" id="TD3" runat="server">
							<igtxt1:WebDateTimeEdit id="txtDATULTPMSCHQ" runat="server" Font-Names="Arial" Font-Size="11px" Width="80px"
								CssClass="" Height="20" PromptChar=" " HorizontalAlign="Right" ReadOnly="True"></igtxt1:WebDateTimeEdit></TD>
					</TR>
					<TR>
						<TD class="barra3">Usuário:</TD>
						<TD class="barra1" colSpan="3">
							<igtxt:WebTextEdit id="txtNOMACSUSRSIS" runat="server" Width="80px" CssClass="" ReadOnly="True"></igtxt:WebTextEdit></TD>
					</TR>
					<TR>
						<TD class="barra3">
							<asp:dropdownlist id="ddl5" runat="server" AutoPostBack="True" Height="19px" Font-Names="Arial" Font-Size="11px"
								Width="0px" CssClass=" "></asp:dropdownlist>
							Valor do Cheque:
						</TD>
						<TD class="barra1" colSpan="3">
							<igtxt1:WebCurrencyEdit id="txtVLRCHQ" runat="server" Width="80px" Height="20" CssClass="" DataMode="Decimal"
								Font-Names="Arial" Font-Size="11px">
								<ClientSideEvents Blur="txtVLRCHQ_Blur"></ClientSideEvents>
							</igtxt1:WebCurrencyEdit>
						</TD>
					</TR>
					<TR>
					</TR>
				</tbody>
			</table>
			</TD></TR></TBODY></TABLE>
			<asp:label id="lblErro" runat="server" ForeColor="Red" Font-Size="10px"></asp:label></form>
	</body>
</HTML>
