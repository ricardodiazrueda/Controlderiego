using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SprinklerData : Database
    {
        public string Insert()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "INSERT INTO Sprinklers (State) VALUES (0)";

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
        public List<int> ReadAll()
        {
            try
            {
                List<int> list = new List<int>();

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "SELECT * FROM Sprinklers";

                        command.CommandText = query;
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                list.Add(Convert.ToInt32(reader["State"]));
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
    }
}
