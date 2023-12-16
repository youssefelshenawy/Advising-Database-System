<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvisorHome.aspx.cs" Inherits="databaseproject.AdvisorHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="AdminListStudentsWithAdvisors" Text="View all his/her advising students" />
            <br />
            <asp:Button ID="Insertgradutationplan" runat="server" Text="Insert graduation plan for a certain student" OnClick="Insertgradutationplan_Click" />
            <br />
            <asp:Button ID="InsertCourseforgdplan" runat="server" Text=" Insert courses for a specific graduation plan" OnClick="InsertCourseforgdplan_Click" />
            <br />
            <asp:Button ID="Button3" runat="server" Text="Update expected graduation date in a certain graduation plan" OnClick="Button3_Click" />
            <br />
            <asp:Button ID="Button4" runat="server" Text="Delete course from a certain graduation plan in a certain semester" OnClick="Button4_Click" />
            <br />
            <asp:Button ID="Button5" runat="server" Text="View all students assigned from a certain major along with their taken courses" OnClick="Button5_Click" Height="22px" Width="755px" />
            <br />
            <asp:Button ID="Button6" runat="server" Text="View all requests" OnClick="Button6_Click" />
            <br />
            <asp:Button ID="Procedures_AdvisorViewPendingRequests" runat="server" Text="View pending requests" OnClick="Procedures_AdvisorViewPendingRequests_Click" />
            <br />
            <asp:Button ID="Button7" runat="server" Text="Approve/ reject extra credit hours request" OnClick="Button7_Click" />
            <br />
            <asp:Button ID="Button8" runat="server" Text=" Approve/ reject extra courses request" OnClick="Button8_Click" />
        </div>
        <asp:Button ID="Button2" runat="server" style="height: 29px" OnClick="SignOut" Text="Sign Out" />
    </form>
</body>
</html>
