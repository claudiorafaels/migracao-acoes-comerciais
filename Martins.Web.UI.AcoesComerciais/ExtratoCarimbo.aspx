<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="AppComponents/wucFornecedor.ascx" %>
<%@ Register TagPrefix="uc1" TagName="wucCelula" Src="AppComponents/wucCelula.ascx" %>
<%@ Register TagPrefix="uc1" TagName="wucDiretoria" Src="AppComponents/wucDiretoria.ascx" %>
<%@ Register TagPrefix="uc1" TagName="wucComprador" Src="AppComponents/wucComprador.ascx" %>
<%@ Register TagPrefix="martinscontrols" Namespace="Martins.Web.UI.Controls" Assembly="Martins.Web.UI.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=e9ed78c287a2fd3c" %>
<%@ Register TagPrefix="igcmbo" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ExtratoCarimbo.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.ExtratoCarimbo" %>
<%@ Register TagPrefix="uc1" TagName="ucMercadoria" Src="AppComponents/ucMercadoria.ascx" %>
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
		<script event="onreadystatechange" for="document">
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

function TestaNumerico(obj) {
				if ( (window.event.keyCode < 48 ) || window.event.keyCode > 57 ) 
				{
					if (window.event.keyCode != 44)
		    			window.event.returnValue=false ;
		    		else
		    			if (obj.value.toString().indexOf(',') > -1)
							{
				    			window.event.returnValue=false ;
							}
				}
			}


function FormataData(Campo) {
					var tecla = window.event.keyCode;
					vr = Campo.value;
					vr = vr.replace( ".", "" );
					vr = vr.replace( "/", "" );
					vr = vr.replace( "/", "" );
					tam = vr.length + 1;

					//tecla != 9 && tecla != 8 ||
					
					if ( tecla >= 48 && tecla <= 57 ){
						if ( tam > 2 && tam < 5 )
							Campo.value = vr.substr( 0, tam - 2  ) + '/' + vr.substr( tam - 2, tam );
						if ( tam >= 5 && tam <= 10 )
							Campo.value = vr.substr( 0, 2 ) + '/' + vr.substr( 2, 2 ) + '/' + vr.substr( 4, 4 ); 
					}
					else {window.event.returnValue=false}
	        }

//-->
		</script>
		<script language="javascript">
			history.forward();
		</script>
		<LINK href="styles_tabelas.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onload="MM_preloadImages('../Imagens/lastpost.gif')">
		<form id="Form1" runat="server">
			<table cellSpacing="cellPadding=" width="10" border="0">
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
							<table id="tbOpcoes" cellSpacing="0" cellPadding="0" border="0" runat="server">
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
									<td id="TD1" runat="server">
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td id="TD2" onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"
													runat="server"></td>
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
									<TR id="Tr1" height="40" runat="server">
										<TD class="barra1" id="TDEspera" style="HEIGHT: 35px" align="left" width="50%" runat="server">
											<DIV id="Div2" align="left" runat="server"><asp:image id="Image2" runat="server" ImageUrl="../Imagens/espera.gif"></asp:image>&nbsp;Carregando...
											</DIV>
										</TD>
										<TD class="barra1" id="TDReserva" style="HEIGHT: 35px" align="left" width="50%" runat="server"></TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
									<TR>
										<TD class="barra3" style="WIDTH: 37px; HEIGHT: 70px">
											<P align="right">Relatório:</P>
										</TD>
										<TD class="barra1" style="WIDTH: 315px; HEIGHT: 70px" colSpan="3"><asp:radiobuttonlist id="tblOpcao" runat="server" Width="72px" AutoPostBack="True" Height="32px">
												<asp:ListItem Value="0" Selected="True">Sint&#233;tico</asp:ListItem>
												<asp:ListItem Value="1">Anal&#237;tico</asp:ListItem>
												<asp:ListItem Value="2">Histórico</asp:ListItem>
											</asp:radiobuttonlist></TD>
									</TR>
									<TR id="trEmpenho" runat="server">
										<TD class="barra3" style="WIDTH: 37px; HEIGHT: 26px">
											<P align="right">Empenho:</P>
										</TD>
										<TD class="barra1" style="WIDTH: 315px; HEIGHT: 26px" colSpan="3"><asp:dropdownlist id="cmbEmpenho" runat="server" Width="200px" CssClass=""></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="barra3" style="WIDTH: 37px; HEIGHT: 10px" runat="server">
											<P align="right">Filial:</P>
										</TD>
										<TD class="barra1" id="TD4" style="WIDTH: 315px; HEIGHT: 10px" colSpan="3" runat="server"><asp:dropdownlist id="cmbFilial" runat="server" Width="200px" CssClass=""></asp:dropdownlist></TD>
									</TR>
									<TR id="trFiltro" runat="server">
										<TD class="barra3" style="WIDTH: 37px; HEIGHT: 13px">
											<P align="right">Filtro:</P>
										</TD>
										<TD class="barra1" style="WIDTH: 315px; HEIGHT: 13px" colSpan="3"><asp:dropdownlist id="cmbFiltro" runat="server" Width="200px" AutoPostBack="True" CssClass="">
												<asp:ListItem Value="0" Selected="True">(Selecione)</asp:ListItem>
												<asp:ListItem Value="1">Celula</asp:ListItem>
												<asp:ListItem Value="2">Comprador</asp:ListItem>
												<asp:ListItem Value="3">Diretoria</asp:ListItem>
												<asp:ListItem Value="4">Fornecedor</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
									<TR id="trDiretoria" runat="server">
										<TD class="barra3" style="WIDTH: 37px">
											<P align="right">Diretoria:</P>
										</TD>
										<TD class="barra1" colSpan="3"><uc1:wucdiretoria id="ucDiretoria" runat="server"></uc1:wucdiretoria></TD>
									</TR>
									<TR id="trCelula" runat="server">
										<TD class="barra3" style="WIDTH: 37px">
											<P align="right">Célula:</P>
										</TD>
										<TD class="barra1" colSpan="3"><uc1:wuccelula id="ucCelula" runat="server"></uc1:wuccelula></TD>
									</TR>
									<TR id="trComprador" runat="server">
										<TD class="barra3" style="WIDTH: 37px">
											<P align="right">Comprador:</P>
										</TD>
										<TD class="barra1" colSpan="3"><uc1:wuccomprador id="ucComprador" runat="server"></uc1:wuccomprador></TD>
									</TR>
									<TR id="trFornecedor" runat="server">
										<TD class="barra3" style="WIDTH: 37px">
											<P align="right">Fornecedor:</P>
										</TD>
										<TD class="barra1" colSpan="3"><uc1:wucfornecedor id="ucFornecedor" runat="server"></uc1:wucfornecedor></TD>
									</TR>
									<TR id="trHistorico1" runat="server">
										<TD class="barra3" style="WIDTH: 37px">
											<P align="right">Período:</P>
										</TD>
										<TD class="barra1" colSpan="3">
											Inicial
											<asp:textbox onkeypress="TestaNumerico();FormataData(this);" id="txtDataInicial" runat="server"
												CssClass="lightbox" MaxLength="10" Width="88px"></asp:textbox>
											&nbsp;Final
											<asp:textbox onkeypress="TestaNumerico();FormataData(this);" id="txtDataFinal" runat="server"
												Width="88px" CssClass="lightbox" MaxLength="10"></asp:textbox>
										</TD>
									</TR>
									<TR id="trHistorico2" runat="server">
										<TD class="barra3" style="WIDTH: 37px">
											<P align="right">Tipo:</P>
										</TD>
										<TD class="barra1" colSpan="3">
											<asp:RadioButtonList id="tblTipo" runat="server" RepeatDirection="Horizontal">
												<asp:ListItem Value="t" Selected="True">Todos</asp:ListItem>
												<asp:ListItem Value="d">D&#233;bito</asp:ListItem>
												<asp:ListItem Value="c">Cr&#233;dito</asp:ListItem>
											</asp:RadioButtonList></TD>
									</TR>
									<TR id="trHistorico3" runat="server">
										<TD class="barra3" style="WIDTH: 37px">
											<P align="right">Mercadoria:</P>
										</TD>
										<TD class="barra1" colSpan="3">
											<uc1:ucMercadoria id="UcMercadoria1" runat="server"></uc1:ucMercadoria></TD>
									</TR>
									<TR id="trHistorico4" runat="server">
										<TD class="barra3" style="WIDTH: 37px">
											<P align="right">Descricao:</P>
										</TD>
										<TD class="barra1" colSpan="3">
											<asp:TextBox id="txtDescricao" runat="server" MaxLength="40"></asp:TextBox></TD>
									</TR>
								</TBODY>
							</TABLE>
					<TR>
					</TR>
					</td></tr></tbody></table>
			</TD></TR></TBODY></TABLE><asp:label id="lblErro" runat="server" ForeColor="Red" Font-Size="10px"></asp:label></form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
