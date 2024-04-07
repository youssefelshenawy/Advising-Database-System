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
    public partial class StudentPart1e : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Proceed_Click(object sender, EventArgs e)
        {
            try
            {
                String sem = TextBox1.Text;
                Session["sem"] = sem;
                string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                int sid = (int)Session["user"];


                if (sem == "")
                {
                    Response.Write("You didn't enter semester code");
                }
                else
                {


                    SqlCommand fnAv = new SqlCommand("SELECT * FROM dbo.FN_SemsterAvailableCourses(@semstercode)", conn);
                    fnAv.Parameters.AddWithValue("@semstercode", sem);

                    conn.Open();
                    SqlDataReader reader = fnAv.ExecuteReader();
                    while (reader.Read())
                    {
                        String name = reader.GetString(reader.GetOrdinal("name"));
                        int course_id = reader.GetInt32(reader.GetOrdinal("course_id"));

                        Label lll = new Label();
                        lll.Text = "name:  " + name + "        course_id:  " + course_id + "<br/>";
                        form1.Controls.Add(lll);
                    }
                    Response.Write("Action done successfully, if no data displayed then there is no data to be display");
                    conn.Close();





                }
            }
            catch (Exception ex) { Response.Write("Fill all fields, and make sure the data are in right type"); }

        }

        protected void GoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}