<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CharTextRequired.ascx.cs" Inherits="NationDrugs.DrugZang.Ucshared.CharTextRequired" %>
<asp:TextBox ID="TextBox1"  runat="server"  Width = "96%" Height = "100%" Font-Names = "Microsoft Himalaya" Font-Size = "17pt"  BackColor = "AliceBlue"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
    ControlToValidate="TextBox1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
