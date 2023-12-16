<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advisordeletecoursefromgraduationplan.aspx.cs" Inherits="databaseproject.Advisordeletecoursefromgraduationplan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter the student id<br />
            <asp:TextBox ID="StudentIdText" runat="server"></asp:TextBox>
            <br />
            <br />
            Enter the semester code</div>
        <asp:TextBox ID="SemestecodeText" runat="server"></asp:TextBox>
        <br />
        <br />
        Enter the course Id<br />
        <asp:TextBox ID="CourseIdText" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Delete" OnClick="Button1_Click" />
        &nbsp;<asp:Button ID="Button2" runat="server" Text="Go Back" OnClick="Button2_Click" />
        </p>
    </form>
</body>
</html>
