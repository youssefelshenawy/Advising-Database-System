using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace databaseproject
{
    public partial class StudentPart2e2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int sid = (int)Session["user"];
                int cid = (int)Session["cid"];
                String sem = (String)Session["sem"];


                if (cid == 0 || sem == "")
                {
                    Response.Write("You either didn't enter course id or current semester code");
                }
                else
                {
                    SqlCommand fn2ndEligibility = new SqlCommand("SELECT dbo.FN_StudentCheckSMEligibility(@CourseID,@Student_id)", conn);
                    fn2ndEligibility.Parameters.AddWithValue("@CourseID", cid);
                    fn2ndEligibility.Parameters.AddWithValue("@Student_id", sid);

                    conn.Open();
                    Object result = fn2ndEligibility.ExecuteScalar();
                    conn.Close();
                    int res = Convert.ToInt32(result);




                    SqlCommand proc2stMakeUp = new SqlCommand("Exec Procedures_StudentRegisterSecondMakeup @StudentID, @courseID, @studentCurr_sem", conn);
                    proc2stMakeUp.Parameters.AddWithValue("@StudentID", sid);
                    proc2stMakeUp.Parameters.AddWithValue("@CourseID", cid);
                    proc2stMakeUp.Parameters.AddWithValue("@studentCurr_sem", sem);




                    conn.Open();
                    proc2stMakeUp.ExecuteScalar();
                    conn.Close();

                    if (res == 0)
                    {
                        Response.Write("You are not eligible");
                    }
                    else
                    {
                        Response.Write("Registered Successfully");
                    }
                }
            }
            catch(Exception) { Response.Write("Check that you filled all data"); }
        }

        protected void GoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");

        }
    }
}