<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvisorStudentMajorCourses.aspx.cs" Inherits="databaseproject.AdvisorStudentMajorCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="Label1" runat="server" Text="enter the major"></asp:Label>

            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

        </div>
        <asp:Button ID="Button2" runat="server" Text="View" OnClick="Button2_Click" />
        <asp:Button ID="Button1" runat="server" Text="Go back" OnClick="Button1_Click" />
    </form>

    
</body>
</html>
