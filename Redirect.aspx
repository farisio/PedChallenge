<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Redirect.aspx.cs" Inherits="Redirect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pedometer Challenge 2016</title>
	<script type="text/javascript">
	    function openURL() {
	        var shell = new ActiveXObject("WScript.Shell");
	        shell.run("Chrome https://pedometerchallenge.xlthtr.nhs.uk");
	    }
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!--[if lte IE 9]>
		<p>This site only works in IE10 or above and Google Chrome, please click the button to view the site in Chrome.</p>
		<p><input type="button" onclick="openURL()" value="Go to Chrome"></p>
	<![endif]-->
    </div>
    </form>
</body>
</html>
