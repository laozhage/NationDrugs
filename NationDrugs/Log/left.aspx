<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="NationDrugs.Log.left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
<link href ="../App_Themes/myskin/default.css" rel = "Stylesheet" type = "text/css" />

</head>
<body style="background-color:#e7eaf1;" >
    <form id="form1" runat="server" >
    <div>
    	<table border="0" style="width: 100%; height: 23px; background-color: #588fc7" cellpadding="0" cellspacing="0">
		<tr>
			<td align="center" valign='middle' style="font-size:10pt; font-weight: bold; color: White;">管理菜单</td>
		</tr>
            
        <tr>
          <%--<td>
               <table  cellspacing="0" cellpadding="0" width="100%" border="1" bordercolor="#588fc7" style = "background-color: White;  " >
                            <tr>
                                <td align="center" width="100%" height="50">
                                    <a href="../DrugHan/Admin/AdWeb/APassport.aspx?flag=0" target="fmain"><span style="text-decoration: none;">
                                    <font face="黑体" color="#000000" style="font-size: 14px;">添加新药材
                                    
                                    </font></span></a></td>
                            </tr>
                            <tr>
                                <td align="center" width="100%" height="50">
                                    <a href="../DrugHan/Client/findDrug.aspx" target="fmain"><span style="text-decoration: none; " ><font
                                        face="黑体" color="#000000"  style="font-size: 14px;" >查找药材</font></span></a></td>
                            </tr>
                           
                           <tr>
                           
                            

                 </table>

             
         </td>--%>
         <td style=" height:560px;">
         
           <div  style=" width:100%; height:100%;">
	        <iframe id= "ffleft" 
           style="Z-INDEX: 2; VISIBILITY:visible;width:100%; HEIGHT: 100%" 
            name ="left"  src="leftMenu.aspx"  frameborder="0" ></iframe>
	
            </div>
         </td>
        </tr>
	    </table>
    </div>
    </form>
</body>
</html>
