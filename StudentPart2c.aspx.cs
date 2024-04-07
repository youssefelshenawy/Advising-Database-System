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
    public partial class StudentPart2c : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int id = (int)Session["user"];

                SqlCommand viewCourseExams = new SqlCommand("SELECT * FROM Courses_MakeupExams", conn);

                conn.Open();
                SqlDataReader reader = viewCourseExams.ExecuteReader();
                while (reader.Read())
                {
                    int exam_id = reader.GetInt32(reader.GetOrdinal("exam_id"));
                    DateTime date = reader.GetDateTime(reader.GetOrdinal("date"));
                    String type = reader.GetString(reader.GetOrdinal("type"));
                    int course_id = reader.GetInt32(reader.GetOrdinal("course_id"));
                    String name = reader.GetString(reader.GetOrdinal("name"));
                    int semester = reader.GetInt32(reader.GetOrdinal("semester"));
                    Label lll = new Label();
                    lll.Text = "exam_id:  " + exam_id + "    date:  " + date + "    type:  " + type + "    course_id:  " + course_id
                        + "     name:  " + name + "     semester:  " + semester + "<br/>";
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