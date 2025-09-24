using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TwoLayerWebapp
{
    public partial class Loginpg : System.Web.UI.Page
    {
        Connectionclass objclass = new Connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "select count(Id) from Tab1twolayr where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";

            string cid = objclass.Fn_Scalar(s);

            if (cid == "1")
            {
                // Get actual Id instead of count
                string str = "select Id from Tab1twolayr where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";

                string id = objclass.Fn_Scalar(str);

                Session["uid"] = id;
                Response.Redirect("userprofile.aspx");
            }
            else
            {
                Label1.Text = "Invalid username and password";
            }
        }


    }
}