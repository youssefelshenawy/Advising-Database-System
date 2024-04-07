<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminViewAllPayments.aspx.cs" Inherits="databaseproject.AdminViewAllPayments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="GoBackButton" runat="server" Text="Go Back" OnClick="GoBackButton_Click" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
