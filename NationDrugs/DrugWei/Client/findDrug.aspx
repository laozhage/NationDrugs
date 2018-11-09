<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="findDrug.aspx.cs" Inherits="NationDrugs.DrugWei.Client.findDrug" %>

<%@ Register src="../Ucshared/CharText.ascx" tagname="CharText" tagprefix="uc1" %>

<%@ Register src="../Ucshared/UcCalendar.ascx" tagname="UcCalendar" tagprefix="uc2" %>

<%@ Register src="../Ucshared/DigitalOnlyTxt.ascx" tagname="DigitalOnlyTxt" tagprefix="uc3" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <div>
       <table cellpadding="4" cellspacing="0" border="1" width="100%" 
        style="border-collapse: collapse; font-size:11pt;  font-family:Microsoft Himalaya; background-color:#ebf7ff; border-color:#588fc7;" 
        bordercolor="#588fc7">
        <tr>
        <td colspan = "2" align = "center" bgcolor="#588fc7">
        <span lang = "zh-cn" style=" color:white;"><strong>数据查询</strong>  </span>
        </td>                    
            </tr>                     
             
    <tr>
        <td style =" width:20%;" align = "right" >
                <span lang="zh-cn">药材名称：</span>
        </td>
        <td bgcolor="white" style =" width:80%;">        
          <table style =" width:100%;">
            <tr>
              <td style =" width:80%;">
               <uc1:CharText ID="txtNationName" runat="server" />       
              </td>
              <td>
               <asp:Button ID="btn_Query" runat="server" onclick="Button1_Click" Text="查询" 
             CssClass="btnHima" Width="107px" />
              </td>

            </tr>
            
          
          </table>
           
 
        </td>
        
    </tr>
             
    </table>
  
      </div>
       <asp:GridView ID="gv" runat="server" AllowPaging="True"  AutoGenerateColumns="False"
                   Font-Size="11pt"    RowStyle-Height = "11pt" Font-Names = "Microsoft Himalaya"
                    onrowdatabound="gv_RowDataBound" Width="100%" 
                    onpageindexchanging="gv_PageIndexChanging" 
                          onrowcreated="gv_RowCreated" onrowcommand="gv_RowCommand">
                    <HeaderStyle  BackColor="#588fc7" ForeColor = "White" />            
                   <RowStyle Height="14pt" BackColor = "White" ></RowStyle>
             
             <Columns>
                   
               <asp:TemplateField HeaderText="ID" >
                <ItemTemplate>                
                   <asp:LinkButton ID="delLinkDetail" runat="server"  CommandName="detail" CommandArgument='<%# Eval("drugid") %>' ValidationGroup = "0"  Text = '<%# Eval("drugid") %>'>详细信息</asp:LinkButton> 
                  </ItemTemplate>
                     <HeaderStyle Width="10%" />
                     <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>  

                <asp:BoundField DataField="nationName"  HeaderText="民族文字名称">  
                 <HeaderStyle Width="10%" />
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>   
               <asp:BoundField DataField="transltName"  HeaderText="音译汉文名称">  
                 <HeaderStyle Width="10%" />
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>   
                <asp:BoundField DataField="name"  HeaderText="汉字名称">  
                 <HeaderStyle Width="10%" />
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField> 
                <asp:BoundField DataField="position"  HeaderText="药用部位">  
                 <HeaderStyle Width="10%" />
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>             
             
             </Columns>
           </asp:GridView>
    </form>
</body>
</html>
