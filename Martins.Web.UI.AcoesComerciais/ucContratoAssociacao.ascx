<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="cc1" Namespace="ControleMessageBox" Assembly="ControleMessageBox" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucContratoAssociacao.ascx.vb" Inherits="Martins.Web.UI.AcoesComerciais.ucContratoAssociacao" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
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

function txtNUMCSLCTTFRN_Blur(oEdit, text, oEvent){
   document.getElementById('webTab__ctl6_ucContratoAssociacao_cmbNUMCSLCTTFRN').value = text;
}

//-->
	</script>
	<script language="javascript">
		history.forward();
	</script>
	<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
		<TBODY>
			<TR>
				<TD class="barra3" width="11%" id="TD1" runat="server">Opções:</TD>
				<TD class="barra1" width="89%" colSpan="7" id="TD2" runat="server">
					<TABLE class="3D" id="Table2" cellSpacing="0" cellPadding="0" border="0">
						<TR>
							<TD><asp:linkbutton id="btnAlterar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/S_B_OKAY.gif" width="16" align="absMiddle">  Alterar</asp:linkbutton></TD>
							<TD></TD>
						</TR>
					</TABLE>
					<cc1:MessageBox id="MessageBox1" runat="server"></cc1:MessageBox>
				</TD>
			</TR>
			<TR>
				<TD class="barra3" width="11%">Cláusula</TD>
				<TD class="barra1" width="89%" colSpan="7"><igtxt:webnumericedit id="txtNUMCSLCTTFRN" Font-Names="Arial" runat="server" CssClass="" Width="50px"
						Font-Size="11px">
						<ClientSideEvents Blur="txtNUMCSLCTTFRN_Blur"></ClientSideEvents>
					</igtxt:webnumericedit><asp:dropdownlist id="cmbNUMCSLCTTFRN" Font-Names="Arial" runat="server" CssClass="" Width="250px"
						Font-Size="11px" Height="19px" AutoPostBack="True"></asp:dropdownlist><asp:label id="lblErroNUMCSLCTTFRN" Font-Names="Arial" runat="server" Font-Size="Larger" ForeColor="#C00000">*</asp:label></TD>
			</TR>
			<TR>
				<TD class="barra3" width="11%">Associacões do Contrato:</TD>
				<TD class="barra1" width="89%" colSpan="7">
					<P>
						<asp:Label id="lblTipoFornecedor" runat="server" ForeColor="Black">Label</asp:Label></P>
					<P><asp:datagrid id=grdContratosAssociados runat="server" CssClass=" " Width="100%" Font-Size="X-Small" DataSource="<%# DatasetContrato1 %>" DataMember="TbPRCDLCnsAscCslFrn" AutoGenerateColumns="False" PageSize="13" AllowPaging="True">
							<AlternatingItemStyle CssClass="row4"></AlternatingItemStyle>
							<ItemStyle CssClass="row3"></ItemStyle>
							<HeaderStyle CssClass="header1"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="&lt;img src=../Imagens/office/janelas.gif alt=Associacao border=0&gt;" CommandName="lnkAssociacao"></asp:ButtonColumn>
								<asp:BoundColumn DataField="CODFRN" SortExpression="CODFRN" HeaderText="COD. FORN." DataFormatString="{0:###,##0}"></asp:BoundColumn>
								<asp:BoundColumn DataField="NOMFRN" SortExpression="NOMFRN" HeaderText="NOME FORNECEDOR"></asp:BoundColumn>
								<asp:BoundColumn DataField="NUMCTTFRN" SortExpression="NUMCTTFRN" HeaderText="CONTRATO" DataFormatString="{0:###,###,##0}"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="INDGRP" SortExpression="INDGRP" HeaderText="INDGRPAtual"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="INDGRP" SortExpression="INDGRP" HeaderText="INDGRPAnterior"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="ASSOCIA&#199;&#195;O">
									<ItemTemplate>
										<asp:Label id=Label1 runat="server" Text='<%# consultarDescricaoAssociacao(DataBinder.Eval(Container, "DataItem.INDGRP")) %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox id=TextBox1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.INDGRP") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle VerticalAlign="Middle" Height="20px" HorizontalAlign="Center" PageButtonCount="9"
								CssClass=" " Mode="NumericPages"></PagerStyle>
						</asp:datagrid></P>
				</TD>
			</TR>
		</TBODY>
	</TABLE>
</HTML>
