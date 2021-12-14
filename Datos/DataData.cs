using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataData : Database
    {
        public string Set(string key, string value)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "UPDATE Data SET Value = '{1}' WHERE Key = '{0}'";
                        query = string.Format(query, key, value);

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
        public string Get(string key)
        {
            string data = "";
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "SELECT * FROM Data WHERE Key = '{0}'";
                        query = string.Format(query, key);

                        command.CommandText = query;
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                data = Convert.ToString(reader["Value"]);
                            }
                        }
                    }
                    connection.Close();
                }

                return data;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
