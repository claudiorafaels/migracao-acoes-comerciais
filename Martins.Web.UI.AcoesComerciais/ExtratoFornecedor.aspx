<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="AppComponents/wucFornecedor.ascx" %>
<%@ Register TagPrefix="uc1" TagName="wucEmpenho" Src="AppComponents/wucEmpenho.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ExtratoFornecedor.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.ExtratoFornecedor" %>
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
		<form id="Form1" method="post" runat="server" onsubmit="mostraAndamento()">
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
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnPesquisar" style="TEXT-DECORATION: none" runat="server"><img src="../Imagens/office/procurar.gif" width="16" height="16" align="absMiddle">Pesquisar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
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
								<TR>
									<TD class="barra3" style="WIDTH: 90px">Fornecedor:
									</TD>
									<TD class="barra1" colSpan="3"><uc1:wucfornecedor id="ucFornecedor" runat="server"></uc1:wucfornecedor></TD>
								</TR>
							</TABLE>
							<TABLE class="tabela2" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
									<TR>
										<TD class="barra3" style="HEIGHT: 19px">Empenho:</TD>
										<TD class="barra1" style="WIDTH: 315px; HEIGHT: 19px"><igtxt:webnumericedit id="txtEmpenho" runat="server" AutoPostBack="True" Font-Names="Arial" Font-Size="11px"
												Width="60px" CssClass=""></igtxt:webnumericedit><asp:dropdownlist id="cmbEmpenho" runat="server" AutoPostBack="True" Font-Names="Arial" Font-Size="11px"
												Width="200px" CssClass=""></asp:dropdownlist></TD>
										<TD class="barra3" style="WIDTH: 97px; HEIGHT: 19px">Período:</TD>
										<TD class="barra1" style="HEIGHT: 19px"><igtxt:webdatetimeedit id="txtDataInicial" runat="server" Font-Names="arial" Font-Size="11px" Width="90px"
												CssClass="" Height="19px"></igtxt:webdatetimeedit><asp:label id="Label1" runat="server"> A </asp:label><igtxt:webdatetimeedit id="txtDataFinal" runat="server" Font-Names="arial" Font-Size="11px" Width="90px"
												CssClass="" Height="19px"></igtxt:webdatetimeedit></TD>
									</TR>
									<TR>
										<TD class="barra3">Lançamentos:</TD>
										<TD class="barra1" colSpan="3"><igtbl:ultrawebgrid id=grdLancamentos runat="server" Width="100%" Height="125px" ImageDirectory="/ig_common/Images/" UseAccessibleHeader="False" DataSource="<%# dsRelatorioExtratoContaCorrrente %>" DataMember="TbExtratoContaCorrrente_048">
												<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" RowHeightDefault="20px"
													Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
													HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
													RowSelectorsDefault="No" Name="grdLancamentos" TableLayout="Fixed">
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
														BorderColor="InactiveCaption" BorderStyle="Solid" BackColor="Window" Height="125px"></FrameStyle>
													<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
														<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
													</FooterStyleDefault>
													<GroupByBox Hidden="True">
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
													<igtbl:UltraGridBand AddButtonCaption="TbExtratoContaCorrrente_048" BaseTableName="TbExtratoContaCorrrente_048"
														Key="TbExtratoContaCorrrente_048">
														<Columns>
															<igtbl:UltraGridColumn HeaderText="Data" Key="DatRefLmt" IsBound="True" DataType="System.DateTime" BaseColumnName="DatRefLmt">
																<Footer Key="DatRefLmt"></Footer>
																<Header Key="DatRefLmt" Caption="Data"></Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Seq" Key="NumSeqLmt" IsBound="True" Width="30px" DataType="System.Int32"
																BaseColumnName="NumSeqLmt">
																<Footer Key="NumSeqLmt">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NumSeqLmt" Caption="Seq">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Empenho" Key="DesDsnDscBnf" IsBound="True" Width="200px" BaseColumnName="DesDsnDscBnf">
																<Footer Key="DesDsnDscBnf">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DesDsnDscBnf" Caption="Empenho">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Tipo Lan&#231;amento" Key="DesTipLmt" IsBound="True" Width="200px" BaseColumnName="DesTipLmt">
																<Footer Key="DesTipLmt">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DesTipLmt" Caption="Tipo Lan&#231;amento">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Hist&#243;rico" Key="DesHstLmt" IsBound="True" Width="250px" BaseColumnName="DesHstLmt">
																<Footer Key="DesHstLmt">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DesHstLmt" Caption="Hist&#243;rico">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Valor" Key="VlrLmtCtb" IsBound="True" Width="120px" DataType="System.Decimal"
																BaseColumnName="VlrLmtCtb">
																<SelectedCellStyle HorizontalAlign="Right"></SelectedCellStyle>
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="VlrLmtCtb">
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
																<Header Key="VlrLmtCtb" Caption="Valor">
																	<Style HorizontalAlign="Right">
																	</Style>
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="CodTipLmt" Key="CodTipLmt" IsBound="True" Hidden="True" DataType="System.Int32"
																BaseColumnName="CodTipLmt">
																<Footer Key="CodTipLmt">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CodTipLmt" Caption="CodTipLmt">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Usu&#225;rio" Key="NomAcsUsrGrcLmt" IsBound="True" Width="120px" BaseColumnName="NomAcsUsrGrcLmt">
																<Footer Key="NomAcsUsrGrcLmt">
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NomAcsUsrGrcLmt" Caption="Usu&#225;rio">
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="VlrSldMesAnt" Key="VlrSldMesAnt" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="VlrSldMesAnt">
																<Footer Key="VlrSldMesAnt">
																	<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="VlrSldMesAnt" Caption="VlrSldMesAnt">
																	<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="VlrCrdMesCrr" Key="VlrCrdMesCrr" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="VlrCrdMesCrr">
																<Footer Key="VlrCrdMesCrr">
																	<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="VlrCrdMesCrr" Caption="VlrCrdMesCrr">
																	<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="VlrDebMesCrr" Key="VlrDebMesCrr" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="VlrDebMesCrr">
																<Footer Key="VlrDebMesCrr">
																	<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="VlrDebMesCrr" Caption="VlrDebMesCrr">
																	<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="VlrSldPms" Key="VlrSldPms" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="VlrSldPms">
																<Footer Key="VlrSldPms">
																	<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="VlrSldPms" Caption="VlrSldPms">
																	<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="TipDsnDscEvtAcoCmc" Key="TipDsnDscEvtAcoCmc" IsBound="True" Hidden="True"
																DataType="System.Decimal" BaseColumnName="TipDsnDscEvtAcoCmc">
																<Footer Key="TipDsnDscEvtAcoCmc">
																	<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TipDsnDscEvtAcoCmc" Caption="TipDsnDscEvtAcoCmc">
																	<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="FlgCtbDsnDsc" Key="FlgCtbDsnDsc" IsBound="True" Hidden="True" BaseColumnName="FlgCtbDsnDsc">
																<Footer Key="FlgCtbDsnDsc">
																	<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="FlgCtbDsnDsc" Caption="FlgCtbDsnDsc">
																	<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="CodFrn" Key="CodFrn" IsBound="True" Hidden="True" DataType="System.Int32"
																BaseColumnName="CodFrn">
																<Footer Key="CodFrn">
																	<RowLayoutColumnInfo OriginX="14"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CodFrn" Caption="CodFrn">
																	<RowLayoutColumnInfo OriginX="14"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="NomFrn" Key="NomFrn" IsBound="True" Hidden="True" BaseColumnName="NomFrn">
																<Footer Key="NomFrn">
																	<RowLayoutColumnInfo OriginX="15"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NomFrn" Caption="NomFrn">
																	<RowLayoutColumnInfo OriginX="15"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="SldDsp" Key="SldDsp" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="SldDsp">
																<Footer Key="SldDsp">
																	<RowLayoutColumnInfo OriginX="16"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="SldDsp" Caption="SldDsp">
																	<RowLayoutColumnInfo OriginX="16"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DesVarHstPad" Key="DesVarHstPad" IsBound="True" Hidden="True" BaseColumnName="DesVarHstPad">
																<Footer Key="DesVarHstPad">
																	<RowLayoutColumnInfo OriginX="17"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DesVarHstPad" Caption="DesVarHstPad">
																	<RowLayoutColumnInfo OriginX="17"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="VlrSldRsv" Key="VlrSldRsv" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="VlrSldRsv">
																<Footer Key="VlrSldRsv">
																	<RowLayoutColumnInfo OriginX="18"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="VlrSldRsv" Caption="VlrSldRsv">
																	<RowLayoutColumnInfo OriginX="18"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="TipDsnDscBnf" Key="TipDsnDscBnf" IsBound="True" Hidden="True" DataType="System.Int32"
																BaseColumnName="TipDsnDscBnf">
																<Footer Key="TipDsnDscBnf">
																	<RowLayoutColumnInfo OriginX="19"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TipDsnDscBnf" Caption="TipDsnDscBnf">
																	<RowLayoutColumnInfo OriginX="19"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="VlrRcb" Key="VlrRcb" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="VlrRcb">
																<Footer Key="VlrRcb">
																	<RowLayoutColumnInfo OriginX="20"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="VlrRcb" Caption="VlrRcb">
																	<RowLayoutColumnInfo OriginX="20"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="TipAlcVbaFrn" Key="TipAlcVbaFrn" IsBound="True" Hidden="True" DataType="System.Int32"
																BaseColumnName="TipAlcVbaFrn">
																<Footer Key="TipAlcVbaFrn">
																	<RowLayoutColumnInfo OriginX="21"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TipAlcVbaFrn" Caption="TipAlcVbaFrn">
																	<RowLayoutColumnInfo OriginX="21"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DesAlcVbaFrn" Key="DesAlcVbaFrn" IsBound="True" Hidden="True" BaseColumnName="DesAlcVbaFrn">
																<Footer Key="DesAlcVbaFrn">
																	<RowLayoutColumnInfo OriginX="22"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DesAlcVbaFrn" Caption="DesAlcVbaFrn">
																	<RowLayoutColumnInfo OriginX="22"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="PerAlcVbaFrn" Key="PerAlcVbaFrn" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="PerAlcVbaFrn">
																<Footer Key="PerAlcVbaFrn">
																	<RowLayoutColumnInfo OriginX="23"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="PerAlcVbaFrn" Caption="PerAlcVbaFrn">
																	<RowLayoutColumnInfo OriginX="23"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="VlrAlcVbaFrn" Key="VlrAlcVbaFrn" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="VlrAlcVbaFrn">
																<Footer Key="VlrAlcVbaFrn">
																	<RowLayoutColumnInfo OriginX="24"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="VlrAlcVbaFrn" Caption="VlrAlcVbaFrn">
																	<RowLayoutColumnInfo OriginX="24"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="VlrRcbAlcVbaFrn" Key="VlrRcbAlcVbaFrn" IsBound="True" Hidden="True"
																DataType="System.Decimal" BaseColumnName="VlrRcbAlcVbaFrn">
																<Footer Key="VlrRcbAlcVbaFrn">
																	<RowLayoutColumnInfo OriginX="25"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="VlrRcbAlcVbaFrn" Caption="VlrRcbAlcVbaFrn">
																	<RowLayoutColumnInfo OriginX="25"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="VlrSldDspAlcVbaFrn" Key="VlrSldDspAlcVbaFrn" IsBound="True" Hidden="True"
																DataType="System.Decimal" BaseColumnName="VlrSldDspAlcVbaFrn">
																<Footer Key="VlrSldDspAlcVbaFrn">
																	<RowLayoutColumnInfo OriginX="26"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="VlrSldDspAlcVbaFrn" Caption="VlrSldDspAlcVbaFrn">
																	<RowLayoutColumnInfo OriginX="26"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="PmtDdo" Key="PmtDdo" IsBound="True" Hidden="True" BaseColumnName="PmtDdo">
																<Footer Key="PmtDdo">
																	<RowLayoutColumnInfo OriginX="27"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="PmtDdo" Caption="PmtDdo">
																	<RowLayoutColumnInfo OriginX="27"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="CodAcoCmc" Key="CodAcoCmc" IsBound="True" Hidden="True" BaseColumnName="CodAcoCmc">
																<Footer Key="CodAcoCmc">
																	<RowLayoutColumnInfo OriginX="28"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CodAcoCmc" Caption="CodAcoCmc">
																	<RowLayoutColumnInfo OriginX="28"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
														</Columns>
													</igtbl:UltraGridBand>
												</Bands>
											</igtbl:ultrawebgrid></TD>
									</TR>
									<TR>
										<TD class="barra3" style="HEIGHT: 23px">Saldo Anterior:</TD>
										<TD class="barra1" style="WIDTH: 315px; HEIGHT: 23px"><igtxt:webcurrencyedit id="txtSaldoAnterior" runat="server" Font-Names="arial" Font-Size="11px" Width="120px"
												CssClass="" Height="19px" DataMode="Decimal" ReadOnly="True"></igtxt:webcurrencyedit></TD>
										<TD class="barra3" style="WIDTH: 97px; HEIGHT: 23px">Créditos:</TD>
										<TD class="barra1" style="HEIGHT: 23px"><igtxt:webcurrencyedit id="txtCreditos" runat="server" Font-Names="arial" Font-Size="11px" Width="120px"
												CssClass="" Height="19px" DataMode="Decimal" ReadOnly="True"></igtxt:webcurrencyedit></TD>
									</TR>
									<TR>
										<TD class="barra3">Valor&nbsp;a Receber:</TD>
										<TD class="barra1" style="WIDTH: 315px"><igtxt:webcurrencyedit id="txtValorAReceber" runat="server" Font-Names="arial" Font-Size="11px" Width="120px"
												CssClass="" Height="19px" DataMode="Decimal" ReadOnly="True"></igtxt:webcurrencyedit></TD>
										<TD class="barra3" style="WIDTH: 97px">
											<P align="right">Acordos a Receber:</P>
										</TD>
										<TD class="barra1"><igtxt:webcurrencyedit id="txtAcordosAReceber" runat="server" Font-Names="arial" Font-Size="11px" Width="120px"
												CssClass="" Height="19px" DataMode="Decimal" ReadOnly="True"></igtxt:webcurrencyedit></TD>
									</TR>
									<TR>
										<TD class="barra3" style="HEIGHT: 27px">Débitos:</TD>
										<TD class="barra1" style="WIDTH: 315px; HEIGHT: 27px"><igtxt:webcurrencyedit id="txtDebitos" runat="server" Font-Names="arial" Font-Size="11px" Width="120px"
												CssClass="" Height="19px" DataMode="Decimal" ReadOnly="True"></igtxt:webcurrencyedit></TD>
										<TD class="barra3" style="WIDTH: 97px; HEIGHT: 27px">Saldo Disponível:</TD>
										<TD class="barra1" style="HEIGHT: 27px"><igtxt:webcurrencyedit id="txtSaldoDisponivel" runat="server" Font-Names="arial" Font-Size="11px" Width="120px"
												CssClass="" Height="19px" DataMode="Decimal" ReadOnly="True"></igtxt:webcurrencyedit></TD>
									</TR>
									<TR>
										<TD class="barra3">Movimentação:</TD>
										<TD class="barra1" style="WIDTH: 315px"><igtxt:webcurrencyedit id="txtMovimentacao" runat="server" Font-Names="arial" Font-Size="11px" Width="120px"
												CssClass="" Height="19px" DataMode="Decimal" ReadOnly="True"></igtxt:webcurrencyedit></TD>
										<TD class="barra1" style="WIDTH: 97px"></TD>
										<TD class="barra1"></TD>
									</TR>
									<TR>
									</TR>
								</TBODY>
							</TABLE>
						</td>
					</tr>
				</tbody>
			</table>
			<asp:label id="lblErro" runat="server" Font-Size="10px" ForeColor="Red"></asp:label></form>
	</body>
</HTML>
