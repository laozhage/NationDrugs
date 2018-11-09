<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="NationDrugs.Log.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
<script language = "javascript" type = "text/javascript">
    function tmtC_winMaximizer() {
        if (document.layers) {
            var larg = screen.availWidth - 10;
            var altez = screen.availHeight - 20;
        }
        else {
            var larg = screen.availWidth - 2;
            var altez = screen.availHeight;
        }
        self.resizeTo(larg, altez);
        self.moveTo(0, 0);
    }
</script>  
</head>

<frameset rows="64,*,20,0" cols="*" frameborder="NO" border="0" framespacing="0" onload = "tmtC_winMaximizer();">
    <frame name="topFrame" scrolling="NO" src="top.aspx" frameborder="no">
    <frame name="mainFrame" src="middle.aspx" marginwidth="0" scrolling="auto" frameborder="no">
    <frame name="bottomFrame" scrolling="NO" noresize src="bottom.aspx" frameborder="no">
</frameset>
<noframes>
	<body bgcolor="#FFFFFF" text="#000000">
		您的浏览器不支持框架。
	</body>
</noframes>
</html>

