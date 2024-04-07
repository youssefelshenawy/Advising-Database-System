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
    public partial class StudentPart1h : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Proceed_Click(object sender, EventArgs e)
        {
            try
            {
                int CourseID = Int32.Parse(TextBox1.Text);
                String Type = TextBox3.Text;
                String Comment = TextBox4.Text;
                string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                int sid = (int)Session["user"];


                if (CourseID == 0 || Comment=="" || Type=="")
                {
                    Response.Write("You didn't enter either course id, comment or type");
                }
                else
                {


                    SqlCommand procReq = new SqlCommand("Exec Procedures_StudentSendingCourseRequest @courseID,@StudentID,@type,@comment", conn);
                    procReq.Parameters.AddWithValue("@courseID", CourseID);
                    procReq.Parameters.AddWithValue("@StudentID", sid);
                    procReq.Parameters.AddWithValue("@type", Type);
                    procReq.Parameters.AddWithValue("@comment", Comment);

                    conn.Open();
                    procReq.ExecuteScalar();
                    Response.Write("Action done successfully");
                    conn.Close();





                }
            }
            catch (Exception)
            {
                Response.Write("Course not found");
            }
        }

        protected void GoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}