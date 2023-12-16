<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainLogin.aspx.cs" Inherits="databaseproject.MainLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Login Page</div>
        <asp:Button ID="Button1" runat="server" OnClick="I_am_student" Text="I am a student" />
        </br>
        <asp:Button ID="Button2" runat="server"  OnClick="I_am_advisor" Text="I am an advisor"/>
    </form>
</body>
</html>
