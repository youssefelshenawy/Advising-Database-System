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
    public partial class AdvisorInsertCourseForGraduationPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Procedures_AdvisorCreateGP(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String StudentId = StudentIdText.Text;
            String semestercode = SemesterCodeText.Text;
            String CourseName = CourseNameText.Text;

            if (StudentId.Equals(""))
            {
                Response.Write("you should input the student id");
                return;
            }
            else
            {

                if (semestercode.Equals(""))
                {
                    Response.Write("you should input the semester code");
                    return;
                }
                else
                {

                    if (CourseName.Equals(""))
                    {
                        Response.Write("you should input the course name");
                        return;
                    }
                    else
                    {

                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT * FROM Course WHERE name= '" + CourseName + "' ";
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (!dr.Read())
                        {
                            conn.Close();
                            Response.Write("This Course name doesn't exist");
                            return;
                        }
                        else
                        {
                            conn.Close();

                            int StudentIdd = Convert.ToInt32(StudentId);


                            conn.Open();
                            cmd = new SqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "SELECT * FROM Student WHERE student_id= '" + StudentIdd + "' ";
                            dr = cmd.ExecuteReader();
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
                                cmd.CommandText = "SELECT * FROM Graduation_plan WHERE student_id= '" + StudentIdd + "' AND semester_code= '" + semestercode + "'";
                                dr = cmd.ExecuteReader();
                                if (!dr.Read())
                                {
                                    conn.Close();
                                    Response.Write("The graduation plan does not exists");
                                    return;
                                }

                                else
                                {
                                    conn.Close();
                                    conn.Open();
                                    cmd = new SqlCommand();
                                    cmd.Connection = conn;
                                    cmd.CommandText = "SELECT * FROM Graduation_plan WHERE student_id= '" + StudentIdd + "' AND advisor_id= '" + Convert.ToInt32(Session["advisor_id"]) + "' AND semester_code= '" + semestercode + "'";
                                    dr = cmd.ExecuteReader();
                                    if (!dr.Read())
                                    {
                                        conn.Close();
                                        Response.Write("You are not the advisor");
                                        return;
                                    }










                                    else
                                    {
                                        conn.Close();


                                        SqlCommand Addcourse = new SqlCommand("dbo.Procedures_AdvisorAddCourseGP", conn);
                                        Addcourse.CommandType = CommandType.StoredProcedure;

                                        Addcourse.Parameters.Add(new SqlParameter("@student_id", StudentIdd));
                                        Addcourse.Parameters.Add(new SqlParameter("@Semester_code", semestercode));
                                        Addcourse.Parameters.Add(new SqlParameter("@course_name", CourseName));




                                        conn.Open();
                                        try
                                        {
                                            Addcourse.ExecuteNonQuery();
                                            Response.Write("Updated");
                                        }
                                        catch (Exception ex)
                                        {
                                            Response.Write("can't have duplicates");
                                        }
                                        conn.Close();



                                    }


                                }

                            }
                        }
                    }
                }
            }
        }


                    protected void Go_Back(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorHome.aspx");
        }
    }
}