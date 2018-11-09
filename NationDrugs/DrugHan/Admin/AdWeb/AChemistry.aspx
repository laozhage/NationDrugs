<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AChemistry.aspx.cs" Inherits="NationDrugs.DrugHan.Admin.AdWeb.AChemistry" %>

<%@ Register src="../UcFiles/UcChemistry.ascx" tagname="UcChemistry" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body  style = " padding:0px; margin:0px;">
    <form id="form1" runat="server">

    <div>
    
        <uc1:UcChemistry ID="UcChemistry1" runat="server" />
    
    </div>
    </form>
</body>
</html>
