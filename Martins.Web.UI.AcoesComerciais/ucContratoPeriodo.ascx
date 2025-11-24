<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="AppComponents/wucFornecedor.ascx" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucContratoPeriodo.ascx.vb" Inherits="Martins.Web.UI.AcoesComerciais.ucContratoPeriodo" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
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
			document.getElementById('webTab__ctl4_ucContratoPeriodo_cmbNUMCSLCTTFRN').value = text;
		}
		function txtTIPPODCTTFRN_Blur(oEdit, text, oEvent){
			document.getElementById('webTab__ctl4_ucContratoPeriodo_cmbTIPPODCTTFRN').value = text;
		}
//-->
	</script>
	<script language="javascript">
		history.forward();
	</script>
	<LINK href="styles_tabelas.css" type="text/css" rel="stylesheet">
	<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
		<TR>
			<TD class="barra3" width="11%">Periodos do Contrato:</TD>
			<TD class="barra1" width="89%" colSpan="5">
				<asp:datagrid id=grdPeriodos runat="server" CssClass=" " Width="100%" Font-Size="X-Small" PageSize="14" AllowPaging="True" AutoGenerateColumns="False" DataMember="T0124988" DataSource="<%# DatasetContrato1 %>">
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
						<asp:TemplateColumn HeaderText="PER&#205;ODO">
							<ItemTemplate>
								<asp:Label id=Label2 runat="server" Text='<%# consultarDESPODCTTFRN(DataBinder.Eval(Container, "DataItem.TIPPODCTTFRN")) %>'>
								</asp:Label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox id=TextBox2 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TIPPODCTTFRN") %>'>
								</asp:TextBox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="NUMREFPOD" SortExpression="NUMREFPOD" HeaderText="NRO. REFERENCIA" DataFormatString="{0:###,###}">
							<HeaderStyle HorizontalAlign="Center" VerticalAlign="Top"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="DATINIPOD" SortExpression="DATINIPOD" HeaderText="DATA INICIAL" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
						<asp:BoundColumn DataField="DATFIMPOD" SortExpression="DATFIMPOD" HeaderText="DATA FINAL" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="NUMCTTFRN" SortExpression="NUMCTTFRN" HeaderText="NUMCTTFRN"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="NUMCSLCTTFRN" SortExpression="NUMCSLCTTFRN" HeaderText="NUMCSLCTTFRN"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="TIPPODCTTFRN" SortExpression="TIPPODCTTFRN" HeaderText="TIPPODCTTFRN"></asp:BoundColumn>
					</Columns>
					<PagerStyle VerticalAlign="Middle" Height="20px" HorizontalAlign="Center" PageButtonCount="9"
						CssClass=" " Mode="NumericPages"></PagerStyle>
				</asp:datagrid></TD>
		</TR>
	</TABLE>
	<TABLE class="tabela3" id="Table3" cellSpacing="0" cellPadding="2" width="100%" border="0">
		<TR>
			<TD class="barra1" width="11%" style="HEIGHT: 3px"></TD>
			<TD class="barra1" width="39%" colSpan="3" style="HEIGHT: 3px"></TD>
			<TD class="barra1" width="11%" style="HEIGHT: 3px"></TD>
			<TD class="barra1" width="39%" style="HEIGHT: 3px"></TD>
		</TR>
		<TR>
			<TD class="barra3" width="11%">Opções</TD>
			<TD class="barra1" width="39%" colSpan="5">
				<TABLE class="3D" id="Table2" cellSpacing="0" cellPadding="0" border="0">
					<TR>
						<TD onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');">
							<asp:linkbutton id="cmdNova" style="TEXT-DECORATION: none" runat="server" Visible="False" CausesValidation="False"><IMG height="16" src="../Imagens/office/Novo.gif" width="16" align="absMiddle">  Nova</asp:linkbutton></TD>
						<TD>
							<asp:linkbutton id="cmdAtualizar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
								ToolTip="Gerar períodos para cláusula e periodo selecionado"><IMG height="16" src="../Imagens/office/S_B_OKAY.gif" width="16" align="absMiddle">  Gerar</asp:linkbutton></TD>
						<TD>
							<asp:linkbutton id="btnExcluir" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
								ToolTip="Excluir todos períodos gerados para cláusula e periodo selecionado"><IMG height="16" src="../Imagens/office/Apagar.gif" width="16" align="absMiddle">  Excluir</asp:linkbutton></TD>
						<TD>
							<asp:linkbutton id="btnTrimestralidade" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
								ToolTip="Gerar trimestralidade" Enabled="False"><IMG height="16" src="../Imagens/office/S_B_OKAY.gif" width="16" align="absMiddle">  Trimestralidade</asp:linkbutton></TD>
						<TD>
							<asp:linkbutton id="btnAnualidade" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
								ToolTip="Gerar Anualidade" Enabled="False"><IMG height="16" src="../Imagens/office/S_B_OKAY.gif" width="16" align="absMiddle">  Anualidade</asp:linkbutton></TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
		<TR>
			<TD class="barra3" width="11%" style="HEIGHT: 39px">Cláusula:</TD>
			<TD class="barra1" width="39%" colSpan="3" style="HEIGHT: 39px">
				<igtxt:webnumericedit id="txtNUMCSLCTTFRN" runat="server" CssClass="" Width="50px" Font-Size="11px" Font-Names="Arial">
					<ClientSideEvents Blur="txtNUMCSLCTTFRN_Blur"></ClientSideEvents>
				</igtxt:webnumericedit>
				<asp:dropdownlist id="cmbNUMCSLCTTFRN" runat="server" CssClass="" Width="200px" Font-Names="Arial"
					Font-Size="11px" Height="19px"></asp:dropdownlist>
				<asp:label id="lblErroNUMCSLCTTFRN" Font-Size="Larger" runat="server" Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
			<TD class="barra3" width="11%" style="HEIGHT: 39px">Período:</TD>
			<TD class="barra1" width="39%" style="HEIGHT: 39px">
				<igtxt:WebNumericEdit id="txtTIPPODCTTFRN" runat="server" CssClass="" Width="50px" Font-Size="11px" Font-Names="Arial">
					<ClientSideEvents Blur="txtTIPPODCTTFRN_Blur"></ClientSideEvents>
				</igtxt:WebNumericEdit>
				<asp:dropdownlist id="cmbTIPPODCTTFRN" runat="server" CssClass="" Width="250px" AutoPostBack="True"
					Font-Names="Arial" Font-Size="11px" Height="19px"></asp:dropdownlist>
				<asp:label id="lblErroTIPPODCTTFRN" Font-Size="Larger" runat="server" Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
		</TR>
		<TR>
			<TD class="barra3" width="11%" id="TD1" runat="server">Data Inicial:</TD>
			<TD class="barra1" width="39%" colSpan="3" id="TD2" runat="server">
				<asp:dropdownlist id="cmbDATINIPOD" Font-Size="11px" Width="90px" CssClass="" runat="server" Font-Names="Arial"
					Height="19px"></asp:dropdownlist><BR>
				<igtxt:WebDateTimeEdit id="txtDATINIPOD" Width="90px" runat="server" CssClass="" Font-Size="11px" Font-Names="Arial"></igtxt:WebDateTimeEdit>
				<asp:label id="lblErroDATINIPOD" runat="server" Font-Names="Arial" Font-Size="Larger" ForeColor="#C00000">*</asp:label></TD>
			<TD class="barra3" width="11%" id="TD3" runat="server">Data Final</TD>
			<TD class="barra1" width="39%" id="TD4" runat="server">
				<igtxt:WebDateTimeEdit id="txtDATFIMPOD" Width="90px" runat="server" CssClass="" Font-Size="11px" Font-Names="Arial"></igtxt:WebDateTimeEdit>
				<asp:label id="LblErroDATFIMPOD" runat="server" Font-Names="Arial" Font-Size="Larger" ForeColor="#C00000">*</asp:label></TD>
		</TR>
		<TR>
			<TD class="barra3" width="11%" id="TD5" runat="server">Numero Referencia Período:</TD>
			<TD class="barra1" width="89%" colSpan="5" id="TD6" runat="server">
				<igtxt:WebNumericEdit id="txtNUMREFPOD" runat="server" CssClass="" Width="100px" Font-Size="11px" Font-Names="Arial"></igtxt:WebNumericEdit></TD>
		</TR>
	</TABLE>
</HTML>
