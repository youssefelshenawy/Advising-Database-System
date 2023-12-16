<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvisorInsertCourseForGraduationPlan.aspx.cs" Inherits="databaseproject.AdvisorInsertCourseForGraduationPlan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>

            <div>
           Add course inside certain plan of specific student<br />
            <br />
            Enter the Student Id</div>
        <asp:TextBox ID="StudentIdText" runat="server"></asp:TextBox>
        <br />
        <br />
        Enter the Semester code<p>
            <asp:TextBox ID="SemesterCodeText" runat="server" style="margin-bottom: 0px"></asp:TextBox>
        </p>
        <p>
            Enter the Course name:</p>
        <p>
            <asp:TextBox ID="CourseNameText" runat="server"></asp:TextBox>
        </p>
       
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Procedures_AdvisorCreateGP" Text="Add Course" />
            <asp:Button ID="Button2" runat="server" OnClick="Go_Back" Text="Go back" />
        </p>    
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        </div>
        </div>
    </form>
</body>
</html>
