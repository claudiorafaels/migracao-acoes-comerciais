<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucMercadoria.ascx.vb" Inherits="Martins.Web.UI.AcoesComerciais.ucMercadoria" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<SCRIPT type="text/javascript"><!--
--></SCRIPT>
<asp:TextBox id="txtCodigoMercadoria" Width="60px" runat="server" AutoPostBack="True" Font-Size="11px"
	Font-Names="Arial" MaxLength="7"></asp:TextBox>&nbsp;<igtxt:webtextedit id="txtNomeMercadoria" CssClass="" Font-Size="11px" Font-Names="Arial" Width="224px"
	runat="server" MaxLength="35"></igtxt:webtextedit><asp:dropdownlist id="cmbNomeMercadoria" CssClass="" Font-Size="11px" Font-Names="Arial" AutoPostBack="True"
	Width="224px" runat="server" Height="19px" Visible="False"></asp:dropdownlist>
<asp:ImageButton id="btnBuscarMercadoria" runat="server" ImageUrl="../../Imagens/office/procurar.gif"
	ImageAlign="AbsMiddle" CausesValidation="False"></asp:ImageButton>
<asp:Label id="lblMercadoria" Font-Names="Arial" Font-Size="11px" runat="server" Width="136px"
	ForeColor="Red" Font-Bold="True"></asp:Label>
