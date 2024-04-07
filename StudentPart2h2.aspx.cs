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
    public partial class StudentPart2h2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int sid = (int)Session["user"];
                int iid = (int)Session["iid"];
                int cid = (int)Session["cid"];
                String sem = (String)Session["sem"];

                if (cid == 0 || iid == 0 || sem == "")
                {
                    Response.Write("You either didn't enter course id or instructor id or Current semester code");
                }
                else
                {


                    SqlCommand procChooseInstructor = new SqlCommand("Exec Procedures_ChooseInstructor @StudentID,@InstructorID,@CourseID,@SemCode", conn);
                    procChooseInstructor.Parameters.AddWithValue("@StudentID", sid);
                    procChooseInstructor.Parameters.AddWithValue("@InstructorID", iid);
                    procChooseInstructor.Parameters.AddWithValue("@CourseID", cid);
                    procChooseInstructor.Parameters.AddWithValue("@SemCode", sem);

                    //SqlParameter outputParam = new SqlParameter("@result", SqlDbType.Bit); // Adjust the SqlDbType and size based on your actual output parameter
                    //outputParam.Direction = ParameterDirection.Output;
                    //procChooseInstructor.Parameters.Add(outputParam);

                    conn.Open();
                    object result = procChooseInstructor.ExecuteScalar();
                    //string outputValue = outputParam.Value.ToString();
                    //int m = Int32.Parse(outputValue);
                    Response.Write("Instructor chosen, if you're taking this course this semester");
                    conn.Close();

                    //if (m == 0)
                    //    Response.Write("You are not taking this course this semester");
                    //else
                    //    Response.Write("Instructor chosen");

                }
            }
            catch (Exception ex){ ShowAlert("This course is not taken by you this semester"); }
        }

        private void ShowAlert(string message)
        {
            string script = $@"<script type='text/javascript'>alert('{message}');</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
        }

        protected void GoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}