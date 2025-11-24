<%@ Page Language="vb" AutoEventWireup="false" Codebehind="confirmarWindow.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.confirmarWindow"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>PAFS</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../Imagens/styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="JavaScript" src="../Imagens/controle.js" type="text/javascript"></SCRIPT>
		<style type="text/css">BODY { MARGIN: 0px; BACKGROUND-COLOR: #ffffff; scrolling: no }</style>
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

function FechaPagina(retorno) {
   window.returnValue=retorno;
   window.close();
}

//-->
			</script>
	</HEAD>
	<BODY onload="MM_preloadImages('../Imagens/lastpost.gif')">
		<form id="Form1" runat="server">
			<DIV>
				<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD class="submenu2" vAlign="top">
							<P>Aviso:</P>
							<P><asp:label id="lblPergunta" runat="server"></asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD class="submenu2" vAlign="middle" align="center">
							<p>
								<TABLE id="Table1" height="10" cellSpacing="0" cellPadding="0" border="0">
									<TR>
										<TD>
											<TABLE class="3D" id="Table3" cellSpacing="0" cellPadding="0" border="0">
												<TR>
													<TD onmouseover="mOvr(this,'#E1EBF4');" onmouseout="mOut(this,'');" onclick="javascript:FechaPagina(1);">
														<IMG height="16" src="../Imagens/office/S_B_OKAY.gif" width="16" align="absMiddle">
														Confirmar</TD>
													<TD onmouseover="mOvr(this,'#E1EBF4');" onmouseout="mOut(this,'');" onclick="javascript:FechaPagina(0);">
														<IMG height="16" src="../../IMAGENS/office/S_B_CANC.gif" width="16" align="absMiddle">
														Cancelar</TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</p>
						</TD>
					</TR>
				</TABLE>
			</DIV>
		</form>
	</BODY>
</HTML>