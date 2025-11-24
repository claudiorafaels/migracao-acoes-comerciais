<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="AppComponents/wucFornecedor.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucContratoCapa" Src="ucContratoCapa.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucContratoTabelaDePrecos" Src="ucContratoTabelaDePrecos.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucContratoCondicaoPagamento" Src="ucContratoCondicaoPagamento.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucContratoRelacionamentos" Src="ucContratoRelacionamentos.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucContratoServicos" Src="ucContratoServicos.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucContratoAbrangenciaXFiliado" Src="ucContratoAbrangenciaXFiliado.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucAditamento" Src="Aditamento/ucAditamento.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Contrato.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.Contrato" %>
<%@ Register TagPrefix="uc1" TagName="ucContratoPeriodo" Src="ucContratoPeriodo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucContratoMercadoriaExcludente" Src="ucContratoMercadoriaExcludente.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucContratoAssociacao" Src="ucContratoAssociacao.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucContratoFaixa" Src="ucContratoFaixa.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucContratoCondicoesDeFrete" Src="ucContratoCondicoesDeFrete.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucContratoFormaDePagamento" Src="ucContratoFormaDePagamento.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucContratoClausula" Src="ucContratoClausula.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucContratoAbrangencia" Src="ucContratoAbrangencia.ascx" %>
<%@ Register TagPrefix="igtab" Namespace="Infragistics.WebUI.UltraWebTab" Assembly="Infragistics.WebUI.UltraWebTab.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igcmbo" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
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
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=0)">
		<meta http-equiv="Page-Exit" content="blendTrans(Duration=1)">
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
	<body onload="MM_preloadImages('../Imagens/lastpost.gif')" XMLNS:igtbl="http://schemas.infragistics.com/ASPNET/WebControls/UltraWebGrid">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="10" border="0">
				<tr>
					<td><A href="javascript:parent.resizeFrame('5,*')"><IMG id="Image1" onmouseover="MM_swapImage('Image1','','../Imagens/lastpost.gif',1)"
								onmouseout="MM_swapImage('Image1','','../Imagens/lastpost_l.gif',1)" height="12" src="../Imagens/lastpost_l.gif" width="12"
								name="Image1"></A></td>
				</tr>
			</table>
			<table style="WIDTH: 100%; HEIGHT: 57px" height="57" cellSpacing="0" cellPadding="0" width="706"
				border="0">
				<tbody>
					<tr>
						<td class="submenu2" vAlign="top">
							<table cellSpacing="0" cellPadding="0" border="0" id="tbOpcoes" runat="server">
								<tr>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnSalvar" style="TEXT-DECORATION: none" runat="server"><IMG height="16" src="../Imagens/office/salvar.gif" width="16" align="absMiddle"> Salvar e Validar</asp:linkbutton></td>
												<TD>
													<asp:linkbutton id="btnSalvarEContinuar" style="TEXT-DECORATION: none" runat="server"><IMG height="16" src="../Imagens/office/salvar.gif" width="16" align="absMiddle"> Salvar sem Validar</asp:linkbutton></TD>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnApagar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/apagar.gif" width="16" align="absMiddle">
													Excluir</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<TD></TD>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="cmdCancelarContrato" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
														ToolTip="Desativa o contrato"><IMG height="16" src="../Imagens/office/S_B_CANC.gif" width="16" align="absMiddle">  Desativar  Contrato</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnCancelar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/Sair.gif" width="16" align="absMiddle"> Sair</asp:linkbutton></td>
											</TR>
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
							<TABLE class="tabela1" id="Table0" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
								</TBODY>
							</TABLE>
							<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
									<TR>
										<TD class="barra1" height="19">
											<TABLE id="Table2" cellSpacing="0" cellPadding="0" align="left" border="0">
												<TR>
													<TD class="barra3" width="10%">Contrato:</TD>
													<TD width="90%"><igtxt:webnumericedit id="txtNroCnt" runat="server" ReadOnly="True" CssClass=" " Width="60px" Font-Names="Arial"
															Font-Size="11px"></igtxt:webnumericedit>
														<asp:Label id="lblErrotxtNroCnt" runat="server" Font-Size="Larger" Font-Names="Arial" ForeColor="#C00000">*</asp:Label></TD>
												</TR>
												<TR>
													<TD class="barra3" width="10%">Fornecedor:</TD>
													<TD width="90%"><uc1:wucfornecedor id="ucFornecedor" runat="server"></uc1:wucfornecedor>&nbsp;
														<asp:Label id="lblErroFornecedor" runat="server" Font-Size="Larger" Font-Names="Arial" ForeColor="#C00000">*</asp:Label></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
							<table>
							</table>
							<igtab:ultrawebtab id="webTab" runat="server" CssClass="submenu2" Width="100%" BorderStyle="Solid"
								DisplayMode="Scrollable" BarHeight="4" ForeColor="Gray" Font-Bold="True" Font-Names="Verdana">
								<DefaultTabStyle>
									<Padding Bottom="2px" Left="3px" Top="2px" Right="3px"></Padding>
								</DefaultTabStyle>
								<SelectedTabStyle ForeColor="Black"></SelectedTabStyle>
								<Tabs>
									<igtab:Tab Key="" Text="Geral" Tooltip="Capa">
										<ContentTemplate>
											<uc1:uccontratocapa id="ucContratoCapa" runat="server"></uc1:uccontratocapa>
										</ContentTemplate>
									</igtab:Tab>
									<igtab:TabSeparator>
										<Style Width="2px">
										</Style>
									</igtab:TabSeparator>
									<igtab:Tab Text="Cl&#225;usula" Tooltip="Cl&#225;usula">
										<ContentTemplate>
											<uc1:uccontratoclausula id="ucContratoClausula" runat="server"></uc1:uccontratoclausula>
										</ContentTemplate>
									</igtab:Tab>
									<igtab:TabSeparator>
										<Style Width="2px">
										</Style>
									</igtab:TabSeparator>
									<igtab:Tab Text="Abrangencia" Tooltip="Abrangencia">
										<ContentTemplate>
											<uc1:uccontratoabrangencia id="ucContratoAbrangencia" runat="server"></uc1:uccontratoabrangencia>
										</ContentTemplate>
									</igtab:Tab>
									<igtab:TabSeparator></igtab:TabSeparator>
									<igtab:Tab Text="Aditamento" Tooltip="Aditamento">
										<ContentTemplate>
											<uc1:ucAditamento id="UcAditamento1" runat="server"></uc1:ucAditamento>
										</ContentTemplate>
									</igtab:Tab>
									<igtab:TabSeparator>
										<Style Width="2px">
										</Style>
									</igtab:TabSeparator>
									<igtab:Tab Text="Faixa" Tooltip="Faixa">
										<ContentTemplate>
											<uc1:uccontratofaixa id="ucContratoFaixa" runat="server"></uc1:uccontratofaixa>
										</ContentTemplate>
									</igtab:Tab>
									<igtab:TabSeparator>
										<Style Width="2px">
										</Style>
									</igtab:TabSeparator>
									<igtab:Tab Text="Per&#237;odo" Tooltip="Per&#237;do">
										<ContentTemplate>
											<uc1:uccontratoperiodo id="ucContratoPeriodo" runat="server"></uc1:uccontratoperiodo>
										</ContentTemplate>
									</igtab:Tab>
									<igtab:TabSeparator>
										<Style Width="2px">
										</Style>
									</igtab:TabSeparator>
									<igtab:Tab Text="Itens Exc." Tooltip="Itens Excludentes">
										<ContentTemplate>
											<uc1:uccontratomercadoriaexcludente id="ucContratoMercadoriaExcludente" runat="server"></uc1:uccontratomercadoriaexcludente>
										</ContentTemplate>
									</igtab:Tab>
									<igtab:TabSeparator>
										<Style Width="2px">
										</Style>
									</igtab:TabSeparator>
									<igtab:Tab Text="Assoc. CTTs" Tooltip="Associa&#231;&#227;o de Contratos">
										<ContentTemplate>
											<uc1:uccontratoassociacao id="ucContratoAssociacao" runat="server"></uc1:uccontratoassociacao>
										</ContentTemplate>
									</igtab:Tab>
									<igtab:TabSeparator>
										<Style Width="2px">
										</Style>
									</igtab:TabSeparator>
									<igtab:Tab Text="Abrang. X Filiado" Tooltip="Abrangencia X Filiado" Visible="False">
										<ContentTemplate>
											<uc1:uccontratoabrangenciaxfiliado id="ucContratoAbrangenciaXFiliado" runat="server"></uc1:uccontratoabrangenciaxfiliado>
										</ContentTemplate>
									</igtab:Tab>
									<igtab:TabSeparator>
										<Style Width="2px">
										</Style>
									</igtab:TabSeparator>
									<igtab:Tab Text="Cond. Pgto" Tooltip="Condi&#231;&#227;o de Pagamento">
										<ContentTemplate>
											<uc1:uccontratocondicaopagamento id="ucContratoCondicaoPagamento" runat="server"></uc1:uccontratocondicaopagamento>
										</ContentTemplate>
									</igtab:Tab>
									<igtab:TabSeparator>
										<Style Width="2px">
										</Style>
									</igtab:TabSeparator>
									<igtab:Tab Text="Tabela Pre&#231;o" Tooltip="Tabela de Pre&#231;o">
										<ContentTemplate>
											<uc1:uccontratotabeladeprecos id="ucContratoTabelaDePrecos" runat="server"></uc1:uccontratotabeladeprecos>
										</ContentTemplate>
									</igtab:Tab>
									<igtab:TabSeparator>
										<Style Width="2px">
										</Style>
									</igtab:TabSeparator>
									<igtab:Tab Text="Forma Pgto" Tooltip="Forma de Pagamento">
										<ContentTemplate>
											<uc1:uccontratoformadepagamento id="ucContratoFormaDePagamento" runat="server"></uc1:uccontratoformadepagamento>
										</ContentTemplate>
									</igtab:Tab>
									<igtab:TabSeparator>
										<Style Width="2px">
										</Style>
									</igtab:TabSeparator>
									<igtab:Tab Text="Cond. Frete" Tooltip="Condi&#231;&#227;o Frete">
										<ContentTemplate>
											<uc1:uccontratocondicoesdefrete id="ucContratoCondicoesDeFrete" runat="server"></uc1:uccontratocondicoesdefrete>
										</ContentTemplate>
									</igtab:Tab>
									<igtab:TabSeparator>
										<Style Width="2px">
										</Style>
									</igtab:TabSeparator>
									<igtab:Tab Text="Servi&#231;os" Tooltip="Servi&#231;os">
										<ContentTemplate>
											<uc1:uccontratoservicos id="ucContratoServicos" runat="server"></uc1:uccontratoservicos>
										</ContentTemplate>
									</igtab:Tab>
									<igtab:TabSeparator>
										<Style Width="2px">
										</Style>
									</igtab:TabSeparator>
									<igtab:Tab Text="Relacion." Tooltip="Relacionamentos">
										<ContentTemplate>
											<uc1:uccontratorelacionamentos id="ucContratoRelacionamentos" runat="server"></uc1:uccontratorelacionamentos>
										</ContentTemplate>
									</igtab:Tab>
								</Tabs>
							</igtab:ultrawebtab></td>
					</tr>
				</tbody>
			</table>
			<asp:label id="lblErro" runat="server" ForeColor="Red" Font-Size="10px"></asp:label><BR>
		</form>
	</body>
</HTML>
