<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcReference.ascx.cs" Inherits="NationDrugs.DrugZang.Admin.UcFiles.UcReference" %>
<%@ Register src="../../Ucshared/CharTextRequired.ascx" tagname="CharTextRequired" tagprefix="uc3" %><%@ Register src="../../Ucshared/CharText.ascx" tagname="CharText" tagprefix="uc1" %><%@ Register src="../../Ucshared/Ulable.ascx" tagname="Ulable" tagprefix="uc2" %><%@ Register src="../../Ucshared/RichText.ascx" tagname="RichText" tagprefix="uc4" %>

<link href="Popwindows.css" rel="stylesheet" type="text/css" />
   
   <table cellpadding="4" cellspacing="0" border="1" width="100%" 
        style="border-collapse: collapse; font-size:10pt; background-color:#e7eaf1; border-color:#588fc7;" 
        bordercolor="#588fc7">
        <tr>
        <td colspan = "4" align = "center" bgcolor="#588fc7">
        <span lang = "zh-cn" style=" color:white;"><strong>第四步：文献来源信息</strong>  </span>
        </td>                    
            </tr>                     
             
    <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">民族文字名称</span>
        </td>
        <td bgcolor="white" style =" width:25%;">


            <uc2:Ulable ID="Ulable1" runat="server" />
        </td>
        <td  align = "right" colspan="2" >
                &nbsp;</td>
  
    </tr>

     <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">论文题目(32)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                <uc3:CharTextRequired ID="CharText1" runat="server" Width="95%" />
         </td>                
  
    </tr>

     <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">文献来源(33)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                <uc1:CharText ID="CharText2" runat="server" />
         </td>                
  
    </tr>
     <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">作者(34)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                <uc1:CharText ID="CharText3" runat="server" />
         </td>                
  
    </tr>
     <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">作者所在单位(35)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                <uc4:RichText ID="CharText4" runat="server" Hight="80px" />
         </td>                
  
    </tr>

    <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">第一作者省份(36)</span>
        </td>
        <td bgcolor="white" style =" width:25%;">
                <uc1:CharText ID="CharText5" runat="server" />
        </td>
        <td style =" width:30%;"  align = "right" >
                <span lang="zh-cn">年份(37)</span>
        </td>
        <td bgcolor="white" style =" width:30%;">
                <uc1:CharText ID="CharText6" runat="server" />
        </td>           
  
    </tr>
    <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">卷、期(38)</span>
        </td>
        <td bgcolor="white" style =" width:25%;">
                <uc1:CharText ID="CharText7" runat="server" />
        </td>
        <td style =" width:30%;"  align = "right" >
                <span lang="zh-cn">页码(39)</span>
        </td>
        <td bgcolor="white" style =" width:30%;">
                <uc1:CharText ID="CharText8" runat="server" />
        </td>           
  
    </tr>
        <tr>
         <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">摘要(40)</span>
        </td>
        
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                <uc4:RichText ID="CharText9" runat="server" />
            </td>                
  
    </tr>
                 
                 
                     
        <tr>
        <td align = "center" colspan="4" >
                  <asp:GridView ID="gv" runat="server" AllowPaging="True"  AutoGenerateColumns="False"
                   Font-Size="14pt"  Font-Bold = "True"  RowStyle-Height = "11pt"
                    onrowdatabound="gv_RowDataBound" Width="100%" 
                    onpageindexchanging="gv_PageIndexChanging" 
                          onrowcreated="gv_RowCreated" onrowcommand="gv_RowCommand" PageSize="5">
                    <HeaderStyle  BackColor="#588fc7" ForeColor = "White" />            
                   <RowStyle Height="11pt" BackColor = "White" ></RowStyle>
             
             <Columns>
                            
                <asp:BoundField DataField="title"  HeaderText="论文题目"  >  
                 <HeaderStyle Width="16%" />
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>  
                  
                <asp:BoundField DataField="magazine"  HeaderText="文献来源">  
                 <HeaderStyle Width="14%" />
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>   
              
                 <asp:BoundField DataField="author"  HeaderText="作者">  
                 <HeaderStyle Width="14%" />
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>   

                  <asp:BoundField DataField="province" HeaderText="第一作者省份">  
                 <HeaderStyle Width="12%" />
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>  
                 <asp:BoundField DataField="year" HeaderText="年份">  
                 <HeaderStyle Width="8%" />
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>  
                 <asp:BoundField DataField="vol" HeaderText="卷、期">  
                 <HeaderStyle Width="8%" />
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>  
                 <asp:BoundField DataField="page" HeaderText="页码" >  
                 <HeaderStyle Width="8%" />
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>  
                


                 <asp:TemplateField HeaderText="详细信息" >
                <ItemTemplate>                
                   <asp:LinkButton ID="delLinkDetail" runat="server"  CommandName="detail" CommandArgument='<%# Eval("rfeid") %>' ValidationGroup = "0">详细信息</asp:LinkButton> 
                  </ItemTemplate>
                     <HeaderStyle Width="10%" />
                     <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>      

                <asp:TemplateField HeaderText="删除操作" >
                <ItemTemplate>                
                   <asp:LinkButton ID="delLinkButton" runat="server" OnClientClick='return confirm("确定删除该条记录？")' CommandName="del" CommandArgument='<%# Eval("rfeid") %>' ValidationGroup = "0">删除记录</asp:LinkButton> 
                  </ItemTemplate>
                    <HeaderStyle Width="10%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>                 
             
             
             </Columns>
</asp:GridView>
               </td>
  
    </tr>
                 
                 
                     
        <tr>
        <td align = "center" colspan="4" >
                <asp:Button ID="btn_newRe" runat="server" Text="添加新记录" Width="96px" onclick="btn_newRe_Click" 
                    />
                <asp:Button ID="btn_save" runat="server" Text="保存信息" Width="92px" onclick="btn_save_Click" 
                   />
                <asp:Button ID="btn_back6" runat="server" Text="&lt;&lt;上一步" Width="96px" 
                    onclick="btn_back6_Click" ValidationGroup="1" 
                     />
                <asp:Button ID="btn_next6" runat="server" Text="下一步&gt;&gt;" Width="96px" 
                    onclick="btn_next6_Click" ValidationGroup="1" 
                     />
            </td>
  
    </tr>
                 
                 
                     
    </table>


<asp:HiddenField ID="hid_drugid" runat="server" Visible="False" />
<asp:HiddenField ID="hid_refid" runat="server" Visible="False"  />




