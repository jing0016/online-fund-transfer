<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundTransferResult.aspx.cs" Inherits="FundTransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bank of Algonquin</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />

</head>
<body style="background-color: lightyellow">
    <h1>Online Fund Transfer Service</h1>
      <form id="form1" runat="server" style="border:2px groove grey; padding-left:30px; width:90%; margin-left:10px;">

        <p style="font-size:30px">Thank you for using Online fund transfer service.</p>
          <asp:Label ID="Label6" runat="server" style="font-size:30px"></asp:Label>
        <br />
        <br />
        <p style="font-weight:bold;">From</p>
        <asp:Label ID="Label1" runat="server" Text="   Name: "></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Account: "></asp:Label>
        <br />

        <br />
        <p style="font-weight:bold;">To</p>
        <asp:Label ID="Label4" runat="server" Text="   Name: "></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Account: "></asp:Label>
        <br />

        <br />
        <br />
          
        <asp:Button ID="btnResult" runat="server" Text="Start A New Transfer" Cssclass="button" style="margin-left:120px;" OnClick="btnResult_Click" Width="342px"/>
        <br />
        <br />
        
    </form>
</body>
</html>
