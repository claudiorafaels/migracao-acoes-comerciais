<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="AppComponents/wucFornecedor.ascx" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucContratoMercadoriaExcludente.ascx.vb" Inherits="Martins.Web.UI.AcoesComerciais.ucContratoMercadoriaExcludente" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
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
		function txtNUMCSLCTTFRN_Blur(oEdit, text, oEvent){
			document.getElementById('webTab__ctl5_ucContratoMercadoriaExcludente_cmbNUMCSLCTTFRN').value = text;
		}
		function txtTIPEDEABGMIX_Blur(oEdit, text, oEvent){
			document.getElementById('webTab__ctl5_ucContratoMercadoriaExcludente_cmbTIPEDEABGMIX').value = text;
		}
		function txtCODEDEABGMIX_Blur(oEdit, text, oEvent){
			document.getElementById('webTab__ctl5_ucContratoMercadoriaExcludente_cmbCODEDEABGMIX').value = text;
		}
		function txtCODMER_Blur(oEdit, text, oEvent){
			document.getElementById('webTab__ctl5_ucContratoMercadoriaExcludente_cmbCODMER').value = text;
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
				<TD class="barra3" style="HEIGHT: 41px" width="11%">Mercadorias Excludentes do 
					Contrato:</TD>
				<TD class="barra1" style="HEIGHT: 41px" width="89%" colSpan="5"><asp:datagrid id=GrdMercadoriasExcludentes DataSource="<%# DatasetContrato1 %>" DataMember="T0125020" AutoGenerateColumns="False" AllowPaging="True" PageSize="13" Font-Size="X-Small" CssClass=" " Width="100%" runat="server">
						<AlternatingItemStyle CssClass="row4"></AlternatingItemStyle>
						<ItemStyle CssClass="row3"></ItemStyle>
						<HeaderStyle CssClass="header1"></HeaderStyle>
						<Columns>
							<asp:ButtonColumn Text="&lt;img src=../Imagens/office/s_b_dail.gif alt=Detalhe border=0&gt;" CommandName="Link">
								<HeaderStyle Width="30px"></HeaderStyle>
							</asp:ButtonColumn>
							<asp:TemplateColumn HeaderText="CL&#193;USULA">
								<ItemTemplate>
									<asp:Label id=Label1 runat="server" Text='<%# consultarDESCSLCTTFRN(DataBinder.Eval(Container, "DataItem.NUMCSLCTTFRN")) %>'>
									</asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox id=TextBox1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NUMCSLCTTFRN") %>'>
									</asp:TextBox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="ABRANGENCIA">
								<ItemTemplate>
									<asp:Label id=Label2 runat="server" Text='<%# consultarDESEDEABGMIX(DataBinder.Eval(Container, "DataItem.TIPEDEABGMIX")) %>'>
									</asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox id=TextBox2 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TIPEDEABGMIX") %>'>
									</asp:TextBox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="ENTIDADE">
								<ItemTemplate>
									<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CODEDEABGMIX") %>'>
									</asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CODEDEABGMIX") %>'>
									</asp:TextBox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:BoundColumn DataField="CODMER" SortExpression="CODMER" HeaderText="COD. MERCADORIA" DataFormatString="{0:###,###,###}"></asp:BoundColumn>
							<asp:TemplateColumn HeaderText="DESCRI&#199;&#195;O MERCADORIA">
								<ItemTemplate>
									<asp:Label id=Label3 runat="server" Text='<%# consultarDESMER(DataBinder.Eval(Container, "DataItem.CODMER")) %>'>
									</asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox id=TextBox3 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CODMER") %>'>
									</asp:TextBox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:BoundColumn Visible="False" DataField="NUMCSLCTTFRN" SortExpression="NUMCSLCTTFRN" HeaderText="NUMCSLCTTFRN"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="TIPEDEABGMIX" SortExpression="TIPEDEABGMIX" HeaderText="TIPEDEABGMIX"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="CODEDEABGMIX" SortExpression="CODEDEABGMIX" HeaderText="CODEDEABGMIX"></asp:BoundColumn>
						</Columns>
						<PagerStyle VerticalAlign="Middle" Height="20px" HorizontalAlign="Center" PageButtonCount="9"
							CssClass=" " Mode="NumericPages"></PagerStyle>
					</asp:datagrid></TD>
			</TR>
			<TR>
				<TD class="barra1" style="HEIGHT: 3px" width="11%"></TD>
				<TD class="barra1" style="HEIGHT: 3px" width="89%" colSpan="5"></TD>
			</TR>
			<TR>
				<TD class="barra3" style="HEIGHT: 24px" width="11%">Opções:</TD>
				<TD class="barra1" style="HEIGHT: 24px" width="89%" colSpan="5">
					<TABLE class="3D" id="Table2" cellSpacing="0" cellPadding="0" border="0">
						<TR>
							<TD onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="cmdNova" style="TEXT-DECORATION: none" runat="server" Visible="False" CausesValidation="False"><IMG height="16" src="../Imagens/office/Novo.gif" width="16" align="absMiddle">  Nova</asp:linkbutton></TD>
							<TD><asp:linkbutton id="cmdAtualizar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/S_B_OKAY.gif" width="16" align="absMiddle">  Atualizar</asp:linkbutton></TD>
							<TD><asp:linkbutton id="btnExcluir" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/Apagar.gif" width="16" align="absMiddle">  Excluir</asp:linkbutton></TD>
							<TD><asp:linkbutton id="btnTrimestralidade" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
									Enabled="False" ToolTip="Gerar trimestralidade"><IMG height="16" src="../Imagens/office/S_B_OKAY.gif" width="16" align="absMiddle">  Trimestralidade</asp:linkbutton></TD>
							<TD><asp:linkbutton id="btnAnualidade" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
									Enabled="False" ToolTip="Gerar Anualidade"><IMG height="16" src="../Imagens/office/S_B_OKAY.gif" width="16" align="absMiddle">  Anualidade</asp:linkbutton></TD>
						</TR>
					</TABLE>
				</TD>
			</TR>
			<TR>
				<TD class="barra3" style="HEIGHT: 26px" width="11%">Cláusula:</TD>
				<TD class="barra1" style="HEIGHT: 26px" width="39%" colSpan="3"><igtxt:webnumericedit id="txtNUMCSLCTTFRN" Font-Size="11px" CssClass="" Width="50px" runat="server" AutoPostBack="True"
						Font-Names="Arial">
						<ClientSideEvents Blur="txtNUMCSLCTTFRN_Blur"></ClientSideEvents>
					</igtxt:webnumericedit><asp:dropdownlist id="cmbNUMCSLCTTFRN" Font-Size="11px" CssClass="" Width="250px" runat="server" AutoPostBack="True"
						Font-Names="Arial" Height="19px"></asp:dropdownlist><asp:label id="lblErroNUMCSLCTTFRN" Font-Size="Larger" runat="server" Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
				<TD class="barra3" style="HEIGHT: 26px" width="11%">Abrangência:</TD>
				<TD class="barra1" style="HEIGHT: 26px" width="39%"><igtxt:webnumericedit id="txtTIPEDEABGMIX" Font-Size="11px" CssClass="" Width="50px" runat="server" AutoPostBack="True"
						Font-Names="Arial">
						<ClientSideEvents Blur="txtTIPEDEABGMIX_Blur"></ClientSideEvents>
					</igtxt:webnumericedit><asp:dropdownlist id="cmbTIPEDEABGMIX" Font-Size="11px" CssClass="" Width="250px" runat="server" AutoPostBack="True"
						Font-Names="Arial" Height="19px">
						<asp:ListItem></asp:ListItem>
						<asp:ListItem Value="1">1 - TODOS</asp:ListItem>
						<asp:ListItem Value="2">2 - CATEGORIA</asp:ListItem>
						<asp:ListItem Value="3">3 - ITENS</asp:ListItem>
						<asp:ListItem Value="4">4 - ITENS NOVOS</asp:ListItem>
					</asp:dropdownlist><asp:label id="lblErroTIPEDEABGMIX" Font-Size="Larger" runat="server" Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
			<TR>
				<TD class="barra3" style="HEIGHT: 6px" width="11%">Entidade:</TD>
				<TD class="barra1" style="HEIGHT: 6px" width="39%" colSpan="3"><asp:dropdownlist id="cmbCODEDEABGMIX" Font-Size="11px" CssClass="" Width="250px" runat="server" Font-Names="Arial"
						Height="19px"></asp:dropdownlist><asp:label id="lblErroCODEDEABGMIX" Font-Size="Larger" runat="server" Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
				<TD class="barra1" style="HEIGHT: 6px" width="11%"></TD>
				<TD class="barra1" style="HEIGHT: 6px" width="39%"></TD>
			</TR>
			<TR>
				<TD class="barra3" width="11%">Mercadoria Excludente:</TD>
				<TD class="barra1" width="39%" colSpan="3"><asp:dropdownlist id="cmbTipo" Font-Size="11px" CssClass="" Width="250px" runat="server" AutoPostBack="True"
						Font-Names="Arial" Height="19px">
						<asp:ListItem></asp:ListItem>
						<asp:ListItem Value="1">SELECIONAR POR ITEM</asp:ListItem>
						<asp:ListItem Value="2">SELECIONAR POR CATEGORIA</asp:ListItem>
					</asp:dropdownlist></TD>
				<TD class="barra3" width="11%">Item:</TD>
				<TD class="barra1" width="39%">
					<igtxt:WebNumericEdit id="txtCODMER" Width="50px" runat="server" CssClass="" Font-Size="11px" Font-Names="Arial">
						<ClientSideEvents Blur="txtCODMER_Blur"></ClientSideEvents>
					</igtxt:WebNumericEdit>
					<asp:dropdownlist id="cmbCODMER" Height="19px" Width="250px" runat="server" CssClass="" Font-Size="11px"
						Font-Names="Arial"></asp:dropdownlist>
					<asp:label id="lblErroCODMER" runat="server" Font-Size="Larger" Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
			</TR>
		</TBODY>
	</TABLE>
</HTML>
