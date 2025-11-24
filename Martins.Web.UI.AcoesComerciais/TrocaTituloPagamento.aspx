<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="AppComponents/wucFornecedor.ascx" %>
<%@ Register TagPrefix="igmisc" Namespace="Infragistics.WebUI.Misc" Assembly="Infragistics.WebUI.Misc.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TrocaTituloPagamento.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.TrocaTituloPagamento" %>
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
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnCancelar" style="TEXT-DECORATION: none" runat="server" href="Principal.aspx"
														CausesValidation="False"><IMG height="16" src="../Imagens/office/Sair.gif" width="16" align="absMiddle"> Sair</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td></td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td class="darkbox" vAlign="top" align="center">
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
										<TD class="barra3" width="10%">Fornecedor:</TD>
										<TD class="barra1" width="50%"><uc1:wucfornecedor id="ucFornecedor" runat="server"></uc1:wucfornecedor></TD>
										<TD class="barra3" width="10%">Tipo</TD>
										<TD class="barra1" width="30%"><asp:radiobutton id="rbIntegral" runat="server" AutoPostBack="True" Checked="True" GroupName="rbTipo"
												Text="Integral" ForeColor="Black"></asp:radiobutton><asp:radiobutton id="rbParcial" runat="server" AutoPostBack="True" GroupName="rbTipo" Text="Parcial"
												ForeColor="Black"></asp:radiobutton></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%">Acordo:</TD>
										<TD class="barra1" width="50%"><asp:dropdownlist id="ddlAcordo" runat="server" AutoPostBack="True" Width="243px" Height="20px" Font-Size="11px"
												Font-Names="Arial"></asp:dropdownlist></TD>
										<TD class="barra3" width="10%">Situação:</TD>
										<TD class="barra1" width="30%"><asp:textbox id="txtDesSitPms" runat="server" Width="243px" CssClass="" Font-Size="11px"
												Font-Names="Arial"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%">Dat. Negociação:</TD>
										<TD class="barra1" width="50%"><igtxt:webdatetimeedit id="txtDatNgc" runat="server" Width="100px" Height="19px" CssClass="" ReadOnly="True"
												EditModeFormat="MM/dd/yyyy" DisplayModeFormat="dd/MM/yyyy" Font-Size="11px" Font-Names="Arial"></igtxt:webdatetimeedit></TD>
										<TD class="barra3" width="10%">Dat. Prev. Recebimento:</TD>
										<TD class="barra1" width="30%"><asp:dropdownlist id="ddlDatPrvRcbPms" runat="server" Width="180px" Height="20px" CssClass=""
												Font-Size="11px" Font-Names="Arial"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%" style="HEIGHT: 1px">Destino:</TD>
										<TD class="barra1" width="50%" style="HEIGHT: 1px"><asp:dropdownlist id="ddlTipDsnDscBnf" runat="server" Width="243px" Height="20px" CssClass=""
												Font-Size="11px" Font-Names="Arial"></asp:dropdownlist></TD>
										<TD class="barra3" width="10%" style="HEIGHT: 1px">Forma:</TD>
										<TD class="barra1" width="30%" style="HEIGHT: 1px"><asp:dropdownlist id="ddlTipFrmDscBnf" runat="server" Width="243px" Height="20px" CssClass=""
												Font-Size="11px" Font-Names="Arial"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%" style="HEIGHT: 35px">Vlr. Negociado:</TD>
										<TD class="barra1" width="50%"><igtxt:webcurrencyedit id="txtVlrNgcEftPms" runat="server" Width="120px" Height="19px" CssClass=""
												ReadOnly="True" DataMode="Decimal" Font-Size="11px" Font-Names="Arial"></igtxt:webcurrencyedit></TD>
										<TD class="barra3" width="10%" style="HEIGHT: 35px">Vlr. Pago:</TD>
										<TD class="barra1" width="30%"><igtxt:webcurrencyedit id="txtVlrPgoPms" runat="server" Width="120px" Height="19px" CssClass=""
												ReadOnly="True" DataMode="Decimal" Font-Size="11px" Font-Names="Arial"></igtxt:webcurrencyedit></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%">Vlr. Associado:</TD>
										<TD class="barra1" width="50%"><igtxt:webcurrencyedit id="txtVlrRelPms" runat="server" Width="120px" Height="19px" CssClass=""
												ReadOnly="True" DataMode="Decimal" Font-Size="11px" Font-Names="Arial"></igtxt:webcurrencyedit></TD>
										<TD class="barra3" width="10%">Vlr. Saldo:</TD>
										<TD class="barra1" width="30%"><igtxt:webcurrencyedit id="txtVlrPms" runat="server" Width="120px" Height="19px" CssClass="" ReadOnly="True"
												DataMode="Decimal" Font-Size="11px" Font-Names="Arial"></igtxt:webcurrencyedit></TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TR>
									<TD class="barra3" width="10%"></TD>
									<TD class="barra3" width="50%">
										<P align="center">Associadas
										</P>
									</TD>
									<TD class="barra3" width="40%">
										<P align="center">Disponíveis
										</P>
									</TD>
								</TR>
								<TR>
									<TD class="barra3" width="10%">Notas Fiscais:</TD>
									<TD class="barra1" width="50%">
										<igtbl:ultrawebgrid id=grdNotasAssociadas runat="server" Width="100%" Height="200px" ImageDirectory="/ig_common/Images/" DataSource="<%# dsTrocaManualTituloPagamentoAcordoComercial %>" DataMember="tbNotasRelacionadasPromessaFornecedor">
											<DisplayLayout AllowSortingDefault="OnClient" RowHeightDefault="20px" Version="4.00" SelectTypeRowDefault="Extended"
												ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer" HeaderClickActionDefault="SortMulti"
												BorderCollapseDefault="Separate" AllowColSizingDefault="Free" RowSelectorsDefault="No" Name="grdNotasAssociadas"
												TableLayout="Fixed">
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
													BorderColor="InactiveCaption" BorderStyle="Solid" BackColor="Window" Height="200px"></FrameStyle>
												<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
													<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
												</FooterStyleDefault>
												<GroupByBox Hidden="True" Prompt="Arraste uma coluna aqui para efetuar o agrupamento...">
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
												<igtbl:UltraGridBand AddButtonCaption="tbNotasRelacionadasPromessaFornecedor" BaseTableName="tbNotasRelacionadasPromessaFornecedor"
													Key="tbNotasRelacionadasPromessaFornecedor">
													<Columns>
														<igtbl:TemplatedColumn Key="" Width="20px" HeaderText="" BaseColumnName="" AllowUpdate="Yes">
															<CellTemplate>
																<asp:LinkButton id="btnEscolher" runat="server" ToolTip="DISSOCIAR NOTA">
																	<IMG height="16" src="../Imagens/office/S_B_PAGR.gif" width="16" align="absMiddle"></asp:LinkButton>
															</CellTemplate>
															<Footer Key=""></Footer>
															<Header Key="" Caption=""></Header>
														</igtbl:TemplatedColumn>
														<igtbl:UltraGridColumn HeaderText="N&#250;mero" Key="" Width="45px" BaseColumnName="">
															<Footer Key="">
																<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="" Caption="N&#250;mero">
																<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Vencimento" Key="DatPgtPclNotFsc" IsBound="True" Width="65px" Format="dd/MM/yyyy"
															DataType="System.DateTime" BaseColumnName="DatPgtPclNotFsc">
															<Footer Key="DatPgtPclNotFsc">
																<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="DatPgtPclNotFsc" Caption="Vencimento">
																<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Valor Dispon&#237;vel" Key="VlrDspNotFsc" IsBound="True" Width="85px"
															Format="R$  ###,###,##0.00" DataType="System.Decimal" BaseColumnName="VlrDspNotFsc">
															<Footer Key="VlrDspNotFsc">
																<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="VlrDspNotFsc" Caption="Valor Dispon&#237;vel">
																<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Valor Utilizado" Key="VlrRelNotFsc" IsBound="True" Width="80px" Format="R$  ###,###,##0.00"
															DataType="System.Decimal" BaseColumnName="VlrRelNotFsc">
															<Footer Key="VlrRelNotFsc">
																<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="VlrRelNotFsc" Caption="Valor Utilizado">
																<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="NumNotFscFrnCtb" Key="NumNotFscFrnCtb" IsBound="True" Width="100px"
															Hidden="True" DataType="System.Int32" BaseColumnName="NumNotFscFrnCtb">
															<Footer Key="NumNotFscFrnCtb">
																<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="NumNotFscFrnCtb" Caption="NumNotFscFrnCtb">
																<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Valor Associado" Key="VlrTitPgtUtzSbtPms" IsBound="True" Width="85px"
															Format="R$  ###,###,##0.00" DataType="System.Decimal" BaseColumnName="VlrTitPgtUtzSbtPms">
															<Footer Key="VlrTitPgtUtzSbtPms">
																<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="VlrTitPgtUtzSbtPms" Caption="Valor Associado">
																<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="CodSeqPclNotFsc" Key="CodSeqPclNotFsc" IsBound="True" Width="100px"
															Hidden="True" BaseColumnName="CodSeqPclNotFsc">
															<Footer Key="CodSeqPclNotFsc">
																<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="CodSeqPclNotFsc" Caption="CodSeqPclNotFsc">
																<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="NumSeqTitPgt" Key="NumSeqTitPgt" IsBound="True" Width="100px" Hidden="True"
															DataType="System.Int32" BaseColumnName="NumSeqTitPgt">
															<Footer Key="NumSeqTitPgt">
																<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="NumSeqTitPgt" Caption="NumSeqTitPgt">
																<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="CodEmpFrn" Key="CodEmpFrn" IsBound="True" Width="100px" Hidden="True"
															DataType="System.Int32" BaseColumnName="CodEmpFrn">
															<Footer Key="CodEmpFrn">
																<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="CodEmpFrn" Caption="CodEmpFrn">
																<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
													</Columns>
												</igtbl:UltraGridBand>
											</Bands>
										</igtbl:ultrawebgrid></TD>
									<TD class="barra1" align="center" width="40%">
										<igtbl:ultrawebgrid id=grdNotasDisponiveis runat="server" Width="100%" Height="200px" ImageDirectory="/ig_common/Images/" DataSource="<%# dsTrocaManualTituloPagamentoAcordoComercial %>" DataMember="tbNotasDisponiveisRelacionamento">
											<DisplayLayout AllowSortingDefault="OnClient" RowHeightDefault="20px" Version="4.00" SelectTypeRowDefault="Extended"
												ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer" HeaderClickActionDefault="SortMulti"
												BorderCollapseDefault="Separate" AllowColSizingDefault="Free" RowSelectorsDefault="No" Name="grdNotasDisponiveis"
												TableLayout="Fixed">
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
													BorderColor="InactiveCaption" BorderStyle="Solid" BackColor="Window" Height="200px"></FrameStyle>
												<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
													<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
												</FooterStyleDefault>
												<GroupByBox Hidden="True" Prompt="Arraste uma coluna aqui para efetuar o agrupamento...">
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
												<igtbl:UltraGridBand AddButtonCaption="tbNotasDisponiveisRelacionamento" BaseTableName="tbNotasDisponiveisRelacionamento"
													Key="tbNotasDisponiveisRelacionamento">
													<Columns>
														<igtbl:TemplatedColumn Key="" Width="20px" HeaderText="" BaseColumnName="" AllowUpdate="Yes">
															<CellTemplate>
																<asp:LinkButton id="Linkbutton1" runat="server" ToolTip="ASSOCIAR NOTA">
																	<IMG height="16" src="../Imagens/office/S_B_PAGL.gif" width="16" align="absMiddle"></asp:LinkButton>
															</CellTemplate>
															<Footer Key=""></Footer>
															<Header Key="" Caption=""></Header>
														</igtbl:TemplatedColumn>
														<igtbl:UltraGridColumn HeaderText="N&#250;mero" Key="" Width="70px" BaseColumnName="">
															<Footer Key="">
																<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="" Caption="N&#250;mero">
																<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Data Vencimento" Key="DatPgtPclNotFsc" IsBound="True" Width="90px" Format="dd/MM/yyyy"
															DataType="System.DateTime" BaseColumnName="DatPgtPclNotFsc">
															<Footer Key="DatPgtPclNotFsc">
																<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="DatPgtPclNotFsc" Caption="Data Vencimento">
																<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Valor Dispon&#237;vel" Key="VlrDspNotFsc" IsBound="True" Width="90px"
															Format="R$  ###,###,##0.00" DataType="System.Decimal" BaseColumnName="VlrDspNotFsc">
															<Footer Key="VlrDspNotFsc">
																<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="VlrDspNotFsc" Caption="Valor Dispon&#237;vel">
																<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="NumNotFscFrnCtb" Key="NumNotFscFrnCtb" IsBound="True" Hidden="True"
															DataType="System.Int32" BaseColumnName="NumNotFscFrnCtb">
															<Footer Key="NumNotFscFrnCtb">
																<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="NumNotFscFrnCtb" Caption="NumNotFscFrnCtb">
																<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="CodSeqPclNotFsc" Key="CodSeqPclNotFsc" IsBound="True" Hidden="True"
															BaseColumnName="CodSeqPclNotFsc">
															<Footer Key="CodSeqPclNotFsc">
																<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="CodSeqPclNotFsc" Caption="CodSeqPclNotFsc">
																<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="NumSeqTitPgt" Key="NumSeqTitPgt" IsBound="True" Hidden="True" DataType="System.Int32"
															BaseColumnName="NumSeqTitPgt">
															<Footer Key="NumSeqTitPgt">
																<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="NumSeqTitPgt" Caption="NumSeqTitPgt">
																<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="CodEmpFrn" Key="CodEmpFrn" IsBound="True" Hidden="True" DataType="System.Int32"
															BaseColumnName="CodEmpFrn">
															<Footer Key="CodEmpFrn">
																<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="CodEmpFrn" Caption="CodEmpFrn">
																<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="VlrTitPgtUtzSbtPms" Key="VlrTitPgtUtzSbtPms" IsBound="True" Hidden="True"
															DataType="System.Decimal" BaseColumnName="VlrTitPgtUtzSbtPms">
															<Footer Key="VlrTitPgtUtzSbtPms">
																<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="VlrTitPgtUtzSbtPms" Caption="VlrTitPgtUtzSbtPms">
																<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="VlrRelNotFsc" Key="VlrRelNotFsc" IsBound="True" Hidden="True" DataType="System.Decimal"
															BaseColumnName="VlrRelNotFsc">
															<Footer Key="VlrRelNotFsc">
																<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="VlrRelNotFsc" Caption="VlrRelNotFsc">
																<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="DES." Key="FlagFoiDesassociada" IsBound="True" Width="30px" Hidden="True"
															DataType="System.Boolean" BaseColumnName="FlagFoiDesassociada">
															<Footer Key="FlagFoiDesassociada">
																<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="FlagFoiDesassociada" Caption="DES.">
																<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
													</Columns>
												</igtbl:UltraGridBand>
											</Bands>
										</igtbl:ultrawebgrid></TD>
								</TR>
								<TR>
								</TR>
							</TABLE>
							<TABLE id="tblVlrUtz" borderColor="silver" cellSpacing="0" cellPadding="0" width="250"
								border="1" runat="server" visible="false">
								<TR>
									<TD style="HEIGHT: 17px" bgColor="silver" colSpan="2"><STRONG>Informe o valor a ser 
											utilizado para a nota.</STRONG></TD>
								</TR>
								<TR>
									<TD align="center"><igtxt:webcurrencyedit id="txtVlrUtz" runat="server" Width="120px" Height="19px" DataMode="Decimal"></igtxt:webcurrencyedit></TD>
									<TD align="center">
										<TABLE class="3D" id="Table3" cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnOk" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
														Width="57px"><IMG height="16" src="../Imagens/office/s_b_okay.gif" width="20" align="absMiddle">OK</asp:linkbutton></TD>
											</TR>
										</TABLE>
										<TABLE class="3D" id="Table2" cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnCancVlr" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/s_b_canc.gif" width="16" align="absMiddle">
													Cancelar</asp:linkbutton></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</td>
					</tr>
				</tbody>
			</table>
			<asp:label id="lblErro" runat="server" Font-Size="10px" ForeColor="Red"></asp:label></form>
	</body>
</HTML>
