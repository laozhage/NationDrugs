<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCharacter.ascx.cs" Inherits="NationDrugs.DrugWei.Admin.UcFiles.ucCharacter" %>

<%@ Register src="../../Ucshared/CharText.ascx" tagname="CharText" tagprefix="uc1" %>
<%@ Register src="Ucpreparation.ascx" tagname="Ucpreparation" tagprefix="uc2" %>
  
<%@ Register src="../../Ucshared/RichText.ascx" tagname="RichText" tagprefix="uc3" %>
  
<%@ Register src="../../Ucshared/Ulable.ascx" tagname="Ulable" tagprefix="uc4" %>
  
   <table cellpadding="4" cellspacing="0" border="1" width="100%" 
        style="border-collapse: collapse; font-size:10pt; background-color:#e7eaf1; border-color:#588fc7;" 
        bordercolor="#588fc7">
        <tr>
        <td colspan = "4" align = "center" bgcolor="#588fc7">
        <span lang = "zh-cn" style=" color:white;"><strong>第二步：资源特征特性描述信息（物质属性）</strong>  </span>
        </td>                    
            </tr>                     
             
    <tr>
        <td style =" width:15%;" align = "right" >
               民族文字名称</td>
        <td bgcolor="white" style =" width:25%;">
                <uc4:Ulable ID="Ulable1" runat="server" />
        </td>
        <td style =" width:30%;"  align = "right" >
                原植物(动物、矿物)中文名(14)</td>
        <td bgcolor="white" style =" width:30%;">
                <uc1:CharText ID="CharText14" runat="server" />
        </td>           
  
    </tr>
             
    <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">拉丁学名(15)</span></td>
        <td bgcolor="white" colspan="3">
                <uc1:CharText ID="CharText15" runat="server" />
        </td>
  
    </tr>
    <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">属名(16)</span>
        </td>
        <td bgcolor="white" style =" width:25%;">
                <uc1:CharText ID="CharText16" runat="server" />
        </td>
        <td style =" width:30%;"  align = "right" >
                <span lang="zh-cn">科名(17)</span>
        </td>
        <td bgcolor="white" style =" width:30%;">
                <uc1:CharText ID="CharText17" runat="server" />
        </td>           
  
    </tr>
    <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">描述信息(18)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                <uc3:RichText ID="RichText18" runat="server" />
        </td>                
  
    </tr>
        <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">分布及生境(19)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                <uc3:RichText ID="RichText19" runat="server" Hight="80px" />
            </td>                
  
    </tr>
        <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">产地(20)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                <uc3:RichText ID="RichText20" runat="server" Hight="80px" />
            </td>                
  
    </tr> 
                 
                 
                     
        <tr>
        <td align = "center" colspan="4" >
                <asp:Button ID="btn_save" runat="server" Text="保存信息" Width="92px" onclick="btn_save_Click" 
                    />
                <asp:Button ID="btn_back2" runat="server" onclick="btn_back2_Click" 
                    Text="&lt;&lt;上一步" />
                <asp:Button ID="btn_next" runat="server" Text="下一步&gt;&gt;" Width="96px" onclick="btn_next_Click" 
                    />
            </td>
  
    </tr>
                 
                 
                     
    </table>

<asp:HiddenField ID="hid_drugid" runat="server" Visible="False" />


<asp:HiddenField ID="hid_ccid" runat="server" />



