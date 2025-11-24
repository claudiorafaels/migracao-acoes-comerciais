<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="martinscontrols" Namespace="Martins.Web.UI.Controls" Assembly="Martins.Web.UI.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=e9ed78c287a2fd3c" %>
<%@ Register TagPrefix="igcmbo" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igsch" Namespace="Infragistics.WebUI.WebSchedule" Assembly="Infragistics.WebUI.WebDateChooser.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MktExtraAcordoListar.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.MktExtraAcordoListar" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Martins</TITLE>
		<META content="text/html; charset=iso-8859-1" http-equiv="Content-Type">
		<LINK rel="stylesheet" type="text/css" href="../../../../Imagens/Styles.css">
		<LINK rel="stylesheet" type="text/css" href="styles_tabelas.css">
	</HEAD>
	<BODY onload="MM_preloadImages('../../../../Imagens/lastpost.gif')">
		<meta name="vs_snapToGrid" content="False">
		<meta name="vs_showGrid" content="False">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script for="document" event="onreadystatechange">
			if (readyState == 'complete'){
				escondeAndamento();
			} else {
				mostraAndamento();			
			}
		</script>
		<script language="JScript" for="document" event="onkeyup"> 
			autoTab(); 
		</script>
		<SCRIPT language="JavaScript" type="text/javascript" src="../../../../Imagens/controle.js">
		</SCRIPT>
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
			<table border="0" cellSpacing="0" cellPadding="0" width="10">
				<tr>
					<td><A href="javascript:parent.resizeFrame('5,*')"><IMG id="Image1" onmouseover="MM_swapImage('Image1','','../../../../Imagens/lastpost.gif',1)"
								onmouseout="MM_swapImage('Image1','','../../../../Imagens/lastpost_l.gif',1)" name="Image1" src="../../../../Imagens/lastpost_l.gif"
								width="12" height="12"></A></td>
				</tr>
			</table>
			<table style="WIDTH: 100%" border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tbody>
					<tr>
						<td class="submenu2" vAlign="top">
							<table id="tbOpcoes" border="0" cellSpacing="0" cellPadding="0" runat="server">
								<tr>
									<td>
										<table class="3D" border="0" cellSpacing="0" cellPadding="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onmouseout="mOut(this,'');" onclick="mClk('#');"><asp:linkbutton style="TEXT-DECORATION: none" id="btnPesquisar" runat="server" Width="64px" CausesValidation="False"><img src="../../Imagens/office/procurar.gif" width="16" height="16" align="absMiddle">Pesquisar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" border="0" cellSpacing="0" cellPadding="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onmouseout="mOut(this,'');" onclick="mClk('#');"><asp:linkbutton style="TEXT-DECORATION: none" id="btnNovo" runat="server" Width="64px" CausesValidation="False"><img src="../../Imagens/office/novo.gif" width="16" height="16" align="absMiddle">Novo</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" border="0" cellSpacing="0" cellPadding="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onmouseout="mOut(this,'');" onclick="mClk('#');"><asp:linkbutton style="TEXT-DECORATION: none" id="btnDesativar" runat="server" Width="64px" CausesValidation="False"
														Visible="False"><img src="../../../../../Imagens/cancelar.gif" width="16" height="16" align="absMiddle">Desativar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td class="darkbox" vAlign="top">
							<TABLE id="Table0" class="tabela1" border="0" cellSpacing="0" cellPadding="2" width="100%">
								<TBODY>
									<TR id="trEspera" runat="server">
										<TD id="TDEspera" class="barra1" height="19" width="50%" align="left" runat="server">
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
							<TABLE id="Table1" class="tabela1" border="0" cellSpacing="0" cellPadding="2" width="100%">
								<TBODY>
									<TR>
										<TD class="barra3" width="10%">Critério:</TD>
										<TD class="barra1" width="90%" colSpan="3"><asp:dropdownlist id="cmbCriterio" runat="server" Width="150px" AutoPostBack="True" Font-Names="Arial"
												Font-Size="11px" Height="19px" CssClass="">
												<asp:ListItem Value="0" Selected="True">NENHUM</asp:ListItem>
												<asp:ListItem Value="1">CODIGO</asp:ListItem>
												<asp:ListItem Value="2">DESCRI&#199;&#195;O</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
									<TR id="TRCodigo" runat="server">
										<TD class="barra3" width="10%">Código:
										</TD>
										<TD class="barra1" width="90%" colSpan="3"><igtxt:webnumericedit id="txtCODFRN" runat="server" Width="70px" Font-Names="Arial" Font-Size="11px"></igtxt:webnumericedit></TD>
									</TR>
									<TR id="TRDescricao" runat="server">
										<TD class="barra3" width="10%">Descrição:</TD>
										<TD class="barra1" width="90%" colSpan="3"><igtxt:webtextedit id="txtNOMFRN" runat="server" Width="200px" Font-Names="Arial" Font-Size="11px"></igtxt:webtextedit></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%"></TD>
										<TD class="barra1" width="90%" colSpan="3">
											<asp:CheckBox id="chkDATDSTMKTEXAARD" runat="server" Text="% Mkt. Exa. Acordo Desativado"></asp:CheckBox></TD>
									</TR>
								</TBODY>
							</TABLE>
							<asp:linkbutton id="lkbTodas" runat="server" ForeColor="Black" Visible="False">Todas</asp:linkbutton>&nbsp;
							<asp:linkbutton id="lkbNenhuma" runat="server" ForeColor="Black" Visible="False">Nenhuma</asp:linkbutton><br>
							<igtbl:ultrawebgrid id=grdMarketingExtraAcordo runat="server" Width="743px" Height="273px" DataMember="RLCFRNPERMKTEXAARDPesquisa" DataSource="<%# DatasetMarketinExtraAcordo1 %>" ImageDirectory="/ig_common/Images/">
								<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" RowHeightDefault="20px"
									Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
									HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
									RowSelectorsDefault="No" Name="grdMarketingExtraAcordo" TableLayout="Fixed">
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
									<FrameStyle Width="743px" BorderWidth="1px" Font-Size="11px" Font-Names="Arial" BorderColor="InactiveCaption"
										BorderStyle="Solid" BackColor="Window" Height="273px"></FrameStyle>
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
									<igtbl:UltraGridBand AddButtonCaption="RLCFRNPERMKTEXAARDPesquisa" BaseTableName="RLCFRNPERMKTEXAARDPesquisa"
										Key="RLCFRNPERMKTEXAARDPesquisa">
										<Columns>
											<igtbl:TemplatedColumn Key="" Width="25px" Type="CheckBox" BaseColumnName="" AllowUpdate="Yes">
												<Footer Key=""></Footer>
												<Header Key=""></Header>
											</igtbl:TemplatedColumn>
											<igtbl:TemplatedColumn Key="" Width="30px" BaseColumnName="">
												<CellStyle HorizontalAlign="Center"></CellStyle>
												<CellTemplate>
													<asp:ImageButton id="btnEditar" runat="server" ImageUrl="../../Imagens/office/S_B_DAIL.gif" CommandName="btnEditar"></asp:ImageButton>
												</CellTemplate>
												<Footer Key="">
													<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
												</Footer>
												<Header Key="">
													<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
												</Header>
											</igtbl:TemplatedColumn>
											<igtbl:UltraGridColumn HeaderText="C&#243;d. Fornecedor" Key="CODFRN" IsBound="True" Width="90px" DataType="System.Decimal"
												BaseColumnName="CODFRN">
												<CellStyle HorizontalAlign="Center"></CellStyle>
												<Footer Key="CODFRN">
													<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
												</Footer>
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<Header Key="CODFRN" Caption="C&#243;d. Fornecedor">
													<Style HorizontalAlign="Center">
													</Style>
													<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
												</Header>
											</igtbl:UltraGridColumn>
											<igtbl:UltraGridColumn HeaderText="Nome Fornecedor" Key="NOMFRN" IsBound="True" Width="250px" BaseColumnName="NOMFRN">
												<Footer Key="NOMFRN">
													<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
												</Footer>
												<Header Key="NOMFRN" Caption="Nome Fornecedor">
													<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
												</Header>
											</igtbl:UltraGridColumn>
											<igtbl:UltraGridColumn HeaderText="% Mkt. Exa. Acordo" Key="PERMKTEXAARD" IsBound="True" Width="102px"
												Format="###,###,##0.00" DataType="System.Decimal" BaseColumnName="PERMKTEXAARD">
												<CellStyle HorizontalAlign="Center"></CellStyle>
												<Footer Key="PERMKTEXAARD">
													<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
												</Footer>
												<Header Key="PERMKTEXAARD" Caption="% Mkt. Exa. Acordo">
													<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
												</Header>
											</igtbl:UltraGridColumn>
											<igtbl:UltraGridColumn HeaderText="Data Cadastramento" Key="DATCADMKTEXAARD" IsBound="True" Width="110px"
												Format="dd/MM/yyyy" DataType="System.DateTime" BaseColumnName="DATCADMKTEXAARD">
												<CellStyle HorizontalAlign="Center"></CellStyle>
												<Footer Key="DATCADMKTEXAARD">
													<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
												</Footer>
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<Header Key="DATCADMKTEXAARD" Caption="Data Cadastramento">
													<Style HorizontalAlign="Center">
													</Style>
													<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
												</Header>
											</igtbl:UltraGridColumn>
											<igtbl:UltraGridColumn HeaderText="Data Inicio Apura&#231;&#227;o  " Key="DATINIAPUMKTEXAARD" IsBound="True"
												Width="110px" Format="dd/MM/yyyy" DataType="System.DateTime" BaseColumnName="DATINIAPUMKTEXAARD">
												<CellStyle HorizontalAlign="Center"></CellStyle>
												<Footer Key="DATINIAPUMKTEXAARD">
													<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
												</Footer>
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<Header Key="DATINIAPUMKTEXAARD" Caption="Data Inicio Apura&#231;&#227;o  ">
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
