using System;
using Microsoft.Data.Sqlite;

namespace helloworld.DataBaseManipulatios
{
    public class ViewTable
    {
       
        public void ViewDataTable(string tableName)
        {
            SqliteConnection conn;
            conn = CreateConnection();
            SqliteDataReader sqlite_datareader;
            SqliteCommand sqlite_cmd;

            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM " + tableName;

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.Write(myreader + "\t");

                myreader = sqlite_datareader.GetString(1);
                Console.Write(myreader + "\t");

                myreader = sqlite_datareader.GetString(2);
                Console.Write(myreader + "\t");

                myreader = sqlite_datareader.GetString(3);
                Console.Write(myreader + "\t");

                myreader = sqlite_datareader.GetString(4);
                Console.Write(myreader + "\t");

                myreader = sqlite_datareader.GetString(5);
                Console.Write(myreader + "\t");
            }
            conn.Close();

        }

        public void ViewDataTableWithQuery(string query)
        {
            SqliteConnection conn;
            conn = CreateConnection();
            SqliteDataReader sqlite_datareader;
            SqliteCommand sqlite_cmd;

            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = query;

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            Boolean flag = false;
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.Write(myreader + "\t");

                myreader = sqlite_datareader.GetString(1);
                Console.Write(myreader + "\t");

                myreader = sqlite_datareader.GetString(2);
                Console.Write(myreader + "\t");

                myreader = sqlite_datareader.GetString(3);
                Console.Write(myreader + "\t");

                myreader = sqlite_datareader.GetString(4);
                Console.Write(myreader + "\t");

                myreader = sqlite_datareader.GetString(5);
                Console.Write(myreader + "\t");
                Console.WriteLine("\n");
                flag = true;
            }
            conn.Close();

            if(!flag){
                Console.WriteLine("No rows were found");
            }

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


