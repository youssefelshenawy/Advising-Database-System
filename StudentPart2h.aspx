<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentPart2h.aspx.cs" Inherits="databaseproject.StudentPart2h" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Instructor ID<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Course ID<br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Current Semester Code<br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Proceed" runat="server" Text="Proceed" OnClick="Proceed_Click" />
            <asp:Button ID="GoBack" runat="server" Text="GoBack" OnClick="GoBack_Click" />
        </div>
    </form>
</body>
</html>
