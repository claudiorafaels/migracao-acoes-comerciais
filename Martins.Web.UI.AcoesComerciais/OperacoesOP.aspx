<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="martinscontrols" Namespace="Martins.Web.UI.Controls" Assembly="Martins.Web.UI.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=e9ed78c287a2fd3c" %>
<%@ Register TagPrefix="igcmbo" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="OperacoesOP.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.OperacoesOP" %>
<%@ Register TagPrefix="igcmbo1" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3" %>
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

function chamaQuebraOp(){
	showModalDialog('OperacoesOpQuebra.aspx','OperacoesOpQuebra','dialogWidth:620px;dialogHeight:420px;center:1;');
	__doPostBack('lkbProcessaCloseModal','');
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
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnPesquisar" style="TEXT-DECORATION: none" runat="server"><img src="../Imagens/office/procurar.gif" width="16" height="16" align="absMiddle">Pesquisar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnLimpar" style="TEXT-DECORATION: none" runat="server"><IMG height="16" src="../Imagens/office/novo.gif" width="16" align="absMiddle"> Limpar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnSalvar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/salvar.gif" width="16" align="absMiddle"> Confirmar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnImprimir" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
														Enabled="False"><IMG height="16" src="../Imagens/office/imprimir.gif" width="16" align="absMiddle">  Imprimir</asp:linkbutton></td>
												<TD><asp:linkbutton id="btnVisualizar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
														Enabled="False"><IMG height="16" src="../Imagens/office/S_F_NXTO.gif" width="16" align="absMiddle">  Exportar</asp:linkbutton></TD>
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
												<TD></TD>
											</tr>
										</table>
									</td>
								</tr>
							</table>
							<asp:linkbutton id="lkbProcessaCloseModal" runat="server"></asp:linkbutton></td>
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
										<TD class="barra3" style="HEIGHT: 30px">Empresa:</TD>
										<TD class="barra1" style="HEIGHT: 30px" colSpan="3"><asp:dropdownlist id="CmbTipIdtEmpAscAcoCmc" runat="server" CssClass="" Width="200px" Height="19px"
												Font-Size="11px" Font-Names="Arial" AutoPostBack="True">
												<asp:ListItem Value="0">MARTINS</asp:ListItem>
												<asp:ListItem Value="1">FARMA SERVICE</asp:ListItem>
												<asp:ListItem Value="2">SMART</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="barra3">Fornecedor:</TD>
										<TD class="barra1" colSpan="3"><igtxt:webnumericedit id="txtCODFRN" runat="server" CssClass="" Width="60px" Font-Size="11px"
												Font-Names="Arial" AutoPostBack="True"></igtxt:webnumericedit><asp:dropdownlist id="cmbNomeFornecedor" runat="server" Visible="False" CssClass="" Width="280px"
												Height="19px" Font-Size="11px" Font-Names="Arial" AutoPostBack="True"></asp:dropdownlist><igtxt:webtextedit id="txtNomeFornecedor" runat="server" CssClass="" Width="280px" Font-Size="11px"
												Font-Names="Arial"></igtxt:webtextedit><asp:linkbutton id="btnBuscarFornecedor" style="TEXT-DECORATION: none" runat="server">
												<img src="../Imagens/office/procurar.gif" width="16" height="16" align="absMiddle"></asp:linkbutton></TD>
									</TR>
									<TR>
										<TD class="barra3" style="HEIGHT: 15px">Status:</TD>
										<TD class="barra1" style="HEIGHT: 15px" colSpan="3"><asp:dropdownlist id="cmbStaOpe" runat="server" CssClass="" Width="100px" Height="19px" Font-Size="11px"
												Font-Names="Arial" AutoPostBack="True">
												<asp:ListItem Value="3" Selected="True">TODOS</asp:ListItem>
												<asp:ListItem Value="1">ABERTO(S)</asp:ListItem>
												<asp:ListItem Value="2">FECHADO(S)</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="barra3" style="HEIGHT: 19px">Origem:</TD>
										<TD class="barra1" style="HEIGHT: 19px" colSpan="3"><asp:dropdownlist id="cmbTipOriOrdPgtFrn" runat="server" CssClass="" Width="100px" Height="19px"
												Font-Size="11px" Font-Names="Arial">
												<asp:ListItem Value="0">TODOS</asp:ListItem>
												<asp:ListItem Value="1">MANUAL</asp:ListItem>
												<asp:ListItem Value="2">AUTOM&#193;TICO</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="barra3">Período Emissão:</TD>
										<TD class="barra1" colSpan="3"><igtxt:webdatetimeedit id="txtDatRcbOrdPgtInicial" runat="server" CssClass="" Width="100px" Height="19px"
												Font-Size="11px" Font-Names="Arial"></igtxt:webdatetimeedit>&nbsp;A
											<igtxt:webdatetimeedit id="txtDatRcbOrdPgtFinal" runat="server" CssClass="" Width="100px" Height="19px"
												Font-Size="11px" Font-Names="Arial"></igtxt:webdatetimeedit></TD>
									</TR>
									<TR>
										<TD class="barra3" style="HEIGHT: 26px">Período Baixa:</TD>
										<TD class="barra1" style="HEIGHT: 26px" colSpan="3"><igtxt:webdatetimeedit id="txtDatUltPmsOrdInicial" runat="server" CssClass="" Width="100px" Height="19px"
												Font-Size="11px" Font-Names="Arial"></igtxt:webdatetimeedit>&nbsp;A
											<igtxt:webdatetimeedit id="txtDatUltPmsOrdFinal" runat="server" CssClass="" Width="100px" Height="19px"
												Font-Size="11px" Font-Names="Arial"></igtxt:webdatetimeedit></TD>
									</TR>
									<TR>
										<TD class="barra3">O.P Original:</TD>
										<TD class="barra1" colSpan="3"><igtxt:webnumericedit id="txtOpOriginal" runat="server" CssClass="" Width="100px" Height="19px"
												Font-Size="11px" Font-Names="Arial"></igtxt:webnumericedit></TD>
									</TR>
									<TR>
										<TD class="barra3">Operações:</TD>
										<TD class="barra1" colSpan="3"><igtbl:ultrawebgrid id=dGridItens runat="server" Width="100%" Height="125px" Browser="Xml" ImageDirectory="/ig_common/Images/" DataSource="<%# DatasetOperacaoBaixaOperacaoFornecedor_1 %>" DataMember="TbRetorno1">
												<DisplayLayout UseFixedHeaders="True" StationaryMargins="Header" AllowSortingDefault="OnClient"
													RowHeightDefault="20px" Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy"
													AllowColumnMovingDefault="OnServer" HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate"
													AllowColSizingDefault="Free" RowSelectorsDefault="No" Name="dGridItens" TableLayout="Fixed"
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
													<HeaderStyleDefault Font-Size="11px" Font-Names="Arial" BorderStyle="Solid" HorizontalAlign="Left" BackColor="LightGray">
														<BorderDetails ColorTop="White" ColorLeft="White"></BorderDetails>
													</HeaderStyleDefault>
													<GroupByRowStyleDefault BorderColor="Window" BackColor="Control"></GroupByRowStyleDefault>
													<RowSelectorStyleDefault BorderStyle="None" ForeColor="HighlightText" BackColor="Highlight"></RowSelectorStyleDefault>
													<FrameStyle Width="100%" BorderWidth="1px" Font-Size="11px" Font-Names="Arial" BorderColor="InactiveCaption"
														BorderStyle="Solid" BackColor="Window" Height="125px"></FrameStyle>
													<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
														<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
													</FooterStyleDefault>
													<GroupByBox Hidden="True">
														<Style BorderColor="Window" BackColor="ActiveBorder">
														</Style>
													</GroupByBox>
													<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>
													<SelectedRowStyleDefault ForeColor="HighlightText" BackColor="Highlight"></SelectedRowStyleDefault>
													<RowStyleDefault BorderWidth="1px" Font-Size="11px" Font-Names="Arial" BorderColor="Silver" BorderStyle="Solid"
														BackColor="Window">
														<Padding Left="3px"></Padding>
														<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
													</RowStyleDefault>
													<FixedCellStyleDefault VerticalAlign="Top" Wrap="True"></FixedCellStyleDefault>
												</DisplayLayout>
												<Bands>
													<igtbl:UltraGridBand AddButtonCaption="TbRetorno1" BaseTableName="TbRetorno1" Key="TbRetorno1">
														<Columns>
															<igtbl:UltraGridColumn HeaderText="COD" Key="" Width="50px" BaseColumnName="CodFrn">
																<Footer Key=""></Footer>
																<Header Key="" Caption="COD"></Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="FORNECEDOR" Key="" Width="200px" BaseColumnName="NomFrn">
																<CellStyle HorizontalAlign="Left"></CellStyle>
																<Footer Key="">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="" Caption="FORNECEDOR">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DES.HIST.DEPOS.IDENT." Key="" Width="200px" BaseColumnName="DesHstDpsIdtFrn">
																<CellStyle HorizontalAlign="Left"></CellStyle>
																<Footer Key="">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="" Caption="DES.HIST.DEPOS.IDENT.">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DTA RECEB." Key="" Width="70px" Format="dd/MMyyyy" BaseColumnName="DatRcbOrdPgt">
																<CellStyle HorizontalAlign="Left"></CellStyle>
																<Footer Key="">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="" Caption="DTA RECEB.">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="VALOR O.P." Key="VlrOrdPgt" Width="100px" Format="###,###,##0.00" DataType="System.Decimal"
																BaseColumnName="VlrOrdPgt">
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="VlrOrdPgt">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="VlrOrdPgt" Caption="VALOR O.P.">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="OP" Key="" Width="80px" BaseColumnName="NumOrdPgtFrn">
																<CellStyle HorizontalAlign="Left"></CellStyle>
																<Footer Key="">
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="" Caption="OP">
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="BCO" Key="" Width="40px" BaseColumnName="CodBco">
																<CellStyle HorizontalAlign="Left"></CellStyle>
																<Footer Key="">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="" Caption="BCO">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="AG." Key="" Width="40px" BaseColumnName="CodAge" FooterText="">
																<CellStyle HorizontalAlign="Left"></CellStyle>
																<Footer Key="" Caption="">
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="" Caption="AG.">
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DTA BAIXA" Key="" Width="70px" Format="dd/MM/yyyy" BaseColumnName="DatUltPmsOrd">
																<CellStyle HorizontalAlign="Left"></CellStyle>
																<Footer Key="">
																	<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="" Caption="DTA BAIXA">
																	<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:TemplatedColumn Key="" Width="100px" HeaderText="ORIGEM" BaseColumnName="TipOriOrdPgtFrn">
																<CellStyle HorizontalAlign="Center"></CellStyle>
																<CellTemplate>
																	<asp:Label id=Label1 runat="server" Text='<%# IIf(Container.Text="1","1- MANUAL", "2- AUTOMÁTICO") %>'>
																	</asp:Label>
																</CellTemplate>
																<Footer Key="">
																	<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<Header Key="" Caption="ORIGEM">
																	<Style HorizontalAlign="Center">
																	</Style>
																	<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																</Header>
															</igtbl:TemplatedColumn>
															<igtbl:UltraGridColumn HeaderText="OPERA&#199;&#195;O" Key="" Width="100px" BaseColumnName="DesTipOpeBxaOrdPgt">
																<CellStyle HorizontalAlign="Left"></CellStyle>
																<Footer Key="">
																	<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="" Caption="OPERA&#199;&#195;O">
																	<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:TemplatedColumn Key="" Width="60px" HeaderText="SITUA&#199;&#195;O" BaseColumnName="DatUltPmsOrd">
																<CellStyle HorizontalAlign="Left"></CellStyle>
																<CellTemplate>
																	<asp:Label id=Label2 runat="server" Text="<%# verificaSituacao(Container.Text) %>">
																	</asp:Label>
																</CellTemplate>
																<Footer Key="">
																	<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="" Caption="SITUA&#199;&#195;O">
																	<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																</Header>
															</igtbl:TemplatedColumn>
															<igtbl:UltraGridColumn HeaderText="USU&#193;RIO OPER." Key="" Width="90px" BaseColumnName="NomAcsUsrBxaOrdPgt">
																<CellStyle HorizontalAlign="Left"></CellStyle>
																<Footer Key="">
																	<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="" Caption="USU&#193;RIO OPER.">
																	<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="O.P.ORIGINAL" Key="" Width="100px" BaseColumnName="NumOrdPgtOriFrn">
																<CellStyle HorizontalAlign="Left"></CellStyle>
																<Footer Key="">
																	<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="" Caption="O.P.ORIGINAL">
																	<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="NumOrdPgtFrn" Key="NumOrdPgtFrn" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="NumOrdPgtFrn">
																<Footer Key="NumOrdPgtFrn">
																	<RowLayoutColumnInfo OriginX="14"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NumOrdPgtFrn" Caption="NumOrdPgtFrn">
																	<RowLayoutColumnInfo OriginX="14"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="CodBco" Key="CodBco" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="CodBco">
																<Footer Key="CodBco">
																	<RowLayoutColumnInfo OriginX="15"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CodBco" Caption="CodBco">
																	<RowLayoutColumnInfo OriginX="15"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="CodAge" Key="CodAge" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="CodAge">
																<Footer Key="CodAge">
																	<RowLayoutColumnInfo OriginX="16"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CodAge" Caption="CodAge">
																	<RowLayoutColumnInfo OriginX="16"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DatRcbOrdPgt" Key="DatRcbOrdPgt" IsBound="True" Hidden="True" BaseColumnName="DatRcbOrdPgt">
																<Footer Key="DatRcbOrdPgt">
																	<RowLayoutColumnInfo OriginX="17"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DatRcbOrdPgt" Caption="DatRcbOrdPgt">
																	<RowLayoutColumnInfo OriginX="17"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="CodFrn" Key="CodFrn" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="CodFrn">
																<Footer Key="CodFrn">
																	<RowLayoutColumnInfo OriginX="18"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CodFrn" Caption="CodFrn">
																	<RowLayoutColumnInfo OriginX="18"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="NomFrn" Key="NomFrn" IsBound="True" Hidden="True" BaseColumnName="NomFrn">
																<Footer Key="NomFrn">
																	<RowLayoutColumnInfo OriginX="19"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NomFrn" Caption="NomFrn">
																	<RowLayoutColumnInfo OriginX="19"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="VlrOrdPgt" Key="VlrOrdPgt" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="VlrOrdPgt">
																<Footer Key="VlrOrdPgt">
																	<RowLayoutColumnInfo OriginX="20"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="VlrOrdPgt" Caption="VlrOrdPgt">
																	<RowLayoutColumnInfo OriginX="20"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DatUltPmsOrd" Key="DatUltPmsOrd" IsBound="True" Hidden="True" BaseColumnName="DatUltPmsOrd">
																<Footer Key="DatUltPmsOrd">
																	<RowLayoutColumnInfo OriginX="21"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DatUltPmsOrd" Caption="DatUltPmsOrd">
																	<RowLayoutColumnInfo OriginX="21"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DatRcbCreOrd" Key="DatRcbCreOrd" IsBound="True" Hidden="True" BaseColumnName="DatRcbCreOrd">
																<Footer Key="DatRcbCreOrd">
																	<RowLayoutColumnInfo OriginX="22"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DatRcbCreOrd" Caption="DatRcbCreOrd">
																	<RowLayoutColumnInfo OriginX="22"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="NomAcsUsrSis" Key="NomAcsUsrSis" IsBound="True" Hidden="True" BaseColumnName="NomAcsUsrSis">
																<Footer Key="NomAcsUsrSis">
																	<RowLayoutColumnInfo OriginX="23"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NomAcsUsrSis" Caption="NomAcsUsrSis">
																	<RowLayoutColumnInfo OriginX="23"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="TipOriOrdPgtFrn" Key="TipOriOrdPgtFrn" IsBound="True" Hidden="True"
																DataType="System.Decimal" BaseColumnName="TipOriOrdPgtFrn">
																<Footer Key="TipOriOrdPgtFrn">
																	<RowLayoutColumnInfo OriginX="24"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TipOriOrdPgtFrn" Caption="TipOriOrdPgtFrn">
																	<RowLayoutColumnInfo OriginX="24"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="TipOpeBxaOrdPgtFrn" Key="TipOpeBxaOrdPgtFrn" IsBound="True" Hidden="True"
																DataType="System.Decimal" BaseColumnName="TipOpeBxaOrdPgtFrn">
																<Footer Key="TipOpeBxaOrdPgtFrn">
																	<RowLayoutColumnInfo OriginX="25"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TipOpeBxaOrdPgtFrn" Caption="TipOpeBxaOrdPgtFrn">
																	<RowLayoutColumnInfo OriginX="25"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DesTipOpeBxaOrdPgt" Key="DesTipOpeBxaOrdPgt" IsBound="True" Hidden="True"
																BaseColumnName="DesTipOpeBxaOrdPgt">
																<Footer Key="DesTipOpeBxaOrdPgt">
																	<RowLayoutColumnInfo OriginX="26"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DesTipOpeBxaOrdPgt" Caption="DesTipOpeBxaOrdPgt">
																	<RowLayoutColumnInfo OriginX="26"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="NumOrdPgtOriFrn" Key="NumOrdPgtOriFrn" IsBound="True" Hidden="True"
																DataType="System.Decimal" BaseColumnName="NumOrdPgtOriFrn">
																<Footer Key="NumOrdPgtOriFrn">
																	<RowLayoutColumnInfo OriginX="27"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NumOrdPgtOriFrn" Caption="NumOrdPgtOriFrn">
																	<RowLayoutColumnInfo OriginX="27"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DatTrnOrdPgtFrn" Key="DatTrnOrdPgtFrn" IsBound="True" Hidden="True"
																BaseColumnName="DatTrnOrdPgtFrn">
																<Footer Key="DatTrnOrdPgtFrn">
																	<RowLayoutColumnInfo OriginX="28"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DatTrnOrdPgtFrn" Caption="DatTrnOrdPgtFrn">
																	<RowLayoutColumnInfo OriginX="28"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DesHstDpsIdtFrn" Key="DesHstDpsIdtFrn" IsBound="True" Hidden="True"
																BaseColumnName="DesHstDpsIdtFrn">
																<Footer Key="DesHstDpsIdtFrn">
																	<RowLayoutColumnInfo OriginX="29"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DesHstDpsIdtFrn" Caption="DesHstDpsIdtFrn">
																	<RowLayoutColumnInfo OriginX="29"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="NomAcsUsrBxaOrdPgt" Key="NomAcsUsrBxaOrdPgt" IsBound="True" Hidden="True"
																BaseColumnName="NomAcsUsrBxaOrdPgt">
																<Footer Key="NomAcsUsrBxaOrdPgt">
																	<RowLayoutColumnInfo OriginX="30"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NomAcsUsrBxaOrdPgt" Caption="NomAcsUsrBxaOrdPgt">
																	<RowLayoutColumnInfo OriginX="30"></RowLayoutColumnInfo>
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
										<TD class="barra3"></TD>
										<TD class="barra1" colSpan="3">
											<P>&nbsp;</P>
										</TD>
									</TR>
									<TR>
										<TD class="barra3" style="HEIGHT: 30px">Operação de Baixa:</TD>
										<TD class="barra1" style="HEIGHT: 30px" colSpan="3"><asp:dropdownlist id="cmbTipoOperacaoBaixa" runat="server" CssClass="" Width="200px" Height="19px"
												Font-Size="11px" Font-Names="Arial" AutoPostBack="True"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="barra3" style="HEIGHT: 26px">Total de O.P:</TD>
										<TD class="barra1" style="HEIGHT: 26px" colSpan="3"><igtxt:webnumericedit id="txtTotOP" runat="server" CssClass="" Width="100px" DataMode="Int" ReadOnly="True"></igtxt:webnumericedit></TD>
									</TR>
									<TR>
										<TD class="barra3">Total Valor O.P:</TD>
										<TD class="barra1" colSpan="3"><igtxt:webcurrencyedit id="txtTotVlrOP" runat="server" Enabled="False" CssClass="" Width="100px"
												Height="19px" Font-Size="11px" Font-Names="Arial" ReadOnly="True"></igtxt:webcurrencyedit></TD>
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
