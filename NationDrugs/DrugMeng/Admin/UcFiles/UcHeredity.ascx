<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcHeredity.ascx.cs" Inherits="NationDrugs.DrugMeng.Admin.UcFiles.UcHeredity" %>
<%@ Register src="../../Ucshared/CharTextRequired.ascx" tagname="CharTextRequired" tagprefix="uc3" %>
<%@ Register src="../../Ucshared/CharText.ascx" tagname="CharText" tagprefix="uc1" %>  
<%@ Register src="../../Ucshared/Ulable.ascx" tagname="Ulable" tagprefix="uc2" %>
<%@ Register src="../../Ucshared/RichText.ascx" tagname="RichText" tagprefix="uc4" %>
<%@ Register src="../../Ucshared/DigitalOnlyTxt.ascx" tagname="DigitalOnlyTxt" tagprefix="uc6" %>
<%@ Register src="../../Ucshared/UcCalendar.ascx" tagname="UcCalendar" tagprefix="uc5" %>
<%@ Register src="../../Ucshared/FloatDigitalOnlyText.ascx" tagname="FloatDigitalOnlyText" tagprefix="uc7" %>
<%@ Register src="../../Ucshared/latitudeOnlyText.ascx" tagname="latitudeOnlyText" tagprefix="uc8" %>



<script src="../../../Cjs/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
<link href="../../../Cjs/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" /> 

<script src="../../../Cjs/TextValidator/detect.js" type="text/javascript"></script>
<script src="../../../Cjs/TextValidator/eventutil.js" type="text/javascript"></script>
<script src="../../../Cjs/TextValidator/textutil.js" type="text/javascript"></script>
  
   <style type="text/css">
       .style1
       {
           width: 15%;
           height: 22px;
       }
       .style2
       {
           width: 75%;
           height: 22px;
       }

   </style>
  
   <table cellpadding="4" cellspacing="0" border="1" width="100%" 
        style="border-collapse: collapse; font-size:10pt; background-color:#e7eaf1; border-color:#588fc7;" 
        bordercolor="#588fc7">
        <tr>
        <td colspan = "4" align = "center" bgcolor="#588fc7">
        <span lang = "zh-cn" style=" color:white;"><strong>第五步：种质资源信息</strong>  </span>
        </td>                    
            </tr>                     
             
    <tr>
        <td style =" width:20%;" align = "right" >
                <span lang="zh-cn">民族文字名称</span>
        </td>
        <td bgcolor="white" style =" width:25%;">
            <uc2:Ulable ID="Ulable1" runat="server" />
        </td>
        <td  align = "left" colspan="2" >
                <span lang="zh-cn" style="color: #FF0000">友情提示：如果该药材没有种质资源，请【无】直接保存后，进入下一步</span>
                </td>  
    </tr>

     <tr>
        <td style =" width:20%;" align = "right" >
                <span lang="zh-cn">种质资源(41)</span>
        </td>
        <td bgcolor="white" style =" width:70%;" colspan = "3"  >
            <table>
               <tr>
                <td>
                    <asp:RadioButtonList ID="rbtn_41" runat="server" 
                        RepeatDirection="Horizontal" AutoPostBack="True" 
                        onselectedindexchanged="rbtn_41_SelectedIndexChanged">
                        <asp:ListItem Value="1">有</asp:ListItem>
                        <asp:ListItem Value="2">无</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="rbtn_41" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                
                </td>
                </tr>
            </table>
         </td>                
  
    </tr>

     <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">收藏单位(42)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
               
            <uc1:CharText ID="CharText1" runat="server" />
               
         </td>                
  
    </tr>
     <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">资源来源(43)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                <asp:Panel ID="Panel1" runat="server">
                <table>
                  <tr>
                    <td>
                        <asp:RadioButtonList ID="rbtn_43" runat="server" 
                        RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">野生</asp:ListItem>
                            <asp:ListItem Value="2">栽培</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="rbtn_43" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                   </tr>
                 </table>
                </asp:Panel>
         </td>                
  
    </tr>
     <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">种质资源保存形式(44) </span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <table>
                       <tr>
                          <td>
                        <asp:RadioButtonList ID="rbtn_44" runat="server" AutoPostBack="True" 
                   
                    RepeatDirection="Horizontal" onselectedindexchanged="rbtn_44_SelectedIndexChanged">
                            <asp:ListItem Value="1">植物园</asp:ListItem>
                            <asp:ListItem Value="2">种质资源圃</asp:ListItem>
                            <asp:ListItem Value="3">种子库</asp:ListItem>
                            <asp:ListItem Value="4">离体保存</asp:ListItem>
                            <asp:ListItem Value="5">其他</asp:ListItem>
                        </asp:RadioButtonList>
                        </td>
                        <td>
                             <asp:TextBox ID="txt_44" runat="server" Enabled="False"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                 ControlToValidate="rbtn_44" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                     </tr>
                       </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
         </td>                
  
    </tr>

    <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">标本及采集号(45)</span>
        </td>
        <td bgcolor="white" style =" width:25%;">
                <uc1:CharText ID="CharText2" runat="server" />
        </td>
        <td style =" width:30%;"  align = "right" >
                <span lang="zh-cn">采集人(46)</span>
        </td>
        <td bgcolor="white" style =" width:30%;">
                <uc1:CharText ID="CharText3" runat="server" />
        </td>           
  
    </tr>
    <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">采集时间(47)</span>
        </td>
        <td bgcolor="white" style =" width:25%;">
                <asp:TextBox ID="txt_date1" runat="server" BackColor="AliceBlue" Width="98%" 
                    CssClass="Wdate" oninit="txt_date1_Init"></asp:TextBox>
        </td>
        <td style =" width:30%;"  align = "right" >
                <span lang="zh-cn">种子数量(48)</span>
        </td>
        <td bgcolor="white" style =" width:30%;">
                <uc1:CharText ID="CharText5" runat="server" />
        </td>           
  
    </tr>
        <tr>
        <td align = "right"  >
                <span lang="zh-cn">DNA材料份数(49)</span>
        </td>
        <td bgcolor="white" colspan = "3"  >
                
            <uc6:DigitalOnlyTxt ID="CharText6" runat="server" />
                
            </td>                
  
    </tr>
     <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">采集地点(50)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                
            <uc1:CharText ID="CharText7" runat="server" />
                
            </td>                
  
    </tr>
      <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">伴生物种(51)</span>
        </td>
        <td bgcolor="white" style =" width:25%;">
                <uc1:CharText ID="CharText8" runat="server" />
          </td>
        <td style =" width:30%;"  align = "right" >
                <span lang="zh-cn">经度(52)</span>
        </td>
        <td bgcolor="white" style =" width:30%;">
                <uc8:latitudeOnlyText ID="CharText9" runat="server" />
          </td>           
  
    </tr>
      <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">维度(53)</span>
        </td>
        <td bgcolor="white" style =" width:25%;">
                <uc8:latitudeOnlyText ID="CharText10" runat="server" />
          </td>
        <td style =" width:30%;"  align = "right" >
                <span lang="zh-cn">海拔(54)</span>
        </td>
        <td bgcolor="white" style =" width:30%;">
                <uc7:FloatDigitalOnlyText ID="CharText11" runat="server" />
          </td>           
  
    </tr>             
       <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">鉴定人(55)</span>
        </td>
        <td bgcolor="white" style =" width:25%;">
                <uc1:CharText ID="CharText12" runat="server" />
           </td>
        <td style =" width:30%;"  align = "right" >
                <span lang="zh-cn">鉴定时间(56)</span>
        </td>
        <td bgcolor="white" style =" width:30%;">
                <asp:TextBox ID="txt_date2" runat="server" BackColor="AliceBlue" Width="98%" 
                    CssClass="Wdate" oninit="txt_date2_Init"></asp:TextBox>
           </td>           
  
    </tr>                
           
       <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">种子收获时期(57)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
            <table>
              <tr>
                 <td>
                    <asp:RadioButtonList ID="rbtn_57" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">偏早</asp:ListItem>
                        <asp:ListItem Value="2">合适</asp:ListItem>
                        <asp:ListItem Value="3">偏晚</asp:ListItem>
                    </asp:RadioButtonList>
                  </td>
                  <td>
                  
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                          ControlToValidate="rbtn_57" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                  
                  </td>
               </tr>
           </table>
        </td>                
  
        </tr>
        <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">保存状况(58)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
           <table>
             <tr>
               <td>
                <asp:RadioButtonList ID="rbtn_58" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">潮湿</asp:ListItem>
                    <asp:ListItem Value="2">干燥</asp:ListItem>
                    <asp:ListItem Value="3">两者兼有</asp:ListItem>
                </asp:RadioButtonList>
                </td>
                <td>
                  
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                          ControlToValidate="rbtn_58" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                  
                </td>
            </tr>
           </table>     
         </td>               
  
        </tr>
      
        <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn"> 保存方式(59)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                
            <uc1:CharText ID="CharText14" runat="server" />
            </td>                
  
        </tr>
        <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">实物状态(60)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
            <table>
                <tr>
                    <td>
                     <asp:RadioButtonList ID="rbtn_60" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">完整</asp:ListItem>
                            <asp:ListItem Value="2">受损</asp:ListItem>
                            <asp:ListItem Value="3">严重受损</asp:ListItem>
                            <asp:ListItem Value="4">无实物</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                  
                         
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                          ControlToValidate="rbtn_60" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                  
                         
                    </td>
                </tr>
            </table>   
           

            </td>                
  
        </tr>
      
         <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn"> 植被类型(61)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
           
            
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                 <table>
                  <tr>
                    <td>
                    <asp:RadioButtonList ID="rbtn_61" runat="server" AutoPostBack="True" 
                        RepeatDirection="Horizontal" 
                            onselectedindexchanged="rbtn_61_SelectedIndexChanged">
                        <asp:ListItem Value="1">针叶林</asp:ListItem>
                        <asp:ListItem Value="2">针阔混交林</asp:ListItem>
                        <asp:ListItem Value="3">阔叶林</asp:ListItem>
                        <asp:ListItem Value="4">灌丛</asp:ListItem>
                        <asp:ListItem Value="5">草丛</asp:ListItem>
                        <asp:ListItem Value="6">其他</asp:ListItem>
                    </asp:RadioButtonList>
                    </td>
                    <td>
                    <asp:TextBox ID="txt_61" runat="server" Enabled="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                            ControlToValidate="rbtn_61" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                   </td>
                    </tr>
                  </table>    
                </ContentTemplate>
            </asp:UpdatePanel>
          


             </td>                
  
        </tr>
        <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">土壤类型(62)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                  <table>
                    <tr>
                      <td>                      
                          <asp:RadioButtonList ID="rbtn_62" runat="server" AutoPostBack="True" 
                              onselectedindexchanged="rbtn_62_SelectedIndexChanged" 
                              RepeatDirection="Horizontal">
                              <asp:ListItem Value="1">水稻土</asp:ListItem>
                              <asp:ListItem Value="2">赤红壤</asp:ListItem>
                              <asp:ListItem Value="3">红壤</asp:ListItem>
                              <asp:ListItem Value="4">黄棕壤</asp:ListItem>
                              <asp:ListItem Value="5">石灰(岩)土</asp:ListItem>
                              <asp:ListItem Value="6">紫色土</asp:ListItem>
                              <asp:ListItem Value="7">其他</asp:ListItem>
                          </asp:RadioButtonList>                      
                      </td>
                      <td>
                       <asp:TextBox ID="txt_62" runat="server" Enabled="False"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                              ControlToValidate="rbtn_62" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                      </td>
                    </tr>
                 </table>   
                </ContentTemplate>
            </asp:UpdatePanel>
                
            </td>                
  
        </tr>

        <tr>
        <td align = "right" class="style1" >
                <span lang="zh-cn">生态环境(63)</span>
        </td>
        <td bgcolor="white" colspan = "3" class="style2"  >
                
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                   <table>
                      <tr>
                        <td>
                        <asp:RadioButtonList ID="rbtn_63" runat="server" 
                            RepeatDirection="Horizontal" AutoPostBack="True" 
                                onselectedindexchanged="rbtn_63_SelectedIndexChanged">
                            <asp:ListItem Value="1">阴坡</asp:ListItem>
                            <asp:ListItem Value="2">阳坡</asp:ListItem>
                            <asp:ListItem Value="3">沟边</asp:ListItem>
                            <asp:ListItem Value="4">林下</asp:ListItem>
                            <asp:ListItem Value="5">其他</asp:ListItem>
                        </asp:RadioButtonList>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_63" runat="server" Enabled="False"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                ControlToValidate="rbtn_63" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                     </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
                
            </td>                
  
        </tr>
        <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">影响因子(64)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
             <ContentTemplate>
                   <table>
                      <tr>
                        <td>
                       
                            <asp:RadioButtonList ID="rbtn_64" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="rbtn_64_SelectedIndexChanged" 
                                RepeatDirection="Horizontal">
                                <asp:ListItem Value="1">放牧</asp:ListItem>
                                <asp:ListItem Value="2">耕作</asp:ListItem>
                                <asp:ListItem Value="3">砍伐</asp:ListItem>
                                <asp:ListItem Value="4">修路</asp:ListItem>
                                <asp:ListItem Value="5">采矿</asp:ListItem>
                                <asp:ListItem Value="6">其他</asp:ListItem>
                            </asp:RadioButtonList>
                       
                        </td>
                        <td>
                            <asp:TextBox ID="txt_64" runat="server" Enabled="False" EnableTheming="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                ControlToValidate="rbtn_64" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                     </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            </td>                
  
        </tr>
        <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn"> 生长习性(65)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
           <table>
               <tr>
               <td>
                <asp:RadioButtonList ID="rbtn_65" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">草本</asp:ListItem>
                    <asp:ListItem Value="2">乔木</asp:ListItem>
                    <asp:ListItem Value="3">灌木</asp:ListItem>
                    <asp:ListItem Value="4">藤本</asp:ListItem>
                </asp:RadioButtonList>
                </td>
                <td>
                  
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                          ControlToValidate="rbtn_65" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                  
                </td>
                </tr>

            </table>
            </td>                
  
        </tr>
        <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">寄主(66)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
                
            <uc1:CharText ID="CharText15" runat="server" />
            </td>                
  
        </tr>
        <tr>
        <td style =" width:15%;" align = "right" >
                <span lang="zh-cn">出现频度(67)</span>
        </td>
        <td bgcolor="white" style =" width:75%;" colspan = "3"  >
           <table>
              <tr>
                <td>
               
                <asp:RadioButtonList ID="rbtn_67" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">多</asp:ListItem>
                    <asp:ListItem Value="2">一般</asp:ListItem>
                    <asp:ListItem Value="3">少</asp:ListItem>
                    <asp:ListItem Value="4">偶见</asp:ListItem>
                </asp:RadioButtonList>
                 </td>
                 <td>
                 
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                          ControlToValidate="rbtn_67" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                  
                 </td>
                </tr>
             </table>     
            </td>                
  
        </tr>
      
                
                     
        <tr>
        <td align = "center" colspan="4" >
                <asp:Button ID="btn_save" runat="server" Text="保存信息" Width="92px" onclick="btn_save_Click" 
                   />
                <asp:Button ID="btn_back7" runat="server" Text="&lt;&lt;上一步" Width="96px" 
                    onclick="btn_back7_Click" ValidationGroup="1" 
                     />
                <asp:Button ID="btn_next7" runat="server" Text="下一步&gt;&gt;" Width="96px" 
                    onclick="btn_next7_Click" ValidationGroup="1" 
                     />
            </td>
  
    </tr>
                 
                 
                     
    </table>


<asp:HiddenField ID="hid_drugid" runat="server" Visible="False" />
<asp:HiddenField ID="hid_hdid" runat="server" Visible="False"  />
