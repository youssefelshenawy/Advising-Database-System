<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvisorLogin.aspx.cs" Inherits="databaseproject.Advisor.AdvisorLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Advisor Login</p>
        <p>
            enter your ID</p>
        <asp:TextBox ID="AdvisorIdTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="enter your password"></asp:Label>

        <p>
            <asp:TextBox ID="AdvisorpasswordTextBox" runat="server"></asp:TextBox>
        </p>

        <asp:Button ID="Advisorsignin" runat="server" OnClick="FN_AdvisorLogin" Text="Login"  />



        <asp:Button ID="Advisor_Registeration" runat="server" OnClick="advisorRegisteration" Text="Register" />




        <asp:Button ID="GoBack" runat="server" OnClick="Button1_Click" Text="Go back" />

        </form>
</body>
</html>
