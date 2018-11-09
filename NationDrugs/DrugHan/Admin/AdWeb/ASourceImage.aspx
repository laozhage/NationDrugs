<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ASourceImage.aspx.cs" Inherits="NationDrugs.DrugHan.Admin.AdWeb.ASourceImage" %>


<%@ Register src="../UcFiles/UcResourceImage.ascx" tagname="UcResourceImage" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body  style = " padding:0px; margin:0px;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
      
         <uc1:UcResourceImage ID="UcResourceImage1" runat="server" />
      
    <div>
    
    </div>
    </form>
</body>
</html>
