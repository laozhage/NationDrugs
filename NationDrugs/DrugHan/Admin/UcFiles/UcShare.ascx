<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcShare.ascx.cs" Inherits="NationDrugs.DrugHan.Admin.UcFiles.UcShare" %>
   <%@ Register src="../../Ucshared/Ulable.ascx" tagname="Ulable" tagprefix="uc1" %>
   <%@ Register src="../../Ucshared/CharText.ascx" tagname="CharText" tagprefix="uc2" %>
   <table cellpadding="4" cellspacing="0" border="1" width="100%" 
        style="border-collapse: collapse; font-size:10pt; background-color:#e7eaf1; border-color:#588fc7;" 
        bordercolor="#588fc7">
        <tr>
        <td colspan = "3" align = "center" bgcolor="#588fc7">
        <span lang = "zh-cn" style=" color:white;"><strong>第七步：共享利用信息</strong>  </span>
        </td>                    
            </tr>                     
             
    <tr>
        <td style =" width:20%;" align = "right" >
               民族文字名称</td>
        <td bgcolor="white" style =" width:80%;" colspan="2">
                <uc1:Ulable ID="Ulable1" runat="server" />
        </td>               
  
    </tr>
             
    <tr>
        <td style =" width:20%;" align = "right" >
               共享利用方式（72）</td>
        <td bgcolor="white" style =" width:80%;" colspan="2">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="3" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">1.公益性共享</asp:ListItem>
                    <asp:ListItem Value="2">2.公益性借用共享</asp:ListItem>
                    <asp:ListItem Value="3">3.合作研究共享</asp:ListItem>
                    <asp:ListItem Value="4">4.知识产权性交易共享</asp:ListItem>
                    <asp:ListItem Value="5">5.资源纯交易性共享</asp:ListItem>
                    <asp:ListItem Value="6">6.资源租赁性共享</asp:ListItem>
                    <asp:ListItem Value="7">7.资源交换性共享</asp:ListItem>
                    <asp:ListItem Value="8">8.收藏地共享</asp:ListItem>
                    <asp:ListItem Value="9">9.行政许可性共享</asp:ListItem>
                </asp:CheckBoxList>
              
        </td>               
  
    </tr>
                
  
   

    <tr>
        <td style =" width:20%;" align = "right" >
               获取途径（73）</td>
        <td bgcolor="white" style =" width:80%;" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                    <table>
                        <tr>
                            <td>
                               <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                            RepeatDirection="Horizontal" 
                                    onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                            <asp:ListItem Value="1">邮件</asp:ListItem>
                            <asp:ListItem Value="2">现场获取</asp:ListItem>
                            <asp:ListItem Value="3">网上订购</asp:ListItem>
                            <asp:ListItem Value="4">其他</asp:ListItem>
                            </asp:RadioButtonList></td>
                            <td>
                                 
                        <asp:TextBox ID="txt_73" runat="server" Enabled="False"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="*" ForeColor="Red" ControlToValidate="RadioButtonList1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
        </td>               
  
    </tr>
     <tr>
        <td style =" width:20%;" align = "right" rowspan="5" >
               联系方式（74）</td>
        <td  style =" width:15%; padding:0; margin:0; " align = "right">
            联系人：
             
              </td>               
  
        <td bgcolor="white" style =" width:65%; padding:0; margin:0; ">
              
             
              <asp:TextBox ID="TextBox1" runat="server" Width="80%"  BackColor = "AliceBlue"></asp:TextBox>
              
             
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                  ControlToValidate="TextBox1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
              
             
              </td>               
  
    </tr>            
  
     <tr>
        <td  style =" width:15%; padding:0; margin:0; " align = "right">
              
             
             联系单位：</td>               
  
        <td bgcolor="white" style =" width:65%; padding:0; margin:0; ">
              
             
              <asp:TextBox ID="TextBox2" runat="server" Width="80%"  BackColor = "AliceBlue"></asp:TextBox>
         </td>               
  
    </tr>            
  
     <tr>
        <td  style =" width:15%; padding:0; margin:0; " align = "right">
              
             
              邮编：</td>               
  
        <td bgcolor="white" style =" width:65%; padding:0; margin:0; ">
              
             
              <asp:TextBox ID="TextBox3" runat="server" Width="80%"  BackColor = "AliceBlue"></asp:TextBox>
         </td>               
  
    </tr>            
  
     <tr>
        <td  style =" width:15%; padding:0; margin:0; " align = "right">
              
             
              电话：</td>               
  
        <td bgcolor="white" style =" width:65%; padding:0; margin:0; ">
              
             
              <asp:TextBox ID="TextBox4" runat="server" Width="80%"  BackColor = "AliceBlue"></asp:TextBox>
         </td>               
  
    </tr>            
  
     <tr>
        <td  style =" width:15%; padding:0; margin:0; " align = "right">
              
             
              E-mail：</td>               
  
        <td bgcolor="white" style =" width:65%; padding:0; margin:0; ">
              
             
              <asp:TextBox ID="TextBox5" runat="server" Width="80%"  BackColor = "AliceBlue"></asp:TextBox>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                  ErrorMessage="邮件格式不对！" ControlToValidate="TextBox5" ForeColor="Red" 
                  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
         </td>               
  
    </tr>   
    
    
    
    
             
  
     <tr>
        <td align = "center" colspan="3" >
               <asp:Button ID="btn_save" runat="server" Text="保存信息" onclick="btn_save_Click" />
               <asp:Button ID="btn_back9" runat="server" Text="&lt;&lt;上一步" 
                   onclick="btn_back9_Click" />
               <asp:Button ID="btn_next9" runat="server" Text="  完成  " 
                   onclick="btn_next9_Click" />
         </td>
  
    </tr>            
  
    </table>


<asp:HiddenField ID="hid_drugid" runat="server" Visible="False" />


<asp:HiddenField ID="hid_shareid" runat="server" Visible="False"  />



