using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Data
{
    public class Database
    {
        string databaseName = "Data Source = ./data.db; Version = 3";
        SQLiteConnection connection = null;
        public SQLiteConnection Connect()
        {
            if (connection != null)
                connection.Dispose();
            connection = new SQLiteConnection(databaseName);
            connection.Open();
            return connection;
        }
        public void Disconnect()
        {
            if (connection != null)
                connection.Dispose();
        }
    }
}