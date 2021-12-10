using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Entities;

namespace Data
{
    public class UserData
    {
        Database database = new Database();
        public string Insert(UserEntity user)
        {
            try
            {
                user.Password = Util.Util.Hash(user.Password);

                string query = "INSERT INTO Users (UserName, Password, FullName) VALUES ('{0}', '{1}', '{2}')";
                query = string.Format(query, user.UserName, user.Password, user.FullName);

                SQLiteConnection connection = database.Connect();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                database.Disconnect();
            }
        }
        public UserEntity Read(string username, string password)
        {
            try
            {
                password = Util.Util.Hash(password);

                string query = "SELECT * FROM Users WHERE UserName = '{0}' AND Password = '{1}'";
                query = string.Format(query, username, password);

                SQLiteConnection connection = database.Connect();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                UserEntity user = null;
                if (reader.Read())
                {
                    user = new UserEntity();
                    user.UserID = Convert.ToInt32(reader["UserID"]);
                    user.UserName = Convert.ToString(reader["UserName"]);
                    user.Password = Convert.ToString(reader["Password"]);
                    user.FullName = Convert.ToString(reader["FullName"]);
                }

                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                database.Disconnect();
            }
        }
    }
}
