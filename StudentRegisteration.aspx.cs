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
    public partial class StudentRegisteration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Register_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                string fname = TextBox1.Text;
                string lname = TextBox2.Text;
                string pass = TextBox3.Text;
                string faculty = TextBox4.Text;
                string email = TextBox5.Text;
                string major = TextBox6.Text;
                int sem = Int32.Parse(TextBox7.Text);
                SqlCommand show = new SqlCommand("Procedures_StudentRegistration", conn);
                show.CommandType = CommandType.StoredProcedure;

                show.Parameters.AddWithValue("@first_name", fname);
                show.Parameters.AddWithValue("@last_name", lname);
                show.Parameters.AddWithValue("@password", pass);
                show.Parameters.AddWithValue("@faculty", faculty);
                show.Parameters.AddWithValue("@email", email);
                show.Parameters.AddWithValue("@major", major);
                show.Parameters.AddWithValue("@Semester", sem);


                SqlParameter outputParam = new SqlParameter("@Student_id", SqlDbType.Int); // Adjust the SqlDbType and size based on your actual output parameter
                outputParam.Direction = ParameterDirection.Output;
                show.Parameters.Add(outputParam);



                conn.Open();
                show.ExecuteNonQuery();
                string outputValue = outputParam.Value.ToString();
                Session["user"] = Int32.Parse(outputValue);
                Response.Redirect("StudentHome.aspx");
            }
            catch (Exception ex) { Response.Write("Fill all fields, and make sure the data are in right data type"); }
        }

        protected void GoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogin.aspx");
        }
    }
}