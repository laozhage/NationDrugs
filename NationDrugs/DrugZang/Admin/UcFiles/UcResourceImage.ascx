<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcResourceImage.ascx.cs" Inherits="NationDrugs.DrugZang.Admin.UcFiles.UcResourceImage" %>

<%@ Register src="../../../DrugZang/Ucshared/CharTextRequired.ascx" tagname="CharTextRequired" tagprefix="uc1" %>
<%@ Register src="../../../DrugZang/Ucshared/Ulable.ascx" tagname="Ulable" tagprefix="uc2" %>

<link href="Popwindows.css" rel="stylesheet" type="text/css" />
 
<style type="text/css"> 



.mybody{ width:890px; margin:0 ;position:absolute; z-index:999;
          height:500px; border:1px solid #ccc; padding:0px; background:#fff; display:none;
        
       
    } 
#cwxBg{ position:absolute; display:none; background:#000; width:100%; height:100%; left:0px; top:0px; z-index:1000;} 
#cwxWd{ position:absolute; display:none; border:10px solid #CCC; padding:10px;background:#FFF; z-index:1500;} 
#cwxCn{ background:#FFF; display:block;} 
.imgd{ width:400px; height:300px;} 
</style> 


<script type="text/javascript">
//    C$('testClick').onclick = function (srcc) {
//        var neirong = '<div><img src="'+srcc+'" class="imgd" /></div>';
//        cwxbox.box.show(neirong);
//    }
//    C$('testClick1').onclick = function () {
//        var neirong = '123456789132456789';
//        cwxbox.box.show(neirong, 3);
    //    }

    function ShowWin() {

       
    }


    function C$(id) { return document.getElementById(id); }
    //定义窗体对象 
    var cwxbox = {};

    cwxbox.box = function () {
        var bg, wd, cn, ow, oh, o = true, time = null;
        return {
            show: function (c, t, w, h) {
                if (o) {
                    bg = document.createElement('div'); bg.id = 'cwxBg';
                    wd = document.createElement('div'); wd.id = 'cwxWd';
                    cn = document.createElement('div'); cn.id = 'cwxCn';
                    document.body.appendChild(bg);
                    document.body.appendChild(wd);
                    wd.appendChild(cn);
                    bg.onclick = cwxbox.box.hide;
                    window.onresize = this.init;
                    window.onscroll = this.scrolls;
                    o = false;
                }
                if (w && h) {
                    var inhtml = '<iframe src="' + c + '" width="' + w + '" height="' + h + '" frameborder="0"></iframe>';
                } else {
                    var inhtml = c;
                }
                cn.innerHTML = inhtml;
                oh = this.getCss(wd, 'offsetHeight');
                ow = this.getCss(wd, 'offsetWidth');
                this.init();
                this.alpha(bg, 50, 1);
                this.drag(wd);
                if (t) {
                    time = setTimeout(function () { cwxbox.box.hide() }, t * 1000);
                }
            },
            hide: function () {
                cwxbox.box.alpha(wd, 0, -1);
                clearTimeout(time);
            },
            init: function () {
                bg.style.height = cwxbox.page.total(1) + 'px';
                bg.style.width = '';
                bg.style.width = cwxbox.page.total(0) + 'px';
                var h = (cwxbox.page.height() - oh) / 2;
                wd.style.top = (h + cwxbox.page.top()) + 'px';
                wd.style.left = (cwxbox.page.width() - ow) / 2 + 'px';
            },
            scrolls: function () {
                var h = (cwxbox.page.height() - oh) / 2;
                wd.style.top = (h + cwxbox.page.top()) + 'px';
            },
            alpha: function (e, a, d) {
                clearInterval(e.ai);
                if (d == 1) {
                    e.style.opacity = 0;
                    e.style.filter = 'alpha(opacity=0)';
                    e.style.display = 'block';
                }
                e.ai = setInterval(function () { cwxbox.box.ta(e, a, d) }, 40);
            },
            ta: function (e, a, d) {
                var anum = Math.round(e.style.opacity * 100);
                if (anum == a) {
                    clearInterval(e.ai);
                    if (d == -1) {
                        e.style.display = 'none';
                        if (e == wd) {
                            this.alpha(bg, 0, -1);
                        }
                    } else {
                        if (e == bg) {
                            this.alpha(wd, 100, 1);
                        }
                    }
                } else {
                    var n = Math.ceil((anum + ((a - anum) * .5)));
                    n = n == 1 ? 0 : n;
                    e.style.opacity = n / 100;
                    e.style.filter = 'alpha(opacity=' + n + ')';
                }
            },
            getCss: function (e, n) {
                var e_style = e.currentStyle ? e.currentStyle : window.getComputedStyle(e, null);
                if (e_style.display === 'none') {
                    var clonDom = e.cloneNode(true);
                    clonDom.style.cssText = 'position:absolute; display:block; top:-3000px;';
                    document.body.appendChild(clonDom);
                    var wh = clonDom[n];
                    clonDom.parentNode.removeChild(clonDom);
                    return wh;
                }
                return e[n];
            },
            drag: function (e) {
                var startX, startY, mouse;
                mouse = {
                    mouseup: function () {
                        if (e.releaseCapture) {
                            e.onmousemove = null;
                            e.onmouseup = null;
                            e.releaseCapture();
                        } else {
                            document.removeEventListener("mousemove", mouse.mousemove, true);
                            document.removeEventListener("mouseup", mouse.mouseup, true);
                        }
                    },
                    mousemove: function (ev) {
                        var oEvent = ev || event;
                        e.style.left = oEvent.clientX - startX + "px";
                        e.style.top = oEvent.clientY - startY + "px";
                    }
                }
                e.onmousedown = function (ev) {
                    var oEvent = ev || event;
                    startX = oEvent.clientX - this.offsetLeft;
                    startY = oEvent.clientY - this.offsetTop;
                    if (e.setCapture) {
                        e.onmousemove = mouse.mousemove;
                        e.onmouseup = mouse.mouseup;
                        e.setCapture();
                    } else {
                        document.addEventListener("mousemove", mouse.mousemove, true);
                        document.addEventListener("mouseup", mouse.mouseup, true);
                    }
                }

            }
        }
    } ()

    cwxbox.page = function () {
        return {
            top: function () { return document.documentElement.scrollTop || document.body.scrollTop },
            width: function () { return self.innerWidth || document.documentElement.clientWidth || document.body.clientWidth },
            height: function () { return self.innerHeight || document.documentElement.clientHeight || document.body.clientHeight },
            total: function (d) {
                var b = document.body, e = document.documentElement;
                return d ? Math.max(Math.max(b.scrollHeight, e.scrollHeight), Math.max(b.clientHeight, e.clientHeight)) :
Math.max(Math.max(b.scrollWidth, e.scrollWidth), Math.max(b.clientWidth, e.clientWidth))
            }
        }
    } () 
</script> 


<table cellpadding="4" cellspacing="0" border="1" width="100%" 
        style="border-collapse: collapse; font-size:10pt; background-color:#e7eaf1; border-color:#588fc7;" 
        bordercolor="#588fc7">
      <tr>
        <td colspan = "6" align = "center" bgcolor="#588fc7">
        <span lang = "zh-cn" style=" color:white;"><strong>第六步：资源图像描述信息</strong>  </span>
        </td>                    
            </tr>                    
   <tr>
        <td style =" width:10%;" align = "right" >
               <span lang="zh-cn">民族文字:</span></td>
        <td bgcolor="white" colspan="5"  >
                <uc2:Ulable ID="Ulable1" runat="server" />
        </td> 
    </tr>                      
   <tr>
        <td style =" width:10%;" align = "right" >
                <span lang="zh-cn">图片描述:</span>
        </td>
        <td bgcolor="white"style =" width:20%;"  >
                <uc1:CharTextRequired ID="CharTextRequired1" runat="server" Width="90%" 
                    ValidationGroup="1" />
        </td>
        <td style =" width:10%;"  align = "right" >
                <span lang="zh-cn">图像类别:</span>
        </td>
        <td bgcolor="white" style ="width:10%; ">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" >
                    <asp:ListItem Value="0" Selected="True">药材图像（68）</asp:ListItem>
                    <asp:ListItem Value="1">原植物图像（69）</asp:ListItem>
                    <asp:ListItem Value="2">种质资源图像（70）</asp:ListItem>
                    <asp:ListItem Value="3">标本图像（71）</asp:ListItem>
                </asp:DropDownList>
        </td>    
        
          <td style ="width:10%;" align = "left" >
              <span lang="zh-cn">文件路径:</span>
          </td>
          <td bgcolor="white"  style ="width:40%;" align = "left"  >
             <asp:FileUpload ID="fupPicPath" 
                    runat="server" />
         
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                  ControlToValidate="fupPicPath" ErrorMessage="*" ForeColor="Red" 
                  ValidationGroup="1"></asp:RequiredFieldValidator>
            
        
                <asp:Button ID="btn_upload" runat="server" Text="文件上传" 
                  onclick="btn_upload_Click" ValidationGroup="1" />
              <asp:Label ID="l1" runat="server" Visible="False"></asp:Label>
        </td>
          
  
    </tr>
                    
   <tr>
        <td align = "left" colspan="6" bgcolor="white" >
          
        <div class="mybody"> 

        </div>
        
        <asp:DataList ID="DataList1" runat="server" DataKeyField="imgid" 
        RepeatColumns="4" 
        RepeatDirection="Horizontal" Height="216px" Width="219px" 
        BackColor="White" BorderColor="#588FC7" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="3" GridLines="Both" CellSpacing="4" style="text-align: center;" 
                onitemcommand="DataList1_ItemCommand">
         
            <FooterStyle BackColor="White" ForeColor="#588fc7" />
            <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="White" />
            <ItemStyle   BackColor="White" ForeColor="#588fc7" />
         
            <ItemTemplate>
              <table cellpadding="4" cellspacing="0" border="1" width="100%"  
                style="border-collapse: collapse; text-align:center; font-size:10pt; background-color:#e7eaf1; border-color:#588fc7;" 
                bordercolor="#588fc7">
                    <tr>
                        <td bgcolor = "white" >
                            <asp:Label ID="imagenameLabel" runat="server" style="font-weight: 700" 
                                Text='<%# Eval("imagename") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor = "white"> 
                          <%--  <a href= '<%#Eval("filepath") %>' target="_blank">--%>
                            <asp:Image ID="Image1" runat="server" Height="248px" 
                                      ImageUrl='<%# Eval("filepath") %>' Width="255px" />                         
                         </td>
                    </tr>
                    <tr>
                        <td>
                         <asp:LinkButton ID="LinkButton2" runat="server"
                             CommandArgument = '<%#DataBinder.Eval(Container.DataItem,"imgid")  %>' 
                             CommandName = "detail"                             
                             ValidationGroup="vdel" >
                            【显示原图】</asp:LinkButton>                          
                           
                           <asp:LinkButton ID="LinkButton1" runat="server" CommandName = "del"  
                                OnClientClick='return confirm("确定删除该条记录？")'  
                                CommandArgument = '<%#DataBinder.Eval(Container.DataItem,"imgid")  %>' 
                                ValidationGroup="vdel" >【删除】</asp:LinkButton>
                        </td>                        
                    </tr>
                </table>
                
                
             </ItemTemplate>
       
            <SelectedItemStyle BackColor="White" Font-Bold="True" ForeColor="White" />
       
     </asp:DataList>
     

      </td>
          
  
    </tr>
    
     <tr>
        <td align = "center" colspan="6" >           
          
            <asp:Button ID="btn_back8" runat="server" onclick="btn_back8_Click" 
                Text="&lt;&lt;上一步" ValidationGroup="2" />
            <asp:Button ID="btn_next8" runat="server" onclick="btn_next8_Click" 
                Text="下一步&gt;&gt;" ValidationGroup="2" />
          
      </td>
          
  
    </tr>           
                     
</table>


<asp:HiddenField ID="hid_drugid" runat="server" Visible="False" />
<asp:HiddenField ID="hid_ImageCat" runat="server" Visible="False" />




