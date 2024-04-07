using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace databaseproject
{
    public partial class StudentPart2d2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int sid = (int)Session["user"];
                int cid = (int)Session["cid"];
                String sem = (String)Session["sem"];

                if (cid == 0 || sem == "") { Response.Write("Fill all data fields"); }
                else
                {


                    SqlCommand proc1stMakeUp = new SqlCommand("Procedures_StudentRegisterFirstMakeup", conn);
                    proc1stMakeUp.CommandType = CommandType.StoredProcedure;
                    proc1stMakeUp.Parameters.AddWithValue("@StudentID", sid);
                    proc1stMakeUp.Parameters.AddWithValue("@CourseID", cid);
                    proc1stMakeUp.Parameters.AddWithValue("@studentCurr_sem", sem);


                    SqlParameter outputParam = new SqlParameter("@result", SqlDbType.Bit); // Adjust the SqlDbType and size based on your actual output parameter
                    outputParam.Direction = ParameterDirection.Output;
                    proc1stMakeUp.Parameters.Add(outputParam);



                    conn.Open();
                    proc1stMakeUp.ExecuteNonQuery();
                    string outputValue = outputParam.Value.ToString();
                    String m = outputValue;
                    if (m.Equals("False"))
                        Response.Write("You are not eligible");
                    else
                        Response.Write("Registration done");
                    conn.Close();


                }

            }
            catch(Exception ex) { Response.Write("Not eligible"); }
        }

            protected void GoBack_Click(object sender, EventArgs e)
            {
                Response.Redirect("StudentHome.aspx");
            }
        
    }
}