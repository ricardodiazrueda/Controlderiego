using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data
{
    public class LogData : Database
    {
        public string Insert(LogEntity log)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "INSERT INTO Logs (EntityID, LogDate, Type, Data) VALUES ({0}, '{1}', '{2}', '{3}')";
                        query = string.Format(query, log.EntityID != null ? log.EntityID.ToString() : "null", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), log.Type, log.Data);

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
        public List<string> Read(DateTime start, DateTime end)
        {
            try
            {
                List<string> list = new List<string>();
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "SELECT * FROM Logs WHERE LogDate >= '{0}' AND LogDate < '{1}'";
                        query = string.Format(query, start.ToString("yyyy-MM-dd HH:mm:ss"), end.ToString("yyyy-MM-dd HH:mm:ss"));

                        command.CommandText = query;
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(Convert.ToString(reader["LogDate"]) + " " + Convert.ToString(reader["Type"]) + " " + Convert.ToString(reader["Data"]));
                            }
                        }
                    }
                    connection.Close();
                }

                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public string Delete(DateTime start, DateTime end)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "DELETE FROM Logs WHERE LogDate >= '{0}' AND LogDate < '{1}'";
                        query = string.Format(query, start.ToString("yyyy-MM-dd HH:mm:ss"), end.ToString("yyyy-MM-dd HH:mm:ss"));

                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}