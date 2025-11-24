<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="martinscontrols" Namespace="Martins.Web.UI.Controls" Assembly="Martins.Web.UI.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=e9ed78c287a2fd3c" %>
<%@ Register TagPrefix="igcmbo" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igcmbo1" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3" %>
<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="AppComponents/wucFornecedor.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AlteraFormaPagamento.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.AlteraFormaPagamento" %>
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
		<script for="document" event="onreadystatechange">
			if (readyState == 'complete'){
				escondeAndamento();
			} else {
				mostraAndamento();			
			}
		</script>
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

function escondeAndamento() {
	window.MM_findObj('trEspera').style.display = 'none';
	window.MM_findObj('tbOpcoes').style.display = 'inline';
	return true;
}

function mostraAndamento() {
	window.MM_findObj('trEspera').style.display = 'inline';
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
	<body scroll="yes" onload="MM_preloadImages('../Imagens/lastpost.gif')">
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
										<TD class="barra1" align="left" style="HEIGHT: 35px" width="50%">
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
										<TD class="barra3" style="HEIGHT: 1px" width="15%">Desconto:</TD>
										<TD class="barra1" style="HEIGHT: 1px" width="85%" colSpan="3"><asp:dropdownlist id="ddlDesconto" runat="server" Width="200px" AutoPostBack="True">
												<asp:ListItem Value="IPP" Selected="True">IPP</asp:ListItem>
												<asp:ListItem Value="IPC/BCC">IPC/BCC</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="barra3" style="HEIGHT: 28px" width="15%">Fornecedor:</TD>
										<TD class="barra1" style="HEIGHT: 28px" vAlign="top" width="85%" colSpan="5"><uc1:wucfornecedor id="ucFornecedor" runat="server"></uc1:wucfornecedor></TD>
									</TR>
									<TR>
										<TD class="barra3" style="HEIGHT: 23px" width="15%">Tipo:</TD>
										<TD class="barra1" style="HEIGHT: 23px" width="85%" colSpan="3"><asp:radiobutton id="rbDuplicata" runat="server" Checked="True" Text="Duplicata" AutoPostBack="True"
												GroupName="rbTipo" Enabled="False"></asp:radiobutton><asp:radiobutton id="rbBonificacao" runat="server" Text="Bonificação" AutoPostBack="True" GroupName="rbTipo"
												Enabled="False"></asp:radiobutton></TD>
									</TR>
									<TR>
										<TD class="barra3" width="15%">Forma de Pagamento:</TD>
										<TD class="barra1" width="85%" colSpan="3"><asp:dropdownlist id="ddlFormaPagamento" runat="server" Width="200px" AutoPostBack="True">
												<asp:ListItem Value=" " Selected="True"></asp:ListItem>
												<asp:ListItem Value="3">Cheque</asp:ListItem>
												<asp:ListItem Value="8">Ordem Pagamento</asp:ListItem>
												<asp:ListItem Value="9">Bonifica&#231;&#227;o</asp:ListItem>
												<asp:ListItem Value="2">Duplicata</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="barra3" width="15%">Itens:</TD>
										<TD class="barra1" width="85%" colSpan="3"><igtbl:ultrawebgrid id=grdContratos runat="server" Width="100%" UseAccessibleHeader="False" Height="140px" ImageDirectory="/ig_common/Images/" DataSource="<%# dsSelecaoValorAcordoDuplicataNaoRelacionada %>" DataMember="tbSelecaoValorAcordoDuplicataNaoRelacionada">
												<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" RowHeightDefault="20px"
													Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
													HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
													RowSelectorsDefault="No" Name="grdContratos" TableLayout="Fixed">
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
														BorderStyle="Solid" BackColor="Window" Height="140px"></FrameStyle>
													<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
														<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
													</FooterStyleDefault>
													<GroupByBox Hidden="True" Prompt="Arraste uma coluna aqui para efetuar o agrupamento por esta coluna...">
														<Style BorderColor="Window" BackColor="ActiveBorder">
														</Style>
													</GroupByBox>
													<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>
													<RowAlternateStyleDefault CssClass="row1"></RowAlternateStyleDefault>
													<RowStyleDefault BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" BackColor="Window">
														<Padding Left="3px"></Padding>
														<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
													</RowStyleDefault>
												</DisplayLayout>
												<Bands>
													<igtbl:UltraGridBand AddButtonCaption="tbSelecaoValorAcordoDuplicataNaoRelacionada" BaseTableName="tbSelecaoValorAcordoDuplicataNaoRelacionada"
														Key="tbSelecaoValorAcordoDuplicataNaoRelacionada" DataKeyField="DSINDEX">
														<Columns>
															<igtbl:UltraGridColumn Key="" Width="30px" Type="CheckBox" DataType="System.Boolean" BaseColumnName=""
																AllowUpdate="Yes">
																<Footer Key=""></Footer>
																<Header Key=""></Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="CODIGO" Key="CODFRN" IsBound="True" EditorControlID="" Format="" DataType="System.Int32"
																BaseColumnName="CODFRN" FooterText="">
																<Footer Key="CODFRN" Caption="">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CODFRN" Caption="CODIGO">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="FORNECEDOR" Key="NOMFRN" IsBound="True" EditorControlID="" Format=""
																BaseColumnName="NOMFRN" FooterText="">
																<Footer Key="NOMFRN" Caption="">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NOMFRN" Caption="FORNECEDOR">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="VALOR RESIDUAL" Key="" Format="###,###,##0.00" DataType="System.Decimal"
																BaseColumnName="">
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="" Caption="VALOR RESIDUAL">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="VLRRCBPCL" Key="VLRRCBPCL" IsBound="True" EditorControlID="" Hidden="True"
																Format="" DataType="System.Decimal" BaseColumnName="VLRRCBPCL" FooterText="">
																<Footer Key="VLRRCBPCL" Caption="">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="VLRRCBPCL" Caption="VLRRCBPCL">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="CLAUSULA" Key="NUMCSLCTTFRN" IsBound="True" EditorControlID="" Format=""
																DataType="System.Int32" BaseColumnName="NUMCSLCTTFRN" FooterText="">
																<Footer Key="NUMCSLCTTFRN" Caption="">
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NUMCSLCTTFRN" Caption="CLAUSULA">
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DATA REFERENCIA" Key="DATREFAPU" IsBound="True" EditorControlID="" Format="dd/MM/yyyy"
																DataType="System.DateTime" BaseColumnName="DATREFAPU" FooterText="">
																<Footer Key="DATREFAPU" Caption="">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DATREFAPU" Caption="DATA REFERENCIA">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="VALOR APURADO" Key="VLRRCBEFTFXA" IsBound="True" EditorControlID=""
																Format="###,###,##0.00" DataType="System.Decimal" BaseColumnName="VLRRCBEFTFXA" FooterText="">
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="VLRRCBEFTFXA" Caption="">
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="VLRRCBEFTFXA" Caption="VALOR APURADO">
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="CONTRATO" Key="NUMCTTFRN" IsBound="True" EditorControlID="" Format=""
																DataType="System.Int32" BaseColumnName="NUMCTTFRN" FooterText="">
																<Footer Key="NUMCTTFRN" Caption="">
																	<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NUMCTTFRN" Caption="CONTRATO">
																	<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="NOTA FISCAL" Key="NUMNOTFSCFRNCTB" IsBound="True" EditorControlID=""
																Format="" DataType="System.Int32" BaseColumnName="NUMNOTFSCFRNCTB" FooterText="">
																<Footer Key="NUMNOTFSCFRNCTB" Caption="">
																	<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NUMNOTFSCFRNCTB" Caption="NOTA FISCAL">
																	<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="ENTIDADE" Key="DESCTGMER" IsBound="True" EditorControlID="" Format=""
																BaseColumnName="DESCTGMER" FooterText="">
																<Footer Key="DESCTGMER" Caption="">
																	<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DESCTGMER" Caption="ENTIDADE">
																	<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DESCSLCTTFRN" Key="DESCSLCTTFRN" IsBound="True" EditorControlID="" Hidden="True"
																Format="" BaseColumnName="DESCSLCTTFRN" FooterText="">
																<Footer Key="DESCSLCTTFRN" Caption="">
																	<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DESCSLCTTFRN" Caption="DESCSLCTTFRN">
																	<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="TIPPODCTTFRN" Key="TIPPODCTTFRN" IsBound="True" EditorControlID="" Hidden="True"
																Format="" DataType="System.Int32" BaseColumnName="TIPPODCTTFRN" FooterText="">
																<Footer Key="TIPPODCTTFRN" Caption="">
																	<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TIPPODCTTFRN" Caption="TIPPODCTTFRN">
																	<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="NUMREFPOD" Key="NUMREFPOD" IsBound="True" EditorControlID="" Hidden="True"
																Format="" DataType="System.Int32" BaseColumnName="NUMREFPOD" FooterText="">
																<Footer Key="NUMREFPOD" Caption="">
																	<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NUMREFPOD" Caption="NUMREFPOD">
																	<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="TIPEDEABGMIX" Key="TIPEDEABGMIX" IsBound="True" EditorControlID="" Hidden="True"
																Format="" DataType="System.Int32" BaseColumnName="TIPEDEABGMIX" FooterText="">
																<Footer Key="TIPEDEABGMIX" Caption="">
																	<RowLayoutColumnInfo OriginX="14"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TIPEDEABGMIX" Caption="TIPEDEABGMIX">
																	<RowLayoutColumnInfo OriginX="14"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="CODEDEABGMIX" Key="CODEDEABGMIX" IsBound="True" EditorControlID="" Hidden="True"
																Format="" DataType="System.Int32" BaseColumnName="CODEDEABGMIX" FooterText="">
																<Footer Key="CODEDEABGMIX" Caption="">
																	<RowLayoutColumnInfo OriginX="15"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CODEDEABGMIX" Caption="CODEDEABGMIX">
																	<RowLayoutColumnInfo OriginX="15"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="NUMSEQRLCCTTPMS" Key="NUMSEQRLCCTTPMS" IsBound="True" EditorControlID=""
																Hidden="True" Format="" DataType="System.Int32" BaseColumnName="NUMSEQRLCCTTPMS" FooterText="">
																<Footer Key="NUMSEQRLCCTTPMS" Caption="">
																	<RowLayoutColumnInfo OriginX="16"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NUMSEQRLCCTTPMS" Caption="NUMSEQRLCCTTPMS">
																	<RowLayoutColumnInfo OriginX="16"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="TIPDSCPGTFVC" Key="TIPDSCPGTFVC" IsBound="True" EditorControlID="" Hidden="True"
																Format="" DataType="System.Int32" BaseColumnName="TIPDSCPGTFVC" FooterText="">
																<Footer Key="TIPDSCPGTFVC" Caption="">
																	<RowLayoutColumnInfo OriginX="17"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TIPDSCPGTFVC" Caption="TIPDSCPGTFVC">
																	<RowLayoutColumnInfo OriginX="17"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="TIPDSNDSCBNF" Key="TIPDSNDSCBNF" IsBound="True" EditorControlID="" Hidden="True"
																Format="" DataType="System.Int32" BaseColumnName="TIPDSNDSCBNF" FooterText="">
																<Footer Key="TIPDSNDSCBNF" Caption="">
																	<RowLayoutColumnInfo OriginX="18"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TIPDSNDSCBNF" Caption="TIPDSNDSCBNF">
																	<RowLayoutColumnInfo OriginX="18"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DATPRVRCBPMS" Key="DATPRVRCBPMS" IsBound="True" EditorControlID="" Hidden="True"
																Format="" DataType="System.DateTime" BaseColumnName="DATPRVRCBPMS" FooterText="">
																<Footer Key="DATPRVRCBPMS" Caption="">
																	<RowLayoutColumnInfo OriginX="19"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DATPRVRCBPMS" Caption="DATPRVRCBPMS">
																	<RowLayoutColumnInfo OriginX="19"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DSINDEX" Key="DSINDEX" IsBound="True" EditorControlID="" Hidden="True"
																Format="" DataType="System.Int32" BaseColumnName="DSINDEX" FooterText="">
																<Footer Key="DSINDEX" Caption="">
																	<RowLayoutColumnInfo OriginX="20"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DSINDEX" Caption="DSINDEX">
																	<RowLayoutColumnInfo OriginX="20"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
														</Columns>
													</igtbl:UltraGridBand>
												</Bands>
											</igtbl:ultrawebgrid></TD>
									</TR>
									<TR id="trDuplicatas01" runat="server">
										<TD class="barra3" width="15%"></TD>
										<TD class="barra1" width="85%" colSpan="3"></TD>
									</TR>
									<TR id="trDuplicatas02" runat="server">
										<TD class="barra3" width="15%">Fornecedor:</TD>
										<TD class="barra1" width="85%" colSpan="3"><asp:label id="txtFornecedor" runat="server" ForeColor="Black" CssClass=""></asp:label></TD>
									</TR>
									<TR id="trDuplicatas03" runat="server">
										<TD class="barra3" width="15%">Duplicatas:</TD>
										<TD class="barra1" width="85%" colSpan="3"><igtbl:ultrawebgrid id=grdDuplicatas runat="server" Width="100%" UseAccessibleHeader="False" Height="140px" ImageDirectory="/ig_common/Images/" DataSource="<%# dsDuplicatasDisponiveis %>" DataMember="tbDuplicatasDisponiveis">
												<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" RowHeightDefault="20px"
													Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
													HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
													RowSelectorsDefault="No" Name="grdDuplicatas" TableLayout="Fixed" CellClickActionDefault="RowSelect">
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
														BorderColor="InactiveCaption" BorderStyle="Solid" BackColor="Window" Height="140px"></FrameStyle>
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
													<igtbl:UltraGridBand AddButtonCaption="tbDuplicatasDisponiveis" BaseTableName="tbDuplicatasDisponiveis"
														Key="tbDuplicatasDisponiveis">
														<Columns>
															<igtbl:UltraGridColumn Key="" Width="30px" Type="CheckBox" DataType="System.Boolean" BaseColumnName=""
																AllowUpdate="Yes">
																<Footer Key=""></Footer>
																<Header Key=""></Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="COD. EMPRESA" Key="CODEMP" IsBound="True" Hidden="True" DataType="System.Int32"
																BaseColumnName="CODEMP">
																<Footer Key="CODEMP">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CODEMP" Caption="COD. EMPRESA">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="FILIAL" Key="CODFILEMP" IsBound="True" DataType="System.Int32" BaseColumnName="CODFILEMP">
																<Footer Key="CODFILEMP">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CODFILEMP" Caption="FILIAL">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="EMP. FORN" Key="CODEMPFRN" IsBound="True" DataType="System.Int32" BaseColumnName="CODEMPFRN">
																<Footer Key="CODEMPFRN">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CODEMPFRN" Caption="EMP. FORN">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="NOTA FISCAL" Key="NUMNOTFSCFRNCTB" IsBound="True" DataType="System.Int32"
																BaseColumnName="NUMNOTFSCFRNCTB">
																<Footer Key="NUMNOTFSCFRNCTB">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NUMNOTFSCFRNCTB" Caption="NOTA FISCAL">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="SEQ. PARCELA" Key="CODSEQPCLNOTFSC" IsBound="True" BaseColumnName="CODSEQPCLNOTFSC">
																<Footer Key="CODSEQPCLNOTFSC">
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CODSEQPCLNOTFSC" Caption="SEQ. PARCELA">
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="SEQ. TITULO" Key="NUMSEQTITPGT" IsBound="True" DataType="System.Int32"
																BaseColumnName="NUMSEQTITPGT">
																<Footer Key="NUMSEQTITPGT">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NUMSEQTITPGT" Caption="SEQ. TITULO">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DATA PAGAMENTO" Key="DATPGTPCLNOTFSC" IsBound="True" Format="dd/MMyyyy"
																DataType="System.DateTime" BaseColumnName="DATPGTPCLNOTFSC">
																<Footer Key="DATPGTPCLNOTFSC">
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DATPGTPCLNOTFSC" Caption="DATA PAGAMENTO">
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="VALOR" Key="VLRDSP" IsBound="True" Format="###,###,##0.00" DataType="System.Decimal"
																BaseColumnName="VLRDSP">
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="VLRDSP">
																	<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="VLRDSP" Caption="VALOR">
																	<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
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
			<asp:label id="lblErro" runat="server" Font-Size="10px" ForeColor="Red"></asp:label></form>
	</body>
</HTML>
