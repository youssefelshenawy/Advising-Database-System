using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace databaseproject
{
    public partial class AdvisorStudentMajorCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }







        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorHome.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int advisorid = Convert.ToInt32(Session["advisor_id"]);

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Student WHERE advisor_id= '" + advisorid + "' ";
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                conn.Close();
                Response.Write("you don't have any student");
                return;
            }

            conn.Close();


            if (TextBox1.Text.Equals(""))
            {
                Response.Write("you should input the Major");
                return;
            }
            else
            {


                String Major = TextBox1.Text;

                conn.Open();
                 cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Student WHERE major= '" + Major + "' ";
                 dr = cmd.ExecuteReader();
                if (!dr.Read())
                {
                    conn.Close();
                    Response.Write("There is no one in this major");
                    return;
                }

                conn.Close();



                SqlCommand show = new SqlCommand("Procedures_AdvisorViewAssignedStudents", conn);
                show.CommandType = CommandType.StoredProcedure;

                show.Parameters.Add(new SqlParameter("@AdvisorID", advisorid));
                show.Parameters.Add(new SqlParameter("@major", Major));


                conn.Open();
                SqlDataReader rdr = show.ExecuteReader(CommandBehavior.CloseConnection);



                while (rdr.Read())
                {

                    int studentid = rdr.GetInt32(rdr.GetOrdinal("student_id"));
                    String studentname = rdr.GetString(rdr.GetOrdinal("Student_name"));
                    String major = rdr.GetString(rdr.GetOrdinal("major"));
                    String Course_name = rdr.GetString(rdr.GetOrdinal("Course_name"));


                    Label student_id = new Label();
                    student_id.Text = "student_id: " + studentid + " Student_name: " + studentname + " major: " + major + " Course_name: " + Course_name + "<br />";
                    form1.Controls.Add(student_id);


                }
            }

        }
    }
}