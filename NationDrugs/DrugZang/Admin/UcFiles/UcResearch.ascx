<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcResearch.ascx.cs" Inherits="NationDrugs.DrugZang.Admin.UcFiles.UcResearch" %>


<%@ Register src="../../../DrugZang/Ucshared/CharText.ascx" tagname="CharText" tagprefix="uc1" %>
<%@ Register src="Ucpreparation.ascx" tagname="Ucpreparation" tagprefix="uc2" %>  
<%@ Register src="../../../DrugZang/Ucshared/RichText.ascx" tagname="RichText" tagprefix="uc3" %>  
<%@ Register src="../../../DrugZang/Ucshared/Ulable.ascx" tagname="Ulable" tagprefix="uc4" %>
<link href="Popwindows.css" rel="stylesheet" type="text/css" />
   
   <table cellpadding="4" cellspacing="0" border="1" width="100%" 
        style="border-collapse: collapse; font-size:10pt; background-color:#e7eaf1; border-color:#588fc7;" 
        bordercolor="#588fc7">
        <tr>
        <td colspan = "2" align = "center" bgcolor="#588fc7">
        <span lang = "zh-cn" style=" color:white;"><strong>第三步：资源研究成果描述信息（文化属性）</strong>  </span>
        </td>                    
            </tr>                     
             
    <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">民族文字名称(1)</span></td>
        <td bgcolor="white">
                <uc4:Ulable ID="Ulable1" runat="server" />
        </td>
  
    </tr>
    <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">药理药效(21)</span>
        </td>
        <td bgcolor="white" style =" width:75%;"  >
                <uc3:RichText ID="RichText21" runat="server" Hight="80px" />
        </td>                
  
    </tr>
        <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">临床研究(22)</span>
        </td>
        <td bgcolor="white" style =" width:75%;"  >
                <uc3:RichText ID="RichText22" runat="server" Hight="80px" />
            </td>                
  
    </tr>
        <tr>
        <td style =" width:15%;" align = "right" >
                 <span lang="zh-cn">化学成分(23)</span></td>
        <td bgcolor="white" style =" width:75%;"  >
                <span lang="zh-cn" style="color:Red;">
                提示：为保证录入信息的准确性，&lt;化学成分&gt;将在保存完【文化属性】之后录入</span></td>                
  
    </tr> 
                 
                 
                     
        <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">栽培及组培(24)</span>
        </td>
        <td bgcolor="white" style =" width:75%;"  >
                <uc3:RichText ID="RichText24" runat="server" Hight="80px" />
            </td>                
  
    </tr> 
                 
                 
                     
        <tr>
        <td style =" width:15%;" align = "right" >
                 <span lang="zh-cn">采收、加工、炮制及工艺研究(25)</span></td>
        <td bgcolor="white" style =" width:75%;"  >
                <uc3:RichText ID="RichText25" runat="server" Hight="80px" />
            </td>                
  
    </tr> 
                 
                 
                     
        <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">资源分布(26)</span></td>
        <td bgcolor="white" style =" width:75%;"  >
                <uc3:RichText ID="RichText26" runat="server" Hight="80px" />
            </td>                
  
    </tr> 
         <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">综述(27)</span></td>
        <td bgcolor="white" style =" width:75%;"  >
                <uc3:RichText ID="RichText27" runat="server" Hight="80px" />
             </td>                
  
    </tr> 
         <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">保护与利用(28)</span></td>
        <td bgcolor="white" style =" width:75%;"  >
                <uc3:RichText ID="RichText28" runat="server" Hight="80px" />
             </td>                
  
    </tr> 
          <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">商品规格与流通(29)</span></td>
        <td bgcolor="white" style =" width:75%;"  >
                <uc3:RichText ID="RichText29" runat="server" Hight="80px" />
              </td>                
  
    </tr> 
        <tr>
        <td style =" width:15%;" align = "right" >
                 <span lang="zh-cn">生成与需求(30)</span></td>
        <td bgcolor="white" style =" width:75%;"  >
                <uc3:RichText ID="RichText30" runat="server" Hight="80px" />
            </td>                
  
    </tr> 
        
    </tr> 
        <tr>
        <td style =" width:15%;" align = "right" >
                 <span lang="zh-cn">知识产权(31)</span></td>
        <td bgcolor="white" style =" width:75%;"  >
                <span lang="zh-cn" style="color:Red;">
                提示：为保证录入信息的准确性，&lt;知识产权&gt;将在保存完【文化属性之后】之后录入</span></td>                
  
    </tr>                    
                 
                     
        <tr>
        <td align = "center" colspan="2" >
                <asp:Button ID="btn_save" runat="server" Text="保存信息" Width="92px" onclick="btn_save_Click" 
                    />
                <asp:Button ID="btn_back3" runat="server" 
                    Text="&lt;&lt;上一步" onclick="btn_back3_Click" />
                <asp:Button ID="btn_next4" runat="server" Text="下一步&gt;&gt;" Width="96px" onclick="btn_next4_Click"
                    />
            </td>
  
    </tr>
                 
                 
                     
    </table>

<asp:HiddenField ID="hid_drugid" runat="server" Visible="False" />


<asp:HiddenField ID="hid_rsid" runat="server" />



