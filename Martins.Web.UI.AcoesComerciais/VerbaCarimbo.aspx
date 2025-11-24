<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igcmbo" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="VerbaCarimbo.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.VerbaCarimbo"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Martins</TITLE>
		<meta name="vs_snapToGrid" content="False">
		<meta name="vs_showGrid" content="False">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../Imagens/Styles.css">
		<META content="text/html; charset=iso-8859-1" http-equiv="Content-Type">
		<SCRIPT language="JavaScript" type="text/javascript" src="../Imagens/controle.js"></SCRIPT>
		<script for="document" event="onreadystatechange">
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


function somaValorVerba(idCheckbox, valorPrevisto){
    var chk = document.getElementById(idCheckbox);
	var sel = chk.checked;
	var txtValor=igedit_getById('<%= txtVLRNGCPMS.ClientID %>');
	var valorVerba=0;
	if (txtValor.value != null )
	{
		valorVerba = txtValor.getValue();
	}
	
	if(sel == true)
	{
	   valorVerba = valorVerba + valorPrevisto;
	}else{
		valorVerba = valorVerba - valorPrevisto;
	} 
	txtValor.setValue(valorVerba);
}








//-->
		</script>
		<LINK rel="stylesheet" type="text/css" href="styles_tabelas.css">
	</HEAD>
	<body onload="MM_preloadImages('../Imagens/lastpost.gif')" XMLNS:igtbl="http://schemas.infragistics.com/ASPNET/WebControls/UltraWebGrid">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="10">
				<tr>
					<td><A href="javascript:parent.resizeFrame('5,*')"><IMG id="Image1" onmouseover="MM_swapImage('Image1','','../Imagens/lastpost.gif',1)"
								onmouseout="MM_swapImage('Image1','','../Imagens/lastpost_l.gif',1)" name="Image1" src="../Imagens/lastpost_l.gif" width="12"
								height="12"></A></td>
				</tr>
			</table>
			<table style="HEIGHT: 510px" border="0" cellSpacing="0" cellPadding="0" width="100%" height="510">
				<tbody>
					<tr>
						<td style="HEIGHT: 47px" class="submenu2" vAlign="top">
							<table id="tbOpcoes" border="0" cellSpacing="0" cellPadding="0" runat="server">
								<tr>
									<td>
										<table class="3D" border="0" cellSpacing="0" cellPadding="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onmouseout="mOut(this,'');" onclick="mClk('#');"><asp:linkbutton style="TEXT-DECORATION: none" id="btnPesquisar" runat="server"><img src="../Imagens/office/procurar.gif" width="16" height="16" align="absMiddle">Pesquisar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" border="0" cellSpacing="0" cellPadding="0">
											<TR>
												<TD><asp:linkbutton style="TEXT-DECORATION: none" id="btnGerarExtraAcordo" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/S_F_NXTO.gif" width="16" align="absMiddle">Gerar Extra Acordo</asp:linkbutton></TD>
											</TR>
										</table>
									</td>
									<td>
										<table class="3D" border="0" cellSpacing="0" cellPadding="0">
											<TR>
												<TD><asp:linkbutton style="TEXT-DECORATION: none" id="btnAtualizarExtraAcordo" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/atualizar.gif" width="16" align="absMiddle">Atualizar Extra Acordo</asp:linkbutton></TD>
											</TR>
										</table>
									</td>
									<TD style="WIDTH: 8px"></TD>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td class="darkbox" vAlign="top">
							<TABLE id="Table0" class="tabela1" border="0" cellSpacing="0" cellPadding="2" width="100%">
								<TBODY>
									<TR id="trEspera" height="40" runat="server">
										<TD style="HEIGHT: 35px" class="barra1" width="50%" align="left">
											<DIV id="Div2" align="left" runat="server"><asp:image id="Image2" runat="server" ImageUrl="../Imagens/espera.gif"></asp:image>&nbsp;Carregando...
											</DIV>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE id="Table1" class="tabela1" border="0" cellSpacing="0" cellPadding="2" width="100%">
								<TBODY>
									<TR>
										<TD class="barra3" width="10%"><asp:dropdownlist id="ddl2" runat="server" CssClass=" " Width="0px" Height="19px" Font-Size="11px"
												Font-Names="Arial" AutoPostBack="True"></asp:dropdownlist>Fornecedor:</TD>
										<TD class="barra1" width="90%"><igtxt:webnumericedit id="txtCODFRN" runat="server" CssClass="" Font-Size="11px" Font-Names="Arial" AutoPostBack="True"
												width="60px"></igtxt:webnumericedit><asp:dropdownlist id="cmbNomeFornecedor" runat="server" CssClass="" Width="280px" Height="19px" Font-Size="11px"
												Font-Names="Arial" AutoPostBack="True" Visible="False"></asp:dropdownlist><igtxt:webtextedit id="txtNomeFornecedor" runat="server" CssClass="" Width="280px" Font-Size="11px"
												Font-Names="Arial"></igtxt:webtextedit><asp:linkbutton style="TEXT-DECORATION: none" id="btnBuscarFornecedor" runat="server">
												<img src="../Imagens/office/procurar.gif" width="16" height="16" align="absMiddle"></asp:linkbutton></TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE id="Table2" class="tabela1" border="0" cellSpacing="0" cellPadding="2" width="100%">
								<TR>
									<TD class="barra3" width="10%">Destino Verba:</TD>
									<TD class="barra1" width="50%"><asp:dropdownlist id="cmbEmpenho" runat="server" CssClass="" Width="312px" Height="19px" Font-Size="11px"
											Font-Names="Arial"></asp:dropdownlist></TD>
									<TD class="barra3" width="10%">Valor Verba:</TD>
									<TD class="barra1" width="30%"><igtxt:webcurrencyedit id="txtVLRNGCPMS" runat="server" CssClass="" Width="100px" Height="19px" Font-Size="11px"
											Font-Names="Arial" HorizontalAlign="Left"></igtxt:webcurrencyedit></TD>
								</TR>
							</TABLE>
							<TABLE id="Table4" class="tabela4" border="0" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="barra1" height="364" width="10%" colSpan="7"><asp:linkbutton id="Linkbutton2" runat="server" Visible="False">LinkButton</asp:linkbutton><igtbl:ultrawebgrid id="GrdVerbaCarimbo" runat="server" Width="1008px" Height="400px" ImageDirectory="/ig_common/Images/">
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
												<FrameStyle Width="1008px" BorderWidth="1px" Font-Size="11px" Font-Names="Arial" BorderColor="InactiveCaption"
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
																<asp:CheckBox id="chkSel" runat="server"></asp:CheckBox>
															</CellTemplate>
															<Footer Key="Sel"></Footer>
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<Header Key="Sel" Caption="Sel">
																<Style HorizontalAlign="Center">
																</Style>
															</Header>
														</igtbl:TemplatedColumn>
														<igtbl:UltraGridColumn HeaderText="Carimbo" Key="CARIMBO" Width="65px" BaseColumnName="CARIMBO">
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
														<igtbl:UltraGridColumn HeaderText="Data" Key="DATA" Width="65px" Format="" BaseColumnName="DATA">
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
														<igtbl:UltraGridColumn HeaderText="Cod Fornecedor" Key="COD_FORNECEDOR" BaseColumnName="COD_FORNECEDOR">
															<CellStyle HorizontalAlign="Left"></CellStyle>
															<Footer Key="COD_FORNECEDOR">
																<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
															</Footer>
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<Header Key="COD_FORNECEDOR" Caption="Cod Fornecedor">
																<Style HorizontalAlign="Center"></Style>
																<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Nome Fornecedor" Key="NOME_FORNECEDOR" Width="250px" BaseColumnName="NOME_FORNECEDOR">
															<CellStyle HorizontalAlign="Left"></CellStyle>
															<Footer Key="NOME_FORNECEDOR">
																<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
															</Footer>
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<Header Key="NOME_FORNECEDOR" Caption="Nome Fornecedor">
																<Style HorizontalAlign="Center"></Style>
																<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Funcionario" Key="FUNCIONARIO" Width="75px" BaseColumnName="FUNCIONARIO">
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
														<igtbl:UltraGridColumn HeaderText="Valor Previsto" Key="VALOR_PREVISTO" Format="###,###,##0.00" BaseColumnName="VALOR_PREVISTO">
															<CellStyle HorizontalAlign="Right"></CellStyle>
															<Footer Key="VALOR_PREVISTO">
																<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
															</Footer>
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<Header Key="VALOR_PREVISTO" Caption="Valor Previsto">
																<Style HorizontalAlign="Center"></Style>
																<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
															</Header>
														</igtbl:UltraGridColumn>
														<igtbl:UltraGridColumn HeaderText="Observa&#231;&#227;o" Key="OBSERVACAO" Width="300px" BaseColumnName="OBSERVACAO">
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
														<igtbl:UltraGridColumn Key="INDSTAMCOVBAFRN" Hidden="True" BaseColumnName="INDSTAMCOVBAFRN">
															<Footer Key="INDSTAMCOVBAFRN">
																<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
															</Footer>
															<Header Key="INDSTAMCOVBAFRN">
																<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
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
								<TR>
									<TD class="barra1" height="199" width="10%" colSpan="7"><asp:panel id="Panel1" runat="server" Width="725px" HorizontalAlign="Center">
											<asp:label id="lblPaginacao" runat="server" Font-Names="Arial" Font-Size="11px" ForeColor="Black"></asp:label>
										</asp:panel></TD>
								</TR>
								<tr class="escondido">
									<td colSpan="4"><asp:label id="lblFrame" runat="server" Width="0px" Height="0px"></asp:label></td>
								</tr>
							</TABLE>
						</td>
					</tr>
				</tbody>
			</table>
		</form>
	</body>
</HTML>
