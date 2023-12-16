using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace databaseproject
{
    public partial class Advisorupdategraduationdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String dateTimes = graddateText.Text;
            String studentids = StudentIdText.Text;

            if(dateTimes.Equals(""))
            {
                Response.Write("Please enter the date");
                return;
            }

            if (studentids.Equals(""))
            {
                Response.Write("Please enter the date");
                return;
            }

            DateTime dateTime = Convert.ToDateTime(dateTimes);
            int studentid = Convert.ToInt32(studentids);

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
            cmd.CommandText = "SELECT * FROM Graduation_Plan WHERE student_id= '" + studentid + "' AND advisor_id= '" + Convert.ToInt32(Session["advisor_id"]) + "'";



             dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                conn.Close();
                Response.Write("You are not the advisor of this student");
                return;
            }

            conn.Close();   


            SqlCommand update = new SqlCommand("dbo.Procedures_AdvisorUpdateGP", conn);
            update.CommandType = CommandType.StoredProcedure;

            update.Parameters.Add(new SqlParameter("@expected_grad_date", dateTime));
            update.Parameters.Add(new SqlParameter("@studentID", studentid));

            conn.Open();

            update.ExecuteNonQuery();
            conn.Close();

            Response.Write("Success");


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorHome.aspx");
        }
    }
}