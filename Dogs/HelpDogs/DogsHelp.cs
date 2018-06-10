using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dogs.Models;

namespace Dogs.HelpDogs
{
    public class DogsHelp
    {
        public List<SignIn> DogHMail()
        {
            SqlConnection SqlConnection1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sevak\Desktop\Dogs\DogsSql.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("SELECT * from [HelpDogs]");
            cmd.Connection = SqlConnection1;
            AddResponse add = new AddResponse();
            List<SignIn> lst = new List<SignIn>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                //int i = 0;
                SignIn user = new SignIn();
               // DataSet ds = new DataSet();
                //DataTable dt = new DataTable();
                //dt.Rows[0]["Name"].ToString();
               //foreach( DataRow r in ds.Tables[0].Rows)
               // {
               //     user = new SignIn();
               //     user.Email = reader["Mail"].ToString();
               //     user.Name = reader["Name"].ToString();
               //     AddResponse.AddGuest(user);
                   
               // }

                if (reader.Read())
                {
                   



                }
                lst.Add(user);
            }
            SqlConnection1.Close();
            return lst;
        }

        public List<string> DogHName()
        {
            SqlConnection SqlConnection1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sevak\Desktop\Dogs\DogsSql.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("SELECT * from [HelpDogs]");
            cmd.Connection = SqlConnection1;
            List<string> lst = new List<string>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                if (reader.Read())
                {
                    lst.Add(reader["Name"].ToString());
                }
            }
            SqlConnection1.Close();
            return lst;
        }

        public List<string> DogHPhone()
        {
            SqlConnection SqlConnection1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sevak\Desktop\Dogs\DogsSql.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("SELECT * from [HelpDogs]");
            cmd.Connection = SqlConnection1;
            List<string> lst = new List<string>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                if (reader.Read())
                {
                    lst.Add(reader["Phone"].ToString());
                }
            }
            SqlConnection1.Close();
            return lst;
        }

        public List<string> DogHText()
        {
            SqlConnection SqlConnection1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sevak\Desktop\Dogs\DogsSql.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("SELECT * from [HelpDogs]");
            cmd.Connection = SqlConnection1;
            List<string> lst = new List<string>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                if (reader.Read())
                {
                    lst.Add(reader["Text"].ToString());
                }
            }
            SqlConnection1.Close();
            return lst;
        }
        
    }
}
