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
    public partial class StudentPart1c : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void GoBack_Click1(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }

        protected void Proceed_Click(object sender, EventArgs e)
        {
            try
            {
            String mob = TextBox1.Text;
            Session["mob"] = mob;
            string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int sid = (int)Session["user"];
            

            if (mob == "")
            {
                Response.Write("You didn't enter mobile number");
            }
            else
            {


                SqlCommand procAddMobile = new SqlCommand("Exec Procedures_StudentaddMobile @StudentID,@mobile_number", conn);
                procAddMobile.Parameters.AddWithValue("@StudentID", sid);
                procAddMobile.Parameters.AddWithValue("@mobile_number", mob);


                conn.Open();
                object result = procAddMobile.ExecuteScalar();
                Response.Write("Action done successfully");
                conn.Close();


            }
            }
            catch(Exception) {
                Response.Write("Already entered");
            }
        }
    }
}