using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data
{
    public class RadioData : Database
    {
        public string Insert(int sprinklers)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "INSERT INTO Radios (Sprinklers) VALUES ({0})";
                        query = string.Format(query, sprinklers);

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
        public int ReadQuantity()
        {
            try
            {
                int quantity = 0;

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "SELECT COUNT(*) AS Quantity FROM Radios";

                        command.CommandText = query;
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            quantity = Convert.ToInt32(reader["Quantity"]);
                        }
                    }
                    connection.Close();
                }

                return quantity;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public int ReadQuantity(int radio)
        {
            try
            {
                int quantity = 0;

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "SELECT SUM(Sprinklers) AS Quantity FROM Radios WHERE RadioID < " + radio;

                        command.CommandText = query;
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            quantity = Convert.ToInt32(reader["Quantity"]);
                        }
                    }
                    connection.Close();
                }

                return quantity;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int ReadSprinklers(int radio)
        {
            try
            {
                int sprinklers = 0;

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "SELECT Sprinklers FROM Radios WHERE RadioID = " + radio;

                        command.CommandText = query;
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            sprinklers = Convert.ToInt32(reader["Sprinklers"]);
                        }
                    }
                    connection.Close();
                }

                return sprinklers;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
