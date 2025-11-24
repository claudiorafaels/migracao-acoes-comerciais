<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="AppComponents/wucFornecedor.ascx" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucContratoCondicaoPagamento.ascx.vb" Inherits="Martins.Web.UI.AcoesComerciais.ucContratoCondicaoPagamento" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
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
				<TD class="barra3" width="11%">Prazo Pagamento</TD>
				<TD class="barra1" width="39%"><igtxt:webnumericedit id="txtNUMDIAPRZPGTCTTFRN" CssClass="" Width="60px" runat="server" Font-Names="Arial"
						Font-Size="11px"></igtxt:webnumericedit>&nbsp;
					<asp:label id="Label1" runat="server" ForeColor="Black">Dias</asp:label><asp:label id="lblErroNUMDIAPRZPGTCTTFRN" runat="server" ForeColor="#C00000" Font-Size="Larger"
						Font-Names="Arial">*</asp:label></TD>
				<TD class="barra3" width="11%">Modalidade Pagamento</TD>
				<TD class="barra1" width="39%"><asp:dropdownlist id="cmbTIPFRMPGTCTTFRN" CssClass="" Width="80px" runat="server" Height="19px"
						Font-Size="11px" Font-Names="Arial">
						<asp:ListItem Value="0"></asp:ListItem>
						<asp:ListItem Value="1">D.D.E</asp:ListItem>
						<asp:ListItem Value="2">D.D.N</asp:ListItem>
						<asp:ListItem Value="3">D.D.F</asp:ListItem>
					</asp:dropdownlist><asp:label id="lblErroTIPFRMPGTCTTFRN" runat="server" ForeColor="#C00000" Font-Size="Larger"
						Font-Names="Arial">*</asp:label></TD>
			</TR>
			<TR>
				<TD class="barra3" width="11%">Desc. Financeiro:</TD>
				<TD class="barra1" width="39%"><igtxt:webpercentedit id="txtPERDSCFINCTTFRN" CssClass="" Width="60px" runat="server" Font-Names="Arial"
						Font-Size="11px"></igtxt:webpercentedit></TD>
				<TD class="barra1" width="11%"></TD>
				<TD class="barra1" width="39%"></TD>
			</TR>
			<TR>
				<TD class="barra3" width="11%">Encargos Finac.:</TD>
				<TD class="barra1" width="39%"><igtxt:webpercentedit id="txtPERENCFINCTTFRN" CssClass="" Width="60px" runat="server" Font-Names="Arial"
						Font-Size="11px"></igtxt:webpercentedit></TD>
				<TD class="barra3" width="11%">
					<P>Periodicidade do Encargo</P>
				</TD>
				<TD class="barra1" width="39%"><asp:dropdownlist id="cmbTIPENCFINCTTFRN" CssClass="" Width="80px" runat="server" Height="19px"
						Font-Size="11px" Font-Names="Arial">
						<asp:ListItem Value="0"></asp:ListItem>
						<asp:ListItem Value="1">P.M</asp:ListItem>
						<asp:ListItem Value="2">P.A</asp:ListItem>
						<asp:ListItem Value="3">P.P</asp:ListItem>
					</asp:dropdownlist><asp:label id="lblErroTIPENCFINCTTFRN" runat="server" ForeColor="#C00000" Font-Size="Larger"
						Font-Names="Arial">*</asp:label></TD>
			</TR>
			<TR>
				<TD class="barra3" width="11%">Observação:</TD>
				<TD class="barra1" width="89%" colSpan="3"><asp:textbox id="txtDESOBSCNDPGTCTTFRN" CssClass="" Width="100%" runat="server" Rows="3"
						TextMode="MultiLine" Font-Names="Arial" Font-Size="11px" MaxLength="254"></asp:textbox></TD>
			</TR>
		</TBODY>
	</TABLE>
</HTML>
