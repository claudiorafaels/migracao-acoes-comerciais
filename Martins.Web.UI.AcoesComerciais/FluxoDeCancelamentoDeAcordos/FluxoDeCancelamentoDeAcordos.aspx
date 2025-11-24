<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="../AppComponents/wucFornecedor.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="FluxoDeCancelamentoDeAcordos.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.FluxoDeCancelamentoDeAcordos" %>
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

function CarregarJanelaSelecionarAcordos() {
	escondeAndamento();
	showModalDialog('SelecionarAcordos.aspx','SelecionarValores','dialogWidth:880px;dialogHeight:520px;center:1;');
	__doPostBack('lkbProcessaCloseModalSelecionarValores','');
}

function CarregarJanelaObservacaoAprovacaoFluxo() {
	escondeAndamento();
	showModalDialog('ObservacaoFluxoCancelamentoAcordo.aspx?action=aprovacao','Aprovar','dialogWidth:450px;dialogHeight:200px;center:1;');
	__doPostBack('lnkFecharTela','');
}

function CarregarJanelaObservacaoReprovacaoFluxo() {
	escondeAndamento();
	showModalDialog('ObservacaoFluxoCancelamentoAcordo.aspx?action=reprovacao','Reprovar','dialogWidth:450px;dialogHeight:200px;center:1;');
	__doPostBack('lnkFecharTela','');
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
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnSelecionar" style="TEXT-DECORATION: none" runat="server"><IMG height="16" src="../../Imagens/office/janelas.gif" width="16" align="absMiddle"> Selecionar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td id="TDApagarSelecao" runat="server">
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnApagar" style="TEXT-DECORATION: none" runat="server" ToolTip="Apagar as linha selecionadas no grid"
														CausesValidation="False"><IMG height="16" src="../../Imagens/apagar.gif" width="16" align="absMiddle"> Apagar Sel.</asp:linkbutton></td>
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
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnApagarFluxoTransferencia" style="TEXT-DECORATION: none" runat="server" ToolTip="Apagar Transferencia"
														CausesValidation="False"><IMG height="16" src="../../Imagens/Office/S_B_CANC.gif" width="16" align="absMiddle"> Excluir</asp:linkbutton></td>
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
										<TD class="barra1" style="HEIGHT: 34px" align="left" width="50%">
											<DIV id="Div2" align="left" runat="server"><asp:image id="Image2" runat="server" ImageUrl="../../Imagens/espera.gif"></asp:image>&nbsp;Carregando...
											</DIV>
										</TD>
										<TD class="barra1" id="TDReserva" style="HEIGHT: 34px" align="left" width="50%" runat="server"></TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE class="tabela1" id="Table2" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
									<TR>
										<TD class="barra3" style="HEIGHT: 24px" width="10%">Número:
										</TD>
										<TD class="barra1" style="HEIGHT: 24px" width="23%" colSpan="3"><igtxt:webnumericedit id="txtNUMPEDCNCACOCMC" runat="server" CssClass=" " ReadOnly="True" Font-Names="Arial"
												Font-Size="11px" Enabled="False" Width="100px"></igtxt:webnumericedit></TD>
										<TD class="barra3" style="HEIGHT: 24px" width="10%">Usuário:
										</TD>
										<TD class="barra1" style="HEIGHT: 24px" width="23%" colSpan="3"><asp:textbox id="txtNOMUSRSIS" runat="server" Font-Names="Arial" Font-Size="11px" Enabled="False"
												Width="100px"></asp:textbox></TD>
										<TD class="barra3" style="HEIGHT: 24px" width="10%">Status:
										</TD>
										<TD class="barra1" style="HEIGHT: 24px" width="24%" colSpan="3"><asp:dropdownlist id="cmbCODSTAAPV" runat="server" Font-Names="Arial" Font-Size="11px" Enabled="False">
												<asp:ListItem Value="0">EM APROVA&#199;&#195;O</asp:ListItem>
												<asp:ListItem Value="1">APROVADO</asp:ListItem>
												<asp:ListItem Value="2">REJEITADO</asp:ListItem>
												<asp:ListItem Value="3">NOVO</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="barra3" style="HEIGHT: 28px" width="10%">Emitida em:</TD>
										<TD class="barra1" style="HEIGHT: 28px" width="23%" colSpan="3"><igtxt:webdatetimeedit id="txtDATGRCCNCACOCMC" runat="server" Font-Names="Arial" Font-Size="11px" Enabled="False"
												Width="100px" HorizontalAlign="Right"></igtxt:webdatetimeedit></TD>
										<TD class="barra3" style="HEIGHT: 28px" width="10%">Rejeitada em:</TD>
										<TD class="barra1" style="HEIGHT: 28px" width="23%" colSpan="3"><igtxt:webdatetimeedit id="txtDATRPVCNCACOCMC" runat="server" Font-Names="Arial" Font-Size="11px" Enabled="False"
												Width="100px" HorizontalAlign="Right"></igtxt:webdatetimeedit></TD>
										<TD class="barra3" style="HEIGHT: 28px" width="10%">Aprovada em:</TD>
										<TD class="barra1" style="HEIGHT: 28px" width="24%" colSpan="3"><igtxt:webdatetimeedit id="txtDATAPVCNCACOCMC" runat="server" Font-Names="Arial" Font-Size="11px" Enabled="False"
												Width="100px" HorizontalAlign="Right"></igtxt:webdatetimeedit></TD>
									</TR>
									<TR>
										<TD class="barra3" style="HEIGHT: 28px" width="10%">Fornecedor:</TD>
										<TD class="barra1" style="HEIGHT: 28px" width="23%" colSpan="11"><uc1:wucfornecedor id="ucFornecedor" runat="server"></uc1:wucfornecedor></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%">Justificativa:</TD>
										<TD class="barra1" width="90%" colSpan="11"><asp:textbox id="txtDESOBSCNCACOCMC" runat="server" Font-Names="Arial" Font-Size="11px" Width="90%"
												MaxLength="180" TextMode="MultiLine" Rows="2"></asp:textbox></TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
									<TR>
										<TD class="titlemedium1" style="WIDTH: 96px" colSpan="4" height="20">Acordos
										</TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 18px" width="100%" colSpan="5"><asp:linkbutton id="lkbTodas" runat="server" ForeColor="Black">Todos</asp:linkbutton>&nbsp;
											<asp:linkbutton id="lkbNenhum" runat="server" ForeColor="Black">Nenhum</asp:linkbutton><igtxt:webnumericedit id="ValorCancelar" runat="server" Font-Names="Arial" Font-Size="11px" MinDecimalPlaces="Two"
												DataMode="Decimal">
												<SpinButtons Delay="20000" Delta="0" SpinOnArrowKeys="False"></SpinButtons>
											</igtxt:webnumericedit></TD>
									</TR>
									<TR>
										<TD width="100%" colSpan="4"><igtbl:ultrawebgrid id=grdAcordo runat="server" Width="864px" DataMember="T0118066Pesquisa" DataSource="<%# DatasetAcordoACancelarEmFluxoCancelamentoAcordo1 %>" Height="128px" ImageDirectory="/ig_common/Images/">
												<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" TabDirection="TopToBottom"
													RowHeightDefault="21px" Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy"
													AllowColumnMovingDefault="OnServer" HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate"
													AllowColSizingDefault="Free" RowSelectorsDefault="No" Name="grdAcordo" TableLayout="Fixed"
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
													<FrameStyle Width="864px" BorderWidth="1px" Font-Size="11px" Font-Names="Arial" BorderColor="InactiveCaption"
														BorderStyle="Solid" BackColor="Window" Height="128px"></FrameStyle>
													<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
														<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
													</FooterStyleDefault>
													<ClientSideEvents AfterCellUpdateHandler="grdAcordoCancelamento_AfterCellUpdateHandler"></ClientSideEvents>
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
													<igtbl:UltraGridBand AddButtonCaption="T0118066Pesquisa" BaseTableName="T0118066Pesquisa" Key="T0118066Pesquisa"
														DataKeyField="NUMPEDCNCACOCMC,CODPMS,CODEMP,CODFILEMP,DATNGCPMS,DATPRVRCBPMS,TIPFRMDSCBNF,TIPDSNDSCBNF">
														<Columns>
															<igtbl:UltraGridColumn HeaderText="SEL" Key="Sel" Width="25px" Type="CheckBox" DataType="System.Boolean"
																BaseColumnName="Sel" AllowUpdate="Yes">
																<Footer Key="Sel"></Footer>
																<Header Key="Sel" Caption="SEL"></Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="N&#250;mero" Key="CODPMS" IsBound="True" Width="60px" DataType="System.Decimal"
																BaseColumnName="CODPMS">
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="CODPMS">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<Header Key="CODPMS" Caption="N&#250;mero">
																	<Style HorizontalAlign="Center">
																	</Style>
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="D.Emiss&#227;o" Key="DATNGCPMS" IsBound="True" Width="80px" Format="dd/MM/yyyy"
																DataType="System.DateTime" BaseColumnName="DATNGCPMS">
																<CellStyle HorizontalAlign="Center"></CellStyle>
																<Footer Key="DATNGCPMS">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<Header Key="DATNGCPMS" Caption="D.Emiss&#227;o">
																	<Style HorizontalAlign="Center">
																	</Style>
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="D.Vencimento" Key="DATPRVRCBPMS" IsBound="True" Width="80px" Format="dd/MM/yyyy"
																DataType="System.DateTime" BaseColumnName="DATPRVRCBPMS">
																<CellStyle HorizontalAlign="Center"></CellStyle>
																<Footer Key="DATPRVRCBPMS">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<Header Key="DATPRVRCBPMS" Caption="D.Vencimento">
																	<Style HorizontalAlign="Center">
																	</Style>
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Empenho" Key="DESDSNDSCBNF" IsBound="True" Width="155px" BaseColumnName="DESDSNDSCBNF">
																<CellStyle HorizontalAlign="Left"></CellStyle>
																<Footer Key="DESDSNDSCBNF">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DESDSNDSCBNF" Caption="Empenho">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Forma de Pagamento" Key="DESFRMDSCBNF" IsBound="True" Width="130px"
																BaseColumnName="DESFRMDSCBNF">
																<CellStyle HorizontalAlign="Left"></CellStyle>
																<Footer Key="DESFRMDSCBNF">
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																<Header Key="DESFRMDSCBNF" Caption="Forma de Pagamento">
																	<Style HorizontalAlign="Left">
																	</Style>
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="D" Key="FLGSITNGCDUP" IsBound="True" Width="20px" BaseColumnName="FLGSITNGCDUP">
																<CellStyle HorizontalAlign="Center"></CellStyle>
																<Footer Key="FLGSITNGCDUP">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<Header Key="FLGSITNGCDUP" Caption="D">
																	<Style HorizontalAlign="Center">
																	</Style>
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Vlr.Negociado" Key="VLRNGCPMS" IsBound="True" Width="80px" Format="###,###,##0.00"
																DataType="System.Decimal" BaseColumnName="VLRNGCPMS" CellMultiline="No">
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="VLRNGCPMS">
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<Header Key="VLRNGCPMS" Caption="Vlr.Negociado">
																	<Style HorizontalAlign="Center">
																	</Style>
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Vlr.Pago" Key="VLRPGOPMS" IsBound="True" Width="80px" Format="###,###,##0.00"
																DataType="System.Decimal" BaseColumnName="VLRPGOPMS" CellMultiline="No">
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="VLRPGOPMS">
																	<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<Header Key="VLRPGOPMS" Caption="Vlr.Pago">
																	<Style HorizontalAlign="Center">
																	</Style>
																	<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Vlr Cancelar" Key="VLRSLDPMSFRN" AllowNull="False" IsBound="True" EditorControlID="ValorCancelar"
																Width="80px" AllowGroupBy="No" Type="Custom" Format="R$  ###,###,##0.00" DataType="System.Decimal"
																BaseColumnName="VLRSLDPMSFRN" AllowUpdate="Yes" CellMultiline="No">
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="VLRSLDPMSFRN">
																	<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<Header Key="VLRSLDPMSFRN" Caption="Vlr Cancelar">
																	<Style HorizontalAlign="Center">
																	</Style>
																	<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn Key="CODEMP" IsBound="True" Hidden="True" DataType="System.Decimal" BaseColumnName="CODEMP">
																<Footer Key="CODEMP">
																	<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CODEMP">
																	<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn Key="CODFILEMP" IsBound="True" Hidden="True" DataType="System.Decimal" BaseColumnName="CODFILEMP">
																<Footer Key="CODFILEMP">
																	<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CODFILEMP">
																	<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn Key="TIPFRMDSCBNF" IsBound="True" Hidden="True" DataType="System.Decimal" BaseColumnName="TIPFRMDSCBNF">
																<Footer Key="TIPFRMDSCBNF">
																	<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TIPFRMDSCBNF">
																	<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn Key="TIPDSNDSCBNF" IsBound="True" Hidden="True" DataType="System.Decimal" BaseColumnName="TIPDSNDSCBNF">
																<Footer Key="TIPDSNDSCBNF">
																	<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TIPDSNDSCBNF">
																	<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn Key="NUMPEDCNCACOCMC" IsBound="True" Hidden="True" DataType="System.Decimal" BaseColumnName="NUMPEDCNCACOCMC">
																<Footer Key="NUMPEDCNCACOCMC">
																	<RowLayoutColumnInfo OriginX="14"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NUMPEDCNCACOCMC">
																	<RowLayoutColumnInfo OriginX="14"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
														</Columns>
													</igtbl:UltraGridBand>
												</Bands>
											</igtbl:ultrawebgrid></TD>
									</TR>
									<TR>
										<TD width="100%" colSpan="4" height="5"><asp:linkbutton id="lkbProcessaCloseModalSelecionarValores" runat="server"></asp:linkbutton><asp:linkbutton id="lkbRecarregarPagina" runat="server"></asp:linkbutton><asp:linkbutton id="lnkFecharTela" runat="server"></asp:linkbutton></TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE class="tabela1" id="Table3" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TR>
								</TR>
							</TABLE>
							<TABLE class="tabela1" id="Table4" cellSpacing="0" cellPadding="2" width="100%" border="0">
							</TABLE>
							<TABLE class="tabela1" id="Table5" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TR>
									<TD class="titlemedium1" width="100%" colSpan="4" height="20">Fluxos
									</TD>
								</TR>
								<TR>
								</TR>
							</TABLE>
							<igtbl:ultrawebgrid id=grdFluxos runat="server" Width="864px" DataMember="queryFluxos" DataSource="<%# DatasetFluxoCancelamentoAcordo1 %>" Height="120px" ImageDirectory="/ig_common/Images/" DESIGNTIMEDRAGDROP="135">
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
									<FrameStyle Width="864px" BorderWidth="1px" Font-Size="11px" Font-Names="Arial" BorderColor="InactiveCaption"
										BorderStyle="Solid" BackColor="Window" Height="120px"></FrameStyle>
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
											<igtbl:UltraGridColumn HeaderText="Aprovador" Key="NOMFNC" IsBound="True" Width="200px" BaseColumnName="NOMFNC">
												<Footer Key="NOMFNC">
													<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
												</Footer>
												<Header Key="NOMFNC" Caption="Aprovador">
													<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
												</Header>
											</igtbl:UltraGridColumn>
											<igtbl:UltraGridColumn HeaderText="Situa&#231;&#227;o" Key="DESSTAFLUAPV" IsBound="True" Width="120px"
												BaseColumnName="DESSTAFLUAPV">
												<Footer Key="DESSTAFLUAPV">
													<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
												</Footer>
												<Header Key="DESSTAFLUAPV" Caption="Situa&#231;&#227;o">
													<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
												</Header>
											</igtbl:UltraGridColumn>
											<igtbl:UltraGridColumn HeaderText="Data Avalia&#231;&#227;o" Key="DATHRAAPVFLU" IsBound="True" Width="120px"
												Format="" DataType="System.DateTime" BaseColumnName="DATHRAAPVFLU">
												<CellStyle HorizontalAlign="Center"></CellStyle>
												<Footer Key="DATHRAAPVFLU">
													<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
												</Footer>
												<Header Key="DATHRAAPVFLU" Caption="Data Avalia&#231;&#227;o">
													<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
												</Header>
											</igtbl:UltraGridColumn>
											<igtbl:UltraGridColumn HeaderText="Aprovador Delegado" Key="NOMFNCDELEGADO" IsBound="True" Width="200px"
												BaseColumnName="NOMFNCDELEGADO">
												<Footer Key="NOMFNCDELEGADO">
													<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
												</Footer>
												<Header Key="NOMFNCDELEGADO" Caption="Aprovador Delegado">
													<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
												</Header>
											</igtbl:UltraGridColumn>
											<igtbl:UltraGridColumn HeaderText="Observa&#231;&#227;o" Key="DESOBSAPV" IsBound="True" Width="500px" BaseColumnName="DESOBSAPV">
												<Footer Key="DESOBSAPV">
													<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
												</Footer>
												<Header Key="DESOBSAPV" Caption="Observa&#231;&#227;o">
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
			<TABLE id="Table6" cellSpacing="0" cellPadding="0" border="0">
				<TR>
					<TD><asp:label id="lblErro" runat="server" Font-Size="10px" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblErroFluxo" runat="server" Font-Size="11px" ForeColor="Red" Visible="False"
							Font-Bold="True">* Acordo já existe em outro fluxo aprovado ou em aprovação</asp:label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
