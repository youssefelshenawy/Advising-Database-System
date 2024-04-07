using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace databaseproject
{
    public partial class AdminViewAllActiveStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString =
WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ConnectionString;
            string selectSQL = "SELECT *  FROM view_Students";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);


            DataSet ds = new DataSet();
            adapter.Fill(ds, "view_Students");
            if (IsEmpty(ds))
            {
                Response.Write("No data Available");
                return;
            }
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }

        bool IsEmpty(DataSet dataSet)
        {
            return !dataSet.Tables.Cast<DataTable>().Any(x => x.DefaultView.Count > 0);
        }

        protected void GoBackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome2.aspx");
        }

       
    }
}
    
