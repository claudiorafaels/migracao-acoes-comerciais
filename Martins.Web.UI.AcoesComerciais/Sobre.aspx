<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics.WebUI.UltraWebGrid.v5.3, Version=5.3.20053.50, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Sobre.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.Sobre" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>:: PRIME SOBRE ::</title>
<meta http-equiv=Content-Type content="text/html; charset=iso-8859-1"><LINK href="style.css" type=text/css rel=stylesheet >
  </HEAD>
<body>
<form id=Form1 method=post runat="server">
<table height=56 cellSpacing=0 cellPadding=0 width=781 align=center border=0>
  <tr>
    <td align=center>
      <table cellSpacing=0 cellPadding=0 width=780 border=0>
        <tr>
          <td align=center width="35%" height=65><IMG height=36 src="../../../IMAGENS/LogoMartins.gif" width=48  ?></td>
          <td vAlign=middle align=center width="30%" height=65 
          ><asp:label id=Label1 runat="server" Width="100%" Font-Size="Smaller" Font-Bold="True" ForeColor="MidnightBlue" Font-Italic="True">MARTINS COMÉRCIO E SERVIÇOS DE DISTRIBUIÇÃO S/A</asp:label></td>
          <td width="35%" height=65><IMG height=65 src="/IMAGENS/primeteam.gif" width=200  ?></td></tr>
        <tr>
          <td width=56></td>
          <td align=center width="100%" <td>
          <td width=0></td></tr></table>
      <P><igtbl:ultrawebgrid id=grdInformacoes runat="server" Width="600px" ImageDirectory="/ig_common/Images/" Height="182px">
<DisplayLayout StationaryMargins="Header" AllowSortingDefault="OnClient" RowHeightDefault="20px" Version="4.00" SelectTypeRowDefault="Extended" ViewType="OutlookGroupBy" AllowColumnMovingDefault="OnServer" HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowColSizingDefault="Free" RowSelectorsDefault="No" Name="grdInformacoes" TableLayout="Fixed" NoDataMessage="Sem informa&#231;&#245;es neste momento...">

<AddNewBox Hidden="False">

<Style BorderWidth="1px" BorderColor="InactiveCaption" BorderStyle="Solid" BackColor="Window">

<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
</BorderDetails>

</Style>

</AddNewBox>

<Pager>

<Style BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">

<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
</BorderDetails>

</Style>

</Pager>

<HeaderStyleDefault BorderStyle="Solid" HorizontalAlign="Left" BackColor="LightGray">

<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
</BorderDetails>

</HeaderStyleDefault>

<GroupByRowStyleDefault BorderColor="Window" BackColor="Control">
</GroupByRowStyleDefault>

<FrameStyle Width="600px" BorderWidth="1px" Font-Size="11px" Font-Names="Arial" BorderColor="InactiveCaption" BorderStyle="Solid" BackColor="Window" Height="182px">
</FrameStyle>

<FooterStyleDefault BorderWidth="1px" BorderStyle="Solid" BackColor="LightGray">

<BorderDetails ColorTop="White" WidthLeft="1px" WidthTop="1px" ColorLeft="White">
</BorderDetails>

</FooterStyleDefault>

<GroupByBox Hidden="True" Prompt="Arraste uma coluna aqui para efetuar o agrupamento por esta coluna...">

<Style BorderColor="Window" BackColor="ActiveBorder">
</Style>

</GroupByBox>

<EditCellStyleDefault BorderWidth="0px" BorderStyle="None">
</EditCellStyleDefault>

<RowAlternateStyleDefault BackColor="#F5F9FD">
</RowAlternateStyleDefault>

<RowStyleDefault BorderWidth="1px" BorderColor="Silver" BorderStyle="Solid" BackColor="Window">

<Padding Left="3px">
</Padding>

<BorderDetails WidthLeft="0px" WidthTop="0px">
</BorderDetails>

</RowStyleDefault>

</DisplayLayout>

<Bands>
<igtbl:UltraGridBand Key="informacoes"></igtbl:UltraGridBand>
</Bands>
</igtbl:ultrawebgrid></P></td></tr>
  <tr>
    <td align=center></td></tr></table></form>
	</body>
</HTML>
