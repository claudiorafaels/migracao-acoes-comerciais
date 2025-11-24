<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucContratoFormaDePagamento.ascx.vb" Inherits="Martins.Web.UI.AcoesComerciais.ucContratoFormaDePagamento" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
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
	<LINK href="styles_Formas.css" type="text/css" rel="stylesheet">
	<TABLE class="Forma1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
		<TBODY>
			<TR>
				<TD class="barra3" width="11%"></TD>
				<TD class="barra3" width="39%">
					<P align="left">Existente:</P>
				</TD>
				<TD class="barra3" width="11%"></TD>
				<TD class="barra3" width="39%">
					<P align="left">Do Contrato:</P>
				</TD>
			</TR>
			<TR>
				<TD class="barra3" width="11%">Unidade Pagadora</TD>
				<TD class="barra1" width="39%"><asp:listbox id="lboTIPUNDPGTCTTFRN_existente" runat="server" CssClass="" Width="100%"
						Font-Names="Arial" Font-Size="11px"></asp:listbox></TD>
				<TD class="barra3" width="11%">
					<P align="center"><asp:button id="btnIncluirUnidadePagadora" runat="server" Text=">" ToolTip="Incluir unidade pagadora"></asp:button><br>
						<asp:button id="btnExcluirUnidadePagadora" runat="server" Text="<" ToolTip="Excluir unidade pagadora"></asp:button></P>
				</TD>
				<TD class="barra1" width="39%"><asp:listbox id="lboTIPUNDPGTCTTFRN" runat="server" CssClass="" Width="100%" Font-Names="Arial"
						Font-Size="11px"></asp:listbox></TD>
			</TR>
			<TR>
				<TD class="barra1" width="11%" style="HEIGHT: 3px"></TD>
				<TD class="barra1" width="39%" style="HEIGHT: 3px"></TD>
				<TD class="barra1" width="11%" style="HEIGHT: 3px"></TD>
				<TD class="barra1" width="39%" style="HEIGHT: 3px"></TD>
			</TR>
			<TR>
				<TD class="barra3" style="HEIGHT: 16px" width="11%">Tipo de Pag. Not.:</TD>
				<TD class="barra1" style="HEIGHT: 16px" width="39%"><asp:dropdownlist id="cmbTIPFRNCTTFRN" runat="server" CssClass=" " Width="90%" Font-Names="Arial"
						Font-Size="11px">
						<asp:ListItem Value="0">&lt;--Selecione--&gt;</asp:ListItem>
						<asp:ListItem Value="1">Boleta Banc&#225;ria</asp:ListItem>
						<asp:ListItem Value="2">Cr&#233;dito Conta Corrente</asp:ListItem>
						<asp:ListItem Value="3">Outros</asp:ListItem>
					</asp:dropdownlist></TD>
				<TD class="barra3" style="HEIGHT: 16px" width="11%">Tipo de Fornecedor:</TD>
				<TD class="barra1" style="HEIGHT: 16px" width="39%"><asp:dropdownlist id="cmbTIPPGTNOTFSCCTTFRN" runat="server" CssClass=" " Width="90%" Font-Names="Arial"
						Font-Size="11px">
						<asp:ListItem Value="0">&lt;--Selecione--&gt;</asp:ListItem>
						<asp:ListItem Value="1">Consumo</asp:ListItem>
						<asp:ListItem Value="2">Produtos</asp:ListItem>
						<asp:ListItem Value="3">Revenda</asp:ListItem>
						<asp:ListItem Value="4">Servi&#231;o</asp:ListItem>
						<asp:ListItem Value="5">Outros</asp:ListItem>
					</asp:dropdownlist></TD>
			</TR>
			<TR>
				<TD class="barra3" style="HEIGHT: 18px" width="11%">Banco:</TD>
				<TD class="barra1" style="HEIGHT: 18px" width="39%"><asp:dropdownlist id="cmbCODBCOCTTFRN" runat="server" CssClass=" " Width="90%" AutoPostBack="True"
						Font-Names="Arial" Font-Size="11px"></asp:dropdownlist><asp:label id="lblErroCODBCOCTTFRN" runat="server" Font-Size="Larger" Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
				<TD class="barra3" style="HEIGHT: 18px" width="11%">Agencia:</TD>
				<TD class="barra1" style="HEIGHT: 18px" width="39%"><asp:dropdownlist id="cmbCODAGEBCOCTTFRN" runat="server" CssClass=" " Width="90%" Font-Names="Arial"
						Font-Size="11px"></asp:dropdownlist><asp:label id="lblErroCODAGEBCOCTTFRN" runat="server" Font-Size="Larger" Font-Names="Arial"
						ForeColor="#C00000">*</asp:label></TD>
			</TR>
			<TR>
				<TD class="barra3" width="11%">Conta Corrente:</TD>
				<TD class="barra1" width="39%"><asp:textbox id="txtCODCNTCRRBCOCTTFRN" runat="server" CssClass=" " Width="100px" Font-Names="Arial"
						Font-Size="11px"></asp:textbox><asp:label id="lblErroCODCNTCRRBCOCTTFRN" runat="server" Font-Size="Larger" Font-Names="Arial"
						ForeColor="#C00000">*</asp:label></TD>
				<TD class="barra1" width="11%"></TD>
				<TD class="barra1" width="39%"></TD>
			</TR>
			<TR>
				<TD class="barra3" width="11%">Observação:</TD>
				<TD class="barra1" width="89%" colSpan="3"><asp:textbox id="txtDESOBSFRMPGTCTTFRN" runat="server" CssClass="" Width="100%" Rows="3"
						TextMode="MultiLine" Font-Size="11px" Font-Names="Arial" MaxLength="254"></asp:textbox></TD>
			</TR>
		</TBODY>
	</TABLE>
</HTML>
