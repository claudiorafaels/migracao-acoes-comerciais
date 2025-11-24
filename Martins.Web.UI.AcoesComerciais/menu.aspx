<%@ Page Language="vb" AutoEventWireup="false" Codebehind="menu.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.menu" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head>
		<title>Menu</title>
		<style>
	a, A:link, a:visited, a:active, A:hover
		{color: #000000; text-decoration: none; font-family: Tahoma, Verdana; font-size: 12px}
body {
	background-color: #F0F5FA;
}
</style>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
	</head>
	<body bottommargin="0" topmargin="0" leftmargin="0" rightmargin="0" marginheight="0" marginwidth="0">
		<script language="JavaScript" src="tree.js"></script>
		<script language="JavaScript" src="tree_items.js"></script>
		<script language="JavaScript" src="tree_tpl.js"></script>
		<table cellpadding="5" cellspacing="0" border="0" width="100%">
			<tr>
				<td>
					<script language="JavaScript">
	<!--//
		new tree (TREE_ITEMS, TREE_TPL);
	//-->
					</script>
				</td>
			</tr>
		</table>
	</body>

</html>