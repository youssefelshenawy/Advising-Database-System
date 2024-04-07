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
    public partial class StudentPart1i : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Proceed_Click(object sender, EventArgs e)
        {
            try
            {
                int CreditHours = Int32.Parse(TextBox1.Text);
                String Type = TextBox3.Text;
                String Comment = TextBox4.Text;
                string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                int sid = (int)Session["user"];


                if (CreditHours == 0 || Comment == "" || Type == "")
                {
                    Response.Write("You didn't enter either course id, comment or type");
                }
                else
                {


                    SqlCommand procReq = new SqlCommand("Exec Procedures_StudentSendingCourseRequest @StudentID,@credit_hours,@type,@comment", conn);
                    procReq.Parameters.AddWithValue("@StudentID", sid);
                    procReq.Parameters.AddWithValue("@credit_hours", CreditHours);
                    procReq.Parameters.AddWithValue("@type", Type);
                    procReq.Parameters.AddWithValue("@comment", Comment);

                    conn.Open();
                    procReq.ExecuteScalar();
                    Response.Write("Action done successfully");
                    conn.Close();





                }
            }
            catch (Exception)
            {
                Response.Write("Credit Hours too large. Can't assign");
            }
        }

        protected void GoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}