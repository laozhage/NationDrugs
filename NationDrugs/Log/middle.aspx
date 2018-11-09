<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="middle.aspx.cs" Inherits="NationDrugs.Log.middle" %>


<html>
<head id="Head1" runat="server">
	<style type="text/css">
		.navPoint
		{
			color: #E9F1A4;
			cursor: hand;
			font-family: Webdings;
			font-size: 9pt;
		}
	</style>

	<script type="text/javascript">
	    function switchSysBarLeft() {
	        if (switchPointLeft.innerText == 3) {
	            switchPointLeft.innerText = 4
	            document.all("frmleft").style.display = "none"
	        }
	        else {
	            switchPointLeft.innerText = 3
	            document.all("frmleft").style.display = ""
	        }
	    }
	    function openMenu() {
	        if (switchPointLeft.innerText == 4) {
	            switchPointLeft.innerText = 3;
	            document.all("frmleft").style.display = "";
	        }
	        else {
	            switchPointLeft.innerText = 3
	            document.all("frmleft").style.display = "";
	        }
	    }
	</script>
</head>
<body style="overflow-x: hidden; overflow-y: hidden">
	<div align="center">
		<table border="0" width="100%" height="100%" cellspacing="0" cellpadding="0" bgcolor="White">
			<tr>
				<td height="100%" width="200px" id="frmleft" name="frmleft">
					<iframe frameborder="0" id="fleft" scrolling="NO" noresize name="fleft" src="left.aspx"
						style="height: 100%; visibility: inherit; width: 200px"></iframe>
				</td>
				<td width="2" height="100%" valign="top">
					<table border="0" cellpadding="0" cellspacing="0" style="height:100%; background-color: #588fc7">
						<tr>
							<td valign="top" onclick="switchSysBarLeft();" title="关闭/打开菜单">
								<span class="navPoint" id="switchPointLeft">3</span>
							</td>
						</tr>
					</table>
				</td>
				<td height="100%" id="frmmain" name="frmmain" valign="top" align="left" width="100%">
					<iframe frameborder="0" id="fmain" scrolling="yes" noresize name="fmain" src="main.aspx"
						style="height: 100%; visibility: inherit; width: 100%"></iframe>
				</td>
			</tr>
		</table>
	</div>
</body>
</html>
