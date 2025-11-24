<%@ Page Language="vb" AutoEventWireup="false" Codebehind="InibirDedAutomatico.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.InibirDedAutomatico"%>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="martinscontrols" Namespace="Martins.Web.UI.Controls" Assembly="Martins.Web.UI.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=e9ed78c287a2fd3c" %>
<%@ Register TagPrefix="igcmbo" Namespace="Infragistics.WebUI.WebCombo" Assembly="Infragistics.WebUI.WebCombo.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="uc1" TagName="ucGrupoEconomico" Src="Controles/ucGrupoEconomico.ascx" %>
<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="AppComponents/wucFornecedor.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Martins</TITLE>
		<META content="text/html; charset=iso-8859-1" http-equiv="Content-Type">
		<LINK rel="stylesheet" type="text/css" href="../../../Imagens/Styles.css">
		<LINK rel="stylesheet" type="text/css" href="styles_tabelas.css">
	</HEAD>
	<BODY onload="MM_preloadImages('../../../Imagens/lastpost.gif')">
		<meta name="vs_snapToGrid" content="False">
		<meta name="vs_showGrid" content="False">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script for="document" event="onreadystatechange">
			if (readyState == 'complete'){
				escondeAndamento();
			} else {
				mostraAndamento();			
			}
		</script>
		<script language="JScript" for="document" event="onkeyup"> 
			//autoTab(); 
		</script>
		<SCRIPT language="JavaScript" type="text/javascript" src="../../../Imagens/controle.js">
		</SCRIPT>
		<style type="text/css">BODY {
	BACKGROUND-COLOR: #ffffff; MARGIN: 0px; scrolling: no
}
		</style>
		<script language="JavaScript" type="text/JavaScript">
<!--

 function SelectAll(chkTodos) {
      var grid = document.all("<%= dtgListar.ClientID %>");
      var cell;
      if (grid != null) {
        if (grid.rows.length > 0) {
          for (i = 1; i < grid.rows.length; i++) {
            cell = grid.rows[i].cells[4];
			if (cell != undefined){
				for (j = 0; j < cell.childNodes.length; j++) {
					if (cell.childNodes[j].type == "checkbox") {
						cell.childNodes[j].checked = chkTodos.checked;
					}
				}
            }
          }
        }
      }
    }

    function VerifyUnselectAll(chkItem) {
      if (chkItem.checked == false) {
        var grid = document.all("<%= dtgListar.ClientID %>");
        var cell;
        cell = grid.rows[0].cells[4];

        for (j = 0; j < cell.childNodes.length; j++) {
          if (cell.childNodes[j].type == "checkbox") {
            cell.childNodes[j].checked = false;
          }
        }
      }
    }
    
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



//-->
		</script>
		<script language="javascript">
			history.forward();
		</script>
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="10">
				<tr>
					<td><A href="javascript:parent.resizeFrame('5,*')"><IMG id="Image1" onmouseover="MM_swapImage('Image1','','../../../../Imagens/lastpost.gif',1)"
								onmouseout="MM_swapImage('Image1','','../../../Imagens/lastpost_l.gif',1)" name="Image1" src="../../../../Imagens/lastpost_l.gif"
								width="12" height="12"></A>
					</td>
				</tr>
			</table>
			<table style="WIDTH: 100%" border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tbody>
					<tr>
						<td class="submenu2" vAlign="top">
							<table id="tbOpcoes" border="0" cellSpacing="0" cellPadding="0" runat="server">
								<tr>
									<td>
										<table class="3D" border="0" cellSpacing="0" cellPadding="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onmouseout="mOut(this,'');" onclick="mClk('#');"><asp:linkbutton style="TEXT-DECORATION: none" id="btnPesquisar" runat="server" Width="64px" CausesValidation="False"><img src="../Imagens/office/procurar.gif" width="16" height="16" align="absMiddle">Pesquisar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" border="0" cellSpacing="0" cellPadding="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onmouseout="mOut(this,'');" onclick="mClk('#');"><asp:linkbutton style="TEXT-DECORATION: none" id="btnSalvar" runat="server" Width="64px" CausesValidation="False"><img src="../imagens/office/salvar.gif" width="16" height="16" align="absMiddle"> Salvar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" border="0" cellSpacing="0" cellPadding="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onmouseout="mOut(this,'');" onclick="mClk('#');"><asp:linkbutton style="TEXT-DECORATION: none" id="btnLimpar" runat="server"><IMG height="16" src="../Imagens/office/novo.gif" width="16" align="absMiddle"> Limpar</asp:linkbutton></td>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" border="0" cellSpacing="0" cellPadding="0">
											<tr>
												<TD><asp:linkbutton style="TEXT-DECORATION: none" visible="false" id="btnExportar" runat="server"><IMG height="16" src="../Imagens/office/S_F_OOBJ.gif" width="16" align="absMiddle"> Exportar p/Excel</asp:linkbutton></TD>
											</tr>
										</table>
									</td>
									<td>
										<table class="3D" border="0" cellSpacing="0" cellPadding="0">
											<tr>
												<td onmouseover="mOvr(this,'#E1EBF4');" onmouseout="mOut(this,'');" onclick="mClk('#');"></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td class="darkbox" vAlign="top">
							<TABLE id="Table0" class="tabela1" border="0" cellSpacing="0" cellPadding="2" width="100%">
								<TBODY>
									<TR id="trEspera" runat="server">
										<TD id="TDEspera" class="barra1" height="19" width="50%" align="left" runat="server">
											<DIV id="Div1" align="left" runat="server"><asp:image id="Image2" runat="server" ImageUrl="../../../Imagens/espera.gif"></asp:image>&nbsp;Carregando...
											</DIV>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
						</td>
					</tr>
					<tr>
						<td class="darkbox" vAlign="top">
							<TABLE id="Table1" class="tabela1" border="0" cellSpacing="0" cellPadding="2" width="100%">
								<TBODY>
									<TR id="TRCodigoGrupoEconomico" runat="server">
										<TD class="barra3" width="10%">Grupo Econômico:</TD>
										<TD class="barra1" width="90%" colSpan="3"><uc1:ucgrupoeconomico id="UcGrupoEconomico" runat="server"></uc1:ucgrupoeconomico></TD>
									</TR>
									<TR>
										<TD class="barra3">Fornecedor:</TD>
										<TD class="barra1" width="90%" colSpan="3"><uc1:wucfornecedor id="ucFornecedor" runat="server"></uc1:wucfornecedor></TD>
									</TR>
									<TR>
										<TD class="barra3">Status:</TD>
										<TD class="barra1" width="90%" colSpan="3">
											<asp:DropDownList Runat="server" ID="ddlStatus">
												<asp:ListItem Value="T">Todos</asp:ListItem>
												<asp:ListItem Value="I">Inibidos</asp:ListItem>
												<asp:ListItem Value="N">Não Inibidos</asp:ListItem>
											</asp:DropDownList></TD>
									</TR>
								</TBODY>
								<asp:datagrid id="dtgListar" runat="server" AllowPaging="True" PageSize="15" CssClass=" " AutoGenerateColumns="False"
									Font-Size="X-Small" Width="100%">
									<AlternatingItemStyle CssClass="row4"></AlternatingItemStyle>
									<ItemStyle CssClass="row3"></ItemStyle>
									<HeaderStyle CssClass="header1"></HeaderStyle>
									<Columns>
										<asp:BoundColumn DataField="CODFRN" HeaderText="C&oacute;d. Fornecedor" HeaderStyle-Width="5%">
											<HeaderStyle HorizontalAlign="Center" VerticalAlign="Top"></HeaderStyle>
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="NOMFRN" HeaderText="Fornecedor" HeaderStyle-Width="40%">
											<HeaderStyle HorizontalAlign="Center" VerticalAlign="Top"></HeaderStyle>
											<ItemStyle Wrap="False" HorizontalAlign="Left" CssClass="upper"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CODGRPFRN" HeaderText="C&oacute;d. Grupo Econ&ocirc;mico" HeaderStyle-Width="5%">
											<HeaderStyle HorizontalAlign="Center" VerticalAlign="Top"></HeaderStyle>
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="NOMGRPFRN" HeaderText="Grupo Econ&ocirc;mico" HeaderStyle-Width="45%">
											<HeaderStyle HorizontalAlign="Center" VerticalAlign="Top"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn HeaderText="Inibido" HeaderStyle-Width="5%">
											<HeaderStyle HorizontalAlign="Center" VerticalAlign="Top"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
											<HeaderTemplate>
												Inibido
												<asp:CheckBox id="chkAll" runat="server" onclick="javascript:SelectAll(this)"></asp:CheckBox>
											</HeaderTemplate>
											<ItemTemplate>
												<asp:CheckBox id="chkInibido" runat="server" onclick="javascript:VerifyUnselectAll(this)" Checked='<%# IIF(DataBinder.Eval(Container, "DataItem.INDSUSDSCNOTFSCAUT") = 1, true, false) %>'>
												</asp:CheckBox>
											</ItemTemplate>
											<FooterStyle HorizontalAlign="Center"></FooterStyle>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Inibido" HeaderStyle-Width="5%" Visible="False">
											<HeaderStyle HorizontalAlign="Center" VerticalAlign="Top"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
											<HeaderTemplate>
												Inibido
											</HeaderTemplate>
											<ItemTemplate>
											<asp:Label Runat="server" ID="lblInibido"></asp:Label>
											</ItemTemplate>
											<FooterStyle HorizontalAlign="Center"></FooterStyle>
										</asp:TemplateColumn>
									</Columns>
									<PagerStyle VerticalAlign="Middle" Height="20px" HorizontalAlign="Center" PageButtonCount="9"
										CssClass=" " Mode="NumericPages"></PagerStyle>
								</asp:datagrid></TABLE>
						</td>
					</tr>
				</tbody>
			</table>
			<asp:label id="lblErro" runat="server" Font-Size="10px" ForeColor="Red"></asp:label></form>
	</BODY>
</HTML>
