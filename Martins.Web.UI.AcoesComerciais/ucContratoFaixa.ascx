<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucContratoFaixa.ascx.vb" Inherits="Martins.Web.UI.AcoesComerciais.ucContratoFaixa" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
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
		function txtClausula_Blur(oEdit, text, oEvent){
			document.getElementById('webTab__ctl3_ucContratoFaixa_ddlClausula').value = text;
		}
		function txtEntidade_Blur(oEdit, text, oEvent){
			document.getElementById('webTab__ctl3_ucContratoFaixa_ddlEntidade').value = text;
		}
		function txtVlrRec_Blur(oEdit, text, oEvent){
			document.getElementById('webTab__ctl3_ucContratoFaixa_cmdAtualizar').focus();
		}
//-->
	</script>
	<script language="javascript">
		history.forward();
	</script>
	<LINK href="styles_tabelas.css" type="text/css" rel="stylesheet">
	<TABLE class="tabela1" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
		<TR>
			<TD class="barra3" width="11%">Faixas do Contrato:</TD>
			<TD class="barra1" width="89%" colSpan="5"><asp:datagrid id="grdFaixa" AutoGenerateColumns="False" AllowPaging="True" Font-Size="X-Small"
					Width="100%" CssClass=" " runat="server" PageSize="13">
					<EditItemStyle HorizontalAlign="Left" VerticalAlign="Top"></EditItemStyle>
					<AlternatingItemStyle CssClass="row4"></AlternatingItemStyle>
					<ItemStyle CssClass="row3"></ItemStyle>
					<HeaderStyle HorizontalAlign="Left" CssClass="header1" VerticalAlign="Top"></HeaderStyle>
					<Columns>
						<asp:ButtonColumn Text="&lt;img src=../Imagens/office/s_b_dail.gif alt=Detalhe border=0&gt;" CommandName="Link">
							<HeaderStyle Width="30px"></HeaderStyle>
						</asp:ButtonColumn>
						<asp:TemplateColumn SortExpression="NUMCTTFRN" HeaderText="CL&#193;USULA">
							<ItemTemplate>
								<asp:Label id=Label1 runat="server" Text='<%# consultarDESCSLCTTFRN(DataBinder.Eval(Container, "DataItem.NUMCSLCTTFRN")) %>'>
								</asp:Label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox id=TextBox1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NUMCSLCTTFRN") %>'>
								</asp:TextBox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn Visible="False" DataField="NUMCTTFRN" SortExpression="NUMCTTFRN" HeaderText="NUMCTTFRN"
							DataFormatString="{0:######}"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="NUMCSLCTTFRN" SortExpression="NUMCSLCTTFRN" HeaderText="NUMCSLCTTFRN"></asp:BoundColumn>
						<asp:BoundColumn DataField="TIPEDEABGMIX" SortExpression="TIPEDEABGMIX" HeaderText="ABR." DataFormatString="{0:0}"></asp:BoundColumn>
						<asp:BoundColumn DataField="CODEDEABGMIX" SortExpression="CODEDEABGMIX" HeaderText="ENTID." DataFormatString="{0:0}"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="CODFXAAVL" SortExpression="CODFXAAVL" HeaderText="CODFXAAVL">
							<HeaderStyle Width="60px"></HeaderStyle>
						</asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="DATREFINIUTZPMT" SortExpression="DATREFINIUTZPMT" HeaderText="DATREFINIUTZPMT">
							<HeaderStyle Width="60px"></HeaderStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="CODFXAAVL" SortExpression="CODFXAAVL" HeaderText="C&#211;DIGO DA FAIXA"
							DataFormatString="{0:0}">
							<HeaderStyle HorizontalAlign="Right" Width="60px"></HeaderStyle>
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="VLRFXAAVL" SortExpression="VLRFXAAVL" HeaderText="VALOR DE AVALIA&#199;&#195;O"
							DataFormatString="{0:###,###,##0.00}">
							<HeaderStyle HorizontalAlign="Right" Width="60px"></HeaderStyle>
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="VLRRCBREFFXA" SortExpression="VLRRCBREFFXA" HeaderText="VALOR A RECEBER"
							DataFormatString="{0:###,###,##0.00}">
							<HeaderStyle HorizontalAlign="Right" Width="60px"></HeaderStyle>
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="PERAPUVLRRCBREFFXA" SortExpression="PERAPUVLRRCBREFFXA" HeaderText="PERCENTUAL A RECEBER"
							DataFormatString="{0:#0.00}">
							<HeaderStyle HorizontalAlign="Right" Width="60px"></HeaderStyle>
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
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
						<TD onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="cmdNova" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
								Visible="False"><IMG height="16" src="../Imagens/office/Novo.gif" width="16" align="absMiddle">  Nova</asp:linkbutton></TD>
						<TD><asp:linkbutton id="cmdAtualizar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/S_B_OKAY.gif" width="16" align="absMiddle">  Atualizar</asp:linkbutton></TD>
						<TD><asp:linkbutton id="cmdExcluir" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/Apagar.gif" width="16" align="absMiddle">  Excluir</asp:linkbutton></TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
	</TABLE>
	<TABLE class="tabela2" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
		<TR>
			<TD class="barra3" style="HEIGHT: 8px" width="11%">Cláusula:</TD>
			<TD class="barra1" style="HEIGHT: 8px" width="39%" colSpan="3"><igtxt:webnumericedit id="txtClausula" Font-Size="11px" Width="50px" CssClass="" runat="server"
					Font-Names="Arial" AutoPostBack="True">
					<ClientSideEvents Blur="txtClausula_Blur"></ClientSideEvents>
				</igtxt:webnumericedit><asp:dropdownlist id="ddlClausula" Font-Size="11px" Width="200px" CssClass="" runat="server"
					Font-Names="Arial" AutoPostBack="True" Height="19px"></asp:dropdownlist><asp:label id="lblErroddlClausula" Font-Size="Larger" runat="server" Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
			<TD class="barra3" style="HEIGHT: 8px" width="11%">Abrangencia:</TD>
			<TD class="barra1" style="HEIGHT: 8px" width="39%"><igtxt:webnumericedit id="txtAbrangencia" Font-Size="11px" Width="50px" CssClass="" runat="server"
					Font-Names="Arial" AutoPostBack="True" ReadOnly="True" Enabled="False"></igtxt:webnumericedit><asp:dropdownlist id="ddlAbrangencia" Font-Size="11px" Width="250px" CssClass="" runat="server"
					Font-Names="Arial" AutoPostBack="True" Height="19px" Enabled="False">
					<asp:ListItem Value=" " Selected="True"></asp:ListItem>
					<asp:ListItem Value="1">Todos</asp:ListItem>
					<asp:ListItem Value="2">Categoria</asp:ListItem>
					<asp:ListItem Value="3">Itens</asp:ListItem>
					<asp:ListItem Value="4">Itens Novos</asp:ListItem>
				</asp:dropdownlist><asp:label id="lblErroddlAbrangencia" Font-Size="Larger" runat="server" Font-Names="Arial"
					ForeColor="#C00000">*</asp:label></TD>
		<TR>
			<TD class="barra3" style="HEIGHT: 18px" width="11%">Entidade:</TD>
			<TD class="barra1" style="HEIGHT: 18px" width="39%" colSpan="3"><igtxt:webnumericedit id="txtEntidade" Font-Size="11px" Width="50px" CssClass="" runat="server"
					Font-Names="Arial" Enabled="False" DataMode="Long">
					<ClientSideEvents Blur="txtEntidade_Blur"></ClientSideEvents>
				</igtxt:webnumericedit><asp:dropdownlist id="ddlEntidade" Font-Size="11px" Width="250px" CssClass="" runat="server"
					Font-Names="Arial" Height="19px" Enabled="False"></asp:dropdownlist><asp:label id="LblErroddlEntidade" Font-Size="Larger" runat="server" Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
			<TD class="barra3" style="HEIGHT: 18px" width="11%">Data Inicio Utilização:</TD>
			<TD class="barra1" style="HEIGHT: 18px" width="39%"><asp:dropdownlist id="cmbDatIniUtzPmt" Font-Size="11px" Width="90px" CssClass="" runat="server"
					Font-Names="Arial" Height="19px"></asp:dropdownlist><asp:label id="lblErrotxtDatIniUtzPmt" Font-Size="Larger" runat="server" Font-Names="Arial"
					ForeColor="#C00000">*</asp:label><br>
				<igtxt:webdatetimeedit id="txtDatIniUtzPmt" Font-Size="11px" Width="90px" CssClass="" runat="server"
					Font-Names="Arial" AutoPostBack="True"></igtxt:webdatetimeedit></TD>
		</TR>
		<TR>
			<TD class="barra3" width="11%">Tipo Faixa:</TD>
			<TD class="barra1" width="39%" colSpan="3">
				<asp:DropDownList id="cmbTipoFaixa" runat="server" Width="100px" Font-Size="11px" AutoPostBack="True"
					Font-Names="Arial">
					<asp:ListItem Value="1" Selected="True">Por Percentual</asp:ListItem>
					<asp:ListItem Value="2">Por Valor</asp:ListItem>
				</asp:DropDownList></TD>
			<TD class="barra1" width="11%"></TD>
			<TD class="barra1" width="39%"></TD>
		</TR>
		<TR>
			<TD class="barra3" width="11%"><asp:dropdownlist id="ddl1" Font-Size="11px" Width="0px" CssClass=" " runat="server" Font-Names="Arial"
					AutoPostBack="True" Height="19px"></asp:dropdownlist>Valor Faixa:</TD>
			<TD class="barra1" width="39%" colSpan="3"><igtxt:webnumericedit id="txtVlrFxa" Font-Size="11px" Width="80px" CssClass="" runat="server"
					Font-Names="Arial"></igtxt:webnumericedit><asp:label id="lblErrotxtVlrFxa" Font-Size="Larger" runat="server" Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
			<TD class="barra3" width="11%">Valor a Receber:</TD>
			<TD class="barra1" width="39%"><igtxt:webnumericedit id="txtVlrRec" Font-Size="11px" Width="80px" CssClass="" runat="server"
					Visible="False" Font-Names="Arial">
					<ClientSideEvents Blur="txtVlrRec_Blur"></ClientSideEvents>
				</igtxt:webnumericedit><igtxt:webpercentedit id="txtPer" Font-Size="11px" Width="50px" CssClass="" runat="server" Font-Names="Arial"></igtxt:webpercentedit><asp:label id="lblErrotxtPer" Font-Size="Larger" runat="server" Visible="False" Font-Names="Arial"
					ForeColor="#C00000">*</asp:label><asp:label id="lblErrotxtVlrRec" Font-Size="Larger" runat="server" Font-Names="Arial" ForeColor="#C00000">*</asp:label></TD>
		</TR>
		<TR>
			<TD class="barra3" id="TD1" width="11%" runat="server"></TD>
			<TD class="barra1" id="TD2" width="39%" colSpan="3" runat="server"><asp:textbox id="txtCODFXAAVL" Width="80px" runat="server" ReadOnly="True"></asp:textbox></TD>
			<TD class="barra3" id="TD3" width="11%" runat="server"></TD>
			<TD class="barra1" id="TD4" width="39%" runat="server"></TD>
		</TR>
	</TABLE>
</HTML>
