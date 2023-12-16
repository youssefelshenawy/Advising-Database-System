<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvisorRegisteration.aspx.cs" Inherits="databaseproject.AdvisorRegisteration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Adisor Registeration<br />
            <br />
            Enter your name</div>
        <asp:TextBox ID="NameTextBoxRA" runat="server"></asp:TextBox>
        <br />
        <br />
        Enter the password<p>
            <asp:TextBox ID="passwordTextBoxRA" runat="server" style="margin-bottom: 0px"></asp:TextBox>
        </p>
        <p>
            Email:</p>
        <p>
            <asp:TextBox ID="EmailTextBoxRA" runat="server"></asp:TextBox>
        </p>
        <p>
            Office</p>
        <p>
            <asp:TextBox ID="OfficeTextBoxRA" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Procedures_AdvisorRegistration" Text="Register" />
            <asp:Button ID="Button2" runat="server" OnClick="Go_Back" Text="Go back" />
        </p>    
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
