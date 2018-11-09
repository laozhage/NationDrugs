<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="NationDrugs.Log.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>用户登录</title>
    
    <link  href ="images/login.css"  rel="stylesheet" type="text/css" />
    <style type="text/css">
       
    </style>
     <script  language="javascript" type="text/javascript">
         function getimgcode() {
             var randomnum = Math.random();
             var getimagecode = document.getElementById("Image1");
             getimagecode.src = "../Log/VerifyCode.ashx?" + Math.random();

         } 
      </script> 
</head>
<body>

    <form id="form1" runat="server">

	
    <table id="__01" width="1025" height="769" border="0" cellpadding="0" cellspacing="0" align="center">
	<tr>
		<td rowspan="9">
			<img src="images/login/NTDruglogin_01.gif" width="168" height="768" alt=""></td>
		<td colspan="5">
			<img src="images/login/NTDruglogin_02.gif" width="682" height="135" alt=""></td>
		<td rowspan="9">
			<img src="images/login/NTDruglogin_03.gif" width="174" height="768" alt=""></td>
		<td>
			<img src="images/login/split.gif" width="1" height="135" alt=""></td>
	</tr>
	<tr>
		<td colspan="5">
			<img src="images/login/NTDruglogin_04.gif" width="682" height="92" alt=""></td>
		<td>
			<img src="images/login/split.gif" width="1" height="92" alt=""></td>
	</tr>
	<tr>
		<td colspan="2" rowspan="3">
			<img src="images/login/NTDruglogin_05.gif" width="256" height="129" alt=""></td>
		<td colspan="3">
			<img src="images/login/NTDruglogin_06.gif" width="426" height="1" alt=""></td>
		<td>
			<img src="images/login/split.gif" width="1" height="1" alt=""></td>
	</tr>
	<tr>
		<td colspan="2" rowspan="3">
            
            <table width="242"  height="129" border="0" align="left" cellpadding="0" cellspacing="0">
  <tr>
    <td style= " vertical-align:middle;">
      <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="*" ForeColor="Red" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
    </td>
  </tr>
  <tr>
    <td>
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="TextBox2" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
      </td>
  </tr>
  <tr>
    <td ><asp:TextBox ID="txt_checkCode" runat="server" Width = "70px" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="txt_checkCode" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
    <asp:Image ID="Image1" runat="server" Height="24px" 
                           ImageUrl="~/Log/VerifyCode.ashx" Width="74px" ImageAlign="Bottom" />
      <input name="buton" id="button1"  type="button" value="换一张" onclick = "getimgcode() " />
      </td>
  </tr>
</table>
            
            
            
            </td>
		<td>
			<img src="images/login/NTDruglogin_08.gif" width="184" height="101" alt=""></td>
		<td>
			<img src="images/login/split.gif" width="1" height="101" alt=""></td>
	</tr>
	<tr>
		<td rowspan="4">
			<img src="images/login/NTDruglogin_09.gif" width="184" height="144" alt=""></td>
		<td>
			<img src="images/login/split.gif" width="1" height="27" alt=""></td>
	</tr>
	<tr>
		<td colspan="2">
			<img src="images/login/NTDruglogin_10.gif" width="256" height="1" alt=""></td>
		<td>
			<img src="images/login/split.gif" width="1" height="1" alt=""></td>
	</tr>
	<tr>
		<td rowspan="2">
			<img src="images/login/NTDruglogin_11.gif" width="216" height="116" alt=""></td>
		<td colspan="2" background = "images/login/NTDruglogin_12.gif" align = "right">
                <asp:ImageButton ID="btn_login" runat="server" BorderStyle="None" Height="41px" 
                    ImageUrl="~/Log/images/login/log.png" onclick="btn_login_Click" Width="90px" />
                </td>
		<td background = "images/login/NTDruglogin_13.gif">
			<asp:ImageButton ID="btn_reset" runat="server" BorderStyle="None" Height="41px" 
                ImageUrl="~/Log/images/login/reset.png" Width="90px" />
			</td>
		<td>
			<img src="images/login/split.gif" width="1" height="55" alt=""></td>
	</tr>
	<tr>
		<td colspan="3" background = "images/login/NTDruglogin_14.gif" align = "left"  valign ="top" >
			<asp:Label ID="lbl_errorMessage" runat="server" ForeColor="Red"></asp:Label>
			</td>
		<td>
			<img src="images/login/split.gif" width="1" height="61" alt=""></td>
	</tr>
	<tr>
		<td colspan="5">
			<img src="images/login/NTDruglogin_15.jpg" width="682" height="295" alt=""></td>
		<td>
			<img src="images/login/split.gif" width="1" height="295" alt=""></td>
	</tr>
	<tr>
		<td>
			<img src="images/login/split.gif" width="168" height="1" alt=""></td>
		<td>
			<img src="images/login/split.gif" width="216" height="1" alt=""></td>
		<td>
			<img src="images/login/split.gif" width="40" height="1" alt=""></td>
		<td>
			<img src="images/login/split.gif" width="82" height="1" alt=""></td>
		<td>
			<img src="images/login/split.gif" width="160" height="1" alt=""></td>
		<td>
			<img src="images/login/split.gif" width="184" height="1" alt=""></td>
		<td>
			<img src="images/login/split.gif" width="174" height="1" alt=""></td>
		<td></td>
	</tr>
</table>
	  

  
    </form>
</body>
</html>

