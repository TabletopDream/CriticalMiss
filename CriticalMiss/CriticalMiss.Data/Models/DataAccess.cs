using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace CriticalMiss.Data.Models
{
    public class DataAccess
    {
        public readonly IConfiguration configuration;
        public DataAccess(IConfiguration config)
        {
            this.configuration = config;
        }
        public void connection()
        { 
        string constr =configuration.GetConnectionString("CriticalMissDB");
        }
        //public bool CreateGames(Games games)
        //{
        //   // connection();
        //   // //SqlConnection con = new SqlConnection(constr);
        //   // SqlCommand cmd = new SqlCommand("", );
        //   // cmd.CommandType = CommandType.StoredProcedure;
        //   //// cmd.Connection = con;
        //   // cmd.Parameters.AddWithValue("@", games.GameName);
        //   // cmd.Parameters.AddWithValue("@", games.Password);
        //   // cmd.Parameters.AddWithValue("@", games.UserName);

        //   // con.Open();
        //   // int p = cmd.ExecuteNonQuery();
        //   // con.Close();
        //   // if (p > 0)
        //   // {
        //   //     return true;
        //   // }
        //   // else
        //   // {
        //   //     return false;
        //   // }

        //}
    }
}
