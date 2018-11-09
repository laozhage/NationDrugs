<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcUser.ascx.cs" Inherits="NationDrugs.DrugWei.Admin.UcFiles.UcUser" %>

<%@ Register src="../../Ucshared/Ulable.ascx" tagname="Ulable" tagprefix="uc1" %>
<%@ Register src="../../Ucshared/CharTextRequired.ascx" tagname="CharTextRequired" tagprefix="uc2" %>

<script  language = "javascript" type = "text/javascript">

    //CharMode函数     
    //测试某个字符是属于哪一类.     
    function CharMode(iN) {
        if (iN >= 48 && iN <= 57) //数字     
            return 1;
        if (iN >= 65 && iN <= 90) //大写字母     
            return 2;
        if (iN >= 97 && iN <= 122) //小写     
            return 4;
        else
            return 8; //特殊字符     
    }
    //bitTotal函数     
    //计算出当前密码当中一共有多少种模式     
    function bitTotal(num) {
        modes = 0;
        for (i = 0; i < 4; i++) {
            if (num & 1) modes++;
            num >>>= 1;
        }
        return modes;
    }
    //checkStrong函数     
    //返回密码的强度级别     

    function checkStrong(sPW) {
        if (sPW.length <= 4)
            return 0; //密码太短     
        Modes = 0;
        for (i = 0; i < sPW.length; i++) {
            //测试每一个字符的类别并统计一共有多少种模式.     
            Modes |= CharMode(sPW.charCodeAt(i));
        }
        return bitTotal(Modes);
    }

    //pwStrength函数     
    //当用户放开键盘或密码输入框失去焦点时,根据不同的级别显示不同的颜色     
    function pwStrength(pwd) {
        O_color = "#e0f0ff";
        L_color = "#FF0000";
        M_color = "#FF9900";
        H_color = "#33CC00";
        if (pwd == null || pwd == '') {
            Lcolor = Mcolor = Hcolor = O_color;
        }
        else {
            S_level = checkStrong(pwd);
            switch (S_level) {
                case 0:
                    Lcolor = Mcolor = Hcolor = O_color;
                case 1:
                    Lcolor = L_color;
                    Mcolor = Hcolor = O_color;
                    break;
                case 2:
                    Lcolor = Mcolor = M_color;
                    Hcolor = O_color;
                    break;
                default:
                    Lcolor = Mcolor = Hcolor = H_color;
            }
        }

        document.getElementById("strength_L").style.background = Lcolor;
        document.getElementById("strength_M").style.background = Mcolor;
        document.getElementById("strength_H").style.background = Hcolor;
        return;
    }     



</script>
  <div>
    <table cellpadding="4" cellspacing="0" border="1" width="100%" 
        style="border-collapse: collapse; font-size:10pt; background-color:#e7eaf1; border-color:#588fc7;" 
        bordercolor="#588fc7">
      <tr>
        <td colspan = "6" align = "center" bgcolor="#588fc7">
        <span lang = "zh-cn" style=" color:white;"><strong>修改个人信息</strong>  </span>
        </td>                    
            </tr>                    
       <tr>
        <td style =" width:10%;" align = "right" >
                <span lang="zh-cn">用户ID:</span>
        </td>
        <td bgcolor="white"style =" width:23%;"  >
                <uc1:Ulable ID="Ulable1" runat="server" />
           </td>
        <td style =" width:10%;"  align = "right" >
                <span lang="zh-cn">真实姓名:</span>
        </td>
        <td bgcolor="white" style ="width:23%; ">
                <uc1:Ulable ID="Ulable2" runat="server" />
           </td>    
        
          <td style ="width:10%;" align = "right" >
              <span lang="zh-cn">用户组别:</span>
          </td>
          <td bgcolor="white"  style ="width:24%;" align = "left"  >
              <uc1:Ulable ID="Ulable3" runat="server" />
           </td>
          
  
    </tr>                   
    </table> 

      <table cellpadding="4" cellspacing="0" border="1" width="100%" 
        style="border-collapse: collapse; font-size:10pt; background-color:#e7eaf1; border-color:#588fc7;" 
        bordercolor="#588fc7">
       <tr>
        <td style =" width:20%;" align = "right" >
                <span lang="zh-cn">旧密码:</span>
        </td>
        <td bgcolor="white"style =" width:80%;"  >
                <asp:TextBox ID="txt_oldpass" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txt_oldpass" Display="Dynamic" ErrorMessage="*" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidator1" runat="server" 
                    ControlToValidate="txt_oldpass" Display="Dynamic" ErrorMessage="旧密码不正确！" 
                    ForeColor="Red" onservervalidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
           </td>
    </tr>
       <tr>
        <td style =" width:20%;" align = "right" >
                <span lang="zh-cn">新密码:</span>
        </td>
        <td bgcolor="white"style =" width:80%;"  >
                <asp:TextBox ID="txt_newpass1" runat="server" onKeyUp=pwStrength(this.value) 
                    onBlur=pwStrength(this.value) TextMode="Password" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txt_newpass1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidator2" runat="server" 
                    ControlToValidate="txt_newpass1" Display="Dynamic" ErrorMessage="密码位数不能少于6位！" 
                    ForeColor="Red" onservervalidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
           </td>
    </tr>        
       <tr>
        <td style =" width:20%;" align = "right" >
                 <span lang="zh-cn">确认密码:</span>
                 </td>
        <td bgcolor="white"style =" width:80%;"  >
                <asp:TextBox ID="txt_newpass2" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txt_newpass2" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txt_newpass1" ControlToValidate="txt_newpass2" 
                    Display="Dynamic" ErrorMessage="两次密码输入不一致！" ForeColor="Red"></asp:CompareValidator>
           </td>        
    </tr>
       
       <tr>
        <td style =" width:20%;" align = "right" >
                  <span lang="zh-cn">密码强度:</span>
                 </td>
        <td bgcolor="white"style =" width:80%;"  >
           
            <table cellpadding="1" cellspacing="0" border="1" width="100%" 
               style="border-collapse: collapse;   width: 200px; background-color:#e0f0ff; border-color:#588fc7;" 
                bordercolor="#588fc7">
            <tr>   
                <td id="strength_L" style="width: 100px; height: 19px;" align="center" valign = "bottom" >   
                    弱</td>   
                <td id="strength_M" style="width: 100px; height: 19px;" align="center" valign = "bottom"  >   
                    中</td>   
                <td id="strength_H" style="width: 100px; height: 19px;" align="center" valign = "bottom" >   
                    强</td>   
            </tr>   
        </table>   
               
         </td>
    </tr>

    <tr>
        <td align = "center" colspan="2" >
                 
            <asp:Button ID="btn_save" runat="server" Text="确认修改" onclick="btn_save_Click" />
            <asp:Button ID="btn_cancel" runat="server" Text="取消" Width="69px" 
                onclick="btn_cancel_Click" ValidationGroup="1" />
                 
        </td>
    </tr>
     
    </table> 
    </div>