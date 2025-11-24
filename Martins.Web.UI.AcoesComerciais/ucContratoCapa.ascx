<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="AppComponents/wucFornecedor.ascx" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucContratoCapa.ascx.vb" Inherits="Martins.Web.UI.AcoesComerciais.ucContratoCapa" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
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
	<script language="javascript">
		history.forward();
	</script>
	<LINK href="styles_tabelas.css" type="text/css" rel="stylesheet">
	<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
		<TBODY>
			<TR>
				<TD class="barra3" width="14%">
					<P align="right">Dt. Vigoração:</P>
				</TD>
				<TD class="barra1" width="20%"><igtxt:webdatetimeedit id="txtDatIniPodVgrCttFrn" Font-Size="11px" Font-Names="Arial" EditModeFormat="dd/MM/yyyy"
						Width="80px" DisplayModeFormat="dd/MM/yyyy" CssClass=" " runat="server"></igtxt:webdatetimeedit><asp:label id="lblErrotxtDatIniPodVgrCttFrn" Font-Size="Larger" Font-Names="Arial" runat="server"
						ForeColor="#C00000">*</asp:label></TD>
				<TD class="barra3" width="13%">
					<P align="right">Dt. Vencimento:</P>
				</TD>
				<TD class="barra1" width="20%"><igtxt:webdatetimeedit id="txtDatVen" Font-Size="11px" Font-Names="Arial" EditModeFormat="dd/MM/yyyy" Width="80px"
						DisplayModeFormat="dd/MM/yyyy" CssClass=" " runat="server" ReadOnly="True"></igtxt:webdatetimeedit></TD>
				<TD class="barra3" align="right" width="13%">Prorrogar Vencimento:</TD>
				<TD class="barra1" width="20%"><asp:checkbox id="chkPrgVen" Font-Size="11px" Font-Names="Arial" runat="server" ForeColor="Black"
						Checked="True"></asp:checkbox></TD>
			</TR>
			<TR>
				<TD class="barra3" width="14%">
					<P align="right">Dt. Desativ.:</P>
				</TD>
				<TD class="barra1" width="20%"><igtxt:webdatetimeedit id="txtDatDstCttFrn" Font-Size="11px" Font-Names="Arial" EditModeFormat="dd/MM/yyyy"
						Width="80px" DisplayModeFormat="dd/MM/yyyy" CssClass=" " runat="server" ReadOnly="True"></igtxt:webdatetimeedit></TD>
				<TD class="barra3" width="13%">
					<P align="right">Apurar período anterior:</P>
				</TD>
				<TD class="barra1" width="20%"><asp:checkbox id="chkPerApu" Font-Size="11px" Font-Names="Arial" runat="server" ForeColor="Black"></asp:checkbox></TD>
				<TD class="barra3" align="right" width="13%">Períodicidade:</TD>
				<TD class="barra1" width="20%"><asp:dropdownlist id="ddlProPer" Font-Size="11px" Font-Names="Arial" Width="144px" CssClass=" " runat="server"></asp:dropdownlist><asp:label id="lblErroddlProPer" Font-Size="Larger" Font-Names="Arial" runat="server" ForeColor="#C00000">*</asp:label></TD>
			</TR>
			<TR>
				<TD class="barra3" width="14%">Aviso de Renovação:</TD>
				<TD class="barra1" width="20%" colSpan="5"><asp:checkbox id="chkAvisoRenovacao" Font-Size="11px" Font-Names="Arial" runat="server" ForeColor="Black"
						AutoPostBack="True"></asp:checkbox></TD>
			</TR>
			<TR id="TRDataAviso" runat="server">
				<TD class="barra3" width="14%">Data de Aviso:</TD>
				<TD class="barra1" width="20%" colSpan="5"><igtxt:webdatetimeedit id="txtDataAviso" Font-Size="11px" Font-Names="Arial" EditModeFormat="dd/MM/yyyy"
						Width="80px" DisplayModeFormat="dd/MM/yyyy" CssClass=" " runat="server" AutoPostBack="True" PromptChar=" "></igtxt:webdatetimeedit></TD>
			</TR>
			<TR>
				<TD class="barra3" width="14%">
					<P align="right">Tipo Contrato:</P>
				</TD>
				<TD class="barra1" width="20%"><asp:dropdownlist id="ddlTipCttFrn" Font-Size="11px" Font-Names="Arial" Width="144px" CssClass=" "
						runat="server"></asp:dropdownlist></TD>
				<TD class="barra3" width="13%">
					<P align="right">Qtd ítens catalogo:</P>
				</TD>
				<TD class="barra1" width="20%"><igtxt:webnumericedit id="txtQtdIteCtlFrn" Font-Size="11px" Font-Names="Arial" Width="64px" CssClass=" "
						runat="server" ValueText="1"></igtxt:webnumericedit></TD>
				<TD class="barra3" align="right" width="13%">Cálculo PIS / COFINS</TD>
				<TD class="barra1" width="20%">
					<P><asp:checkbox id="chkIndApuPisCttFrn" Font-Size="11px" Font-Names="Arial" runat="server" ForeColor="Black"
							Text="Normal"></asp:checkbox><BR>
						<asp:checkbox id="chkIndApuPisNcmCttFrn" Font-Size="11px" Font-Names="Arial" runat="server" ForeColor="Black"
							Text="NCM"></asp:checkbox></P>
				</TD>
			</TR>
			<TR>
				<TD class="barra3" width="14%">
					<P align="right">Linha de produtos:</P>
				</TD>
				<TD class="barra1" width="86%" colSpan="5"><asp:textbox id="txtDesLnhPrdCttFrn" Font-Size="11px" Font-Names="Arial" Width="100%" runat="server"
						TextMode="MultiLine"></asp:textbox></TD>
			</TR>
			<TR>
				<TD class="barra3" width="14%">
					<P align="right">Descontos Comerciais Permanentes?</P>
				</TD>
				<TD class="barra1" width="20%"><asp:dropdownlist id="ddlIndDscCmcPet" Font-Size="11px" Font-Names="Arial" Width="60px" CssClass=" "
						runat="server">
						<asp:ListItem Value="1">SIM</asp:ListItem>
						<asp:ListItem Value="0">NAO</asp:ListItem>
					</asp:dropdownlist></TD>
				<TD class="barra3" width="13%">
					<P align="right">Observação:</P>
				</TD>
				<TD class="barra1" width="53%" colSpan="3"><asp:textbox id="txtDesObsDescCmcPet" Font-Size="11px" Font-Names="Arial" Width="100%" runat="server"
						TextMode="MultiLine"></asp:textbox></TD>
			</TR>
			<TR>
				<TD class="barra1" width="100%" colSpan="6"></TD>
			</TR>
			<TR>
				<TD class="barra1" width="100%" colSpan="6"><asp:label id="Label2" CssClass=" " runat="server" ForeColor="Black">Condições de Devolução</asp:label></TD>
			</TR>
			<TR>
				<TD class="barra3" width="14%">
					<P align="right">Prazo Produto à Vencer:</P>
				</TD>
				<TD class="barra1" width="20%"><igtxt:webnumericedit id="txtPrzProVec" Font-Size="11px" Font-Names="Arial" Width="60px" runat="server"></igtxt:webnumericedit>&nbsp;
					<asp:label id="Label1" runat="server" ForeColor="Black">Dias</asp:label></TD>
				<TD class="barra3" align="right" width="13%">Aceita Troca:</TD>
				<TD class="barra1" width="20%"><asp:dropdownlist id="ddlAceTrc" Font-Size="11px" Font-Names="Arial" Width="60px" CssClass=" " runat="server">
						<asp:ListItem Value="1">SIM</asp:ListItem>
						<asp:ListItem Value="0">NAO</asp:ListItem>
					</asp:dropdownlist></TD>
				<TD class="barra3" align="right" width="13%">Tipo de Ressarcimento:</TD>
				<TD class="barra1" width="20%"><asp:dropdownlist id="ddlTipRess" Font-Size="11px" Font-Names="Arial" Width="100%" CssClass=" " runat="server"></asp:dropdownlist></TD>
			</TR>
			<TR>
				<TD class="barra3" width="14%">
					<P align="right">Tipo de Frete Devolução:</P>
				</TD>
				<TD class="barra1" width="20%"><asp:dropdownlist id="ddlTipFreDev" Font-Size="11px" Font-Names="Arial" Width="100%" CssClass=" "
						runat="server">
						<asp:ListItem></asp:ListItem>
						<asp:ListItem Value="C">C.I.F</asp:ListItem>
						<asp:ListItem Value="F">F.O.B</asp:ListItem>
					</asp:dropdownlist></TD>
				<TD class="barra3" align="right" width="13%">Observação:</TD>
				<TD class="barra1" width="53%" colSpan="3"><asp:textbox id="txtDesObsDvlMer" Font-Size="11px" Font-Names="Arial" Width="100%" runat="server"
						TextMode="MultiLine"></asp:textbox></TD>
			</TR>
		</TBODY>
	</TABLE>
</HTML>
