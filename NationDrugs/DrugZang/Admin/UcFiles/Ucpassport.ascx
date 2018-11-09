<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ucpassport.ascx.cs" Inherits="NationDrugs.DrugZang.Admin.UcFiles.Ucpassport" %>
<%@ Register src="../../Ucshared/CharText.ascx" tagname="CharText" tagprefix="uc1" %>
<%@ Register src="Ucpreparation.ascx" tagname="Ucpreparation" tagprefix="uc2" %>

<%@ Register src="../../Ucshared/CharTextRequired.ascx" tagname="CharTextRequired" tagprefix="uc3" %>

<link href="Popwindows.css" rel="stylesheet" type="text/css" />
   
   <table cellpadding="4" cellspacing="0" border="1" width="100%" 
        style="border-collapse: collapse; font-size:14pt;  font-family:Microsoft Himalaya; background-color:#ebf7ff; border-color:#588fc7;" 
        bordercolor="#588fc7">
        <tr>
        <td colspan = "4" align = "center" bgcolor="#588fc7">
        <span lang = "zh-cn" style=" color:white;"><strong>གོམ་པ་དང་པོ། སྨན་གྱི་རྩ་བའི་ཆ་འཕྲིན།</strong>  </span>
        </td>                    
            </tr>                     
             
    <tr>
        <td style =" width:20%;" align = "right" >
                <span lang="zh-cn">མི་རིགས་ཡི་གེའི་མིང་།(1)</span>
        </td>
        <td bgcolor="white" style =" width:25%;">


<uc3:CharTextRequired ID="CharText1" runat="server" Width="90%"  />



        </td>
        <td style =" width:20%;"  align = "right" >
                <span lang="zh-cn">མི་རིགས་ཡི་གེའི་མིང་གི་རྒྱ་ཡིག་སྒྲ་སྦྱོར(2)</span>
        </td>
        <td bgcolor="white" style =" width:30%;">
                <uc1:CharText ID="CharText2" runat="server" />
        </td>           
  
    </tr>
    <tr>
        <td style =" width:20%;" align = "right" >
                <span lang="zh-cn">རྒྱ་ཡིག་མིང་།(3)</span>
        </td>
        <td bgcolor="white" style =" width:25%;">
                <uc1:CharText ID="CharText3" runat="server" />
        </td>
        <td style =" width:20%;"  align = "right" >
                <span lang="zh-cn">སྨན་ལ་གཏོང་རྒྱུའི་ཆ།(4)</span>
        </td>
        <td bgcolor="white" style =" width:30%;">
                <uc1:CharText ID="CharText4" runat="server" />
        </td>           
  
    </tr>
    <tr>
        <td style =" width:20%;" align = "right" >
                <span lang="zh-cn">སྨན་ནུས(5)</span>
        </td>
        <td bgcolor="white" style =" width:25%;">
                <uc1:CharText ID="CharText5" runat="server" />
        </td>
        <td style =" width:20%;"  align = "right" >
                <span lang="zh-cn">ཕན་ནུས།(6)</span>
        </td>
        <td bgcolor="white" style =" width:30%;">
                <uc1:CharText ID="CharText6" runat="server" />
        </td>           
  
    </tr>
    <tr>
        <td style =" width:20%;" align = "right" >
                <span lang="zh-cn">གཙོ་བཅོས།(7)</span>
        </td>
        <td bgcolor="white" style =" width:80%;" colspan = "3"  >
                <uc1:CharText ID="CharText7" runat="server" />
        </td>                
  
    </tr>
        <tr>
        <td style =" width:20%;" align = "right" >
                <span lang="zh-cn">གཏོང་ཐབས་དང་གཏོང་ཚད།(8)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                <uc1:CharText ID="CharText8" runat="server" />
            </td>                
  
    </tr>
        <tr>
        <td style =" width:20%;" align = "right" >
                <span lang="zh-cn">དོ་སྣང་བྱེད་དགོས་པ།(9)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                <uc1:CharText ID="CharText9" runat="server" />
            </td>                
  
    </tr> 
        <tr>
        <td style =" width:20%;" align = "right" >
                <span lang="zh-cn">སྤུས་ཚད་ཚད་གཞི།(10)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                <uc1:CharText ID="CharText10" runat="server" />
            </td>                
  
    </tr>
        <tr>
        <td style =" width:20%;" align = "right" >
                <span lang="zh-cn">སྨན་སྦྱོར།(11)</span>
        </td>
        <td bgcolor="white" style =" width:75%; text-align:left;" colspan = "3"  >
               
             <span lang="zh-cn" style="color:Red;">དྲན་སྐུལ་ཞུ་རྒྱུར་   འཆར་འཕྲིན་ནང་འཇུག་བྱེད་པའི་སྐབས་ཀྱི་ཚད་ལྡན་རང་བཞིན་འགན་ལེན་ཡོང་ཆེད་འཐུས་ཚང་བཟོས་པའི་འཆར་འཕྲིན་ཉར་ཚགས་བྱས་རྗེས་[ཐེམ་ཐོའི་འཆར་འཕྲིན་]དང་[བྲིས་རྟགས་རྒྱབ་པའི་འཆར་འཕྲིན་]ནང་འཇུག་བྱེད་དགོས་</span></td>                
  
    </tr> 
        <tr>
        <td style =" width:20%;" align = "right" >
                <span lang="zh-cn">ན་གྱི་བཟོ་དབྱིབས།(12)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                <uc1:CharText ID="CharText12" runat="server" />
            </td>                
  
    </tr>
        <tr>
        <td style =" width:15%;" align ="center" colspan = "4" bgcolor="#588fc7">
                <span lang="zh-cn" style=" color:white;"><strong>མཚོན་རྟགས་ཆ་འཕྲིན།</strong> </span>
        </td>
                                
  
    </tr>
        <tr>
        <td style =" width:20%;" align = "right" >
                <span lang="zh-cn">ཐོན་ཁུངས་རིགས་དབྱེའི་ཨང་གྲངས།(13)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                <uc1:CharText ID="CharText13" runat="server" />
            </td>                
  
    </tr>
                 
                 
                     
        <tr>
        <td align = "center" colspan="4" >
                <asp:Button ID="Button1" runat="server" Text="保存信息" Width="96px"  CssClass ="btnHima"
                    onclick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="下一步&gt;&gt;" Width="96px"  CssClass ="btnHima"
                    onclick="Button2_Click" />
            </td>
  
    </tr>
                 
                 
                     
    </table>

<asp:HiddenField ID="hid_drugid" runat="server" Visible="False" />






