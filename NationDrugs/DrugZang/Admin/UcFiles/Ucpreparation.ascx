<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ucpreparation.ascx.cs" Inherits="NationDrugs.DrugZang.Admin.UcFiles.Ucpreparation" %>

<%@ Register src="../../Ucshared/RichText.ascx" tagname="RichText" tagprefix="uc1" %><%@ Register src="../../Ucshared/CharText.ascx" tagname="CharText" tagprefix="uc2" %><%@ Register src="../../Ucshared/Ulable.ascx" tagname="Ulable" tagprefix="uc3" %><%@ Register src="../../Ucshared/CharTextRequired.ascx" tagname="CharTextRequired" tagprefix="uc4" %>

<link href="Popwindows.css" rel="stylesheet" type="text/css" />

<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>

   <div class="popupWindow1" style="left: 7px; top: 36px">
      <table cellpadding="4" cellspacing="0" border="1" width="100%" 
                    style=" margin:0px; padding:0px;  border-collapse: collapse; font-size:14pt; background-color:#e7eaf1; border-color:#588fc7; " 
                     bordercolor="#588fc7">
        <tr>
           <td style =" width:15%;" align ="center" colspan = "2" bgcolor="#588fc7">
                <span lang="zh-cn" style=" color:white;"><strong>第一步：护照信息==>制剂信息</strong> </span>
        </td>
          </tr>
           <tr>
               <td style=" text-align:center;">
                   <span lang="zh-cn">民族文字名称</span></td>
               <td bgcolor="white" style=" text-align:left;">
                   <uc3:Ulable ID="Ulable1" runat="server" />
               </td>
          </tr>
           <tr>
               <td style=" text-align:center;">
                   <span lang="zh-cn">制剂名称</span>
               </td>
               <td bgcolor="white" style=" text-align:left;">
                   <uc4:CharTextRequired ID="CharTextRequired1" runat="server" />
               </td>
          </tr>
           <tr>
                    <td style =" width:15%;" align = "center" >
                          制剂内容 
                    </td>
                    <td  style =" width:85%;">
                           <uc1:RichText ID="RichText1" runat="server" />
                    </td>       
  
             </tr>
             <tr>
                <td colspan = "2" style = " text-align :center;">
                  
                  <div>
 <asp:Repeater ID="Rpter_person" runat="server" 
        onitemcommand="Rpter_person_ItemCommand" >
                <HeaderTemplate >
               <table cellpadding="4" cellspacing="0" border="1" width="100%" 
                    style=" margin:0px; padding:0px;  border-collapse: collapse; font-size:14pt; background-color:#e7eaf1; border-color:#588fc7; " 
                     bordercolor="#588fc7">
                      <tr>
                   <td style =" text-align:center;" >
                   <span lang="zh-cn">制剂名称</span>
                   </td>
                  <td style =" text-align:center;" >
                      <span lang="zh-cn">制剂详细内容</span>
                   </td>
                   <td style =" text-align:center;" >
                      <span lang="zh-cn">删除操作</span>
                   </td>
                </tr>
                </HeaderTemplate>
               
                 <ItemTemplate>
                   <tr onmouseover="currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6dbcfd',this.style.fontWeight='';"
                       onmouseout="this.style.backgroundColor=currentcolor,this.style.fontWeight='';">
                    <td style =" width:40%;" align = "center" bgcolor="white">
                            <asp:Label ID ="lbl_ppid" runat = "server" Text='<%# Eval("ppid") %>'  Visible = "false" ></asp:Label>
                            <asp:Label ID="Label1" runat="server" Text = '<%# Eval("pName") %>' ></asp:Label>
                    </td>
                    <td bgcolor="white" style =" width:40%;" align = "center">
                        <asp:LinkButton ID="detailLinkButton" runat="server"  CommandName="detail" CommandArgument='<%# Eval("ppid") %>' ValidationGroup = "0">制剂详细信息</asp:LinkButton> 
                        
                    </td>
                    <td style =" text-align:center; width:20%" bgcolor="white" >
                         <asp:LinkButton ID="delLinkButton" runat="server" OnClientClick='return confirm("确定删除该条制剂？")' CommandName="del" CommandArgument='<%# Eval("ppid") %>' ValidationGroup = "0">删除制剂</asp:LinkButton> 
                   </td>       
  
                </tr>
                 </ItemTemplate>
                <FooterTemplate>
                 </table>
                </FooterTemplate>
                </asp:Repeater>

</div>
                  </td>
             
             </tr>
            
          <tr>
              <td colspan="2" style=" text-align :center;">
                  <asp:Button  CssClass ="btnHima" ID="btn_add" runat="server" onclick="btn_add_Click" Text="添加新记录" 
                      ValidationGroup="0" />
                  <asp:Button  CssClass ="btnHima" ID="bnt_savePreparation" runat="server" 
                      onclick="bnt_savePreparation_Click" Text="保存信息" Width="87px" />
                  <asp:Button  CssClass ="btnHima" ID="btn_back1" runat="server" onclick="btn_back1_Click" 
                      Text="&lt;&lt;上一步" ValidationGroup="0" />
                  <asp:Button  CssClass ="btnHima" ID="bnt_cancal" runat="server" onclick="bnt_cancal_Click" 
                      Text="下一步&gt;&gt;" ValidationGroup="0" Width="93px" />
              </td>
          </tr>
            
        </table>
</div>


</ContentTemplate>
</asp:UpdatePanel>


   
<asp:HiddenField ID="hid_drugid" runat="server" Visible="False" /> 
<asp:HiddenField ID="hid_keyid" runat="server" Visible="False" />



 



   
