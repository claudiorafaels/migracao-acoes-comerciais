<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="martinscontrols" Namespace="Martins.Web.UI.Controls" Assembly="Martins.Web.UI.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=e9ed78c287a2fd3c" %>
<%@ Register TagPrefix="igcmbo" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="uc1" TagName="wucEmpenho" Src="../AppComponents/wucEmpenho.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SelecionarValores.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.SelecionarValores" %>
<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="../AppComponents/wucFornecedor.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Selecionar Valores</TITLE>
		<meta content="False" name="vs_snapToGrid">
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<base target="_self">
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

function textContar(field,maxlimit) { 
	if (field.value.length > maxlimit) {
		alert('Tamanho máximo de ' + maxlimit + ' caracteres');
		field.value = field.value.substring(0, maxlimit); 
	}
}

function grdOrigem_AfterCellUpdateHandler(gridName, cellId){
	if (igtbl_getColumnById(cellId).Key == "Sel"){
		var row = igtbl_getRowById(cellId);
		if (row.getCellFromKey("Sel").getValue()){
			if(parseFloat(window.document.getElementById('txtPERPSQSLDFRN').value) == 0 ){
				row.getCellFromKey("ValorTransferir").setValue(row.getCellFromKey("SaldoDisponivel").getValue());
			}else{
				row.getCellFromKey("ValorTransferir").setValue((parseFloat(row.getCellFromKey('SaldoDisponivel').getValue()) * (parseFloat(window.document.getElementById('txtPERPSQSLDFRN').value) / 100)));
			}
			
			window.MM_findObj('TbValorAtualizado').style.display = 'inline';
		} else {
			row.getCellFromKey("ValorTransferir").setValue(0);
			window.MM_findObj('TbValorAtualizado').style.display = 'inline';
		}
	}
	if (igtbl_getColumnById(cellId).Key == "ValorTransferir"){
		window.MM_findObj('TbValorAtualizado').style.display = 'inline';
	}	
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
			<table style="WIDTH: 100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tbody>
					<tr>
						<td class="submenu2" vAlign="top">
							<table id="tbOpcoes" cellSpacing="0" cellPadding="0" border="0" runat="server">
								<tr>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnLimparOrigem" style="TEXT-DECORATION: none" runat="server"><IMG height="16" src="../../Imagens/office/novo.gif" width="16" align="absMiddle"> Limpar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnPesquisar" style="TEXT-DECORATION: none" runat="server"><IMG height="16" src="../../Imagens/office/Procurar.gif" width="16" align="absMiddle"> Pesquisar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnSalvar" style="TEXT-DECORATION: none" runat="server"><IMG height="16" src="../../Imagens/office/salvar.gif" width="16" align="absMiddle"> Salvar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<TD>
										<TABLE class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnSair" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../../Imagens/Office/S_B_STEP.gif" width="16" align="absMiddle"> Voltar</asp:linkbutton></td>
											</tr>
										</TABLE>
									</TD>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"></td>
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
											<DIV id="Div2" align="left" runat="server"><asp:image id="Image2" runat="server" ImageUrl="../../Imagens/espera.gif"></asp:image>&nbsp;Carregando...
											</DIV>
										</TD>
										<TD class="barra1" id="TDReserva" align="left" width="50%" runat="server"></TD>
									</TR>
									<TR>
										<TD align="left" width="50%" colSpan="2" height="3"></TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE class="tabela1" id="Table0" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
								</TBODY>
							</TABLE>
							<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
									<TR>
										<TD width="100%" colSpan="5" height="5"></TD>
									</TR>
									<TR>
										<TD class="titlemedium1" width="100%" colSpan="3" height="20">Origem
										</TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%" style="HEIGHT: 24px">Filtrar Por:</TD>
										<TD class="barra1" width="90%" colSpan="2" style="HEIGHT: 24px"><asp:dropdownlist id="cmbOpcaoFiltro" runat="server" Width="90px" CssClass=" " AutoPostBack="True">
												<asp:ListItem Value="Categoria">Categoria</asp:ListItem>
												<asp:ListItem Value="Comprador">Comprador</asp:ListItem>
												<asp:ListItem Value="Fornecedor">Fornecedor</asp:ListItem>
											</asp:dropdownlist><igtxt:webnumericedit id="ValorTransferir" runat="server" BrowserTarget="UpLevel" MinDecimalPlaces="Two"
												DataMode="Decimal" Font-Names="Arial" Font-Size="11px">
												<ClientSideEvents KeyDown="ValorTransferir_KeyDown" KeyPress="ValorTransferir_KeyPress"></ClientSideEvents>
												<SpinButtons DefaultTriangleImages="None" Delay="20000" Delta="0" SpinOnArrowKeys="False"></SpinButtons>
											</igtxt:webnumericedit></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%"><asp:label id="lblFiltroOrigem" runat="server" Width="63px" CssClass="barra3">Categoria:</asp:label></TD>
										<TD class="barra1" width="90%" colSpan="2"><asp:dropdownlist id="cmbCategoria" runat="server" Width="260px" CssClass=" "></asp:dropdownlist><asp:dropdownlist id="cmbComprador" runat="server" Width="260px" CssClass=" " Visible="False"></asp:dropdownlist><uc1:wucfornecedor id="WucFornecedor1" runat="server" Visible="False"></uc1:wucfornecedor></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%">Empenho:</TD>
										<TD class="barra1" width="90%" colSpan="2"><igtxt:webnumericedit id="txtTIPDSNDSCBNFORITRN" runat="server" Width="60px" CssClass="" AutoPostBack="True"
												Font-Names="Arial" Font-Size="11px"></igtxt:webnumericedit><asp:dropdownlist id="cmbTIPDSNDSCBNFORITRN" runat="server" Width="196px" CssClass=" " AutoPostBack="True"
												Font-Names="Arial" Font-Size="11px" Height="19px"></asp:dropdownlist><asp:label id="lblAlcVbaFrn" runat="server" Font-Names="Arial" Font-Size="11px" ForeColor="Black"></asp:label></TD>
									</TR>
									<TR id="TRBuscaSaldoFornecedor" runat="server">
										<TD class="barra3" width="10%">% Busca Saldo Fornecedor:</TD>
										<TD class="barra1" width="90%" colSpan="2">
											<igtxt:WebNumericEdit id="txtPERPSQSLDFRN" runat="server" Width="60px" Font-Size="11px" Font-Names="Arial"
												MinDecimalPlaces="Two" AutoPostBack="True"></igtxt:WebNumericEdit></TD>
									</TR>
									<TR>
										<TD class="barra3" width="10%">Valor:</TD>
										<TD class="barra1" width="10%"><igtxt:webcurrencyedit id="txtValor" runat="server" Width="110px" CssClass="" DataMode="Decimal" Font-Names="Arial"
												Font-Size="11px" Height="19px" ReadOnly="True"></igtxt:webcurrencyedit></TD>
										<TD class="barra1" width="80%">
											<TABLE id="TbValorAtualizado" cellSpacing="1" cellPadding="1" border="0">
												<TR>
													<TD><asp:button id="cmdCalcularValores" runat="server" Height="22px" Text="Atualizar"></asp:button>&nbsp;
														<asp:label id="lblMensagemDesatualizado" runat="server" ForeColor="Red">Valor desatualizado</asp:label></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE class="tabela2" id="Table2" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
									<TR>
										<TD width="100%" colSpan="5"><asp:linkbutton id="lkbTodas" runat="server" ForeColor="Black">Todos</asp:linkbutton>&nbsp;
											<asp:linkbutton id="lkbNenhum" runat="server" ForeColor="Black">Nenhum</asp:linkbutton></TD>
									</TR>
									<TR>
										<TD width="100%" colSpan="5"><igtbl:ultrawebgrid id=grdOrigem runat="server" Width="100%" Height="340px" DataMember="tbTransfenciaEmpenhosDoFornecedor" DataSource="<%# DatasetSelecaoValorDisponivelFornecedor1 %>" ImageDirectory="/ig_common/Images/">
												<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" TabDirection="TopToBottom"
													RowHeightDefault="21px" Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy"
													AllowColumnMovingDefault="OnServer" HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate"
													AllowColSizingDefault="Free" RowSelectorsDefault="No" Name="grdOrigem" TableLayout="Fixed"
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
													<FrameStyle Width="100%" BorderWidth="1px" Font-Size="11px" Font-Names="Arial" BorderColor="InactiveCaption"
														BorderStyle="Solid" BackColor="Window" Height="340px"></FrameStyle>
													<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
														<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
													</FooterStyleDefault>
													<ClientSideEvents AfterCellUpdateHandler="grdOrigem_AfterCellUpdateHandler"></ClientSideEvents>
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
													<igtbl:UltraGridBand AddButtonCaption="tbTransfenciaEmpenhosDoFornecedor" BaseTableName="tbTransfenciaEmpenhosDoFornecedor"
														Key="tbTransfenciaEmpenhosDoFornecedor" DataKeyField="CodigoFornecedor,CodigoEmpenho,CodigoAlocacao">
														<Columns>
															<igtbl:UltraGridColumn HeaderText="SEL" Key="Sel" Width="25px" Type="CheckBox" DataType="System.Boolean"
																BaseColumnName="Sel" AllowUpdate="Yes">
																<Footer Key="Sel"></Footer>
																<Header Key="Sel" Caption="SEL"></Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="CATEGORIA" Key="NomeCategoria" IsBound="True" Width="80px" BaseColumnName="NomeCategoria"
																AllowUpdate="No">
																<Footer Key="NomeCategoria">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NomeCategoria" Caption="CATEGORIA">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="COMPRADOR" Key="NomeComprador" IsBound="True" Width="100px" BaseColumnName="NomeComprador"
																AllowUpdate="No">
																<Footer Key="NomeComprador">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NomeComprador" Caption="COMPRADOR">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="CODIGO" Key="CodigoFornecedor" IsBound="True" Width="50px" DataType="System.Decimal"
																BaseColumnName="CodigoFornecedor" AllowUpdate="No">
																<SelectedCellStyle HorizontalAlign="Right"></SelectedCellStyle>
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="CodigoFornecedor">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CodigoFornecedor" Caption="CODIGO">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="NOME" Key="NomeFornecedor" IsBound="True" Width="150px" BaseColumnName="NomeFornecedor"
																AllowUpdate="No">
																<Footer Key="NomeFornecedor">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NomeFornecedor" Caption="NOME">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="CODIGO" Key="CodigoEmpenho" IsBound="True" Width="50px" DataType="System.Decimal"
																BaseColumnName="CodigoEmpenho" AllowUpdate="No">
																<SelectedCellStyle HorizontalAlign="Right"></SelectedCellStyle>
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="CodigoEmpenho">
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CodigoEmpenho" Caption="CODIGO">
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DESCRI&#199;&#195;O" Key="NomeEmpenho" IsBound="True" BaseColumnName="NomeEmpenho"
																AllowUpdate="No">
																<Footer Key="NomeEmpenho">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NomeEmpenho" Caption="DESCRI&#199;&#195;O">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="ALOCA&#199;&#195;O" Key="NomeAlocacao" IsBound="True" Width="70px" BaseColumnName="NomeAlocacao"
																AllowUpdate="No">
																<Footer Key="NomeAlocacao">
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="NomeAlocacao" Caption="ALOCA&#199;&#195;O">
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="ALOCADO" Key="ValorAlocado" IsBound="True" Width="80px" Format="###,###,##0.00"
																DataType="System.Decimal" BaseColumnName="ValorAlocado" AllowUpdate="No">
																<SelectedCellStyle HorizontalAlign="Right"></SelectedCellStyle>
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="ValorAlocado">
																	<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
																<Header Key="ValorAlocado" Caption="ALOCADO">
																	<Style HorizontalAlign="Right">
																	</Style>
																	<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="RECEBER" Key="ValorReceber" IsBound="True" Width="80px" Format="###,###,##0.00"
																DataType="System.Decimal" BaseColumnName="ValorReceber" AllowUpdate="No">
																<SelectedCellStyle HorizontalAlign="Right"></SelectedCellStyle>
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="ValorReceber">
																	<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
																<Header Key="ValorReceber" Caption="RECEBER">
																	<Style HorizontalAlign="Right">
																	</Style>
																	<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="DISPON&#205;VEL" Key="SaldoDisponivel" AllowNull="False" IsBound="True"
																Width="80px" AllowGroupBy="No" Format="###,###,##0.00" DataType="System.Decimal" BaseColumnName="SaldoDisponivel"
																AllowUpdate="No">
																<SelectedCellStyle HorizontalAlign="Right"></SelectedCellStyle>
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="SaldoDisponivel">
																	<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
																<Header Key="SaldoDisponivel" Caption="DISPON&#205;VEL">
																	<Style HorizontalAlign="Right">
																	</Style>
																	<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="TRANSFERIR" Key="ValorTransferir" AllowNull="False" IsBound="True" EditorControlID="ValorTransferir"
																Width="80px" AllowGroupBy="No" Type="Custom" Format="R$  ###,###,##0.00" DataType="System.Decimal"
																BaseColumnName="ValorTransferir" AllowUpdate="Yes" CellMultiline="No">
																<SelectedCellStyle HorizontalAlign="Right"></SelectedCellStyle>
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="ValorTransferir">
																	<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
																<Header Key="ValorTransferir" Caption="TRANSFERIR">
																	<Style HorizontalAlign="Right">
																	</Style>
																	<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn Key="CodigoAlocacao" IsBound="True" Hidden="True" DataType="System.Decimal" BaseColumnName="CodigoAlocacao">
																<Footer Key="CodigoAlocacao">
																	<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CodigoAlocacao">
																	<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
														</Columns>
													</igtbl:UltraGridBand>
												</Bands>
											</igtbl:ultrawebgrid></TD>
									</TR>
								</TBODY>
							</TABLE>
						</td>
					<TR>
						<TD class="darkbox" vAlign="top"></TD>
					</TR>
				</tbody>
			</table>
			<asp:label id="lblErro" runat="server" Font-Size="10px" ForeColor="Red"></asp:label></form>
	</body>
</HTML>
