using System;
using System.Data.SQLite;
using System.Text;

namespace Naumaxia
{
    class ConnectionClass
    {
        private readonly string connectionString; // readonly -> can assign the variable only in declaration
        private readonly SQLiteConnection conn;  // or in constructor of the same class in which it is declared.
        private string query;
        public ConnectionClass()
        {
            connectionString = "Data Source=stats.db;Version=3";
            conn = new SQLiteConnection(connectionString);
        }

        public void OpenConnection()
        {
            conn.Open();
        }

        public void CloseConnection()
        {
            conn.Close();
        }

        public void CreateQuery(string q)
        {
            query = q;
        }

        public void ExecuteInsertQuery(string winner, string duration)
        {
            var cmd = new SQLiteCommand(query, conn); // Create object for the execution of the query.

            cmd.Parameters.AddWithValue("@winner", winner); // avoid SQL injection
            cmd.Parameters.AddWithValue("@duration", duration);
            cmd.ExecuteNonQuery(); // Execute the query.
        }

        public StringBuilder ExecuteShowQuery()
        {
            // Execute the query and return all db data in a stringbuilder.
            var cmd = new SQLiteCommand(query, conn); // Create object for the execution of the query.
            SQLiteDataReader reader = cmd.ExecuteReader();
            StringBuilder builder = new StringBuilder(); // builder contains all db data.

            while (reader.Read())
                builder.Append(reader.GetString(0)).Append("                 ").Append(reader.GetString(1)).Append(" seconds").Append(Environment.NewLine);

            return builder;
        }

        public void ExecuteDeleteQuery()
        {
            var cmd = new SQLiteCommand(query, conn); // Create object for the execution of the query.
            cmd.ExecuteNonQuery(); // Execute the query.
        }
    }
}
