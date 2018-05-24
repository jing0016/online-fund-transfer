<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundTransferFrom.aspx.cs" Inherits="FundTransferFrom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bank of Algonquin</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />

</head>
<body style="background-color: lightyellow">
    <h1>Online Fund Transfer Service</h1>
    <form id="form1" runat="server" style="border:2px groove grey; padding-left:30px; width:50%; margin-left:10px;">

        <p class="LargeDistinct">Transfer From</p>
        <asp:DropDownList ID="selectTransferor" runat="server" CssClass="dropdown" OnSelectedIndexChanged="selectTransferor_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Value="-1">Select Transferor</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="selectTransferorValidator" runat="server" ErrorMessage="Must Select One" ControlToValidate="selectTransferor" CssClass="error" InitialValue="-1"></asp:RequiredFieldValidator>
        <p>From Account:</p>
        <asp:RadioButtonList ID="btnFromAccount" runat="server" OnSelectedIndexChanged="btnFromAccount_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem>Checking</asp:ListItem>
            <asp:ListItem>Saving</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:RequiredFieldValidator ID="accountValidator" runat="server" ErrorMessage="Must select an account!" ControlToValidate="btnFromAccount" CssClass="error"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="lblAmount" runat="server" Text="Amount:   "></asp:Label>
        <asp:TextBox ID="txtBoxAmount" runat="server" CssClass="input"></asp:TextBox>
        <asp:RequiredFieldValidator ID="amountValidator" runat="server" ErrorMessage="<br /><br />Can not be blank" ControlToValidate="txtBoxAmount" CssClass="error" display="Dynamic"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="amountCompareValidator" runat="server" ErrorMessage="<br /><br />Must greater than 0" ControlToValidate="txtBoxAmount" Type="Double" CssClass="error" Operator="GreaterThan" ValueToCompare="0" display="Dynamic"></asp:CompareValidator>
        <asp:RangeValidator ID="amountRangeValidator" runat="server" ErrorMessage="<br /><br />Must be less than or equal to the balance of the amount" ControlToValidate="txtBoxAmount" CssClass="error" Type="Double" display="Dynamic"></asp:RangeValidator>
        <br />
        <br />
            <asp:Button ID="btnTansferForm" runat="server" Text="Next &gt;" Cssclass="button" style="margin-left:170px;" OnClick="btnTansferForm_Click"/>
        <br />
        <br />
    </form>
</body>
</html>
