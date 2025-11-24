<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucContratoTabelaDePrecos.ascx.vb" Inherits="Martins.Web.UI.AcoesComerciais.ucContratoTabelaDePrecos" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
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
	<script language="javascript">
		history.forward();
	</script>		
	<LINK href="styles_tabelas.css" type="text/css" rel="stylesheet">
	<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
		<TBODY>
			<TR>
				<TD class="barra3" width="11%">
					Abrangência:</TD>
				<TD class="barra1" width="39%">
					<asp:dropdownlist id="cmbTIPABGTABPCOCTTFRN" runat="server" Font-Names="Arial" Font-Size="11px" CssClass=""
						Width="150px" Height="19px">
						<asp:ListItem Value="0">&lt;--Selecione--&gt;</asp:ListItem>
						<asp:ListItem Value="1">Internacional</asp:ListItem>
						<asp:ListItem Value="2">Nacional</asp:ListItem>
						<asp:ListItem Value="3">Outros</asp:ListItem>
					</asp:dropdownlist>
					<asp:label id="lblErroTIPABGTABPCOCTTFRN" Font-Size="Larger" Font-Names="Arial" runat="server"
						ForeColor="#C00000">*</asp:label></TD>
				<TD class="barra3" width="11%">Pré - Aviso Atualização da Tabela de Preços:</TD>
				<TD class="barra1" width="39%">
					<igtxt:WebNumericEdit id="txtNUMDIAATLTABPCOFRN" runat="server" CssClass="" Width="60px" Font-Size="11px"
						Font-Names="Arial"></igtxt:WebNumericEdit>&nbsp;
					<asp:Label id="Label1" runat="server" ForeColor="Black">Dias</asp:Label></TD>
			</TR>
			<TR>
				<TD class="barra3" width="11%">Diferenciação de Alíquota ?</TD>
				<TD class="barra1" width="39%">
					<asp:DropDownList id="cmbINDDIFALQICMCTTFRN" runat="server" CssClass=" " Width="60px" Font-Size="11px"
						Font-Names="Arial">
						<asp:ListItem Value="1">SIM</asp:ListItem>
						<asp:ListItem Value="0">NAO</asp:ListItem>
					</asp:DropDownList></TD>
				<TD class="barra3" width="11%">Diferenciação de Canais de Venda ?</TD>
				<TD class="barra1" width="39%">
					<asp:DropDownList id="cmbINDDIFCNLVNDCTTFRN" runat="server" CssClass=" " Width="60px" Font-Size="11px"
						Font-Names="Arial">
						<asp:ListItem Value="1">SIM</asp:ListItem>
						<asp:ListItem Value="0">NAO</asp:ListItem>
					</asp:DropDownList></TD>
			</TR>
			<TR>
				<TD class="barra3" width="11%">Observação:</TD>
				<TD class="barra1" width="89%" colSpan="3">
					<asp:textbox id="txtDESOBSTABPCOCTTFRN" runat="server" CssClass="" Width="100%" TextMode="MultiLine"
						Rows="3" Font-Size="11px" Font-Names="Arial" MaxLength="254"></asp:textbox></TD>
			</TR>
		</TBODY>
	</TABLE>
</HTML>
