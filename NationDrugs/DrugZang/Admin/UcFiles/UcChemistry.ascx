<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcChemistry.ascx.cs" Inherits="NationDrugs.DrugZang.Admin.UcFiles.UcChemistry" %>


<%@ Register src="../../../DrugZang/Ucshared/RichText.ascx" tagname="RichText" tagprefix="uc1" %>
<%@ Register src="../../../DrugZang/Ucshared/CharText.ascx" tagname="CharText" tagprefix="uc2" %>

<%@ Register src="../../../DrugZang/Ucshared/Ulable.ascx" tagname="Ulable" tagprefix="uc3" %>

<%@ Register src="../../../DrugZang/Ucshared/CharTextRequired.ascx" tagname="CharTextRequired" tagprefix="uc4" %>

<%@ Register src="../../../DrugZang/Ucshared/BigImage.ascx" tagname="BigImage" tagprefix="uc5" %>

<link href="Popwindows.css" rel="stylesheet" type="text/css" />
   <div  style="left: 7px; top: 36px">
      <table cellpadding="4" cellspacing="0" border="1" width="100%" 
                    style=" margin:0px; padding:0px;  border-collapse: collapse; font-size:14pt; background-color:#e7eaf1; border-color:#588fc7; " 
                     bordercolor="#588fc7">
        <tr>
           <td style =" width:15%;" align ="center" colspan = "3" bgcolor="#588fc7">
                <span lang="zh-cn" style=" color:white;"><strong>第三步：文化属性==>化学成分</strong> </span>
        </td>
          </tr>
           <tr>
               <td style=" text-align:right; width:15%;">
                   <span lang="zh-cn">民族文字名称:</span></td>
               <td bgcolor="white" style=" text-align:left; width:40%">
                   <uc3:Ulable ID="Ulable1" runat="server" />
               </td>
               <td  style=" text-align:center;">
                   分子结构式预览</td>
          </tr>
           <tr>
               <td style=" text-align:right; width:15%;">
                     <span lang="zh-cn">化学成分名:</span></td>
               <td bgcolor="white" style=" text-align:left; width:40%">
                   <uc4:CharTextRequired ID="CharText1" runat="server" Width="95%" />
               </td>
               <td bgcolor="white" style=" text-align:left;  background-repeat:no-repeat" rowspan="4" >
                          &nbsp;   <uc5:BigImage ID="cmimage" runat="server" Hight="300px" Width = "300px"/>
                    </td>
          </tr>
           <tr>
              <td style=" text-align:right; width:15%;">
                    <span lang="zh-cn">化学成分分子式:</span></td>
               <td bgcolor="white" style=" text-align:left; width:40%">
                   <uc2:CharText ID="CharText2" runat="server" />
               </td>
          </tr>
           <tr>
             <td style=" text-align:right; width:15%;">
                   <span lang="zh-cn">化学成分分子式图:</span></td>

               <td bgcolor="white" style=" text-align:left; width:40%">
                  <asp:FileUpload ID="fupPicPath" runat="server" CssClass ="btnHima"/>
                  <asp:Button ID="btn_upload" runat="server" Text="上传图片" Width="75px" CssClass ="btnHima"
                      onclick="btn_upload_Click" ValidationGroup="0" />
                  <asp:Label ID="lbl_cmpicURL" runat="server" Visible="False"></asp:Label>
               </td>
          </tr>
            
           <tr>
               <td style=" text-align:right; vertical-align:top; " colspan="2" height = "260px">
               <div style =" margin :0px; padding:0px;">
                  <asp:GridView ID="gv" runat="server" AllowPaging="True"  AutoGenerateColumns="False"
                   Font-Size="14pt"  Font-Bold = "True"  RowStyle-Height = "14pt"
                    onrowdatabound="gv_RowDataBound" Width="100%" 
                    onpageindexchanging="gv_PageIndexChanging" 
                          onrowcreated="gv_RowCreated" onrowcommand="gv_RowCommand" PageSize="5" 
                       CellPadding="4" ForeColor="#333333" GridLines="None">
                      <EditRowStyle BackColor="#2461BF" />
                      <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle  BackColor="#507CD1" ForeColor = "White" Font-Bold="True" />            
                      <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                   <RowStyle Height="11pt" BackColor = "#EFF3FB" ></RowStyle>
             
                      <AlternatingRowStyle BackColor="White" />
             
             <Columns>
                            
                <asp:BoundField DataField="cmname"  HeaderText="化学成分名"  >  
                 <HeaderStyle Width="30%" />
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>   
                <asp:BoundField DataField="cmformula"  HeaderText="化学成分分子式">  
                 <HeaderStyle Width="30%" />
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>   
                 <asp:TemplateField HeaderText="化学成分分子式图" Visible = "false" >
                     <EditItemTemplate>                         
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Image ID="Image1" runat="server" Height="60px" 
                             ImageUrl='<%# Eval("cmpic") %>' />
                     </ItemTemplate>
                     <HeaderStyle Width="120px" />
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="详细信息" >
                <ItemTemplate>                
                   <asp:LinkButton ID="delLinkDetail" runat="server"  CommandName="detail" CommandArgument='<%# Eval("cmid") %>' ValidationGroup = "0">详细信息</asp:LinkButton> 
                  </ItemTemplate>
                     <HeaderStyle Width="20%" />
                     <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>      

                <asp:TemplateField HeaderText="删除操作" >
                <ItemTemplate>                
                   <asp:LinkButton ID="delLinkButton" runat="server" OnClientClick='return confirm("确定删除该条记录？")' CommandName="del" CommandArgument='<%# Eval("cmid") %>' ValidationGroup = "0">删除信息</asp:LinkButton> 
                  </ItemTemplate>
                    <HeaderStyle Width="20%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>                 
             
             
             </Columns>
                      <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                      <SortedAscendingCellStyle BackColor="#F5F7FB" />
                      <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                      <SortedDescendingCellStyle BackColor="#E9EBEF" />
                      <SortedDescendingHeaderStyle BackColor="#4870BE" />
</asp:GridView>
               </div>
               </td>
          </tr>
            
          <tr>
              <td colspan="3" style=" text-align :center;" >
                   <asp:Button ID="btn_add" CssClass ="btnHima"  runat="server" Text="添加新记录" onclick="btn_add_Click" 
                       ValidationGroup="0" Width="108px" />
                  <asp:Button ID="bnt_save" runat="server" CssClass ="btnHima"
                      onclick="bnt_save_Click" Text="保存信息" Width="87px" />
                  <asp:Button ID="btn_back4" runat="server" CssClass ="btnHima"
                      Text="&lt;&lt;上一步" ValidationGroup="0" onclick="btn_back4_Click" />
                  <asp:Button ID="btn_next4" runat="server" CssClass ="btnHima"
                      Text="下一步&gt;&gt;" ValidationGroup="0" Width="93px" 
                       onclick="btn_next4_Click" />
              </td>
          </tr>
            

            
          </table>
</div>


   
<asp:HiddenField ID="hid_drugid" runat="server" Visible="False" /> 
<asp:HiddenField ID="hid_rsid" runat="server" Visible="False" />
<asp:HiddenField ID="hid_cmid" runat="server" />




 



   
