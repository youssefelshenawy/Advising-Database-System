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
    public partial class StudentPart2e : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Proceed_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["DBAdvising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int id = (int)Session["user"];
                int cid = Int32.Parse(TextBox1.Text);
                string sem = TextBox2.Text;
                Session["cid"] = cid;
                Session["sem"] = sem;
                Response.Redirect("StudentPart2e2.aspx");
            }
            catch (Exception ex) { Response.Write("Fill all data fields"); }

        }

        protected void GoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}