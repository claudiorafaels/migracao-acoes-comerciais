<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="../AppComponents/wucFornecedor.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SelecionarAcordos.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.SelecionarAcordos" culture="pt-BR"%>
<%@ Register TagPrefix="uc1" TagName="wucEmpenho" Src="../AppComponents/wucEmpenho.ascx" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igcmbo" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="martinscontrols" Namespace="Martins.Web.UI.Controls" Assembly="Martins.Web.UI.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=e9ed78c287a2fd3c" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
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

function grdAcordoCancelamento_AfterCellUpdateHandler(gridName, cellId){
	if (igtbl_getColumnById(cellId).Key == "Sel"){
		var row = igtbl_getRowById(cellId);
		if (row.getCellFromKey("Sel").getValue()){
			row.getCellFromKey("ValorACancelar").setValue(row.getCellFromKey("VLRDSPPMS").getValue());
			window.MM_findObj('TbValorAtualizado').style.display = 'inline';
		} else {
			row.getCellFromKey("ValorACancelar").setValue(0);
			window.MM_findObj('TbValorAtualizado').style.display = 'inline';
		}
	}
	if (igtbl_getColumnById(cellId).Key == "ValorACancelar"){
		window.MM_findObj('TbValorAtualizado').style.display = 'inline';
		//row.getCellFromKey("Sel").setValue(true);
	}	
}

//-->
		</script>
		<LINK href="styles_tabelas.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onload="MM_preloadImages('../../Imagens/lastpost.gif')">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tbody>
					<tr>
						<td class="submenu2" vAlign="top">
							<table id="tbOpcoes" cellSpacing="0" cellPadding="0" border="0" runat="server">
								<tr>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnLimparOrigem" style="TEXT-DECORATION: none" runat="server" Visible="False"><IMG height="16" src="../../Imagens/office/novo.gif" width="16" align="absMiddle"> Limpar</asp:linkbutton></td>
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
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnVoltar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../../Imagens/Office/S_B_STEP.gif" width="16" align="absMiddle"> Voltar</asp:linkbutton></td>
											</tr>
										</TABLE>
									</TD>
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
							<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
									<TR>
										<TD class="barra3" width="10%">Valor:</TD>
										<TD class="barra1" width="10%">
											<igtxt:WebNumericEdit id="txtValor1" runat="server" Width="84px" Font-Names="Arial" Font-Size="11px" MinDecimalPlaces="Two"
												ReadOnly="True"></igtxt:WebNumericEdit></TD>
										<TD class="barra1" width="80%" colSpan="1">
											<TABLE id="TbValorAtualizado" cellSpacing="1" cellPadding="1" border="0">
												<TR>
													<TD><asp:button id="cmdCalcularValores" runat="server" Height="22px" Text="Atualizar"></asp:button>&nbsp;
														<asp:label id="lblMensagemDesatualizado" runat="server" ForeColor="Red">Valor desatualizado</asp:label></TD>
												</TR>
											</TABLE>
											<igtxt:webnumericedit id="txtValorCancelar" runat="server" Font-Size="11px" Font-Names="Arial" DataMode="Decimal"
												MinDecimalPlaces="Two">
												<SpinButtons Delay="20000" Delta="0" SpinOnArrowKeys="False"></SpinButtons>
											</igtxt:webnumericedit></TD>
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
										<TD width="100%" colSpan="5"><igtbl:ultrawebgrid id=grdAcordoCancelamento runat="server" Height="340px" Width="815px" ImageDirectory="/ig_common/Images/" DataSource="<%# DatasetAcordoACancelarEmFluxoCancelamentoAcordo1 %>" DataMember="T0118066Pesquisa">
												<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" TabDirection="TopToBottom"
													RowHeightDefault="21px" Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy"
													AllowColumnMovingDefault="OnServer" HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate"
													AllowColSizingDefault="Free" RowSelectorsDefault="No" Name="grdAcordoCancelamento" TableLayout="Fixed"
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
													<FrameStyle Width="815px" BorderWidth="1px" Font-Size="11px" Font-Names="Arial" BorderColor="InactiveCaption"
														BorderStyle="Solid" BackColor="Window" Height="340px"></FrameStyle>
													<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">
														<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White"></BorderDetails>
													</FooterStyleDefault>
													<ClientSideEvents AfterCellUpdateHandler="grdAcordoCancelamento_AfterCellUpdateHandler"></ClientSideEvents>
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
													<igtbl:UltraGridBand AddButtonCaption="T0118066Pesquisa" BaseTableName="T0118066Pesquisa" Key="T0118066Pesquisa"
														DataKeyField="NUMPEDCNCACOCMC,CODPMS,CODEMP,CODFILEMP,DATNGCPMS,DATPRVRCBPMS,TIPFRMDSCBNF,TIPDSNDSCBNF">
														<Columns>
															<igtbl:UltraGridColumn HeaderText="SEL" Key="Sel" Width="25px" Type="CheckBox" DataType="System.Boolean"
																BaseColumnName="Sel" AllowUpdate="Yes">
																<Footer Key="Sel"></Footer>
																<Header Key="Sel" Caption="SEL"></Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="N&#250;mero" Key="CODPMS" IsBound="True" Width="60px" DataType="System.Decimal"
																BaseColumnName="CODPMS">
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="CODPMS">
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<Header Key="CODPMS" Caption="N&#250;mero">
																	<Style HorizontalAlign="Center">
																	</Style>
																	<RowLayoutColumnInfo OriginX="1"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="D.Emiss&#227;o" Key="DATNGCPMS" IsBound="True" Width="80px" Format="dd/MM/yyyy"
																DataType="System.DateTime" BaseColumnName="DATNGCPMS">
																<CellStyle HorizontalAlign="Center"></CellStyle>
																<Footer Key="DATNGCPMS">
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<Header Key="DATNGCPMS" Caption="D.Emiss&#227;o">
																	<Style HorizontalAlign="Center">
																	</Style>
																	<RowLayoutColumnInfo OriginX="2"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="D.Vencimento" Key="DATPRVRCBPMS" IsBound="True" Width="80px" Format="dd/MM/yyyy"
																DataType="System.DateTime" BaseColumnName="DATPRVRCBPMS">
																<CellStyle HorizontalAlign="Center"></CellStyle>
																<Footer Key="DATPRVRCBPMS">
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<Header Key="DATPRVRCBPMS" Caption="D.Vencimento">
																	<Style HorizontalAlign="Center">
																	</Style>
																	<RowLayoutColumnInfo OriginX="3"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Empenho" Key="DESDSNDSCBNF" IsBound="True" Width="155px" BaseColumnName="DESDSNDSCBNF">
																<CellStyle HorizontalAlign="Left"></CellStyle>
																<Footer Key="DESDSNDSCBNF">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="DESDSNDSCBNF" Caption="Empenho">
																	<RowLayoutColumnInfo OriginX="4"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Forma de Pagamento" Key="DESFRMDSCBNF" IsBound="True" Width="130px"
																BaseColumnName="DESFRMDSCBNF">
																<CellStyle HorizontalAlign="Left"></CellStyle>
																<Footer Key="DESFRMDSCBNF">
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																<Header Key="DESFRMDSCBNF" Caption="Forma de Pagamento">
																	<Style HorizontalAlign="Left">
																	</Style>
																	<RowLayoutColumnInfo OriginX="5"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="D" Key="FLGSITNGCDUP" IsBound="True" Width="20px" BaseColumnName="FLGSITNGCDUP">
																<CellStyle HorizontalAlign="Center"></CellStyle>
																<Footer Key="FLGSITNGCDUP">
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<Header Key="FLGSITNGCDUP" Caption="D">
																	<Style HorizontalAlign="Center">
																	</Style>
																	<RowLayoutColumnInfo OriginX="6"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Vlr.Negociado" Key="VLRNGCPMS" IsBound="True" Width="80px" Format="###,###,##0.00"
																DataType="System.Decimal" BaseColumnName="VLRNGCPMS" CellMultiline="No">
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="VLRNGCPMS">
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<Header Key="VLRNGCPMS" Caption="Vlr.Negociado">
																	<Style HorizontalAlign="Center">
																	</Style>
																	<RowLayoutColumnInfo OriginX="7"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Vlr.Pago" Key="VLRPGOPMS" IsBound="True" Width="80px" Format="###,###,##0.00"
																DataType="System.Decimal" BaseColumnName="VLRPGOPMS" CellMultiline="No">
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="VLRPGOPMS">
																	<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<Header Key="VLRPGOPMS" Caption="Vlr.Pago">
																	<Style HorizontalAlign="Center">
																	</Style>
																	<RowLayoutColumnInfo OriginX="8"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Vlr.Cancelar" Key="ValorACancelar" AllowNull="False" IsBound="True"
																EditorControlID="txtValorCancelar" Width="80px" AllowGroupBy="No" Type="Custom" Format="R$  ###,###,##0.00"
																DataType="System.Decimal" BaseColumnName="ValorACancelar" AllowUpdate="Yes" CellMultiline="No">
																<SelectedCellStyle HorizontalAlign="Right"></SelectedCellStyle>
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="ValorACancelar">
																	<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																</Footer>
																<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
																<Header Key="ValorACancelar" Caption="Vlr.Cancelar">
																	<Style HorizontalAlign="Right">
																	</Style>
																	<RowLayoutColumnInfo OriginX="9"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="Teste" Key="VLRDSPPMS" AllowNull="False" IsBound="True" EditorControlID="ValorTransferir"
																Width="80px" Hidden="True" AllowGroupBy="No" Type="Custom" Format="R$  ###,###,##0.00" DataType="System.Decimal"
																BaseColumnName="VLRDSPPMS" AllowUpdate="No" CellMultiline="No" FooterText="Teste">
																<CellStyle HorizontalAlign="Right"></CellStyle>
																<Footer Key="VLRDSPPMS" Caption="Teste">
																	<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="VLRDSPPMS" Caption="Teste">
																	<RowLayoutColumnInfo OriginX="10"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="CODEMP" Key="CODEMP" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="CODEMP">
																<Footer Key="CODEMP">
																	<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CODEMP" Caption="CODEMP">
																	<RowLayoutColumnInfo OriginX="11"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="CODFILEMP" Key="CODFILEMP" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="CODFILEMP">
																<Footer Key="CODFILEMP">
																	<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CODFILEMP" Caption="CODFILEMP">
																	<RowLayoutColumnInfo OriginX="12"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="TIPDSNDSCBNF" Key="TIPDSNDSCBNF" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="TIPDSNDSCBNF">
																<Footer Key="TIPDSNDSCBNF">
																	<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TIPDSNDSCBNF" Caption="TIPDSNDSCBNF">
																	<RowLayoutColumnInfo OriginX="13"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="TIPFRMDSCBNF" Key="TIPFRMDSCBNF" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="TIPFRMDSCBNF">
																<Footer Key="TIPFRMDSCBNF">
																	<RowLayoutColumnInfo OriginX="14"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="TIPFRMDSCBNF" Caption="TIPFRMDSCBNF">
																	<RowLayoutColumnInfo OriginX="14"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
															<igtbl:UltraGridColumn HeaderText="CODFRN" Key="CODFRN" IsBound="True" Hidden="True" DataType="System.Decimal"
																BaseColumnName="CODFRN">
																<Footer Key="CODFRN">
																	<RowLayoutColumnInfo OriginX="15"></RowLayoutColumnInfo>
																</Footer>
																<Header Key="CODFRN" Caption="CODFRN">
																	<RowLayoutColumnInfo OriginX="15"></RowLayoutColumnInfo>
																</Header>
															</igtbl:UltraGridColumn>
														</Columns>
													</igtbl:UltraGridBand>
												</Bands>
											</igtbl:ultrawebgrid>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
						</td>
					</tr>
				</tbody>
			</table>
		</form>
	</body>
</HTML>
