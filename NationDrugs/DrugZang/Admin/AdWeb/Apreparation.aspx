<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Apreparation.aspx.cs" Inherits="NationDrugs.DrugZang.Admin.AdWeb.Apreparation" %>

<%@ Register src="../UcFiles/Ucpreparation.ascx" tagname="Ucpreparation" tagprefix="uc1" %>

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
    </div>
    <div> 
        <uc1:Ucpreparation ID="Ucpreparation1" runat="server" />
     </div>
   </form>
</body>
</html>
