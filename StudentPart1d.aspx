<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentPart1d.aspx.cs" Inherits="databaseproject.StudentPart1d" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Semester Code<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Proceed" runat="server" Text="Proceed" OnClick="Proceed_Click" />
            <asp:Button ID="GoBack" runat="server" Text="GoBack" OnClick="GoBack_Click" />
        </div>
    </form>
</body>
</html>
