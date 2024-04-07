<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRegisteration.aspx.cs" Inherits="databaseproject.StudentRegisteration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            First Name<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Last Name<br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Password<br />
            <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
            <br />
            Faculty<br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            Email<br />
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            Major<br />
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            Semester<br />
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Register" runat="server" Text="Register" OnClick="Register_Click" />
            <asp:Button ID="GoBack" runat="server" Text="Go Back" OnClick="GoBack_Click" />
        </div>
    </form>
</body>
</html>
