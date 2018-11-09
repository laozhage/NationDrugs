<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcDDRright.ascx.cs" Inherits="NationDrugs.DrugZang.Admin.UcFiles.UcDDRright" %>

<link href="Popwindows.css" rel="stylesheet" type="text/css" />
 
<asp:DropDownList ID="DropDownList1" runat="server" CssClass = "btnHima">
    <asp:ListItem Value="0">请选择...</asp:ListItem>
    <asp:ListItem Value="1">品名</asp:ListItem>
    <asp:ListItem Value="2">产品</asp:ListItem>
    <asp:ListItem Value="3">专利</asp:ListItem>
    <asp:ListItem Value="4">标准</asp:ListItem>
    <asp:ListItem Value="5">规范</asp:ListItem>
</asp:DropDownList>

