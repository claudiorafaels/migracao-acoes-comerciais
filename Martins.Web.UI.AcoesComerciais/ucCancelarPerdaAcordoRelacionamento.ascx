<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="AppComponents/wucFornecedor.ascx" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtab" Namespace="Infragistics.WebUI.UltraWebTab" Assembly="Infragistics.WebUI.UltraWebTab.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucCancelarPerdaAcordoRelacionamento.ascx.vb" Inherits="Martins.Web.UI.AcoesComerciais.ucCancelarPerdaAcordoRelacionamento" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="uc1" TagName="ucCancelarPerdaAcordoRelacionamentoAtivo" Src="ucCancelarPerdaAcordoRelacionamentoAtivo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucCancelarPerdaAcordoRelacionamentoDesativado" Src="ucCancelarPerdaAcordoRelacionamentoDesativado.ascx" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
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
//-->
	</script>
	<script language="javascript">
		history.forward();
	</script>	
	<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
		<TBODY>
			<TR>
				<TD class="barra1" style="HEIGHT: 41px" width="100%" colSpan="5">
					<P>
						<igtab:UltraWebTab id="webTab" runat="server" Width="100%" BorderStyle="Solid" DisplayMode="Scrollable"
							BarHeight="4" Font-Bold="True" ForeColor="Gray" Font-Names="Verdana" AutoPostBack="True" CssClass="submenu2">
							<DefaultTabStyle>
								<Padding Bottom="2px" Left="3px" Top="2px" Right="3px"></Padding>
							</DefaultTabStyle>
							<SelectedTabStyle ForeColor="Black"></SelectedTabStyle>
							<Tabs>
								<igtab:Tab Text="Ativo" Tooltip="Cl&#225;usula"></igtab:Tab>
								<igtab:TabSeparator>
									<Style Width="2px">
									</Style>
								</igtab:TabSeparator>
								<igtab:Tab Text="Desativa&#231;&#227;o" Tooltip="Abrangencia"></igtab:Tab>
							</Tabs>
						</igtab:UltraWebTab>
						<uc1:ucCancelarPerdaAcordoRelacionamentoAtivo id="UcCancelarPerdaAcordoRelacionamentoAtivo" runat="server"></uc1:ucCancelarPerdaAcordoRelacionamentoAtivo>
						<uc1:ucCancelarPerdaAcordoRelacionamentoDesativado id="UcCancelarPerdaAcordoRelacionamentoDesativado" runat="server" Visible="False"></uc1:ucCancelarPerdaAcordoRelacionamentoDesativado></P>
				</TD>
			</TR>
		</TBODY>
	</TABLE>
</HTML>
