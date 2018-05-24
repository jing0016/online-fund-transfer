<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundTransferConfirmation.aspx.cs" Inherits="FundTransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bank of Algonquin</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />

</head>
<body style="background-color: lightyellow">
    <h1>Online Fund Transfer Service</h1>
    <form id="form1" runat="server" style="border:2px groove grey; padding-left:30px; width:50%; margin-left:10px;">

        <p class="LargeDistinct">Review and Complete</p>

        <p style="font-weight:bold;">Transferer</p>
        <asp:Label ID="Label1" runat="server" Text="   Name: "></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Account: "></asp:Label>
        <br />

        <asp:Label ID="Label3" runat="server" Text="Amount: "></asp:Label>

        <br />
        <p style="font-weight:bold;">Transferee</p>
        <asp:Label ID="Label4" runat="server" Text="   Name: "></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Account: "></asp:Label>
        <br />

        <br />
        <br />
        
        <asp:Button ID="btnComfirmToBack" runat="server" Text="&lt; Back" Cssclass="button" OnClick="btnComfirmToBack_Click"/>    
        <asp:Button ID="btnComfirmToNext" runat="server" Text="Complete" Cssclass="button" style="margin-left:120px;" OnClick="btnComfirmToNext_Click"/>
        <br />
        <br />
        
    </form>

</body>
</html>
