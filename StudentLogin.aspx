<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentLogin.aspx.cs" Inherits="databaseproject.StudentLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Student Login</p>
        <p>
            enter your ID</p>
        <asp:TextBox ID="StudentIdTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="enter your password"></asp:Label>

        <p>
            <asp:TextBox ID="StudentpasswordTextBox" runat="server"></asp:TextBox>
        </p>

        <asp:Button ID="signin" runat="server" OnClick="FN_StudentLogin" Text="Login"  />



        <asp:Button ID="Student_Registeration" runat="server" OnClick="StudentRegisteration" Text="Register" />



        

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Go back" />



        

    </form>
</body>
</html>
