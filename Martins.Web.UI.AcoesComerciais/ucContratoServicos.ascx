<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="AppComponents/wucFornecedor.ascx" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucContratoServicos.ascx.vb" Inherits="Martins.Web.UI.AcoesComerciais.ucContratoServicos" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
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
				<TD class="barra3" width="11%">Serviços Especiais&nbsp;do Contrato</TD>
				<TD class="barra1" width="89%" colSpan="3">
					<P align="left">
						<asp:datagrid id=GrdServicos runat="server" Font-Size="X-Small" Width="100%" CssClass=" " PageSize="4" AllowPaging="True" AutoGenerateColumns="False" DataMember="T0138504" DataSource="<%# DatasetContrato1 %>">
							<AlternatingItemStyle CssClass="row4"></AlternatingItemStyle>
							<ItemStyle CssClass="row3"></ItemStyle>
							<HeaderStyle CssClass="header1"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="&lt;img src=../Imagens/office/s_b_dail.gif alt=Detalhe border=0&gt;" CommandName="Link">
									<HeaderStyle Width="30px"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:TemplateColumn HeaderText="TIPO SERVI&#199;O">
									<ItemTemplate>
										<asp:Label id=Label1 runat="server" Text='<%# consultarDESTIPSVCCTTFRN(DataBinder.Eval(Container, "DataItem.TIPSVCCTTFRN")) %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox id=TextBox1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TIPSVCCTTFRN") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="TIPSVCCTTFRN" SortExpression="TIPSVCCTTFRN" HeaderText="TIPSVCCTTFRN"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="POSSUI?">
									<ItemTemplate>
										<asp:Label id=Label2 runat="server" Text='<%# IIf(DataBinder.Eval(Container, "DataItem.INDSVCCTTFRN") = 1, "SIM", "NÃO") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox id=TextBox2 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.INDSVCCTTFRN") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="DESOBSSVCCTTFRN" SortExpression="DESOBSSVCCTTFRN" HeaderText="OBSERVA&#199;&#195;O"></asp:BoundColumn>
							</Columns>
							<PagerStyle VerticalAlign="Middle" Height="20px" HorizontalAlign="Center" PageButtonCount="9"
								CssClass=" " Mode="NumericPages"></PagerStyle>
						</asp:datagrid></P>
				</TD>
			</TR>
			<TR>
				<TD class="barra1" width="11%" style="HEIGHT: 3px"></TD>
				<TD class="barra1" width="89%" colSpan="3" style="HEIGHT: 3px"></TD>
			</TR>
			<TR>
				<TD class="barra3" width="11%">
					<P>Opções:</P>
				</TD>
				<TD class="barra1" width="89%" colSpan="3">
					<P align="left">
						<TABLE class="3D" id="Table2" cellSpacing="0" cellPadding="0" border="0">
							<TR>
								<TD>
									<asp:linkbutton id="cmdAtualizar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/S_B_OKAY.gif" width="16" align="absMiddle">  Atualizar</asp:linkbutton></TD>
								<TD>
									<asp:linkbutton id="btnExcluir" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/Apagar.gif" width="16" align="absMiddle">  Excluir</asp:linkbutton></TD>
							</TR>
						</TABLE>
					</P>
				</TD>
			</TR>
			<TR>
				<TD class="barra3" width="11%" style="HEIGHT: 18px">
					Serviço:</TD>
				<TD class="barra1" width="89%" style="HEIGHT: 18px" colSpan="3">
					<asp:DropDownList id="cmbTIPSVCCTTFRN" runat="server" CssClass=" " Width="200px" Font-Size="11px"
						Font-Names="Arial"></asp:DropDownList>
					<asp:label id="lblErroTIPSVCCTTFRN" runat="server" Font-Names="Arial" Font-Size="Larger" ForeColor="#C00000">*</asp:label></TD>
			</TR>
			<TR>
				<TD class="barra3" style="HEIGHT: 18px" width="11%">Possui esse Serviço ?</TD>
				<TD class="barra1" style="HEIGHT: 18px" width="89%" colSpan="3">
					<asp:DropDownList id="cmbINDSVCCTTFRN" runat="server" Font-Names="Arial" Font-Size="11px" Width="80px"
						CssClass=" ">
						<asp:ListItem Value="0">N&#195;O</asp:ListItem>
						<asp:ListItem Value="1">SIM</asp:ListItem>
					</asp:DropDownList></TD>
			</TR>
			<TR>
				<TD class="barra3" width="11%">Observação:</TD>
				<TD class="barra1" width="89%" colSpan="3">
					<asp:textbox id="txtDESOBSSVCCTTFRN" runat="server" CssClass="" Width="100%" TextMode="MultiLine"
						Rows="3" Font-Names="Arial" Font-Size="11px" MaxLength="254"></asp:textbox></TD>
			</TR>
		</TBODY>
	</TABLE>
</HTML>
