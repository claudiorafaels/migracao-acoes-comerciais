<%@ Control Language="vb" AutoEventWireup="false" Codebehind="wucCentroCusto.ascx.vb" Inherits="Martins.Web.UI.AcoesComerciais.wucCentroCusto" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics.WebUI.WebDataInput.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<asp:textbox id="txtCodigo" runat="server" Width="60px" Font-Names="Arial" Font-Size="11px" AutoPostBack="True"></asp:textbox><igtxt:webtextedit id="txtNomeCentroCusto" runat="server" Width="200px" Font-Names="Arial" Font-Size="11px"
	MaxLength="35"></igtxt:webtextedit><asp:dropdownlist id="cmbNomeCentroCusto" runat="server" Width="200px" Font-Names="Arial" Font-Size="11px"
	AutoPostBack="True" Visible="False" Height="19px"></asp:dropdownlist><asp:imagebutton id="btnBuscarCentroCusto" runat="server" CausesValidation="False" ImageAlign="AbsMiddle"
	ImageUrl="../../Imagens/office/procurar.gif"></asp:imagebutton>
