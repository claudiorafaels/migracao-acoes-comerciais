<%@ register tagprefix="uc1" tagname="ucFornecedor" src="Controles/ucFornecedor.ascx" %>
<%@ page language="vb" autoeventwireup="false" codebehind="ValoresContabilizadosCarimbos.aspx.vb"
        inherits="Martins.Web.UI.AcoesComerciais.ValoresContabilizadosCarimbos" %>
<%@ Register TagPrefix="uc1" TagName="ucMercadoria" Src="AppComponents/ucMercadoria.ascx" %>
<%@ register tagprefix="igtbl" namespace="Infragistics.WebUI.UltraWebGrid" assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ register tagprefix="martinscontrols" namespace="Martins.Web.UI.Controls" assembly="Martins.Web.UI.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=e9ed78c287a2fd3c" %>
<%@ register tagprefix="igcmbo" namespace="Infragistics.WebUI.WebCombo" assembly="Infragistics.WebUI.WebCombo.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ register tagprefix="igtxt" namespace="Infragistics.WebUI.WebDataInput" assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Martins</title>
		<meta name="vs_snapToGrid" content="False">
		<meta name="vs_showGrid" content="False">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../Imagens/Styles.css">
		<meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type">
		<script language="JavaScript" type="text/javascript" src="../Imagens/controle.js"></script>
		<script for="document" event="onreadystatechange">
			if (readyState == 'complete'){
				escondeAndamento();
			} else {
				mostraAndamento();			
			}
		</script>
		<style type="text/css">BODY { BACKGROUND-COLOR: #ffffff; MARGIN: 0px; scrolling: no }
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
		<LINK rel="stylesheet" type="text/css" href="styles_tabelas.css">
	</HEAD>
	<body onload="MM_preloadImages('../Imagens/lastpost.gif')">
		<form id="Form2" runat="server">
			<table border="0" cellSpacing="cellPadding=" width="10">
				<tr>
					<td><A href="javascript:parent.resizeFrame('5,*')"><IMG id="Image1" onmouseover="MM_swapImage('Image1','','../Imagens/lastpost.gif',1)"
								onmouseout="MM_swapImage('Image1','','../Imagens/lastpost_l.gif',1)" name="Image1" src="../Imagens/lastpost_l.gif" width="12"
								height="12"></A>
					</td>
				</tr>
			</table>
			<table border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tbody>
					<tr>
						<td class="submenu2" height="28" vAlign="top">
							<table id="tbOpcoes" border="0" cellSpacing="0" cellPadding="0" width="100%" runat="server">
								<tr>
									<td style="WIDTH: 65px" vAlign="top">
										<table class="3D" border="0" cellSpacing="0" cellPadding="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onmouseout="mOut(this,'');" onclick="mClk('#');"><asp:linkbutton style="TEXT-DECORATION: none" id="btnImprimir" runat="server" causesvalidation="False"><IMG height="16" src="../Imagens/office/imprimir.gif" width="16" align="absMiddle">  Imprimir</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td style="WIDTH: 70px" vAlign="top">
										<table class="3D" border="0" cellSpacing="0" cellPadding="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onmouseout="mOut(this,'');" onclick="mClk('#');"><asp:linkbutton style="TEXT-DECORATION: none" id="btnVisualizar" runat="server" causesvalidation="False"><IMG height="16" src="../Imagens/office/S_F_NXTO.gif" width="16" align="absMiddle">  Exportar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td vAlign="top">
										<table class="3D" border="0" cellSpacing="0" cellPadding="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onmouseout="mOut(this,'');" onclick="mClk('#');"><asp:linkbutton style="Z-INDEX: 0; TEXT-DECORATION: none" id="btnCancelar" runat="server" causesvalidation="False"
														href="Principal.aspx"><IMG height="16" src="../Imagens/office/Sair.gif" width="16" align="absMiddle"> Sair</asp:linkbutton></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</tbody>
			</table>
			<table border="0" cellSpacing="0" cellPadding="0" height="67">
				<tbody>
					<tr>
						<td style="WIDTH: 100%" class="darkbox" vAlign="top">
							<table id="Table0" class="tabela1" border="0" cellSpacing="0" cellPadding="2" width="100%">
								<tbody>
									<tr id="Tr1" height="40" runat="server">
										<td style="HEIGHT: 35px" id="TDEspera" class="barra1" width="50%" align="left" runat="server">
											<div id="Div2" align="left" runat="server"><asp:image id="Image2" runat="server" imageurl="../Imagens/espera.gif"></asp:image>&nbsp;Carregando...
											</div>
										</td>
										<td style="HEIGHT: 35px" id="TDReserva" class="barra1" width="50%" align="left" runat="server"></td>
									</tr>
								</tbody>
							</table>
							<table id="Table1" class="tabela1" border="0" cellSpacing="0" cellPadding="2" width="100%">
								<tbody>
									<tr>
										<td style="WIDTH: 165px" class="barra3">
											<p align="right">Relatório:</p>
										</td>
										<td class="barra1"><asp:radiobuttonlist id="rdbRelatorio" runat="server" width="808px" autopostback="True">
												<asp:ListItem Value="0">Valores a Receber</asp:ListItem>
												<asp:ListItem Value="1">Valores Recebidos</asp:ListItem>
												<asp:ListItem Value="2">Verbas Carimbadas Realizado</asp:ListItem>
												<asp:ListItem Value="3">Verbas Carimbadas Cancelado</asp:ListItem>
												<asp:ListItem Value="4">Novos Acordos</asp:ListItem>
												<asp:ListItem Value="5">Acordos Cancelados</asp:ListItem>
												<asp:ListItem Value="6">Valores de Venda carimbo x Pendente a Faturar</asp:ListItem>
												<asp:ListItem Value="7">Valores Realizados Funding Carimbo</asp:ListItem>
											</asp:radiobuttonlist></td>
									</tr>
								</tbody>
							</table>
							<table id="tblTipoRelatorio" class="tabela1" border="0" cellSpacing="0" cellPadding="2"
								width="100%" runat="server">
								<tr>
									<td style="WIDTH: 165px" class="barra3">
										<p align="right">Tipo Relatório:</p>
									</td>
									<td class="barra1" colSpan="3"><asp:radiobuttonlist id="rdbTipoRelatorio" runat="server" width="88px">
											<asp:ListItem Value="0" Selected="True">Sint&#233;tico</asp:ListItem>
											<asp:ListItem Value="1">Anal&#237;tico</asp:ListItem>
										</asp:radiobuttonlist></td>
								</tr>
							</table>
							<table id="tblRadioTipoDestinoDesconto" class="tabela1" border="0" cellpadding="2" cellspacing="0"
								width="100%" runat="server">
								<TR>
									<TD style="WIDTH: 164px" class="barra3">Tipo Desconto Bonificação:</TD>
									<TD class="barra1">
										<asp:RadioButtonList id="rblTipDsnDscBnf" runat="server" Width="240px" RepeatDirection="Horizontal">
											<asp:ListItem Value="0" Selected="True">Carimbados</asp:ListItem>
											<asp:ListItem Value="1">Negocia&#231;&#227;o Devolu&#231;&#227;o</asp:ListItem>
										</asp:RadioButtonList></TD>
								</TR>
							</table>
							<table id="tblValoresReceber" class="tabela1" border="0" cellSpacing="0" cellPadding="2"
								width="100%" runat="server">
								<tr id="trDataGeracaoAcordo" runat="server">
									<td style="WIDTH: 164px" class="barra3">
										<p align="right">Ano/Mes Referência:</p>
									</td>
									<td class="barra1"><asp:dropdownlist id="ddlAnoMesReferencia" runat="server" Width="92px"></asp:dropdownlist></td>
								</tr>
								<tr id="trDataPrevisaoRecebimentos" runat="server">
									<td style="WIDTH: 164px" class="barra3">
										<p align="right">Data Previsão Recebimentos:</p>
									</td>
									<td class="barra1"><asp:textbox id="txtDataPrevisaoRecebimentos" onkeypress="TestaNumerico();FormataData(this);"
											runat="server" width="88px" cssclass="lightbox" maxlength="10"></asp:textbox></td>
								</tr>
							</table>
							<table id="tblPeriodo" class="tabela1" border="0" cellSpacing="0" cellPadding="2" width="100%"
								runat="server">
								<tr>
									<td style="WIDTH: 164px" class="barra3">
										<p align="right">Período:</p>
									</td>
									<td class="barra1" colSpan="3"><asp:textbox id="txtDataInicial" onkeypress="TestaNumerico();FormataData(this);" runat="server"
											width="88px" cssclass="lightbox" maxlength="10"></asp:textbox>&nbsp;A
										<asp:textbox id="txtDataFinal" onkeypress="TestaNumerico();FormataData(this);" runat="server"
											width="88px" cssclass="lightbox" maxlength="10"></asp:textbox></td>
								</tr>
							</table>
							<table id="tblPeriodoAnoMes" border="0" cellSpacing="0" cellPadding="2" width="100%" runat="server"
								cclass="tabela1">
								<tr>
									<td style="WIDTH: 164px" class="barra3">
										<p align="right">Período(Ano/Mês):</p>
									</td>
									<td class="barra1" colSpan="3">&nbsp;
										<asp:dropdownlist style="Z-INDEX: 0" id="ddlDataInicio" runat="server" Width="92px"></asp:dropdownlist>A
										<asp:dropdownlist style="Z-INDEX: 0" id="ddlDataFim" runat="server" Width="92px"></asp:dropdownlist></td>
								</tr>
							</table>
							<table id="tblMercadoria" class="tabela1" border="0" cellSpacing="0" cellPadding="2" width="100%"
								runat="server">
								<tr>
									<td style="WIDTH: 164px" class="barra3">
										<p align="right">Mercadoria:</p>
									</td>
									<td class="barra1" colSpan="3"><uc1:ucmercadoria id="UcMercadoria1" runat="server"></uc1:ucmercadoria></td>
								</tr>
							</table>
							<table id="tblFilial" class="tabela1" border="0" cellSpacing="0" cellPadding="2" width="100%"
								runat="server">
								<tr>
									<td style="WIDTH: 164px" class="barra3">
										<p align="right">Filial:</p>
									</td>
									<td class="barra1" colSpan="3"><asp:textbox id="txtFilial" onkeypress="TestaNumerico();" runat="server" width="88px" cssclass="lightbox"
											maxlength="10"></asp:textbox></td>
								</tr>
							</table>
							<table id="tblValoresRecebidos" class="tabela1" border="0" cellSpacing="0" cellPadding="2"
								width="100%" runat="server">
								<tr>
									<td style="WIDTH: 164px" class="barra3">
										<p align="right">Tipo Lançamento:</p>
									</td>
									<td class="barra1"><asp:dropdownlist id="ddlTipoLancamento" Width="156px" Runat="server">
											<asp:ListItem Value="TODOS">Todos</asp:ListItem>
											<asp:ListItem Value="DEDUCTION">Deduction</asp:ListItem>
											<asp:ListItem Value="DUPLICATA">Recebimento de Duplicata</asp:ListItem>
											<asp:ListItem Value="ACERTO">Acerto de Pedidos/Acordos</asp:ListItem>
											<asp:ListItem Value="OP">Recebimento de OP</asp:ListItem>
										</asp:dropdownlist></td>
								</tr>
							</table>
							<table id="tblDestino" class="tabela1" border="0" cellSpacing="0" cellPadding="2" width="100%"
								runat="server">
								<tr>
									<td style="WIDTH: 164px" class="barra3">
										<p align="right">Destino:</p>
									</td>
									<td class="barra1"><asp:dropdownlist id="ddlDestino" Width="156px" Runat="server">
											<asp:ListItem Value="00">Todos</asp:ListItem>
											<asp:ListItem Value="91">Pre&#231;o</asp:ListItem>
											<asp:ListItem Value="99">Margem</asp:ListItem>
										</asp:dropdownlist></td>
								</tr>
							</table>
							<table id="tblFornecedor" class="tabela1" border="0" cellSpacing="0" cellPadding="2" width="100%"
								runat="server">
								<tr>
									<td style="WIDTH: 163px" class="barra3">
										<p align="right">Fornecedor:</p>
									</td>
									<td class="barra1"><uc1:ucfornecedor id="UcFornecedor1" runat="server"></uc1:ucfornecedor></td>
								</tr>
							</table>
							<table id="tblObjetivoVerba" class="tabela1" border="0" cellSpacing="0" cellPadding="2"
								width="100%" runat="server">
								<tr>
									<td style="WIDTH: 164px" class="barra3">
										<p align="right">Tipo Objetivo Verba:</p>
									</td>
									<td class="barra1">
										<asp:dropdownlist id="ddlObjetivoVerba" Width="156px" Runat="server"></asp:dropdownlist>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</tbody>
			</table>
			</TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE><asp:label id="lblErro" runat="server" forecolor="Red" font-size="10px"></asp:label></form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
