<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="../AppComponents/wucFornecedor.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EmpenhoFornecedor.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.EmpenhoFornecedor" %>
<%@ Register TagPrefix="uc1" TagName="wucEmpenho" Src="../AppComponents/wucEmpenho.ascx" %>
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
		<LINK href="../../Imagens/Styles.css" type="text/css" rel="stylesheet">
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<script event="onreadystatechange" for="document">
			if (readyState == 'complete'){
				escondeAndamento();
			} else {
				mostraAndamento();			
			}
		</script>
		<SCRIPT language="JavaScript" src="../../Imagens/controle.js" type="text/javascript"></SCRIPT>
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
	window.MM_findObj('trEspera').style.display = 'none';
	window.MM_findObj('tbOpcoes').style.display = 'inline';
	return true;
}

function mostraAndamento() {
	window.MM_findObj('trEspera').style.display = 'inline';
	window.MM_findObj('tbOpcoes').style.display = 'none';
	return true;   
}

function textContar(field,maxlimit) { 
	if (field.value.length > maxlimit) {
		alert('Tamanho máximo de ' + maxlimit + ' caracteres');
		field.value = field.value.substring(0, maxlimit); 
	}
}

function CarregarJanelaSelecionarValores(NUMFLUAPV) {
	escondeAndamento();
	showModalDialog('SelecionarValores.aspx?NUMFLUAPV=' + NUMFLUAPV,'SelecionarValores','dialogWidth:1000px;dialogHeight:570px;center:1;');
	__doPostBack('lkbProcessaCloseModalSelecionarValores','');
}

function CarregarJanelaSelecionarValoresTipoFluxo(NUMFLUAPV, TipoFluxo) {
	escondeAndamento();
	showModalDialog('SelecionarValores.aspx?NUMFLUAPV=' + NUMFLUAPV + '&TipoFluxo=' + TipoFluxo,'SelecionarValores','dialogWidth:1000px;dialogHeight:570px;center:1;');
	__doPostBack('lkbProcessaCloseModalSelecionarValores','');
}

function CarregarJanelaObservacaoAprovacaoFluxo() {
	escondeAndamento();
	showModalDialog('Observacao.aspx?action=aprovacao','SelecionarValores','dialogWidth:450px;dialogHeight:200px;center:1;');
	__doPostBack('lnkFecharTela','');
	//__doPostBack('btnSair','');
}

function CarregarJanelaObservacaoReprovacaoFluxo() {
	escondeAndamento();
	showModalDialog('Observacao.aspx?action=reprovacao','SelecionarValores','dialogWidth:450px;dialogHeight:200px;center:1;');
	__doPostBack('lnkFecharTela','');
	//__doPostBack('btnSair','');
}

//-->
		</script>
		<script language="javascript">
			history.forward();
		</script>
		<LINK href="styles_tabelas.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onload="MM_preloadImages('../../Imagens/lastpost.gif')">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="10" border="0">
				<tr>
					<td><A href="javascript:parent.resizeFrame('5,*')"><IMG id="Image1" onmouseover="MM_swapImage('Image1','','../../Imagens/lastpost.gif',1)"
								onmouseout="MM_swapImage('Image1','','../../Imagens/lastpost_l.gif',1)" height="12" src="../../Imagens/lastpost_l.gif" width="12"
								name="Image1"></A></td>
				</tr>
			</table>
			<table style="WIDTH: 100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tbody>
					<tr>
						<td class="submenu2" vAlign="top">
							<table id="tbOpcoes" cellSpacing="0" cellPadding="0" border="0" runat="server">
								<tr>
									<td id="TDSelecionar" runat="server">
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnPesquisar" style="TEXT-DECORATION: none" runat="server"><IMG height="16" src="../../Imagens/office/janelas.gif" width="16" align="absMiddle"> Selecionar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td id="TDApagarSelecao" runat="server">
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnApagar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
														ToolTip="Apagar as linha selecionadas no grid"><IMG height="16" src="../../Imagens/apagar.gif" width="16" align="absMiddle"> Apagar Sel.</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td id="TDSalvar" runat="server">
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnSalvar" style="TEXT-DECORATION: none" runat="server"><IMG height="16" src="../../Imagens/office/salvar.gif" width="16" align="absMiddle"> Salvar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td id="TDApgar" runat="server">
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnApagarFluxoTransferencia" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
														ToolTip="Apagar Transferencia"><IMG height="16" src="../../Imagens/Office/S_B_CANC.gif" width="16" align="absMiddle"> Excluir</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td id="TDEnviar" runat="server">
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnEnviar" style="TEXT-DECORATION: none" runat="server"><IMG height="16" src="../../Imagens/office/S_B_STEN.gif" width="16" align="absMiddle"> Enviar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<TD id="TDAprovar" runat="server">
										<TABLE class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnAprovar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../../Imagens/Office/S_B_OKAY.gif" width="16" align="absMiddle">
													Aprovar</asp:linkbutton></td>
											</tr>
										</TABLE>
									</TD>
									<td id="TDReprovar" runat="server">
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnReprovar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../../Imagens/delitem.gif" width="16" align="absMiddle"> Rejeitar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td id="TDClonar" runat="server">
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnClonar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../../Imagens/office/S_F_COPY.gif" width="16" align="absMiddle"> Clonar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td id="TDSair" runat="server">
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnSair" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../../Imagens/sair.gif" width="16" align="absMiddle"> Sair</asp:linkbutton></td>
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
									<TR id="trEspera" height="40" runat="server">
										<TD class="barra1" style="HEIGHT: 35px" align="left" width="50%">
											<DIV id="Div2" align="left" runat="server"><asp:image id="Image2" runat="server" ImageUrl="../../Imagens/espera.gif"></asp:image>&nbsp;Carregando...
											</DIV>
										</TD>
										<TD class="barra1" id="TDReserva" align="left" width="50%" runat="server"></TD>
									</TR>
									<TR>
										<TD align="left" width="50%" height="3"></TD>
										<TD align="left" width="50%" height="3"></TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE class="tabela1" id="Table2" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
									<TR>
										<TD class="barra3" width="10%">Numero:
										</TD>
										<TD class="barra1" width="23%" colSpan="3"><igtxt:webnumericedit id="txtNUMFLUAPV" runat="server" ReadOnly="True" Font-Names="Arial" CssClass=" "
												Font-Size="11px" Width="60px"></igtxt:webnumericedit>&nbsp;</TD>
										<TD class="barra3" width="10%">Data:
										</TD>
										<TD class="barra1" width="23%" colSpan="3"><igtxt:webdatetimeedit id="txtDatRefLmt" runat="server" ReadOnly="True" Font-Names="Arial" Font-Size="11px"
												Width="90px"></igtxt:webdatetimeedit></TD>
										<TD class="barra3" width="10%">Status:
										</TD>
										<TD class="barra1" width="24%" colSpan="3"><asp:dropdownlist id="cmbTIPSTAFLUAPV" runat="server" Font-Names="Arial" Font-Size="11px" Enabled="False">
												<asp:ListItem Value="0">NOVA</asp:ListItem>
												<asp:ListItem Value="1">EM APROVA&#199;&#195;O</asp:ListItem>
												<asp:ListItem Value="2">REJEITADO</asp:ListItem>
												<asp:ListItem Value="3">APROVADA</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
									<TR>
										<TD style="WIDTH: 96px" colSpan="4" height="5"></TD>
									</TR>
									<TR>
										<TD class="titlemedium1" style="WIDTH: 96px" colSpan="4" height="20">Origem
										</TD>
									</TR>
									<TR>
										<TD width="100%" colSpan="4" style="HEIGHT: 2px"><asp:linkbutton id="lkbNenhum" runat="server" ForeColor="Black">Nenhum</asp:linkbutton>&nbsp;<asp:linkbutton id="lkbTodas" runat="server" ForeColor="Black">Todos</asp:linkbutton>
											<igtxt:webnumericedit id="ValorTransferir" runat="server" Font-Size="11px" Font-Names="Arial" DataMode="Decimal"
												MinDecimalPlaces="Two">
												<SpinButtons Delay="20000" Delta="0" SpinOnArrowKeys="False"></SpinButtons>
											</igtxt:webnumericedit></TD>
									</TR>
									<TR>
										<TD width="100%" colSpan="4"><igtbl:ultrawebgrid id=grdOrigem runat="server" Width="100%" DataMember="QueryRLCTRNVBAFRN" DataSource="<%# DatasetTransferenciaVerbaFornecedor1 %>" Height="230px" ImageDirectory="/ig_common/Images/">
												<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" TabDirection="TopToBottom"
													RowHeightDefault="21px" Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy"
													AllowColumnMovingDefault="OnServer" HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate"
													AllowColSizingDefault="Free" RowSelectorsDefault="No" Name="grdOrigem" TableLayout="Fixed"
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
													<FrameStyle Width="100%" BorderWidth="1px" Font-Size="11px" Font-Names="Arial" BorderColor="InactiveCaption"
														BorderStyle="Solid" BackColor="Window" Height="230px"></FrameStyle>
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
													<igtbl:UltraGridBand AddButtonCaption="QueryRLCTRNVBAFRN" BaseTableName="QueryRLCTRNVBAFRN" Key="QueryRLCTRNVBAFRN">
														<Columns>
															<igtbl:UltraGridColumn HeaderText="SEL" Key="Sel" Width="25px" Type="CheckBox" DataType="System.Boolean"
																BaseColumnName="Sel" AllowUpdate="Yes">
																<Footer Key="Sel"></Footer>
																<Header Key="Sel" Caption="SEL"></Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="CATEGORIA" Key="DESDIVCMP" IsBound="True" Width="95px" BaseColumnName="DESDIVCMP"
																AllowUpdate="No">
																<Footer Key="DESDIVCMP">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DESDIVCMP" Caption="CATEGORIA">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="COMPRADOR" Key="NOMCPR" IsBound="True" Width="110px" BaseColumnName="NOMCPR"
																AllowUpdate="No">
																<Footer Key="NOMCPR">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NOMCPR" Caption="COMPRADOR">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="CODIGO" Key="CODFRN" IsBound="True" Width="50px" DataType="System.Decimal"
																BaseColumnName="CODFRN" AllowUpdate="No">
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="CODFRN">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
																<Header Key="CODFRN" Caption="CODIGO">
																	<Style HorizontalAlign="Right">
																	</Style>
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="NOME" Key="NOMFRN" IsBound="True" Width="140px" BaseColumnName="NOMFRN"
																AllowUpdate="No">
																<Footer Key="NOMFRN">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NOMFRN" Caption="NOME">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="COD" Key="TIPDSNDSCBNFORITRN" IsBound="True" Width="30px" DataType="System.Decimal"
																BaseColumnName="TIPDSNDSCBNFORITRN" AllowUpdate="No">
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="TIPDSNDSCBNFORITRN">
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
																<Header Key="TIPDSNDSCBNFORITRN" Caption="COD">
																	<Style HorizontalAlign="Right">
																	</Style>
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DESCRI&#199;&#195;O" Key="DESDSNDSCBNF" IsBound="True" Width="120px"
																BaseColumnName="DESDSNDSCBNF" AllowUpdate="No">
																<Footer Key="DESDSNDSCBNF">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DESDSNDSCBNF" Caption="DESCRI&#199;&#195;O">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="ALOCA&#199;&#195;O" Key="DESALCVBAFRN" IsBound="True" Width="70px" Type="DropDownList"
																BaseColumnName="DESALCVBAFRN" AllowUpdate="No">
																<ValueList>
																	<ValueListItems>
																		<igtbl:ValueListItem Key="1" DisplayText="CONTA CORRENTE"></igtbl:ValueListItem>
																		<igtbl:ValueListItem Key="2" DisplayText="MARKETING"></igtbl:ValueListItem>
																	</ValueListItems>
																</ValueList>
																<Footer Key="DESALCVBAFRN">
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DESALCVBAFRN" Caption="ALOCA&#199;&#195;O">
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DISPON&#205;VEL" Key="VlrSldDsp" IsBound="True" EditorControlID="" Width="80px"
																Format="###,###,##0.00" DataType="System.Decimal" BaseColumnName="VlrSldDsp" AllowUpdate="No">
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="VlrSldDsp">
																	<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
																<Header Key="VlrSldDsp" Caption="DISPON&#205;VEL">
																	<Style HorizontalAlign="Right">
																	</Style>
																	<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="TRANSFERIR" Key="VLRLMTCTB" AllowNull="False" IsBound="True" EditorControlID="ValorTransferir"
																Width="80px" AllowGroupBy="No" Type="Custom" Format="R$  ###,###,##0.00" DataType="System.Decimal"
																BaseColumnName="VLRLMTCTB" AllowUpdate="Yes" CellMultiline="No">
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="VLRLMTCTB">
																	<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
																<Header Key="VLRLMTCTB" Caption="TRANSFERIR">
																	<Style HorizontalAlign="Right">
																	</Style>
																	<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="CODCPR" Key="CODCPR" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="CODCPR" AllowUpdate="No">
																<Footer Key="CODCPR">
																	<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CODCPR" Caption="CODCPR">
																	<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="CODDIVCMP" Key="CODDIVCMP" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="CODDIVCMP" AllowUpdate="No">
																<Footer Key="CODDIVCMP">
																	<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CODDIVCMP" Caption="CODDIVCMP">
																	<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn Key="TIPALCVBAFRN" IsBound="True" Hidden="True" DataType="System.Decimal" BaseColumnName="TIPALCVBAFRN">
																<Footer Key="TIPALCVBAFRN">
																	<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TIPALCVBAFRN">
																	<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
														</Columns>
													</igtbl:UltraGridBand>
												</Bands>
											</igtbl:ultrawebgrid></TD>
									</TR>
									<TR>
										<TD width="100%" colSpan="4" height="5"><asp:linkbutton id="lkbProcessaCloseModalSelecionarValores" runat="server"></asp:linkbutton><asp:linkbutton id="lkbRecarregarPagina" runat="server"></asp:linkbutton>
											<asp:LinkButton id="lnkFecharTela" runat="server"></asp:LinkButton></TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE class="tabela1" id="Table3" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TR>
									<TD class="titlemedium1" width="100%" colSpan="8" height="20">Destino</TD>
								<TR>
								</TR>
							</TABLE>
							<TABLE class="tabela1" id="Table4" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TR width="100%">
									<TD class="barra3" width="10%" style="HEIGHT: 26px">Empenho:</TD>
									<TD class="barra1" width="40%" colSpan="3" style="HEIGHT: 26px">
										<igtxt:webnumericedit id="txtTIPDSNDSCBNFDSNTRN" runat="server" Width="60px" Font-Size="11px" CssClass=""
											Font-Names="Arial" AutoPostBack="True" ValueText="0"></igtxt:webnumericedit>
										<asp:dropdownlist id="cmbTIPDSNDSCBNFDSNTRN" runat="server" Width="196px" Font-Size="11px" CssClass=" "
											Font-Names="Arial" Height="19px" AutoPostBack="True"></asp:dropdownlist>
										<asp:TextBox id="txtValorAnteriorDeWucTIPDSNDSCBNFDSNTRN" runat="server" Width="40px" Visible="False"></asp:TextBox></TD>
									<TD class="barra3" width="10%" style="HEIGHT: 26px">Alocação:</TD>
									<TD class="barra1" width="40%" colSpan="3" style="HEIGHT: 26px"><asp:dropdownlist id="cmbTIPALCVBAFRN" runat="server" Font-Names="Arial" Font-Size="11px" Width="120px">
											<asp:ListItem Value="3" Selected="True">CONTA CORRENTE</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR width="100%">
									<TD class="barra3" width="10%">Lançar em:</TD>
									<TD class="barra1" width="40%" colSpan="3"><asp:dropdownlist id="cmbINDMESTRNFLU" runat="server" Font-Names="Arial" Font-Size="11px" Width="120px"></asp:dropdownlist></TD>
									<TD class="barra3" width="10%">Valor:</TD>
									<TD class="barra1" width="40%" colSpan="3">
										<igtxt:WebCurrencyEdit id="txtSomaDeVLRLMTCTB" runat="server" Width="120px" Font-Size="11px" Font-Names="Arial"
											HorizontalAlign="Left"></igtxt:WebCurrencyEdit></TD>
								</TR>
								<TR width="100%">
									<TD class="barra3" width="10%">Justificativa:</TD>
									<TD class="barra1" width="90%" colSpan="7">
										<asp:textbox id="txtDESJSTTRNVBA" runat="server" Width="100%" Font-Size="11px" Font-Names="Arial"
											MaxLength="180" TextMode="MultiLine" Rows="2"></asp:textbox></TD>
								</TR>
								<TR id="TRTipoFluxo" runat="server">
									<TD class="barra3" width="10%">Tipo Fluxo:</TD>
									<TD class="barra1" width="90%" colSpan="7">
										<asp:dropdownlist style="Z-INDEX: 0" id="cmbTipoFluxo" runat="server" Width="120px" Font-Size="11px"
											Font-Names="Arial">
											<asp:ListItem Value="0">Normal</asp:ListItem>
											<asp:ListItem Value="1">Marketing</asp:ListItem>
											<asp:ListItem Value="2">Desonera&#231;&#227;o AGF</asp:ListItem>
											<asp:ListItem Value="3">Resultado AGF</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
							</TABLE>
							<TABLE class="tabela1" id="Table5" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TR>
									<TD width="100%" colSpan="4" height="5"></TD>
								</TR>
								<TR>
									<TD class="titlemedium1" width="100%" colSpan="4" height="20">Fluxos
									</TD>
								</TR>
								<TR>
								</TR>
							</TABLE>
							<igtbl:ultrawebgrid id=grdFluxos runat="server" Width="100%" DataMember="queryFluxos" DataSource="<%# DatasetTransferenciaVerbaFornecedor1 %>" Height="80px" ImageDirectory="/ig_common/Images/">
								<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" RowHeightDefault="20px"
									Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
									HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
									RowSelectorsDefault="No" Name="grdFluxos" TableLayout="Fixed" CellClickActionDefault="RowSelect">
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
										BorderStyle="Solid" BackColor="Window" Height="80px"></FrameStyle>
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
									<igtbl:UltraGridBand AddButtonCaption="queryFluxos" BaseTableName="queryFluxos" Key="queryFluxos" DataKeyField="NUMFLUAPV">
										<Columns>
											<igtbl:UltraGridColumn HeaderText="CODFNC" Key="CODFNC" IsBound="True" Hidden="True" DataType="System.Decimal"
												BaseColumnName="CODFNC">
												<Footer Key="CODFNC"></Footer>
												<Header Key="CODFNC" Caption="CODFNC"></Header>
											</igtbl:UltraGridColumn>
											<igtbl:UltraGridColumn HeaderText="APROVADOR" Key="NOMFNC" IsBound="True" Width="200px" BaseColumnName="NOMFNC">
												<Footer Key="NOMFNC">
													<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
												</Footer>
												<Header Key="NOMFNC" Caption="APROVADOR">
													<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
												</Header>
											</igtbl:UltraGridColumn>
											<igtbl:UltraGridColumn HeaderText="SITUA&#199;&#195;O" Key="DESSTAFLUAPV" IsBound="True" Width="120px"
												BaseColumnName="DESSTAFLUAPV">
												<Footer Key="DESSTAFLUAPV">
													<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
												</Footer>
												<Header Key="DESSTAFLUAPV" Caption="SITUA&#199;&#195;O">
													<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
												</Header>
											</igtbl:UltraGridColumn>
											<igtbl:UltraGridColumn HeaderText="DATA AVALIA&#199;&#195;O" Key="DATHRAAPVFLU" IsBound="True" Width="120px"
												DataType="System.DateTime" BaseColumnName="DATHRAAPVFLU">
												<Footer Key="DATHRAAPVFLU">
													<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
												</Footer>
												<Header Key="DATHRAAPVFLU" Caption="DATA AVALIA&#199;&#195;O">
													<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
												</Header>
											</igtbl:UltraGridColumn>
											<igtbl:UltraGridColumn HeaderText="APROVADOR DELEGADO" Key="NOMFNCDELEGADO" IsBound="True" Width="200px"
												BaseColumnName="NOMFNCDELEGADO">
												<Footer Key="NOMFNCDELEGADO">
													<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
												</Footer>
												<Header Key="NOMFNCDELEGADO" Caption="APROVADOR DELEGADO">
													<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
												</Header>
											</igtbl:UltraGridColumn>
											<igtbl:UltraGridColumn HeaderText="OBSERVA&#199;&#195;O" Key="DESOBSAPV" IsBound="True" Width="500px" BaseColumnName="DESOBSAPV">
												<Footer Key="DESOBSAPV">
													<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
												</Footer>
												<Header Key="DESOBSAPV" Caption="OBSERVA&#199;&#195;O">
													<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
												</Header>
											</igtbl:UltraGridColumn>
										</Columns>
									</igtbl:UltraGridBand>
								</Bands>
							</igtbl:ultrawebgrid></td>
					</tr>
				</tbody>
			</table>
			<asp:label id="lblErro" runat="server" Font-Size="10px" ForeColor="Red"></asp:label></form>
	</body>
</HTML>
