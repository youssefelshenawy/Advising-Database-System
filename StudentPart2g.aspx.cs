using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace databaseproject
{
    public partial class StudentPart2g : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Proceed_Click(object sender, EventArgs e)
        {
            try
            {
                int cid = Int32.Parse(TextBox1.Text);
                int iid = Int32.Parse(TextBox2.Text);
                Session["cid"] = cid;
                Session["iid"] = iid;
                Response.Redirect("StudentPart2g2.aspx");
            }
            catch (Exception ex) { Response.Write("Fill all data fields"); }

        }

        protected void GoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}