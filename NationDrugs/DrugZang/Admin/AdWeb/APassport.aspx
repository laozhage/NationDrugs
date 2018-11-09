<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="APassport.aspx.cs" Inherits="NationDrugs.DrugZang.Admin.AdWeb.APassport" %>

<%@ Register src="../UcFiles/Ucpassport.ascx" tagname="Ucpassport" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body  style = " padding:0px; margin:0px;">
<div id="divShowLoading" style="position:absolute; display:none;">数据正在加载......</div>

<script type="text/javascript">

    function showProcess() { GetMsg(); }
    var timerId = null;
    function GetMsg() {
        var msg = document.getElementById("divShowLoading");
        msg.style.left = (document.body.clientWidth - 220) / 2;
        msg.style.top = window.screen.height / 3 - 120;
        if (window.document.readyState != null && window.document.readyState != 'complete')
        { msg.style.display = "block"; }
        else {
            msg.style.display = "none";
            window.clearTimeout(timerId); return;
        }
        timerId = window.setTimeout('GetMsg()', 1000);
    }
//    showProcess(); 
            </script>  

    <form id="form1" runat="server">
     <div>    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>        
    </div>
    <div>
     <uc1:Ucpassport ID="Ucpassport1" runat="server" />
    </div>
   
    </form>
</body>
</html>
