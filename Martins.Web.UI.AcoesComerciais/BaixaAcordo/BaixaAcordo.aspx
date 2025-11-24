<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BaixaAcordo.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.BaixaAcordo" %>
<%@ Register TagPrefix="uc1" TagName="wucCentroCusto" Src="../AppComponents/wucCentroCusto.ascx" %>
<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="../AppComponents/wucFornecedor.ascx" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igcmbo" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Martins</TITLE>
		<meta name="vs_snapToGrid" content="False">
		<meta name="vs_showGrid" content="False">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../Imagens/Styles.css">
		<META content="text/html; charset=iso-8859-1" http-equiv="Content-Type">
		<script for="document" event="onreadystatechange">
			if (readyState == 'complete'){
				escondeAndamento();
			} else {
				mostraAndamento();			
			}
		</script>
		<SCRIPT language="JavaScript" type="text/javascript" src="../../Imagens/controle.js"></SCRIPT>
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

function CarregarJanelaObservacaoBaixaAcordoPago() {
	escondeAndamento();
	showModalDialog('ObservacaoBaixaAcordo.aspx?action=Pago','Selecao','dialogWidth:450px;dialogHeight:200px;center:1;');
	__doPostBack('lnkFecharTelaPago','');
	//__doPostBack('btnSair','');
}

function CarregarJanelaObservacaoBaixaAcordoPerda() {
	escondeAndamento();
	showModalDialog('ObservacaoBaixaAcordo.aspx?action=Perda','Selecao','dialogWidth:450px;dialogHeight:200px;center:1;');
	__doPostBack('lnkFecharTelaPerda','');
	//__doPostBack('btnSair','');
}
//-->
		</script>
		<script language="javascript">
			history.forward();
		</script>
		<LINK rel="stylesheet" type="text/css" href="styles_tabelas.css">
	</HEAD>
	<body onload="MM_preloadImages('../../Imagens/lastpost.gif')" XMLNS:igtbl="http://schemas.infragistics.com/ASPNET/WebControls/UltraWebGrid">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="10">
				<tr>
					<td><A href="javascript:parent.resizeFrame('5,*')"><IMG id="Image1" onmouseover="MM_swapImage('Image1','','../../Imagens/lastpost.gif',1)"
								onmouseout="MM_swapImage('Image1','','../../Imagens/lastpost_l.gif',1)" name="Image1" src="../../Imagens/lastpost_l.gif" width="12"
								height="12"></A></td>
				</tr>
			</table>
			<table style="HEIGHT: 510px" border="0" cellSpacing="0" cellPadding="0" width="100%" height="510">
				<tbody>
					<tr>
						<td class="submenu2" vAlign="top">
							<table id="tbOpcoes" border="0" cellSpacing="0" cellPadding="0" runat="server">
								<tr>
									<td>
										<table class="3D" border="0" cellSpacing="0" cellPadding="0">
											<TR>
												<td onmouseover="mOvr(this,'#E1EBF4');" onmouseout="mOut(this,'');" onclick="mClk('#');"><asp:linkbutton style="TEXT-DECORATION: none" id="btnPesquisar" runat="server" CausesValidation="False"><IMG height="16" src="../../Imagens/office/procurar.gif" width="16" align="absMiddle"> Pesquisar</asp:linkbutton></td>
											</TR>
										</table>
									</td>
									<td>
										<table class="3D" border="0" cellSpacing="0" cellPadding="0">
											<TR>
												<td onmouseover="mOvr(this,'#E1EBF4');" onmouseout="mOut(this,'');" onclick="mClk('#');"><asp:linkbutton style="TEXT-DECORATION: none" id="btnGravar" runat="server" CausesValidation="False"><IMG height="16" src="../../Imagens/office/salvar.gif" width="16" align="absMiddle"> Alterar Pago</asp:linkbutton></td>
											</TR>
										</table>
									</td>
									<td>
										<table class="3D" border="0" cellSpacing="0" cellPadding="0">
											<TR>
												<td onmouseover="mOvr(this,'#E1EBF4');" onmouseout="mOut(this,'');" onclick="mClk('#');"><asp:linkbutton style="TEXT-DECORATION: none" id="btnAlterarPerda" runat="server" CausesValidation="False"><IMG height="16" src="../../Imagens/office/salvar.gif" width="16" align="absMiddle"> Alterar Perda</asp:linkbutton></td>
											</TR>
										</table>
									</td>
									<td>
										<table class="3D" border="0" cellSpacing="0" cellPadding="0">
											<TR>
												<td onmouseover="mOvr(this,'#E1EBF4');" onmouseout="mOut(this,'');" onclick="mClk('#');"><asp:linkbutton style="TEXT-DECORATION: none" id="btnCancelar" runat="server" CausesValidation="False"><IMG height="16" src="../../Imagens/office/Sair.gif" width="16" align="absMiddle"> Sair</asp:linkbutton></td>
											</TR>
										</table>
									</td>
									<td>
										<table class="3D" border="0" cellSpacing="0" cellPadding="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onmouseout="mOut(this,'');" onclick="mClk('#');"><asp:linkbutton style="TEXT-DECORATION: none" id="cmdImprimir" runat="server" CausesValidation="False"
														Visible="False"><IMG height="16" src="../../Imagens/office/imprimir.gif" width="16" align="absMiddle">  Relatório</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" border="0" cellSpacing="0" cellPadding="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onmouseout="mOut(this,'');" onclick="mClk('#');"></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td class="darkbox" vAlign="top">
							<TABLE id="Table0" class="tabela1" border="0" cellSpacing="0" cellPadding="2" width="100%">
								<TBODY>
									<TR id="trEspera" runat="server">
										<TD id="TDEspera" class="barra1" width="50%" align="left" runat="server">
											<DIV id="Div2" align="left" runat="server"><asp:image id="Image2" runat="server" ImageUrl="../../Imagens/espera.gif"></asp:image>&nbsp;Carregando...
											</DIV>
										</TD>
										<TD id="TDReserva" class="barra1" width="50%" align="left" runat="server"></TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE id="Table1" class="tabela1" border="0" cellSpacing="0" cellPadding="2" width="100%">
								<TBODY>
									<TR>
										<TD class="barra3" width="10%">Objetivo:</TD>
										<TD class="barra1" width="13%"><asp:radiobuttonlist id="rblObjetivo" runat="server" AutoPostBack="True" Font-Names="Arial" Font-Size="11px"
												CssClass="" Width="115px">
												<asp:ListItem Value="1">Alterar Vr. Pago</asp:ListItem>
												<asp:ListItem Value="2">Alterar Vr. Perda</asp:ListItem>
											</asp:radiobuttonlist></TD>
										<TD class="barra3" width="10%">Identificação do Acordo:</TD>
										<TD class="barra1" width="67%">
											<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%">
												<TR>
													<TD>
														<P align="right">Filial:
														</P>
													</TD>
													<TD><asp:textbox id="txtfilial" runat="server" Font-Names="Arial" Font-Size="11px" Width="192px"
															Enabled="False"></asp:textbox>&nbsp;Acordo:
														<igtxt:webnumericedit id="txtCODPMS" runat="server" AutoPostBack="True" Font-Names="Arial" Font-Size="11px"
															CssClass="" Width="60px"></igtxt:webnumericedit>&nbsp; ou Pedido:
														<igtxt:webtextedit id="txtNUMPEDCMP" runat="server" AutoPostBack="True" Font-Names="Arial" Font-Size="11px"
															CssClass="" Width="80px" Height="19px"></igtxt:webtextedit><asp:dropdownlist id="cmbCODFILEMP" runat="server" Visible="False" Font-Names="Arial" Font-Size="11px"
															CssClass="" Width="105px" Height="19px"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 24px">
														<P align="right">Fornecedor:</P>
													</TD>
													<TD style="HEIGHT: 24px"><uc1:wucfornecedor id="ucFornecedor" runat="server"></uc1:wucfornecedor></TD>
												</TR>
												<TR>
													<TD>
														<P align="right">Período:
															<asp:dropdownlist id="ddl1" runat="server" AutoPostBack="True" Font-Names="Arial" Font-Size="11px"
																CssClass=" " Width="0px" Height="19px"></asp:dropdownlist></P>
													</TD>
													<TD><igtxt:webdatetimeedit id="txtDataInicial" runat="server" Font-Names="Arial" Font-Size="11px" CssClass=""
															Width="80px" Height="19px" PromptChar=" "></igtxt:webdatetimeedit>&nbsp;até
														<igtxt:webdatetimeedit id="txtDataFinal" runat="server" Font-Names="Arial" Font-Size="11px" CssClass=""
															Width="80px" Height="19px" PromptChar=" "></igtxt:webdatetimeedit></TD>
												</TR>
												<TR>
													<TD></TD>
													<TD>
														<P align="right">&nbsp;</P>
													</TD>
												</TR>
											</TABLE>
											<asp:linkbutton id="lnkFecharTelaPago" runat="server"></asp:linkbutton><asp:linkbutton id="lnkFecharTelaPerda" runat="server"></asp:linkbutton></TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE id="Table3" class="tabela1" border="0" cellSpacing="0" cellPadding="2" width="100%">
								<TR>
									<TD class="barra1" width="100%" colSpan="2"><igtbl:ultrawebgrid id=uwgPesquisa runat="server" Width="100%" Height="152px" DataSource="<%# DatasetAcordo1 %>" DataMember="TbAcoesComerciaisBaixa" ImageDirectory="/ig_common/Images/">
											<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" RowHeightDefault="20px"
												Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
												HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
												RowSelectorsDefault="No" Name="uwgPesquisa" TableLayout="Fixed" CellClickActionDefault="RowSelect">
												<AddNewBox Hidden="False">
													<Style BorderWidth="1px" BorderColor="InactiveCaption" BorderStyle="Solid" BackColor="Window">

<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
</BorderDetails>

													</Style>
												</AddNewBox>
												<Pager>
													<Style BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">

<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
</BorderDetails>

													</Style>
												</Pager>
												<HeaderStyleDefault BorderStyle="Solid" HorizontalAlign="Left" BackColor="LightGray">
													<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
												</HeaderStyleDefault>
												<GroupByRowStyleDefault BorderColor="Window" BackColor="Control"></GroupByRowStyleDefault>
												<FrameStyle Width="100%" BorderWidth="1px" Font-Size="8.25pt" Font-Names="Microsoft Sans Serif"
													BorderColor="InactiveCaption" BorderStyle="Solid" BackColor="Window" Height="152px"></FrameStyle>
												<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
													<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
												</FooterStyleDefault>
												<GroupByBox Hidden="True">
													<Style BorderColor="Window" BackColor="ActiveBorder"></Style>
												</GroupByBox>
												<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>
												<SelectedRowStyleDefault ForeColor="HighlightText" BackColor="Highlight"></SelectedRowStyleDefault>
												<RowStyleDefault BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" BackColor="Window">
													<Padding Left="3px"></Padding>
													<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
												</RowStyleDefault>
											</DisplayLayout>
											<Bands>
												<igtbl:UltraGridBand AddButtonCaption="TbAcoesComerciaisBaixa" BaseTableName="TbAcoesComerciaisBaixa"
													Key="TbAcoesComerciaisBaixa" DataKeyField="CODEMP,CODFILEMP,CODPMS,DATNGCPMS">
													<Columns>
														<igtbl:UltraGridColumn HeaderText="Promessa" Key="codpms" IsBound="True" Width="80px" DataType="System.Decimal"
															BaseColumnName="codpms">
															<Footer Key="codpms"></Footer>
															<Header Key="codpms" Caption="Promessa"></Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Pedido" Key="numpedcmp" IsBound="True" Width="80px" DataType="System.Decimal"
															BaseColumnName="numpedcmp">
															<Footer Key="numpedcmp">
																<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="numpedcmp" Caption="Pedido">
																<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Cod. Forn." Key="codfrn" IsBound="True" Width="80px" DataType="System.Decimal"
															BaseColumnName="codfrn">
															<Footer Key="codfrn">
																<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="codfrn" Caption="Cod. Forn.">
																<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Nome Fornecedor" Key="nomfrn" IsBound="True" Width="280px" BaseColumnName="nomfrn">
															<Footer Key="nomfrn">
																<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="nomfrn" Caption="Nome Fornecedor">
																<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Cod .F.Pagto" Key="tipfrmdscbnf" IsBound="True" Width="80px" DataType="System.Decimal"
															BaseColumnName="tipfrmdscbnf">
															<Footer Key="tipfrmdscbnf">
																<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="tipfrmdscbnf" Caption="Cod .F.Pagto">
																<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Descri&#231;&#227;o Forma Pagto" Key="desfrmdscbnf" IsBound="True" Width="200px"
															BaseColumnName="desfrmdscbnf">
															<Footer Key="desfrmdscbnf">
																<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="desfrmdscbnf" Caption="Descri&#231;&#227;o Forma Pagto">
																<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Cod. D.da Verba" Key="tipdsndscbnf" IsBound="True" Width="80px" DataType="System.Decimal"
															BaseColumnName="tipdsndscbnf">
															<Footer Key="tipdsndscbnf">
																<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="tipdsndscbnf" Caption="Cod. D.da Verba">
																<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Descri&#231;&#227;o Destino da Verba" Key="desdsndscbnf" IsBound="True"
															Width="200px" BaseColumnName="desdsndscbnf">
															<Footer Key="desdsndscbnf">
																<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="desdsndscbnf" Caption="Descri&#231;&#227;o Destino da Verba">
																<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Valor Negociado" Key="vlrngcpms" IsBound="True" Width="120px" DataType="System.Decimal"
															BaseColumnName="vlrngcpms">
															<Footer Key="vlrngcpms">
																<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="vlrngcpms" Caption="Valor Negociado">
																<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Valor Efetivado" Key="vlreftpms" IsBound="True" Width="120px" DataType="System.Decimal"
															BaseColumnName="vlreftpms">
															<Footer Key="vlreftpms">
																<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="vlreftpms" Caption="Valor Efetivado">
																<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Valor Pago" Key="vlrpgopms" IsBound="True" Width="120px" DataType="System.Decimal"
															BaseColumnName="vlrpgopms">
															<Footer Key="vlrpgopms">
																<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="vlrpgopms" Caption="Valor Pago">
																<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Previs&#227;o Recebto" Key="datprvrcbpms" IsBound="True" Width="120px"
															Format="dd/MM/yyyy" DataType="System.DateTime" BaseColumnName="datprvrcbpms">
															<Footer Key="datprvrcbpms">
																<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="datprvrcbpms" Caption="Previs&#227;o Recebto">
																<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Data Neg." Key="datngcpms" IsBound="True" Width="120px" Format="dd/MM/yyyy"
															DataType="System.DateTime" BaseColumnName="datngcpms">
															<Footer Key="datngcpms">
																<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="datngcpms" Caption="Data Neg.">
																<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Usu&#225;rio" Key="NomAcsUsrSis" IsBound="True" Width="120px" BaseColumnName="NomAcsUsrSis">
															<Footer Key="NomAcsUsrSis">
																<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="NomAcsUsrSis" Caption="Usu&#225;rio">
																<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Valor Perda Promessa" Key="vlrpdapms" IsBound="True" Width="120px" DataType="System.Decimal"
															BaseColumnName="vlrpdapms">
															<Footer Key="vlrpdapms">
																<RowLayoutColumnInfo OriginX="14"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="vlrpdapms" Caption="Valor Perda Promessa">
																<RowLayoutColumnInfo OriginX="14"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Situa&#231;&#227;o da Promessa" Key="codsitpms" IsBound="True" Width="120px"
															DataType="System.Decimal" BaseColumnName="codsitpms">
															<Footer Key="codsitpms">
																<RowLayoutColumnInfo OriginX="15"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="codsitpms" Caption="Situa&#231;&#227;o da Promessa">
																<RowLayoutColumnInfo OriginX="15"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
													</Columns>
												</igtbl:UltraGridBand>
											</Bands>
										</igtbl:ultrawebgrid></TD>
								</TR>
							</TABLE>
							<TABLE id="Table4" class="tabela1" border="0" cellSpacing="0" cellPadding="2" width="100%">
								<TBODY>
									<TR>
										<TD class="barra3" width="10%">Forma de Pagto</TD>
										<TD class="barra1" width="23%"><asp:textbox id="txtFormaPagto" runat="server" Font-Names="Arial" Font-Size="11px" CssClass=""
												Width="100%" ReadOnly="True"></asp:textbox></TD>
										<TD class="barra3" width="10%">Vr. Negociado</TD>
										<TD class="barra1" width="18%"><igtxt:webcurrencyedit id="txtValorNegociado" runat="server" Font-Names="Arial" Font-Size="11px" CssClass=""
												Width="90px" ReadOnly="True"></igtxt:webcurrencyedit></TD>
										<TD class="barra3" width="10%">Vr. Perda Anterior</TD>
										<TD class="barra1" width="29%"><igtxt:webcurrencyedit id="txtValorPerdaAnterior" runat="server" Font-Names="Arial" Font-Size="11px" CssClass=""
												Width="90px" ReadOnly="True"></igtxt:webcurrencyedit></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%">Destino da Verba</TD>
										<TD class="barra1" width="23%"><asp:textbox id="txtDestinoVerba" runat="server" Font-Names="Arial" Font-Size="11px" CssClass=""
												Width="100%" ReadOnly="True"></asp:textbox></TD>
										<TD class="barra3" width="10%">Vr. Efetivado</TD>
										<TD class="barra1" width="18%"><igtxt:webcurrencyedit id="txtValorEfetivado" runat="server" Font-Names="Arial" Font-Size="11px" CssClass=""
												Width="90px" ReadOnly="True"></igtxt:webcurrencyedit></TD>
										<TD class="barra3" width="10%">Vr. Perda</TD>
										<TD class="barra1" width="29%"><igtxt:webcurrencyedit id="txtValorPerda" runat="server" Font-Names="Arial" Font-Size="11px" CssClass=""
												Width="90px"></igtxt:webcurrencyedit></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%">Previsão de Recebto</TD>
										<TD class="barra1" width="23%"><igtxt:webdatetimeedit id="txtDataPrevisaoRecebimento" runat="server" Font-Names="Arial" Font-Size="11px"
												CssClass="" Width="90px" ReadOnly="True"></igtxt:webdatetimeedit></TD>
										<TD class="barra3" width="10%">Vr. Pago</TD>
										<TD class="barra1" width="18%"><igtxt:webcurrencyedit id="txtValorPago" runat="server" Font-Names="Arial" Font-Size="11px" CssClass=""
												Width="90px"></igtxt:webcurrencyedit></TD>
										<TD class="barra3" width="10%">C. Custo</TD>
										<TD class="barra1" width="29%">
											<uc1:wucCentroCusto id="ucCentroCusto" runat="server"></uc1:wucCentroCusto></TD>
									</TR>
								</TBODY>
							</TABLE>
							<P align="right">&nbsp;</P>
						</td>
					</tr>
				</tbody>
			</table>
		</form>
	</body>
</HTML>
