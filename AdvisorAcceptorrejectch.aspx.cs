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
    public partial class AdvisorAcceptorrejectch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String RequestIds= RequestIdText.Text;
            String CurrentSemester = CurrentSemesterText.Text;

            if(RequestIds.Equals(""))
            { Response.Write("Please enter the request id");
              return;
            }

            if (CurrentSemester.Equals(""))
            {
                Response.Write("Please enter the current semester");
                return;
            }

            int RequestId = Convert.ToInt32(RequestIds);

            String connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Request WHERE request_id = '" + RequestId + "' ";
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                conn.Close();
                Response.Write("Invalid Request id");
                return;
            }

            conn.Close();






            conn.Open();
             cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Request WHERE request_id = '" + RequestId + "'And advisor_id=' " + Convert.ToInt32(Session["advisor_id"])+"'";
             dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                conn.Close();
                Response.Write("You are not the advisor for that request");
                return;
            }

            conn.Close();

       





            String temp = "credit hours";

            conn.Open();
             cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Request WHERE request_id = '" + RequestId + "' And type= '" + temp + "' And advisor_id='" + Convert.ToInt32(Session["advisor_id"]) + "'";
             dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                conn.Close();
                Response.Write("this request id has a different type ");
                return;
            }

            conn.Close();


            SqlCommand ch = new SqlCommand("dbo.Procedures_AdvisorApproveRejectCHRequest", conn);
            ch.CommandType = CommandType.StoredProcedure;

            ch.Parameters.Add(new SqlParameter("@requestID", RequestId));
            ch.Parameters.Add(new SqlParameter("@current_sem_code", CurrentSemester));

            SqlParameter planid = ch.Parameters.Add(new SqlParameter("@result", SqlDbType.Int));
            planid.Direction = ParameterDirection.Output;
           

            conn.Open();
            ch.ExecuteNonQuery();
            conn.Close();

            if(Convert.ToInt32(planid.Value) == 0)
            {
                Response.Write("The request is rejected");
                return;
            }

            if (Convert.ToInt32(planid.Value)==1)
            {
                Response.Write("The request is accepted");
                return;
            }

            


        }











        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorHome.aspx");
        }
    }
}