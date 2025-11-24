<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RelacaoGrupoMktManter.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.RelacaoGrupoMktManter" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igsch" Namespace="Infragistics.WebUI.WebSchedule" Assembly="Infragistics.WebUI.WebDateChooser.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igcmbo" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="martinscontrols" Namespace="Martins.Web.UI.Controls" Assembly="Martins.Web.UI.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=e9ed78c287a2fd3c" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Martins</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../../../../Imagens/Styles.css" type="text/css" rel="stylesheet">
		<LINK href="styles_tabelas.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY onload="MM_preloadImages('../../../../Imagens/lastpost.gif')">
		<meta content="False" name="vs_snapToGrid">
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script event="onreadystatechange" for="document">
			if (readyState == 'complete'){
				escondeAndamento();
			} else {
				mostraAndamento();			
			}
		</script>
		<script language="JScript" event="onkeyup" for="document"> 
			autoTab(); 
		</script>
		<SCRIPT language="JavaScript" src="../../../../Imagens/controle.js" type="text/javascript">
		</SCRIPT>
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

function CarregaTelaIncluirIndicadorAcordo(){
  escondeAndamento();
  window.showModalDialog('IncluirIndicadorAcordo.aspx','window','help:no;status:no;scroll:no;edge:raised;dialogWidth:400px;edge:raised;dialogHeight:120px');
  __doPostBack('lkbProcessaCloseModalIncluirIndicadorAcordo','');
}

//-->
		</script>
		<script language="javascript">
			history.forward();
		</script>
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="10" border="0">
				<tr>
					<td><A href="javascript:parent.resizeFrame('5,*')"><IMG id="Image1" onmouseover="MM_swapImage('Image1','','../../../../Imagens/lastpost.gif',1)"
								onmouseout="MM_swapImage('Image1','','../../../../Imagens/lastpost_l.gif',1)" height="12" src="../../../../Imagens/lastpost_l.gif"
								width="12" name="Image1"></A></td>
				</tr>
			</table>
			<table style="WIDTH: 100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tbody>
					<tr>
						<td class="submenu2" vAlign="top">
							<table id="tbOpcoes" cellSpacing="0" cellPadding="0" border="0" runat="server">
								<tr>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnSalvar" style="TEXT-DECORATION: none" runat="server" Width="64px" CausesValidation="False"><IMG height="16" src="../../Imagens/office/salvar.gif" width="16" align="absMiddle">Salvar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnSair" style="TEXT-DECORATION: none" runat="server" Width="64px" CausesValidation="False"><IMG height="16" src="../../Imagens/office/Sair.gif" width="16" align="absMiddle"> Sair</asp:linkbutton></td>
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
									<TR id="trEspera" runat="server">
										<TD class="barra1" id="TDEspera" align="left" width="50%" height="19" runat="server">
											<DIV id="Div1" align="left" runat="server"><asp:image id="Image2" runat="server" ImageUrl="../../../../Imagens/espera.gif"></asp:image>&nbsp;Carregando...
											</DIV>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
						</td>
					</tr>
					<tr>
						<td class="darkbox" vAlign="top">
							<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
									<TR>
										<TD class="barra3" width="10%">Grupo Marketing:</TD>
										<TD class="barra1" width="90%" colSpan="3"><asp:dropdownlist id="cmbGrupoMarketingPercentuais" runat="server" Width="150px" Font-Names="Arial"
												Font-Size="11px" Height="19px" CssClass=""></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD width="10%" colSpan="4"><asp:linkbutton id="lkbTodas" runat="server" ForeColor="Black">Todas</asp:linkbutton>&nbsp;
											<asp:linkbutton id="lkbNenhuma" runat="server" ForeColor="Black">Nenhuma</asp:linkbutton></TD>
									</TR>
								</TBODY>
							</TABLE>
							<igtbl:ultrawebgrid id=grdRelacaoGrupoEconomico runat="server" Width="765px" Height="308px" DataMember="RLCGRPECOGRPMKTFRNPesquisaPai" DataSource="<%# DatasetTipoGrupoMarketing1 %>" ImageDirectory="/ig_common/Images/">
								<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" RowHeightDefault="20px"
									Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
									HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
									RowSelectorsDefault="No" Name="grdRelacaoGrupoEconomico" TableLayout="Fixed">
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
									<FrameStyle Width="765px" BorderWidth="1px" Font-Size="11px" Font-Names="Arial" BorderColor="InactiveCaption"
										BorderStyle="Solid" BackColor="Window" Height="308px"></FrameStyle>
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
									<igtbl:UltraGridBand AddButtonCaption="RLCGRPECOGRPMKTFRNPesquisaPai" BaseTableName="RLCGRPECOGRPMKTFRNPesquisaPai"
										Key="RLCGRPECOGRPMKTFRNPesquisaPai" DataKeyField="CODGRPFRN">
										<Columns>
											<igtbl:UltraGridColumn HeaderText="Sel." Key="Sel" Width="30px" Type="CheckBox" BaseColumnName="" AllowUpdate="Yes">
												<CellStyle HorizontalAlign="Center"></CellStyle>
												<Footer Key="Sel"></Footer>
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<Header Key="Sel" Caption="Sel.">
													<Style HorizontalAlign="Center">
													</Style>
												</Header>
											</igtbl:UltraGridColumn>
											<igtbl:UltraGridColumn HeaderText="CODGRP" Key="CODGRPFRN" IsBound="True" Width="65px" DataType="System.Decimal"
												BaseColumnName="CODGRPFRN">
												<CellStyle HorizontalAlign="Center"></CellStyle>
												<Footer Key="CODGRPFRN">
													<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
												</Footer>
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<Header Key="CODGRPFRN" Caption="CODGRP">
													<Style HorizontalAlign="Center">
													</Style>
													<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
												</Header>
											</igtbl:UltraGridColumn>
											<igtbl:UltraGridColumn HeaderText="Grupo Econ&#244;mico" Key="NOMGRPFRN" IsBound="True" Width="200px" BaseColumnName="NOMGRPFRN">
												<Footer Key="NOMGRPFRN">
													<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
												</Footer>
												<Header Key="NOMGRPFRN" Caption="Grupo Econ&#244;mico">
													<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
												</Header>
											</igtbl:UltraGridColumn>
											<igtbl:UltraGridColumn HeaderText="GRPMKT" Key="TIPGRPMKTFRN" IsBound="True" Width="65px" DataType="System.Decimal"
												BaseColumnName="TIPGRPMKTFRN">
												<CellStyle HorizontalAlign="Center"></CellStyle>
												<Footer Key="TIPGRPMKTFRN">
													<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
												</Footer>
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<Header Key="TIPGRPMKTFRN" Caption="GRPMKT">
													<Style HorizontalAlign="Center">
													</Style>
													<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
												</Header>
											</igtbl:UltraGridColumn>
											<igtbl:UltraGridColumn HeaderText="Grupo Marketing" Key="DESGRPMKTFRN" IsBound="True" Width="200px" BaseColumnName="DESGRPMKTFRN">
												<Footer Key="DESGRPMKTFRN">
													<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
												</Footer>
												<Header Key="DESGRPMKTFRN" Caption="Grupo Marketing">
													<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
												</Header>
											</igtbl:UltraGridColumn>
											<igtbl:UltraGridColumn HeaderText="% MKT" Key="PERGRPMKTFRN" IsBound="True" Width="60px" Format="###,###,##0.00"
												DataType="System.Decimal" BaseColumnName="PERGRPMKTFRN">
												<CellStyle HorizontalAlign="Center"></CellStyle>
												<Footer Key="PERGRPMKTFRN">
													<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
												</Footer>
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<Header Key="PERGRPMKTFRN" Caption="% MKT">
													<Style HorizontalAlign="Center">
													</Style>
													<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
												</Header>
											</igtbl:UltraGridColumn>
											<igtbl:UltraGridColumn HeaderText="Verba MKT" Key="INDORIVBAMKT" IsBound="True" BaseColumnName="INDORIVBAMKT">
												<CellStyle HorizontalAlign="Center"></CellStyle>
												<Footer Key="INDORIVBAMKT">
													<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
												</Footer>
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<Header Key="INDORIVBAMKT" Caption="Verba MKT">
													<Style HorizontalAlign="Center">
													</Style>
													<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
												</Header>
											</igtbl:UltraGridColumn>
										</Columns>
										<RowEditTemplate>
											<P align="center">&nbsp;
											</P>
										</RowEditTemplate>
										<RowTemplateStyle BorderColor="Window" BorderStyle="Ridge" BackColor="Window">
											<BorderDetails WidthLeft="3px" WidthTop="3px" WidthRight="3px" WidthBottom="3px"></BorderDetails>
										</RowTemplateStyle>
									</igtbl:UltraGridBand>
								</Bands>
							</igtbl:ultrawebgrid></td>
					</tr>
				</tbody>
			</table>
			<asp:label id="lblErro" runat="server" Font-Size="10px" ForeColor="Red"></asp:label></form>
	</BODY>
</HTML>
