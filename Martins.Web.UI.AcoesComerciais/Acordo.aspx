<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Acordo.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.Acordo" %>
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
		<SCRIPT language="JavaScript" src="../Imagens/controle.js" type="text/javascript"></SCRIPT>
		<script event="onreadystatechange" for="document">
			if (readyState == 'complete'){
				escondeAndamento();
			} else {
				mostraAndamento();			
			}
		</script>
		<script language="javascript">
			history.forward();
		</script>
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

function CliqueSalvar(obj){
if(!obj.disabled){
mostraAndamento();
}
}


//function popup(){
//window.open('VerbaCarimbo.aspx','Verba Carimbo','width=350px,height=350px');
//return false;




//-->
		</script>
		<LINK href="styles_tabelas.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onload="MM_preloadImages('../Imagens/lastpost.gif')" XMLNS:igtbl="http://schemas.infragistics.com/ASPNET/WebControls/UltraWebGrid">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="10" border="0">
				<tr>
					<td><A href="javascript:parent.resizeFrame('5,*')"><IMG id="Image1" onmouseover="MM_swapImage('Image1','','../Imagens/lastpost.gif',1)"
								onmouseout="MM_swapImage('Image1','','../Imagens/lastpost_l.gif',1)" height="12" src="../Imagens/lastpost_l.gif" width="12"
								name="Image1"></A></td>
				</tr>
			</table>
			<table style="HEIGHT: 510px" height="510" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<tbody>
					<tr>
						<td class="submenu2" vAlign="top">
							<table id="tbOpcoes" cellSpacing="0" cellPadding="0" border="0" runat="server">
								<tr>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<TD><asp:linkbutton id="btnNovo" style="TEXT-DECORATION: none" runat="server"><img src="../Imagens/office/novo.gif" width="16" height="16" align="absMiddle">Novo</asp:linkbutton></TD>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnSalvar" style="TEXT-DECORATION: none" runat="server"><IMG height="16" src="../Imagens/office/salvar.gif" width="16" align="absMiddle"> Salvar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnCancelar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/Sair.gif" width="16" align="absMiddle"> Sair</asp:linkbutton></td>
											</TR>
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
									<TD></TD>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="cmdCancelarAcordo" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
														ToolTip="Alterar a situação do acordo para cancelada"><IMG height="16" src="../Imagens/office/S_B_CANC.gif" width="16" align="absMiddle">  Cancelar Acordo</asp:linkbutton></td>
												<TD><asp:linkbutton id="btnImprimir" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/imprimir.gif" width="16" align="absMiddle">  Imprimir</asp:linkbutton></TD>
												<TD><asp:linkbutton id="btnVisualizar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/S_F_NXTO.gif" width="16" align="absMiddle">  Exportar</asp:linkbutton></TD>
												<TD></TD>
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
										<TD class="barra1" style="HEIGHT: 35px" align="left" width="50%">
											<DIV id="Div2" align="left" runat="server"><asp:image id="Image2" runat="server" ImageUrl="../Imagens/espera.gif"></asp:image>&nbsp;Carregando...
											</DIV>
										</TD>
										<TD class="barra1" id="TDReserva" align="left" width="50%" runat="server"></TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
									<TR>
										<TD class="barra3" width="10%">Filial:</TD>
										<TD class="barra1" width="45%"><asp:dropdownlist id="cmbCODFILEMP" runat="server" AutoPostBack="True" Font-Names="Arial" Font-Size="11px"
												Height="19px" Width="250px" CssClass=""></asp:dropdownlist></TD>
										<TD class="barra3" width="10%">Acordo:</TD>
										<TD class="barra1" width="30%"><igtxt:webnumericedit id="txtCODPMS" runat="server" Font-Names="Arial" Font-Size="11px" Width="100px"
												CssClass="" ReadOnly="True"></igtxt:webnumericedit></TD>
									<TR>
										<TD class="barra3" width="10%">Data Negociação:</TD>
										<TD class="barra1" width="45%"><igtxt:webdatetimeedit id="txtDATNGCPMS" runat="server" Font-Names="Arial" Font-Size="11px" Height="19px"
												Width="100px" CssClass="" ReadOnly="True" PromptChar=" "></igtxt:webdatetimeedit></TD>
										<TD class="barra3" width="10%">Pedido:</TD>
										<TD class="barra1" width="30%"><igtxt:webtextedit id="txtNUMPEDCMP" runat="server" Font-Names="Arial" Font-Size="11px" Height="19px"
												Width="100px" CssClass="" ReadOnly="True"></igtxt:webtextedit></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%">Situação:</TD>
										<TD class="barra1" width="45%"><asp:dropdownlist id="cmbCODSITPMS" runat="server" Font-Names="Arial" Font-Size="11px" Height="19px"
												Width="250px" CssClass="" Enabled="False"></asp:dropdownlist></TD>
										<TD class="barra3" width="10%">Usuário:</TD>
										<TD class="barra1" width="30%"><igtxt:webtextedit id="txtNOMACSUSRSIS" runat="server" Font-Names="Arial" Font-Size="11px" Height="19px"
												Width="100px" CssClass="" ReadOnly="True"></igtxt:webtextedit></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%" style="HEIGHT: 41px"><asp:dropdownlist id="ddl2" runat="server" AutoPostBack="True" Font-Names="Arial" Font-Size="11px"
												Height="19px" Width="0px" CssClass=" "></asp:dropdownlist>Fornecedor:</TD>
										<TD class="barra1" width="45%" style="HEIGHT: 41px"><igtxt:webnumericedit id="txtCODFRN" runat="server" AutoPostBack="True" Font-Names="Arial" Font-Size="11px"
												Width="60px" CssClass=""></igtxt:webnumericedit><asp:dropdownlist id="cmbNomeFornecedor" runat="server" Visible="False" AutoPostBack="True" Font-Names="Arial"
												Font-Size="11px" Height="19px" Width="280px" CssClass=""></asp:dropdownlist><igtxt:webtextedit id="txtNomeFornecedor" runat="server" Font-Names="Arial" Font-Size="11px" Width="280px"
												CssClass=""></igtxt:webtextedit><asp:linkbutton id="btnBuscarFornecedor" style="TEXT-DECORATION: none" runat="server">
												<img src="../Imagens/office/procurar.gif" width="16" height="16" align="absMiddle"></asp:linkbutton></TD>
										<TD class="barra3" width="10%" style="HEIGHT: 41px">Tipo Fornecedor:</TD>
										<TD class="barra1" width="30%" style="HEIGHT: 47px"><igtxt:webtextedit id="txtTipoFornecedor" runat="server" Font-Names="Arial" Font-Size="11px" Height="19px"
												Width="100px" CssClass="" ReadOnly="True"></igtxt:webtextedit></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%"><asp:dropdownlist id="ddl1" runat="server" AutoPostBack="True" Font-Names="Arial" Font-Size="11px"
												Height="19px" Width="0px" CssClass=" "></asp:dropdownlist>Nome Contato:</TD>
										<TD class="barra1" width="45%"><igtxt:webtextedit id="txtNOMCTOFRN" runat="server" Font-Names="Arial" Font-Size="11px" Height="19px"
												Width="250px" CssClass="" MaxLength="25"></igtxt:webtextedit></TD>
										<TD class="barra3" width="10%">Tel. Contato:</TD>
										<TD class="barra1" width="30%"><igtxt:webtextedit id="txtNUMTLFCTOFRN" runat="server" Font-Names="Arial" Font-Size="11px" Height="19px"
												Width="100px" CssClass="" MaxLength="40"></igtxt:webtextedit></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%">Cargo:</TD>
										<TD class="barra1" width="45%"><igtxt:webtextedit id="txtDESCGRCTOFRN" runat="server" Font-Names="Arial" Font-Size="11px" Height="19px"
												Width="150px" CssClass="" MaxLength="25"></igtxt:webtextedit></TD>
										<TD class="barra3" width="10%">Valor Total:</TD>
										<TD class="barra1" width="30%"><igtxt:webcurrencyedit id="txtValorTotal" runat="server" Font-Names="Arial" Font-Size="11px" Width="100px"
												CssClass="" ReadOnly="True"></igtxt:webcurrencyedit></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%">Comentários:</TD>
										<TD class="barra1" width="45%"><igtxt:webtextedit id="txtDESMSGUSR" runat="server" Font-Names="Arial" Font-Size="11px" Width="100%"
												CssClass="" MaxLength="255"></igtxt:webtextedit></TD>
										<TD class="barra1" width="10%"></TD>
										<TD class="barra1" width="30%"></TD>
									</TR>
									<TR>
										<TD class="barra1" width="10%"></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%">Opções:</TD>
										<TD width="85%" colSpan="3"><asp:linkbutton id="btnInserir" style="TEXT-DECORATION: none" runat="server"><img src="../Imagens/office/novo.gif" width="16" height="16" align="absMiddle">Novo Recebimento</asp:linkbutton>&nbsp;
											<asp:linkbutton id="btnSalvarRecebimento" style="TEXT-DECORATION: none" runat="server"><IMG height="16" src="../Imagens/office/S_B_OKAY.gif" width="16" align="absMiddle"> Incluir Recebimento</asp:linkbutton>&nbsp;</TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%">Data Negociação:</TD>
										<TD class="barra1" width="45%"><igtxt:webdatetimeedit id="txtDATNGCPMSItem" runat="server" Font-Names="Arial" Font-Size="11px" Height="19px"
												Width="100px" CssClass="" ReadOnly="True" PromptChar=" "></igtxt:webdatetimeedit></TD>
										<TD class="barra3" width="10%">Valor Verba:</TD>
										<TD class="barra1" width="30%"><igtxt:webcurrencyedit id="txtVLRNGCPMS" runat="server" Font-Names="Arial" Font-Size="11px" Height="19px"
												Width="100px" CssClass="" HorizontalAlign="Left"></igtxt:webcurrencyedit><asp:linkbutton id="btnAlterarVerbaCarimbo" style="TEXT-DECORATION: none" runat="server"><IMG height="16" src="../Imagens/office/S_B_OKAY.gif" width="16" align="absMiddle"> Alterar Verba Carimbo</asp:linkbutton>&nbsp;</TD>
						</td>
					</tr>
					<TR>
						<TD class="barra3" width="10%">Forma Recebimento:</TD>
						<TD class="barra1" width="45%"><asp:dropdownlist id="cmbTIPFRMDSCBNF" runat="server" Font-Names="Arial" Font-Size="11px" Height="19px"
								Width="250px" CssClass=""></asp:dropdownlist></TD>
						<TD class="barra3" width="10%">Previsão Vencimento:</TD>
						<TD class="barra1" width="30%"><igtxt:webdatetimeedit id="txtDATPRVRCBPMS" runat="server" Font-Names="Arial" Font-Size="11px" Height="19px"
								Width="100px" CssClass="" PromptChar=" "></igtxt:webdatetimeedit></TD>
					</TR>
					<TR>
						<TD class="barra3" width="10%">Destino Verba:</TD>
						<TD class="barra1" width="45%"><asp:dropdownlist id="cmbTIPDSNDSCBNF" runat="server" Font-Names="Arial" Font-Size="11px" Height="19px"
								Width="250px" CssClass=""></asp:dropdownlist></TD>
						<TD class="barra1" width="10%"></TD>
						<TD class="barra1" width="30%"></TD>
					</TR>
				</tbody>
			</table>
			<br>
			<asp:datagrid id=dGridRecebimentos runat="server" Font-Size="X-Small" Width="100%" CssClass=" " PageSize="5" AllowPaging="True" AutoGenerateColumns="False" DataMember="T0118066" DataSource="<%# DatasetAcordo1 %>">
				<AlternatingItemStyle CssClass="row4"></AlternatingItemStyle>
				<ItemStyle CssClass="row3"></ItemStyle>
				<HeaderStyle CssClass="header1"></HeaderStyle>
				<Columns>
					<asp:TemplateColumn>
						<HeaderStyle Width="10px"></HeaderStyle>
						<ItemTemplate>
							<asp:ImageButton id="imbExcluir" runat="server" CommandName="grdExcluir" ImageUrl="../Imagens/office/apagar.gif"></asp:ImageButton>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="DATNGCPMS" SortExpression="DATNGCPMS" HeaderText="Data Negocia&#231;&#227;o"
						DataFormatString="{0:dd/MM/yyyy}">
						<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="DATPRVRCBPMS" SortExpression="DATPRVRCBPMS" HeaderText="Data Recebimento"
						DataFormatString="{0:dd/MM/yyyy}">
						<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="VLRNGCPMS" SortExpression="VLRNGCPMS" HeaderText="Valor" DataFormatString="{0:###,###,##0.00}">
						<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Forma">
						<ItemTemplate>
							<asp:Label id=Label1 runat="server" Text='<%# obterDESFRMDSCBNF(DataBinder.Eval(Container, "DataItem.TIPFRMDSCBNF")) %>'>
							</asp:Label>
						</ItemTemplate>
						<EditItemTemplate>
							<asp:TextBox id=TextBox1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TIPFRMDSCBNF") %>'>
							</asp:TextBox>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Destino">
						<ItemTemplate>
							<asp:Label id=Label2 runat="server" Text='<%# obterDESDSNDSCBNF(DataBinder.Eval(Container, "DataItem.TIPDSNDSCBNF")) %>'>
							</asp:Label>
						</ItemTemplate>
						<EditItemTemplate>
							<asp:TextBox id=TextBox2 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TIPDSNDSCBNF") %>'>
							</asp:TextBox>
						</EditItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle VerticalAlign="Middle" Height="20px" HorizontalAlign="Center" PageButtonCount="9"
					CssClass=" " Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
			<TABLE class="tabela4" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="barra1" width="10%" colSpan="7" height="364"><asp:linkbutton id="Linkbutton2" runat="server" Visible="False">LinkButton</asp:linkbutton><igtbl:ultrawebgrid id="GrdVerbaCarimbo" runat="server" Visible="False" Height="400px" Width="100%"
							ImageDirectory="/ig_common/Images/">
							<DisplayLayout StationaryMargins="Header" AutoGenerateColumns="False" AllowSortingDefault="OnClient"
								RowHeightDefault="20px" Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy"
								AllowColumnMovingDefault="OnServer" HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate"
								AllowColSizingDefault="Free" RowSelectorsDefault="No" Name="GrdVerbaCarimbo" TableLayout="Fixed"
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
									BorderStyle="Solid" BackColor="Window" Height="400px"></FrameStyle>
								<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
									<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
								</FooterStyleDefault>
								<GroupByBox Hidden="True">
									<Style BorderColor="Window" BackColor="ActiveBorder"></Style>
								</GroupByBox>
								<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>
								<SelectedRowStyleDefault BackColor="Silver"></SelectedRowStyleDefault>
								<RowStyleDefault BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" BackColor="Window">
									<Padding Left="3px"></Padding>
									<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
								</RowStyleDefault>
							</DisplayLayout>
							<Bands>
								<igtbl:UltraGridBand AddButtonCaption="CADALQICMCRDPSMATPPesquisa" Key="CADALQICMCRDPSMATPPesquisa">
									<Columns>
										<igtbl:TemplatedColumn Key="Sel" Width="35px" HeaderText="Sel" BaseColumnName="" AllowUpdate="Yes">
											<CellStyle HorizontalAlign="Center"></CellStyle>
											<CellTemplate>
												<asp:CheckBox id="chkSel" runat="server" Enabled="False" Checked="True"></asp:CheckBox>
											</CellTemplate>
											<Footer Key="Sel"></Footer>
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<Header Key="Sel" Caption="Sel">
												<Style HorizontalAlign="Center">
												</Style>
											</Header>
										</igtbl:TemplatedColumn>
										<igtbl:UltraGridColumn HeaderText="Carimbo" Key="CARIMBO" Width="80px" BaseColumnName="CARIMBO">
											<CellStyle HorizontalAlign="Center"></CellStyle>
											<Footer Key="CARIMBO">
												<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
											</Footer>
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<Header Key="CARIMBO" Caption="Carimbo">
												<Style HorizontalAlign="Center"></Style>
												<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
											</Header>
										</igtbl:UltraGridColumn>
										<igtbl:UltraGridColumn HeaderText="Data" Key="DATA" Width="80px" Format="dd/MM/yyyy" BaseColumnName="DATA">
											<CellStyle HorizontalAlign="Center"></CellStyle>
											<Footer Key="DATA">
												<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
											</Footer>
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<Header Key="DATA" Caption="Data">
												<Style HorizontalAlign="Center"></Style>
												<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
											</Header>
										</igtbl:UltraGridColumn>
										<igtbl:UltraGridColumn HeaderText="Cod_Fornecedor" Key="COD_FORNECEDOR" Width="120px" BaseColumnName="COD_FORNECEDOR">
											<CellStyle HorizontalAlign="Left"></CellStyle>
											<Footer Key="COD_FORNECEDOR">
												<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
											</Footer>
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<Header Key="COD_FORNECEDOR" Caption="Cod_Fornecedor">
												<Style HorizontalAlign="Center"></Style>
												<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
											</Header>
										</igtbl:UltraGridColumn>
										<igtbl:UltraGridColumn HeaderText="Nome_Fornecedor" Key="NOME_FORNECEDOR" Width="300px" BaseColumnName="NOME_FORNECEDOR">
											<CellStyle HorizontalAlign="Left"></CellStyle>
											<Footer Key="NOME_FORNECEDOR">
												<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
											</Footer>
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<Header Key="NOME_FORNECEDOR" Caption="Nome_Fornecedor">
												<Style HorizontalAlign="Center"></Style>
												<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
											</Header>
										</igtbl:UltraGridColumn>
										<igtbl:UltraGridColumn HeaderText="Funcionario" Key="FUNCIONARIO" Width="80px" BaseColumnName="FUNCIONARIO">
											<CellStyle HorizontalAlign="Center"></CellStyle>
											<Footer Key="FUNCIONARIO">
												<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
											</Footer>
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<Header Key="FUNCIONARIO" Caption="Funcionario">
												<Style HorizontalAlign="Center"></Style>
												<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
											</Header>
										</igtbl:UltraGridColumn>
										<igtbl:UltraGridColumn HeaderText="Valor_Previsto" Key="VALOR_PREVISTO" Width="120px" Format="###,###,##0.00"
											BaseColumnName="VALOR_PREVISTO">
											<CellStyle HorizontalAlign="Right"></CellStyle>
											<Footer Key="VALOR_PREVISTO">
												<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
											</Footer>
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<Header Key="VALOR_PREVISTO" Caption="Valor_Previsto">
												<Style HorizontalAlign="Center"></Style>
												<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
											</Header>
										</igtbl:UltraGridColumn>
										<igtbl:UltraGridColumn HeaderText="Observa&#231;&#227;o" Key="OBSERVACAO" Width="320px" BaseColumnName="OBSERVACAO">
											<CellStyle HorizontalAlign="Left"></CellStyle>
											<Footer Key="OBSERVACAO">
												<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
											</Footer>
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<Header Key="OBSERVACAO" Caption="Observa&#231;&#227;o">
												<Style HorizontalAlign="Center"></Style>
												<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
											</Header>
										</igtbl:UltraGridColumn>
									</Columns>
									<RowEditTemplate>
										<P align="center"></P>
									</RowEditTemplate>
									<RowTemplateStyle BorderColor="Window" BorderStyle="Ridge" BackColor="Window">
										<BorderDetails WidthLeft="3px" WidthTop="3px" WidthRight="3px" WidthBottom="3px"></BorderDetails>
									</RowTemplateStyle>
								</igtbl:UltraGridBand>
							</Bands>
						</igtbl:ultrawebgrid></TD>
				</TR>
				</TD></TR></TABLE>
			<asp:label id="lblErro" runat="server" Font-Size="10px" ForeColor="Red"></asp:label></form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
