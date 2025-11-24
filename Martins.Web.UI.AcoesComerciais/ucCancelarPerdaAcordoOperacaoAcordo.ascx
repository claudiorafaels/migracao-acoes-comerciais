<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucCancelarPerdaAcordoOperacaoAcordo.ascx.vb" Inherits="Martins.Web.UI.AcoesComerciais.ucCancelarPerdaAcordoOperacaoAcordo" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="AppComponents/wucFornecedor.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Martins</TITLE>
	</HEAD>
	<LINK href="../Imagens/styles.css" type="text/css" rel="stylesheet">
	<meta content="False" name="vs_showGrid">
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
	<script language="javascript">
		history.forward();
	</script>
	<LINK href="styles_tabelas.css" type="text/css" rel="stylesheet">
	<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
		<TBODY>
			<TR>
				<TD class="barra1" style="HEIGHT: 41px" width="100%" colSpan="5">
					<igtbl:ultrawebgrid id="dGridRecebimentos" UseAccessibleHeader="False" ImageDirectory="/ig_common/Images/"
						Height="125px" Width="100%" runat="server">
						<DisplayLayout AllowDeleteDefault="Yes" StationaryMargins="Header" AllowSortingDefault="OnClient"
							RowHeightDefault="20px" Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy"
							AllowColumnMovingDefault="OnServer" HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate"
							AllowColSizingDefault="Free" RowSelectorsDefault="No" Name="xctl0xdGridRecebimentos" TableLayout="Fixed"
							AllowUpdateDefault="Yes">
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
								BorderStyle="Solid" BackColor="Window" Height="125px"></FrameStyle>
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
							<igtbl:UltraGridBand AddButtonCaption="T0118066" SelectTypeRow="Single" Key="T0118066" AllowDelete="Yes">
								<Columns>
									<igtbl:UltraGridColumn HeaderText="COD. EMP." Key="" BaseColumnName="">
										<Footer Key=""></Footer>
										<Header Key="" Caption="COD. EMP."></Header>
									</igtbl:UltraGridColumn>
									<igtbl:UltraGridColumn HeaderText="PROMESSA" Key="" BaseColumnName="">
										<Footer Key="">
											<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
										</Footer>
										<Header Key="" Caption="PROMESSA">
											<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
										</Header>
									</igtbl:UltraGridColumn>
									<igtbl:UltraGridColumn HeaderText="DAT. NEGOCIA&#199;&#195;O" Key="" BaseColumnName="">
										<Footer Key="">
											<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
										</Footer>
										<Header Key="" Caption="DAT. NEGOCIA&#199;&#195;O">
											<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
										</Header>
									</igtbl:UltraGridColumn>
									<igtbl:UltraGridColumn HeaderText="DAT. PREVISTA" Key="" BaseColumnName="">
										<Footer Key="">
											<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
										</Footer>
										<Header Key="" Caption="DAT. PREVISTA">
											<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
										</Header>
									</igtbl:UltraGridColumn>
									<igtbl:UltraGridColumn HeaderText="FORMA" Key="" BaseColumnName="">
										<Footer Key="">
											<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
										</Footer>
										<Header Key="" Caption="FORMA">
											<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
										</Header>
									</igtbl:UltraGridColumn>
									<igtbl:UltraGridColumn HeaderText="EMPENHO" Key="" BaseColumnName="">
										<Footer Key="">
											<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
										</Footer>
										<Header Key="" Caption="EMPENHO">
											<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
										</Header>
									</igtbl:UltraGridColumn>
									<igtbl:UltraGridColumn HeaderText="VLR. DEP&#211;SITO" Key="" BaseColumnName="">
										<Footer Key="">
											<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
										</Footer>
										<Header Key="" Caption="VLR. DEP&#211;SITO">
											<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
										</Header>
									</igtbl:UltraGridColumn>
								</Columns>
								<RowEditTemplate>
									<P align="right">DATA NEGOCIAÇÃO&nbsp;<INPUT id="igtbl_TextBox_0_0" style="WIDTH: 150px" type="text" columnKey="DATNGCPMS"><BR>
										DATA RECEBIMENTO&nbsp;<INPUT id="igtbl_TextBox_0_1" style="WIDTH: 150px" type="text" columnKey="DATPRVRCBPMS"><BR>
										VALOR&nbsp;<INPUT id="igtbl_TextBox_0_2" style="WIDTH: 150px" type="text" columnKey="VLRNGCPMS"><BR>
										FORMA&nbsp;
										<asp:dropdownlist id="Dropdownlist3" runat="server" Font-Names="Arial" Font-Size="11px" Height="22px"
											Width="150px" CssClass=""></asp:dropdownlist><BR>
										DESTINO
										<asp:dropdownlist id="Dropdownlist1" runat="server" Font-Names="Arial" Font-Size="11px" Height="22px"
											Width="150px" CssClass=""></asp:dropdownlist><BR>
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
		</TBODY>
	</TABLE>
	<TABLE class="tabela1" id="Table2" cellSpacing="0" cellPadding="2" width="100%" border="0">
		<TR>
			<TD class="barra3">Total Alocado Acordo:</TD>
			<TD class="barra1" colSpan="3">
				<igtxt:WebCurrencyEdit id="WebCurrencyEdit1" runat="server" Width="120px" CssClass=" "></igtxt:WebCurrencyEdit></TD>
			<TD class="barra1">
				<TABLE id="Table3" cellSpacing="0" cellPadding="0" border="0" align="right">
					<TR>
						<TD onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');">
							<asp:linkbutton id="btnSalvar" style="TEXT-DECORATION: none" runat="server"><IMG height="16" src="../Imagens/office/imprimir.gif" width="16" align="absMiddle"> Imprimir Acordo</asp:linkbutton></TD>
						<TD onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');">
							<asp:linkbutton id="btnCancelar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
								href="Principal.aspx"><IMG height="16" src="../Imagens/office/S_B_COLR.gif" width="16" align="absMiddle"> Abater</asp:linkbutton></TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
	</TABLE>
</HTML>
