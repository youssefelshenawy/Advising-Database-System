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
    public partial class StudentPart2f : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int id = (int)Session["user"];

                SqlCommand viewCourseSlotsInstructor = new SqlCommand("SELECT * FROM Courses_Slots_Instructor", conn);

                conn.Open();
                SqlDataReader reader = viewCourseSlotsInstructor.ExecuteReader();
                while (reader.Read())
                {
                    int CourseID = reader.GetInt32(reader.GetOrdinal("CourseID"));
                    String Course = reader.GetString(reader.GetOrdinal("Course"));
                    int slot_id = reader.GetInt32(reader.GetOrdinal("slot_id"));
                    String day = reader.GetString(reader.GetOrdinal("day"));
                    String time = reader.GetString(reader.GetOrdinal("time"));
                    String location = reader.GetString(reader.GetOrdinal("location"));
                    int course_id = reader.GetInt32(reader.GetOrdinal("course_id"));
                    int instructor_id = reader.GetInt32(reader.GetOrdinal("instructor_id"));
                    String Instructor = reader.GetString(reader.GetOrdinal("Instructor"));
                    Label lll = new Label();
                    lll.Text = "CourseID:  " + CourseID + "    Course:  " + Course + "    slot_id:  " + slot_id + "     day:  " + day
                        + "    time:  " + time + "     location:  " + location + "    course_id:  " + course_id +
                        "    instructor_id:  " + instructor_id + "     Instructor:  " + Instructor + "<br/>";
                    form1.Controls.Add(lll);
                }
                Response.Write("Action done successfully");
                conn.Close();
            }
            catch (Exception ex) { Response.Write("No data to display"); }
        }

        protected void GoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}