<%@ Control Language="vb" AutoEventWireup="false" Codebehind="wucDiretoria.ascx.vb" Inherits="Martins.Web.UI.AcoesComerciais.wucDiretoria" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<asp:TextBox id="txtDiretoria" runat="server" Width="60px" Font-Names="Arial" Font-Size="11px"
	AutoPostBack="True" DESIGNTIMEDRAGDROP="35"></asp:TextBox>
<igtxt:webtextedit id="txtNomeDiretoria" Font-Size="11px" Font-Names="Arial" Width="200px" runat="server"
	MaxLength="35"></igtxt:webtextedit>
<asp:dropdownlist id="cmbNomeDiretoria" Font-Size="11px" Font-Names="Arial" AutoPostBack="True" Width="200px"
	runat="server" Height="19px" Visible="False"></asp:dropdownlist>
<asp:ImageButton id="btnBuscarDiretoria" runat="server" ImageUrl="../../Imagens/office/procurar.gif"
	ImageAlign="AbsMiddle" CausesValidation="False"></asp:ImageButton>
