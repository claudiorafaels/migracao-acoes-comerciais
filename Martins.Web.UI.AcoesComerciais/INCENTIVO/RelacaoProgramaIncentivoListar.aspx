<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RelacaoProgramaIncentivoListar.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.RelacaoProgramaIncentivoListar" %>
<%@ Register TagPrefix="uc1" TagName="ucFornecedor" Src="../Controles/ucFornecedor.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucPrograma" Src="../Controles/ucPrograma.ascx" %>
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
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnPesquisar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
														Width="64px"><img src="../../Imagens/office/procurar.gif" width="16" height="16" align="absMiddle">Pesquisar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnNovo" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
														Width="64px"><img src="../../Imagens/office/novo.gif" width="16" height="16" align="absMiddle">Novo</asp:linkbutton></td>
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
										<TD class="barra3" width="10%">Critério:</TD>
										<TD class="barra1" width="90%" colSpan="3"><asp:dropdownlist id="cmbCriterio" runat="server" Width="150px" CssClass="" Height="19px" Font-Size="11px"
												Font-Names="Arial" AutoPostBack="True">
												<asp:ListItem Value="0" Selected="True">NENHUM</asp:ListItem>
												<asp:ListItem Value="1">PROGRAMA</asp:ListItem>
												<asp:ListItem Value="2">FORNECEDOR</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
									<TR id="TRCodigo" runat="server">
										<TD class="barra3" width="10%">Programa:
										</TD>
										<TD class="barra1" width="90%" colSpan="3">
											<uc1:ucPrograma id="UcPrograma" runat="server"></uc1:ucPrograma></TD>
									</TR>
									<TR id="TRDescricao" runat="server">
										<TD class="barra3" width="10%">Fornecedor:</TD>
										<TD class="barra1" width="90%" colSpan="3">
											<uc1:ucFornecedor id="UcFornecedor" runat="server"></uc1:ucFornecedor></TD>
									</TR>
								</TBODY>
							</TABLE>
							<igtbl:ultrawebgrid id=grdIncentivo runat="server" Width="672px" Height="308px" ImageDirectory="/ig_common/Images/" DataSource="<%# DatasetIncentivo1 %>" DataMember="RLCPRGICTFRNPesquisa">
								<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" RowHeightDefault="20px"
									Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
									HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
									RowSelectorsDefault="No" Name="grdIncentivo" TableLayout="Fixed">
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
									<FrameStyle Width="672px" BorderWidth="1px" Font-Size="11px" Font-Names="Arial" BorderColor="InactiveCaption"
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
									<igtbl:UltraGridBand AddButtonCaption="RLCPRGICTFRNPesquisa" BaseTableName="RLCPRGICTFRNPesquisa" Key="RLCPRGICTFRNPesquisa"
										DataKeyField="PROGRAMA,CODIGO">
										<Columns>
											<igtbl:TemplatedColumn Key="" Width="30px" BaseColumnName="">
												<CellStyle HorizontalAlign="Center"></CellStyle>
												<CellTemplate>
													<asp:ImageButton id="btnEditar" runat="server" ImageUrl="../../Imagens/office/S_B_DAIL.gif" CommandName="btnEditar"></asp:ImageButton>
												</CellTemplate>
												<Footer Key=""></Footer>
												<Header Key=""></Header>
											</igtbl:TemplatedColumn>
											<igtbl:UltraGridColumn HeaderText="Programa" Key="PROGRAMA" IsBound="True" Width="60px" DataType="System.Decimal"
												BaseColumnName="PROGRAMA">
												<CellStyle HorizontalAlign="Center"></CellStyle>
												<Footer Key="PROGRAMA">
													<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
												</Footer>
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<Header Key="PROGRAMA" Caption="Programa">
													<Style HorizontalAlign="Center">
													</Style>
													<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
												</Header>
											</igtbl:UltraGridColumn>
											<igtbl:UltraGridColumn HeaderText="Descri&#231;&#227;o" Key="DESCRICAO" IsBound="True" Width="250px" BaseColumnName="DESCRICAO">
												<Footer Key="DESCRICAO">
													<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
												</Footer>
												<Header Key="DESCRICAO" Caption="Descri&#231;&#227;o">
													<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
												</Header>
											</igtbl:UltraGridColumn>
											<igtbl:UltraGridColumn HeaderText="C&#243;digo" Key="CODIGO" IsBound="True" Width="60px" DataType="System.Decimal"
												BaseColumnName="CODIGO">
												<CellStyle HorizontalAlign="Center"></CellStyle>
												<Footer Key="CODIGO">
													<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
												</Footer>
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<Header Key="CODIGO" Caption="C&#243;digo">
													<Style HorizontalAlign="Center">
													</Style>
													<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
												</Header>
											</igtbl:UltraGridColumn>
											<igtbl:UltraGridColumn HeaderText="Fornecedor" Key="FORNECEDOR" IsBound="True" Width="250px" BaseColumnName="FORNECEDOR">
												<Footer Key="FORNECEDOR">
													<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
												</Footer>
												<Header Key="FORNECEDOR" Caption="Fornecedor">
													<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
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
