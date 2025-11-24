<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucContratoAbrangencia.ascx.vb" Inherits="Martins.Web.UI.AcoesComerciais.ucContratoAbrangencia" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="uc1" TagName="wucFornecedor" Src="AppComponents/wucFornecedor.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Martins</TITLE>
	</HEAD>
	<LINK href="../Imagens/styles.css" type="text/css" rel="stylesheet">
	<meta content="False" name="vs_showGrid">
	<SCRIPT language="JavaScript" src="../Imagens/controle.js" type="text/javascript"></SCRIPT>
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
		function txtCodClausula_Blur(oEdit, text, oEvent){
			document.getElementById('webTab__ctl2_ucContratoAbrangencia_ddlClausula').value = text;
		}
		
		function txtCodEntidade_Blur(oEdit, text, oEvent){
			document.getElementById('webTab__ctl2_ucContratoAbrangencia_ddlEntidade').value = text;
		}
		
		function txtCodAbrangencia_Blur(oEdit, text, oEvent){
			document.getElementById('webTab__ctl2_ucContratoAbrangencia_ddlAbrangencia').value = text;
		}
		
		function txtCodBseClcVlrRec_Blur(oEdit, text, oEvent){
			document.getElementById('webTab__ctl2_ucContratoAbrangencia_ddlBseClcVlrRec').value = text;
		}
		
		function txtCodBseClcIndice_Blur(oEdit, text, oEvent){
			document.getElementById('webTab__ctl2_ucContratoAbrangencia_ddlBseClcIndice').value = text;		
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
				<TD class="barra3" width="11%">Abrangencia do Contrato:</TD>
				<TD class="barra1" width="89%" colSpan="9">
					<asp:datagrid id=grdAbrangencia runat="server" CssClass=" " Width="100%" Font-Size="X-Small" PageSize="4" AllowPaging="True" AutoGenerateColumns="False" DataMember="T0124996" DataSource="<%# DatasetContrato1 %>">
						<AlternatingItemStyle CssClass="row4"></AlternatingItemStyle>
						<ItemStyle CssClass="row3"></ItemStyle>
						<HeaderStyle CssClass="header1"></HeaderStyle>
						<Columns>
							<asp:ButtonColumn Text="&lt;img src=../Imagens/office/s_b_dail.gif alt=Detalhe border=0&gt;" CommandName="Link">
								<HeaderStyle Width="30px"></HeaderStyle>
							</asp:ButtonColumn>
							<asp:TemplateColumn HeaderText="CL&#193;USULA">
								<ItemTemplate>
									<asp:Label id=Label2 runat="server" Text='<%# consultarDESCSLCTTFRN(DataBinder.Eval(Container, "DataItem.NUMCSLCTTFRN")) %>'>
									</asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox id=TextBox1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NUMCSLCTTFRN") %>'>
									</asp:TextBox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:BoundColumn Visible="False" DataField="NUMCSLCTTFRN" SortExpression="NUMCSLCTTFRN" HeaderText="NUMCSLCTTFRN"></asp:BoundColumn>
							<asp:TemplateColumn HeaderText="ABRANGENCIA">
								<ItemTemplate>
									<asp:Label id=Label1 runat="server" Text='<%# consultarDESEDEABGMIX(DataBinder.Eval(Container, "DataItem.TIPEDEABGMIX")) %>'>
									</asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox id=TextBox2 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TIPEDEABGMIX") %>'>
									</asp:TextBox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:BoundColumn Visible="False" DataField="TIPEDEABGMIX" SortExpression="TIPEDEABGMIX" HeaderText="TIPEDEABGMIX"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="NUMCTTFRN" SortExpression="NUMCTTFRN" HeaderText="NUMCTTFRN"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="CODEDEABGMIX" SortExpression="CODEDEABGMIX" HeaderText="CODEDEABGMIX"></asp:BoundColumn>
							<asp:BoundColumn DataField="CODEDEABGMIX" SortExpression="CODEDEABGMIX" HeaderText="ENTIDADE" DataFormatString="{0:###########0}"></asp:BoundColumn>
						</Columns>
						<PagerStyle VerticalAlign="Middle" Height="20px" HorizontalAlign="Center" PageButtonCount="9"
							CssClass=" " Mode="NumericPages"></PagerStyle>
					</asp:datagrid></TD>
			</TR>
			<TR>
				<TD class="barra1" style="HEIGHT: 3px" width="11%"></TD>
				<TD class="barra1" style="HEIGHT: 3px" width="39%" colSpan="7"></TD>
				<TD class="barra1" style="HEIGHT: 3px" width="11%" colSpan="7"></TD>
				<TD class="barra1" style="HEIGHT: 3px" width="39%" colSpan="7"></TD>
			</TR>
			<TR>
				<TD class="barra3" width="11%">Opções:</TD>
				<TD class="barra1" width="39%" colSpan="7">
					<TABLE class="3D" id="Table2" cellSpacing="0" cellPadding="0" border="0">
						<TR>
							<TD onmouseover="mOvr(this,'#E1EBF4');" onclick="mClk('#');" onmouseout="mOut(this,'');"><asp:linkbutton id="cmdNova" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"
									Visible="False"><IMG height="16" src="../Imagens/office/Novo.gif" width="16" align="absMiddle">  Nova</asp:linkbutton></TD>
							<TD><asp:linkbutton id="cmdAtualizar" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/S_B_OKAY.gif" width="16" align="absMiddle">  Atualizar</asp:linkbutton></TD>
							<TD>
								<asp:linkbutton id="btnExcluir" style="TEXT-DECORATION: none" runat="server" CausesValidation="False"><IMG height="16" src="../Imagens/office/apagar.gif" width="16" align="absMiddle">  Excluir</asp:linkbutton></TD>
						</TR>
					</TABLE>
				</TD>
				<TD class="barra1" width="11%"></TD>
				<TD class="barra1" width="39%"></TD>
			</TR>
			<TR>
				<TD class="barra3" width="11%" style="HEIGHT: 22px">Cláusula:</TD>
				<TD class="barra1" width="39%" colSpan="7" style="HEIGHT: 22px"><igtxt:webnumericedit id="txtCodClausula" runat="server" Width="60px" DataMode="Int" CssClass="" Font-Size="11px"
						Font-Names="Arial">
						<ClientSideEvents Blur="txtCodClausula_Blur"></ClientSideEvents>
					</igtxt:webnumericedit><asp:dropdownlist id="ddlClausula" runat="server" Width="240px" Height="19px" CssClass="" Font-Names="Arial"
						Font-Size="11px"></asp:dropdownlist>
					<asp:Label id="lblErroddlClausula" runat="server" Font-Size="Larger" Font-Names="Arial" ForeColor="#C00000">*</asp:Label></TD>
				<TD class="barra3" width="11%" style="HEIGHT: 22px">Abrangencia:</TD>
				<TD class="barra1" width="39%" style="HEIGHT: 22px"><igtxt:webnumericedit id="txtCodAbrangencia" runat="server" Width="50px" DataMode="Int" CssClass="" AutoPostBack="True"
						Font-Size="11px" Font-Names="Arial">
						<ClientSideEvents Blur="txtCodAbrangencia_Blur"></ClientSideEvents>
					</igtxt:webnumericedit><asp:dropdownlist id="ddlAbrangencia" runat="server" Width="220px" Height="19px" CssClass="" Font-Names="Arial"
						Font-Size="11px" AutoPostBack="True">
						<asp:ListItem Value=" " Selected="True"></asp:ListItem>
						<asp:ListItem Value="1">Todos</asp:ListItem>
						<asp:ListItem Value="2">Categoria</asp:ListItem>
						<asp:ListItem Value="3">Itens</asp:ListItem>
						<asp:ListItem Value="4">Itens Novos</asp:ListItem>
					</asp:dropdownlist>
					<asp:Label id="lblErroddlAbrangencia" runat="server" Font-Size="Larger" Font-Names="Arial"
						ForeColor="#C00000">*</asp:Label></TD>
			</TR>
			<TR>
				<TD class="barra3" style="HEIGHT: 49px" width="11%">Entidade:</TD>
				<TD class="barra1" style="HEIGHT: 49px" width="39%" colSpan="7"><igtxt:webnumericedit id="txtCodEntidade" runat="server" Width="60px" DataMode="Long" CssClass="" Font-Size="11px"
						Font-Names="Arial">
						<ClientSideEvents Blur="txtCodEntidade_Blur"></ClientSideEvents>
					</igtxt:webnumericedit><asp:dropdownlist id="ddlEntidade" runat="server" Width="240px" Height="19px" CssClass="" Font-Names="Arial"
						Font-Size="11px"></asp:dropdownlist>
					<asp:Label id="lblErroddlEntidade" runat="server" Font-Size="Larger" Font-Names="Arial" ForeColor="#C00000">*</asp:Label></TD>
				<TD class="barra1" style="HEIGHT: 49px" width="11%"></TD>
				<TD class="barra1" style="HEIGHT: 49px" width="39%"></TD>
			</TR>
			<TR>
				<TD class="barra3" width="11%" style="HEIGHT: 39px">Bse. Clc. Vlr. Rec.:</TD>
				<TD class="barra1" width="39%" colSpan="7" style="HEIGHT: 39px"><igtxt:webnumericedit id="txtCodBseClcVlrRec" runat="server" Width="60px" DataMode="Int" CssClass="" AutoPostBack="True"
						Font-Size="11px" Font-Names="Arial">
						<ClientSideEvents Blur="txtCodBseClcVlrRec_Blur"></ClientSideEvents>
					</igtxt:webnumericedit><asp:dropdownlist id="ddlBseClcVlrRec" runat="server" Width="240px" Height="19px" CssClass="" Font-Names="Arial"
						Font-Size="11px" AutoPostBack="True"></asp:dropdownlist>
					<asp:Label id="lblErroddlBseClcVlrRec" runat="server" Font-Size="Larger" Font-Names="Arial"
						ForeColor="#C00000">*</asp:Label></TD>
				<TD class="barra3" width="11%" style="HEIGHT: 39px">Bse. Clc. Índice:</TD>
				<TD class="barra1" width="39%" style="HEIGHT: 39px"><igtxt:webnumericedit id="txtCodBseClcIndice" runat="server" Width="50px" DataMode="Int" CssClass="" Font-Size="11px"
						Font-Names="Arial">
						<ClientSideEvents Blur="txtCodBseClcIndice_Blur"></ClientSideEvents>
					</igtxt:webnumericedit><asp:dropdownlist id="ddlBseClcIndice" runat="server" Width="220px" Height="19px" CssClass="" Font-Names="Arial"
						Font-Size="11px"></asp:dropdownlist></TD>
			</TR>
			<TR>
				<TD class="barra3" style="HEIGHT: 76px" width="11%">Parâmetros Abrangencia:</TD>
				<TD class="barra1" style="HEIGHT: 76px" width="89%" colSpan="9">
					<TABLE class="tabela1" id="Table3" cellSpacing="0" cellPadding="2" width="100%" border="0">
						<TBODY>
							<TR>
								<TD class="barra1" width="25%" colSpan="7"><asp:checkbox id="chkMerExc" runat="server" Text="Mercadoria excludente" ForeColor="Black"></asp:checkbox></TD>
								<TD class="barra1" width="25%" colSpan="7"><asp:checkbox id="chkFaixa" runat="server" AutoPostBack="True" Text="Faixas de Crescimento" ForeColor="Black"></asp:checkbox></TD>
								<TD class="barra1" width="25%" colSpan="7"><asp:checkbox id="chkFxaPer" runat="server" Text="Faixas em Percentual" ForeColor="Black"></asp:checkbox></TD>
								<TD class="barra1" width="25%" colSpan="7"><asp:checkbox id="chkDescMerNova" runat="server" Text="Desconsiderar Mercadoria Nova" ForeColor="Black"></asp:checkbox></TD>
							</TR>
							<TR>
								<TD class="barra1" width="25%" colSpan="7" id="TD2" runat="server"><asp:checkbox id="chkPerVlr" runat="server" AutoPostBack="True" Text="Percentual Fixo" ForeColor="Black"></asp:checkbox></TD>
								<TD class="barra1" width="25%" colSpan="7" id="TD1" runat="server"><asp:label id="lblPerVlrFixoApuracao" runat="server" Width="110px" ForeColor="Black">Percentual Fixo de Apuração do Valor:</asp:label>
									<igtxt:WebPercentEdit id="txtPerFixoVlr" Width="70px" runat="server" CssClass="" Font-Size="11px" Font-Names="Arial"></igtxt:WebPercentEdit>
									<igtxt:WebCurrencyEdit id="txtVlrFixoApu" Font-Size="11px" Width="70px" CssClass="" runat="server" Font-Names="Arial"
										MinDecimalPlaces="Two" Visible="False"></igtxt:WebCurrencyEdit>
									<asp:Label id="lblErrotxtPerVlrFixoApuracao" runat="server" Font-Size="Larger" Font-Names="Arial"
										ForeColor="#C00000">*</asp:Label></TD>
				</TD>
				<TD class="barra1" width="25%" colSpan="7" id="TD3" runat="server"><asp:checkbox id="chkBaseAnterior" runat="server" Text="Ger. Base Anterior" ForeColor="Black"
						Visible="False"></asp:checkbox></TD>
				<TD class="barra1" width="25%" colSpan="7"></TD>
			</TR>
		</TBODY>
	</TABLE>
	</TD></TR>
	<TR>
		<TD class="barra3" width="11%">Tip. Cálculo Fat. Min.:</TD>
		<TD class="barra1" width="39%" colSpan="7"><asp:dropdownlist id="ddlTipCalculoFatMin" runat="server" Width="220px" Height="19px" CssClass=""
				Font-Names="Arial" Font-Size="11px"></asp:dropdownlist></TD>
		<TD class="barra3" width="11%">Valor Fat. Min.:</TD>
		<TD class="barra1" width="39%"><igtxt:webcurrencyedit id="txtValorFatMin" runat="server" Width="100px" DataMode="Decimal" CssClass=""
				Font-Size="11px" Font-Names="Arial"></igtxt:webcurrencyedit>
			<asp:Label id="lblErrotxtValorFatMin" runat="server" Font-Size="Larger" Font-Names="Arial"
				ForeColor="#C00000">*</asp:Label></TD>
	</TR>
	<TR>
		<TD class="barra3" width="11%">Indicadores Aplicáveis:</TD>
		<TD class="barra1" width="89%" colSpan="9">
			<TABLE class="tabela1" id="Table3" cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR>
					<TD class="barra1" width="25%" colSpan="7"><asp:checkbox id="chkIndIncIPIApuCtt" runat="server" Text="IPI" ForeColor="Black"></asp:checkbox></TD>
					<TD class="barra1" width="25%" colSpan="7"><asp:checkbox id="chkIndIncICMApuCtt" runat="server" Text="ICMS" ForeColor="Black"></asp:checkbox></TD>
					<TD class="barra1" width="25%" colSpan="7"><asp:checkbox id="chkIndIncPISApuCtt" runat="server" Text="PIS/COFINS" ForeColor="Black"></asp:checkbox></TD>
					<TD class="barra1" width="25%" colSpan="7"><asp:checkbox id="chkIndIncSbtTbtApuCtt" runat="server" Text="STB" ForeColor="Black"></asp:checkbox></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	</TBODY></TABLE>
</HTML>
