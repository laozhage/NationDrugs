<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="leftMenu.aspx.cs" Inherits="NationDrugs.Log.leftMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <style type="text/css"> 
  BODY {
	   border:none;
	   SCROLLBAR-FACE-COLOR: #ebf7ff; 
	   SCROLLBAR-HIGHLIGHT-COLOR: #ebf7ff;
	   SCROLLBAR-SHADOW-COLOR: #999999;
	   SCROLLBAR-3DLIGHT-COLOR: #ffffff; 
	   SCROLLBAR-ARROW-COLOR: #ff9900; 
	   SCROLLBAR-TRACK-COLOR: #ebf7ff; 
	   SCROLLBAR-DARKSHADOW-COLOR: #ebf7ff;
	   line-height: 22px; 
	   background-color: #ebf7ff;
	   FONT-SIZE: 10pt;
	   COLOR: #494949; 
}


INPUT {
 BEHAVIOR: url(inputxp.htc); 
 }
 
SELECT{
	font-family: Verdana, Arial, 宋体;
	font-size: 10pt;
	color: #0560A6;
	border: #7F9DB9 1px solid;
	height: 20px;
	width:60px
}

.ddl
{
	background-color: #E6E6E6; 	
	border: 1px #7f9db9 solid; 
	font-family: Verdana, Arial, 宋体;
	font-size: 9pt;
	color: #0560A6;
	height: 20px;
	width:60px
}
A:link {
	FONT-SIZE: 10pt; 
	COLOR: #494949 ; 
	TEXT-DECORATION: none;
}

A:visited {
	 FONT-SIZE: 10pt;
	 COLOR: #494949; 
	 TEXT-DECORATION: none;
}

A:active {
	FONT-SIZE: 10pt;
    COLOR: #494949; 
}

A:hover {
	FONT-SIZE: 10pt; 
	COLOR: #990000; 
}

tr {
	FONT-SIZE: 10pt; 
	COLOR: #494949; 
}

.bg_line {  border: solid; top: -10px; clip:  rect(   ); border-color: #CCCCCC #CCCCCC #FFFFFF; color: #999999; border-width: 0px 0px 1px; text-decoration: none}

.button_a  {height:22px; cursor: hand;FONT-SIZE: 9pt; border-color: #FFFFFF #999999 #999999 #FFFFFF; padding-top: 2px; border-style: solid; border-top-width: 1px; border-right-width: 1px; border-bottom-width: 1px; border-left-width: 1px;background-color: #ebf7ff}

.button_c  {width: 22px; height: 22px; vertical-align:middle; text-align:center; cursor: hand;FONT-SIZE: 9pt; border-color: #FFFFFF #999999 #999999 #FFFFFF; border-style: solid; border-top-width: 1px; border-right-width: 1px; border-bottom-width: 1px; border-left-width: 1px;background-color: #ebf7ff}

.button_b {cursor: hand;FONT-SIZE: 9pt; padding-top: 2px;  background-color:#ebf7ff; border: ebf7ff; border-style: solid; border-top-width: 1px; border-right-width: 1px; border-bottom-width: 1px; border-left-width: 1px}

.headtd1  {cursor: hand;FONT-SIZE: 9pt; border-color: #FFFFFF #999999 #999999 #FFFFFF; padding-top: 2px; border-style: solid; border-top-width: 1px; border-right-width: 1px; border-bottom-width: 1px; border-left-width: 1px;; background-color:#ebf7ff}

.headtd2 {cursor: hand;FONT-SIZE: 9pt; padding-top: 2px;  background-color: #ebf7ff; border: ebf7ff; border-style: solid; border-top-width: 1px; border-right-width: 1px; border-bottom-width: 1px; border-left-width: 1px}

.bodytd  {  
	background: #d6d3ce; 
	
	border: 0px outset;
	border-color: #d6d3ce #d6d3ce #d6d3ce #d6d3ce;
    font-size: 9pt;
}

.input_a{  
	background-color: #E6E6E6; 
	color: #000000; 
	BORDER-BOTTOM: #888888 1px solid; 
	BORDER-LEFT: #888888 1px solid; 
	BORDER-RIGHT: #888888 1px solid; 
	BORDER-TOP: #888888 1px solid; 
	clip:    rect(   ); 
	border: 1px #999999 solid; 
	vertical-align: middle
}

.input_b
{
	background-color: #ffffff; 
	color: #000000; 
	BORDER-BOTTOM: #888888 1px solid; 
	BORDER-LEFT: #888888 1px solid; 
	BORDER-RIGHT: #888888 1px solid; 
	BORDER-TOP: #888888 1px solid; 
	clip:    rect(   ); 
	border: 1px #999999 solid; 
	vertical-align: middle;
	width:60px
}

.btn
{
	background-color: #E6E6E6; 	
	border: 1px #999999 solid; 
	height: 20px;
}
.cursor {cursor: hand;}

.about { 
   line-height: 21px;
 }

legend{
	color:#ffffff;
	background-color:#ABA161;
	padding:3 15 3 15;
}

.tbtitle{background:#E0DCC0;}

.dvBorder
{
	 border-top-color:#ffffff;
	 border-bottom-color:#ffffff;
	  border-left-color:#888888;
	  border-right-color:#888888;
}

</style>

  <script type="text/javascript">
      ///显示菜单
      function hidden_showmenu(str1, str2) {
          if (document.all['menu' + str1].style.display == "inline") {
              document.all['menu' + str1].style.display = "none";
          }
          else {
              for (var i = 1; i <= str2; i++) {
                  document.all['menu' + i].style.display = "none";
              }
              document.all['menu' + str1].style.display = "inline";
          }
      }
      ///显示时间
      function showTime() {
          var now = new Date();
          var year = now.getYear();
          var month = now.getMonth() + 1;
          var date = now.getDate();
          var hours = now.getHours();
          var mins = now.getMinutes();
          var secs = now.getSeconds();
          var timeVal = "";
          timeVal += hours;
          timeVal += ((mins < 10) ? ":0" : ":") + mins;
          timeVal += ((secs <= 10) ? ":0" : ":") + secs;

          document.all.face.innerHTML = "时间：" + timeVal;
          timerID = setTimeout("showTime()", 1000);
      }
      showTime(); 

</script>  

</head>
<body style =" margin-top:0px; margin-left:0px;">
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
