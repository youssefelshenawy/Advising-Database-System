using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace databaseproject
{
    public partial class AdvisorHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AdminListStudentsWithAdvisors(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorStudents.aspx");
        }

        protected void SignOut(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorLogin.aspx");

        }

        protected void Insertgradutationplan_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorInsertGraduationPlan.aspx");
        }

        protected void InsertCourseforgdplan_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorInsertCourseForGraduationPlan.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
    
                Response.Redirect("AdvisorStudentMajorCourses.aspx");
            
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorView_all_requests.aspx");
        }

        protected void Procedures_AdvisorViewPendingRequests_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorPendingRequests.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Advisorupdategraduationdate.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Advisordeletecoursefromgraduationplan.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorAcceptorrejectch.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorAcceptorrejectcourse.aspx");
        }
    }
}