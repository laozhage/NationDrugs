﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ACharacter.aspx.cs" Inherits="NationDrugs.DrugWei.Admin.AdWeb.ACharacter" %>

<%@ Register src="../UcFiles/ucCharacter.ascx" tagname="ucCharacter" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body   style = " padding:0px; margin:0px;">
    <form id="form1" runat="server">
    <div>
    
        <uc1:ucCharacter ID="ucCharacter1" runat="server" />
    
    </div>
    </form>
</body>
</html>
