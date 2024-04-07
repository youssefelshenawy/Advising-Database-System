using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace databaseproject
{
    public partial class StudentPart2h : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Proceed_Click(object sender, EventArgs e)
        {
            try
            {
                int iid = Int32.Parse(TextBox1.Text);
                int cid = Int32.Parse(TextBox2.Text);
                String sem = TextBox3.Text;
                Session["iid"] = iid;
                Session["cid"] = cid;
                Session["sem"] = sem;
                Response.Redirect("StudentPart2h2.aspx");
            }
            catch (Exception ex) { Response.Write("You need to fill all fields"); }
        }

        protected void GoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}