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
    public partial class View_all_requests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int advisorID = Convert.ToInt32(Session["advisor_id"]);

           
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Request WHERE advisor_id= '" + advisorID + "' ";
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                conn.Close();
                Response.Write("you don't have any request");
                return;
            }

            conn.Close();



            SqlCommand showreq = new SqlCommand("Select * FROM dbo.FN_Advisors_Requests(@advisor_id)", conn);
 
            showreq.Parameters.AddWithValue("@advisor_id", advisorID);
            

            conn.Open();



            SqlDataReader rdr = showreq.ExecuteReader(CommandBehavior.CloseConnection);



            while (rdr.Read())
            {

                int request_id = rdr.GetInt32(rdr.GetOrdinal("request_id"));
                String type = rdr.GetString(rdr.GetOrdinal("type"));
                String comment = rdr.GetString(rdr.GetOrdinal("comment"));
                String status = rdr.GetString(rdr.GetOrdinal("status"));
                int credit_hours = rdr.GetInt32(rdr.GetOrdinal("credit_hours"));
                int course_id = rdr.GetInt32(rdr.GetOrdinal("course_id"));
                int student_id = rdr.GetInt32(rdr.GetOrdinal("student_id"));


                Label student_idlabel = new Label();
                student_idlabel.Text = "request_id: " + request_id + " type: " + type + " comment: " + comment + " status: " + status + " credit_hours: " + credit_hours + " course_id: " + course_id + " student_id: " + student_id + "<br />";
                form1.Controls.Add(student_idlabel);


            }



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorHome.aspx");
        }
    }
}