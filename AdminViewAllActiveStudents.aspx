<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminViewAllActiveStudents.aspx.cs" Inherits="databaseproject.AdminViewAllActiveStudents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:Button ID="GoBackButton" runat="server" Text="Go Back" OnClick="GoBackButton_Click" />
        </div>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        <br />
    </form>
</body>
</html>
