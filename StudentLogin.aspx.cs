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
    public partial class StudentLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void FN_StudentLogin(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int id = Int32.Parse(StudentIdTextBox.Text);
            string password = StudentpasswordTextBox.Text;

            if (id == 0 & password == "admin")
            {
                Response.Redirect("AdminHome.aspx");
            }
            else
            {


                SqlCommand loginproc = new SqlCommand("SELECT dbo.FN_StudentLogin(@Student_id,@password)", conn);
                loginproc.Parameters.AddWithValue("@Student_id", id);
                loginproc.Parameters.AddWithValue("@password", password);

                conn.Open();
                object result = loginproc.ExecuteScalar();
                conn.Close();

                if (Convert.ToInt32(result) == 0)
                {
                    Response.Write("Invalid Login");
                }
                else
                {

                    Response.Redirect("StudentHome.aspx");
                }
            }
        }

       

        protected void StudentRegisteration(object sender, EventArgs e)
        {
            Response.Redirect("StudentRegisteration.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainLogin.aspx");

        }
    }
}