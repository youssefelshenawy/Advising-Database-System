<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentHome.aspx.cs" Inherits="databaseproject.StudentHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Button ID="part1c" runat="server" Text="Add telephone number(s)" OnClick="part1c_Click" />
            <br />
            <asp:Button ID="part1d" runat="server" Text="View all optional courses in the current semester" OnClick="part1d_Click" />
            <br />
            <asp:Button ID="part1e" runat="server" Text="View all available courses in the current semester" OnClick="part1e_Click" />
            <br />
            <asp:Button ID="part1f" runat="server" Text="View the required courses within the current semester" OnClick="part1f_Click" />
            <br />
            <asp:Button ID="part1g" runat="server" Text="View the missing courses" OnClick="part1g_Click" />
            <br />
            <asp:Button ID="part1h" runat="server" Text="Send a course request" OnClick="part1h_Click" />
            <br />
            <asp:Button ID="part1i" runat="server" Text="Send a credit hour request" OnClick="part1i_Click" />
            <br />
            <asp:Button ID="part2a" runat="server" Text="View Graduation Plan with assigned hours" OnClick="part2a_Click" />
            <br />
            <asp:Button ID="part2b" runat="server" Text="View upcoming not paid installment" OnClick="part2b_Click" />
            <br />
            <asp:Button ID="part2c" runat="server" Text="View all courses along with their exams details" OnClick="part2c_Click" />
            <br />
            <asp:Button ID="part2d" runat="server" Text="Register for first makeup exam" OnClick="part2d_Click" />
            <br />
            <asp:Button ID="part2e" runat="server" Text="Register for second makeup exam" OnClick="part2e_Click" />
            <br />
            <asp:Button ID="part2f" runat="server" Text="View all courses along with their corresponding slots details and instructors" OnClick="part2f_Click" />
            <br />
            <asp:Button ID="part2g" runat="server" Text="View the slots of a certain course that is taught by a certain instructor" OnClick="part2g_Click" />
            <br />
            <asp:Button ID="part2h" runat="server" Text="Choose the instructor for a certain course" OnClick="part2h_Click" />
            <br />
            <asp:Button ID="part2i" runat="server" Text="View all details of all courses with their prerequisites" OnClick="part2i_Click" />
        </div>
        <asp:Button ID="Button1" runat="server" Text="Sign out" OnClick="Button1_Click" />
    </form>
</body>
</html>
