<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ASourceImages.aspx.cs" Inherits="NationDrugs.DrugZang.Admin.AdWeb.ASourceImages" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<style type="text/css">
#winpop { width:600px; height:0px; position:absolute; left:100px; top:100px; border:1px solid #666; margin:0; padding:1px; overflow:hidden; display:none;}
#winpop .title { width:100%; height:22px; line-height:20px; background:#FFCC00; font-weight:bold; text-align:center; font-size:12px;}
#silu { font-size:12px; color:#666; position:absolute; right:0; text-align:right; text-decoration:underline; line-height:22px;}
.close { position:absolute; right:4px; top:-1px; color:#FFF; cursor:pointer}
</style>

<script type="text/javascript">
    function tips_pop() {
        var MsgPop = document.getElementById("winpop");
        var popH = parseInt(MsgPop.style.height); //将对象的高度转化为数字
        if (popH == 0) {
            MsgPop.style.display = "block"; //显示隐藏的窗口
            show = setInterval("changeH('up')", 2);
        }
        else {
            hide = setInterval("changeH('down')", 2);
        }
    }
    function changeH(str) {
        var MsgPop = document.getElementById("winpop");
        var popH = parseInt(MsgPop.style.height);
        if (str == "up") {
            if (popH <= 400) {
                MsgPop.style.height = (popH + 4).toString() + "px";
            }
            else {
                clearInterval(show);
            }
        }
        if (str == "down") {
            if (popH >= 4) {
                MsgPop.style.height = (popH - 4).toString() + "px";
            }
            else {
                clearInterval(hide);
                MsgPop.style.display = "none"; //隐藏DIV
            }
        }
    }
    function  ShowWin () {//加载
        document.getElementById('winpop').style.height = '0px';
        setTimeout("tips_pop()", 1); //3秒后调用tips_pop()这个函数
    }
</script>



</head>
<body>
    <form id="form1" runat="server">
  <%--  <div>
      <table style="width:611px;height:125px" align="center">
       <tr>
            
       <td colspan="3">
        <div id="demo" style="OVERFLOW: hidden; WIDTH: 611px;  align: center">
        <table cellspacing="0" cellpadding="0" align="center" border="0">
          <tbody>
            <tr>
              <td id="marquePic1" valign="top">
                 <table border="2">
                   <tr>
                      <td style="width: 122px">
                          <input type="image" name="ImageButton1" id="ctl00_ContentPlaceHolder1_ImageButton1" src="../SourceImages/1.jpg" style="height:125px;width:122px;border-width:0px;" /></td>
                      <td style="width: 122px">
                          <input type="image" name="ImageButton2" id="ctl00_ContentPlaceHolder1_ImageButton2" src="../SourceImages/2.jpg" style="height:125px;width:122px;border-width:0px;" /></td>
                      <td style="width: 122px">
                          <input type="image" name="ImageButton3" id="ctl00_ContentPlaceHolder1_ImageButton3" src="../SourceImages/3.jpg" style="height:125px;width:122px;border-width:0px;" /></td>
                      <td style="width: 122px">
                          <input type="image" name="ImageButton4" id="ctl00_ContentPlaceHolder1_ImageButton4" src="../SourceImages/4.jpg" style="height:125px;width:122px;border-width:0px;" /></td>
                      <td style="width: 122px">
                          <input type="image" name="ImageButton5" id="ctl00_ContentPlaceHolder1_ImageButton5" src="../SourceImages/5.jpg" style="height:125px;width:122px;border-width:0px;" /></td>
                       <td style="width: 122px">
                          <input type="image" name="ImageButton6" id="Image1" src="../SourceImages/6.jpg" style="height:125px;width:122px;border-width:0px;" /></td>
                      <td style="width: 122px">
                          <input type="image" name="ImageButton7" id="Image2" src="../SourceImages/7.jpg" style="height:125px;width:122px;border-width:0px;" /></td>
                      <td style="width: 122px">
                          <input type="image" name="ImageButton8" id="Image3" src="../SourceImages/8.jpg" style="height:125px;width:122px;border-width:0px;" /></td>
                      <td style="width: 122px">
                          <input type="image" name="ImageButton9" id="Image4" src="../SourceImages/9.jpg" style="height:125px;width:122px;border-width:0px;" /></td>
                     
                  
                  </tr>             
                  </table>
             </td>
              <td id="marquePic2" valign="top"></td>
            </tr>
          </tbody>
          
        </table>
      </div>
        <script type ="text/javascript">
            var speed = 30
            marquePic2.innerHTML = marquePic1.innerHTML
            function Marquee() {
                if (demo.scrollLeft >= marquePic1.scrollWidth) {
                    demo.scrollLeft = 0
                } else {
                    demo.scrollLeft++
                }
            }
            var MyMar = setInterval(Marquee, speed)
            demo.onmouseover = function () { clearInterval(MyMar) }
            demo.onmouseout = function () { MyMar = setInterval(Marquee, speed) }
        </script>
        
        
 

            </td>
       </tr>
    </table>
    </div>--%>

    <div id="winpop">
    <div class="title">您有新的短消息！<span class="close" onclick="tips_pop()">X</span></div>
    <div>
        <asp:Image ID="Image1" runat="server" />
    </div>
    
    </div>

    <input id="Button1" type="button" value="button" onclick = "ShowWin()" /></form>
</body>
</html>
