using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TwoLayerWebapp
{
    public partial class Connectionform : System.Web.UI.Page
    {
        Connectionclass objclass = new Connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = "~/Photooos/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(path));
            string strinsert = "insert into Tab1twolayr values ('" + TextBox1.Text + "', " + TextBox2.Text + ", '" + TextBox3.Text + "', '" + path + "', '" + TextBox4.Text + "', '" + TextBox5.Text + "')";

            int i = objclass.Fn_Nonquery(strinsert);
            if (i == 1)
            {
                Label1.Text = "Inserted";
            }

        }
    }
}