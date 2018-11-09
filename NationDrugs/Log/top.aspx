<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="NationDrugs.Log.top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href ="../App_Themes/myskin/default.css" rel = "Stylesheet" type = "text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table id="divHeader" style="width: 100%; height: 62px; background-image: url(images/bg1.jpg);" cellspacing="0" cellpadding="0" border="0">
			<tr>
				<td>
					<img src="images/top.jpg" border="0" alt="" />
				</td>
				<td style="width: 280px; padding-right: 20px; color: White" valign="middle" align="right" nowrap="nowrap">
					当前用户：<asp:Label ID="lblUserId" runat="server" />
					<br />
					<a title="点击修改您的登录密码！" href="../DrugHan/Admin/UserModi/ModiPass.aspx" target="fmain">修改密码</a>
					<%--<a title="查看系统帮助文件" href="#" target="_blank">帮助</a>--%>
					<a title="重新登录/注销" href="logout.ashx" target="_top">退出</a>
				</td>
			</tr>
		</table>
    </div>
    </form>
</body>
</html>
