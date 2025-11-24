<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RelacaoGrupoMktListar.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.RelacaoGrupoMktListar" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="martinscontrols" Namespace="Martins.Web.UI.Controls" Assembly="Martins.Web.UI.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=e9ed78c287a2fd3c" %>
<%@ Register TagPrefix="igcmbo" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igsch" Namespace="Infragistics.WebUI.WebSchedule" Assembly="Infragistics.WebUI.WebDateChooser.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="uc1" TagName="ucGrupoEconomico" Src="../Controles/ucGrupoEconomico.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucGrupoMarketing" Src="../Controles/ucGrupoMarketing.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Martins</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../../../../Imagens/Styles.css" type="text/css" rel="stylesheet">
		<LINK href="styles_tabelas.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY onload="MM_preloadImages('../../../../Imagens/lastpost.gif')">
		<meta content="False" name="vs_snapToGrid">
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script event="onreadystatechange" for="document">
			if (readyState == 'complete'){
				escondeAndamento();
			} else {
				mostraAndamento();			
			}
		</script>
		<script language="JScript" event="onkeyup" for="document"> 
			autoTab(); 
		</script>
		<SCRIPT language="JavaScript" src="../../../../Imagens/controle.js" type="text/javascript">
		</SCRIPT>
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

function escondeAndamento() {
	window.MM_findObj('tdEspera').style.display = 'none';
	window.MM_findObj('tbOpcoes').style.display = 'inline';
	return true;
}

function mostraAndamento() {
	window.MM_findObj('tdEspera').style.display = 'inline';
	window.MM_findObj('tbOpcoes').style.display = 'none';
	return true;   
}

function CarregaTelaIncluirIndicadorAcordo(){
  escondeAndamento();
  window.showModalDialog('IncluirIndicadorAcordo.aspx','window','help:no;status:no;scroll:no;edge:raised;dialogWidth:400px;edge:raised;dialogHeight:120px');
  __doPostBack('lkbProcessaCloseModalIncluirIndicadorAcordo','');
}

//-->
		</script>
		<script language="javascript">
			history.forward();
		</script>
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="10" border="0">
				<tr>
					<td><A href="javascript:parent.resizeFrame('5,*')"><IMG id="Image1" onmouseover="MM_swapImage('Image1','','../../../../Imagens/lastpost.gif',1)"
								onmouseout="MM_swapImage('Image1','','../../../../Imagens/lastpost_l.gif',1)" height="12" src="../../../../Imagens/lastpost_l.gif"
								width="12" name="Image1"></A>
					</td>
				</tr>
			</table>
			<table style="WIDTH: 100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tbody>
					<tr>
						<td class="submenu2" vAlign="top">
							<table id="tbOpcoes" cellSpacing="0" cellPadding="0" border="0" runat="server">
								<tr>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnPesquisar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
														Width="64px"><img src="../../Imagens/office/procurar.gif" width="16" height="16" align="absMiddle">Pesquisar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="btnImportar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
														Width="64px"><img src="../../imagens/office/excel.gif" width="16" height="16" align="absMiddle"> Importar</asp:linkbutton></td>
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
									<TR id="trEspera" runat="server">
										<TD class="barra1" id="TDEspera" align="left" width="50%" height="19" runat="server">
											<DIV id="Div1" align="left" runat="server"><asp:image id="Image2" runat="server" ImageUrl="../../../../Imagens/espera.gif"></asp:image>&nbsp;Carregando...
											</DIV>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
						</td>
					</tr>
					<tr>
						<td class="darkbox" vAlign="top">
							<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TBODY>
									<TR>
										<TD class="barra3" width="10%">Arquivo:</TD>
										<TD class="barra1" width="90%" colSpan="3"><INPUT language="vb" class="lightbox " id="Plan" style="WIDTH: 520px; HEIGHT: 20px" type="file"
												size="67" name="Plan" runat="server"></TD>
									</TR>
									<TR id="TRCodigoGrupoEconomico" runat="server">
										<TD class="barra3" width="10%">
											Grupo Econômico:</TD>
										<TD class="barra1" width="90%" colSpan="3">
											<uc1:ucGrupoEconomico id="UcGrupoEconomico" runat="server"></uc1:ucGrupoEconomico></TD>
									</TR>
									<TR id="TRTipoGrupoMkt" runat="server">
										<TD class="barra3" width="10%">
											Grupo Marketing:
										</TD>
										<TD class="barra1" width="90%" colSpan="3">
											<uc1:ucGrupoMarketing id="UcGrupoMarketing" runat="server"></uc1:ucGrupoMarketing></TD>
									</TR>
									<TR id="TRChkGrupoEconomico" runat="server">
										<TD class="barra3" width="10%"></TD>
										<TD class="barra1" width="90%" colSpan="3"><asp:checkbox id="chkGrupoEconomicoSemGrupoMkt" runat="server" Text="Grupo Econômico sem Grupo de Marketing"></asp:checkbox></TD>
									</TR>
								</TBODY>
							</TABLE>
						</td>
					</tr>
				</tbody>
			</table>
			<asp:label id="lblErro" runat="server" Font-Size="10px" ForeColor="Red"></asp:label></form>
	</BODY>
</HTML>
