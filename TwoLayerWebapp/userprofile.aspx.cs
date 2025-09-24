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
    public partial class userprofile : System.Web.UI.Page
    {
        Connectionclass objclass = new Connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sel = "select name,age,address,photo from Tab1twolayr where Id=" + Session["uid"] + "";
            SqlDataReader dr = objclass.Fn_Reader(sel);
            while (dr.Read())
            {
                TextBox1.Text = dr["name"].ToString();
                TextBox2.Text = dr["age"].ToString();
                TextBox3.Text = dr["address"].ToString();
                Image1.ImageUrl = dr["photo"].ToString();
            }
            DataSet ds = objclass.Fn_DataSet(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}