<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucContratoClausula.ascx.vb" Inherits="Martins.Web.UI.AcoesComerciais.ucContratoClausula" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="AppComponents/wucFornecedor.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Martins</TITLE>
	</HEAD>
	<LINK href="../Imagens/styles.css" type="text/css" rel="stylesheet">
	<LINK href="styles_tabelas.css" type="text/css" rel="stylesheet">
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
		function txtCodFormaPagamento_Blur(oEdit, text, oEvent){
			document.getElementById('webTab__ctl1_ucContratoClausula_ddlFormaPagamento').value = text;
		}
		function txtCodDVF_Blur(oEdit, text, oEvent){
			document.getElementById('webTab__ctl1_ucContratoClausula_ddlDVF').value = text;
		}
		function txtCodDVM_Blur(oEdit, text, oEvent){
			document.getElementById('webTab__ctl1_ucContratoClausula_ddlDVM').value = text;
		}
		function txtTIPPODCTTFRN_Blur(oEdit, text, oEvent){
			document.getElementById('webTab__ctl1_ucContratoClausula_cmbTIPPODCTTFRN').value = text;
		}
//-->
	</script>
	<script language="javascript">
		history.forward();
	</script>
	<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
		<TBODY>
			<TR>
				<TD class="barra3" width="11%">Cláusulas do Contrato:</TD>
				<TD class="barra1" width="89%" colSpan="7"><asp:datagrid id=grdClausulas runat="server" CssClass=" " Width="100%" Font-Size="X-Small" PageSize="2" AllowPaging="True" AutoGenerateColumns="False" DataMember="T0124961" DataSource="<%# DatasetContrato1 %>">
						<AlternatingItemStyle CssClass="row4"></AlternatingItemStyle>
						<ItemStyle CssClass="row3"></ItemStyle>
						<HeaderStyle CssClass="header1"></HeaderStyle>
						<Columns>
							<asp:ButtonColumn Text="&lt;img src=../Imagens/office/s_b_dail.gif alt=Detalhe border=0&gt;" CommandName="Link">
								<HeaderStyle Width="30px"></HeaderStyle>
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
							<asp:BoundColumn DataField="DATINIVGRCSLCTTFRN" SortExpression="DATINIVGRCSLCTTFRN" HeaderText="DATA VIGOR."
								DataFormatString="{0:dd/MM/yyyy}">
								<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="DATDSTCSL" SortExpression="DATDSTCSL" HeaderText="DATA DESAT." DataFormatString="{0:dd/MM/yyyy}">
								<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="NUMCSLCTTFRN" SortExpression="NUMCSLCTTFRN" HeaderText="NUMCSLCTTFRN"></asp:BoundColumn>
						</Columns>
						<PagerStyle VerticalAlign="Middle" Height="20px" HorizontalAlign="Center" PageButtonCount="9"
							CssClass=" " Mode="NumericPages"></PagerStyle>
					</asp:datagrid></TD>
			</TR>
			<TR>
				<TD class="barra1" style="HEIGHT: 3px" width="11%"></TD>
				<TD class="barra1" style="HEIGHT: 3px" width="89%" colSpan="7"></TD>
			</TR>
			<TR>
				<TD class="barra3" style="HEIGHT: 26px" width="11%">Opções:</TD>
				<TD class="barra1" width="89%" colSpan="7">
					<TABLE id="Table3" cellSpacing="5" align="left" border="0">
						<TR>
							<TD>
								<TABLE class="3D" id="Table2" cellSpacing="0" cellPadding="0" border="0">
									<TR>
										<TD onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="cmdNovaClausula" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/Novo.gif" width="16" align="absMiddle">  Nova</asp:linkbutton></TD>
										<TD><asp:linkbutton id="cmdAtualizarClausula" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/S_B_OKAY.gif" width="16" align="absMiddle">  Atualizar</asp:linkbutton></TD>
										<TD>
											<asp:linkbutton id="btnExcluir" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/apagar.gif" width="16" align="absMiddle">  Excluir</asp:linkbutton></TD>
										<TD><asp:linkbutton id="cmdDesativarClausula" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/S_B_CANC.gif" width="16" align="absMiddle">  Desativar</asp:linkbutton></TD>
									</TR>
								</TABLE>
							</TD>
							<TD vAlign="top"><asp:button id="btnTrimestralidade" runat="server" Visible="False" BorderWidth="1px" BorderColor="Gray"
									BorderStyle="Solid" Text="Trimestralidade" Height="25px" Enabled="False"></asp:button></TD>
							<TD vAlign="top"><asp:button id="btnAnualidade" runat="server" Visible="False" BorderWidth="1px" BorderColor="Gray"
									BorderStyle="Solid" Text="Anualidade" Height="25px" Enabled="False"></asp:button></TD>
						</TR>
					</TABLE>
				</TD>
			</TR>
			<TR>
				<TD class="barra3" style="HEIGHT: 14px" width="11%">Cláusula:</TD>
				<TD class="barra1" style="HEIGHT: 14px" width="39%" colSpan="3"><igtxt:webnumericedit id="txtCodClausula" runat="server" CssClass="" Width="50px" Font-Size="11px" Font-Names="Arial"
						DataMode="Int" AutoPostBack="True"></igtxt:webnumericedit><asp:dropdownlist id="ddlClausula" runat="server" CssClass="" Width="200px" Font-Size="11px" Height="19px"
						Font-Names="Arial" AutoPostBack="True"></asp:dropdownlist><asp:label id="lblErrotxtCodClausula" runat="server" Font-Size="Larger" Font-Names="Arial"
						ForeColor="#C00000">*</asp:label></TD>
				<TD class="barra3" style="HEIGHT: 14px" width="11%">Forma de Pgto.:</TD>
				<TD class="barra1" style="HEIGHT: 14px" width="39%" colSpan="3"><igtxt:webnumericedit id="txtCodFormaPagamento" runat="server" CssClass="" Width="50px" Font-Size="11px"
						Font-Names="Arial" DataMode="Int">
						<ClientSideEvents Blur="txtCodFormaPagamento_Blur"></ClientSideEvents>
					</igtxt:webnumericedit><asp:dropdownlist id="ddlFormaPagamento" runat="server" CssClass="" Width="200px" Font-Size="11px"
						Height="19px" Font-Names="Arial"></asp:dropdownlist><asp:label id="lblErrotxtCodFormaPagamento" runat="server" Font-Size="Larger" Font-Names="Arial"
						ForeColor="#C00000">*</asp:label></TD>
			</TR>
			<TR>
				<TD class="barra3" id="TD1" style="HEIGHT: 24px" width="11%" runat="server">Tipo do 
					Período:</TD>
				<TD class="barra1" id="TD2" style="HEIGHT: 24px" width="39%" colSpan="3" runat="server"><igtxt:webnumericedit id="txtTIPPODCTTFRN" runat="server" CssClass="" Width="50px" Font-Size="11px" Font-Names="Arial"
						DataMode="Int">
						<ClientSideEvents Blur="txtTIPPODCTTFRN_Blur"></ClientSideEvents>
					</igtxt:webnumericedit><asp:dropdownlist id="cmbTIPPODCTTFRN" runat="server" CssClass="" Width="200px" Font-Size="11px" Height="19px"
						Font-Names="Arial"></asp:dropdownlist><asp:label id="lblTIPPODCTTFRN" runat="server" Font-Size="Larger" Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
				<TD class="barra3" id="TD3" style="HEIGHT: 24px" width="11%" runat="server"></TD>
				<TD class="barra1" id="TD4" style="HEIGHT: 24px" width="39%" colSpan="3" runat="server"></TD>
			</TR>
			<TR>
				<TD class="barra3" style="HEIGHT: 27px" width="11%">Dest. Verba &nbsp;Fornec.:</TD>
				<TD class="barra1" style="HEIGHT: 27px" width="39%" colSpan="3"><igtxt:webnumericedit id="txtCodDVF" runat="server" CssClass="" Width="50px" Font-Size="11px" Font-Names="Arial"
						DataMode="Int">
						<ClientSideEvents Blur="txtCodDVF_Blur"></ClientSideEvents>
					</igtxt:webnumericedit><asp:dropdownlist id="ddlDVF" runat="server" CssClass="" Width="200px" Font-Size="11px" Height="19px"
						Font-Names="Arial"></asp:dropdownlist><asp:label id="lblErrotxtCodDVF" runat="server" Font-Size="Larger" Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
				<TD class="barra3" style="HEIGHT: 27px" width="11%">Moeda:</TD>
				<TD class="barra1" style="HEIGHT: 27px" width="39%" colSpan="3"><asp:dropdownlist id="ddlMoeda" runat="server" CssClass="" Width="250px" Font-Size="11px" Height="19px"
						Font-Names="Arial"></asp:dropdownlist><asp:label id="lblErroddlMoeda" runat="server" Font-Size="Larger" Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
			</TR>
			<TR>
				<TD class="barra3" style="HEIGHT: 3px" width="11%">Dest. Verba &nbsp;Martins:</TD>
				<TD class="barra1" width="39%" colSpan="3"><igtxt:webnumericedit id="txtCodDVM" runat="server" CssClass="" Width="50px" Font-Size="11px" Font-Names="Arial"
						DataMode="Int">
						<ClientSideEvents Blur="txtCodDVM_Blur"></ClientSideEvents>
					</igtxt:webnumericedit><asp:dropdownlist id="ddlDVM" runat="server" CssClass="" Width="200px" Font-Size="11px" Height="19px"
						Font-Names="Arial"></asp:dropdownlist><asp:label id="lblErrotxtCodDVM" runat="server" Font-Size="Larger" Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
				<TD class="barra3" style="HEIGHT: 3px" width="11%">Dt. Vig. Cláusula:</TD>
				<TD class="barra1" width="39%" colSpan="3"><igtxt:webdatetimeedit id="txtDatVigCsl" runat="server" CssClass="" Width="80px" Font-Size="11px" Font-Names="Arial"
						DisplayModeFormat="d"></igtxt:webdatetimeedit><asp:label id="lblErrotxtDatVigCsl" runat="server" Font-Size="Larger" Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
			</TR>
			<TR>
				<TD class="barra3" width="11%">Perc. Disp. &nbsp;Conta Forn.:</TD>
				<TD class="barra1" width="14%"><igtxt:webpercentedit id="txtPercCtaFrn" runat="server" CssClass="" Width="50px" Font-Size="11px" Font-Names="Arial"></igtxt:webpercentedit><asp:label id="lblErrotxtPercCtaFrn" runat="server" Font-Size="Larger" Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
				<TD class="barra3" width="11%">Dia Venc. Acordo Com.:</TD>
				<TD class="barra1" style="WIDTH: 60px" width="60"><igtxt:webnumericedit id="txtDiaVencAco" runat="server" CssClass="" Width="50px" Font-Size="11px" Font-Names="Arial"
						DataMode="Int"></igtxt:webnumericedit><asp:label id="lblErrotxtDiaVencAco" runat="server" Font-Size="Larger" Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
				<TD class="barra3" width="11%">Tipo de Desconto:</TD>
				<TD class="barra1" width="14%"><igtxt:webnumericedit id="txtTipDsc" runat="server" CssClass="" Width="80px" Font-Size="11px" Font-Names="Arial"></igtxt:webnumericedit><asp:label id="lblErrotxtTipDsc" runat="server" Font-Size="Larger" Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
				<TD class="barra1" width="11%"></TD>
				<TD class="barra1" width="14%"></TD>
			</TR>
			<TR>
				<TD class="barra3" width="11%">Gerar Acordo Comercial:</TD>
				<TD class="barra1" width="14%"><asp:checkbox id="chkGeraAco" runat="server" Font-Size="11px" Font-Names="Arial" AutoPostBack="True"></asp:checkbox></TD>
				<TD class="barra3" width="11%">Desc. Autom. Pedido:</TD>
				<TD class="barra1" style="WIDTH: 60px" width="60"><asp:checkbox id="chkFlgDscAut" runat="server" Font-Size="11px" Font-Names="Arial"></asp:checkbox></TD>
				<TD class="barra1" width="11%" colSpan="4"></TD>
			</TR>
			<TR>
				<TD class="barra3" width="11%">Observação:</TD>
				<TD class="barra1" width="89%" colSpan="7"><asp:textbox id="txtObs" runat="server" CssClass="" Width="100%" Font-Size="11px" Font-Names="Arial"
						Rows="2" TextMode="MultiLine"></asp:textbox></TD>
			</TR>
			<TR>
				<TD class="barra3" width="11%">Mês Ref. p/ Apuração:</TD>
				<TD class="barra1" width="14%"><asp:dropdownlist id="ddlDatRefApuPodCslCtt" runat="server" CssClass="" Width="100%" Font-Size="11px"
						Height="19px" Font-Names="Arial" AutoPostBack="True">
						<asp:ListItem Value="  " Selected="True"></asp:ListItem>
						<asp:ListItem Value="1">Janeiro</asp:ListItem>
						<asp:ListItem Value="2">Fevereiro</asp:ListItem>
						<asp:ListItem Value="3">Mar&#231;o</asp:ListItem>
						<asp:ListItem Value="4">Abril</asp:ListItem>
						<asp:ListItem Value="5">Maio</asp:ListItem>
						<asp:ListItem Value="6">Junho</asp:ListItem>
						<asp:ListItem Value="7">Julho</asp:ListItem>
						<asp:ListItem Value="8">Agosto</asp:ListItem>
						<asp:ListItem Value="9">Setembro</asp:ListItem>
						<asp:ListItem Value="10">Outubro</asp:ListItem>
						<asp:ListItem Value="11">Novembro</asp:ListItem>
						<asp:ListItem Value="12">Dezembro</asp:ListItem>
					</asp:dropdownlist><asp:label id="lblErroddlDatRefApuPodCslCtt" runat="server" Font-Size="Larger" Visible="False"
						Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
				<TD class="barra3" width="11%">Qtd. Meses p/ Cálc. Média:</TD>
				<TD class="barra1" style="WIDTH: 60px" width="60"><igtxt:webpercentedit id="txtQdeMesApuMedPod" runat="server" CssClass="" Width="80px" Font-Size="11px"
						Font-Names="Arial"></igtxt:webpercentedit><asp:label id="lblErrotxtQdeMesApuMedPod" runat="server" Font-Size="Larger" Visible="False"
						Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
				<TD class="barra3" width="11%">Tipo Limite p/ Cálculo:</TD>
				<TD class="barra1" width="14%"><asp:dropdownlist id="ddlTipLimCalPod" runat="server" CssClass="" Width="100%" Font-Size="11px" Height="19px"
						Font-Names="Arial" AutoPostBack="True">
						<asp:ListItem Value=" " Selected="True"></asp:ListItem>
						<asp:ListItem Value="1">Percentual</asp:ListItem>
						<asp:ListItem Value="2">Valor</asp:ListItem>
					</asp:dropdownlist>&nbsp;
					<asp:label id="lblErroddlTipLimCalPod" runat="server" Font-Size="Larger" Visible="False" Font-Names="Arial"
						ForeColor="#C00000">*</asp:label></TD>
				<TD class="barra3" width="11%">Vlr. Limite p/ Cálculo:</TD>
				<TD class="barra1" width="14%"><igtxt:webnumericedit id="txtVlrLimFatcalPod" runat="server" CssClass="" Width="80px" Font-Size="11px"
						Font-Names="Arial"></igtxt:webnumericedit><asp:label id="lblErrotxtVlrLimFatcalPod" runat="server" Font-Size="Larger" Visible="False"
						Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
			</TR>
			<TR>
				<TD class="barra3" width="11%">Qtd. Mín. Ítens Bonif.:</TD>
				<TD class="barra1" width="14%"><igtxt:webnumericedit id="txtQdeIteVarMix" runat="server" CssClass="" Width="60px" Font-Size="11px" Font-Names="Arial"></igtxt:webnumericedit><asp:label id="lblErrotxtQdeIteVarMix" runat="server" Font-Size="Larger" Visible="False" Font-Names="Arial"
						ForeColor="#C00000">*</asp:label></TD>
				<TD class="barra3" width="11%">Perc. Mínimo Bonificação:</TD>
				<TD class="barra1" style="WIDTH: 60px" width="60"><igtxt:webpercentedit id="txtPerIteVarMix" runat="server" CssClass="" Width="80px" Font-Size="11px" Font-Names="Arial"></igtxt:webpercentedit><asp:label id="lblErrotxtPerIteVarMix" runat="server" Font-Size="Larger" Visible="False" Font-Names="Arial"
						ForeColor="#C00000">*</asp:label></TD>
				<TD class="barra3" width="11%">Qtd. Pedidos no Período:</TD>
				<TD class="barra1" width="14%"><igtxt:webnumericedit id="txtQdePedPodApuCsl" runat="server" CssClass="" Width="60px" Font-Size="11px"
						Font-Names="Arial"></igtxt:webnumericedit><asp:label id="lblErrotxtQdePedPodApuCsl" runat="server" Font-Size="Larger" Visible="False"
						Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
				<TD class="barra1" width="11%"></TD>
				<TD class="barra1" width="14%"></TD>
			</TR>
		</TBODY>
	</TABLE>
</HTML>
