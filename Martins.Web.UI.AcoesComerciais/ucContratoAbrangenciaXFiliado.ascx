<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="AppComponents/wucFornecedor.ascx" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucContratoAbrangenciaXFiliado.ascx.vb" Inherits="Martins.Web.UI.AcoesComerciais.ucContratoAbrangenciaXFiliado" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
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
				<TD class="barra3" style="HEIGHT: 26px" width="11%">Opções:</TD>
				<TD class="barra1" style="HEIGHT: 26px" width="89%" colSpan="5">
					<TABLE class="3D" id="Table2" cellSpacing="0" cellPadding="0" border="0">
						<TR>
							<TD><asp:linkbutton id="cmdExportar" style="TEXT-DECORATION: none" runat="server"><IMG height="16" src="../Imagens/office/S_F_OOBJ.gif" width="16" align="absMiddle"> Importar p/Excel</asp:linkbutton></TD>
							<TD><asp:linkbutton id="cmdAtualizar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/S_B_OKAY.gif" width="16" align="absMiddle">  Atualizar dados do arquivo de origem</asp:linkbutton></TD>
						</TR>
					</TABLE>
				</TD>
			</TR>
			<TR>
				<TD class="barra3" style="HEIGHT: 26px" width="11%">Cláusula:</TD>
				<TD class="barra1" style="HEIGHT: 26px" width="39%" colSpan="5">
					<igtxt:webnumericedit id="txtNUMCSLCTTFRN" runat="server" Width="50px" CssClass="" Font-Size="11px"
						Font-Names="Arial" AutoPostBack="True">
						<ClientSideEvents Blur="txtNUMCSLCTTFRN_Blur"></ClientSideEvents>
					</igtxt:webnumericedit>
					<asp:dropdownlist id="cmbNUMCSLCTTFRN" runat="server" Width="250px" CssClass="" Font-Size="11px"
						Font-Names="Arial" AutoPostBack="True" Height="19px"></asp:dropdownlist>
					<asp:label id="lblErroNUMCSLCTTFRN" runat="server" Font-Size="Larger" Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
			<TR>
				<TD class="barra3" style="HEIGHT: 6px" width="11%">Abrangência:</TD>
				<TD class="barra1" style="HEIGHT: 6px" width="89%" colSpan="5">
					<igtxt:webnumericedit id="txtTIPEDEABGMIX" runat="server" AutoPostBack="True" Font-Names="Arial" Font-Size="11px"
						CssClass="" Width="50px">
						<ClientSideEvents Blur="txtTIPEDEABGMIX_Blur"></ClientSideEvents>
					</igtxt:webnumericedit><asp:dropdownlist id="cmbTIPEDEABGMIX" runat="server" AutoPostBack="True" Font-Names="Arial" Font-Size="11px"
						CssClass="" Width="250px" Height="19px">
						<asp:ListItem></asp:ListItem>
						<asp:ListItem Value="1">1 - TODOS</asp:ListItem>
						<asp:ListItem Value="2">2 - CATEGORIA</asp:ListItem>
						<asp:ListItem Value="3">3 - ITENS</asp:ListItem>
						<asp:ListItem Value="4">4 - ITENS NOVOS</asp:ListItem>
					</asp:dropdownlist><asp:label id="lblErroTIPEDEABGMIX" runat="server" Font-Names="Arial" Font-Size="Larger" ForeColor="#C00000">*</asp:label></TD>
				</TD></TR>
			<TR>
				<TD class="barra3" style="HEIGHT: 6px" width="11%">Entidade:</TD>
				<TD class="barra1" style="HEIGHT: 6px" width="89%" colSpan="5">
					<asp:dropdownlist id="cmbCODEDEABGMIX" runat="server" Width="300px" CssClass="" Font-Size="11px"
						Font-Names="Arial" Height="19px"></asp:dropdownlist>
					<asp:label id="lblErroCODEDEABGMIX" runat="server" Font-Size="Larger" Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
			</TR>
			<TR>
				<TD class="barra3" style="HEIGHT: 6px" width="11%">Arquivo de Origem:</TD>
				<TD class="barra1" style="HEIGHT: 6px" width="89%" colSpan="5"><INPUT language="vb" class=" " id="InpArquivoOrigem" style="WIDTH: 365px; HEIGHT: 20px"
						type="file" size="75" name="Plan" runat="server"></TD>
			</TR>
			<TR>
				<TD class="barra3" width="11%">Filiados:</TD>
				<TD class="barra1" width="89%" colSpan="9"><asp:datagrid id=grdContratosAssociados2 runat="server" Font-Size="X-Small" CssClass=" " Width="100%" PageSize="13" AllowPaging="True" AutoGenerateColumns="False" DataMember="queryFiliados" DataSource="<%# DatasetContrato1 %>">
						<AlternatingItemStyle CssClass="row4"></AlternatingItemStyle>
						<ItemStyle CssClass="row3"></ItemStyle>
						<HeaderStyle CssClass="header1"></HeaderStyle>
						<Columns>
							<asp:BoundColumn DataField="CODCLI" SortExpression="CODCLI" HeaderText="COD. FILIADO"></asp:BoundColumn>
							<asp:BoundColumn DataField="NOMCLI" SortExpression="NOMCLI" HeaderText="FILIADO"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="CADASTRADO" SortExpression="CADASTRADO" HeaderText="CADASTRADO"></asp:BoundColumn>
							<asp:TemplateColumn HeaderText="VALOR">
								<ItemTemplate>
									<asp:Label id="Label2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.VLRFIXAPUVLRRCB", "{0:###,###,##0.00}") %>'>
									</asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox id="Textbox2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.VLRFIXAPUVLRRCB", "{0:###,###,##0.00}") %>'>
									</asp:TextBox>
								</EditItemTemplate>
							</asp:TemplateColumn>
						</Columns>
						<PagerStyle VerticalAlign="Middle" Height="20px" HorizontalAlign="Center" PageButtonCount="9"
							CssClass=" " Mode="NumericPages"></PagerStyle>
					</asp:datagrid></TD>
			</TR>
			<TR>
				<TD class="barra3" id="TD01" width="11%" runat="server"></TD>
				<TD class="barra1" id="TD02" width="89%" colSpan="9" runat="server">
					<DIV style="DISPLAY: inline; OVERFLOW: auto; WIDTH: 100%" ms_positioning="FlowLayout">
						<asp:datagrid id=grdContratosAssociados runat="server" Font-Size="X-Small" CssClass=" " Width="700px" DataSource="<%# DatasetContrato1 %>" DataMember="queryFiliados" AutoGenerateColumns="False" PageSize="13">
							<AlternatingItemStyle CssClass="row4"></AlternatingItemStyle>
							<ItemStyle CssClass="row3"></ItemStyle>
							<HeaderStyle CssClass="header1"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="CODCLI" SortExpression="CODCLI" HeaderText="COD. FILIADO"></asp:BoundColumn>
								<asp:BoundColumn DataField="NOMCLI" SortExpression="NOMCLI" HeaderText="FILIADO"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="CADASTRADO" SortExpression="CADASTRADO" HeaderText="CADASTRADO"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="VALOR">
									<ItemTemplate>
										<asp:Label id=Label1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.VLRFIXAPUVLRRCB", "{0:###,###,##0.00}") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox id=TextBox1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.VLRFIXAPUVLRRCB", "{0:###,###,##0.00}") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle VerticalAlign="Middle" Height="20px" HorizontalAlign="Center" PageButtonCount="9"
								CssClass=" " Mode="NumericPages"></PagerStyle>
						</asp:datagrid></DIV>
				</TD>
			</TR>
		</TBODY>
	</TABLE>
</HTML>
