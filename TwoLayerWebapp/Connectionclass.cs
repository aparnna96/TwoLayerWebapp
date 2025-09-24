using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TwoLayerWebapp
{
    public class Connectionclass
    {
        SqlConnection con;
        SqlCommand cmd;
        public Connectionclass()
        {
            con = new SqlConnection(@"Server=localhost\MSSQLSERVER01;Database=master;Trusted_Connection=True;");
        }
        public int Fn_Nonquery(string sqlquery)//insert/delete/update
        {
            if(con.State== ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }
        public string Fn_Scalar(string sqlquery)//scalar fns
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            string s = cmd.ExecuteScalar().ToString();
            con.Close();
            return s;
        }
        public SqlDataReader Fn_Reader(string sqlquery)//select
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;

        }
        public DataSet Fn_DataSet(string sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }
        public DataTable Fn_DataTable(string sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void CreateTab1twolayrTable()
        {
            string createTableSql = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Tab1twolayr' AND xtype='U')
            CREATE TABLE Tab1twolayr (
                Id INT IDENTITY(1,1) PRIMARY KEY,
                name NVARCHAR(100),
                age INT,
                address NVARCHAR(200),
                photo NVARCHAR(200),
                Username NVARCHAR(100),
                Password NVARCHAR(100)
            )";
            Fn_Nonquery(createTableSql);
        }
    }
}