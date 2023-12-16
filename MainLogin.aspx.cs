using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace databaseproject
{
    public partial class MainLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void I_am_student(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogin.aspx");
        }

       

        protected void I_am_advisor(object sender, EventArgs e)
        {
            
            Response.Redirect("AdvisorLogin.aspx");

        }
    }
}