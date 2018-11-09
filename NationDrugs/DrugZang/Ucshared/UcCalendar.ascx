<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcCalendar.ascx.cs" Inherits="NationDrugs.DrugZang.Ucshared.UcCalendar" %>
<link href="../../Cjs/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
<script language = "javascript"  src="../../Cjs/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

<asp:TextBox   ID="TextBox1" runat="server" Width="98%" oninit="TextBox1_Init" 
    CssClass="Wdate"></asp:TextBox>