<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="databaseproject.AdminHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div >
                <asp:Label ID="Label18" runat="server" Text="Output Area: "></asp:Label>
                <br />
                <asp:Label ID="resLabel" runat="server" Text=" "></asp:Label>
                
            </div>
            <br />
            <br />
    
            <asp:Label ID="Label1" runat="server" Text="Add A New Semester:"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Start Date: "></asp:Label>
            <br />
            <asp:TextBox ID="StartDateTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="End Date: "></asp:Label>
            <br />
            <asp:TextBox ID="EndDateTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Semester Code: "></asp:Label>
            <br />
            <asp:TextBox ID="SemesterCodeTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button5" runat="server" Text="Add Semester" OnClick="add_semester" />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Add A New Course:"></asp:Label>
            <br />
            Major:<br />
            <asp:TextBox ID="coursemajor" runat="server"></asp:TextBox>
            <br />
            Semester:<br />
            <asp:TextBox ID="coursesemester" runat="server"></asp:TextBox>
            <br />
            Credit Hours:<br />
            <asp:TextBox ID="coursecredithours" runat="server"></asp:TextBox>
            <br />
            Course Name:<br />
            <asp:TextBox ID="coursename" runat="server"></asp:TextBox>
            <br />
            Course Offered:<br />
            <asp:TextBox ID="courseoffered" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button6" runat="server" Text="Add New Course" OnClick="addSemester" />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Link Instructor To Course On Specific Slot:"></asp:Label>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Instructor ID:"></asp:Label>
            <br />
            <asp:TextBox ID="AdminLinkInstructorInstructorID" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label8" runat="server" Text="Course ID:"></asp:Label>
            <br />
            <asp:TextBox ID="AdminLinkInstructorCourseID" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label9" runat="server" Text="Slot ID:"></asp:Label>
            <br />
            <asp:TextBox ID="AdminLinkInstructorSlotID" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button7" runat="server" Text="Link Instructor To Course" OnClick="adminLinkInstructor" />
            <br />
            <asp:Label ID="Label10" runat="server" Text="Link Student To Advisor:"></asp:Label>
            <br />
            <asp:Label ID="Label11" runat="server" Text="Student ID:"></asp:Label>
            <br />
            <asp:TextBox ID="AdminLinkStudentToAdvisorStudentID" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label12" runat="server" Text="Advisor ID:"></asp:Label>
            <br />
            <asp:TextBox ID="AdminLinkStudentToAdvisorAdvisorID" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button8" runat="server" Text="Link Student To Advisor" OnClick="adminLinkStudentToAdvisor" />
            <br />
            <asp:Label ID="Label13" runat="server" Text="Link Student To Course With Specific Instructor:"></asp:Label>
            <br />
            <asp:Label ID="Label14" runat="server" Text="Instructor ID:"></asp:Label>
            <br />
            <asp:TextBox ID="AdminLinkStudentInstructorID" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label15" runat="server" Text="Student ID::"></asp:Label>
            <br />
            <asp:TextBox ID="AdminLinkStudentStudentID" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label16" runat="server" Text="Course ID:"></asp:Label>
            <br />
            <asp:TextBox ID="AdminLinkStudentCourseID" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label17" runat="server" Text="Semester Code:"></asp:Label>
            <br />
            <asp:TextBox ID="AdminLinkStudentSemesterCode" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button9" runat="server" Text="Link Student To Course Through Instructor" OnClick="adminLinkStudent" />
            <br />

            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="advisors_list" Text="View All Advisors" />
            <asp:Button ID="Button3" runat="server" OnClick="students_advisors_list" Text="View all Students with their Advisors" />
            <asp:Button ID="Button4" runat="server" OnClick="pendingRequests" Text="View All Pending Requests" />
            <asp:Button ID="Button10" runat="server" OnClick="assignedCourses" Text="View Details Of all Instructors With the Courses" />
            <br />
            <asp:Button ID="Button11" runat="server" Text="Fetch All Semesters Along With Their Offered Courses" OnClick="semster_offered_Courses" />
            <br />
            <br />
            <br />

        </div>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="more_Options" Text="More Options" />
            <asp:Button ID="Button12" runat="server" Text="Go Back Home" OnClick="Button12_Click" />
            <asp:Button ID="Button13" runat="server" Text="Go Back To Student Login" OnClick="Button13_Click" />
            <asp:Button ID="Button14" runat="server" Text="Go Back To Advisor Login" OnClick="Button14_Click" />
        </p>
    </form>
     
</body>
</html>
