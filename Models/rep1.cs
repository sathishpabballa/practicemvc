using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace practicemvc.Models
{
    
    public class rep1
    {

        string s = ConfigurationManager.ConnectionStrings["sa"].ToString();
        public void insert(model1 obj)
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlCommand com = new SqlCommand("prc_insert1", con);
            com.CommandType = CommandType.StoredProcedure;
           
            com.Parameters.AddWithValue("@name", obj.name);
            com.Parameters.AddWithValue("@password", obj.password);
            com.Parameters.AddWithValue("@address", obj.address);
            com.ExecuteNonQuery();
            con.Close();
        }
        public List<model1> display()
        {
            SqlConnection con = new SqlConnection(s);
            List<model1> lob = new List<model1>();
            con.Open();
            SqlCommand com = new SqlCommand("prc_select", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
           
            da.Fill(dt);
            con.Close();
            foreach(DataRow dr in dt.Rows)
            {
                lob.Add(new model1()
                {
                    id = Convert.ToInt32(dr["id"]),
                    name=Convert.ToString(dr["name"]),
                    password=Convert.ToString(dr["password"]),
                    address=Convert.ToString(dr["address"])
                }); 
            }
            return lob;
        }
        public void update(model1 uobj)
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlCommand com = new SqlCommand("prc_update", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", uobj.id);
            com.Parameters.AddWithValue("@name", uobj.name);
            com.Parameters.AddWithValue("@password", uobj.password);
            com.Parameters.AddWithValue("@address", uobj.address);
            com.ExecuteNonQuery();
            con.Close();
        }
        public void delete(int id)
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlCommand com = new SqlCommand("prc_delete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
           
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}