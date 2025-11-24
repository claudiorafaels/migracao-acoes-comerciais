<%@ Control Language="vb" AutoEventWireup="false" Codebehind="wucComprador.ascx.vb" Inherits="Martins.Web.UI.AcoesComerciais.wucComprador" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<asp:TextBox id="txtComprador" AutoPostBack="True" Font-Size="11px" Font-Names="Arial" Width="60px"
	runat="server" DESIGNTIMEDRAGDROP="11"></asp:TextBox>
<igtxt:webtextedit id="txtNomeComprador" Font-Size="11px" Font-Names="Arial" Width="200px" runat="server"
	MaxLength="35"></igtxt:webtextedit>
<asp:dropdownlist id="cmbNomeComprador" Font-Size="11px" Font-Names="Arial" AutoPostBack="True" Width="200px"
	runat="server" Height="19px" Visible="False"></asp:dropdownlist>
<asp:ImageButton id="btnBuscarComprador" runat="server" ImageUrl="../../Imagens/office/procurar.gif"
	ImageAlign="AbsMiddle" CausesValidation="False"></asp:ImageButton>
