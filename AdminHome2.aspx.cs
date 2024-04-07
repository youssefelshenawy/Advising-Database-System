using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.CodeDom;

namespace databaseproject
{
    public partial class AdminHome2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void courseToBeDeletedButton_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if(courseToBeDeletedTextBox.Text.Equals(""))
            {
                Response.Write("Missing Course ID");
                return;
            }

            int id = Int32.Parse(courseToBeDeletedTextBox.Text);
            
            SqlCommand deleteCourse = new SqlCommand("[Procedures_AdminDeleteCourse]", conn);
            deleteCourse.CommandType = CommandType.StoredProcedure;
            deleteCourse.Parameters.Add(new SqlParameter("@courseID", id));

            conn.Open();
            deleteCourse.ExecuteNonQuery();
            conn.Close();

            Response.Write("Course Deleted Successfully");
        }

        protected void currentSemesterButton_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if (currentSemesterTextBox.Text.Equals(""))
            {
                Response.Write("Missing Semester Code");
                return;
            }

            string  currentSemester = currentSemesterTextBox.Text;


            SqlCommand deleteCourses = new SqlCommand("[Procedures_AdminDeleteSlots]", conn);
            deleteCourses.CommandType = CommandType.StoredProcedure;
            deleteCourses.Parameters.Add(new SqlParameter("@current_semester", currentSemester));

            conn.Open();
            deleteCourses.ExecuteNonQuery();
            conn.Close();

            Response.Write("Courses Deleted Successfully");
        }

        


        protected void ViewAllPaymentsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewAllPayments.aspx");
        }

        protected void IssueInstallmentsButton_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if(IssueInstallmentsTextBox.Text.Equals(""))
            {
                Response.Write("Missing Payment ID");
                return;
            }

            int paymentID = Int32.Parse(IssueInstallmentsTextBox.Text);

            conn.Open() ;

            SqlCommand cmd  = new SqlCommand();
            cmd.Connection = conn;  
            cmd.CommandText = "SELECT * FROM PAYMENT WHERE payment_id = " + paymentID;
            SqlDataReader rdr = cmd.ExecuteReader();
            if(!rdr.Read())
            {
                conn.Close();
                Response.Write("This payment ID is not available");
                return;
            }


            conn.Close() ;

            SqlCommand issueInstallments = new SqlCommand("[Procedures_AdminIssueInstallment]", conn);
            issueInstallments.CommandType = CommandType.StoredProcedure;
            issueInstallments.Parameters.Add(new SqlParameter("@payment_id", paymentID));

            conn.Open();
            issueInstallments.ExecuteNonQuery();
            conn.Close();

            Response.Write("Installments issued successfully");
        }

        protected void UpdateStudentStatusButton_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if(UpdateStudentStatusTextBox.Text.Equals(""))
            {
                Response.Write("Missing Student ID");
                return;
            }

            int studentID = Int32.Parse(UpdateStudentStatusTextBox.Text);

            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Student WHERE student_id = " + studentID;
            SqlDataReader rdr = cmd.ExecuteReader();
            if (!rdr.Read())
            {
                conn.Close();
                Response.Write("There is no Student with this ID");
                return;
            }


            conn.Close();


            SqlCommand updateStatus = new SqlCommand("[Procedure_AdminUpdateStudentStatus]", conn);
            updateStatus.CommandType = CommandType.StoredProcedure;
            updateStatus.Parameters.Add(new SqlParameter("@student_id", studentID));

            conn.Open();
            updateStatus.ExecuteNonQuery();
            conn.Close();

            Response.Write("Status Updated Successfully");
        }

        protected void ViewActiveStudentsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewAllActiveStudents.aspx");
        }

        protected void ViewAllGradPlansButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewGraduationPlans.aspx");
        }

        protected void GoBackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx");
        }

        protected void ViewAllTranscriptsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewAllTranscripts.aspx");
        }

        protected void ViewAllSemesterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewAllSemester.aspx");
        }

        protected void AddMakeupButton_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if (TypeOfMakeupTextBox.Text.Equals(""))
            {
                Response.Write("Missing Type of MakeUp");
                return;
            }
            if (DateTimeOfMakeupTextBox.Text.Equals(""))
            {
                Response.Write("Missing Date of Makeup");
                return;
            }
            if (courseIDTextBox.Text.Equals(""))
            {
                Response.Write("Missing Course ID");
                return;
            }

            string type = TypeOfMakeupTextBox.Text;
            DateTime date = Convert.ToDateTime(DateTimeOfMakeupTextBox.Text);
            int courseID = Int32.Parse(courseIDTextBox.Text);

            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Course WHERE course_id = " + courseID;
            SqlDataReader rdr = cmd.ExecuteReader();
            if (!rdr.Read())
            {
                conn.Close();
                Response.Write("There is no Course with this ID");
                return;
            }


            conn.Close();


            SqlCommand addMakeup = new SqlCommand("[Procedures_AdminAddExam]", conn);
            addMakeup.CommandType = CommandType.StoredProcedure;
            addMakeup.Parameters.Add(new SqlParameter("@Type", type));
            addMakeup.Parameters.Add(new SqlParameter("@date", date));
            addMakeup.Parameters.Add(new SqlParameter("@courseID", courseID));

            conn.Open();
            addMakeup.ExecuteNonQuery();
            conn.Close();

            Response.Write("Makeup Added Successfully.");
        }
    }
}