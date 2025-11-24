<%@ Register TagPrefix="igsch" Namespace="Infragistics.WebUI.WebSchedule" Assembly="Infragistics.WebUI.WebDateChooser.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="FluxoDeCancelamentoDeAcordosListar.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.FluxoDeCancelamentoDeAcordosListar" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Martins</TITLE>
		<meta content="True" name="vs_snapToGrid">
		<meta content="False" name="vs_showGrid">
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../../Imagens/styles.css" type="text/css" rel="stylesheet">
			<script event="onreadystatechange" for="document">
			if (readyState == 'complete'){
				escondeAndamento();
			} else {
				mostraAndamento();			
			}
			</script>
			<SCRIPT language="JavaScript" src="../../Imagens/controle.js" type="text/javascript"></SCRIPT>
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
	</HEAD>
	<BODY onload="MM_preloadImages('../../Imagens/lastpost.gif')">
		<form id="Form1" runat="server">
			<table cellSpacing="0" cellPadding="0" width="10" border="0">
				<tr>
					<td><A href="javascript:parent.resizeFrame('5,*')"><IMG id="Image1" onmouseover="MM_swapImage('Image1','','../../Imagens/lastpost.gif',1)"
								onmouseout="MM_swapImage('Image1','','../../imagens/lastpost_l.gif',1)" height="12" src="../../Imagens/lastpost_l.gif" width="12"
								name="Image1"></A></td>
				</tr>
			</table>
			<table height="424" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tbody>
					<tr>
					</tr>
				</tbody></table>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tbody>
					<tr>
						<td class="submenu2" vAlign="top">
							<table id="tbOpcoes" cellSpacing="0" cellPadding="0" border="0" runat="server">
								<tr>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnPesquisar" style="TEXT-DECORATION: none" runat="server"><img src="../../Imagens/office/procurar.gif" width="16" height="16" align="absMiddle">Pesquisar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnNovo" style="TEXT-DECORATION: none" runat="server"><img src="../../Imagens/office/novo.gif" width="16" height="16" align="absMiddle">Novo</asp:linkbutton></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
					</tr>
				</tbody></table>
			<TABLE class="tabela2" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR id="trEspera" runat="server">
					<TD class="barra1" width="10%" colSpan="7">
						<DIV id="Div1" align="left" runat="server"><asp:image id="Espera" runat="server" ImageUrl="../../Imagens/espera.gif"></asp:image>&nbsp;Carregando...
						</DIV>
					</TD>
				</TR>
			</TABLE>
			<TABLE class="tabela3" id="Table3" height="8" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<TR>
					<TD class="barra3" width="10%" height="19">Filtro:</TD>
					<TD class="barra1" width="90%" colSpan="6" height="19"><asp:dropdownlist id="cmbFiltro" runat="server" Width="130px" AutoPostBack="True">
							<asp:ListItem Value="1">Fluxo</asp:ListItem>
							<asp:ListItem Value="2">Status</asp:ListItem>
							<asp:ListItem Value="3" Selected="True">Minhas Aprova&#231;&#245;es</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR id="TRFluxo" runat="server">
					<TD class="barra3" width="10%" height="19">Fluxo:</TD>
					<TD class="barra1" width="90%" colSpan="6" height="19" runat="server"><igtxt:webnumericedit id="txtFluxo" runat="server" Width="70px" MaxLength="9" Font-Size="11px" Font-Names="Arial"></igtxt:webnumericedit></TD>
				</TR>
				<TR id="TRStatus" runat="server">
					<TD class="barra3" width="10%" height="19">Status:</TD>
					<TD class="barra1" width="90%" colSpan="6" height="19"><asp:dropdownlist id="cmbCODSTAAPV" runat="server" Width="130px" AutoPostBack="True">
							<asp:ListItem Value="0">Em Aprova&#231;&#227;o</asp:ListItem>
							<asp:ListItem Value="1" Selected="True">Aprovado</asp:ListItem>
							<asp:ListItem Value="2">Rejeitado</asp:ListItem>
							<asp:ListItem Value="3">Novo</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
			</TABLE>
			<TABLE class="tabela3" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="barra1" width="100%" colSpan="7" height="19"><igtbl:ultrawebgrid id=GrdFluxo runat="server" Width="728px" Height="440px" ImageDirectory="/ig_common/Images/" DataSource="<%# DatasetFluxoCancelamentoAcordo1 %>" DataMember="T0154038Pesquisa">
							<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" RowHeightDefault="20px"
								Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
								HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
								RowSelectorsDefault="No" Name="GrdFluxo" TableLayout="Fixed" AllowUpdateDefault="Yes">
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
								<FrameStyle Width="728px" BorderWidth="1px" Font-Size="11px" Font-Names="Arial" BorderColor="InactiveCaption"
									BorderStyle="Solid" BackColor="Window" Height="440px"></FrameStyle>
								<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
									<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
								</FooterStyleDefault>
								<GroupByBox Hidden="True">
									<Style BorderColor="Window" BackColor="ActiveBorder"></Style>
								</GroupByBox>
								<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>
								<RowStyleDefault BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" BackColor="Window">
									<Padding Left="3px"></Padding>
									<BorderDetails WidthLeft="0px" WidthTop="0px"></BorderDetails>
								</RowStyleDefault>
							</DisplayLayout>
							<Bands>
								<igtbl:UltraGridBand AddButtonCaption="T0154038Pesquisa" BaseTableName="T0154038Pesquisa" Key="T0154038Pesquisa">
									<Columns>
										<igtbl:TemplatedColumn Key="" Width="30px" HeaderText="Sel" BaseColumnName="" AllowUpdate="Yes">
											<CellStyle HorizontalAlign="Center"></CellStyle>
											<CellTemplate>
												<asp:LinkButton id="btnLnkSelecionar" runat="server" CommandName="btnLnkSelecionar">
													<img src="../../Imagens/office/s_b_dail.gif" alt="Detalhe" border="0"></asp:LinkButton>
											</CellTemplate>
											<Footer Key=""></Footer>
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<Header Key="" Caption="Sel">
												<Style HorizontalAlign="Center"></Style>
											</Header>
										</igtbl:TemplatedColumn>
										<igtbl:UltraGridColumn HeaderText="Fluxo" Key="NUMPEDCNCACOCMC" IsBound="True" Width="80px" DataType="System.Decimal"
											BaseColumnName="NUMPEDCNCACOCMC">
											<CellStyle HorizontalAlign="Center"></CellStyle>
											<Footer Key="NUMPEDCNCACOCMC">
												<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
											</Footer>
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<Header Key="NUMPEDCNCACOCMC" Caption="Fluxo">
												<Style HorizontalAlign="Center"></Style>
												<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
											</Header>
										</igtbl:UltraGridColumn>
										<igtbl:UltraGridColumn HeaderText="Status" Key="DESSTAAPV" IsBound="True" Width="150px" BaseColumnName="DESSTAAPV">
											<Footer Key="DESSTAAPV">
												<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
											</Footer>
											<Header Key="DESSTAAPV" Caption="Status">
												<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
											</Header>
										</igtbl:UltraGridColumn>
										<igtbl:UltraGridColumn HeaderText="Fornecedor" Key="NOMFRN" IsBound="True" Width="250px" BaseColumnName="NOMFRN">
											<Footer Key="NOMFRN">
												<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
											</Footer>
											<Header Key="NOMFRN" Caption="Fornecedor">
												<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
											</Header>
										</igtbl:UltraGridColumn>
										<igtbl:UltraGridColumn HeaderText="Observa&#231;&#227;o" Key="DESOBSCNCACOCMC" IsBound="True" Width="400px"
											BaseColumnName="DESOBSCNCACOCMC">
											<Footer Key="DESOBSCNCACOCMC">
												<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
											</Footer>
											<Header Key="DESOBSCNCACOCMC" Caption="Observa&#231;&#227;o">
												<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
											</Header>
										</igtbl:UltraGridColumn>
										<igtbl:UltraGridColumn HeaderText="CODFRN" Key="CODFRN" IsBound="True" Hidden="True" DataType="System.Decimal"
											BaseColumnName="CODFRN">
											<Footer Key="CODFRN">
												<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
											</Footer>
											<Header Key="CODFRN" Caption="CODFRN">
												<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
											</Header>
										</igtbl:UltraGridColumn>
										<igtbl:UltraGridColumn HeaderText="CODSTAAPV" Key="CODSTAAPV" IsBound="True" Hidden="True" DataType="System.Decimal"
											BaseColumnName="CODSTAAPV">
											<Footer Key="CODSTAAPV">
												<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
											</Footer>
											<Header Key="CODSTAAPV" Caption="CODSTAAPV">
												<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
											</Header>
										</igtbl:UltraGridColumn>
									</Columns>
									<RowEditTemplate>
										<P align="right">Sel&nbsp;<INPUT id="igtbl_TextBox_0_0" style="WIDTH: 150px" type="text" columnKey=""><BR>
											Numero Fluxo&nbsp;<INPUT id="igtbl_TextBox_0_1" style="WIDTH: 150px" type="text" columnKey="NUMFLUAPV"><BR>
											Status Fluxo&nbsp;<INPUT id="igtbl_TextBox_0_2" style="WIDTH: 150px" type="text" columnKey="TIPSTAFLUAPV"><BR>
											Descrição Alocação&nbsp;<INPUT id="igtbl_TextBox_0_3" style="WIDTH: 150px" type="text" columnKey="DESALCVBAFRN"><BR>
											Descrição Destino&nbsp;<INPUT id="igtbl_TextBox_0_4" style="WIDTH: 150px" type="text" columnKey="DESDSNDSCBNF"><BR>
											Descrição Justificativa&nbsp;<INPUT id="igtbl_TextBox_0_5" style="WIDTH: 150px" type="text" columnKey="DESJSTTRNVBA"><BR>
											Funcionario&nbsp;<INPUT id="igtbl_TextBox_0_6" style="WIDTH: 150px" type="text" columnKey="NOMFNC"><BR>
										</P>
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
					<TD class="barra1" width="100%" colSpan="7" height="19">
						<P align="center"><asp:label id="lblPaginacao" runat="server" Font-Size="11px" Font-Names="Arial" ForeColor="Black"></asp:label></P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</BODY>
</HTML>
