using InsuranceRestSerwer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InsuranceRestSerwer
{
    public class SqlHelper
    {
        public Client getUser(int Id)
        {
            SqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["localDb"].ConnectionString;
          //  string myConnectionString = @"Server = tcp:insuranceappdatabaseserver.database.windows.net,1433; Initial Catalog = InsuranceAppDatabase; Persist Security Info = False; User ID = BartlomiejLeja; Password = Sim13vetson!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            conn = new SqlConnection();
            try
            {
                conn.ConnectionString = myConnectionString;
                conn.Open();
                var user = new Client();
                var userList = new List<Client>();
                SqlDataReader mySqlDataReader = null;
                var sqlString = "SELECT * FROM UserInsurance WHERE ID =" + Id.ToString();
                SqlCommand cmd = new SqlCommand(sqlString,conn);
                mySqlDataReader = cmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                //    user.Id = mySqlDataReader.GetInt32(0);
                //    user.FirstName = mySqlDataReader.GetString(1);
                //    user.SecondName = mySqlDataReader.GetString(2);
                   return user;
                }
                else return null;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally { conn.Close(); }
        }

        public void saveUser(Client userToSave)
        {
            SqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["localDb"].ConnectionString;
          //  string myConnectionString = @"Server = tcp:insuranceappdatabaseserver.database.windows.net,1433; Initial Catalog = InsuranceAppDatabase; Persist Security Info = False; User ID = BartlomiejLeja; Password = Sim13vetson!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            conn = new SqlConnection();
            try
            {
                conn.ConnectionString = myConnectionString;
                conn.Open();
                //var sqlString = "INSERT INTO UserInsurance (Id,FirstName,SecondName) VALUES ('"+userToSave.Id+ "','" + userToSave.FirstName+"','"+ userToSave.SecondName +"')";
             //   SqlCommand cmd = new SqlCommand(sqlString, conn);
                //cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally { conn.Close(); }
        }
    }
}