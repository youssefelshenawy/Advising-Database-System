using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace databaseproject
{
    public partial class StudentHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = (int)Session["user"];
            Response.Write("Your id is "+id);
        }

        protected void part2a_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPart2a.aspx");
            
        }

        protected void part2b_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPart2b.aspx");
        }

        protected void part2c_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPart2c.aspx");
        }

        protected void part2d_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPart2d.aspx");
        }

        protected void part2e_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPart2e.aspx");
        }

        protected void part2f_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPart2f.aspx");
        }

        protected void part2g_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPart2g.aspx");
        }

        protected void part2h_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPart2h.aspx");
        }

        protected void part2i_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPart2i.aspx");
        }

        protected void part1c_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPart1c.aspx");
        }

        protected void part1d_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPart1d.aspx");
        }

        protected void part1e_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPart1e.aspx");
        }

        protected void part1f_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPart1f.aspx");
        }

        protected void part1g_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPart1g.aspx");
        }

        protected void part1h_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPart1h.aspx");
        }

        protected void part1i_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentPart1i.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogin.aspx");
        }
    }
}