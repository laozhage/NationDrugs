<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ucpassport.ascx.cs" Inherits="NationDrugs.DrugHan.Admin.UcFiles.Ucpassport" %>
<%@ Register src="../../Ucshared/CharText.ascx" tagname="CharText" tagprefix="uc1" %>
<%@ Register src="Ucpreparation.ascx" tagname="Ucpreparation" tagprefix="uc2" %>
  
   <%@ Register src="../../Ucshared/CharTextRequired.ascx" tagname="CharTextRequired" tagprefix="uc3" %>
  
   <table cellpadding="4" cellspacing="0" border="1" width="100%" 
        style="border-collapse: collapse; font-size:10pt; background-color:#ebf7ff; border-color:#588fc7;" 
        bordercolor="#588fc7">
        <tr>
        <td colspan = "4" align = "center" bgcolor="#588fc7">
        <span lang = "zh-cn" style=" color:white;"><strong>第一步：护照信息</strong>  </span>
        </td>                    
            </tr>                     
             
    <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">民族文字名称(1)</span>
        </td>
        <td bgcolor="white" style =" width:25%;">


<uc3:CharTextRequired ID="CharText1" runat="server" Width="90%" />



        </td>
        <td style =" width:30%;"  align = "right" >
                <span lang="zh-cn">民族文字名称音译文名称(2)</span>
        </td>
        <td bgcolor="white" style =" width:30%;">
                <uc1:CharText ID="CharText2" runat="server" />
        </td>           
  
    </tr>
    <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">汉字名称(3)</span>
        </td>
        <td bgcolor="white" style =" width:25%;">
                <uc1:CharText ID="CharText3" runat="server" />
        </td>
        <td style =" width:30%;"  align = "right" >
                <span lang="zh-cn">药用部位(4)</span>
        </td>
        <td bgcolor="white" style =" width:30%;">
                <uc1:CharText ID="CharText4" runat="server" />
        </td>           
  
    </tr>
    <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">药性或归经(5)</span>
        </td>
        <td bgcolor="white" style =" width:25%;">
                <uc1:CharText ID="CharText5" runat="server" />
        </td>
        <td style =" width:30%;"  align = "right" >
                <span lang="zh-cn">功效(6)</span>
        </td>
        <td bgcolor="white" style =" width:30%;">
                <uc1:CharText ID="CharText6" runat="server" />
        </td>           
  
    </tr>
    <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">主治(7)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                <uc1:CharText ID="CharText7" runat="server" />
        </td>                
  
    </tr>
        <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">用法用量(8)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                <uc1:CharText ID="CharText8" runat="server" />
            </td>                
  
    </tr>
        <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">注意事项(9)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                <uc1:CharText ID="CharText9" runat="server" />
            </td>                
  
    </tr> 
        <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">质量标准(10)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                <uc1:CharText ID="CharText10" runat="server" />
            </td>                
  
    </tr>
        <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">制剂(11)</span>
        </td>
        <td bgcolor="white" style =" width:75%; text-align:left;" colspan = "3"  >
               
             <span lang="zh-cn" style="color:Red;">提示：为保证录入信息的准确性，制剂信息将在保存完【护照信息】和【标记信息】之后进行录入</span></td>                
  
    </tr> 
        <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">剂型(12)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                <uc1:CharText ID="CharText12" runat="server" />
            </td>                
  
    </tr>
        <tr>
        <td style =" width:15%;" align ="center" colspan = "4" bgcolor="#588fc7">
                <span lang="zh-cn" style=" color:white;"><strong>  标记信息</strong> </span>
        </td>
                                
  
    </tr>
        <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">资源归类编码(13)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                <uc1:CharText ID="CharText13" runat="server" />
            </td>                
  
    </tr>
                 
                 
                     
        <tr>
        <td align = "center" colspan="4" >
                <asp:Button ID="Button1" runat="server" Text="保存信息" Width="92px" 
                    onclick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="下一步&gt;&gt;" Width="96px" 
                    onclick="Button2_Click" />
            </td>
  
    </tr>
                 
                 
                     
    </table>

<asp:HiddenField ID="hid_drugid" runat="server" Visible="False" />






