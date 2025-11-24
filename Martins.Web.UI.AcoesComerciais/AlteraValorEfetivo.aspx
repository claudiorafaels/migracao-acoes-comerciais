<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AlteraValorEfetivo.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.AlteraValorEfetivo" %>
<%@ Register TagPrefix="igsch" Namespace="Infragistics.WebUI.WebSchedule" Assembly="Infragistics.WebUI.WebDateChooser.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="AppComponents/wucFornecedor.ascx" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igcmbo" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
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
		<script for="document" event="onreadystatechange">
			if (readyState == 'complete'){
				escondeAndamento();
			} else {
				mostraAndamento();			
			}
		</script>
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

/* Parametros:
Campo -> Campo a ser formatado
Tammax -> Tamanho maximo do numero sem pontuacao
Precision -> número de casas decimais
Teclapres -> tecla pressionada.

Exemplo:
Número = 1.234.567.890.123,50
Como formatar ?
NomeTextbox.Attributes.Add("OnKeyDown", "FormataValorPrecisao(this,15,2,event)")
NomeTextbox.maxLength = 20
*/
function FormataValorPrecisao(campo,tammax,precision,teclapres) {
	var tecla = teclapres.keyCode;
	
	if ((teclapres.shiftKey) || (!( ((tecla >= 46) && (tecla <= 57)) || ((tecla >= 96) && (tecla <= 105)) || ((tecla >= 35) && (tecla <= 40)) || (tecla == 8) || (tecla == 9) )))  {
	window.event.returnValue=false;
	return true;
	}
	vr = campo.value;
	vr = vr.replace( "/", "" );
	vr = vr.replace( "/", "" );
	vr = vr.replace( ",", "" );
	vr = vr.replace( ".", "" );
	vr = vr.replace( ".", "" );
	vr = vr.replace( ".", "" );
	vr = vr.replace( ".", "" );
	tam = vr.length;

	if (tam < tammax && tecla != 8){ tam = vr.length + 1 ; }

	if (tecla == 8 ){	tam = tam - 1 ; }
		
	if ( tecla == 8 || tecla >= 48 && tecla <= 57 || tecla >= 96 && tecla <= 105 ){
		if ( tam <= precision ){ 
	 		campo.value = vr ; }
	 	if ( (tam > precision) && (tam <= (3 + precision)) ){
	 		campo.value = vr.substr( 0, tam - precision ) + ',' + vr.substr( tam - precision, tam ) ; } 	
	 	if ( (tam >= (4 + precision)) && (tam <= (6 + precision)) ){
	 		campo.value = vr.substr( 0, tam - (4 + precision - 1)) + '.' + vr.substr( tam -( 4 + precision - 1), 3 ) + ',' + vr.substr( tam - precision, tam ) ; }
	 	if ( (tam >= (7 + precision)) && (tam <= (9 + precision)) ){
	 		campo.value = vr.substr( 0, tam - (7 + precision - 1) ) + '.' + vr.substr( tam - (7 + precision - 1), 3 ) + '.' + vr.substr( tam - (4 + precision - 1), 3 ) + ',' + vr.substr( tam - precision, tam ) ; }
	 	if ( (tam >= (10 + precision)) && (tam <= (12 + precision)) ){
	 		campo.value = vr.substr( 0, tam - (10 + precision - 1) ) + '.' + vr.substr( tam - (10 + precision - 1), 3 ) + '.' + vr.substr( tam - (7 + precision - 1), 3 ) + '.' + vr.substr( tam - (4 + precision - 1), 3 ) + ',' + vr.substr( tam - precision, tam ) ; }
	 	if ( (tam >= (13 + precision)) && (tam <= (15 + precision)) ){
	 		campo.value = vr.substr( 0, tam - (13 + precision - 1) ) + '.' + vr.substr( tam - (13 + precision - 1), 3 ) + '.' + vr.substr( tam - (10 + precision - 1), 3 ) + '.' + vr.substr( tam - (7 + precision - 1), 3 ) + '.' + vr.substr( tam - (4 + precision - 1), 3 ) + ',' + vr.substr( tam - precision, tam ) ;}
	}
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
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tbody>
					<tr>
						<td class="submenu2" vAlign="top">
							<table cellSpacing="0" cellPadding="0" border="0" id="tbOpcoes" runat="server">
								<tr>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnPesquisar" style="TEXT-DECORATION: none" runat="server"><IMG height="16" src="../Imagens/office/procurar.gif" width="16" align="absMiddle"> Pesquisar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnSalvar" style="TEXT-DECORATION: none" runat="server" Visible="False"><IMG height="16" src="../Imagens/office/salvar.gif" width="16" align="absMiddle"> Alterar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnLimpar" style="TEXT-DECORATION: none" runat="server" Visible="False"><IMG height="16" src="../Imagens/office/novo.gif" width="16" align="absMiddle"> Limpar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<TD>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnCancelar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
														href="Principal.aspx"><IMG height="16" src="../Imagens/office/Sair.gif" width="16" align="absMiddle"> Sair</asp:linkbutton></td>
											</tr>
										</table>
									</TD>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td class="darkbox" style="HEIGHT: 497px" vAlign="top">
							<TABLE class="tabela1" id="Table0" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
									<TR id="trEspera" height="40" runat="server">
										<TD class="barra1" id="TDEspera" align="left" width="50%" runat="server">
											<DIV id="Div2" align="left" runat="server"><asp:image id="Image2" runat="server" ImageUrl="../Imagens/espera.gif"></asp:image>&nbsp;Carregando...
											</DIV>
										</TD>
										<TD class="barra1" id="TDReserva" align="left" width="50%" runat="server"></TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TR>
									<TD class="barra3" align="right" width="10%">Fornecedor:</TD>
									<TD class="barra1" width="90%" colSpan="3"><uc1:wucfornecedor id="ucFornecedor" runat="server"></uc1:wucfornecedor></TD>
								</TR>
								<TR>
									<TD class="barra3" align="right" width="10%">Contrato:</TD>
									<TD class="barra1" width="90%" colSpan="3"><asp:dropdownlist id=DdlContrato runat="server" Width="252px" DataSource="<%# DatasetContrato %>" DataMember="T0124945" DataValueField="NUMCTTFRN" AutoPostBack="True" CssClass="" Font-Size="11px" Font-Names="Arial"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="barra3" align="right" width="10%">Cláusula:</TD>
									<TD class="barra1" width="90%" colSpan="3"><asp:dropdownlist id="ddlClausula" runat="server" Width="252px" DataValueField="NUMCTTFRN" CssClass=""
											Font-Size="11px" Font-Names="Arial"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="barra3" style="HEIGHT: 8px" align="right" width="10%">Tipo Período:</TD>
									<TD class="barra1" style="HEIGHT: 8px" width="90%" colSpan="3"><asp:dropdownlist id="ddlTipoPeriodo" runat="server" Width="252px" CssClass="" Font-Size="11px"
											Font-Names="Arial"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="barra3" align="right" width="10%">Num. Período:</TD>
									<TD class="barra1" width="90%" colSpan="3"><igtxt:webnumericedit id="txtNumPeriodo" runat="server" CssClass="" ReadOnly="True" Font-Size="11px"
											Font-Names="Arial" Width="100px"></igtxt:webnumericedit></TD>
								</TR>
								<asp:panel id="pnlAbrangencia" runat="server" Visible="False">
									<TR>
										<TD class="barra3" align="right" width="10%">Abrangência:</TD>
										<TD class="barra1" width="90%" colSpan="3"><igtxt:webtextedit id="txtAbrangencia" runat="server" Width="100px" CssClass="" Font-Size="11px"
												Font-Names="Arial"></igtxt:webtextedit></TD>
									</TR>
									<TR>
										<TD class="barra3" align="right" width="10%">Entidade:</TD>
										<TD class="barra1" width="90%" colSpan="3"><igtxt:webnumericedit id="txtEntidade" runat="server" CssClass="" Font-Size="11px" Font-Names="Arial"
												Width="100px"></igtxt:webnumericedit></TD>
									</TR>
									<TR>
										<TD class="barra3" align="right" width="10%">Valor Efetivo Desconto:</TD>
										<TD class="barra1" width="90%" colSpan="3">
											<igtxt:WebCurrencyEdit id="txtValorEfetivo" runat="server" Width="100px" CssClass="" Font-Size="11px"
												Font-Names="Arial"></igtxt:WebCurrencyEdit>&nbsp;
											<asp:label id="Label1" runat="server" Visible="False" ForeColor="Black">De</asp:label>&nbsp;&nbsp;
											<igtxt:webdatetimeedit id="txtDataInicio" runat="server" Width="90px" CssClass="" Font-Size="11px"
												Font-Names="Arial"></igtxt:webdatetimeedit>&nbsp;&nbsp;&nbsp;
											<asp:label id="Label2" runat="server" Visible="False" ForeColor="Black">a</asp:label>&nbsp;
											<igtxt:webdatetimeedit id="txtDataFinal" runat="server" Width="90px" CssClass="" Font-Size="11px"
												Font-Names="Arial"></igtxt:webdatetimeedit></TD>
									</TR></TABLE>
							<TABLE class="tabela2" id="Table2" cellSpacing="0" cellPadding="2" width="100%" border="0">
								</asp:panel>
								<TR>
									<TD class="barra1" width="100%" colSpan="4"><igtbl:ultrawebgrid id=gridValor runat="server" Width="100%" DataSource="<%# DatasetContratoXPeriodo %>" DataMember="T0124988" Height="264px" ImageDirectory="/ig_common/Images/" UseAccessibleHeader="False">
											<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" RowHeightDefault="20px"
												Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
												HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
												RowSelectorsDefault="No" Name="gridValor" TableLayout="Fixed">
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
													BorderStyle="Solid" BackColor="Window" Height="264px"></FrameStyle>
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
												<igtbl:UltraGridBand AddButtonCaption="T0124988" BaseTableName="T0124988" Key="T0124988" DataKeyField="NUMCTTFRN,NUMCSLCTTFRN,TIPPODCTTFRN,NUMREFPOD,DATINIPOD">
													<Columns>
														<igtbl:TemplatedColumn Key="" HeaderText="" BaseColumnName="" AllowUpdate="Yes">
															<CellTemplate>
																<asp:LinkButton id="btnEscolher" runat="server">
																		<IMG height="16" src="../Imagens/office/S_B_OKAY.gif" width="16" align="absMiddle">Selecionar</asp:LinkButton>
															</CellTemplate>
															<Footer Key=""></Footer>
															<Header Key="" Caption=""></Header>
														</igtbl:TemplatedColumn>
														<igtbl:UltraGridColumn HeaderText="NUM. CONTRATO" Key="NUMCTTFRN" IsBound="True" Format="#########" DataType="System.Decimal"
															BaseColumnName="NUMCTTFRN">
															<Footer Key="NUMCTTFRN">
																<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="NUMCTTFRN" Caption="NUM. CONTRATO">
																<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="NUM. CLAUSULA" Key="NUMCSLCTTFRN" IsBound="True" Format="#########"
															DataType="System.Decimal" BaseColumnName="NUMCSLCTTFRN">
															<Footer Key="NUMCSLCTTFRN">
																<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="NUMCSLCTTFRN" Caption="NUM. CLAUSULA">
																<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="TIP. PER&#205;ODO" Key="TIPPODCTTFRN" IsBound="True" Format="#########"
															DataType="System.Decimal" BaseColumnName="TIPPODCTTFRN">
															<Footer Key="TIPPODCTTFRN">
																<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="TIPPODCTTFRN" Caption="TIP. PER&#205;ODO">
																<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="NUM PED&#205;ODO" Key="NUMREFPOD" IsBound="True" Format="#########"
															DataType="System.Decimal" BaseColumnName="NUMREFPOD">
															<Footer Key="NUMREFPOD">
																<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="NUMREFPOD" Caption="NUM PED&#205;ODO">
																<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="DATA INICIAL" Key="DATINIPOD" IsBound="True" Format="dd/MM/yyyy" DataType="System.DateTime"
															BaseColumnName="DATINIPOD">
															<Footer Key="DATINIPOD">
																<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="DATINIPOD" Caption="DATA INICIAL">
																<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="DATA FINAL" Key="DATFIMPOD" IsBound="True" Format="dd/MM/yyyy" DataType="System.DateTime"
															BaseColumnName="DATFIMPOD">
															<Footer Key="DATFIMPOD">
																<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="DATFIMPOD" Caption="DATA FINAL">
																<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
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
						</td>
					</tr>
				</tbody>
			</table>
			<asp:label id="lblErro" runat="server" ForeColor="Red" Font-Size="10px"></asp:label></form>
	</body>
</HTML>
