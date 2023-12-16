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
    public partial class Advisordeletecoursefromgraduationplan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            String studentids = StudentIdText.Text;
            String semestercodes = SemestecodeText.Text;
            String courseids = CourseIdText.Text;

            if(studentids.Equals(""))
            {
                Response.Write("Please enter the student id");
                return;
            }
            if (semestercodes.Equals(""))
            {
                Response.Write("Please enter the semester code");
                return;
            }
            if (courseids.Equals(""))
            {
                Response.Write("Please enter the course id");
                return;
            }

            int studentid = Convert.ToInt32(studentids);
            int courseid = Convert.ToInt32(courseids);


            String connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Student WHERE student_id= '" + studentid + "' ";
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                conn.Close();
                Response.Write("Invalid student id");
                return;
            }

            conn.Close();




            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Course WHERE course_id= '" + courseid + "' ";
             dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                conn.Close();
                Response.Write("Invalid Course id");
                return;
            }

            conn.Close();


            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Graduation_plan WHERE student_id = '" + studentid + "' AND advisor_id= '" + Convert.ToInt32(Session["advisor_id"]) + "'";
            dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                conn.Close();
                Response.Write("You are not the advisor of this student");
                return;
            }

            conn.Close();





            SqlCommand help = new SqlCommand("dbo.helper", conn);
            help.CommandType = CommandType.StoredProcedure;

            help.Parameters.Add(new SqlParameter("@studentID", studentid));
            help.Parameters.Add(new SqlParameter("@sem_code", semestercodes));
            help.Parameters.Add(new SqlParameter("@courseID", courseid));

            SqlParameter planid = help.Parameters.Add(new SqlParameter("@plan_id", SqlDbType.Int));
            planid.Direction = ParameterDirection.Output;


            conn.Open();
            help.ExecuteNonQuery();
            conn.Close();


            


            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM GradPlan_Course WHERE plan_id = '" + help.Parameters["@plan_id"].Value + "' AND semester_code= '" + semestercodes + "'And course_id= '" + courseid + "'";
            dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                conn.Close();
                Response.Write("this course is not in the graduation plan course");
                return;
            }

            conn.Close();



            SqlCommand delete = new SqlCommand("dbo.Procedures_AdvisorDeleteFromGP", conn);
            delete.CommandType = CommandType.StoredProcedure;

            delete.Parameters.Add(new SqlParameter("@studentID", studentid));
            delete.Parameters.Add(new SqlParameter("@sem_code", semestercodes));
            delete.Parameters.Add(new SqlParameter("@courseID", courseid));

            
            conn.Open();
            delete.ExecuteNonQuery();
            conn.Close();

            Response.Write("The course is deleted from the graduation plan course");



        }







        protected void Button2_Click(object sender, EventArgs e)
        {

            Response.Redirect("AdvisorHome.aspx");

        }
    }
}