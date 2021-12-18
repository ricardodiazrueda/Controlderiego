using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data
{
    public class ProgramData : Database
    {
        public string Insert(int SprinklerID, string ActionTime, int Action)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "INSERT INTO Program (SprinklerID, ActionTime, Action) VALUES ({0}, '{1}', {2})";
                        query = string.Format(query, SprinklerID, ActionTime, Action);

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
        public List<ProgramEntity> ReadPrograms(int SprinklerID)
        {
            try
            {
                List<ProgramEntity> result = new List<ProgramEntity>();
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "SELECT * FROM Program WHERE SprinklerID = {0}";
                        query = string.Format(query, SprinklerID);

                        command.CommandText = query;
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProgramEntity entity = new ProgramEntity();
                                entity.ProgramID = Convert.ToInt32(reader["ProgramID"]);
                                entity.SprinklerID = Convert.ToInt32(reader["SprinklerID"]);
                                entity.ActionTime = Convert.ToString(reader["ActionTime"]);
                                entity.Action = Convert.ToInt32(reader["Action"]);
                                result.Add(entity);
                            }
                        }
                    }
                    connection.Close();
                }

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<ProgramEntity> ReadAll()
        {
            try
            {
                List<ProgramEntity> result = new List<ProgramEntity>();
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "SELECT * FROM Program";

                        command.CommandText = query;
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProgramEntity entity = new ProgramEntity();
                                entity.ProgramID = Convert.ToInt32(reader["ProgramID"]);
                                entity.SprinklerID = Convert.ToInt32(reader["SprinklerID"]);
                                entity.ActionTime = Convert.ToString(reader["ActionTime"]);
                                entity.Action = Convert.ToInt32(reader["Action"]);
                                result.Add(entity);
                            }
                        }
                    }
                    connection.Close();
                }

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public string Delete(int ProgramID)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "DELETE FROM Program WHERE ProgramID = " + ProgramID;

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
