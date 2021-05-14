using System;
using Microsoft.Data.Sqlite;

namespace helloworld.DataBaseManipulatios
{
    public class UpdateTable
    {
        public void ExecuteQuery(string query){
             SqliteConnection conn;
            conn = CreateConnection();
            SqliteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();

            sqlite_cmd.CommandText = query;
            sqlite_cmd.ExecuteNonQuery();
        }


        public static SqliteConnection CreateConnection()
        {

            SqliteConnection sqlite_conn = new SqliteConnection("Data Source= database.db");

            try
            {
                sqlite_conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return sqlite_conn;
        }

    }
}
