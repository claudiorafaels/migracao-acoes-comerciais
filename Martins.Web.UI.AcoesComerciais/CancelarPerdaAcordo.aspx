<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igcmbo" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtab" Namespace="Infragistics.WebUI.UltraWebTab" Assembly="Infragistics.WebUI.UltraWebTab.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="uc1" TagName="ucCancelarPerdaAcordoAtivo" Src="ucCancelarPerdaAcordoAtivo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucCancelarPerdaAcordoRelacionamento" Src="ucCancelarPerdaAcordoRelacionamento.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucCancelarPerdaAcordoOperacao" Src="ucCancelarPerdaAcordoOperacao.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CancelarPerdaAcordo.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.CancelarPerdaAcordo" %>
<%@ Register TagPrefix="uc1" TagName="ucCancelarPerdaAcordoDesativado" Src="ucCancelarPerdaAcordoDesativado.ascx" %>
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
							<table id="tbOpcoes" cellSpacing="0" cellPadding="0" border="0" runat="server">
								<tr>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnLimpar" style="TEXT-DECORATION: none" runat="server"><IMG height="16" src="../Imagens/office/S_F_NXTO.gif" width="16" align="absMiddle"> Limpar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnImprimir" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/Imprimir.gif" width="16" align="absMiddle"> Imprimir</asp:linkbutton></td>
												<TD><asp:linkbutton id="btnVisualizar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/S_F_NXTO.gif" width="16" align="absMiddle">  Exportar</asp:linkbutton></TD>
											</TR>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnPesquisar" style="TEXT-DECORATION: none" accessKey="p" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/Procurar.gif" width="16" align="absMiddle"> <u>P</u>esquisar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<TD></TD>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnSair" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/Sair.gif" width="16" align="absMiddle">  Sair</asp:linkbutton></td>
												<TD></TD>
											</tr>
										</table>
									</td>
								</tr>
							</table>
							<TABLE class="tabela1" id="Table0" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
									<TR id="trEspera" height="40" runat="server">
										<TD class="barra1" id="TDEspera" align="left" width="50%" runat="server">
											<DIV id="Div2" align="left" runat="server"><asp:image id="Image2" runat="server" ImageUrl="../Imagens/espera.gif"></asp:image>&nbsp;Carregando...
											</DIV>
										</TD>
										<TD class="barra1" id="TDReserva" align="left" width="50%" runat="server"></TD>
									</TR>
								</TBODY>
							</TABLE>
						</td>
					</tr>
					<tr>
						<td class="darkbox" vAlign="top">
							<TABLE class="tabela1" id="Table0" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
								</TBODY>
							</TABLE>
							<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
									<TR>
										<TD class="barra1" id="TbTopo" height="19" runat="server">
											<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
												<TR>
													<TD class="barra3" id="TD1" width="10%">Filtros:</TD>
													<TD id="TD2" width="15%"><asp:checkbox id="chkRelatorios" runat="server" Text="Relatórios" AutoPostBack="True" ForeColor="Black"></asp:checkbox>&nbsp;</TD>
													<TD width="75%"><asp:radiobuttonlist id="rblTipoFiltro" runat="server" AutoPostBack="True" Width="100%" Visible="False">
															<asp:ListItem Value="1">Cr&#233;ditos Dispon&#237;veis</asp:ListItem>
															<asp:ListItem Value="2">Abatimentos Realizados</asp:ListItem>
														</asp:radiobuttonlist></TD>
												</TR>
												<TR>
													<TD class="barra3" id="TD3" width="10%" runat="server">Célula:</TD>
													<TD id="TD4" width="90%" colSpan="2" runat="server"><asp:dropdownlist id="cmbCelula" runat="server" AutoPostBack="True" Width="250px" Font-Names="Arial"
															CssClass="" Font-Size="11px" Height="19px"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="barra3" id="TD5" width="10%" runat="server">Fornecedor:</TD>
													<TD id="TD6" width="90%" colSpan="2" runat="server"><uc1:wucfornecedor id="ucFornecedor" runat="server"></uc1:wucfornecedor></TD>
												</TR>
												<TR>
													<TD class="barra3" id="TD7" width="10%" runat="server">Data Abatimento:</TD>
													<TD id="TD8" width="90%" colSpan="2" runat="server"><igtxt:webdatetimeedit id="TxtDatIni" runat="server" Width="90px" CssClass="" MinValue="1950-12-31"
															MaxValue="2025-12-31"></igtxt:webdatetimeedit>&nbsp;
														<asp:label id="Label1" runat="server" ForeColor="Black">A</asp:label>&nbsp;
														<igtxt:webdatetimeedit id="TxtDatFim" runat="server" Width="90px" CssClass="" MaxValue="2025-12-31"></igtxt:webdatetimeedit></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
							<br>
							<table>
							</table>
							<igtab:ultrawebtab id="wtabCancelarPerdaAcordoAtivoDesativado" runat="server" ForeColor="Gray" Width="100%"
								Font-Names="Verdana" CssClass="submenu2" Font-Bold="True" BarHeight="4" DisplayMode="Scrollable"
								BorderStyle="Solid">
								<ScrollButtons Visibility="None"></ScrollButtons>
								<DefaultTabStyle>
									<Padding Bottom="2px" Left="3px" Top="2px" Right="3px"></Padding>
								</DefaultTabStyle>
								<SelectedTabStyle ForeColor="Black"></SelectedTabStyle>
								<Tabs>
									<igtab:Tab Key="1" AccessKey="o" Text="Ativ&lt;u&gt;o&lt;/u&gt;" Tooltip="Ativo">
										<ContentTemplate>
											<igtbl:ultrawebgrid id=grdCancelarPerdaAcordoAtivo runat="server" Width="100%" Height="125px" ImageDirectory="/ig_common/Images/" DataSource="<%# dsPerdasDisponiveis %>" DataMember="tbPerdasDisponiveis">
												<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" RowHeightDefault="20px"
													Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
													SelectTypeCellDefault="Single" HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate"
													AllowColSizingDefault="Free" RowSelectorsDefault="No" Name="wtabCancelarPerdaAcordoAtivoDesativadoxgrdCancelarPerdaAcordoAtivo"
													TableLayout="Fixed" NoDataMessage="Sem informa&#231;&#245;es neste momento...">
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
													<FrameStyle Width="100%" BorderWidth="1px" Font-Size="11px" Font-Names="Arial" BorderColor="InactiveCaption"
														BorderStyle="Solid" BackColor="Window" Height="125px"></FrameStyle>
													<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
														<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
													</FooterStyleDefault>
													<ClientSideEvents CellChangeHandler="grdCancelarPerdaAcordoAtivo_CellChangeHandler"></ClientSideEvents>
													<GroupByBox Hidden="True" Prompt="Arraste uma coluna aqui para efetuar o agrupamento por esta coluna...">
														<Style BorderColor="Window" BackColor="ActiveBorder"></Style>
													</GroupByBox>
													<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>
													<RowStyleDefault BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" BackColor="Window">
														<Padding Left="3px"></Padding>
														<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
													</RowStyleDefault>
												</DisplayLayout>
												<Bands>
													<igtbl:UltraGridBand AddButtonCaption="tbPerdasDisponiveis" BaseTableName="tbPerdasDisponiveis" SelectTypeRow="Single"
														Key="tbPerdasDisponiveis" AllowDelete="Yes">
														<Columns>
															<igtbl:UltraGridColumn Key="" Width="30px" Type="CheckBox" BaseColumnName="" AllowUpdate="Yes">
																<Footer Key=""></Footer>
																<Header Key=""></Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="CODFRN" Key="CODFRN" IsBound="True" Hidden="True" DataType="System.Int32"
																BaseColumnName="CODFRN">
																<Footer Key="CODFRN">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CODFRN" Caption="CODFRN">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Fornecedor" Key="NOMFRN" IsBound="True" Width="110px" BaseColumnName="NOMFRN">
																<Footer Key="NOMFRN">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NOMFRN" Caption="Fornecedor">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Contrato" Key="NUMCTTFRN" IsBound="True" Width="55px" DataType="System.Int32"
																BaseColumnName="NUMCTTFRN">
																<Footer Key="NUMCTTFRN">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NUMCTTFRN" Caption="Contrato">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Cl&#225;usula" Key="NUMCSLCTTFRN" IsBound="True" Width="55px" DataType="System.Int32"
																BaseColumnName="NUMCSLCTTFRN">
																<Footer Key="NUMCSLCTTFRN">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NUMCSLCTTFRN" Caption="Cl&#225;usula">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DesCslCttFrn" Key="DesCslCttFrn" IsBound="True" Hidden="True" BaseColumnName="DesCslCttFrn">
																<Footer Key="DesCslCttFrn">
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DesCslCttFrn" Caption="DesCslCttFrn">
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Per&#237;odo" Key="TIPPODCTTFRN" IsBound="True" Width="45px" Format=""
																DataType="System.Int32" BaseColumnName="TIPPODCTTFRN">
																<Footer Key="TIPPODCTTFRN">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TIPPODCTTFRN" Caption="Per&#237;odo">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DesPodCttFrn" Key="DesPodCttFrn" IsBound="True" Hidden="True" BaseColumnName="DesPodCttFrn">
																<Footer Key="DesPodCttFrn">
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DesPodCttFrn" Caption="DesPodCttFrn">
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Ref.Per&#237;odo" Key="NUMREFPOD" IsBound="True" Width="65px" DataType="System.Int32"
																BaseColumnName="NUMREFPOD">
																<Footer Key="NUMREFPOD">
																	<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NUMREFPOD" Caption="Ref.Per&#237;odo">
																	<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Entidade" Key="TIPEDEABGMIX" IsBound="True" Width="50px" DataType="System.Int32"
																BaseColumnName="TIPEDEABGMIX">
																<Footer Key="TIPEDEABGMIX">
																	<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TIPEDEABGMIX" Caption="Entidade">
																	<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DesEdeAbgMix" Key="DesEdeAbgMix" IsBound="True" Hidden="True" BaseColumnName="DesEdeAbgMix">
																<Footer Key="DesEdeAbgMix">
																	<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DesEdeAbgMix" Caption="DesEdeAbgMix">
																	<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Cod. Abrang." Key="CODEDEABGMIX" IsBound="True" Width="75px" DataType="System.Int32"
																BaseColumnName="CODEDEABGMIX">
																<Footer Key="CODEDEABGMIX">
																	<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CODEDEABGMIX" Caption="Cod. Abrang.">
																	<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Data Refer&#234;ncia" Key="DATREFAPU" IsBound="True" Width="85px" Format="dd/MM/yyyy"
																DataType="System.DateTime" BaseColumnName="DATREFAPU">
																<Footer Key="DATREFAPU">
																	<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DATREFAPU" Caption="Data Refer&#234;ncia">
																	<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Forma" Key="TIPFRMDSCBNF" IsBound="True" Width="40px" DataType="System.Int32"
																BaseColumnName="TIPFRMDSCBNF">
																<Footer Key="TIPFRMDSCBNF">
																	<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TIPFRMDSCBNF" Caption="Forma">
																	<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Empenho" Key="TIPDSNDSCBNFFRN" IsBound="True" Width="55px" DataType="System.Int32"
																BaseColumnName="TIPDSNDSCBNFFRN">
																<Footer Key="TIPDSNDSCBNFFRN">
																	<RowLayoutColumnInfo OriginX="14"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TIPDSNDSCBNFFRN" Caption="Empenho">
																	<RowLayoutColumnInfo OriginX="14"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Val.Des.Perda" Key="VLRDSPPDA" IsBound="True" Width="80px" DataType="System.Decimal"
																BaseColumnName="VLRDSPPDA">
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="VLRDSPPDA">
																	<RowLayoutColumnInfo OriginX="15"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="VLRDSPPDA" Caption="Val.Des.Perda">
																	<RowLayoutColumnInfo OriginX="15"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
														</Columns>
														<RowTemplateStyle BorderColor="Window" BorderStyle="Ridge" BackColor="Window">
															<BorderDetails WidthLeft="3px" WidthTop="3px" WidthRight="3px" WidthBottom="3px"></BorderDetails>
														</RowTemplateStyle>
														<SelectedRowStyle BorderColor="Transparent" BorderStyle="None" BackColor="ScrollBar"></SelectedRowStyle>
													</igtbl:UltraGridBand>
												</Bands>
											</igtbl:ultrawebgrid>
										</ContentTemplate>
									</igtab:Tab>
									<igtab:TabSeparator>
										<Style Width="2px">
										</Style>
									</igtab:TabSeparator>
									<igtab:Tab AccessKey="i" Text="Desat&lt;u&gt;i&lt;/u&gt;vado" Tooltip="Desativado">
										<ContentTemplate>
											<igtbl:ultrawebgrid id=grdCancelarPerdaAcordoDesativado runat="server" Width="100%" Height="125px" DataMember="T0153589" DataSource="<%# dsContratoFornecimentoXAbatimentoPerda %>" ImageDirectory="/ig_common/Images/">
												<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" RowHeightDefault="20px"
													Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
													HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
													RowSelectorsDefault="No" Name="wtabCancelarPerdaAcordoAtivoDesativadoxgrdCancelarPerdaAcordoDesativado"
													TableLayout="Fixed" NoDataMessage="Sem informa&#231;&#245;es neste momento...">
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
													<FrameStyle Width="100%" BorderWidth="1px" Font-Size="11px" Font-Names="Arial" BorderColor="InactiveCaption"
														BorderStyle="Solid" BackColor="Window" Height="125px"></FrameStyle>
													<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
														<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
													</FooterStyleDefault>
													<GroupByBox Hidden="True" Prompt="Arraste uma coluna aqui para efetuar o agrupamento por esta coluna...">
														<Style BorderColor="Window" BackColor="ActiveBorder"></Style>
													</GroupByBox>
													<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>
													<RowStyleDefault BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" BackColor="Window">
														<Padding Left="3px"></Padding>
														<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
													</RowStyleDefault>
												</DisplayLayout>
												<Bands>
													<igtbl:UltraGridBand AddButtonCaption="T0153589" BaseTableName="T0153589" SelectTypeRow="Single" Key="T0153589"
														AllowDelete="Yes" DataKeyField="NUMCTTFRN,NUMCSLCTTFRN,TIPPODCTTFRN,NUMREFPOD,TIPEDEABGMIX,CODEDEABGMIX,DATREFAPU,NUMSEQRLCCTTPMS">
														<Columns>
															<igtbl:UltraGridColumn HeaderText="Contrato" Key="NUMCTTFRN" IsBound="True" DataType="System.Decimal" BaseColumnName="NUMCTTFRN">
																<Footer Key="NUMCTTFRN"></Footer>
																<Header Key="NUMCTTFRN" Caption="Contrato"></Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Cl&#225;usula" Key="NUMCSLCTTFRN" IsBound="True" DataType="System.Decimal"
																BaseColumnName="NUMCSLCTTFRN">
																<Footer Key="NUMCSLCTTFRN">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NUMCSLCTTFRN" Caption="Cl&#225;usula">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Per&#237;odo" Key="TIPPODCTTFRN" IsBound="True" DataType="System.Decimal"
																BaseColumnName="TIPPODCTTFRN">
																<Footer Key="TIPPODCTTFRN">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TIPPODCTTFRN" Caption="Per&#237;odo">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Num. Ref. Per&#237;odo" Key="NUMREFPOD" IsBound="True" DataType="System.Decimal"
																BaseColumnName="NUMREFPOD">
																<Footer Key="NUMREFPOD">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NUMREFPOD" Caption="Num. Ref. Per&#237;odo">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Entidade" Key="TIPEDEABGMIX" IsBound="True" DataType="System.Decimal"
																BaseColumnName="TIPEDEABGMIX">
																<Footer Key="TIPEDEABGMIX">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TIPEDEABGMIX" Caption="Entidade">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Cod. Abrang&#234;ncia" Key="CODEDEABGMIX" IsBound="True" DataType="System.Decimal"
																BaseColumnName="CODEDEABGMIX">
																<Footer Key="CODEDEABGMIX">
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CODEDEABGMIX" Caption="Cod. Abrang&#234;ncia">
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Data Refer&#234;ncia" Key="DATREFAPU" IsBound="True" Format="dd/MM/yyyy"
																DataType="System.DateTime" BaseColumnName="DATREFAPU">
																<Footer Key="DATREFAPU">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DATREFAPU" Caption="Data Refer&#234;ncia">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Sequ&#234;ncia" Key="NUMSEQRLCCTTPMS" IsBound="True" DataType="System.Decimal"
																BaseColumnName="NUMSEQRLCCTTPMS">
																<Footer Key="NUMSEQRLCCTTPMS">
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NUMSEQRLCCTTPMS" Caption="Sequ&#234;ncia">
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Fornecedor" Key="CODFRN" IsBound="True" DataType="System.Decimal" BaseColumnName="CODFRN">
																<Footer Key="CODFRN">
																	<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CODFRN" Caption="Fornecedor">
																	<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DESOBSCTTFRN" Key="DESOBSCTTFRN" IsBound="True" Hidden="True" BaseColumnName="DESOBSCTTFRN">
																<Footer Key="DESOBSCTTFRN">
																	<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DESOBSCTTFRN" Caption="DESOBSCTTFRN">
																	<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="TIPCNCPDACTTFRN" Key="TIPCNCPDACTTFRN" IsBound="True" Hidden="True"
																BaseColumnName="TIPCNCPDACTTFRN">
																<Footer Key="TIPCNCPDACTTFRN">
																	<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TIPCNCPDACTTFRN" Caption="TIPCNCPDACTTFRN">
																	<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Vlr. Cr&#233;dito" Key="VLRCRDDISCTTFRN" IsBound="True" Format="R$  ###,###,##0.00"
																DataType="System.Decimal" BaseColumnName="VLRCRDDISCTTFRN">
																<Footer Key="VLRCRDDISCTTFRN">
																	<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="VLRCRDDISCTTFRN" Caption="Vlr. Cr&#233;dito">
																	<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Forma" Key="TIPFRMDSCBNF" IsBound="True" DataType="System.Decimal" BaseColumnName="TIPFRMDSCBNF">
																<Footer Key="TIPFRMDSCBNF">
																	<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TIPFRMDSCBNF" Caption="Forma">
																	<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Empenho" Key="TIPDSNDSCBNF" IsBound="True" DataType="System.Decimal"
																BaseColumnName="TIPDSNDSCBNF">
																<Footer Key="TIPDSNDSCBNF">
																	<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TIPDSNDSCBNF" Caption="Empenho">
																	<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Usu&#225;rio" Key="NOMUSRSIS" IsBound="True" BaseColumnName="NOMUSRSIS">
																<Footer Key="NOMUSRSIS">
																	<RowLayoutColumnInfo OriginX="14"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NOMUSRSIS" Caption="Usu&#225;rio">
																	<RowLayoutColumnInfo OriginX="14"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Dat. Gera&#231;&#227;o" Key="DATGRCOBSPMS" IsBound="True" Format="dd/MM/yyyy"
																DataType="System.DateTime" BaseColumnName="DATGRCOBSPMS">
																<Footer Key="DATGRCOBSPMS">
																	<RowLayoutColumnInfo OriginX="15"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DATGRCOBSPMS" Caption="Dat. Gera&#231;&#227;o">
																	<RowLayoutColumnInfo OriginX="15"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
														</Columns>
														<RowTemplateStyle BorderColor="Window" BorderStyle="Ridge" BackColor="Window">
															<BorderDetails WidthLeft="3px" WidthTop="3px" WidthRight="3px" WidthBottom="3px"></BorderDetails>
														</RowTemplateStyle>
														<SelectedRowStyle BorderColor="Transparent" BorderStyle="None" BackColor="ScrollBar"></SelectedRowStyle>
													</igtbl:UltraGridBand>
												</Bands>
											</igtbl:ultrawebgrid>
										</ContentTemplate>
									</igtab:Tab>
								</Tabs>
							</igtab:ultrawebtab><BR>
							<igtab:ultrawebtab id="wtabRelOp" runat="server" ForeColor="Gray" Width="100%" Font-Names="Verdana"
								CssClass="submenu2" Font-Bold="True" BarHeight="4" DisplayMode="Scrollable" BorderStyle="Solid">
								<ScrollButtons Visibility="None"></ScrollButtons>
								<DefaultTabStyle>
									<Padding Bottom="2px" Left="3px" Top="2px" Right="3px"></Padding>
								</DefaultTabStyle>
								<SelectedTabStyle ForeColor="Black"></SelectedTabStyle>
								<Tabs>
									<igtab:Tab AccessKey="m" Text="Relaciona&lt;u&gt;m&lt;/u&gt;ento" Tooltip="Relacionamento">
										<ContentTemplate>
											<igtab:ultrawebtab id="wtabAtivoDesativo" runat="server" ForeColor="Gray" Width="100%" CssClass="submenu2"
												Font-Names="Verdana" BorderStyle="Solid" DisplayMode="Scrollable" BarHeight="4" Font-Bold="True">
												<ScrollButtons Visibility="None"></ScrollButtons>
												<DefaultTabStyle>
													<Padding Bottom="2px" Left="3px" Top="2px" Right="3px"></Padding>
												</DefaultTabStyle>
												<SelectedTabStyle ForeColor="Black"></SelectedTabStyle>
												<Tabs>
													<igtab:Tab Key="1" AccessKey="v" Text="Ati&lt;u&gt;v&lt;/u&gt;o" Tooltip="Ativo">
														<ContentTemplate>
															<P>
																<igtbl:ultrawebgrid id=grdRelAtivo runat="server" Width="100%" Height="125px" DataMember="tbAbatimentoPerdasAcoFrn" DataSource="<%# dsAbatimentoPerdasAcoFrn %>" ImageDirectory="/ig_common/Images/">
																	<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" RowHeightDefault="20px"
																		Version="4.00" SelectTypeRowDefault="Single" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
																		SelectTypeCellDefault="Single" HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate"
																		AllowColSizingDefault="Free" RowSelectorsDefault="No" Name="wtabAtivoDesativoxgrdRelAtivo"
																		TableLayout="Fixed" NoDataMessage="Sem informa&#231;&#245;es neste momento...">
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
																		<FrameStyle Width="100%" BorderWidth="1px" Font-Size="11px" Font-Names="Arial" BorderColor="InactiveCaption"
																			BorderStyle="Solid" BackColor="Window" Height="125px"></FrameStyle>
																		<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
																			<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
																		</FooterStyleDefault>
																		<ClientSideEvents CellChangeHandler="grdRelAtivo_CellChangeHandler"></ClientSideEvents>
																		<GroupByBox Hidden="True" Prompt="Arraste uma coluna aqui para efetuar o agrupamento por esta coluna...">
																			<Style BorderColor="Window" BackColor="ActiveBorder"></Style>
																		</GroupByBox>
																		<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>
																		<RowStyleDefault BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" BackColor="Window">
																			<Padding Left="3px"></Padding>
																			<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
																		</RowStyleDefault>
																	</DisplayLayout>
																	<Bands>
																		<igtbl:UltraGridBand AddButtonCaption="tbAbatimentoPerdasAcoFrn" BaseTableName="tbAbatimentoPerdasAcoFrn"
																			SelectTypeRow="Single" Key="tbAbatimentoPerdasAcoFrn" AllowDelete="Yes">
																			<Columns>
																				<igtbl:UltraGridColumn HeaderText="" Key="" Width="30px" Type="CheckBox" DataType="System.Boolean" BaseColumnName=""
																					AllowUpdate="Yes">
																					<Footer Key=""></Footer>
																					<Header Key="" Caption=""></Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Contrato" Key="NUMCTTFRN" IsBound="True" DataType="System.Decimal" BaseColumnName="NUMCTTFRN">
																					<Footer Key="NUMCTTFRN">
																						<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="NUMCTTFRN" Caption="Contrato">
																						<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Num. Cl&#225;sula" Key="NUMCSLCTTFRN" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="NUMCSLCTTFRN">
																					<Footer Key="NUMCSLCTTFRN">
																						<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="NUMCSLCTTFRN" Caption="Num. Cl&#225;sula">
																						<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Tip. Per&#237;odo" Key="TIPPODCTTFRN" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="TIPPODCTTFRN">
																					<Footer Key="TIPPODCTTFRN">
																						<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="TIPPODCTTFRN" Caption="Tip. Per&#237;odo">
																						<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Num Refer&#234;ncia Per." Key="NUMREFPOD" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="NUMREFPOD">
																					<Footer Key="NUMREFPOD">
																						<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="NUMREFPOD" Caption="Num Refer&#234;ncia Per.">
																						<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Tip. Entidade" Key="TIPEDEABGMIX" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="TIPEDEABGMIX">
																					<Footer Key="TIPEDEABGMIX">
																						<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="TIPEDEABGMIX" Caption="Tip. Entidade">
																						<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Cod. Abrang&#234;ncia" Key="CODEDEABGMIX" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="CODEDEABGMIX">
																					<Footer Key="CODEDEABGMIX">
																						<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="CODEDEABGMIX" Caption="Cod. Abrang&#234;ncia">
																						<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Dat. Ref. Per&#237;odo" Key="DATREFAPU" IsBound="True" Format="dd/MM/yyyy"
																					DataType="System.DateTime" BaseColumnName="DATREFAPU">
																					<Footer Key="DATREFAPU">
																						<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="DATREFAPU" Caption="Dat. Ref. Per&#237;odo">
																						<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Sequ&#234;ncia" Key="NUMSEQRLCCTTPMS" IsBound="True" DataType="System.Int32"
																					BaseColumnName="NUMSEQRLCCTTPMS">
																					<Footer Key="NUMSEQRLCCTTPMS">
																						<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="NUMSEQRLCCTTPMS" Caption="Sequ&#234;ncia">
																						<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Cod. Emp. Per&#237;odo" Key="CODEMP" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="CODEMP">
																					<Footer Key="CODEMP">
																						<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="CODEMP" Caption="Cod. Emp. Per&#237;odo">
																						<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Cod. Filial Perda" Key="CODFILEMP" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="CODFILEMP">
																					<Footer Key="CODFILEMP">
																						<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="CODFILEMP" Caption="Cod. Filial Perda">
																						<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Promessa Perda" Key="CODPMS" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="CODPMS">
																					<Footer Key="CODPMS">
																						<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="CODPMS" Caption="Promessa Perda">
																						<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Dat. Negocia&#231;&#227;o Perda" Key="DATNGCPMS" IsBound="True" Format="dd/MM/yyyy"
																					DataType="System.DateTime" BaseColumnName="DATNGCPMS">
																					<Footer Key="DATNGCPMS">
																						<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="DATNGCPMS" Caption="Dat. Negocia&#231;&#227;o Perda">
																						<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Dat. Previs&#227;o Perda" Key="DATPRVRCBPMS" IsBound="True" Format="dd/MM/yyyy"
																					DataType="System.DateTime" BaseColumnName="DATPRVRCBPMS">
																					<Footer Key="DATPRVRCBPMS">
																						<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="DATPRVRCBPMS" Caption="Dat. Previs&#227;o Perda">
																						<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Forma Perda" Key="TIPFRMDSCBNF" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="TIPFRMDSCBNF">
																					<Footer Key="TIPFRMDSCBNF">
																						<RowLayoutColumnInfo OriginX="14"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="TIPFRMDSCBNF" Caption="Forma Perda">
																						<RowLayoutColumnInfo OriginX="14"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Empenho Perda" Key="TIPDSNDSCBNF" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="TIPDSNDSCBNF">
																					<Footer Key="TIPDSNDSCBNF">
																						<RowLayoutColumnInfo OriginX="15"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="TIPDSNDSCBNF" Caption="Empenho Perda">
																						<RowLayoutColumnInfo OriginX="15"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Cod. Fornecedor Perda" Key="CODFRN" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="CODFRN">
																					<Footer Key="CODFRN">
																						<RowLayoutColumnInfo OriginX="16"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="CODFRN" Caption="Cod. Fornecedor Perda">
																						<RowLayoutColumnInfo OriginX="16"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Contrato Perda" Key="NUMCTTFRNORIPDA" IsBound="True" DataType="System.Int32"
																					BaseColumnName="NUMCTTFRNORIPDA">
																					<Footer Key="NUMCTTFRNORIPDA">
																						<RowLayoutColumnInfo OriginX="17"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="NUMCTTFRNORIPDA" Caption="Contrato Perda">
																						<RowLayoutColumnInfo OriginX="17"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Num. Cl&#225;usula Perda" Key="NUMCSLCTTFRNORIPDA" IsBound="True" DataType="System.Int32"
																					BaseColumnName="NUMCSLCTTFRNORIPDA">
																					<Footer Key="NUMCSLCTTFRNORIPDA">
																						<RowLayoutColumnInfo OriginX="18"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="NUMCSLCTTFRNORIPDA" Caption="Num. Cl&#225;usula Perda">
																						<RowLayoutColumnInfo OriginX="18"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Tip. Per&#237;odo Perda" Key="TIPPODCTTFRNORIPDA" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="TIPPODCTTFRNORIPDA">
																					<Footer Key="TIPPODCTTFRNORIPDA">
																						<RowLayoutColumnInfo OriginX="19"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="TIPPODCTTFRNORIPDA" Caption="Tip. Per&#237;odo Perda">
																						<RowLayoutColumnInfo OriginX="19"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Num. Ref. Perda" Key="NUMREFPODORIPDA" IsBound="True" DataType="System.Int32"
																					BaseColumnName="NUMREFPODORIPDA">
																					<Footer Key="NUMREFPODORIPDA">
																						<RowLayoutColumnInfo OriginX="20"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="NUMREFPODORIPDA" Caption="Num. Ref. Perda">
																						<RowLayoutColumnInfo OriginX="20"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Tip. Entidade Perda" Key="TIPEDEABGMIXORIPDA" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="TIPEDEABGMIXORIPDA">
																					<Footer Key="TIPEDEABGMIXORIPDA">
																						<RowLayoutColumnInfo OriginX="21"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="TIPEDEABGMIXORIPDA" Caption="Tip. Entidade Perda">
																						<RowLayoutColumnInfo OriginX="21"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Cod. Entidade Perda" Key="CODEDEABGMIXORIPDA" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="CODEDEABGMIXORIPDA">
																					<Footer Key="CODEDEABGMIXORIPDA">
																						<RowLayoutColumnInfo OriginX="22"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="CODEDEABGMIXORIPDA" Caption="Cod. Entidade Perda">
																						<RowLayoutColumnInfo OriginX="22"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Dat. Ref. Perda" Key="DATREFAPUORIPDA" IsBound="True" Format="dd/MM/yyyy"
																					DataType="System.DateTime" BaseColumnName="DATREFAPUORIPDA">
																					<Footer Key="DATREFAPUORIPDA">
																						<RowLayoutColumnInfo OriginX="23"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="DATREFAPUORIPDA" Caption="Dat. Ref. Perda">
																						<RowLayoutColumnInfo OriginX="23"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Vlr. Cr&#233;dido Ref. Perda" Key="VLRCRDUTZCTTFRN" IsBound="True" Format="R$  ###,###,##0.00"
																					DataType="System.Decimal" BaseColumnName="VLRCRDUTZCTTFRN">
																					<Footer Key="VLRCRDUTZCTTFRN">
																						<RowLayoutColumnInfo OriginX="24"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="VLRCRDUTZCTTFRN" Caption="Vlr. Cr&#233;dido Ref. Perda">
																						<RowLayoutColumnInfo OriginX="24"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Dat. Gera&#231;&#227;o Cr&#233;dito Perda" Key="DATGRCRLCPDACTTFRN"
																					IsBound="True" Format="dd/MM/yyyy" DataType="System.DateTime" BaseColumnName="DATGRCRLCPDACTTFRN">
																					<Footer Key="DATGRCRLCPDACTTFRN">
																						<RowLayoutColumnInfo OriginX="25"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="DATGRCRLCPDACTTFRN" Caption="Dat. Gera&#231;&#227;o Cr&#233;dito Perda">
																						<RowLayoutColumnInfo OriginX="25"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Dat. Desativa&#231;&#227;o" Key="DATDSTRLCPDACTTFRN" IsBound="True"
																					Format="dd/MM/yyyy" DataType="System.DateTime" BaseColumnName="DATDSTRLCPDACTTFRN">
																					<Footer Key="DATDSTRLCPDACTTFRN">
																						<RowLayoutColumnInfo OriginX="26"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="DATDSTRLCPDACTTFRN" Caption="Dat. Desativa&#231;&#227;o">
																						<RowLayoutColumnInfo OriginX="26"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="TIPFRMDSCBNFORIPDA" Key="TIPFRMDSCBNFORIPDA" IsBound="True" Hidden="True"
																					DataType="System.Decimal" BaseColumnName="TIPFRMDSCBNFORIPDA">
																					<Footer Key="TIPFRMDSCBNFORIPDA">
																						<RowLayoutColumnInfo OriginX="27"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="TIPFRMDSCBNFORIPDA" Caption="TIPFRMDSCBNFORIPDA">
																						<RowLayoutColumnInfo OriginX="27"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="TIPDSNDSCBNFORIPDA" Key="TIPDSNDSCBNFORIPDA" IsBound="True" Hidden="True"
																					DataType="System.Decimal" BaseColumnName="TIPDSNDSCBNFORIPDA">
																					<Footer Key="TIPDSNDSCBNFORIPDA">
																						<RowLayoutColumnInfo OriginX="28"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="TIPDSNDSCBNFORIPDA" Caption="TIPDSNDSCBNFORIPDA">
																						<RowLayoutColumnInfo OriginX="28"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="DESOBSPMS" Key="DESOBSPMS" IsBound="True" Hidden="True" BaseColumnName="DESOBSPMS">
																					<Footer Key="DESOBSPMS">
																						<RowLayoutColumnInfo OriginX="29"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="DESOBSPMS" Caption="DESOBSPMS">
																						<RowLayoutColumnInfo OriginX="29"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="NOMUSRSIS" Key="NOMUSRSIS" IsBound="True" Hidden="True" BaseColumnName="NOMUSRSIS">
																					<Footer Key="NOMUSRSIS">
																						<RowLayoutColumnInfo OriginX="30"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="NOMUSRSIS" Caption="NOMUSRSIS">
																						<RowLayoutColumnInfo OriginX="30"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																			</Columns>
																			<RowTemplateStyle BorderColor="Window" BorderStyle="Ridge" BackColor="Window">
																				<BorderDetails WidthLeft="3px" WidthTop="3px" WidthRight="3px" WidthBottom="3px"></BorderDetails>
																			</RowTemplateStyle>
																			<SelectedRowStyle BorderColor="Transparent" BorderStyle="None" BackColor="ScrollBar"></SelectedRowStyle>
																		</igtbl:UltraGridBand>
																	</Bands>
																</igtbl:ultrawebgrid>
																<TABLE class="tabela1" id="Table5" cellSpacing="0" cellPadding="2" width="100%" border="0">
																	<TR>
																		<TD class="barra3" width="15%">Valor da Perda:</TD>
																		<TD class="barra1" width="20%" colSpan="3">
																			<igtxt:WebCurrencyEdit id="txtVlrPdaRel" runat="server" Width="120px" CssClass=" "></igtxt:WebCurrencyEdit></TD>
																		<TD class="barra3" width="15%">Valor do Crédito:</TD>
																		<TD class="barra1" width="20%">
																			<igtxt:WebCurrencyEdit id="txtVlrResRel" runat="server" Width="120px" CssClass=" "></igtxt:WebCurrencyEdit></TD>
																		<TD width="30%">
																			<TABLE id="Table3" cellSpacing="0" cellPadding="0" align="right" border="0">
																				<TR>
																					<TD onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');">
																						<asp:linkbutton id="btnImprimirAtivo" style="TEXT-DECORATION: none" runat="server"><IMG height="16" src="../Imagens/office/imprimir.gif" width="16" align="absMiddle">  Imprimir Ativo</asp:linkbutton></TD>
																					<TD onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');">
																						<asp:linkbutton id="btnDesativar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
																							Width="80"><IMG height="16" src="../Imagens/office/S_B_COLR.gif" width="16" align="absMiddle"> Desativar</asp:linkbutton></TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																</TABLE>
															</P>
														</ContentTemplate>
													</igtab:Tab>
													<igtab:TabSeparator>
														<Style Width="2px">
														</Style>
													</igtab:TabSeparator>
													<igtab:Tab AccessKey="t" Text="Desa&lt;u&gt;t&lt;/u&gt;ivado" Tooltip="Desativado">
														<ContentTemplate>
															<P>
																<igtbl:ultrawebgrid id=grdRelDesativado runat="server" Width="100%" Height="125px" DataMember="tbAbatimentoPerdasAcoFrn" DataSource="<%# dsAbatimentoPerdasAcoFrn %>" ImageDirectory="/ig_common/Images/" UseAccessibleHeader="False">
																	<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" RowHeightDefault="20px"
																		Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
																		HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
																		RowSelectorsDefault="No" Name="wtabAtivoDesativoxgrdRelDesativado" TableLayout="Fixed" NoDataMessage="Sem informa&#231;&#245;es neste momento...">
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
																		<FrameStyle Width="100%" BorderWidth="1px" Font-Size="11px" Font-Names="Arial" BorderColor="InactiveCaption"
																			BorderStyle="Solid" BackColor="Window" Height="125px"></FrameStyle>
																		<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
																			<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
																		</FooterStyleDefault>
																		<GroupByBox Hidden="True" Prompt="Arraste uma coluna aqui para efetuar o agrupamento por esta coluna...">
																			<Style BorderColor="Window" BackColor="ActiveBorder"></Style>
																		</GroupByBox>
																		<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>
																		<RowStyleDefault BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" BackColor="Window">
																			<Padding Left="3px"></Padding>
																			<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
																		</RowStyleDefault>
																	</DisplayLayout>
																	<Bands>
																		<igtbl:UltraGridBand AddButtonCaption="tbAbatimentoPerdasAcoFrn" BaseTableName="tbAbatimentoPerdasAcoFrn"
																			SelectTypeRow="Single" Key="tbAbatimentoPerdasAcoFrn" AllowDelete="Yes">
																			<Columns>
																				<igtbl:UltraGridColumn HeaderText="Contrato" Key="NUMCTTFRN" IsBound="True" DataType="System.Decimal" BaseColumnName="NUMCTTFRN">
																					<Footer Key="NUMCTTFRN"></Footer>
																					<Header Key="NUMCTTFRN" Caption="Contrato"></Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Num. Cl&#225;sula" Key="NUMCSLCTTFRN" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="NUMCSLCTTFRN">
																					<Footer Key="NUMCSLCTTFRN">
																						<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="NUMCSLCTTFRN" Caption="Num. Cl&#225;sula">
																						<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Tip. Per&#237;odo" Key="TIPPODCTTFRN" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="TIPPODCTTFRN">
																					<Footer Key="TIPPODCTTFRN">
																						<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="TIPPODCTTFRN" Caption="Tip. Per&#237;odo">
																						<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Num Refer&#234;ncia Per." Key="NUMREFPOD" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="NUMREFPOD">
																					<Footer Key="NUMREFPOD">
																						<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="NUMREFPOD" Caption="Num Refer&#234;ncia Per.">
																						<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Tip. Entidade" Key="TIPEDEABGMIX" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="TIPEDEABGMIX">
																					<Footer Key="TIPEDEABGMIX">
																						<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="TIPEDEABGMIX" Caption="Tip. Entidade">
																						<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Cod. Abrang&#234;ncia" Key="CODEDEABGMIX" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="CODEDEABGMIX">
																					<Footer Key="CODEDEABGMIX">
																						<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="CODEDEABGMIX" Caption="Cod. Abrang&#234;ncia">
																						<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Dat. Ref. Per&#237;odo" Key="DATREFAPU" IsBound="True" Format="dd/MM/yyyy"
																					DataType="System.DateTime" BaseColumnName="DATREFAPU">
																					<Footer Key="DATREFAPU">
																						<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="DATREFAPU" Caption="Dat. Ref. Per&#237;odo">
																						<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Sequ&#234;ncia" Key="NUMSEQRLCCTTPMS" IsBound="True" DataType="System.Int32"
																					BaseColumnName="NUMSEQRLCCTTPMS">
																					<Footer Key="NUMSEQRLCCTTPMS">
																						<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="NUMSEQRLCCTTPMS" Caption="Sequ&#234;ncia">
																						<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Cod. Emp. Per&#237;odo" Key="CODEMP" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="CODEMP">
																					<Footer Key="CODEMP">
																						<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="CODEMP" Caption="Cod. Emp. Per&#237;odo">
																						<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Cod. Filial Perda" Key="CODFILEMP" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="CODFILEMP">
																					<Footer Key="CODFILEMP">
																						<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="CODFILEMP" Caption="Cod. Filial Perda">
																						<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Promessa Perda" Key="CODPMS" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="CODPMS">
																					<Footer Key="CODPMS">
																						<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="CODPMS" Caption="Promessa Perda">
																						<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Dat. Negocia&#231;&#227;o Perda" Key="DATNGCPMS" IsBound="True" Format="dd/MM/yyyy"
																					DataType="System.DateTime" BaseColumnName="DATNGCPMS">
																					<Footer Key="DATNGCPMS">
																						<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="DATNGCPMS" Caption="Dat. Negocia&#231;&#227;o Perda">
																						<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Dat. Previs&#227;o Perda" Key="DATPRVRCBPMS" IsBound="True" Format="dd/MM/yyyy"
																					DataType="System.DateTime" BaseColumnName="DATPRVRCBPMS">
																					<Footer Key="DATPRVRCBPMS">
																						<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="DATPRVRCBPMS" Caption="Dat. Previs&#227;o Perda">
																						<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Forma Perda" Key="TIPFRMDSCBNF" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="TIPFRMDSCBNF">
																					<Footer Key="TIPFRMDSCBNF">
																						<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="TIPFRMDSCBNF" Caption="Forma Perda">
																						<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Empenho Perda" Key="TIPDSNDSCBNF" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="TIPDSNDSCBNF">
																					<Footer Key="TIPDSNDSCBNF">
																						<RowLayoutColumnInfo OriginX="14"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="TIPDSNDSCBNF" Caption="Empenho Perda">
																						<RowLayoutColumnInfo OriginX="14"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Cod. Fornecedor Perda" Key="CODFRN" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="CODFRN">
																					<Footer Key="CODFRN">
																						<RowLayoutColumnInfo OriginX="15"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="CODFRN" Caption="Cod. Fornecedor Perda">
																						<RowLayoutColumnInfo OriginX="15"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Contrato Perda" Key="NUMCTTFRNORIPDA" IsBound="True" DataType="System.Int32"
																					BaseColumnName="NUMCTTFRNORIPDA">
																					<Footer Key="NUMCTTFRNORIPDA">
																						<RowLayoutColumnInfo OriginX="16"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="NUMCTTFRNORIPDA" Caption="Contrato Perda">
																						<RowLayoutColumnInfo OriginX="16"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Num. Cl&#225;usula Perda" Key="NUMCSLCTTFRNORIPDA" IsBound="True" DataType="System.Int32"
																					BaseColumnName="NUMCSLCTTFRNORIPDA">
																					<Footer Key="NUMCSLCTTFRNORIPDA">
																						<RowLayoutColumnInfo OriginX="17"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="NUMCSLCTTFRNORIPDA" Caption="Num. Cl&#225;usula Perda">
																						<RowLayoutColumnInfo OriginX="17"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Tip. Per&#237;odo Perda" Key="TIPPODCTTFRNORIPDA" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="TIPPODCTTFRNORIPDA">
																					<Footer Key="TIPPODCTTFRNORIPDA">
																						<RowLayoutColumnInfo OriginX="18"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="TIPPODCTTFRNORIPDA" Caption="Tip. Per&#237;odo Perda">
																						<RowLayoutColumnInfo OriginX="18"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Num. Ref. Perda" Key="NUMREFPODORIPDA" IsBound="True" DataType="System.Int32"
																					BaseColumnName="NUMREFPODORIPDA">
																					<Footer Key="NUMREFPODORIPDA">
																						<RowLayoutColumnInfo OriginX="19"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="NUMREFPODORIPDA" Caption="Num. Ref. Perda">
																						<RowLayoutColumnInfo OriginX="19"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Tip. Entidade Perda" Key="TIPEDEABGMIXORIPDA" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="TIPEDEABGMIXORIPDA">
																					<Footer Key="TIPEDEABGMIXORIPDA">
																						<RowLayoutColumnInfo OriginX="20"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="TIPEDEABGMIXORIPDA" Caption="Tip. Entidade Perda">
																						<RowLayoutColumnInfo OriginX="20"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Cod. Entidade Perda" Key="CODEDEABGMIXORIPDA" IsBound="True" DataType="System.Decimal"
																					BaseColumnName="CODEDEABGMIXORIPDA">
																					<Footer Key="CODEDEABGMIXORIPDA">
																						<RowLayoutColumnInfo OriginX="21"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="CODEDEABGMIXORIPDA" Caption="Cod. Entidade Perda">
																						<RowLayoutColumnInfo OriginX="21"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Dat. Ref. Perda" Key="DATREFAPUORIPDA" IsBound="True" Format="dd/MM/yyyy"
																					DataType="System.DateTime" BaseColumnName="DATREFAPUORIPDA">
																					<Footer Key="DATREFAPUORIPDA">
																						<RowLayoutColumnInfo OriginX="22"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="DATREFAPUORIPDA" Caption="Dat. Ref. Perda">
																						<RowLayoutColumnInfo OriginX="22"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Vlr. Cr&#233;dido Ref. Perda" Key="VLRCRDUTZCTTFRN" IsBound="True" Format="R$  ###,###,##0.00"
																					DataType="System.Decimal" BaseColumnName="VLRCRDUTZCTTFRN">
																					<Footer Key="VLRCRDUTZCTTFRN">
																						<RowLayoutColumnInfo OriginX="23"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="VLRCRDUTZCTTFRN" Caption="Vlr. Cr&#233;dido Ref. Perda">
																						<RowLayoutColumnInfo OriginX="23"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Dat. Gera&#231;&#227;o Cr&#233;dito Perda" Key="DATGRCRLCPDACTTFRN"
																					IsBound="True" Format="dd/MM/yyyy" DataType="System.DateTime" BaseColumnName="DATGRCRLCPDACTTFRN">
																					<Footer Key="DATGRCRLCPDACTTFRN">
																						<RowLayoutColumnInfo OriginX="24"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="DATGRCRLCPDACTTFRN" Caption="Dat. Gera&#231;&#227;o Cr&#233;dito Perda">
																						<RowLayoutColumnInfo OriginX="24"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="Dat. Desativa&#231;&#227;o" Key="DATDSTRLCPDACTTFRN" IsBound="True"
																					Format="dd/MM/yyyy" DataType="System.DateTime" BaseColumnName="DATDSTRLCPDACTTFRN">
																					<Footer Key="DATDSTRLCPDACTTFRN">
																						<RowLayoutColumnInfo OriginX="25"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="DATDSTRLCPDACTTFRN" Caption="Dat. Desativa&#231;&#227;o">
																						<RowLayoutColumnInfo OriginX="25"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="TIPFRMDSCBNFORIPDA" Key="TIPFRMDSCBNFORIPDA" IsBound="True" Hidden="True"
																					DataType="System.Decimal" BaseColumnName="TIPFRMDSCBNFORIPDA">
																					<Footer Key="TIPFRMDSCBNFORIPDA">
																						<RowLayoutColumnInfo OriginX="26"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="TIPFRMDSCBNFORIPDA" Caption="TIPFRMDSCBNFORIPDA">
																						<RowLayoutColumnInfo OriginX="26"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="TIPDSNDSCBNFORIPDA" Key="TIPDSNDSCBNFORIPDA" IsBound="True" Hidden="True"
																					DataType="System.Decimal" BaseColumnName="TIPDSNDSCBNFORIPDA">
																					<Footer Key="TIPDSNDSCBNFORIPDA">
																						<RowLayoutColumnInfo OriginX="27"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="TIPDSNDSCBNFORIPDA" Caption="TIPDSNDSCBNFORIPDA">
																						<RowLayoutColumnInfo OriginX="27"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="DESOBSPMS" Key="DESOBSPMS" IsBound="True" Hidden="True" BaseColumnName="DESOBSPMS">
																					<Footer Key="DESOBSPMS">
																						<RowLayoutColumnInfo OriginX="28"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="DESOBSPMS" Caption="DESOBSPMS">
																						<RowLayoutColumnInfo OriginX="28"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																				<igtbl:UltraGridColumn HeaderText="NOMUSRSIS" Key="NOMUSRSIS" IsBound="True" Hidden="True" BaseColumnName="NOMUSRSIS">
																					<Footer Key="NOMUSRSIS">
																						<RowLayoutColumnInfo OriginX="29"></RowLayoutColumnInfo>
																					</Footer>
																					<Header Key="NOMUSRSIS" Caption="NOMUSRSIS">
																						<RowLayoutColumnInfo OriginX="29"></RowLayoutColumnInfo>
																					</Header>
																				</igtbl:UltraGridColumn>
																			</Columns>
																			<RowTemplateStyle BorderColor="Window" BorderStyle="Ridge" BackColor="Window">
																				<BorderDetails WidthLeft="3px" WidthTop="3px" WidthRight="3px" WidthBottom="3px"></BorderDetails>
																			</RowTemplateStyle>
																			<SelectedRowStyle BorderColor="Transparent" BorderStyle="None" BackColor="ScrollBar"></SelectedRowStyle>
																		</igtbl:UltraGridBand>
																	</Bands>
																</igtbl:ultrawebgrid>
																<TABLE class="tabela1" id="Table7" cellSpacing="0" cellPadding="2" width="100%" border="0">
																	<TR>
																		<TD class="barra1">
																			<TABLE id="Table3" cellSpacing="0" cellPadding="0" align="right" border="0">
																				<TR>
																					<TD onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');">
																						<asp:linkbutton id="btnImprimirDesativo" style="TEXT-DECORATION: none" runat="server"><IMG height="16" src="../Imagens/office/imprimir.gif" width="16" align="absMiddle">  Imprimir Desativo</asp:linkbutton></TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																</TABLE>
															</P>
														</ContentTemplate>
													</igtab:Tab>
												</Tabs>
											</igtab:ultrawebtab>
										</ContentTemplate>
									</igtab:Tab>
									<igtab:TabSeparator>
										<Style Width="2px">
										</Style>
									</igtab:TabSeparator>
									<igtab:Tab AccessKey="e" Text="Op&lt;u&gt;e&lt;/u&gt;ra&#231;&#227;o" Tooltip="Opera&#231;&#227;o">
										<ContentTemplate>
											<igtab:ultrawebtab id="wtabCttPms" runat="server" ForeColor="Gray" Width="100%" CssClass="submenu2"
												Font-Names="Verdana" BorderStyle="Solid" DisplayMode="Scrollable" BarHeight="4" Font-Bold="True">
												<ScrollButtons Visibility="None"></ScrollButtons>
												<DefaultTabStyle>
													<Padding Bottom="2px" Left="3px" Top="2px" Right="3px"></Padding>
												</DefaultTabStyle>
												<SelectedTabStyle ForeColor="Black"></SelectedTabStyle>
												<Tabs>
													<igtab:Tab AccessKey="t" Text="Con&lt;u&gt;t&lt;/u&gt;rato" Tooltip="Contrato">
														<ContentTemplate>
															<TABLE class="tabela1" id="Table4" cellSpacing="0" cellPadding="2" width="100%" border="0">
																<TR>
																	<TD class="barra1" style="HEIGHT: 41px" width="100%" colSpan="5">
																		<igtbl:ultrawebgrid id=grdContratos runat="server" Width="100%" Height="125px" DataMember="TbValoresApuradosContratosValidosDoFornecedor" DataSource="<%# dsValoresApuradosContratosValidosDoFornecedor %>" ImageDirectory="/ig_common/Images/">
																			<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" RowHeightDefault="20px"
																				Version="4.00" SelectTypeRowDefault="Single" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
																				SelectTypeCellDefault="Single" HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate"
																				AllowColSizingDefault="Free" RowSelectorsDefault="No" Name="wtabCttPmsxgrdContratos" TableLayout="Fixed"
																				NoDataMessage="Sem informa&#231;&#245;es neste momento...">
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
																				<FrameStyle Width="100%" BorderWidth="1px" Font-Size="11px" Font-Names="Arial" BorderColor="InactiveCaption"
																					BorderStyle="Solid" BackColor="Window" Height="125px"></FrameStyle>
																				<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
																					<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
																				</FooterStyleDefault>
																				<ClientSideEvents CellChangeHandler="grdContrato_CellChangeHandler"></ClientSideEvents>
																				<GroupByBox Prompt="Arraste uma coluna aqui para efetuar o agrupamento por esta coluna...">
																					<Style BorderColor="Window" BackColor="ActiveBorder"></Style>
																				</GroupByBox>
																				<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>
																				<RowStyleDefault BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" BackColor="Window">
																					<Padding Left="3px"></Padding>
																					<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
																				</RowStyleDefault>
																			</DisplayLayout>
																			<Bands>
																				<igtbl:UltraGridBand AddButtonCaption="TbValoresApuradosContratosValidosDoFornecedor" BaseTableName="TbValoresApuradosContratosValidosDoFornecedor"
																					SelectTypeRow="Single" Key="TbValoresApuradosContratosValidosDoFornecedor" AllowDelete="Yes">
																					<Columns>
																						<igtbl:UltraGridColumn Key="" Width="30px" Type="CheckBox" DataType="System.Boolean" BaseColumnName=""
																							AllowUpdate="Yes">
																							<Footer Key=""></Footer>
																							<Header Key=""></Header>
																						</igtbl:UltraGridColumn>
																						<igtbl:UltraGridColumn HeaderText="Contrato" Key="NUMCTTFRN" IsBound="True" DataType="System.Int32" BaseColumnName="NUMCTTFRN">
																							<Footer Key="NUMCTTFRN">
																								<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																							</Footer>
																							<Header Key="NUMCTTFRN" Caption="Contrato">
																								<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																							</Header>
																						</igtbl:UltraGridColumn>
																						<igtbl:UltraGridColumn HeaderText="Num. Cl&#225;usula" Key="NUMCSLCTTFRN" IsBound="True" DataType="System.Int32"
																							BaseColumnName="NUMCSLCTTFRN">
																							<Footer Key="NUMCSLCTTFRN">
																								<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																							</Footer>
																							<Header Key="NUMCSLCTTFRN" Caption="Num. Cl&#225;usula">
																								<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																							</Header>
																						</igtbl:UltraGridColumn>
																						<igtbl:UltraGridColumn HeaderText="Tip. Per&#237;odo" Key="TIPPODCTTFRN" IsBound="True" DataType="System.Int32"
																							BaseColumnName="TIPPODCTTFRN">
																							<Footer Key="TIPPODCTTFRN">
																								<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																							</Footer>
																							<Header Key="TIPPODCTTFRN" Caption="Tip. Per&#237;odo">
																								<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																							</Header>
																						</igtbl:UltraGridColumn>
																						<igtbl:UltraGridColumn HeaderText="Num. Ref. Per&#237;odo" Key="NUMREFPOD" IsBound="True" DataType="System.Int32"
																							BaseColumnName="NUMREFPOD">
																							<Footer Key="NUMREFPOD">
																								<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																							</Footer>
																							<Header Key="NUMREFPOD" Caption="Num. Ref. Per&#237;odo">
																								<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																							</Header>
																						</igtbl:UltraGridColumn>
																						<igtbl:UltraGridColumn HeaderText="Tip. Entidade" Key="TIPEDEABGMIX" IsBound="True" DataType="System.Int32"
																							BaseColumnName="TIPEDEABGMIX">
																							<Footer Key="TIPEDEABGMIX">
																								<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																							</Footer>
																							<Header Key="TIPEDEABGMIX" Caption="Tip. Entidade">
																								<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																							</Header>
																						</igtbl:UltraGridColumn>
																						<igtbl:UltraGridColumn HeaderText="Cod. Abrang&#234;ncia" Key="CODEDEABGMIX" IsBound="True" DataType="System.Int32"
																							BaseColumnName="CODEDEABGMIX">
																							<Footer Key="CODEDEABGMIX">
																								<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																							</Footer>
																							<Header Key="CODEDEABGMIX" Caption="Cod. Abrang&#234;ncia">
																								<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																							</Header>
																						</igtbl:UltraGridColumn>
																						<igtbl:UltraGridColumn HeaderText="Dat. Refer&#234;ncia" Key="DATREFAPU" IsBound="True" Format="dd/MM/yyyy"
																							DataType="System.DateTime" BaseColumnName="DATREFAPU">
																							<Footer Key="DATREFAPU">
																								<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																							</Footer>
																							<Header Key="DATREFAPU" Caption="Dat. Refer&#234;ncia">
																								<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																							</Header>
																						</igtbl:UltraGridColumn>
																						<igtbl:UltraGridColumn HeaderText="Forma" Key="TIPFRMDSCBNF" IsBound="True" DataType="System.Int32" BaseColumnName="TIPFRMDSCBNF">
																							<Footer Key="TIPFRMDSCBNF">
																								<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																							</Footer>
																							<Header Key="TIPFRMDSCBNF" Caption="Forma">
																								<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																							</Header>
																						</igtbl:UltraGridColumn>
																						<igtbl:UltraGridColumn HeaderText="Empenho" Key="TIPDSNDSCBNFFRN" IsBound="True" DataType="System.Int32"
																							BaseColumnName="TIPDSNDSCBNFFRN">
																							<Footer Key="TIPDSNDSCBNFFRN">
																								<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																							</Footer>
																							<Header Key="TIPDSNDSCBNFFRN" Caption="Empenho">
																								<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																							</Header>
																						</igtbl:UltraGridColumn>
																						<igtbl:UltraGridColumn HeaderText="Vlr. Dep&#243;sito" Key="VLRDSP" IsBound="True" Format="R$  ###,###,##0.00"
																							DataType="System.Decimal" BaseColumnName="VLRDSP">
																							<Footer Key="VLRDSP">
																								<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																							</Footer>
																							<Header Key="VLRDSP" Caption="Vlr. Dep&#243;sito">
																								<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																							</Header>
																						</igtbl:UltraGridColumn>
																					</Columns>
																					<RowTemplateStyle BorderColor="Window" BorderStyle="Ridge" BackColor="Window">
																						<BorderDetails WidthLeft="3px" WidthTop="3px" WidthRight="3px" WidthBottom="3px"></BorderDetails>
																					</RowTemplateStyle>
																					<SelectedRowStyle BorderColor="Transparent" BorderStyle="None" BackColor="ScrollBar"></SelectedRowStyle>
																				</igtbl:UltraGridBand>
																			</Bands>
																		</igtbl:ultrawebgrid></TD>
																</TR>
															</TABLE>
															<TABLE class="tabela1" id="Table5" cellSpacing="0" cellPadding="2" width="100%" border="0">
																<TR>
																	<TD class="barra3">Total Alocado Contrato:</TD>
																	<TD class="barra1" colSpan="3">
																		<igtxt:WebCurrencyEdit id="txtVlrCtt" runat="server" Width="120px" CssClass=" "></igtxt:WebCurrencyEdit></TD>
																	<TD class="barra1">
																		<TABLE id="Table6" cellSpacing="0" cellPadding="0" align="right" border="0">
																			<TR>
																				<TD onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');">
																					<asp:linkbutton id="btnImprimirContratos" style="TEXT-DECORATION: none" runat="server"><IMG height="16" src="../Imagens/office/imprimir.gif" width="16" align="absMiddle"> Imprimir Contrato</asp:linkbutton></TD>
																				<TD onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');">
																					<asp:linkbutton id="btnAbaterCtts" style="TEXT-DECORATION: none" runat="server" Width="80"><IMG height="16" src="../Imagens/office/S_B_COLR.gif" width="16" align="absMiddle"> Abater</asp:linkbutton></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
															</TABLE>
														</ContentTemplate>
													</igtab:Tab>
													<igtab:TabSeparator>
														<Style Width="2px">
														</Style>
													</igtab:TabSeparator>
													<igtab:Tab AccessKey="s" Text="Prome&lt;u&gt;s&lt;/u&gt;sa" Tooltip="Promessa">
														<ContentTemplate>
															<TABLE class="tabela1" id="Table7" cellSpacing="0" cellPadding="2" width="100%" border="0">
																<TR>
																	<TD class="barra1" style="HEIGHT: 41px" width="100%" colSpan="5">
																		<igtbl:ultrawebgrid id=grdPromessas runat="server" Width="100%" Height="125px" ImageDirectory="/ig_common/Images/" DataSource="<%# dsAcordosEmAbertoPorEmpenho %>" DataMember="tbAcordosEmAbertoPorEmpenho">
																			<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" RowHeightDefault="20px"
																				Version="4.00" SelectTypeRowDefault="Single" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
																				SelectTypeCellDefault="Single" HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate"
																				AllowColSizingDefault="Free" RowSelectorsDefault="No" Name="wtabCttPmsxgrdPromessas" TableLayout="Fixed"
																				NoDataMessage="Sem informa&#231;&#245;es neste momento...">
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
																				<FrameStyle Width="100%" BorderWidth="1px" Font-Size="11px" Font-Names="Arial" BorderColor="InactiveCaption"
																					BorderStyle="Solid" BackColor="Window" Height="125px"></FrameStyle>
																				<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
																					<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
																				</FooterStyleDefault>
																				<ClientSideEvents CellChangeHandler="grdPromessas_CellChangeHandler"></ClientSideEvents>
																				<GroupByBox Prompt="Arraste uma coluna aqui para efetuar o agrupamento por esta coluna...">
																					<Style BorderColor="Window" BackColor="ActiveBorder"></Style>
																				</GroupByBox>
																				<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>
																				<RowStyleDefault BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" BackColor="Window">
																					<Padding Left="3px"></Padding>
																					<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
																				</RowStyleDefault>
																			</DisplayLayout>
																			<Bands>
																				<igtbl:UltraGridBand AddButtonCaption="tbAcordosEmAbertoPorEmpenho" BaseTableName="tbAcordosEmAbertoPorEmpenho"
																					SelectTypeRow="Single" Key="tbAcordosEmAbertoPorEmpenho" AllowDelete="Yes">
																					<Columns>
																						<igtbl:UltraGridColumn Key="" Width="30px" Type="CheckBox" BaseColumnName="" AllowUpdate="Yes">
																							<Footer Key=""></Footer>
																							<Header Key=""></Header>
																						</igtbl:UltraGridColumn>
																						<igtbl:UltraGridColumn HeaderText="Cod. Emp." Key="CodEmp" IsBound="True" DataType="System.Int32" BaseColumnName="CodEmp">
																							<Footer Key="CodEmp">
																								<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																							</Footer>
																							<Header Key="CodEmp" Caption="Cod. Emp.">
																								<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																							</Header>
																						</igtbl:UltraGridColumn>
																						<igtbl:UltraGridColumn HeaderText="Cod. Filial" Key="CodFilEmp" IsBound="True" DataType="System.Int32"
																							BaseColumnName="CodFilEmp">
																							<Footer Key="CodFilEmp">
																								<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																							</Footer>
																							<Header Key="CodFilEmp" Caption="Cod. Filial">
																								<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																							</Header>
																						</igtbl:UltraGridColumn>
																						<igtbl:UltraGridColumn HeaderText="CodFrn" Key="CodFrn" IsBound="True" Hidden="True" DataType="System.Int32"
																							BaseColumnName="CodFrn">
																							<Footer Key="CodFrn">
																								<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																							</Footer>
																							<Header Key="CodFrn" Caption="CodFrn">
																								<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																							</Header>
																						</igtbl:UltraGridColumn>
																						<igtbl:UltraGridColumn HeaderText="Promessa" Key="CodPms" IsBound="True" DataType="System.Int32" BaseColumnName="CodPms">
																							<Footer Key="CodPms">
																								<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																							</Footer>
																							<Header Key="CodPms" Caption="Promessa">
																								<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																							</Header>
																						</igtbl:UltraGridColumn>
																						<igtbl:UltraGridColumn HeaderText="Dat. Negocia&#231;&#227;o" Key="DatNgcPms" IsBound="True" Format="dd/MM/yyyy"
																							DataType="System.DateTime" BaseColumnName="DatNgcPms">
																							<Footer Key="DatNgcPms">
																								<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																							</Footer>
																							<Header Key="DatNgcPms" Caption="Dat. Negocia&#231;&#227;o">
																								<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																							</Header>
																						</igtbl:UltraGridColumn>
																						<igtbl:UltraGridColumn HeaderText="Dat. Prevista" Key="DatPrvRcbPms" IsBound="True" Format="dd/MM/yyyy"
																							DataType="System.DateTime" BaseColumnName="DatPrvRcbPms">
																							<Footer Key="DatPrvRcbPms">
																								<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																							</Footer>
																							<Header Key="DatPrvRcbPms" Caption="Dat. Prevista">
																								<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																							</Header>
																						</igtbl:UltraGridColumn>
																						<igtbl:UltraGridColumn HeaderText="Forma Empenho" Key="TipFrmDscBnf" IsBound="True" DataType="System.Int32"
																							BaseColumnName="TipFrmDscBnf">
																							<Footer Key="TipFrmDscBnf">
																								<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																							</Footer>
																							<Header Key="TipFrmDscBnf" Caption="Forma Empenho">
																								<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																							</Header>
																						</igtbl:UltraGridColumn>
																						<igtbl:UltraGridColumn HeaderText="TipDsnDscBnf" Key="TipDsnDscBnf" IsBound="True" Hidden="True" DataType="System.Int32"
																							BaseColumnName="TipDsnDscBnf">
																							<Footer Key="TipDsnDscBnf">
																								<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																							</Footer>
																							<Header Key="TipDsnDscBnf" Caption="TipDsnDscBnf">
																								<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																							</Header>
																						</igtbl:UltraGridColumn>
																						<igtbl:UltraGridColumn HeaderText="CodSitPms" Key="CodSitPms" IsBound="True" Hidden="True" DataType="System.Int32"
																							BaseColumnName="CodSitPms">
																							<Footer Key="CodSitPms">
																								<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																							</Footer>
																							<Header Key="CodSitPms" Caption="CodSitPms">
																								<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																							</Header>
																						</igtbl:UltraGridColumn>
																						<igtbl:UltraGridColumn HeaderText="Vlr. Dep&#243;sito" Key="VlrDspPms" IsBound="True" Format="R$  ###,###,##0.00"
																							DataType="System.Decimal" BaseColumnName="VlrDspPms">
																							<Footer Key="VlrDspPms">
																								<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																							</Footer>
																							<Header Key="VlrDspPms" Caption="Vlr. Dep&#243;sito">
																								<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																							</Header>
																						</igtbl:UltraGridColumn>
																					</Columns>
																					<RowTemplateStyle BorderColor="Window" BorderStyle="Ridge" BackColor="Window">
																						<BorderDetails WidthLeft="3px" WidthTop="3px" WidthRight="3px" WidthBottom="3px"></BorderDetails>
																					</RowTemplateStyle>
																					<SelectedRowStyle BorderColor="Transparent" BorderStyle="None" BackColor="ScrollBar"></SelectedRowStyle>
																				</igtbl:UltraGridBand>
																			</Bands>
																		</igtbl:ultrawebgrid></TD>
																</TR>
															</TABLE>
															<TABLE class="tabela1" id="Table8" cellSpacing="0" cellPadding="2" width="100%" border="0">
																<TR>
																	<TD class="barra3">Total Alocado Acordo:</TD>
																	<TD class="barra1" colSpan="3">
																		<igtxt:WebCurrencyEdit id="txtVlrPms" runat="server" Width="120px" CssClass=" "></igtxt:WebCurrencyEdit></TD>
																	<TD class="barra1">
																		<TABLE id="Table9" cellSpacing="0" cellPadding="0" align="right" border="0">
																			<TR>
																				<TD onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');">
																					<asp:linkbutton id="btnImprimirAcordo" style="TEXT-DECORATION: none" runat="server"><IMG height="16" src="../Imagens/office/imprimir.gif" width="16" align="absMiddle"> Imprimir Acordo</asp:linkbutton></TD>
																				<TD onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');">
																					<asp:linkbutton id="btnAbaterAcordo" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
																						Width="80"><IMG height="16" src="../Imagens/office/S_B_COLR.gif" width="16" align="absMiddle"> Abater</asp:linkbutton></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
															</TABLE>
														</ContentTemplate>
													</igtab:Tab>
												</Tabs>
											</igtab:ultrawebtab>
											<BR>
											<TABLE class="tabela1" id="Table3" cellSpacing="0" cellPadding="2" width="100%" border="0">
												<TR>
													<TD class="barra3">Valor de Perda:</TD>
													<TD class="barra1" colSpan="3">
														<igtxt:WebCurrencyEdit id="txtVlrPda" runat="server" Width="120px" CssClass=" " ReadOnly="True"></igtxt:WebCurrencyEdit></TD>
													<TD class="barra3">Valor Restante:</TD>
													<TD class="barra1">
														<igtxt:WebCurrencyEdit id="txtVlrRes" runat="server" Width="120px" CssClass=" " ReadOnly="True"></igtxt:WebCurrencyEdit></TD>
													<TD class="barra1">&nbsp;
													</TD>
												</TR>
											</TABLE>
										</ContentTemplate>
									</igtab:Tab>
								</Tabs>
							</igtab:ultrawebtab></td>
					</tr>
				</tbody>
			</table>
			<asp:label id="lblErro" runat="server" ForeColor="Red" Font-Size="10px"></asp:label><BR>
			<INPUT id="txtHidObs" type="hidden" runat="server">
		</form>
		<script language="JavaScript" type="text/JavaScript">
<!--
	// txts das abas 
	var grdContratos = igtbl_getGridById("<%=grdContratos.ClientID%>");
	var grdPromessas = igtbl_getGridById("<%=grdPromessas.ClientID%>");
	var grdRelAtivo = igtbl_getGridById("<%=grdRelAtivo.ClientID%>");
	var lblVlrPda = igedit_getById("<%=txtVlrPda.ClientID%>");
	var lblVlrPdaRel = igedit_getById("<%=txtVlrPdaRel.ClientID%>");
	var lblVlrRes = igedit_getById("<%=txtVlrRes.ClientID%>");
	var lblVlrCtt = igedit_getById("<%=txtVlrCtt.ClientID%>");
	var lblVlrPms = igedit_getById("<%=txtVlrPms.ClientID%>");
	var lblVlrResRel = igedit_getById("<%=txtVlrResRel.ClientID%>");
	
function ValidarAbatimento(n, postID)
{
	try
	{
		if (!ValidarSelecaoGrid(n)) 
		{
			alert("Favor selecionar algum item do grid (principal)!"); 
			return false;
		}
		if (n == 5 || n == 6) 
		{
			if (!ValidaAbaterContratoPromessa()) return false;
		}
		
		if (!MostrarJanelaModalPromessa(postID)) return false;
		
		__doPostBack(postID, '');				
		return true;
	}
	catch(err)
	{
		alert(err.message);
		return false;
	}
}
	
function ValidarSelecaoGrid(n) {
	switch(n)
	{
		case 5:
			return VerificaGridPossuiSelecao(grdContratos);
			break    
		case 6:
			return VerificaGridPossuiSelecao(grdPromessas);
			break
		case 7:
			return VerificaGridPossuiSelecao(grdRelAtivo);
			break			
		default:
			alert("Função inválida!");
			return false;
	}
}

function VerificaGridPossuiSelecao(objGrd)
{
	// get reference to the rows collection
	var rows = objGrd.Rows;
	
	for (var i = 0; i < rows.length; i++) 
	{
		if (rows.getRow(i).getCell(0).getValue() == 'true') 
		{
			return true;
		}
	}
	return false;
}

/*
*	Atualiza outros campos apos valores dos grids serem mudados
*/
function AtualizaCamposAposSomaGrid() {
	lblVlrRes.setNumber(lblVlrPda.getNumber() - (lblVlrCtt.getNumber() + lblVlrPms.getNumber()));
}

/*
*	Recebe um grid e uma celula q foi clicada percore os selecionados e soma a coluna para
*	atualizar o label
*/
function SomaColunaSelecionadaGrid(objGrid, objCell, coluna, objLbl)
{
	if (objCell.Index == 0) 
	{
		// get reference to the rows collection
		var rows = objGrid.Rows;
		// get reference to row object
		//var row = igtbl_getRowById(cellId);
		var cellTotal = 0;
		
		for (var i = 0; i < rows.length; i++) 
		{
			if (rows.getRow(i).getCell(0).getValue() == 'true') 
			{			
				// retrieve column value
				cellTotal += rows.getRow(i).getCellFromKey(coluna).getValue();
			}
		}
		objLbl.setNumber(cellTotal);
		objCell.getNextCell().activate();
	}			
}

/*
*	Conta do grid de Ativos e soma para atualizar campos...
*/
function grdCancelarPerdaAcordoAtivo_CellChangeHandler(gridName, cellId){
	//Add code to handle your event here.
	var objCell = igtbl_getCellById(cellId);
	
	if (objCell.Index == 0) 
	{
		// get reference to the rows collection
		var rows = igtbl_getGridById(gridName).Rows;
		// get reference to row object
		//var row = igtbl_getRowById(cellId);
		var cellTotal = 0;
		var cellValue = objCell.getValue();
		
		for (var i = 0; i < rows.length; i++) 
		{
			rows.getRow(i).getCell(0).setValue(0);
		}

		if (cellValue == 'true')
		{
			objCell.setValue(1);
			lblVlrPda.setNumber(igtbl_getRowById(cellId).getCellFromKey('VLRDSPPDA').getValue());
		}
		else
		{
			lblVlrPda.setNumber(0);
		}
		lblVlrPdaRel.setNumber(lblVlrPda.getNumber());		
		AtualizaCamposAposSomaGrid();
		objCell.getNextCell().activate();
	}				

}

/*
*	Conta do grid de Contratos e soma para atualizar campos...
*/
function grdContrato_CellChangeHandler(gridName, cellId){
	//Add code to handle your event here.
	SomaColunaSelecionadaGrid(igtbl_getGridById(gridName), igtbl_getCellById(cellId), 'VLRDSP', lblVlrCtt);
	AtualizaCamposAposSomaGrid();
}

/*
*	Conta do grid de Promessas e soma para atualizar campos...
*/
function grdPromessas_CellChangeHandler(gridName, cellId){
	//Add code to handle your event here.
	SomaColunaSelecionadaGrid(igtbl_getGridById(gridName), igtbl_getCellById(cellId), 'VlrDspPms', lblVlrPms);
	AtualizaCamposAposSomaGrid();
}

/*
*	conta no grid os itens selecionados e soma para atualizar os txts
*/
function grdRelAtivo_CellChangeHandler(gridName, cellId) {
	//Add code to handle your event here.
	SomaColunaSelecionadaGrid(igtbl_getGridById(gridName), igtbl_getCellById(cellId), 'VLRCRDUTZCTTFRN', lblVlrResRel);
	AtualizaCamposAposSomaGrid();
}

function ValidaAbaterContratoPromessa()
{
	if (lblVlrResRel.getNumber() > lblVlrPda.getNumber())
	{
		return Confirm("Os valores do abatimento são maiores que da perda, serão abatidos apenas " & lblVlrPda.getNumber() & " dos primeiros itens informados. Deseja continuar ? ");
    }         
    else
    {
		return true;
	}
}

/*
* MOSTRA JANELA PARA ENTRAR COM A OBSERVACAO DA BAIXA...
*/
function MostrarJanelaModalPromessa(postID) 
{	
	var aRetorno = " ";
	aRetorno = showModalDialog('CancelarPerdaAcordoObsPms.aspx','Observação','dialogWidth:520px;dialogHeight:300px;center:1;');

	if(aRetorno != null) 
	{
		if(aRetorno.toString().length > 1) 
		{
			document.getElementById('<%=txtHidObs.ClientID%>').value = aRetorno.toString();
			__doPostBack(postID, '');
			return false;
		} 
	}
	if (confirm('Atenção você deve digitar uma observação!'))
	{
		return MostrarJanelaModalPromessa();
	}
	return false
}	


//-->
		</script>
	</body>
</HTML>
