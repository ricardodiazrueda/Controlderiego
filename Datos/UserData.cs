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
    }
}
