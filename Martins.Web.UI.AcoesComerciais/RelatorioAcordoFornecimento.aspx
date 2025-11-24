<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="martinscontrols" Namespace="Martins.Web.UI.Controls" Assembly="Martins.Web.UI.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=e9ed78c287a2fd3c" %>
<%@ Register TagPrefix="igcmbo" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igcmbo1" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RelatorioAcordoFornecimento.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.RelatorioAcordoFornecimento" %>
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

function MostrarJanelaModal() {
	var frmquebra = showModalDialog('RelatorioAcordoFornecimentoSimulacao.aspx','RelatorioAcordoFornecimentoSimulacao','dialogWidth:608px;dialogHeight:409px;center:1;')
	__doPostBack('lkbProcessaCloseModal','');
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
	<body onload="MM_preloadImages('../Imagens/lastpost.gif')">
		<form id="Form1" method="post" runat="server">
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
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td class="darkbox" vAlign="top">
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
							<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
									<TR>
										<TD class="barra3" id="TD1" runat="server">Opções</TD>
										<TD class="barra1" id="TD2" colSpan="3" runat="server"><asp:radiobuttonlist id="rdlOpcoes" runat="server" ForeColor="Black" Width="100%" AutoPostBack="True">
												<asp:ListItem Value="1" Selected="True">Fornecedor Sint&#233;tico</asp:ListItem>
												<asp:ListItem Value="2">Fornecedor Anal&#237;tico</asp:ListItem>
												<asp:ListItem Value="3">Simula&#231;&#227;o</asp:ListItem>
												<asp:ListItem Value="4">Simula&#231;&#227;o por c&#233;lula</asp:ListItem>
											</asp:radiobuttonlist></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD3" style="HEIGHT: 41px" runat="server">Célula:</TD>
										<TD class="barra1" id="TD4" style="HEIGHT: 28px" colSpan="3" runat="server"><asp:dropdownlist id="CmbCelula" runat="server" Width="250px" AutoPostBack="True" Height="19px" CssClass=""
												Font-Names="Arial" Font-Size="11px"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD5" style="HEIGHT: 38px" runat="server">Fornecedor:</TD>
										<TD class="barra1" id="TD6" style="HEIGHT: 38px" colSpan="3" runat="server"><uc1:wucfornecedor id="ucFornecedor" runat="server"></uc1:wucfornecedor></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD7" style="HEIGHT: 15px" runat="server">Contrato:</TD>
										<TD class="barra1" id="TD8" style="HEIGHT: 15px" colSpan="3" runat="server"><asp:dropdownlist id="CmbContrato" runat="server" Width="90px" AutoPostBack="True" Height="19px" CssClass=""
												Font-Names="Arial" Font-Size="11px"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD9" style="HEIGHT: 30px" runat="server">Cláusula:</TD>
										<TD class="barra1" id="TD10" style="HEIGHT: 30px" colSpan="3" runat="server"><igtxt:webnumericedit id="txtCodClausula" runat="server" Width="100px" AutoPostBack="True" CssClass=""
												Font-Names="Arial" Font-Size="11px"></igtxt:webnumericedit><asp:dropdownlist id="CmbClausula" runat="server" Width="250px" AutoPostBack="True" Height="19px"
												CssClass="" Font-Names="Arial" Font-Size="11px"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD11" style="HEIGHT: 19px" runat="server">Abrangencia:</TD>
										<TD class="barra1" id="TD12" style="HEIGHT: 19px" colSpan="3" runat="server"><igtxt:webnumericedit id="TxtCodAbrangencia" runat="server" Width="100px" AutoPostBack="True" CssClass=""
												Font-Names="Arial" Font-Size="11px"></igtxt:webnumericedit><asp:dropdownlist id="CmbAbrangencia" runat="server" Width="250px" AutoPostBack="True" Height="19px"
												CssClass="" Font-Names="Arial" Font-Size="11px"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD13" style="HEIGHT: 26px" runat="server">Entidade:</TD>
										<TD class="barra1" id="TD14" style="HEIGHT: 26px" colSpan="3" runat="server">
											<igtxt:WebMaskEdit id="CodEntidade" runat="server" Width="100px" Font-Names="Arial" Font-Size="11px"
												InputMask="9999999999999" HorizontalAlign="Right" AutoPostBack="True"></igtxt:WebMaskEdit>
											<asp:dropdownlist id="CmbEntidade" runat="server" Width="250px" AutoPostBack="True" Height="19px"
												CssClass="" Font-Names="Arial" Font-Size="11px"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD15" style="HEIGHT: 38px" runat="server">Tipo Período:</TD>
										<TD class="barra1" id="TD16" style="HEIGHT: 38px" colSpan="3" runat="server"><igtxt:webnumericedit id="txtCodTipoPeriodo" runat="server" Width="100px" AutoPostBack="True" CssClass=""
												Font-Names="Arial" Font-Size="11px"></igtxt:webnumericedit><asp:dropdownlist id="CmbTipoPeriodo" runat="server" Width="250px" AutoPostBack="True" Height="19px"
												CssClass="" Font-Names="Arial" Font-Size="11px"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD17" runat="server">Num. Período:</TD>
										<TD class="barra1" id="TD18" colSpan="3" runat="server"><igtxt:webnumericedit id="txtNumRefPod" runat="server" Width="60px" Height="19px" CssClass="" Font-Names="Arial"
												Font-Size="11px" ReadOnly="True"></igtxt:webnumericedit>&nbsp;
											<asp:label id="LblA" runat="server">De</asp:label>&nbsp;
											<igtxt:webdatetimeedit id="txtDataInicial" runat="server" Width="70px" Height="19px" CssClass="" Font-Names="Arial"
												Font-Size="11px" ReadOnly="True" MaxValue="2025-12-31" MinValue="1950-12-31"></igtxt:webdatetimeedit><asp:label id="Label1" runat="server">A</asp:label><igtxt:webdatetimeedit id="txtDataFinal" runat="server" Width="70px" Height="19px" CssClass="" Font-Names="Arial"
												Font-Size="11px" ReadOnly="True" MaxValue="2025-12-31" MinValue="1950-12-31"></igtxt:webdatetimeedit></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD19" runat="server">Comprador:</TD>
										<TD class="barra1" id="TD20" colSpan="3" runat="server"><asp:dropdownlist id="cmbComprador" runat="server" Width="230px" Height="19px" CssClass=" " Font-Names="Arial"
												Font-Size="11px"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD21" runat="server">Período:</TD>
										<TD class="barra1" id="TD22" colSpan="3" runat="server"><igtxt:webnumericedit id="txtCodTipoPeriodo2" runat="server" Width="60px" AutoPostBack="True" Height="19px"
												CssClass="" Font-Names="Arial" Font-Size="11px" ReadOnly="True"></igtxt:webnumericedit><asp:dropdownlist id="CmbTipoPeriodo2" runat="server" Width="230px" AutoPostBack="True" Height="19px"
												CssClass=" " Font-Names="Arial" Font-Size="11px"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD23" runat="server">Porcentagem:</TD>
										<TD class="barra1" id="TD24" colSpan="3" runat="server"><igtxt:webnumericedit id="txtPercentualInicial" runat="server" Width="60px" CssClass=" "></igtxt:webnumericedit>&nbsp;
											<asp:label id="Label2" runat="server" ForeColor="Black">A</asp:label>&nbsp;
											<igtxt:webnumericedit id="txtPercentualFinal" runat="server" Width="60px" CssClass=" "></igtxt:webnumericedit></TD>
									</TR>
									<TR>
										<TD class="barra3" id="TD25" runat="server">Itens:</TD>
										<TD class="barra1" id="TD26" colSpan="3" runat="server">
											<igtbl:ultrawebgrid id=uWebGrid runat="server" Width="370px" Height="105px" ImageDirectory="/ig_common/Images/" DataSource="<%# DatasetContratoXPeriodo1 %>" DataMember="T0124988">
												<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" TabDirection="TopToBottom"
													RowHeightDefault="21px" Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy"
													AllowColumnMovingDefault="OnServer" HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate"
													AllowColSizingDefault="Free" RowSelectorsDefault="No" Name="uWebGrid" TableLayout="Fixed" CellClickActionDefault="RowSelect">
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
													<FrameStyle Width="370px" BorderWidth="1px" Font-Size="11px" Font-Names="Arial" BorderColor="InactiveCaption"
														BorderStyle="Solid" BackColor="Window" Height="105px"></FrameStyle>
													<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
														<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
													</FooterStyleDefault>
													<GroupByBox Hidden="True" Prompt="Arraste uma coluna aqui para efetuar o agrupamento por esta coluna...">
														<Style BorderColor="Window" BackColor="ActiveBorder">
														</Style>
													</GroupByBox>
													<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>
													<RowStyleDefault BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" BackColor="Window">
														<Padding Left="3px"></Padding>
														<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
													</RowStyleDefault>
												</DisplayLayout>
												<Bands>
													<igtbl:UltraGridBand AddButtonCaption="T0124988" BaseTableName="T0124988" Key="T0124988" DataKeyField="NUMCTTFRN,NUMCSLCTTFRN,TIPPODCTTFRN,NUMREFPOD,DATINIPOD">
														<Columns>
															<igtbl:UltraGridColumn HeaderText="NUMCTTFRN" Key="NUMCTTFRN" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="NUMCTTFRN">
																<Footer Key="NUMCTTFRN"></Footer>
																<Header Key="NUMCTTFRN" Caption="NUMCTTFRN"></Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="NUMCSLCTTFRN" Key="NUMCSLCTTFRN" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="NUMCSLCTTFRN">
																<Footer Key="NUMCSLCTTFRN">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NUMCSLCTTFRN" Caption="NUMCSLCTTFRN">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="TIPPODCTTFRN" Key="TIPPODCTTFRN" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="TIPPODCTTFRN">
																<Footer Key="TIPPODCTTFRN">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TIPPODCTTFRN" Caption="TIPPODCTTFRN">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="NRO.REFER&#202;NCIA" Key="NUMREFPOD" IsBound="True" Width="100px" DataType="System.Decimal"
																BaseColumnName="NUMREFPOD">
																<CellStyle HorizontalAlign="Center"></CellStyle>
																<Footer Key="NUMREFPOD">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
																<Header Key="NUMREFPOD" Caption="NRO.REFER&#202;NCIA">
																	<Style HorizontalAlign="Right">
																	</Style>
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DATA INICIAL" Key="DATINIPOD" IsBound="True" Format="dd/MM/yyyy" DataType="System.DateTime"
																BaseColumnName="DATINIPOD">
																<CellButtonStyle HorizontalAlign="Center"></CellButtonStyle>
																<CellStyle HorizontalAlign="Center"></CellStyle>
																<Footer Key="DATINIPOD">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<Header Key="DATINIPOD" Caption="DATA INICIAL">
																	<Style HorizontalAlign="Center">
																	</Style>
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DATA FINAL" Key="DATFIMPOD" IsBound="True" Format="dd/MM/yyyy" DataType="System.DateTime"
																BaseColumnName="DATFIMPOD">
																<CellButtonStyle HorizontalAlign="Right"></CellButtonStyle>
																<CellStyle HorizontalAlign="Center"></CellStyle>
																<Footer Key="DATFIMPOD">
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<Header Key="DATFIMPOD" Caption="DATA FINAL">
																	<Style HorizontalAlign="Center">
																	</Style>
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="FLGESTAPUPOD" Key="FLGESTAPUPOD" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="FLGESTAPUPOD">
																<Footer Key="FLGESTAPUPOD">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="FLGESTAPUPOD" Caption="FLGESTAPUPOD">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="NUMSEQREFPOD" Key="NUMSEQREFPOD" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="NUMSEQREFPOD">
																<Footer Key="NUMSEQREFPOD">
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NUMSEQREFPOD" Caption="NUMSEQREFPOD">
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
														</Columns>
													</igtbl:UltraGridBand>
												</Bands>
											</igtbl:ultrawebgrid></TD>
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
