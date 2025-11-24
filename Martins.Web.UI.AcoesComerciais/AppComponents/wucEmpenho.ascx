<%@ Control Language="vb" AutoEventWireup="false" Codebehind="wucEmpenho.ascx.vb" Inherits="Martins.Web.UI.AcoesComerciais.wucEmpenho" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<igtxt:webtextedit id="txtCodigo" runat="server" Width="60px" AutoPostBack="True" Font-Names="Arial"
	Font-Size="11px" HorizontalAlign="Right" SelectionOnFocus="SelectAll"></igtxt:webtextedit><asp:dropdownlist id="cmbNomeEmpenho" runat="server" Width="200px" AutoPostBack="True" Font-Names="Arial"
	Font-Size="11px" Height="19px"></asp:dropdownlist>
