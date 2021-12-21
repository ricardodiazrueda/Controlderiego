using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Entities;

namespace Data
{
    public class UserData : Database
    {
        public string Insert(UserEntity user)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        user.Password = Util.Util.Hash(user.Password);

                        string query = "INSERT INTO Users (UserName, Password, FullName, Type) VALUES ('{0}', '{1}', '{2}', {3})";
                        query = string.Format(query, user.UserName, user.Password, user.FullName, user.Type);

                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public UserEntity Read(string username, string password)
        {
            try
            {
                UserEntity user = null;

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        password = Util.Util.Hash(password);

                        string query = "SELECT * FROM Users WHERE UserName = '{0}' AND Password = '{1}'";
                        query = string.Format(query, username, password);

                        command.CommandText = query;

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new UserEntity();
                                user.UserID = Convert.ToInt32(reader["UserID"]);
                                user.UserName = Convert.ToString(reader["UserName"]);
                                user.Password = Convert.ToString(reader["Password"]);
                                user.FullName = Convert.ToString(reader["FullName"]);
                                user.Type = Convert.ToInt32(reader["Type"]);
                            }
                        }
                    }
                    connection.Close();
                }

                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
