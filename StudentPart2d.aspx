<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentPart2d.aspx.cs" Inherits="databaseproject.StudentPart2d" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Course ID</div>
        <p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            Current semester code</p>
        <p>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Proceed" runat="server" Text="Proceed" OnClick="Proceed_Click" />
            <asp:Button ID="GoBack" runat="server" Text="Go Back" OnClick="GoBack_Click" />
        </p>
    </form>
</body>
</html>
