<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucCancelarPerdaAcordoDesativado.ascx.vb" Inherits="Martins.Web.UI.AcoesComerciais.ucCancelarPerdaAcordoDesativado" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
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
					<igtbl:ultrawebgrid id="grdCancelarPerdaAcordoDesativado" UseAccessibleHeader="False" ImageDirectory="/ig_common/Images/"
						Height="125px" Width="100%" runat="server">
						<DisplayLayout AllowDeleteDefault="Yes" StationaryMargins="Header" AllowSortingDefault="OnClient"
							RowHeightDefault="20px" Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy"
							AllowColumnMovingDefault="OnServer" HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate"
							AllowColSizingDefault="Free" RowSelectorsDefault="No" Name="xctl0xgrdCancelarPerdaAcordoDesativado"
							TableLayout="Fixed" AllowUpdateDefault="Yes">
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
							<GroupByBox>
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
									<igtbl:UltraGridColumn HeaderText="CONTRATO" Key="NUMCTTFRN" IsBound="True" DataType="System.Decimal" BaseColumnName="NUMCTTFRN">
										<Footer Key="NUMCTTFRN"></Footer>
										<Header Key="NUMCTTFRN" Caption="CONTRATO"></Header>
									</igtbl:UltraGridColumn>
									<igtbl:UltraGridColumn HeaderText="CL&#193;USULA" Key="NUMCSLCTTFRN" IsBound="True" DataType="System.Decimal"
										BaseColumnName="NUMCSLCTTFRN">
										<Footer Key="NUMCSLCTTFRN">
											<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
										</Footer>
										<Header Key="NUMCSLCTTFRN" Caption="CL&#193;USULA">
											<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
										</Header>
									</igtbl:UltraGridColumn>
									<igtbl:UltraGridColumn HeaderText="PER&#205;ODO" Key="tippodcttfrn" IsBound="True" BaseColumnName="tippodcttfrn">
										<Footer Key="tippodcttfrn">
											<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
										</Footer>
										<Header Key="tippodcttfrn" Caption="PER&#205;ODO">
											<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
										</Header>
									</igtbl:UltraGridColumn>
									<igtbl:UltraGridColumn HeaderText="NUM. REF. PER&#205;ODO" Key="NUMREFPOD" IsBound="True" DataType="System.Int32"
										BaseColumnName="NUMREFPOD">
										<Footer Key="NUMREFPOD">
											<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
										</Footer>
										<Header Key="NUMREFPOD" Caption="NUM. REF. PER&#205;ODO">
											<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
										</Header>
									</igtbl:UltraGridColumn>
									<igtbl:UltraGridColumn HeaderText="ENTIDADE" Key="TIPEDEABGMIX" IsBound="True" DataType="System.Int32"
										BaseColumnName="TIPEDEABGMIX">
										<Footer Key="TIPEDEABGMIX">
											<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
										</Footer>
										<Header Key="TIPEDEABGMIX" Caption="ENTIDADE">
											<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
										</Header>
									</igtbl:UltraGridColumn>
									<igtbl:UltraGridColumn HeaderText="COD. ABRANG&#202;NCIA" Key="CODEDEABGMIX" IsBound="True" DataType="System.Decimal"
										BaseColumnName="CODEDEABGMIX">
										<Footer Key="CODEDEABGMIX">
											<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
										</Footer>
										<Header Key="CODEDEABGMIX" Caption="COD. ABRANG&#202;NCIA">
											<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
										</Header>
									</igtbl:UltraGridColumn>
									<igtbl:UltraGridColumn HeaderText="DATA REFER&#202;NCIA" Key="DATREFAPU" IsBound="True" Format="dd/MM/yyyy"
										DataType="System.DateTime" BaseColumnName="DATREFAPU">
										<Footer Key="DATREFAPU">
											<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
										</Footer>
										<Header Key="DATREFAPU" Caption="DATA REFER&#202;NCIA">
											<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
										</Header>
									</igtbl:UltraGridColumn>
									<igtbl:UltraGridColumn HeaderText="SEQUENCIA" Key="numseqrlccttpms" IsBound="True" BaseColumnName="numseqrlccttpms">
										<Footer Key="numseqrlccttpms">
											<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
										</Footer>
										<Header Key="numseqrlccttpms" Caption="SEQUENCIA">
											<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
										</Header>
									</igtbl:UltraGridColumn>
									<igtbl:UltraGridColumn HeaderText="FORNECEDOR" Key="CODFRN" IsBound="True" BaseColumnName="CODFRN">
										<Footer Key="CODFRN">
											<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
										</Footer>
										<Header Key="CODFRN" Caption="FORNECEDOR">
											<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
										</Header>
									</igtbl:UltraGridColumn>
									<igtbl:UltraGridColumn HeaderText="VLR. CR&#201;DITO" Key="VLRCRDDISCTTFRN" IsBound="True" Format="R$  ###,###,##0.00"
										DataType="System.Decimal" BaseColumnName="VLRCRDDISCTTFRN">
										<Footer Key="VLRCRDDISCTTFRN">
											<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
										</Footer>
										<Header Key="VLRCRDDISCTTFRN" Caption="VLR. CR&#201;DITO">
											<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
										</Header>
									</igtbl:UltraGridColumn>
									<igtbl:UltraGridColumn HeaderText="FORMA" Key="TIPFRMDSCBNF" IsBound="True" BaseColumnName="TIPFRMDSCBNF">
										<Footer Key="TIPFRMDSCBNF">
											<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
										</Footer>
										<Header Key="TIPFRMDSCBNF" Caption="FORMA">
											<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
										</Header>
									</igtbl:UltraGridColumn>
									<igtbl:UltraGridColumn HeaderText="EMPENHO" Key="TIPDSNDSCBNF" IsBound="True" BaseColumnName="TIPDSNDSCBNF">
										<Footer Key="TIPDSNDSCBNF">
											<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
										</Footer>
										<Header Key="TIPDSNDSCBNF" Caption="EMPENHO">
											<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
										</Header>
									</igtbl:UltraGridColumn>
									<igtbl:UltraGridColumn HeaderText="USU&#193;RIO" Key="NOMUSRSIS" IsBound="True" BaseColumnName="NOMUSRSIS">
										<Footer Key="NOMUSRSIS">
											<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
										</Footer>
										<Header Key="NOMUSRSIS" Caption="USU&#193;RIO">
											<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
										</Header>
									</igtbl:UltraGridColumn>
									<igtbl:UltraGridColumn HeaderText="DAT. GERA&#199;&#195;O" Key="DATGRCOBSPMS" IsBound="True" Format="dd/MM/yyyy"
										DataType="System.DateTime" BaseColumnName="DATGRCOBSPMS">
										<Footer Key="DATGRCOBSPMS">
											<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
										</Footer>
										<Header Key="DATGRCOBSPMS" Caption="DAT. GERA&#199;&#195;O">
											<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
										</Header>
									</igtbl:UltraGridColumn>
								</Columns>
								<RowTemplateStyle BorderColor="Window" BorderStyle="Ridge" BackColor="Window">
									<BorderDetails WidthLeft="3px" WidthTop="3px" WidthRight="3px" WidthBottom="3px"></BorderDetails>
								</RowTemplateStyle>
								<SelectedRowStyle BorderColor="Transparent" BorderStyle="None" BackColor="ScrollBar"></SelectedRowStyle>
							</igtbl:UltraGridBand>
						</Bands>
					</igtbl:ultrawebgrid>
				</TD>
			</TR>
		</TBODY>
	</TABLE>
</HTML>
