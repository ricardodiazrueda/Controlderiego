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
                        query = string.Format(query, log.EntityID != null ? log.EntityID.ToString() : "null", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), log.Type, log.Data);

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
    }
}
