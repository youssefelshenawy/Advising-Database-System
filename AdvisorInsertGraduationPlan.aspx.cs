using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace databaseproject
{
    public partial class InsertGraduationPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Procedures_AdvisorCreateGP(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String semestercode = semestercodetext.Text;
            String expected_graduation_date = expected_graduation_datetext.Text;
            String sem_credit_hours = sem_credit_hourstext.Text;
            String StudentId = StudentIdtext.Text;

            int AdvisorId = Convert.ToInt32(Session["advisor_id"]);

            if (semestercode.Equals(""))
            {
                Response.Write("you should input the semester code");
                return;
            }
            else
            {

                if (expected_graduation_date.Equals(""))
                {
                    Response.Write("you should input the expected graduation date");
                    return;
                }
                else
                {

                    if (sem_credit_hours.Equals(""))
                    {
                        Response.Write("you should input the semester credit hours");
                        return;
                    }
                    else
                    {

                        if (StudentId.Equals(""))
                        {
                            Response.Write("you should input the student Id");
                            return;
                        }
                        else
                        {

                            conn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "SELECT * FROM Student WHERE student_id= '" + StudentId + "' ";
                            SqlDataReader dr = cmd.ExecuteReader();

                            if (!dr.Read())
                            {
                                conn.Close();
                                Response.Write("This student id doesn't exist");
                                return;
                            }
                            else
                            {

                                conn.Close();


                                conn.Open();
                                cmd = new SqlCommand();
                                cmd.Connection = conn;
                                cmd.CommandText = "SELECT * FROM Student WHERE student_id= '" + StudentId + "' AND advisor_id= '" + Convert.ToInt32(Session["advisor_id"])+"'";
                                 dr = cmd.ExecuteReader();

                                if (!dr.Read())
                                {
                                    conn.Close();
                                    Response.Write("You are not the advisor of that student");
                                    return;
                                }
                                else
                                {



                                    conn.Close();

                                    int StudentIdd = Convert.ToInt32(StudentIdtext.Text);
                                    SqlCommand Addplan = new SqlCommand("dbo.Procedures_AdvisorCreateGP", conn);
                                    Addplan.CommandType = CommandType.StoredProcedure;
                                    Addplan.Parameters.Add(new SqlParameter("@Semester_code", semestercode));
                                    Addplan.Parameters.Add(new SqlParameter("@expected_graduation_date", expected_graduation_date));
                                    Addplan.Parameters.Add(new SqlParameter("@sem_credit_hours", sem_credit_hours));
                                    Addplan.Parameters.Add(new SqlParameter("@advisor_id", AdvisorId));
                                    Addplan.Parameters.Add(new SqlParameter("@student_id", StudentIdd));

                                    SqlParameter success = Addplan.Parameters.Add(new SqlParameter("@success", SqlDbType.Int));
                                    success.Direction = ParameterDirection.Output;






                                    conn.Open();
                                    Addplan.ExecuteNonQuery();
                                    conn.Close();

                                    if (success.Value.ToString().Equals("0"))
                                    {
                                        Response.Write("This student has acquired hours less than 157");
                                        return;
                                    }
                                    else

                                        Response.Write("Success");

                                }
                            }
                        }
                    }
                }
            }

        }
        protected void Go_Back(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorHome.aspx", true);
        }
    }
}