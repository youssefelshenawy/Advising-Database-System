<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advisorupdategraduationdate.aspx.cs" Inherits="databaseproject.Advisorupdategraduationdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter the expected grad date</div>
        <asp:TextBox ID="graddateText" runat="server"></asp:TextBox>
        <p>
            Enter the student id</p>
        <p>
&nbsp;<asp:TextBox ID="StudentIdText" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Go back" OnClick="Button2_Click" />
    </form>
</body>
</html>
