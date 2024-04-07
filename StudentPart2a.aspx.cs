using Microsoft.SqlServer.Server;
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
    public partial class StudentPart2a : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int id = (int)Session["user"];

                SqlCommand viewGP = new SqlCommand("SELECT * FROM dbo.FN_StudentViewGP(@Student_id)", conn);
                viewGP.Parameters.AddWithValue("@Student_id", id);

                conn.Open();
                SqlDataReader reader = viewGP.ExecuteReader();
                while (reader.Read())
                {
                    String Student_name = reader.GetString(reader.GetOrdinal("Student_name"));
                    int plan_id = reader.GetInt32(reader.GetOrdinal("plan_id"));
                    String semester_code = reader.GetString(reader.GetOrdinal("semester_code"));
                    int semester_credit_hours = reader.GetInt32(reader.GetOrdinal("semester_credit_hours"));
                    DateTime expected_grad_date = reader.GetDateTime(reader.GetOrdinal("expected_grad_date"));
                    int advisor_id = reader.GetInt32(reader.GetOrdinal("advisor_id"));
                    int student_id = reader.GetInt32(reader.GetOrdinal("student_id"));
                    int course_id = reader.GetInt32(reader.GetOrdinal("course_id"));
                    String name = reader.GetString(reader.GetOrdinal("Course.name"));
                    Label lll = new Label();
                    lll.Text = "Student_name:  " + Student_name + "    plan_id:  " + plan_id + "    semester_code:  " + semester_code + "    semester_credit_hours:  " + semester_credit_hours
                        + "    expected_grad_date:  " + expected_grad_date + "     advisor_id:  " + advisor_id + "    student_id:  " + student_id + "     course_id:  " + course_id
                        + "     course name:  " + name + "<br/>";
                    form1.Controls.Add(lll);
                }
                Response.Write("Action done successfully");
                conn.Close();
            }
            catch(Exception ex) { Response.Write("No Graduation Plan"); }
        }

        protected void GoBack_Click1(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}