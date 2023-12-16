using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace databaseproject
{
    public partial class AdvisorStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand Relstudentds = new SqlCommand("AdminListStudentsWithAdvisors", conn);
            Relstudentds.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader rdr = Relstudentds.ExecuteReader(CommandBehavior.CloseConnection);

            while (rdr.Read())
            {
                
                int studentid = rdr.GetInt32(rdr.GetOrdinal("student_id"));
                String studentfirstname =  rdr.GetString(rdr.GetOrdinal("f_name"));
                String studentLastname = rdr.GetString(rdr.GetOrdinal("L_name"));
                int advisorid = rdr.GetInt32(rdr.GetOrdinal("advisor_id"));
                String advisorname = rdr.GetString(rdr.GetOrdinal("advisor_name"));

                if (advisorid == Convert.ToInt32(Session["advisor_id"])) 
                {
                    Label student_id = new Label();
                    student_id.Text = "student_id: " + studentid + " studentfirstname: " + studentfirstname + " studentLastname: " + studentLastname + " advisorid: " + advisorid + " advisorname: " + advisorname + "<br />";
                    form1.Controls.Add(student_id);
                }
            }

        }

        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorHome.aspx");
        }
    }
}