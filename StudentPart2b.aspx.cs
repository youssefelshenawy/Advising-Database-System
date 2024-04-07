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
    public partial class StudentPart2b : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int id = (int)Session["user"];

                SqlCommand viewInstallment = new SqlCommand("SELECT dbo.FN_StudentUpcoming_installment(@Student_id)", conn);
                viewInstallment.Parameters.AddWithValue("@Student_id", id);

                conn.Open();
                object result = viewInstallment.ExecuteScalar();

                if (result.ToString() == "") { Response.Write("No upcoming unpaid installment "); }
                else { Response.Write("Action done successfully, your deadline is due    " + result); }
                conn.Close();


                Response.Write(result);
            }
            catch (Exception ex) { Response.Write("No data to display"); }
        }

        protected void GoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}