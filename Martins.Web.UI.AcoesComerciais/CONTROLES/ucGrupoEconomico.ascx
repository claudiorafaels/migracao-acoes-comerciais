<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ucGrupoEconomico.ascx.vb" Inherits="Martins.Web.UI.AcoesComerciais.ucGrupoEconomico" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<SCRIPT type="text/javascript"><!--
--></SCRIPT>
<asp:textbox id="txtCodigoGrupoEconomico" Font-Names="Arial" Font-Size="11px" AutoPostBack="True"
	runat="server" Width="60px"></asp:textbox>&nbsp;<igtxt:webtextedit id="txtDescricaoGrupoEconomico" Font-Names="Arial" Font-Size="11px" runat="server"
	Width="224px" MaxLength="35" CssClass=""></igtxt:webtextedit><asp:dropdownlist id="cmbDescricaoGrupoEconomico" Font-Names="Arial" Font-Size="11px" AutoPostBack="True"
	runat="server" Width="224px" CssClass="" Visible="False" Height="19px"></asp:dropdownlist>
<asp:imagebutton id="btnBuscarGrupoEconomico" runat="server" CausesValidation="False" ImageAlign="AbsMiddle"
	ImageUrl="../../Imagens/office/procurar.gif"></asp:imagebutton><asp:label id="lblGrupoEconomico" Font-Names="Arial" Font-Size="11px" runat="server" Width="136px"
	Font-Bold="True" ForeColor="Red"></asp:label>
