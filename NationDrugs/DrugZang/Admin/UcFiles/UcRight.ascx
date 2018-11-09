<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcRight.ascx.cs" Inherits="NationDrugs.DrugZang.Admin.UcFiles.UcRight" %>

<%@ Register src="UcDDRright.ascx" tagname="UcDDRright" tagprefix="uc1" %>
<%@ Register src="../../../DrugZang/Ucshared/CharTextRequired.ascx" tagname="CharTextRequired" tagprefix="uc2" %>
<%@ Register src="../../../DrugZang/Ucshared/Ulable.ascx" tagname="Ulable" tagprefix="uc3" %>
<%@ Register src="../../../DrugZang/Ucshared/RichText.ascx" tagname="RichText" tagprefix="uc4" %>
 
<link href="Popwindows.css" rel="stylesheet" type="text/css" />
  
  
  <table cellpadding="4" cellspacing="0" border="1" width="100%" 
                    style=" margin:0px; padding:0px;  border-collapse: collapse; font-size:10pt; background-color:#e7eaf1; border-color:#588fc7; " 
                     bordercolor="#588fc7">
        <tr>
           <td style =" width:15%;" align ="center" colspan = "4" bgcolor="#588fc7">
                <span lang="zh-cn" style=" color:white;"><strong>第三步：文化属性==>知识产权</strong> </span>
        </td>
          </tr>
           <tr>
               <td style=" text-align:right; width:15%;">
                   <span lang="zh-cn">民族文字名称:</span></td>
               <td bgcolor="white" style=" text-align:left; width:40%" colspan="3">
                   <uc3:Ulable ID="Ulable1" runat="server" />
               </td>
          </tr>
           <tr>
               <td style=" text-align:right; width:15%;">
                     <span lang="zh-cn">知识产权分类:</span></td>
               <td bgcolor="white" style=" text-align:left; width:35%">
                   <uc1:UcDDRright ID="UcDDRright1" runat="server" />
               </td>
               <td  style=" text-align:right; width:15%">
                   &nbsp;知识产权名:</td>
               <td bgcolor="white" style=" text-align:left; width:35%">
                   <uc2:CharTextRequired ID="CharTextRequired1" runat="server" Width="95%" />
               </td>
          </tr>
           <tr>
               <td style=" text-align:right; width:15%;">知识产权内容:</span></td>
               <td bgcolor="white" style=" text-align:left; width:40%" colspan="3">
                   <uc4:RichText ID="RichText1" runat="server" />
               </td>
          </tr>
            
           <tr>
               <td style=" text-align:right; vertical-align:top; " colspan="4" height = "260px" >
               <div style =" margin :0px; padding:0px; text-align:center;">
                  <asp:GridView ID="gv" runat="server" AllowPaging="True"  AutoGenerateColumns="False"
                   Font-Size="14pt"  Font-Bold = "True"  RowStyle-Height = "11pt"
                    onrowdatabound="gv_RowDataBound" Width="100%" 
                    onpageindexchanging="gv_PageIndexChanging" 
                          onrowcreated="gv_RowCreated" onrowcommand="gv_RowCommand" PageSize="8">
                      <FooterStyle HorizontalAlign="Center" />
                    <HeaderStyle  BackColor="#588fc7" ForeColor = "White" />            
                   <RowStyle Height="11pt" BackColor = "White" ></RowStyle>
             
             <Columns>
                            
                <asp:BoundField DataField="rttype"  HeaderText="知识产权分类"  >  
                 <HeaderStyle Width="15%" />
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>  
                  
                <asp:BoundField DataField="rtname"  HeaderText="知识产权名">  
                 <HeaderStyle Width="20%" />
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>   
              
                 <asp:BoundField DataField="rtcontent"  HeaderText="知识产权内容">  
                 <HeaderStyle Width="30%" />
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>   


                 <asp:TemplateField HeaderText="详细信息" >
                <ItemTemplate>                
                   <asp:LinkButton ID="delLinkDetail" runat="server"  CommandName="detail" CommandArgument='<%# Eval("rtid") %>' ValidationGroup = "0">详细信息</asp:LinkButton> 
                  </ItemTemplate>
                     <HeaderStyle Width="100px" />
                     <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>      

                <asp:TemplateField HeaderText="删除操作" >
                <ItemTemplate>                
                   <asp:LinkButton ID="delLinkButton" runat="server" OnClientClick='return confirm("确定删除该条记录？")' CommandName="del" CommandArgument='<%# Eval("rtid") %>' ValidationGroup = "0">删除记录</asp:LinkButton> 
                  </ItemTemplate>
                    <HeaderStyle Width="100px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>                 
             
             
             </Columns>
</asp:GridView>
               </div>
               </td>
          </tr>
            
          <tr>
              <td colspan="4" style=" text-align :center;">
                  <asp:Button ID="btn_addnew" runat="server" onclick="btn_addnew_Click" 
                      Text="添加新记录" />
                  <asp:Button ID="bnt_save" runat="server" 
                       Text="保存信息" Width="87px" onclick="bnt_save_Click" />
                  <asp:Button ID="btn_back5" runat="server" 
                      Text="&lt;&lt;上一步" ValidationGroup="0" onclick="btn_back5_Click" />
                  <asp:Button ID="btn_next5" runat="server" 
                      Text="下一步&gt;&gt;" ValidationGroup="0" Width="93px" onclick="btn_next5_Click" 
                       />
              </td>
          </tr>
            
          <tr>
              <td colspan="4" style=" text-align :center;">
                   &nbsp;</td>
          </tr>
            
          </table>
<asp:HiddenField ID="hid_drugid" runat="server" Visible="False" />
<asp:HiddenField ID="hid_rsid" runat="server" Visible="False" />
<asp:HiddenField ID="hid_rightid" runat="server" />
