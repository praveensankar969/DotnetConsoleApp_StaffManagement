using System;
using System.Data;
using System.Data.SqlClient;
using DotnetConsoleApp_StaffManagement.Controller;
using DotnetConsoleApp_StaffManagement.DTO;

namespace Procedure
{
    public class SQLProcedure
    {
        SqlConnection connection;
        private string _config = @"Server=localhost\SQLEXPRESS;Database=TutorialDB;Trusted_Connection=True;";

        public void Insert<T>(T admin)
        {

            using (connection = new SqlConnection(_config))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                SqlCommand cmd = new SqlCommand(@"dbo.[InsertData]", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", SqlDbType.NVarChar).Value = typeof(T).GetProperty("UserName").GetValue(admin);
                cmd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = typeof(T).GetProperty("Password").GetValue(admin);
                cmd.Parameters.AddWithValue("@Experience", SqlDbType.Int).Value = typeof(T).GetProperty("Experience").GetValue(admin);
                cmd.Parameters.AddWithValue("@DateOfJoining", SqlDbType.DateTime).Value = typeof(T).GetProperty("DateOfJoining").GetValue(admin);
                cmd.Parameters.AddWithValue("@PhoneNumber", SqlDbType.NVarChar).Value = typeof(T).GetProperty("PhoneNumber").GetValue(admin);
                cmd.Parameters.AddWithValue("@Subject", SqlDbType.NVarChar).Value = typeof(T).GetProperty("Subject").GetValue(admin);
                cmd.Parameters.AddWithValue("@Type", SqlDbType.NVarChar).Value = typeof(T).GetProperty("Type").GetValue(admin);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Update<T>(T admin)
        {
            using (connection = new SqlConnection(_config))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                SqlCommand cmd = new SqlCommand(@"dbo.[UpdateData]", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = typeof(T).GetProperty("Id").GetValue(admin);
                cmd.Parameters.AddWithValue("@UserName", SqlDbType.NVarChar).Value = typeof(T).GetProperty("UserName").GetValue(admin);
                cmd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = typeof(T).GetProperty("Password").GetValue(admin);
                cmd.Parameters.AddWithValue("@Experience", SqlDbType.Int).Value = typeof(T).GetProperty("Experience").GetValue(admin);
                cmd.Parameters.AddWithValue("@DateOfJoining", SqlDbType.DateTime).Value = typeof(T).GetProperty("DateOfJoining").GetValue(admin);
                cmd.Parameters.AddWithValue("@PhoneNumber", SqlDbType.NVarChar).Value = typeof(T).GetProperty("PhoneNumber").GetValue(admin);
                cmd.Parameters.AddWithValue("@Subject", SqlDbType.NVarChar).Value = typeof(T).GetProperty("Subject").GetValue(admin);
                cmd.Parameters.AddWithValue("@Type", SqlDbType.NVarChar).Value = typeof(T).GetProperty("Type").GetValue(admin);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void GetAllData()
        {
            using (connection = new SqlConnection(_config))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                SqlCommand cmd = new SqlCommand(@"dbo.[GetData]", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Id: " + reader.GetInt32(0) + " Name: " + reader.GetString(1) + " \tDate of Joining: " + reader.GetDateTime(4) + " \tExperience: " + reader.GetInt32(3) + " \tPhone: " + reader.GetString(5) + " \tSubject: " + reader.GetString(6) + " \tStaff Type: " + reader.GetString(7));
                    }
                }
            }
        }

        public User Login(string username, string password)
        {
            using (connection = new SqlConnection(_config))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                SqlCommand cmd = new SqlCommand(@"dbo.[Login]", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", SqlDbType.NVarChar).Value = username;
                cmd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = password;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader != null)
                {
                    reader.Read();
                    return new User { Id = reader.GetInt32(0), Type = reader.GetString(7) };
                }
                else
                {
                    return new User { Id = -1, Type = " " };
                }
            }
        }

        public AdminStaff GetDataOfId(int id)
        {
            using (connection = new SqlConnection(_config))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                SqlCommand cmd = new SqlCommand(@"dbo.[GetWithId]", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = id;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader != null)
                {
                    reader.Read();
                    Console.WriteLine("Name: " + reader.GetString(1) + " \tDate of Joining: " + reader.GetDateTime(4) + " \tExperience: " + reader.GetInt32(3) + " \tPhone: " + reader.GetString(5) + " \tSubject: " + reader.GetString(6) + " \tStaff Type: " + reader.GetString(7));
                    return new AdminStaff {
                        Id = reader.GetInt32(0),
                        UserName = reader.GetString(1),
                        DateOfJoining = reader.GetDateTime(4),
                        Experience = reader.GetInt32(3),
                        PhoneNumber = reader.GetString(5),
                        Subject = reader.GetString(6),
                        Type = reader.GetString(7)
                    };
                }
                else{
                    return null;
                }
            }
        }

        public void DeleteDataOfId(int id)
        {
            using (connection = new SqlConnection(_config))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                SqlCommand cmd = new SqlCommand(@"dbo.[DeleteWithId]", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = id;
                cmd.ExecuteNonQuery();
            }
        }

    }
}