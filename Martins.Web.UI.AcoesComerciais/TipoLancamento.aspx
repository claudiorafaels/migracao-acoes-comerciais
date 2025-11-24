<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="martinscontrols" Namespace="Martins.Web.UI.Controls" Assembly="Martins.Web.UI.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=e9ed78c287a2fd3c" %>
<%@ Register TagPrefix="igcmbo" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TipoLancamento.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.TipoLancamento" %>
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
//-->
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
							<table cellSpacing="0" cellPadding="0" border="0">
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
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnCancelar" style="TEXT-DECORATION: none" runat="server" href="TipoLancamentoListar.aspx"
														CausesValidation="False"><IMG height="16" src="../Imagens/office/Sair.gif" width="16" align="absMiddle"> Sair</asp:linkbutton></td>
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
							<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
									<TR>
										<TD class="barra3" width="10%">Código:</TD>
										<TD class="barra1" width="40%"><igtxt:webnumericedit id="txtCodTipLmt" runat="server" Font-Names="Arial" CssClass=" " ReadOnly="True"
												Font-Size="11px" Width="48px" Height="19px"></igtxt:webnumericedit></TD>
										<TD class="barra1" width="10%"></TD>
										<TD class="barra1" width="40%"></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%">Descrição:</TD>
										<TD class="barra1" width="40%"><igtxt:webtextedit id="txtDesTipLmt" runat="server" Font-Names="Arial" CssClass=" " Font-Size="11px"
												Width="216px" Height="19px"></igtxt:webtextedit></TD>
										<TD class="barra3" width="10%">Lançamento Manual:</TD>
										<TD class="barra1" width="40%"><asp:checkbox id="chkFlgLmtMan" runat="server" Font-Names="Arial" CssClass=" " Font-Size="11px"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%">Gera Lançamento Contábil</TD>
										<TD class="barra1" width="40%"><asp:checkbox id="chkFlgGrcLmtCtb" runat="server" Font-Names="Arial" CssClass=" " Font-Size="11px"
												AutoPostBack="True"></asp:checkbox></TD>
										<TD class="barra3" width="10%">Usar Descrição Fornecedor:</TD>
										<TD class="barra1" width="40%"><asp:checkbox id="chkIndTipLmtDspFrn" runat="server" Font-Names="Arial" CssClass=" " Font-Size="11px"
												AutoPostBack="True"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%">Lançamento Sintético:</TD>
										<TD class="barra1" width="40%"><asp:checkbox id="chkIndTipLmtStn" runat="server" Font-Names="Arial" CssClass=" " Font-Size="11px"
												AutoPostBack="True"></asp:checkbox></TD>
										<TD class="barra3" width="10%">Desc. Lançamento Fornecedor:</TD>
										<TD class="barra1" width="40%"><igtxt:webtextedit id="txtDesTipLmtFrn" runat="server" Font-Names="Arial" CssClass=" " Font-Size="11px"
												Width="216px" Height="19px" Enabled="False"></igtxt:webtextedit></TD>
									</TR>
									<TR>
										<TD class="barra1" width="10%"></TD>
										<TD class="barra1" width="40%"></TD>
										<TD class="barra1" width="10%"></TD>
										<TD class="barra1" width="40%"></TD>
									</TR>
									</TABLES></TBODY></TABLE>
							<TABLE class="tabela1" id="tblAssociacao" cellSpacing="0" cellPadding="2" width="100%"
								border="0" runat="server" VISIBLE="FALSE">
								<TR>
									<TD class="barra3" width="10%">Associação:</TD>
									<TD class="barra1" width="90%"><asp:dropdownlist id="cmbTipoLancamentoAssoc" runat="server" Font-Names="Arial" CssClass="" Font-Size="11px"
											Width="250px" Height="19px"></asp:dropdownlist>&nbsp;
										<asp:linkbutton id="lkbAssociar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
											ForeColor="Black"><IMG height="16" src="../Imagens/office/S_B_OKAY.gif" width="16" align="absMiddle"> Associar</asp:linkbutton>&nbsp;<BR>
										<igtbl:ultrawebgrid id="grdAssociacao" runat="server" Width="100%" Height="110px" UseAccessibleHeader="False"
											ImageDirectory="/ig_common/Images/">
											<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" RowHeightDefault="20px"
												Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
												HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
												RowSelectorsDefault="No" Name="grdAssociacao" TableLayout="Fixed">
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
													BorderStyle="Solid" BackColor="Window" Height="110px"></FrameStyle>
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
												<igtbl:UltraGridBand AddButtonCaption="T0123108_Associada" SelectTypeRow="Single" Key="T0123108_Associada"
													AllowDelete="Yes">
													<Columns>
														<igtbl:TemplatedColumn Key="" Width="40px" HeaderText="EXCLUIR" BaseColumnName="" AllowUpdate="Yes">
															<CellTemplate>
																<asp:ImageButton id=imgExcluir runat="server" Height="16px" Width="16px" CommandArgument='<%# Container.Cell.Row.Cells.FromKey("CÓDIGO").Value %>' ImageUrl="../Imagens/office/apagar.gif" CommandName="cnExcluir">
																</asp:ImageButton>
															</CellTemplate>
															<Footer Key=""></Footer>
															<Header Key="" Caption="EXCLUIR"></Header>
														</igtbl:TemplatedColumn>
													</Columns>
													<RowEditTemplate>
														<P align="right">DATA NEGOCIAÇÃO&nbsp;<INPUT id="igtbl_TextBox_0_0" style="WIDTH: 150px" type="text" columnKey="DATNGCPMS"><BR>
															DATA RECEBIMENTO&nbsp;<INPUT id="igtbl_TextBox_0_1" style="WIDTH: 150px" type="text" columnKey="DATPRVRCBPMS"><BR>
															VALOR&nbsp;<INPUT id="igtbl_TextBox_0_2" style="WIDTH: 150px" type="text" columnKey="VLRNGCPMS"><BR>
															FORMA&nbsp;
															<asp:dropdownlist id="Dropdownlist3" runat="server" Height="22px" Width="150px" Font-Size="11px" CssClass=""
																Font-Names="Arial"></asp:dropdownlist><BR>
															DESTINO
															<asp:dropdownlist id="Dropdownlist1" runat="server" Height="22px" Width="150px" Font-Size="11px" CssClass=""
																Font-Names="Arial"></asp:dropdownlist><BR>
														</P>
														<P align="right"><INPUT id="igtbl_reOkBtn" style="WIDTH: 50px" onclick="igtbl_gRowEditButtonClick(event);"
																type="button" value="OK">&nbsp; <INPUT id="igtbl_reCancelBtn" style="WIDTH: 50px" onclick="igtbl_gRowEditButtonClick(event);"
																type="button" value="Cancel"></P>
													</RowEditTemplate>
													<RowTemplateStyle BorderColor="Window" BorderStyle="Ridge" BackColor="Window">
														<BorderDetails WidthLeft="3px" WidthTop="3px" WidthRight="3px" WidthBottom="3px"></BorderDetails>
													</RowTemplateStyle>
													<SelectedRowStyle BorderColor="Transparent" BorderStyle="None" BackColor="ScrollBar"></SelectedRowStyle>
												</igtbl:UltraGridBand>
											</Bands>
										</igtbl:ultrawebgrid></TD>
								</TR>
								<TR>
									<TD class="barra1" width="10%"></TD>
									<TD class="barra1" width="40%">
										<P align="right">-</P>
									</TD>
									<TD class="barra1" width="10%"></TD>
									<TD class="barra1" width="40%"></TD>
								</TR>
							</TABLE>
							<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TR>
									<TD class="barra1" width="10%"></TD>
									<TD class="barra1" width="40%" align="left"><DIV align="left">
											<asp:Label id="Label1" runat="server" ForeColor="Black">Parâmetros Contábeis:</asp:Label></DIV>
									</TD>
									<TD class="barra1" width="10%"></TD>
									<TD class="barra1" width="40%"></TD>
								</TR>
								<TR>
									<TD class="barra3" width="10%">Filial</TD>
									<TD class="barra1" width="40%"><asp:dropdownlist id="cmbFillial" runat="server" Font-Names="Arial" CssClass="" Font-Size="11px" Width="250px"
											Height="19px" AutoPostBack="True"></asp:dropdownlist>&nbsp;</TD>
									<TD class="barra1" width="10%"></TD>
									<TD class="barra1" width="40%">
										<asp:linkbutton id="lkbAtualizarParamContab" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
											ForeColor="Black"><IMG height="16" src="../Imagens/office/S_B_OKAY.gif" width="16" align="absMiddle"> Atualizar Parametros Contábeis</asp:linkbutton></TD>
								</TR>
								<TR>
									<TD class="barra3" width="10%">Conta Débito</TD>
									<TD class="barra1" width="40%"><igtxt:webtextedit id="txtContaDebito" runat="server" Font-Names="Arial" CssClass=" " Font-Size="11px"
											Width="100px" Height="19px" Enabled="False"></igtxt:webtextedit></TD>
									<TD class="barra3" width="10%">Centro Custo Débito</TD>
									<TD class="barra1" width="40%"><igtxt:webtextedit id="txtCCDebito" runat="server" Font-Names="Arial" CssClass=" " Font-Size="11px"
											Width="100px" Height="19px" Enabled="False"></igtxt:webtextedit></TD>
								</TR>
								<TR>
									<TD class="barra3" width="10%">Conta Crédito</TD>
									<TD class="barra1" width="40%"><igtxt:webtextedit id="txtContaCredito" runat="server" Font-Names="Arial" CssClass=" " Font-Size="11px"
											Width="100px" Height="19px" Enabled="False"></igtxt:webtextedit></TD>
									<TD class="barra3" width="10%">Centro Custo Crédito</TD>
									<TD class="barra1" width="40%"><igtxt:webtextedit id="txtCCCredito" runat="server" Font-Names="Arial" CssClass=" " Font-Size="11px"
											Width="100px" Height="19px" Enabled="False"></igtxt:webtextedit></TD>
								</TR>
								<TR>
									<TD class="barra3" width="10%">Cod. Hist. Padrao</TD>
									<TD class="barra1" width="40%">
										<igtxt:WebNumericEdit id="txtCodHistPadrao" runat="server" CssClass=" " Width="100px" Height="19px" DataMode="Decimal"></igtxt:WebNumericEdit></TD>
									<TD class="barra1" width="10%"></TD>
									<TD class="barra1" width="40%"></TD>
								</TR>
								<TR>
									<TD class="barra3" width="10%">Cod. Fato</TD>
									<TD class="barra1" width="40%">
										<igtxt:WebNumericEdit id="txtCodFato" runat="server" CssClass=" " Width="100px" Height="19px" DataMode="Decimal"></igtxt:WebNumericEdit></TD>
									<TD class="barra3" width="10%">Cod. Evento</TD>
									<TD class="barra1" width="40%">
										<igtxt:WebNumericEdit id="txtCodEvento" runat="server" CssClass=" " Width="100px" Height="19px" DataMode="Decimal"></igtxt:WebNumericEdit></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
				</tbody>
			</table>
			<asp:label id="lblErro" runat="server" Font-Size="10px" ForeColor="Red"></asp:label></form>
	</body>
</HTML>
