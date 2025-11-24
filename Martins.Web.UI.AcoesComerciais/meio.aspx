<%@ Page Language="vb" AutoEventWireup="false" Codebehind="meio.aspx.vb" Inherits="Martins.Web.UI.AcoesComerciais.meio" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Meio</TITLE>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script type="text/javascript">

/***********************************************
* Collapsible Frames script- © Dynamic Drive (www.dynamicdrive.com)
* This notice must stay intact for use
* Visit http://www.dynamicdrive.com/ for full source code
***********************************************/

var columntype=""
var defaultsetting=""

function getCurrentSetting(){
if (document.body)
return (document.body.cols)? document.body.cols : document.body.rows
}

function setframevalue(coltype, settingvalue){
if (coltype=="rows")
document.body.rows=settingvalue
else if (coltype=="cols")
document.body.cols=settingvalue
}

function resizeFrame(contractsetting){
if (getCurrentSetting()!=defaultsetting)
setframevalue(columntype, defaultsetting)
else
setframevalue(columntype, contractsetting)
}

function init(){
if (!document.all && !document.getElementById) return
if (document.body!=null){
columntype=(document.body.cols)? "cols" : "rows"
defaultsetting=(document.body.cols)? document.body.cols : document.body.rows
}
else
setTimeout("init()",100)
}

setTimeout("init()",100)

		</script>
	</HEAD>
	<frameset cols="265,80%" frameborder="NO" border="0" framespacing="0">
		<frame src="menu.aspx" name="menu" noresize id="menu">
		<frame src="Principal.aspx" name="principal" scrolling="no" id="principal">
	</frameset>
</HTML>
