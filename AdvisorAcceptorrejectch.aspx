<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvisorAcceptorrejectch.aspx.cs" Inherits="databaseproject.AdvisorAcceptorrejectch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            Enter the request id</div>
        <asp:TextBox ID="RequestIdText" runat="server"></asp:TextBox>
        <p>
            Enter the current semester</p>
        <asp:TextBox ID="CurrentSemesterText" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Accept/Reject" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Go Back" OnClick="Button2_Click" />
        </p>
    </form>
</body>
</html>
