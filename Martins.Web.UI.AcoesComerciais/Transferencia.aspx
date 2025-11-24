<%@ Register TagPrefix="igmisc" Namespace="Infragistics.WebUI.Misc" Assembly="Infragistics.WebUI.Misc.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtxt1" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Transferencia.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.Transferencia" %>
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

function txtValor_Blur(oEdit, text, oEvent){
	btnSalvar.focus();
}

function grdOrigemN_AfterCellUpdateHandler(gridName, cellId){
	if (igtbl_getColumnById(cellId).Key == "Sel"){
		var row = igtbl_getRowById(cellId);
		if (row.getCellFromKey("Sel").getValue()){
			var SaldoDisponivel;
			SaldoDisponivel = row.getCellFromKey("SaldoDisponivel").getValue(); 
			row.getCellFromKey("ValorTransferir").setValue(parseFloat(SaldoDisponivel).toFixed(2).replace(".", ","));
			window.MM_findObj('TbValorAtualizado').style.display = 'inline';
		} else {
			row.getCellFromKey("ValorTransferir").setValue(0);
			window.MM_findObj('TbValorAtualizado').style.display = 'inline';
		}
	}
	if (igtbl_getColumnById(cellId).Key == "ValorTransferir"){
		window.MM_findObj('TbValorAtualizado').style.display = 'inline';
	}
}

function grdDestinoN_AfterCellUpdateHandler(gridName, cellId){
	window.MM_findObj('TbValorAtualizado').style.display = 'inline';
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
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnSalvar" style="TEXT-DECORATION: none" runat="server"><IMG height="16" src="../Imagens/office/salvar.gif" width="16" align="absMiddle"> Transferir</asp:linkbutton></td>
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
										<TD id="TDEspera" align="left" width="100%" runat="server">
											<DIV id="Div2" align="left" runat="server"><asp:image id="Image2" runat="server" ImageUrl="../Imagens/espera.gif"></asp:image>&nbsp;Carregando...
											</DIV>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE class="TbCabecalho" id="TbCabecalho" cellSpacing="0" cellPadding="2" width="100%"
								border="0">
								<TBODY>
									<TR>
										<TD class="barra3" width="10%" height="19">Data:</TD>
										<TD class="barra1" width="40%" height="19">
											<P align="left"><igtxt:webdatetimeedit id="txtData" runat="server" CssClass="" Width="100px" Height="19px" Font-Size="11px"
													Font-Names="Arial" ReadOnly="True"></igtxt:webdatetimeedit></P>
										</TD>
										<TD class="barra3" width="10%" height="19">Usuário:</TD>
										<TD class="barra1" width="40%" height="19"><asp:textbox id="txtUsuario" runat="server" CssClass="" Width="100px" Height="19px" Font-Size="11px"
												Font-Names="Arial" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%" height="19">Tipo:</TD>
										<TD class="barra1" width="40%" height="19"><asp:dropdownlist id="cmbTipo" runat="server" Font-Size="11px" Font-Names="Arial" AutoPostBack="True">
												<asp:ListItem Value="1" Selected="True">1 EMPENHO ORIGEM E 1 EMPENHO DESTINO</asp:ListItem>
												<asp:ListItem Value="2">1 EMPENHO ORIGEM E 'N' EMPENHOS DESTINO</asp:ListItem>
												<asp:ListItem Value="3">'N' EMPENHOS DE ORIGEM E 1 EMPENHO DESTINO</asp:ListItem>
											</asp:dropdownlist></TD>
										<TD class="barra1" width="10%" height="19"></TD>
										<TD class="barra1" width="40%" height="19"></TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE class="TbUmaOrigem" id="TbUmaOrigem" cellSpacing="0" cellPadding="2" width="100%"
								border="0" runat="server">
								<TR>
									<TD style="WIDTH: 96px" colSpan="4" height="5"></TD>
								</TR>
								<TR>
									<TD class="titlemedium1" style="WIDTH: 96px; HEIGHT: 19px" colSpan="4" height="19">Origem</TD>
								</TR>
								<TR>
									<TD class="barra3" width="10%" height="19"><asp:dropdownlist id="ddl1" runat="server" CssClass=" " Width="0px" Height="19px" Font-Size="11px"
											Font-Names="Arial" AutoPostBack="True"></asp:dropdownlist>Fornecedor:</TD>
									<TD class="barra1" width="50%" height="19"><uc1:wucfornecedor id="ucFornecedorOR" runat="server"></uc1:wucfornecedor></TD>
									<TD class="barra3" width="10%" height="19">Saldo Disponível</TD>
									<TD class="barra1" width="30%" height="19"><igtxt:webcurrencyedit id="txtSaldoDisp" runat="server" CssClass="" Width="96px" Height="19px" Font-Size="11px"
											Font-Names="Arial" ReadOnly="True" DataMode="Decimal"></igtxt:webcurrencyedit></TD>
								</TR>
								<TR>
									<TD class="barra3" width="10%" height="19"><asp:dropdownlist id="ddl2" runat="server" CssClass=" " Width="0px" Height="19px" Font-Size="11px"
											Font-Names="Arial" AutoPostBack="True"></asp:dropdownlist>Empenho:</TD>
									<TD class="barra1" width="50%" height="19"><igtxt:webnumericedit id="txtEmpenho" runat="server" CssClass="" Width="60px" Font-Size="11px" Font-Names="Arial"
											AutoPostBack="True"></igtxt:webnumericedit><asp:dropdownlist id="ddlEmpenhoOR" runat="server" CssClass=" " Width="200px" Height="19px" Font-Size="11px"
											Font-Names="Arial" AutoPostBack="True"></asp:dropdownlist></TD>
									<TD class="barra3" width="10%" height="19">Saldo Empenho</TD>
									<TD class="barra1" width="30%" height="19"><igtxt:webcurrencyedit id="txtSaldoEmp" runat="server" CssClass="" Width="96px" Height="19px" Font-Size="11px"
											Font-Names="Arial" ReadOnly="True" DataMode="Decimal"></igtxt:webcurrencyedit></TD>
								</TR>
								<TR>
									<TD class="barra3" width="10%" height="19">Alocações:</TD>
									<TD class="barra1" width="90%" colSpan="3"><igtbl:ultrawebgrid id=grdAlocacoes runat="server" Width="100%" Height="82px" UseAccessibleHeader="False" DataMember="tbSelecaoValorDisponivelFornecedor" DataSource="<%# dsSelecaoValorDisponivelFornecedor %>" ImageDirectory="/ig_common/Images/">
											<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" RowHeightDefault="20px"
												Version="4.00" SelectTypeRowDefault="Single" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
												SelectTypeCellDefault="Single" HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate"
												AllowColSizingDefault="Free" RowSelectorsDefault="No" Name="grdAlocacoes" TableLayout="Fixed"
												CellClickActionDefault="RowSelect" SelectTypeColDefault="Single">
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
												<GroupByRowStyleDefault BorderColor="Highlight" ForeColor="HighlightText" BackColor="Highlight"></GroupByRowStyleDefault>
												<RowSelectorStyleDefault ForeColor="HighlightText" BackColor="Highlight"></RowSelectorStyleDefault>
												<FrameStyle Width="100%" BorderWidth="1px" Font-Size="11px" Font-Names="Arial" BorderColor="InactiveCaption"
													BorderStyle="Solid" BackColor="Window" Height="82px"></FrameStyle>
												<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
													<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
												</FooterStyleDefault>
												<GroupByBox Hidden="True">
													<Style BorderColor="Window" BackColor="ActiveBorder">
													</Style>
												</GroupByBox>
												<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>
												<SelectedRowStyleDefault ForeColor="HighlightText" BackColor="Highlight"></SelectedRowStyleDefault>
												<RowStyleDefault BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" BackColor="Window">
													<Padding Left="3px"></Padding>
													<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
												</RowStyleDefault>
											</DisplayLayout>
											<Bands>
												<igtbl:UltraGridBand AddButtonCaption="tbSelecaoValorDisponivelFornecedor" BaseTableName="tbSelecaoValorDisponivelFornecedor"
													Key="tbSelecaoValorDisponivelFornecedor">
													<Columns>
														<igtbl:UltraGridColumn HeaderText="" Key="TipDsnDscBnf" IsBound="True" Width="40px" Hidden="True" DataType="System.Decimal"
															BaseColumnName="TipDsnDscBnf">
															<CellStyle CssClass=""></CellStyle>
															<Footer Key="TipDsnDscBnf"></Footer>
															<Header Key="TipDsnDscBnf" Caption=""></Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="TipAlcVbaFrn" Key="TipAlcVbaFrn" IsBound="True" Hidden="True" DataType="System.Decimal"
															BaseColumnName="TipAlcVbaFrn">
															<CellStyle CssClass=""></CellStyle>
															<Footer Key="TipAlcVbaFrn">
																<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="TipAlcVbaFrn" Caption="TipAlcVbaFrn">
																<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Aloca&#231;&#227;o" Key="DesAlcVbaFrn" IsBound="True" BaseColumnName="DesAlcVbaFrn">
															<CellStyle CssClass=""></CellStyle>
															<Footer Key="DesAlcVbaFrn">
																<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
															</Footer>
															<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
															<Header Key="DesAlcVbaFrn" Caption="Aloca&#231;&#227;o">
																<Style HorizontalAlign="Left">
																</Style>
																<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Vlr. Alocado" Key="VlrAlcVbaFrn" IsBound="True" Format="R$  ###,###,##0.00;(R$  ###,###,##0.00)"
															DataType="System.Decimal" BaseColumnName="VlrAlcVbaFrn">
															<CellStyle HorizontalAlign="Right" CssClass=""></CellStyle>
															<Footer Key="VlrAlcVbaFrn">
																<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
															</Footer>
															<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
															<Header Key="VlrAlcVbaFrn" Caption="Vlr. Alocado">
																<Style HorizontalAlign="Right">
																</Style>
																<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Vlr. Receber" Key="VlrRcbAlcVbaFrn" IsBound="True" Format="R$  ###,###,##0.00;(R$  ###,###,##0.00)"
															DataType="System.Decimal" BaseColumnName="VlrRcbAlcVbaFrn">
															<CellStyle HorizontalAlign="Right" CssClass=""></CellStyle>
															<Footer Key="VlrRcbAlcVbaFrn">
																<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
															</Footer>
															<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
															<Header Key="VlrRcbAlcVbaFrn" Caption="Vlr. Receber">
																<Style HorizontalAlign="Right">
																</Style>
																<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Saldo Dispon&#237;vel" Key="VlrSldDspAlcVbaFrn" IsBound="True" Format="R$  ###,###,##0.00;(R$  ###,###,##0.00)"
															DataType="System.Decimal" BaseColumnName="VlrSldDspAlcVbaFrn">
															<CellStyle HorizontalAlign="Right" CssClass=""></CellStyle>
															<Footer Key="VlrSldDspAlcVbaFrn">
																<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
															</Footer>
															<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
															<Header Key="VlrSldDspAlcVbaFrn" Caption="Saldo Dispon&#237;vel">
																<Style HorizontalAlign="Right">
																</Style>
																<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
													</Columns>
												</igtbl:UltraGridBand>
											</Bands>
										</igtbl:ultrawebgrid></TD>
								</TR>
								<TR>
									<TD class="barra3" width="10%" height="19">Total Alocações:</TD>
									<TD class="barra1" width="40%" height="19"><igtxt:webcurrencyedit id="txtTotalAloc" runat="server" CssClass="" Width="96px" Height="19px" Font-Size="11px"
											Font-Names="Arial" ReadOnly="True" DataMode="Decimal"></igtxt:webcurrencyedit></TD>
									<TD class="barra1" width="10%" height="19"></TD>
									<TD class="barra1" width="40%" height="19"></TD>
								</TR>
							</TABLE>
							<TABLE class="TbMuitasOrigens" id="TbMuitasOrigens" cellSpacing="0" cellPadding="2" width="100%"
								border="0" runat="server">
								<TR>
									<TD style="WIDTH: 96px" colSpan="4" height="5"></TD>
								</TR>
								<TR>
									<TD class="titlemedium1" style="WIDTH: 96px" colSpan="4" height="20">Origem</TD>
								</TR>
								<TR>
									<TD class="barra3" width="10%" height="19"><asp:dropdownlist id="Dropdownlist1" runat="server" CssClass=" " Width="0px" Height="19px" Font-Size="11px"
											Font-Names="Arial" AutoPostBack="True"></asp:dropdownlist>Fornecedor:</TD>
									<TD class="barra1" width="90%" colSpan="3" height="19"><uc1:wucfornecedor id="ucfornecedorOrigemN" runat="server"></uc1:wucfornecedor>
										<igtxt:webnumericedit id="ValorTransferir" runat="server" Font-Names="Arial" Font-Size="11px" DataMode="Decimal"
											MinDecimalPlaces="Two"></igtxt:webnumericedit></TD>
								</TR>
								<TR>
									<TD width="100%" colSpan="4"><igtbl:ultrawebgrid id=grdOrigemN runat="server" Width="100%" Height="180px" DataMember="tbTransfenciaEmpenhosDoFornecedor" DataSource="<%# dsSelecaoValorDisponivelFornecedor %>" ImageDirectory="/ig_common/Images/">
											<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" TabDirection="TopToBottom"
												RowHeightDefault="21px" Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy"
												AllowColumnMovingDefault="OnServer" HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate"
												AllowColSizingDefault="Free" RowSelectorsDefault="No" Name="grdOrigemN" TableLayout="Fixed"
												CellClickActionDefault="Edit">
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
													BorderStyle="Solid" BackColor="Window" Height="180px"></FrameStyle>
												<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
													<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
												</FooterStyleDefault>
												<ClientSideEvents AfterCellUpdateHandler="grdOrigemN_AfterCellUpdateHandler"></ClientSideEvents>
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
												<igtbl:UltraGridBand AddButtonCaption="tbTransfenciaEmpenhosDoFornecedor" BaseTableName="tbTransfenciaEmpenhosDoFornecedor"
													Key="tbTransfenciaEmpenhosDoFornecedor" DataKeyField="CodigoFornecedor,CodigoEmpenho,CodigoAlocacao">
													<Columns>
														<igtbl:UltraGridColumn HeaderText="SEL" Key="Sel" Width="25px" Type="CheckBox" DataType="System.Boolean"
															BaseColumnName="Sel" AllowUpdate="Yes">
															<Footer Key="Sel"></Footer>
															<Header Key="Sel" Caption="SEL"></Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="CODIGO" Key="CodigoEmpenho" IsBound="True" Width="50px" DataType="System.Decimal"
															BaseColumnName="CodigoEmpenho" AllowUpdate="No">
															<SelectedCellStyle HorizontalAlign="Right"></SelectedCellStyle>
															<CellStyle HorizontalAlign="Right"></CellStyle>
															<Footer Key="CodigoEmpenho">
																<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="CodigoEmpenho" Caption="CODIGO">
																<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="DESCRI&#199;&#195;O" Key="NomeEmpenho" IsBound="True" Width="150px"
															BaseColumnName="NomeEmpenho" AllowUpdate="No">
															<Footer Key="NomeEmpenho">
																<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="NomeEmpenho" Caption="DESCRI&#199;&#195;O">
																<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="ALOCA&#199;&#195;O" Key="NomeAlocacao" IsBound="True" Width="100px"
															BaseColumnName="NomeAlocacao" AllowUpdate="No">
															<Footer Key="NomeAlocacao">
																<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="NomeAlocacao" Caption="ALOCA&#199;&#195;O">
																<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="ALOCADO" Key="ValorAlocado" IsBound="True" Width="80px" Format="###,###,##0.00"
															DataType="System.Decimal" BaseColumnName="ValorAlocado" AllowUpdate="No">
															<SelectedCellStyle HorizontalAlign="Right"></SelectedCellStyle>
															<CellStyle HorizontalAlign="Right"></CellStyle>
															<Footer Key="ValorAlocado">
																<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
															</Footer>
															<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
															<Header Key="ValorAlocado" Caption="ALOCADO">
																<Style HorizontalAlign="Right">
																</Style>
																<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="RECEBER" Key="ValorReceber" IsBound="True" Width="80px" Format="###,###,##0.00"
															DataType="System.Decimal" BaseColumnName="ValorReceber" AllowUpdate="No">
															<SelectedCellStyle HorizontalAlign="Right"></SelectedCellStyle>
															<CellStyle HorizontalAlign="Right"></CellStyle>
															<Footer Key="ValorReceber">
																<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
															</Footer>
															<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
															<Header Key="ValorReceber" Caption="RECEBER">
																<Style HorizontalAlign="Right">
																</Style>
																<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="DISPON&#205;VEL" Key="SaldoDisponivel" IsBound="True" Width="80px" Format="###,###,##0.00"
															DataType="System.Decimal" BaseColumnName="SaldoDisponivel" AllowUpdate="No">
															<SelectedCellStyle HorizontalAlign="Right"></SelectedCellStyle>
															<CellStyle HorizontalAlign="Right"></CellStyle>
															<Footer Key="SaldoDisponivel">
																<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
															</Footer>
															<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
															<Header Key="SaldoDisponivel" Caption="DISPON&#205;VEL">
																<Style HorizontalAlign="Right">
																</Style>
																<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="TRANSFERIR" Key="ValorTransferir" AllowNull="False" IsBound="True" EditorControlID="ValorTransferir"
															AllowGroupBy="No" Type="Custom" Format="R$  ###,###,##0.00" DataType="System.Decimal" BaseColumnName="ValorTransferir"
															AllowUpdate="Yes" CellMultiline="No">
															<CellStyle HorizontalAlign="Right"></CellStyle>
															<Footer Key="ValorTransferir">
																<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
															</Footer>
															<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
															<Header Key="ValorTransferir" Caption="TRANSFERIR">
																<Style HorizontalAlign="Right">
																</Style>
																<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="CodigoAlocacao" Key="CodigoAlocacao" IsBound="True" Hidden="True" DataType="System.Decimal"
															BaseColumnName="CodigoAlocacao">
															<Footer Key="CodigoAlocacao">
																<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="CodigoAlocacao" Caption="CodigoAlocacao">
																<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
													</Columns>
												</igtbl:UltraGridBand>
											</Bands>
										</igtbl:ultrawebgrid></TD>
								</TR>
							</TABLE>
							<TABLE class="TbUmDestino" id="TbUmDestino" cellSpacing="0" cellPadding="2" width="100%"
								border="0" runat="server">
								<TR>
									<TD style="WIDTH: 96px" colSpan="4" height="5"></TD>
								</TR>
								<TR>
									<TD class="titlemedium1" style="WIDTH: 96px" colSpan="4" height="20">Destino</TD>
								</TR>
								<TR>
									<TD class="barra3" width="10%" height="19">Fornecedor:</TD>
									<TD class="barra1" width="90%" height="19">
										<uc1:wucfornecedor id="ucFornecedorDS" runat="server"></uc1:wucfornecedor></TD>
								</TR>
								<TR>
									<TD class="barra3" width="10%" height="19">Empenho:</TD>
									<TD class="barra1" width="90%" height="19">
										<igtxt:webnumericedit id="txtEmpenhoDS" runat="server" Font-Names="Arial" Font-Size="11px" Width="60px"
											CssClass="" AutoPostBack="True"></igtxt:webnumericedit>
										<asp:dropdownlist id="ddlEmpenhoDS" runat="server" Font-Names="Arial" Font-Size="11px" Height="19px"
											Width="200px" CssClass=" " AutoPostBack="True"></asp:dropdownlist>&nbsp;
										<asp:label id="lblAlcVbaFrn" runat="server" Font-Names="Arial" Font-Size="11px" ForeColor="Black"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 96px" colSpan="4" height="5"></TD>
								</TR>
							</TABLE>
							<TABLE class="TbMuitosDestinos" id="TbMuitosDestinos" cellSpacing="0" cellPadding="2" width="100%"
								border="0" runat="server">
								<TR>
									<TD style="WIDTH: 96px" colSpan="4" height="5"></TD>
								</TR>
								<TR>
									<TD class="titlemedium1" style="WIDTH: 96px" colSpan="4" height="20">
										Destino</TD>
								</TR>
								<TR>
									<TD width="100%" colSpan="4"><igtbl:ultrawebgrid id="grdDestinoN" runat="server" Width="424px" Height="107px" DataMember="T0109059" DataSource="<%# dsEmpenho %>" ImageDirectory="/ig_common/Images/">
											<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" TabDirection="TopToBottom"
												RowHeightDefault="21px" Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy"
												AllowColumnMovingDefault="OnServer" HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate"
												AllowColSizingDefault="Free" RowSelectorsDefault="No" Name="grdDestinoN" TableLayout="Fixed"
												CellClickActionDefault="Edit">
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
												<FrameStyle Width="424px" BorderWidth="1px" Font-Size="11px" Font-Names="Arial" BorderColor="InactiveCaption"
													BorderStyle="Solid" BackColor="Window" Height="107px"></FrameStyle>
												<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
													<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
												</FooterStyleDefault>
												<ClientSideEvents AfterCellUpdateHandler="grdDestinoN_AfterCellUpdateHandler"></ClientSideEvents>
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
												<igtbl:UltraGridBand AddButtonCaption="T0109059" BaseTableName="T0109059" Key="T0109059" DataKeyField="TIPDSNDSCBNF">
													<Columns>
														<igtbl:UltraGridColumn HeaderText="CODIGO" Key="TIPDSNDSCBNF" IsBound="True" Width="50px" DataType="System.Decimal"
															BaseColumnName="TIPDSNDSCBNF">
															<Footer Key="TIPDSNDSCBNF"></Footer>
															<Header Key="TIPDSNDSCBNF" Caption="CODIGO"></Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="DESCRI&#199;&#195;O EMPENHO" Key="DESDSNDSCBNF" IsBound="True" Width="250px"
															BaseColumnName="DESDSNDSCBNF">
															<Footer Key="DESDSNDSCBNF">
																<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="DESDSNDSCBNF" Caption="DESCRI&#199;&#195;O EMPENHO">
																<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="TRANSFERIR" Key="ValorTransferir" AllowNull="False" IsBound="True" EditorControlID="ValorTransferirDestino"
															AllowGroupBy="No" Type="Custom" Format="R$  ###,###,##0.00" DataType="System.Decimal" BaseColumnName="ValorTransferir"
															AllowUpdate="Yes" CellMultiline="No">
															<CellStyle HorizontalAlign="Right"></CellStyle>
															<Footer Key="ValorTransferir">
																<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
															</Footer>
															<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
															<Header Key="ValorTransferir" Caption="TRANSFERIR">
																<Style HorizontalAlign="Right">
																</Style>
																<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
													</Columns>
												</igtbl:UltraGridBand>
											</Bands>
										</igtbl:ultrawebgrid>
										<igtxt:webnumericedit id="ValorTransferirDestino" runat="server" Font-Names="Arial" Font-Size="11px" DataMode="Decimal"
											MinDecimalPlaces="Two"></igtxt:webnumericedit></TD>
								</TR>
							</TABLE>
							<TABLE class="TbFinal" id="TbFinal" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
									<TR>
										<TD width="100%" colSpan="6" height="5"></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%" height="19">Histórico:</TD>
										<TD class="barra1" width="90%" colSpan="5" height="19">
											<asp:textbox id="txtHistorico" runat="server" Font-Names="Arial" Font-Size="11px" Height="19px"
												Width="400px" CssClass="" MaxLength="50"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%" height="19">Valor:</TD>
										<TD class="barra1" colSpan="5">
											<igtxt:webcurrencyedit id="txtValor" runat="server" Font-Names="Arial" Font-Size="11px" Height="19px" Width="110px"
												CssClass="" DataMode="Decimal">
												<ClientSideEvents Blur="txtValor_Blur"></ClientSideEvents>
											</igtxt:webcurrencyedit></TD>
						</td>
						</TD></tr>
					<TR>
						<TD class="barra1" width="10%" height="19"></TD>
						<TD class="barra1" colSpan="5">
							<TABLE id="TbValorAtualizado" cellSpacing="1" cellPadding="1" border="0">
								<TR>
									<TD>
										<asp:button id="cmdCalcularValores" runat="server" Height="22px" Text="Atualizar"></asp:button>&nbsp;
										<asp:label id="lblMensagemDesatualizado" runat="server" ForeColor="Red">Valor desatualizado</asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</tbody>
			</table>
			</TD></TR></TBODY></TABLE></form>
	</body>
</HTML>
