using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace databaseproject
{
    public partial class AdminHome : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void more_Options(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome2.aspx");
        }

        protected void advisors_list(object sender, EventArgs e)
        {

            clearlabel();
            string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand show = new SqlCommand("Procedures_AdminListAdvisors", conn);
            show.CommandType = CommandType.StoredProcedure;



            conn.Open();
            SqlDataReader rdr = show.ExecuteReader(CommandBehavior.CloseConnection);



            while (rdr.Read())
            {

                int advisorid = rdr.GetInt32(rdr.GetOrdinal("advisor_id"));
                String advisorname = rdr.GetString(rdr.GetOrdinal("advisor_name"));
                String advisoremail = rdr.GetString(rdr.GetOrdinal("email"));
                String advisoroffice = rdr.GetString(rdr.GetOrdinal("office"));
                String advisorpassword = rdr.GetString(rdr.GetOrdinal("password"));


                Label advisors = new Label();
                advisors.Text = "Advisor Id: " + advisorid + " Advisor Name: " + advisorname + " Email: " + advisoremail + " Office: " + advisoroffice + " Password: " + advisorpassword + "<br/>";

                resLabel.Text += advisors.Text;


            }

        }

        protected void students_advisors_list(object sender, EventArgs e)
        {

            clearlabel();
            string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand show = new SqlCommand("[AdminListStudentsWithAdvisors]", conn);
            show.CommandType = CommandType.StoredProcedure;



            conn.Open();
            SqlDataReader rdr = show.ExecuteReader(CommandBehavior.CloseConnection);



            while (rdr.Read())
            {


                int studentid = rdr.GetInt32(rdr.GetOrdinal("student_id"));
                String fname = rdr.GetString(rdr.GetOrdinal("f_name"));
                String lname = rdr.GetString(rdr.GetOrdinal("l_name"));
                int advisorid = rdr.GetInt32(rdr.GetOrdinal("advisor_id"));
                String advisorname = rdr.GetString(rdr.GetOrdinal("advisor_name"));


                Label advisors = new Label();
                advisors.Text = "Student_id: " + studentid + " Student_first_name: " + fname + " Student_last_name: " + lname + " Advisor_iD: " + advisorid + " Advisor_name: " + advisorname + "<br/>";

                resLabel.Text += advisors.Text;
            }







        }

        protected void pendingRequests(object sender, EventArgs e)
        {
            clearlabel();
            string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            //SqlCommand show = new SqlCommand("[Procedures_AdvisorViewPendingRequests]", conn);
            //show.CommandType = CommandType.StoredProcedure;

            string query = "SELECT * FROM all_Pending_Requests";
            SqlCommand command = new SqlCommand(query, conn);

            conn.Open();
            SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);



            while (rdr.Read())
            {


                int requestid = rdr.GetInt32(rdr.GetOrdinal("request_id"));
                String requesttype = rdr.GetString(rdr.GetOrdinal("type"));
                String requestcomment = rdr.GetString(rdr.GetOrdinal("comment"));
                String requeststatus = rdr.GetString(rdr.GetOrdinal("status"));
                int requestcredithours = rdr.GetInt32(rdr.GetOrdinal("credit_hours"));
                int requestcourseid = rdr.GetInt32(rdr.GetOrdinal("course_id"));
                int requeststudentid = rdr.GetInt32(rdr.GetOrdinal("student_id"));
                int requestadvisorid = rdr.GetInt32(rdr.GetOrdinal("advisor_id"));


                Label advisors = new Label();
                advisors.Text = "Request_id: " + requestid + " Type: " + requesttype + " comment: " + requestcomment + " Status: " + requeststatus
                    + " Credit_hours: " + requestcredithours + " Course_id: " + requestcourseid + " Student_id: " + requeststudentid
                    + " Advisor_id: " + requestadvisorid + "<br/>";

                resLabel.Text += advisors.Text;
            }




        }

        protected void add_semester(object sender, EventArgs e)
        {
            clearlabel();
            string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                DateTime sd = DateTime.Parse(StartDateTextBox.Text);
                DateTime ed = DateTime.Parse(EndDateTextBox.Text);
                int semestercode = int.Parse(SemesterCodeTextBox.Text);
                SqlCommand show = new SqlCommand("AdminAddingSemester", conn);
                show.CommandType = CommandType.StoredProcedure;

                show.Parameters.Add(new SqlParameter("@start_date", sd));
                show.Parameters.Add(new SqlParameter("@end_date", ed));
                show.Parameters.Add(new SqlParameter("@semester_code", semestercode));


                conn.Open();
                SqlDataReader rdr = show.ExecuteReader(CommandBehavior.CloseConnection);
                ShowAlert("Action was successful!");

            }
            catch (Exception)
            {
                ShowAlert("Action was unsuccessful, Check if you entered all fields and that the date was in the format DD/MM/YYYY correctly and a number in the semester code!");
            }

        }









        private void removelabels()
        {
            Response.Write("");
            Response.Write("");
        }

        protected void addSemester(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                String major = coursemajor.Text;
                int credithours = int.Parse(coursecredithours.Text);
                int semestercode = int.Parse(coursesemester.Text);
                String name = coursename.Text;
                int offered = int.Parse(courseoffered.Text);





                SqlCommand show = new SqlCommand("Procedures_AdminAddingCourse", conn);
                show.CommandType = CommandType.StoredProcedure;

                show.Parameters.Add(new SqlParameter("@major", major));
                show.Parameters.Add(new SqlParameter("@semester", semestercode));
                show.Parameters.Add(new SqlParameter("@credit_hours", credithours));
                show.Parameters.Add(new SqlParameter("@name", name));
                show.Parameters.Add(new SqlParameter("@is_offered", offered));


                conn.Open();
                SqlDataReader rdr = show.ExecuteReader(CommandBehavior.CloseConnection);
                ShowAlert("Action was successful!");

            }
            catch (Exception)
            {
                ShowAlert("Action was unsuccessful,Check if you entered all fields and that the semester and credit hours are numbers and the course offered bit is either 0 or 1!");
            }
        }
        private void ShowAlert(string message)
        {
            string script = $@"<script type='text/javascript'>alert('{message}');</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
        }

        protected void adminLinkInstructor(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            try
            {

                int instructorid = int.Parse(AdminLinkInstructorInstructorID.Text);
                int courseid = int.Parse(AdminLinkInstructorCourseID.Text);
                int slotid = int.Parse(AdminLinkInstructorSlotID.Text);





                SqlCommand show = new SqlCommand("Procedures_AdminLinkInstructor", conn);
                show.CommandType = CommandType.StoredProcedure;

                show.Parameters.Add(new SqlParameter("@cours_id", courseid));
                show.Parameters.Add(new SqlParameter("@instructor_id", instructorid));
                show.Parameters.Add(new SqlParameter("@slot_id", slotid));



                conn.Open();
                SqlDataReader rdr = show.ExecuteReader(CommandBehavior.CloseConnection);
                ShowAlert("Action was successful!");

            }
            catch (Exception)
            {
                ShowAlert("Action was unsuccessful,Check if you entered all fields and that the Course ID,Instructor ID, Slot ID are numbers");
            }
        }

        protected void adminLinkStudentToAdvisor(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            try
            {

                int studentID = int.Parse(AdminLinkStudentToAdvisorStudentID.Text);
                int advisorID = int.Parse(AdminLinkStudentToAdvisorAdvisorID.Text);






                SqlCommand show = new SqlCommand("Procedures_AdminLinkStudentToAdvisor", conn);
                show.CommandType = CommandType.StoredProcedure;

                show.Parameters.Add(new SqlParameter("@studentID", studentID));
                show.Parameters.Add(new SqlParameter("@advisorID", advisorID));




                conn.Open();
                SqlDataReader rdr = show.ExecuteReader(CommandBehavior.CloseConnection);
                ShowAlert("Action was successful!");

            }
            catch (Exception)
            {
                ShowAlert("Action was unsuccessful,Check if you entered all fields and that the Student ID and Advisor ID are numbers");
            }
        }

        protected void adminLinkStudent(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            try
            {

                int studentID = int.Parse(AdminLinkStudentStudentID.Text);
                int instructorID = int.Parse(AdminLinkStudentInstructorID.Text);
                int courseID = int.Parse(AdminLinkStudentCourseID.Text);
                String semesterCode = AdminLinkStudentSemesterCode.Text;






                SqlCommand show = new SqlCommand("Procedures_AdminLinkStudent", conn);
                show.CommandType = CommandType.StoredProcedure;

                show.Parameters.Add(new SqlParameter("@cours_id", courseID));
                show.Parameters.Add(new SqlParameter("@instructor_id", instructorID));
                show.Parameters.Add(new SqlParameter("@studentID", studentID));
                show.Parameters.Add(new SqlParameter("@semester_code", semesterCode));



                conn.Open();
                SqlDataReader rdr = show.ExecuteReader(CommandBehavior.CloseConnection);
                ShowAlert("Action was successful!");

            }
            catch (Exception)
            {
                ShowAlert("Action was unsuccessful,Check if you entered all fields and that the Student ID, Instructor ID and Course ID are numbers");
            }
        }

        protected void assignedCourses(object sender, EventArgs e)
        {
            clearlabel();
            string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            string query = "SELECT * FROM Instructors_AssignedCourses";
            SqlCommand command = new SqlCommand(query, conn);

            conn.Open();
            SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);



            while (rdr.Read())
            {


                int instructor_id = rdr.GetInt32(rdr.GetOrdinal("instructor_id"));
                String instructorname = rdr.GetString(rdr.GetOrdinal("Instructor"));
                String coursename = rdr.GetString(rdr.GetOrdinal("Course"));
                int courseid = rdr.GetInt32(rdr.GetOrdinal("course_id"));


                Label advisors = new Label();
                advisors.Text = "Instructor_id: " + instructor_id + " Instructor_name: " + instructorname +
                    " Course_id: " + courseid + " Course_name: " + coursename + "<br/>";

                resLabel.Text += advisors.Text;
            }

        }

        protected void semster_offered_Courses(object sender, EventArgs e)
        {

            clearlabel();
            string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            string query = "SELECT * FROM Semster_offered_Courses";
            SqlCommand command = new SqlCommand(query, conn);

            conn.Open();
            SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);



            while (rdr.Read())
            {

                int courseid = rdr.GetInt32(rdr.GetOrdinal("course_id"));
                String coursename = rdr.GetString(rdr.GetOrdinal("name"));
                String semestercode = rdr.GetString(rdr.GetOrdinal("semester_code"));




                Label advisors = new Label();
                advisors.Text = "Course_id: " + courseid + " Course_name: " + coursename + " Semester_Code: " + semestercode + "<br/>";
                resLabel.Text += advisors.Text;

            }
        }

        private void clearlabel()
        {
            resLabel.Text = " ";
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainLogin.aspx");
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogin.aspx");
        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorLogin.aspx");
        }
    }
}