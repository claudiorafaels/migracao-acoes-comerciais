<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igsch" Namespace="Infragistics.WebUI.WebSchedule" Assembly="Infragistics.WebUI.WebDateChooser.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucAditamento.ascx.vb" Inherits="Martins.Web.UI.AcoesComerciais.ucAditamento" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Martins</TITLE>
	</HEAD>
	<LINK rel="stylesheet" type="text/css" href="../../Imagens/styles.css">
	<LINK rel="stylesheet" type="text/css" href="styles_tabelas.css">
	<LINK rel="stylesheet" type="text/css" href="styles_tabelas.css">
	<meta name="vs_showGrid" content="False">
	<SCRIPT language="JavaScript" type="text/javascript" src="../../Imagens/controle.js"></SCRIPT>
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
		function txtCodClausula_Blur(oEdit, text, oEvent){
			document.getElementById('webTab__ctl2_ucContratoAbrangencia_ddlClausula').value = text;
		}
		
		function txtCodEntidade_Blur(oEdit, text, oEvent){
			document.getElementById('webTab__ctl2_ucContratoAbrangencia_ddlEntidade').value = text;
		}
		
		function txtCodAbrangencia_Blur(oEdit, text, oEvent){
			document.getElementById('webTab__ctl2_ucContratoAbrangencia_ddlAbrangencia').value = text;
		}
		
		function txtCodBseClcVlrRec_Blur(oEdit, text, oEvent){
			document.getElementById('webTab__ctl2_ucContratoAbrangencia_ddlBseClcVlrRec').value = text;
		}
		
		function txtCodBseClcIndice_Blur(oEdit, text, oEvent){
			document.getElementById('webTab__ctl2_ucContratoAbrangencia_ddlBseClcIndice').value = text;		
		}
		
//-->
	</script>
	<script language="javascript">
		history.forward();
	</script>
	<TABLE id="Table1" class="tabela1" border="0" cellSpacing="0" cellPadding="2" width="100%">
		<TBODY>
			<TR>
				<TD class="barra3" width="10%">Aditamento:</TD>
				<TD class="barra1" width="90%" colSpan="5"><asp:datagrid style="Z-INDEX: 0" id=grdAditamento runat="server" CssClass=" " Width="100%" Font-Size="X-Small" PageSize="4" AllowPaging="True" AutoGenerateColumns="False" DataMember="Aditamento" DataSource="<%# DatasetContrato1 %>">
						<AlternatingItemStyle CssClass="row4"></AlternatingItemStyle>
						<ItemStyle CssClass="row3"></ItemStyle>
						<HeaderStyle CssClass="header1"></HeaderStyle>
						<Columns>
							<asp:ButtonColumn Text="&lt;img src=../../Imagens/office/s_b_dail.gif alt=Detalhe border=0&gt;" CommandName="Link">
								<HeaderStyle Width="30px"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
							</asp:ButtonColumn>
							<asp:TemplateColumn HeaderText="CL&#193;USULA">
								<ItemTemplate>
									<asp:Label id=Label2 runat="server" Text='<%# consultarDESCSLCTTFRN(DataBinder.Eval(Container, "DataItem.NUMCSLCTTFRN")) %>'>
									</asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox id=TextBox1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NUMCSLCTTFRN") %>'>
									</asp:TextBox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="ABRANGENCIA">
								<ItemTemplate>
									<asp:Label id=Label1 runat="server" Text='<%# consultarDESEDEABGMIX(DataBinder.Eval(Container, "DataItem.TIPEDEABGMIX")) %>'>
									</asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox id=TextBox2 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TIPEDEABGMIX") %>'>
									</asp:TextBox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:BoundColumn Visible="False" DataField="CODFRN" SortExpression="CODEDEABGMIX" HeaderText="CODFRN"
								DataFormatString="{0:###########0}"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="NUMCTTFRN" SortExpression="NUMCTTFRN" HeaderText="NUMCTTFRN"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="DESCSLCTTFRN" SortExpression="DESCSLCTTFRN" HeaderText="DESCSLCTTFRN"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="PERFIXAPUVLRRCB" SortExpression="PERFIXAPUVLRRCB" HeaderText="PERFIXAPUVLRRCB"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="CODFXAAVL" SortExpression="CODFXAAVL" HeaderText="CODFXAAVL"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="VLRFXAAVL" SortExpression="VLRFXAAVL" HeaderText="VLRFXAAVL"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="PERAPUVLRRCBREFFXA" SortExpression="PERAPUVLRRCBREFFXA"
								HeaderText="PERAPUVLRRCBREFFXA"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="NUMCSLCTTFRN" SortExpression="NUMCSLCTTFRN" HeaderText="NUMCSLCTTFRN"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="TIPEDEABGMIX" SortExpression="TIPEDEABGMIX" HeaderText="TIPEDEABGMIX"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="DATVNCCTTFRN" SortExpression="DATVNCCTTFRN" HeaderText="DATVNCCTTFRN"></asp:BoundColumn>
							<asp:BoundColumn DataField="CODEDEABGMIX" SortExpression="CODEDEABGMIX" HeaderText="ENTIDADE" DataFormatString="{0:###########0}"></asp:BoundColumn>
						</Columns>
						<PagerStyle VerticalAlign="Middle" Height="20px" HorizontalAlign="Center" PageButtonCount="9"
							CssClass=" " Mode="NumericPages"></PagerStyle>
					</asp:datagrid></TD>
			</TR>
			<TR>
				<TD class="barra1" width="10%" colSpan="6"></TD>
			</TR>
			<TR>
				<TD class="barra3" width="10%">Opções:</TD>
				<TD class="barra1" width="90%" colSpan="5">
					<TABLE id="Table2" class="3D" border="0" cellSpacing="0" cellPadding="0">
						<TR>
							<TD><asp:linkbutton style="TEXT-DECORATION: none" id="btnBuscarAditamento" runat="server" CausesValidation="False"><img src="../../Imagens/office/procurar.gif" width="16" height="16" align="absMiddle">Buscar  Simulação</asp:linkbutton></TD>
							<TD onmouseover="mOvr(this,'#E1EBF4');" onmouseout="mOut(this,'');" onclick="mClk('#');"><asp:linkbutton style="TEXT-DECORATION: none" id="btnSalvarAditamento" runat="server" CausesValidation="False"><IMG height="16" src="../../Imagens/office/salvar.gif" width="16" align="absMiddle">  Salvar aditamento</asp:linkbutton></TD>
							<TD><asp:linkbutton style="TEXT-DECORATION: none" id="btnCancelarAditamento" runat="server" CausesValidation="False"><IMG height="16" src="../../Imagens/office/S_B_CANC.gif" width="16" align="absMiddle">  Cancelar Aditamento</asp:linkbutton></TD>
						</TR>
					</TABLE>
				</TD>
			</TR>
			<TR id="TRDadosAditamento" runat="server">
				<TD class="barra3" width="10%">Dados Aditamento:</TD>
				<TD class="barra1" width="90%" colSpan="5">
					<asp:Label id="lblAditamento" runat="server" Font-Size="11px"></asp:Label>
					<asp:Label style="Z-INDEX: 0" id="lblSituacao" runat="server" ForeColor="Red" Font-Bold="True"
						Font-Size="14px"></asp:Label></TD>
			</TR>
			<TR id="TRFaixas" runat="server">
				<TD class="barra3" width="10%">Faixas:</TD>
				<TD class="barra1" width="90%" colSpan="5"><igtbl:ultrawebgrid style="Z-INDEX: 0" id="grdFaixas" runat="server" Width="274px" ImageDirectory="/ig_common/Images/"
						Height="130px">
						<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" RowHeightDefault="20px"
							Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer"
							HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowColSizingDefault="Free"
							RowSelectorsDefault="No" Name="xctl0xgrdFaixas" TableLayout="Fixed" AllowUpdateDefault="Yes">
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
							<FrameStyle Width="274px" BorderWidth="1px" Font-Size="11px" Font-Names="Arial" BorderColor="InactiveCaption"
								BorderStyle="Solid" BackColor="Window" Height="130px"></FrameStyle>
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
							<igtbl:UltraGridBand AddButtonCaption="CADTRNVBAFRNJOIN" Key="CADTRNVBAFRNJOIN">
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
			<TR id="TRPercentualFixo" runat="server">
				<TD class="barra3" width="10%">% Fixo:</TD>
				<TD class="barra1" width="90%" colSpan="5"><igtxt:webnumericedit style="Z-INDEX: 0" id="txtPERFIXAPUVLRRCB" runat="server" Width="64px" Font-Size="11px"
						Enabled="False" Font-Names="Arial" MinDecimalPlaces="Two"></igtxt:webnumericedit></TD>
			</TR>
			<TR id="TROrigem" runat="server">
				<TD class="barra3" width="10%">% Origem:</TD>
				<TD class="barra1" width="90%" colSpan="5">
					<igtxt:webnumericedit style="Z-INDEX: 0" id="txtPERORIFIXAPUVLRRCB" Font-Size="11px" Width="64px" runat="server"
						MinDecimalPlaces="Two" Font-Names="Arial" Enabled="False"></igtxt:webnumericedit></TD>
			</TR>
			<TR>
				<TD class="barra3" width="10%">Data Início:</TD>
				<TD class="barra1" width="23%"><igsch:webdatechooser style="Z-INDEX: 0" id="txtDataInicio" runat="server" Width="96px" Font-Size="11px"
						Font-Names="Arial" NullDateLabel=" ">
						<AutoPostBack ValueChanged="True"></AutoPostBack>
						<CalendarLayout FooterFormat="Today: {0:d}" MaxDate=""></CalendarLayout>
					</igsch:webdatechooser></TD>
				<TD style="WIDTH: 114px" class="barra3" width="114">Data Fim:</TD>
				<TD class="barra1" width="23%" colSpan="3"><igsch:webdatechooser style="Z-INDEX: 0" id="txtDataFim" runat="server" Width="96px" Font-Size="11px"
						Font-Names="Arial" NullDateLabel=" ">
						<AutoPostBack ValueChanged="True"></AutoPostBack>
						<CalendarLayout FooterFormat="Today: {0:d}" MaxDate=""></CalendarLayout>
					</igsch:webdatechooser></TD>
			</TR>
			<TR>
				<TD class="barra3" width="10%">% Utilizado Acordo:</TD>
				<TD class="barra1" width="23%"><igtxt:webnumericedit style="Z-INDEX: 0" id="txtPERUTZVLRAPUARDFRN" runat="server" Width="64px" Font-Size="11px"
						Enabled="False" Font-Names="Arial" MinDecimalPlaces="Two"></igtxt:webnumericedit></TD>
				<TD style="WIDTH: 112px" class="barra3" width="112">% Desoneração:</TD>
				<TD class="barra1" width="23%"><igtxt:webnumericedit style="Z-INDEX: 0" id="txtPERRCTTBTADIARDFRN" runat="server" Width="64px" Font-Size="11px"
						Enabled="False" Font-Names="Arial" MinDecimalPlaces="Two"></igtxt:webnumericedit></TD>
				<TD class="barra3" width="10%">% Desconto NF:</TD>
				<TD class="barra1" width="23%"><igtxt:webnumericedit style="Z-INDEX: 0" id="txtPERDSCNOTFSCFRN" runat="server" Width="64px" Font-Size="11px"
						Enabled="False" Font-Names="Arial" MinDecimalPlaces="Two"></igtxt:webnumericedit></TD>
			</TR>
		</TBODY>
	</TABLE>
</HTML>
