<%@ Register TagPrefix="igcalc" Namespace="Infragistics.WebUI.UltraWebCalcManager" Assembly="Infragistics.WebUI.UltraWebCalcManager.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Recebimento.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.Recebimento" %>
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

function valorAlterado(gridName, cellId){
	var objCell = igtbl_getCellById(cellId);
	var cellValue = objCell.getValue();	
	valor = cellValue.replace(".", ",");
	objCell.setValue(valor)
	/*
	var objCellDes = igtbl_getCellById('uwgAcordosrc_0_12');
	
	valor = cellValue.replace(",", ".");

	if (valor != parseFloat(valor)) {
		alert('valor inválido ' + valor + ' ' + parseFloat(valor))
		valor = objCellDes.getValue();
	}
	else {
		//valor = (Math.round(parseFloat(valor) * 100) / 100).toString();	
		/*
		alert(valor)
		alert(parseFloat(valor))
		alert(parseFloat(valor) / 100)
		alert(Math.round(parseFloat(valor) / 100))
		valor = Math.round(parseFloat(valor) / 100) //valor = (Math.round(parseFloat(valor) * 100) / 100).toString();
		*/
	//}	
	//objCell.setValue(valor)
	//objCellDes.setValue(parseFloat(valor * 100));	
	//objCellDes.setValue(parseFloat(valor).toFixed(2).replace(".", ","))
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
			<table style="WIDTH: 100%; HEIGHT: 67px" height="67" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<tbody>
					<tr>
						<td class="submenu2" vAlign="top" style="HEIGHT: 55px">
							<table cellSpacing="0" cellPadding="0" border="0" id="tbOpcoes" runat="server">
								<tr>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnSalvar" style="TEXT-DECORATION: none" runat="server" ToolTip="Confirmar recebimentos"><IMG height="16" src="../Imagens/office/salvar.gif" width="16" align="absMiddle"> Confirmar</asp:linkbutton></td>
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
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnApagar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
														Visible="False"><IMG height="16" src="../Imagens/office/apagar.gif" width="16" align="absMiddle">
													Apagar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="BtnImprimirRecibo" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/imprimir.gif" width="16" align="absMiddle">  Imprimir Recibo</asp:linkbutton></td>
												<TD><asp:linkbutton id="btnVisualizar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/S_F_NXTO.gif" width="16" align="absMiddle">  Exportar Recibo</asp:linkbutton></TD>
												<TD></TD>
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
									<TR>
										<TD class="barra3" style="HEIGHT: 14px" width="10%">Fornecedor:</TD>
										<TD class="barra1" style="HEIGHT: 14px" colSpan="3" width="90%"><uc1:wucfornecedor id="ucFornecedor" runat="server"></uc1:wucfornecedor></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%">Acordos em Aberto</TD>
										<TD class="barra1" colSpan="3" width="90%"><igtbl:ultrawebgrid id=uwgAcordos runat="server" Height="125px" Width="100%" DataMember="tbAcordosPendente" DataSource="<%# dsAcordo %>" ImageDirectory="/ig_common/Images/">
												<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" RowHeightDefault="20px"
													Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
													SelectTypeCellDefault="Single" HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate"
													AllowColSizingDefault="Free" RowSelectorsDefault="No" Name="uwgAcordos" TableLayout="Fixed"
													CellClickActionDefault="RowSelect">
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
													<RowSelectorStyleDefault ForeColor="HighlightText" BackColor="Highlight"></RowSelectorStyleDefault>
													<FrameStyle Width="100%" BorderWidth="1px" Font-Size="8.25pt" Font-Names="Arial" BorderColor="InactiveCaption"
														BorderStyle="Solid" BackColor="Window" Height="125px"></FrameStyle>
													<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
														<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
													</FooterStyleDefault>
													<ClientSideEvents AfterCellUpdateHandler="valorAlterado"></ClientSideEvents>
													<GroupByBox Hidden="True">
														<Style BorderColor="Window" BackColor="ActiveBorder"></Style>
													</GroupByBox>
													<EditCellStyleDefault BorderWidth="0px" BorderStyle="None" HorizontalAlign="Right"></EditCellStyleDefault>
													<SelectedRowStyleDefault ForeColor="HighlightText" BackColor="Highlight"></SelectedRowStyleDefault>
													<RowStyleDefault BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" BackColor="Window">
														<Padding Left="3px"></Padding>
														<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
													</RowStyleDefault>
												</DisplayLayout>
												<Bands>
													<igtbl:UltraGridBand AddButtonCaption="tbAcordosPendente" BaseTableName="tbAcordosPendente" Key="tbAcordosPendente">
														<Columns>
															<igtbl:UltraGridColumn HeaderText="SELE&#199;&#195;O" Key="" Width="30px" Type="CheckBox" BaseColumnName=""
																AllowUpdate="Yes">
																<Footer Key=""></Footer>
																<Header Key="" Caption="SELE&#199;&#195;O"></Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="TIPO" Key="TIPO" IsBound="True" Width="30px" BaseColumnName="TIPO">
																<Footer Key="TIPO">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TIPO" Caption="TIPO">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DOCUM." Key="CodPms" IsBound="True" Width="60px" DataType="System.Decimal"
																BaseColumnName="CodPms">
																<Footer Key="CodPms">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CodPms" Caption="DOCUM.">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="PEDIDO" Key="NumPedCmp" IsBound="True" Width="60px" DataType="System.Decimal"
																BaseColumnName="NumPedCmp">
																<Footer Key="NumPedCmp">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NumPedCmp" Caption="PEDIDO">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="FILIAL" Key="CodFilEmp" IsBound="True" Width="35px" DataType="System.Decimal"
																BaseColumnName="CodFilEmp">
																<Footer Key="CodFilEmp">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CodFilEmp" Caption="FILIAL">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="FORMA DE PGTO" Key="Forma" IsBound="True" Width="90px" BaseColumnName="Forma">
																<Footer Key="Forma">
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="Forma" Caption="FORMA DE PGTO">
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DESTINO DO DESCONTO" Key="Destino" IsBound="True" Width="130px" BaseColumnName="Destino">
																<Footer Key="Destino">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="Destino" Caption="DESTINO DO DESCONTO">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DATA NEG." Key="DatNgcPms" IsBound="True" Width="70px" Format="dd/MM/yyyy"
																DataType="System.DateTime" BaseColumnName="DatNgcPms">
																<CellStyle HorizontalAlign="Center"></CellStyle>
																<Footer Key="DatNgcPms">
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<Header Key="DatNgcPms" Caption="DATA NEG.">
																	<Style HorizontalAlign="Center"></Style>
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DATA PREV." Key="DatPrvRcbPms" IsBound="True" Width="70px" Format="dd/MM/yyyy"
																DataType="System.DateTime" BaseColumnName="DatPrvRcbPms" AllowUpdate="No">
																<CellStyle HorizontalAlign="Center"></CellStyle>
																<Footer Key="DatPrvRcbPms">
																	<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<Header Key="DatPrvRcbPms" Caption="DATA PREV.">
																	<Style HorizontalAlign="Center"></Style>
																	<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="VALOR NEG." Key="VlrNgcPms" IsBound="True" Width="80px" Format="###,###,##0.00"
																DataType="System.Decimal" BaseColumnName="VlrNgcPms" AllowUpdate="No">
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="VlrNgcPms">
																	<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
																<Header Key="VlrNgcPms" Caption="VALOR NEG.">
																	<Style HorizontalAlign="Right"></Style>
																	<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="VALOR PAGO" Key="VlrPgoPms" IsBound="True" Width="80px" Format="###,###,##0.00"
																DataType="System.Decimal" BaseColumnName="VlrPgoPms" AllowUpdate="No">
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="VlrPgoPms">
																	<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
																<Header Key="VlrPgoPms" Caption="VALOR PAGO">
																	<Style HorizontalAlign="Right"></Style>
																	<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="VALOR EFET." Key="VlrEftPms" IsBound="True" Width="80px" Format="###,###,##0.00"
																DataType="System.Decimal" BaseColumnName="VlrEftPms" AllowUpdate="No">
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="VlrEftPms">
																	<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
																<Header Key="VlrEftPms" Caption="VALOR EFET.">
																	<Style HorizontalAlign="Right"></Style>
																	<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="VALOR REST." Key="ValorRestantePagar" EditorControlID="" Width="80px"
																Hidden="True" Type="Custom" Format="" DataType="System.Decimal" BaseColumnName="ValorRestantePagar"
																AllowUpdate="No" FooterText="">
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="ValorRestantePagar" Caption="">
																	<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="ValorRestantePagar" Caption="VALOR REST.">
																	<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="VALOR REST." Key="" Width="80px" BaseColumnName="ValorRestantePagarTemp"
																AllowUpdate="Yes">
																<CellStyle VerticalAlign="Top" HorizontalAlign="Right"></CellStyle>
																<Footer Key="">
																	<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="" Caption="VALOR REST.">
																	<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
														</Columns>
														<RowEditTemplate>
															<P align="right"></P>
															<BR>
															<P align="center"><INPUT id="igtbl_reOkBtn" style="WIDTH: 50px" onclick="igtbl_gRowEditButtonClick(event);"
																	type="button" value="OK">&nbsp; <INPUT id="igtbl_reCancelBtn" style="WIDTH: 50px" onclick="igtbl_gRowEditButtonClick(event);"
																	type="button" value="Cancel"></P>
														</RowEditTemplate>
														<RowTemplateStyle BorderColor="Window" BorderStyle="Ridge" BackColor="Window">
															<BorderDetails WidthLeft="3px" WidthTop="3px" WidthRight="3px" WidthBottom="3px"></BorderDetails>
														</RowTemplateStyle>
													</igtbl:UltraGridBand>
												</Bands>
											</igtbl:ultrawebgrid></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%">Recebimentos em Aberto</TD>
										<TD class="barra1" colSpan="3" width="90%"><igtbl:ultrawebgrid id="uwgRecebimentos" runat="server" Height="125px" Width="100%" UseAccessibleHeader="False"
												ImageDirectory="/ig_common/Images/">
												<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" RowHeightDefault="20px"
													Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
													SelectTypeCellDefault="Single" HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate"
													AllowColSizingDefault="Free" RowSelectorsDefault="No" Name="uwgRecebimentos" TableLayout="Fixed"
													CellClickActionDefault="RowSelect">
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
													<RowSelectorStyleDefault ForeColor="HighlightText" BackColor="Highlight"></RowSelectorStyleDefault>
													<FrameStyle Width="100%" BorderWidth="1px" Font-Size="8.25pt" Font-Names="Arial" BorderColor="InactiveCaption"
														BorderStyle="Solid" BackColor="Window" Height="125px"></FrameStyle>
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
													<igtbl:UltraGridBand AddButtonCaption="tbAcordosPendente" Key="tbAcordosPendente">
														<Columns>
															<igtbl:UltraGridColumn HeaderText="SELE&#199;&#195;O" Key="" Width="30px" Type="CheckBox" BaseColumnName=""
																AllowUpdate="Yes">
																<Footer Key=""></Footer>
																<Header Key="" Caption="SELE&#199;&#195;O"></Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="TIPO" Key="" IsBound="True" Width="40px" BaseColumnName="TIPO">
																<Footer Key="">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="" Caption="TIPO">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DOCUMENTO" Key="" IsBound="True" Width="80px" BaseColumnName="DOCUMENTO">
																<Footer Key="">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="" Caption="DOCUMENTO">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="BANCO" Key="" IsBound="True" Width="60px" DataType="System.Int32" BaseColumnName="BANCO">
																<Footer Key="">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="" Caption="BANCO">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="AGENCIA" Key="" IsBound="True" Width="60px" DataType="System.Int32"
																BaseColumnName="AGENCIA">
																<Footer Key="">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="" Caption="AGENCIA">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DATA DE RECEBIMENTO" Key="" IsBound="True" Width="130px" Format="dd/MM/yyyy"
																DataType="System.Date" BaseColumnName="DATARECEBIMENTO">
																<CellStyle HorizontalAlign="Center"></CellStyle>
																<Footer Key="">
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="" Caption="DATA DE RECEBIMENTO">
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="VALOR DO CHEQUE - OP" Key="" IsBound="True" Width="130px" Format="###,###,##0.00"
																DataType="System.Decimal" BaseColumnName="VLRCHOP">
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="" Caption="VALOR DO CHEQUE - OP">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
														</Columns>
														<RowEditTemplate>
															<P align="right"></P>
															<BR>
															<P align="center"><INPUT id="igtbl_reOkBtn" style="WIDTH: 50px" onclick="igtbl_gRowEditButtonClick(event);"
																	type="button" value="OK">&nbsp; <INPUT id="igtbl_reCancelBtn" style="WIDTH: 50px" onclick="igtbl_gRowEditButtonClick(event);"
																	type="button" value="Cancel"></P>
														</RowEditTemplate>
														<RowTemplateStyle BorderColor="Window" BorderStyle="Ridge" BackColor="Window">
															<BorderDetails WidthLeft="3px" WidthTop="3px" WidthRight="3px" WidthBottom="3px"></BorderDetails>
														</RowTemplateStyle>
													</igtbl:UltraGridBand>
												</Bands>
											</igtbl:ultrawebgrid></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%">Valor Negociado:</TD>
										<TD class="barra1" colSpan="3" width="90%"><igtxt:webcurrencyedit id="txtVlrPmsSel1" runat="server" Height="20px" Width="100px" DataMode="Decimal"
												CellSpacing="1" UseBrowserDefaults="False" BorderWidth="1px" BorderColor="#7F9DB9" BorderStyle="Solid" ReadOnly="True" ValueText="0" CssClass=""
												Font-Size="11px" Font-Names="Arial">
												<ButtonsAppearance CustomButtonDisabledImageUrl="ig_edit_01b.gif" CustomButtonDefaultTriangleImages="Arrow"
													CustomButtonImageUrl="ig_edit_0b.gif">
													<ButtonPressedStyle BackColor="#83A6F4"></ButtonPressedStyle>
													<ButtonDisabledStyle BorderColor="#E4E4E4" BackColor="#F1F1ED"></ButtonDisabledStyle>
													<ButtonStyle Width="13px" BorderWidth="1px" BorderColor="#ABC1F4" BorderStyle="Solid" BackColor="#C5D5FC"></ButtonStyle>
													<ButtonHoverStyle BackColor="#DCEDFD"></ButtonHoverStyle>
												</ButtonsAppearance>
												<SpinButtons DefaultTriangleImages="ArrowSmall" Width="15px" UpperButtonDisabledImageUrl="ig_edit_11b.gif"
													LowerButtonDisabledImageUrl="ig_edit_21b.gif" LowerButtonImageUrl="ig_edit_2b.gif" UpperButtonImageUrl="ig_edit_1b.gif"></SpinButtons>
											</igtxt:webcurrencyedit>&nbsp;
											<asp:checkbox id="chkBaixarNegociado" runat="server" Text="Baixar pelo negociado" AutoPostBack="True"
												ForeColor="Black"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD class="barra1" width="10%"></TD>
										<TD class="barra1" colSpan="3" width="90%"></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%"></TD>
										<TD class="barra3" colSpan="3" width="90%">
											<P align="center">Resultado</P>
										</TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%">Valor Efetivo (1):</TD>
										<TD class="barra1" colSpan="3" width="90%"><igtxt:webcurrencyedit id="txtVlrPmsSel" runat="server" Height="20px" Width="100px" DataMode="Decimal"
												CellSpacing="1" UseBrowserDefaults="False" BorderWidth="1px" BorderColor="#7F9DB9" BorderStyle="Solid" ReadOnly="True" ValueText="0" CssClass=""
												Font-Size="11px" Font-Names="Arial">
												<ButtonsAppearance CustomButtonDisabledImageUrl="ig_edit_01b.gif" CustomButtonDefaultTriangleImages="Arrow"
													CustomButtonImageUrl="ig_edit_0b.gif">
													<ButtonPressedStyle BackColor="#83A6F4"></ButtonPressedStyle>
													<ButtonDisabledStyle BorderColor="#E4E4E4" BackColor="#F1F1ED"></ButtonDisabledStyle>
													<ButtonStyle Width="13px" BorderWidth="1px" BorderColor="#ABC1F4" BorderStyle="Solid" BackColor="#C5D5FC"></ButtonStyle>
													<ButtonHoverStyle BackColor="#DCEDFD"></ButtonHoverStyle>
												</ButtonsAppearance>
												<SpinButtons DefaultTriangleImages="ArrowSmall" Width="15px" UpperButtonDisabledImageUrl="ig_edit_11b.gif"
													LowerButtonDisabledImageUrl="ig_edit_21b.gif" LowerButtonImageUrl="ig_edit_2b.gif" UpperButtonImageUrl="ig_edit_1b.gif"></SpinButtons>
											</igtxt:webcurrencyedit></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%">Valor Pagamentos (2):</TD>
										<TD class="barra1" colSpan="3" width="90%"><igtxt:webcurrencyedit id="txtVlrPgtSel" runat="server" Height="20px" Width="100px" DataMode="Decimal"
												CellSpacing="1" UseBrowserDefaults="False" BorderWidth="1px" BorderColor="#7F9DB9" BorderStyle="Solid" ReadOnly="True" ValueText="0" CssClass=""
												NegativeForeColor="Red" Font-Size="11px" Font-Names="Arial">
												<ButtonsAppearance CustomButtonDisabledImageUrl="ig_edit_01b.gif" CustomButtonDefaultTriangleImages="Arrow"
													CustomButtonImageUrl="ig_edit_0b.gif">
													<ButtonPressedStyle BackColor="#83A6F4"></ButtonPressedStyle>
													<ButtonDisabledStyle BorderColor="#E4E4E4" BackColor="#F1F1ED"></ButtonDisabledStyle>
													<ButtonStyle Width="13px" BorderWidth="1px" BorderColor="#ABC1F4" BorderStyle="Solid" BackColor="#C5D5FC"></ButtonStyle>
													<ButtonHoverStyle BackColor="#DCEDFD"></ButtonHoverStyle>
												</ButtonsAppearance>
												<SpinButtons DefaultTriangleImages="ArrowSmall" Width="15px" UpperButtonDisabledImageUrl="ig_edit_11b.gif"
													LowerButtonDisabledImageUrl="ig_edit_21b.gif" LowerButtonImageUrl="ig_edit_2b.gif" UpperButtonImageUrl="ig_edit_1b.gif"></SpinButtons>
											</igtxt:webcurrencyedit></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%">Valor Restante
											<BR>
											(= 1 - 2):</TD>
										<TD class="barra1" colSpan="3" width="90%"><igtxt:webcurrencyedit id="txtVlrRst" runat="server" Height="20px" Width="100px" DataMode="Decimal" CellSpacing="1"
												UseBrowserDefaults="False" BorderWidth="1px" BorderColor="#7F9DB9" BorderStyle="Solid" ReadOnly="True" ValueText="0" CssClass="" NegativeForeColor="Red"
												Font-Size="11px" Font-Names="Arial">
												<ButtonsAppearance CustomButtonDisabledImageUrl="ig_edit_01b.gif" CustomButtonDefaultTriangleImages="Arrow"
													CustomButtonImageUrl="ig_edit_0b.gif">
													<ButtonPressedStyle BackColor="#83A6F4"></ButtonPressedStyle>
													<ButtonDisabledStyle BorderColor="#E4E4E4" BackColor="#F1F1ED"></ButtonDisabledStyle>
													<ButtonStyle Width="13px" BorderWidth="1px" BorderColor="#ABC1F4" BorderStyle="Solid" BackColor="#C5D5FC"></ButtonStyle>
													<ButtonHoverStyle BackColor="#DCEDFD"></ButtonHoverStyle>
												</ButtonsAppearance>
												<SpinButtons DefaultTriangleImages="ArrowSmall" Width="15px" UpperButtonDisabledImageUrl="ig_edit_11b.gif"
													LowerButtonDisabledImageUrl="ig_edit_21b.gif" LowerButtonImageUrl="ig_edit_2b.gif" UpperButtonImageUrl="ig_edit_1b.gif"></SpinButtons>
											</igtxt:webcurrencyedit>&nbsp;
											<asp:button id="cmdCalcularValores" runat="server" Text="Calcular Valores" Height="22px"></asp:button></TD>
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
