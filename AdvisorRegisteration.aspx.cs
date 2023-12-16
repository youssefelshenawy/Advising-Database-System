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
    public partial class AdvisorRegisteration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Procedures_AdvisorRegistration(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String name = NameTextBoxRA.Text;
            String password = passwordTextBoxRA.Text;
            String Email = EmailTextBoxRA.Text;
            String office = OfficeTextBoxRA.Text;

            if (name.Equals(""))
            {
                Response.Write("you should input your name");
                return;
            }
            else
            {

                if (password.Equals(""))
                {
                    Response.Write("you should input your password");
                    return;
                }
                else
                {

                    if (Email.Equals(""))
                    {
                        Response.Write("you should input your Email");
                        return;
                    }
                    else
                    {

                        if (office.Equals(""))
                        {
                            Response.Write("you should input your office");
                            return;
                        }
                        else
                        {

                            conn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "SELECT * FROM Advisor WHERE email= '" + Email+ "' ";
                            SqlDataReader dr = cmd.ExecuteReader();
                            
                            if (dr.Read())
                            {
                                conn.Close();
                                Response.Write("This email is already exist");
                            }
                            else
                            {
                                conn.Close();
                                SqlCommand Regproc = new SqlCommand("dbo.Procedures_AdvisorRegistration", conn);
                                Regproc.CommandType = CommandType.StoredProcedure;
                                Regproc.Parameters.Add(new SqlParameter("@advisor_name", name));
                                Regproc.Parameters.Add(new SqlParameter("@password", password));
                                Regproc.Parameters.Add(new SqlParameter("@email", Email));
                                Regproc.Parameters.Add(new SqlParameter("@office", office));

                                SqlParameter success = Regproc.Parameters.Add(new SqlParameter("@Advisor_id", SqlDbType.Int));
                                success.Direction = ParameterDirection.Output;

                                conn.Open();
                                Regproc.ExecuteNonQuery();
                                conn.Close();
                               
                                Response.Write("Registeration is complete "+(Regproc.Parameters["@Advisor_id"].Value));

                            }



                        }
                    }
                }
            }
        }

        protected void Go_Back(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorLogin.aspx");
        }
    }
}