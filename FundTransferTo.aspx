<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundTransferTo.aspx.cs" Inherits="FundTransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bank of Algonquin</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />

</head>
<body style="background-color: lightyellow">
    <h1>Online Fund Transfer Service</h1>
    <form id="form1" runat="server" style="border:2px groove grey; padding-left:30px; width:50%; margin-left:10px;">

        <p class="LargeDistinct">Transferee</p>
        <asp:DropDownList ID="selectTransferee" runat="server" CssClass="dropdown" AutoPostBack="True" OnSelectedIndexChanged="selectTransferee_SelectedIndexChanged">
            <asp:ListItem Value="-1">Select Transferee</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="selectTransfereeValidator" runat="server" ErrorMessage="Must Select One" ControlToValidate="selectTransferee" CssClass="error" InitialValue="-1" ValidationGroup="group1" Display="Dynamic"></asp:RequiredFieldValidator>
        
        <p>To Account:</p>
        <asp:RadioButtonList ID="btnToAccount" runat="server" AutoPostBack="true">
            <asp:ListItem>Checking</asp:ListItem>
            <asp:ListItem>Saving</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:RequiredFieldValidator ID="toaccountValidator" runat="server" ErrorMessage="Must select an account!" ControlToValidate="btnToAccount" CssClass="error" ValidationGroup="group1"></asp:RequiredFieldValidator>
        <br />
        <br />
        
        <asp:Button ID="btnTransferToBack" runat="server" Text="&lt; Back" Cssclass="button" OnClick="btnTransferToBack_Click"/>    
        <asp:Button ID="btnTansferToNext" runat="server" Text="Next &gt;" Cssclass="button" style="margin-left:120px;" OnClick="btnTansferToNext_Click" ValidationGroup="group1"/>
        <br />
        <br />

    </form>
</body>
</html>
