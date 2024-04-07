<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHome2.aspx.cs" Inherits="databaseproject.AdminHome2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="GoBackButton" runat="server" Text="Go Back" OnClick="GoBackButton_Click" />
            <br />
            Enter Course ID<br />
            <asp:TextBox ID="courseToBeDeletedTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="courseToBeDeletedButton" runat="server" Text="Delete Course" OnClick="courseToBeDeletedButton_Click" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Enter Current Semester "></asp:Label>
            <br />
            <asp:TextBox ID="currentSemesterTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="currentSemesterButton" runat="server" Text="Delete unofferd Courses" OnClick="currentSemesterButton_Click" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Enter type of Makeup exam"></asp:Label>
            <br />
            <asp:TextBox ID="TypeOfMakeupTextBox" runat="server" style="margin-bottom: 5px"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Enter Datetime for the Makeup "></asp:Label>
            <br />
            <asp:TextBox ID="DateTimeOfMakeupTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Enter the Course's ID"></asp:Label>
            <br />
            <asp:TextBox ID="courseIDTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="AddMakeupButton" runat="server" Text="Add Makeup" OnClick="AddMakeupButton_Click" style="height: 29px" />
            <br />
            <br />
            <asp:Button ID="ViewAllPaymentsButton" runat="server" Text="View All Payments" OnClick="ViewAllPaymentsButton_Click" />
            <br />
            <br />
        </div>
        Enter Payment ID<br />
        <asp:TextBox ID="IssueInstallmentsTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="IssueInstallmentsButton" runat="server" Text="Issue Installments" OnClick="IssueInstallmentsButton_Click" />
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Enter Student's ID"></asp:Label>
        <br />
        <asp:TextBox ID="UpdateStudentStatusTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="UpdateStudentStatusButton" runat="server" Text="Update Status" OnClick="UpdateStudentStatusButton_Click" />
        <br />
        <br />
        <asp:Button ID="ViewActiveStudentsButton" runat="server" Text="View Active Students" OnClick="ViewActiveStudentsButton_Click" />
        <br />
        <br />
        <asp:Button ID="ViewAllGradPlansButton" runat="server" Text="View All Graduation Plans" OnClick="ViewAllGradPlansButton_Click" />
        <br />
        <br />
        <asp:Button ID="ViewAllTranscriptsButton" runat="server" Text="View All Students' Transcripts" OnClick="ViewAllTranscriptsButton_Click" />
        <p>
            <asp:Button ID="ViewAllSemesterButton" runat="server" Text="View all Semester with their offered courses" OnClick="ViewAllSemesterButton_Click" />
        </p>
    </form>
</body>
</html>

