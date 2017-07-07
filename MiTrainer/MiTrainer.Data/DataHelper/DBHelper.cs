using MiTrainer.Data.Account;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTrainer.Data.DataHelper
{
    public static class DBHelper
    {
        private static SqlConnection con = null;


        public static SqlConnection CreateConnection()
        {
            con = new SqlConnection();
            con.ConnectionString = @"Server=ONNU\SQLEXPRESS; database=MiTrainer; Trusted_Connection=True;";

            try
            {
                con.Open();
                return con;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not able to make connection.");
                return new SqlConnection(); ;
            }

        }

        public static DataTable GetTableData(string query)
        {
            var cmd = new SqlCommand();

            con = CreateConnection();
            DataTable dt = new DataTable();
            cmd.CommandText = query;

            using (var dataTable = new SqlDataAdapter(query, con))
            {
                dataTable.Fill(dt);
            }

            return dt;
        }

        public static int InsertData(string procName, Person p)
        {
            int rowsAffected = 0;
            
            con = CreateConnection();

            using (con)
            {
               var cmd = new SqlCommand("spCreatePerson", con);
                cmd.CommandType = CommandType.StoredProcedure;
                

                cmd.Parameters.AddWithValue("@first", p.FirstName);
                cmd.Parameters.AddWithValue("@last", p.LastName);
                cmd.Parameters.AddWithValue("@email", p.Email);
                cmd.Parameters.AddWithValue("@phone", p.Phone);
                cmd.Parameters.AddWithValue("@pTypeID", p.PersonTypeId);

                rowsAffected = cmd.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        public static int UpdateData(string tableName, string fieldName, int id)
        {
            var cmd = new SqlCommand();
            int rowsAffected = 0;
            string query = string.Format("UPDATE {0} SET {1} WHERE ID = {2}", tableName, fieldName, id);

            con = CreateConnection();
            cmd.CommandText = query;

            using (con)
            {
                rowsAffected = cmd.ExecuteNonQuery();
            }

            return rowsAffected;
        }


    }
}

