using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace databaseproject.Advisor
{
    public partial class AdvisorLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void FN_AdvisorLogin(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int id = Int32.Parse(AdvisorIdTextBox.Text);
            string password = AdvisorpasswordTextBox.Text;

            if (id == 0 & password == "admin")
            {
                Response.Redirect("AdminHome.aspx");
            }
            else
            {


                SqlCommand loginproc = new SqlCommand("SELECT dbo.FN_AdvisorLogin(@advisor_Id,@password)", conn);
                loginproc.Parameters.AddWithValue("@advisor_Id", id);
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
                    Session["advisor_id"] = id;

                    Response.Redirect("AdvisorHome.aspx");
                }
            }
        }

        protected void advisorRegisteration(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorRegisteration.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainLogin.aspx");
        }
    }
}