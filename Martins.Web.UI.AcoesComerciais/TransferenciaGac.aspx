<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="martinscontrols" Namespace="Martins.Web.UI.Controls" Assembly="Martins.Web.UI.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=e9ed78c287a2fd3c" %>
<%@ Register TagPrefix="igcmbo" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="AppComponents/wucFornecedor.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TransferenciaGAC.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.TransferenciaGAC" %>
<%@ Register TagPrefix="igtxt1" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3" %>
<%@ Register TagPrefix="igmisc" Namespace="Infragistics.WebUI.Misc" Assembly="Infragistics.WebUI.Misc.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
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

function escondeAndamento() {
	window.MM_findObj('tdEspera').style.display = 'none';
	window.MM_findObj('btnSalvar').style.display = 'inline';
	return true;
}

function mostraAndamento() {
	window.MM_findObj('tdEspera').style.display = 'inline';
	window.MM_findObj('btnSalvar').style.display = 'none';
	return true;   
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}
		function txtValor_Blur(oEdit, text, oEvent){
			btnSalvar.focus()	
		}
		function txtEmpenhoDS_Blur(oEdit, text, oEvent){
			document.getElementById('ddlEmpenhoDS').value = text;			
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
									<td id="TDTransferir" runat="server">
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
										<TD class="barra3" height="19">Data:</TD>
										<TD class="barra1" height="19">
											<P align="left"><igtxt:webdatetimeedit id="txtData" runat="server" CssClass="" Width="100px" Height="19px" Font-Size="11px"
													Font-Names="Arial" ReadOnly="True"></igtxt:webdatetimeedit></P>
										</TD>
										<TD class="barra1" height="19"></TD>
										<TD class="barra1" height="19"></TD>
									</TR>
									<TR>
										<TD class="barra3" height="19">Usuário:</TD>
										<TD class="barra1" height="19"><asp:textbox id="txtUsuario" runat="server" CssClass="" Width="100px" Height="19px" Font-Size="11px"
												Font-Names="Arial" ReadOnly="True"></asp:textbox></TD>
										<TD class="barra1" height="19"></TD>
										<TD class="barra1" height="19"></TD>
									</TR>
									<TR>
										<TD class="barra1" height="5"></TD>
										<TD class="barra1" height="5"></TD>
										<TD class="barra1" height="5"></TD>
										<TD class="barra1" height="5"></TD>
									</TR>
									<TR>
										<TD class="barra3" height="19">Conta Origem:</TD>
										<TD class="barra3" height="19"></TD>
										<TD class="barra3" height="19"></TD>
										<TD class="barra3" height="19"></TD>
									</TR>
									<TR>
										<TD class="barra3" height="19">
											<asp:dropdownlist id="ddl1" runat="server" Font-Names="Arial" Font-Size="11px" Height="19px" Width="0px"
												CssClass=" " AutoPostBack="True"></asp:dropdownlist>Fornecedor:</TD>
										<TD class="barra1" height="19"><uc1:wucfornecedor id="ucFornecedorOR" runat="server"></uc1:wucfornecedor></TD>
										<TD class="barra3" height="19" id="TD3" runat="server">Saldo Emp.</TD>
										<TD class="barra1" height="19" id="TD1" runat="server"><igtxt:webcurrencyedit id="txtSaldoEmp" runat="server" CssClass="" Width="96px" Height="19px" DataMode="Decimal"
												ReadOnly="True" Font-Size="11px" Font-Names="Arial"></igtxt:webcurrencyedit></TD>
									</TR>
									<TR>
										<TD class="barra3" height="19">
											<asp:dropdownlist id="ddl2" runat="server" Font-Names="Arial" Font-Size="11px" Height="19px" Width="0px"
												CssClass=" " AutoPostBack="True"></asp:dropdownlist>Empenho:</TD>
										<TD class="barra1" height="19">
											<igtxt:WebNumericEdit id="txtEmpenho" runat="server" Font-Names="Arial" Font-Size="11px" Width="60px"
												CssClass="" AutoPostBack="True"></igtxt:WebNumericEdit><asp:dropdownlist id="ddlEmpenhoOR" runat="server" Width="200px" Height="19px" AutoPostBack="True"
												Font-Names="Arial" Font-Size="11px" CssClass=" "></asp:dropdownlist></TD>
										<TD class="barra3" height="19" id="TD4" runat="server">Saldo Disp.</TD>
										<TD class="barra1" height="19" id="TD2" runat="server"><igtxt:webcurrencyedit id="txtSaldoDisp" runat="server" CssClass="" Width="96px" Height="19px" DataMode="Decimal"
												ReadOnly="True" Font-Size="11px" Font-Names="Arial"></igtxt:webcurrencyedit></TD>
									</TR>
									<TR>
										<TD class="barra3" height="19">
											<asp:dropdownlist id="ddl3" runat="server" Font-Names="Arial" Font-Size="11px" Height="19px" Width="0px"
												CssClass=" " AutoPostBack="True"></asp:dropdownlist>Alocações:</TD>
										<TD class="barra1" colSpan="3" height="19"><igtbl:ultrawebgrid id=grdAlocacoes runat="server" Width="100%" Height="82px" DataMember="tbSelecaoValorDisponivelFornecedor" DataSource="<%# dsSelecaoValorDisponivelFornecedor %>" ImageDirectory="/ig_common/Images/">
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
													<GroupByRowStyleDefault BorderColor="Window" BackColor="Control"></GroupByRowStyleDefault>
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
																<Footer Key="TipDsnDscBnf"></Footer>
																<Header Key="TipDsnDscBnf" Caption=""></Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="TipAlcVbaFrn" Key="TipAlcVbaFrn" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="TipAlcVbaFrn">
																<Footer Key="TipAlcVbaFrn">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TipAlcVbaFrn" Caption="TipAlcVbaFrn">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Aloca&#231;&#227;o" Key="DesAlcVbaFrn" IsBound="True" BaseColumnName="DesAlcVbaFrn">
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
																<CellStyle HorizontalAlign="Right"></CellStyle>
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
																<CellStyle HorizontalAlign="Right"></CellStyle>
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
																<CellStyle HorizontalAlign="Right"></CellStyle>
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
										<TD class="barra3" height="19" id="TD5" runat="server">Total Alocações:</TD>
										<TD class="barra1" height="19" id="TD6" runat="server"><igtxt:webcurrencyedit id="txtTotalAloc" runat="server" CssClass="" Width="96px" Height="19px" DataMode="Decimal"
												ReadOnly="True"></igtxt:webcurrencyedit></TD>
										<TD class="barra1" height="19" id="TD7" runat="server"></TD>
										<TD class="barra1" height="19" id="TD8" runat="server"></TD>
									</TR>
									<TR>
										<TD class="barra1" height="5"></TD>
										<TD class="barra1" height="5"></TD>
										<TD class="barra1" height="5"></TD>
										<TD class="barra1" height="5"></TD>
									</TR>
									<TR>
										<TD class="barra3" height="19">Conta Destino:</TD>
										<TD class="barra3" height="19"></TD>
										<TD class="barra3" height="19"></TD>
										<TD class="barra3" height="19"></TD>
									</TR>
									<TR>
										<TD class="barra3" height="19">Fornecedor:</TD>
										<TD class="barra1" height="19">
											<uc1:wucfornecedor id="ucFornecedorDS" runat="server"></uc1:wucfornecedor></TD>
										<TD class="barra1" height="19"></TD>
										<TD class="barra1" height="19"></TD>
									</TR>
									<TR>
										<TD class="barra3" height="20" style="HEIGHT: 20px">
											<asp:dropdownlist id="ddl4" runat="server" Font-Names="Arial" Font-Size="11px" Height="19px" Width="0px"
												CssClass=" " AutoPostBack="True"></asp:dropdownlist>Empenho:</TD>
										<TD class="barra1" height="20" style="HEIGHT: 20px">
											<igtxt:WebNumericEdit id="txtEmpenhoDS" runat="server" Font-Names="Arial" Font-Size="11px" Width="60px"
												CssClass="">
												<ClientSideEvents Blur="txtEmpenhoDS_Blur"></ClientSideEvents>
											</igtxt:WebNumericEdit><asp:dropdownlist id="ddlEmpenhoDS" runat="server" Width="200px" Height="19px" Font-Names="Arial"
												Font-Size="11px" CssClass=" "></asp:dropdownlist></TD>
										<TD class="barra1" height="20" style="HEIGHT: 20px"></TD>
										<TD class="barra1" height="20" style="HEIGHT: 20px"></TD>
									</TR>
									<TR>
										<TD class="barra3" height="18" style="HEIGHT: 18px">Destino:</TD>
										<TD class="barra1" height="18" style="HEIGHT: 18px"><asp:dropdownlist id="ddlDestino" runat="server" Width="260px" Height="19px" Font-Names="Arial" Font-Size="11px"
												CssClass=" ">
												<asp:ListItem Value="2">2 - MARKETING</asp:ListItem>
												<asp:ListItem Value="3" Selected="True">3 - CONTA CORRENTE</asp:ListItem>
											</asp:dropdownlist></TD>
										<TD class="barra1" height="18" style="HEIGHT: 18px"></TD>
										<TD class="barra1" height="18" style="HEIGHT: 18px"></TD>
									</TR>
									<TR>
										<TD class="barra1" height="5"></TD>
										<TD class="barra1" height="5"></TD>
										<TD class="barra1" height="5"></TD>
										<TD class="barra1" height="5"></TD>
									</TR>
									<TR>
										<TD class="barra3" height="19">Histórico:</TD>
										<TD class="barra1" height="19"><asp:textbox id="txtHistorico" runat="server" CssClass="" Width="400px" Height="19px" Font-Size="11px"
												Font-Names="Arial" MaxLength="50"></asp:textbox></TD>
										<TD class="barra1" height="19"></TD>
										<TD class="barra1" height="19"></TD>
									</TR>
									<TR>
										<TD class="barra3" height="19">Valor:</TD>
										<TD class="barra1" height="19"><igtxt:webcurrencyedit id="txtValor" runat="server" CssClass="" Width="96px" Height="19px" DataMode="Decimal"
												Font-Size="11px" Font-Names="Arial">
												<ClientSideEvents Blur="txtValor_Blur"></ClientSideEvents>
											</igtxt:webcurrencyedit></TD>
										<TD class="barra1" height="19"></TD>
										<TD class="barra1" height="19"></TD>
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
