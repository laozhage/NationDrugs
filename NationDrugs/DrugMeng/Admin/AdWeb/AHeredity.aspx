﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AHeredity.aspx.cs" Inherits="NationDrugs.DrugMeng.Admin.AdWeb.AHeredity" %>

<%@ Register src="../UcFiles/UcHeredity.ascx" tagname="UcHeredity" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body  style = " padding:0px; margin:0px;">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <uc1:UcHeredity ID="UcHeredity1" runat="server" />
    
    </div>
    </form>
</body>
</html>
