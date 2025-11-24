<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="AppComponents/wucFornecedor.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="OperacoesOpQuebra.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.OperacoesOpQuebra" %>
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
		<base target="_self">
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
			<table style="WIDTH: 100%; HEIGHT: 67px" height="67" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<tbody>
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
										<TD class="barra3" width="14%" height="19">
											<P align="right">Ordem Pagto:</P>
										</TD>
										<TD class="barra1" width="36%" height="19"><igtxt:webnumericedit id="txtOpOriginal" runat="server" Height="19px" Width="100px" CssClass=""
												Font-Names="Arial" Font-Size="11px" ReadOnly="True"></igtxt:webnumericedit></TD>
										<TD class="barra3" width="14%" height="19">
											<P align="right">Valor OP:</P>
										</TD>
										<TD class="barra1" width="36%" height="19"><igtxt:webcurrencyedit id="txtTotVlrOP" runat="server" Height="19px" Width="100px" CssClass=""
												Font-Names="Arial" Font-Size="11px" ReadOnly="True" Enabled="False"></igtxt:webcurrencyedit></TD>
									</TR>
									<TR>
										<TD class="barra3" width="14%" height="19">
											<P align="right">Cod. Fornecedor:</P>
										</TD>
										<TD class="barra1" width="36%" height="19"><igtxt:webnumericedit id="txtCodigoFornecedor" runat="server" Height="19px" Width="100px" CssClass=""
												Font-Names="Arial" Font-Size="11px" ReadOnly="True"></igtxt:webnumericedit></TD>
										<TD class="barra3" width="14%" height="19">
											<P align="right">Nome Fornecedor:</P>
										</TD>
										<TD class="barra1" width="36%" height="19"><igtxt:webtextedit id="txtNomeFornecedor" runat="server" Width="100%" CssClass="" ReadOnly="True"></igtxt:webtextedit></TD>
									</TR>
									<TR>
										<TD class="barra3" width="14%" height="19">
											<P align="right">Descrição do Hist. Depos. Ident. :</P>
										</TD>
										<TD class="barra1" width="86%" colSpan="3" height="19"><igtxt:webtextedit id="txtDecricaoHistorico" runat="server" Width="100%" CssClass="" ReadOnly="True"></igtxt:webtextedit></TD>
									</TR>
									<TR>
										<TD class="barra1" width="14%" height="19"></TD>
										<TD class="barra1" width="86%" colSpan="3" height="19"></TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE class="tabela2" id="Table2" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
									<TR>
										<TD class="barra3" width="62%" colSpan="2" height="19">Forneced.</TD>
										<TD class="barra3" width="15%" height="19">Valor</TD>
										<TD class="barra1" width="23%" height="19"></TD>
									</TR>
									<TR>
										<TD class="barra1" width="62%" colSpan="2" height="19"><uc1:wucfornecedor id="ucFornecedor" runat="server"></uc1:wucfornecedor></TD>
										<TD class="barra1" width="15%" height="19"><igtxt:webcurrencyedit id="txtValorQuebra" runat="server" Height="19px" Width="100%" CssClass=""
												Font-Names="Arial" Font-Size="11px"></igtxt:webcurrencyedit></TD>
										<TD class="barra1" width="23%" height="19"></TD>
									</TR>
									<TR>
										<TD class="barra1" width="77%" colSpan="3" height="19"><igtbl:ultrawebgrid id="uwgQuebra" runat="server" Height="150px" Width="100%" ImageDirectory="/ig_common/Images/"
												UseAccessibleHeader="False" DataMember="tbQuebraOP" DataSource="<%# DatasetOperacaoBaixaOperacaoFornecedor1 %>">
												<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" RowHeightDefault="20px"
													Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
													HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
													RowSelectorsDefault="No" Name="uwgQuebra" TableLayout="Fixed" CellClickActionDefault="RowSelect">
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
													<FrameStyle Width="100%" BorderWidth="1px" Font-Size="8.25pt" Font-Names="Microsoft Sans Serif"
														BorderColor="InactiveCaption" BorderStyle="Solid" BackColor="Window" Height="150px"></FrameStyle>
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
													<igtbl:UltraGridBand AddButtonCaption="tbQuebraOP" BaseTableName="tbQuebraOP" Key="tbQuebraOP">
														<Columns>
															<igtbl:UltraGridColumn HeaderText="Codigo" Key="Codigo" IsBound="True" DataType="System.Int32" BaseColumnName="Codigo">
																<Footer Key="Codigo"></Footer>
																<Header Key="Codigo" Caption="Codigo"></Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Fornecedor" Key="Fornecedor" IsBound="True" BaseColumnName="Fornecedor">
																<Footer Key="Fornecedor">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="Fornecedor" Caption="Fornecedor">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Valor" Key="Valor" IsBound="True" DataType="System.Decimal" BaseColumnName="Valor">
																<Footer Key="Valor">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="Valor" Caption="Valor">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Tipo" Key="Tipo" IsBound="True" BaseColumnName="Tipo">
																<Footer Key="Tipo">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="Tipo" Caption="Tipo">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
														</Columns>
													</igtbl:UltraGridBand>
												</Bands>
											</igtbl:ultrawebgrid></TD>
										<TD class="barra1" width="23%" height="19" runat="server" id="tbOpcoes">
											<asp:button id="btnIncluir" runat="server" Width="100%" Text="Incluir"></asp:button><br>
											<br>
											<asp:button id="btnExcluir" runat="server" Width="100%" Text="Excluir"></asp:button><br>
											<br>
											<asp:button id="btnConfirmar" runat="server" Width="100%" Text="Confirmar"></asp:button><BR>
											<br>
											<INPUT id="btnFechar" style="WIDTH: 100%" onclick="javascript:window.close();" type="button"
												value="Fechar">
											<br>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE class="tabela2" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
									<TR>
										<TD class="barra3" width="20%" height="19">Saldo</TD>
										<TD class="barra1" width="19%" height="19"><igtxt:webcurrencyedit id="txtValorSaldo" runat="server" Height="19px" Width="100%" CssClass=""
												Font-Names="Arial" Font-Size="11px" ReadOnly="True" Enabled="False"></igtxt:webcurrencyedit></TD>
										<TD class="barra3" width="19%" height="19">
											<P align="right">Total</P>
										</TD>
										<TD class="barra1" width="19%" height="19"><igtxt:webcurrencyedit id="txtValorTotal" runat="server" Height="19px" Width="100%" CssClass=""
												Font-Names="Arial" Font-Size="11px" ReadOnly="True" Enabled="False"></igtxt:webcurrencyedit></TD>
										<TD class="barra1" width="23%" height="19"></TD>
									</TR>
								</TBODY>
							</TABLE>
						</td>
					</tr>
				</tbody>
			</table>
		</form>
	</body>
</HTML>
