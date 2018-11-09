<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcUserNew.ascx.cs" Inherits="NationDrugs.DrugWei.Admin.UcFiles.UcUserNew" %>


<%@ Register src="../../Ucshared/Ulable.ascx" tagname="Ulable" tagprefix="uc1" %>
<%@ Register src="../../Ucshared/CharTextRequired.ascx" tagname="CharTextRequired" tagprefix="uc2" %>


<script src="../../../Cjs/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
<link href="../../../Cjs/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" /> 


    <table cellpadding="4" cellspacing="0" border="1" width="100%" 
        style="border-collapse: collapse; font-size:10pt; background-color:#e7eaf1; border-color:#588fc7;" 
        bordercolor="#588fc7">
      <tr>
        <td colspan = "6" align = "center" bgcolor="#588fc7" style=" color:White; font-weight:bold;">
         <asp:Label ID="lbl_titleName"  runat="server" Text="添加新用户"></asp:Label>
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
                <uc2:CharTextRequired ID="txt_tname" runat="server" Width="90%" />
           </td>    
        
          <td style ="width:10%;" align = "right" >
              <span lang="zh-cn">用户组别:</span>
          </td>
          <td bgcolor="white"  style ="width:24%;" align = "left"  >
              <asp:DropDownList ID="DropDownList1" runat="server" Width="80px">
                  <asp:ListItem Value="1" Selected="True">汉语</asp:ListItem>
                  <asp:ListItem Value="2">藏语</asp:ListItem>
                  <asp:ListItem Value="3">维语</asp:ListItem>
                  <asp:ListItem Value="4">蒙语</asp:ListItem>
              </asp:DropDownList>
           </td>
          
  
    </tr>                   
       <tr>
        <td style =" width:10%;" align = "right" >
                 <span lang="zh-cn">用户密码:</span></td>
        <td bgcolor="white"style =" width:23%;"  >
                <asp:TextBox ID="txt_pass" runat="server" TextMode="Password" Width="90%"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txt_pass" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
           </td>
        <td style =" width:10%;"  align = "right" >
                <span lang="zh-cn">创建时间:</span></td>
        <td bgcolor="white" style ="width:23%; ">
                <asp:TextBox ID="txt_stDate" runat="server"  CssClass="Wdate"  Width= "98%"
                    oninit="txt_stDate_Init" ></asp:TextBox>
           </td>    
        
          <td style ="width:10%;" align = "right" >
               <span lang="zh-cn">截止时间:</span></td>
          <td bgcolor="white"  style ="width:24%;" align = "left"  >
              <asp:TextBox ID="txt_endDate" runat="server"  CssClass="Wdate"  Width = "98%"
                  oninit="txt_endDate_Init" ></asp:TextBox>
           </td>
          
  
    </tr>                   
       <tr>
        <td style =" width:10%;" align = "right" >
               <span lang="zh-cn">是否有效:</span></td>
        <td bgcolor="white"style =" width:23%;"  >
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="1">有效</asp:ListItem>
                    <asp:ListItem Value="0">无效</asp:ListItem>
                </asp:RadioButtonList>
           </td>
        <td style =" width:10%;"  align = "right" >
                是否删除:</td>
        <td bgcolor="white" colspan="3">
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="1">未删除</asp:ListItem>
                    <asp:ListItem Value="0">已删除</asp:ListItem>
                </asp:RadioButtonList>
           </td>    
        
  
    </tr>                   
       <tr>
        <td style =" width:10%;" align = "right" >
               用户权限:</td>
        <td bgcolor="white" colspan="10"  >
                <asp:CheckBoxList ID="check_right" runat="server" DataSourceID="SqlDataS_right" 
                    DataTextField="ParentMenuName" DataValueField="ParentMenuValue" 
                    RepeatDirection="Horizontal">
                </asp:CheckBoxList>
                <asp:SqlDataSource ID="SqlDataS_right" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:MinZuYaoConnectionString %>" 
                    
                    SelectCommand="SELECT * FROM [LeftParentMenu] WHERE ([ParentMenuID] = @ParentMenuID)">
                    <SelectParameters>
                        <asp:SessionParameter Name="ParentMenuID" SessionField="SelectGroupid" 
                            Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
           </td>
        
  
    </tr>                   
       <tr>
        <td align = "center" colspan="6" >
               <asp:Button ID="btn_new" runat="server" Text="添加新用户" onclick="btn_new_Click" 
                   ValidationGroup="1" />
               <asp:Button ID="btn_save" runat="server" Text=" 保存信息 " 
                   onclick="btn_save_Click" />
           </td>
          
  
    </tr>                   
    </table> 
       <div style =" margin :0px; padding:0px;">
                  <asp:GridView ID="gv" runat="server" AllowPaging="True"  AutoGenerateColumns="False"
                   Font-Size="10pt"  Font-Bold = "True"  RowStyle-Height = "11pt"
                    onrowdatabound="gv_RowDataBound" Width="100%" 
                    onpageindexchanging="gv_PageIndexChanging" 
                          onrowcreated="gv_RowCreated" onrowcommand="gv_RowCommand">
                    <HeaderStyle  BackColor="#588fc7" ForeColor = "White" />            
                   <RowStyle Height="11pt" BackColor = "White" ></RowStyle>
             
             <Columns>
                            
                <asp:BoundField DataField="userid"  HeaderText="用户ID"  >  
                 <HeaderStyle Width="12.5%" />
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>   
                <asp:BoundField DataField="Groupid"  HeaderText="用户分组">  
                 <HeaderStyle Width="12.5%" />
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>   
                 <asp:BoundField DataField="truename"  HeaderText="真实姓名">  
                 <HeaderStyle Width="12.5%" />
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>   
                 <asp:TemplateField HeaderText="创建时间">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Eval("tcreat", "{0:d}") %>'></asp:Label>
                     </ItemTemplate>
                     <HeaderStyle Width="12.5%" />
                     <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="终止时间">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("tdeadline", "{0:d}") %>'></asp:Label>
                     </ItemTemplate>
                     <HeaderStyle Width="12.5%" />
                     <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="是否有效">
                     <ItemTemplate>
                         <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("bfunc") %>' 
                             Enabled="False" />
                     </ItemTemplate>
                     <HeaderStyle Width="12.5%" />
                     <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="未删除">
                     <ItemTemplate>
                         <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("bdel") %>' 
                             Enabled="False" />
                     </ItemTemplate>
                     <HeaderStyle Width="12.5%" />
                     <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>

                 <asp:TemplateField HeaderText="详细信息" >
                <ItemTemplate>                
                   <asp:LinkButton ID="delLinkDetail" runat="server"  CommandName="detail" CommandArgument='<%# Eval("userid") %>' ValidationGroup = "0">详细信息</asp:LinkButton> 
                  </ItemTemplate>
                     <HeaderStyle Width="12.5%" />
                     <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>      


                              
             
             
             </Columns>
</asp:GridView>
               </div>
<asp:HiddenField ID="hid_userid" runat="server" />
 
