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
    public partial class StudentPart2i : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int id = (int)Session["user"];

                SqlCommand viewCoursePrerequisites = new SqlCommand("SELECT * FROM view_Course_prerequisites", conn);

                conn.Open();
                SqlDataReader reader = viewCoursePrerequisites.ExecuteReader();
                while (reader.Read())
                {
                    int course_id = reader.GetInt32(reader.GetOrdinal("course_id"));
                    String name = reader.GetString(reader.GetOrdinal("name"));
                    String major = reader.GetString(reader.GetOrdinal("major"));
                    Boolean is_offered = reader.GetBoolean(reader.GetOrdinal("is_offered"));
                    int credit_hours = reader.GetInt32(reader.GetOrdinal("credit_hours"));
                    int semester = reader.GetInt32(reader.GetOrdinal("semester"));
                    int preRequsite_course_id = reader.GetInt32(reader.GetOrdinal("preRequsite_course_id"));
                    String preRequsite_course_name = reader.GetString(reader.GetOrdinal("preRequsite_course_name"));
                    Label lll = new Label();
                    lll.Text = "course_id:  " + course_id + "    name:  " + name + "     major:  " + major + "         is_offered:  " + is_offered
                        + "      credit_hours:  " + credit_hours + "        semester:  " + semester
                        + "     preRequsite_course_id:  " + preRequsite_course_id +
                        "      preRequsite_course_name:  " + preRequsite_course_name + "<br/>";
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