<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="findDrug.aspx.cs" Inherits="NationDrugs.DrugMeng.Client.findDrug" %>

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
    <div style=" height:30px;">
    
        <uc1:CharText ID="CharText1" runat="server" Width="200px" />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
        
    </div>
    </form>
</body>
</html>
